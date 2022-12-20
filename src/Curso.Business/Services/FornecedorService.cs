using Curso.Business.Interfaces;
using Curso.Business.Models;
using Curso.Business.Models.Validators;

namespace Curso.Business.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository, IEnderecoRepository enderecoRepository, INotificador notificador) : base(notificador)
        {
            _fornecedorRepository = fornecedorRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task Adicionar(Fornecedor fornecedor)
        {
            var ehValido = ExecutarValidacao(new FornecedorValidator(), fornecedor) && ExecutarValidacao(new EnderecoValidator(), fornecedor.Endereco);
            if(ehValido) await _fornecedorRepository.Adicionar(fornecedor);
        }

        public async Task Atualizar(Fornecedor fornecedor)
        {
            var ehValido = ExecutarValidacao(new FornecedorValidator(), fornecedor);

            if(ehValido) await _fornecedorRepository.Atualizar(fornecedor);
        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
            var ehValido = ExecutarValidacao(new EnderecoValidator(), endereco);

            if(ehValido) await _enderecoRepository.Atualizar(endereco);
        }

        public async Task Remover(Guid id)
        {
            await _fornecedorRepository.Remover(id);
        }

        public void Dispose()
        {
            _enderecoRepository?.Dispose();
            _fornecedorRepository?.Dispose();
        }
    }
}