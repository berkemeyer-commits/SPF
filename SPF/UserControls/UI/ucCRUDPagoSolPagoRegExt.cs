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
using SPF.Forms.UI;

#endregion

namespace SPF.UserControls.UI
{
    public partial class ucCRUDPagoSolPagoRegExt : ucBaseForm2015
    {
        #region Constantes
        private const string CAMPO_PAGOCORRESPONSALID = "PagoCorresponsalID";
        private const string CAMPO_SOLICITUDPAGOCABID = "SolicitudPagoCabID";
        private const string CAMPO_DOCUMENTOSID = "DocumentosID";
        private const string CAMPO_DOCUMENTOSINFO = "DocumentosInfo";
        private const string CAMPO_ORIGEN = "Origen";
        private const string CAMPO_CORRESPONSALID = "CorresponsalID";
        private const string CAMPO_CORRESPONSALNOMBRE = "CorresponsalNombre";
        private const string CAMPO_CORRESPONSALNROFACTURA = "CorresponsalNroFactura";
        private const string CAMPO_CORRESPONSALFECFACTURA = "CorresponsalFecFactura";
        private const string CAMPO_MONEDAID = "MonedaID";
        private const string CAMPO_MONEDADESCRIP = "MonedaDescrip";
        private const string CAMPO_MONEDAABREV = "MonedaAbrev";
        private const string CAMPO_FECHAPAGO = "FechaPago";
        private const string CAMPO_FORMAPAGOID = "FormaPagoID";
        private const string CAMPO_FORMAPAGONOMBRE = "FormaPagoNombre";
        private const string CAMPO_USUARIOGENID = "UsuarioGeneracionID";
        private const string CAMPO_USUARIOGENNOMBRE = "UsuarioGeneracionNombre";
        /*Depósito en Cuenta*/
        private const string CAMPO_FECHABOLETADEP = "FechaBoletaDep";
        private const string CAMPO_BANCODEPID = "BancoDepID";
        private const string CAMPO_BANCODEPNOMBRE = "BancoDepNombre";
        private const string CAMPO_CTADEPID = "CtaDepID";
        private const string CAMPO_CTADEPNOMBRE = "CtaDepNombre";
        /*Cheque*/
        private const string CAMPO_FECHACHEQUE = "FechaCheque";
        private const string CAMPO_BANCOCHEQID = "BancoCheqID";
        private const string CAMPO_BANCOCHEQNOMBRE = "BancoCheqNombre";
        private const string CAMPO_CTACHEQID = "CtaCheqID";
        private const string CAMPO_CTACHEQNOMBRE = "CtaCheqNombre";
        private const string CAMPO_CTACHEQNRO = "CtaCheqNro";
        private const string CAMPO_MONEDACTACHEQ = "MonedaCtaCheq";
        private const string CAMPO_CHEQUENRO = "ChequeNro";
        /*Recibo*/
        private const string CAMPO_NRORECIBO = "NroRecibo";
        private const string CAMPO_FECHARECIBO = "FechaRecibo";
        /*Nota Crédito*/
        private const string CAMPO_NOTACREDITONRO = "NotaCreditoNro";
        private const string CAMPO_FECHANOTACREDITO = "FechaNotaCredito";

        private const string CAMPO_MONTOPAGO = "MontoPago";
        private const string CAMPO_SALDO = "Saldo";
        private const string CAMPO_SALDOTOTAL = "SaldoTotal";
        private const string CAMPO_REFERENCIAPAGO = "ReferenciaPago";
        private const string CAMPO_AUTORIZACIONVIG = "TieneAutorizacionVigente";
        private const string CAMPO_ANULADO = "Anulado";
        private const string CAMPO_EXTRA = "Extra";
        private const string CAMPO_SOLICITUDPAGOCABID_TABLA = "spc_solicitudpagocabid";
        private const string CAMPO_SOLICITUDPAGOCABID_DET_TABLA = "spd_solicitudpagocabid";
        private const string CAMPO_PAGOSOLICITUDFK_TABLA = "sxp_pagosolicitudid";
        private const string CAMPO_PAGOSOLICITUDPK_TABLA = "ps_pagosolicitudid";

        private const string ESTADO_PENDIENTE = "A";
        private const string ESTADO_ANULADO = "N";
        private const string ESTADO_ACTIVOVALOR = "Activo";
        private const string ESTADO_ANULADOVALOR = "Anulado";
        private const string ESTADO_PAGADO = "P";
        private const string FILTRO_FACTURA = "F";
        private const string FILTRO_SOLICITUD = "S";
        private const string FILTRO_PROVEEDOR = "P";
        private const int IDIOMA_ESPANOL = 2;
        private const int TIPODOCUMENTO_PAGOSOLICITUDPAGO = 9;
        private const int FORMAPAGO_CHEQUELOCAL = 2;
        private const int TIPOMOV_PAGOPROVEEDORES = 4;
        private const string SIN_FACTURA = "No posee factura";
        private const string VARIAS_FACTURAS = "Varias Facturas";
        private const string SIN_PROVEEDORES = "Sin Proveedores";
        private const string VARIOS_PROVEEDORES = "Varios Proveedores";
        private const string VARIAS_SOLICITUDES = "{0} Solicitudes: {1}";
        private const int WIDTH_113 = 113;
        private const int WIDTH_70 = 70;
        private const string FORMATO_DECIMAL_BROWSE = "{0:N2}";
        private const string FORMATO_DECIMAL_EDIT = "{0:0.00}";
        #endregion Constantes

        #region Variables Globales
        frmPickBase fPickMoneda;
        frmPickBase fPickFormaPago;
        frmPickBase fPickBancoDeposito;
        frmPickBase fPickCuentaDeposito;
        frmPickBase fPickBancoCheque;
        frmPickBase fPickSolicitudCab;
        FSelSolicPorProveedor fSelSolxProv;
        private frmPickBase fPickCuenta;
        private int UsuarioID = -1;
        private List<PagoSolPagoRegExtTypeAll> lPagos;
        #endregion Variables Globales

        #region Método de Inicio
        public ucCRUDPagoSolPagoRegExt()
        {
            InitializeComponent();
        }

        public ucCRUDPagoSolPagoRegExt(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();
            this.DBContext = dbContext;
            this.Titulo = Titulo;
            this.UsuarioID = Convert.ToInt32(VWGContext.Current.Session["UsuarioID"].ToString());
            this.UseSQLSyntax = true;
            this.tbbImprimir.Visible = true;

            lPagos = new List<PagoSolPagoRegExtTypeAll>();

            lPagos = (from lista in this.DBContext.GetListaPagoCorresponsales(this.UsuarioID, String.Empty)
                      select new PagoSolPagoRegExtTypeAll
                      {
                          PagoCorresponsalID = lista.PagoCorresponsalID, //ID de Pago
                          Origen = lista.Origen,
                          CorresponsalID = lista.CorresponsalID,
                          CorresponsalNombre = lista.CorresponsalNombre,
                          CorresponsalNroFactura = lista.CorresponsalNroFactura,
                          CorresponsalFecFactura = lista.CorresponsalFecFactura,
                          MonedaID = lista.MonedaID,
                          MonedaDescrip = lista.MonedaDescrip,
                          MonedaAbrev = lista.MonedaAbrev,
                          FechaPago = lista.FechaPago,
                          FormaPagoID = lista.FormaPagoID,
                          FormaPagoNombre = lista.FormaPagoNombre,
                          MontoPago = lista.MontoPago,
                          ReferenciaPago = lista.ReferenciaPago,
                          DocumentosID = lista.DocumentosID,
                          DocumentosInfo = lista.DocumentosInfo,
                          TieneAutorizacionVigente = lista.TieneAutorizacionVigente,
                          UsuarioGeneracionID = lista.UsuarioGeneracionID,
                          UsuarioGeneracionNombre = lista.UsuarioGeneracionNombre,
                          SaldoTotal = lista.SaldoTotal,
                          Anulado = lista.Anulado,
                          /*Depósito en Cuenta*/
                          FechaBoletaDep = lista.FechaBoletaDep,
                          BancoDepID = lista.BancoDepID,
                          BancoDepNombre = lista.BancoDepNombre,
                          CtaDepID = lista.CtaDepID,
                          CtaDepNombre = lista.CtaDepNombre,
                          /*Cheque*/
                          FechaCheque = lista.FechaCheque,
                          BancoCheqID = lista.BancoCheqID,
                          BancoCheqNombre = lista.BancoCheqNombre,
                          CtaCheqID = lista.CtaCheqID,
                          CtaCheqNombre = lista.CtaCheqNombre,
                          CtaCheqNro = lista.CtaCheqNro,
                          MonedaCtaCheq = lista.MonedaCtaCheq,
                          ChequeNro = lista.ChequeNro,
                          /*Recibo*/
                          NroRecibo = lista.NroRecibo,
                          FechaRecibo = lista.FechaRecibo,
                          /*Nota Crédito*/
                          NotaCreditoNro = lista.NotaCreditoNro,
                          FechaNotaCredito = lista.FechaNotaCredito,
                          //Detalle
                          SolicitudPagoCabID = lista.SolicitudPagoCabID, //ID de Solicitud de Pago a Proveedor
                          Saldo = lista.Saldo                                                                             
                      })
                      .ToList();

            this.BindingSourceBase_ExportExcelGrid = lPagos;
            //this.LoadGridExportToExcel();

            var query = (from item in lPagos
                         select new PagoSolPagoRegExtTypeCab
                         {
                             //Cabecera
                             PagoCorresponsalID = item.PagoCorresponsalID, //ID de Pago
                             Origen = item.Origen,
                             CorresponsalID = item.CorresponsalID,
                             CorresponsalNombre = item.CorresponsalNombre,
                             CorresponsalNroFactura = item.CorresponsalNroFactura,
                             CorresponsalFecFactura = item.CorresponsalFecFactura,
                             MonedaID = item.MonedaID,
                             MonedaDescrip = item.MonedaDescrip,
                             MonedaAbrev = item.MonedaAbrev,
                             FechaPago = item.FechaPago,
                             FormaPagoID = item.FormaPagoID,
                             FormaPagoNombre = item.FormaPagoNombre,
                             DocumentosID = item.DocumentosID,
                             DocumentosInfo = item.DocumentosInfo,
                             MontoPago = item.MontoPago,
                             ReferenciaPago = item.ReferenciaPago,
                             TieneAutorizacionVigente = item.TieneAutorizacionVigente,
                             UsuarioGeneracionID = item.UsuarioGeneracionID,
                             UsuarioGeneracionNombre = item.UsuarioGeneracionNombre,
                             SaldoTotal = item.SaldoTotal,
                             Anulado = item.Anulado,
                             /*Depósito en Cuenta*/
                             FechaBoletaDep = item.FechaBoletaDep,
                             BancoDepID = item.BancoDepID,
                             BancoDepNombre = item.BancoDepNombre,
                             CtaDepID = item.CtaDepID,
                             CtaDepNombre = item.CtaDepNombre,
                             /*Cheque*/
                             FechaCheque = item.FechaCheque,
                             BancoCheqID = item.BancoCheqID,
                             BancoCheqNombre = item.BancoCheqNombre,
                             CtaCheqID = item.CtaCheqID,
                             CtaCheqNombre = item.CtaCheqNombre,
                             CtaCheqNro = item.CtaCheqNro,
                             MonedaCtaCheq = item.MonedaCtaCheq,
                             ChequeNro = item.ChequeNro,
                             /*Recibo*/
                             NroRecibo = item.NroRecibo,
                             FechaRecibo = item.FechaRecibo,
                             /*Nota Crédito*/
                             NotaCreditoNro = item.NotaCreditoNro,
                             FechaNotaCredito = item.FechaNotaCredito,
                         })
                         .GroupBy(x => new { x.PagoCorresponsalID }).Select(g => g.First()).ToList();

            this.BindingSourceBase = query;

            #region Especificar campos para filtro
            this.SetFilter(CAMPO_PAGOCORRESPONSALID, "Pago Corr. ID", false);        
            this.SetFilter(CAMPO_SOLICITUDPAGOCABID, "Sol. Pago ID", false);
            this.SetFilter(CAMPO_CORRESPONSALID, "Corr. ID", false);
            this.SetFilter(CAMPO_CORRESPONSALNOMBRE, "Corr. Nomb.");
            this.SetFilter(CAMPO_CORRESPONSALNROFACTURA, "N° Fact. Corr.");
            this.SetFilter(CAMPO_CORRESPONSALFECFACTURA, "Fec. Fact. Corr.");
            this.SetFilter(CAMPO_MONEDAID, "Moneda ID.", false);
            this.SetFilter(CAMPO_MONEDADESCRIP, "Mon. Desc.");
            this.SetFilter(CAMPO_MONEDAABREV, "Mon. Abrev.");
            this.SetFilter(CAMPO_FECHAPAGO, "Fecha Pago");
            this.SetFilter(CAMPO_FORMAPAGOID, "Forma Pago ID", false);
            this.SetFilter(CAMPO_FORMAPAGONOMBRE, "For. Pago Desc.");
            this.SetFilter(CAMPO_USUARIOGENID, "ID Usu. Gen.", false);
            this.SetFilter(CAMPO_USUARIOGENNOMBRE, "Nomb. Usu. Gen.");
            /*Depósito en Cuenta*/
            this.SetFilter(CAMPO_FECHABOLETADEP, "Fec. Bol. Pago");
            this.SetFilter(CAMPO_BANCODEPID, "Banc. Dép. ID.", false);
            this.SetFilter(CAMPO_BANCODEPNOMBRE, "Banc. Dép. Nomb.");
            this.SetFilter(CAMPO_CTADEPID, "Cta. Dép. ID.", false);
            this.SetFilter(CAMPO_CTADEPNOMBRE, "Cta. Dép. Nomb.");
            ///*Cheque*/
            this.SetFilter(CAMPO_FECHACHEQUE, "Fecha Cheque");
            this.SetFilter(CAMPO_CHEQUENRO, "N° Cheque");
            this.SetFilter(CAMPO_BANCOCHEQID, "Banc. Cheq. ID.", false);
            this.SetFilter(CAMPO_BANCOCHEQNOMBRE, "Banc. Cheq. Nomb.");
            this.SetFilter(CAMPO_CTACHEQID, "Cta. Cheq. ID.", false);
            this.SetFilter(CAMPO_CTACHEQNOMBRE, "Cta. Cheq. Nomb.");
            this.SetFilter(CAMPO_CTACHEQNRO, "Cta. Cheq. N°");
            ///*Recibo*/
            this.SetFilter(CAMPO_NRORECIBO, "N° Recibo");
            this.SetFilter(CAMPO_FECHARECIBO, "Fecha Recibo");
            ///*Nota Crédito*/
            this.SetFilter(CAMPO_NOTACREDITONRO, "N° Nota Créd.");
            this.SetFilter(CAMPO_FECHANOTACREDITO, "Fec. Nota Créd.");
            this.SetFilter(CAMPO_MONTOPAGO, "Monto", false);//
            this.SetFilter(CAMPO_SALDO, "Saldo", false);//
            this.SetFilter(CAMPO_REFERENCIAPAGO, "Ref. Pago");//


            this.TituloBuscador = "Buscar Pagos a Proveedores";
            #endregion Especificar campos para filtro

            #region Inicializar TextSearchBoxes
            this.tSBMoneda.KeyMemberWidth = 70;
            this.tSBMoneda.ToolTip = "Elegir Moneda";
            this.tSBMoneda.AceptarClick += tSBMoneda_AceptarClick;

            this.tSBFormaPago.KeyMemberWidth = 70;
            this.tSBFormaPago.ToolTip = "Elegir Forma de Pago";
            this.tSBFormaPago.AceptarClick += tSBFormaPago_AceptarClick;

            this.tSBBancoDeposito.KeyMemberWidth = 70;
            this.tSBBancoDeposito.ToolTip = "Elegir Banco de Transferencia";
            this.tSBBancoDeposito.AceptarClick += tSBBancoDeposito_AceptarClick;

            this.tSBCuentaDeposito.KeyMemberWidth = 70;
            this.tSBCuentaDeposito.ToolTip = "Elegir Cuenta de Transferencia";
            this.tSBCuentaDeposito.AceptarClick += tSBCuentaDeposito_AceptarClick;

            this.tSBCuenta.KeyMemberWidth = 70;
            this.tSBCuenta.ToolTip = "Elegir Cuenta del Cheque";
            this.tSBCuenta.SoloLectura = true;
            this.tSBCuenta.AceptarClick += tSBCuenta_AceptarClick;

            //this.tSBBancoCheque.KeyMemberWidth = 70;
            //this.tSBBancoCheque.ToolTip = "Elegir Banco de Cheque";
            //this.tSBBancoCheque.AceptarClick += tSBBancoCheque_AceptarClick;

            this.tSBSolicitudCab.KeyMemberWidth = 70;
            this.tSBSolicitudCab.ToolTip = "Elegir Documento a Pagar";
            this.tSBSolicitudCab.SoloLectura = true;
            this.tSBSolicitudCab.AceptarClick += tSBSolicitudCab_AceptarClick;

            #endregion Inicializar TextSearchBoxes

            #region Datetime Picker
            this.dtpFechaPago.Format = DateTimePickerFormat.Short;
            this.dtpFechaDeposito.Format = DateTimePickerFormat.Short;
            #endregion Datetime Picker

            #region Ocultar Botones
            this.tbbBorrar.Visible = false;
            //this.tbbEditar.Visible = false;
            #endregion Ocultar Botones

            #region Asignación Eventos Deletados
            //Asignar Evento de Validación de carga de campos
            this.ValidarCamposEvent += ucCRUDPagoSolPago_ValidarCamposEvent;
            //Asignar Evento para Guardar Registro
            this.CRUDEvent += ucCRUDPagoSolPago_CRUDEvent;
            #endregion Asignación Eventos Deletados

        }

        private void ucCRUDPagoSolPago_Load(object sender, EventArgs e)
        {
            //this.btnVerFacturas.Visible = false;
            //this.btnVerProveedores.Visible = false;
            
        }
        
        #endregion Método de Inicio

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

            fPickMoneda.Close();
            fPickMoneda.Dispose();
        }
        #endregion Moneda

        #region Forma de Pago
        private void tSBFormaPago_AceptarClick(object sender, EventArgs e)
        {
            if (fPickFormaPago == null)
            {
                fPickFormaPago = new frmPickBase();
                fPickFormaPago.AceptarFiltrarClick += fPickFormaPago_AceptarFiltrarClick;
                fPickFormaPago.FiltrarClick += fPickFormaPago_FiltrarClick;
                fPickFormaPago.Titulo = "Elegir Forma de Pago";
                fPickFormaPago.CampoIDNombre = "fp_formadepagoid";
                fPickFormaPago.CampoDescripNombre = "fp_descripcion";
                fPickFormaPago.LabelCampoID = "ID";
                fPickFormaPago.LabelCampoDescrip = "Nombre";
                fPickFormaPago.NombreCampo = "Forma Pago";
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

            fPickFormaPago.Close();
            fPickFormaPago.Dispose();

        //    if ((Convert.ToInt32(this.tSBFormaPago.KeyMember) == FORMAPAGO_NOTACREDITOPRESUPUESTO) && (this.ExistenNCConSaldo))
        //    {
        //        this.tSBNotaCredito.Visible = true;
        //        this.txtNotaCreditoNro.Visible = false;
        //        this.txtReferenciaNotaCredito.ReadOnly = true;
        //        this.txtReferenciaNotaCredito.BackColor = SystemColors.Control; 
        //        this.txtNotaCreditoCuerpo.ReadOnly = true;
        //        this.txtNotaCreditoCuerpo.BackColor = SystemColors.Control; 
        //    }
        //    else
        //    {
        //        this.tSBNotaCredito.Visible = false;
        //        this.txtNotaCreditoNro.Visible = true;
        //        this.txtReferenciaNotaCredito.ReadOnly = false;
        //        this.txtReferenciaNotaCredito.BackColor = SystemColors.Window;
        //        this.txtNotaCreditoCuerpo.ReadOnly = false;
        //        this.txtNotaCreditoCuerpo.BackColor = SystemColors.Window;
        //    }
        //    this.txtFechaNotaCredito.Text = "";
        //    this.txtNotaCreditoNro.Text = "";
        //    this.txtIdNotaCredito.Text = "";
        //    this.txtNCSaldo.Text = "";
        //    this.txtNCTotal.Text = "";
        //    this.txtNotaCreditoCuerpo.Text = "";
        //    this.txtReferenciaNotaCredito.Text = "";

        }
        #endregion Forma de Pago

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

        #region Cuenta
        private void tSBCuenta_AceptarClick(object sender, EventArgs e)
        {
            if (fPickCuenta == null)
            {
                fPickCuenta = new frmPickBase();
                fPickCuenta.AceptarFiltrarClick += fPickCuenta_AceptarFiltrarClick;
                fPickCuenta.FiltrarClick += fPickCuenta_FiltrarClick;
                fPickCuenta.Titulo = "Elegir Cuenta ";
                fPickCuenta.CampoIDNombre = "CuentaID";
                fPickCuenta.CampoDescripNombre = "CuentaDescripcion";
                fPickCuenta.LabelCampoID = "ID";
                fPickCuenta.LabelCampoDescrip = "Descripción";
                fPickCuenta.NombreCampo = "Cuenta";
                fPickCuenta.PermitirFiltroNulo = true;
            }
            if (this.txtMonedaID.Text == "")
            {
                MessageBox.Show("Moneda de Pago no definida", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            fPickCuenta.MostrarFiltro();
            this.fPickCuenta_FiltrarClick(sender, e);
        }

        private void fPickCuenta_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickCuenta != null)
            {
                //fPickCuenta.LoadData<cb_cuentabanco>(this.DBContext.cb_cuentabanco, fPickCuenta.GetWhereString());
                int monedaID = Convert.ToInt32(this.txtMonedaID.Text);
                var query = (from cb in this.DBContext.cb_cuentabanco
                             select new CuentaType
                             {
                                 CuentaID = cb.cb_cuentabancoid,
                                 CuentaDescripcion = cb.cb_descripcion,
                                 BancoID = cb.cb_bancoid,
                                 MonedaID = cb.cb_monedaid,
                                 EsCuentaPago = cb.cb_escuentapago
                             }).Where(a => a.MonedaID == monedaID && a.EsCuentaPago == true);

                fPickCuenta.LoadData<CuentaType>(query.AsQueryable(), fPickCuenta.GetWhereString());
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
                             BancoID = cb.cb_bancoid,
                             BancoNombre = ba.ba_descripcion,
                             MonedaAbrev = mon.AbrevMoneda
                         })
                        .Where(a => a.CuentaID == cuentaID).ToList();

            this.txtMoneda.Text = query.First().MonedaAbrev;
            this.txtNroCuenta.Text = query.First().NroCuenta;
            this.txtBancoChequeID.Text = query.First().BancoID.ToString();
            this.txtBanco.Text = query.First().BancoNombre;
            this.txtNroCheque.Focus();
        }
        #endregion Cuenta

        //#region Banco Cheque
        //private void tSBBancoCheque_AceptarClick(object sender, EventArgs e)
        //{
        //    if (fPickBancoCheque == null)
        //    {
        //        fPickBancoCheque = new frmPickBase();
        //        fPickBancoCheque.AceptarFiltrarClick += fPickBancoCheque_AceptarFiltrarClick;
        //        fPickBancoCheque.FiltrarClick += fPickBancoCheque_FiltrarClick;
        //        fPickBancoCheque.Titulo = "Elegir Banco Cheque";
        //        fPickBancoCheque.CampoIDNombre = "ba_bancoid";
        //        fPickBancoCheque.CampoDescripNombre = "ba_descripcion";
        //        fPickBancoCheque.LabelCampoID = "ID";
        //        fPickBancoCheque.LabelCampoDescrip = "Nombre";
        //        fPickBancoCheque.NombreCampo = "Banco";
        //        fPickBancoCheque.PermitirFiltroNulo = true;
        //    }
        //    fPickBancoCheque.MostrarFiltro();
        //    this.fPickBancoCheque_FiltrarClick(sender, e);
        //}

        //private void fPickBancoCheque_FiltrarClick(object sender, EventArgs e)
        //{
        //    if (fPickBancoCheque != null)
        //    {
        //        fPickBancoCheque.LoadData<ba_banco>(this.DBContext.ba_banco, fPickBancoCheque.GetWhereString());
        //    }
        //}

        //private void fPickBancoCheque_AceptarFiltrarClick(object sender, EventArgs e)
        //{
        //    this.tSBBancoCheque.DisplayMember = fPickBancoCheque.ValorDescrip;
        //    this.tSBBancoCheque.KeyMember = fPickBancoCheque.ValorID;

        //    fPickBancoCheque.Close();
        //    fPickBancoCheque.Dispose();
        //}
        //#endregion Banco Cheque

        #region Documento A Pagar
        
        private void tSBSolicitudCab_AceptarClick(object sender, EventArgs e)
        {
            string filterType = this.GetFilterType();
            if (filterType == FILTRO_PROVEEDOR)
            {
                if (fSelSolxProv == null)
                {
                    fSelSolxProv = new FSelSolicPorProveedor(this.DBContext, "Selección de Documentos para Pago", true);
                    fSelSolxProv.AceptarClick += fSelSolxProv_AceptarClick;
                }

                fSelSolxProv.ShowDialog();
            }
            else
            {
                if (fPickSolicitudCab == null)
                {
                    if (this.cbCampoFiltro.SelectedIndex < 0)
                    {
                        MessageBox.Show("Debe seleccionar un criterio de búsqueda.",
                                    "Información",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                        return;
                    }

                    fPickSolicitudCab = new frmPickBase(800);
                    fPickSolicitudCab.FormClosed += delegate { fPickSolicitudCab = null; };
                    fPickSolicitudCab.AceptarFiltrarClick += fPickSolicitudCab_AceptarFiltrarClick;
                    fPickSolicitudCab.FiltrarClick += fPickSolicitudCab_FiltrarClick;

                    fPickSolicitudCab.CampoIDNombre = "Id";
                    fPickSolicitudCab.CampoDescripNombre = "Informacion";
                    fPickSolicitudCab.LabelCampoID = "ID";
                    fPickSolicitudCab.LabelCampoDescrip = "Información";
                    fPickSolicitudCab.Col2Width = 600;

                    if (this.cbCampoFiltro.SelectedIndex == 0)
                    {
                        fPickSolicitudCab.Titulo = "Elegir Documento a Pagar - Por N° de Factura";
                        fPickSolicitudCab.NombreCampo = "Datos Fact.";
                        fPickSolicitudCab.LabelCampoID = "Solicitudes";
                        fPickSolicitudCab.LabelCampoDescrip = "Datos Factura";
                        fPickSolicitudCab.SetExplicitToolTipIDTextBox("N° o Fecha de Factura, Corresponsal, Referencia u Observación");
                        fPickSolicitudCab.HideDescriptionTextBox(true);
                        fPickSolicitudCab.UseExplicitToolTip = true;
                        fPickSolicitudCab.Col1Width = 100;
                    }
                    else if (this.cbCampoFiltro.SelectedIndex == 1)
                    {
                        fPickSolicitudCab.Titulo = "Elegir Documento a Pagar - Por N° de Solicitud";
                        fPickSolicitudCab.LabelCampoID = "N° de Solicitud";
                        fPickSolicitudCab.LabelCampoDescrip = "Referencia u Observación";
                        fPickSolicitudCab.NombreCampo = "Solicitud";
                        fPickSolicitudCab.SetExplicitToolTipIDTextBox("ID Solicitud");
                        fPickSolicitudCab.SetExplicitToolTipDescripTextBox("Referencia u Observación");
                        fPickSolicitudCab.UseExplicitToolTip = true;
                        fPickSolicitudCab.Col1Width = 70;
                    }
                    else if (this.cbCampoFiltro.SelectedIndex == 2)
                    {
                        fPickSolicitudCab.Titulo = "Elegir Documento a Pagar - Por Provedor";
                        fPickSolicitudCab.LabelCampoID = "Proveedor";
                        fPickSolicitudCab.LabelCampoDescrip = "Razón Social";
                        fPickSolicitudCab.NombreCampo = "Proveedor";
                        fPickSolicitudCab.SetExplicitToolTipIDTextBox("ID Proveedor");
                        fPickSolicitudCab.SetExplicitToolTipDescripTextBox("Razón Social");
                        fPickSolicitudCab.UseExplicitToolTip = true;
                    }
                    fPickSolicitudCab.PermitirFiltroNulo = true;
                }
                fPickSolicitudCab.MostrarFiltro();
            }
        }

        private void fPickSolicitudCab_FiltrarClick(object sender, EventArgs e)
        {
            string filterType = this.GetFilterType();
            #region Pick SolicitudCab
                if (fPickSolicitudCab != null)
                {
                    if ((fPickSolicitudCab.GetIDFilter == "") && (fPickSolicitudCab.GetDescripFilter == ""))
                    {
                        MessageBox.Show("Debe establecer algún criterio de filtro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string valorInt = "";
                    string valorAlfa = "";
                    //string filterType = this.GetFilterType();

                    if (filterType == FILTRO_SOLICITUD)
                    {
                        valorInt = fPickSolicitudCab.GetIDFilter;
                        valorAlfa = fPickSolicitudCab.GetDescripFilter;
                    }
                    else if (filterType == FILTRO_FACTURA)
                    {
                        valorInt = "";
                        valorAlfa = fPickSolicitudCab.GetIDFilter;
                    }

                    var query = (from data in this.DBContext.GetDocumentoAPagarCorresponsal(filterType,
                                                                                            valorInt,
                                                                                            valorAlfa)
                                 select new PagoProveedorFilterTypeSolicitud
                                 {
                                     Id = data.Id,
                                     Informacion = data.Informacion,
                                     Saldo = data.Saldo,
                                     Importe = data.Importe,
                                     Extra = data.Extra
                                 }).ToList();

                    fPickSolicitudCab.LoadData<PagoProveedorFilterTypeSolicitud>(query.AsQueryable());

                }
                #endregion Pick SolicitudCab

        }

        private void fSelSolxProv_AceptarClick(object sender, EventArgs e)
        {
            this.tSBSolicitudCab.KeyMember = fSelSolxProv.ListaSolicitudes.Replace(" ", String.Empty);
            this.tSBSolicitudCab.DisplayMember = fSelSolxProv.Informacion;

            string[] solicitudesArray = this.tSBSolicitudCab.KeyMember.Split(',');

            if (solicitudesArray.Count() > 1)
            {
                this.lblVariasSolicitudes.Text = String.Format(VARIAS_SOLICITUDES, solicitudesArray.Count().ToString(), this.tSBSolicitudCab.KeyMember);
                this.lblVariasSolicitudes.Visible = true;
            }
            else if (solicitudesArray.Count() == 1)
            {
                this.lblVariasSolicitudes.Text = "";
                this.lblVariasSolicitudes.Visible = false;
            }

            string[] datosFactura = fSelSolxProv.DatosFactura.Split('#');

            if (datosFactura.Count() > 0)
            {
                this.txtProveedorID.Text = datosFactura[0];
                this.txtProveedorNombre.Text = datosFactura[1];
                this.txtFecFactura.Text = datosFactura[2];
                this.txtNroFactura.Text = datosFactura[3];
                this.txtMonedaID.Text = datosFactura[4];
                this.txtMonedaDescrip.Text = datosFactura[5];

                if (datosFactura[3] == VARIAS_FACTURAS)
                {
                    this.lblFecFactura.Visible = false;
                    this.txtFecFactura.Visible = false;
                }
                else
                {
                    this.lblFecFactura.Visible = true;
                    this.txtFecFactura.Visible = true;
                }
            }
            else
            {
                this.txtProveedorID.Text = "";
                this.txtProveedorNombre.Text = "";
                this.txtFecFactura.Text = "";
                this.txtNroFactura.Text = "";
                this.txtMonedaID.Text = "";
                this.txtMonedaDescrip.Text = "";
            }

            this.txtSaldo.Text = String.Format(FORMATO_DECIMAL_BROWSE, fSelSolxProv.Saldo);
            this.txtMontoPago.Text = String.Format(FORMATO_DECIMAL_BROWSE, fSelSolxProv.Saldo);
           
            if (this.lblVariasSolicitudes.Visible)
                this.tTBaseForm.SetToolTip(this.lblVariasSolicitudes, this.lblVariasSolicitudes.Text);

            fSelSolxProv.Close();
        }

        private void fPickSolicitudCab_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.limpiarDatosFiltro();
            if (this.GetFilterType() == FILTRO_SOLICITUD)
            {
                this.tSBSolicitudCab.KeyMember = fPickSolicitudCab.ValorID;
                this.tSBSolicitudCab.DisplayMember = fPickSolicitudCab.ValorDescrip;
                this.txtSaldo.Text = String.Format(FORMATO_DECIMAL_BROWSE, (decimal)fPickSolicitudCab.GetValor(CAMPO_SALDO));
                this.txtMontoPago.Text = String.Format(FORMATO_DECIMAL_BROWSE, (decimal)fPickSolicitudCab.GetValor(CAMPO_SALDO));

                int SolicitudCabID = Convert.ToInt32(fPickSolicitudCab.ValorID);

                var query = (from spc in this.DBContext.spc_solicitudpagocab
                             join spd in this.DBContext.spd_solicitudpagodet
                                on spc.spc_solicitudpagocabid equals spd.spd_solicitudpagocabid into spd_spc
                                from spd in spd_spc.DefaultIfEmpty()
                             join cli in this.DBContext.Cliente
                                on spd.spd_proveedorid equals cli.ID into cli_spd
                                from cli in cli_spd.DefaultIfEmpty()
                             join mon in this.DBContext.Moneda
                                on spc.spc_monedaid equals mon.ID
                                select new
                                {
                                    SolicitudPagoCabID = spc.spc_solicitudpagocabid,
                                    NroFactura = spd.spd_nrofactura,
                                    FechaFactura = spd.spd_fechafactura,
                                    ProveedorID = spd.spd_proveedorid,
                                    NombreProveerdor = cli.Nombre,
                                    MonedaID = spc.spc_monedaid,
                                    MonedaDescrip = mon.Descripcion,
                                    Saldo = spd.spd_saldo
                                })
                                .Where(a => a.SolicitudPagoCabID== SolicitudCabID && a.Saldo > 0)
                                .ToList();

                #region Contar Factura y Proveedores
                int cantFacturas = 0;
                int cantProveedores = 0;
                string gNroFactura = "";
                string gFechaFactura = "";
                int gProveedorID = -1;
                int gProveedorID2 = -1;
                foreach (var row in query)
                {
                    string auxFechaFactura = row.FechaFactura.HasValue ? row.FechaFactura.Value.ToShortDateString() : ""; 
                    int auxProveedorID = row.ProveedorID.HasValue ? row.ProveedorID.Value : -1;
                    if ((gNroFactura != row.NroFactura) ||
                        (gFechaFactura != auxFechaFactura) ||
                        (gProveedorID != auxProveedorID))
                    {
                        gNroFactura = row.NroFactura;
                        gFechaFactura = auxFechaFactura;
                        gProveedorID = auxProveedorID;
                        cantFacturas++;
                    }
                    if (gProveedorID2 != auxProveedorID)
                    {
                        gProveedorID2 = auxProveedorID;
                        cantProveedores++;
                    }
                }

                #endregion Contar Factura y Proveedores

                #region Manejar Apariencia y valores según Cantidad de Facturas Encontradas
                if (cantFacturas == 0)
                {
                    this.txtNroFactura.Text = SIN_FACTURA;
                    this.txtFecFactura.Text = "";
                    this.txtFecFactura.Visible = false;
                    this.lblFecFactura.Visible = false;
                    //this.btnVerFacturas.Visible = false;
                }
                else if (cantFacturas == 1)
                {
                    this.txtNroFactura.Text = query.First().NroFactura != null ? query.First().NroFactura : SIN_FACTURA;
                    //this.btnVerFacturas.Visible = false;
                    if (query.First().FechaFactura.HasValue)
                    {
                        this.txtFecFactura.Text = query.First().FechaFactura.Value.ToShortDateString();
                        this.txtFecFactura.Visible = true;
                        this.lblFecFactura.Visible = true;
                        
                    }
                    else
                    {
                        this.txtFecFactura.Text = "";
                        this.txtFecFactura.Text = "";
                        this.txtFecFactura.Visible = false;
                        this.lblFecFactura.Visible = false;
                    }
                }
                else
                {
                    this.txtNroFactura.Text = VARIAS_FACTURAS;
                    this.txtFecFactura.Text = "";
                    this.txtFecFactura.Visible = false;
                    this.lblFecFactura.Visible = false;
                    //this.btnVerFacturas.Visible = true;
                }
                #endregion Manejar Apariencia y valores según Cantidad de Facturas Encontradas

                #region Manejar Apariencia y valores según Cantidad de Proveedores Encontrados
                if (cantProveedores == 0)
                {
                    this.txtProveedorID.Text = SIN_PROVEEDORES;
                    this.txtProveedorID.Size = new Size(WIDTH_113, this.txtProveedorID.Size.Height);
                    this.txtProveedorNombre.Text = "";
                    this.txtProveedorNombre.Visible = false;
                    //this.btnVerProveedores.Visible = false;
                }
                else if (cantProveedores == 1)
                {
                    //this.btnVerProveedores.Visible = false;
                    if (query.First().ProveedorID != null)
                    {
                        this.txtProveedorID.Text = query.First().ProveedorID.Value.ToString();
                        this.txtProveedorNombre.Text = query.First().NombreProveerdor;
                        this.txtProveedorNombre.Visible = true;
                    }
                    else
                    {
                        this.txtProveedorID.Text = SIN_PROVEEDORES;
                        this.txtProveedorID.Size = new Size(WIDTH_113, this.txtProveedorID.Size.Height);
                        this.txtProveedorNombre.Text = "";
                        this.txtProveedorNombre.Visible = false;
                    }   
                }
                else
                {
                    this.txtProveedorID.Text = VARIOS_PROVEEDORES;
                    this.txtProveedorID.Size = new Size(WIDTH_113, this.txtProveedorID.Size.Height);
                    this.txtProveedorNombre.Text = "";
                    this.txtProveedorNombre.Visible = false;
                    //this.btnVerProveedores.Visible = true;
                }
                this.txtMonedaID.Text = query.First().MonedaID.ToString();
                this.txtMonedaDescrip.Text = query.First().MonedaDescrip;
            
                #endregion Manejar Apariencia y valores según Cantidad de Proveedores Encontrados
            }
            else if (this.GetFilterType() == FILTRO_FACTURA)
            {
                this.tSBSolicitudCab.KeyMember = fPickSolicitudCab.ValorID.Replace(" ", String.Empty);
                this.tSBSolicitudCab.DisplayMember = fPickSolicitudCab.ValorDescrip;

                string[] solicitudesArray = this.tSBSolicitudCab.KeyMember.Split(',');

                if (solicitudesArray.Count() > 1)
                {
                    this.lblVariasSolicitudes.Text = String.Format(VARIAS_SOLICITUDES, solicitudesArray.Count().ToString(), fPickSolicitudCab.ValorID);
                    this.lblVariasSolicitudes.Visible = true;
                }
                else if (solicitudesArray.Count() == 1)
                {
                    this.lblVariasSolicitudes.Text = "";
                    this.lblVariasSolicitudes.Visible = false;
                }

                string[] datosFactura = fPickSolicitudCab.GetValor(CAMPO_EXTRA).ToString().Split('#');

                if (datosFactura.Count() > 0)
                {
                    this.txtProveedorID.Text = datosFactura[0];
                    this.txtProveedorNombre.Text = datosFactura[1];
                    this.txtFecFactura.Text = datosFactura[2];
                    this.txtNroFactura.Text = datosFactura[3];
                    this.txtMonedaID.Text = datosFactura[4];
                    this.txtMonedaDescrip.Text = datosFactura[5];

                    if (datosFactura[3] == VARIAS_FACTURAS)
                    {
                        this.lblFecFactura.Visible = false;
                        this.txtFecFactura.Visible = false;
                    }
                    else
                    {
                        this.lblFecFactura.Visible = true;
                        this.txtFecFactura.Visible = true;
                    }
                }
                else
                {
                    this.txtProveedorID.Text = "";
                    this.txtProveedorNombre.Text = "";
                    this.txtFecFactura.Text = "";
                    this.txtNroFactura.Text = "";
                    this.txtMonedaID.Text = "";
                    this.txtMonedaDescrip.Text = "";
                }
                
                this.txtSaldo.Text = String.Format(FORMATO_DECIMAL_BROWSE, (decimal)fPickSolicitudCab.GetValor(CAMPO_SALDO));
                this.txtMontoPago.Text = String.Format(FORMATO_DECIMAL_BROWSE, (decimal)fPickSolicitudCab.GetValor(CAMPO_SALDO));
            }

            if (this.lblVariasSolicitudes.Visible)
                this.tTBaseForm.SetToolTip(this.lblVariasSolicitudes, this.lblVariasSolicitudes.Text);

            fPickSolicitudCab.Close();
            
        }
        #endregion Documento A Pagar

        #endregion Picks

        #region Controles Locales
        private void tbbImprimir_Click_1(object sender, EventArgs e)
        {
            if (this.FormEditStatus == BROWSE)
            {
                if (this.txtPagoID.Text == "")
                {
                    MessageBox.Show("No hay nada que imprimir.",
                                    "Información",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    return;
                }

                try
                {
                    int PagoCorresponsalID = Convert.ToInt32(this.txtPagoID.Text);
                    PagoSolPagoRegExtTypeAll psa = lPagos.First(a => a.PagoCorresponsalID == PagoCorresponsalID);

                    if (psa.Anulado)
                    {
                        throw new Exception("No se puede imprimir un documento anulado.");
                    }

                    List<RepOrdenPagoxID_Result> reportDS = new List<RepOrdenPagoxID_Result>();
                    reportDS = this.DBContext.RepOrdenPagoxID(PagoCorresponsalID).ToList();

                    if (reportDS.Count == 0)
                    {
                        MessageBox.Show("No existen datos para el reporte.",
                                        "Atención Requerida",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        return;
                    }

                    int MonedaID = Convert.ToInt32(this.txtMonedaID.Text);
                    Moneda mon = this.DBContext.Moneda.First( a => a.ID == MonedaID);
                    reportDS.First().MontoLetras = GenerarNotaCredito.ObtenerMontoEnLetras(IDIOMA_ESPANOL,
                                                                                           reportDS.First().MontoPago,
                                                                                           mon);

                    ReportDataSource datasource = null;
                    datasource = new ReportDataSource("DataSet1", reportDS);

                    string path = @"Reportes\RepOrdenPago.rdlc";
                    string asuntoMail = String.Format("Orden de Pago Administrativa N° {0}", reportDS.First().PagoProveedorID);
                    string cuerpoMail = "Por favor revise el documento adjunto.";
                    string nombreArchivo = "NotadeCredito-";

                    FReportViewerBase f = new FReportViewerBase(path, datasource, this.DBContext);
                    f.FormClosed += delegate { f = null; };
                    f.Titulo = String.Format("Orden de Pago Administrativa N° {0}", reportDS.First().PagoProveedorID);
                    f.NombreArchivoAdjunto = nombreArchivo + reportDS.First().PagoProveedorID;
                    f.AsuntoMail = asuntoMail;
                    f.CuerpoMail = cuerpoMail;
                    f.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al mostrar el documento: " + Environment.NewLine + ex.Message, "Información de Error", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                }
            }

        }

        private void ucCRUDPagoPresupuesto_VisibleChanged(object sender, EventArgs e)
        {
            if (this.tabListaABM.SelectedIndex == 0)
                this.FormatearGrilla();
        }

        private void tbbAnular_Click(object sender, EventArgs e)
        {
            if (!this.lblAutorizacionVigente.Visible)
            {
                MessageBox.Show("No se puede anular el pago debido a que no posee autorización vigente.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;

            }

            if (this.txtEstado.Text == ESTADO_ANULADOVALOR)
            {
                MessageBox.Show("No se puede anular el pago debido a que ya se encuentra en ese estado.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            string message = "";
            string caption = "";
            caption = "Anulación de Pagos";
            message = "Se anulará el pago ¿Desea continuar?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(AnularDialogHandler));
        }

        protected override void dgvListadoABM_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((this.FormEditStatus == BROWSE) && (!this.IsClosing))
            {
                base.dgvListadoABM_RowEnter(sender, e);
                if (this.LastDGVIndex > -1)
                    this.CargarPago(this.dgvListadoABM.Rows[this.LastDGVIndex]);
            }
                
        }

        private void dtpFechaCheque_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaCheque.Text = this.dtpFechaCheque.Value.ToShortDateString();
        }

        private void dtpFechaRecibo_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaRecibo.Text = this.dtpFechaRecibo.Value.ToShortDateString();
        }

        private void dtpFechaNotaCredito_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaNotaCredito.Text = this.dtpFechaNotaCredito.Value.ToShortDateString();
        }
        
        private void dtpFechaPago_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaPago.Text = this.dtpFechaPago.Value.ToShortDateString();
        }

        private void dtpFechaDeposito_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaDeposito.Text = this.dtpFechaDeposito.Value.ToShortDateString();
        }

        private void tbbGuardar_Click_1(object sender, EventArgs e)
        {
            #region Validaciones

            if (this.tSBSolicitudCab.KeyMember == "")
            {
                MessageBox.Show("Debe seleccionar alguna obligación a la que imputar el pago.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (this.txtMonedaID.Text == "")
            {
                MessageBox.Show("Debe ingresar una moneda para el pago.",
                               "Información",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return;
            }

            if (this.tSBFormaPago.KeyMember == "")
            {
                MessageBox.Show("Debe ingresar una forma de pago válida.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (this.txtFechaPago.Text == "")
            {
                MessageBox.Show("Debe ingresar una fecha de pago válida.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (this.txtMontoPago.Text == "")
            {
                MessageBox.Show("Debe ingresar un monto de pago válido.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            
            if (this.tSBFormaPago.KeyMember == FORMAPAGO_CHEQUELOCAL.ToString())
            {
                if (this.tSBCuenta.KeyMember == String.Empty)
                {
                    MessageBox.Show("Debe ingresar la cuenta del cheque emitido",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                    return;
                }

                if (this.txtNroCheque.Text == String.Empty)
                {
                    MessageBox.Show("Debe ingresar el número del cheque emitido",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                    return;
                }

                if (this.txtFechaCheque.Text == String.Empty)
                {
                    MessageBox.Show("Debe ingresar la fecha del cheque emitido",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                    return;
                }
            }


            if (((this.txtFechaRecibo.Text == "") && (this.txtNroRecibo.Text != "")) ||
                ((this.txtFechaRecibo.Text != "") && (this.txtNroRecibo.Text == "")))
            {
                MessageBox.Show("Debe ingresar fecha y número de recibo.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (((this.txtFechaNotaCredito.Text == "") && (this.txtNotaCreditoNro.Text != "")) ||
               ((this.txtFechaNotaCredito.Text != "") && (this.txtNotaCreditoNro.Text == "")))
            {
               MessageBox.Show("Debe ingresar fecha y número de nota de crédito.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }


            

            //No se pueden pagar presupuestos que no estén pendientes o cuyos saldo sean iguales a 0
            //if ((this.FormEditStatus == INSERT) &&
            //    (!this.PuedePagarse(Convert.ToInt32(this.tSBSolicitudCab.KeyMember), Convert.ToDecimal(this.txtMontoPago.Text.Replace('.', ',')), this.DBContext)))
            //{
            //    MessageBox.Show("El pago no puede ser procesado, el saldo del Presupuesto es 0 (cero)," + Environment.NewLine +
            //                    "el presupuesto no se encuentra en estado Pendiente (P) " + Environment.NewLine +
            //                    "o el monto ingresado es superior al saldo del Presupuesto.",
            //                   "Información",
            //                   MessageBoxButtons.OK,
            //                   MessageBoxIcon.Information);
            //    return;
            //}



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

        private void dgvListadoABM_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.RowIndex > -1) &&
                (this.dgvListadoABM.Rows[e.RowIndex].Cells[CAMPO_AUTORIZACIONVIG].Value != null) &&
                ((bool)(this.dgvListadoABM.Rows[e.RowIndex].Cells[CAMPO_AUTORIZACIONVIG].Value)))
            {
                ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }

        private void txtNroCheque_Leave(object sender, EventArgs e)
        {
            if ((this.FormEditStatus != BROWSE)
                && (this.txtNroCheque.Text.Trim() != String.Empty) 
                && (this.txtBancoChequeID.Text.Trim() != String.Empty) 
                && (this.ExisteCheque(this.txtNroCheque.Text, Convert.ToInt32(this.txtBancoChequeID.Text))))
            {
                string messageInt = "El número de cheque está ingresando ya existe en otro pago a proveedores: " + this.txtNroCheque.Text + ".";
                string captionInt = "Advertencia";

                MessageBox.Show(messageInt,
                               captionInt,
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
            }
        }
        #endregion Controles Locales

        #region Métodos Locales

        private bool ExisteCheque(string NroCheque, int BancoChequeID)
        {
            var qry = this.DBContext.ps_pagosolicitud.Where(a => a.ps_nrocheque == NroCheque).ToList();
            return qry.Count > 0;
        }

        private string GetFilterType()
        {
            string Result = "";
            if (this.cbCampoFiltro.SelectedIndex == 0)
            {
                Result = FILTRO_FACTURA;
            }
            else if (this.cbCampoFiltro.SelectedIndex == 1)
            {
                Result = FILTRO_SOLICITUD;
            }
            else if (this.cbCampoFiltro.SelectedIndex == 2)
            {
                Result = FILTRO_PROVEEDOR;
            }
            return Result;
        }

        private bool PuedePagarse(int PresupuestoCabID, decimal MontoPago, BerkeDBEntities context)
        {
            bool Result = true;

            pc_presupuestocab pCab = context.pc_presupuestocab.FirstOrDefault(a => a.pc_presupuestocabid == PresupuestoCabID);

            if ((pCab.pc_estado != ESTADO_PENDIENTE) || (pCab.pc_saldo == 0) || (pCab.pc_saldo < MontoPago))
                Result = false;

            return Result;
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
                    //else
                        //this.EliminarRegistro();
                }
            }
        }

        private void txtMontoPago_Enter(object sender, EventArgs e)
        {
            if ((this.FormEditStatus != BROWSE) && (!this.txtMontoPago.ReadOnly))
            {
                decimal valor;
                if (decimal.TryParse(this.txtMontoPago.Text, out valor))
                    this.txtMontoPago.Text = String.Format(FORMATO_DECIMAL_EDIT, valor);
                else this.txtMontoPago.Text = "0,00";
                this.txtMontoPago.Focus();
            }
        }

        private void txtMontoPago_Leave(object sender, EventArgs e)
        {
            if ((this.FormEditStatus != BROWSE) && (!this.txtMontoPago.ReadOnly))
            {
                decimal valor;
                if (decimal.TryParse(this.txtMontoPago.Text, out valor))
                    this.txtMontoPago.Text = String.Format(FORMATO_DECIMAL_BROWSE, valor);
                else this.txtMontoPago.Text = "0,00";
                //this.txtMontoPago.Focus();
            }
        }
        #endregion Métodos Locales

        #region Método Extendidos del ParentControl
        protected override void FilterEntity(string where = "", object[] filterParams = null)
        {
            try
            {
                this.limpiarDatos();

                //var query = (from pSol in this.DBContext.ps_pagosolicitud
                //             join sxp in this.DBContext.sxp_solicitudesxpago
                //                on pSol.ps_pagosolicitudid equals sxp.sxp_pagosolicitudid into sxp_pSol
                //             from sxp in sxp_pSol.DefaultIfEmpty()
                //             join sCab in this.DBContext.spc_solicitudpagocab
                //                on sxp.sxp_solicitudpagocabid equals sCab.spc_solicitudpagocabid
                //             join mon in this.DBContext.Moneda
                //                on pSol.ps_monedaid equals mon.ID
                //             join banD in this.DBContext.ba_banco
                //                on pSol.ps_bancoid equals banD.ba_bancoid into banD_pSol
                //             from banD in banD_pSol.DefaultIfEmpty()
                //             join ctaD in this.DBContext.cb_cuentabanco
                //                on pSol.ps_cuentaid equals ctaD.cb_cuentabancoid into ctaD_pSol
                //             from ctaD in ctaD_pSol.DefaultIfEmpty()
                //             join fPag in this.DBContext.fp_formadepago
                //                on pSol.ps_formapagoid equals fPag.fp_formadepagoid
                //             join banC in this.DBContext.ba_banco
                //                on pSol.ps_bancochequeid equals banC.ba_bancoid into banC_pSol
                //             from banC in banC_pSol.DefaultIfEmpty()
                //             join ctaC in this.DBContext.cb_cuentabanco
                //                on pSol.ps_cuentachequeid equals ctaC.cb_cuentabancoid into ctaC_pSol
                //             from ctaC in ctaC_pSol.DefaultIfEmpty()
                //             join prov in this.DBContext.pr_proveedor
                //                on pSol.ps_proveedorid equals prov.pr_proveedorid into prov_pSol
                //             from prov in prov_pSol.DefaultIfEmpty()
                //             select new PagoSolPagoType
                //             {
                //                 PagoProveedorID = pSol.ps_pagosolicitudid, //ID de Pago
                //                 //SolicitudPagoCabID = pSol.ps_solpagocabid, //ID de Solicitud de Pago a Proveedor
                //                 SolicitudPagoCabID = sxp.sxp_solicitudpagocabid,
                //                 Origen = pSol.ps_docorigen,
                //                 ProveedorNombre = prov.pr_nombre,
                //                 ProveedorNroFactura = pSol.ps_proveedornrofactura,
                //                 ProveedorFecFactura = pSol.ps_proveedorfecfactura,
                //                 MonedaID = pSol.ps_monedaid,
                //                 MonedaDescrip = mon.Descripcion,
                //                 MonedaAbrev = mon.AbrevMoneda,
                //                 FechaPago = pSol.ps_fechapago,
                //                 FormaPagoID = pSol.ps_formapagoid,
                //                 FormaPagoNombre = fPag.fp_descripcion,
                //                 /*Depósito en Cuenta*/
                //                 FechaBoletaDep = pSol.ps_fechaboletadeposito,
                //                 BancoDepID = pSol.ps_bancoid,
                //                 BancoDepNombre = banD.ba_descripcion,
                //                 CtaDepID = pSol.ps_cuentaid,
                //                 CtaDepNombre = ctaD.cb_descripcion,
                //                 /*Cheque*/
                //                 FechaCheque = pSol.ps_feccheque,
                //                 BancoCheqID = pSol.ps_bancochequeid,
                //                 BancoCheqNombre = banC.ba_descripcion,
                //                 CtaCheqID = pSol.ps_cuentachequeid,
                //                 CtaCheqNombre = ctaC.cb_descripcion,
                //                 CtaCheqNro = ctaC.cb_nrocuenta,
                //                 /*Recibo*/
                //                 NroRecibo = pSol.ps_nrorecibo,
                //                 FechaRecibo = pSol.ps_fecharecibo,
                //                 /*Nota Crédito*/
                //                 NotaCreditoNro = pSol.ps_notacreditonro,
                //                 FechaNotaCredito = pSol.ps_fechanotacredito,
                //                 MontoPago = pSol.ps_montopago,
                //                 Saldo = sCab.spc_saldo,
                //                 ReferenciaPago = pSol.ps_referencia,
                //                 TieneAutorizacionVigente = this.DBContext.GetAutorizacionPorDocumentoID(TIPODOCUMENTO_PAGOSOLICITUDPAGO,
                //                                                                                              pSol.ps_pagosolicitudid,
                //                                                                                              this.UsuarioID)
                //                                                                                              .FirstOrDefault().Value
                //             });

                string filtro = where;
                lPagos.Clear();

                lPagos = (from lista in this.DBContext.GetListaPagoCorresponsales(this.UsuarioID, filtro)
                             select new PagoSolPagoRegExtTypeAll
                             {
                                 PagoCorresponsalID = lista.PagoCorresponsalID, //ID de Pago
                                 Origen = lista.Origen,
                                 CorresponsalID = lista.CorresponsalID,
                                 CorresponsalNombre = lista.CorresponsalNombre,
                                 CorresponsalNroFactura = lista.CorresponsalNroFactura,
                                 CorresponsalFecFactura = lista.CorresponsalFecFactura,
                                 MonedaID = lista.MonedaID,
                                 MonedaDescrip = lista.MonedaDescrip,
                                 MonedaAbrev = lista.MonedaAbrev,
                                 FechaPago = lista.FechaPago,
                                 FormaPagoID = lista.FormaPagoID,
                                 FormaPagoNombre = lista.FormaPagoNombre,
                                 MontoPago = lista.MontoPago,
                                 ReferenciaPago = lista.ReferenciaPago,
                                 DocumentosID = lista.DocumentosID,
                                 DocumentosInfo = lista.DocumentosInfo,
                                 TieneAutorizacionVigente = lista.TieneAutorizacionVigente,
                                 UsuarioGeneracionID = lista.UsuarioGeneracionID,
                                 UsuarioGeneracionNombre = lista.UsuarioGeneracionNombre,
                                 SaldoTotal = lista.SaldoTotal,
                                 Anulado = lista.Anulado,
                                 /*Depósito en Cuenta*/
                                 FechaBoletaDep = lista.FechaBoletaDep,
                                 BancoDepID = lista.BancoDepID,
                                 BancoDepNombre = lista.BancoDepNombre,
                                 CtaDepID = lista.CtaDepID,
                                 CtaDepNombre = lista.CtaDepNombre,
                                 /*Cheque*/
                                 FechaCheque = lista.FechaCheque,
                                 BancoCheqID = lista.BancoCheqID,
                                 BancoCheqNombre = lista.BancoCheqNombre,
                                 CtaCheqID = lista.CtaCheqID,
                                 CtaCheqNombre = lista.CtaCheqNombre,
                                 CtaCheqNro = lista.CtaCheqNro,
                                 MonedaCtaCheq = lista.MonedaCtaCheq,
                                 ChequeNro = lista.ChequeNro,
                                 /*Recibo*/
                                 NroRecibo = lista.NroRecibo,
                                 FechaRecibo = lista.FechaRecibo,
                                 /*Nota Crédito*/
                                 NotaCreditoNro = lista.NotaCreditoNro,
                                 FechaNotaCredito = lista.FechaNotaCredito,
                                 //Detalle
                                 SolicitudPagoCabID = lista.SolicitudPagoCabID, //ID de Solicitud de Pago a Proveedor
                                 Saldo = lista.Saldo
                             }).ToList();

                this.BindingSourceBase_ExportExcelGrid = lPagos;

                var query = (from item in lPagos
                             select new PagoSolPagoRegExtTypeCab
                             {
                                 //Cabecera
                                 PagoCorresponsalID = item.PagoCorresponsalID, //ID de Pago
                                 Origen = item.Origen,
                                 CorresponsalID = item.CorresponsalID,
                                 CorresponsalNombre = item.CorresponsalNombre,
                                 CorresponsalNroFactura = item.CorresponsalNroFactura,
                                 CorresponsalFecFactura = item.CorresponsalFecFactura,
                                 MonedaID = item.MonedaID,
                                 MonedaDescrip = item.MonedaDescrip,
                                 MonedaAbrev = item.MonedaAbrev,
                                 FechaPago = item.FechaPago,
                                 FormaPagoID = item.FormaPagoID,
                                 FormaPagoNombre = item.FormaPagoNombre,
                                 DocumentosID = item.DocumentosID,
                                 DocumentosInfo = item.DocumentosInfo,
                                 MontoPago = item.MontoPago,
                                 ReferenciaPago = item.ReferenciaPago,
                                 TieneAutorizacionVigente = item.TieneAutorizacionVigente,
                                 UsuarioGeneracionID = item.UsuarioGeneracionID,
                                 UsuarioGeneracionNombre = item.UsuarioGeneracionNombre,
                                 SaldoTotal = item.SaldoTotal,
                                 Anulado = item.Anulado,
                                 /*Depósito en Cuenta*/
                                 FechaBoletaDep = item.FechaBoletaDep,
                                 BancoDepID = item.BancoDepID,
                                 BancoDepNombre = item.BancoDepNombre,
                                 CtaDepID = item.CtaDepID,
                                 CtaDepNombre = item.CtaDepNombre,
                                 /*Cheque*/
                                 FechaCheque = item.FechaCheque,
                                 BancoCheqID = item.BancoCheqID,
                                 BancoCheqNombre = item.BancoCheqNombre,
                                 CtaCheqID = item.CtaCheqID,
                                 CtaCheqNombre = item.CtaCheqNombre,
                                 CtaCheqNro = item.CtaCheqNro,
                                 MonedaCtaCheq = item.MonedaCtaCheq,
                                 ChequeNro = item.ChequeNro,
                                 /*Recibo*/
                                 NroRecibo = item.NroRecibo,
                                 FechaRecibo = item.FechaRecibo,
                                 /*Nota Crédito*/
                                 NotaCreditoNro = item.NotaCreditoNro,
                                 FechaNotaCredito = item.FechaNotaCredito,
                             })
                         .GroupBy(x => new { x.PagoCorresponsalID }).Select(g => g.First()).ToList();

                this.BindingSourceBase = query;

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

            this.dgvListadoABM.Columns[CAMPO_FECHAPAGO].HeaderText = "Fecha Pago";
            this.dgvListadoABM.Columns[CAMPO_FECHAPAGO].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_FECHAPAGO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_FECHAPAGO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_FECHAPAGO].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_PAGOCORRESPONSALID].HeaderText = "Pago ID";
            this.dgvListadoABM.Columns[CAMPO_PAGOCORRESPONSALID].Width = 60;
            this.dgvListadoABM.Columns[CAMPO_PAGOCORRESPONSALID].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_PAGOCORRESPONSALID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_PAGOCORRESPONSALID].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_CORRESPONSALNROFACTURA].HeaderText = "N° Factura";
            this.dgvListadoABM.Columns[CAMPO_CORRESPONSALNROFACTURA].Width = 100;
            this.dgvListadoABM.Columns[CAMPO_CORRESPONSALNROFACTURA].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_CORRESPONSALNROFACTURA].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_CORRESPONSALNOMBRE].HeaderText = "Corresponsal";
            this.dgvListadoABM.Columns[CAMPO_CORRESPONSALNOMBRE].Width = 200;
            this.dgvListadoABM.Columns[CAMPO_CORRESPONSALNOMBRE].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_CORRESPONSALNOMBRE].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_MONEDAABREV].HeaderText = "Moneda";
            this.dgvListadoABM.Columns[CAMPO_MONEDAABREV].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_MONEDAABREV].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_MONEDAABREV].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_MONTOPAGO].HeaderText = "Monto";
            this.dgvListadoABM.Columns[CAMPO_MONTOPAGO].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_MONTOPAGO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_MONTOPAGO].DefaultCellStyle.Format = "N2";
            this.dgvListadoABM.Columns[CAMPO_MONTOPAGO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_MONTOPAGO].Visible = true;
            displayIndex++;

            DataGridViewCheckBoxColumn colAnulado = new DataGridViewCheckBoxColumn();
            colAnulado.DataPropertyName = CAMPO_ANULADO;
            colAnulado.Name = CAMPO_ANULADO;
            colAnulado.HeaderText = "Anulado";
            colAnulado.FalseValue = false;
            colAnulado.TrueValue = true;
            colAnulado.ReadOnly = true;
            this.dgvListadoABM.Columns.Insert(displayIndex, colAnulado);
        }

        protected override void tbbNuevo_Click(object sender, EventArgs e)
        {
            base.tbbNuevo_Click(sender, e);
            this.limpiarDatos();
            this.dtpFechaPago.Value = System.DateTime.Now;
            this.txtFechaPago.Text = System.DateTime.Now.ToShortDateString();
            this.txtMontoPago.Text = "0,00";
            this.txtSaldo.Text = "0,00";
            this.txtFechaPago.Focus();
        }

        protected override void tbbEditar_Click(object sender, EventArgs e)
        {
            //if ((Convert.ToInt32(this.tSBFormaPago.KeyMember) == FORMAPAGO_NOTACREDITOPRESUPUESTO)
            //    && (this.ExisteNotaCredito()))
            //{
            //    MessageBox.Show("No se puede editar el pago debido a que existe una nota de crédito asociada.",
            //                    "Información",
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Information);
            //    return;
            //}

            if (this.txtEstado.Text == CAMPO_ANULADO)
            {
                MessageBox.Show("No se puede editar el pago debido a que se encuentra anulado.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }
            base.tbbEditar_Click(sender, e);          
            this.txtFechaRecibo.Focus();
        }

        protected override void tbbCancelar_Click(object sender, EventArgs e)
        {
            base.tbbCancelar_Click(sender, e);
            fSelSolxProv = null;

            if (this.LastDGVIndex > -1)
            {
                this.CargarPago(this.dgvListadoABM.Rows[this.LastDGVIndex]);
            }
            else
            {
                this.limpiarDatos();
            }
        }

        #endregion Método Extendidos del ParentControl

        #region ReadOnly condicional
        protected override void Editable(bool editar)
        {
            if (this.FormEditStatus == EDIT)
            {
                this.txtFechaPago.ReadOnly = true;
                this.tSBSolicitudCab.Editable = false;
                this.tSBFormaPago.Editable = false;
                this.tSBMoneda.Editable = false;
                this.txtMontoPago.ReadOnly = true;

                this.txtGastoBancario.ReadOnly = true;
                this.txtReferencia.ReadOnly = true;
                this.txtFechaDeposito.ReadOnly = true;
                this.tSBBancoDeposito.Editable = false;
                this.tSBCuentaDeposito.Editable = false;

                this.tSBCuenta.Editable = false;
                this.txtNroCheque.ReadOnly = true;
                this.txtFechaCheque.ReadOnly = true;
                this.dtpFechaCheque.Enabled = false;
                this.dtpFechaPago.Enabled = false;
                this.dtpFechaDeposito.Enabled = false;
                
                this.txtFechaRecibo.ReadOnly = false;
                this.dtpFechaRecibo.Enabled = true;
                this.txtNroRecibo.ReadOnly = false;
                this.txtFechaNotaCredito.ReadOnly = true;
                this.txtFechaNotaCredito.BackColor = SystemColors.Window;
                this.dtpFechaNotaCredito.Enabled = false;
                this.txtNotaCreditoNro.ReadOnly = true;
                this.txtNotaCreditoNro.BackColor = SystemColors.Window;

                this.cbCampoFiltro.Enabled = false;
            }
            else
            {
                this.txtFechaPago.ReadOnly = editar;
                this.tSBFormaPago.Editable = !editar;
                this.tSBMoneda.Editable = !editar;

                this.txtMontoPago.ReadOnly = editar;

                this.txtGastoBancario.ReadOnly = editar;
                this.txtReferencia.ReadOnly = editar;
                this.txtFechaDeposito.ReadOnly = editar;
                this.tSBBancoDeposito.Editable = !editar;
                this.tSBCuentaDeposito.Editable = !editar;
                //this.tSBBancoCheque.Editable = !editar;
                this.tSBCuenta.Editable = !editar;
                this.txtNroCheque.ReadOnly = editar;
                this.txtFechaCheque.ReadOnly = editar;
                this.dtpFechaCheque.Enabled = !editar;
                this.dtpFechaPago.Enabled = !editar;
                this.dtpFechaDeposito.Enabled = !editar;
                this.tSBSolicitudCab.Editable = !editar;
                this.txtFechaRecibo.ReadOnly = editar;
                this.dtpFechaRecibo.Enabled = !editar;
                this.txtNroRecibo.ReadOnly = editar;
                this.txtFechaNotaCredito.ReadOnly = editar;
                this.txtFechaNotaCredito.BackColor = SystemColors.Window;
                this.dtpFechaNotaCredito.Enabled = !editar;
                this.txtNotaCreditoNro.ReadOnly = editar;
                this.txtNotaCreditoNro.BackColor = SystemColors.Window;

                this.cbCampoFiltro.Enabled = !editar;

                

            }
            this.tbbAnular.Enabled = this.FormEditStatus == BROWSE;
            this.tbbActualizar.Enabled = this.FormEditStatus == BROWSE;
            this.tbbExportarExcel.Enabled = this.FormEditStatus == BROWSE;
            
        }
        #endregion ReadOnly condicional

        #region Limpiar Datos
        private void limpiarDatos()
        {
            this.txtPagoID.Text = "";
            this.txtIDPagoMultiple.Text = "";
            //this.txtSolPagoCabID.Text = "";
            this.txtNroPresupuesto.Text = "";
            this.txtNroFactura.Text = "";
            this.txtFecFactura.Text = "";
            this.txtFechaPago.Text = "";
            this.tSBFormaPago.Clear();
            this.tSBMoneda.Clear();
            this.txtMontoPago.Text = "";
            this.txtGastoBancario.Text = "";
            this.txtReferencia.Text = "";
            this.txtFechaDeposito.Text = "";
            this.tSBBancoDeposito.Clear();
            this.tSBCuentaDeposito.Clear();
            //this.tSBBancoCheque.Clear();
            this.tSBCuenta.Clear();
            this.txtNroCuenta.Text = "";
            this.txtMoneda.Text = "";
            this.txtBanco.Text = "";
            this.txtBancoChequeID.Text = "";
            this.txtNroCheque.Text = "";
            this.txtFechaCheque.Text = "";
            this.txtFechaRecibo.Text = "";
            this.txtFechaNotaCredito.Text = "";
            this.txtNroRecibo.Text = "";
            this.txtNotaCreditoNro.Text = "";
            this.tSBSolicitudCab.Clear();
            this.txtProveedorID.Text = "";
            this.txtProveedorNombre.Text = "";
            this.txtEstado.Text = "";
            this.txtSaldo.Text = "";
            this.txtMonedaID.Text = "";
            this.txtMonedaDescrip.Text = "";
            this.txtGeneradoPorID.Text = "";
            this.txtGeneradoPorNombre.Text = "";
            this.lblAutorizacionVigente.Visible = false;
            this.txtNotaCreditoNro.Visible = true;

            this.txtProveedorNombre.Visible = true;
            this.txtProveedorID.Size = new Size(WIDTH_70, this.txtProveedorID.Size.Height);
            this.lblFecFactura.Visible = true;
            this.txtFecFactura.Visible = true;

            //this.btnVerFacturas.Visible = false;
            //this.btnVerProveedores.Visible = false;

            this.cbCampoFiltro.SelectedIndex = -1;
            this.lblVariasSolicitudes.Visible = false;     
        }

        private void limpiarDatosFiltro()
        {
            this.tSBSolicitudCab.Clear();
            this.txtNroFactura.Text = "";
            //this.btnVerFacturas.Visible = false;
            this.lblFecFactura.Visible = true;
            this.txtFecFactura.Visible = true;
            this.txtProveedorNombre.Visible = true;
            this.txtProveedorID.Size = new Size(WIDTH_70, this.txtProveedorID.Size.Height);
            //this.btnVerProveedores.Visible = false;
            this.txtMonedaID.Text = "";
            this.txtMonedaDescrip.Text = "";
            this.tSBFormaPago.Clear();
            this.txtMontoPago.Text = "";
            this.txtSaldo.Text = "";
            this.txtReferencia.Text = "";
            this.lblVariasSolicitudes.Visible = false;
        }

        #endregion Limpiar Datos

        #region CRUD
        
        private void CargarPago(DataGridViewRow row)
        {
            this.limpiarDatos();

            #region Datos Generales
            this.txtPagoID.Text = row.Cells[CAMPO_PAGOCORRESPONSALID].Value.ToString();
            this.txtFechaPago.Text = Convert.ToDateTime(row.Cells[CAMPO_FECHAPAGO].Value.ToString()).ToShortDateString();

            if (row.Cells[CAMPO_ORIGEN].Value.ToString() == FILTRO_FACTURA)
                this.cbCampoFiltro.SelectedIndex = 0;
            else if (row.Cells[CAMPO_ORIGEN].Value.ToString() == FILTRO_SOLICITUD)
                this.cbCampoFiltro.SelectedIndex = 1;
            else if (row.Cells[CAMPO_ORIGEN].Value.ToString() == FILTRO_PROVEEDOR)
                this.cbCampoFiltro.SelectedIndex = 2;


            this.tSBSolicitudCab.KeyMember = row.Cells[CAMPO_DOCUMENTOSID].Value != null ? row.Cells[CAMPO_DOCUMENTOSID].Value.ToString() : String.Empty;
            this.tSBSolicitudCab.DisplayMember = row.Cells[CAMPO_DOCUMENTOSINFO].Value != null ? row.Cells[CAMPO_DOCUMENTOSINFO].Value.ToString() : String.Empty;

            this.txtNroFactura.Text = row.Cells[CAMPO_CORRESPONSALNROFACTURA].Value != null ? row.Cells[CAMPO_CORRESPONSALNROFACTURA].Value.ToString() : "";
            this.txtFecFactura.Text = row.Cells[CAMPO_CORRESPONSALFECFACTURA].Value != null
                                        ? Convert.ToDateTime(row.Cells[CAMPO_CORRESPONSALFECFACTURA].Value).ToShortDateString() : "";

            if (this.txtNroFactura.Text == VARIAS_FACTURAS)
            {
                this.txtFecFactura.Visible = false;
                this.lblFecFactura.Visible = false;
            }
            else
            {
                this.txtFecFactura.Visible = true;
                this.lblFecFactura.Visible = true;
            }

            if (row.Cells[CAMPO_CORRESPONSALNOMBRE].Value != null)
            {
                if (row.Cells[CAMPO_CORRESPONSALNOMBRE].Value.ToString() == VARIOS_PROVEEDORES)
                {
                    this.txtProveedorID.Text = VARIOS_PROVEEDORES;
                    this.txtProveedorID.Size = new Size(WIDTH_113, this.txtProveedorID.Size.Height);
                    this.txtProveedorNombre.Text = "";
                    this.txtProveedorNombre.Visible = false;
                }
                else
                {
                    this.txtProveedorID.Text = row.Cells[CAMPO_CORRESPONSALID].Value.ToString();
                    this.txtProveedorNombre.Text = row.Cells[CAMPO_CORRESPONSALNOMBRE].Value.ToString();
                }
            }
            else
            {
                this.txtProveedorID.Text = String.Empty;
                this.txtProveedorNombre.Text = String.Empty;
            }
            
            //this.txtProveedorID.Text = row.Cells[CAMPO_PROVEEDORID].Value != null ? row.Cells[CAMPO_PROVEEDORID].Value.ToString() : "";
            //this.txtProveedorNombre.Text = row.Cells[CAMPO_PROVEEDORNOMBRE].Value != null ? row.Cells[CAMPO_PROVEEDORNOMBRE].Value.ToString() : "";
            this.txtMonedaID.Text = row.Cells[CAMPO_MONEDAID].Value.ToString();
            this.txtMonedaDescrip.Text = row.Cells[CAMPO_MONEDADESCRIP].Value.ToString();
            this.tSBFormaPago.KeyMember = row.Cells[CAMPO_FORMAPAGOID].Value.ToString();
            this.tSBFormaPago.DisplayMember = row.Cells[CAMPO_FORMAPAGONOMBRE].Value.ToString();
            this.txtMontoPago.Text = String.Format(FORMATO_DECIMAL_BROWSE, (decimal)row.Cells[CAMPO_MONTOPAGO].Value);
            this.txtSaldo.Text = row.Cells[CAMPO_SALDOTOTAL].Value != null ? String.Format(FORMATO_DECIMAL_BROWSE, (decimal)row.Cells[CAMPO_SALDOTOTAL].Value) : "0,00";
            this.txtReferencia.Text = row.Cells[CAMPO_REFERENCIAPAGO].Value != null ? row.Cells[CAMPO_REFERENCIAPAGO].Value.ToString() : "";
            this.txtGeneradoPorID.Text = row.Cells[CAMPO_USUARIOGENID].Value.ToString();
            this.txtGeneradoPorNombre.Text = row.Cells[CAMPO_USUARIOGENNOMBRE].Value.ToString();
            this.txtEstado.Text = !(bool)row.Cells[CAMPO_ANULADO].Value ? "Activo" : "Anulado";
            this.lblAutorizacionVigente.Visible = (bool)row.Cells[CAMPO_AUTORIZACIONVIG].Value;
            
            
            #endregion Datos Generales

            #region Transferencia
            this.txtFechaDeposito.Text = row.Cells[CAMPO_FECHABOLETADEP].Value != null
                                            ? Convert.ToDateTime(row.Cells[CAMPO_FECHABOLETADEP].Value.ToString()).ToShortDateString()
                                            : "";

            if (row.Cells[CAMPO_BANCODEPID].Value != null)
            {
                this.tSBBancoDeposito.KeyMember = row.Cells[CAMPO_BANCODEPID].Value.ToString();
                this.tSBBancoDeposito.DisplayMember = row.Cells[CAMPO_BANCODEPNOMBRE].Value.ToString();
            }

            if (row.Cells[CAMPO_CTADEPID].Value != null)
            {
                this.tSBCuentaDeposito.KeyMember = row.Cells[CAMPO_CTADEPID].Value.ToString();
                this.tSBCuentaDeposito.DisplayMember = row.Cells[CAMPO_CTADEPNOMBRE].Value.ToString();
            }
            #endregion Transferencia

            #region Cheque
            if (row.Cells[CAMPO_CTACHEQID].Value != null)
            {
                this.tSBCuenta.KeyMember = row.Cells[CAMPO_CTACHEQID].Value.ToString();
                this.tSBCuenta.DisplayMember = row.Cells[CAMPO_CTACHEQNOMBRE].Value.ToString();
            }
            this.txtNroCheque.Text = row.Cells[CAMPO_CHEQUENRO].Value != null ? row.Cells[CAMPO_CHEQUENRO].Value.ToString() : "";
            this.txtFechaCheque.Text = row.Cells[CAMPO_FECHACHEQUE].Value != null ? Convert.ToDateTime(row.Cells[CAMPO_FECHACHEQUE].Value).ToShortDateString() : "";
            //Moneda Cuenta Cheque
            this.txtMoneda.Text = row.Cells[CAMPO_MONEDACTACHEQ].Value != null ? row.Cells[CAMPO_MONEDACTACHEQ].Value.ToString() : "";
            //ID Banco Cheque
            this.txtBancoChequeID.Text = row.Cells[CAMPO_BANCOCHEQID].Value != null ? row.Cells[CAMPO_BANCOCHEQID].Value.ToString() : "";
            //ID Banco Cheque Nombre
            this.txtBanco.Text = row.Cells[CAMPO_BANCOCHEQNOMBRE].Value != null ? row.Cells[CAMPO_BANCOCHEQNOMBRE].Value.ToString() : "";
            this.txtNroCuenta.Text = row.Cells[CAMPO_CTACHEQNRO].Value != null ? row.Cells[CAMPO_CTACHEQNRO].Value.ToString() : "";
            #endregion Cheque

            #region Gasto Bancario
            //if (row.Cells[CAMPO_MONEDAGASTOID].Value != null)
            //{
            //    this.tSBMoneda.KeyMember = row.Cells[CAMPO_MONEDAGASTOID].Value.ToString();
            //    this.tSBMoneda.DisplayMember = row.Cells[CAMPO_MONEDAGASTODESCRIP].Value.ToString();

            //}

            //if (row.Cells[CAMPO_GASTOCAMBIARIO].Value != null)
            //{
            //    this.txtGastoBancario.Text = Convert.ToInt32(row.Cells[CAMPO_GASTOCAMBIARIO].Value) > 0
            //                                    ? row.Cells[CAMPO_GASTOCAMBIARIO].Value.ToString()
            //                                    : "";
            //}
            #endregion Gasto Bancario

            #region Recibo
            this.txtFechaRecibo.Text = row.Cells[CAMPO_FECHARECIBO].Value != null ? Convert.ToDateTime(row.Cells[CAMPO_FECHARECIBO].Value.ToString()).ToShortDateString() : "";
            this.txtNroRecibo.Text = row.Cells[CAMPO_NRORECIBO].Value != null ? row.Cells[CAMPO_NRORECIBO].Value.ToString() : "";
            #endregion Recibo

            #region Nota Crédito
            this.txtFechaNotaCredito.Text = row.Cells[CAMPO_FECHANOTACREDITO].Value != null ? Convert.ToDateTime(row.Cells[CAMPO_FECHANOTACREDITO].Value.ToString()).ToShortDateString() : "";
            this.txtNotaCreditoNro.Text = row.Cells[CAMPO_NOTACREDITONRO].Value != null ? row.Cells[CAMPO_NOTACREDITONRO].Value.ToString() : "";
            #endregion Nota Crédito
        }

        private void GuardarRegistro()
        {
            bool success = false;

            ps_pagosolicitud ps = null;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        ps = this.guardarPago(context);
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
                    this.FilterEntity(CAMPO_PAGOCORRESPONSALID + " = " + ps.ps_pagosolicitudid.ToString(), null);
                else if (this.FormEditStatus == EDIT)
                    this.FilterEntity(this.WhereString, this.FilterParam);

                this.FormEditStatus = BROWSE;
                this.CargarPago(this.dgvListadoABM.Rows[this.LastDGVIndex]);

                MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region Métodos de Edición de Datos

        private void ucCRUDPagoSolPago_CRUDEvent(object sender, EventArgs e)
        {
            ps_pagosolicitud ps = new ps_pagosolicitud();

            //ps.ps_pagosolicitudid = this.FormEditStatus != INSERT ? Convert.ToInt32(this.txtPagoID.Text) : 0;
            if (this.FormEditStatus == INSERT)
            {
                ps.ps_pagosolicitudid = 0;

                #region Datos Generales
                ps.ps_docorigen = this.GetFilterType();
                ps.ps_formapagoid = Convert.ToInt32(this.tSBFormaPago.KeyMember);
                ps.ps_fechapago = Convert.ToDateTime(this.txtFechaPago.Text);
                ps.ps_proveedornrofactura = this.txtNroFactura.Text != null ? this.txtNroFactura.Text : null;
                //ps.ps_montopago = Convert.ToDecimal(this.txtMontoPago.Text.Replace('.', ','));
                ps.ps_montopago = Convert.ToDecimal(this.txtMontoPago.Text);
                ps.ps_referencia = this.txtReferencia.Text != "" ? this.txtReferencia.Text : null;

                if (this.txtProveedorID.Text != String.Empty)
                {
                    if (this.txtProveedorID.Text == VARIOS_PROVEEDORES)
                    {
                        ps.ps_nombreproveedor = VARIOS_PROVEEDORES;
                        ps.ps_proveedorid = null;
                        ps.ps_corresponsalid = null;
                    }
                    else
                    {
                        ps.ps_proveedorid = null;
                        ps.ps_corresponsalid = Convert.ToInt32(this.txtProveedorID.Text);
                    }
                }
                else ps.ps_proveedorid = null;

                if (this.txtFecFactura.Text != "")
                {
                    ps.ps_proveedorfecfactura = Convert.ToDateTime(this.txtFecFactura.Text);
                }
                else ps.ps_proveedorfecfactura = null;

                ps.ps_monedaid = Convert.ToInt32(this.txtMonedaID.Text);
                #endregion Datos Generales

                #region Transferencia
                if (this.txtFechaDeposito.Text != "")
                    ps.ps_fechaboletadeposito = Convert.ToDateTime(this.txtFechaDeposito.Text);
                else ps.ps_fechaboletadeposito = null;

                if (this.tSBBancoDeposito.KeyMember != "")
                {
                    ps.ps_bancoid = Convert.ToInt32(this.tSBBancoDeposito.KeyMember);
                }
                else
                {
                    ps.ps_bancoid = null;
                }

                if (this.tSBCuentaDeposito.KeyMember != "")
                {
                    ps.ps_cuentaid = Convert.ToInt32(this.tSBCuentaDeposito.KeyMember);
                }
                else
                {
                    ps.ps_cuentaid = null;
                }
                #endregion Depósito en Banco

                #region Pago con Cheque
                ps.ps_nrocheque = this.txtNroCheque.Text != "" ? this.txtNroCheque.Text : null;

                if (this.txtFechaCheque.Text != "")
                {
                    ps.ps_feccheque = Convert.ToDateTime(this.txtFechaCheque.Text);
                }
                else ps.ps_feccheque = null;

                if (this.txtBancoChequeID.Text != "")
                {
                    ps.ps_bancochequeid = Convert.ToInt32(this.txtBancoChequeID.Text);
                }
                else ps.ps_bancochequeid = null;

                if (this.tSBCuenta.KeyMember != "")
                {
                    ps.ps_cuentachequeid = Convert.ToInt32(this.tSBCuenta.KeyMember);
                }
                else ps.ps_cuentachequeid = null;

                #endregion Pago con Cheque

                #region Gasto Bancario
                //if (this.txtGastoBancario.Text != "")
                //{
                //    ps.ps_gastocambiario = Convert.ToDecimal(this.txtGastoBancario.Text.Replace('.', ','));
                //}
                //else ps.ps_gastocambiario = null;

                //if (this.tSBMoneda.KeyMember != "")
                //{
                //    ps.ps_monedagastoid = Convert.ToInt32(this.tSBMoneda.KeyMember);
                //}
                //else
                //{
                //    ps.ps_monedagastoid = null;
                //}
                #endregion Gasto Bancario

                #region Recibo
                if (this.txtFechaRecibo.Text != "")
                {
                    ps.ps_fecharecibo = Convert.ToDateTime(this.txtFechaRecibo.Text);
                    ps.ps_nrorecibo = this.txtNroRecibo.Text != "" ? this.txtNroRecibo.Text : null;
                }
                else
                {
                    ps.ps_fecharecibo = null;
                    ps.ps_nrorecibo = null;
                }
                #endregion Recibo

                #region Nota Crédito
                if (this.txtFechaNotaCredito.Text != "")
                {
                    ps.ps_fechanotacredito = Convert.ToDateTime(this.txtFechaNotaCredito.Text);
                    ps.ps_notacreditonro = this.txtNotaCreditoNro.Text != "" ? this.txtNotaCreditoNro.Text : null;
                }
                else
                {
                    ps.ps_fechanotacredito = null;
                    ps.ps_notacreditonro = null;
                }
                #endregion Nota Crédito
            }
            else if (this.FormEditStatus == EDIT)
            {
                int pagoID = Convert.ToInt32(this.txtPagoID.Text);

                ps = this.DBContext.ps_pagosolicitud.First(a => a.ps_pagosolicitudid == pagoID);

                #region Recibo
                if (this.txtFechaRecibo.Text != "")
                {
                    ps.ps_fecharecibo = Convert.ToDateTime(this.txtFechaRecibo.Text);
                    ps.ps_nrorecibo = this.txtNroRecibo.Text != "" ? this.txtNroRecibo.Text : null;
                }
                else
                {
                    ps.ps_fecharecibo = null;
                    ps.ps_nrorecibo = null;
                }
                #endregion Recibo
            }

            bool exito = false;

            if (this.FormEditStatus != BROWSE)
            {
                List<sxp_solicitudesxpago> detalles = this.GetListaSolicitudesXPago(ps.ps_pagosolicitudid);
                ps = this.GuardarRegistro<ps_pagosolicitud, sxp_solicitudesxpago>(ps, 
                                                                                  detalles, 
                                                                                  CAMPO_PAGOSOLICITUDPK_TABLA, 
                                                                                  CAMPO_PAGOSOLICITUDFK_TABLA);
            }
            else
                exito = this.EliminarRegistro<ps_pagosolicitud>(ps);

            if ((ps != null) || (exito))
            {
                int index = 0;
                if (this.FormEditStatus == INSERT)
                {
                    this.FilterEntity("", null);
                    this.CargarPago(this.dgvListadoABM.Rows[0]);
                }
                else if ((this.FormEditStatus == EDIT) || (this.FormEditStatus == BROWSE))
                {
                    this.FilterEntity(this.WhereString, this.FilterParam);
                    this.CargarPago(this.dgvListadoABM.Rows[this.LastDGVIndex]);
                    index = this.LastDGVIndex;
                }

                this.FormEditStatus = BROWSE;
                this.dgvListadoABM.CurrentCell = this.dgvListadoABM.Rows[index].Cells[0];
                this.dgvListadoABM.CurrentCell.Selected = true;


                MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ucCRUDPagoSolPago_ValidarCamposEvent(object sender, EventArgs e)
        {
            #region Validaciones

            if (this.tSBSolicitudCab.KeyMember == "")
            {
                MessageBox.Show("Debe seleccionar alguna obligación a la que imputar el pago.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (this.txtMonedaID.Text == "")
            {
                MessageBox.Show("Debe ingresar una moneda para el pago.",
                               "Información",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return;
            }

            if (this.tSBFormaPago.KeyMember == "")
            {
                MessageBox.Show("Debe ingresar una forma de pago válida.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (this.txtFechaPago.Text == "")
            {
                MessageBox.Show("Debe ingresar una fecha de pago válida.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (this.txtMontoPago.Text == "")
            {
                MessageBox.Show("Debe ingresar un monto de pago válido.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (this.tSBFormaPago.KeyMember == FORMAPAGO_CHEQUELOCAL.ToString())
            {
                if (this.tSBCuenta.KeyMember == String.Empty)
                {
                    MessageBox.Show("Debe ingresar la cuenta del cheque emitido",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                    return;
                }

                if (this.txtNroCheque.Text == String.Empty)
                {
                    MessageBox.Show("Debe ingresar el número del cheque emitido",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                    return;
                }

                if (this.txtFechaCheque.Text == String.Empty)
                {
                    MessageBox.Show("Debe ingresar la fecha del cheque emitido",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                    return;
                }
            }

            if (((this.txtFechaRecibo.Text == "") && (this.txtNroRecibo.Text != "")) ||
                ((this.txtFechaRecibo.Text != "") && (this.txtNroRecibo.Text == "")))
            {
                MessageBox.Show("Debe ingresar fecha y número de recibo.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (((this.txtFechaNotaCredito.Text == "") && (this.txtNotaCreditoNro.Text != "")) ||
               ((this.txtFechaNotaCredito.Text != "") && (this.txtNotaCreditoNro.Text == "")))
            {
                MessageBox.Show("Debe ingresar fecha y número de nota de crédito.",
                                 "Información",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                return;
            }

            #region Validar que monto pagado sea total para solicitudes con varios proveedores
            //if ((this.txtProveedorID.Text != VARIOS_PROVEEDORES) && (this.GetFilterType() == FILTRO_FACTURA))
            //{
            //    int provID = Convert.ToInt32(this.txtProveedorID.Text);
            //    foreach (string solCabIDStr in this.tSBSolicitudCab.KeyMember.Split(','))
            //    {
            //        int solCabID = Convert.ToInt32(solCabIDStr);
            //        var qry = (from spd in this.DBContext.spd_solicitudpagodet
            //                   where spd.spd_solicitudpagocabid == solCabID
            //                   group spd by spd.spd_solicitudpagocabid into g
            //                   select new { SolicitudCabID = g.Key, ProvCnt = g.Count() }).ToList(); ;

            //        if (qry.First().ProvCnt > 1)
            //        {
            //            var qry1 = (from spd in this.DBContext.spd_solicitudpagodet
            //                        where spd.spd_solicitudpagocabid == solCabID && spd.spd_proveedorid == provID
            //                        group spd by new { spd.spd_solicitudpagocabid, spd.spd_proveedorid,  } into g
            //                        select new { SolicitudCabID = g.Key.spd_solicitudpagocabid, ProveedorID = g.Key.spd_proveedorid, TotalFactura = g.Sum(a => a.spd_total) }).ToList();

            //            decimal saldoSolProv = 0;

            //            if ((Convert.ToDecimal(this.txtMontoPago.Text) < saldoSolProv))
            //            {
            //                MessageBox.Show("No se puede realizar pago parcial de la factura debido a " + Environment.NewLine +
            //                                "que la solicitu de pago N° " + qry.First().SolicitudCabID.ToString() + " cuenta" + Environment.NewLine +
            //                                "con facturas de varios proveedores asociados.",
            //                             "Información",
            //                             MessageBoxButtons.OK,
            //                             MessageBoxIcon.Information);
            //                return;
            //            }
            //        }

            //    }
            //}
            #endregion Validar que monto pagado sea total para solicitudes con varios proveedores

            this.ValidOK = true;


            //No se pueden pagar presupuestos que no estén pendientes o cuyos saldo sean iguales a 0
            //if ((this.FormEditStatus == INSERT) &&
            //    (!this.PuedePagarse(Convert.ToInt32(this.tSBSolicitudCab.KeyMember), Convert.ToDecimal(this.txtMontoPago.Text.Replace('.', ',')), this.DBContext)))
            //{
            //    MessageBox.Show("El pago no puede ser procesado, el saldo del Presupuesto es 0 (cero)," + Environment.NewLine +
            //                    "el presupuesto no se encuentra en estado Pendiente (P) " + Environment.NewLine +
            //                    "o el monto ingresado es superior al saldo del Presupuesto.",
            //                   "Información",
            //                   MessageBoxButtons.OK,
            //                   MessageBoxIcon.Information);
            //    return;
            //}



            #endregion Validaciones
        }

        private ps_pagosolicitud guardarPago(BerkeDBEntities context = null)
        {
            ps_pagosolicitud ps = new ps_pagosolicitud();

            #region EDIT
            if (this.FormEditStatus == EDIT)
            {
                int pagoProveedorID = Convert.ToInt32(this.txtPagoID.Text);

                ps = context.ps_pagosolicitud.First(a => a.ps_pagosolicitudid == pagoProveedorID);
                                
                #region Recibo
                if (this.txtFechaRecibo.Text != "")
                {
                    ps.ps_fecharecibo = Convert.ToDateTime(this.txtFechaRecibo.Text);
                    ps.ps_nrorecibo = this.txtNroRecibo.Text != "" ? this.txtNroRecibo.Text : null;
                }
                else
                {
                    ps.ps_fecharecibo = null;
                    ps.ps_nrorecibo = null;
                }
                #endregion Recibo
                
            }
            #endregion EDIT

            #region INSERT
            else if (this.FormEditStatus == INSERT)
            {
                #region Datos Generales
                ps.ps_docorigen = this.GetFilterType();
                ps.ps_formapagoid = Convert.ToInt32(this.tSBFormaPago.KeyMember);
                ps.ps_fechapago = Convert.ToDateTime(this.txtFechaPago.Text);
                ps.ps_proveedornrofactura = this.txtNroFactura.Text != null ? this.txtNroFactura.Text : null;
                //ps.ps_montopago = Convert.ToDecimal(this.txtMontoPago.Text.Replace('.', ','));
                ps.ps_montopago = Convert.ToDecimal(this.txtMontoPago.Text);
                ps.ps_referencia = this.txtReferencia.Text != "" ? this.txtReferencia.Text : null;

                if (this.txtProveedorID.Text != "")
                {
                    ps.ps_proveedorid = Convert.ToInt32(this.txtProveedorID.Text);
                }
                else ps.ps_proveedorid = null;

                if (this.txtFecFactura.Text != "")
                {
                    ps.ps_proveedorfecfactura = Convert.ToDateTime(this.txtFecFactura.Text);
                }
                else ps.ps_proveedorfecfactura = null;

                ps.ps_monedaid = Convert.ToInt32(this.txtMonedaID.Text);
                #endregion Datos Generales

                #region Transferencia
                if (this.txtFechaDeposito.Text != "")
                    ps.ps_fechaboletadeposito = Convert.ToDateTime(this.txtFechaDeposito.Text);
                else ps.ps_fechaboletadeposito = null;

                if (this.tSBBancoDeposito.KeyMember != "")
                {
                    ps.ps_bancoid = Convert.ToInt32(this.tSBBancoDeposito.KeyMember);
                }
                else
                {
                    ps.ps_bancoid = null;
                }

                if (this.tSBCuentaDeposito.KeyMember != "")
                {
                    ps.ps_cuentaid = Convert.ToInt32(this.tSBCuentaDeposito.KeyMember);
                }
                else
                {
                    ps.ps_cuentaid = null;
                }
                #endregion Depósito en Banco

                #region Pago con Cheque
                ps.ps_nrocheque = this.txtNroCheque.Text != "" ? this.txtNroCheque.Text : null;

                if (this.txtFechaCheque.Text != "")
                {
                    ps.ps_feccheque = Convert.ToDateTime(this.txtFechaCheque.Text);
                }
                else ps.ps_feccheque = null;

                if (this.txtBancoChequeID.Text != "")
                {
                    ps.ps_bancochequeid = Convert.ToInt32(this.txtBancoChequeID.Text);
                }
                else ps.ps_bancochequeid = null;

                if (this.tSBCuenta.KeyMember != "")
                {
                    ps.ps_cuentachequeid = Convert.ToInt32(this.tSBCuenta.KeyMember);
                }
                else ps.ps_cuentachequeid = null;

                #endregion Pago con Cheque

                #region Gasto Bancario
                //if (this.txtGastoBancario.Text != "")
                //{
                //    ps.ps_gastocambiario = Convert.ToDecimal(this.txtGastoBancario.Text.Replace('.', ','));
                //}
                //else ps.ps_gastocambiario = null;

                //if (this.tSBMoneda.KeyMember != "")
                //{
                //    ps.ps_monedagastoid = Convert.ToInt32(this.tSBMoneda.KeyMember);
                //}
                //else
                //{
                //    ps.ps_monedagastoid = null;
                //}
                #endregion Gasto Bancario

                #region Recibo
                if (this.txtFechaRecibo.Text != "")
                {
                    ps.ps_fecharecibo = Convert.ToDateTime(this.txtFechaRecibo.Text);
                    ps.ps_nrorecibo = this.txtNroRecibo.Text != "" ? this.txtNroRecibo.Text : null;
                }
                else
                {
                    ps.ps_fecharecibo = null;
                    ps.ps_nrorecibo = null;
                }
                #endregion Recibo

                #region Nota Crédito
                if (this.txtFechaNotaCredito.Text != "")
                {
                    ps.ps_fechanotacredito = Convert.ToDateTime(this.txtFechaNotaCredito.Text);
                    ps.ps_notacreditonro = this.txtNotaCreditoNro.Text != "" ? this.txtNotaCreditoNro.Text : null;
                }
                else
                {
                    ps.ps_fechanotacredito = null;
                    ps.ps_notacreditonro = null;
                }
                #endregion Nota Crédito

                context.ps_pagosolicitud.Add(ps);
            }
            #endregion INSERT

            return ps;
        }

        private List<sxp_solicitudesxpago> GetListaSolicitudesXPago(int PagoProveedorID = 0)
        {
            const string WHERE_FACTURA = " AND (spd_saldo > 0) AND (spd_proveedorid = {0}) AND (spd_nrofactura = \"{1}\") AND (spd_fechafactura = \"{2}\")";
            const string WHERE_UN_PROVEEDOR_VARIAS_FACTURA = " AND (spd_saldo > 0) AND (spd_proveedorid = {0}) ";
            List<sxp_solicitudesxpago> Result = new List<sxp_solicitudesxpago>();

            string ListaSolicitudes = this.tSBSolicitudCab.KeyMember;
            decimal MontoPago = Convert.ToDecimal(this.txtMontoPago.Text);

            string where = SPF.Base.Libs.GetFilterString(ListaSolicitudes, CAMPO_SOLICITUDPAGOCABID_DET_TABLA, false);

            List<object> filterParam = new List<object>();
            filterParam = null;
            if ((this.GetFilterType() == FILTRO_FACTURA) || ((this.GetFilterType() == FILTRO_PROVEEDOR) && (this.txtNroFactura.Text != VARIAS_FACTURAS)))
            {
                where += String.Format(WHERE_FACTURA, this.txtProveedorID.Text, this.txtNroFactura.Text, this.txtFecFactura.Text);
                GenerarCadenasFiltro genFiltro = new GenerarCadenasFiltro();
                where = genFiltro.GetParseString(where);
                filterParam = genFiltro.FilterParam;
            }
            else if ((this.GetFilterType() == FILTRO_PROVEEDOR) && (this.txtNroFactura.Text == VARIAS_FACTURAS))
            {
                where += String.Format(WHERE_UN_PROVEEDOR_VARIAS_FACTURA, this.txtProveedorID.Text);
                GenerarCadenasFiltro genFiltro = new GenerarCadenasFiltro();
                where = genFiltro.GetParseString(where);
                filterParam = genFiltro.FilterParam;
            }

            List<spd_solicitudpagodet> listaSPD = this.DBContext.spd_solicitudpagodet.Where(where, filterParam != null ? filterParam.ToArray() : null).OrderBy(a => a.spd_solicitudpagodetid).ToList();

            //List<spc_solicitudpagocab> listaSPC = this.DBContext.spc_solicitudpagocab.Where(where).ToList();
            
            decimal montopago = 0;
            decimal gMontoPago = MontoPago;
            //foreach (var row in listaSPC)
            foreach (var row in listaSPD)
            {
                ((IObjectContextAdapter)this.DBContext).ObjectContext.Refresh(System.Data.Entity.Core.Objects.RefreshMode.ClientWins, row);
                if (gMontoPago > 0)
                {
                    //if (row.spc_saldo <= gMontoPago)
                    if (row.spd_saldo <= gMontoPago)
                    {
                        //montopago = row.spc_saldo;
                        montopago = row.spd_saldo;
                        gMontoPago = gMontoPago - montopago;
                    }
                    else
                    {
                        montopago = gMontoPago;
                        gMontoPago = 0;
                    }

                    sxp_solicitudesxpago sxp = new sxp_solicitudesxpago
                    {
                        sxp_pagosolicitudid = PagoProveedorID,
                        sxp_solicitudpagocabid = row.spd_solicitudpagocabid,//row.spc_solicitudpagocabid,
                        sxp_monto = montopago
                    };
                    Result.Add(sxp);
                }                                  
            }
            return Result;
        }

        private void AnularDialogHandler(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    this.AnularPagoProveedor(Convert.ToInt32(this.txtPagoID.Text));
                }
            }
        }

        private void AnularPagoProveedor(int PagoProveedorID)
        {
            bool success = false;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        ps_pagosolicitud mc = context.ps_pagosolicitud.First(a => a.ps_pagosolicitudid == PagoProveedorID);
                        mc.ps_anulado = true;
                        mc.ps_fechaanulacion = System.DateTime.Now;
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        MessageBox.Show("Ocurrió un error al anular el pago. "
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
                this.FilterEntity(this.WhereString, this.FilterParam);
                this.CargarPago(this.dgvListadoABM.Rows[this.LastDGVIndex]);
                MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion Métodos de Edición de Datos

        private void tabListaABM_SelectedIndexChanging_1(object sender, TabControlCancelEventArgs e)
        {

        }

               

        #endregion CRUD
    }
}