using FluxoCaixa.Lancamentos.Application.DTO;
using FluxoCaixa.Lancamentos.Application.UseCases;
using FluxoCaixa.Lancamentos.Domain.Entities;
using FluxoCaixa.Lancamentos.Domain.Enums;
using FluxoCaixa.Lancamentos.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace FluxoCaixa.Lancamentos.Test.Application.UseCases
{
    public class AdicionarLancamentoUseCaseTests
    {
        private readonly ILancamentoRepository _lancamentoRepositoryMock;
        private readonly AdicionarLancamentoUseCase _useCase;

        public AdicionarLancamentoUseCaseTests()
        {
            _lancamentoRepositoryMock = Substitute.For<ILancamentoRepository>();
            ILogger<AdicionarLancamentoUseCase> loggerMock = Substitute.For<ILogger<AdicionarLancamentoUseCase>>();
            _useCase = new AdicionarLancamentoUseCase(_lancamentoRepositoryMock, loggerMock);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(30)]
        public async Task ExecutarCredito_DeveAdicionarLancamentoDeCredito(int valor)
        {
            // Arrange
            var lancamentoDto = new LancamentoDTO { Valor = valor , Data = DateTime.Now };
            
            // Act
            await _useCase.ExecutarCredito(lancamentoDto);
            
            // Assert
            await _lancamentoRepositoryMock.Received(1).Adicionar(
                Arg.Is<Lancamento>(l => l.Tipo == TipoLancamento.Credito && l.Valor == lancamentoDto.Valor));
        }

        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(30)]
        public async Task ExecutarDebito_DeveAdicionarLancamentoDeDebito(int valor)
        {
            // Arrange
            var lancamentoDto = new LancamentoDTO { Valor = valor , Data = DateTime.Now};
            
            // Act
            await _useCase.ExecutarDebito(lancamentoDto);
            
            // Assert
            await _lancamentoRepositoryMock.Received(1).Adicionar(
                Arg.Is<Lancamento>(l => l.Tipo == TipoLancamento.Debito && l.Valor == lancamentoDto.Valor));
        }
    }
}