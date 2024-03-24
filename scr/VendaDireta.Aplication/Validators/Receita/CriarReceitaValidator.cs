using FluentValidation;
using VendaDireta.Aplication.Requests.Receita;

namespace VendaDireta.Aplication.Validators.Receita;

public class CriarReceitaValidator : AbstractValidator<CriarReceitaRequest>
{
    public CriarReceitaValidator()
    {
        RuleFor(r => r.DataDeVencimento)
            .GreaterThan(DateTime.Now.Date)
            .WithMessage("A data de vencimento não pode ser menor que a data atual!");

        RuleFor(r => r.Parcelas)
            .GreaterThanOrEqualTo(1)
            .WithMessage("A parcela não pode ser menor que 1");

        RuleFor(r => r.Valor)
            .GreaterThan(0)
            .WithMessage("O valor da receita deve ser maior que zero.");
    }
}