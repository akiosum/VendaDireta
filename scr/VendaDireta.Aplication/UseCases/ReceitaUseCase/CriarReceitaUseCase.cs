using FastResults.Results;
using Mapster;
using MediatR;
using VendaDireta.Aplication.Abstractions;
using VendaDireta.Aplication.Contracts.Patterns;
using VendaDireta.Aplication.Dto.Receita;
using VendaDireta.Aplication.Requests.Receita;

namespace VendaDireta.Aplication.UseCases.ReceitaUseCase;

public class CriarReceitaUseCase(
    ISender sender,
    IReceitaBuilder receitaBuilder)
    : BaseUseCase<CriarReceitaRequest>(sender)
{
    public override async Task<BaseResult> Handle(
        CriarReceitaRequest request,
        CancellationToken cancellationToken)
    {
        CriarReceitaDto receita = request.Adapt<CriarReceitaDto>();
        List<ReceitaDto> receitas = receitaBuilder
            .Iniciar(receita)
            .AdicionarData()
            .AdicionarDocumento()
            .AdicionarValores()
            .Buildar();

        return BaseResult.Sucess();
    }
}