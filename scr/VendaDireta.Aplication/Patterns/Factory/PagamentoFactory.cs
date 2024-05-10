using VendaDireta.Aplication.Contracts.Patterns;
using VendaDireta.Aplication.Contracts.Services;
using VendaDireta.Aplication.Services;
using VendaDireta.Domain.Enums;

namespace VendaDireta.Aplication.Patterns.Factory;

public class PagamentoFactory(
    ReceitaService receitaService,
    BoletoService boletoService) : IPagamentoFactory
{
    public IPagamentoService ObterPagamento(TipoPagamento tipoPagamento)
    {
        IPagamentoService pagamentoService;
        switch (tipoPagamento)
        {
            case TipoPagamento.Boleto:
                pagamentoService = boletoService;
                break;
            case TipoPagamento.Carne:
                pagamentoService = receitaService;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return pagamentoService;
    }
}