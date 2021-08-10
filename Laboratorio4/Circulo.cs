namespace Laboratorio4
{
    public class Circulo
    {
        public double CentroX { get; set; }
        public double CentroY { get; set; }
        public double Raio { get; set; }

        public Circulo(double x, double y, double r)
        {
            CentroX = x;
            CentroY = y;
            Raio = r;
        }

        public override string ToString()
        {
            return $"Centro: ({CentroX}, {CentroY}), Raio: {Raio}";
        }

        protected void Mover(double dx, double dy)
        {
            CentroX += dx;
            CentroY += dy;
        }
    }
}