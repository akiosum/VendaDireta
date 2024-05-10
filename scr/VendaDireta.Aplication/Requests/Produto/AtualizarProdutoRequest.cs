using VendaDireta.Aplication.Abstractions.Contracts;
using VendaDireta.Aplication.Dto.Produto;

namespace VendaDireta.Aplication.Requests.Produto;

public record AtualizarProdutoRequest(
    Guid Id,
    string Descricao,
    string DescricaoReduzida,
    decimal Preco) : IRequestUseCase<ProdutoDto>;