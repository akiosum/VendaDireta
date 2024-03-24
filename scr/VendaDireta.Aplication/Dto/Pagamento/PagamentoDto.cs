using VendaDireta.Aplication.Dto.Receita;
using VendaDireta.Domain.Enums;

namespace VendaDireta.Aplication.Dto.Pagamento;

public record PagamentoDto(
    TipoPagamento TipoPagamento,
    List<ReceitaDto>? Receitas = null);