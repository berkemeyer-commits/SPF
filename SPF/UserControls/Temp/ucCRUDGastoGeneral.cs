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
    public partial class ucCRUDGastoGeneral : ucBaseForm
    {
        #region Constantes
        private const string CAMPO_GASTOGENERALID = "GastoGeneralID";
        private const string CAMPO_GASTOGENERALDESCRIP = "GastoGeneralDescrip";
        #endregion Constantes

        #region Variables
        frmPickBase fPickPais;
        frmPickBase fPickCiudad;
        #endregion Variables

        #region Métodos de Inicio
        public ucCRUDGastoGeneral()
        {
            InitializeComponent();
        }

        public ucCRUDGastoGeneral(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();
            this.DBContext = dbContext;
            this.Titulo = Titulo;
            //this.UsuarioID = Convert.ToInt32(VWGContext.Current.Session["UsuarioID"].ToString());

            var ggs = (from gg in this.DBContext.gg_gastogeneral
                          select new
                          {
                                 GastoGeneralID = gg.gg_gastogeneralid,
                                 GastoGeneralDescrip = gg.gg_descripcion
                          })
                          .OrderByDescending(a => a.GastoGeneralID)
                          .Take(50);

            this.BindingSourceBase = ggs.ToList();

            #region Especificar campos para filtro
            this.SetFilter(CAMPO_GASTOGENERALID, "Concepto Gasto ID", false);
            this.SetFilter(CAMPO_GASTOGENERALDESCRIP, "Concepto Gasto");
            this.TituloBuscador = "Buscar Conceptos de Gastos";
            #endregion Especificar campos para filtro

        }
        #endregion Métodos de Inicio

        #region Método Extendidos del ParentControl
        protected override void FilterEntity(string where = "", object[] filterParams = null)
        {
            try
            {
                this.limpiarDatos();

                var query (from gg in this.DBContext.gg_gastogeneral
                          select new
                          {
                                 GastoGeneralID = gg.gg_gastogeneralid,
                                 GastoGeneralDescrip = gg.gg_descripcion
                          });
            

                if (where != "")
                {
                    this.BindingSourceBase = query.Where(where, filterParams).OrderByDescending(a => a.GastoGeneralID).ToList();
                }
                else
                {
                    this.BindingSourceBase = query.OrderByDescending(a => a.GastoGeneralID).Take(50).ToList();
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

            this.dgvListadoABM.Columns[CAMPO_GASTOGENERALID].HeaderText = "Concepto Gasto ID";
            this.dgvListadoABM.Columns[CAMPO_GASTOGENERALID].Width = 100;
            this.dgvListadoABM.Columns[CAMPO_GASTOGENERALID].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_GASTOGENERALID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_GASTOGENERALID].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_GASTOGENERALDESCRIP].HeaderText = "Concepto";
            this.dgvListadoABM.Columns[CAMPO_GASTOGENERALDESCRIP].Width = 250;
            this.dgvListadoABM.Columns[CAMPO_GASTOGENERALDESCRIP].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_GASTOGENERALDESCRIP].Visible = true;
            displayIndex++;
        }

        protected override void tbbNuevo_Click(object sender, EventArgs e)
        {
            base.tbbNuevo_Click(sender, e);
            this.limpiarDatos();
            this.txtGastoGeneralDescrip.Focus();
        }

        protected override void tbbEditar_Click(object sender, EventArgs e)
        {
            base.tbbEditar_Click(sender, e);
            this.txtGastoGeneralDescrip.Focus();
        }

        protected override void tbbCancelar_Click(object sender, EventArgs e)
        {
            base.tbbCancelar_Click(sender, e);

            if (this.LastDGVIndex > -1)
            {
                this.CargarGastoGeneral(this.dgvListadoABM.Rows[this.LastDGVIndex]);
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
            this.txtGastoGeneralID.Text = "";
            this.txtGastoGeneralDescrip.Text = "";
        }
        #endregion Limpiar Datos

        #region ReadOnly condicional
        protected override void Editable(bool editar)
        {
            this.txtGastoGeneralID.ReadOnly = editar;
            this.txtGastoGeneralDescrip.ReadOnly = editar;
        }
        #endregion ReadOnly condicional

        #region Métodos de Apoyo
        private void CargarBanco(DataGridViewRow row)
        {
            this.limpiarDatos();

            this.txtGastoGeneralID.Text = row.Cells[CAMPO_GASTOGENERALID].Value.ToString();
            this.txtGastoGeneralDescrip.Text = row.Cells[CAMPO_GASTOGENERALDESCRIP].Value.ToString();
        }
        #endregion Métodos de Apoyo

        #region Métodos locales sobre controles
        private void ucCRUDGastoGeneral_VisibleChanged(object sender, EventArgs e)
        {
            if (this.tabListaABM.SelectedIndex == 0)
                this.FormatearGrilla();
        }

        private void dgvListadoABM_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this.LastDGVIndex > -1)
                this.CargarBanco(this.dgvListadoABM.Rows[this.LastDGVIndex]);
        }

        private void tbbGuardar_Click_1(object sender, EventArgs e)
        {
            if (this.txtGastoGeneralDescrip.Text == "")
            {
                MessageBox.Show("Debe ingresar el concepto del gasto.",
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

        #endregion Métodos locales sobre controles

        #region CRUD
        private void GuardarRegistro()
        {
            bool success = false;

            gg_gastogeneral gg = null;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        gg = this.guardarGG(context);
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
                        MessageBox.Show("Ocurrió un error al procesar el guardado: "
                                        + ex.Message + Environment.NewLine
                                        + ex.InnerException,
                                        "Error al guardar los datos",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Stop);
                    }
                }
            }
            if (success)
            {
                if (this.FormEditStatus == INSERT)
                    this.FilterEntity(CAMPO_GASTOGENERALID + " = " + gg.gg_gastogeneralid.ToString(), null);
                else if (this.FormEditStatus == EDIT)
                    this.FilterEntity(this.WhereString, this.FilterParam);

                this.FormEditStatus = BROWSE;
                this.CargarBanco(this.dgvListadoABM.Rows[this.LastDGVIndex]);

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
                        this.eliminarGG(context);
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
        private gg_gastogeneral guardarGG(BerkeDBEntities context = null)
        {
            gg_gastogeneral gg = new gg_gastogeneral();
            if (this.FormEditStatus == EDIT)
            {
                int ggID = Convert.ToInt32(this.txtGastoGeneralID.Text);

                gg = context.gg_gastogeneral.First(a => a.gg_gastogeneralid == ggID);

                gg.gg_descripcion = this.txtGastoGeneralDescrip.Text != "" ? this.txtGastoGeneralDescrip.Text : "";
                
            }
            else if (this.FormEditStatus == INSERT)
            {
                gg.gg_descripcion = this.txtGastoGeneralDescrip.Text != "" ? this.txtGastoGeneralDescrip.Text : "";
                context.gg_gastogeneral.Add(gg);
            }

            return gg;
        }

        private void eliminarGG(BerkeDBEntities context = null)
        {
            int ggID = Convert.ToInt32(this.txtGastoGeneralID.Text);
            gg_gastogeneral gg = context.gg_gastogeneral.First(a => a.gg_gastogeneralid == ggID);

            context.gg_gastogeneral.Remove(gg);

        }
        #endregion Métodos de Edición de Datos
        #endregion CRUD
    }
}