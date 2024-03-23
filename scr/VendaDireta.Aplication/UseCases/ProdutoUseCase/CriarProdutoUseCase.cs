using FastResults.Results;
using Mapster;
using MediatR;
using VendaDireta.Aplication.Abstractions;
using VendaDireta.Aplication.Requests.Produto;
using VendaDireta.Domain.Contracts.Repositories;
using VendaDireta.Domain.Entities;

namespace VendaDireta.Aplication.UseCases.ProdutoUseCase;

public class CriarProdutoUseCase(
    ISender sender,
    IProdutoRepository produtoRepository)
    : BaseUseCase<CriarProdutoRequest, Guid>(sender)
{
    public override async Task<BaseResult<Guid>> Handle(
        CriarProdutoRequest request,
        CancellationToken cancellationToken)
    {
        Produto produto = request.Adapt<Produto>();
        produto.Criar(request.Preco, request.EstoqueInicial);

        Produto produtoCriado = await produtoRepository.Inserir(produto, cancellationToken);

        return produtoCriado.Id;
    }
}