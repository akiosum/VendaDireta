using MediatR;
using Moq;
using VendaDireta.Aplication.Requests.Produto;
using VendaDireta.Aplication.UseCases.ProdutoUseCase;
using VendaDireta.Domain.Contracts.Repositories;
using VendaDireta.Domain.Entities;

namespace VendaDireta.Test.Application.UseCases;

public class ObterTodosProdutosUseCaseTest
{
    [Fact]
    public async Task DadoQueExistaDoisProdutos_Executa_RetornaDoisProdutoDto()
    {
        // Arrange
        Mock<ISender> senderMock = new Mock<ISender>();
        Mock<IProdutoRepository> produtoRepositoryMock = new Mock<IProdutoRepository>();
        
        List<Produto> produtos =
        [
            new("Descricao 1", "Descricao 1"),
            new("Descricao 2", "Descricao 2"),
            new("Descricao 3", "Descricao 3")
        ];
        produtos.ForEach(produto => produto.Criar(10, 10));

        produtoRepositoryMock.Setup(pr => pr.ObterTodosProdutos(default).Result).Returns(produtos);

        var obterTodosProduto = new ObterTodosRequest();
        var obterTodosProdutoUseCase = new ObterTodosUseCase(senderMock.Object, produtoRepositoryMock.Object);

        // Act
        var result = await obterTodosProdutoUseCase.Handle(obterTodosProduto, default);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.NotEmpty(result.Value);
        Assert.Equal(3, result.Value.Count);

        produtoRepositoryMock.Verify(pr => pr.ObterTodosProdutos(default).Result, Times.Once);
    }
}