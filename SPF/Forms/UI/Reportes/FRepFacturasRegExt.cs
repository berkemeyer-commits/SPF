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
    public partial class FRepFacturasRegExt : Form
    {
        #region Variables
        frmPickBase fPickCorresponsal;
        frmPickBase fPickMoneda;
        BerkeDBEntities DBContext;
        #endregion Variables

        #region Constantes
        private const int IDIOMA_ESPANOL = 2;
        #endregion Constantes

        public FRepFacturasRegExt()
        {
            InitializeComponent();
        }

        public FRepFacturasRegExt(string titulo, BerkeDBEntities context)
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
            this.tSBCorresponsal.KeyMemberWidth = 70;
            this.tSBCorresponsal.ToolTip = "Elegir Corresponsal";
            this.tSBCorresponsal.Editable = true;
            this.tSBCorresponsal.AceptarClick += tSBCorresponsal_AceptarClick;

            this.tSBMoneda.KeyMemberWidth = 70;
            this.tSBMoneda.ToolTip = "Elegir Moneda";
            this.tSBMoneda.Editable = true;
            this.tSBMoneda.AceptarClick += tSBMoneda_AceptarClick;
            #endregion TextSearchBoxes

            this.rbDetalladoCoef.Checked = true;
        }

        #region Picks
        #region Proveedor
        private void tSBCorresponsal_AceptarClick(object sender, EventArgs e)
        {
            if (fPickCorresponsal == null)
            {
                fPickCorresponsal = new frmPickBase();
                fPickCorresponsal.AceptarFiltrarClick += fPickCorresponsal_AceptarFiltrarClick;
                fPickCorresponsal.FiltrarClick += fPickCorresponsal_FiltrarClick;
                fPickCorresponsal.Titulo = "Elegir Corresponsal";
                fPickCorresponsal.CampoIDNombre = "ID";
                fPickCorresponsal.CampoDescripNombre = "Nombre";
                fPickCorresponsal.LabelCampoID = "ID";
                fPickCorresponsal.LabelCampoDescrip = "Nombre o Razón Social";
                fPickCorresponsal.NombreCampo = "Corresponsal";
                fPickCorresponsal.PermitirFiltroNulo = true;
            }
            fPickCorresponsal.MostrarFiltro();
            //this.fPickCorresponsal_FiltrarClick(sender, e);
        }

        private void fPickCorresponsal_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickCorresponsal != null)
            {
                fPickCorresponsal.LoadData<Cliente>(this.DBContext.Cliente, fPickCorresponsal.GetWhereString());
            }
        }

        private void fPickCorresponsal_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBCorresponsal.DisplayMember = fPickCorresponsal.ValorDescrip;
            this.tSBCorresponsal.KeyMember = fPickCorresponsal.ValorID;

            fPickCorresponsal.Close();
            fPickCorresponsal.Dispose();
        }
        #endregion Proveedor

        #region Moneda
        private void tSBMoneda_AceptarClick(object sender, EventArgs e)
        {
            if (fPickMoneda == null)
            {
                fPickMoneda = new frmPickBase();
                fPickMoneda.AceptarFiltrarClick += fPickMoneda_AceptarFiltrarClick;
                fPickMoneda.FiltrarClick += fPickMoneda_FiltrarClick;
                fPickMoneda.Titulo = "Elegir Moneda";
                fPickMoneda.CampoIDNombre = "ID";
                fPickMoneda.CampoDescripNombre = "Descripcion";
                fPickMoneda.LabelCampoID = "ID";
                fPickMoneda.LabelCampoDescrip = "Descripción";
                fPickMoneda.NombreCampo = "Moneda";
                fPickMoneda.PermitirFiltroNulo = true;
            }
            fPickMoneda.MostrarFiltro();
            this.fPickMoneda_FiltrarClick(sender, e);
        }

        private void fPickMoneda_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickMoneda != null)
            {
                fPickMoneda.LoadData<Moneda>(this.DBContext.Moneda, fPickMoneda.GetWhereString());
            }
        }

        private void fPickMoneda_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBMoneda.DisplayMember = fPickMoneda.ValorDescrip;
            this.tSBMoneda.KeyMember = fPickMoneda.ValorID;

            fPickMoneda.Close();
            fPickMoneda.Dispose();
        }
        #endregion Moneda
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
            string ProveedorID = null;
            if (this.tSBCorresponsal.KeyMember != String.Empty)
                ProveedorID = this.tSBCorresponsal.KeyMember;

            string MonedaID = null;
            if (this.tSBMoneda.KeyMember != String.Empty)
                MonedaID = this.tSBMoneda.KeyMember;

            if ((this.rbDetalladoCoef.Checked) || (this.rbDetalladoAvPago.Checked))
                this.GenDetallado(ProveedorID, this.txtFechaDesde.Text, this.txtFechaHasta.Text, MonedaID);
            else
                this.GenConsolidado(ProveedorID, this.txtFechaDesde.Text, this.txtFechaHasta.Text, MonedaID);

            //if (this.rbDetalladoCoef.Checked)
            //    this.GenDetallado(ProveedorID, this.txtFechaDesde.Text, this.txtFechaHasta.Text, MonedaID);
            //else if (this.rbConsolidado.Checked)
            //    this.GenConsolidado(ProveedorID, this.txtFechaDesde.Text, this.txtFechaHasta.Text, MonedaID);
            
        }


        private string GetErrorMsg(List<GetListaFacturasRegExt_Result> lista)
        {
            string Result = String.Empty;

            if (lista.Where(a => a.CoefUtilidad == -15001).Count() > 0)
            {
                Result = "Debe cargar las cotizaciones del día para poder generar este reporte.";
            }

            return Result;
        }

        private void GenDetallado(string ProveedorID, string FechaDesde, string FechaHasta, string MonedaID)
        {
            List<GetListaFacturasRegExt_Result> reportDS = new List<GetListaFacturasRegExt_Result>();

            try
            {
                reportDS = this.DBContext.GetListaFacturasRegExt(ProveedorID,
                                                                  FechaDesde,
                                                                  FechaHasta,
                                                                  MonedaID).ToList();

                string errMsg = this.GetErrorMsg(reportDS);

                if (errMsg != String.Empty)
                    throw new Exception(errMsg);
                
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

            string path = String.Empty;
            string asuntoMail = String.Empty;
            string cuerpoMail = String.Empty;
            string nombreArchivo = String.Empty;

            if (this.rbDetalladoCoef.Checked)
            {
                path = @"Reportes\RepFacturasRegExtDetCoef.rdlc";
                asuntoMail = "Listado Detallado de Facturas de Corresponsales con Coeficiente de Utilidad - {0}";
                cuerpoMail = "Por favor revise el documento adjunto.";
                nombreArchivo = "RepFacturasRegExtDetCoef";
            }
            else if (this.rbDetalladoAvPago.Checked)
            {
                path = @"Reportes\RepFacturasRegExtDetAvPago.rdlc";
                asuntoMail = "Listado Detallado de Facturas de Corresponsales indicando Av. de Pago - {0}";
                cuerpoMail = "Por favor revise el documento adjunto.";
                nombreArchivo = "RepFacturasRegExtDetAvPago";
            }
            //else if (this.rbConsolidado.Checked)
            //{
            //    path = @"Reportes\RepFacturasRegExtConsolidado.rdlc";
            //    asuntoMail = "Listado Consolidado de Facturas de Corresponsales - {0}";
            //    cuerpoMail = "Por favor revise el documento adjunto.";
            //    nombreArchivo = "RepFacturasRegExtConsolidado";
            //}

            FReportViewerBase f = new FReportViewerBase(path, datasource, this.DBContext);
            f.FormClosed += delegate { f = null; };
            f.Titulo = String.Format(asuntoMail, reportDS.First().Rango);
            f.NombreArchivoAdjunto = nombreArchivo;
            f.AsuntoMail = String.Format(asuntoMail, reportDS.First().Rango);
            f.CuerpoMail = cuerpoMail;
            f.ShowDialog();
        }

        private void GenConsolidado(string ProveedorID, string FechaDesde, string FechaHasta, string MonedaID)
        {
            List<GetListaFacturasRegExtConso_Result> reportDS = new List<GetListaFacturasRegExtConso_Result>();

            try
            {
                reportDS = this.DBContext.GetListaFacturasRegExtConso(ProveedorID,
                                                                  FechaDesde,
                                                                  FechaHasta,
                                                                  MonedaID).ToList();

                //string errMsg = this.GetErrorMsg(reportDS);

                //if (errMsg != String.Empty)
                //    throw new Exception(errMsg);

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

            string path = String.Empty;
            string asuntoMail = String.Empty;
            string cuerpoMail = String.Empty;
            string nombreArchivo = String.Empty;

            if (this.rbConsolidado.Checked)
            {
                path = @"Reportes\RepFacturasRegExtConsolidadov2.rdlc";
                asuntoMail = "Listado Consolidado de Facturas de Corresponsales - {0}";
                cuerpoMail = "Por favor revise el documento adjunto.";
                nombreArchivo = "RepFacturasRegExtConsolidado";
            }
            else if (this.rbConsolidadoConDeudas.Checked)
            {
                path = @"Reportes\RepFacturasRegExtConsolidadov2ConDeuda.rdlc";
                asuntoMail = "Listado Consolidado de Facturas de Corresponsales - Con detalle de Deudas a Berkemeyer {0}";
                cuerpoMail = "Por favor revise el documento adjunto.";
                nombreArchivo = "RepFacturasRegExtConsolidadov2ConDeuda";
            }
            

            FReportViewerBase f = new FReportViewerBase(path, datasource, this.DBContext);
            f.FormClosed += delegate { f = null; };
            f.Titulo = String.Format(asuntoMail, reportDS.First().Rango);
            f.NombreArchivoAdjunto = nombreArchivo;
            f.AsuntoMail = String.Format(asuntoMail, reportDS.First().Rango);
            f.CuerpoMail = cuerpoMail;
            f.ShowDialog();
        }

        private void dtpFechaDesde_Enter(object sender, EventArgs e)
        {
            if (this.txtFechaDesde.Text == String.Empty)
            {
                this.txtFechaDesde.Text = System.DateTime.Now.ToShortDateString();
            }
        }

        private void dtpFechaHasta_Enter(object sender, EventArgs e)
        {
            if (this.txtFechaHasta.Text == String.Empty)
            {
                this.txtFechaHasta.Text = System.DateTime.Now.ToShortDateString();
            }
        }

        private void FRepPagosPendientes_Load(object sender, EventArgs e)
        {
            this.tSBCorresponsal.SetFocus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDocument document = new PrintDocument();
            document.PrintPage += document_PrintPage;
            document.DocumentName = "Factura";
            
            PrintDialog printDialog1 = new PrintDialog();
            printDialog1.Document = document;

            document.Print();
            printDialog1.ShowDialog();
        }

        private void document_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(this.LeerFactura(), new Font("Arial", 10), Brushes.Black, 100, 10);
        }

        private string LeerFactura()
        {
            string str = String.Empty;
            string path = VWGContext.Current.Server.MapPath(@"\Resources\UserData\test.txt");
            using (StreamReader sr = new StreamReader(@path))
            {
                str = sr.ReadToEnd();
            }
            return str;
        }
    }
}