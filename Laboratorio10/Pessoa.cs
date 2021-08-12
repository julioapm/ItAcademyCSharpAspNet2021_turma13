using System;

namespace Laboratorio10
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Casada { get; set; }
        public override string ToString()
        {
            return $"Nome={Nome} Casada={Casada} DataNascimento={DataNascimento.ToShortDateString()}";
        }
    }
}