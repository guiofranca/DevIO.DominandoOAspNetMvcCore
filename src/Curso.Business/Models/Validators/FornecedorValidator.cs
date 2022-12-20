using FluentValidation;

namespace Curso.Business.Models.Validators;

public class FornecedorValidator : AbstractValidator<Fornecedor>
{
    public FornecedorValidator()
    {
        RuleFor(f => f.Nome)
            .NotEmpty()
            .Length(3, 100);
        
        When(f => f.TipoFornecedor == TipoFornecedor.PessoaFisica, () => {
            RuleFor(f => f.Documento)
                .Length(11,15);
        });

        When(f => f.TipoFornecedor == TipoFornecedor.PessoaJuridica, () => {
            RuleFor(f => f.Documento)
                .Length(14,18);
        });
    }
}