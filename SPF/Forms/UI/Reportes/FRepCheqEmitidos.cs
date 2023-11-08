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
    public partial class FRepCheqEmitidos : Form
    {
        #region Variables
        frmPickBase fPickProveedor;
        frmPickBase fPickMoneda;
        frmPickBase fPickCuenta;
        BerkeDBEntities DBContext;
        #endregion Variables

        #region Constantes
        private const int IDIOMA_ESPANOL = 2;
        private const string CUENTA_WHERE = " ( EsCuentaPago == true ) {0} ";
        private const string AND_OPERATOR = "AND ( MonedaID = {0} )";
        #endregion Constantes

        public FRepCheqEmitidos()
        {
            InitializeComponent();
        }

        public FRepCheqEmitidos(string titulo, BerkeDBEntities context)
        {
            InitializeComponent();
            this.Text = titulo;
            this.DBContext = context;
            ((IObjectContextAdapter)this.DBContext).ObjectContext.CommandTimeout = 180;

            #region DateTime Pickers
            this.dtpFechaDesde.Format = DateTimePickerFormat.Short;
            this.dtpFechaHasta.Format = DateTimePickerFormat.Short;

            this.txtFechaDesde.Text = System.DateTime.Now.Date.ToShortDateString();
            this.txtFechaHasta.Text = System.DateTime.Now.Date.ToShortDateString();
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

            this.tSBCuenta.KeyMemberWidth = 70;
            this.tSBCuenta.ToolTip = "Elegir Cuenta de Depósito";
            this.tSBCuenta.AceptarClick += tSBCuenta_AceptarClick;
            #endregion TextSearchBoxes
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

        #region Cuenta
        private void tSBCuenta_AceptarClick(object sender, EventArgs e)
        {
            if (fPickCuenta == null)
            {
                fPickCuenta = new frmPickBase();
                fPickCuenta.AceptarFiltrarClick += fPickCuenta_AceptarFiltrarClick;
                fPickCuenta.FiltrarClick += fPickCuenta_FiltrarClick;
                fPickCuenta.Titulo = "Elegir Cuenta ";
                fPickCuenta.CampoIDNombre = "CuentaID";
                fPickCuenta.CampoDescripNombre = "CuentaDescripcion";
                fPickCuenta.LabelCampoID = "ID";
                fPickCuenta.LabelCampoDescrip = "Descripción";
                fPickCuenta.NombreCampo = "Cuenta";
                fPickCuenta.PermitirFiltroNulo = true;
            }
            fPickCuenta.MostrarFiltro();
            this.fPickCuenta_FiltrarClick(sender, e);
        }

        private void fPickCuenta_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickCuenta != null)
            {
                string where = String.Empty;
                string monedaID = String.Empty;
                if (this.tSBMoneda.KeyMember.Trim() != String.Empty)
                {
                    monedaID = this.tSBMoneda.KeyMember;
                }

                if (monedaID != String.Empty)
                    where = String.Format(CUENTA_WHERE, String.Format(AND_OPERATOR, monedaID));
                else
                    where = String.Format(CUENTA_WHERE, String.Empty);

                var query = (from cb in this.DBContext.cb_cuentabanco
                             select new CuentaType
                             {
                                 CuentaID = cb.cb_cuentabancoid,
                                 CuentaDescripcion = cb.cb_descripcion,
                                 BancoID = cb.cb_bancoid,
                                 MonedaID = cb.cb_monedaid,
                                 EsCuentaPago = cb.cb_escuentapago
                             }).Where(where);

                fPickCuenta.LoadData<CuentaType>(query.AsQueryable(), fPickCuenta.GetWhereString());
                //fPickCuenta.LoadData<cb_cuentabanco>(this.DBContext.cb_cuentabanco, fPickCuenta.GetWhereString());
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
        #endregion Cuenta
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

            if (((this.txtFechaDesde.Text != String.Empty) && (this.txtFechaHasta.Text == String.Empty)) ||
                ((this.txtFechaDesde.Text == String.Empty) && (this.txtFechaHasta.Text != String.Empty)))
            {
                MessageBox.Show("Debe especificar un rango de fechas válido.",
                                        "Atención Requerida",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                return;

            }

            string FechaDesde = null;
            if (this.txtFechaDesde.Text != String.Empty)
                FechaDesde = this.txtFechaDesde.Text;

            string FechaHasta = null;
            if (this.txtFechaHasta.Text != String.Empty)
                FechaHasta = this.txtFechaHasta.Text;
            
            string ProveedorID = null;
            if (this.tSBProveedor.KeyMember != String.Empty)
                ProveedorID =this.tSBProveedor.KeyMember;

            string MonedaID = null;
            if (this.tSBMoneda.KeyMember != String.Empty)
                MonedaID = this.tSBMoneda.KeyMember;

            string CuentaID = null;
            if (this.tSBCuenta.KeyMember != String.Empty)
                CuentaID = this.tSBCuenta.KeyMember;

            List<GetListadoChequesEmitidos_Result> reportDS = new List<GetListadoChequesEmitidos_Result>();

            try
            {
                reportDS = this.DBContext.GetListadoChequesEmitidos(ProveedorID,
                                                                    FechaDesde, FechaHasta,
                                                                    MonedaID, CuentaID).ToList();

                if (reportDS.Count == 0)
                {
                    throw new Exception("No existen datos para el reporte con los criterios ingresados.");
                }

                ReportDataSource datasource = null;
                datasource = new ReportDataSource("DataSet1", reportDS);

                string path = @"Reportes\RepChequesEmitidos.rdlc";
                string asuntoMail = "Listado de Cheques Emitidos";
                string cuerpoMail = "Por favor revise el documento adjunto.";
                string nombreArchivo = "ListChequesEmitidos";

                FReportViewerBase f = new FReportViewerBase(path, datasource, this.DBContext);
                f.FormClosed += delegate { f = null; };
                f.Titulo = String.Format("Listado de Cheques Emitidos - {0}", reportDS.First().Rango);
                f.NombreArchivoAdjunto = nombreArchivo;
                f.AsuntoMail = asuntoMail + " - " + String.Format("Listado de Cheques Emitidos - {0}", reportDS.First().Rango);
                f.CuerpoMail = cuerpoMail;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al generar el reporte: " + Environment.NewLine + ex.Message, "Información de Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

            //if (reportDS.Count == 0)
            //{
            //    MessageBox.Show("No existen datos para el reporte con los criterios ingresados.",
            //                    "Atención Requerida",
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Information);
            //    return;
            //}

            
        }

        private void FRepCheqEmitidos_Load(object sender, EventArgs e)
        {
            this.txtFechaDesde.Focus();
        }
    }
}