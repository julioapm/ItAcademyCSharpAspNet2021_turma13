using System;
using System.Collections.Generic;

namespace Laboratorio7
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            string[] nomes = {"Julio", "Lucia", "Daniel", "João"};
            Console.WriteLine("Nomes:");
            foreach (string nome in nomes)
            {
                Console.WriteLine(nome);
            }
            Array.Sort(nomes);
            Console.WriteLine("Nomes ordenados:");
            foreach (string nome in nomes)
            {
                Console.WriteLine(nome);
            }
            */
            List<Pessoa> pessoas = new List<Pessoa>()
            {
                new Pessoa {Nome = "Julio", Idade = 30},
                new Pessoa {Nome = "Lucia", Idade = 25},
                new Pessoa {Nome = "Daniel", Idade = 20},
                new Pessoa {Nome = "Julio", Idade = 15}
            };
            Console.WriteLine("Pessoas:");
            foreach (Pessoa pessoa in pessoas)
            {
                Console.WriteLine(pessoa.Nome + " " + pessoa.Idade);
            }
            //pessoas.Sort();
            //pessoas.Sort(new PessoaComparadorIdade());
            pessoas.Sort((p1,p2) => p1.Nome.CompareTo(p2.Nome));
            Console.WriteLine("Pessoas ordenadas:");
            foreach (Pessoa pessoa in pessoas)
            {
                Console.WriteLine(pessoa.Nome + " " + pessoa.Idade);
            }
            Console.WriteLine(pessoas.Exists(p => p.Nome == "Julio"));
        }
    }
}
