using ChallengeAlkemy.Models;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Repositories.IRepositories
{
    public interface IGeneroRepository
    {        
        Task AddGenero(Genero genero);
        Task UpdateGenero(Genero genero);
        Task DeleteGenero(Genero genero);
        
    }
}
