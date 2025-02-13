using FluxoCaixa.Lancamentos.Domain.Entities;
using FluxoCaixa.Lancamentos.Domain.Interfaces;
using FluxoCaixa.Lancamentos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FluxoCaixa.Lancamentos.Infrastructure.Repositories
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private readonly AppDbContext _context;

        public LancamentoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Adicionar(Lancamento lancamento)
        {
            await _context.Lancamentos.AddAsync(lancamento);
            await _context.SaveChangesAsync();
        }
    }
}