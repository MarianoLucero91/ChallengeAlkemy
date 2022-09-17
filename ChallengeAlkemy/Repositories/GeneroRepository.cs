using ChallengeAlkemy.Data;
using ChallengeAlkemy.Models;
using ChallengeAlkemy.Repositories.IRepositories;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private ApplicationDbContext _dbContext;

        public GeneroRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddGenero(Genero genero)
        {
            _dbContext.Genero.Add(genero);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteGenero(Genero genero)
        {
            _dbContext.Genero.Remove(genero);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateGenero(Genero genero)
        {
            _dbContext.Genero.Update(genero);
            await _dbContext.SaveChangesAsync();
        }
    }
}
