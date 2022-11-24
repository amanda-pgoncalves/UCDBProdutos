using System;
using System.Threading.Tasks;
using UCDBProdutos.Business.Models;

namespace UCDBProdutos.Business.Interfaces
{
    public interface IPedidoService
    {
        Task Adicionar(Pedido pedido);

        Task Atualizar(Pedido pedido);
                
        Task Remover(Guid id);
    }
}
