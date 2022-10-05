using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmopolitaWeb.Models
{
    public class Cuota
    {
        public int Id { get; set; }
        [Required]
        public int Mes { get; set; }
        [Required]
        public int Año { get; set; }
        [Required]
        public decimal Monto { get; set; }
        public bool Cobrada { get; set; }
        [Required]
        public DateTime Vencimiento { get; set; }
        public int SocioId { get; set; }
        public Socio? Socio { get; set; }
        public int ActividadId { get; set; }
        public Actividad? Actividad { get; set; }
        public int CobradorId { get; set; }
        public Cobrador? Cobrador { get; set; }

    }
}
