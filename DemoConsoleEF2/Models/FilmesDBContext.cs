using Microsoft.EntityFrameworkCore;
using System;

namespace DemoConsoleEF2.Models
{
    public class FilmesDbContext : DbContext
    {
        public DbSet<Filme> Filmes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Filme>(
                entity =>
                {
                    entity.Property(e => e.Titulo)
                        .HasMaxLength(50)
                        .IsRequired();
                }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=ITA13_filmes;Integrated Security=True");
            optionsBuilder.EnableSensitiveDataLogging().LogTo(Console.WriteLine);
        }
    }
}