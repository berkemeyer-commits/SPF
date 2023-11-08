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
using SPF.UserControls.Base;
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
    public partial class FCambioFormaPago_Cobros : Form
    {
        #region Constantes
        private const string CAMPO_COBROID          = "CobroID";
        private const string CAMPO_COBROMULTIPLEID  = "CobroMultipleID";
        private const string CAMPO_FECHACOBRO       = "FechaCobro";
        private const string CAMPO_MONTOCOBRO       = "MontoCobro";
        private const string CAMPO_MONEDAID         = "MonedaID";
        private const string CAMPO_MONEDAABREV      = "MonedaAbrev";
        private const string CAMPO_MONEDADESCRIP    = "MonedaDescrip";
        private const string CAMPO_FORMACOBROID     = "FormaCobroID";
        private const string CAMPO_FORMACOBRODESCRIP= "FormaCobroDescrip";
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
        private const string CAMPO_FECHADEPOSITO    = "FechaDeposito";
        private const string CAMPO_BOLETADEPNRO     = "BoletaDepNro";
        private const string CAMPO_BANCODEPOSITO    = "BancoDeposito";
        private const string CAMPO_CUENTADEPOSITO   = "CuentaDeposito";
        private const string CAMPO_MONEDAGASTO      = "MonedaGasto";
        private const string CAMPO_MONTOGASTO       = "MontoGasto";
        private const string CAMPO_BANCOCHEQUEID    = "BancoChequeID";
        private const string CAMPO_BANCOCHEQUE      = "BancoChequeNombre";
        private const string CAMPO_NROCHEQUE        = "NroCheque";
        private const string FILTRO_ANULADO = " ( {0} = false ) ";
        private const string OR_FILTER = " (({0}) OR ({1})) ";
        private const string TEXTBOX_NRODOC = "txtNroDoc";
        private const string WHERE_FILTRO_NRO_DOC = " AND {0} != null ";
        private const string FORMATO_DECIMAL_BROWSE = "{0:N2}";
        #endregion Constantes

        #region Variables
        BerkeDBEntities DBContext;
        private frmPickBase fPickCliente;
        frmPickBase fPickFormaPago;
        frmPickBase fPickFormaPagoOrig;
        frmPickBase fPickBancoDeposito;
        frmPickBase fPickCuentaDeposito;
        frmPickBase fPickMoneda;
        frmPickBase fPickBancoCheque;
        private BindingSource bS;
        #endregion Variables

        #region Métodos de Inicio
        public FCambioFormaPago_Cobros()
        {
            InitializeComponent();
        }

        public FCambioFormaPago_Cobros(string titulo, BerkeDBEntities context)
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

            this.tSBFormaPago.KeyMemberWidth = 70;
            this.tSBFormaPago.ToolTip = "Elegir Forma de Cobro Destino";
            this.tSBFormaPago.AceptarClick += tSBFormaPago_AceptarClick;
            this.tSBFormaPago.Editable = true;

            this.tsbFormaCobroOrig.KeyMemberWidth = 70;
            this.tsbFormaCobroOrig.ToolTip = "Elegir Forma de Cobro Origen";
            this.tsbFormaCobroOrig.AceptarClick += tsbFormaCobroOrig_AceptarClick;
            this.tsbFormaCobroOrig.Editable = true;

            this.tSBMoneda.KeyMemberWidth = 70;
            this.tSBMoneda.ToolTip = "Elegir Moneda";
            this.tSBMoneda.AceptarClick += tSBMoneda_AceptarClick;
            this.tSBMoneda.Editable = true;

            this.tSBBancoDeposito.KeyMemberWidth = 70;
            this.tSBBancoDeposito.ToolTip = "Elegir Banco de Depósito";
            this.tSBBancoDeposito.AceptarClick += tSBBancoDeposito_AceptarClick;
            this.tSBBancoDeposito.Editable = true;

            this.tSBCuentaDeposito.KeyMemberWidth = 70;
            this.tSBCuentaDeposito.ToolTip = "Elegir Cuenta de Depósito";
            this.tSBCuentaDeposito.AceptarClick += tSBCuentaDeposito_AceptarClick;
            this.tSBCuentaDeposito.Editable = true;

            this.tSBBancoCheque.KeyMemberWidth = 70;
            this.tSBBancoCheque.ToolTip = "Elegir Banco de Cheque";
            this.tSBBancoCheque.AceptarClick += tSBBancoCheque_AceptarClick;
            this.tSBBancoCheque.Editable = true;
            #endregion Inicializar TextSearchBoxes
            this.bS = new BindingSource();
            this.cbMarcarTodo.Visible = false;
        }

        private void FSeleccionarCobros_Load(object sender, EventArgs e)
        {
            this.txtCMID.Text = String.Empty;
            this.txtCMMonto.Text = String.Empty;
        }

        #endregion Métodos de Inicio

        #region Métodos Locales
        private void CargarCobros()
        {
            string where = String.Empty;

            if (!this.cbBuscarPagosAsoc.Checked)
            {

                if (this.txtFiltroCobroID.Text != String.Empty)
                {
                    where += Libs.GetFilterString(this.txtFiltroCobroID.Text, CAMPO_COBROID, false);
                }

                if (this.txtFiltroCobroMultipleID.Text != String.Empty)
                {
                    where += where != String.Empty ? " AND " : String.Empty;
                    where += Libs.GetFilterString(this.txtFiltroCobroMultipleID.Text, CAMPO_COBROMULTIPLEID, false);
                }

                if (this.tsbFormaCobroOrig.KeyMember != String.Empty)
                {
                    where += where != String.Empty ? " AND " : String.Empty;
                    where += Libs.GetFilterString(this.tsbFormaCobroOrig.KeyMember, CAMPO_FORMACOBROID, false);
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
            }
            else
            {
                string where1 = Libs.GetFilterString(this.txtNroDoc.Text, CAMPO_DOCUMENTONRO, true) +
                                String.Format(WHERE_FILTRO_NRO_DOC, CAMPO_COBROMULTIPLEID);

                var qry = (from pp in this.DBContext.pp_pagopresupuesto
                           join pc in this.DBContext.pc_presupuestocab
                             on pp.pp_presupuestocabid equals pc.pc_presupuestocabid
                           select new
                           {
                                CobroMultipleID = pp.pp_pagomultipleid,
                                DocumentoNro = this.DBContext.GetDocumentoNro(pc.pc_presupuestocabid).FirstOrDefault()
                           })
                           .Where(where1)
                           .ToList();

                string listaCobrosMultiplesID = String.Empty;
                foreach (var row in qry)
                {
                    listaCobrosMultiplesID += (listaCobrosMultiplesID != String.Empty ? "," : String.Empty) + row.CobroMultipleID.Value.ToString();
                }

                if (listaCobrosMultiplesID != String.Empty)
                    where = Libs.GetFilterString(listaCobrosMultiplesID, CAMPO_COBROMULTIPLEID, false);

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
                         join fCob in this.DBContext.fp_formadepago
                            on cob.pp_formapagoid equals fCob.fp_formadepagoid
                         join monG in this.DBContext.Moneda
                            on cob.pp_monedagastoid equals monG.ID into monG_pPre
                            from monG in monG_pPre.DefaultIfEmpty()
                         join banD in this.DBContext.ba_banco
                            on cob.pp_bancoid equals banD.ba_bancoid into banD_pPre
                            from banD in banD_pPre.DefaultIfEmpty()
                         join ctaD in this.DBContext.cb_cuentabanco
                            on cob.pp_cuentaid equals ctaD.cb_cuentabancoid into ctaD_pPre
                            from ctaD in ctaD_pPre.DefaultIfEmpty()
                         join banC in this.DBContext.ba_banco
                             on cob.pp_bancochequeid equals banC.ba_bancoid into banC_pPre
                         from banC in banC_pPre.DefaultIfEmpty()
                         select new SeleccionarCobrosType
                         {
                             CobroID = cob.pp_pagopresupuestoid,
                             CobroMultipleID = cob.pp_pagomultipleid,
                             FechaCobro = cob.pp_fechapago,
                             MonedaID = cob.pp_monedaid,
                             MonedaAbrev = mon.AbrevMoneda,
                             MonedaDescrip = mon.Descripcion,
                             FormaCobroID = cob.pp_formapagoid,
                             FormaCobroDescrip = fCob.fp_descripcion,
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
                             FacturaNro = pCab.pc_string1,
                             FechaDeposito = cob.pp_fechaboletadeposito,
                             BoletaDepNro = cob.pp_nroboletadeposito,
                             BancoDeposito = banD.ba_descripcion,
                             CuentaDeposito = ctaD.cb_descripcion,
                             MonedaGasto = monG.AbrevMoneda,
                             MontoGasto = cob.pp_gastocambiario,
                             BancoChequeID = cob.pp_bancochequeid,
                             BancoChequeNombre = banC.ba_descripcion,
                             NroCheque = cob.pp_nrocheque
                         })
                         .Where(where)
                         .OrderBy(a => a.CobroMultipleID)
                         .ToList();

            this.bS.DataSource = query;
            this.dgvCobros.DataSource = this.bS;
            this.lblEstado.Text = "Documentos recuperados: " + this.dgvCobros.RowCount.ToString();
            this.FormatearGrilla();

            this.cbMarcarTodo.Visible = false;
            if (this.dgvCobros.RowCount > 0)
            {
                this.cbMarcarTodo.Visible = true;
                //this.dgvCobros.CurrentCell = this.dgvCobros.Rows[0].Cells[0];
                //this.dgvCobros.CurrentCell.Selected = true;
                this.dgvCobros.Focus();
                this.dgvCobros.Rows[0].Selected = true;
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
            this.dgvCobros.ItemsPerPage = 6;
            this.dgvCobros.ShowCellToolTips = true;
            this.dgvCobros.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvCobros.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvCobros.DefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvCobros.DefaultCellStyle.BackColor = Color.Transparent;
            this.dgvCobros.MultiSelect = false;
            this.dgvCobros.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            
            int displayIndex = 0;

            this.dgvCobros.Columns[CAMPO_COBROID].HeaderText = "ID Cobro";
            this.dgvCobros.Columns[CAMPO_COBROID].Width = 80;
            this.dgvCobros.Columns[CAMPO_COBROID].DisplayIndex = displayIndex;
            this.dgvCobros.Columns[CAMPO_COBROID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvCobros.Columns[CAMPO_COBROID].Visible = true;
            displayIndex++;

            this.dgvCobros.Columns[CAMPO_COBROMULTIPLEID].HeaderText = "ID Cob. M.";
            this.dgvCobros.Columns[CAMPO_COBROMULTIPLEID].Width = 80;
            this.dgvCobros.Columns[CAMPO_COBROMULTIPLEID].DisplayIndex = displayIndex;
            this.dgvCobros.Columns[CAMPO_COBROMULTIPLEID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvCobros.Columns[CAMPO_COBROMULTIPLEID].Visible = true;
            displayIndex++;

            this.dgvCobros.Columns[CAMPO_FORMACOBRODESCRIP].HeaderText = "Forma de Cobro";
            this.dgvCobros.Columns[CAMPO_FORMACOBRODESCRIP].Width = 150;
            this.dgvCobros.Columns[CAMPO_FORMACOBRODESCRIP].DisplayIndex = displayIndex;
            this.dgvCobros.Columns[CAMPO_FORMACOBRODESCRIP].Visible = true;
            displayIndex++;

            this.dgvCobros.Columns[CAMPO_MONEDAABREV].HeaderText = "Moneda";
            this.dgvCobros.Columns[CAMPO_MONEDAABREV].Width = 70;
            this.dgvCobros.Columns[CAMPO_MONEDAABREV].DisplayIndex = displayIndex;
            this.dgvCobros.Columns[CAMPO_MONEDAABREV].Visible = true;
            displayIndex++;

            this.dgvCobros.Columns[CAMPO_MONTOCOBRO].HeaderText = "Monto";
            this.dgvCobros.Columns[CAMPO_MONTOCOBRO].Width = 75;
            this.dgvCobros.Columns[CAMPO_MONTOCOBRO].DisplayIndex = displayIndex;
            this.dgvCobros.Columns[CAMPO_MONTOCOBRO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvCobros.Columns[CAMPO_MONTOCOBRO].DefaultCellStyle.Format = "N2";
            this.dgvCobros.Columns[CAMPO_MONTOCOBRO].Visible = true;
            displayIndex++;

            this.dgvCobros.Columns[CAMPO_FECHACOBRO].HeaderText = "Fec. Cobro";
            this.dgvCobros.Columns[CAMPO_FECHACOBRO].Width = 80;
            this.dgvCobros.Columns[CAMPO_FECHACOBRO].DisplayIndex = displayIndex;
            this.dgvCobros.Columns[CAMPO_FECHACOBRO].Visible = true;
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

            this.dgvCobros.Columns[CAMPO_FECHADEPOSITO].HeaderText = "Fec. Depósito";
            this.dgvCobros.Columns[CAMPO_FECHADEPOSITO].Width = 95;
            this.dgvCobros.Columns[CAMPO_FECHADEPOSITO].DisplayIndex = displayIndex;
            this.dgvCobros.Columns[CAMPO_FECHADEPOSITO].Visible = true;
            displayIndex++;

            this.dgvCobros.Columns[CAMPO_BOLETADEPNRO].HeaderText = "N° Bol. Dep.";
            this.dgvCobros.Columns[CAMPO_BOLETADEPNRO].Width = 85;
            this.dgvCobros.Columns[CAMPO_BOLETADEPNRO].DisplayIndex = displayIndex;
            this.dgvCobros.Columns[CAMPO_BOLETADEPNRO].Visible = true;
            displayIndex++;

            this.dgvCobros.Columns[CAMPO_BANCODEPOSITO].HeaderText = "Banco Depósito";
            this.dgvCobros.Columns[CAMPO_BANCODEPOSITO].Width = 150;
            this.dgvCobros.Columns[CAMPO_BANCODEPOSITO].DisplayIndex = displayIndex;
            this.dgvCobros.Columns[CAMPO_BANCODEPOSITO].Visible = true;
            displayIndex++;

            this.dgvCobros.Columns[CAMPO_CUENTADEPOSITO].HeaderText = "Cuenta Depósito";
            this.dgvCobros.Columns[CAMPO_CUENTADEPOSITO].Width = 150;
            this.dgvCobros.Columns[CAMPO_CUENTADEPOSITO].DisplayIndex = displayIndex;
            this.dgvCobros.Columns[CAMPO_CUENTADEPOSITO].Visible = true;
            displayIndex++;

            this.dgvCobros.Columns[CAMPO_MONTOGASTO].HeaderText = "Monto Gasto";
            this.dgvCobros.Columns[CAMPO_MONTOGASTO].Width = 100;
            this.dgvCobros.Columns[CAMPO_MONTOGASTO].DisplayIndex = displayIndex;
            this.dgvCobros.Columns[CAMPO_MONTOGASTO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvCobros.Columns[CAMPO_MONTOGASTO].DefaultCellStyle.Format = "N2";
            this.dgvCobros.Columns[CAMPO_MONTOGASTO].Visible = true;
            displayIndex++;

            this.dgvCobros.Columns[CAMPO_MONEDAGASTO].HeaderText = "Moneda Gasto";
            this.dgvCobros.Columns[CAMPO_MONEDAGASTO].Width = 100;
            this.dgvCobros.Columns[CAMPO_MONEDAGASTO].DisplayIndex = displayIndex;
            this.dgvCobros.Columns[CAMPO_MONEDAGASTO].Visible = true;
            displayIndex++;

            this.dgvCobros.Columns[CAMPO_DOCUMENTONRO].HeaderText = "N° Documento";
            this.dgvCobros.Columns[CAMPO_DOCUMENTONRO].Width = 100;
            this.dgvCobros.Columns[CAMPO_DOCUMENTONRO].DisplayIndex = displayIndex;
            this.dgvCobros.Columns[CAMPO_DOCUMENTONRO].Visible = true;
            displayIndex++;

            this.dgvCobros.Columns[CAMPO_RECIBONRO].HeaderText = "N° Recibo";
            this.dgvCobros.Columns[CAMPO_RECIBONRO].Width = 100;
            this.dgvCobros.Columns[CAMPO_RECIBONRO].DisplayIndex = displayIndex;
            this.dgvCobros.Columns[CAMPO_RECIBONRO].Visible = true;
            displayIndex++;

            this.dgvCobros.Columns[CAMPO_BANCOCHEQUE].HeaderText = "Banco Cheque";
            this.dgvCobros.Columns[CAMPO_BANCOCHEQUE].Width = 150;
            this.dgvCobros.Columns[CAMPO_BANCOCHEQUE].DisplayIndex = displayIndex;
            this.dgvCobros.Columns[CAMPO_BANCOCHEQUE].Visible = true;
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

        private void Iterar()
        {
            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[this.dgvCobros.DataSource];
            currencyManager1.SuspendBinding();
            int cantProcesados = 0;
            
            foreach (DataGridViewRow row in this.dgvCobros.Rows)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)row.Cells[CAMPO_SELECCIONAR];
                if ((checkCell.Value != null) && ((bool)checkCell.Value))
                {
                    SeleccionarCobrosType datos = (SeleccionarCobrosType)row.DataBoundItem;
                    //if (datos.FormaCobroID.Value != Convert.ToInt32(this.tSBFormaPago.KeyMember))
                    //{
                        CambioFormaCobroType cfrow = new CambioFormaCobroType();

                        //this.Procesar(datos.CobroID.Value, Convert.ToInt32(this.tSBFormaPago.KeyMember), Convert.ToDateTime(this.txtFechaCobroDest.Text));
                        cfrow.CobroID = datos.CobroID.Value;
                        if (this.tSBFormaPago.KeyMember != String.Empty)
                            cfrow.FormaCobroID = Convert.ToInt32(this.tSBFormaPago.KeyMember);
                        if (this.txtFechaCobroDest.Text != String.Empty)
                            cfrow.FechaCobro = Convert.ToDateTime(this.txtFechaCobroDest.Text);
                        //Datos Depósito
                        if (this.txtFechaDeposito.Text.Trim() != String.Empty)
                            cfrow.FechaDeposito = Convert.ToDateTime(this.txtFechaDeposito.Text);
                        if (this.tSBBancoDeposito.KeyMember.Trim() != String.Empty)
                            cfrow.BancoDepositoID = Convert.ToInt32(this.tSBBancoDeposito.KeyMember);
                        if (this.txtBoletaDepNro.Text.Trim() != String.Empty)
                            cfrow.BoletaDepNro = this.txtBoletaDepNro.Text;
                        if (this.tSBCuentaDeposito.KeyMember.Trim() != String.Empty)
                            cfrow.CtaDepositoID = Convert.ToInt32(this.tSBCuentaDeposito.KeyMember);
                        //Datos Gasto
                        if (this.tSBMoneda.KeyMember.Trim() != String.Empty)
                            cfrow.MonedaGastoID = Convert.ToInt32(this.tSBMoneda.KeyMember);
                        if (this.txtGastoBancario.Text.Trim() != String.Empty)
                            cfrow.MontoGasto = Convert.ToDecimal(this.txtGastoBancario.Text.Replace('.', ','));
                        //Datos Cheque
                        if (this.tSBBancoCheque.KeyMember.Trim() != String.Empty)
                            cfrow.BancoChequeID = Convert.ToInt32(this.tSBBancoCheque.KeyMember);
                        if (this.txtNroCheque.Text.Trim() != String.Empty)
                            cfrow.NroCheque = this.txtNroCheque.Text;
                        
                        this.Procesar(cfrow);
                        cantProcesados++;
                        row.Visible = false;
                    //}
                }
            }
            currencyManager1.ResumeBinding();

            this.MarcarTodo(false);
            this.btnFiltrar.PerformClick();

            if (cantProcesados > 0)
                this.LimpiarTextBoxes();

            MessageBox.Show("Operación completada con éxito." + Environment.NewLine +
                            "Se procesaron " +  cantProcesados + " cobros.", 
                            "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void Procesar(CambioFormaCobroType row)
        {
            bool success = false;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        pp_pagopresupuesto cob = context.pp_pagopresupuesto.First(a => a.pp_pagopresupuestoid == row.CobroID);
                        
                        if (row.FechaCobro.HasValue)
                            cob.pp_fechapago = row.FechaCobro.Value;
                        if (row.FormaCobroID.HasValue)
                            cob.pp_formapagoid = row.FormaCobroID.Value;

                        //Datos Depósito
                        if (row.FechaDeposito.HasValue)
                            cob.pp_fechaboletadeposito = row.FechaDeposito.Value;
                        if (row.BoletaDepNro != null)
                            cob.pp_nroboletadeposito = row.BoletaDepNro;
                        if (row.BancoDepositoID.HasValue)
                            cob.pp_bancoid = row.BancoDepositoID.Value;
                        if (row.CtaDepositoID.HasValue)
                            cob.pp_cuentaid = row.CtaDepositoID.Value;
                        //Gasto Bancario
                        if (row.MonedaGastoID.HasValue)
                            cob.pp_monedagastoid = row.MonedaGastoID.Value;
                        if (row.MontoGasto.HasValue)
                            cob.pp_gastocambiario = row.MontoGasto.Value;

                        if (row.BancoChequeID.HasValue)
                            cob.pp_bancochequeid = row.BancoChequeID.Value;
                        if (row.NroCheque != null)
                            cob.pp_nrocheque = row.NroCheque;
                
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        success = true;
                        
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        MessageBox.Show("Ocurrió un error al procesar el cambio de forma de cobro. "
                                        + ex.Message + Environment.NewLine
                                        + ex.InnerException,
                                        "Error al anular",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Stop);
                    }
                }
            }
            if (success)
            {
                //this.txtEstado.Text = "Anulado";
                //this.FilterEntity(this.WhereString, this.FilterParam);
                //this.CargarPago(this.dgvListadoABM.Rows[this.LastDGVIndex]);
                //MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        private int GetCantidadFilasMarcadas()
        {
            int cantFilasMarcadas = 0;
            foreach (DataGridViewRow row in this.dgvCobros.Rows)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)row.Cells[CAMPO_SELECCIONAR];
                if ((checkCell.Value != null) && ((bool)checkCell.Value))
                {
                    cantFilasMarcadas++;
                }
            }
            return cantFilasMarcadas;
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
            this.cbMarcarTodo.Checked = false;
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
            if (this.GetCantidadFilasMarcadas() == 0)
            {
                MessageBox.Show("No existen filas seleccionadas para el proceso.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            //if (this.tSBFormaPago.KeyMember == "")
            //{
            //    MessageBox.Show("Debe ingresar una forma de cobro de destino.",
            //                    "Información",
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Information);

            //    return;
            //}

            //if (this.txtFechaCobroDest.Text == String.Empty)
            //{
            //    MessageBox.Show("Debe ingresar una fecha de cobro de destino.",
            //                    "Información",
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Information);

            //    return;
            //}
            //else
            //{
            //    string[] format = new string[] { "dd-MM-yyyy", "dd/MM/yyyy", "dd-MM-yyyy HH:mm:ss", "dd-MM-yyyy hh:mm:ss", "dd/MM/yyyy HH:mm:ss", "dd/MM/yyyy hh:mm:ss" };
            //    DateTime datetime;
                
            //    if (!DateTime.TryParseExact(this.txtFechaCobroDest.Text, format, System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out datetime))
            //    {
            //        MessageBox.Show("La fecha ingresada no es válida.",
            //                    "Información",
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Error);

            //        return;
            //    }
            //}

            if (this.txtFechaCobroDest.Text != String.Empty)
            {
                string[] format = new string[] { "dd-MM-yyyy", "dd/MM/yyyy", "dd-MM-yyyy HH:mm:ss", "dd-MM-yyyy hh:mm:ss", "dd/MM/yyyy HH:mm:ss", "dd/MM/yyyy hh:mm:ss" };
                DateTime datetime;

                if (!DateTime.TryParseExact(this.txtFechaCobroDest.Text, format, System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out datetime))
                {
                    MessageBox.Show("La fecha ingresada no es válida.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                    return;
                }
            }

            string message = "Se iniciará el proceso ¿Desea continuar?";
            string caption = "Confirmación";
            
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
                    this.Iterar();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCobros_SelectionChanged(object sender, EventArgs e)
        {
            if ((this.dgvCobros.DataSource != null) && (this.dgvCobros.CurrentRow != null))
            {
                SeleccionarCobrosType datos = (SeleccionarCobrosType)this.dgvCobros.Rows[this.dgvCobros.CurrentRow.Index].DataBoundItem;
                int gcobroMultID = this.txtCMID.Text != String.Empty ? Convert.ToInt32(this.txtCMID.Text) : -1;
                if ((datos.CobroMultipleID.HasValue) && (datos.CobroMultipleID.Value != gcobroMultID))
                {
                    int cobroMultID = datos.CobroMultipleID.Value;
                    this.txtCMID.Text = cobroMultID.ToString();
                    decimal montoCobroMult = this.DBContext.pp_pagopresupuesto.Where(a => a.pp_pagomultipleid == cobroMultID).Sum(a => a.pp_montopago);
                    this.txtCMMonto.Text = String.Format("{0:N2}", montoCobroMult);
                    this.lblMoneda.Text = datos.MonedaAbrev;
                }
                else if (!datos.CobroMultipleID.HasValue)
                {
                    this.txtCMID.Text = String.Empty;
                    this.txtCMMonto.Text = String.Empty;
                    this.lblMoneda.Text = String.Empty;
                }
            }
            else
            {
                this.txtCMID.Text = String.Empty;
                this.txtCMMonto.Text = String.Empty;
                this.lblMoneda.Text = String.Empty;
            }
        }

        #endregion Controles Locales

        #region Picks
        #region Moneda
        private void tSBMoneda_AceptarClick(object sender, EventArgs e)
        {
            if (fPickMoneda == null)
            {
                fPickMoneda = new frmPickBase();
                fPickMoneda.AceptarFiltrarClick += fPickMoneda_AceptarFiltrarClick;
                fPickMoneda.FiltrarClick += fPickMoneda_FiltrarClick;
                fPickMoneda.Titulo = "Elegir Moneda";
                fPickMoneda.CampoIDNombre = "ID";
                fPickMoneda.CampoDescripNombre = "Descripcion";
                fPickMoneda.LabelCampoID = "ID";
                fPickMoneda.LabelCampoDescrip = "Descripción";
                fPickMoneda.NombreCampo = "Moneda";
                fPickMoneda.PermitirFiltroNulo = true;
            }
            fPickMoneda.MostrarFiltro();
            this.fPickMoneda_FiltrarClick(sender, e);
        }

        private void fPickMoneda_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickMoneda != null)
            {
                fPickMoneda.LoadData<Moneda>(this.DBContext.Moneda, fPickMoneda.GetWhereString());
            }
        }

        private void fPickMoneda_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBMoneda.DisplayMember = fPickMoneda.ValorDescrip;
            this.tSBMoneda.KeyMember = fPickMoneda.ValorID;
            this.txtGastoBancario.Text = "0";

            fPickMoneda.Close();
            fPickMoneda.Dispose();
        }
        #endregion Moneda

        #region Banco Depósito
        private void tSBBancoDeposito_AceptarClick(object sender, EventArgs e)
        {
            if (fPickBancoDeposito == null)
            {
                fPickBancoDeposito = new frmPickBase();
                fPickBancoDeposito.AceptarFiltrarClick += fPickBancoDeposito_AceptarFiltrarClick;
                fPickBancoDeposito.FiltrarClick += fPickBancoDeposito_FiltrarClick;
                fPickBancoDeposito.Titulo = "Elegir Banco Déposito";
                fPickBancoDeposito.CampoIDNombre = "ba_bancoid";
                fPickBancoDeposito.CampoDescripNombre = "ba_descripcion";
                fPickBancoDeposito.LabelCampoID = "ID";
                fPickBancoDeposito.LabelCampoDescrip = "Nombre";
                fPickBancoDeposito.NombreCampo = "Banco";
                fPickBancoDeposito.PermitirFiltroNulo = true;
            }
            fPickBancoDeposito.MostrarFiltro();
            this.fPickBancoDeposito_FiltrarClick(sender, e);
        }

        private void fPickBancoDeposito_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickBancoDeposito != null)
            {
                fPickBancoDeposito.LoadData<ba_banco>(this.DBContext.ba_banco, fPickBancoDeposito.GetWhereString());
            }
        }

        private void fPickBancoDeposito_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBBancoDeposito.DisplayMember = fPickBancoDeposito.ValorDescrip;
            this.tSBBancoDeposito.KeyMember = fPickBancoDeposito.ValorID;

            fPickBancoDeposito.Close();
            fPickBancoDeposito.Dispose();
        }
        #endregion Banco Depósito

        #region Cuenta Depósito
        private void tSBCuentaDeposito_AceptarClick(object sender, EventArgs e)
        {
            if (this.tSBBancoDeposito.KeyMember == "")
            {
                MessageBox.Show("Debe ingresar un banco válido.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (fPickCuentaDeposito == null)
            {
                fPickCuentaDeposito = new frmPickBase();
                fPickCuentaDeposito.AceptarFiltrarClick += fPickCuentaDeposito_AceptarFiltrarClick;
                fPickCuentaDeposito.FiltrarClick += fPickCuentaDeposito_FiltrarClick;
                fPickCuentaDeposito.Titulo = "Elegir Cuenta Déposito";
                fPickCuentaDeposito.CampoIDNombre = "CuentaID";
                fPickCuentaDeposito.CampoDescripNombre = "CuentaDescripcion";
                fPickCuentaDeposito.LabelCampoID = "ID";
                fPickCuentaDeposito.LabelCampoDescrip = "Descripción";
                fPickCuentaDeposito.NombreCampo = "Cuenta";
                fPickCuentaDeposito.PermitirFiltroNulo = true;
            }
            fPickCuentaDeposito.MostrarFiltro();
            this.fPickCuentaDeposito_FiltrarClick(sender, e);
        }

        private void fPickCuentaDeposito_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickCuentaDeposito != null)
            {
                int bancoID = Convert.ToInt32(this.tSBBancoDeposito.KeyMember);
                //int monedaID = Convert.ToInt32(this.txtMonedaID.Text);
                var query = (from cb in this.DBContext.cb_cuentabanco
                             select new CuentaType
                             {
                                 CuentaID = cb.cb_cuentabancoid,
                                 CuentaDescripcion = cb.cb_descripcion,
                                 BancoID = cb.cb_bancoid,
                                 MonedaID = cb.cb_monedaid
                             }).Where(a => a.BancoID == bancoID);// && a.MonedaID == monedaID);

                fPickCuentaDeposito.LoadData<CuentaType>(query.AsQueryable(), fPickCuentaDeposito.GetWhereString());
                //fPickCuentaDeposito.LoadData<cb_cuentabanco>(this.DBContext.cb_cuentabanco, fPickCuentaDeposito.GetWhereString());
            }
        }

        private void fPickCuentaDeposito_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBCuentaDeposito.DisplayMember = fPickCuentaDeposito.ValorDescrip;
            this.tSBCuentaDeposito.KeyMember = fPickCuentaDeposito.ValorID;

            fPickCuentaDeposito.Close();
            fPickCuentaDeposito.Dispose();
        }
        #endregion Cuenta Depósito

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
        #endregion Cliente

        #region Forma de Pago
        private void tSBFormaPago_AceptarClick(object sender, EventArgs e)
        {
            if (fPickFormaPago == null)
            {
                fPickFormaPago = new frmPickBase();
                fPickFormaPago.AceptarFiltrarClick += fPickFormaPago_AceptarFiltrarClick;
                fPickFormaPago.FiltrarClick += fPickFormaPago_FiltrarClick;
                fPickFormaPago.Titulo = "Elegir Forma de Cobro";
                fPickFormaPago.CampoIDNombre = "fp_formadepagoid";
                fPickFormaPago.CampoDescripNombre = "fp_descripcion";
                fPickFormaPago.LabelCampoID = "ID";
                fPickFormaPago.LabelCampoDescrip = "Nombre";
                fPickFormaPago.NombreCampo = "Forma Cobro";
                fPickFormaPago.PermitirFiltroNulo = true;
            }
            fPickFormaPago.MostrarFiltro();
            this.fPickFormaPago_FiltrarClick(sender, e);
        }

        private void fPickFormaPago_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickFormaPago != null)
            {
                fPickFormaPago.LoadData<fp_formadepago>(this.DBContext.fp_formadepago, fPickFormaPago.GetWhereString());
            }
        }

        private void fPickFormaPago_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBFormaPago.DisplayMember = fPickFormaPago.ValorDescrip;
            this.tSBFormaPago.KeyMember = fPickFormaPago.ValorID;
            this.txtFechaCobroDest.Text = DateTime.Now.ToShortDateString();
            this.txtFechaDeposito.Text = DateTime.Now.ToShortDateString();

            fPickFormaPago.Close();
            fPickFormaPago.Dispose();

        }
        #endregion Forma de Pago

        #region Forma de Pago Origen
        private void tsbFormaCobroOrig_AceptarClick(object sender, EventArgs e)
        {
            if (fPickFormaPagoOrig == null)
            {
                fPickFormaPagoOrig = new frmPickBase();
                fPickFormaPagoOrig.AceptarFiltrarClick += fPickFormaPagoOrig_AceptarFiltrarClick;
                fPickFormaPagoOrig.FiltrarClick += fPickFormaPagoOrig_FiltrarClick;
                fPickFormaPagoOrig.Titulo = "Elegir Forma de Cobro";
                fPickFormaPagoOrig.CampoIDNombre = "fp_formadepagoid";
                fPickFormaPagoOrig.CampoDescripNombre = "fp_descripcion";
                fPickFormaPagoOrig.LabelCampoID = "ID";
                fPickFormaPagoOrig.LabelCampoDescrip = "Nombre";
                fPickFormaPagoOrig.NombreCampo = "Forma Cobro";
                fPickFormaPagoOrig.PermitirFiltroNulo = true;
            }
            fPickFormaPagoOrig.MostrarFiltro();
            this.fPickFormaPagoOrig_FiltrarClick(sender, e);
        }

        private void fPickFormaPagoOrig_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickFormaPagoOrig != null)
            {
                fPickFormaPagoOrig.LoadData<fp_formadepago>(this.DBContext.fp_formadepago, fPickFormaPagoOrig.GetWhereString());
            }
        }

        private void fPickFormaPagoOrig_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tsbFormaCobroOrig.DisplayMember = fPickFormaPagoOrig.ValorDescrip;
            this.tsbFormaCobroOrig.KeyMember = fPickFormaPagoOrig.ValorID;

            fPickFormaPagoOrig.Close();
            fPickFormaPagoOrig.Dispose();

        }
        #endregion Forma de Pago Origen

        #region Banco Cheque
        private void tSBBancoCheque_AceptarClick(object sender, EventArgs e)
        {
            if (fPickBancoCheque == null)
            {
                fPickBancoCheque = new frmPickBase();
                fPickBancoCheque.AceptarFiltrarClick += fPickBancoCheque_AceptarFiltrarClick;
                fPickBancoCheque.FiltrarClick += fPickBancoCheque_FiltrarClick;
                fPickBancoCheque.Titulo = "Elegir Banco Cheque";
                fPickBancoCheque.CampoIDNombre = "ba_bancoid";
                fPickBancoCheque.CampoDescripNombre = "ba_descripcion";
                fPickBancoCheque.LabelCampoID = "ID";
                fPickBancoCheque.LabelCampoDescrip = "Nombre";
                fPickBancoCheque.NombreCampo = "Banco";
                fPickBancoCheque.PermitirFiltroNulo = true;
            }
            fPickBancoCheque.MostrarFiltro();
            this.fPickBancoCheque_FiltrarClick(sender, e);
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
        #endregion Banco Cheque
        #endregion Picks

        #region Limpiar TextBoxes
        private void LimpiarTextBoxes(bool buscarPorNroDoc = false)
        {
            foreach (Control ctrl in this.grpBuscarCobros.Controls)
            {
                if (ctrl.GetType() == typeof(TextBox))
                {
                    if (!((buscarPorNroDoc) && (ctrl.Name == TEXTBOX_NRODOC)))
                        ctrl.Text = String.Empty;
                }
                else if (ctrl.GetType() == typeof(ucTextSearchBox))
                {
                    ((ucTextSearchBox)ctrl).Clear();
                }
            }

            if (!buscarPorNroDoc)
            {
                foreach (Control ctrl in this.grpFormaPagoDestino.Controls)
                {
                    if (ctrl.GetType() == typeof(TextBox))
                    {
                        ctrl.Text = String.Empty;
                    }
                    else if (ctrl.GetType() == typeof(ucTextSearchBox))
                    {
                        ((ucTextSearchBox)ctrl).Clear();
                    }
                }

                foreach (Control ctrl in this.grpDeposito.Controls)
                {
                    if (ctrl.GetType() == typeof(TextBox))
                    {
                        ctrl.Text = String.Empty;
                    }
                    else if (ctrl.GetType() == typeof(ucTextSearchBox))
                    {
                        ((ucTextSearchBox)ctrl).Clear();
                    }
                }

                foreach (Control ctrl in this.grpCheque.Controls)
                {
                    if (ctrl.GetType() == typeof(TextBox))
                    {
                        ctrl.Text = String.Empty;
                    }
                    else if (ctrl.GetType() == typeof(ucTextSearchBox))
                    {
                        ((ucTextSearchBox)ctrl).Clear();
                    }
                }

                foreach (Control ctrl in this.grpGastoBancario.Controls)
                {
                    if (ctrl.GetType() == typeof(TextBox))
                    {
                        ctrl.Text = String.Empty;
                    }
                    else if (ctrl.GetType() == typeof(ucTextSearchBox))
                    {
                        ((ucTextSearchBox)ctrl).Clear();
                    }
                }
                this.cbBuscarPagosAsoc.Checked = false;
                this.cbMarcarTodo.Checked = false;
            }
            
        }
        #endregion Limpiar TextBoxes

        private void cbBuscarPagosAsoc_CheckedChanged(object sender, EventArgs e)
        {
            this.LimpiarTextBoxes(this.cbBuscarPagosAsoc.Checked);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpiarTextBoxes();
        }
    }
}