#region Using

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.IO;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms;

using ModelEF6;
using SPF.Forms.Base;
using SPF.Types;
using SPF.Forms;
using SPF.Base;

#endregion

namespace SPF.Forms.UI
{
    
    public partial class FCargarRetencionesRecibo : Form
    {
        #region Variables
        BerkeDBEntities DBContext;
        private FormatoNumeroReciboType formatoNumeroRecibo;
        private int clienteId;
        private int monedaId;
        private string monedaAbrev;
        private decimal totalRecibo;
        private List<FacturasParaRetenciones> listaFacturasRetenciones;
        private FCargarDatosRetencion fCargarDatosRetencion;
        private CheckBox headerCheckBox;
        private List<FacturasParaRecibos> listaFacturas;
        #endregion Variables

        #region Constantes
        private const int GUARANIES_MONEDA_ID = 3;
        private const string FORMATO_MONEDA_GUARANIES = "{0:N0}";
        private const string FORMATO_MONEDA_OTROS = "{0:N2}";
        private const string FORMATO_MONEDA_GUARANIES_GRILLA = "N0";
        private const string FORMATO_MONEDA_OTROS_GRILLA = "N2";
        private const string NOTA_CREDITO_ELECTRONICA = "Nota Crédito Electrónica";

        private const string CAMPO_SELECCIONAR = "Seleccionar";
        public const string CAMPO_CARGARRETENCION = "CargarRetencion";

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
        private const string COL_IMAGEN = "Imagen";

        private const string CAMPO_NRORETENCION = "NroRetencion";
        private const string CAMPO_FECHARETENCION = "FechaRetencion";
        private const string CAMPO_NCLIQIVA5 = "NCLiqIVA5";
        private const string CAMPO_NCLIQIVA10 = "NCLiqIVA10";
        private const string CAMPO_RETENCIONIVA5 = "RetencionIVA5";
        private const string CAMPO_RETENCIONIVA10 = "RetencionIVA10";
        private const string CAMPO_RETENCIONRENTA = "RetencionRenta";
        #endregion Constantes

        #region Eventos Personalizados
        public event EventHandler AceptarClick;
        #endregion Eventos Personalizados

        #region Propiedades
        private FormatoNumeroReciboType FormatoNumeroRecibo
        {
            get { return this.formatoNumeroRecibo; }
            set { this.formatoNumeroRecibo = value; }
        }

        public int MonedaId
        {
            set { this.monedaId = value; }
            get { return this.monedaId; }
        }

        public string MonedaAbrev
        {
            set { this.monedaAbrev = value; }
            get { return this.monedaAbrev; }
        }

        private decimal TotalRecibo
        {
            set { this.totalRecibo = value; }
            get { return this.totalRecibo; }
        }

        private List<FacturasParaRecibos> ListaFacturas
        {
            set { this.listaFacturas = value; }
            get { return this.listaFacturas; }
        }

        public List<FacturasParaRetenciones> ListaFacturasRetenciones
        {
            set { this.listaFacturasRetenciones = value; }
            get { return this.listaFacturasRetenciones; }
        }

        public int ClienteId
        {
            set { this.clienteId = value; }
            get { return this.clienteId; }
        }
        #endregion Propiedades

        #region Metodos de Inicio
        public FCargarRetencionesRecibo()
        {
            InitializeComponent();
        }

        public FCargarRetencionesRecibo(BerkeDBEntities context, 
                                        string titulo, List<FacturasParaRetenciones> listaFacturasRetenciones, 
                                        List<FacturasParaRecibos> listaFacturas, 
                                        decimal totalRecibo)
        {
            InitializeComponent();
            this.Text = titulo;
            this.DBContext = context;
            this.formatoNumeroRecibo = new FormatoNumeroReciboType();
            this.ClienteId = listaFacturas.First().ClienteId.Value;
            this.MonedaId = listaFacturas.First().MonedaId;
            this.MonedaAbrev = listaFacturas.First().MonedaAbrev;
            this.TotalRecibo = totalRecibo;

            this.GetDatosRetencionCliente();

            this.ListaFacturasRetenciones = listaFacturasRetenciones != null
                                                ? listaFacturasRetenciones
                                                : this.MakeList(listaFacturas);
            this.dgvRetenciones.DataSource = this.ListaFacturasRetenciones;
            this.dgvRetenciones.AutoGenerateColumns = false;
            this.FormatearGrilla();
            this.SetFormatoNumero();
            this.CalcularTotalesRetenciones();

            this.headerCheckBox = new CheckBox();
            this.headerCheckBox.CheckedChanged += headerCheckBox_CheckedChanged;
            this.headerCheckBox.Size = new Size(19, 19);
            this.panel1.Controls.Add(this.headerCheckBox);
            this.headerCheckBox.Location = new Point(this.headerCheckBox.Location.X + 54, this.headerCheckBox.Location.Y);
            this.toolTip1.SetToolTip(this.headerCheckBox, "Marcar o desmarcar todas las facturas");
            this.headerCheckBox.Visible = true;
            this.headerCheckBox.Checked = false;
            this.btnCargarDatosRetencion.Enabled = false;

            this.txtCliente.Text = listaFacturas.First().ClienteNombre;
        }

        private void GetDatosRetencionCliente()
        {
            using (BerkeDBEntities context = new BerkeDBEntities())
            {
                cr_clienteretencion cr = context.cr_clienteretencion
                                            .FirstOrDefault(a => a.cr_clienteid == this.ClienteId);

                if (cr != null)
                {
                    this.txtPorcRetIVA10.Text = cr.cr_porcentajeiva10.ToString();
                    this.txtPorcRetRenta.Text = cr.cr_porcentajerenta.ToString();
                    this.txtNroTimbrado.Text = cr.cr_nrotimbrado.ToString();
                }
            }
        }

        private void FCargarRetencionesRecibo_Load(object sender, EventArgs e)
        {
            this.LimpiarTextBoxes();
        }

        private void CalcularTotalesRetenciones()
        {
            decimal totalRetIVA10 = 0;
            decimal totalRetRenta = 0;

            foreach (DataGridViewRow row in this.dgvRetenciones.Rows)
            {
                totalRetIVA10 += (decimal)row.Cells[CAMPO_RETENCIONIVA10].Value;
                totalRetRenta += (decimal)row.Cells[CAMPO_RETENCIONRENTA].Value;
            }

            this.txtTotalRetIVA10.Text = string.Format(this.FormatoNumeroRecibo.General, totalRetIVA10);
            this.txtTotalRetRenta.Text = string.Format(this.FormatoNumeroRecibo.General, totalRetRenta);
            this.txtTotalRetenciones.Text = string.Format(this.FormatoNumeroRecibo.General, totalRetIVA10 + totalRetRenta);
        }

        private List<FacturasParaRetenciones> MakeList(List<FacturasParaRecibos> listaFacturas)
        {

            int porcentajeRetIVA10 = this.txtPorcRetIVA10.Text.Trim() == string.Empty 
                                        ? 0
                                        : Convert.ToInt32(this.txtPorcRetIVA10.Text);
            int porcentajeRetRenta = this.txtPorcRetRenta.Text.Trim() == string.Empty
                                        ? 0
                                        : Convert.ToInt32(this.txtPorcRetRenta.Text);

            List<FacturasParaRetenciones> listaFacturasRetencionesLocal = new List<FacturasParaRetenciones>();
            var propiedadesListaFacturas = typeof(FacturasParaRecibos).GetProperties();
            var propiedadesListaFacturasRetencion = typeof(FacturasParaRetenciones).GetProperties();

            foreach(FacturasParaRecibos row in listaFacturas)
            {
                if (row.TipoDocumento == NOTA_CREDITO_ELECTRONICA)
                {
                    decimal ivaNC10 = row.Total / 11;
                    if (this.MonedaId == GUARANIES_MONEDA_ID)
                        ivaNC10 = decimal.Round(ivaNC10, 0, MidpointRounding.AwayFromZero);
                    else ivaNC10 = decimal.Round(ivaNC10, 2);

                    var x = listaFacturasRetencionesLocal
                            .Where(a => a.FacturaCabId == row.FacturaCabIdRel)
                            .FirstOrDefault();

                    decimal NCLiqIVA10 = ivaNC10;

                    decimal ImporteCobrado = x.ImporteCobrado.Value - row.Total;

                    decimal LiqIVA10 = 0;
                    decimal iva10 = ImporteCobrado / 11;
                    if (this.MonedaId == GUARANIES_MONEDA_ID)
                        LiqIVA10 = decimal.Round(iva10, 0, MidpointRounding.AwayFromZero);
                    else LiqIVA10 = decimal.Round(iva10, 2);

                    listaFacturasRetencionesLocal
                            .Where(a => a.FacturaCabId == row.FacturaCabIdRel)
                            .FirstOrDefault()
                            .NCLiqIVA10 = ivaNC10;

                    listaFacturasRetencionesLocal
                            .Where(a => a.FacturaCabId == row.FacturaCabIdRel)
                            .FirstOrDefault()
                            .ImporteCobrado = ImporteCobrado;

                    listaFacturasRetencionesLocal
                            .Where(a => a.FacturaCabId == row.FacturaCabIdRel)
                            .FirstOrDefault()
                            .LiqIVA10 = LiqIVA10;


                    if (porcentajeRetIVA10 > 0)
                    {
                        decimal retIVA10 = LiqIVA10 * porcentajeRetIVA10 / 100;
                        if (this.MonedaId == GUARANIES_MONEDA_ID)
                        {
                            listaFacturasRetencionesLocal
                            .Where(a => a.FacturaCabId == row.FacturaCabIdRel)
                            .FirstOrDefault()
                            .RetencionIVA10 = decimal.Round(retIVA10, 0, MidpointRounding.AwayFromZero);
                        }
                        else
                        {
                            listaFacturasRetencionesLocal
                            .Where(a => a.FacturaCabId == row.FacturaCabIdRel)
                            .FirstOrDefault()
                            .RetencionIVA10 = decimal.Round(retIVA10, 2);
                        }
                    }

                    if (porcentajeRetRenta > 0)
                    {
                        decimal retRenta = ImporteCobrado * porcentajeRetRenta / 100;
                        if (this.MonedaId == GUARANIES_MONEDA_ID)
                        {
                            listaFacturasRetencionesLocal
                            .Where(a => a.FacturaCabId == row.FacturaCabIdRel)
                            .FirstOrDefault()
                            .RetencionRenta = decimal.Round(retRenta, 0, MidpointRounding.AwayFromZero);
                        }
                        else
                        {
                            listaFacturasRetencionesLocal
                            .Where(a => a.FacturaCabId == row.FacturaCabIdRel)
                            .FirstOrDefault()
                            .RetencionRenta = decimal.Round(retRenta, 2);
                        }
                    }

                    continue;
                }


                FacturasParaRetenciones facturaRetencion = new FacturasParaRetenciones();
                for (int i = 0; i < propiedadesListaFacturas.Length; i++)
                {
                    var valor = propiedadesListaFacturas[i].GetValue(row);
                    propiedadesListaFacturasRetencion[i].SetValue(facturaRetencion, valor);
                }

                facturaRetencion.NroRetencion =  string.Empty;
                facturaRetencion.FechaRetencion = string.Empty;
                facturaRetencion.NCLiqIVA5 = 0;
                facturaRetencion.NCLiqIVA10 = 0;
                facturaRetencion.RetencionIVA5 = 0;
                facturaRetencion.RetencionIVA10 = 0;
                facturaRetencion.RetencionRenta = 0;
                
                //Actualizar LiqIVA10 (se aplicara a pagos parciales)
                if (facturaRetencion.ImporteCobrado != facturaRetencion.TotalIVA10)
                {
                    facturaRetencion.LiqIVA5 = 0;

                    decimal iva10 = facturaRetencion.ImporteCobrado.Value / 11;
                    if (this.MonedaId == GUARANIES_MONEDA_ID)
                        facturaRetencion.LiqIVA10 = decimal.Round(iva10, 0, MidpointRounding.AwayFromZero);
                    else facturaRetencion.LiqIVA10 = decimal.Round(iva10, 2);
                }

                if (porcentajeRetIVA10 > 0)
                {
                    decimal retIVA10 = facturaRetencion.LiqIVA10 * porcentajeRetIVA10 / 100;
                    if (this.MonedaId == GUARANIES_MONEDA_ID)
                        facturaRetencion.RetencionIVA10 = decimal.Round(retIVA10, 0, MidpointRounding.AwayFromZero);
                    else facturaRetencion.RetencionIVA10 = decimal.Round(retIVA10, 2);
                }

                if (porcentajeRetRenta > 0)
                {
                    decimal retRenta = facturaRetencion.ImporteCobrado.Value * porcentajeRetRenta / 100;
                    if (this.MonedaId == GUARANIES_MONEDA_ID)
                        facturaRetencion.RetencionRenta = decimal.Round(retRenta, 0, MidpointRounding.AwayFromZero);
                    else facturaRetencion.RetencionRenta = decimal.Round(retRenta, 2);
                }

                listaFacturasRetencionesLocal.Add(facturaRetencion);
            }
            return listaFacturasRetencionesLocal;
        }

        private void SetFormatoNumero()
        {
            if (this.MonedaId == GUARANIES_MONEDA_ID)
            {
                this.FormatoNumeroRecibo.General = FORMATO_MONEDA_GUARANIES;
            }
            else
            {
                this.FormatoNumeroRecibo.General = FORMATO_MONEDA_OTROS;
            }
        }

        private void FormatearGrilla()
        {
            string formatoMoneda = this.MonedaId == GUARANIES_MONEDA_ID ? FORMATO_MONEDA_GUARANIES_GRILLA : FORMATO_MONEDA_OTROS_GRILLA;

            this.dgvRetenciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRetenciones.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Pixel);
            this.dgvRetenciones.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dgvRetenciones.DefaultCellStyle.Font = new Font("Arial", 11F, GraphicsUnit.Pixel);
            this.dgvRetenciones.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvRetenciones.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            this.dgvRetenciones.ItemsPerPage = 15;
            this.dgvRetenciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvRetenciones.MultiSelect = false;

            foreach (DataGridViewColumn col in this.dgvRetenciones.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            int displayIndex = 0;

            //#region Columna Cargar Retención
            //DataGridViewCellStyle cStyle = new DataGridViewCellStyle();
            //cStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //cStyle.ForeColor = Color.Green;
            //cStyle.Font = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Pixel);

            //DataGridViewButtonColumn cargarRetencion = new DataGridViewButtonColumn();
            //cargarRetencion.HeaderText = " ";
            //cargarRetencion.Text = "Cargar";
            //cargarRetencion.UseColumnTextForButtonValue = true;
            //cargarRetencion.DefaultCellStyle = cStyle;
            //cargarRetencion.ToolTipText = "Presione para cargar la retención de la factura";
            //cargarRetencion.Width = 60;
            //cargarRetencion.Name = CAMPO_CARGARRETENCION;
            //this.dgvRetenciones.Columns.Insert(displayIndex, cargarRetencion);
            //#endregion Columna Ver Detalles

            //this.dgvRetenciones.Columns[CAMPO_TIPODOCUMENTO].Visible = false;
            //this.dgvRetenciones.Columns[CAMPO_TIPODOCUMENTO].DisplayIndex = displayIndex;
            //this.dgvRetenciones.Columns[CAMPO_TIPODOCUMENTO].HeaderText = "Tipo Comprobante";
            //this.dgvRetenciones.Columns[CAMPO_TIPODOCUMENTO].Width = 100;
            //displayIndex++;

            this.dgvRetenciones.Columns[CAMPO_NRO_FACTURA].Visible = true;
            this.dgvRetenciones.Columns[CAMPO_NRO_FACTURA].DisplayIndex = displayIndex;
            this.dgvRetenciones.Columns[CAMPO_NRO_FACTURA].HeaderText = "Nro. Comprobante";
            this.dgvRetenciones.Columns[CAMPO_NRO_FACTURA].Width = 100;
            displayIndex++;

            this.dgvRetenciones.Columns[CAMPO_FECHA_FACTURA].Visible = true;
            this.dgvRetenciones.Columns[CAMPO_FECHA_FACTURA].DisplayIndex = displayIndex;
            this.dgvRetenciones.Columns[CAMPO_FECHA_FACTURA].HeaderText = "Fecha Fact.";
            this.dgvRetenciones.Columns[CAMPO_FECHA_FACTURA].Width = 100;
            displayIndex++;

            this.dgvRetenciones.Columns[CAMPO_NRORETENCION].Visible = true;
            this.dgvRetenciones.Columns[CAMPO_NRORETENCION].DisplayIndex = displayIndex;
            this.dgvRetenciones.Columns[CAMPO_NRORETENCION].HeaderText = "Nro. Retención";
            this.dgvRetenciones.Columns[CAMPO_NRORETENCION].Width = 100;
            displayIndex++;

            //this.dgvRetenciones.Columns[CAMPO_CLIENTENOMBRE].Visible = false;
            //this.dgvRetenciones.Columns[CAMPO_CLIENTENOMBRE].DisplayIndex = displayIndex;
            //this.dgvRetenciones.Columns[CAMPO_CLIENTENOMBRE].HeaderText = "Cliente";
            //this.dgvRetenciones.Columns[CAMPO_CLIENTENOMBRE].Width = 70;
            //displayIndex++;

            //this.dgvRetenciones.Columns[CAMPO_RUC].Visible = false;
            //this.dgvRetenciones.Columns[CAMPO_RUC].DisplayIndex = displayIndex;
            //this.dgvRetenciones.Columns[CAMPO_RUC].HeaderText = "RUC";
            //this.dgvRetenciones.Columns[CAMPO_RUC].Width = 70;
            //displayIndex++;

            //this.dgvRetenciones.Columns[CAMPO_TIPOFACTURADESCRIP].Visible = false;
            //this.dgvRetenciones.Columns[CAMPO_TIPOFACTURADESCRIP].DisplayIndex = displayIndex;
            //this.dgvRetenciones.Columns[CAMPO_TIPOFACTURADESCRIP].HeaderText = "Tipo";
            //this.dgvRetenciones.Columns[CAMPO_TIPOFACTURADESCRIP].Width = 70;
            //displayIndex++;

            this.dgvRetenciones.Columns[CAMPO_FECHARETENCION].Visible = true;
            this.dgvRetenciones.Columns[CAMPO_FECHARETENCION].DisplayIndex = displayIndex;
            this.dgvRetenciones.Columns[CAMPO_FECHARETENCION].HeaderText = "Fecha Ret.";
            //this.dgvRetenciones.Columns[CAMPO_FECHARETENCION].DefaultCellStyle.Format = "dd/MM/yyyy";
            this.dgvRetenciones.Columns[CAMPO_FECHARETENCION].Width = 100;
            displayIndex++;

            //this.dgvRetenciones.Columns[CAMPO_TOTAL].Visible = true;
            //this.dgvRetenciones.Columns[CAMPO_TOTAL].DisplayIndex = displayIndex;
            //this.dgvRetenciones.Columns[CAMPO_TOTAL].HeaderText = "Importe";
            //this.dgvRetenciones.Columns[CAMPO_TOTAL].Width = 70;
            //this.dgvRetenciones.Columns[CAMPO_TOTAL].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dgvRetenciones.Columns[CAMPO_TOTAL].DefaultCellStyle.Format = formatoMoneda;
            //displayIndex++;

            this.dgvRetenciones.Columns[CAMPO_IMPORTECOBRADO].Visible = true;
            this.dgvRetenciones.Columns[CAMPO_IMPORTECOBRADO].DisplayIndex = displayIndex;
            this.dgvRetenciones.Columns[CAMPO_IMPORTECOBRADO].HeaderText = "Grav. 10%";
            //this.dgvRetenciones.Columns[CAMPO_IMPORTECOBRADO].ReadOnly = false;
            this.dgvRetenciones.Columns[CAMPO_IMPORTECOBRADO].Width = 70;
            this.dgvRetenciones.Columns[CAMPO_IMPORTECOBRADO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvRetenciones.Columns[CAMPO_IMPORTECOBRADO].DefaultCellStyle.Format = formatoMoneda;
            this.dgvRetenciones.Columns[CAMPO_IMPORTECOBRADO].DefaultCellStyle.ForeColor = Color.Maroon;
            this.dgvRetenciones.Columns[CAMPO_IMPORTECOBRADO].DefaultCellStyle.Font = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Pixel);
            displayIndex++;

            this.dgvRetenciones.Columns[CAMPO_LIQIVA10].Visible = true;
            this.dgvRetenciones.Columns[CAMPO_LIQIVA10].DisplayIndex = displayIndex;
            this.dgvRetenciones.Columns[CAMPO_LIQIVA10].HeaderText = "IVA 10%";
            //this.dgvRetenciones.Columns[CAMPO_IMPORTECOBRADO].ReadOnly = false;
            this.dgvRetenciones.Columns[CAMPO_LIQIVA10].Width = 70;
            this.dgvRetenciones.Columns[CAMPO_LIQIVA10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvRetenciones.Columns[CAMPO_LIQIVA10].DefaultCellStyle.Format = formatoMoneda;
            this.dgvRetenciones.Columns[CAMPO_LIQIVA10].DefaultCellStyle.ForeColor = Color.Maroon;
            this.dgvRetenciones.Columns[CAMPO_LIQIVA10].DefaultCellStyle.Font = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Pixel);
            displayIndex++;

            this.dgvRetenciones.Columns[CAMPO_NCLIQIVA10].Visible = true;
            this.dgvRetenciones.Columns[CAMPO_NCLIQIVA10].DisplayIndex = displayIndex;
            this.dgvRetenciones.Columns[CAMPO_NCLIQIVA10].HeaderText = "IVA NC 10%";
            this.dgvRetenciones.Columns[CAMPO_NCLIQIVA10].Width = 70;
            this.dgvRetenciones.Columns[CAMPO_NCLIQIVA10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvRetenciones.Columns[CAMPO_NCLIQIVA10].DefaultCellStyle.Format = formatoMoneda;
            this.dgvRetenciones.Columns[CAMPO_NCLIQIVA10].DefaultCellStyle.ForeColor = Color.Maroon;
            this.dgvRetenciones.Columns[CAMPO_NCLIQIVA10].DefaultCellStyle.Font = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Pixel);
            displayIndex++;

            this.dgvRetenciones.Columns[CAMPO_RETENCIONIVA10].Visible = true;
            this.dgvRetenciones.Columns[CAMPO_RETENCIONIVA10].DisplayIndex = displayIndex;
            this.dgvRetenciones.Columns[CAMPO_RETENCIONIVA10].HeaderText = "Ret. IVA 10%";
            this.dgvRetenciones.Columns[CAMPO_RETENCIONIVA10].Width = 70;
            this.dgvRetenciones.Columns[CAMPO_RETENCIONIVA10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvRetenciones.Columns[CAMPO_RETENCIONIVA10].DefaultCellStyle.Format = formatoMoneda;
            this.dgvRetenciones.Columns[CAMPO_RETENCIONIVA10].DefaultCellStyle.ForeColor = Color.Maroon;
            this.dgvRetenciones.Columns[CAMPO_RETENCIONIVA10].DefaultCellStyle.Font = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Pixel);
            displayIndex++;

            this.dgvRetenciones.Columns[CAMPO_RETENCIONRENTA].Visible = true;
            this.dgvRetenciones.Columns[CAMPO_RETENCIONRENTA].DisplayIndex = displayIndex;
            this.dgvRetenciones.Columns[CAMPO_RETENCIONRENTA].HeaderText = "Ret. Renta";
            this.dgvRetenciones.Columns[CAMPO_RETENCIONRENTA].Width = 70;
            this.dgvRetenciones.Columns[CAMPO_RETENCIONRENTA].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvRetenciones.Columns[CAMPO_RETENCIONRENTA].DefaultCellStyle.Format = formatoMoneda;
            this.dgvRetenciones.Columns[CAMPO_RETENCIONRENTA].DefaultCellStyle.ForeColor = Color.Maroon;
            this.dgvRetenciones.Columns[CAMPO_RETENCIONRENTA].DefaultCellStyle.Font = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Pixel);
            displayIndex++;

            //this.dgvRetenciones.Columns[CAMPO_SALDO].Visible = true;
            //this.dgvRetenciones.Columns[CAMPO_SALDO].DisplayIndex = displayIndex;
            //this.dgvRetenciones.Columns[CAMPO_SALDO].HeaderText = "Saldo";
            //this.dgvRetenciones.Columns[CAMPO_SALDO].Width = 70;
            //this.dgvRetenciones.Columns[CAMPO_SALDO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dgvRetenciones.Columns[CAMPO_SALDO].DefaultCellStyle.Format = formatoMoneda;
            //displayIndex++;

            

            //#region Columna Imagen
            //DataGridViewCellStyle iStyle = new DataGridViewCellStyle();
            //iStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //iStyle.Font = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Pixel);

            //DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            //imgCol.HeaderText = "Selecc";
            //imgCol.HeaderCell.Style.ForeColor = Color.Transparent;
            //imgCol.Name = "Imagen";
            //imgCol.DefaultCellStyle = iStyle;
            //imgCol.Image = this.btnParaImgFE.Image;
            //this.dgvRetenciones.Columns.Insert(0, imgCol);
            //displayIndex++;
            //#endregion Columna Imagen

            DataGridViewCheckBoxColumn doWork = new DataGridViewCheckBoxColumn();
            doWork.HeaderText = "Selecc";//CAMPO_SELECCIONAR;
            doWork.HeaderCell.Style.ForeColor = Color.Transparent;
            doWork.Name = CAMPO_SELECCIONAR;
            doWork.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            doWork.FalseValue = false;
            doWork.TrueValue = true;
            doWork.ReadOnly = false;
            //doWork.Width = 80;
            this.dgvRetenciones.Columns.Insert(0, doWork);
        }
        #endregion Metodos de Inicio

        #region Metodos de Apoyo
        private void CargarRetenciones()
        {
            if (this.ValidarDatos())
            {
                if (this.AceptarClick != null)
                {
                    this.AceptarClick(this, null);
                }
            }
        }

        private bool ValidarDatos()
        {
            foreach (DataGridViewRow row in this.dgvRetenciones.Rows)
            {
                if ((row.Cells[CAMPO_FECHARETENCION].Value.ToString() == string.Empty) ||
                    (row.Cells[CAMPO_NRORETENCION].Value.ToString() == string.Empty))
                {
                     MessageBox.Show("Debe cargar información de fecha y número de retención para las facturas.",
                               "Atención Requerida",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                     return false;
                }
            }

            long nroretencion = 0;
            
            return true;
        }

        private void LimpiarTextBoxes()
        {

        }

        private List<int> GetListaSeleccionados()
        {
            List<int> result = new List<int>();
            
            foreach (DataGridViewRow row in this.dgvRetenciones.Rows)
            {
                if ((row.Cells[CAMPO_SELECCIONAR].GetType() == typeof(DataGridViewCheckBoxCell)) && (row.Cells[CAMPO_SELECCIONAR].Value != null) && ((bool)row.Cells[CAMPO_SELECCIONAR].Value))
                {
                    result.Add(row.Index);
                }
            }

            this.btnCargarDatosRetencion.Enabled = result.Count > 0;
            return result;
        }
        #endregion Metodos de Apoyo

        #region Metodos sobre Controles
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.ValidarDatosPorcentajesRetencion() && this.ValidarPorcentajes())
                this.CargarRetenciones();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidarPorcentajes()
        {
            using (BerkeDBEntities context = new BerkeDBEntities())
            {
                cr_clienteretencion cr = context.cr_clienteretencion.FirstOrDefault(a => a.cr_clienteid == this.ClienteId);

                if (cr == null)
                {
                    MessageBox.Show("El cliente no posee  información para retenciones. Debe ingresar los datos" + Environment.NewLine +
                                    "en los cuadros de texto de arriba y actualizar la información para que los " + Environment.NewLine +
                                    "montos se muestren en la grilla y puedan ser usados en el recibo.",
                                   "Atención Requerida",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
                    return false;
                }
            }
            return true;
        }

        private void headerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool checkedState = this.headerCheckBox.Checked;

            foreach (DataGridViewRow row in this.dgvRetenciones.Rows)
            {
                row.Cells[CAMPO_SELECCIONAR].Value = checkedState;
            }

            this.btnCargarDatosRetencion.Enabled = this.GetListaSeleccionados().Count > 0;
        }
        #endregion Metodos sobre Controles

        private void fCargarDatosRetencion_AceptarClick(object sender, EventArgs e)
        {
            foreach(int ix in fCargarDatosRetencion.ListaFacturaIx)
            {
                DataGridViewRow row = this.dgvRetenciones.Rows[ix];
                row.Cells[CAMPO_FECHARETENCION].Value = fCargarDatosRetencion.FechaRetencion.ToShortDateString();
                row.Cells[CAMPO_NRORETENCION].Value = fCargarDatosRetencion.NumeroRetencion;
            }
            fCargarDatosRetencion.Close();
        }

        private void btnCargarDatosRetencion_Click(object sender, EventArgs e)
        {
            fCargarDatosRetencion = new FCargarDatosRetencion("Ingresar datos de retención", this.GetListaSeleccionados());
            fCargarDatosRetencion.FormClosed += delegate { fCargarDatosRetencion = null; };
            fCargarDatosRetencion.AceptarClick += fCargarDatosRetencion_AceptarClick;
            fCargarDatosRetencion.ShowDialog();
        }

        private bool ValidarDatosPorcentajesRetencion()
        {
            if (this.txtPorcRetIVA10.Text.Trim() == string.Empty)
            {
                this.txtPorcRetIVA10.Focus();
                MessageBox.Show("Debe ingresar un valor para el porcentaje de retención de IVA 10%",
                               "Atención Requerida",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }

            int porcRetIVA10 = 0;
            if (!int.TryParse(this.txtPorcRetIVA10.Text, out porcRetIVA10))
            {
                this.txtPorcRetIVA10.Focus();
                MessageBox.Show("El porcentaje de retención de IVA 10% debe ser un valor numérico entero.",
                               "Atención Requerida",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }

            if (this.txtPorcRetRenta.Text.Trim() == string.Empty)
            {
                this.txtPorcRetRenta.Focus();
                MessageBox.Show("Debe ingresar un valor para el porcentaje de retención de Renta",
                               "Atención Requerida",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }

            int porcRetRenta = 0;
            if (!int.TryParse(this.txtPorcRetRenta.Text, out porcRetRenta))
            {
                this.txtPorcRetRenta.Focus();
                MessageBox.Show("El porcentaje de retención de Renta debe ser un valor numérico entero.",
                               "Atención Requerida",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }

            if (this.txtNroTimbrado.Text.Trim() == string.Empty)
            {
                this.txtNroTimbrado.Focus();
                MessageBox.Show("Debe ingresar un valor para el porcentaje de retención de Renta",
                               "Atención Requerida",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }

            long nroretencion = 0;
            if (!long.TryParse(this.txtNroTimbrado.Text, out nroretencion))
            {
                this.txtNroTimbrado.Focus();
                MessageBox.Show("El número de timbrado debe ser un valor numérico entero largo.",
                               "Atención Requerida",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void btnActualizarDatosRetTimb_Click(object sender, EventArgs e)
        {
            if (this.ValidarDatosPorcentajesRetencion())
            {
                string message = "";
                string caption = "";
                caption = "Actualización Datos de Retenciones";
                message = "Se actualizará la información de retenciones del cliente ¿Desea continuar?";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBox.Show(message, caption, buttons,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                                new EventHandler(ActualizarDatosRetencionesDialogHandler));
            }
        }

        private void ActualizarDatosRetencionesDialogHandler(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    this.ActualizarDatos();
                }
            }
        }

        private void ActualizarDatos()
        {
            this.GuardarRegistro();
        }

        private void ActualizarGrilla()
        {
            int porcentajeRetIVA10 = this.txtPorcRetIVA10.Text.Trim() == string.Empty
                                        ? 0
                                        : Convert.ToInt32(this.txtPorcRetIVA10.Text);
            int porcentajeRetRenta = this.txtPorcRetRenta.Text.Trim() == string.Empty
                                        ? 0
                                        : Convert.ToInt32(this.txtPorcRetRenta.Text);

            foreach (DataGridViewRow row in this.dgvRetenciones.Rows)
            {
                if (porcentajeRetIVA10 > 0)
                {
                    decimal retIVA10 = (decimal)row.Cells[CAMPO_LIQIVA10].Value * porcentajeRetIVA10 / 100;
                    if (this.MonedaId == GUARANIES_MONEDA_ID)
                        row.Cells[CAMPO_RETENCIONIVA10].Value = decimal.Round(retIVA10, 0, MidpointRounding.AwayFromZero);
                    else row.Cells[CAMPO_RETENCIONIVA10].Value = decimal.Round(retIVA10, 2);
                }
                else row.Cells[CAMPO_RETENCIONIVA10].Value = (decimal)0;

                if (porcentajeRetRenta > 0)
                {
                    decimal retRenta = (decimal)row.Cells[CAMPO_IMPORTECOBRADO].Value * porcentajeRetRenta / 100;
                    if (this.MonedaId == GUARANIES_MONEDA_ID)
                        row.Cells[CAMPO_RETENCIONRENTA].Value = decimal.Round(retRenta, 0, MidpointRounding.AwayFromZero);
                    else row.Cells[CAMPO_RETENCIONRENTA].Value = decimal.Round(retRenta, 2);
                }
                else row.Cells[CAMPO_RETENCIONRENTA].Value = (decimal)0;
            }
            this.CalcularTotalesRetenciones();
        }

        #region CRUD
        private void GuardarRegistro()
        {
            bool success = false;

            cr_clienteretencion cr = null;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        cr = this.guardarClienteRetencion(context);
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
                this.ActualizarGrilla();
                MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region Métodos de Edición de Datos
        private cr_clienteretencion guardarClienteRetencion(BerkeDBEntities context = null)
        {
            cr_clienteretencion cr = context.cr_clienteretencion.FirstOrDefault(a => a.cr_clienteid == this.ClienteId);

            if (cr != null)
            {
                cr.cr_porcentajeiva10 = Convert.ToInt32(this.txtPorcRetIVA10.Text);
                cr.cr_porcentajerenta = Convert.ToInt32(this.txtPorcRetRenta.Text);
                cr.cr_nrotimbrado = Convert.ToInt64(this.txtNroTimbrado.Text);
            }
            else
            {
                cr = new cr_clienteretencion();
                cr.cr_clienteid = this.ClienteId;
                cr.cr_porcentajeiva10 = Convert.ToInt32(this.txtPorcRetIVA10.Text);
                cr.cr_porcentajerenta = Convert.ToInt32(this.txtPorcRetRenta.Text);
                cr.cr_nrotimbrado = Convert.ToInt64(this.txtNroTimbrado.Text);
                context.cr_clienteretencion.Add(cr);
            }

            return cr;
        }
        #endregion Métodos de Edición de Datos
        #endregion CRUD

        private void dgvRetenciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex > -1) && (e.ColumnIndex > -1))
            {
                if (this.dgvRetenciones.Columns[e.ColumnIndex].Name == CAMPO_SELECCIONAR)
                {
                    this.btnCargarDatosRetencion.Enabled = this.GetListaSeleccionados().Count > 0;
                }
            }
        }

        private void txtPorcRetIVA10_Enter(object sender, EventArgs e)
        {
            this.txtPorcRetIVA10.SelectAll();
        }

        private void txtPorcRetRenta_Enter(object sender, EventArgs e)
        {
            this.txtPorcRetRenta.SelectAll();
        }

        private void txtNroTimbrado_Enter(object sender, EventArgs e)
        {
            this.txtNroTimbrado.SelectAll();
        }
    }
}