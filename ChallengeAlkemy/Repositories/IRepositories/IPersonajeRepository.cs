using ChallengeAlkemy.Dtos;
using ChallengeAlkemy.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Repositories.IRepositories
{
    public interface IPersonajeRepository
    {
        Task <Personaje> GetPersonaje(int id);
        Task AddPersonaje(Personaje personaje);
        Task UpdatePersonaje(Personaje personaje);
        Task DeletePersonaje(Personaje personaje);
        Task <IEnumerable<Personaje>> GetPersonajes(string nombre, double? peso, int? edad, int? peliculaId);
    }
}
