using VendaDireta.Domain.Abstraction;

namespace VendaDireta.Domain.Entities;

public class Venda() : Entity
{
    #region Properties

    public Guid? IdCliente { get; set; } = null;
    public ICollection<VendaItem> VendaItem { get; private set; } = new List<VendaItem>();
    public ICollection<VendaPagamento> VendaPagamento { get; private set; } = new List<VendaPagamento>();

    #endregion Properties

    #region Methods

    public void Criar(List<VendaItem> itens, List<VendaPagamento> pagamentos)
    {
        itens.ForEach(item => item.CalcularValorBruto());
        
        decimal valorTotal = itens.Sum(item => item.ValorBruto);
        pagamentos.ForEach(pag => pag.CalcularTroco(valorTotal));

        VendaItem = itens;
        VendaPagamento = pagamentos;
    }

    #endregion Methods
}