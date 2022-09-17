using ChallengeAlkemy.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Repositories.IRepositories
{
    public interface IPeliculaRepository
    {
        Task<Pelicula> GetPelicula(int id);
        Task<IEnumerable<Pelicula>> GetPeliculas(string titulo, int? generoId, DateTime? fechaDeCreacion);
        Task AddPelicula(Pelicula pelicula);
        Task UpdatePelicula(Pelicula pelicula);
        Task DeletePelicula(Pelicula pelicula);
    }
}
