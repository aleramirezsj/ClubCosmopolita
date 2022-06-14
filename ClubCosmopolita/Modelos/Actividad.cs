using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubCosmopolita.Modelos
{
    public class Actividad
    {
        public int Id { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? Horarios { get; set; }
        [Required]
        public decimal Costo { get; set; }
    }
}
