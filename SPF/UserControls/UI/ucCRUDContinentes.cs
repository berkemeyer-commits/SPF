#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using ModelEF6;
using SPF.Types;
using SPF.Forms.UI;
using SPF.Forms.Base;
using SPF.UserControls.Base;
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
using System.Data.Objects.DataClasses;


using SPF.Classes;
using Microsoft.Reporting.WebForms;
using SPF.Forms.UI;

#endregion

namespace SPF.UserControls.UI
{
    public partial class ucCRUDContinentes : ucBaseForm2015
    {
        #region Propiedades
        #endregion Propiedades

        #region Variables
        private BindingSource bS;
        #endregion Variables

        #region Constantes
        private const string CAMPO_CONTINENTEID = "ContinenteID";
        private const string CAMPO_CONTINENTENOMBRE = "ContinenteNombre";
        private const string CAMPO_BANCOID = "BancoID";
        
        private const string TIPORELACIONCONTINENTE = "N";
        private const string CONTINENTE = "Continente";

        private const string CAMPO_CUENTADESCRIPCION = "CuentaDescripcion";
        private const string CAMPO_CUENTANUMERO = "CuentaNumero";
        private const string CAMPO_MONEDAABREV = "MonedaAbrev";
        private const string CAMPO_CCCMID = "CCCMID";               

        #endregion Constantes

        #region Constructores
        public ucCRUDContinentes()
        {
            InitializeComponent();
        }

        public ucCRUDContinentes(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();

            this.DBContext = dbContext;
            this.Titulo = Titulo;

            var continente = (from co in this.DBContext.co_continente
                              select new
                              {
                                  ContinenteID = co.co_continenteid,
                                  ContinenteNombre = co.co_descripcion
                              })
                              .OrderByDescending(a => a.ContinenteID)
                              .Take(50);

            this.BindingSourceBase = continente.ToList();

            #region Especificar campos para filtro
            this.SetFilter(CAMPO_CONTINENTEID, "Continente ID", false);
            this.SetFilter(CAMPO_CONTINENTENOMBRE, "Continente Nombre");
            this.TituloBuscador = "Buscar Continentes";
            #endregion Especificar campos para filtro

            this.bS = new BindingSource();

            #region Asignación Eventos Deletados
            //Asignar Evento de Validación de carga de campos
            this.ValidarCamposEvent += ucCRUDContinentes_ValidarCamposEvent;
            //Asignar Evento para Guardar Registro
            this.CRUDEvent += ucCRUDContinentes_CRUDEvent;
            #endregion Asignación Eventos Deletados
        }        
        #endregion Constructores              

        #region Método Extendidos del ParentControl
        protected override void FilterEntity(string where = "", object[] filterParams = null)
        {
            try
            {
                this.limpiarDatos();

                var query = (from co in this.DBContext.co_continente
                             join ba in this.DBContext.ba_banco
                               on co.co_bancoid equals ba.ba_bancoid into co_ba
                             from ba in co_ba.DefaultIfEmpty()
                             select new
                             {
                                 ContinenteID = co.co_continenteid,
                                 ContinenteNombre = co.co_descripcion,
                                 BancoID = co.co_bancoid,
                                 BancoNombre = ba.ba_descripcion
                             });

                if (where != "")
                {
                    this.BindingSourceBase = query.Where(where, filterParams).OrderByDescending(a => a.ContinenteID).ToList();
                }
                else
                {
                    this.BindingSourceBase = query.OrderByDescending(a => a.ContinenteID).Take(50).ToList();
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

            this.dgvListadoABM.Columns[CAMPO_CONTINENTEID].HeaderText = "ID";
            this.dgvListadoABM.Columns[CAMPO_CONTINENTEID].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvListadoABM.Columns[CAMPO_CONTINENTEID].Width = 70;
            this.dgvListadoABM.Columns[CAMPO_CONTINENTEID].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_CONTINENTEID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_CONTINENTEID].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_CONTINENTENOMBRE].HeaderText = "Descripción";
            this.dgvListadoABM.Columns[CAMPO_CONTINENTENOMBRE].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvListadoABM.Columns[CAMPO_CONTINENTENOMBRE].Width = 150;
            this.dgvListadoABM.Columns[CAMPO_CONTINENTENOMBRE].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_CONTINENTENOMBRE].Visible = true;
            displayIndex++;            
        }

        protected override void tbbNuevo_Click(object sender, EventArgs e)
        {
            this.limpiarDatos();
            base.tbbNuevo_Click(sender, e);            
            this.txtNombreContinente.Focus();
        }

        protected override void tbbEditar_Click(object sender, EventArgs e)
        {
            this.FormEditStatus = EDIT;

            if (this.tabListaABM.SelectedIndex != 2)
            {
                this.tabListaABM.SelectedIndex = 1;
                this.txtNombreContinente.Focus();
            }   
        }

        protected override void tbbCancelar_Click(object sender, EventArgs e)
        {
            base.tbbCancelar_Click(sender, e);

            if (this.LastDGVIndex > -1)
            {
                this.CargarContinentes(this.dgvListadoABM.Rows[this.LastDGVIndex]);
            }
            else
            {
                this.limpiarDatos();
            }
        }

        protected override void tabListaABM_SelectedIndexChanging(object sender, TabControlCancelEventArgs e)
        {
            if (this.FormEditStatus == EDIT)
            {
                e.Cancel = e.TabPage.TabIndex == 0;
            }
            else if (this.FormEditStatus == INSERT)
            {
                e.Cancel = e.TabPage.TabIndex != 1;
            }
            else e.Cancel = false;
        }

        #endregion Método Extendidos del ParentControl

        #region Limpiar Datos
        private void limpiarDatos()
        {
            this.txtContinenteID.Text = string.Empty;
            this.txtNombreContinente.Text = string.Empty;
        }
        #endregion Limpiar Datos

        #region ReadOnly condicional
        protected override void Editable(bool editar)
        {
            this.txtContinenteID.ReadOnly = editar;
            this.txtNombreContinente.ReadOnly = editar;
            this.btnAgregarCuenta.Enabled = !editar;
            this.btnEliminarCuenta.Enabled = !editar;
        }
        #endregion ReadOnly condicional

        #region Métodos de Apoyo
        private void CargarContinentes(DataGridViewRow row)
        {
            this.limpiarDatos();
            this.txtContinenteID.Text = row.Cells[CAMPO_CONTINENTEID].Value.ToString();
            this.txtNombreContinente.Text = row.Cells[CAMPO_CONTINENTENOMBRE].Value.ToString();

            //Cargar Cuentas
            this.CargarCuentas(Convert.ToInt32(this.txtContinenteID.Text));
        }

        private void CargarCuentas(int continenteID)
        {
            var query = (from ccm in this.DBContext.ccm_conclictamoneda
                         join mon in this.DBContext.Moneda
                            on ccm.ccm_monedaid equals mon.ID
                         join cb in this.DBContext.cb_cuentabanco
                            on ccm.ccm_cuentabancoid equals cb.cb_cuentabancoid
                         join ba in this.DBContext.ba_banco
                            on cb.cb_bancoid equals ba.ba_bancoid                         
                         join co in this.DBContext.co_continente
                            on ccm.ccm_concliid equals co.co_continenteid
                         select new ClienteContinenteCuentaMoneda
                         {
                             CCCMID = ccm.ccm_conclictamonedaid,
                             ConCliID = ccm.ccm_concliid,
                             ConCliDescripcion = co.co_descripcion,
                             TipoRelacion = ccm.ccm_tiporelacion,
                             CuentaID = ccm.ccm_cuentabancoid,
                             CuentaDescripcion = cb.cb_descripcion,
                             CuentaNumero = cb.cb_nrocuenta,
                             BancoID = cb.cb_bancoid,
                             BancoDescripcion = ba.ba_descripcion,
                             MonedaID = mon.ID,
                             MonedaDescripcion = mon.Descripcion,
                             MonedaAbrev = mon.AbrevMoneda
                         })
                        .Where(a => a.ConCliID == continenteID && a.TipoRelacion == TIPORELACIONCONTINENTE)
                        .ToList();

            if (query.Count > 0)
            {
                this.bS.DataSource = query;
                this.dgvDetCuentas.DataSource = this.bS;
                this.FormatearGrillaCuentas();
            }
            else
                this.dgvDetCuentas.DataSource = null;
        }

        private void DialogHandler(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    if (this.FormEditStatus != BROWSE)
                        this.EliminarCuenta();

                }
            }
        }

        private void EliminarCuenta()
        {
            int cccmID = Convert.ToInt32(this.dgvDetCuentas.CurrentRow.Cells[0].Value);

            ccm_conclictamoneda ccm = this.DBContext.ccm_conclictamoneda.First(a => a.ccm_conclictamonedaid == cccmID);
            this.DBContext.ccm_conclictamoneda.Remove(ccm);
            this.DBContext.SaveChanges();
            this.CargarCuentas(Convert.ToInt32(this.txtContinenteID.Text));

            if (this.dgvDetCuentas.RowCount > 0)
            {
                this.dgvDetCuentas.CurrentCell = this.dgvDetCuentas.Rows[0].Cells[5];
                this.dgvDetCuentas.CurrentCell.Selected = true;
                this.dgvDetCuentas.Focus();
            }
            else
            {
                this.btnEliminarCuenta.Enabled = false;
                this.btnAgregarCuenta.Focus();
            }
        }

        private void FormatearGrillaCuentas()
        {
            foreach (DataGridViewColumn col in this.dgvDetCuentas.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            this.dgvDetCuentas.ReadOnly = true;
            this.dgvDetCuentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetCuentas.ItemsPerPage = 10;
            this.dgvDetCuentas.ShowCellToolTips = true;
            this.dgvDetCuentas.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvDetCuentas.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvDetCuentas.DefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvDetCuentas.DefaultCellStyle.BackColor = Color.Transparent;
            this.dgvDetCuentas.MultiSelect = false;

            this.dgvDetCuentas.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;

            int displayIndex = 0;

            //this.dgvDetCuentas.Columns[CAMPO_CCCMID].HeaderText = "ID";
            //this.dgvDetCuentas.Columns[CAMPO_CCCMID].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.dgvDetCuentas.Columns[CAMPO_CCCMID].Width = 80;
            //this.dgvDetCuentas.Columns[CAMPO_CCCMID].DisplayIndex = displayIndex;
            //this.dgvDetCuentas.Columns[CAMPO_CCCMID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //this.dgvDetCuentas.Columns[CAMPO_CCCMID].Visible = true;
            //displayIndex++;

            this.dgvDetCuentas.Columns[CAMPO_MONEDAABREV].HeaderText = "Moneda";
            this.dgvDetCuentas.Columns[CAMPO_MONEDAABREV].Width = 80;
            this.dgvDetCuentas.Columns[CAMPO_MONEDAABREV].DisplayIndex = displayIndex;
            this.dgvDetCuentas.Columns[CAMPO_MONEDAABREV].Visible = true;
            displayIndex++;

            this.dgvDetCuentas.Columns[CAMPO_CUENTADESCRIPCION].HeaderText = "Descripción Cuenta";
            this.dgvDetCuentas.Columns[CAMPO_CUENTADESCRIPCION].Width = 200;
            this.dgvDetCuentas.Columns[CAMPO_CUENTADESCRIPCION].DisplayIndex = displayIndex;
            this.dgvDetCuentas.Columns[CAMPO_CUENTADESCRIPCION].Visible = true;
            displayIndex++;

            this.dgvDetCuentas.Columns[CAMPO_CUENTANUMERO].HeaderText = "N° Cuenta";
            this.dgvDetCuentas.Columns[CAMPO_CUENTANUMERO].Width = 200;
            this.dgvDetCuentas.Columns[CAMPO_CUENTANUMERO].DisplayIndex = displayIndex;
            this.dgvDetCuentas.Columns[CAMPO_CUENTANUMERO].Visible = true;
            displayIndex++;
        }

        private void ManejarBotones()
        {
            if (this.dgvDetCuentas.RowCount > 0)
            {
                this.dgvDetCuentas.CurrentCell = this.dgvDetCuentas.Rows[0].Cells[5];
                this.dgvDetCuentas.CurrentCell.Selected = true;
                this.dgvDetCuentas.Focus();

                if (this.FormEditStatus != BROWSE)
                {
                    this.btnEliminarCuenta.Enabled = true;
                    this.btnAgregarCuenta.Enabled = true;
                }
                else
                {
                    this.btnEliminarCuenta.Enabled = false;
                    this.btnAgregarCuenta.Enabled = false;
                }
            }
            else
            {
                if (this.FormEditStatus != BROWSE)
                {
                    this.btnEliminarCuenta.Enabled = false;
                    this.btnAgregarCuenta.Enabled = true;
                    this.btnAgregarCuenta.Focus();
                }
                else
                {
                    this.btnAgregarCuenta.Enabled = false;
                    this.btnEliminarCuenta.Enabled = false;
                }
            }
        }
        #endregion Métodos de Apoyo

        #region Métodos locales sobre controles
        protected override void dgvListadoABM_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            base.dgvListadoABM_RowEnter(sender, e);

            if ((this.LastDGVIndex > -1) && (!this.IsClosing))
                this.CargarContinentes(this.dgvListadoABM.Rows[this.LastDGVIndex]);
        }

        private void dgvDetCuenta_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.btnEliminarCuenta.Enabled = this.dgvDetCuentas.CurrentRow != null && this.FormEditStatus != BROWSE;
        }

        private void ucCRUDContinentes_VisibleChanged(object sender, EventArgs e)
        {
            if (this.tabListaABM.SelectedIndex == 0)
                this.FormatearGrilla();
        }

        private void btnAgregarCuenta_Click(object sender, EventArgs e)
        {
            FCuentaPorClienteContinente f = new Forms.UI.FCuentaPorClienteContinente(this.DBContext,
                                                                                     CONTINENTE,
                                                                                     this.txtContinenteID.Text,
                                                                                     this.txtNombreContinente.Text,
                                                                                     this.FormEditStatus);
            f.FormClosed += delegate
            {
                f = null;
                this.CargarCuentas(Convert.ToInt32(this.txtContinenteID.Text));

                if (this.dgvDetCuentas.RowCount > 0)
                {
                    this.dgvDetCuentas.CurrentCell = this.dgvDetCuentas.Rows[0].Cells[5];
                    this.dgvDetCuentas.CurrentCell.Selected = true;
                    this.dgvDetCuentas.Focus();
                }
            };
            f.ShowDialog();
        }

        private void btnEliminarCuenta_Click(object sender, EventArgs e)
        {
            string message = "";
            string caption = "";
            if (this.FormEditStatus == EDIT)
            {
                caption = "Eliminación de registro";
                message = "Se eliminará el presente registro ¿Desea continuar?";
            }
            else if (this.FormEditStatus == INSERT)
            {
                caption = "Eliminación de registro";
                message = "Se eliminará el registro seleccionado ¿Desea continuar?";
            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(DialogHandler));
        }

        private void tabListaABM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabListaABM.SelectedIndex == 2)
            {
                this.ManejarBotones();
            }
        }
        #endregion Métodos locales sobre controles

        #region CRUD
        private void ucCRUDContinentes_ValidarCamposEvent(object sender, EventArgs e)
        {
            this.ValidOK = true;
        }

        private void ucCRUDContinentes_CRUDEvent(object sender, EventArgs e)
        {
            co_continente co = new co_continente();

            co.co_continenteid = this.FormEditStatus != INSERT ? Convert.ToInt32(this.txtContinenteID.Text) : 0;
            co.co_descripcion = this.txtNombreContinente.Text != String.Empty ? this.txtNombreContinente.Text : null;
            bool exito = false;

            if (this.FormEditStatus != BROWSE)
            {
                co = this.GuardarRegistro<co_continente>(co);
            }
            else
            {
                exito = this.EliminarRegistro<co_continente>(co);
                co = exito ? co : null;
            }

            if ((co != null) || (exito))
            {
                int index = 0;
                if (this.FormEditStatus == INSERT)
                {
                    this.FilterEntity("", null);
                    this.CargarContinentes(this.dgvListadoABM.Rows[0]);
                }
                else if ((this.FormEditStatus == EDIT) || (this.FormEditStatus == BROWSE))
                {
                    this.FilterEntity(this.WhereString, this.FilterParam);
                    this.CargarContinentes(this.dgvListadoABM.Rows[this.LastDGVIndex]);
                    index = this.LastDGVIndex;
                }

                this.FormEditStatus = BROWSE;
                this.dgvListadoABM.CurrentCell = this.dgvListadoABM.Rows[index].Cells[0];
                this.dgvListadoABM.CurrentCell.Selected = true;


                MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion CRUD

        private void dgvDetCuentas_DoubleClick(object sender, EventArgs e)
        {
            if (this.dgvDetCuentas.RowCount > 0)
            {
                int ix = this.dgvDetCuentas.CurrentRow != null ? this.dgvDetCuentas.CurrentRow.Index : 0;
                FCuentaPorClienteContinente f = new Forms.UI.FCuentaPorClienteContinente(this.DBContext,
                                                                                         CONTINENTE,
                                                                                         this.txtContinenteID.Text,
                                                                                         this.txtNombreContinente.Text,
                                                                                         this.FormEditStatus,
                                                                                         (ClienteContinenteCuentaMoneda)this.dgvDetCuentas.Rows[ix].DataBoundItem);
                f.FormClosed += delegate
                {
                    f = null;
                    if (this.FormEditStatus != BROWSE)
                        this.CargarCuentas(Convert.ToInt32(this.txtContinenteID.Text));

                    if (this.dgvDetCuentas.RowCount > 0)
                    {
                        this.dgvDetCuentas.CurrentCell = this.dgvDetCuentas.Rows[0].Cells[5];
                        this.dgvDetCuentas.CurrentCell.Selected = true;
                        this.dgvDetCuentas.Focus();
                    }
                };
                f.ShowDialog();
            }
        }

        

        

        

                
    }
}