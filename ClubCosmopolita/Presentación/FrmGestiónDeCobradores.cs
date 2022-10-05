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
    public partial class FrmGestiónDeCobradores : Form
    {
        public FrmGestiónDeCobradores()
        {
            InitializeComponent();
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            //instanciamos el objeto dbcontext
            var db = new CosmopolitaContext();

            //traemos la lista de actividades
            var listaCobradores= db.Cobradores.ToList();

            //la asignamos a la grilla
            GrdCobradores.DataSource= listaCobradores;

            
            //las 3 líneas pueden estar en una sola expresión
            //GrdActividades.DataSource = new CosmopolitaContext().Actividades.ToList();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            var frmNuevoEditarCobrador = new FrmNuevoEditarCobrador();
            frmNuevoEditarCobrador.ShowDialog();
            ActualizarGrilla();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtBusqueda_TextChanged(object sender, EventArgs e)
        {
            ActualizarGrilla(TxtBusqueda.Text);
        }

        private void ActualizarGrilla(string cadenaDeBusqueda)
        {
            //instanciamos el objeto dbcontext
            var db = new CosmopolitaContext();

            //traemos la lista de actividades
            var listaCobradores = db.Cobradores.Where(a=>a.Apellido_Nombre.Contains(cadenaDeBusqueda)).ToList();

            //la asignamos a la grilla
            GrdCobradores.DataSource = listaCobradores;
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            //obtenemos el id de la fila seleccionada
            var idCobrador =(int) GrdCobradores.CurrentRow.Cells[0].Value;
            var frmNuevoEditarCobrador = new FrmNuevoEditarCobrador(idCobrador);
            frmNuevoEditarCobrador.ShowDialog();
            ActualizarGrilla();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            //obtenemos el id y nombre de la actividad seleccionada
            var idCobrador = (int)GrdCobradores.CurrentRow.Cells[0].Value;
            var nombreCobrador= (string)GrdCobradores.CurrentRow.Cells[1].Value;

            //preguntamos al usuario si está seguro que quiere borrar
            DialogResult respuesta = MessageBox.Show($"¿Deseas eliminar al cobrador {nombreCobrador}?","Eliminar cobrador",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            
            //si contestó que si, borramos la actividad
            if(respuesta == DialogResult.Yes)
            {
                //instanciamos la clase dbcontext
                var db = new CosmopolitaContext();

                //obtenemos la actividad a borrar
                var cobradorABorrar = db.Cobradores.Find(idCobrador);

                //borramos la actividad
                db.Cobradores.Remove(cobradorABorrar);

                //guardamos los cambios
                db.SaveChanges();

                ActualizarGrilla();
            }
        }
    }
}
