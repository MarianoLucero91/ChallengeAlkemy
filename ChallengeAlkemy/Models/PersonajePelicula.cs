using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChallengeAlkemy.Models
{
    public class PersonajePelicula
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PersonajeId { get; set; }

        [ForeignKey("PersonajeId")]
        public Personaje Personaje { get; set; }
        
        [Required]
        public int PeliculaId { get; set; }

        [ForeignKey("PeliculaId ")]
        public Pelicula Pelicula { get; set; }
    }
}
