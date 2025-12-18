using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeScript.Domain.Entities;

namespace AnimeScript.Domain.Interfaces;

public interface IRoteiroRepository
{
    Task SalvarAsync(Roteiro roteiro);
    Task<IEnumerable<Roteiro>> ListarTodosAsync();
    Task<Roteiro?> ObterPorIdAsync(Guid id);
}