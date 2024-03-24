using Mapster;
using MediatR;
using Moq;
using VendaDireta.Aplication.Contracts.Patterns;
using VendaDireta.Aplication.Dto.Receita;
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
        Mock<IReceitaBuilder> receitaBuilderMock = new Mock<IReceitaBuilder>();

        CriarReceitaRequest receita = new CriarReceitaRequest(
            DateTime.Now,
            30,
            3,
            Guid.NewGuid(),
            string.Empty,
            150);

        CriarReceitaDto receitaDto = receita.Adapt<CriarReceitaDto>();
        List<ReceitaDto> receitas =
        [
            new ReceitaDto(),
            new ReceitaDto(),
            new ReceitaDto()
        ];

        receitaBuilderMock.Setup(rb => rb.Iniciar(receitaDto));
        receitaBuilderMock.Setup(rb => rb.AdicionarData());
        receitaBuilderMock.Setup(rb => rb.AdicionarDocumento());
        receitaBuilderMock.Setup(rb => rb.AdicionarValores());
        receitaBuilderMock.Setup(rb => rb.Buildar()).Returns(receitas);

        var criarReceitaUseCase = new CriarReceitaUseCase(senderMock.Object, receitaBuilderMock.Object);

        // Act

        var result = await criarReceitaUseCase.Handle(receita, new CancellationToken());

        // Assert

        Assert.True(result.IsSuccess);

        receitaBuilderMock.Verify(rb => rb.Iniciar(receitaDto), Times.Once);
        receitaBuilderMock.Verify(rb => rb.Buildar(), Times.Once);
    }
}