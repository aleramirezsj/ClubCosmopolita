using ClubCosmopolita.Presentación;

namespace ClubCosmopolita
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
            CboModoOscuroClaro.SelectedIndex = 0;
        }

        private void salirDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var texto = "Hecho por: Tomás Benitez";
            texto += Environment.NewLine;
            texto += "Materia: Programación 1";
            texto += Environment.NewLine;
            texto += "Carrera: TSD Software";
            var titulo = "Acerca de...";
            MessageBox.Show(texto, titulo);
        }

        private void acercaDeSistemaClubSocialCosmopolitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAcercaDe frmAcercaDe = new FrmAcercaDe();
            frmAcercaDe.ShowDialog();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAcercaDe_Click(object sender, EventArgs e)
        {
            acercaDeSistemaClubSocialCosmopolitaToolStripMenuItem_Click(sender,e);
        }

        private void ocultarEtiquetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BtnAcercaDe.DisplayStyle = ToolStripItemDisplayStyle.Image;
            BtnOpciones.DisplayStyle = ToolStripItemDisplayStyle.Image;
            BtnSalir.DisplayStyle = ToolStripItemDisplayStyle.Image;
        }

        private void mostrarEtiquetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BtnAcercaDe.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            BtnOpciones.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            BtnSalir.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
        }

        private void mostrarEtiquetasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mostrarEtiquetasToolStripMenuItem_Click(sender, e);
        }

        private void ocultarEtiquetasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ocultarEtiquetasToolStripMenuItem_Click(sender, e);
        }

        private void CboModoOscuroClaro_SelectedIndexChanged(object sender, EventArgs e)
        {
            //modo claro
            if(CboModoOscuroClaro.SelectedIndex==0)
            {
                this.BackColor = SystemColors.Control;
                LblEstado.Text = "Modo claro";
                StsBarraDeEstado.BackColor = SystemColors.Control;
            }else//modo oscuro
            {
                this.BackColor=SystemColors.ControlDark;
                LblEstado.Text = "Modo oscuro";
                StsBarraDeEstado.BackColor = SystemColors.ControlDark;
            }
        }

        private void modoOsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CboModoOscuroClaro.SelectedIndex = 1;
        }

        private void curoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CboModoOscuroClaro.SelectedIndex = 0;
        }

        private void FrmMenuPrincipal_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                
                CmsMenuContextual.Show(MousePosition);
            }
        }

        private void nuevoCobradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmNuevoEditarCobrador = new FrmNuevoEditarCobrador();
            frmNuevoEditarCobrador.ShowDialog();
        }
    }
}