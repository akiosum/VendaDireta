using FastResults.Results;
using Mapster;
using MediatR;
using VendaDireta.Aplication.Abstractions;
using VendaDireta.Aplication.Dto.Produto;
using VendaDireta.Aplication.Requests.Estoque;
using VendaDireta.Aplication.Requests.Produto;
using VendaDireta.Domain.Contracts.Repositories;
using VendaDireta.Domain.Entities;
using VendaDireta.Shared.Messages;

namespace VendaDireta.Aplication.UseCases.EstoqueUseCase;

public class AtualizarEstoqueUseCase(
    ISender sender,
    IEstoqueRepository estoqueRepository) : BaseUseCase<AtualizarEstoqueRequest>(sender)
{
    public override async Task<BaseResult> Handle(AtualizarEstoqueRequest request, CancellationToken cancellationToken)
    {
        BaseResult<ProdutoDto> produto = await sender.Send(new ObterPorIdRequest(request.Id), cancellationToken);
        if (produto.IsFailure)
        {
            return BaseResult.Failure(produto.Error);
        }

        List<Estoque> estoques = await estoqueRepository.ObterTodosPorProduto(request.Id, cancellationToken);
        if (!estoques.Any())
        {
            return BaseResult.Failure(VendaMensagem.Comum.NenhumRegistroEncontrado);
        }

        estoques.ForEach(estoque => estoque.AjustarSaldo(request.Quantidade, request.Tipo));
        await estoqueRepository.AtualizarLote(estoques, cancellationToken);

        return BaseResult.Sucess();
    }
}