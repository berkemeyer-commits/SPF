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
using SPF.UserControls.Base;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.ObjectModel;
using System.Data.Objects.SqlClient;

using SPF.Classes;
using Microsoft.Reporting.WebForms;

#endregion

namespace SPF.UserControls.UI
{
    public partial class ucCRUDMovimientoCuenta : ucBaseForm2015
    {
        #region Constantes
        private const string CAMPO_MOVIMIENTOID = "MovimientoID";
        private const string CAMPO_MOVIMIENTOESTADO = "Estado";
        private const string CAMPO_MOVIMIENTOESTADOTEXTO = "EstadoTexto";
        private const string CAMPO_MOVIMIENTOFECHA = "FechaMov";
        private const string CAMPO_CUENTAID = "CuentaID";
        private const string CAMPO_CUENTANRO = "CuentaNro";
        private const string CAMPO_CUENTADESCRIP = "CuentaDescrip";
        private const string CAMPO_BANCONOMBRE = "BancoNombre";
        private const string CAMPO_TIPOMOVIMIENTOID = "TipoMovimientoID";
        private const string CAMPO_TIPOMOVIMIENTODESCRIP = "TipoMovimientoDescrip";
        private const string CAMPO_TIPOMOVIMIENTO = "TipoMovimiento";
        private const string CAMPO_TIPOMOVIMIENTOTEXTO = "TipoMovimientoTexto";
        private const string CAMPO_MONTOMOVIMIENTO = "Monto";
        private const string CAMPO_OBSERVACION = "Observacion";
        private const string CAMPO_AUTORIZACIONVIG = "TieneAutorizacionVigente";
        private const string CAMPO_PAGOPROVEEDORID = "PagoProveedorID";
        private const string CAMPO_NROBOLETADEP = "NroBoletaDep";
        private const string CAMPO_FECHADEPOSITO = "FechaDeposito";
        private const string CAMPO_ANULADO = "Anulado";
        private const string CAMPO_ASOCIADOACOBRANZA = "AsociadoACobranza";
        private const string CAMPO_CERRADO = "Cerrado";
        private const string CAMPO_DOCUMENTONRO = "DocumentoNro";
        private const string HABER = "H";
        private const string DEBE = "D";
        private const string CREDITO = "Crédito";
        private const string DEBITO = "Débito";
        private const string ESTADO_ACTIVOVALOR = "Activo";
        private const string ESTADO_ANULADOVALOR = "Anulado";
        private const string ESTADO_ACTIVO = "A";
        private const string ESTADO_ANULADO = "N";
        
        private const int TIPODOCUMENTO_MOVIMIENTOCUENTA = 8;
        private const string FORMATO_DECIMAL_BROWSE = "{0:N2}";
        private const string FORMATO_DECIMAL_EDIT = "{0:0.00}";

        private const string CAMPO_COBROID = "CobroID";
        private const string CAMPO_COBROXMOVID = "CobroXMovimientoID";
        private const string CAMPO_FECHACOBRO = "FechaCobro";
        private const string CAMPO_MONTOCOBRO = "MontoCobro";
        private const string CAMPO_MONEDAID = "MonedaID";
        private const string CAMPO_MONEDAABREV = "MonedaAbrev";
        private const string CAMPO_MONEDADESCRIP = "MonedaDescrip";
        private const string CAMPO_CLIENTEID = "ClienteID";
        private const string CAMPO_CLIENTENOMBRE = "ClienteNombre";
        private const string CAMPO_TRAMITEID = "TramiteID";
        private const string CAMPO_TRAMITEDESCRIP = "TramiteDescrip";
        private const string CAMPO_RECIBONRO = "ReciboNro";
        private const string CAMPO_FECHARECIBO = "FechaRecibo";

        private const string CAMPO_MOVIMIENTOFK_TABLA = "cxm_movimientoid";
        private const string CAMPO_MOVIMIENTOPK_TABLA = "mc_movimientoid";
        #endregion Constantes

        #region Variables
        private frmPickBase fPickCuenta;
        private frmPickBase fPickTipoMovimiento;
        private FSeleccionarCobros fSeleccionarCobros;
        private BindingSource bS;
        private int UsuarioID = -1;
        private List<MovimientoCuentaListAll> lMovs;
        private List<SeleccionarCobrosType> cobrosElim;
        #endregion Variable

        #region Métodos de Inicio
        public ucCRUDMovimientoCuenta()
        {
            InitializeComponent();
        }

        public ucCRUDMovimientoCuenta(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();
            this.DBContext = dbContext;
            this.Titulo = Titulo;
            this.UsuarioID = Convert.ToInt32(VWGContext.Current.Session["UsuarioID"].ToString());
            this.cbAsociarCobranzas.Text = "Asociar a" + Environment.NewLine + "Cobranzas";
            this.cobrosElim = new List<SeleccionarCobrosType>();
            
            lMovs = new List<MovimientoCuentaListAll>();

            lMovs = (from mc in this.DBContext.mc_movimientoscuenta
                     join cb in this.DBContext.cb_cuentabanco
                      on mc.mc_cuentabancoid equals cb.cb_cuentabancoid
                     join ba in this.DBContext.ba_banco
                      on cb.cb_bancoid equals ba.ba_bancoid
                     join tm in this.DBContext.tm_tipomovimientocuenta
                      on mc.mc_tipomovimientoid equals tm.tm_tipomovimientoid
                     join cxm in this.DBContext.cxm_cobranzasxmov
                      on mc.mc_movimientoid equals cxm.cxm_movimientoid into cxm_mc
                     from cxm in cxm_mc.DefaultIfEmpty()
                     join pp in this.DBContext.pp_pagopresupuesto
                      on cxm.cxm_cobranzaid equals pp.pp_pagopresupuestoid into pp_cxm
                     from pp in pp_cxm.DefaultIfEmpty()
                     join pCab in this.DBContext.pc_presupuestocab
                      on pp.pp_presupuestocabid equals pCab.pc_presupuestocabid into pCab_pp
                     from pCab in pCab_pp.DefaultIfEmpty()
                     join cli in this.DBContext.Cliente
                      on pCab.pc_clienteid equals cli.ID into cli_pCab
                     from cli in cli_pCab.DefaultIfEmpty()
                     join mon in this.DBContext.Moneda
                        on pp.pp_monedaid equals mon.ID into mon_pp
                        from mon in mon_pp.DefaultIfEmpty()
                     join tra in this.DBContext.Tramite
                        on pCab.pc_tramiteid equals tra.ID into tra_pCab
                        from tra in tra_pCab.DefaultIfEmpty()
                     select new MovimientoCuentaListAll
                     {
                         MovimientoID = mc.mc_movimientoid,
                         Estado = mc.mc_estado,
                         FechaMov = mc.mc_fechamovimiento,
                         CuentaID = mc.mc_cuentabancoid,
                         CuentaNro = cb.cb_nrocuenta,
                         CuentaDescrip = cb.cb_descripcion,
                         BancoNombre = ba.ba_descripcion,
                         TipoMovimientoID = mc.mc_tipomovimientoid,
                         TipoMovimientoDescrip = tm.tm_tipomovimientodescrip,
                         TipoMovimiento = tm.tm_tipo,
                         Monto = mc.mc_montomovimiento,
                         Observacion = mc.mc_observacion,
                         PagoProveedorID = mc.mc_pagosolicitudid,
                         NroBoletaDep = mc.mc_nroboleta,
                         FechaDeposito = mc.mc_fechaboleta,
                         AsociadoACobranza = mc.mc_asociadocobranza,
                         TieneAutorizacionVigente = this.DBContext.GetAutorizacionPorDocumentoID(TIPODOCUMENTO_MOVIMIENTOCUENTA,
                                                                                                        mc.mc_movimientoid,
                                                                                                        this.UsuarioID)
                                                                                                        .FirstOrDefault().Value,
                         Cerrado = this.DBContext.CheckMesCerradoTable(mc.mc_fechamovimiento).FirstOrDefault().Value,
                         //Detalle
                         CobroID = cxm.cxm_cobranzaid,
                         CobroxMovimientoID = cxm.cxm_cobranzaxmovid,
                         FechaCobro = pp.pp_fechapago,
                         ClienteID = pCab.pc_clienteid,
                         ClienteNombre = cli.Nombre,
                         ReciboNro = pp.pp_nrorecibo,
                         FechaRecibo = pp.pp_fecharecibo,
                         TramiteID = pCab.pc_tramiteid,
                         TramiteDescrip = tra.EtiquetaEsp,
                         MonedaID = pp.pp_monedaid,
                         MonedaAbrev = mon.AbrevMoneda,
                         MonedaDescrip = mon.Descripcion,
                         MontoCobro = pp.pp_montopago,
                         DocumentoNro = this.DBContext.GetDocumentoNro(pCab.pc_presupuestocabid).FirstOrDefault()
                     })
                     .OrderByDescending(a => a.MovimientoID)
                     .Take(50).ToList();
            
            this.BindingSourceBase_ExportExcelGrid = lMovs;

            var query = (from item in lMovs
                         select new MovimientoCuentaListCab
                         {
                             //Cabecera
                             MovimientoID = item.MovimientoID,
                             Estado = item.Estado,
                             FechaMov = item.FechaMov,
                             CuentaID = item.CuentaID,
                             CuentaNro = item.CuentaNro,
                             CuentaDescrip = item.CuentaDescrip,
                             BancoNombre = item.BancoNombre,
                             TipoMovimientoID = item.TipoMovimientoID,
                             TipoMovimientoDescrip = item.TipoMovimientoDescrip,
                             TipoMovimiento = item.TipoMovimiento,
                             Monto = item.Monto,
                             Observacion = item.Observacion,
                             PagoProveedorID = item.PagoProveedorID,
                             NroBoletaDep = item.NroBoletaDep,
                             FechaDeposito = item.FechaDeposito,
                             AsociadoACobranza = item.AsociadoACobranza,
                             TieneAutorizacionVigente = item.TieneAutorizacionVigente,
                             Cerrado = item.Cerrado
                         })
                         .GroupBy(x => new { x.MovimientoID }).Select(g => g.First()).ToList();

            this.BindingSourceBase = query;

            #region Especificar campos para filtro
            this.SetFilter(CAMPO_MOVIMIENTOID, "Mov. ID", false);
            this.SetFilter(CAMPO_MOVIMIENTOESTADO, "Estado (A/N");
            this.SetFilter(CAMPO_MOVIMIENTOFECHA, "Fecha");
            this.SetFilter(CAMPO_CUENTAID, "Cuenta. ID", false);
            this.SetFilter(CAMPO_CUENTANRO, "N° Cuenta");
            this.SetFilter(CAMPO_CUENTADESCRIP, "Descrip. Cta.");
            this.SetFilter(CAMPO_BANCONOMBRE, "Nomb. Banco");
            this.SetFilter(CAMPO_NROBOLETADEP, "N° Boleta Dep.");
            this.SetFilter(CAMPO_FECHADEPOSITO, "Fecha Dep.");
            this.SetFilter(CAMPO_TIPOMOVIMIENTOID, "T. Mov. ID", false);
            this.SetFilter(CAMPO_TIPOMOVIMIENTODESCRIP, "Desc. T. Mov.");
            this.SetFilter(CAMPO_TIPOMOVIMIENTO, "Tipo (D=Debe; H=Haber");
            this.SetFilter(CAMPO_MONTOMOVIMIENTO, "Monto", false);
            this.SetFilter(CAMPO_PAGOPROVEEDORID, "Pago Prov. ID", false);
            this.SetFilter(CAMPO_OBSERVACION, "Observación");
            this.SetFilter(CAMPO_ASOCIADOACOBRANZA, "Asoc. a Cob. (S/N)", false);
            this.SetFilter(CAMPO_COBROID, "Cobro ID", false);
            this.SetFilter(CAMPO_FECHACOBRO, "Fecha Cobro");
            this.SetFilter(CAMPO_RECIBONRO, "N° Recibo");
            this.SetFilter(CAMPO_FECHARECIBO, "Fecha Recibo");
            this.SetFilter(CAMPO_CLIENTEID, "Cliente ID", false);
            this.SetFilter(CAMPO_CLIENTENOMBRE, "Cliente Nombre");
            this.SetFilter(CAMPO_TRAMITEID, "Trámite ID", false);
            this.SetFilter(CAMPO_TRAMITEDESCRIP, "Trám. Descrip");
            this.SetFilter(CAMPO_MONEDAID, "Moneda ID", false);
            this.SetFilter(CAMPO_MONEDAABREV, "Moneda Abrev.");
            this.SetFilter(CAMPO_MONEDADESCRIP, "Moneda Desc.");
            this.SetFilter(CAMPO_MONTOCOBRO, "Monto Cobro", false);
            this.TituloBuscador = "Buscar Movimientos";
            #endregion Especificar campos para filtro

            #region Inicializar TextSearchBoxes
            this.tSBCuenta.KeyMemberWidth = 70;
            this.tSBCuenta.ToolTip = "Elegir Cuenta de Depósito";
            this.tSBCuenta.AceptarClick += tSBCuenta_AceptarClick;

            this.tSBTipoMovimiento.KeyMemberWidth = 70;
            this.tSBTipoMovimiento.ToolTip = "Elegir Cuenta de Depósito";
            this.tSBTipoMovimiento.AceptarClick += tSBTipoMovimiento_AceptarClick;
            #endregion Inicializar TextSearchBoxes

            #region Ocultar botones
            this.tbbEditar.Visible = false;
            this.tbbEditar.Enabled = false;

            this.tbbBorrar.Visible = false;
            this.tbbBorrar.Enabled = false;
            #endregion Ocultar botones

            this.bS = new BindingSource();

            #region Asignación Eventos Deletados
            //Asignar Evento de Validación de carga de campos
            this.ValidarCamposEvent += ucCRUDMovimientoCuenta_ValidarCamposEvent;
            //Asignar Evento para Guardar Registro
            this.CRUDEvent += ucCRUDMovimientoCuenta_CRUDEvent;
            #endregion Asignación Eventos Deletados
        }
        #endregion Métodos de Inicio

        #region Picks

        #region Cuenta
        private void tSBCuenta_AceptarClick(object sender, EventArgs e)
        {
            if (fPickCuenta == null)
            {
                fPickCuenta = new frmPickBase();
                fPickCuenta.AceptarFiltrarClick += fPickCuenta_AceptarFiltrarClick;
                fPickCuenta.FiltrarClick += fPickCuenta_FiltrarClick;
                fPickCuenta.Titulo = "Elegir Cuenta ";
                fPickCuenta.CampoIDNombre = "cb_cuentabancoid";
                fPickCuenta.CampoDescripNombre = "cb_descripcion";
                fPickCuenta.LabelCampoID = "ID";
                fPickCuenta.LabelCampoDescrip = "Descripción";
                fPickCuenta.NombreCampo = "Cuenta";
                fPickCuenta.PermitirFiltroNulo = true;
            }
            fPickCuenta.MostrarFiltro();
            //this.fPickCuenta_FiltrarClick(sender, e);
        }

        private void fPickCuenta_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickCuenta != null)
            {
                fPickCuenta.LoadData<cb_cuentabanco>(this.DBContext.cb_cuentabanco, fPickCuenta.GetWhereString());
            }
        }

        private void fPickCuenta_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBCuenta.DisplayMember = fPickCuenta.ValorDescrip;
            this.tSBCuenta.KeyMember = fPickCuenta.ValorID;

            fPickCuenta.Close();
            fPickCuenta.Dispose();

            int cuentaID = Convert.ToInt32(this.tSBCuenta.KeyMember);

            var query = (from cb in this.DBContext.cb_cuentabanco
                         join ba in this.DBContext.ba_banco
                             on cb.cb_bancoid equals ba.ba_bancoid
                         join mon in this.DBContext.Moneda
                             on cb.cb_monedaid equals mon.ID
                         select new
                         {
                             CuentaID = cb.cb_cuentabancoid,
                             NroCuenta = cb.cb_nrocuenta,
                             BancoNombre = ba.ba_descripcion,
                             MonedaAbrev = mon.AbrevMoneda
                         })
                        .Where(a => a.CuentaID == cuentaID).ToList();

            this.txtMoneda.Text = query.First().MonedaAbrev;
            this.txtNroCuenta.Text = query.First().NroCuenta;
            this.txtBanco.Text = query.First().BancoNombre;
        }
        #endregion Cuenta

        #region Tipo Movimiento
        private void tSBTipoMovimiento_AceptarClick(object sender, EventArgs e)
        {
            if (fPickTipoMovimiento == null)
            {
                fPickTipoMovimiento = new frmPickBase();
                fPickTipoMovimiento.AceptarFiltrarClick += fPickTipoMovimiento_AceptarFiltrarClick;
                fPickTipoMovimiento.FiltrarClick += fPickTipoMovimiento_FiltrarClick;
                fPickTipoMovimiento.Titulo = "Elegir Tipo Movimiento";
                fPickTipoMovimiento.CampoIDNombre = "tm_tipomovimientoid";
                fPickTipoMovimiento.CampoDescripNombre = "tm_tipomovimientodescrip";
                fPickTipoMovimiento.LabelCampoID = "ID";
                fPickTipoMovimiento.LabelCampoDescrip = "Descripción";
                fPickTipoMovimiento.NombreCampo = "T. Mov.";
                fPickTipoMovimiento.PermitirFiltroNulo = true;
            }
            fPickTipoMovimiento.MostrarFiltro();
            this.fPickTipoMovimiento_FiltrarClick(sender, e);
        }

        private void fPickTipoMovimiento_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickTipoMovimiento != null)
            {
                fPickTipoMovimiento.LoadData<tm_tipomovimientocuenta>(this.DBContext.tm_tipomovimientocuenta, fPickTipoMovimiento.GetWhereString());
            }
        }

        private void fPickTipoMovimiento_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBTipoMovimiento.DisplayMember = fPickTipoMovimiento.ValorDescrip;
            this.tSBTipoMovimiento.KeyMember = fPickTipoMovimiento.ValorID;

            fPickTipoMovimiento.Close();
            fPickTipoMovimiento.Dispose();

            int tipoMovimientoID = Convert.ToInt32(this.tSBTipoMovimiento.KeyMember);
            string tipoMov = this.DBContext.tm_tipomovimientocuenta.First(a => a.tm_tipomovimientoid == tipoMovimientoID).tm_tipo;

            this.cbAsociarCobranzas.Checked = false;

            if (tipoMov == DEBE)
            {
                this.txtTipo.Text = DEBITO;
                this.cbAsociarCobranzas.Visible = false;
            }
            else if (tipoMov == HABER)
            {
                this.txtTipo.Text = CREDITO;
                this.cbAsociarCobranzas.Visible = true;
            }
        }
        
        #endregion Tipo Movimiento

        #endregion Picks

        #region Método Extendidos del ParentControl
        protected override void FilterEntity(string where = "", object[] filterParams = null)
        {
            try
            {
                this.limpiarDatos();

                var query = (from mc in this.DBContext.mc_movimientoscuenta
                             join cb in this.DBContext.cb_cuentabanco
                              on mc.mc_cuentabancoid equals cb.cb_cuentabancoid
                             join ba in this.DBContext.ba_banco
                              on cb.cb_bancoid equals ba.ba_bancoid
                             join tm in this.DBContext.tm_tipomovimientocuenta
                              on mc.mc_tipomovimientoid equals tm.tm_tipomovimientoid
                             join cxm in this.DBContext.cxm_cobranzasxmov
                              on mc.mc_movimientoid equals cxm.cxm_movimientoid into cxm_mc
                             from cxm in cxm_mc.DefaultIfEmpty()
                             join pp in this.DBContext.pp_pagopresupuesto
                              on cxm.cxm_cobranzaid equals pp.pp_pagopresupuestoid into pp_cxm
                             from pp in pp_cxm.DefaultIfEmpty()
                             join pCab in this.DBContext.pc_presupuestocab
                              on pp.pp_presupuestocabid equals pCab.pc_presupuestocabid into pCab_pp
                             from pCab in pCab_pp.DefaultIfEmpty()
                             join cli in this.DBContext.Cliente
                              on pCab.pc_clienteid equals cli.ID into cli_pCab
                             from cli in cli_pCab.DefaultIfEmpty()
                             join mon in this.DBContext.Moneda
                                on pp.pp_monedaid equals mon.ID into mon_pp
                             from mon in mon_pp.DefaultIfEmpty()
                             join tra in this.DBContext.Tramite
                                on pCab.pc_tramiteid equals tra.ID into tra_pCab
                             from tra in tra_pCab.DefaultIfEmpty()
                             select new MovimientoCuentaListAll
                             {
                                 MovimientoID = mc.mc_movimientoid,
                                 Estado = mc.mc_estado,
                                 FechaMov = mc.mc_fechamovimiento,
                                 CuentaID = mc.mc_cuentabancoid,
                                 CuentaNro = cb.cb_nrocuenta,
                                 CuentaDescrip = cb.cb_descripcion,
                                 BancoNombre = ba.ba_descripcion,
                                 TipoMovimientoID = mc.mc_tipomovimientoid,
                                 TipoMovimientoDescrip = tm.tm_tipomovimientodescrip,
                                 TipoMovimiento = tm.tm_tipo,
                                 Monto = mc.mc_montomovimiento,
                                 Observacion = mc.mc_observacion,
                                 PagoProveedorID = mc.mc_pagosolicitudid,
                                 NroBoletaDep = mc.mc_nroboleta,
                                 FechaDeposito = mc.mc_fechaboleta,
                                 AsociadoACobranza = mc.mc_asociadocobranza,
                                 TieneAutorizacionVigente = this.DBContext.GetAutorizacionPorDocumentoID(TIPODOCUMENTO_MOVIMIENTOCUENTA,
                                                                                                                mc.mc_movimientoid,
                                                                                                                this.UsuarioID)
                                                                                                                .FirstOrDefault().Value,
                                 Cerrado = this.DBContext.CheckMesCerradoTable(mc.mc_fechamovimiento).FirstOrDefault().Value,
                                 //Detalle
                                 CobroID = cxm.cxm_cobranzaid,
                                 CobroxMovimientoID = cxm.cxm_cobranzaxmovid,
                                 FechaCobro = pp.pp_fechapago,
                                 ClienteID = pCab.pc_clienteid,
                                 ClienteNombre = cli.Nombre,
                                 ReciboNro = pp.pp_nrorecibo,
                                 FechaRecibo = pp.pp_fecharecibo,
                                 TramiteID = pCab.pc_tramiteid,
                                 TramiteDescrip = tra.EtiquetaEsp,
                                 MonedaID = pp.pp_monedaid,
                                 MonedaAbrev = mon.AbrevMoneda,
                                 MonedaDescrip = mon.Descripcion,
                                 MontoCobro = pp.pp_montopago,
                                 DocumentoNro = this.DBContext.GetDocumentoNro(pCab.pc_presupuestocabid).FirstOrDefault()
                             });

                lMovs.Clear();
                if (where != "")
                {
                    //this.BindingSourceBase = query.Where(where, filterParams).OrderByDescending(a => a.NotaCreditoID).ToList();
                    lMovs = query.Where(where, filterParams).OrderByDescending(a => a.MovimientoID).ToList();
                    
                }
                else
                {
                    //this.BindingSourceBase = query.OrderByDescending(a => a.NotaCreditoID).Take(50).ToList();
                    lMovs = query.OrderByDescending(a => a.MovimientoID).Take(50).ToList();
                }

                this.BindingSourceBase_ExportExcelGrid = lMovs;

                var query1 = (from item in lMovs
                             select new MovimientoCuentaListCab
                             {
                                 //Cabecera
                                 MovimientoID = item.MovimientoID,
                                 Estado = item.Estado,
                                 FechaMov = item.FechaMov,
                                 CuentaID = item.CuentaID,
                                 CuentaNro = item.CuentaNro,
                                 CuentaDescrip = item.CuentaDescrip,
                                 BancoNombre = item.BancoNombre,
                                 TipoMovimientoID = item.TipoMovimientoID,
                                 TipoMovimientoDescrip = item.TipoMovimientoDescrip,
                                 TipoMovimiento = item.TipoMovimiento,
                                 Monto = item.Monto,
                                 Observacion = item.Observacion,
                                 PagoProveedorID = item.PagoProveedorID,
                                 NroBoletaDep = item.NroBoletaDep,
                                 FechaDeposito = item.FechaDeposito,
                                 AsociadoACobranza = item.AsociadoACobranza,
                                 TieneAutorizacionVigente = item.TieneAutorizacionVigente,
                                 Cerrado = item.Cerrado
                             })
                         .GroupBy(x => new { x.MovimientoID }).Select(g => g.First()).ToList();

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

            this.dgvListadoABM.Columns[CAMPO_MOVIMIENTOID].HeaderText = "Mov. ID";
            this.dgvListadoABM.Columns[CAMPO_MOVIMIENTOID].Width = 70;
            this.dgvListadoABM.Columns[CAMPO_MOVIMIENTOID].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_MOVIMIENTOID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_MOVIMIENTOID].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_MOVIMIENTOFECHA].HeaderText = "Fec. Mov.";
            this.dgvListadoABM.Columns[CAMPO_MOVIMIENTOFECHA].Width = 70;
            this.dgvListadoABM.Columns[CAMPO_MOVIMIENTOFECHA].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_MOVIMIENTOFECHA].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_MOVIMIENTOFECHA].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_CUENTADESCRIP].HeaderText = "Descrip. Cuenta";
            this.dgvListadoABM.Columns[CAMPO_CUENTADESCRIP].Width = 150;
            this.dgvListadoABM.Columns[CAMPO_CUENTADESCRIP].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_CUENTADESCRIP].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_TIPOMOVIMIENTODESCRIP].HeaderText = "Descrip. Tipo Mov.";
            this.dgvListadoABM.Columns[CAMPO_TIPOMOVIMIENTODESCRIP].Width = 150;
            this.dgvListadoABM.Columns[CAMPO_TIPOMOVIMIENTODESCRIP].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_TIPOMOVIMIENTODESCRIP].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_TIPOMOVIMIENTOTEXTO].HeaderText = "Tipo";
            this.dgvListadoABM.Columns[CAMPO_TIPOMOVIMIENTOTEXTO].Width = 150;
            this.dgvListadoABM.Columns[CAMPO_TIPOMOVIMIENTOTEXTO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_TIPOMOVIMIENTOTEXTO].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_MONTOMOVIMIENTO].HeaderText = "Monto";
            this.dgvListadoABM.Columns[CAMPO_MONTOMOVIMIENTO].Width = 70;
            this.dgvListadoABM.Columns[CAMPO_MONTOMOVIMIENTO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_MONTOMOVIMIENTO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_MONTOMOVIMIENTO].DefaultCellStyle.Format = "N2";
            this.dgvListadoABM.Columns[CAMPO_MONTOMOVIMIENTO].Visible = true;
            displayIndex++;

            //this.dgvListadoABM.Columns[CAMPO_MOVIMIENTOESTADOTEXTO].HeaderText = "Estado";
            //this.dgvListadoABM.Columns[CAMPO_MOVIMIENTOESTADOTEXTO].Width = 50;
            //this.dgvListadoABM.Columns[CAMPO_MOVIMIENTOESTADOTEXTO].DisplayIndex = displayIndex;
            //this.dgvListadoABM.Columns[CAMPO_MOVIMIENTOESTADOTEXTO].Visible = true;
            //displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_PAGOPROVEEDORID].HeaderText = "Prov. Pago ID";
            this.dgvListadoABM.Columns[CAMPO_PAGOPROVEEDORID].Width = 70;
            this.dgvListadoABM.Columns[CAMPO_PAGOPROVEEDORID].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_PAGOPROVEEDORID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_PAGOPROVEEDORID].Visible = true;
            displayIndex++;

            DataGridViewCheckBoxColumn colAnulado = new DataGridViewCheckBoxColumn();
            colAnulado.DataPropertyName = CAMPO_ANULADO;
            colAnulado.Name = CAMPO_ANULADO;
            colAnulado.HeaderText = "Anulado";
            colAnulado.FalseValue = false;
            colAnulado.TrueValue = true;
            colAnulado.ReadOnly = true;
            this.dgvListadoABM.Columns.Insert(displayIndex, colAnulado);
            displayIndex++;
        }

        protected override void tbbNuevo_Click(object sender, EventArgs e)
        {
            base.tbbNuevo_Click(sender, e);
            this.limpiarDatos();
            this.txtFechaMov.Text = System.DateTime.Now.ToShortDateString();
            this.dtpFechaMov.Value = System.DateTime.Now;
            this.txtFechaMov.Focus();
        }

        protected override void tbbEditar_Click(object sender, EventArgs e)
        {
            base.tbbEditar_Click(sender, e);
            //this.txtFechaMov.Focus();
            
        }

        protected override void tbbCancelar_Click(object sender, EventArgs e)
        {
            base.tbbCancelar_Click(sender, e);

            if (this.LastDGVIndex > -1)
            {
                this.CargarMovimiento(this.dgvListadoABM.Rows[this.LastDGVIndex]);
            }
            else
            {
                this.limpiarDatos();
            }

            if (this.tabListaABM.SelectedTab == tpCobAsoc)
                this.tabListaABM.SelectedIndex = 1; //TabDetalle
        }

        #endregion Método Extendidos del ParentControl

        #region Limpiar Datos
        private void limpiarDatos()
        {
            this.txtMovimientoID.Text = "";
            this.txtEstado.Text = "";
            this.txtFechaMov.Text = "";
            this.tSBCuenta.Clear();
            this.txtNroCuenta.Text = "";
            this.txtBanco.Text = "";
            this.txtMoneda.Text = "";
            this.tSBTipoMovimiento.Clear();
            this.txtMonto.Text = "";
            this.txtTipo.Text = "";
            this.txtObservacion.Text = "";
            this.txtObservacion.Text = "";
            this.lblAutorizacionVigente.Visible = false;
            this.txtPagoProveedorID.Text = "";
            this.txtNroBolDep.Text = "";
            this.txtFecBolDep.Text = "";
            this.cbAsociarCobranzas.Checked = false;
            this.dgvDetCobranzas.DataSource = null;
            this.cobrosElim.Clear();
        }
        #endregion Limpiar Datos

        #region ReadOnly condicional
        protected override void Editable(bool editar)
        {
            if ((this.FormEditStatus == INSERT) || (this.FormEditStatus == BROWSE))
            {
                this.txtMovimientoID.ReadOnly = editar;
                this.txtEstado.ReadOnly = editar;
                this.txtFechaMov.ReadOnly = editar;
                this.dtpFechaMov.Enabled = !editar;
                this.tSBCuenta.Editable = !editar;
                this.txtNroCuenta.ReadOnly = editar;
                this.txtBanco.ReadOnly = editar;
                //this.grpDatosCuenta.Enabled = !editar;
                this.tSBTipoMovimiento.Editable = !editar;
                this.txtMonto.ReadOnly = editar;
                this.txtTipo.ReadOnly = editar;
                this.txtObservacion.ReadOnly = editar;
                this.txtNroBolDep.ReadOnly = editar;
                this.txtFecBolDep.ReadOnly = editar;
                this.dtpFecBolDep.Enabled = !editar;
                this.cbAsociarCobranzas.Enabled = !editar;
                this.btnAgregarCobro.Enabled = !editar;
                this.btnEliminarCobro.Enabled = !editar;
            }
            else if (this.FormEditStatus == EDIT)
            {
                //Solo se puede editar lo referente a Cobros Asociados
                MessageBox.Show("Sólo puede editar la asociación a Cobros.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cbAsociarCobranzas.Enabled = true;
            }
        }
        #endregion ReadOnly condicional

        #region Métodos de Apoyo
        private void CargarMovimiento(DataGridViewRow row)
        {
            this.limpiarDatos();

            this.txtMovimientoID.Text = row.Cells[CAMPO_MOVIMIENTOID].Value.ToString();
            this.txtEstado.Text = row.Cells[CAMPO_MOVIMIENTOESTADOTEXTO].Value.ToString();
            this.txtFechaMov.Text = ((DateTime)row.Cells[CAMPO_MOVIMIENTOFECHA].Value).ToShortDateString();
            this.dtpFechaMov.Value = (DateTime)row.Cells[CAMPO_MOVIMIENTOFECHA].Value;
            this.tSBCuenta.KeyMember = row.Cells[CAMPO_CUENTAID].Value.ToString();
            this.tSBCuenta.DisplayMember = row.Cells[CAMPO_CUENTADESCRIP].Value.ToString();
            this.tSBTipoMovimiento.KeyMember = row.Cells[CAMPO_TIPOMOVIMIENTOID].Value.ToString();
            this.tSBTipoMovimiento.DisplayMember = row.Cells[CAMPO_TIPOMOVIMIENTODESCRIP].Value.ToString();
            this.txtNroCuenta.Text = row.Cells[CAMPO_CUENTANRO].Value.ToString();
            this.txtBanco.Text = row.Cells[CAMPO_BANCONOMBRE].Value.ToString();
            this.txtTipo.Text = row.Cells[CAMPO_TIPOMOVIMIENTOTEXTO].Value.ToString();
            this.txtMonto.Text = String.Format("{0:N2}", (decimal)row.Cells[CAMPO_MONTOMOVIMIENTO].Value);
            this.txtObservacion.Text = row.Cells[CAMPO_OBSERVACION].Value != null ? row.Cells[CAMPO_OBSERVACION].Value.ToString() : String.Empty;
            this.txtEstado.Text = row.Cells[CAMPO_MOVIMIENTOESTADOTEXTO].Value.ToString();
            this.lblAutorizacionVigente.Visible = (bool)row.Cells[CAMPO_AUTORIZACIONVIG].Value;
            this.txtPagoProveedorID.Text = row.Cells[CAMPO_PAGOPROVEEDORID].Value != null ? row.Cells[CAMPO_PAGOPROVEEDORID].Value.ToString() : String.Empty;

            if (row.Cells[CAMPO_FECHADEPOSITO].Value != null)
            {
                this.txtFecBolDep.Text = ((DateTime)row.Cells[CAMPO_FECHADEPOSITO].Value).ToShortDateString();
                this.dtpFecBolDep.Value = (DateTime)row.Cells[CAMPO_FECHADEPOSITO].Value;
            }
            this.txtNroBolDep.Text = row.Cells[CAMPO_NROBOLETADEP].Value != null ? row.Cells[CAMPO_NROBOLETADEP].Value.ToString() : String.Empty;

            if (row.Cells[CAMPO_ASOCIADOACOBRANZA].Value != null)
            {
                this.cbAsociarCobranzas.Checked = (bool)row.Cells[CAMPO_ASOCIADOACOBRANZA].Value;
                if (!(bool)row.Cells[CAMPO_ASOCIADOACOBRANZA].Value)
                {
                    this.tpCobAsoc.Hide();
                    //this.cbAsociarCobranzas.Visible = false;
                    this.cbAsociarCobranzas.Checked = false;
                }
                else
                {
                    this.tpCobAsoc.Show();
                    //this.cbAsociarCobranzas.Visible = true;
                    this.cbAsociarCobranzas.Checked = true;
                    this.CargarGrillaCobrosAsociados((int)row.Cells[CAMPO_MOVIMIENTOID].Value);
                }
            }
            else
            {
                this.cbAsociarCobranzas.Checked = false;
                this.tpCobAsoc.Hide();
                this.cbAsociarCobranzas.Visible = false;
            }

            if ((!(bool)row.Cells[CAMPO_CERRADO].Value) && (row.Cells[CAMPO_TIPOMOVIMIENTOTEXTO].Value.ToString() == CREDITO))
            {
                this.tbbEditar.Visible = true;
            }
            else
            {
                this.tbbEditar.Visible = false;
            }

            this.cbAsociarCobranzas.Visible = row.Cells[CAMPO_TIPOMOVIMIENTOTEXTO].Value.ToString() == CREDITO;
            
        }

        private void CargarGrillaCobrosAsociados(int MovimientoID)
        {
            var query = (from item in lMovs
                         select new SeleccionarCobrosType
                         {
                             CobroID = item.CobroID,
                             MovimientoID = item.MovimientoID,
                             CobroXMovimientoID = item.CobroxMovimientoID,
                             FechaCobro = item.FechaCobro,
                             MonedaID = item.MonedaID,
                             MonedaAbrev = item.MonedaAbrev,
                             MonedaDescrip = item.MonedaDescrip,
                             MontoCobro = item.MontoCobro,
                             ClienteID = item.ClienteID,
                             ClienteNombre = item.ClienteNombre,
                             TramiteID = item.TramiteID,
                             TramiteDescrip = item.TramiteDescrip,
                             ReciboNro = item.ReciboNro,
                             FechaRecibo = item.FechaRecibo,
                             DocumentoNro = item.DocumentoNro
                         }
                        )
                        .Where(a => a.MovimientoID == MovimientoID).ToList();
            if ((query.Count > 0) && (query.First().CobroXMovimientoID != null))
            {
                this.bS.DataSource = query;
                this.dgvDetCobranzas.DataSource = this.bS;
                this.FormatearGrillaDetCobAsoc();
            }
            else
                this.dgvDetCobranzas.DataSource = null;


        }

        private void AnularDialogHandler(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    this.AnularMov(Convert.ToInt32(this.txtMovimientoID.Text));
                }
            }
        }

        private void AnularMov(int MovimientoID)
        {
            bool success = false;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        mc_movimientoscuenta mc = context.mc_movimientoscuenta.First(a => a.mc_movimientoid == MovimientoID);
                        mc.mc_estado = ESTADO_ANULADO;
                        mc.mc_fechaanulacion = System.DateTime.Now;
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        success = true;
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
                //this.txtEstado.Text = "Anulado";
                this.FilterEntity(this.WhereString, this.FilterParam);
                this.CargarMovimiento(this.dgvListadoABM.Rows[this.LastDGVIndex]);
                MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ValidarMontos()
        {
            decimal total = Convert.ToDecimal(this.txtMonto.Text);
            decimal sumCobros = 0;
            foreach (DataGridViewRow row in this.dgvDetCobranzas.Rows)
            {
                sumCobros += (decimal)row.Cells[CAMPO_MONTOCOBRO].Value;
            }

            return total == sumCobros;
        }

        #endregion Métodos de Apoyo

        #region Métodos locales sobre controles
        private void tbbAnular_Click(object sender, EventArgs e)
        {
            if (!this.lblAutorizacionVigente.Visible)
            {
                MessageBox.Show("No se puede anular el movimiento debido a que no posee autorización vigente.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;

            }

            if (this.txtEstado.Text == ESTADO_ANULADOVALOR)
            {
                MessageBox.Show("No se puede anular el movimiento debido a que ya se encuentra en ese estado.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            if (this.txtPagoProveedorID.Text != String.Empty)
            {
                MessageBox.Show("No se puede anular el movimiento debido a que se encuentra asociado a un pago." + Environment.NewLine +
                                "Debe anular el pago para que el movimiento sea anulado.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            string message = "";
            string caption = "";
            caption = "Anulación de Movimientos en Cuenta";
            message = "Se anulará el movimiento ¿Desea continuar?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(AnularDialogHandler));
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

        private void txtEstado_TextChanged(object sender, EventArgs e)
        {
            if (this.txtEstado.Text == ESTADO_ANULADOVALOR)
                this.txtEstado.ForeColor = Color.Red;
            else
                this.txtEstado.ForeColor = Color.Black;
        }

        private void dtpFechaMov_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaMov.Text = this.dtpFechaMov.Value.ToShortDateString();
        }

        private void dtpFecBolDep_ValueChanged(object sender, EventArgs e)
        {
            this.txtFecBolDep.Text = this.dtpFecBolDep.Value.ToShortDateString();
        }

        private void ucCRUDMovimientoCuenta_VisibleChanged(object sender, EventArgs e)
        {
            if (this.tabListaABM.SelectedIndex == 0)
                this.FormatearGrilla();
        }

        protected override void tabListaABM_SelectedIndexChanging(object sender, TabControlCancelEventArgs e)
        {
            if (this.FormEditStatus != BROWSE)
            {
                if ((!((this.cbAsociarCobranzas.Visible) && (this.cbAsociarCobranzas.Checked) && ((e.TabPage != tabListaABM.TabPages[0])))))
                    e.Cancel = true;
            }
        }

        private void dgvListadoABM_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((this.LastDGVIndex > -1) && (!this.IsClosing))
                this.CargarMovimiento(this.dgvListadoABM.Rows[this.LastDGVIndex]);
        }

        private void btnEliminarDetalle_Click(object sender, EventArgs e)
        {
            if (this.dgvDetCobranzas.CurrentRow.Cells[CAMPO_COBROXMOVID].Value != null)
                this.cobrosElim.Add((SeleccionarCobrosType)this.dgvDetCobranzas.CurrentRow.DataBoundItem);

            this.dgvDetCobranzas.Rows.Remove(this.dgvDetCobranzas.CurrentRow);

            if (this.dgvDetCobranzas.RowCount > 0)
            {
                this.dgvDetCobranzas.CurrentCell = this.dgvDetCobranzas.Rows[0].Cells[0];
                this.dgvDetCobranzas.CurrentCell.Selected = true;
                this.dgvDetCobranzas.Focus();
            }
            else
            {
                this.btnEliminarCobro.Enabled = false;
                this.btnAgregarCobro.Focus();
            }
        }

        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            if (fSeleccionarCobros == null)
            {
                fSeleccionarCobros = new FSeleccionarCobros(this.DBContext, "Selección de Cobros");
                fSeleccionarCobros.FormClosed += delegate { fSeleccionarCobros = null; };
                fSeleccionarCobros.AceptarClick += fSeleccionarCobros_AceptarClick;
                fSeleccionarCobros.CloseClick += fSeleccionarCobros_CloseClick;
            }

            fSeleccionarCobros.ShowDialog();
        }

        private void fSeleccionarCobros_CloseClick(object sender, EventArgs e)
        {
            fSeleccionarCobros.Close();
            if (this.dgvDetCobranzas.RowCount > 0)
            {
                this.dgvDetCobranzas.CurrentCell = this.dgvDetCobranzas.Rows[0].Cells[0];
                this.dgvDetCobranzas.CurrentCell.Selected = true;
                this.dgvDetCobranzas.Focus();
            }
            else
            {
                this.btnEliminarCobro.Enabled = false;
                this.btnAgregarCobro.Focus();
            }
        }

        private void fSeleccionarCobros_AceptarClick(object sender, EventArgs e)
        {
            int cantidadFilas = this.dgvDetCobranzas.RowCount;
            List<SeleccionarCobrosType> listaCobrosAsoc = cantidadFilas > 0 ?
                                                            (List<SeleccionarCobrosType>)this.bS.DataSource :
                                                            new List<SeleccionarCobrosType>();

            listaCobrosAsoc.AddRange(fSeleccionarCobros.ListaCobrosAsoc);

            this.bS.DataSource = listaCobrosAsoc.GroupBy(x => x.CobroID).Select(y => y.First()).ToList();
            this.dgvDetCobranzas.DataSource = this.bS;
            fSeleccionarCobros.SetEtiqueta(this.dgvDetCobranzas.RowCount - cantidadFilas);
            this.FormatearGrillaDetCobAsoc();
        }

        private void FormatearGrillaDetCobAsoc()
        {
            foreach (DataGridViewColumn col in this.dgvDetCobranzas.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            this.dgvDetCobranzas.ReadOnly = true;
            this.dgvDetCobranzas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetCobranzas.ItemsPerPage = 10;
            this.dgvDetCobranzas.ShowCellToolTips = true;
            this.dgvDetCobranzas.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvDetCobranzas.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvDetCobranzas.DefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvDetCobranzas.DefaultCellStyle.BackColor = Color.Transparent;
            this.dgvDetCobranzas.MultiSelect = false;

            this.dgvDetCobranzas.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;

            int displayIndex = 0;

            this.dgvDetCobranzas.Columns[CAMPO_COBROID].HeaderText = "Cobro ID";
            this.dgvDetCobranzas.Columns[CAMPO_COBROID].Width = 80;
            this.dgvDetCobranzas.Columns[CAMPO_COBROID].DisplayIndex = displayIndex;
            this.dgvDetCobranzas.Columns[CAMPO_COBROID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvDetCobranzas.Columns[CAMPO_COBROID].Visible = true;
            displayIndex++;

            this.dgvDetCobranzas.Columns[CAMPO_FECHACOBRO].HeaderText = "Fec. Cobro";
            this.dgvDetCobranzas.Columns[CAMPO_FECHACOBRO].Width = 80;
            this.dgvDetCobranzas.Columns[CAMPO_FECHACOBRO].DisplayIndex = displayIndex;
            this.dgvDetCobranzas.Columns[CAMPO_FECHACOBRO].Visible = true;
            displayIndex++;

            this.dgvDetCobranzas.Columns[CAMPO_DOCUMENTONRO].HeaderText = "N° Documento";
            this.dgvDetCobranzas.Columns[CAMPO_DOCUMENTONRO].Width = 100;
            this.dgvDetCobranzas.Columns[CAMPO_DOCUMENTONRO].DisplayIndex = displayIndex;
            this.dgvDetCobranzas.Columns[CAMPO_DOCUMENTONRO].Visible = true;
            displayIndex++;

            this.dgvDetCobranzas.Columns[CAMPO_CLIENTENOMBRE].HeaderText = "Cliente";
            this.dgvDetCobranzas.Columns[CAMPO_CLIENTENOMBRE].Width = 200;
            this.dgvDetCobranzas.Columns[CAMPO_CLIENTENOMBRE].DisplayIndex = displayIndex;
            this.dgvDetCobranzas.Columns[CAMPO_CLIENTENOMBRE].Visible = true;
            displayIndex++;

            this.dgvDetCobranzas.Columns[CAMPO_TRAMITEDESCRIP].HeaderText = "Trámite";
            this.dgvDetCobranzas.Columns[CAMPO_TRAMITEDESCRIP].Width = 80;
            this.dgvDetCobranzas.Columns[CAMPO_TRAMITEDESCRIP].DisplayIndex = displayIndex;
            this.dgvDetCobranzas.Columns[CAMPO_TRAMITEDESCRIP].Visible = true;
            displayIndex++;

            this.dgvDetCobranzas.Columns[CAMPO_MONEDAABREV].HeaderText = "Moneda";
            this.dgvDetCobranzas.Columns[CAMPO_MONEDAABREV].Width = 80;
            this.dgvDetCobranzas.Columns[CAMPO_MONEDAABREV].DisplayIndex = displayIndex;
            this.dgvDetCobranzas.Columns[CAMPO_MONEDAABREV].Visible = true;
            displayIndex++;

            this.dgvDetCobranzas.Columns[CAMPO_MONTOCOBRO].HeaderText = "Monto";
            this.dgvDetCobranzas.Columns[CAMPO_MONTOCOBRO].Width = 80;
            this.dgvDetCobranzas.Columns[CAMPO_MONTOCOBRO].DisplayIndex = displayIndex;
            this.dgvDetCobranzas.Columns[CAMPO_MONTOCOBRO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvDetCobranzas.Columns[CAMPO_MONTOCOBRO].DefaultCellStyle.Format = "N2";
            this.dgvDetCobranzas.Columns[CAMPO_MONTOCOBRO].Visible = true;
            displayIndex++;

            this.dgvDetCobranzas.Columns[CAMPO_RECIBONRO].HeaderText = "N° Recibo";
            this.dgvDetCobranzas.Columns[CAMPO_RECIBONRO].Width = 100;
            this.dgvDetCobranzas.Columns[CAMPO_RECIBONRO].DisplayIndex = displayIndex;
            this.dgvDetCobranzas.Columns[CAMPO_RECIBONRO].Visible = true;
            displayIndex++;

            this.dgvDetCobranzas.Columns[CAMPO_FECHARECIBO].HeaderText = "Fec. Recibo";
            this.dgvDetCobranzas.Columns[CAMPO_FECHARECIBO].Width = 80;
            this.dgvDetCobranzas.Columns[CAMPO_FECHARECIBO].DisplayIndex = displayIndex;
            this.dgvDetCobranzas.Columns[CAMPO_FECHARECIBO].Visible = true;
            displayIndex++;

        }

        private void dgvDetCobranzas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.btnEliminarCobro.Enabled = this.dgvDetCobranzas.CurrentRow != null;
        }

        private void tabListaABM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabListaABM.SelectedIndex == 2)
            {
                if (this.dgvDetCobranzas.RowCount > 0)
                {
                    this.dgvDetCobranzas.CurrentCell = this.dgvDetCobranzas.Rows[0].Cells[0];
                    this.dgvDetCobranzas.CurrentCell.Selected = true;
                    this.dgvDetCobranzas.Focus();

                    if (this.FormEditStatus != BROWSE)
                    {
                        this.btnEliminarCobro.Enabled = true;
                        this.btnAgregarCobro.Enabled = true;
                    }
                    else
                    {
                        this.btnEliminarCobro.Enabled = false;
                        this.btnAgregarCobro.Enabled = false;
                    }
                }
                else
                {
                    if (this.FormEditStatus != BROWSE)
                    {
                        this.btnEliminarCobro.Enabled = false;
                        this.btnAgregarCobro.Enabled = true;
                        this.btnAgregarCobro.Focus();
                    }
                    else
                    {
                        this.btnAgregarCobro.Enabled = false;
                        this.btnEliminarCobro.Enabled = false;
                    }
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
                    else
                        this.EliminarRegistro();
                }
            }
        }

        private void tbbBorrar_Click_1(object sender, EventArgs e)
        {
            string caption = "Eliminación de registro";
            string message = "Se eliminará el presente registro ¿Desea continuar?";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(DialogHandler));
        }

        private void txtMonto_Enter(object sender, EventArgs e)
        {
            if (this.FormEditStatus != BROWSE)
            {
                decimal valor;
                if (decimal.TryParse(this.txtMonto.Text, out valor))
                    this.txtMonto.Text = String.Format(FORMATO_DECIMAL_EDIT, valor);
                else this.txtMonto.Text = "0,00";
                this.txtMonto.Focus();
            }
        }

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            if (this.FormEditStatus != BROWSE)
            {
                decimal valor;
                if (decimal.TryParse(this.txtMonto.Text, out valor))
                    this.txtMonto.Text = String.Format(FORMATO_DECIMAL_BROWSE, valor);
                else this.txtMonto.Text = "0,00";
                //this.txtMontoPago.Focus();
            }

            //if (this.txtMonto.Text != "")
            //    this.txtMonto.Text = String.Format("{0:0.00}", Convert.ToDecimal(this.txtMonto.Text));
        }

        #endregion Métodos locales sobre controles

        #region CRUD
        private void ucCRUDMovimientoCuenta_CRUDEvent(object sender, EventArgs e)
        {
            mc_movimientoscuenta mc = new mc_movimientoscuenta();

            mc.mc_movimientoid = this.FormEditStatus != INSERT ? Convert.ToInt32(this.txtMovimientoID.Text) : 0;
            mc.mc_estado = ESTADO_ACTIVO;
            mc.mc_fechamovimiento = Convert.ToDateTime(this.txtFechaMov.Text);
            mc.mc_cuentabancoid = Convert.ToInt32(this.tSBCuenta.KeyMember);
            mc.mc_tipomovimientoid = Convert.ToInt32(this.tSBTipoMovimiento.KeyMember);
            //mc.mc_montomovimiento = Convert.ToDecimal(this.txtMonto.Text.Replace('.', ','));
            mc.mc_montomovimiento = Convert.ToDecimal(this.txtMonto.Text);
            mc.mc_observacion = this.txtObservacion.Text != String.Empty ? this.txtObservacion.Text : null;
            mc.mc_nroboleta = this.txtNroBolDep.Text != String.Empty ? this.txtNroBolDep.Text : null;
            mc.mc_asociadocobranza = this.cbAsociarCobranzas.Checked;

            if (this.txtFecBolDep.Text != "")
            {
                mc.mc_fechaboleta = Convert.ToDateTime(this.txtFecBolDep.Text);
                mc.mc_fechamovimiento = mc.mc_fechaboleta.Value;
            }
            bool exito = false;

            if (this.FormEditStatus != BROWSE)
            {
                List<cxm_cobranzasxmov> detalles = this.GetListaCobranzasAsoc(mc.mc_movimientoid);
                mc = this.GuardarRegistro<mc_movimientoscuenta, cxm_cobranzasxmov>(mc,
                                                                                  detalles,
                                                                                  CAMPO_MOVIMIENTOPK_TABLA,
                                                                                  CAMPO_MOVIMIENTOFK_TABLA);
            }
            else
                exito = this.EliminarRegistro<mc_movimientoscuenta>(mc);

            if ((mc != null) || (exito))
            {
                int index = 0;
                if (this.FormEditStatus == INSERT)
                {
                    this.FilterEntity("", null);
                    this.CargarMovimiento(this.dgvListadoABM.Rows[0]);
                }
                else if ((this.FormEditStatus == EDIT) || (this.FormEditStatus == BROWSE))
                {
                    this.FilterEntity(this.WhereString, this.FilterParam);
                    this.CargarMovimiento(this.dgvListadoABM.Rows[this.LastDGVIndex]);
                    index = this.LastDGVIndex;
                }

                this.FormEditStatus = BROWSE;
                this.dgvListadoABM.CurrentCell = this.dgvListadoABM.Rows[index].Cells[0];
                this.dgvListadoABM.CurrentCell.Selected = true;


                MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private List<cxm_cobranzasxmov> GetListaCobranzasAsoc(int MovimientoID = 0)
        {
            List<cxm_cobranzasxmov> Result = new List<cxm_cobranzasxmov>();

            foreach (DataGridViewRow row in this.dgvDetCobranzas.Rows)
            {
                Result.Add(new cxm_cobranzasxmov
                {
                    cxm_cobranzaxmovid = row.Cells[CAMPO_COBROXMOVID].Value != null ? (int)row.Cells[CAMPO_COBROXMOVID].Value : 0,
                    cxm_movimientoid = MovimientoID,
                    cxm_cobranzaid = (int)row.Cells[CAMPO_COBROID].Value
                });

            }

            foreach (SeleccionarCobrosType row in this.cobrosElim)
            {
                cxm_cobranzasxmov cxm = this.DBContext.cxm_cobranzasxmov.First(a => a.cxm_cobranzaxmovid == row.CobroXMovimientoID);
                cxm.cxm_cobranzaxmovid = cxm.cxm_cobranzaxmovid * -1;
                Result.Add(cxm);
            }
            
            return Result;
        }

        private void ucCRUDMovimientoCuenta_ValidarCamposEvent(object sender, EventArgs e)
        {
            if ((this.cbAsociarCobranzas.Checked) && (this.dgvDetCobranzas.RowCount == 0))
            {
                MessageBox.Show("Debe indicar los cobros asociados al movimiento.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            //if ((this.cbAsociarCobranzas.Checked) && (!this.ValidarMontos()))
            //{
            //    MessageBox.Show("El monto ingresado no coincide con la sumatoria de los montos de los cobros asociados.",
            //                    "Información",
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Information);

            //    return;
            //}

            if (this.txtFechaMov.Text == "")
            {
                MessageBox.Show("Debe ingresar la fecha del movimiento.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (this.tSBTipoMovimiento.KeyMember == "")
            {
                MessageBox.Show("Debe ingresar el tipo de movimiento.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (this.txtMonto.Text == "")
            {
                MessageBox.Show("Debe ingresar el monto de movimiento.",
                                 "Información",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);

                return;
            }

            decimal monto = Convert.ToDecimal(this.txtMonto.Text);
            if (monto == 0)
            {
                MessageBox.Show("Debe ingresar un monto superior a 0 (cero).",
                                 "Información",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);

                return;
            }

            if (this.txtObservacion.Text == "")
            {
                MessageBox.Show("Debe ingresar una breve descripción del movimiento.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (this.tSBCuenta.KeyMember == "")
            {
                MessageBox.Show("Debe ingresar la cuenta del movimiento.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            this.ValidOK = true;
        }

        private void GuardarRegistro()
        {
            bool success = false;

            mc_movimientoscuenta mc = null;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        mc = this.guardarMC(context);
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
                    this.FilterEntity(CAMPO_MOVIMIENTOID + " = " + mc.mc_movimientoid.ToString(), null);
                else if (this.FormEditStatus == EDIT)
                    this.FilterEntity(this.WhereString, this.FilterParam);

                this.FormEditStatus = BROWSE;
                this.CargarMovimiento(this.dgvListadoABM.Rows[this.LastDGVIndex]);

                MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EliminarRegistro()
        {
            bool success = false;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        this.eliminarMC(context);
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
                        MessageBox.Show("Ocurrió un error al eliminar el registro: "
                                        + ex.Message + Environment.NewLine
                                        + ex.InnerException,
                                        "Error al eliminar los datos",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Stop);
                    }
                }
                if (success)
                {
                    this.limpiarDatos();
                    this.FilterEntity(this.WhereString, this.FilterParam);
                    this.FormEditStatus = BROWSE;
                    MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #region Métodos de Edición de Datos
        private mc_movimientoscuenta guardarMC(BerkeDBEntities context = null)
        {
            mc_movimientoscuenta mc = new mc_movimientoscuenta();
            if (this.FormEditStatus == EDIT)
            {
                int mcID = Convert.ToInt32(this.txtMovimientoID.Text);

                mc = context.mc_movimientoscuenta.First(a => a.mc_movimientoid == mcID);
                mc.mc_fechamovimiento = Convert.ToDateTime(this.txtFechaMov.Text);
                mc.mc_cuentabancoid = Convert.ToInt32(this.tSBCuenta.KeyMember);
                mc.mc_tipomovimientoid = Convert.ToInt32(this.tSBTipoMovimiento.KeyMember);
                //mc.mc_montomovimiento = Convert.ToDecimal(this.txtMonto.Text.Replace('.', ','));
                mc.mc_montomovimiento = Convert.ToDecimal(this.txtMonto.Text);
                mc.mc_observacion = this.txtObservacion.Text != String.Empty ? this.txtObservacion.Text : null;
                mc.mc_nroboleta = this.txtNroBolDep.Text != String.Empty ? this.txtNroBolDep.Text : String.Empty;
                mc.mc_asociadocobranza = this.cbAsociarCobranzas.Checked;

                if (this.txtFecBolDep.Text != "")
                {
                    mc.mc_fechaboleta =  Convert.ToDateTime(this.txtFecBolDep.Text);
                }
            }
            else if (this.FormEditStatus == INSERT)
            {
                mc.mc_estado = ESTADO_ACTIVO;
                mc.mc_fechamovimiento = Convert.ToDateTime(this.txtFechaMov.Text);
                mc.mc_cuentabancoid = Convert.ToInt32(this.tSBCuenta.KeyMember);
                mc.mc_tipomovimientoid = Convert.ToInt32(this.tSBTipoMovimiento.KeyMember);
                //mc.mc_montomovimiento = Convert.ToDecimal(this.txtMonto.Text.Replace('.', ','));
                mc.mc_montomovimiento = Convert.ToDecimal(this.txtMonto.Text);
                mc.mc_observacion = this.txtObservacion.Text != String.Empty ? this.txtObservacion.Text : null;
                mc.mc_nroboleta = this.txtNroBolDep.Text != String.Empty ? this.txtNroBolDep.Text : String.Empty;
                mc.mc_asociadocobranza = this.cbAsociarCobranzas.Checked;

                if (this.txtFecBolDep.Text != "")
                {
                    mc.mc_fechaboleta = Convert.ToDateTime(this.txtFecBolDep.Text);
                }

                context.mc_movimientoscuenta.Add(mc);
            }

            return mc;
        }

        private void eliminarMC(BerkeDBEntities context = null)
        {
            int tmID = Convert.ToInt32(this.txtMovimientoID.Text);
            tm_tipomovimientocuenta tm = context.tm_tipomovimientocuenta.First(a => a.tm_tipomovimientoid == tmID);

            context.tm_tipomovimientocuenta.Remove(tm);

        }
        #endregion Métodos de Edición de Datos

        private void cbAsociarCobranzas_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.cbAsociarCobranzas.Checked)
            {
                this.tpCobAsoc.Hide();

                if ((this.FormEditStatus != BROWSE) 
                    && (this.dgvListadoABM.CurrentRow != null) 
                    && (this.dgvListadoABM.CurrentRow.Cells[CAMPO_ASOCIADOACOBRANZA].Value != null)
                    && ((bool)this.dgvListadoABM.CurrentRow.Cells[CAMPO_ASOCIADOACOBRANZA].Value))
                {
                    foreach (DataGridViewRow row in this.dgvDetCobranzas.Rows)
                    {
                        if (row.Cells[CAMPO_COBROXMOVID].Value != null)
                            this.cobrosElim.Add((SeleccionarCobrosType)row.DataBoundItem);
                    }
                    this.dgvDetCobranzas.DataSource = null;
                }
            }
            else
                this.tpCobAsoc.Show();
        }
        #endregion CRUD

    }
}