using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.UserControls.UI
{
    partial class ucCRUDFacturasExcluidas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlCab = new Gizmox.WebGUI.Forms.Panel();
            this.txtMonedaID = new Gizmox.WebGUI.Forms.TextBox();
            this.txtImporteVal = new Gizmox.WebGUI.Forms.TextBox();
            this.txtSaldoVal = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTipoFacturaID = new Gizmox.WebGUI.Forms.TextBox();
            this.chkActivo = new Gizmox.WebGUI.Forms.CheckBox();
            this.txtProveedorID = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.txtIDExclusionFactura = new Gizmox.WebGUI.Forms.TextBox();
            this.grpDatosFactura = new Gizmox.WebGUI.Forms.GroupBox();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.txtSaldo = new Gizmox.WebGUI.Forms.TextBox();
            this.txtImporte = new Gizmox.WebGUI.Forms.TextBox();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.txtProveedor = new Gizmox.WebGUI.Forms.TextBox();
            this.btnBuscar = new Gizmox.WebGUI.Forms.Button();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.txtTipoFactura = new Gizmox.WebGUI.Forms.TextBox();
            this.txtNroFactura = new Gizmox.WebGUI.Forms.TextBox();
            this.lblProvCorresp = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.txtFechaFactura = new Gizmox.WebGUI.Forms.TextBox();
            this.lblSolicitudesNro = new Gizmox.WebGUI.Forms.Label();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.panel7 = new Gizmox.WebGUI.Forms.Panel();
            this.panel6 = new Gizmox.WebGUI.Forms.Panel();
            this.panel5 = new Gizmox.WebGUI.Forms.Panel();
            this.dgvSolDet = new Gizmox.WebGUI.Forms.DataGridView();
            this.panel4 = new Gizmox.WebGUI.Forms.Panel();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).BeginInit();
            this.tabListaABM.SuspendLayout();
            this.tpDetalle.SuspendLayout();
            this.pnlCab.SuspendLayout();
            this.grpDatosFactura.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolDet)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListadoABM
            // 
            this.dgvListadoABM.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dgvListadoABM.Size = new System.Drawing.Size(1172, 459);
            this.dgvListadoABM.CellFormatting += new Gizmox.WebGUI.Forms.DataGridViewCellFormattingEventHandler(this.dgvListadoABM_CellFormatting);
            this.dgvListadoABM.RowEnter += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgvListadoABM_RowEnter_1);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.panel2);
            this.pnlDetalle.Controls.Add(this.pnlCab);
            this.pnlDetalle.Size = new System.Drawing.Size(1192, 479);
            // 
            // tBBaseForm
            // 
            this.tBBaseForm.Size = new System.Drawing.Size(1200, 114);
            // 
            // tabListaABM
            // 
            this.tabListaABM.Alignment = Gizmox.WebGUI.Forms.TabAlignment.Top;
            this.tabListaABM.Size = new System.Drawing.Size(1200, 508);
            // 
            // tpDetalle
            // 
            this.tpDetalle.Location = new System.Drawing.Point(4, 25);
            this.tpDetalle.Size = new System.Drawing.Size(1192, 479);
            // 
            // tpListado
            // 
            this.tpListado.Size = new System.Drawing.Size(1192, 479);
            // 
            // pnlCab
            // 
            this.pnlCab.Controls.Add(this.txtMonedaID);
            this.pnlCab.Controls.Add(this.txtImporteVal);
            this.pnlCab.Controls.Add(this.txtSaldoVal);
            this.pnlCab.Controls.Add(this.txtTipoFacturaID);
            this.pnlCab.Controls.Add(this.chkActivo);
            this.pnlCab.Controls.Add(this.txtProveedorID);
            this.pnlCab.Controls.Add(this.label1);
            this.pnlCab.Controls.Add(this.txtIDExclusionFactura);
            this.pnlCab.Controls.Add(this.grpDatosFactura);
            this.pnlCab.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.pnlCab.Location = new System.Drawing.Point(0, 0);
            this.pnlCab.Name = "pnlCab";
            this.pnlCab.Size = new System.Drawing.Size(1192, 224);
            this.pnlCab.TabIndex = 0;
            // 
            // txtMonedaID
            // 
            this.txtMonedaID.BackColor = System.Drawing.SystemColors.Control;
            this.txtMonedaID.Location = new System.Drawing.Point(558, 146);
            this.txtMonedaID.Name = "txtMonedaID";
            this.txtMonedaID.ReadOnly = true;
            this.txtMonedaID.Size = new System.Drawing.Size(77, 20);
            this.txtMonedaID.TabIndex = 0;
            this.txtMonedaID.TabStop = false;
            this.txtMonedaID.Visible = false;
            // 
            // txtImporteVal
            // 
            this.txtImporteVal.BackColor = System.Drawing.SystemColors.Control;
            this.txtImporteVal.Location = new System.Drawing.Point(558, 59);
            this.txtImporteVal.Name = "txtImporteVal";
            this.txtImporteVal.ReadOnly = true;
            this.txtImporteVal.Size = new System.Drawing.Size(77, 20);
            this.txtImporteVal.TabIndex = 0;
            this.txtImporteVal.TabStop = false;
            this.txtImporteVal.Visible = false;
            // 
            // txtSaldoVal
            // 
            this.txtSaldoVal.BackColor = System.Drawing.SystemColors.Control;
            this.txtSaldoVal.Location = new System.Drawing.Point(558, 102);
            this.txtSaldoVal.Name = "txtSaldoVal";
            this.txtSaldoVal.ReadOnly = true;
            this.txtSaldoVal.Size = new System.Drawing.Size(77, 20);
            this.txtSaldoVal.TabIndex = 0;
            this.txtSaldoVal.TabStop = false;
            this.txtSaldoVal.Visible = false;
            // 
            // txtTipoFacturaID
            // 
            this.txtTipoFacturaID.BackColor = System.Drawing.SystemColors.Control;
            this.txtTipoFacturaID.Location = new System.Drawing.Point(321, 31);
            this.txtTipoFacturaID.Name = "txtTipoFacturaID";
            this.txtTipoFacturaID.ReadOnly = true;
            this.txtTipoFacturaID.Size = new System.Drawing.Size(77, 20);
            this.txtTipoFacturaID.TabIndex = 0;
            this.txtTipoFacturaID.TabStop = false;
            this.txtTipoFacturaID.Visible = false;
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Enabled = false;
            this.chkActivo.Location = new System.Drawing.Point(445, 33);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(56, 17);
            this.chkActivo.TabIndex = 5;
            this.chkActivo.Text = "Activo";
            // 
            // txtProveedorID
            // 
            this.txtProveedorID.BackColor = System.Drawing.SystemColors.Control;
            this.txtProveedorID.Location = new System.Drawing.Point(235, 31);
            this.txtProveedorID.Name = "txtProveedorID";
            this.txtProveedorID.ReadOnly = true;
            this.txtProveedorID.Size = new System.Drawing.Size(77, 20);
            this.txtProveedorID.TabIndex = 0;
            this.txtProveedorID.TabStop = false;
            this.txtProveedorID.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Exclusión ID";
            // 
            // txtIDExclusionFactura
            // 
            this.txtIDExclusionFactura.BackColor = System.Drawing.SystemColors.Control;
            this.txtIDExclusionFactura.Location = new System.Drawing.Point(126, 31);
            this.txtIDExclusionFactura.Name = "txtIDExclusionFactura";
            this.txtIDExclusionFactura.ReadOnly = true;
            this.txtIDExclusionFactura.Size = new System.Drawing.Size(77, 20);
            this.txtIDExclusionFactura.TabIndex = 0;
            this.txtIDExclusionFactura.TabStop = false;
            // 
            // grpDatosFactura
            // 
            this.grpDatosFactura.Controls.Add(this.label7);
            this.grpDatosFactura.Controls.Add(this.txtSaldo);
            this.grpDatosFactura.Controls.Add(this.txtImporte);
            this.grpDatosFactura.Controls.Add(this.label6);
            this.grpDatosFactura.Controls.Add(this.txtProveedor);
            this.grpDatosFactura.Controls.Add(this.btnBuscar);
            this.grpDatosFactura.Controls.Add(this.label4);
            this.grpDatosFactura.Controls.Add(this.txtTipoFactura);
            this.grpDatosFactura.Controls.Add(this.txtNroFactura);
            this.grpDatosFactura.Controls.Add(this.lblProvCorresp);
            this.grpDatosFactura.Controls.Add(this.label2);
            this.grpDatosFactura.Controls.Add(this.label3);
            this.grpDatosFactura.Controls.Add(this.txtFechaFactura);
            this.grpDatosFactura.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpDatosFactura.ForeColor = System.Drawing.Color.Black;
            this.grpDatosFactura.Location = new System.Drawing.Point(49, 59);
            this.grpDatosFactura.Name = "grpDatosFactura";
            this.grpDatosFactura.Size = new System.Drawing.Size(452, 155);
            this.grpDatosFactura.TabIndex = 4;
            this.grpDatosFactura.TabStop = false;
            this.grpDatosFactura.Text = "Datos Factura";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Saldo";
            // 
            // txtSaldo
            // 
            this.txtSaldo.AllowDrag = false;
            this.txtSaldo.BackColor = System.Drawing.SystemColors.Control;
            this.txtSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldo.ForeColor = System.Drawing.Color.Green;
            this.txtSaldo.Location = new System.Drawing.Point(90, 113);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(104, 20);
            this.txtSaldo.TabIndex = 3;
            this.txtSaldo.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // txtImporte
            // 
            this.txtImporte.AllowDrag = false;
            this.txtImporte.BackColor = System.Drawing.SystemColors.Control;
            this.txtImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporte.ForeColor = System.Drawing.Color.Green;
            this.txtImporte.Location = new System.Drawing.Point(319, 86);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.ReadOnly = true;
            this.txtImporte.Size = new System.Drawing.Size(104, 20);
            this.txtImporte.TabIndex = 3;
            this.txtImporte.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(269, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Importe";
            // 
            // txtProveedor
            // 
            this.txtProveedor.AllowDrag = false;
            this.txtProveedor.BackColor = System.Drawing.SystemColors.Control;
            this.txtProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProveedor.ForeColor = System.Drawing.Color.Green;
            this.txtProveedor.Location = new System.Drawing.Point(90, 31);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.ReadOnly = true;
            this.txtProveedor.Size = new System.Drawing.Size(333, 20);
            this.txtProveedor.TabIndex = 3;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(272, 111);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(151, 24);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Seleccionar Factura";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tipo";
            // 
            // txtTipoFactura
            // 
            this.txtTipoFactura.AllowDrag = false;
            this.txtTipoFactura.BackColor = System.Drawing.SystemColors.Control;
            this.txtTipoFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoFactura.ForeColor = System.Drawing.Color.Green;
            this.txtTipoFactura.Location = new System.Drawing.Point(90, 83);
            this.txtTipoFactura.Name = "txtTipoFactura";
            this.txtTipoFactura.ReadOnly = true;
            this.txtTipoFactura.Size = new System.Drawing.Size(114, 20);
            this.txtTipoFactura.TabIndex = 3;
            // 
            // txtNroFactura
            // 
            this.txtNroFactura.AllowDrag = false;
            this.txtNroFactura.BackColor = System.Drawing.SystemColors.Control;
            this.txtNroFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroFactura.ForeColor = System.Drawing.Color.Green;
            this.txtNroFactura.Location = new System.Drawing.Point(90, 57);
            this.txtNroFactura.Name = "txtNroFactura";
            this.txtNroFactura.ReadOnly = true;
            this.txtNroFactura.Size = new System.Drawing.Size(164, 20);
            this.txtNroFactura.TabIndex = 3;
            // 
            // lblProvCorresp
            // 
            this.lblProvCorresp.AutoSize = true;
            this.lblProvCorresp.Location = new System.Drawing.Point(24, 61);
            this.lblProvCorresp.Name = "lblProvCorresp";
            this.lblProvCorresp.Size = new System.Drawing.Size(44, 13);
            this.lblProvCorresp.TabIndex = 0;
            this.lblProvCorresp.Text = "Número";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fecha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Proveedor";
            // 
            // txtFechaFactura
            // 
            this.txtFechaFactura.AllowDrag = false;
            this.txtFechaFactura.BackColor = System.Drawing.SystemColors.Control;
            this.txtFechaFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaFactura.ForeColor = System.Drawing.Color.Green;
            this.txtFechaFactura.Location = new System.Drawing.Point(319, 57);
            this.txtFechaFactura.Name = "txtFechaFactura";
            this.txtFechaFactura.ReadOnly = true;
            this.txtFechaFactura.Size = new System.Drawing.Size(104, 20);
            this.txtFechaFactura.TabIndex = 3;
            this.txtFechaFactura.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblSolicitudesNro
            // 
            this.lblSolicitudesNro.AutoSize = true;
            this.lblSolicitudesNro.Font = new System.Drawing.Font("Tahoma", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSolicitudesNro.Location = new System.Drawing.Point(20, 4);
            this.lblSolicitudesNro.Name = "lblSolicitudesNro";
            this.lblSolicitudesNro.Size = new System.Drawing.Size(168, 13);
            this.lblSolicitudesNro.TabIndex = 1;
            this.lblSolicitudesNro.Text = "Solicitudes Asociadas a la Factura";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 224);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1192, 255);
            this.panel2.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 100);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(20, 215);
            this.panel7.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(1172, 20);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(20, 215);
            this.panel6.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgvSolDet);
            this.panel5.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 20);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1192, 215);
            this.panel5.TabIndex = 0;
            // 
            // dgvSolDet
            // 
            this.dgvSolDet.AllowDrag = false;
            this.dgvSolDet.AllowUserToAddRows = false;
            this.dgvSolDet.AllowUserToDeleteRows = false;
            this.dgvSolDet.AllowUserToResizeRows = false;
            this.dgvSolDet.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvSolDet.Location = new System.Drawing.Point(0, 0);
            this.dgvSolDet.Name = "dgvSolDet";
            this.dgvSolDet.Size = new System.Drawing.Size(1192, 215);
            this.dgvSolDet.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 235);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1192, 20);
            this.panel4.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblSolicitudesNro);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1192, 20);
            this.panel3.TabIndex = 0;
            // 
            // ucCRUDFacturasExcluidas
            // 
            this.Size = new System.Drawing.Size(1202, 586);
            this.Text = "ucFacturasExcluidas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).EndInit();
            this.tabListaABM.ResumeLayout(false);
            this.tpDetalle.ResumeLayout(false);
            this.pnlCab.ResumeLayout(false);
            this.grpDatosFactura.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolDet)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel2;
        private Panel pnlCab;
        private Label label1;
        private TextBox txtIDExclusionFactura;
        private GroupBox grpDatosFactura;
        private TextBox txtProveedor;
        private Button btnBuscar;
        private Label label4;
        private TextBox txtTipoFactura;
        private TextBox txtNroFactura;
        private Label lblProvCorresp;
        private Label label2;
        private Label label3;
        private TextBox txtFechaFactura;
        private Panel panel7;
        private Panel panel6;
        private Panel panel5;
        private DataGridView dgvSolDet;
        private Panel panel4;
        private Panel panel3;
        private Label lblSolicitudesNro;
        private TextBox txtImporte;
        private Label label6;
        private Label label7;
        private TextBox txtSaldo;
        private TextBox txtProveedorID;
        private CheckBox chkActivo;
        private TextBox txtTipoFacturaID;
        private TextBox txtImporteVal;
        private TextBox txtSaldoVal;
        private TextBox txtMonedaID;



    }
}