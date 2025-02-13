using FluxoCaixa.Lancamentos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FluxoCaixa.Lancamentos.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Lancamento> Lancamentos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}