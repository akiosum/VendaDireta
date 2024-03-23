using VendaDireta.Aplication.Abstractions.Contracts;
using VendaDireta.Aplication.Dto.Produto;

namespace VendaDireta.Aplication.Requests.Produto;

public record ObterTodosRequest() : IRequestUseCase<List<ProdutoDto>>;