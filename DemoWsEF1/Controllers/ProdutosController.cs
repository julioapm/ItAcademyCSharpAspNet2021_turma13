using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DemoWsEF1.Models;
using DemoWsEF1.Dtos;
//using Microsoft.EntityFrameworkCore;

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
    }
}
