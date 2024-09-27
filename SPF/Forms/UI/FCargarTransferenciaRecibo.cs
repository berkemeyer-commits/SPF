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
    public partial class FCargarTransferenciaRecibo : Form
    {
        #region Variables
        BerkeDBEntities DBContext;
        private FormatoNumeroReciboType formatoNumeroRecibo;
        frmPickBase fPickCuentaTransferencia;
        DatosTransferenciaReciboType datosTransferencia;
        private int monedaId;
        private string monedaAbrev;
        private decimal totalRecibo;
        #endregion Variables

        #region Constantes
        private const int GUARANIES_MONEDA_ID = 3;
        private const string FORMATO_MONEDA_GUARANIES = "{0:N0}";
        private const string FORMATO_MONEDA_OTROS = "{0:N2}";
        #endregion Constantes

        #region Eventos Personalizados
        public event EventHandler AceptarClick;
        #endregion Eventos Personalizados

        #region Propiedades
        private FormatoNumeroReciboType FormatoNumeroRecibo
        {
            get { return this.formatoNumeroRecibo; }
            set { this.formatoNumeroRecibo = value; }
        }

        public DatosTransferenciaReciboType DatosTransferencia
        {
            set { this.datosTransferencia = value; }
            get { return this.datosTransferencia; }
        }

        public int MonedaId
        {
            set { this.monedaId = value; }
            get { return this.monedaId; }
        }

        public string MonedaAbrev
        {
            set { this.monedaAbrev = value; }
            get { return this.monedaAbrev; }
        }

        private decimal TotalRecibo
        {
            set { this.totalRecibo = value; }
            get { return this.totalRecibo; }
        }
        #endregion Propiedades

        public FCargarTransferenciaRecibo()
        {
            InitializeComponent();
        }

        public FCargarTransferenciaRecibo(BerkeDBEntities context, string titulo, int monedaId, string monedaAbrev, decimal totalRecibo)
        {
            InitializeComponent();
            this.Text = titulo;
            this.DBContext = context;
            this.formatoNumeroRecibo = new FormatoNumeroReciboType();
            this.datosTransferencia = new DatosTransferenciaReciboType();
            this.MonedaId = monedaId;
            this.MonedaAbrev = monedaAbrev;
            this.TotalRecibo = totalRecibo;
            this.tSBBancoTransferencia.KeyMemberWidth = 35;
            this.tSBBancoTransferencia.ToolTip = "Elegir Cuenta de Depósito";
            this.tSBBancoTransferencia.AceptarClick += tSBBancoTransferencia_AceptarClick;
            this.tSBBancoTransferencia.Editable = true;
            this.tSBBancoTransferencia.SoloLectura = true;

            this.SetFormatoNumero();
        }

        private void SetFormatoNumero()
        {
            if (this.MonedaId == GUARANIES_MONEDA_ID)
            {
                this.FormatoNumeroRecibo.General = FORMATO_MONEDA_GUARANIES;
            }
            else
            {
                this.FormatoNumeroRecibo.General = FORMATO_MONEDA_OTROS;
            }
        }

        #region Picks
        #region Cuenta Transferencia
        private void tSBBancoTransferencia_AceptarClick(object sender, EventArgs e)
        {
            if (fPickCuentaTransferencia == null)
            {
                fPickCuentaTransferencia = new frmPickBase();
                fPickCuentaTransferencia.AceptarFiltrarClick += fPickCuentaTransferencia_AceptarFiltrarClick;
                fPickCuentaTransferencia.FiltrarClick += fPickCuentaTransferencia_FiltrarClick;
                fPickCuentaTransferencia.Titulo = "Elegir Cuenta Transferencia";
                fPickCuentaTransferencia.CampoIDNombre = "CuentaBancariaId";
                fPickCuentaTransferencia.CampoDescripNombre = "CuentaBancariaDescrip";
                fPickCuentaTransferencia.LabelCampoID = "ID";
                fPickCuentaTransferencia.LabelCampoDescrip = "Descripción";
                fPickCuentaTransferencia.NombreCampo = "Cuenta";
                fPickCuentaTransferencia.PermitirFiltroNulo = true;
            }
            fPickCuentaTransferencia.MostrarFiltro();
            this.fPickCuentaTransferencia_FiltrarClick(sender, e);
        }

        private void fPickCuentaTransferencia_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickCuentaTransferencia != null)
            {
                if (!this.chkMostrarTodasLasCuentas.Checked)
                {
                    //var lista = this.DBContext.cb_cuentabanco.Where(a => a.cb_monedaid == this.MonedaId).AsQueryable();
                    //fPickCuentaTransferencia.LoadData<cb_cuentabanco>(
                    //    lista,
                    //    fPickCuentaTransferencia.GetWhereString());

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
                                     MostrarCuenta = cb.cb_mostrar,
                                     MonedaIdCuentaBancaria = cb.cb_monedaid,
                                     MonedaAbrevCuentaBancaria = m.AbrevMoneda,
                                     MonedaDescripCuentaBancaria = m.Descripcion,
                                     BancoId = cb.cb_bancoid,
                                     BancoDescrip = ba.ba_descripcion,
                                     PaisId = ba.ba_paisid
                                 })
                                 .Where(a => a.MonedaIdCuentaBancaria == this.MonedaId && a.MostrarCuenta == true)
                                 .AsQueryable();
                    fPickCuentaTransferencia.LoadData<DatosCuentaBancaria>(
                        lista,
                        fPickCuentaTransferencia.GetWhereString());
                }
                else
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
                                     PaisId = ba.ba_paisid
                                 })
                                 .Where(a => a.MostrarCuenta == true)
                                .AsQueryable();
                    fPickCuentaTransferencia.LoadData<DatosCuentaBancaria>(lista, fPickCuentaTransferencia.GetWhereString());
                }
            }
        }

        private void fPickCuentaTransferencia_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBBancoTransferencia.DisplayMember = fPickCuentaTransferencia.ValorDescrip;
            this.tSBBancoTransferencia.KeyMember = fPickCuentaTransferencia.ValorID;

            this.txtCuentaId.Text = fPickCuentaTransferencia.ValorID;
            this.txtCuentaDescripcion.Text = fPickCuentaTransferencia.ValorDescrip;
            this.txtNroCuenta.Text = fPickCuentaTransferencia.GetValor("NroCuentaBancaria").ToString();
            this.txtPaisId.Text = fPickCuentaTransferencia.GetValor("PaisId").ToString();

            if (this.chkMostrarTodasLasCuentas.Checked)
            {
                string monedaAbrev = fPickCuentaTransferencia.GetValor("MonedaAbrevCuentaBancaria").ToString();
                this.txtAbrevMonedaGasto.Text = monedaAbrev;
                this.txtAbrevMonedaMonto.Text = monedaAbrev;
                this.MonedaId = (int)fPickCuentaTransferencia.GetValor("MonedaIdCuentaBancaria");
                this.monedaAbrev = fPickCuentaTransferencia.GetValor("MonedaAbrevCuentaBancaria").ToString(); ;
                this.SetFormatoNumero();
                this.txtGastoBancario.Text = String.Format(this.FormatoNumeroRecibo.General, 0);
                this.txtMontoTransferencia.Text = String.Format(this.FormatoNumeroRecibo.General, 0);
            }
            else
            {
                this.txtAbrevMonedaGasto.Text = this.MonedaAbrev;
                this.txtAbrevMonedaMonto.Text = this.MonedaAbrev;
            }
           
            fPickCuentaTransferencia.Close();
            fPickCuentaTransferencia.Dispose();

            this.txtNumeroTransferencia.Focus();
        }
        #endregion Cuenta Transferencia
        #endregion Picks

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            decimal totalTransfencia = Convert.ToDecimal(this.txtGastoBancario.Text) + Convert.ToDecimal(this.txtMontoTransferencia.Text);
            if (totalTransfencia <= this.TotalRecibo)
                this.CargarTransferencia();
            else
            {
                MessageBox.Show("No se puede cargar una transferencia con monto mayor al total del recibo.",
                                       "Atención Requerida",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void CargarTransferencia()
        {
            if (this.ValidarDatosTransferencia())
            {
                DatosTransferenciaReciboType row = new DatosTransferenciaReciboType();
                row.FechaTransferencia = this.dtpFechaTransferencia.Value.ToShortDateString();
                row.BancoTransferenciaId = Convert.ToInt32(this.tSBBancoTransferencia.KeyMember);
                row.BancoTransferenciaDescrip = this.tSBBancoTransferencia.DisplayMember; ;
                row.NumeroTransferencia = this.txtNumeroTransferencia.Text;
                row.MontoGastoBancario = Convert.ToDecimal(this.txtGastoBancario.Text);
                row.MontoTransferencia = Convert.ToDecimal(this.txtMontoTransferencia.Text);
                row.MonedaTransferenciaId = this.MonedaId;
                row.MonedaTransferenciaAbrev = this.txtAbrevMonedaMonto.Text;
                row.PaisId = Convert.ToInt32(this.txtPaisId.Text);

                this.DatosTransferencia = row;

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

        private bool ValidarDatosTransferencia()
        {
            if (this.tSBBancoTransferencia.KeyMember == String.Empty)
            {
                this.tSBBancoTransferencia.SetFocus();
                MessageBox.Show("Debe seleccionar la cuenta bancaria de la transferencia.",
                               "Atención Requerida",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }

            if (this.txtNumeroTransferencia.Text.Trim() == String.Empty)
            {
                this.txtNumeroTransferencia.Focus();
                MessageBox.Show("Debe ingresar el número de la transferencia.",
                               "Atención Requerida",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }

            if (this.txtGastoBancario.Text.Trim() == String.Empty)
            {
                this.txtGastoBancario.Text = String.Format(this.FormatoNumeroRecibo.General, 0);
            }

            decimal gastoBancario;
            if (!decimal.TryParse(this.txtGastoBancario.Text, out gastoBancario))
            {
                this.txtGastoBancario.Focus();
                MessageBox.Show("El valor ingresado como gasto bancario no es válido.",
                               "Atención Requerida",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }

            if (this.txtMontoTransferencia.Text.Trim() == String.Empty)
            {
                this.txtMontoTransferencia.Text = String.Format(this.FormatoNumeroRecibo.General, 0);
            }

            decimal montoTransferencia;
            if (!decimal.TryParse(this.txtMontoTransferencia.Text, out montoTransferencia))
            {
                this.txtMontoTransferencia.Focus();
                MessageBox.Show("El valor ingresado como monto de la transferencia no es válido.",
                               "Atención Requerida",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }
            else
            {
                if (montoTransferencia <= 0)
                {
                    this.txtMontoTransferencia.Focus();
                    MessageBox.Show("El valor ingresado como monto de la transferencia debe ser mayor a 0 (cero).",
                                   "Atención Requerida",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
                    return false;
                }
            }

            return true;
        }

        private void FCargarTransferenciaRecibo_Load(object sender, EventArgs e)
        {
            this.LimpiarTextBoxes();
            this.dtpFechaTransferencia.Focus();
        }

        private void LimpiarTextBoxes()
        {
            this.dtpFechaTransferencia.Value = DateTime.Now;
            this.tSBBancoTransferencia.Clear();
            this.txtNumeroTransferencia.Text = String.Empty;
            this.txtGastoBancario.Text = String.Format(this.FormatoNumeroRecibo.General, 0);
            this.txtMontoTransferencia.Text = String.Format(this.FormatoNumeroRecibo.General, 0);
            //this.chkMostrarTodasLasCuentas.Checked = false;
            this.txtCuentaId.Text = String.Empty;
            this.txtCuentaDescripcion.Text = String.Empty;
            this.txtNroCuenta.Text = String.Empty;
            this.txtAbrevMonedaGasto.Text = this.MonedaAbrev;
            this.txtAbrevMonedaMonto.Text = this.MonedaAbrev;
        }

        private void txtGastoBancario_Leave(object sender, EventArgs e)
        {
            decimal gastoBancario;

            if (decimal.TryParse(this.txtGastoBancario.Text, out gastoBancario))
            {
                this.txtGastoBancario.Text = String.Format(this.FormatoNumeroRecibo.General, gastoBancario);
            }
        }

        private void txtMontoTransferencia_Leave(object sender, EventArgs e)
        {
            decimal montoTransferencia;

            if (decimal.TryParse(this.txtMontoTransferencia.Text, out montoTransferencia))
            {
                this.txtMontoTransferencia.Text = String.Format(this.FormatoNumeroRecibo.General, montoTransferencia);
            }
        }

        private void tSBBancoTransferencia_Enter(object sender, EventArgs e)
        {
            this.tSBBancoTransferencia_AceptarClick(sender, e);
        }

        private void txtGastoBancario_Enter(object sender, EventArgs e)
        {
            this.txtGastoBancario.SelectAll();
        }

        private void txtMontoTransferencia_Enter(object sender, EventArgs e)
        {
            this.txtMontoTransferencia.SelectAll();
        }

        private void txtCuentaDescripcion_Enter(object sender, EventArgs e)
        {
            this.tSBBancoTransferencia_AceptarClick(sender, e);
        }
    }
}