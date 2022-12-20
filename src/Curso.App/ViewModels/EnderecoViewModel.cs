using System.ComponentModel.DataAnnotations;
using Curso.Business.Models;

namespace Curso.App.ViewModels;

public class EnderecoViewModel
{
    public Guid Id { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Cep { get; set; }
    public string? Complemento { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    [StringLength(2)]
    public string Estado { get; set; }
    public FornecedorViewModel? Fornecedor { get; set; }
    public Guid? FornecedorId { get; set; }
}