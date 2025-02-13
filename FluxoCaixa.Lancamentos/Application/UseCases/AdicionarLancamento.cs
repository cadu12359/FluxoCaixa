using FluxoCaixa.Lancamentos.Application.DTO;
using FluxoCaixa.Lancamentos.Application.Interfaces;
using FluxoCaixa.Lancamentos.Domain.Entities;
using FluxoCaixa.Lancamentos.Domain.Interfaces;
using MassTransit;

namespace FluxoCaixa.Lancamentos.Application.UseCases
{
    public class AdicionarLancamento : IAdicionarLancamento
    {
        private readonly ILancamentoRepository _lancamentoRepository;
        private readonly IBus _bus;

        public AdicionarLancamento(ILancamentoRepository lancamentoRepository, IBus bus)
        {
            _lancamentoRepository = lancamentoRepository;
            _bus = bus;
        }

        public async Task Executar(LancamentoDTO lancamentoDTO)
        {
            var lancamento = new Lancamento(lancamentoDTO.Tipo, lancamentoDTO.Valor, lancamentoDTO.Data);
            await _lancamentoRepository.Adicionar(lancamento);

            // Publica o lançamento no RabbitMQ usando MassTransit
            await _bus.Publish(lancamentoDTO);
        }
    }
}