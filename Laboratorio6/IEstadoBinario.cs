namespace Laboratorio6
{
    public enum EstadoBinario { Ligado, Desligado };

    public interface IEstadoBinario
    {
        EstadoBinario Estado { get; }
        void Ligar();
        void Desligar();
    }
}