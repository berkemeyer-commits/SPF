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
    public partial class FRepListadoComision : Form
    {
        #region Variables
        frmPickBase fPickCliente;
        frmPickBase fPickAbogado;
        BerkeDBEntities DBContext;
        #endregion Variables

        #region Constantes
        public const string ESTADO_PENDIENTE = "A";
        public const string ESTADO_PAGADO = "P";
        public const string ESTADO_ANULADO = "N";
        #endregion Constantes

        public FRepListadoComision()
        {
            InitializeComponent();
        }

        public FRepListadoComision(string titulo, BerkeDBEntities context = null)
        {
            InitializeComponent();
            this.Text = titulo;
            //En este caso particular se crea una nueva conexión debido a que el procesamiento puede extenderse
            //por mayor tiempo del timeout por defecto
            this.DBContext = new BerkeDBEntities();//context;
            ((IObjectContextAdapter)this.DBContext).ObjectContext.CommandTimeout = 180;
            
            #region DateTime Pickers
            this.dtpFechaDesde.Format = DateTimePickerFormat.Short;
            this.dtpFechaHasta.Format = DateTimePickerFormat.Short;
            this.dtpFechaAl.Format = DateTimePickerFormat.Short;

            this.txtFechaDesde.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToShortDateString();
            this.txtFechaHasta.Text = System.DateTime.Now.Date.ToShortDateString();
            this.txtFechaAl.Text = System.DateTime.Now.Date.ToShortDateString();
            #endregion DateTime Pickers

            #region TextSearchBoxes
            this.tSBCliente.KeyMemberWidth = 70;
            this.tSBCliente.ToolTip = "Elegir Cliente";
            this.tSBCliente.AceptarClick += tSBCliente_AceptarClick;
            this.tSBCliente.Editable = true;
            this.tSBCliente.ToolTipTSB = "Cliente";

            this.tSBAbogado.KeyMemberWidth = 70;
            this.tSBAbogado.ToolTip = "Elegir Abogado";
            this.tSBAbogado.AceptarClick += tSBAbogado_AceptarClick;
            this.tSBAbogado.Editable = true;
            this.tSBAbogado.ToolTipTSB = "Avogado";

            #endregion TextSearchBoxes

            this.rbAl.Checked = true;
            this.lblAdvertencia.Text = "Al incluir todo, el reporte puede demorar bastante en generarse." + Environment.NewLine +
                                       "Favor sea paciente o ingrese un rango de fechas.";
            this.lblAdvertencia.Visible = false;
            
        }

        

        #region Picks

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

        #region Abogado
        private void tSBAbogado_AceptarClick(object sender, EventArgs e)
        {
            if (fPickAbogado == null)
            {
                fPickAbogado = new frmPickBase();
                fPickAbogado.AceptarFiltrarClick += fPickAbogado_AceptarFiltrarClick;
                fPickAbogado.FiltrarClick += fPickAbogado_FiltrarClick;
                fPickAbogado.Titulo = "Elegir Abogado";
                fPickAbogado.CampoIDNombre = "ID";
                fPickAbogado.CampoDescripNombre = "NombrePila";
                fPickAbogado.LabelCampoID = "ID";
                fPickAbogado.LabelCampoDescrip = "Nombre";
                fPickAbogado.NombreCampo = "Abogado";
                fPickAbogado.PermitirFiltroNulo = false;
            }
            fPickAbogado.MostrarFiltro();
        }

        private void fPickAbogado_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickAbogado != null)
            {
                fPickAbogado.LoadData<Usuario>(this.DBContext.Usuario, fPickAbogado.GetWhereString());
            }
        }

        private void fPickAbogado_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBAbogado.DisplayMember = fPickAbogado.ValorDescrip;
            this.tSBAbogado.KeyMember = fPickAbogado.ValorID;

            fPickAbogado.Close();
            fPickAbogado.Dispose();
        }
        #endregion Abogado


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
            if (this.rbRango.Checked)
            {
                if (((this.txtFechaDesde.Text == "") && (this.txtFechaHasta.Text != "")) ||
                   ((this.txtFechaDesde.Text != "") && (this.txtFechaHasta.Text == "")))
                {
                    MessageBox.Show("Debe especificar fecha desde y fecha hasta.",
                                            "Atención Requerida",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Exclamation);
                    return;

                }
            }

            if (this.rbAl.Checked)
            {
                if (this.txtFechaAl.Text == "")
                {
                    MessageBox.Show("Debe especificar fecha límite para el listado",
                                            "Atención Requerida",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Exclamation);
                    return;

                }
            }

            #region Evaluar Filtros
            string clienteid = this.tSBCliente.KeyMember != "" ? this.tSBCliente.KeyMember : "";
            string abogadoid = this.tSBAbogado.KeyMember != "" ? this.tSBAbogado.KeyMember : "";

            string fechaDesde = "";
            string fechaHasta = "";
            if (this.rbAl.Checked)
            {
                fechaDesde = "";
                fechaHasta = this.txtFechaAl.Text;
            }
            else if (this.rbRango.Checked)
            {
                fechaDesde = this.txtFechaDesde.Text;
                fechaHasta = this.txtFechaHasta.Text;
            }

            string path = @"Reportes\RepListadoComision.rdlc";

            #endregion Evaluar Filtros



            List<GetListadoParaComision_Result> reportDS = new List<GetListadoParaComision_Result>();
            
            try
            {
                reportDS = this.DBContext.GetListadoParaComision(fechaDesde,
                                                                 fechaHasta,
                                                                 clienteid,
                                                                 abogadoid).ToList();
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

            string titulo = "Listado Para Comisión";
            if (this.tSBCliente.KeyMember != "")
            {
                this.tSBCliente.DisplayMember = reportDS.First().NombreCliente;
                titulo += " - " + this.tSBCliente.DisplayMember;
            }

            if (this.tSBAbogado.KeyMember != "")
            {
                this.tSBAbogado.DisplayMember = reportDS.First().Abogado;
                titulo += " - " + this.tSBAbogado.DisplayMember;
            }

            ReportDataSource datasource = null;
            datasource = new ReportDataSource("DataSet1", reportDS);

            FReportViewerBase f = new FReportViewerBase(path, datasource, this.DBContext);
            f.FormClosed += delegate { f = null; };
            f.Titulo = titulo;
            f.CantidadRegistros = "Registros encontrados: " + reportDS.Count.ToString();
            f.NombreArchivoAdjunto = "ListadoParaComision" + DateTime.Now.Ticks;
            f.AsuntoMail = titulo;
            f.ShowDialog();
        }

        private void rbAl_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbAl.Checked)
            {
                this.txtFechaAl.Enabled = true;
                this.txtFechaAl.ReadOnly = false;
                this.dtpFechaAl.Enabled = true;

                this.txtFechaDesde.Enabled = false;
                this.txtFechaDesde.ReadOnly = true;
                this.dtpFechaDesde.Enabled = false;

                this.txtFechaHasta.Enabled = false;
                this.txtFechaHasta.ReadOnly = true;
                this.dtpFechaHasta.Enabled = false;
            }
        }

        private void dtpFechaAl_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaAl.Text = this.dtpFechaAl.Value.ToShortDateString();
        }

        private void rbRango_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbRango.Checked)
            {
                this.txtFechaAl.Enabled = false;
                this.txtFechaAl.ReadOnly = true;
                this.dtpFechaAl.Enabled = false;

                this.txtFechaDesde.Enabled = true;
                this.txtFechaDesde.ReadOnly = false;
                this.dtpFechaDesde.Enabled = true;

                this.txtFechaHasta.Enabled = true;
                this.txtFechaHasta.ReadOnly = false;
                this.dtpFechaHasta.Enabled = true;
            }
        }

        private void rbTodo_CheckedChanged(object sender, EventArgs e)
        {
            this.txtFechaAl.Enabled = false;
            this.txtFechaAl.ReadOnly = true;
            this.dtpFechaAl.Enabled = false;

            this.txtFechaDesde.Enabled = false;
            this.txtFechaDesde.ReadOnly = true;
            this.dtpFechaDesde.Enabled = false;

            this.txtFechaHasta.Enabled = false;
            this.txtFechaHasta.ReadOnly = true;
            this.dtpFechaHasta.Enabled = false;

            this.lblAdvertencia.Visible = ((RadioButton)sender).Checked;
        }

        private void FRepListadoGeneralDeudas_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((IObjectContextAdapter)this.DBContext).ObjectContext.Connection.Close();
        }
    }
}