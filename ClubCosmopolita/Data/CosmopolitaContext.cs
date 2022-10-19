using ClubCosmopolita.Enums;
using ClubCosmopolita.Modelos;
using ClubCosmopolita.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Carga de Usuarios
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id=1, 
                              Nombre="Adminitrador",
                              User="admin",
                              Password=Helper.ObtenerHashSha256("123"),
                              TipoUsuario=TipoUsuarioEnum.Administrador}
           );
            #endregion
            #region carga de actividades
            modelBuilder.Entity<Actividad>().HasData(
                new Actividad
                {
                    Id = 1,
                    Nombre = "Folklore",
                    Horarios = "Martes y Jueves 20hs",
                    Costo = 2000
                },
                new Actividad
                {
                    Id = 2,
                    Nombre = "Telas",
                    Horarios = "Lunes y miércoles 15:00hs2",
                    Costo = 2500
                }
                );
            #endregion
            #region Carga de Socios
            modelBuilder.Entity<Socio>().HasData(
                new Socio
                {
                    Id = 1,
                    Apellido_Nombre = "Acevedo Lautaro",
                    Dirección = "San Justo",
                    Teléfono = "3498345345"
                },
                new Socio
                {
                    Id = 2,
                    Apellido_Nombre = "Lescano Marcos",
                    Dirección = "San Justo",
                    Teléfono = "3498324870"
                }
                );
            #endregion
            #region Cobradores
            modelBuilder.Entity<Cobrador>().HasData(
                new Cobrador
                {
                    Id = 1,
                    Apellido_Nombre = "Juárez, Tomás"
                },
                new Cobrador
                {
                    Id = 2,
                    Apellido_Nombre = "Acevedo, Lautaro"
                }
                );
            #endregion
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source =.\SQLEXPRESS; Initial Catalog = CosmopolitaContext; User Id = sa; Password = 123; MultipleActiveResultSets = True");
            //optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database=CosmopolitaContext; Integrated Security=True;");
            optionsBuilder.UseMySql("Server=184.175.77.148;Database=smartsof_2doTSDS2022;Uid=smartsof_2doTSDS;Pwd=2doTSDS;",ServerVersion.AutoDetect("Server=184.175.77.148;Database=smartsof_2doTSDS2022;Uid=smartsof_2doTSDS;Pwd=2doTSDS;"),
                    options => options.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: System.TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null));
            //optionsBuilder.UseMySQL("Server=127.0.0.1;Database=smartsof_2doTSDS2022;Uid=root;Pwd=milton;");


        }

        #region Declaración de los DbSets
        //cada DbSet representa una tabla en la BBDD
        public DbSet<Socio> Socios { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Cuota> Cuotas { get; set; }
        public DbSet<Cobrador>  Cobradores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        #endregion
    }
}
