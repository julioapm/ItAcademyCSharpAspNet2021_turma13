using System;
using System.Collections.Generic;

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
    }

    public class PedidoItemDTO
    {
        public int CodigoProduto {get; set;}
        public string NomeProduto {get; set;}
        public int Quantidade { get; set; }
    }
}