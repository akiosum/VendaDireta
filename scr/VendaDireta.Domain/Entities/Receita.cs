using VendaDireta.Domain.Abstraction;

namespace VendaDireta.Domain.Entities;

public class Receita() : Entity
{
    #region Properties

    public DateTime DataDeVencimento { get; set; }
    public DateTime? DateDePagamento { get; set; }
    public Guid IdCliente { get; set; }
    public int Parcela { get; set; }
    public decimal Bruto { get; set; }
    public decimal Saldo { get; set; }
    public string Documento { get; set; } = string.Empty;
    public bool Ativo { get; set; }
    public Cliente Cliente { get; set; } = new("", "");

    #endregion Properties

    #region Constructors

    public Receita(
        DateTime dataDeVencimento,
        DateTime? dateDePagamento,
        int parcela,
        decimal bruto,
        decimal saldo,
        string documento,
        bool ativo) : this()
    {
        DataDeVencimento = dataDeVencimento;
        DateDePagamento = dateDePagamento;
        Parcela = parcela;
        Bruto = bruto;
        Saldo = saldo;
        Documento = documento;
        Ativo = ativo;
    }

    #endregion Constructors

    #region Methods

    public void Pagar(DateTime dataDePagamento, decimal valorPago)
    {
        DateDePagamento = dataDePagamento;
        Saldo -= valorPago;
    }

    #endregion Methods
}