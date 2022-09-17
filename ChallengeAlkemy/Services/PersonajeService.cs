using ChallengeAlkemy.Dtos;
using ChallengeAlkemy.Mappers;
using ChallengeAlkemy.Models;
using ChallengeAlkemy.Repositories.IRepositories;
using ChallengeAlkemy.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;

namespace ChallengeAlkemy.Services
{
    public class PersonajeService : IPersonajeService
    {
        private readonly IPersonajePeliculaRepository _personajePeliculaRepository;
        private readonly IPersonajeRepository _personajeRepository;

        public PersonajeService(IPersonajeRepository repository, IPersonajePeliculaRepository personajePeliculaRepository)
        {
            _personajeRepository = repository;
            _personajePeliculaRepository = personajePeliculaRepository;

        }

        public async Task<PersonajeDto> GetPersonaje(int personajeId)
        {
            PersonajeMapper personajeMapper = new PersonajeMapper();
            var personaje = await _personajeRepository.GetPersonaje(personajeId);
            if (personaje == null) 
            { 
                throw new Exception("No existe un personaje con ese Id."); 
            }
            var peliculasAsociadas = await _personajePeliculaRepository.GetByPersonaje(personajeId);
            personaje.PeliculasAsociadas = peliculasAsociadas.ToList();

            var response = personajeMapper.MapToDto(personaje);

            return response;
        }

        private void Validate(SavePersonajeDto request)
        {
            if (request == null || 
                request.Imagen == null || 
                request.Nombre.Length < 0 ||
                request.Nombre.Length > 100 || 
                request.Nombre == null || 
                request.Edad <= 0 || 
                request.Peso <= 0 || 
                request.Historia == null || 
                request.Historia.Length <= 0)
                
                throw new Exception("Los campos ingresados son inválidos.");

            return;
        }

        public async Task<Personaje> UpdatePersonaje(SavePersonajeDto personajeUpdateRequest)
        {
            Validate(personajeUpdateRequest);

            var personaje = _personajeRepository.GetPersonaje(personajeUpdateRequest.Id).Result;

            personaje = new PersonajeMapper().MapFromSavePersonajeDto(personajeUpdateRequest, personaje);

            await _personajeRepository.UpdatePersonaje(personaje);

            return personaje;
        }

        public async Task<Personaje> AddPersonaje(SavePersonajeDto model)
        {
            Validate(model);

            var personaje = new PersonajeMapper().MapFromSavePersonajeDto(model);
            await _personajeRepository.AddPersonaje(personaje);

            return personaje;
        }

        public async Task DeletePersonaje(int personajeId)
        {
            var deleter = await _personajeRepository.GetPersonaje(personajeId);

            if (deleter == null)
                throw new Exception("Debe ingresar un personaje existente");

            await _personajeRepository.DeletePersonaje(deleter);
            return;
        }

        public async Task<IEnumerable<SearchPersonajeResponseDto>> GetPersonajes(SearchPersonajeRequestDto request)
        {
            var personajes = await _personajeRepository.GetPersonajes(request.Nombre, request.Peso, request.Edad, request.PeliculaId);
            return personajes.Select(p => new PersonajeMapper().MapFromPersonaje(p));
        }

    }
}
