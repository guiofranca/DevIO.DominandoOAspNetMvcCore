namespace Curso.Business.Models;

public class Produto : Entity
{
    public Produto() : base() { }
    public Guid FornecedorId { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Valor { get; set; }
    public string Imagem { get; set; }
    public Fornecedor Fornecedor { get; set; }
}