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
    public partial class ucPartePresupuesto : ucBaseForm
    {
        #region Variables Globales
        frmPickBase fPickTramite;
        #endregion Variables Globales

        #region Constantes
        private const string CAMPO_PARTEPRESUPUESTOID = "PartePresupuestoID";
        private const string CAMPO_TRAMITEID = "TramiteID";
        private const string CAMPO_TRAMITEDESCRIP = "TramiteDescrip";
        private const string CAMPO_DESCRIPSERVESP = "DescripServEsp";
        private const string CAMPO_DESCRIPSERVING = "DescripServIng";
        private const string CAMPO_DESCRIPGASTESP = "DescripGastEsp";
        private const string CAMPO_DESCRIPGASTING = "DescripGastIng";

        private const int IDIOMA_ESPANOL = 2;
        private const int IDIOMA_INGLES = 1;
        #endregion Constantes

        #region Métodos de Inicio
        public ucPartePresupuesto()
        {
            InitializeComponent();
        }

        public ucPartePresupuesto(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();
            this.DBContext = dbContext;
            this.Titulo = Titulo;

            var partePresup = (from pp in this.DBContext.pp_partepresupuesto
                               join tram in this.DBContext.Tramite
                                   on pp.pp_tramiteid equals tram.ID
                               select new PartePresupuestoType
                               {
                                   PartePresupuestoID = pp.pp_partepresupuestoid,
                                   TramiteID = pp.pp_tramiteid,
                                   TramiteDescrip = tram.Descrip,
                                   DescripServEsp = pp.pp_descripcionserviciosesp,
                                   DescripServIng = pp.pp_descripcionserviciosing,
                                   DescripGastEsp = pp.pp_descripciongastosesp,
                                   DescripGastIng = pp.pp_descripciongastosing
                               })
                               .Take(50)
                               .OrderByDescending(a => a.PartePresupuestoID);

            this.BindingSourceBase = partePresup.ToList();

            #region Especificar campos para filtro
            this.SetFilter("PartePresupuestoID", "ID Modelo", false);
            this.SetFilter("TramiteID", "Trámite ID", false);
            this.SetFilter("TramiteDescrip", "Descrip. Trámite");
            this.SetFilter("DescripServEsp", "Descrip. Serv. Esp.");
            this.SetFilter("DescripServIng", "Descrip. Serv. Ing.");
            this.SetFilter("DescripGastEsp", "Descrip. Gastos Esp.");
            this.SetFilter("DescripGastIng", "Descrip. Gastos Ing.");
            this.TituloBuscador = "Buscar Partes de Modelos de Prespuesto";
            #endregion Especificar campos para filtro

            #region Inicializar TextSearchBoxes
            this.tSBTramite.KeyMemberWidth = 35;
            this.tSBTramite.ToolTip = "Elegir Trámite";
            this.tSBTramite.AceptarClick += tSBTramite_AceptarClick;
            #endregion Inicializar TextSearchBoxes
        }
        #endregion Métodos de Inicio

        #region Picks
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

                var query = (from pp in this.DBContext.pp_partepresupuesto
                             join tram in this.DBContext.Tramite
                                 on pp.pp_tramiteid equals tram.ID
                             select new PartePresupuestoType
                             {
                                 PartePresupuestoID = pp.pp_partepresupuestoid,
                                 TramiteID = pp.pp_tramiteid,
                                 TramiteDescrip = tram.Descrip,
                                 DescripServEsp = pp.pp_descripcionserviciosesp,
                                 DescripServIng = pp.pp_descripcionserviciosing,
                                 DescripGastEsp = pp.pp_descripciongastosesp,
                                 DescripGastIng = pp.pp_descripciongastosing
                             });

                if (where != "")
                {
                    this.BindingSourceBase = query.Where(where, filterParams).OrderByDescending(a => a.PartePresupuestoID).ToList();
                }
                else
                {
                    this.BindingSourceBase = query.Take(50).OrderByDescending(a => a.PartePresupuestoID).ToList();
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
            this.dgvListadoABM.Columns[CAMPO_PARTEPRESUPUESTOID].HeaderText = "Parte ID";
            this.dgvListadoABM.Columns[CAMPO_PARTEPRESUPUESTOID].Width = 60;
            this.dgvListadoABM.Columns[CAMPO_PARTEPRESUPUESTOID].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_PARTEPRESUPUESTOID].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_TRAMITEDESCRIP].HeaderText = "Descripción Trámite";
            this.dgvListadoABM.Columns[CAMPO_TRAMITEDESCRIP].Width = 100;
            this.dgvListadoABM.Columns[CAMPO_TRAMITEDESCRIP].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_TRAMITEDESCRIP].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_DESCRIPSERVESP].HeaderText = "Descrip. Servicios Español";
            this.dgvListadoABM.Columns[CAMPO_DESCRIPSERVESP].Width = 200;
            this.dgvListadoABM.Columns[CAMPO_DESCRIPSERVESP].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_DESCRIPSERVESP].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_DESCRIPSERVING].HeaderText = "Descrip. Servicios Inglés";
            this.dgvListadoABM.Columns[CAMPO_DESCRIPSERVING].Width = 200;
            this.dgvListadoABM.Columns[CAMPO_DESCRIPSERVING].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_DESCRIPSERVING].Visible = true;
            displayIndex++;
        }

        protected override void tbbNuevo_Click(object sender, EventArgs e)
        {
            base.tbbNuevo_Click(sender, e);
            this.limpiarDatos();
            this.tSBTramite.SetFocus();
        }

        protected override void tbbEditar_Click(object sender, EventArgs e)
        {
            base.tbbEditar_Click(sender, e);
            this.tSBTramite.SetFocus();
        }
        #endregion Método Extendidos del ParentControl

        #region Controles Locales
        private void dgvListadoABM_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.txtIDPartePresupuesto.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_PARTEPRESUPUESTOID].Value.ToString();

            if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TRAMITEID].Value != null)
            {
                this.tSBTramite.KeyMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TRAMITEID].Value.ToString();
                this.tSBTramite.DisplayMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TRAMITEDESCRIP].Value.ToString();
            }

            if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_DESCRIPSERVESP].Value != null)
            {
                this.txtDescripServEsp.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_DESCRIPSERVESP].Value.ToString();
            }

            if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_DESCRIPSERVING].Value != null)
            {
                this.txtDescripServIng.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_DESCRIPSERVING].Value.ToString();
            }

            if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_DESCRIPGASTESP].Value != null)
            {
                this.txtDescripGastEsp.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_DESCRIPGASTESP].Value.ToString();
            }

            if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_DESCRIPGASTING].Value != null)
            {
                this.txtDescripGastIng.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_DESCRIPGASTING].Value.ToString();
            }
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
            this.tSBTramite.Editable = !editar;
            this.txtDescripServEsp.ReadOnly = editar;
            this.txtDescripServIng.ReadOnly = editar;
            this.txtDescripGastEsp.ReadOnly = editar;
            this.txtDescripGastIng.ReadOnly = editar;
        }
        #endregion ReadOnly condicional

        #region Limpiar Datos
        private void limpiarDatos()
        {
            this.txtIDPartePresupuesto.Text = "";
            this.tSBTramite.Clear();
            this.txtDescripServEsp.Text = "";
            this.txtDescripServIng.Text = "";
            this.txtDescripGastEsp.Text = "";
            this.txtDescripGastIng.Text = "";
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
                        this.eliminarPartePresupuesto(context);
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

            pp_partepresupuesto pp = null;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        pp = this.guardarPartePresupuesto(context);
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
        private pp_partepresupuesto guardarPartePresupuesto(BerkeDBEntities context = null)
        {
            pp_partepresupuesto pp = new pp_partepresupuesto();
            if (this.FormEditStatus == EDIT)
            {
                int ppID = Convert.ToInt32(this.txtIDPartePresupuesto.Text);

                pp = context.pp_partepresupuesto.First(a => a.pp_partepresupuestoid == ppID);

                if (this.tSBTramite.KeyMember != "")
                    pp.pp_tramiteid = Convert.ToInt32(this.tSBTramite.KeyMember);

                pp.pp_descripcionserviciosesp = this.txtDescripServEsp.Text;
                pp.pp_descripcionserviciosing = this.txtDescripServIng.Text;
                pp.pp_descripciongastosesp = this.txtDescripGastEsp.Text;
                pp.pp_descripciongastosing = this.txtDescripGastIng.Text;
            }
            else if (this.FormEditStatus == INSERT)
            {
                if (this.tSBTramite.KeyMember != "")
                    pp.pp_tramiteid = Convert.ToInt32(this.tSBTramite.KeyMember);

                pp.pp_descripcionserviciosesp = this.txtDescripServEsp.Text;
                pp.pp_descripcionserviciosing = this.txtDescripServIng.Text;
                pp.pp_descripciongastosesp = this.txtDescripGastEsp.Text;
                pp.pp_descripciongastosing = this.txtDescripGastIng.Text;

                context.pp_partepresupuesto.Add(pp);
            }

            return pp;
        }

        private void eliminarPartePresupuesto(BerkeDBEntities context = null)
        {
            int ppID = Convert.ToInt32(this.txtIDPartePresupuesto.Text);
            pp_partepresupuesto pp = context.pp_partepresupuesto.First(a => a.pp_partepresupuestoid == ppID);

            context.pp_partepresupuesto.Remove(pp);
        }
        #endregion Métodos de Edición de Datos
        #endregion CRUD
    }
}