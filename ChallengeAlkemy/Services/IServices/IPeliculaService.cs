using ChallengeAlkemy.Dtos;
using ChallengeAlkemy.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Services.IServices
{
    public interface IPeliculaService
    {
        Task<PeliculaDto> GetPelicula(int peliculaId);
        Task<IEnumerable<SearchPeliculaResponseDto>> GetPeliculas (SearchPeliculaRequestDto request);
        Task<string> AddPelicula(SavePeliculaDto model);
        Pelicula UpdatePelicula (SavePeliculaDto peliculaUpdate);
        Task DeletePelicula (int peliculaId);
    }
}
