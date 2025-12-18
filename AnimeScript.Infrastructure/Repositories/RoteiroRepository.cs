using AnimeScript.Domain.Entities;
using AnimeScript.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimeScript.Infrastructure.Repositories;

public class RoteiroRepository : IRoteiroRepository
{
    // 1. Implementação do SalvarAsync (conforme o erro indicou)
    public async Task SalvarAsync(Roteiro roteiro)
    {
        // Simulação de salvamento
        await Task.CompletedTask;
    }

    // 2. Implementação do ListarTodosAsync
    public async Task<IEnumerable<Roteiro>> ListarTodosAsync()
    {
        // Retorna uma lista vazia por enquanto para não dar erro de tipo
        return await Task.FromResult(new List<Roteiro>());
    }

    // 3. Implementação do ObterPorIdAsync
    public async Task<Roteiro?> ObterPorIdAsync(Guid id)
    {
        // Retorna nulo por enquanto (simulando que não achou no banco)
        return await Task.FromResult<Roteiro?>(null);
    }
}