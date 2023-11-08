using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.UserControls.UI
{
    partial class ucPartePresupuesto
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
            this.label10 = new Gizmox.WebGUI.Forms.Label();
            this.tSBTramite = new SPF.UserControls.Base.ucTextSearchBox();
            this.label29 = new Gizmox.WebGUI.Forms.Label();
            this.txtDescripServEsp = new Gizmox.WebGUI.Forms.TextBox();
            this.txtIDPartePresupuesto = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.txtDescripServIng = new Gizmox.WebGUI.Forms.TextBox();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.txtDescripGastEsp = new Gizmox.WebGUI.Forms.TextBox();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.txtDescripGastIng = new Gizmox.WebGUI.Forms.TextBox();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListadoABM
            // 
            this.dgvListadoABM.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dgvListadoABM.Size = new System.Drawing.Size(902, 378);
            this.dgvListadoABM.RowEnter += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgvListadoABM_RowEnter);
            // 
            // tbbEditar
            // 
            this.tbbEditar.Click += new System.EventHandler(this.tbbEditar_Click);
            // 
            // tbbBorrar
            // 
            this.tbbBorrar.Click += new System.EventHandler(this.tbbBorrar_Click_1);
            // 
            // tbbGuardar
            // 
            this.tbbGuardar.Click += new System.EventHandler(this.tbbGuardar_Click);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.label8);
            this.pnlDetalle.Controls.Add(this.txtDescripGastIng);
            this.pnlDetalle.Controls.Add(this.label7);
            this.pnlDetalle.Controls.Add(this.label6);
            this.pnlDetalle.Controls.Add(this.txtDescripGastEsp);
            this.pnlDetalle.Controls.Add(this.label5);
            this.pnlDetalle.Controls.Add(this.label4);
            this.pnlDetalle.Controls.Add(this.txtDescripServIng);
            this.pnlDetalle.Controls.Add(this.label3);
            this.pnlDetalle.Controls.Add(this.label2);
            this.pnlDetalle.Controls.Add(this.label1);
            this.pnlDetalle.Controls.Add(this.txtIDPartePresupuesto);
            this.pnlDetalle.Controls.Add(this.txtDescripServEsp);
            this.pnlDetalle.Controls.Add(this.label29);
            this.pnlDetalle.Controls.Add(this.tSBTramite);
            this.pnlDetalle.Controls.Add(this.label10);
            // 
            // tBBaseForm
            // 
            this.tBBaseForm.Size = new System.Drawing.Size(930, 42);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(226, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Trámite";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tSBTramite
            // 
            this.tSBTramite.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBTramite.DBContext = null;
            this.tSBTramite.DisplayMember = "";
            this.tSBTramite.KeyMember = "";
            this.tSBTramite.LabelCampoBusqueda = "";
            this.tSBTramite.Location = new System.Drawing.Point(285, 50);
            this.tSBTramite.Name = "tSBTramite";
            this.tSBTramite.NombreCampoDescrip = "";
            this.tSBTramite.NombreCampoID = "";
            this.tSBTramite.Size = new System.Drawing.Size(435, 20);
            this.tSBTramite.TabIndex = 0;
            this.tSBTramite.Text = "ucTextSearchBox";
            this.tSBTramite.TituloBuscador = "";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(177, 78);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(35, 13);
            this.label29.TabIndex = 0;
            this.label29.Text = "Texto Descripción";
            this.label29.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtDescripServEsp
            // 
            this.txtDescripServEsp.Location = new System.Drawing.Point(285, 75);
            this.txtDescripServEsp.Multiline = true;
            this.txtDescripServEsp.Name = "txtDescripServEsp";
            this.txtDescripServEsp.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.txtDescripServEsp.Size = new System.Drawing.Size(435, 71);
            this.txtDescripServEsp.TabIndex = 1;
            // 
            // txtIDPartePresupuesto
            // 
            this.txtIDPartePresupuesto.BackColor = System.Drawing.SystemColors.Control;
            this.txtIDPartePresupuesto.Location = new System.Drawing.Point(285, 25);
            this.txtIDPartePresupuesto.Name = "txtIDPartePresupuesto";
            this.txtIDPartePresupuesto.ReadOnly = true;
            this.txtIDPartePresupuesto.Size = new System.Drawing.Size(100, 20);
            this.txtIDPartePresupuesto.TabIndex = 0;
            this.txtIDPartePresupuesto.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(251, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "de Servicios Español";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "de Servicios Inglés";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtDescripServIng
            // 
            this.txtDescripServIng.Location = new System.Drawing.Point(285, 151);
            this.txtDescripServIng.Multiline = true;
            this.txtDescripServIng.Name = "txtDescripServIng";
            this.txtDescripServIng.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.txtDescripServIng.Size = new System.Drawing.Size(435, 73);
            this.txtDescripServIng.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(177, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Texto Descripción";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(177, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Texto Descripción";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtDescripGastEsp
            // 
            this.txtDescripGastEsp.Location = new System.Drawing.Point(285, 230);
            this.txtDescripGastEsp.Multiline = true;
            this.txtDescripGastEsp.Name = "txtDescripGastEsp";
            this.txtDescripGastEsp.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.txtDescripGastEsp.Size = new System.Drawing.Size(435, 51);
            this.txtDescripGastEsp.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(174, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "de Gastos Español";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(182, 303);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "de Gastos Inglés";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtDescripGastIng
            // 
            this.txtDescripGastIng.Location = new System.Drawing.Point(285, 287);
            this.txtDescripGastIng.Multiline = true;
            this.txtDescripGastIng.Name = "txtDescripGastIng";
            this.txtDescripGastIng.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.txtDescripGastIng.Size = new System.Drawing.Size(435, 51);
            this.txtDescripGastIng.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(177, 290);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Texto Descripción";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ucPartePresupuesto
            // 
            this.Size = new System.Drawing.Size(932, 505);
            this.Text = "ucPartePresupuesto";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label label8;
        private TextBox txtDescripGastIng;
        private Label label7;
        private Label label6;
        private TextBox txtDescripGastEsp;
        private Label label5;
        private Label label4;
        private TextBox txtDescripServIng;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtIDPartePresupuesto;
        private TextBox txtDescripServEsp;
        private Label label29;
        private Base.ucTextSearchBox tSBTramite;
        private Label label10;


    }
}