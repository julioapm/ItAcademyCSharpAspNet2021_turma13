using System.Collections.Generic;
using DemoRest1.Models;

namespace DemoRest1.Services
{
    public interface ICepService
    {
        IEnumerable<ConsultaCep> ConsultaTodos();
        ConsultaCep ConsultaPorCep(string cep);
        void FazAlgoRuim();
        void Cadastrar(ConsultaCep cep);
    }
}