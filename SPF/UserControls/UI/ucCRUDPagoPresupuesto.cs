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
    public partial class ucCRUDPagoPresupuesto : ucBaseForm
    {
        #region Variables Globales
        frmPickBase fPickMoneda;
        frmPickBase fPickFormaPago;
        frmPickBase fPickBancoDeposito;
        frmPickBase fPickCuentaDeposito;
        frmPickBase fPickBancoCheque;
        frmPickBase fPickPresupuesto;
        frmPickBase fPickNotaCredito;
        frmPickBase fPickRespCobroExterior;
        private int UsuarioID = -1;
        private bool ExistenNCConSaldo = false;
        #endregion Variables Globales

        #region Constantes
        private const string CAMPO_PAGOPRESUPUESTOID    = "PagoPresupuestoID";
        private const string CAMPO_PAGOMULTIPLEID       = "PagoMultipleID";
        private const string CAMPO_PRESUPUESTOCABID     = "PresupuestoCabID";
        private const string CAMPO_FECHAPAGO            = "FechaPago";
        private const string CAMPO_MONEDAID             = "MonedaID";
        private const string CAMPO_MONEDADESCRIP        = "MonedaDescrip";
        private const string CAMPO_MONEDASIMBOLO        = "MonedaSimbolo";
        private const string CAMPO_BANCODEPID           = "BancoDepID";
        private const string CAMPO_BANCODEPNOMBRE       = "BancoNombre";
        private const string CAMPO_CUENTADEPOSITO       = "CuentaDepID";
        private const string CAMPO_CUENTADEPNOMBRE      = "CuentaDepNombre";
        private const string CAMPO_FORMAPAGOID          = "FormaPagoID";
        private const string CAMPO_FORMAPAGODESCRIP     = "FormaPagoDescrip";
        private const string CAMPO_CHEQUENRO            = "ChequeNro";
        private const string CAMPO_BANCOCHEQUEID        = "BancoChequeID";
        private const string CAMPO_BANCOCHEQUENOMBRE    = "BancoChequeNombre";
        private const string CAMPO_MONEDAGASTOID        = "MonedaGastoID";
        private const string CAMPO_MONEDAGASTODESCRIP   = "MonedaGastoDescrip";
        private const string CAMPO_GASTOCAMBIARIO       = "GastoBancario";
        private const string CAMPO_MONTOPAGO            = "MontoPago";
        private const string CAMPO_REFERENCIA           = "Referencia";
        private const string CAMPO_FECHABOLETADEP       = "FechaBoletaDep";
        private const string CAMPO_BOLETADEPNRO         = "BoletaDepNro";
        private const string CAMPO_NROPRESUPUESTO       = "NroPresupuesto";
        private const string CAMPO_NRORECIBO            = "NroRecibo";
        private const string CAMPO_FECHARECIBO          = "FechaRecibo";
        private const string CAMPO_TRAMITEDESCRIPCION   = "TramiteDescripcion";
        private const string CAMPO_CLIENTEID            = "ClienteID";
        private const string CAMPO_CLIENTENOMBRE        = "ClienteNombre";
        private const string CAMPO_AUTORIZACIONVIG      = "TieneAutorizacionVigente";
        private const string CAMPO_ANULADO              = "Anulado";
        private const string CAMPO_SALDO                = "Saldo";
        private const string CAMPO_FACTURANRO           = "FacturaNro";
        private const string CAMPO_FECHANOTACREDITO     = "FechaNotaCredito";
        private const string CAMPO_NOTACREDITONRO       = "NroNotaCredito";
        private const string CAMPO_NOTACREDITOID        = "IDNotaCredito";
        private const string CAMPO_NOTACREDITOREF       = "RefNotaCredito";
        private const string CAMPO_NOTACREDITOCUERPO    = "CuerpoNotaCredito";
        private const string CAMPO_RESPCOBROEXTID       = "RespCobroExtID";
        private const string CAMPO_RESPCOBROEXTNOMBRE   = "RespCobroExtNombre";

        private const string CAMPO_AUDITOPERACION       = "AuditOperacion";
        private const string CAMPO_USUARIOCARGAID       = "UsuarioCargaID";
        private const string CAMPO_USUARIOCARGANOMBRE   = "UsuarioCargaNombre";

        private const string AUDIT_OPERACION_INSERT     = "INSERT";
        private const string ESTADO_PENDIENTE = "A";
        private const string ESTADO_ANULADO = "N";
        private const string ESTADO_PAGADO = "P";
        private const int IDIOMA_ESPANOL = 2;
        private const int TIPODOCUMENTO_PAGOPRESUPUESTO = 4;
        private const int FORMAPAGO_NOTACREDITOPRESUPUESTO = 9;
        private const int FORMAPAGO_COBRO_EN_EL_EXTERIOR = 16;
        #endregion Constantes

        #region Método de Inicio
        public ucCRUDPagoPresupuesto()
        {

            InitializeComponent();
        }

        public ucCRUDPagoPresupuesto(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();
            this.DBContext = dbContext;
            this.Titulo = Titulo;
            this.UsuarioID = Convert.ToInt32(VWGContext.Current.Session["UsuarioID"].ToString());
            
            var pagos = (from pPre in this.DBContext.pp_pagopresupuesto
                         join pCab in this.DBContext.pc_presupuestocab
                            on pPre.pp_presupuestocabid equals pCab.pc_presupuestocabid
                         join mon in this.DBContext.Moneda
                            on pPre.pp_monedaid equals mon.ID
                         join monG in this.DBContext.Moneda
                            on pPre.pp_monedagastoid equals monG.ID into monG_pPre
                            from monG in monG_pPre.DefaultIfEmpty()
                         join banD in this.DBContext.ba_banco
                            on pPre.pp_bancoid equals banD.ba_bancoid into banD_pPre
                         from banD in banD_pPre.DefaultIfEmpty()
                         join ctaD in this.DBContext.cb_cuentabanco
                            on pPre.pp_cuentaid equals ctaD.cb_cuentabancoid into ctaD_pPre
                         from ctaD in ctaD_pPre.DefaultIfEmpty()
                         join fPag in this.DBContext.fp_formadepago
                            on pPre.pp_formapagoid equals fPag.fp_formadepagoid
                         join banC in this.DBContext.ba_banco
                            on pPre.pp_bancochequeid equals banC.ba_bancoid into banC_pPre
                         from banC in banC_pPre.DefaultIfEmpty()
                         join tram in this.DBContext.Tramite
                            on pCab.pc_tramiteid equals tram.ID
                         join cli in this.DBContext.Cliente
                            on pCab.pc_clienteid equals cli.ID
                         join nCr in this.DBContext.ncp_notacreditopresup
                            on pPre.pp_notacreditopresupid equals nCr.ncp_notacreditoid into nCr_pPre
                         from nCr in nCr_pPre.DefaultIfEmpty()
                         join uExt in this.DBContext.Usuario 
                            on pPre.pp_respcobroextid equals uExt.ID into uExt_pPre
                         from uExt in uExt_pPre.DefaultIfEmpty()
                         join AudpPre in this.DBContext.Audit_pp_pagopresupuesto
                            on pPre.pp_pagopresupuestoid equals AudpPre.pp_pagopresupuestoid
                         join uAud in this.DBContext.Usuario
                            on AudpPre.Audit_User.Substring(6, AudpPre.Audit_User.Length) equals uAud.Usuario1
                         select new PagoPresupuestoType
                         {
                             PagoPresupuestoID = pPre.pp_pagopresupuestoid,
                             PresupuestoCabID = pPre.pp_presupuestocabid,
                             FechaPago = pPre.pp_fechapago,
                             MonedaID = pPre.pp_monedaid,
                             MonedaDescrip = mon.Descripcion,
                             MonedaSimbolo = mon.AbrevMoneda,
                             BancoDepID = pPre.pp_bancoid,
                             BancoNombre = banD.ba_descripcion,
                             CuentaDepID = pPre.pp_cuentaid,
                             CuentaDepNombre = ctaD.cb_descripcion,
                             FormaPagoID = pPre.pp_formapagoid,
                             FormaPagoDescrip = fPag.fp_descripcion,
                             ChequeNro = pPre.pp_nrocheque,
                             BancoChequeID = pPre.pp_bancochequeid,
                             BancoChequeNombre = banC.ba_descripcion,
                             MonedaGastoID = pPre.pp_monedagastoid,
                             MonedaGastoDescrip = monG.Descripcion,
                             GastoBancario = pPre.pp_gastocambiario,
                             MontoPago = pPre.pp_montopago,
                             Referencia = pPre.pp_referencia,
                             FechaBoletaDep = pPre.pp_fechaboletadeposito,
                             BoletaDepNro = pPre.pp_nroboletadeposito,
                             NroPresupuesto = pCab.pc_nropresupuesto,
                             NroRecibo = pPre.pp_nrorecibo,
                             FechaRecibo = pPre.pp_fecharecibo,
                             TramiteDescripcion = tram.Descrip,
                             ClienteID = pCab.pc_clienteid,
                             ClienteNombre = cli.Nombre,
                             Anulado = pPre.pp_anulado,
                             Saldo = pCab.pc_saldo,
                             FacturaNro = pCab.pc_string1,
                             FechaNotaCredito = pPre.pp_fechanotacredito,
                             NroNotaCredito = pPre.pp_notacreditonro,
                             PagoMultipleID = pPre.pp_pagomultipleid,
                             TieneAutorizacionVigente = this.DBContext.GetAutorizacionPorDocumentoID(TIPODOCUMENTO_PAGOPRESUPUESTO,
                                                                                                          pPre.pp_pagopresupuestoid,
                                                                                                          this.UsuarioID)
                                                                                                          .FirstOrDefault().Value,
                             IDNotaCredito = pPre.pp_notacreditopresupid,
                             RefNotaCredito = nCr.ncp_referenciacliente,
                             CuerpoNotaCredito = nCr.ncp_cuerponota,
                             RespCobroExtID = pPre.pp_respcobroextid,
                             RespCobroExtNombre = uExt.NombrePila,
                             UsuarioCargaID = uAud.ID,
                             UsuarioCargaNombre = uAud.NombrePila,
                             AuditOperacion = AudpPre.Audit_Operacion
                         })
                         .Where(b => b.AuditOperacion == AUDIT_OPERACION_INSERT)
                         .OrderByDescending(a => a.PagoPresupuestoID)
                         .Take(50);

            this.BindingSourceBase = pagos.ToList();

            #region Especificar campos para filtro
            this.SetFilter(CAMPO_PAGOPRESUPUESTOID, "ID Cobro", false);
            this.SetFilter(CAMPO_NROPRESUPUESTO, "N° Presupuesto");
            this.SetFilter(CAMPO_PRESUPUESTOCABID, "ID Presup.", false);
            this.SetFilter(CAMPO_REFERENCIA, "Referencia");
            this.SetFilter(CAMPO_FECHAPAGO, "Fecha Cobro");
            this.SetFilter(CAMPO_FECHABOLETADEP, "Fecha Depósito");
            this.SetFilter(CAMPO_BOLETADEPNRO, "Boleta Dep. N°");
            this.SetFilter(CAMPO_NRORECIBO, "Recibo N°");
            this.SetFilter(CAMPO_FECHARECIBO, "Fecha Recibo");
            this.SetFilter(CAMPO_MONEDADESCRIP, "Moneda");
            this.SetFilter(CAMPO_FORMAPAGODESCRIP, "Forma de Cobro");
            this.SetFilter(CAMPO_BANCODEPNOMBRE, "Banco Depósito");
            this.SetFilter(CAMPO_CUENTADEPNOMBRE, "Cuenta Depósito");
            this.SetFilter(CAMPO_CHEQUENRO, "N° Cheque");
            this.SetFilter(CAMPO_BANCOCHEQUENOMBRE, "Banco Cheque");
            this.SetFilter(CAMPO_FACTURANRO, "Factura N°");
            this.SetFilter(CAMPO_CLIENTEID, "ID Cliente", false);
            this.SetFilter(CAMPO_CLIENTENOMBRE, "Nombre Cliente");
            this.SetFilter(CAMPO_NOTACREDITOID, "ID Nota Créd.", false);
            this.SetFilter(CAMPO_NOTACREDITONRO, "N° Nota Créd.");
            this.SetFilter(CAMPO_NOTACREDITOREF, "Ref. Nota Créd.");
            this.SetFilter(CAMPO_PAGOMULTIPLEID, "ID Cobro Múltiple", false);
            this.SetFilter(CAMPO_RESPCOBROEXTID, "Resp. Cobro Ext.", false);
            this.SetFilter(CAMPO_RESPCOBROEXTNOMBRE, "Resp. Cobro Ext. Nomb.");
            this.SetFilter(CAMPO_USUARIOCARGAID, "Gen. Por ID", false);
            this.SetFilter(CAMPO_USUARIOCARGANOMBRE, "Gen. Por Nombre");
            this.TituloBuscador = "Buscar Cobros";
            #endregion Especificar campos para filtro

            #region Inicializar TextSearchBoxes
            this.tSBMoneda.KeyMemberWidth = 70;
            this.tSBMoneda.ToolTip = "Elegir Moneda";
            this.tSBMoneda.AceptarClick += tSBMoneda_AceptarClick;

            this.tSBFormaPago.KeyMemberWidth = 70;
            this.tSBFormaPago.ToolTip = "Elegir Forma de Cobro";
            this.tSBFormaPago.AceptarClick += tSBFormaPago_AceptarClick;
            this.tSBFormaPago.KeyMemberTextChanged += tSBFormaPago_KeyMemberTextChanged;

            this.tSBRespCobroExterior.KeyMemberWidth = 70;
            this.tSBRespCobroExterior.ToolTip = "Elegir Responsable de Cobro en el Exterior";
            this.tSBRespCobroExterior.AceptarClick += tSBRespCobroExterior_AceptarClick;

            this.tSBBancoDeposito.KeyMemberWidth = 70;
            this.tSBBancoDeposito.ToolTip = "Elegir Banco de Depósito";
            this.tSBBancoDeposito.AceptarClick += tSBBancoDeposito_AceptarClick;

            this.tSBCuentaDeposito.KeyMemberWidth = 70;
            this.tSBCuentaDeposito.ToolTip = "Elegir Cuenta de Depósito";
            this.tSBCuentaDeposito.AceptarClick += tSBCuentaDeposito_AceptarClick;

            this.tSBBancoCheque.KeyMemberWidth = 70;
            this.tSBBancoCheque.ToolTip = "Elegir Banco de Cheque";
            this.tSBBancoCheque.AceptarClick += tSBBancoCheque_AceptarClick;

            this.tSBPresupuesto.KeyMemberWidth = 70;
            this.tSBPresupuesto.ToolTip = "Elegir Presupuesto";
            this.tSBPresupuesto.AceptarClick += tSBPresupuesto_AceptarClick;

            this.tSBNotaCredito.KeyMemberWidth = 100;
            this.tSBNotaCredito.ToolTip = "Elegir Nota de Crédito";
            this.tSBNotaCredito.Visible = false;
            this.tSBNotaCredito.AceptarClick += tSBNotaCredito_AceptarClick;
            #endregion Inicializar TextSearchBoxes

            #region Datetime Picker
            this.dtpFechaPago.Format = DateTimePickerFormat.Short;
            this.dtpFechaDeposito.Format = DateTimePickerFormat.Short;
            #endregion Datetime Picker

            #region Ocultar Botones
            this.tbbBorrar.Visible = false;
            //this.tbbEditar.Visible = false;
            #endregion Ocultar Botones

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

            fPickFormaPago.Close();
            fPickFormaPago.Dispose();

            if ((Convert.ToInt32(this.tSBFormaPago.KeyMember) == FORMAPAGO_NOTACREDITOPRESUPUESTO) && (this.ExistenNCConSaldo))
            {
                this.tSBNotaCredito.Visible = true;
                this.txtNotaCreditoNro.Visible = false;
                this.txtReferenciaNotaCredito.ReadOnly = true;
                this.txtReferenciaNotaCredito.BackColor = SystemColors.Control; 
                this.txtNotaCreditoCuerpo.ReadOnly = true;
                this.txtNotaCreditoCuerpo.BackColor = SystemColors.Control; 
            }
            else
            {
                this.tSBNotaCredito.Visible = false;
                this.txtNotaCreditoNro.Visible = true;
                this.txtReferenciaNotaCredito.ReadOnly = false;
                this.txtReferenciaNotaCredito.BackColor = SystemColors.Window;
                this.txtNotaCreditoCuerpo.ReadOnly = false;
                this.txtNotaCreditoCuerpo.BackColor = SystemColors.Window;
            }
            this.txtFechaNotaCredito.Text = "";
            this.txtNotaCreditoNro.Text = "";
            this.txtIdNotaCredito.Text = "";
            this.txtNCSaldo.Text = "";
            this.txtNCTotal.Text = "";
            this.txtNotaCreditoCuerpo.Text = "";
            this.txtReferenciaNotaCredito.Text = "";

        }

        private void tSBFormaPago_KeyMemberTextChanged(object sender, EventArgs e)
        {
            this.HandletSBRespCobroExterior();
        }

        private void HandletSBRespCobroExterior()
        {
            this.tSBRespCobroExterior.Editable = ((this.FormEditStatus != BROWSE)
                                                    && (this.tSBFormaPago.KeyMember.Trim() != String.Empty)
                                                    && (Convert.ToInt32(this.tSBFormaPago.KeyMember) == FORMAPAGO_COBRO_EN_EL_EXTERIOR));
        }

        #endregion Forma de Pago

        #region Responsable Cobro en el Exterior
        private void tSBRespCobroExterior_AceptarClick(object sender, EventArgs e)
        {
            if (fPickRespCobroExterior == null)
            {
                fPickRespCobroExterior = new frmPickBase();
                fPickRespCobroExterior.AceptarFiltrarClick += fPickRespCobroExterior_AceptarFiltrarClick;
                fPickRespCobroExterior.FiltrarClick += fPickRespCobroExterior_FiltrarClick;
                fPickRespCobroExterior.Titulo = "Elegir Responsable de Cobro en el Exterior";
                fPickRespCobroExterior.CampoIDNombre = "ID";
                fPickRespCobroExterior.CampoDescripNombre = "NombrePIla";
                fPickRespCobroExterior.LabelCampoID = "ID";
                fPickRespCobroExterior.LabelCampoDescrip = "Nombre";
                fPickRespCobroExterior.NombreCampo = "Resp. Cobro";
                fPickRespCobroExterior.PermitirFiltroNulo = true;
            }
            fPickRespCobroExterior.MostrarFiltro();
        }

        private void fPickRespCobroExterior_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickRespCobroExterior != null)
            {
                fPickRespCobroExterior.LoadData<Usuario>(this.DBContext.Usuario, fPickRespCobroExterior.GetWhereString());
            }
        }

        private void fPickRespCobroExterior_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBRespCobroExterior.DisplayMember = fPickRespCobroExterior.ValorDescrip;
            this.tSBRespCobroExterior.KeyMember = fPickRespCobroExterior.ValorID;

            fPickRespCobroExterior.Close();
            fPickRespCobroExterior.Dispose();
        }
        #endregion Responsable Cobro en el Exterior

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
                                 Descripcion = this.DBContext.GetDocumentoNro(pCab.pc_presupuestocabid).FirstOrDefault() + " - " + tr.Descrip
                             });

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

            #region Datos Presupuesto
            int pCabID = Convert.ToInt32(this.tSBPresupuesto.KeyMember);
            pc_presupuestocab pCab = this.DBContext.pc_presupuestocab.FirstOrDefault(a => a.pc_presupuestocabid == pCabID);
            ((IObjectContextAdapter)this.DBContext).ObjectContext.Refresh(System.Data.Entity.Core.Objects.RefreshMode.ClientWins, pCab);

            if (pCab.pc_estado == ESTADO_ANULADO)
            {
                MessageBox.Show("El documento: " + this.tSBPresupuesto.DisplayMember + " se encuentra anulado." + Environment.NewLine +
                                "No se pueden cargar cobros para el mismo.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            this.txtPresupuestoCabID.Text = this.tSBPresupuesto.KeyMember;
            //this.txtNroPresupuesto.Text = this.tSBPresupuesto.DisplayMember.Split('-')[0].Trim();
            this.txtNroPresupuesto.Text = pCab.pc_nropresupuesto;
            this.txtNroFactura.Text = pCab.pc_string1;
            this.txtSaldo.Text = pCab.pc_saldo.ToString();
            #endregion Datos Presupuesto

            #region Moneda del Presupuesto
            int MonedaID = pCab.pc_monedaid;
            Moneda mn = this.DBContext.Moneda.FirstOrDefault(a => a.ID == MonedaID);

            this.txtMonedaID.Text = mn.ID.ToString();
            this.txtMonedaDescrip.Text = mn.Descripcion;
            #endregion Moneda del Presupuesto

            #region Cliente del Presupuesto
            int ClienteID = pCab.pc_clienteid;
            Cliente cli = this.DBContext.Cliente.FirstOrDefault(a => a.ID == ClienteID);
            this.txtClienteID.Text = cli.ID.ToString();
            this.txtClienteNombre.Text = cli.Nombre;

            #endregion Cliente del Presupuesto

            fPickPresupuesto.Close();
            fPickPresupuesto.Dispose();

            #region Verificar si tiene notas crédito de presupuestos disponibles
            this.ExistenNCConSaldo = this.ExisteNotaCreditoConSaldo(ClienteID, this.DBContext);
            if (this.ExistenNCConSaldo)
            {
                MessageBox.Show("El cliente cuenta con Notas de Crédito de Presupuesto disponibles.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }
            #endregion Verificar si tiene notas crédito de presupuestos disponibles
        }
        #endregion Presupuesto

        #region Nota Crédito
        private void tSBNotaCredito_AceptarClick(object sender, EventArgs e)
        {
            if (fPickNotaCredito == null)
            {
                fPickNotaCredito = new frmPickBase();
                fPickNotaCredito.AceptarFiltrarClick += fPickNotaCredito_AceptarFiltrarClick;
                fPickNotaCredito.FiltrarClick += fPickNotaCredito_FiltrarClick;
                fPickNotaCredito.Titulo = "Elegir Nota Crédito";
                fPickNotaCredito.CampoIDNombre = "NotaCreditoID";
                fPickNotaCredito.CampoDescripNombre = "NotaCreditoDescripcion";
                fPickNotaCredito.LabelCampoID = "ID";
                fPickNotaCredito.LabelCampoDescrip = "Descripción";
                fPickNotaCredito.NombreCampo = "N. Crédito";
                fPickNotaCredito.PermitirFiltroNulo = true;
            }
            fPickNotaCredito.MostrarFiltro();
            this.fPickNotaCredito_FiltrarClick(sender, e);
        }

        private void fPickNotaCredito_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickNotaCredito != null)
            {
                int clienteID = Convert.ToInt32(this.txtClienteID.Text);
                int monedaID = Convert.ToInt32(this.txtMonedaID.Text);

                var query = this.DBContext.ncp_notacreditopresup
                             .Where(a => a.ncp_clienteid == clienteID
                                    && a.ncp_anulado != true
                                    && a.ncp_saldo > 0
                                    && a.ncp_monedaid == monedaID)
                             .ToList()
                             .Select(x => new NotaCreditoSelectType()
                            {
                                NotaCreditoID = x.ncp_notacreditoid,
                                NotaCreditoDescripcion = x.ncp_nrocomprobante.ToString() + ": " + x.ncp_cuerponota + " - " + x.ncp_presupuestos,
                                Anulado = x.ncp_anulado,
                                Saldo = x.ncp_saldo,
                                ClienteID = x.ncp_clienteid,
                                MonedaID = x.ncp_monedaid
                            });
                            


                fPickNotaCredito.LoadData<NotaCreditoSelectType>(query.AsQueryable(), fPickNotaCredito.GetWhereString());
               
            }
        }

        private void fPickNotaCredito_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBNotaCredito.DisplayMember = fPickNotaCredito.ValorDescrip;
            this.tSBNotaCredito.KeyMember = fPickNotaCredito.ValorID;
            this.txtNotaCreditoNro.Text = fPickNotaCredito.ValorDescrip.Split(':')[0];
            this.txtIdNotaCredito.Text = fPickNotaCredito.ValorID;

            fPickNotaCredito.Close();
            fPickNotaCredito.Dispose();

            int ncID = Convert.ToInt32(this.txtIdNotaCredito.Text);
            ncp_notacreditopresup ncp = this.DBContext.ncp_notacreditopresup.First(a => a.ncp_notacreditoid == ncID);
            this.txtNCSaldo.Text = String.Format("{0:0.00}", ncp.ncp_saldo);
            this.txtNCTotal.Text = String.Format("{0:0.00}", ncp.ncp_monto);
            this.txtNotaCreditoCuerpo.Text = ncp.ncp_cuerponota;
            this.txtReferenciaNotaCredito.Text = ncp.ncp_referenciacliente;
            this.lblNCTotal.Visible = true;
            this.txtNCTotal.Visible = true;
            this.lblNCSaldo.Visible = true;
            this.txtNCSaldo.Visible = true;
            //this.lblIDNotaCredito.Visible = true;
            //this.txtIdNotaCredito.Visible = true;
            this.txtFechaNotaCredito.ReadOnly = true;
            this.dtpFechaNotaCredito.Enabled = false;
            this.txtNotaCreditoCuerpo.ReadOnly = true;
            this.txtReferenciaNotaCredito.ReadOnly = true;
        }
        #endregion Nota Crédito
        #endregion Picks

        #region Controles Locales
        private void dgvListadoABM_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((this.LastDGVIndex > -1) && (!this.IsClosing))
                this.CargarPago(this.dgvListadoABM.Rows[this.LastDGVIndex]);
                
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

            if (this.tSBPresupuesto.KeyMember == "")
            {
                MessageBox.Show("Debe ingresar Presupuesto al que imputar el cobro.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if ((this.tSBMoneda.KeyMember == "") && (this.txtGastoBancario.Text != ""))
            {
                MessageBox.Show("Debe ingresar una moneda de gasto válida.",
                               "Información",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return;
            }

            if (this.tSBFormaPago.KeyMember == "")
            {
                MessageBox.Show("Debe ingresar una forma de cobro válida.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (this.txtFechaPago.Text == "")
            {
                MessageBox.Show("Debe ingresar una fecha de cobro válida.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (this.txtMontoPago.Text == "")
            {
                MessageBox.Show("Debe ingresar un monto de cobro válido.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
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

            if ((this.tSBFormaPago.KeyMember != "") &&
                        (Convert.ToInt32(this.tSBFormaPago.KeyMember) != FORMAPAGO_NOTACREDITOPRESUPUESTO))
            {
                if (((this.txtFechaNotaCredito.Text == "") && (this.txtNotaCreditoNro.Text != "")) ||
                    ((this.txtFechaNotaCredito.Text != "") && (this.txtNotaCreditoNro.Text == "")))
                {
                    MessageBox.Show("Debe ingresar fecha y número de nota de crédito.",
                                    "Información",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    return;
                }

                
            }

            if ((this.tSBFormaPago.KeyMember != "") &&
                        (Convert.ToInt32(this.tSBFormaPago.KeyMember) == FORMAPAGO_NOTACREDITOPRESUPUESTO))
            {
                if ((this.tSBNotaCredito.KeyMember != "")
                        && (Convert.ToDecimal(this.txtNCSaldo.Text.Replace('.', ',')) < Convert.ToDecimal(this.txtMontoPago.Text.Replace('.', ','))))
                {
                    MessageBox.Show("El monto de cobro no puede ser mayor al saldo de la nota de crédito seleccionada",
                                    "Información",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    return;
                }
            }

            //No se pueden pagar presupuestos que no estén pendientes o cuyos saldo sean iguales a 0
            if ((this.FormEditStatus == INSERT) &&
                (!this.PuedePagarse(Convert.ToInt32(this.tSBPresupuesto.KeyMember), Convert.ToDecimal(this.txtMontoPago.Text.Replace('.', ',')), this.DBContext)))
            {
                MessageBox.Show("El cobro no puede ser procesado, el saldo del Presupuesto es 0 (cero)," + Environment.NewLine +
                                "el presupuesto no se encuentra en estado Pendiente (P) " + Environment.NewLine +
                                "o el monto ingresado es superior al saldo del Presupuesto.",
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

        private void dgvListadoABM_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.RowIndex > -1) &&
                (this.dgvListadoABM.Rows[e.RowIndex].Cells[CAMPO_AUTORIZACIONVIG].Value != null) &&
                ((bool)(this.dgvListadoABM.Rows[e.RowIndex].Cells[CAMPO_AUTORIZACIONVIG].Value)))
            {
                ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }
        #endregion Controles Locales

        #region Métodos Locales

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
        #endregion Métodos Locales

        #region Método Extendidos del ParentControl
        protected override void FilterEntity(string where = "", object[] filterParams = null)
        {
            try
            {
                this.limpiarDatos();

                var query = (from pPre in this.DBContext.pp_pagopresupuesto
                             join pCab in this.DBContext.pc_presupuestocab
                                on pPre.pp_presupuestocabid equals pCab.pc_presupuestocabid
                             join mon in this.DBContext.Moneda
                                on pPre.pp_monedaid equals mon.ID
                             join monG in this.DBContext.Moneda
                                on pPre.pp_monedagastoid equals monG.ID into monG_pPre
                             from monG in monG_pPre.DefaultIfEmpty()
                             join banD in this.DBContext.ba_banco
                                on pPre.pp_bancoid equals banD.ba_bancoid into banD_pPre
                             from banD in banD_pPre.DefaultIfEmpty()
                             join ctaD in this.DBContext.cb_cuentabanco
                                on pPre.pp_cuentaid equals ctaD.cb_cuentabancoid into ctaD_pPre
                                from ctaD in ctaD_pPre.DefaultIfEmpty()
                             join fPag in this.DBContext.fp_formadepago
                                on pPre.pp_formapagoid equals fPag.fp_formadepagoid
                             join banC in this.DBContext.ba_banco
                                on pPre.pp_bancochequeid equals banC.ba_bancoid into banC_pPre
                             from banC in banC_pPre.DefaultIfEmpty()
                             join tram in this.DBContext.Tramite
                                on pCab.pc_tramiteid equals tram.ID
                             join cli in this.DBContext.Cliente
                                on pCab.pc_clienteid equals cli.ID
                             join nCr in this.DBContext.ncp_notacreditopresup
                                on pPre.pp_notacreditopresupid equals nCr.ncp_notacreditoid into nCr_pPre
                                from nCr in nCr_pPre.DefaultIfEmpty()
                             join uExt in this.DBContext.Usuario
                                on pPre.pp_respcobroextid equals uExt.ID into uExt_pPre
                                from uExt in uExt_pPre.DefaultIfEmpty()
                             join AudpPre in this.DBContext.Audit_pp_pagopresupuesto
                                on pPre.pp_pagopresupuestoid equals AudpPre.pp_pagopresupuestoid
                             join uAud in this.DBContext.Usuario
                                on AudpPre.Audit_User.Substring(6, AudpPre.Audit_User.Length) equals uAud.Usuario1
                             select new PagoPresupuestoType
                             {
                                 PagoPresupuestoID = pPre.pp_pagopresupuestoid,
                                 PresupuestoCabID = pPre.pp_presupuestocabid,
                                 FechaPago = pPre.pp_fechapago,
                                 MonedaID = pPre.pp_monedaid,
                                 MonedaDescrip = mon.Descripcion,
                                 MonedaSimbolo = mon.AbrevMoneda,
                                 BancoDepID = pPre.pp_bancoid,
                                 BancoNombre = banD.ba_descripcion,
                                 CuentaDepID = pPre.pp_cuentaid,
                                 CuentaDepNombre = ctaD.cb_descripcion,
                                 FormaPagoID = pPre.pp_formapagoid,
                                 FormaPagoDescrip = fPag.fp_descripcion,
                                 ChequeNro = pPre.pp_nrocheque,
                                 BancoChequeID = pPre.pp_bancochequeid,
                                 BancoChequeNombre = banC.ba_descripcion,
                                 MonedaGastoID = pPre.pp_monedagastoid,
                                 MonedaGastoDescrip = monG.Descripcion,
                                 GastoBancario = pPre.pp_gastocambiario,
                                 MontoPago = pPre.pp_montopago,
                                 Referencia = pPre.pp_referencia,
                                 FechaBoletaDep = pPre.pp_fechaboletadeposito,
                                 BoletaDepNro = pPre.pp_nroboletadeposito,
                                 NroPresupuesto = pCab.pc_nropresupuesto,
                                 NroRecibo = pPre.pp_nrorecibo,
                                 FechaRecibo = pPre.pp_fecharecibo,
                                 TramiteDescripcion = tram.Descrip,
                                 ClienteID = pCab.pc_clienteid,
                                 ClienteNombre = cli.Nombre,
                                 Anulado = pPre.pp_anulado,
                                 Saldo = pCab.pc_saldo,
                                 FacturaNro = pCab.pc_string1,
                                 FechaNotaCredito = pPre.pp_fechanotacredito,
                                 NroNotaCredito = pPre.pp_notacreditonro,
                                 PagoMultipleID = pPre.pp_pagomultipleid,
                                 TieneAutorizacionVigente = this.DBContext.GetAutorizacionPorDocumentoID(TIPODOCUMENTO_PAGOPRESUPUESTO,
                                                                                                         pPre.pp_pagopresupuestoid,
                                                                                                         this.UsuarioID)
                                                                                                         .FirstOrDefault().Value,
                                 IDNotaCredito = pPre.pp_notacreditopresupid,
                                 RefNotaCredito = nCr.ncp_referenciacliente,
                                 CuerpoNotaCredito = nCr.ncp_cuerponota,
                                 RespCobroExtID = pPre.pp_respcobroextid,
                                 RespCobroExtNombre = uExt.NombrePila,
                                 UsuarioCargaID = uAud.ID,
                                 UsuarioCargaNombre = uAud.NombrePila,
                                 AuditOperacion = AudpPre.Audit_Operacion
                             })
                             .Where(b => b.AuditOperacion == AUDIT_OPERACION_INSERT);

                if (where != "")
                {
                    var x = query.Where(where, filterParams).OrderByDescending(a => a.FechaPago).ToList();
                    this.BindingSourceBase = query.Where(where, filterParams).OrderByDescending(a => a.FechaPago).ToList();
                }
                else
                {
                    this.BindingSourceBase = query.OrderByDescending(a => a.PagoPresupuestoID).Take(50).ToList();
                }

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

            this.dgvListadoABM.Columns[CAMPO_FECHAPAGO].HeaderText = "Fecha Cobro";
            this.dgvListadoABM.Columns[CAMPO_FECHAPAGO].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_FECHAPAGO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_FECHAPAGO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_FECHAPAGO].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_PAGOPRESUPUESTOID].HeaderText = "Cobro ID";
            this.dgvListadoABM.Columns[CAMPO_PAGOPRESUPUESTOID].Width = 60;
            this.dgvListadoABM.Columns[CAMPO_PAGOPRESUPUESTOID].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_PAGOPRESUPUESTOID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_PAGOPRESUPUESTOID].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_NROPRESUPUESTO].HeaderText = "N° Presupuesto";
            this.dgvListadoABM.Columns[CAMPO_NROPRESUPUESTO].Width = 110;
            this.dgvListadoABM.Columns[CAMPO_NROPRESUPUESTO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_NROPRESUPUESTO].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_FACTURANRO].HeaderText = "N° Factura";
            this.dgvListadoABM.Columns[CAMPO_FACTURANRO].Width = 100;
            this.dgvListadoABM.Columns[CAMPO_FACTURANRO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_FACTURANRO].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_CLIENTENOMBRE].HeaderText = "Cliente";
            this.dgvListadoABM.Columns[CAMPO_CLIENTENOMBRE].Width = 200;
            this.dgvListadoABM.Columns[CAMPO_CLIENTENOMBRE].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_CLIENTENOMBRE].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_TRAMITEDESCRIPCION].HeaderText = "Trámite";
            this.dgvListadoABM.Columns[CAMPO_TRAMITEDESCRIPCION].Width = 180;
            this.dgvListadoABM.Columns[CAMPO_TRAMITEDESCRIPCION].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_TRAMITEDESCRIPCION].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_MONTOPAGO].HeaderText = "Monto";
            this.dgvListadoABM.Columns[CAMPO_MONTOPAGO].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_MONTOPAGO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_MONTOPAGO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_MONTOPAGO].Visible = true;
            displayIndex++;

            DataGridViewCheckBoxColumn colConfirmado = new DataGridViewCheckBoxColumn();
            colConfirmado.DataPropertyName = CAMPO_ANULADO;
            colConfirmado.Name = CAMPO_ANULADO;
            colConfirmado.HeaderText = "Anulado";
            colConfirmado.FalseValue = false;
            colConfirmado.TrueValue = true;
            colConfirmado.ReadOnly = true;
            this.dgvListadoABM.Columns.Insert(displayIndex, colConfirmado);
        }

        protected override void tbbNuevo_Click(object sender, EventArgs e)
        {
            base.tbbNuevo_Click(sender, e);
            this.limpiarDatos();
            this.dtpFechaPago.Value = System.DateTime.Now;
            this.txtFechaPago.Text = System.DateTime.Now.ToShortDateString();
            this.tSBPresupuesto.SetFocus();
        }

        protected override void tbbEditar_Click(object sender, EventArgs e)
        {
            if ((Convert.ToInt32(this.tSBFormaPago.KeyMember) == FORMAPAGO_NOTACREDITOPRESUPUESTO)
                && (this.ExisteNotaCredito()))
            {
                MessageBox.Show("No se puede editar el cobro debido a que existe una nota de crédito asociada.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            if (this.txtEstado.Text == CAMPO_ANULADO)
            {
                MessageBox.Show("No se puede editar el cobro debido a que se encuentra anulado.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            base.tbbEditar_Click(sender, e);
            this.txtMontoPago.ReadOnly = true;
            this.tSBPresupuesto.SetFocus();
        }

        protected override void tbbCancelar_Click(object sender, EventArgs e)
        {
            base.tbbCancelar_Click(sender, e);

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
            this.txtFechaPago.ReadOnly = editar;
            this.tSBFormaPago.Editable = !editar;
            //this.tSBRespCobroExterior.Editable = !editar;
            this.HandletSBRespCobroExterior();
            this.tSBMoneda.Editable = !editar;

            this.txtMontoPago.ReadOnly = editar;

            this.txtGastoBancario.ReadOnly = editar;
            this.txtReferencia.ReadOnly = editar;
            this.txtFechaDeposito.ReadOnly = editar;
            this.tSBBancoDeposito.Editable = !editar;
            this.tSBCuentaDeposito.Editable = !editar;
            this.tSBBancoCheque.Editable = !editar;
            this.txtNroCheque.ReadOnly = editar;
            this.dtpFechaPago.Enabled = !editar;
            this.dtpFechaDeposito.Enabled = !editar;
            this.txtBoletaDepNro.ReadOnly = editar;
            this.tSBPresupuesto.Editable = !editar;
            this.txtFechaRecibo.ReadOnly = editar;
            this.dtpFechaRecibo.Enabled = !editar;
            this.txtNroRecibo.ReadOnly = editar;
            this.txtFechaNotaCredito.ReadOnly = editar;
            this.txtFechaNotaCredito.BackColor = SystemColors.Window;
            this.dtpFechaNotaCredito.Enabled = !editar;
            this.txtNotaCreditoNro.ReadOnly = editar;
            this.txtNotaCreditoNro.BackColor = SystemColors.Window;
            this.txtReferenciaNotaCredito.ReadOnly = editar;
            this.txtReferenciaNotaCredito.BackColor = SystemColors.Control;
            this.txtNotaCreditoCuerpo.ReadOnly = editar;
            this.txtNotaCreditoCuerpo.BackColor = SystemColors.Control;

            if ((this.FormEditStatus == EDIT)
                && (Convert.ToInt32(this.tSBFormaPago.KeyMember) == FORMAPAGO_NOTACREDITOPRESUPUESTO))
            {
                this.txtNotaCreditoNro.ReadOnly = true;
                this.txtNotaCreditoNro.BackColor = SystemColors.Control;
                this.txtReferenciaNotaCredito.ReadOnly = true;
                this.txtReferenciaNotaCredito.BackColor = SystemColors.Control;
                this.txtFechaNotaCredito.ReadOnly = true;
                this.txtFechaNotaCredito.BackColor = SystemColors.Control;
                this.dtpFechaNotaCredito.Enabled = false;
            }

            this.tbbAnular.Enabled = this.FormEditStatus == BROWSE;
            this.tbbActualizar.Enabled = this.FormEditStatus == BROWSE;
            this.tbbExportarExcel.Enabled = this.FormEditStatus == BROWSE;

            //if ((this.FormEditStatus != BROWSE)
            //    && (Convert.ToInt32(this.tSBFormaPago.KeyMember) == FORMAPAGO_NOTACREDITOPRESUPUESTO))
            //{
            //    this.txtReferenciaNotaCredito.ReadOnly = false;
            //    this.txtReferenciaNotaCredito.BackColor = SystemColors.Window;
            //    this.txtNotaCreditoCuerpo.ReadOnly = false;
            //    this.txtNotaCreditoCuerpo.BackColor = SystemColors.Window;
            //}
        }
        #endregion ReadOnly condicional

        #region Limpiar Datos
        private void limpiarDatos()
        {
            this.txtPagoID.Text = "";
            this.txtIDPagoMultiple.Text = "";
            this.txtPresupuestoCabID.Text = "";
            this.txtNroPresupuesto.Text = "";
            this.txtNroFactura.Text = "";
            this.txtFechaPago.Text = "";
            this.tSBFormaPago.Clear();
            this.tSBRespCobroExterior.Clear();
            this.tSBMoneda.Clear();
            this.txtMontoPago.Clear();
            this.txtGastoBancario.Text = "";
            this.txtReferencia.Text = "";
            this.txtFechaDeposito.Text = "";
            this.txtBoletaDepNro.Text = String.Empty;
            this.tSBBancoDeposito.Clear();
            this.tSBCuentaDeposito.Clear();
            this.tSBBancoCheque.Clear();
            this.txtNroCheque.Text = "";
            this.txtFechaRecibo.Text = "";
            this.txtFechaNotaCredito.Text = "";
            this.txtNroRecibo.Text = "";
            this.txtNotaCreditoNro.Text = "";
            this.txtReferenciaNotaCredito.Text = "";
            this.txtNotaCreditoCuerpo.Text = "";
            this.txtIdNotaCredito.Text = "";
            this.tSBPresupuesto.Clear();
            this.txtClienteID.Text = "";
            this.txtClienteNombre.Text = "";
            this.txtEstado.Text = "";
            this.txtSaldo.Text = "";
            this.txtMonedaID.Text = "";
            this.txtMonedaDescrip.Text = "";
            this.lblAutorizacionVigente.Visible = false;
            this.tSBNotaCredito.Clear();
            this.tSBNotaCredito.Visible = false;
            this.lblNCTotal.Visible = false;
            this.txtNCTotal.Visible = false;
            this.txtNCTotal.Text = "";
            this.lblNCSaldo.Visible = false;
            this.txtNCSaldo.Visible = false;
            this.txtNCSaldo.Text = "";
            this.txtNotaCreditoNro.Visible = true;
            this.txtIdNotaCredito.Text = "";
            this.txtGeneradoPorID.Text = string.Empty;
            this.txtGeneradoPorNombre.Text = string.Empty;
        }
        #endregion Limpiar Datos

        #region CRUD
        //private void EliminarRegistro()
        //{
        //    bool success = false;
        //    using (var context = new BerkeDBEntities())
        //    {
        //        using (var dbContextTransaction = context.Database.BeginTransaction())
        //        {
        //            try
        //            {
        //                this.eliminaArea(context);
        //                context.SaveChanges();
        //                dbContextTransaction.Commit();
        //                success = true;
        //            }
        //            catch (Exception ex)
        //            {
        //                dbContextTransaction.Rollback();
        //                MessageBox.Show("Ocurrió un error al eliminar el registro: "
        //                                + ex.Message + Environment.NewLine
        //                                + ex.InnerException,
        //                                "Error al eliminar los datos",
        //                                MessageBoxButtons.OK,
        //                                MessageBoxIcon.Stop);
        //            }
        //        }
        //        if (success)
        //        {
        //            this.limpiarDatos();
        //            this.FilterEntity(this.WhereString, this.FilterParam);
        //            this.FormEditStatus = BROWSE;
        //            MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //}

        private void CargarPago(DataGridViewRow row)
        {
            this.limpiarDatos();

            #region Datos Generales
            this.txtPagoID.Text = row.Cells[CAMPO_PAGOPRESUPUESTOID].Value.ToString();
            this.txtIDPagoMultiple.Text = row.Cells[CAMPO_PAGOMULTIPLEID].Value != null ? row.Cells[CAMPO_PAGOMULTIPLEID].Value.ToString() : "";
            this.tSBPresupuesto.KeyMember = row.Cells[CAMPO_PRESUPUESTOCABID].Value.ToString();

            string presupuestoDisplay = "";
            if (row.Cells[CAMPO_NROPRESUPUESTO].Value != null)
                presupuestoDisplay = row.Cells[CAMPO_NROPRESUPUESTO].Value.ToString();

            presupuestoDisplay += presupuestoDisplay != "" ? " - " : "";

            this.tSBPresupuesto.DisplayMember = presupuestoDisplay + row.Cells[CAMPO_TRAMITEDESCRIPCION].Value.ToString();
            
            //this.tSBPresupuesto.DisplayMember = row.Cells[CAMPO_NROPRESUPUESTO].Value.ToString() + " - " + row.Cells[CAMPO_TRAMITEDESCRIPCION].Value.ToString();
            
            this.txtNroPresupuesto.Text = row.Cells[CAMPO_NROPRESUPUESTO].Value != null ? row.Cells[CAMPO_NROPRESUPUESTO].Value.ToString() : "";
            this.txtNroFactura.Text = row.Cells[CAMPO_FACTURANRO].Value != null ? row.Cells[CAMPO_FACTURANRO].Value.ToString() : "";
            this.txtFechaPago.Text = Convert.ToDateTime(row.Cells[CAMPO_FECHAPAGO].Value.ToString()).ToShortDateString();
            this.txtPresupuestoCabID.Text = row.Cells[CAMPO_PRESUPUESTOCABID].Value.ToString();
            this.tSBFormaPago.KeyMember = row.Cells[CAMPO_FORMAPAGOID].Value.ToString();
            this.tSBFormaPago.DisplayMember = row.Cells[CAMPO_FORMAPAGODESCRIP].Value.ToString();

            if (row.Cells[CAMPO_RESPCOBROEXTID].Value != null)
            {
                this.tSBRespCobroExterior.KeyMember = row.Cells[CAMPO_RESPCOBROEXTID].Value.ToString();
                this.tSBRespCobroExterior.DisplayMember = row.Cells[CAMPO_RESPCOBROEXTNOMBRE].Value.ToString();
            }

            this.txtMonedaID.Text = row.Cells[CAMPO_MONEDAID].Value.ToString();
            this.txtMonedaDescrip.Text = row.Cells[CAMPO_MONEDADESCRIP].Value.ToString();
            this.txtMontoPago.Text = String.Format("{0:0.00}", (decimal)row.Cells[CAMPO_MONTOPAGO].Value);
            this.txtReferencia.Text = row.Cells[CAMPO_REFERENCIA].Value != null ? row.Cells[CAMPO_REFERENCIA].Value.ToString() : "";
            this.txtClienteID.Text = row.Cells[CAMPO_CLIENTEID].Value.ToString();
            this.txtClienteNombre.Text = row.Cells[CAMPO_CLIENTENOMBRE].Value.ToString();
            this.lblAutorizacionVigente.Visible = (bool)row.Cells[CAMPO_AUTORIZACIONVIG].Value;
            this.txtEstado.Text = !(bool)row.Cells[CAMPO_ANULADO].Value ? "Activo" : "Anulado";
            this.txtSaldo.Text = row.Cells[CAMPO_SALDO].Value.ToString();
            this.txtGeneradoPorID.Text = row.Cells[CAMPO_USUARIOCARGAID].Value.ToString();
            this.txtGeneradoPorNombre.Text = row.Cells[CAMPO_USUARIOCARGANOMBRE].Value.ToString();
            #endregion Datos Generales

            #region Depósito
            this.txtFechaDeposito.Text = row.Cells[CAMPO_FECHABOLETADEP].Value != null
                                            ? Convert.ToDateTime(row.Cells[CAMPO_FECHABOLETADEP].Value.ToString()).ToShortDateString()
                                            : "";

            if (row.Cells[CAMPO_BANCODEPID].Value != null)
            {
                this.tSBBancoDeposito.KeyMember = row.Cells[CAMPO_BANCODEPID].Value.ToString();
                this.tSBBancoDeposito.DisplayMember = row.Cells[CAMPO_BANCODEPNOMBRE].Value.ToString();
            }

            if (row.Cells[CAMPO_CUENTADEPOSITO].Value != null)
            {
                this.tSBCuentaDeposito.KeyMember = row.Cells[CAMPO_CUENTADEPOSITO].Value.ToString();
                this.tSBCuentaDeposito.DisplayMember = row.Cells[CAMPO_CUENTADEPNOMBRE].Value.ToString();
            }
            this.txtBoletaDepNro.Text = row.Cells[CAMPO_BOLETADEPNRO].Value != null ? row.Cells[CAMPO_BOLETADEPNRO].Value.ToString() : String.Empty;
            #endregion Depósito

            #region Cheque
            if (row.Cells[CAMPO_BANCOCHEQUEID].Value != null)
            {
                this.tSBBancoCheque.KeyMember = row.Cells[CAMPO_BANCOCHEQUEID].Value.ToString();
                this.tSBBancoCheque.DisplayMember = row.Cells[CAMPO_BANCOCHEQUENOMBRE].Value.ToString();
            }
            this.txtNroCheque.Text = row.Cells[CAMPO_CHEQUENRO].Value != null ? row.Cells[CAMPO_CHEQUENRO].Value.ToString() : "";
            #endregion Cheque

            #region Gasto Bancario
            if (row.Cells[CAMPO_MONEDAGASTOID].Value != null)
            {
                this.tSBMoneda.KeyMember = row.Cells[CAMPO_MONEDAGASTOID].Value.ToString();
                this.tSBMoneda.DisplayMember = row.Cells[CAMPO_MONEDAGASTODESCRIP].Value.ToString();

            }

            if (row.Cells[CAMPO_GASTOCAMBIARIO].Value != null)
            {
                this.txtGastoBancario.Text = Convert.ToInt32(row.Cells[CAMPO_GASTOCAMBIARIO].Value) > 0 
                                                ? row.Cells[CAMPO_GASTOCAMBIARIO].Value.ToString() 
                                                : "";
            }
            #endregion Gasto Bancario

            #region Recibo
            this.txtFechaRecibo.Text = row.Cells[CAMPO_FECHARECIBO].Value != null ? Convert.ToDateTime(row.Cells[CAMPO_FECHARECIBO].Value.ToString()).ToShortDateString() : "";
            this.txtNroRecibo.Text = row.Cells[CAMPO_NRORECIBO].Value != null ? row.Cells[CAMPO_NRORECIBO].Value.ToString() : "";
            #endregion Recibo

            #region Nota Crédito
            this.txtFechaNotaCredito.Text = row.Cells[CAMPO_FECHANOTACREDITO].Value != null ? Convert.ToDateTime(row.Cells[CAMPO_FECHANOTACREDITO].Value.ToString()).ToShortDateString() : "";
            this.txtNotaCreditoNro.Text = row.Cells[CAMPO_NOTACREDITONRO].Value != null ? row.Cells[CAMPO_NOTACREDITONRO].Value.ToString() : "";
            this.txtIdNotaCredito.Text = row.Cells[CAMPO_NOTACREDITOID].Value != null ? row.Cells[CAMPO_NOTACREDITOID].Value.ToString() : "";
            this.txtReferenciaNotaCredito.Text = row.Cells[CAMPO_NOTACREDITOREF].Value != null ? row.Cells[CAMPO_NOTACREDITOREF].Value.ToString() : "";
            this.txtNotaCreditoCuerpo.Text = row.Cells[CAMPO_NOTACREDITOCUERPO].Value != null ? row.Cells[CAMPO_NOTACREDITOCUERPO].Value.ToString() : "";
            #endregion Nota Crédito
        }

        private void GuardarRegistro()
        {
            bool success = false;
            bool mostrarNC = false;

            pp_pagopresupuesto pp = null;
            object [] notaCredito = null;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        pp = this.guardarPago(context);
                        context.SaveChanges();

                        #region Nota Crédito Presupuesto
                        if (Convert.ToInt32(this.tSBFormaPago.KeyMember) == FORMAPAGO_NOTACREDITOPRESUPUESTO)
                        {
                            int PagoPresupuestoID = pp.pp_pagopresupuestoid;
                            #region Caso Creación de Nota Crédito con Pago
                            if (this.tSBNotaCredito.KeyMember == "")
                            {
                                Hashtable hashPagosCabID = new Hashtable();
                                hashPagosCabID.Add(pp.pp_pagopresupuestoid, pp.pp_montopago);
                                notaCredito = GenerarNotaCredito.CrearNotaCredito(context,
                                                                                  hashPagosCabID,
                                                                                  Convert.ToDecimal(this.txtMontoPago.Text.Replace('.', ',')),
                                                                                  Convert.ToInt32(this.txtMonedaID.Text),
                                                                                  Convert.ToInt32(this.txtClienteID.Text),
                                                                                  Convert.ToDateTime(this.txtFechaNotaCredito.Text),
                                                                                  new string[] { this.txtPresupuestoCabID.Text },
                                                                                  this.txtReferenciaNotaCredito.Text,
                                                                                  this.txtNotaCreditoCuerpo.Text);
                                //int PagoPresupuestoID = pp.pp_pagopresupuestoid;
                                //context.pp_pagopresupuesto.First(a => a.pp_pagopresupuestoid == PagoPresupuestoID).pp_notacreditonro = notaCredito[0].ToString();
                                pp.pp_notacreditonro = notaCredito[0].ToString();
                                pp.pp_notacreditopresupid = (int)notaCredito[1];
                                //context.SaveChanges();
                                this.txtNotaCreditoNro.Text = notaCredito[0].ToString();
                                this.txtIdNotaCredito.Text = notaCredito[1].ToString();
                                mostrarNC = true;
                            }
                            #endregion Caso Creación de Nota Crédito con Pago
                            #region Caso Asignación de Nota Crédito con Saldo ya existente
                            else
                            {
                                int NotaCreditoID = Convert.ToInt32(this.txtIdNotaCredito.Text);
                                
                                ncd_notacreditopresupdetalle ncd = new ncd_notacreditopresupdetalle();
                                ncd.ncd_notacreditocabid = NotaCreditoID;
                                ncd.ncd_monto = Convert.ToDecimal(this.txtMontoPago.Text.Replace('.', ','));
                                ncd.ncd_pagoid = PagoPresupuestoID;
                                pp.pp_notacreditonro = this.tSBNotaCredito.DisplayMember.Split(':')[0];
                                pp.pp_notacreditopresupid = NotaCreditoID;
                                context.ncd_notacreditopresupdetalle.Add(ncd);

                                context.ncp_notacreditopresup.First(a => a.ncp_notacreditoid == NotaCreditoID).ncp_saldo -= ncd.ncd_monto;
                            }
                            #endregion Caso Asignación de Nota Crédito con Saldo ya existente
                            context.SaveChanges();
                        }
                        #endregion Nota Crédito Presupuesto

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

                        if (Convert.ToInt32(this.tSBFormaPago.KeyMember) == FORMAPAGO_NOTACREDITOPRESUPUESTO)
                        {
                            this.txtNotaCreditoNro.Text = "";
                        }

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
                if (this.FormEditStatus != BROWSE)
                    this.FilterEntity(CAMPO_PAGOPRESUPUESTOID + " = " + pp.pp_pagopresupuestoid.ToString(), null);
                    //this.FilterEntity(this.WhereString, this.FilterParam);

                this.FormEditStatus = BROWSE;
                this.CargarPago(this.dgvListadoABM.Rows[this.LastDGVIndex]);

                if (mostrarNC)//(Convert.ToInt32(this.tSBFormaPago.KeyMember) == FORMAPAGO_NOTACREDITOPRESUPUESTO)
                {
                    NotaCreditoPresupType ncCuerpo = (NotaCreditoPresupType)notaCredito[2];
                    this.MostrarNotaCredito(new List<NotaCreditoPresupType>() { ncCuerpo });
                }
                else
                    MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region Métodos de Edición de Datos
        private pp_pagopresupuesto guardarPago(BerkeDBEntities context = null)
        {
            pp_pagopresupuesto pp = new pp_pagopresupuesto();

            #region EDIT
            if (this.FormEditStatus == EDIT)
            {
                int pagoID = Convert.ToInt32(this.txtPagoID.Text);

                pp = context.pp_pagopresupuesto.First(a => a.pp_pagopresupuestoid == pagoID);

                pp.pp_presupuestocabid = Convert.ToInt32(this.txtPresupuestoCabID.Text);
                pp.pp_monedaid = Convert.ToInt32(this.txtMonedaID.Text);

                if (this.tSBBancoDeposito.KeyMember != "")
                {
                    pp.pp_bancoid = Convert.ToInt32(this.tSBBancoDeposito.KeyMember);
                }
                else
                {
                    pp.pp_bancoid = null;
                }

                if (this.tSBCuentaDeposito.KeyMember != "")
                {
                    pp.pp_cuentaid = Convert.ToInt32(this.tSBCuentaDeposito.KeyMember);
                }
                else
                {
                    pp.pp_cuentaid = null;
                }

                pp.pp_formapagoid = Convert.ToInt32(this.tSBFormaPago.KeyMember);

                if (this.tSBRespCobroExterior.KeyMember != String.Empty)
                {
                    pp.pp_respcobroextid = Convert.ToInt32(this.tSBRespCobroExterior.KeyMember);
                }
                else
                {
                    pp.pp_respcobroextid = null;
                }


                pp.pp_fechapago = Convert.ToDateTime(this.txtFechaPago.Text);
                pp.pp_nrocheque = this.txtNroCheque.Text;

                if (this.tSBBancoCheque.KeyMember != "")
                {
                    pp.pp_bancochequeid = Convert.ToInt32(this.tSBBancoCheque.KeyMember);
                }
                else
                {
                    pp.pp_bancochequeid = null;
                }

                if (this.txtGastoBancario.Text != "")
                {
                    pp.pp_gastocambiario = Convert.ToDecimal(this.txtGastoBancario.Text.Replace('.', ','));
                }

                if (this.tSBMoneda.KeyMember != "")
                {
                    pp.pp_monedagastoid = Convert.ToInt32(this.tSBMoneda.KeyMember);
                }
                else
                {
                    pp.pp_monedagastoid = null;
                }

                pp.pp_montopago = Convert.ToDecimal(this.txtMontoPago.Text.Replace('.', ','));
                pp.pp_referencia = this.txtReferencia.Text;

                if (this.txtFechaDeposito.Text != "")
                    pp.pp_fechaboletadeposito = Convert.ToDateTime(this.txtFechaDeposito.Text);

                if (this.txtBoletaDepNro.Text.Trim() != String.Empty)
                    pp.pp_nroboletadeposito = this.txtBoletaDepNro.Text;
                else
                    pp.pp_nroboletadeposito = null;

                if (this.txtFechaRecibo.Text != "")
                {
                    pp.pp_fecharecibo = Convert.ToDateTime(this.txtFechaRecibo.Text);
                    pp.pp_nrorecibo = this.txtNroRecibo.Text;
                }

                if (this.txtFechaNotaCredito.Text != "")
                {
                    pp.pp_fechanotacredito = Convert.ToDateTime(this.txtFechaNotaCredito.Text);
                    pp.pp_notacreditonro = this.txtNotaCreditoNro.Text;
                }
            }
            #endregion EDIT

            #region INSERT
            else if (this.FormEditStatus == INSERT)
            {
                pp.pp_presupuestocabid = Convert.ToInt32(this.txtPresupuestoCabID.Text);
                pp.pp_monedaid = Convert.ToInt32(this.txtMonedaID.Text);

                if (this.tSBBancoDeposito.KeyMember != "")
                {
                    pp.pp_bancoid = Convert.ToInt32(this.tSBBancoDeposito.KeyMember);
                }
                else
                {
                    pp.pp_bancoid = null;
                }

                if (this.tSBCuentaDeposito.KeyMember != "")
                {
                    pp.pp_cuentaid = Convert.ToInt32(this.tSBCuentaDeposito.KeyMember);
                }
                else
                {
                    pp.pp_cuentaid = null;
                }

                pp.pp_formapagoid = Convert.ToInt32(this.tSBFormaPago.KeyMember);

                if (this.tSBRespCobroExterior.KeyMember != String.Empty)
                {
                    pp.pp_respcobroextid = Convert.ToInt32(this.tSBRespCobroExterior.KeyMember);
                }
                else
                {
                    pp.pp_respcobroextid = null;
                }

                pp.pp_fechapago = Convert.ToDateTime(this.txtFechaPago.Text);
                pp.pp_nrocheque = this.txtNroCheque.Text;

                if (this.tSBBancoCheque.KeyMember != "")
                {
                    pp.pp_bancochequeid = Convert.ToInt32(this.tSBBancoCheque.KeyMember);
                }
                else
                {
                    pp.pp_bancochequeid = null;
                }

                if (this.txtGastoBancario.Text != "")
                {
                    pp.pp_gastocambiario = Convert.ToDecimal(this.txtGastoBancario.Text.Replace('.', ','));
                }

                if (this.tSBMoneda.KeyMember != "")
                {
                    pp.pp_monedagastoid = Convert.ToInt32(this.tSBMoneda.KeyMember);
                }
                else
                {
                    pp.pp_monedagastoid = null;
                }

                pp.pp_montopago = Convert.ToDecimal(this.txtMontoPago.Text.Replace('.', ','));
                pp.pp_referencia = this.txtReferencia.Text;

                if (this.txtFechaDeposito.Text != "")
                    pp.pp_fechaboletadeposito = Convert.ToDateTime(this.txtFechaDeposito.Text);

                if (this.txtBoletaDepNro.Text.Trim() != String.Empty)
                    pp.pp_nroboletadeposito = this.txtBoletaDepNro.Text;
                else
                    pp.pp_nroboletadeposito = null;

                if (this.txtFechaRecibo.Text != "")
                {
                    pp.pp_fecharecibo = Convert.ToDateTime(this.txtFechaRecibo.Text);
                    pp.pp_nrorecibo = this.txtNroRecibo.Text;
                }

                if (this.txtFechaNotaCredito.Text != "")
                {
                    pp.pp_fechanotacredito = Convert.ToDateTime(this.txtFechaNotaCredito.Text);
                    pp.pp_notacreditonro = this.txtNotaCreditoNro.Text;
                }
           
                context.pp_pagopresupuesto.Add(pp);
            }
            #endregion INSERT

            return pp;
        }

        private void ucCRUDPagoPresupuesto_VisibleChanged(object sender, EventArgs e)
        {
            if (this.tabListaABM.SelectedIndex == 0)
                this.FormatearGrilla();
        }

        private void tabListaABM_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (this.tablis
        }

        private void tbbAnular_Click(object sender, EventArgs e)
        {
            if (!this.lblAutorizacionVigente.Visible)
            {
                MessageBox.Show("No se puede anular el cobro debido a que no posee autorización vigente.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;

            }

            if (this.txtEstado.Text == CAMPO_ANULADO)
            {
                MessageBox.Show("No se puede anular el cobro debido a que ya se encuentra en ese estado.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            if ((Convert.ToInt32(this.tSBFormaPago.KeyMember) == FORMAPAGO_NOTACREDITOPRESUPUESTO)
                && (this.ExisteNotaCredito()))
            {
                MessageBox.Show("No se puede anular el cobro debido a que existe una nota de crédito asociada." + Environment.NewLine +
                                "Debe anular la nota de crédito para anular todos los cobros incluidos en ella.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            string message = "";
            string caption = "";
            caption = "Anulación de Cobros";
            message = "Se anulará el cobro ¿Desea continuar?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(AnularDialogHandler));
        }

        private bool ExisteNotaCredito()
        {
            bool Result = false;
            int PagoID = Convert.ToInt32(this.txtPagoID.Text);
            var query = (from ncp in this.DBContext.ncp_notacreditopresup
                         join ncd in this.DBContext.ncd_notacreditopresupdetalle
                             on ncp.ncp_notacreditoid equals ncd.ncd_notacreditocabid
                         select new { PagoID = ncd.ncd_pagoid, Anulado = ncp.ncp_anulado })
                        .Where(a => a.PagoID == PagoID && !a.Anulado).ToList();

            if (query.Count > 0)
                Result = true;

            return Result;
        }

        private void AnularDialogHandler(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    this.AnularPago(Convert.ToInt32(this.txtPagoID.Text), Convert.ToInt32(this.txtPresupuestoCabID.Text));
                }
            }
        }

        private void AnularPago(int PagoPrespuestoID, int PresupuestoCabID)
        {
            bool success = false;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        pp_pagopresupuesto pPag = context.pp_pagopresupuesto.First(a => a.pp_pagopresupuestoid == PagoPrespuestoID);
                        pPag.pp_anulado = true;

                        pc_presupuestocab pCab = context.pc_presupuestocab.First(a => a.pc_presupuestocabid == PresupuestoCabID);
                        pCab.pc_saldo += pPag.pp_montopago;
                        pCab.pc_estado = ESTADO_PENDIENTE;

                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        MessageBox.Show("Ocurrió un error al anular el cobro. "
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
                this.CargarPago(this.dgvListadoABM.Rows[this.LastDGVIndex]);
                MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pnlDetalle_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Key=NotaCreditoID; Value=NotaCreditoNro
            //Hashtable hashPagosCabID = new Hashtable();
            //hashPagosCabID.Add(Convert.ToInt32(this.txtPagoID.Text), Convert.ToDecimal(this.txtMontoPago.Text));
            //Hashtable notaCredito = GenerarNotaCredito.CrearNotaCredito(hashPagosCabID,
            //                                                            Convert.ToDecimal(this.txtMontoPago.Text),
            //                                                            Convert.ToInt32(this.txtMonedaID.Text),
            //                                                            Convert.ToInt32(this.txtClienteID.Text),
            //                                                            Convert.ToDateTime(this.txtFechaNotaCredito.Text));


        }

        private void tSBFormaPago_Leave(object sender, EventArgs e)
        {
            if ((this.tSBFormaPago.KeyMember != "") &&
                (Convert.ToInt32(this.tSBFormaPago.KeyMember) == FORMAPAGO_NOTACREDITOPRESUPUESTO))
            {
                this.txtNotaCreditoNro.ReadOnly = true;
                this.txtNotaCreditoNro.BackColor = SystemColors.Control;
                this.txtFechaNotaCredito.Text = DateTime.Now.ToShortDateString();
                //this.txtIdNotaCredito.Visible = true;
                //this.lblIDNotaCredito.Visible = true;
            }
            else
            {
                this.txtNotaCreditoNro.ReadOnly = false;
                this.txtNotaCreditoNro.BackColor = SystemColors.Window;
                this.txtFechaNotaCredito.Text = "";
                //this.txtIdNotaCredito.Visible = false;
                //this.lblIDNotaCredito.Visible = false;
            }
        }

        private void dtpFechaNotaCredito_Click(object sender, EventArgs e)
        {

        }

        private void txtFechaNotaCredito_TextChanged(object sender, EventArgs e)
        {

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

        private bool ExisteNotaCreditoConSaldo(int ClienteID, BerkeDBEntities context)
        {
            bool Result = false;
            List<ncp_notacreditopresup> listNCP = context.ncp_notacreditopresup.Where(a => a.ncp_clienteid == ClienteID
                                                                                      && a.ncp_anulado != true
                                                                                      && a.ncp_saldo > 0).ToList();
            if (listNCP.Count > 0)
                Result = true;

            return Result;

        }
        #endregion Métodos de Edición de Datos

        private void lblAutorizacionVigente_Click(object sender, EventArgs e)
        {

        }
        
        #endregion CRUD
            
    }
}