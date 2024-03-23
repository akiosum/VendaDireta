using VendaDireta.Aplication.Abstractions.Contracts;
using VendaDireta.Aplication.Dto.Produto;

namespace VendaDireta.Aplication.Requests.Produto;

public record CriarProdutoRequest(
    string Descricao,
    string DescricaoReduzida,
    decimal Preco,
    decimal Custo,
    decimal EstoqueInicial) : IRequestUseCase<CriarProdutoDto>;