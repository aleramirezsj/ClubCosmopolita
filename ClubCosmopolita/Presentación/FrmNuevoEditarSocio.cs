using ClubCosmopolita.Data;
using ClubCosmopolita.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubCosmopolita.Presentación
{
    public partial class FrmNuevoEditarSocio : Form
    {
        private Socio socio;
        public FrmNuevoEditarSocio()
        {
            InitializeComponent();
        }

        public FrmNuevoEditarSocio(int idSocio)
        {
            InitializeComponent();
            CargarDatosSocio(idSocio);
        }

        private void CargarDatosSocio(int idSocio)
        {
            var db = new CosmopolitaContext();
            socio = db.Socios.Find(idSocio);
            txtApellido_Nombre.Text = socio.Apellido_Nombre;
            txtDireccion.Text = socio.Dirección;
            txtTelefono.Text = socio.Teléfono;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var db = new CosmopolitaContext();

            if (socio == null)
            {
                var socio = new Socio();
                socio.Apellido_Nombre = txtApellido_Nombre.Text;
                socio.Dirección = txtDireccion.Text;
                socio.Teléfono = txtTelefono.Text;
                db.Socios.Add(socio);
            }
            else
            {
                socio.Apellido_Nombre = txtApellido_Nombre.Text;
                socio.Dirección = txtDireccion.Text;
                socio.Teléfono = txtTelefono.Text;
                db.Entry(socio).State = EntityState.Modified;
            }
            db.SaveChanges();
            this.Close();
        }
    }
}
