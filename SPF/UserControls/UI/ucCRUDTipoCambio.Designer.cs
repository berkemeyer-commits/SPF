using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.UserControls.UI
{
    partial class ucCRUDTipoCambio
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
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.txtTipoCambioD = new Gizmox.WebGUI.Forms.TextBox();
            this.label13 = new Gizmox.WebGUI.Forms.Label();
            this.dtpFecha = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label18 = new Gizmox.WebGUI.Forms.Label();
            this.label9 = new Gizmox.WebGUI.Forms.Label();
            this.tSBMoneda = new SPF.UserControls.Base.ucTextSearchBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.lblValor = new Gizmox.WebGUI.Forms.Label();
            this.txtValor = new Gizmox.WebGUI.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).BeginInit();
            this.tabListaABM.SuspendLayout();
            this.tpDetalle.SuspendLayout();
            this.label9.SuspendLayout();
            this.lblValor.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListadoABM
            // 
            this.dgvListadoABM.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dgvListadoABM.Size = new System.Drawing.Size(1094, 339);
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
            this.pnlDetalle.Controls.Add(this.txtValor);
            this.pnlDetalle.Controls.Add(this.lblValor);
            this.pnlDetalle.Controls.Add(this.tSBMoneda);
            this.pnlDetalle.Controls.Add(this.label9);
            this.pnlDetalle.Controls.Add(this.dtpFecha);
            this.pnlDetalle.Controls.Add(this.label13);
            this.pnlDetalle.Controls.Add(this.txtTipoCambioD);
            this.pnlDetalle.Controls.Add(this.label1);
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
            // tpDetalle
            // 
            this.tpDetalle.Size = new System.Drawing.Size(1114, 359);
            // 
            // tpListado
            // 
            this.tpListado.Size = new System.Drawing.Size(1114, 359);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID Timbrado";
            // 
            // txtTipoCambioD
            // 
            this.txtTipoCambioD.BackColor = System.Drawing.SystemColors.Control;
            this.txtTipoCambioD.Location = new System.Drawing.Point(158, 26);
            this.txtTipoCambioD.Name = "txtTipoCambioD";
            this.txtTipoCambioD.ReadOnly = true;
            this.txtTipoCambioD.Size = new System.Drawing.Size(79, 20);
            this.txtTipoCambioD.TabIndex = 1;
            this.txtTipoCambioD.TabStop = false;
            this.txtTipoCambioD.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(71, 54);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Fecha";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(158, 50);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(100, 21);
            this.dtpFecha.TabIndex = 4;
            this.dtpFecha.TabStop = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(-170, -1);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Area";
            this.label18.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Controls.Add(this.label18);
            this.label9.Location = new System.Drawing.Point(71, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Moneda";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tSBMoneda
            // 
            this.tSBMoneda.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBMoneda.BackColor = System.Drawing.Color.Transparent;
            this.tSBMoneda.DBContext = null;
            this.tSBMoneda.DisplayMember = "";
            this.tSBMoneda.KeyMember = "";
            this.tSBMoneda.LabelCampoBusqueda = "";
            this.tSBMoneda.Location = new System.Drawing.Point(158, 75);
            this.tSBMoneda.Name = "tSBMoneda";
            this.tSBMoneda.NombreCampoDescrip = "";
            this.tSBMoneda.NombreCampoID = "";
            this.tSBMoneda.Size = new System.Drawing.Size(356, 20);
            this.tSBMoneda.SoloLectura = false;
            this.tSBMoneda.TabIndex = 4;
            this.tSBMoneda.Text = "ucTextSearchBox";
            this.tSBMoneda.TituloBuscador = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-170, -1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Area";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Controls.Add(this.label2);
            this.lblValor.Location = new System.Drawing.Point(71, 106);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(35, 13);
            this.lblValor.TabIndex = 0;
            this.lblValor.Text = "T.C.";
            this.lblValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(158, 102);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(100, 20);
            this.txtValor.TabIndex = 5;
            // 
            // ucCRUDTipoCambio
            // 
            this.Size = new System.Drawing.Size(1124, 466);
            this.Text = "ucCRUDBancos";
            this.VisibleChanged += new System.EventHandler(this.ucCRUDMovimientoCuenta_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).EndInit();
            this.tabListaABM.ResumeLayout(false);
            this.tpDetalle.ResumeLayout(false);
            this.label9.ResumeLayout(false);
            this.lblValor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox txtTipoCambioD;
        private Label label1;
        private DateTimePicker dtpFecha;
        private Label label13;
        private Base.ucTextSearchBox tSBMoneda;
        private Label label9;
        private Label label18;
        private TextBox txtValor;
        private Label lblValor;
        private Label label2;


    }
}