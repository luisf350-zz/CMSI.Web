using Microsoft.EntityFrameworkCore;

namespace CMSI.Web.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public DbSet<Procedimiento> Procedimientos { get; set; }
        public DbSet<Profesional> Profesionales { get; set; }
    }
}
