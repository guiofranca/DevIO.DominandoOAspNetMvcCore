using Curso.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Curso.Data.Mappings;

public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnType("binary(16)");

        builder.Property(p => p.FornecedorId)
            .HasColumnType("binary(16)");

        builder.Property(p => p.Logradouro)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(p => p.Numero)
            .IsRequired()
            .HasColumnType("varchar(50)");

        builder.Property(p => p.Cep)
            .IsRequired()
            .HasColumnType("varchar(8)");

        builder.Property(p => p.Complemento)
            .HasColumnType("varchar(255)");

        builder.Property(p => p.Bairro)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder.Property(p => p.Cidade)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder.Property(p => p.Estado)
            .IsRequired()
            .HasColumnType("varchar(2)");

        builder.ToTable("Enderecos");
    }
}