using ClubCosmopolita.Data;
using ClubCosmopolita.Modelos;
using ClubCosmopolita.Utils;
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
    public partial class FrmLogin : Form
    {
        int intentosfallidos = 0;
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            //instanciamos la clase dbcontext(contexto de base de datos)
            using var db = new CosmopolitaContext();
            //almacenamos en la variable user lo escrito en el cuadro
            //de texto txtUsuario
            var user = txtUsuario.Text;
            //almacenamos en la variable pass el hash 256 de la
            //contraseña escrita
            var pass = Helper.ObtenerHashSha256(txtContraseña.Text);
            //utilizamos la clase db para buscar un usuario que tenga el
            //user y pass igual a los ingresados
            var usuarioLogueado = db.Usuarios.Where(u => u.User == user &&
                                                    u.Password == pass)
                                                    .FirstOrDefault();
            if(usuarioLogueado == null)//logín fallido
            {
                intentosfallidos++;
                if (intentosfallidos == 3)
                    this.Close();
                MessageBox.Show("Error, usuario o contraseña inválida");
                txtUsuario.Text = "";
                txtContraseña.Text = "";
                txtUsuario.Focus();
            }
            else//login válido
            {
                //guardamos el usuario que se logeo en la propiedad UsuarioLogueado
                //del FrmMenuPrincipal
                FrmMenuPrincipal.UsuarioLogueado = usuarioLogueado;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
