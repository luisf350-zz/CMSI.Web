using System.ComponentModel.DataAnnotations;

namespace CMSI.Web.Models
{
    public class Procedimiento: BaseModel
    {
        [Required]
        public string Codigo { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Precio { get; set; }
    }
}
