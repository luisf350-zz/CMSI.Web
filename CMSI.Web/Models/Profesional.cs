using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSI.Web.Models
{
    public class Profesional : BaseModel
    {
        [Required]
        [ForeignKey("TipoDocumentoId")]
        [Display(Name = "Tipo Documento")]
        public TipoDocumento TipoDocumento { get; set; }

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

        [Display(Name = "Tipo Documento")]
        public Guid TipoDocumentoId { get; set; }

        public List<PorcentajeProfesional> Porcentajes { get; set; }
    }
}
