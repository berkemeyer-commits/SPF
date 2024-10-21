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

#endregion

namespace SPF.Forms.UI
{
    public partial class FCargarDatosRecaudacion : Form
    {
        #region Variables
        BerkeDBEntities DBContext;
        private DateTime fechaRetencion;
        private string numeroRetencion;
        private DatosRecaudacionesType datoRecaudacion;
        private int reciboIndex;
        private FormatoNumeroReciboType formatoNumeroRecibo;
        frmPickBase fPickCuentaDeposito;
        #endregion Variables

        #region Constantes
        private const string FORMATO_MONEDA_GUARANIES_GRILLA = "N0";
        private const string FORMATO_MONEDA_OTROS_GRILLA = "N2";
        private const string FORMATO_MONEDA_GUARANIES = "{0:N0}";
        private const string FORMATO_MONEDA_OTROS = "{0:N2}";
        private const int GUARANIES_MONEDA_ID = 3;
        private const int PAIS_PARAGUAY_ID = 91;
        #endregion Constantes

        #region Eventos Personalizados
        public event EventHandler AceptarClick;
        #endregion Eventos Personalizados

        #region Propiedades
        public DateTime FechaRetencion
        {
            set { this.fechaRetencion = value; }
            get { return this.fechaRetencion; }
        }

        public string NumeroRetencion
        {
            set { this.numeroRetencion = value; }
            get { return this.numeroRetencion; }
        }

        public DatosRecaudacionesType DatoRecaudacion
        {
            set { this.datoRecaudacion = value; }
            get { return this.datoRecaudacion; }
        }

        public int ReciboIndex
        {
            set { this.reciboIndex = value; }
            get { return this.reciboIndex; }
        }

        private FormatoNumeroReciboType FormatoNumeroRecibo
        {
            get { return this.formatoNumeroRecibo; }
            set { this.formatoNumeroRecibo = value; }
        }
        #endregion Propiedades

        public FCargarDatosRecaudacion()
        {
            InitializeComponent();
        }

        public FCargarDatosRecaudacion(string titulo, BerkeDBEntities context, DatosRecaudacionesType data, int index)
        {
            InitializeComponent();
            this.Text = titulo;
            this.DBContext = context;
            this.DatoRecaudacion = data;
            this.ReciboIndex = index;
            this.SetFormatoNumero();

            #region TextSearchBox
            this.tSBCuentaDeposito.KeyMemberWidth = 35;
            this.tSBCuentaDeposito.ToolTip = "Elegir Cuenta de Depósito";
            this.tSBCuentaDeposito.AceptarClick += tSBCuentaDeposito_AceptarClick;
            this.tSBCuentaDeposito.Editable = true;
            this.tSBCuentaDeposito.SoloLectura = true;
            #endregion TextSearchBox
        }

        #region Picks
        #region Cuenta Transferencia
        private void tSBCuentaDeposito_AceptarClick(object sender, EventArgs e)
        {
            if (fPickCuentaDeposito == null)
            {
                fPickCuentaDeposito = new frmPickBase();
                fPickCuentaDeposito.AceptarFiltrarClick += fPickCuentaDeposito_AceptarFiltrarClick;
                fPickCuentaDeposito.FiltrarClick += fPickCuentaDeposito_FiltrarClick;
                fPickCuentaDeposito.Titulo = "Elegir Cuenta Transferencia";
                fPickCuentaDeposito.CampoIDNombre = "CuentaBancariaId";
                fPickCuentaDeposito.CampoDescripNombre = "CuentaBancariaDescrip";
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
                var lista = (from cb in this.DBContext.cb_cuentabanco
                             join m in this.DBContext.Moneda
                                 on cb.cb_monedaid equals m.ID
                             join ba in this.DBContext.ba_banco
                                 on cb.cb_bancoid equals ba.ba_bancoid
                             select new DatosCuentaBancaria
                             {
                                 CuentaBancariaId = cb.cb_cuentabancoid,
                                 NroCuentaBancaria = cb.cb_nrocuenta,
                                 CuentaBancariaDescrip = cb.cb_descripcion,
                                 MonedaIdCuentaBancaria = cb.cb_monedaid,
                                 MonedaAbrevCuentaBancaria = m.AbrevMoneda,
                                 MonedaDescripCuentaBancaria = m.Descripcion,
                                 BancoId = cb.cb_bancoid,
                                 BancoDescrip = ba.ba_descripcion,
                                 PaisId = ba.ba_paisid,
                                 MostrarCuenta = cb.cb_mostrar
                             })
                             .Where(a => a.MostrarCuenta == true 
                                 && a.PaisId == PAIS_PARAGUAY_ID
                                 && a.MonedaIdCuentaBancaria == this.DatoRecaudacion.MonedaId)
                             .AsQueryable();
                fPickCuentaDeposito.LoadData<DatosCuentaBancaria>(lista, fPickCuentaDeposito.GetWhereString());
            }
        }

        private void fPickCuentaDeposito_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBCuentaDeposito.DisplayMember = fPickCuentaDeposito.ValorDescrip;
            this.tSBCuentaDeposito.KeyMember = fPickCuentaDeposito.ValorID;

            this.txtCuentaDescripcion.Text = fPickCuentaDeposito.ValorDescrip;
            this.txtNroCuenta.Text = fPickCuentaDeposito.GetValor("NroCuentaBancaria").ToString();
            this.txtCtaBancariaId.Text = fPickCuentaDeposito.ValorID;

            
            fPickCuentaDeposito.Close();
            fPickCuentaDeposito.Dispose();

            this.txtMontoDeposito.Focus();
        }
        #endregion Cuenta Transferencia
        #endregion Picks

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.ValidarDatos())
            {
                this.DatoRecaudacion.FechaDeposito = this.dtpFechaDeposito.Value;
                this.DatoRecaudacion.NroBoleta = this.txtNroBoletaDeposito.Text;
                this.DatoRecaudacion.CtaBancariaId = Convert.ToInt32(this.txtCtaBancariaId.Text);
                this.DatoRecaudacion.CtaBancariaDescrip = this.txtCuentaDescripcion.Text;
                this.DatoRecaudacion.CtaBancariaNro = this.txtNroCuenta.Text;
                this.DatoRecaudacion.MontoDeposito = Convert.ToDecimal(this.txtMontoDeposito.Text);
                this.DatoRecaudacion.UsuarioCargaId = Convert.ToInt32(this.txtUsuarioId.Text);
                this.DatoRecaudacion.UsuarioCargaNombre = this.txtUsuarioNombre.Text;

                if (this.AceptarClick != null)
                {
                    this.AceptarClick(this, null);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidarDatos()
        {
            if (this.txtNroBoletaDeposito.Text == String.Empty)
            {
                this.txtNroBoletaDeposito.Focus();
                MessageBox.Show("Debe ingresar el número de boleta de depósito.",
                               "Atención Requerida",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }

            if (this.txtCuentaDescripcion.Text == String.Empty)
            {
                this.txtCuentaDescripcion.Focus();
                MessageBox.Show("Debe ingresar la cuenta del depósito.",
                               "Atención Requerida",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }

            if (this.txtMontoDeposito.Text.Trim() == String.Empty)
            {
                this.txtMontoDeposito.Text = String.Format(this.FormatoNumeroRecibo.General, 0);
            }

            decimal montoDeposito;
            if (!decimal.TryParse(this.txtMontoDeposito.Text, out montoDeposito))
            {
                this.txtMontoDeposito.Focus();
                MessageBox.Show("El valor ingresado como monto del depósito no es válido.",
                               "Atención Requerida",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }

            if (montoDeposito <= 0)
            {
                this.txtMontoDeposito.Focus();
                MessageBox.Show("El valor ingresado como monto del depósito debe ser mayor a 0 (cero).",
                               "Atención Requerida",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }

            if (montoDeposito > this.DatoRecaudacion.MontoDepositable)
            {
                this.txtMontoDeposito.Focus();
                MessageBox.Show("El valor ingresado como monto del depósito no puede ser mayor al monto depositable.",
                               "Atención Requerida",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void SetFormatoNumero()
        {
            this.formatoNumeroRecibo = new FormatoNumeroReciboType();

            if (this.DatoRecaudacion.MonedaId == GUARANIES_MONEDA_ID)
            {
                this.FormatoNumeroRecibo.General = FORMATO_MONEDA_GUARANIES;
                this.FormatoNumeroRecibo.Grilla = FORMATO_MONEDA_GUARANIES_GRILLA;
            }
            else
            {
                this.FormatoNumeroRecibo.General = FORMATO_MONEDA_OTROS;
                this.FormatoNumeroRecibo.Grilla = FORMATO_MONEDA_OTROS_GRILLA;
            }
        }

        private void FCargarTransferenciaRecibo_Load(object sender, EventArgs e)
        {
            this.txtNroRecibo.Text = this.DatoRecaudacion.NroRecibo;
            this.txtFechaRecibo.Text = this.DatoRecaudacion.FechaRecibo.ToShortDateString();
            this.txtCliente.Text = this.DatoRecaudacion.ClienteNombre + " (" + this.DatoRecaudacion.ClienteId.ToString() + ")";
            this.toolTip1.SetToolTip(this.txtCliente, this.txtCliente.Text);
            this.txtMoneda.Text = this.DatoRecaudacion.MonedaAbrev;
            this.txtTotalRecibo.Text = string.Format(this.FormatoNumeroRecibo.General, this.DatoRecaudacion.TotalRecibo);
            this.txtMontoDepositable.Text = string.Format(this.FormatoNumeroRecibo.General, this.DatoRecaudacion.MontoDepositable);
            //
            this.dtpFechaDeposito.Value = this.DatoRecaudacion.FechaDeposito.HasValue
                                            ? this.DatoRecaudacion.FechaDeposito.Value
                                            : DateTime.Now;
            this.txtNroBoletaDeposito.Text = this.DatoRecaudacion.NroBoleta != string.Empty
                                            ? this.DatoRecaudacion.NroBoleta
                                            : string.Empty;
            this.txtCtaBancariaId.Text = this.DatoRecaudacion.CtaBancariaId.HasValue
                                            ? this.DatoRecaudacion.CtaBancariaId.Value.ToString()
                                            : string.Empty;
            this.txtCuentaDescripcion.Text = this.DatoRecaudacion.CtaBancariaDescrip != string.Empty
                                                ? this.DatoRecaudacion.CtaBancariaDescrip
                                                : string.Empty;
            this.txtNroCuenta.Text = this.DatoRecaudacion.CtaBancariaNro != string.Empty
                                        ? this.DatoRecaudacion.CtaBancariaNro
                                        : string.Empty;
            this.txtMontoDeposito.Text = this.DatoRecaudacion.MontoDeposito == 0
                                            ? string.Format(this.FormatoNumeroRecibo.General, this.DatoRecaudacion.MontoDepositable)
                                            : string.Format(this.FormatoNumeroRecibo.General, this.DatoRecaudacion.MontoDeposito);
            this.txtUsuarioId.Text = VWGContext.Current.Session["UsuarioID"].ToString();
            this.txtUsuarioNombre.Text = VWGContext.Current.Session["NombreUsuario"].ToString();
            this.dtpFechaDeposito.Focus();
        }

        private void txtCuentaDescripcion_Enter(object sender, EventArgs e)
        {
            this.tSBCuentaDeposito_AceptarClick(sender, e);
        }

        private void txtMontoDeposito_Enter(object sender, EventArgs e)
        {
            this.txtMontoDeposito.SelectAll();
        }

        private void txtMontoDeposito_Leave(object sender, EventArgs e)
        {
            decimal montoDeposito;
            if (decimal.TryParse(this.txtMontoDeposito.Text, out montoDeposito))
            {
                this.txtMontoDeposito.Text = string.Format(this.FormatoNumeroRecibo.General, montoDeposito);
            }
        }

        
    }
}