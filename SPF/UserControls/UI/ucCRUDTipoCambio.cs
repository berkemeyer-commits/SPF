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
using SPF.Forms.UI;
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

using SPF.Classes;
using Microsoft.Reporting.WebForms;

#endregion

namespace SPF.UserControls.UI
{
    public partial class ucCRUDTipoCambio : ucBaseForm2015
    {
        #region Constantes
        private const string CAMPO_TIPOCAMBIOID = "TipoCambioID";
        private const string CAMPO_FECHACOTIZACION = "FechaCotizacion";
        private const string CAMPO_MONEDAID = "MonedaID";
        private const string CAMPO_MONEDADESCRIP = "MonedaDescrip";
        private const string CAMPO_ABREVMONEDA = "AbrevMoneda";
        private const string CAMPO_VALOR = "Valor";

        private const string FORMATO_MONEDA_OTROS = "{0:N2}";
        private const string FORMATO_MONEDA_OTROS_GRILLA = "N2";

        private const string CAMPO_USUARIOID = "UsuarioID";
        private const string CAMPO_USUARIONOMBRE = "UsuarioNombre";
        #endregion Constantes

        #region Variables
        private BindingSource bS;
        private frmPickBase fPickMoneda;
        #endregion Variables

        #region Métodos de Inicio
        public ucCRUDTipoCambio()
        {
            InitializeComponent();
        }

        public ucCRUDTipoCambio(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();
            this.DBContext = dbContext;
            this.Titulo = Titulo;

            var tiposCambio = (from tcd in this.DBContext.tcd_tipocambiode
                               join m in this.DBContext.Moneda
                                on tcd.tcd_monedaid equals m.ID
                             select new
                             {
                                 TipoCambioID = tcd.tcd_tipocambiodeid,
                                 FechaCotizacion = tcd.tcd_fecha,
                                 MonedaID = tcd.tcd_monedaid,
                                 MonedaDescrip = m.Descripcion,
                                 AbrevMoneda = m.AbrevMoneda,
                                 Valor = tcd.tcd_valor
                             })
                             .OrderByDescending(a => a.FechaCotizacion)
                             .ThenBy(b => b.MonedaID)
                             .Take(50);

            this.BindingSourceBase = tiposCambio.ToList();

            #region Especificar campos para filtro
            this.SetFilter(CAMPO_TIPOCAMBIOID, "Tipo Cambio", false);
            this.SetFilter(CAMPO_FECHACOTIZACION, "Fecha Cotizacion", false);
            this.SetFilter(CAMPO_MONEDAID, "ID Moneda");
            this.SetFilter(CAMPO_MONEDADESCRIP, "Descrip. Moneda", false);
            this.SetFilter(CAMPO_VALOR, "Valor TC");
            this.TituloBuscador = "Buscar Tipos de Cambio";
            #endregion Especificar campos para filtro

            this.bS = new BindingSource();

            #region Asignación Eventos Deletados
            //Asignar Evento de Validación de carga de campos
            this.ValidarCamposEvent += ucCRUDTimbrados_ValidarCamposEvent;
            //Asignar Evento para Guardar Registro
            this.CRUDEvent += ucCRUDTimbrados_CRUDEvent;
            #endregion Asignación Eventos Deletados

            this.tSBMoneda.KeyMemberWidth = 50;
            this.tSBMoneda.ToolTip = "Elegir Moneda";
            this.tSBMoneda.SoloLectura = false;
            this.tSBMoneda.AceptarClick += tSBMoneda_AceptarClick;
        }
        #endregion Métodos de Inicio

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
        #endregion Picks

        #region Método Extendidos del ParentControl
        protected override void FilterEntity(string where = "", object[] filterParams = null)
        {
            try
            {
                this.limpiarDatos();

                var query = (from tcd in this.DBContext.tcd_tipocambiode
                             join m in this.DBContext.Moneda
                              on tcd.tcd_monedaid equals m.ID
                             select new
                             {
                                 TipoCambioID = tcd.tcd_tipocambiodeid,
                                 FechaCotizacion = tcd.tcd_fecha,
                                 MonedaID = tcd.tcd_monedaid,
                                 MonedaDescrip = m.Descripcion,
                                 AbrevMoneda = m.AbrevMoneda,
                                 Valor = tcd.tcd_valor
                             });

                if (where != "")
                {
                    this.BindingSourceBase = query.Where(where, filterParams).OrderByDescending(a => a.FechaCotizacion).ThenBy(b => b.MonedaID).ToList();
                }
                else
                {
                    this.BindingSourceBase = query.OrderByDescending(a => a.FechaCotizacion).Take(50).ToList();
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

            this.dgvListadoABM.Columns[CAMPO_TIPOCAMBIOID].HeaderText = "ID";
            this.dgvListadoABM.Columns[CAMPO_TIPOCAMBIOID].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvListadoABM.Columns[CAMPO_TIPOCAMBIOID].Width = 70;
            this.dgvListadoABM.Columns[CAMPO_TIPOCAMBIOID].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_TIPOCAMBIOID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_TIPOCAMBIOID].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_FECHACOTIZACION].HeaderText = "Fecha";
            this.dgvListadoABM.Columns[CAMPO_FECHACOTIZACION].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvListadoABM.Columns[CAMPO_FECHACOTIZACION].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_FECHACOTIZACION].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_FECHACOTIZACION].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvListadoABM.Columns[CAMPO_FECHACOTIZACION].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_ABREVMONEDA].HeaderText = "Moneda";
            this.dgvListadoABM.Columns[CAMPO_ABREVMONEDA].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvListadoABM.Columns[CAMPO_ABREVMONEDA].Width = 90;
            this.dgvListadoABM.Columns[CAMPO_ABREVMONEDA].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_ABREVMONEDA].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvListadoABM.Columns[CAMPO_ABREVMONEDA].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_VALOR].HeaderText = "Valor T.C.";
            this.dgvListadoABM.Columns[CAMPO_VALOR].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvListadoABM.Columns[CAMPO_VALOR].Width = 90;
            this.dgvListadoABM.Columns[CAMPO_VALOR].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_VALOR].DefaultCellStyle.Format = FORMATO_MONEDA_OTROS_GRILLA;
            this.dgvListadoABM.Columns[CAMPO_VALOR].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_VALOR].Visible = true;
            displayIndex++;
        }

        protected override void tbbNuevo_Click(object sender, EventArgs e)
        {
            base.tbbNuevo_Click(sender, e);
            this.limpiarDatos();
            this.dtpFecha.Value = System.DateTime.Now.AddDays(-1); ;
            this.dtpFecha.Focus();
        }

        protected override void tbbEditar_Click(object sender, EventArgs e)
        {
            //base.tbbEditar_Click(sender, e);
            this.FormEditStatus = EDIT;

            if (this.txtValor.Text != String.Empty)
                this.txtValor.Text = this.txtValor.Text.Replace(".", "");
        }

        protected override void tbbCancelar_Click(object sender, EventArgs e)
        {
            base.tbbCancelar_Click(sender, e);

            if (this.LastDGVIndex > -1)
            {
                this.CargarTipoCambio(this.dgvListadoABM.Rows[this.LastDGVIndex]);
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
            this.txtTipoCambioD.Text = String.Empty;
            this.tSBMoneda.Clear();
            this.dtpFecha.Text = String.Empty;
            this.txtValor.Text = String.Empty;
        }
        #endregion Limpiar Datos

        #region ReadOnly condicional
        protected override void Editable(bool editar)
        {
            this.tSBMoneda.Editable = !editar;
            this.dtpFecha.Enabled = !editar;
            this.txtValor.ReadOnly = editar;
        }
        #endregion ReadOnly condicional

        #region Métodos de Apoyo
        private void CargarTipoCambio(DataGridViewRow row)
        {
            this.limpiarDatos();

            this.txtTipoCambioD.Text = row.Cells[CAMPO_TIPOCAMBIOID].Value.ToString();
            this.tSBMoneda.KeyMember = row.Cells[CAMPO_MONEDAID].Value.ToString();
            this.tSBMoneda.DisplayMember = row.Cells[CAMPO_MONEDADESCRIP].Value.ToString();
            this.dtpFecha.Value = Convert.ToDateTime(row.Cells[CAMPO_FECHACOTIZACION].Value);
            this.txtValor.Text = Convert.ToDecimal(row.Cells[CAMPO_VALOR].Value).ToString(FORMATO_MONEDA_OTROS_GRILLA);
        }
        #endregion Métodos de Apoyo

        #region Métodos locales sobre controles
        
        private void ucCRUDMovimientoCuenta_VisibleChanged(object sender, EventArgs e)
        {
            if (this.tabListaABM.SelectedIndex == 0)
                this.FormatearGrilla();
        }

        protected override void tabListaABM_SelectedIndexChanging(object sender, TabControlCancelEventArgs e)
        {
            //if (this.FormEditStatus == EDIT)
            //{
            //    e.Cancel = e.TabPage.TabIndex == 0;
            //}
            //else if (this.FormEditStatus == INSERT)
            //{
            //    e.Cancel = e.TabPage.TabIndex != 1;
            //}
            //else e.Cancel = false;
        }

        protected override void dgvListadoABM_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            base.dgvListadoABM_RowEnter(sender, e);

            if ((this.LastDGVIndex > -1) && (!this.IsClosing))
                this.CargarTipoCambio(this.dgvListadoABM.Rows[this.LastDGVIndex]);
        }

        #endregion Métodos locales sobre controles

        #region CRUD
        private void ucCRUDTimbrados_CRUDEvent(object sender, EventArgs e)
        {
            tcd_tipocambiode tcd = new tcd_tipocambiode();

            tcd.tcd_tipocambiodeid = this.FormEditStatus != INSERT ? Convert.ToInt32(this.txtTipoCambioD.Text) : 0;
            tcd.tcd_fecha = this.dtpFecha.Value;
            tcd.tcd_monedaid = Convert.ToInt32(this.tSBMoneda.KeyMember);
            tcd.tcd_valor = Convert.ToDecimal(this.txtValor.Text);

            bool exito = false;

            if (this.FormEditStatus != BROWSE)
            {
                tcd = this.GuardarRegistro<tcd_tipocambiode>(tcd);
            }
            else
            {
                exito = this.EliminarRegistro<tcd_tipocambiode>(tcd);
                tcd = exito ? tcd : null;
            }

            if ((tcd != null) || (exito))
            {
                int index = 0;
                if (this.FormEditStatus == INSERT)
                {
                    this.FilterEntity("", null);
                    this.CargarTipoCambio(this.dgvListadoABM.Rows[0]);
                }
                else if ((this.FormEditStatus == EDIT) || (this.FormEditStatus == BROWSE))
                {
                    this.FilterEntity(this.WhereString, this.FilterParam);
                    this.CargarTipoCambio(this.dgvListadoABM.Rows[this.LastDGVIndex]);
                    index = this.LastDGVIndex;
                }

                this.FormEditStatus = BROWSE;
                this.dgvListadoABM.CurrentCell = this.dgvListadoABM.Rows[index].Cells[0];
                this.dgvListadoABM.CurrentCell.Selected = true;


                MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void ucCRUDTimbrados_ValidarCamposEvent(object sender, EventArgs e)
        {
            if (this.dtpFecha.Text == String.Empty)
            {
                MessageBox.Show("Debe ingresar la fecha de la cotización.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (this.tSBMoneda.KeyMember == String.Empty)
            {
                MessageBox.Show("Debe definir alguna moneda.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            decimal valor;
            if (!decimal.TryParse(this.txtValor.Text, out valor))
            {
                MessageBox.Show("Debe ingresar un valor válido para el campo T.C.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }this.ValidOK = true;
        }

        #region Métodos de Edición de Datos
        #endregion Métodos de Edición de Datos

        private void cbAsociarCobranzas_CheckedChanged(object sender, EventArgs e)
        {
            //if (!this.cbAsociarCobranzas.Checked)
            //{
            //    this.tpCobAsoc.Hide();

            //    if ((this.FormEditStatus != BROWSE) 
            //        && (this.dgvListadoABM.CurrentRow != null) 
            //        && (this.dgvListadoABM.CurrentRow.Cells[CAMPO_ASOCIADOACOBRANZA].Value != null)
            //        && ((bool)this.dgvListadoABM.CurrentRow.Cells[CAMPO_ASOCIADOACOBRANZA].Value))
            //    {
            //        foreach (DataGridViewRow row in this.dgvDetCobranzas.Rows)
            //        {
            //            if (row.Cells[CAMPO_COBROXMOVID].Value != null)
            //                this.cobrosElim.Add((SeleccionarCobrosType)row.DataBoundItem);
            //        }
            //        this.dgvDetCobranzas.DataSource = null;
            //    }
            //}
            //else
            //    this.tpCobAsoc.Show();
        }
        #endregion CRUD

        

    }
}