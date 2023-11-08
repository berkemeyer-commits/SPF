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
    public partial class FRepDetallePagoDocs : Form
    {
        #region Variables
        frmPickBase fPickCliente;
        BerkeDBEntities DBContext;
        #endregion Variables

        public FRepDetallePagoDocs()
        {
            InitializeComponent();
        }

        public FRepDetallePagoDocs(string titulo, BerkeDBEntities context)
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

            #region TextSearchBoxes
            this.tSBCliente.KeyMemberWidth = 70;
            this.tSBCliente.ToolTip = "Elegir Cliente";
            this.tSBCliente.AceptarClick += tSBCliente_AceptarClick;
            this.tSBCliente.Editable = true;
            this.tSBCliente.ToolTipTSB = "Cliente";
            #endregion TextSearchBoxes
        }

        #region Picks
        private void tSBCliente_AceptarClick(object sender, EventArgs e)
        {
            if (fPickCliente == null)
            {
                fPickCliente = new frmPickBase();
                fPickCliente.AceptarFiltrarClick += fPickCliente_AceptarFiltrarClick;
                fPickCliente.FiltrarClick += fPickCliente_FiltrarClick;
                fPickCliente.Titulo = "Elegir Cliente";
                fPickCliente.CampoIDNombre = "ID";
                fPickCliente.CampoDescripNombre = "Nombre";
                fPickCliente.LabelCampoID = "ID";
                fPickCliente.LabelCampoDescrip = "Nombre";
                fPickCliente.NombreCampo = "Cliente";
                fPickCliente.PermitirFiltroNulo = false;
                fPickCliente.MostrarFiltro();
            }
            else fPickCliente.MostrarFiltro(true); 
        }

        private void fPickCliente_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickCliente != null)
            {
                fPickCliente.LoadData<Cliente>(this.DBContext.Cliente, fPickCliente.GetWhereString());
            }
        }

        private void fPickCliente_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBCliente.DisplayMember = fPickCliente.ValorDescrip;
            this.tSBCliente.KeyMember = fPickCliente.ValorID;

            fPickCliente.Close();
            fPickCliente.Dispose();
        }
        #endregion Picks

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
            if (this.tSBCliente.KeyMember == "")
            {
                MessageBox.Show("Debe especificar un cliente obligatoriamente.",
                                        "Atención Requerida",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                return;
            }
            
            if (((this.txtFechaDesde.Text == "") && (this.txtFechaHasta.Text != "")) ||
               ((this.txtFechaDesde.Text != "")&& (this.txtFechaHasta.Text == "")))
            {
                MessageBox.Show("Debe especificar fecha desde y fecha hasta.",
                                        "Atención Requerida",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                return;

            }


            List<DetallePagosPorDocumento_Result> reportDS = new List<DetallePagosPorDocumento_Result>();

            try
            {
                reportDS = this.DBContext.DetallePagosPorDocumento(this.tSBCliente.KeyMember,
                                                                   this.txtFechaDesde.Text,
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
            this.tSBCliente.DisplayMember = reportDS.First().ClienteNombre;

            ReportDataSource datasource = null;
            datasource = new ReportDataSource("DataSet1", reportDS);

            string path = @"Reportes\RepListadoPagosPorDocumentos.rdlc";
            
            FReportViewerBase f = new FReportViewerBase(path, datasource, this.DBContext);
            f.FormClosed += delegate { f = null; };
            f.Titulo = "Detalle de Pagos de Documentos - " + this.tSBCliente.DisplayMember;
            f.NombreArchivoAdjunto = "RepDetallePagos-" + this.tSBCliente.KeyMember;
            f.AsuntoMail = "Reporte Detallado de Pagos de Documentos - " + this.tSBCliente.DisplayMember + " (" + this.tSBCliente.KeyMember + ")";
            f.ShowDialog();
        }
    }
}