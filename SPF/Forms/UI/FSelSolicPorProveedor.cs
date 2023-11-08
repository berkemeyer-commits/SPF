#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using ModelEF6;
using SPF.Forms;
using SPF.Forms.Base;
using SPF.Types;
using System.Data.Entity;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Dynamic;

using System.Data.SqlClient;
using System.Collections;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text.RegularExpressions;

#endregion

namespace SPF.Forms.UI
{
    public partial class FSelSolicPorProveedor : Form
    {
        #region Variables
        BerkeDBEntities DBContext;
        private string listaPresupuestos = "";
        private frmPickBase fPickProveedor;
        private Boolean esRegExt = false;
        #endregion Variables

        #region Constantes
        private const string CAMPO_ID           = "Id";
        private const string CAMPO_INFORMACION  = "Informacion";
        private const string CAMPO_SALDO        = "Saldo";
        private const string CAMPO_IMPORTE      = "Importe";
        private const string CAMPO_EXTRA        = "Extra";
        private const string CAMPO_SELECCIONAR  = "Seleccionar";
                
        private const string FILTRO_PROVEEDOR   = "P";
        private const string VARIAS_FACTURAS    = "Varias Facturas";
        private const string FORMATO_DECIMAL_BROWSE = "{0:N2}";
        private string solicitudes = "";
        private string datosFacturas = "";
        private string informacion = "";
        private decimal saldo = 0;
        #endregion Constantes

        #region Eventos personalizados
        public event EventHandler AceptarClick;
        #endregion Eventos personalizados

        #region Propiedades
        public string ListaSolicitudes
        {
            set { this.solicitudes = value; }
            get { return this.solicitudes; }
        }

        public string Informacion
        {
            set { this.informacion = value; }
            get { return this.informacion; }
        }

        public string DatosFactura
        {
            set { this.datosFacturas = value; }
            get { return this.datosFacturas; }
        }

        public decimal Saldo
        {
            set { this.saldo = value; }
            get { return this.saldo; }
        }

        public Boolean EsRegExt
        {
            set { this.esRegExt = value; }
            get { return this.esRegExt; }
        }

        #endregion Propiedades

        #region Métodos de Inicio
        public FSelSolicPorProveedor()
        {
            InitializeComponent();
        }

        public FSelSolicPorProveedor(BerkeDBEntities context, string titulo, bool regExt = false)
        {
            InitializeComponent();
            this.EsRegExt = regExt;
            this.DBContext = context;
            this.Text = titulo;
            this.toolTip1.SetToolTip(this.txtFiltroFactura,
                                     "Filtrar por N° o Fecha de Factura, Ref. de la Solicitud");
            this.lblProvCorresp.Text = this.EsRegExt ? "Corresponsal" : "Proveedor";

            #region Inicializar TextSearchBoxes
            this.tSBProveedor.KeyMemberWidth = 70;
            this.tSBProveedor.ToolTip = "Elegir Proveedor";
            this.tSBProveedor.AceptarClick += tSBProveedor_AceptarClick;
            #endregion Inicializar TextSearchBoxes
        }

        #region Proveedor
        private void tSBProveedor_AceptarClick(object sender, EventArgs e)
        {
            if (fPickProveedor == null)
            {
                fPickProveedor = new frmPickBase();
                fPickProveedor.AceptarFiltrarClick += fPickProveedor_AceptarFiltrarClick;
                fPickProveedor.FiltrarClick += fPickProveedor_FiltrarClick;
                fPickProveedor.Titulo = this.EsRegExt ? "Elegir Corresponsal" : "Elegir Proveedor";
                fPickProveedor.CampoIDNombre = this.EsRegExt ? "ID" : "pr_proveedorid";
                fPickProveedor.CampoDescripNombre = this.EsRegExt ? "Nombre" : "pr_nombre";
                fPickProveedor.LabelCampoID = "ID";
                fPickProveedor.LabelCampoDescrip = "Nombre o Razón Social";
                fPickProveedor.NombreCampo = this.EsRegExt ? "Corresponsal" : "Proveedor";
                fPickProveedor.PermitirFiltroNulo = false;
            }
            fPickProveedor.MostrarFiltro();
        }

        private void fPickProveedor_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickProveedor != null)
            {
                if (!this.EsRegExt)
                    fPickProveedor.LoadData<pr_proveedor>(this.DBContext.pr_proveedor, fPickProveedor.GetWhereString());
                else
                    fPickProveedor.LoadData<Cliente>(this.DBContext.Cliente, fPickProveedor.GetWhereString());
            }
        }

        private void fPickProveedor_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBProveedor.DisplayMember = fPickProveedor.ValorDescrip;
            this.tSBProveedor.KeyMember = fPickProveedor.ValorID;

            fPickProveedor.Close();
            fPickProveedor.Dispose();

            this.CargarFacturas();
        }
        #endregion Proveedor

        private void FSelSolicPorProveedor_Load(object sender, EventArgs e)
        {
            if (this.dgvFacturas.RowCount == 0)
            {
                this.tSBProveedor_AceptarClick(sender, e);
            }
        }

        #endregion Métodos de Inicio

        #region Métodos Locales
        private void CargarFacturas()
        {
            string valorInt = this.tSBProveedor.KeyMember;
            string valorAlfa = this.txtFiltroFactura.Text;

            if (valorInt.Trim() == String.Empty)
            {
                MessageBox.Show("Debe elegir algún Proveedor.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            List<PagoProveedorFilterTypeSolicitud> lista = new List<PagoProveedorFilterTypeSolicitud>();

            if (this.EsRegExt)
            {
                lista = (from data in this.DBContext.GetDocumentoAPagarCorresponsal(FILTRO_PROVEEDOR,
                                                                                    valorInt,
                                                                                    valorAlfa)
                         select new PagoProveedorFilterTypeSolicitud
                         {
                             Id = data.Id,
                             Informacion = data.Informacion,
                             Saldo = data.Saldo,
                             Importe = data.Importe,
                             Extra = data.Extra
                         }).ToList();
            }
            else
            {
                lista = (from data in this.DBContext.GetDocumentoAPagar(FILTRO_PROVEEDOR,
                                                                        valorInt,
                                                                        valorAlfa)
                         select new PagoProveedorFilterTypeSolicitud
                         {
                             Id = data.Id,
                             Informacion = data.Informacion,
                             Saldo = data.Saldo,
                             Importe = data.Importe,
                             Extra = data.Extra
                         }).ToList();
            }

            this.dgvFacturas.DataSource = lista;
            this.lblEstado.Text = "Documentos recuperados: " + lista.Count.ToString();
            this.FormatearGrilla();

            if (this.dgvFacturas.RowCount > 0)
            {
                this.dgvFacturas.CurrentCell = this.dgvFacturas.Rows[0].Cells[0];
                this.dgvFacturas.CurrentCell.Selected = true;
                this.dgvFacturas.Focus();
            }
        }

        private void FormatearGrilla()
        {
            foreach (DataGridViewColumn col in this.dgvFacturas.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            this.dgvFacturas.ReadOnly = false;
            this.dgvFacturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvFacturas.ItemsPerPage = 13;
            this.dgvFacturas.ShowCellToolTips = true;
            this.dgvFacturas.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvFacturas.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvFacturas.DefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvFacturas.DefaultCellStyle.BackColor = Color.Transparent;

            this.dgvFacturas.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            
            int displayIndex = 0;

            this.dgvFacturas.Columns[CAMPO_ID].HeaderText = "Solic. Pago ID";
            this.dgvFacturas.Columns[CAMPO_ID].Width = 120;
            this.dgvFacturas.Columns[CAMPO_ID].DisplayIndex = displayIndex;
            this.dgvFacturas.Columns[CAMPO_ID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvFacturas.Columns[CAMPO_ID].Visible = true;
            displayIndex++;

            this.dgvFacturas.Columns[CAMPO_INFORMACION].HeaderText = "Información";
            this.dgvFacturas.Columns[CAMPO_INFORMACION].Width = 400;
            this.dgvFacturas.Columns[CAMPO_INFORMACION].DisplayIndex = displayIndex;
            this.dgvFacturas.Columns[CAMPO_INFORMACION].Visible = true;
            displayIndex++;

            this.dgvFacturas.Columns[CAMPO_IMPORTE].HeaderText = "Importe";
            this.dgvFacturas.Columns[CAMPO_IMPORTE].Width = 80;
            this.dgvFacturas.Columns[CAMPO_IMPORTE].DisplayIndex = displayIndex;
            this.dgvFacturas.Columns[CAMPO_IMPORTE].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvFacturas.Columns[CAMPO_IMPORTE].Visible = false;
            displayIndex++;

            this.dgvFacturas.Columns[CAMPO_SALDO].HeaderText = "Saldo";
            this.dgvFacturas.Columns[CAMPO_SALDO].Width = 80;
            this.dgvFacturas.Columns[CAMPO_SALDO].DisplayIndex = displayIndex;
            this.dgvFacturas.Columns[CAMPO_SALDO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvFacturas.Columns[CAMPO_SALDO].Visible = false;
            displayIndex++;

            this.dgvFacturas.Columns[CAMPO_EXTRA].HeaderText = "Extra";
            this.dgvFacturas.Columns[CAMPO_EXTRA].Width = 300;
            this.dgvFacturas.Columns[CAMPO_EXTRA].DisplayIndex = displayIndex;
            this.dgvFacturas.Columns[CAMPO_EXTRA].Visible = false;
            displayIndex++;

            DataGridViewCheckBoxColumn doWork = new DataGridViewCheckBoxColumn();
            doWork.HeaderText = CAMPO_SELECCIONAR;
            doWork.Name = CAMPO_SELECCIONAR;
            doWork.FalseValue = false;
            doWork.TrueValue = true;
            doWork.ReadOnly = false;
            doWork.Width = 80;
            this.dgvFacturas.Columns.Insert(0, doWork);
        }

        private void PrepararDatos()
        {
            int cantidadSeleccionados = 0;
            decimal sumSaldo = 0;

            string ProveedorID = "";
            string ProveedorNombre = "";
            string FecFactura = "";
            string NroFactura = "";
            string MonedaID = "";
            string MonedaDescrip = "";
            string MonedaAbrev = "";
            string Informacion = "";
            string SolicitudesID = "";

            string gMonedaID = "";

            foreach (DataGridViewRow row in this.dgvFacturas.Rows)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)this.dgvFacturas.Rows[row.Index].Cells[CAMPO_SELECCIONAR];
                if ((checkCell.Value != null) && ((bool)checkCell.Value))
                {
                    SolicitudesID += SolicitudesID != "" ? "," : "";
                    SolicitudesID += this.dgvFacturas.Rows[row.Index].Cells[CAMPO_ID].Value.ToString();
                    sumSaldo = sumSaldo + (decimal)this.dgvFacturas.Rows[row.Index].Cells[CAMPO_SALDO].Value;
                    Informacion = this.dgvFacturas.Rows[row.Index].Cells[CAMPO_INFORMACION].Value.ToString();
                    string[] datosFactura = this.dgvFacturas.Rows[row.Index].Cells[CAMPO_EXTRA].Value.ToString().Split('#');
                    ProveedorID = datosFactura[0];
                    ProveedorNombre = datosFactura[1];
                    FecFactura = datosFactura[2];
                    NroFactura = datosFactura[3];
                    MonedaID = datosFactura[4];
                    MonedaDescrip = datosFactura[5];
                    MonedaAbrev = datosFactura[6];

                    if (cantidadSeleccionados == 0)
                        gMonedaID = MonedaID;

                    cantidadSeleccionados++;

                    if (gMonedaID != MonedaID)
                    {
                        MessageBox.Show("No se pueden seleccionar facturas con distintas monedas.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                        return;
                    }
                }
            }

            if (cantidadSeleccionados > 1)
            {
                FecFactura = String.Empty;
                NroFactura = VARIAS_FACTURAS;
                Informacion = String.Format("{0} - {1} - {2} - {3}",
                                            VARIAS_FACTURAS, ProveedorNombre, MonedaAbrev, 
                                            String.Format(FORMATO_DECIMAL_BROWSE, (decimal)sumSaldo));
            }
            this.DatosFactura = String.Format("{0}#{1}#{2}#{3}#{4}#{5}",
                                                      ProveedorID, ProveedorNombre, FecFactura, NroFactura, MonedaID, MonedaDescrip);
            this.Saldo = sumSaldo;
            this.ListaSolicitudes = SolicitudesID;
            this.Informacion = Informacion;
        }
        #endregion Métodos Locales

        #region Controles Locales
        private void FSelSolicPorProveedor_VisibleChanged(object sender, EventArgs e)
        {
            if (this.dgvFacturas.RowCount > 0)
            {
                this.FormatearGrilla();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.AceptarClick != null)
            {
                this.PrepararDatos();
                this.AceptarClick(sender, e);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion Controles Locales

        private void btnFiltrar_Click_1(object sender, EventArgs e)
        {
            this.CargarFacturas();
        }
    }
}