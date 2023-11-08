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
#endregion

namespace SPF.Forms.UI
{
    public partial class FDetallePresupuestoMerge : Form
    {
        #region Constantes
        public const string CAMPO_EXPEDIENTEID      = "ExpedienteID";
        public const string CAMPO_ACTA              = "Acta";
        public const string CAMPO_DENOMINACIONMARCA = "DenominacionMarca";
        public const string CAMPO_PRESENTACIONFECHA = "PresentacionFecha";
        public const string CAMPO_HI                = "HI";
        public const string CAMPO_CLIENTEID         = "ClienteID";
        public const string CAMPO_CLIENTENOMBRE     = "ClienteNombre";
        public const string CAMPO_TRAMITEID         = "TramiteID";
        public const string CAMPO_TRAMITEDESCRIP    = "TramiteDescrip";
        public const string CAMPO_SERIEAUX          = "SerieAux";
        public const string CAMPO_NROPRESUPUESTOAUX = "NroPresupuestoAux";
        public const string CAMPO_NROPRESUPUESTO    = "NroPresupuesto";
        public const string CAMPO_GENERADO          = "Generado";
        public const string CAMPO_COTIZACIONCABID   = "CotizacionCabID";
        public const string CAMPO_MERDOCID          = "MergeDocID";
        #endregion Constantes

        public FDetallePresupuestoMerge()
        {
            InitializeComponent();
            this.Text = "Marcas de la Hoja de Inicio";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void AddData(List<DetallePresupuestoType> detalle)
        {
            DetallePresupuestoType cab = detalle.First();
            this.txtClienteID.Text = cab.ClienteID.ToString();
            this.txtClienteNombre.Text = cab.ClienteNombre;
            this.txtTramiteID.Text = cab.TramiteID.ToString();
            this.txtTramiteDescrip.Text = cab.TramiteDescrip;
            this.txtHI.Text = cab.HI;

            this.dgvDetallePresupuesto.DataSource = detalle;
            
        }

        public void FormatearGrila()
        {
            foreach (DataGridViewColumn col in this.dgvDetallePresupuesto.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            this.dgvDetallePresupuesto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetallePresupuesto.ItemsPerPage = 5;
            this.dgvDetallePresupuesto.ShowCellToolTips = true;
            this.dgvDetallePresupuesto.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvDetallePresupuesto.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvDetallePresupuesto.DefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvDetallePresupuesto.DefaultCellStyle.BackColor = Color.Transparent;
            int displayIndex = 0;

            this.dgvDetallePresupuesto.Columns[CAMPO_COTIZACIONCABID].Visible = true;
            this.dgvDetallePresupuesto.Columns[CAMPO_COTIZACIONCABID].DisplayIndex = displayIndex;
            this.dgvDetallePresupuesto.Columns[CAMPO_COTIZACIONCABID].HeaderText = "Cotización ID";
            this.dgvDetallePresupuesto.Columns[CAMPO_COTIZACIONCABID].Width = 90;
            displayIndex++;

            this.dgvDetallePresupuesto.Columns[CAMPO_DENOMINACIONMARCA].Visible = true;
            this.dgvDetallePresupuesto.Columns[CAMPO_DENOMINACIONMARCA].DisplayIndex = displayIndex;
            this.dgvDetallePresupuesto.Columns[CAMPO_DENOMINACIONMARCA].HeaderText = "Denominación";
            this.dgvDetallePresupuesto.Columns[CAMPO_DENOMINACIONMARCA].Width = 250;
            displayIndex++;

            /*this.dgvDetallePresupuesto.Columns[CAMPO_SERIEAUX].Visible = true;
            this.dgvDetallePresupuesto.Columns[CAMPO_SERIEAUX].HeaderText = "Serie";
            this.dgvDetallePresupuesto.Columns[CAMPO_SERIEAUX].DisplayIndex = displayIndex;
            this.dgvDetallePresupuesto.Columns[CAMPO_SERIEAUX].ReadOnly = false;
            this.dgvDetallePresupuesto.Columns[CAMPO_SERIEAUX].Width = 50;
            this.dgvDetallePresupuesto.Columns[CAMPO_SERIEAUX].ToolTipText = "Ingrese la serie a ser asignada manualmente.";
            displayIndex++;

            this.dgvDetallePresupuesto.Columns[CAMPO_NROPRESUPUESTOAUX].Visible = true;
            this.dgvDetallePresupuesto.Columns[CAMPO_NROPRESUPUESTOAUX].HeaderText = "Nro. Presup.";
            this.dgvDetallePresupuesto.Columns[CAMPO_NROPRESUPUESTOAUX].DisplayIndex = displayIndex;
            this.dgvDetallePresupuesto.Columns[CAMPO_NROPRESUPUESTOAUX].ReadOnly = false;
            this.dgvDetallePresupuesto.Columns[CAMPO_NROPRESUPUESTOAUX].Width = 95;
            this.dgvDetallePresupuesto.Columns[CAMPO_NROPRESUPUESTOAUX].ToolTipText = "Ingrese la numeración a ser asignada manualmente.";
            displayIndex++;*/

            this.dgvDetallePresupuesto.Columns[CAMPO_ACTA].Visible = true;
            this.dgvDetallePresupuesto.Columns[CAMPO_ACTA].DisplayIndex = displayIndex;
            this.dgvDetallePresupuesto.Columns[CAMPO_ACTA].HeaderText = "Acta";
            displayIndex++;

            this.dgvDetallePresupuesto.Columns[CAMPO_PRESENTACIONFECHA].Visible = true;
            this.dgvDetallePresupuesto.Columns[CAMPO_PRESENTACIONFECHA].DisplayIndex = displayIndex;
            this.dgvDetallePresupuesto.Columns[CAMPO_PRESENTACIONFECHA].Width = 90;
            this.dgvDetallePresupuesto.Columns[CAMPO_PRESENTACIONFECHA].HeaderText = "Pres. Fec.";
            displayIndex++;

            this.dgvDetallePresupuesto.Columns[CAMPO_EXPEDIENTEID].Visible = true;
            this.dgvDetallePresupuesto.Columns[CAMPO_EXPEDIENTEID].DisplayIndex = displayIndex;
            this.dgvDetallePresupuesto.Columns[CAMPO_EXPEDIENTEID].HeaderText = "Expediente";
            displayIndex++;

            this.dgvDetallePresupuesto.Columns[CAMPO_NROPRESUPUESTO].Visible = true;
            this.dgvDetallePresupuesto.Columns[CAMPO_NROPRESUPUESTO].DisplayIndex = displayIndex;
            this.dgvDetallePresupuesto.Columns[CAMPO_NROPRESUPUESTO].HeaderText = "Presup N°";
            this.dgvDetallePresupuesto.Columns[CAMPO_NROPRESUPUESTO].Width = 95;
            displayIndex++;

            //this.dgvDetallePresupuesto.Columns[CAMPO_GENERADO].Visible = true;
            //this.dgvDetallePresupuesto.Columns[CAMPO_GENERADO].DisplayIndex = displayIndex;
            //this.dgvDetallePresupuesto.Columns[CAMPO_GENERADO].HeaderText = "Generado";
            //displayIndex++;

            DataGridViewCheckBoxColumn colGenerado = new DataGridViewCheckBoxColumn();
            colGenerado.DataPropertyName = CAMPO_GENERADO;
            colGenerado.HeaderText = "Generado";
            colGenerado.FalseValue = false;
            colGenerado.TrueValue = true;
            colGenerado.ReadOnly = true;
            this.dgvDetallePresupuesto.Columns.Insert(displayIndex, colGenerado);
            displayIndex++;

            this.dgvDetallePresupuesto.Columns[CAMPO_MERDOCID].Visible = true;
            this.dgvDetallePresupuesto.Columns[CAMPO_MERDOCID].DisplayIndex = displayIndex;
            this.dgvDetallePresupuesto.Columns[CAMPO_MERDOCID].HeaderText = "MergeDoc ID";
            this.dgvDetallePresupuesto.Columns[CAMPO_MERDOCID].Width = 95;
            displayIndex++;

        }

        private void FDetallePresupuestoMerge_VisibleChanged(object sender, EventArgs e)
        {
            this.FormatearGrila();
        }

        private void dgvDetallePresupuesto_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.RowIndex > -1) &&
                (this.dgvDetallePresupuesto.Rows[e.RowIndex].Cells[CAMPO_GENERADO].Value != null) &&
                ((bool)(this.dgvDetallePresupuesto.Rows[e.RowIndex].Cells[CAMPO_GENERADO].Value)))
            {
                ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }
    }
}