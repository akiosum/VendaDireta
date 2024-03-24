using VendaDireta.Aplication.Abstractions.Contracts;

namespace VendaDireta.Aplication.Requests.Receita;

public record CriarReceitaRequest(
    DateTime DataDeVencimento,
    int IntervaloDeDias,
    int Parcelas,
    string Documento,
    decimal Valor) : IRequestUseCase;