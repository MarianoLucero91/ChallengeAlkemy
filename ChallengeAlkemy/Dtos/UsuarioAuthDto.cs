using System.ComponentModel.DataAnnotations;

namespace ChallengeAlkemy.Dtos
{
    public class UsuarioAuthDto
    {

        [Required(ErrorMessage = "El usuario es obligatorio")]

        public string UserName { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "La contraseña debe estar entre 4 y 10 caracteres")]

        public string Password { get; set; }
    }

    public class UsuarioAuthLoginDto
    {
        [Required(ErrorMessage = "El usuario es obligatorio")]

        public string UserName { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]

        public string Password { get; set; }
    }
}
