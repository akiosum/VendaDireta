namespace VendaDireta.Aplication.Dto.Receita;

public record CriarReceitaDto(
    DateTime DataDeVencimento,
    int IntervaloDeDias,
    int Parcelas,
    string Documento,
    decimal Valor);