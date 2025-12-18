using AnimeScript.Domain.Entities;
using AnimeScript.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Mscc.GenerativeAI;

namespace AnimeScript.Infrastructure.Services;

public class ScriptGeneratorService : IScriptGeneratorService
{
    private readonly string _apiKey;

    public ScriptGeneratorService(IConfiguration config)
    {
        _apiKey = config["Gemini:ApiKey"] ?? throw new ArgumentNullException("API Key não configurada");
    }

    public async Task<Roteiro> GerarRoteiroAsync(string prompt, string estilo)
    {
        var googleAI = new GoogleAI(_apiKey);
        var model = googleAI.GenerativeModel("gemini-1.5-flash"); 

        // Instruímos a IA a responder em um formato fácil de "quebrar" via código
        string promptRefinado = $@"
            Crie um roteiro de anime no estilo {estilo}. Contexto: {prompt}.
            Responda EXATAMENTE seguindo este modelo:
            TITULO: [Escreva o nome aqui]
            CENA: [Escreva a descrição da cena aqui]
            DIALOGOS:
            - PersonagemA: Texto da fala
            - PersonagemB: Texto da fala
        ";

        var response = await model.GenerateContent(promptRefinado);
        var textoIA = response.Text ?? "";

        // Chamamos a função que organiza o texto bruto no objeto Roteiro
        return ProcessarRespostaIA(textoIA, estilo);
    }

    private Roteiro ProcessarRespostaIA(string texto, string estilo)
    {
        var roteiro = new Roteiro 
        { 
            Titulo = $"Roteiro de {estilo}", 
            DescricaoCena = "Descrição não gerada",
            Dialogos = new List<Dialogo>() 
        };

        var linhas = texto.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        foreach (var linha in linhas)
        {
            var linhaLimpa = linha.Trim();

            if (linhaLimpa.StartsWith("TITULO:", StringComparison.OrdinalIgnoreCase))
                roteiro.Titulo = linhaLimpa.Replace("TITULO:", "").Trim();
            
            else if (linhaLimpa.StartsWith("CENA:", StringComparison.OrdinalIgnoreCase))
                roteiro.DescricaoCena = linhaLimpa.Replace("CENA:", "").Trim();
            
            else if (linhaLimpa.StartsWith("- "))
            {
                var partes = linhaLimpa.Replace("- ", "").Split(':');
                if (partes.Length >= 2)
                {
                    roteiro.Dialogos.Add(new Dialogo 
                    { 
                        Personagem = partes[0].Trim(), 
                        Texto = string.Join(":", partes.Skip(1)).Trim() 
                    });
                }
            }
        }

        return roteiro;
    }
}