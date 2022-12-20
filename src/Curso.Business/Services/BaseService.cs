using Curso.Business.Interfaces;
using Curso.Business.Models;
using Curso.Business.Notificacoes;
using FluentValidation;
using FluentValidation.Results;

namespace Curso.Business.Services;

public abstract class BaseService
{
    private readonly INotificador _notificador;

    protected BaseService(INotificador notificador)
    {
        _notificador = notificador;
    }

    protected void Notificar(ValidationResult validationResult) {
        validationResult.Errors.ForEach(v => Notificar(v.ErrorMessage));
    }

    private void Notificar(string mensagem)
    {
        _notificador.Handle(new Notificacao(mensagem));
    }

    protected bool ExecutarValidacao<TV, TE>(TV tv, TE te) where TV : AbstractValidator<TE> where TE : Entity {
        var result = tv.Validate(te);
        if(result.IsValid is true) return true;

        Notificar(result);

        return false;
    }
}