using FluxoCaixa.Lancamentos.Application.DTO;
using FluxoCaixa.Lancamentos.Application.Interfaces;
using FluxoCaixa.Lancamentos.Domain.Entities;
using FluxoCaixa.Lancamentos.Domain.Enums;
using FluxoCaixa.Lancamentos.Domain.Interfaces;
using FluxoCaixa.Lancamentos.Infrastructure.Messaging;
using FluxoCaixa.Lancamentos.Infrastructure.Repositories;

namespace FluxoCaixa.Lancamentos.Application.UseCases
{
    public class AdicionarLancamentoUseCase : IAdicionarLancamentoUseCase
    {
        private readonly ILancamentoRepository _lancamentoRepository;
        private readonly ILogger<AdicionarLancamentoUseCase> _logger;

        public AdicionarLancamentoUseCase(ILancamentoRepository lancamentoRepository, ILogger<AdicionarLancamentoUseCase> logger)
        {
            _lancamentoRepository = lancamentoRepository;
            _logger = logger;
        }

        public async Task ExecutarCredito(LancamentoDTO lancamentoDto)
        {
            _logger.LogInformation($"Adicionando lancamento de crédito, valor: {lancamentoDto.Valor}");
            
            var lancamento = new Lancamento(TipoLancamento.Credito, lancamentoDto.Valor);
            await _lancamentoRepository.Adicionar(lancamento);
        }
        
        public async Task ExecutarDebito(LancamentoDTO lancamentoDto)
        {
            _logger.LogInformation($"Adicionando lancamento de débito, valor: {lancamentoDto.Valor}");
            
            var lancamento = new Lancamento(TipoLancamento.Debito, lancamentoDto.Valor);
            await _lancamentoRepository.Adicionar(lancamento);
        }
    }
}