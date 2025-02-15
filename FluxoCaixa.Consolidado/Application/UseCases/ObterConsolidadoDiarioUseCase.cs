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

        public ObterConsolidadoDiarioUseCase(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<ConsolidadoDiarioDTO> ObterSaldo()
        {
            var hoje = DateTime.UtcNow.Date;

            var totalCredito = await _context.Lancamentos
                .Where(l => l.Tipo == TipoLancamento.Credito && l.Data.Date == hoje)
                .SumAsync(l => l.Valor);

            var totalDebito = await _context.Lancamentos
                .Where(l => l.Tipo == TipoLancamento.Debito && l.Data.Date == hoje)
                .SumAsync(l => l.Valor);

            var saldo = totalCredito - totalDebito;

            return new ConsolidadoDiarioDTO{ Data = hoje, Saldo = saldo, TotalCredito = totalCredito, TotalDebito = totalDebito };
        }
    }
}