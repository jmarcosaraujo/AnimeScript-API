using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeScript.Domain.Entities;

public class Roteiro
{
    // Identificador único (importante para o banco de dados)
    public Guid Id { get; set; } = Guid.NewGuid();
    
    // Dados de entrada do usuário
    public string Titulo { get; set; } = string.Empty;
    public string PromptOriginal { get; set; } = string.Empty;
    public string Estilo { get; set; } = string.Empty; // Ex: Shonen, Isekai, Cyberpunk
    
    // Metadados
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

    // Conteúdo gerado pela Inteligência Artificial
    public string DescricaoCena { get; set; } = string.Empty;
    public List<Personagem> Personagens { get; set; } = new();
    public List<Dialogo> Dialogos { get; set; } = new();
}

public class Personagem
{
    public string Nome { get; set; } = string.Empty;
    public string Papel { get; set; } = string.Empty; // Protagonista, Vilão, Alívio Cômico
    public string Caracteristicas { get; set; } = string.Empty;
}

public class Dialogo 
{
    public string Personagem { get; set; } = string.Empty;
    public string Texto { get; set; } = string.Empty;
}