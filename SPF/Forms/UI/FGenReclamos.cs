#region Using

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.IO;
using System.Data.Objects.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Globalization;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms;

using ModelEF6;
using SPF.Forms.Base;
using SPF.Types;
using SPF.Forms;
using SPF.Base;
using SPF.Forms.UI;

using Berke.Libs.Base;

#endregion

namespace SPF.Forms.UI
{
    public partial class FGenReclamos : Form
    {
        #region Variables
        int CantTabs = 0;
        int cntGenerados = 0;
        int cntAProcesar = 0;
        int cntProcesados = 0;
        bool existeError;
        frmPickBase fPickCliente;
        frmPickBase fPickTramite;
        frmPickBase fPickPais;
        frmPickBase fPickCiudad;
        frmPickBase fPickCArea;
        frmPickBase fPickUnidadNegocio;
        BerkeDBEntities DBContext;
        private BindingList<TramiteType> bList1;
        private BindingList<TramiteType> bList2;
        private string w_directorio_trabajo = "";
        private List<DetallePresupuestoType> ListaDetallePresupuesto;
        List<GetCotizacionesParaPresupuestos_Result> listaCoti;
        List<GetListadoGeneraldeDeudasPendientes_Result> listaDeudas;
        private bool MostrarProgressBar = false;
        System.Threading.Thread thr;
        int UsuarioID = 0;
        bool Lucifer = false;
        bool ProcesoTerminado = false;

        FDatosMailingHTML fDatosMailing;

        int contador = 0;

        private string fechaDesde = String.Empty;
        private string fechaHasta = String.Empty;
        private string fechaReclamarEn = String.Empty;
        
        #endregion Variables

        #region Constantes
        public const string CAMPO_SELECCIONAR       = "Seleccionar";
        public const string CAMPO_EXPEDIENTEID      = "ExpedienteID";
        public const string CAMPO_ACTANRO           = "ActaNro";
        public const string CAMPO_ACTAANHO          = "ActaAnho";
        public const string CAMPO_ACTA              = "Acta";
        public const string CAMPO_ORDENTRABAJOID    = "OrdenTrabajoID";
        public const string CAMPO_HINRO             = "HINro";
        public const string CAMPO_HIANHO            = "HIAnho";
        public const string CAMPO_HI                = "HI";
        public const string CAMPO_COTIZACIONCABID   = "CotizacionCabID";
        public const string CAMPO_FECHACOTIBCAB     = "FechaCotiCab";
        
        public const string CAMPO_TRAMITEID         = "TramiteID";
        public const string CAMPO_TRAMITEDESCRIP    = "TramiteDescrip";
        public const string CAMPO_TRAMITEDESCRIPESP = "EtiquetaEsp";
        public const string CAMPO_SERIEAUX          = "SerieAux";
        public const string CAMPO_NROPRESUPUESTOAUX = "NroPresupuestoAux";
        public const string CAMPO_GENERADO          = "Generado";
        public const string CAMPO_NROPRESUPUESTO    = "NroPresupuesto";
        public const string CAMPO_CLIENTECORREO     = "ClienteCorreo";
        public const string CAMPO_IDIOMAID          = "IdiomaID";
        public const string CAMPO_IDIOMA            = "Idioma";
        public const string CAMPO_CLIENTEMULTIPLE   = "ClienteMultiple";
        public const string CAMPO_REFCLIENTE        = "ReferenciaCliente";
        public const string CAMPO_REFCORRESP        = "ReferenciaCorresp";
        public const string CAMPO_FECHACORRESP      = "FechaCorresp";
        public const string CAMPO_NROCORRESP        = "NroCorresp";
        public const string CAMPO_ANIOCORRESP       = "AnioCorresp";
        public const string CAMPO_PAISID            = "PaisID";
        public const string CAMPO_PAIS              = "Pais";
        public const string CAMPO_ATENCIONID        = "AtencionID";
        public const string CAMPO_ATENCIONNOMBRE    = "AtencionNombre";
        public const string CAMPO_AREAID            = "AreaID";
        public const string CAMPO_MEID              = "MeID";
        public const string CAMPO_MERGEID           = "MergeID";
        public const string CAMPO_MERGEDOCID        = "MergeDocID";
        public const string CAMPO_ANULADO           = "Anulado";
        public const string CAMPO_EXPEIDPADRE       = "ExpedienteIDPadre";
        public const string CAMPO_EXPEIDPADRE_PR    = "ExpedientePadreID_pr";
        public const string CAMPO_ENTRAMITE         = "EnTramite";
        public const string CAMPO_ORIGEN            = "Origen";
        public const string CAMPO_PRESENTACIONFECHA = "PresentacionFecha";
        public const string CAMPO_DENOMINACIONMARCA = "DenominacionMarca";
        private const string CAMPO_FECGENERACIONAUX = "FechaGeneracionAux";
        public const string ORIGEN_MARCAS           = "M";
        public const string ORIGEN_OTRAS            = "O";
        private const string OK = "OK";
        public const int    IDIOMA_INGLES           = 1;
        public const int    IDIOMA_ESPANOL          = 2;
        public const int    IDIOMA_ALEMAN           = 3;
        public const int    IDIOMA_FRANCES          = 4;
        public const string MI_ENTER                = "\r\n";
        private const string DESCRIPCION_GASTOS_ING = "Expenses (Including: Taxes, official fees, publication and any other expenses)";
        private const string DESCRIPCION_GASTOS_ESP = "Gastos (Incluye: impuesto, tasa, publicación y otros gastos)";
        private const string DESCRIPCION_DESCUENTOS_ING = "Discounts";
        private const string DESCRIPCION_DESCUENTOS_ESP = "Descuentos";
        private const string PLANTILLA_PRESUPUESTO_MARCAS= "M8";
        private const string PLANTILLA_PRESUPUESTO_SPF_ESP = "PB";
        private const string PLANTILLA_PRESUPUESTO_SPF_PRUEBAS_ESP = "PBT";
        private const string PLANTILLA_PRESUPUESTO_SPF_PRUEBAS_ING = "PBT1";
        private const string PLANTILLA_PRESUPUESTO_SPF_ING = "PB1";
        private const int OPOSICIONES_ID = 29;
        private string[] textos = { "Procesando.", "Procesando..", "Procesando..." };
        private const string ESTADO_ACTIVO = "A";
        private const string IX_PC_NROPRESUPUESTO = "IX_pc_nropresupuesto";
        private const string DOLLARS = "DOLLARS";
        private const string DOLARES = "DOLARES";
        private const string MONEDA_GUARANIES = "G";
        private const string NEWLINEXML = "<w:br></w:br>";
        private const int LONGITUD_PADDING = 126;


        private const string CAMPO_FECHADOCUMENTO = "FechaDocumento";
        private const string CAMPO_CLIENTEID = "ClienteID";
        private const string CAMPO_CLIENTENOMBRE = "ClienteNombre";
        private const string CAMPO_TELEFONOSCLIENTE = "TelefonosCliente";
        private const string CAMPO_RUCCLIENTE = "RUCCliente";
        private const string CAMPO_RAZONSOCIALFACTURA = "RazonSocialFactura";
        private const string CAMPO_DIRECCIONCLIENTE = "DireccionCliente";
        private const string CAMPO_SALDODEUDA = "SaldoDeuda";
        private const string CAMPO_SALDOEQUIVALENTEDOLARES = "SaldoEquivalenteDolares";
        private const string CAMPO_MONTODEUDA = "MontoDeuda";
        private const string CAMPO_MONEDA = "Moneda";
        private const string CAMPO_MONEDAID = "MonedaID";
        private const string CAMPO_VERDETALLES = "VerDetalles";
        private const string CAMPO_VERTEXTONOTIF = "VerTextoNotif";
        private const string CAMPO_ERROR = "ErrMsg";

        private const string FORMATO_MONEDA_GUARANIES_GRILLA = "N0";
        private const string FORMATO_MONEDA_OTROS_GRILLA = "N2";
        private const string FORMATO_DECIMAL_BROWSE = "{0:N2}";
        private const string FORMATO_SIN_DECIMAL_BROWSE = "{0:N0}";

        private const string SMTP = "SMTP";
        private const string SMTP_PORT = "SMTP_PORT";
        private const string TEXTO_RECLAMO_INGLES = "TEXTO_RECLAMO_INGLES";
        private const string TEXTO_RECLAMO_ESPANOL = "TEXTO_RECLAMO_ESPANOL";
        private const string TITULO_RECLAMO_INGLES = "TITULO_RECLAMO_INGLES";
        private const string TITULO_RECLAMO_ESPANOL = "TITULO_RECLAMO_ESPANOL";
        private const string RECLAMO_CC = "RECLAMO_CC";
        private const int RECLAMO_AREAID = 26;
        private const int RECLAMO_VIAID = 4;
        private const string FORMAT_REFERENCIA = "{0}-{1}-{2}";

        private const string ORIGEN_DE_LOS_TIEMPOS = "01/01/1900";
        private const string NEW_LINE_HTML = "<br>";
        private const string SEP_TRAMITE = ";#;";
        private const string SITUACIONES_ALERTA_ESTADO_CUENTA = "SITUACIONES_ALERTA_ESTADO_CUENTA";
        private const string FORMAT_MSG = "MENSAJE_{0}_{1}";
        private const string FORMAT_ESP = "ESP";
        private const string FORMAT_ING = "ING";
        private const string CULTURE_PY = "es-PY";
        private const string CULTURE_US = "en-US";
        private const string FORMAT_REDFONTMARK = "<font color='red'><b>{0}</b></font>";
        private const string TABLE_HEADER_SPANISH = "<tr style='background: #dbe5f1;'>" +
                                                    "   <td style='width: 7%; border: 1px solid #d3d3d3; padding: 2pt 2pt 2pt 2pt; font-weight: bold; font-size: small; text-align: left;'>Cliente:</td>" +
                                                    "   <td colspan='4' style='border: 1px solid #d3d3d3; padding: 2pt 2pt 2pt 2pt; font-size: small; text-align: left;'>{0} ({1})</td>" +
	                                                "</tr>" +
                                                    "<tr style='background: #b8cce4;'>" +
                                                    "	<td style='width: 7%; border: 1px solid #d3d3d3; padding: 2pt 2pt 2pt 2pt; font-weight: bold; font-size: small;'>Moneda</td>" +
                                                    "	<td style='width: 10%; border: 1px solid #d3d3d3; padding: 2pt 2pt 2pt 2pt; font-weight: bold; font-size: small;'>Fecha</td>" +
                                                    "	<td style='width: 47%; border: 1px solid #d3d3d3; padding: 2pt 2pt 2pt 2pt; font-weight: bold; font-size: small;'>Trámite</td>" +
                                                    "	<td style='width: 18%; border: 1px solid #d3d3d3; padding: 2pt 2pt 2pt 2pt; font-weight: bold; font-size: small;'>Documento Nº</td>" +
                                                    "	<td style='width: 18%; border: 1px solid #d3d3d3; padding: 2pt 2pt 2pt 2pt; font-weight: bold; font-size: small;'>Saldo</td>" +
                                                    "</tr>";

        private const string TABLE_HEADER_ENGLISH = "<tr style='background: #dbe5f1;'>" +
                                                    "   <td style='width: 15%; border: 1px solid #d3d3d3; padding: 2pt 2pt 2pt 2pt; font-weight: bold; font-size: small; text-align: left;'>Client:</td>" +
                                                    "   <td colspan='4' style='border: 1px solid #d3d3d3; padding: 2pt 2pt 2pt 2pt; font-size: small; text-align: left;'>{0} ({1})</td>" +
                                                    "</tr>" +
                                                    "<tr style='background: #b8cce4;'>" +
                                                    "	<td style='width: 7%; border: 1px solid #d3d3d3; padding: 2pt 2pt 2pt 2pt; font-weight: bold; font-size: small;'>Currency</td>" +
                                                    "	<td style='width: 10%; border: 1px solid #d3d3d3; padding: 2pt 2pt 2pt 2pt; font-weight: bold; font-size: small;'>Date</td>" +
                                                    "	<td style='width: 47%; border: 1px solid #d3d3d3; padding: 2pt 2pt 2pt 2pt; font-weight: bold; font-size: small;'>Subject</td>" +
                                                    "	<td style='width: 18%; border: 1px solid #d3d3d3; padding: 2pt 2pt 2pt 2pt; font-weight: bold; font-size: small;'>Bill Number</td>" +
                                                    "	<td style='width: 18%; border: 1px solid #d3d3d3; padding: 2pt 2pt 2pt 2pt; font-weight: bold; font-size: small;'>Amount</td>" +
                                                    "</tr>";

        private const string TABLE_ROW = "<tr style='background: {0};'>" +
                                        "	<td style='width: 7%; border: 1px solid #d3d3d3; padding: 2pt 2pt 2pt 2pt; font-size: small; text-align: center;'>{1}</td>" +
                                        "	<td style='width: 10%; border: 1px solid #d3d3d3; padding: 2pt 2pt 2pt 2pt; font-size: small; text-align: left;'>{2}</td>" +
                                        "	<td style='width: 47%; border: 1px solid #d3d3d3; padding: 2pt 2pt 2pt 2pt; font-size: small; text-align: left;'>{3}</td>" +
                                        "	<td style='width: 18%; border: 1px solid #d3d3d3; padding: 2pt 2pt 2pt 2pt; font-size: small; text-align: left;'>{4}</td>" +
                                        "	<td style='width: 18%; border: 1px solid #d3d3d3; padding: 2pt 2pt 2pt 2pt; font-size: small; text-align: right;'>{5}</td>" +
                                        "</tr>";
        private const string FORMAT_TOTAL_AMOUNT = "<b>{0} {1}</b>";
        private const string BG_EVEN = "#b8cce4";
        private const string BG_ODD = "#dbe5f1";
        #endregion Constantes

        #region Propiedades
        public string FechaDesde
        {
            get { return this.fechaDesde; }
            set { this.fechaDesde = value; }
        }

        public string FechaHasta
        {
            get { return this.fechaHasta; }
            set { this.fechaHasta = value; }
        }

        public string FechaReclamarEn
        {
            get { return this.fechaReclamarEn; }
            set { this.fechaReclamarEn = value; }
        }
        #endregion Propiedades

        #region Métodos de Inicialización
        public FGenReclamos()
        {
            InitializeComponent();
        }

        public FGenReclamos(string titulo, BerkeDBEntities context)
        {
            InitializeComponent();
            this.Text = titulo;
            this.DBContext = context;
            this.ConfigTabs();
            this.UsuarioID = Convert.ToInt32(VWGContext.Current.Session["UsuarioID"].ToString());
            
            #region DateTime Pickers
            this.dtpFechaDesde.Format = DateTimePickerFormat.Short;
            this.dtpFechaDesde.Value = System.DateTime.Now.AddDays(-30);
            this.dtpFechaHasta.Format = DateTimePickerFormat.Short;
            this.dtpFechaHasta.Value = System.DateTime.Now;

            #endregion DateTime Pickers

            this.rbIncluirTodo.Checked = true;

            #region TextSearchBoxes
            this.tSBCliente.KeyMemberWidth = 70;
            this.tSBCliente.ToolTip = "Elegir Cliente";
            this.tSBCliente.AceptarClick += tSBCliente_AceptarClick;
            this.tSBCliente.Editable = true;
            this.tSBCliente.ToolTipTSB = "Cliente";

            this.tSBTramite.KeyMemberWidth = 70;
            this.tSBTramite.ToolTip = "Elegir Trámite";
            this.tSBTramite.AceptarClick += tSBTramite_AceptarClick;
            this.tSBTramite.Editable = true;
            this.tSBTramite.ToolTipTSB = "Trámite";

            this.tSBPais.KeyMemberWidth = 70;
            this.tSBPais.ToolTip = "Elegir País";
            this.tSBPais.Editable = true;
            this.tSBPais.AceptarClick += tSBPais_AceptarClick;

            this.tSBCiudad.KeyMemberWidth = 70;
            this.tSBCiudad.ToolTip = "Elegir País";
            this.tSBCiudad.Editable = true;
            this.tSBCiudad.AceptarClick += tSBCiudad_AceptarClick;

            this.tSBAreaContab.KeyMemberWidth = 70;
            this.tSBAreaContab.ToolTip = "Elegir Trámite";
            this.tSBAreaContab.Editable = true;
            this.tSBAreaContab.AceptarClick += tSBAreaContab_AceptarClick;

            this.tSBUnidadNegocio.KeyMemberWidth = 70;
            this.tSBUnidadNegocio.ToolTip = "Elegir Trámite";
            this.tSBUnidadNegocio.Editable = true;
            this.tSBUnidadNegocio.AceptarClick += tSBUnidadNegocio_AceptarClick;
            #endregion TextSearchBoxes

            this.w_directorio_trabajo = @VWGContext.Current.Session["PresupFolderURL"].ToString();

            this.listaDeudas = new List<GetListadoGeneraldeDeudasPendientes_Result>();
            
        }

        /// <summary>
        /// This type of UI updates on main UI thread would be easy to update to the browser,
        /// as it would automatically do so if changes are made from a normal response 
        /// processing code.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FPresupuesto_CometHartbeat(object sender, EventArgs e)
        {
            //if ((this.Lucifer) && (this.thr == null))
            //{
            //    thr = new System.Threading.Thread(GenerarPresupuestos);
            //    thr.Start();
            //}
            ////this.txtCounter.Text = this.contador++.ToString();
            //this.ActualizarProgressBar();
        }

        private void ActualizarProgressBar()
        {
            if (this.MostrarProgressBar)
            {
                if (this.pbarGeneracion.Value == 0)
                {
                    this.pbarGeneracion.Visible = true;
                }

                if ((this.cntProcesados > 0) && (this.pbarGeneracion.Maximum > 0)) 
                {
                    this.pbarGeneracion.Value = this.cntProcesados;
                    this.lblRegistrosInfo.Text = String.Format("Procesando {0} de {1}", this.cntProcesados.ToString(), this.pbarGeneracion.Maximum.ToString());
                }

                //if (!this.timer1.Enabled)
                if (this.ProcesoTerminado)
                {
                    this.timer1.Stop();
                    this.ProcesoTerminado = false;

                    this.pbarGeneracion.Value = this.pbarGeneracion.Maximum;
                    this.lblRegistrosInfo.Text = String.Format("{0} de {1} procesados.", this.pbarGeneracion.Maximum.ToString(), this.pbarGeneracion.Maximum.ToString());
                    this.cntAProcesar = 0;
                    this.cntProcesados = 0;
                    this.MostrarProgressBar = false;

                    #region Resumen de Procesamiento
                    string Resultado = "";
                    if ((this.existeError) || (this.cntGenerados > 0))
                    {
                        //this.dgvCotizaciones.Columns[CAMPO_ERROR].Visible = true;
                        this.FormatearGrilla(true);
                        this.dgvDeudas.EditMode = DataGridViewEditMode.EditOnF2;
                        Resultado = this.cntGenerados > 0 ? "Se generaron " + this.cntGenerados.ToString() + " presupuestos." + Environment.NewLine : "";
                        Resultado += this.existeError ? "Se produjeron errores al generar algunos documentos," + Environment.NewLine +
                                                   "verifique el error en la columna \"Resultado\"." : "";
                    }

                    MessageBox.Show(Resultado,
                                    this.existeError ? "Atención Requerida" : "Resumen de procesamiento",
                                    MessageBoxButtons.OK,
                                    this.existeError ? MessageBoxIcon.Exclamation : MessageBoxIcon.Information);
                    this.cntGenerados = 0;
                    this.existeError = false;
                    #endregion Resumen de Procesamiento
                }
            }
        }

        private void FPresupuesto_Load(object sender, EventArgs e)
        {
            //this.CometHartbeat += this.FPresupuesto_CometHartbeat;
            //this.CometFrequency = 1500;

            this.timer1.Tick += timer1_Tick;
            //this.timer1.Start();
            this.tbCtrlGenPresup_SelectedIndexChanged(sender, e);
            this.lblTitulo.Text = "Asistente para la Generación de Cartas de Reclamo - Especificación de Filtros";
            this.btnMarcarTodo.Text = "Marcar Todo";
            this.btnGenerar.Text = "Generar" + Environment.NewLine + "Reclamos";
            this.btnVerDocumentos.Text = "Ver" + Environment.NewLine + "Documentos";
            this.btnActualizarGrilla.Text = "Actualizar" + Environment.NewLine + "Grila";
            this.btnActualizarConBD.Text = "Actualizar" + Environment.NewLine + "Docs en BD";
            this.tSBCliente.SetFocus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //this.txtCounter.Text = this.contador++.ToString();
            if (this.Lucifer)
            {
                this.Lucifer = false;
                this.GenerarPresupuestos();
                //this.GenerarPresupuestos();

                //GenerarPresupuestos_delegate d;
                //IAsyncResult h1;
                //AsyncCallback ACB;

                //d = new GenerarPresupuestos_delegate(this.GenerarPresupuestos);
                //ACB = new AsyncCallback(this.TaskCompleted);
                //h1 = d.BeginInvoke(ACB, null);

            }

            this.ActualizarProgressBar();

            //if (this.ProcesoTerminado)
            //{
            //    this.timer1.Stop();

            //    this.txtMessage.Text = this.existeError.ToString() + this.cntGenerados.ToString();

            //    this.ProcesoTerminado = false;
            //    this.pbarGeneracion.Value = this.pbarGeneracion.Maximum;
            //    this.lblRegistrosInfo.Text = String.Format("{0} de {1} procesados.", this.pbarGeneracion.Maximum.ToString(), this.pbarGeneracion.Maximum.ToString());
            //    this.cntAProcesar = 0;
            //    this.cntProcesados = 0;
            //    this.MostrarProgressBar = false;

            //    #region Resumen de Procesamiento
            //    string Resultado = "";
            //    if ((this.existeError) || (this.cntGenerados > 0))
            //    {
            //        this.dgvCotizaciones.Columns[CAMPO_ERROR].Visible = true;
            //        Resultado = this.cntGenerados > 0 ? "Se generaron " + this.cntGenerados.ToString() + " presupuestos." + Environment.NewLine : "";
            //        Resultado += this.existeError ? "Se produjeron errores al generar algunos documentos," + Environment.NewLine +
            //                                   "verifique el error en la columna \"Resultado\"." : "";
            //    }

            //    MessageBox.Show(Resultado,
            //                    this.existeError ? "Atención Requerida" : "Resumen de procesamiento",
            //                    MessageBoxButtons.OK,
            //                    this.existeError ? MessageBoxIcon.Exclamation : MessageBoxIcon.Information);
            //    this.cntGenerados = 0;
            //    this.existeError = false;
            //    #endregion Resumen de Procesamiento
            //}
        }

        private void ConfigTabs()
        {
            this.tbCtrlGenReclamos.Appearance = TabAppearance.Logical;
            this.CantTabs = this.tbCtrlGenReclamos.TabPages.Count;

            #region Tab Filtros
            this.lblFiltros.Text = "Indique los criterios de filtro a tener en cuenta para la selección de cotizaciones con las que se Generarán Presupuestos.";
            #endregion Tab Filtros

            

            #region Tab Selección
            //this.lblTitulo.Text = "Definición de Cotizaciones";
            this.lblSeleccion.Text = "Seleccione los clientes para los que se generarán Reclamos";
            #endregion Tab Selección
        }

        #endregion Métodos de Inicialización

        #region Métodos de Apoyo

        private void FormatearGrilla(bool mostrarError = false)
        {
            foreach (DataGridViewColumn col in dgvDeudas.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            //this.dgvCotizaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeudas.ReadOnly = false;
            this.dgvDeudas.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.dgvDeudas.ItemsPerPage = 13;
            this.dgvDeudas.ShowCellToolTips = true;
            this.dgvDeudas.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvDeudas.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvDeudas.DefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvDeudas.DefaultCellStyle.BackColor = Color.Transparent;

            this.dgvDeudas.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;

            int displayIndex = 0;

            dgvDeudas.Columns[CAMPO_CLIENTEID].Visible = true;
            dgvDeudas.Columns[CAMPO_CLIENTEID].DisplayIndex = displayIndex;
            dgvDeudas.Columns[CAMPO_CLIENTEID].HeaderText = "Cliente ID";
            //dgvDeudas.Columns[CAMPO_CLIENTEID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDeudas.Columns[CAMPO_CLIENTEID].Width = 70;
            displayIndex++;

            this.dgvDeudas.Columns[CAMPO_ERROR].Visible = mostrarError;
            this.dgvDeudas.Columns[CAMPO_ERROR].DisplayIndex = displayIndex;
            this.dgvDeudas.Columns[CAMPO_ERROR].HeaderText = "Resultado";
            this.dgvDeudas.Columns[CAMPO_ERROR].Width = 300;
            displayIndex++;

            this.dgvDeudas.Columns[CAMPO_CLIENTENOMBRE].Visible = true;
            this.dgvDeudas.Columns[CAMPO_CLIENTENOMBRE].DisplayIndex = displayIndex;
            this.dgvDeudas.Columns[CAMPO_CLIENTENOMBRE].HeaderText = "Cliente Nombre";
            this.dgvDeudas.Columns[CAMPO_CLIENTENOMBRE].Width = 300;
            displayIndex++;

            //this.dgvDeudas.Columns[CAMPO_MONTODEUDA].HeaderText = "Monto Total Deuda";
            //this.dgvDeudas.Columns[CAMPO_MONTODEUDA].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.dgvDeudas.Columns[CAMPO_MONTODEUDA].Width = 60;
            //this.dgvDeudas.Columns[CAMPO_MONTODEUDA].DisplayIndex = displayIndex;
            //this.dgvDeudas.Columns[CAMPO_MONTODEUDA].DefaultCellStyle.Format = FORMATO_MONEDA_OTROS_GRILLA;
            //this.dgvDeudas.Columns[CAMPO_MONTODEUDA].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dgvDeudas.Columns[CAMPO_MONTODEUDA].Visible = true;
            //displayIndex++;

            this.dgvDeudas.Columns[CAMPO_MONEDA].Visible = true;
            this.dgvDeudas.Columns[CAMPO_MONEDA].DisplayIndex = displayIndex;
            this.dgvDeudas.Columns[CAMPO_MONEDA].HeaderText = "Moneda";
            this.dgvDeudas.Columns[CAMPO_MONEDA].Width = 60;
            displayIndex++;

            this.dgvDeudas.Columns[CAMPO_SALDODEUDA].HeaderText = "Saldo Deuda";
            this.dgvDeudas.Columns[CAMPO_SALDODEUDA].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDeudas.Columns[CAMPO_SALDODEUDA].Width = 120;
            this.dgvDeudas.Columns[CAMPO_SALDODEUDA].DisplayIndex = displayIndex;
            this.dgvDeudas.Columns[CAMPO_SALDODEUDA].DefaultCellStyle.Format = "N2";
            this.dgvDeudas.Columns[CAMPO_SALDODEUDA].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvDeudas.Columns[CAMPO_SALDODEUDA].Visible = true;
            displayIndex++;

            this.dgvDeudas.Columns[CAMPO_SALDOEQUIVALENTEDOLARES].HeaderText = "Saldo Equiv. U$S";
            this.dgvDeudas.Columns[CAMPO_SALDOEQUIVALENTEDOLARES].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDeudas.Columns[CAMPO_SALDOEQUIVALENTEDOLARES].Width = 130;
            this.dgvDeudas.Columns[CAMPO_SALDOEQUIVALENTEDOLARES].DisplayIndex = displayIndex;
            this.dgvDeudas.Columns[CAMPO_SALDOEQUIVALENTEDOLARES].DefaultCellStyle.Format = "N2";
            this.dgvDeudas.Columns[CAMPO_SALDOEQUIVALENTEDOLARES].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvDeudas.Columns[CAMPO_SALDOEQUIVALENTEDOLARES].Visible = true;
            displayIndex++;

            #region Columna Ver Detalles
            DataGridViewCellStyle cStyle = new DataGridViewCellStyle();
            cStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cStyle.ForeColor = Color.Green;
            cStyle.Font = new Font("Arial", 9.5F, FontStyle.Bold, GraphicsUnit.Pixel);

            DataGridViewButtonColumn showDetails = new DataGridViewButtonColumn();
            showDetails.HeaderText = "Detalles";
            showDetails.Text = "Ver";
            showDetails.UseColumnTextForButtonValue = true;
            showDetails.DefaultCellStyle = cStyle;
            showDetails.ToolTipText = "Presione para ver los detalles asociados";
            showDetails.Width = 60;
            showDetails.Name = CAMPO_VERDETALLES;
            dgvDeudas.Columns.Insert(0, showDetails);
            displayIndex++;
            #endregion Columna Ver Detalles

            #region Columna Texto Notificacion
            DataGridViewButtonColumn showMailBody = new DataGridViewButtonColumn();
            showMailBody.HeaderText = "Acción";
            showMailBody.Text = "Enviar";
            showMailBody.UseColumnTextForButtonValue = true;
            showMailBody.DefaultCellStyle = cStyle;
            showMailBody.ToolTipText = "Presione para ver el texto de la notificación que será enviada al cliente";
            showMailBody.Width = 120;
            showMailBody.Name = CAMPO_VERTEXTONOTIF;
            dgvDeudas.Columns.Insert(displayIndex, showMailBody);
            displayIndex++;
            #endregion Columna Texto Notificacion

            //DataGridViewCheckBoxColumn doWork = new DataGridViewCheckBoxColumn();
            //doWork.HeaderText = "Seleccionar";
            //doWork.FalseValue = false;
            //doWork.TrueValue = true;
            //doWork.ReadOnly = false;
            //doWork.Width = 80;
            //doWork.Name = CAMPO_SELECCIONAR;
            //dgvDeudas.Columns.Insert(0, doWork);

            this.lblRegistrosInfo.Text = dgvDeudas.RowCount.ToString() + " clientes con deudas encontrados.";

            //if (this.rbMarcas.Checked)
            //{
            //    dgvDeudas.Columns[CAMPO_COTIZACIONCABID].Visible = true;
            //    dgvDeudas.Columns[CAMPO_COTIZACIONCABID].DisplayIndex = displayIndex;
            //    dgvDeudas.Columns[CAMPO_COTIZACIONCABID].HeaderText = "Cotización ID";
            //    dgvDeudas.Columns[CAMPO_COTIZACIONCABID].Width = 90;
            //    displayIndex++;

            //    this.dgvDeudas.Columns[CAMPO_ERROR].Visible = mostrarError;
            //    this.dgvDeudas.Columns[CAMPO_ERROR].DisplayIndex = displayIndex;
            //    this.dgvDeudas.Columns[CAMPO_ERROR].HeaderText = "Resultado";
            //    this.dgvDeudas.Columns[CAMPO_ERROR].Width = 300;
            //    this.dgvDeudas.Columns[CAMPO_ERROR].ReadOnly = false;
            //    displayIndex++;

            //    dgvDeudas.Columns[CAMPO_SERIEAUX].Visible = true;
            //    dgvDeudas.Columns[CAMPO_SERIEAUX].HeaderText = "Serie";
            //    dgvDeudas.Columns[CAMPO_SERIEAUX].DisplayIndex = displayIndex;
            //    dgvDeudas.Columns[CAMPO_SERIEAUX].ReadOnly = false;
            //    dgvDeudas.Columns[CAMPO_SERIEAUX].Width = 50;
            //    dgvDeudas.Columns[CAMPO_SERIEAUX].ToolTipText = "Ingrese la serie a ser asignada manualmente.";
            //    displayIndex++;

            //    dgvDeudas.Columns[CAMPO_NROPRESUPUESTOAUX].Visible = true;
            //    dgvDeudas.Columns[CAMPO_NROPRESUPUESTOAUX].HeaderText = "Nro. Presup.";
            //    dgvDeudas.Columns[CAMPO_NROPRESUPUESTOAUX].DisplayIndex = displayIndex;
            //    dgvDeudas.Columns[CAMPO_NROPRESUPUESTOAUX].ReadOnly = false;
            //    dgvDeudas.Columns[CAMPO_NROPRESUPUESTOAUX].Width = 95;
            //    dgvDeudas.Columns[CAMPO_NROPRESUPUESTOAUX].ToolTipText = "Ingrese la numeración a ser asignada manualmente.";
            //    displayIndex++;

            //    dgvDeudas.Columns[CAMPO_FECGENERACIONAUX].Visible = true;
            //    dgvDeudas.Columns[CAMPO_FECGENERACIONAUX].HeaderText = "Fecha Gen.";
            //    dgvDeudas.Columns[CAMPO_FECGENERACIONAUX].DisplayIndex = displayIndex;
            //    dgvDeudas.Columns[CAMPO_FECGENERACIONAUX].ReadOnly = false;
            //    dgvDeudas.Columns[CAMPO_FECGENERACIONAUX].Width = 100;
            //    dgvDeudas.Columns[CAMPO_FECGENERACIONAUX].ToolTipText = "Ingrese la fecha de generación a ser asignada manualmente.";
            //    displayIndex++;

            //    dgvDeudas.Columns[CAMPO_DENOMINACIONMARCA].Visible = true;
            //    dgvDeudas.Columns[CAMPO_DENOMINACIONMARCA].DisplayIndex = displayIndex;
            //    dgvDeudas.Columns[CAMPO_DENOMINACIONMARCA].HeaderText = "Denominación";
            //    dgvDeudas.Columns[CAMPO_DENOMINACIONMARCA].Width = 300;
            //    displayIndex++;
            //}

            //if (this.rbHI.Checked)
            //{
            //    this.dgvDeudas.Columns[CAMPO_ERROR].Visible = mostrarError;
            //    this.dgvDeudas.Columns[CAMPO_ERROR].DisplayIndex = displayIndex;
            //    this.dgvDeudas.Columns[CAMPO_ERROR].HeaderText = "Resultado";
            //    this.dgvDeudas.Columns[CAMPO_ERROR].Width = 300;
            //    this.dgvDeudas.Columns[CAMPO_ERROR].ReadOnly = false;
            //    displayIndex++;

            //    dgvDeudas.Columns[CAMPO_SERIEAUX].Visible = true;
            //    dgvDeudas.Columns[CAMPO_SERIEAUX].HeaderText = "Serie";
            //    dgvDeudas.Columns[CAMPO_SERIEAUX].DisplayIndex = displayIndex;
            //    dgvDeudas.Columns[CAMPO_SERIEAUX].ReadOnly = false;
            //    dgvDeudas.Columns[CAMPO_SERIEAUX].Width = 50;
            //    dgvDeudas.Columns[CAMPO_SERIEAUX].ToolTipText = "Ingrese la serie a ser asignada manualmente.";
            //    displayIndex++;

            //    dgvDeudas.Columns[CAMPO_NROPRESUPUESTOAUX].Visible = true;
            //    dgvDeudas.Columns[CAMPO_NROPRESUPUESTOAUX].HeaderText = "Nro. Presup.";
            //    dgvDeudas.Columns[CAMPO_NROPRESUPUESTOAUX].DisplayIndex = displayIndex;
            //    dgvDeudas.Columns[CAMPO_NROPRESUPUESTOAUX].ReadOnly = false;
            //    dgvDeudas.Columns[CAMPO_NROPRESUPUESTOAUX].Width = 95;
            //    dgvDeudas.Columns[CAMPO_NROPRESUPUESTOAUX].ToolTipText = "Ingrese la numeración a ser asignada manualmente.";
            //    displayIndex++;

            //    dgvDeudas.Columns[CAMPO_FECGENERACIONAUX].Visible = true;
            //    dgvDeudas.Columns[CAMPO_FECGENERACIONAUX].HeaderText = "Fecha Gen.";
            //    dgvDeudas.Columns[CAMPO_FECGENERACIONAUX].DisplayIndex = displayIndex;
            //    dgvDeudas.Columns[CAMPO_FECGENERACIONAUX].ReadOnly = false;
            //    dgvDeudas.Columns[CAMPO_FECGENERACIONAUX].Width = 100;
            //    dgvDeudas.Columns[CAMPO_FECGENERACIONAUX].ToolTipText = "Ingrese la fecha de generación a ser asignada manualmente.";
            //    displayIndex++;
                
            //}

            //dgvDeudas.Columns[CAMPO_CLIENTENOMBRE].Visible = true;
            //dgvDeudas.Columns[CAMPO_CLIENTENOMBRE].DisplayIndex = displayIndex;
            //dgvDeudas.Columns[CAMPO_CLIENTENOMBRE].HeaderText = "Nombre o Razón Social";
            //dgvDeudas.Columns[CAMPO_CLIENTENOMBRE].Width = 300;
            //displayIndex++;

            //dgvDeudas.Columns[CAMPO_IDIOMA].Visible = true;
            //dgvDeudas.Columns[CAMPO_IDIOMA].DisplayIndex = displayIndex;
            //dgvDeudas.Columns[CAMPO_IDIOMA].HeaderText = "Idioma";
            //dgvDeudas.Columns[CAMPO_IDIOMA].Width = 300;
            //displayIndex++;

            //dgvDeudas.Columns[CAMPO_TRAMITEDESCRIP].Visible = true;
            //dgvDeudas.Columns[CAMPO_TRAMITEDESCRIP].DisplayIndex = displayIndex;
            //dgvDeudas.Columns[CAMPO_TRAMITEDESCRIP].HeaderText = "Trámite";
            //dgvDeudas.Columns[CAMPO_TRAMITEDESCRIP].Width = 200;
            //displayIndex++;

            //dgvDeudas.Columns[CAMPO_HI].Visible = true;
            //dgvDeudas.Columns[CAMPO_HI].DisplayIndex = displayIndex;
            //dgvDeudas.Columns[CAMPO_HI].HeaderText = "HI";
            //displayIndex++;

            //if (this.rbMarcas.Checked)
            //{
            //    dgvDeudas.Columns[CAMPO_ACTA].Visible = true;
            //    dgvDeudas.Columns[CAMPO_ACTA].DisplayIndex = displayIndex;
            //    dgvDeudas.Columns[CAMPO_ACTA].HeaderText = "Acta";
            //    displayIndex++;

            //    dgvDeudas.Columns[CAMPO_PRESENTACIONFECHA].Visible = true;
            //    dgvDeudas.Columns[CAMPO_PRESENTACIONFECHA].DisplayIndex = displayIndex;
            //    dgvDeudas.Columns[CAMPO_PRESENTACIONFECHA].Width = 90;
            //    dgvDeudas.Columns[CAMPO_PRESENTACIONFECHA].HeaderText = "Pres. Fec.";
            //    displayIndex++;

            //    dgvDeudas.Columns[CAMPO_EXPEDIENTEID].Visible = true;
            //    dgvDeudas.Columns[CAMPO_EXPEDIENTEID].DisplayIndex = displayIndex;
            //    dgvDeudas.Columns[CAMPO_EXPEDIENTEID].HeaderText = "Expediente";
            //    displayIndex++;
            //}

            //dgvDeudas.Columns[CAMPO_CLIENTEID].Visible = true;
            //dgvDeudas.Columns[CAMPO_CLIENTEID].DisplayIndex = displayIndex;
            //dgvDeudas.Columns[CAMPO_CLIENTEID].HeaderText = "ID Cliente";
            //displayIndex++;

            //dgvDeudas.Columns[CAMPO_ORDENTRABAJOID].Visible = true;
            //dgvDeudas.Columns[CAMPO_ORDENTRABAJOID].DisplayIndex = displayIndex;
            //dgvDeudas.Columns[CAMPO_ORDENTRABAJOID].HeaderText = "OT ID";
            //displayIndex++;

            //dgvDeudas.Columns[CAMPO_NROPRESUPUESTO].Visible = true;
            //dgvDeudas.Columns[CAMPO_NROPRESUPUESTO].DisplayIndex = displayIndex;
            //dgvDeudas.Columns[CAMPO_NROPRESUPUESTO].HeaderText = "Presup N°";
            //dgvDeudas.Columns[CAMPO_NROPRESUPUESTO].Width = 95;
            //displayIndex++;

            //if (this.rbMarcas.Checked)
            //{
            //    dgvDeudas.Columns[CAMPO_FECHACOTIBCAB].Visible = true;
            //    dgvDeudas.Columns[CAMPO_FECHACOTIBCAB].DisplayIndex = displayIndex;
            //    dgvDeudas.Columns[CAMPO_FECHACOTIBCAB].Width = 90;
            //    dgvDeudas.Columns[CAMPO_FECHACOTIBCAB].HeaderText = "Cotiz. Fec.";
            //    displayIndex++;
            //}

            ////dgvCotizaciones.Columns[CAMPO_GENERADO].Visible = true;
            ////dgvCotizaciones.Columns[CAMPO_GENERADO].DisplayIndex = displayIndex;
            ////dgvCotizaciones.Columns[CAMPO_GENERADO].HeaderText = "Generado";
            ////displayIndex++;

            //DataGridViewCheckBoxColumn colGenerado = new DataGridViewCheckBoxColumn();
            //colGenerado.DataPropertyName = CAMPO_GENERADO;
            //colGenerado.HeaderText = "Generado";
            //colGenerado.FalseValue = false;
            //colGenerado.TrueValue = true;
            //colGenerado.ReadOnly = true;
            //dgvDeudas.Columns.Insert(displayIndex, colGenerado);
            //displayIndex++;

            //if (this.rbHI.Checked)
            //{
            //    //#region Columna Nro. Presupuesto Aux
            //    //dgvCotizaciones.Columns.Remove(CAMPO_NROPRESUPUESTOAUX);

            //    //DataGridViewColumn nroPresupAux = new DataGridViewColumn();
            //    //nroPresupAux.Visible = true;
            //    //nroPresupAux.HeaderText = "Nro. Presup.";
            //    //nroPresupAux.ReadOnly = false;
            //    //nroPresupAux.Width = 95;
            //    //nroPresupAux.ToolTipText = "Ingrese la numeración a ser asignada manualmente.";
            //    //nroPresupAux.CellTemplate = new DataGridViewTextBoxCell();
            //    //nroPresupAux.DataPropertyName = CAMPO_NROPRESUPUESTOAUX;
            //    //dgvCotizaciones.Columns.Insert(0, nroPresupAux);
            //    //#endregion Columna Nro. Presupuesto Aux

            //    //#region Columna Serie Aux
            //    //dgvCotizaciones.Columns.Remove(CAMPO_SERIEAUX);

            //    //DataGridViewColumn serieAux = new DataGridViewColumn();
            //    //serieAux.Visible = true;
            //    //serieAux.HeaderText = "Serie";
            //    //serieAux.ReadOnly = false;
            //    //serieAux.Width = 50;
            //    //serieAux.ToolTipText = "Ingrese la serie a ser asignada manualmente.";
            //    //serieAux.CellTemplate = new DataGridViewTextBoxCell();
            //    //serieAux.DataPropertyName = CAMPO_SERIEAUX;
            //    //dgvCotizaciones.Columns.Insert(0, serieAux);
            //    //#endregion Columna Serie Aux

            //    #region Columna Ver Detalles
            //    DataGridViewCellStyle cStyle = new DataGridViewCellStyle();
            //    cStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    cStyle.ForeColor = Color.Green;
            //    cStyle.Font = new Font("Arial", 9.5F, FontStyle.Bold, GraphicsUnit.Pixel);

            //    DataGridViewButtonColumn showDetails = new DataGridViewButtonColumn();
            //    showDetails.HeaderText = "Detalles";
            //    showDetails.Text = "Ver";
            //    showDetails.UseColumnTextForButtonValue = true;
            //    showDetails.DefaultCellStyle = cStyle;
            //    showDetails.ToolTipText = "Presione para ver los detalles asociados";
            //    showDetails.Width = 60;
            //    showDetails.Name = CAMPO_VERDETALLES;
            //    dgvDeudas.Columns.Insert(0, showDetails);
            //    #endregion Columna Ver Detalles
            //}

            //DataGridViewCheckBoxColumn doWork = new DataGridViewCheckBoxColumn();
            //doWork.HeaderText = "Seleccionar";
            //doWork.FalseValue = false;
            //doWork.TrueValue = true;
            //doWork.ReadOnly = false;
            //doWork.Width = 80;
            //doWork.Name = CAMPO_SELECCIONAR;
            //dgvDeudas.Columns.Insert(0, doWork);

            
                        
            //this.lblRegistrosInfo.Text = dgvDeudas.RowCount.ToString() + " cotizaciones encontradas.";
        }

        private bool esEnTramite(int ExpedientePadreID)//, string Origen)
        {
            bool Result = false;

            ExpeRegistro expeReg = (from regRenAnt in this.DBContext.MarcaRegRen
                                    join expe in this.DBContext.Expediente
                                      on regRenAnt.ID equals expe.MarcaRegRenID
                                    select new ExpeRegistro
                                    {
                                        RegistroNro = regRenAnt.RegistroNro,
                                        ExpedienteID = expe.ID
                                    })
                                    .FirstOrDefault(a => a.ExpedienteID == ExpedientePadreID);

            if ((expeReg != null) && (expeReg.RegistroNro == null))
                Result = true;

            return Result;
        }

        

        private string GetFilterSQL()
        {
            string Result = "";
            if (this.tSBCliente.KeyMember != "")
            {
                Result = " (ClienteID = " + this.tSBCliente.KeyMember + ")";
            }

            

            return Result;
        }

        private int GetCantidadSeleccionados()
        {
            int Result = 0;
            foreach (DataGridViewRow row in this.dgvDeudas.Rows)
            {
                if ((row.Cells[CAMPO_SELECCIONAR].Value != null) && ((bool)row.Cells[CAMPO_SELECCIONAR].Value))
                    Result++;
            }

            return Result;
        }

        

        private string GetFilter(string csv, string clave)
        {
            const string DEFAULT_STRING_PATTERN = "( {0} = {1} )";

            string Result = "";

            string[] listaValores = csv.Split(',');

            if (listaValores.Length > 1)
            {
                string gFiltro = "";
                foreach (string e in listaValores)
                {
                    if (gFiltro != "")
                        gFiltro += " OR ";

                    gFiltro += String.Format(DEFAULT_STRING_PATTERN, clave, e);
                }
                Result = " (" + gFiltro + ") ";

            }
            return Result;
        }

        private List<GetCotizacionesParaPresupuestos_Result> GetListaCabeceras()
        {
            List<GetCotizacionesParaPresupuestos_Result> Result = new List<GetCotizacionesParaPresupuestos_Result>();

            if (this.rbMarcas.Checked)
            {
                foreach (DataGridViewRow row in this.dgvDeudas.Rows)
                {
                    if ((row.Cells[CAMPO_SELECCIONAR].Value != null) && ((bool)row.Cells[CAMPO_SELECCIONAR].Value))
                    {
                        int ExpedienteID = (int)row.Cells[CAMPO_EXPEDIENTEID].Value;
                        int CotizacionCabID = (int)row.Cells[CAMPO_COTIZACIONCABID].Value;
                        
                        GetCotizacionesParaPresupuestos_Result item = new GetCotizacionesParaPresupuestos_Result();
                        //item = this.listaCoti.First(a => a.ExpedienteID == ExpedienteID);
                        item = this.listaCoti.First(a => a.ExpedienteID == ExpedienteID && a.CotizacionCabID == CotizacionCabID);
                        if (row.Cells[CAMPO_NROPRESUPUESTOAUX].Value != null)
                            item.NroPresupuestoAux =  (int)row.Cells[CAMPO_NROPRESUPUESTOAUX].Value;
                        if (row.Cells[CAMPO_SERIEAUX].Value != null)
                            item.SerieAux = row.Cells[CAMPO_SERIEAUX].Value.ToString();
                        if (row.Cells[CAMPO_FECGENERACIONAUX].Value != null)
                            item.FechaGeneracionAux = Convert.ToDateTime(row.Cells[CAMPO_FECGENERACIONAUX].Value.ToString());

                        Result.Add(item);
                    }
                }
            }
            else if (this.rbHI.Checked)
            {
                foreach (DataGridViewRow row in this.dgvDeudas.Rows)
                {
                    if ((row.Cells[CAMPO_SELECCIONAR].Value != null) && ((bool)row.Cells[CAMPO_SELECCIONAR].Value))
                    {
                        if (row.Cells[CAMPO_ORDENTRABAJOID].Value != null)
                        {
                            int OrdenTrabajoID = (int)row.Cells[CAMPO_ORDENTRABAJOID].Value;

                            GetCotizacionesParaPresupuestos_Result item = new GetCotizacionesParaPresupuestos_Result();
                            item = this.listaCoti.First(a => a.OrdenTrabajoID == OrdenTrabajoID);
                            
                            if (row.Cells[CAMPO_NROPRESUPUESTOAUX].Value != null)
                                item.NroPresupuestoAux =  (int)row.Cells[CAMPO_NROPRESUPUESTOAUX].Value;
                            if (row.Cells[CAMPO_SERIEAUX].Value != null)
                                item.SerieAux = row.Cells[CAMPO_SERIEAUX].Value.ToString();
                            if (row.Cells[CAMPO_FECGENERACIONAUX].Value != null)
                                item.FechaGeneracionAux = Convert.ToDateTime(row.Cells[CAMPO_FECGENERACIONAUX].Value.ToString());

                            Result.Add(item);
                        }
                        else
                        {
                            int ExpedienteID = (int)row.Cells[CAMPO_EXPEDIENTEID].Value;
                            int CotizacionCabID = (int)row.Cells[CAMPO_COTIZACIONCABID].Value;
                            
                            GetCotizacionesParaPresupuestos_Result item = new GetCotizacionesParaPresupuestos_Result();
                            //item = this.listaCoti.First(a => a.ExpedienteID == ExpedienteID);
                            item = this.listaCoti.First(a => a.ExpedienteID == ExpedienteID && a.CotizacionCabID == CotizacionCabID);
                            
                            if (row.Cells[CAMPO_NROPRESUPUESTOAUX].Value != null)
                                item.NroPresupuestoAux =  (int)row.Cells[CAMPO_NROPRESUPUESTOAUX].Value;
                            if (row.Cells[CAMPO_SERIEAUX].Value != null)
                                item.SerieAux = row.Cells[CAMPO_SERIEAUX].Value.ToString();
                            if (row.Cells[CAMPO_FECGENERACIONAUX].Value != null)
                                item.FechaGeneracionAux = Convert.ToDateTime(row.Cells[CAMPO_FECGENERACIONAUX].Value.ToString());

                            Result.Add(item);
                        }
                    }
                }
            }

            return Result;
        }

        private TExpedienteDet GetPropietarioAnterior( int ExpedienteID, TExpedienteDet str_Expediente, BerkeDBEntities context) 
		{

            List<ExpedienteCampo> ListExpedienteCampo = context.ExpedienteCampo.Where(a => a.ExpedienteID == ExpedienteID).ToList();

			foreach (ExpedienteCampo item in ListExpedienteCampo)
			{
				if ( item.Campo.ToUpper() == "PROPIETARIO ANTERIOR" ) 
				{
					str_Expediente.propietarioAnterior     =  item.Valor;
				}

				if ( item.Campo.ToUpper() == "PROPIETARIO ANTERIOR_DIR" ) 
				{
					str_Expediente.propietarioAntDireccion =  item.Valor;
				}

				if ( item.Campo.ToUpper() == "FUSIONADO CON" ) 
				{
					str_Expediente.nombreotrospropietarios =  item.Valor;
				}

			}
			
				
			return str_Expediente;
		}

        #region Buscar Denominacion de la Marca 

        private TExpedienteDet getDatosMarca(int ExpedienteID, TExpedienteDet str_Expediente, BerkeDBEntities context) 
		{
            if (ExpedienteID != -1)
            {
                Expediente expe = context.Expediente.First(a => a.ID == ExpedienteID);
                Marca marca = context.Marca.First(a => a.ID == expe.MarcaID);
                //str_Expediente.marcaDenominacion = marca.Dat.Denominacion.AsString;
                str_Expediente.ClaseNro = getClaseNro(marca.ClaseID, context);
                str_Expediente.ClaseTipo = getClaseTipo(marca.ClaseID, context);
            }
            return str_Expediente;

		}
		#endregion


		#region Buscar Clase
        private int getClaseNro(int ClaseID, BerkeDBEntities context)
		{
            return context.Clase.First(a => a.ID == ClaseID).Nro;
		}
		#endregion


		#region Buscar ClaseTipo
        private string getClaseTipo(int ClaseID, BerkeDBEntities context)
		{
            Clase clase = context.Clase.First(a => a.ID == ClaseID);
            return context.ClaseTipo.First(a => a.ID == clase.ClaseTipoID).Descrip;
		}
		#endregion

        #region Traducir Clase
		private string traducirClase(string clase, int idiomaID)
		{   

			string tr ="";
			
            List<Traduccion> ListaTraduccion = this.DBContext.Traduccion.Where(a => a.IdiomaID == idiomaID && a.Texto == clase).ToList();

			if ( ListaTraduccion.Count > 0 ) {
			
				tr = ListaTraduccion.First().Traducido;
			}

			return tr;
		}

		#endregion

        private TExpedienteCab getPartes(int ExpedienteID, TExpedienteCab str_ExpedienteCab, BerkeDBEntities context)
        {
            List<op_oposicion> opo = context.op_oposicion.Where(a => a.ID == ExpedienteID).ToList();

            if (opo.Count > 0)
            {
                str_ExpedienteCab.ParteNombre = opo.First().ParteNombre;
                str_ExpedienteCab.ContraparteNombre = opo.First().ContraparteNombre;
            }
            return str_ExpedienteCab;
        }

        private TExpedienteDet getPropietarioActual(int ExpedienteID, TExpedienteDet str_Expediente, BerkeDBEntities context)
        {

            string w_domicilio = "";
            string w_nombprop = "";

            List<ExpedienteXPoder> ListaExpedienteXPoder = context.ExpedienteXPoder.Where(a => a.ExpedienteID == ExpedienteID).ToList();

            if (ListaExpedienteXPoder.Count > 0)
            {
                int PoderID = ListaExpedienteXPoder.First().PoderID.HasValue && ListaExpedienteXPoder.First().PoderID.Value > 0 ? ListaExpedienteXPoder.First().PoderID.Value : -1;
                List<Poder> poder = context.Poder.Where(a => a.ID == PoderID).ToList();

                if (poder.Count > 0)
                {
                    /* Domicilio del poder */
                    w_domicilio = poder.First().Domicilio;

                    /* Buscar el id del propietario */
                    int PropietarioXPoderID = poder.First().ID;
                    List<PropietarioXPoder> ListaPropietarioXPoder = context.PropietarioXPoder.Where(a => a.PoderID == PropietarioXPoderID).ToList();

                    if (ListaPropietarioXPoder.Count > 0)
                    {
                        int PropietarioID = ListaPropietarioXPoder.First().PropietarioID;
                        List<Propietario> ListaPropietario = context.Propietario.Where(a => a.ID == PropietarioID).ToList();

                        if (ListaPropietario.Count > 0)
                        {
                            w_nombprop = ListaPropietario.First().Nombre;
                        }
                    }

                }

            }
            else
            {
                List<ExpedienteXPropietario> ListaExpedienteXPropietario = context.ExpedienteXPropietario.Where(a => a.ExpedienteID == ExpedienteID).ToList();

                if (ListaExpedienteXPropietario.Count > 0)
                {
                    int PropietarioID = ListaExpedienteXPropietario.First().PropietarioID;
                    List<Propietario> ListaPropietario = context.Propietario.Where(a => a.ID == PropietarioID).ToList();

                    if (ListaPropietario.Count > 0)
                    {
                        w_domicilio = ListaPropietario.First().Direccion;
                        w_nombprop = ListaPropietario.First().Nombre;
                    }
                }


            }


            str_Expediente.propietarioActual = w_nombprop;
            str_Expediente.propietarioActDireccion = w_domicilio;

            return str_Expediente;
        }

        #region Buscar datos de la Marca (Registro numero y año)

        private TExpedienteDet getDatosMarcaRegRen(int ExpedienteID, TExpedienteDet str_Expediente, BerkeDBEntities context)
        {
            List<Expediente> ListaExpediente = context.Expediente.Where(a => a.ID == ExpedienteID).ToList();
            if (ListaExpediente.Count > 0)
            {
                int MarcaID = ListaExpediente.First().MarcaID.Value;
                Marca mar = context.Marca.First(a => a.ID == MarcaID);

                int MarcaRegRenID = mar.MarcaRegRenID.Value;
                MarcaRegRen mrr = context.MarcaRegRen.First(a => a.ID == MarcaRegRenID);

                str_Expediente.RegistroNro = mrr.RegistroNro.HasValue ? mrr.RegistroNro.Value : 0;
                str_Expediente.RegistroAnio = mrr.RegistroAnio.HasValue ? mrr.RegistroAnio.Value : 0;
                str_Expediente.FechaConcesion = mrr.ConcesionFecha.HasValue ? mrr.ConcesionFecha.Value.ToShortDateString() : "";
            }
            return str_Expediente;
        }
        #endregion

        #region Traducir fecha
        public string traducirFecha(string fecha, int idiomaID)
        {

            string f = "";
            int dd = 0; int mm = 0; int aa = 0;

            DateTime fec = DateTime.Parse(fecha.ToString());

            dd = fec.Day; mm = fec.Month; aa = fec.Year;

            List<Mes> mes = this.DBContext.Mes.Where(a => a.ididioma == idiomaID && a.Orden == mm).ToList();

            if (idiomaID == IDIOMA_INGLES) /*ingles*/
            {
                f = mes.First().Mes1 + " " + dd.ToString() + ", " + aa.ToString();
            }

            if (idiomaID == IDIOMA_ESPANOL) /*español*/
            {
                f = dd.ToString() + " de " + mes.First().Mes1 + " de " + aa.ToString();
            }

            if (idiomaID == 3) /*aleman*/
            {
                f = dd.ToString() + ". " + mes.First().Mes1 + " " + aa.ToString();
            }

            if (idiomaID == 4) /*frances*/
            {
                f = dd.ToString() + " " + mes.First().Mes1 + " " + aa.ToString();
            }


            return f;
        }

        #endregion

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


            string[] words0 = {"", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine "};
            string[] words1 = {"Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen "};
            string[] words2 = {"Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety "};
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

        #region Formatear marcas XML
        private string FormatearMarcasXML(string bruto)
        {
            /*
            <p>: <w:r><w:t>
            </p>: </w:t></w:r>
            <b>: <w:r><w:rPr><w:b/></w:rPr><w:t>
            </b>: </w:t></w:r>
             */
            string Formateado = "";

            //Reemplazar inicio de texto normal
            Formateado = bruto.Replace("<p>", "<w:r><w:t>");
            //Reemplazar fin de texto normal
            Formateado = Formateado.Replace("</p>", "</w:t></w:r>");
            //Reemplazar inicio de texto en negritas
            Formateado = Formateado.Replace("<b>", "<w:r><w:rPr><w:b/></w:rPr><w:t>");
            //Reemplazar fin de texto en negritas
            Formateado = Formateado.Replace("</b>", "</w:t></w:r>");

            return Formateado;
        }
        #endregion Formatear marcas XML

        #endregion Métodos de Apoyo

        #region Picks
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

        #region Tramite
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
                fPickTramite.LabelCampoDescrip = "Nombre";
                fPickTramite.NombreCampo = "Trámite";
                fPickTramite.PermitirFiltroNulo = false;
            }
            fPickTramite.MostrarFiltro();
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
        }
        #endregion Tramite

        #region PickCiudad
        private void tSBCiudad_AceptarClick(object sender, EventArgs e)
        {
            if (fPickCiudad == null)
            {
                fPickCiudad = new frmPickBase();
                fPickCiudad.AceptarFiltrarClick += fPickCiudad_AceptarFiltrarClick;
                fPickCiudad.FiltrarClick += fPickCiudad_FiltrarClick;
                fPickCiudad.Titulo = "Elegir Ciudad";
                fPickCiudad.CampoIDNombre = "idciudad";
                fPickCiudad.CampoDescripNombre = "nomciudad";
                fPickCiudad.LabelCampoID = "ID";
                fPickCiudad.LabelCampoDescrip = "Descripción";
                fPickCiudad.NombreCampo = "Ciudad";
                //fPickCiudad.ShowDialog();

            }
            fPickCiudad.MostrarFiltro();
        }

        private void fPickCiudad_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickCiudad != null)
            {
                fPickCiudad.LoadData<CCiudad>(this.DBContext.CCiudad, fPickCiudad.GetWhereString());
            }
        }

        private void fPickCiudad_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBCiudad.DisplayMember = fPickCiudad.ValorDescrip;
            this.tSBCiudad.KeyMember = fPickCiudad.ValorID;

            fPickCiudad.Close();
            fPickCiudad.Dispose();
            //fPickCiudad = null;
        }
        #endregion PickCiudad

        #region PickPais
        private void tSBPais_AceptarClick(object sender, EventArgs e)
        {
            if (fPickPais == null)
            {
                fPickPais = new frmPickBase();
                //fPickPais.init("idpais", "descrip");
                fPickPais.AceptarFiltrarClick += f_AceptarFiltrarClickPais;
                fPickPais.FiltrarClick += fPickPais_FiltrarClick;
                fPickPais.Titulo = "Elegir País";
                fPickPais.CampoIDNombre = "idpais";
                fPickPais.CampoDescripNombre = "descrip";
                fPickPais.LabelCampoID = "ID";
                fPickPais.LabelCampoDescrip = "Descripción";
                fPickPais.NombreCampo = "País";
            }
            fPickPais.MostrarFiltro();


        }

        private void fPickPais_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickPais != null)
            {
                fPickPais.LoadData<CPais>(this.DBContext.CPais, fPickPais.GetWhereString());
            }
        }

        private void f_AceptarFiltrarClickPais(object sender, EventArgs e)
        {
            this.tSBPais.DisplayMember = fPickPais.ValorDescrip;
            this.tSBPais.KeyMember = fPickPais.ValorID;

            fPickPais.Close();
            fPickPais.Dispose();
        }
        #endregion PickPais        

        #region Area
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
        #endregion Area

        #region Unidad de Negocio
        private void tSBUnidadNegocio_AceptarClick(object sender, EventArgs e)
        {
            if (fPickUnidadNegocio == null)
            {
                fPickUnidadNegocio = new frmPickBase();
                fPickUnidadNegocio.AceptarFiltrarClick += fPickUnidadNegocio_AceptarFiltrarClick;
                fPickUnidadNegocio.FiltrarClick += fPickUnidadNegocio_FiltrarClick;
                fPickUnidadNegocio.Titulo = "Elegir Unidad de Negocio";
                fPickUnidadNegocio.CampoIDNombre = "un_unidadnegocioid";
                fPickUnidadNegocio.CampoDescripNombre = "un_descripcion";
                fPickUnidadNegocio.LabelCampoID = "ID";
                fPickUnidadNegocio.LabelCampoDescrip = "Descripción";
                fPickUnidadNegocio.NombreCampo = "Unid. Negocio";
                fPickUnidadNegocio.PermitirFiltroNulo = true;
            }
            fPickUnidadNegocio.MostrarFiltro();
            fPickUnidadNegocio_FiltrarClick(sender, e);
        }

        private void fPickUnidadNegocio_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickUnidadNegocio != null)
            {
                fPickUnidadNegocio.LoadData<un_unidadnegocio>(this.DBContext.un_unidadnegocio, fPickUnidadNegocio.GetWhereString());
            }
        }

        private void fPickUnidadNegocio_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBUnidadNegocio.DisplayMember = fPickUnidadNegocio.ValorDescrip;
            this.tSBUnidadNegocio.KeyMember = fPickUnidadNegocio.ValorID;

            fPickUnidadNegocio.Close();
            fPickUnidadNegocio.Dispose();
        }
        #endregion Unidad de Negocio
        #endregion Picks

        #region Manejo de Controles
        private void btnVerDocumentos_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(@w_directorio_trabajo);
            if (System.IO.Directory.Exists(@w_directorio_trabajo))
            {
                string path = "file://" + @w_directorio_trabajo;
                Link.Open(@path);
            }

        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbCtrlGenPresup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tbCtrlGenReclamos.SelectedIndex == 0)
            {
                this.btnCancelar.Enabled = true;
                this.btnAtras.Enabled = false;
                this.btnSiguiente.Enabled = true;
                this.btnFinalizar.Enabled = false;
            }
            else if (this.tbCtrlGenReclamos.SelectedIndex == this.CantTabs - 1)
            {
                this.btnCancelar.Enabled = true;
                this.btnAtras.Enabled = true;
                this.btnSiguiente.Enabled = false;
                this.btnFinalizar.Enabled = true;
            }
            else if (this.tbCtrlGenReclamos.SelectedIndex < this.CantTabs - 1)
            {
                this.btnCancelar.Enabled = true;
                this.btnAtras.Enabled = true;
                this.btnSiguiente.Enabled = true;
                this.btnFinalizar.Enabled = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            string caption = "Cancelación de Generación de Presupuestos";
            string message = "Se cancelará la operación de Generación de Presupuestos ¿Está seguro?";

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
                    this.Close();
                }
                
            }
        }

        private void DialogHandlerGeneracion(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    #region Configuraciones del ProgressBar
                    this.pbarGeneracion.Value = 0;
                    this.pbarGeneracion.Maximum = 0;
                    this.lblRegistrosInfo.Text = "Iniciando...";
                    this.MostrarProgressBar = true;
                    #endregion Configuraciones del ProgressBar

                    #region Thread para Generación de Presupuestos
                    this.timer1.Start();
                    this.Lucifer = true;
                    //thr = new System.Threading.Thread(GenerarPresupuestos);
                    //thr.Start();
                    #endregion Thread para Generación de Presupuestos
                }
                else
                {
                    #region Configuraciones del ProgressBar
                    this.timer1.Stop();
                    this.Lucifer = false;
                    //this.CometFrequency = 0;
                    this.pbarGeneracion.Value = 0;
                    this.MostrarProgressBar = false;
                    #endregion Configuraciones del ProgressBar
                }
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            //Validaciones
            switch (this.tbCtrlGenReclamos.SelectedIndex)
            {
                case 0 :

                    //if (this.tSBCliente.KeyMember == "")
                    //{
                    //    MessageBox.Show("Debe especificar algún tipo de criterio obligatoriamente.",
                    //                    "Atención Requerida",
                    //                    MessageBoxButtons.OK,
                    //                    MessageBoxIcon.Exclamation);
                    //    return;
                    //}

                    string clienteId = this.tSBCliente.KeyMember.Trim();
                    this.FechaDesde = String.Empty;
                    this.FechaHasta = String.Empty;

                    this.FechaReclamarEn = ((this.cbReclamarEn.Text == null) || (this.cbReclamarEn.Text.Trim() == String.Empty)) ? String.Empty : System.DateTime.Now.AddDays(Convert.ToInt32(this.cbReclamarEn.Text)).ToShortDateString();

                    if (this.rbDeudasA.Checked)
                    {
                        if (this.cbDeudasA.Text.Trim() == String.Empty)
                        {
                            MessageBox.Show("Debe ingresar una cantidad de días para realizar la selección",
                                            "Atención Requerida",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Exclamation);
                            return;
                        }
                        this.FechaDesde = ORIGEN_DE_LOS_TIEMPOS;
                        this.FechaHasta = System.DateTime.Now.AddDays(Convert.ToInt32(this.cbDeudasA.Text) * -1).ToShortDateString();
                        
                    }
                    else if (this.rbRango.Checked)
                    {
                        if ((this.txtFechaDesde.Text != "") && (this.txtFechaHasta.Text == "") ||
                           (this.txtFechaDesde.Text == "") && (this.txtFechaHasta.Text != ""))
                        {
                            MessageBox.Show("Debe ingresar Fecha Desde y Fecha Hasta de Presentaciones.",
                                            "Atención Requerida",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Exclamation);
                            return;
                        }

                        DateTime FechaDesde, FechaHasta;
                        if (DateTime.TryParse(this.txtFechaDesde.Text, out FechaDesde) && DateTime.TryParse(this.txtFechaHasta.Text, out FechaHasta))
                        {
                            if (FechaDesde > FechaHasta)
                            {
                                MessageBox.Show("La Fecha Desde no puede ser superior a la Fecha Hasta.",
                                            "Atención Requerida",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Exclamation);
                                return;
                            }
                        }
                        this.FechaDesde = this.txtFechaDesde.Text;
                        this.FechaHasta = this.txtFechaHasta.Text;
                    }
                    
                    this.lblTitulo.Text = "Asistente para la Generación de Cartas de Reclamos - Selección";

                    decimal montoMinimo = this.txtMonto.Text.Trim() != String.Empty ? Convert.ToDecimal(this.txtMonto.Text.Trim()) : 0;

                    /*
                     var result = source
                                    .GroupBy(x => x.Currency)
                                    .Select(g => new {
                                        Currency = g.Key,
                                        Total = g.Sum(x => x.FeesCustom > 0 ? x.FeesCustom : x.FeesNormal)
                                    });
                     */

                    this.listaDeudas.Clear();
                    this.listaDeudas = this.GetListaDeudas(fechaDesde, fechaHasta, clienteId, 
                                        this.tSBTramite.KeyMember,
                                        this.txtHINro.Text, this.txtHIAnio.Text,
                                        this.txtActaNro.Text, this.txtActaAnho.Text,
                                        this.tSBCiudad.KeyMember, this.tSBPais.KeyMember,
                                        this.tSBAreaContab.KeyMember, this.tSBUnidadNegocio.KeyMember);
                    //var cab = (from item in this.listaDeudas
                    //           select new
                    //               {
                    //                   ClienteID = item.ClienteID,
                    //                   ClienteNombre = item.NombreCliente,
                    //                   TelefonosCliente = item.TelefonosCliente,
                    //                   RUCCliente = item.RUCCliente,
                    //                   RazonSocialFactura = item.RazonSocialFactura,
                    //                   DireccionCliente = item.DireccionCliente,
                    //                   ErrMsg = DBNull.Value
                    //               })
                    //                 .GroupBy(x => new { x.ClienteID }).Select(g => g.First()).ToList();

                    var cab = (from item in this.listaDeudas
                               group item by new
                               {
                                   item.ClienteID,
                                   item.NombreCliente,
                                   item.IdiomaID,
                                   item.Moneda,
                                   item.MonedaID
                               } into g
                               select new
                               {
                                   ClienteID = g.Key.ClienteID,
                                   ClienteNombre = g.Key.NombreCliente,
                                   IdiomaID = g.Key.IdiomaID,
                                   Moneda = g.Key.Moneda,
                                   MonedaID = g.Key.MonedaID,
                                   SaldoDeuda = g.Sum(s => s.Saldo),
                                   SaldoEquivalenteDolares = g.Sum(s => s.SaldoEquivalenteDolares),
                                   ErrMsg = DBNull.Value
                               })
                               .Where(y => y.SaldoEquivalenteDolares >= montoMinimo)
                               .ToList();


                        //listaDeudas.GroupBy(x => new { x.ClienteID }).Select(g => g.First()).ToList();

                    this.dgvDeudas.Columns.Clear();
                    this.dgvDeudas.DataSource = cab;
                    this.FormatearGrilla();

                    break;
                case 1 :

                    this.lblTitulo.Text = "Asistente para la Generación de Presupuestos - Definición de Cotizaciones";
                    this.pbarGeneracion.Visible = false;
                    this.btnMarcarTodo.Text = "Marcar Todo";
                    this.GetCotizacionesCab();
                    break;
                case 2 :
                    this.lblTitulo.Text = "";
                    break;
            }

            this.tbCtrlGenReclamos.SelectedIndex = this.tbCtrlGenReclamos.SelectedIndex + 1;
        }

        private List<GetListadoGeneraldeDeudasPendientes_Result> GetListaDeudas(string fechaDesde, string fechaHasta, string clienteId,
                                                                                string tramiteID, string hiNro, string hiAnio,
                                                                                string actaNro, string actaAnio, string ciudadID,
                                                                                string paisID, string areaID, string unidadnegocioID)
        {
            this.DBContext.Database.CommandTimeout = 180;
            List<GetListadoGeneraldeDeudasPendientes_Result> listaDeudas = this.DBContext.GetListadoGeneraldeDeudasPendientes(fechaDesde,
                                                                                                          fechaHasta,
                                                                                                          clienteId,
                                                                                                          String.Empty,
                                                                                                          true,
                                                                                                          false,
                                                                                                          tramiteID,
                                                                                                          hiNro,
                                                                                                          hiAnio,
                                                                                                          actaNro,
                                                                                                          actaAnio,
                                                                                                          ciudadID,
                                                                                                          paisID,
                                                                                                          areaID,
                                                                                                          unidadnegocioID).ToList();
            return listaDeudas;
        }
    
        private void btnAtras_Click(object sender, EventArgs e)
        {
            switch (this.tbCtrlGenReclamos.SelectedIndex)
            {
                case 0:
                    this.lblTitulo.Text = "";
                    break;
                case 1:
                    this.lblTitulo.Text = "Asistente para la Generación de Presupuestos - Especificación de Filtros";
                    break;
                case 2:
                    this.lblTitulo.Text = "Asistente para la Generación de Presupuestos - Selección de Trámites";
                    break;
            }
            this.tbCtrlGenReclamos.SelectedIndex = this.tbCtrlGenReclamos.SelectedIndex - 1;
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaDesde.Text = this.dtpFechaDesde.Value.ToShortDateString();
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaHasta.Text = this.dtpFechaHasta.Value.ToShortDateString();
        }

        
        private void btnMarcarTodo_Click(object sender, EventArgs e)
        {
            string DESMARCAR = "Desmarcar" + Environment.NewLine + "Todo";
            string MARCAR = "Marcar Todo";// +Environment.NewLine + "Todo";
            bool marcar = true;

            if (this.btnMarcarTodo.Text == DESMARCAR)
                marcar = false;

            foreach (DataGridViewRow row in this.dgvDeudas.Rows)
            {
                row.Cells[0].Value = marcar;
            }

            this.btnMarcarTodo.Text = marcar ? DESMARCAR : MARCAR;
        }


        private void btnGenerar_Click(object sender, EventArgs e)
        {
            //if (this.GetCantidadSeleccionados() == 0)
            //{
            //    MessageBox.Show("Debe seleccionar al menos una cotización para iniciar el proceso.",
            //                            "Atención Requerida",
            //                            MessageBoxButtons.OK,
            //                            MessageBoxIcon.Exclamation);
            //    return;
            //}

            //this.timer1.Start();

            //string caption = "Generación de Presupuestos";
            //string message = "Se iniciará el Proceso de Generación de Presupuestos ¿Desea continuar?";

            //MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            //MessageBox.Show(message, caption, buttons,
            //                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
            //                new EventHandler(DialogHandlerGeneracion));
        }

        private void dgvCotizaciones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.RowIndex > -1) && ((e.ColumnIndex == (((DataGridView)sender).Columns[CAMPO_SALDODEUDA].Index) ||
                                      (e.ColumnIndex == (((DataGridView)sender).Columns[CAMPO_SALDOEQUIVALENTEDOLARES].Index)))))
            {
                if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_MONEDA].Value.ToString() == MONEDA_GUARANIES)
                    e.CellStyle.Format = FORMATO_MONEDA_GUARANIES_GRILLA;
                else
                    e.CellStyle.Format = FORMATO_MONEDA_OTROS_GRILLA;
            }
            
            //if ((e.RowIndex > -1) && (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_MONEDA].Value.ToString() == "G"))
            //{
            //    //((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_MONEDA].Style.Format = FORMATO_MONEDA_GUARANIES_GRILLA;
            //    ((DataGridView)sender).Columns[CAMPO_MONEDA].DefaultCellStyle.Format = "N0";
            //}
            //else if ((e.RowIndex > -1) && (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_MONEDA].Value.ToString() != "G"))
            //{
            //    //((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_MONEDA].Style.Format = FORMATO_MONEDA_OTROS_GRILLA;
            //    ((DataGridView)sender).Columns[CAMPO_MONEDA].DefaultCellStyle.Format = "N2";
            //}
            //if ((e.RowIndex > -1) &&
            //    (this.dgvDeudas.Rows[e.RowIndex].Cells[CAMPO_GENERADO].Value != null) &&
            //    ((bool)(this.dgvDeudas.Rows[e.RowIndex].Cells[CAMPO_GENERADO].Value)) /*&&
            //    (this.rbMarcas.Checked)*/) 
            //{
            //    ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
            //}

            ////if ((e.RowIndex > -1) &&
            ////    (this.dgvCotizaciones.Rows[e.RowIndex].Cells[CAMPO_ANULADO].Value != null) &&
            ////    ((bool)(this.dgvCotizaciones.Rows[e.RowIndex].Cells[CAMPO_ANULADO].Value)))
            ////{
            ////    ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.HotPink;
            ////}

            //if ((e.RowIndex > -1) &&
            //    (this.dgvDeudas.Rows[e.RowIndex].Cells[CAMPO_ERROR].Value != null) &&
            //    (this.dgvDeudas.Rows[e.RowIndex].Cells[CAMPO_ERROR].Value.ToString() != OK))
            //{
            //    ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
            //}
        }

        private void dgvCotizaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ((DataGridView)sender).Columns[CAMPO_VERDETALLES].Index)
            {
                int clienteID = (int)((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_CLIENTEID].Value;
                int monedaID = (int)((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_MONEDAID].Value;
                var subLista = this.listaDeudas.Where(a => a.ClienteID == clienteID && a.MonedaID == monedaID).ToList();

                FDetalleDeudasClientes f = new FDetalleDeudasClientes();
                f.FormClosed += delegate { f = null; };
                f.AddData(subLista);
                f.ShowDialog();
            }
            else if (e.ColumnIndex == ((DataGridView)sender).Columns[CAMPO_VERTEXTONOTIF].Index)
            {
                int idiomaID = (int)((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_IDIOMAID].Value;

                if (fDatosMailing == null)
                {
                    fDatosMailing = new FDatosMailingHTML(this.DBContext);
                    fDatosMailing.AceptarFiltrarClick += f_AceptarFiltrarClick;
                }

                string clienteID = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_CLIENTEID].Value.ToString();
                string clienteNombre = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_CLIENTENOMBRE].Value.ToString();
                int monedaID = (int)((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_MONEDAID].Value;
                string tituloReclamo = idiomaID == IDIOMA_ESPANOL ? TITULO_RECLAMO_ESPANOL : TITULO_RECLAMO_INGLES;
                string referenceNumber = String.Format(FORMAT_REFERENCIA, clienteID.ToString(),
                                                        DateTime.Now.Ticks.ToString(),
                                                        VWGContext.Current.Session["UsuarioID"].ToString());

                string htmlTable = this.GenerarReporteTramitesDesagrupados(clienteID, monedaID, this.FechaDesde, this.FechaHasta);
                string textoReclamo = idiomaID == IDIOMA_ESPANOL ? TEXTO_RECLAMO_ESPANOL : TEXTO_RECLAMO_INGLES;
                string htmlBody = this.DBContext.pa_parametros.First(a => a.clave == textoReclamo).valor;
                string cc = this.DBContext.pa_parametros.First(a => a.clave == RECLAMO_CC).valor;
                int cliID = Convert.ToInt32(clienteID);
                fDatosMailing.To = this.DBContext.GetViaPorClienteAreaTable(cliID, RECLAMO_AREAID, RECLAMO_VIAID).FirstOrDefault().ToString();
                fDatosMailing.CC = cc;
                fDatosMailing.Body = String.Format(htmlBody, htmlTable, referenceNumber);
                fDatosMailing.Subject = String.Format(this.DBContext.pa_parametros.First(a => a.clave == tituloReclamo).valor, clienteNombre);
                fDatosMailing.ReferenceNumber = referenceNumber;
                fDatosMailing.ShowDialog();
            }
        }

        private void f_AceptarFiltrarClick(object sender, EventArgs e)
        {
            
            string subject = fDatosMailing.Subject;
            string body = fDatosMailing.Body;
            string from = fDatosMailing.From;
            string to = fDatosMailing.To;
            string cc = fDatosMailing.CC;
            string bcc = fDatosMailing.BCC;
            string referenceNumber = fDatosMailing.ReferenceNumber;

            //pa_parametros param = this.DBContext.pa_parametros.First(a => a.clave == SMTP);
            string smtp = this.DBContext.pa_parametros.First(a => a.clave == SMTP).valor;
            string smtp_port = this.DBContext.pa_parametros.First(a => a.clave == SMTP_PORT).valor;

            if ((from == "") || (to == ""))
            {
                MessageBox.Show("Debe indicar el remitente y al menos un destinatario.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            string format = "HTML,html";
            
            bool success = false;
            //cm_cierremovimiento cm = null;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        int clienteID = (int)this.dgvDeudas.Rows[this.dgvDeudas.CurrentRow.Index].Cells[CAMPO_CLIENTEID].Value;
                        int monedaID = (int)this.dgvDeudas.Rows[this.dgvDeudas.CurrentRow.Index].Cells[CAMPO_MONEDAID].Value;

                        rc_reclamocliente rc = new rc_reclamocliente();
                        rc.rc_fechareclamo = DateTime.Now;
                        rc.rc_usuarioid = Convert.ToInt32(VWGContext.Current.Session["UsuarioID"].ToString());
                        rc.rc_textoreclamo = body;
                        rc.rc_total = (decimal)this.dgvDeudas.Rows[this.dgvDeudas.CurrentRow.Index].Cells[CAMPO_SALDODEUDA].Value;
                        rc.rc_monedaid = monedaID;// (int)this.dgvDeudas.Rows[this.dgvDeudas.CurrentRow.Index].Cells[CAMPO_MONEDAID].Value;
                        rc.rc_clienteid = clienteID;// (int)this.dgvDeudas.Rows[this.dgvDeudas.CurrentRow.Index].Cells[CAMPO_CLIENTEID].Value;
                        rc.rc_from = from;
                        rc.rc_to = to;
                        rc.rc_cc = cc;
                        rc.rc_bcc = bcc;
                        rc.rc_subject = subject;
                        rc.rc_referencia = referenceNumber;
                        context.rc_reclamocliente.Add(rc);

                        foreach (var row in this.listaDeudas.Where(a => a.ClienteID == clienteID && a.MonedaID == monedaID).ToList())
                        {
                            rd_reclamoclientedetalle rd = new rd_reclamoclientedetalle();
                            rd.rd_presupuestocabid = rc.rc_reclamoclienteid;
                            rd.rd_presupuestocabid = row.PresupuestoID;
                            rd.rd_saldo = row.Saldo;

                            if (this.FechaReclamarEn != String.Empty)
                                rd.rd_fecharereclamo = Convert.ToDateTime(this.FechaReclamarEn);
                            else
                                rd.rd_fecharereclamo = null;

                            context.rd_reclamoclientedetalle.Add(rd);
                        }

                        context.SaveChanges();

                        this.SendAsMail(from, to, cc, bcc, smtp,
                                        format, String.Empty, subject, body, smtp_port);

                        dbContextTransaction.Commit();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            if (success)
            {
                fDatosMailing.Close();
                MessageBox.Show("E-mail enviado éxitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void SendAsMail(string from, string to, string cc, string bcc, string smtpServer,
                               string format = "PDF,pdf", string fileName = "Reporte", string asuntoMail = "Reporte del SPF",
                               string cuerpoMail = "Por favor revise el archivo adjunto.", string smtp_port = "587")
        {
            string[] frmext = format.Split(',');

            MailMessage message = new MailMessage();

            #region Manejo de Destinatarios
            if (from != "")
            {
                //from = "Notificaciones@berke.com.py";
                message.From = new MailAddress(from);
                message.ReplyToList.Add(new MailAddress(from));
            }

            if (to != "")
            {
                string[] tos = (to.Replace(';', ',')).Split(','); ;
                foreach (string subTo in tos)
                {
                    message.To.Add(new MailAddress(subTo));
                }
            }

            if (cc != "")
            {
                string[] ccs = (cc.Replace(';', ',')).Split(','); ;
                foreach (string subCC in ccs)
                {
                    message.CC.Add(new MailAddress(subCC));
                }
            }

            if (bcc != "")
            {
                string[] bccs = (bcc.Replace(';', ',')).Split(','); ;
                foreach (string subBCC in bccs)
                {
                    message.Bcc.Add(new MailAddress(subBCC));
                }
            }
            #endregion Manejo de Destinatarios
            //message.From = new MailAddress("Gustavo.Galeano@berke.com.py");
            //message.To.Add("ggaleano.py@gmail.com");         

            //message.CC.Add("ggaleano.py@gmail.com");

            message.Subject = asuntoMail;
            message.IsBodyHtml = true;
            message.Body = cuerpoMail;//.Replace(Environment.NewLine, "<br>");
            
            //SmtpClient smtp = new SmtpClient(smtpServer);
            //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtp.UseDefaultCredentials = false;
            //smtp.Credentials = CredentialCache.DefaultNetworkCredentials;
            //smtp.Send(message);

            //Para SMTP de Office365
            SmtpClient smtpClient = new SmtpClient(smtpServer, Convert.ToInt32(smtp_port));
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;

            smtpClient.UseDefaultCredentials = false;

            string username = VWGContext.Current.Session["EmailUsuario"].ToString();
            string password = this.decryptPasswd();
            smtpClient.Credentials = new NetworkCredential(username, password);

            try
            {
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error [SendMailThrowSMTP] " + ex.ToString());
            }
        }

        private string decryptPasswd()
        {
            string Result = string.Empty;
            int usuarioID = Convert.ToInt32(VWGContext.Current.Session["UsuarioID"].ToString());

            SPF.Classes.Encrypt_Decrypt decrypt = new SPF.Classes.Encrypt_Decrypt();

            using (BerkeDBEntities context = new BerkeDBEntities())
            {
                Result = decrypt.DecryptString(context.Usuario.FirstOrDefault(a => a.ID == usuarioID).PasswordEmail);
            }

            return Result;
        }
        #endregion Manejo de Controles

        #region Estado de Cuenta
        private string GenerarReporteTramitesDesagrupados(string clienteID, int monedaID, string fechaDesde, string fechaHasta, bool incluirNC = false)
        {
            string htmlTable = String.Empty;

            List<RepEstadoDeCuentaTramitesDesagrupados_Result> reportDS = new List<RepEstadoDeCuentaTramitesDesagrupados_Result>();

            List<int> ListaPresupuestos = new List<int>();

            try
            {
                int cliID = Convert.ToInt32(clienteID);

                List<int> listaPresupuestos = this.listaDeudas.Where(a => a.ClienteID == cliID && a.MonedaID == monedaID).Select(b => b.PresupuestoID).ToList(); 
                reportDS = this.DBContext.RepEstadoDeCuentaTramitesDesagrupados(clienteID, fechaDesde, fechaHasta, incluirNC)
                            .Where(a => listaPresupuestos.Contains( a.PresupuestoID ))
                            .ToList();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al generar el Estado de Cuenta: " + Environment.NewLine + ex.Message, "Información de Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

            if (reportDS.Count == 0)
            {
                //MessageBox.Show("No existen datos para el reporte con los criterios ingresados.",
                //                "Atención Requerida",
                //                MessageBoxButtons.OK,
                //                MessageBoxIcon.Information);
                return String.Empty;
            }

            int it = 0;
            string currencyName = String.Empty;
            string bgColor = String.Empty;
            decimal totalsaldo = 0;
            CultureInfo culture = null;
            string[] situacionAlertaArray = this.DBContext.pa_parametros.First(a => a.clave == SITUACIONES_ALERTA_ESTADO_CUENTA).valor.Split(',');

            foreach (RepEstadoDeCuentaTramitesDesagrupados_Result row in reportDS)
            {
                Hashtable presupCabIDs = new Hashtable();

                if (row.PresupuestoID == 0)
                {
                    foreach (string tram in row.Tramite.Split(new string[] { @NEW_LINE_HTML }, StringSplitOptions.None))
                    {
                        string[] trams = tram.Split(new string[] { @SEP_TRAMITE }, StringSplitOptions.None);
                        int presupCabID = trams.Count() > 0 ? Convert.ToInt32(trams[1]) : 0;
                        presupCabIDs[presupCabID] = trams[0];
                    }
                }
                else
                    presupCabIDs[row.PresupuestoID] = row.Tramite;


                //Primera Iteración
                if (it == 0)
                {
                    string cultureString = row.ClienteIdiomaID == IDIOMA_ESPANOL ? CULTURE_PY : CULTURE_US;
                    culture = new CultureInfo(cultureString);
                    //it++;

                    htmlTable += row.ClienteIdiomaID == IDIOMA_ESPANOL ? String.Format(TABLE_HEADER_SPANISH, row.ClienteNombre, row.ClienteID)
                                                                        : String.Format(TABLE_HEADER_ENGLISH, row.ClienteNombre, row.ClienteID);
                }
                it++;

                row.Tramite = string.Empty;

                foreach (DictionaryEntry entry in presupCabIDs)
                {
                    row.Tramite += (row.Tramite != string.Empty ? @NEW_LINE_HTML : string.Empty) + entry.Value.ToString();
                    int PresupuestoCabID = (int)entry.Key;

                    var q = this.DBContext.cp_cotizacionesxpresup.Where(a => a.cp_presupuestocabid == PresupuestoCabID).ToList();

                    string listaCotizaciones = "";
                    int cantPropietarios = 0;
                    string listaPropietarios = "";
                    string gPropietario = "";
                    string lblAlerta = string.Empty;

                    if (q.Count > 0)
                    {
                        foreach (var qRow in q)
                        {
                            if (listaCotizaciones != "")
                                listaCotizaciones += ",";

                            int cotizacionID = qRow.cp_cotizacionid;
                            listaCotizaciones += cotizacionID.ToString();

                            int expedienteID = this.DBContext.cc_cotizacioncab.First(a => a.cc_cotizacioncabid == cotizacionID).cc_expedienteid.Value;
                            List<GetDatosExpediente_Result> dExpe = this.DBContext.GetDatosExpediente(row.Origen, expedienteID).ToList();

                            if (dExpe.Count > 0)
                            {
                                string propietario = dExpe.First().Propietario;

                                if (propietario != gPropietario)
                                {
                                    cantPropietarios++;
                                    gPropietario = propietario;

                                    if (listaPropietarios != "")
                                        listaPropietarios += ", ";

                                    listaPropietarios += propietario;
                                }

                                foreach (string val in situacionAlertaArray)
                                {
                                    if ((dExpe.First().SituacionID.HasValue) && (Convert.ToInt32(val) == dExpe.First().SituacionID.Value))
                                    {
                                        string clave = string.Format(FORMAT_MSG, val, (culture.Name == CULTURE_PY ? FORMAT_ESP : FORMAT_ING));
                                        lblAlerta = string.Format(this.DBContext.pa_parametros.First(a => a.clave == clave).valor, dExpe.First().SituacionFecha.Value.ToString("d", culture));

                                        if (lblAlerta != string.Empty)
                                            break;
                                    }
                                }
                            }
                        }

                        int TramiteID = row.TramiteID;
                        List<RepHojaCotizacion_Result> repHojaCotizacion = new List<RepHojaCotizacion_Result>();
                        repHojaCotizacion = this.DBContext.RepHojaCotizacion(listaCotizaciones,
                                                                             "A",
                                                                             TramiteID)
                                                                             .GroupBy(x => new { x.Acta }).Select(g => g.First())
                                                                             .ToList();

                        string listaActas = "";
                        if (repHojaCotizacion.Count > 0)
                        {
                            listaActas = row.ClienteIdiomaID == IDIOMA_ESPANOL ? "Acta: " : "Application: ";
                            if (repHojaCotizacion.Count > 1)
                                listaActas = row.ClienteIdiomaID == IDIOMA_ESPANOL ? "Actas: " : "Applications: ";

                            int cantidadCaracteres = listaActas.Length;
                            bool noPrimeraIteracion = true;

                            foreach (RepHojaCotizacion_Result hcRow in repHojaCotizacion)
                            {
                                //if (listaActas != "")
                                if (!noPrimeraIteracion)
                                {
                                    listaActas += ", ";
                                    cantidadCaracteres += 1;
                                }

                                if (cantidadCaracteres + hcRow.Acta.Length > 75)
                                {
                                    listaActas += Environment.NewLine;
                                    cantidadCaracteres = 0;
                                }

                                listaActas += hcRow.Acta;
                                cantidadCaracteres += hcRow.Acta.Length;
                                noPrimeraIteracion = false;
                            }
                            row.Tramite += @NEW_LINE_HTML + listaActas;
                        }

                        string lblPropietarios = row.ClienteIdiomaID == IDIOMA_ESPANOL ? "Propietario: {0}" : "Owner: {0}";
                        if (cantPropietarios > 0)
                        {
                            if (cantPropietarios > 1)
                                lblPropietarios = row.ClienteIdiomaID == IDIOMA_ESPANOL ? "Propietarios: {0}" : "Owners: {0}";

                            row.Tramite += @NEW_LINE_HTML + String.Format(lblPropietarios, listaPropietarios != string.Empty ? listaPropietarios : "--");
                        }

                        if (lblAlerta != string.Empty)
                        {
                            row.Tramite += @NEW_LINE_HTML + this.AddRedFontMarks(lblAlerta);
                        }
                    }
                }

                currencyName = String.Empty;
                bgColor = String.Empty;

                if (it % 2 == 0)
                {
                    bgColor = BG_EVEN;
                }
                else
                {
                    if (it == 1)
                    {
                        currencyName = row.Moneda;
                    }
                    bgColor = BG_ODD;
                }
                totalsaldo += row.Saldo.Value;
                string saldo = String.Format(row.Moneda == MONEDA_GUARANIES ? FORMATO_SIN_DECIMAL_BROWSE :  FORMATO_DECIMAL_BROWSE, row.Saldo);

                htmlTable += String.Format(TABLE_ROW, bgColor, currencyName, row.FechaDocAsDate.Value.ToShortDateString(), row.Tramite, row.NroDoc, saldo);
                currencyName = row.Moneda;
            }
            //Total
            if (it % 2 == 0)
            {
                bgColor = BG_EVEN;
            }
            else
            {
                bgColor = BG_ODD;
            }

            string tSaldo = String.Format(currencyName == MONEDA_GUARANIES ? FORMATO_SIN_DECIMAL_BROWSE : FORMATO_DECIMAL_BROWSE, totalsaldo);
            //tSaldo = String.Format(FORMAT_TOTAL_AMOUNT, currencyName, tSaldo);
            htmlTable += String.Format(TABLE_ROW, bgColor, String.Empty, String.Empty, String.Empty, String.Empty, String.Format(FORMAT_TOTAL_AMOUNT, currencyName, tSaldo));
            
            return htmlTable;
        }

        private string AddRedFontMarks(string text)
        {
            return string.Format(FORMAT_REDFONTMARK, text);
        }
        #endregion Estado de Cuenta

        #region Obtener Cotizaciones a Procesar
        private void GetCotizacionesCab()
        {
            //listaCoti = this.DBContext.GetCotizacionesParaPresupuestos(this.tSBCliente.KeyMember,
            //                                                           this.txtHINro.Text, this.txtHIAnio.Text,
            //                                                           this.txtActaNro.Text, this.txtActaAnho.Text,
            //                                                           this.txtExpediente.Text,
            //                                                           this.txtCotizacionCabID.Text,
            //                                                           this.txtFechaDesde.Text, this.txtFechaHasta.Text,
            //                                                           this.GetTramitesSeleccionados(),
            //                                                           this.GetFilterGenerados()).ToList();
            ListaDetallePresupuesto = new List<DetallePresupuestoType>();

            #region Agrupado por HI
            if (this.rbHI.Checked)
            {

                var query = (from item in listaCoti
                             select new CotizacionesParaPresupuestosType
                              {
                                  ClienteID = item.ClienteID,
                                  ClienteNombre = item.ClienteNombre,
                                  ClienteCorreo = item.ClienteCorreo,
                                  ClienteMultiple = item.ClienteMultiple,
                                  ReferenciaCliente = item.ReferenciaCliente,
                                  HI = item.HI,
                                  OrdenTrabajoID = item.OrdenTrabajoID,
                                  ExpedienteID = item.OrdenTrabajoID == null ? item.ExpedienteID : null,
                                  TramiteID = item.TramiteID,
                                  TramiteDescrip = item.TramiteDescrip,
                                  Generado = item.Generado,
                                  SerieAux = item.SerieAux,
                                  NroPresupuestoAux = item.NroPresupuestoAux,
                                  FechaGeneracionAux = item.FechaGeneracionAux,
                                  NroPresupuesto = item.NroPresupuesto,
                                  HechoPor = item.HechoPor,
                                  InicialesHecho = item.InicialesHecho,
                                  AprobadoPor = item.AprobadoPor,
                                  InicialesAprob = item.InicialesAprob,
                                  AreaContabID = item.AreaContabID,
                                  AbrevPresupDoc = item.AbrevPresupDoc,
                                  AreaDescrip = item.AreaDescrip,
                                  ErrMsg = item.ErrMsg,
                                  Anulado = item.Anulado,
                                  Idioma = item.Idioma
                              })
                              .GroupBy(x => new {x.OrdenTrabajoID}).Select(g => g.First()).ToList();
                
                //EmployeeCollection.GroupBy(x => new{x.fName, x.lName}).Select(g => g.First());
        
                
                foreach (var item in query)
                {
                    if (item.OrdenTrabajoID != null)
                    {
                        var qry = (from detPresup in listaCoti

                                   select new DetallePresupuestoType
                                   {
                                       OrdenTrabajoID = detPresup.OrdenTrabajoID,
                                       ExpedienteID = detPresup.ExpedienteID,
                                       Acta = detPresup.Acta,
                                       DenominacionMarca = detPresup.DenominacionMarca,
                                       PresentacionFecha = detPresup.PresentacionFecha,
                                       HI = detPresup.HI,
                                       ClienteID = detPresup.ClienteID,
                                       ClienteNombre = detPresup.ClienteNombre,
                                       TramiteID = detPresup.TramiteID,
                                       TramiteDescrip = detPresup.TramiteDescrip,
                                       Generado = detPresup.Generado,
                                       Terminado = detPresup.Terminado,
                                       Anulado = detPresup.Anulado,
                                       ExpedienteIDPadre = detPresup.ExpedienteIDPadre,
                                       HINro = detPresup.HINro,
                                       HIAnho = detPresup.HIAnho,
                                       CotizacionCabID = detPresup.CotizacionCabID,
                                       MeID = detPresup.MeID,
                                       ExpedientePadreID_pr = detPresup.ExpedientePadreID_pr,
                                       NroPresupuesto = detPresup.NroPresupuesto,
                                       MergeDocID = detPresup.MergeDocID,
                                       Idioma = detPresup.Idioma
                                   }).Where(a => a.OrdenTrabajoID == item.OrdenTrabajoID)
                                   .GroupBy(x => new { x.CotizacionCabID }).Select(g => g.First()).ToList();

                        ListaDetallePresupuesto.AddRange((List<DetallePresupuestoType>)qry.ToList());
                                                        
                    }
                    else
                    {
                        var qry = (from detPresup in listaCoti
                                   select new DetallePresupuestoType
                                   {
                                       ExpedienteID = detPresup.ExpedienteID,
                                       Acta = detPresup.Acta,
                                       DenominacionMarca = detPresup.DenominacionMarca,
                                       PresentacionFecha = detPresup.PresentacionFecha,
                                       HI = detPresup.HI,
                                       ClienteID = detPresup.ClienteID,
                                       ClienteNombre = detPresup.ClienteNombre,
                                       TramiteID = detPresup.TramiteID,
                                       TramiteDescrip = detPresup.TramiteDescrip,
                                       Generado = detPresup.Generado,
                                       Terminado = detPresup.Terminado,
                                       Anulado = detPresup.Anulado,
                                       ExpedienteIDPadre = detPresup.ExpedienteIDPadre,
                                       HINro = detPresup.HINro,
                                       HIAnho = detPresup.HIAnho,
                                       CotizacionCabID = detPresup.CotizacionCabID,
                                       MeID = detPresup.MeID,
                                       ExpedientePadreID_pr = detPresup.ExpedientePadreID_pr,
                                       NroPresupuesto = detPresup.NroPresupuesto,
                                       MergeDocID = detPresup.MergeDocID,
                                       Idioma = detPresup.Idioma
                                   }).Where(a => a.ExpedienteID == item.ExpedienteID)
                                   .GroupBy(x => new { x.CotizacionCabID }).Select(g => g.First()).ToList();

                        ListaDetallePresupuesto.AddRange((List<DetallePresupuestoType>)qry.ToList());
                    }

                    if ((item.Anulado.HasValue) && (item.Anulado.Value))
                    {
                        item.Generado = false;
                        item.NroPresupuesto = null;
                    }
                }

                this.dgvDeudas.DataSource = query;

            }
            #endregion Agrupado por HI
            #region Agrupado por Marca
            else if (this.rbMarcas.Checked)
            {
                listaCoti = listaCoti.GroupBy(x => new { x.CotizacionCabID }).Select(g => g.First()).ToList();

                var qry = (from detPresup in listaCoti
                           select new DetallePresupuestoType
                           {
                               ExpedienteID = detPresup.ExpedienteID,
                               Acta = detPresup.Acta,
                               DenominacionMarca = detPresup.DenominacionMarca,
                               PresentacionFecha = detPresup.PresentacionFecha,
                               HI = detPresup.HI,
                               ClienteID = detPresup.ClienteID,
                               ClienteNombre = detPresup.ClienteNombre,
                               TramiteID = detPresup.TramiteID,
                               TramiteDescrip = detPresup.TramiteDescrip,
                               Generado = detPresup.Generado,
                               Terminado = detPresup.Terminado,
                               Anulado = detPresup.Anulado,
                               ExpedienteIDPadre = detPresup.ExpedienteIDPadre,
                               HINro = detPresup.HINro,
                               HIAnho = detPresup.HIAnho,
                               CotizacionCabID = detPresup.CotizacionCabID,
                               MeID = detPresup.MeID,
                               ExpedientePadreID_pr = detPresup.ExpedientePadreID_pr,
                               NroPresupuesto = detPresup.NroPresupuesto,
                               MergeDocID = detPresup.MergeDocID,
                               Idioma = detPresup.Idioma
                           });
                           

                ListaDetallePresupuesto.AddRange((List<DetallePresupuestoType>)qry.ToList());

                foreach (var coti in listaCoti)
                {
                    if ((coti.Anulado.HasValue) && (coti.Anulado.Value))
                    {
                        coti.Generado = false;
                        coti.NroPresupuesto = null;
                    }
                }

                this.dgvDeudas.DataSource = listaCoti;
            }
            #endregion Agrupado por Marca

            foreach (DetallePresupuestoType item in this.ListaDetallePresupuesto)
            {
                if ((item.Anulado.HasValue) && (item.Anulado.Value))
                {
                    item.MeID = null;
                    item.MergeDocID = null;
                    item.NroPresupuesto = null;
                    item.Generado = false;
                }
            }

            this.FormatearGrilla();
        }
        #endregion Obtener Cotizaciones a Procesar

        #region Proceso
        private void GenerarPresupuestos()
        {
            //int cntGenerados = 0;
            byte[] binaryFile;

            if (!System.IO.Directory.Exists(@w_directorio_trabajo))
            {
                System.IO.Directory.CreateDirectory(@w_directorio_trabajo);
            }
            
            Berke.Libs.CodeGenerator cg;

            Berke.Libs.CodeGenerator tablaCliente;
            Berke.Libs.CodeGenerator tablaAtencion;
            Berke.Libs.CodeGenerator filaAtencion;
            Berke.Libs.CodeGenerator filaCorreo;
            Berke.Libs.CodeGenerator tablaTarifa;
            Berke.Libs.CodeGenerator filaServicio;
            Berke.Libs.CodeGenerator filaTarifa;
            Berke.Libs.CodeGenerator filaTotal;
            

            string carpeta = @w_directorio_trabajo;

            //string archivo = "presupuesto";
            string ext = ".doc";
            //string path = carpeta + archivo + ext;

            string archivo = "";
            string path = "";
            string MergeDocID = "";
            
            //chequear_guardar_docs();

            TExpedienteCab str_ExpedienteCab = new TExpedienteCab();
            int autonum = 0;

            this.dgvDeudas.Columns[CAMPO_ERROR].Visible = false;
            
            List<GetCotizacionesParaPresupuestos_Result> listaProceso = this.GetListaCabeceras();

            this.cntAProcesar = listaProceso.Count;
            this.pbarGeneracion.Maximum = this.cntAProcesar;

            //this.timer1.Start();

            string DescripcionGastos = "";

            #region Iteración Principal
            foreach (var item in listaProceso)
            {
                this.cntProcesados++;
                DescripcionGastos = "";
                using (var context = new BerkeDBEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            ConfigPresup configPresup = new ConfigPresup();
                            List<DetallePresupuestoType> DetallesProceso = new List<DetallePresupuestoType>();
                            List<RepHojaCotizacion_Result> listadoTarifas = new List<RepHojaCotizacion_Result>();
                            List<DetalleTarifasPresupuestoType> listaDetallePresup = new List<DetalleTarifasPresupuestoType>();
                            string NroPresupuesto = "";

                            //DateTime fecGen;
                            //if (item.FechaGeneracionAux.HasValue)
                            //{
                            //    DateTime.TryParse(item.FechaGeneracionAux.Value.tos
                            //}

                            DateTime fechaGeneracion = item.FechaGeneracionAux.HasValue ? item.FechaGeneracionAux.Value : System.DateTime.Today;
                            int MergeExpedienteID = 0;
                            decimal total = 0;
                            string listaCotizacionesCabID = "";

                            #region Obtener detalles a procesar
                            //List<DetallePresupuestoType> DetallesProceso = new List<DetallePresupuestoType>();
                            int CotizacionCabID = item.CotizacionCabID;
                            if (this.rbMarcas.Checked)
                            {
                                int ExpedienteID = item.ExpedienteID.Value;
                                //DetallesProceso = ListaDetallePresupuesto.Where(a => a.ExpedienteID == ExpedienteID).ToList();
                                DetallesProceso = ListaDetallePresupuesto.Where(a => a.ExpedienteID == ExpedienteID && a.CotizacionCabID == CotizacionCabID).ToList();
                            }
                            else if (this.rbHI.Checked)
                            {
                                if (item.OrdenTrabajoID.HasValue)
                                {
                                    int OrdenTrabajoID = item.OrdenTrabajoID.Value;
                                    DetallesProceso = ListaDetallePresupuesto.Where(a => a.OrdenTrabajoID == OrdenTrabajoID).ToList();
                                }
                                else
                                {
                                    int ExpedienteID = item.ExpedienteID.Value;
                                    //DetallesProceso = ListaDetallePresupuesto.Where(a => a.ExpedienteID == ExpedienteID).ToList();
                                    DetallesProceso = ListaDetallePresupuesto.Where(a => a.ExpedienteID == ExpedienteID && a.CotizacionCabID == CotizacionCabID).ToList();
                                }
                            }

                            #endregion Obtener detalles a procesar

                            if ((item.FacturaLocal.HasValue) && (!item.FacturaLocal.Value))
                            {
                                #region Obtener numero de presupuesto

                                if ((item.NroPresupuestoAux.HasValue) && (item.SerieAux == null) ||
                                    (!item.NroPresupuestoAux.HasValue) && (item.SerieAux != null))
                                    throw new Exception("Debe indicar serie y número para asignaciones manuales de identificador de presupuesto.");

                                autonum = item.NroPresupuestoAux.HasValue && item.SerieAux != "" ? 0 : 1;
                                //ConfigPresup configPresup = new ConfigPresup();
                                if (autonum == 1)
                                {
                                    var configP = context.ConfigPresup.Where(a => a.Vigente == true).ToList();

                                    if (configP.Count > 1)
                                    {
                                        //MessageBox.Show("No se encuentra configuracion para obtener el numero de presupuesto o existe mas de una vigente");
                                        //return;
                                        throw new Exception("No se encuentra configuración para obtener el número de presupuesto o existe más de uno vigente");
                                    }
                                    configPresup = configP.First();
                                }

                                #endregion Obtener numero de presupuesto

                                #region Leer Plantilla

                                if (!item.IdiomaID.HasValue)
                                {
                                    //MessageBox.Show("El cliente no tiene definido el idioma");
                                    //return;
                                    throw new Exception("El cliente no tiene definido el idioma");
                                }

                                int TramiteID = item.TramiteID.Value;
                                int MergeID = item.MergeID.Value;
                                int IdiomaID = item.IdiomaID.Value != IDIOMA_ESPANOL ? IDIOMA_INGLES : IDIOMA_ESPANOL;
                                //string Plantilla = item.IdiomaID.Value != IDIOMA_ESPANOL ? PLANTILLA_PRESUPUESTO_SPF_ING : PLANTILLA_PRESUPUESTO_SPF_ESP;
                                string Plantilla = item.IdiomaID.Value != IDIOMA_ESPANOL ? PLANTILLA_PRESUPUESTO_SPF_PRUEBAS_ING : PLANTILLA_PRESUPUESTO_SPF_PRUEBAS_ESP;

                                List<DocumentoPlantilla> DP = new List<DocumentoPlantilla>();

                                //if (item.Origen == ORIGEN_MARCAS)
                                //{
                                //    DP = context.DocumentoPlantilla.Where(a => a.Clave == PLANTILLA_PRESUPUESTO_MARCAS
                                //                                                      && a.TramiteID == TramiteID
                                //                                                      && a.MergeID == MergeID
                                //                                                      && a.IdiomaID == IdiomaID
                                //                                                      && a.Plural == true).ToList();
                                //}
                                //else
                                //{
                                DP = context.DocumentoPlantilla.Where(a => a.Clave == Plantilla
                                                                                  && a.MergeID == MergeID
                                                                                  && a.IdiomaID == IdiomaID
                                                                                  && a.Plural == true).ToList();
                                //}

                                string msj = "Tramite " + TramiteID.ToString() + " Mergeid "
                                             + MergeID.ToString() + " Idioma "
                                             + IdiomaID.ToString();

                                if (DP.Count == 0)
                                {
                                    //MessageBox.Show("No se encuentra una plantilla para el tramite " + item.TramiteDescrip + " " + msj);
                                    //return;
                                    throw new Exception("No se encuentra una plantilla para el tramite " + item.TramiteDescrip + " " + msj);

                                }

                                if (DP.Count > 1)
                                {
                                    //MessageBox.Show("Existe mas de una plantilla para el tramite " + item.TramiteDescrip + " " + msj);
                                    //return;
                                    throw new Exception("Existe mas de una plantilla para el tramite " + item.TramiteDescrip + " " + msj);
                                }


                                string template = ((List<DocumentoPlantilla>)DP).First().PlantillaHTML;

                                #endregion Leer Plantilla

                                #region Instanciar CodeGenerators

                                cg = new Berke.Libs.CodeGenerator(template);

                                tablaCliente = cg.ExtraerTabla("tablaCliente");
                                filaCorreo = tablaCliente.ExtraerFila("filaCorreo", 1);

                                filaCorreo.clearText();
                                filaCorreo.copyTemplateToBuffer();

                                tablaCliente.clearText();
                                tablaCliente.copyTemplateToBuffer();

                                tablaAtencion = cg.ExtraerTabla("tablaAtencion");
                                filaAtencion = tablaAtencion.ExtraerFila("filaAtencion",3);

                                filaAtencion.clearText();
                                filaAtencion.copyTemplateToBuffer();

                                tablaAtencion.clearText();
                                tablaAtencion.copyTemplateToBuffer();

                                tablaTarifa = cg.ExtraerTabla("tablaTarifa");

                                filaServicio = tablaTarifa.ExtraerFila("filaServicio", 1);
                                filaTarifa = tablaTarifa.ExtraerFila("filaTarifa", 2);
                                filaTotal = filaTarifa.ExtraerFila("filaTotal", 1);

                                filaServicio.clearText();
                                filaServicio.copyTemplateToBuffer();

                                #region Configurar descripción de servicios según trámite e idioma
                                //if (item.Origen == ORIGEN_OTRAS)
                                //{
                                pp_partepresupuesto pp = new pp_partepresupuesto();
                                try
                                {
                                    pp = context.pp_partepresupuesto.First(a => a.pp_tramiteid == TramiteID);
                                    //((IObjectContextAdapter)context).ObjectContext.Refresh(System.Data.Entity.Core.Objects.RefreshMode.ClientWins, pp);
                                }
                                catch (InvalidOperationException)
                                {
                                    throw new Exception("Modelo de documento no definido para el trámite: " + item.TramiteDescrip);
                                }
                                string DescripcionServicios = IdiomaID == IDIOMA_ESPANOL ? pp.pp_descripcionserviciosesp : pp.pp_descripcionserviciosing;

                                if (DescripcionServicios == "")
                                    throw new Exception("No existe plantilla Descripción de Servicios para el trámite e idioma del cliente. Debe especificar uno en la configuración del modelo");

                                DescripcionGastos = IdiomaID == IDIOMA_ESPANOL ? pp.pp_descripciongastosesp : pp.pp_descripciongastosing;

                                if (DescripcionGastos == "")
                                    DescripcionGastos = IdiomaID == IDIOMA_ESPANOL ? DESCRIPCION_GASTOS_ESP : DESCRIPCION_GASTOS_ING;

                                filaServicio.replaceField("descripcion.servicios", this.FormatearMarcasXML(DescripcionServicios));
                                //}
                                #endregion Configurar descripción de servicios según trámite

                                filaTarifa.clearText();
                                filaTarifa.copyTemplateToBuffer();

                                filaTotal.clearText();
                                filaTotal.copyTemplateToBuffer();

                                tablaTarifa.clearText();
                                tablaTarifa.copyTemplateToBuffer();

                                cg.clearText();
                                cg.copyTemplateToBuffer();


                                #endregion Instanciar CodeGenerators

                                //#region Obtener detalles a procesar
                                ////List<DetallePresupuestoType> DetallesProceso = new List<DetallePresupuestoType>();
                                //if (this.rbMarcas.Checked)
                                //{
                                //    int ExpedienteID = item.ExpedienteID.Value;
                                //    DetallesProceso = ListaDetallePresupuesto.Where(a => a.ExpedienteID == ExpedienteID).ToList();
                                //}
                                //else if (this.rbHI.Checked)
                                //{
                                //    if (item.OrdenTrabajoID.HasValue)
                                //    {
                                //        int OrdenTrabajoID = item.OrdenTrabajoID.Value;
                                //        DetallesProceso = ListaDetallePresupuesto.Where(a => a.OrdenTrabajoID == OrdenTrabajoID).ToList();
                                //    }
                                //    else
                                //    {
                                //        int ExpedienteID = item.ExpedienteID.Value;
                                //        DetallesProceso = ListaDetallePresupuesto.Where(a => a.ExpedienteID == ExpedienteID).ToList();
                                //    }
                                //}
                                //#endregion Obtener detalles a procesar

                                #region Generación de documento
                                int cabecera = 0;
                                //string NroPresupuesto = "";
                                string cadena_clasenro = "";
                                string nro_registro = "";
                                string nro_acta = "";
                                string marca = "";

                                //string listaCotizacionesCabID = "";
                                listaCotizacionesCabID = "";

                                #region Procesar detalles del Merge
                                foreach (var drDetPreMerge in DetallesProceso)
                                {
                                    if ((drDetPreMerge.Generado.HasValue) && (drDetPreMerge.Generado.Value))
                                        throw new Exception("Presupuesto ya generado. Debe anular el anterior para generar nuevamente.");

                                    #region Inserción de Merge_Expediente
                                    if (!drDetPreMerge.MeID.HasValue) //|| (drDetPreMerge.Anulado.HasValue && (bool)drDetPreMerge.Anulado.Value))
                                    {
                                        Merge_Expediente me = new Merge_Expediente();

                                        if (item.Origen == ORIGEN_MARCAS)
                                        {
                                            me.ExpedienteID = drDetPreMerge.ExpedienteID;
                                            me.ExpedienteExtID = null;
                                        }
                                        else if (item.Origen == ORIGEN_OTRAS)
                                        {
                                            me.ExpedienteID = null;
                                            me.ExpedienteExtID = drDetPreMerge.ExpedienteID;
                                        }
                                        me.TramiteID = drDetPreMerge.TramiteID;
                                        me.MergeID = item.MergeID.Value;
                                        me.FuncionarioID = this.UsuarioID;
                                        me.Fecha = System.DateTime.Now;

                                        if (drDetPreMerge.ExpedientePadreID_pr.HasValue)
                                        {
                                            me.EnTramite = this.esEnTramite(drDetPreMerge.ExpedientePadreID_pr.Value);//, dr.Cells[CAMPO_ORIGEN].Value.ToString());
                                            me.ExpedienteIDPadre = drDetPreMerge.ExpedientePadreID_pr.Value;
                                        }
                                        else
                                        {
                                            me.EnTramite = false;
                                            me.ExpedienteIDPadre = null;
                                        }

                                        me.Generado = false;
                                        me.Anulado = false;
                                        me.Terminado = false;
                                        me.MergeDocID = null;

                                        context.Merge_Expediente.Add(me);
                                        context.SaveChanges();

                                        #region Actualizar Datos de la grilla
                                        drDetPreMerge.MeID = me.ID;
                                        drDetPreMerge.ExpedienteIDPadre = me.ExpedienteIDPadre;
                                        //drDetPreMerge.EnTramite = me.EnTramite;
                                        #endregion Actualizar Datos de la grilla
                                        //throw new Exception("Just testing");
                                    }

                                    #endregion Inserción de Merge_Expediente

                                    //MergeExpedienteID = drDetPreMerge.MeID.Value.ToString();
                                    TExpedienteDet str_ExpedienteDet = new TExpedienteDet();
                                    int ExpedienteID = item.Origen == ORIGEN_MARCAS 
                                                        ? drDetPreMerge.ExpedienteID.Value 
                                                        : (drDetPreMerge.ExpedienteIDPadre.HasValue ? drDetPreMerge.ExpedienteIDPadre.Value
                                                                                                    : -1);
                                    this.getDatosMarca(ExpedienteID, str_ExpedienteDet, context);

                                    if (listaCotizacionesCabID != "")
                                        listaCotizacionesCabID += ",";

                                    listaCotizacionesCabID += drDetPreMerge.CotizacionCabID.Value.ToString();

                                    #region Datos de cabecera
                                    if (cabecera == 0)
                                    {
                                        MergeExpedienteID = drDetPreMerge.MeID.Value;
                                        #region Salvar datos de Cabecera
                                        str_ExpedienteCab.OrdenTrabajoID = item.OrdenTrabajoID.HasValue ? item.OrdenTrabajoID.Value.ToString() : "";
                                        str_ExpedienteCab.ClienteID = item.ClienteID;
                                        str_ExpedienteCab.ClienteNombre = item.ClienteNombre;
                                        str_ExpedienteCab.ClienteCorreo = item.ClienteCorreo;

                                        if (item.AtencionID.HasValue)
                                            str_ExpedienteCab.AtencionID = item.AtencionID.Value;

                                        //if (!item.AtencionID.HasValue)
                                        //    throw new Exception("No se encuentra ninguna atención asociada al expediente");
                                        //else
                                        //    str_ExpedienteCab.AtencionID = item.AtencionID.Value;

                                        str_ExpedienteCab.ClienteAtencion = item.AtencionNombre;
                                        str_ExpedienteCab.FechaCorresp = item.FechaCorresp.HasValue ? item.FechaCorresp.Value.ToShortDateString() : "";
                                        str_ExpedienteCab.TramiteID = item.TramiteID.Value.ToString();
                                        str_ExpedienteCab.EnTramite = item.EnTramite.HasValue && item.EnTramite.Value ? "S" : "N";

                                        str_ExpedienteCab.ReferenciaCliente = item.ReferenciaCliente;
                                        str_ExpedienteCab.ReferenciaCorresp = item.ReferenciaCorresp;

                                        str_ExpedienteCab.nrocorresp = item.NroCorresp.HasValue ? item.NroCorresp.Value.ToString() : "";
                                        str_ExpedienteCab.aniocorresp = item.AnioCorresp.HasValue ? item.AnioCorresp.Value.ToString() : "";

                                        //if (!item.AreaContabID.HasValue)
                                          //  throw new Exception("El trámite no tiene definido un área de pertenencia.");
                                        //else
                                        if (item.AreaContabID.HasValue)
                                            str_ExpedienteCab.AreaID = item.AreaContabID.Value;

                                        //if (item.InicialesAprob == null)
                                        if (item.AprobadoPor == null)
                                            throw new Exception("No está definida la persona que autorizó la cotización.");
                                        else
                                            str_ExpedienteCab.AprobadoPorID = item.AprobadoPor.Value;
                                        //    str_ExpedienteCab.InicialesAprob = item.InicialesAprob;

                                        //if (item.InicialesHecho == null)
                                        if (item.HechoPor == null)
                                            throw new Exception("No está definida la persona que solicitó la cotización.");
                                        else
                                        {
                                            //str_ExpedienteCab.InicialesHecho = item.InicialesHecho;
                                            str_ExpedienteCab.EnviadoPorID = item.HechoPor.Value;
                                        }

                                        //if (item.AbrevPresupDoc == null)
                                        //    throw new Exception("No se encunentra identificador de área para el documento");
                                        //else
                                        //{
                                        //    str_ExpedienteCab.AbrevPresupDoc = item.AbrevPresupDoc;
                                        //    str_ExpedienteCab.AprobadoPorID = item.AprobadoPor.Value;
                                        //}

                                        if (item.Origen == ORIGEN_OTRAS)
                                        {
                                            this.getPartes(drDetPreMerge.ExpedienteID.Value, str_ExpedienteCab, context);

                                            if ((str_ExpedienteCab.ParteNombre == null) && (Convert.ToInt32(str_ExpedienteCab.TramiteID) == OPOSICIONES_ID))
                                                throw new Exception("El trámite no tiene definido el nombre de la parte");
                                        }

                                        #endregion Salvar datos de Cabecera


                                        string[] lines = str_ExpedienteCab.ClienteCorreo.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

                                        string correoFormateado = this.FormatearMarcasXML("<b>" + lines[0] + "</b>") + NEWLINEXML;

                                        for (int index = 1; index < lines.Count(); index++)
                                        {
                                            correoFormateado += this.FormatearMarcasXML("<p>" + lines[index] + "</p>") + NEWLINEXML;
                                        }

                                        str_ExpedienteCab.ClienteCorreo = correoFormateado; //str_ExpedienteCab.ClienteCorreo.Replace(MI_ENTER, "<w:br></w:br>");

                                        filaCorreo.replaceField("cliente.correo", str_ExpedienteCab.ClienteCorreo.ToString());

                                        if (autonum == 1)
                                        {
                                            NroPresupuesto = configPresup.Serie + configPresup.Numero.Value.ToString();
                                            filaCorreo.replaceField("numero", NroPresupuesto);
                                        }
                                        else
                                        {
                                            //Verificar que la SerieAux + NroPresupuestoAux no exista en un presupuesto no anulado
                                            NroPresupuesto = item.SerieAux + item.NroPresupuestoAux.Value.ToString();
                                            filaCorreo.replaceField("numero", NroPresupuesto);
                                        }

                                        filaCorreo.addBufferToText();

                                        this.GetPropietarioAnterior(ExpedienteID, str_ExpedienteDet, context);
                                        this.getPropietarioActual(ExpedienteID, str_ExpedienteDet, context);

                                        /*/datos para tr , cn, */

                                        //cg.replaceField("atencion.atencion", str_ExpedienteCab.ClienteAtencion);
                                        //cg.replaceField("orden_trabajo.referenciacliente", str_ExpedienteCab.ReferenciaCliente + " " + str_ExpedienteCab.ReferenciaCorresp);

                                        filaAtencion.replaceField("atencion.atencion", str_ExpedienteCab.ClienteAtencion);
                                        filaAtencion.replaceField("orden_trabajo.referenciacliente", str_ExpedienteCab.ReferenciaCliente + " " + str_ExpedienteCab.ReferenciaCorresp);
                                        filaAtencion.addBufferToText();

                                        cg.replaceField("proant.nombre", str_ExpedienteDet.propietarioAnterior);
                                        //cg.replaceField("proact.nombre", str_ExpedienteDet.propietarioActual);
                                        filaServicio.replaceField("proact.nombre", str_ExpedienteDet.propietarioActual);

                                        /* Registro o Renovacion*/
                                        if (str_ExpedienteCab.TramiteID.ToString() == "1" || str_ExpedienteCab.TramiteID.ToString() == "2")
                                        {
                                            cg.replaceField("clase.clasetipoid", traducirClase(str_ExpedienteDet.ClaseTipo.ToLower(), item.IdiomaID.Value));

                                        }


                                        /*fusion*/
                                        if (str_ExpedienteCab.TramiteID.ToString() == "5")
                                        {
                                            cg.replaceField("proant2.nombre", str_ExpedienteDet.nombreotrospropietarios);
                                        }

                                        /*cambio de domicilio*/
                                        if (str_ExpedienteCab.TramiteID.ToString() == "6")
                                        {
                                            cg.replaceField("proant.direccion", str_ExpedienteDet.propietarioAntDireccion);
                                            cg.replaceField("proact.direccion", str_ExpedienteDet.propietarioActDireccion);
                                        }

                                        if (item.Origen == ORIGEN_OTRAS)
                                        {
                                            //this.getPartes(drDetPreMerge.ExpedienteID.Value, str_ExpedienteDet, context);

                                            //if (str_ExpedienteDet.ParteNombre == null)
                                            //    throw new Exception("El trámite no tiene definido el nombre de la parte");

                                            filaServicio.replaceField("parte.nombre", str_ExpedienteCab.ParteNombre);
                                            filaServicio.replaceField("contraparte.nombre", str_ExpedienteCab.ContraparteNombre);
                                        }


                                        cabecera = 1;

                                    }
                                    #endregion Datos de cabecera

                                    #region Listar las Marcas

                                    /* Mostramos el numero de registro o acta segun este registrado 
						                              * o en tramite respectivamente
						                              * */


                                    if (marca.Length > 0)
                                    {
                                        marca += ", ";
                                    }

                                    if (nro_registro.Length > 0)
                                    {
                                        nro_registro += ", ";
                                    }

                                    if (nro_acta.Length > 0)
                                    {
                                        nro_acta += ", ";
                                    }

                                    if (cadena_clasenro.Length > 0)
                                    {
                                        cadena_clasenro += ", ";
                                    }

                                    marca += drDetPreMerge.DenominacionMarca;
                                    cadena_clasenro += str_ExpedienteDet.ClaseNro;


                                    /*Si NO esta en tramite se utiliza el numero de registro sino se usa el numero de acta */
                                    this.getDatosMarcaRegRen(ExpedienteID, str_ExpedienteDet, context);
                                    if (str_ExpedienteDet.RegistroNro.ToString() != "0" && str_ExpedienteDet.RegistroNro.ToString() != "")
                                    {
                                        nro_registro += str_ExpedienteDet.RegistroNro.ToString();
                                    }
                                    else
                                    {
                                        nro_registro += drDetPreMerge.Acta;
                                    }

                                    nro_acta += drDetPreMerge.Acta;


                                    #endregion
                                }
                                #endregion Procesar detalles del Merge

                                #region Completar Tablas Cliente y Marcas
                                tablaCliente.replaceLabel("filaCorreo", filaCorreo.Texto);
                                tablaCliente.addBufferToText();
                                cg.replaceLabel("tablaCliente", tablaCliente.Texto);

                                tablaAtencion.replaceLabel("filaAtencion", filaAtencion.Texto);
                                tablaAtencion.addBufferToText();
                                cg.replaceLabel("tablaAtencion", tablaAtencion.Texto);


                                string str_fecha = this.traducirFecha(fechaGeneracion.ToShortDateString(), IdiomaID);

                                if (IdiomaID == IDIOMA_ESPANOL) /*español*/
                                {
                                    cg.replaceField("fecha", "Asunción, " + str_fecha.ToString());
                                }
                                else
                                {
                                    cg.replaceField("fecha", str_fecha.ToString());
                                }

                                /* aqui final */

                                filaServicio.replaceField("marca.denominacion", marca.ToString());
                                filaServicio.replaceField("clase.nro", cadena_clasenro.ToString());
                                filaServicio.replaceField("regact.nro", nro_registro.ToString());
                                filaServicio.addBufferToText();
                                tablaTarifa.replaceLabel("filaServicio", filaServicio.Texto);

                                //List<RepHojaCotizacion_Result> listadoTarifas = context.RepHojaCotizacion(listaCotizacionesCabID,
                                //                                                                          this.rbMarcas.Checked ? "A" : "H",
                                //                                                                          item.TramiteID.Value).ToList();
                                listadoTarifas = context.RepHojaCotizacion(listaCotizacionesCabID,
                                                                           this.rbMarcas.Checked ? "A" : "H",
                                                                           item.TramiteID.Value).ToList();
                                int i = 0;
                                //decimal total = 0;
                                total = 0;
                                decimal gasto = 0;
                                decimal impuesto = 0;
                                decimal descuento = 0;
                                decimal recargo = 0;
                                string monedaAbrev = listadoTarifas.First().AbrevMoneda;
                                string monedaDescrip = IdiomaID == IDIOMA_ESPANOL
                                                            ? listadoTarifas.First().MonedaDescrip
                                                            : listadoTarifas.First().MonedaDescripIngles;
                                string descripcionDescuento = IdiomaID == IDIOMA_ESPANOL
                                                                ? DESCRIPCION_DESCUENTOS_ESP
                                                                : DESCRIPCION_DESCUENTOS_ING;
                                //List<DetalleTarifasPresupuestoType> listaDetallePresup = new List<DetalleTarifasPresupuestoType>();

                                foreach (var fila in listadoTarifas)
                                {
                                    if (i > 0)
                                    {
                                        filaTarifa.addBufferToText();
                                    }

                                    string descripcionTarifa = "";

                                    if (IdiomaID == IDIOMA_ESPANOL)
                                    {
                                        if ((fila.TextoEspanol == null) || (fila.TextoEspanol == ""))
                                        {
                                            throw new Exception("La tarifa: " +
                                                                fila.TarifaDescripcion +
                                                                "(" + fila.TarifaID.Value.ToString() + ") " +
                                                                "no tiene etiqueta definida para el idioma español.");
                                        }
                                        descripcionTarifa = fila.TextoEspanol;
                                        
                                    }
                                    else
                                    {
                                        if ((fila.TextoIngles == null) || (fila.TextoIngles == ""))
                                        {
                                            throw new Exception("La tarifa: " +
                                                                fila.TarifaDescripcion +
                                                                "(" + fila.TarifaID.Value.ToString() + ") " +
                                                                "no tiene etiqueta definida para el idioma inglés.");
                                        }
                                        descripcionTarifa = fila.TextoIngles;
                                    }

                                    filaTarifa.copyTemplateToBuffer();
                                    filaTarifa.replaceField("descripcion.tarifa", descripcionTarifa.PadRight(LONGITUD_PADDING, '.'));
                                    filaTarifa.replaceField("mn", monedaAbrev);
                                    filaTarifa.replaceField("tr.mnt", String.Format("{0:0.00}", fila.PrecioUnitario.Value * fila.Cantidad.Value /*fila.Neto.Value*/).Replace(',', '.'));
                                    total += fila.Neto.Value;
                                    gasto += fila.Gasto.Value;
                                    recargo += fila.Recargo.Value;
                                    descuento += fila.Descuento.Value;
                                    impuesto += fila.Impuesto.Value;
                                    i++;

                                    DetalleTarifasPresupuestoType det = new DetalleTarifasPresupuestoType();
                                    det.DetalleDescripcion = descripcionTarifa;
                                    det.DetalleMonto = fila.PrecioUnitario.Value * fila.Cantidad.Value;//fila.Neto.Value;
                                    listaDetallePresup.Add(det);
                                }

                                if ((gasto > 0) || (impuesto > 0) || (recargo > 0))
                                {
                                    filaTarifa.addBufferToText();
                                    filaTarifa.copyTemplateToBuffer();
                                    filaTarifa.replaceField("descripcion.tarifa", DescripcionGastos.PadRight(LONGITUD_PADDING, '.'));
                                    filaTarifa.replaceField("mn", monedaAbrev);
                                    filaTarifa.replaceField("tr.mnt", String.Format("{0:0.00}", gasto + impuesto + recargo).Replace(',', '.'));
                                    total += gasto + impuesto + recargo;

                                    DetalleTarifasPresupuestoType det = new DetalleTarifasPresupuestoType();
                                    det.DetalleDescripcion = DescripcionGastos;
                                    det.DetalleMonto = gasto + impuesto + recargo;
                                    listaDetallePresup.Add(det);
                                }

                                if (descuento > 0)
                                {
                                    filaTarifa.addBufferToText();
                                    filaTarifa.copyTemplateToBuffer();
                                    filaTarifa.replaceField("descripcion.tarifa", descripcionDescuento.PadRight(LONGITUD_PADDING, '.'));
                                    filaTarifa.replaceField("mn", monedaAbrev);
                                    filaTarifa.replaceField("tr.mnt", String.Format("{0:0.00}", descuento * -1).Replace(',', '.'));
                                    
                                    DetalleTarifasPresupuestoType det = new DetalleTarifasPresupuestoType();
                                    det.DetalleDescripcion = descripcionDescuento;
                                    det.DetalleMonto = descuento * -1;
                                    listaDetallePresup.Add(det);
                                }


                                filaTotal.replaceField("total", String.Format("{0:0.00}", total).Replace(',', '.'));
                                filaTotal.replaceField("mn", monedaAbrev);
                                filaTotal.addBufferToText();

                                filaTarifa.replaceLabel("filaTotal", filaTotal.Texto);
                                filaTarifa.addBufferToText();

                                tablaTarifa.replaceLabel("filaTarifa", filaTarifa.Texto);

                                tablaTarifa.addBufferToText();
                                cg.replaceLabel("tablaTarifa", tablaTarifa.Texto);

                                string totalEnLetras = "";

                                if (IdiomaID == IDIOMA_ESPANOL)
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

                                    if (monedaDescrip == DOLLARS)
                                        totalEnLetras = this.NumberToText(total) + " " + monedaDescrip;
                                    else
                                        totalEnLetras = monedaDescrip + " " + this.NumberToText(total);
                                }

                                cg.replaceField("total.letras", totalEnLetras.ToUpper());
                                cg.replaceField("atencion.nombre", item.AtencionNombre);
                                cg.replaceField("atencion.email", item.AtencionEmail);
                                //cg.replaceField("iniciales1", str_ExpedienteCab.InicialesAprob);
                                //cg.replaceField("iniciales2", str_ExpedienteCab.InicialesHecho);
                                //cg.replaceField("abrev.area", str_ExpedienteCab.AbrevPresupDoc);

                                if (item.TramiteID == 2)
                                {
                                    cg.replaceField("acta.nro", nro_acta.ToString());
                                }
                                else
                                {
                                    cg.replaceField("acta.nro", nro_registro.ToString());
                                }


                                cg.replaceField("Paraguay", "Paraguay");


                                /*[ggaleano 19/09/2018] Se agrega sello de banco asignado*/
                                cg.replaceField("color", item.ClienteSelloColor);
                                cg.replaceField("sello", item.ClienteSelloTexto.Replace(System.Environment.NewLine, "<w:br/>"));

                                cg.addBufferToText();
                                #endregion

                                #region Guardar documento en Archivo
                                //System.IO.File.WriteAllText(path, cg.Texto);
                                archivo = str_ExpedienteCab.ClienteID.ToString() + "-" + NroPresupuesto;
                                path = carpeta + archivo + ext;
                                Berke.Libs.Base.Helpers.Files.SaveStringToFile(cg.Texto, path);
                                #endregion Guardar documento en Archivo

                                #endregion Generación de documento
                            }
                            

                            #region Guardar en BD
                            MergeDoc mDoc = new MergeDoc();

                            if ((item.FacturaLocal.HasValue) && (!item.FacturaLocal.Value))
                            {
                                #region Guardar MergeDoc
                                binaryFile = Berke.Libs.Base.Helpers.Files.GetBytesFromFile(@path);
                                mDoc.Contenido = binaryFile;
                                mDoc.Fecha = System.DateTime.Now;
                                mDoc.FuncionarioID = this.UsuarioID;
                                mDoc.MergeID = item.MergeID;
                                mDoc.MergeExpedienteID = MergeExpedienteID;

                                if (autonum == 1)
                                {
                                    mDoc.Serie = configPresup.Serie;
                                    mDoc.NroPresupuesto = configPresup.Numero;
                                    mDoc.Anio = configPresup.Anio;
                                }
                                else
                                {
                                    mDoc.Serie = item.SerieAux;
                                    mDoc.NroPresupuesto = item.NroPresupuestoAux;
                                }
                                context.MergeDoc.Add(mDoc);
                                //Guardamos para obtener el MergeDocID
                                context.SaveChanges();
                                #endregion Guardar MergeDoc

                                #region Actualizar Número de Presupuesto
                                if (autonum == 1)
                                {
                                    configPresup.Numero += 1;
                                }
                                #endregion Actualizar Número de Presupuesto
                            }

                            #region Actualizar Merge_Expediente con referencias
                            int cab = 0;
                            foreach (var drDetPreMerge in DetallesProceso)
                            {
                                if ((item.FacturaLocal.HasValue) && (item.FacturaLocal.Value))
                                {
                                    if ((drDetPreMerge.Generado.HasValue) && (drDetPreMerge.Generado.Value))
                                        throw new Exception("Presupuesto ya generado. Debe anular el anterior para generar nuevamente.");

                                    if (cab == 0)
                                    {
                                        #region Salvar datos de Cabecera
                                        str_ExpedienteCab.OrdenTrabajoID = item.OrdenTrabajoID.HasValue ? item.OrdenTrabajoID.Value.ToString() : "";
                                        str_ExpedienteCab.ClienteID = item.ClienteID;
                                        str_ExpedienteCab.ClienteNombre = item.ClienteNombre;
                                        str_ExpedienteCab.ClienteCorreo = item.ClienteCorreo;

                                        if (item.AtencionID.HasValue)
                                            str_ExpedienteCab.AtencionID = item.AtencionID.Value;

                                        //if (!item.AtencionID.HasValue)
                                        //    throw new Exception("No se encuentra ninguna atención asociada al expediente");
                                        //else
                                        //    str_ExpedienteCab.AtencionID = item.AtencionID.Value;

                                        str_ExpedienteCab.ClienteAtencion = item.AtencionNombre;
                                        str_ExpedienteCab.FechaCorresp = item.FechaCorresp.HasValue ? item.FechaCorresp.Value.ToShortDateString() : "";
                                        str_ExpedienteCab.TramiteID = item.TramiteID.Value.ToString();
                                        str_ExpedienteCab.EnTramite = item.EnTramite.HasValue && item.EnTramite.Value ? "S" : "N";

                                        str_ExpedienteCab.ReferenciaCliente = item.ReferenciaCliente;
                                        str_ExpedienteCab.ReferenciaCorresp = item.ReferenciaCorresp;

                                        str_ExpedienteCab.nrocorresp = item.NroCorresp.HasValue ? item.NroCorresp.Value.ToString() : "";
                                        str_ExpedienteCab.aniocorresp = item.AnioCorresp.HasValue ? item.AnioCorresp.Value.ToString() : "";

                                        if (!item.AreaContabID.HasValue)
                                            throw new Exception("El trámite no tiene definido un área de pertenencia.");
                                        else
                                            str_ExpedienteCab.AreaID = item.AreaContabID.Value;

                                        //if (item.InicialesAprob == null)
                                        if (item.AprobadoPor == null)
                                            throw new Exception("No está definida la persona que autorizó la cotización.");
                                        else
                                            str_ExpedienteCab.AprobadoPorID = item.AprobadoPor.Value;
                                        //    str_ExpedienteCab.InicialesAprob = item.InicialesAprob;

                                        //if (item.InicialesHecho == null)
                                        if (item.HechoPor == null)
                                            throw new Exception("No está definida la persona que solicitó la cotización.");
                                        else
                                        {
                                            //str_ExpedienteCab.InicialesHecho = item.InicialesHecho;
                                            str_ExpedienteCab.EnviadoPorID = item.HechoPor.Value;
                                        }

                                        //if (item.AbrevPresupDoc == null)
                                        //    throw new Exception("No se encunentra identificador de área para el documento");
                                        //else
                                        //{
                                        //    str_ExpedienteCab.AbrevPresupDoc = item.AbrevPresupDoc;
                                        //    str_ExpedienteCab.AprobadoPorID = item.AprobadoPor.Value;
                                        //}

                                        if (item.Origen == ORIGEN_OTRAS)
                                        {
                                            this.getPartes(drDetPreMerge.ExpedienteID.Value, str_ExpedienteCab, context);

                                            if ((str_ExpedienteCab.ParteNombre == null) && (Convert.ToInt32(str_ExpedienteCab.TramiteID) == OPOSICIONES_ID))
                                                throw new Exception("El trámite no tiene definido el nombre de la parte");
                                        }

                                        #endregion Salvar datos de Cabecera
                                        cab = 1;
                                    }

                                    #region Inserción de Merge_Expediente
                                    if (!drDetPreMerge.MeID.HasValue) //|| (drDetPreMerge.Anulado.HasValue && (bool)drDetPreMerge.Anulado.Value))
                                    {
                                        Merge_Expediente me = new Merge_Expediente();

                                        if (item.Origen == ORIGEN_MARCAS)
                                        {
                                            me.ExpedienteID = drDetPreMerge.ExpedienteID;
                                            me.ExpedienteExtID = null;
                                        }
                                        else if (item.Origen == ORIGEN_OTRAS)
                                        {
                                            me.ExpedienteID = null;
                                            me.ExpedienteExtID = drDetPreMerge.ExpedienteID;
                                        }
                                        me.TramiteID = drDetPreMerge.TramiteID;
                                        me.MergeID = item.MergeID.Value;
                                        me.FuncionarioID = this.UsuarioID;
                                        me.Fecha = System.DateTime.Now;

                                        if (drDetPreMerge.ExpedientePadreID_pr.HasValue)
                                        {
                                            me.EnTramite = this.esEnTramite(drDetPreMerge.ExpedientePadreID_pr.Value);//, dr.Cells[CAMPO_ORIGEN].Value.ToString());
                                            me.ExpedienteIDPadre = drDetPreMerge.ExpedientePadreID_pr.Value;
                                        }
                                        else
                                        {
                                            me.EnTramite = false;
                                            me.ExpedienteIDPadre = null;
                                        }

                                        me.Generado = false;
                                        me.Anulado = false;
                                        me.Terminado = false;
                                        me.MergeDocID = null;

                                        context.Merge_Expediente.Add(me);
                                        context.SaveChanges();

                                        #region Actualizar Datos de la grilla
                                        drDetPreMerge.MeID = me.ID;
                                        drDetPreMerge.ExpedienteIDPadre = me.ExpedienteIDPadre;
                                        //drDetPreMerge.EnTramite = me.EnTramite;
                                        #endregion Actualizar Datos de la grilla
                                        //throw new Exception("Just testing");
                                    }

                                    #endregion Inserción de Merge_Expediente

                                    if (listaCotizacionesCabID != "")
                                        listaCotizacionesCabID += ",";

                                    listaCotizacionesCabID += drDetPreMerge.CotizacionCabID.Value.ToString();
                                }


                                Merge_Expediente mExpe = context.Merge_Expediente.First(a => a.ID == drDetPreMerge.MeID.Value);
                                //mExpe.MergeDocID = null;// mDoc.ID;
                                if ((item.FacturaLocal.HasValue) && (item.FacturaLocal.Value))
                                    mExpe.MergeDocID = null;
                                else
                                    mExpe.MergeDocID = mDoc.ID;
                                
                                mExpe.Generado = true;

                                if (this.rbMarcas.Checked)
                                {
                                    item.Generado = true;
                                    item.NroPresupuesto = NroPresupuesto;

                                    if ((item.FacturaLocal.HasValue) && (item.FacturaLocal.Value))
                                        item.MergeDocID = null;
                                    else
                                        item.MergeDocID = mDoc.ID;

                                    this.ListaDetallePresupuesto.First(a => a.ExpedienteID == drDetPreMerge.ExpedienteID).Generado = true;
                                    this.ListaDetallePresupuesto.First(a => a.ExpedienteID == drDetPreMerge.ExpedienteID).MergeDocID = mDoc.ID;
                                }
                                else if (this.rbHI.Checked)
                                {
                                    if (item.OrdenTrabajoID.HasValue)
                                    {
                                        int OrdenTrabajoID = item.OrdenTrabajoID.Value;
                                        ((List<CotizacionesParaPresupuestosType>)this.dgvDeudas.DataSource).First(a => a.OrdenTrabajoID == OrdenTrabajoID).Generado = true;
                                        ((List<CotizacionesParaPresupuestosType>)this.dgvDeudas.DataSource).First(a => a.OrdenTrabajoID == OrdenTrabajoID).NroPresupuesto = NroPresupuesto;
                                    }
                                    else
                                    {
                                        int ExpedienteID = item.ExpedienteID.Value;
                                        ((List<CotizacionesParaPresupuestosType>)this.dgvDeudas.DataSource).First(a => a.ExpedienteID == ExpedienteID).Generado = true;
                                        ((List<CotizacionesParaPresupuestosType>)this.dgvDeudas.DataSource).First(a => a.ExpedienteID == ExpedienteID).NroPresupuesto = NroPresupuesto;
                                    }
                                    this.ListaDetallePresupuesto.First(a => a.ExpedienteID == drDetPreMerge.ExpedienteID).NroPresupuesto = NroPresupuesto;

                                    if ((item.FacturaLocal.HasValue) && (item.FacturaLocal.Value))
                                        this.ListaDetallePresupuesto.First(a => a.ExpedienteID == drDetPreMerge.ExpedienteID).MergeDocID = null;// mDoc.ID;
                                    else
                                        this.ListaDetallePresupuesto.First(a => a.ExpedienteID == drDetPreMerge.ExpedienteID).MergeDocID = mDoc.ID;

                                    
                                    this.ListaDetallePresupuesto.First(a => a.ExpedienteID == drDetPreMerge.ExpedienteID).Generado = true;
                                }
                            }
                            #endregion Actualizar Merge_Expediente con referencias

                            #region Cálculos para clientes locales
                            if ((item.FacturaLocal.HasValue) && (item.FacturaLocal.Value))
                            {
                                int i = 0;
                                total = 0;
                                decimal gasto = 0;
                                decimal recargo = 0;
                                decimal descuento = 0;
                                decimal impuesto = 0;
                                
                                listadoTarifas = context.RepHojaCotizacion(listaCotizacionesCabID,
                                                                               this.rbMarcas.Checked ? "A" : "H",
                                                                               item.TramiteID.Value).ToList();

                                foreach (var fila in listadoTarifas)
                                {
                                    string descripcionTarifa = "";
                                    if (item.IdiomaID == IDIOMA_ESPANOL)
                                    {
                                        if ((fila.TextoEspanol == null) || (fila.TextoEspanol == ""))
                                        {
                                            throw new Exception("La tarifa: " +
                                                                fila.TarifaDescripcion +
                                                                "(" + fila.TarifaID.Value.ToString() + ") " +
                                                                "no tiene etiqueta definida para el idioma español.");
                                        }
                                        descripcionTarifa = fila.TextoEspanol;
                                    }
                                    else
                                    {
                                        if ((fila.TextoIngles == null) || (fila.TextoIngles == ""))
                                        {
                                            throw new Exception("La tarifa: " +
                                                                fila.TarifaDescripcion +
                                                                "(" + fila.TarifaID.Value.ToString() + ") " +
                                                                "no tiene etiqueta definida para el idioma inglés.");
                                        }
                                        descripcionTarifa = fila.TextoIngles;
                                    }

                                    total += fila.Neto.Value;
                                    gasto += fila.Gasto.Value;
                                    recargo += fila.Recargo.Value;
                                    descuento += fila.Descuento.Value;
                                    impuesto += fila.Impuesto.Value;
                                    i++;

                                    DetalleTarifasPresupuestoType det = new DetalleTarifasPresupuestoType();
                                    det.DetalleDescripcion = descripcionTarifa;
                                    det.DetalleMonto = fila.PrecioUnitario.Value * fila.Cantidad.Value;//fila.Neto.Value;
                                    listaDetallePresup.Add(det);
                                }

                                if ((gasto > 0) || (impuesto > 0) || (recargo > 0))
                                {
                                    total += gasto + impuesto + recargo;

                                    #region Obtener Descripción de Gastos
                                    pp_partepresupuesto pp = new pp_partepresupuesto();
                                    try
                                    {
                                        int TramiteID = item.TramiteID.Value;
                                        pp = context.pp_partepresupuesto.First(a => a.pp_tramiteid == TramiteID);
                                    }
                                    catch (InvalidOperationException)
                                    {
                                        throw new Exception("Modelo de documento no definido para el trámite: " + item.TramiteDescrip);
                                    }

                                    DescripcionGastos = item.IdiomaID == IDIOMA_ESPANOL ? pp.pp_descripciongastosesp : pp.pp_descripciongastosing;

                                    if (DescripcionGastos == "")
                                        DescripcionGastos = item.IdiomaID == IDIOMA_ESPANOL ? DESCRIPCION_GASTOS_ESP : DESCRIPCION_GASTOS_ING;
                                    #endregion Obtener Descripción de Gastos

                                    DetalleTarifasPresupuestoType det = new DetalleTarifasPresupuestoType();
                                    det.DetalleDescripcion = DescripcionGastos;
                                    det.DetalleMonto = gasto + impuesto + recargo;
                                    listaDetallePresup.Add(det);
                                }

                                if (descuento > 0)
                                {
                                    DetalleTarifasPresupuestoType det = new DetalleTarifasPresupuestoType();
                                    det.DetalleDescripcion = "Descuentos";
                                    det.DetalleMonto = descuento * -1;
                                    listaDetallePresup.Add(det);
                                }
                            }
                            #endregion Cálculos para clientes locales

                            #region Guardar Cabecera de Presupuesto
                            pc_presupuestocab pCab = new pc_presupuestocab();

                            if ((item.FacturaLocal.HasValue) && (!item.FacturaLocal.Value))
                            {
                                pCab.pc_mergedocid = mDoc.ID;
                                pCab.pc_nropresupuesto = NroPresupuesto;
                            }
                            else
                            {
                                pCab.pc_mergedocid = null;
                                pCab.pc_nropresupuesto = null;
                            }

                            pCab.pc_fechageneracion = fechaGeneracion;
                            pCab.pc_tramiteid = Convert.ToInt32(str_ExpedienteCab.TramiteID);
                            pCab.pc_clienteid = str_ExpedienteCab.ClienteID;

                            if (str_ExpedienteCab.AtencionID > 0)
                                pCab.pc_atencionid = str_ExpedienteCab.AtencionID;

                            pCab.pc_monedaid = item.MonedaID.Value;//listadoTarifas.First().MonedadID;
                            pCab.pc_total = total;
                            pCab.pc_saldo = total;
                            
                            if (str_ExpedienteCab.AreaID > 0)
                                pCab.pc_areaid = str_ExpedienteCab.AreaID;

                            pCab.pc_enviadopor = str_ExpedienteCab.EnviadoPorID;
                            pCab.pc_autorizadopor = str_ExpedienteCab.AprobadoPorID;
                            pCab.pc_estado = ESTADO_ACTIVO;
                            pCab.pc_partenombre = str_ExpedienteCab.ParteNombre;
                            pCab.pc_contrapartenombre = str_ExpedienteCab.ContraparteNombre;
                            pCab.pc_origen = item.Origen;
                            
                            context.pc_presupuestocab.Add(pCab);
                            #endregion Guardar Cabecera de Presupuesto

                            #region Guardar Detalle de Presupuesto
                            foreach (var tarifa in listaDetallePresup)
                            {
                                pd_presupuestodetalle pDet = new pd_presupuestodetalle();
                                pDet.pd_presupuestocabid = pCab.pc_presupuestocabid;
                                pDet.pd_detalledescripcion = tarifa.DetalleDescripcion;
                                pDet.pd_detallemonto = tarifa.DetalleMonto;
                                context.pd_presupuestodetalle.Add(pDet);
                            }
                            #endregion Guardar Detalle de Presupuesto

                            #region Guardar Cotizaciones Asociadas al Presupuesto
                            foreach (string cotID in listaCotizacionesCabID.Split(','))
                            {
                                cp_cotizacionesxpresup cPresup = new cp_cotizacionesxpresup();
                                cPresup.cp_presupuestocabid = pCab.pc_presupuestocabid;
                                cPresup.cp_cotizacionid = Convert.ToInt32(cotID);
                                context.cp_cotizacionesxpresup.Add(cPresup);
                            }
                            #endregion Guardar Cotizaciones Asociadas al Presupuesto
                            context.SaveChanges();

                            #region Guardar PresupuestoCabxMergeExpediente
                            foreach (var drDetPreMerge in DetallesProceso)
                            {
                                pm_pcabxmergeexpe pCabXmExpe = new pm_pcabxmergeexpe();
                                pCabXmExpe.pm_mergeexpedienteid = drDetPreMerge.MeID.Value;
                                pCabXmExpe.pm_presupuestocabid = pCab.pc_presupuestocabid;
                                context.pm_pcabxmergeexpe.Add(pCabXmExpe);
                            }
                            #endregion Guardar PresupuestoCabxMergeExpediente


                            context.SaveChanges();
                            #endregion Guardar en BD

                            #region Eliminar Archivo
                            //System.IO.File.Delete(@path);
                            #endregion Eliminar Archivo

                            #region Informar Resultado Exitoso
                            if (this.rbMarcas.Checked)
                            {
                                item.ErrMsg = OK;
                            }
                            else if (this.rbHI.Checked)
                            {
                                if (item.OrdenTrabajoID.HasValue)
                                {
                                    int OrdenTrabajoID = item.OrdenTrabajoID.Value;
                                    ((List<CotizacionesParaPresupuestosType>)this.dgvDeudas.DataSource).First(a => a.OrdenTrabajoID == OrdenTrabajoID).ErrMsg = OK;
                                }
                                else
                                {
                                    int ExpedienteID = item.ExpedienteID.Value;
                                    ((List<CotizacionesParaPresupuestosType>)this.dgvDeudas.DataSource).First(a => a.ExpedienteID == ExpedienteID).ErrMsg = OK;
                                }

                            }
                            dbContextTransaction.Commit();
                            cntGenerados++;
                            
                            #endregion Informar Resultado Exitoso
                        }
                        catch (DbEntityValidationException e)
                        {
                            #region Manejo de errores

                            dbContextTransaction.Rollback();
                            //this.timer1.Stop();
                            existeError = true;

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
                            
                            if (this.rbMarcas.Checked)
                            {
                                item.ErrMsg = "Error de validación en BD: " + error + Environment.NewLine + sError;
                            }
                            else if (this.rbHI.Checked)
                            {
                                if (item.OrdenTrabajoID.HasValue)
                                {
                                    int OrdenTrabajoID = item.OrdenTrabajoID.Value;
                                    ((List<CotizacionesParaPresupuestosType>)this.dgvDeudas.DataSource).First(a => a.OrdenTrabajoID == OrdenTrabajoID).ErrMsg = "Error de validación en BD: " + error + Environment.NewLine + sError;
                                }
                                else
                                {
                                    int ExpedienteID = item.ExpedienteID.Value;
                                    ((List<CotizacionesParaPresupuestosType>)this.dgvDeudas.DataSource).First(a => a.ExpedienteID == ExpedienteID).ErrMsg = "Error de validación en BD: " + error + Environment.NewLine + sError;
                                }

                            }
                            #endregion Manejo de errores

                            continue;
                        }
                        catch (Exception ex)
                        {
                            #region Manejo de errores
                            dbContextTransaction.Rollback();
                            //this.timer1.Stop();
                            existeError = true;

                            string errMsg = ex.Message;
                            bool errorSQL = false;
                            if (ex.InnerException != null)
                            {
                                if (ex.InnerException.InnerException.Message.IndexOf(IX_PC_NROPRESUPUESTO) > -1)
                                {
                                    errorSQL = true;
                                    errMsg = "Nro. de Presupuesto duplicado no se puede continuar la generación.";
                                    System.IO.File.Delete(path);
                                           
                                }
                                errMsg += Environment.NewLine
                                          + ex.InnerException.InnerException.Message;

                            }
                            
                            if (this.rbMarcas.Checked)
                            {
                                item.ErrMsg = "Error: " + errMsg;

                                if (errorSQL)
                                {
                                    item.NroPresupuesto = null;
                                    item.Generado = false;
                                }
                            }
                            else if (this.rbHI.Checked)
                            {
                                if (item.OrdenTrabajoID.HasValue)
                                {
                                    int OrdenTrabajoID = item.OrdenTrabajoID.Value;
                                    ((List<CotizacionesParaPresupuestosType>)this.dgvDeudas.DataSource).First(a => a.OrdenTrabajoID == OrdenTrabajoID).ErrMsg = "Error: " + errMsg;

                                    if (errorSQL)
                                    {
                                        ((List<CotizacionesParaPresupuestosType>)this.dgvDeudas.DataSource).First(a => a.OrdenTrabajoID == OrdenTrabajoID).NroPresupuesto = null;
                                        ((List<CotizacionesParaPresupuestosType>)this.dgvDeudas.DataSource).First(a => a.OrdenTrabajoID == OrdenTrabajoID).Generado = false;
                                    }
                                }
                                else
                                {
                                    int ExpedienteID = item.ExpedienteID.Value;
                                    ((List<CotizacionesParaPresupuestosType>)this.dgvDeudas.DataSource).First(a => a.ExpedienteID == ExpedienteID).ErrMsg = "Error: " + errMsg;

                                    if (errorSQL)
                                    {
                                        ((List<CotizacionesParaPresupuestosType>)this.dgvDeudas.DataSource).First(a => a.ExpedienteID == ExpedienteID).NroPresupuesto = null;
                                        ((List<CotizacionesParaPresupuestosType>)this.dgvDeudas.DataSource).First(a => a.ExpedienteID == ExpedienteID).Generado = false;
                                    }
                                }

                            }
                            #endregion Manejo de errores

                            continue;
                        }
                    }
                }
            }
            #endregion Iteración Principal        
            //this.timer1.Stop();
            this.ProcesoTerminado = true;
        }
        #endregion Proceso

        private void dgvCotizaciones_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void btnActualizarGrilla_Click(object sender, EventArgs e)
        {
            this.GetCotizacionesCab();
        }

        private void btnActualizarConBD_Click(object sender, EventArgs e)
        {
            byte [] binaryFile;
            string nropresupuesto = "";
            //string w_archivoExt = @"*.doc;*.docx";
            bool success = false;

            string[] extensions = new string[] { @"*.docx", @"*.doc" };
            DirectoryInfo di = new DirectoryInfo(w_directorio_trabajo);

            foreach (string ext in extensions)
            {
                #region Proceso
                //System.IO.FileInfo[] archivos = di.GetFiles(w_archivoExt);
                System.IO.FileInfo[] archivos = di.GetFiles(ext);

                using (var context = new BerkeDBEntities())
                {
                    foreach (System.IO.FileInfo archNext in archivos)
                    {
                        using (var dbContextTransaction = context.Database.BeginTransaction())
                        {
                            try
                            {
                                nropresupuesto = archNext.Name.Replace(ext.Substring(1, ext.Length - 1), "").Split('-')[1];

                                pc_presupuestocab pCab = context.pc_presupuestocab.First(a => a.pc_nropresupuesto == nropresupuesto);
                                int MergeDocID = pCab.pc_mergedocid.Value;
                                MergeDoc mDoc = context.MergeDoc.First(a => a.ID == MergeDocID);

                                binaryFile = Berke.Libs.Base.Helpers.Files.GetBytesFromFile(@w_directorio_trabajo + @"\" + archNext.Name);
                                mDoc.Contenido = binaryFile;

                                context.SaveChanges();

                                System.IO.File.Delete(@w_directorio_trabajo + @"\" + archNext.Name);

                                dbContextTransaction.Commit();
                                success = true;
                            }
                            catch (Exception ex)
                            {
                                dbContextTransaction.Rollback();

                                MessageBox.Show("Ocurrió un error al procesar el guardado: Archivo: " + archNext.Name
                                                + ex.Message + Environment.NewLine
                                                + ex.InnerException,
                                                "Error al guardar los datos",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Stop);
                            }
                        }
                    }
                }
                #endregion Proceso
            }

            if (success)
            {
                MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }  
            
		}

        

        private void rbTodo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbRango_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbAl_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dtpFechaAl_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbDeudasA_TextChanged(object sender, EventArgs e)
        {
            this.CalcularFechaDesde();
        }

        private void cbDeudasA_GotFocus(object sender, EventArgs e)
        {
            this.rbDeudasA.Checked = true;
            this.CalcularFechaDesde();
        }

        private void CalcularFechaDesde()
        {
            if (this.cbDeudasA.Text.Trim() != String.Empty)
            {
                Int32 d = Convert.ToInt32(this.cbDeudasA.Text) * -1;
                const string RANGO_FORMAT = "Deudas vencidas al {0}";
                this.lblRango.Text = String.Format(RANGO_FORMAT, System.DateTime.Now.AddDays(d).ToShortDateString());
                this.lblRango.Visible = true;
            }
        }

        private void cbReclamarEn_GotFocus(object sender, EventArgs e)
        {
            this.rbReclamarEn.Checked = true;
            this.CalcularFechaReclamarEn();
        }

        private void CalcularFechaReclamarEn()
        {
            if ((this.cbReclamarEn.Text != null) && (this.cbReclamarEn.Text.Trim() != String.Empty))
            {
                Int32 d = Convert.ToInt32(this.cbReclamarEn.Text);
                const string RANGO_RECLAMO = "Reclamar nuevamente el {0}";
                this.lblReclamarEn.Text = String.Format(RANGO_RECLAMO, System.DateTime.Now.AddDays(d).ToShortDateString());
                this.lblReclamarEn.Visible = true;
            }
            else
            {
                this.lblReclamarEn.Text = String.Empty;
                this.lblReclamarEn.Visible = false;
            }
        }

        private void cbReclamarEn_TextChanged(object sender, EventArgs e)
        {
            this.CalcularFechaReclamarEn();
        }
   }
}