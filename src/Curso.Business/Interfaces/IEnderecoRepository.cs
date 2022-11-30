using Curso.Business.Models;

namespace Curso.Business.Interfaces;

public interface IEnderecoRepository : IRepository<Endereco>
{
     Task<Endereco> ObterDoFornecedor(Guid fornecedorId);
}