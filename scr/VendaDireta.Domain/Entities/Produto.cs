using VendaDireta.Domain.Abstraction;

namespace VendaDireta.Domain.Entities;

public class Produto() : Entity
{
    #region Properties

    public string Descricao { get; private set; } = string.Empty;
    public string DescricaoReduzida { get; private set; } = string.Empty;
    public ICollection<ProdutoPreco> ProdutoPreco { get; private set; } = new List<ProdutoPreco>();
    public ICollection<Estoque> Estoque { get; private set; } = new List<Estoque>();
    public ICollection<VendaItem> VendaItem { get; private set; } = new List<VendaItem>();

    #endregion Properties

    #region Constructors

    public Produto(string descricao, string descricaoReduzida) : this()
    {
        Descricao = descricao;
        DescricaoReduzida = descricaoReduzida;
        ProdutoPreco = new List<ProdutoPreco>();
        Estoque = new List<Estoque>();
    }

    #endregion Constructors

    #region Methods

    public void Criar(
        decimal preco,
        decimal estoqueInicial)
    {
        ProdutoPreco = new List<ProdutoPreco> { new(preco) };
        Estoque = new List<Estoque> { new(estoqueInicial) };
    }

    public void Atualizar(string descricao, string descricaoReduzida, decimal preco)
    {
        Descricao = descricao;
        DescricaoReduzida = descricaoReduzida;
        DataDeAlteracao = DateTime.Now;

        foreach (ProdutoPreco produtoPreco in ProdutoPreco)
        {
            produtoPreco.Atualizar(preco);
        }
    }

    #endregion Methods
}