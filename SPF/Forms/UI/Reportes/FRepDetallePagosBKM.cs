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
    public partial class FRepDetallePagosBKM : Form
    {
        #region Variables
        BerkeDBEntities DBContext;
        #endregion Variables

        #region Constantes
        private const int IDIOMA_ESPANOL = 2;
        private const string CLIENTE_PAGOS_A_BKM_ID = "1014101";
        private const string CLIENTE_PAGOS_A_BKM_NOMBRE = "PAGOS A BKM";
        #endregion Constantes

        public FRepDetallePagosBKM()
        {
            InitializeComponent();
        }

        public FRepDetallePagosBKM(string titulo, BerkeDBEntities context)
        {
            InitializeComponent();
            this.Text = titulo;
            this.DBContext = context;

            #region DateTime Pickers
            this.dtpFechaDesde.Format = DateTimePickerFormat.Short;
            this.dtpFechaHasta.Format = DateTimePickerFormat.Short;
            #endregion

            //this.txtFechaDesde.Text = System.DateTime.Now.Date.ToShortDateString();
            //this.txtFechaHasta.Text = System.DateTime.Now.Date.ToShortDateString();
        }

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
            //if (this.tSBCliente.KeyMember == "")
            //{
            //    MessageBox.Show("Debe especificar un cliente obligatoriamente.",
            //                            "Atención Requerida",
            //                            MessageBoxButtons.OK,
            //                            MessageBoxIcon.Exclamation);
            //    return;
            //}


            if (((this.txtFechaDesde.Text == string.Empty) && (this.txtFechaHasta.Text == string.Empty)))
            {
                MessageBox.Show("Debe especificar fecha desde y fecha hasta.",
                                        "Atención Requerida",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                return;

            }

            if (((this.txtFechaDesde.Text == "") && (this.txtFechaHasta.Text != "")) ||
               ((this.txtFechaDesde.Text != "")&& (this.txtFechaHasta.Text == "")))
            {
                MessageBox.Show("Debe especificar un rango de fechas válido.",
                                        "Atención Requerida",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                return;

            }
            
            List<DetallePagosPorDocumentoParaFactura_Result> reportDS = new List<DetallePagosPorDocumentoParaFactura_Result>();

            try
            {
                reportDS = this.DBContext.DetallePagosPorDocumentoParaFactura(CLIENTE_PAGOS_A_BKM_ID,
                                                                   this.txtFechaDesde.Text,
                                                                   this.txtFechaHasta.Text).ToList();
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

            #region Datos de trámite para factura
            foreach (DetallePagosPorDocumentoParaFactura_Result row in reportDS)
            {
                int PresupuestoCabID = row.PresupuestoCabID;
                var q = this.DBContext.cp_cotizacionesxpresup.Where(a => a.cp_presupuestocabid == PresupuestoCabID).ToList();

                string listaCotizaciones = "";
                int cantPropietarios = 0;
                string listaPropietarios = "";
                string gPropietario = "";
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
                        row.TramiteDescrip += Environment.NewLine + listaActas;
                    }

                    string lblPropietarios = row.ClienteIdiomaID == IDIOMA_ESPANOL ? "Propietario: {0}" : "Owner: {0}";
                    if (cantPropietarios > 0)
                    {
                        if (cantPropietarios > 1)
                            lblPropietarios = row.ClienteIdiomaID == IDIOMA_ESPANOL ? "Propietarios: {0}" : "Owners: {0}";

                        row.TramiteDescrip += Environment.NewLine + String.Format(lblPropietarios, listaPropietarios);
                    }
                }
                else
                {
                    //Generalmente, cargas manuales que no se hicieron desde cotizaciones
                    row.TramiteDescrip += Environment.NewLine + row.Descripcion;
                }

            }
            #endregion Datos de trámite para factura
            
            ReportDataSource datasource = null;
            datasource = new ReportDataSource("DataSet1", reportDS);

            string path = @"Reportes\RepListadoPagosABKM.rdlc";
            
            FReportViewerBase f = new FReportViewerBase(path, datasource, this.DBContext);
            f.FormClosed += delegate { f = null; };
            f.Titulo = "Detalle - " + CLIENTE_PAGOS_A_BKM_NOMBRE;
            f.NombreArchivoAdjunto = "RepDetallePagosABKM-" + CLIENTE_PAGOS_A_BKM_NOMBRE;
            f.AsuntoMail = "Reporte Detalle - " + CLIENTE_PAGOS_A_BKM_NOMBRE+ " (" + CLIENTE_PAGOS_A_BKM_ID + ")";
            f.ShowDialog();
        }
    }
}