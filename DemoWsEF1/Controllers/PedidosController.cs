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
            pedido.PedidoProdutos = new List<PedidoProduto>();
            decimal total = 0;
            foreach (var item in carrinho.Itens)
            {
                var produto = await _basedados.Produtos.FindAsync(item.CodigoProduto);
                if (produto == null)
                {
                    return BadRequest($"Produto não encontrado {item.CodigoProduto}");
                }
                var itemDoPedido = new PedidoProduto();
                itemDoPedido.Produto = produto;
                itemDoPedido.Quantidade = item.Quantidade;
                itemDoPedido.ValorUnitario = produto.Preco;
                pedido.PedidoProdutos.Add(itemDoPedido);
                total += produto.Preco * item.Quantidade;
            }

            await _basedados.Pedidos.AddAsync(pedido);
            await _basedados.SaveChangesAsync();
            
            var resposta = new PedidoDTO();
            resposta.Codigo = pedido.PedidoId;
            resposta.DataEmissao = pedido.DataEmissao;
            resposta.NomeCliente = pedido.Cliente.Nome;
            resposta.EmailCliente = pedido.Cliente.Email;
            resposta.Itens = pedido.PedidoProdutos.Select(pp => new PedidoItemDTO {
                CodigoProduto = pp.Produto.ProdutoId,
                NomeProduto = pp.Produto.Nome,
                Quantidade = pp.Quantidade
            }).ToList();
            resposta.ValorTotal = total;
            return resposta;
        }

        //GET /pedidos?cliente={id}
        [HttpGet]
        public async Task<ActionResult<List<PedidoDTO>>> ListarPedidos(int cliente)
        {
            _logger.LogInformation($"Listando pedidos do cliente {cliente}");
            var clienteAtual = await _basedados.Clientes.FindAsync(cliente);
            if (clienteAtual == null)
            {
                return BadRequest("Cliente inexistente.");
            }

            //eager load
            var pedidos = await _basedados.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.PedidoProdutos)
                .ThenInclude(pp => pp.Produto)
                .Where(p => p.ClienteId == cliente)
                .OrderBy(p => p.DataEmissao)
                .ToListAsync();
            
            var resposta = pedidos.Select(p => PedidoDTO.FromPedido(p)).ToList();
            return resposta;
        }
    }
}