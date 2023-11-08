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
    public partial class FRepFacturas : Form
    {
        #region Variables
        frmPickBase fPickProveedor;
        frmPickBase fPickMoneda;
        BerkeDBEntities DBContext;
        #endregion Variables

        #region Constantes
        private const int IDIOMA_ESPANOL = 2;
        #endregion Constantes

        public FRepFacturas()
        {
            InitializeComponent();
        }

        public FRepFacturas(string titulo, BerkeDBEntities context)
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
            this.tSBProveedor.KeyMemberWidth = 70;
            this.tSBProveedor.ToolTip = "Elegir Proveedor";
            this.tSBProveedor.Editable = true;
            this.tSBProveedor.AceptarClick += tSBProveedor_AceptarClick;

            this.tSBMoneda.KeyMemberWidth = 70;
            this.tSBMoneda.ToolTip = "Elegir Moneda";
            this.tSBMoneda.Editable = true;
            this.tSBMoneda.AceptarClick += tSBMoneda_AceptarClick;
            #endregion TextSearchBoxes

            this.rbDetallado.Checked = true;
        }

        #region Picks
        #region Proveedor
        private void tSBProveedor_AceptarClick(object sender, EventArgs e)
        {
            if (fPickProveedor == null)
            {
                fPickProveedor = new frmPickBase();
                fPickProveedor.AceptarFiltrarClick += fPickProveedor_AceptarFiltrarClick;
                fPickProveedor.FiltrarClick += fPickProveedor_FiltrarClick;
                fPickProveedor.Titulo = "Elegir Proveedor";
                fPickProveedor.CampoIDNombre = "pr_proveedorid";
                fPickProveedor.CampoDescripNombre = "pr_nombre";
                fPickProveedor.LabelCampoID = "ID";
                fPickProveedor.LabelCampoDescrip = "Nombre o Razón Social";
                fPickProveedor.NombreCampo = "Proveedor";
                fPickProveedor.PermitirFiltroNulo = true;
            }
            fPickProveedor.MostrarFiltro();
            //this.fPickProveedor_FiltrarClick(sender, e);
        }

        private void fPickProveedor_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickProveedor != null)
            {
                fPickProveedor.LoadData<pr_proveedor>(this.DBContext.pr_proveedor, fPickProveedor.GetWhereString());
            }
        }

        private void fPickProveedor_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBProveedor.DisplayMember = fPickProveedor.ValorDescrip;
            this.tSBProveedor.KeyMember = fPickProveedor.ValorID;

            fPickProveedor.Close();
            fPickProveedor.Dispose();
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
            if (this.tSBProveedor.KeyMember != String.Empty)
                ProveedorID = this.tSBProveedor.KeyMember;

            string MonedaID = null;
            if (this.tSBMoneda.KeyMember != String.Empty)
                MonedaID = this.tSBMoneda.KeyMember;

            if (this.rbDetallado.Checked)
                this.GenDetallado(ProveedorID, this.txtFechaDesde.Text, this.txtFechaHasta.Text, MonedaID);
            else if (this.rbConsolidado.Checked)
                this.GenConsolidado(ProveedorID, this.txtFechaDesde.Text, this.txtFechaHasta.Text, MonedaID);
            else if (this.rbLista.Checked)
                this.GenLista(ProveedorID, this.txtFechaDesde.Text, this.txtFechaHasta.Text, MonedaID);
            else if (this.rbListadoPendientes.Checked)
                this.GenListaPendientes(ProveedorID, this.txtFechaDesde.Text, this.txtFechaHasta.Text, MonedaID);
            
        }

        private void GenDetallado(string ProveedorID, string FechaDesde, string FechaHasta, string MonedaID)
        {
            List<GetListaFacturas_Result> reportDS = new List<GetListaFacturas_Result>();

            try
            {
                reportDS = this.DBContext.GetListaFacturas(ProveedorID,
                                                                  FechaDesde,
                                                                  FechaHasta,
                                                                  MonedaID).ToList();
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

            string path = @"Reportes\RepFacturas.rdlc";
            string asuntoMail = "Reporte de Facturas de Proveedores - Detallado";
            string cuerpoMail = "Por favor revise el documento adjunto.";
            string nombreArchivo = "RepFacturasProvDetallado";

            FReportViewerBase f = new FReportViewerBase(path, datasource, this.DBContext);
            f.FormClosed += delegate { f = null; };
            f.Titulo = String.Format("Reporte de Facturas de Proveedores - Detallado - {0}", reportDS.First().Rango);
            f.NombreArchivoAdjunto = nombreArchivo;
            f.AsuntoMail = asuntoMail + " - " + String.Format("Reporte de Facturas de Proveedores - Detallado - {0}", reportDS.First().Rango);
            f.CuerpoMail = cuerpoMail;
            f.ShowDialog();
        }

        private void GenConsolidado(string ProveedorID, string FechaDesde, string FechaHasta, string MonedaID)
        {
            List<GetListaFacturasConso_Result> reportDS = new List<GetListaFacturasConso_Result>();

            try
            {
                reportDS = this.DBContext.GetListaFacturasConso(ProveedorID,
                                                                  FechaDesde,
                                                                  FechaHasta,
                                                                  MonedaID).ToList();
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

            string path = @"Reportes\RepFacturasConso.rdlc";
            string asuntoMail = "Reporte de Facturas de Proveedores - Consolidado";
            string cuerpoMail = "Por favor revise el documento adjunto.";
            string nombreArchivo = "RepFacturasProvConso";

            FReportViewerBase f = new FReportViewerBase(path, datasource, this.DBContext);
            f.FormClosed += delegate { f = null; };
            f.Titulo = String.Format("Reporte de Facturas de Proveedores - Consolidado - {0}", reportDS.First().Rango);
            f.NombreArchivoAdjunto = nombreArchivo;
            f.AsuntoMail = asuntoMail + " - " + String.Format("Reporte de Facturas de Proveedores - Consolidado - {0}", reportDS.First().Rango);
            f.CuerpoMail = cuerpoMail;
            f.ShowDialog();
        }

        private void GenLista(string ProveedorID, string FechaDesde, string FechaHasta, string MonedaID)
        {
            List<GetListaFacturas_Result> reportDS = new List<GetListaFacturas_Result>();

            try
            {
                reportDS = this.DBContext.GetListaFacturas(ProveedorID,
                                                                  FechaDesde,
                                                                  FechaHasta,
                                                                  MonedaID).ToList();
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

            string path = @"Reportes\RepFacturasLista.rdlc";
            string asuntoMail = "Reporte de Facturas de Proveedores - Listado Simple";
            string cuerpoMail = "Por favor revise el documento adjunto.";
            string nombreArchivo = "RepFacturasProvListadoSimple";

            FReportViewerBase f = new FReportViewerBase(path, datasource, this.DBContext);
            f.FormClosed += delegate { f = null; };
            f.Titulo = String.Format("Reporte de Facturas de Proveedores - Listado Simple - {0}", reportDS.First().Rango);
            f.NombreArchivoAdjunto = nombreArchivo;
            f.AsuntoMail = asuntoMail + " - " + String.Format("Reporte de Facturas de Proveedores - Listado Simple - {0}", reportDS.First().Rango);
            f.CuerpoMail = cuerpoMail;
            f.ShowDialog();
        }

        private void GenListaPendientes(string ProveedorID, string FechaDesde, string FechaHasta, string MonedaID)
        {
            List<GetListaFacturasProvPendientes_Result> reportDS = new List<GetListaFacturasProvPendientes_Result>();

            try
            {
                reportDS = this.DBContext.GetListaFacturasProvPendientes(ProveedorID,
                                                                  FechaDesde,
                                                                  FechaHasta,
                                                                  MonedaID).ToList();
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

            string path = @"Reportes\RepFacturasPendientesLista.rdlc";
            string asuntoMail = "Reporte de Facturas Pendientes de Proveedores - Listado Simple";
            string cuerpoMail = "Por favor revise el documento adjunto.";
            string nombreArchivo = "RepFacturasPendientesProvListadoSimple";

            FReportViewerBase f = new FReportViewerBase(path, datasource, this.DBContext);
            f.FormClosed += delegate { f = null; };
            f.Titulo = String.Format("Reporte de Facturas Pendientes de Proveedores - Listado Simple - {0}", reportDS.First().Rango);
            f.NombreArchivoAdjunto = nombreArchivo;
            f.AsuntoMail = asuntoMail + " - " + String.Format("Reporte de Facturas Pendientes de Proveedores - Listado Simple - {0}", reportDS.First().Rango);
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
            this.tSBProveedor.SetFocus();
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