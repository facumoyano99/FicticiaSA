using System.ComponentModel.DataAnnotations;

namespace FicticiaSA.Models.Dtos.UserDtos
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Usuario Requerido.")]
        public string User { get; set; }
        [Required(ErrorMessage = "Contraseña Requerida.")]
        public string Password { get; set; }
    }
}
