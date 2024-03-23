using VendaDireta.Domain.Entities;

namespace VendaDireta.Test.Domain.Entities;

public class ProdutoTest
{
    [Fact]
    public void TestCriandoProduto()
    {
        Produto produto = new Produto("Descricao Teste", "Descricao Reduzida Teste");
        produto.Criar(decimal.Zero, decimal.Zero);

        Assert.NotEqual(0, produto.ProdutoPreco.Count);
        Assert.NotEqual(0, produto.Estoque.Count);
    }
}