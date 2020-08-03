using Microsoft.EntityFrameworkCore;
using System;

namespace CMSI.Web.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public DbSet<Procedimiento> Procedimientos { get; set; }
    }
}
