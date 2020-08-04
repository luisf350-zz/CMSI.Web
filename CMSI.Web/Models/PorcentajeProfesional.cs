using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSI.Web.Models
{
    public class PorcentajeProfesional : BaseModel
    {
        [ForeignKey("ProfesionalId")]
        public Profesional Profesional { get; set; }

        [ForeignKey("ProcedimientoId")]
        public Procedimiento Procedimiento { get; set; }

        public double Porcentaje { get; set; }

        public Guid ProfesionalId { get; set; }

        public Guid ProcedimientoId { get; set; }

    }
}
