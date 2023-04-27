using System.ComponentModel.DataAnnotations;

namespace FicticiaSA.Models.Dtos
{
    public class PersonaPatchDto
    {
        [Required(ErrorMessage = "El ID es obligatorio")]
        public int IdPersona { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string NombreCompleto { get; set; }
        [Required(ErrorMessage = "El número de documento es obligatorio")]
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
        [Required(ErrorMessage = "La fecha de alta es obligatoria")]
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
    }
}
