using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.UserControls.UI
{
    partial class ucCRUDBancos
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
            this.textBox4 = new Gizmox.WebGUI.Forms.TextBox();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.textBox3 = new Gizmox.WebGUI.Forms.TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.tSBPais = new SPF.UserControls.Base.ucTextSearchBox();
            this.tSBCiudad = new SPF.UserControls.Base.ucTextSearchBox();
            this.txtNombreBanco = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.txtBancoID = new Gizmox.WebGUI.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).BeginInit();
            this.label8.SuspendLayout();
            this.label4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListadoABM
            // 
            this.dgvListadoABM.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dgvListadoABM.Size = new System.Drawing.Size(1094, 339);
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
            this.tbbGuardar.Click += new System.EventHandler(this.tbbGuardar_Click_1);
            // 
            // tbbCancelar
            // 
            this.tbbCancelar.Click += new System.EventHandler(this.tbbCancelar_Click);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.txtBancoID);
            this.pnlDetalle.Controls.Add(this.label1);
            this.pnlDetalle.Controls.Add(this.txtNombreBanco);
            this.pnlDetalle.Controls.Add(this.tSBCiudad);
            this.pnlDetalle.Controls.Add(this.tSBPais);
            this.pnlDetalle.Controls.Add(this.label4);
            this.pnlDetalle.Controls.Add(this.label8);
            this.pnlDetalle.Size = new System.Drawing.Size(1114, 359);
            // 
            // tBBaseForm
            // 
            this.tBBaseForm.Size = new System.Drawing.Size(1122, 42);
            // 
            // tbbNuevo
            // 
            this.tbbNuevo.Click += new System.EventHandler(this.tbbNuevo_Click);
            // 
            // tabListaABM
            // 
            this.tabListaABM.Alignment = Gizmox.WebGUI.Forms.TabAlignment.Top;
            this.tabListaABM.Size = new System.Drawing.Size(1122, 388);
            // 
            // textBox4
            // 
            this.textBox4.AllowDrag = false;
            this.textBox4.Location = new System.Drawing.Point(-184, -4);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(-279, -1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Cliente";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Controls.Add(this.textBox4);
            this.label8.Controls.Add(this.label7);
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label8.Location = new System.Drawing.Point(84, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Ciudad";
            // 
            // textBox3
            // 
            this.textBox3.AllowDrag = false;
            this.textBox3.Location = new System.Drawing.Point(-184, -4);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(-279, -1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cliente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Controls.Add(this.textBox3);
            this.label4.Controls.Add(this.label2);
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.Location = new System.Drawing.Point(84, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "País";
            // 
            // tSBPais
            // 
            this.tSBPais.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBPais.DBContext = null;
            this.tSBPais.DisplayMember = "";
            this.tSBPais.KeyMember = "";
            this.tSBPais.LabelCampoBusqueda = "";
            this.tSBPais.Location = new System.Drawing.Point(138, 90);
            this.tSBPais.Name = "tSBPais";
            this.tSBPais.NombreCampoDescrip = "";
            this.tSBPais.NombreCampoID = "";
            this.tSBPais.Size = new System.Drawing.Size(467, 20);
            this.tSBPais.TabIndex = 1;
            this.tSBPais.Text = "ucTextSearchBox";
            this.tSBPais.TituloBuscador = "";
            // 
            // tSBCiudad
            // 
            this.tSBCiudad.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBCiudad.DBContext = null;
            this.tSBCiudad.DisplayMember = "";
            this.tSBCiudad.KeyMember = "";
            this.tSBCiudad.LabelCampoBusqueda = "";
            this.tSBCiudad.Location = new System.Drawing.Point(138, 133);
            this.tSBCiudad.Name = "tSBCiudad";
            this.tSBCiudad.NombreCampoDescrip = "";
            this.tSBCiudad.NombreCampoID = "";
            this.tSBCiudad.Size = new System.Drawing.Size(467, 20);
            this.tSBCiudad.TabIndex = 2;
            this.tSBCiudad.Text = "ucTextSearchBox";
            this.tSBCiudad.TituloBuscador = "";
            // 
            // txtNombreBanco
            // 
            this.txtNombreBanco.Location = new System.Drawing.Point(238, 49);
            this.txtNombreBanco.Name = "txtNombreBanco";
            this.txtNombreBanco.Size = new System.Drawing.Size(367, 20);
            this.txtNombreBanco.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Banco";
            // 
            // txtBancoID
            // 
            this.txtBancoID.BackColor = System.Drawing.SystemColors.Control;
            this.txtBancoID.Location = new System.Drawing.Point(136, 49);
            this.txtBancoID.Name = "txtBancoID";
            this.txtBancoID.ReadOnly = true;
            this.txtBancoID.Size = new System.Drawing.Size(100, 20);
            this.txtBancoID.TabIndex = 1;
            this.txtBancoID.TabStop = false;
            this.txtBancoID.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // ucCRUDBancos
            // 
            this.Size = new System.Drawing.Size(1124, 466);
            this.Text = "ucCRUDBancos";
            this.VisibleChanged += new System.EventHandler(this.ucCRUDBancos_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).EndInit();
            this.label8.ResumeLayout(false);
            this.label4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Base.ucTextSearchBox tSBCiudad;
        private Base.ucTextSearchBox tSBPais;
        private Label label4;
        private TextBox textBox3;
        private Label label2;
        private Label label8;
        private TextBox textBox4;
        private Label label7;
        private TextBox txtBancoID;
        private Label label1;
        private TextBox txtNombreBanco;


    }
}