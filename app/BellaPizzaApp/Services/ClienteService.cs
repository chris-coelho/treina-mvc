using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

        public NovoClienteViewModel ObterNovoCliente()
        {
            return new NovoClienteViewModel();
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
            var result = new ClienteValidationResult { Errors = new List<ValidationError>() };

            if (_repository.GetAll().FirstOrDefault(x => x.Id == viewModel.Codigo) != null)
                result.Errors.Add(new ValidationError { Field = "Codigo", Message = $"Código { viewModel.Codigo } já existe" });

            if (!NomeContemSobrenome(viewModel.Nome))
                result.Errors.Add(new ValidationError { Field = "Nome", Message = "Nome deve conter o sobrenome"});

            result.Success = result.Errors.Count == 0;
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

        public AlterarClienteViewModel ObterClienteParaAlteracao(int id)
        {
            var cliente = _repository.GetById( id );
            if (cliente == null)
                return null;

            return new AlterarClienteViewModel
            {
                Codigo = cliente.Id,
                Nome = cliente.Nome,
                Telefone = cliente.Telefone,
                Bairro = cliente.Bairro,
                Cidade = cliente.Cidade,
                Uf = cliente.Uf
            };
        }

        public ClienteValidationResult AlterarCliente(AlterarClienteViewModel viewModel)
        {
            var result = new ClienteValidationResult() { Errors = new List<ValidationError>() };

            if (! NomeContemSobrenome(viewModel.Nome))
                result.Errors.Add(new ValidationError { Field = "Nome", Message = "Nome deve conter o sobrenome" });

            if (!TelefoneValido(viewModel.Telefone))
                result.Errors.Add(new ValidationError { Field = "Telefone", Message = "Telefone inválido. Formato: (11) 00000-0000" });

            result.Success = result.Errors.Count == 0;
            if (!result.Success)
                return result;

            _repository.Update(new ClienteModel()
            {
                Id = viewModel.Codigo,
                Nome = viewModel.Nome,
                Telefone = viewModel.Telefone,
                Bairro = viewModel.Bairro,
                Cidade = viewModel.Cidade,
                Uf = viewModel.Uf
            });

            return result;
        }

        private bool NomeContemSobrenome(string nome)
        {
            var palavras = nome.Trim().Split(' ');

            return palavras.Length > 1;
        }

        private bool TelefoneValido(string telefone)
        {
            return Regex.Match(telefone, @"^\([0-9]{2}\) [0-9]?[0-9]{4,5}-[0-9]{4}$").Success;
        }
    }
}
