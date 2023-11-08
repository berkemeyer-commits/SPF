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
    public partial class FRepLibroBanco : Form
    {
        #region Variables
        frmPickBase fPickCuenta;
        BerkeDBEntities DBContext;
        #endregion Variables

        #region Constantes
        private const int IDIOMA_ESPANOL = 2;
        #endregion Constantes

        public FRepLibroBanco()
        {
            InitializeComponent();
        }

        public FRepLibroBanco(string titulo, BerkeDBEntities context)
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
            this.tSBCuenta.KeyMemberWidth = 70;
            this.tSBCuenta.ToolTip = "Elegir Cuenta de Depósito";
            this.tSBCuenta.AceptarClick += tSBCuenta_AceptarClick;
            #endregion TextSearchBoxes
        }

        #region Picks
        private void tSBCuenta_AceptarClick(object sender, EventArgs e)
        {
            if (fPickCuenta == null)
            {
                fPickCuenta = new frmPickBase();
                fPickCuenta.AceptarFiltrarClick += fPickCuenta_AceptarFiltrarClick;
                fPickCuenta.FiltrarClick += fPickCuenta_FiltrarClick;
                fPickCuenta.Titulo = "Elegir Cuenta ";
                fPickCuenta.CampoIDNombre = "cb_cuentabancoid";
                fPickCuenta.CampoDescripNombre = "cb_descripcion";
                fPickCuenta.LabelCampoID = "ID";
                fPickCuenta.LabelCampoDescrip = "Descripción";
                fPickCuenta.NombreCampo = "Cuenta";
                fPickCuenta.PermitirFiltroNulo = true;
            }
            fPickCuenta.MostrarFiltro();
            //this.fPickCuenta_FiltrarClick(sender, e);
        }

        private void fPickCuenta_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickCuenta != null)
            {
                fPickCuenta.LoadData<cb_cuentabanco>(this.DBContext.cb_cuentabanco, fPickCuenta.GetWhereString());
            }
        }

        private void fPickCuenta_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBCuenta.DisplayMember = fPickCuenta.ValorDescrip;
            this.tSBCuenta.KeyMember = fPickCuenta.ValorID;

            fPickCuenta.Close();
            fPickCuenta.Dispose();

            int cuentaID = Convert.ToInt32(this.tSBCuenta.KeyMember);

            var query = (from cb in this.DBContext.cb_cuentabanco
                         join ba in this.DBContext.ba_banco
                             on cb.cb_bancoid equals ba.ba_bancoid
                         join mon in this.DBContext.Moneda
                             on cb.cb_monedaid equals mon.ID
                         select new
                         {
                             CuentaID = cb.cb_cuentabancoid,
                             NroCuenta = cb.cb_nrocuenta,
                             BancoNombre = ba.ba_descripcion,
                             MonedaAbrev = mon.AbrevMoneda
                         })
                        .Where(a => a.CuentaID == cuentaID).ToList();

            this.txtMoneda.Text = query.First().MonedaAbrev;
            this.txtNroCuenta.Text = query.First().NroCuenta;
            this.txtBanco.Text = query.First().BancoNombre;
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
            //if (this.tSBCliente.KeyMember == "")
            //{
            //    MessageBox.Show("Debe especificar un cliente obligatoriamente.",
            //                            "Atención Requerida",
            //                            MessageBoxButtons.OK,
            //                            MessageBoxIcon.Exclamation);
            //    return;
            //}

            if (((this.txtFechaDesde.Text == "") && (this.txtFechaHasta.Text != "")) ||
               ((this.txtFechaDesde.Text != "") && (this.txtFechaHasta.Text == "")))
            {
                MessageBox.Show("Debe especificar fecha desde y fecha hasta.",
                                        "Atención Requerida",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                return;

            }

            Nullable<int> CuentaID = null;
            if (this.tSBCuenta.KeyMember != String.Empty)
                CuentaID = Convert.ToInt32(this.tSBCuenta.KeyMember);

            List<GetLibroBanco_Result> reportDS = new List<GetLibroBanco_Result>();

            try
            {
                reportDS = this.DBContext.GetLibroBanco(CuentaID, this.txtFechaDesde.Text, this.txtFechaHasta.Text).ToList();
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

            string path = @"Reportes\RepLibroBanco.rdlc";
            string asuntoMail = "Reporte de Libro de Bancos";
            string cuerpoMail = "Por favor revise el documento adjunto.";
            string nombreArchivo = "RepLibroBanco";

            FReportViewerBase f = new FReportViewerBase(path, datasource, this.DBContext);
            f.FormClosed += delegate { f = null; };
            f.Titulo = String.Format("Reporte de Libro de Bancos - Del {0} al {1}", this.txtFechaDesde.Text, this.txtFechaHasta.Text);
            f.NombreArchivoAdjunto = nombreArchivo;
            f.AsuntoMail = asuntoMail + " - " + String.Format("Reporte de Libro de Bancos - Del {0} al {1}", this.txtFechaDesde.Text, this.txtFechaHasta.Text);
            f.CuerpoMail = cuerpoMail;
            f.ShowDialog();
        }

        
        private void dtpFecBolDep_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}