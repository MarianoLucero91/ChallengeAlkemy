using ChallengeAlkemy.Models;
using System;
using System.Collections.Generic;

namespace ChallengeAlkemy.Dtos
{
    public class PeliculaDto
    {
        public int Id { get; set; }
        public string Imagen { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public float Calificacion { get; set; }
        public List<PersonajeDto> PersonajesAsociados { get; set; }
    }
    
    public class SearchPeliculaRequestDto
    {
        public string Titulo { get; set; }
        public int? GeneroId { get; set; }
        public DateTime? FechaDeCreacion { get; set; }
    }

    public class SearchPeliculaResponseDto
    {
        public string Imagen { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaDeCreacion { get; set; }
    }
    
    public class SearchPeliculaDetalleResponseDto : PeliculaDto { }

    public class SavePeliculaDto 
    {
        public int Id { get; set; }
        public string Imagen { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaDeCreacion { get => DateTime.Now; }
        public float Calificacion { get; set; }
        public List<int> IdPersonajesAsociados { get; set; }
    }
}
