using ClubCosmopolita.Data;
using ClubCosmopolita.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Forms;

namespace ClubCosmopolita.Presentación
{
    public partial class FrmNuevoEditarActividad : Form
    {
        Actividad actividad;
        //agregando una nueva actividad
        public FrmNuevoEditarActividad()
        {
            InitializeComponent();
        }
        //modificando una actividad existente
        public FrmNuevoEditarActividad(int idActividad)
        {
            InitializeComponent();
            CargarDatosActividad(idActividad);
        }

        private void CargarDatosActividad(int idActividad)
        {
            //instanciamos la clase dbcontext
            var db = new CosmopolitaContext();
            //obtenemos la actividad con el método find
            actividad = db.Actividades.Find(idActividad);
            //cargamos los datos en la pantalla
            TxtNombre.Text = actividad.Nombre;
            txtHorarios.Text = actividad.Horarios;
            nudCosto.Value = actividad.Costo;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            //instanciamos el dbcontext
            var db = new CosmopolitaContext();
            if (actividad == null)
            {
                //creamos un objeto del tipo actividad
                actividad = new Actividad();
                //cargamos los datos de la pantalla en el objeto actividad
                actividad.Nombre = TxtNombre.Text;
                actividad.Horarios = txtHorarios.Text;
                actividad.Costo = nudCosto.Value;
                //agregamos el cobrador al dbcontext
                db.Actividades.Add(actividad);
            }
            else
            {
                actividad.Nombre = TxtNombre.Text;
                actividad.Horarios = txtHorarios.Text;
                actividad.Costo = nudCosto.Value;
                //definimos que estamos modificando la actividad
                db.Entry(actividad).State = EntityState.Modified;
            }
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
