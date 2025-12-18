using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeScript.Domain.Entities;

namespace AnimeScript.Domain.Interfaces;

public interface IScriptGeneratorService
{
    // Recebe o pedido e devolve um objeto Roteiro preenchido pela IA
    Task<Roteiro> GerarRoteiroAsync(string prompt, string estilo);
}