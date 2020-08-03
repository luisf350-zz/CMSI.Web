using System.ComponentModel.DataAnnotations;

namespace CMSI.Web.Models
{
    public class Profesional : BaseModel
    {
        [Required]
        [Display(Name = "Nro. Identificación")]
        public long NroIdentificacion { get; set; }

        [Required]
        public string Nombres { get; set; }

        [Required]
        public string Apellidos { get; set; }

        [Required]
        public string Registro { get; set; }

        [Required]
        public string Especialidad { get; set; }

        [DataType(DataType.MultilineText)]
        public string Observaciones { get; set; }
    }
}
