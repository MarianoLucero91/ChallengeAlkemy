using ChallengeAlkemy.Dtos;
using ChallengeAlkemy.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Services.IServices
{
    public interface IPersonajeService
    {
        Task<PersonajeDto> GetPersonaje(int personajeId);
        Task<IEnumerable<SearchPersonajeResponseDto>> GetPersonajes(SearchPersonajeRequestDto request);
        Task<Personaje> AddPersonaje(SavePersonajeDto model);
        Task<Personaje> UpdatePersonaje(SavePersonajeDto personajeUpdateRequest);
        Task DeletePersonaje(int personajeId);
    }
}
