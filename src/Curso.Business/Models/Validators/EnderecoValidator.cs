using FluentValidation;

namespace Curso.Business.Models.Validators;

public class EnderecoValidator : AbstractValidator<Endereco>
{
    public EnderecoValidator()
    {
            RuleFor(e => e.Logradouro).NotEmpty().Length(2,200);
            RuleFor(e => e.Numero).NotEmpty().Length(2,50);
            RuleFor(e => e.Cep).NotEmpty().Length(8);
            RuleFor(e => e.Complemento).Length(2,255);
            RuleFor(e => e.Bairro).NotEmpty().Length(2,100);
            RuleFor(e => e.Cidade).NotEmpty().Length(2,100);
            RuleFor(e => e.Estado).NotEmpty().Length(2);
    }
}