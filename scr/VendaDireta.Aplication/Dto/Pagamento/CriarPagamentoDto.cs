using VendaDireta.Domain.Enums;

namespace VendaDireta.Aplication.Dto.Pagamento;

public record CriarPagamentoDto(
    TipoPagamento TipoPagamento,
    decimal Valor,
    DateTime DataDeVencimento,
    Guid? IdCliente,
    int Parcelas,
    int IntervaloDeDias = 30);