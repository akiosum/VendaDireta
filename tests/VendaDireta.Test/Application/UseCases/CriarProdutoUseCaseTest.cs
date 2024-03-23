using MediatR;
using Moq;
using VendaDireta.Aplication.Requests.Produto;
using VendaDireta.Aplication.UseCases.ProdutoUseCase;
using VendaDireta.Domain.Contracts.Repositories;
using VendaDireta.Domain.Entities;

namespace VendaDireta.Test.Application.UseCases;

public class CriarProdutoUseCaseTest
{
    [Fact]
    public async Task DadoQueOsDadosEstejamOk_Executa_RetornaOId()
    {
        // Arrange
        Mock<ISender> senderMock = new Mock<ISender>();
        Mock<IProdutoRepository> produtoRepositoryMock = new Mock<IProdutoRepository>();

        CriarProdutoRequest request = new CriarProdutoRequest(
            "Teste",
            "Teste",
            10,
            0,
            10);

        var criarProdutoUseCase = new CriarProdutoUseCase(senderMock.Object, produtoRepositoryMock.Object);

        // Act

        var result = await criarProdutoUseCase.Handle(request, new CancellationToken());

        // Assert

        Assert.True(result.IsSuccess);
        produtoRepositoryMock.Verify(pr => pr.Inserir(It.IsAny<Produto>(), default), Times.Once);
    }
}