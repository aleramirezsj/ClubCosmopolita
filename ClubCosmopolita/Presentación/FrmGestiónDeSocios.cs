using ClubCosmopolita.Data;
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
    public partial class FrmGestiónDeSocios : Form
    {
        public FrmGestiónDeSocios()
        {
            InitializeComponent();
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            var db = new CosmopolitaContext();
            var listaSocios = db.Socios.ToList();
            grdSocios.DataSource = listaSocios;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var frmNuevoEditarSocio = new FrmNuevoEditarSocio();
            frmNuevoEditarSocio.ShowDialog();
            ActualizarGrilla();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            ActualizarGrilla(txtBusqueda.Text);
        }

        private void ActualizarGrilla(string cadenaDeBusqueda)
        {
            var db = new CosmopolitaContext();
            var listaSocios = db.Socios.Where(s => s.Apellido_Nombre.Contains(cadenaDeBusqueda)).ToList();
            grdSocios.DataSource = listaSocios;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var idSocio = (int)grdSocios.CurrentRow.Cells[0].Value;
            var nombreSocios = (string)grdSocios.CurrentRow.Cells[1].Value;
            DialogResult respuesta = MessageBox.Show($"¿Deseas eliminar la actividad {nombreSocios}?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                var db = new CosmopolitaContext();
                var SocioBorrar = db.Socios.Find(idSocio);
                db.Socios.Remove(SocioBorrar);
                db.SaveChanges();
                ActualizarGrilla();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            var idSocio = (int)grdSocios.CurrentRow.Cells[0].Value;
            var frmNuevoEditarSocio = new FrmNuevoEditarSocio(idSocio);
            frmNuevoEditarSocio.ShowDialog();
            ActualizarGrilla();
        }
    }
}
