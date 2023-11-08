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

using Newtonsoft.Json;

#endregion

namespace SPF.UserControls.UI
{
    public partial class ucCRUDNotaCreditoCliente : ucBaseForm2015
    {
        #region Constantes
        //Cabecera
        public const string CAMPO_FACTURACABECERAID = "FacturaCabeceraID";
        public const string CAMPO_PRESUPUESTOCABID = "PresupuestoCabID";
        public const string CAMPO_FACTURATIMBRADOID = "FacturaTimbradoID";
        public const string CAMPO_FACTURAHOJASUELTA = "FacturaTimbradoHojaSuelta";
        public const string CAMPO_FACTURAFECHA = "FacturaFecha";
        public const string CAMPO_FACTURANRO = "FacturaNro";
        public const string CAMPO_ANULADO = "Anulado";
        public const string CAMPO_ANULADODESCRIPCION = "AnuladoDescripcion";
        public const string CAMPO_CLIENTEID = "ClienteID";
        public const string CAMPO_CLIENTENOMBRE = "ClienteNombre";
        public const string CAMPO_CLIENTEIDIOMAID = "ClienteIdiomaID";
        public const string CAMPO_DIRECCION = "Direccion";
        public const string CAMPO_FACTURATIPO = "FacturaTipo";
        public const string CAMPO_FACTURATIPODESCRIPCION = "FacturaTipoDescripcion";
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
        public const string CAMPO_TOTALFACTURA = "TotalFactura";
        public const string CAMPO_TOTALLETRAS = "TotalLetras";
        public const string CAMPO_DOCUMENTOSASOCIADOS = "DocumentosAsociados";
        public const string CAMPO_AUTORIZACIONVIG = "TieneAutorizacionVigente";
        //Detalles
        public const string CAMPO_CANTIDAD = "Cantidad";
        public const string CAMPO_DESCRIPCION = "Descripcion";
        public const string CAMPO_PRECIOUNITARIO = "PrecioUnitario";
        public const string CAMPO_EXENTAS = "Exentas";
        public const string CAMPO_CINCOPORCIENTO = "CincoPorciento";
        public const string CAMPO_DIEZPORCIENTO = "DiezPorciento";
        private const string CAMPO_BOLETADEPOSITONRO = "BoletaDepositoNro";
        public const string CAMPO_COBROID = "CobroID";

        private const string CAMPO_AUDITOPERACION = "AuditOperacion";
        private const string CAMPO_USUARIOCARGAID = "UsuarioCargaID";
        private const string CAMPO_USUARIOCARGANOMBRE = "UsuarioCargaNombre";
        
        private const string CAMPO_FACTURADETALLEFK_TABLA = "fd_facturacabeceraid";
        private const string CAMPO_FACTURACABECERAPK_TABLA = "fc_facturacabeceraid";
        private const string CAMPO_FACTURACABECERA_NROFACTURA = "fc_nrofactura";
        private const string CAMPO_FACTURACABECERA_TIMBRADOID = "fc_timbradoid";
        private const string CAMPO_FACTURACABECERA_DOCUMENTOSASOC = "fc_documentosasoc";

        private const string DESCRIPCION_FACTURA_SERIE2_SING_ESP = "DESCRIPCION_FACTURA_SERIE2_SING_ESP";
        private const string DESCRIPCION_FACTURA_SERIE2_PLU_ESP = "DESCRIPCION_FACTURA_SERIE2_PLU_ESP";
        private const string DESCRIPCION_FACTURA_SERIE2_SING_ING = "DESCRIPCION_FACTURA_SERIE2_SING_ING";
        private const string DESCRIPCION_FACTURA_SERIE2_PLU_ING = "DESCRIPCION_FACTURA_SERIE2_PLU_ING";

        private const string SERIE_2 = "Serie 2";

        private const string AUDIT_OPERACION_INSERT = "INSERT";

        private const string ESTADO_PENDIENTE = "A";
        private const string ESTADO_ANULADO = "N";
        private const string ESTADO_ACTIVOVALOR = "Activo";
        private const string ESTADO_ANULADOVALOR = "Anulado";
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
        private const int TIPODOCUMENTO_FACTURA_CLIENTE = 7;

        private const string CERO_SIN_DECIMALES = "0";
        private const string CERO_CON_DECIMALES = "0,00";

        private const char PAD = '0';
        private const string FORMATO_FACTURA = "{0}-{1}-{2}";

        private const string IE_BROWSER = "InternetExplorer";

        private const string HOJASUELTA_SI = "S";
        private const string HOJASUELTA_NO = "N";
        #endregion Constantes

        #region Variables Globales
        frmPickBase fPickMoneda;
        frmPickBase fPickCliente;
        private int UsuarioID = -1;
        private List<FacturaAllType> lFacturas;
        FSelecPresupFactura fSelecPresupFactura;
        #endregion Variables Globales

        #region Método de Inicio
        public ucCRUDNotaCreditoCliente()
        {
            InitializeComponent();
        }

        

        public ucCRUDNotaCreditoCliente(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
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
            
            lFacturas = new List<FacturaAllType>();

            DateTime d = new DateTime(2023, 12, 31);

            lFacturas = (from fc in this.DBContext.fc_facturacabecera
                         join fd in this.DBContext.fd_facturadetalle
                             on fc.fc_facturacabeceraid equals fd.fd_facturacabeceraid
                         join mon in this.DBContext.Moneda
                             on fc.fc_monedaid equals mon.ID
                         join AudFc in this.DBContext.Audit_fc_facturacabecera
                             on fc.fc_facturacabeceraid equals AudFc.fc_facturacabeceraid
                         join cli in this.DBContext.Cliente
                             on fc.fc_clienteid equals cli.ID into fc_cli
                         from cli in fc_cli.DefaultIfEmpty()
                         join uAud in this.DBContext.Usuario
                             on AudFc.Audit_User.Substring(6, AudFc.Audit_User.Length) equals uAud.Usuario1
                         join ti in this.DBContext.ti_timbrado
                             on fc.fc_timbradoid equals ti.ti_timbradoid
                         //join pp in this.DBContext.pp_pagopresupuesto
                         //    on fd.fd_presupuestocabid equals pp.pp_presupuestocabid into fd_pp
                         //    from pp in fd_pp.DefaultIfEmpty()
                         select new FacturaAllType
                         {
                             //Cabecera
                             FacturaFecha = fc.fc_fechafactura,
                             FacturaCabeceraID = fc.fc_facturacabeceraid,
                             FacturaTimbradoID = fc.fc_timbradoid,
                             FacturaTimbradoHojaSuelta = ti.ti_facthojasuelta,
                             FacturaNro = fc.fc_nrofactura,
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
                             TotalIVA = fc.fc_totaliva,
                             LiqIVA5 = fc.fc_liqiva5,
                             LiqIVA10 = fc.fc_liqiva10,
                             TotalLiqIVA = fc.fc_totaliva,
                             TotalFactura = fc.fc_total,
                             TotalLetras = fc.fc_totalletras,
                             DocumentosAsociados = fc.fc_documentosasoc,
                             UsuarioCargaID = uAud.ID,
                             UsuarioCargaNombre = uAud.NombrePila,
                             AuditOperacion = AudFc.Audit_Operacion,
                             TieneAutorizacionVigente = this.DBContext.GetAutorizacionPorDocumentoID(TIPODOCUMENTO_FACTURA_CLIENTE,
                                                                                                     fc.fc_facturacabeceraid,
                                                                                                     this.UsuarioID).FirstOrDefault().Value,
                             //Detalles
                             Cantidad = fd.fd_cantidad,
                             Descripcion = fd.fd_descripcion,
                             PrecioUnitario = fd.fd_preciounitario,
                             Exentas = fd.fd_exentas,
                             CincoPorciento = fd.fd_cincoporciento,
                             DiezPorciento = fd.fd_diezporciento,
                             PresupuestoCabID = fd.fd_presupuestocabid,
                             BoletaDepositoNro = fd.fd_nroboletadeposito,  //this.DBContext.GetDatosBoletaDepCobro(fd.fd_presupuestocabid).FirstOrDefault().NroBoletaDep
                             //CobroAnulado = pp.pp_anulado
                             CobroID = fd.fd_cobroid
                         })
                //.Where(b => b.AuditOperacion == AUDIT_OPERACION_INSERT && (b.CobroAnulado == null || (b.CobroAnulado.HasValue && !b.CobroAnulado.Value)))
                         .Where(b => b.AuditOperacion == AUDIT_OPERACION_INSERT)
                //.Where(b => b.AuditOperacion == AUDIT_OPERACION_INSERT && !(b.CobroAnulado.HasValue && !b.CobroAnulado.Value))
                         .OrderByDescending(a => a.FacturaCabeceraID)
                         .Take(200)
                         .ToList();

            this.BindingSourceBase_ExportExcelGrid = lFacturas;
            //this.LoadGridExportToExcel();

            var query = (from item in lFacturas
                         select new FacturaCabType
                         {
                             //Cabecera
                             FacturaFecha = item.FacturaFecha,
                             FacturaCabeceraID = item.FacturaCabeceraID,
                             FacturaTimbradoID = item.FacturaTimbradoID,
                             FacturaTimbradoHojaSuelta = item.FacturaTimbradoHojaSuelta,
                             FacturaNro = item.FacturaNro,
                             Anulado = item.Anulado,
                             ClienteID = item.ClienteID,
                             ClienteNombre = item.ClienteNombre,
                             ClienteIdiomaID = item.ClienteIdiomaID,
                             Direccion = item.Direccion,
                             FacturaTipo = item.FacturaTipo,
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
                             TotalFactura = item.TotalFactura,
                             TotalLetras = item.TotalLetras,
                             DocumentosAsociados = item.DocumentosAsociados,
                             UsuarioCargaID = item.UsuarioCargaID,
                             UsuarioCargaNombre = item.UsuarioCargaNombre,
                             AuditOperacion = item.AuditOperacion,
                             TieneAutorizacionVigente = item.TieneAutorizacionVigente
                         })
                         .GroupBy(x => new { x.FacturaCabeceraID }).Select(g => g.First()).ToList()
                         .Take(1);

            this.BindingSourceBase = query;

            #region Especificar campos para filtro
            this.SetFilter(CAMPO_FACTURACABECERAID, "Fact. Cab. ID", false);        
            this.SetFilter(CAMPO_FACTURATIMBRADOID, "Timbrado");
            this.SetFilter(CAMPO_FACTURATIPO, "Tipo Factura (C/R)");
            this.SetFilter(CAMPO_FACTURATIPO, "Tipo Fact. Descrip.");
            this.SetFilter(CAMPO_FACTURANRO, "N° Factura");
            this.SetFilter(CAMPO_NROREMISION, "N° Remisión");
            this.SetFilter(CAMPO_ANULADO, "Anulado (S/N)", false);
            this.SetFilter(CAMPO_CLIENTEID, "Cliente ID", false);
            this.SetFilter(CAMPO_CLIENTENOMBRE, "Cliente Nombre");
            this.SetFilter(CAMPO_DIRECCION, "Cliente Dirección");
            this.SetFilter(CAMPO_RUC, "Cliente RUC");
            this.SetFilter(CAMPO_TELEFONO, "Cliente Teléf.");
            this.SetFilter(CAMPO_MONEDAID, "Moneda ID", false);
            this.SetFilter(CAMPO_MONEDADESCRIPCION, "Moneda Descrip.");
            this.SetFilter(CAMPO_TOTALFACTURA, "Total Factura", false);
            this.SetFilter(CAMPO_PRESUPUESTOCABID, "Presup. ID", false);
            this.SetFilter(CAMPO_DOCUMENTOSASOCIADOS, "Documentos Asoc.");
            this.SetFilter(CAMPO_BOLETADEPOSITONRO, "N° Boleta Dep.");
            this.SetFilter(CAMPO_USUARIOCARGAID, "Gen. Por ID", false);
            this.SetFilter(CAMPO_USUARIOCARGANOMBRE, "Gen. Por Nombre");

            this.TituloBuscador = "Buscar Facturas";
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
            #region Cargar Combo Serie
            this.cargarCBSerieFactura();
            #endregion Cargar Combo Serie

            #region Ocultar Botones
            this.tbbBorrar.Visible = false;
            this.tbbEditar.Visible = false;
            this.tbbImprimir.Visible = true;
            this.tbbAnular.Visible = true;
            #endregion Ocultar Botones

            #region Asignación Eventos Deletados
            //Asignar Evento de Validación de carga de campos
            this.ValidarCamposEvent += ucCRUDPagoSolPago_ValidarCamposEvent;
            //Asignar Evento para Guardar Registro
            this.CRUDEvent += ucCRUDPagoSolPago_CRUDEvent;
            #endregion Asignación Eventos Deletados

            this.InsertActionMessage = "Se guardará e imprimirá la factura ¿Desea continuar?";
            this.InsertActionCaption = "Generación de Factura";

            //this.BindingSourceBase = null;
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
        private int cargarCBSerieFactura()
        {
            List<CBSerie> lista = new List<CBSerie>();

            if (this.FormEditStatus == BROWSE)
            {
                lista = (from ti in this.DBContext.ti_timbrado
                         select new CBSerie
                         {
                             TimbradoID = ti.ti_timbradoid,
                             DescripcionTimbrado = ti.ti_descripcion,
                             Vigente = ti.ti_vigente
                         })
                         //.Where(a => a.Vigente == true)
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
                             UsuarioID = su.su_usuarioid
                         })
                         .Where(a => a.Vigente == true && a.UsuarioID == this.UsuarioID)
                         .OrderBy(b => b.TimbradoID)
                         .ToList();

                //if (lista.Count == 0)
                //{
                //    MessageBox.Show("No cuenta con ningún timbrado habilitado para la generación de facturas." + Environment.NewLine +
                //                    "No se puede continuar.",
                //                    "Información",
                //                    MessageBoxButtons.OK,
                //                    MessageBoxIcon.Information);
                //    this.tbbCancelar_Click(this, null);
                //    return;
                //}                
            }
            this.cbSerie.DataSource = lista;
            this.cbSerie.DisplayMember = "DescripcionTimbrado";
            this.cbSerie.ValueMember = "TimbradoID";

            return lista.Count;
        }
        #endregion Combo Serie Factura

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
                MessageBox.Show("No se puede anular la factura debido a que no posee autorización vigente.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;

            }

            if (this.txtEstado.Text == ESTADO_ANULADOVALOR)
            {
                MessageBox.Show("No se puede anular la factura debido a que ya se encuentra en ese estado.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            string message = "";
            string caption = "";
            caption = "Anulación de Factura";
            message = "Se anulará la presente factura ¿Desea continuar?";
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
                    this.CargarFactura(this.dgvListadoABM.Rows[this.LastDGVIndex]);
            }
                
        }

        private void dtpFechaFactura_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaFactura.Text = this.dtpFechaFactura.Value.ToShortDateString();
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
            cft.Direccion = this.TruncateString(this.ObtenerDireccionDesdeCorreo(cliente.Correo), 62);
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
            try
            {
                if (fSelecPresupFactura == null)
                {
                    fSelecPresupFactura = new FSelecPresupFactura(this.DBContext, "Selección de Documentos");
                    fSelecPresupFactura.FormClosed += delegate { fSelecPresupFactura = null; };
                    fSelecPresupFactura.AceptarClick += f_AceptarClick;
                }

                fSelecPresupFactura.ListaPresupuestos = this.txtPresupAsoc.Text.Replace(", ", ",");
                fSelecPresupFactura.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + Environment.NewLine + ex.Message, "Información de Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        #endregion Métodos Locales

        #region Método Extendidos del ParentControl
        protected override void FilterEntity(string where = "", object[] filterParams = null)
        {
            try
            {
                this.limpiarDatos();

                var query = (from fc in this.DBContext.fc_facturacabecera
                             join fd in this.DBContext.fd_facturadetalle
                                 on fc.fc_facturacabeceraid equals fd.fd_facturacabeceraid
                             join mon in this.DBContext.Moneda
                                 on fc.fc_monedaid equals mon.ID
                             join AudFc in this.DBContext.Audit_fc_facturacabecera
                                 on fc.fc_facturacabeceraid equals AudFc.fc_facturacabeceraid
                             join cli in this.DBContext.Cliente
                                 on fc.fc_clienteid equals cli.ID into fc_cli
                             from cli in fc_cli.DefaultIfEmpty()
                             join uAud in this.DBContext.Usuario
                                 on AudFc.Audit_User.Substring(6, AudFc.Audit_User.Length) equals uAud.Usuario1
                             join ti in this.DBContext.ti_timbrado
                                 on fc.fc_timbradoid equals ti.ti_timbradoid
                             //join pp in this.DBContext.pp_pagopresupuesto
                             //    on fd.fd_presupuestocabid equals pp.pp_presupuestocabid into fd_pp
                             //from pp in fd_pp.DefaultIfEmpty()
                             select new FacturaAllType
                             {
                                 //Cabecera
                                 FacturaNro = fc.fc_nrofactura,
                                 FacturaCabeceraID = fc.fc_facturacabeceraid,
                                 FacturaTimbradoID = fc.fc_timbradoid,
                                 FacturaTimbradoHojaSuelta = ti.ti_facthojasuelta,
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
                                 TotalIVA = fc.fc_totaliva,
                                 LiqIVA5 = fc.fc_liqiva5,
                                 LiqIVA10 = fc.fc_liqiva10,
                                 TotalLiqIVA = fc.fc_totaliva,
                                 TotalFactura = fc.fc_total,
                                 TotalLetras = fc.fc_totalletras,
                                 DocumentosAsociados = fc.fc_documentosasoc,
                                 UsuarioCargaID = uAud.ID,
                                 UsuarioCargaNombre = uAud.NombrePila,
                                 AuditOperacion = AudFc.Audit_Operacion,
                                 TieneAutorizacionVigente = this.DBContext.GetAutorizacionPorDocumentoID(TIPODOCUMENTO_FACTURA_CLIENTE,
                                                                                                     fc.fc_facturacabeceraid,
                                                                                                     this.UsuarioID).FirstOrDefault().Value,
                                 //Detalles
                                 Cantidad = fd.fd_cantidad,
                                 Descripcion = fd.fd_descripcion,
                                 PrecioUnitario = fd.fd_preciounitario,
                                 Exentas = fd.fd_exentas,
                                 CincoPorciento = fd.fd_cincoporciento,
                                 DiezPorciento = fd.fd_diezporciento,
                                 PresupuestoCabID = fd.fd_presupuestocabid,
                                 BoletaDepositoNro = fd.fd_nroboletadeposito //this.DBContext.GetDatosBoletaDepCobro(fd.fd_presupuestocabid).FirstOrDefault().NroBoletaDep //pp.pp_nroboletadeposito,
                                 //CobroAnulado = pp.pp_anulado
                             })
                             .Where(b => b.AuditOperacion == AUDIT_OPERACION_INSERT);
                             //.Where(b => b.AuditOperacion == AUDIT_OPERACION_INSERT && (b.CobroAnulado == null || (b.CobroAnulado.HasValue && !b.CobroAnulado.Value)));
                             //.Where(b => b.AuditOperacion == AUDIT_OPERACION_INSERT && !(b.CobroAnulado.HasValue && !b.CobroAnulado.Value));
                             //.OrderByDescending(a => a.FacturaCabeceraID)
                             //.ToList();

                lFacturas.Clear();

                if (where != "")
                {
                    //this.BindingSourceBase = query.Where(where, filterParams).OrderByDescending(a => a.NotaCreditoID).ToList();
                    lFacturas = query.Where(where, filterParams).OrderByDescending(a => a.FacturaCabeceraID).ToList();
                }
                else
                {
                    //this.BindingSourceBase = query.OrderByDescending(a => a.NotaCreditoID).Take(50).ToList();
                    lFacturas = query.OrderByDescending(a => a.FacturaCabeceraID).Take(200).ToList();
                }

                this.BindingSourceBase_ExportExcelGrid = lFacturas;

                var query1 = (from item in lFacturas
                             select new FacturaCabType
                             {
                                 //Cabecera
                                 FacturaFecha = item.FacturaFecha,
                                 FacturaCabeceraID = item.FacturaCabeceraID,
                                 FacturaTimbradoID = item.FacturaTimbradoID,
                                 FacturaTimbradoHojaSuelta = item.FacturaTimbradoHojaSuelta,
                                 FacturaNro = item.FacturaNro,
                                 Anulado = item.Anulado,
                                 ClienteID = item.ClienteID,
                                 ClienteNombre = item.ClienteNombre,
                                 ClienteIdiomaID = item.ClienteIdiomaID,
                                 Direccion = item.Direccion,
                                 FacturaTipo = item.FacturaTipo,
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
                                 TotalFactura = item.TotalFactura,
                                 TotalLetras = item.TotalLetras,
                                 DocumentosAsociados = item.DocumentosAsociados,
                                 UsuarioCargaID = item.UsuarioCargaID,
                                 UsuarioCargaNombre = item.UsuarioCargaNombre,
                                 AuditOperacion = item.AuditOperacion,
                                 TieneAutorizacionVigente = item.TieneAutorizacionVigente
                             })
                             .GroupBy(x => new { x.FacturaCabeceraID }).Select(g => g.First()).ToList();

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


            this.dgvListadoABM.Columns[CAMPO_FACTURAFECHA].HeaderText = "Fecha Fact.";
            this.dgvListadoABM.Columns[CAMPO_FACTURAFECHA].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_FACTURAFECHA].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_FACTURAFECHA].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_FACTURAFECHA].Visible = true;
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

            this.dgvListadoABM.Columns[CAMPO_MONEDAABREV].HeaderText = "Moneda";
            this.dgvListadoABM.Columns[CAMPO_MONEDAABREV].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_MONEDAABREV].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_MONEDAABREV].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_TOTALFACTURA].HeaderText = "Total";
            this.dgvListadoABM.Columns[CAMPO_TOTALFACTURA].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_TOTALFACTURA].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_TOTALFACTURA].DefaultCellStyle.Format = "N2";
            this.dgvListadoABM.Columns[CAMPO_TOTALFACTURA].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_TOTALFACTURA].Visible = true;
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
            //base.tbbNuevo_Click(sender, e);

            //if (this.cargarCBSerieFactura() == 0)
            //{
            //    MessageBox.Show("No cuenta con ningún timbrado habilitado para la generación de facturas." + Environment.NewLine +
            //                    "No se puede continuar.",
            //                    "Información",
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Information);
            //    this.tbbCancelar_Click(sender, e);
            //    return;
            //}
            
            //this.limpiarDatos();
            //this.dtpFechaFactura.Value = System.DateTime.Now;
            //this.txtFechaFactura.Text = System.DateTime.Now.ToShortDateString();
            //this.txtEstado.Text = ESTADO_ACTIVOVALOR;
            //this.cbSerie.Focus();
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
            this.cargarCBSerieFactura();
            
            if (this.LastDGVIndex > -1)
            {
                this.CargarFactura(this.dgvListadoABM.Rows[this.LastDGVIndex]);
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

            this.txtFacturaID.ReadOnly = editar;
            this.txtGeneradoPorID.ReadOnly = editar;
            this.txtGeneradoPorNombre.ReadOnly = editar;
            this.cbSerie.Enabled = !editar;
            this.grpTipoFactura.Enabled = !editar;
            this.txtEstado.ReadOnly = editar;
            this.txtFechaFactura.ReadOnly = editar;
            this.dtpFechaFactura.Enabled = !editar;
            this.txtNroFactura.ReadOnly = editar;
            this.txtNroRemision.ReadOnly = editar;
            this.tSBCliente.Editable = !editar;
            this.txtRUC.ReadOnly = editar;
            this.txtDireccion.ReadOnly = editar;
            this.txtTelefono.ReadOnly = editar;
            this.tSBMoneda.Editable = !editar;
            //this.txtMontoTotal.ReadOnly = editar;
            this.btnBuscar.Enabled = !editar;
            this.dgvDetFactura.ReadOnly = editar;

            this.tbbAnular.Enabled = this.FormEditStatus == BROWSE;
            this.tbbActualizar.Enabled = this.FormEditStatus == BROWSE;
            this.tbbExportarExcel.Enabled = this.FormEditStatus == BROWSE;
        }
        #endregion ReadOnly condicional

        #region Limpiar Datos
        private void limpiarDatos()
        {
            this.txtFacturaID.Text = string.Empty;
            this.txtGeneradoPorID.Text = string.Empty;
            this.txtGeneradoPorNombre.Text = string.Empty;
            this.cbSerie.SelectedIndex = 0;
            this.rbContado.Checked = true;
            this.txtEstado.Text = string.Empty;
            this.txtFechaFactura.Text = string.Empty;
            this.txtNroFactura.Text = string.Empty;
            this.txtNroRemision.Text = string.Empty;
            this.tSBCliente.Clear();
            this.txtClienteIdiomaID.Text = string.Empty;
            this.txtRUC.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.tSBMoneda.Clear();
            this.txtPresupAsoc.Text = string.Empty;
            this.txtPresupuestosIDs.Text = string.Empty;
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

            this.dgvDetFactura.DataSource = null;

            this.txtHojaSuelta.Text = String.Empty;
        }
        #endregion Limpiar Datos

        #region CRUD
        
        private void CargarFactura(DataGridViewRow row)
        {
            this.limpiarDatos();
            string formatoNumero = row.Cells[CAMPO_MONEDADESCRIPCION].Value.ToString() == GUARANIES ? FORMATO_MONEDA_GUARANIES : FORMATO_MONEDA_OTROS;
            try
            {
                this.txtFacturaID.Text = row.Cells[CAMPO_FACTURACABECERAID].Value.ToString();
                this.cbSerie.SelectedValue = Convert.ToInt32(row.Cells[CAMPO_FACTURATIMBRADOID].Value.ToString());
                this.rbContado.Checked = row.Cells[CAMPO_FACTURATIPO].Value.ToString() == FACTURA_CONTADO;
                this.rbCredito.Checked = row.Cells[CAMPO_FACTURATIPO].Value.ToString() == FACTURA_CREDITO;
                this.txtEstado.Text = row.Cells[CAMPO_ANULADODESCRIPCION].Value.ToString();
                this.txtFechaFactura.Text = Convert.ToDateTime(row.Cells[CAMPO_FACTURAFECHA].Value.ToString()).ToShortDateString();
                this.dtpFechaFactura.Value = Convert.ToDateTime(row.Cells[CAMPO_FACTURAFECHA].Value.ToString());
                this.txtNroFactura.Text = row.Cells[CAMPO_FACTURANRO].Value != null ? row.Cells[CAMPO_FACTURANRO].Value.ToString() : string.Empty;
                this.txtNroRemision.Text = row.Cells[CAMPO_NROREMISION].Value != null ? row.Cells[CAMPO_NROREMISION].Value.ToString() : string.Empty;
                this.txtPresupAsoc.Text = string.Empty;
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
                this.txtMontoTotal.Text = String.Format(formatoNumero, Convert.ToDecimal(row.Cells[CAMPO_TOTALFACTURA].Value.ToString()));
                this.txtPresupAsoc.Text = row.Cells[CAMPO_DOCUMENTOSASOCIADOS].Value != null ? row.Cells[CAMPO_DOCUMENTOSASOCIADOS].Value.ToString() : string.Empty;
                this.txtGeneradoPorID.Text = row.Cells[CAMPO_USUARIOCARGAID].Value != null ? row.Cells[CAMPO_USUARIOCARGAID].Value.ToString() : string.Empty;
                this.txtGeneradoPorNombre.Text = row.Cells[CAMPO_USUARIOCARGANOMBRE].Value != null ? row.Cells[CAMPO_USUARIOCARGANOMBRE].Value.ToString() : string.Empty;
                this.lblAutorizacionVigente.Visible = (bool)row.Cells[CAMPO_AUTORIZACIONVIG].Value;

                this.txtHojaSuelta.Text = ((row.Cells[CAMPO_FACTURAHOJASUELTA].Value == null) || (!(bool)row.Cells[CAMPO_FACTURAHOJASUELTA].Value)) ? HOJASUELTA_NO : HOJASUELTA_SI;
                
                this.CargarDetallesFactura(Convert.ToInt32(this.txtFacturaID.Text));
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
            f.Titulo = "Factura N° " + this.txtNroFactura.Text + " - " + (this.txtHojaSuelta.Text == HOJASUELTA_SI ? "HS" : "PC");
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
            f.Titulo = "Factura N° " + this.txtNroFactura.Text;
            f.NombreArchivoAdjunto = "Factura";
            f.AsuntoMail = "Factura";
            f.CuerpoMail = "Factura";
            f.ShowDialog();
        }

        private List<ImprimirFacturaType> GenerarDatosFactura()
        {
            List<ImprimirFacturaType> listaDatosFactura = new List<ImprimirFacturaType>();
            string formatoNumero = this.tSBMoneda.DisplayMember == GUARANIES ? FORMATO_MONEDA_GUARANIES: FORMATO_MONEDA_OTROS; 

            foreach (DataGridViewRow row in this.dgvDetFactura.Rows)
            {
                ImprimirFacturaType datosFactura = new ImprimirFacturaType();
                datosFactura.FechaFactura = this.txtFechaFactura.Text;
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

            DatosTimbrado dTimbrado = this.GetDatosTimbrado(Convert.ToInt32(this.txtFacturaID.Text));

            foreach (DataGridViewRow row in this.dgvDetFactura.Rows)
            {
                ImprimirFacturaType datosFactura = new ImprimirFacturaType();
                datosFactura.FechaFactura = this.txtFechaFactura.Text;
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

        private List<fd_facturadetalle> GetDetallesFactura()
        {
            List<fd_facturadetalle> Result = new List<fd_facturadetalle>();

            foreach (DataGridViewRow row in this.dgvDetFactura.Rows)
            {
                Nullable<int> cobroID = null;


                if (row.Cells[CAMPO_COBROID].Value != null)
                    cobroID = Convert.ToInt32(row.Cells[CAMPO_COBROID].Value.ToString());
 
                Result.Add(new fd_facturadetalle
                {
                    fd_facturacabeceraid = 0,
                    fd_cantidad = Convert.ToDecimal(row.Cells[CAMPO_CANTIDAD].Value.ToString()),
                    fd_descripcion = @row.Cells[CAMPO_DESCRIPCION].Value != null ? row.Cells[CAMPO_DESCRIPCION].Value.ToString() : string.Empty,
                    fd_preciounitario = Convert.ToDecimal(row.Cells[CAMPO_PRECIOUNITARIO].Value.ToString()),
                    fd_exentas = Convert.ToDecimal(row.Cells[CAMPO_EXENTAS].Value.ToString()),
                    fd_cincoporciento = Convert.ToDecimal(row.Cells[CAMPO_CINCOPORCIENTO].Value.ToString()),
                    fd_diezporciento = Convert.ToDecimal(row.Cells[CAMPO_DIEZPORCIENTO].Value.ToString()),
                    fd_presupuestocabid = Convert.ToInt32(row.Cells[CAMPO_PRESUPUESTOCABID].Value.ToString()),
                    fd_nroboletadeposito = row.Cells[CAMPO_BOLETADEPOSITONRO].Value != null ? row.Cells[CAMPO_BOLETADEPOSITONRO].Value.ToString() : string.Empty,
                    fd_cobroid = cobroID
                });

            }
            return Result;
        }

        private void ucCRUDPagoSolPago_CRUDEvent(object sender, EventArgs e)
        {
            this.CalcularTotal();
            fc_facturacabecera fc = new fc_facturacabecera();
            fc.fc_facturacabeceraid = 0;
            fc.fc_timbradoid = Convert.ToInt32(this.cbSerie.SelectedValue.ToString());
            //fc.fc_nrofactura: Ver la manera de obtener el número vía trigger
            fc.fc_anulado = false;
            fc.fc_fechafactura = Convert.ToDateTime(this.txtFechaFactura.Text);

            if (this.tSBCliente.KeyMember != string.Empty)
                fc.fc_clienteid = Convert.ToInt32(this.tSBCliente.KeyMember);
            else fc.fc_clienteid = null;

            fc.fc_clientenombre = this.tSBCliente.DisplayMember;

            if (this.txtNroRemision.Text != string.Empty)
                fc.fc_nroremision = this.txtNroRemision.Text;

            if (this.txtDireccion.Text != string.Empty)
                fc.fc_direccion = this.txtDireccion.Text;

            fc.fc_tipofactura = this.rbContado.Checked ? FACTURA_CONTADO : FACTURA_CREDITO;

            if (this.txtRUC.Text != string.Empty)
                fc.fc_ruc = this.txtRUC.Text;

            if (this.txtTelefono.Text != string.Empty)
                fc.fc_telefono = this.txtTelefono.Text;

            if (this.txtPresupAsoc.Text != string.Empty)
                fc.fc_documentosasoc = this.txtPresupAsoc.Text;
            
            fc.fc_monedaid = Convert.ToInt32(this.tSBMoneda.KeyMember);
            fc.fc_totalexentas = Convert.ToDecimal(this.txtTotalExentas.Text);
            fc.fc_totaliva5 = Convert.ToDecimal(this.txtTotalIVA5.Text);
            fc.fc_totaliva10 = Convert.ToDecimal(this.txtTotalIVA10.Text);
            fc.fc_liqiva5 = Convert.ToDecimal(this.txtLiqIVA5.Text);
            fc.fc_liqiva10 = Convert.ToDecimal(this.txtLiqIVA10.Text);
            fc.fc_totaliva = Convert.ToDecimal(this.txtLiqTotalIVA.Text);
            fc.fc_total = Convert.ToDecimal(this.txtMontoTotal.Text);
            fc.fc_totalletras = this.ObtenerTotalEnLetras(Convert.ToInt32(this.txtClienteIdiomaID.Text));
            
            if (this.FormEditStatus != BROWSE)
            {
                List<fd_facturadetalle> detalles = this.GetDetallesFactura();
                fc = this.GuardarRegistroLocal<fc_facturacabecera, fd_facturadetalle>(fc,
                                                                                 detalles,
                                                                                 CAMPO_FACTURACABECERAPK_TABLA,
                                                                                 CAMPO_FACTURADETALLEFK_TABLA);
            }

            if (fc != null)
            {
                int index = 0;
                if (this.FormEditStatus == INSERT)
                {
                    this.FilterEntity("", null);
                    this.CargarFactura(this.dgvListadoABM.Rows[0]);
                }

                this.FormEditStatus = BROWSE;
                this.dgvListadoABM.CurrentCell = this.dgvListadoABM.Rows[index].Cells[CAMPO_FACTURAFECHA];
                this.dgvListadoABM.CurrentCell.Selected = true;
                
                this.ImprimirFactura();
            }
        }

        private void ucCRUDPagoSolPago_ValidarCamposEvent(object sender, EventArgs e)
        {
            #region Validaciones
            DateTime fec = new DateTime();
            if ((this.txtFechaFactura.Text == string.Empty) || (!DateTime.TryParseExact(this.txtFechaFactura.Text,
                                                                                        "dd/MM/yyyy",
                                                                                        null,
                                                                                        System.Globalization.DateTimeStyles.None,
                                                                                        out fec)))
            {
                MessageBox.Show("Debe ingresar una fecha de factura válida.",
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
                MessageBox.Show("Debe ingresar una moneda para la factura.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (this.tSBCliente.KeyMember == string.Empty)
            {
                MessageBox.Show("Debe ingresar un nombre de cliente para la factura.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if ((this.dgvDetFactura.DataSource == null) || (this.dgvDetFactura.Rows.Count == 0))
            {
                MessageBox.Show("No se puede procesar una factura sin detalles.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;

            }

            this.ValidOK = true;
            #endregion Validaciones
        }

        private ps_pagosolicitud guardarPago(BerkeDBEntities context = null)
        {
            ps_pagosolicitud ps = new ps_pagosolicitud();

            #region EDIT
            if (this.FormEditStatus == EDIT)
            {
                int pagoProveedorID = Convert.ToInt32(this.txtFacturaID.Text);

                
                
            }
            #endregion EDIT

            #region INSERT
            else if (this.FormEditStatus == INSERT)
            {
                

                context.ps_pagosolicitud.Add(ps);
            }
            #endregion INSERT

            return ps;
        }

        
        private void AnularDialogHandler(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    this.AnularFactura(Convert.ToInt32(this.txtFacturaID.Text));
                }
            }
        }

        private void AnularFactura(int FacturaID)
        {
            bool success = false;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        fc_facturacabecera fc = context.fc_facturacabecera.First(a => a.fc_facturacabeceraid == FacturaID);
                        fc.fc_anulado = true;
                        fc.fc_fechaanulacion = System.DateTime.Now;
                        fc.fc_usuarioanulacion = VWGContext.Current.Session["WindowsUser"].ToString();

                        //foreach (pc_presupuestocab pc in context.pc_presupuestocab.Where(a => a.pc_facturacabid == FacturaID))
                        //{
                        //    pc.pc_facturacabid = null;
                        //    if (fc.fc_nrofactura == pc.pc_string1) //remover nro_factura en caso de que haya sido generado
                        //    {
                        //        pc.pc_string1 = null;
                        //    }
                        //}

                        fpc_facturapresupuestocab fpc = context.fpc_facturapresupuestocab
                                                        .OrderByDescending(a => a.fpc_facturapresupuestocabid)
                                                        .First(b => b.fpc_facturacabid == FacturaID && b.fpc_activo);

                        foreach (fpd_facturapresupuestodet fpd in context.fpd_facturapresupuestodet.Where(a => a.fpd_facturapresupuestocabid == fpc.fpc_facturapresupuestocabid))
                        {
                            //numbers = numbers.Where(val => val != numToRemove).ToArray();
                            pc_presupuestocab pc = context.pc_presupuestocab.First(a => a.pc_presupuestocabid == fpd.fpd_presupuestocabid);

                            if (pc.pc_string1 != null)
                            {
                                string[] nroFacturas = pc.pc_string1.Replace(" ", string.Empty).Split(',');
                                nroFacturas = nroFacturas.Where(val => val != fc.fc_nrofactura).ToArray();

                                if (nroFacturas.Length > 0)
                                    pc.pc_string1 = String.Join(", ", nroFacturas);
                                else pc.pc_string1 = null;
                            }

                            if (pc.pc_descripcion != null)
                            {
                                List<fd_facturadetalle> lFd = context.fd_facturadetalle.Where(a => a.fd_facturacabeceraid == fc.fc_facturacabeceraid).ToList();

                                string descripcion = pc.pc_descripcion;
                                foreach(fd_facturadetalle row in lFd)
                                {
                                    Regex rex = new Regex(row.fd_descripcion.TrimStart('\r', '\n').TrimEnd('\r', '\n'), RegexOptions.IgnoreCase);
                                    descripcion = rex.Replace(descripcion, string.Empty, 1);
                                    //descripcion = descripcion.Replace(row.fd_descripcion, string.Empty);
                                }

                                descripcion = descripcion.TrimStart('\r', '\n').TrimEnd('\r', '\n');

                                if (descripcion.Trim() != string.Empty)
                                    pc.pc_descripcion = descripcion.TrimEnd('\r', '\n');
                                else pc.pc_descripcion = null;
                            }
                             
                            
                        }

                        fpc.fpc_activo = false;
                        
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
                this.CargarFactura(this.dgvListadoABM.Rows[this.LastDGVIndex]);
                MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion Métodos de Edición de Datos

        #region Eventos delegados
        private void f_AceptarClick(object sender, EventArgs e)
        {
            this.txtPresupAsoc.Text = fSelecPresupFactura.ListaPresupuestos;
            this.tTBaseForm.SetToolTip(this.txtPresupAsoc, this.txtPresupAsoc.Text);
            this.txtPresupuestosIDs.Text = fSelecPresupFactura.ListaPresupuestosIDs;
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
                this.txtFechaFactura.Text = fSelecPresupFactura.CobroFechaDeposito.Value.ToShortDateString();
            }

            if (this.txtPresupuestosIDs.Text != string.Empty)
            {
                this.dgvDetFactura.DataSource = this.ObtenerDatosPresupuestos();

                if (this.dgvDetFactura.RowCount > 0)
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
            this.dgvDetFactura.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 11.5F, GraphicsUnit.Pixel);
            this.dgvDetFactura.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dgvDetFactura.DefaultCellStyle.Font = new Font("Arial", 11.5F, GraphicsUnit.Pixel);
            this.dgvDetFactura.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvDetFactura.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            this.dgvDetFactura.ItemsPerPage = 4;
            this.dgvDetFactura.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetFactura.MultiSelect = false;
            //this.dgvDetFactura.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            foreach (DataGridViewColumn col in this.dgvDetFactura.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            foreach (DataGridViewRow row in this.dgvDetFactura.Rows)
            {
                row.Cells[CAMPO_DESCRIPCION].Value = this.SpliceText(row.Cells[CAMPO_DESCRIPCION].Value.ToString(), 80);

                string [] descrip = row.Cells[CAMPO_DESCRIPCION].Value.ToString().Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                if (descrip.Length > 1)
                {
                    row.Height = 22 * (descrip.Length - 1) + 8;
                }
            }

            int displayIndex = 0;

            this.dgvDetFactura.Columns[CAMPO_CANTIDAD].HeaderText = "Cantidad";
            this.dgvDetFactura.Columns[CAMPO_CANTIDAD].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDetFactura.Columns[CAMPO_CANTIDAD].Width = 60;
            this.dgvDetFactura.Columns[CAMPO_CANTIDAD].DisplayIndex = displayIndex;
            this.dgvDetFactura.Columns[CAMPO_CANTIDAD].DefaultCellStyle.Format = this.tSBMoneda.DisplayMember == GUARANIES ? FORMATO_MONEDA_GUARANIES_GRILLA : FORMATO_MONEDA_OTROS_GRILLA;
            this.dgvDetFactura.Columns[CAMPO_CANTIDAD].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvDetFactura.Columns[CAMPO_CANTIDAD].Visible = true;
            this.dgvDetFactura.Columns[CAMPO_CANTIDAD].ReadOnly = false;
            displayIndex++;

            this.dgvDetFactura.Columns[CAMPO_DESCRIPCION].HeaderText = "Descripción";
            this.dgvDetFactura.Columns[CAMPO_DESCRIPCION].Width = 500;
            this.dgvDetFactura.Columns[CAMPO_DESCRIPCION].DisplayIndex = displayIndex;
            this.dgvDetFactura.Columns[CAMPO_DESCRIPCION].Visible = true;
            this.dgvDetFactura.Columns[CAMPO_DESCRIPCION].ReadOnly = false;
            //this.dgvDetFactura.Columns[CAMPO_DESCRIPCION].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            ////this.dgvDetFactura.Columns[CAMPO_DESCRIPCION].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            displayIndex++;

            this.dgvDetFactura.Columns[CAMPO_PRECIOUNITARIO].HeaderText = "Pr. Unit.";
            this.dgvDetFactura.Columns[CAMPO_PRECIOUNITARIO].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDetFactura.Columns[CAMPO_PRECIOUNITARIO].Width = 80;
            this.dgvDetFactura.Columns[CAMPO_PRECIOUNITARIO].DisplayIndex = displayIndex;
            this.dgvDetFactura.Columns[CAMPO_PRECIOUNITARIO].DefaultCellStyle.Format = this.tSBMoneda.DisplayMember == GUARANIES ? FORMATO_MONEDA_GUARANIES_GRILLA : FORMATO_MONEDA_OTROS_GRILLA;
            this.dgvDetFactura.Columns[CAMPO_PRECIOUNITARIO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvDetFactura.Columns[CAMPO_PRECIOUNITARIO].Visible = true;
            this.dgvDetFactura.Columns[CAMPO_PRECIOUNITARIO].ReadOnly = false;
            displayIndex++;

            this.dgvDetFactura.Columns[CAMPO_EXENTAS].HeaderText = "Exentas";
            this.dgvDetFactura.Columns[CAMPO_EXENTAS].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDetFactura.Columns[CAMPO_EXENTAS].Width = 80;
            this.dgvDetFactura.Columns[CAMPO_EXENTAS].DisplayIndex = displayIndex;
            this.dgvDetFactura.Columns[CAMPO_EXENTAS].DefaultCellStyle.Format = this.tSBMoneda.DisplayMember == GUARANIES ? FORMATO_MONEDA_GUARANIES_GRILLA : FORMATO_MONEDA_OTROS_GRILLA;
            this.dgvDetFactura.Columns[CAMPO_EXENTAS].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvDetFactura.Columns[CAMPO_EXENTAS].Visible = true;
            this.dgvDetFactura.Columns[CAMPO_EXENTAS].ReadOnly = false;
            displayIndex++;

            this.dgvDetFactura.Columns[CAMPO_CINCOPORCIENTO].HeaderText = "5%";
            this.dgvDetFactura.Columns[CAMPO_CINCOPORCIENTO].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDetFactura.Columns[CAMPO_CINCOPORCIENTO].Width = 80;
            this.dgvDetFactura.Columns[CAMPO_CINCOPORCIENTO].DisplayIndex = displayIndex;
            this.dgvDetFactura.Columns[CAMPO_CINCOPORCIENTO].DefaultCellStyle.Format = this.tSBMoneda.DisplayMember == GUARANIES ? FORMATO_MONEDA_GUARANIES_GRILLA : FORMATO_MONEDA_OTROS_GRILLA;
            this.dgvDetFactura.Columns[CAMPO_CINCOPORCIENTO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvDetFactura.Columns[CAMPO_CINCOPORCIENTO].Visible = true;
            this.dgvDetFactura.Columns[CAMPO_CINCOPORCIENTO].ReadOnly = false;
            displayIndex++;

            this.dgvDetFactura.Columns[CAMPO_DIEZPORCIENTO].HeaderText = "10%";
            this.dgvDetFactura.Columns[CAMPO_DIEZPORCIENTO].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDetFactura.Columns[CAMPO_DIEZPORCIENTO].Width = 80;
            this.dgvDetFactura.Columns[CAMPO_DIEZPORCIENTO].DisplayIndex = displayIndex;
            this.dgvDetFactura.Columns[CAMPO_DIEZPORCIENTO].DefaultCellStyle.Format = this.tSBMoneda.DisplayMember == GUARANIES ? FORMATO_MONEDA_GUARANIES_GRILLA : FORMATO_MONEDA_OTROS_GRILLA;
            this.dgvDetFactura.Columns[CAMPO_DIEZPORCIENTO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvDetFactura.Columns[CAMPO_DIEZPORCIENTO].Visible = true;
            this.dgvDetFactura.Columns[CAMPO_DIEZPORCIENTO].ReadOnly = false;
            displayIndex++;
        }

        private List<DetalleFacturaType> ObtenerDatosPresupuestos()
        {
            List<DetalleFacturaType> detFactura = new List<DetalleFacturaType>();
            #region Iteración
            decimal[] dbx = this.txtMontosCobros.Text.Split(';').Select(decimal.Parse).ToArray();
            int[] cbx = this.txtCobrosIDs.Text.Split(';').Select(int.Parse).ToArray();
            int cx = 0;

            foreach (string val in this.txtPresupuestosIDs.Text.Split(','))
            {
                int PresupuestoCabID = Convert.ToInt32(val);
                pc_presupuestocab presup = this.DBContext.pc_presupuestocab.FirstOrDefault(a => a.pc_presupuestocabid == PresupuestoCabID);

                if ((presup.pc_origen == ORIGEN_M) || (presup.pc_origen == ORIGEN_O))
                {
                    #region M/O
                    var q = this.DBContext.cp_cotizacionesxpresup.Where(a => a.cp_presupuestocabid == PresupuestoCabID).ToList();

                    //GetDatosBoletaDepCobro_Result dbx = this.DBContext.GetDatosBoletaDepCobro(PresupuestoCabID).FirstOrDefault();

                    DetalleFacturaType det = new DetalleFacturaType();
                    det.PresupuestoCabID = PresupuestoCabID;
                    det.Cantidad = 1;
                    det.PrecioUnitario = dbx[cx]; //presup.pc_total;
                    det.Exentas = 0;
                    det.CincoPorciento = 0;
                    det.DiezPorciento = dbx[cx]; //presup.pc_total;
                    det.BoletaDepositoNro = this.txtNroBoletas.Text;

                    if (cbx[cx] > 0)
                        det.CobroID = cbx[cx];
                    else det.CobroID = null;


                    //det.BoletaDepositoNro = this.DBContext.GetDatosBoletaDepCobro(PresupuestoCabID).FirstOrDefault().NroBoletaDep;
                    
                    string listaCotizaciones = "";
                    int cantPropietarios = 0;
                    string listaPropietarios = "";
                    string gPropietario = "";

                    //int cantClases = 0;
                    string listaClases = string.Empty;
                    //string gClase = string.Empty;

                    //int cantDenominaciones = 0;
                    string listaDenominaciones = string.Empty;
                    //string gDenominacion = string.Empty;

                    if (q.Count > 0)
                    {
                        foreach (var qRow in q)
                        {
                            if (listaCotizaciones != "")
                                listaCotizaciones += ",";

                            int cotizacionID = qRow.cp_cotizacionid;
                            listaCotizaciones += cotizacionID.ToString();

                            int expedienteID = this.DBContext.cc_cotizacioncab.First(a => a.cc_cotizacioncabid == cotizacionID).cc_expedienteid.Value;
                            List<GetDatosExpediente_Result> dExpe = this.DBContext.GetDatosExpediente(presup.pc_origen, expedienteID).ToList();

                            if (dExpe.Count > 0)
                            {
                                #region Propietarios
                                string propietario = dExpe.First().Propietario;

                                if (propietario != gPropietario)
                                {
                                    cantPropietarios++;
                                    gPropietario = propietario;

                                    if (listaPropietarios != "")
                                        listaPropietarios += ", ";

                                    listaPropietarios += propietario;
                                }
                                #endregion Propietarios

                                #region Clases
                                string clase = dExpe.First().ClaseNro.HasValue ? dExpe.First().ClaseNro.Value.ToString() : string.Empty;
                                //cantClases++;
                                
                                if (listaClases != string.Empty)
                                        listaClases += ", ";

                                listaClases += clase;
                                #endregion Clases

                                #region Denominaciones
                                string denominacion = dExpe.First().Denominacion;

                                //cantDenominaciones++;
                                if (listaDenominaciones != string.Empty)
                                    listaDenominaciones += ", ";
                                
                                listaDenominaciones += "\"" + denominacion + "\"";
                                #endregion Denominaciones
                            }
                        }

                        int TramiteID = presup.pc_tramiteid;
                        List<RepHojaCotizacion_Result> repHojaCotizacion = new List<RepHojaCotizacion_Result>();
                        repHojaCotizacion = this.DBContext.RepHojaCotizacion(listaCotizaciones,
                                                                             "A",
                                                                             TramiteID)
                                                                             .GroupBy(x => new { x.Acta }).Select(g => g.First())
                                                                             .ToList();

                        string listaActas = string.Empty;
                        string descripcion = string.Empty;
                        if (repHojaCotizacion.Count > 0)
                        {
                            if (this.cbSerie.GetItemText(this.cbSerie.SelectedItem) == SERIE_2)
                            {
                                if (Convert.ToInt32(this.txtClienteIdiomaID.Text) == IDIOMA_ESPANOL)
                                {
                                    if (repHojaCotizacion.Count > 1)
                                    {
                                        descripcion = this.DBContext.pa_parametros.First(a => a.clave == DESCRIPCION_FACTURA_SERIE2_PLU_ESP).valor;
                                    }
                                    else
                                    {
                                        descripcion = this.DBContext.pa_parametros.First(a => a.clave == DESCRIPCION_FACTURA_SERIE2_SING_ESP).valor;
                                    }
                                }
                                else
                                {
                                    if (repHojaCotizacion.Count > 1)
                                    {
                                        descripcion = this.DBContext.pa_parametros.First(a => a.clave == DESCRIPCION_FACTURA_SERIE2_PLU_ING).valor;
                                    }
                                    else
                                    {
                                        descripcion = this.DBContext.pa_parametros.First(a => a.clave == DESCRIPCION_FACTURA_SERIE2_SING_ING).valor;
                                    }
                                }                                
                            }
                            else
                            {
                                listaActas = Convert.ToInt32(this.txtClienteIdiomaID.Text) == IDIOMA_ESPANOL ? "Acta: " : "Application: ";
                                if (repHojaCotizacion.Count > 1)
                                    listaActas = Convert.ToInt32(this.txtClienteIdiomaID.Text) == IDIOMA_ESPANOL ? "Actas: " : "Applications: ";

                                det.Descripcion = repHojaCotizacion.First().TramiteDescripcion;
                            }

                            int cantidadCaracteres = listaActas.Length;
                            bool noPrimeraIteracion = true;

                            foreach (RepHojaCotizacion_Result hcRow in repHojaCotizacion)
                            {
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

                            if (this.cbSerie.GetItemText(this.cbSerie.SelectedItem) != SERIE_2)
                            {
                                if (listaActas.Split(':')[1] != " --/--")
                                {
                                    det.Descripcion += Environment.NewLine + listaActas;
                                }
                            }
                            else
                            {
                                det.Descripcion = String.Format(descripcion,
                                                                repHojaCotizacion.First().TramiteDescripcion,
                                                                listaDenominaciones, listaActas, listaClases);
                            }
                        }

                        if (this.cbSerie.GetItemText(this.cbSerie.SelectedItem) != SERIE_2)
                        {
                            string lblPropietarios = Convert.ToInt32(this.txtClienteIdiomaID.Text) == IDIOMA_ESPANOL ? "Propietario: {0}" : "Owner: {0}";
                            if (cantPropietarios > 0)
                            {
                                if (cantPropietarios > 1)
                                    lblPropietarios = Convert.ToInt32(this.txtClienteIdiomaID.Text) == IDIOMA_ESPANOL ? "Propietarios: {0}" : "Owners: {0}";

                                if (listaPropietarios != string.Empty)
                                    det.Descripcion += Environment.NewLine + String.Format(lblPropietarios, listaPropietarios);
                            }

                            det.Descripcion = det.Descripcion == null ? "Sin descripción" : det.Descripcion;
                        }
                        detFactura.Add(det);
                    }
                    #endregion M/O
                }
                else
                {
                    #region C/R
                    //GetDatosBoletaDepCobro_Result dbx = this.DBContext.GetDatosBoletaDepCobro(PresupuestoCabID).FirstOrDefault();

                    DetalleFacturaType det = new DetalleFacturaType();
                    det.PresupuestoCabID = PresupuestoCabID;
                    det.Cantidad = 1;
                    det.PrecioUnitario = dbx[cx]; //presup.pc_total;
                    det.Exentas = 0;
                    det.CincoPorciento = 0;
                    det.DiezPorciento = dbx[cx]; //presup.pc_total;
                    det.Descripcion = presup.pc_descripcion == null ? "Sin descripción" : presup.pc_descripcion;
                    det.BoletaDepositoNro = this.txtNroBoletas.Text;
                    //det.BoletaDepositoNro = this.DBContext.GetDatosBoletaDepCobro(PresupuestoCabID).FirstOrDefault().NroBoletaDep;
                    detFactura.Add(det);
                    #endregion C/R
                }
                cx++;
            }
            #endregion Iteración

            return detFactura;
        }

        private void CargarDetallesFactura(int facturaCabID)
        {
            List<DetalleFacturaType> det = (from lista in this.lFacturas
                                            select new DetalleFacturaType
                                            {
                                                FacturaCabID = lista.FacturaCabeceraID,
                                                Descripcion = lista.Descripcion,
                                                Cantidad = lista.Cantidad,
                                                PrecioUnitario = lista.PrecioUnitario,
                                                Exentas = lista.Exentas,
                                                CincoPorciento = lista.CincoPorciento,
                                                DiezPorciento = lista.DiezPorciento,
                                                PresupuestoCabID = lista.PresupuestoCabID,
                                                BoletaDepositoNro = lista.BoletaDepositoNro,
                                                CobroID = lista.CobroID
                                            })
                                            .Where( a => a.FacturaCabID == facturaCabID )
                                            //.GroupBy( b => b.PresupuestoCabID )
                                            //.Select( grp => grp.First() )
                                            .ToList();

            
            string listaBoletas = string.Empty;

            string gBoletaNro = string.Empty;
            for(int i = 0; i < det.Count; i++)
            {
                if (gBoletaNro != det[i].BoletaDepositoNro)
                {
                    listaBoletas += (listaBoletas != string.Empty ? ", " : string.Empty) + (det[i].BoletaDepositoNro != string.Empty ? det[i].BoletaDepositoNro : string.Empty);
                    gBoletaNro = det[i].BoletaDepositoNro;
                }
            }

            this.txtNroBoletas.Text = listaBoletas;
            this.dgvDetFactura.DataSource = det;
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
            
            foreach (DataGridViewRow row in this.dgvDetFactura.Rows)
            {
                totalExentas += Convert.ToDecimal(row.Cells[CAMPO_EXENTAS].Value.ToString());
                totalIVA5 += Convert.ToDecimal(row.Cells[CAMPO_CINCOPORCIENTO].Value.ToString());
                totalIVA10 += (Convert.ToDecimal(row.Cells[CAMPO_CANTIDAD].Value.ToString()) * Convert.ToDecimal(row.Cells[CAMPO_PRECIOUNITARIO].Value.ToString())); //Convert.ToDecimal(row.Cells[CAMPO_DIEZPORCIENTO].Value.ToString());
                row.Cells[CAMPO_DIEZPORCIENTO].Value = (Convert.ToDecimal(row.Cells[CAMPO_CANTIDAD].Value.ToString()) * Convert.ToDecimal(row.Cells[CAMPO_PRECIOUNITARIO].Value.ToString()));
            }
            
            if (this.tSBMoneda.DisplayMember == GUARANIES)
            {
                totalIVA = decimal.Round(totalIVA5) + decimal.Round(totalIVA10);
                totalExentas = decimal.Round(totalExentas);
                totalGral = totalExentas + totalIVA;

                liqIVA5 = decimal.Round(totalIVA5 / 21);
                liqIVA10 = decimal.Round(totalIVA10 / 11);
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

                liqIVA5 = totalIVA5 / 21;
                liqIVA10 = totalIVA10 / 11;
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


        private TEntidadCab ObtenerNroFactura<TEntidadCab>(BerkeDBEntities context, TEntidadCab cab, string nroFacturaFieldName, string timbradoIDFieldName, string docAsocFieldName)
            where TEntidadCab : class
        {
            int timbradoID = Convert.ToInt32(context.Entry(cab).Property(timbradoIDFieldName).CurrentValue);

            ti_timbrado ti = context.ti_timbrado.First(a => a.ti_timbradoid == timbradoID);
            nf_numeracionfactura nf = context.nf_numeracionfactura.First(a => a.nf_timbradoid == timbradoID);

            long nroFactura = nf.nf_ultnrofactura + 1;
            string nroFacturaConFormato = String.Format(FORMATO_FACTURA, ti.ti_serie.PadLeft(3, PAD), ti.ti_sucursal.PadLeft(3, PAD), nroFactura.ToString().PadLeft(7, PAD));

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
                context.Entry(cab).Property(CAMPO_FACTURACABECERA_DOCUMENTOSASOC).CurrentValue = nroFacturaConFormato;

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
                            cab = this.ObtenerNroFactura(r.Context, cab, CAMPO_FACTURACABECERA_NROFACTURA, CAMPO_FACTURACABECERA_TIMBRADOID, CAMPO_FACTURACABECERA_DOCUMENTOSASOC);
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
            this.ImprimirFacturaDigital();            
        }

        private void tbbNuevo_Click_1(object sender, EventArgs e)
        {
            this.tabListaABM.SelectedIndex = 1;
            this.FormEditStatus = INSERT;

            if (this.cargarCBSerieFactura() == 0)
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
            this.txtFechaFactura.Text = System.DateTime.Now.ToShortDateString();
            this.txtEstado.Text = ESTADO_ACTIVOVALOR;
            this.rbCredito.Checked = this.cbSerie.GetItemText(this.cbSerie.SelectedItem) == SERIE_2;
            this.cbSerie.Focus();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            this.ImprimirFactura();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string descripcion = pc.pc_descripcion;
            //Regex rex = new Regex(row.fd_descripcion.TrimStart('\r', '\n').TrimEnd('\r', '\n'), RegexOptions.IgnoreCase);
            //                        descripcion = rex.Replace(descripcion, string.Empty, 1);
        }

        
    }
}