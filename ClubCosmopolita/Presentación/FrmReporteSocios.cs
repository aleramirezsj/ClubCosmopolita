using ClubCosmopolita.Data;
using Microsoft.Reporting.WinForms;
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
    public partial class FrmReporteSocios : Form
    {
        ReportViewer reporte = new ReportViewer();
        CosmopolitaContext db = new CosmopolitaContext();
        public FrmReporteSocios()
        {
            InitializeComponent();
            reporte.Dock = DockStyle.Fill;
            reporte.SetDisplayMode(DisplayMode.PrintLayout);
            Controls.Add(reporte);
        }

        private void FrmReporteSocios_Load(object sender, EventArgs e)
        {
            reporte.LocalReport.ReportEmbeddedResource = "ClubCosmopolita.Reportes.RptListadoSocios.rdlc";
            var socios = db.Socios.ToList();
            reporte.LocalReport.DataSources.Add(new ReportDataSource("DSSocios",socios));
            
            reporte.RefreshReport();
        }
    }
}
