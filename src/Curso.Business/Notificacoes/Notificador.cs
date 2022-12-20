using Curso.Business.Interfaces;

namespace Curso.Business.Notificacoes;

public class Notificador : INotificador
{
    private List<Notificacao> _notificacoes = new();
    
    public void Handle(Notificacao notificacao)
    {
        _notificacoes.Add(notificacao);
    }

    public List<Notificacao> ObterNotificacoes()
    {
        return _notificacoes;
    }

    public bool TemNotificacao()
    {
        return _notificacoes.Any();
    }
}