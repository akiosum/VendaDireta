using VendaDireta.Domain.Abstraction;
using VendaDireta.Domain.Enums;

namespace VendaDireta.Domain.Entities;

public class Estoque() : Entity
{
    #region Properties

    public Guid IdProduto { get; set; }
    public decimal Quantidade { get; set; }
    public Produto Produto { get; set; }

    #endregion Properties

    #region Constructors

    public Estoque(decimal quantidade) : this()
    {
        Quantidade = quantidade;
        Produto = new Produto();
    }

    #endregion Constructors

    #region Methods

    public void AjustarSaldo(decimal quantidade, TipoEstoque tipo)
    {
        switch (tipo)
        {
            case TipoEstoque.Saida:
                Quantidade -= quantidade;
                break;
            case TipoEstoque.Entrada:
            default:
                Quantidade += quantidade;
                break;
        }

        DataDeAlteracao = DateTime.Now;
    }

    #endregion Methods
}