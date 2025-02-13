using FluxoCaixa.Lancamentos.Domain.Enums;

namespace FluxoCaixa.Lancamentos.Application.DTO;

public class LancamentoDTO
{
    public TipoLancamento Tipo { get; set; }
    public decimal Valor { get; set; }
    public DateTime Data { get; set; }
}