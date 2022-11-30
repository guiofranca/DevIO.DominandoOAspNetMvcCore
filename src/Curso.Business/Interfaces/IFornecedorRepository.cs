using Curso.Business.Models;

namespace Curso.Business.Interfaces;

public interface IFornecedorRepository : IRepository<Fornecedor>
{
     Task<Fornecedor> ObterComEndereco(Guid id);
     Task<Fornecedor> ObterComProdutosEEndereco(Guid id);
}