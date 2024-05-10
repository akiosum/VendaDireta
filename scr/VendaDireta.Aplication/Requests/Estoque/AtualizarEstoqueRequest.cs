using VendaDireta.Aplication.Abstractions.Contracts;
using VendaDireta.Domain.Enums;

namespace VendaDireta.Aplication.Requests.Estoque;

public record AtualizarEstoqueRequest(
    Guid Id,
    decimal Quantidade,
    TipoEstoque Tipo) : IRequestUseCase;