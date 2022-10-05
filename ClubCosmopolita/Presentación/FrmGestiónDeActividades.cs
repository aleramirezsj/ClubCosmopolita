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
    public partial class FrmGestiónDeActividades : Form
    {
        public FrmGestiónDeActividades()
        {
            InitializeComponent();
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            //instanciamos el objeto dbcontext
            var db = new CosmopolitaContext();

            //traemos la lista de actividades
            var listaActividades= db.Actividades.ToList();

            //la asignamos a la grilla
            GrdActividades.DataSource=listaActividades;

            
            //las 3 líneas pueden estar en una sola expresión
            //GrdActividades.DataSource = new CosmopolitaContext().Actividades.ToList();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            var frmNuevoEditarActividad = new FrmNuevoEditarActividad();
            frmNuevoEditarActividad.ShowDialog();
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
            var listaActividades = db.Actividades.Where(a=>a.Nombre.Contains(cadenaDeBusqueda)).ToList();

            //la asignamos a la grilla
            GrdActividades.DataSource = listaActividades;
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            //obtenemos el id de la fila seleccionada
            var idActividad =(int) GrdActividades.CurrentRow.Cells[0].Value;
            var frmNuevoEditarActividad = new FrmNuevoEditarActividad(idActividad);
            frmNuevoEditarActividad.ShowDialog();
            ActualizarGrilla();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            //obtenemos el id y nombre de la actividad seleccionada
            var idActividad = (int)GrdActividades.CurrentRow.Cells[0].Value;
            var nombreActividad= (string)GrdActividades.CurrentRow.Cells[1].Value;

            //preguntamos al usuario si está seguro que quiere borrar
            DialogResult respuesta = MessageBox.Show($"¿Deseas eliminar la actividad {nombreActividad}?","Eliminar actividad",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            
            //si contestó que si, borramos la actividad
            if(respuesta == DialogResult.Yes)
            {
                //instanciamos la clase dbcontext
                var db = new CosmopolitaContext();

                //obtenemos la actividad a borrar
                var actividadABorrar = db.Actividades.Find(idActividad);

                //borramos la actividad
                db.Actividades.Remove(actividadABorrar);

                //guardamos los cambios
                db.SaveChanges();

                ActualizarGrilla();
            }
        }
    }
}
