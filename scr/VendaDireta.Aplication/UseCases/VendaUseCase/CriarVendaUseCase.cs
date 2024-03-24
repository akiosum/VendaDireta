using FastResults.Results;
using MediatR;
using VendaDireta.Aplication.Abstractions;
using VendaDireta.Aplication.Contracts.Patterns;
using VendaDireta.Aplication.Contracts.Services;
using VendaDireta.Aplication.Dto.Pagamento;
using VendaDireta.Aplication.Requests.Venda;

namespace VendaDireta.Aplication.UseCases.VendaUseCase;

public class CriarVendaUseCase(
    ISender sender,
    IPagamentoFactory pagamentoFactory)
    : BaseUseCase<CriarVendaRequest>(sender)
{
    public override async Task<BaseResult> Handle(
        CriarVendaRequest request,
        CancellationToken cancellationToken)
    {
        ProcessarPagamento(request);

        return BaseResult.Sucess();
    }

    private void ProcessarPagamento(CriarVendaRequest request)
    {
        foreach (CriarPagamentoRequest pagamento in request.Pagamentos)
        {
            IPagamentoService pagamentoService = pagamentoFactory.ObterPagamento(pagamento.TipoPagamento);
            CriarPagamentoDto pagamentoDto = new(
                pagamento.TipoPagamento,
                pagamento.Valor,
                DateTime.Now,
                request.IdCliente,
                pagamento.Parcelas);

            BaseResult<PagamentoDto> pagamentoCriado = pagamentoService.Processar(pagamentoDto);
        }
    }
}