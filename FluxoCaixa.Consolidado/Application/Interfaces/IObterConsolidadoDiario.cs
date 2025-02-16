using FluxoCaixa.Consolidado.Application.DTO;
using FluxoCaixa.Lancamentos.Application.DTO;

namespace FluxoCaixa.Consolidado.Application.Interfaces
{
    public interface IObterConsolidadoDiario
    {
        Task<ConsolidadoDiarioDTO> ObterSaldo();
    }
}
