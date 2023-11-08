#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using SPF.Types;
using ModelEF6;
#endregion

namespace SPF.Forms.UI
{
    public partial class FDetalleSolArchivo : Form
    {
        #region Constantes
        private const string CAMPO_SOLPAGOARCHCABID = "SolPagoArchCabId";
        private const string CAMPO_SOLPAGOARCHCABPROVEEDORID = "SolPagoArchCabProveedorId";
        private const string CAMPO_SOLPAGOARCHCABPROVEEDORNOMBRE = "SolPagoArchCabProveedorNombre";
        private const string CAMPO_SOLPAGOARCHCABTIPOFACTURAID = "SolPagoArchCabTipoFacturaId";
        private const string CAMPO_SOLPAGOARCHCABTIPOFACTURADESCRIP = "SolPagoArchCabTipoFacturaDescrip";
        private const string CAMPO_SOLPAGOARCHCABNROFACTURA = "SolPagoArchCabNroFactura";
        private const string CAMPO_SOLPAGOARCHCABFECHAFACTURA = "SolPagoArchCabFechaFactura";
        private const string CAMPO_SOLPAGOARCHCABMONTOTOTAL = "SolPagoArchCabMontoTotal";
        private const string CAMPO_SOLPAGOARCHCABMONEDAID = "SolPagoArchCabMonedaId";
        private const string CAMPO_SOLPAGOARCHCABABREVMONEDA = "SolPagoArchCabAbrevMoneda";
        private const string CAMPO_SOLPAGOARCHCABACTIVO = "SolPagoArchCabActivo";
        private const string CAMPO_SOLPAGOARCHCABCLIENTEID = "SolPagoArchCabClienteId";
        private const string CAMPO_SOLPAGOARCHCABCLIENTENOMBRE = "SolPagoArchCabClienteNombre";
        private const string CAMPO_SOLPAGOARCHCABSOLPAGOCABID = "SolPagoArchCabSolPagoCabId";
        private const string CAMPO_SOLPAGOARCHDETSOLPAGODETID = "SolPagoArchDetSolPagoDetId";
        private const string CAMPO_SOLPAGOARCHDETCANTIDADIVA10 = "SolPagoArchDetCantidadIVA10";
        private const string CAMPO_SOLPAGOARCHDETPRECIOUNITARIOIVA10 = "SolPagoArchDetPrecioUnitarioIVA10";
        private const string CAMPO_SOLPAGOARCHDETSOLPAGODETTOTAL = "SolPagoArchDetSolPagoDetTotal";


        private const string FORMATO_MONEDA_GUARANIES_GRILLA = "N0";
        private const string FORMATO_MONEDA_OTROS_GRILLA = "N2";
        private const string FORMAT_MONEDA_GUARANIES = "{0:n0}";
        private const string FORMAT_MONEDA_OTROS = "{0:n2}";

        private const int MONEDA_GUARANIES = 3;
        #endregion Constantes

        #region Variables
        List<ListaSolArchivo> lSolArchivo;
        #endregion Variables

        #region Propiedades
        public List<ListaSolArchivo> ListaSolicitudes
        {
            set { this.lSolArchivo = value; }
            get { return this.lSolArchivo; }
        }
        #endregion Propiedades

        public FDetalleSolArchivo(List<ListaSolArchivo> lSolArchivo)
        {
            InitializeComponent();
            this.Text = "Detalle de Solicitudes";
            this.ListaSolicitudes = lSolArchivo;

            this.txtProveedor.Text = this.ListaSolicitudes.First().SolPagoArchCabProveedorNombre + 
                                        " (" + this.ListaSolicitudes.First().SolPagoArchCabProveedorId.ToString() + ")";
            this.txtNroFactura.Text = this.ListaSolicitudes.First().SolPagoArchCabNroFactura;
            this.txtFechaFactura.Text = this.ListaSolicitudes.First().SolPagoArchCabFechaFactura.ToShortDateString();
            this.txtTipoFactura.Text = this.ListaSolicitudes.First().SolPagoArchCabTipoFacturaDescrip;

            //Formato monto
            string formato = this.ListaSolicitudes.First().SolPagoArchCabMonedaId == MONEDA_GUARANIES ? FORMAT_MONEDA_GUARANIES : FORMAT_MONEDA_OTROS;

            this.txtTotal.Text = this.ListaSolicitudes.First().SolPagoArchCabMonedaAbrev + 
                                    " " + string.Format(formato, this.ListaSolicitudes.First().SolPagoArchCabMontoTotal);
            this.dgvDetSolArchivo.DataSource = this.ListaSolicitudes;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FormatearGrila()
        {
            this.dgvDetSolArchivo.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Pixel);
            this.dgvDetSolArchivo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvDetSolArchivo.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvDetSolArchivo.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dgvDetSolArchivo.DefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvDetSolArchivo.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvDetSolArchivo.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            this.dgvDetSolArchivo.ItemsPerPage = 13;
            this.dgvDetSolArchivo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetSolArchivo.MultiSelect = false;

            foreach (DataGridViewColumn col in this.dgvDetSolArchivo.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            //this.dgvDetSolArchivo.ReadOnly = false;
            //this.dgvDetSolArchivo.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //this.dgvDetSolArchivo.ItemsPerPage = 13;
            //this.dgvDetSolArchivo.ShowCellToolTips = true;
            //this.dgvDetSolArchivo.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            //this.dgvDetSolArchivo.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            //this.dgvDetSolArchivo.DefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            //this.dgvDetSolArchivo.DefaultCellStyle.BackColor = Color.Transparent;

            this.dgvDetSolArchivo.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;

            int displayIndex = 0;

            this.dgvDetSolArchivo.Columns[CAMPO_SOLPAGOARCHCABSOLPAGOCABID].HeaderText = "Id. Sol. Pago";
            this.dgvDetSolArchivo.Columns[CAMPO_SOLPAGOARCHCABSOLPAGOCABID].Width = 100;
            this.dgvDetSolArchivo.Columns[CAMPO_SOLPAGOARCHCABSOLPAGOCABID].DisplayIndex = displayIndex;
            this.dgvDetSolArchivo.Columns[CAMPO_SOLPAGOARCHCABSOLPAGOCABID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvDetSolArchivo.Columns[CAMPO_SOLPAGOARCHCABSOLPAGOCABID].Visible = true;
            displayIndex++;

            this.dgvDetSolArchivo.Columns[CAMPO_SOLPAGOARCHCABCLIENTENOMBRE].HeaderText = "Cliente";
            this.dgvDetSolArchivo.Columns[CAMPO_SOLPAGOARCHCABCLIENTENOMBRE].Width = 170;
            this.dgvDetSolArchivo.Columns[CAMPO_SOLPAGOARCHCABCLIENTENOMBRE].DisplayIndex = displayIndex;
            this.dgvDetSolArchivo.Columns[CAMPO_SOLPAGOARCHCABCLIENTENOMBRE].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvDetSolArchivo.Columns[CAMPO_SOLPAGOARCHCABCLIENTENOMBRE].Visible = true;
            displayIndex++;

            this.dgvDetSolArchivo.Columns[CAMPO_SOLPAGOARCHDETCANTIDADIVA10].HeaderText = "Cantidad";
            this.dgvDetSolArchivo.Columns[CAMPO_SOLPAGOARCHDETCANTIDADIVA10].Width = 60;
            this.dgvDetSolArchivo.Columns[CAMPO_SOLPAGOARCHDETCANTIDADIVA10].DisplayIndex = displayIndex;
            this.dgvDetSolArchivo.Columns[CAMPO_SOLPAGOARCHDETCANTIDADIVA10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvDetSolArchivo.Columns[CAMPO_SOLPAGOARCHDETCANTIDADIVA10].DefaultCellStyle.Format = "N0";
            this.dgvDetSolArchivo.Columns[CAMPO_SOLPAGOARCHDETCANTIDADIVA10].Visible = true;
            displayIndex++;

            this.dgvDetSolArchivo.Columns[CAMPO_SOLPAGOARCHDETPRECIOUNITARIOIVA10].HeaderText = "Prec. Unitario";
            this.dgvDetSolArchivo.Columns[CAMPO_SOLPAGOARCHDETPRECIOUNITARIOIVA10].Width = 100;
            this.dgvDetSolArchivo.Columns[CAMPO_SOLPAGOARCHDETPRECIOUNITARIOIVA10].DisplayIndex = displayIndex;
            this.dgvDetSolArchivo.Columns[CAMPO_SOLPAGOARCHDETPRECIOUNITARIOIVA10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvDetSolArchivo.Columns[CAMPO_SOLPAGOARCHDETPRECIOUNITARIOIVA10].DefaultCellStyle.Format = "N0";
            this.dgvDetSolArchivo.Columns[CAMPO_SOLPAGOARCHDETPRECIOUNITARIOIVA10].Visible = true;
            displayIndex++;

            this.dgvDetSolArchivo.Columns[CAMPO_SOLPAGOARCHDETSOLPAGODETTOTAL].HeaderText = "Prec. Total";
            this.dgvDetSolArchivo.Columns[CAMPO_SOLPAGOARCHDETSOLPAGODETTOTAL].Width = 100;
            this.dgvDetSolArchivo.Columns[CAMPO_SOLPAGOARCHDETSOLPAGODETTOTAL].DisplayIndex = displayIndex;
            this.dgvDetSolArchivo.Columns[CAMPO_SOLPAGOARCHDETSOLPAGODETTOTAL].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvDetSolArchivo.Columns[CAMPO_SOLPAGOARCHDETSOLPAGODETTOTAL].DefaultCellStyle.Format = "N0";
            this.dgvDetSolArchivo.Columns[CAMPO_SOLPAGOARCHDETSOLPAGODETTOTAL].Visible = true;
            displayIndex++;
        }

        private void FDetallePresupuestoMerge_VisibleChanged(object sender, EventArgs e)
        {
            this.FormatearGrila();
        }

        private void dgvDetalleClienteDeuda_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if ((e.RowIndex > -1) && (e.ColumnIndex == (((DataGridView)sender).Columns[CAMPO_SALDO].Index)))
            //{
            //    if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_MONEDA].Value.ToString() == "G")
            //        e.CellStyle.Format = FORMATO_MONEDA_GUARANIES_GRILLA;
            //    else
            //        e.CellStyle.Format = FORMATO_MONEDA_OTROS_GRILLA;
            //}
        }
    }
}