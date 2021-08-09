using System;

namespace Laboratorio3
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta = new ContaCorrente("12345678901");
            conta.Depositar(100);
            conta.Sacar(50);
            Console.WriteLine(conta.Titular);
            Console.WriteLine(conta.Saldo);
            Console.WriteLine(ContaCorrente.MINIMO_DEPOSITO);
        }
    }
}
