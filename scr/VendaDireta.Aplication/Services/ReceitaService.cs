using FastResults.Results;
using VendaDireta.Aplication.Contracts.Patterns;
using VendaDireta.Aplication.Contracts.Services;
using VendaDireta.Aplication.Dto.Pagamento;
using VendaDireta.Aplication.Dto.Receita;
using VendaDireta.Domain.Enums;

namespace VendaDireta.Aplication.Services;

public class ReceitaService(IReceitaBuilder receitaBuilder) : IPagamentoService
{
    public BaseResult<PagamentoDto> Processar(CriarPagamentoDto pagamento)
    {
        CriarReceitaDto receita = new(
            pagamento.DataDeVencimento,
            pagamento.IntervaloDeDias,
            pagamento.Parcelas,
            pagamento.IdCliente ?? Guid.NewGuid(),
            string.Empty,
            pagamento.Valor);

        List<ReceitaDto> receitas = receitaBuilder
            .Iniciar(receita)
            .AdicionarDocumento()
            .AdicionarData()
            .AdicionarValores()
            .Buildar();

        return new PagamentoDto(
            TipoPagamento.Carne,
            receitas);
    }
}