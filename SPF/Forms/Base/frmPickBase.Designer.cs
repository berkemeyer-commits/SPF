using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.Base
{
    partial class frmPickBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPickBase));
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel4 = new Gizmox.WebGUI.Forms.Panel();
            this.dgvFiltro = new Gizmox.WebGUI.Forms.DataGridView();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.btnCancelar = new Gizmox.WebGUI.Forms.Button();
            this.btnAceptar = new Gizmox.WebGUI.Forms.Button();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.btnFiltrar = new Gizmox.WebGUI.Forms.Button();
            this.lblCampo = new Gizmox.WebGUI.Forms.Label();
            this.txtDescrpcion = new Gizmox.WebGUI.Forms.TextBox();
            this.txtID = new Gizmox.WebGUI.Forms.TextBox();
            this.toolTip = new Gizmox.WebGUI.Forms.ToolTip();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiltro)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(477, 466);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.CornflowerBlue);
            this.panel4.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.dgvFiltro);
            this.panel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 53);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(477, 358);
            this.panel4.TabIndex = 2;
            // 
            // dgvFiltro
            // 
            this.dgvFiltro.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiltro.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvFiltro.Location = new System.Drawing.Point(0, 0);
            this.dgvFiltro.Name = "dgvFiltro";
            this.dgvFiltro.Size = new System.Drawing.Size(475, 356);
            this.dgvFiltro.TabIndex = 2;
            this.dgvFiltro.CellDoubleClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgvFiltro_CellDoubleClick);
            this.dgvFiltro.KeyPress += new Gizmox.WebGUI.Forms.KeyPressEventHandler(this.dgvFiltro_KeyPress);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Controls.Add(this.btnCancelar);
            this.panel3.Controls.Add(this.btnAceptar);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 411);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(477, 55);
            this.panel3.TabIndex = 1;
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
            this.btnCancelar.Location = new System.Drawing.Point(265, 9);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 36);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
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
            this.btnAceptar.Location = new System.Drawing.Point(109, 9);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(85, 36);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.btnFiltrar);
            this.panel2.Controls.Add(this.lblCampo);
            this.panel2.Controls.Add(this.txtDescrpcion);
            this.panel2.Controls.Add(this.txtID);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(477, 53);
            this.panel2.TabIndex = 0;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnFiltrar.Image"));
            this.btnFiltrar.Location = new System.Drawing.Point(423, 8);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(40, 40);
            this.btnFiltrar.TabIndex = 3;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // lblCampo
            // 
            this.lblCampo.AutoSize = true;
            this.lblCampo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCampo.Location = new System.Drawing.Point(11, 20);
            this.lblCampo.Name = "lblCampo";
            this.lblCampo.Size = new System.Drawing.Size(35, 13);
            this.lblCampo.TabIndex = 1;
            this.lblCampo.Text = "lblCampo";
            // 
            // txtDescrpcion
            // 
            this.txtDescrpcion.AllowDrag = false;
            this.txtDescrpcion.Location = new System.Drawing.Point(154, 17);
            this.txtDescrpcion.Name = "txtDescrpcion";
            this.txtDescrpcion.Size = new System.Drawing.Size(262, 20);
            this.txtDescrpcion.TabIndex = 1;
            this.txtDescrpcion.Leave += new System.EventHandler(this.txtDescrpcion_Leave);
            // 
            // txtID
            // 
            this.txtID.AllowDrag = false;
            this.txtID.ClientId = "txtClientID";
            this.txtID.Location = new System.Drawing.Point(90, 17);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(63, 20);
            this.txtID.TabIndex = 0;
            this.txtID.Leave += new System.EventHandler(this.txtID_Leave);
            // 
            // frmPickBase
            // 
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Size = new System.Drawing.Size(477, 466);
            this.Text = "frmPickBase";
            this.Load += new System.EventHandler(this.frmPickBase_Load);
            this.VisibleChanged += new System.EventHandler(this.frmPickBase_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiltro)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private DataGridView dgvFiltro;
        private Label lblCampo;
        private TextBox txtDescrpcion;
        private TextBox txtID;
        private Button btnCancelar;
        private Button btnAceptar;
        private ToolTip toolTip;
        private Button btnFiltrar;


    }
}