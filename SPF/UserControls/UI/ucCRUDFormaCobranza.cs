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
    public partial class ucCRUDFormaCobranza : ucBaseForm
    {
        #region Constantes
        private const string CAMPO_FORMACOBRANZAID = "FormaCobranzaID";
        private const string CAMPO_FORMACOBRANZADESCRIPCION = "FormaCobranzaDescripcion";
        #endregion Constantes

        #region Métodos de Inicio
        public ucCRUDFormaCobranza()
        {
            InitializeComponent();
        }

        public ucCRUDFormaCobranza(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();
            this.DBContext = dbContext;
            this.Titulo = Titulo;

            var fCobranza = (from fp in this.DBContext.fp_formadepago
                              select new
                              {
                                     FormaCobranzaID = fp.fp_formadepagoid,
                                     FormaCobranzaDescripcion = fp.fp_descripcion
                              })
                              .OrderByDescending(a => a.FormaCobranzaID)
                              .Take(50);

            this.BindingSourceBase = fCobranza.ToList();

            #region Especificar campos para filtro
            this.SetFilter(CAMPO_FORMACOBRANZAID, "Forma Cob. ID", false);
            this.SetFilter(CAMPO_FORMACOBRANZADESCRIPCION, "Forma Cob. Desc.");
            this.TituloBuscador = "Buscar Formas de Cobranza";
            #endregion Especificar campos para filtro
        }
        #endregion Métodos de Inicio

        #region Método Extendidos del ParentControl
        protected override void FilterEntity(string where = "", object[] filterParams = null)
        {
            try
            {
                this.limpiarDatos();

                var query = (from fp in this.DBContext.fp_formadepago
                             select new
                             {
                                 FormaCobranzaID = fp.fp_formadepagoid,
                                 FormaCobranzaDescripcion = fp.fp_descripcion
                             });

                if (where != "")
                {
                    this.BindingSourceBase = query.Where(where, filterParams).OrderByDescending(a => a.FormaCobranzaID).ToList();
                }
                else
                {
                    this.BindingSourceBase = query.OrderByDescending(a => a.FormaCobranzaID).Take(50).ToList();
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

            this.dgvListadoABM.Columns[CAMPO_FORMACOBRANZAID].HeaderText = "ID";
            this.dgvListadoABM.Columns[CAMPO_FORMACOBRANZAID].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvListadoABM.Columns[CAMPO_FORMACOBRANZAID].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_FORMACOBRANZAID].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_FORMACOBRANZAID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_FORMACOBRANZAID].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_FORMACOBRANZADESCRIPCION].HeaderText = "Descripción";
            this.dgvListadoABM.Columns[CAMPO_FORMACOBRANZADESCRIPCION].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvListadoABM.Columns[CAMPO_FORMACOBRANZADESCRIPCION].Width = 400;
            this.dgvListadoABM.Columns[CAMPO_FORMACOBRANZADESCRIPCION].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_FORMACOBRANZADESCRIPCION].Visible = true;
            displayIndex++;
        }

        protected override void tbbNuevo_Click(object sender, EventArgs e)
        {
            this.limpiarDatos();
            base.tbbNuevo_Click(sender, e);
            this.txtDescripcionFormaCobranza.Focus();
        }

        protected override void tbbEditar_Click(object sender, EventArgs e)
        {
            base.tbbEditar_Click(sender, e);
            this.txtDescripcionFormaCobranza.Focus();
        }

        protected override void tbbCancelar_Click(object sender, EventArgs e)
        {
            base.tbbCancelar_Click(sender, e);

            if (this.LastDGVIndex > -1)
            {
                this.CargarFormasCobranza(this.dgvListadoABM.Rows[this.LastDGVIndex]);
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
            this.txtFormaCobranzaID.Text = String.Empty;
            this.txtDescripcionFormaCobranza.Text = String.Empty;
        }
        #endregion Limpiar Datos

        #region ReadOnly condicional
        protected override void Editable(bool editar)
        {
            this.txtFormaCobranzaID.ReadOnly = editar;
            this.txtDescripcionFormaCobranza.ReadOnly = editar;
        }
        #endregion ReadOnly condicional

        #region Métodos de Apoyo
        private void CargarFormasCobranza(DataGridViewRow row)
        {
            this.limpiarDatos();

            this.txtFormaCobranzaID.Text = row.Cells[CAMPO_FORMACOBRANZAID].Value.ToString();
            this.txtDescripcionFormaCobranza.Text = row.Cells[CAMPO_FORMACOBRANZADESCRIPCION].Value.ToString();
        }
        #endregion Métodos de Apoyo

        #region Métodos locales sobre controles
        private void ucCRUDBancos_VisibleChanged(object sender, EventArgs e)
        {
            if (this.tabListaABM.SelectedIndex == 0)
                this.FormatearGrilla();
        }

        private void dgvListadoABM_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this.LastDGVIndex > -1)
                this.CargarFormasCobranza(this.dgvListadoABM.Rows[this.LastDGVIndex]);
        }

        private void tbbGuardar_Click_1(object sender, EventArgs e)
        {
            if (this.txtDescripcionFormaCobranza.Text == "")
            {
                MessageBox.Show("Debe ingresar la descripción de la forma de cobranza.",
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

            fp_formadepago fp = null;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        fp = this.guardarFormasCobranza(context);
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
                {
                    this.FilterEntity(String.Empty, null);
                    //this.FilterEntity(CAMPO_FORMACOBRANZAID + " = " + fp.fp_formadepagoid.ToString(), null);

                    if (this.dgvListadoABM.Rows.Count > 0)
                    {
                        this.dgvListadoABM.CurrentCell = this.dgvListadoABM.Rows[0].Cells[CAMPO_FORMACOBRANZAID];
                        this.dgvListadoABM.Focus();
                    }
                }
                else if (this.FormEditStatus == EDIT)
                    this.FilterEntity(this.WhereString, this.FilterParam);

                this.FormEditStatus = BROWSE;
                this.CargarFormasCobranza(this.dgvListadoABM.Rows[this.LastDGVIndex]);

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
                        this.eliminarFormasCobranza(context);
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
        private fp_formadepago guardarFormasCobranza(BerkeDBEntities context = null)
        {
            fp_formadepago fp = new fp_formadepago();
            if (this.FormEditStatus == EDIT)
            {
                int formaPagoID = Convert.ToInt32(this.txtFormaCobranzaID.Text);

                fp = context.fp_formadepago.First(a => a.fp_formadepagoid == formaPagoID);

                fp.fp_descripcion = this.txtDescripcionFormaCobranza.Text != "" ? this.txtDescripcionFormaCobranza.Text : "";
            }
            else if (this.FormEditStatus == INSERT)
            {
                fp.fp_descripcion = this.txtDescripcionFormaCobranza.Text != "" ? this.txtDescripcionFormaCobranza.Text : "";

                context.fp_formadepago.Add(fp);
            }

            return fp;
        }

        private void eliminarFormasCobranza(BerkeDBEntities context = null)
        {
            int formaPagoID = Convert.ToInt32(this.txtFormaCobranzaID.Text);
            fp_formadepago fp = context.fp_formadepago.First(a => a.fp_formadepagoid == formaPagoID);

            context.fp_formadepago.Remove(fp);

        }
        #endregion Métodos de Edición de Datos
        #endregion CRUD
    }
}