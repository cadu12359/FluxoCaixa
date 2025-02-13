using FluxoCaixa.Lancamentos.Application.DTO;

namespace FluxoCaixa.Lancamentos.Application.Interfaces
{
    public interface IAdicionarLancamento
    {
        Task Executar(LancamentoDTO lancamentoDto);
    }
}