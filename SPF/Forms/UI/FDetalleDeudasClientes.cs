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
    public partial class FDetalleDeudasClientes : Form
    {
        #region Constantes
        public const string CAMPO_FECHADOCUMENTO = "FechaDocumento";
        public const string CAMPO_CLIENTE = "ClienteID";// Cab
        public const string CAMPO_CLIENTENOMBRE = "ClienteNombre";// Cab
        public const string CAMPO_DOCUMENTONRO = "DocumentoNro";
        public const string CAMPO_SALDO = "Saldo";
        public const string CAMPO_MONEDA = "Moneda";// Cab
        public const string CAMPO_NOMBRETRAMITE = "NombreTramite";
        public const string CAMPO_DESCRIPAREA = "DescripArea";
        public const string CAMPO_DESCRIPUNIDADNEGOCIO = "DescripUnindadNegocio";
        public const string CAMPO_PAIS = "Pais";// Cab
        public const string CAMPO_HI = "HI";
        public const string CAMPO_ACTA = "Acta";


        private const string FORMATO_MONEDA_GUARANIES_GRILLA = "N0";
        private const string FORMATO_MONEDA_OTROS_GRILLA = "N2";
        #endregion Constantes

        public FDetalleDeudasClientes()
        {
            InitializeComponent();
            this.Text = "Detalle de Deudas del Cliente";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void AddData(List<GetListadoGeneraldeDeudasPendientes_Result> detalle)
        {
            GetListadoGeneraldeDeudasPendientes_Result cab = detalle.First();
            this.txtClienteID.Text = cab.ClienteID.ToString();
            this.txtClienteNombre.Text = cab.NombreCliente;
            this.txtPais.Text = cab.Pais;
            this.txtMoneda.Text = cab.Moneda;

            this.dgvDetalleClienteDeuda.DataSource = detalle;
            
        }

        public void FormatearGrila()
        {
            foreach (DataGridViewColumn col in this.dgvDetalleClienteDeuda.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            this.dgvDetalleClienteDeuda.ReadOnly = false;
            this.dgvDetalleClienteDeuda.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.dgvDetalleClienteDeuda.ItemsPerPage = 13;
            this.dgvDetalleClienteDeuda.ShowCellToolTips = true;
            this.dgvDetalleClienteDeuda.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvDetalleClienteDeuda.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvDetalleClienteDeuda.DefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvDetalleClienteDeuda.DefaultCellStyle.BackColor = Color.Transparent;

            this.dgvDetalleClienteDeuda.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;

            int displayIndex = 0;

            dgvDetalleClienteDeuda.Columns[CAMPO_FECHADOCUMENTO].Visible = true;
            dgvDetalleClienteDeuda.Columns[CAMPO_FECHADOCUMENTO].DisplayIndex = displayIndex;
            dgvDetalleClienteDeuda.Columns[CAMPO_FECHADOCUMENTO].Width = 90;
            dgvDetalleClienteDeuda.Columns[CAMPO_FECHADOCUMENTO].HeaderText = "Fec. Doc.";
            dgvDetalleClienteDeuda.Columns[CAMPO_FECHADOCUMENTO].Visible = true;
            displayIndex++;

            dgvDetalleClienteDeuda.Columns[CAMPO_DOCUMENTONRO].Visible = true;
            dgvDetalleClienteDeuda.Columns[CAMPO_DOCUMENTONRO].DisplayIndex = displayIndex;
            dgvDetalleClienteDeuda.Columns[CAMPO_DOCUMENTONRO].HeaderText = "N° Documento";
            dgvDetalleClienteDeuda.Columns[CAMPO_DOCUMENTONRO].Width = 110;
            dgvDetalleClienteDeuda.Columns[CAMPO_DOCUMENTONRO].Visible = true;
            displayIndex++;

            dgvDetalleClienteDeuda.Columns[CAMPO_SALDO].HeaderText = "Saldo Deuda";
            dgvDetalleClienteDeuda.Columns[CAMPO_SALDO].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalleClienteDeuda.Columns[CAMPO_SALDO].Width = 130;
            dgvDetalleClienteDeuda.Columns[CAMPO_SALDO].DisplayIndex = displayIndex;
            dgvDetalleClienteDeuda.Columns[CAMPO_SALDO].DefaultCellStyle.Format = "N2";
            dgvDetalleClienteDeuda.Columns[CAMPO_SALDO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalleClienteDeuda.Columns[CAMPO_SALDO].Visible = true;
            displayIndex++;

            dgvDetalleClienteDeuda.Columns[CAMPO_NOMBRETRAMITE].Visible = true;
            dgvDetalleClienteDeuda.Columns[CAMPO_NOMBRETRAMITE].DisplayIndex = displayIndex;
            dgvDetalleClienteDeuda.Columns[CAMPO_NOMBRETRAMITE].HeaderText = "Trámite";
            dgvDetalleClienteDeuda.Columns[CAMPO_NOMBRETRAMITE].Width = 250;
            dgvDetalleClienteDeuda.Columns[CAMPO_NOMBRETRAMITE].Visible = true;
            displayIndex++;

            dgvDetalleClienteDeuda.Columns[CAMPO_ACTA].Visible = true;
            dgvDetalleClienteDeuda.Columns[CAMPO_ACTA].DisplayIndex = displayIndex;
            dgvDetalleClienteDeuda.Columns[CAMPO_ACTA].HeaderText = "Acta";
            dgvDetalleClienteDeuda.Columns[CAMPO_ACTA].Width = 80;
            dgvDetalleClienteDeuda.Columns[CAMPO_ACTA].Visible = true;
            displayIndex++;

            dgvDetalleClienteDeuda.Columns[CAMPO_HI].Visible = true;
            dgvDetalleClienteDeuda.Columns[CAMPO_HI].DisplayIndex = displayIndex;
            dgvDetalleClienteDeuda.Columns[CAMPO_HI].HeaderText = "HI";
            dgvDetalleClienteDeuda.Columns[CAMPO_HI].Width = 80;
            dgvDetalleClienteDeuda.Columns[CAMPO_HI].Visible = true;
            displayIndex++;

            dgvDetalleClienteDeuda.Columns[CAMPO_DESCRIPAREA].Visible = true;
            dgvDetalleClienteDeuda.Columns[CAMPO_DESCRIPAREA].DisplayIndex = displayIndex;
            dgvDetalleClienteDeuda.Columns[CAMPO_DESCRIPAREA].HeaderText = "Área";
            dgvDetalleClienteDeuda.Columns[CAMPO_DESCRIPAREA].Width = 160;
            dgvDetalleClienteDeuda.Columns[CAMPO_DESCRIPAREA].Visible = true;
            displayIndex++;

            dgvDetalleClienteDeuda.Columns[CAMPO_DESCRIPUNIDADNEGOCIO].Visible = true;
            dgvDetalleClienteDeuda.Columns[CAMPO_DESCRIPUNIDADNEGOCIO].DisplayIndex = displayIndex;
            dgvDetalleClienteDeuda.Columns[CAMPO_DESCRIPUNIDADNEGOCIO].HeaderText = "Unidad de Negocio";
            dgvDetalleClienteDeuda.Columns[CAMPO_DESCRIPUNIDADNEGOCIO].Width = 160;
            dgvDetalleClienteDeuda.Columns[CAMPO_DESCRIPUNIDADNEGOCIO].Visible = true;
            displayIndex++;
        }

        private void FDetallePresupuestoMerge_VisibleChanged(object sender, EventArgs e)
        {
            this.FormatearGrila();
        }

        private void dgvDetalleClienteDeuda_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.RowIndex > -1) && (e.ColumnIndex == (((DataGridView)sender).Columns[CAMPO_SALDO].Index)))
            {
                if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_MONEDA].Value.ToString() == "G")
                    e.CellStyle.Format = FORMATO_MONEDA_GUARANIES_GRILLA;
                else
                    e.CellStyle.Format = FORMATO_MONEDA_OTROS_GRILLA;
            }
        }
    }
}