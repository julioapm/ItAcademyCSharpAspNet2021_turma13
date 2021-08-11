using System;
using System.Collections.Generic;

namespace Laboratorio7
{
    public class Pessoa : IComparable<Pessoa>
    {
        public string Nome { get; set; }
        public int Idade { get; set; }

        public int CompareTo(Pessoa outra)
        {
            if (Nome.CompareTo(outra.Nome) == 0)
            {
                return Idade.CompareTo(outra.Idade);
            }
            return Nome.CompareTo(outra.Nome);
        }
    }

    public class PessoaComparadorIdade : IComparer<Pessoa>
    {
        public int Compare(Pessoa x, Pessoa y)
        {
            return x.Idade.CompareTo(y.Idade);
        }
    }
}