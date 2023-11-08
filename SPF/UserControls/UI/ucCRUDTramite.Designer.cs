using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.UserControls.UI
{
    partial class ucCRUDTramite
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
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.txtTramiteID = new Gizmox.WebGUI.Forms.TextBox();
            this.txtDescripTramite = new Gizmox.WebGUI.Forms.TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.txtAbreviatura = new Gizmox.WebGUI.Forms.TextBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.txtAbrevContab = new Gizmox.WebGUI.Forms.TextBox();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.tSBProceso = new SPF.UserControls.Base.ucTextSearchBox();
            this.tSBTrabajoTipo = new SPF.UserControls.Base.ucTextSearchBox();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.txtBolAbrev = new Gizmox.WebGUI.Forms.TextBox();
            this.label9 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.tSBAreaContab = new SPF.UserControls.Base.ucTextSearchBox();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.label10 = new Gizmox.WebGUI.Forms.Label();
            this.txtEtiquetaEspanol = new Gizmox.WebGUI.Forms.TextBox();
            this.label11 = new Gizmox.WebGUI.Forms.Label();
            this.txtEtiquetaIngles = new Gizmox.WebGUI.Forms.TextBox();
            this.textBox1 = new Gizmox.WebGUI.Forms.TextBox();
            this.label12 = new Gizmox.WebGUI.Forms.Label();
            this.label13 = new Gizmox.WebGUI.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).BeginInit();
            this.pnlListadoContainer.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.pnlTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListadoABM
            // 
            this.dgvListadoABM.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dgvListadoABM.Size = new System.Drawing.Size(1102, 400);
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
            this.pnlDetalle.Controls.Add(this.label13);
            this.pnlDetalle.Controls.Add(this.label12);
            this.pnlDetalle.Controls.Add(this.textBox1);
            this.pnlDetalle.Controls.Add(this.txtEtiquetaIngles);
            this.pnlDetalle.Controls.Add(this.label11);
            this.pnlDetalle.Controls.Add(this.txtEtiquetaEspanol);
            this.pnlDetalle.Controls.Add(this.label10);
            this.pnlDetalle.Controls.Add(this.label6);
            this.pnlDetalle.Controls.Add(this.tSBAreaContab);
            this.pnlDetalle.Controls.Add(this.label4);
            this.pnlDetalle.Controls.Add(this.label9);
            this.pnlDetalle.Controls.Add(this.txtBolAbrev);
            this.pnlDetalle.Controls.Add(this.label8);
            this.pnlDetalle.Controls.Add(this.label7);
            this.pnlDetalle.Controls.Add(this.tSBTrabajoTipo);
            this.pnlDetalle.Controls.Add(this.tSBProceso);
            this.pnlDetalle.Controls.Add(this.label5);
            this.pnlDetalle.Controls.Add(this.txtAbrevContab);
            this.pnlDetalle.Controls.Add(this.label3);
            this.pnlDetalle.Controls.Add(this.txtAbreviatura);
            this.pnlDetalle.Controls.Add(this.label2);
            this.pnlDetalle.Controls.Add(this.txtDescripTramite);
            this.pnlDetalle.Controls.Add(this.txtTramiteID);
            this.pnlDetalle.Controls.Add(this.label1);
            this.pnlDetalle.Size = new System.Drawing.Size(1122, 420);
            // 
            // tBBaseForm
            // 
            this.tBBaseForm.Size = new System.Drawing.Size(1130, 42);
            // 
            // tbbNuevo
            // 
            this.tbbNuevo.Click += new System.EventHandler(this.tbbNuevo_Click);
            // 
            // tabListaABM
            // 
            this.tabListaABM.Alignment = Gizmox.WebGUI.Forms.TabAlignment.Top;
            this.pnlListadoContainer.Controls.SetChildIndex(this.dgvListadoABM, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(142, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trámite ID";
            // 
            // txtTramiteID
            // 
            this.txtTramiteID.BackColor = System.Drawing.SystemColors.Control;
            this.txtTramiteID.Location = new System.Drawing.Point(226, 33);
            this.txtTramiteID.Name = "txtTramiteID";
            this.txtTramiteID.ReadOnly = true;
            this.txtTramiteID.Size = new System.Drawing.Size(96, 20);
            this.txtTramiteID.TabIndex = 1;
            this.txtTramiteID.TabStop = false;
            // 
            // txtDescripTramite
            // 
            this.txtDescripTramite.Location = new System.Drawing.Point(226, 100);
            this.txtDescripTramite.Name = "txtDescripTramite";
            this.txtDescripTramite.Size = new System.Drawing.Size(341, 20);
            this.txtDescripTramite.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Descripción";
            // 
            // txtAbreviatura
            // 
            this.txtAbreviatura.Location = new System.Drawing.Point(226, 137);
            this.txtAbreviatura.Name = "txtAbreviatura";
            this.txtAbreviatura.Size = new System.Drawing.Size(137, 20);
            this.txtAbreviatura.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(142, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Abreviatura";
            // 
            // txtAbrevContab
            // 
            this.txtAbrevContab.Location = new System.Drawing.Point(226, 240);
            this.txtAbrevContab.Name = "txtAbrevContab";
            this.txtAbrevContab.Size = new System.Drawing.Size(341, 20);
            this.txtAbrevContab.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(142, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Abreviatura ID";
            // 
            // tSBProceso
            // 
            this.tSBProceso.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBProceso.BackColor = System.Drawing.SystemColors.Control;
            this.tSBProceso.DBContext = null;
            this.tSBProceso.DisplayMember = "";
            this.tSBProceso.KeyMember = "";
            this.tSBProceso.LabelCampoBusqueda = "";
            this.tSBProceso.Location = new System.Drawing.Point(226, 65);
            this.tSBProceso.Name = "tSBProceso";
            this.tSBProceso.NombreCampoDescrip = "";
            this.tSBProceso.NombreCampoID = "";
            this.tSBProceso.Size = new System.Drawing.Size(378, 20);
            this.tSBProceso.SoloLectura = false;
            this.tSBProceso.TabIndex = 0;
            this.tSBProceso.Text = "ucTextSearchBox";
            this.tSBProceso.TituloBuscador = "";
            // 
            // tSBTrabajoTipo
            // 
            this.tSBTrabajoTipo.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBTrabajoTipo.BackColor = System.Drawing.SystemColors.Control;
            this.tSBTrabajoTipo.DBContext = null;
            this.tSBTrabajoTipo.DisplayMember = "";
            this.tSBTrabajoTipo.KeyMember = "";
            this.tSBTrabajoTipo.LabelCampoBusqueda = "";
            this.tSBTrabajoTipo.Location = new System.Drawing.Point(226, 170);
            this.tSBTrabajoTipo.Name = "tSBTrabajoTipo";
            this.tSBTrabajoTipo.NombreCampoDescrip = "";
            this.tSBTrabajoTipo.NombreCampoID = "";
            this.tSBTrabajoTipo.Size = new System.Drawing.Size(378, 20);
            this.tSBTrabajoTipo.SoloLectura = false;
            this.tSBTrabajoTipo.TabIndex = 4;
            this.tSBTrabajoTipo.Text = "ucTextSearchBox";
            this.tSBTrabajoTipo.TituloBuscador = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(142, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Proceso ID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(367, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Abrev. Boletín";
            // 
            // txtBolAbrev
            // 
            this.txtBolAbrev.Location = new System.Drawing.Point(451, 137);
            this.txtBolAbrev.Name = "txtBolAbrev";
            this.txtBolAbrev.Size = new System.Drawing.Size(116, 20);
            this.txtBolAbrev.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(142, 174);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Tipo Trabajo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(142, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Area";
            // 
            // tSBAreaContab
            // 
            this.tSBAreaContab.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBAreaContab.BackColor = System.Drawing.SystemColors.Control;
            this.tSBAreaContab.DBContext = null;
            this.tSBAreaContab.DisplayMember = "";
            this.tSBAreaContab.KeyMember = "";
            this.tSBAreaContab.LabelCampoBusqueda = "";
            this.tSBAreaContab.Location = new System.Drawing.Point(226, 206);
            this.tSBAreaContab.Name = "tSBAreaContab";
            this.tSBAreaContab.NombreCampoDescrip = "";
            this.tSBAreaContab.NombreCampoID = "";
            this.tSBAreaContab.Size = new System.Drawing.Size(378, 20);
            this.tSBAreaContab.SoloLectura = false;
            this.tSBAreaContab.TabIndex = 5;
            this.tSBAreaContab.Text = "ucTextSearchBox";
            this.tSBAreaContab.TituloBuscador = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(142, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Presupuesto";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(142, 282);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Etiq. Español";
            // 
            // txtEtiquetaEspanol
            // 
            this.txtEtiquetaEspanol.Location = new System.Drawing.Point(226, 278);
            this.txtEtiquetaEspanol.Name = "txtEtiquetaEspanol";
            this.txtEtiquetaEspanol.Size = new System.Drawing.Size(341, 20);
            this.txtEtiquetaEspanol.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(142, 319);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Etiq. Inglés";
            // 
            // txtEtiquetaIngles
            // 
            this.txtEtiquetaIngles.Location = new System.Drawing.Point(226, 315);
            this.txtEtiquetaIngles.Name = "txtEtiquetaIngles";
            this.txtEtiquetaIngles.Size = new System.Drawing.Size(341, 20);
            this.txtEtiquetaIngles.TabIndex = 8;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(226, 347);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(161, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.textBox1.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(142, 345);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Tasa DINAPI";
            this.label12.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(143, 358);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "(Guaraníes)";
            this.label13.Visible = false;
            // 
            // ucCRUDTramite
            // 
            this.Size = new System.Drawing.Size(1132, 527);
            this.Text = "ucCRUDTramite";
            this.Click += new System.EventHandler(this.tbbEditar_Click);
            this.VisibleChanged += new System.EventHandler(this.ucCRUDTramite_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).EndInit();
            this.pnlListadoContainer.ResumeLayout(false);
            this.pnlContainer.ResumeLayout(false);
            this.pnlTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label label5;
        private TextBox txtAbrevContab;
        private Label label3;
        private TextBox txtAbreviatura;
        private Label label2;
        private TextBox txtDescripTramite;
        private TextBox txtTramiteID;
        private Label label1;
        private Base.ucTextSearchBox tSBTrabajoTipo;
        private Base.ucTextSearchBox tSBProceso;
        private Label label7;
        private Base.ucTextSearchBox tSBAreaContab;
        private Label label4;
        private Label label9;
        private TextBox txtBolAbrev;
        private Label label8;
        private Label label6;
        private TextBox txtEtiquetaIngles;
        private Label label11;
        private TextBox txtEtiquetaEspanol;
        private Label label10;
        private Label label13;
        private Label label12;
        private TextBox textBox1;


    }
}