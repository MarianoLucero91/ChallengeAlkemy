using ChallengeAlkemy.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeAlkemy.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Personaje> Personaje { get; set; }

        public DbSet<Pelicula> Pelicula { get; set; }

        public DbSet<Genero> Genero { get; set; }

        public DbSet<PersonajePelicula> PersonajePelicula { get; set; }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
