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
    public partial class FRepListadoGeneralPagos : Form
    {
        #region Variables
        frmPickBase fPickCliente;
        BerkeDBEntities DBContext;
        #endregion Variables

        public FRepListadoGeneralPagos()
        {
            InitializeComponent();
        }

        public FRepListadoGeneralPagos(string titulo, BerkeDBEntities context)
        {
            InitializeComponent();
            this.Text = titulo;
            this.DBContext = context;

            #region DateTime Pickers
            this.dtpFechaDesde.Format = DateTimePickerFormat.Short;
            this.dtpFechaHasta.Format = DateTimePickerFormat.Short;

            //this.txtFechaDesde.Text = System.DateTime.Now.Date.ToShortDateString();
            //this.txtFechaHasta.Text = System.DateTime.Now.Date.ToShortDateString();
            #endregion DateTime Pickers

        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaDesde.Text = this.dtpFechaDesde.Value.ToShortDateString();
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaHasta.Text = this.dtpFechaHasta.Value.ToShortDateString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (((this.txtFechaDesde.Text == "") && (this.txtFechaHasta.Text != "")) ||
               ((this.txtFechaDesde.Text != "")&& (this.txtFechaHasta.Text == "")))
            {
                MessageBox.Show("Debe especificar fecha desde y fecha hasta.",
                                        "Atención Requerida",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                return;

            }


            List<GetListadoGeneralPagos_Result> reportDS = new List<GetListadoGeneralPagos_Result>();

            try
            {
                reportDS = this.DBContext.GetListadoGeneralPagos(this.txtFechaDesde.Text,
                                                                 this.txtFechaHasta.Text).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al generar el reporte: " + Environment.NewLine + ex.Message, "Información de Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
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

            string path = @"Reportes\RepListadoGeneralPagos.rdlc";
            
            FReportViewerBase f = new FReportViewerBase(path, datasource, this.DBContext);
            f.FormClosed += delegate { f = null; };
            f.Titulo = String.Format("Listado General de Pagos - Del {0} al {1}", this.txtFechaDesde.Text, this.txtFechaHasta.Text);
            f.NombreArchivoAdjunto = "RepListadoGralPagos-" + DateTime.Now.Ticks;
            f.AsuntoMail = String.Format("Listado General de Pagos - Del {0} al {1}", this.txtFechaDesde.Text, this.txtFechaHasta.Text);
            f.CantidadRegistros = String.Format("Filas recuperadas: {0}", reportDS.Count.ToString());
            f.ShowDialog();
        }
    }
}