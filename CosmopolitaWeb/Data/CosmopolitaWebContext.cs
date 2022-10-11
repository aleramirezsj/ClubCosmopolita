using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CosmopolitaWeb.Models;

namespace CosmopolitaWeb.Data
{
    public class CosmopolitaWebContext : DbContext
    {
        public CosmopolitaWebContext (DbContextOptions<CosmopolitaWebContext> options)
            : base(options)
        {
        }

        public DbSet<CosmopolitaWeb.Models.Socio> Socios { get; set; }

        public DbSet<CosmopolitaWeb.Models.Actividad> Actividades { get; set; }

        public DbSet<CosmopolitaWeb.Models.Usuario> Usuarios { get; set; }
    }
}
