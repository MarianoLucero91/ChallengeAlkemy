using System.ComponentModel.DataAnnotations;

namespace ChallengeAlkemy.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
