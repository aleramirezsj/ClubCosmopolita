using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmopolitaWeb.Models
{
    public class Actividad
    {
        public int Id { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? Horarios { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Costo { get; set; }
    }
}
