using System;
using System.Threading.Tasks;

namespace DemoAsync
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Vou fazer um cálculo demorado");
            var resultado = await FazCalculoDemoradoAsync(10);
            Console.WriteLine("Resultado = " + resultado);
        }

        static async Task<int> FazCalculoDemoradoAsync(int x)
        {
            Console.WriteLine("Calculando...");
            await Task.Delay(5000);
            Console.WriteLine("Finalizando o cálculo");
            return (int)Math.Pow(2,x);
        }
    }
}
