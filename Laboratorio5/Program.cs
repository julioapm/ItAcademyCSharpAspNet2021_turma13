using System;

namespace Laboratorio5
{
    class Program
    {
        static void Main(string[] args)
        {
            Conta[] contas = new Conta[2];
            contas[0] = new ContaPoupanca(0.01M, new DateTime(2020,3,10), "12345678901");
            contas[1] = new ContaPoupanca(0.01M, new DateTime(2021,1,5), "12345678902");
            foreach (Conta c in contas)
            {
                Console.WriteLine($"Id: {c.Id} Saldo: {c.Saldo}");
            }
        }
    }
}
