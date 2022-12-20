using Curso.Business.Interfaces;
using Curso.Business.Models;
using Curso.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Curso.Data.Repositories;

public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
{
    public EnderecoRepository(CursoDbContext db) : base(db) { }
    
    public async Task<Endereco> ObterDoFornecedor(Guid fornecedorId) => await Db.Enderecos.AsNoTracking().FirstOrDefaultAsync(e => e.FornecedorId == fornecedorId);
}