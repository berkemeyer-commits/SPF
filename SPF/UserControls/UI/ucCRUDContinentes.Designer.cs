using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.UserControls.UI
{
    partial class ucCRUDContinentes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCRUDContinentes));
            this.txtContinenteID = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.txtNombreContinente = new Gizmox.WebGUI.Forms.TextBox();
            this.tpCuentas = new Gizmox.WebGUI.Forms.TabPage();
            this.pnlCuentas = new Gizmox.WebGUI.Forms.Panel();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.dgvDetCuentas = new Gizmox.WebGUI.Forms.DataGridView();
            this.panel6 = new Gizmox.WebGUI.Forms.Panel();
            this.panel5 = new Gizmox.WebGUI.Forms.Panel();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.btnEliminarCuenta = new Gizmox.WebGUI.Forms.Button();
            this.btnAgregarCuenta = new Gizmox.WebGUI.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).BeginInit();
            this.tabListaABM.SuspendLayout();
            this.tpDetalle.SuspendLayout();
            this.tpCuentas.SuspendLayout();
            this.pnlCuentas.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetCuentas)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListadoABM
            // 
            this.dgvListadoABM.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dgvListadoABM.Size = new System.Drawing.Size(834, 339);
            this.dgvListadoABM.RowEnter += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgvListadoABM_RowEnter);
            // 
            // tbbEditar
            // 
            this.tbbEditar.Click += new System.EventHandler(this.tbbEditar_Click);
            // 
            // tbbCancelar
            // 
            this.tbbCancelar.Click += new System.EventHandler(this.tbbCancelar_Click);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.txtNombreContinente);
            this.pnlDetalle.Controls.Add(this.label1);
            this.pnlDetalle.Controls.Add(this.txtContinenteID);
            this.pnlDetalle.Size = new System.Drawing.Size(854, 359);
            // 
            // tBBaseForm
            // 
            this.tBBaseForm.Size = new System.Drawing.Size(862, 42);
            // 
            // tbbNuevo
            // 
            this.tbbNuevo.Click += new System.EventHandler(this.tbbNuevo_Click);
            // 
            // tabListaABM
            // 
            this.tabListaABM.Alignment = Gizmox.WebGUI.Forms.TabAlignment.Top;
            this.tabListaABM.Controls.Add(this.tpCuentas);
            this.tabListaABM.Size = new System.Drawing.Size(862, 388);
            this.tabListaABM.SelectedIndexChanged += new System.EventHandler(this.tabListaABM_SelectedIndexChanged);
            this.tabListaABM.Controls.SetChildIndex(this.tpCuentas, 0);
            this.tabListaABM.Controls.SetChildIndex(this.tpDetalle, 0);
            this.tabListaABM.Controls.SetChildIndex(this.tpListado, 0);
            // 
            // tpDetalle
            // 
            this.tpDetalle.Size = new System.Drawing.Size(854, 359);
            // 
            // tpListado
            // 
            this.tpListado.Size = new System.Drawing.Size(854, 359);
            // 
            // txtContinenteID
            // 
            this.txtContinenteID.BackColor = System.Drawing.SystemColors.Control;
            this.txtContinenteID.Location = new System.Drawing.Point(136, 53);
            this.txtContinenteID.Name = "txtContinenteID";
            this.txtContinenteID.ReadOnly = true;
            this.txtContinenteID.Size = new System.Drawing.Size(70, 20);
            this.txtContinenteID.TabIndex = 1;
            this.txtContinenteID.TabStop = false;
            this.txtContinenteID.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Continente";
            // 
            // txtNombreContinente
            // 
            this.txtNombreContinente.Location = new System.Drawing.Point(208, 53);
            this.txtNombreContinente.Name = "txtNombreContinente";
            this.txtNombreContinente.Size = new System.Drawing.Size(367, 20);
            this.txtNombreContinente.TabIndex = 0;
            // 
            // tpCuentas
            // 
            this.tpCuentas.Controls.Add(this.pnlCuentas);
            this.tpCuentas.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpCuentas.Location = new System.Drawing.Point(0, 0);
            this.tpCuentas.Name = "tpCuentas";
            this.tpCuentas.Size = new System.Drawing.Size(854, 359);
            this.tpCuentas.TabIndex = 2;
            this.tpCuentas.Text = "Cuentas";
            // 
            // pnlCuentas
            // 
            this.pnlCuentas.Controls.Add(this.panel1);
            this.pnlCuentas.Controls.Add(this.panel3);
            this.pnlCuentas.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlCuentas.Location = new System.Drawing.Point(0, 0);
            this.pnlCuentas.Name = "pnlCuentas";
            this.pnlCuentas.Size = new System.Drawing.Size(854, 359);
            this.pnlCuentas.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDetCuentas);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(854, 311);
            this.panel1.TabIndex = 1;
            // 
            // dgvDetCuentas
            // 
            this.dgvDetCuentas.AllowUserToAddRows = false;
            this.dgvDetCuentas.AllowUserToDeleteRows = false;
            this.dgvDetCuentas.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvDetCuentas.Location = new System.Drawing.Point(10, 0);
            this.dgvDetCuentas.Name = "dgvDetCuentas";
            this.dgvDetCuentas.Size = new System.Drawing.Size(834, 301);
            this.dgvDetCuentas.TabIndex = 0;
            this.dgvDetCuentas.RowEnter += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgvDetCuenta_RowEnter);
            this.dgvDetCuentas.DoubleClick += new System.EventHandler(this.dgvDetCuentas_DoubleClick);
            // 
            // panel6
            // 
            this.panel6.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(844, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(10, 301);
            this.panel6.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(10, 301);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(844, 10);
            this.panel5.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 311);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnEliminarCuenta);
            this.panel3.Controls.Add(this.btnAgregarCuenta);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(854, 48);
            this.panel3.TabIndex = 0;
            // 
            // btnEliminarCuenta
            // 
            this.btnEliminarCuenta.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminarCuenta.CustomStyle = "F";
            this.btnEliminarCuenta.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnEliminarCuenta.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnEliminarCuenta.Image"));
            this.btnEliminarCuenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarCuenta.Location = new System.Drawing.Point(150, 4);
            this.btnEliminarCuenta.Name = "btnEliminarCuenta";
            this.btnEliminarCuenta.Size = new System.Drawing.Size(131, 39);
            this.btnEliminarCuenta.TabIndex = 0;
            this.btnEliminarCuenta.Text = "Eliminar Cuenta";
            this.btnEliminarCuenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarCuenta.Click += new System.EventHandler(this.btnEliminarCuenta_Click);
            // 
            // btnAgregarCuenta
            // 
            this.btnAgregarCuenta.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarCuenta.CustomStyle = "F";
            this.btnAgregarCuenta.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnAgregarCuenta.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnAgregarCuenta.Image"));
            this.btnAgregarCuenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarCuenta.Location = new System.Drawing.Point(10, 4);
            this.btnAgregarCuenta.Name = "btnAgregarCuenta";
            this.btnAgregarCuenta.Size = new System.Drawing.Size(131, 39);
            this.btnAgregarCuenta.TabIndex = 0;
            this.btnAgregarCuenta.Text = "Agregar Cuenta";
            this.btnAgregarCuenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarCuenta.Click += new System.EventHandler(this.btnAgregarCuenta_Click);
            // 
            // ucCRUDContinentes
            // 
            this.Size = new System.Drawing.Size(864, 466);
            this.Text = "ucCRUDContinentes";
            this.VisibleChanged += new System.EventHandler(this.ucCRUDContinentes_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).EndInit();
            this.tabListaABM.ResumeLayout(false);
            this.tpDetalle.ResumeLayout(false);
            this.tpCuentas.ResumeLayout(false);
            this.pnlCuentas.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetCuentas)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox txtNombreContinente;
        private Label label1;
        private TextBox txtContinenteID;
        private TabPage tpCuentas;
        private Panel pnlCuentas;
        private Panel panel1;
        private DataGridView dgvDetCuentas;
        private Panel panel6;
        private Panel panel5;
        private Panel panel2;
        private Panel panel3;
        private Button btnEliminarCuenta;
        private Button btnAgregarCuenta;


    }
}