using System.Collections.Generic;
using System.Collections.Concurrent;
using DemoRest1.Models;


namespace DemoRest1.Services
{
    public class CepMemoriaServices : ICepService
    {
        private readonly ConcurrentDictionary<string, ConsultaCep> _dados =
            new ConcurrentDictionary<string, ConsultaCep>();
        public ConsultaCep ConsultaPorCep(string cep)
        {
            ConsultaCep resultado;
            _dados.TryGetValue(cep, out resultado);
            return resultado;
        }

        public IEnumerable<ConsultaCep> ConsultaTodos()
        {
            return _dados.Values;
        }
        public CepMemoriaServices()
        {
            _dados.TryAdd("90619900", new ConsultaCep{
                Logradouro = "Avenida Ipiranga, 6681",
                Bairro = "Partenon",
                Cidade = "Porto Alegre",
                Estado = "RS",
                Cep = "90619900"
            });
            _dados.TryAdd("01001000", new ConsultaCep{
                Logradouro = "Praça da Sé",
                Bairro = "Sé",
                Cidade = "São Paulo",
                Estado = "SP",
                Cep = "01001000"
            });
        }
    }
}