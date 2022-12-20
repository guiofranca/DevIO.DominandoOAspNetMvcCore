using AutoMapper;
using Curso.App.Controllers.Shared;
using Curso.App.ViewModels;
using Curso.Business.Interfaces;
using Curso.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Curso.App.Controllers;

[Controller]
public class FornecedorController : BaseController
{
    private readonly IFornecedorRepository _repositorioFornecedor;
    private readonly IEnderecoRepository _repositorioEndereco;
    private readonly IMapper _mapper;

    public FornecedorController(IFornecedorRepository repositorioFornecedor, IMapper mapper, IEnderecoRepository repositorioEndereco)
    {
        _repositorioFornecedor = repositorioFornecedor;
        _mapper = mapper;
        _repositorioEndereco = repositorioEndereco;
    }

    [HttpGet("/Fornecedor")]
    public async Task<IActionResult> Index() {
        var fornecedores = await ObterTodos();
        return View(fornecedores);
    }

    [HttpGet("/Fornecedor/Criar")]
    public IActionResult Criar() {
        return View();
    }

    [HttpPost("/Fornecedor/Criar")]
    public async Task<IActionResult> Criar(FornecedorViewModel fornecedorViewModel) {
        if(!ModelState.IsValid) return View(fornecedorViewModel);
        var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
        await _repositorioFornecedor.Adicionar(fornecedor);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("/Fornecedor/{id}/Detalhes")]
    public async Task<IActionResult> Detalhes(Guid id) {
        var fornecedorViewModel = await Obter(id);
        if(fornecedorViewModel is null) return NotFound();
        return View(fornecedorViewModel);
    }

    [HttpGet("/Fornecedor/{id}/Editar")]
    public async Task<IActionResult> Editar(Guid id) {
        var fornecedorViewModel = await Obter(id);
        if(fornecedorViewModel is null) return NotFound();
        return View(fornecedorViewModel);
    }

    [HttpPost("/Fornecedor/{id}/Editar")]
    public async Task<IActionResult> Editar(Guid id, FornecedorViewModel fornecedorViewModel) {
        if(!ModelState.IsValid) return View(fornecedorViewModel);
        var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
        await _repositorioFornecedor.Atualizar(fornecedor);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("/Fornecedor/{id}/Remover")]
    public async Task<IActionResult> Remover(Guid id) {
        var fornecedorViewModel = await Obter(id);
        if(fornecedorViewModel is null) return NotFound();
        return View(fornecedorViewModel);
    }

    [HttpPost("/Fornecedor/{id}/Remover")]
    public async Task<IActionResult> RemoverPost(Guid id) {
        await _repositorioFornecedor.Remover(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("/Fornecedor/Endereco/{id}/Editar")]
    public async Task<IActionResult> EditarEnderecoModal(Guid id) {
        var enderecoViewModel = await ObterEndereco(id);

        if(enderecoViewModel is null) return NotFound();

        return PartialView("_EditarEnderecoModal", enderecoViewModel);
    }

    [HttpPost("/Fornecedor/Endereco/{id}/Editar")]
    public async Task<IActionResult> EditarEnderecoModal(EnderecoViewModel enderecoViewModel) {
        if(!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(v => v.Errors));
        var endereco = _mapper.Map<Endereco>(enderecoViewModel);
        await _repositorioEndereco.Atualizar(endereco);
        return Ok(new {reload = true});
    }

    private async Task<IEnumerable<FornecedorViewModel>> ObterTodos() {
        return _mapper.Map<IEnumerable<FornecedorViewModel>>(await _repositorioFornecedor.ObterTodos());
    }

    private async Task<FornecedorViewModel> Obter(Guid id) {
        return _mapper.Map<FornecedorViewModel>(await _repositorioFornecedor.ObterComEndereco(id));
    }

    private async Task<EnderecoViewModel> ObterEndereco(Guid id) {
        return _mapper.Map<EnderecoViewModel>(await _repositorioEndereco.ObterPorId(id));
    }
}