using FluxoCaixa.Consolidado.Application.UseCases;
using FluxoCaixa.Lancamentos.Domain.Entities;
using FluxoCaixa.Lancamentos.Domain.Enums;
using FluxoCaixa.Lancamentos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Shouldly;

namespace FluxoCaixa.Consolidado.Test.Application.UseCases
{
    public class ObterConsolidadoDiarioUseCaseTests
    {
        private readonly AppDbContext _context;
        private readonly ObterConsolidadoDiarioUseCase _useCase;
        private readonly ILogger<ObterConsolidadoDiarioUseCase> _logger;

        public ObterConsolidadoDiarioUseCaseTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "FluxoCaixaTestDb")
                .Options;

            _context = new AppDbContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            
            _logger = Substitute.For<ILogger<ObterConsolidadoDiarioUseCase>>();

            _useCase = new ObterConsolidadoDiarioUseCase(_context, _logger);
        }

        [Fact]
        public async Task ObterSaldo_DeveRetornarSaldoCorreto()
        {
            // Arrange
            var hoje = DateTime.Now.Date;
            _context.Lancamentos.AddRange(
                new Lancamento(TipoLancamento.Credito, 100),
                new Lancamento(TipoLancamento.Debito, 20),
                new Lancamento(TipoLancamento.Credito, 30)
            );
            
            await _context.SaveChangesAsync();

            // Act
            var resultado = await _useCase.ObterSaldo();

            // Assert
            resultado.Data.ShouldBe(hoje);
            resultado.TotalCredito.ShouldBe(130);
            resultado.TotalDebito.ShouldBe(20);
            resultado.Saldo.ShouldBe(110);
        }
        
        [Fact]
        public async Task ObterSaldo_SemLancamentos_DeveRetornarSaldoZerado()
        {
            // Act
            var resultado = await _useCase.ObterSaldo();

            // Assert
            resultado.Data.ShouldBe(DateTime.UtcNow.Date);
            resultado.TotalCredito.ShouldBe(0);
            resultado.TotalDebito.ShouldBe(0);
            resultado.Saldo.ShouldBe(0);
        }
        
        [Fact]
        public async Task ObterSaldo_ErroAoAcessarBanco_DeveLancarExcecao()
        {
            var invalidOptions = new DbContextOptionsBuilder<AppDbContext>().Options;
            await using var invalidContext = new AppDbContext(invalidOptions);
            var useCase = new ObterConsolidadoDiarioUseCase(invalidContext, _logger);

            // Act & Assert
            await Should.ThrowAsync<InvalidOperationException>(async () => await useCase.ObterSaldo());
        }
    }
}