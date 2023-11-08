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
    public partial class FRepListadoCotizacionesPorRango : Form
    {
        #region Variables
        frmPickBase fPickCliente;
        BerkeDBEntities DBContext;
        #endregion Variables

        #region Constantes
        public const string CAMPO_CLIENTEID = "ClienteID";
        public const string CAMPO_FECHACOTIZACION = "FechaCotizacion";
        public const string CAMPO_CONFIRMADO = "Confirmado";
        public const string RANGO = "(FechaCotizacionDate BETWEEN '{0}' AND '{1}')";
        public const string HASTA = "(FechaCotizacionDate <= '{0}')";
        public const string RANGO_FECHA_CONFIRMACION = "(FechaConfirmacionDate BETWEEN '{0}' AND '{1}')";
        public const string HASTA_FECHA_CONFIRMACION = "(FechaConfirmacionDate <= '{0}')";
        public const string CLIENTE = "(ClienteID = {0})";
        public const string CONFIRMADO = "(ConfirmadoVal = {0})";
        public const string AND = " AND ";
        public const string UNO = "1";
        public const string CERO = "0";
        #endregion Constantes

        public FRepListadoCotizacionesPorRango()
        {
            InitializeComponent();
        }

        public FRepListadoCotizacionesPorRango(string titulo, BerkeDBEntities context = null)
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
            this.cargarCBEstados();
        }

        private void cargarCBEstados()
        {
            List<EstadoCotizacion> estados = new List<EstadoCotizacion>();
            estados.Add(new EstadoCotizacion { Confirmado = null, Nombre = "Omitir" });
            estados.Add(new EstadoCotizacion { Confirmado = true, Nombre = "Sí" });
            estados.Add(new EstadoCotizacion { Confirmado = false, Nombre = "No" });

            this.cbEstados.DataSource = estados;
            this.cbEstados.ValueMember = "Confirmado";
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
            string clienteid = this.tSBCliente.KeyMember != String.Empty ? this.tSBCliente.KeyMember : String.Empty;;

            string whereString = String.Empty;

            whereString += clienteid != String.Empty ? String.Format(CLIENTE, clienteid) : String.Empty;

            string fechaDesde = "";
            string fechaHasta = "";
            string whereFecha = String.Empty;

            Nullable<bool> confirmado = null;

            if (this.cbEstados.SelectedValue != null)
            {
                confirmado = (bool)this.cbEstados.SelectedValue;
                string whereConfirmado = confirmado.Value ? String.Format(CONFIRMADO, UNO) : String.Format(CONFIRMADO, CERO);
                whereString += (whereString != String.Empty ? AND : String.Empty) + whereConfirmado;
            }

            if (this.rbAl.Checked)
            {
                fechaDesde = "";
                fechaHasta = this.txtFechaAl.Text;
                whereFecha = String.Format(confirmado.HasValue && confirmado.Value ? HASTA_FECHA_CONFIRMACION : HASTA, fechaHasta);
            }
            else if (this.rbRango.Checked)
            {
                fechaDesde = this.txtFechaDesde.Text;
                fechaHasta = this.txtFechaHasta.Text;
                whereFecha = String.Format(confirmado.HasValue && confirmado.Value ? RANGO_FECHA_CONFIRMACION : RANGO, fechaDesde, fechaHasta);
            }

            if (whereFecha != String.Empty)
                whereString += (whereString != String.Empty ? AND : String.Empty) + whereFecha;
            
            //Nullable<bool> confirmado = null;

            //if (this.cbEstados.SelectedValue != null)
            //{
            //    confirmado = (bool)this.cbEstados.SelectedValue;
            //    string whereConfirmado = confirmado.Value ? String.Format(CONFIRMADO, UNO) : String.Format(CONFIRMADO, CERO);
            //    whereString += (whereString != String.Empty ? AND : String.Empty) + whereConfirmado;

            //}

            
            string path = @"Reportes\RepListadoCotizacionesPorRango.rdlc";

            

            #endregion Evaluar Filtros



            List<GetListadoCotizaciones_Result> reportDS = new List<GetListadoCotizaciones_Result>();
            
            try
            {
                reportDS = this.DBContext.GetListadoCotizaciones(whereString).ToList();
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

            if (this.tSBCliente.KeyMember != "")
            {
                this.tSBCliente.DisplayMember = reportDS.First().ClienteNombre;
            }
            
            ReportDataSource datasource = null;
            datasource = new ReportDataSource("DataSet1", reportDS);

            FReportViewerBase f = new FReportViewerBase(path, datasource, this.DBContext);
            f.FormClosed += delegate { f = null; };
            f.Titulo = "Listado de Cotizaciones";
            f.CantidadRegistros = "Registros encontrados: " + reportDS.Count.ToString();
            f.NombreArchivoAdjunto = "ListadoDeCotizaciones" + DateTime.Now.Ticks;
            f.AsuntoMail = "Listado de Cotizaciones";
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

        }

        private void FRepListadoGeneralDeudas_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((IObjectContextAdapter)this.DBContext).ObjectContext.Connection.Close();
        }
    }
}