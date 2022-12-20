using AutoMapper;
using Curso.App.Controllers.Shared;
using Curso.App.ViewModels;
using Curso.Business.Interfaces;
using Curso.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Curso.App.Controllers;

[Controller]
public class ProdutoController : BaseController
{
    private readonly IProdutoRepository _repositorioProduto;
    private readonly IFornecedorRepository _repositorioFornecedor;
    private readonly IMapper _mapper;

    public ProdutoController(IProdutoRepository repositorioProduto, 
        IFornecedorRepository repositorioFornecedor,
        IMapper mapper)
    {
        _repositorioProduto = repositorioProduto;
        _repositorioFornecedor = repositorioFornecedor;
        _mapper = mapper;
    }

    [HttpGet("/Produto")]
    public async Task<IActionResult> Index() {
        var produtos = await ObterTodos();
        return View(produtos);
    }

    [HttpGet("/Produto/Criar")]
    public async Task<IActionResult> Criar() {
        var produtoViewModel = await PopularFornecedores(new ProdutoViewModel());
        return View(produtoViewModel);
    }

    [HttpPost("/Produto/Criar")]
    public async Task<IActionResult> Criar(ProdutoViewModel produtoViewModel) {
        if(!ModelState.IsValid) {
            await PopularFornecedores(produtoViewModel);
            return View(produtoViewModel);
        }

        produtoViewModel.Imagem = $"{Guid.NewGuid()}_{produtoViewModel.ImagemUpload.FileName}";
        if(!await UploadArquivo(produtoViewModel.ImagemUpload, produtoViewModel.Imagem)) {
            return View(produtoViewModel);
        }

        var produto = _mapper.Map<Produto>(produtoViewModel);
        await _repositorioProduto.Adicionar(produto);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("/Produto/{id}/Detalhes")]
    public async Task<IActionResult> Detalhes(Guid id) {
        var produtoViewModel = await Obter(id);
        if(produtoViewModel is null) return NotFound();
        return View(produtoViewModel);
    }

    [HttpGet("/Produto/{id}/Editar")]
    public async Task<IActionResult> Editar(Guid id) {
        var produtoViewModel = await Obter(id);
        if(produtoViewModel is null) return NotFound();
        await PopularFornecedores(produtoViewModel);
        return View(produtoViewModel);
    }

    [HttpPost("/Produto/{id}/Editar")]
    public async Task<IActionResult> Editar(Guid id, ProdutoViewModel produtoViewModel) {
        if(!ModelState.IsValid) {
            await PopularFornecedores(produtoViewModel);
            return View(produtoViewModel);
        }

        if(produtoViewModel.ImagemUpload is not null) {
            produtoViewModel.Imagem = $"{Guid.NewGuid()}_{produtoViewModel.ImagemUpload.FileName}";
            if(!await UploadArquivo(produtoViewModel.ImagemUpload, produtoViewModel.Imagem)) {
                return View(produtoViewModel);
            }
        }

        var produto = _mapper.Map<Produto>(produtoViewModel);
        if(produto.Imagem == null) {
            var produtoOriginal = await _repositorioProduto.ObterPorId(produto.Id);
            produto.Imagem = produtoOriginal.Imagem;
        }

        await _repositorioProduto.Atualizar(produto);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("/Produto/{id}/Remover")]
    public async Task<IActionResult> Remover(Guid id) {
        var produtoViewModel = await Obter(id);
        if(produtoViewModel is null) return NotFound();
        return View(produtoViewModel);
    }

    [HttpPost("/Produto/{id}/Remover")]
    public async Task<IActionResult> RemoverPost(Guid id) {
        await _repositorioProduto.Remover(id);
        return RedirectToAction(nameof(Index));
    }

    private async Task<IEnumerable<ProdutoViewModel>> ObterTodos() {
        return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _repositorioProduto.ObterTodos());
    }

    private async Task<ProdutoViewModel> Obter(Guid id) {
        return _mapper.Map<ProdutoViewModel>(await _repositorioProduto.ObterComFornecedor(id));
    }

    private async Task<ProdutoViewModel> PopularFornecedores(ProdutoViewModel produtoViewModel) {
        produtoViewModel.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _repositorioFornecedor.ObterTodos());
        return produtoViewModel;
    }

    private async Task<bool> UploadArquivo(IFormFile arquivo, string nome) {
        if(arquivo.Length <= 0) return false;

        Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens"));

        var caminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", nome);

        if(System.IO.File.Exists(caminho)) {
            ModelState.AddModelError(string.Empty, "Faça upload novamente da imagem");
            return false;
        }

        using(var stream = new FileStream(caminho, FileMode.Create)) {
            await arquivo.CopyToAsync(stream);
        }

        return true;
    }
}