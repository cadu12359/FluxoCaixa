using FluxoCaixa.Lancamentos.Application.DTO;

namespace FluxoCaixa.Lancamentos.Application.Interfaces
{
    public interface IAdicionarLancamentoUseCase
    {
        Task ExecutarCredito(LancamentoDTO lancamentoDto);
        Task ExecutarDebito(LancamentoDTO lancamentoDto);
    }
}