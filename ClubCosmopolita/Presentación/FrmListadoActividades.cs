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
    public partial class FrmListadoActividades : Form
    {
        CosmopolitaContext db = new CosmopolitaContext();
        ReportViewer reporte = new ReportViewer();
        public FrmListadoActividades()
        {
            InitializeComponent();
            reporte.Dock= DockStyle.Fill;
            reporte.SetDisplayMode(DisplayMode.PrintLayout);
            reporte.ZoomMode=ZoomMode.Percent;
            reporte.ZoomPercent = 100;
            Controls.Add(reporte);
        }

        private void FrmReporteActividades_Load(object sender, EventArgs e)
        {
            reporte.LocalReport.ReportEmbeddedResource = "ClubCosmopolita.Reportes.RptListadoActividades.rdlc";
            var actividades = db.Actividades.ToList();
            reporte.LocalReport.DataSources.Add(new ReportDataSource("DSActividades", actividades));
            reporte.RefreshReport();
        }
    }
}
