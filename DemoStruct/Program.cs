using System;

namespace DemoStruct
{
    class Program
    {
        static void Main(string[] args)
        {
            Fracao f1 = new Fracao(1, 2);
            Fracao f2 = f1;
            Fracao f3 = f1 + f2;
            Console.WriteLine(f3.Numerador);
            Console.WriteLine(f3.Denominador);
        }
    }
}
