using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.UI
{
    partial class FDetallePresupuestoMerge
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

        #region Visual WebGui Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FDetallePresupuestoMerge));
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.panel4 = new Gizmox.WebGUI.Forms.Panel();
            this.dgvDetallePresupuesto = new Gizmox.WebGUI.Forms.DataGridView();
            this.txtClienteID = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.txtClienteNombre = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTramiteDescrip = new Gizmox.WebGUI.Forms.TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.txtTramiteID = new Gizmox.WebGUI.Forms.TextBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.txtHI = new Gizmox.WebGUI.Forms.TextBox();
            this.btnCerrar = new Gizmox.WebGUI.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallePresupuesto)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(811, 318);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.btnCerrar);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 271);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(811, 47);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Controls.Add(this.txtHI);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txtTramiteID);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtTramiteDescrip);
            this.panel3.Controls.Add(this.txtClienteNombre);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtClienteID);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(811, 100);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvDetallePresupuesto);
            this.panel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 100);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(811, 171);
            this.panel4.TabIndex = 2;
            // 
            // dgvDetallePresupuesto
            // 
            this.dgvDetallePresupuesto.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvDetallePresupuesto.Location = new System.Drawing.Point(0, 0);
            this.dgvDetallePresupuesto.Name = "dgvDetallePresupuesto";
            this.dgvDetallePresupuesto.Size = new System.Drawing.Size(811, 171);
            this.dgvDetallePresupuesto.TabIndex = 0;
            this.dgvDetallePresupuesto.CellFormatting += new Gizmox.WebGUI.Forms.DataGridViewCellFormattingEventHandler(this.dgvDetallePresupuesto_CellFormatting);
            // 
            // txtClienteID
            // 
            this.txtClienteID.BackColor = System.Drawing.SystemColors.Control;
            this.txtClienteID.Location = new System.Drawing.Point(157, 26);
            this.txtClienteID.Name = "txtClienteID";
            this.txtClienteID.ReadOnly = true;
            this.txtClienteID.Size = new System.Drawing.Size(72, 20);
            this.txtClienteID.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cliente";
            // 
            // txtClienteNombre
            // 
            this.txtClienteNombre.BackColor = System.Drawing.SystemColors.Control;
            this.txtClienteNombre.Location = new System.Drawing.Point(233, 26);
            this.txtClienteNombre.Name = "txtClienteNombre";
            this.txtClienteNombre.ReadOnly = true;
            this.txtClienteNombre.Size = new System.Drawing.Size(289, 20);
            this.txtClienteNombre.TabIndex = 0;
            // 
            // txtTramiteDescrip
            // 
            this.txtTramiteDescrip.BackColor = System.Drawing.SystemColors.Control;
            this.txtTramiteDescrip.Location = new System.Drawing.Point(233, 52);
            this.txtTramiteDescrip.Name = "txtTramiteDescrip";
            this.txtTramiteDescrip.ReadOnly = true;
            this.txtTramiteDescrip.Size = new System.Drawing.Size(289, 20);
            this.txtTramiteDescrip.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Trámite";
            // 
            // txtTramiteID
            // 
            this.txtTramiteID.BackColor = System.Drawing.SystemColors.Control;
            this.txtTramiteID.Location = new System.Drawing.Point(157, 52);
            this.txtTramiteID.Name = "txtTramiteID";
            this.txtTramiteID.ReadOnly = true;
            this.txtTramiteID.Size = new System.Drawing.Size(72, 20);
            this.txtTramiteID.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(563, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "HI";
            // 
            // txtHI
            // 
            this.txtHI.BackColor = System.Drawing.SystemColors.Control;
            this.txtHI.Location = new System.Drawing.Point(601, 52);
            this.txtHI.Name = "txtHI";
            this.txtHI.ReadOnly = true;
            this.txtHI.Size = new System.Drawing.Size(72, 20);
            this.txtHI.TabIndex = 0;
            // 
            // btnCerrar
            // 
            this.btnCerrar.CustomStyle = "F";
            this.btnCerrar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnCerrar.Image"));
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.ImageSize = new System.Drawing.Size(32, 32);
            this.btnCerrar.Location = new System.Drawing.Point(717, 6);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(85, 36);
            this.btnCerrar.TabIndex = 20;
            this.btnCerrar.Text = "&Cerrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FDetallePresupuestoMerge
            // 
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(811, 318);
            this.Text = "FDetallePresupuestoMerge";
            this.VisibleChanged += new System.EventHandler(this.FDetallePresupuestoMerge_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallePresupuesto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel4;
        private DataGridView dgvDetallePresupuesto;
        private Panel panel3;
        private TextBox txtHI;
        private Label label3;
        private TextBox txtTramiteID;
        private Label label2;
        private TextBox txtTramiteDescrip;
        private TextBox txtClienteNombre;
        private Label label1;
        private TextBox txtClienteID;
        private Panel panel2;
        private Button btnCerrar;


    }
}