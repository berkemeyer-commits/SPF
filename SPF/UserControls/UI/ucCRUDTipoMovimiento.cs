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
    public partial class ucCRUDTipoMovimiento : ucBaseForm
    {
        #region Constantes
        private const string CAMPO_TIPOMOVIMIENTOID = "TipoMovimientoID";
        private const string CAMPO_TIPOMOVIMIENTODESCRIP = "TipoMovimientoDescrip";
        private const string CAMPO_TIPOMOVIMIENTO = "TipoMovimiento";
        private const string CAMPO_TIPOMOVIMIENTOTEXTO = "TipoMovimientoTexto";
        private const string HABER = "H";
        private const string DEBE = "D";
        #endregion Constantes

        #region Métodos de Inicio
        public ucCRUDTipoMovimiento()
        {
            InitializeComponent();
        }

        public ucCRUDTipoMovimiento(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();
            this.DBContext = dbContext;
            this.Titulo = Titulo;
            
            var tms = (from tm in this.DBContext.tm_tipomovimientocuenta
                       select new TipoMovimientoList
                          {
                                 TipoMovimientoID = tm.tm_tipomovimientoid,
                                 TipoMovimientoDescrip = tm.tm_tipomovimientodescrip,
                                 TipoMovimiento = tm.tm_tipo
                          })
                          .OrderByDescending(a => a.TipoMovimientoID)
                          .Take(50);

            this.BindingSourceBase = tms.ToList();

            #region Especificar campos para filtro
            this.SetFilter(CAMPO_TIPOMOVIMIENTOID, "Tipo Mov. ID", false);
            this.SetFilter(CAMPO_TIPOMOVIMIENTODESCRIP, "Tipo Mov. Descrip.");
            this.SetFilter(CAMPO_TIPOMOVIMIENTO, "Tipo (D=Debe; H=Haber");
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

                var query = (from tm in this.DBContext.tm_tipomovimientocuenta
                             select new TipoMovimientoList
                             {
                                 TipoMovimientoID = tm.tm_tipomovimientoid,
                                 TipoMovimientoDescrip = tm.tm_tipomovimientodescrip,
                                 TipoMovimiento = tm.tm_tipo
                             });
            

                if (where != "")
                {
                    this.BindingSourceBase = query.Where(where, filterParams).OrderByDescending(a => a.TipoMovimientoID).ToList();
                }
                else
                {
                    this.BindingSourceBase = query.OrderByDescending(a => a.TipoMovimientoID).Take(50).ToList();
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

            this.dgvListadoABM.Columns[CAMPO_TIPOMOVIMIENTOID].HeaderText = "Tipo Mov. ID";
            this.dgvListadoABM.Columns[CAMPO_TIPOMOVIMIENTOID].Width = 100;
            this.dgvListadoABM.Columns[CAMPO_TIPOMOVIMIENTOID].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_TIPOMOVIMIENTOID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_TIPOMOVIMIENTOID].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_TIPOMOVIMIENTODESCRIP].HeaderText = "Descripción";
            this.dgvListadoABM.Columns[CAMPO_TIPOMOVIMIENTODESCRIP].Width = 250;
            this.dgvListadoABM.Columns[CAMPO_TIPOMOVIMIENTODESCRIP].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_TIPOMOVIMIENTODESCRIP].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_TIPOMOVIMIENTOTEXTO].HeaderText = "Tipo";
            this.dgvListadoABM.Columns[CAMPO_TIPOMOVIMIENTOTEXTO].Width = 70;
            this.dgvListadoABM.Columns[CAMPO_TIPOMOVIMIENTOTEXTO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_TIPOMOVIMIENTOTEXTO].Visible = true;
            displayIndex++;
        }

        protected override void tbbNuevo_Click(object sender, EventArgs e)
        {
            base.tbbNuevo_Click(sender, e);
            this.limpiarDatos();
            this.txtTipoMovimientoDescrip.Focus();
        }

        protected override void tbbEditar_Click(object sender, EventArgs e)
        {
            base.tbbEditar_Click(sender, e);
            this.txtTipoMovimientoDescrip.Focus();
        }

        protected override void tbbCancelar_Click(object sender, EventArgs e)
        {
            base.tbbCancelar_Click(sender, e);

            if (this.LastDGVIndex > -1)
            {
                this.CargarTipoMovimiento(this.dgvListadoABM.Rows[this.LastDGVIndex]);
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
            this.txtTipoMovimientoID.Text = "";
            this.txtTipoMovimientoDescrip.Text = "";
            this.rbDebe.Checked = true;
        }
        #endregion Limpiar Datos

        #region ReadOnly condicional
        protected override void Editable(bool editar)
        {
            this.txtTipoMovimientoID.ReadOnly = editar;
            this.txtTipoMovimientoDescrip.ReadOnly = editar;
            this.grpTipoMovimiento.Enabled = !editar;
        }
        #endregion ReadOnly condicional

        #region Métodos de Apoyo
        private void CargarTipoMovimiento(DataGridViewRow row)
        {
            this.limpiarDatos();

            this.txtTipoMovimientoID.Text = row.Cells[CAMPO_TIPOMOVIMIENTOID].Value.ToString();
            this.txtTipoMovimientoDescrip.Text = row.Cells[CAMPO_TIPOMOVIMIENTODESCRIP].Value.ToString();
            this.rbDebe.Checked = row.Cells[CAMPO_TIPOMOVIMIENTO].Value.ToString() == DEBE;
            this.rbHaber.Checked = row.Cells[CAMPO_TIPOMOVIMIENTO].Value.ToString() == HABER;
        }
        #endregion Métodos de Apoyo

        #region Métodos locales sobre controles
        private void ucCRUDTipoMovimiento_VisibleChanged(object sender, EventArgs e)
        {
            if (this.tabListaABM.SelectedIndex == 0)
                this.FormatearGrilla();
        }

        private void dgvListadoABM_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this.LastDGVIndex > -1)
                this.CargarTipoMovimiento(this.dgvListadoABM.Rows[this.LastDGVIndex]);
        }

        private void tbbGuardar_Click_1(object sender, EventArgs e)
        {
            if (this.txtTipoMovimientoDescrip.Text == "")
            {
                MessageBox.Show("Debe ingresar la descripción del movimiento.",
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

            tm_tipomovimientocuenta tm = null;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        tm = this.guardarTM(context);
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
                    this.FilterEntity(CAMPO_TIPOMOVIMIENTOID + " = " + tm.tm_tipomovimientoid.ToString(), null);
                else if (this.FormEditStatus == EDIT)
                    this.FilterEntity(this.WhereString, this.FilterParam);

                this.FormEditStatus = BROWSE;
                this.CargarTipoMovimiento(this.dgvListadoABM.Rows[this.LastDGVIndex]);

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
                        this.eliminarTM(context);
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
        private tm_tipomovimientocuenta guardarTM(BerkeDBEntities context = null)
        {
            tm_tipomovimientocuenta tm = new tm_tipomovimientocuenta();
            if (this.FormEditStatus == EDIT)
            {
                int tmID = Convert.ToInt32(this.txtTipoMovimientoID.Text);

                tm = context.tm_tipomovimientocuenta.First(a => a.tm_tipomovimientoid == tmID);

                tm.tm_tipomovimientodescrip = this.txtTipoMovimientoDescrip.Text != "" ? this.txtTipoMovimientoDescrip.Text : "";

                if (this.rbDebe.Checked)
                    tm.tm_tipo = DEBE;
                else if (this.rbHaber.Checked)
                    tm.tm_tipo = HABER;
            }
            else if (this.FormEditStatus == INSERT)
            {
                tm.tm_tipomovimientodescrip = this.txtTipoMovimientoDescrip.Text != "" ? this.txtTipoMovimientoDescrip.Text : "";

                if (this.rbDebe.Checked)
                    tm.tm_tipo = DEBE;
                else if (this.rbHaber.Checked)
                    tm.tm_tipo = HABER;

                context.tm_tipomovimientocuenta.Add(tm);
            }

            return tm;
        }

        private void eliminarTM(BerkeDBEntities context = null)
        {
            int tmID = Convert.ToInt32(this.txtTipoMovimientoID.Text);
            tm_tipomovimientocuenta tm = context.tm_tipomovimientocuenta.First(a => a.tm_tipomovimientoid == tmID);

            context.tm_tipomovimientocuenta.Remove(tm);

        }
        #endregion Métodos de Edición de Datos
        #endregion CRUD
    }
}