using Curso.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Curso.Data.Mappings;

public class ProdutoMapping : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnType("binary(16)");
            
        builder.Property(p => p.FornecedorId)
            .HasColumnType("binary(16)");

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(p => p.Descricao)
            .IsRequired()
            .HasColumnType("varchar(1000)");

        builder.Property(p => p.Imagem)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.ToTable("Produtos");
    }
}