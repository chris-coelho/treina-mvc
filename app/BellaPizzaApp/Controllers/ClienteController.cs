using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using BellaPizzaApp.Models;
using System.Linq;

namespace BellaPizzaApp.Controllers
{
    public class ClienteController : Controller
    {
        private static ICollection<ClienteModel> _clientes;

        public ClienteController()
        {
            if (_clientes != null)
                return;

            _clientes = new List<ClienteModel>();

            _clientes.Add(new ClienteModel { Id = 1, Nome = "Joao do Teste", Telefone = "(16) 91234-4321", Bairro = "Centro", Cidade = "Araraquara", Uf = "SP" });
            _clientes.Add(new ClienteModel { Id = 2, Nome = "Maria Antonieta", Telefone = "(16) 91234-1234", Bairro = "Centro", Cidade = "Araraquara", Uf = "SP" });
            _clientes.Add(new ClienteModel { Id = 3, Nome = "Camila", Telefone = "(11) 91234-1111", Bairro = "Eloy Chaves", Cidade = "Jundiai", Uf = "SP" });
            _clientes.Add(new ClienteModel { Id = 4, Nome = "Lucas", Telefone = "(16) 91234-2222", Bairro = "Centro", Cidade = "Araraquara", Uf = "SP" });
            _clientes.Add(new ClienteModel { Id = 5, Nome = "Cristovao", Telefone = "(11) 91234-3333", Bairro = "Medeiros", Cidade = "Jundiai", Uf = "SP" });
        }

        [HttpGet]
        public IActionResult Index()
        {
            var lista = new List<ListaClienteViewModel>();

            foreach (var cliente in _clientes)
            {
                lista.Add(new ListaClienteViewModel
                {
                    Codigo = cliente.Id,
                    Nome = cliente.Nome,
                    Telefone = cliente.Telefone,
                    Bairro = cliente.Bairro,
                    Localidade = $"{cliente.Cidade}/{ cliente.Uf}"
                });
            }

            return View(lista);
        }

        [HttpGet]
        public IActionResult NovoCliente()
        {
            var novoCliente = new ClienteModel();
            return View(novoCliente);
        }

        [HttpPost]
        public IActionResult NovoCliente(ClienteModel clienteModel)
        {
            if (!ModelState.IsValid)
                return View();

            if (_clientes.FirstOrDefault(x => x.Id == clienteModel.Id) != null)
            {
                ModelState.AddModelError("Id", $"Id {clienteModel.Id} já existe");
                return View();
            }

            var palavras = clienteModel.Nome.Trim().Split(' ');
            if (palavras.Length <= 1)
            {
                ModelState.AddModelError("Nome", "Nome deve conter o sobrenome");
                return View();
            }

            _clientes.Add(clienteModel);

            return RedirectToAction("Index");
        }
    }
}
