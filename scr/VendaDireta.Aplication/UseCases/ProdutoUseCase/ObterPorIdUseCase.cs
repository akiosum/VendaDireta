using FastResults.Results;
using Mapster;
using MediatR;
using VendaDireta.Aplication.Abstractions;
using VendaDireta.Aplication.Dto.Produto;
using VendaDireta.Aplication.Requests.Produto;
using VendaDireta.Domain.Contracts.Repositories;
using VendaDireta.Domain.Entities;
using VendaDireta.Shared.Messages;

namespace VendaDireta.Aplication.UseCases.ProdutoUseCase;

public class ObterPorIdUseCase(
    ISender sender,
    IProdutoRepository produtoRepository)
    : BaseUseCase<ObterPorIdRequest, ProdutoDto>(sender)
{
    public override async Task<BaseResult<ProdutoDto>> Handle(ObterPorIdRequest request,
        CancellationToken cancellationToken)
    {
        Produto? produto = await produtoRepository.ObterPorIdComDependencias(request.Id, cancellationToken);
        if (produto is null)
        {
            return BaseResult.Failure<ProdutoDto>(VendaMensagem.Comum.NenhumRegistroEncontrado);
        }

        return produto.Adapt<ProdutoDto>();
    }
}