#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Transactions;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI;

using ModelEF6;
using SPF.Types;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.ObjectModel;

using SPF.Forms.Base;
using Microsoft.Reporting.WebForms;
#endregion

namespace SPF.UserControls.UI
{
    public partial class ucAutorizaciones : ucBaseForm
    {
        #region Variables Globales
        frmPickBase fPickAutorizadoA;
        frmPickBase fPickDocumento;
        #endregion Variables Globales

        #region Constantes
        public const string CAMPO_AUTORIZACIONCABID         = "AutorizacionCabID";
        public const string CAMPO_TIPODOCUMENTOID           = "TipoDocumentoID";
        public const string CAMPO_DOCUMENTOID               = "DocumentoID";
        public const string CAMPO_DOCUMENTONOMBRE           = "DocumentoNombre";
        public const string CAMPO_USUARIOAUTORIZADORID      = "UsuarioAutorizadorID";
        public const string CAMPO_USUARIOAUTORIZADORNOMBRE  = "UsuarioAutorizadorNombre";
        public const string CAMPO_USUARIOAUTORIZADOID       = "UsuarioAutorizadoID";
        public const string CAMPO_USUARIOAUTORIZADONOMBRE   = "UsuarioAutorizadoNombre";
        public const string CAMPO_MOTIVO                    = "Motivo";
        public const string CAMPO_FECHADESDE                = "FechaDesde";
        public const string CAMPO_FECHAHASTA                = "FechaHasta";
        public const int SISTEMA_ID = 1;
        #endregion Constantes

        #region Constructores
        public ucAutorizaciones()
        {
            InitializeComponent();
        }

        public ucAutorizaciones(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();
            this.Titulo = Titulo;
            this.DBContext = dbContext;
            this.FormEditStatus = NONE;

            this.dtpFechaHasta.Format = DateTimePickerFormat.Short;

            var query = (from autorizacion in this.DBContext.ad_autorizaciondocumento
                         join usuarioAutorizador in this.DBContext.Usuario
                             on autorizacion.ad_usuarioautorizador equals usuarioAutorizador.ID
                         join usuarioAutorizado in this.DBContext.Usuario
                             on autorizacion.ad_usuarioautorizado equals usuarioAutorizado.ID
                         join tipodocumento in this.DBContext.td_tipodocumento
                             on autorizacion.ad_tipodocumentoautid equals tipodocumento.td_tipodocumentoid
                         select new AutorizacionType
                         {
                             AutorizacionCabID = autorizacion.ad_autorizacioncabid,
                             TipoDocumentoID = autorizacion.ad_tipodocumentoautid,
                             DocumentoID = autorizacion.ad_documentoid,
                             DocumentoNombre = tipodocumento.td_descripcion,
                             UsuarioAutorizadorID = usuarioAutorizador.ID,
                             UsuarioAutorizadorNombre = usuarioAutorizador.NombrePila,
                             UsuarioAutorizadoID = usuarioAutorizado.ID,
                             UsuarioAutorizadoNombre = usuarioAutorizado.NombrePila,
                             FechaDesde = autorizacion.ad_fechadesde,
                             FechaHasta = autorizacion.ad_fechahasta,
                             Motivo = autorizacion.ad_motivo,
                             SistemaID = tipodocumento.td_sistemaid
                         })
                        .Where( a => a.SistemaID == SISTEMA_ID )
                        .Take(50)
                        .OrderByDescending(a => a.AutorizacionCabID);

            this.BindingSourceBase = query.ToList();

            #region Especificar campos para filtro
            this.SetFilter("AutorizacionCabID", "ID Autorización", false);
            this.SetFilter("TipoDocumentoID", "Tipo Documento ID", false);
            this.SetFilter("DocumentoID", "Documento ID", false);
            this.SetFilter("UsuarioAutorizadorNombre", "Usuario Autorizador");
            this.SetFilter("UsuarioAutorizadoNombre", "Usuario Autorizado");
            this.SetFilter("FechaDesde", "Fecha Desde");
            this.SetFilter("FechaHasta", "Fecha Hasta");
            this.SetFilter("Motivo", "Motivo");
            this.TituloBuscador = "Buscar Autorizaciones";
            #endregion Especificar campos para filtro

            #region Inicializar TextSearchBoxes
            this.tSBUsuarioAutorizado.KeyMemberWidth = 35;
            this.tSBUsuarioAutorizado.ToolTip = "Elegir Usuario al que se autoriza";
            this.tSBUsuarioAutorizado.AceptarClick += tSBUsuarioAutorizado_AceptarClick;

            this.tSBDocumento.KeyMemberWidth = 35;
            this.tSBDocumento.ToolTip = "Elegir Documento a Autorizar";
            this.tSBDocumento.AceptarClick += tSBDocumento_AceptarClick;

            #endregion Inicializar TextSearchBoxes
        }
        #endregion Constructores

        #region Picks
        private void tSBDocumento_AceptarClick(object sender, EventArgs e)
        {
            if (fPickDocumento == null)
            {
                fPickDocumento = new frmPickBase();
                fPickDocumento.AceptarFiltrarClick += fPickDocumento_AceptarFiltrarClick;
                fPickDocumento.FiltrarClick += fPickDocumento_FiltrarClick;
                fPickDocumento.Titulo = "Elegir Documento a Autorizar";
                fPickDocumento.CampoIDNombre = "td_tipodocumentoid";
                fPickDocumento.CampoDescripNombre = "td_descripcion";
                fPickDocumento.LabelCampoID = "ID";
                fPickDocumento.LabelCampoDescrip = "Documento";
                fPickDocumento.NombreCampo = "Documento";
                fPickDocumento.PermitirFiltroNulo = true;
            }
            fPickDocumento.MostrarFiltro();
            this.fPickDocumento_FiltrarClick(sender, e);
        }

        private void fPickDocumento_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickDocumento != null)
            {
                fPickDocumento.LoadData<td_tipodocumento>(this.DBContext.td_tipodocumento.Where(a => a.td_mostrar == true && a.td_sistemaid == SISTEMA_ID),
                                                          fPickDocumento.GetWhereString());
            }
        }

        private void fPickDocumento_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBDocumento.DisplayMember = fPickDocumento.ValorDescrip;
            this.tSBDocumento.KeyMember = fPickDocumento.ValorID;

            fPickDocumento.Close();
            fPickDocumento.Dispose();
        }

        private void tSBUsuarioAutorizado_AceptarClick(object sender, EventArgs e)
        {
            if (fPickAutorizadoA == null)
            {
                fPickAutorizadoA = new frmPickBase();
                fPickAutorizadoA.AceptarFiltrarClick += fPickAutorizadoA_AceptarFiltrarClick;
                fPickAutorizadoA.FiltrarClick += fPickAutorizadoA_FiltrarClick;
                fPickAutorizadoA.Titulo = "Elegir Persona a quien se Autoriza";
                fPickAutorizadoA.CampoIDNombre = "ID";
                fPickAutorizadoA.CampoDescripNombre = "NombrePila";
                fPickAutorizadoA.LabelCampoID = "ID";
                fPickAutorizadoA.LabelCampoDescrip = "Nombre";
                fPickAutorizadoA.NombreCampo = "Usuario";
                fPickAutorizadoA.PermitirFiltroNulo = true;
            }
            fPickAutorizadoA.MostrarFiltro();
        }

        private void fPickAutorizadoA_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickAutorizadoA != null)
            {
                fPickAutorizadoA.LoadData<Usuario>(this.DBContext.Usuario, fPickAutorizadoA.GetWhereString());
            }
        }

        private void fPickAutorizadoA_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBUsuarioAutorizado.DisplayMember = fPickAutorizadoA.ValorDescrip;
            this.tSBUsuarioAutorizado.KeyMember = fPickAutorizadoA.ValorID;

            fPickAutorizadoA.Close();
            fPickAutorizadoA.Dispose();
        }
        #endregion Picks

        #region Método Extendidos del ParentControl
        protected override void FilterEntity(string where = "", object[] filterParams = null)
        {
            try
            {
                this.limpiarDatos();

                var query = (from autorizacion in this.DBContext.ad_autorizaciondocumento
                             join usuarioAutorizador in this.DBContext.Usuario
                                 on autorizacion.ad_usuarioautorizador equals usuarioAutorizador.ID
                             join usuarioAutorizado in this.DBContext.Usuario
                                 on autorizacion.ad_usuarioautorizado equals usuarioAutorizado.ID
                             join tipodocumento in this.DBContext.td_tipodocumento
                                 on autorizacion.ad_tipodocumentoautid equals tipodocumento.td_tipodocumentoid
                             select new AutorizacionType
                             {
                                 AutorizacionCabID = autorizacion.ad_autorizacioncabid,
                                 TipoDocumentoID = autorizacion.ad_tipodocumentoautid,
                                 DocumentoID = autorizacion.ad_documentoid,
                                 DocumentoNombre = tipodocumento.td_descripcion,
                                 UsuarioAutorizadorID = usuarioAutorizador.ID,
                                 UsuarioAutorizadorNombre = usuarioAutorizador.NombrePila,
                                 UsuarioAutorizadoID = usuarioAutorizado.ID,
                                 UsuarioAutorizadoNombre = usuarioAutorizado.NombrePila,
                                 FechaDesde = autorizacion.ad_fechadesde,
                                 FechaHasta = autorizacion.ad_fechahasta,
                                 Motivo = autorizacion.ad_motivo,
                                 SistemaID = tipodocumento.td_sistemaid
                             })
                             .Where( a => a.SistemaID == SISTEMA_ID );

                if (where != "")
                {
                    this.BindingSourceBase = query.Where(where, filterParams).OrderByDescending(a => a.AutorizacionCabID).ToList();
                }
                else
                {
                    this.BindingSourceBase = query.Take(50).OrderByDescending(a => a.AutorizacionCabID).ToList();
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
            }

            this.dgvListadoABM.Columns[CAMPO_AUTORIZACIONCABID].HeaderText = "ID";
            this.dgvListadoABM.Columns[CAMPO_AUTORIZACIONCABID].Width = 60;
            this.dgvListadoABM.Columns[CAMPO_AUTORIZACIONCABID].DisplayIndex = 0;
            this.dgvListadoABM.Columns[CAMPO_AUTORIZACIONCABID].Visible = true;

            this.dgvListadoABM.Columns[CAMPO_DOCUMENTOID].HeaderText = "ID Documento";
            this.dgvListadoABM.Columns[CAMPO_DOCUMENTOID].Width = 150;
            this.dgvListadoABM.Columns[CAMPO_DOCUMENTOID].DisplayIndex = 1;
            this.dgvListadoABM.Columns[CAMPO_DOCUMENTOID].Visible = true;

            this.dgvListadoABM.Columns[CAMPO_DOCUMENTONOMBRE].HeaderText = "Tipo Documento";
            this.dgvListadoABM.Columns[CAMPO_DOCUMENTONOMBRE].Width = 150;
            this.dgvListadoABM.Columns[CAMPO_DOCUMENTONOMBRE].DisplayIndex = 2;
            this.dgvListadoABM.Columns[CAMPO_DOCUMENTONOMBRE].Visible = true;

            this.dgvListadoABM.Columns[CAMPO_FECHADESDE].HeaderText = "Válido Desde";
            this.dgvListadoABM.Columns[CAMPO_FECHADESDE].Width = 100;
            this.dgvListadoABM.Columns[CAMPO_FECHADESDE].DisplayIndex = 3;
            this.dgvListadoABM.Columns[CAMPO_FECHADESDE].Visible = true;

            this.dgvListadoABM.Columns[CAMPO_FECHAHASTA].HeaderText = "Válido Hasta";
            this.dgvListadoABM.Columns[CAMPO_FECHAHASTA].Width = 100;
            this.dgvListadoABM.Columns[CAMPO_FECHAHASTA].DisplayIndex = 4;
            this.dgvListadoABM.Columns[CAMPO_FECHAHASTA].Visible = true;

            this.dgvListadoABM.Columns[CAMPO_USUARIOAUTORIZADONOMBRE].HeaderText = "Usuario Autorizado";
            this.dgvListadoABM.Columns[CAMPO_USUARIOAUTORIZADONOMBRE].Width = 200;
            this.dgvListadoABM.Columns[CAMPO_USUARIOAUTORIZADONOMBRE].DisplayIndex = 5;
            this.dgvListadoABM.Columns[CAMPO_USUARIOAUTORIZADONOMBRE].Visible = true;

            this.dgvListadoABM.Columns[CAMPO_USUARIOAUTORIZADORNOMBRE].HeaderText = "Usuario Autorizador";
            this.dgvListadoABM.Columns[CAMPO_USUARIOAUTORIZADORNOMBRE].Width = 200;
            this.dgvListadoABM.Columns[CAMPO_USUARIOAUTORIZADORNOMBRE].DisplayIndex = 6;
            this.dgvListadoABM.Columns[CAMPO_USUARIOAUTORIZADORNOMBRE].Visible = true;
        }

        protected override void tbbNuevo_Click(object sender, EventArgs e)
        {
            base.tbbNuevo_Click(sender, e);
            this.limpiarDatos();
            this.txtFechaDesde.Text = System.DateTime.Now.ToShortDateString();
            this.dtpFechaHasta.Text = DateTime.Now.AddDays(2).ToShortDateString();
            this.txtUsuarioAutorizadorID.Text = VWGContext.Current.Session["UsuarioID"].ToString();
            this.txtUsuarioAutorizadorNombre.Text = VWGContext.Current.Session["NombreUsuario"].ToString();
            this.tSBDocumento.Focus();
        }

        protected override void tbbEditar_Click(object sender, EventArgs e)
        {
            if ((this.dgvListadoABM.RowCount > 0) && (dtpFechaHasta.Value <= System.DateTime.Now ))
            {
                MessageBox.Show("No se pueden modificar autorizaciones vencidas.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;

            }

            base.tbbEditar_Click(sender, e);
            this.tSBDocumento.Focus();
        }

        #endregion Método Extendidos del ParentControl

        #region Controles Locales
        private void dgvListadoABM_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this.FormEditStatus != INSERT)
            {
                this.txtAutorizacionID.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_AUTORIZACIONCABID].Value.ToString();
                this.tSBDocumento.KeyMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TIPODOCUMENTOID].Value.ToString();
                this.tSBDocumento.DisplayMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_DOCUMENTONOMBRE].Value.ToString();
                this.txtUsuarioAutorizadorID.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_USUARIOAUTORIZADORID].Value.ToString();
                this.txtUsuarioAutorizadorNombre.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_USUARIOAUTORIZADORNOMBRE].Value.ToString();
                this.tSBUsuarioAutorizado.KeyMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_USUARIOAUTORIZADOID].Value.ToString();
                this.tSBUsuarioAutorizado.DisplayMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_USUARIOAUTORIZADONOMBRE].Value.ToString();
                this.txtFechaDesde.Text = Convert.ToDateTime(((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_FECHADESDE].Value).ToShortDateString();
                this.dtpFechaHasta.Text = Convert.ToDateTime(((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_FECHAHASTA].Value).ToShortDateString();
                this.txtMotivo.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_MOTIVO].Value.ToString();
                this.txtDocumentoID.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_DOCUMENTOID].Value.ToString();
            }
        }

        private void tbbGuardar_Click(object sender, EventArgs e)
        {
            if (this.txtMotivo.Text.Trim() == "")
            {
                MessageBox.Show("Debe indicar el motivo de la autorización.",
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
            if (dtpFechaHasta.Value <= System.DateTime.Now)
            {
                MessageBox.Show("No se pueden modificar autorizaciones vencidas.",
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
            this.tSBDocumento.Editable = !editar;
            this.tSBUsuarioAutorizado.Editable = !editar;
            //this.txtAutorizacionID.ReadOnly = !editar;
            //this.txtUsuarioAutorizadorID.ReadOnly = !editar;
            //this.txtUsuarioAutorizadorNombre.ReadOnly = !editar;
            //this.txtFechaDesde.ReadOnly = editar;
            this.dtpFechaHasta.Enabled = !editar;
            this.txtDocumentoID.ReadOnly = editar;
            this.txtMotivo.ReadOnly = editar;
        }
        #endregion ReadOnly condicional

        #region Limpiar Datos
        private void limpiarDatos()
        {
            this.txtAutorizacionID.Text = "";
            this.tSBDocumento.Clear();
            this.txtUsuarioAutorizadorID.Text = "";
            this.txtUsuarioAutorizadorNombre.Text = "";
            this.tSBUsuarioAutorizado.Clear();
            this.txtFechaDesde.Text = "";
            this.dtpFechaHasta.Text = "";
            this.txtMotivo.Text = "";
            this.txtDocumentoID.Text = "";
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

            ad_autorizaciondocumento ad = null;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (this.FormEditStatus == INSERT)
                        {
                            List<int> listaDocumentoIDs = this.GetDocumentoIDs(this.txtDocumentoID.Text);
                            foreach (int documentoid in listaDocumentoIDs)
                            {
                                ad = this.guardarAutorizacion(documentoid, context);
                            }
                        }
                        else if (this.FormEditStatus == EDIT)
                        {
                            ad = this.guardarAutorizacion(Convert.ToInt32(txtDocumentoID.Text), context);
                        }
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
                if (this.FormEditStatus != BROWSE)
                    this.FilterEntity(this.WhereString, this.FilterParam);

                this.FormEditStatus = BROWSE;
                MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region Métodos de Edición de Datos
        private ad_autorizaciondocumento guardarAutorizacion( int documentoid, BerkeDBEntities context = null)
        {
            ad_autorizaciondocumento ad = new ad_autorizaciondocumento();
            if (this.FormEditStatus == EDIT)
            {
                int autorizacionID = Convert.ToInt32(this.txtAutorizacionID.Text);

                ad = context.ad_autorizaciondocumento.First(a => a.ad_autorizacioncabid == autorizacionID);

                if (this.tSBDocumento.KeyMember != "")
                    ad.ad_tipodocumentoautid = Convert.ToInt32(this.tSBDocumento.KeyMember);

                if (this.txtUsuarioAutorizadorID.Text != "")
                    ad.ad_usuarioautorizador = Convert.ToInt32(this.txtUsuarioAutorizadorID.Text);

                if (this.tSBUsuarioAutorizado.KeyMember != "")
                    ad.ad_usuarioautorizado = Convert.ToInt32(this.tSBUsuarioAutorizado.KeyMember);

                ad.ad_fechadesde = Convert.ToDateTime(this.txtFechaDesde.Text);

                if (this.dtpFechaHasta.Text != "")
                    ad.ad_fechahasta = this.dtpFechaHasta.Value;

                ad.ad_motivo = this.txtMotivo.Text;

                ad.ad_documentoid = documentoid;

            }
            else if (this.FormEditStatus == INSERT)
            {
                if (this.tSBDocumento.KeyMember != "")
                    ad.ad_tipodocumentoautid = Convert.ToInt32(this.tSBDocumento.KeyMember);

                if (this.txtUsuarioAutorizadorID.Text != "")
                    ad.ad_usuarioautorizador = Convert.ToInt32(this.txtUsuarioAutorizadorID.Text);

                if (this.tSBUsuarioAutorizado.KeyMember != "")
                    ad.ad_usuarioautorizado = Convert.ToInt32(this.tSBUsuarioAutorizado.KeyMember);

                ad.ad_fechadesde = Convert.ToDateTime(this.txtFechaDesde.Text);

                if (this.dtpFechaHasta.Text != "")
                    ad.ad_fechahasta = this.dtpFechaHasta.Value;

                ad.ad_motivo = this.txtMotivo.Text;
                ad.ad_documentoid = documentoid;

                context.ad_autorizaciondocumento.Add(ad);
            }

            return ad;
        }

        private void eliminarAntecedente(BerkeDBEntities context = null)
        {
            int autorizacionID = Convert.ToInt32(this.txtAutorizacionID.Text);
            ad_autorizaciondocumento ad = context.ad_autorizaciondocumento.First(a => a.ad_autorizacioncabid == autorizacionID);

            context.ad_autorizaciondocumento.Remove(ad);
        }
        #endregion Métodos de Edición de Datos

        #endregion CRUD

        #region Helpers
        private List<int> GetDocumentoIDs(string texto)
        {
            List<int> listaDocumentoIDs = new List<int>();

            string[] splitText = texto.Split('-');

            if (splitText.Count() == 1)
            {
                splitText = texto.Split(',');
                if (splitText.Count() == 1)
                {
                    listaDocumentoIDs.Add(Convert.ToInt32(texto));
                }
                else if (splitText.Count() > 1)
                {
                    foreach (var val in splitText)
                    {
                        listaDocumentoIDs.Add(Convert.ToInt32(val));
                    }
                }
            }
            else if (splitText.Count() == 2)
            {
                int limInferior = Convert.ToInt32(splitText[0]);
                int limSuperior = Convert.ToInt32(splitText[1]);

                for (int i = limInferior; i <= limSuperior; i++)
                {
                    listaDocumentoIDs.Add(i);
                }
            }

            return listaDocumentoIDs;
        }
        #endregion Helpers

        private void dgvListadoABM_VisibleChanged(object sender, EventArgs e)
        {
            if (this.tabListaABM.SelectedIndex == 0)
                this.FormatearGrilla();
        }

        
    }
}