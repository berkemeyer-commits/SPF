using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.UI
{
    partial class FSeleccionarPresupuestoNC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FSeleccionarPresupuestoNC));
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel4 = new Gizmox.WebGUI.Forms.Panel();
            this.panel6 = new Gizmox.WebGUI.Forms.Panel();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.btnAceptar = new Gizmox.WebGUI.Forms.Button();
            this.btnCancelar = new Gizmox.WebGUI.Forms.Button();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.txtClienteNombre = new Gizmox.WebGUI.Forms.TextBox();
            this.txtClienteID = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.txtFechaHasta = new Gizmox.WebGUI.Forms.TextBox();
            this.txtFechaDesde = new Gizmox.WebGUI.Forms.TextBox();
            this.dtpFechaDesde = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label21 = new Gizmox.WebGUI.Forms.Label();
            this.label18 = new Gizmox.WebGUI.Forms.Label();
            this.dtpFechaHasta = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.btnFiltrar = new Gizmox.WebGUI.Forms.Button();
            this.dgvPresupuestos = new Gizmox.WebGUI.Forms.DataGridView();
            this.lblEstado = new Gizmox.WebGUI.Forms.Label();
            this.panel5 = new Gizmox.WebGUI.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuestos)).BeginInit();
            this.panel5.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(675, 504);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 111);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(675, 340);
            this.panel4.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvPresupuestos);
            this.panel6.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(675, 340);
            this.panel6.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Controls.Add(this.btnAceptar);
            this.panel3.Controls.Add(this.btnCancelar);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 451);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(675, 53);
            this.panel3.TabIndex = 1;
            // 
            // btnAceptar
            // 
            this.btnAceptar.CustomStyle = "F";
            this.btnAceptar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnAceptar.Image"));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.ImageSize = new System.Drawing.Size(32, 32);
            this.btnAceptar.Location = new System.Drawing.Point(217, 9);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(85, 36);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.CustomStyle = "F";
            this.btnCancelar.DialogResult = Gizmox.WebGUI.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnCancelar.Image"));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.ImageSize = new System.Drawing.Size(32, 32);
            this.btnCancelar.Location = new System.Drawing.Point(373, 9);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 36);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.txtClienteNombre);
            this.panel2.Controls.Add(this.txtClienteID);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtFechaHasta);
            this.panel2.Controls.Add(this.txtFechaDesde);
            this.panel2.Controls.Add(this.dtpFechaDesde);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.dtpFechaHasta);
            this.panel2.Controls.Add(this.btnFiltrar);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(675, 111);
            this.panel2.TabIndex = 0;
            // 
            // txtClienteNombre
            // 
            this.txtClienteNombre.BackColor = System.Drawing.SystemColors.Control;
            this.txtClienteNombre.Location = new System.Drawing.Point(221, 20);
            this.txtClienteNombre.Name = "txtClienteNombre";
            this.txtClienteNombre.ReadOnly = true;
            this.txtClienteNombre.Size = new System.Drawing.Size(370, 20);
            this.txtClienteNombre.TabIndex = 4;
            this.txtClienteNombre.TabStop = false;
            // 
            // txtClienteID
            // 
            this.txtClienteID.BackColor = System.Drawing.SystemColors.Control;
            this.txtClienteID.Location = new System.Drawing.Point(138, 20);
            this.txtClienteID.Name = "txtClienteID";
            this.txtClienteID.ReadOnly = true;
            this.txtClienteID.Size = new System.Drawing.Size(82, 20);
            this.txtClienteID.TabIndex = 4;
            this.txtClienteID.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente";
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaHasta.Location = new System.Drawing.Point(406, 54);
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.Size = new System.Drawing.Size(81, 18);
            this.txtFechaHasta.TabIndex = 3;
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaDesde.Location = new System.Drawing.Point(139, 54);
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.Size = new System.Drawing.Size(81, 18);
            this.txtFechaDesde.TabIndex = 3;
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaDesde.Location = new System.Drawing.Point(138, 53);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaDesde.TabIndex = 3;
            this.dtpFechaDesde.TabStop = false;
            this.dtpFechaDesde.ValueChanged += new System.EventHandler(this.dtpFechaDesde_ValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(61, 57);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(43, 13);
            this.label21.TabIndex = 0;
            this.label21.Text = "Fecha Desde";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(329, 57);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(43, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Fecha Hasta";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaHasta.Location = new System.Drawing.Point(405, 53);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaHasta.TabIndex = 3;
            this.dtpFechaHasta.TabStop = false;
            this.dtpFechaHasta.ValueChanged += new System.EventHandler(this.dtpFechaHasta_ValueChanged);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnFiltrar.Image"));
            this.btnFiltrar.Location = new System.Drawing.Point(530, 45);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(40, 40);
            this.btnFiltrar.TabIndex = 2;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // dgvPresupuestos
            // 
            this.dgvPresupuestos.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvPresupuestos.Location = new System.Drawing.Point(0, 0);
            this.dgvPresupuestos.Name = "dgvPresupuestos";
            this.dgvPresupuestos.Size = new System.Drawing.Size(675, 340);
            this.dgvPresupuestos.TabIndex = 0;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblEstado.ForeColor = System.Drawing.Color.Black;
            this.lblEstado.Location = new System.Drawing.Point(5, 3);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(35, 13);
            this.lblEstado.TabIndex = 0;
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.lblEstado);
            this.panel5.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 90);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(675, 21);
            this.panel5.TabIndex = 1;
            // 
            // FSeleccionarPresupuestoNC
            // 
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(675, 504);
            this.Text = "FSeleccionarPresupuestoNC";
            this.Load += new System.EventHandler(this.FSeleccionarPresupuestoNC_Load);
            this.VisibleChanged += new System.EventHandler(this.FSeleccionarPresupuestoNC_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuestos)).EndInit();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Panel panel6;
        private Button btnAceptar;
        private Button btnCancelar;
        private TextBox txtClienteID;
        private Label label1;
        private TextBox txtFechaHasta;
        private TextBox txtFechaDesde;
        private DateTimePicker dtpFechaDesde;
        private Label label21;
        private Label label18;
        private DateTimePicker dtpFechaHasta;
        private Button btnFiltrar;
        private TextBox txtClienteNombre;
        private DataGridView dgvPresupuestos;
        private Panel panel5;
        private Label lblEstado;


    }
}