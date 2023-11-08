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
    public partial class ucCRUDBancos : ucBaseForm
    {
        #region Constantes
        private const string CAMPO_BANCOID = "BancoID";
        private const string CAMPO_BANCONOMBRE = "BancoNombre";
        private const string CAMPO_BANCOPAISID = "BancoPaisID";
        private const string CAMPO_BANCOPAIS = "BancoPais";
        private const string CAMPO_BANCOCIUDADID = "BancoCiudadID";
        private const string CAMPO_BANCOCIUDAD = "BancoCiudad";
        #endregion Constantes

        #region Variables
        frmPickBase fPickPais;
        frmPickBase fPickCiudad;
        #endregion Variables

        #region Métodos de Inicio
        public ucCRUDBancos()
        {
            InitializeComponent();
        }

        public ucCRUDBancos(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();
            this.DBContext = dbContext;
            this.Titulo = Titulo;
            //this.UsuarioID = Convert.ToInt32(VWGContext.Current.Session["UsuarioID"].ToString());

            var bancos = (from banc in this.DBContext.ba_banco
                          join pais in this.DBContext.CPais
                            on banc.ba_paisid equals pais.idpais into pais_banc
                            from pais in pais_banc.DefaultIfEmpty()
                          join ciud in this.DBContext.CCiudad
                            on banc.ba_ciudadid equals ciud.idciudad into ciud_banc
                            from ciud in ciud_banc.DefaultIfEmpty()
                          select new
                          {
                                 BancoID = banc.ba_bancoid,
                                 BancoNombre = banc.ba_descripcion,
                                 BancoPaisID = banc.ba_paisid,
                                 BancoPais = pais.descrip,
                                 BancoCiudadID = banc.ba_ciudadid,
                                 BancoCiudad = ciud.nomciudad,
                          })
                          .OrderByDescending(a => a.BancoID)
                          .Take(50);

            this.BindingSourceBase = bancos.ToList();

            #region Especificar campos para filtro
            this.SetFilter(CAMPO_BANCOID, "ID Banco", false);
            this.SetFilter(CAMPO_BANCONOMBRE, "Nombre Banco");
            this.SetFilter(CAMPO_BANCOPAISID, "País ID", false);
            this.SetFilter(CAMPO_BANCOPAIS, "País Banco");
            this.SetFilter(CAMPO_BANCOCIUDADID, "Ciudad ID", false);
            this.SetFilter(CAMPO_BANCOCIUDAD, "Ciudad Banco");
            this.TituloBuscador = "Buscar Bancos";
            #endregion Especificar campos para filtro

            #region Inicializar TextSearchBoxes
            this.tSBPais.KeyMemberWidth = 36;
            this.tSBPais.ToolTip = "Elegir País";
            this.tSBPais.AceptarClick += tSBPais_AceptarClick;

            this.tSBCiudad.KeyMemberWidth = 36;
            this.tSBCiudad.ToolTip = "Elegir País";
            this.tSBCiudad.AceptarClick += tSBCiudad_AceptarClick;
            #endregion Inicializar TextSearchBoxes

        }
        #endregion Métodos de Inicio

        #region Picks
        #region PickCiudad
        private void tSBCiudad_AceptarClick(object sender, EventArgs e)
        {
            if (fPickCiudad == null)
            {
                fPickCiudad = new frmPickBase();
                fPickCiudad.AceptarFiltrarClick += fPickCiudad_AceptarFiltrarClick;
                fPickCiudad.FiltrarClick += fPickCiudad_FiltrarClick;
                fPickCiudad.Titulo = "Elegir Ciudad";
                fPickCiudad.CampoIDNombre = "idciudad";
                fPickCiudad.CampoDescripNombre = "nomciudad";
                fPickCiudad.LabelCampoID = "ID";
                fPickCiudad.LabelCampoDescrip = "Descripción";
                fPickCiudad.NombreCampo = "Ciudad";
                //fPickCiudad.ShowDialog();

            }
            fPickCiudad.MostrarFiltro();
        }

        private void fPickCiudad_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickCiudad != null)
            {
                fPickCiudad.LoadData<CCiudad>(this.DBContext.CCiudad, fPickCiudad.GetWhereString());
            }
        }

        private void fPickCiudad_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBCiudad.DisplayMember = fPickCiudad.ValorDescrip;
            this.tSBCiudad.KeyMember = fPickCiudad.ValorID;

            fPickCiudad.Close();
            fPickCiudad.Dispose();
            //fPickCiudad = null;
        }
        #endregion PickCiudad

        #region PickPais
        private void tSBPais_AceptarClick(object sender, EventArgs e)
        {
            if (fPickPais == null)
            {
                fPickPais = new frmPickBase();
                //fPickPais.init("idpais", "descrip");
                fPickPais.AceptarFiltrarClick += f_AceptarFiltrarClickPais;
                fPickPais.FiltrarClick += fPickPais_FiltrarClick;
                fPickPais.Titulo = "Elegir País";
                fPickPais.CampoIDNombre = "idpais";
                fPickPais.CampoDescripNombre = "descrip";
                fPickPais.LabelCampoID = "ID";
                fPickPais.LabelCampoDescrip = "Descripción";
                fPickPais.NombreCampo = "País";
            }
            fPickPais.MostrarFiltro();


        }

        private void fPickPais_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickPais != null)
            {
                fPickPais.LoadData<CPais>(this.DBContext.CPais, fPickPais.GetWhereString());
            }
        }

        private void f_AceptarFiltrarClickPais(object sender, EventArgs e)
        {
            this.tSBPais.DisplayMember = fPickPais.ValorDescrip;
            this.tSBPais.KeyMember = fPickPais.ValorID;

            fPickPais.Close();
            fPickPais.Dispose();
        }
        #endregion PickPais
        #endregion Picks

        #region Método Extendidos del ParentControl
        protected override void FilterEntity(string where = "", object[] filterParams = null)
        {
            try
            {
                this.limpiarDatos();

                var query = (from banc in this.DBContext.ba_banco
                             join pais in this.DBContext.CPais
                               on banc.ba_paisid equals pais.idpais into pais_banc
                             from pais in pais_banc.DefaultIfEmpty()
                             join ciud in this.DBContext.CCiudad
                               on banc.ba_ciudadid equals ciud.idciudad into ciud_banc
                             from ciud in ciud_banc.DefaultIfEmpty()
                             select new
                             {
                                 BancoID = banc.ba_bancoid,
                                 BancoNombre = banc.ba_descripcion,
                                 BancoPaisID = banc.ba_paisid,
                                 BancoPais = pais.descrip,
                                 BancoCiudadID = banc.ba_ciudadid,
                                 BancoCiudad = ciud.nomciudad,
                             });

                if (where != "")
                {
                    this.BindingSourceBase = query.Where(where, filterParams).OrderByDescending(a => a.BancoID).ToList();
                }
                else
                {
                    this.BindingSourceBase = query.OrderByDescending(a => a.BancoID).Take(50).ToList();
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

            this.dgvListadoABM.Columns[CAMPO_BANCOID].HeaderText = "Banco ID";
            this.dgvListadoABM.Columns[CAMPO_BANCOID].Width = 100;
            this.dgvListadoABM.Columns[CAMPO_BANCOID].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_BANCOID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_BANCOID].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_BANCONOMBRE].HeaderText = "Banco Nombre";
            this.dgvListadoABM.Columns[CAMPO_BANCONOMBRE].Width = 250;
            this.dgvListadoABM.Columns[CAMPO_BANCONOMBRE].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_BANCONOMBRE].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_BANCOPAIS].HeaderText = "País";
            this.dgvListadoABM.Columns[CAMPO_BANCOPAIS].Width = 150;
            this.dgvListadoABM.Columns[CAMPO_BANCOPAIS].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_BANCOPAIS].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_BANCOCIUDAD].HeaderText = "Ciudad";
            this.dgvListadoABM.Columns[CAMPO_BANCOCIUDAD].Width = 150;
            this.dgvListadoABM.Columns[CAMPO_BANCOCIUDAD].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_BANCOCIUDAD].Visible = true;
            displayIndex++;
        }

        protected override void tbbNuevo_Click(object sender, EventArgs e)
        {
            base.tbbNuevo_Click(sender, e);
            this.limpiarDatos();
            this.txtNombreBanco.Focus();
        }

        protected override void tbbEditar_Click(object sender, EventArgs e)
        {
            base.tbbEditar_Click(sender, e);
            this.txtNombreBanco.Focus();
        }

        protected override void tbbCancelar_Click(object sender, EventArgs e)
        {
            base.tbbCancelar_Click(sender, e);

            if (this.LastDGVIndex > -1)
            {
                this.CargarBanco(this.dgvListadoABM.Rows[this.LastDGVIndex]);
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
            this.txtBancoID.Text = "";
            this.txtNombreBanco.Text = "";
            this.tSBPais.Clear();
            this.tSBCiudad.Clear();
        }
        #endregion Limpiar Datos

        #region ReadOnly condicional
        protected override void Editable(bool editar)
        {
            this.txtBancoID.ReadOnly = editar;
            this.txtNombreBanco.ReadOnly = editar;
            this.tSBPais.Editable = !editar;
            this.tSBCiudad.Editable = !editar;
        }
        #endregion ReadOnly condicional

        #region Métodos de Apoyo
        private void CargarBanco(DataGridViewRow row)
        {
            this.limpiarDatos();

            this.txtBancoID.Text = row.Cells[CAMPO_BANCOID].Value.ToString();
            this.txtNombreBanco.Text = row.Cells[CAMPO_BANCONOMBRE].Value.ToString();

            if (row.Cells[CAMPO_BANCOPAISID].Value != null)
            {
                this.tSBPais.KeyMember = row.Cells[CAMPO_BANCOPAISID].Value.ToString();
                this.tSBPais.DisplayMember = row.Cells[CAMPO_BANCOPAIS].Value.ToString();
            }

            if (row.Cells[CAMPO_BANCOCIUDADID].Value != null)
            {
                this.tSBCiudad.KeyMember = row.Cells[CAMPO_BANCOCIUDADID].Value.ToString();
                this.tSBCiudad.DisplayMember = row.Cells[CAMPO_BANCOCIUDAD].Value.ToString();
            }

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
                this.CargarBanco(this.dgvListadoABM.Rows[this.LastDGVIndex]);
        }

        private void tbbGuardar_Click_1(object sender, EventArgs e)
        {
            if (this.txtNombreBanco.Text == "")
            {
                MessageBox.Show("Debe ingresar el nombre del banco.",
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

            ba_banco banco = null;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        banco = this.guardarBanco(context);
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
                    this.FilterEntity(CAMPO_BANCOID + " = " + banco.ba_bancoid.ToString(), null);
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
                        this.eliminarBanco(context);
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
        private ba_banco guardarBanco(BerkeDBEntities context = null)
        {
            ba_banco banco = new ba_banco();
            if (this.FormEditStatus == EDIT)
            {
                int bancoID = Convert.ToInt32(this.txtBancoID.Text);

                banco = context.ba_banco.First(a => a.ba_bancoid == bancoID);

                banco.ba_descripcion = this.txtNombreBanco.Text != "" ? this.txtNombreBanco.Text : "";
                
                #region Datos Pais
                int paisID;
                if (int.TryParse(this.tSBPais.KeyMember, out paisID))
                {
                    banco.ba_paisid = paisID;
                }
                else
                    banco.ba_paisid = null;
                #endregion Datos Pais
                
                #region Datos Ciudad
                int ciudadID;
                if (int.TryParse(this.tSBCiudad.KeyMember, out ciudadID))
                {
                    banco.ba_ciudadid = ciudadID;
                }
                else banco.ba_ciudadid = null;
                #endregion Datos Ciudad
            }
            else if (this.FormEditStatus == INSERT)
            {
                banco.ba_descripcion = this.txtNombreBanco.Text != "" ? this.txtNombreBanco.Text : "";

                #region Datos Pais
                int paisID;
                if (int.TryParse(this.tSBPais.KeyMember, out paisID))
                {
                    banco.ba_paisid = paisID;
                }
                else
                    banco.ba_paisid = null;
                #endregion Datos Pais

                #region Datos Ciudad
                int ciudadID;
                if (int.TryParse(this.tSBCiudad.KeyMember, out ciudadID))
                {
                    banco.ba_ciudadid = ciudadID;
                }
                else banco.ba_ciudadid = null;
                #endregion Datos Ciudad
                
                context.ba_banco.Add(banco);
            }

            return banco;
        }

        private void eliminarBanco(BerkeDBEntities context = null)
        {
            int bancoID = Convert.ToInt32(this.txtBancoID.Text);
            ba_banco banco = context.ba_banco.First(a => a.ba_bancoid == bancoID);

            context.ba_banco.Remove(banco);

        }
        #endregion Métodos de Edición de Datos
        #endregion CRUD
    }
}