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
    public partial class FRepFEEmitidas : Form
    {
        #region Variables
        BerkeDBEntities DBContext;
        #endregion Variables

        #region Constantes
        private const char FE = 'F';
        private const string FE_DESCRIP = "Factura Electrónica";
        private const char NCE = 'N';
        private const string NCE_DESCRIP = "Nota Crédito Electrónica";
        #endregion Constantes

        public FRepFEEmitidas()
        {
            InitializeComponent();
        }

        public FRepFEEmitidas(string titulo, BerkeDBEntities context)
        {
            InitializeComponent();
            this.Text = titulo;
            this.DBContext = context;

            #region DateTime Pickers
            this.dtpFechaDesde.Format = DateTimePickerFormat.Short;
            this.dtpFechaHasta.Format = DateTimePickerFormat.Short;
            #endregion DateTime Pickers

            this.cargarCBDE();
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

        private void cargarCBDE()
        {
            List<TipoDE> tipos = new List<TipoDE>();
            tipos.Add(new TipoDE { Tipo = FE, Descripcion = FE_DESCRIP });
            tipos.Add(new TipoDE { Tipo = NCE, Descripcion = NCE_DESCRIP });

            this.cbTipoDE.DataSource = tipos;
            this.cbTipoDE.ValueMember = "TIpo";
            this.cbTipoDE.DisplayMember = "Descripcion";
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

            if ((char)this.cbTipoDE.SelectedValue == FE)
                this.GenerarFE();
            else this.GenerarNCE();
            
        }

        private void GenerarFE()
        {
            List<ReporteFEEmitidos> reportDS = new List<ReporteFEEmitidos>();

            try
            {
                reportDS = this.DBContext.GetReporteFE(this.dtpFechaDesde.Value,
                                                       this.dtpFechaHasta.Value).ToList();
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

            string path = @"Reportes\ReporteFE_Emitidas.rdlc";
            FReportViewerBase f = new FReportViewerBase(path, datasource, this.DBContext);
            f.SoloExportarExcel(true);
            f.SoloImpresion(true);
            f.FormClosed += delegate { f = null; };
            f.Titulo = "Listado de FE Emitidas: Del " + this.dtpFechaDesde.Value.ToShortDateString() + " al " + this.dtpFechaHasta.Value.ToShortDateString();
            f.CantidadRegistros = "Registros encontrados: " + reportDS.Count.ToString();
            f.NombreArchivoAdjunto = "Listado-de-FE-Emitidas" + DateTime.Now.Ticks;
            f.AsuntoMail = f.Titulo;
            f.ShowDialog();
        }

        private void GenerarNCE()
        {
            List<ReporteNCEEmitidos> reportDS = new List<ReporteNCEEmitidos>();

            try
            {
                reportDS = this.DBContext.GetReporteNCE(this.dtpFechaDesde.Value,
                                                       this.dtpFechaHasta.Value).ToList();
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

            string path = @"Reportes\ReporteNCE_Emitidas.rdlc";
            FReportViewerBase f = new FReportViewerBase(path, datasource, this.DBContext);
            f.SoloExportarExcel(true);
            f.SoloImpresion(true);
            f.FormClosed += delegate { f = null; };
            f.Titulo = "Listado de NCE Emitidas: Del " + this.dtpFechaDesde.Value.ToShortDateString() + " al " + this.dtpFechaHasta.Value.ToShortDateString();
            f.CantidadRegistros = "Registros encontrados: " + reportDS.Count.ToString();
            f.NombreArchivoAdjunto = "Listado-de-NCE-Emitidas" + DateTime.Now.Ticks;
            f.AsuntoMail = f.Titulo;
            f.ShowDialog();
        }
    }
}