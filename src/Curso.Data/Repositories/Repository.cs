using System.Linq.Expressions;
using Curso.Business.Interfaces;
using Curso.Business.Models;
using Curso.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Curso.Data.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
{
    protected readonly CursoDbContext Db;
    protected readonly DbSet<TEntity> DbSet;

    protected Repository(CursoDbContext db)
    {
        Db = db;
        DbSet = db.Set<TEntity>();
    }

    public async Task Adicionar(TEntity entity)
    {
        entity.DataCadastro = DateTime.Now;
        entity.DataAtualizacao = DateTime.Now;
        DbSet.Add(entity);
        await SaveChanges();
    }

    public async Task Atualizar(TEntity entity)
    {
        entity.DataAtualizacao = DateTime.Now;
        DbSet.Update(entity);
        await SaveChanges();
    }

    public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate) => await DbSet.AsNoTracking()
            .Where(predicate)
            .ToListAsync();

    public async Task<TEntity> ObterPorId(Guid id) => await DbSet.FindAsync(id);

    public async Task<List<TEntity>> ObterTodos() => await DbSet.ToListAsync();

    public async Task Remover(Guid id)
    {
        DbSet.Remove(new TEntity{Id = id});
        await SaveChanges();
    }

    public async Task<int> SaveChanges() => await Db.SaveChangesAsync();

    public void Dispose()
    {
        Db?.Dispose();
    }
}