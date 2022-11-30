using Curso.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace Curso.Data.Context;

public class CursoDbContext : DbContext
{
    public CursoDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; }

    protected override void OnModelCreating(ModelBuilder builder) 
    {
        builder.ApplyConfigurationsFromAssembly(typeof(CursoDbContext).Assembly);
        base.OnModelCreating(builder);
    }
}