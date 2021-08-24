using System;
using System.Collections.Generic;
using DemoWsEF1.Models;
using System.Linq;

namespace DemoWsEF1.Dtos
{
    public class PedidoDTO
    {
        public int Codigo { get; set; }
        public DateTime DataEmissao { get; set; }
        public string NomeCliente { get; set; }
        public string EmailCliente { get; set; }
        public IEnumerable<PedidoItemDTO> Itens { get; set; }
        public decimal ValorTotal { get; set; }

        public static PedidoDTO FromPedido(Pedido pedido)
        {
            return new PedidoDTO
            {
                Codigo = pedido.PedidoId,
                DataEmissao = pedido.DataEmissao,
                NomeCliente = pedido.Cliente.Nome,
                EmailCliente = pedido.Cliente.Email,
                Itens = pedido.PedidoProdutos.Select(pp => PedidoItemDTO.FromPedidoProduto(pp)),
                ValorTotal = pedido.PedidoProdutos.Sum(pp => pp.ValorUnitario * pp.Quantidade)
            };
        }
    }

    public class PedidoItemDTO
    {
        public int CodigoProduto {get; set;}
        public string NomeProduto {get; set;}
        public int Quantidade { get; set; }
        public static PedidoItemDTO FromPedidoProduto(PedidoProduto item)
        {
            return new PedidoItemDTO
            {
                CodigoProduto = item.Produto.ProdutoId,
                NomeProduto = item.Produto.Nome,
                Quantidade = item.Quantidade
            };
        }
    }
}