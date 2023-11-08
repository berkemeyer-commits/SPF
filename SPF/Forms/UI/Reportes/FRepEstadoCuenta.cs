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
using Microsoft.Reporting.WebForms;

#endregion

namespace SPF.Forms.UI.Reportes
{
    public partial class FRepEstadoCuenta : Form
    {
        #region Variables
        frmPickBase fPickCliente;
        BerkeDBEntities DBContext;
        #endregion Variables

        #region Constantes
        private const int IDIOMA_ESPANOL = 2;
        private const string CLAVE_REP_ESTADO_CUENTA = "ESTADO_CTA";
        private const string NEW_LINE_HTML = "<br>";
        private const string SEP_TRAMITE = ";#;";
        private const string SITUACIONES_ALERTA_ESTADO_CUENTA = "SITUACIONES_ALERTA_ESTADO_CUENTA";
        private const string FORMAT_MSG = "MENSAJE_{0}_{1}";
        private const string FORMAT_ESP = "ESP";
        private const string FORMAT_ING = "ING";
        private const string CULTURE_PY = "es-PY";
        private const string CULTURE_US = "en-US";
        private const string FORMAT_REDFONTMARK = "<font color='red'><b>{0}</b></font>";
        #endregion Constantes

        public FRepEstadoCuenta()
        {
            InitializeComponent();
        }

        public FRepEstadoCuenta(string titulo, BerkeDBEntities context)
        {
            InitializeComponent();
            this.Text = titulo;
            this.DBContext = context;

            #region DateTime Pickers
            this.dtpFechaDesde.Format = DateTimePickerFormat.Short;
            this.dtpFechaHasta.Format = DateTimePickerFormat.Short;

            //this.txtFechaDesde.Text = System.DateTime.Now.Date.ToShortDateString();
            //this.txtFechaHasta.Text = System.DateTime.Now.Date.ToShortDateString();
            #endregion DateTime Pickers

            #region TextSearchBoxes
            this.tSBCliente.KeyMemberWidth = 70;
            this.tSBCliente.ToolTip = "Elegir Cliente";
            this.tSBCliente.AceptarClick += tSBCliente_AceptarClick;
            this.tSBCliente.Editable = true;
            this.tSBCliente.ToolTipTSB = "Cliente";
            #endregion TextSearchBoxes

            this.rbTramitesAgrupados.Checked = true;
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
                fPickCliente.MostrarFiltro();
            }
            else fPickCliente.MostrarFiltro(true);
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
            /*fPickCliente.Dispose();*/
        }
        #endregion Picks

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaDesde.Text = this.dtpFechaDesde.Value.ToShortDateString();
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaHasta.Text = this.dtpFechaHasta.Value.ToShortDateString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.tSBCliente.KeyMember == "")
            {
                MessageBox.Show("Debe especificar un cliente obligatoriamente.",
                                        "Atención Requerida",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                return;
            }
            
            if (((this.txtFechaDesde.Text == "") && (this.txtFechaHasta.Text != "")) ||
               ((this.txtFechaDesde.Text != "")&& (this.txtFechaHasta.Text == "")))
            {
                MessageBox.Show("Debe especificar fecha desde y fecha hasta.",
                                        "Atención Requerida",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                return;

            }

            if (this.rbTramitesAgrupados.Checked)
            {
                this.GenerarReporteTramitesAgrupados();
            }
            else
            {
                this.GenerarReporteTramitesDesagrupados();   
            }            
        }

        private void GenerarReporteTramitesAgrupados()
        {
            List<RepEstadoDeCuenta_Result> reportDS = new List<RepEstadoDeCuenta_Result>();
            
            try
            {
                reportDS = this.DBContext.RepEstadoDeCuenta(this.tSBCliente.KeyMember,
                                                             this.txtFechaDesde.Text,
                                                             this.txtFechaHasta.Text,
                                                             this.chkIncluirNCP.Checked).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al generar el reporte: " + Environment.NewLine + ex.Message, "Información de Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

            if (reportDS.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte con los criterios ingresados.",
                                "Atención Requerida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            this.tSBCliente.DisplayMember = reportDS.First().ClienteNombre;

            int it = 0;
            CultureInfo culture = null;
            string[] situacionAlertaArray = this.DBContext.pa_parametros.First(a => a.clave == SITUACIONES_ALERTA_ESTADO_CUENTA).valor.Split(',');

            foreach (RepEstadoDeCuenta_Result row in reportDS)
            {
                int PresupuestoCabID = row.PresupuestoID;
                var q = this.DBContext.cp_cotizacionesxpresup.Where(a => a.cp_presupuestocabid == PresupuestoCabID).ToList();

                string listaCotizaciones = "";
                int cantPropietarios = 0;
                string listaPropietarios = "";
                string gPropietario = "";
                string lblAlerta = string.Empty;

                //Primera Iteración
                if (it == 0)
                {
                    string cultureString = row.ClienteIdiomaID == IDIOMA_ESPANOL ? CULTURE_PY : CULTURE_US;
                    culture = new CultureInfo(cultureString);
                    it++;
                }

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

                        row.Tramite += @NEW_LINE_HTML + String.Format(lblPropietarios, listaPropietarios);
                    }

                    if (lblAlerta != string.Empty)
                    {
                        row.Tramite += @NEW_LINE_HTML + this.AddRedFontMarks(lblAlerta);
                    }
                }
            }


            ReportDataSource datasource = null;

            var ds = from r in reportDS
                     group r by new
                     {
                         r.ClienteID,
                         r.ClienteNombre,
                         r.Tramite,
                         r.FechaDoc,
                         r.NroDoc,
                         r.Moneda
                     } into g
                     select new
                     {
                         ClienteID = g.Key.ClienteID,
                         ClienteNombre = g.Key.ClienteNombre,
                         Tramite = g.Key.Tramite,
                         FechaDoc = g.Key.FechaDoc,
                         NroDoc = g.Key.NroDoc,
                         Moneda = g.Key.Moneda,
                         Saldo = g.Sum(x => x.Saldo)
                     };
            //datasource = new ReportDataSource("DataSet1", reportDS);
            datasource = new ReportDataSource("DataSet1", ds);

            int ClienteID = Convert.ToInt32(this.tSBCliente.KeyMember);
            int IdiomaID = this.DBContext.Cliente.First(a => a.ID == ClienteID).IdiomaID.Value;
            ra_reporteasunto repAsunto = this.DBContext.ra_reporteasunto.FirstOrDefault(a => a.ra_reporte_id == CLAVE_REP_ESTADO_CUENTA);

            string path = IdiomaID == IDIOMA_ESPANOL ? @"Reportes\RepEstadoCuentaEsp.rdlc" : @"Reportes\RepEstadoCuentaIng.rdlc";
            
            List<ReportParameter> rptParams = null;

            if (this.chkObsSistElect.Checked)
            {
                path = IdiomaID == IDIOMA_ESPANOL ? @"Reportes\RepEstadoCuentaEspObs.rdlc" : @"Reportes\RepEstadoCuentaIngObs.rdlc";

                var qry = (from cc in this.DBContext.Cliente
                           join ts in this.DBContext.tse_tiposistelectronico
                             on cc.TipoSistElectronicoID equals ts.tse_tiposistelectronicoid into cc_ts
                           from ts in cc_ts.DefaultIfEmpty()

                           select new
                           {
                               ClienteID = cc.ID,
                               Observacion = cc.Obs,
                               SistemaElectronico = ts.tse_descripcion
                           })
                          .Where(a => a.ClienteID == ClienteID).FirstOrDefault();
                          

                rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("ObservacionCliente", !string.IsNullOrEmpty(qry.Observacion) ? qry.Observacion : "--"));
                rptParams.Add(new ReportParameter("SistemaElectronico", !string.IsNullOrEmpty(qry.SistemaElectronico) ? qry.SistemaElectronico : "--"));
            }

            
            string asuntoMail = IdiomaID == IDIOMA_ESPANOL ? "Reporte de Estado de Cuenta" : "Statement Report";
            string cuerpoMail = IdiomaID == IDIOMA_ESPANOL ? "Por favor revise el documento adjunto." : "Please check the attached document.";

            if (repAsunto != null)
            {
                cuerpoMail = IdiomaID == IDIOMA_ESPANOL ? repAsunto.ra_asunto_esp : repAsunto.ra_asunto_ing;
            }

            string nombreArchivo = IdiomaID == IDIOMA_ESPANOL ? "RepEstadoCuenta-" : "StatementReport";

            FReportViewerBase f = new FReportViewerBase(path, datasource, this.DBContext, rptParams);
            f.FormClosed += delegate { f = null; };
            f.Titulo = "Reporte de Estado de Cuenta - " + this.tSBCliente.DisplayMember;
            f.NombreArchivoAdjunto = nombreArchivo + this.tSBCliente.KeyMember;
            f.AsuntoMail = asuntoMail + " - " + this.tSBCliente.DisplayMember + " (" + this.tSBCliente.KeyMember + ")";
            f.CuerpoMail = cuerpoMail;
            f.ShowDialog();
        }

        private void GenerarReporteTramitesDesagrupados()
        {
            List<RepEstadoDeCuentaTramitesDesagrupados_Result> reportDS = new List<RepEstadoDeCuentaTramitesDesagrupados_Result>();

            try
            {
                reportDS = this.DBContext.RepEstadoDeCuentaTramitesDesagrupados(this.tSBCliente.KeyMember,
                                                                this.txtFechaDesde.Text,
                                                                this.txtFechaHasta.Text,
                                                                this.chkIncluirNCP.Checked).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al generar el reporte: " + Environment.NewLine + ex.Message, "Información de Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

            if (reportDS.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte con los criterios ingresados.",
                                "Atención Requerida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            this.tSBCliente.DisplayMember = reportDS.First().ClienteNombre;

            int it = 0;
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
                    it++;
                }

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
            }

            ReportDataSource datasource = null;

            var ds = from r in reportDS
                     group r by new
                     {
                         r.ClienteID,
                         r.ClienteNombre,
                         r.FechaDoc,
                         r.NroDoc,
                         r.Moneda
                     } into g
                     select new
                     {
                         ClienteID = g.Key.ClienteID,
                         ClienteNombre = g.Key.ClienteNombre,
                         Tramite = string.Join("", g.Select(i => i.Tramite)),
                         FechaDoc = g.Key.FechaDoc,
                         NroDoc = g.Key.NroDoc,
                         Moneda = g.Key.Moneda,
                         Saldo = g.Sum(x => x.Saldo)
                     };

            //datasource = new ReportDataSource("DataSet1", reportDS);
            datasource = new ReportDataSource("DataSet1", ds);

            int ClienteID = Convert.ToInt32(this.tSBCliente.KeyMember);
            int IdiomaID = this.DBContext.Cliente.First(a => a.ID == ClienteID).IdiomaID.Value;
            ra_reporteasunto repAsunto = this.DBContext.ra_reporteasunto.FirstOrDefault(a => a.ra_reporte_id == CLAVE_REP_ESTADO_CUENTA);

            string path = IdiomaID == IDIOMA_ESPANOL ? @"Reportes\RepEstadoCuentaEsp.rdlc" : @"Reportes\RepEstadoCuentaIng.rdlc";

            List<ReportParameter> rptParams = null;

            if (this.chkObsSistElect.Checked)
            {
                path = IdiomaID == IDIOMA_ESPANOL ? @"Reportes\RepEstadoCuentaEspObs.rdlc" : @"Reportes\RepEstadoCuentaIngObs.rdlc";

                var qry = (from cc in this.DBContext.Cliente
                           join ts in this.DBContext.tse_tiposistelectronico
                             on cc.TipoSistElectronicoID equals ts.tse_tiposistelectronicoid into cc_ts
                           from ts in cc_ts.DefaultIfEmpty()

                           select new
                           {
                               ClienteID = cc.ID,
                               Observacion = cc.Obs,
                               SistemaElectronico = ts.tse_descripcion
                           })
                          .Where(a => a.ClienteID == ClienteID).FirstOrDefault();


                rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("ObservacionCliente", !string.IsNullOrEmpty(qry.Observacion) ? qry.Observacion : "--"));
                rptParams.Add(new ReportParameter("SistemaElectronico", !string.IsNullOrEmpty(qry.SistemaElectronico) ? qry.SistemaElectronico : "--"));
            }

            string asuntoMail = IdiomaID == IDIOMA_ESPANOL ? "Reporte de Estado de Cuenta" : "Statement Report";
            string cuerpoMail = IdiomaID == IDIOMA_ESPANOL ? "Por favor revise el documento adjunto." : "Please check the attached document.";

            if (repAsunto != null)
            {
                cuerpoMail = IdiomaID == IDIOMA_ESPANOL ? repAsunto.ra_asunto_esp : repAsunto.ra_asunto_ing;
            }

            string nombreArchivo = IdiomaID == IDIOMA_ESPANOL ? "RepEstadoCuenta-" : "StatementReport";

            FReportViewerBase f = new FReportViewerBase(path, datasource, this.DBContext, rptParams);
            f.FormClosed += delegate { f = null; };
            f.Titulo = "Reporte de Estado de Cuenta - " + this.tSBCliente.DisplayMember;
            f.NombreArchivoAdjunto = nombreArchivo + this.tSBCliente.KeyMember;
            f.AsuntoMail = asuntoMail + " - " + this.tSBCliente.DisplayMember + " (" + this.tSBCliente.KeyMember + ")";
            f.CuerpoMail = cuerpoMail;
            f.ShowDialog();
        }

        private string GetTruncatedString(string truncatedString)
        {
            string Result = "";
            return Result;
        }

        private string AddRedFontMarks(string text)
        {
            return string.Format(FORMAT_REDFONTMARK, text);
        }
    }
}