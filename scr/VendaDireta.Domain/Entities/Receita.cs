using VendaDireta.Domain.Abstraction;

namespace VendaDireta.Domain.Entities;

public class Receita(
    DateTime dataDeVencimento,
    DateTime? dateDePagamento,
    Guid idCliente,
    int parcela,
    decimal bruto,
    decimal saldo,
    string documento,
    bool ativo,
    Cliente cliente)
    : Entity
{
    #region Properties

    public DateTime DataDeVencimento { get; private set; } = dataDeVencimento;
    public DateTime? DateDePagamento { get; private set; } = dateDePagamento;
    public Guid IdCliente { get; private set; } = idCliente;
    public int Parcela { get; private set; } = parcela;
    public decimal Bruto { get; private set; } = bruto;
    public decimal Saldo { get; private set; } = saldo;
    public string Documento { get; private set; } = documento;
    public bool Ativo { get; private set; } = ativo;
    public Cliente Cliente { get; private set; } = cliente;

    #endregion Properties

    #region Methods

    public void Pagar(DateTime dataDePagamento, decimal valorPago)
    {
        DateDePagamento = dataDePagamento;
        Saldo -= valorPago;
    }

    #endregion Methods
}