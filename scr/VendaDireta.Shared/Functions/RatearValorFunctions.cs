namespace VendaDireta.Shared.Functions;

public class RatearValorFunctions(decimal valor, int parcelas)
{
    #region Properties

    private decimal _valorParcela = Math.Round(valor / parcelas, 2, MidpointRounding.AwayFromZero);
    private decimal _valorRestante = valor;

    #endregion Properties

    public decimal RetornaValor()
    {
        if (parcelas > 1)
        {
            _valorRestante -= _valorParcela;
            parcelas -= 1;

            return _valorParcela;
        }

        if (parcelas is 0)
        {
            parcelas -= 1;

            return _valorRestante;
        }

        return _valorRestante;
    }
}