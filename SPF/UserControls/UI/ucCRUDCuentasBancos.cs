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
using SPF.Types;
using SPF.Forms.Base;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.ObjectModel;
using System.Data.Objects.SqlClient;

using SPF.Classes;
using Microsoft.Reporting.WebForms;

#endregion

namespace SPF.UserControls.UI
{
    public partial class ucCRUDCuentasBancos : ucBaseForm
    {
        #region Constantes
        private const string CAMPO_CUENTABANCOID = "CuentaBancoID";
        private const string CAMPO_CUENTABANCODESCRIP = "CuentaBancoDescrip";
        private const string CAMPO_BANCOID = "BancoID";
        private const string CAMPO_BANCONOMBRE = "BancoNombre";
        private const string CAMPO_CUENTANRO = "CuentaNro";
        private const string CAMPO_CUENTAMONEDAID = "CuentaMonedaID";
        private const string CAMPO_CUENTAMONEDA = "CuentaMoneda";
        private const string CAMPO_CUENTAMONEDAABREV = "CuentaMonedaAbrev";
        private const string CAMPO_ESCUENTAPAGO = "EsCuentaPago";
        private const string CAMPO_CUENTAMOSTRAR = "CuentaMostrar";
        private const string CAMPO_SELLO = "Sello";
        private const string CAMPO_COLORDEFONDO = "ColorDeFondo";
        #endregion Constantes

        #region Variables
        frmPickBase fPickBanco;
        frmPickBase fPickMoneda;
        #endregion Variables

        #region Métodos de Inicio
        public ucCRUDCuentasBancos()
        {
            InitializeComponent();
        }

        public ucCRUDCuentasBancos(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();
            this.DBContext = dbContext;
            this.Titulo = Titulo;
            //this.UsuarioID = Convert.ToInt32(VWGContext.Current.Session["UsuarioID"].ToString());

            var ctas = (from ctaB in this.DBContext.cb_cuentabanco
                          join banc in this.DBContext.ba_banco
                            on ctaB.cb_bancoid equals banc.ba_bancoid into banc_ctaB
                            from banc in banc_ctaB.DefaultIfEmpty()
                          join mon in this.DBContext.Moneda
                            on ctaB.cb_monedaid equals mon.ID into mon_ctaB
                        from mon in mon_ctaB.DefaultIfEmpty()
                          select new
                          {
                              CuentaBancoID = ctaB.cb_cuentabancoid,
                              CuentaBancoDescrip = ctaB.cb_descripcion,
                              BancoID = ctaB.cb_bancoid,
                              BancoNombre = banc.ba_descripcion,
                              CuentaNro = ctaB.cb_nrocuenta,
                              CuentaMonedaID = ctaB.cb_monedaid,
                              CuentaMoneda = mon.Descripcion,
                              CuentaMonedaAbrev = mon.AbrevMoneda,
                              EsCuentaPago = ctaB.cb_escuentapago,
                              CuentaMostrar = ctaB.cb_mostrar,
                              Sello = ctaB.cb_sello,
                              ColorDeFondo = ctaB.cb_color
                          })
                          .OrderByDescending(a => a.CuentaBancoID)
                          .Take(50);

            this.BindingSourceBase = ctas.ToList();

            #region Especificar campos para filtro
            this.SetFilter(CAMPO_CUENTABANCOID, "ID Cuenta", false);
            this.SetFilter(CAMPO_CUENTABANCODESCRIP, "Descrip. Cuenta");
            this.SetFilter(CAMPO_BANCOID, "ID Banco", false);
            this.SetFilter(CAMPO_BANCONOMBRE, "Nombre Banco");
            this.SetFilter(CAMPO_CUENTANRO, "N° Cuenta");
            this.SetFilter(CAMPO_CUENTAMONEDAID, "ID Moneda", false);
            this.SetFilter(CAMPO_CUENTAMONEDA, "Moneda Cuenta");
            this.SetFilter(CAMPO_ESCUENTAPAGO, "Es Cuenta Pago (S/N)", false);
            this.SetFilter(CAMPO_CUENTAMOSTRAR, "Seleccionable (S/N)", false);
            this.TituloBuscador = "Buscar Cuentas";
            #endregion Especificar campos para filtro

            #region Inicializar TextSearchBoxes
            this.tSBMoneda.KeyMemberWidth = 70;
            this.tSBMoneda.ToolTip = "Elegir Moneda";
            this.tSBMoneda.AceptarClick += tSBMoneda_AceptarClick;

            this.tSBBanco.KeyMemberWidth = 70;
            this.tSBBanco.ToolTip = "Elegir Banco de Depósito";
            this.tSBBanco.AceptarClick += tSBBanco_AceptarClick;
            #endregion Inicializar TextSearchBoxes

        }
        #endregion Métodos de Inicio

        #region Picks
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

        #region Banco
        private void tSBBanco_AceptarClick(object sender, EventArgs e)
        {
            if (fPickBanco == null)
            {
                fPickBanco = new frmPickBase();
                fPickBanco.AceptarFiltrarClick += fPickBanco_AceptarFiltrarClick;
                fPickBanco.FiltrarClick += fPickBanco_FiltrarClick;
                fPickBanco.Titulo = "Elegir Banco";
                fPickBanco.CampoIDNombre = "ba_bancoid";
                fPickBanco.CampoDescripNombre = "ba_descripcion";
                fPickBanco.LabelCampoID = "ID";
                fPickBanco.LabelCampoDescrip = "Nombre";
                fPickBanco.NombreCampo = "Banco";
                fPickBanco.PermitirFiltroNulo = true;
            }
            fPickBanco.MostrarFiltro();
            this.fPickBanco_FiltrarClick(sender, e);
        }

        private void fPickBanco_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickBanco != null)
            {
                fPickBanco.LoadData<ba_banco>(this.DBContext.ba_banco, fPickBanco.GetWhereString());
            }
        }

        private void fPickBanco_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBBanco.DisplayMember = fPickBanco.ValorDescrip;
            this.tSBBanco.KeyMember = fPickBanco.ValorID;

            fPickBanco.Close();
            fPickBanco.Dispose();
        }
        #endregion Banco Depósito
        #endregion Picks

        #region Método Extendidos del ParentControl
        protected override void FilterEntity(string where = "", object[] filterParams = null)
        {
            try
            {
                this.limpiarDatos();

                var query = (from ctaB in this.DBContext.cb_cuentabanco
                             join banc in this.DBContext.ba_banco
                               on ctaB.cb_bancoid equals banc.ba_bancoid into banc_ctaB
                             from banc in banc_ctaB.DefaultIfEmpty()
                             join mon in this.DBContext.Moneda
                               on ctaB.cb_monedaid equals mon.ID into mon_ctaB
                             from mon in mon_ctaB.DefaultIfEmpty()
                             select new
                             {
                                 CuentaBancoID = ctaB.cb_cuentabancoid,
                                 CuentaBancoDescrip = ctaB.cb_descripcion,
                                 BancoID = ctaB.cb_bancoid,
                                 BancoNombre = banc.ba_descripcion,
                                 CuentaNro = ctaB.cb_nrocuenta,
                                 CuentaMonedaID = ctaB.cb_monedaid,
                                 CuentaMoneda = mon.Descripcion,
                                 CuentaMonedaAbrev = mon.AbrevMoneda,
                                 EsCuentaPago = ctaB.cb_escuentapago,
                                 CuentaMostrar = ctaB.cb_mostrar,
                                 Sello = ctaB.cb_sello,
                                 ColorDeFondo = ctaB.cb_color
                             });

                if (where != "")
                {
                    this.BindingSourceBase = query.Where(where, filterParams).OrderByDescending(a => a.CuentaBancoID).ToList();
                }
                else
                {
                    this.BindingSourceBase = query.OrderByDescending(a => a.CuentaBancoID).Take(50).ToList();
                }

                this.FormatearGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al filtrar los datos: " + Environment.NewLine + ex.Message, "Información de Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        protected override void FormatearGrilla()
        {
            base.FormatearGrilla();

            foreach (DataGridViewColumn col in this.dgvListadoABM.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            int displayIndex = 0;

            this.dgvListadoABM.Columns[CAMPO_CUENTABANCOID].HeaderText = "Cta. Banco ID";
            this.dgvListadoABM.Columns[CAMPO_CUENTABANCOID].Width = 100;
            this.dgvListadoABM.Columns[CAMPO_CUENTABANCOID].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_CUENTABANCOID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_CUENTABANCOID].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_CUENTABANCODESCRIP].HeaderText = "Cta. Banco Nombre";
            this.dgvListadoABM.Columns[CAMPO_CUENTABANCODESCRIP].Width = 250;
            this.dgvListadoABM.Columns[CAMPO_CUENTABANCODESCRIP].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_CUENTABANCODESCRIP].Visible = true;
            displayIndex++;

            //this.dgvListadoABM.Columns[CAMPO_BANCOID].HeaderText = "Banco ID";
            //this.dgvListadoABM.Columns[CAMPO_BANCOID].Width = 80;
            //this.dgvListadoABM.Columns[CAMPO_BANCOID].DisplayIndex = displayIndex;
            //this.dgvListadoABM.Columns[CAMPO_BANCOID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dgvListadoABM.Columns[CAMPO_BANCOID].Visible = true;
            //displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_BANCONOMBRE].HeaderText = "Banco Nombre";
            this.dgvListadoABM.Columns[CAMPO_BANCONOMBRE].Width = 250;
            this.dgvListadoABM.Columns[CAMPO_BANCONOMBRE].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_BANCONOMBRE].Visible = false;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_CUENTANRO].HeaderText = "N° Cuenta";
            this.dgvListadoABM.Columns[CAMPO_CUENTANRO].Width = 100;
            this.dgvListadoABM.Columns[CAMPO_CUENTANRO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_CUENTANRO].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_CUENTAMONEDAABREV].HeaderText = "Moneda";
            this.dgvListadoABM.Columns[CAMPO_CUENTAMONEDAABREV].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_CUENTAMONEDAABREV].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_CUENTAMONEDAABREV].Visible = true;
            displayIndex++;

            DataGridViewCheckBoxColumn colEsCuentaPago = new DataGridViewCheckBoxColumn();
            colEsCuentaPago.DataPropertyName = CAMPO_ESCUENTAPAGO;
            colEsCuentaPago.Name = CAMPO_ESCUENTAPAGO;
            colEsCuentaPago.HeaderText = "Es Cuenta Pago";
            colEsCuentaPago.FalseValue = false;
            colEsCuentaPago.TrueValue = true;
            colEsCuentaPago.ReadOnly = true;
            this.dgvListadoABM.Columns.Insert(displayIndex, colEsCuentaPago);
            displayIndex++;

            DataGridViewCheckBoxColumn colMostrarCuenta = new DataGridViewCheckBoxColumn();
            colMostrarCuenta.DataPropertyName = CAMPO_CUENTAMOSTRAR;
            colMostrarCuenta.Name = CAMPO_CUENTAMOSTRAR;
            colMostrarCuenta.HeaderText = "Seleccionable";
            colMostrarCuenta.FalseValue = false;
            colMostrarCuenta.TrueValue = true;
            colMostrarCuenta.ReadOnly = true;
            this.dgvListadoABM.Columns.Insert(displayIndex, colMostrarCuenta);
        }

        protected override void tbbNuevo_Click(object sender, EventArgs e)
        {
            base.tbbNuevo_Click(sender, e);
            this.limpiarDatos();
            this.txtCuentaBancoDescrip.Focus();
        }

        protected override void tbbEditar_Click(object sender, EventArgs e)
        {
            base.tbbEditar_Click(sender, e);
            this.txtCuentaBancoDescrip.Focus();
        }

        protected override void tbbCancelar_Click(object sender, EventArgs e)
        {
            base.tbbCancelar_Click(sender, e);

            if (this.LastDGVIndex > -1)
            {
                this.CargarCtaBanco(this.dgvListadoABM.Rows[this.LastDGVIndex]);
            }
            else
            {
                this.limpiarDatos();
            }
        }

        #endregion Método Extendidos del ParentControl

        #region Limpiar Datos
        private void limpiarDatos()
        {
            this.txtCuentaBancoID.Text = "";
            this.txtCuentaBancoDescrip.Text = "";
            this.txtNroCuenta.Text = "";
            this.tSBBanco.Clear();
            this.tSBMoneda.Clear();
            this.cbEsCuentaPago.Checked = false;
            this.txtSello.BackColor = Color.White;
            this.txtSello.Text = string.Empty;
            this.chkMostrar.Checked = false;
        }
        #endregion Limpiar Datos

        #region ReadOnly condicional
        protected override void Editable(bool editar)
        {
            this.txtCuentaBancoID.ReadOnly = editar;
            this.txtCuentaBancoDescrip.ReadOnly = editar;
            this.txtNroCuenta.ReadOnly = editar;
            this.tSBBanco.Editable = !editar;
            this.tSBMoneda.Editable = !editar;
            this.cbEsCuentaPago.Enabled = !editar;
            this.txtSello.ReadOnly = editar;
            this.btnColorDeFondo.Enabled = !editar;
            this.chkMostrar.Enabled = !editar;
        }
        #endregion ReadOnly condicional

        #region Métodos de Apoyo
        private void CargarCtaBanco(DataGridViewRow row)
        {
            this.limpiarDatos();

            this.txtCuentaBancoID.Text = row.Cells[CAMPO_CUENTABANCOID].Value.ToString();
            this.txtCuentaBancoDescrip.Text = row.Cells[CAMPO_CUENTABANCODESCRIP].Value.ToString();
            this.txtNroCuenta.Text = row.Cells[CAMPO_CUENTANRO].Value.ToString();
            this.cbEsCuentaPago.Checked = (bool)row.Cells[CAMPO_ESCUENTAPAGO].Value;
            this.chkMostrar.Checked = (bool)row.Cells[CAMPO_CUENTAMOSTRAR].Value;

            if (row.Cells[CAMPO_CUENTAMONEDAID].Value != null)
            {
                this.tSBMoneda.KeyMember = row.Cells[CAMPO_CUENTAMONEDAID].Value.ToString();
                this.tSBMoneda.DisplayMember = row.Cells[CAMPO_CUENTAMONEDA].Value.ToString();
            }

            if (row.Cells[CAMPO_BANCOID].Value != null)
            {
                this.tSBBanco.KeyMember = row.Cells[CAMPO_BANCOID].Value.ToString();
                this.tSBBanco.DisplayMember = row.Cells[CAMPO_BANCONOMBRE].Value.ToString();
            }

            this.txtSello.Text = row.Cells[CAMPO_SELLO].Value != null ? row.Cells[CAMPO_SELLO].Value.ToString() : string.Empty;
            this.txtSello.BackColor = row.Cells[CAMPO_COLORDEFONDO].Value != null ?
                                        System.Drawing.ColorTranslator.FromHtml(row.Cells[CAMPO_COLORDEFONDO].Value.ToString()) :
                                        Color.White;

        }
        #endregion Métodos de Apoyo

        #region Métodos locales sobre controles

        private void ucCRUDCuentasBancos_VisibleChanged(object sender, EventArgs e)
        {
            if (this.tabListaABM.SelectedIndex == 0)
                this.FormatearGrilla();
        }

        private void dgvListadoABM_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((this.LastDGVIndex > -1)  && (!this.IsClosing))
                this.CargarCtaBanco(this.dgvListadoABM.Rows[this.LastDGVIndex]);
        }

        private void tbbGuardar_Click_1(object sender, EventArgs e)
        {
            if (this.txtCuentaBancoDescrip.Text == "")
            {
                MessageBox.Show("Debe ingresar el nombre de la cuenta.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (this.tSBBanco.KeyMember == "")
            {
                MessageBox.Show("Debe ingresar el banco de la cuenta.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }


            if (this.tSBMoneda.KeyMember == "")
            {
                MessageBox.Show("Debe ingresar la moneda de la cuenta.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (this.txtNroCuenta.Text == "")
            {
                MessageBox.Show("Debe ingresar el número de cuenta.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            string message = "";
            string caption = "";
            if (this.FormEditStatus == EDIT)
            {
                caption = "Actualización de registro";
                message = "Se modificará el presente registro ¿Desea continuar?";
            }
            else if (this.FormEditStatus == INSERT)
            {
                caption = "Inserción de nuevo de registro";
                message = "Se insertará un nuevo registro ¿Desea continuar?";
            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(DialogHandler));
        }

        private void DialogHandler(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    if (this.FormEditStatus != BROWSE)
                        this.GuardarRegistro();
                    else
                        this.EliminarRegistro();
                }
            }
        }

        private void tbbBorrar_Click_1(object sender, EventArgs e)
        {
            string caption = "Eliminación de registro";
            string message = "Se eliminará el presente registro ¿Desea continuar?";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(DialogHandler));
        }

        private void GetBackcolor()
        {
            colorDialog1.ShowDialog(new EventHandler(BackcolorDialog));
        }

        private void BackcolorDialog(object sender, EventArgs e)
        {
            ColorDialog msgForm = sender as Gizmox.WebGUI.Forms.ColorDialog;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.OK)
                {
                    this.txtSello.BackColor = msgForm.Color;
                }
            }
        }

        private void btnColorDeFondo_Click(object sender, EventArgs e)
        {
            this.GetBackcolor();
        }

        #endregion Métodos locales sobre controles

        #region CRUD
        private void GuardarRegistro()
        {
            bool success = false;

            cb_cuentabanco cbanco = null;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        cbanco = this.guardarCtaBanco(context);
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
                if (this.FormEditStatus == INSERT)
                    this.FilterEntity(CAMPO_CUENTABANCOID + " = " + cbanco.cb_cuentabancoid.ToString(), null);
                else if (this.FormEditStatus == EDIT)
                    this.FilterEntity(this.WhereString, this.FilterParam);

                this.FormEditStatus = BROWSE;
                this.CargarCtaBanco(this.dgvListadoABM.Rows[this.LastDGVIndex]);

                MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EliminarRegistro()
        {
            bool success = false;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        this.eliminarCtaBanco(context);
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
                        MessageBox.Show("Ocurrió un error al eliminar el registro: "
                                        + ex.Message + Environment.NewLine
                                        + ex.InnerException,
                                        "Error al eliminar los datos",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Stop);
                    }
                }
                if (success)
                {
                    this.limpiarDatos();
                    this.FilterEntity(this.WhereString, this.FilterParam);
                    this.FormEditStatus = BROWSE;
                    MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #region Métodos de Edición de Datos
        private cb_cuentabanco guardarCtaBanco(BerkeDBEntities context = null)
        {
            cb_cuentabanco cbanco = new cb_cuentabanco();
            if (this.FormEditStatus == EDIT)
            {
                int cbancoID = Convert.ToInt32(this.txtCuentaBancoID.Text);

                cbanco = context.cb_cuentabanco.First(a => a.cb_cuentabancoid == cbancoID);

                cbanco.cb_descripcion = this.txtCuentaBancoDescrip.Text;
                cbanco.cb_bancoid = Convert.ToInt32(this.tSBBanco.KeyMember);
                cbanco.cb_monedaid = Convert.ToInt32(this.tSBMoneda.KeyMember);
                cbanco.cb_nrocuenta = this.txtNroCuenta.Text;
                cbanco.cb_escuentapago = this.cbEsCuentaPago.Checked;
                cbanco.cb_mostrar = this.chkMostrar.Checked;

                if (this.txtSello.Text.Trim() != string.Empty)
                {
                    cbanco.cb_sello = this.txtSello.Text;
                    cbanco.cb_color = System.Drawing.ColorTranslator.ToHtml(this.txtSello.BackColor);
                }
                else
                {
                    cbanco.cb_sello = null;
                    cbanco.cb_color = null;
                }
            }
            else if (this.FormEditStatus == INSERT)
            {
                cbanco.cb_descripcion = this.txtCuentaBancoDescrip.Text;
                cbanco.cb_bancoid = Convert.ToInt32(this.tSBBanco.KeyMember);
                cbanco.cb_monedaid = Convert.ToInt32(this.tSBMoneda.KeyMember);
                cbanco.cb_nrocuenta = this.txtNroCuenta.Text;
                cbanco.cb_escuentapago = this.cbEsCuentaPago.Checked;
                cbanco.cb_mostrar = this.chkMostrar.Checked;

                if (this.txtSello.Text.Trim() != string.Empty)
                {
                    cbanco.cb_sello = this.txtSello.Text;
                    cbanco.cb_color = System.Drawing.ColorTranslator.ToHtml(this.txtSello.BackColor);
                }
                else
                {
                    cbanco.cb_sello = null;
                    cbanco.cb_color = null;
                }

                context.cb_cuentabanco.Add(cbanco);
            }

            return cbanco;
        }

        private void eliminarCtaBanco(BerkeDBEntities context = null)
        {
            int cbancoID = Convert.ToInt32(this.txtCuentaBancoID.Text);
            cb_cuentabanco cbanco = context.cb_cuentabanco.First(a => a.cb_cuentabancoid == cbancoID);

            context.cb_cuentabanco.Remove(cbanco);

        }
        #endregion Métodos de Edición de Datos

        #endregion CRUD
    }
}