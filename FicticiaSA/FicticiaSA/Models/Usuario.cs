using System.ComponentModel.DataAnnotations;

namespace FicticiaSA.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
    }
}
