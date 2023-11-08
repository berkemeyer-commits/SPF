#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using ModelEF6;
using SPF.Forms;
using SPF.Types;
using System.Data.Entity;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Dynamic;

using System.Data.SqlClient;
using System.Collections;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text.RegularExpressions;

using SPF.Forms.Base;
using SPF.Base;
using Microsoft.Reporting.WebForms;

#endregion

namespace SPF.Forms.UI
{
    public partial class FSeleccionarProveedor : Form
    {
        #region Variables
        private BerkeDBEntities DBContext;
        private List<int> ListaProveedorID;
        private int SolPagoCabID;
        #endregion Variables
        
        #region Constantes
        const string DEFAULT_STRING_PATTERN = "( {0} = {1} )";
        private const string CAMPO_PROVEEDORID = "ProveedorID";
        private const string CAMPO_PROVEEDORNOMBRE = "NombreProveedor";
        private const string CAMPO_PROVEEDORRUC = "RUCProveedor";
        private const string CAMPO_PROVEEDORDIRECCION = "DireccionProveedor";
        private const string CUERPO_MAIL = "Favor confirmar el presente pedido en la brevedad posible. Muchas gracias.";
        #endregion Constantes

        #region Métodos de Inicio
        public FSeleccionarProveedor()
        {
            InitializeComponent();
        }
        
        public FSeleccionarProveedor(int solpagocabid, List<int> listaProveedorID, BerkeDBEntities context)
        {
            InitializeComponent();

            this.Text = "Impresión de Orden de Trabajo - Seleccionar Proveedor";
            this.DBContext = context;
            this.ListaProveedorID = listaProveedorID;
            this.SolPagoCabID = solpagocabid;
            this.SetGridDataSource();
        }

        private void FSeleccionarProveedor_Load(object sender, EventArgs e)
        {
            this.FormatearGrilla();

            if (this.dgvProveedores.Rows.Count > 0)
            {
                this.dgvProveedores.CurrentCell = this.dgvProveedores.Rows[0].Cells[CAMPO_PROVEEDORID];
                this.dgvProveedores.Focus();
            }
        }

        private void SetGridDataSource()
        {
            string sqlWhere = this.GetFilterStringProveedorID();
            var query = (from prov in this.DBContext.pr_proveedor
                         select new
                         {
                             ProveedorID = prov.pr_proveedorid,
                             NombreProveedor = prov.pr_nombre,
                             RUCProveedor = prov.pr_ruc,
                             DireccionProveedor = prov.pr_direccion
                         })
                        .Where(sqlWhere)
                        .ToList();

            this.dgvProveedores.DataSource = query;
            this.FormatearGrilla();
        }
        #endregion Métodos de Inicio

        #region Métodos de Apoyo
        private string GetFilterStringProveedorID()
        {
            string gFiltro = "";
            foreach (int id in this.ListaProveedorID)
            {
                if (gFiltro != "")
                    gFiltro += " OR ";

                gFiltro += String.Format(DEFAULT_STRING_PATTERN, CAMPO_PROVEEDORID, id.ToString());
            }
            return " (" + gFiltro + ") ";
        }

        private void FormatearGrilla()
        {
            this.dgvProveedores.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvProveedores.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dgvProveedores.DefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvProveedores.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvProveedores.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            this.dgvProveedores.ItemsPerPage = 6;
            this.dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvProveedores.MultiSelect = false;

            foreach (DataGridViewColumn col in this.dgvProveedores.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            int displayIndex = 0;

            this.dgvProveedores.Columns[CAMPO_PROVEEDORID].Visible = true;
            this.dgvProveedores.Columns[CAMPO_PROVEEDORID].DisplayIndex = displayIndex;
            this.dgvProveedores.Columns[CAMPO_PROVEEDORID].HeaderText = "ID";
            this.dgvProveedores.Columns[CAMPO_PROVEEDORID].Width = 70;
            this.dgvProveedores.Columns[CAMPO_PROVEEDORID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            displayIndex++;

            this.dgvProveedores.Columns[CAMPO_PROVEEDORNOMBRE].Visible = true;
            this.dgvProveedores.Columns[CAMPO_PROVEEDORNOMBRE].DisplayIndex = displayIndex;
            this.dgvProveedores.Columns[CAMPO_PROVEEDORNOMBRE].HeaderText = "Nombre";
            this.dgvProveedores.Columns[CAMPO_PROVEEDORNOMBRE].Width = 300;
            displayIndex++;

            this.dgvProveedores.Columns[CAMPO_PROVEEDORRUC].Visible = true;
            this.dgvProveedores.Columns[CAMPO_PROVEEDORRUC].DisplayIndex = displayIndex;
            this.dgvProveedores.Columns[CAMPO_PROVEEDORRUC].HeaderText = "RUC";
            this.dgvProveedores.Columns[CAMPO_PROVEEDORRUC].Width = 80;
            displayIndex++;

            this.dgvProveedores.Columns[CAMPO_PROVEEDORDIRECCION].Visible = true;
            this.dgvProveedores.Columns[CAMPO_PROVEEDORDIRECCION].DisplayIndex = displayIndex;
            this.dgvProveedores.Columns[CAMPO_PROVEEDORDIRECCION].HeaderText = "Dirección";
            this.dgvProveedores.Columns[CAMPO_PROVEEDORDIRECCION].Width = 300;
            displayIndex++;
        }


        private void GenerarReporteOTProveedor()
        {
            int ProveedorID = (int)this.dgvProveedores.CurrentRow.Cells[CAMPO_PROVEEDORID].Value;

            List<SolPagoImpresionDataSet1> reportDS = new List<SolPagoImpresionDataSet1>();

            try
            {
                reportDS = (from spd in this.DBContext.spd_solicitudpagodet
                            join prov in this.DBContext.pr_proveedor
                             on spd.spd_proveedorid equals prov.pr_proveedorid
                            join tar in this.DBContext.Tarifas
                             on spd.spd_tarifaid equals tar.ID
                            join usu in this.DBContext.Usuario
                             on spd.spd_solicitadopor equals usu.ID
                            select new SolPagoImpresionDataSet1
                            {
                                FechaSolicitudDet = spd.spd_fechasol,
                                ProveedorID = spd.spd_proveedorid,
                                NombreProveedor = prov.pr_nombre,
                                RUCProveedor = prov.pr_ruc,
                                DireccionProveedor = prov.pr_direccion,
                                SolPagoCabID = spd.spd_solicitudpagocabid,
                                Cantidad = spd.spd_cantidad + spd.spd_cantidadiva5 + spd.spd_cantidadiva10,
                                TarifaDescrip = tar.DescripcionFactura,
                                SolicitadoPor = usu.NombrePila
                            })
                           .Where(a => a.SolPagoCabID == this.SolPagoCabID && a.ProveedorID == ProveedorID)
                           .ToList();
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

            List<SolPagoImpresionDataSet2> reportDS2 = new List<SolPagoImpresionDataSet2>();
            reportDS2.Add(new SolPagoImpresionDataSet2 { HechoPor = VWGContext.Current.Session["NombreUsuario"].ToString() });

            ReportDataSource datasource = null;
            datasource = new ReportDataSource("DataSet1", reportDS);

            ReportDataSource datasource2 = null;
            datasource2 = new ReportDataSource("DataSet2", reportDS2);

            string path = @"Reportes\RepOrdenTrabajo.rdlc";

            List<ReportDataSource> rptDS = new List<ReportDataSource>();
            rptDS.Add(datasource);
            rptDS.Add(datasource2);

            FReportViewerBase f = new FReportViewerBase(path, rptDS, this.DBContext);
            f.FormClosed += delegate { f = null; };
            f.Titulo = "Orden de Trabajo N° " + this.SolPagoCabID.ToString();
            f.CantidadRegistros = "Registros encontrados: " + reportDS.Count.ToString();
            f.NombreArchivoAdjunto = "OrdenTrabajo-" + this.SolPagoCabID.ToString() + DateTime.Now.Ticks;
            f.AsuntoMail = "Orden de Trabajo";
            f.CuerpoMail = CUERPO_MAIL;
            f.ShowDialog();
        }

        private void GenerarReporteOTInterno()
        {
            int ProveedorID = (int)this.dgvProveedores.CurrentRow.Cells[CAMPO_PROVEEDORID].Value;

            List<SolPagoImpresionDataSet1> reportDS = new List<SolPagoImpresionDataSet1>();

            try
            {
                reportDS = (from spc in this.DBContext.spc_solicitudpagocab
                            join spd in this.DBContext.spd_solicitudpagodet
                             on spc.spc_solicitudpagocabid equals spd.spd_solicitudpagocabid
                            join prov in this.DBContext.pr_proveedor
                             on spd.spd_proveedorid equals prov.pr_proveedorid
                            join tar in this.DBContext.Tarifas
                             on spd.spd_tarifaid equals tar.ID
                            join usu in this.DBContext.Usuario
                             on spd.spd_solicitadopor equals usu.ID
                            join corr in this.DBContext.Correspondencia
                             on spd.spd_correspondenciaid equals corr.ID into corr_spd
                             from corr in corr_spd.DefaultIfEmpty()
                            join tra in this.DBContext.Tramite
                             on spc.spc_tramiteid equals tra.ID into tra_spc
                             from tra in tra_spc.DefaultIfEmpty()
                            join cli in this.DBContext.Cliente
                             on spc.spc_clienteid equals cli.ID into cli_spc
                             from cli in cli_spc.DefaultIfEmpty()
                            join mon in this.DBContext.Moneda
                             on spc.spc_monedaid equals mon.ID
                            select new SolPagoImpresionDataSet1
                            {
                                FechaSolicitudDet = spd.spd_fechasol,
                                ProveedorID = spd.spd_proveedorid,
                                NombreProveedor = prov.pr_nombre,
                                RUCProveedor = prov.pr_ruc,
                                DireccionProveedor = prov.pr_direccion,
                                SolPagoCabID = spd.spd_solicitudpagocabid,
                                Cantidad = spd.spd_cantidad + spd.spd_cantidadiva5 + spd.spd_cantidadiva10,
                                TarifaDescrip = tar.DescripcionFactura,
                                CorrespNro = corr.Nro,
                                CorrespAnio = corr.Anio,
                                Monto = spd.spd_total,
                                ActaNro = spc.spc_actanro,
                                ActaAnio = spc.spc_actaanio,
                                HINro = spc.spc_hinro,
                                HIAnio = spc.spc_hianio,
                                SolicitadoPor = usu.NombrePila,
                                Tramite = tra.EtiquetaEsp,
                                Cliente = cli.Nombre,
                                Moneda = mon.Descripcion,
                                Observacion = spc.spc_observacion,
                                Referencia = spc.spc_refcliente,
                                Facturable = spd.spd_facturable,
                                Reembolsable = spd.spd_reembolsable
                            })
                           .Where(a => a.SolPagoCabID == this.SolPagoCabID && a.ProveedorID == ProveedorID)
                           .ToList();
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

            List<SolPagoImpresionDataSet2> reportDS2 = new List<SolPagoImpresionDataSet2>();
            reportDS2.Add(new SolPagoImpresionDataSet2 { HechoPor = VWGContext.Current.Session["NombreUsuario"].ToString() });

            ReportDataSource datasource = null;
            datasource = new ReportDataSource("DataSet1", reportDS);

            ReportDataSource datasource2 = null;
            datasource2 = new ReportDataSource("DataSet2", reportDS2);

            string path = @"Reportes\RepOrdenTrabajoInterno.rdlc";

            List<ReportDataSource> rptDS = new List<ReportDataSource>();
            rptDS.Add(datasource);
            rptDS.Add(datasource2);

            FReportViewerBase f = new FReportViewerBase(path, rptDS, this.DBContext);
            f.FormClosed += delegate { f = null; };
            f.Titulo = "Orden de Trabajo N° " + this.SolPagoCabID.ToString();
            f.CantidadRegistros = "Registros encontrados: " + reportDS.Count.ToString();
            f.NombreArchivoAdjunto = "OrdenTrabajo-" + this.SolPagoCabID.ToString() + DateTime.Now.Ticks;
            f.AsuntoMail = "Orden de Trabajo";
            f.CuerpoMail = CUERPO_MAIL;
            f.ShowDialog();
        }

        #endregion Métodos de Apoyo

        #region Métodos sobre Controles Locales
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.dgvProveedores.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un proveedor de la grilla.",
                                "Atención Requerida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            if (this.rbOTProveedor.Checked)
                this.GenerarReporteOTProveedor();
            else if (this.rbOTInterno.Checked)
                this.GenerarReporteOTInterno();
            
        }
        #endregion Métodos sobre Controles Locales

        private void grpTipoReporte_Click(object sender, EventArgs e)
        {

        }
    }
}