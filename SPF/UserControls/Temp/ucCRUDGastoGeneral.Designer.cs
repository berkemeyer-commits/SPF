using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.UserControls.UI
{
    partial class ucCRUDGastoGeneral
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
            this.textBox3 = new Gizmox.WebGUI.Forms.TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.txtGastoGeneralDescrip = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.txtGastoGeneralID = new Gizmox.WebGUI.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).BeginInit();
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
            this.pnlDetalle.Controls.Add(this.txtGastoGeneralID);
            this.pnlDetalle.Controls.Add(this.label1);
            this.pnlDetalle.Controls.Add(this.txtGastoGeneralDescrip);
            this.pnlDetalle.Controls.Add(this.label4);
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
            this.label4.Text = "Descripción";
            // 
            // txtGastoGeneralDescrip
            // 
            this.txtGastoGeneralDescrip.Location = new System.Drawing.Point(154, 91);
            this.txtGastoGeneralDescrip.Name = "txtGastoGeneralDescrip";
            this.txtGastoGeneralDescrip.Size = new System.Drawing.Size(367, 20);
            this.txtGastoGeneralDescrip.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID Concepto";
            // 
            // txtGastoGeneralID
            // 
            this.txtGastoGeneralID.BackColor = System.Drawing.SystemColors.Control;
            this.txtGastoGeneralID.Location = new System.Drawing.Point(154, 49);
            this.txtGastoGeneralID.Name = "txtGastoGeneralID";
            this.txtGastoGeneralID.ReadOnly = true;
            this.txtGastoGeneralID.Size = new System.Drawing.Size(100, 20);
            this.txtGastoGeneralID.TabIndex = 1;
            this.txtGastoGeneralID.TabStop = false;
            this.txtGastoGeneralID.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // ucCRUDBancos
            // 
            this.Size = new System.Drawing.Size(1124, 466);
            this.Text = "ucCRUDBancos";
            this.VisibleChanged += new System.EventHandler(this.ucCRUDGastoGeneral_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).EndInit();
            this.label4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label label4;
        private TextBox textBox3;
        private Label label2;
        private TextBox txtGastoGeneralID;
        private Label label1;
        private TextBox txtGastoGeneralDescrip;


    }
}