using VendaDireta.Domain.Abstraction;

namespace VendaDireta.Domain.Entities;

public class Estoque : Entity
{
    #region Properties

    public Guid IdProduto { get; set; }
    public decimal Quantidade { get; set; }
    public Produto Produto { get; set; }

    #endregion Properties

    #region Constructors

    public Estoque(decimal quantidade)
    {
        Quantidade = quantidade;
        Produto = new Produto();
    }

    #endregion Constructors
}