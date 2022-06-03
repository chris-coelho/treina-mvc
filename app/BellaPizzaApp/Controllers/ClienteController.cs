﻿using Microsoft.AspNetCore.Mvc;

using BellaPizzaApp.Models;
using BellaPizzaApp.Services;

namespace BellaPizzaApp.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteService _service;

        public ClienteController()
        {
            _service = new ClienteService();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View( _service.ObterListaClientes() );
        }

        [HttpGet]
        public IActionResult NovoCliente()
        {
            return View( _service.ObterNovoCliente() );
        }

        [HttpPost]
        public IActionResult NovoCliente(NovoClienteViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View();

            var result = _service.AdicionarCliente(viewModel);
            if (!result.Success)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Field, error.Message);
                }

                return View();
            }

            return RedirectToAction("Index");
        }

        public IActionResult AlterarCliente(int id)
        {
            return View( _service.ObterClienteParaAlteracao(id) );
        }

        [HttpPost]
        public IActionResult AlterarCliente(AlterarClienteViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View();

            var result = _service.AlterarCliente(viewModel);
            if (!result.Success)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(error.Field, error.Message);
                }

                return View();
            }

            return RedirectToAction("Index");
        }
    }
}
