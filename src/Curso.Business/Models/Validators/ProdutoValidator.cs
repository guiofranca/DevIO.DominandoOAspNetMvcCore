using FluentValidation;

namespace Curso.Business.Models.Validators;

public class ProdutoValidator : AbstractValidator<Produto>
{
    public ProdutoValidator()
    {
        RuleFor(f => f.Nome)
            .NotEmpty()
            .Length(3, 200);
        
        RuleFor(f => f.Descricao)
            .NotEmpty()
            .Length(3, 1000);
        
        RuleFor(f => f.Valor)
            .NotEmpty()
            .GreaterThan(0);
    }
}