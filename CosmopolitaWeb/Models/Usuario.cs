﻿using CosmopolitaWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmopolitaWeb.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public TipoUsuarioEnum TipoUsuario { get; set; }
    }
}
