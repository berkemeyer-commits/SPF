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
using SPF.Forms;
using SPF.Types;
using System.Data.Entity;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Dynamic;

using System.Data.SqlClient;
using System.Collections;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text.RegularExpressions;

using SPF.Forms.Base;
using SPF.Base;
using Microsoft.Reporting.WebForms;

#endregion

namespace SPF.Forms.UI
{
    public partial class FSeleccionarFacturaRecibos : Form
    {
        #region Variables
        BerkeDBEntities DBContext;
        frmPickBase fPickCliente;
        FRealizarCobroRecibo fRealizarCobroRecibo;
        private int usuarioID;
        private List<FacturasParaRecibos> ListaSeleccionados;
        CheckBox headerCheckBox;
        #endregion Variables
        
        #region Constantes
        private const string CAMPO_SELECCIONAR = "Seleccionar";
        public const string CAMPO_VERDETALLES = "VerDetalles";

        private const string CAMPO_NRO_FACTURA = "NroFactura";
        private const string CAMPO_FECHA_FACTURA = "FechaFactura";
        private const string CAMPO_FACTURACABID = "FacturaCabId";
        private const string CAMPO_TIMBRADOID = "TimbradoId";
        private const string CAMPO_CLIENTEID = "ClienteId";
        private const string CAMPO_CLIENTENOMBRE = "ClienteNombre";
        private const string CAMPO_TIPOFACTURADESCRIP = "TipoFacturaDescrip";
        private const string CAMPO_RUC = "RUC";
        private const string CAMPO_ESDOCUMENTOELECTRONICO = "EsDocumentoElectronico";
        private const string CAMPO_MONEDAID = "MonedaId";
        private const string CAMPO_MONEDAABREV = "MonedaAbrev";
        private const string CAMPO_TOTALEXENTAS = "TotalExentas";
        private const string CAMPO_TOTALIVA5 = "TotalIVA5";
        private const string CAMPO_TOTALIVA10 = "TotalIVA10";
        private const string CAMPO_LIQIVA5 = "LiqIVA5";
        private const string CAMPO_LIQIVA10 = "LiqIVA10";
        private const string CAMPO_TOTALIVA = "TotalIVA";
        private const string CAMPO_TOTAL = "Total";
        private const string CAMPO_DOCUMENTOSASOCIADOS = "DocumentosAsociados";
        private const string CAMPO_SALDO = "Saldo";
        private const string CAMPO_IMPORTECOBRADO = "ImporteCobrado";
        private const string CAMPO_CDC = "CDC";
        private const string CAMPO_TIPODOCUMENTO = "TipoDocumento";
        private const string CAMPO_FACTURAPRESUPUESTOCABID = "FacturaPresupuestoCabId";
        private const string COL_IMAGEN = "Imagen";
        
        private const string FORMATO_MONEDA_GUARANIES_GRILLA = "N0";
        private const string FORMATO_MONEDA_OTROS_GRILLA = "N2";
        private const string FORMATO_MONEDA_GUARANIES = "{0:N0}";
        private const string FORMATO_MONEDA_OTROS = "{0:N2}";
        private const string NOTA_CREDITO_ELECTRONICA = "Nota Crédito Electrónica";
        private const int GUARANIES_MONEDA_ID = 3;

        private const string FILAS_RECUPERADAS = "{0} comprobantes encontrados.";
        private const string FILAS_SELECCIONADAS = "{0} comprobantes seleccionados.";

        private const int RECIBO_SERIE_3_CLIENTE_LOCAL = 28;
        private const int RECIBO_SERIE_4_CLIENTE_EXTERIOR = 29;
        private const int TIPODOCUMENTO_RECIBO_CLIENTE = 14;
        private const int PARAGUAY_ID = 91;
        private const int LIMITE_FACTURAS_POR_RECIBO = 14;

        private const string ERROR_CADENA_FORMATO = "La cadena de entrada no tiene el formato correcto.";

        #endregion Constantes

        #region Propiedades
        private int UsuarioID
        {
            get { return this.usuarioID; }
            set { this.usuarioID = value; }
        }
        #endregion Propiedades

        public event EventHandler AceptarFiltrarClick;

        #region Métodos de Inicio
        public FSeleccionarFacturaRecibos()
        {
            InitializeComponent();
        }

        public FSeleccionarFacturaRecibos(string titulo, BerkeDBEntities context)
        {
            InitializeComponent();
            this.Text = titulo;
            this.DBContext = context;
            this.UsuarioID = Convert.ToInt32(VWGContext.Current.Session["UsuarioID"].ToString());

            #region TextSearchBoxes
            this.tSBCliente.KeyMemberWidth = 70;
            this.tSBCliente.ToolTip = "Elegir Cliente";
            this.tSBCliente.AceptarClick += tSBCliente_AceptarClick;
            this.tSBCliente.Editable = true;
            this.tSBCliente.ToolTipTSB = "Cliente";
            #endregion TextSearchBoxes

            #region DateTime Pickers
            this.dtpFechaDesde.Format = DateTimePickerFormat.Short;
            this.dtpFechaHasta.Format = DateTimePickerFormat.Short;
            #endregion DateTime Pickers

            this.cargarCBMoneda();
            this.SetFirstAndLastDayofMonth();
            this.chkFiltroFecha.Checked = false;
            this.btnFiltrar.Location = new Point(676, 16);
            this.pnlFiltroFecha.Visible = false;
            this.lblFilasRecuperadas.Text = string.Empty;
            this.lblSeleccionadas.Text = string.Empty;
            this.btnCobrar.Text = "Realizar" + Environment.NewLine + "Cobro";
            this.btnCobrar.Enabled = false;
            //this.lblTotalImpCob.Text = "Total Imp." + Environment.NewLine + "Cobrado";
            //this.lblTotalImpNotaCred.Text = "Total" + Environment.NewLine + "N. Créd.";
            //this.lblTotalRecibo.Text = "Total" + Environment.NewLine + "Recibo";

            this.ListaSeleccionados = new List<FacturasParaRecibos>();
            this.headerCheckBox = new CheckBox();
            this.headerCheckBox.CheckedChanged += headerCheckBox_CheckedChanged;
            this.headerCheckBox.Size = new Size(19, 19);
            this.panel1.Controls.Add(this.headerCheckBox);
            this.headerCheckBox.Location = new Point(this.headerCheckBox.Location.X + 54, this.headerCheckBox.Location.Y);
            this.toolTip1.SetToolTip(this.headerCheckBox, "Marcar o desmarcar todas las facturas");
            this.headerCheckBox.Visible = false;
            this.headerCheckBox.Checked = false;
        }

        #region Configurar fechas iniciales
        private void SetFirstAndLastDayofMonth()
        {
            DateTime hoy = DateTime.Now;

            //Primer día del siguiente mes
            DateTime primerDiaMes = new DateTime(hoy.Year, hoy.Month, 1);
            DateTime ultimoDiaMes = (new DateTime(hoy.Year, hoy.AddMonths(1).Month, 1)).AddDays(-1);

            dtpFechaDesde.Value = primerDiaMes;
            dtpFechaHasta.Value = ultimoDiaMes;
        }
        #endregion Configurar fechas iniciales

        #region Picks

        #region Cargar CBMoneda
        private void cargarCBMoneda()
        {
            List<int> monedaIds = new List<int>() { 2, 3, 5, 176, 17 };
            this.DBContext.Moneda.Where(a => monedaIds.Contains(a.ID)).Load();

            this.cbMoneda.DataSource = this.DBContext.Moneda.Local.OrderBy( a => a.ID ).ToList();
            this.cbMoneda.DisplayMember = "Descripcion";
            this.cbMoneda.ValueMember = "ID";
        }
        #endregion Cargar CBMoneda

        #region Cliente
        private void tSBCliente_AceptarClick(object sender, EventArgs e)
        {
            if (fPickCliente == null)
            {
                fPickCliente = new frmPickBase();
                fPickCliente.AceptarFiltrarClick += fPickCliente_AceptarFiltrarClick;
                fPickCliente.FiltrarClick += fPickCliente_FiltrarClick;
                fPickCliente.Titulo = "Elegir Cliente";
                fPickCliente.CampoIDNombre = "ID";
                fPickCliente.CampoDescripNombre = "Nombre";
                fPickCliente.LabelCampoID = "ID";
                fPickCliente.LabelCampoDescrip = "Nombre";
                fPickCliente.NombreCampo = "Cliente";
                fPickCliente.PermitirFiltroNulo = false;
            }
            fPickCliente.MostrarFiltro();
        }

        private void fPickCliente_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickCliente != null)
            {
                fPickCliente.LoadData<Cliente>(this.DBContext.Cliente, fPickCliente.GetWhereString());
            }
        }

        private void fPickCliente_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBCliente.DisplayMember = fPickCliente.ValorDescrip;
            this.tSBCliente.KeyMember = fPickCliente.ValorID;

            fPickCliente.Close();
            fPickCliente.Dispose();
        }
        #endregion Cliente
        #endregion Picks

        private void GetFacturas(int clienteId, int monedaId, Nullable<DateTime> fechaDesde = null, Nullable<DateTime> fechaHasta = null)
        {
            List<FacturasParaRecibos> listaFacturas = this.DBContext.GetListadoFacturasParaRecibos(clienteId,
                                                                                            monedaId,
                                                                                            fechaDesde,
                                                                                            fechaHasta)
                                                                                            .ToList();
            this.dgvFacturasRecibos.RefreshEdit();
            this.dgvFacturasRecibos.DataSource = listaFacturas;
            this.dgvFacturasRecibos.AutoGenerateColumns = true;
            this.lblFilasRecuperadas.Text = String.Format(FILAS_RECUPERADAS, listaFacturas.Count());
            this.FormatearGrilla();
            this.OcultarCheckBoxSeleccionarNC();
            this.btnCobrar.Enabled = false;
            this.headerCheckBox.Visible = false;
            this.headerCheckBox.Checked = false;
            
            if (listaFacturas.Count() > 0)
            {
                this.headerCheckBox.Visible = true;
                this.dgvFacturasRecibos.Rows[0].Selected = true;
                this.dgvFacturasRecibos.Focus();
            }
        }
        #endregion Métodos de Inicio

        #region Métodos de Apoyo

        public void OcultarCheckBoxSeleccionarNC()
        {
            foreach (DataGridViewRow row in this.dgvFacturasRecibos.Rows)
            {
                bool conditionValue = row.Cells[CAMPO_TIPODOCUMENTO].Value.ToString() == NOTA_CREDITO_ELECTRONICA;

                if (conditionValue)
                {
                    DataGridViewImageCell imgCell = new DataGridViewImageCell();
                    imgCell.Value = this.btnParaImgNCE.Image;
                    row.Cells[COL_IMAGEN] = imgCell;
                    row.Cells[CAMPO_SELECCIONAR] = new DataGridViewTextBoxCell();
                    row.Cells[CAMPO_SELECCIONAR].Value = string.Empty;
                }
            }
        }

        private void FormatearGrilla()
        {
            string formatoMoneda = (int)this.cbMoneda.SelectedValue == GUARANIES_MONEDA_ID ? FORMATO_MONEDA_GUARANIES_GRILLA : FORMATO_MONEDA_OTROS_GRILLA;

            this.dgvFacturasRecibos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvFacturasRecibos.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Pixel);
            this.dgvFacturasRecibos.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dgvFacturasRecibos.DefaultCellStyle.Font = new Font("Arial", 11F, GraphicsUnit.Pixel);
            this.dgvFacturasRecibos.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvFacturasRecibos.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            this.dgvFacturasRecibos.ItemsPerPage = 15;
            this.dgvFacturasRecibos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvFacturasRecibos.MultiSelect = false;

            foreach (DataGridViewColumn col in this.dgvFacturasRecibos.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            int displayIndex = 0;

            //this.dgvFacturasRecibos.Columns[CAMPO_DOCUMENTOSASOCIADOS].Visible = true;
            //this.dgvFacturasRecibos.Columns[CAMPO_DOCUMENTOSASOCIADOS].DisplayIndex = displayIndex;
            //this.dgvFacturasRecibos.Columns[CAMPO_DOCUMENTOSASOCIADOS].HeaderText = "Doc. Asoc.";
            //this.dgvFacturasRecibos.Columns[CAMPO_DOCUMENTOSASOCIADOS].Width = 100;
            //displayIndex++;

            //this.dgvFacturasRecibos.Columns[CAMPO_FACTURAPRESUPUESTOCABID].Visible = true;
            //this.dgvFacturasRecibos.Columns[CAMPO_FACTURAPRESUPUESTOCABID].DisplayIndex = displayIndex;
            //this.dgvFacturasRecibos.Columns[CAMPO_FACTURAPRESUPUESTOCABID].HeaderText = "FacturaPresupuestoCabId";
            //this.dgvFacturasRecibos.Columns[CAMPO_FACTURAPRESUPUESTOCABID].Width = 100;
            //displayIndex++;

            this.dgvFacturasRecibos.Columns[CAMPO_TIPODOCUMENTO].Visible = true;
            this.dgvFacturasRecibos.Columns[CAMPO_TIPODOCUMENTO].DisplayIndex = displayIndex;
            this.dgvFacturasRecibos.Columns[CAMPO_TIPODOCUMENTO].HeaderText = "Tipo Comprobante";
            this.dgvFacturasRecibos.Columns[CAMPO_TIPODOCUMENTO].Width = 100;
            displayIndex++;

            this.dgvFacturasRecibos.Columns[CAMPO_NRO_FACTURA].Visible = true;
            this.dgvFacturasRecibos.Columns[CAMPO_NRO_FACTURA].DisplayIndex = displayIndex;
            this.dgvFacturasRecibos.Columns[CAMPO_NRO_FACTURA].HeaderText = "Nro. Comprobante";
            this.dgvFacturasRecibos.Columns[CAMPO_NRO_FACTURA].Width = 100;
            displayIndex++;

            this.dgvFacturasRecibos.Columns[CAMPO_CLIENTENOMBRE].Visible = true;
            this.dgvFacturasRecibos.Columns[CAMPO_CLIENTENOMBRE].DisplayIndex = displayIndex;
            this.dgvFacturasRecibos.Columns[CAMPO_CLIENTENOMBRE].HeaderText = "Cliente";
            this.dgvFacturasRecibos.Columns[CAMPO_CLIENTENOMBRE].Width = 70;
            displayIndex++;

            this.dgvFacturasRecibos.Columns[CAMPO_RUC].Visible = true;
            this.dgvFacturasRecibos.Columns[CAMPO_RUC].DisplayIndex = displayIndex;
            this.dgvFacturasRecibos.Columns[CAMPO_RUC].HeaderText = "RUC";
            this.dgvFacturasRecibos.Columns[CAMPO_RUC].Width = 70;
            displayIndex++;

            this.dgvFacturasRecibos.Columns[CAMPO_TIPOFACTURADESCRIP].Visible = true;
            this.dgvFacturasRecibos.Columns[CAMPO_TIPOFACTURADESCRIP].DisplayIndex = displayIndex;
            this.dgvFacturasRecibos.Columns[CAMPO_TIPOFACTURADESCRIP].HeaderText = "Tipo";
            this.dgvFacturasRecibos.Columns[CAMPO_TIPOFACTURADESCRIP].Width = 70;
            displayIndex++;

            this.dgvFacturasRecibos.Columns[CAMPO_FECHA_FACTURA].Visible = true;
            this.dgvFacturasRecibos.Columns[CAMPO_FECHA_FACTURA].DisplayIndex = displayIndex;
            this.dgvFacturasRecibos.Columns[CAMPO_FECHA_FACTURA].HeaderText = "Fecha Emisión";
            this.dgvFacturasRecibos.Columns[CAMPO_FECHA_FACTURA].Width = 100;
            displayIndex++;

            this.dgvFacturasRecibos.Columns[CAMPO_TOTAL].Visible = true;
            this.dgvFacturasRecibos.Columns[CAMPO_TOTAL].DisplayIndex = displayIndex;
            this.dgvFacturasRecibos.Columns[CAMPO_TOTAL].HeaderText = "Importe";
            this.dgvFacturasRecibos.Columns[CAMPO_TOTAL].Width = 70;
            this.dgvFacturasRecibos.Columns[CAMPO_TOTAL].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvFacturasRecibos.Columns[CAMPO_TOTAL].DefaultCellStyle.Format = formatoMoneda;
            displayIndex++;

            this.dgvFacturasRecibos.Columns[CAMPO_IMPORTECOBRADO].Visible = true;
            this.dgvFacturasRecibos.Columns[CAMPO_IMPORTECOBRADO].DisplayIndex = displayIndex;
            this.dgvFacturasRecibos.Columns[CAMPO_IMPORTECOBRADO].HeaderText = "Importe Cobrado";
            this.dgvFacturasRecibos.Columns[CAMPO_IMPORTECOBRADO].ReadOnly = false;
            this.dgvFacturasRecibos.Columns[CAMPO_IMPORTECOBRADO].Width = 70;
            this.dgvFacturasRecibos.Columns[CAMPO_IMPORTECOBRADO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvFacturasRecibos.Columns[CAMPO_IMPORTECOBRADO].DefaultCellStyle.Format = formatoMoneda;
            this.dgvFacturasRecibos.Columns[CAMPO_IMPORTECOBRADO].DefaultCellStyle.ForeColor = Color.Maroon;
            this.dgvFacturasRecibos.Columns[CAMPO_IMPORTECOBRADO].DefaultCellStyle.Font = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Pixel);
            displayIndex++;

            this.dgvFacturasRecibos.Columns[CAMPO_SALDO].Visible = true;
            this.dgvFacturasRecibos.Columns[CAMPO_SALDO].DisplayIndex = displayIndex;
            this.dgvFacturasRecibos.Columns[CAMPO_SALDO].HeaderText = "Saldo";
            this.dgvFacturasRecibos.Columns[CAMPO_SALDO].Width = 70;
            this.dgvFacturasRecibos.Columns[CAMPO_SALDO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvFacturasRecibos.Columns[CAMPO_SALDO].DefaultCellStyle.Format = formatoMoneda;
            displayIndex++;

            #region Columna Ver Factura
            DataGridViewCellStyle cStyle = new DataGridViewCellStyle();
            cStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cStyle.ForeColor = Color.Green;
            cStyle.Font = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Pixel);

            DataGridViewButtonColumn showDetails = new DataGridViewButtonColumn();
            showDetails.HeaderText = "Factura";
            showDetails.Text = "Ver";
            showDetails.UseColumnTextForButtonValue = true;
            showDetails.DefaultCellStyle = cStyle;
            showDetails.ToolTipText = "Presione para ver la factura";
            showDetails.Width = 60;
            showDetails.Name = CAMPO_VERDETALLES;
            this.dgvFacturasRecibos.Columns.Insert(displayIndex, showDetails);
            #endregion Columna Ver Detalles

            #region Columna Imagen
            DataGridViewCellStyle iStyle = new DataGridViewCellStyle();
            iStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            iStyle.Font = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Pixel);

            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol.HeaderText = "Selecc";
            imgCol.HeaderCell.Style.ForeColor = Color.Transparent;
            imgCol.Name = "Imagen";
            imgCol.DefaultCellStyle = iStyle;
            imgCol.Image = this.btnParaImgFE.Image;
            this.dgvFacturasRecibos.Columns.Insert(0, imgCol);
            displayIndex++;
            #endregion Columna Imagen

            DataGridViewCheckBoxColumn doWork = new DataGridViewCheckBoxColumn();
            doWork.HeaderText = "Selecc";//CAMPO_SELECCIONAR;
            doWork.HeaderCell.Style.ForeColor = Color.Transparent;
            doWork.Name = CAMPO_SELECCIONAR;
            doWork.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            doWork.FalseValue = false;
            doWork.TrueValue = true;
            doWork.ReadOnly = false;
            //doWork.Width = 80;
            this.dgvFacturasRecibos.Columns.Insert(0, doWork);
        }

        private void headerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool checkedState = this.headerCheckBox.Checked;

            foreach (DataGridViewRow row in this.dgvFacturasRecibos.Rows)
            {
                row.Cells[CAMPO_SELECCIONAR].Value = checkedState;
            }

            //this.dgvFacturasRecibos.Columns[CAMPO_SELECCIONAR].Width = 80;
        }

        #endregion Métodos de Apoyo

        #region Métodos sobre Controles Locales
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.dgvFacturasRecibos.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar alguna factura.",
                                "Atención Requerida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            if (this.AceptarFiltrarClick != null)
            {
                this.AceptarFiltrarClick(sender, e);
            }
            
        }
        #endregion Métodos sobre Controles Locales

        private void chkFiltroFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                this.pnlFiltroFecha.Visible = true;
                this.btnFiltrar.Location = new Point(915, 16);
            }
            else
            {
                this.pnlFiltroFecha.Visible = false;
                this.btnFiltrar.Location = new Point(676, 16);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            
            int monedaId = (int)this.cbMoneda.SelectedValue;
            Nullable<DateTime> fechaDesde = null;
            Nullable<DateTime> fechaHasta = null;

            if (this.tSBCliente.KeyMember == String.Empty)
            {
                MessageBox.Show("Es necesario seleccionar un cliente.",
                                "Atención Requerida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }
            int clienteId = Convert.ToInt32(this.tSBCliente.KeyMember);

            if (this.pnlFiltroFecha.Visible)
            {
                if ((this.dtpFechaDesde.Value == null) || (this.dtpFechaHasta.Value == null))
                {
                    MessageBox.Show("Debe especificar Fecha Desde y Fecha Hasta.",
                                    "Atención Requerida",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    return;
                }

                if (this.dtpFechaDesde.Value > this.dtpFechaHasta.Value)
                {
                    MessageBox.Show("La Fecha Hasta debe ser mayor o igual a la Fecha Desde.",
                                    "Atención Requerida",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    return;
                }
                fechaDesde = this.dtpFechaDesde.Value;
                fechaHasta = this.dtpFechaHasta.Value;
            }

            this.GetFacturas(clienteId, monedaId, fechaDesde, fechaHasta);
            
        }

        private void dgvFacturasRecibos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == 0) //columna que cambió es Seleccionar
                {
                    if ((this.dgvFacturasRecibos[e.ColumnIndex, e.RowIndex].GetType() == typeof(DataGridViewCheckBoxCell)) && (bool)this.dgvFacturasRecibos[e.ColumnIndex, e.RowIndex].Value)
                    {
                        if ((decimal)this.dgvFacturasRecibos.Rows[e.RowIndex].Cells[CAMPO_IMPORTECOBRADO].Value == 0)
                        {
                            this.dgvFacturasRecibos.Rows[e.RowIndex].Cells[CAMPO_IMPORTECOBRADO].Value = this.dgvFacturasRecibos.Rows[e.RowIndex].Cells[CAMPO_SALDO].Value;
                        }
                    }
                    else this.dgvFacturasRecibos.Rows[e.RowIndex].Cells[CAMPO_IMPORTECOBRADO].Value = (Nullable<decimal>)0;

                    this.dgvFacturasRecibos.Rows[e.RowIndex].ErrorText = string.Empty;
                    this.dgvFacturasRecibos.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    this.btnCobrar.Enabled = this.GetCantidadSeleccionados() > 0;
                }

                //if ((this.dgvFacturasRecibos.Columns[e.ColumnIndex].Name == CAMPO_IMPORTECOBRADO) &&
                //    (this.dgvFacturasRecibos.Rows[e.RowIndex].ErrorText == string.Empty))
                //{

                //    this.CalcularTotales();
                //}
            }
        }

        private int GetCantidadSeleccionados()
        {
            int result = 0;
            this.ListaSeleccionados.Clear();
            foreach (DataGridViewRow row in this.dgvFacturasRecibos.Rows)
            {
                if ((row.Cells[CAMPO_SELECCIONAR].GetType() == typeof(DataGridViewCheckBoxCell)) && (row.Cells[CAMPO_SELECCIONAR].Value != null) && ((bool)row.Cells[CAMPO_SELECCIONAR].Value))
                {
                    this.ListaSeleccionados.Add((FacturasParaRecibos)row.DataBoundItem);
                    this.ListaSeleccionados.AddRange(this.GetNCAsociadas(((FacturasParaRecibos)row.DataBoundItem).FacturaCabId));
                    result++;
                }
            }

            this.CalcularTotales();
            this.lblSeleccionadas.Text = result == 0 ? string.Empty : string.Format(FILAS_SELECCIONADAS, result);
            return result;
        }

        private void CalcularTotales()
        {
            string formatoMoneda = (int)this.cbMoneda.SelectedValue == GUARANIES_MONEDA_ID ? FORMATO_MONEDA_GUARANIES : FORMATO_MONEDA_OTROS;

            decimal totalImpCob = this.ListaSeleccionados
                                    .Where(p => p.TipoDocumento != NOTA_CREDITO_ELECTRONICA)
                                    .Sum(p => p.ImporteCobrado.Value);
            decimal totalNC = this.ListaSeleccionados
                                    .Where(p => p.TipoDocumento == NOTA_CREDITO_ELECTRONICA)
                                    .Sum(p => p.Total);

            this.txtTotalImpCob.Text = string.Format(formatoMoneda, totalImpCob);
            this.txtTotalNCred.Text = string.Format(formatoMoneda, totalNC);
            this.txtTotalRecibo.Text = string.Format(formatoMoneda, totalImpCob - totalNC);
        }

        private List<FacturasParaRecibos> GetNCAsociadas(int facturaCabID)
        {
            return ((List<FacturasParaRecibos>)this.dgvFacturasRecibos.DataSource)
                .Where(a => a.FacturaCabIdRel == facturaCabID
                    && a.TipoDocumento == NOTA_CREDITO_ELECTRONICA).ToList();
        }

        private void dgvFacturasRecibos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1)
            {
                if (this.dgvFacturasRecibos.Columns[e.ColumnIndex].Name == CAMPO_VERDETALLES)
                {
                    string cdc = this.dgvFacturasRecibos.Rows[e.RowIndex].Cells[CAMPO_CDC].Value != null ? this.dgvFacturasRecibos.Rows[e.RowIndex].Cells[CAMPO_CDC].Value.ToString() : String.Empty;

                    if (cdc != String.Empty)
                    {
                        string pdfUrl = "https://facte.siga.com.py/FacturaE/printDE?ruc=80016875-5&cdc=" + cdc;
                        LinkParameters linkParameters = new LinkParameters();
                        linkParameters.Target = "_blank";
                        Link.Open(pdfUrl, linkParameters);
                    }
                    else
                    {
                        MessageBox.Show("La factura no es electrónica o no tiene CDC válido.",
                                        "Atención Requerida",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }
        }

        private bool DataGridViewHasErrors(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // Verificar errores a nivel de fila
                if (!string.IsNullOrEmpty(row.ErrorText))
                {
                    return true;
                }
            }
            return false;
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (this.GetCantidadSeleccionados() > LIMITE_FACTURAS_POR_RECIBO)
            {
                MessageBox.Show("Sólo pueden incluirse " + 
                                LIMITE_FACTURAS_POR_RECIBO.ToString() +
                                " facturas por recibo.",
                                        "Atención Requerida",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                return;
            }

            if (this.DataGridViewHasErrors(this.dgvFacturasRecibos))
            {
                MessageBox.Show("Existen errores que de deben corregirse en la grilla para proceder a realizar el cobro.",
                                        "Atención Requerida",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                return;
            }

            int timbradoID = this.CheckPermisoTimbradoRecibo();
            if (timbradoID > 0)
            {
                fRealizarCobroRecibo = new FRealizarCobroRecibo(this.DBContext, "Cobros a Clientes", this.ListaSeleccionados, timbradoID);
                fRealizarCobroRecibo.ShowDialog();
            }
            else
            {   
                MessageBox.Show("El usuario no cuenta con permisos para emisión de recibos.",
                                       "Atención Requerida",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Exclamation);
                return;
            }

        }

        private int CheckPermisoTimbradoRecibo()
        {
            //int timbradoID = -1;
            //using (BerkeDBEntities context = new BerkeDBEntities())
            //{
            //    int clienteID = Convert.ToInt32(this.tSBCliente.KeyMember);
            //    Nullable<bool> esClienteLocal = context.Cliente.FirstOrDefault(a => a.ID == clienteID).PaisID == PARAGUAY_ID;

            //    int checkTimbradoID = ((esClienteLocal.HasValue) && (esClienteLocal.Value)) ? RECIBO_SERIE_3_CLIENTE_LOCAL : RECIBO_SERIE_4_CLIENTE_EXTERIOR;

            //    var lista = (from ti in this.DBContext.ti_timbrado
            //                 join su in this.DBContext.su_serieusuario
            //                     on ti.ti_timbradoid equals su.su_timbradoid
            //                 select new CBSerie
            //                 {
            //                     TimbradoID = ti.ti_timbradoid,
            //                     DescripcionTimbrado = ti.ti_descripcion,
            //                     Vigente = ti.ti_vigente,
            //                     UsuarioID = su.su_usuarioid,
            //                     TipoDocumentoID = ti.ti_tipodocumentoid
            //                 })
            //                 .Where(a => a.Vigente == true 
            //                     && a.UsuarioID == this.UsuarioID 
            //                     && a.TimbradoID == checkTimbradoID)
            //                 .OrderBy(b => b.TimbradoID)
            //                 .ToList();

            //    if (lista.Count > 0)
            //        timbradoID = lista.First().TimbradoID;
                
            //}
            ti_timbrado timbrado = null;
            using (BerkeDBEntities context = new BerkeDBEntities())
            {
                timbrado = context.ti_timbrado.FirstOrDefault(a => a.ti_tipodocumentoid == TIPODOCUMENTO_RECIBO_CLIENTE 
                                                                && a.ti_usuarioid == this.UsuarioID
                                                                && a.ti_vigente == true);
            }

            return timbrado != null ? timbrado.ti_timbradoid : -1;
        }

        private void dgvFacturasRecibos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (this.dgvFacturasRecibos.Rows[e.RowIndex].Cells[CAMPO_TIPODOCUMENTO].Value.ToString() == NOTA_CREDITO_ELECTRONICA)
                {
                    ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_IMPORTECOBRADO].ReadOnly = true;
                }
            }
        }

        private void dgvFacturasRecibos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Verifica si la columna es la que debe validarse
            if (this.dgvFacturasRecibos.Columns[e.ColumnIndex].Name == CAMPO_IMPORTECOBRADO)
            {
                decimal value;
                if (!decimal.TryParse(e.FormattedValue.ToString(), out value))
                {
                    // Mostrar mensaje de error si el valor no es numérico
                    this.dgvFacturasRecibos.Rows[e.RowIndex].ErrorText = "Debe ingresar un valor numérico.";
                    this.dgvFacturasRecibos.Rows[e.RowIndex].Cells[CAMPO_IMPORTECOBRADO].Value = (Nullable<decimal>)0; ;
                    //e.Cancel = true; // Cancelar la edición si el valor no es válido
                }
                else if ((value > 0) && (value > (decimal)this.dgvFacturasRecibos.Rows[e.RowIndex].Cells[CAMPO_SALDO].Value))
                {
                    // Mostrar mensaje de error si el valor es mayor a 100
                    this.dgvFacturasRecibos.Rows[e.RowIndex].ErrorText = "El importe cobrado no puede ser mayor al saldo.";
                    this.dgvFacturasRecibos.Rows[e.RowIndex].Cells[CAMPO_IMPORTECOBRADO].Value = (Nullable<decimal>)0; ;
                    //e.Cancel = true; // Cancelar la edición si el valor es mayor a 100
                }
                else
                {
                    // Limpiar el mensaje de error si el valor es válido
                    this.dgvFacturasRecibos.Rows[e.RowIndex].ErrorText = string.Empty;
                    this.dgvFacturasRecibos.CommitEdit(DataGridViewDataErrorContexts.Commit);

                    
                }
                this.dgvFacturasRecibos.Rows[e.RowIndex].Cells[CAMPO_SELECCIONAR].Value = (decimal)this.dgvFacturasRecibos.Rows[e.RowIndex].Cells[CAMPO_IMPORTECOBRADO].Value > 0;
                this.CalcularTotales();
            }
        }

        private void dgvFacturasRecibos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if ((this.dgvFacturasRecibos.Columns[e.ColumnIndex].Name == CAMPO_IMPORTECOBRADO) &&
                (e.Exception.Message == ERROR_CADENA_FORMATO))
            {
                this.dgvFacturasRecibos.Rows[e.RowIndex].Cells[CAMPO_IMPORTECOBRADO].Value = (Nullable<decimal>)0; ;
            }
        }

        private void dgvFacturasRecibos_KeyDown(object objSender, KeyEventArgs objArgs)
        {
            if (objArgs.KeyCode == Keys.Space)
            {
                if (this.dgvFacturasRecibos.CurrentRow != null)
                {
                    DataGridViewRow row = this.dgvFacturasRecibos.CurrentRow;
                    bool checkState = row.Cells[CAMPO_SELECCIONAR].Value != null
                                        ? (bool)row.Cells[CAMPO_SELECCIONAR].Value
                                        : false;
                    row.Cells[CAMPO_SELECCIONAR].Value = !checkState;
                    this.btnCancelar.Focus();
                    this.dgvFacturasRecibos.Focus();
                }
            }
        }
    }
}