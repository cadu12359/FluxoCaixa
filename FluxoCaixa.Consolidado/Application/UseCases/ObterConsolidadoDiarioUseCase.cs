using FluxoCaixa.Consolidado.Application.DTO;
using FluxoCaixa.Consolidado.Application.Interfaces;
using FluxoCaixa.Lancamentos.Application.DTO;
using FluxoCaixa.Lancamentos.Domain.Enums;
using FluxoCaixa.Lancamentos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FluxoCaixa.Consolidado.Application.UseCases
{
    public class ObterConsolidadoDiarioUseCase : IObterConsolidadoDiario
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ObterConsolidadoDiarioUseCase> _logger;

        public ObterConsolidadoDiarioUseCase(AppDbContext context, ILogger<ObterConsolidadoDiarioUseCase> logger)
        {
            _context = context;
            _logger = logger;
        }
        
        public async Task<ConsolidadoDiarioDTO> ObterSaldo()
        {
            _logger.LogInformation("Iniciando busca do Saldo.");
            
            var hoje = DateTime.UtcNow.Date;

            var totalCredito = await _context.Lancamentos
                .Where(l => l.Tipo == TipoLancamento.Credito)
                .SumAsync(l => l.Valor);

            var totalDebito = await _context.Lancamentos
                .Where(l => l.Tipo == TipoLancamento.Debito)
                .SumAsync(l => l.Valor);

            var saldo = totalCredito - totalDebito;
            
            _logger.LogInformation($"Saldo consolidado: {saldo}");

            return new ConsolidadoDiarioDTO{ Data = hoje, Saldo = saldo, TotalCredito = totalCredito, TotalDebito = totalDebito };
        }
    }
}