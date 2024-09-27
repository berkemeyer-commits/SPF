#region Using

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Gateways;

using ModelEF6;
using SPF.Forms;
using SPF.Forms.Base;
using SPF.Types;
using SPF.Base;
using System.Data.Entity;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Dynamic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

using System.Data.SqlClient;
using System.Collections;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text.RegularExpressions;

using Microsoft.Reporting.WebForms;

#endregion

namespace SPF.Forms.UI
{
    public partial class FRealizarCobroRecibo : Form
    {
        #region Constantes
        private const string NOTA_CREDITO_ELECTRONICA = "Nota Crédito Electrónica";
        private const string FACTURA = "Factura";
        
        private const char PAD = '0';
        private const string FORMATO_RECIBO = "{0}-{1}-{2}";
        private const string LOCALHOST = "localhost";
        private const int PAIS_PARAGUAY_ID = 91;

        private const string FORMATO_MONEDA_GUARANIES_GRILLA = "N0";
        private const string FORMATO_MONEDA_OTROS_GRILLA = "N2";
        private const string FORMATO_MONEDA_GUARANIES = "{0:N0}";
        private const string FORMATO_MONEDA_OTROS = "{0:N2}";
        private const int GUARANIES_MONEDA_ID = 3;
        private const string GUARANIES_TEXTO = "guaraníes";
        private const int DOLARES_MONEDA_ID = 2;
        private const string DOLARES_TEXTO = "dólares americanos";
        private const int LIMITE_FACTURAS_POR_RECIBO = 14;
        private const int LIMITE_TRANSF_CHEQUES_POR_RECIBO = 4;
        private const int IDIOMA_ESPANOL = 2;

        private const string CAMPO_FECHA_TRANSFERENCIA = "FechaTransferencia";
        private const string CAMPO_CUENTA_TRANSFERENCIA_ID = "BancoTransferenciaId";
        private const string CAMPO_CUENTA_TRANSFERENCIA_DESCRIP = "BancoTransferenciaDescrip";
        private const string CAMPO_NUMERO_TRANSFERENCIA = "NumeroTransferencia";
        private const string CAMPO_MONTO_GASTO_BANCARIO = "MontoGastoBancario";
        private const string CAMPO_MONTO_TRANSFERENCIA = "MontoTransferencia";
        private const string CAMPO_MONEDA_TRANSFERENCIA_ID = "MonedaTransferenciaId";
        private const string CAMPO_MONEDA_TRANSFERENCIA_ABREV = "MonedaTransferenciaAbrev";
        private const string CAMPO_ELIMINAR_TRANSFERENCIA = "EliminarTransferencia";
        private const string CAMPO_CUENTA_TRANSFERENCIA_PAIS_ID = "PaisId";

        private const string CAMPO_FECHA_CHEQUE = "FechaCheque";
        private const string CAMPO_BANCO_CHEQUE_ID = "BancoChequeId";
        private const string CAMPO_BANCO_CHEQUE_DESCRIP = "BancoChequeDescrip";
        private const string CAMPO_NUMERO_CHEQUE = "NumeroCheque";
        private const string CAMPO_MONTO_CHEQUE = "MontoCheque";
        private const string CAMPO_MONEDA_CHEQUE_ID = "MonedaChequeId";
        private const string CAMPO_MONEDA_CHEQUE_ABREV = "MonedaChequeAbrev";
        private const string CAMPO_ELIMINAR_CHEQUE = "EliminarCheque";

        private const string FACTURAS_CANCELADAS = "FACTURAS CANCELADAS S/ DETALLE. ";
        private const string FACTURAS_PAGOS_PARCIALES = "Pago Parcial Fact: {0}. ";
        #endregion Constantes

        #region Variables
        BerkeDBEntities DBContext;
        private int timbradoReciboID;
        private int monedaID;
        private decimal totalRecibo;
        private int clienteID;
        private List<FacturasParaRecibos> listaFacturas;
        FCargarTransferenciaRecibo fCargarTransferencia;
        FCargarChequeRecibo fCargarCheque;
        FCargarRetencionesRecibo fCargarRetenciones;
        private FormatoNumeroReciboType formatoNumeroRecibo;
        BindingSource bindingSource;
        BindingSource bindingSourceC;
        private bool filaInsertada;
        private int contadorComportamientoRaro;
        string facturasCanceladas = string.Empty;
        string facturasPagosParciales = string.Empty;
        List<FacturasParaRetenciones> listaFacturasRetenciones;
        #endregion Variables

        #region Eventos personalizados
        public event EventHandler CloseClick;
        #endregion Eventos personalizados

        #region Propiedades
        private int TimbradoReciboID
        {
            set { this.timbradoReciboID = value; }
            get { return this.timbradoReciboID; }
        }

        private int ClienteID
        {
            set { this.clienteID = value; }
            get { return this.clienteID; }
        }

        private int MonedaID
        {
            set { this.monedaID = value; }
            get { return this.monedaID; }
        }

        public List<FacturasParaRecibos> ListaFacturas
        {
            get { return this.listaFacturas; }
            set { this.listaFacturas = value; }
        }

        private FormatoNumeroReciboType FormatoNumeroRecibo
        {
            get { return this.formatoNumeroRecibo; }
            set { this.formatoNumeroRecibo = value; }
        }

        private bool FilaInsertada
        {
            set { this.filaInsertada = value; }
            get { return this.filaInsertada; }
        }

        private int ContadorComportamientoRaro
        {
            set { this.contadorComportamientoRaro = value; }
            get { return this.contadorComportamientoRaro; }
        }

        private string FacturasCanceladas
        {
            set { this.facturasCanceladas = value; }
            get { return this.facturasCanceladas; }
        }

        private string FacturasPagosParciales
        {
            set { this.facturasPagosParciales = value; }
            get { return this.facturasPagosParciales; }
        }

        public List<FacturasParaRetenciones> ListaFacturasRetenciones
        {
            set { this.listaFacturasRetenciones = value; }
            get { return this.listaFacturasRetenciones; }
        }

        private decimal TotalRecibo
        {
            set { this.totalRecibo = value; }
            get { return this.totalRecibo; }
        }
        #endregion Propiedades

        #region Métodos de Inicio
        public FRealizarCobroRecibo()
        {
            InitializeComponent();
        }

        public FRealizarCobroRecibo(BerkeDBEntities context, string titulo, List<FacturasParaRecibos> listaFacturas, int timbradoReciboID)
        {
            InitializeComponent();
            this.DBContext = context;
            this.Text = titulo;
            this.ListaFacturas = listaFacturas;
            this.TimbradoReciboID = timbradoReciboID;

            this.formatoNumeroRecibo = new FormatoNumeroReciboType();

            if (this.ListaFacturas.First().MonedaId == GUARANIES_MONEDA_ID)
            {
                this.FormatoNumeroRecibo.General = FORMATO_MONEDA_GUARANIES;
                this.FormatoNumeroRecibo.Grilla = FORMATO_MONEDA_GUARANIES_GRILLA;
            }
            else
            {
                this.FormatoNumeroRecibo.General = FORMATO_MONEDA_OTROS;
                this.FormatoNumeroRecibo.Grilla = FORMATO_MONEDA_OTROS_GRILLA;
            }
        }

        private void FRealizarCobroRecibo_Load(object sender, EventArgs e)
        {
            this.CerarTextBoxes();
            this.ClienteID = this.ListaFacturas.First().ClienteId.Value;
            string clienteNombre = this.ListaFacturas.First().ClienteNombre + " (" + this.ListaFacturas.First().ClienteId + ")";
            this.txtCliente.Text = clienteNombre;
            this.toolTip1.SetToolTip(this.txtCliente, clienteNombre);
            this.MonedaID = this.ListaFacturas.First().MonedaId;
            this.txtMoneda.Text = this.ListaFacturas.First().MonedaDescrip;
            this.txtUsuario.Text = VWGContext.Current.Session["NombreUsuario"].ToString();

            decimal totalNC = this.GetTotalNC();
            //decimal totalRecibo = this.GetTotalRecibo() - this.GetTotalNC();
            this.TotalRecibo = this.GetTotalRecibo() - this.GetTotalNC();
            this.txtTotalRecibo.Text = string.Format(this.FormatoNumeroRecibo.General, this.TotalRecibo);
            this.txtTotalDebitos.Text = string.Format(this.FormatoNumeroRecibo.General, totalNC);
            this.txtMontoNC.Text = string.Format(this.FormatoNumeroRecibo.General, totalNC);
            this.txtEfectivo.Text = this.txtTotalRecibo.Text;
            
            //string concepto = this.FacturasCanceladas != string.Empty ? string.Format(FACTURAS_CANCELADAS, this.FacturasCanceladas) : string.Empty;
            string concepto = this.FacturasCanceladas != string.Empty ? FACTURAS_CANCELADAS.ToUpper() : string.Empty;
            concepto += this.facturasPagosParciales != string.Empty ? string.Format(FACTURAS_PAGOS_PARCIALES.ToUpper(), this.facturasPagosParciales) : string.Empty;
            this.txtConcepto.Text = concepto;

            ti_timbrado timbrado = this.DBContext.ti_timbrado.First(a => a.ti_timbradoid == this.timbradoReciboID);
            this.txtNroReciboSuc.Text = timbrado.ti_serie.PadLeft(3, PAD);
            this.txtNroReciboSerie.Text = timbrado.ti_sucursal.PadLeft(3, PAD);
            this.txtNroRecibo.Text = ("0").ToString().PadLeft(7, PAD);

            #region Datos Transferencias
            this.dgvTransferencias.AutoGenerateColumns = false;
            DatosTransferenciaReciboType row = this.GetFilaEnBlancoGrillaTransferencia();
            List<DatosTransferenciaReciboType> listaTransferencias = new List<DatosTransferenciaReciboType>();
            bindingSource = new BindingSource();
            bindingSource.DataSource = listaTransferencias;
            this.dgvTransferencias.DataSource = bindingSource;
            this.FormatearGrillaTransferencias();
            #endregion Datos Transferencias

            #region Datos Cheques
            this.dgvCheques.AutoGenerateColumns = false;
            DatosChequeReciboType rowC = this.GetFilaEnBlancoGrillaCheque();
            List<DatosChequeReciboType> listaCheques = new List<DatosChequeReciboType>();
            bindingSourceC = new BindingSource();
            bindingSourceC.DataSource = listaCheques;
            this.dgvCheques.DataSource = bindingSourceC;
            this.FormatearGrillaCheques();

            #endregion Datos Cheques

            this.FilaInsertada = false;
            this.ContadorComportamientoRaro = 0;
            this.btnAceptar.Visible = true;
        }

        private void FormatearGrillaTransferencias()
        {
            //this.dgvTransferencias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTransferencias.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Pixel);
            this.dgvTransferencias.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dgvTransferencias.DefaultCellStyle.Font = new Font("Arial", 10F, GraphicsUnit.Pixel);
            this.dgvTransferencias.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvTransferencias.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            this.dgvTransferencias.ItemsPerPage = 4;
            this.dgvTransferencias.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.dgvTransferencias.MultiSelect = false;
            //this.dgvTransferencias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransferencias.AllowUserToAddRows = false;
            this.dgvTransferencias.AllowUserToDeleteRows = true;
            this.dgvTransferencias.AllowUserToResizeRows = true;
            this.dgvTransferencias.AllowUserToOrderColumns = false;
            this.dgvTransferencias.RowHeadersWidth = 20;
            this.dgvTransferencias.ScrollBars = ScrollBars.None;

            foreach (DataGridViewColumn col in this.dgvTransferencias.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            int displayIndex = 0;

            #region Columna Imagen
            DataGridViewCellStyle iStyle = new DataGridViewCellStyle();
            iStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            iStyle.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Pixel);

            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol.HeaderText = "";
            imgCol.HeaderCell.Style.ForeColor = Color.Transparent;
            imgCol.Name = CAMPO_ELIMINAR_TRANSFERENCIA;
            imgCol.DefaultCellStyle = iStyle;
            imgCol.Image = this.btnEliminarTransferencia.Image;
            imgCol.Width = 20;
            imgCol.ToolTipText = "Eliminar Transferencia";
            this.dgvTransferencias.Columns.Insert(displayIndex, imgCol);
            displayIndex++;
            #endregion Columna Imagen

            DataGridViewTextBoxColumn fechaTransferencia = new DataGridViewTextBoxColumn();
            fechaTransferencia.Name = CAMPO_FECHA_TRANSFERENCIA;
            fechaTransferencia.DataPropertyName = CAMPO_FECHA_TRANSFERENCIA;
            fechaTransferencia.Visible = true;
            fechaTransferencia.DisplayIndex = displayIndex;
            fechaTransferencia.HeaderText = "Fecha";
            fechaTransferencia.DefaultCellStyle.Format = "dd/MM/yyyy";
            fechaTransferencia.Width = 80;
            this.dgvTransferencias.Columns.Add(fechaTransferencia);
            displayIndex++;

            DataGridViewTextBoxColumn cuentaTransferenciaId = new DataGridViewTextBoxColumn();
            cuentaTransferenciaId.Name = CAMPO_CUENTA_TRANSFERENCIA_ID;
            cuentaTransferenciaId.DataPropertyName = CAMPO_CUENTA_TRANSFERENCIA_ID;
            cuentaTransferenciaId.Visible = false;
            cuentaTransferenciaId.DisplayIndex = displayIndex;
            this.dgvTransferencias.Columns.Add(cuentaTransferenciaId);
            displayIndex++;

            DataGridViewTextBoxColumn cuentaPaisId = new DataGridViewTextBoxColumn();
            cuentaPaisId.Name = CAMPO_CUENTA_TRANSFERENCIA_PAIS_ID;
            cuentaPaisId.DataPropertyName = CAMPO_CUENTA_TRANSFERENCIA_PAIS_ID;
            cuentaPaisId.Visible = false;
            cuentaPaisId.DisplayIndex = displayIndex;
            this.dgvTransferencias.Columns.Add(cuentaPaisId);
            displayIndex++;

            DataGridViewTextBoxColumn bancoTransferencia = new DataGridViewTextBoxColumn();
            bancoTransferencia.Name = CAMPO_CUENTA_TRANSFERENCIA_DESCRIP;
            bancoTransferencia.DataPropertyName = CAMPO_CUENTA_TRANSFERENCIA_DESCRIP;
            bancoTransferencia.Visible = true;
            bancoTransferencia.DisplayIndex = displayIndex;
            bancoTransferencia.HeaderText = "Cuenta";
            bancoTransferencia.Width = 120;
            this.dgvTransferencias.Columns.Add(bancoTransferencia);
            displayIndex++;

            DataGridViewTextBoxColumn numeroTransferencia = new DataGridViewTextBoxColumn();
            numeroTransferencia.Name = CAMPO_NUMERO_TRANSFERENCIA;
            numeroTransferencia.DataPropertyName = CAMPO_NUMERO_TRANSFERENCIA;
            numeroTransferencia.Visible = true;
            numeroTransferencia.DisplayIndex = displayIndex;
            numeroTransferencia.HeaderText = "Número";
            numeroTransferencia.Width = 70;
            this.dgvTransferencias.Columns.Add(numeroTransferencia);
            displayIndex++;

            DataGridViewTextBoxColumn gastoBancario = new DataGridViewTextBoxColumn();
            gastoBancario.Name = CAMPO_MONTO_GASTO_BANCARIO;
            gastoBancario.DataPropertyName = CAMPO_MONTO_GASTO_BANCARIO;
            gastoBancario.Visible = true;
            gastoBancario.DisplayIndex = displayIndex;
            gastoBancario.HeaderText = "Gasto";
            gastoBancario.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gastoBancario.DefaultCellStyle.Format = this.FormatoNumeroRecibo.Grilla;
            gastoBancario.Width = 65;
            this.dgvTransferencias.Columns.Add(gastoBancario);
            displayIndex++;

            DataGridViewTextBoxColumn importeTransferencia = new DataGridViewTextBoxColumn();
            importeTransferencia.Name = CAMPO_MONTO_TRANSFERENCIA;
            importeTransferencia.DataPropertyName = CAMPO_MONTO_TRANSFERENCIA;
            importeTransferencia.Visible = true;
            importeTransferencia.DisplayIndex = displayIndex;
            importeTransferencia.HeaderText = "Monto";
            importeTransferencia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            importeTransferencia.DefaultCellStyle.Format = this.FormatoNumeroRecibo.Grilla;
            importeTransferencia.Width = 65;
            this.dgvTransferencias.Columns.Add(importeTransferencia);
            displayIndex++;
        }

        private void FormatearGrillaCheques()
        {
            //this.dgvCheques.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCheques.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Pixel);
            this.dgvCheques.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dgvCheques.DefaultCellStyle.Font = new Font("Arial", 10F, GraphicsUnit.Pixel);
            this.dgvCheques.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvCheques.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            this.dgvCheques.ItemsPerPage = 4;
            this.dgvCheques.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.dgvCheques.MultiSelect = false;
            //this.dgvCheques.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCheques.AllowUserToAddRows = false;
            this.dgvCheques.AllowUserToDeleteRows = true;
            this.dgvCheques.AllowUserToResizeRows = true;
            this.dgvCheques.AllowUserToOrderColumns = false;
            this.dgvCheques.RowHeadersWidth = 20;
            this.dgvCheques.ScrollBars = ScrollBars.None;

            foreach (DataGridViewColumn col in this.dgvCheques.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            int displayIndex = 0;

            #region Columna Imagen
            DataGridViewCellStyle iStyle = new DataGridViewCellStyle();
            iStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            iStyle.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Pixel);

            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol.HeaderText = "";
            imgCol.HeaderCell.Style.ForeColor = Color.Transparent;
            imgCol.Name = CAMPO_ELIMINAR_CHEQUE;
            imgCol.DefaultCellStyle = iStyle;
            imgCol.Image = this.btnEliminarTransferencia.Image;
            imgCol.Width = 20;
            imgCol.ToolTipText = "Eliminar Cheque";
            this.dgvCheques.Columns.Insert(displayIndex, imgCol);
            displayIndex++;
            #endregion Columna Imagen

            DataGridViewTextBoxColumn fechaCheque = new DataGridViewTextBoxColumn();
            fechaCheque.Name = CAMPO_FECHA_CHEQUE;
            fechaCheque.DataPropertyName = CAMPO_FECHA_CHEQUE;
            fechaCheque.Visible = true;
            fechaCheque.DisplayIndex = displayIndex;
            fechaCheque.HeaderText = "Fecha";
            fechaCheque.DefaultCellStyle.Format = "dd/MM/yyyy";
            fechaCheque.Width = 80;
            this.dgvCheques.Columns.Add(fechaCheque);
            displayIndex++;

            DataGridViewTextBoxColumn bancoCheque = new DataGridViewTextBoxColumn();
            bancoCheque.Name = CAMPO_BANCO_CHEQUE_DESCRIP;
            bancoCheque.DataPropertyName = CAMPO_BANCO_CHEQUE_DESCRIP;
            bancoCheque.Visible = true;
            bancoCheque.DisplayIndex = displayIndex;
            bancoCheque.HeaderText = "Banco";
            bancoCheque.Width = 160;
            this.dgvCheques.Columns.Add(bancoCheque);
            displayIndex++;

            DataGridViewTextBoxColumn numeroCheque = new DataGridViewTextBoxColumn();
            numeroCheque.Name = CAMPO_NUMERO_CHEQUE;
            numeroCheque.DataPropertyName = CAMPO_NUMERO_CHEQUE;
            numeroCheque.Visible = true;
            numeroCheque.DisplayIndex = displayIndex;
            numeroCheque.HeaderText = "Número";
            numeroCheque.Width = 70;
            this.dgvCheques.Columns.Add(numeroCheque);
            displayIndex++;

            DataGridViewTextBoxColumn importeCheque = new DataGridViewTextBoxColumn();
            importeCheque.Name = CAMPO_MONTO_CHEQUE;
            importeCheque.DataPropertyName = CAMPO_MONTO_CHEQUE;
            importeCheque.Visible = true;
            importeCheque.DisplayIndex = displayIndex;
            importeCheque.HeaderText = "Monto";
            importeCheque.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            importeCheque.DefaultCellStyle.Format = this.FormatoNumeroRecibo.Grilla;
            importeCheque.Width = 65;
            this.dgvCheques.Columns.Add(importeCheque);
            displayIndex++;
        }
        #endregion Métodos de Inicio

        #region Métodos Locales
        private List<ReciboFacturasType> GetFacturasParaRecibo()
        {
            List<ReciboFacturasType> reciboFacturas = new List<ReciboFacturasType>();
            //string formatoMoneda = Convert.ToInt32(this.txtMoneda.Text) == GUARANIES_MONEDA_ID ? FORMATO_MONEDA_GUARANIES : FORMATO_MONEDA_OTROS;

            for (int i = 0; i < LIMITE_FACTURAS_POR_RECIBO; i++)
            {
                if (i < this.listaFacturas.Count)
                {
                    //if (this.ListaFacturas[i].TipoDocumento != NOTA_CREDITO_ELECTRONICA)
                    //{
                    //    reciboFacturas.Add(new ReciboFacturasType()
                    //    {
                    //        ID = i + 1,
                    //        NroFactura = this.ListaFacturas[i].NroFactura,
                    //        Importe = string.Format(this.formatoNumeroRecibo.General, this.ListaFacturas[i].ImporteCobrado)
                    //    });
                    //}
                    string importe = string.Format(this.formatoNumeroRecibo.General, this.ListaFacturas[i].ImporteCobrado);
                    if (this.ListaFacturas[i].TipoDocumento == NOTA_CREDITO_ELECTRONICA)
                    {
                        importe = "-" + string.Format(this.formatoNumeroRecibo.General, this.ListaFacturas[i].Total);
                    }
                    reciboFacturas.Add(new ReciboFacturasType()
                    {
                        ID = i + 1,
                        NroFactura = this.ListaFacturas[i].NroFactura,
                        Importe = importe
                    });
                }
                else
                {
                    reciboFacturas.Add(new ReciboFacturasType()
                    {
                        ID = i + 1,
                        NroFactura = "--",
                        Importe = "--"
                    });
                }
            }

            return reciboFacturas;
        }

        private List<ReciboRetencionesType> GetRetencionesParaRecibo()
        {
            List<ReciboRetencionesType> reciboRetenciones = new List<ReciboRetencionesType>();

            decimal totalRetenciones = Convert.ToDecimal(this.txtRetencionIVA10.Text) + Convert.ToDecimal(this.txtRetencionRenta.Text);

            reciboRetenciones.Add(new ReciboRetencionesType()
            {
                ImporteRetencion = totalRetenciones > 0 
                                    ? string.Format(this.FormatoNumeroRecibo.General, totalRetenciones) 
                                    : "--"
            });

            return reciboRetenciones;
        }

        private List<DatosTransfenciaReciboReporte> GetDatosTransferenciaReciboReporte()
        {
            List<DatosTransfenciaReciboReporte> data = new List<DatosTransfenciaReciboReporte>();

            int c = 1;
            foreach (DataGridViewRow row in this.dgvTransferencias.Rows)
            {
                if ((int)row.Cells[CAMPO_CUENTA_TRANSFERENCIA_PAIS_ID].Value == PAIS_PARAGUAY_ID)
                {
                    DatosTransfenciaReciboReporte transf = new DatosTransfenciaReciboReporte();
                    transf.ID = c;
                    transf.FechaTransferencia = row.Cells[CAMPO_FECHA_TRANSFERENCIA].Value.ToString();
                    transf.BancoTransferencia = row.Cells[CAMPO_CUENTA_TRANSFERENCIA_DESCRIP].Value.ToString();
                    transf.NroTransferencia = row.Cells[CAMPO_NUMERO_TRANSFERENCIA].Value.ToString();
                    //decimal totalTransferencia = (decimal)row.Cells[CAMPO_MONTO_GASTO_BANCARIO].Value + (decimal)row.Cells[CAMPO_MONTO_TRANSFERENCIA].Value;
                    //decimal totalTransferencia = (decimal)row.Cells[CAMPO_MONTO_TRANSFERENCIA].Value;
                    transf.MontoTransferencia = string.Format(this.FormatoNumeroRecibo.General, (decimal)row.Cells[CAMPO_MONTO_TRANSFERENCIA].Value); //string.Format(this.FormatoNumeroRecibo.General, totalTransferencia);
                    data.Add(transf);
                    c++;
                }
            }

            //if (this.dgvTransferencias.RowCount < LIMITE_TRANSF_CHEQUES_POR_RECIBO)
            //{
            //    for (int i = c - 1; i <= LIMITE_TRANSF_CHEQUES_POR_RECIBO; i++)
            //    {
            //        DatosTransfenciaReciboReporte transf = new DatosTransfenciaReciboReporte();
            //        transf.ID = i;
            //        transf.FechaTransferencia = "--";
            //        transf.BancoTransferencia = "--";
            //        transf.NroTransferencia = "--";
            //        transf.MontoTransferencia = "--";
            //        data.Add(transf);
            //    }
            //}

            return data;
        }

        private List<DatosChequeReciboReporte> GetDatosChequeReciboReporte()
        {
            List<DatosChequeReciboReporte> data = new List<DatosChequeReciboReporte>();

            int c = 1;
            foreach (DataGridViewRow row in this.dgvCheques.Rows)
            {
                DatosChequeReciboReporte cheq = new DatosChequeReciboReporte();
                cheq.ID = c;
                cheq.FechaCheque = row.Cells[CAMPO_FECHA_CHEQUE].Value.ToString();
                cheq.CargoBancoCheque = row.Cells[CAMPO_BANCO_CHEQUE_DESCRIP].Value.ToString();
                cheq.NroCheque = row.Cells[CAMPO_NUMERO_CHEQUE].Value.ToString();
                //decimal montoCheque = (decimal)row.Cells[CAMPO_MONTO_CHEQUE].Value;
                cheq.MontoCheque = string.Format(this.FormatoNumeroRecibo.General, (decimal)row.Cells[CAMPO_MONTO_CHEQUE].Value);
                data.Add(cheq);
                c++;
            }

            //if (this.dgvCheques.RowCount < LIMITE_TRANSF_CHEQUES_POR_RECIBO)
            //{
            //    for (int i = c - 1; i <= LIMITE_TRANSF_CHEQUES_POR_RECIBO; i++)
            //    {
            //        DatosChequeReciboReporte cheq = new DatosChequeReciboReporte();
            //        cheq.ID = c;
            //        cheq.FechaCheque = "--";
            //        cheq.CargoBancoCheque = "--";
            //        cheq.NroCheque = "--";
            //        cheq.MontoCheque = "--";
            //        data.Add(cheq);
            //    }
            //}

            return data;
        }

        private List<DatosReciboType> GetDatosRecibo()
        {
            DatosReciboType datosRecibo = new DatosReciboType();
            datosRecibo.AbrevMoneda = this.ListaFacturas.First().MonedaAbrev;
            datosRecibo.TotalRecibo = this.txtTotalRecibo.Text;
            datosRecibo.ClienteNombre = this.ListaFacturas.First().ClienteNombre;
            datosRecibo.RUC = this.ListaFacturas.First().RUC;
            datosRecibo.NroRecibo = this.txtNroReciboSuc.Text + "-" + this.txtNroReciboSerie.Text + "-" + this.txtNroRecibo.Text;

            string descripMoneda = string.Empty;

            switch (this.ListaFacturas.First().MonedaId)
            {
                case DOLARES_MONEDA_ID:
                    descripMoneda = DOLARES_TEXTO;
                    break;
                case GUARANIES_MONEDA_ID:
                    descripMoneda = GUARANIES_TEXTO;
                    break;
                default:
                    descripMoneda = this.ListaFacturas.First().MonedaDescrip; 
                    break;
            }

            datosRecibo.DescripMoneda = descripMoneda;
            datosRecibo.TotalLetras = this.TruncarTexto(descripMoneda + " " + this.ObtenerTotalEnLetras(IDIOMA_ESPANOL,
                                                                                                        this.ListaFacturas.First().MonedaId,
                                                                                                        this.txtTotalRecibo.Text,
                                                                                                        descripMoneda,
                                                                                                        false), 47)
                                                                                                        .Replace(descripMoneda, string.Empty)
                                                                                                        .TrimStart()
                                                                                                        .TrimEnd();

            datosRecibo.Concepto = this.TruncarTexto(this.txtConcepto.Text.ToUpper(), 45).TrimStart().TrimEnd();
            datosRecibo.Efectivo = Convert.ToDecimal(this.txtEfectivo.Text) > 0 ? this.txtEfectivo.Text : string.Empty;
            datosRecibo.Cheque = Convert.ToDecimal(this.txtCheque.Text) > 0;
            //datosRecibo.Transferencia = Convert.ToDecimal(this.txtTransferencia.Text) > 0;
            //datosRecibo.NroCheque = "123456789";
            //datosRecibo.BancoCheque = "Banco GNB Paraguay";
            //datosRecibo.NroTransferencia = "123456789";
            datosRecibo.FechaRecibo = this.dtpFechaRecibo.Value.ToShortDateString();
            datosRecibo.ElaboradoPor = this.txtUsuario.Text;
            List<DatosReciboType> result = new List<DatosReciboType>();
            result.Add(datosRecibo);

            return result;
        }

        private string TruncarTexto(string texto, int longitud = 52, int longitudMax = 55)
        {
            if (texto.Length <= longitud)
                return texto;

            string primeraParte = texto.Substring(0, longitud);
            int i = 0;
            for(i = longitud-1; i >= 0; i--) 
            {
                if (Char.IsWhiteSpace(primeraParte[i]))
                    break;
            }

            int longitudSegundaLinea = texto.Length - i - 1 > longitudMax ? longitudMax : texto.Length - i - 1;
            
            return texto.Substring(0, i) + "<br><br>" + texto.Substring(i+1, longitudSegundaLinea);
        }

        private string ObtenerTotalEnLetras(int idiomaID, int monedaID, string montoTotal, string monedaDescrip, bool mostrarDescripMoneda = true)
        {
            decimal total = Convert.ToDecimal(montoTotal);
            string totalEnLetras = "";

            if (idiomaID == IDIOMA_ESPANOL)
            {
                Numalet let = new Numalet();
                let.ConvertirDecimales = false;
                let.Decimales = 0;

                int number = (int)Math.Truncate(total);
                decimal decimalPart = total - number;
                if (decimalPart > 0)
                {
                    let.ConvertirDecimales = true;
                    let.Decimales = 2;
                }

                if (mostrarDescripMoneda)
                {
                    if (monedaID == DOLARES_MONEDA_ID)
                        totalEnLetras = let.ToCustomCardinal(total) + " " + monedaDescrip;
                    else
                        totalEnLetras = monedaDescrip + " " + let.ToCustomCardinal(total);
                }
                else totalEnLetras = let.ToCustomCardinal(total);

                let = null;
            }
            else
            {
                if (mostrarDescripMoneda)
                {
                    if (monedaID == DOLARES_MONEDA_ID)
                        totalEnLetras = this.NumberToText(total) + " " + monedaDescrip;
                    else
                        totalEnLetras = monedaDescrip + " " + this.NumberToText(total);
                }
                else totalEnLetras = this.NumberToText(total);
            }

            return totalEnLetras.ToUpper();
        }

        #region Convertir Números a Texto
        public string NumberToText(decimal inputDecimal, bool isUK = true)
        {
            int number = (int)Math.Truncate(inputDecimal);
            decimal decimalPart = inputDecimal - number;

            string decimalPartString = "";
            if (decimalPart > 0)
                decimalPartString += " WITH " + this.NumberToText(decimalPart * 100);

            if (number == 0) return "Zero";
            string and = isUK ? "and " : ""; // deals with UK or US numbering
            if (number == -2147483648) return "Minus Two Billion One Hundred " + and +
            "Forty Seven Million Four Hundred " + and + "Eighty Three Thousand " +
            "Six Hundred " + and + "Forty Eight";
            int[] num = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (number < 0)
            {
                sb.Append("Minus ");
                number = -number;
            }

            //string[] words0 = new string[10];


            string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };
            string[] words1 = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };
            string[] words2 = { "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };
            string[] words3 = { "Thousand ", "Million ", "Billion " };

            num[0] = number % 1000;           // units
            num[1] = number / 1000;
            num[2] = number / 1000000;
            num[1] = num[1] - 1000 * num[2];  // thousands
            num[3] = number / 1000000000;     // billions
            num[2] = num[2] - 1000 * num[3];  // millions
            for (int i = 3; i > 0; i--)
            {
                if (num[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (int i = first; i >= 0; i--)
            {
                if (num[i] == 0) continue;
                u = num[i] % 10;              // ones
                t = num[i] / 10;
                h = num[i] / 100;             // hundreds
                t = t - 10 * h;               // tens
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    if (h > 0 || i < first) sb.Append(and);
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }
            return sb.ToString().TrimEnd() + decimalPartString;
        }
        #endregion Convertir Números a Texto

        private string GetNroRecibo()
        {
            return string.Format(FORMATO_RECIBO, this.txtNroReciboSuc.Text, this.txtNroReciboSerie.Text, this.txtNroRecibo.Text);
        }

        #region CRUD
        private void GuardarRegistro()
        {
            bool success = false;
            string nrorecibo = string.Empty;
            //pp_pagopresupuesto pp = null;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        //Guardar Recibo (pp_pagopresupuesto)
                        nrorecibo = this.guardarRecibo(context);
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
                this.btnAceptar.Visible = false;
                this.txtNroRecibo.Text = nrorecibo.Split('-')[2];
                this.GenerarReporte();
                //MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        #region Métodos de Edición de Datos
        private string guardarRecibo(BerkeDBEntities context = null)
        {
            #region Obtener nro de recibo y actualizar correlatividad
            long nroreciboCorr = context.nf_numeracionfactura
                            .First(a => a.nf_timbradoid == this.TimbradoReciboID)
                            .nf_ultnrofactura + 1;
            string nrorecibo = string.Format(FORMATO_RECIBO, this.txtNroReciboSuc.Text, this.txtNroReciboSerie.Text, nroreciboCorr.ToString().PadLeft(7, PAD));
            context.nf_numeracionfactura
                            .First(a => a.nf_timbradoid == this.TimbradoReciboID)
                            .nf_ultnrofactura = nroreciboCorr;
            context.SaveChanges();
            #endregion Obtener nro de recibo y actualizar correlatividad


            re_recibo re = new re_recibo();
            re.re_fecha = this.dtpFechaRecibo.Value;
            re.re_numero = nrorecibo;
            re.re_clienteid = this.ClienteID;
            re.re_monedaid = this.MonedaID;
            re.re_totalrecibo = Convert.ToDecimal(this.txtTotalRecibo.Text);
            re.re_totalnc = Convert.ToDecimal(this.txtMontoNC.Text);
            re.re_montoret10 = Convert.ToDecimal(this.txtRetencionIVA10.Text);
            re.re_montoretrenta = Convert.ToDecimal(this.txtRetencionRenta.Text);
            re.re_totaltransf = Convert.ToDecimal(this.txtTransferencia.Text);
            re.re_totalgastos = Convert.ToDecimal(this.txtGastosBancarios.Text);
            re.re_totalcheques = Convert.ToDecimal(this.txtCheque.Text);
            re.re_totalefectivo = Convert.ToDecimal(this.txtEfectivo.Text);
            re.re_concepto = this.txtConcepto.Text;
            re.re_usuario = VWGContext.Current.Session["WindowsUser"].ToString();
            context.re_recibo.Add(re);
            context.SaveChanges();
            int reciboid = re.re_reciboid;

            foreach (FacturasParaRecibos row in this.ListaFacturas)
            {
                List<pc_presupuestocab> listaPresup = (from pc in context.pc_presupuestocab
                                                       join fpd in context.fpd_facturapresupuestodet
                                                       on pc.pc_presupuestocabid equals fpd.fpd_presupuestocabid
                                                       where fpd.fpd_facturapresupuestocabid == row.FacturaPresupuestoCabId
                                                       select pc)
                                                      .ToList();
                //Pago presupuestos: pp_pagopresupuesto
                decimal importe = row.ImporteCobrado.Value;
                foreach (pc_presupuestocab pc in listaPresup)
                {
                    pp_pagopresupuesto pp = new pp_pagopresupuesto();
                    pp.pp_presupuestocabid = pc.pc_presupuestocabid;
                    pp.pp_monedaid = this.MonedaID;
                    pp.pp_fechapago = this.dtpFechaRecibo.Value;
                    pp.pp_montopago = importe >= pc.pc_saldo ? pc.pc_saldo : importe;
                    pp.pp_referencia = this.txtConcepto.Text;
                    pp.pp_fecharecibo = this.dtpFechaRecibo.Value;
                    pp.pp_nrorecibo = nrorecibo;
                    pp.pp_reciboid = reciboid;
                    context.pp_pagopresupuesto.Add(pp);
                    context.SaveChanges();
                    importe = importe - pc.pc_saldo;
                }
                //rf_recibofactura
                rf_recibofactura rf = new rf_recibofactura();
                rf.rf_facturacabid = row.FacturaCabId;
                rf.rf_reciboid = reciboid;
                rf.rf_montopagado = row.ImporteCobrado.Value;
                context.rf_recibofactura.Add(rf);
                context.SaveChanges();
            }
            //Transferencias
            if (this.dgvTransferencias.RowCount > 0)
            {
                foreach (DataGridViewRow rowTransf in this.dgvTransferencias.Rows)
                {
                    rt_recibotransf rt = new rt_recibotransf();
                    rt.rt_reciboid = reciboid;
                    rt.rt_fechatransf = Convert.ToDateTime(rowTransf.Cells[CAMPO_FECHA_TRANSFERENCIA].Value);
                    rt.rt_cuentabancoid = (int)rowTransf.Cells[CAMPO_CUENTA_TRANSFERENCIA_ID].Value;
                    rt.rt_numero = rowTransf.Cells[CAMPO_NUMERO_TRANSFERENCIA].Value.ToString();
                    rt.rt_montogasto = (decimal)rowTransf.Cells[CAMPO_MONTO_GASTO_BANCARIO].Value;
                    rt.rt_montotransf = (decimal)rowTransf.Cells[CAMPO_MONTO_TRANSFERENCIA].Value;
                    context.rt_recibotransf.Add(rt);
                    context.SaveChanges();
                }
            }

            //Cheques
            if (this.dgvCheques.RowCount > 0)
            {
                foreach (DataGridViewRow rowCheq in this.dgvCheques.Rows)
                {
                    rch_recibocheque rch = new rch_recibocheque();
                    rch.rch_reciboid = reciboid;
                    rch.rch_fechacheque = Convert.ToDateTime(rowCheq.Cells[CAMPO_FECHA_CHEQUE].Value);
                    rch.rch_bancoid = (int)rowCheq.Cells[CAMPO_BANCO_CHEQUE_ID].Value;
                    rch.rch_numero = rowCheq.Cells[CAMPO_NUMERO_CHEQUE].Value.ToString();
                    rch.rch_monto = (decimal)rowCheq.Cells[CAMPO_MONTO_CHEQUE].Value;
                    context.rch_recibocheque.Add(rch);
                    context.SaveChanges();
                }
            }

            //Retenciones
            if (this.ListaFacturasRetenciones != null)
            {
                foreach (FacturasParaRetenciones rowRet in this.ListaFacturasRetenciones)
                {
                    rr_reciboretencion rr = new rr_reciboretencion();
                    rr.rr_reciboid = reciboid;
                    rr.rr_facturaid = rowRet.FacturaCabId;
                    rr.rr_numero = rowRet.NroRetencion;
                    rr.rr_fecharetencion = Convert.ToDateTime(rowRet.FechaRetencion);
                    rr.rr_montoretencioniva10 = rowRet.RetencionIVA10;
                    rr.rr_montoretencionrenta = rowRet.RetencionRenta;
                    context.rr_reciboretencion.Add(rr);
                    context.SaveChanges();
                }
            }

            return nrorecibo;
        }
        #endregion Métodos de Edición de Datos
        #endregion CRUD

        private void GenerarReporte()
        {
            string numeroRecibo = this.GetNroRecibo();
            string pdfName = numeroRecibo + ".pdf";
            this.OpenPdfInBrowser(this.GenerarPDF(), pdfName);
        }

        private byte[] GenerarPDF()
        {
            //string reportPath = @"Reportes\RepRecibo.rdlc";
            string reportPath = @"Reportes\Recibo de Dinero.rdlc";

            LocalReport report = new LocalReport();
            report.ReportPath = reportPath;

            //report.DisplayName = "Recibo de Dinero N° " + numeroRecibo;
            report.DataSources.Add(new ReportDataSource("DataSet1", this.GetFacturasParaRecibo()));
            report.DataSources.Add(new ReportDataSource("DataSet2", this.GetRetencionesParaRecibo()));
            report.DataSources.Add(new ReportDataSource("DataSet3", this.GetDatosRecibo()));
            report.DataSources.Add(new ReportDataSource("DataSet4", this.GetDatosTransferenciaReciboReporte()));
            report.DataSources.Add(new ReportDataSource("DataSet5", this.GetDatosChequeReciboReporte()));

            byte[] bytes;
            string mimeType, encoding, fileNameExtension;
            string[] streamIds;
            Warning[] warnings;

            // Renderizar el reporte
            bytes = report.Render(
                "PDF", null, out mimeType, out encoding, out fileNameExtension,
                out streamIds, out warnings);

            return bytes;
        }

        public void OpenPdfInBrowser(byte[] pdfBytes, string fileName)
        {
            string specialpath = Context.HttpContext.Request.Url.Authority.IndexOf(LOCALHOST) > -1 ? String.Empty : @"\" + Context.HttpContext.Request.ApplicationPath;
            string tempFilePath = VWGContext.Current.Server.MapPath(specialpath +
                                                            @"\Resources\UserData\" + VWGContext.Current.Session["WindowsUser"].ToString() + @"\") +
                                                            fileName;

            
            File.WriteAllBytes(tempFilePath, pdfBytes);
            string pdfUrl = @"http://" + Context.HttpContext.Request.Url.Authority + @"/Resources/UserData/" + VWGContext.Current.Session["WindowsUser"].ToString() + @"/" + fileName;
            LinkParameters linkParameters = new LinkParameters();
            linkParameters.Target = "_blank";
            
            Link.Open(pdfUrl, linkParameters);
        }

        private void CerarTextBoxes()
        {
            this.txtRetencionIVA10.Text = string.Format(this.FormatoNumeroRecibo.General, 0);
            this.txtRetencionIVA5.Text = string.Format(this.FormatoNumeroRecibo.General, 0);
            this.txtRetencionLey2051.Text = string.Format(this.FormatoNumeroRecibo.General, 0);
            this.txtRetencionRenta.Text = string.Format(this.FormatoNumeroRecibo.General, 0);
            this.txtTransferencia.Text = string.Format(this.FormatoNumeroRecibo.General, 0);
            this.txtGastosBancarios.Text = string.Format(this.FormatoNumeroRecibo.General, 0);
            this.txtEfectivo.Text = string.Format(this.FormatoNumeroRecibo.General, 0);
            this.txtCheque.Text = string.Format(this.FormatoNumeroRecibo.General, 0);
        }

        private DatosTransferenciaReciboType GetFilaEnBlancoGrillaTransferencia()
        {
            DatosTransferenciaReciboType datosTransf = new DatosTransferenciaReciboType();
            datosTransf.FechaTransferencia = DateTime.Now.ToShortDateString();
            datosTransf.BancoTransferenciaId = -1;
            datosTransf.BancoTransferenciaDescrip = string.Empty;
            datosTransf.NumeroTransferencia = string.Empty;
            datosTransf.MontoGastoBancario = 0;
            datosTransf.MontoTransferencia = 0;
            return datosTransf;
        }

        private DatosChequeReciboType GetFilaEnBlancoGrillaCheque()
        {
            DatosChequeReciboType datosCheque = new DatosChequeReciboType();
            datosCheque.FechaCheque = DateTime.Now.ToShortDateString();
            datosCheque.BancoChequeId = -1;
            datosCheque.BancoChequeDescrip = string.Empty;
            datosCheque.NumeroCheque = string.Empty;
            datosCheque.MontoCheque = 0;
            return datosCheque;
        }

        private MontosTransferencia GetTotalTransferencias()
        {
            decimal totalTransferencias = 0;
            decimal totalGastosBancarios = 0;
            foreach (DataGridViewRow row in this.dgvTransferencias.Rows)
            {
                totalTransferencias += (decimal)row.Cells[CAMPO_MONTO_TRANSFERENCIA].Value;
                totalGastosBancarios += (decimal)row.Cells[CAMPO_MONTO_GASTO_BANCARIO].Value;
            }
            return new MontosTransferencia() { TotalTransferencia = totalTransferencias, TotalGastosBancarios = totalGastosBancarios };
        }

        private decimal GetTotalCheques()
        {
            decimal totalCheques = 0;
            foreach (DataGridViewRow row in this.dgvCheques.Rows)
            {
                totalCheques += (decimal)row.Cells[CAMPO_MONTO_CHEQUE].Value;
            }
            return totalCheques;
        }

        private void CalcularSaldos()
        {
            decimal totalTransferencias = Convert.ToDecimal(this.txtTransferencia.Text);
            decimal totalGastosBancarios = Convert.ToDecimal(this.txtGastosBancarios.Text);
            decimal totalCheques = Convert.ToDecimal(this.txtCheque.Text);
            decimal totalRetenciones = Convert.ToDecimal(this.txtRetencionIVA10.Text) + Convert.ToDecimal(this.txtRetencionRenta.Text);
            
            decimal efectivo = this.TotalRecibo - (totalTransferencias + totalGastosBancarios + totalCheques + totalRetenciones);
            this.txtTotalRecibo.Text = string.Format(this.FormatoNumeroRecibo.General, totalRecibo);
            this.txtEfectivo.Text = string.Format(this.FormatoNumeroRecibo.General, efectivo);
        }

        private decimal GetTotalRecibo()
        {
            decimal totalRecibo = 0;
            

            foreach (FacturasParaRecibos row in this.ListaFacturas)
            {
                if (row.TipoDocumento.StartsWith(FACTURA))
                {
                    totalRecibo += row.ImporteCobrado.Value;

                    if (row.ImporteCobrado.Value == row.Saldo)
                    {
                        if (this.FacturasCanceladas != string.Empty)
                            this.FacturasCanceladas += ", ";

                        this.FacturasCanceladas += row.NroFactura;
                    }
                    else
                    {
                        if (this.FacturasPagosParciales != string.Empty)
                            this.FacturasPagosParciales += ", ";

                        this.FacturasPagosParciales += row.NroFactura;
                    }
                }
            }

            

            return totalRecibo;
        }

        private decimal GetTotalNC()
        {
            decimal totalNC = 0;

            foreach (FacturasParaRecibos row in this.ListaFacturas)
            {
                if (row.TipoDocumento == NOTA_CREDITO_ELECTRONICA)
                {
                    totalNC += row.Total;
                }
            }
            return totalNC;
        }

        private bool ValidarTotales()
        {
            decimal totalRecibo = Convert.ToDecimal(this.txtTotalRecibo.Text);

            decimal totalReciboCalculado = Math.Abs(Convert.ToDecimal(this.txtTransferencia.Text)) +
                                            Math.Abs(Convert.ToDecimal(this.txtGastosBancarios.Text)) +
                                            Math.Abs(Convert.ToDecimal(this.txtCheque.Text)) +
                                            Math.Abs(Convert.ToDecimal(this.txtRetencionIVA10.Text) + Convert.ToDecimal(this.txtRetencionRenta.Text)) +
                                            Math.Abs(Convert.ToDecimal(this.txtEfectivo.Text));

            return totalRecibo == totalReciboCalculado;
        }

        #endregion Métodos Locales

        #region Controles Locales
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.ValidarTotales())
            {
                string message = "";
                string caption = "";
                caption = "Generación de Recibo de Dinero";
                message = "Se generará un recibo con los datos del formulario ¿Desea continuar?";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBox.Show(message, caption, buttons,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                                new EventHandler(GenerarReciboDialogHandler));
            }
            else
            {
                MessageBox.Show("La sumatoria de montos ingresada no coincide con el monto total del recibo.",
                                       "Atención Requerida",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void GenerarReciboDialogHandler(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    this.GuardarRegistro();
                    //this.GenerarReporte();
                    //this.guardarRecibo(this.DBContext);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (this.CloseClick != null)
            {
                this.CloseClick(sender, e);
            }
        }
        #region Transferencias

        private void dgvTransferencias_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                if ((this.dgvTransferencias.Columns[e.ColumnIndex].Name == CAMPO_ELIMINAR_TRANSFERENCIA))
                {
                    this.dgvTransferencias.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Eliminar Transferencia";
                }
                else if ((this.dgvTransferencias.Columns[e.ColumnIndex].Name == CAMPO_CUENTA_TRANSFERENCIA_DESCRIP))
                {
                    this.dgvTransferencias.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = this.dgvTransferencias.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
            }
        }

        private void dgvTransferencias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                if (this.dgvTransferencias.Columns[e.ColumnIndex].Name == CAMPO_ELIMINAR_TRANSFERENCIA)
                {
                    bindingSource.RemoveAt(e.RowIndex);
                }
            }
        }
        #endregion Transferencias

        #region Cheques
        private void dgvCheques_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                if ((this.dgvCheques.Columns[e.ColumnIndex].Name == CAMPO_ELIMINAR_CHEQUE))
                {
                    this.dgvCheques.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Eliminar Cheque";
                }
                else if ((this.dgvCheques.Columns[e.ColumnIndex].Name == CAMPO_BANCO_CHEQUE_DESCRIP))
                {
                    this.dgvCheques.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = this.dgvCheques.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
            }
        }

        private void dgvCheques_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                if (this.dgvCheques.Columns[e.ColumnIndex].Name == CAMPO_ELIMINAR_CHEQUE)
                {
                    bindingSourceC.RemoveAt(e.RowIndex);
                }
            }
        }
        #endregion Cheques

        private void fCargarRetenciones_AceptarClick(object sender, EventArgs e)
        {
            this.ListaFacturasRetenciones = fCargarRetenciones.ListaFacturasRetenciones;

            decimal retIVA10 = this.ListaFacturasRetenciones
                                    .Sum(p => p.RetencionIVA10);
            this.txtRetencionIVA10.Text = string.Format(this.FormatoNumeroRecibo.General, retIVA10);

            decimal retRenta = this.ListaFacturasRetenciones
                                    .Sum(p => p.RetencionRenta);
            this.txtRetencionRenta.Text = string.Format(this.FormatoNumeroRecibo.General, retRenta);
            this.CalcularSaldos();
            fCargarRetenciones.Close();
        }

        private void btnCargarRetenciones_Click(object sender, EventArgs e)
        {
            if (this.fCargarRetenciones == null)
            {
                this.fCargarRetenciones = new FCargarRetencionesRecibo(this.DBContext,
                    "Cargar Retenciones del Recibo",
                    this.ListaFacturasRetenciones,
                    this.ListaFacturas,
                    Convert.ToDecimal(this.txtTotalRecibo.Text));
                this.fCargarRetenciones.FormClosed += delegate { this.fCargarRetenciones = null; };
                this.fCargarRetenciones.AceptarClick += fCargarRetenciones_AceptarClick;
            }
            this.fCargarRetenciones.ShowDialog();
        }

        private void btnAgregarTransferencia_Click(object sender, EventArgs e)
        {
            if (this.fCargarTransferencia == null)
            {
                this.fCargarTransferencia = new FCargarTransferenciaRecibo(this.DBContext, 
                    "Cargar Transferencias del Recibo", 
                    this.ListaFacturas.First().MonedaId,
                    this.ListaFacturas.First().MonedaAbrev,
                    Convert.ToDecimal(this.txtTotalRecibo.Text));
                fCargarTransferencia.AceptarClick += fCargarTransferencia_AceptarFiltrarClick;
                //this.fCargarTransferencia.FormClosed += delegate { f = null; };
            }
            this.fCargarTransferencia.MonedaId = this.ListaFacturas.First().MonedaId;
            this.fCargarTransferencia.MonedaAbrev = this.ListaFacturas.First().MonedaAbrev;
            this.fCargarTransferencia.ShowDialog();
        }

        private void fCargarTransferencia_AceptarFiltrarClick(object sender, EventArgs e)
        {
            bindingSource.Add(this.fCargarTransferencia.DatosTransferencia);
            this.fCargarTransferencia.Close();
        }

        private void btnAgregarCheque_Click(object sender, EventArgs e)
        {
            if (this.fCargarCheque == null)
            {
                this.fCargarCheque = new FCargarChequeRecibo(this.DBContext,
                    "Cargar Cheques del Recibo",
                    this.ListaFacturas.First().MonedaId,
                    this.ListaFacturas.First().MonedaAbrev,
                    Convert.ToDecimal(this.txtTotalRecibo.Text));
                this.fCargarCheque.AceptarClick += fCargarCheque_AceptarClick;
            }
            this.fCargarCheque.MonedaId = this.ListaFacturas.First().MonedaId;
            this.fCargarCheque.MonedaAbrev = this.ListaFacturas.First().MonedaAbrev;
            this.fCargarCheque.ShowDialog();
        }

        private void fCargarCheque_AceptarClick(object sender, EventArgs e)
        {
            bindingSourceC.Add(this.fCargarCheque.DatosCheque);
            this.fCargarCheque.Close();
        }
        #endregion Controles Locales

        private void txtEfectivo_Leave(object sender, EventArgs e)
        {
            decimal montoEfectivo;

            if (decimal.TryParse(this.txtEfectivo.Text, out montoEfectivo))
            {
                this.txtEfectivo.Text = String.Format(this.FormatoNumeroRecibo.General, montoEfectivo);
            }
        }

        private void dgvTransferencias_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            MontosTransferencia montos = this.GetTotalTransferencias();
            this.txtTransferencia.Text = string.Format(this.FormatoNumeroRecibo.General, montos.TotalTransferencia);
            this.txtGastosBancarios.Text = string.Format(this.FormatoNumeroRecibo.General, montos.TotalGastosBancarios);
            this.CalcularSaldos();
        }

        private void dgvTransferencias_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            MontosTransferencia montos = this.GetTotalTransferencias();
            this.txtTransferencia.Text = string.Format(this.FormatoNumeroRecibo.General, montos.TotalTransferencia);
            this.txtGastosBancarios.Text = string.Format(this.FormatoNumeroRecibo.General, montos.TotalGastosBancarios);
            this.CalcularSaldos();
        }

        private void dgvCheques_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            decimal monto = this.GetTotalCheques();
            this.txtCheque.Text = string.Format(this.FormatoNumeroRecibo.General, monto);
            this.CalcularSaldos();
        }

        private void dgvCheques_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            decimal monto = this.GetTotalCheques();
            this.txtCheque.Text = string.Format(this.FormatoNumeroRecibo.General, monto);
            this.CalcularSaldos();
        }
    }
}