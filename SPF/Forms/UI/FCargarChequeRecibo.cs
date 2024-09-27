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
    public partial class FCargarChequeRecibo : Form
    {
        #region Variables
        BerkeDBEntities DBContext;
        private FormatoNumeroReciboType formatoNumeroRecibo;
        frmPickBase fPickBancoCheque;
        DatosChequeReciboType datosCheque;
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

        public DatosChequeReciboType DatosCheque
        {
            set { this.datosCheque = value; }
            get { return this.datosCheque; }
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

        public FCargarChequeRecibo()
        {
            InitializeComponent();
        }

        public FCargarChequeRecibo(BerkeDBEntities context, string titulo, int monedaId, string monedaAbrev, decimal totalRecibo)
        {
            InitializeComponent();
            this.Text = titulo;
            this.DBContext = context;
            this.formatoNumeroRecibo = new FormatoNumeroReciboType();
            this.datosCheque = new DatosChequeReciboType();
            this.MonedaId = monedaId;
            this.MonedaAbrev = monedaAbrev;
            this.TotalRecibo = totalRecibo;
            this.tSBBancoCheque.KeyMemberWidth = 35;
            this.tSBBancoCheque.ToolTip = "Elegir Banco Cargo del Cheque";
            this.tSBBancoCheque.AceptarClick += tSBBancoCheque_AceptarClick;
            this.tSBBancoCheque.Editable = true;
            this.tSBBancoCheque.SoloLectura = true;

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
        #region Cuenta Cheque
        private void tSBBancoCheque_AceptarClick(object sender, EventArgs e)
        {
            if (fPickBancoCheque == null)
            {
                fPickBancoCheque = new frmPickBase();
                fPickBancoCheque.AceptarFiltrarClick += fPickBancoCheque_AceptarFiltrarClick;
                fPickBancoCheque.FiltrarClick += fPickBancoCheque_FiltrarClick;
                fPickBancoCheque.Titulo = "Elegir Banco Cargo del Cheque";
                fPickBancoCheque.CampoIDNombre = "Bancoid";
                fPickBancoCheque.CampoDescripNombre = "BancoDescripcion";
                fPickBancoCheque.LabelCampoID = "ID";
                fPickBancoCheque.LabelCampoDescrip = "Descripción";
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
                var query = (from ba in this.DBContext.ba_banco
                             select new BancoCheque
                             {
                                 BancoID = ba.ba_bancoid,
                                 BancoDescripcion = ba.ba_descripcion,
                                 Mostrar = ba.ba_mostrar
                             })
                             .Where(a => a.Mostrar == true)
                             .ToList();
                fPickBancoCheque.LoadData<BancoCheque>(query.AsQueryable(), fPickBancoCheque.GetWhereString());
                //if (!this.chkMostrarTodasLasCuentas.Checked)
                //{
                //    var lista = (from cb in this.DBContext.cb_cuentabanco
                //                 join m in this.DBContext.Moneda
                //                     on cb.cb_monedaid equals m.ID
                //                 join ba in this.DBContext.ba_banco
                //                     on cb.cb_bancoid equals ba.ba_bancoid
                //                 select new DatosCuentaBancaria
                //                 {
                //                     CuentaBancariaId = cb.cb_cuentabancoid,
                //                     NroCuentaBancaria = cb.cb_nrocuenta,
                //                     CuentaBancariaDescrip = cb.cb_descripcion,
                //                     MonedaIdCuentaBancaria = cb.cb_monedaid,
                //                     MonedaAbrevCuentaBancaria = m.AbrevMoneda,
                //                     MonedaDescripCuentaBancaria = m.Descripcion,
                //                     BancoId = cb.cb_bancoid,
                //                     BancoDescrip = ba.ba_descripcion
                //                 })
                //                 .Where(a => a.MonedaIdCuentaBancaria == this.MonedaId)
                //                .AsQueryable();
                //    fPickBancoCheque.LoadData<DatosCuentaBancaria>(
                //        lista,
                //        fPickBancoCheque.GetWhereString());
                //}
                //else
                //{
                //    var lista = (from cb in this.DBContext.cb_cuentabanco
                //                 join m in this.DBContext.Moneda
                //                     on cb.cb_monedaid equals m.ID
                //                 join ba in this.DBContext.ba_banco
                //                     on cb.cb_bancoid equals ba.ba_bancoid
                //                 select new DatosCuentaBancaria
                //                 {
                //                     CuentaBancariaId = cb.cb_cuentabancoid,
                //                     NroCuentaBancaria = cb.cb_nrocuenta,
                //                     CuentaBancariaDescrip = cb.cb_descripcion,
                //                     MonedaIdCuentaBancaria = cb.cb_monedaid,
                //                     MonedaAbrevCuentaBancaria = m.AbrevMoneda,
                //                     MonedaDescripCuentaBancaria = m.Descripcion,
                //                     BancoId = cb.cb_bancoid,
                //                     BancoDescrip = ba.ba_descripcion
                //                 })
                //                .AsQueryable();
                //    fPickBancoCheque.LoadData<DatosCuentaBancaria>(lista, fPickBancoCheque.GetWhereString());
                //}
            }
        }

        private void fPickBancoCheque_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBBancoCheque.DisplayMember = fPickBancoCheque.ValorDescrip;
            this.tSBBancoCheque.KeyMember = fPickBancoCheque.ValorID;

            this.txtCuentaId.Text = fPickBancoCheque.ValorID;
            this.txtBancoDescripcion.Text = fPickBancoCheque.ValorDescrip;
            //this.txtNroCuenta.Text = fPickBancoCheque.GetValor("NroCuentaBancaria").ToString();

            //if (this.chkMostrarTodasLasCuentas.Checked)
            //{
            //    string monedaAbrev = fPickBancoCheque.GetValor("MonedaAbrevCuentaBancaria").ToString();
            //    this.txtAbrevMonedaMonto.Text = monedaAbrev;
            //    this.MonedaId = (int)fPickBancoCheque.GetValor("MonedaIdCuentaBancaria");
            //    this.MonedaAbrev = fPickBancoCheque.GetValor("MonedaAbrevCuentaBancaria").ToString();
            //    this.SetFormatoNumero();
            //    this.txtMontoCheque.Text = String.Format(this.FormatoNumeroRecibo.General, 0);
            //}
            //else
            //{
            //    this.txtAbrevMonedaMonto.Text = this.MonedaAbrev;
            //}
           
            fPickBancoCheque.Close();
            fPickBancoCheque.Dispose();

            this.txtNumeroCheque.Focus();
        }
        #endregion Cuenta Cheque
        #endregion Picks

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            decimal totalCheque = Convert.ToDecimal(this.txtMontoCheque.Text);
            if (totalCheque <= this.TotalRecibo)
                this.CargarCheque();
            else
            {
                MessageBox.Show("No se puede cargar un cheque con monto mayor al total del recibo.",
                                       "Atención Requerida",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void CargarCheque()
        {
            if (this.ValidarDatosCheque())
            {
                DatosChequeReciboType row = new DatosChequeReciboType();
                row.FechaCheque = this.dtpFechaCheque.Value.ToShortDateString();
                row.BancoChequeId = Convert.ToInt32(this.tSBBancoCheque.KeyMember);
                row.BancoChequeDescrip = this.tSBBancoCheque.DisplayMember; ;
                row.NumeroCheque = this.txtNumeroCheque.Text;
                row.MontoCheque = Convert.ToDecimal(this.txtMontoCheque.Text);
                row.MonedaChequeId = this.MonedaId;
                row.MonedaChequeAbrev = this.txtAbrevMonedaMonto.Text;
                this.DatosCheque = row;

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

        private bool ValidarDatosCheque()
        {
            if (this.tSBBancoCheque.KeyMember == String.Empty)
            {
                this.tSBBancoCheque.SetFocus();
                MessageBox.Show("Debe seleccionar la cuenta bancaria del cheque.",
                               "Atención Requerida",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }

            if (this.txtNumeroCheque.Text.Trim() == String.Empty)
            {
                this.txtNumeroCheque.Focus();
                MessageBox.Show("Debe ingresar el número de cheque.",
                               "Atención Requerida",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }

            if (this.txtMontoCheque.Text.Trim() == String.Empty)
            {
                this.txtMontoCheque.Text = String.Format(this.FormatoNumeroRecibo.General, 0);
            }

            decimal montoCheque;
            if (!decimal.TryParse(this.txtMontoCheque.Text, out montoCheque))
            {
                this.txtMontoCheque.Focus();
                MessageBox.Show("El valor ingresado como monto del cheque no es válido.",
                               "Atención Requerida",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }
            else
            {
                if (montoCheque <= 0)
                {
                    this.txtMontoCheque.Focus();
                    MessageBox.Show("El valor ingresado como monto del cheque debe ser mayor a 0 (cero).",
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
            this.dtpFechaCheque.Focus();
        }

        private void LimpiarTextBoxes()
        {
            this.dtpFechaCheque.Value = DateTime.Now;
            this.tSBBancoCheque.Clear();
            this.txtNumeroCheque.Text = String.Empty;
            this.txtMontoCheque.Text = String.Format(this.FormatoNumeroRecibo.General, 0);
            this.txtCuentaId.Text = String.Empty;
            this.txtBancoDescripcion.Text = String.Empty;
            this.txtNroCuenta.Text = String.Empty;
            this.txtAbrevMonedaMonto.Text = this.MonedaAbrev;
        }

        private void txtMontoCheque_Leave(object sender, EventArgs e)
        {
            decimal montoCheque;

            if (decimal.TryParse(this.txtMontoCheque.Text, out montoCheque))
            {
                this.txtMontoCheque.Text = String.Format(this.FormatoNumeroRecibo.General, montoCheque);
            }
        }

        private void txtMontoTransferencia_Enter(object sender, EventArgs e)
        {
            this.txtMontoCheque.SelectAll();
        }

        private void txtCuentaDescripcion_Enter(object sender, EventArgs e)
        {
            this.tSBBancoCheque_AceptarClick(sender, e);
        }
    }
}