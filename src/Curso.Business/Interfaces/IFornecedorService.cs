using Curso.Business.Models;

namespace Curso.Business.Interfaces;

public interface IFornecedorService : IDisposable {
    Task Adicionar(Fornecedor fornecedor);
    Task Atualizar(Fornecedor fornecedor);
    Task Remover(Guid id);
    Task AtualizarEndereco(Endereco endereco);
}