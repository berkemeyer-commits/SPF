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
    public partial class ucCRUDTramite : ucBaseForm
    {
        #region Variables
        frmPickBase fPickCArea;
        frmPickBase fPickTrabajo;
        frmPickBase fPickProceso;
        #endregion Variables

        #region Constantes
        private const string CAMPO_TRAMITEID            = "TramiteID";
        private const string CAMPO_TRAMITEDESCRIP       = "TramiteDescrip";
        private const string CAMPO_PROCESOID            = "ProcesoID";
        private const string CAMPO_PROCESODESCRIP       = "ProcesoDescrip";
        private const string CAMPO_ABREVTRAMITE         = "AbrevTramite";
        private const string CAMPO_TIPOTRABAJOID        = "TipoTrabajoID";
        private const string CAMPO_TIPOTRABAJODESCRIP   = "TipoTrabajoDescrip";
        private const string CAMPO_BOLABREV             = "BolAbrev";
        private const string CAMPO_AREACONTABID         = "AreaContabID";
        private const string CAMPO_AREACONTABDESCRIP    = "AreaContabDescrip";
        private const string CAMPO_ABREVPARACONTAB      = "AbrevParaContabilidad";
        private const string CAMPO_ETIQUETAESPANOL      = "EtiquetaEspanol";
        private const string CAMPO_ETIQUETAINGLES       = "EtiquetaIngles";
        #endregion Constantes

        #region Métodos de Inicio
        public ucCRUDTramite()
        {
            InitializeComponent();
        }
        
        public ucCRUDTramite(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();
            this.DBContext = dbContext;
            this.Titulo = Titulo;

            var tramite = (from tram in this.DBContext.Tramite
                           join proceso in this.DBContext.Proceso
                            on tram.ProcesoID equals proceso.ID into proceso_tram
                            from proceso in proceso_tram.DefaultIfEmpty()
                           join trabajotipo in this.DBContext.TrabajoTipo
                            on tram.TrabajoTipoID equals trabajotipo.ID into trabajotipo_tram
                            from trabajotipo in trabajotipo_tram.DefaultIfEmpty()
                           join acArea in this.DBContext.ac_areacontabilidad
                            on tram.AreaContabID equals acArea.ac_areacontabilidadid into acArea_Tram
                           from acArea in acArea_Tram.DefaultIfEmpty()
                           select new
                           {
                               TramiteID = tram.ID,
                               ProcesoID = tram.ProcesoID,
                               ProcesoDescrip = proceso.Descrip,
                               TramiteDescrip = tram.Descrip,
                               AbrevTramite = tram.Abrev,
                               TipoTrabajoID = tram.TrabajoTipoID,
                               TipoTrabajoDescrip = trabajotipo.Descrip,
                               BolAbrev = tram.BolAbrev,
                               AreaContabID = tram.AreaContabID,
                               AreaContabDescrip = acArea.ac_descripcionarea,
                               AbrevParaContabilidad = tram.AbrevParaContabilidad,
                               EtiquetaEspanol = tram.EtiquetaEsp,
                               EtiquetaIngles = tram.EtiquetaIng
                           })
                         .OrderByDescending(a => a.TramiteID)
                         .Take(50);

            this.BindingSourceBase = tramite.ToList();

            #region Especificar campos para filtro
            this.SetFilter("TramiteID", "ID Trámite", false);
            this.SetFilter("TramiteDescrip", "Descrip. Trámite");
            this.SetFilter("ProcesoID", "ID Proceso", false);
            this.SetFilter("ProcesoDescrip", "Descrip. Proceso");
            this.SetFilter("AbrevTramite", "Abrev. Proceso");
            this.SetFilter("TipoTrabajoID", "ID Tipo Trab.", false);
            this.SetFilter("TipoTrabajoDescrip", "Descrip. Tipo Trab.");
            this.SetFilter("BolAbrev", "Abrev. Boletín");
            this.SetFilter("AreaContabID", "ID Area", false);
            this.SetFilter("AreaContabDescrip", "Descrip. Area");
            this.SetFilter(CAMPO_ABREVPARACONTAB, "Abrev. Contab.");
            this.SetFilter(CAMPO_ETIQUETAESPANOL, "Etiq. Español");
            this.SetFilter(CAMPO_ETIQUETAINGLES, "Etiq. Inglés");
            this.TituloBuscador = "Buscar Trámites";
            #endregion Especificar campos para filtro

            #region Inicializar TextSearchBoxes
            this.tSBAreaContab.KeyMemberWidth = 70;
            this.tSBAreaContab.ToolTip = "Elegir Trámite";
            this.tSBAreaContab.AceptarClick += tSBAreaContab_AceptarClick;

            this.tSBProceso.KeyMemberWidth = 70;
            this.tSBProceso.ToolTip = "Elegir Trámite";
            this.tSBProceso.AceptarClick += tSBProceso_AceptarClick;

            this.tSBTrabajoTipo.KeyMemberWidth = 70;
            this.tSBTrabajoTipo.ToolTip = "Elegir Trámite";
            this.tSBTrabajoTipo.AceptarClick += tSBTrabajoTipo_AceptarClick;
            #endregion Inicializar TextSearchBoxes
        }
        #endregion Métodos de Inicio

        #region Picks
        private void tSBAreaContab_AceptarClick(object sender, EventArgs e)
        {
            if (fPickCArea == null)
            {
                fPickCArea = new frmPickBase();
                fPickCArea.AceptarFiltrarClick += fPickCArea_AceptarFiltrarClick;
                fPickCArea.FiltrarClick += fPickCArea_FiltrarClick;
                fPickCArea.Titulo = "Elegir Area";
                fPickCArea.CampoIDNombre = "ac_areacontabilidadid";
                fPickCArea.CampoDescripNombre = "ac_descripcionarea";
                fPickCArea.LabelCampoID = "ID";
                fPickCArea.LabelCampoDescrip = "Descripción";
                fPickCArea.NombreCampo = "Area";
                fPickCArea.PermitirFiltroNulo = true;
            }
            fPickCArea.MostrarFiltro();
            fPickCArea_FiltrarClick(sender, e);
        }

        private void fPickCArea_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickCArea != null)
            {
                fPickCArea.LoadData<ac_areacontabilidad>(this.DBContext.ac_areacontabilidad, fPickCArea.GetWhereString());
            }
        }

        private void fPickCArea_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBAreaContab.DisplayMember = fPickCArea.ValorDescrip;
            this.tSBAreaContab.KeyMember = fPickCArea.ValorID;

            fPickCArea.Close();
            fPickCArea.Dispose();
        }

        private void tSBProceso_AceptarClick(object sender, EventArgs e)
        {
            if (fPickProceso == null)
            {
                fPickProceso = new frmPickBase();
                fPickProceso.AceptarFiltrarClick += fPickProceso_AceptarFiltrarClick;
                fPickProceso.FiltrarClick += fPickProceso_FiltrarClick;
                fPickProceso.Titulo = "Elegir Proceso";
                fPickProceso.CampoIDNombre = "ID";
                fPickProceso.CampoDescripNombre = "Descrip";
                fPickProceso.LabelCampoID = "ID";
                fPickProceso.LabelCampoDescrip = "Descripción";
                fPickProceso.NombreCampo = "Proceso";
                fPickProceso.PermitirFiltroNulo = true;
            }
            fPickProceso.MostrarFiltro();
            fPickProceso_FiltrarClick(sender, e);
        }

        private void fPickProceso_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickProceso != null)
            {
                fPickProceso.LoadData<Proceso>(this.DBContext.Proceso, fPickProceso.GetWhereString());
            }
        }

        private void fPickProceso_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBProceso.DisplayMember = fPickProceso.ValorDescrip;
            this.tSBProceso.KeyMember = fPickProceso.ValorID;

            fPickProceso.Close();
            fPickProceso.Dispose();
        }

        private void tSBTrabajoTipo_AceptarClick(object sender, EventArgs e)
        {
            if (fPickTrabajo == null)
            {
                fPickTrabajo = new frmPickBase();
                fPickTrabajo.AceptarFiltrarClick += fPickTrabajo_AceptarFiltrarClick;
                fPickTrabajo.FiltrarClick += fPickTrabajo_FiltrarClick;
                fPickTrabajo.Titulo = "Elegir Tipo Trabajo";
                fPickTrabajo.CampoIDNombre = "ID";
                fPickTrabajo.CampoDescripNombre = "Descrip";
                fPickTrabajo.LabelCampoID = "ID";
                fPickTrabajo.LabelCampoDescrip = "Descripción";
                fPickTrabajo.NombreCampo = "Tipo Trabajo";
                fPickTrabajo.PermitirFiltroNulo = true;
            }
            fPickTrabajo.MostrarFiltro();
            fPickTrabajo_FiltrarClick(sender, e);
        }

        private void fPickTrabajo_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickTrabajo != null)
            {
                fPickTrabajo.LoadData<TrabajoTipo>(this.DBContext.TrabajoTipo, fPickTrabajo.GetWhereString());
            }
        }

        private void fPickTrabajo_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBTrabajoTipo.DisplayMember = fPickTrabajo.ValorDescrip;
            this.tSBTrabajoTipo.KeyMember = fPickTrabajo.ValorID;

            fPickTrabajo.Close();
            fPickTrabajo.Dispose();
        }

        #endregion Picks

        #region Método Extendidos del ParentControl
        protected override void FilterEntity(string where = "", object[] filterParams = null)
        {
            try
            {
                this.limpiarDatos();

                var query = (from tram in this.DBContext.Tramite
                             join proceso in this.DBContext.Proceso
                              on tram.ProcesoID equals proceso.ID into proceso_tram
                              from proceso in proceso_tram.DefaultIfEmpty()
                             join trabajotipo in this.DBContext.TrabajoTipo
                              on tram.TrabajoTipoID equals trabajotipo.ID into trabajotipo_tram
                              from trabajotipo in trabajotipo_tram.DefaultIfEmpty()
                             join acArea in this.DBContext.ac_areacontabilidad
                              on tram.AreaContabID equals acArea.ac_areacontabilidadid into acArea_Tram
                             from acArea in acArea_Tram.DefaultIfEmpty()
                             select new
                             {
                                 TramiteID = tram.ID,
                                 ProcesoID = tram.ProcesoID,
                                 ProcesoDescrip = proceso.Descrip,
                                 TramiteDescrip = tram.Descrip,
                                 AbrevTramite = tram.Abrev,
                                 TipoTrabajoID = tram.TrabajoTipoID,
                                 TipoTrabajoDescrip = trabajotipo.Descrip,
                                 BolAbrev = tram.BolAbrev,
                                 AreaContabID = tram.AreaContabID,
                                 AreaContabDescrip = acArea.ac_descripcionarea,
                                 AbrevParaContabilidad = tram.AbrevParaContabilidad,
                                 EtiquetaEspanol = tram.EtiquetaEsp,
                                 EtiquetaIngles = tram.EtiquetaIng
                             });

                if (where != "")
                {
                    this.BindingSourceBase = query.Where(where, filterParams).OrderByDescending(a => a.TramiteID).ToList();
                }
                else
                {
                    this.BindingSourceBase = query.OrderByDescending(a => a.TramiteID).Take(50).ToList();
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
            this.dgvListadoABM.Columns[CAMPO_TRAMITEID].HeaderText = "Trámite ID";
            this.dgvListadoABM.Columns[CAMPO_TRAMITEID].Width = 60;
            this.dgvListadoABM.Columns[CAMPO_TRAMITEID].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_TRAMITEID].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_TRAMITEDESCRIP].HeaderText = "Descripción Trámite";
            this.dgvListadoABM.Columns[CAMPO_TRAMITEDESCRIP].Width = 150;
            this.dgvListadoABM.Columns[CAMPO_TRAMITEDESCRIP].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_TRAMITEDESCRIP].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_PROCESODESCRIP].HeaderText = "Proceso";
            this.dgvListadoABM.Columns[CAMPO_PROCESODESCRIP].Width = 150;
            this.dgvListadoABM.Columns[CAMPO_PROCESODESCRIP].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_PROCESODESCRIP].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_TIPOTRABAJODESCRIP].HeaderText = "Tipo de Trabajo";
            this.dgvListadoABM.Columns[CAMPO_TIPOTRABAJODESCRIP].Width = 150;
            this.dgvListadoABM.Columns[CAMPO_TIPOTRABAJODESCRIP].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_TIPOTRABAJODESCRIP].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_ABREVPARACONTAB].HeaderText = "Abrev. para Presupuestos";
            this.dgvListadoABM.Columns[CAMPO_ABREVPARACONTAB].Width = 150;
            this.dgvListadoABM.Columns[CAMPO_ABREVPARACONTAB].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_ABREVPARACONTAB].Visible = true;
            displayIndex++;
        }

        protected override void tbbNuevo_Click(object sender, EventArgs e)
        {
            base.tbbNuevo_Click(sender, e);
            this.limpiarDatos();
            this.tSBProceso.SetFocus();
        }

        protected override void tbbEditar_Click(object sender, EventArgs e)
        {
            base.tbbEditar_Click(sender, e);
            this.tSBProceso.SetFocus();
        }

        #endregion Método Extendidos del ParentControl

        #region Controles Locales

        private void ucCRUDTramite_VisibleChanged(object sender, EventArgs e)
        {
            if (this.tabListaABM.SelectedIndex == 0)
                this.FormatearGrilla();
        }

        private void dgvListadoABM_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.limpiarDatos();
            this.txtTramiteID.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TRAMITEID].Value.ToString();
            if ((int)((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_PROCESOID].Value > 0)
            {
                this.tSBProceso.KeyMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_PROCESOID].Value.ToString();
                this.tSBProceso.DisplayMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_PROCESODESCRIP].Value.ToString();
            }
            this.txtDescripTramite.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TRAMITEDESCRIP].Value.ToString();

            if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TIPOTRABAJOID].Value != null)
            {
                this.tSBTrabajoTipo.KeyMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TIPOTRABAJOID].Value.ToString();
                this.tSBTrabajoTipo.DisplayMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TIPOTRABAJODESCRIP].Value.ToString();
            }

            if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_ABREVTRAMITE].Value != null)
            {
                this.txtAbreviatura.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_ABREVTRAMITE].Value.ToString();
            }

            if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_ETIQUETAESPANOL].Value != null)
            {
                this.txtEtiquetaEspanol.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_ETIQUETAESPANOL].Value.ToString();
            }

            if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_ETIQUETAINGLES].Value != null)
            {
                this.txtEtiquetaIngles.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_ETIQUETAINGLES].Value.ToString();
            }

            if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_BOLABREV].Value != null)
            {
                this.txtBolAbrev.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_BOLABREV].Value.ToString();
            }

            if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_AREACONTABID].Value != null)
            {
                this.tSBAreaContab.KeyMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_AREACONTABID].Value.ToString();
                this.tSBAreaContab.DisplayMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_AREACONTABDESCRIP].Value.ToString();

            }

            if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_ABREVPARACONTAB].Value != null)
            {
                this.txtAbrevContab.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_ABREVPARACONTAB].Value.ToString();
            }
            else
                this.txtAbrevContab.Text = "";
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
            this.txtTramiteID.ReadOnly = editar;
            this.tSBProceso.Editable = !editar;
            this.txtDescripTramite.ReadOnly = editar;
            this.txtAbreviatura.ReadOnly = editar;
            this.txtBolAbrev.ReadOnly = editar;
            this.tSBTrabajoTipo.Editable = !editar;
            this.tSBAreaContab.Editable = !editar;
            this.txtAbrevContab.ReadOnly = editar;
            this.txtEtiquetaEspanol.ReadOnly = editar;
            this.txtEtiquetaIngles.ReadOnly = editar;
        }
        #endregion ReadOnly condicional

        #region Limpiar Datos
        private void limpiarDatos()
        {
            this.txtTramiteID.Text = "";
            this.tSBProceso.Clear();
            this.txtDescripTramite.Text = "";
            this.txtAbreviatura.Text = "";
            this.txtEtiquetaEspanol.Text = "";
            this.txtEtiquetaIngles.Text = "";
            this.txtBolAbrev.Text = "";
            this.tSBTrabajoTipo.Clear();
            this.tSBAreaContab.Clear();
            this.txtAbrevContab.Text = "";
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
                        this.eliminaTramite(context);
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

            Tramite tr = null;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        tr = this.guardarTramite(context);
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
                if (this.FormEditStatus == INSERT)
                    this.FilterEntity(CAMPO_TRAMITEID + " = " + tr.ID.ToString(), null);
                else if (this.FormEditStatus != EDIT)
                    this.FilterEntity(this.WhereString, this.FilterParam);

                this.FormEditStatus = BROWSE;
                MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region Métodos de Edición de Datos
        private Tramite guardarTramite(BerkeDBEntities context = null)
        {
            Tramite tr = new Tramite();
            if (this.FormEditStatus == EDIT)
            {
                int tramiteID = Convert.ToInt32(this.txtTramiteID.Text);

                tr = context.Tramite.First(a => a.ID == tramiteID);

                if (this.tSBProceso.KeyMember != "")
                {
                    tr.ProcesoID = Convert.ToInt32(this.tSBProceso.KeyMember);
                }
                
                tr.Descrip = this.txtDescripTramite.Text;
                tr.Abrev = this.txtAbreviatura.Text;
                tr.BolAbrev = this.txtBolAbrev.Text;

                if (this.tSBTrabajoTipo.KeyMember != "")
                {
                    tr.TrabajoTipoID = Convert.ToInt32(this.tSBTrabajoTipo.KeyMember);
                }

                if (this.tSBAreaContab.KeyMember != "")
                {
                    tr.AreaContabID = Convert.ToInt32(this.tSBAreaContab.KeyMember);
                }
                else
                {
                    tr.AreaContabID = null;
                }

                tr.AbrevParaContabilidad = this.txtAbrevContab.Text;
                tr.EtiquetaEsp = this.txtEtiquetaEspanol.Text;
                tr.EtiquetaIng = this.txtEtiquetaIngles.Text;
            }
            else if (this.FormEditStatus == INSERT)
            {
                if (this.tSBProceso.KeyMember != "")
                {
                    tr.ProcesoID = Convert.ToInt32(this.tSBProceso.KeyMember);
                }

                tr.Descrip = this.txtDescripTramite.Text;
                tr.Abrev = this.txtAbreviatura.Text;
                tr.BolAbrev = this.txtBolAbrev.Text;

                if (this.tSBTrabajoTipo.KeyMember != "")
                {
                    tr.TrabajoTipoID = Convert.ToInt32(this.tSBTrabajoTipo.KeyMember);
                }

                if (this.tSBAreaContab.KeyMember != "")
                {
                    tr.AreaContabID = Convert.ToInt32(this.tSBAreaContab.KeyMember);
                }
                else
                {
                    tr.AreaContabID = null;
                }

                tr.AbrevParaContabilidad = this.txtAbrevContab.Text;
                tr.EtiquetaEsp = this.txtEtiquetaEspanol.Text;
                tr.EtiquetaIng = this.txtEtiquetaIngles.Text;

                context.Tramite.Add(tr);
            }

            return tr;
        }

        private void eliminaTramite(BerkeDBEntities context = null)
        {
            int tramiteID = Convert.ToInt32(this.txtTramiteID.Text);
            Tramite tr = context.Tramite.First(a => a.ID == tramiteID);

            context.Tramite.Remove(tr);
        }
        #endregion Métodos de Edición de Datos
        #endregion CRUD
    
    }

}