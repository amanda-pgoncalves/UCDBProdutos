using System;
using System.Threading.Tasks;
using UCDBProdutos.Business.Interfaces;
using UCDBProdutos.Business.Models;

namespace UCDBProdutos.Business.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }
        public async Task Adicionar(Pedido pedido)
        {
            await _pedidoRepository.Adicionar(pedido);
        }

        public async Task Atualizar(Pedido pedido)
        {
            await _pedidoRepository.Atualizar(pedido);
        }

        public async Task Remover(Guid id)
        {
            await _pedidoRepository.Remover(id);
        }
    }
}
