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
    public partial class FSeleccionarPresupuestoNC : Form
    {
        #region Variables
        BerkeDBEntities DBContext;
        private List<object> filterParam;
        private int ClienteID = -1;
        private string listaPresupuestos = "";
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

        private const string DEFAULT_STRING_PATTERN = "( {0} = {1} )";
        private const string RANGE_STRING_PATTERN   = "( {0} >= {1} AND {0} <= {2} )";
        private const string ESTADO_ANULADO         = "N";
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
        #endregion Propiedades

        #region Métodos de Inicio
        public FSeleccionarPresupuestoNC()
        {
            InitializeComponent();
        }

        public FSeleccionarPresupuestoNC(BerkeDBEntities context, string titulo, string fechaDesde, string fechaHasta, int clienteID)
        {
            InitializeComponent();
            this.DBContext = context;
            this.Text = titulo;
            this.filterParam = null;
            this.ClienteID = clienteID;

            #region DateTime Pickers
            this.dtpFechaDesde.Format = DateTimePickerFormat.Short;
            this.dtpFechaDesde.Value = Convert.ToDateTime(fechaDesde);
            this.dtpFechaHasta.Format = DateTimePickerFormat.Short;
            this.dtpFechaHasta.Value = Convert.ToDateTime(fechaHasta);
            #endregion DateTime Pickers

            this.txtFechaDesde.Text = fechaDesde;
            this.txtFechaHasta.Text = fechaHasta;

            this.CargarPresupuestos(fechaDesde, fechaHasta, this.ClienteID.ToString());
        
        }

        private void FSeleccionarPresupuestoNC_Load(object sender, EventArgs e)
        {
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
                         select new
                         {
                             PresupuestoCabID = pCab.pc_presupuestocabid,
                             ClienteID = pCab.pc_clienteid,
                             ClienteNombre = cli.Nombre,
                             NroDocumento = this.DBContext.GetDocumentoNro(pCab.pc_presupuestocabid).FirstOrDefault(),
                             FechaDocumento = this.DBContext.GetFechaDocumento(pCab.pc_presupuestocabid).FirstOrDefault(),
                             MontoDocumento = pCab.pc_total,
                             SaldoDocumento = pCab.pc_saldo,
                             EstadoDocumento = pCab.pc_estado
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
                            "(" + CAMPO_ESTADODOCUMENTO + " != \"" + ESTADO_ANULADO + "\")";
                            
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

            DataGridViewCheckBoxColumn doWork = new DataGridViewCheckBoxColumn();
            doWork.HeaderText = CAMPO_SELECCIONAR;
            doWork.Name = CAMPO_SELECCIONAR;
            doWork.FalseValue = false;
            doWork.TrueValue = true;
            doWork.ReadOnly = false;
            doWork.Width = 80;
            this.dgvPresupuestos.Columns.Insert(0, doWork);
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
                    Result += Result != "" ? ", " + row.Cells[CAMPO_NRODOCUMENTO].Value.ToString() : row.Cells[CAMPO_NRODOCUMENTO].Value.ToString();
                }
            }

            return Result;
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
                this.listaPresupuestos = this.GetListaPresupuestos();
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
            this.CargarPresupuestos(this.txtFechaDesde.Text,
                                    this.txtFechaHasta.Text,
                                    this.ClienteID.ToString());
            this.FormatearGrilla();
        }

        #endregion Controles Locales
    }
}