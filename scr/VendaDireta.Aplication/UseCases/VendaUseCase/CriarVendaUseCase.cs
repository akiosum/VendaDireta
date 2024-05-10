using FastResults.Results;
using Mapster;
using MediatR;
using VendaDireta.Aplication.Abstractions;
using VendaDireta.Aplication.Contracts.Patterns;
using VendaDireta.Aplication.Contracts.Services;
using VendaDireta.Aplication.Dto.Pagamento;
using VendaDireta.Aplication.Requests.Venda;
using VendaDireta.Domain.Contracts.Repositories;
using VendaDireta.Domain.Entities;

namespace VendaDireta.Aplication.UseCases.VendaUseCase;

public class CriarVendaUseCase(
    ISender sender,
    IPagamentoFactory pagamentoFactory,
    IVendaRepository vendaRepository,
    IUnitOfWork unitOfWork)
    : BaseUseCase<CriarVendaRequest>(sender)
{
    public override async Task<BaseResult> Handle(
        CriarVendaRequest request,
        CancellationToken cancellationToken)
    {
        Venda venda = Criar(request);

        vendaRepository.InserirSemSave(venda);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return BaseResult.Sucess();
    }

    private Venda Criar(CriarVendaRequest request)
    {
        Venda venda = request.Adapt<Venda>();
        List<VendaItem> itens = request.Itens.Adapt<List<VendaItem>>();
        List<VendaPagamento> pagamentos = request.Pagamentos.Adapt<List<VendaPagamento>>();
        venda.Criar(itens, pagamentos);

        return venda;
    }

    private BaseResult<List<PagamentoDto>> ProcessarPagamento(CriarVendaRequest request)
    {
        List<PagamentoDto> pagamentos = [];
        foreach (CriarPagamentoRequest pagamento in request.Pagamentos)
        {
            IPagamentoService pagamentoService = pagamentoFactory.ObterPagamento(pagamento.TipoPagamento);
            CriarPagamentoDto pagamentoDto = new(
                pagamento.TipoPagamento,
                pagamento.ValorPago,
                DateTime.Now,
                request.IdCliente,
                pagamento.Parcelas);

            BaseResult<PagamentoDto> pagamentoCriado = pagamentoService.Processar(pagamentoDto);
            if (pagamentoCriado.IsFailure)
            {
                return BaseResult.Failure<List<PagamentoDto>>(pagamentoCriado.Error);
            }

            pagamentos.Add(pagamentoCriado.Value);
        }

        return pagamentos;
    }
}