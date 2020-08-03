using System.ComponentModel.DataAnnotations;

namespace CMSI.Web.Models
{
    public class TipoDocumento: BaseModel
    {
        [Required]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }
    }
}
