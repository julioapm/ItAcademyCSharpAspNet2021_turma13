using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DemoRest1.Models;
using DemoRest1.Services;


namespace DemoRest1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CepController : ControllerBase
    {
        private readonly ILogger<CepController> _logger;
        private readonly ICepService _cepService;

        public CepController(ILogger<CepController> logger, ICepService cepService)
        {
            _logger = logger;
            _cepService = cepService;
        }

        //GET /cep/90210010
        [HttpGet("{cep:regex(^\\d{{8}}$)}")]
        public ActionResult<ConsultaCep> ConsultaCep(string cep)
        {
            _logger.LogInformation($"ConsultaCep: {cep}");
            var resultado = _cepService.ConsultaPorCep(cep);
            if (resultado == null)
            {
                return NotFound();
            }
            return resultado;
        }

        //GET /cep
        [HttpGet]
        public IEnumerable<ConsultaCep> ConsultaCeps()
        {
            _logger.LogInformation("ConsultaCeps");
            return _cepService.ConsultaTodos()
                .OrderBy(c => c.Estado)
                .ThenBy(c => c.Cidade);
        }

        //GET /cep/deuruim
        [HttpGet("deuruim")]
        public void Deuruim()
        {
            _cepService.FazAlgoRuim();
        }

        //POST /cep
        [HttpPost]
        public ActionResult<ConsultaCep> CadastrarCep(ConsultaCep novoCep)
        {
            _logger.LogInformation($"CadastrarCep: {novoCep}");
            var existente = _cepService.ConsultaPorCep(novoCep.Cep);
            if (existente != null)
            {
                return BadRequest("CEP já cadastrado");
            }
            _cepService.Cadastrar(novoCep);
            return CreatedAtAction(
                nameof(ConsultaCep),
                new { cep = novoCep.Cep },
                novoCep
            );
        }
    }
}
