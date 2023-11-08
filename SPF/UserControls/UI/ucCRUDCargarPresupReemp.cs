#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

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
using System.Data.Objects.DataClasses;

using SPF.Classes;
using Microsoft.Reporting.WebForms;
using SPF.Forms.UI;

#endregion

namespace SPF.UserControls.UI
{
    public partial class ucCRUDCargarPresupReemp : ucBaseForm2015
    {
        #region Variables
        FSeleccionarPresupuestoAReemp fSeleccionPresupAsoc;
        frmPickBase fPickCliente;
        frmPickBase fPickEnviadoPor;
        frmPickBase fPickAutorizadoPor;
        frmPickBase fPickAtencion;
        CheckBox headerCheckBox;
        Cliente clienteDS;
        #endregion Variables

        #region Constantes
        private const string CAMPO_PRESUPUESTOCABID = "PresupuestoCabID";
        private const string CAMPO_NRODOCUMENTO = "NroDocumento";
        private const string CAMPO_FECHADOCUMENTO = "FechaDocumento";
        private const string CAMPO_MONTO = "MontoDocumento";
        private const string CAMPO_SALDO = "SaldoDocumento";
        private const string CAMPO_SELECCIONAR = "Seleccionar";
        private const string CAMPO_CLIENTEID = "ClienteID";
        private const string CAMPO_CLIENTENOMBRE = "ClienteNombre";
        private const string CAMPO_ESTADODOCUMENTO = "EstadoDocumento";
        private const string CAMPO_DESCRIPCION = "Descripcion";
        private const string CAMPO_TRAMITEDESCRIP = "TramiteDescrip";
        private const string CAMPO_MONEDAABREV = "MonedaAbrev";
        private const string CAMPO_MONEDADESCRIP = "MonedaDescrip";

        private const string FORMATO_MONEDA_GUARANIES_GRILLA = "N0";
        private const string FORMATO_MONEDA_OTROS_GRILLA = "N2";
        private const string FORMATO_DECIMAL_BROWSE = "{0:N2}";
        private const string FORMATO_SIN_DECIMAL_BROWSE = "{0:N0}";
        private const string MONEDA_GUARANIES = "G";

        private const int PRESUP_MERGEID = 6;
        public const int IDIOMA_INGLES = 1;
        public const int IDIOMA_ESPANOL = 2;
        private const string DOLLARS = "DOLLARS";
        private const string DOLARES = "DOLARES";
        public const string MI_ENTER = "\r\n";
        private const string NEWLINEXML = "<w:br></w:br>";
        private const string DESCRIPCION_GASTOS_ING = "Expenses (Including: Taxes, official fees, publication and any other expenses)";
        private const string DESCRIPCION_GASTOS_ESP = "Gastos (Incluye: impuesto, tasa, publicación y otros gastos)";
        private const string DESCRIPCION_DESCUENTOS_ING = "Discounts";
        private const string DESCRIPCION_DESCUENTOS_ESP = "Descuentos";
        private const string PLANTILLA_PRESUPUESTO_MARCAS = "M8";
        private const string PLANTILLA_PRESUPUESTO_SPF_ESP = "PB";
        private const string PLANTILLA_PRESUPUESTO_SPF_PRUEBAS_ESP = "PBT";
        private const string PLANTILLA_PRESUPUESTO_SPF_CON_SELLO_TABLA_UNICA_ESP = "PBT_T";
        private const string PLANTILLA_PRESUPUESTO_SPF_CON_SELLO_TABLA_UNICA_ING = "PBT1_T";
        private const string PLANTILLA_PRESUPUESTO_SPF_ING = "PB1";

        private const string ESTADO_ANULADO = "N";
        private const string ORIGEN_MARCAS = "M";
        private const string ORIGEN_OTROS = "O";
        private const string ACTA = "A";
        private const string SI = "S";
        private const string NO = "N";
        private const int OPOSICIONES_ID = 29;
        private const int LONGITUD_PADDING = 126;
        private const int VIA_E_EMAIL = 4;
        private string w_directorio_trabajo = "";
        #endregion Constantes

        #region Propiedades
        public Cliente ClienteDS
        {
            get { return this.clienteDS; }
            set { this.clienteDS = value; }
        }
        #endregion Propiedades

        public ucCRUDCargarPresupReemp()
        {
            InitializeComponent();
        }

        public ucCRUDCargarPresupReemp(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();

            w_directorio_trabajo = @VWGContext.Current.Session["PresupFolderURL"].ToString();

            #region Redimensionar Panel de Grilla de Detalles de Factura según navegador
            //if (Context.HttpContext.Request.Browser.Browser != IE_BROWSER)
            //    this.pnlDetalle.Height = 230;
            //else
            //    this.pnlDetalle.Height = 165;
            #endregion Redimensionar Panel de Grilla de Detalles de Factura según navegador

            this.DBContext = dbContext;
            this.Titulo = Titulo;
            //this.UsuarioID = Convert.ToInt32(VWGContext.Current.Session["UsuarioID"].ToString());
            
            //lFacturas = new List<FacturaAllType>();

            //lFacturas = (from fc in this.DBContext.fc_facturacabecera
            //             join fd in this.DBContext.fd_facturadetalle
            //                 on fc.fc_facturacabeceraid equals fd.fd_facturacabeceraid
            //             join mon in this.DBContext.Moneda
            //                 on fc.fc_monedaid equals mon.ID
            //             join AudFc in this.DBContext.Audit_fc_facturacabecera
            //                 on fc.fc_facturacabeceraid equals AudFc.fc_facturacabeceraid
            //             join cli in this.DBContext.Cliente
            //                 on fc.fc_clienteid equals cli.ID into fc_cli
            //                 from cli in fc_cli.DefaultIfEmpty()
            //             join uAud in this.DBContext.Usuario
            //                 on AudFc.Audit_User.Substring(6, AudFc.Audit_User.Length) equals uAud.Usuario1
            //             join ti in this.DBContext.ti_timbrado
            //                 on fc.fc_timbradoid equals ti.ti_timbradoid
            //             //join pp in this.DBContext.pp_pagopresupuesto
            //             //    on fd.fd_presupuestocabid equals pp.pp_presupuestocabid into fd_pp
            //             //    from pp in fd_pp.DefaultIfEmpty()
            //             select new FacturaAllType
            //             {
            //                 //Cabecera
            //                 FacturaFecha = fc.fc_fechafactura,
            //                 FacturaCabeceraID = fc.fc_facturacabeceraid,
            //                 FacturaTimbradoID = fc.fc_timbradoid,
            //                 FacturaTimbradoHojaSuelta = ti.ti_facthojasuelta,
            //                 FacturaNro = fc.fc_nrofactura,
            //                 Anulado = fc.fc_anulado,
            //                 ClienteID = fc.fc_clienteid,
            //                 ClienteNombre = fc.fc_clientenombre,
            //                 ClienteIdiomaID = cli.IdiomaID,
            //                 Direccion = fc.fc_direccion,
            //                 FacturaTipo = fc.fc_tipofactura,
            //                 RUC = fc.fc_ruc,
            //                 NroRemision = fc.fc_nroremision,
            //                 Telefono = fc.fc_telefono,
            //                 MonedaID = fc.fc_monedaid,
            //                 MonedaAbrev = mon.AbrevMoneda,
            //                 MonedaDescripcion = mon.Descripcion,
            //                 TotalExentas = fc.fc_totalexentas,
            //                 TotalIVA5 = fc.fc_totaliva5,
            //                 TotalIVA10 = fc.fc_totaliva10,
            //                 TotalIVA = fc.fc_totaliva,
            //                 LiqIVA5 = fc.fc_liqiva5,
            //                 LiqIVA10 = fc.fc_liqiva10,
            //                 TotalLiqIVA = fc.fc_totaliva,
            //                 TotalFactura = fc.fc_total,
            //                 TotalLetras = fc.fc_totalletras,
            //                 DocumentosAsociados = fc.fc_documentosasoc,
            //                 UsuarioCargaID = uAud.ID,
            //                 UsuarioCargaNombre = uAud.NombrePila,
            //                 AuditOperacion = AudFc.Audit_Operacion,
            //                 TieneAutorizacionVigente = this.DBContext.GetAutorizacionPorDocumentoID(TIPODOCUMENTO_FACTURA_CLIENTE,
            //                                                                                         fc.fc_facturacabeceraid,
            //                                                                                         this.UsuarioID).FirstOrDefault().Value,
            //                 //Detalles
            //                 Cantidad = fd.fd_cantidad,
            //                 Descripcion = fd.fd_descripcion,
            //                 PrecioUnitario = fd.fd_preciounitario,
            //                 Exentas = fd.fd_exentas,
            //                 CincoPorciento = fd.fd_cincoporciento,
            //                 DiezPorciento = fd.fd_diezporciento,
            //                 PresupuestoCabID = fd.fd_presupuestocabid,
            //                 BoletaDepositoNro = fd.fd_nroboletadeposito  //this.DBContext.GetDatosBoletaDepCobro(fd.fd_presupuestocabid).FirstOrDefault().NroBoletaDep
            //                 //CobroAnulado = pp.pp_anulado
            //             })
            //             //.Where(b => b.AuditOperacion == AUDIT_OPERACION_INSERT && (b.CobroAnulado == null || (b.CobroAnulado.HasValue && !b.CobroAnulado.Value)))
            //             .Where(b => b.AuditOperacion == AUDIT_OPERACION_INSERT)
            //             //.Where(b => b.AuditOperacion == AUDIT_OPERACION_INSERT && !(b.CobroAnulado.HasValue && !b.CobroAnulado.Value))
            //             .OrderByDescending( a => a.FacturaCabeceraID )
            //             .Take(200)
            //             .ToList();

            //this.BindingSourceBase_ExportExcelGrid = lFacturas;
            ////this.LoadGridExportToExcel();

            //var query = (from item in lFacturas
            //             select new FacturaCabType
            //             {
            //                 //Cabecera
            //                 FacturaFecha = item.FacturaFecha,
            //                 FacturaCabeceraID = item.FacturaCabeceraID,
            //                 FacturaTimbradoID = item.FacturaTimbradoID,
            //                 FacturaTimbradoHojaSuelta = item.FacturaTimbradoHojaSuelta,
            //                 FacturaNro = item.FacturaNro,
            //                 Anulado = item.Anulado,
            //                 ClienteID = item.ClienteID,
            //                 ClienteNombre = item.ClienteNombre,
            //                 ClienteIdiomaID = item.ClienteIdiomaID,
            //                 Direccion = item.Direccion,
            //                 FacturaTipo = item.FacturaTipo,
            //                 RUC = item.RUC,
            //                 NroRemision = item.NroRemision,
            //                 Telefono = item.Telefono,
            //                 MonedaID = item.MonedaID,
            //                 MonedaAbrev = item.MonedaAbrev,
            //                 MonedaDescripcion = item.MonedaDescripcion,
            //                 TotalExentas = item.TotalExentas,
            //                 TotalIVA5 = item.TotalIVA5,
            //                 TotalIVA10 = item.TotalIVA10,
            //                 TotalIVA = item.TotalIVA,
            //                 LiqIVA5 = item.LiqIVA5,
            //                 LiqIVA10 = item.LiqIVA10,
            //                 TotalLiqIVA = item.TotalLiqIVA,
            //                 TotalFactura = item.TotalFactura,
            //                 TotalLetras = item.TotalLetras,
            //                 DocumentosAsociados = item.DocumentosAsociados,
            //                 UsuarioCargaID = item.UsuarioCargaID,
            //                 UsuarioCargaNombre = item.UsuarioCargaNombre,
            //                 AuditOperacion = item.AuditOperacion,
            //                 TieneAutorizacionVigente = item.TieneAutorizacionVigente
            //             })
            //             .GroupBy(x => new { x.FacturaCabeceraID }).Select(g => g.First()).ToList()
            //             .Take(50);

            //this.BindingSourceBase = query;

            //#region Especificar campos para filtro
            //this.SetFilter(CAMPO_FACTURACABECERAID, "Fact. Cab. ID", false);        
            //this.SetFilter(CAMPO_FACTURATIMBRADOID, "Timbrado");
            //this.SetFilter(CAMPO_FACTURATIPO, "Tipo Factura (C/R)");
            //this.SetFilter(CAMPO_FACTURATIPO, "Tipo Fact. Descrip.");
            //this.SetFilter(CAMPO_FACTURANRO, "N° Factura");
            //this.SetFilter(CAMPO_NROREMISION, "N° Remisión");
            //this.SetFilter(CAMPO_ANULADO, "Anulado (S/N)", false);
            //this.SetFilter(CAMPO_CLIENTEID, "Cliente ID", false);
            //this.SetFilter(CAMPO_CLIENTENOMBRE, "Cliente Nombre");
            //this.SetFilter(CAMPO_DIRECCION, "Cliente Dirección");
            //this.SetFilter(CAMPO_RUC, "Cliente RUC");
            //this.SetFilter(CAMPO_TELEFONO, "Cliente Teléf.");
            //this.SetFilter(CAMPO_MONEDAID, "Moneda ID", false);
            //this.SetFilter(CAMPO_MONEDADESCRIPCION, "Moneda Descrip.");
            //this.SetFilter(CAMPO_TOTALFACTURA, "Total Factura", false);
            //this.SetFilter(CAMPO_PRESUPUESTOCABID, "Presup. ID", false);
            //this.SetFilter(CAMPO_DOCUMENTOSASOCIADOS, "Documentos Asoc.");
            //this.SetFilter(CAMPO_BOLETADEPOSITONRO, "N° Boleta Dep.");
            //this.SetFilter(CAMPO_USUARIOCARGAID, "Gen. Por ID", false);
            //this.SetFilter(CAMPO_USUARIOCARGANOMBRE, "Gen. Por Nombre");

            //this.TituloBuscador = "Buscar Facturas";
            //#endregion Especificar campos para filtro

            #region Inicializar TextSearchBoxes
            this.tSBCliente.KeyMemberWidth = 50;
            this.tSBCliente.ToolTip = "Elegir Cliente";
            this.tSBCliente.AceptarClick += tSBCliente_AceptarClick;
            this.tSBCliente.KeyMemberTextChanged += tSBCliente_KeyMemberTextChanged;

            this.tSBEnviadoPor.KeyMemberWidth = 50;
            this.tSBEnviadoPor.ToolTip = "Elegir Persona que Solicita";
            this.tSBEnviadoPor.AceptarClick += tSBEnviadoPor_AceptarClick;
            this.tSBEnviadoPor.KeyMemberTextChanged += tSBEnviadoPor_KeyMemberTextChanged;

            this.tSBAutorizadoPor.KeyMemberWidth = 50;
            this.tSBAutorizadoPor.ToolTip = "Elegir Persona que Autoriza";
            this.tSBAutorizadoPor.AceptarClick += tSBAutorizadoPor_AceptarClick;
            this.tSBAutorizadoPor.KeyMemberTextChanged += tSBAutorizadoPor_KeyMemberTextChanged;

            this.tSBAtencion.KeyMemberWidth = 50;
            this.tSBAtencion.ToolTip = "Elegir Atención";
            this.tSBAtencion.AceptarClick += tSBAtencion_AceptarClick;
            this.tSBAtencion.SoloLectura = true;
            
            //this.tSBMoneda.KeyMemberWidth = 50;
            //this.tSBMoneda.ToolTip = "Elegir Moneda";
            //this.tSBMoneda.SoloLectura = false;
            //this.tSBMoneda.AceptarClick += tSBMoneda_AceptarClick;

            #endregion Inicializar TextSearchBoxes

            this.dgvDetPresupReemp.DataSource = new List<PresupSelReemp>();

            if (headerCheckBox == null)
                headerCheckBox = new CheckBox();

            //#region Datetime Picker
            //this.dtpFechaFactura.Format = DateTimePickerFormat.Short;
            //#endregion Datetime Picker

            //this.FormEditStatus = BROWSE;
            //#region Cargar Combo Serie
            //this.cargarCBSerieFactura();
            //#endregion Cargar Combo Serie

            //#region Ocultar Botones
            //this.tbbBorrar.Visible = false;
            //this.tbbEditar.Visible = false;
            //this.tbbImprimir.Visible = true;
            //this.tbbAnular.Visible = true;
            //#endregion Ocultar Botones

            //#region Asignación Eventos Deletados
            ////Asignar Evento de Validación de carga de campos
            //this.ValidarCamposEvent += ucCRUDPagoSolPago_ValidarCamposEvent;
            ////Asignar Evento para Guardar Registro
            //this.CRUDEvent += ucCRUDPagoSolPago_CRUDEvent;
            //#endregion Asignación Eventos Deletados

            //this.InsertActionMessage = "Se guardará e imprimirá la factura ¿Desea continuar?";
            //this.InsertActionCaption = "Generación de Factura";
        }
        #region Picks
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

            //if (this.tSBCliente.KeyMember != "")
            //{
            //    int clienteID = Convert.ToInt32(this.tSBCliente.KeyMember);
            //    List<Cliente> cli = this.DBContext.Cliente.Where(a => a.ID == clienteID).ToList();

            //    if (cli.Count > 0)
            //    {
            //        this.txtRazonSocialFactura.Text = cli.First().Nombre;
            //        this.txtRUC.Text = cli.First().RUC;
            //    }

            //}
        }

        private void tSBCliente_KeyMemberTextChanged(object sender, EventArgs e)
        {
            if ((!this.IsClosing) && (!this.IsCancelling) && (this.dgvDetPresupReemp.RowCount > 0))
            {
                string caption = "Información";
                string message = "Debido al cambio de cliente los presupuestos de la grilla se eliminaron de la carga.";

                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons,
                                MessageBoxIcon.Information);

                this.dgvDetPresupReemp.DataSource = new List<PresupSelReemp>();

                if (this.tSBCliente.KeyMember != string.Empty)
                {
                    int clienteID = Convert.ToInt32(this.tSBCliente.KeyMember);
                    Cliente cli = this.DBContext.Cliente.FirstOrDefault(a => a.ID == clienteID);
                    this.tSBCliente.KeyMember = cli.ID.ToString();
                    this.tSBCliente.DisplayMember = cli.Nombre;

                    this.ClienteDS = cli;
                }
            }
            else if ((!this.IsClosing) && (!this.IsCancelling))
            {
                if (this.tSBCliente.KeyMember != string.Empty)
                {
                    int clienteID = Convert.ToInt32(this.tSBCliente.KeyMember);
                    Cliente cli = this.DBContext.Cliente.FirstOrDefault(a => a.ID == clienteID);
                    this.tSBCliente.KeyMember = cli.ID.ToString();
                    this.tSBCliente.DisplayMember = cli.Nombre;

                    this.ClienteDS = cli;
                }
                else this.tSBCliente.Clear();
            }

            this.txtMonedaAbrev.Text = string.Empty;
            this.txtMonedaID.Text = string.Empty;
            this.txtTotal.Text = string.Empty;
            this.txtSaldo.Text = string.Empty;
            this.tSBEnviadoPor.Clear();
            this.tSBAutorizadoPor.Clear();
            this.tSBAtencion.Clear();
            this.FormatearGrillaDetPresup();
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

        private void tSBEnviadoPor_KeyMemberTextChanged(object sender, EventArgs e)
        {
            if ((!this.IsClosing) && (!this.IsCancelling))
            {
                if (this.tSBEnviadoPor.KeyMember != string.Empty)
                {
                    int enviadoPorID = Convert.ToInt32(this.tSBEnviadoPor.KeyMember);
                    Usuario enviadoPor = this.DBContext.Usuario.FirstOrDefault(a => a.ID == enviadoPorID);
                    this.tSBEnviadoPor.KeyMember = enviadoPor.ID.ToString();
                    this.tSBEnviadoPor.DisplayMember = enviadoPor.Nombre;
                }
                else this.tSBEnviadoPor.Clear();
            }
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

        private void tSBAutorizadoPor_KeyMemberTextChanged(object sender, EventArgs e)
        {
            if ((!this.IsClosing) && (!this.IsCancelling))
            {
                if (this.tSBAutorizadoPor.KeyMember != string.Empty)
                {
                    int autorizadoPorID = Convert.ToInt32(this.tSBAutorizadoPor.KeyMember);
                    Usuario autorizadoPor = this.DBContext.Usuario.FirstOrDefault(a => a.ID == autorizadoPorID);
                    this.tSBAutorizadoPor.KeyMember = autorizadoPor.ID.ToString();
                    this.tSBAutorizadoPor.DisplayMember = autorizadoPor.Nombre;
                }
                else this.tSBEnviadoPor.Clear();
            }
        }

        private void tSBAtencion_AceptarClick(object sender, EventArgs e)
        {
            if (this.tSBCliente.KeyMember == "")
            {
                MessageBox.Show("Debe ingresar un cliente válido.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (fPickAtencion == null)
            {
                fPickAtencion = new frmPickBase();
                fPickAtencion.AceptarFiltrarClick += fPickAtencion_AceptarFiltrarClick;
                fPickAtencion.FiltrarClick += fPickAtencion_FiltrarClick;
                fPickAtencion.Titulo = "Elegir Atención";
                fPickAtencion.CampoIDNombre = "AtencionID";
                fPickAtencion.CampoDescripNombre = "AtencionNombre";
                fPickAtencion.LabelCampoID = "ID";
                fPickAtencion.LabelCampoDescrip = "Nombre";
                fPickAtencion.NombreCampo = "Atención";
                fPickAtencion.PermitirFiltroNulo = true;
            }
            fPickAtencion.MostrarFiltro();
            fPickAtencion_FiltrarClick(sender, e);
        }

        private void fPickAtencion_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickAtencion != null)
            {
                int clienteID = Convert.ToInt32(this.tSBCliente.KeyMember);

                var query = (from at in this.DBContext.Atencion
                             select new AtencionType
                             {
                                 AtencionID = at.ID,
                                 AtencionNombre = at.Nombre,
                                 ClienteID = at.ClienteID
                             }).Where(a => a.ClienteID == clienteID);

                fPickAtencion.LoadData<AtencionType>(query.AsQueryable(), fPickAtencion.GetWhereString());
            }
        }

        private void fPickAtencion_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBAtencion.DisplayMember = fPickAtencion.ValorDescrip;
            this.tSBAtencion.KeyMember = fPickAtencion.ValorID;

            fPickAtencion.Close();
            fPickAtencion.Dispose();
        }
        #endregion Picks

        #region ReadOnly condicional
        protected override void Editable(bool editar)
        {
            this.dtpFechaGen.Enabled = !editar;
            this.txtFechaGen.ReadOnly = editar;
            this.btnAgregarDetalle.Enabled = !editar;
            this.btnEliminarDetalle.Enabled = !editar;
            this.tSBCliente.Editable = !editar;
            this.tSBEnviadoPor.Editable = !editar;
            this.tSBAutorizadoPor.Editable = !editar;
            this.tSBAtencion.Editable = !editar;
            this.headerCheckBox.Enabled = !editar;
        }
        #endregion ReadOnly condicional

        #region Limpiar Datos
        private void limpiarDatos()
        {
            foreach (Control ctrl in this.pnlDetCab.Controls)
            {
                if (ctrl.GetType() == typeof(TextBox))
                {
                    ctrl.Text = string.Empty;
                }
            }

            this.tSBCliente.Clear();
            this.tSBEnviadoPor.Clear();
            this.tSBAutorizadoPor.Clear();
            this.tSBAtencion.Clear();
            //this.dgvDetPresupReemp.DataSource = null;
            this.dgvDetPresupReemp.DataSource = new List<PresupSelReemp>();
            this.FormatearGrillaDetPresup();
        }
        #endregion ReadOnly condicional

        protected override void tbbNuevo_Click(object sender, EventArgs e)
        {
            base.tbbNuevo_Click(sender, e);
            this.limpiarDatos();
            this.dtpFechaGen.Value = DateTime.Now;
            this.tSBCliente.Focus();
        }

        protected override void tbbCancelar_Click(object sender, EventArgs e)
        {
            base.tbbCancelar_Click(sender, e);
            
            if (this.LastDGVIndex > -1)
            {
                //this.Cargar (this.dgvListadoABM.Rows[this.LastDGVIndex]);
            }
            else
            {
                this.limpiarDatos();
                this.IsCancelling = false;
            }
        }

        private void dtpFechaGen_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaGen.Text = this.dtpFechaGen.Value.ToShortDateString();
        }

        private void dtpFechaGen_Click(object sender, EventArgs e)
        {
            if (this.txtFechaGen.Text == string.Empty)
            {
                this.txtFechaGen.Text = ((DateTimePicker)sender).Value.ToShortDateString();
            }
            //MessageBox.Show(sender.ToString());
        }

        private string[] GetRangoFechas(DateTime fechaHasta)
        {
            List<string> Result = new List<string>();

            //DateTime fechaDesde = new DateTime(fecha.AddMonths(-3).Year, fecha.AddMonths(-3).Month, 1);
            //Result.Add(fechaDesde.ToShortDateString());

            //DateTime fechaHasta = new DateTime(fechaDesde.AddMonths(2).Year, fechaDesde.AddMonths(2).Month, DateTime.DaysInMonth(fechaDesde.AddMonths(2).Year, fechaDesde.AddMonths(2).Month));
            DateTime fechaDesde = new DateTime(fechaHasta.AddMonths(-3).Year, fechaHasta.AddMonths(-3).Month, DateTime.DaysInMonth(fechaHasta.AddMonths(-3).Year, fechaHasta.AddMonths(-3).Month));
            Result.Add(fechaDesde.ToShortDateString());
            Result.Add(fechaHasta.ToShortDateString());

            return Result.ToArray();
        }

        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            if ((this.tSBCliente.KeyMember == ""))
            {
                MessageBox.Show("Debe seleccionar un cliente.",
                               "Información",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return;
            }

            if ((this.txtFechaGen.Text == ""))
            {
                MessageBox.Show("Debe ingresar una fecha para el presupuesto.",
                               "Información",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return;
            }

            try
            {

                string[] rangoFechas = this.GetRangoFechas(Convert.ToDateTime(this.txtFechaGen.Text));

                if ((fSeleccionPresupAsoc == null) || (fSeleccionPresupAsoc.ClienteID.ToString() != tSBCliente.KeyMember))
                {
                    fSeleccionPresupAsoc = new FSeleccionarPresupuestoAReemp(this.DBContext,
                                                                                "Selección de Presupuestos",
                                                                                rangoFechas[0],
                                                                                rangoFechas[1],
                                                                                Convert.ToInt32(this.tSBCliente.KeyMember),
                                                                                this.tSBCliente.DisplayMember);
                    fSeleccionPresupAsoc.AceptarClick += fSeleccionPresupAsoc_AceptarClick;
                }

                //fSeleccionPresupAsoc.ListaPresupuestos = this.txtPresupAsoc.Text.Replace(", ", ",");
                fSeleccionPresupAsoc.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + Environment.NewLine + ex.Message, "Información de Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void fSeleccionPresupAsoc_AceptarClick(object sender, EventArgs e)
        {
            this.SetValues();
        }

        private void SetValues()
        {
            List<PresupSelReemp> lista = new List<PresupSelReemp>();

            if (this.dgvDetPresupReemp.RowCount == 0)
            {
                lista = fSeleccionPresupAsoc.GetPresupuestosData();
                //this.dgvDetPresupReemp.DataSource = lista; //fSeleccionPresupAsoc.GetPresupuestosData();
                this.txtMonedaAbrev.Text = string.Empty;
                this.txtMonedaID.Text = string.Empty;
                this.txtTotal.Text = string.Empty;
                this.txtSaldo.Text = string.Empty;
                //this.tSBEnviadoPor.Clear();
                //this.tSBAutorizadoPor.Clear();
            }
            else
            {
                lista = (List<PresupSelReemp>)this.dgvDetPresupReemp.DataSource;
                lista.AddRange(fSeleccionPresupAsoc.GetPresupuestosData());
                //this.dgvDetPresupReemp.DataSource = lista.Distinct().ToList();
            }

            lista = lista.Distinct().ToList();

            if (lista.Count > 0)
            {
                int oMonedaCount = 0;
                int monedaID = lista.First().MonedaID;
                decimal sumMonto = 0;
                decimal sumSaldo = 0;

                //foreach (PresupSelReemp row in lista)
                int c = lista.Count;
                for(int i = 0; i < c; i++)
                {
                    if (monedaID == lista[i].MonedaID)
                    {
                        sumMonto += lista[i].MontoDocumento;
                        sumSaldo += lista[i].SaldoDocumento;
                    }
                    else
                    {
                        lista.Remove(lista[i]);
                        oMonedaCount++;
                        i--;
                        c--;
                    }
                }

                this.txtEstado.Text = "A = Abierto";
                this.txtMonedaID.Text = lista.First().MonedaID.ToString();
                this.txtMonedaAbrev.Text = lista.First().MonedaAbrev.ToString();
                this.txtTotal.Text = string.Format(lista.First().MonedaAbrev == MONEDA_GUARANIES ? FORMATO_SIN_DECIMAL_BROWSE : FORMATO_DECIMAL_BROWSE, sumMonto);
                this.txtSaldo.Text = string.Format(lista.First().MonedaAbrev == MONEDA_GUARANIES ? FORMATO_SIN_DECIMAL_BROWSE : FORMATO_DECIMAL_BROWSE, sumSaldo);

                if (this.tSBEnviadoPor.KeyMember.Trim() == string.Empty)
                {
                    this.tSBEnviadoPor.KeyMember = lista.First().SolicitadoPorID.ToString();
                    this.tSBEnviadoPor.DisplayMember = lista.First().SolicitadoPorNombre;
                }

                if (this.tSBAutorizadoPor.KeyMember.Trim() == string.Empty)
                {
                    this.tSBAutorizadoPor.KeyMember = lista.First().AutorizadoPorID.ToString();
                    this.tSBAutorizadoPor.DisplayMember = lista.First().AutorizadoPorNombre;
                }

                if ((this.tSBAtencion.KeyMember.Trim() == string.Empty) && (lista.First().AtencionID.HasValue))
                {
                    this.tSBAtencion.KeyMember = lista.First().AtencionID.ToString();
                    this.tSBAtencion.DisplayMember = lista.First().AtencionNombre;
                }

                this.dgvDetPresupReemp.DataSource = lista.Distinct().ToList();

                this.FormatearGrillaDetPresup();
                fSeleccionPresupAsoc.Close();

                if (oMonedaCount > 0)
                {
                    MessageBox.Show("Sólo puede seleccionar presupuestos de la misma moneda." + Environment.NewLine +
                                    "La moneda utilizada en la grilla es: " + lista.First().MonedaAbrev,
                                   "Información",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);

                }
            }
            else
            {
                this.txtMonedaID.Text = string.Empty;
                this.txtMonedaAbrev.Text = string.Empty;
                this.txtTotal.Text = string.Empty;
                this.txtSaldo.Text = string.Empty;
                this.tSBAtencion.Clear();
                this.tSBEnviadoPor.Clear();
                this.tSBAutorizadoPor.Clear();
                this.FormatearGrillaDetPresup();
            }
        }

        private void FormatearGrillaDetPresup()
        {
            foreach (DataGridViewColumn col in this.dgvDetPresupReemp.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            this.dgvDetPresupReemp.ReadOnly = false;
            this.dgvDetPresupReemp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetPresupReemp.ItemsPerPage = 11;
            this.dgvDetPresupReemp.ShowCellToolTips = true;
            this.dgvDetPresupReemp.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvDetPresupReemp.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvDetPresupReemp.DefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvDetPresupReemp.DefaultCellStyle.BackColor = Color.Transparent;

            this.dgvDetPresupReemp.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;

            int displayIndex = 0;

            this.dgvDetPresupReemp.Columns[CAMPO_TRAMITEDESCRIP].HeaderText = "Trámite";
            this.dgvDetPresupReemp.Columns[CAMPO_TRAMITEDESCRIP].Width = 200;
            this.dgvDetPresupReemp.Columns[CAMPO_TRAMITEDESCRIP].DisplayIndex = displayIndex;
            this.dgvDetPresupReemp.Columns[CAMPO_TRAMITEDESCRIP].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvDetPresupReemp.Columns[CAMPO_TRAMITEDESCRIP].Visible = true;
            displayIndex++;

            this.dgvDetPresupReemp.Columns[CAMPO_FECHADOCUMENTO].HeaderText = "Fec. Documento";
            this.dgvDetPresupReemp.Columns[CAMPO_FECHADOCUMENTO].Width = 120;
            this.dgvDetPresupReemp.Columns[CAMPO_FECHADOCUMENTO].DisplayIndex = displayIndex;
            this.dgvDetPresupReemp.Columns[CAMPO_FECHADOCUMENTO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvDetPresupReemp.Columns[CAMPO_FECHADOCUMENTO].Visible = true;
            displayIndex++;

            this.dgvDetPresupReemp.Columns[CAMPO_NRODOCUMENTO].HeaderText = "N° Documento";
            this.dgvDetPresupReemp.Columns[CAMPO_NRODOCUMENTO].Width = 120;
            this.dgvDetPresupReemp.Columns[CAMPO_NRODOCUMENTO].DisplayIndex = displayIndex;
            this.dgvDetPresupReemp.Columns[CAMPO_NRODOCUMENTO].Visible = true;
            displayIndex++;

            this.dgvDetPresupReemp.Columns[CAMPO_MONEDAABREV].HeaderText = "Moneda";
            this.dgvDetPresupReemp.Columns[CAMPO_MONEDAABREV].Width = 80;
            this.dgvDetPresupReemp.Columns[CAMPO_MONEDAABREV].DisplayIndex = displayIndex;
            this.dgvDetPresupReemp.Columns[CAMPO_MONEDAABREV].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvDetPresupReemp.Columns[CAMPO_MONEDAABREV].Visible = true;
            displayIndex++;

            this.dgvDetPresupReemp.Columns[CAMPO_MONTO].HeaderText = "Monto";
            this.dgvDetPresupReemp.Columns[CAMPO_MONTO].Width = 80;
            this.dgvDetPresupReemp.Columns[CAMPO_MONTO].DisplayIndex = displayIndex;
            this.dgvDetPresupReemp.Columns[CAMPO_MONTO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvDetPresupReemp.Columns[CAMPO_MONTO].Visible = true;
            displayIndex++;

            this.dgvDetPresupReemp.Columns[CAMPO_SALDO].HeaderText = "Saldo";
            this.dgvDetPresupReemp.Columns[CAMPO_SALDO].Width = 80;
            this.dgvDetPresupReemp.Columns[CAMPO_SALDO].DisplayIndex = displayIndex;
            this.dgvDetPresupReemp.Columns[CAMPO_SALDO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvDetPresupReemp.Columns[CAMPO_SALDO].Visible = true;
            displayIndex++;

            this.dgvDetPresupReemp.Columns[CAMPO_PRESUPUESTOCABID].HeaderText = "Presup. ID";
            this.dgvDetPresupReemp.Columns[CAMPO_PRESUPUESTOCABID].Width = 80;
            this.dgvDetPresupReemp.Columns[CAMPO_PRESUPUESTOCABID].DisplayIndex = displayIndex;
            this.dgvDetPresupReemp.Columns[CAMPO_PRESUPUESTOCABID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvDetPresupReemp.Columns[CAMPO_PRESUPUESTOCABID].Visible = true;
            displayIndex++;

            //Find the Location of Header Cell.
            Point headerCellLocation = this.dgvDetPresupReemp.Columns[0].HeaderCell.ContentBounds.Location;

            //Place the Header CheckBox in the Location of the Header Cell.
            headerCheckBox.Location = new Point(headerCellLocation.X + 48, headerCellLocation.Y + 3);
            headerCheckBox.BackColor = Color.White;
            headerCheckBox.Size = new Size(15, 15);
            headerCheckBox.ClientId = "headerChkPresupReemp";

            //Assign Click event to the Header CheckBox.
            headerCheckBox.Click += new EventHandler(HeaderCheckBox_Clicked);
            //headerCheckBox.CheckStateChanged += headerCheckBox_CheckStateChanged;
            this.pnlDetDetFill.Controls.Add(headerCheckBox);

            //Assign Click event to the DataGridView Cell.
            this.dgvDetPresupReemp.CellContentClick += new DataGridViewCellEventHandler(DataGridView_CellClick);
            //dataGridView1.CellContentClick += new DataGridViewCellEventHandler(DataGridView_CellClick);

            //Add a CheckBox Column to the DataGridView at the first position.
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.Width = 30;
            checkBoxColumn.Name = CAMPO_SELECCIONAR;
            checkBoxColumn.HeaderText = " ";
            checkBoxColumn.TrueValue = true;
            checkBoxColumn.FalseValue = false;

            this.dgvDetPresupReemp.Columns.Insert(0, checkBoxColumn);
        }

        protected override void FireEvent(Gizmox.WebGUI.Common.Interfaces.IEvent objEvent)
        {
            if (objEvent.Type == "headerCheckBoxValEvent")
            {
                this.SelectAll(objEvent["headerCheckBoxVal"]);
            }
            else
                base.FireEvent(objEvent);

        }

        private void SelectAll(string select)
        {
            bool isChecked = select == "true" ? true : false;

            foreach (DataGridViewRow row in this.dgvDetPresupReemp.Rows)
            {
                row.Cells[CAMPO_SELECCIONAR].Value = isChecked;
            }
        }

        private void HeaderCheckBox_Clicked(object sender, EventArgs e)
        {
            object[] jsParams = new object[2];
            jsParams[0] = this.ID.ToString();
            jsParams[1] = this.headerCheckBox.ID.ToString();
            VWGClientContext.Current.Invoke("getHeaderCheckBoxVal", jsParams);
            return;
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Check to ensure that the row CheckBox is clicked.
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                //Loop to verify whether all row CheckBoxes are checked or not.
                bool isChecked = true;
                foreach (DataGridViewRow row in this.dgvDetPresupReemp.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[CAMPO_SELECCIONAR].EditedFormattedValue) == false)
                    {
                        isChecked = false;
                        break;
                    }
                }
                headerCheckBox.Checked = isChecked;
            }
        }

        private void btnEliminarDetalle_Click(object sender, EventArgs e)
        {
            if (this.GetListaPresupuestos().Count > 0)
            {
                string caption = "Información";
                string message = "Se eliminarán los registros seleccionados ¿Desea continuar?";

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBox.Show(message, caption, buttons,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                                new EventHandler(DialogHandler));
            }
        }

        private void DialogHandler(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    this.EliminarPresupestos();
                }
            }
        }

        private void EliminarPresupestos()
        {
            int[] lista = this.GetListaPresupuestos().ToArray();
            List<PresupSelReemp> newDS = new List<PresupSelReemp>();

            foreach (PresupSelReemp row in (List<PresupSelReemp>)this.dgvDetPresupReemp.DataSource)
            {
                if (!lista.Contains(row.PresupuestoCabID))
                {
                    newDS.Add(row);
                }
            }

            this.headerCheckBox.Checked = false;
            this.dgvDetPresupReemp.DataSource = newDS;
            this.SetValues();
            
            //this.FormatearGrillaDetPresup();
        }

        private List<Int32> GetListaPresupuestos()
        {
            List<Int32> Result = new List<int>();

            foreach (DataGridViewRow row in this.dgvDetPresupReemp.Rows)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)this.dgvDetPresupReemp.Rows[row.Index].Cells[CAMPO_SELECCIONAR];
                if ((checkCell.Value != null) && ((bool)checkCell.Value))
                {
                    Result.Add(Convert.ToInt32(row.Cells[CAMPO_PRESUPUESTOCABID].Value));
                }
            }

            return Result;
        }

        private void ucCRUDCargarPresupReemp_Load(object sender, EventArgs e)
        {
            this.FormatearGrillaDetPresup();
        }

        private void dgvDetPresupReemp_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvDetPresupReemp.RowCount > 0)
            {
                if ((e.RowIndex > -1) && ((e.ColumnIndex == (((DataGridView)sender).Columns[CAMPO_MONTO].Index) ||
                                          (e.ColumnIndex == (((DataGridView)sender).Columns[CAMPO_SALDO].Index)))))
                {
                    if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_MONEDAABREV].Value.ToString() == MONEDA_GUARANIES)
                        e.CellStyle.Format = FORMATO_MONEDA_GUARANIES_GRILLA;
                    else
                        e.CellStyle.Format = FORMATO_MONEDA_OTROS_GRILLA;
                }
            }
        }

        #region Formatear marcas XML
        private string FormatearMarcasXML(string bruto)
        {
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

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            this.GenerarPresupuestos();
            //this.xxx();
        }

        private void xxx()
        {
            byte[] binaryFile;

            if (!System.IO.Directory.Exists(@w_directorio_trabajo))
            {
                System.IO.Directory.CreateDirectory(@w_directorio_trabajo);
            }

            pp_partepresupuesto pp = new pp_partepresupuesto();

            Berke.Libs.CodeGenerator cg;

            Berke.Libs.CodeGenerator tablaCliente;
            Berke.Libs.CodeGenerator filaCorreo;

            Berke.Libs.CodeGenerator tablaCuerpo;
            Berke.Libs.CodeGenerator filaAtencion;
            Berke.Libs.CodeGenerator filaReferencia;
            Berke.Libs.CodeGenerator filaServicio;
            Berke.Libs.CodeGenerator filaTarifa;
            Berke.Libs.CodeGenerator filaTotal;
            Berke.Libs.CodeGenerator filaTotalLetras;

            #region Leer Plantilla
            int MergeID = PRESUP_MERGEID;
            int IdiomaID = this.ClienteDS.IdiomaID != IDIOMA_ESPANOL ? IDIOMA_INGLES : IDIOMA_ESPANOL;
            string Plantilla = this.ClienteDS.IdiomaID != IDIOMA_ESPANOL ? PLANTILLA_PRESUPUESTO_SPF_CON_SELLO_TABLA_UNICA_ING : PLANTILLA_PRESUPUESTO_SPF_CON_SELLO_TABLA_UNICA_ESP;

            List<DocumentoPlantilla> DP = new List<DocumentoPlantilla>();

            DP = this.DBContext.DocumentoPlantilla.Where(a => a.Clave == Plantilla
                                                         && a.MergeID == MergeID
                                                         && a.IdiomaID == IdiomaID
                                                         && a.Plural == true).ToList();

            string msj = " Mergeid "
                         + MergeID.ToString() + " Idioma "
                         + IdiomaID.ToString();

            if (DP.Count == 0)
            {
                throw new Exception("No se encuentra una plantilla." + " " + msj);

            }

            if (DP.Count > 1)
            {
                throw new Exception("Existe mas de una plantilla." + " " + msj);
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

            tablaCuerpo = cg.ExtraerTabla("tablaCuerpo");
            filaAtencion = tablaCuerpo.ExtraerFila("filaAtencion", 2);
            filaReferencia = tablaCuerpo.ExtraerFila("filaReferencia", 5);
            filaServicio = tablaCuerpo.ExtraerFila("filaServicio", 1);
            filaTarifa = tablaCuerpo.ExtraerFila("filaTarifa", 1);
            filaTotal = tablaCuerpo.ExtraerFila("filaTotal", 1);
            filaTotalLetras = tablaCuerpo.ExtraerFila("filaTotalLetras", 3);

            const string FORMATO_MARCA_TABLACUERPO = "@@tablaCuerpo{0}@@";
            const string TABLA_CUERPO = "tablaCuerpo{0}";
            string tablaCuerpoMarcas = string.Empty;
            for (int i = 1; i <= this.dgvDetPresupReemp.RowCount; i++)
            {
                tablaCuerpoMarcas += string.Format(FORMATO_MARCA_TABLACUERPO, i.ToString());
            }

            cg.clearText();
            cg.copyTemplateToBuffer();

            cg.replaceLabel("tablaCuerpo", tablaCuerpoMarcas);

            #endregion Instanciar CodeGenerators

            string carpeta = @w_directorio_trabajo;
            string DescripcionGastos = string.Empty;

            int x = 1;
            foreach (PresupSelReemp item in (List<PresupSelReemp>)this.dgvDetPresupReemp.DataSource)
            {
                filaAtencion.clearText();
                filaAtencion.copyTemplateToBuffer();

                filaReferencia.clearText();
                filaReferencia.copyTemplateToBuffer();

                filaServicio.clearText();
                filaServicio.copyTemplateToBuffer();

                filaTarifa.clearText();
                filaTarifa.copyTemplateToBuffer();

                filaTotal.clearText();
                filaTotal.copyTemplateToBuffer();

                filaTotalLetras.clearText();
                filaTotalLetras.copyTemplateToBuffer();

                tablaCuerpo.clearText();
                tablaCuerpo.copyTemplateToBuffer();

                filaAtencion.replaceField("atencion.nombre", "Gustavo Galeano");
                filaAtencion.replaceField("atencion.email", "ggaleano.py@gmail.com");
                filaAtencion.addBufferToText();
                tablaCuerpo.replaceLabel("filaAtencion", filaAtencion.Texto);

                filaReferencia.replaceField("orden_trabajo.referenciacliente", "Esta es una referencia");
                filaReferencia.addBufferToText();
                tablaCuerpo.replaceLabel("filaReferencia", filaReferencia.Texto);

                #region Configurar descripción de servicios según trámite e idioma
                //pp_partepresupuesto pp = new pp_partepresupuesto();
                try
                {
                    pp = this.DBContext.pp_partepresupuesto.First(a => a.pp_tramiteid == item.TramiteID);
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
                filaServicio.addBufferToText();
                tablaCuerpo.replaceLabel("filaServicio", filaServicio.Texto);
                #endregion Configurar descripción de servicios según trámite

                filaTarifa.replaceField("descripcion.tarifa", "Descripción de Tarifa");
                filaTarifa.replaceField("mn", "100");
                filaTarifa.replaceField("tr.mnt", "200");
                filaTarifa.addBufferToText();
                tablaCuerpo.replaceLabel("filaTarifa", filaTarifa.Texto);

                filaTotal.replaceField("mn", "300");
                filaTotal.replaceField("total", "400");
                filaTotal.addBufferToText();
                tablaCuerpo.replaceLabel("filaTotal", filaTotal.Texto);

                filaTotalLetras.replaceField("total.letras", "TOTAL EN LETRAS");
                filaTotalLetras.addBufferToText();
                tablaCuerpo.replaceLabel("filaTotalLetras", filaTotalLetras.Texto);
                
                tablaCuerpo.addBufferToText();
                cg.replaceLabel(string.Format(TABLA_CUERPO, x), tablaCuerpo.Texto);
                x++;
            }

            filaCorreo.addBufferToText();
            tablaCliente.replaceLabel("filaCorreo", filaCorreo.Texto);
            tablaCliente.addBufferToText();
            cg.replaceLabel("tablaCliente", tablaCliente.Texto);


            cg.addBufferToText();

            #region Guardar documento en Archivo
            string archivo = DateTime.Now.Ticks.ToString();
            string path = carpeta + archivo + ".doc";
            Berke.Libs.Base.Helpers.Files.SaveStringToFile(cg.Texto, path);
            MessageBox.Show("Archivo creado con éxito: " + path);

            if (System.IO.Directory.Exists(@w_directorio_trabajo))
            {
                path = "file://" + @w_directorio_trabajo;
                Link.Open(@path);
            }

            #endregion Guardar documento en Archivo
        }
        
        private void GenerarPresupuestos()
        {
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    #region Inicializaciones
                    byte[] binaryFile;

                    if (!System.IO.Directory.Exists(@w_directorio_trabajo))
                    {
                        System.IO.Directory.CreateDirectory(@w_directorio_trabajo);
                    }

                    pp_partepresupuesto pp = new pp_partepresupuesto();

                    Berke.Libs.CodeGenerator cg;

                    Berke.Libs.CodeGenerator tablaCliente;
                    Berke.Libs.CodeGenerator filaCorreo;

                    Berke.Libs.CodeGenerator tablaCuerpo;
                    Berke.Libs.CodeGenerator filaAtencion;
                    Berke.Libs.CodeGenerator filaReferencia;
                    Berke.Libs.CodeGenerator filaDescripcionServicio;
                    Berke.Libs.CodeGenerator filaServicio;
                    Berke.Libs.CodeGenerator filaTarifa;
                    Berke.Libs.CodeGenerator filaTotal;
                    Berke.Libs.CodeGenerator filaTotalLetras;

                    string carpeta = @w_directorio_trabajo;
                    string ext = ".doc";
                    string archivo = "";
                    string path = "";
                    string MergeDocID = "";
                    string DescripcionGastos = "";
                    
                    List<RepHojaCotizacion_Result> listadoTarifas = new List<RepHojaCotizacion_Result>();
                    List<DetalleTarifasPresupuestoType> listaDetallePresup = new List<DetalleTarifasPresupuestoType>();

                    DateTime fechaGeneracion = this.dtpFechaGen.Value;
                    int MergeExpedienteID = 0;
                    decimal total = 0;

                    TExpedienteCab str_ExpedienteCab = new TExpedienteCab();
                    #endregion

                    #region Obtener numero de presuesto
                    var configP = this.DBContext.ConfigPresup.Where(a => a.Vigente == true).ToList();

                    if (configP.Count > 1)
                    {
                        throw new Exception("No se encuentra configuración para obtener el número de presupuesto o existe más de uno vigente");
                    }
                    ConfigPresup configPresup = configP.First();
                    string NroPresupuesto = configPresup.Serie + configPresup.Numero.Value.ToString();
                    #endregion Obtener numero de presupuesto

                    #region Procesar presupuestos reemplazados

                    if (!this.ClienteDS.IdiomaID.HasValue)
                    {
                        throw new Exception("El cliente no tiene definido el idioma");
                    }

                    Merge_Expediente me = new Merge_Expediente();
                    me.MergeID = PRESUP_MERGEID;
                    me.Generado = false;
                    me.Terminado = false;
                    me.FuncionarioID = Convert.ToInt32(VWGContext.Current.Session["UsuarioID"]);
                    me.Fecha = System.DateTime.Now;
                    context.Merge_Expediente.Add(me);
                    context.SaveChanges();

                    #region Leer Plantilla
                    int MergeID = PRESUP_MERGEID;
                    int IdiomaID = this.ClienteDS.IdiomaID != IDIOMA_ESPANOL ? IDIOMA_INGLES : IDIOMA_ESPANOL;
                    string Plantilla = this.ClienteDS.IdiomaID != IDIOMA_ESPANOL ? PLANTILLA_PRESUPUESTO_SPF_CON_SELLO_TABLA_UNICA_ING : PLANTILLA_PRESUPUESTO_SPF_CON_SELLO_TABLA_UNICA_ESP;

                    List<DocumentoPlantilla> DP = new List<DocumentoPlantilla>();

                    DP = this.DBContext.DocumentoPlantilla.Where(a => a.Clave == Plantilla
                                                                 && a.MergeID == MergeID
                                                                 && a.IdiomaID == IdiomaID
                                                                 && a.Plural == true).ToList();

                    string msj = " Mergeid "
                                 + MergeID.ToString() + " Idioma "
                                 + IdiomaID.ToString();

                    if (DP.Count == 0)
                    {
                        throw new Exception("No se encuentra una plantilla." + " " + msj);

                    }

                    if (DP.Count > 1)
                    {
                        throw new Exception("Existe mas de una plantilla." + " " + msj);
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

                    tablaCuerpo = cg.ExtraerTabla("tablaCuerpo");
                    filaAtencion = tablaCuerpo.ExtraerFila("filaAtencion", 2);
                    filaReferencia = tablaCuerpo.ExtraerFila("filaReferencia", 3);
                    filaDescripcionServicio = tablaCuerpo.ExtraerFila("filaDescripcionServicio", 2);
                    filaServicio = tablaCuerpo.ExtraerFila("filaServicio", 2);
                    filaTarifa = tablaCuerpo.ExtraerFila("filaTarifa", 1);
                    filaTotal = tablaCuerpo.ExtraerFila("filaTotal", 2);
                    filaTotalLetras = tablaCuerpo.ExtraerFila("filaTotalLetras", 1);

                    const string FORMATO_MARCA_TABLACUERPO = "@@tablaCuerpo{0}@@";
                    const string TABLA_CUERPO = "tablaCuerpo{0}";
                    string tablaCuerpoMarcas = string.Empty;
                    for (int i = 1; i <= this.dgvDetPresupReemp.RowCount; i++)
                    {
                        tablaCuerpoMarcas += string.Format(FORMATO_MARCA_TABLACUERPO, i.ToString());
                                               //"<w:p><w:pPr><w:rPr></w:rPr></w:pPr></w:p>";
                    }

                    cg.clearText();
                    cg.copyTemplateToBuffer();

                    cg.replaceLabel("tablaCuerpo", tablaCuerpoMarcas);

                    #endregion Instanciar CodeGenerators

                    string selloTexto = string.Empty;
                    string selloColor = string.Empty;
                    string monedaAbrev = string.Empty;
                    string monedaDescrip = string.Empty;
                    decimal gTotal = 0;

                    int x = 1;
                    foreach (PresupSelReemp item in (List<PresupSelReemp>)this.dgvDetPresupReemp.DataSource)
                    {
                        filaAtencion.clearText();
                        filaAtencion.copyTemplateToBuffer();

                        filaReferencia.clearText();
                        filaReferencia.copyTemplateToBuffer();

                        filaDescripcionServicio.clearText();
                        filaDescripcionServicio.copyTemplateToBuffer();

                        filaServicio.clearText();
                        filaServicio.copyTemplateToBuffer();

                        filaTarifa.clearText();
                        filaTarifa.copyTemplateToBuffer();

                        filaTotal.clearText();
                        filaTotal.copyTemplateToBuffer();

                        filaTotalLetras.clearText();
                        filaTotalLetras.copyTemplateToBuffer();

                        tablaCuerpo.clearText();
                        tablaCuerpo.copyTemplateToBuffer();

                        #region Configurar descripción de servicios según trámite e idioma
                        try
                        {
                            pp = this.DBContext.pp_partepresupuesto.First(a => a.pp_tramiteid == item.TramiteID);
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
                        #endregion Configurar descripción de servicios según trámite

                        #region Generación de documento
                        int cabecera = 0;
                        string cadena_clasenro = "";
                        string nro_registro = "";
                        string nro_acta = "";
                        string marca = "";
                        string listaCotizacionesCabID = "";

                        #region Obtener Datos de Expediente
                        var expedientes = new List<ExpePresupType>();
                        #region Trámites de Marcas
                        if (item.Origen == ORIGEN_MARCAS)
                        {
                            expedientes = (from cPres in this.DBContext.cp_cotizacionesxpresup
                                               join cCab in this.DBContext.cc_cotizacioncab
                                                    on cPres.cp_cotizacionid equals cCab.cc_cotizacioncabid
                                               join expe in this.DBContext.Expediente
                                                    on cCab.cc_expedienteid equals expe.ID
                                               join marc in this.DBContext.Marca
                                                    on expe.MarcaID equals marc.ID
                                               join mRR in this.DBContext.MarcaRegRen
                                                    on marc.MarcaRegRenID equals mRR.ID
                                               join Tram in this.DBContext.Tramite
                                                    on expe.TramiteID equals Tram.ID
                                               join oTrab in this.DBContext.OrdenTrabajo
                                                    on expe.OrdenTrabajoID equals oTrab.ID
                                               join pCab in this.DBContext.pc_presupuestocab
                                                    on cPres.cp_presupuestocabid equals pCab.pc_presupuestocabid
                                               join mDoc in this.DBContext.MergeDoc
                                                    on pCab.pc_mergedocid equals mDoc.ID into pCab_mDoc
                                               from mDoc in pCab_mDoc.DefaultIfEmpty()
                                               join corr in this.DBContext.Correspondencia
                                                    on oTrab.CorrespondenciaID equals corr.ID into oTrab_corr
                                               from corr in oTrab_corr.DefaultIfEmpty()
                                               join mExp in this.DBContext.Merge_Expediente
                                                    on mDoc.MergeExpedienteID equals mExp.ID into mDoc_mExp
                                               from mExp in mDoc_mExp.DefaultIfEmpty()
                                               join mTipo in this.DBContext.MarcaTipo
                                                    on marc.MarcaTipoID equals mTipo.ID into marc_mTipo
                                               from mTipo in marc_mTipo.DefaultIfEmpty()
                                               join mClase in this.DBContext.Clase
                                                    on marc.ClaseID equals mClase.ID into marc_mClase
                                               from mClase in marc_mClase.DefaultIfEmpty()
                                               join at in this.DBContext.Atencion
                                                    on pCab.pc_atencionid equals at.ID into pCab_at
                                               from at in pCab_at.DefaultIfEmpty()
                                               select new ExpePresupType
                                               {
                                                   PresupuestoCabID = cPres.cp_presupuestocabid,
                                                   Serie = mDoc.Serie,
                                                   NroPresupuesto = mDoc.NroPresupuesto,
                                                   CotizacionCabID = cPres.cp_cotizacionid,
                                                   ExpedienteID = cCab.cc_expedienteid,
                                                   DenominacionMarca = marc.Denominacion,
                                                   ActaNro = expe.ActaNro,
                                                   ActaAnio = expe.ActaAnio,
                                                   RegistroNro = mRR.Registro,
                                                   DescripTramite = Tram.Descrip,
                                                   HINro = oTrab.Nro,
                                                   HiAnio = oTrab.Anio,
                                                   TramiteID = Tram.ID,
                                                   PropietarioMarca = marc.Propietario,
                                                   FechaCorresp = corr.FechaCorresp,
                                                   EnTramite = mExp.EnTramite,
                                                   ReferenciaCliente = oTrab.RefCliente,
                                                   ReferenciaCorresp = oTrab.RefCorr,
                                                   NroCorresp = corr.Nro,
                                                   AreaContabID = Tram.AreaContabID,
                                                   AprobadoPor = cCab.cc_aprobadopor,
                                                   HechoPor = cCab.cc_solicitadopor,
                                                   Origen = pCab.pc_origen,
                                                   ClaseNro = mClase.Nro,
                                                   MarcaTipo = mTipo.Descrip,
                                                   NroRegistro = mRR.RegistroNro,
                                                   AnoRegistro = mRR.RegistroAnio,
                                                   FechaConcesion = mRR.ConcesionFecha,
                                                   AtencionID = pCab.pc_atencionid,
                                                   AtencionNombre = at.Nombre
                                               }).Where(a => a.PresupuestoCabID == item.PresupuestoCabID).ToList();
                        }
                        #endregion Trámites de Marcas
                        #region Otros Trámites
                        else if (item.Origen == ORIGEN_OTROS)
                        {
                            expedientes = (from cPres in this.DBContext.cp_cotizacionesxpresup
                                               join cCab in this.DBContext.cc_cotizacioncab
                                                    on cPres.cp_cotizacionid equals cCab.cc_cotizacioncabid
                                               join eOpo in this.DBContext.op_oposicion
                                                    on cCab.cc_expedienteid equals eOpo.ID
                                               join expe in this.DBContext.Expediente
                                                    on eOpo.ExpedienteID equals expe.ID into expe_eOpo
                                               from expe in expe_eOpo.DefaultIfEmpty()
                                               join mRR in this.DBContext.MarcaRegRen
                                                    on expe.MarcaRegRenID equals mRR.ID into mRR_expe
                                               from mRR in mRR_expe.DefaultIfEmpty()
                                               join Tram in this.DBContext.Tramite
                                                    on eOpo.TramiteID equals Tram.ID
                                               join oTrab in this.DBContext.OrdenTrabajo
                                                    on eOpo.OrdenTrabajoID equals oTrab.ID into oTrab_eOpo
                                               from oTrab in oTrab_eOpo.DefaultIfEmpty()
                                               join pCab in this.DBContext.pc_presupuestocab
                                                    on cPres.cp_presupuestocabid equals pCab.pc_presupuestocabid
                                               join mDoc in this.DBContext.MergeDoc
                                                    on pCab.pc_mergedocid equals mDoc.ID into pCab_mDoc
                                               from mDoc in pCab_mDoc.DefaultIfEmpty()
                                               join marc in this.DBContext.Marca
                                                    on expe.MarcaID equals marc.ID into expe_marc
                                               from marc in expe_marc.DefaultIfEmpty()
                                               join corr in this.DBContext.Correspondencia
                                                    on oTrab.CorrespondenciaID equals corr.ID into oTrab_corr
                                               from corr in oTrab_corr.DefaultIfEmpty()
                                               join mExp in this.DBContext.Merge_Expediente
                                                    on mDoc.MergeExpedienteID equals mExp.ID into mDoc_mExp
                                               from mExp in mDoc_mExp.DefaultIfEmpty()
                                               join mTipo in this.DBContext.MarcaTipo 
                                                    on marc.MarcaTipoID equals mTipo.ID into marc_mTipo
                                               from mTipo in marc_mTipo.DefaultIfEmpty()
                                               join mClase in this.DBContext.Clase
                                                    on marc.ClaseID equals mClase.ID into marc_mClase
                                               from mClase in marc_mClase.DefaultIfEmpty()
                                               join at in this.DBContext.Atencion
                                                    on pCab.pc_atencionid equals at.ID into pCab_at
                                               from at in pCab_at.DefaultIfEmpty()
                                               select new ExpePresupType
                                               {
                                                   PresupuestoCabID = cPres.cp_presupuestocabid,
                                                   Serie = mDoc.Serie,
                                                   NroPresupuesto = mDoc.NroPresupuesto,
                                                   CotizacionCabID = cPres.cp_cotizacionid,
                                                   ExpedienteID = cCab.cc_expedienteid,
                                                   DenominacionMarca = eOpo.Denominacion,
                                                   ActaNro = eOpo.ActaNro,
                                                   ActaAnio = eOpo.ActaAnio,
                                                   RegistroNro = mRR.Registro,
                                                   DescripTramite = Tram.Descrip,
                                                   HINro = oTrab.Nro,
                                                   HiAnio = oTrab.Anio,
                                                   TramiteID = Tram.ID,
                                                   PropietarioMarca = marc.Propietario,
                                                   FechaCorresp = corr.FechaCorresp,
                                                   EnTramite = mExp.EnTramite,
                                                   ReferenciaCliente = oTrab.RefCliente,
                                                   ReferenciaCorresp = oTrab.RefCorr,
                                                   AreaContabID = Tram.AreaContabID,
                                                   AprobadoPor = cCab.cc_aprobadopor,
                                                   HechoPor = cCab.cc_solicitadopor,
                                                   Origen = pCab.pc_origen,
                                                   ClaseNro = mClase.Nro,
                                                   MarcaTipo = mTipo.Descrip,
                                                   NroRegistro = mRR.RegistroNro,
                                                   AnoRegistro = mRR.RegistroAnio,
                                                   FechaConcesion = mRR.ConcesionFecha,
                                                   AtencionID = pCab.pc_atencionid,
                                                   AtencionNombre = at.Nombre
                                               }).Where(a => a.PresupuestoCabID == item.PresupuestoCabID).ToList();

                        }
                        #endregion Otros Trámites
                        #endregion Obtener Datos de Expediente

                        TExpedienteDet str_ExpedienteDet = new TExpedienteDet();

                        foreach (ExpePresupType item1 in expedientes)
                        {
                            if (listaCotizacionesCabID != "")
                                listaCotizacionesCabID += ",";

                            listaCotizacionesCabID += item1.CotizacionCabID.ToString();

                            str_ExpedienteDet.ClaseNro = item1.ClaseNro;
                            str_ExpedienteDet.ClaseTipo = item1.MarcaTipo;
                            #region Datos de cabecera
                            if (cabecera == 0)
                            {
                                MergeExpedienteID = me.ID;
                                #region Salvar datos de Cabecera
                                str_ExpedienteCab.OrdenTrabajoID = item1.OrdenTrabajoID.HasValue ? item1.OrdenTrabajoID.Value.ToString() : string.Empty;
                                str_ExpedienteCab.ClienteID = this.ClienteDS.ID;
                                str_ExpedienteCab.ClienteNombre = this.ClienteDS.Nombre;
                                str_ExpedienteCab.ClienteCorreo = this.ClienteDS.Correo;
                                str_ExpedienteCab.AtencionID = Convert.ToInt32(this.tSBAtencion.KeyMember);
                                str_ExpedienteCab.ClienteAtencion = this.tSBAtencion.DisplayMember;
                                str_ExpedienteCab.AtencionMail = this.getAtencionEmail(str_ExpedienteCab.AtencionID, context);
                                str_ExpedienteCab.FechaCorresp = item1.FechaCorresp.HasValue ? item1.FechaCorresp.Value.ToShortDateString() : string.Empty;
                                str_ExpedienteCab.TramiteID = item1.TramiteID.ToString();
                                str_ExpedienteCab.EnTramite = item1.EnTramite.HasValue && item1.EnTramite.Value ? SI : NO;

                                str_ExpedienteCab.ReferenciaCliente = item1.ReferenciaCliente != null ? item1.ReferenciaCliente : string.Empty;
                                str_ExpedienteCab.ReferenciaCorresp = item1.ReferenciaCorresp != null ? item1.ReferenciaCorresp : string.Empty;

                                str_ExpedienteCab.nrocorresp = item1.NroCorresp.HasValue ? item1.NroCorresp.Value.ToString() : string.Empty;
                                str_ExpedienteCab.aniocorresp = item1.AnioCorresp.HasValue ? item1.AnioCorresp.Value.ToString() : string.Empty;

                                if (item1.AreaContabID.HasValue)
                                    str_ExpedienteCab.AreaID = item1.AreaContabID.Value;

                                if (item1.AprobadoPor == null)
                                    throw new Exception("No está definida la persona que autorizó la cotización.");
                                else
                                    str_ExpedienteCab.AprobadoPorID = item1.AprobadoPor.Value;

                                if (item1.HechoPor == null)
                                    throw new Exception("No está definida la persona que solicitó la cotización.");
                                else
                                {
                                    str_ExpedienteCab.EnviadoPorID = item1.HechoPor.Value;
                                }

                                if (item1.Origen == ORIGEN_OTROS)
                                {
                                    this.getPartes(item1.ExpedienteID.Value, str_ExpedienteCab, context);

                                    if ((str_ExpedienteCab.ParteNombre == null) && (Convert.ToInt32(str_ExpedienteCab.TramiteID) == OPOSICIONES_ID))
                                        throw new Exception("El trámite no tiene definido el nombre de la parte");
                                }

                                #endregion Salvar datos de Cabecera

                                this.GetPropietarioAnterior(item1.ExpedienteID.Value, str_ExpedienteDet, context);
                                this.getPropietarioActual(item1.ExpedienteID.Value, str_ExpedienteDet, context);

                                /*/datos para tr , cn, */
                                filaAtencion.replaceField("atencion.nombre", str_ExpedienteCab.ClienteAtencion);
                                filaAtencion.replaceField("atencion.email", str_ExpedienteCab.AtencionMail);
                                filaAtencion.addBufferToText();

                                filaReferencia.replaceField("orden_trabajo.referenciacliente", str_ExpedienteCab.ReferenciaCliente + 
                                                                                                str_ExpedienteCab.ReferenciaCorresp != string.Empty ? string.Empty : " " + 
                                                                                                str_ExpedienteCab.ReferenciaCorresp);
                                filaReferencia.addBufferToText();

                                filaServicio.replaceField("proant.nombre", str_ExpedienteDet.propietarioAnterior);
                                filaServicio.replaceField("proact.nombre", str_ExpedienteDet.propietarioActual);

                                if (item.Origen == ORIGEN_OTROS)
                                {
                                    filaServicio.replaceField("parte.nombre", str_ExpedienteCab.ParteNombre);
                                    filaServicio.replaceField("contraparte.nombre", str_ExpedienteCab.ContraparteNombre);
                                }

                                selloTexto = item.ClienteSelloTexto;
                                selloColor = item.ClienteSelloColor;

                                cabecera = 1;
                            }
                            #endregion Datos de cabecera

                            #region Listar las Marcas

                            /* Mostramos el numero de registro o acta segun este registrado 
						     * o en tramite respectivamente */
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

                            marca += item1.DenominacionMarca;
                            cadena_clasenro += str_ExpedienteDet.ClaseNro;

                            /*Si NO esta en tramite se utiliza el numero de registro sino se usa el numero de acta */
                            str_ExpedienteDet.RegistroNro = item1.NroRegistro.HasValue ? item1.NroRegistro.Value : 0;
                            str_ExpedienteDet.RegistroAnio = item1.AnoRegistro.HasValue ? item1.AnoRegistro.Value : 0;
                            str_ExpedienteDet.FechaConcesion = item1.FechaConcesion.HasValue ? item1.FechaConcesion.Value.ToShortDateString() : "";
                            if (str_ExpedienteDet.RegistroNro.ToString() != "0" && str_ExpedienteDet.RegistroNro.ToString() != "")
                            {
                                nro_registro += str_ExpedienteDet.RegistroNro.ToString();
                            }
                            else
                            {
                                nro_registro += item1.Acta;
                            }

                            nro_acta += item1.Acta;
                            #endregion
                        }

                        #region Completar Tablas Cliente y Marcas
                        /* aqui final */

                        filaServicio.replaceField("marca.denominacion", marca.ToString());
                        filaServicio.replaceField("clase.nro", cadena_clasenro.ToString()); 
                        filaServicio.replaceField("regact.nro", nro_registro.ToString());
                        filaServicio.replaceField("acta.nro", nro_acta.ToString());
                        filaServicio.addBufferToText();

                        listadoTarifas = context.RepHojaCotizacion(listaCotizacionesCabID,
                                                                   ACTA,
                                                                   item.TramiteID).ToList();
                        int i = 0;
                        total = 0;
                        decimal gasto = 0;
                        decimal impuesto = 0;
                        decimal descuento = 0;
                        decimal recargo = 0;
                        monedaAbrev = listadoTarifas.First().AbrevMoneda;
                        monedaDescrip = IdiomaID == IDIOMA_ESPANOL
                                                    ? listadoTarifas.First().MonedaDescrip
                                                    : listadoTarifas.First().MonedaDescripIngles;
                        string descripcionDescuento = IdiomaID == IDIOMA_ESPANOL
                                                        ? DESCRIPCION_DESCUENTOS_ESP
                                                        : DESCRIPCION_DESCUENTOS_ING;
                        
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
                            filaTarifa.replaceField("descripcion.tarifa", descripcionTarifa);
                            filaTarifa.replaceField("mn", monedaAbrev);
                            filaTarifa.replaceField("tr.mnt", String.Format("{0:n2}", fila.PrecioUnitario.Value * fila.Cantidad.Value /*fila.Neto.Value*/).Replace(',', '.'));
                            total += fila.Neto.Value;
                            gasto += fila.Gasto.Value;
                            recargo += fila.Recargo.Value;
                            descuento += fila.Descuento.Value;
                            impuesto += fila.Impuesto.Value;
                            i++;

                            DetalleTarifasPresupuestoType det = new DetalleTarifasPresupuestoType();
                            det.DetalleDescripcion = descripcionTarifa;
                            det.DetalleMonto = fila.PrecioUnitario.Value * fila.Cantidad.Value;
                            listaDetallePresup.Add(det);
                        }

                        if ((gasto > 0) || (impuesto > 0) || (recargo > 0))
                        {
                            filaTarifa.addBufferToText();
                            filaTarifa.copyTemplateToBuffer();
                            filaTarifa.replaceField("descripcion.tarifa", DescripcionGastos);
                            filaTarifa.replaceField("mn", monedaAbrev);
                            filaTarifa.replaceField("tr.mnt", String.Format("{0:n2}", gasto + impuesto + recargo).Replace(',', '.'));
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
                            filaTarifa.replaceField("descripcion.tarifa", descripcionDescuento);
                            filaTarifa.replaceField("mn", monedaAbrev);
                            filaTarifa.replaceField("tr.mnt", String.Format("{0:n2}", descuento * -1).Replace(',', '.'));

                            DetalleTarifasPresupuestoType det = new DetalleTarifasPresupuestoType();
                            det.DetalleDescripcion = descripcionDescuento;
                            det.DetalleMonto = descuento * -1;
                            listaDetallePresup.Add(det);
                        }

                        gTotal += total;

                        //filaTotal.replaceField("total", String.Format("{0:0.00}", total).Replace(',', '.'));
                        //filaTotal.replaceField("mn", monedaAbrev);
                        //filaTotal.addBufferToText();

                        filaTarifa.replaceLabel("filaTotal", filaTotal.Texto);
                        filaTarifa.addBufferToText();

                        //string totalEnLetras = "";

                        //if (IdiomaID == IDIOMA_ESPANOL)
                        //{
                        //    Numalet let = new Numalet();
                        //    let.ConvertirDecimales = false;
                        //    let.Decimales = 0;

                        //    int number = (int)Math.Truncate(total);
                        //    decimal decimalPart = total - number;
                        //    if (decimalPart > 0)
                        //    {
                        //        let.ConvertirDecimales = true;
                        //        let.Decimales = 2;
                        //    }

                        //    if (monedaDescrip == DOLARES)
                        //        totalEnLetras = let.ToCustomCardinal(total) + " " + monedaDescrip;
                        //    else
                        //        totalEnLetras = monedaDescrip + " " + let.ToCustomCardinal(total);

                        //    let = null;
                        //}
                        //else
                        //{
                        //    if (monedaDescrip == DOLLARS)
                        //        totalEnLetras = this.NumberToText(total) + " " + monedaDescrip;
                        //    else
                        //        totalEnLetras = monedaDescrip + " " + this.NumberToText(total);
                        //}

                        //filaTotalLetras.replaceField("total.letras", totalEnLetras.ToUpper());
                        //filaTotalLetras.addBufferToText();

                        if (item.TramiteID == 2)
                        {
                            cg.replaceField("acta.nro", nro_acta.ToString());
                        }
                        else
                        {
                            cg.replaceField("acta.nro", nro_registro.ToString());
                        }
                        #endregion

                        //tablaCuerpo.replaceLabel("filaAtencion", filaAtencion.Texto);
                        //tablaCuerpo.replaceLabel("filaReferencia", filaReferencia.Texto);
                        tablaCuerpo.replaceLabel("filaServicio", filaServicio.Texto);
                        tablaCuerpo.replaceLabel("filaTarifa", filaTarifa.Texto);

                        if (x == 1)
                        {
                            tablaCuerpo.replaceLabel("filaAtencion", filaAtencion.Texto);
                            //tablaCuerpo.replaceLabel("filaReferencia", filaReferencia.Texto);

                            filaDescripcionServicio.addBufferToText();
                            tablaCuerpo.replaceLabel("filaDescripcionServicio", filaDescripcionServicio.Texto);
                        }

                        if (x == this.dgvDetPresupReemp.RowCount)
                        {
                            filaTotal.addBufferToText();
                            tablaCuerpo.replaceLabel("filaTotal", filaTotal.Texto);
                            filaTotalLetras.addBufferToText();
                            tablaCuerpo.replaceLabel("filaTotalLetras", filaTotalLetras.Texto);
                        }
                        
                        tablaCuerpo.addBufferToText();

                        cg.replaceLabel(string.Format(TABLA_CUERPO, x), tablaCuerpo.Texto);
                        x++;
                        #endregion Generación de documento
                    }
                    #endregion Procesar presupuestos reemplazados

                    string[] lines = str_ExpedienteCab.ClienteCorreo.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                    string correoFormateado = this.FormatearMarcasXML("<b>" + lines[0] + "</b>") + NEWLINEXML;

                    for (int index = 1; index < lines.Count(); index++)
                    {
                        correoFormateado += this.FormatearMarcasXML("<p>" + lines[index] + "</p>") + NEWLINEXML;
                    }

                    str_ExpedienteCab.ClienteCorreo = correoFormateado;
                    filaCorreo.replaceField("cliente.correo", str_ExpedienteCab.ClienteCorreo.ToString());
                    filaCorreo.replaceField("numero", NroPresupuesto);
                    filaCorreo.addBufferToText();

                    tablaCliente.replaceLabel("filaCorreo", filaCorreo.Texto);
                    tablaCliente.addBufferToText();
                    cg.replaceLabel("tablaCliente", tablaCliente.Texto);

                    string str_fecha = this.traducirFecha(fechaGeneracion.ToShortDateString(), IdiomaID);

                    if (IdiomaID == IDIOMA_ESPANOL) /*español*/
                    {
                        cg.replaceField("fecha", "Asunción, " + str_fecha.ToString());
                    }
                    else
                    {
                        cg.replaceField("fecha", str_fecha.ToString());
                    }

                    cg.replaceField("Paraguay", "Paraguay");

                    cg.replaceField("total", String.Format("{0:n2}", gTotal));
                    cg.replaceField("mn", monedaAbrev);
                  
                    filaTarifa.replaceLabel("filaTotal", filaTotal.Texto);
                    filaTarifa.addBufferToText();

                    string totalEnLetras = "";

                    if (IdiomaID == IDIOMA_ESPANOL)
                    {
                        Numalet let = new Numalet();
                        let.ConvertirDecimales = false;
                        let.Decimales = 0;

                        int number = (int)Math.Truncate(gTotal);
                        decimal decimalPart = gTotal - number;
                        if (decimalPart > 0)
                        {
                            let.ConvertirDecimales = true;
                            let.Decimales = 2;
                        }

                        if (monedaDescrip == DOLARES)
                            totalEnLetras = let.ToCustomCardinal(gTotal) + " " + monedaDescrip;
                        else
                            totalEnLetras = monedaDescrip + " " + let.ToCustomCardinal(gTotal);

                        let = null;
                    }
                    else
                    {
                        if (monedaDescrip == DOLLARS)
                            totalEnLetras = this.NumberToText(gTotal) + " " + monedaDescrip;
                        else
                            totalEnLetras = monedaDescrip + " " + this.NumberToText(gTotal);
                    }

                    cg.replaceField("total.letras", totalEnLetras.ToUpper());
                    
                    /*[ggaleano 19/09/2018] Se agrega sello de banco asignado*/
                    cg.replaceField("color", selloColor);
                    cg.replaceField("sello", selloTexto.Replace(System.Environment.NewLine, "<w:br/>"));

                    cg.addBufferToText();

                    #region Guardar documento en Archivo
                    archivo = str_ExpedienteCab.ClienteID.ToString() + "-" + NroPresupuesto;
                    path = carpeta + archivo + ext;
                    Berke.Libs.Base.Helpers.Files.SaveStringToFile(cg.Texto, path);
                    MessageBox.Show("Archivo creado con éxito: " + path);

                    if (System.IO.Directory.Exists(@w_directorio_trabajo))
                    {
                        path = "file://" + @w_directorio_trabajo;
                        Link.Open(@path);
                    }

                    #endregion Guardar documento en Archivo
                }
            }
        }

        #region Helpers
        private string traducirClase(string clase, int idiomaID)
        {

            string tr = "";

            List<Traduccion> ListaTraduccion = this.DBContext.Traduccion.Where(a => a.IdiomaID == idiomaID && a.Texto == clase).ToList();

            if (ListaTraduccion.Count > 0)
            {

                tr = ListaTraduccion.First().Traducido;
            }

            return tr;
        }

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

        private string getClaseTipo(int ClaseID, BerkeDBEntities context)
        {
            Clase clase = context.Clase.First(a => a.ID == ClaseID);
            return context.ClaseTipo.First(a => a.ID == clase.ClaseTipoID).Descrip;
        }

        private int getClaseNro(int ClaseID, BerkeDBEntities context)
        {
            return context.Clase.First(a => a.ID == ClaseID).Nro;
        }

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

        private TExpedienteDet GetPropietarioAnterior(int ExpedienteID, TExpedienteDet str_Expediente, BerkeDBEntities context)
        {

            List<ExpedienteCampo> ListExpedienteCampo = context.ExpedienteCampo.Where(a => a.ExpedienteID == ExpedienteID).ToList();

            foreach (ExpedienteCampo item in ListExpedienteCampo)
            {
                if (item.Campo.ToUpper() == "PROPIETARIO ANTERIOR")
                {
                    str_Expediente.propietarioAnterior = item.Valor;
                }

                if (item.Campo.ToUpper() == "PROPIETARIO ANTERIOR_DIR")
                {
                    str_Expediente.propietarioAntDireccion = item.Valor;
                }

                if (item.Campo.ToUpper() == "FUSIONADO CON")
                {
                    str_Expediente.nombreotrospropietarios = item.Valor;
                }

            }


            return str_Expediente;
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

        private string getAtencionEmail(int AtencionID, BerkeDBEntities context)
        {
            string result = string.Empty;
            List<AtencionXVia> lista = new List<AtencionXVia>();

            lista = context.AtencionXVia.Where(a => a.AtencionID == AtencionID && a.ViaID == VIA_E_EMAIL)
                      .OrderByDescending(a => a.ID)      
                      .ToList();

            if (lista.Count > 0)
            {
                result = lista.First().Descrip;
            }

            return result;
        }

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
        #endregion Helpers
    }
}