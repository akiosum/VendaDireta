namespace VendaDireta.Aplication.Dto.Receita;

public record CriarReceitaDto(
    DateTime DataDeVencimento,
    int IntervaloDeDias,
    int Parcelas,
    Guid IdCliente,
    string Documento,
    decimal Valor);