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
using SPF.Forms.UI;
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
    public partial class ucCRUDSolPagoRegExt : ucBaseForm
    {
        #region Constantes
        //Cabecera
        private const string CAMPO_SOLPAGOCABID = "SolPagoCabID";
        private const string CAMPO_EXPEDIENTEID = "ExpedienteID";
        private const string CAMPO_ORDENTRABAJOID = "OrdenTrabajoID";
        private const string CAMPO_ORIGEN = "Origen";
        private const string CAMPO_MONEDAID = "MonedaID";
        private const string CAMPO_MONEDADESCRIP = "MonedaDescrip";
        private const string CAMPO_MONEDAABREV = "MonedaAbrev";
        private const string CAMPO_TIPOSOLPAGO = "TipoSolicitudPago";
        private const string CAMPO_GASTOGENERALID = "GastoGeneralID";
        private const string CAMPO_GASTOGENERALDESCRIP = "GastoGeneralDescrip";
        private const string CAMPO_UNIDADNEGOCIOID = "UnidadNegocioID";
        private const string CAMPO_UNIDADNEGOCIODESCRIP = "UnidadNegocioDescrip";
        private const string CAMPO_CLIENTEID = "ClienteID";
        private const string CAMPO_CLIENTENOMBRE = "NombreCliente";
        private const string CAMPO_TRAMITEID = "TramiteID";
        private const string CAMPO_TRAMITEDESCRIP = "TramiteDescrip";
        private const string CAMPO_ACTANRO = "ActaNro";
        private const string CAMPO_ACTAANIO = "ActaAnio";
        private const string CAMPO_HINRO = "HINro";
        private const string CAMPO_HIANIO = "HIAnio";
        private const string CAMPO_FECHASOLCAB = "FecSolicitudCab";
        private const string CAMPO_REFCLIENTE = "RefCliente";
        private const string CAMPO_OBSERVACION = "Observacion";
        private const string CAMPO_ACTATEXTO = "ActaTexto";
        private const string CAMPO_HITEXTO = "HITexto";
        private const string CAMPO_IMPORTE = "Importe";
        private const string CAMPO_SALDO = "Saldo";
        private const string CAMPO_FECANULACION = "FechaAnulacion";
        private const string CAMPO_ESTADO = "Estado";
        private const string CAMPO_ESTADOTEXTO = "EstadoTexto";
        private const string CAMPO_AREAID = "AreaID";
        private const string CAMPO_AREADESCRIP = "AreaDescrip";
        private const string CAMPO_PRESUPICABIDS = "PresupCabIDs";
        private const string CAMPO_TIPOASOCPRESUP = "TipoAsocPresup";
        //Detalle
        private const string CAMPO_SOLPAGODETID = "SolPagoDetID";
        private const string CAMPO_TARIFAID = "TarifaID";
        private const string CAMPO_TARIFADESCRIP = "TarifaDescrip";
        private const string CAMPO_CANTIDAD = "Cantidad";
        private const string CAMPO_TIPOUNIDDESC = "TipoUnidDescuento";
        private const string CAMPO_DESCUENTOMONTO = "DescuentoMonto";
        private const string CAMPO_DESCUENTOPORC = "DescuentoPorc";
        private const string CAMPO_TIPOUNIDIMP = "TipoUnidImp";
        private const string CAMPO_IMPUESTOMONTO = "ImpuestoMonto";
        private const string CAMPO_IMPUESTOPORC = "ImpuestoPorc";
        private const string CAMPO_PRECIOVENTA = "PrecioVenta";
        private const string CAMPO_PRECIOCOSTO = "PrecioCosto";
        private const string CAMPO_TOTAL = "Total";
        private const string CAMPO_RECARGONETO = "RecargoNeto";
        private const string CAMPO_TOTALCONRECARGO = "TotalConRecargo";
        private const string CAMPO_PROVEEDORID = "ProveedorID";
        private const string CAMPO_NOMBREPROVEEDOR = "NombreProveedor";
        private const string CAMPO_NROFACTURAPROV = "NroFacturaProv";
        private const string CAMPO_FACTURABLE = "Facturable";
        private const string CAMPO_REEMBOLSABLE = "Reembolsable";
        private const string CAMPO_SOLICITADOPORID = "SolicitadoPor";
        private const string CAMPO_SOLICITADOPORNOMBRE = "SolicitadoPorNombre";
        private const string CAMPO_CORRESPONDENCIAID = "CorrespondenciaID";
        private const string CAMPO_CORRESPONDENCIANRO = "CorrespondenciaNro";
        private const string CAMPO_CORRESPONDENCIAANIO = "CorrespondenciaAnio";
        private const string CAMPO_CORRESPONDENCIATEXTO = "CorrespondenciaTexto";
        private const string CAMPO_REFCORRESP = "RefCorresp";
        private const string CAMPO_FECHASOLDET = "FecSolicitudDet";
        private const string CAMPO_SALDODET = "SaldoDet";
        private const string CAMPO_FECFACTURA = "FecFactura";
        private const string CAMPO_CANTIDADIVA5 = "CantidadIVA5";
        private const string CAMPO_CANTIDADIVA10 = "CantidadIVA10";
        private const string CAMPO_PRECUNITIVA5 = "PrecUnitIVA5";
        private const string CAMPO_PREUNITIVA10 = "PrecUnitIVA10";
        private const string CAMPO_EXENTAS = "Exentas";
        private const string CAMPO_IVA5 = "IVA5";
        private const string CAMPO_IVA10 = "IVA10";
        private const string CAMPO_TIPOFACTURAID = "TipoFacturaID";
        private const string CAMPO_TIPOFACTURADESCRIP = "TipoFacturaDescrip";
        //-------//
        private const string ESTADO_PENDIENTE = "A";
        private const string FILTRO_HI = "H";
        private const string FILTRO_EXPEDIENTE = "E";
        private const string ESTADO_ANULADO = "N";
        private const string ORIGEN_REGEXT = "X";

        private const string ES_ADMINISTRADOR = "EsAdministrador";
        private const string PUEDE_VER_TODO = "PuedeVerTodo";
        private const string WHERE_PROVEEDOR_PUBLICO = " ((ProveedorPublico = true) OR (ProveedorID == null)) ";
        private const string AND = " AND ";
        #endregion Constantes

        #region Variables
        frmPickBase fPickMoneda;
        frmPickBase fPickCliente;
        frmPickBase fPickGastosGrales;
        frmPickBase fPickUnidadNegocio;
        frmPickBase fPickCArea;
        private int UsuarioID = -1;
        List<SolPagoAll> solpag;
        FSeleccionarPresupuesto fSeleccionPresupAsoc;
        private bool ExistenPagosAsoc = false;
        private bool PuedeVerTodo = false;
        #endregion Variables

        #region Métodos de Inicio
        public ucCRUDSolPagoRegExt()
        {
            InitializeComponent();
        }

        public ucCRUDSolPagoRegExt(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();
            this.DBContext = dbContext;
            this.Titulo = Titulo;

            this.UsuarioID = Convert.ToInt32(VWGContext.Current.Session["UsuarioID"].ToString());

            #region Obtener Lista
            //Verificamos que el usuario pueda ver todas las solicitudes
            this.PuedeVerTodo = (((bool)VWGContext.Current.Session[ES_ADMINISTRADOR])
                                || (VWGContext.Current.Session[PUEDE_VER_TODO] != null) && (VWGContext.Current.Session[PUEDE_VER_TODO].ToString().IndexOf(Titulo.Split(new string[] { " - " }, StringSplitOptions.None)[1]) > -1));

            solpag = new List<SolPagoAll>();

            var qryB = (from spc in this.DBContext.spc_solicitudpagocab
                        join spd in this.DBContext.spd_solicitudpagodet
                          on spc.spc_solicitudpagocabid equals spd.spd_solicitudpagocabid into spd_spc
                        from spd in spd_spc.DefaultIfEmpty()
                        join ot in this.DBContext.OrdenTrabajo
                          on spc.spc_ordentrabajoid equals ot.ID into ot_spc
                        from ot in ot_spc.DefaultIfEmpty()
                        join mon in this.DBContext.Moneda
                          on spc.spc_monedaid equals mon.ID
                        join cli in this.DBContext.Cliente
                          on spc.spc_clienteid equals cli.ID into cli_spc
                        from cli in cli_spc.DefaultIfEmpty()
                        join tra in this.DBContext.Tramite
                          on spc.spc_tramiteid equals tra.ID into tra_spc
                        from tra in tra_spc.DefaultIfEmpty()
                        join tar in this.DBContext.Tarifas
                          on spd.spd_tarifaid equals tar.ID into tar_spd
                        from tar in tar_spd.DefaultIfEmpty()
                        join cor in this.DBContext.Correspondencia
                          on spd.spd_correspondenciaid equals cor.ID into cor_spd
                        from cor in cor_spd.DefaultIfEmpty()
                        join usu in this.DBContext.Usuario
                          on spd.spd_solicitadopor equals usu.ID into usu_spd
                        from usu in usu_spd.DefaultIfEmpty()
                        //join tsp in this.DBContext.tsp_tiposolicitudpago
                        //  on spc.spc_tiposolicitudpagoid equals tsp.tsp_tiposolicitudpagoid
                        join gg in this.DBContext.gg_gastogeneral
                          on spc.spc_gastogeneralid equals gg.gg_gastogeneralid into gg_spc
                        from gg in gg_spc.DefaultIfEmpty()
                        join un in this.DBContext.un_unidadnegocio
                          on spc.spc_unidadnegocioid equals un.un_unidadnegocioid into un_spc
                        from un in un_spc.DefaultIfEmpty()
                        //Se hace JOIN con la tabla CLIENTE y no con la talba PROVEEDOR
                        //porque se trata de REGEXT
                        join corr in this.DBContext.Cliente
                          on spd.spd_proveedorid equals corr.ID into corr_spd
                        from corr in corr_spd.DefaultIfEmpty()
                        join ar in this.DBContext.ac_areacontabilidad
                          on spc.spc_areaid equals ar.ac_areacontabilidadid into ar_spc
                        from ar in ar_spc.DefaultIfEmpty()
                        join tf in this.DBContext.tf_tipofactura
                          on spd.spd_tipofacturaid equals tf.tf_tipofacturaid into tf_spd
                        from tf in tf_spd.DefaultIfEmpty()
                        select new SolPagoAll
                             {
                                 //Cabecera
                                 SolPagoCabID = spc.spc_solicitudpagocabid,
                                 ExpedienteID = spc.spc_expedienteid,
                                 OrdenTrabajoID = spc.spc_ordentrabajoid,
                                 Origen = spc.spc_origen,
                                 MonedaID = spc.spc_monedaid,
                                 MonedaDescrip = mon.Descripcion,
                                 MonedaAbrev = mon.AbrevMoneda,
                                 TipoSolicitudPago = spc.spc_tiposolicitudpago,
                                 //TipoSolicitudPagoDescrip = tsp.tsp_descripcion,
                                 GastoGeneralID = spc.spc_gastogeneralid,
                                 GastoGeneralDescrip = gg.gg_descripcion,
                                 UnidadNegocioID = spc.spc_unidadnegocioid,
                                 UnidadNegocioDescrip = un.un_descripcion,
                                 ClienteID = spc.spc_clienteid,
                                 NombreCliente = cli.Nombre,
                                 TramiteID = spc.spc_tramiteid,
                                 TramiteDescrip = tra.Descrip,
                                 ActaNro = spc.spc_actanro,
                                 ActaAnio = spc.spc_actaanio,
                                 HINro = spc.spc_hinro,
                                 HIAnio = spc.spc_hianio,
                                 FecSolicitudCab = spc.spc_fechasol,
                                 RefCliente = spc.spc_refcliente,
                                 Observacion = spc.spc_observacion,
                                 Importe = spc.spc_importe,
                                 Saldo = spc.spc_saldo,
                                 Estado = spc.spc_estado,
                                 FechaAnulacion = spc.spc_fechaanulacion,
                                 AreaID = spc.spc_areaid,
                                 AreaDescrip = ar.ac_descripcionarea,
                                 PresupCabIDs = spc.spc_presupcabids,
                                 TipoAsocPresup = spc.spc_tipoasociacionpresup,
                                 //Detalle
                                 SolPagoDetID = spd.spd_solicitudpagodetid,
                                 TarifaID = spd.spd_tarifaid,
                                 TarifaDescrip = tar.Descripcion,
                                 Cantidad = spd.spd_cantidad,
                                 TipoUnidDescuento = spd.spd_tipounidaddesc,
                                 DescuentoMonto = spd.spd_descuentomonto,
                                 DescuentoPorc = spd.spd_descuentoporcentaje,
                                 TipoUnidImp = spd.spd_tipounidadimp,
                                 ImpuestoMonto = spd.spd_impuestomonto,
                                 ImpuestoPorc = spd.spd_impuestoporcentaje,
                                 PrecioVenta = spd.spd_precioventa,
                                 PrecioCosto = spd.spd_preciocosto,
                                 Total = spd.spd_total,
                                 SaldoDet = spd.spd_saldo,
                                 RecargoNeto = spd.spd_recargoneto,
                                 TotalConRecargo = spd.spd_totalconrecargo,
                                 ProveedorID = spd.spd_proveedorid,
                                 //ProveedorPublico = pr.pr_publico,
                                 NombreProveedor = corr.Nombre,
                                 NroFacturaProv = spd.spd_nrofactura,
                                 FecFactura = spd.spd_fechafactura,
                                 Facturable = spd.spd_facturable,
                                 Reembolsable = spd.spd_reembolsable,
                                 SolicitadoPor = spd.spd_solicitadopor,
                                 SolicitadoPorNombre = usu.NombrePila,
                                 CorrespondenciaID = spd.spd_correspondenciaid,
                                 CorrespondenciaNro = cor.Nro,
                                 CorrespondenciaAnio = cor.Anio,
                                 RefCorresp = cor.RefCorresp,
                                 FecSolicitudDet = spd.spd_fechasol,
                                 Exentas = spd.spd_exentas,
                                 CantidadIVA5 = spd.spd_cantidadiva5,
                                 PrecUnitIVA5 = spd.spd_precunitiva5,
                                 IVA5 = spd.spd_iva5,
                                 CantidadIVA10 = spd.spd_cantidadiva10,
                                 PrecUnitIVA10 = spd.spd_precunitiva10,
                                 IVA10 = spd.spd_iva10,
                                 TipoFacturaID = spd.spd_tipofacturaid,
                                 TipoFacturaDescrip = tf.tf_descripcion
                             })
                           .Where(a => a.Origen == ORIGEN_REGEXT)
                           .OrderByDescending(a => a.SolPagoCabID)
                           .Take(50)
                           .ToList();

            //if (this.PuedeVerTodo)
            //{
            //    solpag = qryB.OrderByDescending(a => a.SolPagoCabID).Take(50).ToList();
            //}
            //else
            //{
            //    solpag = qryB.Where(WHERE_PROVEEDOR_PUBLICO).OrderByDescending(a => a.SolPagoCabID).Take(50).ToList();
            //}
            solpag = qryB;
            this.BindingSourceBase_ExportExcelGrid = solpag;

            var query = (from item in solpag
                         select new SolPagoCab
                         {
                             //Cabecera
                             SolPagoCabID = item.SolPagoCabID,
                             ExpedienteID = item.ExpedienteID,
                             OrdenTrabajoID = item.OrdenTrabajoID,
                             Origen = item.Origen,
                             MonedaID = item.MonedaID,
                             MonedaDescrip = item.MonedaDescrip,
                             MonedaAbrev = item.MonedaAbrev,
                             TipoSolicitudPago = item.TipoSolicitudPago,
                             //TipoSolicitudPagoDescrip = item.TipoSolicitudPagoDescrip,
                             GastoGeneralID = item.GastoGeneralID,
                             GastoGeneralDescrip = item.GastoGeneralDescrip,
                             UnidadNegocioID = item.UnidadNegocioID,
                             UnidadNegocioDescrip = item.UnidadNegocioDescrip,
                             ClienteID = item.ClienteID,
                             NombreCliente = item.NombreCliente,
                             TramiteID = item.TramiteID,
                             TramiteDescrip = item.TramiteDescrip,
                             ActaNro = item.ActaNro,
                             ActaAnio = item.ActaAnio,
                             HINro = item.HINro,
                             HIAnio = item.HIAnio,
                             FecSolicitudCab = item.FecSolicitudCab,
                             RefCliente = item.RefCliente,
                             Observacion = item.Observacion,
                             Importe = item.Importe,
                             Saldo = item.Saldo,
                             Estado = item.Estado,
                             FechaAnulacion = item.FechaAnulacion,
                             AreaID = item.AreaID,
                             AreaDescrip = item.AreaDescrip,
                             PresupCabIDs = item.PresupCabIDs,
                             TipoAsocPresup = item.TipoAsocPresup
                         })
                         .GroupBy(x => new { x.SolPagoCabID }).Select(g => g.First()).ToList();

            this.BindingSourceBase = query;
            #endregion Obtener Lista

            #region Especificar campos para filtro
            this.SetFilter(CAMPO_SOLPAGOCABID, "Sol. Pago ID.", false);
            this.SetFilter(CAMPO_EXPEDIENTEID, "Expe. ID", false);
            this.SetFilter(CAMPO_ORDENTRABAJOID, "Ord. Trab. ID", false);
            this.SetFilter(CAMPO_ORIGEN, "Origen (M/O)");
            this.SetFilter(CAMPO_ESTADO, "Estado");
            this.SetFilter(CAMPO_MONEDAID, "Moneda ID", false);
            this.SetFilter(CAMPO_MONEDADESCRIP, "Descrip. Moneda");
            this.SetFilter(CAMPO_MONEDAABREV, "Abrev. Moneda");
            this.SetFilter(CAMPO_TIPOSOLPAGO, "Asoc. Trám. (S/N)", false);
            this.SetFilter(CAMPO_GASTOGENERALID, "Gasto Gral. ID", false);
            this.SetFilter(CAMPO_GASTOGENERALDESCRIP, "Descrip. G. Gral.");
            this.SetFilter(CAMPO_UNIDADNEGOCIOID, "U. Neg. ID", false);
            this.SetFilter(CAMPO_UNIDADNEGOCIODESCRIP, "Descrip. U. Neg.");
            this.SetFilter(CAMPO_CLIENTEID, "Cliente ID", false);
            this.SetFilter(CAMPO_CLIENTENOMBRE, "Nombre Cliente");
            this.SetFilter(CAMPO_TRAMITEID, "Trámite ID", false);
            this.SetFilter(CAMPO_TRAMITEDESCRIP, "Descrip. Trámite");
            this.SetFilter(CAMPO_AREAID, "Área ID", false);
            this.SetFilter(CAMPO_AREADESCRIP, "Descrip. Área");
            this.SetFilter(CAMPO_ACTANRO, "Acta N°", false);
            this.SetFilter(CAMPO_ACTAANIO, "Acta Año", false);
            this.SetFilter(CAMPO_HINRO, "HI N°", false);
            this.SetFilter(CAMPO_HIANIO, "HI Año", false);
            this.SetFilter(CAMPO_FECHASOLCAB, "Fec. Sol.");
            this.SetFilter(CAMPO_REFCLIENTE, "Ref. Cliente");
            this.SetFilter(CAMPO_OBSERVACION, "Observación");
            this.SetFilter(CAMPO_ACTATEXTO, "Acta/Año");
            this.SetFilter(CAMPO_HITEXTO, "HI/Año");
            this.SetFilter(CAMPO_IMPORTE, "Importe", false);
            //Detalle
            this.SetFilter(CAMPO_PROVEEDORID, "Corresp. ID", false);
            this.SetFilter(CAMPO_NOMBREPROVEEDOR, "Nombre Corresp.");
            this.SetFilter(CAMPO_TARIFAID, "Tarifa ID", false);
            this.SetFilter(CAMPO_TARIFADESCRIP, "Tarifa Desc.");
            this.SetFilter(CAMPO_SOLICITADOPORID, "Solic. Por ID", false);
            this.SetFilter(CAMPO_SOLICITADOPORNOMBRE, "Solic. Nomb.");
            this.SetFilter(CAMPO_TIPOFACTURAID, "Tipo Fac. ID", false);
            this.SetFilter(CAMPO_TIPOFACTURADESCRIP, "Tipo Fac. Desc.");
            this.SetFilter(CAMPO_NROFACTURAPROV, "N° Fact. Corresp.");
            this.SetFilter(CAMPO_FECFACTURA, "Fec. Fact. Corresp.");
            this.TituloBuscador = "Buscar Solicitudes de Pago a Corresponsales";
            #endregion Especificar campos para filtro

            #region Inicializar TextSearchBoxes
            this.tSBCliente.KeyMemberWidth = 70;
            this.tSBCliente.ToolTip = "Elegir Cliente";
            this.tSBCliente.AceptarClick += tSBCliente_AceptarClick;

            this.tSBMoneda.KeyMemberWidth = 70;
            this.tSBMoneda.ToolTip = "Elegir Moneda";
            this.tSBMoneda.AceptarClick += tSBMoneda_AceptarClick;

            this.tSBGastosGenerales.KeyMemberWidth = 35;
            this.tSBGastosGenerales.ToolTip = "Elegir Concepto";
            this.tSBGastosGenerales.AceptarClick += tSBGastosGenerales_AceptarClick;

            this.tSBUnidadNegocio.KeyMemberWidth = 35;
            this.tSBUnidadNegocio.ToolTip = "Elegir Unidad de Negocio";
            this.tSBUnidadNegocio.AceptarClick += tSBUnidadNegocio_AceptarClick;

            this.tSBAreaContab.KeyMemberWidth = 35;
            this.tSBAreaContab.ToolTip = "Elegir Área";
            this.tSBAreaContab.AceptarClick += tSBAreaContab_AceptarClick;
            #endregion Inicializar TextSearchBoxes

            #region Carbar Combos
            this.cargarOrigen();
            this.cargarCampoFiltro();
            #endregion Carbar Combos
        }

        private void ucCRUDSolPago_Load(object sender, EventArgs e)
        {
            this.tabListaABM.TabPages[0].HeaderToolTip = "Listado de Solicitudes de Pago";
            this.tabListaABM.TabPages[1].Text = "Datos Generales";
            this.tabListaABM.TabPages[1].HeaderToolTip = "Datos Generales de la Solicitud de Pago";
            this.tabListaABM.TabPages[2].HeaderToolTip = "Detalles de la Solicitud de Pago";
            this.tTBaseForm.SetToolTip(this.txtFiltroExpedienteID, this.GetToolTipTextFilter());
            this.tbbImprimir.Visible = true;

            //Verificamos que el usuario pueda ver todas las solicitudes
            //this.PuedeVerTodo = (((bool)VWGContext.Current.Session[ES_ADMINISTRADOR]) || ((bool)VWGContext.Current.Session[PUEDE_VER_TODO]));
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

        #region Gastos Generales

        private void tSBGastosGenerales_AceptarClick(object sender, EventArgs e)
        {
            if (fPickGastosGrales == null)
            {
                fPickGastosGrales = new frmPickBase();
                fPickGastosGrales.AceptarFiltrarClick += fPickGastosGrales_AceptarFiltrarClick;
                fPickGastosGrales.FiltrarClick += fPickGastosGrales_FiltrarClick;
                fPickGastosGrales.Titulo = "Elegir Concepto de Gasto";
                fPickGastosGrales.CampoIDNombre = "gg_gastogeneralid";
                fPickGastosGrales.CampoDescripNombre = "gg_descripcion";
                fPickGastosGrales.LabelCampoID = "ID";
                fPickGastosGrales.LabelCampoDescrip = "Descripción";
                fPickGastosGrales.NombreCampo = "Gasto Gral.";
                fPickGastosGrales.PermitirFiltroNulo = true;
            }
            fPickGastosGrales.MostrarFiltro();
            //this.fPickGastosGrales_FiltrarClick(sender, e);
        }

        private void fPickGastosGrales_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickGastosGrales != null)
            {
                fPickGastosGrales.LoadData<gg_gastogeneral>(this.DBContext.gg_gastogeneral, fPickGastosGrales.GetWhereString());
            }
        }

        private void fPickGastosGrales_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBGastosGenerales.DisplayMember = fPickGastosGrales.ValorDescrip;
            this.tSBGastosGenerales.KeyMember = fPickGastosGrales.ValorID;

            fPickGastosGrales.Close();
            fPickGastosGrales.Dispose();
        }

        #endregion Gastos Generales

        #region Área Contabilidad
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
        #endregion Área Contabilidad

        #region Unidad Negocio
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
                fPickUnidadNegocio.NombreCampo = "Un. Negocio";
                fPickUnidadNegocio.PermitirFiltroNulo = true;
            }
            fPickUnidadNegocio.MostrarFiltro();
            this.fPickUnidadNegocio_FiltrarClick(sender, e);
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
        #endregion Unidad Negocio

        #endregion Picks

        #region Método Extendidos del ParentControl
        protected override void FilterEntity(string where = "", object[] filterParams = null)
        {
            try
            {
                this.limpiarDatos();

                //if (!this.PuedeVerTodo)
                //{
                //    where += where != "" ? AND : String.Empty;
                //    where += WHERE_PROVEEDOR_PUBLICO;
                //}

                var query = (from spc in this.DBContext.spc_solicitudpagocab
                             join spd in this.DBContext.spd_solicitudpagodet
                               on spc.spc_solicitudpagocabid equals spd.spd_solicitudpagocabid into spd_spc
                             from spd in spd_spc.DefaultIfEmpty()
                             join ot in this.DBContext.OrdenTrabajo
                               on spc.spc_ordentrabajoid equals ot.ID into ot_spc
                             from ot in ot_spc.DefaultIfEmpty()
                             join mon in this.DBContext.Moneda
                               on spc.spc_monedaid equals mon.ID
                             join cli in this.DBContext.Cliente
                               on spc.spc_clienteid equals cli.ID into cli_spc
                             from cli in cli_spc.DefaultIfEmpty()
                             join tra in this.DBContext.Tramite
                               on spc.spc_tramiteid equals tra.ID into tra_spc
                             from tra in tra_spc.DefaultIfEmpty()
                             join tar in this.DBContext.Tarifas
                               on spd.spd_tarifaid equals tar.ID into tar_spd
                             from tar in tar_spd.DefaultIfEmpty()
                             join cor in this.DBContext.Correspondencia
                               on spd.spd_correspondenciaid equals cor.ID into cor_spd
                             from cor in cor_spd.DefaultIfEmpty()
                             join usu in this.DBContext.Usuario
                               on spd.spd_solicitadopor equals usu.ID into usu_spd
                             from usu in usu_spd.DefaultIfEmpty()
                             //join tsp in this.DBContext.tsp_tiposolicitudpago
                             //  on spc.spc_tiposolicitudpagoid equals tsp.tsp_tiposolicitudpagoid
                             join gg in this.DBContext.gg_gastogeneral
                               on spc.spc_gastogeneralid equals gg.gg_gastogeneralid into gg_spc
                             from gg in gg_spc.DefaultIfEmpty()
                             join un in this.DBContext.un_unidadnegocio
                               on spc.spc_unidadnegocioid equals un.un_unidadnegocioid into un_spc
                               from un in un_spc.DefaultIfEmpty()
                             join corr in this.DBContext.Cliente
                               on spd.spd_proveedorid equals corr.ID into corr_spd
                             from corr in corr_spd.DefaultIfEmpty()
                             join ar in this.DBContext.ac_areacontabilidad
                                on spc.spc_areaid equals ar.ac_areacontabilidadid into ar_spc
                             from ar in ar_spc.DefaultIfEmpty()
                             join tf in this.DBContext.tf_tipofactura
                                on spd.spd_tipofacturaid equals tf.tf_tipofacturaid into tf_spd
                             from tf in tf_spd.DefaultIfEmpty()
                             select new SolPagoAll
                             {
                                 //Cabecera
                                 SolPagoCabID = spc.spc_solicitudpagocabid,
                                 ExpedienteID = spc.spc_expedienteid,
                                 OrdenTrabajoID = spc.spc_ordentrabajoid,
                                 Origen = spc.spc_origen,
                                 MonedaID = spc.spc_monedaid,
                                 MonedaDescrip = mon.Descripcion,
                                 MonedaAbrev = mon.AbrevMoneda,
                                 TipoSolicitudPago = spc.spc_tiposolicitudpago,
                                 //TipoSolicitudPagoDescrip = tsp.tsp_descripcion,
                                 GastoGeneralID = spc.spc_gastogeneralid,
                                 GastoGeneralDescrip = gg.gg_descripcion,
                                 UnidadNegocioID = spc.spc_unidadnegocioid,
                                 UnidadNegocioDescrip = un.un_descripcion,
                                 ClienteID = spc.spc_clienteid,
                                 NombreCliente = cli.Nombre,
                                 TramiteID = spc.spc_tramiteid,
                                 TramiteDescrip = tra.Descrip,
                                 ActaNro = spc.spc_actanro,
                                 ActaAnio = spc.spc_actaanio,
                                 HINro = spc.spc_hinro,
                                 HIAnio = spc.spc_hianio,
                                 FecSolicitudCab = spc.spc_fechasol,
                                 RefCliente = spc.spc_refcliente,
                                 Observacion = spc.spc_observacion,
                                 Importe = spc.spc_importe,
                                 Saldo = spc.spc_saldo,
                                 Estado = spc.spc_estado,
                                 FechaAnulacion = spc.spc_fechaanulacion,
                                 AreaID = spc.spc_areaid,
                                 AreaDescrip = ar.ac_descripcionarea,
                                 PresupCabIDs = spc.spc_presupcabids,
                                 TipoAsocPresup = spc.spc_tipoasociacionpresup,
                                 //Detalle
                                 SolPagoDetID = spd.spd_solicitudpagodetid,
                                 TarifaID = spd.spd_tarifaid,
                                 TarifaDescrip = tar.Descripcion,
                                 Cantidad = spd.spd_cantidad,
                                 TipoUnidDescuento = spd.spd_tipounidaddesc,
                                 DescuentoMonto = spd.spd_descuentomonto,
                                 DescuentoPorc = spd.spd_descuentoporcentaje,
                                 TipoUnidImp = spd.spd_tipounidadimp,
                                 ImpuestoMonto = spd.spd_impuestomonto,
                                 ImpuestoPorc = spd.spd_impuestoporcentaje,
                                 PrecioVenta = spd.spd_precioventa,
                                 PrecioCosto = spd.spd_preciocosto,
                                 Total = spd.spd_total,
                                 SaldoDet = spd.spd_saldo,
                                 RecargoNeto = spd.spd_recargoneto,
                                 TotalConRecargo = spd.spd_totalconrecargo,
                                 ProveedorID = spd.spd_proveedorid,
                                 //ProveedorPublico = pr.pr_publico,
                                 NombreProveedor = corr.Nombre,
                                 NroFacturaProv = spd.spd_nrofactura,
                                 FecFactura = spd.spd_fechafactura,
                                 Facturable = spd.spd_facturable,
                                 Reembolsable = spd.spd_reembolsable,
                                 SolicitadoPor = spd.spd_solicitadopor,
                                 SolicitadoPorNombre = usu.NombrePila,
                                 CorrespondenciaID = spd.spd_correspondenciaid,
                                 CorrespondenciaNro = cor.Nro,
                                 CorrespondenciaAnio = cor.Anio,
                                 RefCorresp = cor.RefCorresp,
                                 FecSolicitudDet = spd.spd_fechasol,
                                 Exentas = spd.spd_exentas,
                                 CantidadIVA5 = spd.spd_cantidadiva5,
                                 PrecUnitIVA5 = spd.spd_precunitiva5,
                                 IVA5 = spd.spd_iva5,
                                 CantidadIVA10 = spd.spd_cantidadiva10,
                                 PrecUnitIVA10 = spd.spd_precunitiva10,
                                 IVA10 = spd.spd_iva10,
                                 TipoFacturaID = spd.spd_tipofacturaid,
                                 TipoFacturaDescrip = tf.tf_descripcion
                             })
                             .Where(a => a.Origen == ORIGEN_REGEXT); 

                //List<NotaCreditoPresupAll> ncs = new List<NotaCreditoPresupAll>();
                solpag.Clear();
                if (where != "")
                {
                    //this.BindingSourceBase = query.Where(where, filterParams).OrderByDescending(a => a.NotaCreditoID).ToList();
                    solpag = query.Where(where, filterParams).OrderByDescending(a => a.SolPagoCabID).ToList();
                }
                else
                {
                    //this.BindingSourceBase = query.OrderByDescending(a => a.NotaCreditoID).Take(50).ToList();
                    solpag = query.OrderByDescending(a => a.SolPagoCabID).Take(50).ToList();
                }

                this.BindingSourceBase_ExportExcelGrid = solpag;

                var query1 = (from item in solpag
                              select new SolPagoCab
                              {
                                  //Cabecera
                                  SolPagoCabID = item.SolPagoCabID,
                                  ExpedienteID = item.ExpedienteID,
                                  OrdenTrabajoID = item.OrdenTrabajoID,
                                  Origen = item.Origen,
                                  MonedaID = item.MonedaID,
                                  MonedaDescrip = item.MonedaDescrip,
                                  MonedaAbrev = item.MonedaAbrev,
                                  TipoSolicitudPago = item.TipoSolicitudPago,
                                  //TipoSolicitudPagoDescrip = item.TipoSolicitudPagoDescrip,
                                  GastoGeneralID = item.GastoGeneralID,
                                  GastoGeneralDescrip = item.GastoGeneralDescrip,
                                  UnidadNegocioID = item.UnidadNegocioID,
                                  UnidadNegocioDescrip = item.UnidadNegocioDescrip,
                                  ClienteID = item.ClienteID,
                                  NombreCliente = item.NombreCliente,
                                  TramiteID = item.TramiteID,
                                  TramiteDescrip = item.TramiteDescrip,
                                  ActaNro = item.ActaNro,
                                  ActaAnio = item.ActaAnio,
                                  HINro = item.HINro,
                                  HIAnio = item.HIAnio,
                                  FecSolicitudCab = item.FecSolicitudCab,
                                  RefCliente = item.RefCliente,
                                  Observacion = item.Observacion,
                                  Importe = item.Importe,
                                  Saldo = item.Saldo,
                                  Estado = item.Estado,
                                  FechaAnulacion = item.FechaAnulacion,
                                  AreaID = item.AreaID,
                                  AreaDescrip = item.AreaDescrip,
                                  PresupCabIDs = item.PresupCabIDs,
                                  TipoAsocPresup = item.TipoAsocPresup
                              })
                             .GroupBy(x => new { x.SolPagoCabID }).Select(g => g.First()).ToList();

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

            this.dgvListadoABM.Columns[CAMPO_SOLPAGOCABID].HeaderText = "Sol. Pago ID";
            this.dgvListadoABM.Columns[CAMPO_SOLPAGOCABID].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_SOLPAGOCABID].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_SOLPAGOCABID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_SOLPAGOCABID].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_FECHASOLCAB].HeaderText = "Fec. Solic.";
            this.dgvListadoABM.Columns[CAMPO_FECHASOLCAB].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_FECHASOLCAB].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_FECHASOLCAB].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_FECHASOLCAB].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_EXPEDIENTEID].HeaderText = "Exp. ID";
            this.dgvListadoABM.Columns[CAMPO_EXPEDIENTEID].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_EXPEDIENTEID].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_EXPEDIENTEID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_EXPEDIENTEID].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_MONEDAABREV].HeaderText = "Moneda";
            this.dgvListadoABM.Columns[CAMPO_MONEDAABREV].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_MONEDAABREV].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_MONEDAABREV].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_CLIENTENOMBRE].HeaderText = "Cliente";
            this.dgvListadoABM.Columns[CAMPO_CLIENTENOMBRE].Width = 250;
            this.dgvListadoABM.Columns[CAMPO_CLIENTENOMBRE].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_CLIENTENOMBRE].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_TRAMITEDESCRIP].HeaderText = "Trámite";
            this.dgvListadoABM.Columns[CAMPO_TRAMITEDESCRIP].Width = 250;
            this.dgvListadoABM.Columns[CAMPO_TRAMITEDESCRIP].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_TRAMITEDESCRIP].Visible = true;
            displayIndex++;
            
            this.dgvListadoABM.Columns[CAMPO_ACTATEXTO].HeaderText = "Acta N°";
            this.dgvListadoABM.Columns[CAMPO_ACTATEXTO].Width = 100;
            this.dgvListadoABM.Columns[CAMPO_ACTATEXTO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_ACTATEXTO].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_HITEXTO].HeaderText = "HI N°";
            this.dgvListadoABM.Columns[CAMPO_HITEXTO].Width = 100;
            this.dgvListadoABM.Columns[CAMPO_HITEXTO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_HITEXTO].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_ESTADOTEXTO].HeaderText = "Estado";
            this.dgvListadoABM.Columns[CAMPO_ESTADOTEXTO].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_ESTADOTEXTO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_ESTADOTEXTO].Visible = true;
            displayIndex++;

            //DataGridViewCheckBoxColumn colAnulado = new DataGridViewCheckBoxColumn();
            //colAnulado.DataPropertyName = CAMPO_NOTACREDITOANULADO;
            //colAnulado.HeaderText = "Anulado";
            //colAnulado.FalseValue = false;
            //colAnulado.TrueValue = true;
            //colAnulado.ReadOnly = true;
            //this.dgvListadoABM.Columns.Insert(displayIndex, colAnulado);
        }

        protected override void tbbNuevo_Click(object sender, EventArgs e)
        {
            base.tbbNuevo_Click(sender, e);
            this.limpiarDatos();
            this.dtpFechaSolCab.Value = DateTime.Now;
            this.txtFechaSolCab.Text = DateTime.Now.ToShortDateString();
            this.txtImporte.ReadOnly = false;
            this.txtImporte.Text = "0,00";
            this.txtSaldoCab.Text = "0,00";
            this.txtFechaSolCab.Focus();
        }

        private void tbbEditar_Click_1(object sender, EventArgs e)
        {
            if (this.ExistenPagosAsociados())
            {
                MessageBox.Show("La solicitud ya cuenta con pagos asociados. Sólo se puede editar el apartado de asociación a Presupuestos," + Environment.NewLine +
                                " o la Referencia del Cliente o el detalle de facturas no saldadas aún.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                this.FormEditStatus = EDIT;
                this.cbTipoAsocPresup.Focus();
            }
            else
            {
                //base.tbbEditar_Click(sender, e);
                this.FormEditStatus = EDIT;

                if (this.tabListaABM.SelectedIndex == 0)
                    this.tabListaABM.SelectedIndex = 1;

                this.txtFechaSolCab.Focus();
            }
        }

        protected override void tbbCancelar_Click(object sender, EventArgs e)
        {
            base.tbbCancelar_Click(sender, e);

            if (this.LastDGVIndex > -1)
            {
                this.CargarSolPago(this.dgvListadoABM.Rows[this.LastDGVIndex]);
            }
            else
            {
                this.limpiarDatos();
            }
            this.tabListaABM.SelectedIndex = 0;
        }

        private void tabListaABM_SelectedIndexChanging_1(object sender, TabControlCancelEventArgs e)
        {
            bool existenPagoAsoc = this.ExistenPagosAsociados();
            if (((this.FormEditStatus != BROWSE) && (e.TabPage.Name == this.tabListaABM.TabPages[0].Name))
                /*|| ((this.FormEditStatus != BROWSE) && (e.TabPage.Name == this.tabListaABM.TabPages[2].Name) */ && (existenPagoAsoc))
                e.Cancel = true;
            else e.Cancel = false;
            
        }

        #endregion Método Extendidos del ParentControl

        #region Combo Origen
        private void cargarOrigen()
        {
            List<OrigenList> listaOrigen = new List<OrigenList>();
            //listaOrigen.Add(new OrigenList() { OrigenID = "", OrigenDescrip = "" });
            //listaOrigen.Add(new OrigenList() { OrigenID = "M", OrigenDescrip = "Marcas" });
            //listaOrigen.Add(new OrigenList() { OrigenID = "O", OrigenDescrip = "Otros" });
            listaOrigen.Add(new OrigenList() { OrigenID = ORIGEN_REGEXT, OrigenDescrip = "Marcas y Patentes en el Exterior" });

            this.cbOrigen.DataSource = listaOrigen;
            this.cbOrigen.DisplayMember = "OrigenDescrip";
            this.cbOrigen.ValueMember = "OrigenID";
        }
        #endregion Combo Origen

        #region Combo Campo Filtro
        private void cargarCampoFiltro()
        {
            List<CampoFiltroList> listaCampoFiltro = new List<CampoFiltroList>();
            listaCampoFiltro.Add(new CampoFiltroList() { CampoFiltroID = "ExpedienteID", CampoFiltroDescrip = "Expediente" });
            listaCampoFiltro.Add(new CampoFiltroList() { CampoFiltroID = "ActaTexto", CampoFiltroDescrip = "Acta" });
            listaCampoFiltro.Add(new CampoFiltroList() { CampoFiltroID = "HIText", CampoFiltroDescrip = "H. de Inicio" });

            this.cbCampoFiltro.DataSource = listaCampoFiltro;
            this.cbCampoFiltro.DisplayMember = "CampoFiltroDescrip";
            this.cbCampoFiltro.ValueMember = "CampoFiltroID";
        }
        #endregion Combo Campo Fitro

        #region Limpiar Datos
        private void limpiarDatos()
        {
            this.txtSolPagoCabID.Text = "";
            this.txtFechaSolCab.Text = "";
            this.cbOrigen.SelectedIndex = 0;
            this.tSBCliente.Clear();
            this.tSBMoneda.Clear();
            this.rbAsocTramite.Checked = true;
            this.txtRefCliente.Text = "";
            this.txtObservacion.Text = "";
            this.cbCampoFiltro.SelectedIndex = 0;
            this.txtFiltroExpedienteID.Text = "";
            this.txtExpedienteID.Text = "";
            this.txtOTID.Text = "";
            this.txtTramiteID.Text = "";
            this.txtTramiteDescrip.Text = "";
            this.txtActaNro.Text = "";
            this.txtActaAnio.Text = "";
            this.txtHINro.Text = "";
            this.txtHIAnio.Text = "";
            this.tSBGastosGenerales.Clear();
            this.tSBUnidadNegocio.Clear();
            this.txtImporte.Text = "";
            this.txtSaldoCab.Text = "";
            this.tSBAreaContab.Clear();
            this.txtPresupID.Text = "";
            this.txtPresupAsoc.Text = "";
            this.cbTipoAsocPresup.SelectedIndex = 0;
            this.txtEstado.Text = "";
        }
        #endregion Limpiar Datos

        #region ReadOnly condicional
        protected override void Editable(bool editar)
        {
            bool existenPagosAsoc = false;
            if (this.FormEditStatus == EDIT)
            {
                existenPagosAsoc = this.ExistenPagosAsociados();
                editar = !editar && existenPagosAsoc;
            }

            this.txtFechaSolCab.ReadOnly = editar;
            this.dtpFechaSolCab.Enabled = !editar;
            this.cbOrigen.Enabled = !editar;
            this.grpTipoSolicitud.Enabled = !editar;
            this.tSBCliente.Editable = !editar;
            this.tSBMoneda.Editable = !editar;
            //this.txtRefCliente.ReadOnly = editar;
            this.txtObservacion.ReadOnly = editar;
            this.grpBuscarExpediente.Enabled = !editar;

            if ((existenPagosAsoc) && (this.FormEditStatus == EDIT))
            {
                this.grpAsociacionPresup.Enabled = true;
                this.txtRefCliente.ReadOnly = false;
            }
            else
            {
                this.grpAsociacionPresup.Enabled = !editar;
                this.txtRefCliente.ReadOnly = editar;
            }

            if (this.FormEditStatus == BROWSE)
            {
                this.grpAsociadoaTramite.Enabled = !editar;
                this.grpGastoGeneral.Enabled = !editar;
                this.txtImporte.ReadOnly = true;
                this.txtImporte.BackColor = SystemColors.Control;
                this.btnAgregarDetalle.Enabled = false;
                this.btnEliminarDetalle.Enabled = false;
                this.btnBuscar.Enabled = false;
            }
            else
            {
                this.HabilitarGrupos(existenPagosAsoc);
                this.btnAgregarDetalle.Enabled = !existenPagosAsoc; // true;
                this.btnEliminarDetalle.Enabled = !existenPagosAsoc; // true;
                this.btnBuscar.Enabled = true;

                if (this.dgvDetalleSolPago.RowCount > 0)
                {
                    this.txtImporte.ReadOnly = true;
                    this.txtImporte.BackColor = SystemColors.Control;
                    this.tTBaseForm.SetToolTip(this.txtImporte, "No se puede editar porque la solicitud tiene detalles asociados");
                }
                else
                {
                    this.txtImporte.ReadOnly = false;
                    this.txtImporte.BackColor = SystemColors.Window;
                    this.tTBaseForm.SetToolTip(this.txtImporte, "");
                }
            }
            
        }
        #endregion ReadOnly condicional

        #region Métodos Heredadeos del Parent Control
        protected override void tbbImprimir_Click(object sender, EventArgs e)
        {
            List<int> listaProveedorID = this.GetListaProveedorID();

            if (listaProveedorID.Count > 0)
            {
                Forms.UI.FSeleccionarProveedor f = new Forms.UI.FSeleccionarProveedor(Convert.ToInt32(this.txtSolPagoCabID.Text), listaProveedorID, this.DBContext);
                f.FormClosed += delegate { f = null; };
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen proveedores ingresados para la solicitud de pago.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }
        }
        #endregion Métodos Heredadeos del Parent Control

        #region Métodos de Apoyo
        private bool ExistenPagosAsociados()
        {
            int SolicitudPagoCabID = Convert.ToInt32(this.txtSolPagoCabID.Text);
            var query = (from sxp in this.DBContext.sxp_solicitudesxpago
                        join pProv in this.DBContext.ps_pagosolicitud 
                            on sxp.sxp_pagosolicitudid equals pProv.ps_pagosolicitudid
                        select new 
                        {
                            PagoProveedorID = pProv.ps_pagosolicitudid,
                            SolicitudPagoCabID = sxp.sxp_solicitudpagocabid,
                            Anulado = pProv.ps_anulado
                        }).Where(a => a.SolicitudPagoCabID == SolicitudPagoCabID && !a.Anulado)
                        .ToList();

            return query.Count > 0 ? true : false;
        }

        private void SetPresupuestosAsociados(BerkeDBEntities context, string PresupuestoCabIDs)
        {
            string[] arryPIs = PresupuestoCabIDs.Split(',');
            string listaPresupIDs = "";
            string listaNroDocs = "";

            if (this.cbTipoAsocPresup.SelectedIndex == 0)
            {
                string tipoFiltro = "";
                int valorFiltro = -1;

                if (this.txtExpedienteID.Text != "")
                {
                    tipoFiltro = FILTRO_EXPEDIENTE;
                    valorFiltro = Convert.ToInt32(this.txtExpedienteID.Text);
                }
                else if (this.txtOTID.Text != "")
                {
                    tipoFiltro = FILTRO_HI;
                    valorFiltro = Convert.ToInt32(this.txtOTID.Text);
                }

                if (valorFiltro > -1)
                {
                    List<PresupuestoXSolicitudType> listaDocumentos = (from lPxS in context.GetPresupuestoXSolicitudPago(tipoFiltro, valorFiltro)
                                                                       select new PresupuestoXSolicitudType
                                                                       {
                                                                           PresupuestoCabID = lPxS.PresupuestoCabID,
                                                                           NroDocumento = lPxS.NroDocumento
                                                                       }).ToList();

                    if (listaDocumentos.Count() > 0)
                    {
                        foreach (PresupuestoXSolicitudType item in listaDocumentos)
                        {
                            listaPresupIDs += listaPresupIDs != "" ? "," : "";
                            listaPresupIDs += item.PresupuestoCabID.Value.ToString();

                            listaNroDocs += listaNroDocs != "" ? "," : "";
                            listaNroDocs += item.NroDocumento;
                        }
                    }
                }
            }
            else if (this.cbTipoAsocPresup.SelectedIndex == 1)
            {
                if (PresupuestoCabIDs != "")
                {
                    foreach (string val in arryPIs)
                    {
                        listaNroDocs += listaNroDocs != "" ? "," : "";
                        listaNroDocs += context.GetDocumentoNro(Convert.ToInt32(val)).FirstOrDefault();
                    }
                    listaPresupIDs = PresupuestoCabIDs;
                }
            }
            this.txtPresupID.Text = listaPresupIDs;
            this.txtPresupAsoc.Text = listaNroDocs;
        }
        
        private void CargarSolPago(DataGridViewRow row)
        {
            this.limpiarDatos();

            this.txtSolPagoCabID.Text = row.Cells[CAMPO_SOLPAGOCABID].Value.ToString();
            this.cbOrigen.SelectedValue = row.Cells[CAMPO_ORIGEN].Value.ToString();
            this.txtFechaSolCab.Text = ((DateTime)row.Cells[CAMPO_FECHASOLCAB].Value).ToShortDateString();
            this.dtpFechaSolCab.Value = ((DateTime)row.Cells[CAMPO_FECHASOLCAB].Value); 
            this.rbAsocTramite.Checked = (bool)row.Cells[CAMPO_TIPOSOLPAGO].Value == true ? true : false;
            this.rbGastosGrales.Checked = (bool)row.Cells[CAMPO_TIPOSOLPAGO].Value == false ? true : false;
            this.txtRefCliente.Text = row.Cells[CAMPO_REFCLIENTE].Value != null ? row.Cells[CAMPO_REFCLIENTE].Value.ToString() : "";
            this.txtObservacion.Text = row.Cells[CAMPO_OBSERVACION].Value != null ? row.Cells[CAMPO_OBSERVACION].Value.ToString() : "";
            this.txtImporte.Text = String.Format("{0:N2}", (decimal)row.Cells[CAMPO_IMPORTE].Value);
            this.txtSaldoCab.Text = String.Format("{0:N2}", (decimal)row.Cells[CAMPO_SALDO].Value);
            this.cbTipoAsocPresup.SelectedIndex = (bool)row.Cells[CAMPO_TIPOASOCPRESUP].Value ? 0 : 1;
            this.txtEstado.Text = row.Cells[CAMPO_ESTADOTEXTO].Value.ToString();

            //if (row.Cells[CAMPO_PRESUPICABIDS].Value != null)
            //{
            //    this.txtPresupID.Text = row.Cells[CAMPO_PRESUPICABIDS].Value.ToString();
            //    this.txtPresupAsoc.Text = this.GetNroDocumento(this.DBContext, row.Cells[CAMPO_PRESUPICABIDS].Value.ToString());
            //}
            //else
            //{
            //    this.txtPresupID.Text = "";
            //    this.txtPresupAsoc.Text = "";
            //}
            //this.txtImporte.Text = String.Format("{0:0.00}", (decimal)row.Cells[CAMPO_IMPORTE].Value);

            if (row.Cells[CAMPO_CLIENTEID].Value != null)
            {
                this.tSBCliente.KeyMember = row.Cells[CAMPO_CLIENTEID].Value.ToString();
                this.tSBCliente.DisplayMember = row.Cells[CAMPO_CLIENTENOMBRE].Value.ToString();
            }

            if (row.Cells[CAMPO_MONEDAID].Value != null)
            {
                this.tSBMoneda.KeyMember = row.Cells[CAMPO_MONEDAID].Value.ToString();
                this.tSBMoneda.DisplayMember = row.Cells[CAMPO_MONEDADESCRIP].Value.ToString();
            }
            
            #region Asociado a Trámite
            this.txtExpedienteID.Text = row.Cells[CAMPO_EXPEDIENTEID].Value != null ? row.Cells[CAMPO_EXPEDIENTEID].Value.ToString() : "";
            this.txtOTID.Text = row.Cells[CAMPO_ORDENTRABAJOID].Value != null ? row.Cells[CAMPO_ORDENTRABAJOID].Value.ToString() : "";
            this.txtActaNro.Text =  row.Cells[CAMPO_ACTANRO].Value != null ? row.Cells[CAMPO_ACTANRO].Value.ToString() : "";
            this.txtActaAnio.Text =  row.Cells[CAMPO_ACTAANIO].Value != null ? row.Cells[CAMPO_ACTAANIO].Value.ToString() : "";
            this.txtHINro.Text =  row.Cells[CAMPO_HINRO].Value != null ? row.Cells[CAMPO_HINRO].Value.ToString() : "";
            this.txtHIAnio.Text =  row.Cells[CAMPO_HIANIO].Value != null ? row.Cells[CAMPO_HIANIO].Value.ToString() : "";

            if (row.Cells[CAMPO_TRAMITEID].Value != null)
            {
                this.txtTramiteID.Text = row.Cells[CAMPO_TRAMITEID].Value.ToString();
                this.txtTramiteDescrip.Text = row.Cells[CAMPO_TRAMITEDESCRIP].Value.ToString();
            }
            #endregion Asociado a Trámite

            #region Gastos Generales
            if (row.Cells[CAMPO_GASTOGENERALID].Value != null)
            {
                this.tSBGastosGenerales.KeyMember = row.Cells[CAMPO_GASTOGENERALID].Value.ToString();
                this.tSBGastosGenerales.DisplayMember = row.Cells[CAMPO_GASTOGENERALDESCRIP].Value.ToString();
            }
            
            if (row.Cells[CAMPO_UNIDADNEGOCIOID].Value != null)
            {
                this.tSBUnidadNegocio.KeyMember = row.Cells[CAMPO_UNIDADNEGOCIOID].Value.ToString();
                this.tSBUnidadNegocio.DisplayMember = row.Cells[CAMPO_UNIDADNEGOCIODESCRIP].Value.ToString();
            }

            if (row.Cells[CAMPO_AREAID].Value != null)
            {
                this.tSBAreaContab.KeyMember = row.Cells[CAMPO_AREAID].Value.ToString();
                this.tSBAreaContab.DisplayMember = row.Cells[CAMPO_AREADESCRIP].Value.ToString();
            }
            #endregion Gastos Generales

            this.SetPresupuestosAsociados(this.DBContext,
                                          row.Cells[CAMPO_PRESUPICABIDS].Value != null ? row.Cells[CAMPO_PRESUPICABIDS].Value.ToString() : "");
            int SolPagoCabID = Convert.ToInt32(this.txtSolPagoCabID.Text);
            this.CargarGrillaDetalles(SolPagoCabID);

        }

        private void HabilitarGrupos(bool existenPagosAsoc = false)
        {
            //this.grpAsociadoaTramite.Enabled = this.rbAsocTramite.Checked && !existenPagosAsoc;
            this.grpGastoGeneral.Enabled = this.rbGastosGrales.Checked && !existenPagosAsoc;

            if (this.rbAsocTramite.Checked)
            {
                this.tSBGastosGenerales.Clear();
                this.tSBAreaContab.Clear();
                this.tSBUnidadNegocio.Clear();
                //this.cbTipoAsocPresup.Enabled = true;
                //this.cbTipoAsocPresup.SelectedIndex = 0;
            }
            else
            {
                this.txtExpedienteID.Text = "";
                this.txtOTID.Text = "";
                this.txtTramiteID.Text = "";
                this.txtTramiteDescrip.Text = "";
                this.txtActaNro.Text = "";
                this.txtActaAnio.Text = "";
                this.txtHINro.Text = "";
                this.txtHIAnio.Text = "";
                //this.cbTipoAsocPresup.Enabled = false;
                //this.cbTipoAsocPresup.SelectedIndex = 1;
            }

        }

        private string GetToolTipTextFilter()
        {
            if (this.cbCampoFiltro.SelectedIndex == 0)
                return "Ingrese ID de Expediente";
            else if (this.cbCampoFiltro.SelectedIndex == 1) 
                return "Ingrese N° de Acta en el formato [N° Acta/Año Acta]";
            else
                return "Ingrese N° de H. de Inicio en el formato [N° HI/HI Acta]";
        }

        private void GetExpedienteMarcas(BerkeDBEntities context, string filtro)
        {
            string sqlWhere = "";

            if (this.cbCampoFiltro.SelectedIndex == 0)
                sqlWhere = " (ExpedienteID == " + filtro + ") ";
            else if (this.cbCampoFiltro.SelectedIndex == 1)
            {
                string[] acta = filtro.Split('/');
                sqlWhere = " (ActaNro == " + acta[0] + ") && ( ActaAnio == " + acta[1] + ")";
            }
            else if (this.cbCampoFiltro.SelectedIndex == 2)
            {
                string[] hi = filtro.Split('/');
                sqlWhere = " (HINro == " + hi[0] + ") && ( hiAnio == " + hi[1] + ")";
            }

            var query = (from expe in context.Expediente
                         join tra in context.Tramite
                             on expe.TramiteID equals tra.ID
                         join ot in context.OrdenTrabajo
                             on expe.OrdenTrabajoID equals ot.ID into ot_expe
                         from ot in ot_expe.DefaultIfEmpty()
                         join cli in context.Cliente
                            on expe.ClienteID equals cli.ID into cli_expe
                         from cli in cli_expe.DefaultIfEmpty()
                        select new BuscarSolPago
                         {
                             ExpedienteID = expe.ID,
                             ActaNro = expe.ActaNro,
                             ActaAnio = expe.ActaAnio,
                             OrdenTrabajoID = expe.OrdenTrabajoID,
                             HINro = ot.Nro,
                             HIAnio = ot.Anio,
                             TramiteID = expe.TramiteID,
                             TramiteDescrip = tra.Descrip,
                             ClienteID = expe.ClienteID,
                             ClienteNombre = cli.Nombre
                         })
                        .Where(sqlWhere, null).ToList();

            if (query.Count == 0)
            {
                MessageBox.Show("No se encontraron datos.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }
            else if (query.Count > 1)
            {
                if (this.cbCampoFiltro.SelectedIndex == 2)
                {
                    this.txtExpedienteID.Text = "";
                    this.txtOTID.Text = query.First().OrdenTrabajoID.HasValue ? query.First().OrdenTrabajoID.Value.ToString() : "";
                    this.txtActaNro.Text = "";
                    this.txtActaAnio.Text = "";
                    this.txtHINro.Text = query.First().HINro != null ? query.First().HINro.ToString() : "";
                    this.txtHIAnio.Text = query.First().HIAnio != null ? query.First().HIAnio.ToString() : "";
                    this.txtTramiteID.Text = query.First().TramiteID.ToString();
                    this.txtTramiteDescrip.Text = query.First().TramiteDescrip;
                    this.MostrarAlerta(query.First().ClienteID.HasValue ? query.First().ClienteID.Value : -1,
                                   query.First().ClienteNombre);
                }
                else
                {
                    MessageBox.Show("Existe más de un expediente que satisface los filtros.",
                                    "Información",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    return;
                }
            }
            else
            {
                this.txtExpedienteID.Text = query.First().ExpedienteID.ToString();
                this.txtOTID.Text = query.First().OrdenTrabajoID.HasValue ? query.First().OrdenTrabajoID.Value.ToString() : "";
                this.txtActaNro.Text = query.First().ActaNro.HasValue ? query.First().ActaNro.Value.ToString() : "";
                this.txtActaAnio.Text = query.First().ActaAnio.HasValue ? query.First().ActaAnio.Value.ToString() : "";
                this.txtHINro.Text = query.First().HINro != null ? query.First().HINro.ToString() : "";
                this.txtHIAnio.Text = query.First().HIAnio != null ? query.First().HIAnio.ToString() : "";
                this.txtTramiteID.Text = query.First().TramiteID.ToString();
                this.txtTramiteDescrip.Text = query.First().TramiteDescrip;
                this.MostrarAlerta(query.First().ClienteID.HasValue ? query.First().ClienteID.Value : -1, 
                                   query.First().ClienteNombre);
            }


        }

        private void GetExpedienteOtros(BerkeDBEntities context, string filtro)
        {
            string sqlWhere = "";

            if (this.cbCampoFiltro.SelectedIndex == 0)
                sqlWhere = " (ExpedienteID == " + filtro + ") ";
            else if (this.cbCampoFiltro.SelectedIndex == 1)
            {
                string[] acta = filtro.Split('/');
                sqlWhere = " (ActaNro == " + acta[0] + ") && ( ActaAnio == " + acta[1] + ")";
            }
            else if (this.cbCampoFiltro.SelectedIndex == 2)
            {
                string[] hi = filtro.Split('/');
                sqlWhere = " (HINro == " + hi[0] + ") && ( HIAnio == " + hi[1] + ")";
            }

            var query = (from op in context.op_oposicion
                         join tra in context.Tramite
                             on op.TramiteID equals tra.ID
                         join ot in context.OrdenTrabajo
                             on op.OrdenTrabajoID equals ot.ID into ot_expe
                         from ot in ot_expe.DefaultIfEmpty()
                         join cli in context.Cliente
                            on op.ClienteID equals cli.ID into cli_op
                         from cli in cli_op.DefaultIfEmpty()
                         select new BuscarSolPago
                         {
                             ExpedienteID = op.ID,
                             ActaNro = op.ActaNro,
                             ActaAnio = op.ActaAnio,
                             OrdenTrabajoID = op.OrdenTrabajoID,
                             HINro = ot.Nro,
                             HIAnio = ot.Anio,
                             TramiteID = op.TramiteID,
                             TramiteDescrip = tra.Descrip,
                             ClienteID = op.ClienteID,
                             ClienteNombre = cli.Nombre
                         })
                        .Where(sqlWhere, null).ToList();

            if (query.Count == 0)
            {
                MessageBox.Show("No se encontraron datos.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }
            else if (query.Count > 1)
            {
                MessageBox.Show("Existe más de un expediente que satisface los filtros.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }
            else
            {
                this.txtExpedienteID.Text = query.First().ExpedienteID.ToString();
                this.txtOTID.Text = query.First().OrdenTrabajoID.HasValue ? query.First().OrdenTrabajoID.Value.ToString() : "";
                this.txtActaNro.Text = query.First().ActaNro.HasValue ? query.First().ActaNro.Value.ToString() : "";
                this.txtActaAnio.Text = query.First().ActaAnio.HasValue ? query.First().ActaAnio.Value.ToString() : "";
                this.txtHINro.Text = query.First().HINro != null ? query.First().HINro.ToString() : "";
                this.txtHIAnio.Text = query.First().HIAnio != null ? query.First().HIAnio.ToString() : "";
                this.txtTramiteID.Text = query.First().TramiteID.ToString();
                this.txtTramiteDescrip.Text = query.First().TramiteDescrip;
                this.MostrarAlerta(query.First().ClienteID.HasValue ? query.First().ClienteID.Value : -1,
                                   query.First().ClienteNombre);
            }
        }

        private void CargarGrillaDetalles(int SolPagoCabID)
        {
            var query = (from item in solpag
                         select new
                         {
                             SolPagoCabID = item.SolPagoCabID,
                             SolPagoDetID = item.SolPagoDetID,
                             FecSolicitudDet = item.FecSolicitudDet,
                             TarifaID = item.TarifaID,
                             TarifaDescrip = item.TarifaDescrip,
                             PrecioCosto = item.PrecioCosto,
                             Cantidad = item.Cantidad,
                             PrecioVenta = item.PrecioVenta,
                             TipoUnidDescuento = item.TipoUnidDescuento,
                             DescuentoMonto = item.DescuentoMonto,
                             DescuentoPorc = item.DescuentoPorc,
                             TipoUnidImp = item.TipoUnidImp,
                             ImpuestoMonto = item.ImpuestoMonto,
                             ImpuestoPorc = item.ImpuestoPorc,
                             Total = item.Total,
                             ProveedorID = item.ProveedorID,
                             NombreProveedor = item.NombreProveedor,
                             NroFacturaProv = item.NroFacturaProv,
                             FecFactura = item.FecFactura,
                             Facturable = item.Facturable,
                             Reembolsable = item.Reembolsable,
                             CorrespondenciaID = item.CorrespondenciaID,
                             CorrespondenciaTexto = item.CorrespondenciaTexto,
                             RefCorresp = item.RefCorresp,
                             SaldoDet = item.SaldoDet,
                             SolicitadoPor = item.SolicitadoPor,
                             SolicitadoPorNombre = item.SolicitadoPorNombre,
                             Exentas = item.Exentas,
                             CantidadIVA5 = item.CantidadIVA5,
                             PrecUnitIVA5 = item.PrecUnitIVA5,
                             IVA5 = item.IVA5,
                             CantidadIVA10 = item.CantidadIVA10,
                             PrecUnitIVA10 = item.PrecUnitIVA10,
                             IVA10 = item.IVA10,
                             TipoFacturaID = item.TipoFacturaID,
                             TipoFacturaDescrip = item.TipoFacturaDescrip
                         }
                        )
                        .Where(a => a.SolPagoCabID == SolPagoCabID).ToList();
            if ((query.Count > 0) && (query.First().SolPagoDetID != null))
            {
                this.dgvDetalleSolPago.DataSource = query;
                this.FormatearGrillaDet();
            }
            else
                this.dgvDetalleSolPago.DataSource = null;

        }

        private void FormatearGrillaDet()
        {
            this.dgvDetalleSolPago.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvDetalleSolPago.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dgvDetalleSolPago.DefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvDetalleSolPago.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvDetalleSolPago.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            this.dgvDetalleSolPago.ItemsPerPage = 10;
            this.dgvDetalleSolPago.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            foreach (DataGridViewColumn col in this.dgvDetalleSolPago.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            int displayIndex = 0;

            this.dgvDetalleSolPago.Columns[CAMPO_FECHASOLDET].Visible = true;
            this.dgvDetalleSolPago.Columns[CAMPO_FECHASOLDET].DisplayIndex = displayIndex;
            this.dgvDetalleSolPago.Columns[CAMPO_FECHASOLDET].HeaderText = "Fecha";
            this.dgvDetalleSolPago.Columns[CAMPO_FECHASOLDET].Width = 70;
            this.dgvDetalleSolPago.Columns[CAMPO_FECHASOLDET].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            displayIndex++;

            this.dgvDetalleSolPago.Columns[CAMPO_NOMBREPROVEEDOR].Visible = true;
            this.dgvDetalleSolPago.Columns[CAMPO_NOMBREPROVEEDOR].DisplayIndex = displayIndex;
            this.dgvDetalleSolPago.Columns[CAMPO_NOMBREPROVEEDOR].HeaderText = "Proveedor";
            this.dgvDetalleSolPago.Columns[CAMPO_NOMBREPROVEEDOR].Width = 200;
            displayIndex++;

            this.dgvDetalleSolPago.Columns[CAMPO_TARIFADESCRIP].Visible = true;
            this.dgvDetalleSolPago.Columns[CAMPO_TARIFADESCRIP].DisplayIndex = displayIndex;
            this.dgvDetalleSolPago.Columns[CAMPO_TARIFADESCRIP].HeaderText = "Descripción";
            this.dgvDetalleSolPago.Columns[CAMPO_TARIFADESCRIP].Width = 200;
            displayIndex++;

            this.dgvDetalleSolPago.Columns[CAMPO_EXENTAS].Visible = true;
            this.dgvDetalleSolPago.Columns[CAMPO_EXENTAS].DisplayIndex = displayIndex;
            this.dgvDetalleSolPago.Columns[CAMPO_EXENTAS].HeaderText = "Exentas";
            this.dgvDetalleSolPago.Columns[CAMPO_EXENTAS].Width = 80;
            this.dgvDetalleSolPago.Columns[CAMPO_EXENTAS].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvDetalleSolPago.Columns[CAMPO_EXENTAS].DefaultCellStyle.Format = "N2";
            displayIndex++;

            this.dgvDetalleSolPago.Columns[CAMPO_IVA5].Visible = true;
            this.dgvDetalleSolPago.Columns[CAMPO_IVA5].DisplayIndex = displayIndex;
            this.dgvDetalleSolPago.Columns[CAMPO_IVA5].HeaderText = "Grav. 5%";
            this.dgvDetalleSolPago.Columns[CAMPO_IVA5].Width = 80;
            this.dgvDetalleSolPago.Columns[CAMPO_IVA5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvDetalleSolPago.Columns[CAMPO_IVA5].DefaultCellStyle.Format = "N2";
            displayIndex++;

            this.dgvDetalleSolPago.Columns[CAMPO_IVA10].Visible = true;
            this.dgvDetalleSolPago.Columns[CAMPO_IVA10].DisplayIndex = displayIndex;
            this.dgvDetalleSolPago.Columns[CAMPO_IVA10].HeaderText = "Grav. 10%";
            this.dgvDetalleSolPago.Columns[CAMPO_IVA10].Width = 80;
            this.dgvDetalleSolPago.Columns[CAMPO_IVA10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvDetalleSolPago.Columns[CAMPO_IVA10].DefaultCellStyle.Format = "N2";
            displayIndex++;

            //this.dgvDetalleSolPago.Columns[CAMPO_CANTIDAD].Visible = true;
            //this.dgvDetalleSolPago.Columns[CAMPO_CANTIDAD].DisplayIndex = displayIndex;
            //this.dgvDetalleSolPago.Columns[CAMPO_CANTIDAD].HeaderText = "Cantidad";
            //this.dgvDetalleSolPago.Columns[CAMPO_CANTIDAD].Width = 80;
            //this.dgvDetalleSolPago.Columns[CAMPO_CANTIDAD].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dgvDetalleSolPago.Columns[CAMPO_CANTIDAD].DefaultCellStyle.Format = "N2";
            //displayIndex++;

            //this.dgvDetalleSolPago.Columns[CAMPO_PRECIOCOSTO].Visible = true;
            //this.dgvDetalleSolPago.Columns[CAMPO_PRECIOCOSTO].DisplayIndex = displayIndex;
            //this.dgvDetalleSolPago.Columns[CAMPO_PRECIOCOSTO].HeaderText = "Prec. Unit.";
            //this.dgvDetalleSolPago.Columns[CAMPO_PRECIOCOSTO].Width = 80;
            //this.dgvDetalleSolPago.Columns[CAMPO_PRECIOCOSTO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dgvDetalleSolPago.Columns[CAMPO_PRECIOCOSTO].DefaultCellStyle.Format = "N2";
            //displayIndex++;

            this.dgvDetalleSolPago.Columns[CAMPO_TOTAL].Visible = true;
            this.dgvDetalleSolPago.Columns[CAMPO_TOTAL].DisplayIndex = displayIndex;
            this.dgvDetalleSolPago.Columns[CAMPO_TOTAL].HeaderText = "Total";
            this.dgvDetalleSolPago.Columns[CAMPO_TOTAL].Width = 80;
            this.dgvDetalleSolPago.Columns[CAMPO_TOTAL].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvDetalleSolPago.Columns[CAMPO_TOTAL].DefaultCellStyle.Format = "N2";
            displayIndex++;

            this.dgvDetalleSolPago.Columns[CAMPO_SALDODET].Visible = true;
            this.dgvDetalleSolPago.Columns[CAMPO_SALDODET].DisplayIndex = displayIndex;
            this.dgvDetalleSolPago.Columns[CAMPO_SALDODET].HeaderText = "Saldo";
            this.dgvDetalleSolPago.Columns[CAMPO_SALDODET].Width = 80;
            this.dgvDetalleSolPago.Columns[CAMPO_SALDODET].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvDetalleSolPago.Columns[CAMPO_SALDODET].DefaultCellStyle.Format = "N2";
            displayIndex++;

            this.dgvDetalleSolPago.Columns[CAMPO_TIPOFACTURADESCRIP].Visible = true;
            this.dgvDetalleSolPago.Columns[CAMPO_TIPOFACTURADESCRIP].DisplayIndex = displayIndex;
            this.dgvDetalleSolPago.Columns[CAMPO_TIPOFACTURADESCRIP].HeaderText = "T. Factura";
            this.dgvDetalleSolPago.Columns[CAMPO_TIPOFACTURADESCRIP].Width = 80;
            this.dgvDetalleSolPago.Columns[CAMPO_TIPOFACTURADESCRIP].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            displayIndex++;

            //this.dgvDetalleSolPago.Columns[CAMPO_PRECIOVENTA].Visible = true;
            //this.dgvDetalleSolPago.Columns[CAMPO_PRECIOVENTA].DisplayIndex = displayIndex;
            //this.dgvDetalleSolPago.Columns[CAMPO_PRECIOVENTA].HeaderText = "Prec. Venta";
            //this.dgvDetalleSolPago.Columns[CAMPO_PRECIOVENTA].Width = 80;
            //this.dgvDetalleSolPago.Columns[CAMPO_PRECIOVENTA].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dgvDetalleSolPago.Columns[CAMPO_PRECIOVENTA].DefaultCellStyle.Format = "N2";
            //displayIndex++;

            //this.dgvDetalleSolPago.Columns[CAMPO_DESCUENTOMONTO].Visible = true;
            //this.dgvDetalleSolPago.Columns[CAMPO_DESCUENTOMONTO].DisplayIndex = displayIndex;
            //this.dgvDetalleSolPago.Columns[CAMPO_DESCUENTOMONTO].HeaderText = "Monto Desc.";
            //this.dgvDetalleSolPago.Columns[CAMPO_DESCUENTOMONTO].Width = 90;
            //this.dgvDetalleSolPago.Columns[CAMPO_DESCUENTOMONTO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dgvDetalleSolPago.Columns[CAMPO_DESCUENTOMONTO].DefaultCellStyle.Format = "N2";
            //displayIndex++;

            //this.dgvDetalleSolPago.Columns[CAMPO_DESCUENTOPORC].Visible = true;
            //this.dgvDetalleSolPago.Columns[CAMPO_DESCUENTOPORC].DisplayIndex = displayIndex;
            //this.dgvDetalleSolPago.Columns[CAMPO_DESCUENTOPORC].HeaderText = "Porc. Desc.";
            //this.dgvDetalleSolPago.Columns[CAMPO_DESCUENTOPORC].Width = 80;
            //this.dgvDetalleSolPago.Columns[CAMPO_DESCUENTOPORC].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dgvDetalleSolPago.Columns[CAMPO_DESCUENTOPORC].DefaultCellStyle.Format = "N2";
            //displayIndex++;

            //this.dgvDetalleSolPago.Columns[CAMPO_IMPUESTOMONTO].Visible = true;
            //this.dgvDetalleSolPago.Columns[CAMPO_IMPUESTOMONTO].DisplayIndex = displayIndex;
            //this.dgvDetalleSolPago.Columns[CAMPO_IMPUESTOMONTO].HeaderText = "Monto Imp.";
            //this.dgvDetalleSolPago.Columns[CAMPO_IMPUESTOMONTO].Width = 80;
            //this.dgvDetalleSolPago.Columns[CAMPO_IMPUESTOMONTO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dgvDetalleSolPago.Columns[CAMPO_IMPUESTOMONTO].DefaultCellStyle.Format = "N2";
            //displayIndex++;

            //this.dgvDetalleSolPago.Columns[CAMPO_IMPUESTOPORC].Visible = true;
            //this.dgvDetalleSolPago.Columns[CAMPO_IMPUESTOPORC].DisplayIndex = displayIndex;
            //this.dgvDetalleSolPago.Columns[CAMPO_IMPUESTOPORC].HeaderText = "Porc. Imp.";
            //this.dgvDetalleSolPago.Columns[CAMPO_IMPUESTOPORC].Width = 80;
            //this.dgvDetalleSolPago.Columns[CAMPO_IMPUESTOPORC].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dgvDetalleSolPago.Columns[CAMPO_IMPUESTOPORC].DefaultCellStyle.Format = "N2";
            //displayIndex++;

            this.dgvDetalleSolPago.Columns[CAMPO_SOLPAGODETID].HeaderText = "Detalle ID";
            this.dgvDetalleSolPago.Columns[CAMPO_SOLPAGODETID].Width = 80;
            this.dgvDetalleSolPago.Columns[CAMPO_SOLPAGODETID].DisplayIndex = displayIndex;
            this.dgvDetalleSolPago.Columns[CAMPO_SOLPAGODETID].Visible = true;
            displayIndex++;

            //this.dgvDetalleSolPago.Columns[CAMPO_RECARGONETO].Visible = true;
            //this.dgvDetalleSolPago.Columns[CAMPO_RECARGONETO].DisplayIndex = 10;
            //this.dgvDetalleSolPago.Columns[CAMPO_RECARGONETO].HeaderText = "Rec. Neto";
            //this.dgvDetalleSolPago.Columns[CAMPO_RECARGONETO].Width = 95;
            //this.dgvDetalleSolPago.Columns[CAMPO_RECARGONETO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //this.dgvDetalleSolPago.Columns[CAMPO_TOTALCONRECARGO].Visible = true;
            //this.dgvDetalleSolPago.Columns[CAMPO_TOTALCONRECARGO].DisplayIndex = 11;
            //this.dgvDetalleSolPago.Columns[CAMPO_TOTALCONRECARGO].HeaderText = @"Tot. c/ Rec.";
            //this.dgvDetalleSolPago.Columns[CAMPO_TOTALCONRECARGO].Width = 95;
            //this.dgvDetalleSolPago.Columns[CAMPO_TOTALCONRECARGO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private List<int> GetListaProveedorID()
        {
            List<int> lista = new List<int>();
            int gProveedorID = -1;

            foreach(DataGridViewRow row in this.dgvDetalleSolPago.Rows)
            {
                if (row.Cells[CAMPO_PROVEEDORID].Value != null)
                {
                    if (gProveedorID != (int)row.Cells[CAMPO_PROVEEDORID].Value)
                    {
                        gProveedorID = (int)row.Cells[CAMPO_PROVEEDORID].Value;
                        lista.Add(gProveedorID);
                    }
                }
            }
            
            return lista;
        }

        private void MostrarAlerta(int clienteID, string clienteNombre)
        {
            int clienteIDSol = this.tSBCliente.KeyMember != "" ? Convert.ToInt32(this.tSBCliente.KeyMember) : -1;

            if (clienteID != clienteIDSol)
            {
                string cliente = String.Format("{0} ({1})", clienteNombre, clienteID.ToString());
                string messageInt = "El cliente del expediente \"{0}\", no coincide con el cliente ingresado en la solicitud.";
                string captionInt = "Advertencia";

                MessageBox.Show(String.Format(messageInt, cliente),
                               captionInt,
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
            }
        }

        #endregion Métodos de Apoyo

        #region Métodos locales sobre controles
        private void cbTipoAsocPresup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.FormEditStatus != BROWSE)
            {
                this.txtPresupID.Text = "";
                this.txtPresupAsoc.Text = "";
                this.btnBuscar.Enabled = this.cbTipoAsocPresup.SelectedIndex == 1;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (fSeleccionPresupAsoc == null)
                {
                    fSeleccionPresupAsoc = new FSeleccionarPresupuesto(this.DBContext, 
                                                                        "Presupuestos Asociados", 
                                                                        this.txtPresupID.Text,
                                                                        this.cbTipoAsocPresup.SelectedIndex);
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

        private void tabListaABM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this.tabListaABM.SelectedIndex == 2) && (this.dgvDetalleSolPago.RowCount > 0))
            {
                this.dgvDetalleSolPago.CurrentCell = this.dgvDetalleSolPago.Rows[0].Cells[CAMPO_FECHASOLDET];
                this.dgvDetalleSolPago.Focus();
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (this.txtFiltroExpedienteID.Text == "")
            {
                MessageBox.Show("Debe ingresar algún criterio de filtro.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            using (BerkeDBEntities context = new BerkeDBEntities())
            {
                try
                {
                    if (this.cbOrigen.SelectedIndex == 0)
                    {
                        this.GetExpedienteMarcas(context, this.txtFiltroExpedienteID.Text);
                    }
                    else
                    {
                        this.GetExpedienteOtros(context, this.txtFiltroExpedienteID.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al buscar el expediente: "
                                        + ex.Message + Environment.NewLine
                                        + ex.InnerException,
                                        "Error al buscar los datos",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Stop);
                }
            }
        }

        private void ucCRUDSolPago_VisibleChanged(object sender, EventArgs e)
        {
            if (this.tabListaABM.SelectedIndex == 0)
                this.FormatearGrilla();
        }

        private void dgvListadoABM_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this.LastDGVIndex > -1)
                this.CargarSolPago(this.dgvListadoABM.Rows[this.LastDGVIndex]);
        }

        private void tbbGuardar_Click_1(object sender, EventArgs e)
        {
            #region Validaciones
            if (this.tSBMoneda.KeyMember == "")
            {
                MessageBox.Show("Debe ingresar la moneda de solicitud de pago.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (this.rbAsocTramite.Checked)
            {
                if (this.tSBCliente.KeyMember == "")
                {
                    MessageBox.Show("Debe ingresar un cliente.",
                                    "Información",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    return;
                }

                //if (this.txtExpedienteID.Text == "")
                //{
                //    MessageBox.Show("Debe ingresar un Expediente.",
                //                    "Información",
                //                    MessageBoxButtons.OK,
                //                    MessageBoxIcon.Information);

                //    return;
                //}
            
            }
            //else if (this.rbGastosGrales.Checked)
            //{
            //    if (this.tSBGastosGenerales.KeyMember == "")
            //    {
            //        MessageBox.Show("Debe ingresar el concepto del Gasto.",
            //                        "Información",
            //                        MessageBoxButtons.OK,
            //                        MessageBoxIcon.Information);

            //        return;
            //    }

            //    if (this.tSBAreaContab.KeyMember == "")
            //    {
            //        MessageBox.Show("Debe ingresar el área asociada al Gasto General.",
            //                        "Información",
            //                        MessageBoxButtons.OK,
            //                        MessageBoxIcon.Information);

            //        return;
            //    }

            //    if (this.tSBUnidadNegocio.KeyMember == "")
            //    {
            //        MessageBox.Show("Debe ingresar la Unidad de Negocio asociada al Gasto General.",
            //                        "Información",
            //                        MessageBoxButtons.OK,
            //                        MessageBoxIcon.Information);

            //        return;
            //    }
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

        private void DialogHandlerEliminarDetalle(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    this.EliminarDetalle(Convert.ToInt32(this.dgvDetalleSolPago.CurrentRow.Cells[CAMPO_SOLPAGODETID].Value));
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

        private void rbAsocTramite_CheckedChanged(object sender, EventArgs e)
        {
            if (this.FormEditStatus != BROWSE)
                this.HabilitarGrupos();
        }

        private void rbGastosGrales_CheckedChanged(object sender, EventArgs e)
        {
            if (this.FormEditStatus != BROWSE)
                this.HabilitarGrupos();
        }

        private void cbCampoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tTBaseForm.SetToolTip(this.txtFiltroExpedienteID, this.GetToolTipTextFilter());
        }

        private void dtpFechaSolCab_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaSolCab.Text = this.dtpFechaSolCab.Value.ToShortDateString();
        }

        private void btnEliminarDetalle_Click(object sender, EventArgs e)
        {
            if (this.dgvDetalleSolPago.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar alguna fila para eliminar.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }


            string caption = "Eliminación de Detalle de Solicitud de Pago";
            string message = "Se eliminará el presente detalle ¿Desea continuar?";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(DialogHandlerEliminarDetalle));
        }

        private void dgvDetalleSolPago_DoubleClick(object sender, EventArgs e)
        {
            //int currenRowIndex = this.dgvDetalleSolPago.CurrentRow.Index;
            bool pagado = (decimal)this.dgvDetalleSolPago.CurrentRow.Cells[CAMPO_SALDODET].Value == 0 
                            && (decimal)this.dgvDetalleSolPago.CurrentRow.Cells[CAMPO_TOTAL].Value > 0;
            Forms.UI.FDetalleSolPago f = new Forms.UI.FDetalleSolPago(this.DBContext,
                                                                      this.dgvDetalleSolPago.CurrentRow,
                                                                      new MonedaInfo { MonedadID = Convert.ToInt32(this.tSBMoneda.KeyMember), MonedaDescrip = this.tSBMoneda.DisplayMember },
                                                                      Convert.ToInt32(this.txtSolPagoCabID.Text),
                                                                      this.FormEditStatus != BROWSE && !pagado ? true : false,
                                                                      false, true);
            f.FormClosed += delegate
            {
                if (f.SeGuardo)
                {
                    MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.FilterEntity(this.WhereString, this.FilterParam);
                    //this.CargarSolPago(this.dgvListadoABM.Rows[this.LastDGVIndex]);
                    this.CargarSolPago(this.dgvListadoABM.Rows[this.LastDGVIndex]);
                    //this.dgvDetalleSolPago.CurrentCell = this.dgvDetalleSolPago.Rows[currenRowIndex].Cells[CAMPO_FECHASOLDET];
                    //this.dgvDetalleSolPago.Focus();
                }
                f = null;
            };
            f.ShowDialog();
        }

        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            //int currenRowIndex = this.dgvDetalleSolPago.CurrentRow.Index;
            Forms.UI.FDetalleSolPago f = new Forms.UI.FDetalleSolPago(this.DBContext,
                                                                        this.dgvDetalleSolPago.CurrentRow,
                                                                        new MonedaInfo { MonedadID = Convert.ToInt32(this.tSBMoneda.KeyMember), MonedaDescrip = this.tSBMoneda.DisplayMember },
                                                                        Convert.ToInt32(this.txtSolPagoCabID.Text),
                                                                        true, true, true);
            f.FormClosed += delegate
            {
                if (f.SeGuardo)
                {
                    MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.FilterEntity(this.WhereString, this.FilterParam);
                    //this.CargarSolPago(this.dgvListadoABM.Rows[this.LastDGVIndex]);
                    this.CargarSolPago(this.dgvListadoABM.Rows[this.LastDGVIndex]);
                    //this.dgvDetalleSolPago.CurrentCell = this.dgvDetalleSolPago.Rows[currenRowIndex].Cells[CAMPO_FECHASOLDET];
                    //this.dgvDetalleSolPago.Focus();
                }
                f = null;
            };
            f.ShowDialog();
        }

        private void txtImporte_Leave(object sender, EventArgs e)
        {
            if (this.FormEditStatus != BROWSE)
                this.txtSaldoCab.Text = this.txtImporte.Text;
        }

        #endregion Métodos locales sobre controles

        #region CRUD

        private void GuardarRegistro()
        {
            bool success = false;

            spc_solicitudpagocab spc = null;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        spc = this.guardarSolPagoCab(context);
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
                    this.FilterEntity(CAMPO_SOLPAGOCABID + " = " + spc.spc_solicitudpagocabid.ToString(), null);
                else if (this.FormEditStatus == EDIT)
                    this.FilterEntity(this.WhereString, this.FilterParam);

                this.FormEditStatus = BROWSE;
                this.CargarSolPago(this.dgvListadoABM.Rows[this.LastDGVIndex]);

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
                        this.eliminarSolPagoCab(context);
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
        private spc_solicitudpagocab guardarSolPagoCab(BerkeDBEntities context = null)
        {
            spc_solicitudpagocab spc = new spc_solicitudpagocab();
            if (this.FormEditStatus == EDIT)
            {
                int solpagocabID = Convert.ToInt32(this.txtSolPagoCabID.Text);

                spc = context.spc_solicitudpagocab.First(a => a.spc_solicitudpagocabid == solpagocabID);

                spc.spc_fechasol = Convert.ToDateTime(this.txtFechaSolCab.Text);
                spc.spc_origen = this.cbOrigen.SelectedValue.ToString();

                if (this.tSBCliente.KeyMember.Trim() != "")
                {
                    spc.spc_clienteid = Convert.ToInt32(this.tSBCliente.KeyMember);
                }
                else spc.spc_clienteid = null;

                spc.spc_monedaid = Convert.ToInt32(this.tSBMoneda.KeyMember);
                spc.spc_tiposolicitudpago = this.rbAsocTramite.Checked;
                spc.spc_refcliente = this.txtRefCliente.Text.Trim() != "" ? this.txtRefCliente.Text : null;
                spc.spc_observacion = this.txtObservacion.Text.Trim() != "" ? this.txtObservacion.Text : null;

                if (this.txtExpedienteID.Text != "")
                    spc.spc_expedienteid = Convert.ToInt32(this.txtExpedienteID.Text);
                else spc.spc_expedienteid = null;

                if (this.txtOTID.Text != "")
                    spc.spc_ordentrabajoid = Convert.ToInt32(this.txtOTID.Text);
                else spc.spc_ordentrabajoid = null;

                if (this.txtTramiteID.Text != "")
                    spc.spc_tramiteid = Convert.ToInt32(this.txtTramiteID.Text);
                else spc.spc_tramiteid = null;

                if (this.txtActaNro.Text != "")
                {
                    spc.spc_actanro = Convert.ToInt32(this.txtActaNro.Text);
                    spc.spc_actaanio = Convert.ToInt32(this.txtActaAnio.Text);
                }
                else
                {
                    spc.spc_actanro = null;
                    spc.spc_actaanio = null;
                }

                if (this.txtHINro.Text != "")
                {
                    spc.spc_hinro = Convert.ToInt32(this.txtHINro.Text);
                    spc.spc_hianio = Convert.ToInt32(this.txtHIAnio.Text);
                }
                else
                {
                    spc.spc_hinro = null;
                    spc.spc_hianio = null;
                }

                if (this.tSBGastosGenerales.KeyMember.Trim() != "")
                    spc.spc_gastogeneralid = Convert.ToInt32(this.tSBGastosGenerales.KeyMember);
                else spc.spc_gastogeneralid = null;

                if (this.tSBAreaContab.KeyMember.Trim() != "")
                    spc.spc_areaid = Convert.ToInt32(this.tSBAreaContab.KeyMember);
                else spc.spc_areaid = null;

                if (this.tSBUnidadNegocio.KeyMember.Trim() != "")
                    spc.spc_unidadnegocioid = Convert.ToInt32(this.tSBUnidadNegocio.KeyMember);
                else spc.spc_unidadnegocioid = null;

                if (!this.txtImporte.ReadOnly)
                {
                    spc.spc_importe = Convert.ToDecimal(this.txtImporte.Text);
                    spc.spc_saldo = Convert.ToDecimal(this.txtSaldoCab.Text);
                }

                if (this.cbTipoAsocPresup.SelectedIndex == 0)
                {
                    spc.spc_tipoasociacionpresup = true;
                    spc.spc_presupcabids = null;
                }
                else
                {
                    spc.spc_tipoasociacionpresup = false;
                    spc.spc_presupcabids = this.txtPresupID.Text != "" ? this.txtPresupID.Text : null;
                }
            }
            else if (this.FormEditStatus == INSERT)
            {
                spc.spc_fechasol = Convert.ToDateTime(this.txtFechaSolCab.Text);
                spc.spc_origen = this.cbOrigen.SelectedValue.ToString();
                spc.spc_estado = ESTADO_PENDIENTE;

                if (this.tSBCliente.KeyMember.Trim() != "")
                {
                    spc.spc_clienteid = Convert.ToInt32(this.tSBCliente.KeyMember);
                }
                else spc.spc_clienteid = null;

                spc.spc_monedaid = Convert.ToInt32(this.tSBMoneda.KeyMember);
                spc.spc_tiposolicitudpago = this.rbAsocTramite.Checked;
                spc.spc_refcliente = this.txtRefCliente.Text.Trim() != "" ? this.txtRefCliente.Text : null;//this.GetString(this.txtRefCliente.Text);
                spc.spc_observacion = this.txtObservacion.Text.Trim() != "" ? this.txtObservacion.Text : null;//this.GetString(this.txtObservacion.Text);

                if (this.txtExpedienteID.Text != "")
                    spc.spc_expedienteid = Convert.ToInt32(this.txtExpedienteID.Text);
                else spc.spc_expedienteid = null;

                if (this.txtOTID.Text != "")
                    spc.spc_ordentrabajoid = Convert.ToInt32(this.txtOTID.Text);
                else spc.spc_ordentrabajoid = null;

                if (this.txtTramiteID.Text != "")
                    spc.spc_tramiteid = Convert.ToInt32(this.txtTramiteID.Text);
                else spc.spc_tramiteid = null;

                if (this.txtActaNro.Text != "")
                {
                    spc.spc_actanro = Convert.ToInt32(this.txtActaNro.Text);
                    spc.spc_actaanio = Convert.ToInt32(this.txtActaAnio.Text);
                }
                else
                {
                    spc.spc_actanro = null;
                    spc.spc_actaanio = null;
                }

                if (this.txtHINro.Text != "")
                {
                    spc.spc_hinro = Convert.ToInt32(this.txtHINro.Text);
                    spc.spc_hianio = Convert.ToInt32(this.txtHIAnio.Text);
                }
                else
                {
                    spc.spc_hinro = null;
                    spc.spc_hianio = null;
                }

                if (this.tSBGastosGenerales.KeyMember.Trim() != "")
                    spc.spc_gastogeneralid = Convert.ToInt32(this.tSBGastosGenerales.KeyMember);
                else spc.spc_gastogeneralid = null;

                if (this.tSBAreaContab.KeyMember.Trim() != "")
                    spc.spc_areaid = Convert.ToInt32(this.tSBAreaContab.KeyMember);
                else spc.spc_areaid = null;

                if (this.tSBUnidadNegocio.KeyMember.Trim() != "")
                    spc.spc_unidadnegocioid = Convert.ToInt32(this.tSBUnidadNegocio.KeyMember);
                else spc.spc_unidadnegocioid = null;

                if (!this.txtImporte.ReadOnly)
                {
                    spc.spc_importe = Convert.ToDecimal(this.txtImporte.Text);
                    spc.spc_saldo = Convert.ToDecimal(this.txtSaldoCab.Text);
                }

                if (this.cbTipoAsocPresup.SelectedIndex == 0)
                {
                    spc.spc_tipoasociacionpresup = true;
                    spc.spc_presupcabids = null;
                }
                else
                {
                    spc.spc_tipoasociacionpresup = false;
                    spc.spc_presupcabids = this.txtPresupID.Text != "" ? this.txtPresupID.Text : null;
                }
                context.spc_solicitudpagocab.Add(spc);
            }
            return spc;
        }

        private void eliminarSolPagoCab(BerkeDBEntities context = null)
        {
            int solpagocabID = Convert.ToInt32(this.txtSolPagoCabID.Text);
            spc_solicitudpagocab spc = context.spc_solicitudpagocab.First(a => a.spc_solicitudpagocabid == solpagocabID);

            context.spc_solicitudpagocab.Remove(spc);

        }

        private void EliminarDetalle(int SolPagoDetID)
        {
            bool success = false;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        spd_solicitudpagodet spd = context.spd_solicitudpagodet.First(a => a.spd_solicitudpagodetid == SolPagoDetID);
                        context.spd_solicitudpagodet.Remove(spd);
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
                    //this.FormEditStatus = BROWSE;
                    MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        #endregion Métodos de Edición de Datos

        #endregion CRUD

        #region Eventos delegados
        private void f_AceptarClick(object sender, EventArgs e)
        {
            this.txtPresupID.Text = fSeleccionPresupAsoc.ListaPresupuestosID;
            this.txtPresupAsoc.Text = fSeleccionPresupAsoc.ListaPresupuestos;
            fSeleccionPresupAsoc.Close();
        }
        #endregion Eventos delegados

    }
}