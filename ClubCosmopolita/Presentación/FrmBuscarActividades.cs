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
    public partial class FrmBuscarActividades : Form
    {
        //instanciamos el objeto dbcontext
        CosmopolitaContext db = new CosmopolitaContext();
        public int idActividadSeleccionada = 0;
        public FrmBuscarActividades()
        {
            InitializeComponent();
            ActualizarGrilla();
        }
        private void ActualizarGrilla(string cadenaDeBusqueda)
        {
            //traemos la lista de actividades
            var listaActividades = db.Actividades.Where(a => a.Nombre.Contains(cadenaDeBusqueda)).ToList();

            //la asignamos a la grilla
            GrdActividades.DataSource = listaActividades;
        }
        private void ActualizarGrilla()
        {
            //traemos la lista de actividades
            var listaActividades = db.Actividades.ToList();

            //la asignamos a la grilla
            GrdActividades.DataSource = listaActividades;
        }

        private void TxtBusqueda_TextChanged(object sender, EventArgs e)
        {
            ActualizarGrilla(TxtBusqueda.Text);
        }

        private void GrdActividades_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            idActividadSeleccionada = (int)GrdActividades.CurrentRow.Cells[0].Value;
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.Close();
        }
    }
}
