#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Gateways;

using ModelEF6;
using SPF.Types;
using SPF.Forms.Base;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.ObjectModel;
using System.Data.Objects.SqlClient;
using Microsoft.Reporting.WebForms;

#endregion

namespace SPF.UserControls.UI
{
    public partial class ucCRUDPresupuesto : ucBaseForm
    {
        #region Constantes
        private const string CAMPO_PRESUPUESTOCABID     = "PresupuestoCabID";
        private const string CAMPO_MERGEDOCID           = "MergeDocID";
        private const string CAMPO_SERIE                = "Serie";
        private const string CAMPO_NROPRESUPUESTO       = "NroPresupuesto";
        private const string CAMPO_DESCRIPCION          = "Descripcion";
        private const string CAMPO_FACTURANRO           = "FacturaNro";
        private const string CAMPO_FACTURACABID         = "FacturaCabID";
        private const string CAMPO_CLIENTEID            = "ClienteID";
        private const string CAMPO_CLIENTENOMBRE        = "ClienteNombre";
        private const string CAMPO_ATENCIONID           = "AtencionID";
        private const string CAMPO_ATENCIONOMBRE        = "AtencionNombre";
        private const string CAMPO_MONEDAID             = "MonedaID";
        private const string CAMPO_MONEDADESCRIP        = "MonedaDescrip";
        private const string CAMPO_MONEDAABREV          = "MonedaAbrev";
        private const string CAMPO_AREAID               = "AreaID";
        private const string CAMPO_AREADESCRIP          = "AreaDescrip";
        private const string CAMPO_USUARIOHECHOPORID    = "UsuarioHechoPorID";
        private const string CAMPO_USUARIOHECHOPORNOMBRE= "UsuarioHechoPorNombre";
        private const string CAMPO_USUARIOAPROBPORID    = "UsuarioAprobPorID";
        private const string CAMPO_USUARIOAPROBPORNOMBRE= "UsuarioAprobPorNombre";
        private const string CAMPO_FECHAGENERACION      = "FechaGeneracion";
        private const string CAMPO_USUARIOGENID         = "UsuarioGeneracionID";
        private const string CAMPO_USUARIOGENNOMBRE     = "UsuarioGeneracionNombre";
        private const string CAMPO_TOTAL                = "Total";
        private const string CAMPO_SALDO                = "Saldo";
        private const string CAMPO_PARTENOMBRE          = "ParteNombre";
        private const string CAMPO_CONTRAPARTENOMBRE    = "ContraParteNombre";
        private const string CAMPO_ESTADO               = "Estado";
        private const string CAMPO_ESTADOTEXTO          = "EstadoTexto";
        private const string CAMPO_SERIENROPRESUPUESTO  = "SerieNroPresupuesto";
        private const string CAMPO_SELECCIONAR          = "Seleccionar";
        private const string CAMPO_DETALLEDESCRIPCION   = "DetalleDescripcion";
        private const string CAMPO_DETALLEMONTO         = "DetalleMonto";
        private const string CAMPO_AUTORIZACIONVIG      = "TieneAutorizacionVigente";
        private const string CAMPO_ORIGEN               = "Origen";
        private const string CAMPO_FORMPAGOID           = "FormaPagoID";

        private const string CAMPO_EXPEDIENTEID         = "ExpedienteID";
        private const string CAMPO_DENOMINACIONMARCA    = "DenominacionMarca";
        private const string CAMPO_PROPIETARIOMARCA     = "PropietarioMarca";
        private const string CAMPO_MARCAID              = "MarcaID";
        private const string CAMPO_ACTANRO              = "ActaNro";
        private const string CAMPO_ACTAANIO             = "ActaAnio";
        private const string CAMPO_REGISTRONRO          = "RegistroNro";
        private const string CAMPO_DESCRIPTRAMITE       = "DescripTramite";
        private const string CAMPO_ORDENTRABAJOID       = "OrdenTrabajoID";
        private const string CAMPO_HINRO                = "HINro";
        private const string CAMPO_HIANIO               = "HIAnio";
        private const string CAMPO_ACTA                 = "Acta";
        private const string CAMPO_HI                   = "HI";

        private const string CAMPO_COTIZACIONCABID      = "CotizacionCabID";
        private const string CAMPO_TRAMITEID            = "TramiteID";
        private const string CAMPO_TRAMITEDESCRIPCION   = "TramiteDescripcion";
        private const string CAMPO_TRAMITEDF            = "TramiteDF";

        private const int TIPODOCUMENTO_PRESUPUESTO     = 3;
        private const string ESTADO_ANULADO             = "N";
        private const string ORIGEN_MARCAS              = "M";
        private const string ORIGEN_OTROS               = "O";
        private const int FORMAPAGO_BAJA                = 8;

        private const string CAMPO_DENOMINACION         = "Denominacion";
        private const string CAMPO_TARIFADESCRIPCION    = "TarifaDescripcion";
        private const string CAMPO_CANTIDAD             = "Cantidad";
        private const string CAMPO_PRECIOUNITARIO       = "PrecioUnitario";
        private const string CAMPO_DESCUENTO            = "Descuento";
        private const string CAMPO_NETO                 = "Neto";
        private const string CAMPO_GASTO                = "Gasto";
        private const string CAMPO_RECARGO              = "Recargo";
        private const string CAMPO_IMPUESTO             = "Impuesto";
        private const string CAMPO_ABREVMONEDA          = "AbrevMoneda";
        private const string CAMPO_NROPRESUPUESTOCOMP   = "NroPresupuestoCompuesto";

        private const string DOLLARS = "DOLLARS";
        private const string DOLARES = "DOLARES";
        private const int IDIOMA_ESPANOL = 2;
        private const string GUARANIES = "GUARANIES";
        private const string FORMATO_MONEDA_GUARANIES = "{0:N0}";
        private const string FORMATO_MONEDA_OTROS = "{0:N2}";
        private const int VIA_TELEFONO = 2;
        private const string FACTURA_CONTADO = "C";
        private const string FACTURA_CREDITO = "R";
        private const string CERO_SIN_DECIMALES = "0";
        private const string CERO_CON_DECIMALES = "0,00";
        #endregion Constantes

        #region Variables Globales
        int UsuarioID = -1;
        List<PresupuestoTypeAll> lPresup;
        #endregion Variables Globales

        #region Método de Inicio
        public ucCRUDPresupuesto()
        {
            InitializeComponent();
        }

        public ucCRUDPresupuesto(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();
            this.DBContext = dbContext;
            this.Titulo = Titulo;
            this.TituloDetalle = "Presupuesto";
            this.UsuarioID = Convert.ToInt32(VWGContext.Current.Session["UsuarioID"].ToString());
            this.UseSQLSyntax = true;

            #region Ocultar botones que no se usan
            this.tbbNuevo.Visible = false;
            this.tbbEditar.Visible = false;
            this.tbbGuardar.Visible = false;
            this.tbbImprimir.Visible = false;
            this.tbbCancelar.Visible = false;
            this.tbbBorrar.Visible = false;
            this.tbbUpdDocs.Visible = false;
            #endregion Ocultar botones que no se usan

            #region Deprecated
            //var presup = (from pCab in this.DBContext.pc_presupuestocab
            //              join mDoc in this.DBContext.MergeDoc
            //                on pCab.pc_mergedocid equals mDoc.ID into pCab_mDoc
            //              from mDoc in pCab_mDoc.DefaultIfEmpty()
            //              join clie in this.DBContext.Cliente
            //                on pCab.pc_clienteid equals clie.ID
            //              join aten in this.DBContext.Atencion
            //                on pCab.pc_atencionid equals aten.ID into pCab_aten
            //              from aten in pCab_aten.DefaultIfEmpty()
            //              join mone in this.DBContext.Moneda
            //                on pCab.pc_monedaid equals mone.ID
            //              join cAre in this.DBContext.ac_areacontabilidad
            //                on pCab.pc_areaid equals cAre.ac_areacontabilidadid into pCab_cAre
            //              from cAre in pCab_cAre.DefaultIfEmpty()
            //              join uApr in this.DBContext.Usuario
            //                on pCab.pc_autorizadopor equals uApr.ID
            //              join uHec in this.DBContext.Usuario
            //                on pCab.pc_enviadopor equals uHec.ID
            //              join Tram in this.DBContext.Tramite
            //                on pCab.pc_tramiteid equals Tram.ID
            #endregion Deprecated

            lPresup = new List<PresupuestoTypeAll>();

            lPresup = (from lista in this.DBContext.GetListaPresupuestos(this.UsuarioID, String.Empty)
                          select new PresupuestoTypeAll
                          {
                              PresupuestoCabID = lista.PresupuestoCabID,
                              MergeDocID = lista.MergeDocID,
                              Serie = lista.Serie,
                              NroPresupuesto = lista.NroPresupuesto,
                              Descripcion = lista.Descripcion,
                              ClienteID = lista.ClienteID,
                              ClienteNombre = lista.ClienteNombre,
                              AtencionID = lista.AtencionID,
                              AtencionNombre = lista.AtencionNombre,
                              MonedaID = lista.MonedaID,
                              MonedaDescrip = lista.MonedaDescrip,
                              MonedaAbrev = lista.AbrevMoneda,
                              AreaID = lista.AreaID,
                              AreaDescrip = lista.AreaDescrip,
                              TramiteID = lista.TramiteID,
                              TramiteDescripcion = lista.TramiteDescripcion,
                              TramiteDF = lista.TramiteDF,
                              UsuarioHechoPorID = lista.UsuarioHechoPorID,
                              UsuarioHechoPorNombre = lista.UsuarioHechoPorNombre,
                              UsuarioAprobPorID = lista.UsuarioAprobPorID,
                              UsuarioAprobPorNombre = lista.UsuarioAprobPorNombre,
                              FechaGeneracion = lista.FechaGeneracion,
                              Total = lista.Total,
                              Saldo = lista.Saldo,
                              ParteNombre = lista.ParteNombre,
                              ContraParteNombre = lista.ContraParteNombre,
                              SerieNroPresupuesto = lista.SerieNroPresupuesto,
                              //SerieNroPresupuesto = this.DBContext.ConcatSerieNroPresupuesto(mDoc.Serie, mDoc.NroPresupuesto).FirstOrDefault(),
                              Estado = lista.Estado,
                              Origen = lista.Origen,
                              FacturaNro = lista.FacturaNro,
                              TieneAutorizacionVigente = this.DBContext.GetAutorizacionPorDocumentoID(TIPODOCUMENTO_PRESUPUESTO,
                                                                                                         lista.PresupuestoCabID,
                                                                                                         this.UsuarioID)
                                                                                                         .FirstOrDefault().Value,
                              UsuarioGeneracionID = lista.UsuarioGeneracionID,
                              UsuarioGeneracionNombre = lista.UsuarioGeneracionNombre,
                              FormaPagoID = lista.FormaPagoID,
                              FacturaCabID = lista.FacturaCabID,
                              //Detalle
                              CotizacionCabID = lista.CotizacionCabID,
                              ExpedienteID = lista.ExpedienteID,
                              OrdenTrabajoID = lista.OrdenTrabajoID,
                              ActaNro = lista.ActaNro,
                              ActaAnio = lista.ActaAnio,
                              Acta = lista.Acta,
                              HINro = lista.HINro,
                              HIAnio = lista.HIAnio,
                              HI = lista.HI,
                              PropietarioMarca = lista.PropietarioMarca,
                              DenominacionMarca = lista.DenominacionMarca
                          })
                          .OrderByDescending(a => a.PresupuestoCabID)
                          //.Take(50)
                          .ToList();

            this.BindingSourceBase_ExportExcelGrid = lPresup;
            //this.LoadGridExportToExcel();

            var query = (from item in lPresup
                         select new PresupuestoTypeCab
                         {
                             //Cabecera
                             PresupuestoCabID = item.PresupuestoCabID,
                             MergeDocID = item.MergeDocID,
                             Serie = item.Serie,
                             NroPresupuesto = item.NroPresupuesto,
                             Descripcion = item.Descripcion,
                             ClienteID = item.ClienteID,
                             ClienteNombre = item.ClienteNombre,
                             AtencionID = item.AtencionID,
                             AtencionNombre = item.AtencionNombre,
                             MonedaID = item.MonedaID,
                             MonedaDescrip = item.MonedaDescrip,
                             MonedaAbrev = item.MonedaAbrev,
                             AreaID = item.AreaID,
                             AreaDescrip = item.AreaDescrip,
                             TramiteID = item.TramiteID,
                             TramiteDescripcion = item.TramiteDescripcion,
                             TramiteDF = item.TramiteDF,
                             UsuarioHechoPorID = item.UsuarioHechoPorID,
                             UsuarioHechoPorNombre = item.UsuarioHechoPorNombre,
                             UsuarioAprobPorID = item.UsuarioAprobPorID,
                             UsuarioAprobPorNombre = item.UsuarioAprobPorNombre,
                             FechaGeneracion = item.FechaGeneracion,
                             Total = item.Total,
                             Saldo = item.Saldo,
                             ParteNombre = item.ParteNombre,
                             ContraParteNombre = item.ContraParteNombre,
                             SerieNroPresupuesto = item.SerieNroPresupuesto,
                             Estado = item.Estado,
                             Origen = item.Origen,
                             FacturaNro = item.FacturaNro,
                             TieneAutorizacionVigente = item.TieneAutorizacionVigente,
                             UsuarioGeneracionID = item.UsuarioGeneracionID,
                             UsuarioGeneracionNombre = item.UsuarioGeneracionNombre,
                             FormaPagoID = item.FormaPagoID,
                             FacturaCabID = item.FacturaCabID
                         })
                         .GroupBy(x => new { x.PresupuestoCabID }).Select(g => g.First()).ToList();

            this.BindingSourceBase = query;

            #region Especificar campos para filtro
            this.SetFilter(CAMPO_PRESUPUESTOCABID, "ID Presupuesto", false);
            this.SetFilter(CAMPO_MERGEDOCID, "ID Documento", false);
            this.SetFilter(CAMPO_SERIENROPRESUPUESTO, "Serie + N° Presup.");
            this.SetFilter(CAMPO_FECHAGENERACION, "Fec. Generación");
            this.SetFilter(CAMPO_ESTADO, "Estado");
            this.SetFilter(CAMPO_SERIE, "Serie");
            this.SetFilter(CAMPO_NROPRESUPUESTO, "Nro. Presup.", false);
            this.SetFilter(CAMPO_DESCRIPCION, "Descripción");
            this.SetFilter(CAMPO_FACTURANRO, "Factura N°");
            this.SetFilter(CAMPO_CLIENTEID, "ID Cliente", false);
            this.SetFilter(CAMPO_CLIENTENOMBRE, "Cliente Nombre");
            this.SetFilter(CAMPO_ATENCIONID, "ID Atención", false);
            this.SetFilter(CAMPO_ATENCIONOMBRE, "Atención Nombre");
            this.SetFilter(CAMPO_MONEDAID, "ID Moneda", false);
            this.SetFilter(CAMPO_MONEDADESCRIP, "Descrip. Moneda");
            this.SetFilter(CAMPO_TRAMITEID, "ID Trámite", false);
            this.SetFilter(CAMPO_TRAMITEDESCRIPCION, "Descrip. Trámite");
            this.SetFilter(CAMPO_TRAMITEDF, "Descrip. Tr. DF");
            this.SetFilter(CAMPO_AREAID, "ID Area", false);
            this.SetFilter(CAMPO_AREADESCRIP, "Descrip. Area");
            this.SetFilter(CAMPO_USUARIOHECHOPORID, "ID Usu. Resp.", false);
            this.SetFilter(CAMPO_USUARIOHECHOPORNOMBRE, "Nombre Usu. Resp.");
            this.SetFilter(CAMPO_USUARIOAPROBPORID, "ID Usu. Aprob.", false);
            this.SetFilter(CAMPO_USUARIOAPROBPORNOMBRE, "Nomb. Usu. Aprob.");
            this.SetFilter(CAMPO_USUARIOGENID, "ID Usu. Gen.", false);
            this.SetFilter(CAMPO_USUARIOGENNOMBRE, "Nomb. Usu. Gen.");
            this.SetFilter(CAMPO_TOTAL, "Total", false);
            this.SetFilter(CAMPO_SALDO, "Saldo", false);
            this.SetFilter(CAMPO_PARTENOMBRE, "Nombre Parte");
            this.SetFilter(CAMPO_CONTRAPARTENOMBRE, "Contraparte Nombre");
            this.SetFilter(CAMPO_DENOMINACIONMARCA, "Denom. Marca");
            this.SetFilter(CAMPO_PROPIETARIOMARCA, "Prop. Marca");
            this.SetFilter(CAMPO_EXPEDIENTEID, "ID Expediente", false);
            this.SetFilter(CAMPO_ACTANRO, "N° Acta", false);
            this.SetFilter(CAMPO_ACTAANIO, "Año Acta", false);
            this.SetFilter(CAMPO_ACTA, "Acta (Nro/Año)");
            this.SetFilter(CAMPO_ORDENTRABAJOID, "ID Ord. Trab.", false);
            this.SetFilter(CAMPO_HINRO, "N° HI", false);
            this.SetFilter(CAMPO_HIANIO, "Año HI", false);
            this.SetFilter(CAMPO_HI, "HI (Nro/Año)");
            this.TituloBuscador = "Buscar Prespuestos";
            #endregion Especificar campos para filtro

        }

        private void ucCRUDPresupuesto_Load(object sender, EventArgs e)
        {
            this.tabListaABM_SelectedIndexChanged(sender, e);

            //string path = VWGContext.Current.Server.MapPath(@VWGContext.Current.Session["PresupFolderURL"].ToString());
            string path = VWGContext.Current.Server.MapPath(@"\Resources\UserData\" + VWGContext.Current.Session["WindowsUser"].ToString() + @"\" );

            //MessageBox.Show(path);

            if (!System.IO.Directory.Exists(@path))
            {
                System.IO.Directory.CreateDirectory(@path);
            }
            else
            {
                Array.ForEach(Directory.GetFiles(@path), File.Delete);
            }
        }

        #endregion Método de Inicio

        #region Método Extendidos del ParentControl
        protected override void FilterEntity(string where = "", object[] filterParams = null)
        {
            try
            {
                this.limpiarDatos();

                #region Deprecated
                //var query = (from pCab in this.DBContext.pc_presupuestocab
                //             join mDoc in this.DBContext.MergeDoc
                //                on pCab.pc_mergedocid equals mDoc.ID into pCab_mDoc
                //                from mDoc in pCab_mDoc.DefaultIfEmpty()
                //             join clie in this.DBContext.Cliente
                //               on pCab.pc_clienteid equals clie.ID
                //             join aten in this.DBContext.Atencion
                //                on pCab.pc_atencionid equals aten.ID into pCab_aten
                //                from aten in pCab_aten.DefaultIfEmpty()
                //             join mone in this.DBContext.Moneda
                //               on pCab.pc_monedaid equals mone.ID
                //             join cAre in this.DBContext.ac_areacontabilidad
                //                on pCab.pc_areaid equals cAre.ac_areacontabilidadid into pCab_cAre
                //                from cAre in pCab_cAre.DefaultIfEmpty()
                //             join uApr in this.DBContext.Usuario
                //               on pCab.pc_autorizadopor equals uApr.ID
                //             join uHec in this.DBContext.Usuario
                //               on pCab.pc_enviadopor equals uHec.ID
                //             join Tram in this.DBContext.Tramite
                //               on pCab.pc_tramiteid equals Tram.ID
                //             select new PresupuestoTypeAll
                //             {
                //                 PresupuestoCabID = pCab.pc_presupuestocabid,
                //                 MergeDocID = pCab.pc_mergedocid,
                //                 Serie = mDoc.Serie,
                //                 NroPresupuesto = mDoc.NroPresupuesto,
                //                 ClienteID = pCab.pc_clienteid,
                //                 ClienteNombre = clie.Nombre,
                //                 AtencionID = pCab.pc_atencionid,
                //                 AtencionNombre = aten.Nombre,
                //                 MonedaID = pCab.pc_monedaid,
                //                 MonedaDescrip = mone.Descripcion,
                //                 MonedaAbrev = mone.AbrevMoneda,
                //                 AreaID = pCab.pc_areaid,
                //                 AreaDescrip = cAre.ac_descripcionarea,
                //                 TramiteID = pCab.pc_tramiteid,
                //                 TramiteDescripcion = Tram.Descrip,
                //                 UsuarioHechoPorID = pCab.pc_enviadopor,
                //                 UsuarioHechoPorNombre = uHec.NombrePila,
                //                 UsuarioAprobPorID = pCab.pc_autorizadopor,
                //                 UsuarioAprobPorNombre = uApr.NombrePila,
                //                 FechaGeneracion = pCab.pc_fechageneracion,
                //                 Total = pCab.pc_total,
                //                 Saldo = pCab.pc_saldo,
                //                 ParteNombre = pCab.pc_partenombre,
                //                 ContraParteNombre = pCab.pc_contrapartenombre,
                //                 SerieNroPresupuesto = pCab.pc_nropresupuesto,
                //                 //SerieNroPresupuesto = this.DBContext.ConcatSerieNroPresupuesto(mDoc.Serie, mDoc.NroPresupuesto).FirstOrDefault(),
                //                 Estado = pCab.pc_estado,
                //                 Origen = pCab.pc_origen,
                //                 FacturaNro = pCab.pc_string1,
                //                 TieneAutorizacionVigente = this.DBContext.GetAutorizacionPorDocumentoID(TIPODOCUMENTO_PRESUPUESTO,
                //                                                                                         pCab.pc_presupuestocabid,
                //                                                                                         this.UsuarioID)
                //                                                                                         .FirstOrDefault().Value
                //             });
                #endregion Deprecated

                string filtro = where;
                lPresup.Clear();

                lPresup = (from lista in this.DBContext.GetListaPresupuestos(this.UsuarioID, filtro)
                             select new PresupuestoTypeAll
                             {
                                 PresupuestoCabID = lista.PresupuestoCabID,
                                 MergeDocID = lista.MergeDocID,
                                 Serie = lista.Serie,
                                 NroPresupuesto = lista.NroPresupuesto,
                                 Descripcion = lista.Descripcion,
                                 ClienteID = lista.ClienteID,
                                 ClienteNombre = lista.ClienteNombre,
                                 AtencionID = lista.AtencionID,
                                 AtencionNombre = lista.AtencionNombre,
                                 MonedaID = lista.MonedaID,
                                 MonedaDescrip = lista.MonedaDescrip,
                                 MonedaAbrev = lista.AbrevMoneda,
                                 AreaID = lista.AreaID,
                                 AreaDescrip = lista.AreaDescrip,
                                 TramiteID = lista.TramiteID,
                                 TramiteDescripcion = lista.TramiteDescripcion,
                                 TramiteDF = lista.TramiteDF,
                                 UsuarioHechoPorID = lista.UsuarioHechoPorID,
                                 UsuarioHechoPorNombre = lista.UsuarioHechoPorNombre,
                                 UsuarioAprobPorID = lista.UsuarioAprobPorID,
                                 UsuarioAprobPorNombre = lista.UsuarioAprobPorNombre,
                                 FechaGeneracion = lista.FechaGeneracion,
                                 Total = lista.Total,
                                 Saldo = lista.Saldo,
                                 ParteNombre = lista.ParteNombre,
                                 ContraParteNombre = lista.ContraParteNombre,
                                 SerieNroPresupuesto = lista.SerieNroPresupuesto,
                                 //SerieNroPresupuesto = this.DBContext.ConcatSerieNroPresupuesto(mDoc.Serie, mDoc.NroPresupuesto).FirstOrDefault(),
                                 Estado = lista.Estado,
                                 Origen = lista.Origen,
                                 FacturaNro = lista.FacturaNro,
                                 TieneAutorizacionVigente = this.DBContext.GetAutorizacionPorDocumentoID(TIPODOCUMENTO_PRESUPUESTO,
                                                                                                            lista.PresupuestoCabID,
                                                                                                            this.UsuarioID)
                                                                                                            .FirstOrDefault().Value,
                                 UsuarioGeneracionID = lista.UsuarioGeneracionID,
                                 UsuarioGeneracionNombre = lista.UsuarioGeneracionNombre,
                                 FormaPagoID = lista.FormaPagoID,
                                 FacturaCabID = lista.FacturaCabID,
                                 //Detalle
                                 CotizacionCabID = lista.CotizacionCabID,
                                 ExpedienteID = lista.ExpedienteID,
                                 OrdenTrabajoID = lista.OrdenTrabajoID,
                                 ActaNro = lista.ActaNro,
                                 ActaAnio = lista.ActaAnio,
                                 Acta = lista.Acta,
                                 HINro = lista.HINro,
                                 HIAnio = lista.HIAnio,
                                 HI = lista.HI,
                                 PropietarioMarca = lista.PropietarioMarca,
                                 DenominacionMarca = lista.DenominacionMarca
                             }).ToList();

                //lPresup.Clear();
                //if (where != "")
                //{
                //    //this.BindingSourceBase = query.Where(where, filterParams).OrderByDescending(a => a.PresupuestoCabID).ToList();
                //    lPresup = query.AsQueryable().Where(where, filterParams).OrderByDescending(a => a.PresupuestoCabID).ToList();
                //}
                //else
                //{
                //    //this.BindingSourceBase = query.OrderByDescending(a => a.PresupuestoCabID).Take(50).ToList();
                //    lPresup = query.OrderByDescending(a => a.PresupuestoCabID).Take(50).ToList();
                //}

                this.BindingSourceBase_ExportExcelGrid = lPresup;
                //this.LoadGridExportToExcel();

                var query1 = (from item in lPresup
                              select new PresupuestoTypeCab
                              {
                                  //Cabecera
                                  PresupuestoCabID = item.PresupuestoCabID,
                                  MergeDocID = item.MergeDocID,
                                  Serie = item.Serie,
                                  NroPresupuesto = item.NroPresupuesto,
                                  Descripcion = item.Descripcion,
                                  ClienteID = item.ClienteID,
                                  ClienteNombre = item.ClienteNombre,
                                  AtencionID = item.AtencionID,
                                  AtencionNombre = item.AtencionNombre,
                                  MonedaID = item.MonedaID,
                                  MonedaDescrip = item.MonedaDescrip,
                                  MonedaAbrev = item.MonedaAbrev,
                                  AreaID = item.AreaID,
                                  AreaDescrip = item.AreaDescrip,
                                  TramiteID = item.TramiteID,
                                  TramiteDescripcion = item.TramiteDescripcion,
                                  TramiteDF = item.TramiteDF,
                                  UsuarioHechoPorID = item.UsuarioHechoPorID,
                                  UsuarioHechoPorNombre = item.UsuarioHechoPorNombre,
                                  UsuarioAprobPorID = item.UsuarioAprobPorID,
                                  UsuarioAprobPorNombre = item.UsuarioAprobPorNombre,
                                  FechaGeneracion = item.FechaGeneracion,
                                  Total = item.Total,
                                  Saldo = item.Saldo,
                                  ParteNombre = item.ParteNombre,
                                  ContraParteNombre = item.ContraParteNombre,
                                  SerieNroPresupuesto = item.SerieNroPresupuesto,
                                  Estado = item.Estado,
                                  Origen = item.Origen,
                                  FacturaNro = item.FacturaNro,
                                  TieneAutorizacionVigente = item.TieneAutorizacionVigente,
                                  UsuarioGeneracionID = item.UsuarioGeneracionID,
                                  UsuarioGeneracionNombre = item.UsuarioGeneracionNombre,
                                  FormaPagoID = item.FormaPagoID,
                                  FacturaCabID = item.FacturaCabID
                              })
                              .GroupBy(x => new { x.PresupuestoCabID }).Select(g => g.First()).ToList();

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

            //this.dgvListadoABM.ReadOnly = false;

            foreach (DataGridViewColumn col in this.dgvListadoABM.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            this.dgvListadoABM.ItemsPerPage = 13;
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

            this.dgvListadoABM.Columns[CAMPO_USUARIOGENNOMBRE].HeaderText = "Generado Por";
            this.dgvListadoABM.Columns[CAMPO_USUARIOGENNOMBRE].Width = 180;
            this.dgvListadoABM.Columns[CAMPO_USUARIOGENNOMBRE].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_USUARIOGENNOMBRE].Visible = true;
            displayIndex++;

            //DataGridViewCheckBoxColumn doWork = new DataGridViewCheckBoxColumn();
            //doWork.HeaderText = "Seleccionar";
            //doWork.FalseValue = false;
            //doWork.TrueValue = true;
            //doWork.ReadOnly = false;
            //doWork.Width = 80;
            //doWork.Name = CAMPO_SELECCIONAR;
            //doWork.Visible = false;
            //this.dgvListadoABM.Columns.Insert(0, doWork);
        }
        #endregion Método Extendidos del ParentControl

        #region Controles Locales

        private void dgvExpedientes_CurrentCellChanged(object sender, EventArgs e)
        {
            if ((this.dgvExpedientes.Rows.Count > 0) && (this.dgvExpedientes.CurrentRow != null))
            {
                int CotizacionCabID = (int)((DataGridView)sender).Rows[this.dgvExpedientes.CurrentRow.Index].Cells[CAMPO_COTIZACIONCABID].Value;
                int TramiteID = (int)((DataGridView)sender).Rows[this.dgvExpedientes.CurrentRow.Index].Cells[CAMPO_TRAMITEID].Value;
                this.CargarCotizaciones(CotizacionCabID, TramiteID);
            }
        }

        //private void dgvExpedientes_RowEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    int CotizacionCabID = (int)((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_COTIZACIONCABID].Value;
        //    int TramiteID = (int)((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TRAMITEID].Value;
        //    this.CargarCotizaciones(CotizacionCabID, TramiteID);
        //}

        private void dgvListadoABM_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.limpiarDatos();

            if (this.dgvListadoABM.Rows.Count > 0)
            {
                this.txtPresupID.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_PRESUPUESTOCABID].Value.ToString();
                this.txtMergeDocID.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_MERGEDOCID].Value != null
                                            ? ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_MERGEDOCID].Value.ToString()
                                            : "";

                this.txtNroPresupuesto.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_SERIENROPRESUPUESTO].Value != null
                                                ? ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_SERIENROPRESUPUESTO].Value.ToString()
                                                : "";

                this.txtFacturaNro.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_FACTURANRO].Value != null
                                                ? ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_FACTURANRO].Value.ToString()
                                                : "";

                if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_FACTURACABID].Value != null)
                {
                    this.txtFacturaCabID.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_FACTURACABID].Value.ToString();
                    this.tbbVerFactura.Visible = true;
                }
                else
                {
                    this.txtFacturaCabID.Text = String.Empty;
                    this.tbbVerFactura.Visible = false;
                }

                this.txtEstado.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_ESTADOTEXTO].Value.ToString();
                this.txtFecGeneracion.Text = Convert.ToDateTime(((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_FECHAGENERACION].Value.ToString()).ToShortDateString();
                this.txtTotal.Text = String.Format("{0:0.00}", ((decimal)((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TOTAL].Value));
                this.txtSaldo.Text = String.Format("{0:0.00}",((decimal)((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_SALDO].Value));
                this.txtMonedaAbrev.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_MONEDAABREV].Value.ToString();
                this.txtMonedaDescrip.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_MONEDADESCRIP].Value.ToString();
                this.txtClienteID.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_CLIENTEID].Value.ToString();
                this.txtClienteNombre.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_CLIENTENOMBRE].Value.ToString();
                this.txtGeneradoPorID.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_USUARIOGENID].Value.ToString();
                this.txtGeneradoPorNombre.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_USUARIOGENNOMBRE].Value.ToString();

                if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_ATENCIONID].Value != null)
                {
                    this.txtAtencionID.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_ATENCIONID].Value.ToString();
                    this.txtAtencionNombre.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_ATENCIONOMBRE].Value.ToString();
                }
                
                this.txtTramiteID.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TRAMITEID].Value.ToString();
                this.txtTramiteDescrip.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TRAMITEDESCRIPCION].Value.ToString();
                this.txtTramiteDF.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TRAMITEDF].Value != null ?
                                            ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TRAMITEDF].Value.ToString() :
                                            String.Empty;

                if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_AREAID].Value != null)
                {
                    this.txtAreaID.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_AREAID].Value.ToString();
                    this.txtAreaDescripcion.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_AREADESCRIP].Value.ToString();
                }
                
                this.txtHechoPorID.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_USUARIOHECHOPORID].Value.ToString();
                this.txtHechoPorNombre.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_USUARIOHECHOPORNOMBRE].Value.ToString();
                this.txtAprobPorID.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_USUARIOAPROBPORID].Value.ToString();
                this.txtAprobPorNombre.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_USUARIOAPROBPORNOMBRE].Value.ToString();
                this.txtParteNombre.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_PARTENOMBRE].Value != null
                                            ? ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_PARTENOMBRE].Value.ToString()
                                            : "";
                this.txtContraParteNombre.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_CONTRAPARTENOMBRE].Value != null
                                            ? ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_CONTRAPARTENOMBRE].Value.ToString()
                                            : "";
                this.txtDescripcion.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_DESCRIPCION].Value != null
                                            ? ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_DESCRIPCION].Value.ToString()
                                            : "";

                this.lblAutorizacionVigente.Visible = (bool)((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_AUTORIZACIONVIG].Value;
                this.lblBaja.Visible = (int)((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_FORMPAGOID].Value  == FORMAPAGO_BAJA;

                int PresupuestoCabID = Convert.ToInt32(this.txtPresupID.Text);
                string Origen = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_ORIGEN].Value.ToString();

                this.CargarDetalles(PresupuestoCabID);
                this.CargarExpedientes(PresupuestoCabID, Origen);
            }
        }

        private void ucCRUDPresupuesto_VisibleChanged(object sender, EventArgs e)
        {
            if (this.dgvListadoABM.RowCount > 0)
            {
                this.FormatearGrilla();
                this.FormatearGrillaDetalle();

                if (this.dgvExpedientes.RowCount > 0)
                    this.FormatearGrillaExpedientes();
                
                if (this.dgvCotizaciones.RowCount > 0)
                    this.FormatearGrillaCotizaciones();
            }
        }

        private void tbbAnular_Click(object sender, EventArgs e)
        {

            if (!this.lblAutorizacionVigente.Visible)
            {
                MessageBox.Show("No se puede anular el presupuesto debido a que no posee autorización vigente.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;

            }

            if (this.txtEstado.Text.Split('=')[0].Trim() == ESTADO_ANULADO)
            {
                MessageBox.Show("No se puede anular el presupuesto debido a que ya se encuentra en ese estado.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }


            //Verificar que no existan pagos

            if (this.ExistenPagos(Convert.ToInt32(this.txtPresupID.Text), this.DBContext))
            {
                MessageBox.Show("No se puede anular el presupuesto debido a que ya exisen pagos asociados.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            string message = "";
            string caption = "";
            caption = "Anulación de Presupuestos";
            message = "Se anularán los presupuestos seleccionados ¿Desea continuar?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(AnularDialogHandler));
        }

        private void tbbVerDocumento_Click(object sender, EventArgs e)
        {
            //string[] listaDocs = this.GetMergeDocIDSeleccionados();
            string[] listaDocs = null;
            byte[] binaryFile;

            //string path = VWGContext.Current.Server.MapPath(@VWGContext.Current.Session["PresupFolderURL"].ToString());
            string path = VWGContext.Current.Server.MapPath(@"\Resources\UserData\" + VWGContext.Current.Session["WindowsUser"].ToString() + @"\");

            if (listaDocs != null)
            {
                foreach (string MergeDocID in listaDocs)
                {
                    int mDocID = Convert.ToInt32(MergeDocID);
                    MergeDoc mDoc = this.DBContext.MergeDoc.First(a => a.ID == mDocID);
                    binaryFile = mDoc.Contenido;
                    string extension = mDoc.Extension != null ? mDoc.Extension : ".doc";
                    string fileName = @path + MergeDocID + extension;//".doc";
                    Berke.Libs.Base.Helpers.Files.SaveBytesToFile(binaryFile, @fileName);
                    DownloadGateway download = new DownloadGateway(@fileName);
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
                    string fileName = @path + this.txtMergeDocID.Text + extension;// ".doc";
                    Berke.Libs.Base.Helpers.Files.SaveBytesToFile(binaryFile, @fileName);
                    DownloadGateway download = new DownloadGateway(@fileName);
                    download.StartDownload(this);
                }
            }
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

        private void tabListaABM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabListaABM.SelectedTab == this.tabListaABM.TabPages[0])
            {
                this.tbbAnular.Visible = false;
                this.Sep6.Visible = false;
            }
            else if (this.tabListaABM.SelectedTab == this.tabListaABM.TabPages[2])
            {
                if (this.dgvExpedientes.RowCount > 0)
                {
                    this.dgvExpedientes.CurrentCell = this.dgvExpedientes.Rows[0].Cells[CAMPO_NROPRESUPUESTOCOMP];
                    this.dgvExpedientes.Rows[0].Selected = true;
                    this.dgvExpedientes.Focus();
                }
            }
            else
            {
                this.tbbAnular.Visible = true;
                this.Sep6.Visible = true;
            }
        }
        #endregion Controles Locales

        #region ReadOnly condicional
        protected override void Editable(bool editar)
        {
            //foreach (Control ctrl in this.pnlDetalle.Controls)
            //{
            //    if ((ctrl.GetType() == typeof(TextBox) && ((TextBox)ctrl).Visible))
            //    {
            //        ((TextBox)ctrl).ReadOnly = true;
            //    }
            //}
        }
        #endregion ReadOnly condicional

        #region Limpiar Datos
        private void limpiarDatos()
        {
            foreach (Control ctrl in this.pnlCabPresup.Controls)
            {
                if ((ctrl.GetType() == typeof(TextBox) && ((TextBox)ctrl).Visible))
                {
                    ((TextBox)ctrl).Text = "";
                }
            }
        }
        #endregion Limpiar Datos

        #region Métodos Locales
        private bool ExistenPagos(int PresupuestoCabID, BerkeDBEntities context)
        {
            bool Result = false;
            var query = context.pp_pagopresupuesto.Where(a => a.pp_presupuestocabid == PresupuestoCabID && a.pp_anulado == false);

            if (query.Count() > 0)
                Result = true;

            return Result;

        }

        private void CargarDetalles(int PresupuestoCabID)
        {
            var detalles = (from pDet in this.DBContext.pd_presupuestodetalle
                            select new
                            {
                                PCabID = pDet.pd_presupuestocabid,
                                DetalleDescripcion = pDet.pd_detalledescripcion,
                                DetalleMonto = pDet.pd_detallemonto
                            }).Where(a => a.PCabID == PresupuestoCabID).ToList();

            this.dgvDetPresup.DataSource = detalles;
            this.FormatearGrillaDetalle();
        }

        private void CargarExpedientes(int PresupuestoCabID, string Origen)
        {
            this.dgvExpedientes.DataSource = null;
            this.dgvCotizaciones.DataSource = null;
            #region Trámites de Marcas
            if (Origen == ORIGEN_MARCAS)
            {
                var expedientes = (from cPres in this.DBContext.cp_cotizacionesxpresup
                                   join cCab in this.DBContext.cc_cotizacioncab
                                        on cPres.cp_cotizacionid equals cCab.cc_cotizacioncabid
                                   join expe in this.DBContext.Expediente
                                        on cCab.cc_expedienteid equals expe.ID
                                   join marc in this.DBContext.Marca
                                        on expe.MarcaID equals marc.ID
                                   join mRR in this.DBContext.MarcaRegRen
                                        //on expe.MarcaRegRenID equals mRR.ID
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
                                       PropietarioMarca = marc.Propietario
                                   }).Where(a => a.PresupuestoCabID == PresupuestoCabID).ToList();

                if (expedientes.Count > 0)
                {
                    this.dgvExpedientes.DataSource = expedientes;
                    this.FormatearGrillaExpedientes();
                }
                                        
            }
            #endregion Trámites de Marcas
            #region Otros Trámites
            else if (Origen == ORIGEN_OTROS)
            {
                var expedientes = (from cPres in this.DBContext.cp_cotizacionesxpresup
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
                                       PropietarioMarca = marc.Propietario
                                   }).Where(a => a.PresupuestoCabID == PresupuestoCabID).ToList();

                if (expedientes.Count > 0)
                {
                    this.dgvExpedientes.DataSource = expedientes;
                    this.FormatearGrillaExpedientes();
                }
                
               
            }
            #endregion Otros Trámites
            //this.FormatearGrillaExpedientes();
        }

        private void CargarCotizaciones(int CotizacionCabID, int TramiteID)
        {
            List<RepHojaCotizacion_Result> lista = this.DBContext.RepHojaCotizacion(CotizacionCabID.ToString(),
                                                                                    "A",
                                                                                    TramiteID).ToList();
            this.dgvCotizaciones.DataSource = lista;
            this.FormatearGrillaCotizaciones();
        }

        private void FormatearGrillaDetalle()
        {
            foreach (DataGridViewColumn col in this.dgvDetPresup.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            this.dgvDetPresup.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 10.5F, GraphicsUnit.Pixel);
            this.dgvDetPresup.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dgvDetPresup.DefaultCellStyle.Font = new Font("Arial", 10.5F, GraphicsUnit.Pixel);
            this.dgvDetPresup.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvDetPresup.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            this.dgvDetPresup.ItemsPerPage = 5;
            this.dgvDetPresup.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            int displayIndex = 0;
            this.dgvDetPresup.Columns[CAMPO_DETALLEDESCRIPCION].HeaderText = "Descripción";
            this.dgvDetPresup.Columns[CAMPO_DETALLEDESCRIPCION].Width = 430;
            this.dgvDetPresup.Columns[CAMPO_DETALLEDESCRIPCION].DisplayIndex = displayIndex;
            this.dgvDetPresup.Columns[CAMPO_DETALLEDESCRIPCION].Visible = true;
            displayIndex++;

            this.dgvDetPresup.Columns[CAMPO_DETALLEMONTO].HeaderText = "Monto";
            this.dgvDetPresup.Columns[CAMPO_DETALLEMONTO].Width = 100;
            this.dgvDetPresup.Columns[CAMPO_DETALLEMONTO].DisplayIndex = displayIndex;
            this.dgvDetPresup.Columns[CAMPO_DETALLEMONTO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvDetPresup.Columns[CAMPO_DETALLEMONTO].Visible = true;
            displayIndex++;
        }

        private void FormatearGrillaExpedientes()
        {
            foreach (DataGridViewColumn col in this.dgvExpedientes.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            this.dgvExpedientes.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 10.5F, GraphicsUnit.Pixel);
            this.dgvExpedientes.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dgvExpedientes.DefaultCellStyle.Font = new Font("Arial", 10.5F, GraphicsUnit.Pixel);
            this.dgvExpedientes.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvExpedientes.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            this.dgvExpedientes.ItemsPerPage = 5;
            this.dgvExpedientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            int displayIndex = 0;
            this.dgvExpedientes.Columns[CAMPO_NROPRESUPUESTOCOMP].HeaderText = "N° Presupuesto";
            this.dgvExpedientes.Columns[CAMPO_NROPRESUPUESTOCOMP].Width = 120;
            this.dgvExpedientes.Columns[CAMPO_NROPRESUPUESTOCOMP].DisplayIndex = displayIndex;
            this.dgvExpedientes.Columns[CAMPO_NROPRESUPUESTOCOMP].Visible = true;
            displayIndex++;

            this.dgvExpedientes.Columns[CAMPO_ACTA].HeaderText = "Acta";
            this.dgvExpedientes.Columns[CAMPO_ACTA].Width = 100;
            this.dgvExpedientes.Columns[CAMPO_ACTA].DisplayIndex = displayIndex;
            this.dgvExpedientes.Columns[CAMPO_ACTA].Visible = true;
            displayIndex++;

            this.dgvExpedientes.Columns[CAMPO_HI].HeaderText = "H. de Inicio";
            this.dgvExpedientes.Columns[CAMPO_HI].Width = 100;
            this.dgvExpedientes.Columns[CAMPO_HI].DisplayIndex = displayIndex;
            this.dgvExpedientes.Columns[CAMPO_HI].Visible = true;
            displayIndex++;

            this.dgvExpedientes.Columns[CAMPO_DENOMINACIONMARCA].HeaderText = "Denominación";
            this.dgvExpedientes.Columns[CAMPO_DENOMINACIONMARCA].Width = 300;
            this.dgvExpedientes.Columns[CAMPO_DENOMINACIONMARCA].DisplayIndex = displayIndex;
            this.dgvExpedientes.Columns[CAMPO_DENOMINACIONMARCA].Visible = true;
            displayIndex++;

            this.dgvExpedientes.Columns[CAMPO_PROPIETARIOMARCA].HeaderText = "Propietario";
            this.dgvExpedientes.Columns[CAMPO_PROPIETARIOMARCA].Width = 350;
            this.dgvExpedientes.Columns[CAMPO_PROPIETARIOMARCA].DisplayIndex = displayIndex;
            this.dgvExpedientes.Columns[CAMPO_PROPIETARIOMARCA].Visible = true;
            displayIndex++;

            this.dgvExpedientes.Columns[CAMPO_EXPEDIENTEID].HeaderText = "Expediente ID";
            this.dgvExpedientes.Columns[CAMPO_EXPEDIENTEID].Width = 100;
            this.dgvExpedientes.Columns[CAMPO_EXPEDIENTEID].DisplayIndex = displayIndex;
            this.dgvExpedientes.Columns[CAMPO_EXPEDIENTEID].Visible = true;
            displayIndex++;

            this.dgvExpedientes.Columns[CAMPO_COTIZACIONCABID].HeaderText = "Cotización ID";
            this.dgvExpedientes.Columns[CAMPO_COTIZACIONCABID].Width = 120;
            this.dgvExpedientes.Columns[CAMPO_COTIZACIONCABID].DisplayIndex = displayIndex;
            this.dgvExpedientes.Columns[CAMPO_COTIZACIONCABID].Visible = true;
            displayIndex++;
        }

        private void FormatearGrillaCotizaciones()
        {
            foreach (DataGridViewColumn col in this.dgvCotizaciones.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            this.dgvCotizaciones.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 10.5F, GraphicsUnit.Pixel);
            this.dgvCotizaciones.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dgvCotizaciones.DefaultCellStyle.Font = new Font("Arial", 10.5F, GraphicsUnit.Pixel);
            this.dgvCotizaciones.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvCotizaciones.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            this.dgvCotizaciones.ItemsPerPage = 5;
            this.dgvCotizaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            int displayIndex = 0;
            this.dgvCotizaciones.Columns[CAMPO_TARIFADESCRIPCION].HeaderText = "Tarifa";
            this.dgvCotizaciones.Columns[CAMPO_TARIFADESCRIPCION].Width = 300;
            this.dgvCotizaciones.Columns[CAMPO_TARIFADESCRIPCION].DisplayIndex = displayIndex;
            this.dgvCotizaciones.Columns[CAMPO_TARIFADESCRIPCION].Visible = true;
            displayIndex++;

            this.dgvCotizaciones.Columns[CAMPO_ABREVMONEDA].HeaderText = "Moneda";
            this.dgvCotizaciones.Columns[CAMPO_ABREVMONEDA].Width = 70;
            this.dgvCotizaciones.Columns[CAMPO_ABREVMONEDA].DisplayIndex = displayIndex;
            //this.dgvCotizaciones.Columns[CAMPO_ABREVMONEDA].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvCotizaciones.Columns[CAMPO_ABREVMONEDA].Visible = true;
            displayIndex++;

            this.dgvCotizaciones.Columns[CAMPO_CANTIDAD].HeaderText = "Cantidad";
            this.dgvCotizaciones.Columns[CAMPO_CANTIDAD].Width = 70;
            this.dgvCotizaciones.Columns[CAMPO_CANTIDAD].DisplayIndex = displayIndex;
            this.dgvCotizaciones.Columns[CAMPO_CANTIDAD].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvCotizaciones.Columns[CAMPO_CANTIDAD].Visible = true;
            displayIndex++;

            this.dgvCotizaciones.Columns[CAMPO_PRECIOUNITARIO].HeaderText = "Pr. Unit.";
            this.dgvCotizaciones.Columns[CAMPO_PRECIOUNITARIO].Width = 70;
            this.dgvCotizaciones.Columns[CAMPO_PRECIOUNITARIO].DisplayIndex = displayIndex;
            this.dgvCotizaciones.Columns[CAMPO_PRECIOUNITARIO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvCotizaciones.Columns[CAMPO_PRECIOUNITARIO].Visible = true;
            displayIndex++;

            this.dgvCotizaciones.Columns[CAMPO_DESCUENTO].HeaderText = "Descuento";
            this.dgvCotizaciones.Columns[CAMPO_DESCUENTO].Width = 70;
            this.dgvCotizaciones.Columns[CAMPO_DESCUENTO].DisplayIndex = displayIndex;
            this.dgvCotizaciones.Columns[CAMPO_DESCUENTO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvCotizaciones.Columns[CAMPO_DESCUENTO].Visible = true;
            displayIndex++;

            this.dgvCotizaciones.Columns[CAMPO_NETO].HeaderText = "Neto";
            this.dgvCotizaciones.Columns[CAMPO_NETO].Width = 70;
            this.dgvCotizaciones.Columns[CAMPO_NETO].DisplayIndex = displayIndex;
            this.dgvCotizaciones.Columns[CAMPO_NETO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvCotizaciones.Columns[CAMPO_NETO].Visible = true;
            displayIndex++;

            this.dgvCotizaciones.Columns[CAMPO_GASTO].HeaderText = "Gasto";
            this.dgvCotizaciones.Columns[CAMPO_GASTO].Width = 70;
            this.dgvCotizaciones.Columns[CAMPO_GASTO].DisplayIndex = displayIndex;
            this.dgvCotizaciones.Columns[CAMPO_GASTO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvCotizaciones.Columns[CAMPO_GASTO].Visible = true;
            displayIndex++;

            this.dgvCotizaciones.Columns[CAMPO_RECARGO].HeaderText = "Recargo";
            this.dgvCotizaciones.Columns[CAMPO_RECARGO].Width = 70;
            this.dgvCotizaciones.Columns[CAMPO_RECARGO].DisplayIndex = displayIndex;
            this.dgvCotizaciones.Columns[CAMPO_RECARGO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvCotizaciones.Columns[CAMPO_RECARGO].Visible = true;
            displayIndex++;

            this.dgvCotizaciones.Columns[CAMPO_IMPUESTO].HeaderText = "Impuesto";
            this.dgvCotizaciones.Columns[CAMPO_IMPUESTO].Width = 70;
            this.dgvCotizaciones.Columns[CAMPO_IMPUESTO].DisplayIndex = displayIndex;
            this.dgvCotizaciones.Columns[CAMPO_IMPUESTO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvCotizaciones.Columns[CAMPO_IMPUESTO].Visible = true;
            displayIndex++;

            this.dgvCotizaciones.Columns[CAMPO_TOTAL].HeaderText = "Total";
            this.dgvCotizaciones.Columns[CAMPO_TOTAL].Width = 80;
            this.dgvCotizaciones.Columns[CAMPO_TOTAL].DisplayIndex = displayIndex;
            this.dgvCotizaciones.Columns[CAMPO_TOTAL].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvCotizaciones.Columns[CAMPO_TOTAL].Visible = true;
            displayIndex++;
        }

        private void AnularDialogHandler(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    this.AnularPresupuesto();
                }
            }
        }

        private void AnularPresupuesto()
        {
            bool success = false;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        int presupuestoCabID = Convert.ToInt32(this.txtPresupID.Text);
                        
                        pc_presupuestocab pCab = context.pc_presupuestocab.First(a => a.pc_presupuestocabid == presupuestoCabID);
                        pCab.pc_estado = ESTADO_ANULADO;
                        pCab.pc_fechaanulacion = System.DateTime.Now;

                        foreach (pm_pcabxmergeexpe pCabXmExp in context.pm_pcabxmergeexpe.Where(a => a.pm_presupuestocabid == presupuestoCabID).ToList())
                        {
                            int MergeExpedienteID = pCabXmExp.pm_mergeexpedienteid;
                            Merge_Expediente mExp = context.Merge_Expediente.First(a => a.ID == MergeExpedienteID);
                            mExp.Anulado = true;
                            mExp.Generado = false;
                        }


                        //int mergeDocID = Convert.ToInt32(this.txtMergeDocID.Text);
                        int mergeDocID;
                        if (Int32.TryParse(this.txtMergeDocID.Text, out mergeDocID))
                        {
                            MergeDoc mDoc = context.MergeDoc.First(a => a.ID == mergeDocID);
                            mDoc.Anulado = true;
                            mDoc.FechaAnulacion = pCab.pc_fechaanulacion;
                        }

                        //context.Merge_Expediente.Where(a => a.MergeDocID == mergeDocID).ToList().ForEach(b => b.Anulado = true);

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
                this.FilterEntity(this.WhereString, this.FilterParam);

                MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private string[] GetMergeDocIDSeleccionados()
        {
            string Result = "";
            if (this.dgvListadoABM.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in this.dgvListadoABM.Rows)
                {
                    if ((row.Cells[CAMPO_SELECCIONAR].Value != null) && ((bool)(row.Cells[CAMPO_SELECCIONAR].Value))
                        && (row.Cells[CAMPO_ESTADO].Value != null) && ((row.Cells[CAMPO_ESTADO].Value).ToString() != ESTADO_ANULADO))
                    {
                        Result += Result != "" ? "," : "";
                        Result += row.Cells[CAMPO_MERGEDOCID].Value.ToString();
                    }
                }
            }

            if (Result != "")
                return Result.Split(',');
            else
                return null;
        }
        #endregion Métodos Locales        

        private void tbbVerFactura_Click(object sender, EventArgs e)
        {
            this.ImprimirFacturaDigital();
        }

        private string EvaluarCero(string valor)
        {
            return ((valor == CERO_CON_DECIMALES) || (valor == CERO_SIN_DECIMALES)) ? string.Empty : valor;
        }

        private List<ImprimirFacturaType> GenerarDatosFacturaDigital(int fCabID)
        {
            List<ImprimirFacturaType> listaDatosFactura = new List<ImprimirFacturaType>();

            var qry = (from fc in this.DBContext.fc_facturacabecera
                      join fd in this.DBContext.fd_facturadetalle
                        on fc.fc_facturacabeceraid equals fd.fd_facturacabeceraid
                      join mo in this.DBContext.Moneda
                        on fc.fc_monedaid equals mo.ID
                      join ti in this.DBContext.ti_timbrado
                        on fc.fc_timbradoid equals ti.ti_timbradoid
                      select new
                      {
                          FechaFactura = fc.fc_fechafactura,
                          ClienteNombre = fc.fc_clientenombre,
                          TipoFactura = fc.fc_tipofactura,
                          RUC = fc.fc_ruc,
                          NroRemision = fc.fc_nroremision,
                          Direccion = fc.fc_direccion,
                          Telefono = fc.fc_telefono,
                          Descripcion = fd.fd_descripcion,
                          MonedaAbrev = mo.AbrevMoneda,
                          MonedaDescrip = mo.Descripcion,
                          NroTimbrado = ti.ti_nrotimbrado,
                          VigenciaInicio = ti.ti_vigenciadesde,
                          VigenciaFin = ti.ti_vigenciahasta,
                          NroFactura = fc.fc_nrofactura,
                          Anulado = fc.fc_anulado,
                          Cantidad = fd.fd_cantidad,
                          PrecioUnitario = fd.fd_preciounitario,
                          Exentas = fd.fd_exentas,
                          CincoPorCiento = fd.fd_cincoporciento,
                          DiezPorCiento = fd.fd_diezporciento,
                          TotalExentas = fc.fc_totalexentas,
                          TotalCincoPorCiento = fc.fc_totaliva5,
                          TotalDiezPorCiento = fc.fc_totaliva10,
                          TotalFactura = fc.fc_total,
                          TotalLetras = fc.fc_totalletras,
                          LiqIVA5 = fc.fc_liqiva5,
                          LiqIVA10 = fc.fc_liqiva10,
                          LiqIVATotal = fc.fc_totaliva,
                          FacturaCabID = fc.fc_facturacabeceraid
                      })
                        .Where(a => a.FacturaCabID == fCabID)
                        .ToList();

            string formatoNumero = qry.First().MonedaDescrip == GUARANIES ? FORMATO_MONEDA_GUARANIES : FORMATO_MONEDA_OTROS;

            for (int i = 0; i < qry.Count; i++)
            {
                ImprimirFacturaType datosFactura = new ImprimirFacturaType();
                datosFactura.FechaFactura = qry[i].FechaFactura.ToShortDateString();
                datosFactura.ClienteNombre = qry[i].ClienteNombre;
                datosFactura.FacturaContado = qry[i].TipoFactura == FACTURA_CONTADO ? "X" : String.Empty;
                datosFactura.FacturaCredito = qry[i].TipoFactura == FACTURA_CREDITO ? "X" : String.Empty;
                datosFactura.RUC = qry[i].RUC;
                datosFactura.NroRemision = qry[i].NroRemision;
                datosFactura.Direccion = qry[i].Direccion;
                datosFactura.Telefono = qry[i].Telefono;
                datosFactura.Descripcion = qry[i].Descripcion;
                datosFactura.MonedaAbrev = qry[i].MonedaAbrev;
                datosFactura.NroTimbrado = qry[i].NroTimbrado.Value.ToString();
                datosFactura.VigenciaInicio = qry[i].VigenciaInicio.ToShortDateString();
                datosFactura.VigenciaFin = qry[i].VigenciaFin.ToShortDateString();
                datosFactura.NroFactura = qry[i].NroFactura;
                datosFactura.Anulado = qry[i].Anulado;

                datosFactura.Cantidad = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(qry[i].Cantidad))));
                datosFactura.PrecioUnitario = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(qry[i].PrecioUnitario))));
                datosFactura.Exentas = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(qry[i].Exentas))));
                datosFactura.CincoPorciento = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(qry[i].CincoPorCiento))));
                datosFactura.DiezPorciento = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(qry[i].DiezPorCiento))));

                //if (qry.First().MonedaDescrip == GUARANIES)
                //{
                //    datosFactura.Cantidad = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(qry[i].Cantidad))));
                //    datosFactura.PrecioUnitario = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(qry[i].PrecioUnitario))));
                //    datosFactura.Exentas = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(qry[i].Exentas))));
                //    datosFactura.CincoPorciento = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(qry[i].CincoPorCiento))));
                //    datosFactura.DiezPorciento = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(qry[i].DiezPorCiento))));
                //}
                //else
                //{
                //    datosFactura.Cantidad = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(qry[i].Cantidad))));
                //    datosFactura.PrecioUnitario = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(qry[i].PrecioUnitario))));
                //    datosFactura.Exentas = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(qry[i].Exentas))));
                //    datosFactura.CincoPorciento = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(qry[i].CincoPorCiento))));
                //    datosFactura.DiezPorciento = this.EvaluarCero(String.Format(formatoNumero, (decimal.Round(qry[i].DiezPorCiento))));
                //    //datosFactura.Cantidad = this.EvaluarCero(String.Format(formatoNumero, (Convert.ToDecimal(row.Cells[CAMPO_CANTIDAD].Value.ToString()))));
                //    //datosFactura.PrecioUnitario = this.EvaluarCero(String.Format(formatoNumero, (Convert.ToDecimal(row.Cells[CAMPO_PRECIOUNITARIO].Value.ToString()))));
                //    //datosFactura.Exentas = this.EvaluarCero(String.Format(formatoNumero, (Convert.ToDecimal(row.Cells[CAMPO_EXENTAS].Value.ToString()))));
                //    //datosFactura.CincoPorciento = this.EvaluarCero(String.Format(formatoNumero, (Convert.ToDecimal(row.Cells[CAMPO_CINCOPORCIENTO].Value.ToString()))));
                //    //datosFactura.DiezPorciento = this.EvaluarCero(String.Format(formatoNumero, (Convert.ToDecimal(row.Cells[CAMPO_DIEZPORCIENTO].Value.ToString()))));
                //}

                datosFactura.TotalExentas = this.EvaluarCero(String.Format(formatoNumero, decimal.Round(qry[i].TotalExentas)));
                datosFactura.TotalCincoPorciento = this.EvaluarCero(String.Format(formatoNumero, decimal.Round(qry[i].TotalCincoPorCiento)));
                datosFactura.TotalDiezPorciento = this.EvaluarCero(String.Format(formatoNumero, decimal.Round(qry[i].TotalDiezPorCiento)));
                datosFactura.TotalFactura = this.EvaluarCero(String.Format(formatoNumero, decimal.Round(qry[i].TotalFactura)));
                datosFactura.TotalLetras = qry[i].TotalLetras;
                datosFactura.LiqIVA5 = this.EvaluarCero(String.Format(formatoNumero, decimal.Round(qry[i].LiqIVA5)));
                datosFactura.LiqIVA10 = this.EvaluarCero(String.Format(formatoNumero, decimal.Round(qry[i].LiqIVA10)));
                datosFactura.LiqIVATotal = this.EvaluarCero(String.Format(formatoNumero, decimal.Round(qry[i].LiqIVATotal)));
                listaDatosFactura.Add(datosFactura);
            }
            return listaDatosFactura;
        }

        private void ImprimirFacturaDigital()
        {
            ReportDataSource datasource = null;
            datasource = new ReportDataSource("DataSet1", this.GenerarDatosFacturaDigital(Convert.ToInt32(this.txtFacturaCabID.Text)));

            string path = @"Reportes\Factura-Digital.rdlc";

            FReportViewerBase f = new FReportViewerBase(path, datasource, this.DBContext, String.Empty, false, true);
            f.FormClosed += delegate { f = null; };
            f.SoloPDF(true);
            f.Titulo = "Factura N° " + this.txtFacturaNro.Text;
            f.NombreArchivoAdjunto = "Factura";
            f.AsuntoMail = "Factura";
            f.CuerpoMail = "Factura";
            f.ShowDialog();
        }
    }


}