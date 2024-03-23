using FluentValidation;
using VendaDireta.Aplication.Requests.Produto;

namespace VendaDireta.Aplication.Validators.Produto;

public class CriarProdutoValidator : AbstractValidator<CriarProdutoRequest>
{
    public CriarProdutoValidator()
    {
        RuleFor(x => x.Descricao)
            .NotEmpty()
            .WithMessage("Descrição obrigatoria!")
            .MinimumLength(2)
            .WithMessage("Tamanho minimo da descrição é de 2 caracteres!")
            .MaximumLength(250)
            .WithMessage("Tamanho maximo da descrição é de 250 caracteres!");
        
        RuleFor(x => x.DescricaoReduzida)
            .MaximumLength(100)
            .WithMessage("Tamanho maximo da descrição reduzida é de 100 caracteres!");

        RuleFor(x => x.Preco)
            .NotEqual(0)
            .WithMessage("Preço é obrigatorio!");

        RuleFor(x => x.EstoqueInicial)
            .GreaterThanOrEqualTo(0)
            .WithMessage("O valor do estoque inicial deve ser maior ou igual a zero.");
    }
}