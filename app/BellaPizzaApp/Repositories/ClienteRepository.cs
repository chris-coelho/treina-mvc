﻿using System.Collections.Generic;
using System.Linq;

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

        public ClienteModel GetById(int id)
        {
            /* Usando foreach
            ClienteModel clienteExistente = null;

            foreach (var cliente in _clientes)
            {
                if (cliente.Id == id)
                {
                    clienteExistente = cliente;
                }
            }

            return clienteExistente;
            */

            // Usando LINQ
            return _clientes.FirstOrDefault( x => x.Id == id );
        }

        public ICollection<ClienteModel> GetAll()
        {
            return _clientes;
        }

        public void Add(ClienteModel cliente)
        {
            _clientes.Add(cliente);
        }

        public void Update(ClienteModel cliente)
        {
            var clienteExistente = _clientes.FirstOrDefault(x => x.Id == cliente.Id);
            
            if (clienteExistente != null)
            {
                clienteExistente.Nome = cliente.Nome;
                clienteExistente.Telefone = cliente.Telefone;
                clienteExistente.Bairro = cliente.Bairro;
                clienteExistente.Cidade = cliente.Cidade;
                clienteExistente.Uf = cliente.Uf;
            }
        }

    }
}
