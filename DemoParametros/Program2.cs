using System;
using System.Text;

namespace DemoParametros
{
    class Program2
    {
        static void Main(string[] args)
        {
            StringBuilder dado = new StringBuilder("teste");
            //MetodoPassagemPorValor(dado);
            //Console.WriteLine("dado = {0}", dado);
            MetodoPassagemPorReferencia(ref dado);
            Console.WriteLine("dado = {0}", dado);
        }

        static void MetodoPassagemPorValor(StringBuilder s)
        {
            Console.WriteLine("Entrada s = {0}", s);
            s = new StringBuilder("outro");
            Console.WriteLine("Saida s = {0}", s);
        }

        static void MetodoPassagemPorReferencia(ref StringBuilder s)
        {
            Console.WriteLine("Entrada s = {0}", s);
            s = new StringBuilder("outro");
            Console.WriteLine("Saida s = {0}", s);
        }
    }
}
