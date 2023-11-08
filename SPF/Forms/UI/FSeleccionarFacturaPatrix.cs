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
    public partial class FSeleccionarFacturaPatrix : Form
    {
        #region Variables
        #endregion Variables
        
        #region Constantes
        private const string CAMPO_CASENUMBER = "CaseNumber";
        private const string CAMPO_CASEID = "CaseID";
        private const string CAMPO_INVOICEID = "InvoiceID";
        private const string CAMPO_MONTO = "Monto";
        private const string CAMPO_MONEDAABREV = "MonedaAbrev";
        private const string CAMPO_CLIENTENOMBRE = "ClienteNombre";
        private const string CAMPO_FECHAFACTURA ="FechaFactura";

        private const string FORMATO_MONEDA_OTROS_GRILLA = "N2";
        #endregion Constantes

        public event EventHandler AceptarFiltrarClick;

        #region Métodos de Inicio
        public FSeleccionarFacturaPatrix()
        {
            InitializeComponent();
        }

        public FSeleccionarFacturaPatrix(List<FacturaPatrixType> listaFacturas)
        {
            InitializeComponent();
            this.Text = "Seleccionar Factura de Sistema Patricia";            
            this.SetGridDataSource(listaFacturas);
        }

        private void FSeleccionarProveedor_Load(object sender, EventArgs e)
        {
            this.FormatearGrilla();

            if (this.dgvFacturasPatricia.Rows.Count > 0)
            {
                this.dgvFacturasPatricia.CurrentCell = this.dgvFacturasPatricia.Rows[0].Cells[CAMPO_INVOICEID];
                this.dgvFacturasPatricia.Focus();
            }
        }

        private void SetGridDataSource(List<FacturaPatrixType> listaFacturas)
        {
            this.dgvFacturasPatricia.DataSource = listaFacturas;
            this.FormatearGrilla();
        }
        #endregion Métodos de Inicio

        #region Métodos de Apoyo
        private void FormatearGrilla()
        {
            this.dgvFacturasPatricia.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvFacturasPatricia.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dgvFacturasPatricia.DefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvFacturasPatricia.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvFacturasPatricia.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            this.dgvFacturasPatricia.ItemsPerPage = 6;
            this.dgvFacturasPatricia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvFacturasPatricia.MultiSelect = false;

            foreach (DataGridViewColumn col in this.dgvFacturasPatricia.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            int displayIndex = 0;

            this.dgvFacturasPatricia.Columns[CAMPO_INVOICEID].Visible = true;
            this.dgvFacturasPatricia.Columns[CAMPO_INVOICEID].DisplayIndex = displayIndex;
            this.dgvFacturasPatricia.Columns[CAMPO_INVOICEID].HeaderText = "Caso ID";
            this.dgvFacturasPatricia.Columns[CAMPO_INVOICEID].Width = 70;
            this.dgvFacturasPatricia.Columns[CAMPO_INVOICEID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            displayIndex++;

            this.dgvFacturasPatricia.Columns[CAMPO_CASENUMBER].Visible = true;
            this.dgvFacturasPatricia.Columns[CAMPO_CASENUMBER].DisplayIndex = displayIndex;
            this.dgvFacturasPatricia.Columns[CAMPO_CASENUMBER].HeaderText = "N° Caso";
            this.dgvFacturasPatricia.Columns[CAMPO_CASENUMBER].Width = 80;
            displayIndex++;

            this.dgvFacturasPatricia.Columns[CAMPO_CLIENTENOMBRE].Visible = true;
            this.dgvFacturasPatricia.Columns[CAMPO_CLIENTENOMBRE].DisplayIndex = displayIndex;
            this.dgvFacturasPatricia.Columns[CAMPO_CLIENTENOMBRE].HeaderText = "Nombre Cliente";
            this.dgvFacturasPatricia.Columns[CAMPO_CLIENTENOMBRE].Width = 250;
            displayIndex++;

            this.dgvFacturasPatricia.Columns[CAMPO_MONEDAABREV].Visible = true;
            this.dgvFacturasPatricia.Columns[CAMPO_MONEDAABREV].DisplayIndex = displayIndex;
            this.dgvFacturasPatricia.Columns[CAMPO_MONEDAABREV].HeaderText = "Moneda";
            this.dgvFacturasPatricia.Columns[CAMPO_MONEDAABREV].Width = 80;
            displayIndex++;

            this.dgvFacturasPatricia.Columns[CAMPO_MONTO].Visible = true;
            this.dgvFacturasPatricia.Columns[CAMPO_MONTO].DisplayIndex = displayIndex;
            this.dgvFacturasPatricia.Columns[CAMPO_MONTO].HeaderText = "Monto";
            this.dgvFacturasPatricia.Columns[CAMPO_MONTO].Width = 70;
            this.dgvFacturasPatricia.Columns[CAMPO_MONTO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvFacturasPatricia.Columns[CAMPO_MONTO].DefaultCellStyle.Format = FORMATO_MONEDA_OTROS_GRILLA;
            displayIndex++;
        }

        #endregion Métodos de Apoyo

        #region Métodos sobre Controles Locales
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int GetInvoiceID()
        {
            return (int)this.dgvFacturasPatricia.CurrentRow.Cells[CAMPO_INVOICEID].Value;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.dgvFacturasPatricia.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar alguna factura.",
                                "Atención Requerida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            if (this.AceptarFiltrarClick != null)
            {
                this.AceptarFiltrarClick(sender, e);
            }
            
        }
        #endregion Métodos sobre Controles Locales

        
    }
}