using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeScript.Application.DTOs;

namespace AnimeScript.Application.Interfaces;

public interface IRoteiroAppService
{
    Task<RoteiroResponse> GerarEGuardarRoteiroAsync(string prompt, string estilo);
    Task<IEnumerable<RoteiroResponse>> ObterHistoricoAsync();
}