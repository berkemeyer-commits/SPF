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
using SPF.Forms.Base;
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
    public partial class FSelecPresupFactura : Form
    {
        #region Variables
        BerkeDBEntities DBContext;
        frmPickBase fPickCliente;
        frmPickBase fPickBancoCheque;
        private List<object> filterParam;
        private string listaPresupuestos = string.Empty;
        private string listaPresupuestosIDs = string.Empty;
        private string listaNroBoletaDeps = String.Empty;
        private string listaMontosCobros = string.Empty;
        private string listaCobrosIDs = string.Empty;
        private int clienteID = -1;
        private int monedaID = -1;
        private string monedaDescrip = string.Empty;
        private string monedaAbrev = string.Empty;
        private Nullable<DateTime> cobroFechaDeposito = null;
        #endregion Variables

        #region Constantes
        private const string CAMPO_PRESUPUESTOCABID = "PresupuestoCabID";
        private const string CAMPO_FACTURACABID     = "FacturaCabID";
        private const string CAMPO_NRODOCUMENTO     = "NroDocumento";
        private const string CAMPO_NROPRESUPUESTO   = "NroPresupuesto";
        private const string CAMPO_NROFACTURA       = "NroFactura";
        private const string CAMPO_FECHADOCUMENTO   = "FechaDocumento";
        private const string CAMPO_MONTO            = "MontoDocumento";
        private const string CAMPO_SALDO            = "SaldoDocumento";
        private const string CAMPO_SELECCIONAR      = "Seleccionar";
        private const string CAMPO_CLIENTEID        = "ClienteID";
        private const string CAMPO_CLIENTENOMBRE    = "ClienteNombre";
        private const string CAMPO_ESTADODOCUMENTO  = "EstadoDocumento";
        private const string CAMPO_COBROFECHADEPOSITO = "CobroFechaDeposito";
        private const string CAMPO_COBROFECHACOBRO = "CobroFechaCobro";
        private const string CAMPO_COBRONROBOLETADEPOSITO= "CobroNroBoletaDeposito";
        private const string CAMPO_COBROCHEQUENRO = "CobroNroCheque";
        private const string CAMPO_COBROBANCOCHEQUEID = "CobroBancoChequeID";
        private const string CAMPO_COBROBANCOCHEQUENOMBRE = "CobroBancoChequeNombre";
        private const string CAMPO_COBRONROBOLETACHEQUE = "CobroNroCheque";
        private const string CAMPO_COBROANULADO = "CobroAnulado";
        private const string CAMPO_COBROMONTO = "CobroMonto";
        private const string CAMPO_MONEDAID = "MonedaID";
        private const string CAMPO_MONEDAABREV = "MonedaAbrev";
        private const string CAMPO_MONEDADESCRIP = "MonedaDescrip";
        private const string CAMPO_TOTALFACTURADOSF = "TotalFacturadoSF";
        private const string CAMPO_COBROID = "CobroID";
        
        private const string DEFAULT_STRING_PATTERN = "( {0} = {1} )";
        private const string NOT_EQUAL_STRING_PATTERN = "( {0} != {1} )";
        private const string RANGE_STRING_PATTERN   = "( {0} >= {1} AND {0} <= {2} )";
        private const string CONTAINS_STRING_PATTERN = "({0}.Contains(\"{1}\"))";
        private const string NULL_VALUE = "null";
        private const string AND_OPERATOR = " AND ";
        private const string OR_OPERATOR = " OR ";
        private const string ESTADO_ANULADO         = "N";
        private const string GUARANIES = "GUARANIES";
        private const string FORMATO_MONEDA_GUARANIES_GRILLA = "N0";
        private const string FORMATO_MONEDA_OTROS_GRILLA = "N2";

        private const string DESMARCAR = "Desmarcar Todo";
        private const string MARCAR = "Marcar Todo";            
        #endregion Constantes

        #region Eventos personalizados
        public event EventHandler AceptarClick;
        #endregion Eventos personalizados

        #region Propiedades
        public string ListaPresupuestos
        {
            set { this.listaPresupuestos = value; }
            //get { return string.Join(", ", this.listaPresupuestos.Trim().Split(',').Distinct().ToArray()); }
            get { return string.Join(",", this.listaPresupuestos.Trim().Split(',').Distinct().ToArray()); }
        }

        public string ListaPresupuestosIDs
        {
            set { this.listaPresupuestosIDs = value; }
            //get { return string.Join(", ", this.listaPresupuestosIDs.Split(',').Distinct().ToArray()); }
            get { return string.Join(", ", this.listaPresupuestosIDs); }
        }

        public string ListaNroBoletaDeps
        {
            set { this.listaNroBoletaDeps = value; }
            get { return string.Join(", ",  this.listaNroBoletaDeps.Split(',').Distinct().ToArray()); }
        }

        public string ListaMontosCobros
        {
            set { this.listaMontosCobros = value; }
            get { return this.listaMontosCobros; }
        }

        public string ListaCobrosIDs
        {
            set { this.listaCobrosIDs = value; }
            get { return string.Join(", ", this.listaCobrosIDs.Split(',').Distinct().ToArray()); }
        }
        
        public int ClienteID
        {
            set { this.clienteID = value; }
            get { return this.clienteID; }
        }

        public int MonedaID
        {
            set { this.monedaID = value; }
            get { return this.monedaID; }
        }

        public string MonedaDescrip
        {
            set { this.monedaDescrip = value; }
            get { return this.monedaDescrip; }
        }

        public string MonedaAbrev
        {
            set { this.monedaAbrev = value; }
            get { return this.monedaAbrev; }
        }

        public Nullable<DateTime> CobroFechaDeposito
        {
            set { this.cobroFechaDeposito = value; }
            get 
            {
                if (this.cobroFechaDeposito.HasValue)
                    return this.cobroFechaDeposito.Value;
                else return null;
            }
        }
        #endregion Propiedades

        #region Métodos de Inicio
        public FSelecPresupFactura()
        {
            InitializeComponent();
        }

        public FSelecPresupFactura(BerkeDBEntities context, string titulo)
        {
            InitializeComponent();
            this.DBContext = context;
            this.Text = titulo;
            this.filterParam = null;

            //this.SetDateTimePicks();
            this.btnMarcarTodo.Visible = false;
            this.btnMarcarTodo.Text = MARCAR;

            #region Inicializar TextSearchBox
            this.tSBCliente.KeyMemberWidth = 50;
            this.tSBCliente.ToolTip = "Elegir Cliente";
            this.tSBCliente.AceptarClick += tSBCliente_AceptarClick;
            this.tSBCliente.MakeDescriptionEditable();
            this.tSBCliente.DisplayMemberLeave += tSBCliente_DisplayMemberLeave;

            this.tSBBancoCheque.KeyMemberWidth = 50;
            this.tSBBancoCheque.ToolTip = "Elegir Banco Cheque";
            this.tSBBancoCheque.AceptarClick += tSBBancoCheque_AceptarClick;
            this.tSBBancoCheque.MakeDescriptionEditable();
            this.tSBBancoCheque.DisplayMemberLeave += tSBBancoCheque_DisplayMemberLeave;
            #endregion Inicializar TextSearchBox
        }

        private void FSeleccionarPresupuestoNC_Load(object sender, EventArgs e)
        {
            if (this.dgvPresupuestos.RowCount > 0)
                    this.FormatearGrilla();
        }

        #endregion Métodos de Inicio

        #region Picks

        #region Cliente
        private void tSBCliente_AceptarClick(object sender, EventArgs e)
        {
            if (fPickCliente == null)
            {
                this.SettSBCliente();
            }
            fPickCliente.MostrarFiltro();
        }

        private void SettSBCliente()
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

        private void tSBCliente_DisplayMemberLeave(object sender, EventArgs e)
        {
            if (this.fPickCliente == null)
            {
                this.SettSBCliente();
            }

            if (this.tSBCliente.DisplayMember != string.Empty)
            {
                this.fPickCliente.SetDescripFilter = this.tSBCliente.DisplayMember;
                this.fPickCliente_FiltrarClick(sender, e);
                if ((this.fPickCliente.RowCount > 0) && (this.tSBCliente.KeyMember == string.Empty))
                {
                    this.fPickCliente.MostrarFiltro(true);
                }
                else if ((this.fPickCliente.RowCount == 0) && (this.tSBCliente.KeyMember != string.Empty))
                {
                    this.tSBCliente.KeyMember = string.Empty;
                }
            }
        }

        #endregion Cliente

        #region Banco Cheque
        private void tSBBancoCheque_AceptarClick(object sender, EventArgs e)
        {
            if (fPickBancoCheque == null)
            {
                this.SettSBBancoCheque();
            }
            fPickBancoCheque.MostrarFiltro();
        }

        private void SettSBBancoCheque()
        {
            fPickBancoCheque = new frmPickBase();
            fPickBancoCheque.AceptarFiltrarClick += fPickBancoCheque_AceptarFiltrarClick;
            fPickBancoCheque.FiltrarClick += fPickBancoCheque_FiltrarClick;
            fPickBancoCheque.Titulo = "Elegir Banco Cheque";
            fPickBancoCheque.CampoIDNombre = "ba_bancoid";
            fPickBancoCheque.CampoDescripNombre = "ba_descripcion";
            fPickBancoCheque.LabelCampoID = "ID";
            fPickBancoCheque.LabelCampoDescrip = "Nombre";
            fPickBancoCheque.NombreCampo = "Banco Cheque";
            fPickBancoCheque.PermitirFiltroNulo = false;
        }

        private void fPickBancoCheque_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickBancoCheque != null)
            {
                fPickBancoCheque.LoadData<ba_banco>(this.DBContext.ba_banco, fPickBancoCheque.GetWhereString());
            }
        }

        private void fPickBancoCheque_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBBancoCheque.DisplayMember = fPickBancoCheque.ValorDescrip;
            this.tSBBancoCheque.KeyMember = fPickBancoCheque.ValorID;

            fPickBancoCheque.Close();
            fPickBancoCheque.Dispose();
        }

        private void tSBBancoCheque_DisplayMemberLeave(object sender, EventArgs e)
        {
            if (this.fPickBancoCheque == null)
            {
                this.SettSBBancoCheque();
            }

            if (this.tSBBancoCheque.DisplayMember != string.Empty)
            {
                this.fPickBancoCheque.SetDescripFilter = this.tSBBancoCheque.DisplayMember;
                this.fPickBancoCheque_FiltrarClick(sender, e);
                if ((this.fPickBancoCheque.RowCount > 0) && (this.tSBBancoCheque.KeyMember == string.Empty))
                {
                    this.fPickBancoCheque.MostrarFiltro(true);
                }
                else if ((this.fPickBancoCheque.RowCount == 0) && (this.tSBBancoCheque.KeyMember != string.Empty))
                {
                    this.tSBBancoCheque.KeyMember = string.Empty;
                }
            }
        }
        #endregion Banco Cheque

        #endregion Picks

        #region Métodos Locales
        private void SetDateTimePicks()
        {
            string[] rangoFechas = this.GetRangoFechas(DateTime.Now);
            this.dtpFechaDesde.Format = DateTimePickerFormat.Short;
            this.dtpFechaDesde.Value = Convert.ToDateTime(rangoFechas[0]);
            this.dtpFechaHasta.Format = DateTimePickerFormat.Short;
            this.dtpFechaHasta.Value = Convert.ToDateTime(rangoFechas[1]);
            this.txtFechaDesde.Text = rangoFechas[0];
            this.txtFechaHasta.Text = rangoFechas[1];
        }

        private string[] GetRangoFechas(DateTime fecha)
        {
            List<string> Result = new List<string>();

            DateTime fechaDesde = new DateTime(fecha.AddMonths(-2).Year, fecha.AddMonths(-2).Month, 1);
            Result.Add(fechaDesde.ToShortDateString());

            DateTime fechaHasta = new DateTime(fecha.Year, fecha.Month, DateTime.DaysInMonth(fecha.Year, fecha.Month));
            Result.Add(fechaHasta.ToShortDateString());

            return Result.ToArray();
        }

        private void CargarPresupuestos()
        {
            string whereString = this.GetWhere();
            //string whereString = "";
            var query = (from pCab in this.DBContext.pc_presupuestocab
                         join cli in this.DBContext.Cliente
                             on pCab.pc_clienteid equals cli.ID
                         join mon in this.DBContext.Moneda
                             on pCab.pc_monedaid equals mon.ID
                         join cp in this.DBContext.pp_pagopresupuesto
                            on pCab.pc_presupuestocabid equals cp.pp_presupuestocabid into cp_pCab
                            from cp in cp_pCab.DefaultIfEmpty()
                         join bd in this.DBContext.ba_banco
                            on cp.pp_bancochequeid equals bd.ba_bancoid into bd_cp
                            from bd in bd_cp.DefaultIfEmpty()
                         select new SelPresupFactura
                         {
                             PresupuestoCabID = pCab.pc_presupuestocabid,
                             FacturaCabID = pCab.pc_facturacabid,
                             ClienteID = pCab.pc_clienteid,
                             ClienteNombre = cli.Nombre,
                             NroDocumento = this.DBContext.GetDocumentoNro(pCab.pc_presupuestocabid).FirstOrDefault(),
                             NroPresupuesto = pCab.pc_nropresupuesto,
                             NroFactura = pCab.pc_string1,
                             FechaDocumento = this.DBContext.GetFechaDocumento(pCab.pc_presupuestocabid).FirstOrDefault(),
                             MontoDocumento = pCab.pc_total,
                             SaldoDocumento = pCab.pc_saldo,
                             EstadoDocumento = pCab.pc_estado,
                             MonedaID = pCab.pc_monedaid,
                             MonedaAbrev = mon.AbrevMoneda,
                             MonedaDescrip = mon.Descripcion,
                             CobroFechaDeposito = cp.pp_fechaboletadeposito,
                             CobroFechaCobro = cp.pp_fechapago,
                             CobroNroBoletaDeposito = cp.pp_nroboletadeposito,
                             CobroNroCheque = cp.pp_nrocheque,
                             CobroBancoChequeID = cp.pp_bancochequeid,
                             CobroBancoChequeNombre = bd.ba_descripcion,
                             CobroAnulado = cp.pp_anulado,
                             CobroMonto = cp.pp_montopago,
                             TotalFacturadoSF = this.DBContext.GetTotalPresupFactura(pCab.pc_presupuestocabid).FirstOrDefault().Total,
                             CobroID = cp.pp_pagopresupuestoid
                         })
                         .Where(whereString, this.filterParam != null ? this.filterParam.ToArray() : null)
                         .Where(a => !this.DBContext.ExisteCobroAsociado(a.CobroID, a.PresupuestoCabID).FirstOrDefault().Value)
                         .OrderBy(a => a.FechaDocumento)
                         .ToList();

            //var missing = dbcontext.Alumnos.Where(a => !a.Materias.Any(m => m.MateriaID == XXX));

            this.dgvPresupuestos.DataSource = query;
            this.lblEstado.Text = "Documentos recuperados: " + query.Count.ToString();

            this.btnMarcarTodo.Visible = query.Count > 0;
            this.btnMarcarTodo.Text = MARCAR;

            //if (query.Count > 0)
            //{
            //    //this.tSBCliente.KeyMember = query.First().ClienteID.ToString();
            //    //this.tSBCliente.DisplayMember = query.First().ClienteNombre;
            //    //this.MarcarPresupuestos();
                
            //}
        }

        private string GetWhere(string fechaDesde, string fechaHasta, string clienteID)
        {
            string Result = String.Format(DEFAULT_STRING_PATTERN, CAMPO_CLIENTEID, clienteID) + " AND " +
                            this.getParseString(String.Format(RANGE_STRING_PATTERN, CAMPO_FECHADOCUMENTO, "\"" + fechaDesde + "\"", "\"" + fechaHasta + "\"")) + " AND " +
                            "(" + CAMPO_ESTADODOCUMENTO + " != \"" + ESTADO_ANULADO + "\")" + " AND " +
                            "((" + CAMPO_COBROANULADO + " == null) OR (" + CAMPO_COBROANULADO + " == false))";// +
                            //" AND (" + CAMPO_TOTALFACTURADOSF + " <= " + CAMPO_MONTO + ") "; 
                            
            return Result;
        }

        private string GetWhere()
        {
            string whereString = string.Empty;

            whereString += String.Format(NOT_EQUAL_STRING_PATTERN, CAMPO_ESTADODOCUMENTO, "\"" + ESTADO_ANULADO + "\"") +
                                        " AND ((" + CAMPO_COBROANULADO + " == null) OR (" + CAMPO_COBROANULADO + " == false))" +
                                        " AND (" + CAMPO_TOTALFACTURADOSF + " < " + CAMPO_MONTO + ") ";

            //whereString += (whereString != string.Empty ? AND_OPERATOR : string.Empty) +
            //                String.Format(DEFAULT_STRING_PATTERN, CAMPO_FACTURACABID, NULL_VALUE);

            if (this.txtNroBoletaDeposito.Text.TrimEnd() != string.Empty)
                whereString += (whereString != string.Empty ? AND_OPERATOR : string.Empty) +
                                String.Format(CONTAINS_STRING_PATTERN, CAMPO_COBRONROBOLETADEPOSITO, this.txtNroBoletaDeposito.Text);

            if (this.txtNroDocumento.Text.TrimEnd() != string.Empty)
            {
                //whereString += (whereString != string.Empty ? AND_OPERATOR : string.Empty) +
                //                string.Format(CONTAINS_STRING_PATTERN, CAMPO_NRODOCUMENTO, this.txtNroDocumento.Text);
                whereString += (whereString != string.Empty ? AND_OPERATOR : string.Empty) +
                                string.Format(CONTAINS_STRING_PATTERN, CAMPO_NROPRESUPUESTO, this.txtNroDocumento.Text) + OR_OPERATOR +
                                string.Format(CONTAINS_STRING_PATTERN, CAMPO_NROFACTURA, this.txtNroDocumento.Text);
            }

            if (this.tSBCliente.KeyMember != string.Empty)
            {
                whereString += (whereString != string.Empty ? AND_OPERATOR : string.Empty) +
                                string.Format(DEFAULT_STRING_PATTERN, CAMPO_CLIENTEID, this.tSBCliente.KeyMember);
            }

            if ((this.txtFechaDesde.Text != string.Empty) && (this.txtFechaHasta.Text != string.Empty))
            {
                whereString += (whereString != string.Empty ? AND_OPERATOR : string.Empty) +
                                this.getParseString(String.Format(RANGE_STRING_PATTERN, CAMPO_FECHADOCUMENTO, "\"" + this.txtFechaDesde.Text + "\"", "\"" + this.txtFechaHasta.Text + "\""));

            }

            //ID Documento
            if (this.txtIDDocumento.Text != string.Empty)
            {
                whereString += (whereString != string.Empty ? AND_OPERATOR : string.Empty) +
                                string.Format(DEFAULT_STRING_PATTERN, CAMPO_PRESUPUESTOCABID, this.txtIDDocumento.Text);
            }
            //Fecha Depósito
            if ((this.txtFechaDepositoDesde.Text != string.Empty) && (this.txtFechaDepositoHasta.Text != string.Empty))
            {
                whereString += (whereString != string.Empty ? AND_OPERATOR : string.Empty) +
                                this.getParseString(String.Format(RANGE_STRING_PATTERN, CAMPO_COBROFECHADEPOSITO, "\"" + this.txtFechaDepositoDesde.Text + "\"", "\"" + this.txtFechaDepositoHasta.Text + "\""));

            }
            //N° Cheque
            if (this.txtNroCheque.Text.TrimEnd() != string.Empty)
            {
                whereString += (whereString != string.Empty ? AND_OPERATOR : string.Empty) +
                                string.Format(CONTAINS_STRING_PATTERN, CAMPO_COBROCHEQUENRO, this.txtNroCheque.Text);
            }
            //Banco Cheque
            if (this.tSBBancoCheque.KeyMember != string.Empty)
            {
                whereString += (whereString != string.Empty ? AND_OPERATOR : string.Empty) +
                                string.Format(DEFAULT_STRING_PATTERN, CAMPO_COBROBANCOCHEQUEID, this.tSBBancoCheque.KeyMember);
            }
            //Fecha Cobro
            if ((this.txtFechaCobroDesde.Text != string.Empty) && (this.txtFechaCobroHasta.Text != string.Empty))
            {
                whereString += (whereString != string.Empty ? AND_OPERATOR : string.Empty) +
                                this.getParseString(String.Format(RANGE_STRING_PATTERN, CAMPO_COBROFECHACOBRO, "\"" + this.txtFechaCobroDesde.Text + "\"", "\"" + this.txtFechaCobroHasta.Text + "\""));

            }


            return whereString;
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
            this.dgvPresupuestos.ItemsPerPage = 8;
            this.dgvPresupuestos.ShowCellToolTips = true;
            this.dgvPresupuestos.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvPresupuestos.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvPresupuestos.DefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvPresupuestos.DefaultCellStyle.BackColor = Color.Transparent;

            this.dgvPresupuestos.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            
            int displayIndex = 0;

            //this.dgvPresupuestos.Columns[CAMPO_FECHADOCUMENTO].HeaderText = "Fec. Documento";
            //this.dgvPresupuestos.Columns[CAMPO_FECHADOCUMENTO].Width = 120;
            //this.dgvPresupuestos.Columns[CAMPO_FECHADOCUMENTO].DisplayIndex = displayIndex;
            //this.dgvPresupuestos.Columns[CAMPO_FECHADOCUMENTO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dgvPresupuestos.Columns[CAMPO_FECHADOCUMENTO].Visible = true;
            //displayIndex++;

            this.dgvPresupuestos.Columns[CAMPO_CLIENTENOMBRE].HeaderText = "Cliente";
            this.dgvPresupuestos.Columns[CAMPO_CLIENTENOMBRE].Width = 250;
            this.dgvPresupuestos.Columns[CAMPO_CLIENTENOMBRE].DisplayIndex = displayIndex;
            this.dgvPresupuestos.Columns[CAMPO_CLIENTENOMBRE].Visible = true;
            displayIndex++;

            this.dgvPresupuestos.Columns[CAMPO_FECHADOCUMENTO].HeaderText = "Fec. Doc.";
            this.dgvPresupuestos.Columns[CAMPO_FECHADOCUMENTO].Width = 80;
            this.dgvPresupuestos.Columns[CAMPO_FECHADOCUMENTO].DisplayIndex = displayIndex;
            this.dgvPresupuestos.Columns[CAMPO_FECHADOCUMENTO].Visible = true;
            displayIndex++;

            this.dgvPresupuestos.Columns[CAMPO_NRODOCUMENTO].HeaderText = "N° Documento";
            this.dgvPresupuestos.Columns[CAMPO_NRODOCUMENTO].Width = 100;
            this.dgvPresupuestos.Columns[CAMPO_NRODOCUMENTO].DisplayIndex = displayIndex;
            this.dgvPresupuestos.Columns[CAMPO_NRODOCUMENTO].Visible = true;
            displayIndex++;

            this.dgvPresupuestos.Columns[CAMPO_MONEDAABREV].HeaderText = "Moneda";
            this.dgvPresupuestos.Columns[CAMPO_MONEDAABREV].Width = 60;
            this.dgvPresupuestos.Columns[CAMPO_MONEDAABREV].DisplayIndex = displayIndex;
            this.dgvPresupuestos.Columns[CAMPO_MONEDAABREV].Visible = true;
            displayIndex++;

            this.dgvPresupuestos.Columns[CAMPO_MONTO].HeaderText = "Monto";
            this.dgvPresupuestos.Columns[CAMPO_MONTO].Width = 80;
            this.dgvPresupuestos.Columns[CAMPO_MONTO].DisplayIndex = displayIndex;
            this.dgvPresupuestos.Columns[CAMPO_MONTO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvPresupuestos.Columns[CAMPO_MONTO].Visible = true;
            displayIndex++;

            this.dgvPresupuestos.Columns[CAMPO_COBROMONTO].HeaderText = "Monto Cobro";
            this.dgvPresupuestos.Columns[CAMPO_COBROMONTO].Width = 90;
            this.dgvPresupuestos.Columns[CAMPO_COBROMONTO].DisplayIndex = displayIndex;
            this.dgvPresupuestos.Columns[CAMPO_COBROMONTO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvPresupuestos.Columns[CAMPO_COBROMONTO].Visible = true;
            displayIndex++;

            this.dgvPresupuestos.Columns[CAMPO_TOTALFACTURADOSF].HeaderText = "Total Facturado";
            this.dgvPresupuestos.Columns[CAMPO_TOTALFACTURADOSF].Width = 120;
            this.dgvPresupuestos.Columns[CAMPO_TOTALFACTURADOSF].DisplayIndex = displayIndex;
            this.dgvPresupuestos.Columns[CAMPO_TOTALFACTURADOSF].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvPresupuestos.Columns[CAMPO_TOTALFACTURADOSF].Visible = true;
            displayIndex++;

            this.dgvPresupuestos.Columns[CAMPO_COBRONROBOLETADEPOSITO].HeaderText = "Boletas";
            this.dgvPresupuestos.Columns[CAMPO_COBRONROBOLETADEPOSITO].Width = 90;
            this.dgvPresupuestos.Columns[CAMPO_COBRONROBOLETADEPOSITO].DisplayIndex = displayIndex;
            this.dgvPresupuestos.Columns[CAMPO_COBRONROBOLETADEPOSITO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvPresupuestos.Columns[CAMPO_COBRONROBOLETADEPOSITO].Visible = true;
            displayIndex++;
            
            //this.dgvPresupuestos.Columns[CAMPO_SALDO].HeaderText = "Saldo";
            //this.dgvPresupuestos.Columns[CAMPO_SALDO].Width = 80;
            //this.dgvPresupuestos.Columns[CAMPO_SALDO].DisplayIndex = displayIndex;
            //this.dgvPresupuestos.Columns[CAMPO_SALDO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dgvPresupuestos.Columns[CAMPO_SALDO].Visible = true;
            //displayIndex++;

            this.dgvPresupuestos.Columns[CAMPO_COBROFECHACOBRO].HeaderText = "Fecha Cobro";
            this.dgvPresupuestos.Columns[CAMPO_COBROFECHACOBRO].Width = 100;
            this.dgvPresupuestos.Columns[CAMPO_COBROFECHACOBRO].DisplayIndex = displayIndex;
            this.dgvPresupuestos.Columns[CAMPO_COBROFECHACOBRO].Visible = true;
            displayIndex++;

            this.dgvPresupuestos.Columns[CAMPO_COBROFECHADEPOSITO].HeaderText = "Fec. Bol. Dép.";
            this.dgvPresupuestos.Columns[CAMPO_COBROFECHADEPOSITO].Width = 100;
            this.dgvPresupuestos.Columns[CAMPO_COBROFECHADEPOSITO].DisplayIndex = displayIndex;
            this.dgvPresupuestos.Columns[CAMPO_COBROFECHADEPOSITO].Visible = true;
            displayIndex++;

            this.dgvPresupuestos.Columns[CAMPO_COBRONROBOLETADEPOSITO].HeaderText = "N° Bol. Dép.";
            this.dgvPresupuestos.Columns[CAMPO_COBRONROBOLETADEPOSITO].Width = 100;
            this.dgvPresupuestos.Columns[CAMPO_COBRONROBOLETADEPOSITO].DisplayIndex = displayIndex;
            this.dgvPresupuestos.Columns[CAMPO_COBRONROBOLETADEPOSITO].Visible = true;
            displayIndex++;

            this.dgvPresupuestos.Columns[CAMPO_COBROCHEQUENRO].HeaderText = "N° Cheque";
            this.dgvPresupuestos.Columns[CAMPO_COBROCHEQUENRO].Width = 100;
            this.dgvPresupuestos.Columns[CAMPO_COBROCHEQUENRO].DisplayIndex = displayIndex;
            this.dgvPresupuestos.Columns[CAMPO_COBROCHEQUENRO].Visible = true;
            displayIndex++;

            this.dgvPresupuestos.Columns[CAMPO_COBROBANCOCHEQUENOMBRE].HeaderText = "Banco Cheque";
            this.dgvPresupuestos.Columns[CAMPO_COBROBANCOCHEQUENOMBRE].Width = 250;
            this.dgvPresupuestos.Columns[CAMPO_COBROBANCOCHEQUENOMBRE].DisplayIndex = displayIndex;
            this.dgvPresupuestos.Columns[CAMPO_COBROBANCOCHEQUENOMBRE].Visible = true;
            displayIndex++;

            this.dgvPresupuestos.Columns[CAMPO_PRESUPUESTOCABID].HeaderText = "Presup. ID";
            this.dgvPresupuestos.Columns[CAMPO_PRESUPUESTOCABID].Width = 80;
            this.dgvPresupuestos.Columns[CAMPO_PRESUPUESTOCABID].DisplayIndex = displayIndex;
            this.dgvPresupuestos.Columns[CAMPO_PRESUPUESTOCABID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvPresupuestos.Columns[CAMPO_PRESUPUESTOCABID].Visible = true;
            displayIndex++;

            this.dgvPresupuestos.Columns[CAMPO_COBROID].HeaderText = "Cobro ID";
            this.dgvPresupuestos.Columns[CAMPO_COBROID].Width = 80;
            this.dgvPresupuestos.Columns[CAMPO_COBROID].DisplayIndex = displayIndex;
            this.dgvPresupuestos.Columns[CAMPO_COBROID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvPresupuestos.Columns[CAMPO_COBROID].Visible = true;
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

        private void GetListaPresupuestos()
        {
            //string Result = "";
            
            foreach (DataGridViewRow row in this.dgvPresupuestos.Rows)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)this.dgvPresupuestos.Rows[row.Index].Cells[CAMPO_SELECCIONAR];
                if ((checkCell.Value != null) && ((bool)checkCell.Value))
                {
                    //Result += Result != "" ? ", " + row.Cells[CAMPO_NRODOCUMENTO].Value.ToString() : row.Cells[CAMPO_NRODOCUMENTO].Value.ToString();

                    if (this.ClienteID == -1)
                        this.ClienteID = Convert.ToInt32(row.Cells[CAMPO_CLIENTEID].Value.ToString());

                    if (this.MonedaID == -1)
                    {
                        this.MonedaID = Convert.ToInt32(row.Cells[CAMPO_MONEDAID].Value.ToString());
                        this.MonedaDescrip = row.Cells[CAMPO_MONEDADESCRIP].Value.ToString();
                        this.MonedaAbrev = row.Cells[CAMPO_MONEDAABREV].Value.ToString();
                    }

                    if ((this.CobroFechaDeposito == null) && (row.Cells[CAMPO_COBROFECHADEPOSITO].Value != null))
                        this.CobroFechaDeposito = Convert.ToDateTime(row.Cells[CAMPO_COBROFECHADEPOSITO].Value.ToString());

                    this.ListaPresupuestos += this.ListaPresupuestos != "" && row.Cells[CAMPO_NRODOCUMENTO].Value.ToString().Trim() != string.Empty ? "," + row.Cells[CAMPO_NRODOCUMENTO].Value.ToString().Trim() : row.Cells[CAMPO_NRODOCUMENTO].Value.ToString().Trim();
                    this.ListaPresupuestosIDs += this.ListaPresupuestosIDs != "" ? "," + row.Cells[CAMPO_PRESUPUESTOCABID].Value.ToString() : row.Cells[CAMPO_PRESUPUESTOCABID].Value.ToString();


                    string cobroID = (row.Cells[CAMPO_COBROID].Value != null && row.Cells[CAMPO_COBROID].Value.ToString().Trim() != string.Empty) ? row.Cells[CAMPO_COBROID].Value.ToString() : "-1";
                    this.ListaCobrosIDs += this.ListaCobrosIDs != "" ? ";" + cobroID : cobroID;
                    //this.ListaMontosCobros += this.ListaMontosCobros != "" ? ";" + row.Cells[CAMPO_COBROMONTO].Value.ToString() : row.Cells[CAMPO_COBROMONTO].Value.ToString();

                    this.ListaMontosCobros += this.ListaMontosCobros != "" ? ";" : string.Empty;

                    if (Convert.ToDecimal(row.Cells[CAMPO_COBROMONTO].Value) > 0)
                        this.ListaMontosCobros += row.Cells[CAMPO_COBROMONTO].Value.ToString();
                    else this.ListaMontosCobros += row.Cells[CAMPO_MONTO].Value.ToString();

                    if (row.Cells[CAMPO_COBRONROBOLETADEPOSITO].Value != null)
                    {
                        this.ListaNroBoletaDeps += this.ListaNroBoletaDeps != "" ? "," + row.Cells[CAMPO_COBRONROBOLETADEPOSITO].Value.ToString() : row.Cells[CAMPO_COBRONROBOLETADEPOSITO].Value.ToString();
                    }
                    //this.ListaNroBoletaDeps += this.ListaNroBoletaDeps != "" && row.Cells[CAMPO_COBRONROBOLETADEPOSITO].Value != null ? ", " + row.Cells[CAMPO_COBRONROBOLETADEPOSITO].Value.ToString() : row.Cells[CAMPO_COBRONROBOLETADEPOSITO].Value.ToString();
                }
            }

            //return Result;
        }
        #endregion Métodos Locales

        #region Controles Locales
        private void FSeleccionarPresupuestoNC_VisibleChanged(object sender, EventArgs e)
        {
            if (this.dgvPresupuestos.RowCount > 0)
            {
                this.FormatearGrilla();
                this.MarcarPresupuestos();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.AceptarClick != null)
            {
                //this.listaPresupuestos = this.GetListaPresupuestos();
                this.ClienteID = -1;
                this.MonedaID = -1;
                this.CobroFechaDeposito = null;
                this.ListaPresupuestos = string.Empty;
                this.ListaPresupuestosIDs = string.Empty;
                this.ListaMontosCobros = string.Empty;
                this.GetListaPresupuestos();
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
            if ((this.txtNroDocumento.Text == string.Empty) && (this.txtIDDocumento.Text == string.Empty) && (this.txtFechaDesde.Text == string.Empty)
                && (this.txtFechaHasta.Text == string.Empty) && (this.tSBCliente.KeyMember == string.Empty) && (this.txtNroBoletaDeposito.Text == string.Empty)
                && (this.txtFechaDepositoDesde.Text == string.Empty) && (this.txtFechaDepositoHasta.Text == string.Empty)
                && (this.txtNroCheque.Text == string.Empty) && (this.tSBBancoCheque.KeyMember == string.Empty)
                && (this.txtFechaCobroDesde.Text == string.Empty) && (this.txtFechaCobroHasta.Text == string.Empty))
            {
                MessageBox.Show("Debe ingresar algún filtro para realizar la búsqueda",
                               "Información",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return;
            }
            
            if (((this.txtFechaDepositoDesde.Text != string.Empty) && (this.txtFechaDepositoHasta.Text == string.Empty)) ||
                ((this.txtFechaDepositoDesde.Text == string.Empty) && (this.txtFechaDepositoHasta.Text != string.Empty)))
            {
                MessageBox.Show("Debe ingresar un rango de fechas de depósito válido.",
                               "Información",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return;
            }
            
            if (((this.txtFechaDesde.Text != string.Empty) && (this.txtFechaHasta.Text == string.Empty)) ||
                ((this.txtFechaDesde.Text == string.Empty) && (this.txtFechaHasta.Text != string.Empty)))
            {
                MessageBox.Show("Debe ingresar un rango de fechas de generación válido.",
                               "Información",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return;
            }

            if (((this.txtFechaCobroDesde.Text != string.Empty) && (this.txtFechaCobroHasta.Text == string.Empty)) ||
                ((this.txtFechaCobroDesde.Text == string.Empty) && (this.txtFechaCobroHasta.Text != string.Empty)))
            {
                MessageBox.Show("Debe ingresar un rango de fechas de cobro válido.",
                               "Información",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return;
            }

            this.CargarPresupuestos();
            this.FormatearGrilla();
        }

        #endregion Controles Locales

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            this.LimpiarFiltros();
        }

        private void LimpiarFiltros()
        {
            this.txtNroBoletaDeposito.Text = string.Empty;
            this.txtNroDocumento.Text = string.Empty;
            this.tSBCliente.Clear();
            this.txtFechaDesde.Text = string.Empty;
            this.txtFechaHasta.Text = string.Empty;
            //this.SetDateTimePicks();
            this.txtIDDocumento.Text = string.Empty;
            this.txtFechaDepositoDesde.Text = string.Empty;
            this.txtFechaDepositoHasta.Text = string.Empty;
            this.txtFechaCobroDesde.Text = string.Empty;
            this.txtFechaCobroHasta.Text = string.Empty;
            this.txtNroCheque.Text = string.Empty;
            this.tSBBancoCheque.Clear();
        }

        private void dgvPresupuestos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (this.dgvPresupuestos.Rows[e.RowIndex].Cells[CAMPO_MONEDADESCRIP].Value.ToString() == GUARANIES)
                {
                    this.dgvPresupuestos.Rows[e.RowIndex].Cells[CAMPO_MONTO].Style.Format = FORMATO_MONEDA_GUARANIES_GRILLA;
                }
                else this.dgvPresupuestos.Rows[e.RowIndex].Cells[CAMPO_MONTO].Style.Format = FORMATO_MONEDA_OTROS_GRILLA;
            }
        }

        private void dtpFechaDepositoDesde_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaDepositoDesde.Text = this.dtpFechaDepositoDesde.Value.ToShortDateString();
        }

        private void dtpFechaDepositoHasta_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaDepositoHasta.Text = this.dtpFechaDepositoHasta.Value.ToShortDateString();
        }

        private void dtpFechaCobroDesde_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaCobroDesde.Text = this.dtpFechaCobroDesde.Value.ToShortDateString();
        }

        private void dtpFechaCobroHasta_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaCobroHasta.Text = this.dtpFechaCobroHasta.Value.ToShortDateString();
        }

        private void lnkMarcarDesmarcar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void btnMarcarTodo_Click(object sender, EventArgs e)
        {
            bool marcar = true;

            if (this.btnMarcarTodo.Text == DESMARCAR)
                marcar = false;

            foreach (DataGridViewRow row in this.dgvPresupuestos.Rows)
            {
                row.Cells[0].Value = marcar;
            }

            this.btnMarcarTodo.Text = marcar ? DESMARCAR : MARCAR;
        }       
        
    }
}