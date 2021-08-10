using System;

namespace Laboratorio4
{
    class Program
    {
        static void Main(string[] args)
        {
            Circulo c1 = new Circulo(2, 3, 4);
            c1.Raio = 10;
            Console.WriteLine(c1.ToString());
            Console.WriteLine(((object)c1).ToString());
            Circulo c2 = new Circulo(2, 3, 4);
            Console.WriteLine(c1 == c2);
            Console.WriteLine(c1.Equals(c2));

            CirculoColorido c3 = new CirculoColorido();
            Console.WriteLine(c3);

            Circulo c4 = new CirculoColorido();
            Console.WriteLine(c4);

        }
    }
}
