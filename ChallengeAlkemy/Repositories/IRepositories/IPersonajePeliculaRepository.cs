using ChallengeAlkemy.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Repositories.IRepositories
{
    public interface IPersonajePeliculaRepository
    {

        Task<IEnumerable<PersonajePelicula>> GetByPersonaje(int personajeId);
        Task<IEnumerable<PersonajePelicula>> GetByPelicula(int peliculaId);
        Task AddPersonajePelicula(List<PersonajePelicula> peliculaPersonaje);
        Task DeletePersonajePelicula(PersonajePelicula peliculaPersonaje);
    }
}
