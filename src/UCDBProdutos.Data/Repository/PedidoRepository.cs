using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCDBProdutos.Business.Interfaces;
using UCDBProdutos.Business.Models;
using UCDBProdutos.Data.Context;

namespace UCDBProdutos.Data.Repository
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(MyDbContext context) : base(context) { }
    
    }
}
