using ChallengeAlkemy.Models;
using System.Collections.Generic;

namespace ChallengeAlkemy.Dtos
{
    public class GeneroDto
    {
        public int Id { get; set; }
        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public List<Pelicula> PeliculasAsociadas { get; set; }
    }
}
