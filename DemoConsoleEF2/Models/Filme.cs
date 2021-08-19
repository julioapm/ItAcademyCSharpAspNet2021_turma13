namespace DemoConsoleEF2.Models
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public string Diretor { get; set; }
        public string Sinopse { get; set; }
        public int? Duracao { get; set; }
    }
}