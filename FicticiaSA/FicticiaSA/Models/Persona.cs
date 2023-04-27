using System.ComponentModel.DataAnnotations;

namespace FicticiaSA.Models
{
    public class Persona
    {
        [Key]
        public int IdPersona { get; set; }
        public string NombreCompleto { get; set; }
        public string Identificacion { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public bool EsActivo { get; set; }
        public bool? Maneja { get; set; }
        public bool? UsaLentes { get; set; }
        public bool? Diabetico { get; set; }
        public bool? OtraEnfermedad { get; set; }
        public string? OtrasEnfermedades { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
    }
}
