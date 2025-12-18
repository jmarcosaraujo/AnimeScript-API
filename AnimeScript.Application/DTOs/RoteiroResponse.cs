using System;
using System.Collections.Generic;
namespace AnimeScript.Application.DTOs;

// O que a API vai devolver para o usuário
public record RoteiroResponse(
    Guid Id,
    string Titulo,
    string Estilo,
    string DescricaoCena,
    List<PersonagemDto> Personagens,
    List<DialogoDto> Dialogos
);

public record PersonagemDto(string Nome, string Papel, string Caracteristicas);
public record DialogoDto(string NomePersonagem, string Fala);