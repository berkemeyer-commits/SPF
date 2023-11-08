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
    public partial class FRepFacturasRegExtGanancia : Form
    {
        #region Variables
        frmPickBase fPickCorresponsal;
        frmPickBase fPickMoneda;
        BerkeDBEntities DBContext;
        #endregion Variables

        #region Constantes
        private const int IDIOMA_ESPANOL = 2;
        #endregion Constantes

        public FRepFacturasRegExtGanancia()
        {
            InitializeComponent();
        }

        public FRepFacturasRegExtGanancia(string titulo, BerkeDBEntities context)
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

            this.rbSinPago.Checked = true;
            this.txtObservacion.Text = "Para las facturas de Corresponsales \"SIN COSTO\" se tiene en cuenta la fecha de la factura.";
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

            if (this.rbConPago.Checked)
                this.GenConPago(ProveedorID, this.txtFechaDesde.Text, this.txtFechaHasta.Text, MonedaID);
            else if (this.rbSinPago.Checked)
                this.GenSinPago(ProveedorID, this.txtFechaDesde.Text, this.txtFechaHasta.Text, MonedaID);
            else if (this.rbSinPagosObligados.Checked)
                this.GenSinPagoConObligacion(ProveedorID, this.txtFechaDesde.Text, this.txtFechaHasta.Text, MonedaID);
            
        }

        private string GetErrorMsgConPago(List<GetListaFacturasRegExtParaGanancia_Result> lista)
        {
            string Result = String.Empty;

            if (lista.Where(a => a.CoefUtilidad == -15001).Count() > 0)
            {
                Result = "Debe cargar las cotizaciones del día para poder generar este reporte.";
            }

            return Result;
        }

        private void GenConPago(string ProveedorID, string FechaDesde, string FechaHasta, string MonedaID)
        {
            List<GetListaFacturasRegExtParaGanancia_Result> reportDS = new List<GetListaFacturasRegExtParaGanancia_Result>();

            try
            {
                reportDS = this.DBContext.GetListaFacturasRegExtParaGanancia(ProveedorID,
                                                                              FechaDesde,
                                                                              FechaHasta,
                                                                              MonedaID).ToList();

                string errMsg = this.GetErrorMsgConPago(reportDS);

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

            path = @"Reportes\RepFacturasRegExtDetConGanancia.rdlc";
            asuntoMail = "Listado Detallado de Facturas de Corresponsales con Margen Bruto - {0}";
            cuerpoMail = "Por favor revise el documento adjunto.";
            nombreArchivo = "RepFacturasRegExtDetConGanancia";

            FReportViewerBase f = new FReportViewerBase(path, datasource, this.DBContext);
            f.FormClosed += delegate { f = null; };
            f.Titulo = String.Format(asuntoMail, reportDS.First().Rango);
            f.NombreArchivoAdjunto = nombreArchivo;
            f.AsuntoMail = String.Format(asuntoMail, reportDS.First().Rango);
            f.CuerpoMail = cuerpoMail;
            f.ShowDialog();
        }

        private string GetErrorMsgSinPago(List<GetListaFacturasRegExtParaGananciaPrePago_Result> lista)
        {
            string Result = String.Empty;

            if (lista.Where(a => a.CoefUtilidad == -15001).Count() > 0)
            {
                Result = "Debe cargar las cotizaciones del día para poder generar este reporte.";
            }

            return Result;
        }

        private void GenSinPago(string ProveedorID, string FechaDesde, string FechaHasta, string MonedaID)
        {
            List<GetListaFacturasRegExtParaGananciaPrePago_Result> reportDS = new List<GetListaFacturasRegExtParaGananciaPrePago_Result>();

            try
            {
                reportDS = this.DBContext.GetListaFacturasRegExtParaGananciaPrePago(ProveedorID,
                                                                              FechaDesde,
                                                                              FechaHasta,
                                                                              MonedaID).ToList();

                string errMsg = this.GetErrorMsgSinPago(reportDS);

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

            path = @"Reportes\RepFacturasRegExtDetConGananciaSinPago.rdlc";
            asuntoMail = "Listado Detallado de Facturas de Corresponsales con Margen Bruto - Antes de Pagar - {0}";
            cuerpoMail = "Por favor revise el documento adjunto.";
            nombreArchivo = "RepFacturasRegExtDetConGananciaSinPago";

            FReportViewerBase f = new FReportViewerBase(path, datasource, this.DBContext);
            f.FormClosed += delegate { f = null; };
            f.Titulo = String.Format(asuntoMail, reportDS.First().Rango);
            f.NombreArchivoAdjunto = nombreArchivo;
            f.AsuntoMail = String.Format(asuntoMail, reportDS.First().Rango);
            f.CuerpoMail = cuerpoMail;
            f.ShowDialog();
        }

        private string GetErrorMsgSinPagoConObligacion(List<GetListaFacturasRegExtParaGananciaPrePagoObligado_Result> lista)
        {
            string Result = String.Empty;

            if (lista.Where(a => a.CoefUtilidad == -15001).Count() > 0)
            {
                Result = "Debe cargar las cotizaciones del día para poder generar este reporte.";
            }

            return Result;
        }

        private void GenSinPagoConObligacion(string ProveedorID, string FechaDesde, string FechaHasta, string MonedaID)
        {
            List<GetListaFacturasRegExtParaGananciaPrePagoObligado_Result> reportDS = new List<GetListaFacturasRegExtParaGananciaPrePagoObligado_Result>();

            try
            {
                reportDS = this.DBContext.GetListaFacturasRegExtParaGananciaPrePagoObligado (ProveedorID,
                                                                              FechaDesde,
                                                                              FechaHasta,
                                                                              MonedaID).ToList();

                string errMsg = this.GetErrorMsgSinPagoConObligacion(reportDS);

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

            path = @"Reportes\RepFacturasRegExtDetConGananciaSinPagoObligado.rdlc";
            asuntoMail = "Listado Detallado de Facturas de Corresponsales con Margen Bruto - Antes de Pagar (Con Obligación de Pago) - {0}";
            cuerpoMail = "Por favor revise el documento adjunto.";
            nombreArchivo = "RepFacturasRegExtDetConGananciaSinPagoObligado";

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
            this.rbSinPago.Checked = true;
            this.HandleLabelSinCosto();
            this.tSBCorresponsal.SetFocus();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    PrintDocument document = new PrintDocument();
        //    document.PrintPage += document_PrintPage;
        //    document.DocumentName = "Factura";
            
        //    PrintDialog printDialog1 = new PrintDialog();
        //    printDialog1.Document = document;

        //    document.Print();
        //    printDialog1.ShowDialog();
        //}

        //private void document_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //    e.Graphics.DrawString(this.LeerFactura(), new Font("Arial", 10), Brushes.Black, 100, 10);
        //}

        //private string LeerFactura()
        //{
        //    string str = String.Empty;
        //    string path = VWGContext.Current.Server.MapPath(@"\Resources\UserData\test.txt");
        //    using (StreamReader sr = new StreamReader(@path))
        //    {
        //        str = sr.ReadToEnd();
        //    }
        //    return str;
        //}

        private void rbConPago_CheckedChanged(object sender, EventArgs e)
        {
            this.HandleLabelSinCosto();
        }

        private void HandleLabelSinCosto()
        {
            this.txtObservacion.Visible = this.rbConPago.Checked;
        }

        private void rbSinPagosObligados_CheckedChanged(object sender, EventArgs e)
        {
            this.HandleLabelSinCosto();
        }

      

    }
}