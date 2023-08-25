using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LogisticaAPI.Models;

namespace LogisticaAPI.Data
{
    public class LogisticaAPIContext : DbContext
    {
        public LogisticaAPIContext (DbContextOptions<LogisticaAPIContext> options)
            : base(options)
        {
        }

        public DbSet<LogisticaAPI.Models.Cliente> Cliente { get; set; } = default!;

        public DbSet<LogisticaAPI.Models.Bodega>? Bodega { get; set; }

        public DbSet<LogisticaAPI.Models.EnvioMaritimo>? EnvioMaritimo { get; set; }

        public DbSet<LogisticaAPI.Models.EnvioTerrestre>? EnvioTerrestre { get; set; }

        public DbSet<LogisticaAPI.Models.Pais>? Pais { get; set; }

        public DbSet<LogisticaAPI.Models.Puerto>? Puerto { get; set; }

        public DbSet<LogisticaAPI.Models.TipoDeProducto>? TipoDeProducto { get; set; }
    }
}
