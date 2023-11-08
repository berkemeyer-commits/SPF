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
    public partial class FRepListadoGeneralDeudas : Form
    {
        #region Variables
        frmPickBase fPickCliente;
        BerkeDBEntities DBContext;
        #endregion Variables

        #region Constantes
        public const string ESTADO_PENDIENTE = "A";
        public const string ESTADO_PAGADO = "P";
        public const string ESTADO_ANULADO = "N";
        #endregion Constantes

        public FRepListadoGeneralDeudas()
        {
            InitializeComponent();
        }

        public FRepListadoGeneralDeudas(string titulo, BerkeDBEntities context = null)
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
            #endregion TextSearchBoxes

            this.rbAl.Checked = true;
            this.lblAdvertencia.Text = "Al incluir todas las deudas, el reporte puede demorar bastante en generarse." + Environment.NewLine +
                                       "Favor sea paciente o ingrese un rango de fechas.";
            this.lblAdvertencia.Visible = false;
            this.cargarCBEstados();
        }

        private void cargarCBEstados()
        {
            List<Estado> estados = new List<Estado>();
            estados.Add(new Estado { Codigo = "", Nombre = "Todos" });
            estados.Add(new Estado { Codigo = ESTADO_PENDIENTE, Nombre = "Pendientes" });
            estados.Add(new Estado { Codigo = ESTADO_PAGADO, Nombre = "Pagados" });
            estados.Add(new Estado { Codigo = ESTADO_ANULADO, Nombre = "Anulados" });

            this.cbEstados.DataSource = estados;
            this.cbEstados.ValueMember = "Codigo";
            this.cbEstados.DisplayMember = "Nombre";
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

            string estado = this.cbEstados.SelectedValue.ToString();

            string path = "";
              
            
            if (this.chkDatosClienteLocales.Checked)
            {
                if (this.chkIncluirFechaPago.Checked)
                {
                    path = @"Reportes\RepListadoGeneralDeudasConDatosClientesPYConFechaPago.rdlc";
                }
                else
                {
                    path = @"Reportes\RepListadoGeneralDeudasConDatosClientesPY.rdlc";
                }
            }
            else
            {
                if (this.chkIncluirFechaPago.Checked)
                {
                    path = @"Reportes\RepListadoGeneralDeudasConFechaPago.rdlc";
                }   
                else
                {
                    path = @"Reportes\RepListadoGeneralDeudas.rdlc";
                }
            }

            #endregion Evaluar Filtros



            List<GetListadoGeneraldeDeudas_Result> reportDS = new List<GetListadoGeneraldeDeudas_Result>();
            
            try
            {
                reportDS = this.DBContext.GetListadoGeneraldeDeudas(fechaDesde,
                                                                    fechaHasta,
                                                                    clienteid,
                                                                    estado,
                                                                    this.chkDatosClienteLocales.Checked,
                                                                    this.chkIncluirFechaPago.Checked).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al generar el reporte: " + Environment.NewLine + ex.Message, "Información de Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (reportDS.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte con los criterios ingresados.",
                                "Atención Requerida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            if (this.tSBCliente.KeyMember != "")
            {
                this.tSBCliente.DisplayMember = reportDS.First().NombreCliente;
            }
            
            ReportDataSource datasource = null;
            datasource = new ReportDataSource("DataSet1", reportDS);

            FReportViewerBase f = new FReportViewerBase(path, datasource, this.DBContext);
            f.FormClosed += delegate { f = null; };
            f.Titulo = "Listado General de Deudas - " + this.tSBCliente.DisplayMember;
            f.CantidadRegistros = "Registros encontrados: " + reportDS.Count.ToString();
            f.NombreArchivoAdjunto = "ListadoGeneralDeudas" + DateTime.Now.Ticks;
            f.AsuntoMail = "Listado General de Deudas";
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