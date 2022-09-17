using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChallengeAlkemy.Models
{
    public class Genero
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Imagen { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }
        public List<Pelicula> PeliculasAsociadas { get; set; }
    }
}
