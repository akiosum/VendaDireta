using FastResults.Results;
using Mapster;
using MediatR;
using VendaDireta.Aplication.Abstractions;
using VendaDireta.Aplication.Dto.Receita;
using VendaDireta.Aplication.Patterns.Builders;
using VendaDireta.Aplication.Requests.Receita;
using VendaDireta.Domain.Entities;

namespace VendaDireta.Aplication.UseCases.ReceitaUseCase;

public class CriarReceitaUseCase(ISender sender)
    : BaseUseCase<CriarReceitaRequest>(sender)
{
    public override async Task<BaseResult> Handle(
        CriarReceitaRequest request,
        CancellationToken cancellationToken)
    {
        CriarReceitaDto receita = request.Adapt<CriarReceitaDto>();

        ReceitaBuilder builder = new ReceitaBuilder(receita);
        List<Receita> receitas = builder
            .Iniciar()
            .AdicionarData()
            .AdicionarDocumento()
            .AdicionarValores()
            .Buildar();

        return BaseResult.Sucess();
    }
}