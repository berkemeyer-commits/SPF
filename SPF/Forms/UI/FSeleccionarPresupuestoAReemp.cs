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

#endregion

namespace SPF.Forms.UI
{
    public partial class FSeleccionarPresupuestoAReemp : Form
    {
        #region Variables
        BerkeDBEntities DBContext;
        private List<object> filterParam;
        private int clienteID = -1;
        private string listaPresupuestos = "";
        CheckBox headerCheckBox;
        #endregion Variables

        #region Constantes
        private const string CAMPO_PRESUPUESTOCABID = "PresupuestoCabID";
        private const string CAMPO_NRODOCUMENTO     = "NroDocumento";
        private const string CAMPO_FECHADOCUMENTO   = "FechaDocumento";
        private const string CAMPO_MONTO            = "MontoDocumento";
        private const string CAMPO_SALDO            = "SaldoDocumento";
        private const string CAMPO_SELECCIONAR      = "Seleccionar";
        private const string CAMPO_CLIENTEID        = "ClienteID";
        private const string CAMPO_CLIENTENOMBRE    = "ClienteNombre";
        private const string CAMPO_ESTADODOCUMENTO  = "EstadoDocumento";
        private const string CAMPO_DESCRIPCION      = "Descripcion";
        private const string CAMPO_TRAMITEDESCRIP   = "TramiteDescrip";
        private const string CAMPO_MONEDAABREV      = "MonedaAbrev";
        private const string CAMPO_MONEDADESCRIP    = "MonedaDescrip";

        private const string DEFAULT_STRING_PATTERN = "( {0} = {1} )";
        private const string RANGE_STRING_PATTERN   = "( {0} >= {1} AND {0} <= {2} )";
        private const string ESTADO_ANULADO         = "N";
        private const string ESTADO_PENDIENTE       = "A";
        private const string SELECTED_TEXT = "{0} presupuestos seleccionados";

        private const string MONEDA_GUARANIES = "G";
        private const string FORMATO_MONEDA_GUARANIES_GRILLA = "N0";
        private const string FORMATO_MONEDA_OTROS_GRILLA = "N2";
        #endregion Constantes

        #region Eventos personalizados
        public event EventHandler AceptarClick;
        #endregion Eventos personalizados

        #region Propiedades
        public string ListaPresupuestos
        {
            set { this.listaPresupuestos = value; }
            get { return this.listaPresupuestos; }
        }

        public int ClienteID
        {
            set { this.clienteID = value; }
            get { return this.clienteID; }
        }
        #endregion Propiedades

        #region Métodos de Inicio
        public FSeleccionarPresupuestoAReemp()
        {
            InitializeComponent();
        }

        public FSeleccionarPresupuestoAReemp(BerkeDBEntities context, string titulo, string fechaDesde, string fechaHasta, int pClienteID, string clienteNombre)
        {
            InitializeComponent();
            this.DBContext = context;
            this.Text = titulo;
            this.filterParam = null;
            this.ClienteID = pClienteID;

            #region DateTime Pickers
            this.dtpFechaDesde.Format = DateTimePickerFormat.Short;
            this.dtpFechaDesde.Value = Convert.ToDateTime(fechaDesde);
            this.dtpFechaHasta.Format = DateTimePickerFormat.Short;
            this.dtpFechaHasta.Value = Convert.ToDateTime(fechaHasta);
            #endregion DateTime Pickers

            this.txtClienteID.Text = clienteID.ToString();
            this.txtClienteNombre.Text = clienteNombre;
            this.txtFechaDesde.Text = fechaDesde;
            this.txtFechaHasta.Text = fechaHasta;

            this.CargarPresupuestos(fechaDesde, fechaHasta, this.ClienteID.ToString());
            this.lblSeleccionados.Text = string.Format(SELECTED_TEXT, "0");
        }

        private void FSeleccionarPresupuestoNC_Load(object sender, EventArgs e)
        {
            if (headerCheckBox == null)
                headerCheckBox = new CheckBox();

            this.headerCheckBox.Checked = false;
            this.FormatearGrilla();
        }

        #endregion Métodos de Inicio

        #region Métodos Locales
        private void CargarPresupuestos(string fechaDesde, string fechaHasta, string clienteID)
        {
            string whereString = this.GetWhere(fechaDesde, fechaHasta, clienteID);
            var query = (from pCab in this.DBContext.pc_presupuestocab
                         join cli in this.DBContext.Cliente
                             on pCab.pc_clienteid equals cli.ID
                         join tra in this.DBContext.Tramite
                             on pCab.pc_tramiteid equals tra.ID
                         join mon in this.DBContext.Moneda
                             on pCab.pc_monedaid equals mon.ID
                         join uSol in this.DBContext.Usuario 
                             on pCab.pc_enviadopor equals uSol.ID
                         join uAut in this.DBContext.Usuario
                             on pCab.pc_autorizadopor equals uAut.ID
                         join at in this.DBContext.Atencion
                            on pCab.pc_atencionid equals at.ID into pCab_at
                            from at in pCab_at.DefaultIfEmpty()
                         select new PresupSelReemp
                         {
                             PresupuestoCabID = pCab.pc_presupuestocabid,
                             ClienteID = pCab.pc_clienteid,
                             ClienteNombre = cli.Nombre,
                             NroDocumento = this.DBContext.GetDocumentoNro(pCab.pc_presupuestocabid).FirstOrDefault(),
                             FechaDocumento = this.DBContext.GetFechaDocumento(pCab.pc_presupuestocabid).FirstOrDefault(),
                             MontoDocumento = pCab.pc_total,
                             SaldoDocumento = pCab.pc_saldo,
                             EstadoDocumento = pCab.pc_estado,
                             TramiteID = pCab.pc_tramiteid,
                             TramiteDescrip = tra.Descrip,
                             MonedaID = mon.ID,
                             MonedaAbrev = mon.AbrevMoneda,
                             MonedaDescrip = mon.Descripcion,
                             SolicitadoPorID = pCab.pc_enviadopor,
                             SolicitadoPorNombre = uSol.NombrePila,
                             AutorizadoPorID = pCab.pc_autorizadopor,
                             AutorizadoPorNombre = uAut.NombrePila,
                             Origen = pCab.pc_origen,
                             AtencionID = pCab.pc_atencionid.Value,
                             AtencionNombre = at.Nombre,
                             ClienteSelloColor = this.DBContext.GetSello(pCab.pc_clienteid, pCab.pc_monedaid).FirstOrDefault().SelloColor,
                             ClienteSelloTexto = this.DBContext.GetSello(pCab.pc_clienteid, pCab.pc_monedaid).FirstOrDefault().SelloTexto
                         })
                         .Where(whereString, this.filterParam.ToArray())
                         .OrderBy(a => a.FechaDocumento)
                         .ToList();

            this.dgvPresupuestos.DataSource = query;
            this.lblEstado.Text = "Documentos recuperados: " + query.Count.ToString();

            if (query.Count > 0)
            {
                this.txtClienteID.Text = query.First().ClienteID.ToString();
                this.txtClienteNombre.Text = query.First().ClienteNombre;
            }
            this.MarcarPresupuestos();
        }

        private string GetWhere(string fechaDesde, string fechaHasta, string clienteID)
        {
            string Result = String.Format(DEFAULT_STRING_PATTERN, CAMPO_CLIENTEID, clienteID) + " AND " +
                            this.getParseString(String.Format(RANGE_STRING_PATTERN, CAMPO_FECHADOCUMENTO, "\"" + fechaDesde + "\"", "\"" + fechaHasta + "\"")) + " AND " +
                            "(" + CAMPO_ESTADODOCUMENTO + " == \"" + ESTADO_PENDIENTE + "\")";
                            //"(" + CAMPO_ESTADODOCUMENTO + " != \"" + ESTADO_ANULADO + "\")";
                            
            return Result;
        }

        private string getParseString(string where)
        {
            var regex = new Regex(@"\b\d{2}\/\d{2}/\d{4}\b");
            this.filterParam = new List<object>();
            int cont = 0;
            foreach (Match m in regex.Matches(where))
            {
                DateTime dt;
                if (DateTime.TryParseExact(m.Value, "dd/MM/yyyy", null, DateTimeStyles.None, out dt))
                {
                    where = where.Replace("\"" + m.Value + "\"", "@" + cont.ToString());
                    this.filterParam.Add(dt);
                    cont++;
                }
            }
            return where;
        }

        private void FormatearGrilla()
        {
            foreach (DataGridViewColumn col in this.dgvPresupuestos.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            this.dgvPresupuestos.ReadOnly = false;
            this.dgvPresupuestos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPresupuestos.ItemsPerPage = 13;
            this.dgvPresupuestos.ShowCellToolTips = true;
            this.dgvPresupuestos.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvPresupuestos.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvPresupuestos.DefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvPresupuestos.DefaultCellStyle.BackColor = Color.Transparent;

            this.dgvPresupuestos.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            
            int displayIndex = 0;

            this.dgvPresupuestos.Columns[CAMPO_TRAMITEDESCRIP].HeaderText = "Trámite";
            this.dgvPresupuestos.Columns[CAMPO_TRAMITEDESCRIP].Width = 200;
            this.dgvPresupuestos.Columns[CAMPO_TRAMITEDESCRIP].DisplayIndex = displayIndex;
            this.dgvPresupuestos.Columns[CAMPO_TRAMITEDESCRIP].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvPresupuestos.Columns[CAMPO_TRAMITEDESCRIP].Visible = true;
            displayIndex++;

            this.dgvPresupuestos.Columns[CAMPO_FECHADOCUMENTO].HeaderText = "Fec. Documento";
            this.dgvPresupuestos.Columns[CAMPO_FECHADOCUMENTO].Width = 120;
            this.dgvPresupuestos.Columns[CAMPO_FECHADOCUMENTO].DisplayIndex = displayIndex;
            this.dgvPresupuestos.Columns[CAMPO_FECHADOCUMENTO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvPresupuestos.Columns[CAMPO_FECHADOCUMENTO].Visible = true;
            displayIndex++;

            this.dgvPresupuestos.Columns[CAMPO_NRODOCUMENTO].HeaderText = "N° Documento";
            this.dgvPresupuestos.Columns[CAMPO_NRODOCUMENTO].Width = 120;
            this.dgvPresupuestos.Columns[CAMPO_NRODOCUMENTO].DisplayIndex = displayIndex;
            this.dgvPresupuestos.Columns[CAMPO_NRODOCUMENTO].Visible = true;
            displayIndex++;

            this.dgvPresupuestos.Columns[CAMPO_MONEDAABREV].HeaderText = "Moneda";
            this.dgvPresupuestos.Columns[CAMPO_MONEDAABREV].Width = 80;
            this.dgvPresupuestos.Columns[CAMPO_MONEDAABREV].DisplayIndex = displayIndex;
            this.dgvPresupuestos.Columns[CAMPO_MONEDAABREV].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvPresupuestos.Columns[CAMPO_MONEDAABREV].Visible = true;
            displayIndex++;

            this.dgvPresupuestos.Columns[CAMPO_MONTO].HeaderText = "Monto";
            this.dgvPresupuestos.Columns[CAMPO_MONTO].Width = 80;
            this.dgvPresupuestos.Columns[CAMPO_MONTO].DisplayIndex = displayIndex;
            this.dgvPresupuestos.Columns[CAMPO_MONTO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvPresupuestos.Columns[CAMPO_MONTO].Visible = true;
            displayIndex++;

            this.dgvPresupuestos.Columns[CAMPO_SALDO].HeaderText = "Saldo";
            this.dgvPresupuestos.Columns[CAMPO_SALDO].Width = 80;
            this.dgvPresupuestos.Columns[CAMPO_SALDO].DisplayIndex = displayIndex;
            this.dgvPresupuestos.Columns[CAMPO_SALDO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvPresupuestos.Columns[CAMPO_SALDO].Visible = true;
            displayIndex++;

            this.dgvPresupuestos.Columns[CAMPO_PRESUPUESTOCABID].HeaderText = "Presup. ID";
            this.dgvPresupuestos.Columns[CAMPO_PRESUPUESTOCABID].Width = 80;
            this.dgvPresupuestos.Columns[CAMPO_PRESUPUESTOCABID].DisplayIndex = displayIndex;
            this.dgvPresupuestos.Columns[CAMPO_PRESUPUESTOCABID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvPresupuestos.Columns[CAMPO_PRESUPUESTOCABID].Visible = true;
            displayIndex++;

            

            //DataGridViewCheckBoxColumn doWork = new DataGridViewCheckBoxColumn();
            //doWork.HeaderText = CAMPO_SELECCIONAR;
            //doWork.Name = CAMPO_SELECCIONAR;
            //doWork.FalseValue = false;
            //doWork.TrueValue = true;
            //doWork.ReadOnly = false;
            //doWork.Width = 80;
            //this.dgvPresupuestos.Columns.Insert(0, doWork);

            
            //Find the Location of Header Cell.
            Point headerCellLocation = this.dgvPresupuestos.Columns[0].HeaderCell.ContentBounds.Location;

            //Place the Header CheckBox in the Location of the Header Cell.
            headerCheckBox.Location = new Point(headerCellLocation.X + 48, headerCellLocation.Y + 3);
            headerCheckBox.BackColor = Color.White;
            headerCheckBox.Size = new Size(15, 15);
            headerCheckBox.ClientId = "headerChkPresupReemp";

            //Assign Click event to the Header CheckBox.
            headerCheckBox.Click += new EventHandler(HeaderCheckBox_Clicked);
            //headerCheckBox.CheckStateChanged += headerCheckBox_CheckStateChanged;
            this.pnlGridDetPresup.Controls.Add(headerCheckBox);

            //Assign Click event to the DataGridView Cell.
            this.dgvPresupuestos.CellContentClick += new DataGridViewCellEventHandler(DataGridView_CellClick);
            //dataGridView1.CellContentClick += new DataGridViewCellEventHandler(DataGridView_CellClick);

            //Add a CheckBox Column to the DataGridView at the first position.
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.Width = 30;
            checkBoxColumn.Name = CAMPO_SELECCIONAR;
            checkBoxColumn.HeaderText = " ";
            checkBoxColumn.TrueValue = true;
            checkBoxColumn.FalseValue = false;
            
            this.dgvPresupuestos.Columns.Insert(0, checkBoxColumn);
        }

        protected override void FireEvent(Gizmox.WebGUI.Common.Interfaces.IEvent objEvent)
        {
            if (objEvent.Type == "headerCheckBoxValEvent")
            {
                //MessageBox.Show(objEvent["headerCheckBoxVal"]);
                this.SelectAll(objEvent["headerCheckBoxVal"]);
            }
            else
                base.FireEvent(objEvent);

        }

        private void SelectAll(string select)
        {
            bool isChecked = select == "true" ? true : false;

            foreach (DataGridViewRow row in this.dgvPresupuestos.Rows)
            {
                //DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)this.dgvPresupuestos.Rows[row.Index].Cells[CAMPO_SELECCIONAR];
                ////DataGridViewCell cell = checkCell;
                ////this.dgvPresupuestos.CurrentCell = checkCell;
                ////this.dgvPresupuestos.BeginEdit(true);
                //checkCell.Value = checkCell.TrueValue;
                row.Cells[CAMPO_SELECCIONAR].Value = isChecked;
            }
            //this.dgvPresupuestos.EndEdit();
        }

        private void HeaderCheckBox_Clicked(object sender, EventArgs e)
        {
            //VWGClientContext.Current.Invoke("getHeaderCheckBoxVal", (((int)this.headerCheckBox.ID) - 1).ToString());
            object[] jsParams = new object[2];
            jsParams[0] = this.ID.ToString();
            jsParams[1] = this.headerCheckBox.ID.ToString();
            //jsParams[1] = (((int)this.headerCheckBox.ID) - 1).ToString();// this.headerCheckBox.ID.ToString();
            VWGClientContext.Current.Invoke("getHeaderCheckBoxVal", jsParams);
            return;
            //Necessary to end the edit mode of the Cell.
            //this.dgvPresupuestos.EndEdit();

            //MessageBox.Show(headerCheckBox.Checked.ToString());
            //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
            //foreach (DataGridViewRow row in this.dgvPresupuestos.Rows)
            //{
            //    //DataGridViewCheckBoxCell checkBox = (row.Cells[CAMPO_SELECCIONAR] as DataGridViewCheckBoxCell);
            //    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)this.dgvPresupuestos.Rows[row.Index].Cells[CAMPO_SELECCIONAR];
            //    checkCell.Value = headerCheckBox.Checked;
            //}
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Check to ensure that the row CheckBox is clicked.
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                //Loop to verify whether all row CheckBoxes are checked or not.
                bool isChecked = true;
                foreach (DataGridViewRow row in this.dgvPresupuestos.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[CAMPO_SELECCIONAR].EditedFormattedValue) == false)
                    {
                        isChecked = false;
                        break;
                    }
                }
                headerCheckBox.Checked = isChecked;
            }
        }

        public void MarcarPresupuestos()
        {
            if (this.listaPresupuestos != "")
            {
                this.dgvPresupuestos.Update();
                List<string> lista = this.listaPresupuestos.Split(',').ToList();

                foreach (DataGridViewRow row in this.dgvPresupuestos.Rows)
                {
                    string NroDoc = row.Cells[CAMPO_NRODOCUMENTO].Value.ToString();

                    if (lista.Contains(NroDoc))
                    {
                        DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)this.dgvPresupuestos.Rows[row.Index].Cells[CAMPO_SELECCIONAR];
                        checkCell.Value = true;
                    }
                }
                
            }
        }

        private string GetListaPresupuestos()
        {
            string Result = "";
            
            foreach (DataGridViewRow row in this.dgvPresupuestos.Rows)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)this.dgvPresupuestos.Rows[row.Index].Cells[CAMPO_SELECCIONAR];
                if ((checkCell.Value != null) && ((bool)checkCell.Value))
                {
                    Result += Result != "" ? "," + row.Cells[CAMPO_PRESUPUESTOCABID].Value.ToString() : row.Cells[CAMPO_PRESUPUESTOCABID].Value.ToString();
                }
            }

            return Result;
        }

        public List<PresupSelReemp> GetPresupuestosData()
        {
            List<PresupSelReemp> Result = new List<PresupSelReemp>();

            foreach (DataGridViewRow row in this.dgvPresupuestos.Rows)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)this.dgvPresupuestos.Rows[row.Index].Cells[CAMPO_SELECCIONAR];
                if ((checkCell.Value != null) && ((bool)checkCell.Value))
                {
                    Result.Add((PresupSelReemp)row.DataBoundItem);
                }
            }

            return Result;
        }

        public string GetListaPresupuestosCabId()
        {
            return this.GetListaPresupuestos();
        }
        #endregion Métodos Locales

        #region Controles Locales
        private void FSeleccionarPresupuestoNC_VisibleChanged(object sender, EventArgs e)
        {
            this.FormatearGrilla();
            this.MarcarPresupuestos();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.AceptarClick != null)
            {
                this.ListaPresupuestos = this.GetListaPresupuestos();
                this.AceptarClick(sender, e);
            }
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaDesde.Text = this.dtpFechaDesde.Value.ToShortDateString();
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaHasta.Text = this.dtpFechaHasta.Value.ToShortDateString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if ((this.txtFechaDesde.Text == "") || (this.txtFechaHasta.Text == ""))
            {
                MessageBox.Show("Debe ingresar un rango de fechas válido.",
                               "Información",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return;
            }
            this.lblSeleccionados.Text = string.Format(SELECTED_TEXT, "0");
            this.CargarPresupuestos(this.txtFechaDesde.Text,
                                    this.txtFechaHasta.Text,
                                    this.ClienteID.ToString());
            this.FormatearGrilla();
        }

        #endregion Controles Locales

        private void dgvPresupuestos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridView)sender).Columns[e.ColumnIndex].Name == CAMPO_SELECCIONAR)
            {
                this.lblSeleccionados.Text = string.Format(SELECTED_TEXT, GetSelectedRowCount());
            }
        }

        private string GetSelectedRowCount()
        {
            int count = 0;

            if (this.GetListaPresupuestos() != string.Empty)
            {
                count = this.GetListaPresupuestos().Split(',').Length;
            }

            return count.ToString();
        }

        private void dgvPresupuestos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.RowIndex > -1) && ((e.ColumnIndex == (((DataGridView)sender).Columns[CAMPO_MONTO].Index) ||
                                      (e.ColumnIndex == (((DataGridView)sender).Columns[CAMPO_SALDO].Index)))))
            {
                if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_MONEDAABREV].Value.ToString() == MONEDA_GUARANIES)
                    e.CellStyle.Format = FORMATO_MONEDA_GUARANIES_GRILLA;
                else
                    e.CellStyle.Format = FORMATO_MONEDA_OTROS_GRILLA;
            }
        }
    }
}