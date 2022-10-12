using CosmopolitaWeb.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public MesEnum Mes { get; set; }
        [Required]
        public int Año { get; set; }
        [Required]
        public decimal Monto { get; set; }
        public bool Cobrada { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Vencimiento { get; set; }
        [DisplayName("Socio")]
        public int SocioId { get; set; }
        public Socio? Socio { get; set; }
        [DisplayName("Actividad")]
        public int ActividadId { get; set; }
        public Actividad? Actividad { get; set; }
        [DisplayName("Cobrador")]
        public int CobradorId { get; set; }
        public Cobrador? Cobrador { get; set; }

    }
}
