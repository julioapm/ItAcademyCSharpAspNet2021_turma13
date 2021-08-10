namespace Laboratorio6
{
    public class Lampada : IEstadoBinario
    {
        private bool ligado;
        private int voltagem;
        private int potencia;

        public Lampada(int v, int p)
        {
            ligado = false;
            voltagem = v;
            potencia = p;
        }

        public EstadoBinario Estado
        {
            get { return ligado ? EstadoBinario.Ligado : EstadoBinario.Desligado; }
        }

        public void Desligar()
        {
            ligado = false;
        }

        public void Ligar()
        {
            ligado = true;
        }
    }
}