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
    public partial class FRepDetallePagoDocsParaFactura : Form
    {
        #region Variables
        frmPickBase fPickCliente;
        BerkeDBEntities DBContext;
        #endregion Variables

        #region Constantes
        private const int IDIOMA_ESPANOL = 2;
        #endregion Constantes

        public FRepDetallePagoDocsParaFactura()
        {
            InitializeComponent();
        }

        public FRepDetallePagoDocsParaFactura(string titulo, BerkeDBEntities context)
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
            fPickCliente.Dispose();
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
            //if (this.tSBCliente.KeyMember == "")
            //{
            //    MessageBox.Show("Debe especificar un cliente obligatoriamente.",
            //                            "Atenci�n Requerida",
            //                            MessageBoxButtons.OK,
            //                            MessageBoxIcon.Exclamation);
            //    return;
            //}


            if (((this.txtFechaDesde.Text == string.Empty) && (this.txtFechaHasta.Text == string.Empty)))
            {
                MessageBox.Show("Debe especificar fecha desde y fecha hasta.",
                                        "Atenci�n Requerida",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                return;

            }

            if (((this.txtFechaDesde.Text == "") && (this.txtFechaHasta.Text != "")) ||
               ((this.txtFechaDesde.Text != "")&& (this.txtFechaHasta.Text == "")))
            {
                MessageBox.Show("Debe especificar un rango de fechas v�lido.",
                                        "Atenci�n Requerida",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                return;

            }
            
            List<DetallePagosPorDocumentoParaFactura_Result> reportDS = new List<DetallePagosPorDocumentoParaFactura_Result>();

            try
            {
                reportDS = this.DBContext.DetallePagosPorDocumentoParaFactura(this.tSBCliente.KeyMember,
                                                                   this.txtFechaDesde.Text,
                                                                   this.txtFechaHasta.Text).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurri� un error al generar el reporte: " + Environment.NewLine + ex.Message, "Informaci�n de Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

            if (reportDS.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte con los criterios ingresados.",
                                "Atenci�n Requerida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            #region Datos de tr�mite para factura
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
            #endregion Datos de tr�mite para factura
            
            this.tSBCliente.DisplayMember = reportDS.First().ClienteNombre;

            ReportDataSource datasource = null;
            datasource = new ReportDataSource("DataSet1", reportDS);

            string path = @"Reportes\RepListadoPagosPorDocumentosParaFactura.rdlc";
            
            FReportViewerBase f = new FReportViewerBase(path, datasource, this.DBContext);
            f.FormClosed += delegate { f = null; };
            f.Titulo = "Detalle de Pagos de Documentos - " + this.tSBCliente.DisplayMember;
            f.NombreArchivoAdjunto = "RepDetallePagosParaFactura-" + this.tSBCliente.KeyMember;
            f.AsuntoMail = "Reporte Detallado de Pagos de Documentos Para Factura - " + this.tSBCliente.DisplayMember + " (" + this.tSBCliente.KeyMember + ")";
            f.ShowDialog();
        }
    }
}