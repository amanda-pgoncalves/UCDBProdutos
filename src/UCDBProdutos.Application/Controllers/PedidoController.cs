﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UCDBProdutos.Application.Models;
using UCDBProdutos.Business.Interfaces;

namespace UCDBProdutos.Application.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var pedidosBusiness = await _pedidoRepository.ObterTodos();

            List<Pedido> pedidos = new List<Pedido>();

            foreach (var pedidoBusiness in pedidosBusiness)
            {
                Pedido pedido = new Pedido { Id = pedidoBusiness.Id , 
                                            DataVencimento = pedidoBusiness.DataVencimento,
                                            NomeProduto = pedidoBusiness.NomeProduto, 
                                            Valor = pedidoBusiness.Valor};
                pedidos.Add(pedido);
            }
             
            return View(pedidos);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View(new Pedido());
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(Pedido pedido)
        {
            UCDBProdutos.Business.Models.Pedido pedidoBusiness = new Business.Models.Pedido
            {
                Id = pedido.Id,
                NomeProduto = pedido.NomeProduto,
                Valor = pedido.Valor,
                DataVencimento = pedido.DataVencimento
            };

            await _pedidoRepository.Adicionar(pedidoBusiness);

            return RedirectToAction("Index");
        }
    }
}
