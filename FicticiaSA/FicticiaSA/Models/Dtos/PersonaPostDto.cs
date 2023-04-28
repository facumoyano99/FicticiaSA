using System.ComponentModel.DataAnnotations;

namespace FicticiaSA.Models.Dtos
{
    public class PersonaPostDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string NombreCompleto { get; set; }
        [Required(ErrorMessage = "El número de documento es obligatorio")]
        [MinLength(8,ErrorMessage = "El número de documento debe poseer 8 números")]
        [MaxLength(8,ErrorMessage = "El número de documento debe poseer 8 números")]
        public string Identificacion { get; set; }
        [Required(ErrorMessage = "La edad es obligatoria")]
        public int Edad { get; set; }
        [Required(ErrorMessage = "El género es obligatorio")]
        public string Genero { get; set; }
        [Required(ErrorMessage = "El estado es obligatorio")]
        public bool? Maneja { get; set; }
        public bool? UsaLentes { get; set; }
        public bool? Diabetico { get; set; }
        public bool? OtraEnfermedad { get; set; }
        public string? OtrasEnfermedades { get; set; }
    }
}
