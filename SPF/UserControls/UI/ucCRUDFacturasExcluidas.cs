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
using SPF.UserControls.Base;
using SPF.Forms.Base;
using SPF.Forms;
using SPF.Base;

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.ObjectModel;

using System.Data.SqlClient;
using System.Text.RegularExpressions;



#endregion

namespace SPF.UserControls.UI
{
    public partial class ucCRUDFacturasExcluidas : ucBaseForm2015
    {
        #region Propiedades
        public int MonedaID
        {
            set { this.monedaID = value; }
            get { return this.monedaID; }
        }
        #endregion Propiedades

        #region Variables
        private frmPickBase fPickFactura;
        private BindingSource bS;
        private int monedaID;
        private List<SolicitudExclusionAll> factExc;
        #endregion Variables

        #region Constantes
        private const string CAMPO_SOLEXCCABID = "SolExcCabId";
        private const string CAMPO_SOLEXCCABPROVEEDORID = "SolExcCabProveedorId";
        private const string CAMPO_SOLEXCCABPROVEEDORNOMBRE = "SolExcCabProveedorNombre";
        private const string CAMPO_SOLEXCCABNROFACTURA = "SolExcCabNroFactura";
        private const string CAMPO_SOLEXCCABFECHAFACTURA = "SolExcCabFechaFactura";
        private const string CAMPO_SOLEXCCABFECHAEXCLUSION = "SolExcCabFechaExclusion";
        private const string CAMPO_SOLEXCCABIMPORTE = "SolExcCabImporte";
        private const string CAMPO_SOLEXCCABSALDO = "SolExcCabSaldo";
        private const string CAMPO_SOLEXCCABACTIVO = "SolExcCabActivo";
        private const string CAMPO_SOLEXCCABMONEDAID = "SolExcCabMonedaId";
        private const string CAMPO_SOLEXCCABMONEDADESCRIP = "SolExcCabMonedaDescrip";
        private const string CAMPO_SOLEXCCABTIPOFACTURAID = "SolExcCabTipoFacturaId";
        private const string CAMPO_SOLEXCCABTIPOFACTURADESCRIP = "SolExcCabTipoFacturaDescrip";
        private const string CAMPO_SOLEXCCABMONEDAABREV = "SolExcCabMonedaAbrev";
        
        //Detalles
        private const string CAMPO_SOLEXCDETCABID = "SolExcDetCabId";
        private const string CAMPO_SOLICITUDPAGOCABECERAID = "SolicitudPagoCabeceraId";
        private const string CAMPO_SOLICITUDPAGOCABECERAMONEDAID = "SolicitudPagoCabeceraMonedaId";
        private const string CAMPO_SOLICITUDPAGODETALLEID = "SolicitudPagoDetalleId";
        private const string CAMPO_SOLICITUDPAGODETALLEMONTO = "SolicitudPagoDetalleMonto";
        private const string CAMPO_SOLICITUDPAGODETALLESALDO = "SolicitudPagoDetalleSaldo";
        private const string CAMPO_SOLICITUDPAGOCABECERAOBS = "SolicitudPagoCabeceraObs";
        private const string CAMPO_SOLICITUDPAGOCABECERACLIENTE = "SolicitudPagoCabeceraCliente";
        private const string CAMPO_SOLICITUDPAGODETALLETARIFA = "SolicitudPagoDetalleTarifa";
        private const string CAMPO_SOLICITUDPAGOCABECERAASOCTRAMITE = "SolicitudPagoCabeceraAsocTramite";
        private const string CAMPO_SOLICITUDPAGOCABECERAASOCTRAMITESTR = "SolicitudPagoCabeceraAsocTramiteStr";
        
        private const string CAMPO_EXTRA = "Extra";
        private const string CAMPO_IMPORTE = "Importe";
        private const string CAMPO_SALDO = "Saldo";
        private const string FILTRO_FACTURA_EXCLUIR = "E";
        private const string FORMATO_SIN_DECIMALES = "{0:N0}";
        private const string FORMATO_CON_DECIMALES = "{0:N2}";
        private const string FORMATO_SIN_DECIMALES_GRILLA = "N0";
        private const string FORMATO_CON_DECIMALES_GRILLA = "N2";
        private const string FORMATO_FECHAHORA = "dd/MM/yyyy";

        private const int MONEDA_GUARANI_ID = 3;
        private const string TITULO_GRILLA_SOLICITUDES = "Solicitudes Asociadas a la Factura - {0} registros";
        private const string PROVEEDOR_STR = "{0} ({1})";
        private const string MONTOS_STR = "{0} {1}";
        #endregion Constantes

        #region Constructores
        public ucCRUDFacturasExcluidas()
        {
            InitializeComponent();
        }

        public ucCRUDFacturasExcluidas(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();
            this.Titulo = Titulo;
            this.DBContext = dbContext;
            this.MonedaID = MONEDA_GUARANI_ID;
            this.lblSolicitudesNro.Text = string.Format(TITULO_GRILLA_SOLICITUDES, "0");

            var listaIds = this.DBContext.sec_solexclusioncab
                            .OrderByDescending(a => a.sec_solexclusioncabid)
                            .SelectMany(f => new[] { f.sec_solexclusioncabid })
                            .Take(50)
                            .ToArray();
            
            factExc = new List<SolicitudExclusionAll>();

            factExc = (from sec in this.DBContext.sec_solexclusioncab
                       join sed in this.DBContext.sed_solexclusiondet
                        on sec.sec_solexclusioncabid equals sed.sed_solexclusioncabid
                       join spd in this.DBContext.spd_solicitudpagodet
                        on sed.sed_solicitudpagodetid equals spd.spd_solicitudpagodetid
                       join spc in this.DBContext.spc_solicitudpagocab
                        on spd.spd_solicitudpagocabid equals spc.spc_solicitudpagocabid
                       join pr in this.DBContext.pr_proveedor
                        on sec.sec_proveedorid equals pr.pr_proveedorid
                       join cli in this.DBContext.Cliente
                        on spc.spc_clienteid equals cli.ID into spc_cli
                       from cli in spc_cli.DefaultIfEmpty()
                       join tar in this.DBContext.Tarifas
                        on spd.spd_tarifaid equals tar.ID
                       join monC in this.DBContext.Moneda
                        on sec.sec_monedaid equals monC.ID
                       join tf in this.DBContext.tf_tipofactura
                        on sec.sec_tipofacturaid equals tf.tf_tipofacturaid
                       select new SolicitudExclusionAll
                       {
                           //Cabecera
                           SolExcCabId = sec.sec_solexclusioncabid,
                           SolExcCabProveedorId = sec.sec_proveedorid,
                           SolExcCabProveedorNombre = pr.pr_nombre,
                           SolExcCabNroFactura = sec.sec_nrofactura,
                           SolExcCabFechaFactura = sec.sec_fechafactura,
                           SolExcCabFechaExclusion = sec.sec_fechaexclusion,
                           SolExcCabImporte = sec.sec_importe,
                           SolExcCabSaldo = sec.sec_saldo,
                           SolExcCabActivo = sec.sec_activo,
                           SolExcCabMonedaId = sec.sec_monedaid,
                           SolExcCabMonedaDescrip = monC.Descripcion,
                           SolExcCabMonedaAbrev = monC.AbrevMoneda,
                           SolExcCabTipoFacturaId = sec.sec_tipofacturaid,
                           SolExcCabTipoFacturaDescrip = tf.tf_descripcion,
                           //Detalle
                           SolicitudPagoDetalleId = spd.spd_solicitudpagodetid,
                           SolicitudPagoCabeceraId = spd.spd_solicitudpagocabid,
                           SolicitudPagoCabeceraMonedaId = spc.spc_monedaid,
                           SolicitudPagoDetalleMonto = spd.spd_total,
                           SolicitudPagoDetalleSaldo = spd.spd_saldo,
                           SolicitudPagoCabeceraObs = spc.spc_observacion,
                           SolicitudPagoCabeceraCliente = cli.Nombre,
                           SolicitudPagoDetalleTarifa = tar.Descripcion,
                           SolicitudPagoCabeceraAsocTramite = spc.spc_tipoasociacionpresup

                       })
                       //.Where(b => listaIds.Contains(b.SolExcCabId) && b.SolExcCabActivo)
                       .Where(b => listaIds.Contains(b.SolExcCabId))
                       .ToList();

            var query = (from item in factExc
                         select new SolicitudExclusionCabecera
                         {
                             //Cabecera
                             SolExcCabId = item.SolExcCabId,
                             SolExcCabProveedorId = item.SolExcCabProveedorId,
                             SolExcCabProveedorNombre = item.SolExcCabProveedorNombre,
                             SolExcCabNroFactura = item.SolExcCabNroFactura,
                             SolExcCabFechaFactura = item.SolExcCabFechaFactura,
                             SolExcCabFechaExclusion = item.SolExcCabFechaExclusion,
                             SolExcCabImporte = item.SolExcCabImporte,
                             SolExcCabSaldo = item.SolExcCabSaldo,
                             SolExcCabActivo = item.SolExcCabActivo,
                             SolExcCabMonedaId = item.SolExcCabMonedaId,
                             SolExcCabMonedaDescrip = item.SolExcCabMonedaDescrip,
                             SolExcCabMonedaAbrev = item.SolExcCabMonedaAbrev,
                             SolExcCabTipoFacturaId = item.SolExcCabTipoFacturaId,
                             SolExcCabTipoFacturaDescrip = item.SolExcCabTipoFacturaDescrip
                         })
                         .GroupBy(x => new { x.SolExcCabId }).Select(g => g.First()).ToList();

            this.BindingSourceBase = query.ToList();

            #region Especificar campos para filtro
            this.SetFilter(CAMPO_SOLEXCCABID, "Exclusión ID", false);
            this.SetFilter(CAMPO_SOLEXCCABPROVEEDORID, "Proveedor ID", false);
            this.SetFilter(CAMPO_SOLEXCCABPROVEEDORNOMBRE, "Proveedor Nombre");
            this.SetFilter(CAMPO_SOLEXCCABNROFACTURA, "Proveedor N° Factura");
            this.SetFilter(CAMPO_SOLEXCCABFECHAFACTURA, "Proveedor Fecha Fact.");
            this.SetFilter(CAMPO_SOLEXCCABMONEDAID, "Moneda ID", false);
            this.SetFilter(CAMPO_SOLEXCCABMONEDADESCRIP, "Moneda Descrip.");
            this.SetFilter(CAMPO_SOLEXCCABTIPOFACTURAID, "T. Fact. ID", false);
            this.SetFilter(CAMPO_SOLEXCCABTIPOFACTURADESCRIP, "T. Fact. Desc.");
            this.TituloBuscador = "Buscar Exclusiones de Facturas";
            #endregion Especificar campos para filtro

            this.bS = new BindingSource();

            #region Asignación Eventos Deletados
            //Asignar Evento de Validación de carga de campos
            this.ValidarCamposEvent += ucCRUDFacturasExcluidas_ValidarCamposEvent;
            //Asignar Evento para Guardar Registro
            this.CRUDEvent += ucCRUDFacturasExcluidas_CRUDEvent;
            #endregion Asignación Eventos Deletados

            #region Inicializar TextSearchBoxes
            //this.tSBFactura.KeyMemberWidth = 70;
            //this.tSBFactura.ToolTip = "Elegir Factura";
            //this.tSBFactura.AceptarClick += tSBFactura_AceptarClick;

            this.btnBuscar.Click += tSBFactura_AceptarClick;
            #endregion Inicializar TextSearchBoxes

            this.tbbEditar.Visible = false;
            this.tbbBorrar.Visible = false;
            this.Sep5.Visible = true;
            this.tbbAnular.Visible = true;
            this.tbbAnular.Text = "Rem";
            this.tbbAnular.ToolTipText = "Remover Exclusión de Factura";
            this.tbbAnular.Click += tbbAnular_Click;
        }
        #endregion Constructores

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

                fPickFactura.CampoIDNombre = "Id";
                fPickFactura.CampoDescripNombre = "Informacion";
                fPickFactura.LabelCampoID = "ID";
                fPickFactura.LabelCampoDescrip = "Información";
                fPickFactura.Col2Width = 600;

                fPickFactura.Titulo = "Elegir Factura";
                fPickFactura.NombreCampo = "Datos Fact.";
                fPickFactura.LabelCampoID = "Sol. Det. ID";
                fPickFactura.LabelCampoDescrip = "Datos Factura";
                fPickFactura.SetExplicitToolTipIDTextBox("N° o Fecha de Factura, Proveedor, Referencia u Observación");
                fPickFactura.HideDescriptionTextBox(true);
                fPickFactura.UseExplicitToolTip = true;
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

                string valorInt = "";
                string valorAlfa = fPickFactura.GetIDFilter;

                var query = (from data in this.DBContext.GetDocumentoAPagar(FILTRO_FACTURA_EXCLUIR,
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

                fPickFactura.LoadData<PagoProveedorFilterTypeSolicitud>(query.AsQueryable());
            }
        }

        private void fPickFactura_AceptarFiltrarClick(object sender, EventArgs e)
        {
            //this.tSBFactura.DisplayMember = fPickFactura.ValorDescrip;
            //this.tSBFactura.KeyMember = fPickFactura.ValorID;
            //this.txtNroFactura.Text = fPickFactura.ValorDescrip;

            string[] datosFactura = fPickFactura.GetValor(CAMPO_EXTRA).ToString().Split('#');

            if (datosFactura.Count() > 0)
            {
                this.MonedaID = Convert.ToInt32(datosFactura[4]);

                this.txtProveedor.Text = datosFactura[1] + " (" + datosFactura[0] + ")";
                this.txtFechaFactura.Text = datosFactura[2];
                this.txtNroFactura.Text = datosFactura[3];
                this.txtTipoFactura.Text = datosFactura[7];
                this.txtImporte.Text = datosFactura[6] + " " +
                                        string.Format((this.MonedaID == MONEDA_GUARANI_ID ? FORMATO_SIN_DECIMALES : FORMATO_CON_DECIMALES), Convert.ToDecimal(fPickFactura.GetValor(CAMPO_IMPORTE).ToString().Replace('.', ',')));
                this.txtImporteVal.Text = Convert.ToDecimal(fPickFactura.GetValor(CAMPO_IMPORTE)).ToString();
                this.txtSaldo.Text = datosFactura[6] + " " +
                                        string.Format((this.MonedaID == MONEDA_GUARANI_ID ? FORMATO_SIN_DECIMALES : FORMATO_CON_DECIMALES), Convert.ToDecimal(fPickFactura.GetValor(CAMPO_SALDO).ToString().Replace('.', ',')));
                this.txtSaldoVal.Text = Convert.ToDecimal(fPickFactura.GetValor(CAMPO_SALDO)).ToString();
                this.txtProveedorID.Text = datosFactura[0];
                this.txtTipoFacturaID.Text = datosFactura[8];
                int[] detalles = fPickFactura.ValorID.Split(',').Select(Int32.Parse).ToArray();

                //var qry = from spd in this.DBContext.spd_solicitudpagodet
                //          where detalles.Contains(spd.spd_solicitudpagodetid)
                //          select spd;

                var qry = (from spd in this.DBContext.spd_solicitudpagodet
                           join spc in this.DBContext.spc_solicitudpagocab 
                            on spd.spd_solicitudpagocabid equals spc.spc_solicitudpagocabid
                           join cli in this.DBContext.Cliente
                            on spc.spc_clienteid equals cli.ID into spc_cli
                            from cli in spc_cli.DefaultIfEmpty()
                           join tar in this.DBContext.Tarifas
                            on spd.spd_tarifaid equals tar.ID
                           select new SolicitudExclusionDetalle
                           {
                               SolicitudPagoCabeceraId = spd.spd_solicitudpagocabid,
                               SolicitudPagoCabeceraMonedaId = spc.spc_monedaid,
                               SolicitudPagoDetalleId = spd.spd_solicitudpagodetid,
                               SolicitudPagoDetalleMonto = spd.spd_total,
                               SolicitudPagoDetalleSaldo = spd.spd_saldo,
                               SolicitudPagoCabeceraObs = spc.spc_observacion,
                               SolicitudPagoCabeceraCliente = cli.Nombre,
                               SolicitudPagoDetalleTarifa = tar.Descripcion,
                               SolicitudPagoCabeceraAsocTramite = spc.spc_tipoasociacionpresup
                           })
                          .Where(a => detalles.Contains(a.SolicitudPagoDetalleId))
                          .ToList();

                this.dgvSolDet.DataSource = qry;
                this.lblSolicitudesNro.Text = string.Format(TITULO_GRILLA_SOLICITUDES, string.Format(FORMATO_SIN_DECIMALES, qry.Count.ToString()));
                this.FormatearGrillaSolicitudes();
            }

            //fPickFactura.Close();
            fPickFactura.Hide();
        }
        #endregion Factura
        #endregion Picks

        #region Formatear Grilla Solicitudes
        private void FormatearGrillaSolicitudes()
        {
            //this.dgvSolDet.RowHeadersDefaultCellStyle.Font = new Font("Arial", 8F, GraphicsUnit.Pixel);
            this.dgvSolDet.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 12F, GraphicsUnit.Pixel);
            this.dgvSolDet.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dgvSolDet.DefaultCellStyle.Font = new Font("Arial", 12F, GraphicsUnit.Pixel);
            this.dgvSolDet.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvSolDet.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            this.dgvSolDet.ItemsPerPage = 12;
            this.dgvSolDet.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.dgvSolDet.MultiSelect = false;

            foreach (DataGridViewColumn col in this.dgvSolDet.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            int displayIndex = 0;

            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGOCABECERAID].HeaderText = "Sol. Cab. ID";
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGOCABECERAID].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGOCABECERAID].HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGOCABECERAID].Width = 80;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGOCABECERAID].DisplayIndex = displayIndex;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGOCABECERAID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGOCABECERAID].Visible = true;
            displayIndex++;

            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGODETALLEID].HeaderText = "Sol. Det. ID";
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGODETALLEID].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGODETALLEID].HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGODETALLEID].Width = 80;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGODETALLEID].DisplayIndex = displayIndex;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGODETALLEID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGODETALLEID].Visible = true;
            displayIndex++;

            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGOCABECERACLIENTE].HeaderText = "Cliente";
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGOCABECERACLIENTE].HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGOCABECERACLIENTE].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGOCABECERACLIENTE].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGOCABECERACLIENTE].Width = 250;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGOCABECERACLIENTE].DisplayIndex = displayIndex;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGOCABECERACLIENTE].Visible = true;
            displayIndex++;

            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGODETALLETARIFA].HeaderText = "Tarifa";
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGODETALLETARIFA].HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGODETALLETARIFA].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGODETALLETARIFA].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGODETALLETARIFA].Width = 180;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGODETALLETARIFA].DisplayIndex = displayIndex;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGODETALLETARIFA].Visible = true;
            displayIndex++;

            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGOCABECERAASOCTRAMITESTR].HeaderText = "Tipo Tarifa";
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGOCABECERAASOCTRAMITESTR].HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGOCABECERAASOCTRAMITESTR].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGOCABECERAASOCTRAMITESTR].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGOCABECERAASOCTRAMITESTR].Width = 180;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGOCABECERAASOCTRAMITESTR].DisplayIndex = displayIndex;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGOCABECERAASOCTRAMITESTR].Visible = true;
            displayIndex++;

            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGODETALLEMONTO].HeaderText = "Importe";
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGODETALLEMONTO].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGODETALLEMONTO].HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGODETALLEMONTO].Width = 80;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGODETALLEMONTO].DisplayIndex = displayIndex;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGODETALLEMONTO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGODETALLEMONTO].DefaultCellStyle.Format = this.MonedaID == MONEDA_GUARANI_ID ? FORMATO_SIN_DECIMALES_GRILLA : FORMATO_CON_DECIMALES_GRILLA;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGODETALLEMONTO].Visible = true;
            displayIndex++;

            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGODETALLESALDO].HeaderText = "Saldo";
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGODETALLESALDO].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGODETALLESALDO].HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGODETALLESALDO].Width = 80;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGODETALLESALDO].DisplayIndex = displayIndex;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGODETALLESALDO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGODETALLESALDO].DefaultCellStyle.Format = this.MonedaID == MONEDA_GUARANI_ID ? FORMATO_SIN_DECIMALES_GRILLA : FORMATO_CON_DECIMALES_GRILLA;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGODETALLESALDO].Visible = true;
            displayIndex++;

            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGOCABECERAOBS].HeaderText = "Observación";
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGOCABECERAOBS].HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGOCABECERAOBS].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGOCABECERAOBS].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGOCABECERAOBS].Width = 250;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGOCABECERAOBS].DisplayIndex = displayIndex;
            this.dgvSolDet.Columns[CAMPO_SOLICITUDPAGOCABECERAOBS].Visible = true;
            displayIndex++;
        }
        #endregion Formatear Grilla Solicitudes

        #region Método Extendidos del ParentControl
        protected override void FilterEntity(string where = "", object[] filterParams = null)
        {
            try
            {
                this.limpiarDatos();

                var query = (from sec in this.DBContext.sec_solexclusioncab
                             join sed in this.DBContext.sed_solexclusiondet
                              on sec.sec_solexclusioncabid equals sed.sed_solexclusioncabid
                             join spd in this.DBContext.spd_solicitudpagodet
                              on sed.sed_solicitudpagodetid equals spd.spd_solicitudpagodetid
                             join spc in this.DBContext.spc_solicitudpagocab
                              on spd.spd_solicitudpagocabid equals spc.spc_solicitudpagocabid
                             join pr in this.DBContext.pr_proveedor
                              on sec.sec_proveedorid equals pr.pr_proveedorid
                             join cli in this.DBContext.Cliente
                              on spc.spc_clienteid equals cli.ID into spc_cli
                             from cli in spc_cli.DefaultIfEmpty()
                             join tar in this.DBContext.Tarifas
                              on spd.spd_tarifaid equals tar.ID
                             join monC in this.DBContext.Moneda
                              on sec.sec_monedaid equals monC.ID
                             join tf in this.DBContext.tf_tipofactura
                              on sec.sec_tipofacturaid equals tf.tf_tipofacturaid
                             select new SolicitudExclusionAll
                             {
                                 //Cabecera
                                 SolExcCabId = sec.sec_solexclusioncabid,
                                 SolExcCabProveedorId = sec.sec_proveedorid,
                                 SolExcCabProveedorNombre = pr.pr_nombre,
                                 SolExcCabNroFactura = sec.sec_nrofactura,
                                 SolExcCabFechaFactura = sec.sec_fechafactura,
                                 SolExcCabFechaExclusion = sec.sec_fechaexclusion,
                                 SolExcCabImporte = sec.sec_importe,
                                 SolExcCabSaldo = sec.sec_saldo,
                                 SolExcCabActivo = sec.sec_activo,
                                 SolExcCabMonedaDescrip = monC.Descripcion,
                                 SolExcCabMonedaAbrev = monC.AbrevMoneda,
                                 SolExcCabTipoFacturaId = sec.sec_tipofacturaid,
                                 SolExcCabTipoFacturaDescrip = tf.tf_descripcion,
                                 //Detalle
                                 SolicitudPagoDetalleId = spd.spd_solicitudpagodetid,
                                 SolicitudPagoCabeceraId = spd.spd_solicitudpagocabid,
                                 SolicitudPagoCabeceraMonedaId = spc.spc_monedaid,
                                 SolicitudPagoDetalleMonto = spd.spd_total,
                                 SolicitudPagoDetalleSaldo = spd.spd_saldo,
                                 SolicitudPagoCabeceraObs = spc.spc_observacion,
                                 SolicitudPagoCabeceraCliente = cli.Nombre,
                                 SolicitudPagoDetalleTarifa = tar.Descripcion,
                                 SolicitudPagoCabeceraAsocTramite = spc.spc_tipoasociacionpresup
                             });
                             //.Where(b => b.SolExcCabActivo);
                       //.Where(b => listaIds.Contains(b.SolExcCabId) && b.SolExcCabActivo);
                       //.ToList();

                factExc.Clear();
                if (where != "")
                {
                    factExc = query.Where(where, filterParams).OrderByDescending(a => a.SolExcCabId).ToList();
                }
                else
                {
                    var listaIds = this.DBContext.sec_solexclusioncab
                            .OrderByDescending(a => a.sec_solexclusioncabid)
                            .SelectMany(f => new[] { f.sec_solexclusioncabid })
                            .Take(50)
                            .ToArray();
                    factExc = query
                                .Where(b => listaIds.Contains(b.SolExcCabId))
                                .OrderByDescending(a => a.SolExcCabId).ToList();
                }

                this.BindingSourceBase_ExportExcelGrid = factExc;

                var query1 = (from item in factExc
                             select new SolicitudExclusionCabecera
                             {
                                 //Cabecera
                                 SolExcCabId = item.SolExcCabId,
                                 SolExcCabProveedorId = item.SolExcCabProveedorId,
                                 SolExcCabProveedorNombre = item.SolExcCabProveedorNombre,
                                 SolExcCabNroFactura = item.SolExcCabNroFactura,
                                 SolExcCabFechaFactura = item.SolExcCabFechaFactura,
                                 SolExcCabFechaExclusion = item.SolExcCabFechaExclusion,
                                 SolExcCabImporte = item.SolExcCabImporte,
                                 SolExcCabSaldo = item.SolExcCabSaldo,
                                 SolExcCabActivo = item.SolExcCabActivo,
                                 SolExcCabMonedaId = item.SolExcCabMonedaId,
                                 SolExcCabMonedaDescrip = item.SolExcCabMonedaDescrip,
                                 SolExcCabMonedaAbrev = item.SolExcCabMonedaAbrev,
                                 SolExcCabTipoFacturaId = item.SolExcCabTipoFacturaId,
                                 SolExcCabTipoFacturaDescrip = item.SolExcCabTipoFacturaDescrip
                             })
                             .GroupBy(x => new { x.SolExcCabId }).Select(g => g.First()).ToList();

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

            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABID].HeaderText = "Exclusión ID";
            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABID].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABID].Width = 100;
            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABID].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABID].Visible = true;
            displayIndex++;

            //this.dgvListadoABM.Columns[CAMPO_SOLICITUDDETID].HeaderText = "Sol. Det. ID";
            //this.dgvListadoABM.Columns[CAMPO_SOLICITUDDETID].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.dgvListadoABM.Columns[CAMPO_SOLICITUDDETID].Width = 70;
            //this.dgvListadoABM.Columns[CAMPO_SOLICITUDDETID].DisplayIndex = displayIndex;
            //this.dgvListadoABM.Columns[CAMPO_SOLICITUDDETID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dgvListadoABM.Columns[CAMPO_SOLICITUDDETID].Visible = true;
            //displayIndex++;

            //this.dgvListadoABM.Columns[CAMPO_PROVEEDORID].HeaderText = "Proveedor ID";
            //this.dgvListadoABM.Columns[CAMPO_PROVEEDORID].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.dgvListadoABM.Columns[CAMPO_PROVEEDORID].Width = 70;
            //this.dgvListadoABM.Columns[CAMPO_PROVEEDORID].DisplayIndex = displayIndex;
            //this.dgvListadoABM.Columns[CAMPO_PROVEEDORID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dgvListadoABM.Columns[CAMPO_PROVEEDORID].Visible = true;
            //displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABPROVEEDORNOMBRE].HeaderText = "Proveedor Nombre";
            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABPROVEEDORNOMBRE].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABPROVEEDORNOMBRE].Width = 250;
            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABPROVEEDORNOMBRE].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABPROVEEDORNOMBRE].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABNROFACTURA].HeaderText = "Proveedor N° Factura";
            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABNROFACTURA].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABNROFACTURA].Width = 180;
            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABNROFACTURA].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABNROFACTURA].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABFECHAFACTURA].HeaderText = "Prov. Fec. Factura";
            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABFECHAFACTURA].Width = 120;
            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABFECHAFACTURA].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABFECHAFACTURA].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABIMPORTE].HeaderText = "Total Factura";
            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABIMPORTE].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABIMPORTE].Width = 100;
            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABIMPORTE].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABIMPORTE].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABIMPORTE].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABSALDO].HeaderText = "Saldo Factura";
            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABSALDO].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABSALDO].Width = 100;
            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABSALDO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABSALDO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABSALDO].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABACTIVO].HeaderText = "Activo";
            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABACTIVO].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABACTIVO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_SOLEXCCABACTIVO].Visible = true;
            displayIndex++;
        }

        protected override void tbbNuevo_Click(object sender, EventArgs e)
        {
            this.limpiarDatos();
            base.tbbNuevo_Click(sender, e);
            this.chkActivo.Checked = true;
            this.btnBuscar.Focus();
        }

        protected override void tbbEditar_Click(object sender, EventArgs e)
        {
            this.FormEditStatus = EDIT;

            if (this.tabListaABM.SelectedIndex != 2)
            {
                this.tabListaABM.SelectedIndex = 1;
                //this.txtNombreContinente.Focus();
            }   
        }

        protected override void tbbCancelar_Click(object sender, EventArgs e)
        {
            base.tbbCancelar_Click(sender, e);

            if (this.LastDGVIndex > -1)
            {
                this.CargarSolExcCab(this.dgvListadoABM.Rows[this.LastDGVIndex]);
            }
            else
            {
                this.limpiarDatos();
            }
        }

        protected override void tabListaABM_SelectedIndexChanging(object sender, TabControlCancelEventArgs e)
        {
            if (this.FormEditStatus == EDIT)
            {
                e.Cancel = e.TabPage.TabIndex == 0;
            }
            else if (this.FormEditStatus == INSERT)
            {
                e.Cancel = e.TabPage.TabIndex != 1;
            }
            else e.Cancel = false;
        }

        private void dgvListadoABM_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.RowIndex > -1) &&
                (
                ((e.ColumnIndex == (((DataGridView)sender).Columns[CAMPO_SOLEXCCABIMPORTE].Index))) ||
                ((e.ColumnIndex == (((DataGridView)sender).Columns[CAMPO_SOLEXCCABSALDO].Index))))
                )
            {
                if (Convert.ToInt32(((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_SOLEXCCABMONEDAID].Value.ToString()) == MONEDA_GUARANI_ID)
                    e.CellStyle.Format = FORMATO_SIN_DECIMALES_GRILLA;
                else
                    e.CellStyle.Format = FORMATO_CON_DECIMALES_GRILLA;
            }
        }

        private void dgvListadoABM_RowEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            if ((this.LastDGVIndex > -1) && (!this.IsClosing))
                this.CargarSolExcCab(this.dgvListadoABM.Rows[this.LastDGVIndex]);
        }

        #endregion Método Extendidos del ParentControl

        #region Limpiar Datos
        private void limpiarDatos()
        {
            this.txtIDExclusionFactura.Text = string.Empty;
            this.txtProveedorID.Text = string.Empty;
            this.txtTipoFacturaID.Text = string.Empty;
            this.txtImporteVal.Text = string.Empty;
            this.txtSaldoVal.Text = string.Empty;
            this.txtMonedaID.Text = string.Empty;

            foreach (Control ctrl in this.grpDatosFactura.Controls)
            {
                if (ctrl.GetType() == typeof(TextBox))
                {
                    ((TextBox)ctrl).Text = string.Empty;
                }
            }

            this.dgvSolDet.DataSource = null;
            this.lblSolicitudesNro.Text = string.Format(TITULO_GRILLA_SOLICITUDES, "0");
            this.chkActivo.Checked = false;
        }
        #endregion Limpiar Datos

        #region ReadOnly condicional
        protected override void Editable(bool editar)
        {
            this.btnBuscar.Enabled = !editar;
        }
        #endregion ReadOnly condicional

        #region CRUD
        private void ucCRUDFacturasExcluidas_CRUDEvent(object sender, EventArgs e)
        {
            try
            {
                sec_solexclusioncab sec = new sec_solexclusioncab();

                sec.sec_solexclusioncabid = this.FormEditStatus != INSERT ? Convert.ToInt32(this.txtIDExclusionFactura.Text) : 0;
                sec.sec_proveedorid = Convert.ToInt32(this.txtProveedorID.Text);
                sec.sec_nrofactura = this.txtNroFactura.Text;
                sec.sec_fechafactura = Convert.ToDateTime(this.txtFechaFactura.Text);
                sec.sec_fechaexclusion = DateTime.Now;
                sec.sec_activo = true;
                sec.sec_importe = Convert.ToDecimal(this.txtImporteVal.Text);
                sec.sec_saldo = Convert.ToDecimal(this.txtSaldoVal.Text);
                sec.sec_tipofacturaid = Convert.ToInt32(this.txtTipoFacturaID.Text);
                sec.sec_monedaid = this.MonedaID;

                List<sed_solexclusiondet> lSed = new List<sed_solexclusiondet>();
                foreach (DataGridViewRow row in this.dgvSolDet.Rows)
                {
                    sed_solexclusiondet sed = new sed_solexclusiondet();
                    sed.sed_solicitudpagodetid = (int)row.Cells[CAMPO_SOLICITUDPAGODETALLEID].Value;
                    lSed.Add(sed);
                }

                bool exito = false;

                if (this.FormEditStatus != BROWSE)
                {
                    sec = this.GuardarRegistro<sec_solexclusioncab, sed_solexclusiondet>(sec, lSed, "sec_solexclusioncabid", "sed_solexclusioncabid");
                }
                else
                {
                    //
                }

                if ((sec != null) || (exito))
                {
                    int index = 0;
                    if (this.FormEditStatus == INSERT)
                    {
                        this.FilterEntity("", null);
                        this.CargarSolExcCab(this.dgvListadoABM.Rows[0]);
                    }
                    else if ((this.FormEditStatus == EDIT) || (this.FormEditStatus == BROWSE))
                    {
                        this.FilterEntity(this.WhereString, this.FilterParam);
                        this.CargarSolExcCab(this.dgvListadoABM.Rows[this.LastDGVIndex]);
                        index = this.LastDGVIndex;
                    }

                    this.FormEditStatus = BROWSE;

                    if (this.dgvListadoABM.RowCount > 0)
                    {
                        this.dgvListadoABM.CurrentCell = this.dgvListadoABM.Rows[index].Cells[0];
                        this.dgvListadoABM.CurrentCell.Selected = true;
                    }

                    MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ucCRUDFacturasExcluidas_ValidarCamposEvent(object sender, EventArgs e)
        {
            if (this.txtProveedor.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Debe seleccionar alguna factura.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }
            this.ValidOK = true;
        }

        private void CargarSolExcCab(DataGridViewRow row)
        {
            this.txtIDExclusionFactura.Text = row.Cells[CAMPO_SOLEXCCABID].Value.ToString();
            this.txtProveedorID.Text = row.Cells[CAMPO_SOLEXCCABPROVEEDORID].Value.ToString();
            this.chkActivo.Checked = Convert.ToBoolean(row.Cells[CAMPO_SOLEXCCABACTIVO].Value);
            this.txtProveedor.Text = string.Format(PROVEEDOR_STR, row.Cells[CAMPO_SOLEXCCABPROVEEDORNOMBRE].Value.ToString(), row.Cells[CAMPO_SOLEXCCABPROVEEDORID].Value.ToString());
            this.txtNroFactura.Text = row.Cells[CAMPO_SOLEXCCABNROFACTURA].Value.ToString();
            this.txtFechaFactura.Text = Convert.ToDateTime(row.Cells[CAMPO_SOLEXCCABFECHAFACTURA].Value).ToString(FORMATO_FECHAHORA);
            this.txtImporte.Text = string.Format(MONTOS_STR, row.Cells[CAMPO_SOLEXCCABMONEDAABREV].Value.ToString(),
                                    Convert.ToInt32(row.Cells[CAMPO_SOLEXCCABMONEDAID].Value.ToString()) == MONEDA_GUARANI_ID
                                    ? string.Format(FORMATO_SIN_DECIMALES, row.Cells[CAMPO_SOLEXCCABIMPORTE].Value)
                                    : string.Format(FORMATO_CON_DECIMALES, row.Cells[CAMPO_SOLEXCCABIMPORTE].Value));
            this.txtImporteVal.Text = row.Cells[CAMPO_SOLEXCCABIMPORTE].Value.ToString();
            this.txtSaldo.Text = string.Format(MONTOS_STR, row.Cells[CAMPO_SOLEXCCABMONEDAABREV].Value.ToString(),
                                    Convert.ToInt32(row.Cells[CAMPO_SOLEXCCABMONEDAID].Value.ToString()) == MONEDA_GUARANI_ID
                                    ? string.Format(FORMATO_SIN_DECIMALES, row.Cells[CAMPO_SOLEXCCABSALDO].Value)
                                    : string.Format(FORMATO_CON_DECIMALES, row.Cells[CAMPO_SOLEXCCABSALDO].Value));
            this.txtSaldoVal.Text = row.Cells[CAMPO_SOLEXCCABSALDO].Value.ToString();
            this.txtTipoFactura.Text = row.Cells[CAMPO_SOLEXCCABTIPOFACTURADESCRIP].Value.ToString();
            this.txtTipoFacturaID.Text = row.Cells[CAMPO_SOLEXCCABTIPOFACTURAID].Value.ToString();
            //this.txtMonedaID.Text = row.Cells[CAMPO_SOLEXCCABMONEDAID].Value.ToString();
            this.MonedaID = (int)row.Cells[CAMPO_SOLEXCCABMONEDAID].Value;

            this.CargarSolExcDet(Convert.ToInt32(this.txtIDExclusionFactura.Text));
        }

        private void CargarSolExcDet(int solExcCabId)
        {
            var qry = (from det in this.factExc
                       select new SolicitudExclusionDetalle
                       {
                           SolExcDetCabId = det.SolExcCabId,
                           SolicitudPagoCabeceraId = det.SolicitudPagoCabeceraId,
                           SolicitudPagoCabeceraMonedaId = det.SolicitudPagoCabeceraMonedaId,
                           SolicitudPagoDetalleId = det.SolicitudPagoDetalleId,
                           SolicitudPagoDetalleMonto = det.SolicitudPagoDetalleMonto,
                           SolicitudPagoDetalleSaldo = det.SolicitudPagoDetalleSaldo,
                           SolicitudPagoCabeceraObs = det.SolicitudPagoCabeceraObs,
                           SolicitudPagoCabeceraCliente = det.SolicitudPagoCabeceraCliente,
                           SolicitudPagoDetalleTarifa = det.SolicitudPagoDetalleTarifa,
                           SolicitudPagoCabeceraAsocTramite = det.SolicitudPagoCabeceraAsocTramite
                       })
                       .Where(a => a.SolExcDetCabId == solExcCabId)
                       .ToList();

            this.dgvSolDet.DataSource = qry;
            this.lblSolicitudesNro.Text = string.Format(TITULO_GRILLA_SOLICITUDES, string.Format(FORMATO_SIN_DECIMALES, qry.Count.ToString()));
            this.FormatearGrillaSolicitudes();
        }

        #endregion CRUD

        #region Métodos locales sobre controles
        public void tbbAnular_Click(object sender, EventArgs e)
        {
            if (this.chkActivo.Checked)
            {
                string message = "";
                string caption = "";
                caption = "Anulación de Factura";
                message = "Se removerá la exclusión de la presente factura ¿Desea continuar?";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBox.Show(message, caption, buttons,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                                new EventHandler(RemoverExclusionDialogHandler));
            }
            else
            {
                MessageBox.Show("No se puede realizar la operación. La factura no se encuentra excluída.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }
        }

        private void RemoverExclusionDialogHandler(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    this.RemoverExclusion(Convert.ToInt32(this.txtIDExclusionFactura.Text));
                }
            }
        }

        private void RemoverExclusion(int solExcCabId)
        {
            bool success = false;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        List<sed_solexclusiondet> lista = new List<sed_solexclusiondet>();
                        lista = context.sed_solexclusiondet.Where(a => a.sed_solexclusioncabid == solExcCabId).ToList();

                        foreach (sed_solexclusiondet row in lista)
                        {
                            spd_solicitudpagodet spd = context.spd_solicitudpagodet.First(a => a.spd_solicitudpagodetid == row.sed_solicitudpagodetid);
                            spd.spd_excluir = false;
                        }

                        context.sec_solexclusioncab.First(a => a.sec_solexclusioncabid == solExcCabId).sec_activo = false;
                        context.SaveChanges();

                        dbContextTransaction.Commit();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        MessageBox.Show("Ocurrió un error al remover la exclusión de factura."
                                        + ex.Message + Environment.NewLine
                                        + ex.InnerException,
                                        "Error al remover exclusión",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Stop);
                    }
                }
            }
            if (success)
            {
                this.FilterEntity(this.WhereString, this.FilterParam);
                this.CargarSolExcCab(this.dgvListadoABM.Rows[this.LastDGVIndex]);
                MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion Métodos locales sobre controles
    }
}