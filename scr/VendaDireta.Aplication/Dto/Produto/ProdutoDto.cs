using VendaDireta.Aplication.Dto.Estoque;

namespace VendaDireta.Aplication.Dto.Produto;

public record ProdutoDto(
    Guid Id,
    string Descricao,
    string DescricaoReduzida,
    List<ProdutoPrecoDto> ProdutoPreco,
    List<EstoqueDto> Estoque);