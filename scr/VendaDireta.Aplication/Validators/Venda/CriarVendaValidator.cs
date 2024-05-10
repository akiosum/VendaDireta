using FluentValidation;
using VendaDireta.Aplication.Requests.Venda;
using VendaDireta.Domain.Enums;

namespace VendaDireta.Aplication.Validators.Venda;

public class CriarVendaValidator : AbstractValidator<CriarVendaRequest>
{
    public CriarVendaValidator()
    {
        RuleFor(v => v.Itens)
            .Must(itens => itens != null && itens.Any())
            .WithMessage("Insira produtos");

        RuleForEach(v => v.Itens)
            .SetValidator(_ => new CriarVendaItemValidator());

        RuleForEach(p => p.Pagamentos)
            .SetValidator(v => new CriarVendaPagamentoValidator(v.IdCliente));

        RuleFor(v => v.Pagamentos)
            .Must(pagamentos => pagamentos != null && pagamentos.Any())
            .WithMessage("Insira uma forma de pagamento");
    }
}

public class CriarVendaItemValidator : AbstractValidator<CriarItemRequest>
{
    public CriarVendaItemValidator()
    {
        RuleFor(i => i.Quantidade)
            .GreaterThanOrEqualTo(0)
            .WithMessage("A quantidade do item não pode ser menor que 0.");

        RuleFor(i => i.ValorUnitario)
            .GreaterThan(0)
            .WithMessage("O valor do item deve ser maior que zero.");
    }
}

public class CriarVendaPagamentoValidator() : AbstractValidator<CriarPagamentoRequest>
{
    public CriarVendaPagamentoValidator(Guid? cliente) : this()
    {
        RuleFor(p => p.ValorPago)
            .GreaterThan(0)
            .WithMessage("O valor deve ser maior que zero.");

        When(p => p.TipoPagamento == TipoPagamento.Carne && cliente == null,
            () => RuleFor(_ => cliente)
                .NotNull()
                .WithMessage("O cliente não pode ser nulo para vendas do tipo carne."));
    }
}