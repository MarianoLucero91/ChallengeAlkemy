using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChallengeAlkemy.Models
{
    public class Personaje
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Imagen { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }
        [Required]
        [Range(0, 100)]
        public int Edad { get; set; }
        [Required]
        public double Peso { get; set; }
        [Required]
        [MaxLength(500)]
        public string Historia { get; set; }       
        public List<PersonajePelicula> PeliculasAsociadas { get; set; }

    }
}
