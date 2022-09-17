using AutoMapper;
using ChallengeAlkemy.Dtos;
using ChallengeAlkemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Mappers
{
    public class PersonajeMapper
    {
        PeliculaMapper peliculaMapper = new PeliculaMapper();

        public PersonajeDto MapToDto(Personaje personaje)
        {
            if (personaje == null) return null;
           
            return new PersonajeDto()
            {
                Id = personaje.Id,
                Imagen = personaje.Imagen,
                Nombre = personaje.Nombre,
                Edad = personaje.Edad,
                Peso = personaje.Peso,
                Historia = personaje.Historia,
                PeliculasAsociadas = personaje.PeliculasAsociadas?.Select(p => peliculaMapper.MapToDto(p.Pelicula))?.ToList()
            };
        }

        public List<PersonajeDto> MapManyToDto(List<Personaje> personajes)
        {
           if(personajes == null) return null;  

            return personajes.Select(p => new PersonajeDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Imagen = p.Imagen,
                Peso = p.Peso,
                Edad = p.Edad,
                Historia = p.Historia,
            }).ToList();
        }

        public Personaje MapToSearchPersonajeDto(SavePersonajeDto personaje)
        {
            return new Personaje()
            {
                Id = personaje.Id,
                Imagen = personaje.Imagen,
                Nombre = personaje.Nombre,
                Edad = personaje.Edad,
                Peso = personaje.Peso,
                Historia = personaje.Historia,
               // PeliculasAsociadas = personaje.PeliculasAsociadas?.Select(p => peliculaMapper.MapToDto(p.Pelicula))?.ToList()
            };
        }

        public Personaje MapFromSavePersonajeDto(SavePersonajeDto personaje)
        {
            if (personaje == null) return null;

            return new Personaje
            {
                Id = personaje.Id,
                Imagen = personaje.Imagen,
                Nombre = personaje.Nombre,
                Edad = personaje.Edad,
                Peso = personaje.Peso,
                Historia = personaje.Historia,
               
            };
        }
 
        public Personaje MapFromSavePersonajeDto(SavePersonajeDto personaje, Personaje model)
        {
            if (personaje == null) return null;
            if (model == null) return null;

            model.Id = personaje.Id;
            model.Imagen = personaje.Imagen;
            model.Nombre = personaje.Nombre;
            model.Edad = personaje.Edad;
            model.Peso = personaje.Peso;
            model.Historia = personaje.Historia;
            
            
            return model;
        }

        public SearchPersonajeResponseDto MapFromPersonaje(Personaje personaje)
        {
            if (personaje == null) return null;

            return new SearchPersonajeResponseDto
            {
                Imagen = personaje.Imagen,
                Nombre = personaje.Nombre,
            };
        }
    }

           
}
