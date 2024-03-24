namespace VendaDireta.Shared.Functions;

public class DataParcelasFunctions(
    DateTime dataInicial,
    int intervaloDeDias,
    bool primeiraParcela = true)
{
    public DateTime RetornaData()
    {
        if (primeiraParcela)
        {
            primeiraParcela = false;

            return dataInicial;
        }

        dataInicial = dataInicial.AddDays(intervaloDeDias);
        return dataInicial;
    }
}