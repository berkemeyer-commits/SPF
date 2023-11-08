#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using ModelEF6;
using SPF.Types;
using SPF.Forms.Base;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.ObjectModel;
using System.Data.Objects.SqlClient;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace SPF.Forms.UI
{
    public partial class FCuentaPorClienteContinente : Form
    {
        #region Propiedades
        public string FormEditStatus
        {
            set { this.formEditStatus = value; }
            get { return this.formEditStatus; }
        }

        public string TipoRelacion
        {
            set { this.tiporelacion = value; }
            get { return this.tiporelacion; }
        }
        #endregion Propiedades

        #region Variables
        frmPickBase fPickMoneda;
        frmPickBase fPickCuenta;
        BerkeDBEntities DBContext;
        private string formEditStatus = "NONE";
        private string tiporelacion;
        #endregion Variables

        #region Constantes
        private const string CAMPO_BANCOID = "BancoID";
        private const string CAMPO_BANCONOMBRE = "BancoNombre";
        private const string CAMPO_NROCUENTA = "CuentaNumero";
        private const string TITULO = "Cuentas por {0}";

        private const string TIPORELACIONCONTINENTE = "N";
        private const string TIPORELACIONCLIENTE = "C";

        private const string CONTINENTE = "Continente";
        private const string CLIENTE = "Cliente";

        private const string BROWSE = "BROWSE";
        private const string INSERT = "INSERT";
        private const string EDIT = "EDIT";
        private const string NONE = "NONE";
        #endregion Constantes

        public FCuentaPorClienteContinente()
        {
            InitializeComponent();
        }

        public FCuentaPorClienteContinente(BerkeDBEntities dbcontext, string nombrecampo, string valoridcampo, string valordescripcioncampo, string editStatus, ClienteContinenteCuentaMoneda ccm = null)
        {
            InitializeComponent();

            this.DBContext = dbcontext;
            this.FormEditStatus = editStatus;
            this.TipoRelacion = nombrecampo;
            this.Text = string.Format(TITULO, nombrecampo);
            this.lblCampo.Text = nombrecampo;
            this.txtCampoID.Text = valoridcampo;
            this.txtDescripcionCampo.Text = valordescripcioncampo;

            if (ccm != null)
                this.CargarDatos(ccm);

            this.btnAceptar.Visible = this.FormEditStatus != BROWSE;                        

            #region Inicializar TextSearchBoxes
            this.tSBMoneda.KeyMemberWidth = 70;
            this.tSBMoneda.ToolTip = "Elegir Moneda";
            this.tSBMoneda.Editable = this.FormEditStatus != BROWSE;                        
            this.tSBMoneda.AceptarClick += tSBMoneda_AceptarClick;

            this.tSBCuenta.KeyMemberWidth = 70;
            this.tSBCuenta.ToolTip = "Elegir Cuenta";
            this.tSBCuenta.Editable = this.FormEditStatus != BROWSE;                        
            this.tSBCuenta.AceptarClick += tSBCuenta_AceptarClick;
            #endregion Inicializar TextSearchBoxes
        }

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

        #region Cuenta Depósito
        private void tSBCuenta_AceptarClick(object sender, EventArgs e)
        {
            if (this.tSBMoneda.KeyMember.Trim() == string.Empty)
            {
                MessageBox.Show("Debe ingresar una moneda.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (fPickCuenta == null)
            {
                fPickCuenta = new frmPickBase();
                fPickCuenta.AceptarFiltrarClick += fPickCuenta_AceptarFiltrarClick;
                fPickCuenta.FiltrarClick += fPickCuenta_FiltrarClick;
                fPickCuenta.Titulo = "Elegir Cuenta";
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
                int monedaID = Convert.ToInt32(this.tSBMoneda.KeyMember);
                
                var query = (from cb in this.DBContext.cb_cuentabanco
                             join ba in this.DBContext.ba_banco
                                on cb.cb_bancoid equals ba.ba_bancoid
                             select new CuentaType
                             {
                                 CuentaID = cb.cb_cuentabancoid,
                                 CuentaDescripcion = cb.cb_descripcion,
                                 CuentaNumero = cb.cb_nrocuenta,
                                 BancoID = cb.cb_bancoid,
                                 BancoNombre = ba.ba_descripcion,
                                 MonedaID = cb.cb_monedaid
                             }).Where(a => a.MonedaID == monedaID);

                fPickCuenta.LoadData<CuentaType>(query.AsQueryable(), fPickCuenta.GetWhereString());
            }
        }

        private void fPickCuenta_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBCuenta.DisplayMember = fPickCuenta.ValorDescrip;
            this.tSBCuenta.KeyMember = fPickCuenta.ValorID;

            this.txtBancoID.Text = fPickCuenta.GetValor(CAMPO_BANCOID).ToString();
            this.txtBancoNombre.Text = fPickCuenta.GetValor(CAMPO_BANCONOMBRE).ToString();
            this.txtNroCuenta.Text = fPickCuenta.GetValor(CAMPO_NROCUENTA).ToString();

            fPickCuenta.Close();
            fPickCuenta.Dispose();

            this.btnAceptar.Focus();
        }
        #endregion Cuenta Depósito
        #endregion Picks

        private void CargarDatos(ClienteContinenteCuentaMoneda ccm)
        {
            this.txtID.Text = ccm.CCCMID.ToString();
            this.txtCampoID.Text = ccm.ConCliID.ToString();
            this.txtDescripcionCampo.Text = ccm.ConCliDescripcion;
            this.tSBMoneda.KeyMember = ccm.MonedaID.ToString();
            this.tSBMoneda.DisplayMember = ccm.MonedaDescripcion.ToString();
            this.tSBCuenta.KeyMember = ccm.CuentaID.ToString();
            this.tSBCuenta.DisplayMember = ccm.CuentaDescripcion;
            this.txtNroCuenta.Text = ccm.CuentaNumero;
            this.txtBancoID.Text = ccm.BancoID.ToString();
            this.txtBancoNombre.Text = ccm.BancoDescripcion.ToString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.tSBMoneda.KeyMember.Trim() == string.Empty)
            {
                MessageBox.Show("Debe indicar obligatoriamente una moneda.",
                                "Atención Requerida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }

            if (this.tSBCuenta.KeyMember.Trim() == string.Empty)
            {
                MessageBox.Show("Debe indicar obligatoriamente una cuenta.",
                                "Atención Requerida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }

            string caption = "Cuentas por Continente";
            string message = "Se guardará el registro ¿Desea continuar?";

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
                    this.Guardar();
                }
            }
        }

        private void Guardar()
        {
            bool success = false;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        int id = this.txtID.Text != string.Empty ? Convert.ToInt32(this.txtID.Text) : -1;
                        ccm_conclictamoneda ccm = new ccm_conclictamoneda();

                        if (id > -1)
                        {
                            ccm = context.ccm_conclictamoneda.First(a => a.ccm_conclictamonedaid == id);
                        }

                        ccm.ccm_tiporelacion = this.TipoRelacion == CONTINENTE ? TIPORELACIONCONTINENTE : TIPORELACIONCLIENTE;
                        ccm.ccm_concliid = Convert.ToInt32(this.txtCampoID.Text);
                        ccm.ccm_monedaid = Convert.ToInt32(this.tSBMoneda.KeyMember);
                        ccm.ccm_cuentabancoid = Convert.ToInt32(this.tSBCuenta.KeyMember);

                        if (id == -1)
                            context.ccm_conclictamoneda.Add(ccm);

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
                MessageBox.Show("Operación completada con éxito.", "Información", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information,
                                new EventHandler(DialogHandlerClose));
            }
        }

        private void DialogHandlerClose(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FCuentaPorClienteContinente_Load(object sender, EventArgs e)
        {
            if (this.FormEditStatus != BROWSE)
                this.tSBMoneda.SetFocus();
            else
                this.btnCancelar.Focus();
        }        
    }
}