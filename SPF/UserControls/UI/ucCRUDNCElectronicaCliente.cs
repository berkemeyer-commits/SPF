#region Using

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Newtonsoft.Json;
using System.Threading;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;

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
using System.Data.Objects.DataClasses;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;

using SPF.Classes;
using Microsoft.Reporting.WebForms;
using SPF.Forms.UI;



#endregion

namespace SPF.UserControls.UI
{
    public partial class ucCRUDNCElectronicaCliente : ucBaseForm2015
    {
        #region Constantes
        //Cabecera
        public const string CAMPO_NOTACREDITOCABECERAID = "NotaCreditoCabeceraID";
        public const string CAMPO_PRESUPUESTOCABID = "PresupuestoCabID";
        public const string CAMPO_NOTACREDITOTIMBRADOID = "NotaCreditoTimbradoID";
        public const string CAMPO_NOTACREDITOHOJASUELTA = "NotaCreditoTimbradoHojaSuelta";
        public const string CAMPO_NOTACREDITOFECHA = "NotaCreditoFecha";
        public const string CAMPO_NOTACREDITONRO = "NotaCreditoNro";
        public const string CAMPO_ANULADO = "Anulado";
        public const string CAMPO_ANULADODESCRIPCION = "AnuladoDescripcion";
        public const string CAMPO_CLIENTEID = "ClienteID";
        public const string CAMPO_CLIENTENOMBRE = "ClienteNombre";
        public const string CAMPO_CLIENTEIDIOMAID = "ClienteIdiomaID";
        public const string CAMPO_DIRECCION = "Direccion";
        public const string CAMPO_NOTACREDITOTIPO = "NotaCreditoTipo";
        public const string CAMPO_NOTACREDITOTIPODESCRIPCION = "NotaCreditoTipoDescripcion";
        public const string CAMPO_RUC = "RUC";
        public const string CAMPO_NROREMISION = "NroRemision";
        public const string CAMPO_TELEFONO = "Telefono";
        public const string CAMPO_MONEDAID = "MonedaID";
        public const string CAMPO_MONEDAABREV = "MonedaAbrev";
        public const string CAMPO_MONEDADESCRIPCION = "MonedaDescripcion";
        public const string CAMPO_TOTALEXENTAS = "TotalExentas";
        public const string CAMPO_TOTALIVA5 = "TotalIVA5";
        public const string CAMPO_TOTALIVA10 = "TotalIVA10";
        public const string CAMPO_TOTALIVA = "TotalIVA";
        public const string CAMPO_LIQIVA5 = "LiqIVA5";
        public const string CAMPO_LIQIVA10 = "LiqIVA10";
        public const string CAMPO_TOTALLIQIVA = "TotalLiqIVA";
        public const string CAMPO_TOTALNOTACREDITO = "TotalNotaCredito";
        public const string CAMPO_TOTALLETRAS = "TotalLetras";
        public const string CAMPO_DOCUMENTOSASOCIADOS = "DocumentosAsociados";
        public const string CAMPO_AUTORIZACIONVIG = "TieneAutorizacionVigente";
        public const string CAMPO_CDC = "CDC";
        public const string CAMPO_DE = "DE";
        public const string CAMPO_LOTE = "Lote";
        public const string CAMPO_ESTADO_DE = "EstadoDE";
        public const string CAMPO_TIPO_CAMBIO = "TipoCambio";
        public const string CAMPO_MOTIVOEMISIONID = "MotivoEmisionID";
        public const string CAMPO_MOTIVOEMISIONDESCRIP = "MotivoEmisionDescrip";
        public const string CAMPO_FACTURACABID = "FacturaCabID";
        public const string CAMPO_FACTURACDC = "FacturaCDC";
        public const string CAMPO_FACTURAFECHA = "FacturaFecha";
        public const string CAMPO_FACTURANROTIMBRADO = "FacturaNroTimbrado";
        public const string CAMPO_FACTURADE = "FacturaDE";
        //Detalles
        public const string CAMPO_DETNOTACREDITOCABID = "NotaCreditoCabID";
        public const string CAMPO_CANTIDAD = "Cantidad";
        public const string CAMPO_DESCRIPCION = "Descripcion";
        public const string CAMPO_PRECIOUNITARIO = "PrecioUnitario";
        public const string CAMPO_EXENTAS = "Exentas";
        public const string CAMPO_CINCOPORCIENTO = "CincoPorciento";
        public const string CAMPO_DIEZPORCIENTO = "DiezPorciento";
        private const string CAMPO_BOLETADEPOSITONRO = "BoletaDepositoNro";
        public const string CAMPO_COBROID = "CobroID";
        public const string CAMPO_DESCRIPCION_FE = "DescripcionFE";

        private const string CAMPO_AUDITOPERACION = "AuditOperacion";
        private const string CAMPO_USUARIOCARGAID = "UsuarioCargaID";
        private const string CAMPO_USUARIOCARGANOMBRE = "UsuarioCargaNombre";

        private const string CAMPO_NOTACREDITODETALLEFK_TABLA = "nd_notacreditocabeceraid";
        private const string CAMPO_NOTACREDITOCABECERAPK_TABLA = "nc_notacreditocabeceraid";
        private const string CAMPO_NOTACREDITOCABECERA_NRONOTACREDITO = "nc_nronotacredito";
        private const string CAMPO_NOTACREDITOCABECERA_TIMBRADOID = "nc_timbradoid";
        private const string CAMPO_NOTACREDITOCABECERA_DOCUMENTOSASOC = "nc_documentosasoc";

        private const string DESCRIPCION_NOTACREDITO_SERIE2_SING_ESP = "DESCRIPCION_NOTACREDITO_SERIE2_SING_ESP";
        private const string DESCRIPCION_NOTACREDITO_SERIE2_PLU_ESP = "DESCRIPCION_NOTACREDITO_SERIE2_PLU_ESP";
        private const string DESCRIPCION_NOTACREDITO_SERIE2_SING_ING = "DESCRIPCION_NOTACREDITO_SERIE2_SING_ING";
        private const string DESCRIPCION_NOTACREDITO_SERIE2_PLU_ING = "DESCRIPCION_NOTACREDITO_SERIE2_PLU_ING";

        private const string SERIE_2 = "Serie 2";

        private const string AUDIT_OPERACION_INSERT = "INSERT";

        private const string ESTADO_PENDIENTE = "A";
        private const string ESTADO_ANULADO = "N";
        private const string ESTADO_ACTIVOVALOR = "Activo";
        private const string ESTADO_ANULADOVALOR = "Anulado";
        private const string ESTADO_CON_NOTA_CREDITO = "Con Nota Crédito";
        private const int IDIOMA_ESPANOL = 2;
        private const int VIA_TELEFONO = 2;
        private const int VIA_TELEFAX = 11;
        private const int VIA_CELULAR = 9;
        private const string GUARANIES = "GUARANIES";
        private const string DOLLARS = "DOLLARS";
        private const string DOLARES = "DOLARES";
        private const string ORIGEN_M = "M";
        private const string ORIGEN_O = "O";
        private const string ORIGEN_C = "C";
        private const string ORIGEN_R = "R";
        private const string FORMATO_MONEDA_GUARANIES = "{0:N0}";
        private const string FORMATO_MONEDA_OTROS = "{0:N2}";
        private const string FORMATO_MONEDA_GUARANIES_GRILLA = "N0";
        private const string FORMATO_MONEDA_OTROS_GRILLA = "N2";
        private const string FACTURA_CONTADO = "C";
        private const string FACTURA_CREDITO = "R";
        private const int TIPODOCUMENTO_NOTACREDITO_CLIENTE = 6;
        private const string GRAVADO_IVA_ID = "1";
        private const string GRAVADO_IVA_DESCRIP = "Gravado IVA";
        private const string EXENTO_ID = "3";
        private const string EXENTO_DESCRIP = "Exento";
        private const string GRAVADO_PARCIAL_ID = "4";
        private const string GRAVADO_PARCIAL_DESCRIP = "Gravado parcial (Grav- Exento)";
        private const string PROP_IVA = "100";
        private const string TASA_IVA_10 = "10";
        private const string TASA_IVA_5 = "5";
        private const string TASA_IVA_0 = "0";
        private const string BASE_EXE = "0";

        private const string CERO_SIN_DECIMALES = "0";
        private const string CERO_CON_DECIMALES = "0,00";
        private const string FORMATO_FECHA_CORTA = "yyyy-MM-dd";

        private const char PAD = '0';
        private const string FORMATO_NOTACREDITO = "{0}-{1}-{2}";

        private const string IE_BROWSER = "InternetExplorer";

        private const string HOJASUELTA_SI = "S";
        private const string HOJASUELTA_NO = "N";

        private const string NOTACREDITO_ELECTRONICA = "5";
        private const string NOTACREDITO_ELECTRONICA_DESCRIP = "Nota de crédito electrónica";
        private const string TIPO_CONTRIBUYENTE = "2";
        private const string RUC_BERKEMEYER = "80016875";
        private const int DV_BERKEMEYER = 5;
        private const string ESTABLECIMIENTO = "1";
        private const string TIPO_EMISOR = "1";
        private const string CODIGO_ALFA3_PARAGUAY = "PRY";
        private const string CODIGO_GUARANIES_FE = "PYG";
        private const string PERSONA_JURIDICA = "J";
        private const string CONTADO = "Contado";
        private const string CREDITO = "Crédito";
        private const string EFECTIVO_CODIGO = "1";
        private const string EFECTIVO_DESCRIPCION = "Efectivo";
        private const string ESTADO_APROBADO = "Aprobado";
        private const string ESTADO_PENDIENTE_DE = "Pendiente";
        private const string ESTADO_RECHAZADO = "Rechazado";
        private const string ESTADO_CANCELADO = "Cancelado";
        private const string EN_PROCESAMIENTO = "en procesamiento";
        private static readonly List<string> ESTADOS_DE = new List<string>() { ESTADO_APROBADO, ESTADO_PENDIENTE_DE, ESTADO_RECHAZADO };
        private const string TOKEN_JWT = "eyJhbGciOiJIUzI1NiJ9.eyJqdGkiOiI4MDAxNjg3NS01IiwiaWF0IjoxNjgxMTczMTM2LCJzdWIiOiJCRVJLRU1FWUVSIEFUVE9STkVZUyAmIENPVU5TRUxPUlMifQ.dPMhBO_oIvpUG56u8QgWU8waMDYndn7YHHJfuBwJldA";
        private const string ERROR_TC = "No hay tipo de cambio definido para {0} para la fecha {1}.";
        private const string DEBUG_DE_JSON = "DEBUG_DE_JSON";
        #endregion Constantes

        #region Variables Globales
        frmPickBase fPickMoneda;
        frmPickBase fPickCliente;
        private frmPickBase fPickFactura;
        private int UsuarioID = -1;
        private List<NotaCreditoAllType> lNotasCredito;
        FSelecPresupFactura fSelecPresupFactura;
        List<int> timbrados = new List<int>();
        private BindingSource bS_Det;
        Boolean debug_de_json = false;
        #endregion Variables Globales

        #region Propiedades
        public Boolean IsDebugDEJSON
        {
            set { this.debug_de_json = value; }
            get { return this.debug_de_json; }
        }
        #endregion Propiedades

        #region Método de Inicio
        public ucCRUDNCElectronicaCliente()
        {
            InitializeComponent();
        }

        public ucCRUDNCElectronicaCliente(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();

            #region Redimensionar Panel de Grilla de Detalles de Factura según navegador
            //if (Context.HttpContext.Request.Browser.Browser != IE_BROWSER)
            //    this.pnlDetalle.Height = 230;
            //else
            //    this.pnlDetalle.Height = 165;
            #endregion Redimensionar Panel de Grilla de Detalles de Factura según navegador

            this.DBContext = dbContext;
            this.Titulo = Titulo;
            this.UsuarioID = Convert.ToInt32(VWGContext.Current.Session["UsuarioID"].ToString());
            this.bS_Det = new BindingSource();

            this.IsDebugDEJSON = Convert.ToBoolean(this.DBContext.pa_parametros.First(a => a.clave == DEBUG_DE_JSON).valor);

            timbrados = (from t in
                             ((from su in this.DBContext.su_serieusuario
                               join usu in this.DBContext.Usuario
                                  on su.su_usuarioid equals usu.ID
                               join ti in this.DBContext.ti_timbrado
                                on su.su_timbradoid equals ti.ti_timbradoid
                               select new PermisoTimbrado
                               {
                                   PermisoTimbradoID = su.su_serieusuarioid,
                                   TimbradoID = su.su_timbradoid,
                                   UsuarioID = su.su_usuarioid,
                                   UsuarioNombre = usu.NombrePila,
                                   TipoDocumentoID = ti.ti_tipodocumentoid
                               })
                                 .Where(a => a.UsuarioID == UsuarioID && a.TipoDocumentoID == TIPODOCUMENTO_NOTACREDITO_CLIENTE).ToList())
                         select t.TimbradoID).ToList();


            lNotasCredito = new List<NotaCreditoAllType>();

            lNotasCredito = (from nc in this.DBContext.nc_notacreditocabecera
                         join nd in this.DBContext.nd_notacreditodetalle
                             on nc.nc_notacreditocabeceraid equals nd.nd_notacreditocabeceraid
                         join mon in this.DBContext.Moneda
                             on nc.nc_monedaid equals mon.ID
                         join AudFc in this.DBContext.Audit_nc_notacreditocabecera
                             on nc.nc_notacreditocabeceraid equals AudFc.nc_notacreditocabeceraid
                         join cli in this.DBContext.Cliente
                             on nc.nc_clienteid equals cli.ID into nc_cli
                             from cli in nc_cli.DefaultIfEmpty()
                         join uAud in this.DBContext.Usuario
                             on AudFc.Audit_User.Substring(6, AudFc.Audit_User.Length) equals uAud.Usuario1
                         join ti in this.DBContext.ti_timbrado
                             on nc.nc_timbradoid equals ti.ti_timbradoid
                         join me in this.DBContext.me_motivoemision
                            on nc.nc_motivoemisionid equals me.me_motivoemisionid
                         join fc in this.DBContext.fc_facturacabecera
                            on nc.nc_facturacabid equals fc.fc_facturacabeceraid into nc_fc
                            from fc in nc_fc.DefaultIfEmpty()
                         join ti2 in this.DBContext.ti_timbrado
                            on fc.fc_timbradoid equals ti2.ti_timbradoid
                         select new NotaCreditoAllType
                         {
                             //Cabecera
                             NotaCreditoFecha = nc.nc_fechanotacredito,
                             NotaCreditoCabeceraID = nc.nc_notacreditocabeceraid,
                             NotaCreditoTimbradoID = nc.nc_timbradoid,
                             NotaCreditoTimbradoHojaSuelta = ti.ti_facthojasuelta,
                             NotaCreditoNro = nc.nc_nronotacredito,
                             Anulado = nc.nc_anulado,
                             ClienteID = nc.nc_clienteid,
                             ClienteNombre = nc.nc_clientenombre,
                             ClienteIdiomaID = cli.IdiomaID,
                             Direccion = nc.nc_direccion,
                             NotaCreditoTipo = nc.nc_tiponotacredito,
                             RUC = nc.nc_ruc,
                             NroRemision = nc.nc_nroremision,
                             Telefono = nc.nc_telefono,
                             MonedaID = nc.nc_monedaid,
                             MonedaAbrev = mon.AbrevMoneda,
                             MonedaDescripcion = mon.Descripcion,
                             TotalExentas = nc.nc_totalexentas,
                             TotalIVA5 = nc.nc_totaliva5,
                             TotalIVA10 = nc.nc_totaliva10,
                             TotalIVA = nc.nc_totaliva5 + nc.nc_totaliva10, //nc.nc_totaliva,
                             LiqIVA5 = nc.nc_liqiva5,
                             LiqIVA10 = nc.nc_liqiva10,
                             TotalLiqIVA = nc.nc_totaliva,
                             TotalNotaCredito = nc.nc_total,
                             TotalLetras = nc.nc_totalletras,
                             DocumentosAsociados = nc.nc_documentosasoc,
                             UsuarioCargaID = uAud.ID,
                             UsuarioCargaNombre = uAud.NombrePila,
                             AuditOperacion = AudFc.Audit_Operacion,
                             CDC = nc.nc_cdc,
                             DE = nc.nc_documentoelectronico,
                             Lote = nc.nc_lote,
                             EstadoDE = nc.nc_estadode,
                             TipoCambio = nc.nc_tipocambio,
                             MotivoEmisionID = nc.nc_motivoemisionid,
                             MotivoEmisionDescrip = me.me_motivoemisionsifendescrip,
                             FacturaCabId = nc.nc_facturacabid,
                             FacturaCDC = fc.fc_cdc,
                             FacturaFecha = fc.fc_fechafactura,
                             FacturaNroTimbrado = ti2.ti_nrotimbrado,
                             FacturaDE = fc.fc_documentoelectronico,
                             TieneAutorizacionVigente = this.DBContext.GetAutorizacionPorDocumentoID(TIPODOCUMENTO_NOTACREDITO_CLIENTE,
                                                                                                     nc.nc_notacreditocabeceraid,
                                                                                                     this.UsuarioID).FirstOrDefault().Value,
                             //Detalles
                             Cantidad = nd.nd_cantidad,
                             Descripcion = nd.nd_descripcion,
                             PrecioUnitario = nd.nd_preciounitario,
                             Exentas = nd.nd_exentas,
                             CincoPorciento = nd.nd_cincoporciento,
                             DiezPorciento = nd.nd_diezporciento,
                             PresupuestoCabID = nd.nd_presupuestocabid,
                             BoletaDepositoNro = nd.nd_nroboletadeposito,
                             CobroID = nd.nd_cobroid,
                             DescripcionFE = nd.nd_descripFE
                         })
                         .Where(b => b.AuditOperacion == AUDIT_OPERACION_INSERT && b.DE == true && timbrados.Contains(b.NotaCreditoTimbradoID.Value))
                         .OrderByDescending( a => a.NotaCreditoCabeceraID )
                         .Take(50)
                         .ToList();

            this.BindingSourceBase_ExportExcelGrid = lNotasCredito;
            this.dgvDetNC.DataSource = this.bS_Det;
            //this.LoadGridExportToExcel();

            List<NotaCreditoAllType> query = (from item in lNotasCredito
                                              select new NotaCreditoAllType
                                              {
                                                  //Cabecera
                                                  NotaCreditoFecha = item.NotaCreditoFecha,
                                                  NotaCreditoCabeceraID = item.NotaCreditoCabeceraID,
                                                  NotaCreditoTimbradoID = item.NotaCreditoTimbradoID,
                                                  NotaCreditoTimbradoHojaSuelta = item.NotaCreditoTimbradoHojaSuelta,
                                                  NotaCreditoNro = item.NotaCreditoNro,
                                                  Anulado = item.Anulado,
                                                  ClienteID = item.ClienteID,
                                                  ClienteNombre = item.ClienteNombre,
                                                  ClienteIdiomaID = item.ClienteIdiomaID,
                                                  Direccion = item.Direccion,
                                                  NotaCreditoTipo = item.NotaCreditoTipo,
                                                  RUC = item.RUC,
                                                  NroRemision = item.NroRemision,
                                                  Telefono = item.Telefono,
                                                  MonedaID = item.MonedaID,
                                                  MonedaAbrev = item.MonedaAbrev,
                                                  MonedaDescripcion = item.MonedaDescripcion,
                                                  TotalExentas = item.TotalExentas,
                                                  TotalIVA5 = item.TotalIVA5,
                                                  TotalIVA10 = item.TotalIVA10,
                                                  TotalIVA = item.TotalIVA,
                                                  LiqIVA5 = item.LiqIVA5,
                                                  LiqIVA10 = item.LiqIVA10,
                                                  TotalLiqIVA = item.TotalLiqIVA,
                                                  TotalNotaCredito = item.TotalNotaCredito,
                                                  TotalLetras = item.TotalLetras,
                                                  DocumentosAsociados = item.DocumentosAsociados,
                                                  UsuarioCargaID = item.UsuarioCargaID,
                                                  UsuarioCargaNombre = item.UsuarioCargaNombre,
                                                  AuditOperacion = item.AuditOperacion,
                                                  CDC = item.CDC,
                                                  DE = item.DE,
                                                  Lote = item.Lote,
                                                  EstadoDE = item.EstadoDE,
                                                  TipoCambio = item.TipoCambio,
                                                  MotivoEmisionID = item.MotivoEmisionID,
                                                  MotivoEmisionDescrip = item.MotivoEmisionDescrip,
                                                  FacturaCabId = item.FacturaCabId,
                                                  FacturaCDC = item.FacturaCDC,
                                                  FacturaFecha = item.FacturaFecha,
                                                  FacturaNroTimbrado = item.FacturaNroTimbrado,
                                                  FacturaDE = item.FacturaDE,
                                                  TieneAutorizacionVigente = item.TieneAutorizacionVigente
                                              })
                         .GroupBy(x => new { x.NotaCreditoCabeceraID }).Select(g => g.First()).ToList()
                         .Take(200)
                         .ToList();

            this.BindingSourceBase = query;

            #region Especificar campos para filtro
            this.SetFilter(CAMPO_NOTACREDITOCABECERAID, "N.C. Cab. ID", false);        
            this.SetFilter(CAMPO_NOTACREDITOTIMBRADOID, "Timbrado");
            this.SetFilter(CAMPO_NOTACREDITOTIPO, "Tipo N.C. (C/R)");
            this.SetFilter(CAMPO_NOTACREDITOTIPO, "Tipo N.C. Descrip.");
            this.SetFilter(CAMPO_NOTACREDITONRO, "N° Nota Crédito");
            this.SetFilter(CAMPO_NOTACREDITOFECHA, "Fecha NC");
            this.SetFilter(CAMPO_CDC, "CDC");
            this.SetFilter(CAMPO_DE, "DE (S/N)", false);
            this.SetFilter(CAMPO_ESTADO_DE, "Estado DE");
            this.SetFilter(CAMPO_MOTIVOEMISIONDESCRIP, "Motivo Emi.");
            this.SetFilter(CAMPO_NROREMISION, "N° Remisión");
            this.SetFilter(CAMPO_ANULADO, "Anulado (S/N)", false);
            this.SetFilter(CAMPO_CLIENTEID, "Cliente ID", false);
            this.SetFilter(CAMPO_CLIENTENOMBRE, "Cliente Nombre");
            this.SetFilter(CAMPO_DIRECCION, "Cliente Dirección");
            this.SetFilter(CAMPO_RUC, "Cliente RUC");
            this.SetFilter(CAMPO_TELEFONO, "Cliente Teléf.");
            this.SetFilter(CAMPO_MONEDAID, "Moneda ID", false);
            this.SetFilter(CAMPO_MONEDADESCRIPCION, "Moneda Descrip.");
            this.SetFilter(CAMPO_TOTALNOTACREDITO, "Total N.C.", false);
            this.SetFilter(CAMPO_PRESUPUESTOCABID, "Presup. ID", false);
            this.SetFilter(CAMPO_DOCUMENTOSASOCIADOS, "Documentos Asoc.");
            this.SetFilter(CAMPO_BOLETADEPOSITONRO, "N° Boleta Dep.");
            this.SetFilter(CAMPO_USUARIOCARGAID, "Gen. Por ID", false);
            this.SetFilter(CAMPO_USUARIOCARGANOMBRE, "Gen. Por Nombre");

            this.TituloBuscador = "Buscar Notas Créditos";
            #endregion Especificar campos para filtro

            #region Inicializar TextSearchBoxes
            this.tSBCliente.KeyMemberWidth = 50;
            this.tSBCliente.ToolTip = "Elegir Cliente";
            this.tSBCliente.AceptarClick += tSBCliente_AceptarClick;
            this.tSBCliente.MakeDescriptionEditable();
            this.tSBCliente.DisplayMemberLeave += tSBCliente_DisplayMemberLeave;

            this.tSBMoneda.KeyMemberWidth = 50;
            this.tSBMoneda.ToolTip = "Elegir Moneda";
            this.tSBMoneda.SoloLectura = false;
            this.tSBMoneda.AceptarClick += tSBMoneda_AceptarClick;
            

            #endregion Inicializar TextSearchBoxes

            #region Datetime Picker
            this.dtpFechaFactura.Format = DateTimePickerFormat.Short;
            #endregion Datetime Picker

            this.FormEditStatus = BROWSE;
            #region Cargar Combos
            this.cargarCBSerieNotaCredito();
            this.cargarCBMotivoEmision();
            #endregion Cargar Combos

            #region Ocultar Botones
            this.tbbBorrar.Visible = false;
            this.tbbEditar.Visible = false;
            this.tbbImprimir.Visible = true;
            this.tbbAnular.Visible = true;
            this.tbbXML.Visible = true;
            this.tbbXML.Click += tbbXML_Click;
            #endregion Ocultar Botones

            #region Asignación Eventos Deletados
            //Asignar Evento de Validación de carga de campos
            this.ValidarCamposEvent += ucCRUDNCElectronicaCliente_ValidarCamposEvent;
            //Asignar Evento para Guardar Registro
            this.CRUDEvent += ucCRUDNCElectronicaCliente_CRUDEvent;
            #endregion Asignación Eventos Deletados

            this.InsertActionMessage = "Se generará una nota crédito electrónica ¿Desea continuar?";
            this.InsertActionCaption = "Generación de nota crédito";

            this.btnVerMotivoRechazo.Location = new Point(203, 206);
            this.btnBuscar.Click += tSBFactura_AceptarClick;
        }

        #endregion Método de Inicio

        #region Picks
        #region Factura
        private void tSBFactura_AceptarClick(object sender, EventArgs e)
        {
            if (fPickFactura == null)
            {
                fPickFactura = new frmPickBase(800);
                //fPickFactura.FormClosed += delegate { fPickFactura = null; };
                fPickFactura.AceptarFiltrarClick += fPickFactura_AceptarFiltrarClick;
                fPickFactura.FiltrarClick += fPickFactura_FiltrarClick;

                fPickFactura.CampoIDNombre = "FacturaCabId";
                fPickFactura.CampoDescripNombre = "Informacion";
                fPickFactura.LabelCampoID = "ID";
                fPickFactura.LabelCampoDescrip = "Información";
                fPickFactura.Col2Width = 600;

                fPickFactura.Titulo = "Elegir Factura";
                fPickFactura.NombreCampo = "Datos Fact.";
                fPickFactura.LabelCampoID = "Factura ID";
                fPickFactura.LabelCampoDescrip = "Datos Factura";
                fPickFactura.SetExplicitToolTipIDTextBox("N° Factura, N° Timbrado, Cliente");
                fPickFactura.HideDescriptionTextBox(true);
                fPickFactura.UseExplicitToolTip = true;
                fPickFactura.ColumnIDVisible = false;
                fPickFactura.Col1Width = 100;
            }
            fPickFactura.MostrarFiltro();
            //this.fPickProveedor_FiltrarClick(sender, e);
        }

        private void fPickFactura_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickFactura != null)
            {
                if ((fPickFactura.GetIDFilter == "") && (fPickFactura.GetDescripFilter == ""))
                {
                    MessageBox.Show("Debe establecer algún criterio de filtro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string valorAlfa = fPickFactura.GetIDFilter;

                var query = (from data in this.DBContext.GetDatosFacturaNC(valorAlfa)
                             select new FacturaNotaCreditoFilterType
                            {
                                FacturaCabID = data.FacturaCabId,
                                NroFactura = data.NroFactura,
                                NroTimbrado = data.NroTimbrado,
                                AbrevMoneda = data.AbrevMoneda,
                                ClienteNombre = data.ClienteNombre,
                                FechaFactura = data.FechaFactura,
                                MontoFactura = data.MontoFactura,
                                EsDE = data.EsDE
                            }).ToList();

                fPickFactura.LoadData<FacturaNotaCreditoFilterType>(query.AsQueryable());
            }
        }

        private void CargarFactura(int FacturaCabId)
        {
            var query = (from fc in this.DBContext.fc_facturacabecera
                         join fd in this.DBContext.fd_facturadetalle
                             on fc.fc_facturacabeceraid equals fd.fd_facturacabeceraid
                         join mon in this.DBContext.Moneda
                             on fc.fc_monedaid equals mon.ID
                         //join AudFc in this.DBContext.Audit_fc_facturacabecera
                         //    on fc.fc_facturacabeceraid equals AudFc.fc_facturacabeceraid
                         join cli in this.DBContext.Cliente
                             on fc.fc_clienteid equals cli.ID into fc_cli
                         from cli in fc_cli.DefaultIfEmpty()
                         //join uAud in this.DBContext.Usuario
                         //    on AudFc.Audit_User.Substring(6, AudFc.Audit_User.Length) equals uAud.Usuario1
                         join ti in this.DBContext.ti_timbrado
                             on fc.fc_timbradoid equals ti.ti_timbradoid
                         select new 
                         {
                             //Cabecera
                             FacturaNro = fc.fc_nrofactura,
                             FacturaCabeceraID = fc.fc_facturacabeceraid,
                             FacturaTimbradoID = fc.fc_timbradoid,
                             FacturaTimbradoHojaSuelta = ti.ti_facthojasuelta,
                             FacturaNroTimbrado = ti.ti_nrotimbrado,
                             FacturaFecha = fc.fc_fechafactura,
                             Anulado = fc.fc_anulado,
                             ClienteID = fc.fc_clienteid,
                             ClienteNombre = fc.fc_clientenombre,
                             ClienteIdiomaID = cli.IdiomaID,
                             Direccion = fc.fc_direccion,
                             FacturaTipo = fc.fc_tipofactura,
                             RUC = fc.fc_ruc,
                             NroRemision = fc.fc_nroremision,
                             Telefono = fc.fc_telefono,
                             MonedaID = fc.fc_monedaid,
                             MonedaAbrev = mon.AbrevMoneda,
                             MonedaDescripcion = mon.Descripcion,
                             TotalExentas = fc.fc_totalexentas,
                             TotalIVA5 = fc.fc_totaliva5,
                             TotalIVA10 = fc.fc_totaliva10,
                             TotalIVA = fc.fc_totaliva5 + fc.fc_totaliva10,//fc.fc_totaliva,
                             LiqIVA5 = fc.fc_liqiva5,
                             LiqIVA10 = fc.fc_liqiva10,
                             TotalLiqIVA = fc.fc_totaliva,
                             TotalFactura = fc.fc_total,
                             TotalLetras = fc.fc_totalletras,
                             DocumentosAsociados = fc.fc_documentosasoc,
                             //UsuarioCargaID = uAud.ID,
                             //UsuarioCargaNombre = uAud.NombrePila,
                             //AuditOperacion = AudFc.Audit_Operacion,
                             CDC = fc.fc_cdc,
                             DE = fc.fc_documentoelectronico,
                             Lote = fc.fc_lote,
                             EstadoDE = fc.fc_estadode,
                             TipoCambio = fc.fc_tipocambio,
                             //Detalles
                             Cantidad = fd.fd_cantidad,
                             Descripcion = fd.fd_descripcion,
                             PrecioUnitario = fd.fd_preciounitario,
                             Exentas = fd.fd_exentas,
                             CincoPorciento = fd.fd_cincoporciento,
                             DiezPorciento = fd.fd_diezporciento,
                             PresupuestoCabID = fd.fd_presupuestocabid,
                             BoletaDepositoNro = fd.fd_nroboletadeposito,
                             DescripcionFE = fd.fd_descripFE,
                             FacturaDE = fc.fc_documentoelectronico,
                         })
                         .Where(b => b.FacturaCabeceraID == FacturaCabId)
                         .ToList();

            string formatoNumero = query.FirstOrDefault().MonedaDescripcion.ToString()  == GUARANIES ? FORMATO_MONEDA_GUARANIES : FORMATO_MONEDA_OTROS;
            this.txtNroFactura.Text = query.FirstOrDefault().FacturaNro;
            this.txtFacturaCabID.Text = FacturaCabId.ToString();
            this.txtCDCFactura.Text = query.FirstOrDefault().CDC;
            this.txtFechaFactura.Text = query.FirstOrDefault().FacturaFecha.ToString(FORMATO_FECHA_CORTA);
            this.txtNroTimbradoFactura.Text = query.FirstOrDefault().FacturaNroTimbrado.ToString();

            //this.chkFacturaDE.Checked = false;

            //if (query.FirstOrDefault().FacturaDE.HasValue)
            //    this.chkFacturaDE.Checked = query.FirstOrDefault().FacturaDE.Value;

            this.tSBCliente.KeyMember = query.FirstOrDefault().ClienteID.ToString();
            this.tSBCliente.DisplayMember = query.FirstOrDefault().ClienteNombre.ToString();
            this.txtClienteIdiomaID.Text = query.FirstOrDefault().ClienteIdiomaID.ToString();
            this.tSBMoneda.KeyMember = query.FirstOrDefault().MonedaID.ToString();
            this.tSBMoneda.DisplayMember = query.FirstOrDefault().MonedaDescripcion.ToString();
            this.txtRUC.Text = query.FirstOrDefault().RUC;
            this.txtDireccion.Text = query.FirstOrDefault().Direccion;
            this.txtTelefono.Text = query.FirstOrDefault().Telefono;
            this.txtTotalIVA10.Text = String.Format(formatoNumero, query.FirstOrDefault().TotalIVA10);
            this.txtTotalIVA5.Text = String.Format(formatoNumero, query.FirstOrDefault().TotalIVA5);
            this.txtTotalIVA.Text = String.Format(formatoNumero, query.FirstOrDefault().TotalIVA);
            this.txtLiqIVA10.Text = String.Format(formatoNumero, query.FirstOrDefault().LiqIVA10);
            this.txtLiqIVA5.Text = String.Format(formatoNumero, query.FirstOrDefault().LiqIVA5);
            this.txtLiqTotalIVA.Text = String.Format(formatoNumero, query.FirstOrDefault().TotalLiqIVA);
            this.txtTotalExentas.Text = String.Format(formatoNumero, query.FirstOrDefault().TotalExentas);
            this.txtMontoTotal.Text = String.Format(formatoNumero, query.FirstOrDefault().TotalFactura);

            List<DetalleNotaCreditoType> listaDet = new List<DetalleNotaCreditoType>();

            foreach (var row in query)
            {
                DetalleNotaCreditoType det = new DetalleNotaCreditoType();
                det.Cantidad = row.Cantidad;
                det.PrecioUnitario = row.Exentas + row.CincoPorciento + row.DiezPorciento; //row.PrecioUnitario;
                det.Exentas = row.Exentas;
                det.CincoPorciento = row.CincoPorciento;
                det.DiezPorciento = row.DiezPorciento;
                det.Descripcion = row.Descripcion;
                det.DescripcionFE = row.DescripcionFE;
                listaDet.Add(det);
            }
            //this.dgvDetNC.DataSource = listaDet;
            this.bS_Det.DataSource = listaDet;
            this.FormatearGrillaDetalle();
        }

        private void fPickFactura_AceptarFiltrarClick(object sender, EventArgs e)
        {
            //string[] datosFactura = fPickFactura.GetValor("Informacion").ToString().Split('#');

            Nullable<int> facturaCabId = (Nullable<int>)fPickFactura.GetValor("FacturaCabId");

            if (facturaCabId != null)
            {
                //this.txtPresupAsoc.Text = fPickFactura.GetValor("NroFactura").ToString();
                //this.txtPresupuestosIDs.Text = facturaCabId.ToString();
                this.CargarFactura(facturaCabId.Value);
                fPickFactura.Hide();
            }

            //if (datosFactura.Count() > 0)
            //{
            //    this.MonedaID = Convert.ToInt32(datosFactura[4]);

            //    this.txtProveedor.Text = datosFactura[1] + " (" + datosFactura[0] + ")";
            //    this.txtFechaFactura.Text = datosFactura[2];
            //    this.txtNroFactura.Text = datosFactura[3];
            //    this.txtTipoFactura.Text = datosFactura[7];
            //    this.txtImporte.Text = datosFactura[6] + " " +
            //                            string.Format((this.MonedaID == MONEDA_GUARANI_ID ? FORMATO_SIN_DECIMALES : FORMATO_CON_DECIMALES), Convert.ToDecimal(fPickFactura.GetValor(CAMPO_IMPORTE).ToString().Replace('.', ',')));
            //    this.txtImporteVal.Text = Convert.ToDecimal(fPickFactura.GetValor(CAMPO_IMPORTE)).ToString();
            //    this.txtSaldo.Text = datosFactura[6] + " " +
            //                            string.Format((this.MonedaID == MONEDA_GUARANI_ID ? FORMATO_SIN_DECIMALES : FORMATO_CON_DECIMALES), Convert.ToDecimal(fPickFactura.GetValor(CAMPO_SALDO).ToString().Replace('.', ',')));
            //    this.txtSaldoVal.Text = Convert.ToDecimal(fPickFactura.GetValor(CAMPO_SALDO)).ToString();
            //    this.txtProveedorID.Text = datosFactura[0];
            //    this.txtTipoFacturaID.Text = datosFactura[8];
            //    int[] detalles = fPickFactura.ValorID.Split(',').Select(Int32.Parse).ToArray();

            //    var qry = (from spd in this.DBContext.spd_solicitudpagodet
            //               join spc in this.DBContext.spc_solicitudpagocab
            //                on spd.spd_solicitudpagocabid equals spc.spc_solicitudpagocabid
            //               join cli in this.DBContext.Cliente
            //                on spc.spc_clienteid equals cli.ID into spc_cli
            //               from cli in spc_cli.DefaultIfEmpty()
            //               join tar in this.DBContext.Tarifas
            //                on spd.spd_tarifaid equals tar.ID
            //               select new SolicitudExclusionDetalle
            //               {
            //                   SolicitudPagoCabeceraId = spd.spd_solicitudpagocabid,
            //                   SolicitudPagoCabeceraMonedaId = spc.spc_monedaid,
            //                   SolicitudPagoDetalleId = spd.spd_solicitudpagodetid,
            //                   SolicitudPagoDetalleMonto = spd.spd_total,
            //                   SolicitudPagoDetalleSaldo = spd.spd_saldo,
            //                   SolicitudPagoCabeceraObs = spc.spc_observacion,
            //                   SolicitudPagoCabeceraCliente = cli.Nombre,
            //                   SolicitudPagoDetalleTarifa = tar.Descripcion,
            //                   SolicitudPagoCabeceraAsocTramite = spc.spc_tipoasociacionpresup
            //               })
            //              .Where(a => detalles.Contains(a.SolicitudPagoDetalleId))
            //              .ToList();

            //    this.dgvSolDet.DataSource = qry;
            //    this.lblSolicitudesNro.Text = string.Format(TITULO_GRILLA_SOLICITUDES, string.Format(FORMATO_SIN_DECIMALES, qry.Count.ToString()));
            //    this.FormatearGrillaSolicitudes();
            //}

            //fPickFactura.Hide();
        }
        #endregion Factura

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

            //DateTime fe = Convert.ToDateTime(this.txtFechaFactura.Text).AddDays(-1);
            //decimal tipoCambio = this.GetTipoCambio(Convert.ToInt32(this.tSBMoneda.KeyMember), fe);

            //if (this.tSBMoneda.DisplayMember != GUARANIES)
            //{
            //    if (tipoCambio > 0)
            //    {
            //        this.txtTipoCambio.Text = String.Format(FORMATO_MONEDA_GUARANIES, tipoCambio);
            //        this.txtTipoCambio.Visible = true;
            //        this.lblTipoCambio.Visible = true;
            //    }
            //    else
            //    {
            //        this.txtTipoCambio.Text = String.Empty;
            //        this.txtTipoCambio.Visible = false;
            //        this.lblTipoCambio.Visible = false;
            //        MessageBox.Show(String.Format(ERROR_TC, this.tSBMoneda.DisplayMember, fe.ToString("dd/MM/yyyy")),
            //                        "Información de Error", MessageBoxButtons.OK,
            //                        MessageBoxIcon.Error);
            //    }
            //}
        }
        #endregion Moneda

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

            if (this.tSBCliente.KeyMember != string.Empty)
            {
                ClienteFacturaType cft = this.GetDatosCliente(Convert.ToInt32(this.tSBCliente.KeyMember));
                this.txtRUC.Text = cft.RUC;
                this.txtDireccion.Text = cft.Direccion;
                this.txtTelefono.Text = cft.Telefono;
                this.txtClienteIdiomaID.Text = cft.IdiomaID.ToString();
            }

        }

        private void tSBCliente_DisplayMemberLeave(object sender, EventArgs e)
        {
            if ((this.FormEditStatus == INSERT) || (this.FormEditStatus == EDIT))
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
        }

        #endregion Cliente

        #endregion Picks

        #region Combo Serie Factura
        private int cargarCBSerieNotaCredito()
        {
            List<CBSerie> lista = new List<CBSerie>();

            if (this.FormEditStatus == BROWSE)
            {
                lista = (from ti in this.DBContext.ti_timbrado
                         select new CBSerie
                         {
                             TimbradoID = ti.ti_timbradoid,
                             DescripcionTimbrado = ti.ti_descripcion,
                             Vigente = ti.ti_vigente,
                             TipoDocumentoID = ti.ti_tipodocumentoid
                         })
                         .OrderBy(b => b.TimbradoID)
                         .ToList();
            }
            else
            {
                lista = (from ti in this.DBContext.ti_timbrado
                         join su in this.DBContext.su_serieusuario
                             on ti.ti_timbradoid equals su.su_timbradoid
                         select new CBSerie
                         {
                             TimbradoID = ti.ti_timbradoid,
                             DescripcionTimbrado = ti.ti_descripcion,
                             Vigente = ti.ti_vigente,
                             UsuarioID = su.su_usuarioid,
                             TipoDocumentoID = ti.ti_tipodocumentoid
                         })
                         .Where(a => a.Vigente == true && a.UsuarioID == this.UsuarioID && a.TipoDocumentoID == TIPODOCUMENTO_NOTACREDITO_CLIENTE)
                         .OrderBy(b => b.TimbradoID)
                         .ToList();                
            }
            this.cbSerie.DataSource = lista;
            this.cbSerie.DisplayMember = "DescripcionTimbrado";
            this.cbSerie.ValueMember = "TimbradoID";

            return lista.Count;
        }
        #endregion Combo Serie Factura

        #region Combo Motivo Emision
        private int cargarCBMotivoEmision()
        {
            List<CBMotivoEmisionNC> lista = new List<CBMotivoEmisionNC>();

            if (this.FormEditStatus == BROWSE)
            {
                lista = (from me in this.DBContext.me_motivoemision
                         select new CBMotivoEmisionNC
                         {
                             MotivoEmisionID = me.me_motivoemisionid,
                             MotivoEmisionSIFENID = me.me_motivoemisionsifenid,
                             MotivoEmisionSIFENDescrip = me.me_motivoemisionsifendescrip,
                             Mostrar = me.me_mostrar
                         })
                         .OrderBy(a => a.MotivoEmisionSIFENID)
                         .ToList();
            }
            else
            {
                lista = (from me in this.DBContext.me_motivoemision
                         select new CBMotivoEmisionNC
                         {
                             MotivoEmisionID = me.me_motivoemisionid,
                             MotivoEmisionSIFENID = me.me_motivoemisionsifenid,
                             MotivoEmisionSIFENDescrip = me.me_motivoemisionsifendescrip,
                             Mostrar = me.me_mostrar
                         })
                         .Where(a => a.Mostrar)
                         .OrderBy(a => a.MotivoEmisionSIFENID)
                         .ToList();
            }

            this.cbMotivoEmision.DataSource = lista;
            this.cbMotivoEmision.DisplayMember = "MotivoEmisionSIFENDescrip";
            this.cbMotivoEmision.ValueMember = "MotivoEmisionID";

            return lista.Count;
        }
        #endregion Combo Motivo Emision

        #region Controles Locales
        private void ucCRUDPagoPresupuesto_VisibleChanged(object sender, EventArgs e)
        {
            if (this.tabListaABM.SelectedIndex == 0)
                this.FormatearGrilla();
        }

        private void tbbAnular_Click(object sender, EventArgs e)
        {
            if (!this.lblAutorizacionVigente.Visible)
            {
                MessageBox.Show("No se puede anular la nota crédito debido a que no posee autorización vigente.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;

            }

            if (this.txtEstado.Text == ESTADO_ANULADOVALOR)
            {
                MessageBox.Show("No se puede anular la nota crédito debido a que ya se encuentra en ese estado.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            if (this.txtEstadoDE.Text == ESTADO_PENDIENTE)
            {
                MessageBox.Show("No se puede anular la nota crédito debido a que el documento eletrónico se encuentra Pendiente." + 
                                Environment.NewLine +
                                "Sólo se pueden anular notas crédito cuyos documentos electrónicos se encuentren" +
                                "en estados Aprobado o Rechazado.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            string message = "Se anulará la presente nota crédito en la base datos ¿Desea continuar?";

            if (this.txtEstadoDE.Text == ESTADO_APROBADO)
            {
                message = "Se anulará la presente nota crédito en la base de datos." + Environment.NewLine +
                            "También se solicitará la cancelación del documento electrónico ¿Desea continuar?";

            }

            string caption = "";
            caption = "Anulación de nota crédito";
            
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
                    this.CargarNotaCredito(this.dgvListadoABM.Rows[this.LastDGVIndex]);
            }
                
        }

        private void dtpFechaFactura_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaNotaCredito.Text = this.dtpFechaFactura.Value.ToShortDateString();
            this.txtFechaNotaCredito.Focus();
            
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

        private string ObtenerTotalEnLetras(int idiomaID)
        {
            decimal total = Convert.ToDecimal(this.txtMontoTotal.Text);
            string monedaDescrip = this.tSBMoneda.DisplayMember;
            string totalEnLetras = "";

            if (idiomaID == IDIOMA_ESPANOL)
            {
                Numalet let = new Numalet();
                let.ConvertirDecimales = false;
                let.Decimales = 0;

                int number = (int)Math.Truncate(total);
                decimal decimalPart = total - number;
                if (decimalPart > 0)
                {
                    let.ConvertirDecimales = true;
                    let.Decimales = 2;
                }

                //totalEnLetras = let.ToCustomCardinal(total) + " " + monedaDescrip;

                if (monedaDescrip == DOLARES)
                    totalEnLetras = let.ToCustomCardinal(total) + " " + monedaDescrip;
                else
                    totalEnLetras = monedaDescrip + " " + let.ToCustomCardinal(total);

                let = null;
            }
            else
            {
                //totalEnLetras = this.NumberToText(total) + " " + monedaDescrip;

                if (monedaDescrip == DOLARES)
                    totalEnLetras = this.NumberToText(total) + " " + DOLLARS;
                else
                    totalEnLetras = monedaDescrip + " " + this.NumberToText(total);
            }

            return totalEnLetras.ToUpper();
        }

        #region Convertir Números a Texto
        public string NumberToText(decimal inputDecimal, bool isUK = true)
        {
            int number = (int)Math.Truncate(inputDecimal);
            decimal decimalPart = inputDecimal - number;

            string decimalPartString = "";
            if (decimalPart > 0)
                decimalPartString += " WITH " + this.NumberToText(decimalPart * 100);

            if (number == 0) return "Zero";
            string and = isUK ? "and " : ""; // deals with UK or US numbering
            if (number == -2147483648) return "Minus Two Billion One Hundred " + and +
            "Forty Seven Million Four Hundred " + and + "Eighty Three Thousand " +
            "Six Hundred " + and + "Forty Eight";
            int[] num = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (number < 0)
            {
                sb.Append("Minus ");
                number = -number;
            }

            //string[] words0 = new string[10];


            string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };
            string[] words1 = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };
            string[] words2 = { "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };
            string[] words3 = { "Thousand ", "Million ", "Billion " };

            num[0] = number % 1000;           // units
            num[1] = number / 1000;
            num[2] = number / 1000000;
            num[1] = num[1] - 1000 * num[2];  // thousands
            num[3] = number / 1000000000;     // billions
            num[2] = num[2] - 1000 * num[3];  // millions
            for (int i = 3; i > 0; i--)
            {
                if (num[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (int i = first; i >= 0; i--)
            {
                if (num[i] == 0) continue;
                u = num[i] % 10;              // ones
                t = num[i] / 10;
                h = num[i] / 100;             // hundreds
                t = t - 10 * h;               // tens
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    if (h > 0 || i < first) sb.Append(and);
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }
            return sb.ToString().TrimEnd() + decimalPartString;
        }
        #endregion Convertir Números a Texto

        private ClienteFacturaType GetDatosCliente(int clienteID)
        {
            ClienteFacturaType cft = new ClienteFacturaType();
            Cliente cliente = this.DBContext.Cliente.FirstOrDefault(a => a.ID == clienteID);
            
            cft.ClienteID = clienteID;
            cft.ClienteNombre = cliente.Nombre;
            cft.RUC = cliente.RUC;
            cft.Telefono = this.GetTelefonoCliente(cliente);
            cft.Direccion = this.TruncateString(this.ObtenerDireccionDesdeCorreo(cliente.Correo), 255);
            cft.IdiomaID = cliente.IdiomaID.Value;

            return cft;
        }

        private string GetTelefonoCliente(Cliente cliente)
        {
            int[] vias = new int[] { VIA_TELEFONO, VIA_TELEFAX, VIA_CELULAR };

            CPais pais = this.DBContext.CPais.FirstOrDefault(a => a.idpais == cliente.PaisID);
            //Berke.Libs.Base.Helpers.AccesoDB db = new Berke.Libs.Base.Helpers.AccesoDB(this.DBContext.Database.Connection.DataSource,
            //                                                                            this.DBContext.Database.Connection.Database);
            Berke.Libs.Base.Helpers.AccesoDB db = new Berke.Libs.Base.Helpers.AccesoDB(this.DBContext.Database.Connection.ConnectionString);
            Berke.Libs.Boletin.Services.ClienteService cS = new Berke.Libs.Boletin.Services.ClienteService(db);

            string telefono = string.Empty;
            foreach(int via in vias)
            {
                telefono = cS.getClienteVia(cliente.ID, via);

                if (telefono != string.Empty)
                    break;
            }

            db.CerrarConexion();

            return (cliente.Ddi.HasValue ? "+" + pais.paistel.ToString() + cliente.Ddi.Value.ToString() : String.Empty) + telefono;
        }

        private string ObtenerDireccionDesdeCorreo(string correo)
        {
            string result = String.Empty;
            int c = 0;
            foreach (string val in correo.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None))
            {
                if (c > 0)
                    result += " " + val;

                c++;
            }

            return result.TrimStart().TrimEnd();
        }

        private string TruncateString(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
            //try
            //{
            //    if (fSelecPresupFactura == null)
            //    {
            //        fSelecPresupFactura = new FSelecPresupFactura(this.DBContext, "Selección de Documentos");
            //        //fSelecPresupFactura.FormClosed += delegate { fSelecPresupFactura = null; this.CheckTipoCambio(); };
            //        fSelecPresupFactura.FormClosed += delegate { fSelecPresupFactura = null; };
            //        fSelecPresupFactura.AceptarClick += f_AceptarClick;
            //    }

            //    fSelecPresupFactura.ListaPresupuestos = this.txtPresupAsoc.Text.Replace(", ", ",");
            //    fSelecPresupFactura.ShowDialog();

                
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Ocurrió un error: " + Environment.NewLine + ex.Message, "Información de Error", MessageBoxButtons.OK,
            //                    MessageBoxIcon.Error);
            //}
        }

        //private void CheckTipoCambio()
        //{
        //    if ((this.tSBMoneda.DisplayMember != String.Empty) && (this.tSBMoneda.DisplayMember != GUARANIES))
        //    {
        //        DateTime fe = Convert.ToDateTime(this.txtFechaFactura.Text).AddDays(-1);
        //        decimal tipoCambio = this.GetTipoCambio(Convert.ToInt32(this.tSBMoneda.KeyMember), fe);

        //        if (tipoCambio > 0)
        //        {
        //            this.txtTipoCambio.Text = String.Format(FORMATO_MONEDA_GUARANIES, tipoCambio);
        //            this.txtTipoCambio.Visible = true;
        //            this.lblTipoCambio.Visible = true;
        //        }
        //        else
        //        {
        //            this.txtTipoCambio.Text = String.Empty;
        //            this.txtTipoCambio.Visible = false;
        //            this.lblTipoCambio.Visible = false;
        //            MessageBox.Show(String.Format(ERROR_TC, this.tSBMoneda.DisplayMember, fe.ToString("dd/MM/yyyy")),
        //                            "Información de Error", MessageBoxButtons.OK,
        //                            MessageBoxIcon.Error);
        //        }
        //    }
        //}

        #endregion Métodos Locales

        #region Método Extendidos del ParentControl
        protected override void FilterEntity(string where = "", object[] filterParams = null)
        {
            try
            {
                this.limpiarDatos();

                var query = (from nc in this.DBContext.nc_notacreditocabecera
                             join nd in this.DBContext.nd_notacreditodetalle
                                 on nc.nc_notacreditocabeceraid equals nd.nd_notacreditocabeceraid
                             join mon in this.DBContext.Moneda
                                 on nc.nc_monedaid equals mon.ID
                             join AudFc in this.DBContext.Audit_nc_notacreditocabecera
                                 on nc.nc_notacreditocabeceraid equals AudFc.nc_notacreditocabeceraid
                             join cli in this.DBContext.Cliente
                                 on nc.nc_clienteid equals cli.ID into nc_cli
                             from cli in nc_cli.DefaultIfEmpty()
                             join uAud in this.DBContext.Usuario
                                 on AudFc.Audit_User.Substring(6, AudFc.Audit_User.Length) equals uAud.Usuario1
                             join ti in this.DBContext.ti_timbrado
                                 on nc.nc_timbradoid equals ti.ti_timbradoid
                             join me in this.DBContext.me_motivoemision
                                on nc.nc_motivoemisionid equals me.me_motivoemisionid
                             join fc in this.DBContext.fc_facturacabecera
                                on nc.nc_facturacabid equals fc.fc_facturacabeceraid into nc_fc
                                from fc in nc_fc.DefaultIfEmpty()
                             join ti2 in this.DBContext.ti_timbrado
                                on fc.fc_timbradoid equals ti2.ti_timbradoid
                             select new NotaCreditoAllType
                         {
                             //Cabecera
                             NotaCreditoFecha = nc.nc_fechanotacredito,
                             NotaCreditoCabeceraID = nc.nc_notacreditocabeceraid,
                             NotaCreditoTimbradoID = nc.nc_timbradoid,
                             NotaCreditoTimbradoHojaSuelta = ti.ti_facthojasuelta,
                             NotaCreditoNro = nc.nc_nronotacredito,
                             Anulado = nc.nc_anulado,
                             ClienteID = nc.nc_clienteid,
                             ClienteNombre = nc.nc_clientenombre,
                             ClienteIdiomaID = cli.IdiomaID,
                             Direccion = nc.nc_direccion,
                             NotaCreditoTipo = nc.nc_tiponotacredito,
                             RUC = nc.nc_ruc,
                             NroRemision = nc.nc_nroremision,
                             Telefono = nc.nc_telefono,
                             MonedaID = nc.nc_monedaid,
                             MonedaAbrev = mon.AbrevMoneda,
                             MonedaDescripcion = mon.Descripcion,
                             TotalExentas = nc.nc_totalexentas,
                             TotalIVA5 = nc.nc_totaliva5,
                             TotalIVA10 = nc.nc_totaliva10,
                             TotalIVA = nc.nc_totaliva5 + nc.nc_totaliva10, //nc.nc_totaliva,
                             LiqIVA5 = nc.nc_liqiva5,
                             LiqIVA10 = nc.nc_liqiva10,
                             TotalLiqIVA = nc.nc_totaliva,
                             TotalNotaCredito = nc.nc_total,
                             TotalLetras = nc.nc_totalletras,
                             DocumentosAsociados = nc.nc_documentosasoc,
                             UsuarioCargaID = uAud.ID,
                             UsuarioCargaNombre = uAud.NombrePila,
                             AuditOperacion = AudFc.Audit_Operacion,
                             CDC = nc.nc_cdc,
                             DE = nc.nc_documentoelectronico,
                             Lote = nc.nc_lote,
                             EstadoDE = nc.nc_estadode,
                             TipoCambio = nc.nc_tipocambio,
                             MotivoEmisionID = nc.nc_motivoemisionid,
                             MotivoEmisionDescrip = me.me_motivoemisionsifendescrip,
                             FacturaCabId = nc.nc_facturacabid,
                             FacturaCDC = fc.fc_cdc,
                             FacturaFecha = fc.fc_fechafactura,
                             FacturaNroTimbrado = ti2.ti_nrotimbrado,
                             FacturaDE = fc.fc_documentoelectronico,
                             TieneAutorizacionVigente = this.DBContext.GetAutorizacionPorDocumentoID(TIPODOCUMENTO_NOTACREDITO_CLIENTE,
                                                                                                     nc.nc_notacreditocabeceraid,
                                                                                                     this.UsuarioID).FirstOrDefault().Value,
                             //Detalles
                             Cantidad = nd.nd_cantidad,
                             Descripcion = nd.nd_descripcion,
                             PrecioUnitario = nd.nd_preciounitario,
                             Exentas = nd.nd_exentas,
                             CincoPorciento = nd.nd_cincoporciento,
                             DiezPorciento = nd.nd_diezporciento,
                             PresupuestoCabID = nd.nd_presupuestocabid,
                             BoletaDepositoNro = nd.nd_nroboletadeposito,
                             CobroID = nd.nd_cobroid,
                             DescripcionFE = nd.nd_descripFE
                         })
                         .Where(b => b.AuditOperacion == AUDIT_OPERACION_INSERT && b.DE == true && timbrados.Contains(b.NotaCreditoTimbradoID.Value));

                lNotasCredito.Clear();

                if (where != "")
                {
                    lNotasCredito = query.Where(where, filterParams).OrderByDescending(a => a.NotaCreditoCabeceraID).ToList();
                }
                else
                {
                    //this.BindingSourceBase = query.OrderByDescending(a => a.NotaCreditoID).Take(50).ToList();
                    lNotasCredito = query.OrderByDescending(a => a.NotaCreditoCabeceraID).Take(200).ToList();
                }

                this.BindingSourceBase_ExportExcelGrid = lNotasCredito;

                var query1 = (from item in lNotasCredito
                             select new NotaCreditoCabType
                             {
                                 //Cabecera
                                 NotaCreditoFecha = item.NotaCreditoFecha,
                                 NotaCreditoCabeceraID = item.NotaCreditoCabeceraID,
                                 NotaCreditoTimbradoID = item.NotaCreditoTimbradoID,
                                 NotaCreditoTimbradoHojaSuelta = item.NotaCreditoTimbradoHojaSuelta,
                                 NotaCreditoNro = item.NotaCreditoNro,
                                 Anulado = item.Anulado,
                                 ClienteID = item.ClienteID,
                                 ClienteNombre = item.ClienteNombre,
                                 ClienteIdiomaID = item.ClienteIdiomaID,
                                 Direccion = item.Direccion,
                                 NotaCreditoTipo = item.NotaCreditoTipo,
                                 RUC = item.RUC,
                                 NroRemision = item.NroRemision,
                                 Telefono = item.Telefono,
                                 MonedaID = item.MonedaID,
                                 MonedaAbrev = item.MonedaAbrev,
                                 MonedaDescripcion = item.MonedaDescripcion,
                                 TotalExentas = item.TotalExentas,
                                 TotalIVA5 = item.TotalIVA5,
                                 TotalIVA10 = item.TotalIVA10,
                                 TotalIVA = item.TotalIVA,
                                 LiqIVA5 = item.LiqIVA5,
                                 LiqIVA10 = item.LiqIVA10,
                                 TotalLiqIVA = item.TotalLiqIVA,
                                 TotalNotaCredito = item.TotalNotaCredito,
                                 TotalLetras = item.TotalLetras,
                                 DocumentosAsociados = item.DocumentosAsociados,
                                 UsuarioCargaID = item.UsuarioCargaID,
                                 UsuarioCargaNombre = item.UsuarioCargaNombre,
                                 AuditOperacion = item.AuditOperacion,
                                 CDC = item.CDC,
                                 DE = item.DE,
                                 Lote = item.Lote,
                                 EstadoDE = item.EstadoDE,
                                 TipoCambio = item.TipoCambio,
                                 MotivoEmisionID = item.MotivoEmisionID,
                                 MotivoEmisionDescrip = item.MotivoEmisionDescrip,
                                 FacturaCabID = item.FacturaCabId,
                                 FacturaCDC = item.FacturaCDC,
                                 FacturaFecha = item.FacturaFecha,
                                 FacturaNroTimbrado = item.FacturaNroTimbrado,
                                 FacturaDE = item.FacturaDE,
                                 TieneAutorizacionVigente = item.TieneAutorizacionVigente
                             })
                             .GroupBy(x => new { x.NotaCreditoCabeceraID }).Select(g => g.First()).ToList();

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

            /*
             FacturaFecha = item.FacturaFecha,
                             FacturaNro = item.FacturaNro,
                             Anulado = item.Anulado,
                             ClienteID = item.ClienteID,
                             ClienteNombre = item.ClienteNombre,
             */


            this.dgvListadoABM.Columns[CAMPO_NOTACREDITOFECHA].HeaderText = "Fecha Fact.";
            this.dgvListadoABM.Columns[CAMPO_NOTACREDITOFECHA].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_NOTACREDITOFECHA].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_NOTACREDITOFECHA].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_NOTACREDITOFECHA].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_NOTACREDITONRO].HeaderText = "N° Factura";
            this.dgvListadoABM.Columns[CAMPO_NOTACREDITONRO].Width = 100;
            this.dgvListadoABM.Columns[CAMPO_NOTACREDITONRO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_NOTACREDITONRO].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_CLIENTENOMBRE].HeaderText = "Cliente";
            this.dgvListadoABM.Columns[CAMPO_CLIENTENOMBRE].Width = 200;
            this.dgvListadoABM.Columns[CAMPO_CLIENTENOMBRE].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_CLIENTENOMBRE].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_MONEDAABREV].HeaderText = "Moneda";
            this.dgvListadoABM.Columns[CAMPO_MONEDAABREV].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_MONEDAABREV].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_MONEDAABREV].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_TOTALNOTACREDITO].HeaderText = "Total";
            this.dgvListadoABM.Columns[CAMPO_TOTALNOTACREDITO].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_TOTALNOTACREDITO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_TOTALNOTACREDITO].DefaultCellStyle.Format = "N2";
            this.dgvListadoABM.Columns[CAMPO_TOTALNOTACREDITO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_TOTALNOTACREDITO].Visible = true;
            displayIndex++;

            //DataGridViewCheckBoxColumn colDE = new DataGridViewCheckBoxColumn();
            //colDE.DataPropertyName = CAMPO_DE;
            //colDE.Name = CAMPO_DE;
            //colDE.HeaderText = "DE";
            //colDE.FalseValue = false;
            //colDE.TrueValue = true;
            //colDE.ReadOnly = true;
            //this.dgvListadoABM.Columns.Insert(displayIndex, colDE);
            //displayIndex++;

            DataGridViewCheckBoxColumn colAnulado = new DataGridViewCheckBoxColumn();
            colAnulado.DataPropertyName = CAMPO_ANULADO;
            colAnulado.Name = CAMPO_ANULADO;
            colAnulado.HeaderText = "Anulado";
            colAnulado.FalseValue = false;
            colAnulado.TrueValue = true;
            colAnulado.ReadOnly = true;
            this.dgvListadoABM.Columns.Insert(displayIndex, colAnulado);
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_ESTADO_DE].HeaderText = "Estado DE";
            this.dgvListadoABM.Columns[CAMPO_ESTADO_DE].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_ESTADO_DE].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_ESTADO_DE].Visible = true;
            displayIndex++;
        }

        protected override void tbbNuevo_Click(object sender, EventArgs e)
        {
            base.tbbNuevo_Click(sender, e);

            if (this.cargarCBSerieNotaCredito() == 0)
            {
                MessageBox.Show("No cuenta con ningún timbrado habilitado para la generación de notas crédito." + Environment.NewLine +
                                "No se puede continuar.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                this.tbbCancelar_Click(sender, e);
                return;
            }

            this.limpiarDatos();
            this.dtpFechaFactura.Value = System.DateTime.Now;
            this.txtFechaNotaCredito.Text = System.DateTime.Now.ToShortDateString();
            this.txtEstado.Text = ESTADO_ACTIVOVALOR;
            this.cbSerie.Focus();
        }

        protected override void tbbEditar_Click(object sender, EventArgs e)
        {
            //if (this.txtEstado.Text == CAMPO_ANULADO)
            //{
            //    MessageBox.Show("No se puede editar el pago debido a que se encuentra anulado.",
            //                    "Información",
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Information);
            //    return;
            //}

            base.tbbEditar_Click(sender, e);
            this.cbSerie.Focus();
        }

        protected override void tbbCancelar_Click(object sender, EventArgs e)
        {
            base.tbbCancelar_Click(sender, e);
            this.cargarCBSerieNotaCredito();
            
            if (this.LastDGVIndex > -1)
            {
                this.CargarNotaCredito(this.dgvListadoABM.Rows[this.LastDGVIndex]);
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
                
            }
            else
            {
                
            }

            this.txtNotaCreditoID.ReadOnly = editar;
            this.txtGeneradoPorID.ReadOnly = editar;
            this.txtGeneradoPorNombre.ReadOnly = editar;
            this.cbSerie.Enabled = !editar;
            this.cbMotivoEmision.Enabled = !editar;
            this.grpTipoFactura.Enabled = !editar;
            this.txtEstado.ReadOnly = editar;
            this.txtFechaNotaCredito.ReadOnly = editar;
            this.dtpFechaFactura.Enabled = !editar;
            this.txtNroNotaCredito.ReadOnly = editar;
            this.txtNroRemision.ReadOnly = editar;
            this.tSBCliente.Editable = !editar;
            this.txtRUC.ReadOnly = editar;
            this.txtDireccion.ReadOnly = editar;
            this.txtTelefono.ReadOnly = editar;
            this.tSBMoneda.Editable = !editar;
            //this.txtMontoTotal.ReadOnly = editar;
            this.btnBuscar.Enabled = !editar;
            this.btnEliminarFila.Enabled = !editar;
            this.dgvDetNC.ReadOnly = editar;

            this.tbbAnular.Enabled = this.FormEditStatus == BROWSE;
            this.tbbActualizar.Enabled = this.FormEditStatus == BROWSE;
            this.tbbExportarExcel.Enabled = this.FormEditStatus == BROWSE;
        }
        #endregion ReadOnly condicional

        #region Limpiar Datos
        private void limpiarDatos()
        {
            this.txtNotaCreditoID.Text = string.Empty;
            this.txtGeneradoPorID.Text = string.Empty;
            this.txtGeneradoPorNombre.Text = string.Empty;
            this.cbSerie.SelectedIndex = 0;
            this.cbMotivoEmision.SelectedIndex = 0;
            //this.rbContado.Checked = true;
            this.txtEstado.Text = string.Empty;
            this.txtFechaNotaCredito.Text = string.Empty;
            this.txtNroNotaCredito.Text = string.Empty;
            this.txtNroRemision.Text = string.Empty;
            this.tSBCliente.Clear();
            this.txtClienteIdiomaID.Text = string.Empty;
            this.txtRUC.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.tSBMoneda.Clear();
            this.txtNroFactura.Text = string.Empty;
            this.txtFacturaCabID.Text = string.Empty;
            this.txtCDCFactura.Text = string.Empty;
            this.txtFechaFactura.Text = string.Empty;
            this.txtNroTimbradoFactura.Text = string.Empty;
            this.chkFacturaDE.Checked = false;
            this.txtCobrosIDs.Text = string.Empty;
            this.txtMontosCobros.Text = string.Empty;
            this.txtGeneradoPorID.Text = string.Empty;
            this.txtGeneradoPorNombre.Text = string.Empty;
            this.txtNroBoletas.Text = string.Empty;

            this.txtTotalIVA5.Text = CERO_SIN_DECIMALES;
            this.txtTotalIVA10.Text = CERO_SIN_DECIMALES;
            this.txtTotalIVA.Text = CERO_SIN_DECIMALES;

            this.txtLiqIVA5.Text = CERO_SIN_DECIMALES;
            this.txtLiqIVA10.Text = CERO_SIN_DECIMALES;
            this.txtLiqTotalIVA.Text = CERO_SIN_DECIMALES;

            this.txtMontoTotal.Text = CERO_SIN_DECIMALES;
            this.lblAutorizacionVigente.Visible = false;

            //this.dgvDetNC.DataSource = null;
            this.bS_Det.DataSource = null;

            this.txtHojaSuelta.Text = String.Empty;

            this.txtCDC.Text = String.Empty;
            this.txtLote.Text = String.Empty;
            this.txtEstadoDE.Text = String.Empty;
            this.chkDE.Checked = false;
            this.btnGenDE.Visible = false;
            this.btnVerMotivoRechazo.Visible = false;

            this.txtTipoCambio.Text = String.Empty;
            this.txtTipoCambio.Visible = false;
            this.lblTipoCambio.Visible = false;
        }
        #endregion Limpiar Datos

        #region CRUD
        
        private void CargarNotaCredito(DataGridViewRow row)
        {
            this.limpiarDatos();
            string formatoNumero = row.Cells[CAMPO_MONEDADESCRIPCION].Value.ToString() == GUARANIES ? FORMATO_MONEDA_GUARANIES : FORMATO_MONEDA_OTROS;
            try
            {
                this.txtNotaCreditoID.Text = row.Cells[CAMPO_NOTACREDITOCABECERAID].Value.ToString();
                this.cbSerie.SelectedValue = Convert.ToInt32(row.Cells[CAMPO_NOTACREDITOTIMBRADOID].Value.ToString());
                //this.rbContado.Checked = row.Cells[CAMPO_NOTACREDITOTIPO].Value.ToString() == FACTURA_CONTADO;
                //this.rbCredito.Checked = row.Cells[CAMPO_NOTACREDITOTIPO].Value.ToString() == FACTURA_CREDITO;
                this.txtEstado.Text = row.Cells[CAMPO_ANULADODESCRIPCION].Value.ToString();
                this.txtFechaNotaCredito.Text = Convert.ToDateTime(row.Cells[CAMPO_NOTACREDITOFECHA].Value.ToString()).ToShortDateString();
                this.dtpFechaFactura.Value = Convert.ToDateTime(row.Cells[CAMPO_NOTACREDITOFECHA].Value.ToString());
                this.txtNroNotaCredito.Text = row.Cells[CAMPO_NOTACREDITONRO].Value != null ? row.Cells[CAMPO_NOTACREDITONRO].Value.ToString() : string.Empty;
                this.txtNroRemision.Text = row.Cells[CAMPO_NROREMISION].Value != null ? row.Cells[CAMPO_NROREMISION].Value.ToString() : string.Empty;
                this.txtNroFactura.Text = string.Empty;
                this.tSBMoneda.KeyMember = row.Cells[CAMPO_MONEDAID].Value.ToString();
                this.tSBMoneda.DisplayMember = row.Cells[CAMPO_MONEDADESCRIPCION].Value.ToString();
                this.txtMonedadAbrev.Text = row.Cells[CAMPO_MONEDAABREV].Value.ToString();
                this.tSBCliente.KeyMember = row.Cells[CAMPO_CLIENTEID].Value != null ? row.Cells[CAMPO_CLIENTEID].Value.ToString() : string.Empty;
                this.tSBCliente.DisplayMember = row.Cells[CAMPO_CLIENTENOMBRE].Value.ToString();
                this.txtClienteIdiomaID.Text = row.Cells[CAMPO_CLIENTEIDIOMAID].Value != null ? row.Cells[CAMPO_CLIENTEIDIOMAID].Value.ToString() : string.Empty;
                this.txtRUC.Text = row.Cells[CAMPO_RUC].Value != null ? row.Cells[CAMPO_RUC].Value.ToString() : string.Empty;
                this.txtDireccion.Text = row.Cells[CAMPO_DIRECCION].Value != null ? row.Cells[CAMPO_DIRECCION].Value.ToString() : string.Empty;
                this.txtTelefono.Text = row.Cells[CAMPO_TELEFONO].Value != null ? row.Cells[CAMPO_TELEFONO].Value.ToString() : string.Empty;
                this.txtTotalIVA5.Text = String.Format(formatoNumero, Convert.ToDecimal(row.Cells[CAMPO_TOTALIVA5].Value.ToString()));
                this.txtTotalIVA10.Text = String.Format(formatoNumero, Convert.ToDecimal(row.Cells[CAMPO_TOTALIVA10].Value.ToString()));
                this.txtTotalIVA.Text = String.Format(formatoNumero, Convert.ToDecimal(row.Cells[CAMPO_TOTALIVA].Value.ToString()));
                this.txtLiqIVA5.Text = String.Format(formatoNumero, Convert.ToDecimal(row.Cells[CAMPO_LIQIVA5].Value.ToString()));
                this.txtLiqIVA10.Text = String.Format(formatoNumero, Convert.ToDecimal(row.Cells[CAMPO_LIQIVA10].Value.ToString()));
                this.txtLiqTotalIVA.Text = String.Format(formatoNumero, Convert.ToDecimal(row.Cells[CAMPO_TOTALLIQIVA].Value.ToString()));
                this.txtTotalExentas.Text = String.Format(formatoNumero, Convert.ToDecimal(row.Cells[CAMPO_TOTALEXENTAS].Value.ToString()));
                this.txtMontoTotal.Text = String.Format(formatoNumero, Convert.ToDecimal(row.Cells[CAMPO_TOTALNOTACREDITO].Value.ToString()));
                this.txtNroFactura.Text = row.Cells[CAMPO_DOCUMENTOSASOCIADOS].Value != null ? row.Cells[CAMPO_DOCUMENTOSASOCIADOS].Value.ToString() : string.Empty;
                this.txtGeneradoPorID.Text = row.Cells[CAMPO_USUARIOCARGAID].Value != null ? row.Cells[CAMPO_USUARIOCARGAID].Value.ToString() : string.Empty;
                this.txtGeneradoPorNombre.Text = row.Cells[CAMPO_USUARIOCARGANOMBRE].Value != null ? row.Cells[CAMPO_USUARIOCARGANOMBRE].Value.ToString() : string.Empty;
                this.lblAutorizacionVigente.Visible = (bool)row.Cells[CAMPO_AUTORIZACIONVIG].Value;

                this.txtCDC.Text = row.Cells[CAMPO_CDC].Value != null ? row.Cells[CAMPO_CDC].Value.ToString() : string.Empty;
                this.txtLote.Text = row.Cells[CAMPO_LOTE].Value != null ? row.Cells[CAMPO_LOTE].Value.ToString() : string.Empty;
                this.txtEstadoDE.Text = row.Cells[CAMPO_ESTADO_DE].Value != null ? row.Cells[CAMPO_ESTADO_DE].Value.ToString() : string.Empty;
                this.txtLote.Text = row.Cells[CAMPO_LOTE].Value != null ? row.Cells[CAMPO_LOTE].Value.ToString() : string.Empty;
                this.chkDE.Checked = row.Cells[CAMPO_DE].Value != null ? Convert.ToBoolean(row.Cells[CAMPO_DE].Value) : false;
                this.txtHojaSuelta.Text = ((row.Cells[CAMPO_NOTACREDITOHOJASUELTA].Value == null) || (!(bool)row.Cells[CAMPO_NOTACREDITOHOJASUELTA].Value)) ? HOJASUELTA_NO : HOJASUELTA_SI;

                this.btnGenDE.Visible = this.txtCDC.Text == String.Empty && this.txtEstadoDE.Text == String.Empty && this.txtLote.Text == String.Empty;
                this.btnActualizarEstadoDE.Visible = this.txtLote.Text != string.Empty && this.chkDE.Checked && this.txtEstadoDE.Text == ESTADO_PENDIENTE_DE;
                this.btnVerMotivoRechazo.Visible = this.txtEstadoDE.Text == ESTADO_RECHAZADO;

                this.cbMotivoEmision.SelectedValue = Convert.ToInt32(row.Cells[CAMPO_MOTIVOEMISIONID].Value.ToString());

                this.txtFacturaCabID.Text = row.Cells[CAMPO_FACTURACABID].Value != null ? row.Cells[CAMPO_FACTURACABID].Value.ToString() : string.Empty;
                this.txtCDCFactura.Text = row.Cells[CAMPO_FACTURACDC].Value != null ? row.Cells[CAMPO_FACTURACDC].Value.ToString() : string.Empty;
                this.txtFechaFactura.Text = row.Cells[CAMPO_FACTURAFECHA].Value != null ? Convert.ToDateTime(row.Cells[CAMPO_FACTURAFECHA].Value).ToString(FORMATO_FECHA_CORTA) : string.Empty;
                this.txtNroTimbradoFactura.Text = row.Cells[CAMPO_FACTURANROTIMBRADO].Value != null ? row.Cells[CAMPO_FACTURANROTIMBRADO].Value.ToString() : string.Empty;
                this.chkFacturaDE.Checked = row.Cells[CAMPO_FACTURADE].Value != null ? Convert.ToBoolean(row.Cells[CAMPO_FACTURADE].Value) : false;

                if (row.Cells[CAMPO_TIPO_CAMBIO].Value != null)
                {
                    this.txtTipoCambio.Visible = true;
                    this.lblTipoCambio.Visible = true;
                    //this.txtTipoCambio.Text = String.Format(FORMATO_MONEDA_GUARANIES, Convert.ToDecimal(row.Cells[CAMPO_TIPO_CAMBIO].Value.ToString()));
                    this.txtTipoCambio.Text = String.Format(FORMATO_MONEDA_OTROS, Convert.ToDecimal(row.Cells[CAMPO_TIPO_CAMBIO].Value.ToString()));
                }

                this.tbbImprimir.Visible = !(this.txtEstadoDE.Text == ESTADO_RECHAZADO) && this.txtCDC.Text != String.Empty;

                this.CargarDetallesNC(Convert.ToInt32(this.txtNotaCreditoID.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ImprimirFactura()
        {
            ReportDataSource datasource = null;
            datasource = new ReportDataSource("DataSet1", this.GenerarDatosFactura());

            //string path = this.txtHojaSuelta.Text == HOJASUELTA_NO  ? @"Reportes\Factura.rdlc" : @"Reportes\FacturaHojaSuelta.rdlc";

            string path = String.Empty;

            if (this.txtHojaSuelta.Text == HOJASUELTA_NO)
            {
                path = @"Reportes\Factura.rdlc";
            }
            else
            {
                if (this.cbSerie.GetItemText(this.cbSerie.SelectedItem) == SERIE_2)
                {
                    path = @"Reportes\FacturaHojaSuelta-Serie2.rdlc";
                }
                else
                {
                    path = @"Reportes\FacturaHojaSuelta-Serie1.rdlc";
                }
            }
            
            FReportViewerBase f = new FReportViewerBase(path, datasource, this.DBContext, String.Empty, true);
            f.FormClosed += delegate { f = null; };
            f.SoloImpresion(true);
            f.Titulo = "Factura N° " + this.txtNroNotaCredito.Text + " - " + (this.txtHojaSuelta.Text == HOJASUELTA_SI ? "HS" : "PC");
            f.NombreArchivoAdjunto = "Factura";
            f.AsuntoMail = "Factura";
            f.CuerpoMail = "Factura";
            f.ShowDialog();
        }

        private void ImprimirFacturaDigital()
        {
            ReportDataSource datasource = null;
            datasource = new ReportDataSource("DataSet1", this.GenerarDatosFacturaDigital());

            string path = @"Reportes\Factura-Digital.rdlc";

            FReportViewerBase f = new FReportViewerBase(path, datasource, this.DBContext, String.Empty, false, true);
            f.FormClosed += delegate { f = null; };
            f.SoloPDF(true);
            f.Titulo = "Factura N° " + this.txtNroNotaCredito.Text;
            f.NombreArchivoAdjunto = "Factura";
            f.AsuntoMail = "Factura";
            f.CuerpoMail = "Factura";
            f.ShowDialog();
        }

        private List<ImprimirFacturaType> GenerarDatosFactura()
        {
            List<ImprimirFacturaType> listaDatosFactura = new List<ImprimirFacturaType>();
            string formatoNumero = this.tSBMoneda.DisplayMember == GUARANIES ? FORMATO_MONEDA_GUARANIES: FORMATO_MONEDA_OTROS; 

            foreach (DataGridViewRow row in this.dgvDetNC.Rows)
            {
                ImprimirFacturaType datosFactura = new ImprimirFacturaType();
                datosFactura.FechaFactura = this.txtFechaNotaCredito.Text;
                datosFactura.ClienteNombre = this.tSBCliente.DisplayMember;
                datosFactura.FacturaContado = this.rbContado.Checked ? "X" : string.Empty;
                datosFactura.FacturaCredito = this.rbCredito.Checked ? "X" : string.Empty;
                datosFactura.RUC = this.txtRUC.Text;
                datosFactura.NroRemision = this.txtNroRemision.Text;
                datosFactura.Direccion = this.txtDireccion.Text;
                datosFactura.Telefono = this.txtTelefono.Text;
                datosFactura.Descripcion = row.Cells[CAMPO_DESCRIPCION].Value.ToString();
                datosFactura.MonedaAbrev = this.txtMonedadAbrev.Text;

                //datosFactura.Cantidad = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(Convert.ToDecimal(row.Cells[CAMPO_CANTIDAD].Value.ToString())))));
                //datosFactura.PrecioUnitario = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(Convert.ToDecimal(row.Cells[CAMPO_PRECIOUNITARIO].Value.ToString())))));
                //datosFactura.Exentas = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(Convert.ToDecimal(row.Cells[CAMPO_EXENTAS].Value.ToString())))));
                //datosFactura.CincoPorciento = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(Convert.ToDecimal(row.Cells[CAMPO_CINCOPORCIENTO].Value.ToString())))));
                //datosFactura.DiezPorciento = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(Convert.ToDecimal(row.Cells[CAMPO_DIEZPORCIENTO].Value.ToString())))));

                if (this.tSBMoneda.DisplayMember == GUARANIES)
                {
                    datosFactura.Cantidad = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(Convert.ToDecimal(row.Cells[CAMPO_CANTIDAD].Value.ToString())))));
                    datosFactura.PrecioUnitario = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(Convert.ToDecimal(row.Cells[CAMPO_PRECIOUNITARIO].Value.ToString())))));
                    datosFactura.Exentas = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(Convert.ToDecimal(row.Cells[CAMPO_EXENTAS].Value.ToString())))));
                    datosFactura.CincoPorciento = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(Convert.ToDecimal(row.Cells[CAMPO_CINCOPORCIENTO].Value.ToString())))));
                    datosFactura.DiezPorciento = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(Convert.ToDecimal(row.Cells[CAMPO_DIEZPORCIENTO].Value.ToString())))));
                }
                else
                {
                    datosFactura.Cantidad = this.EvaluarCero(String.Format(formatoNumero, (Convert.ToDecimal(row.Cells[CAMPO_CANTIDAD].Value.ToString()))));
                    datosFactura.PrecioUnitario = this.EvaluarCero(String.Format(formatoNumero, (Convert.ToDecimal(row.Cells[CAMPO_PRECIOUNITARIO].Value.ToString()))));
                    datosFactura.Exentas = this.EvaluarCero(String.Format(formatoNumero, (Convert.ToDecimal(row.Cells[CAMPO_EXENTAS].Value.ToString()))));
                    datosFactura.CincoPorciento = this.EvaluarCero(String.Format(formatoNumero, (Convert.ToDecimal(row.Cells[CAMPO_CINCOPORCIENTO].Value.ToString()))));
                    datosFactura.DiezPorciento = this.EvaluarCero(String.Format(formatoNumero, (Convert.ToDecimal(row.Cells[CAMPO_DIEZPORCIENTO].Value.ToString()))));
                }
                
                datosFactura.TotalExentas = this.EvaluarCero(this.txtTotalExentas.Text);
                datosFactura.TotalCincoPorciento = this.EvaluarCero(this.txtTotalIVA5.Text);
                datosFactura.TotalDiezPorciento = this.EvaluarCero(this.txtTotalIVA10.Text); //String.Format(formatoNumero, (decimal.Round(Convert.ToDecimal(this.txtMontoTotal.Text))));
                datosFactura.TotalFactura = this.txtMontoTotal.Text;
                datosFactura.TotalLetras = this.ObtenerTotalEnLetras(Convert.ToInt32(this.txtClienteIdiomaID.Text));
                datosFactura.LiqIVA5 = this.EvaluarCero(this.txtLiqIVA5.Text);
                datosFactura.LiqIVA10 = this.EvaluarCero(this.txtLiqIVA10.Text); //String.Format(formatoNumero, (decimal.Round(Convert.ToDecimal(this.txtMontoTotal.Text) / 11, MidpointRounding.AwayFromZero)));
                datosFactura.LiqIVATotal = this.EvaluarCero(this.txtLiqTotalIVA.Text); //datosFactura.LiqIVA10;
                listaDatosFactura.Add(datosFactura);
            }
            return listaDatosFactura;
        }

        private List<ImprimirFacturaType> GenerarDatosFacturaDigital()
        {
            List<ImprimirFacturaType> listaDatosFactura = new List<ImprimirFacturaType>();
            string formatoNumero = this.tSBMoneda.DisplayMember == GUARANIES ? FORMATO_MONEDA_GUARANIES : FORMATO_MONEDA_OTROS;

            DatosTimbrado dTimbrado = this.GetDatosTimbrado(Convert.ToInt32(this.txtNotaCreditoID.Text));

            foreach (DataGridViewRow row in this.dgvDetNC.Rows)
            {
                ImprimirFacturaType datosFactura = new ImprimirFacturaType();
                datosFactura.FechaFactura = this.txtFechaNotaCredito.Text;
                datosFactura.ClienteNombre = this.tSBCliente.DisplayMember;
                datosFactura.FacturaContado = this.rbContado.Checked ? "X" : string.Empty;
                datosFactura.FacturaCredito = this.rbCredito.Checked ? "X" : string.Empty;
                datosFactura.RUC = this.txtRUC.Text;
                datosFactura.NroRemision = this.txtNroRemision.Text;
                datosFactura.Direccion = this.txtDireccion.Text;
                datosFactura.Telefono = this.txtTelefono.Text;
                datosFactura.Descripcion = row.Cells[CAMPO_DESCRIPCION].Value.ToString();
                datosFactura.MonedaAbrev = this.txtMonedadAbrev.Text;
                //Datos para Impresión de Factura Digital
                datosFactura.NroTimbrado = dTimbrado.NroTimbrado.ToString();
                datosFactura.VigenciaInicio = Convert.ToDateTime(dTimbrado.VigenciaInicio).ToShortDateString();
                datosFactura.VigenciaFin = Convert.ToDateTime(dTimbrado.VigenciaFin).ToShortDateString();
                datosFactura.NroFactura = dTimbrado.NroFactura;
                datosFactura.Anulado = dTimbrado.Anulado;

                //datosFactura.Cantidad = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(Convert.ToDecimal(row.Cells[CAMPO_CANTIDAD].Value.ToString())))));
                //datosFactura.PrecioUnitario = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(Convert.ToDecimal(row.Cells[CAMPO_PRECIOUNITARIO].Value.ToString())))));
                //datosFactura.Exentas = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(Convert.ToDecimal(row.Cells[CAMPO_EXENTAS].Value.ToString())))));
                //datosFactura.CincoPorciento = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(Convert.ToDecimal(row.Cells[CAMPO_CINCOPORCIENTO].Value.ToString())))));
                //datosFactura.DiezPorciento = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(Convert.ToDecimal(row.Cells[CAMPO_DIEZPORCIENTO].Value.ToString())))));

                if (this.tSBMoneda.DisplayMember == GUARANIES)
                {
                    datosFactura.Cantidad = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(Convert.ToDecimal(row.Cells[CAMPO_CANTIDAD].Value.ToString())))));
                    datosFactura.PrecioUnitario = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(Convert.ToDecimal(row.Cells[CAMPO_PRECIOUNITARIO].Value.ToString())))));
                    datosFactura.Exentas = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(Convert.ToDecimal(row.Cells[CAMPO_EXENTAS].Value.ToString())))));
                    datosFactura.CincoPorciento = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(Convert.ToDecimal(row.Cells[CAMPO_CINCOPORCIENTO].Value.ToString())))));
                    datosFactura.DiezPorciento = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(Convert.ToDecimal(row.Cells[CAMPO_DIEZPORCIENTO].Value.ToString())))));
                }
                else
                {
                    datosFactura.Cantidad = this.EvaluarCero(String.Format(formatoNumero, (Convert.ToDecimal(row.Cells[CAMPO_CANTIDAD].Value.ToString()))));
                    datosFactura.PrecioUnitario = this.EvaluarCero(String.Format(formatoNumero, (Convert.ToDecimal(row.Cells[CAMPO_PRECIOUNITARIO].Value.ToString()))));
                    datosFactura.Exentas = this.EvaluarCero(String.Format(formatoNumero, (Convert.ToDecimal(row.Cells[CAMPO_EXENTAS].Value.ToString()))));
                    datosFactura.CincoPorciento = this.EvaluarCero(String.Format(formatoNumero, (Convert.ToDecimal(row.Cells[CAMPO_CINCOPORCIENTO].Value.ToString()))));
                    datosFactura.DiezPorciento = this.EvaluarCero(String.Format(formatoNumero, (Convert.ToDecimal(row.Cells[CAMPO_DIEZPORCIENTO].Value.ToString()))));
                }

                datosFactura.TotalExentas = this.EvaluarCero(this.txtTotalExentas.Text);
                datosFactura.TotalCincoPorciento = this.EvaluarCero(this.txtTotalIVA5.Text);
                datosFactura.TotalDiezPorciento = this.EvaluarCero(this.txtTotalIVA10.Text); //String.Format(formatoNumero, (decimal.Round(Convert.ToDecimal(this.txtMontoTotal.Text))));
                datosFactura.TotalFactura = this.txtMontoTotal.Text;
                datosFactura.TotalLetras = this.ObtenerTotalEnLetras(Convert.ToInt32(this.txtClienteIdiomaID.Text));
                datosFactura.LiqIVA5 = this.EvaluarCero(this.txtLiqIVA5.Text);
                datosFactura.LiqIVA10 = this.EvaluarCero(this.txtLiqIVA10.Text); //String.Format(formatoNumero, (decimal.Round(Convert.ToDecimal(this.txtMontoTotal.Text) / 11, MidpointRounding.AwayFromZero)));
                datosFactura.LiqIVATotal = this.EvaluarCero(this.txtLiqTotalIVA.Text); //datosFactura.LiqIVA10;
                listaDatosFactura.Add(datosFactura);
            }
            return listaDatosFactura;
        }

        #region Métodos de Edición de Datos

        private DatosTimbrado GetDatosTimbrado(int facturaCabID)
        {
            List<DatosTimbrado> lDT = new List<DatosTimbrado>();

            lDT = (from ti in this.DBContext.ti_timbrado
                   join fc in this.DBContext.fc_facturacabecera
                     on ti.ti_timbradoid equals fc.fc_timbradoid
                   select new DatosTimbrado
                   {
                       FacturaCabID = fc.fc_facturacabeceraid,
                       NroTimbrado = ti.ti_nrotimbrado,
                       VigenciaInicio = ti.ti_vigenciadesde,
                       VigenciaFin = ti.ti_vigenciahasta,
                       NroFactura = fc.fc_nrofactura,
                       Anulado = fc.fc_anulado
                   })
                      .Where(a => a.FacturaCabID == facturaCabID)
                      .ToList();

            return lDT.FirstOrDefault();
        }

        private List<nd_notacreditodetalle> GetDetallesFactura()
        {
            List<nd_notacreditodetalle> Result = new List<nd_notacreditodetalle>();

            foreach (DataGridViewRow row in this.dgvDetNC.Rows)
            {
                //Nullable<int> cobroID = null;


                //if (row.Cells[CAMPO_COBROID].Value != null)
                //    cobroID = Convert.ToInt32(row.Cells[CAMPO_COBROID].Value.ToString());

                Result.Add(new nd_notacreditodetalle
                {
                    nd_notacreditocabeceraid = 0,
                    nd_cantidad = Convert.ToDecimal(row.Cells[CAMPO_CANTIDAD].Value.ToString()),
                    nd_descripcion = @row.Cells[CAMPO_DESCRIPCION].Value != null ? row.Cells[CAMPO_DESCRIPCION].Value.ToString() : string.Empty,
                    nd_descripFE = @row.Cells[CAMPO_DESCRIPCION_FE].Value != null ? row.Cells[CAMPO_DESCRIPCION_FE].Value.ToString() : string.Empty,
                    nd_preciounitario = Convert.ToDecimal(row.Cells[CAMPO_PRECIOUNITARIO].Value.ToString()),
                    nd_exentas = Convert.ToDecimal(row.Cells[CAMPO_EXENTAS].Value.ToString()),
                    nd_cincoporciento = Convert.ToDecimal(row.Cells[CAMPO_CINCOPORCIENTO].Value.ToString()),
                    nd_diezporciento = Convert.ToDecimal(row.Cells[CAMPO_DIEZPORCIENTO].Value.ToString()),
                    //nd_presupuestocabid = Convert.ToInt32(row.Cells[CAMPO_PRESUPUESTOCABID].Value.ToString()),
                    //nd_nroboletadeposito = row.Cells[CAMPO_BOLETADEPOSITONRO].Value != null ? row.Cells[CAMPO_BOLETADEPOSITONRO].Value.ToString() : string.Empty,
                    //nd_cobroid = cobroID
                });

            }
            return Result;
        }

        private void ucCRUDNCElectronicaCliente_CRUDEvent(object sender, EventArgs e)
        {
            this.CalcularTotal();
            nc_notacreditocabecera nc = new nc_notacreditocabecera();
            nc.nc_notacreditocabeceraid = 0;
            nc.nc_timbradoid = Convert.ToInt32(this.cbSerie.SelectedValue.ToString());
            nc.nc_motivoemisionid = Convert.ToInt32(this.cbMotivoEmision.SelectedValue.ToString());
            //fc.fc_nrofactura: Ver la manera de obtener el número vía trigger
            nc.nc_anulado = false;
            nc.nc_fechanotacredito = Convert.ToDateTime(this.txtFechaNotaCredito.Text);

            if (this.tSBCliente.KeyMember != string.Empty)
                nc.nc_clienteid = Convert.ToInt32(this.tSBCliente.KeyMember);
            else nc.nc_clienteid = null;

            nc.nc_clientenombre = this.tSBCliente.DisplayMember;

            if (this.txtNroRemision.Text != string.Empty)
                nc.nc_nroremision = this.txtNroRemision.Text;

            if (this.txtDireccion.Text != string.Empty)
                nc.nc_direccion = this.txtDireccion.Text;

            //nc.nc_tiponotacredito = this.rbContado.Checked ? FACTURA_CONTADO : FACTURA_CREDITO;

            if (this.txtRUC.Text != string.Empty)
                nc.nc_ruc = this.txtRUC.Text;

            if (this.txtTelefono.Text != string.Empty)
                nc.nc_telefono = this.txtTelefono.Text;

            if (this.txtNroFactura.Text != string.Empty)
                nc.nc_documentosasoc = this.txtNroFactura.Text;

            if (this.txtTipoCambio.Text != string.Empty)
                nc.nc_tipocambio = Convert.ToDecimal(this.txtTipoCambio.Text);

            nc.nc_monedaid = Convert.ToInt32(this.tSBMoneda.KeyMember);
            nc.nc_totalexentas = Convert.ToDecimal(this.txtTotalExentas.Text);
            nc.nc_totaliva5 = Convert.ToDecimal(this.txtTotalIVA5.Text);
            nc.nc_totaliva10 = Convert.ToDecimal(this.txtTotalIVA10.Text);
            nc.nc_liqiva5 = Convert.ToDecimal(this.txtLiqIVA5.Text);
            nc.nc_liqiva10 = Convert.ToDecimal(this.txtLiqIVA10.Text);
            nc.nc_totaliva = Convert.ToDecimal(this.txtLiqTotalIVA.Text);
            nc.nc_total = Convert.ToDecimal(this.txtMontoTotal.Text);
            nc.nc_totalletras = this.ObtenerTotalEnLetras(Convert.ToInt32(this.txtClienteIdiomaID.Text));
            nc.nc_facturacabid = Convert.ToInt32(this.txtFacturaCabID.Text);
            nc.nc_documentoelectronico = true;

            if (this.FormEditStatus != BROWSE)
            {
                List<nd_notacreditodetalle> detalles = this.GetDetallesFactura();
                nc = this.GuardarRegistroLocal<nc_notacreditocabecera, nd_notacreditodetalle>(nc,
                                                                                 detalles,
                                                                                 CAMPO_NOTACREDITOCABECERAPK_TABLA,
                                                                                 CAMPO_NOTACREDITODETALLEFK_TABLA);
            }

            if (nc != null)
            {
                int index = 0;
                if (this.FormEditStatus == INSERT)
                {
                    this.FilterEntity("", null);
                    this.CargarNotaCredito(this.dgvListadoABM.Rows[0]);
                }

                this.FormEditStatus = BROWSE;
                this.dgvListadoABM.CurrentCell = this.dgvListadoABM.Rows[index].Cells[CAMPO_NOTACREDITOFECHA];
                this.dgvListadoABM.CurrentCell.Selected = true;

                this.GenDE(nc.nc_notacreditocabeceraid);
                
            }
        }

        private void ucCRUDNCElectronicaCliente_ValidarCamposEvent(object sender, EventArgs e)
        {
            #region Validaciones
            DateTime fec = new DateTime();
            if ((this.txtFechaNotaCredito.Text == string.Empty) || (!DateTime.TryParseExact(this.txtFechaNotaCredito.Text,
                                                                                        "dd/MM/yyyy",
                                                                                        null,
                                                                                        System.Globalization.DateTimeStyles.None,
                                                                                        out fec)))
            {
                MessageBox.Show("Debe ingresar una fecha de nota crédito válida.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            //if (this.txtPresupAsoc.Text == string.Empty)
            //{
            //    MessageBox.Show("Debe ingresar algún documento asociado a la factura.",
            //                    "Información",
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Information);

            //    return;
            //}

            if (this.tSBMoneda.KeyMember == string.Empty)
            {
                MessageBox.Show("Debe ingresar una moneda para la nota crédito.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            //if ((this.tSBMoneda.DisplayMember != GUARANIES) && (this.txtTipoCambio.Text == String.Empty))
            //{
            //    MessageBox.Show(String.Format(ERROR_TC, this.tSBMoneda.DisplayMember, fec.AddDays(-1).ToString("dd/MM/yyyy")),
            //                    "Información",
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Information);

            //    return;
            //}

            if (this.tSBMoneda.DisplayMember != GUARANIES)
            {
                DateTime fe = Convert.ToDateTime(this.txtFechaNotaCredito.Text).AddDays(-1);
                decimal tipoCambio = this.GetTipoCambio(Convert.ToInt32(this.tSBMoneda.KeyMember), fe);

                if (tipoCambio > 0)
                {
                    //this.txtTipoCambio.Text = String.Format(FORMATO_MONEDA_GUARANIES, tipoCambio);
                    this.txtTipoCambio.Text = String.Format(FORMATO_MONEDA_OTROS, tipoCambio);
                    this.txtTipoCambio.Visible = true;
                    this.lblTipoCambio.Visible = true;
                }
                else
                {
                    this.txtTipoCambio.Text = String.Empty;
                    this.txtTipoCambio.Visible = false;
                    this.lblTipoCambio.Visible = false;
                    MessageBox.Show(String.Format(ERROR_TC, this.tSBMoneda.DisplayMember, fe.ToString("dd/MM/yyyy")),
                                    "Información de Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }
            }

            if (this.tSBCliente.DisplayMember == string.Empty)
            {
                MessageBox.Show("Debe ingresar un nombre de cliente para la nota crédito.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            //if ((this.dgvDetNC.DataSource == null) || (this.dgvDetNC.Rows.Count == 0))
            if ((this.bS_Det.DataSource == null) || (this.dgvDetNC.Rows.Count == 0))
            {
                MessageBox.Show("No se puede procesar una nota crédito sin detalles.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;

            }

            if (!this.ValidarDetallesGravadas())
            {
                MessageBox.Show("El detalle de una factura sólo puede ser gravado al 5% o al 10%, no ambos.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            this.ValidOK = true;
            #endregion Validaciones
        }

        private bool ValidarDetallesGravadas()
        {
            bool result = true;

            foreach (DataGridViewRow row in this.dgvDetNC.Rows)
            {
                decimal gravadas5 = Convert.ToDecimal(row.Cells[CAMPO_CINCOPORCIENTO].Value);
                decimal gravadas10 = Convert.ToDecimal(row.Cells[CAMPO_DIEZPORCIENTO].Value);

                if ((gravadas5 > 0) && (gravadas10 > 0))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        private void AnularDialogHandler(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    this.AnularNC(Convert.ToInt32(this.txtNotaCreditoID.Text));
                }
            }
        }

        private void AnularNC(int NotaCreditoID)
        {
            bool success = false;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        nc_notacreditocabecera nc = context.nc_notacreditocabecera.First(a => a.nc_notacreditocabeceraid == NotaCreditoID);
                        nc.nc_anulado = true;
                        nc.nc_fechaanulacion = System.DateTime.Now;
                        nc.nc_usuarioanulacion = VWGContext.Current.Session["WindowsUser"].ToString();

                        if (this.txtEstadoDE.Text == ESTADO_APROBADO)
                        {
                            string motivoAnulacion = context
                                                        .GetAutorizacionMotivoPorDocumentoID(TIPODOCUMENTO_NOTACREDITO_CLIENTE, nc.nc_notacreditocabeceraid, this.UsuarioID)
                                                        .FirstOrDefault()
                                                        .Motivo;
                            SifenCancelResponse queryResponse = this.CancelarDE(this.txtCDC.Text, motivoAnulacion);

                            if (queryResponse.estado == ESTADO_APROBADO)
                            {
                                nc.nc_estadode = ESTADO_CANCELADO;

                                fc_facturacabecera fc = context.fc_facturacabecera.First(a => a.fc_facturacabeceraid == nc.nc_facturacabid);
                                fc.fc_estadode = ESTADO_APROBADO;
                            }
                            else throw new Exception(queryResponse.estado + " - " + queryResponse.msgRespuesta);
                        }

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
                        MessageBox.Show("Ocurrió un error al anular la factura."
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
                this.CargarNotaCredito(this.dgvListadoABM.Rows[this.LastDGVIndex]);
                MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion Métodos de Edición de Datos

        #region Eventos delegados
        private void f_AceptarClick(object sender, EventArgs e)
        {
            this.txtNroFactura.Text = fSelecPresupFactura.ListaPresupuestos;
            this.tTBaseForm.SetToolTip(this.txtNroFactura, this.txtNroFactura.Text);
            this.txtFacturaCabID.Text = fSelecPresupFactura.ListaPresupuestosIDs;
            this.txtCobrosIDs.Text = fSelecPresupFactura.ListaCobrosIDs;
            this.txtNroBoletas.Text = fSelecPresupFactura.ListaNroBoletaDeps;
            this.txtMontosCobros.Text = fSelecPresupFactura.ListaMontosCobros;
            
            if (fSelecPresupFactura.ClienteID > 0)
            {
                ClienteFacturaType cft = this.GetDatosCliente(fSelecPresupFactura.ClienteID);
                this.tSBCliente.KeyMember = cft.ClienteID.ToString();
                this.tSBCliente.DisplayMember = cft.ClienteNombre;
                this.txtRUC.Text = cft.RUC;
                this.txtDireccion.Text = cft.Direccion;
                this.txtTelefono.Text = cft.Telefono;
                this.txtClienteIdiomaID.Text = cft.IdiomaID.ToString();
            }

            if (fSelecPresupFactura.MonedaID > 0)
            {
                this.tSBMoneda.KeyMember = fSelecPresupFactura.MonedaID.ToString();
                this.tSBMoneda.DisplayMember = fSelecPresupFactura.MonedaDescrip;
                this.txtMonedadAbrev.Text = fSelecPresupFactura.MonedaAbrev;
            }

            if (fSelecPresupFactura.CobroFechaDeposito.HasValue)
            {
                this.dtpFechaFactura.Value = fSelecPresupFactura.CobroFechaDeposito.Value;
                this.txtFechaNotaCredito.Text = fSelecPresupFactura.CobroFechaDeposito.Value.ToShortDateString();
            }

            if (this.txtFacturaCabID.Text != string.Empty)
            {
                this.dgvDetNC.DataSource = this.ObtenerDatosPresupuestos();

                if (this.dgvDetNC.RowCount > 0)
                {
                    this.FormatearGrillaDetalle();
                    this.CalcularTotal();
                }
            }

            fSelecPresupFactura.Close();
        }
        #endregion Eventos delegados
        

        #endregion CRUD

        private string SpliceText(string text, int lineLength)
        {
            return Regex.Replace(Regex.Replace(text, "(.{" + lineLength + "})(\\s|$)", "$1" + Environment.NewLine), @"[\r\n]{2,}", "\r\n");
            //return Regex.Replace(Regex.Replace(text, "(.{" + lineLength + "})(\\s|$)", "$1" + Environment.NewLine), @"(\r\n)+", "\r\n\r\n", RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase);
            //return Regex.Replace(text, "(.{" + lineLength + "})(\\s|$)", "$1" + Environment.NewLine);
        }

        private void FormatearGrillaDetalle()
        {
            this.dgvDetNC.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 11.5F, GraphicsUnit.Pixel);
            this.dgvDetNC.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dgvDetNC.DefaultCellStyle.Font = new Font("Arial", 11.5F, GraphicsUnit.Pixel);
            this.dgvDetNC.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvDetNC.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            this.dgvDetNC.ItemsPerPage = 4;
            this.dgvDetNC.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetNC.MultiSelect = false;
            this.dgvDetNC.AllowUserToDeleteRows = true;
            this.dgvDetNC.AllowUserToAddRows = false;
            //this.dgvDetFactura.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            foreach (DataGridViewColumn col in this.dgvDetNC.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            foreach (DataGridViewRow row in this.dgvDetNC.Rows)
            {
                row.Cells[CAMPO_DESCRIPCION].Value = this.SpliceText(row.Cells[CAMPO_DESCRIPCION].Value.ToString(), 80);
               
                string [] descrip = row.Cells[CAMPO_DESCRIPCION].Value.ToString().Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                if (descrip.Length > 1)
                {
                    row.Height = 22 * (descrip.Length - 1) + 8;
                }
            }

            int displayIndex = 0;

            this.dgvDetNC.Columns[CAMPO_CANTIDAD].HeaderText = "Cantidad";
            this.dgvDetNC.Columns[CAMPO_CANTIDAD].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDetNC.Columns[CAMPO_CANTIDAD].Width = 60;
            this.dgvDetNC.Columns[CAMPO_CANTIDAD].DisplayIndex = displayIndex;
            this.dgvDetNC.Columns[CAMPO_CANTIDAD].DefaultCellStyle.Format = this.tSBMoneda.DisplayMember == GUARANIES ? FORMATO_MONEDA_GUARANIES_GRILLA : FORMATO_MONEDA_OTROS_GRILLA;
            this.dgvDetNC.Columns[CAMPO_CANTIDAD].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvDetNC.Columns[CAMPO_CANTIDAD].Visible = true;
            this.dgvDetNC.Columns[CAMPO_CANTIDAD].ReadOnly = false;
            displayIndex++;

            //this.dgvDetFactura.Columns[CAMPO_DESCRIPCION_FE].HeaderText = "Descripción FE";
            //this.dgvDetFactura.Columns[CAMPO_DESCRIPCION_FE].Width = 200;
            //this.dgvDetFactura.Columns[CAMPO_DESCRIPCION_FE].DisplayIndex = displayIndex;
            //this.dgvDetFactura.Columns[CAMPO_DESCRIPCION_FE].Visible = true;
            //this.dgvDetFactura.Columns[CAMPO_DESCRIPCION_FE].ReadOnly = false;
            //displayIndex++;

            this.dgvDetNC.Columns[CAMPO_DESCRIPCION].HeaderText = "Descripción";
            this.dgvDetNC.Columns[CAMPO_DESCRIPCION].Width = 400;
            this.dgvDetNC.Columns[CAMPO_DESCRIPCION].DisplayIndex = displayIndex;
            this.dgvDetNC.Columns[CAMPO_DESCRIPCION].Visible = true;
            this.dgvDetNC.Columns[CAMPO_DESCRIPCION].ReadOnly = false;
            //this.dgvDetFactura.Columns[CAMPO_DESCRIPCION].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            ////this.dgvDetFactura.Columns[CAMPO_DESCRIPCION].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            displayIndex++;

            this.dgvDetNC.Columns[CAMPO_PRECIOUNITARIO].HeaderText = "Pr. Unit.";
            this.dgvDetNC.Columns[CAMPO_PRECIOUNITARIO].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDetNC.Columns[CAMPO_PRECIOUNITARIO].Width = 80;
            this.dgvDetNC.Columns[CAMPO_PRECIOUNITARIO].DisplayIndex = displayIndex;
            this.dgvDetNC.Columns[CAMPO_PRECIOUNITARIO].DefaultCellStyle.Format = this.tSBMoneda.DisplayMember == GUARANIES ? FORMATO_MONEDA_GUARANIES_GRILLA : FORMATO_MONEDA_OTROS_GRILLA;
            this.dgvDetNC.Columns[CAMPO_PRECIOUNITARIO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvDetNC.Columns[CAMPO_PRECIOUNITARIO].Visible = true;
            //this.dgvDetNC.Columns[CAMPO_PRECIOUNITARIO].ReadOnly = false;
            displayIndex++;

            this.dgvDetNC.Columns[CAMPO_EXENTAS].HeaderText = "Exentas";
            this.dgvDetNC.Columns[CAMPO_EXENTAS].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDetNC.Columns[CAMPO_EXENTAS].Width = 80;
            this.dgvDetNC.Columns[CAMPO_EXENTAS].DisplayIndex = displayIndex;
            this.dgvDetNC.Columns[CAMPO_EXENTAS].DefaultCellStyle.Format = this.tSBMoneda.DisplayMember == GUARANIES ? FORMATO_MONEDA_GUARANIES_GRILLA : FORMATO_MONEDA_OTROS_GRILLA;
            this.dgvDetNC.Columns[CAMPO_EXENTAS].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvDetNC.Columns[CAMPO_EXENTAS].Visible = true;
            this.dgvDetNC.Columns[CAMPO_EXENTAS].ReadOnly = false;
            displayIndex++;

            this.dgvDetNC.Columns[CAMPO_CINCOPORCIENTO].HeaderText = "5%";
            this.dgvDetNC.Columns[CAMPO_CINCOPORCIENTO].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDetNC.Columns[CAMPO_CINCOPORCIENTO].Width = 80;
            this.dgvDetNC.Columns[CAMPO_CINCOPORCIENTO].DisplayIndex = displayIndex;
            this.dgvDetNC.Columns[CAMPO_CINCOPORCIENTO].DefaultCellStyle.Format = this.tSBMoneda.DisplayMember == GUARANIES ? FORMATO_MONEDA_GUARANIES_GRILLA : FORMATO_MONEDA_OTROS_GRILLA;
            this.dgvDetNC.Columns[CAMPO_CINCOPORCIENTO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvDetNC.Columns[CAMPO_CINCOPORCIENTO].Visible = true;
            this.dgvDetNC.Columns[CAMPO_CINCOPORCIENTO].ReadOnly = false;
            displayIndex++;

            this.dgvDetNC.Columns[CAMPO_DIEZPORCIENTO].HeaderText = "10%";
            this.dgvDetNC.Columns[CAMPO_DIEZPORCIENTO].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDetNC.Columns[CAMPO_DIEZPORCIENTO].Width = 80;
            this.dgvDetNC.Columns[CAMPO_DIEZPORCIENTO].DisplayIndex = displayIndex;
            this.dgvDetNC.Columns[CAMPO_DIEZPORCIENTO].DefaultCellStyle.Format = this.tSBMoneda.DisplayMember == GUARANIES ? FORMATO_MONEDA_GUARANIES_GRILLA : FORMATO_MONEDA_OTROS_GRILLA;
            this.dgvDetNC.Columns[CAMPO_DIEZPORCIENTO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvDetNC.Columns[CAMPO_DIEZPORCIENTO].Visible = true;
            this.dgvDetNC.Columns[CAMPO_DIEZPORCIENTO].ReadOnly = false;
            displayIndex++;

            this.dgvDetNC.Columns[CAMPO_DETNOTACREDITOCABID].Visible = false;
        }

        private string GetLabel(int TramiteId, int ClienteId)
        {
            Tramite t = this.DBContext.Tramite.FirstOrDefault(a => a.ID == TramiteId);
            Cliente c = this.DBContext.Cliente.FirstOrDefault(a => a.ID == ClienteId);

            string result = c.IdiomaID == IDIOMA_ESPANOL ? t.EtiquetaEsp : t.EtiquetaIng;

            if (result == string.Empty)
                result = t.Descrip;

            return result;
        }

        private List<DetalleNotaCreditoType> ObtenerDatosPresupuestos()
        {
            List<DetalleNotaCreditoType> detFactura = new List<DetalleNotaCreditoType>();
            //#region Iteración
            //decimal[] dbx = this.txtMontosCobros.Text.Split(';').Select(decimal.Parse).ToArray();
            //int[] cbx = this.txtCobrosIDs.Text.Split(';').Select(int.Parse).ToArray();
            //int cx = 0;

            //foreach (string val in this.txtFacturaCabID.Text.Split(','))
            //{
            //    int PresupuestoCabID = Convert.ToInt32(val);
            //    pc_presupuestocab presup = this.DBContext.pc_presupuestocab.FirstOrDefault(a => a.pc_presupuestocabid == PresupuestoCabID);

            //    if ((presup.pc_origen == ORIGEN_M) || (presup.pc_origen == ORIGEN_O))
            //    {
            //        #region M/O
            //        var q = this.DBContext.cp_cotizacionesxpresup.Where(a => a.cp_presupuestocabid == PresupuestoCabID).ToList();

            //        //GetDatosBoletaDepCobro_Result dbx = this.DBContext.GetDatosBoletaDepCobro(PresupuestoCabID).FirstOrDefault();

            //        DetalleNotaCreditoType det = new DetalleNotaCreditoType();
            //        det.PresupuestoCabID = PresupuestoCabID;
            //        det.Cantidad = 1;
            //        det.PrecioUnitario = dbx[cx]; //presup.pc_total;
            //        det.Exentas = 0;
            //        det.CincoPorciento = 0;
            //        det.DiezPorciento = dbx[cx]; //presup.pc_total;
            //        det.BoletaDepositoNro = this.txtNroBoletas.Text;
            //        det.DescripcionFE = this.GetLabel(presup.pc_tramiteid, presup.pc_clienteid);

            //        if (cbx[cx] > 0)
            //            det.CobroID = cbx[cx];
            //        else det.CobroID = null;


            //        //det.BoletaDepositoNro = this.DBContext.GetDatosBoletaDepCobro(PresupuestoCabID).FirstOrDefault().NroBoletaDep;
                    
            //        string listaCotizaciones = "";
            //        int cantPropietarios = 0;
            //        string listaPropietarios = "";
            //        string gPropietario = "";

            //        //int cantClases = 0;
            //        string listaClases = string.Empty;
            //        //string gClase = string.Empty;

            //        //int cantDenominaciones = 0;
            //        string listaDenominaciones = string.Empty;
            //        //string gDenominacion = string.Empty;

            //        if (q.Count > 0)
            //        {
            //            foreach (var qRow in q)
            //            {
            //                if (listaCotizaciones != "")
            //                    listaCotizaciones += ",";

            //                int cotizacionID = qRow.cp_cotizacionid;
            //                listaCotizaciones += cotizacionID.ToString();

            //                int expedienteID = this.DBContext.cc_cotizacioncab.First(a => a.cc_cotizacioncabid == cotizacionID).cc_expedienteid.Value;
            //                List<GetDatosExpediente_Result> dExpe = this.DBContext.GetDatosExpediente(presup.pc_origen, expedienteID).ToList();

            //                if (dExpe.Count > 0)
            //                {
            //                    #region Propietarios
            //                    string propietario = dExpe.First().Propietario;

            //                    if (propietario != gPropietario)
            //                    {
            //                        cantPropietarios++;
            //                        gPropietario = propietario;

            //                        if (listaPropietarios != "")
            //                            listaPropietarios += ", ";

            //                        listaPropietarios += propietario;
            //                    }
            //                    #endregion Propietarios

            //                    #region Clases
            //                    string clase = dExpe.First().ClaseNro.HasValue ? dExpe.First().ClaseNro.Value.ToString() : string.Empty;
            //                    //cantClases++;
                                
            //                    if (listaClases != string.Empty)
            //                            listaClases += ", ";

            //                    listaClases += clase;
            //                    #endregion Clases

            //                    #region Denominaciones
            //                    string denominacion = dExpe.First().Denominacion;

            //                    //cantDenominaciones++;
            //                    if (listaDenominaciones != string.Empty)
            //                        listaDenominaciones += ", ";
                                
            //                    listaDenominaciones += "\"" + denominacion + "\"";
            //                    #endregion Denominaciones
            //                }
            //            }

            //            int TramiteID = presup.pc_tramiteid;
            //            List<RepHojaCotizacion_Result> repHojaCotizacion = new List<RepHojaCotizacion_Result>();
            //            repHojaCotizacion = this.DBContext.RepHojaCotizacion(listaCotizaciones,
            //                                                                 "A",
            //                                                                 TramiteID)
            //                                                                 .GroupBy(x => new { x.Acta }).Select(g => g.First())
            //                                                                 .ToList();

            //            string listaActas = string.Empty;
            //            string descripcion = string.Empty;
            //            if (repHojaCotizacion.Count > 0)
            //            {
            //                if (this.cbSerie.GetItemText(this.cbSerie.SelectedItem) == SERIE_2)
            //                {
            //                    if (Convert.ToInt32(this.txtClienteIdiomaID.Text) == IDIOMA_ESPANOL)
            //                    {
            //                        if (repHojaCotizacion.Count > 1)
            //                        {
            //                            descripcion = this.DBContext.pa_parametros.First(a => a.clave == DESCRIPCION_NOTACREDITO_SERIE2_PLU_ESP).valor;
            //                        }
            //                        else
            //                        {
            //                            descripcion = this.DBContext.pa_parametros.First(a => a.clave == DESCRIPCION_NOTACREDITO_SERIE2_SING_ESP).valor;
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (repHojaCotizacion.Count > 1)
            //                        {
            //                            descripcion = this.DBContext.pa_parametros.First(a => a.clave == DESCRIPCION_NOTACREDITO_SERIE2_PLU_ING).valor;
            //                        }
            //                        else
            //                        {
            //                            descripcion = this.DBContext.pa_parametros.First(a => a.clave == DESCRIPCION_NOTACREDITO_SERIE2_SING_ING).valor;
            //                        }
            //                    }                                
            //                }
            //                else
            //                {
            //                    int clienteIdioma = Convert.ToInt32(this.txtClienteIdiomaID.Text);
            //                    listaActas = Convert.ToInt32(this.txtClienteIdiomaID.Text) == IDIOMA_ESPANOL ? "Acta: " : "Application: ";
            //                    if (repHojaCotizacion.Count > 1)
            //                        listaActas = clienteIdioma == IDIOMA_ESPANOL ? "Actas: " : "Applications: ";

            //                    det.Descripcion = repHojaCotizacion.First().TramiteDescripcion;

            //                    if (clienteIdioma != IDIOMA_ESPANOL)
            //                    {
            //                        Tramite t = this.DBContext.Tramite.First(a => a.ID == TramiteID);

            //                        if (!String.IsNullOrEmpty(t.EtiquetaIng.Trim()))
            //                        {
            //                            det.Descripcion = t.EtiquetaIng;
            //                        }
            //                    }
            //                }

            //                int cantidadCaracteres = listaActas.Length;
            //                bool noPrimeraIteracion = true;

            //                foreach (RepHojaCotizacion_Result hcRow in repHojaCotizacion)
            //                {
            //                    if (!noPrimeraIteracion)
            //                    {
            //                        listaActas += ", ";
            //                        cantidadCaracteres += 1;
            //                    }

            //                    if (cantidadCaracteres + hcRow.Acta.Length > 75)
            //                    {
            //                        listaActas += Environment.NewLine;
            //                        cantidadCaracteres = 0;
            //                    }

            //                    listaActas += hcRow.Acta;
            //                    cantidadCaracteres += hcRow.Acta.Length;
            //                    noPrimeraIteracion = false;
            //                }

            //                if (this.cbSerie.GetItemText(this.cbSerie.SelectedItem) != SERIE_2)
            //                {
            //                    if (listaActas.Split(':')[1] != " --/--")
            //                    {
            //                        det.Descripcion += Environment.NewLine + listaActas;
            //                    }
            //                }
            //                else
            //                {
            //                    det.Descripcion = String.Format(descripcion,
            //                                                    repHojaCotizacion.First().TramiteDescripcion,
            //                                                    listaDenominaciones, listaActas, listaClases);
            //                }
            //            }

            //            if (this.cbSerie.GetItemText(this.cbSerie.SelectedItem) != SERIE_2)
            //            {
            //                string lblPropietarios = Convert.ToInt32(this.txtClienteIdiomaID.Text) == IDIOMA_ESPANOL ? "Propietario: {0}" : "Owner: {0}";
            //                if (cantPropietarios > 0)
            //                {
            //                    if (cantPropietarios > 1)
            //                        lblPropietarios = Convert.ToInt32(this.txtClienteIdiomaID.Text) == IDIOMA_ESPANOL ? "Propietarios: {0}" : "Owners: {0}";

            //                    if (listaPropietarios != string.Empty)
            //                        det.Descripcion += Environment.NewLine + String.Format(lblPropietarios, listaPropietarios);
            //                }

            //                det.Descripcion = det.Descripcion == null ? "Sin descripción" : det.Descripcion;
            //            }
            //            detFactura.Add(det);
            //        }
            //        #endregion M/O
            //    }
            //    else
            //    {
            //        #region C/R
            //        //GetDatosBoletaDepCobro_Result dbx = this.DBContext.GetDatosBoletaDepCobro(PresupuestoCabID).FirstOrDefault();

            //        DetalleNotaCreditoType det = new DetalleNotaCreditoType();
            //        det.PresupuestoCabID = PresupuestoCabID;
            //        det.Cantidad = 1;
            //        det.PrecioUnitario = dbx[cx]; //presup.pc_total;
            //        det.Exentas = 0;
            //        det.CincoPorciento = 0;
            //        det.DiezPorciento = dbx[cx]; //presup.pc_total;
            //        det.Descripcion = presup.pc_descripcion == null ? "Sin descripción" : presup.pc_descripcion;
            //        det.BoletaDepositoNro = this.txtNroBoletas.Text;
            //        //det.BoletaDepositoNro = this.DBContext.GetDatosBoletaDepCobro(PresupuestoCabID).FirstOrDefault().NroBoletaDep;
            //        det.DescripcionFE = this.GetLabel(presup.pc_tramiteid, presup.pc_clienteid);
            //        detFactura.Add(det);
            //        #endregion C/R
            //    }
            //    cx++;
            //}
            //#endregion Iteración

            return detFactura;
        }

        private void CargarDetallesNC(int notaCreditoCabID)
        {


            List<DetalleNotaCreditoType> listaDet = (from nd in this.DBContext.nd_notacreditodetalle
                                                     select new DetalleNotaCreditoType
                                                     {
                                                         NotaCreditoCabID = nd.nd_notacreditocabeceraid,
                                                         Cantidad = nd.nd_cantidad,
                                                         PrecioUnitario = nd.nd_preciounitario,
                                                         Exentas = nd.nd_exentas,
                                                         CincoPorciento = nd.nd_cincoporciento,
                                                         DiezPorciento = nd.nd_diezporciento,
                                                         Descripcion = nd.nd_descripcion,
                                                         DescripcionFE = nd.nd_descripFE
                                                     })
                                                     .Where(a => a.NotaCreditoCabID == notaCreditoCabID)
                                                     .ToList();

            //foreach (var row in listaDet)
            //{
            //    DetalleNotaCreditoType det = new DetalleNotaCreditoType();
            //    det.NotaCreditoCabID = det.NotaCreditoCabID;
            //    det.Cantidad = row.Cantidad;
            //    det.PrecioUnitario = row.PrecioUnitario;
            //    det.Exentas = 0;
            //    det.CincoPorciento = row.CincoPorciento;
            //    det.DiezPorciento = row.DiezPorciento;
            //    det.Descripcion = row.Descripcion;
            //    det.DescripcionFE = row.DescripcionFE;
            //    listaDet.Add(det);
            //}
            //this.dgvDetNC.DataSource = listaDet;
            this.bS_Det.DataSource = listaDet;
            this.FormatearGrillaDetalle();
        }

        private void dgvDetFactura_DataSourceChanged(object sender, EventArgs e)
        {
            //if (this.FormEditStatus != BROWSE)
            //{
            //    this.CalcularTotal();
            //}
        }

        private void CalcularTotal()
        {
            decimal totalExentas = 0;
            decimal totalIVA5 = 0;
            decimal totalIVA10 = 0;
            decimal totalIVA = 0;
            decimal totalGral = 0;

            decimal liqIVA5 = 0;
            decimal liqIVA10 = 0;
            decimal totalLiqIVA = 0;
            
            foreach (DataGridViewRow row in this.dgvDetNC.Rows)
            {
                //decimal iva10 = (Convert.ToDecimal(row.Cells[CAMPO_CANTIDAD].Value.ToString()) * Convert.ToDecimal(row.Cells[CAMPO_PRECIOUNITARIO].Value.ToString()));
                decimal iva10 = (Convert.ToDecimal(row.Cells[CAMPO_CANTIDAD].Value.ToString()) * Convert.ToDecimal(row.Cells[CAMPO_DIEZPORCIENTO].Value.ToString()));
                decimal iva5 = (Convert.ToDecimal(row.Cells[CAMPO_CANTIDAD].Value.ToString()) * Convert.ToDecimal(row.Cells[CAMPO_CINCOPORCIENTO].Value.ToString()));
                decimal exentas = (Convert.ToDecimal(row.Cells[CAMPO_CANTIDAD].Value.ToString()) * Convert.ToDecimal(row.Cells[CAMPO_EXENTAS].Value.ToString()));

                //totalExentas += Convert.ToDecimal(row.Cells[CAMPO_EXENTAS].Value.ToString());
                //totalIVA5 += Convert.ToDecimal(row.Cells[CAMPO_CINCOPORCIENTO].Value.ToString());
                //totalIVA10 += (Convert.ToDecimal(row.Cells[CAMPO_CANTIDAD].Value.ToString()) * Convert.ToDecimal(row.Cells[CAMPO_PRECIOUNITARIO].Value.ToString())); //Convert.ToDecimal(row.Cells[CAMPO_DIEZPORCIENTO].Value.ToString());
                totalIVA10 += iva10;
                totalIVA5 += iva5;
                totalExentas += exentas;
                //row.Cells[CAMPO_DIEZPORCIENTO].Value = (Convert.ToDecimal(row.Cells[CAMPO_CANTIDAD].Value.ToString()) * Convert.ToDecimal(row.Cells[CAMPO_PRECIOUNITARIO].Value.ToString()));
                
                liqIVA10 += this.tSBMoneda.DisplayMember == GUARANIES ? decimal.Round(iva10 / 11, 0) : decimal.Round(iva10 / 11, 2);
                liqIVA5 += this.tSBMoneda.DisplayMember == GUARANIES ? decimal.Round(iva5 / 21, 0) : decimal.Round(iva5 / 21, 2);

                row.Cells[CAMPO_PRECIOUNITARIO].Value = Convert.ToDecimal((iva5 + iva10 + exentas) / (decimal)row.Cells[CAMPO_CANTIDAD].Value);
            }
            
            if (this.tSBMoneda.DisplayMember == GUARANIES)
            {
                totalIVA = decimal.Round(totalIVA5) + decimal.Round(totalIVA10);
                totalExentas = decimal.Round(totalExentas);
                totalGral = totalExentas + totalIVA;

                //liqIVA5 = decimal.Round(totalIVA5 / 21);
                //liqIVA10 = decimal.Round(totalIVA10 / 11);
                totalLiqIVA = liqIVA5 + liqIVA10;

                this.txtTotalExentas.Text = String.Format(FORMATO_MONEDA_GUARANIES, totalExentas);

                this.txtTotalIVA5.Text = String.Format(FORMATO_MONEDA_GUARANIES, totalIVA5);
                this.txtTotalIVA10.Text = String.Format(FORMATO_MONEDA_GUARANIES, totalIVA10);
                this.txtTotalIVA.Text = String.Format(FORMATO_MONEDA_GUARANIES, totalIVA);

                this.txtLiqIVA5.Text = String.Format(FORMATO_MONEDA_GUARANIES, liqIVA5);
                this.txtLiqIVA10.Text = String.Format(FORMATO_MONEDA_GUARANIES, liqIVA10);
                this.txtLiqTotalIVA.Text = String.Format(FORMATO_MONEDA_GUARANIES, totalLiqIVA);

                this.txtMontoTotal.Text = String.Format(FORMATO_MONEDA_GUARANIES, totalGral);
            }
            else
            {
                totalIVA = totalIVA5 + totalIVA10;
                totalGral = totalExentas + totalIVA;

                //liqIVA5 = totalIVA5 / 21;
                //liqIVA10 = totalIVA10 / 11;
                totalLiqIVA = liqIVA5 + liqIVA10;

                this.txtTotalExentas.Text = String.Format(FORMATO_MONEDA_OTROS, totalExentas);

                this.txtTotalIVA5.Text = String.Format(FORMATO_MONEDA_OTROS, totalIVA5);
                this.txtTotalIVA10.Text = String.Format(FORMATO_MONEDA_OTROS, totalIVA10);
                this.txtTotalIVA.Text = String.Format(FORMATO_MONEDA_OTROS, totalIVA);

                this.txtLiqIVA5.Text = String.Format(FORMATO_MONEDA_OTROS, liqIVA5);
                this.txtLiqIVA10.Text = String.Format(FORMATO_MONEDA_OTROS, liqIVA10);
                this.txtLiqTotalIVA.Text = String.Format(FORMATO_MONEDA_OTROS, totalLiqIVA);

                this.txtMontoTotal.Text = String.Format(FORMATO_MONEDA_OTROS, totalGral);
            }
        }
                
        private string EvaluarCero(string valor)
        {
            return ((valor == CERO_CON_DECIMALES) || (valor == CERO_SIN_DECIMALES)) ? string.Empty : valor;
        }


        private TEntidadCab ObtenerNroNotaCredito<TEntidadCab>(BerkeDBEntities context, TEntidadCab cab, string nroFacturaFieldName, string timbradoIDFieldName, string docAsocFieldName)
            where TEntidadCab : class
        {
            int timbradoID = Convert.ToInt32(context.Entry(cab).Property(timbradoIDFieldName).CurrentValue);

            ti_timbrado ti = context.ti_timbrado.First(a => a.ti_timbradoid == timbradoID);
            nf_numeracionfactura nf = context.nf_numeracionfactura.First(a => a.nf_timbradoid == timbradoID);

            long nroFactura = nf.nf_ultnrofactura + 1;
            string nroFacturaConFormato = String.Format(FORMATO_NOTACREDITO, ti.ti_serie.PadLeft(3, PAD), ti.ti_sucursal.PadLeft(3, PAD), nroFactura.ToString().PadLeft(7, PAD));

            if (!this.Between(nroFactura, ti.ti_numerodesde, ti.ti_numerohasta, true))
            {
                throw new Exception("Error en el rango de numeración.", 
                                    new Exception("El número de factura generado: " + nroFacturaConFormato + 
                                                  " no corresponde al rango [" + ti.ti_numerodesde.ToString() + "-" + ti.ti_numerohasta.ToString() + " ]" +Environment.NewLine +
                                                  "definido en el timbrado con ID " + timbradoID.ToString() + "."));
            }

            //La fecha de la factura {0}no se encuentra dentro del rango de fechas válidas para el timbrado {1} actualmente en uso.


            nf.nf_ultnrofactura = nroFactura;
            context.Entry(cab).Property(nroFacturaFieldName).CurrentValue = nroFacturaConFormato;

            //if ((int)this.cbSerie.SelectedValue == 2) //Solución temporal para Serie 2
            if ((this.cbSerie.GetItemText(this.cbSerie.SelectedItem) == SERIE_2) && (context.Entry(cab).Property(docAsocFieldName).CurrentValue == null || context.Entry(cab).Property(docAsocFieldName).CurrentValue.ToString().Trim() == string.Empty))
                context.Entry(cab).Property(CAMPO_NOTACREDITOCABECERA_DOCUMENTOSASOC).CurrentValue = nroFacturaConFormato;

            context.SaveChanges();

            return cab;
        }

        public bool Between(long num, long lower, long upper, bool inclusive = false)
        {
            return inclusive
                ? lower <= num && num <= upper
                : lower < num && num < upper;
        }

        //Implementación Local debido a que se debe obtener número de factura dentro de la transacción
        public TEntidadCab GuardarRegistroLocal<TEntidadCab, TEntidadDet>(TEntidadCab cab, List<TEntidadDet> listDet, string pkName, string fkName)
            where TEntidadCab : class
            where TEntidadDet : class
        {
            TEntidadCab Result = null;

            using (var r = new Repositorio<TEntidadCab>())
            {
                using (var dbContextTransaction = r.Context.Database.BeginTransaction())
                {
                    try
                    {
                        if (this.FormEditStatus == INSERT)
                        {
                            //Obtener número de factura
                            cab = this.ObtenerNroNotaCredito(r.Context, cab, CAMPO_NOTACREDITOCABECERA_NRONOTACREDITO, CAMPO_NOTACREDITOCABECERA_TIMBRADOID, CAMPO_NOTACREDITOCABECERA_DOCUMENTOSASOC);
                            Result = r.Insertar(cab);
                            r.Insertar<TEntidadDet>(Result, listDet, pkName, fkName);
                        }
                        else if (this.FormEditStatus == EDIT)
                        {
                            Result = r.Actualizar(cab);
                            //Falta implementación en Repositorio para casos de actualización
                            r.Actualizar<TEntidadDet>(Result, listDet);
                        }

                        dbContextTransaction.Commit();
                        //dbContextTransaction.Rollback();
                    }
                    catch (DbEntityValidationException e)
                    {
                        Result = null;
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
                        Result = null;
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

            return Result;
        }

        private void dgvDetFactura_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (this.FormEditStatus != BROWSE)
            {
                this.CalcularTotal();
                this.FormatearGrillaDetalle();
            }
        }

        private void tbbImprimir_Click_1(object sender, EventArgs e)
        {
            if (this.txtCDC.Text == string.Empty)
                this.ImprimirFacturaDigital();
            else this.showKude();
        }

        private void tbbXML_Click(object sender, EventArgs e)
        {
            this.XMLDownload();
        }

        private void XMLDownload()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //string xmlUrl = "https://ekuatia.set.gov.py/docs/documento-electronico-xml/" + this.txtCDC.Text;
                    string xmlUrl = "https://facte.siga.com.py/FacturaE/rest/descargaXML?ruc=80016875-5&codigo=" + this.txtCDC.Text;
                    System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                    HttpResponseMessage response = client.GetAsync(xmlUrl).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string targetFileName = "NCE-" + this.txtNroNotaCredito.Text + ".xml";
                        DownloadGateway dw = new DownloadGateway(response.Content.ReadAsStreamAsync().Result, targetFileName);
                        dw.StartDownload(this);
                    }
                    else
                    {
                        throw new Exception(response.StatusCode + Environment.NewLine + response.ReasonPhrase);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + Environment.NewLine + ex.Message, "Información de Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void tbbNuevo_Click_1(object sender, EventArgs e)
        {
            this.tabListaABM.SelectedIndex = 1;
            this.FormEditStatus = INSERT;

            if (this.cargarCBSerieNotaCredito() == 0)
            {
                MessageBox.Show("No cuenta con ningún timbrado habilitado para la generación de facturas." + Environment.NewLine +
                                "No se puede continuar.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                this.tbbCancelar_Click(sender, e);
                return;
            }

            this.limpiarDatos();
            this.dtpFechaFactura.Value = System.DateTime.Now;
            this.txtFechaNotaCredito.Text = System.DateTime.Now.ToShortDateString();
            this.txtEstado.Text = ESTADO_ACTIVOVALOR;
            this.rbCredito.Checked = this.cbSerie.GetItemText(this.cbSerie.SelectedItem) == SERIE_2;
            this.chkDE.Checked = true;
            this.cargarCBMotivoEmision();
            this.cbSerie.Focus();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (this.txtCDC.Text == string.Empty)
                this.ImprimirFactura();
            else this.showKude();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string descripcion = pc.pc_descripcion;
            //Regex rex = new Regex(row.fd_descripcion.TrimStart('\r', '\n').TrimEnd('\r', '\n'), RegexOptions.IgnoreCase);
            //                        descripcion = rex.Replace(descripcion, string.Empty, 1);
        }

        private void showKude()
        {
            string pdfUrl = "https://facte.siga.com.py/FacturaE/printDE?ruc=80016875-5&cdc=" + this.txtCDC.Text;
            LinkParameters linkParameters = new LinkParameters();
            linkParameters.Target = "_blank";
            Link.Open(pdfUrl, linkParameters);
        }

        private decimal GetDPropIVA(decimal a, decimal b, int c)
        {
            //return decimal.Round(10000 * a / (b - 10 * a), 2);
            return decimal.Round(10000 * a / ((100 * b) - (a * c)), 2);
        }

        private string GenerateJSON(int NotaCreditoCabId)
        {
            string json = string.Empty;
            using (BerkeDBEntities context = new BerkeDBEntities())
            {
                nc_notacreditocabecera nc = context.nc_notacreditocabecera.FirstOrDefault(a => a.nc_notacreditocabeceraid == NotaCreditoCabId);
                List<nd_notacreditodetalle> listDet = context.nd_notacreditodetalle.Where(a => a.nd_notacreditocabeceraid == NotaCreditoCabId).ToList();

                int monedaID = Convert.ToInt32(this.tSBMoneda.KeyMember);
                Moneda moneda = context.Moneda.FirstOrDefault(a => a.ID == monedaID);

                int timbradoID = nc.nc_timbradoid.Value;
                ti_timbrado ti = context.ti_timbrado.FirstOrDefault(a => a.ti_timbradoid == timbradoID);

                DateTime dFeEmiDEDate = Convert.ToDateTime(this.txtFechaNotaCredito.Text + " " + DateTime.Now.ToShortTimeString());
                int clienteID = nc.nc_clienteid.Value; //Convert.ToInt32(this.tSBCliente.KeyMember);
                
                var cli_pais = (from c in context.Cliente
                                join p in context.CPais
                                   on c.PaisID equals p.idpais
                                select new
                                {
                                    ClienteID = c.ID,
                                    RUC = c.RUC,
                                    PaisAlfa3 = p.paisalfa3,
                                    PaisAlfa = p.paisalfa,
                                    PaisDescripFE = p.descripFE,
                                    TipoPersona = c.Personeria,
                                    RazonSocial = c.Nombre
                                })
                              .Where(a => a.ClienteID == clienteID)
                              .ToList();

                string path = string.Empty;
                //string pathDet = string.Empty;

                if ((cli_pais.FirstOrDefault().PaisAlfa3 == CODIGO_ALFA3_PARAGUAY) && (this.txtRUC.Text != string.Empty))
                {
                    path = VWGContext.Current.Server.MapPath(@"~\Resources\Src\fe-contribuyente.json");
                    //pathDet = VWGContext.Current.Server.MapPath(@"~\Resources\Src\detalleFactura.json");
                }
                else
                {
                    path = VWGContext.Current.Server.MapPath(@"~\Resources\Src\fe-no-contribuyente.json");

                    path = VWGContext.Current.Server.MapPath(@"~\Resources\Src\fe-no-contribuyente.json");

                    if (this.txtRUC.Text == String.Empty)
                    {
                        this.txtRUC.Text = (cli_pais.FirstOrDefault().PaisAlfa != String.Empty ? cli_pais.FirstOrDefault().PaisAlfa : "SP")
                                            + cli_pais.FirstOrDefault().ClienteID.ToString();

                        nc.nc_ruc = this.txtRUC.Text;
                        context.SaveChanges();
                    }
                    //pathDet = VWGContext.Current.Server.MapPath(@"~\Resources\Src\detalleFactura.json");
                }
                string pathDet = VWGContext.Current.Server.MapPath(@"~\Resources\Src\detalleFactura.json");

                StreamReader reader = new StreamReader(path);
                json = reader.ReadToEnd();

                StreamReader readerDet = new StreamReader(pathDet);
                string jsonDet = readerDet.ReadToEnd();

                if (this.chkFacturaDE.Checked)
                {
                    string pathDatosFacturaNCDE = VWGContext.Current.Server.MapPath(@"~\Resources\Src\datosFacturaNCDE.json");
                    StreamReader readerDatosFacturaNCDE = new StreamReader(pathDatosFacturaNCDE);
                    string jsonDatosFacturaNCDE = readerDatosFacturaNCDE.ReadToEnd();
                    jsonDatosFacturaNCDE = jsonDatosFacturaNCDE.Replace("#dCdCDERef#", this.txtCDCFactura.Text);
                    json = json.Replace("#datosFacturaNC#", jsonDatosFacturaNCDE);
                }
                else
                {
                    string pathDatosFacturaNCImpreso = VWGContext.Current.Server.MapPath(@"~\Resources\Src\datosFacturaNCImpreso.json");
                    StreamReader readerDatosFacturaNCImpreso = new StreamReader(pathDatosFacturaNCImpreso);
                    string jsonDatosFacturaNCImpreso = readerDatosFacturaNCImpreso.ReadToEnd();
                    jsonDatosFacturaNCImpreso = jsonDatosFacturaNCImpreso.Replace("#dNTimDI#", this.txtNroTimbradoFactura.Text);

                    string[] datosFactura = this.txtNroFactura.Text.Split('-');
                    jsonDatosFacturaNCImpreso = jsonDatosFacturaNCImpreso.Replace("#dEstDocAso#", datosFactura[0]);
                    jsonDatosFacturaNCImpreso = jsonDatosFacturaNCImpreso.Replace("#dPExpDocAso#", datosFactura[1]);
                    jsonDatosFacturaNCImpreso = jsonDatosFacturaNCImpreso.Replace("#dNumDocAso#", datosFactura[2]);
                    jsonDatosFacturaNCImpreso = jsonDatosFacturaNCImpreso.Replace("#dFecEmiDI#", this.txtFechaFactura.Text);
                    json = json.Replace("#datosFacturaNC#", jsonDatosFacturaNCImpreso);
                }

                //#iTiDE#
                json = json.Replace("#iTiDE#", NOTACREDITO_ELECTRONICA);
                //#dDesTiDE#
                json = json.Replace("#dDesTiDE#", NOTACREDITO_ELECTRONICA_DESCRIP);
                //#dNumTim#
                json = json.Replace("#dNumTim#", ti.ti_nrotimbrado.ToString());
                //#dFeIniT#
                json = json.Replace("#dFeIniT#", ti.ti_vigenciadesde.ToString("yyyy-MM-dd"));

                if (nc.nc_nronotacredito == string.Empty)
                    throw new Exception("Ingrese un número de factura válido");

                string[] dNroNC = nc.nc_nronotacredito.Split('-');

                string dNumDoc = dNroNC[2];
                decimal dTiCam = this.tSBMoneda.DisplayMember != GUARANIES ? Convert.ToDecimal(this.txtTipoCambio.Text) : 1;
                //#Id#
                string dCodSeg = this.GetCodSeg();
                string dPunExp = dNroNC[1];//this.cbSerie.GetItemText(this.cbSerie.SelectedItem) == SERIE_2 ? "002" : "001";
                string dFeEmiDE = dFeEmiDEDate.ToString("yyyy-MM-ddTHH:mm:ss"); //Convert.ToDateTime(this.txtFechaFactura.Text + " " + DateTime.Now.ToShortTimeString()).ToString("yyyy-MM-ddTHH:mm:ss");
                string Id = this.GenerateCDC(NOTACREDITO_ELECTRONICA, RUC_BERKEMEYER, DV_BERKEMEYER.ToString(), ESTABLECIMIENTO,
                                            dPunExp, dNumDoc, TIPO_CONTRIBUYENTE, dFeEmiDEDate, TIPO_EMISOR, dCodSeg);
                this.txtModule11.Text = Id;
                this.txtCDC.Text = Id;
                json = json.Replace("#Id#", Id);
                //#dDVId#
                json = json.Replace("#dDVId#", Id.Substring(43, 1));
                //#dCodSeg#
                json = json.Replace("#dCodSeg#", dCodSeg);
                //#dNumDoc#
                json = json.Replace("#dNumDoc#", dNumDoc);
                //#dPunExp#
                json = json.Replace("#dPunExp#", dPunExp);
                //#dFeEmiDE# 2023-03-24T12:03:59
                //json = json.Replace("#dFeEmiDE#", Convert.ToDateTime(this.txtFechaFactura.Text + " " + DateTime.Now.ToShortTimeString()).ToString("yyyy-MM-ddTHH:mm:ss"));
                json = json.Replace("#dFeEmiDE#", dFeEmiDE);
                //#dFecEmNR#
                //json = json.Replace("#dFecEmNR#", DateTime.Now.ToString("yyyy-MM-dd"));
                //json = json.Replace("#dFecEmNR#", "");
                //#dNomRec#
                json = json.Replace("#dNomRec#", cli_pais.FirstOrDefault().RazonSocial);
                //#dDirRec#
                //json = json.Replace("#dDirRec#", this.txtDireccion.Text);
                json = json.Replace("#dDirRec#", this.txtDireccion.Text.Replace("\"", "\\\""));
                //#cMoneOpe#
                json = json.Replace("#cMoneOpe#", moneda.MonedaFE);
                //#cMoneTiPag#
                json = json.Replace("#cMoneTiPag#", moneda.MonedaFE);
                //#cMoneCuo#
                //json = json.Replace("#cMoneCuo#", moneda.MonedaFE);
                //#dDesMoneOpe#
                json = json.Replace("#dDesMoneOpe#", moneda.MonedaDescripFE);
                //#dDMoneTiPag#
                json = json.Replace("#dDMoneTiPag#", moneda.MonedaDescripFE);
                //#dDMoneCuo#
                //json = json.Replace("#dDMoneCuo#", moneda.MonedaDescripFE);
                //#dVencCuo#
                //json = json.Replace("#dVencCuo#", dFeEmiDEDate.ToString("yyyy-MM-dd"));

                if (this.tSBMoneda.DisplayMember == GUARANIES)
                {
                    //#dCondTiCam#
                    json = json.Replace("#dCondTiCam#", "");
                    //#dTiCam#
                    json = json.Replace("#dTiCam#", "");
                    //#dTiCamTiPag#
                    json = json.Replace("#dTiCamTiPag#", "");
                }
                else
                {
                    //#dCondTiCam#
                    json = json.Replace("#dCondTiCam#", "1"); //Un solo tipo de cambio para toda la factura
                    //#dTiCam#
                    json = json.Replace("#dTiCam#", dTiCam.ToString().Replace(",", "."));
                    //#dTiCamTiPag#
                    json = json.Replace("#dTiCamTiPag#", dTiCam.ToString().Replace(",", "."));
                }


                //#cPaisRec#
                json = json.Replace("#cPaisRec#", cli_pais.FirstOrDefault().PaisAlfa3);
                //#dDesPaisRe#
                json = json.Replace("#dDesPaisRe#", cli_pais.FirstOrDefault().PaisDescripFE);

                if (cli_pais.FirstOrDefault().PaisAlfa3 == CODIGO_ALFA3_PARAGUAY)
                {
                    //#iTiContRec#
                    json = json.Replace("#iTiContRec#", cli_pais.FirstOrDefault().TipoPersona == PERSONA_JURIDICA ? "2" : "1");
                    //#dRucRec#
                    string[] datosRUC = this.txtRUC.Text.Split('-');
                    if (datosRUC.Length < 2)
                        throw new Exception("RUC inválido");

                    json = json.Replace("#dRucRec#", datosRUC[0]);
                    //#dDVRec#
                    json = json.Replace("#dDVRec#", datosRUC[1]);
                }
                else
                {
                    //#dNumIDRec#
                    //json = json.Replace("#dNumIDRec#", this.txtRUC.Text != string.Empty ? this.txtRUC.Text : "0");
                    json = json.Replace("#dNumIDRec#", this.txtRUC.Text);
                    //#dCodCliente#
                    json = json.Replace("#dCodCliente#", this.txtRUC.Text);
                }

                //#iTiPago#
                json = json.Replace("#iTiPago#", EFECTIVO_CODIGO);
                //#dDesTiPag#
                json = json.Replace("#dDesTiPag#", EFECTIVO_DESCRIPCION);
                //#iCondOpe#
                //json = json.Replace("#iCondOpe#", this.rbContado.Checked ? "1" : "2");
                json = json.Replace("#iCondOpe#", "2");
                //#dDCondOpe#
                //json = json.Replace("#dDCondOpe#", this.rbContado.Checked ? CONTADO : CREDITO);
                json = json.Replace("#dDCondOpe#", CREDITO);

                //#iMotEmi#
                json = json.Replace("#iMotEmi#", ((CBMotivoEmisionNC)this.cbMotivoEmision.SelectedItem).MotivoEmisionSIFENID.ToString()); 
                //#dDesMotEmi#
                json = json.Replace("#dDesMotEmi#", ((CBMotivoEmisionNC)this.cbMotivoEmision.SelectedItem).MotivoEmisionSIFENDescrip);

                //Detalles de factura
                string jsonDetTemplate = jsonDet;
                int item = 1;
                decimal gTotalDet = 0;
                decimal gDBasGravIVA10 = 0;
                decimal gDLiqIVA10Item = 0;
                decimal gDBasGravIVA5 = 0;
                decimal gDLiqIVA5Item = 0;
                decimal gDBasExe = 0;
                foreach (nd_notacreditodetalle nd in listDet)
                {
                    jsonDet += item > 1 ? "," + jsonDetTemplate : string.Empty;
                    //#dCodInt#
                    jsonDet = jsonDet.Replace("#dCodInt#", item.ToString().PadLeft(6, '0'));
                    //#dDesProSer#
                    //string descrip = fd.fd_descripFE;//"Servicio gravado N° " + item.ToString();
                    //jsonDet = jsonDet.Replace("#dDesProSer#", descrip);
                    Tuple<string, string> descrip = this.DividirTexto(nd.nd_descripcion);
                    //#dDesProSer#
                    jsonDet = jsonDet.Replace("#dDesProSer#", descrip.Item1);
                    //#dInfItem#
                    jsonDet = jsonDet.Replace("#dInfItem#", descrip.Item2);
                    //#dCantProSer#
                    jsonDet = jsonDet.Replace("#dCantProSer#", nd.nd_cantidad.ToString().Replace(",", "."));
                    //#dPUniProSer#
                    jsonDet = jsonDet.Replace("#dPUniProSer#", nd.nd_preciounitario.ToString().Replace(",", "."));
                    //#dTotBruOpeItem#
                    //decimal totalDet = decimal.Round(nd.nd_preciounitario * nd.nd_cantidad);
                    decimal totalDet = this.tSBMoneda.DisplayMember == GUARANIES ? decimal.Round(nd.nd_preciounitario * nd.nd_cantidad) : decimal.Round(nd.nd_preciounitario * nd.nd_cantidad, 2);
                    gTotalDet += totalDet;
                    jsonDet = jsonDet.Replace("#dTotBruOpeItem#", totalDet.ToString().Replace(",", "."));
                    //#dTotOpeItem#
                    jsonDet = jsonDet.Replace("#dTotOpeItem#", totalDet.ToString().Replace(",", "."));
                    /*gCamIVA*/
                    if (nd.nd_exentas > 0)
                    {
                        if (nd.nd_diezporciento > 0)
                        {
                            //#iAfecIVA#
                            jsonDet = jsonDet.Replace("#iAfecIVA#", GRAVADO_PARCIAL_ID);
                            //#dDesAfecIVA#
                            jsonDet = jsonDet.Replace("#dDesAfecIVA#", GRAVADO_PARCIAL_DESCRIP);
                            //#dPropIVA#
                            decimal a = (nd.nd_diezporciento - (nd.nd_diezporciento / 11)) * nd.nd_cantidad;
                            //a = this.tSBMoneda.DisplayMember == GUARANIES ? decimal.Round(a) : decimal.Round(a, 2);
                            decimal b = nd.nd_preciounitario * nd.nd_cantidad;
                            int c = 10;
                            decimal dPropIVA = decimal.Round(this.GetDPropIVA(a, b, c), 8);
                            jsonDet = jsonDet.Replace("#dPropIVA#", dPropIVA.ToString().Replace(",", "."));
                            //#dTasaIVA#
                            jsonDet = jsonDet.Replace("#dTasaIVA#", c.ToString());
                            //#dBasGravIVA#
                            decimal dBasGravIVA = this.tSBMoneda.DisplayMember == GUARANIES ? decimal.Round(a) : decimal.Round(a, 2);
                            gDBasGravIVA10 += dBasGravIVA;
                            jsonDet = jsonDet.Replace("#dBasGravIVA#", dBasGravIVA.ToString().Replace(",", "."));
                            //#dLiqIVAItem#
                            decimal dLiqIVAItem = this.tSBMoneda.DisplayMember == GUARANIES ? decimal.Round(((nd.nd_diezporciento * nd.nd_cantidad) - a)) : decimal.Round(((nd.nd_diezporciento * nd.nd_cantidad) - a), 2);
                            gDLiqIVA10Item += dLiqIVAItem;
                            jsonDet = jsonDet.Replace("#dLiqIVAItem#", dLiqIVAItem.ToString().Replace(",", "."));
                            //#dBasExe#
                            decimal dBasExe = nd.nd_cantidad * nd.nd_exentas;
                            gDBasExe += dBasExe;
                            jsonDet = jsonDet.Replace("#dBasExe#", dBasExe.ToString().Replace(",", "."));
                        }
                        else
                        {
                            //#iAfecIVA#
                            jsonDet = jsonDet.Replace("#iAfecIVA#", GRAVADO_PARCIAL_ID);
                            //#dDesAfecIVA#
                            jsonDet = jsonDet.Replace("#dDesAfecIVA#", GRAVADO_PARCIAL_DESCRIP);
                            //#dPropIVA#
                            decimal a = (nd.nd_cincoporciento - (nd.nd_cincoporciento / 21)) * nd.nd_cantidad;
                            //a = this.tSBMoneda.DisplayMember == GUARANIES ? decimal.Round(a) : decimal.Round(a, 2);
                            decimal b = nd.nd_preciounitario * nd.nd_cantidad;
                            int c = 5;
                            decimal dPropIVA = decimal.Round(this.GetDPropIVA(a, b, c), 8);
                            jsonDet = jsonDet.Replace("#dPropIVA#", dPropIVA.ToString().Replace(",", "."));
                            //#dTasaIVA#
                            jsonDet = jsonDet.Replace("#dTasaIVA#", c.ToString());
                            //#dBasGravIVA#
                            decimal dBasGravIVA = this.tSBMoneda.DisplayMember == GUARANIES ? decimal.Round(a) : decimal.Round(a, 2);//a;
                            gDBasGravIVA5 += dBasGravIVA;
                            jsonDet = jsonDet.Replace("#dBasGravIVA#", dBasGravIVA.ToString().Replace(",", "."));
                            //#dLiqIVAItem#
                            decimal dLiqIVAItem = this.tSBMoneda.DisplayMember == GUARANIES ? decimal.Round(((nd.nd_cincoporciento * nd.nd_cantidad) - a)) : decimal.Round(((nd.nd_cincoporciento * nd.nd_cantidad) - a), 2);
                            gDLiqIVA5Item += dLiqIVAItem;
                            jsonDet = jsonDet.Replace("#dLiqIVAItem#", dLiqIVAItem.ToString().Replace(",", "."));
                            //#dBasExe#
                            decimal dBasExe = nd.nd_cantidad * nd.nd_exentas;
                            gDBasExe += dBasExe;
                            jsonDet = jsonDet.Replace("#dBasExe#", dBasExe.ToString().Replace(",", "."));
                        }
                    }
                    else
                    {
                        if (nd.nd_diezporciento > 0)
                        {
                            //#iAfecIVA#
                            jsonDet = jsonDet.Replace("#iAfecIVA#", GRAVADO_IVA_ID);
                            //#dDesAfecIVA#
                            jsonDet = jsonDet.Replace("#dDesAfecIVA#", GRAVADO_IVA_DESCRIP);
                            //#dPropIVA#
                            jsonDet = jsonDet.Replace("#dPropIVA#", PROP_IVA);
                            //#dTasaIVA#
                            jsonDet = jsonDet.Replace("#dTasaIVA#", TASA_IVA_10);
                            //#dBasGravIVA#
                            decimal a = (nd.nd_diezporciento - (nd.nd_diezporciento / 11)) * nd.nd_cantidad;
                            decimal dBasGravIVA = this.tSBMoneda.DisplayMember == GUARANIES ? decimal.Round(a) : decimal.Round(a, 2);
                            gDBasGravIVA10 += dBasGravIVA;
                            jsonDet = jsonDet.Replace("#dBasGravIVA#", dBasGravIVA.ToString().Replace(",", "."));
                            //#dLiqIVAItem#
                            decimal dLiqIVAItem = this.tSBMoneda.DisplayMember == GUARANIES ? decimal.Round(((nd.nd_diezporciento * nd.nd_cantidad) - a)) : decimal.Round(((nd.nd_diezporciento * nd.nd_cantidad) - a), 2);
                            gDLiqIVA10Item += dLiqIVAItem;
                            jsonDet = jsonDet.Replace("#dLiqIVAItem#", dLiqIVAItem.ToString().Replace(",", "."));
                            //#dBasExe#
                            jsonDet = jsonDet.Replace("#dBasExe#", BASE_EXE);
                        }
                        else
                        {
                            //#iAfecIVA#
                            jsonDet = jsonDet.Replace("#iAfecIVA#", GRAVADO_IVA_ID);
                            //#dDesAfecIVA#
                            jsonDet = jsonDet.Replace("#dDesAfecIVA#", GRAVADO_IVA_DESCRIP);
                            //#dPropIVA#
                            jsonDet = jsonDet.Replace("#dPropIVA#", PROP_IVA);
                            //#dTasaIVA#
                            jsonDet = jsonDet.Replace("#dTasaIVA#", TASA_IVA_5);
                            //#dBasGravIVA#
                            decimal a = (nd.nd_cincoporciento - (nd.nd_cincoporciento / 21)) * nd.nd_cantidad;
                            decimal dBasGravIVA = this.tSBMoneda.DisplayMember == GUARANIES ? decimal.Round(a) : decimal.Round(a, 2);
                            gDBasGravIVA5 += dBasGravIVA;
                            jsonDet = jsonDet.Replace("#dBasGravIVA#", dBasGravIVA.ToString().Replace(",", "."));
                            //#dLiqIVAItem#
                            decimal dLiqIVAItem = this.tSBMoneda.DisplayMember == GUARANIES ? decimal.Round(((nd.nd_cincoporciento * nd.nd_cantidad) - a)) : decimal.Round(((nd.nd_cincoporciento * nd.nd_cantidad) - a), 2);
                            gDLiqIVA5Item += dLiqIVAItem;
                            jsonDet = jsonDet.Replace("#dLiqIVAItem#", dLiqIVAItem.ToString().Replace(",", "."));
                            //#dBasExe#
                            jsonDet = jsonDet.Replace("#dBasExe#", BASE_EXE);
                        }

                    }
                    item++;
                }
                json = json.Replace("#detalleFactura#", jsonDet);
                //#dSub5#
                json = json.Replace("#dSubExe#", gDBasExe.ToString().Replace(",", "."));
                //#dSub10#
                //json = json.Replace("#dSub10#", gTotalDet.ToString().Replace(",", "."));
                decimal dSub10 = gDBasGravIVA10 + gDLiqIVA10Item;
                json = json.Replace("#dSub10#", dSub10.ToString().Replace(",", "."));
                //#dSub5#
                decimal dSub5 = gDBasGravIVA5 + gDLiqIVA5Item;
                json = json.Replace("#dSub5#", dSub5.ToString().Replace(",", "."));
                //#dTotOpe#
                json = json.Replace("#dTotOpe#", gTotalDet.ToString().Replace(",", "."));
                //#dTotGralOpe#
                json = json.Replace("#dTotGralOpe#", gTotalDet.ToString().Replace(",", "."));
                //#dIVA5#
                json = json.Replace("#dIVA5#", gDLiqIVA5Item.ToString().Replace(",", "."));
                //#dIVA10#
                json = json.Replace("#dIVA10#", gDLiqIVA10Item.ToString().Replace(",", "."));
                //#dTotIVA#
                decimal dTotalIVA = gDLiqIVA10Item + gDLiqIVA5Item;
                json = json.Replace("#dTotIVA#", dTotalIVA.ToString().Replace(",", "."));
                //#dBaseGrav5#
                json = json.Replace("#dBaseGrav5#", gDBasGravIVA5.ToString().Replace(",", "."));
                //#dBaseGrav10#
                json = json.Replace("#dBaseGrav10#", gDBasGravIVA10.ToString().Replace(",", "."));
                //#dTBasGraIVA#
                decimal dTBasGraIVA = gDBasGravIVA10 + gDBasGravIVA5;
                json = json.Replace("#dTBasGraIVA#", dTBasGraIVA.ToString().Replace(",", "."));

                #region Old
                //    if (nd.nd_exentas > 0)
                //    {
                //        if (nd.nd_diezporciento > 0)
                //        {
                //            //#iAfecIVA#
                //            jsonDet = jsonDet.Replace("#iAfecIVA#", GRAVADO_PARCIAL_ID);
                //            //#dDesAfecIVA#
                //            jsonDet = jsonDet.Replace("#dDesAfecIVA#", GRAVADO_PARCIAL_DESCRIP);
                //            //#dPropIVA#
                //            decimal a = nd.nd_diezporciento - (nd.nd_diezporciento / 11);
                //            a = this.tSBMoneda.DisplayMember == GUARANIES ? decimal.Round(a) : decimal.Round(a, 2);
                //            decimal b = nd.nd_preciounitario;
                //            int c = 10;
                //            decimal dPropIVA = this.GetDPropIVA(a, b, c);
                //            jsonDet = jsonDet.Replace("#dPropIVA#", dPropIVA.ToString().Replace(",", "."));
                //            //#dTasaIVA#
                //            jsonDet = jsonDet.Replace("#dTasaIVA#", c.ToString());
                //            //#dBasGravIVA#
                //            decimal dBasGravIVA = a * nd.nd_cantidad;
                //            gDBasGravIVA10 += dBasGravIVA;
                //            jsonDet = jsonDet.Replace("#dBasGravIVA#", dBasGravIVA.ToString().Replace(",", "."));
                //            //#dLiqIVAItem#
                //            decimal dLiqIVAItem = this.tSBMoneda.DisplayMember == GUARANIES ? decimal.Round((nd.nd_diezporciento - a) * nd.nd_cantidad) : decimal.Round((nd.nd_diezporciento - a) * nd.nd_cantidad, 2);
                //            gDLiqIVA10Item += dLiqIVAItem;
                //            jsonDet = jsonDet.Replace("#dLiqIVAItem#", dLiqIVAItem.ToString().Replace(",", "."));
                //            //#dBasExe#
                //            decimal dBasExe = nd.nd_cantidad * nd.nd_exentas;
                //            gDBasExe += dBasExe;
                //            jsonDet = jsonDet.Replace("#dBasExe#", dBasExe.ToString().Replace(",", "."));
                //        }
                //        else
                //        {
                //        }
                //    }
                //    else
                //    {
                //        if (nd.nd_diezporciento > 0)
                //        {
                //            //#iAfecIVA#
                //            jsonDet = jsonDet.Replace("#iAfecIVA#", GRAVADO_IVA_ID);
                //            //#dDesAfecIVA#
                //            jsonDet = jsonDet.Replace("#dDesAfecIVA#", GRAVADO_IVA_DESCRIP);
                //            //#dPropIVA#
                //            jsonDet = jsonDet.Replace("#dPropIVA#", PROP_IVA);
                //            //#dTasaIVA#
                //            jsonDet = jsonDet.Replace("#dTasaIVA#", TASA_IVA_10);
                //            //#dBasGravIVA#
                //            decimal dBasGravIVA = this.tSBMoneda.DisplayMember == GUARANIES ? decimal.Round(totalDet - (totalDet / 11)) : decimal.Round(totalDet - (totalDet / 11), 2);
                //            gDBasGravIVA10 += dBasGravIVA;
                //            jsonDet = jsonDet.Replace("#dBasGravIVA#", dBasGravIVA.ToString().Replace(",", "."));
                //            //#dLiqIVAItem#
                //            decimal dLiqIVAItem = this.tSBMoneda.DisplayMember == GUARANIES ? decimal.Round(totalDet - dBasGravIVA) : decimal.Round(totalDet - dBasGravIVA, 2);
                //            gDLiqIVA10Item += dLiqIVAItem;
                //            jsonDet = jsonDet.Replace("#dLiqIVAItem#", dLiqIVAItem.ToString().Replace(",", "."));
                //            //#dBasExe#
                //            jsonDet = jsonDet.Replace("#dBasExe#", BASE_EXE);
                //        }
                //        else
                //        {
                //        }
                        
                //    }
                //    item++;
                //}
                //json = json.Replace("#detalleFactura#", jsonDet);
                ////#dSub5#
                //json = json.Replace("#dSubExe#", gDBasExe.ToString().Replace(",", "."));
                ////#dSub10#
                ////json = json.Replace("#dSub10#", gTotalDet.ToString().Replace(",", "."));
                //decimal dSub10 = gDBasGravIVA10 + gDLiqIVA10Item;
                //json = json.Replace("#dSub10#", dSub10.ToString().Replace(",", "."));
                ////#dSub5#
                //decimal dSub5 = gDBasGravIVA5 + gDLiqIVA5Item;
                //json = json.Replace("#dSub5#", dSub5.ToString().Replace(",", "."));
                ////#dTotOpe#
                //json = json.Replace("#dTotOpe#", gTotalDet.ToString().Replace(",", "."));
                ////#dTotGralOpe#
                //json = json.Replace("#dTotGralOpe#", gTotalDet.ToString().Replace(",", "."));
                ////#dIVA10#
                //json = json.Replace("#dIVA10#", gDLiqIVA10Item.ToString().Replace(",", "."));
                ////#dTotIVA#
                //decimal dTotalIVA = gDLiqIVA10Item + gDLiqIVA5Item;
                //json = json.Replace("#dTotIVA#", dTotalIVA.ToString().Replace(",", "."));
                ////#dBaseGrav10#
                //json = json.Replace("#dBaseGrav10#", gDBasGravIVA10.ToString().Replace(",", "."));
                ////#dTBasGraIVA#
                //decimal dTBasGraIVA = gDBasGravIVA10 + gDBasGravIVA5;
                //json = json.Replace("#dTBasGraIVA#", dTBasGraIVA.ToString().Replace(",", "."));
                #endregion Old
                
                if (moneda.MonedaFE != CODIGO_GUARANIES_FE)
                {
                    //decimal dTotalGs = decimal.Round(gTotalDet * dTiCam, 2);
                    decimal dTotalGs = decimal.Round(gTotalDet * dTiCam, 0);
                    //#dTBasGraIVA#
                    json = json.Replace("#dTotalGs#", dTotalGs.ToString().Replace(",", "."));
                }
                else json = json.Replace("#dTotalGs#", gTotalDet.ToString().Replace(",", "."));
            }
            return json;
        }

        private decimal GetTipoCambio(int monedaid, DateTime fecha)
        {
            decimal result = -1;
            using (BerkeDBEntities context = new BerkeDBEntities())
            {
                tcd_tipocambiode tcd = context.tcd_tipocambiode.FirstOrDefault(a => a.tcd_monedaid == monedaid && a.tcd_fecha == fecha);
                if (tcd != null)
                {
                    result = decimal.Round(tcd.tcd_valor, 2);
                    //result = decimal.Round(tcd.tcd_valor);
                }
            }
            return result;
        }

        private SifenQueryResponse2 callStarsoftSiga(int NotaCreditoCabId)
        {
            SifenQueryResponse2 asyncResponse = new SifenQueryResponse2();
            var url = "https://facte.siga.com.py/FacturaE/rest/enviarLoteDE/json?ruc=80016875-5&tipoWs=Asincrono-Aprobado&token=" + TOKEN_JWT;

            string requestBody = this.GenerateJSON(NotaCreditoCabId);

            #region Guardar JSON en archivo
            if (this.IsDebugDEJSON)
            {
                string path = VWGContext.Current.Server.MapPath(@"\Resources\UserData\" + VWGContext.Current.Session["WindowsUser"].ToString() + @"\");
                Berke.Libs.Base.Helpers.Files.CreateDirectory(@path);
                string fileName = @path + this.txtCDC.Text + ".json";
                Berke.Libs.Base.Helpers.Files.SaveStringToFile(requestBody, fileName);
            }
            #endregion

            using (HttpClient client = new HttpClient())
            {
                StringContent httpContent = new StringContent(requestBody, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(url, httpContent).Result;

                #region XML
                //if (response.IsSuccessStatusCode)
                //{
                //    string responseContent = response.Content.ReadAsStringAsync().Result;
                //    XmlDocument xmldoc = new XmlDocument();

                //    try
                //    {
                //        xmldoc.LoadXml(responseContent);
                //    }
                //    catch (XmlException ex)
                //    {
                //        return responseContent;
                //    }

                //    var nsmgr = new XmlNamespaceManager(xmldoc.NameTable);
                //    nsmgr.AddNamespace("ns2", "http://ekuatia.set.gov.py/sifen/xsd");

                //    XmlNode dEstRes = xmldoc.SelectSingleNode("//ns2:dEstRes", nsmgr);
                //    string dEstResValue = dEstRes.InnerText;
                //    //result = "OK#" + dEstResValue;

                //    XmlNode dMsgRes = xmldoc.SelectSingleNode("//ns2:dMsgRes", nsmgr);
                //    string dMsgResValue = dMsgRes.InnerText;
                //    //result += "#" + dMsgRes.InnerText;

                //    if (dEstResValue == "Aprobado")
                //    {
                //        XmlNode cDC = xmldoc.SelectSingleNode("//ns2:Id", nsmgr);
                //        result += "OK#" + dEstResValue + "#" + dMsgResValue + "#" + cDC.InnerText;
                //    }
                //    else result = dEstResValue + " - " + dMsgResValue;
                //}
                //else
                //{
                //    result = response.StatusCode + Environment.NewLine + response.ReasonPhrase;
                //}
                #endregion XML

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    responseContent = responseContent.Replace("[", "").Replace("]", "");
                    //asyncResponse = JsonConvert.DeserializeObject<SifenAsyncResponse>(responseContent);
                    asyncResponse = JsonConvert.DeserializeObject<SifenQueryResponse2>(responseContent);
                }
                else
                {
                    throw new Exception(response.StatusCode + Environment.NewLine + response.ReasonPhrase);
                }

            }
            return asyncResponse;
        }

        private string NormalizarTexto(string texto)
        {
            //string textoEscapado = System.Security.SecurityElement.Escape(texto);
            string sep = this.cbSerie.GetItemText(this.cbSerie.SelectedItem) == SERIE_2 ? " - " : " ";
            string textoNormalizado = texto.Replace("\r\n", sep).Replace("\t", " ").Replace("\"", "\\\"");
            return textoNormalizado;
        }

        private Tuple<string, string> DividirTexto(string texto)
        {
            const int longitudMaximaTexto1 = 120;
            const int longitudMaximaTexto2 = 500;

            texto = this.NormalizarTexto(texto);

            if (texto.Length <= longitudMaximaTexto1)
            {
                return Tuple.Create(texto, string.Empty);
            }

            int posicionUltimoEspacio = texto.LastIndexOf(' ', longitudMaximaTexto1);

            string texto1;
            string texto2;

            if (posicionUltimoEspacio == -1)
            {
                texto1 = texto.Substring(0, longitudMaximaTexto1);
                //if (texto[longitudMaximaTexto1] != '\n')
                //{
                //    texto1 += "\n";
                //}
                texto2 = texto.Substring(longitudMaximaTexto1, Math.Min(longitudMaximaTexto2, texto.Length - longitudMaximaTexto1));
            }
            else
            {
                texto1 = texto.Substring(0, posicionUltimoEspacio);
                //if (texto[posicionUltimoEspacio] != '\n')
                //{
                //    texto1 += "\n";
                //}
                texto2 = texto.Substring(posicionUltimoEspacio + 1, Math.Min(longitudMaximaTexto2, texto.Length - posicionUltimoEspacio - 1));
            }

            return Tuple.Create(texto1, texto2);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //if (this.txtCDC.Text != "")
            //    this.showKude();
            //string json = "{\"cdc\":\"01800168755001002000000112023040413296881727\",\"codigoRespuesta\":\"1000\",\"estado\":\"Rechazado\",\"fechaproceso\":\"2023-04-11T09:08:52-04:00\",\"lote\":\"115334546177896681\",\"msgRespuesta\":\"CDC no correspondiente con las informaciones del XML\",\"numdoc\":\"001-002-0000001\"}";
            //SifenQueryResponse2 asyncResponse = JsonConvert.DeserializeObject<SifenQueryResponse2>(json);
            //MessageBox.Show(asyncResponse.cdc);
            //this.CalcularTotal();
            decimal total = Convert.ToDecimal(this.txtMontoTotal.Text);
            decimal totalIVA10 = Convert.ToDecimal(this.txtTotalIVA10.Text);
            decimal liqIVA10 = Convert.ToDecimal(this.txtLiqIVA10.Text);
            decimal a = decimal.Round(totalIVA10 - liqIVA10, 2);
            decimal b = total;
            decimal x = this.GetDPropIVA(a, b, 10);
            MessageBox.Show(x.ToString());
        }

        private void txtKude_TextChanged(object sender, EventArgs e)
        {
            //this.button1.Enabled = this.txtCDC.Text != "";
        }

        private int calcDVModEleven(string p_numero, int p_basemax = 11)
        {
            /*
             * Calcula Digito Verificador numérico con entrada alfanumérica y basemax 11
             */

            int v_total = 0;
            int v_resto = 0;
            int k = 2;
            int v_numero_aux = 0;
            string v_numero_al = "";
            string v_caracter = "";
            int v_digit = 0;

            // Cambia la ultima letra por ascii en caso que la cedula termine en letra
            for (int i = 0; i < p_numero.Length; i++)
            {
                v_caracter = p_numero[i].ToString().ToUpper();
                if ((int)v_caracter[0] < 48 || (int)v_caracter[0] > 57)
                {
                    v_numero_al += ((int)v_caracter[0]).ToString();
                }
                else
                {
                    v_numero_al += v_caracter;
                }
            }

            // Calcula el DV
            for (int i = v_numero_al.Length - 1; i >= 0; i--)
            {
                if (k > p_basemax)
                {
                    k = 2;
                }
                v_numero_aux = int.Parse(v_numero_al[i].ToString());
                v_total += (v_numero_aux * k);
                k++;
            }

            v_resto = v_total % 11;
            if (v_resto > 1)
            {
                v_digit = 11 - v_resto;
            }
            else
            {
                v_digit = 0;
            }

            return v_digit;
        }

        private string GetCodSeg()
        {
            int maxNumber = 999999999;
            int number = 0;

            // Utiliza el tick de tipo DateTime como semilla del generador Random
            Random random = new Random(DateTime.Now.Ticks.GetHashCode());

            do
            {
                number = random.Next(1, maxNumber + 1);
            } while (number.ToString().Length < 9);

            string numberString = number.ToString().PadLeft(9, '0');
            return numberString;
        }

        private string GenerateCDC(string TipoDE, string RUC, string DV, string Establecimiento, string PuntoExpedicion, string NumDoc, string TipoContribuyente, DateTime FechaEmision, string TipoEmisor, string CodSeguridad)
        {
            string cdc = TipoDE.PadLeft(2, '0') + //iTiDe
                         RUC.PadLeft(8, '0') + //dRucEM
                         DV +//dDVEmi
                         Establecimiento.PadLeft(3, '0') + //dEst
                         PuntoExpedicion.PadLeft(3, '0') +//dPunExp
                         NumDoc.PadLeft(7, '0') + //dNumDoc
                         TipoContribuyente + //iTipCont
                         FechaEmision.ToString("yyyyMMdd") + //dFeEmiDE
                         TipoEmisor + //iTipEmi
                         CodSeguridad;//dCodSeg
            cdc = cdc + this.calcDVModEleven(cdc);//dDVid

            return cdc;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string hola = this.GenerateJSON(Convert.ToInt32(this.txtNotaCreditoID.Text));
        }

        private void GeneraDEDialogHandler(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    this.GenDE(Convert.ToInt32(this.txtNotaCreditoID.Text));
                }
            }
        }

        private void btnGenDE_Click(object sender, EventArgs e)
        {
            string message = "";
            string caption = "";
            caption = "Generación de Documento Electrónico";
            message = "Se generará la nota de crédito electrónica ¿Desea continuar?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(GeneraDEDialogHandler));
        }

        private void btnActualizarEstadoDE_Click(object sender, EventArgs e)
        {
            string message = "";
            string caption = "";
            caption = "Actualización de Estado de Documento Electrónico";
            message = "Se actualizará el estado de la factura electrónica ¿Desea continuar?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(ActualizarDEDialogHandler));
        }
        
        private void ActualizarDEDialogHandler(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    string result = this.ActualizarDE(this.txtLote.Text);
                    //string result = this.ActualizarDE(this.txtCDC.Text);
                    string[] msg = result.Split('#');

                    if (msg.Length > 1)
                    {
                        this.btnActualizarEstadoDE.Visible = msg[1] == ESTADO_PENDIENTE || result.Contains(EN_PROCESAMIENTO);
                        MessageBox.Show(result.Replace("#", Environment.NewLine), "Información");
                    }
                    else
                    {
                        MessageBox.Show(msg[0], "Información de Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                    }
                }
            }
        }

        private string ActualizarDE(string valor, bool consultarPorCDC = false)
        //private string ActualizarDE(string lote)
        {
            string result = String.Empty;
            SifenQueryResponse queryResponse = new SifenQueryResponse();
            //var url = "https://facte.siga.com.py/FacturaE/rest/consultarLote?ruc=80016875-5&codigo=" + valor + "&token=" + TOKEN_JWT;
            var url = "https://facte.siga.com.py/FacturaE/rest/consultarLote/json?ruc=80016875-5&codigo=" + valor + "&token=" + TOKEN_JWT;
            
            if (consultarPorCDC)
                url = "https://facte.siga.com.py/FacturaE/rest/consultarDE/json?ruc=80016875-5&codigo=" + valor + "&token=" + TOKEN_JWT;

            string responseContent = "";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync(url).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        responseContent = response.Content.ReadAsStringAsync().Result;
                        //responseContent = responseContent.Replace("[", "").Replace("]", "");
                        //queryResponse = JsonConvert.DeserializeObject<SifenQueryResponse>(responseContent);

                        var rsp = JsonConvert.DeserializeObject<dynamic>(responseContent);
                        
                        if (rsp.Count > 1)
                            queryResponse = JsonConvert.DeserializeObject<SifenQueryResponse>(rsp[1].ToString());
                        else queryResponse = JsonConvert.DeserializeObject<SifenQueryResponse>(rsp[0].ToString());

                        if ((queryResponse.estado == ESTADO_APROBADO) || (queryResponse.estado == ESTADO_RECHAZADO))
                        {
                            using (BerkeDBEntities context = new BerkeDBEntities())
                            {
                                int NotaCreditoCabId = Convert.ToInt32(this.txtNotaCreditoID.Text);
                                nc_notacreditocabecera nc = context.nc_notacreditocabecera.FirstOrDefault(a => a.nc_notacreditocabeceraid == NotaCreditoCabId);
                                nc.nc_estadode = queryResponse.estado;

                                if (String.IsNullOrEmpty(nc.nc_cdc))
                                    nc.nc_cdc = queryResponse.cdc;

                                if (queryResponse.estado == ESTADO_RECHAZADO)
                                    nc.nc_motivorechazo = queryResponse.msgRespuesta;

                                if (queryResponse.estado == ESTADO_APROBADO)
                                {
                                    fc_facturacabecera fc = context.fc_facturacabecera.First(a => a.fc_facturacabeceraid == nc.nc_facturacabid);
                                    fc.fc_estadode = ESTADO_CON_NOTA_CREDITO;
                                }

                                context.SaveChanges();

                                this.txtEstadoDE.Text = queryResponse.estado;
                                this.txtCDC.Text = queryResponse.cdc;
                                this.btnActualizarEstadoDE.Visible = queryResponse.estado == ESTADO_PENDIENTE_DE;
                                this.btnVerMotivoRechazo.Visible = queryResponse.estado == ESTADO_RECHAZADO;
                                //this.tbbImprimir.Visible = !(this.txtEstadoDE.Text == ESTADO_RECHAZADO) && this.txtCDC.Text != String.Empty;

                                //if (queryResponse.estado == ESTADO_APROBADO)
                                //    MessageBox.Show(queryResponse.estado + " - " + queryResponse.msgRespuesta, "Información");
                                //else
                                //{
                                //    MessageBox.Show(queryResponse.estado + " - " + queryResponse.msgRespuesta, "Información de Error", MessageBoxButtons.OK,
                                //                    MessageBoxIcon.Error);
                                //}
                            }
                        }
                        result = "Estado actualizado correctamente.#" + queryResponse.estado + "#" + queryResponse.msgRespuesta;
                        //MessageBox.Show("Estado actualizado correctamente" + 
                        //                Environment.NewLine +
                        //                queryResponse.estado + " - " + queryResponse.msgRespuesta
                        //                , "Información");
                    }
                    else
                    {
                        throw new Exception(response.StatusCode + Environment.NewLine + response.ReasonPhrase);
                    }

                }
            }
            catch (Exception ex)
            {
                if (responseContent == "")
                    result = this.ActualizarDE(this.txtCDC.Text, true);
                //result = this.ActualizarDE_XML(this.txtCDC.Text);
                else result = ex.Message;
            }
            return result;
        }

        private void GenDE(int NotaCreditoCabId)
        {
            try
            {
                string message = string.Empty;
                SifenQueryResponse2 res = this.callStarsoftSiga(NotaCreditoCabId);

                if (res.msgRespuesta.Contains(EN_PROCESAMIENTO))
                {
                    res.estado = ESTADO_PENDIENTE_DE;
                    res.cdc = this.txtCDC.Text;
                }

                if (ESTADOS_DE.Contains(res.estado))
                {
                    this.txtCDC.Text = res.cdc;
                    this.txtEstadoDE.Text = res.estado;
                    this.txtLote.Text = res.lote;
                    this.btnGenDE.Visible = false;
                    this.btnVerMotivoRechazo.Visible = res.estado == ESTADO_RECHAZADO;
                    this.tbbImprimir.Visible = !(this.txtEstadoDE.Text == ESTADO_RECHAZADO) && this.txtCDC.Text != String.Empty;

                    using (BerkeDBEntities context = new BerkeDBEntities())
                    {
                        nc_notacreditocabecera nc2 = context.nc_notacreditocabecera.FirstOrDefault(a => a.nc_notacreditocabeceraid == NotaCreditoCabId);
                        nc2.nc_cdc = res.cdc;
                        nc2.nc_estadode = res.estado;
                        nc2.nc_lote = res.lote;

                        if (res.estado == ESTADO_RECHAZADO)
                            nc2.nc_motivorechazo = res.msgRespuesta;

                        if (res.estado == ESTADO_APROBADO)
                        {
                            fc_facturacabecera fc = context.fc_facturacabecera.First(a => a.fc_facturacabeceraid == nc2.nc_facturacabid);
                            fc.fc_estadode = ESTADO_CON_NOTA_CREDITO;
                        }

                        context.SaveChanges();
                    }

                    message = res.estado == ESTADO_APROBADO
                                    ? "Operación éxitosa. Documento electrónico generado."
                                    : "El documento electrónico ha sido rechazado." + Environment.NewLine + res.msgRespuesta;//res.codError;

                    if (res.estado == ESTADO_PENDIENTE_DE)
                    {
                        Thread.Sleep(3000);
                        string result = this.ActualizarDE(this.txtLote.Text);
                        //string result = this.ActualizarDE(this.txtCDC.Text);
                        string[] msg = result.Split('#');

                        if (msg.Length > 1)
                        {
                            this.btnActualizarEstadoDE.Visible = msg[1] == ESTADO_PENDIENTE_DE;
                            //message = result.Replace("#", Environment.NewLine);
                            if (msg[1] == ESTADO_APROBADO)
                            {
                                //using (BerkeDBEntities context2 = new BerkeDBEntities())
                                //{
                                //    int facturaCabID = Convert.ToInt32(this.txtFacturaCabID.Text);
                                //    fc_facturacabecera fc = context2.fc_facturacabecera.First(a => a.fc_facturacabeceraid == facturaCabID);
                                //    fc.fc_estadode = ESTADO_CON_NOTA_CREDITO;
                                //    context2.SaveChanges();
                                //}
                                message = "Operación éxitosa. Documento electrónico generado.";
                            }
                            else if (msg[1] == ESTADO_RECHAZADO)
                            {
                                message = "El documento electrónico ha sido rechazado." + Environment.NewLine + msg[2];
                                this.btnVerMotivoRechazo.Visible = true;
                            }
                            else
                            {
                                message = "Documento electrónico en procesamiento. Actualice el estado en unos minutos.";
                                this.btnActualizarEstadoDE.Visible = true;
                            }

                        }
                        else
                        {
                            throw new Exception(msg[0]);
                        }
                    }

                    MessageBox.Show(message,
                            "Información",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                }
                else
                {
                    this.btnGenDE.Visible = this.txtCDC.Text == String.Empty && this.txtEstadoDE.Text == String.Empty;
                    throw new Exception(res.estado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información de Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                return;
            }
        }

        private void btnVerMotivoRechazo_Click(object sender, EventArgs e)
        {
            this.VerMotivoRechazo(Convert.ToInt32(this.txtNotaCreditoID.Text));
        }

        private SifenCancelResponse CancelarDE(string cdc, string motivo)
        {
            motivo = motivo.TrimEnd();

            if (String.IsNullOrEmpty(motivo))
                throw new Exception("Debe definir un motivo válido para la cancelacion de la FE en la autorización de anulación de la factura.");

            motivo = Uri.EscapeUriString(motivo);

            SifenCancelResponse queryResponse = new SifenCancelResponse();
            var url = String.Format("https://facte.siga.com.py/FacturaE/rest/cancelar/json?ruc=80016875-5&cdc={0}&motivo={1}&token={2}", cdc, motivo, TOKEN_JWT);

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    queryResponse = JsonConvert.DeserializeObject<SifenCancelResponse>(responseContent);
                }
                else
                {
                    throw new Exception(response.StatusCode + Environment.NewLine + response.ReasonPhrase);
                }

            }
            return queryResponse;
        }

        private void VerMotivoRechazo(int NotaCreditoCabID)
        {
            try
            {
                using (BerkeDBEntities context = new BerkeDBEntities())
                {
                    string motivoRechazo = context.nc_notacreditocabecera.FirstOrDefault(a => a.nc_notacreditocabeceraid == NotaCreditoCabID).nc_motivorechazo;
                    motivoRechazo = !String.IsNullOrEmpty(motivoRechazo) ? motivoRechazo : "--";
                    MessageBox.Show("Motivo rechazo: " + Environment.NewLine + motivoRechazo, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información de Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

            #region Deprecated
            //SifenQueryResponse2 queryResponse = new SifenQueryResponse2();
            //var url = "https://facte.siga.com.py/FacturaE/rest/consultarLote?ruc=80016875-5&codigo=" + this.txtLote.Text + "&token=" + TOKEN_JWT;

            //try
            //{
            //    using (HttpClient client = new HttpClient())
            //    {
            //        HttpResponseMessage response = client.GetAsync(url).Result;

            //        if (response.IsSuccessStatusCode)
            //        {
            //            string responseContent = response.Content.ReadAsStringAsync().Result;
            //            responseContent = responseContent.Replace("[", "").Replace("]", "");
            //            queryResponse = JsonConvert.DeserializeObject<SifenQueryResponse2>(responseContent);
            //            MessageBox.Show("Motivo rechazo: " + Environment.NewLine + queryResponse.msgRespuesta, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //        else
            //        {
            //            throw new Exception(response.StatusCode + Environment.NewLine + response.ReasonPhrase);
            //        }

            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Información de Error", MessageBoxButtons.OK,
            //                    MessageBoxIcon.Error);
            //}
            #endregion Deprecated
        }

        private void txtFechaFactura_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtFechaFactura_KeyUp(object objSender, KeyEventArgs objArgs)
        {
            //if ((this.FormEditStatus != BROWSE) && (this.tSBMoneda.DisplayMember != String.Empty) && (this.txtFechaFactura.Text != String.Empty))
            //{
            //    this.CheckTipoCambio();
            //}
        }

        private void btnEliminarFila_Click(object sender, EventArgs e)
        {
            if (this.dgvDetNC.SelectedRows.Count > 0)
            {
                this.dgvDetNC.Rows.RemoveAt(this.dgvDetNC.SelectedRows[0].Index);
            }
        }

        private void dgvDetNC_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Recorrer todas las columnas del DataGridView
            foreach (DataGridViewColumn column in this.dgvDetNC.Columns)
            {
                // Verificar si la columna es la DataGridViewButtonColumn
                if (column.GetType() == typeof(DataGridViewButtonColumn))
                {
                    // Ocultar la columna DataGridViewButtonColumn
                    column.Visible = false;
                }
            }
        }
    }

    public class SifenAsyncResponse
    {
        public string cdc { get; set; }
        public string codError { get; set; }
        public string estado { get; set; }
        public DateTime fecha { get; set; }
        public string lote { get; set; }
        public string protAut { get; set; }
        public string ruc { get; set; }
        public string tipoDe { get; set; }
        public string tipoWS { get; set; }
    }

    public class SifenQueryResponseMail
    {
        public string climail { get; set; }
        public string correoEnviado { get; set; }
    }

    public class SifenQueryResponse
    {
        public string cdc { get; set; }
        public string codigoRespuesta { get; set; }
        public string estado { get; set; }
        public DateTime fechaproceso { get; set; }
        public string lote { get; set; }
        public string msgRespuesta { get; set; }
        public string numini { get; set; }
        public string ruc { get; set; }

        public string climail { get; set; }
        public string correoEnviado { get; set; }
    }

    public class SifenQueryResponseNew
    {
        public string cdc { get; set; }
        public string climail { get; set; }
        public string codigoRespuesta { get; set; }
        public string correoEnviado { get; set; }
        public string estado { get; set; }
        //public DateTime fechaproceso { get; set; }
        //public string lote { get; set; }
        public string msgRespuesta { get; set; }
        //public string numini { get; set; }
        public string ruc { get; set; }
    }

    public class SifenQueryResponseGlobal
    {
        public string cdc { get; set; }
        public string estado { get; set; }
        public string msgRespuesta { get; set; }
    }

    public class SifenQueryResponse2
    {
        public string cdc { get; set; }
        public string codigoRespuesta { get; set; }
        public string estado { get; set; }
        public DateTime fechaproceso { get; set; }
        public string lote { get; set; }
        public string msgRespuesta { get; set; }
        public string numdoc { get; set; }
    }

    public class SifenCancelResponse
    {
        public string cdc { get; set; }
        public string codigoRespuesta { get; set; }
        public string error { get; set; }
        public string estado { get; set; }
        public DateTime fechaproceso { get; set; }
        public string msgRespuesta { get; set; }
        public string proAut { get; set; }
    }
}