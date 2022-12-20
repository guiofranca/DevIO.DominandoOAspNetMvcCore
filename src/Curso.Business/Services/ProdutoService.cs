using Curso.Business.Interfaces;
using Curso.Business.Models;
using Curso.Business.Models.Validators;

namespace Curso.Business.Services;

public class ProdutoService : BaseService, IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository, INotificador notificador) : base(notificador)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task Adicionar(Produto produto)
    {
        var ehValido = ExecutarValidacao(new ProdutoValidator(), produto);
        if(ehValido) await _produtoRepository.Adicionar(produto);
    }

    public async Task Atualizar(Produto produto)
    {
        var ehValido = ExecutarValidacao(new ProdutoValidator(), produto);
        if(ehValido) await _produtoRepository.Atualizar(produto);
    }

    public async Task Remover(Guid id)
    {
        await _produtoRepository.Remover(id);
    }

    public void Dispose() {
        _produtoRepository?.Dispose();
    }
}