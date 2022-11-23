using System;

namespace UCDBProdutos.Business.Models
{
    public class Pedido
    {
        public Pedido()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public string NomeProduto { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataVencimento { get; set; }
    }
}
