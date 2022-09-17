using ChallengeAlkemy.Data;
using ChallengeAlkemy.Models;
using ChallengeAlkemy.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Repositories
{   
    public class PeliculaRepository : IPeliculaRepository
    {
        private ApplicationDbContext _dbContext;

        public PeliculaRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddPelicula(Pelicula pelicula)
        {
            _dbContext.Pelicula.Add(pelicula);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePelicula(Pelicula pelicula)
        {
            _dbContext.Pelicula.Remove(pelicula);
            await _dbContext.SaveChangesAsync();
        }


        public async Task UpdatePelicula(Pelicula pelicula)
        {
            _dbContext.Pelicula.Update(pelicula);
            await _dbContext.SaveChangesAsync();
        }     
        
        public async Task<Pelicula> GetPelicula(int id)
        {
            return await _dbContext.Pelicula.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<Pelicula>> GetPeliculas(string titulo, int? generoId, DateTime? fechaDeCreacion)
        {
            IQueryable<Pelicula> query = _dbContext.Pelicula;

            if (!string.IsNullOrEmpty(titulo))
            {
                query = query.Where(p => p.Titulo.Contains(titulo));
            }

            if (fechaDeCreacion != null)
            {
                query = query.Where(p => p.FechaDeCreacion == fechaDeCreacion);
            }

            return await query.ToListAsync();
        }
    }
}
