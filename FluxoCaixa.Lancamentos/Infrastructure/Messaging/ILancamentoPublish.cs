using FluxoCaixa.Lancamentos.Application.DTO;

namespace FluxoCaixa.Lancamentos.Infrastructure.Messaging;

public interface ILancamentoPublish
{
     Task Publish(LancamentoDTO lancamentoDto);
}