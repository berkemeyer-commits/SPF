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
    public partial class FRepEstadoCtaGcialPG : Form
    {
        #region Variables
        frmPickBase fPickBanco;
        BerkeDBEntities DBContext;
        #endregion Variables

        #region Constantes
        private const int IDIOMA_ESPANOL = 2;
        #endregion Constantes

        public FRepEstadoCtaGcialPG()
        {
            InitializeComponent();
        }

        public FRepEstadoCtaGcialPG(string titulo, BerkeDBEntities context)
        {
            InitializeComponent();
            this.Text = titulo;
            this.DBContext = context;

            this.txtTipoCambio.Text = this.GetTipoCambioDelDia();

            #region DateTime Pickers
            this.dtpFechaDesde.Format = DateTimePickerFormat.Short;
            this.txtFechaDesde.Text = DateTime.Now.ToShortDateString();
            #endregion DateTime Pickers
        }

        private string GetTipoCambioDelDia()
        {
            string Result = "1";
            DateTime dt = new System.DateTime();
            dt =   System.DateTime.Now.Date;
            tc_tipocambio tc = this.DBContext.tc_tipocambio.FirstOrDefault(a => a.tc_fecha == dt);

            if (tc != null)
            {
                ((IObjectContextAdapter)this.DBContext).ObjectContext.Refresh(System.Data.Entity.Core.Objects.RefreshMode.ClientWins, tc);
                Result = String.Format("{0:N0}", tc.tc_valor);
            }
            else
            {
                if (this.DBContext.tc_tipocambio.Count() > 0)
                {
                    dt = this.DBContext.tc_tipocambio.ToList().Max(a => a.tc_fecha);
                    tc = this.DBContext.tc_tipocambio.FirstOrDefault(a => a.tc_fecha == dt);

                    if (tc != null)
                    {
                        ((IObjectContextAdapter)this.DBContext).ObjectContext.Refresh(System.Data.Entity.Core.Objects.RefreshMode.ClientWins, tc);
                        Result = String.Format("{0:N0}", tc.tc_valor);
                    }
                }
            }

            if (Result != "1")
            {
                if (dt == System.DateTime.Now.Date)
                {
                    this.txtFechaTipoCambio.Text = "Tipo de Cambio de hoy";
                    this.txtFechaTipoCambio.ForeColor = Color.Green;
                }
                else
                {
                    this.txtFechaTipoCambio.Text = String.Format("Utilizando Tipo de Cambio de fecha {0}", dt.ToShortDateString());
                    this.txtFechaTipoCambio.ForeColor = Color.Red;
                }
            }
            else
            {
                this.txtFechaTipoCambio.Text = "No existe Tipo de Cambio definido.";
                this.txtFechaTipoCambio.ForeColor = Color.Red;
            }

            return Result;
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaDesde.Text = this.dtpFechaDesde.Value.ToShortDateString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.txtFechaDesde.Text == "")
            {
                MessageBox.Show("Debe especificar la fecha para generar el listado.",
                                        "Atención Requerida",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                return;

            }

            if (this.txtTipoCambio.Text == "")
            {
                MessageBox.Show("Debe ingresar un tipo de cambio.",
                                "Atención Requerida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;

            }

            List<GetEstadoCuentaGerencialPG_Result> reportDS = new List<GetEstadoCuentaGerencialPG_Result>();

            try
            {
                string MonedaID = null;
                decimal tCambio = Convert.ToDecimal(this.txtTipoCambio.Text);
                reportDS = this.DBContext.GetEstadoCuentaGerencialPG(this.txtFechaDesde.Text, 
                                                                    MonedaID, tCambio).ToList();

                if (reportDS.Count == 0)
                {
                    throw new Exception("No existen datos para el reporte con los criterios ingresados.");
                }

                ReportDataSource datasource = null;
                datasource = new ReportDataSource("DataSet1", reportDS);

                string path = @"Reportes\RepEstadoCtaGerencialPG.rdlc";
                string asuntoMail = "Reporte de Cuentas a Pagar - Gerencial - Práctica General";
                string cuerpoMail = "Por favor revise el documento adjunto.";
                string nombreArchivo = "RepEstadoCtaGerencialPG";

                FReportViewerBase f = new FReportViewerBase(path, datasource, this.DBContext);
                f.FormClosed += delegate { f = null; };
                f.Titulo = String.Format("Reporte de Cuentas a Pagar - Gerencial - Práctica General - Al {0}", this.txtFechaDesde.Text);
                f.NombreArchivoAdjunto = nombreArchivo;
                f.AsuntoMail = asuntoMail + " - " + String.Format("Reporte de Cuentas a Pagar - Gerencial - Práctica General - Al {0}", this.txtFechaDesde.Text);
                f.CuerpoMail = cuerpoMail;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al generar el reporte: " + Environment.NewLine + ex.Message, "Información de Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

            //if (reportDS.Count == 0)
            //{
            //    MessageBox.Show("No existen datos para el reporte con los criterios ingresados.",
            //                    "Atención Requerida",
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Information);
            //    return;
            //}

            
        }

        
        private void dtpFecBolDep_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}