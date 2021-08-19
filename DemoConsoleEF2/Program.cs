using System;
using DemoConsoleEF2.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DemoConsoleEF2
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new FilmesDbContext())
            {
                Filme f1 = new Filme { Titulo = "Titanic", Ano = 1997 };
                Filme f2 = new Filme { Titulo = "Titanic 2", Ano = 1998, Duracao = 120 };
                db.Add(f1);
                db.Filmes.Add(f2);
                db.SaveChanges();
            }
        }
    }
}
