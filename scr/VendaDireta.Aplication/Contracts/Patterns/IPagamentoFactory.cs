using VendaDireta.Aplication.Abstractions.Contracts;
using VendaDireta.Aplication.Contracts.Services;
using VendaDireta.Domain.Enums;

namespace VendaDireta.Aplication.Contracts.Patterns;

public interface IPagamentoFactory : IPatterns
{
    IPagamentoService ObterPagamento(TipoPagamento tipoPagamento);
}