using System.Collections.Generic;

using BellaPizzaApp.Models;

namespace BellaPizzaApp.Repositories
{
    public class ClienteRepository
    {
        private static ICollection<ClienteModel> _clientes;

        public ClienteRepository()
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

        public ICollection<ClienteModel> GetAll()
        {
            return _clientes;
        }

        public void Add(ClienteModel cliente)
        {
            _clientes.Add(cliente);
        }

    }
}
