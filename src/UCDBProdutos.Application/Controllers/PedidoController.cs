using Microsoft.AspNetCore.Mvc;
using System;
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

                var dataVencimento = DateTime.Parse(pedidoBusiness.DataVencimento.ToShortDateString());

                var dataAtual = DateTime.Parse(DateTime.Now.ToShortDateString());

                if (dataVencimento == dataAtual || dataVencimento.AddDays(-1) == dataAtual || dataVencimento.AddDays(-2) == dataAtual)
                {
                    pedido.Cor = "gold";
                    pedido.Desconto = true;
                }

                else if (dataAtual < dataVencimento)
                {
                    pedido.Cor = "ForestGreen";
                    pedido.Desconto = true;
                }

                else
                {
                    pedido.Cor = "red";
                    pedido.Desconto = false;
                }

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

        [HttpGet]
        public async Task<IActionResult> Atualizar(Guid id)
        {
            var pedidoBusiness = await _pedidoRepository.ObterPorId(id);

            Pedido pedido = new Pedido
            {
                Id = pedidoBusiness.Id,
                DataVencimento = pedidoBusiness.DataVencimento,
                NomeProduto = pedidoBusiness.NomeProduto,
                Valor = pedidoBusiness.Valor
            };

            return View(pedido);
        }

        [HttpPost]
        public async Task<IActionResult> Atualizar(Pedido pedido)
        {
            UCDBProdutos.Business.Models.Pedido pedidoBusiness = new Business.Models.Pedido
            {
                Id = pedido.Id,
                NomeProduto = pedido.NomeProduto,
                Valor = pedido.Valor,
                DataVencimento = pedido.DataVencimento
            };

            await _pedidoRepository.Atualizar(pedidoBusiness);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Remover(Guid id)
        {
            await _pedidoRepository.Remover(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Desconto(Guid id)
        {
            var pedidoBusiness = await _pedidoRepository.ObterPorId(id);

            Pedido pedido = new Pedido
            {
                Id = pedidoBusiness.Id,
                DataVencimento = pedidoBusiness.DataVencimento,
                NomeProduto = pedidoBusiness.NomeProduto,
                Valor = pedidoBusiness.Valor
            };

            return View(pedido);
        }

        [HttpPost]
        public async Task<IActionResult> Desconto(Pedido pedido)
        {
            UCDBProdutos.Business.Models.Pedido pedidoBusiness = new Business.Models.Pedido
            {
                Id = pedido.Id,
                NomeProduto = pedido.NomeProduto,
                Valor = pedido.Valor - (pedido.Valor * 0.1m),
                DataVencimento = pedido.DataVencimento
            };

            await _pedidoRepository.Atualizar(pedidoBusiness);

            return RedirectToAction("Index");
        }
    }
}
