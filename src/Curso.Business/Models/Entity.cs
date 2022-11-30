namespace Curso.Business.Models;

public abstract class Entity
{
    public Guid Id { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime DataAtualizacao { get; set; }

    public Entity()
    {
        Id = Guid.NewGuid();
        DataCadastro = DateTime.Now;
        DataAtualizacao = DateTime.Now;
    }
}