using ClubCosmopolita.Data;
using ClubCosmopolita.Modelos;
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
    public partial class FrmNuevoEditarActividad : Form
    {
        public FrmNuevoEditarActividad()
        {
            InitializeComponent();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            //instanciamos el dbcontext
            var db = new CosmopolitaContext();
            //creamos un objeto del tipo cobrador
            var actividad = new Actividad();
            //cargamos los datos de la pantalla en el objeto cobrador
            actividad.Nombre=TxtNombre.Text;
            actividad.Horarios = txtHorarios.Text;
            actividad.Costo = nudCosto.Value;
            //agregamos el cobrador al dbcontext
            db.Actividades.Add(actividad);
            //guardamos los cambios
            db.SaveChanges();
            //cerramos el formulario
            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
