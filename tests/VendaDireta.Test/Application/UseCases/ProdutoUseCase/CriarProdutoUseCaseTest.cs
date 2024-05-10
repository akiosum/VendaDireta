using MediatR;
using Moq;
using VendaDireta.Aplication.Requests.Produto;
using VendaDireta.Aplication.UseCases.ProdutoUseCase;
using VendaDireta.Domain.Contracts.Repositories;

namespace VendaDireta.Test.Application.UseCases.ProdutoUseCase;

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
            10);

        var criarProdutoUseCase = new CriarProdutoUseCase(senderMock.Object, produtoRepositoryMock.Object);

        // Act

        var result = await criarProdutoUseCase.Handle(request, new CancellationToken());

        // Assert

        Assert.True(result.IsSuccess);
        produtoRepositoryMock.Verify(pr => pr.Inserir(It.IsAny<VendaDireta.Domain.Entities.Produto>(), default), Times.Once);
    }
}