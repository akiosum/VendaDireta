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

public class ObterTodosUseCase(
    ISender sender,
    IProdutoRepository produtoRepository)
    : BaseUseCase<ObterTodosRequest, List<ProdutoDto>>(sender)
{
    public override async Task<BaseResult<List<ProdutoDto>>> Handle(
        ObterTodosRequest request,
        CancellationToken cancellationToken)
    {
        List<Produto> produtos = await produtoRepository.ObterTodosProdutos(cancellationToken);
        if (!produtos.Any())
        {
            return BaseResult.Failure<List<ProdutoDto>>(VendaMensagem.Comum.NenhumRegistroEncontrado);
        }

        return produtos.Adapt<List<ProdutoDto>>();
    }
}