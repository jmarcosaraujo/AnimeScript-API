using AnimeScript.Domain.Interfaces;
using AnimeScript.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimeScript.Infrastructure.Services;

public class ScriptGeneratorService : IScriptGeneratorService
{
    public async Task<Roteiro> GerarRoteiroAsync(string prompt, string estilo)
    {
        // Criamos o objeto Roteiro conforme a sua Domain exige
        var novoRoteiro = new Roteiro
        {
            Titulo = $"Aventura {estilo}",
            DescricaoCena = $"Cena gerada a partir de: {prompt}",
            
        // Dentro do método GerarRoteiroAsync no ScriptGeneratorServices.cs
        Dialogos = new List<Dialogo> 
{
    new Dialogo { Personagem = "Protagonista", Texto = "Eu nunca vou desistir!" },
    new Dialogo { Personagem = "Antagonista", Texto = "Sua persistência é admirável." }
}
        };

        return await Task.FromResult(novoRoteiro);
    }
}