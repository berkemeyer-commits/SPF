using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.UserControls.UI
{
    partial class ucCRUDAreaContabilidad
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
            this.txtAreaID = new Gizmox.WebGUI.Forms.TextBox();
            this.txtDescripcionArea = new Gizmox.WebGUI.Forms.TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.tSBCArea = new SPF.UserControls.Base.ucTextSearchBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.tSBUnidadNegocio = new SPF.UserControls.Base.ucTextSearchBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListadoABM
            // 
            this.dgvListadoABM.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dgvListadoABM.Size = new System.Drawing.Size(1023, 398);
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
            this.pnlDetalle.Controls.Add(this.tSBUnidadNegocio);
            this.pnlDetalle.Controls.Add(this.label5);
            this.pnlDetalle.Controls.Add(this.label4);
            this.pnlDetalle.Controls.Add(this.label3);
            this.pnlDetalle.Controls.Add(this.tSBCArea);
            this.pnlDetalle.Controls.Add(this.label2);
            this.pnlDetalle.Controls.Add(this.txtDescripcionArea);
            this.pnlDetalle.Controls.Add(this.txtAreaID);
            this.pnlDetalle.Controls.Add(this.label1);
            this.pnlDetalle.Size = new System.Drawing.Size(1043, 418);
            // 
            // tBBaseForm
            // 
            this.tBBaseForm.Size = new System.Drawing.Size(1051, 42);
            // 
            // tabListaABM
            // 
            this.tabListaABM.Alignment = Gizmox.WebGUI.Forms.TabAlignment.Top;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Area ID";
            // 
            // txtAreaID
            // 
            this.txtAreaID.BackColor = System.Drawing.SystemColors.Control;
            this.txtAreaID.Location = new System.Drawing.Point(223, 57);
            this.txtAreaID.Name = "txtAreaID";
            this.txtAreaID.ReadOnly = true;
            this.txtAreaID.Size = new System.Drawing.Size(100, 20);
            this.txtAreaID.TabIndex = 1;
            this.txtAreaID.TabStop = false;
            // 
            // txtDescripcionArea
            // 
            this.txtDescripcionArea.Location = new System.Drawing.Point(223, 102);
            this.txtDescripcionArea.Name = "txtDescripcionArea";
            this.txtDescripcionArea.Size = new System.Drawing.Size(378, 20);
            this.txtDescripcionArea.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Descripción";
            // 
            // tSBCArea
            // 
            this.tSBCArea.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBCArea.BackColor = System.Drawing.SystemColors.Control;
            this.tSBCArea.DBContext = null;
            this.tSBCArea.DisplayMember = "";
            this.tSBCArea.KeyMember = "";
            this.tSBCArea.LabelCampoBusqueda = "";
            this.tSBCArea.Location = new System.Drawing.Point(223, 186);
            this.tSBCArea.Name = "tSBCArea";
            this.tSBCArea.NombreCampoDescrip = "";
            this.tSBCArea.NombreCampoID = "";
            this.tSBCArea.Size = new System.Drawing.Size(378, 20);
            this.tSBCArea.TabIndex = 2;
            this.tSBCArea.Text = "ucTextSearchBox";
            this.tSBCArea.TituloBuscador = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Area";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(111, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Equiv. Marcas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(111, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Unidad de Negocio";
            // 
            // tSBUnidadNegocio
            // 
            this.tSBUnidadNegocio.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBUnidadNegocio.BackColor = System.Drawing.SystemColors.Control;
            this.tSBUnidadNegocio.DBContext = null;
            this.tSBUnidadNegocio.DisplayMember = "";
            this.tSBUnidadNegocio.KeyMember = "";
            this.tSBUnidadNegocio.LabelCampoBusqueda = "";
            this.tSBUnidadNegocio.Location = new System.Drawing.Point(223, 145);
            this.tSBUnidadNegocio.Name = "tSBUnidadNegocio";
            this.tSBUnidadNegocio.NombreCampoDescrip = "";
            this.tSBUnidadNegocio.NombreCampoID = "";
            this.tSBUnidadNegocio.Size = new System.Drawing.Size(378, 20);
            this.tSBUnidadNegocio.TabIndex = 1;
            this.tSBUnidadNegocio.Text = "ucTextSearchBox";
            this.tSBUnidadNegocio.TituloBuscador = "";
            // 
            // ucCRUDAreaContabilidad
            // 
            this.Size = new System.Drawing.Size(1053, 525);
            this.Text = "ucCRUDAreaContabilidad";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label2;
        private TextBox txtDescripcionArea;
        private TextBox txtAreaID;
        private Label label1;
        private Label label4;
        private Label label3;
        private Base.ucTextSearchBox tSBCArea;
        private Base.ucTextSearchBox tSBUnidadNegocio;
        private Label label5;


    }
}