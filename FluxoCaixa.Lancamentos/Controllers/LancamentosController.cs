using FluxoCaixa.Lancamentos.Application.DTO;
using FluxoCaixa.Lancamentos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.Lancamentos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LancamentosController : ControllerBase
    {
        private readonly IAdicionarLancamento _adicionarLancamento;

        public LancamentosController(IAdicionarLancamento adicionarLancamento)
        {
            _adicionarLancamento = adicionarLancamento;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(LancamentoDTO lancamentoDTO)
        {
            await _adicionarLancamento.Executar(lancamentoDTO);
            return Ok();
        }
    }
}