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
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.ObjectModel;

#endregion

namespace SPF.UserControls.UI
{
    public partial class ucAntecedentesCliente : ucBaseForm
    {
        #region Variables Globales
        frmPickBase fPickEnviadoPor;
        frmPickBase fPickAutorizadoPor;
        frmPickBase fPickTramite;
        int ClienteID = -1;
        int usuarioID = -1;
        #endregion Variables Globales

        #region Constantes
        public const string CAMPO_ANTECEDENTEID                 = "AntecedenteID";
        public const string CAMPO_CLIENTETEID                   = "ClienteID";
        public const string CAMPO_CLIENTENOMBRE                 = "ClienteNombre";
        public const string CAMPO_TIPOANTECEDENTEID             = "TipoAntecedenteID";
        public const string CAMPO_TIPOANTECEDENTENOMBRE         = "TipoAntecedenteNombre";
        public const string CAMPO_TARIFARIOID                   = "TarifarioID";
        public const string CAMPO_OBSERVACION                   = "Observacion";
        public const string CAMPO_TIPOANTECEDENTELOCALID        = "TipoAntecedenteLocal";
        public const string CAMPO_TIPOANTECEDENTELOCALNOMBRE    = "TipoAntecedenteLocalNombre";
        public const string CAMPO_USUARIOENVIAID                = "UsuarioEnviaID";
        public const string CAMPO_USUARIOENVIANOMBRE            = "UsuarioEnviaNombre";
        public const string CAMPO_USUARIOAUTORIZAID             = "UsuarioAutorizaID";
        public const string CAMPO_USUARIOAUTORIZANOMBRE         = "UsuarioAutorizaNombre";
        public const string CAMPO_FECHAANTECEDENTE              = "FechaAntecedente";
        public const string CAMPO_TRAMITEID                     = "TramiteID";
        public const string CAMPO_TRAMITEDESCRIP                = "TramiteDescrip";
        public const string CAMPO_REGISTRONRO                   = "RegistroNro";
        public const string CAMPO_ACTANRO                       = "ActaNro";
        public const string CAMPO_ACTANIO                       = "ActaAnio";
        public const string CAMPO_TIENEAUTORIZACIONVIG          = "TieneAutorizacionVigente";

        private const int TIPO_DOCUMENTO = 2;
        #endregion Constantes

        public ucAntecedentesCliente()
        {
            InitializeComponent();
        }

        public ucAntecedentesCliente(string clienteid, string nombreCliente, string Titulo = "Sin Título", BerkeDBEntities dbContext = null, bool esForm = true) 
        {
            InitializeComponent();
            this.Titulo = Titulo;
            this.ClienteID = Convert.ToInt32(clienteid);
            this.txtClienteID.Text = this.ClienteID.ToString();
            this.txtClienteNombre.Text = nombreCliente;
            this.DBContext = dbContext;
            this.dtpFecha.Format = DateTimePickerFormat.Short;
            this.isForm = esForm;
            this.usuarioID = Convert.ToInt32(VWGContext.Current.Session["UsuarioID"].ToString());

            var antec = (from cliAnte in this.DBContext.ca_clienteantecedente
                         join cliente in this.DBContext.Cliente
                             on cliAnte.ca_clienteid equals cliente.ID
                         join tipoAnte in this.DBContext.ta_tipoantecedente
                             on cliAnte.ca_tipoantecedenteid equals tipoAnte.ta_tipoantecedenteid
                         join usuAuto in this.DBContext.Usuario
                             on cliAnte.ca_autorizadopor equals usuAuto.ID into usuAuto_Usuario
                             from usuAuto in usuAuto_Usuario.DefaultIfEmpty()
                         join usuEnvi in this.DBContext.Usuario
                             on cliAnte.ca_enviadopor equals usuEnvi.ID into usuEnvi_Usuario
                             from usuEnvi in usuEnvi_Usuario.DefaultIfEmpty()
                         join tramite in this.DBContext.Tramite
                            on cliAnte.ca_tramiteid equals tramite.ID into tramite_cliAnte
                            from tramite in tramite_cliAnte.DefaultIfEmpty()
                         select new AntecedentesClienteType
                         {
                             FechaAntecedente = cliAnte.ca_fechaantecedente,
                             ClienteNombre = cliente.Nombre,
                             AntecedenteID = cliAnte.ca_clienteantecedentid,
                             ClienteID = cliAnte.ca_clienteid,
                             TipoAntecedenteID = cliAnte.ca_tipoantecedenteid,
                             TipoAntecedenteNombre = tipoAnte.ta_descripantecedente,
                             TarifarioID = cliAnte.ca_tarifarioid,
                             Observacion = cliAnte.ca_observacion,
                             TipoAntecedenteLocal = cliAnte.ca_tipoantecedente,
                             UsuarioEnviaID = cliAnte.ca_enviadopor,
                             UsuarioEnviaNombre = usuEnvi.NombrePila,
                             UsuarioAutorizaID = cliAnte.ca_autorizadopor,
                             UsuarioAutorizaNombre = usuAuto.NombrePila,
                             TramiteID = cliAnte.ca_tramiteid,
                             TramiteDescrip = tramite.Descrip,
                             ActaNro = cliAnte.ca_actanro,
                             ActaAnio = cliAnte.ca_actaanio,
                             RegistroNro = cliAnte.ca_registronro,
                             TieneAutorizacionVigente = this.DBContext.GetAutorizacionPorDocumentoID(TIPO_DOCUMENTO,
                                                                                                     cliAnte.ca_clienteantecedentid,
                                                                                                     this.usuarioID)
                                                                                                     .FirstOrDefault().Value
                         })
                         .Where(a => a.ClienteID == this.ClienteID)
                         .OrderByDescending(a => a.FechaAntecedente);


            this.BindingSourceBase = antec.ToList();

            #region Especificar campos para filtro
            this.SetFilter(CAMPO_ANTECEDENTEID, "ID Antecedente", false);
            this.SetFilter(CAMPO_TIPOANTECEDENTEID, "Tipo Antec. ID", false);
            this.SetFilter(CAMPO_TIPOANTECEDENTENOMBRE, "Tipo Antec. Nombre");
            this.SetFilter(CAMPO_TRAMITEID, "Trámite ID", false);
            this.SetFilter(CAMPO_TRAMITEDESCRIP, "Descripción Trámite");
            this.SetFilter(CAMPO_USUARIOENVIANOMBRE, "Usuario Envío");
            this.SetFilter(CAMPO_USUARIOAUTORIZANOMBRE, "Usuario Autoriza");
            this.SetFilter(CAMPO_FECHAANTECEDENTE, "Fecha");
            this.SetFilter(CAMPO_OBSERVACION, "Observación");
            this.TituloBuscador = "Buscar Antecedentes de Clientes";
            #endregion Especificar campos para filtro

            this.cargarCBTipoAntecedente();

            #region Inicializar TextSearchBoxes
            this.tSBEnviadoPor.KeyMemberWidth = 35;
            this.tSBEnviadoPor.ToolTip = "Elegir Persona que Envía";
            this.tSBEnviadoPor.AceptarClick += tSBEnviadoPor_AceptarClick;

            this.tSBAutorizadoPor.KeyMemberWidth = 35;
            this.tSBAutorizadoPor.ToolTip = "Elegir Persona que Autoriza";
            this.tSBAutorizadoPor.AceptarClick += tSBAutorizadoPor_AceptarClick;

            this.tSBTramite.KeyMemberWidth = 35;
            this.tSBTramite.ToolTip = "Elegir Trámite";
            this.tSBTramite.AceptarClick += tSBTramite_AceptarClick;
            #endregion Inicializar TextSearchBoxes
        }

        #region Combo Tipos de Antecedentes
        private void cargarCBTipoAntecedente()
        {
            bool existeVacio = true;
            this.DBContext.ta_tipoantecedente.Where(b => b.ta_descripantecedente != String.Empty).Load();

            try
            {
                ta_tipoantecedente ta = this.DBContext.ta_tipoantecedente.Local.First(b => b.ta_tipoantecedenteid == -1);
            }
            catch (InvalidOperationException)
            {
                existeVacio = false;
            }

            if (!existeVacio)
                this.DBContext.ta_tipoantecedente.Local.Add(new ta_tipoantecedente { ta_tipoantecedenteid = -1, ta_descripantecedente = "" });

            this.cbTipoAntecedente.DataSource = this.DBContext.ta_tipoantecedente.Local.OrderBy(a => a.ta_tipoantecedenteid).ToList();
            this.cbTipoAntecedente.DisplayMember = "ta_descripantecedente";
            this.cbTipoAntecedente.ValueMember = "ta_tipoantecedenteid";
        }
        #endregion Combo Idioma

        #region Picks
        private void tSBEnviadoPor_AceptarClick(object sender, EventArgs e)
        {
            if (fPickEnviadoPor == null)
            {
                fPickEnviadoPor = new frmPickBase();
                fPickEnviadoPor.AceptarFiltrarClick += fPickEnviadoPor_AceptarFiltrarClick;
                fPickEnviadoPor.FiltrarClick += fPickEnviadoPor_FiltrarClick;
                fPickEnviadoPor.Titulo = "Elegir Persona que Envía";
                fPickEnviadoPor.CampoIDNombre = "ID";
                fPickEnviadoPor.CampoDescripNombre = "NombrePila";
                fPickEnviadoPor.LabelCampoID = "ID";
                fPickEnviadoPor.LabelCampoDescrip = "Nombre";
                fPickEnviadoPor.NombreCampo = "Usuario";
                fPickEnviadoPor.PermitirFiltroNulo = true;
            }
            fPickEnviadoPor.MostrarFiltro();
        }

        private void fPickEnviadoPor_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickEnviadoPor != null)
            {
                fPickEnviadoPor.LoadData<Usuario>(this.DBContext.Usuario, fPickEnviadoPor.GetWhereString());
            }
        }

        private void fPickEnviadoPor_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBEnviadoPor.DisplayMember = fPickEnviadoPor.ValorDescrip;
            this.tSBEnviadoPor.KeyMember = fPickEnviadoPor.ValorID;

            fPickEnviadoPor.Close();
            fPickEnviadoPor.Dispose();
        }

        private void tSBAutorizadoPor_AceptarClick(object sender, EventArgs e)
        {
            if (fPickAutorizadoPor == null)
            {
                fPickAutorizadoPor = new frmPickBase();
                fPickAutorizadoPor.AceptarFiltrarClick += fPickAutorizadoPor_AceptarFiltrarClick;
                fPickAutorizadoPor.FiltrarClick += fPickAutorizadoPor_FiltrarClick;
                fPickAutorizadoPor.Titulo = "Elegir Persona que Autoriza";
                fPickAutorizadoPor.CampoIDNombre = "ID";
                fPickAutorizadoPor.CampoDescripNombre = "NombrePila";
                fPickAutorizadoPor.LabelCampoID = "ID";
                fPickAutorizadoPor.LabelCampoDescrip = "Nombre";
                fPickAutorizadoPor.NombreCampo = "Usuario";
                fPickAutorizadoPor.PermitirFiltroNulo = true;
            }
            fPickAutorizadoPor.MostrarFiltro();
        }

        private void fPickAutorizadoPor_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickAutorizadoPor != null)
            {
                fPickAutorizadoPor.LoadData<Usuario>(this.DBContext.Usuario, fPickAutorizadoPor.GetWhereString());
            }
        }

        private void fPickAutorizadoPor_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBAutorizadoPor.DisplayMember = fPickAutorizadoPor.ValorDescrip;
            this.tSBAutorizadoPor.KeyMember = fPickAutorizadoPor.ValorID;

            fPickAutorizadoPor.Close();
            fPickAutorizadoPor.Dispose();
        }

        private void tSBTramite_AceptarClick(object sender, EventArgs e)
        {
            if (fPickTramite == null)
            {
                fPickTramite = new frmPickBase();
                fPickTramite.AceptarFiltrarClick += fPickTramite_AceptarFiltrarClick;
                fPickTramite.FiltrarClick += fPickTramite_FiltrarClick;
                fPickTramite.Titulo = "Elegir Trámite";
                fPickTramite.CampoIDNombre = "ID";
                fPickTramite.CampoDescripNombre = "Descrip";
                fPickTramite.LabelCampoID = "ID";
                fPickTramite.LabelCampoDescrip = "Descripción";
                fPickTramite.NombreCampo = "Trámite";
                fPickTramite.PermitirFiltroNulo = true;
            }
            fPickTramite.MostrarFiltro();
            fPickTramite_FiltrarClick(sender, e);
        }

        private void fPickTramite_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickTramite != null)
            {
                fPickTramite.LoadData<Tramite>(this.DBContext.Tramite, fPickTramite.GetWhereString());
            }
        }

        private void fPickTramite_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBTramite.DisplayMember = fPickTramite.ValorDescrip;
            this.tSBTramite.KeyMember = fPickTramite.ValorID;

            fPickTramite.Close();
            fPickTramite.Dispose();
        }
        #endregion Picks

        #region Método Extendidos del ParentControl
        protected override void FilterEntity(string where = "", object[] filterParams = null)
        {
            try
            {
                this.limpiarDatos();

                var query = (from cliAnte in this.DBContext.ca_clienteantecedente
                             join cliente in this.DBContext.Cliente
                                 on cliAnte.ca_clienteid equals cliente.ID
                             join tipoAnte in this.DBContext.ta_tipoantecedente
                                 on cliAnte.ca_tipoantecedenteid equals tipoAnte.ta_tipoantecedenteid
                             join usuAuto in this.DBContext.Usuario
                                 on cliAnte.ca_autorizadopor equals usuAuto.ID into usuAuto_Usuario
                             from usuAuto in usuAuto_Usuario.DefaultIfEmpty()
                             join usuEnvi in this.DBContext.Usuario
                                on cliAnte.ca_enviadopor equals usuEnvi.ID into usuEnvi_Usuario
                                from usuEnvi in usuEnvi_Usuario.DefaultIfEmpty()
                             join tramite in this.DBContext.Tramite
                                on cliAnte.ca_tramiteid equals tramite.ID into tramite_cliAnte
                                from tramite in tramite_cliAnte.DefaultIfEmpty()
                             select new AntecedentesClienteType
                             {
                                 FechaAntecedente = cliAnte.ca_fechaantecedente,
                                 ClienteNombre = cliente.Nombre,
                                 AntecedenteID = cliAnte.ca_clienteantecedentid,
                                 ClienteID = cliAnte.ca_clienteid,
                                 TipoAntecedenteID = cliAnte.ca_tipoantecedenteid,
                                 TipoAntecedenteNombre = tipoAnte.ta_descripantecedente,
                                 TarifarioID = cliAnte.ca_tarifarioid,
                                 Observacion = cliAnte.ca_observacion,
                                 TipoAntecedenteLocal = cliAnte.ca_tipoantecedente,
                                 UsuarioEnviaID = cliAnte.ca_enviadopor,
                                 UsuarioEnviaNombre = usuEnvi.NombrePila,
                                 UsuarioAutorizaID = cliAnte.ca_autorizadopor,
                                 UsuarioAutorizaNombre = usuAuto.NombrePila,
                                 TramiteID = cliAnte.ca_tramiteid,
                                 TramiteDescrip = tramite.Descrip,
                                 ActaNro = cliAnte.ca_actanro,
                                 ActaAnio = cliAnte.ca_actaanio,
                                 RegistroNro = cliAnte.ca_registronro,
                                 TieneAutorizacionVigente = this.DBContext.GetAutorizacionPorDocumentoID(TIPO_DOCUMENTO,
                                                                                                     cliAnte.ca_clienteantecedentid,
                                                                                                     this.usuarioID)
                                                                                                     .FirstOrDefault().Value
                             });

                if (where != "")
                {
                    where += " AND ClienteID = " + this.ClienteID.ToString();
                    this.BindingSourceBase = query.Where(where, filterParams).OrderByDescending(a => a.FechaAntecedente).ToList();
                }
                else
                {
                    where = "ClienteID = " + this.ClienteID.ToString();
                    this.BindingSourceBase = query.Where(where).OrderByDescending(a => a.FechaAntecedente).ToList();
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

            foreach(DataGridViewColumn col in this.dgvListadoABM.Columns)
            {
                col.Visible = false;
            }

            int displayIndex = 0;

            this.dgvListadoABM.Columns[CAMPO_FECHAANTECEDENTE].HeaderText = "Fecha";
            this.dgvListadoABM.Columns[CAMPO_FECHAANTECEDENTE].Width = 60;
            this.dgvListadoABM.Columns[CAMPO_FECHAANTECEDENTE].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_FECHAANTECEDENTE].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_TRAMITEDESCRIP].HeaderText = "Trámite";
            this.dgvListadoABM.Columns[CAMPO_TRAMITEDESCRIP].Width = 150;
            this.dgvListadoABM.Columns[CAMPO_TRAMITEDESCRIP].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_TRAMITEDESCRIP].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_TIPOANTECEDENTENOMBRE].HeaderText = "Tipo Antecedente";
            this.dgvListadoABM.Columns[CAMPO_TIPOANTECEDENTENOMBRE].Width = 150;
            this.dgvListadoABM.Columns[CAMPO_TIPOANTECEDENTENOMBRE].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_TIPOANTECEDENTENOMBRE].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_OBSERVACION].HeaderText = "Observación";
            this.dgvListadoABM.Columns[CAMPO_OBSERVACION].Width = 200;
            this.dgvListadoABM.Columns[CAMPO_OBSERVACION].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_OBSERVACION].Visible = true;
            displayIndex++;
                        
            this.dgvListadoABM.Columns[CAMPO_USUARIOAUTORIZANOMBRE].HeaderText = "Autorizado Por";
            this.dgvListadoABM.Columns[CAMPO_USUARIOAUTORIZANOMBRE].Width = 100;
            this.dgvListadoABM.Columns[CAMPO_USUARIOAUTORIZANOMBRE].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_USUARIOAUTORIZANOMBRE].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_USUARIOENVIANOMBRE].HeaderText = "Enviado Por";
            this.dgvListadoABM.Columns[CAMPO_USUARIOENVIANOMBRE].Width = 100;
            this.dgvListadoABM.Columns[CAMPO_USUARIOENVIANOMBRE].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_USUARIOENVIANOMBRE].Visible = true;
            displayIndex++;            
        }

        protected override void tbbNuevo_Click(object sender, EventArgs e)
        {
            base.tbbNuevo_Click(sender, e);
            this.limpiarDatos();
            this.dtpFecha.Text = DateTime.Now.ToShortDateString();
            this.dtpFecha.Focus();
        }

        protected override void tbbEditar_Click(object sender, EventArgs e)
        {
            if ((this.dgvListadoABM.RowCount > 0) && (this.txtTipoAntecedenteLocal.Text.Substring(0, 1) == "A") && (!this.lblAutorizacionVigente.Visible))
            {
                MessageBox.Show("No se pueden editar antecedentes generados automáticamente.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;

            }

            base.tbbEditar_Click(sender, e);
            this.dtpFecha.Focus();
        }
        #endregion Método Extendidos del ParentControl

        #region Controles Locales
        private void dgvListadoABM_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.txtIDAntecedente.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_ANTECEDENTEID].Value.ToString();
            this.txtClienteID.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_CLIENTETEID].Value.ToString();
            this.txtClienteNombre.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_CLIENTENOMBRE].Value.ToString();
            this.txtTipoAntecedenteLocal.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TIPOANTECEDENTELOCALNOMBRE].Value.ToString();


            if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_FECHAANTECEDENTE].Value != null)
                this.dtpFecha.Text = Convert.ToDateTime(((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_FECHAANTECEDENTE].Value).ToShortDateString();

            if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TIPOANTECEDENTEID].Value != null)
            {
                this.cbTipoAntecedente.SelectedValue = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TIPOANTECEDENTEID].Value;
            }

            if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_USUARIOAUTORIZAID].Value != null)
            {
                this.tSBAutorizadoPor.KeyMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_USUARIOAUTORIZAID].Value.ToString();
                this.tSBAutorizadoPor.DisplayMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_USUARIOAUTORIZANOMBRE].Value.ToString();
            }

            if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_USUARIOENVIAID].Value != null)
            {
                this.tSBEnviadoPor.KeyMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_USUARIOENVIAID].Value.ToString();
                this.tSBEnviadoPor.DisplayMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_USUARIOENVIANOMBRE].Value.ToString();
            }

            if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_OBSERVACION].Value != null)
            {
                this.txtObservaciones.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_OBSERVACION].Value.ToString();
            }

            if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TRAMITEID].Value != null)
            {
                this.tSBTramite.KeyMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TRAMITEID].Value.ToString();
                this.tSBTramite.DisplayMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TRAMITEDESCRIP].Value.ToString();
            }

            if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_ACTANIO].Value != null)
            {
                this.txtEdActaAnio.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_ACTANIO].Value.ToString();
            }

            if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_ACTANRO].Value != null)
            {
                this.txtEdActaNro.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_ACTANRO].Value.ToString();
            }

            if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_REGISTRONRO].Value != null)
            {
                this.txtEdRegistroNro.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_REGISTRONRO].Value.ToString();
            }

            this.lblAutorizacionVigente.Visible = (bool)((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TIENEAUTORIZACIONVIG].Value;
        }

        private void tbbGuardar_Click(object sender, EventArgs e)
        {
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
            if (this.txtTipoAntecedenteLocal.Text.Substring(0,1) == "A" )
            {
                MessageBox.Show("No se pueden eliminar antecedentes generados automáticamente.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;

            }


            string caption = "Eliminación de registro";
            string message = "Se eliminará el presente registro ¿Desea continuar?";
            
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(DialogHandler));
        
        }
        #endregion Controles Locales

        #region ReadOnly condicional
        protected override void Editable(bool editar)
        {
            this.tSBAutorizadoPor.Editable = !editar;
            this.tSBEnviadoPor.Editable = !editar;
            this.tSBTramite.Editable = !editar;
            this.cbTipoAntecedente.Enabled = !editar;
            this.txtObservaciones.ReadOnly = editar;
            this.txtEdActaNro.ReadOnly = editar;
            this.txtEdActaAnio.ReadOnly = editar;
            this.txtEdRegistroNro.ReadOnly = editar;
            this.dtpFecha.Enabled = !editar;
        }
        #endregion ReadOnly condicional

        #region Limpiar Datos
        private void limpiarDatos()
        {
            this.txtIDAntecedente.Text = "";
            this.cbTipoAntecedente.SelectedValue = -1;
            this.tSBEnviadoPor.Clear();
            this.tSBAutorizadoPor.Clear();
            this.tSBTramite.Clear();
            this.txtObservaciones.Text = "";
            this.txtEdActaNro.Text = "";
            this.txtEdActaAnio.Text = "";
            this.txtEdRegistroNro.Text = "";
        }
        #endregion Limpiar Datos

        #region CRUD
        private void EliminarRegistro()
        {
            bool success = false;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        this.eliminarAntecedente(context);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        success = true;
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

        private void GuardarRegistro()
        {
            bool success = false;
            
            ca_clienteantecedente ca = null;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        ca = this.guardarAntecedente(context);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        success = true;
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
                if (this.FormEditStatus != BROWSE)
                    this.FilterEntity(this.WhereString, this.FilterParam);

                this.FormEditStatus = BROWSE;
                MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region Métodos de Edición de Datos
        private ca_clienteantecedente guardarAntecedente(BerkeDBEntities context = null)
        {
            ca_clienteantecedente ca = new ca_clienteantecedente();
            if (this.FormEditStatus == EDIT)
            {
                int antecedenteID = Convert.ToInt32(this.txtIDAntecedente.Text);

                ca = context.ca_clienteantecedente.First(a => a.ca_clienteantecedentid == antecedenteID);

                ca.ca_tipoantecedente = "M";
                ca.ca_clienteid = this.ClienteID;
                ca.ca_fechaantecedente = Convert.ToDateTime(this.dtpFecha.Text);

                if ((int)this.cbTipoAntecedente.SelectedValue != -1)
                    ca.ca_tipoantecedenteid = (int)this.cbTipoAntecedente.SelectedValue;

                if (this.tSBAutorizadoPor.KeyMember != "")
                    ca.ca_autorizadopor = Convert.ToInt32(this.tSBAutorizadoPor.KeyMember);
                else
                    ca.ca_autorizadopor = null;

                if (this.tSBEnviadoPor.KeyMember != "")
                    ca.ca_enviadopor = Convert.ToInt32(this.tSBEnviadoPor.KeyMember);
                else
                    ca.ca_enviadopor = null;

                if (this.tSBTramite.KeyMember != "")
                    ca.ca_tramiteid = Convert.ToInt32(this.tSBTramite.KeyMember);
                else
                    ca.ca_tramiteid = null;

                if (this.txtEdActaNro.Text != "")
                    ca.ca_actanro = Convert.ToInt32(this.txtEdActaNro.Text);
                else
                    ca.ca_actanro = null;

                if (this.txtEdActaAnio.Text != "")
                    ca.ca_actaanio = Convert.ToInt32(this.txtEdActaAnio.Text);
                else
                    ca.ca_actaanio = null;

                if (this.txtEdRegistroNro.Text != "")
                    ca.ca_registronro = Convert.ToInt32(this.txtEdRegistroNro.Text);
                else
                    ca.ca_registronro = null;

                ca.ca_observacion = this.txtObservaciones.Text;

            }
            else if (this.FormEditStatus == INSERT)
            {
                ca.ca_tipoantecedente = "M";
                ca.ca_clienteid = this.ClienteID;
                ca.ca_fechaantecedente = Convert.ToDateTime(this.dtpFecha.Text);

                if ((int)this.cbTipoAntecedente.SelectedValue != -1)
                    ca.ca_tipoantecedenteid = (int)this.cbTipoAntecedente.SelectedValue;

                if (this.tSBAutorizadoPor.KeyMember != "")
                    ca.ca_autorizadopor = Convert.ToInt32(this.tSBAutorizadoPor.KeyMember);
                else
                    ca.ca_autorizadopor = null;

                if (this.tSBEnviadoPor.KeyMember != "")
                    ca.ca_enviadopor = Convert.ToInt32(this.tSBEnviadoPor.KeyMember);
                else
                    ca.ca_enviadopor = null;

                if (this.tSBTramite.KeyMember != "")
                    ca.ca_tramiteid = Convert.ToInt32(this.tSBTramite.KeyMember);
                else
                    ca.ca_tramiteid = null;

                if (this.txtEdActaNro.Text != "")
                    ca.ca_actanro = Convert.ToInt32(this.txtEdActaNro.Text);
                else
                    ca.ca_actanro = null;

                if (this.txtEdActaAnio.Text != "")
                    ca.ca_actaanio = Convert.ToInt32(this.txtEdActaAnio.Text);
                else
                    ca.ca_actaanio = null;

                if (this.txtEdRegistroNro.Text != "")
                    ca.ca_registronro = Convert.ToInt32(this.txtEdRegistroNro.Text);
                else
                    ca.ca_registronro = null;

                ca.ca_observacion = this.txtObservaciones.Text;

                context.ca_clienteantecedente.Add(ca);
            }

            return ca;
        }

        private void eliminarAntecedente(BerkeDBEntities context = null)
        {
            int antecedenteID = Convert.ToInt32(this.txtIDAntecedente.Text);
            ca_clienteantecedente ca = context.ca_clienteantecedente.First(a => a.ca_clienteantecedentid == antecedenteID);

            context.ca_clienteantecedente.Remove(ca);
        }
        #endregion Métodos de Edición de Datos

        #endregion CRUD

    }
}