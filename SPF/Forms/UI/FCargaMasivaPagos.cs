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
using Gizmox.WebGUI.Forms;

using ModelEF6;
using SPF.Types;
using SPF.Forms.Base;
using System.Data.Entity;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;

using SPF.Classes;
using Microsoft.Reporting.WebForms;

#endregion

namespace SPF.Forms.UI
{
    public partial class FCargaMasivaPagos : Form
    {
        #region Variables
        BerkeDBEntities DBContext;
        int CantTabs = 0;
        frmPickBase fPickCliente;
        frmPickBase fPickFormaPago;
        frmPickBase fPickMoneda;
        frmPickBase fPickBancoDeposito;
        frmPickBase fPickCuentaDeposito;
        frmPickBase fPickBancoCheque;
        frmPickBase fPickMonedaGastoBancario;
        frmPickBase fPickNotaCredito;
        frmPickBase fPickRespCobroExterior;
        private bool ExistenNCConSaldo = false;
        #endregion Variables

        #region Constantes
        public const string BROWSE                  = "BROWSE";
        public const string INSERT                  = "INSERT";
        public const string EDIT                    = "EDIT";
        public const string ESTADO_ANULADO          = "N";
        public const string CAMPO_SELECCIONAR       = "Seleccionar";
        public const string CAMPO_PRESUPUESTOID     = "PresupuestoID";
        public const string CAMPO_FECHAGENERACION   = "FechaGeneracion";
        public const string CAMPO_CLIENTEID         = "ClienteID";
        public const string CAMPO_MONTO             = "Monto";
        public const string CAMPO_SALDO             = "Saldo";
        public const string CAMPO_ESTADO            = "Estado";
        public const string CAMPO_DOCUMENTONRO      = "DocumentoNro";
        public const string CAMPO_IMPORTE           = "Importe";
        public const string CAMPO_ABREVMONEDA       = "MonedaAbrev";
        private const int FORMAPAGO_NOTACREDITOPRESUPUESTO = 9;
        private const int FORMAPAGO_COBRO_EN_EL_EXTERIOR = 16;
        private const int IDIOMA_ESPANOL = 2;
        #endregion Constantes

        #region Propiedades
        public string FormEditStatus
        {
            set { this.txtEditStatus.Text = value; }
            get { return this.txtEditStatus.Text; }
        }
        #endregion Propiedades
        
        #region Métodos de Inicio
        public FCargaMasivaPagos()
        {
            InitializeComponent();
        }

        public FCargaMasivaPagos(string titulo, BerkeDBEntities context)
        {
            InitializeComponent();
            this.DBContext = context;
            this.Text = titulo;
            this.ConfigTabs();

            #region Inicializar TextSearchBoxes
            this.tSBCliente.KeyMemberWidth = 70;
            this.tSBCliente.ToolTip = "Elegir Cliente";
            this.tSBCliente.Editable = true;
            this.tSBCliente.AceptarClick += tSBCliente_AceptarClick;

            this.tSBFormaPago.KeyMemberWidth = 70;
            this.tSBFormaPago.ToolTip = "Elegir Forma de Pago";
            this.tSBFormaPago.Editable = true;
            this.tSBFormaPago.AceptarClick += tSBFormaPago_AceptarClick;
            this.tSBFormaPago.KeyMemberTextChanged += tSBFormaPago_KeyMemberTextChanged;

            this.tSBRespCobroExterior.KeyMemberWidth = 70;
            this.tSBRespCobroExterior.ToolTip = "Elegir Responsable de Cobro en el Exterior";
            this.tSBRespCobroExterior.AceptarClick += tSBRespCobroExterior_AceptarClick;

            this.tSBMoneda.KeyMemberWidth = 70;
            this.tSBMoneda.ToolTip = "Elegir Moneda";
            this.tSBMoneda.Editable = true;
            this.tSBMoneda.AceptarClick += tSBMoneda_AceptarClick;

            this.tSBBancoDeposito.KeyMemberWidth = 70;
            this.tSBBancoDeposito.ToolTip = "Elegir Banco de Depósito";
            this.tSBBancoDeposito.Editable = true;
            this.tSBBancoDeposito.AceptarClick += tSBBancoDeposito_AceptarClick;

            this.tSBCuentaDeposito.KeyMemberWidth = 70;
            this.tSBCuentaDeposito.ToolTip = "Elegir Cuenta de Depósito";
            this.tSBCuentaDeposito.Editable = true;
            this.tSBCuentaDeposito.AceptarClick += tSBCuentaDeposito_AceptarClick;

            this.tSBBancoCheque.KeyMemberWidth = 70;
            this.tSBBancoCheque.ToolTip = "Elegir Banco de Cheque";
            this.tSBBancoCheque.Editable = true;
            this.tSBBancoCheque.AceptarClick += tSBBancoCheque_AceptarClick;

            this.tSBMonedaGastoBancario.KeyMemberWidth = 70;
            this.tSBMonedaGastoBancario.ToolTip = "Elegir Moneda";
            this.tSBMonedaGastoBancario.Editable = true;
            this.tSBMonedaGastoBancario.AceptarClick += tSBMonedaGastoBancario_AceptarClick;

            this.tSBNotaCredito.KeyMemberWidth = 100;
            this.tSBNotaCredito.ToolTip = "Elegir Nota de Crédito";
            this.tSBNotaCredito.Visible = false;
            this.tSBNotaCredito.AceptarClick += tSBNotaCredito_AceptarClick;
            #endregion Inicializar TextSearchBoxes

            #region Datetime Picker
            this.dtpFechaPago.Format = DateTimePickerFormat.Short;
            #endregion Datetime Picker
                        
            //this.tSBCliente.Clear();
            this.FormEditStatus = BROWSE;
            this.HandletSBRespCobroExterior();
            //this.tSBCliente.Focus();
        }

        private void FCargaMasivaPagos_Load(object sender, EventArgs e)
        {
            this.tbCargaMasivaPagos_SelectedIndexChanged(sender, e);
            this.dtpFechaDeposito.Format = DateTimePickerFormat.Short;
            this.dtpFechaPago.Value = System.DateTime.Now;
            this.txtFechaPago.Text = System.DateTime.Now.ToShortDateString();
            this.txtMontoPago.Text = "0,00";
            this.tSBNotaCredito.Visible = false;
            this.txtNotaCreditoCuerpo.ReadOnly = true;
            this.txtNotaCreditoCuerpo.BackColor = SystemColors.Control;
            this.txtReferenciaNotaCredito.ReadOnly = true;
            this.txtReferenciaNotaCredito.BackColor = SystemColors.Control;
            this.FormEditStatus = INSERT;
        }

        private void ConfigTabs()
        {
            this.tbCargaMasivaPagos.Appearance = TabAppearance.Logical;
            this.CantTabs = this.tbCargaMasivaPagos.TabPages.Count;

            #region Tab Filtros
            this.lblFiltros.Text = "Ingrese datos comunes de los pagos";
            #endregion Tab Filtros

            #region Tab Selección
            this.lblTitulo.Text = "Asistente para Carga de Pagos";
            this.lblSeleccion.Text = "Seleccione los documentos incluidos en la carga masiva";
            #endregion Tab Selección
        }

        #endregion Métodos de Inicio

        #region Picks

        #region Cliente
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
            }
            fPickCliente.MostrarFiltro();
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
            int ClienteID = Convert.ToInt32(this.tSBCliente.KeyMember);

            fPickCliente.Close();
            fPickCliente.Dispose();

            #region Verificar si tiene notas crédito de presupuestos disponibles
            this.ExistenNCConSaldo = this.ExisteNotaCreditoConSaldo(ClienteID, this.DBContext);
            if (this.ExistenNCConSaldo)
            {
                MessageBox.Show("El cliente cuenta con Notas de Crédito de Presupuesto disponibles.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }
            #endregion Verificar si tiene notas crédito de presupuestos disponibles

            //if (this.tSBCliente.KeyMember != "")
            //{
            //    int clienteID = Convert.ToInt32(this.tSBCliente.KeyMember);
            //    List<Cliente> cli = this.DBContext.Cliente.Where(a => a.ID == clienteID).ToList();

            //    if (cli.Count > 0)
            //    {
            //        this.txtRazonSocialFactura.Text = cli.First().Nombre;
            //        this.txtRUC.Text = cli.First().RUC;
            //    }
            //}
        }
        #endregion Cliente

        #region Forma de Pago
        private void tSBFormaPago_KeyMemberTextChanged(object sender, EventArgs e)
        {
            this.HandletSBRespCobroExterior();
        }

        private void HandletSBRespCobroExterior()
        {
            this.tSBRespCobroExterior.Editable = ((this.FormEditStatus != BROWSE)
                                                    && (this.tSBFormaPago.KeyMember.Trim() != String.Empty)
                                                    && (Convert.ToInt32(this.tSBFormaPago.KeyMember) == FORMAPAGO_COBRO_EN_EL_EXTERIOR));
        }

        private void tSBFormaPago_AceptarClick(object sender, EventArgs e)
        {
            if (fPickFormaPago == null)
            {
                fPickFormaPago = new frmPickBase();
                fPickFormaPago.AceptarFiltrarClick += fPickFormaPago_AceptarFiltrarClick;
                fPickFormaPago.FiltrarClick += fPickFormaPago_FiltrarClick;
                fPickFormaPago.Titulo = "Elegir Forma de Pago";
                fPickFormaPago.CampoIDNombre = "fp_formadepagoid";
                fPickFormaPago.CampoDescripNombre = "fp_descripcion";
                fPickFormaPago.LabelCampoID = "ID";
                fPickFormaPago.LabelCampoDescrip = "Nombre";
                fPickFormaPago.NombreCampo = "Forma Pago";
                fPickFormaPago.PermitirFiltroNulo = true;
            }
            fPickFormaPago.MostrarFiltro();
            this.fPickFormaPago_FiltrarClick(sender, e);
        }

        private void fPickFormaPago_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickFormaPago != null)
            {
                fPickFormaPago.LoadData<fp_formadepago>(this.DBContext.fp_formadepago, fPickFormaPago.GetWhereString());
            }
        }

        private void fPickFormaPago_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBFormaPago.DisplayMember = fPickFormaPago.ValorDescrip;
            this.tSBFormaPago.KeyMember = fPickFormaPago.ValorID;

            fPickFormaPago.Close();
            fPickFormaPago.Dispose();

            if ((Convert.ToInt32(this.tSBFormaPago.KeyMember) == FORMAPAGO_NOTACREDITOPRESUPUESTO) && (this.ExistenNCConSaldo))
            {
                this.tSBNotaCredito.Visible = true;
                this.txtNotaCreditoNro.Visible = false;
                this.txtReferenciaNotaCredito.ReadOnly = true;
                this.txtReferenciaNotaCredito.BackColor = SystemColors.Control;
                this.txtNotaCreditoCuerpo.ReadOnly = true;
                this.txtNotaCreditoCuerpo.BackColor = SystemColors.Control;
            }
            else
            {
                this.tSBNotaCredito.Visible = false;
                this.txtNotaCreditoNro.Visible = true;
                this.txtReferenciaNotaCredito.ReadOnly = false;
                this.txtReferenciaNotaCredito.BackColor = SystemColors.Window;
                this.txtNotaCreditoCuerpo.ReadOnly = false;
                this.txtNotaCreditoCuerpo.BackColor = SystemColors.Window;
            }
            this.txtFechaNotaCredito.Text = "";
            this.txtNotaCreditoNro.Text = "";
            this.txtIdNotaCredito.Text = "";
            this.txtNCSaldo.Text = "";
            this.txtNCTotal.Text = "";
            this.txtNotaCreditoCuerpo.Text = "";
            this.txtReferenciaNotaCredito.Text = "";
        }
        #endregion Forma de Pago

        #region Responsable Cobro en el Exterior
        private void tSBRespCobroExterior_AceptarClick(object sender, EventArgs e)
        {
            if (fPickRespCobroExterior == null)
            {
                fPickRespCobroExterior = new frmPickBase();
                fPickRespCobroExterior.AceptarFiltrarClick += fPickRespCobroExterior_AceptarFiltrarClick;
                fPickRespCobroExterior.FiltrarClick += fPickRespCobroExterior_FiltrarClick;
                fPickRespCobroExterior.Titulo = "Elegir Responsable de Cobro en el Exterior";
                fPickRespCobroExterior.CampoIDNombre = "ID";
                fPickRespCobroExterior.CampoDescripNombre = "NombrePIla";
                fPickRespCobroExterior.LabelCampoID = "ID";
                fPickRespCobroExterior.LabelCampoDescrip = "Nombre";
                fPickRespCobroExterior.NombreCampo = "Resp. Cobro";
                fPickRespCobroExterior.PermitirFiltroNulo = true;
            }
            fPickRespCobroExterior.MostrarFiltro();
        }

        private void fPickRespCobroExterior_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickRespCobroExterior != null)
            {
                fPickRespCobroExterior.LoadData<Usuario>(this.DBContext.Usuario, fPickRespCobroExterior.GetWhereString());
            }
        }

        private void fPickRespCobroExterior_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBRespCobroExterior.DisplayMember = fPickRespCobroExterior.ValorDescrip;
            this.tSBRespCobroExterior.KeyMember = fPickRespCobroExterior.ValorID;

            fPickRespCobroExterior.Close();
            fPickRespCobroExterior.Dispose();
        }
        #endregion Responsable Cobro en el Exterior

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

        #region Banco Depósito
        private void tSBBancoDeposito_AceptarClick(object sender, EventArgs e)
        {
            if (fPickBancoDeposito == null)
            {
                fPickBancoDeposito = new frmPickBase();
                fPickBancoDeposito.AceptarFiltrarClick += fPickBancoDeposito_AceptarFiltrarClick;
                fPickBancoDeposito.FiltrarClick += fPickBancoDeposito_FiltrarClick;
                fPickBancoDeposito.Titulo = "Elegir Banco Déposito";
                fPickBancoDeposito.CampoIDNombre = "ba_bancoid";
                fPickBancoDeposito.CampoDescripNombre = "ba_descripcion";
                fPickBancoDeposito.LabelCampoID = "ID";
                fPickBancoDeposito.LabelCampoDescrip = "Nombre";
                fPickBancoDeposito.NombreCampo = "Banco";
                fPickBancoDeposito.PermitirFiltroNulo = true;
            }
            fPickBancoDeposito.MostrarFiltro();
            this.fPickBancoDeposito_FiltrarClick(sender, e);
        }

        private void fPickBancoDeposito_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickBancoDeposito != null)
            {
                fPickBancoDeposito.LoadData<ba_banco>(this.DBContext.ba_banco, fPickBancoDeposito.GetWhereString());
            }
        }

        private void fPickBancoDeposito_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBBancoDeposito.DisplayMember = fPickBancoDeposito.ValorDescrip;
            this.tSBBancoDeposito.KeyMember = fPickBancoDeposito.ValorID;

            fPickBancoDeposito.Close();
            fPickBancoDeposito.Dispose();
        }
        #endregion Banco Depósito

        #region Cuenta Depósito
        private void tSBCuentaDeposito_AceptarClick(object sender, EventArgs e)
        {
            if (this.tSBBancoDeposito.KeyMember == "")
            {
                MessageBox.Show("Debe ingresar un banco válido.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (fPickCuentaDeposito == null)
            {
                fPickCuentaDeposito = new frmPickBase();
                fPickCuentaDeposito.AceptarFiltrarClick += fPickCuentaDeposito_AceptarFiltrarClick;
                fPickCuentaDeposito.FiltrarClick += fPickCuentaDeposito_FiltrarClick;
                fPickCuentaDeposito.Titulo = "Elegir Cuenta Déposito";
                fPickCuentaDeposito.CampoIDNombre = "CuentaID";
                fPickCuentaDeposito.CampoDescripNombre = "CuentaDescripcion";
                fPickCuentaDeposito.LabelCampoID = "ID";
                fPickCuentaDeposito.LabelCampoDescrip = "Descripción";
                fPickCuentaDeposito.NombreCampo = "Cuenta";
                fPickCuentaDeposito.PermitirFiltroNulo = true;
            }
            fPickCuentaDeposito.MostrarFiltro();
            this.fPickCuentaDeposito_FiltrarClick(sender, e);
        }

        private void fPickCuentaDeposito_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickCuentaDeposito != null)
            {
                int bancoID = Convert.ToInt32(this.tSBBancoDeposito.KeyMember);
                int monedaID = Convert.ToInt32(this.tSBMoneda.KeyMember);
                var query = (from cb in this.DBContext.cb_cuentabanco
                             select new CuentaType
                             {
                                 CuentaID = cb.cb_cuentabancoid,
                                 CuentaDescripcion = cb.cb_descripcion,
                                 BancoID = cb.cb_bancoid,
                                 MonedaID = cb.cb_monedaid
                             }).Where(a => a.BancoID == bancoID && a.MonedaID == monedaID);

                fPickCuentaDeposito.LoadData<CuentaType>(query.AsQueryable(), fPickCuentaDeposito.GetWhereString());
            }
        }

        private void fPickCuentaDeposito_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBCuentaDeposito.DisplayMember = fPickCuentaDeposito.ValorDescrip;
            this.tSBCuentaDeposito.KeyMember = fPickCuentaDeposito.ValorID;

            fPickCuentaDeposito.Close();
            fPickCuentaDeposito.Dispose();
        }
        #endregion Cuenta Depósito

        #region Banco Cheque
        private void tSBBancoCheque_AceptarClick(object sender, EventArgs e)
        {
            if (fPickBancoCheque == null)
            {
                fPickBancoCheque = new frmPickBase();
                fPickBancoCheque.AceptarFiltrarClick += fPickBancoCheque_AceptarFiltrarClick;
                fPickBancoCheque.FiltrarClick += fPickBancoCheque_FiltrarClick;
                fPickBancoCheque.Titulo = "Elegir Banco Cheque";
                fPickBancoCheque.CampoIDNombre = "ba_bancoid";
                fPickBancoCheque.CampoDescripNombre = "ba_descripcion";
                fPickBancoCheque.LabelCampoID = "ID";
                fPickBancoCheque.LabelCampoDescrip = "Nombre";
                fPickBancoCheque.NombreCampo = "Banco";
                fPickBancoCheque.PermitirFiltroNulo = true;
            }
            fPickBancoCheque.MostrarFiltro();
            this.fPickBancoCheque_FiltrarClick(sender, e);
        }

        private void fPickBancoCheque_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickBancoCheque != null)
            {
                fPickBancoCheque.LoadData<ba_banco>(this.DBContext.ba_banco, fPickBancoCheque.GetWhereString());
            }
        }

        private void fPickBancoCheque_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBBancoCheque.DisplayMember = fPickBancoCheque.ValorDescrip;
            this.tSBBancoCheque.KeyMember = fPickBancoCheque.ValorID;

            fPickBancoCheque.Close();
            fPickBancoCheque.Dispose();
        }
        #endregion Banco Cheque

        #region Moneda Gasto Bancario
        private void tSBMonedaGastoBancario_AceptarClick(object sender, EventArgs e)
        {
            if (fPickMonedaGastoBancario == null)
            {
                fPickMonedaGastoBancario = new frmPickBase();
                fPickMonedaGastoBancario.AceptarFiltrarClick += fPickMonedaGastoBancario_AceptarFiltrarClick;
                fPickMonedaGastoBancario.FiltrarClick += fPickMonedaGastoBancario_FiltrarClick;
                fPickMonedaGastoBancario.Titulo = "Elegir Moneda";
                fPickMonedaGastoBancario.CampoIDNombre = "ID";
                fPickMonedaGastoBancario.CampoDescripNombre = "Descripcion";
                fPickMonedaGastoBancario.LabelCampoID = "ID";
                fPickMonedaGastoBancario.LabelCampoDescrip = "Descripción";
                fPickMonedaGastoBancario.NombreCampo = "Moneda";
                fPickMonedaGastoBancario.PermitirFiltroNulo = true;
            }
            fPickMonedaGastoBancario.MostrarFiltro();
            this.fPickMonedaGastoBancario_FiltrarClick(sender, e);
        }

        private void fPickMonedaGastoBancario_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickMonedaGastoBancario != null)
            {
                fPickMonedaGastoBancario.LoadData<Moneda>(this.DBContext.Moneda, fPickMonedaGastoBancario.GetWhereString());
            }
        }

        private void fPickMonedaGastoBancario_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBMonedaGastoBancario.DisplayMember = fPickMonedaGastoBancario.ValorDescrip;
            this.tSBMonedaGastoBancario.KeyMember = fPickMonedaGastoBancario.ValorID;

            fPickMonedaGastoBancario.Close();
            fPickMonedaGastoBancario.Dispose();
        }
        #endregion Moneda

        #region Nota Crédito
        private void tSBNotaCredito_AceptarClick(object sender, EventArgs e)
        {
            if (fPickNotaCredito == null)
            {
                fPickNotaCredito = new frmPickBase();
                fPickNotaCredito.AceptarFiltrarClick += fPickNotaCredito_AceptarFiltrarClick;
                fPickNotaCredito.FiltrarClick += fPickNotaCredito_FiltrarClick;
                fPickNotaCredito.Titulo = "Elegir Nota Crédito";
                fPickNotaCredito.CampoIDNombre = "NotaCreditoID";
                fPickNotaCredito.CampoDescripNombre = "NotaCreditoDescripcion";
                fPickNotaCredito.LabelCampoID = "ID";
                fPickNotaCredito.LabelCampoDescrip = "Descripción";
                fPickNotaCredito.NombreCampo = "N. Crédito";
                fPickNotaCredito.PermitirFiltroNulo = true;
            }
            fPickNotaCredito.MostrarFiltro();
            this.fPickNotaCredito_FiltrarClick(sender, e);
        }

        private void fPickNotaCredito_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickNotaCredito != null)
            {
                int clienteID = Convert.ToInt32(this.tSBCliente.KeyMember);
                int monedaID = Convert.ToInt32(this.tSBMoneda.KeyMember);

                var query = this.DBContext.ncp_notacreditopresup
                             .Where(a => a.ncp_clienteid == clienteID
                                    && a.ncp_anulado != true
                                    && a.ncp_saldo > 0
                                    && a.ncp_monedaid == monedaID)
                             .ToList()
                             .Select(x => new NotaCreditoSelectType()
                             {
                                 NotaCreditoID = x.ncp_notacreditoid,
                                 NotaCreditoDescripcion = x.ncp_nrocomprobante.ToString() + ": " + x.ncp_cuerponota + " - " + x.ncp_presupuestos,
                                 Anulado = x.ncp_anulado,
                                 Saldo = x.ncp_saldo,
                                 ClienteID = x.ncp_clienteid,
                                 MonedaID = x.ncp_monedaid
                             });



                fPickNotaCredito.LoadData<NotaCreditoSelectType>(query.AsQueryable(), fPickNotaCredito.GetWhereString());

            }
        }

        private void fPickNotaCredito_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBNotaCredito.DisplayMember = fPickNotaCredito.ValorDescrip;
            this.tSBNotaCredito.KeyMember = fPickNotaCredito.ValorID;
            this.txtNotaCreditoNro.Text = fPickNotaCredito.ValorDescrip.Split(':')[0];
            this.txtIdNotaCredito.Text = fPickNotaCredito.ValorID;

            fPickNotaCredito.Close();
            fPickNotaCredito.Dispose();

            int ncID = Convert.ToInt32(this.txtIdNotaCredito.Text);
            ncp_notacreditopresup ncp = this.DBContext.ncp_notacreditopresup.First(a => a.ncp_notacreditoid == ncID);
            this.txtNCSaldo.Text = String.Format("{0:0.00}", ncp.ncp_saldo);
            this.txtNCTotal.Text = String.Format("{0:0.00}", ncp.ncp_monto);
            this.txtNotaCreditoCuerpo.Text = ncp.ncp_cuerponota;
            this.txtReferenciaNotaCredito.Text = ncp.ncp_referenciacliente;
            this.lblNCTotal.Visible = true;
            this.txtNCTotal.Visible = true;
            this.lblNCSaldo.Visible = true;
            this.txtNCSaldo.Visible = true;
            //this.lblIDNotaCredito.Visible = true;
            //this.txtIdNotaCredito.Visible = true;
            this.txtFechaNotaCredito.ReadOnly = true;
            this.dtpFechaNotaCredito.Enabled = false;
            this.txtNotaCreditoCuerpo.ReadOnly = true;
            this.txtReferenciaNotaCredito.ReadOnly = true;
        }
        #endregion Nota Crédito

        #endregion Picks

        #region Métodos sobre controles
        private void dgvPresupuestos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvPresupuestos.Columns[e.ColumnIndex].Name == CAMPO_SELECCIONAR)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)this.dgvPresupuestos.Rows[e.RowIndex].Cells[CAMPO_SELECCIONAR];
                decimal saldoG = Convert.ToDecimal(this.txtSaldo.Text);

                if ((saldoG <= 0) && ((Boolean)checkCell.Value))
                {
                    checkCell.Value = false;
                    MessageBox.Show("Ya no queda saldo disponible.",
                                    "Atención Requerida",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    return;
                }


                PresupuestoCargaMasivaPagos obj = (PresupuestoCargaMasivaPagos)this.dgvPresupuestos.Rows[e.RowIndex].DataBoundItem;

                if ((Boolean)checkCell.Value)
                {
                    decimal importe = (decimal)this.dgvPresupuestos.Rows[e.RowIndex].Cells[CAMPO_SALDO].Value;

                    //Pago parcial
                    if (importe > saldoG)
                    {
                        obj.Importe = saldoG;
                        importe = saldoG;
                    }
                    else
                        obj.Importe = importe;

                    decimal totalSeleccion = Convert.ToDecimal(this.txtTotalSeleccion.Text) + importe;
                    decimal saldo = Convert.ToDecimal(this.txtTotal.Text) - totalSeleccion;
                    this.txtTotalSeleccion.Text = String.Format("{0:0.00}", totalSeleccion);
                    this.txtSaldo.Text = String.Format("{0:0.00}", saldo);
                }
                else
                {
                    if (obj.Importe > 0)
                    {
                        decimal importe = (decimal)this.dgvPresupuestos.Rows[e.RowIndex].Cells[CAMPO_SALDO].Value;
                        decimal totalSeleccion = Convert.ToDecimal(this.txtTotalSeleccion.Text) - (decimal)obj.Importe;
                        //decimal saldo = Convert.ToDecimal(this.txtTotal.Text) - totalSeleccion;
                        decimal saldo = Convert.ToDecimal(this.txtSaldo.Text) + (decimal)obj.Importe;
                        this.txtTotalSeleccion.Text = String.Format("{0:0.00}", totalSeleccion);
                        this.txtSaldo.Text = String.Format("{0:0.00}", saldo);
                        obj.Importe = 0;
                    }
                }
                this.dgvPresupuestos.Update();
            }
        }

        private void tbCargaMasivaPagos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tbCargaMasivaPagos.SelectedIndex == 0)
            {
                this.btnCancelar.Enabled = true;
                this.btnAtras.Enabled = false;
                this.btnSiguiente.Enabled = true;
                this.btnFinalizar.Enabled = false;
            }
            else if (this.tbCargaMasivaPagos.SelectedIndex == this.CantTabs - 1)
            {
                this.btnCancelar.Enabled = true;
                this.btnAtras.Enabled = true;
                this.btnSiguiente.Enabled = false;
                this.btnFinalizar.Enabled = true;
            }
            else if (this.tbCargaMasivaPagos.SelectedIndex < this.CantTabs - 1)
            {
                this.btnCancelar.Enabled = true;
                this.btnAtras.Enabled = true;
                this.btnSiguiente.Enabled = true;
                this.btnFinalizar.Enabled = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            string caption = "Cancelación de Carga Masiva de Pagos";
            string message = "Se cancelará la operación de Carga Masiva de Pagos ¿Está seguro?";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(DialogHandler));
        }

        

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (this.tbCargaMasivaPagos.SelectedIndex - 1 == 0)
            {
                string caption = "Atención Requerida";
                string message = "Al volver a la pantalla anterior, todas las selecciones hechas se perderán. " + Environment.NewLine +
                                 "¿Desea continuar?";

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBox.Show(message, caption, buttons,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                                new EventHandler(DialogHandlerAtras));
            }

            //this.tbCargaMasivaPagos.SelectedIndex = this.tbCargaMasivaPagos.SelectedIndex - 1;
        }


        private void DialogHandlerProcesar(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    this.ProcesarPagos();
                }

            }
        }

        private void DialogHandlerOK(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.OK)
                {
                    this.Close();
                }

            }
        }

        private void DialogHandler(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    this.Close();
                }

            }
        }

        private void DialogHandlerAtras(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    this.tbCargaMasivaPagos.SelectedIndex = this.tbCargaMasivaPagos.SelectedIndex - 1;
                }

            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            switch (this.tbCargaMasivaPagos.SelectedIndex)
            {
                case 0:
                    #region Validaciones
                    if (this.tSBCliente.KeyMember == "")
                    {
                        MessageBox.Show("Debe especificar un cliente obligatoriamente.",
                                        "Atención Requerida",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (this.tSBFormaPago.KeyMember == "")
                    {
                        MessageBox.Show("Debe indicar una forma de pago obligatoriamente.",
                                        "Atención Requerida",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (this.tSBMoneda.KeyMember == "")
                    {
                        MessageBox.Show("Debe indicar una moneda de pago obligatoriamente.",
                                        "Atención Requerida",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (this.txtFechaPago.Text == "")
                    {
                        MessageBox.Show("Debe indicar la fecha de pago obligatoriamente.",
                                        "Atención Requerida",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (this.txtMontoPago.Text == "")
                    {
                        MessageBox.Show("Debe ingresar un monto de pago válido.",
                                        "Información",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);

                        return;
                    }

                    if (((this.txtFechaRecibo.Text == "") && (this.txtNroRecibo.Text != "")) ||
                        ((this.txtFechaRecibo.Text != "") && (this.txtNroRecibo.Text == "")))
                    {
                        MessageBox.Show("Debe ingresar fecha y número de recibo.",
                                        "Información",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);

                        return;
                    }

                    if ((this.tSBFormaPago.KeyMember != "") &&
                        (Convert.ToInt32(this.tSBFormaPago.KeyMember) != FORMAPAGO_NOTACREDITOPRESUPUESTO))
                    {
                        if (((this.txtFechaNotaCredito.Text == "") && (this.txtNotaCreditoNro.Text != "")) ||
                            ((this.txtFechaNotaCredito.Text != "") && (this.txtNotaCreditoNro.Text == "")))
                        {
                            MessageBox.Show("Debe ingresar fecha y número de nota de crédito.",
                                            "Información",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);

                            return;
                        }
                    }

                    if (((this.tSBMonedaGastoBancario.KeyMember == "") && (this.txtGastoBancario.Text != "")) ||
                        ((this.tSBMonedaGastoBancario.KeyMember != "") && (this.txtGastoBancario.Text == "")))
                    {
                        MessageBox.Show("Debe ingresar una moneda y monto de gasto válida.",
                                       "Información",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Information);
                        return;
                    }

                    if ((this.tSBFormaPago.KeyMember != "") &&
                        (Convert.ToInt32(this.tSBFormaPago.KeyMember) == FORMAPAGO_NOTACREDITOPRESUPUESTO))
                    {
                        if ((this.tSBNotaCredito.KeyMember != "")
                                && (Convert.ToDecimal(this.txtNCSaldo.Text.Replace('.', ',')) < Convert.ToDecimal(this.txtMontoPago.Text.Replace('.', ','))))
                        {
                            MessageBox.Show("El monto de pago no puede ser mayor al saldo de la nota de crédito seleccionada",
                                            "Información",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);

                            return;
                        }
                    }

                    #endregion Validaciones

                    this.GetPresupuestos();

                    break;
            
            }

            this.tbCargaMasivaPagos.SelectedIndex = this.tbCargaMasivaPagos.SelectedIndex + 1;
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(this.txtSaldo.Text) != 0)
            {
                MessageBox.Show("Debe asignar todo el saldo disponible, para finalizar el pago múltiple" +  Environment.NewLine +
                                "el saldo debe ser 0 (cero).",
                                "Atención Requerida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }

            string caption = "Procesamiento de Pago Múltiple";
            string message = "Se procederá al procesamiento del Pago Múltiple ¿Está seguro?";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(DialogHandlerProcesar));

            //this.Close();
        }

        private void dtpFechaPago_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaPago.Text = this.dtpFechaPago.Value.ToShortDateString();
        }

        private void dtpFechaDeposito_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaDeposito.Text = this.dtpFechaDeposito.Value.ToShortDateString();
        }

        private void dtpFechaRecibo_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaRecibo.Text = this.dtpFechaRecibo.Value.ToShortDateString();
        }

        private void dtpFechaNotaCredito_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaNotaCredito.Text = this.dtpFechaNotaCredito.Value.ToShortDateString();
        }
        #endregion Métodos sobre controles

        #region Métodos Locales
        private bool ExisteNotaCreditoConSaldo(int ClienteID, BerkeDBEntities context)
        {
            bool Result = false;
            List<ncp_notacreditopresup> listNCP = context.ncp_notacreditopresup.Where(a => a.ncp_clienteid == ClienteID
                                                                                      && a.ncp_anulado != true
                                                                                      && a.ncp_saldo > 0).ToList();
            if (listNCP.Count > 0)
                Result = true;

            return Result;

        }

        private void GetPresupuestos()
        {
            int ClienteID = Convert.ToInt32(this.tSBCliente.KeyMember);
            int MonedaID = Convert.ToInt32(this.tSBMoneda.KeyMember);
            var query = (from pCab in this.DBContext.pc_presupuestocab
                         join mon in this.DBContext.Moneda
                            on pCab.pc_monedaid equals mon.ID
                         select new PresupuestoCargaMasivaPagos
                         {
                             PresupuestoID = pCab.pc_presupuestocabid,
                             FechaGeneracion = pCab.pc_fechageneracion,
                             DocumentoNro = this.DBContext.GetDocumentoNro(pCab.pc_presupuestocabid).FirstOrDefault(),
                             ClienteID = pCab.pc_clienteid,
                             MonedaID = pCab.pc_monedaid,
                             MonedaAbrev = mon.AbrevMoneda,
                             Monto = pCab.pc_total,
                             Saldo = pCab.pc_saldo,
                             Importe = 0,
                             Estado = pCab.pc_estado
                         })
                         .Where(a => a.Estado != ESTADO_ANULADO && a.Saldo > 0 && a.ClienteID == ClienteID && a.MonedaID == MonedaID)
                         .OrderBy(a => a.FechaGeneracion)
                         .ToList();

            this.dgvPresupuestos.DataSource = query;
            this.txtTotal.Text = String.Format("{0:0.00}", Convert.ToDecimal(this.txtMontoPago.Text.Replace('.',',')));
            this.txtTotalSeleccion.Text = String.Format("{0:0.00}", 0);
            this.txtSaldo.Text = String.Format("{0:0.00}", Convert.ToDecimal(this.txtMontoPago.Text.Replace('.', ',')));
            this.FormatearGrilla();
        }

        private void FormatearGrilla()
        {
            foreach (DataGridViewColumn col in dgvPresupuestos.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            this.dgvPresupuestos.ReadOnly = false;
            this.dgvPresupuestos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPresupuestos.ItemsPerPage = 12;
            this.dgvPresupuestos.ShowCellToolTips = true;
            this.dgvPresupuestos.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvPresupuestos.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvPresupuestos.DefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvPresupuestos.DefaultCellStyle.BackColor = Color.Transparent;

            this.dgvPresupuestos.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;

            int displayIndex = 0;

            this.dgvPresupuestos.Columns[CAMPO_FECHAGENERACION].Visible = true;
            this.dgvPresupuestos.Columns[CAMPO_FECHAGENERACION].DisplayIndex = displayIndex;
            this.dgvPresupuestos.Columns[CAMPO_FECHAGENERACION].HeaderText = "Fecha Doc.";
            this.dgvPresupuestos.Columns[CAMPO_FECHAGENERACION].Width = 85;
            this.dgvPresupuestos.Columns[CAMPO_FECHAGENERACION].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            displayIndex++;

            this.dgvPresupuestos.Columns[CAMPO_DOCUMENTONRO].Visible = true;
            this.dgvPresupuestos.Columns[CAMPO_DOCUMENTONRO].DisplayIndex = displayIndex;
            this.dgvPresupuestos.Columns[CAMPO_DOCUMENTONRO].HeaderText = "N° Documento";
            this.dgvPresupuestos.Columns[CAMPO_DOCUMENTONRO].Width = 100;
            this.dgvPresupuestos.Columns[CAMPO_DOCUMENTONRO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            displayIndex++;

            this.dgvPresupuestos.Columns[CAMPO_ABREVMONEDA].Visible = true;
            this.dgvPresupuestos.Columns[CAMPO_ABREVMONEDA].DisplayIndex = displayIndex;
            this.dgvPresupuestos.Columns[CAMPO_ABREVMONEDA].HeaderText = "Moneda";
            this.dgvPresupuestos.Columns[CAMPO_ABREVMONEDA].Width = 75;
            this.dgvPresupuestos.Columns[CAMPO_ABREVMONEDA].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            displayIndex++;

            this.dgvPresupuestos.Columns[CAMPO_MONTO].Visible = true;
            this.dgvPresupuestos.Columns[CAMPO_MONTO].DisplayIndex = displayIndex;
            this.dgvPresupuestos.Columns[CAMPO_MONTO].HeaderText = "Deuda";
            this.dgvPresupuestos.Columns[CAMPO_MONTO].Width = 85;
            this.dgvPresupuestos.Columns[CAMPO_MONTO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            displayIndex++;

            this.dgvPresupuestos.Columns[CAMPO_SALDO].Visible = true;
            this.dgvPresupuestos.Columns[CAMPO_SALDO].DisplayIndex = displayIndex;
            this.dgvPresupuestos.Columns[CAMPO_SALDO].HeaderText = "Saldo";
            this.dgvPresupuestos.Columns[CAMPO_SALDO].Width = 85;
            this.dgvPresupuestos.Columns[CAMPO_SALDO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            displayIndex++;

            this.dgvPresupuestos.Columns[CAMPO_IMPORTE].Visible = true;
            this.dgvPresupuestos.Columns[CAMPO_IMPORTE].DisplayIndex = displayIndex;
            this.dgvPresupuestos.Columns[CAMPO_IMPORTE].HeaderText = "Importe Pago";
            this.dgvPresupuestos.Columns[CAMPO_IMPORTE].Width = 100;
            this.dgvPresupuestos.Columns[CAMPO_IMPORTE].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvPresupuestos.Columns[CAMPO_IMPORTE].DefaultCellStyle.Font = new Font("Arial", 9.5F, FontStyle.Bold, GraphicsUnit.Pixel);
            displayIndex++;

            DataGridViewCheckBoxColumn doWork = new DataGridViewCheckBoxColumn();
            doWork.HeaderText = CAMPO_SELECCIONAR;
            doWork.Name = CAMPO_SELECCIONAR;
            doWork.FalseValue = false;
            doWork.TrueValue = true;
            doWork.ReadOnly = false;
            doWork.Width = 80;
            this.dgvPresupuestos.Columns.Insert(0, doWork);
        }

        private void ProcesarPagos()
        {
            bool success = false;
            bool mostrarNC = false;

            pmu_pagomultiple pmu = null;
            object[] notaCredito = null;

            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        pmu = this.guardarPagoMultiple(context);
                        context.SaveChanges();

                        List<string> ListaPresupuestos = new List<string>();
                        Hashtable hashPagosCabID = new Hashtable();

                        foreach (DataGridViewRow row in this.dgvPresupuestos.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells[CAMPO_SELECCIONAR].Value))
                            {
                                pp_pagopresupuesto pp = null;
                                pp = this.guardarPago((Int32)row.Cells[CAMPO_PRESUPUESTOID].Value,
                                                      (decimal)row.Cells[CAMPO_IMPORTE].Value,
                                                      pmu.pmu_pagomultipleid,
                                                      context);
                                context.SaveChanges();

                                #region Datos para Nota Crédito Presupuesto
                                if (Convert.ToInt32(this.tSBFormaPago.KeyMember) == FORMAPAGO_NOTACREDITOPRESUPUESTO)
                                {
                                    hashPagosCabID.Add(pp.pp_pagopresupuestoid, pp.pp_montopago);
                                    ListaPresupuestos.Add(pp.pp_presupuestocabid.ToString());
                                }
                                #endregion Datos para Nota Crédito Presupuesto
                            }
                        }

                        #region Generar Nota Crédito Presupuesto
                        if (Convert.ToInt32(this.tSBFormaPago.KeyMember) == FORMAPAGO_NOTACREDITOPRESUPUESTO)
                        {
                            #region Caso Creación de Nota Crédito con Pago
                            if (this.tSBNotaCredito.KeyMember == "")
                            {
                                notaCredito = GenerarNotaCredito.CrearNotaCredito(context,
                                                                                  hashPagosCabID,
                                                                                  Convert.ToDecimal(this.txtMontoPago.Text.Replace('.', ',')),
                                                                                  Convert.ToInt32(this.tSBMoneda.KeyMember),
                                                                                  Convert.ToInt32(this.tSBCliente.KeyMember),
                                                                                  Convert.ToDateTime(this.txtFechaNotaCredito.Text),
                                                                                  ListaPresupuestos.ToArray(),
                                                                                  this.txtReferenciaNotaCredito.Text,
                                                                                  this.txtNotaCreditoCuerpo.Text);
                                List<ncd_notacreditopresupdetalle> listNC = new List<ncd_notacreditopresupdetalle>();
                                int NroNotaCredito = (int)notaCredito[0];
                                int NotaCreditoID = (int)notaCredito[1];
                                listNC = context.ncd_notacreditopresupdetalle.Where(a => a.ncd_notacreditocabid == NotaCreditoID).ToList();

                                foreach (ncd_notacreditopresupdetalle row in listNC)
                                {
                                    int PagoPresupuestoID = row.ncd_pagoid;
                                    pp_pagopresupuesto pp1 = context.pp_pagopresupuesto.First(a => a.pp_pagopresupuestoid == PagoPresupuestoID);
                                    pp1.pp_notacreditonro = NroNotaCredito.ToString();
                                    pp1.pp_notacreditopresupid = NotaCreditoID;
                                }
                                mostrarNC = true;
                            }
                            #endregion Caso Creación de Nota Crédito con Pago
                            #region Caso Asignación de Nota Crédito con Saldo ya existente
                            else
                            {
                                int NotaCreditoID = Convert.ToInt32(this.txtIdNotaCredito.Text);

                                foreach (DictionaryEntry entry in hashPagosCabID)
                                {
                                    int PagoPresupuestoID = (int)entry.Key;
                                    //Asignar Pago a Nota Crédito
                                    ncd_notacreditopresupdetalle ncd = new ncd_notacreditopresupdetalle();
                                    ncd.ncd_notacreditocabid = NotaCreditoID;
                                    ncd.ncd_pagoid = PagoPresupuestoID;
                                    ncd.ncd_monto = (decimal)entry.Value;
                                    context.ncd_notacreditopresupdetalle.Add(ncd);

                                    //Actualizar Pago con referencia a la nota crédito
                                    pp_pagopresupuesto pp1 = context.pp_pagopresupuesto.First(a => a.pp_pagopresupuestoid == PagoPresupuestoID);
                                    pp1.pp_notacreditonro = this.tSBNotaCredito.DisplayMember.Split(':')[0];
                                    pp1.pp_notacreditopresupid = NotaCreditoID;

                                    //Actualizar el saldo de la nota crédito
                                    context.ncp_notacreditopresup.First(a => a.ncp_notacreditoid == NotaCreditoID).ncp_saldo -= ncd.ncd_monto;

                                    context.SaveChanges();
                                }

                            }
                            #endregion Caso Asignación de Nota Crédito con Saldo ya existente
                            context.SaveChanges();
                        }
                        #endregion Generar Nota Crédito Presupuesto

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
                this.GetPresupuestos();
                //MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //if (Convert.ToInt32(this.tSBFormaPago.KeyMember) == FORMAPAGO_NOTACREDITOPRESUPUESTO)
                if (mostrarNC)
                {
                    NotaCreditoPresupType ncCuerpo = (NotaCreditoPresupType)notaCredito[2];
                    this.MostrarNotaCredito(new List<NotaCreditoPresupType>() { ncCuerpo });
                }
                else
                {
                    string caption = "Información";
                    string message = "Operación completada con éxito.";

                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons,
                                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                                    new EventHandler(DialogHandlerOK));
                }
            }
        }

        private pp_pagopresupuesto guardarPago(Int32 PresupuestoCabID, decimal Importe, Int32 PagoMultipleID, BerkeDBEntities context = null)
        {
            pp_pagopresupuesto pp = new pp_pagopresupuesto();

            #region EDIT
            if (this.FormEditStatus == EDIT)
            {
                int pagoID = -1;// Convert.ToInt32(this.txtPagoID.Text);

                pp = context.pp_pagopresupuesto.First(a => a.pp_pagopresupuestoid == pagoID);

                pp.pp_presupuestocabid = PresupuestoCabID;
                pp.pp_monedaid = Convert.ToInt32(this.tSBMoneda.KeyMember);

                if (this.tSBBancoDeposito.KeyMember != "")
                {
                    pp.pp_bancoid = Convert.ToInt32(this.tSBBancoDeposito.KeyMember);
                }
                else
                {
                    pp.pp_bancoid = null;
                }

                if (this.tSBCuentaDeposito.KeyMember != "")
                {
                    pp.pp_cuentaid = Convert.ToInt32(this.tSBCuentaDeposito.KeyMember);
                }
                else
                {
                    pp.pp_cuentaid = null;
                }

                pp.pp_formapagoid = Convert.ToInt32(this.tSBFormaPago.KeyMember);

                if (this.tSBRespCobroExterior.KeyMember != String.Empty)
                {
                    pp.pp_respcobroextid = Convert.ToInt32(this.tSBRespCobroExterior.KeyMember);
                }
                else
                {
                    pp.pp_respcobroextid = null;
                }

                pp.pp_fechapago = Convert.ToDateTime(this.txtFechaPago.Text);
                pp.pp_nrocheque = this.txtNroCheque.Text;

                if (this.tSBBancoCheque.KeyMember != "")
                {
                    pp.pp_bancochequeid = Convert.ToInt32(this.tSBBancoCheque.KeyMember);
                }
                else
                {
                    pp.pp_bancochequeid = null;
                }

                if (this.txtGastoBancario.Text != "")
                {
                    pp.pp_gastocambiario = Convert.ToDecimal(this.txtGastoBancario.Text.Replace('.', ','));
                }

                if (this.tSBMonedaGastoBancario.KeyMember != "")
                {
                    pp.pp_monedagastoid = Convert.ToInt32(this.tSBMonedaGastoBancario.KeyMember);
                }
                else
                {
                    pp.pp_monedagastoid = null;
                }

                pp.pp_montopago = Convert.ToDecimal(this.txtMontoPago.Text.Replace('.', ','));
                pp.pp_referencia = this.txtReferencia.Text;

                if (this.txtFechaDeposito.Text != "")
                    pp.pp_fechaboletadeposito = Convert.ToDateTime(this.txtFechaDeposito.Text);

                if (this.txtBoletaDepNro.Text.Trim() != String.Empty)
                    pp.pp_nroboletadeposito = this.txtBoletaDepNro.Text;

                if (this.txtFechaRecibo.Text != "")
                {
                    pp.pp_fecharecibo = Convert.ToDateTime(this.txtFechaRecibo.Text);
                    pp.pp_nrorecibo = this.txtNroRecibo.Text;
                }

                if (this.txtFechaNotaCredito.Text != "")
                {
                    pp.pp_fechanotacredito = Convert.ToDateTime(this.txtFechaNotaCredito.Text);
                    pp.pp_notacreditonro = this.txtNotaCreditoNro.Text;
                }

                pp.pp_pagomultipleid = PagoMultipleID;
            }
            #endregion EDIT

            #region INSERT
            else if (this.FormEditStatus == INSERT)
            {
                pp.pp_presupuestocabid = PresupuestoCabID;
                pp.pp_monedaid = Convert.ToInt32(this.tSBMoneda.KeyMember);

                if (this.tSBBancoDeposito.KeyMember != "")
                {
                    pp.pp_bancoid = Convert.ToInt32(this.tSBBancoDeposito.KeyMember);
                }
                else
                {
                    pp.pp_bancoid = null;
                }

                if (this.tSBCuentaDeposito.KeyMember != "")
                {
                    pp.pp_cuentaid = Convert.ToInt32(this.tSBCuentaDeposito.KeyMember);
                }
                else
                {
                    pp.pp_cuentaid = null;
                }

                pp.pp_formapagoid = Convert.ToInt32(this.tSBFormaPago.KeyMember);

                if (this.tSBRespCobroExterior.KeyMember != String.Empty)
                {
                    pp.pp_respcobroextid = Convert.ToInt32(this.tSBRespCobroExterior.KeyMember);
                }
                else
                {
                    pp.pp_respcobroextid = null;
                }

                pp.pp_fechapago = Convert.ToDateTime(this.txtFechaPago.Text);
                pp.pp_nrocheque = this.txtNroCheque.Text;

                if (this.tSBBancoCheque.KeyMember != "")
                {
                    pp.pp_bancochequeid = Convert.ToInt32(this.tSBBancoCheque.KeyMember);
                }
                else
                {
                    pp.pp_bancochequeid = null;
                }

                if (this.txtGastoBancario.Text != "")
                {
                    pp.pp_gastocambiario = Convert.ToDecimal(this.txtGastoBancario.Text.Replace('.', ','));
                }

                if (this.tSBMonedaGastoBancario.KeyMember != "")
                {
                    pp.pp_monedagastoid = Convert.ToInt32(this.tSBMonedaGastoBancario.KeyMember);
                }
                else
                {
                    pp.pp_monedagastoid = null;
                }

                pp.pp_montopago = Importe;
                pp.pp_referencia = this.txtReferencia.Text;

                if (this.txtFechaDeposito.Text != "")
                    pp.pp_fechaboletadeposito = Convert.ToDateTime(this.txtFechaDeposito.Text);

                if (this.txtBoletaDepNro.Text.Trim() != String.Empty)
                    pp.pp_nroboletadeposito = this.txtBoletaDepNro.Text;

                if (this.txtFechaRecibo.Text != "")
                {
                    pp.pp_fecharecibo = Convert.ToDateTime(this.txtFechaRecibo.Text);
                    pp.pp_nrorecibo = this.txtNroRecibo.Text;
                }

                if (this.txtFechaNotaCredito.Text != "")
                {
                    pp.pp_fechanotacredito = Convert.ToDateTime(this.txtFechaNotaCredito.Text);
                    pp.pp_notacreditonro = this.txtNotaCreditoNro.Text;
                }

                pp.pp_pagomultipleid = PagoMultipleID;

                context.pp_pagopresupuesto.Add(pp);
            }
            #endregion INSERT

            return pp;
        }

        private pmu_pagomultiple guardarPagoMultiple(BerkeDBEntities context = null)
        {
            pmu_pagomultiple pmu = new pmu_pagomultiple();
            #region EDIT
            if (this.FormEditStatus == EDIT)
            {
            }
            #endregion EDIT
            #region INSERT
            else if (this.FormEditStatus == INSERT)
            {
                pmu.pmu_clienteid = Convert.ToInt32(this.tSBCliente.KeyMember);
                pmu.pmu_formapagoid = Convert.ToInt32(this.tSBFormaPago.KeyMember);
                pmu.pmu_monedaid = Convert.ToInt32(this.tSBMoneda.KeyMember);
                pmu.pmu_montopago = Convert.ToDecimal(this.txtMontoPago.Text.Replace('.', ','));
                pmu.pmu_fechapago = Convert.ToDateTime(this.txtFechaPago.Text);
                pmu.pmu_referencia = this.txtReferencia.Text;

                context.pmu_pagomultiple.Add(pmu);
            }
            #endregion INSERT
            return pmu;
        }

        private void MostrarNotaCredito(List<NotaCreditoPresupType> ncCuerpo)
        {

            if (ncCuerpo.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte.",
                                "Atención Requerida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            ReportDataSource datasource = null;
            datasource = new ReportDataSource("DataSet1", ncCuerpo);

            int ClienteID = ncCuerpo.First().ClienteID;
            int IdiomaID = ncCuerpo.First().IdiomaID;

            string path = IdiomaID == IDIOMA_ESPANOL ? @"Reportes\RepNotaCreditoEsp.rdlc" : @"Reportes\RepNotaCreditoIng.rdlc";
            string asuntoMail = IdiomaID == IDIOMA_ESPANOL ? "Nota de Crédito N° " + ncCuerpo.First().NroNotaCredito : "Credit Note N° " + ncCuerpo.First().NroNotaCredito;
            string cuerpoMail = IdiomaID == IDIOMA_ESPANOL ? "Por favor revise el documento adjunto." : "Please check the attached document.";
            string nombreArchivo = IdiomaID == IDIOMA_ESPANOL ? "NotadeCredito-" : "CreditNote-";

            FReportViewerBase f = new FReportViewerBase(path, datasource, this.DBContext);
            f.FormClosed += delegate { f = null; this.Close(); };
            f.Titulo = "Nota de Crédito N° " + ncCuerpo.First().NroNotaCredito + " - " + ncCuerpo.First().NombreCliente + " (" + ClienteID.ToString() + ")";
            f.NombreArchivoAdjunto = nombreArchivo + ncCuerpo.First().NroNotaCredito + "-" + ClienteID.ToString();
            f.AsuntoMail = asuntoMail + " - " + ncCuerpo.First().NombreCliente + " (" + ClienteID.ToString() + ")";
            f.CuerpoMail = cuerpoMail;
            f.ShowDialog();
        }

        #endregion Métodos Locales

        private void tSBFormaPago_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.tSBFormaPago.KeyMember) == FORMAPAGO_NOTACREDITOPRESUPUESTO)
            {
                this.txtNotaCreditoNro.ReadOnly = true;
                this.txtFechaNotaCredito.Text = DateTime.Now.ToShortDateString();
                this.txtNotaCreditoNro.BackColor = SystemColors.Control;
            }
            else
            {
                this.txtNotaCreditoNro.ReadOnly = false;
                this.txtFechaNotaCredito.Text = "";
                this.txtNotaCreditoNro.BackColor = SystemColors.Window;
            }
        }

        private void txtFechaNotaCredito_TextChanged(object sender, EventArgs e)
        {

        }
    }
}