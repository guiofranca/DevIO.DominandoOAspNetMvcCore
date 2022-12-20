using Curso.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Curso.App.Controllers.Shared;

public class BaseController : Controller
{
    private readonly INotificador _notificador;

    public BaseController(INotificador notificador)
    {
        _notificador = notificador;
    }

    protected bool OperacaoInvalida() {
        return _notificador.TemNotificacao();
    }
}