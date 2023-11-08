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

#endregion

namespace SPF.UserControls.UI
{
    public partial class ucConsultaCotizacionesPorTramite : ucBaseForm
    {
        #region Constantes
        private const string CAMPO_COTIZACIONCABID = "CotizacionCabID";
        private const string CAMPO_FECHACOTIZACION = "FechaCotizacion";
        private const string CAMPO_USUARIOCOTIZACION = "UsuarioCotizacion";
        private const string CAMPO_CONFIRMADO = "Confirmado";
        private const string CAMPO_FECHACONFIRMACION = "FechaConfirmacion";
        private const string CAMPO_USUARIOCONFIRMACION = "UsuarioConfirmacion";
        private const string CAMPO_CLIENTEID = "ClienteID";
        private const string CAMPO_CLIENTENOMBRE = "ClienteNombre";
        private const string CAMPO_TRAMITEID = "TramiteID";
        private const string CAMPO_TRAMITEDESCRIPCION = "TramiteDescripcion";
        private const string CAMPO_MONEDAID = "MonedaID";
        private const string CAMPO_MONEDADESCRIP = "MonedaDescrip";
        private const string CAMPO_MONEDAABREV = "MonedaAbrev";
        private const string CAMPO_TOTALCOTIZACION = "TotalCotizacion";
        private const string CAMPO_FECHACOTIZACIONDATE = "FechaCotizacionDate";
        private const string CAMPO_CONFIRMADOVAL = "ConfirmadoVal";
        private const string CAMPO_FECHACONFIRMACIONDATE = "FechaConfirmacionDate";
        private const string CAMPO_PRESUPUESTOCABID = "PresupuestoCabID";
        private const string CAMPO_NRODOCUMENTO = "NroDocumento";
        private const string CAMPO_ORIGENEXPEDIENTE = "OrigenExpediente";
        private const string CAMPO_EXPEDIENTEID = "ExpedienteID";
        private const string CAMPO_ACTA = "Acta";
        private const string CAMPO_ACTANRO = "ActaNro";
        private const string CAMPO_ACTAANIO = "ActaAnio";
        private const string CAMPO_HI = "HI";
        private const string CAMPO_HINRO = "HINro";
        private const string CAMPO_HIANIO = "HIAnio";
        private const string CAMPO_OBSCOTIZACION = "ObsCotizacion";
        private const string FORMATO_DECIMAL_BROWSE = "{0:N2}";

        private const string CAMPO_DENOMINACION = "Denominacion";
        private const string CAMPO_TARIFADESCRIPCION = "TarifaDescripcion";
        private const string CAMPO_CANTIDAD = "Cantidad";
        private const string CAMPO_PRECIOUNITARIO = "PrecioUnitario";
        private const string CAMPO_DESCUENTO = "Descuento";
        private const string CAMPO_NETO = "Neto";
        private const string CAMPO_GASTO = "Gasto";
        private const string CAMPO_RECARGO = "Recargo";
        private const string CAMPO_IMPUESTO = "Impuesto";
        private const string CAMPO_ABREVMONEDA = "AbrevMoneda";
        private const string CAMPO_NROPRESUPUESTOCOMP = "NroPresupuestoCompuesto";
        private const string CAMPO_TOTAL = "Total";

        private const string CAMPO_COTIZACIONCABIDANTECEDENTE = "CotizacionCabIDAntecedente";
        private const string CAMPO_CLIENTEIDANTECEDENTE = "ClienteIDAntecedente";
        private const string CAMPO_FECHAANTECEDENTE = "FechaAntecedente";
        private const string CAMPO_ANTECEDENTEID = "AntecedenteID";
        private const string CAMPO_TIPOANTECEDENTEID = "TipoAntecedenteID";
        private const string CAMPO_TIPOANTECEDENTENOMBRE = "TipoAntecedenteNombre";
        private const string CAMPO_TARIFARIOID = "TarifarioID";
        private const string CAMPO_OBSERVACIONANTECEDENTE = "ObservacionAntecedente";
        private const string CAMPO_TIPOANTECEDENTELOCAL = "TipoAntecedenteLocal";
        private const string CAMPO_USUARIOENVIAIDANTECEDENTE = "UsuarioEnviaIDAntecedente";
        private const string CAMPO_USUARIOENVIAANTECEDENTE = "UsuarioEnviaAntecedente";
        private const string CAMPO_USUARIOAUTORIZAIDANTECEDENTE = "UsuarioAutorizaIDAntecedente";
        private const string CAMPO_USUARIOAUTORIZANOMBRE = "UsuarioAutorizaNombre";
        private const string CAMPO_TRAMITEIDANTECEDENTE = "TramiteIDAntecedente	";
        private const string CAMPO_TRAMITEDESCRIPANTECEDENTE = "TramiteDescripAntecedente";
        private const string CAMPO_ACTANROANTECEDENTE = "ActaNroAntecedente";
        private const string CAMPO_ACTAANIOANTECEDENTE = "ActaAnioAntecedente";
        private const string CAMPO_REGISTRONROANTECEDENTE = "RegistroNroAntecedente";
        #endregion Constantes

        #region Variables Globales
        int UsuarioID = -1;
        List<ConsultaCotizacionesAll> lCotizaciones;
        #endregion Variables Globales

        #region Método de Inicio
        public ucConsultaCotizacionesPorTramite()
        {
            InitializeComponent();
        }

        public ucConsultaCotizacionesPorTramite(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();
            this.DBContext = dbContext;
            this.Titulo = Titulo;
            this.TituloDetalle = "Cotización";
            this.UseSQLSyntax = true;

            #region Ocultar botones que no se usan
            this.tbbNuevo.Visible = false;
            this.tbbEditar.Visible = false;
            this.tbbGuardar.Visible = false;
            this.tbbImprimir.Visible = false;
            this.tbbCancelar.Visible = false;
            this.tbbBorrar.Visible = false;
            this.tbbUpdDocs.Visible = false;
            this.tbbAnular.Visible = false;
            #endregion Ocultar botones que no se usan

            lCotizaciones = (from lista in this.DBContext.GetListadoCotizacionesConsulta(String.Empty)
                             select new ConsultaCotizacionesAll
                             {
                                  FechaCotizacionDate = lista.FechaCotizacionDate,
                                  FechaCotizacion = lista.FechaCotizacion,
                                  CotizacionCabID = lista.CotizacionCabID,
                                  UsuarioCotizacion = lista.UsuarioCotizacion,
                                  Confirmado = lista.Confirmado,
                                  FechaConfirmacion = lista.FechaConfirmacion,
                                  UsuarioConfirmacion = lista.UsuarioConfirmacion,
                                  ClienteID = lista.ClienteID,
                                  ClienteNombre = lista.ClienteNombre,
                                  TramiteID = lista.TramiteID,
                                  TramiteDescripcion = lista.TramiteDescripcion,
                                  MonedaID = lista.MonedaID,
                                  MonedaDescrip = lista.MonedaDescrip,
                                  MonedaAbrev = lista.MonedaAbrev,
                                  TotalCotizacion = lista.TotalCotizacion,
                                  ConfirmadoVal = lista.ConfirmadoVal,
                                  FechaConfirmacionDate = lista.FechaConfirmacionDate,
                                  PresupuestoCabID = lista.PresupuestoCabID,
                                  NroDocumento = lista.NroDocumento,
                                  OrigenExpediente = lista.OrigenExpediente,
                                  ExpedienteID = lista.ExpedienteID,
                                  Acta = lista.Acta,
                                  ActaNro = lista.ActaNro,
                                  ActaAnio = lista.ActaAnio,
                                  HI = lista.HI,
                                  HINro = lista.HINro,
                                  HIAnio = lista.HIAnio,
                                  ObsCotizacion = lista.ObsCotizacion,
                                  CotizacionCabIDAntecedente = lista.CotizacionCabIDAntecedente,
                                  ClienteIDAntecedente = lista.ClienteIDAntecedente,
                                  FechaAntecedente = lista.FechaAntecedente,
                                  AntecedenteID = lista.AntecedenteID,
                                  TipoAntecedenteID = lista.TipoAntecedenteID,
                                  TipoAntecedenteNombre = lista.TipoAntecedenteNombre,
                                  TarifarioID = lista.TarifarioID,
                                  ObservacionAntecedente = lista.ObservacionAntecedente,
                                  TipoAntecedenteLocal = lista.TipoAntecedenteLocal,
                                  UsuarioEnviaIDAntecedente = lista.UsuarioAutorizaIDAntecedente,
                                  UsuarioEnviaAntecedente = lista.UsuarioEnviaAntecedente,
                                  UsuarioAutorizaIDAntecedente = lista.UsuarioAutorizaIDAntecedente,
                                  UsuarioAutorizaNombre = lista.UsuarioAutorizaNombre,
                                  TramiteIDAntecedente = lista.TramiteIDAntecedente,
                                  TramiteDescripAntecedente = lista.TramiteDescripAntecedente,
                                  ActaNroAntecedente = lista.ActaNroAntecedente,
                                  ActaAnioAntecedente = lista.ActaAnioAntecedente,
                                  RegistroNroAntecedente = lista.RegistroNroAntecedente
                          })
                          .ToList();


            this.BindingSourceBase_ExportExcelGrid = lCotizaciones;

            var query = (from item in lCotizaciones
                         select new ConsultaCotizacionesCab
                         {
                             //Cabecera
                              FechaCotizacionDate = item.FechaCotizacionDate,
                              FechaCotizacion = item.FechaCotizacion,
                              CotizacionCabID = item.CotizacionCabID,
                              UsuarioCotizacion = item.UsuarioCotizacion,
                              Confirmado = item.Confirmado,
                              FechaConfirmacion = item.FechaConfirmacion,
                              UsuarioConfirmacion = item.UsuarioConfirmacion,
                              ClienteID = item.ClienteID,
                              ClienteNombre = item.ClienteNombre,
                              TramiteID = item.TramiteID,
                              TramiteDescripcion = item.TramiteDescripcion,
                              MonedaID = item.MonedaID,
                              MonedaDescrip = item.MonedaDescrip,
                              MonedaAbrev = item.MonedaAbrev,
                              TotalCotizacion = item.TotalCotizacion,
                              ConfirmadoVal = item.ConfirmadoVal,
                              FechaConfirmacionDate = item.FechaConfirmacionDate,
                              PresupuestoCabID = item.PresupuestoCabID,
                              NroDocumento = item.NroDocumento,
                              OrigenExpediente = item.OrigenExpediente,
                              ExpedienteID = item.ExpedienteID,
                              Acta = item.Acta,
                              ActaNro = item.ActaNro,
                              ActaAnio = item.ActaAnio,
                              HI = item.HI,
                              HINro = item.HINro,
                              HIAnio = item.HIAnio,
                              ObsCotizacion = item.ObsCotizacion
                          })
                          .GroupBy(x => new { x.CotizacionCabID }).Select(g => g.First()).ToList();


            this.BindingSourceBase = query;

            #region Especificar campos para filtro
            this.SetFilter(CAMPO_COTIZACIONCABID, "Cotiz. ID", false);
            this.SetFilter(CAMPO_FECHACOTIZACIONDATE, "Fec. Cotiz.");
            this.SetFilter(CAMPO_CONFIRMADOVAL, "Confirmado (S/N)", false);
            this.SetFilter(CAMPO_CLIENTEID, "Cliente ID", false);
            this.SetFilter(CAMPO_CLIENTENOMBRE, "Cliente Nombre");
            this.SetFilter(CAMPO_TRAMITEID, "Trámite ID", false);
            this.SetFilter(CAMPO_TRAMITEDESCRIPCION, "Trámite Descrip.");
            this.SetFilter(CAMPO_MONEDAABREV, "Moneda");
            this.SetFilter(CAMPO_TOTALCOTIZACION, "Total Cotiz.", false);
            this.SetFilter(CAMPO_NRODOCUMENTO, "N° Documento");
            this.SetFilter(CAMPO_OBSCOTIZACION, "Obs. Cotiz.");
            this.TituloBuscador = "Buscar Cotizaciones por Trámite";
            #endregion Especificar campos para filtro
        }

        #endregion Método de Inicio

        #region Método Extendidos del ParentControl
        protected override void FilterEntity(string where = "", object[] filterParams = null)
        {
            try
            {
                this.limpiarDatos();

                string filtro = where;

                #region Deprecated
                //var query = (from lista in this.DBContext.GetListadoCotizacionesConsulta1(filtro)
                //             select new
                //             {
                //                 FechaCotizacionDate = lista.FechaCotizacionDate,
                //                 FechaCotizacion = lista.FechaCotizacion,
                //                 CotizacionCabID = lista.CotizacionCabID,
                //                 UsuarioCotizacion = lista.UsuarioCotizacion,
                //                 Confirmado = lista.Confirmado,
                //                 FechaConfirmacion = lista.FechaConfirmacion,
                //                 UsuarioConfirmacion = lista.UsuarioConfirmacion,
                //                 ClienteID = lista.ClienteID,
                //                 ClienteNombre = lista.ClienteNombre,
                //                 TramiteID = lista.TramiteID,
                //                 TramiteDescripcion = lista.TramiteDescripcion,
                //                 MonedaID = lista.MonedaID,
                //                 MonedaDescrip = lista.MonedaDescrip,
                //                 MonedaAbrev = lista.MonedaAbrev,
                //                 TotalCotizacion = lista.TotalCotizacion,
                //                 ConfirmadoVal = lista.ConfirmadoVal,
                //                 FechaConfirmacionDate = lista.FechaConfirmacionDate,
                //                 PresupuestoCabID = lista.PresupuestoCabID,
                //                 NroDocumento = lista.NroDocumento,
                //                 OrigenExpediente = lista.OrigenExpediente,
                //                 ExpedienteID = lista.ExpedienteID,
                //                 Acta = lista.Acta,
                //                 ActaNro = lista.ActaNro,
                //                 ActaAnio = lista.ActaAnio,
                //                 HI = lista.HI,
                //                 HINro = lista.HINro,
                //                 HIAnio = lista.HIAnio,
                //                 ObsCotizacion = lista.ObsCotizacion
                //             })
                //          .ToList();

                //this.BindingSourceBase_ExportExcelGrid = query;
                //this.BindingSourceBase = query;
                #endregion Deprecated

                lCotizaciones.Clear();

                lCotizaciones = (from lista in this.DBContext.GetListadoCotizacionesConsulta(filtro)
                                 select new ConsultaCotizacionesAll
                                 {
                                     FechaCotizacionDate = lista.FechaCotizacionDate,
                                     FechaCotizacion = lista.FechaCotizacion,
                                     CotizacionCabID = lista.CotizacionCabID,
                                     UsuarioCotizacion = lista.UsuarioCotizacion,
                                     Confirmado = lista.Confirmado,
                                     FechaConfirmacion = lista.FechaConfirmacion,
                                     UsuarioConfirmacion = lista.UsuarioConfirmacion,
                                     ClienteID = lista.ClienteID,
                                     ClienteNombre = lista.ClienteNombre,
                                     TramiteID = lista.TramiteID,
                                     TramiteDescripcion = lista.TramiteDescripcion,
                                     MonedaID = lista.MonedaID,
                                     MonedaDescrip = lista.MonedaDescrip,
                                     MonedaAbrev = lista.MonedaAbrev,
                                     TotalCotizacion = lista.TotalCotizacion,
                                     ConfirmadoVal = lista.ConfirmadoVal,
                                     FechaConfirmacionDate = lista.FechaConfirmacionDate,
                                     PresupuestoCabID = lista.PresupuestoCabID,
                                     NroDocumento = lista.NroDocumento,
                                     OrigenExpediente = lista.OrigenExpediente,
                                     ExpedienteID = lista.ExpedienteID,
                                     Acta = lista.Acta,
                                     ActaNro = lista.ActaNro,
                                     ActaAnio = lista.ActaAnio,
                                     HI = lista.HI,
                                     HINro = lista.HINro,
                                     HIAnio = lista.HIAnio,
                                     ObsCotizacion = lista.ObsCotizacion,
                                     //Antecedentes
                                     CotizacionCabIDAntecedente = lista.CotizacionCabIDAntecedente,
                                     ClienteIDAntecedente = lista.ClienteIDAntecedente,
                                     FechaAntecedente = lista.FechaAntecedente,
                                     AntecedenteID = lista.AntecedenteID,
                                     TipoAntecedenteID = lista.TipoAntecedenteID,
                                     TipoAntecedenteNombre = lista.TipoAntecedenteNombre,
                                     TarifarioID = lista.TarifarioID,
                                     ObservacionAntecedente = lista.ObservacionAntecedente,
                                     TipoAntecedenteLocal = lista.TipoAntecedenteLocal,
                                     UsuarioEnviaIDAntecedente = lista.UsuarioAutorizaIDAntecedente,
                                     UsuarioEnviaAntecedente = lista.UsuarioEnviaAntecedente,
                                     UsuarioAutorizaIDAntecedente = lista.UsuarioAutorizaIDAntecedente,
                                     UsuarioAutorizaNombre = lista.UsuarioAutorizaNombre,
                                     TramiteIDAntecedente = lista.TramiteIDAntecedente,
                                     TramiteDescripAntecedente = lista.TramiteDescripAntecedente,
                                     ActaNroAntecedente = lista.ActaNroAntecedente,
                                     ActaAnioAntecedente = lista.ActaAnioAntecedente,
                                     RegistroNroAntecedente = lista.RegistroNroAntecedente
                                 })
                          .ToList();


                this.BindingSourceBase_ExportExcelGrid = lCotizaciones;

                var query = (from item in lCotizaciones
                             select new ConsultaCotizacionesCab
                             {
                                 //Cabecera
                                 FechaCotizacionDate = item.FechaCotizacionDate,
                                 FechaCotizacion = item.FechaCotizacion,
                                 CotizacionCabID = item.CotizacionCabID,
                                 UsuarioCotizacion = item.UsuarioCotizacion,
                                 Confirmado = item.Confirmado,
                                 FechaConfirmacion = item.FechaConfirmacion,
                                 UsuarioConfirmacion = item.UsuarioConfirmacion,
                                 ClienteID = item.ClienteID,
                                 ClienteNombre = item.ClienteNombre,
                                 TramiteID = item.TramiteID,
                                 TramiteDescripcion = item.TramiteDescripcion,
                                 MonedaID = item.MonedaID,
                                 MonedaDescrip = item.MonedaDescrip,
                                 MonedaAbrev = item.MonedaAbrev,
                                 TotalCotizacion = item.TotalCotizacion,
                                 ConfirmadoVal = item.ConfirmadoVal,
                                 FechaConfirmacionDate = item.FechaConfirmacionDate,
                                 PresupuestoCabID = item.PresupuestoCabID,
                                 NroDocumento = item.NroDocumento,
                                 OrigenExpediente = item.OrigenExpediente,
                                 ExpedienteID = item.ExpedienteID,
                                 Acta = item.Acta,
                                 ActaNro = item.ActaNro,
                                 ActaAnio = item.ActaAnio,
                                 HI = item.HI,
                                 HINro = item.HINro,
                                 HIAnio = item.HIAnio,
                                 ObsCotizacion = item.ObsCotizacion
                             })
                              .GroupBy(x => new { x.CotizacionCabID }).Select(g => g.First()).ToList();


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

            //this.dgvListadoABM.ReadOnly = false;

            foreach (DataGridViewColumn col in this.dgvListadoABM.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            this.dgvListadoABM.ItemsPerPage = 13;
            int displayIndex = 0;

            this.dgvListadoABM.Columns[CAMPO_FECHACOTIZACIONDATE].HeaderText = "Fec. Cotiz.";
            this.dgvListadoABM.Columns[CAMPO_FECHACOTIZACIONDATE].Width = 120;
            this.dgvListadoABM.Columns[CAMPO_FECHACOTIZACIONDATE].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_FECHACOTIZACIONDATE].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_CONFIRMADO].HeaderText = "Confirmado";
            this.dgvListadoABM.Columns[CAMPO_CONFIRMADO].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_CONFIRMADO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_CONFIRMADO].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_CLIENTENOMBRE].HeaderText = "Cliente";
            this.dgvListadoABM.Columns[CAMPO_CLIENTENOMBRE].Width = 250;
            this.dgvListadoABM.Columns[CAMPO_CLIENTENOMBRE].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_CLIENTENOMBRE].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_TRAMITEDESCRIPCION].HeaderText = "Trámite";
            this.dgvListadoABM.Columns[CAMPO_TRAMITEDESCRIPCION].Width = 250;
            this.dgvListadoABM.Columns[CAMPO_TRAMITEDESCRIPCION].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_TRAMITEDESCRIPCION].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_MONEDAABREV].HeaderText = "Moneda";
            this.dgvListadoABM.Columns[CAMPO_MONEDAABREV].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_MONEDAABREV].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_TOTALCOTIZACION].HeaderText = "Total Cotiz.";
            this.dgvListadoABM.Columns[CAMPO_TOTALCOTIZACION].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_TOTALCOTIZACION].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_TOTALCOTIZACION].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_TOTALCOTIZACION].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_NRODOCUMENTO].HeaderText = "N° Documento";
            this.dgvListadoABM.Columns[CAMPO_NRODOCUMENTO].Width = 120;
            this.dgvListadoABM.Columns[CAMPO_NRODOCUMENTO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_NRODOCUMENTO].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_OBSCOTIZACION].HeaderText = "Observación Cotiz.";
            this.dgvListadoABM.Columns[CAMPO_OBSCOTIZACION].Width = 250;
            this.dgvListadoABM.Columns[CAMPO_OBSCOTIZACION].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_OBSCOTIZACION].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_COTIZACIONCABID].HeaderText = "ID Cotización";
            this.dgvListadoABM.Columns[CAMPO_COTIZACIONCABID].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_COTIZACIONCABID].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_COTIZACIONCABID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_COTIZACIONCABID].Visible = true;
            displayIndex++;
        }
        #endregion Método Extendidos del ParentControl

        #region Métodos Locales
        private void CargarCotizaciones(int CotizacionCabID, int TramiteID)
        {
            List<RepHojaCotizacion_Result> lista = this.DBContext.RepHojaCotizacion(CotizacionCabID.ToString(),
                                                                                    "A",
                                                                                    TramiteID).ToList();
            this.dgvCotizaciones.DataSource = lista;
            this.FormatearGrillaCotizaciones();
        }

        private void CargarAntecedentesXCotizacion(int cotizacionID)
        {
            this.dgvAntecXCoti.DataSource = null;

            var qry = (from antXCoti in lCotizaciones
                       select new
                       {
                           CotizacionCabIDAntecedente = antXCoti.CotizacionCabIDAntecedente,
                           AntecedenteID = antXCoti.AntecedenteID,
                           FechaAntecedente = antXCoti.FechaAntecedente,
                           TipoAntecedenteNombre = antXCoti.TipoAntecedenteNombre,
                           ObservacionAntecedente = antXCoti.ObservacionAntecedente
                       })
                      .Where(a => a.CotizacionCabIDAntecedente == cotizacionID)
                      .GroupBy(x => new { x.AntecedenteID }).Select(g => g.First())
                      .ToList();

            this.dgvAntecXCoti.DataSource = qry;
            this.FormatearGrillaAntecedentesXCotizacion();
        }

        private void CargarAntecedentesXCliente(int clienteID)
        {
            this.dgvAntecXCliente.DataSource = null;

            var qry = (from antXCli in lCotizaciones
                       select new
                       {
                           CotizacionCabIDAntecedente = antXCli.CotizacionCabIDAntecedente,
                           AntecedenteID = antXCli.AntecedenteID,
                           FechaAntecedente = antXCli.FechaAntecedente,
                           TipoAntecedenteNombre = antXCli.TipoAntecedenteNombre,
                           ObservacionAntecedente = antXCli.ObservacionAntecedente,
                           ClienteIDAntecedente = antXCli.ClienteIDAntecedente
                       })
                       .Where(a => a.ClienteIDAntecedente == clienteID && a.CotizacionCabIDAntecedente == null)
                       .GroupBy(x => new { x.AntecedenteID }).Select(g => g.First())
                       .ToList();
            this.dgvAntecXCliente.DataSource = qry;
            this.FormatearGrillaAntecedentesXCliente();
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

        private void FormatearGrillaAntecedentesXCotizacion()
        {
            foreach (DataGridViewColumn col in this.dgvAntecXCoti.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;                
            }

            this.dgvAntecXCoti.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 10.5F, GraphicsUnit.Pixel);
            this.dgvAntecXCoti.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dgvAntecXCoti.DefaultCellStyle.Font = new Font("Arial", 10.5F, GraphicsUnit.Pixel);
            this.dgvAntecXCoti.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvAntecXCoti.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            this.dgvAntecXCoti.ItemsPerPage = 5;
            this.dgvAntecXCoti.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            this.dgvAntecXCoti.ItemsPerPage = 4;
            int displayIndex = 0;

            this.dgvAntecXCoti.Columns[CAMPO_FECHAANTECEDENTE].HeaderText = "Fecha";
            this.dgvAntecXCoti.Columns[CAMPO_FECHAANTECEDENTE].Width = 80;
            this.dgvAntecXCoti.Columns[CAMPO_FECHAANTECEDENTE].DisplayIndex = displayIndex;
            this.dgvAntecXCoti.Columns[CAMPO_FECHAANTECEDENTE].Visible = true;
            displayIndex++;

            this.dgvAntecXCoti.Columns[CAMPO_TIPOANTECEDENTENOMBRE].HeaderText = "Tipo Antecedente";
            this.dgvAntecXCoti.Columns[CAMPO_TIPOANTECEDENTENOMBRE].Width = 120;
            this.dgvAntecXCoti.Columns[CAMPO_TIPOANTECEDENTENOMBRE].DisplayIndex = displayIndex;
            this.dgvAntecXCoti.Columns[CAMPO_TIPOANTECEDENTENOMBRE].Visible = true;
            displayIndex++;

            this.dgvAntecXCoti.Columns[CAMPO_OBSERVACIONANTECEDENTE].HeaderText = "Observación";
            this.dgvAntecXCoti.Columns[CAMPO_OBSERVACIONANTECEDENTE].Width = 150;
            this.dgvAntecXCoti.Columns[CAMPO_OBSERVACIONANTECEDENTE].DisplayIndex = displayIndex;
            this.dgvAntecXCoti.Columns[CAMPO_OBSERVACIONANTECEDENTE].Visible = true;
            displayIndex++;
        }

        private void FormatearGrillaAntecedentesXCliente()
        {
            foreach (DataGridViewColumn col in this.dgvAntecXCliente.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            this.dgvAntecXCliente.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 10.5F, GraphicsUnit.Pixel);
            this.dgvAntecXCliente.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dgvAntecXCliente.DefaultCellStyle.Font = new Font("Arial", 10.5F, GraphicsUnit.Pixel);
            this.dgvAntecXCliente.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvAntecXCliente.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            this.dgvAntecXCliente.ItemsPerPage = 5;
            this.dgvAntecXCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            this.dgvAntecXCliente.ItemsPerPage = 6;
            int displayIndex = 0;

            this.dgvAntecXCliente.Columns[CAMPO_FECHAANTECEDENTE].HeaderText = "Fecha";
            this.dgvAntecXCliente.Columns[CAMPO_FECHAANTECEDENTE].Width = 80;
            this.dgvAntecXCliente.Columns[CAMPO_FECHAANTECEDENTE].DisplayIndex = displayIndex;
            this.dgvAntecXCliente.Columns[CAMPO_FECHAANTECEDENTE].Visible = true;
            displayIndex++;

            this.dgvAntecXCliente.Columns[CAMPO_TIPOANTECEDENTENOMBRE].HeaderText = "Tipo Antecedente";
            this.dgvAntecXCliente.Columns[CAMPO_TIPOANTECEDENTENOMBRE].Width = 120;
            this.dgvAntecXCliente.Columns[CAMPO_TIPOANTECEDENTENOMBRE].DisplayIndex = displayIndex;
            this.dgvAntecXCliente.Columns[CAMPO_TIPOANTECEDENTENOMBRE].Visible = true;
            displayIndex++;

            this.dgvAntecXCliente.Columns[CAMPO_OBSERVACIONANTECEDENTE].HeaderText = "Observación";
            this.dgvAntecXCliente.Columns[CAMPO_OBSERVACIONANTECEDENTE].Width = 250;
            this.dgvAntecXCliente.Columns[CAMPO_OBSERVACIONANTECEDENTE].DisplayIndex = displayIndex;
            this.dgvAntecXCliente.Columns[CAMPO_OBSERVACIONANTECEDENTE].Visible = true;
            displayIndex++;
        }

        #endregion Métodos Locales

        #region Controles Locales
        private void dgvListadoABM_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.limpiarDatos();

            if (this.dgvListadoABM.Rows.Count > 0)
            {
                this.txtFechaCotizacion.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_FECHACOTIZACIONDATE].Value != null ? Convert.ToDateTime(((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_FECHACOTIZACIONDATE].Value.ToString()).ToShortDateString() : string.Empty;
                this.txtNroDocumento.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_NRODOCUMENTO].Value != null ? ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_NRODOCUMENTO].Value.ToString() : string.Empty;
                this.txtClienteID.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_CLIENTEID].Value.ToString();
                this.txtClienteNombre.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_CLIENTENOMBRE].Value.ToString();
                this.txtTramiteID.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TRAMITEID].Value.ToString();
                this.txtTramiteDescripcion.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TRAMITEDESCRIPCION].Value.ToString();
                this.txtTotal.Text = String.Format(FORMATO_DECIMAL_BROWSE, decimal.Round((decimal)((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TOTALCOTIZACION].Value, MidpointRounding.AwayFromZero));
                this.txtMonedaAbrev.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_MONEDAABREV].Value.ToString();
                this.txtObservacion.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_OBSCOTIZACION].Value != null ? ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_OBSCOTIZACION].Value.ToString() : string.Empty;
                this.txtCotizacionID.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_COTIZACIONCABID].Value.ToString();

                if ((((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_CONFIRMADOVAL].Value != null) && (Convert.ToBoolean(((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_CONFIRMADOVAL].Value)))
                {
                    this.rbConfirmadoSi.Checked = true;
                }
                else this.rbConfirmadoNo.Checked = true;

                this.CargarCotizaciones(Convert.ToInt32(this.txtCotizacionID.Text), Convert.ToInt32(this.txtTramiteID.Text));
                this.CargarAntecedentesXCotizacion(Convert.ToInt32(this.txtCotizacionID.Text));
                this.CargarAntecedentesXCliente(Convert.ToInt32(this.txtClienteID.Text));
            }
        }        

        #endregion Controles Locales

        #region ReadOnly condicional
        protected override void Editable(bool editar)
        {
            foreach (Control ctrl in this.pnlDetalle.Controls)
            {
                if ((ctrl.GetType() == typeof(TextBox) && ((TextBox)ctrl).Visible))
                {
                    ((TextBox)ctrl).ReadOnly = true;
                }
            }
        }
        #endregion ReadOnly condicional

        #region Limpiar Datos
        private void limpiarDatos()
        {
            foreach (Control ctrl in this.pnlCabPresup.Controls)
            {
                if ((ctrl.GetType() == typeof(TextBox) && ((TextBox)ctrl).Visible))
                {
                    ((TextBox)ctrl).Text = string.Empty;
                }
            }
        }
        #endregion Limpiar Datos

        private void dgvAntecXCoti_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }

    }
}
