using Curso.Business.Models;

namespace Curso.Business.Interfaces;

public interface IProdutoService : IDisposable {
    Task Adicionar(Produto produto);
    Task Atualizar(Produto produto);
    Task Remover(Guid id);
}