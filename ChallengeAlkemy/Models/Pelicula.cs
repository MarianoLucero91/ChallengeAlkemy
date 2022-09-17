using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChallengeAlkemy.Models
{
    public class Pelicula
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Imagen { get; set; }
        [Required]
        [MaxLength(100)]
        public string Titulo { get; set; }
        [Required]
        public DateTime FechaDeCreacion { get; set; }
        [Required]
        [Range(1, 5)]
        public float Calificacion { get; set; }

        public List<Personaje> PersonajesAsociados { get; set; }
    }
}
