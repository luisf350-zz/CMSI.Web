using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSI.Web.Models
{
    public class BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Fecha Creación")]
        public DateTime FechaCreacion { get; set; }

        [Required]
        [Display(Name = "Fecha Modificación")]
        public DateTime FechaModificacion { get; set; }
    }
}
