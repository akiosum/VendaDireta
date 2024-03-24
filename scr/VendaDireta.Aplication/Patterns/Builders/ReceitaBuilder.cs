using VendaDireta.Aplication.Contracts.Patterns;
using VendaDireta.Aplication.Dto.Receita;
using VendaDireta.Shared.Functions;

namespace VendaDireta.Aplication.Patterns.Builders;

public class ReceitaBuilder : IReceitaBuilder
{
    #region Properties

    private CriarReceitaDto _criarReceita;
    private readonly List<ReceitaDto> _receitas = new();

    #endregion Properties

    public ReceitaBuilder Iniciar(CriarReceitaDto criarReceita)
    {
        _criarReceita = criarReceita;

        for (int parcela = 1; parcela <= criarReceita.Parcelas; parcela++)
        {
            _receitas.Add(new ReceitaDto
            {
                Parcela = parcela,
                IdCliente = _criarReceita.IdCliente,
                Ativo = true
            });
        }

        return this;
    }

    public ReceitaBuilder AdicionarData()
    {
        DataParcelasFunctions functionsData =
            new DataParcelasFunctions(_criarReceita.DataDeVencimento, _criarReceita.IntervaloDeDias);
        foreach (ReceitaDto receita in _receitas)
        {
            receita.DataDeVencimento = functionsData.RetornaData();
        }

        return this;
    }

    public ReceitaBuilder AdicionarValores()
    {
        RatearValorFunctions functionsValor = new RatearValorFunctions(_criarReceita.Valor, _criarReceita.Parcelas);
        foreach (ReceitaDto receita in _receitas)
        {
            receita.Bruto = functionsValor.RetornaValor();
            receita.Saldo = receita.Bruto;
        }

        return this;
    }

    public ReceitaBuilder AdicionarDocumento()
    {
        foreach (ReceitaDto receita in _receitas)
        {
            string documento = string.IsNullOrWhiteSpace(_criarReceita.Documento)
                ? $"{_criarReceita.DataDeVencimento:ddMM}{receita.Parcela:000}"
                : $"{_criarReceita.Documento}-{receita.Parcela:000}";

            receita.Documento = documento;
        }

        return this;
    }

    public List<ReceitaDto> Buildar()
    {
        return _receitas;
    }
}