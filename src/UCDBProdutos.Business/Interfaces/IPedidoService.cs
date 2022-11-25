using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UCDBProdutos.Business.Models;

namespace UCDBProdutos.Business.Interfaces
{
    public interface IPedidoService
    {
        Task<List<Pedido>>ObterTodos();

        Task Atualizar(Pedido pedido);

        Task Remover(Guid id);

        Task Adicionar(Pedido pedido);

        Task<Pedido> ObterPorId(Guid id);
    }
}
