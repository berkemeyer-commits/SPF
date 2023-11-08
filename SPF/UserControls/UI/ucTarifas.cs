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

using ModelEF6;
using SPF.Types;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.ObjectModel;

using SPF.Forms.Base;

#endregion

namespace SPF.UserControls.UI
{
    public partial class ucTarifas : ucBaseForm
    {
        #region Constantes
        public const string CAMPO_TARIFAID              = "TarifaID";
        public const string CAMPO_TARIFADESCRIP         = "TarifaDescrip";
        public const string CAMPO_TARIFAPRECIOUNITARIO  = "TarifaPrecioUnitario";
        public const string CAMPO_TIPOTARIFAID          = "TipoTarifaID";
        public const string CAMPO_TIPOTARIFADESCRIP     = "TipoTarifaDescrip";
        public const string CAMPO_TARIFAMONEDAID        = "TarifaMonedadID";
        public const string CAMPO_TARIFAMONDADESCRIP    = "TarifaMonedaDescrip";
        public const string CAMPO_TARIFAPRECIOVENTA     = "TarifaPrecioVenta";
        public const string CAMPO_TARIFAGRUPO           = "TarifaGrupo";
        public const string CAMPO_TARIFAOBSERVACION     = "TarifaObservacion";
        private const string CAMPO_DESCRIPCIONFACTURAESPANOL = "DescripcionFactura";
        private const string CAMPO_DESCRIPCIONFACTURAINGLES  = "DescripcionFacturaIngles";
        public const int TIPO_TARIFA_GASTO = 2;
        #endregion Constantes

        #region Variables
        frmPickBase fPickTarifa;
        #endregion Variables

        #region Métodos de Inicialización
        public ucTarifas(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();
            this.Titulo = Titulo;
            this.DBContext = dbContext;
            
            var tar = (from tarifas in this.DBContext.Tarifas
                       join moneda in this.DBContext.Moneda
                         on tarifas.MonedaID equals moneda.ID into tar_mon
                         from moneda in tar_mon.DefaultIfEmpty()
                       join tipotarifa in this.DBContext.tt_tipotarifa
                         on tarifas.TipoTarifaID equals tipotarifa.tt_id into tar_tt
                         from tipotarifa in tar_tt.DefaultIfEmpty()
                       select new
                       {
                           TarifaID = tarifas.ID,
                           TarifaDescrip = tarifas.Descripcion,
                           TarifaPrecioUnitario = tarifas.Monto,
                           TipoTarifaID = tarifas.TipoTarifaID,
                           TipoTarifaDescrip = tipotarifa.tt_descrip,
                           TarifaMonedadID = tarifas.MonedaID,
                           TarifaMonedaDescrip = moneda.Descripcion,
                           TarifaPrecioVenta = tarifas.PrecioVenta,
                           TarifaGrupo = tarifas.Grupo,
                           TarifaObservacion = tarifas.Observacion,
                           DescripcionFactura = tarifas.DescripcionFactura,
                           DescripcionFacturaIngles = tarifas.DescripcionFacturaIngles
                       }).Take(50).OrderByDescending(b => b.TarifaID);

            this.BindingSourceBase = tar.ToList();

            #region Especificar campos para filtro
            this.SetFilter("TarifaID", "ID", false);
            this.SetFilter("TarifaDescrip", "Descripción");
            this.SetFilter("TarifaPrecioUnitario", "Precio Unit.", false);
            this.SetFilter(CAMPO_TARIFAPRECIOVENTA, "P. Unit. Venta", false);
            this.SetFilter("TipoTarifaDescrip", "Tipo Tarifa");
            this.SetFilter("TarifaMonedaDescrip", "Moneda");
            this.SetFilter(CAMPO_TARIFAGRUPO, "Grupo");
            this.SetFilter(CAMPO_TARIFAOBSERVACION, "Observación");
            this.SetFilter(CAMPO_DESCRIPCIONFACTURAESPANOL, "Etiqueta Español");
            this.SetFilter(CAMPO_DESCRIPCIONFACTURAINGLES, "Etiqueta Inglés");
            this.TituloBuscador = "Buscar Tarifas";
            #endregion Especificar campos para filtro

            this.cargarCBMoneda();
            this.cargarCBTipoTarifa();

            #region Inicializar TextSearchBoxes
            this.tSBTarifaExtID.KeyMemberWidth = 36;
            this.tSBTarifaExtID.ToolTip = "Elegir Tarifa Externa";
            this.tSBTarifaExtID.AceptarClick += tSBTarifaExtID_AceptarClick;

            this.tSBProveedor.KeyMemberWidth = 36;
            this.tSBProveedor.ToolTip = "Elegir Proveedor";
            this.tSBProveedor.AceptarClick += tSBProveedor_AceptarClick;

            this.tSBTarifaGastoAsoc.KeyMemberWidth = 36;
            this.tSBTarifaGastoAsoc.ToolTip = "Elegira Tarifa de Gasto Asociada";
            this.tSBTarifaGastoAsoc.AceptarClick += tSBTarifaGastoAsoc_AceptarClick;
            #endregion Inicializar TextSearchBoxes
        }

        #region Cargar Combos
        #region Combo Idioma
        private void cargarCBMoneda()
        {
            //bool existeVacio = true;
            this.DBContext.Moneda.Load();

            //try
            //{
            //    Moneda mone = this.DBContext.Moneda.Local.First(b => b.ID == -1);
            //}
            //catch (InvalidOperationException)
            //{
            //    existeVacio = false;
            //}

            //if (!existeVacio)
                //this.DBContext.Moneda.Local.Add(new Moneda { ID = -1, Descripcion = "" });

            this.cbMoneda.DataSource = this.DBContext.Moneda.Local.OrderBy(b => b.ID).ToList();
            this.cbMoneda.DisplayMember = "Descripcion";
            this.cbMoneda.ValueMember = "ID";
        }
        #endregion Combo Idioma

        #region Combo Tipo Tarifa
        private void cargarCBTipoTarifa()
        {
            //bool existeVacio = true;
            this.DBContext.tt_tipotarifa.Load();

            //try
            //{
            //    tt_tipotarifa tt = this.DBContext.tt_tipotarifa.Local.First(b => b.tt_id == -1);
            //}
            //catch (InvalidOperationException)
            //{
            //    existeVacio = false;
            //}

            //if (!existeVacio)
                //this.DBContext.tt_tipotarifa.Local.Add(new tt_tipotarifa { tt_id = -1, tt_descrip = "" });

            this.cbTipoTarifa.DataSource = this.DBContext.tt_tipotarifa.Local.OrderBy(b => b.tt_id).ToList();
            this.cbTipoTarifa.DisplayMember = "tt_descrip";
            this.cbTipoTarifa.ValueMember = "tt_id";
        }
        #endregion Combo Tipo Tarifa

        #endregion Cargar Combos

        #region Cargar Tarifas
        private void cargarTarifas(int tarifaID)
        {
            Tarifas tarifa = this.DBContext.Tarifas.First(a => a.ID == tarifaID);
            ((IObjectContextAdapter)this.DBContext).ObjectContext.Refresh(System.Data.Entity.Core.Objects.RefreshMode.ClientWins, tarifa);

            this.txtTarifaID.Text = tarifa.ID.ToString();
            this.txtTarifaDescrip.Text = tarifa.Descripcion;
            this.txtDescripFactura.Text = tarifa.DescripcionFactura;
            this.txtDescripFacturaIngles.Text = tarifa.DescripcionFacturaIngles;
            this.cbMoneda.SelectedValue = tarifa.MonedaID;
            this.txtPrecioUnitario.Text = String.Format("{0:0.00}", tarifa.Monto.ToString());
            this.txtPrecioVenta.Text = String.Format("{0:0.00}", tarifa.PrecioVenta.ToString());
            this.cbTipoTarifa.SelectedValue = tarifa.TipoTarifaID;
            #region Tipo Unidad Descuento 
            this.cbTipoUnidadDescuento.SelectedIndex = tarifa.TipoUnidadDesc ? 1 : 0;
            #endregion Tipo Descuento
            this.txtMontoDescuento.Text = String.Format("{0:0.00}", tarifa.DescuentoMonto.ToString());
            this.txtPorcDescuento.Text = String.Format("{0:0.00}", tarifa.DescuentoPorcentaje.ToString());

            #region Tipo Unidad Impuesto
            this.cbTipoUnidadImpuesto.SelectedIndex = tarifa.TipoUnidadImp ? 1 : 0;
            #endregion Tipo Impuesto

            this.txtMontoImp.Text = String.Format("{0:0.00}", tarifa.ImpuestoMonto.ToString());
            this.txtPorcImp.Text = String.Format("{0:0.00}", tarifa.ImpuestoPorcentaje.ToString());
            this.txtGrupo.Text = tarifa.Grupo;

            if (tarifa.TarifaGastoID.HasValue)
            {
                Tarifas tarifaGasto = this.DBContext.Tarifas.First(a => a.ID == tarifa.TarifaGastoID.Value);
                this.tSBTarifaGastoAsoc.KeyMember = tarifa.TarifaGastoID.Value.ToString();
                this.tSBTarifaGastoAsoc.DisplayMember = tarifaGasto.Descripcion;
            }

            this.txtObservaciones.Text = tarifa.Observacion;
        }
        #endregion Cargar Cliente

        #region Limpiar Datos
        private void limpiarDatos()
        {
            this.txtTarifaID.Text = "";
            this.txtTarifaDescrip.Text = "";
            this.txtDescripFactura.Text = "";
            this.txtDescripFacturaIngles.Text = "";
            this.txtPrecioUnitario.Text = "";
            this.txtPrecioVenta.Text = "";
            this.txtMontoDescuento.Text = "";
            this.txtPorcDescuento.Text = "";
            this.txtMontoImp.Text = "";
            this.txtPorcImp.Text = "";
            this.tSBTarifaExtID.Clear();
            this.tSBProveedor.Clear();
            this.txtGrupo.Text = "";
            this.tSBTarifaGastoAsoc.Clear();
            this.txtObservaciones.Text = "";
        }
        #endregion Limpiar Datos

        #endregion Métodos de Inicialización

        #region Métodos Extendidos del ParentControl
        protected override void FilterEntity(string where = "", object[] filterParams = null)
        {
            try
            {
                this.limpiarDatos();

                var query = (from tarifas in this.DBContext.Tarifas
                            join moneda in this.DBContext.Moneda
                              on tarifas.MonedaID equals moneda.ID into tar_mon
                              from moneda in tar_mon.DefaultIfEmpty()
                            join tipotarifa in this.DBContext.tt_tipotarifa
                              on tarifas.TipoTarifaID equals tipotarifa.tt_id into tar_tt
                              from tipotarifa in tar_tt.DefaultIfEmpty()
                            select new
                            {
                                TarifaID = tarifas.ID,
                                TarifaDescrip = tarifas.Descripcion,
                                TarifaPrecioUnitario = tarifas.Monto,
                                TipoTarifaID = tarifas.TipoTarifaID,
                                TipoTarifaDescrip = tipotarifa.tt_descrip,
                                TarifaMonedadID = tarifas.MonedaID,
                                TarifaMonedaDescrip = moneda.Descripcion,
                                TarifaPrecioVenta = tarifas.PrecioVenta,
                                TarifaGrupo = tarifas.Grupo,
                                TarifaObservacion = tarifas.Observacion,
                                DescripcionFactura = tarifas.DescripcionFactura,
                                DescripcionFacturaIngles = tarifas.DescripcionFacturaIngles
                             });
                if (where != "")
                {
                    this.BindingSourceBase = query.Where(where, filterParams).OrderByDescending(b => b.TarifaID).ToList();
                }
                else
                {
                    this.BindingSourceBase = query.Take(50).OrderByDescending(b => b.TarifaID).ToList();
                }


                this.FormatearGrilla();

                if ((this.dgvListadoABM.RowCount > 0) && (this.FormEditStatus == INSERT))
                    this.dgvListadoABM.CurrentCell = this.dgvListadoABM.Rows[0].Cells[0];
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

            this.dgvListadoABM.Columns[CAMPO_TARIFAID].HeaderText = "ID";
            this.dgvListadoABM.Columns[CAMPO_TARIFAID].Width = 40;
            this.dgvListadoABM.Columns[CAMPO_TARIFAID].DisplayIndex = 0;
            this.dgvListadoABM.Columns[CAMPO_TARIFAID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_TARIFAID].Visible = true;

            this.dgvListadoABM.Columns[CAMPO_TARIFADESCRIP].HeaderText = "Descripción";
            this.dgvListadoABM.Columns[CAMPO_TARIFADESCRIP].Width = 300;
            this.dgvListadoABM.Columns[CAMPO_TARIFADESCRIP].DisplayIndex = 1;
            this.dgvListadoABM.Columns[CAMPO_TARIFADESCRIP].Visible = true;

            this.dgvListadoABM.Columns[CAMPO_TARIFAPRECIOUNITARIO].HeaderText = "Precio Unit.";
            this.dgvListadoABM.Columns[CAMPO_TARIFAPRECIOUNITARIO].Width = 100;
            this.dgvListadoABM.Columns[CAMPO_TARIFAPRECIOUNITARIO].DisplayIndex = 2;
            this.dgvListadoABM.Columns[CAMPO_TARIFAPRECIOUNITARIO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_TARIFAPRECIOUNITARIO].Visible = true;

            this.dgvListadoABM.Columns[CAMPO_TARIFAPRECIOVENTA].HeaderText = "P. Unit. Venta";
            this.dgvListadoABM.Columns[CAMPO_TARIFAPRECIOVENTA].Width = 100;
            this.dgvListadoABM.Columns[CAMPO_TARIFAPRECIOVENTA].DisplayIndex = 3;
            this.dgvListadoABM.Columns[CAMPO_TARIFAPRECIOVENTA].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_TARIFAPRECIOVENTA].Visible = true;
            
            this.dgvListadoABM.Columns[CAMPO_TARIFAMONDADESCRIP].HeaderText = "Moneda";
            this.dgvListadoABM.Columns[CAMPO_TARIFAMONDADESCRIP].Width = 100;
            this.dgvListadoABM.Columns[CAMPO_TARIFAMONDADESCRIP].DisplayIndex = 4;
            this.dgvListadoABM.Columns[CAMPO_TARIFAMONDADESCRIP].Visible = true;

            this.dgvListadoABM.Columns[CAMPO_TIPOTARIFADESCRIP].HeaderText = "Tipo Tarifa";
            this.dgvListadoABM.Columns[CAMPO_TIPOTARIFADESCRIP].Width = 100;
            this.dgvListadoABM.Columns[CAMPO_TIPOTARIFADESCRIP].DisplayIndex = 5;
            this.dgvListadoABM.Columns[CAMPO_TIPOTARIFADESCRIP].Visible = true;

            this.dgvListadoABM.Columns[CAMPO_TARIFAGRUPO].HeaderText = "Grupo";
            this.dgvListadoABM.Columns[CAMPO_TARIFAGRUPO].Width = 100;
            this.dgvListadoABM.Columns[CAMPO_TARIFAGRUPO].DisplayIndex = 6;
            this.dgvListadoABM.Columns[CAMPO_TARIFAGRUPO].Visible = true;

        }

        protected override void tbbCancelar_Click(object sender, EventArgs e)
        {
            base.tbbCancelar_Click(sender, e);
            
            if (this.dgvListadoABM.RowCount > 0)
                this.cargarTarifas(Convert.ToInt32(this.dgvListadoABM.Rows[this.dgvListadoABM.CurrentRow.Index].Cells[CAMPO_TARIFAID].Value));
            else
                this.limpiarDatos();
        }

        protected override void tbbNuevo_Click(object sender, EventArgs e)
        {
            base.tbbNuevo_Click(sender, e);
            this.limpiarDatos();
            this.txtTarifaDescrip.Focus();
        }

        protected override void tbbEditar_Click(object sender, EventArgs e)
        {
            base.tbbEditar_Click(sender, e);
            this.verificarTipoDescuento();
            this.verificarTipoImpuesto();
            this.txtTarifaDescrip.Focus();
        }

        #region ReadOnly condicional
        protected override void Editable(bool editar)
        {
            this.txtTarifaDescrip.ReadOnly = editar;
            this.txtDescripFactura.ReadOnly = editar;
            this.txtDescripFacturaIngles.ReadOnly = editar;
            this.cbTipoTarifa.Enabled = !editar;
            this.cbMoneda.Enabled = !editar;
            this.txtPrecioUnitario.ReadOnly = editar;
            this.txtPrecioVenta.ReadOnly = editar;
            this.cbTipoUnidadDescuento.Enabled = !editar;
            this.txtMontoDescuento.ReadOnly = editar;
            this.txtPorcDescuento.ReadOnly = editar;
            this.cbTipoUnidadImpuesto.Enabled = !editar;
            this.txtMontoImp.ReadOnly = editar;
            this.txtPorcImp.ReadOnly = editar;
            this.tSBTarifaExtID.Editable = !editar;
            this.tSBProveedor.Editable = !editar;
            this.txtGrupo.ReadOnly = editar;
            this.tSBTarifaGastoAsoc.Editable = !editar;
            this.txtObservaciones.ReadOnly = editar;
        }
        #endregion ReadOnly condicional
        #endregion Métodos Extendidos del ParentControl

        #region Picks
        private void tSBTarifaExtID_AceptarClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void tSBProveedor_AceptarClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void tSBTarifaGastoAsoc_AceptarClick(object sender, EventArgs e)
        {
            if (fPickTarifa == null)
            {
                fPickTarifa = new frmPickBase();
                fPickTarifa.AceptarFiltrarClick += fPickTarifa_AceptarFiltrarClick;
                fPickTarifa.FiltrarClick += fPickTarifa_FiltrarClick;
                fPickTarifa.Titulo = "Elegir Tarifa";
                fPickTarifa.CampoIDNombre = "TarifaID";
                fPickTarifa.CampoDescripNombre = "DescripcionTarifa";
                fPickTarifa.LabelCampoID = "ID";
                fPickTarifa.LabelCampoDescrip = "Descripción";
                fPickTarifa.NombreCampo = "Tarifa";
                fPickTarifa.PermitirFiltroNulo = true;
            }
            fPickTarifa.MostrarFiltro();
            this.fPickTarifa_FiltrarClick(sender, e);
        }

        private void fPickTarifa_FiltrarClick(object sender, EventArgs e)
        {
            var query = (from tarifas in this.DBContext.Tarifas
                         select new TarifasType
                         {
                             TarifaID = tarifas.ID,
                             DescripcionTarifa = tarifas.Descripcion,
                             TipoTarifaID = tarifas.TipoTarifaID
                         })
                        .Where(a => a.TipoTarifaID == TIPO_TARIFA_GASTO);//monedaid);


            if (fPickTarifa != null)
            {
                fPickTarifa.LoadData<TarifasType>(query.AsQueryable(), fPickTarifa.GetWhereString());
                //fPickTarifa.LoadData<TarifasType>(query, fPickTarifa.GetWhereString());
            }
        }

        private void fPickTarifa_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBTarifaGastoAsoc.DisplayMember = fPickTarifa.ValorDescrip;
            this.tSBTarifaGastoAsoc.KeyMember = fPickTarifa.ValorID;

            fPickTarifa.Close();
            fPickTarifa.Dispose();

        }


        #endregion Picks


        #region Métodos sobre controles locales
        private void cbTipoUnidadImpuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.verificarTipoImpuesto();
        }

        private void verificarTipoImpuesto()
        {
            if (this.FormEditStatus != BROWSE)
            {
                if (this.cbTipoUnidadImpuesto.SelectedIndex == 0)
                {
                    this.txtMontoImp.ReadOnly = false;
                    this.txtMontoImp.BackColor = SystemColors.Window;
                    this.txtPorcImp.ReadOnly = true;
                    this.txtPorcImp.BackColor = SystemColors.Control;
                    this.txtMontoImp.Focus();
                }
                else if (this.cbTipoUnidadImpuesto.SelectedIndex == 1)
                {
                    this.txtMontoImp.ReadOnly = true;
                    this.txtMontoImp.BackColor = SystemColors.Control;
                    this.txtPorcImp.ReadOnly = false;
                    this.txtPorcImp.BackColor = SystemColors.Window;
                    this.txtPorcImp.Focus();
                }
                //else
                //{
                //    this.txtMontoImp.ReadOnly = true;
                //    this.txtMontoImp.BackColor = SystemColors.Control;
                //    this.txtPorcImp.ReadOnly = true;
                //    this.txtPorcImp.BackColor = SystemColors.Control;
                //}
            }
        }

        private void cbTipoUnidadDescuento_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.verificarTipoDescuento();
        }

        private void verificarTipoDescuento()
        {
            if (this.FormEditStatus != BROWSE)
            {
                if (this.cbTipoUnidadDescuento.SelectedIndex == 0)
                {
                    this.txtMontoDescuento.ReadOnly = false;
                    this.txtMontoDescuento.BackColor = SystemColors.Window;
                    this.txtPorcDescuento.ReadOnly = true;
                    this.txtPorcDescuento.BackColor = SystemColors.Control;
                    this.txtMontoDescuento.Focus();
                }
                else if (this.cbTipoUnidadDescuento.SelectedIndex == 1)
                {
                    this.txtMontoDescuento.ReadOnly = true;
                    this.txtMontoDescuento.BackColor = SystemColors.Control;
                    this.txtPorcDescuento.ReadOnly = false;
                    this.txtPorcDescuento.BackColor = SystemColors.Window;
                    this.txtPorcDescuento.Focus();
                }
                //else
                //{
                //    this.txtMontoDescuento.ReadOnly = true;
                //    this.txtMontoDescuento.BackColor = SystemColors.Control;
                //    this.txtPorcDescuento.ReadOnly = true;
                //    this.txtPorcDescuento.BackColor = SystemColors.Control;
                //}
            }
        }

        private void txtPorcDescuento_Leave(object sender, EventArgs e)
        {
            //if ((this.cbTipoUnidadDescuento.SelectedIndex == 1) && (this.txtPorcDescuento.Text != ""))
            //{
            //    decimal monto = Convert.ToDecimal(Convert.ToDecimal(this.txtPrecioUnitario.Text) * Convert.ToDecimal(this.txtPorcDescuento.Text) / 100);
            //    this.txtMontoDescuento.Text = String.Format("{0:0.00}", monto);
            //    this.txtPorcDescuento.Text = String.Format("{0:0.00}", Convert.ToDecimal(this.txtPorcDescuento.Text));
            //}
            if (this.FormEditStatus != BROWSE)
            {
                decimal valor;
                if (!decimal.TryParse(this.txtPorcDescuento.Text, out valor)) this.txtPorcDescuento.Text = "0,00";
                if ((this.cbTipoUnidadDescuento.SelectedIndex == 1) && (this.txtPorcDescuento.Text != ""))
                {
                    this.txtMontoDescuento.Text = "0,00";
                    this.txtPorcDescuento.Text = String.Format("{0:0.00}", Convert.ToDecimal(this.txtPorcDescuento.Text));
                }
            }
        }
        
        private void txtPorcImp_Leave(object sender, EventArgs e)
        {
            //if ((this.cbTipoUnidadImpuesto.SelectedIndex == 1) && (this.txtPorcImp.Text != ""))
            //{
            //    decimal monto = Convert.ToDecimal(Convert.ToDecimal(this.txtPrecioUnitario.Text) * Convert.ToDecimal(this.txtPorcImp.Text) / 100);
            //    this.txtMontoImp.Text = String.Format("{0:0.00}", monto);
            //    this.txtPorcImp.Text = String.Format("{0:0.00}", Convert.ToDecimal(this.txtPorcImp.Text));
            //}
            if (this.FormEditStatus != BROWSE)
            {
                decimal valor;
                if (!decimal.TryParse(this.txtPorcImp.Text, out valor)) this.txtPorcImp.Text = "0,00";
                if ((this.cbTipoUnidadImpuesto.SelectedIndex == 1) && (this.txtPorcImp.Text != ""))
                {
                    this.txtMontoImp.Text = "0,00";
                    this.txtPorcImp.Text = String.Format("{0:0.00}", Convert.ToDecimal(this.txtPorcImp.Text));
                }
            }
        }

        private void txtMontoDescuento_Leave(object sender, EventArgs e)
        {
            //if ((this.cbTipoUnidadDescuento.SelectedIndex == 0) && (this.txtMontoDescuento.Text != ""))
            //{
            //    decimal porc = Convert.ToDecimal(this.txtMontoDescuento.Text) / Convert.ToDecimal(this.txtPrecioUnitario.Text) * 100;
            //    this.txtPorcDescuento.Text = String.Format("{0:0.00}", porc);
            //    this.txtMontoDescuento.Text = String.Format("{0:0.00}", Convert.ToDecimal(this.txtMontoDescuento.Text));
            //}
            if (this.FormEditStatus != BROWSE)
            {
                decimal valor;
                if (!decimal.TryParse(this.txtMontoDescuento.Text, out valor)) this.txtMontoDescuento.Text = "0,00";
                if ((this.cbTipoUnidadDescuento.SelectedIndex == 0) && (this.txtMontoDescuento.Text != ""))
                {
                    this.txtPorcDescuento.Text = "0,00";
                    this.txtMontoDescuento.Text = String.Format("{0:0.00}", Convert.ToDecimal(this.txtMontoDescuento.Text));
                }
            }
        }

        private void txtMontoImp_Leave(object sender, EventArgs e)
        {
            //if ((this.cbTipoUnidadImpuesto.SelectedIndex == 0) && (this.txtMontoImp.Text != ""))
            //{
            //    decimal porc = Convert.ToDecimal(this.txtMontoImp.Text) / Convert.ToDecimal(this.txtPrecioUnitario.Text) * 100;
            //    this.txtPorcImp.Text = String.Format("{0:0.00}", porc);
            //    this.txtMontoImp.Text = String.Format("{0:0.00}", this.txtMontoImp.Text);
            //}
            if (this.FormEditStatus != BROWSE)
            {
                decimal valor;
                if (!decimal.TryParse(this.txtMontoImp.Text, out valor)) this.txtMontoImp.Text = "0,00";
                if ((this.cbTipoUnidadImpuesto.SelectedIndex == 0) && (this.txtMontoImp.Text != ""))
                {
                    this.txtPorcImp.Text = "0,00";
                    this.txtMontoImp.Text = String.Format("{0:0.00}", this.txtMontoImp.Text);
                }
            }
        }

        private void dgvListadoABM_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int tarifaID = (int)((DataGridView)sender).Rows[e.RowIndex].Cells[0].Value;

                if (tarifaID.ToString() == this.txtTarifaID.Text) return;

                this.limpiarDatos();
                this.cargarTarifas(tarifaID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al recuperar los datos: " + Environment.NewLine + ex.Message, "Información de Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void tbbGuardar_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Do you want to continue?", "Confirmation", MessageBoxButtons.YesNo, msgBoxHandler);
            this.txtTarifaDescrip.Focus();
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
        
        #endregion Métodos sobre controles locales

        #region Manipulación de datos

        #region Guardar Registro
        private void GuardarRegistro()
        {
            bool success = false;
            
            Tarifas tarifa = null;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        tarifa = this.guardarTarifas(context);
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
                if (success)
                {
                    
                    if (this.FormEditStatus != BROWSE)
                        this.FilterEntity(this.WhereString, this.FilterParam);

                    this.cargarTarifas(tarifa.ID);

                    this.FormEditStatus = BROWSE;
                    
                    MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private Tarifas guardarTarifas(BerkeDBEntities context = null)
        {
            Tarifas tarifa = new Tarifas();
            if (this.FormEditStatus == EDIT)
            {
                int tarifaID = Convert.ToInt32(this.txtTarifaID.Text);

                tarifa = context.Tarifas.First(a => a.ID == tarifaID);

                tarifa.Descripcion = this.txtTarifaDescrip.Text;
                tarifa.DescripcionFactura = this.txtDescripFactura.Text;
                tarifa.DescripcionFacturaIngles = this.txtDescripFacturaIngles.Text;
                tarifa.Grupo = this.txtGrupo.Text;
                tarifa.Observacion = this.txtObservaciones.Text;

                #region Moneda
                tarifa.MonedaID = Convert.ToInt32(this.cbMoneda.SelectedValue.ToString());
                #endregion Moneda

                #region Precio Unitario Costo
                decimal precUnitCosto;
                if (decimal.TryParse(this.txtPrecioUnitario.Text, out precUnitCosto))
                {
                    tarifa.Monto = precUnitCosto;
                }
                #endregion Precio Unitario Costo

                #region Precio Unitario Venta
                decimal precUnitVenta;
                if (decimal.TryParse(this.txtPrecioVenta.Text, out precUnitVenta))
                {
                    tarifa.PrecioVenta = precUnitVenta;
                }
                #endregion Precio Unitario Venta

                #region Tipo Tarifa
                tarifa.TipoTarifaID = Convert.ToInt32(this.cbTipoTarifa.SelectedValue.ToString());
                #endregion Tipo Tarifa

                #region Tipo Unidad Descuento
                tarifa.TipoUnidadDesc = this.cbTipoUnidadDescuento.SelectedIndex == 0 ? false : true;
                #endregion Tipo Unidad Descuento

                #region Descuento Monto
                decimal descuentoMonto;
                if (decimal.TryParse(this.txtMontoDescuento.Text, out descuentoMonto))
                {
                    tarifa.DescuentoMonto = descuentoMonto;
                }
                #endregion Descuento Monto

                #region Descuento Porcentaje
                decimal descuentoPorcentaje;
                if (decimal.TryParse(this.txtPorcDescuento.Text, out descuentoPorcentaje))
                {
                    tarifa.DescuentoPorcentaje = descuentoPorcentaje;
                }
                #endregion Descuento Porcentaje

                #region Tipo Unidad Impuesto
                tarifa.TipoUnidadImp = this.cbTipoUnidadImpuesto.SelectedIndex == 0 ? false : true;
                #endregion Tipo Unidad Impuesto

                #region Impuesto Monto
                decimal impuestoMonto;
                if (decimal.TryParse(this.txtMontoImp.Text, out impuestoMonto))
                {
                    tarifa.ImpuestoMonto = impuestoMonto;
                }
                #endregion Impuesto Monto

                #region Impuesto Porcentaje
                decimal impuestoPorcentaje;
                if (decimal.TryParse(this.txtPorcImp.Text, out impuestoPorcentaje))
                {
                    tarifa.ImpuestoPorcentaje = impuestoPorcentaje;
                }
                #endregion Impuesto Porcentaje

                #region Tarifa Gasto
                if (this.tSBTarifaGastoAsoc.KeyMember != "")
                    tarifa.TarifaGastoID = Convert.ToInt32(this.tSBTarifaGastoAsoc.KeyMember);
                else
                    tarifa.TarifaGastoID = null;
                #endregion Tarifa Gasto
            }
            else if (this.FormEditStatus == INSERT)
            {
                tarifa.Descripcion = this.txtTarifaDescrip.Text;
                tarifa.DescripcionFactura = this.txtDescripFactura.Text;
                tarifa.DescripcionFacturaIngles = this.txtDescripFacturaIngles.Text;
                tarifa.Grupo = this.txtGrupo.Text;
                tarifa.Observacion = this.txtObservaciones.Text;

                #region Moneda
                tarifa.MonedaID = Convert.ToInt32(this.cbMoneda.SelectedValue.ToString());
                #endregion Moneda

                #region Precio Unitario Costo
                decimal precUnitCosto;
                if (decimal.TryParse(this.txtPrecioUnitario.Text, out precUnitCosto))
                {
                    tarifa.Monto = precUnitCosto;
                }
                #endregion Precio Unitario Costo

                #region Precio Unitario Venta
                decimal precUnitVenta;
                if (decimal.TryParse(this.txtPrecioVenta.Text, out precUnitVenta))
                {
                    tarifa.PrecioVenta = precUnitVenta;
                }
                #endregion Precio Unitario Venta

                #region Tipo Tarifa
                tarifa.TipoTarifaID = Convert.ToInt32(this.cbTipoTarifa.SelectedValue.ToString());
                #endregion Tipo Tarifa

                #region Tipo Unidad Descuento
                tarifa.TipoUnidadDesc = this.cbTipoUnidadDescuento.SelectedIndex == 0 ? false : true;
                #endregion Tipo Unidad Descuento

                #region Descuento Monto
                decimal descuentoMonto;
                if (decimal.TryParse(this.txtMontoDescuento.Text, out descuentoMonto))
                {
                    tarifa.DescuentoMonto = descuentoMonto;
                }
                #endregion Descuento Monto

                #region Descuento Porcentaje
                decimal descuentoPorcentaje;
                if (decimal.TryParse(this.txtPorcDescuento.Text, out descuentoPorcentaje))
                {
                    tarifa.DescuentoPorcentaje = descuentoPorcentaje;
                }
                #endregion Descuento Porcentaje

                #region Tipo Unidad Impuesto
                tarifa.TipoUnidadImp = this.cbTipoUnidadImpuesto.SelectedIndex == 0 ? false : true;
                #endregion Tipo Unidad Impuesto

                #region Impuesto Monto
                decimal impuestoMonto;
                if (decimal.TryParse(this.txtMontoImp.Text, out impuestoMonto))
                {
                    tarifa.ImpuestoMonto = impuestoMonto;
                }
                #endregion Impuesto Monto

                #region Impuesto Porcentaje
                decimal impuestoPorcentaje;
                if (decimal.TryParse(this.txtPorcImp.Text, out impuestoPorcentaje))
                {
                    tarifa.ImpuestoPorcentaje = impuestoPorcentaje;
                }
                #endregion Impuesto Porcentaje

                #region Tarifa Gasto
                if (this.tSBTarifaGastoAsoc.KeyMember != "")
                    tarifa.TarifaGastoID = Convert.ToInt32(this.tSBTarifaGastoAsoc.KeyMember);
                else
                    tarifa.TarifaGastoID = null;
                #endregion Tarifa Gasto
                
                context.Tarifas.Add(tarifa);
            }

            return tarifa;
        }
        #endregion Guardar Registro

        #region Eliminar Registro
        private void EliminarRegistro()
        {
            bool success = false;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        this.eliminarTarifa(context);
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
                    this.FormEditStatus = BROWSE;
                    this.FilterEntity(this.WhereString, this.FilterParam);
                    MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void eliminarTarifa(BerkeDBEntities context = null)
        {
            int tarifaID = Convert.ToInt32(this.txtTarifaID.Text);
            Tarifas tarifa = context.Tarifas.First(a => a.ID == tarifaID);
            context.Tarifas.Remove(tarifa);
        }
        #endregion Eliminar Registro

        private void btnAsociar_Click(object sender, EventArgs e)
        {
            Forms.UI.FTramiteAsociados f = new Forms.UI.FTramiteAsociados(this.DBContext, this.FormEditStatus, Convert.ToInt32(this.txtTarifaID.Text));
            f.FormClosed += delegate { f = null; };
            f.ShowDialog();
        }

        #endregion Manipulación de datos

        private void txtTarifaID_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text != "")
                this.btnAsociar.Enabled = true;
            else
                this.btnAsociar.Enabled = false;
        }
        




    }
}