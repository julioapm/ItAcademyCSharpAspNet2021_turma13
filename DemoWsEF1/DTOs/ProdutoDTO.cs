using DemoWsEF1.Models;

namespace DemoWsEF1.Dtos
{
    public class ProdutoDTO
    {
        public int Codigo {get; set;}
        public string Nome {get; set;}
        public decimal PrecoUnitario {get; set;}

        public static ProdutoDTO FromProduto(Produto produto)
        {
            return new ProdutoDTO
            {
                Codigo = produto.ProdutoId,
                Nome = produto.Nome,
                PrecoUnitario = produto.Preco
            };
        }
    }
}