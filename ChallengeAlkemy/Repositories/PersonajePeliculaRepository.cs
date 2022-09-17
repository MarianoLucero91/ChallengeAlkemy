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
    public class PersonajePeliculaRepository : IPersonajePeliculaRepository
    {

        private ApplicationDbContext _dbContext;

        public PersonajePeliculaRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddPersonajePelicula(List<PersonajePelicula> relaciones)
        {
            foreach (var relacion in relaciones)
            {
                _dbContext.PersonajePelicula.Add(relacion);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePersonajePelicula(PersonajePelicula personajePelicula)
        {
            _dbContext.PersonajePelicula.Remove(personajePelicula);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<PersonajePelicula>> GetByPersonaje(int personajeId)
        {
            if (!(personajeId > 0)) throw new Exception("Debe especificar un id de personaje");

            IQueryable<PersonajePelicula> query = _dbContext.PersonajePelicula;

            query = query.Where(x => x.PersonajeId == personajeId);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<PersonajePelicula>> GetByPelicula(int peliculaId)
        {
            if (!(peliculaId > 0)) throw new Exception("Debe especificar un id de pelicula");

            var relations = _dbContext.PersonajePelicula.Include(x => x.Pelicula).Include(x => x.Personaje).Where(x => x.PeliculaId == peliculaId).ToList();

            return relations;
        }
    }
}
