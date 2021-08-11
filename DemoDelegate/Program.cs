using System;

namespace DemoDelegate
{
    public delegate void ReferenciaMetodoVoid();
    public delegate void ReferenciaMetodoVoidComParametro(int x);
    class Program
    {
        static void Main(string[] args)
        {
            ReferenciaMetodoVoid refm = AloMundo;
            refm();
            ReferenciaMetodoVoidComParametro refm2 = AloNumero;
            refm2(10);
        }

        static void AloMundo()
        {
            Console.WriteLine("Alo mundo");
        }

        static void AloNumero(int x)
        {
            Console.WriteLine("Alo {0}", x);
        }
    }
}
