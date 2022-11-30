using Curso.Business.Interfaces;
using Curso.Business.Models;
using Curso.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Curso.Data.Repositories;

public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
{
    public FornecedorRepository(CursoDbContext db) : base(db) { }

    public async Task<Fornecedor> ObterComEndereco(Guid id) => await Db.Fornecedores.AsNoTracking().Include(f => f.Endereco).FirstOrDefaultAsync(f => f.Id == id);

    public async Task<Fornecedor> ObterComProdutosEEndereco(Guid id) => await Db.Fornecedores.AsNoTracking()
            .Include(f => f.Endereco)
            .Include(f => f.Produtos)
            .FirstOrDefaultAsync(f => f.Id == id);
}