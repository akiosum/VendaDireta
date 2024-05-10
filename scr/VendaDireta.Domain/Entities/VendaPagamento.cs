using VendaDireta.Domain.Abstraction;
using VendaDireta.Domain.Enums;

namespace VendaDireta.Domain.Entities;

public class VendaPagamento() : Entity
{
    #region Properties

    public Guid IdVenda { get; private set; }
    public TipoPagamento TipoPagamento { get; private set; }
    public decimal ValorPago { get; private set; }
    public decimal ValorTroco { get; private set; }

    public Venda Venda { get; set; }

    #endregion Properties

    #region Methods

    public void CalcularTroco(decimal valorTotal)
    {
        decimal troco = ValorPago - valorTotal;
        ValorTroco = troco <= 0 ? 0 : troco;
    }

    #endregion Methods
}