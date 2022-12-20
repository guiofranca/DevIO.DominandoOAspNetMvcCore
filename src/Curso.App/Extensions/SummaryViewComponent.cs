namespace Curso.App.Extensions;

using Curso.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

public class SummaryViewComponent : ViewComponent {
    private readonly INotificador _notificador;

    public SummaryViewComponent(INotificador notificador)
    {
        _notificador = notificador;
    }

    public async Task<IViewComponentResult> InvokeAsync() {
        var notificacoes = await Task.FromResult(_notificador.ObterNotificacoes());

        notificacoes.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Mensagem));

        return View();
    }
}