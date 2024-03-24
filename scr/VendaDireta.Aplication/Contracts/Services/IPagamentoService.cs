using FastResults.Results;
using VendaDireta.Aplication.Abstractions.Contracts;
using VendaDireta.Aplication.Dto.Pagamento;

namespace VendaDireta.Aplication.Contracts.Services;

public interface IPagamentoService : IService
{
    BaseResult<PagamentoDto> Processar(CriarPagamentoDto pagamento);
}