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
    public partial class FRepDispBancos : Form
    {
        #region Variables
        frmPickBase fPickBanco;
        BerkeDBEntities DBContext;
        #endregion Variables

        #region Constantes
        private const int IDIOMA_ESPANOL = 2;
        private const int BANCO_COMPENSATORIO = 65;
        #endregion Constantes

        public FRepDispBancos()
        {
            InitializeComponent();
        }

        public FRepDispBancos(string titulo, BerkeDBEntities context)
        {
            InitializeComponent();
            this.Text = titulo;
            this.DBContext = context;

            #region DateTime Pickers
            this.dtpFechaDesde.Format = DateTimePickerFormat.Short;
            this.txtFechaDesde.Text = DateTime.Now.ToShortDateString();
            #endregion DateTime Pickers

            #region TextSearchBoxes
            this.tSBBanco.KeyMemberWidth = 70;
            this.tSBBanco.Editable = true;
            this.tSBBanco.ToolTip = "Elegir Banco";
            this.tSBBanco.AceptarClick += tSBBanco_AceptarClick;
            #endregion TextSearchBoxes
        }

        #region Picks
        #region Banco
        private void tSBBanco_AceptarClick(object sender, EventArgs e)
        {
            if (fPickBanco == null)
            {
                fPickBanco = new frmPickBase();
                fPickBanco.AceptarFiltrarClick += fPickBanco_AceptarFiltrarClick;
                fPickBanco.FiltrarClick += fPickBanco_FiltrarClick;
                fPickBanco.Titulo = "Elegir Banco";
                fPickBanco.CampoIDNombre = "BancoID";
                fPickBanco.CampoDescripNombre = "BancoNombre";
                fPickBanco.LabelCampoID = "ID";
                fPickBanco.LabelCampoDescrip = "Nombre";
                fPickBanco.NombreCampo = "Banco";
                fPickBanco.PermitirFiltroNulo = true;
            }
            fPickBanco.MostrarFiltro();
            this.fPickBanco_FiltrarClick(sender, e);
        }

        private void fPickBanco_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickBanco != null)
            {
                var query = (from ba in this.DBContext.ba_banco
                             join cb in this.DBContext.cb_cuentabanco
                                on ba.ba_bancoid equals cb.cb_bancoid
                             select new BancoType
                             {
                                 BancoID = ba.ba_bancoid,
                                 BancoNombre = ba.ba_descripcion,
                                 EsCuentaPago = cb.cb_escuentapago
                             })
                             .Where(a => a.EsCuentaPago == true && a.BancoID != BANCO_COMPENSATORIO)
                             .Distinct();
                fPickBanco.LoadData<BancoType>(query.AsQueryable(), fPickBanco.GetWhereString());
                //fPickBanco.LoadData<ba_banco>(this.DBContext.ba_banco, fPickBanco.GetWhereString());
            }
        }

        private void fPickBanco_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBBanco.DisplayMember = fPickBanco.ValorDescrip;
            this.tSBBanco.KeyMember = fPickBanco.ValorID;

            fPickBanco.Close();
            fPickBanco.Dispose();
        }
        #endregion Banco Depósito
        #endregion Picks

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
            //if (this.tSBCliente.KeyMember == "")
            //{
            //    MessageBox.Show("Debe especificar un cliente obligatoriamente.",
            //                            "Atención Requerida",
            //                            MessageBoxButtons.OK,
            //                            MessageBoxIcon.Exclamation);
            //    return;
            //}

            if (this.txtFechaDesde.Text == "")
            {
                MessageBox.Show("Debe especificar la fecha para generar el listado.",
                                        "Atención Requerida",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                return;

            }

            Nullable<int> BancoID = null;
            if (this.tSBBanco.KeyMember != String.Empty)
                BancoID = Convert.ToInt32(this.tSBBanco.KeyMember);

            List<GetDisponibilidadEnBanco_Result> reportDS = new List<GetDisponibilidadEnBanco_Result>();

            try
            {
                reportDS = this.DBContext.GetDisponibilidadEnBanco(BancoID, this.txtFechaDesde.Text).ToList();

                if (reportDS.Count == 0)
                {
                    throw new Exception("No existen datos para el reporte con los criterios ingresados.");
                }

                ReportDataSource datasource = null;
                datasource = new ReportDataSource("DataSet1", reportDS);

                string path = @"Reportes\RepDisponibilidadBancos.rdlc";
                string asuntoMail = "Reporte de Disponibilidad en Bancos";
                string cuerpoMail = "Por favor revise el documento adjunto.";
                string nombreArchivo = "RepDisponibilidadBancos";

                FReportViewerBase f = new FReportViewerBase(path, datasource, this.DBContext);
                f.FormClosed += delegate { f = null; };
                f.Titulo = String.Format("Reporte de Disponibilidad en Bancos - Al {0}", this.txtFechaDesde.Text);
                f.NombreArchivoAdjunto = nombreArchivo;
                f.AsuntoMail = asuntoMail + " - " + String.Format("Reporte de Disponibilidad en Bancos - Al {0}", this.txtFechaDesde.Text);
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