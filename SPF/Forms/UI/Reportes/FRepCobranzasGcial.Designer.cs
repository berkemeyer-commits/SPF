using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.UI.Reportes
{
    partial class FRepCobranzasGcial
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.txtFechaHasta = new Gizmox.WebGUI.Forms.TextBox();
            this.txtFechaDesde = new Gizmox.WebGUI.Forms.TextBox();
            this.dtpFechaDesde = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label21 = new Gizmox.WebGUI.Forms.Label();
            this.label18 = new Gizmox.WebGUI.Forms.Label();
            this.dtpFechaHasta = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.txtCobroID = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.tSBBanco = new SPF.UserControls.Base.ucTextSearchBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.txtNroCheque = new Gizmox.WebGUI.Forms.TextBox();
            this.tSBFormaPago = new SPF.UserControls.Base.ucTextSearchBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.tSBMoneda = new SPF.UserControls.Base.ucTextSearchBox();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.chkIncluirSoloCobrosNuevos = new Gizmox.WebGUI.Forms.CheckBox();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.label9 = new Gizmox.WebGUI.Forms.Label();
            this.tSBUnidadNegocio = new SPF.UserControls.Base.ucTextSearchBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrigen)).BeginInit();
            this.grpFiltro.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDestino)).BeginInit();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Size = new System.Drawing.Size(1008, 92);
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(0, 92);
            this.panel4.Size = new System.Drawing.Size(1008, 153);
            // 
            // panel8
            // 
            this.panel8.Size = new System.Drawing.Size(1008, 133);
            // 
            // dgvOrigen
            // 
            this.dgvOrigen.AllowUserToAddRows = false;
            this.dgvOrigen.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvOrigen.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrigen.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.dgvOrigen.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrigen.ItemsPerPage = 4;
            this.dgvOrigen.MultiSelect = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.dgvOrigen.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOrigen.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrigen.Size = new System.Drawing.Size(1008, 133);
            this.dgvOrigen.TabIndex = 10;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(961, 44);
            this.btnFiltrar.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btnFiltrar, "Aplicar Filtros");
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click_1);
            // 
            // grpFiltro
            // 
            this.grpFiltro.Controls.Add(this.tSBUnidadNegocio);
            this.grpFiltro.Controls.Add(this.label9);
            this.grpFiltro.Controls.Add(this.label8);
            this.grpFiltro.Controls.Add(this.label7);
            this.grpFiltro.Controls.Add(this.label6);
            this.grpFiltro.Controls.Add(this.tSBMoneda);
            this.grpFiltro.Controls.Add(this.label4);
            this.grpFiltro.Controls.Add(this.label3);
            this.grpFiltro.Controls.Add(this.tSBFormaPago);
            this.grpFiltro.Controls.Add(this.txtNroCheque);
            this.grpFiltro.Controls.Add(this.label2);
            this.grpFiltro.Controls.Add(this.tSBBanco);
            this.grpFiltro.Controls.Add(this.label5);
            this.grpFiltro.Controls.Add(this.label1);
            this.grpFiltro.Controls.Add(this.txtCobroID);
            this.grpFiltro.Controls.Add(this.txtFechaHasta);
            this.grpFiltro.Controls.Add(this.txtFechaDesde);
            this.grpFiltro.Controls.Add(this.dtpFechaHasta);
            this.grpFiltro.Controls.Add(this.label18);
            this.grpFiltro.Controls.Add(this.label21);
            this.grpFiltro.Controls.Add(this.dtpFechaDesde);
            this.grpFiltro.Controls.SetChildIndex(this.btnFiltrar, 0);
            this.grpFiltro.Controls.SetChildIndex(this.dtpFechaDesde, 0);
            this.grpFiltro.Controls.SetChildIndex(this.label21, 0);
            this.grpFiltro.Controls.SetChildIndex(this.label18, 0);
            this.grpFiltro.Controls.SetChildIndex(this.dtpFechaHasta, 0);
            this.grpFiltro.Controls.SetChildIndex(this.txtFechaDesde, 0);
            this.grpFiltro.Controls.SetChildIndex(this.txtFechaHasta, 0);
            this.grpFiltro.Controls.SetChildIndex(this.txtCobroID, 0);
            this.grpFiltro.Controls.SetChildIndex(this.label1, 0);
            this.grpFiltro.Controls.SetChildIndex(this.label5, 0);
            this.grpFiltro.Controls.SetChildIndex(this.tSBBanco, 0);
            this.grpFiltro.Controls.SetChildIndex(this.label2, 0);
            this.grpFiltro.Controls.SetChildIndex(this.txtNroCheque, 0);
            this.grpFiltro.Controls.SetChildIndex(this.tSBFormaPago, 0);
            this.grpFiltro.Controls.SetChildIndex(this.label3, 0);
            this.grpFiltro.Controls.SetChildIndex(this.label4, 0);
            this.grpFiltro.Controls.SetChildIndex(this.tSBMoneda, 0);
            this.grpFiltro.Controls.SetChildIndex(this.label6, 0);
            this.grpFiltro.Controls.SetChildIndex(this.label7, 0);
            this.grpFiltro.Controls.SetChildIndex(this.label8, 0);
            this.grpFiltro.Controls.SetChildIndex(this.label9, 0);
            this.grpFiltro.Controls.SetChildIndex(this.tSBUnidadNegocio, 0);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.chkIncluirSoloCobrosNuevos);
            // 
            // btnCancelar
            // 
            this.btnCancelar.TabIndex = 15;
            // 
            // btnAceptar
            // 
            this.btnAceptar.TabIndex = 14;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // cbMarcarTodo
            // 
            this.cbMarcarTodo.TabIndex = 11;
            // 
            // btnEliminarTodo
            // 
            this.btnEliminarTodo.TabIndex = 13;
            this.toolTip1.SetToolTip(this.btnEliminarTodo, "Eliminar Todas las Filas de Grilla Inferior");
            // 
            // btnAgregarSeleccion
            // 
            this.btnAgregarSeleccion.Location = new System.Drawing.Point(130, 1);
            this.btnAgregarSeleccion.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btnAgregarSeleccion, "Agregar Filas Seleccionadas");
            this.btnAgregarSeleccion.Click += new System.EventHandler(this.btnAgregarSeleccion_Click_1);
            // 
            // btnEliminarSeleccion
            // 
            this.btnEliminarSeleccion.TabIndex = 12;
            // 
            // dgvDestino
            // 
            this.dgvDestino.AllowUserToAddRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvDestino.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDestino.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle5.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.dgvDestino.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDestino.ItemsPerPage = 5;
            this.dgvDestino.MultiSelect = false;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.dgvDestino.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDestino.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDestino.Size = new System.Drawing.Size(1008, 180);
            this.dgvDestino.TabIndex = 15;
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaHasta.Location = new System.Drawing.Point(249, 19);
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.Size = new System.Drawing.Size(81, 18);
            this.txtFechaHasta.TabIndex = 1;
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaDesde.Location = new System.Drawing.Point(67, 19);
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.Size = new System.Drawing.Size(81, 18);
            this.txtFechaDesde.TabIndex = 0;
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaDesde.Location = new System.Drawing.Point(66, 18);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaDesde.TabIndex = 3;
            this.dtpFechaDesde.TabStop = false;
            this.dtpFechaDesde.ValueChanged += new System.EventHandler(this.dtpFechaDesde_ValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(15, 18);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(43, 13);
            this.label21.TabIndex = 0;
            this.label21.Text = "Fecha";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(171, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(43, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Fecha Hasta";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaHasta.Location = new System.Drawing.Point(247, 18);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaHasta.TabIndex = 3;
            this.dtpFechaHasta.TabStop = false;
            this.dtpFechaHasta.ValueChanged += new System.EventHandler(this.dtpFechaHasta_ValueChanged);
            // 
            // txtCobroID
            // 
            this.txtCobroID.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtCobroID.Location = new System.Drawing.Point(538, 20);
            this.txtCobroID.Name = "txtCobroID";
            this.txtCobroID.Size = new System.Drawing.Size(146, 18);
            this.txtCobroID.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(487, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cobro ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Banco";
            // 
            // tSBBanco
            // 
            this.tSBBanco.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBBanco.BackColor = System.Drawing.Color.Transparent;
            this.tSBBanco.DBContext = null;
            this.tSBBanco.DisplayMember = "";
            this.tSBBanco.KeyMember = "";
            this.tSBBanco.LabelCampoBusqueda = "";
            this.tSBBanco.Location = new System.Drawing.Point(66, 41);
            this.tSBBanco.Name = "tSBBanco";
            this.tSBBanco.NombreCampoDescrip = "";
            this.tSBBanco.NombreCampoID = "";
            this.tSBBanco.Size = new System.Drawing.Size(416, 20);
            this.tSBBanco.SoloLectura = false;
            this.tSBBanco.TabIndex = 4;
            this.tSBBanco.Text = "ucTextSearchBox";
            this.tSBBanco.TituloBuscador = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(703, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "N° Cheque";
            // 
            // txtNroCheque
            // 
            this.txtNroCheque.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtNroCheque.Location = new System.Drawing.Point(768, 20);
            this.txtNroCheque.Name = "txtNroCheque";
            this.txtNroCheque.Size = new System.Drawing.Size(146, 18);
            this.txtNroCheque.TabIndex = 3;
            // 
            // tSBFormaPago
            // 
            this.tSBFormaPago.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBFormaPago.BackColor = System.Drawing.Color.Transparent;
            this.tSBFormaPago.DBContext = null;
            this.tSBFormaPago.DisplayMember = "";
            this.tSBFormaPago.KeyMember = "";
            this.tSBFormaPago.LabelCampoBusqueda = "";
            this.tSBFormaPago.Location = new System.Drawing.Point(538, 41);
            this.tSBFormaPago.Name = "tSBFormaPago";
            this.tSBFormaPago.NombreCampoDescrip = "";
            this.tSBFormaPago.NombreCampoID = "";
            this.tSBFormaPago.Size = new System.Drawing.Size(416, 20);
            this.tSBFormaPago.SoloLectura = false;
            this.tSBFormaPago.TabIndex = 5;
            this.tSBFormaPago.Text = "ucTextSearchBox";
            this.tSBFormaPago.TituloBuscador = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(487, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "de Pago";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(487, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Forma";
            // 
            // tSBMoneda
            // 
            this.tSBMoneda.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBMoneda.BackColor = System.Drawing.Color.Transparent;
            this.tSBMoneda.DBContext = null;
            this.tSBMoneda.DisplayMember = "";
            this.tSBMoneda.KeyMember = "";
            this.tSBMoneda.LabelCampoBusqueda = "";
            this.tSBMoneda.Location = new System.Drawing.Point(66, 64);
            this.tSBMoneda.Name = "tSBMoneda";
            this.tSBMoneda.NombreCampoDescrip = "";
            this.tSBMoneda.NombreCampoID = "";
            this.tSBMoneda.Size = new System.Drawing.Size(416, 20);
            this.tSBMoneda.SoloLectura = false;
            this.tSBMoneda.TabIndex = 6;
            this.tSBMoneda.Text = "ucTextSearchBox";
            this.tSBMoneda.TituloBuscador = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Moneda";
            // 
            // chkIncluirSoloCobrosNuevos
            // 
            this.chkIncluirSoloCobrosNuevos.AutoSize = true;
            this.chkIncluirSoloCobrosNuevos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIncluirSoloCobrosNuevos.Checked = true;
            this.chkIncluirSoloCobrosNuevos.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.chkIncluirSoloCobrosNuevos.Location = new System.Drawing.Point(674, 0);
            this.chkIncluirSoloCobrosNuevos.Name = "chkIncluirSoloCobrosNuevos";
            this.chkIncluirSoloCobrosNuevos.Size = new System.Drawing.Size(239, 17);
            this.chkIncluirSoloCobrosNuevos.TabIndex = 9;
            this.chkIncluirSoloCobrosNuevos.Text = "Incluir sólo cobros posteriores al 01/01/1900";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Desde";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(487, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Unid. de";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(487, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Negocio";
            // 
            // tSBUnidadNegocio
            // 
            this.tSBUnidadNegocio.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBUnidadNegocio.BackColor = System.Drawing.Color.Transparent;
            this.tSBUnidadNegocio.DBContext = null;
            this.tSBUnidadNegocio.DisplayMember = "";
            this.tSBUnidadNegocio.KeyMember = "";
            this.tSBUnidadNegocio.LabelCampoBusqueda = "";
            this.tSBUnidadNegocio.Location = new System.Drawing.Point(538, 64);
            this.tSBUnidadNegocio.Name = "tSBUnidadNegocio";
            this.tSBUnidadNegocio.NombreCampoDescrip = "";
            this.tSBUnidadNegocio.NombreCampoID = "";
            this.tSBUnidadNegocio.Size = new System.Drawing.Size(416, 20);
            this.tSBUnidadNegocio.SoloLectura = false;
            this.tSBUnidadNegocio.TabIndex = 7;
            this.tSBUnidadNegocio.Text = "ucTextSearchBox";
            this.tSBUnidadNegocio.TituloBuscador = "";
            // 
            // FRepCobranzasGcial
            // 
            this.Text = "FRepCobranzasGcial";
            this.Load += new System.EventHandler(this.FRepCobranzasGcial_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrigen)).EndInit();
            this.grpFiltro.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDestino)).EndInit();
            this.panel10.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox txtFechaHasta;
        private TextBox txtFechaDesde;
        private DateTimePicker dtpFechaHasta;
        private Label label18;
        private Label label21;
        private DateTimePicker dtpFechaDesde;
        private Label label1;
        private TextBox txtCobroID;
        private Label label5;
        private TextBox txtNroCheque;
        private Label label2;
        private UserControls.Base.ucTextSearchBox tSBBanco;
        private Label label4;
        private Label label3;
        private UserControls.Base.ucTextSearchBox tSBFormaPago;
        private CheckBox chkIncluirSoloCobrosNuevos;
        private Label label6;
        private UserControls.Base.ucTextSearchBox tSBMoneda;
        private Label label7;
        private UserControls.Base.ucTextSearchBox tSBUnidadNegocio;
        private Label label9;
        private Label label8;


    }
}