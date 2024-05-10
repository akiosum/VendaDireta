using VendaDireta.Aplication.Abstractions.Contracts;
using VendaDireta.Domain.Enums;

namespace VendaDireta.Aplication.Requests.Venda;

public record CriarVendaRequest(
    Guid? IdCliente,
    List<CriarItemRequest> Itens,
    List<CriarPagamentoRequest> Pagamentos) : IRequestUseCase;

public record CriarItemRequest(
    Guid IdProduto,
    decimal Quantidade,
    decimal ValorUnitario);

public record CriarPagamentoRequest(
    TipoPagamento TipoPagamento,
    decimal ValorPago,
    int Parcelas = 1);