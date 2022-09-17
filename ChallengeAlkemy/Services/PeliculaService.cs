using ChallengeAlkemy.Data;
using ChallengeAlkemy.Dtos;
using ChallengeAlkemy.Mappers;
using ChallengeAlkemy.Models;
using ChallengeAlkemy.Repositories.IRepositories;
using ChallengeAlkemy.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Services
{
    public class PeliculaService : IPeliculaService
    {
        private readonly IPeliculaRepository _peliculaRepository;
        private readonly IPersonajePeliculaRepository _personajePeliculaRepository;
        private readonly IPersonajeService _personajeService;

        public PeliculaService (IPeliculaRepository repository, IPersonajePeliculaRepository personajePeliculaRepository, IPersonajeService personajeService)
        {
            _peliculaRepository = repository;
            _personajePeliculaRepository = personajePeliculaRepository;
            _personajeService = personajeService;
        }

        public async Task<PeliculaDto> GetPelicula(int peliculaId)
        {
            if (peliculaId == 0) throw new Exception("No se encontró ninguna película con el ID indicado");
            
            PeliculaMapper mapper = new PeliculaMapper();

            var pelicula = await _peliculaRepository.GetPelicula(peliculaId);
            if (pelicula == null) throw new Exception("La pelicula solicitada no existe");

            var personajesAsociados = await _personajePeliculaRepository.GetByPelicula(pelicula.Id);

            pelicula.PersonajesAsociados = personajesAsociados.Select(x => x.Personaje).ToList();

            return mapper.MapToDto(pelicula);
        }

        public async Task<IEnumerable<SearchPeliculaResponseDto>> GetPeliculas(SearchPeliculaRequestDto request)
        {
            var peliculas = await _peliculaRepository.GetPeliculas(request.Titulo, request.GeneroId, request.FechaDeCreacion);
            return peliculas.Select(p => new PeliculaMapper().MapFromPelicula(p));
        }

        public async Task<string> AddPelicula(SavePeliculaDto model)
        {
            Validate(model);
            EnsureCharacterExists(model.IdPersonajesAsociados);

            var pelicula = new PeliculaMapper().MapFromSavePeliculaDto(model);

            await _peliculaRepository.AddPelicula(pelicula);

            List<PersonajePelicula> relaciones = new List<PersonajePelicula>();
            foreach (int id in model.IdPersonajesAsociados)
            {
                PersonajePelicula relacion = new PersonajePelicula
                {
                    PersonajeId = id,
                    PeliculaId = pelicula.Id
                };
                relaciones.Add(relacion);
            }
             await _personajePeliculaRepository.AddPersonajePelicula(relaciones);
             

            return "Se creo la pelicula con éxito";
        }

        public async Task DeletePelicula(int peliculaId)
        {
            var deleter = await _peliculaRepository.GetPelicula(peliculaId);
            if (deleter == null)
            {
                throw new Exception("Debe ingresar una película existente");
            }

            await _peliculaRepository.DeletePelicula(deleter);
            return;
        }

        public Pelicula UpdatePelicula(SavePeliculaDto peliculaUpdate)
        {
            Validate(peliculaUpdate);

            var pelicula = _peliculaRepository.GetPelicula(peliculaUpdate.Id).Result;

            pelicula = new PeliculaMapper().MapFromSavePeliculaDto(peliculaUpdate, pelicula);

            _peliculaRepository.UpdatePelicula(pelicula);

            return pelicula;
        }

        private void Validate(SavePeliculaDto request)
        {
            if (request == null ||
                request.Imagen == null ||
                request.Titulo.Length < 0 ||
                request.Titulo.Length > 100 ||
                request.Titulo == null ||
                request.Calificacion < 1 ||
                request.Calificacion > 5 ||
                !request.IdPersonajesAsociados.Any())
                throw new Exception("Los campos ingresados son inválidos.");

            return;
        }

        private async void EnsureCharacterExists(List<int> personajeIds)
        {
            foreach (int id in personajeIds)
            {
                await _personajeService.GetPersonaje(id);
            }

            return;
        }
    }
}
