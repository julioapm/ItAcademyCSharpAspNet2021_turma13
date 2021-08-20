using System;
using System.Collections.Generic;

namespace DemoWsEF1.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public DateTime DataEmissao { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public ICollection<Produto> Produtos { get; set; }
        public List<PedidoProduto> PedidoProdutos { get; set; }
    }
}