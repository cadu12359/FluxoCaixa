using FluxoCaixa.Lancamentos.Domain.Entities;

namespace FluxoCaixa.Lancamentos.Domain.Interfaces
{
    public interface ILancamentoRepository
    {
        Task Adicionar(Lancamento lancamento);
    }
}