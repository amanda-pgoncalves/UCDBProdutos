using System;

namespace UCDBProdutos.Application.Models
{
    public class Pedido 
    {
        public Guid Id { get; set; }

        public string NomeProduto { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataVencimento { get; set; }
    }
}
