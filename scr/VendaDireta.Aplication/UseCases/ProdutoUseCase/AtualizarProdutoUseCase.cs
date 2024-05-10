using FastResults.Results;
using Mapster;
using MediatR;
using VendaDireta.Aplication.Abstractions;
using VendaDireta.Aplication.Dto.Produto;
using VendaDireta.Aplication.Requests.Produto;
using VendaDireta.Domain.Contracts.Repositories;
using VendaDireta.Domain.Entities;

namespace VendaDireta.Aplication.UseCases.ProdutoUseCase;

public class AtualizarProdutoUseCase(
    ISender sender,
    IProdutoRepository produtoRepository) :
    BaseUseCase<AtualizarProdutoRequest, ProdutoDto>(sender)
{
    public override async Task<BaseResult<ProdutoDto>> Handle(AtualizarProdutoRequest request,
        CancellationToken cancellationToken)
    {
        BaseResult<ProdutoDto> produto = await sender.Send(new ObterPorIdRequest(request.Id), cancellationToken);
        if (produto.IsFailure)
        {
            return produto;
        }

        Produto? produtoMapeado = await produtoRepository.ObterPorIdComDependencias(request.Id, cancellationToken);
        produtoMapeado!.Atualizar(
            request.Descricao,
            request.DescricaoReduzida,
            request.Preco);

        await produtoRepository.Atualizar(produtoMapeado, cancellationToken);
        return await sender.Send(new ObterPorIdRequest(request.Id), cancellationToken);
    }
}