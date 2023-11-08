#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using ModelEF6;
using SPF.Types;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.ObjectModel;
using System.Data.Objects.SqlClient;
using System.Data.Entity.Validation;

using SPF.Forms.Base;

#endregion

namespace SPF.Forms.UI
{
    public partial class FDetalleSolPago : Form
    {
        #region Constantes
        private const string CAMPO_SOLPAGOCABID = "SolPagoCabID";
        private const string CAMPO_SOLPAGODETID = "SolPagoDetID";
        private const string CAMPO_TARIFAID = "TarifaID";
        private const string CAMPO_TARIFADESCRIP = "TarifaDescrip";
        private const string CAMPO_CANTIDAD = "Cantidad";
        private const string CAMPO_TIPOUNIDDESC = "TipoUnidDescuento";
        private const string CAMPO_DESCUENTOMONTO = "DescuentoMonto";
        private const string CAMPO_DESCUENTOPORC = "DescuentoPorc";
        private const string CAMPO_TIPOUNIDIMP = "TipoUnidImp";
        private const string CAMPO_IMPUESTOMONTO = "ImpuestoMonto";
        private const string CAMPO_IMPUESTOPORC = "ImpuestoPorc";
        private const string CAMPO_PRECIOVENTA = "PrecioVenta";
        private const string CAMPO_PRECIOCOSTO = "PrecioCosto";
        private const string CAMPO_TOTAL = "Total";
        private const string CAMPO_RECARGONETO = "RecargoNeto";
        private const string CAMPO_TOTALCONRECARGO = "TotalConRecargo";
        private const string CAMPO_PROVEEDORID = "ProveedorID";
        private const string CAMPO_NOMBREPROVEEDOR = "NombreProveedor";
        private const string CAMPO_NROFACTURAPROV = "NroFacturaProv";
        private const string CAMPO_FECFACTURA = "FecFactura";
        private const string CAMPO_FACTURABLE = "Facturable";
        private const string CAMPO_REEMBOLSABLE = "Reembolsable";
        private const string CAMPO_SOLICITADOPORID = "SolicitadoPor";
        private const string CAMPO_SOLICITADOPORNOMBRE = "SolicitadoPorNombre";
        private const string CAMPO_CORRESPONDENCIAID = "CorrespondenciaID";
        private const string CAMPO_CORRESPONDENCIANRO = "CorrespondenciaNro";
        private const string CAMPO_CORRESPONDENCIAANIO = "CorrespondenciaAnio";
        private const string CAMPO_CORRESPONDENCIATEXTO = "CorrespondenciaTexto";
        private const string CAMPO_REFCORRESP = "RefCorresp";
        private const string CAMPO_FECHASOLDET = "FecSolicitudDet";
        private const string CAMPO_MONEDAID = "MonedaID";
        private const string CAMPO_SALDODET = "SaldoDet";
        private const string CAMPO_EXENTAS = "Exentas";
        private const string CAMPO_IVA5 = "IVA5";
        private const string CAMPO_IVA10 = "IVA10";
        private const string CAMPO_CANTIDADIVA5 = "CantidadIVA5";
        private const string CAMPO_CANTIDADIVA10 = "CantidadIVA10";
        private const string CAMPO_PRECUNITIVA5 = "PrecUnitIVA5";
        private const string CAMPO_PREUNITIVA10 = "PrecUnitIVA10";
        private const string CAMPO_TIPOFACTURAID = "TipoFacturaID";
        private const int DOLARES_AMERICANOS = 2;
        private const int TARIFA_GASTO = 2;
        private const string FORMATO_DECIMAL_BROWSE = "{0:N2}";
        private const string FORMATO_DECIMAL_EDIT = "{0:0.00}";
        private const string FORMATO_SIN_DECIMAL_BROWSE = "{0:N0}";
        private const string FORMATO_SIN_DECIMAL_EDIT = "{0:0}";
        private const decimal IVA5 = 5M;
        private const decimal IVA10 = 10M;
        private const decimal COEFICIENTE_IVA5 = 1.05M;
        private const decimal COEFICIENTE_IVA10 = 1.1M;
        private const string TOOLTIP_IMPORTE = "Ingrese el importe con IVA incluido";
        private const int MONEDA_GUARANIES = 3;
        private const string CERO_CON_DECIMALES = "0,00";
        private const string CERO_SIN_DECIMALES = "0";
        private const string UNO_CON_DECIMALES = "1,00";
        private const string UNO_SIN_DECIMALES = "1";
        private const string PROVEEDOR = "Proveedor";
        private const string CORRESPONSAL = "Corresponsal";
        #endregion Constantes

        #region Variables
        private BerkeDBEntities DBContext;
        private bool Editar = false;
        private int MonedaID = -1;
        private int SolPagoCabID = -1;
        private frmPickBase fPickTarifa;
        private frmPickBase fPickCliente;
        private frmPickBase fPickCorrespondencia;
        frmPickBase fPickUsuario;
        private bool seGuardo = false;
        private string formatBrowse = "";
        private string formatEdit = "";
        private bool pRegExt = false;
        
        #endregion Variables

        #region Propiedades
        public Boolean SeGuardo
        {
            get { return this.seGuardo; }
            //set { this.seGuardo = value; }
        }

        public Boolean RegExt
        {
            get { return this.pRegExt; }
            set { this.pRegExt = value; }
        }
        #endregion Propiedades

        #region Métodos de Inicio
        public FDetalleSolPago()
        {
            InitializeComponent();
        }

        public FDetalleSolPago(BerkeDBEntities context, DataGridViewRow row, MonedaInfo monedaInfo, int solpagocabid, bool editar = false, bool nuevo = false, bool regExt = false)
        {
            InitializeComponent();
            this.DBContext = context;
            this.Text = regExt ? "Solicitudes de Pago RegExt - Detalle" : "Solicitudes de Pago - Detalle";
            this.Editar = editar;
            this.MonedaID = monedaInfo.MonedadID;
            this.txtMonedaDescrip.Text = monedaInfo.MonedaDescrip;
            this.SolPagoCabID = solpagocabid;
            this.CargarTipoFactura();
            this.Editable(editar);
            this.RegExt = regExt;

            this.lblCorresProv.Text = this.RegExt ? CORRESPONSAL : PROVEEDOR;

            #region Manejar Botones
            this.btnCerrar.Visible = !editar;
            this.btnAceptar.Visible = editar;
            this.btnCancelar.Visible = editar;
            #endregion Manejar Botones

            if (this.MonedaID == MONEDA_GUARANIES)
            {
                this.formatBrowse = FORMATO_SIN_DECIMAL_BROWSE;
                this.formatEdit = FORMATO_SIN_DECIMAL_EDIT;
                this.chkRedondear.Visible = false;
            }
            else
            {
                this.formatBrowse = FORMATO_DECIMAL_BROWSE;
                this.formatEdit = FORMATO_DECIMAL_EDIT;
                this.chkRedondear.Visible = true;
            }

            if (!editar)
            {
                //this.CargarDetalleSolPago(row, FORMATO_DECIMAL_BROWSE);
                this.CargarDetalleSolPago(row, formatBrowse);
            }
            else
            {
                if (nuevo)
                    this.Nuevo();
                else
                {
                    
                    //this.CargarDetalleSolPago(row, FORMATO_DECIMAL_EDIT);
                    this.CargarDetalleSolPago(row, formatEdit);

                }

                this.cbTipoUnidadDescuentoHandler();
                this.cbTipoUnidadDescuentoHandler();

                #region Inicializar TextSearchBoxes
                this.tSBTarifa.KeyMemberWidth = 70;
                this.tSBTarifa.ToolTip = "Elegir Tarifa";
                this.tSBTarifa.AceptarClick += tSBTarifa_AceptarClick;

                this.tSBCliente.KeyMemberWidth = 70;
                this.tSBCliente.ToolTip = this.RegExt ? "Elegir Corresponsal" : "Elegir Proveedor";
                this.tSBCliente.AceptarClick += tSBCliente_AceptarClick;

                this.tSBCorrespondencia.KeyMemberWidth = 70;
                this.tSBCorrespondencia.ToolTip = "Elegir Correspondencia";
                this.tSBCorrespondencia.AceptarClick += tSBCorrespondencia_AceptarClick;

                this.tSBUsuario.KeyMemberWidth = 70;
                this.tSBUsuario.ToolTip = "Elegir Usuario que solicita el servicio";
                this.tSBUsuario.AceptarClick += tSBUsuario_AceptarClick;
                #endregion Inicializar TextSearchBoxes
            }
            
        }

        private void FDetalleSolPago_Load(object sender, EventArgs e)
        {
            if ((this.MonedaID == -1) && (this.Editar))
                throw new Exception("Error: No se ha definido una moneda para la solicitud");

            if (!this.Editar)
                this.btnCerrar.Focus();
            else
                seGuardo = false;

            this.toolTip1.SetToolTip(this.txtPUGrav5, TOOLTIP_IMPORTE);
            this.toolTip1.SetToolTip(this.txtTotalIVA5, TOOLTIP_IMPORTE);
            this.toolTip1.SetToolTip(this.txtPUGrav10, TOOLTIP_IMPORTE);
            this.toolTip1.SetToolTip(this.txtTotalIVA10, TOOLTIP_IMPORTE);
        }

        private void CargarTipoFactura()
        {
            List<CBTipoFactura> listaTipoFactura = new List<CBTipoFactura>();
            listaTipoFactura.Add(new CBTipoFactura { ID = -1, Descripcion = String.Empty });

            foreach (tf_tipofactura tp in this.DBContext.tf_tipofactura.ToList())
            {
                listaTipoFactura.Add(new CBTipoFactura { ID = tp.tf_tipofacturaid, Descripcion = tp.tf_descripcion });
            }

            this.cbTipoFactura.DataSource = listaTipoFactura.OrderBy(a => a.ID).ToList();
            this.cbTipoFactura.DisplayMember = "Descripcion";
            this.cbTipoFactura.ValueMember = "ID";
        }
        #endregion Métodos de Inicio

        #region Picks

        #region Tarifa
        private void tSBTarifa_AceptarClick(object sender, EventArgs e)
        {
            if (fPickTarifa == null)
            {
                fPickTarifa = new frmPickBase();
                fPickTarifa.AceptarFiltrarClick += fPickTarifa_AceptarFiltrarClick;
                fPickTarifa.FiltrarClick += fPickTarifa_FiltrarClick;
                fPickTarifa.Titulo = "Elegir Tarifa";
                fPickTarifa.CampoIDNombre = "TarifaID";
                fPickTarifa.CampoDescripNombre = "DescripcionTarifa";
                fPickTarifa.LabelCampoID = "ID";
                fPickTarifa.LabelCampoDescrip = "Descripción";
                fPickTarifa.NombreCampo = "Tarifa";
                fPickTarifa.PermitirFiltroNulo = true;
            }
            fPickTarifa.MostrarFiltro();
            this.fPickTarifa_FiltrarClick(sender, e);
        }

        private void fPickTarifa_FiltrarClick(object sender, EventArgs e)
        {
            var query = (from tarifas in this.DBContext.Tarifas
                         select new TarifasTypeSinTramite
                         {
                             TarifaID = tarifas.ID,
                             DescripcionTarifa = tarifas.Descripcion,
                             MonedaID = tarifas.MonedaID,
                             TipoTarifaID = tarifas.TipoTarifaID
                         })
                        .Where(a => a.MonedaID == this.MonedaID && a.TipoTarifaID == TARIFA_GASTO);//monedaid);


            if (fPickTarifa != null)
            {
                fPickTarifa.LoadData<TarifasTypeSinTramite>(query.AsQueryable(), fPickTarifa.GetWhereString());
                //fPickTarifa.LoadData<TarifasType>(query, fPickTarifa.GetWhereString());
            }
        }

        private void fPickTarifa_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBTarifa.DisplayMember = fPickTarifa.ValorDescrip;
            this.tSBTarifa.KeyMember = fPickTarifa.ValorID;

            fPickTarifa.Close();
            fPickTarifa.Dispose();

            if (this.tSBTarifa.KeyMember != "")
                this.GetTarifas(Convert.ToInt32(this.tSBTarifa.KeyMember));
        }
        #endregion Tarifa

        #region Correspondencia
        private void tSBCorrespondencia_AceptarClick(object sender, EventArgs e)
        {
            if (fPickCorrespondencia == null)
            {
                fPickCorrespondencia = new frmPickBase();
                fPickCorrespondencia.AceptarFiltrarClick += fPickCorrespondencia_AceptarFiltrarClick;
                fPickCorrespondencia.FiltrarClick += fPickCorrespondencia_FiltrarClick;
                fPickCorrespondencia.Titulo = "Elegir Correspondencia";
                fPickCorrespondencia.CampoIDNombre = "CorrespondenciaID";
                fPickCorrespondencia.CampoDescripNombre = "Descripcion";
                fPickCorrespondencia.LabelCampoID = "ID";
                fPickCorrespondencia.LabelCampoDescrip = "Referencia";
                fPickCorrespondencia.NombreCampo = "Corresp.";
                fPickCorrespondencia.PermitirFiltroNulo = false;
            }
            fPickCorrespondencia.MostrarFiltro();
            //this.fPickCorrespondencia_FiltrarClick(sender, e);
        }

        private void fPickCorrespondencia_FiltrarClick(object sender, EventArgs e)
        {
            var query = (from corresp in this.DBContext.Correspondencia
                         select new CorrespondenciaFilterType
                         {
                             CorrespondenciaID = corresp.ID,
                             CorrespondenciaNro = corresp.Nro,
                             CorrespondenciaAnio = corresp.Anio,
                             RefCorresp = corresp.RefCorresp
                         });

            List<CorrespondenciaFilterType> lista = (List<CorrespondenciaFilterType>)query
                                                    .ToList();
            

            if (fPickCorrespondencia != null)
            {
                fPickCorrespondencia.LoadData<CorrespondenciaFilterType>(lista.AsQueryable(), fPickCorrespondencia.GetWhereString());
            }
        }

        private void fPickCorrespondencia_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBCorrespondencia.DisplayMember = fPickCorrespondencia.ValorDescrip;
            this.tSBCorrespondencia.KeyMember = fPickCorrespondencia.ValorID;

            fPickCorrespondencia.Close();
            fPickCorrespondencia.Dispose();
        }
        #endregion Correspondencia

        #region Cliente
        private void tSBCliente_AceptarClick(object sender, EventArgs e)
        {
            if (fPickCliente == null)
            {
                if (this.RegExt)
                {
                    fPickCliente = new frmPickBase();
                    fPickCliente.AceptarFiltrarClick += fPickCliente_AceptarFiltrarClick;
                    fPickCliente.FiltrarClick += fPickCliente_FiltrarClick;
                    fPickCliente.Titulo = "Elegir Corresponsal";
                    fPickCliente.CampoIDNombre = "ID";
                    fPickCliente.CampoDescripNombre = "Nombre";
                    fPickCliente.LabelCampoID = "ID";
                    fPickCliente.LabelCampoDescrip = "Nombre";
                    fPickCliente.NombreCampo = "Corresponsal";
                    fPickCliente.PermitirFiltroNulo = false;
                }
                else
                {
                    fPickCliente = new frmPickBase();
                    fPickCliente.AceptarFiltrarClick += fPickCliente_AceptarFiltrarClick;
                    fPickCliente.FiltrarClick += fPickCliente_FiltrarClick;
                    fPickCliente.Titulo = "Elegir Proveedor";
                    fPickCliente.CampoIDNombre = "pr_proveedorid";
                    fPickCliente.CampoDescripNombre = "pr_nombre";
                    fPickCliente.LabelCampoID = "ID";
                    fPickCliente.LabelCampoDescrip = "Nombre";
                    fPickCliente.NombreCampo = "Proveedor";
                    fPickCliente.PermitirFiltroNulo = false;
                }
            }
            fPickCliente.MostrarFiltro();
        }

        private void fPickCliente_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickCliente != null)
            {
                if (this.RegExt)
                {
                    fPickCliente.LoadData<Cliente>(this.DBContext.Cliente, fPickCliente.GetWhereString());
                }
                else
                {
                    fPickCliente.LoadData<pr_proveedor>(this.DBContext.pr_proveedor, fPickCliente.GetWhereString());
                }
            }
        }

        private void fPickCliente_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBCliente.DisplayMember = fPickCliente.ValorDescrip;
            this.tSBCliente.KeyMember = fPickCliente.ValorID;

            fPickCliente.Close();
            fPickCliente.Dispose();
        }

        #endregion Cliente

        #region Usuario (Solicitado Por)
        private void tSBUsuario_AceptarClick(object sender, EventArgs e)
        {
            if (fPickUsuario == null)
            {
                fPickUsuario = new frmPickBase();
                fPickUsuario.AceptarFiltrarClick += fPickUsuario_AceptarFiltrarClick;
                fPickUsuario.FiltrarClick += fPickUsuario_FiltrarClick;
                fPickUsuario.Titulo = "Elegir Persona a quien se solicita el servicio";
                fPickUsuario.CampoIDNombre = "ID";
                fPickUsuario.CampoDescripNombre = "NombrePila";
                fPickUsuario.LabelCampoID = "ID";
                fPickUsuario.LabelCampoDescrip = "Nombre";
                fPickUsuario.NombreCampo = "Usuario";
                fPickUsuario.PermitirFiltroNulo = true;
            }
            fPickUsuario.MostrarFiltro();
        }

        private void fPickUsuario_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickUsuario != null)
            {
                fPickUsuario.LoadData<Usuario>(this.DBContext.Usuario, fPickUsuario.GetWhereString());
            }
        }

        private void fPickUsuario_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBUsuario.DisplayMember = fPickUsuario.ValorDescrip;
            this.tSBUsuario.KeyMember = fPickUsuario.ValorID;

            fPickUsuario.Close();
            fPickUsuario.Dispose();
        }
        #endregion Usuario (Solicitado Por)

        #endregion Picks

        #region Métodos de Apoyo
        private void CargarDetalleSolPago(DataGridViewRow row, string format = FORMATO_DECIMAL_BROWSE)
        {
            this.txtSolPagoCabID.Text = this.SolPagoCabID.ToString();
            this.txtSolPagoDetID.Text = row.Cells[CAMPO_SOLPAGODETID].Value.ToString();
            this.txtFechaSolDet.Text = ((DateTime)row.Cells[CAMPO_FECHASOLDET].Value).ToShortDateString();
            this.dtpFechaSolDet.Value = (DateTime)row.Cells[CAMPO_FECHASOLDET].Value;
            this.tSBTarifa.KeyMember = row.Cells[CAMPO_TARIFAID].Value.ToString();
            this.tSBTarifa.DisplayMember = row.Cells[CAMPO_TARIFADESCRIP].Value.ToString();
            this.tSBUsuario.KeyMember = row.Cells[CAMPO_SOLICITADOPORID].Value.ToString();
            this.tSBUsuario.DisplayMember = row.Cells[CAMPO_SOLICITADOPORNOMBRE].Value.ToString();
            this.cbTipoUnidadDescuento.SelectedIndex = (bool)row.Cells[CAMPO_TIPOUNIDDESC].Value ? 0 : 1;
            this.txtMontoDescuento.Text = String.Format(format, decimal.Round((decimal)row.Cells[CAMPO_DESCUENTOMONTO].Value, MidpointRounding.AwayFromZero));
            this.txtPorcDescuento.Text = String.Format(format, (decimal)row.Cells[CAMPO_DESCUENTOPORC].Value);
            this.cbTipoUnidadImpuesto.SelectedIndex = (bool)row.Cells[CAMPO_TIPOUNIDIMP].Value ? 0 : 1;
            this.txtMontoImp.Text = String.Format(format, decimal.Round((decimal)row.Cells[CAMPO_IMPUESTOMONTO].Value, MidpointRounding.AwayFromZero));
            this.txtPorcImp.Text = String.Format(format, (decimal)row.Cells[CAMPO_IMPUESTOPORC].Value);
            
            //Exentas
            this.txtCantExentas.Text = String.Format(format, (decimal)row.Cells[CAMPO_CANTIDAD].Value);
            this.txtPUExentas.Text = String.Format(format, (decimal)row.Cells[CAMPO_PRECIOCOSTO].Value);
            this.txtTotalExentas.Text = String.Format(format, (decimal)row.Cells[CAMPO_EXENTAS].Value);
            //Gravadas5
            this.txtCantGrav5.Text = String.Format(format, (decimal)row.Cells[CAMPO_CANTIDADIVA5].Value);
            this.txtPUGrav5.Text = String.Format(format, (decimal)row.Cells[CAMPO_PRECUNITIVA5].Value);
            this.txtTotalIVA5.Text = String.Format(format, (decimal)row.Cells[CAMPO_IVA5].Value);
            //Gravadas10
            this.txtCantidad.Text = String.Format(format, (decimal)row.Cells[CAMPO_CANTIDADIVA10].Value);
            this.txtPUGrav10.Text = String.Format(format, (decimal)row.Cells[CAMPO_PREUNITIVA10].Value);
            this.txtTotalIVA10.Text = String.Format(format, (decimal)row.Cells[CAMPO_IVA10].Value);

            this.txtTotal.Text = String.Format(format, (decimal)row.Cells[CAMPO_TOTAL].Value);
            this.txtSaldo.Text = String.Format(format, (decimal)row.Cells[CAMPO_SALDODET].Value);
            this.txtNroFactura.Text = row.Cells[CAMPO_NROFACTURAPROV].Value != null ? row.Cells[CAMPO_NROFACTURAPROV].Value.ToString() : "";

            if (row.Cells[CAMPO_FECFACTURA].Value != null)
            {
                this.txtFecFactura.Text = ((DateTime)row.Cells[CAMPO_FECFACTURA].Value).ToShortDateString();
                this.dtpFecFactura.Value = (DateTime)row.Cells[CAMPO_FECFACTURA].Value;
            }
            else
            {
                this.txtFecFactura.Text = "";
            }

            if (row.Cells[CAMPO_TIPOFACTURAID].Value != null)
            {
                this.cbTipoFactura.SelectedValue = Convert.ToInt32(row.Cells[CAMPO_TIPOFACTURAID].Value.ToString());
            }
            else this.cbTipoFactura.SelectedValue = -1;

            
            this.chkFacturable.Checked = (bool)row.Cells[CAMPO_FACTURABLE].Value;
            this.chkReembolsable.Checked = (bool)row.Cells[CAMPO_REEMBOLSABLE].Value;
                        
            if (row.Cells[CAMPO_PROVEEDORID].Value != null)
            {
                this.tSBCliente.KeyMember = row.Cells[CAMPO_PROVEEDORID].Value.ToString();
                this.tSBCliente.DisplayMember = row.Cells[CAMPO_NOMBREPROVEEDOR].Value.ToString();
            }
            
            if (row.Cells[CAMPO_CORRESPONDENCIAID].Value != null)
            {
                this.tSBCorrespondencia.KeyMember = row.Cells[CAMPO_CORRESPONDENCIAID].Value.ToString();
                this.tSBCorrespondencia.DisplayMember = row.Cells[CAMPO_REFCORRESP].Value + " - " + row.Cells[CAMPO_CORRESPONDENCIAID].Value.ToString();
            }
        }

        private void Editable(bool editar)
        {
            this.txtFechaSolDet.ReadOnly = !editar;
            this.dtpFechaSolDet.Enabled = editar;
            this.tSBTarifa.Editable = editar;
            this.tSBUsuario.Editable = editar;
            this.cbTipoUnidadDescuento.Enabled = editar;
            this.cbTipoUnidadImpuesto.Enabled = editar;
            this.txtMontoDescuento.ReadOnly = !editar;
            this.txtPorcDescuento.ReadOnly = !editar;
            this.txtMontoImp.ReadOnly = !editar;
            this.txtPorcImp.ReadOnly = !editar;

            this.txtCantExentas.ReadOnly = !editar;
            this.txtPUExentas.ReadOnly = !editar;
            this.txtTotalExentas.ReadOnly = !editar;

            this.txtCantGrav5.ReadOnly = !editar;
            this.txtPUGrav5.ReadOnly = !editar;
            this.txtTotalIVA5.ReadOnly = !editar;

            this.txtCantidad.ReadOnly = !editar;
            this.txtPUGrav10.ReadOnly = !editar;
            this.txtTotalIVA10.ReadOnly = !editar;
                 

            if (editar)
            {
                this.cbTipoUnidadDescuentoHandler();
                this.cbTipoUnidadImpuestoHandler();
            }

            this.txtNroFactura.ReadOnly = !editar;
            this.chkFacturable.Enabled = editar;
            this.chkReembolsable.Enabled = editar;
            this.tSBCorrespondencia.Editable = editar;
            this.tSBCliente.Editable = editar;
            this.chkRedondear.Checked = editar;
            this.txtFecFactura.ReadOnly = !editar;
            this.dtpFecFactura.Enabled = editar;
            this.cbTipoFactura.Enabled = editar;
        }

        private void LimpiarDatos()
        {
            this.txtSolPagoCabID.Text = "";
            this.txtSolPagoDetID.Text = "";
            this.txtFechaSolDet.Text = "";
            //this.dtpFechaSolDet.Value = null;
            this.tSBTarifa.Clear();
            this.tSBUsuario.Clear();
            this.cbTipoUnidadDescuento.SelectedIndex = 0;
            this.txtMontoDescuento.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
            this.txtPorcDescuento.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
            this.cbTipoUnidadImpuesto.SelectedIndex = 0;
            this.txtMontoImp.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
            this.txtPorcImp.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
            
            this.txtCantExentas.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
            this.txtPUExentas.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
            this.txtTotalExentas.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;

            this.txtCantGrav5.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
            this.txtPUGrav5.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
            this.txtTotalIVA5.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;

            this.txtCantidad.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
            this.txtPUGrav10.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
            this.txtTotalIVA10.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
            
            this.txtTotal.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
            this.txtSaldo.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
            

            this.txtNroFactura.Text = "";
            this.chkFacturable.Checked = true;
            this.chkReembolsable.Checked = false;
            this.tSBCorrespondencia.Clear();
            this.tSBCliente.Clear();
            this.chkRedondear.Checked = true;
            this.txtFecFactura.Text = "";
        }

        private void Nuevo()
        {
            this.LimpiarDatos();
            this.txtSolPagoCabID.Text = this.SolPagoCabID.ToString();
            this.txtFechaSolDet.Focus();
            this.txtFechaSolDet.Text = DateTime.Now.ToShortDateString();
            this.dtpFechaSolDet.Value = DateTime.Now;
            //this.txtCantidad.Text = "1,00";
            this.cbTipoUnidadDescuento.SelectedIndex = 0;
            this.cbTipoUnidadImpuesto.SelectedIndex = 0;
        }

        private void cbTipoUnidadImpuestoHandler()
        {
            if (this.Editar)
            {
                if (this.cbTipoUnidadImpuesto.SelectedIndex == 1)
                {
                    this.txtMontoImp.ReadOnly = false;
                    this.txtMontoImp.BackColor = SystemColors.Window;
                    this.txtPorcImp.ReadOnly = true;
                    this.txtPorcImp.BackColor = SystemColors.Control;
                    this.txtMontoImp.Focus();
                }
                else if (this.cbTipoUnidadImpuesto.SelectedIndex == 0)
                {
                    this.txtMontoImp.ReadOnly = true;
                    this.txtMontoImp.BackColor = SystemColors.Control;
                    this.txtPorcImp.ReadOnly = false;
                    this.txtPorcImp.BackColor = SystemColors.Window;
                    this.txtPorcImp.Focus();
                }
                else
                {
                    this.txtMontoImp.ReadOnly = true;
                    this.txtMontoImp.BackColor = SystemColors.Control;
                    this.txtPorcImp.ReadOnly = true;
                    this.txtPorcImp.BackColor = SystemColors.Control;
                }
            }
        }

        private void cbTipoUnidadDescuentoHandler()
        {
            if (this.Editar)
            {
                if (this.cbTipoUnidadDescuento.SelectedIndex == 1)
                {
                    this.txtMontoDescuento.ReadOnly = false;
                    this.txtMontoDescuento.BackColor = SystemColors.Window;
                    this.txtPorcDescuento.ReadOnly = true;
                    this.txtPorcDescuento.BackColor = SystemColors.Control;
                    this.txtMontoDescuento.Focus();
                }
                else if (this.cbTipoUnidadDescuento.SelectedIndex == 0)
                {
                    this.txtMontoDescuento.ReadOnly = true;
                    this.txtMontoDescuento.BackColor = SystemColors.Control;
                    this.txtPorcDescuento.ReadOnly = false;
                    this.txtPorcDescuento.BackColor = SystemColors.Window;
                    this.txtPorcDescuento.Focus();
                }
                else
                {
                    this.txtMontoDescuento.ReadOnly = true;
                    this.txtMontoDescuento.BackColor = SystemColors.Control;
                    this.txtPorcDescuento.ReadOnly = true;
                    this.txtPorcDescuento.BackColor = SystemColors.Control;
                }
            }
        }

        private void GetTarifas(int tarifaID)
        {
            Tarifas tarifa = this.DBContext.Tarifas.First(b => b.ID == tarifaID);

            ((IObjectContextAdapter)this.DBContext).ObjectContext.Refresh(System.Data.Entity.Core.Objects.RefreshMode.ClientWins, tarifa);

            if (tarifa != null)
            {

                if (tarifa.ImpuestoPorcentaje == IVA5)
                {
                    this.txtCantGrav5.Text = this.MonedaID == MONEDA_GUARANIES ? UNO_SIN_DECIMALES : UNO_CON_DECIMALES;
                    this.txtPUGrav5.Text = String.Format(this.formatBrowse, decimal.Round((tarifa.Monto * COEFICIENTE_IVA5)), MidpointRounding.AwayFromZero);
                    this.txtTotalIVA5.Text = this.txtPUGrav5.Text;
                    this.txtCantGrav5.Focus();
                }
                else if (tarifa.ImpuestoPorcentaje == IVA10)
                {
                    this.txtCantidad.Text = this.MonedaID == MONEDA_GUARANIES ? UNO_SIN_DECIMALES : UNO_CON_DECIMALES;
                    this.txtPUGrav10.Text = String.Format(this.formatBrowse, decimal.Round((tarifa.Monto * COEFICIENTE_IVA10)), MidpointRounding.AwayFromZero);
                    this.txtTotalIVA10.Text = this.txtPUGrav10.Text;
                    this.txtCantidad.Focus();
                }
                else
                {
                    //this.txtCantExentas.Text = this.MonedaID == MONEDA_GUARANIES ? UNO_SIN_DECIMALES : UNO_CON_DECIMALES;
                    this.txtCantExentas.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
                    this.txtPUExentas.Text = String.Format(this.formatBrowse, decimal.Round(tarifa.Monto), MidpointRounding.AwayFromZero);
                    this.txtTotalExentas.Text = this.txtPUExentas.Text;
                    this.txtCantExentas.Focus();
                }
                this.calcularTotal();

                
            }
        }

        private void calcularTotal()
        {
            if ((this.txtTotalExentas.Text != "") &&
                (this.txtTotalIVA5.Text != "") &&
                (this.txtTotalIVA10.Text != ""))
            {
                decimal total = Convert.ToDecimal(this.txtTotalExentas.Text) +
                                Convert.ToDecimal(this.txtTotalIVA5.Text) +
                                Convert.ToDecimal(this.txtTotalIVA10.Text);

                if (this.chkRedondear.Checked)
                    total = decimal.Round(total, MidpointRounding.AwayFromZero);

                //this.txtTotal.Text = String.Format(FORMATO_DECIMAL_EDIT, total);
                //this.txtSaldo.Text = String.Format(FORMATO_DECIMAL_EDIT, total);
                this.txtTotal.Text = String.Format(this.formatEdit, total);
                this.txtSaldo.Text = String.Format(this.formatEdit, total);
            }
        }

        private void calcularTotalExentas()
        {
            if (this.Editar)
            {
                decimal cantidad = Convert.ToDecimal(this.txtCantExentas.Text);
                decimal precUnit = Convert.ToDecimal(this.txtPUExentas.Text);
                //this.txtTotalExentas.Text = String.Format(FORMATO_DECIMAL_EDIT, cantidad * precUnit);
                this.txtTotalExentas.Text = String.Format(this.formatEdit, cantidad * precUnit);
            }
        }

        private void calcularTotalGravadas5()
        {
            if (this.Editar)
            {
                decimal cantidad = Convert.ToDecimal(this.txtCantGrav5.Text);
                decimal precUnit = Convert.ToDecimal(this.txtPUGrav5.Text);
                //this.txtTotalIVA5.Text = String.Format(FORMATO_DECIMAL_EDIT, cantidad * precUnit);
                this.txtTotalIVA5.Text = String.Format(this.formatEdit, cantidad * precUnit);
            }
        }

        private void calcularTotalGravadas10()
        {
            if (this.Editar)
            {
                decimal cantidad = Convert.ToDecimal(this.txtCantidad.Text);
                decimal precUnit = Convert.ToDecimal(this.txtPUGrav10.Text);
                //this.txtTotalIVA10.Text = String.Format(FORMATO_DECIMAL_EDIT, cantidad * precUnit);
                this.txtTotalIVA10.Text = String.Format(this.formatEdit, cantidad * precUnit);
            }

        }

        //private void calcularTotal()
        //{
        //    if ((this.txtCantidad.Text != "") &&
        //         //(this.txtPrecioVenta.Text != "") &&
        //         (this.txtMontoDescuento.Text != "") &&
        //         (this.txtPorcDescuento.Text != "") &&
        //         (this.txtMontoImp.Text != "") &&
        //         (this.txtPorcImp.Text != "")
        //        )
        //    {
        //        //decimal total = Convert.ToDecimal(this.txtCantidad.Text) * Convert.ToDecimal(this.txtPrecioVenta.Text);
        //        decimal total = Convert.ToDecimal(this.txtCantidad.Text) * Convert.ToDecimal(this.txtPUGrav10.Text);

        //        if ((this.cbTipoUnidadDescuento.SelectedIndex == 1) && (this.txtMontoDescuento.Text != ""))
        //        {
        //            total = total - Convert.ToDecimal(this.txtMontoDescuento.Text);
        //        }
        //        else if ((this.cbTipoUnidadDescuento.SelectedIndex == 0) && (this.txtPorcDescuento.Text != ""))
        //        {
        //            total = total - (total * Convert.ToDecimal(this.txtPorcDescuento.Text) / 100);
        //        }

        //        if ((this.cbTipoUnidadImpuesto.SelectedIndex == 1) && (this.txtMontoImp.Text != ""))
        //        {
        //            total = total + Convert.ToDecimal(this.txtMontoImp.Text);
        //        }
        //        else if ((this.cbTipoUnidadImpuesto.SelectedIndex == 0) && (this.txtPorcImp.Text != ""))
        //        {
        //            total = total + total * Convert.ToDecimal(this.txtPorcImp.Text) / 100;
        //        }

        //        if (this.chkRedondear.Checked)
        //            total = decimal.Round(total, MidpointRounding.AwayFromZero);

        //        this.txtTotal.Text = String.Format(FORMATO_DECIMAL_EDIT, total);
        //        this.txtSaldo.Text = String.Format(FORMATO_DECIMAL_EDIT, total);
        //    }
        //}

        private void DialogHandler(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    this.GuardarRegistro();
                }
            }
        }

        #endregion Métodos de Apoyo

        #region Métodos Locales sobre Controles
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbTipoUnidadImpuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbTipoUnidadImpuestoHandler();
        }

        private void cbTipoUnidadDescuento_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbTipoUnidadDescuentoHandler();
        }

        private void txtPorcDescuento_Leave(object sender, EventArgs e)
        {
            if (this.Editar)
            {
                decimal valor;
                if (!decimal.TryParse(this.txtPorcDescuento.Text, out valor)) this.txtPorcDescuento.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
                if ((this.cbTipoUnidadDescuento.SelectedIndex == 0) && (this.txtPorcDescuento.Text != ""))
                {
                    this.txtMontoDescuento.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
                    //this.txtPorcDescuento.Text = String.Format(FORMATO_DECIMAL_EDIT, Convert.ToDecimal(this.txtPorcDescuento.Text.Replace('.', ',')));
                    this.txtPorcDescuento.Text = String.Format(this.formatEdit, Convert.ToDecimal(this.txtPorcDescuento.Text.Replace('.', ',')));
                    this.calcularTotal();

                }
            }
        }

        private void txtPorcImp_Leave(object sender, EventArgs e)
        {
            if (this.Editar)
            {
                decimal valor;
                if (!decimal.TryParse(this.txtPorcImp.Text, out valor)) this.txtPorcImp.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
                if ((this.cbTipoUnidadImpuesto.SelectedIndex == 0) && (this.txtPorcImp.Text != ""))
                {
                    this.txtMontoImp.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
                    //this.txtPorcImp.Text = String.Format(FORMATO_DECIMAL_EDIT, Convert.ToDecimal(this.txtPorcImp.Text.Replace('.', ',')));
                    this.txtPorcImp.Text = String.Format(this.formatEdit, Convert.ToDecimal(this.txtPorcImp.Text.Replace('.', ',')));
                    this.calcularTotal();
                }
            }
        }

        private void txtMontoDescuento_Leave(object sender, EventArgs e)
        {
            if (this.Editar)
            {
                decimal valor;
                if (!decimal.TryParse(this.txtMontoDescuento.Text, out valor)) this.txtMontoDescuento.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
                if ((this.cbTipoUnidadDescuento.SelectedIndex == 1) && (this.txtMontoDescuento.Text != ""))
                {

                    this.txtPorcDescuento.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
                    //this.txtMontoDescuento.Text = String.Format(FORMATO_DECIMAL_EDIT, Convert.ToDecimal(this.txtMontoDescuento.Text.Replace('.', ',')));
                    this.txtMontoDescuento.Text = String.Format(this.formatEdit, Convert.ToDecimal(this.txtMontoDescuento.Text.Replace('.', ',')));
                    this.calcularTotal();
                }
            }
        }

        private void txtMontoImp_Leave(object sender, EventArgs e)
        {
            if (this.Editar)
            {
                decimal valor;
                if (!decimal.TryParse(this.txtMontoImp.Text, out valor)) this.txtMontoImp.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
                if ((this.cbTipoUnidadImpuesto.SelectedIndex == 1) && (this.txtMontoImp.Text != ""))
                {
                    this.txtPorcImp.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
                    //this.txtMontoImp.Text = String.Format(FORMATO_DECIMAL_EDIT, this.txtMontoImp.Text.Replace('.', ','));
                    this.txtMontoImp.Text = String.Format(this.formatEdit, this.txtMontoImp.Text.Replace('.', ','));
                    this.calcularTotal();
                }
            }
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            if (this.Editar)
            {
                decimal valor;
                if (!decimal.TryParse(this.txtCantidad.Text.Replace('.', ','), out valor))
                    this.txtCantidad.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
                else
                    //this.txtCantidad.Text = String.Format(FORMATO_DECIMAL_EDIT, valor);
                    this.txtCantidad.Text = String.Format(this.formatEdit, valor);

                this.calcularTotalGravadas10();
                this.calcularTotal();

                //if (this.tSBTarifa.KeyMember != "")
                //{
                //    decimal valor;
                //    if (!decimal.TryParse(this.txtCantidad.Text.Replace('.', ','), out valor))
                //        this.txtCantidad.Text = this.MonedaID == MONEDA_GUARANIES ? UNO_SIN_DECIMALES : UNO_CON_DECIMALES;
                //    else
                //        this.txtCantidad.Text = String.Format(FORMATO_DECIMAL_EDIT, valor);

                //    this.calcularTotal();
                //}

            }
        }

        private void txtCantExentas_Leave(object sender, EventArgs e)
        {
            if (this.Editar)
            {
                decimal valor;
                if (!decimal.TryParse(this.txtCantExentas.Text.Replace('.', ','), out valor))
                    this.txtCantExentas.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
                else
                    //this.txtCantExentas.Text = String.Format(FORMATO_DECIMAL_EDIT, valor);
                    this.txtCantExentas.Text = String.Format(this.formatEdit, valor);

                this.calcularTotalExentas();
                this.calcularTotal();

            }
        }

        private void txtCantGrav5_Leave(object sender, EventArgs e)
        {
            if (this.Editar)
            {
                decimal valor;
                if (!decimal.TryParse(this.txtCantGrav5.Text.Replace('.', ','), out valor))
                    this.txtCantGrav5.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
                else
                    //this.txtCantGrav5.Text = String.Format(FORMATO_DECIMAL_EDIT, valor);
                    this.txtCantGrav5.Text = String.Format(this.formatEdit, valor);

                this.calcularTotalGravadas5();
                this.calcularTotal();

            }
        }

        private void txtPUExentas_Leave(object sender, EventArgs e)
        {
            if (this.Editar)
            {
                decimal valor;
                if (!decimal.TryParse(this.txtPUExentas.Text.Replace('.', ','), out valor))
                    this.txtPUExentas.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
                else
                    //this.txtPUExentas.Text = String.Format(FORMATO_DECIMAL_EDIT, valor);
                    this.txtPUExentas.Text = String.Format(this.formatEdit, valor);

                this.calcularTotalExentas();
                this.calcularTotal();
            }
        }

        private void txtPUGrav5_Leave(object sender, EventArgs e)
        {
            if (this.Editar)
            {
                decimal valor;
                if (!decimal.TryParse(this.txtPUGrav5.Text.Replace('.', ','), out valor))
                    this.txtPUGrav5.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
                else
                    //this.txtPUGrav5.Text = String.Format(FORMATO_DECIMAL_EDIT, valor);
                    this.txtPUGrav5.Text = String.Format(this.formatEdit, valor);

                this.calcularTotalGravadas5();
                this.calcularTotal();
            }
        }

        private void txtPUGrav10_Leave(object sender, EventArgs e)
        {
            if (this.Editar)
            {
                decimal valor;
                if (!decimal.TryParse(this.txtPUGrav10.Text.Replace('.', ','), out valor))
                    this.txtPUGrav10.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
                else
                    //this.txtPUGrav10.Text = String.Format(FORMATO_DECIMAL_EDIT, valor);
                    this.txtPUGrav10.Text = String.Format(this.formatEdit, valor);

                this.calcularTotalGravadas10();
                this.calcularTotal();
            }
        }

        private void txtTotalExentas_Leave(object sender, EventArgs e)
        {
            if (this.Editar)
            {
                decimal valor;
                if (!decimal.TryParse(this.txtTotalExentas.Text.Replace('.', ','), out valor))
                    this.txtTotalExentas.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
                else
                {
                    decimal cantidad = Convert.ToDecimal(this.txtCantExentas.Text.Replace('.', ','));
                    if ((cantidad == 0) && (valor > 0))
                    {
                        cantidad = 1M;
                        this.txtCantExentas.Text = this.MonedaID == MONEDA_GUARANIES ? UNO_SIN_DECIMALES : UNO_CON_DECIMALES;
                    }

                    //this.txtPUExentas.Text = cantidad > 0 ? String.Format(FORMATO_DECIMAL_EDIT, valor / cantidad) : this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
                    //this.txtTotalExentas.Text = String.Format(FORMATO_DECIMAL_EDIT, valor);
                    this.txtPUExentas.Text = cantidad > 0 ? String.Format(this.formatEdit, valor / cantidad) : this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
                    this.txtTotalExentas.Text = String.Format(this.formatEdit, valor);
                }

                //this.calcularTotalGravadas10();
                this.calcularTotal();
            }
        }

        private void txtTotalIVA5_Leave(object sender, EventArgs e)
        {
            if (this.Editar)
            {
                decimal valor;
                if (!decimal.TryParse(this.txtTotalIVA5.Text.Replace('.', ','), out valor))
                    this.txtTotalIVA5.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
                else
                {
                    decimal cantidad = Convert.ToDecimal(this.txtCantGrav5.Text.Replace('.', ','));
                    if ((cantidad == 0) && (valor > 0))
                    {
                        cantidad = 1M;
                        this.txtCantGrav5.Text = this.MonedaID == MONEDA_GUARANIES ? UNO_SIN_DECIMALES : UNO_CON_DECIMALES;
                    }

                    //this.txtPUGrav5.Text = cantidad > 0 ? String.Format(FORMATO_DECIMAL_EDIT, valor / cantidad) : this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
                    //this.txtTotalIVA5.Text = String.Format(FORMATO_DECIMAL_EDIT, valor);
                    this.txtPUGrav5.Text = cantidad > 0 ? String.Format(this.formatEdit, valor / cantidad) : this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
                    this.txtTotalIVA5.Text = String.Format(this.formatEdit, valor);
                }

                //this.calcularTotalGravadas10();
                this.calcularTotal();
            }
        }

        private void txtTotalIVA10_Leave(object sender, EventArgs e)
        {
            if (this.Editar)
            {
                decimal valor;
                if (!decimal.TryParse(this.txtTotalIVA10.Text.Replace('.', ','), out valor))
                    this.txtTotalIVA10.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
                else
                {
                    decimal cantidad = Convert.ToDecimal(this.txtCantidad.Text.Replace('.', ','));
                    if ((cantidad == 0) && (valor > 0))
                    {
                        cantidad = 1M;
                        this.txtCantidad.Text = this.MonedaID == MONEDA_GUARANIES ? UNO_SIN_DECIMALES : UNO_CON_DECIMALES;
                    }

                    //this.txtPUGrav10.Text = cantidad > 0 ? String.Format(FORMATO_DECIMAL_EDIT, valor / cantidad) : this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
                    //this.txtTotalIVA10.Text = String.Format(FORMATO_DECIMAL_EDIT, valor);
                    this.txtPUGrav10.Text = cantidad > 0 ? String.Format(this.formatEdit, valor / cantidad) : this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
                    this.txtTotalIVA10.Text = String.Format(this.formatEdit, valor);
                }

                //this.calcularTotalGravadas10();
                this.calcularTotal();
            }
        }

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            if (this.Editar)
            {
                if (this.tSBTarifa.KeyMember != "")
                {
                    decimal valor;
                    if (!decimal.TryParse(this.txtPUGrav10.Text.Replace('.', ','), out valor))
                        this.txtPUGrav10.Text = this.MonedaID == MONEDA_GUARANIES ? CERO_SIN_DECIMALES : CERO_CON_DECIMALES;
                    else
                        //this.txtPUGrav10.Text = String.Format(FORMATO_DECIMAL_EDIT, valor);
                        this.txtPUGrav10.Text = String.Format(this.formatEdit, valor);

                    this.calcularTotal();
                }
            }
        }

        private void chkRedondear_CheckedChanged(object sender, EventArgs e)
        {
            this.calcularTotal();
        }

        private void dtpFechaSolDet_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaSolDet.Text = this.dtpFechaSolDet.Value.ToShortDateString();
        }

        private void dtpFecFactura_ValueChanged(object sender, EventArgs e)
        {
            this.txtFecFactura.Text = this.dtpFecFactura.Value.ToShortDateString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.txtFechaSolDet.Text == "")
            {
                MessageBox.Show("Debe ingresar la fecha del detalle.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (this.tSBTarifa.KeyMember == "")
            {
                MessageBox.Show("Debe seleccionar una tarifa obligatoriamente.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (this.tSBUsuario.KeyMember == "")
            {
                MessageBox.Show("Debe seleccionar la persona que solicita el servicio obligatoriamente.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            //if (Convert.ToDecimal(this.txtTotal.Text) == 0)
            //{
            //    MessageBox.Show("El total no puede ser igual a 0 (cero)",
            //                    "Información",
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Information);

            //    return;
            //}

            string message = "";
            string caption = "";
            
            if (this.Editar)
            {
                if (this.txtSolPagoDetID.Text != "")
                {
                    caption = "Actualización de registro";
                    message = "Se modificará el presente registro ¿Desea continuar?";
                }
                else
                {
                    caption = "Inserción de nuevo de registro";
                    message = "Se insertará un nuevo registro ¿Desea continuar?";
                }
            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(DialogHandler));

        }

        #endregion Métodos Locales sobre Controles

        #region CRUD
        private void GuardarRegistro()
        {
            bool success = false;

            spd_solicitudpagodet spd = null;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        spd = this.guardarDetalle(context);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        success = true;
                    }
                    catch (DbEntityValidationException e)
                    {
                        string error = "";
                        string sError = "";
                        foreach (var eve in e.EntityValidationErrors)
                        {
                            error = String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                eve.Entry.Entity.GetType().Name, eve.Entry.State);

                            foreach (var ve in eve.ValidationErrors)
                            {
                                sError = String.Format("Property: \"{0}\", Error: \"{1}\"",
                                    ve.PropertyName, ve.ErrorMessage);
                            }
                        }
                        dbContextTransaction.Rollback();
                        MessageBox.Show("Ocurrió un error al procesar el guardado: " + Environment.NewLine
                                        + error + Environment.NewLine
                                        + sError,
                                        "Error al guardar los datos",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Stop);
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();

                        string innerException = String.Empty;

                        if (ex.InnerException != null)
                        {
                            innerException += "Detalle: ";
                            innerException += ex.InnerException.InnerException != null
                                              ? ex.InnerException.InnerException.Message
                                              : ex.InnerException.Message;
                        }

                        MessageBox.Show("Ocurrió un error al procesar el guardado: "
                                        + ex.Message + Environment.NewLine
                                        + innerException,
                                        "Error al guardar los datos",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Stop);
                    }
                }
            }
            if (success)
            {
                seGuardo = true;
                this.Close();
            }
        }

        #region Métodos de Edición de Datos
        private spd_solicitudpagodet guardarDetalle(BerkeDBEntities context = null)
        {
            spd_solicitudpagodet spd = new spd_solicitudpagodet();
            if (this.Editar)
            {
                if (this.txtSolPagoDetID.Text != "")
                {
                    int spdID = Convert.ToInt32(this.txtSolPagoDetID.Text);

                    spd = context.spd_solicitudpagodet.First(a => a.spd_solicitudpagodetid == spdID);
                    spd.spd_facturable = this.chkFacturable.Checked;
                    spd.spd_reembolsable = this.chkReembolsable.Checked;
                    spd.spd_fechasol = Convert.ToDateTime(this.txtFechaSolDet.Text);

                    if (this.tSBCorrespondencia.KeyMember != "")
                    {
                        spd.spd_correspondenciaid = Convert.ToInt32(this.tSBCorrespondencia.KeyMember);
                    }
                    else spd.spd_correspondenciaid = null;

                    spd.spd_tarifaid = Convert.ToInt32(this.tSBTarifa.KeyMember);
                    spd.spd_solicitadopor = Convert.ToInt32(this.tSBUsuario.KeyMember);
                    //spd.spd_tipounidaddesc = this.cbTipoUnidadDescuento.SelectedIndex == 0 ? true : false;
                    //spd.spd_descuentomonto = Convert.ToDecimal(this.txtMontoDescuento.Text.Replace('.', ','));
                    //spd.spd_descuentoporcentaje = Convert.ToDecimal(this.txtPorcDescuento.Text.Replace('.', ','));
                    //spd.spd_tipounidadimp = this.cbTipoUnidadImpuesto.SelectedIndex == 0 ? true : false;
                    //spd.spd_impuestomonto = Convert.ToDecimal(this.txtMontoImp.Text.Replace('.', ','));
                    //spd.spd_impuestoporcentaje = Convert.ToDecimal(this.txtPorcImp.Text.Replace('.', ','));

                    //Exentas
                    spd.spd_cantidad = Convert.ToDecimal(this.txtCantExentas.Text.Replace('.', ','));
                    spd.spd_preciocosto = Convert.ToDecimal(this.txtPUExentas.Text.Replace('.', ','));
                    spd.spd_exentas = Convert.ToDecimal(this.txtTotalExentas.Text.Replace('.', ','));
                    //Gravadas5
                    spd.spd_cantidadiva5 = Convert.ToDecimal(this.txtCantGrav5.Text.Replace('.', ','));
                    spd.spd_precunitiva5 = Convert.ToDecimal(this.txtPUGrav5.Text.Replace('.', ','));
                    spd.spd_iva5 = Convert.ToDecimal(this.txtTotalIVA5.Text.Replace('.', ','));
                    //Gravadas10
                    spd.spd_cantidadiva10 = Convert.ToDecimal(this.txtCantidad.Text.Replace('.', ','));
                    spd.spd_precunitiva10 = Convert.ToDecimal(this.txtPUGrav10.Text.Replace('.', ','));
                    spd.spd_iva10 = Convert.ToDecimal(this.txtTotalIVA10.Text.Replace('.', ','));
                    
                    spd.spd_total = Convert.ToDecimal(this.txtTotal.Text.Replace('.', ','));
                    spd.spd_saldo= Convert.ToDecimal(this.txtSaldo.Text.Replace('.', ','));

                    if (this.tSBCliente.KeyMember != "")
                    {
                        spd.spd_proveedorid = Convert.ToInt32(this.tSBCliente.KeyMember);
                    }
                    else spd.spd_proveedorid = null;

                    if (this.txtNroFactura.Text.Trim() != "")
                        spd.spd_nrofactura = this.txtNroFactura.Text;
                    else spd.spd_nrofactura = null;

                    if (this.txtFecFactura.Text.Trim() != "")
                        spd.spd_fechafactura = Convert.ToDateTime(this.txtFecFactura.Text);
                    else spd.spd_fechafactura = null;

                    int tipofacturaid = Convert.ToInt32(this.cbTipoFactura.SelectedValue.ToString());
                    if (tipofacturaid > 0)
                    {
                        spd.spd_tipofacturaid = tipofacturaid;
                    }
                    else spd.spd_tipofacturaid = null;

                }
                else
                {
                    spd.spd_solicitudpagocabid = this.SolPagoCabID;
                    spd.spd_facturable = this.chkFacturable.Checked;
                    spd.spd_reembolsable = this.chkReembolsable.Checked;
                    spd.spd_fechasol = Convert.ToDateTime(this.txtFechaSolDet.Text);

                    if (this.tSBCorrespondencia.KeyMember != "")
                    {
                        spd.spd_correspondenciaid = Convert.ToInt32(this.tSBCorrespondencia.KeyMember);
                    }
                    else spd.spd_correspondenciaid = null;

                    spd.spd_tarifaid = Convert.ToInt32(this.tSBTarifa.KeyMember);
                    spd.spd_solicitadopor = Convert.ToInt32(this.tSBUsuario.KeyMember);
                    //spd.spd_tipounidaddesc = this.cbTipoUnidadDescuento.SelectedIndex == 0 ? true : false;
                    //spd.spd_descuentomonto = Convert.ToDecimal(this.txtMontoDescuento.Text.Replace('.', ','));
                    //spd.spd_descuentoporcentaje = Convert.ToDecimal(this.txtPorcDescuento.Text.Replace('.', ','));
                    //spd.spd_tipounidadimp = this.cbTipoUnidadImpuesto.SelectedIndex == 0 ? true : false;
                    //spd.spd_impuestomonto = Convert.ToDecimal(this.txtMontoImp.Text.Replace('.', ','));
                    //spd.spd_impuestoporcentaje = Convert.ToDecimal(this.txtPorcImp.Text.Replace('.', ','));

                    //Exentas
                    spd.spd_cantidad = Convert.ToDecimal(this.txtCantExentas.Text.Replace('.', ','));
                    spd.spd_preciocosto = Convert.ToDecimal(this.txtPUExentas.Text.Replace('.', ','));
                    spd.spd_exentas = Convert.ToDecimal(this.txtTotalExentas.Text.Replace('.', ','));
                    //Gravadas5
                    spd.spd_cantidadiva5 = Convert.ToDecimal(this.txtCantGrav5.Text.Replace('.', ','));
                    spd.spd_precunitiva5 = Convert.ToDecimal(this.txtPUGrav5.Text.Replace('.', ','));
                    spd.spd_iva5 = Convert.ToDecimal(this.txtTotalIVA5.Text.Replace('.', ','));
                    //Gravadas10
                    spd.spd_cantidadiva10 = Convert.ToDecimal(this.txtCantidad.Text.Replace('.', ','));
                    spd.spd_precunitiva10 = Convert.ToDecimal(this.txtPUGrav10.Text.Replace('.', ','));
                    spd.spd_iva10 = Convert.ToDecimal(this.txtTotalIVA10.Text.Replace('.', ','));

                    spd.spd_total = Convert.ToDecimal(this.txtTotal.Text.Replace('.', ','));
                    spd.spd_saldo = Convert.ToDecimal(this.txtSaldo.Text.Replace('.', ','));

                    if (this.tSBCliente.KeyMember != "")
                    {
                        spd.spd_proveedorid = Convert.ToInt32(this.tSBCliente.KeyMember);
                    }
                    else spd.spd_proveedorid = null;

                    if (this.txtNroFactura.Text.Trim() != "")
                        spd.spd_nrofactura = this.txtNroFactura.Text;
                    else spd.spd_nrofactura = null;

                    if (this.txtFecFactura.Text.Trim() != "")
                        spd.spd_fechafactura = Convert.ToDateTime(this.txtFecFactura.Text);
                    else spd.spd_fechafactura = null;

                    int tipofacturaid = Convert.ToInt32(this.cbTipoFactura.SelectedValue.ToString());
                    if (tipofacturaid > 0)
                    {
                        spd.spd_tipofacturaid = tipofacturaid;
                    }
                    else spd.spd_tipofacturaid = null;

                    context.spd_solicitudpagodet.Add(spd);
                }
            }
            return spd;
        }
        #endregion Métodos de Edición de Datos

        #endregion CRUD

    }
}