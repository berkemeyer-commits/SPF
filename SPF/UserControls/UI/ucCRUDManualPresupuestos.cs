#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Transactions;
using System.IO;
using System.Security.Principal;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Gateways;

using ModelEF6;
using SPF.Types;
using SPF.Classes;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.ObjectModel;
using System.Configuration;

using System.Data.SqlClient;
using System.Text.RegularExpressions;

using SPF.Forms.Base;
using SPF.Forms.UI;

using Net.Sgoliver.NRtfTree.Core;
using Net.Sgoliver.NRtfTree.Util;

#endregion

namespace SPF.UserControls.UI
{
    public partial class ucCRUDManualPresupuestos : ucBaseForm
    {
        #region Constantes
        private const string CAMPO_PRESUPUESTOCABID = "PresupuestoCabID";
        private const string CAMPO_MERGEDOCID = "MergeDocID";
        private const string CAMPO_SERIE = "Serie";
        private const string CAMPO_NROPRESUPUESTO = "NroPresupuesto";
        private const string CAMPO_CLIENTEID = "ClienteID";
        private const string CAMPO_CLIENTENOMBRE = "ClienteNombre";
        private const string CAMPO_ATENCIONID = "AtencionID";
        private const string CAMPO_ATENCIONOMBRE = "AtencionNombre";
        private const string CAMPO_MONEDAID = "MonedaID";
        private const string CAMPO_MONEDADESCRIP = "MonedaDescrip";
        private const string CAMPO_MONEDAABREV = "MonedaAbrev";
        private const string CAMPO_AREAID = "AreaID";
        private const string CAMPO_AREADESCRIP = "AreaDescrip";
        private const string CAMPO_USUARIOHECHOPORID = "UsuarioHechoPorID";
        private const string CAMPO_USUARIOHECHOPORNOMBRE = "UsuarioHechoPorNombre";
        private const string CAMPO_USUARIOAPROBPORID = "UsuarioAprobPorID";
        private const string CAMPO_USUARIOAPROBPORNOMBRE = "UsuarioAprobPorNombre";
        private const string CAMPO_USUARIOREEMPSOLICPORID = "UsuarioReempSolicPorID";
        private const string CAMPO_USUARIOREEMPSOLICPORNOMBRE = "UsuarioReempSolicPorNombre";
        private const string CAMPO_NROCASOPATRIX = "NroCasoPatrix";
        private const string CAMPO_MONTORECARGOAT = "MontoRecargoAT";

        private const string CAMPO_FECHAGENERACION = "FechaGeneracion";
        private const string CAMPO_TOTAL = "Total";
        private const string CAMPO_SALDO = "Saldo";
        private const string CAMPO_PARTENOMBRE = "ParteNombre";
        private const string CAMPO_CONTRAPARTENOMBRE = "ContraParteNombre";
        private const string CAMPO_ESTADO = "Estado";
        private const string CAMPO_ESTADOTEXTO = "EstadoTexto";
        private const string CAMPO_SERIENROPRESUPUESTO = "SerieNroPresupuesto";
        private const string CAMPO_FACTURANRO = "FacturaNro";
        private const string CAMPO_TRAMITEID = "TramiteID";
        private const string CAMPO_TRAMITEDESCRIPCION = "TramiteDescripcion";
        private const string CAMPO_REEMPLAZADO = "Reemplazado";
        private const string CAMPO_DESCRIPCION = "Descripcion";
        private const string CAMPO_TIMBRADO = "Timbrado";
        private const string CAMPO_RAZONSOCIALFACTURA = "RazonSocialFactura";
        private const string CAMPO_RUCFACTURA = "RUCFactura";
        private const string CAMPO_FECDOCREEMP = "FecDocReemp";
        private const string CAMPO_AUTORIZACIONVIG = "TieneAutorizacionVigente";
        private const string CAMPO_TELEFONO = "TelefonoFactura";
        private const string CAMPO_FORMPAGOID           = "FormaPagoID";
        private const string CAMPO_PRESUPCABIDSREEMPLAZO = "PresupCabIDsReemplazo";
        private const int MERGEID = 6;
        private const int TIPODOCUMENTO_PRESUPUESTO = 3;
        private const int FORMAPAGO_BAJA = 8;
        private const string ESTADO_ANULADO = "N";
        private const string ESTADO_PAGADO_TEXTO = "P = Pagado";
        private const int USUARIO_ID_HT = 7;
        
        private const string PATRICIADB_CONNSTRING = "PATRICIADB_CONNSTRING";
        private const string PAT_QRY_GETCASEID = "PAT_QRY_GETCASEID";
        private const string PAT_QRY_GETFACTURA = "PAT_QRY_GETFACTURA";
        private const string PAT_QRY_GETFACTURAFN = "PAT_QRY_GETFACTURAFN";
        private const string PAT_QRY_GETRESPONSABLE = "PAT_QRY_GETRESPONSABLE";
        private const string PAT_QRY_GETFACTURAPATH = "PAT_QRY_GETFACTURAPATH";
        private const string PAT_UPD_INVOICE_COMMENT = "PAT_UPD_INVOICE_COMMENT";

        private const string TESTMODE = "TestMode";
        private const string TESTMODE_USERNAME = "TestModeUserName";
        private const string TESTMODE_PASSWORD = "TestModePassword";
        private const string TESTMODE_DOMAIN = "TestModeDomain";

        private const string FORMATO_MONEDA_OTROS = "{0:0.00}";

        private const int ASOCIACION_MANUAL = 1;

        //private const String UPLOADFILE_URL = @"http://spf/uploadfile/uploadfile.aspx?folder={0}&filename=Presup-{1}&parentElementId=TRG_{2}&action={3}";
        private const String UPLOADFILE_URL = @"{0}uploadfile/uploadfile.aspx?folder={1}&filename=Presup-{2}&parentElementId=TRG_{3}&action={4}&extension={5}";
        private const String ACTION_UPLOAD = "U";
        private const String ACTION_UPLOAD_SAVE = "US";
        #endregion Constantes

        #region Variables
        frmPickBase fPickMoneda;
        frmPickBase fPickCliente;
        frmPickBase fPickTramite;
        frmPickBase fPickCArea;
        frmPickBase fPickEnviadoPor;
        frmPickBase fPickAutorizadoPor;
        frmPickBase fPickReempSolicPor; 
        FSeleccionarPresupuesto fSeleccionPresupAsoc;
        List<FacturaPatrixType> lFacturasPatrix;
        FSeleccionarFacturaPatrix fSF;
        string fileName = "";
        string originalFileName = "";
        private int UsuarioID = -1;
        #endregion Variables

        #region Métodos de Inicialización
        public ucCRUDManualPresupuestos()
        {
            InitializeComponent();
        }
        
        public ucCRUDManualPresupuestos(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();
            this.Titulo = Titulo;
            this.DBContext = dbContext;
            this.UsuarioID = Convert.ToInt32(VWGContext.Current.Session["UsuarioID"].ToString());

            this.tbbBorrar.Visible = false;

            var presup = (from pCab in this.DBContext.pc_presupuestocab
                          join mDoc in this.DBContext.MergeDoc
                            on pCab.pc_mergedocid equals mDoc.ID into pCab_mDoc
                          from mDoc in pCab_mDoc.DefaultIfEmpty()
                          join clie in this.DBContext.Cliente
                            on pCab.pc_clienteid equals clie.ID
                          join aten in this.DBContext.Atencion
                            on pCab.pc_atencionid equals aten.ID into pCab_aten
                          from aten in pCab_aten.DefaultIfEmpty()
                          join mone in this.DBContext.Moneda
                            on pCab.pc_monedaid equals mone.ID
                          join cAre in this.DBContext.ac_areacontabilidad
                            on pCab.pc_areaid equals cAre.ac_areacontabilidadid into pCab_cAre
                          from cAre in pCab_cAre.DefaultIfEmpty()
                          join uApr in this.DBContext.Usuario
                            on pCab.pc_autorizadopor equals uApr.ID
                          join uHec in this.DBContext.Usuario
                            on pCab.pc_enviadopor equals uHec.ID
                          join Tram in this.DBContext.Tramite
                            on pCab.pc_tramiteid equals Tram.ID
                          join uRSol in this.DBContext.Usuario
                            on pCab.pc_reempsolicporid equals uRSol.ID into pCab_uRSol
                            from uRSol in pCab_uRSol.DefaultIfEmpty()
                          join pp in this.DBContext.pp_pagopresupuesto
                            on pCab.pc_presupuestocabid equals pp.pp_presupuestocabid into pCab_pp
                            from pp in pCab_pp.DefaultIfEmpty()
                          select new PresupuestoTypeAll
                          {
                              PresupuestoCabID = pCab.pc_presupuestocabid,
                              MergeDocID = pCab.pc_mergedocid,
                              ClienteID = pCab.pc_clienteid,
                              ClienteNombre = clie.Nombre,
                              MonedaID = pCab.pc_monedaid,
                              MonedaDescrip = mone.Descripcion,
                              MonedaAbrev = mone.AbrevMoneda,
                              AreaID = pCab.pc_areaid,
                              AreaDescrip = cAre.ac_descripcionarea,
                              TramiteID = pCab.pc_tramiteid,
                              TramiteDescripcion = Tram.Descrip,
                              UsuarioHechoPorID = pCab.pc_enviadopor,
                              UsuarioHechoPorNombre = uHec.NombrePila,
                              UsuarioAprobPorID = pCab.pc_autorizadopor,
                              UsuarioAprobPorNombre = uApr.NombrePila,
                              UsuarioReempSolicPorID = pCab.pc_reempsolicporid,
                              UsuarioReempSolicPorNombre = uRSol.NombrePila,
                              FechaGeneracion = pCab.pc_fechageneracion,
                              Total = pCab.pc_total,
                              Saldo = pCab.pc_saldo,
                              SerieNroPresupuesto = pCab.pc_nropresupuesto,
                              Estado = pCab.pc_estado,
                              Origen = pCab.pc_origen,
                              Reemplazado = pCab.pc_reemplazado,
                              FacturaNro = pCab.pc_string1,
                              Descripcion = pCab.pc_descripcion,
                              Timbrado = pCab.pc_timbrado,
                              RazonSocialFactura = pCab.pc_razonsocialfactura,
                              RUCFactura = pCab.pc_rucfactura,
                              TelefonoFactura = pCab.pc_telefonofactura,
                              FecDocReemp = pCab.pc_fechadocreemplazado,
                              TieneAutorizacionVigente = this.DBContext.GetAutorizacionPorDocumentoID(TIPODOCUMENTO_PRESUPUESTO,
                                                                                                         pCab.pc_presupuestocabid,
                                                                                                         this.UsuarioID)
                                                                                                         .FirstOrDefault().Value,
                              //FormaPagoID = pp.pp_formapagoid,                        
                              NroCasoPatrix = pCab.pc_nrocasopatrix,
                              MontoRecargoAT = pCab.pc_recargoatmonto,
                              PresupCabIDsReemplazo = pCab.pc_presupcabidsreemplazo
                          })
                          .OrderByDescending(a => a.PresupuestoCabID)
                          .Take(50);

            this.BindingSourceBase = presup.ToList();

            this.dtpFechaGen.Format = DateTimePickerFormat.Short;
            this.dtpFecDocReemp.Format = DateTimePickerFormat.Short;

            this.txtRecargoAT.Text = "0,00";

            #region Especificar campos para filtro
            this.SetFilter(CAMPO_PRESUPUESTOCABID, "Presupuesto ID", false);
            this.SetFilter(CAMPO_NROCASOPATRIX, "N° Caso Patrix");
            this.SetFilter(CAMPO_SERIENROPRESUPUESTO, "N° Presupuesto");
            this.SetFilter(CAMPO_TOTAL, "Total", false);
            this.SetFilter(CAMPO_ESTADO, "Estado");
            this.SetFilter(CAMPO_FECHAGENERACION, "Fec. Generación");
            this.SetFilter(CAMPO_DESCRIPCION, "Descripción");
            this.SetFilter(CAMPO_TRAMITEID, "Trámite ID", false);
            this.SetFilter(CAMPO_TRAMITEDESCRIPCION, "Descripción Trámite");
            this.SetFilter(CAMPO_MONEDAID, "Moneda ID", false);
            this.SetFilter(CAMPO_MONEDADESCRIP, "Moneda Descrip.");
            this.SetFilter(CAMPO_FACTURANRO, "Factura N°");
            this.SetFilter(CAMPO_CLIENTEID, "Cliente ID", false);
            this.SetFilter(CAMPO_CLIENTENOMBRE, "Nombre Cliente");
            this.SetFilter(CAMPO_TIMBRADO, "Timbrado");
            this.SetFilter(CAMPO_RAZONSOCIALFACTURA, "Razón Social Factura");
            this.SetFilter(CAMPO_RUCFACTURA, "N° Presupuesto");
            this.SetFilter(CAMPO_FECDOCREEMP, "Fec. Doc. Reemp.");
            this.SetFilter(CAMPO_TELEFONO, "Teléf. Fact.");
            this.SetFilter(CAMPO_MERGEDOCID, "MergeDoc ID", false);
            this.SetFilter(CAMPO_REEMPLAZADO, "Reemplazado (S/N)", false);
            this.SetFilter(CAMPO_USUARIOREEMPSOLICPORID, "U. Sol. Reemp. ID", false);
            this.SetFilter(CAMPO_USUARIOREEMPSOLICPORNOMBRE, "U. Sol. Reemp. Nom.");
            this.TituloBuscador = "Buscar Presupuestos";
            #endregion Especificar campos para filtro

            #region Inicializar TextSearchBoxes
            this.tSBCliente.KeyMemberWidth = 70;
            this.tSBCliente.ToolTip = "Elegir Cliente";
            this.tSBCliente.AceptarClick += tSBCliente_AceptarClick;

            this.tSBMoneda.KeyMemberWidth = 50;
            this.tSBMoneda.ToolTip = "Elegir Moneda";
            this.tSBMoneda.AceptarClick += tSBMoneda_AceptarClick;

            this.tSBEnviadoPor.KeyMemberWidth = 35;
            this.tSBEnviadoPor.ToolTip = "Elegir Persona que Envía";
            this.tSBEnviadoPor.AceptarClick += tSBEnviadoPor_AceptarClick;

            this.tSBAutorizadoPor.KeyMemberWidth = 35;
            this.tSBAutorizadoPor.ToolTip = "Elegir Persona que Autoriza";
            this.tSBAutorizadoPor.AceptarClick += tSBAutorizadoPor_AceptarClick;

            this.tSBReempSolicPor.KeyMemberWidth = 35;
            this.tSBReempSolicPor.ToolTip = "Elegir Persona que Solicita Reemplazo";
            this.tSBReempSolicPor.AceptarClick += tSBReempSolicPor_AceptarClick;

            this.tSBTramite.KeyMemberWidth = 70;
            this.tSBTramite.ToolTip = "Elegir Trámite";
            this.tSBTramite.AceptarClick += tSBTramite_AceptarClick;

            this.tSBAreaContab.KeyMemberWidth = 70;
            this.tSBAreaContab.ToolTip = "Elegir Área";
            this.tSBAreaContab.AceptarClick += tSBAreaContab_AceptarClick;
            #endregion Inicializar TextSearchBoxes
        }
        #endregion Métodos de Inicialización

        #region Picks
        private void tSBAreaContab_AceptarClick(object sender, EventArgs e)
        {
            if (fPickCArea == null)
            {
                fPickCArea = new frmPickBase();
                fPickCArea.AceptarFiltrarClick += fPickCArea_AceptarFiltrarClick;
                fPickCArea.FiltrarClick += fPickCArea_FiltrarClick;
                fPickCArea.Titulo = "Elegir Area";
                fPickCArea.CampoIDNombre = "ac_areacontabilidadid";
                fPickCArea.CampoDescripNombre = "ac_descripcionarea";
                fPickCArea.LabelCampoID = "ID";
                fPickCArea.LabelCampoDescrip = "Descripción";
                fPickCArea.NombreCampo = "Area";
                fPickCArea.PermitirFiltroNulo = true;
            }
            fPickCArea.MostrarFiltro();
            fPickCArea_FiltrarClick(sender, e);
        }

        private void fPickCArea_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickCArea != null)
            {
                fPickCArea.LoadData<ac_areacontabilidad>(this.DBContext.ac_areacontabilidad, fPickCArea.GetWhereString());
            }
        }

        private void fPickCArea_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBAreaContab.DisplayMember = fPickCArea.ValorDescrip;
            this.tSBAreaContab.KeyMember = fPickCArea.ValorID;

            fPickCArea.Close();
            fPickCArea.Dispose();
        }
        
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

            if (this.tSBCliente.KeyMember != "")
            {
                int clienteID = Convert.ToInt32(this.tSBCliente.KeyMember);
                List<Cliente> cli = this.DBContext.Cliente.Where(a => a.ID == clienteID).ToList();

                if (cli.Count > 0)
                {
                    this.txtRazonSocialFactura.Text = cli.First().Nombre;
                    this.txtRUC.Text = cli.First().RUC;
                }

                this.MostrarAlerta();
            }
        }

        private void tSBTramite_AceptarClick(object sender, EventArgs e)
        {
            if (fPickTramite == null)
            {
                fPickTramite = new frmPickBase();
                fPickTramite.AceptarFiltrarClick += fPickTramite_AceptarFiltrarClick;
                fPickTramite.FiltrarClick += fPickTramite_FiltrarClick;
                fPickTramite.Titulo = "Elegir Trámite";
                fPickTramite.CampoIDNombre = "ID";
                fPickTramite.CampoDescripNombre = "Descrip";
                fPickTramite.LabelCampoID = "ID";
                fPickTramite.LabelCampoDescrip = "Descripción";
                fPickTramite.NombreCampo = "Trámite";
                fPickTramite.PermitirFiltroNulo = true;
            }
            fPickTramite.MostrarFiltro();
            this.fPickTramite_FiltrarClick(sender, e);
        }

        private void fPickTramite_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickTramite != null)
            {
                fPickTramite.LoadData<Tramite>(this.DBContext.Tramite, fPickTramite.GetWhereString());
            }
        }

        private void fPickTramite_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBTramite.DisplayMember = fPickTramite.ValorDescrip;
            this.tSBTramite.KeyMember = fPickTramite.ValorID;

            fPickTramite.Close();
            fPickTramite.Dispose();

            if (this.tSBTramite.KeyMember != "")
            {
                int tramiteID = Convert.ToInt32(this.tSBTramite.KeyMember);
                List<Tramite> tra = this.DBContext.Tramite.Where(a => a.ID == tramiteID).ToList();

                if (tra.Count > 0)
                {
                    int areaContabID = tra.First().AreaContabID.Value;
                    this.tSBAreaContab.KeyMember = tra.First().AreaContabID.ToString();
                    this.tSBAreaContab.DisplayMember = this.DBContext.ac_areacontabilidad.First(a => a.ac_areacontabilidadid == areaContabID).ac_descripcionarea;
                }
            } 
        }

        private void tSBEnviadoPor_AceptarClick(object sender, EventArgs e)
        {
            if (fPickEnviadoPor == null)
            {
                fPickEnviadoPor = new frmPickBase();
                fPickEnviadoPor.AceptarFiltrarClick += fPickEnviadoPor_AceptarFiltrarClick;
                fPickEnviadoPor.FiltrarClick += fPickEnviadoPor_FiltrarClick;
                fPickEnviadoPor.Titulo = "Elegir Persona que Envía";
                fPickEnviadoPor.CampoIDNombre = "ID";
                fPickEnviadoPor.CampoDescripNombre = "NombrePila";
                fPickEnviadoPor.LabelCampoID = "ID";
                fPickEnviadoPor.LabelCampoDescrip = "Nombre";
                fPickEnviadoPor.NombreCampo = "Usuario";
                fPickEnviadoPor.PermitirFiltroNulo = true;
            }
            fPickEnviadoPor.MostrarFiltro();
        }

        private void fPickEnviadoPor_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickEnviadoPor != null)
            {
                fPickEnviadoPor.LoadData<Usuario>(this.DBContext.Usuario, fPickEnviadoPor.GetWhereString());
            }
        }

        private void fPickEnviadoPor_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBEnviadoPor.DisplayMember = fPickEnviadoPor.ValorDescrip;
            this.tSBEnviadoPor.KeyMember = fPickEnviadoPor.ValorID;

            fPickEnviadoPor.Close();
            fPickEnviadoPor.Dispose();
        }

        private void tSBAutorizadoPor_AceptarClick(object sender, EventArgs e)
        {
            if (fPickAutorizadoPor == null)
            {
                fPickAutorizadoPor = new frmPickBase();
                fPickAutorizadoPor.AceptarFiltrarClick += fPickAutorizadoPor_AceptarFiltrarClick;
                fPickAutorizadoPor.FiltrarClick += fPickAutorizadoPor_FiltrarClick;
                fPickAutorizadoPor.Titulo = "Elegir Persona que Autoriza";
                fPickAutorizadoPor.CampoIDNombre = "ID";
                fPickAutorizadoPor.CampoDescripNombre = "NombrePila";
                fPickAutorizadoPor.LabelCampoID = "ID";
                fPickAutorizadoPor.LabelCampoDescrip = "Nombre";
                fPickAutorizadoPor.NombreCampo = "Usuario";
                fPickAutorizadoPor.PermitirFiltroNulo = true;
            }
            fPickAutorizadoPor.MostrarFiltro();
        }

        private void fPickAutorizadoPor_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickAutorizadoPor != null)
            {
                fPickAutorizadoPor.LoadData<Usuario>(this.DBContext.Usuario, fPickAutorizadoPor.GetWhereString());
            }
        }

        private void fPickAutorizadoPor_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBAutorizadoPor.DisplayMember = fPickAutorizadoPor.ValorDescrip;
            this.tSBAutorizadoPor.KeyMember = fPickAutorizadoPor.ValorID;

            fPickAutorizadoPor.Close();
            fPickAutorizadoPor.Dispose();
        }

        #region Reemplazo Solicitado Por
        private void tSBReempSolicPor_AceptarClick(object sender, EventArgs e)
        {
            if (fPickReempSolicPor == null)
            {
                fPickReempSolicPor = new frmPickBase();
                fPickReempSolicPor.AceptarFiltrarClick += fPickReempSolicPor_AceptarFiltrarClick;
                fPickReempSolicPor.FiltrarClick += fPickReempSolicPor_FiltrarClick;
                fPickReempSolicPor.Titulo = "Elegir Persona que Solicitad Reemplazo";
                fPickReempSolicPor.CampoIDNombre = "ID";
                fPickReempSolicPor.CampoDescripNombre = "NombrePila";
                fPickReempSolicPor.LabelCampoID = "ID";
                fPickReempSolicPor.LabelCampoDescrip = "Nombre";
                fPickReempSolicPor.NombreCampo = "Usuario";
                fPickReempSolicPor.PermitirFiltroNulo = true;
            }
            fPickReempSolicPor.MostrarFiltro();
        }

        private void fPickReempSolicPor_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickReempSolicPor != null)
            {
                fPickReempSolicPor.LoadData<Usuario>(this.DBContext.Usuario, fPickReempSolicPor.GetWhereString());
            }
        }

        private void fPickReempSolicPor_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBReempSolicPor.DisplayMember = fPickReempSolicPor.ValorDescrip;
            this.tSBReempSolicPor.KeyMember = fPickReempSolicPor.ValorID;

            fPickReempSolicPor.Close();
            fPickReempSolicPor.Dispose();
        }
        #endregion Reemplazo Solicitado Por
        #endregion Picks

        #region Método Extendidos del ParentControl
        protected override void FormatearGrilla()
        {
            base.FormatearGrilla();

            foreach (DataGridViewColumn col in this.dgvListadoABM.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }
            
            int displayIndex = 0;

            this.dgvListadoABM.Columns[CAMPO_PRESUPUESTOCABID].HeaderText = "Presup. ID";
            this.dgvListadoABM.Columns[CAMPO_PRESUPUESTOCABID].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_PRESUPUESTOCABID].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_PRESUPUESTOCABID].Visible = true;
            displayIndex++;
            
            this.dgvListadoABM.Columns[CAMPO_FECHAGENERACION].HeaderText = "Fec. Generación";
            this.dgvListadoABM.Columns[CAMPO_FECHAGENERACION].Width = 120;
            this.dgvListadoABM.Columns[CAMPO_FECHAGENERACION].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_FECHAGENERACION].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_FECDOCREEMP].HeaderText = "Fec. Doc. Reemp.";
            this.dgvListadoABM.Columns[CAMPO_FECDOCREEMP].Width = 120;
            this.dgvListadoABM.Columns[CAMPO_FECDOCREEMP].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_FECDOCREEMP].Visible = true;
            displayIndex++;


            this.dgvListadoABM.Columns[CAMPO_SERIENROPRESUPUESTO].HeaderText = "N° Presupuesto";
            this.dgvListadoABM.Columns[CAMPO_SERIENROPRESUPUESTO].Width = 120;
            this.dgvListadoABM.Columns[CAMPO_SERIENROPRESUPUESTO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_SERIENROPRESUPUESTO].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_FACTURANRO].HeaderText = "N° Factura";
            this.dgvListadoABM.Columns[CAMPO_FACTURANRO].Width = 120;
            this.dgvListadoABM.Columns[CAMPO_FACTURANRO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_FACTURANRO].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_CLIENTENOMBRE].HeaderText = "Cliente";
            this.dgvListadoABM.Columns[CAMPO_CLIENTENOMBRE].Width = 250;
            this.dgvListadoABM.Columns[CAMPO_CLIENTENOMBRE].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_CLIENTENOMBRE].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_TOTAL].HeaderText = "Total";
            this.dgvListadoABM.Columns[CAMPO_TOTAL].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_TOTAL].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_TOTAL].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_TOTAL].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_SALDO].HeaderText = "Saldo";
            this.dgvListadoABM.Columns[CAMPO_SALDO].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_SALDO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_SALDO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_SALDO].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_MONEDAABREV].HeaderText = "Moneda";
            this.dgvListadoABM.Columns[CAMPO_MONEDAABREV].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_MONEDAABREV].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_ESTADOTEXTO].HeaderText = "Estado";
            this.dgvListadoABM.Columns[CAMPO_ESTADOTEXTO].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_ESTADOTEXTO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_ESTADOTEXTO].Visible = true;
            displayIndex++;

        }
                
        protected override void FilterEntity(string where = "", object[] filterParams = null)
        {
            try
            {
                this.limpiarDatos();

                var query = (from pCab in this.DBContext.pc_presupuestocab
                             join mDoc in this.DBContext.MergeDoc
                               on pCab.pc_mergedocid equals mDoc.ID into pCab_mDoc
                             from mDoc in pCab_mDoc.DefaultIfEmpty()
                             join clie in this.DBContext.Cliente
                               on pCab.pc_clienteid equals clie.ID
                             join aten in this.DBContext.Atencion
                               on pCab.pc_atencionid equals aten.ID into pCab_aten
                             from aten in pCab_aten.DefaultIfEmpty()
                             join mone in this.DBContext.Moneda
                               on pCab.pc_monedaid equals mone.ID
                             join cAre in this.DBContext.ac_areacontabilidad
                               on pCab.pc_areaid equals cAre.ac_areacontabilidadid into pCab_cAre
                             from cAre in pCab_cAre.DefaultIfEmpty()
                             join uApr in this.DBContext.Usuario
                               on pCab.pc_autorizadopor equals uApr.ID
                             join uHec in this.DBContext.Usuario
                               on pCab.pc_enviadopor equals uHec.ID
                             join Tram in this.DBContext.Tramite
                               on pCab.pc_tramiteid equals Tram.ID
                             join uRSol in this.DBContext.Usuario
                                on pCab.pc_reempsolicporid equals uRSol.ID into pCab_uRSol
                                from uRSol in pCab_uRSol.DefaultIfEmpty()
                             join pp in this.DBContext.pp_pagopresupuesto
                                on pCab.pc_presupuestocabid equals pp.pp_presupuestocabid into pCab_pp
                                from pp in pCab_pp.DefaultIfEmpty()
                             select new PresupuestoTypeAll
                             {
                                 PresupuestoCabID = pCab.pc_presupuestocabid,
                                 MergeDocID = pCab.pc_mergedocid,
                                 ClienteID = pCab.pc_clienteid,
                                 ClienteNombre = clie.Nombre,
                                 MonedaID = pCab.pc_monedaid,
                                 MonedaDescrip = mone.Descripcion,
                                 MonedaAbrev = mone.AbrevMoneda,
                                 AreaID = pCab.pc_areaid,
                                 AreaDescrip = cAre.ac_descripcionarea,
                                 TramiteID = pCab.pc_tramiteid,
                                 TramiteDescripcion = Tram.Descrip,
                                 UsuarioHechoPorID = pCab.pc_enviadopor,
                                 UsuarioHechoPorNombre = uHec.NombrePila,
                                 UsuarioAprobPorID = pCab.pc_autorizadopor,
                                 UsuarioAprobPorNombre = uApr.NombrePila,
                                 UsuarioReempSolicPorID = pCab.pc_reempsolicporid,
                                 UsuarioReempSolicPorNombre = uRSol.NombrePila,
                                 FechaGeneracion = pCab.pc_fechageneracion,
                                 Total = pCab.pc_total,
                                 Saldo = pCab.pc_saldo,
                                 SerieNroPresupuesto = pCab.pc_nropresupuesto,
                                 Estado = pCab.pc_estado,
                                 Origen = pCab.pc_origen,
                                 Reemplazado = pCab.pc_reemplazado,
                                 FacturaNro = pCab.pc_string1,
                                 Descripcion = pCab.pc_descripcion,
                                 Timbrado = pCab.pc_timbrado,
                                 RazonSocialFactura = pCab.pc_razonsocialfactura,
                                 RUCFactura = pCab.pc_rucfactura,
                                 TelefonoFactura = pCab.pc_telefonofactura,
                                 FecDocReemp = pCab.pc_fechadocreemplazado,
                                 TieneAutorizacionVigente = this.DBContext.GetAutorizacionPorDocumentoID(TIPODOCUMENTO_PRESUPUESTO,
                                                                                                            pCab.pc_presupuestocabid,
                                                                                                            this.UsuarioID)
                                                                                                            .FirstOrDefault().Value,
                                //FormaPagoID = pp.pp_formapagoid,
                                NroCasoPatrix = pCab.pc_nrocasopatrix,
                                MontoRecargoAT = pCab.pc_recargoatmonto,
                                PresupCabIDsReemplazo = pCab.pc_presupcabidsreemplazo
                             });

                if (where != "")
                {
                    this.BindingSourceBase = query.Where(where, filterParams).OrderByDescending(a => a.PresupuestoCabID).Distinct().ToList();
                }
                else
                {
                    this.BindingSourceBase = query.OrderByDescending(a => a.PresupuestoCabID).Take(50).ToList();
                }

                this.FormatearGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al filtrar los datos: " + Environment.NewLine + ex.Message, "Información de Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        protected override void tbbNuevo_Click(object sender, EventArgs e)
        {
            base.tbbNuevo_Click(sender, e);
            this.limpiarDatos();
            this.txtFechaGen.Text = System.DateTime.Now.ToShortDateString();
            this.txtTotal.Text = "0,00";
            this.txtSaldo.Text = "0,00";
            this.txtNroPresupuesto.Focus();

            //this.EmptyPatrixDirectory();
        }

        protected override void tbbEditar_Click(object sender, EventArgs e)
        {
            if (this.TienePagosAsociados(Convert.ToInt32(this.txtPresupID.Text), this.DBContext))
            {
                MessageBox.Show("No se pueden realizar modificaciones debido a que el documento ya tiene cobros asociados.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }
            base.tbbEditar_Click(sender, e);
        }

        private void txtRecargoAT_Leave(object sender, EventArgs e)
        {
            if (this.FormEditStatus != BROWSE)
            {
                decimal valor;
                if (!decimal.TryParse(this.txtRecargoAT.Text, out valor))
                    this.txtRecargoAT.Text = "0,00";
                else
                    this.txtRecargoAT.Text = String.Format("{0:0.00}", valor);
            }
        }

        protected override void txtFormEditStatus_TextChanged(object sender, EventArgs e)
        {
            base.txtFormEditStatus_TextChanged(sender, e);

            if (this.FormEditStatus == INSERT)
                this.grpSubirDoc.Visible = true;
            else
                this.grpSubirDoc.Visible = false;

            if (this.FormEditStatus != BROWSE)
            {
                this.tbbUploadDoc.Enabled = false;
                this.tbbDownloadDoc.Enabled = false;
            }
            else
            {
                this.tbbUploadDoc.Enabled = true;
                this.tbbDownloadDoc.Enabled = true;
            }

        }
        
        #endregion Método Extendidos del ParentControl

        #region Limpiar Datos
        private void limpiarDatos()
        {
            this.txtPresupID.Text = "";
            this.txtNroPresupuesto.Text = "";
            this.txtNroCasoPatrix.Text = String.Empty;
            this.txtRecargoAT.Text = String.Empty;
            this.txtFechaGen.Text = "";
            this.txtFecDocReemp.Text = "";
            this.tSBMoneda.Clear();
            this.txtTotal.Text = "";
            this.txtSaldo.Text = "";
            this.tSBCliente.Clear();
            this.tSBTramite.Clear();
            this.tSBAreaContab.Clear();
            this.tSBEnviadoPor.Clear();
            this.tSBAutorizadoPor.Clear();
            this.tSBReempSolicPor.Clear();
            this.txtFacturaNro.Text = "";
            this.chkReemplazado.Checked = false;
            this.txtDescripcion.Text = "";
            this.txtRazonSocialFactura.Text = "";
            this.txtRUC.Text = "";
            this.txtTimbrado.Text = "";
            this.txtTelefono.Text = "";
            this.txtMergeDocID.Text = "";
            this.txtDocPath.Text = "";
            this.fileName = "";
            this.txtPatrixInvoiceID.Text = String.Empty;
        }
        #endregion Limpiar Datos

        #region ReadOnly condicional
        protected override void Editable(bool editar)
        {
            this.txtPresupID.ReadOnly = editar;
            this.txtNroPresupuesto.ReadOnly = editar;
            this.txtNroCasoPatrix.ReadOnly = editar;
            this.txtFechaGen.ReadOnly = editar;
            this.dtpFechaGen.Enabled = !editar;
            this.tSBMoneda.Editable = !editar;
            this.txtTotal.ReadOnly = editar;
            this.txtSaldo.ReadOnly = editar;
            this.tSBCliente.Editable = !editar;
            this.tSBTramite.Editable = !editar;
            this.tSBAreaContab.Editable = !editar;
            this.tSBEnviadoPor.Editable = !editar;
            this.tSBAutorizadoPor.Editable = !editar;
            this.tSBReempSolicPor.Editable = !editar;
            this.txtFacturaNro.ReadOnly = editar;
            this.chkReemplazado.Enabled = !editar;
            this.txtDescripcion.ReadOnly = editar;
            this.txtRazonSocialFactura.ReadOnly = editar;
            this.txtRUC.ReadOnly = editar;
            this.txtTimbrado.ReadOnly = editar;
            this.txtTelefono.ReadOnly = editar;
            this.txtMergeDocID.ReadOnly = editar;
            this.txtRecargoAT.ReadOnly = editar;
            this.btnObtenerCasoPatricia.Enabled = !editar;
            this.btnBuscar.Enabled = !editar;
            
            if (this.chkReemplazado.Checked)
            {
                this.txtFecDocReemp.ReadOnly = editar;
                this.dtpFecDocReemp.Enabled = !editar;
            }
            else
            {
                this.txtFecDocReemp.ReadOnly = true;
                this.dtpFecDocReemp.Enabled = false;
            }

            //this.btnBuscar.Enabled = !editar;
        }
        #endregion ReadOnly condicional

        #region Controles Locales
        private void tbbUploadDoc_Click(object sender, EventArgs e)
        {
            /*
               D E S H A B I L I T A C I O N  T E M P O R A L
                                                                */
            //if (!this.lblAutorizacionVigente.Visible)
            //{
            //    MessageBox.Show("No se puede procesar la solicitud debido a que no posee autorización vigente.",
            //                    "Información",
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Information);
            //    return;

            //}

            //this.OpenDialogFileUpload();
            this.OpenPopup(ACTION_UPLOAD_SAVE);
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

        private void tbbDownloadDoc_Click(object sender, EventArgs e)
        {
            //string[] listaDocs = this.GetMergeDocIDSeleccionados();
            string[] listaDocs = null;
            byte[] binaryFile;

            //string path = VWGContext.Current.Server.MapPath(@VWGContext.Current.Session["PresupFolderURL"].ToString());
            string path = VWGContext.Current.Server.MapPath(@"\Resources\UserData\" + VWGContext.Current.Session["WindowsUser"].ToString() + @"\");
            
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(@path);
            }

            if (listaDocs != null)
            {
                foreach (string MergeDocID in listaDocs)
                {
                    int mDocID = Convert.ToInt32(MergeDocID);
                    MergeDoc mDoc = this.DBContext.MergeDoc.First(a => a.ID == mDocID);
                    binaryFile = mDoc.Contenido;
                    string extension = mDoc.Extension != null ? mDoc.Extension : ".doc";
                    string lfileName = @path + MergeDocID + extension;//".doc";
                    Berke.Libs.Base.Helpers.Files.SaveBytesToFile(binaryFile, @lfileName);
                    DownloadGateway download = new DownloadGateway(@lfileName);
                    download.StartDownload(this);
                }
            }
            else
            {
                if ((this.txtMergeDocID.Text != "") && (this.txtEstado.Text.Split('=')[0].Trim() != ESTADO_ANULADO))
                {
                    int mDocID = Convert.ToInt32(this.txtMergeDocID.Text);

                    MergeDoc mDoc = this.DBContext.MergeDoc.First(a => a.ID == mDocID);
                    ((IObjectContextAdapter)this.DBContext).ObjectContext.Refresh(System.Data.Entity.Core.Objects.RefreshMode.ClientWins, mDoc);

                    binaryFile = mDoc.Contenido;
                    string extension = mDoc.Extension != null ? mDoc.Extension : ".doc";

                    //binaryFile = this.DBContext.MergeDoc.First(a => a.ID == mDocID).Contenido;
                    string lfileName = @path + this.txtMergeDocID.Text + extension;// ".doc";
                    Berke.Libs.Base.Helpers.Files.SaveBytesToFile(binaryFile, @lfileName);
                    DownloadGateway download = new DownloadGateway(@lfileName);
                    download.StartDownload(this);
                }
            }
        }

        private void ucCRUDManualPresupuestos_VisibleChanged(object sender, EventArgs e)
        {
            if (this.tabListaABM.SelectedIndex == 0)
                this.FormatearGrilla();
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            //this.OpenDialogFileUpload();
            this.OpenPopup(ACTION_UPLOAD);
        }

        private void OpenPopup(String action)
        {
            string baseUrl = this.GetBaseURL(VWGContext.Current.HttpContext);
            
            object[] jsParams = new object[6];
            //jsParams[0] = String.Format(UPLOADFILE_URL, VWGContext.Current.Session["UserName"], DateTime.Now.Ticks.ToString(), this.txtDocPath.ID.ToString(), action);
            jsParams[0] = String.Format(UPLOADFILE_URL, baseUrl, VWGContext.Current.Session["UserName"], DateTime.Now.Ticks.ToString(), this.txtDocPath.ID.ToString(), action, String.Empty);
            jsParams[1] = "";
            jsParams[2] = 500;
            jsParams[3] = 200;
            jsParams[4] = this.ID.ToString();
            jsParams[5] = this.txtDocPath.ID.ToString();

            VWGClientContext.Current.Invoke("PopupCenterCustom", jsParams);

            return;
        }

        private string GetBaseURL(System.Web.HttpContext context)
        {
            string baseUrl = context.Request.Url.Scheme + "://" + context.Request.Url.Authority + '/'; // + context.Request.ApplicationPath.TrimEnd('/') + '/';
            return baseUrl;
        }


        private void dgvListadoABM_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this.FormEditStatus == BROWSE)
            {
                if (this.dgvListadoABM.RowCount > 0)
                {
                    this.cargarDatos(this.dgvListadoABM.Rows[e.RowIndex]);
                }
                else
                    this.limpiarDatos();
            }
            //this.limpiarDatos();
            //this.txtPresupID.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_PRESUPUESTOCABID].Value.ToString();
            //this.txtNroPresupuesto.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_SERIENROPRESUPUESTO].Value != null
            //                                ? ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_SERIENROPRESUPUESTO].Value.ToString()
            //                                : "";
            //this.txtEstado.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_ESTADO].Value.ToString();
            //this.txtFechaGen.Text = Convert.ToDateTime(((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_FECHAGENERACION].Value.ToString()).ToShortDateString();
            //this.chkReemplazado.Checked = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_REEMPLAZADO].Value != null
            //                                ? (bool)((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_REEMPLAZADO].Value
            //                                : false;
            //this.txtFacturaNro.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_FACTURANRO].Value != null
            //                                ? ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_FACTURANRO].Value.ToString()
            //                                : "";
            //this.txtTotal.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TOTAL].Value != null
            //                        ? ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TOTAL].Value.ToString()
            //                        : "";
            //this.txtSaldo.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_SALDO].Value != null
            //                        ? ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_SALDO].Value.ToString()
            //                        : "";
            //if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_MONEDAID].Value != null)
            //{
            //    this.tSBMoneda.KeyMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_MONEDAID].Value.ToString();
            //    this.tSBMoneda.DisplayMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_MONEDADESCRIP].Value.ToString();
            //}

            //if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_CLIENTEID].Value != null)
            //{
            //    this.tSBCliente.KeyMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_CLIENTEID].Value.ToString();
            //    this.tSBCliente.DisplayMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_CLIENTENOMBRE].Value.ToString();
            //}

            //if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TRAMITEID].Value != null)
            //{
            //    this.tSBTramite.KeyMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TRAMITEID].Value.ToString();
            //    this.tSBTramite.DisplayMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TRAMITEDESCRIPCION].Value.ToString();
            //}

            //if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_AREAID].Value != null)
            //{
            //    this.tSBAreaContab.KeyMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_AREAID].Value.ToString();
            //    this.tSBAreaContab.DisplayMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_AREADESCRIP].Value.ToString();
            //}

            //if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_USUARIOHECHOPORID].Value != null)
            //{
            //    this.tSBEnviadoPor.KeyMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_USUARIOHECHOPORID].Value.ToString();
            //    this.tSBEnviadoPor.DisplayMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_USUARIOHECHOPORNOMBRE].Value.ToString();
            //}

            //if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_USUARIOAPROBPORID].Value != null)
            //{
            //    this.tSBAutorizadoPor.KeyMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_USUARIOAPROBPORID].Value.ToString();
            //    this.tSBAutorizadoPor.DisplayMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_USUARIOAPROBPORNOMBRE].Value.ToString();
            //}

            //this.txtDescripcion.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_DESCRIPCION].Value != null
            //                                ? ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_DESCRIPCION].Value.ToString()
            //                                : "";
            //this.txtRazonSocialFactura.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_RAZONSOCIALFACTURA].Value != null
            //                                ? ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_RAZONSOCIALFACTURA].Value.ToString()
            //                                : "";

            //this.txtRUC.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_RUCFACTURA].Value != null
            //                                ? ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_RUCFACTURA].Value.ToString()
            //                                : "";

            //this.txtTimbrado.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TIMBRADO].Value != null
            //                                ? ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TIMBRADO].Value.ToString()
            //                                : "";


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

            if (this.chkReemplazado.Checked)
            {
                if ((this.txtFecDocReemp.Text == "") ||  (this.txtNroPresupuesto.Text == "") || (this.txtFacturaNro.Text == ""))
                {
                    string msg = "Para cargar un reemplazo, debe indicar obligatoriamente: " + Environment.NewLine +
                                 "- N° Presupuesto " + Environment.NewLine +
                                 "- Fecha de Doc. Reemplazado " + Environment.NewLine +
                                 "- N° Documento reemplazado ";
                    MessageBox.Show(msg,
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                    return;
                }
            }

            decimal total = Convert.ToDecimal(this.txtTotal.Text.Replace('.', ','));
            decimal saldo = Convert.ToDecimal(this.txtSaldo.Text.Replace('.', ','));

            if (total <= 0 )
            {
                MessageBox.Show("El total del presupuesto debe ser mayor a 0 (cero).",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }



            if (saldo > total)
            {
                MessageBox.Show("El saldo no puede ser superior al importe total de la deuda.",
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
                    //else
                    //    this.EliminarRegistro();
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

        private void dtpFechaGen_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaGen.Text = this.dtpFechaGen.Value.ToShortDateString();
        }

        private void dtpFecDocReemp_ValueChanged(object sender, EventArgs e)
        {
            this.txtFecDocReemp.Text = this.dtpFecDocReemp.Value.ToShortDateString();
        }

        private void chkReemplazado_CheckedChanged(object sender, EventArgs e)
        {
            if ((this.FormEditStatus != BROWSE) && (this.chkReemplazado.Checked))
            {
                this.txtFecDocReemp.ReadOnly = false;
                this.dtpFecDocReemp.Enabled = true;
            }
            else
            {
                this.txtFecDocReemp.ReadOnly = true;
                this.dtpFecDocReemp.Enabled = false;
            }
        }

        #endregion Controles Locales

        #region CRUD

        private void cargarDatos(DataGridViewRow row)
        {
            this.limpiarDatos();
            this.txtPresupID.Text = row.Cells[CAMPO_PRESUPUESTOCABID].Value.ToString();
            this.txtNroPresupuesto.Text = row.Cells[CAMPO_SERIENROPRESUPUESTO].Value != null
                                            ? row.Cells[CAMPO_SERIENROPRESUPUESTO].Value.ToString()
                                            : "";

            this.txtNroCasoPatrix.Text = row.Cells[CAMPO_NROCASOPATRIX].Value != null
                                            ? row.Cells[CAMPO_NROCASOPATRIX].Value.ToString()
                                            : String.Empty;

            this.txtEstado.Text = row.Cells[CAMPO_ESTADOTEXTO].Value.ToString();
            this.txtFechaGen.Text = Convert.ToDateTime(row.Cells[CAMPO_FECHAGENERACION].Value.ToString()).ToShortDateString();
            this.txtFecDocReemp.Text = row.Cells[CAMPO_FECDOCREEMP].Value != null
                                            ? Convert.ToDateTime(row.Cells[CAMPO_FECDOCREEMP].Value.ToString()).ToShortDateString()
                                            : "";

            this.chkReemplazado.Checked = row.Cells[CAMPO_REEMPLAZADO].Value != null
                                            ? (bool)row.Cells[CAMPO_REEMPLAZADO].Value
                                            : false;
            this.txtFacturaNro.Text = row.Cells[CAMPO_FACTURANRO].Value != null
                                            ? row.Cells[CAMPO_FACTURANRO].Value.ToString()
                                            : "";
            this.txtTotal.Text = row.Cells[CAMPO_TOTAL].Value != null
                                    ? String.Format("{0:0.00}", (decimal)row.Cells[CAMPO_TOTAL].Value)
                                    : "";
            this.txtSaldo.Text = row.Cells[CAMPO_SALDO].Value != null
                                    ? String.Format("{0:0.00}", (decimal)row.Cells[CAMPO_SALDO].Value)
                                    : "";
            if (row.Cells[CAMPO_MONEDAID].Value != null)
            {
                this.tSBMoneda.KeyMember = row.Cells[CAMPO_MONEDAID].Value.ToString();
                this.tSBMoneda.DisplayMember = row.Cells[CAMPO_MONEDADESCRIP].Value.ToString();
            }

            if (row.Cells[CAMPO_CLIENTEID].Value != null)
            {
                this.tSBCliente.KeyMember = row.Cells[CAMPO_CLIENTEID].Value.ToString();
                this.tSBCliente.DisplayMember = row.Cells[CAMPO_CLIENTENOMBRE].Value.ToString();
            }

            if (row.Cells[CAMPO_TRAMITEID].Value != null)
            {
                this.tSBTramite.KeyMember = row.Cells[CAMPO_TRAMITEID].Value.ToString();
                this.tSBTramite.DisplayMember = row.Cells[CAMPO_TRAMITEDESCRIPCION].Value.ToString();
            }

            if (row.Cells[CAMPO_AREAID].Value != null)
            {
                this.tSBAreaContab.KeyMember = row.Cells[CAMPO_AREAID].Value.ToString();
                this.tSBAreaContab.DisplayMember = row.Cells[CAMPO_AREADESCRIP].Value.ToString();
            }

            if (row.Cells[CAMPO_USUARIOHECHOPORID].Value != null)
            {
                this.tSBEnviadoPor.KeyMember = row.Cells[CAMPO_USUARIOHECHOPORID].Value.ToString();
                this.tSBEnviadoPor.DisplayMember = row.Cells[CAMPO_USUARIOHECHOPORNOMBRE].Value.ToString();
            }

            if (row.Cells[CAMPO_USUARIOAPROBPORID].Value != null)
            {
                this.tSBAutorizadoPor.KeyMember = row.Cells[CAMPO_USUARIOAPROBPORID].Value.ToString();
                this.tSBAutorizadoPor.DisplayMember = row.Cells[CAMPO_USUARIOAPROBPORNOMBRE].Value.ToString();
            }

            if (row.Cells[CAMPO_USUARIOREEMPSOLICPORID].Value != null)
            {
                this.tSBReempSolicPor.KeyMember = row.Cells[CAMPO_USUARIOREEMPSOLICPORID].Value.ToString();
                this.tSBReempSolicPor.DisplayMember = row.Cells[CAMPO_USUARIOREEMPSOLICPORNOMBRE].Value.ToString();
            }

            this.txtDescripcion.Text = row.Cells[CAMPO_DESCRIPCION].Value != null
                                            ? row.Cells[CAMPO_DESCRIPCION].Value.ToString()
                                            : "";
            this.txtRazonSocialFactura.Text = row.Cells[CAMPO_RAZONSOCIALFACTURA].Value != null
                                            ? row.Cells[CAMPO_RAZONSOCIALFACTURA].Value.ToString()
                                            : "";

            this.txtRUC.Text = row.Cells[CAMPO_RUCFACTURA].Value != null
                                            ? row.Cells[CAMPO_RUCFACTURA].Value.ToString()
                                            : "";

            this.txtTimbrado.Text = row.Cells[CAMPO_TIMBRADO].Value != null
                                            ? row.Cells[CAMPO_TIMBRADO].Value.ToString()
                                            : "";

            this.txtTelefono.Text = row.Cells[CAMPO_TELEFONO].Value != null
                                            ? row.Cells[CAMPO_TELEFONO].Value.ToString()
                                            : "";

            this.txtMergeDocID.Text = row.Cells[CAMPO_MERGEDOCID].Value != null
                                            ? row.Cells[CAMPO_MERGEDOCID].Value.ToString()
                                            : "";

            if (row.Cells[CAMPO_MONTORECARGOAT].Value != null)
                this.txtRecargoAT.Text = String.Format("{0:0.00}", row.Cells[CAMPO_MONTORECARGOAT].Value.ToString());
            else this.txtRecargoAT.Text = "0,00";

            this.lblAutorizacionVigente.Visible = (bool)row.Cells[CAMPO_AUTORIZACIONVIG].Value;
            this.lblBaja.Visible = row.Cells[CAMPO_FORMPAGOID].Value != null ?
                ((int)row.Cells[CAMPO_FORMPAGOID].Value == FORMAPAGO_BAJA) :
                false;

            this.SetPresupuestosAsociados(this.DBContext,
                                          row.Cells[CAMPO_PRESUPCABIDSREEMPLAZO].Value != null ? row.Cells[CAMPO_PRESUPCABIDSREEMPLAZO].Value.ToString() : "");

        }

        private void GuardarRegistro()
        {
            bool success = false;

            pc_presupuestocab pCab = null;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        pCab = this.guardarPresupuesto(context);
                        context.SaveChanges();

                        if (this.fileName != "")
                        {
                            this.GuardarDoc(context, this.fileName, pCab);
                            //this.GuardarDoc(context, this.fileName, this.originalFileName, pCab);
                        }

                        if ((this.FormEditStatus == INSERT) && (pCab.pc_nropresupuesto != null) && (this.txtPatrixInvoiceID.Text != String.Empty))
                        {
                            this.ObtenerArchivoFactura(pCab.pc_nropresupuesto);
                            this.ActualizarInvoiceCommentPatrix(Convert.ToInt32(this.txtPatrixInvoiceID.Text), pCab.pc_nropresupuesto);
                        }

                        dbContextTransaction.Commit();
                        success = true;
                    }
                    catch (DbEntityValidationException e)
                    {
                        dbContextTransaction.Rollback();
                        
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

                        MessageBox.Show("Ocurrió un error al procesar el guardado: "
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
                    this.FilterEntity(CAMPO_PRESUPUESTOCABID + " = " + pCab.pc_presupuestocabid.ToString(), null);
                    this.cargarDatos(this.dgvListadoABM.Rows[0]);
                }
                else if (this.FormEditStatus == EDIT)
                    this.FilterEntity(this.WhereString, this.FilterParam);

                this.FormEditStatus = BROWSE;
                this.cargarDatos(this.dgvListadoABM.Rows[this.LastDGVIndex]);                

                MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region Métodos de Edición de Datos
        private pc_presupuestocab guardarPresupuesto(BerkeDBEntities context = null)
        {
            pc_presupuestocab pCab = new pc_presupuestocab();
            if (this.FormEditStatus == EDIT)
            {
                int presupuestoCabID = Convert.ToInt32(this.txtPresupID.Text);

                pCab = context.pc_presupuestocab.First(a => a.pc_presupuestocabid == presupuestoCabID);

                if (this.txtNroPresupuesto.Text != "")
                    pCab.pc_nropresupuesto = this.txtNroPresupuesto.Text;
                else
                    pCab.pc_nropresupuesto = null;
                
                pCab.pc_reemplazado = this.chkReemplazado.Checked;
                pCab.pc_fechageneracion = Convert.ToDateTime(this.txtFechaGen.Text);
                pCab.pc_string1 = this.txtFacturaNro.Text;
                pCab.pc_total = Convert.ToDecimal(this.txtTotal.Text.Replace('.', ','));
                pCab.pc_saldo = Convert.ToDecimal(this.txtSaldo.Text.Replace('.', ','));
                pCab.pc_monedaid = Convert.ToInt32(this.tSBMoneda.KeyMember);
                pCab.pc_clienteid = Convert.ToInt32(this.tSBCliente.KeyMember);
                pCab.pc_tramiteid = Convert.ToInt32(this.tSBTramite.KeyMember);
                pCab.pc_enviadopor = Convert.ToInt32(this.tSBEnviadoPor.KeyMember);
                pCab.pc_autorizadopor = Convert.ToInt32(this.tSBAutorizadoPor.KeyMember);

                if (this.tSBReempSolicPor.KeyMember != String.Empty)
                {
                    pCab.pc_reempsolicporid = Convert.ToInt32(this.tSBReempSolicPor.KeyMember);
                }
                else pCab.pc_reempsolicporid = null;
                //pCab.pc_origen = "C";

                if (this.txtDescripcion.Text != "")
                    pCab.pc_descripcion = this.txtDescripcion.Text;
                else
                    pCab.pc_descripcion = null;

                if (this.txtRazonSocialFactura.Text != "")
                    pCab.pc_razonsocialfactura = this.txtRazonSocialFactura.Text;
                else
                    pCab.pc_razonsocialfactura = null;

                if (this.txtRUC.Text != "")
                    pCab.pc_rucfactura = this.txtRUC.Text;
                else
                    pCab.pc_rucfactura = null;

                if (this.txtTimbrado.Text != "")
                    pCab.pc_timbrado = this.txtTimbrado.Text;
                else
                    pCab.pc_timbrado = null;

                if (this.txtTelefono.Text != "")
                    pCab.pc_telefonofactura = this.txtTelefono.Text;
                else
                    pCab.pc_telefonofactura = null;

                if (this.txtFecDocReemp.Text != "")
                    pCab.pc_fechadocreemplazado =  Convert.ToDateTime(this.txtFecDocReemp.Text);
                else
                    pCab.pc_fechadocreemplazado = null;

                if (this.txtNroCasoPatrix.Text != String.Empty)
                    pCab.pc_nrocasopatrix = this.txtNroCasoPatrix.Text;
                else
                    pCab.pc_nrocasopatrix = null;

                if (this.tSBAreaContab.KeyMember != "")
                {
                    pCab.pc_areaid = Convert.ToInt32(this.tSBAreaContab.KeyMember);
                }

                if (this.txtRecargoAT.Text != String.Empty)
                {
                    pCab.pc_recargoatmonto = Convert.ToDecimal(this.txtRecargoAT.Text);
                }
                else pCab.pc_recargoatmonto = null;

                pCab.pc_presupcabidsreemplazo = this.txtPresupIDs.Text != "" ? this.txtPresupIDs.Text : null;
            }
            else if (this.FormEditStatus == INSERT)
            {
                if (this.txtNroPresupuesto.Text != "")
                    pCab.pc_nropresupuesto = this.txtNroPresupuesto.Text;
                else if ((this.txtNroPresupuesto.Text == String.Empty) && (this.txtPatrixInvoiceID.Text != String.Empty))
                {
                    int clienteID = Convert.ToInt32(this.tSBCliente.KeyMember);
                    if (!context.Cliente.First(a => a.ID == clienteID).FacturaLocal.Value)
                    {
                        //Se obtiene el número de presupuesto                    
                        var configP = context.ConfigPresup.Where(a => a.Vigente == true).ToList();
                        
                        if (configP.Count > 1)
                        {
                            throw new Exception("No se encuentra configuración para obtener el número de presupuesto o existe más de uno vigente");
                        }

                        int configPresupID = configP.First().ID;
                        int nroPresupuesto = configP.First().Numero.Value;
                        pCab.pc_nropresupuesto = configP.First().Serie.ToString().Replace("A", "Z") + nroPresupuesto.ToString();
                        context.ConfigPresup.First(a => a.ID == configPresupID).Numero = nroPresupuesto + 1;
                    }
                    else pCab.pc_nropresupuesto = null;
                }
                else
                    pCab.pc_nropresupuesto = null;

                pCab.pc_reemplazado = this.chkReemplazado.Checked;
                pCab.pc_fechageneracion = Convert.ToDateTime(this.txtFechaGen.Text);
                pCab.pc_string1 = this.txtFacturaNro.Text;
                pCab.pc_total = Convert.ToDecimal(this.txtTotal.Text.Replace('.', ','));
                pCab.pc_saldo = Convert.ToDecimal(this.txtSaldo.Text.Replace('.', ','));
                pCab.pc_monedaid = Convert.ToInt32(this.tSBMoneda.KeyMember);
                pCab.pc_clienteid = Convert.ToInt32(this.tSBCliente.KeyMember);
                pCab.pc_tramiteid = Convert.ToInt32(this.tSBTramite.KeyMember);
                pCab.pc_enviadopor = Convert.ToInt32(this.tSBEnviadoPor.KeyMember);
                pCab.pc_autorizadopor = Convert.ToInt32(this.tSBAutorizadoPor.KeyMember);
                pCab.pc_origen = "C";
                pCab.pc_estado = "A";

                if (this.tSBReempSolicPor.KeyMember != String.Empty)
                {
                    pCab.pc_reempsolicporid = Convert.ToInt32(this.tSBReempSolicPor.KeyMember);
                }
                else pCab.pc_reempsolicporid = null;

                if (this.txtDescripcion.Text != "")
                    pCab.pc_descripcion = this.txtDescripcion.Text;
                else
                    pCab.pc_descripcion = null;

                if (this.txtRazonSocialFactura.Text != "")
                    pCab.pc_razonsocialfactura = this.txtRazonSocialFactura.Text;
                else
                    pCab.pc_razonsocialfactura = null;

                if (this.txtRUC.Text != "")
                    pCab.pc_rucfactura = this.txtRUC.Text;
                else
                    pCab.pc_rucfactura = null;

                if (this.txtTimbrado.Text != "")
                    pCab.pc_timbrado = this.txtTimbrado.Text;
                else
                    pCab.pc_timbrado = null;

                if (this.txtTelefono.Text != "")
                    pCab.pc_telefonofactura = this.txtTelefono.Text;
                else
                    pCab.pc_telefonofactura = null;

                if (this.txtFecDocReemp.Text != "")
                    pCab.pc_fechadocreemplazado = Convert.ToDateTime(this.txtFecDocReemp.Text);
                else
                    pCab.pc_fechadocreemplazado = null;

                if (this.txtNroCasoPatrix.Text != String.Empty)
                    pCab.pc_nrocasopatrix = this.txtNroCasoPatrix.Text;
                else
                    pCab.pc_nrocasopatrix = null;

                if (this.tSBAreaContab.KeyMember != "")
                {
                    pCab.pc_areaid = Convert.ToInt32(this.tSBAreaContab.KeyMember);
                }

                if (this.txtRecargoAT.Text != String.Empty)
                {
                    pCab.pc_recargoatmonto = Convert.ToDecimal(this.txtRecargoAT.Text);
                }
                else pCab.pc_recargoatmonto = null;

                pCab.pc_presupcabidsreemplazo = this.txtPresupIDs.Text != "" ? this.txtPresupIDs.Text : null;

                context.pc_presupuestocab.Add(pCab);
            }

            return pCab;
        }

        private void eliminarPresupuesto(BerkeDBEntities context = null)
        {
            int presupuestoCabID = Convert.ToInt32(this.txtPresupID.Text);
            pc_presupuestocab pCab = context.pc_presupuestocab.First(a => a.pc_presupuestocabid == presupuestoCabID);

            context.pc_presupuestocab.Remove(pCab);
        }
        #endregion Métodos de Edición de Datos

        private void txtFacturaNro_Leave(object sender, EventArgs e)
        {
            #region Validaciones

            if (this.FormEditStatus != BROWSE)
            {
                string nrofactura = this.txtFacturaNro.Text;

                if ((nrofactura != "") && (!this.ValidarNroFactura(nrofactura, this.DBContext)))
                {
                    string messageInt = "Ya existe el N° de Factura: " + nrofactura + ".";
                    string captionInt = "Advertencia";

                    MessageBox.Show(messageInt,
                                   captionInt,
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
                }

                if ((nrofactura != "") && (!this.ValidarNroPresupuesto(nrofactura, this.DBContext)))
                {
                    string messageInt = "Existe un número de presupuesto con el mismo número de factura que está ingresando: " + nrofactura + ".";
                    string captionInt = "Advertencia";

                    MessageBox.Show(messageInt,
                                   captionInt,
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
                }
            }

            #endregion Validaciones
        }
        #endregion CRUD

        #region Método de Apoyo

        private void MostrarAlerta()
        {
            if (this.tSBCliente.KeyMember != "")
            {
                List<GetSolicitudesXCliente_Result> listaSolicitudes = this.DBContext.GetSolicitudesXCliente(this.tSBCliente.KeyMember).ToList();

                if (listaSolicitudes.Count > 0)
                {
                    FSolicitudesPendientes fSP = new FSolicitudesPendientes(Convert.ToInt32(this.tSBCliente.KeyMember), this.tSBCliente.DisplayMember, listaSolicitudes);
                    fSP.FormClosed += delegate { fSP = null; };
                    fSP.Show();
                }
            }
        }

        private void SubirDocBrowse()
        {
            bool success = false;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (this.fileName != "")
                        {
                            this.GuardarDoc(context, this.fileName, null);
                        }
                        else
                            throw new Exception("Error: No se seleccionó ningún archivo.");

                        success = true;
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        MessageBox.Show("Ocurrió un error al subir el documento. "
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
                MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GuardarDoc(BerkeDBEntities context, string path, pc_presupuestocab pCab)
        {
            MergeDoc mDoc = null;

            if (pCab == null)
            {
                int PresupuestoCabID = Convert.ToInt32(this.txtPresupID.Text);
                pCab = context.pc_presupuestocab.First(a => a.pc_presupuestocabid == PresupuestoCabID);
            }
            string extension = "." + (Path.GetFileName(@path).Split('-')[2]).Split('.')[0];
            int MergeDocID = pCab.pc_mergedocid.HasValue ? pCab.pc_mergedocid.Value : -1;
            if (MergeDocID > 0)
            {
                mDoc = context.MergeDoc.First(a => a.ID == MergeDocID);
                mDoc.Contenido = Berke.Libs.Base.Helpers.Files.GetBytesFromFile(@path);
                mDoc.Extension = extension;
            }
            else
            {
                mDoc = new MergeDoc();
                mDoc.Fecha = context.GetFechaDocumento(pCab.pc_presupuestocabid).FirstOrDefault().Value;
                //this.chkReemplazado.Checked ? Convert.ToDateTime(this.txtFecDocReemp.Text) : Convert.ToDateTime(this.txtFechaGen.Text);
                mDoc.Contenido = Berke.Libs.Base.Helpers.Files.GetBytesFromFile(@path);
                mDoc.FuncionarioID = Convert.ToInt32(VWGContext.Current.Session["UsuarioID"].ToString());
                mDoc.MergeID = MERGEID;
                mDoc.Extension = extension;
                context.MergeDoc.Add(mDoc);
                context.SaveChanges();
                pCab.pc_mergedocid = mDoc.ID;
            }
            context.SaveChanges();
        }

        private void GuardarDoc(BerkeDBEntities context, string path, string originalFileName, pc_presupuestocab pCab)
        {
            MergeDoc mDoc = null;

            if (pCab == null)
            {
                int PresupuestoCabID = Convert.ToInt32(this.txtPresupID.Text);
                pCab = context.pc_presupuestocab.First(a => a.pc_presupuestocabid == PresupuestoCabID);
            }
            string extension = Path.GetExtension(@originalFileName);
            int MergeDocID = pCab.pc_mergedocid.HasValue ? pCab.pc_mergedocid.Value : -1;
            if (MergeDocID > 0)
            {
                mDoc = context.MergeDoc.First(a => a.ID == MergeDocID);
                mDoc.Contenido = Berke.Libs.Base.Helpers.Files.GetBytesFromFile(@path);
                mDoc.Extension = extension;
            }
            else
            {
                mDoc = new MergeDoc();
                mDoc.Fecha = context.GetFechaDocumento(pCab.pc_presupuestocabid).FirstOrDefault().Value;
                //this.chkReemplazado.Checked ? Convert.ToDateTime(this.txtFecDocReemp.Text) : Convert.ToDateTime(this.txtFechaGen.Text);
                mDoc.Contenido = Berke.Libs.Base.Helpers.Files.GetBytesFromFile(@path);
                mDoc.FuncionarioID = Convert.ToInt32(VWGContext.Current.Session["UsuarioID"].ToString());
                mDoc.MergeID = MERGEID;
                mDoc.Extension = extension;
                context.MergeDoc.Add(mDoc);
                context.SaveChanges();
                pCab.pc_mergedocid = mDoc.ID;
            }
            context.SaveChanges();
        }

        private byte[] GetDocumentContent(string path)
        {
            byte[] binaryFile = Berke.Libs.Base.Helpers.Files.GetBytesFromFile(@path);
            return binaryFile;
        }

        private void OpenDialogFileUpload()
        {
            //VWGContext.Current.Session["sTMP"] = Environment.GetEnvironmentVariable("TMP");
            //string path = VWGContext.Current.Server.MapPath(@"\Resources\UserData\" + VWGContext.Current.Session["WindowsUser"].ToString() + @"\");
            //Environment.SetEnvironmentVariable("TMP", @path);
            
            openFileDialog1.InitialDirectory = "C:\\";
            //openFileDialog1.Filter = "Documentos de Word|*.doc;*.docx|Archivos PDF|*.pdf|Imágenes|*.jpg;*.bmp;*.png|Todos los archivos|*.*";
            openFileDialog1.Filter = "Todos los archivos|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = false;

            openFileDialog1.FileOk += openFileDialog1_FileOk;

            openFileDialog1.ShowDialog();
            //openFileDialog1.FileOk += new CancelEventHandler(testing);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            this.txtDocPath.Text = "";
            this.fileName = "";
            this.originalFileName = "";

            OpenFileDialog objOFD = sender as OpenFileDialog;

            if (objOFD == null)
            {
                return;
            }

            Gizmox.WebGUI.Common.Resources.FileHandle objFile = null;

            if (objOFD.Files[0] == null || !(objOFD.Files[0] is Gizmox.WebGUI.Common.Resources.FileHandle))
            {
                return;
            }
            objFile = objOFD.Files[0] as Gizmox.WebGUI.Common.Resources.FileHandle;

            //Display original file name, of the first uploaded file, on a label.
            this.fileName = objFile.FileName;
            this.originalFileName = objFile.OriginalFileName;

            if (this.FormEditStatus == INSERT)
                this.txtDocPath.Text = objFile.OriginalFileName;
            else if (this.FormEditStatus == BROWSE)
                this.SubirDocBrowse();

            //Environment.SetEnvironmentVariable("TMP", @VWGContext.Current.Session["sTMP"].ToString());
        }

        private static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        private bool ValidarNroFactura(string nrofactura, BerkeDBEntities context)
        {
            bool Result = true;

            List<pc_presupuestocab> ListaPCab = context.pc_presupuestocab.Where(a => a.pc_string1 == nrofactura).ToList();

            if (ListaPCab.Count > 0)
            {
                Result = false;
            }

            return Result;
        }

        //Valida que el número de factura no sea un número de presupuesto que ya existe
        private bool ValidarNroPresupuesto(string nrofactura, BerkeDBEntities context)
        {
            bool Result = true;

            List<pc_presupuestocab> ListaPCab = context.pc_presupuestocab.Where(a => a.pc_nropresupuesto == nrofactura).ToList();

            if (ListaPCab.Count > 0)
            {
                Result = false;
            }

            return Result;
        }

        private bool TienePagosAsociados(int PresupuestoCabID, BerkeDBEntities context)
        {
            bool Result = false;

            List<pp_pagopresupuesto> listPagos = context.pp_pagopresupuesto
                                                .Where(a => a.pp_presupuestocabid == PresupuestoCabID
                                                        && a.pp_anulado != true).ToList();

            //if (listPagos.Count > 0)
            //    Result = true;

            Result = ((listPagos.Count > 0) || (this.txtEstado.Text == ESTADO_PAGADO_TEXTO));
               
            return Result;
        }
        #endregion Método de Apoyo

        private void btnObtenerCasoPatricia_Click(object sender, EventArgs e)
        {
            if ((this.FormEditStatus == INSERT) && (this.txtNroPresupuesto.Text == String.Empty) && (this.txtNroCasoPatrix.Text != String.Empty))
            {
                this.txtPatrixInvoiceID.Text = String.Empty;
                lFacturasPatrix = new List<FacturaPatrixType>();
                string nroCasoPatrix = this.txtNroCasoPatrix.Text;
                this.limpiarDatos();
                this.txtNroCasoPatrix.Text = nroCasoPatrix;
                this.SetInvoiceID(this.txtNroCasoPatrix.Text);
            }
            else
            {
                MessageBox.Show("Sólo se pueden obtener datos externos del Sistema Patricia al ingresar un nuevo presupuesto." + Environment.NewLine +
                                "Obligatoriamente, debe ingresar el número de caso de Patrix.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
        }

        private void SetInvoiceID(string caseNumber)
        {
            string connectionString = this.DBContext.pa_parametros.FirstOrDefault(a => a.clave == PATRICIADB_CONNSTRING).valor;

            bool isTestMode = false;

            if (ConfigurationManager.AppSettings[TESTMODE] != null)
            {
                isTestMode = Convert.ToBoolean(ConfigurationManager.AppSettings[TESTMODE]);
            }

            if (isTestMode)
            {
                connectionString = "server=BER-SQL-PROD.berke.com.py;database=PatriciaDB;user id=ggaleano;password=C0r0navirus;";
            }

            string qryGetCaseID = this.DBContext.pa_parametros.FirstOrDefault(a => a.clave == PAT_QRY_GETCASEID).valor;
            string qryGetFactura = this.DBContext.pa_parametros.FirstOrDefault(a => a.clave == PAT_QRY_GETFACTURA).valor;

            int caseID = -1;
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(qryGetCaseID, connection);
                command.Parameters.Add(new SqlParameter("@CaseNumber", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@CaseNumberL", SqlDbType.VarChar));
                command.Parameters["@CaseNumber"].Value = caseNumber;
                command.Parameters["@CaseNumberL"].Value = caseNumber + "%";
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    #region Obtener CaseID
                    while (reader.Read())
                    {
                        caseID = (int)reader["CASE_ID"];
                    }
                                        
                    if (caseID == -1)
                        throw new Exception("No se encontró ningún caso con el N° de Caso ingresado.");

                    reader.Close();
                    #endregion Obtener CaseID

                    #region Obtener Facturas
                    command.Parameters.Clear();
                    command.CommandText = qryGetFactura;
                    command.Parameters.Add(new SqlParameter("@CaseID", SqlDbType.Int));
                    command.Parameters["@CaseID"].Value = caseID;
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        FacturaPatrixType dF = new FacturaPatrixType();
                        dF.CaseID = caseID;
                        dF.CaseNumber = caseNumber;
                        dF.InvoiceID = (int)reader["INVOICE_ID"];
                        dF.Monto = (decimal)reader["FOREIGN_CURR_VALUE"];
                        dF.MonedaAbrev = reader["FOREIGN_CURR_ID"].ToString();
                        dF.FechaFactura = (DateTime)reader["INVOCIE_DATE"];
                        dF.ClienteNombre = reader["CLIENT_NAME"].ToString();
                        lFacturasPatrix.Add(dF);
                    }

                    if (lFacturasPatrix.Count == 0)
                        throw new Exception("No se encontraron facturas para el N° de Caso ingresado.");
                    else if (lFacturasPatrix.Count > 1)
                    {
                        fSF = new FSeleccionarFacturaPatrix(lFacturasPatrix);
                        fSF.AceptarFiltrarClick += delegate { this.CargarMasDatos(fSF.GetInvoiceID(), connectionString); };
                        fSF.FormClosed += delegate { fSF = null; };
                        fSF.ShowDialog();
                    }
                    else
                    {
                        this.CargarMasDatos(this.lFacturasPatrix[0].InvoiceID, connectionString);
                    }

                    reader.Close();
                    #endregion Obtener Facturas
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al obtener los datos: " + Environment.NewLine + ex.Message, 
                                    "Información de Error", 
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                    command.Dispose();
                }
            }

        }

        private void CargarMasDatos(int invoiceID, string connectionString)
        {
            this.txtPatrixInvoiceID.Text = invoiceID.ToString();

            string qryGetFacturaFN = this.DBContext.pa_parametros.FirstOrDefault(a => a.clave == PAT_QRY_GETFACTURAFN).valor;
            string qryGetFacturaPath = this.DBContext.pa_parametros.FirstOrDefault(a => a.clave == PAT_QRY_GETFACTURAPATH).valor;
            string qryGetResponsable = this.DBContext.pa_parametros.FirstOrDefault(a => a.clave == PAT_QRY_GETRESPONSABLE).valor;
             
            FacturaPatrixType dF = this.lFacturasPatrix.First( a => a.InvoiceID == invoiceID);
            
            bool success = false;

            RtfTree arbol = new RtfTree();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(qryGetFacturaFN, connection);
                command.Parameters.Add(new SqlParameter("@InvoiceID", SqlDbType.Int));
                command.Parameters["@InvoiceID"].Value = dF.InvoiceID;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    #region Obtener nombre archivo de factura
                    string facturaFN = String.Empty;
                    while (reader.Read())
                    {
                        facturaFN = reader["DOC_FILE_NAME"].ToString();
                    }

                    if (facturaFN == String.Empty)
                        throw new Exception("No se encontró el archivo de la factura para el N° de Caso ingresado.");

                    dF.FacturaFN = facturaFN;

                    reader.Close();
                    #endregion Obtener nombre archivo de factura

                    #region Obtener path de la factura
                    string facturaPath = String.Empty;
                    command.CommandText = qryGetFacturaPath;
                    command.Parameters.Clear();
                    command.Parameters.Add(new SqlParameter("@CaseID", SqlDbType.Int));
                    command.Parameters.Add(new SqlParameter("@FileName", SqlDbType.VarChar));
                    command.Parameters["@CaseID"].Value = dF.CaseID;
                    command.Parameters["@FileName"].Value = dF.FacturaFN;
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        facturaPath = reader["DOC_NAME"].ToString();
                    }

                    if (facturaPath == String.Empty)
                        throw new Exception("No se encontró la ruta al archivo de la factura para el N° de Caso ingresado.");

                    dF.FacturaPath = facturaPath;

                    reader.Close();
                    #endregion Obtener path de la factura

                    #region Obtener Responsable
                    string responsable = String.Empty;
                    command.CommandText = qryGetResponsable;
                    command.Parameters.Clear();
                    command.Parameters.Add(new SqlParameter("@CaseID", SqlDbType.Int));
                    command.Parameters["@CaseID"].Value = dF.CaseID;
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        responsable = reader["LOGIN_ID"].ToString().ToLower();
                    }

                    if (responsable == String.Empty)
                        throw new Exception("No se encontró la ruta al archivo de la factura para el N° de Caso ingresado.");

                    dF.Responsable = responsable;

                    reader.Close();
                    #endregion Obtener Responsable
                    
                    if (fSF != null)
                        fSF.Close();

                    #region Asignar Datos

                    #region Cliente
                    Cliente cliente = this.DBContext.Cliente.FirstOrDefault(a => a.Nombre == dF.ClienteNombre);

                    if (cliente != null)
                    {
                        this.tSBCliente.KeyMember = cliente.ID.ToString();
                        this.tSBCliente.DisplayMember = cliente.Nombre;
                        this.txtRazonSocialFactura.Text = cliente.Nombre;
                        this.txtRUC.Text = cliente.RUC;
                    }
                    else
                    {
                        this.tSBCliente.KeyMember = String.Empty;
                        this.tSBCliente.DisplayMember = dF.ClienteNombre;
                        this.txtRazonSocialFactura.Text = dF.ClienteNombre;
                    }
                    #endregion Cliente

                    #region Responsable
                    Usuario usuario = this.DBContext.Usuario.FirstOrDefault(a => a.Usuario1 == dF.Responsable);

                    if (usuario != null)
                    {
                        this.tSBEnviadoPor.KeyMember = usuario.ID.ToString();
                        this.tSBEnviadoPor.DisplayMember = usuario.NombrePila;
                    }
                    else
                    {
                        this.tSBEnviadoPor.KeyMember = String.Empty;
                        this.tSBEnviadoPor.DisplayMember = String.Empty;
                    }
                    #endregion Responsable

                    #region Aprobado Por
                    usuario = this.DBContext.Usuario.FirstOrDefault(a => a.ID == USUARIO_ID_HT);
                    this.tSBAutorizadoPor.KeyMember = usuario.ID.ToString();
                    this.tSBAutorizadoPor.DisplayMember = usuario.NombrePila;
                    #endregion Aprobado Por

                    #region Fecha Generacion
                    this.txtFechaGen.Text = dF.FechaFactura.ToShortDateString();
                    #endregion Fecha Generacion

                    #region Total y Saldo
                    this.txtTotal.Text = String.Format(FORMATO_MONEDA_OTROS, dF.Monto);
                    this.txtSaldo.Text = String.Format(FORMATO_MONEDA_OTROS, dF.Monto);
                    #endregion Total y Saldo

                    #region Moneda
                    Moneda moneda = this.DBContext.Moneda.FirstOrDefault(a => a.PatrixMonedaID == dF.MonedaAbrev);

                    if (moneda != null)
                    {
                        this.tSBMoneda.KeyMember = moneda.ID.ToString();
                        this.tSBMoneda.DisplayMember = moneda.Descripcion;
                    }
                    else
                    {
                        this.tSBMoneda.KeyMember = String.Empty;
                        this.tSBMoneda.DisplayMember = String.Empty;
                    }
                    #endregion Moneda

                    #endregion Asignar Datos

                    #region Obtener RTF Text
                    PatrixRTFType patrixRTF = new PatrixRTFType();
                    bool isTestMode = false;

                    if (ConfigurationManager.AppSettings[TESTMODE] != null)
                    {
                        isTestMode = Convert.ToBoolean(ConfigurationManager.AppSettings[TESTMODE]);
                    }

                    if (isTestMode)
                    {
                        string userName = ConfigurationManager.AppSettings[TESTMODE_USERNAME].ToString();
                        string password = ConfigurationManager.AppSettings[TESTMODE_PASSWORD].ToString();
                        string domain = ConfigurationManager.AppSettings[TESTMODE_DOMAIN].ToString();

                        using (Impersonation.LogonUser(domain, userName, password, LogonType.NewCredentials))
                        {
                            // Code to execute as the impersonated user
                            //rtfContent = System.IO.File.ReadAllBytes(dF.FacturaPath.Replace("ber-fs-01", "ber-fs-01.berke.com.py"));
                            patrixRTF = this.ObtenerRTFText(dF.FacturaPath.Replace("ber-fs-01", "ber-fs-01.berke.com.py"));
                        }
                    }
                    else patrixRTF = this.ObtenerRTFText(dF.FacturaPath);

                    dF.FacturaPath = patrixRTF.FileFullName;
                    this.txtDescripcion.Text = patrixRTF.Description;

                    #region Original
                    /*byte [] rtfContent = System.IO.File.ReadAllBytes(dF.FacturaPath);

                    string fileName = WindowsIdentity.GetCurrent().Name.Replace(@"BERKE\", "") + "-"
                                        + this.txtNroCasoPatrix.Text + "-"
                                        + this.txtPatrixInvoiceID.Text;

                    string pathRTF = @VWGContext.Current.Session["PresupFolderURL"].ToString() + @"\Patrix\" + fileName + ".rtf";

                    System.IO.FileInfo file = new System.IO.FileInfo(pathRTF);
                    file.Directory.Create(); // If the directory already exists, this method does nothing.
                    File.WriteAllBytes(file.FullName, rtfContent);
                    dF.FacturaPath = file.FullName;

                    ////Se crea el árbol RTF.
                    arbol.LoadRtfFile(@file.FullName);
                    string texto = arbol.Text;

                    string[] startTags = new string[] { "Email", "Email", "Email", "E-mail", "E-mail", "E-mail", "Attn", "Attn", "Atención", "Atención", "Atencion", "Atencion" };
                    string[] endTags = new string[] { "Total", "Final Amount", "Monto Final", "Total", "Final Amount", "Monto Final", "Total", "Final Amount", "Total", "Monto Final", "Total", "Monto Final" };

                    string textoExtraido = String.Empty;

                    for (int c = 0; c < startTags.Length; c++)
                    {
                        textoExtraido = Utils.ExtractString(texto, startTags[c], endTags[c]);

                        if (textoExtraido != String.Empty)
                            break;
                    }

                    string[] lineas = textoExtraido.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                    string descripcion = String.Empty;

                    for (int i = 1; i < lineas.Length; i++)
                    {
                        descripcion += lineas[i] + Environment.NewLine;
                    }

                    if ((descripcion.IndexOf("Solicitud de Patente") > -1) || (descripcion.IndexOf("Patent Application") > -1))
                        descripcion = String.Empty;

                    this.txtDescripcion.Text = descripcion;*/
                    #endregion Original
                    #endregion Obtener RTF Text

                    success = true;
                }
                catch (Exception ex)
                {
                    string innerException = String.Empty;

                    if (ex.InnerException != null)
                    {
                        innerException += "Detalle: ";
                        innerException += ex.InnerException.InnerException != null
                                          ? ex.InnerException.InnerException.Message
                                          : ex.InnerException.Message;
                    }

                    MessageBox.Show("Ocurrió un error al obtener los datos: " + Environment.NewLine + ex.Message
                                    + Environment.NewLine + innerException,
                                    "Información de Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                    command.Dispose();                    
                }
            }

            if (success)
                this.tSBTramite_AceptarClick(this, null);
        }

        private PatrixRTFType ObtenerRTFText(string path)
        {
            PatrixRTFType result = new PatrixRTFType();
            RtfTree arbol = new RtfTree();
            byte [] rtfContent = System.IO.File.ReadAllBytes(path);

            string fileName = WindowsIdentity.GetCurrent().Name.Replace(@"BERKE\", "") + "-"
                                + this.txtNroCasoPatrix.Text + "-"
                                + this.txtPatrixInvoiceID.Text;

            string pathRTF = @VWGContext.Current.Session["PresupFolderURL"].ToString() + @"\Patrix\" + fileName + ".rtf";

            System.IO.FileInfo file = new System.IO.FileInfo(pathRTF);
            file.Directory.Create(); // If the directory already exists, this method does nothing.
            File.WriteAllBytes(file.FullName, rtfContent);
            result.FileFullName = file.FullName;

            ////Se crea el árbol RTF.
            arbol.LoadRtfFile(@file.FullName);
            string texto = arbol.Text;

            string[] startTags = new string[] { "Email", "Email", "Email", "E-mail", "E-mail", "E-mail", "Attn", "Attn", "Atención", "Atención", "Atencion", "Atencion" };
            string[] endTags = new string[] { "Total", "Final Amount", "Monto Final", "Total", "Final Amount", "Monto Final", "Total", "Final Amount", "Total", "Monto Final", "Total", "Monto Final" };

            string textoExtraido = String.Empty;

            for (int c = 0; c < startTags.Length; c++)
            {
                textoExtraido = Utils.ExtractString(texto, startTags[c], endTags[c]);

                if (textoExtraido != String.Empty)
                    break;
            }

            string[] lineas = textoExtraido.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            string descripcion = String.Empty;

            for (int i = 1; i < lineas.Length; i++)
            {
                descripcion += lineas[i] + Environment.NewLine;
            }

            if ((descripcion.IndexOf("Solicitud de Patente") > -1) || (descripcion.IndexOf("Patent Application") > -1))
                descripcion = String.Empty;

            result.Description = descripcion;

            return result;
        }

        private string ObtenerDescripcionFactura(string template)
        {
            CodeGenerator cg;

            CodeGenerator tablaDatos;
            CodeGenerator filaDescrip;
            CodeGenerator filaDescrip1_3;
            
            cg = new CodeGenerator(template);
            
            tablaDatos = cg.ExtraerTabla("tablaDatos");

            //Remover Caracteres de marca de <w:tr>
            var match = Regex.Match(tablaDatos.Template, "<w:tr (.*?)>");

            if (match.Success)
            {
                tablaDatos.Template = tablaDatos.Template.Replace(match.Groups[0].Value, "<w:tr>");
            }

            filaDescrip1_3 = tablaDatos.ExtraerFila("filaDescrip1_3", 3);
            filaDescrip = tablaDatos.ExtraerFila("filaDescrip", 1);

            match = Regex.Match(filaDescrip.Template, "<w:p (.*?)>");

            if (match.Success)
            {
                filaDescrip.Template = filaDescrip.Template.Replace(match.Groups[0].Value, "<w:p>");
            }

            string descripcion = String.Empty;
            CodeGenerator parrafoDescrip = filaDescrip.ExtraerParrafo("parrafoDescrip");
            CodeGenerator textoDescrip;

            while (parrafoDescrip.Template != String.Empty)
            {
                textoDescrip = parrafoDescrip.ExtraerTexto("textoDescrip");
                descripcion += textoDescrip.Template;

                while (textoDescrip.Template != String.Empty)
                {
                    textoDescrip = parrafoDescrip.ExtraerTexto("textoDescrip");
                    descripcion += textoDescrip.Template;
                }

                descripcion += "\r\n";
                parrafoDescrip = filaDescrip.ExtraerParrafo("parrafoDescrip");
            }

            return (Regex.Replace(descripcion, @"^\s+$[\r\n]*", "", RegexOptions.Multiline)).Replace("&amp;", "&");
        }

        private void EmptyPatrixDirectory()
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(@VWGContext.Current.Session["PresupFolderURL"].ToString() + @"\Patrix\");
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }

        private void ObtenerArchivoFactura(string nropresupuesto)
        {
            int invoiceID = Convert.ToInt32(this.txtPatrixInvoiceID.Text);
            string path = this.lFacturasPatrix.First(a => a.InvoiceID == invoiceID).FacturaPath;
            //Se crea el árbol RTF.
            RtfTree arbol = new RtfTree();

            arbol.LoadRtfFile(@path);

            byte[] fileBytes = File.ReadAllBytes(@path);

            string rtf = arbol.GetEncoding().GetString(fileBytes);

            try
            {
                arbol.RootNode.Rtf = rtf;
            }
            catch (System.ArgumentException)
            {
                arbol.RootNode.Rtf = rtf;
            }

            string[] patrones = new string[] { "Debit Note(.*?)No(.*?):", "Invoice(.*?)No(.*?):", "Nota de D(.*?)No(.*?):", "Factura(.*?)No(.*?):" };
            string[] etiquetas = new string[] { "Debit Note No:", "Invoice No:", "Nota de Débito No:", "Factura No:" };

            for(int i = 0; i < patrones.Length; i++)
            {
                var match = Regex.Match(arbol.RootNode.Rtf, patrones[i]);

                if (match.Success)
                {
                    arbol.RootNode.Rtf = arbol.RootNode.Rtf.Replace(match.Groups[0].Value, etiquetas[i] + nropresupuesto);
                    break;
                }
            }
            
            //var match = Regex.Match(arbol.RootNode.Rtf, "Debit Note(.*?)No(.*?):");

            //if (match.Success)
            //{
            //    arbol.RootNode.Rtf = arbol.RootNode.Rtf.Replace(match.Groups[0].Value, "Debit Note No: " + nropresupuesto);
            //}
            //else
            //{
            //    match = Regex.Match(arbol.RootNode.Rtf, "Invoice(.*?)No(.*?):");

            //    if (match.Success)
            //    {
            //        arbol.RootNode.Rtf = arbol.RootNode.Rtf.Replace(match.Groups[0].Value, "Invoice No: " + nropresupuesto);
            //    }
            //}

            fileBytes = arbol.GetEncoding().GetBytes(arbol.RootNode.Rtf);
            File.WriteAllBytes(@path, fileBytes);

            if (System.IO.Directory.Exists(Path.GetDirectoryName(path)))
            {
                path = "file://" + Path.GetDirectoryName(path);
                Link.Open(@path);
            }
        }

        private void ActualizarInvoiceCommentPatrix(int invoiceID, string nropresupuesto)
        {
            string connectionString = this.DBContext.pa_parametros.FirstOrDefault(a => a.clave == PATRICIADB_CONNSTRING).valor;
            string qryUpdInvoiceComment = this.DBContext.pa_parametros.FirstOrDefault(a => a.clave == PAT_UPD_INVOICE_COMMENT).valor;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(qryUpdInvoiceComment, connection);
                //UPDATE INVOICE_HEADER SET INVOICE_COMMENT = @INVOICE_COMMENT WHERE INVOICE_ID = @INVOICE_ID
                command.Parameters.AddWithValue("@INVOICE_COMMENT", nropresupuesto);
                command.Parameters.AddWithValue("@INVOICE_ID", invoiceID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (fSeleccionPresupAsoc == null)
                {
                    fSeleccionPresupAsoc = new FSeleccionarPresupuesto(this.DBContext,
                                                                        "Presupuestos Reemplazados",
                                                                        this.txtPresupIDs.Text,
                                                                        (this.FormEditStatus == BROWSE));
                    fSeleccionPresupAsoc.AceptarClick += f_AceptarClick;
                    fSeleccionPresupAsoc.FormClosed += delegate { fSeleccionPresupAsoc = null; };
                }

                //fSeleccionPresupAsoc.ListaPresupuestos = this.txtPresupID.Text.Replace(", ", ",");
                fSeleccionPresupAsoc.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + Environment.NewLine + ex.Message, "Información de Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        #region Eventos delegados
        private void f_AceptarClick(object sender, EventArgs e)
        {
            this.txtPresupIDs.Text = fSeleccionPresupAsoc.ListaPresupuestosID;
            this.txtPresupAsoc.Text = fSeleccionPresupAsoc.ListaPresupuestos;
            fSeleccionPresupAsoc.Close();
        }
        #endregion Eventos delegados

        private void SetPresupuestosAsociados(BerkeDBEntities context, string PresupuestoCabIDs)
        {
            string[] arryPIs = PresupuestoCabIDs.Split(',');
            string listaPresupIDs = "";
            string listaNroDocs = "";

            if (PresupuestoCabIDs != "")
            {
                foreach (string val in arryPIs)
                {
                    listaNroDocs += listaNroDocs != "" ? "," : "";
                    listaNroDocs += context.GetDocumentoNro(Convert.ToInt32(val)).FirstOrDefault();
                }
                listaPresupIDs = PresupuestoCabIDs;
            }
            this.txtPresupIDs.Text = listaPresupIDs;
            this.txtPresupAsoc.Text = listaNroDocs;
        }

        private void getDocPath()
        {
            object[] jsParams = new object[2];
            jsParams[0] = this.ID.ToString();
            jsParams[1] = this.txtDocPath.ID.ToString();
            VWGClientContext.Current.Invoke("getDocPath", jsParams);
            return;
        }

        protected override void FireEvent(Gizmox.WebGUI.Common.Interfaces.IEvent objEvent)
        {
            if (objEvent.Type == "docPathEvent")
            {
                //MessageBox.Show(objEvent["docPathValue"]);
                this.fileName = objEvent["docPathValue"];

                if (FormEditStatus != BROWSE)
                    this.txtDocPath.Text = this.fileName;
                else this.SubirDocBrowse();
            }
            else
                base.FireEvent(objEvent);

        }
    }
}