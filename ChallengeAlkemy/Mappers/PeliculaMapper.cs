using ChallengeAlkemy.Dtos;
using ChallengeAlkemy.Models;

namespace ChallengeAlkemy.Mappers
{
    public class PeliculaMapper
    {
        public PeliculaDto MapToDto(Pelicula pelicula)
        {
            if (pelicula == null) return null;
            PersonajeMapper personajeMapper = new PersonajeMapper();

            return new PeliculaDto()
            {
                Id = pelicula.Id,
                Imagen = pelicula.Imagen,
                Titulo = pelicula.Titulo,
                FechaDeCreacion = pelicula.FechaDeCreacion,
                Calificacion = pelicula.Calificacion,
                PersonajesAsociados = personajeMapper.MapManyToDto(pelicula.PersonajesAsociados),
            };
        }


        public Pelicula MapToSearchPeliculaDto(SavePeliculaDto pelicula)
        {
            return new Pelicula()
            {
                Id = pelicula.Id,
                Imagen = pelicula.Imagen,
                Titulo = pelicula.Titulo,
                FechaDeCreacion = pelicula.FechaDeCreacion,
                Calificacion = pelicula.Calificacion,                
            };
        }

        public Pelicula MapFromSavePeliculaDto(SavePeliculaDto pelicula)
        {
            if (pelicula == null) return null;

            return new Pelicula
            {
                Id = pelicula.Id,
                Imagen = pelicula.Imagen,
                Titulo = pelicula.Titulo,
                FechaDeCreacion = pelicula.FechaDeCreacion,
                Calificacion = pelicula.Calificacion,
            };
        }

        public Pelicula MapFromSavePeliculaDto(SavePeliculaDto pelicula, Pelicula model)
        {
            if (pelicula == null) return null;
            if (model == null) return null;

            model.Id = pelicula.Id;
            model.Imagen = pelicula.Imagen;
            model.Titulo = pelicula.Titulo;
            model.FechaDeCreacion = pelicula.FechaDeCreacion;
            model.Calificacion = pelicula.Calificacion;

            return model;
        }

        public SearchPeliculaResponseDto MapFromPelicula(Pelicula pelicula)
        {
            if (pelicula == null) return null;

            return new SearchPeliculaResponseDto
            {
                Imagen = pelicula.Imagen,
                Titulo = pelicula.Titulo,
                FechaDeCreacion = pelicula.FechaDeCreacion
            };
        }
    }
}