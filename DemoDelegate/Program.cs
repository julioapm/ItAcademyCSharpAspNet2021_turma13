using System;

namespace DemoDelegate
{
    public delegate R MeuDelagate<T,R>(T x);
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
            ReferenciaMetodoVoid refm3 = () => Console.WriteLine("Alo Mundo");
            ReferenciaMetodoVoidComParametro refm4 = x => Console.WriteLine(x);
            int resultado = FazAlgo((x,y) => x*y, 5);
            Console.WriteLine(resultado);

            var acoisa = ConstroiMetodo(5);
            int resultado2 = acoisa(10);
            Console.WriteLine(resultado2);

            MeuDelagate<string,int> refm5 = x => x.Length;
        }

        static void AloMundo()
        {
            Console.WriteLine("Alo mundo");
        }

        static void AloNumero(int x)
        {
            Console.WriteLine("Alo {0}", x);
        }

        static int FazAlgo(Func<int,int,int> f, int x)
        {
            return f(x, x);
        }

        static Func<int,int> ConstroiMetodo(int y)
        {
            return (x) => x + y;
        }


    }
}
