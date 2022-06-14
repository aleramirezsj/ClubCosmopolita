using ClubCosmopolita.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubCosmopolita.Data
{
    public class CosmopolitaContext : DbContext
    {
        public CosmopolitaContext(DbContextOptions<CosmopolitaContext> options)
                    : base(options)
        {
        }
        public CosmopolitaContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source =.\SQLEXPRESS; Initial Catalog = CosmopolitaContext; User Id = sa; Password = 123; MultipleActiveResultSets = True");
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database=CosmopolitaContext; Integrated Security=True;");
        }
        
        //cada DbSet representa una tabla en la BBDD
        public DbSet<Socio> Socios { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Cuota> Cuotas { get; set; }
        public DbSet<Cobrador>  Cobradores { get; set; }
    }
}
