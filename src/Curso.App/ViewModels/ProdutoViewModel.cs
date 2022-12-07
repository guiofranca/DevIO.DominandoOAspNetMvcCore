using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Curso.App.ViewModels;

public class ProdutoViewModel
{
    public Guid Id { get; set; }

    public DateTime DataCadastro { get; set; }


    [DisplayName("Última atualização")]
    public DateTime DataAtualizacao { get; set; }

    public string Nome { get; set; }

    [DisplayName("Descrição")]
    public string Descricao { get; set; }

    public decimal Valor { get; set; }

    [DisplayName("Imagem do Produto")]
    public IFormFile? ImagemUpload { get; set; }

    public string? Imagem { get; set; }

    public FornecedorViewModel? Fornecedor { get; set; }

    public IEnumerable<FornecedorViewModel>? Fornecedores { get; set; }

    [DisplayName("Fornecedor")]
    public Guid FornecedorId { get; set; }
}