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
using SPF.Base;
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
    public partial class FSeleccionarCobros : Form
    {
        #region Constantes
        private const string CAMPO_COBROID          = "CobroID";
        private const string CAMPO_FECHACOBRO       = "FechaCobro";
        private const string CAMPO_MONTOCOBRO       = "MontoCobro";
        private const string CAMPO_MONEDAID         = "MonedaID";
        private const string CAMPO_MONEDAABREV      = "MonedaAbrev";
        private const string CAMPO_MONEDADESCRIP    = "MonedaDescrip";
        private const string CAMPO_CLIENTEID        = "ClienteID";
        private const string CAMPO_CLIENTENOMBRE    = "ClienteNombre";
        private const string CAMPO_TRAMITEID        = "TramiteID";
        private const string CAMPO_TRAMITEDESCRIP   = "TramiteDescrip";
        private const string CAMPO_RECIBONRO        = "ReciboNro";
        private const string CAMPO_CHEQUENRO        = "ChequeNro";
        private const string CAMPO_FECHARECIBO      = "FechaRecibo";
        private const string CAMPO_SELECCIONAR      = "Seleccionar";
        private const string CAMPO_ANULADO          = "Anulado";
        private const string CAMPO_DOCUMENTONRO     = "DocumentoNro";
        private const string CAMPO_PRESPUESTONRO    = "PresupuestoNro";
        private const string CAMPO_FACTURANRO       = "FacturaNro";
        private const string FILTRO_ANULADO = " ( {0} = false ) ";
        private const string OR_FILTER = " (({0}) OR ({1})) ";
        
        private const string FORMATO_DECIMAL_BROWSE = "{0:N2}";
        #endregion Constantes

        #region Variables
        BerkeDBEntities DBContext;
        private frmPickBase fPickCliente;
        private List<SeleccionarCobrosType> listaCobrosAsoc;
        private BindingSource bS;
        #endregion Variables

        #region Eventos personalizados
        public event EventHandler AceptarClick;
        public event EventHandler CloseClick;
        #endregion Eventos personalizados

        #region Propiedades
        public List<SeleccionarCobrosType> ListaCobrosAsoc
        {
            //set { this.listaCobrosAsoc = value; }
            get { return this.listaCobrosAsoc; }
        }
        #endregion Propiedades

        #region Métodos de Inicio
        public FSeleccionarCobros()
        {
            InitializeComponent();
        }

        public FSeleccionarCobros(BerkeDBEntities context, string titulo)
        {
            InitializeComponent();
            this.DBContext = context;
            this.Text = titulo;
            this.toolTip1.SetToolTip(this.txtFitlroNroRecibo,
                                     "Filtrar por N° o Fecha de Factura, Ref. de la Solicitud");

            #region Inicializar TextSearchBoxes
            this.tSBCliente.KeyMemberWidth = 70;
            this.tSBCliente.ToolTip = "Elegir Cliente";
            this.tSBCliente.AceptarClick += tSBCliente_AceptarClick;
            this.tSBCliente.Editable = true;
            #endregion Inicializar TextSearchBoxes
            this.bS = new BindingSource();
            this.cbMarcarTodo.Visible = false;
        }

        #region Proveedor
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
                fPickCliente.LabelCampoDescrip = "Nombre o Razón Social";
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
        #endregion Proveedor

        private void FSeleccionarCobros_Load(object sender, EventArgs e)
        {
            //if (this.dgvCobros.RowCount == 0)
            //{
            //    this.tSBCliente_AceptarClick(sender, e);
            //}
        }

        #endregion Métodos de Inicio

        #region Métodos Locales
        private void CargarCobros()
        {
            string where = String.Empty;

            if (this.txtFiltroCobroID.Text != String.Empty)
            {
                where += Libs.GetFilterString(this.txtFiltroCobroID.Text, CAMPO_COBROID, false);
            }

            if (this.txtFitlroNroRecibo.Text != String.Empty)
            {
                where += where != String.Empty ? " AND " : String.Empty;
                where += Libs.GetFilterString(this.txtFitlroNroRecibo.Text, CAMPO_RECIBONRO, true);
            }

            if (this.tSBCliente.KeyMember != String.Empty)
            {
                where += where != String.Empty ? " AND " : String.Empty;
                where += Libs.GetFilterString(this.tSBCliente.KeyMember, CAMPO_CLIENTEID, false);
            }

            if (this.txtFiltroNroCheque.Text != String.Empty)
            {
                where += where != String.Empty ? " AND " : String.Empty;
                where += Libs.GetFilterString(this.txtFiltroNroCheque.Text, CAMPO_CHEQUENRO, true);
            }

            if (this.txtNroDoc.Text != String.Empty)
            {
                where += where != String.Empty ? " AND " : String.Empty;
                where += Libs.GetFilterString(this.txtNroDoc.Text, CAMPO_DOCUMENTONRO, true);
            //    where += String.Format(OR_FILTER, Libs.GetFilterString(this.txtNroDoc.Text, CAMPO_PRESPUESTONRO, true),
            //                            Libs.GetFilterString(this.txtNroDoc.Text, CAMPO_FACTURANRO, true));
            }

            if (where == String.Empty)
            {
                MessageBox.Show("Debe indicar algún tipo de filtro.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            where += where != String.Empty ? " AND " : String.Empty;
            where += String.Format(FILTRO_ANULADO, CAMPO_ANULADO);
            
            var query = (from cob in this.DBContext.pp_pagopresupuesto
                         join pCab in this.DBContext.pc_presupuestocab
                            on cob.pp_presupuestocabid equals pCab.pc_presupuestocabid
                         join cli in this.DBContext.Cliente
                            on pCab.pc_clienteid equals cli.ID
                         join tra in this.DBContext.Tramite
                            on pCab.pc_tramiteid equals tra.ID
                         join mon in this.DBContext.Moneda
                            on cob.pp_monedaid equals mon.ID
                         select new SeleccionarCobrosType
                         {
                             CobroID = cob.pp_pagopresupuestoid,
                             FechaCobro = cob.pp_fechapago,
                             MonedaID = cob.pp_monedaid,
                             MonedaAbrev = mon.AbrevMoneda,
                             MonedaDescrip = mon.Descripcion,
                             MontoCobro = cob.pp_montopago,
                             ClienteID = pCab.pc_clienteid,
                             ClienteNombre = cli.Nombre,
                             TramiteID = pCab.pc_tramiteid,
                             TramiteDescrip = tra.EtiquetaEsp,
                             ReciboNro = cob.pp_nrorecibo,
                             ChequeNro = cob.pp_nrocheque,
                             FechaRecibo = cob.pp_fecharecibo,
                             Anulado = cob.pp_anulado,
                             DocumentoNro = this.DBContext.GetDocumentoNro(pCab.pc_presupuestocabid).FirstOrDefault(),
                             PresupuestoNro = pCab.pc_nropresupuesto,
                             FacturaNro = pCab.pc_string1
                         })
                         .Where(where)
                         .ToList();

            this.bS.DataSource = query;
            this.dgvCobros.DataSource = this.bS;
            this.lblEstado.Text = "Documentos recuperados: " + this.dgvCobros.RowCount.ToString();
            this.FormatearGrilla();

            this.cbMarcarTodo.Visible = false;
            if (this.dgvCobros.RowCount > 0)
            {
                this.cbMarcarTodo.Visible = true;
                this.dgvCobros.CurrentCell = this.dgvCobros.Rows[0].Cells[0];
                this.dgvCobros.CurrentCell.Selected = true;
                this.dgvCobros.Focus();
            }
        }

        private void FormatearGrilla()
        {
            foreach (DataGridViewColumn col in this.dgvCobros.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            this.dgvCobros.ReadOnly = false;
            this.dgvCobros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvCobros.ItemsPerPage = 10;
            this.dgvCobros.ShowCellToolTips = true;
            this.dgvCobros.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvCobros.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvCobros.DefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvCobros.DefaultCellStyle.BackColor = Color.Transparent;

            this.dgvCobros.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            
            int displayIndex = 0;

            this.dgvCobros.Columns[CAMPO_COBROID].HeaderText = "Cobro ID";
            this.dgvCobros.Columns[CAMPO_COBROID].Width = 80;
            this.dgvCobros.Columns[CAMPO_COBROID].DisplayIndex = displayIndex;
            this.dgvCobros.Columns[CAMPO_COBROID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvCobros.Columns[CAMPO_COBROID].Visible = true;
            displayIndex++;

            this.dgvCobros.Columns[CAMPO_FECHACOBRO].HeaderText = "Fec. Cobro";
            this.dgvCobros.Columns[CAMPO_FECHACOBRO].Width = 80;
            this.dgvCobros.Columns[CAMPO_FECHACOBRO].DisplayIndex = displayIndex;
            this.dgvCobros.Columns[CAMPO_FECHACOBRO].Visible = true;
            displayIndex++;

            this.dgvCobros.Columns[CAMPO_DOCUMENTONRO].HeaderText = "N° Documento";
            this.dgvCobros.Columns[CAMPO_DOCUMENTONRO].Width = 100;
            this.dgvCobros.Columns[CAMPO_DOCUMENTONRO].DisplayIndex = displayIndex;
            this.dgvCobros.Columns[CAMPO_DOCUMENTONRO].Visible = true;
            displayIndex++;

            this.dgvCobros.Columns[CAMPO_CLIENTENOMBRE].HeaderText = "Cliente";
            this.dgvCobros.Columns[CAMPO_CLIENTENOMBRE].Width = 200;
            this.dgvCobros.Columns[CAMPO_CLIENTENOMBRE].DisplayIndex = displayIndex;
            this.dgvCobros.Columns[CAMPO_CLIENTENOMBRE].Visible = true;
            displayIndex++;

            this.dgvCobros.Columns[CAMPO_TRAMITEDESCRIP].HeaderText = "Trámite";
            this.dgvCobros.Columns[CAMPO_TRAMITEDESCRIP].Width = 200;
            this.dgvCobros.Columns[CAMPO_TRAMITEDESCRIP].DisplayIndex = displayIndex;
            this.dgvCobros.Columns[CAMPO_TRAMITEDESCRIP].Visible = true;
            displayIndex++;

            this.dgvCobros.Columns[CAMPO_MONEDAABREV].HeaderText = "Moneda";
            this.dgvCobros.Columns[CAMPO_MONEDAABREV].Width = 80;
            this.dgvCobros.Columns[CAMPO_MONEDAABREV].DisplayIndex = displayIndex;
            this.dgvCobros.Columns[CAMPO_MONEDAABREV].Visible = true;
            displayIndex++;

            this.dgvCobros.Columns[CAMPO_MONTOCOBRO].HeaderText = "Monto";
            this.dgvCobros.Columns[CAMPO_MONTOCOBRO].Width = 80;
            this.dgvCobros.Columns[CAMPO_MONTOCOBRO].DisplayIndex = displayIndex;
            this.dgvCobros.Columns[CAMPO_MONTOCOBRO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvCobros.Columns[CAMPO_MONTOCOBRO].DefaultCellStyle.Format = "N2";
            this.dgvCobros.Columns[CAMPO_MONTOCOBRO].Visible = true;
            displayIndex++;

            this.dgvCobros.Columns[CAMPO_RECIBONRO].HeaderText = "N° Recibo";
            this.dgvCobros.Columns[CAMPO_RECIBONRO].Width = 100;
            this.dgvCobros.Columns[CAMPO_RECIBONRO].DisplayIndex = displayIndex;
            this.dgvCobros.Columns[CAMPO_RECIBONRO].Visible = true;
            displayIndex++;

            this.dgvCobros.Columns[CAMPO_CHEQUENRO].HeaderText = "N° Cheque";
            this.dgvCobros.Columns[CAMPO_CHEQUENRO].Width = 80;
            this.dgvCobros.Columns[CAMPO_CHEQUENRO].DisplayIndex = displayIndex;
            this.dgvCobros.Columns[CAMPO_CHEQUENRO].Visible = true;
            displayIndex++;

            this.dgvCobros.Columns[CAMPO_FECHARECIBO].HeaderText = "Fec. Recibo";
            this.dgvCobros.Columns[CAMPO_FECHARECIBO].Width = 80;
            this.dgvCobros.Columns[CAMPO_FECHARECIBO].DisplayIndex = displayIndex;
            this.dgvCobros.Columns[CAMPO_FECHARECIBO].Visible = true;
            displayIndex++;

            DataGridViewCheckBoxColumn doWork = new DataGridViewCheckBoxColumn();
            doWork.HeaderText = CAMPO_SELECCIONAR;
            doWork.Name = CAMPO_SELECCIONAR;
            doWork.FalseValue = false;
            doWork.TrueValue = true;
            doWork.ReadOnly = false;
            doWork.Width = 80;
            this.dgvCobros.Columns.Insert(0, doWork);
        }

        private void PrepararDatos()
        {
            this.listaCobrosAsoc = new List<SeleccionarCobrosType>();

            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[this.dgvCobros.DataSource];
            currencyManager1.SuspendBinding();
            
            foreach (DataGridViewRow row in this.dgvCobros.Rows)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)row.Cells[CAMPO_SELECCIONAR];
                if ((checkCell.Value != null) && ((bool)checkCell.Value))
                {
                    this.listaCobrosAsoc.Add((SeleccionarCobrosType)row.DataBoundItem);
                    row.Visible = false;
                }
            }
            currencyManager1.ResumeBinding();

            this.MarcarTodo(false);
        }

        private void MarcarTodo(bool marcar)
        {
            foreach (DataGridViewRow row in this.dgvCobros.Rows)
            {
                if (row.Visible)
                    row.Cells[CAMPO_SELECCIONAR].Value = marcar;
            }
        }

        private int GetCantidadFilasVisibles()
        {
            int result = 0;
            foreach (DataGridViewRow row in this.dgvCobros.Rows)
            {
                if (row.Visible)
                    result++;
            }
            return result;
        }

        public void SetEtiqueta(int cantFilas)
        {
            const string LABEL = "Documentos restantes {0}. Se agregaron {1} cobros.";
            this.lblEstado.Text = String.Format(LABEL, GetCantidadFilasVisibles().ToString(), cantFilas.ToString());
        }
        #endregion Métodos Locales

        #region Controles Locales
        private void btnFiltrar_Click_1(object sender, EventArgs e)
        {
            this.CargarCobros();
        }

        private void cbMarcarTodo_CheckedChanged(object sender, EventArgs e)
        {
            this.MarcarTodo(this.cbMarcarTodo.Checked);
        }

        private void FSeleccionarCobros_VisibleChanged(object sender, EventArgs e)
        {
            if (this.dgvCobros.RowCount > 0)
            {
                this.FormatearGrilla();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.AceptarClick != null)
            {
                this.PrepararDatos();
                this.AceptarClick(sender, e);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (this.CloseClick != null)
            {
                this.CloseClick(sender, e);
            }
            //this.Close();
        }
        #endregion Controles Locales

    }
}