using System;
using System.Collections.Generic;

namespace Laboratorio6
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<IEstadoBinario> dispositivos = new List<IEstadoBinario>();
            dispositivos.Add(new Lampada(110,60));
            foreach (var dispositivo in dispositivos)
            {
                dispositivo.Ligar();
            }
            foreach (var dispositivo in dispositivos)
            {
                Console.WriteLine(dispositivo.Estado);
            }
        }
    }
}
