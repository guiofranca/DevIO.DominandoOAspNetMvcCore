using Curso.Business.Interfaces;
using Curso.Business.Models;
using Curso.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Curso.Data.Repositories;

public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{
    public ProdutoRepository(CursoDbContext db) : base(db) { }
    
    public async Task<Produto> ObterComFornecedor(Guid id) => await Db.Produtos.AsNoTracking().Include(p => p.Fornecedor).FirstOrDefaultAsync(p => p.Id == id);

    public async Task<IEnumerable<Produto>> ObterTodosComFornecedor() => await Db.Produtos.AsNoTracking().Include(p => p.Fornecedor).ToListAsync();

    public async Task<IEnumerable<Produto>> ObterTodosDoFornecedor(Guid fornecedorId)
    {
        throw new NotImplementedException();
    }
}