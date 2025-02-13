using FluxoCaixa.Lancamentos.Domain.Enums;

namespace FluxoCaixa.Lancamentos.Domain.Entities;

public class Lancamento
{
    public Guid Id { get; private set; }
    public TipoLancamento Tipo { get; private set; } // "Debito" ou "Credito"
    public decimal Valor { get; private set; }
    public DateTime Data { get; private set; }

    public Lancamento(TipoLancamento tipo, decimal valor, DateTime data)
    {
        Id = Guid.NewGuid();
        Tipo = tipo;
        Valor = valor;
        Data = data;
    }
}