using MediatR;
using Moq;
using VendaDireta.Aplication.Requests.Receita;
using VendaDireta.Aplication.UseCases.ReceitaUseCase;

namespace VendaDireta.Test.Application.UseCases.ReceitaUseCase;

public class CriarReceitasUseCaseTest
{
    [Fact]
    public async Task DadoTresParcelas_Executa_CriaTresParcelas()
    {
        // Arrange
        Mock<ISender> senderMock = new Mock<ISender>();

        CriarReceitaRequest receita = new CriarReceitaRequest(
            DateTime.Now,
            30,
            3,
            string.Empty,
            150);

        var criarReceitaUseCase = new CriarReceitaUseCase(senderMock.Object);

        // Act

        var result = await criarReceitaUseCase.Handle(receita, new CancellationToken());

        // Assert

        Assert.True(result.IsSuccess);
    }
}