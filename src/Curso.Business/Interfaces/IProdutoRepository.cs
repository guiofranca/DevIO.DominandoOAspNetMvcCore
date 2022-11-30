using Curso.Business.Models;

namespace Curso.Business.Interfaces;

public interface IProdutoRepository : IRepository<Produto>
{
     Task<IEnumerable<Produto>> ObterTodosDoFornecedor(Guid fornecedorId);
     Task<IEnumerable<Produto>> ObterTodosComFornecedor();
     Task<Produto> ObterComFornecedor(Guid id);
}