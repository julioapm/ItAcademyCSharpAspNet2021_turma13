using System;

namespace DemoEventos
{
    class Program
    {
        static void Main(string[] args)
        {
            Contador c = new Contador(3);
            c.LimiteAtingido += DispararAlarme;
            c.Incrementar();
            c.Incrementar();
            c.Incrementar();
        }
        static void DispararAlarme(object fonte, EventArgs args)
        {
            Console.WriteLine("Alarme Disparado");
        }
    }
}
