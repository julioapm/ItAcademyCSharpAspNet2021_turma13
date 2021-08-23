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
    public class ProdutosController : ControllerBase
    {
        private readonly ILogger<ProdutosController> _logger;
        private readonly BdContext _basedados;

        public ProdutosController(ILogger<ProdutosController> logger, BdContext basedados)
        {
            _logger = logger;
            _basedados = basedados;
        }

        //GET /produtos
        [HttpGet]
        public IEnumerable<ProdutoDTO> BuscarTodosProdutos()
        {
            return _basedados.Produtos.Select(ProdutoDTO.FromProduto);
        }

        //GET /produtos/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ProdutoDTO>> BuscarProdutoPorId(int id)
        {
            try
            {
                var produto = await _basedados.Produtos
                    .AsNoTracking()
                    .SingleOrDefaultAsync(p => p.ProdutoId == id);
                if (produto == null)
                {
                    return NotFound();
                }
                return ProdutoDTO.FromProduto(produto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Falha de consultao ao produto de id {id}");
                throw;
            }
        }
    }
}
