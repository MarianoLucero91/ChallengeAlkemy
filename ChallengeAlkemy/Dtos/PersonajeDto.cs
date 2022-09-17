using ChallengeAlkemy.Models;
using System.Collections.Generic;

namespace ChallengeAlkemy.Dtos
{
    public class PersonajeDto
    {
        public int Id { get; set; }
        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public double Peso { get; set; }
        public string Historia { get; set; }
        public List<PeliculaDto> PeliculasAsociadas { get; set; }
    }
    
    public class SearchPersonajeRequestDto
    {
        public int? Edad { get; set; }
        public double? Peso { get; set; }
        public string Nombre { get; set; }
        public int? PeliculaId { get; set; }
    }

    public class SearchPersonajeResponseDto
    {
        public string Imagen { get; set; }
        public string Nombre { get; set; }
    }

    public class SavePersonajeDto : PersonajeDto { }

}
