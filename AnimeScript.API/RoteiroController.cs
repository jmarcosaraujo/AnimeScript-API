using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AnimeScript.Application.Interfaces;

namespace AnimeScript.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoteiroController : ControllerBase
{
    private readonly IRoteiroAppService _appService;

    public RoteiroController(IRoteiroAppService appService)
    {
        _appService = appService;
    }

    [HttpPost("gerar")]
    public async Task<IActionResult> Gerar([FromBody] string prompt, [FromQuery] string estilo = "Shonen")
    {
        // Chama o maestro (Application) para processar o pedido
        var resultado = await _appService.GerarEGuardarRoteiroAsync(prompt, estilo);
        return Ok(resultado);
    }

    [HttpGet("historico")]
    public async Task<IActionResult> Listar()
    {
        var resultado = await _appService.ObterHistoricoAsync();
        return Ok(resultado);
    }
}