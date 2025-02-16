using FluxoCaixa.Consolidado.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.Consolidado.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsolidadoController : ControllerBase
    {
        private readonly IObterConsolidadoDiario _obterConsolidadoDiario;

        public ConsolidadoController(IObterConsolidadoDiario obterConsolidadoDiario)
        {
            _obterConsolidadoDiario = obterConsolidadoDiario;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterConsolidado()
        {
            var consolidado = await _obterConsolidadoDiario.ObterSaldo();
            return Ok(consolidado);
        }
    }
}