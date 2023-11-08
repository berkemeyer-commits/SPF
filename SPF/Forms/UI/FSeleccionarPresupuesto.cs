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

#endregion

namespace SPF.Forms.UI
{
    public partial class FSeleccionarPresupuesto : Form
    {
        #region Variables
        BerkeDBEntities DBContext;
        private List<object> filterParam;
        private int ClienteID = -1;
        private string listaPresupuestos = "";
        private string listaPresupuestoIDs = "";
        frmPickBase fPickPresupuesto;
        private BindingList<SeleccionarPresupuestoType> bList;
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
        private const string CAMPO_TRAMITEID        = "TramiteID";
        private const string CAMPO_TRAMITEDESCRIP   = "TramiteDescrip";

        private const string DEFAULT_STRING_PATTERN = "( {0} = {1} )";
        private const string RANGE_STRING_PATTERN   = "( {0} >= {1} AND {0} <= {2} )";
        private const string ESTADO_ANULADO         = "N";
        private const string BROWSE = "BROWSE";
        private const string INSERT = "INSERT";
        private const string EDIT = "EDIT";
        private const string NONE = "NONE";
        private const int ASOCIACION_AUTOMATICA = 0;
        private const int ASOCIACION_MANUAL = 1;
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

        public string ListaPresupuestosID
        {
            set { this.listaPresupuestoIDs = value; }
            get { return this.listaPresupuestoIDs; }
        }
        #endregion Propiedades

        #region Métodos de Inicio
        public FSeleccionarPresupuesto()
        {
            InitializeComponent();
        }

        public FSeleccionarPresupuesto(BerkeDBEntities context, string titulo, string presupuestoID, int mostrarBotones = 1)
        {
            InitializeComponent();
            this.DBContext = context;
            this.Text = titulo;
            this.filterParam = null;
            this.listaPresupuestoIDs = presupuestoID;

            if (mostrarBotones == ASOCIACION_AUTOMATICA)
            {
                this.btnAceptar.Visible = false;
                this.btnCancelar.Visible = false;
                this.btnCerrar.Visible = true;
                this.tSBPresupuesto.Visible = false;
                this.btnAgregarPresup.Visible = false;
                this.btnEliminarPresupuesto.Visible = false;
                this.lblPresupuesto.Visible = false;
                this.dgvPresupuestos.ContextMenuStrip = null;
                this.dgvPresupuestos.AllowUserToDeleteRows = false;
            }
            else
            {
                this.btnAceptar.Visible = true;
                this.btnCancelar.Visible = true;
                this.btnCerrar.Visible = false;
                this.tSBPresupuesto.Enabled = true;
                this.btnAgregarPresup.Visible = true;
                this.btnEliminarPresupuesto.Visible = true;
                this.lblPresupuesto.Visible = true;
                this.dgvPresupuestos.ContextMenuStrip = this.contextMenuStrip1;
                this.dgvPresupuestos.AllowUserToDeleteRows = true;
            }

            this.tSBPresupuesto.KeyMemberWidth = 70;
            this.tSBPresupuesto.ToolTip = "Elegir Presupuesto";
            this.tSBPresupuesto.AceptarClick += tSBPresupuesto_AceptarClick;

            this.toolTip1.SetToolTip(this.btnAgregarPresup, "Asociar Presupuesto");

            this.CargarPresupuestos(this.listaPresupuestoIDs);
        }

        public FSeleccionarPresupuesto(BerkeDBEntities context, string titulo, string presupuestoID, bool mostrarBotones = true)
        {
            InitializeComponent();
            this.DBContext = context;
            this.Text = titulo;
            this.filterParam = null;
            this.listaPresupuestoIDs = presupuestoID;

            if (mostrarBotones)
            {
                this.btnAceptar.Visible = false;
                this.btnCancelar.Visible = false;
                this.btnCerrar.Visible = true;
                this.tSBPresupuesto.Visible = false;
                this.btnAgregarPresup.Visible = false;
                this.btnEliminarPresupuesto.Visible = false;
                this.lblPresupuesto.Visible = false;
                this.dgvPresupuestos.ContextMenuStrip = null;
                this.dgvPresupuestos.AllowUserToDeleteRows = false;
            }
            else
            {
                this.btnAceptar.Visible = true;
                this.btnCancelar.Visible = true;
                this.btnCerrar.Visible = false;
                this.tSBPresupuesto.Enabled = true;
                this.btnAgregarPresup.Visible = true;
                this.btnEliminarPresupuesto.Visible = true;
                this.lblPresupuesto.Visible = true;
                this.dgvPresupuestos.ContextMenuStrip = this.contextMenuStrip1;
                this.dgvPresupuestos.AllowUserToDeleteRows = true;
            }

            this.tSBPresupuesto.KeyMemberWidth = 70;
            this.tSBPresupuesto.ToolTip = "Elegir Presupuesto";
            this.tSBPresupuesto.AceptarClick += tSBPresupuesto_AceptarClick;

            this.toolTip1.SetToolTip(this.btnAgregarPresup, "Asociar Presupuesto");

            this.CargarPresupuestos(this.listaPresupuestoIDs);
        }

        private void FSeleccionarPresupuesto_Load(object sender, EventArgs e)
        {
            if (this.dgvPresupuestos.Rows.Count > 0)
            {
                this.FormatearGrilla();
                this.dgvPresupuestos.CurrentCell = this.dgvPresupuestos.Rows[0].Cells[CAMPO_FECHADOCUMENTO];
                this.dgvPresupuestos.Focus();
            }
        }

        #endregion Métodos de Inicio

        #region Picks
        #region Presupuesto
        private void tSBPresupuesto_AceptarClick(object sender, EventArgs e)
        {
            if (fPickPresupuesto == null)
            {
                fPickPresupuesto = new frmPickBase();
                fPickPresupuesto.AceptarFiltrarClick += fPickPresupuesto_AceptarFiltrarClick;
                fPickPresupuesto.FiltrarClick += fPickPresupuesto_FiltrarClick;
                fPickPresupuesto.Titulo = "Elegir Presupuesto";
                fPickPresupuesto.CampoIDNombre = "PresupuestoCabID";
                fPickPresupuesto.CampoDescripNombre = "Descripcion";
                fPickPresupuesto.LabelCampoID = "ID";
                fPickPresupuesto.LabelCampoDescrip = "Descripción";
                fPickPresupuesto.NombreCampo = "Presupuesto";
                fPickPresupuesto.PermitirFiltroNulo = false;
            }
            fPickPresupuesto.MostrarFiltro();

        }

        private void fPickPresupuesto_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickPresupuesto != null)
            {
                var query = (from pCab in this.DBContext.pc_presupuestocab
                             join tr in this.DBContext.Tramite
                                on pCab.pc_tramiteid equals tr.ID
                             select new PresupuestoFilterType
                             {
                                 PresupuestoCabID = pCab.pc_presupuestocabid,
                                 NroPresupuesto = pCab.pc_nropresupuesto,
                                 TramiteDescripcion = tr.Descrip,
                                 /*Descripcion = pCab.pc_nropresupuesto != null ? pCab.pc_nropresupuesto : "" + 
                                                " - " + pCab.pc_string1 != null ? pCab.pc_string1 : ""+ 
                                                " - " +  tr.Descrip]*/
                                 Descripcion = this.DBContext.GetDocumentoNro(pCab.pc_presupuestocabid).FirstOrDefault() + " - " + tr.Descrip,
                                 Estado = pCab.pc_estado
                             })
                             .Where( a => a.Estado != ESTADO_ANULADO);

                fPickPresupuesto.LoadData<PresupuestoFilterType>(query.AsQueryable(), fPickPresupuesto.GetWhereString());
                //+ " - " + pCab.pc_string1 != null ? pCab.pc_string1 : "" +
            }
        }

        private void fPickPresupuesto_AceptarFiltrarClick(object sender, EventArgs e)
        {
            #region Pick Presupuesto
            this.tSBPresupuesto.DisplayMember = fPickPresupuesto.ValorDescrip;
            this.tSBPresupuesto.KeyMember = fPickPresupuesto.ValorID;
            #endregion Pick Presupuesto
            
            fPickPresupuesto.Close();
            fPickPresupuesto.Dispose();
        }
        #endregion Presupuesto
        #endregion Picks

        #region Métodos Locales
        private void CargarPresupuestos(string presupuestoID)
        {
            if (presupuestoID != "")
            {
                string whereString = this.getWhereString(presupuestoID, CAMPO_PRESUPUESTOCABID);
                var query = (from pCab in this.DBContext.pc_presupuestocab
                             join cli in this.DBContext.Cliente
                                 on pCab.pc_clienteid equals cli.ID
                             join tra in this.DBContext.Tramite
                                on pCab.pc_tramiteid equals tra.ID
                             select new SeleccionarPresupuestoType
                             {
                                 PresupuestoCabID = pCab.pc_presupuestocabid,
                                 //ClienteID = pCab.pc_clienteid,
                                 //ClienteNombre = cli.Nombre,
                                 NroDocumento = this.DBContext.GetDocumentoNro(pCab.pc_presupuestocabid).FirstOrDefault(),
                                 FechaDocumento = this.DBContext.GetFechaDocumento(pCab.pc_presupuestocabid).FirstOrDefault(),
                                 //MontoDocumento = pCab.pc_total,
                                 //SaldoDocumento = pCab.pc_saldo,
                                 EstadoDocumento = pCab.pc_estado,
                                 TramiteID = pCab.pc_tramiteid,
                                 TramiteDescrip = tra.EtiquetaEsp
                             })
                             .Where(whereString)
                             .OrderBy(a => a.FechaDocumento)
                             .ToList();

                bList = new BindingList<SeleccionarPresupuestoType>(query.ToList());

                this.dgvPresupuestos.DataSource = bList;
                this.lblEstado.Text = "Documentos recuperados: " + query.Count.ToString();
                this.FormatearGrilla();

            }
            else
            {
                this.dgvPresupuestos.DataSource = null;
                this.lblEstado.Text = "Documentos recuperados: 0";
            }

            //this.MarcarPresupuestos();
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

            this.dgvPresupuestos.Columns[CAMPO_TRAMITEDESCRIP].HeaderText = "Trámite";
            this.dgvPresupuestos.Columns[CAMPO_TRAMITEDESCRIP].Width = 250;
            this.dgvPresupuestos.Columns[CAMPO_TRAMITEDESCRIP].DisplayIndex = displayIndex;
            this.dgvPresupuestos.Columns[CAMPO_TRAMITEDESCRIP].Visible = true;
            displayIndex++;
            
            //this.dgvPresupuestos.Columns[CAMPO_MONTO].HeaderText = "Monto";
            //this.dgvPresupuestos.Columns[CAMPO_MONTO].Width = 80;
            //this.dgvPresupuestos.Columns[CAMPO_MONTO].DisplayIndex = displayIndex;
            //this.dgvPresupuestos.Columns[CAMPO_MONTO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dgvPresupuestos.Columns[CAMPO_MONTO].Visible = true;
            //displayIndex++;

            //this.dgvPresupuestos.Columns[CAMPO_SALDO].HeaderText = "Saldo";
            //this.dgvPresupuestos.Columns[CAMPO_SALDO].Width = 80;
            //this.dgvPresupuestos.Columns[CAMPO_SALDO].DisplayIndex = displayIndex;
            //this.dgvPresupuestos.Columns[CAMPO_SALDO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dgvPresupuestos.Columns[CAMPO_SALDO].Visible = true;
            //displayIndex++;

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
                Result += Result != "" ? "," + row.Cells[CAMPO_NRODOCUMENTO].Value.ToString() : row.Cells[CAMPO_NRODOCUMENTO].Value.ToString();
            }

            return Result;
        }

        private string GetListaPresupuestosID()
        {
            string Result = "";

            foreach (DataGridViewRow row in this.dgvPresupuestos.Rows)
            {
                Result += Result != "" ? "," + row.Cells[CAMPO_PRESUPUESTOCABID].Value.ToString() : row.Cells[CAMPO_PRESUPUESTOCABID].Value.ToString();
            }

            return Result;
        }

        private string getWhereString(string lista, string clave)
        {
            const string DEFAULT_STRING_PATTERN = "( {0} = {1} )";

            string filterString = "";
            #region ValueList
            string[] listaValores = lista.Split(',');

            //if (listaValores.Length > 1)
            //{
            string gFiltro = "";
            foreach (string e in listaValores)
            {
                if (gFiltro != "")
                    gFiltro += " OR ";

                //if (esFecha)
                //    gFiltro += String.Format(DEFAULT_STRING_PATTERN, this.Clave, this.addComillas(e));
                //else
                gFiltro += String.Format(DEFAULT_STRING_PATTERN, clave, e);
            }
            filterString = " (" + gFiltro + ") ";

            //}
            #endregion ValueList
            return filterString;
        }
        #endregion Métodos Locales

        #region Controles Locales
        private void btnEliminarPresupuesto_Click(object sender, EventArgs e)
        {
            if (this.dgvPresupuestos.CurrentRow != null)
            {
                this.dgvPresupuestos.Rows.RemoveAt(this.dgvPresupuestos.CurrentRow.Index);
            }
        }

        private void tSMIBorrar_Click(object sender, EventArgs e)
        {
            this.btnEliminarPresupuesto.PerformClick();
        }

        private void FSeleccionarPresupuestoNC_VisibleChanged(object sender, EventArgs e)
        {
            if (this.dgvPresupuestos.RowCount > 0)
            {
                this.FormatearGrilla();
            }
            //this.MarcarPresupuestos();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.AceptarClick != null)
            {
                this.listaPresupuestos = this.GetListaPresupuestos();
                this.listaPresupuestoIDs = this.GetListaPresupuestosID();
                this.AceptarClick(sender, e);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarPresup_Click(object sender, EventArgs e)
        {
            if (this.tSBPresupuesto.KeyMember != "")
            {
                this.listaPresupuestoIDs += this.listaPresupuestoIDs != "" ? "," : "";
                this.listaPresupuestoIDs += this.tSBPresupuesto.KeyMember;
                this.CargarPresupuestos(this.listaPresupuestoIDs);
                this.tSBPresupuesto.Clear();
            }
            else
            {
                MessageBox.Show("Debe elegir algún Presupuesto",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }
        }

        #endregion Controles Locales

    }
}