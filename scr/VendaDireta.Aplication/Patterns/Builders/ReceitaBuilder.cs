using VendaDireta.Aplication.Dto.Receita;
using VendaDireta.Domain.Entities;
using VendaDireta.Shared.Functions;

namespace VendaDireta.Aplication.Patterns.Builders;

public class ReceitaBuilder(CriarReceitaDto criarReceita)
{
    #region Properties

    private readonly List<Receita> _receitas = new();

    #endregion Properties

    public ReceitaBuilder Iniciar()
    {
        for (int parcela = 1; parcela <= criarReceita.Parcelas; parcela++)
        {
            _receitas.Add(new Receita
            {
                Parcela = parcela,
                Ativo = true
            });
        }

        return this;
    }

    public ReceitaBuilder AdicionarData()
    {
        DataParcelasFunctions functionsData =
            new DataParcelasFunctions(criarReceita.DataDeVencimento, criarReceita.IntervaloDeDias);
        foreach (Receita receita in _receitas)
        {
            receita.DataDeVencimento = functionsData.RetornaData();
        }

        return this;
    }

    public ReceitaBuilder AdicionarValores()
    {
        RatearValorFunctions functionsValor = new RatearValorFunctions(criarReceita.Valor, criarReceita.Parcelas);
        foreach (Receita receita in _receitas)
        {
            receita.Bruto = functionsValor.RetornaValor();
            receita.Saldo = receita.Bruto;
        }

        return this;
    }

    public ReceitaBuilder AdicionarDocumento()
    {
        foreach (Receita receita in _receitas)
        {
            string documento = string.IsNullOrWhiteSpace(criarReceita.Documento)
                ? $"{criarReceita.DataDeVencimento:ddMM}{receita.Parcela:000}"
                : $"{criarReceita.Documento}{receita.Parcela:000}";

            receita.Documento = documento;
        }

        return this;
    }

    public List<Receita> Buildar()
    {
        return _receitas;
    }
}