#region Using

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.IO;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms;

using ModelEF6;
using SPF.Forms.Base;
using SPF.Types;
using SPF.Forms;
using SPF.Base;
using Microsoft.Reporting.WebForms;

#endregion

namespace SPF.Forms.UI.Reportes
{
    public partial class FRepExportacionStarsoft : Form
    {
        #region Variables
        BerkeDBEntities DBContext;
        #endregion Variables

        #region Constantes
        private const int FE_SERIE1_TIMBRADOID = 24;
        private const string FE_SERIE1_DESCRIP = "Serie 1";
        private const int FE_SERIE2_TIMBRADOID = 25;
        private const string FE_SERIE2_DESCRIP = "Serie 2";
        #endregion Constantes

        public FRepExportacionStarsoft()
        {
            InitializeComponent();
        }

        public FRepExportacionStarsoft(string titulo, BerkeDBEntities context)
        {
            InitializeComponent();
            this.Text = "Listado Exportación - Starsoft";
            this.DBContext = context;

            #region DateTime Pickers
            this.dtpFechaDesde.Format = DateTimePickerFormat.Short;
            this.dtpFechaHasta.Format = DateTimePickerFormat.Short;
            #endregion DateTime Pickers

            this.chkIncluirAnulados.Checked = true;

            this.cargarCBFESerie();
            this.SetFirstAndLastDayofMonth();
        }

        private void SetFirstAndLastDayofMonth()
        {
            DateTime hoy = DateTime.Now;

            //Primer día del siguiente mes
            DateTime primerDiaMes = new DateTime(hoy.Year, hoy.Month, 1);
            DateTime ultimoDiaMes = (new DateTime(hoy.Year, hoy.AddMonths(1).Month, 1)).AddDays(-1);

            dtpFechaDesde.Value = primerDiaMes;
            dtpFechaHasta.Value = ultimoDiaMes;
        }

        private void cargarCBFESerie()
        {
            List<FESerie> series = new List<FESerie>();
            series.Add(new FESerie { TimbradoID  = FE_SERIE1_TIMBRADOID, Serie = FE_SERIE1_DESCRIP });
            series.Add(new FESerie { TimbradoID = FE_SERIE2_TIMBRADOID, Serie = FE_SERIE2_DESCRIP });

            this.cbFESerie.DataSource = series;
            this.cbFESerie.ValueMember = "TimbradoID";
            this.cbFESerie.DisplayMember = "Serie";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if ((this.dtpFechaDesde.Value == null) || (this.dtpFechaHasta.Value == null))
            {
                MessageBox.Show("Debe especificar fecha desde y fecha hasta.",
                                "Atención Requerida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }

            if (this.dtpFechaDesde.Value > this.dtpFechaHasta.Value)
            {
                MessageBox.Show("La Fecha Fin debe ser mayor o igual a la Fecha Inicio.",
                                "Atención Requerida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }

            if ((int)this.cbFESerie.SelectedValue == FE_SERIE2_TIMBRADOID)
                this.GenerarSerie2();
            else this.GenerarSerie1();
            //{
            //    MessageBox.Show("El reporte para Serie 1 no ha sido implementado aún.",
            //                    "Atención Requerida",
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Exclamation);
            //    return;
            //}
            
        }

        private void GenerarSerie2()
        {
            List<ReporteExportacionStarsoftSerie2> reportDS = new List<ReporteExportacionStarsoftSerie2>();

            try
            {
                reportDS = this.DBContext.GetReporteExportacionStarsoftSerie2(this.dtpFechaDesde.Value,
                                                                    this.dtpFechaHasta.Value,
                                                                    (int)this.cbFESerie.SelectedValue,
                                                                    this.chkIncluirAnulados.Checked).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al generar el reporte: " + Environment.NewLine + ex.Message, "Información de Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (reportDS.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte con los criterios ingresados.",
                                "Atención Requerida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            ReportDataSource datasource = null;
            datasource = new ReportDataSource("DataSet1", reportDS);

            string path = @"Reportes\ReporteImportacionStarsoftSerie2.rdlc";
            FReportViewerBase f = new FReportViewerBase(path, datasource, this.DBContext);
            f.SoloExportarExcel(true);
            f.SoloImpresion(true);
            f.FormClosed += delegate { f = null; };
            f.Titulo = "Listado Exportación - Starsoft: Del " + this.dtpFechaDesde.Value.ToShortDateString() + " al " + this.dtpFechaHasta.Value.ToShortDateString();
            f.CantidadRegistros = "Registros encontrados: " + reportDS.Count.ToString();
            f.NombreArchivoAdjunto = "ListadoExportacionSerie2-Starsoft" + DateTime.Now.Ticks;
            f.AsuntoMail = f.Titulo;
            f.ShowDialog();
        }

        private void GenerarSerie1()
        {
            List<ReporteExportacionStarsoftSerie1> reportDS = new List<ReporteExportacionStarsoftSerie1>();

            try
            {
                reportDS = this.DBContext.GetReporteExportacionStarsoftSerie1(this.dtpFechaDesde.Value,
                                                                    this.dtpFechaHasta.Value,
                                                                    (int)this.cbFESerie.SelectedValue,
                                                                    this.chkIncluirAnulados.Checked).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al generar el reporte: " + Environment.NewLine + ex.Message, "Información de Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (reportDS.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte con los criterios ingresados.",
                                "Atención Requerida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            ReportDataSource datasource = null;
            datasource = new ReportDataSource("DataSet1", reportDS);

            string path = @"Reportes\ReporteImportacionStarsoftSerie1.rdlc";
            FReportViewerBase f = new FReportViewerBase(path, datasource, this.DBContext);
            f.SoloExportarExcel(true);
            f.SoloImpresion(true);
            f.FormClosed += delegate { f = null; };
            f.Titulo = "Listado Exportación - Starsoft: Del " + this.dtpFechaDesde.Value.ToShortDateString() + " al " + this.dtpFechaHasta.Value.ToShortDateString();
            f.CantidadRegistros = "Registros encontrados: " + reportDS.Count.ToString();
            f.NombreArchivoAdjunto = "ListadoExportacionSerie1-Starsoft" + DateTime.Now.Ticks;
            f.AsuntoMail = f.Titulo;
            f.ShowDialog();
        }
    }
}