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
    
    public partial class FCargarDepositoRecaudacion : Form
    {
        #region Variables
        BerkeDBEntities DBContext;
        frmPickBase fPickCliente;
        private FormatoNumeroReciboType formatoNumeroRecibo;
        private int clienteId;
        private int monedaId;
        private string monedaAbrev;
        private decimal totalRecibo;
        private List<FacturasParaRetenciones> listaFacturasRetenciones;
        private FCargarDatosRecaudacion fCargarDatosRecaudacion;
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
        private const string CAMPO_CARGAR_DEPOSITO = "CargarDeposito";
        private string CAMPO_RECIBOID = "ReciboId";
        private string CAMPO_NRORECIBO = "NroRecibo";
        private string CAMPO_FECHARECIBO = "FechaRecibo";
        private string CAMPO_CLIENTEID = "ClienteId";
        private string CAMPO_CLIENTENOMBRE = "ClienteNombre";
        private string CAMPO_MONEDAID = "MonedaId";
        private string CAMPO_MONEDAABREV = "MonedaAbrev";
        private string CAMPO_TOTALRECIBO = "TotalRecibo";
        private string CAMPO_FECHADEPOSITO = "FechaDeposito";
        private string CAMPO_DEPOSITO_RECAUDACION_ID = "DepositoRecaudacionId";
        private string CAMPO_NROBOLETA = "NroBoleta";
        private string CAMPO_CTABANCARIAID = "CtaBancariaId";
        private string CAMPO_CTABANCARIA_DESCRIP = "CtaBancariaDescrip";
        private string CAMPO_CTABANCARIA_NRO = "CtaBancariaNro";
        private string CAMPO_MONTODEPOSITO = "MontoDeposito";
        private string CAMPO_USUARIOCARGAID = "UsuarioCargaId";
        private string CAMPO_USUARIOCARGANOMBRE = "UsuarioCargaNombre";
        private string CAMPO_MONTODEPOSITABLE = "MontoDepositable";
        #endregion Constantes

        #region Eventos Personalizados
        //public event EventHandler AceptarClick;
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
        public FCargarDepositoRecaudacion()
        {
            InitializeComponent();
        }

        public FCargarDepositoRecaudacion(string titulo, BerkeDBEntities context)
        {
            InitializeComponent();
            this.Text = titulo;
            this.DBContext = context;

            List<DatosRecaudacionesType> listaRecaudaciones = (from rpc in this.DBContext.ObtenerRecibosParaRecaudaciones(null, null, null)
                                                               select new DatosRecaudacionesType
                                                               {
                                                                   ReciboId = rpc.ReciboId,
                                                                   NroRecibo = rpc.NroRecibo,
                                                                   FechaRecibo = rpc.FechaRecibo,
                                                                   ClienteId = rpc.ClienteId,
                                                                   ClienteNombre = rpc.ClienteNombre,
                                                                   MonedaId = rpc.MonedaId,
                                                                   MonedaAbrev = rpc.MonedaAbrev,
                                                                   TotalRecibo = rpc.TotalRecibo,
                                                                   TotalEfectivo = rpc.TotalEfectivo,
                                                                   TotalCheque = rpc.TotalCheque,
                                                                   MontoDepositable = rpc.MontoDepositable,
                                                                   DepositoRecaudacionId = rpc.DepositoRecaudacionId,
                                                                   FechaDeposito = rpc.FechaDeposito,
                                                                   NroBoleta = rpc.NroBoleta,
                                                                   CtaBancariaId = rpc.CtaBancariaId,
                                                                   CtaBancariaDescrip = rpc.CtaBancariaDescrip,
                                                                   CtaBancariaNro = rpc.CtaBancariaNro,
                                                                   MontoDeposito = rpc.MontoDeposito,
                                                                   UsuarioCargaId = rpc.UsuarioCargaId,
                                                                   UsuarioCargaNombre = rpc.UsuarioCargaNombre
                                                               })
                                                               .ToList();

            this.dgvRecaudaciones.AutoGenerateColumns = true;
            this.dgvRecaudaciones.DataSource = listaRecaudaciones;

            #region TextSearchBoxes
            this.tSBCliente.KeyMemberWidth = 70;
            this.tSBCliente.ToolTip = "Elegir Cliente";
            this.tSBCliente.AceptarClick += tSBCliente_AceptarClick;
            this.tSBCliente.KeyMemberTextChanged += tSBCliente_KeyMemberTextChanged;
            this.tSBCliente.Editable = true;
            this.tSBCliente.ToolTipTSB = "Cliente";
            #endregion TextSearchBoxes

            #region DateTime Pickers
            this.dtpFechaDesde.Format = DateTimePickerFormat.Short;
            this.dtpFechaHasta.Format = DateTimePickerFormat.Short;
            #endregion DateTime Pickers
        }

        private void tSBCliente_KeyMemberTextChanged(object sender, EventArgs e)
        {
            if (this.tSBCliente.KeyMember == string.Empty)
                this.tSBCliente.DisplayMember = string.Empty;
        }

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

        private void CalcularTotalesRetenciones()
        {
            //decimal totalRetIVA10 = 0;
            //decimal totalRetRenta = 0;

            //foreach (DataGridViewRow row in this.dgvRecaudaciones.Rows)
            //{
            //    totalRetIVA10 += (decimal)row.Cells[CAMPO_RETENCIONIVA10].Value;
            //    totalRetRenta += (decimal)row.Cells[CAMPO_RETENCIONRENTA].Value;
            //}

            //this.txtTotalRetIVA10.Text = string.Format(this.FormatoNumeroRecibo.General, totalRetIVA10);
            //this.txtTotalRetRenta.Text = string.Format(this.FormatoNumeroRecibo.General, totalRetRenta);
            //this.txtTotalRetenciones.Text = string.Format(this.FormatoNumeroRecibo.General, totalRetIVA10 + totalRetRenta);
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
            //this.dgvRecaudaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRecaudaciones.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Pixel);
            this.dgvRecaudaciones.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dgvRecaudaciones.DefaultCellStyle.Font = new Font("Arial", 11F, GraphicsUnit.Pixel);
            this.dgvRecaudaciones.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvRecaudaciones.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            this.dgvRecaudaciones.ItemsPerPage = 16;
            this.dgvRecaudaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecaudaciones.MultiSelect = false;
            this.dgvRecaudaciones.AllowUserToAddRows = false;
            this.dgvRecaudaciones.AllowUserToDeleteRows = false;
            this.dgvRecaudaciones.AllowUserToResizeRows = false;
            this.dgvRecaudaciones.AllowUserToOrderColumns = false;
            this.dgvRecaudaciones.RowHeadersWidth = 25;
            this.dgvRecaudaciones.ScrollBars = ScrollBars.None;

            foreach (DataGridViewColumn col in this.dgvRecaudaciones.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            int displayIndex = 0;

            this.dgvRecaudaciones.Columns[CAMPO_NRORECIBO].Visible = true;
            this.dgvRecaudaciones.Columns[CAMPO_NRORECIBO].DisplayIndex = displayIndex;
            this.dgvRecaudaciones.Columns[CAMPO_NRORECIBO].HeaderText = "N° Recibo";
            this.dgvRecaudaciones.Columns[CAMPO_NRORECIBO].Width = 95;
            displayIndex++;

            this.dgvRecaudaciones.Columns[CAMPO_FECHARECIBO].Visible = true;
            this.dgvRecaudaciones.Columns[CAMPO_FECHARECIBO].DisplayIndex = displayIndex;
            this.dgvRecaudaciones.Columns[CAMPO_FECHARECIBO].HeaderText = "Fec. Rec.";
            this.dgvRecaudaciones.Columns[CAMPO_FECHARECIBO].Width = 60;
            this.dgvRecaudaciones.Columns[CAMPO_FECHARECIBO].DefaultCellStyle.Format = "dd/MM/yyyy";
            displayIndex++;

            this.dgvRecaudaciones.Columns[CAMPO_CLIENTENOMBRE].Visible = true;
            this.dgvRecaudaciones.Columns[CAMPO_CLIENTENOMBRE].DisplayIndex = displayIndex;
            this.dgvRecaudaciones.Columns[CAMPO_CLIENTENOMBRE].HeaderText = "Cliente";
            this.dgvRecaudaciones.Columns[CAMPO_CLIENTENOMBRE].Width = 150;
            displayIndex++;

            this.dgvRecaudaciones.Columns[CAMPO_MONEDAABREV].Visible = true;
            this.dgvRecaudaciones.Columns[CAMPO_MONEDAABREV].DisplayIndex = displayIndex;
            this.dgvRecaudaciones.Columns[CAMPO_MONEDAABREV].HeaderText = "Moneda";
            this.dgvRecaudaciones.Columns[CAMPO_MONEDAABREV].Width = 50;
            displayIndex++;

            this.dgvRecaudaciones.Columns[CAMPO_TOTALRECIBO].Visible = true;
            this.dgvRecaudaciones.Columns[CAMPO_TOTALRECIBO].DisplayIndex = displayIndex;
            this.dgvRecaudaciones.Columns[CAMPO_TOTALRECIBO].HeaderText = "Total Rec.";
            this.dgvRecaudaciones.Columns[CAMPO_TOTALRECIBO].Width = 65;
            this.dgvRecaudaciones.Columns[CAMPO_TOTALRECIBO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            displayIndex++;

            this.dgvRecaudaciones.Columns[CAMPO_MONTODEPOSITABLE].Visible = true;
            this.dgvRecaudaciones.Columns[CAMPO_MONTODEPOSITABLE].DisplayIndex = displayIndex;
            this.dgvRecaudaciones.Columns[CAMPO_MONTODEPOSITABLE].HeaderText = "Depositable";
            this.dgvRecaudaciones.Columns[CAMPO_MONTODEPOSITABLE].Width = 70;
            this.dgvRecaudaciones.Columns[CAMPO_MONTODEPOSITABLE].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvRecaudaciones.Columns[CAMPO_MONTODEPOSITABLE].ToolTipText = "Está formado por la sumatoria de los totales en efectivo y cheques del recibo.";
            displayIndex++;

            this.dgvRecaudaciones.Columns[CAMPO_FECHADEPOSITO].Visible = true;
            this.dgvRecaudaciones.Columns[CAMPO_FECHADEPOSITO].DisplayIndex = displayIndex;
            this.dgvRecaudaciones.Columns[CAMPO_FECHADEPOSITO].HeaderText = "Fec. Dep.";
            this.dgvRecaudaciones.Columns[CAMPO_FECHADEPOSITO].Width = 60;
            this.dgvRecaudaciones.Columns[CAMPO_FECHADEPOSITO].DefaultCellStyle.Format = "dd/MM/yyyy";
            this.dgvRecaudaciones.Columns[CAMPO_FECHADEPOSITO].DefaultCellStyle.ForeColor = Color.Maroon;
            this.dgvRecaudaciones.Columns[CAMPO_FECHADEPOSITO].DefaultCellStyle.Font = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Pixel);
            //this.dgvRecaudaciones.Columns[CAMPO_FECHADEPOSITO].ReadOnly = false;
            displayIndex++;

            this.dgvRecaudaciones.Columns[CAMPO_NROBOLETA].Visible = true;
            this.dgvRecaudaciones.Columns[CAMPO_NROBOLETA].DisplayIndex = displayIndex;
            this.dgvRecaudaciones.Columns[CAMPO_NROBOLETA].HeaderText = "N° Boleta";
            this.dgvRecaudaciones.Columns[CAMPO_NROBOLETA].Width = 85;
            this.dgvRecaudaciones.Columns[CAMPO_NROBOLETA].DefaultCellStyle.ForeColor = Color.Maroon;
            this.dgvRecaudaciones.Columns[CAMPO_NROBOLETA].DefaultCellStyle.Font = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Pixel);
            displayIndex++;

            this.dgvRecaudaciones.Columns[CAMPO_CTABANCARIA_DESCRIP].Visible = true;
            this.dgvRecaudaciones.Columns[CAMPO_CTABANCARIA_DESCRIP].DisplayIndex = displayIndex;
            this.dgvRecaudaciones.Columns[CAMPO_CTABANCARIA_DESCRIP].HeaderText = "Cuenta";
            this.dgvRecaudaciones.Columns[CAMPO_CTABANCARIA_DESCRIP].Width = 150;
            this.dgvRecaudaciones.Columns[CAMPO_CTABANCARIA_DESCRIP].DefaultCellStyle.ForeColor = Color.Maroon;
            this.dgvRecaudaciones.Columns[CAMPO_CTABANCARIA_DESCRIP].DefaultCellStyle.Font = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Pixel);
            displayIndex++;

            this.dgvRecaudaciones.Columns[CAMPO_MONTODEPOSITO].Visible = true;
            this.dgvRecaudaciones.Columns[CAMPO_MONTODEPOSITO].DisplayIndex = displayIndex;
            this.dgvRecaudaciones.Columns[CAMPO_MONTODEPOSITO].HeaderText = "Monto Dep.";
            this.dgvRecaudaciones.Columns[CAMPO_MONTODEPOSITO].Width = 70;
            this.dgvRecaudaciones.Columns[CAMPO_MONTODEPOSITO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvRecaudaciones.Columns[CAMPO_MONTODEPOSITO].DefaultCellStyle.ForeColor = Color.Maroon;
            this.dgvRecaudaciones.Columns[CAMPO_MONTODEPOSITO].DefaultCellStyle.Font = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Pixel);
            displayIndex++;

            this.dgvRecaudaciones.Columns[CAMPO_USUARIOCARGANOMBRE].Visible = true;
            this.dgvRecaudaciones.Columns[CAMPO_USUARIOCARGANOMBRE].DisplayIndex = displayIndex;
            this.dgvRecaudaciones.Columns[CAMPO_USUARIOCARGANOMBRE].HeaderText = "Usuario Carga";
            this.dgvRecaudaciones.Columns[CAMPO_USUARIOCARGANOMBRE].Width = 120;
            this.dgvRecaudaciones.Columns[CAMPO_USUARIOCARGANOMBRE].DefaultCellStyle.ForeColor = Color.Maroon;
            this.dgvRecaudaciones.Columns[CAMPO_USUARIOCARGANOMBRE].DefaultCellStyle.Font = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Pixel);
            displayIndex++;

            #region Columna Cargar Deposito
            DataGridViewCellStyle cStyle = new DataGridViewCellStyle();
            cStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cStyle.ForeColor = Color.Green;
            cStyle.Font = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Pixel);

            DataGridViewButtonColumn showDetails = new DataGridViewButtonColumn();
            showDetails.HeaderText = "  ";
            showDetails.Text = "Cargar";
            showDetails.UseColumnTextForButtonValue = true;
            showDetails.DefaultCellStyle = cStyle;
            showDetails.ToolTipText = "Cargar datos del depósito";
            showDetails.Width = 55;
            showDetails.Name = CAMPO_CARGAR_DEPOSITO;
            this.dgvRecaudaciones.Columns.Insert(0, showDetails);
            #endregion Columna Cargar Deposito

            //DataGridViewCheckBoxColumn doWork = new DataGridViewCheckBoxColumn();
            //doWork.HeaderText = "Selecc";
            //doWork.HeaderCell.Style.ForeColor = Color.Transparent;
            //doWork.Name = CAMPO_SELECCIONAR;
            //doWork.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //doWork.FalseValue = false;
            //doWork.TrueValue = true;
            //doWork.ReadOnly = false;
            //doWork.Width = 43;
            //this.dgvRecaudaciones.Columns.Insert(0, doWork);
        }
        #endregion Metodos de Inicio

        #region Metodos de Apoyo
        private void CargarRecaudaciones()
        {
            
        }

        private void LimpiarTextBoxes()
        {

        }

        private List<int> GetListaSeleccionados()
        {
            List<int> result = new List<int>();
            
            foreach (DataGridViewRow row in this.dgvRecaudaciones.Rows)
            {
                if ((row.Cells[CAMPO_SELECCIONAR].GetType() == typeof(DataGridViewCheckBoxCell)) && (row.Cells[CAMPO_SELECCIONAR].Value != null) && ((bool)row.Cells[CAMPO_SELECCIONAR].Value))
                {
                    result.Add(row.Index);
                }
            }

            this.btnCargarDatosDepositos.Enabled = result.Count > 0;
            return result;
        }
        #endregion Metodos de Apoyo

        #region Metodos sobre Controles
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string message = "";
            string caption = "";
            caption = "Carga de Depósito de Recaudación";
            message = "Se guardarán los datos ¿Desea continuar?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(CargarRecaudacionesDialogHandler));
        }

        private void CargarRecaudacionesDialogHandler(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    this.GuardarRegistro();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void headerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool checkedState = this.headerCheckBox.Checked;

            foreach (DataGridViewRow row in this.dgvRecaudaciones.Rows)
            {
                row.Cells[CAMPO_SELECCIONAR].Value = checkedState;
            }

            this.btnCargarDatosDepositos.Enabled = this.GetListaSeleccionados().Count > 0;
        }
        #endregion Metodos sobre Controles

        private void fCargarDatosRecaudacion_AceptarClick(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dgvRecaudaciones.Rows[fCargarDatosRecaudacion.ReciboIndex];
            row.Cells[CAMPO_FECHADEPOSITO].Value = fCargarDatosRecaudacion.DatoRecaudacion.FechaDeposito;
            row.Cells[CAMPO_NROBOLETA].Value = fCargarDatosRecaudacion.DatoRecaudacion.NroBoleta;
            row.Cells[CAMPO_CTABANCARIAID].Value = fCargarDatosRecaudacion.DatoRecaudacion.CtaBancariaId;
            row.Cells[CAMPO_CTABANCARIA_DESCRIP].Value = fCargarDatosRecaudacion.DatoRecaudacion.CtaBancariaDescrip;
            row.Cells[CAMPO_CTABANCARIA_NRO].Value = fCargarDatosRecaudacion.DatoRecaudacion.CtaBancariaNro;
            row.Cells[CAMPO_MONTODEPOSITO].Value = fCargarDatosRecaudacion.DatoRecaudacion.MontoDeposito;
            row.Cells[CAMPO_USUARIOCARGAID].Value = fCargarDatosRecaudacion.DatoRecaudacion.UsuarioCargaId;
            row.Cells[CAMPO_USUARIOCARGANOMBRE].Value = fCargarDatosRecaudacion.DatoRecaudacion.UsuarioCargaNombre;
            this.dgvRecaudaciones.Update();
            fCargarDatosRecaudacion.Close();
        }

        private void btnCargarDatosRetencion_Click(object sender, EventArgs e)
        {
            //fCargarDatosRecaudacion = new FCargarDatosRecaudacion("Ingresar datos de retención", this.GetListaSeleccionados());
            //fCargarDatosRecaudacion.FormClosed += delegate { fCargarDatosRecaudacion = null; };
            //fCargarDatosRecaudacion.AceptarClick += fCargarDatosRecaudacion_AceptarClick;
            //fCargarDatosRecaudacion.ShowDialog();
        }

        #region CRUD
        private void GuardarRegistro()
        {
            bool success = false;

            dr_depositorecaudacion dr = null;
            DataGridViewRow r = null;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach(DataGridViewRow row in this.dgvRecaudaciones.Rows)
                        {
                            r = row;
                            DatosRecaudacionesType rdr = (DatosRecaudacionesType)row.DataBoundItem;
                            if (rdr.MontoDeposito > 0)
                            {
                                dr = this.guardaRecaudacion(rdr, context);
                                context.SaveChanges();
                                r.ErrorText = string.Empty;
                            }
                         }
                        
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

                        if (r != null)
                            r.ErrorText = ex.Message + " " + innerException;

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
                this.Filtrar();
                MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region Métodos de Edición de Datos
        private dr_depositorecaudacion guardaRecaudacion(DatosRecaudacionesType rdr, BerkeDBEntities context = null)
        {
            dr_depositorecaudacion dr = context.dr_depositorecaudacion.FirstOrDefault(a => a.dr_depositorecaudacionid == rdr.DepositoRecaudacionId);

            if (dr != null)
            {
                dr.dr_reciboid = rdr.ReciboId;
                dr.dr_fechadeposito = rdr.FechaDeposito.Value;
                dr.dr_cuentadepositoid = rdr.CtaBancariaId.Value;
                dr.dr_nroboleta = rdr.NroBoleta;
                dr.dr_monedaid = rdr.MonedaId;
                dr.dr_monto = rdr.MontoDeposito.Value;
                dr.dr_usuariocargaid = rdr.UsuarioCargaId.Value;
            }
            else
            {
                dr = new dr_depositorecaudacion();
                dr.dr_reciboid = rdr.ReciboId;
                dr.dr_fechadeposito = rdr.FechaDeposito.Value;
                dr.dr_cuentadepositoid = rdr.CtaBancariaId.Value;
                dr.dr_nroboleta = rdr.NroBoleta;
                dr.dr_monedaid = rdr.MonedaId;
                dr.dr_monto = rdr.MontoDeposito.Value;
                dr.dr_usuariocargaid = rdr.UsuarioCargaId.Value;
                context.dr_depositorecaudacion.Add(dr);
            }
            return dr;
        }
        #endregion Métodos de Edición de Datos
        #endregion CRUD

        private void dgvRetenciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex > -1) && (e.ColumnIndex > -1))
            {
                //if (this.dgvRecaudaciones.Columns[e.ColumnIndex].Name == CAMPO_SELECCIONAR)
                //{
                //    this.btnCargarDatosDepositos.Enabled = this.GetListaSeleccionados().Count > 0;
                //}

                if (this.dgvRecaudaciones.Columns[e.ColumnIndex].Name == CAMPO_CARGAR_DEPOSITO)
                {
                    DatosRecaudacionesType datoRecaudacion = (DatosRecaudacionesType)this.dgvRecaudaciones.Rows[e.RowIndex].DataBoundItem;
                    fCargarDatosRecaudacion = new FCargarDatosRecaudacion("Ingresar datos de retención", this.DBContext, datoRecaudacion, e.RowIndex);
                    fCargarDatosRecaudacion.FormClosed += delegate { fCargarDatosRecaudacion = null; };
                    fCargarDatosRecaudacion.AceptarClick += fCargarDatosRecaudacion_AceptarClick;
                    fCargarDatosRecaudacion.ShowDialog();
                }
            }
        }

        private void FCargarDepositoRecaudacion_Load(object sender, EventArgs e)
        {
            this.pnlFiltroFecha.Visible = false;
            this.chkFiltroFecha.Checked = false;
            this.btnFiltrar.Location = new Point(426, 13);
            this.btnCargarDatosDepositos.Enabled = false;
            this.LimpiarTextBoxes();
            this.dgvRecaudaciones.Focus();
        }

        private void dgvRecaudaciones_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.FormatearGrilla();
        }

        private void dgvRecaudaciones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.RowIndex > -1) && (e.ColumnIndex > -1))
            {
                if ((this.dgvRecaudaciones.Columns[e.ColumnIndex].Name == CAMPO_TOTALRECIBO)
                    || (this.dgvRecaudaciones.Columns[e.ColumnIndex].Name == CAMPO_MONTODEPOSITO)
                    || (this.dgvRecaudaciones.Columns[e.ColumnIndex].Name == CAMPO_MONTODEPOSITABLE))
                {
                    int monedaId = (int)this.dgvRecaudaciones.Rows[e.RowIndex].Cells[CAMPO_MONEDAID].Value;

                    switch (monedaId)
                    {
                        case GUARANIES_MONEDA_ID:
                            e.Value = string.Format(FORMATO_MONEDA_GUARANIES, e.Value);
                            e.FormattingApplied = true;
                            break;
                        default:
                            e.Value = string.Format(FORMATO_MONEDA_OTROS, e.Value);
                            e.FormattingApplied = true;
                            break;
                    }
                }

                if ((this.dgvRecaudaciones.Columns[e.ColumnIndex].Name == CAMPO_CLIENTENOMBRE)
                    && (this.dgvRecaudaciones.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null))
                {
                    this.dgvRecaudaciones.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = this.dgvRecaudaciones.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()
                                                                                                + " (" + this.dgvRecaudaciones.Rows[e.RowIndex].Cells[CAMPO_CLIENTEID].Value.ToString() + ")";
                }

                if ((this.dgvRecaudaciones.Columns[e.ColumnIndex].Name == CAMPO_CTABANCARIA_DESCRIP)
                    && (this.dgvRecaudaciones.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null))
                {
                    this.dgvRecaudaciones.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = this.dgvRecaudaciones.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }

                if ((this.dgvRecaudaciones.Columns[e.ColumnIndex].Name == CAMPO_USUARIOCARGANOMBRE)
                    && (this.dgvRecaudaciones.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null))
                {
                    this.dgvRecaudaciones.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = this.dgvRecaudaciones.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }

                if (this.dgvRecaudaciones.Columns[e.ColumnIndex].Name == CAMPO_SELECCIONAR)
                {
                    this.dgvRecaudaciones.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Puede marcar/desmarcar con la barra espaciadora";
                }

                if (this.dgvRecaudaciones.Columns[e.ColumnIndex].Name == CAMPO_MONTODEPOSITABLE)
                {
                    this.dgvRecaudaciones.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Está formado por la sumatoria de los totales en efectivo y cheques del recibo.";
                }
            }
        }

        private void dgvRecaudaciones_KeyDown(object objSender, KeyEventArgs objArgs)
        {
            if (objArgs.KeyCode == Keys.Space)
            {
                if (this.dgvRecaudaciones.CurrentRow != null)
                {
                    DataGridViewRow row = this.dgvRecaudaciones.CurrentRow;
                    bool checkState = row.Cells[CAMPO_SELECCIONAR].Value != null
                                        ? (bool)row.Cells[CAMPO_SELECCIONAR].Value
                                        : false;
                    row.Cells[CAMPO_SELECCIONAR].Value = !checkState;
                    this.btnCancelar.Focus();
                    this.dgvRecaudaciones.Focus();
                }
            }
        }

        private void Filtrar()
        {
            Nullable<int> clienteId = null;
            Nullable<DateTime> fechaDesde = null;
            Nullable<DateTime> fechaHasta = null;

            if (this.tSBCliente.KeyMember != string.Empty)
                clienteId = Convert.ToInt32(this.tSBCliente.KeyMember);


            if (this.pnlFiltroFecha.Visible)
            {
                fechaDesde = this.dtpFechaDesde.Value;
                fechaHasta = this.dtpFechaHasta.Value;
            }

            List<DatosRecaudacionesType> listaRecaudaciones = (from rpc in this.DBContext.ObtenerRecibosParaRecaudaciones(clienteId, fechaDesde, fechaHasta)
                                                               select new DatosRecaudacionesType
                                                               {
                                                                   ReciboId = rpc.ReciboId,
                                                                   NroRecibo = rpc.NroRecibo,
                                                                   FechaRecibo = rpc.FechaRecibo,
                                                                   ClienteId = rpc.ClienteId,
                                                                   ClienteNombre = rpc.ClienteNombre,
                                                                   MonedaId = rpc.MonedaId,
                                                                   MonedaAbrev = rpc.MonedaAbrev,
                                                                   TotalRecibo = rpc.TotalRecibo,
                                                                   TotalEfectivo = rpc.TotalEfectivo,
                                                                   TotalCheque = rpc.TotalCheque,
                                                                   MontoDepositable = rpc.MontoDepositable,
                                                                   DepositoRecaudacionId = rpc.DepositoRecaudacionId,
                                                                   FechaDeposito = rpc.FechaDeposito,
                                                                   NroBoleta = rpc.NroBoleta,
                                                                   CtaBancariaId = rpc.CtaBancariaId,
                                                                   CtaBancariaDescrip = rpc.CtaBancariaDescrip,
                                                                   CtaBancariaNro = rpc.CtaBancariaNro,
                                                                   MontoDeposito = rpc.MontoDeposito,
                                                                   UsuarioCargaId = rpc.UsuarioCargaId,
                                                                   UsuarioCargaNombre = rpc.UsuarioCargaNombre
                                                               })
                                                               .ToList();
            this.dgvRecaudaciones.DataSource = listaRecaudaciones;
            this.dgvRecaudaciones.Focus();
        }


        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            this.Filtrar();
        }

        private void chkFiltroFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                this.pnlFiltroFecha.Visible = true;
                this.btnFiltrar.Location = new Point(660, 13);
            }
            else
            {
                this.pnlFiltroFecha.Visible = false;
                this.btnFiltrar.Location = new Point(426, 13);
            }
        }
    }
}