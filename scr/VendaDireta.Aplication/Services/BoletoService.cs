using FastResults.Results;
using VendaDireta.Aplication.Contracts.Services;
using VendaDireta.Aplication.Dto.Pagamento;
using VendaDireta.Domain.Enums;

namespace VendaDireta.Aplication.Services;

public class BoletoService : IPagamentoService
{
    public BaseResult<PagamentoDto> Processar(CriarPagamentoDto pagamento)
    {
        return new PagamentoDto(
            TipoPagamento.Boleto);
    }
}