using System.Collections.Generic;

namespace DemoWsEF1.Dtos
{
    public class CarrinhoDTO
    {
        public string NomeCliente { get; set; }
        public string EmailCliente { get; set; }
        public IEnumerable<CarrinhoItemDTO> Itens { get; set; }
    }

    public class CarrinhoItemDTO
    {
        public int CodigoProduto {get; set;}
        public int Quantidade { get; set; }
    }
}