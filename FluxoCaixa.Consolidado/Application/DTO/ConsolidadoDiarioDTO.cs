namespace FluxoCaixa.Consolidado.Application.DTO;

public class ConsolidadoDiarioDTO
{
    public DateTime Data { get; set; }
    public decimal Saldo { get; set; }
    public decimal TotalCredito { get; set; }
    public decimal TotalDebito  { get; set; }
}