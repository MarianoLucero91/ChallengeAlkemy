using ChallengeAlkemy.Data;
using ChallengeAlkemy.Models;
using ChallengeAlkemy.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Repositories
{
    public class PersonajeRepository : IPersonajeRepository
    {
        private ApplicationDbContext _dbContext;

        public PersonajeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddPersonaje(Personaje personaje)
        {
            _dbContext.Personaje.Add(personaje);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePersonaje(Personaje personaje)
        {
            _dbContext.Personaje.Remove(personaje);
            await _dbContext.SaveChangesAsync();
        }


        public async Task UpdatePersonaje(Personaje personaje)
        {
            _dbContext.Personaje.Update(personaje);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Personaje> GetPersonaje(int id)
        {
           var personaje = await _dbContext.Personaje.FirstOrDefaultAsync(x => x.Id == id);
           return personaje;
        }

        public async Task<IEnumerable<Personaje>> GetPersonajes(string nombre, double? peso, int? edad, int? peliculaId)
        {
            IQueryable<Personaje> query = _dbContext.Personaje;

            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(p => p.Nombre.Contains(nombre));
            }

            if (peso != null)
            {
                query = query.Where(p => p.Peso == peso);
            }

            if (edad != null)
            {
                query = query.Where(p => p.Edad == edad);
            }

            if (peliculaId != null)
            {
                query = query.Where(p => p.PeliculasAsociadas.Exists(m => m.Id == peliculaId));
            }

            return await query.ToListAsync();
        }
       
    }
}
