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
    public partial class FrmActividades2 : Form
    {
        Actividad actividadActual;
        //instanciamos la clase dbcontext
        CosmopolitaContext db = new CosmopolitaContext();

        //CONSTRUCTOR: método que se llama igual que la clase
        //             que no devuelve valores y que se ejecuta cuando
        //             el formulario se está construyendo en memoria
        public FrmActividades2()
        {
            InitializeComponent();
            BtnPrimero_Click(this, new EventArgs());
        }
        private void CargarDatosActividad()
        {
            //cargamos los datos en la pantalla
            TxtId.Text = actividadActual.Id.ToString();
            TxtNombre.Text = actividadActual.Nombre;
            txtHorarios.Text = actividadActual.Horarios;
            nudCosto.Value = actividadActual.Costo;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnPrimero_Click(object sender, EventArgs e)
        {
            actividadActual = db.Actividades.ToList().FirstOrDefault();
            CargarDatosActividad();
            HabilitarDeshabilitarBotones();

        }

        private void BtnUltimo_Click(object sender, EventArgs e)
        {
            
            actividadActual = db.Actividades.ToList().LastOrDefault();
            CargarDatosActividad();
            HabilitarDeshabilitarBotones();

        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            actividadActual = db.Actividades.Where(x => x.Id > actividadActual.Id).FirstOrDefault();
            CargarDatosActividad();
            HabilitarDeshabilitarBotones();

        }

        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            actividadActual = db.Actividades.Where(x => x.Id < actividadActual.Id).ToList().LastOrDefault();
            CargarDatosActividad();
            HabilitarDeshabilitarBotones();
        }

        private void HabilitarDeshabilitarBotones()
        {
            BtnPrimero.Enabled = EstadoBtnPrimero();
            BtnUltimo.Enabled = EstadoBtnUltimo();
            BtnSiguiente.Enabled = EstadoBtnSiguiente();
            BtnAnterior.Enabled = EstadoBtnAnterior();
        }

        private bool EstadoBtnAnterior()
        {
            //evalua si existen actividades anteriores a la actual,
            //preguntando con el método where si existen actividades con un 
            //id menor al de la actividad actual
            return db.Actividades.Where(x => x.Id < actividadActual.Id).Count() > 0;
        }

        private bool EstadoBtnSiguiente()
        {
            //evalua si existen actividades posteriores a la actual,
            //preguntando con el método where si existen actividades con un 
            //id mayor al de la actividad actual
            return db.Actividades.Where(x=>x.Id>actividadActual.Id).Count()>0;
        }

        private bool EstadoBtnUltimo()
        {
            //obtenemos la última actividad y la comparamos con la actual
            //si son distintas el botón debe encenderse
            var ultimaActividad = db.Actividades.ToList().LastOrDefault();
            return actividadActual.Id != ultimaActividad.Id;
        }

        private bool EstadoBtnPrimero()
        {
            //obtenemos la primera actividad y la comparamos con la actual
            //si son distintas el botón de primero debe encenderse 
            var primeraActividad = db.Actividades.ToList().FirstOrDefault();
            return actividadActual.Id!= primeraActividad.Id;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            //preguntamos al usuario si está seguro que quiere borrar
            DialogResult respuesta = MessageBox.Show($"¿Deseas eliminar la actividad {actividadActual.Nombre}?", "Eliminar actividad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //si contestó que si, borramos la actividad
            if (respuesta == DialogResult.Yes)
            {
                //borramos la actividad
                db.Actividades.Remove(actividadActual);
                //guardamos los cambios
                db.SaveChanges();
                //actualizamos la pantalla
                if (BtnSiguiente.Enabled)
                    BtnSiguiente.PerformClick();
                else
                    BtnAnterior.PerformClick();
            }
        }

        private void BtnNueva_Click(object sender, EventArgs e)
        {
            if (BtnNueva.Text == "&Nueva")
            {
                actividadActual = new Actividad();
                CargarDatosActividad();
                ModoEdicion(true);
            }
            else
            {
                actividadActual.Nombre = TxtNombre.Text;
                actividadActual.Horarios = txtHorarios.Text;
                actividadActual.Costo = nudCosto.Value;
                if (actividadActual.Id == 0)
                    db.Actividades.Add(actividadActual);
                else
                    db.Entry(actividadActual).State=EntityState.Modified;
                db.SaveChanges();
                ModoEdicion(false);
                HabilitarDeshabilitarBotones();
            }
        }

        private void ModoEdicion(bool valor)
        {
            TxtNombre.Enabled=valor;
            txtHorarios.Enabled = valor;
            nudCosto.Enabled = valor;
            BtnPrimero.Enabled = !valor;
            BtnUltimo.Enabled = !valor;
            BtnSiguiente.Enabled = !valor;
            BtnAnterior.Enabled = !valor;
            BtnBuscar.Enabled = !valor;
            BtnEliminar.Enabled = !valor;
            BtnNueva.Text = valor ? "&Guardar" : "&Nueva";
            BtnModificar.Text = valor ? "&Cancelar" : "&Modificar";
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (BtnModificar.Text == "&Modificar")
                ModoEdicion(true);
            else
                ModoEdicion(false);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            var frmBuscarActividades = new FrmBuscarActividades();
            frmBuscarActividades.ShowDialog();
            actividadActual = db.Actividades.Find(frmBuscarActividades.idActividadSeleccionada);
            CargarDatosActividad();
        }
    }
}
