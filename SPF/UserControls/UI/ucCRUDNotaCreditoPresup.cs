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
using SPF.Types;
using SPF.Forms.Base;
using SPF.Forms.UI;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.ObjectModel;

using SPF.Classes;
using Microsoft.Reporting.WebForms;

#endregion Using

namespace SPF.UserControls.UI
{
    public partial class ucCRUDNotaCreditoPresup : ucBaseForm
    {
        #region Constantes
        //Campos Tabla Cabecera
        private const string CAMPO_AUTORIZACIONVIG  = "TieneAutorizacionVigente";
        private const string CAMPO_NOTACREDITOID = "NotaCreditoID";
        private const string CAMPO_NOTACREDITONRO = "NotaCreditoNro";
        private const string CAMPO_NOTACREDITOFECHA = "NotaCreditoFecha";
        private const string CAMPO_CLIENTEID = "ClienteID";
        private const string CAMPO_NOMBRECLIENTE = "NombreCliente";
        private const string CAMPO_IDIOMACLIENTE = "IdiomaID";
        private const string CAMPO_MONEDAID = "MonedaID";
        private const string CAMPO_MONEDADESCRIP = "MonedaDescrip";
        private const string CAMPO_NOTACREDITOMONTO = "NotaCreditoMonto";
        private const string CAMPO_NOTACREDITOCUERPO = "NotaCreditoCuerpo";
        private const string CAMPO_NOTACREDITOREF = "NotaCreditoReferencia";
        private const string CAMPO_NOTACREDITOANULADO = "NotaCreditoAnulado";
        private const string CAMPO_NCFECANULACION = "FechaAnulacion";
        private const string CAMPO_NOTACREDITOSALDO = "NotaCreditoSaldo";
        private const string CAMPO_NOTACREDITOPRESUP = "NotaCreditoPresupuestos";
        //Campos Tabla Detalle
        private const string CAMPO_NCDETMONTO = "NotaCreditoDetMonto";
        private const string CAMPO_NCDETMONEDAABREV = "NotaCreditoDetMonedaAbrev";
        private const string CAMPO_NCDETPAGOID = "NotaCreditoDetPagoID";
        private const string CAMPO_NCDETPRESUPUESTOCABID = "NotaCreditoDetPresupuestoCabID";
        private const string CAMPO_NCDETDOCUMENTONRO = "NotaCreditoDetDocumentoNro";
        private const string CAMPO_NCDETTRAMITEID = "NotaCreditoDetTramiteID";
        private const string CAMPO_NCDETTRAMITEDESCRIP  = "NotaCreditoDetTramiteDescrip";
        private const string CAMPO_NCDETANULADO         = "NotaCreditoDetAnulado";
        private const int TIPODOCUMENTO_NOTACREDITO = 5;
        private const int IDIOMA_ESPANOL = 2;
        private const string ESTADO_PENDIENTE = "A";
        #endregion Constantes

        #region Variables
        frmPickBase fPickMoneda;
        frmPickBase fPickCliente;
        int UsuarioID = -1;
        List<NotaCreditoPresupAll> ncs;
        FSeleccionarPresupuestoNC fSeleccionPresupAsoc;
        #endregion Variables

        #region Métodos de Inicio
        public ucCRUDNotaCreditoPresup()
        {
            InitializeComponent();
        }


        public ucCRUDNotaCreditoPresup(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();
            this.DBContext = dbContext;
            this.Titulo = Titulo;
            this.tbbImprimir.Visible = true;
            this.tbbBorrar.Visible = false;
            this.UsuarioID = Convert.ToInt32(VWGContext.Current.Session["UsuarioID"].ToString());

            ncs = new List<NotaCreditoPresupAll>();

            ncs = (from ncp in this.DBContext.ncp_notacreditopresup
                         join cli in this.DBContext.Cliente
                            on ncp.ncp_clienteid equals cli.ID
                         join mon in this.DBContext.Moneda
                            on ncp.ncp_monedaid equals mon.ID
                         join ncd in this.DBContext.ncd_notacreditopresupdetalle
                            on ncp.ncp_notacreditoid equals ncd.ncd_notacreditocabid into ncd_ncp
                            from ncd in ncd_ncp.DefaultIfEmpty()
                         join pap in this.DBContext.pp_pagopresupuesto
                            on ncd.ncd_pagoid equals pap.pp_pagopresupuestoid into pap_ncp
                            from pap in pap_ncp.DefaultIfEmpty()
                         join pcb in this.DBContext.pc_presupuestocab
                            on pap.pp_presupuestocabid equals pcb.pc_presupuestocabid into pcb_pap
                            from pcb in pcb_pap.DefaultIfEmpty()
                         join tra in this.DBContext.Tramite
                            on pcb.pc_tramiteid equals tra.ID into tra_pcb
                            from tra in tra_pcb.DefaultIfEmpty()
                         select new NotaCreditoPresupAll
                         {  
                             //Cabecera
                             NotaCreditoID = ncp.ncp_notacreditoid,
                             NotaCreditoNro = ncp.ncp_nrocomprobante,
                             NotaCreditoFecha = ncp.ncp_fecha,
                             ClienteID = ncp.ncp_clienteid,
                             NombreCliente = cli.Nombre,
                             IdiomaID = cli.IdiomaID,
                             MonedaID = ncp.ncp_monedaid,
                             MonedaDescrip = mon.Descripcion,
                             NotaCreditoMonto = ncp.ncp_monto,
                             NotaCreditoCuerpo = ncp.ncp_cuerponota,
                             NotaCreditoReferencia = ncp.ncp_referenciacliente,
                             NotaCreditoAnulado = ncp.ncp_anulado,
                             FechaAnulacion = ncp.ncp_fechaanulacion,
                             NotaCreditoSaldo = ncp.ncp_saldo,
                             NotaCreditoPresupuestos = ncp.ncp_presupuestos,
                             TieneAutorizacionVigente = this.DBContext.GetAutorizacionPorDocumentoID(TIPODOCUMENTO_NOTACREDITO,
                                                                                                     ncp.ncp_notacreditoid,
                                                                                                     this.UsuarioID)
                                                                                                     .FirstOrDefault().Value,
                             //Detalle
                             NotaCreditoDetID = ncd.ncd_notacreditopresupdetid,
                             NotaCreditoDetPagoID = ncd.ncd_pagoid,
                             NotaCreditoDetMonto = ncd.ncd_monto,
                             NotaCreditoDetMonedaAbrev = mon.AbrevMoneda,
                             NotaCreditoDetPresupuestoCabID = pcb.pc_presupuestocabid,
                             NotaCreditoDetDocumentoNro = this.DBContext.GetDocumentoNro(pcb.pc_presupuestocabid).FirstOrDefault(),
                             NotaCreditoDetTramiteID = pcb.pc_tramiteid,
                             NotaCreditoDetTramiteDescrip = tra.EtiquetaEsp,
                             NotaCreditoDetAnulado = pap.pp_anulado
                         })
                         .OrderByDescending(a => a.NotaCreditoID)
                         .Take(50)
                         .ToList();

            this.BindingSourceBase_ExportExcelGrid = ncs;
            //this.LoadGridExportToExcel();

            var query = (from item in ncs
                        select new NotaCreditoPresupCab
                         {  
                             //Cabecera
                             NotaCreditoID = item.NotaCreditoID,
                             NotaCreditoNro = item.NotaCreditoNro,
                             NotaCreditoFecha = item.NotaCreditoFecha,
                             ClienteID = item.ClienteID,
                             NombreCliente = item.NombreCliente,
                             IdiomaID = item.IdiomaID,
                             MonedaID = item.MonedaID,
                             MonedaDescrip = item.MonedaDescrip,
                             NotaCreditoMonto = item.NotaCreditoMonto,
                             NotaCreditoCuerpo = item.NotaCreditoCuerpo,
                             NotaCreditoReferencia = item.NotaCreditoReferencia,
                             NotaCreditoAnulado = item.NotaCreditoAnulado,
                             FechaAnulacion = item.FechaAnulacion,
                             NotaCreditoSaldo = item.NotaCreditoSaldo,
                             NotaCreditoPresupuestos = item.NotaCreditoPresupuestos,
                             TieneAutorizacionVigente = item.TieneAutorizacionVigente
                         })
                         .GroupBy(x => new { x.NotaCreditoID }).Select(g => g.First()).ToList();

            this.BindingSourceBase = query;

            #region Especificar campos para filtro
            this.SetFilter(CAMPO_NOTACREDITOID, "Nota Crédito ID", false);
            this.SetFilter(CAMPO_NOTACREDITONRO, "N° Nota Crédito", false);
            this.SetFilter(CAMPO_NOTACREDITOFECHA, "Fecha Nota Crédito");
            this.SetFilter(CAMPO_CLIENTEID, "Cliente ID", false);
            this.SetFilter(CAMPO_NOMBRECLIENTE, "Nombre Cliente");
            //
            this.SetFilter(CAMPO_NCDETPAGOID, "Pago ID", false);
            this.SetFilter(CAMPO_NCDETMONTO, "Monto Pago", false);
            //
            this.SetFilter(CAMPO_MONEDAID, "Moneda ID", false);
            this.SetFilter(CAMPO_MONEDADESCRIP, "Moneda Descrip.");
            this.SetFilter(CAMPO_NOTACREDITOMONTO, "Nota Crédito Monto", false);
            this.SetFilter(CAMPO_NOTACREDITOSALDO, "Nota Crédito Saldo", false);
            this.SetFilter(CAMPO_NOTACREDITOPRESUP, "Presupuestos/Fact.");
            this.SetFilter(CAMPO_NOTACREDITOCUERPO, "Nota Crédito Cuerpo");
            this.SetFilter(CAMPO_NOTACREDITOREF, "Nota Crédito Referencia");
            this.SetFilter(CAMPO_NOTACREDITOANULADO, "Anulado (S/N)", false);
            this.SetFilter(CAMPO_NCFECANULACION, "N. Créd. Fec. Anul.");
            this.TituloBuscador = "Buscar Notas Crédito de Presupuestos";
            #endregion Especificar campos para filtro

            #region Inicializar TextSearchBoxes
            this.tSBCliente.KeyMemberWidth = 70;
            this.tSBCliente.ToolTip = "Elegir Cliente";
            this.tSBCliente.AceptarClick += tSBCliente_AceptarClick;

            this.tSBMoneda.KeyMemberWidth = 70;
            this.tSBMoneda.ToolTip = "Elegir Moneda";
            this.tSBMoneda.AceptarClick += tSBMoneda_AceptarClick;
            #endregion Inicializar TextSearchBoxes
            //this.FormEditStatus = BROWSE;
        }

        #endregion Métodos de Inicio

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
                fPickMoneda.NombreCampo = "Tarifa";
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

            fPickMoneda.Close();
            fPickMoneda.Dispose();
        }

        #endregion Moneda

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

        #region Método Extendidos del ParentControl
        protected override void FilterEntity(string where = "", object[] filterParams = null)
        {
            try
            {
                this.limpiarDatos();

                var query = (from ncp in this.DBContext.ncp_notacreditopresup
                           join cli in this.DBContext.Cliente
                              on ncp.ncp_clienteid equals cli.ID
                           join mon in this.DBContext.Moneda
                              on ncp.ncp_monedaid equals mon.ID
                           join ncd in this.DBContext.ncd_notacreditopresupdetalle
                              on ncp.ncp_notacreditoid equals ncd.ncd_notacreditocabid into ncd_ncp
                              from ncd in ncd_ncp.DefaultIfEmpty()
                           join pap in this.DBContext.pp_pagopresupuesto
                            on ncd.ncd_pagoid equals pap.pp_pagopresupuestoid into pap_ncp
                            from pap in pap_ncp.DefaultIfEmpty()
                             join pcb in this.DBContext.pc_presupuestocab
                                on pap.pp_presupuestocabid equals pcb.pc_presupuestocabid into pcb_pap
                                from pcb in pcb_pap.DefaultIfEmpty()
                             join tra in this.DBContext.Tramite
                                on pcb.pc_tramiteid equals tra.ID into tra_pcb
                                from tra in tra_pcb.DefaultIfEmpty()
                           select new NotaCreditoPresupAll
                           {
                               //Cabecera
                               NotaCreditoID = ncp.ncp_notacreditoid,
                               NotaCreditoNro = ncp.ncp_nrocomprobante,
                               NotaCreditoFecha = ncp.ncp_fecha,
                               ClienteID = ncp.ncp_clienteid,
                               NombreCliente = cli.Nombre,
                               IdiomaID = cli.IdiomaID,
                               MonedaID = ncp.ncp_monedaid,
                               MonedaDescrip = mon.Descripcion,
                               NotaCreditoMonto = ncp.ncp_monto,
                               NotaCreditoCuerpo = ncp.ncp_cuerponota,
                               NotaCreditoReferencia = ncp.ncp_referenciacliente,
                               NotaCreditoAnulado = ncp.ncp_anulado,
                               FechaAnulacion = ncp.ncp_fechaanulacion,
                               NotaCreditoSaldo = ncp.ncp_saldo,
                               NotaCreditoPresupuestos = ncp.ncp_presupuestos,
                               TieneAutorizacionVigente = this.DBContext.GetAutorizacionPorDocumentoID(TIPODOCUMENTO_NOTACREDITO,
                                                                                                       ncp.ncp_notacreditoid,
                                                                                                       this.UsuarioID)
                                                                                                       .FirstOrDefault().Value,
                               //Detalle
                               NotaCreditoDetID = ncd.ncd_notacreditopresupdetid,
                               NotaCreditoDetPagoID = ncd.ncd_pagoid,
                               NotaCreditoDetMonto = ncd.ncd_monto,
                               NotaCreditoDetMonedaAbrev = mon.AbrevMoneda,
                               NotaCreditoDetPresupuestoCabID = pcb.pc_presupuestocabid,
                               NotaCreditoDetDocumentoNro = this.DBContext.GetDocumentoNro(pcb.pc_presupuestocabid).FirstOrDefault(),
                               NotaCreditoDetTramiteID = pcb.pc_tramiteid,
                               NotaCreditoDetTramiteDescrip = tra.EtiquetaEsp,
                               NotaCreditoDetAnulado = pap.pp_anulado
                           });

                //List<NotaCreditoPresupAll> ncs = new List<NotaCreditoPresupAll>();
                ncs.Clear();
                if (where != "")
                {
                    //this.BindingSourceBase = query.Where(where, filterParams).OrderByDescending(a => a.NotaCreditoID).ToList();
                    ncs = query.Where(where, filterParams).OrderByDescending(a => a.NotaCreditoID).ToList();
                }
                else
                {
                    //this.BindingSourceBase = query.OrderByDescending(a => a.NotaCreditoID).Take(50).ToList();
                    ncs = query.OrderByDescending(a => a.NotaCreditoID).Take(50).ToList();
                }

                this.BindingSourceBase_ExportExcelGrid = ncs;
                //this.LoadGridExportToExcel();

                var query1 = (from item in ncs
                             select new NotaCreditoPresupCab
                             {
                                 //Cabecera
                                 NotaCreditoID = item.NotaCreditoID,
                                 NotaCreditoNro = item.NotaCreditoNro,
                                 NotaCreditoFecha = item.NotaCreditoFecha,
                                 ClienteID = item.ClienteID,
                                 NombreCliente = item.NombreCliente,
                                 IdiomaID = item.IdiomaID,
                                 MonedaID = item.MonedaID,
                                 MonedaDescrip = item.MonedaDescrip,
                                 NotaCreditoMonto = item.NotaCreditoMonto,
                                 NotaCreditoCuerpo = item.NotaCreditoCuerpo,
                                 NotaCreditoReferencia = item.NotaCreditoReferencia,
                                 NotaCreditoAnulado = item.NotaCreditoAnulado,
                                 FechaAnulacion = item.FechaAnulacion,
                                 NotaCreditoSaldo = item.NotaCreditoSaldo,
                                 NotaCreditoPresupuestos = item.NotaCreditoPresupuestos,
                                 TieneAutorizacionVigente = item.TieneAutorizacionVigente
                             })
                             .GroupBy(x => new { x.NotaCreditoID }).Select(g => g.First()).ToList();

                this.BindingSourceBase = query1;
                
                this.FormatearGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al filtrar los datos: " + Environment.NewLine + ex.Message, "Información de Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        protected override void FormatearGrilla()
        {
            base.FormatearGrilla();

            foreach (DataGridViewColumn col in this.dgvListadoABM.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            int displayIndex = 0;

            this.dgvListadoABM.Columns[CAMPO_NOTACREDITOID].HeaderText = "NC ID";
            this.dgvListadoABM.Columns[CAMPO_NOTACREDITOID].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_NOTACREDITOID].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_NOTACREDITOID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_NOTACREDITOID].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_NOTACREDITONRO].HeaderText = "NC N°";
            this.dgvListadoABM.Columns[CAMPO_NOTACREDITONRO].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_NOTACREDITONRO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_NOTACREDITONRO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_NOTACREDITONRO].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_NOTACREDITOFECHA].HeaderText = "Fecha NC";
            this.dgvListadoABM.Columns[CAMPO_NOTACREDITOFECHA].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_NOTACREDITOFECHA].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_NOTACREDITOFECHA].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_NOTACREDITOFECHA].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_NOMBRECLIENTE].HeaderText = "Cliente";
            this.dgvListadoABM.Columns[CAMPO_NOMBRECLIENTE].Width = 250;
            this.dgvListadoABM.Columns[CAMPO_NOMBRECLIENTE].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_NOMBRECLIENTE].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_NOTACREDITOMONTO].HeaderText = "Monto";
            this.dgvListadoABM.Columns[CAMPO_NOTACREDITOMONTO].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_NOTACREDITOMONTO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_NOTACREDITOMONTO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_NOTACREDITOMONTO].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_NOTACREDITOSALDO].HeaderText = "Saldo";
            this.dgvListadoABM.Columns[CAMPO_NOTACREDITOSALDO].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_NOTACREDITOSALDO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_NOTACREDITOSALDO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_NOTACREDITOSALDO].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_MONEDADESCRIP].HeaderText = "Moneda";
            this.dgvListadoABM.Columns[CAMPO_MONEDADESCRIP].Width = 110;
            this.dgvListadoABM.Columns[CAMPO_MONEDADESCRIP].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_MONEDADESCRIP].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_NOTACREDITOPRESUP].HeaderText = "Presupuestos Asociados";
            this.dgvListadoABM.Columns[CAMPO_NOTACREDITOPRESUP].Width = 150;
            this.dgvListadoABM.Columns[CAMPO_NOTACREDITOPRESUP].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_NOTACREDITOPRESUP].Visible = true;
            displayIndex++;

            DataGridViewCheckBoxColumn colAnulado = new DataGridViewCheckBoxColumn();
            colAnulado.DataPropertyName = CAMPO_NOTACREDITOANULADO;
            colAnulado.Name = CAMPO_NOTACREDITOANULADO;
            colAnulado.HeaderText = "Anulado";
            colAnulado.FalseValue = false;
            colAnulado.TrueValue = true;
            colAnulado.ReadOnly = true;
            this.dgvListadoABM.Columns.Insert(displayIndex, colAnulado);
        }

        private void FormatearGrillaDet()
        {
            this.dgvPagosAsoc.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvPagosAsoc.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dgvPagosAsoc.DefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvPagosAsoc.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvPagosAsoc.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            this.dgvPagosAsoc.ItemsPerPage = 8;
            this.dgvPagosAsoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            foreach (DataGridViewColumn col in this.dgvPagosAsoc.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            int displayIndex = 0;

            this.dgvPagosAsoc.Columns[CAMPO_NCDETPAGOID].HeaderText = "Pago ID";
            this.dgvPagosAsoc.Columns[CAMPO_NCDETPAGOID].Width = 80;
            this.dgvPagosAsoc.Columns[CAMPO_NCDETPAGOID].DisplayIndex = displayIndex;
            this.dgvPagosAsoc.Columns[CAMPO_NCDETPAGOID].Visible = true;
            displayIndex++;

            this.dgvPagosAsoc.Columns[CAMPO_NCDETDOCUMENTONRO].HeaderText = "N° Documento";
            this.dgvPagosAsoc.Columns[CAMPO_NCDETDOCUMENTONRO].Width = 120;
            this.dgvPagosAsoc.Columns[CAMPO_NCDETDOCUMENTONRO].DisplayIndex = displayIndex;
            this.dgvPagosAsoc.Columns[CAMPO_NCDETDOCUMENTONRO].Visible = true;
            displayIndex++;

            this.dgvPagosAsoc.Columns[CAMPO_NCDETMONEDAABREV].HeaderText = "Moneda";
            this.dgvPagosAsoc.Columns[CAMPO_NCDETMONEDAABREV].Width = 80;
            this.dgvPagosAsoc.Columns[CAMPO_NCDETMONEDAABREV].DisplayIndex = displayIndex;
            this.dgvPagosAsoc.Columns[CAMPO_NCDETMONEDAABREV].Visible = true;
            displayIndex++;

            this.dgvPagosAsoc.Columns[CAMPO_NCDETMONTO].HeaderText = "Monto";
            this.dgvPagosAsoc.Columns[CAMPO_NCDETMONTO].Width = 80;
            this.dgvPagosAsoc.Columns[CAMPO_NCDETMONTO].DisplayIndex = displayIndex;
            this.dgvPagosAsoc.Columns[CAMPO_NCDETMONTO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvPagosAsoc.Columns[CAMPO_NCDETMONTO].Visible = true;
            displayIndex++;

            this.dgvPagosAsoc.Columns[CAMPO_NCDETTRAMITEDESCRIP].HeaderText = "Trámite";
            this.dgvPagosAsoc.Columns[CAMPO_NCDETTRAMITEDESCRIP].Width = 250;
            this.dgvPagosAsoc.Columns[CAMPO_NCDETTRAMITEDESCRIP].DisplayIndex = displayIndex;
            this.dgvPagosAsoc.Columns[CAMPO_NCDETTRAMITEDESCRIP].Visible = true;
            displayIndex++;

            DataGridViewCheckBoxColumn colAnulado = new DataGridViewCheckBoxColumn();
            colAnulado.DataPropertyName = CAMPO_NCDETANULADO;
            colAnulado.HeaderText = "Anulado";
            colAnulado.FalseValue = false;
            colAnulado.TrueValue = true;
            colAnulado.ReadOnly = true;
            colAnulado.Width = 80;
            this.dgvPagosAsoc.Columns.Insert(displayIndex, colAnulado);
        }

        protected override void tbbNuevo_Click(object sender, EventArgs e)
        {
            base.tbbNuevo_Click(sender, e);
            this.limpiarDatos();
            this.txtFechaNC.Text = System.DateTime.Now.ToShortDateString();
            this.txtMonto.Text = "0,00";
            this.txtSaldo.Text = "0,00";

            this.txtFechaNC.Focus();
        }

        protected override void tbbEditar_Click(object sender, EventArgs e)
        {
            if (this.ExistePagoAsociado(Convert.ToInt32(this.txtNCID.Text)))
            {
                MessageBox.Show("No se pueden realizar modificaciones debido a que el documento ya tiene pagos asociados.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }
            base.tbbEditar_Click(sender, e);
            this.txtFechaNC.Focus();
        }
        #endregion Método Extendidos del ParentControl

        #region Limpiar Datos
        private void limpiarDatos()
        {
            this.txtNCID.Text = "";
            this.txtNCNro.Text = "";
            this.chkAnulado.Checked = false;
            this.txtFechaNC.Text = "";
            this.txtMonto.Text = "";
            this.txtSaldo.Text = "";
            this.tSBCliente.Clear();
            this.tSBMoneda.Clear();
            this.txtPresupAsoc.Text = "";
            this.txtNCReferencia.Text = "";
            this.txtNCCuerpo.Text = "";
            this.lblAutorizacionVigente.Visible = false;
        }
        #endregion Limpiar Datos

        #region ReadOnly condicional
        protected override void Editable(bool editar)
        {
            //this.txtNCID.ReadOnly = editar;
            //this.txtNCNro.ReadOnly = editar;
            //this.chkAnulado.Enabled = !editar;
            this.txtFechaNC.ReadOnly = editar;
            this.dtpFechaNC.Enabled = !editar;
            this.txtMonto.ReadOnly = editar;
            this.txtSaldo.ReadOnly = editar;
            this.tSBCliente.Editable = !editar;
            this.tSBMoneda.Editable = !editar;
            //this.txtPresupAsoc.ReadOnly = editar;
            this.txtNCReferencia.ReadOnly = editar;
            this.txtNCCuerpo.ReadOnly = editar;
            this.btnBuscar.Enabled = !editar;
        }
        #endregion ReadOnly condicional

        #region Controles Locales
        private void tbbImprimir_Click_1(object sender, EventArgs e)
        {
            if (this.FormEditStatus == BROWSE)
            {
                if (this.txtNCID.Text == "")
                {
                    MessageBox.Show("No hay nada que imprimir.",
                                    "Información",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    return;
                }

                try
                {
                    int NotaCreditoID = Convert.ToInt32(this.txtNCID.Text);
                    NotaCreditoPresupAll nca = ncs.First(a => a.NotaCreditoID == NotaCreditoID);

                    if (nca.NotaCreditoAnulado)
                    {
                        throw new Exception("No se puede imprimir un documento anulado.");
                    }

                    ncp_notacreditopresup ncp = new ncp_notacreditopresup();

                    ncp.ncp_fecha = nca.NotaCreditoFecha;
                    ncp.ncp_nrocomprobante = nca.NotaCreditoNro;
                    ncp.ncp_monto = nca.NotaCreditoMonto;
                    ncp.ncp_monedaid = nca.MonedaID;
                    ncp.ncp_clienteid = nca.ClienteID;
                    ncp.ncp_referenciacliente = nca.NotaCreditoReferencia;
                    ncp.ncp_cuerponota = nca.NotaCreditoCuerpo;
                    ncp.ncp_presupuestos = nca.NotaCreditoPresupuestos;
                    this.MostrarNotaCredito(new List<NotaCreditoPresupType>() { GenerarNotaCredito.CrearDataSet(this.DBContext, ncp) });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al mostrar el documento: " + Environment.NewLine + ex.Message, "Información de Error", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                }
            }

        }

        private void cargarDatos(DataGridViewRow row)
        {
            this.limpiarDatos();

            this.txtNCID.Text = row.Cells[CAMPO_NOTACREDITOID].Value.ToString();
            this.txtNCNro.Text = row.Cells[CAMPO_NOTACREDITONRO].Value.ToString();
            this.chkAnulado.Checked = row.Cells[CAMPO_NOTACREDITOANULADO].Value != null && (bool)row.Cells[CAMPO_NOTACREDITOANULADO].Value ? true : false;
            this.txtFechaNC.Text = Convert.ToDateTime(row.Cells[CAMPO_NOTACREDITOFECHA].Value).ToShortDateString();
            this.txtMonto.Text = String.Format("{0:0.00}", (decimal)row.Cells[CAMPO_NOTACREDITOMONTO].Value);
            this.txtSaldo.Text = String.Format("{0:0.00}", (decimal)row.Cells[CAMPO_NOTACREDITOSALDO].Value);
            this.tSBCliente.KeyMember = row.Cells[CAMPO_CLIENTEID].Value.ToString();
            this.tSBCliente.DisplayMember = row.Cells[CAMPO_NOMBRECLIENTE].Value.ToString();
            this.tSBMoneda.KeyMember = row.Cells[CAMPO_MONEDAID].Value.ToString();
            this.tSBMoneda.DisplayMember = row.Cells[CAMPO_MONEDADESCRIP].Value.ToString();
            this.txtPresupAsoc.Text = row.Cells[CAMPO_NOTACREDITOPRESUP].Value != null ? row.Cells[CAMPO_NOTACREDITOPRESUP].Value.ToString() : "";
            this.txtNCReferencia.Text = row.Cells[CAMPO_NOTACREDITOREF].Value != null ? row.Cells[CAMPO_NOTACREDITOREF].Value.ToString() : "";
            this.txtNCCuerpo.Text = row.Cells[CAMPO_NOTACREDITOCUERPO].Value != null ? row.Cells[CAMPO_NOTACREDITOCUERPO].Value.ToString() : "";
            this.lblAutorizacionVigente.Visible = (bool)row.Cells[CAMPO_AUTORIZACIONVIG].Value;

            //Cargar Grilla Pagos
            this.CargarGrillaPagosAsociados(Convert.ToInt32(this.txtNCID.Text));
        }

        private void dgvListadoABM_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((this.FormEditStatus == BROWSE) && (this.dgvListadoABM.RowCount > 0))
            {
                this.cargarDatos(this.dgvListadoABM.Rows[e.RowIndex]);
            }
            else
                this.limpiarDatos();
            
            
        }

        private void tbbCancelar_Click_1(object sender, EventArgs e)
        {
            base.tbbCancelar_Click(sender, e);

            if (this.dgvListadoABM.RowCount > 0)
            {
                this.dgvListadoABM.Rows[this.LastDGVIndex].Selected = true;
                this.cargarDatos(this.dgvListadoABM.Rows[this.LastDGVIndex]);
            }
            else
                this.limpiarDatos();
        }

        private void tbbGuardar_Click(object sender, EventArgs e)
        {
            #region Validaciones
            if (this.txtFechaNC.Text == "")
            {
                MessageBox.Show("Debe ingresar una fecha válida.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if ((this.txtMonto.Text == "") || (Convert.ToDecimal(this.txtMonto.Text) == 0))
            {
                MessageBox.Show("Debe ingresar un monto válido mayor a 0 (cero).",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (this.tSBCliente.KeyMember == "")
            {
                MessageBox.Show("Debe ingresar un cliente válido.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (this.tSBMoneda.KeyMember == "")
            {
                MessageBox.Show("Debe ingresar una moneda válida.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (this.txtNCCuerpo.Text == "")
            {
                MessageBox.Show("Debe ingresar la descripción de la nota de crédito válido.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }
            #endregion Validaciones

            string message = "";
            string caption = "";
            if (this.FormEditStatus == EDIT)
            {
                caption = "Actualización de registro";
                message = "Se modificará el presente registro ¿Desea continuar?";
            }
            else if (this.FormEditStatus == INSERT)
            {
                caption = "Inserción de nuevo de registro";
                message = "Se insertará un nuevo registro ¿Desea continuar?";
            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(DialogHandler));
        }

        private void DialogHandlerValidacion(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.No)
                {
                    return;
                }
            }
        }

        private void DialogHandler(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    if (this.FormEditStatus != BROWSE)
                        this.GuardarRegistro();
                    
                }
            }
        }

        private void tbbBorrar_Click_1(object sender, EventArgs e)
        {
            if (this.ExistePagoAsociado(Convert.ToInt32(this.txtNCID.Text)))
            {
                MessageBox.Show("No se pueden eliminar la nota de crédito porque tiene pagos asociados.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            string caption = "Eliminación de registro";
            string message = "Se eliminará el presente registro ¿Desea continuar?";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(DialogHandler));

        }

        
        private void dtpFechaNC_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaNC.Text = this.dtpFechaNC.Value.ToShortDateString();
        }

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            if (this.FormEditStatus != BROWSE)
                this.txtSaldo.Text = this.txtMonto.Text;
        }

        private void txtSaldo_TextChanged(object sender, EventArgs e)
        {
            if (this.FormEditStatus != BROWSE)
                this.txtSaldo.Text = this.txtMonto.Text;
        }

        private void tbbAnular_Click(object sender, EventArgs e)
        {
            if (!this.lblAutorizacionVigente.Visible)
            {
                MessageBox.Show("No se puede anular la nota de crédito debido a que no posee autorización vigente.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;

            }

            if (this.chkAnulado.Checked)
            {
                MessageBox.Show("No se puede anular la nota de crédito debido a que ya se encuentra en ese estado.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            //if ((Convert.ToInt32(this.tSBFormaPago.KeyMember) == FORMAPAGO_NOTACREDITOPRESUPUESTO)
            //    && (this.ExisteNotaCredito()))
            //{
            //    MessageBox.Show("No se puede anular el pago debido a que existe una nota de crédito asociada." + Environment.NewLine +
            //                    "Debe anular la nota de crédito para anular todos los pagos incluidos en ella.",
            //                    "Información",
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Information);
            //    return;
            //}

            string message = "";
            string caption = "";
            caption = "Anulación de Nota de Crédito";
            message = "Se anulará la nota de crédito y todos los pagos asociados a ella ¿Desea continuar?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(AnularDialogHandler));
        }

        private void AnularDialogHandler(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    this.AnularNC(Convert.ToInt32(this.txtNCID.Text));
                }
            }
        }

        private void dgvListadoABM_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.RowIndex > -1) &&
                (this.dgvListadoABM.Rows[e.RowIndex].Cells[CAMPO_AUTORIZACIONVIG].Value != null) &&
                ((bool)(this.dgvListadoABM.Rows[e.RowIndex].Cells[CAMPO_AUTORIZACIONVIG].Value)))
            {
                ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }

        private void ucCRUDNotaCreditoPresup_VisibleChanged(object sender, EventArgs e)
        {
            this.FormatearGrilla();

            if ((this.tabListaABM.SelectedIndex == 2) && (this.dgvPagosAsoc.DataSource != null))
                this.FormatearGrillaDet();
        }

        private void tSBCliente_Leave(object sender, EventArgs e)
        {
            if ((this.FormEditStatus == INSERT) && (this.txtNCCuerpo.Text == ""))
            {
                int clienteID = Convert.ToInt32(this.tSBCliente.KeyMember);
                Cliente cli = this.DBContext.Cliente.First(a => a.ID == clienteID);

                this.txtNCCuerpo.Text = cli.IdiomaID.Value == IDIOMA_ESPANOL ?
                                        "Crédito por los honorarios y gastos facturados en la(s) nota(s):" :
                                        "Credit note for the work instructed regarding note(s):";
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if ((this.tSBCliente.KeyMember == ""))
            {
                MessageBox.Show("Debe seleccionar un cliente.",
                               "Información",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return;
            }

            if ((this.txtFechaNC.Text == ""))
            {
                MessageBox.Show("Debe ingresar una fecha para la Nota de Crédito.",
                               "Información",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return;
            }

            try
            {

                string[] rangoFechas = this.GetRangoFechas(Convert.ToDateTime(this.txtFechaNC.Text));

                if (fSeleccionPresupAsoc == null)
                {
                    fSeleccionPresupAsoc = new FSeleccionarPresupuestoNC(this.DBContext,
                                                                                "Selección de Presupuestos",
                                                                                rangoFechas[0],
                                                                                rangoFechas[1],
                                                                                Convert.ToInt32(this.tSBCliente.KeyMember));
                    fSeleccionPresupAsoc.AceptarClick += f_AceptarClick;
                }

                fSeleccionPresupAsoc.ListaPresupuestos = this.txtPresupAsoc.Text.Replace(", ", ",");
                fSeleccionPresupAsoc.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + Environment.NewLine + ex.Message, "Información de Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        #endregion Controles Locales

        #region Método de Apoyo
        private void AnularNC(int NCID)
        {
            bool success = false;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (ncd_notacreditopresupdetalle ncd in context.ncd_notacreditopresupdetalle.Where(a => a.ncd_notacreditocabid == NCID).ToList())
                        {
                            int PagoPrespuestoID = ncd.ncd_pagoid;
                            pp_pagopresupuesto pPag = context.pp_pagopresupuesto.First(a => a.pp_pagopresupuestoid == PagoPrespuestoID);
                            pPag.pp_anulado = true;

                            int PresupuestoCabID = pPag.pp_presupuestocabid;
                            pc_presupuestocab pCab = context.pc_presupuestocab.First(a => a.pc_presupuestocabid == PresupuestoCabID);
                            pCab.pc_saldo += pPag.pp_montopago;
                            pCab.pc_estado = ESTADO_PENDIENTE;
                        }

                        ncp_notacreditopresup ncp = context.ncp_notacreditopresup.First(a => a.ncp_notacreditoid == NCID);
                        ncp.ncp_anulado = true;
                        ncp.ncp_fechaanulacion = DateTime.Now;

                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        MessageBox.Show("Ocurrió un error al anular la nota de crédito. "
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
                this.FilterEntity(this.WhereString, this.FilterParam);
                this.cargarDatos(this.dgvListadoABM.Rows[this.LastDGVIndex]);
                MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void MostrarNotaCredito(List<NotaCreditoPresupType> ncCuerpo)
        {

            if (ncCuerpo.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte.",
                                "Atención Requerida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            ReportDataSource datasource = null;
            datasource = new ReportDataSource("DataSet1", ncCuerpo);

            int ClienteID = ncCuerpo.First().ClienteID;
            int IdiomaID = ncCuerpo.First().IdiomaID;

            string path = IdiomaID == IDIOMA_ESPANOL ? @"Reportes\RepNotaCreditoEsp.rdlc" : @"Reportes\RepNotaCreditoIng.rdlc";
            string asuntoMail = IdiomaID == IDIOMA_ESPANOL ? "Nota de Crédito N° " + ncCuerpo.First().NroNotaCredito : "Credit Note N° " + ncCuerpo.First().NroNotaCredito;
            string cuerpoMail = IdiomaID == IDIOMA_ESPANOL ? "Por favor revise el documento adjunto." : "Please check the attached document.";
            string nombreArchivo = IdiomaID == IDIOMA_ESPANOL ? "NotadeCredito-" : "CreditNote-";

            FReportViewerBase f = new FReportViewerBase(path, datasource, this.DBContext);
            f.FormClosed += delegate { f = null; };
            f.Titulo = "Nota de Crédito N° " + ncCuerpo.First().NroNotaCredito + " - " + ncCuerpo.First().NombreCliente + " (" + ClienteID.ToString() + ")";
            f.NombreArchivoAdjunto = nombreArchivo + ncCuerpo.First().NroNotaCredito + "-" + ClienteID.ToString();
            f.AsuntoMail = asuntoMail + " - " + ncCuerpo.First().NombreCliente + " (" + ClienteID.ToString() + ")";
            f.CuerpoMail = cuerpoMail;
            f.ShowDialog();
        }

        private bool ExistePagoAsociado(int NotaCreditoID)
        {
            bool Result = false;

            List<NotaCreditoPresupAll> nca = ncs.Where(a => a.NotaCreditoID == NotaCreditoID && a.NotaCreditoDetPagoID != null).ToList();

            if (nca.Count > 0)
                Result = true;
            return Result;
        }

        private void CargarGrillaPagosAsociados(int NotaCreditoID)
        {
            var query = (from item in ncs
                         select new
                         {
                             NotaCreditoID = item.NotaCreditoID,
                             NotaCreditoDetMonto = item.NotaCreditoDetMonto,
                             NotaCreditoDetMonedaAbrev = item.NotaCreditoDetMonedaAbrev,
                             NotaCreditoDetPagoID = item.NotaCreditoDetPagoID,
                             NotaCreditoDetPresupuestoCabID = item.NotaCreditoDetPresupuestoCabID,
                             NotaCreditoDetDocumentoNro = item.NotaCreditoDetDocumentoNro,
                             NotaCreditoDetTramiteID = item.NotaCreditoDetTramiteID,
                             NotaCreditoDetTramiteDescrip = item.NotaCreditoDetTramiteDescrip,
                             NotaCreditoDetAnulado = item.NotaCreditoAnulado
                         }
                        )
                        .Where(a => a.NotaCreditoID == NotaCreditoID).ToList();
            if ((query.Count > 0) && (query.First().NotaCreditoDetPagoID != null))
            {
                this.dgvPagosAsoc.DataSource = query;
                this.FormatearGrillaDet();
            }
            else
                this.dgvPagosAsoc.DataSource = null;

            
        }

        private string[] GetRangoFechas(DateTime fechaNC)
        {
            List<string> Result = new List<string>();

            DateTime fechaDesde = new DateTime(fechaNC.AddMonths(-3).Year, fechaNC.AddMonths(-3).Month, 1);
            Result.Add(fechaDesde.ToShortDateString());

            DateTime fechaHasta = new DateTime(fechaDesde.AddMonths(2).Year, fechaDesde.AddMonths(2).Month, DateTime.DaysInMonth(fechaDesde.AddMonths(2).Year, fechaDesde.AddMonths(2).Month));
            Result.Add(fechaHasta.ToShortDateString());

            return Result.ToArray();
        }

        #endregion Método de Apoyo

        #region Eventos delegados
        private void f_AceptarClick(object sender, EventArgs e)
        {
            this.txtPresupAsoc.Text = fSeleccionPresupAsoc.ListaPresupuestos;
            fSeleccionPresupAsoc.Close();
        }
        #endregion Eventos delegados

        #region CRUD
        private void GuardarRegistro()
        {
            bool success = false;

            ncp_notacreditopresup ncp = null;
            //object[] notaCredito = null;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        ncp = this.guardarNC(context);
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
                if (this.FormEditStatus == INSERT)
                {
                    this.FilterEntity(CAMPO_NOTACREDITOID + " = " + ncp.ncp_notacreditoid.ToString(), null);
                    this.cargarDatos(this.dgvListadoABM.Rows[0]);
                    this.MostrarNotaCredito(new List<NotaCreditoPresupType>() { GenerarNotaCredito.CrearDataSet(this.DBContext, ncp) });
                }
                else if (this.FormEditStatus == EDIT)
                {
                    this.FilterEntity(this.WhereString, this.FilterParam);
                    this.cargarDatos(this.dgvListadoABM.Rows[this.LastDGVIndex]);
                    MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                this.FormEditStatus = BROWSE;
                
            }
        }

        #region Métodos de Edición de Datos
        private ncp_notacreditopresup guardarNC(BerkeDBEntities context = null)
        {
            ncp_notacreditopresup ncp = new ncp_notacreditopresup();

            #region EDIT
            if (this.FormEditStatus == EDIT)
            {
                int ncID = Convert.ToInt32(this.txtNCID.Text);

                ncp = context.ncp_notacreditopresup.First(a => a.ncp_notacreditoid == ncID);

                ncp.ncp_fecha = Convert.ToDateTime(this.txtFechaNC.Text);
                ncp.ncp_nrocomprobante = Convert.ToInt32(this.txtNCNro.Text);
                ncp.ncp_monto = Convert.ToDecimal(this.txtMonto.Text.Replace('.', ','));
                ncp.ncp_saldo = Convert.ToDecimal(this.txtMonto.Text.Replace('.', ','));
                ncp.ncp_monedaid = Convert.ToInt32(this.tSBMoneda.KeyMember);
                ncp.ncp_clienteid = Convert.ToInt32(this.tSBCliente.KeyMember);
                ncp.ncp_referenciacliente = this.txtNCReferencia.Text;
                ncp.ncp_cuerponota = this.txtNCCuerpo.Text;
                ncp.ncp_presupuestos = this.txtPresupAsoc.Text;
            }
            #endregion EDIT

            #region INSERT
            else if (this.FormEditStatus == INSERT)
            {
                

                #region Obtener número comprobante
                GetComprobanteNro_Result datosComprobante = context.GetComprobanteNro(TIPODOCUMENTO_NOTACREDITO, null, null, null).First();
                int nroComprobante = datosComprobante.ComprobanteNro + 1;
                int numeracionID = datosComprobante.NumeracionID;
                #endregion Obtener número comprobante

                ncp.ncp_fecha = Convert.ToDateTime(this.txtFechaNC.Text);
                ncp.ncp_nrocomprobante = nroComprobante;
                ncp.ncp_monto = Convert.ToDecimal(this.txtMonto.Text.Replace('.', ','));
                ncp.ncp_saldo = Convert.ToDecimal(this.txtMonto.Text.Replace('.', ','));
                ncp.ncp_monedaid = Convert.ToInt32(this.tSBMoneda.KeyMember);
                ncp.ncp_clienteid = Convert.ToInt32(this.tSBCliente.KeyMember);
                ncp.ncp_referenciacliente = this.txtNCReferencia.Text;
                ncp.ncp_cuerponota = this.txtNCCuerpo.Text;
                ncp.ncp_presupuestos = this.txtPresupAsoc.Text;

                context.cnd_controlnumdoc.First(a => a.cnd_controlnumdocid == numeracionID).cnd_ultnro = nroComprobante;
                context.ncp_notacreditopresup.Add(ncp);
            }
            #endregion INSERT

            return ncp;
        }
        #endregion Métodos de Edición de Datos
        
        #endregion CRUD


    }
}