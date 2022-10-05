using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmopolitaWeb.Models
{
    public class Cobrador
    {
        public int Id { get; set; }
        [Required]
        public string? Apellido_Nombre { get; set; }
    }
}
