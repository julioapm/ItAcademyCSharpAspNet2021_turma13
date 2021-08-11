using System;

namespace DemoEventos
{
    public class Contador
    {
        public event EventHandler LimiteAtingido;
        public int Valor {get; private set;}
        private int valorLimite;
        public Contador(int vl)
        {
            valorLimite = vl;
        }
        public void Incrementar()
        {
            Valor++;
            if (Valor == valorLimite)
            {
                if (LimiteAtingido != null)
                {
                    LimiteAtingido(this, EventArgs.Empty);
                }
            }
        }
    }
}