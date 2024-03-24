namespace VendaDireta.Aplication.Dto.Receita;

public class ReceitaDto()
{
    public DateTime DataDeVencimento { get; set; }
    public DateTime? DateDePagamento { get; set; }
    public Guid IdCliente { get; set; }
    public int Parcela { get; set; }
    public decimal Bruto { get; set; }
    public decimal Saldo { get; set; }
    public string Documento { get; set; } = string.Empty;
    public bool Ativo { get; set; }
}