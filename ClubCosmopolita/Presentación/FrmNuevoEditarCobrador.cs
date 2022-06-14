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
    public partial class FrmNuevoEditarCobrador : Form
    {
        public FrmNuevoEditarCobrador()
        {
            InitializeComponent();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            //instanciamos el dbcontext
            var db = new CosmopolitaContext();
            //creamos un objeto del tipo cobrador
            var cobrador = new Cobrador();
            //cargamos los datos de la pantalla en el objeto cobrador
            cobrador.Apellido_Nombre=TxtNombre.Text;
            //agregamos el cobrador al dbcontext
            db.Cobradores.Add(cobrador);
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
