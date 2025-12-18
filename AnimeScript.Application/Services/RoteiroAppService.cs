using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeScript.Application.DTOs;
using AnimeScript.Application.Interfaces;
using AnimeScript.Domain.Interfaces;
using AnimeScript.Domain.Entities;

namespace AnimeScript.Application.Services;

public class RoteiroAppService : IRoteiroAppService
{
    private readonly IScriptGeneratorService _aiService;
    private readonly IRoteiroRepository _repository;

    // Injeção de Dependência: O serviço recebe as interfaces, não as implementações fixas
    public RoteiroAppService(IScriptGeneratorService aiService, IRoteiroRepository repository)
    {
        _aiService = aiService;
        _repository = repository;
    }

    public async Task<RoteiroResponse> GerarEGuardarRoteiroAsync(string prompt, string estilo)
    {
        // 1. Chama a IA para gerar o roteiro
        var roteiro = await _aiService.GerarRoteiroAsync(prompt, estilo);

        // 2. Salva o resultado no banco de dados
        await _repository.SalvarAsync(roteiro);

        // 3. Mapeia para o DTO de resposta (Transforma Entidade em DTO)
        return MapToResponse(roteiro);
    }

    public async Task<IEnumerable<RoteiroResponse>> ObterHistoricoAsync()
    {
        var roteiros = await _repository.ListarTodosAsync();
        return roteiros.Select(MapToResponse);
    }

    // Método auxiliar de mapeamento (em projetos maiores, usaríamos AutoMapper)
    private static RoteiroResponse MapToResponse(Roteiro r) => new(
        r.Id,
        r.Titulo,
        r.Estilo,
        r.DescricaoCena,
        r.Personagens.Select(p => new PersonagemDto(p.Nome, p.Papel, p.Caracteristicas)).ToList(),
        r.Dialogos.Select(d => new DialogoDto(d.Personagem, d.Texto)).ToList()
    );
}