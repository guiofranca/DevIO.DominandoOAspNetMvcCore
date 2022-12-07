using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Curso.Business.Models;

namespace Curso.App.ViewModels;

public class FornecedorViewModel
{
    public Guid Id { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public string Nome { get; set; }
    public string Documento { get; set; }

    [DisplayName("Tipo de Fornecedor")]
    public int TipoFornecedor { get; set; }
    public EnderecoViewModel? Endereco { get; set; }
    public bool Ativo { get; set; }
    public IEnumerable<ProdutoViewModel>? Produtos { get; set; }
}