using System.Collections.Generic;
using System.Linq;
using BellaPizzaApp.Models;
using BellaPizzaApp.Repositories;

namespace BellaPizzaApp.Services
{
    public class ClienteService
    {
        private readonly ClienteRepository _repository;

        public ClienteService()
        {
            _repository = new ClienteRepository();
        }

        public ICollection<ClienteViewModel> ObterListaClientes()
        {
            var lista = new List<ClienteViewModel>();
            var clientes = _repository.GetAll();

            foreach (var cliente in clientes)
            {
                lista.Add(new ClienteViewModel
                {
                    Codigo = cliente.Id,
                    Nome = cliente.Nome,
                    Telefone = cliente.Telefone,
                    Bairro = cliente.Bairro,
                    Localidade = $"{cliente.Cidade}/{ cliente.Uf}"
                });
            }

            return lista;
        }

        public ClienteValidationResult AdicionarCliente(NovoClienteViewModel viewModel)
        {
            var result = new ClienteValidationResult
            {
                Success = true,
                Errors = new List<ValidationError>()
            };

            var clientes = _repository.GetAll();

            if (clientes.FirstOrDefault(x => x.Id == viewModel.Codigo) != null)
            {
                result.Errors.Add(new ValidationError { 
                    Field = "Codigo", 
                    Message = $"Código { viewModel.Codigo } já existe" }
                );
                result.Success = false;
            }

            var palavras = viewModel.Nome.Trim().Split(' ');
            if (palavras.Length <= 1)
            {
                result.Errors.Add(new ValidationError
                {
                    Field = "Nome",
                    Message = "Nome deve conter o sobrenome"
                });
                result.Success = false;
            }

            if (result.Success)
            {
                _repository.Add(new ClienteModel
                {
                    Id = viewModel.Codigo,
                    Nome = viewModel.Nome,
                    Bairro = viewModel.Bairro,
                    Cidade = viewModel.Cidade,
                    Uf = viewModel.Uf
                });
            }

            return result;
        }
    }
}
