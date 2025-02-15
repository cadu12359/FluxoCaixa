using FluxoCaixa.Lancamentos.Application.DTO;
using FluxoCaixa.Lancamentos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.Lancamentos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LancamentosController : ControllerBase
    {
        private readonly IAdicionarLancamentoUseCase _adicionarLancamentoUseCase;

        public LancamentosController(IAdicionarLancamentoUseCase adicionarLancamentoUseCase)
        {
            _adicionarLancamentoUseCase = adicionarLancamentoUseCase;
        }

        /// <summary>
        /// Adiciona um lançamento tipo Debito no banco de cados
        /// </summary>
        /// <param name="lancamentoDTO"></param>
        /// <returns>lancamentoDTO</returns>
        [HttpPost("Debito")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AdicionarLancamentoDebito(LancamentoDTO lancamentoDTO)
        {
            await _adicionarLancamentoUseCase.ExecutarDebito(lancamentoDTO);
            return Ok(lancamentoDTO);
        }
        
        /// <summary>
        /// Adiciona um lançamento tipo Credito no banco de cados
        /// </summary>
        /// <param name="lancamentoDTO"></param>
        /// <returns>lancamentoDTO</returns>
        [HttpPost("Credito")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AdicionarLancamentoCredito(LancamentoDTO lancamentoDTO)
        {
            await _adicionarLancamentoUseCase.ExecutarCredito(lancamentoDTO);
            return Ok(lancamentoDTO);
        }
    }
}