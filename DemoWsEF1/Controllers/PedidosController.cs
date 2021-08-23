using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DemoWsEF1.Models;
using DemoWsEF1.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DemoWsEF1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly ILogger<ProdutosController> _logger;
        private readonly BdContext _basedados;
        public PedidosController(ILogger<ProdutosController> logger, BdContext basedados)
        {
            _logger = logger;
            _basedados = basedados;
        }

        //POST /pedidos
        [HttpPost]
        public async Task<ActionResult<PedidoDTO>> ProcessarCarrinho(CarrinhoDTO carrinho)
        {
            var pedido = new Pedido();
            pedido.DataEmissao = DateTime.Now;
            var cliente = await _basedados.Clientes.FindAsync(carrinho.IdCliente);
            if (cliente == null)
            {
                return BadRequest("Cliente não encontrado");
            }
            pedido.Cliente = cliente;
            if (carrinho.Itens.Count() == 0)
            {
                return BadRequest("Carrinho vazio");
            }
            foreach (var item in carrinho.Itens)
            {
                var produto = await _basedados.Produtos.FindAsync(item.CodigoProduto);
                if (produto == null)
                {
                    return BadRequest($"Produto não encontrado {item.CodigoProduto}");
                }

            }

            await _basedados.Pedidos.AddAsync(pedido);
            await _basedados.SaveChangesAsync();            
        }
    }
}