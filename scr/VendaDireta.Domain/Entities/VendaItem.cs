using VendaDireta.Domain.Abstraction;

namespace VendaDireta.Domain.Entities;

public class VendaItem() : Entity
{
    #region Properties

    public Guid IdVenda { get; private set; }
    public Guid IdProduto { get; private set; }
    public decimal Quantidade { get; private set; }
    public decimal ValorUnitario { get; private set; }
    public decimal ValorBruto { get; private set; }

    public Venda Venda { get; set; }
    public Produto Produto { get; set; }

    #endregion Properties

    #region Methods

    public void  CalcularValorBruto()
    {
        ValorBruto = Quantidade * ValorUnitario;
    }

    #endregion Methods
}