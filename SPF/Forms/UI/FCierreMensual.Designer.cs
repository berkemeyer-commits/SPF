using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.UI
{
    partial class FCierreMensual
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
            this.cbAnho = new Gizmox.WebGUI.Forms.ComboBox();
            this.textBox5 = new Gizmox.WebGUI.Forms.TextBox();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.cbMes = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblEtiquetaCicloNoCerrado = new Gizmox.WebGUI.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrigen)).BeginInit();
            this.grpFiltro.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDestino)).BeginInit();
            this.panel10.SuspendLayout();
            this.label6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(746, 517);
            // 
            // panel3
            // 
            this.panel3.Size = new System.Drawing.Size(746, 62);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 471);
            this.panel2.Size = new System.Drawing.Size(746, 46);
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(0, 291);
            this.panel5.Size = new System.Drawing.Size(746, 180);
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(0, 62);
            this.panel4.Size = new System.Drawing.Size(746, 188);
            // 
            // panel6
            // 
            this.panel6.Location = new System.Drawing.Point(0, 250);
            this.panel6.Size = new System.Drawing.Size(746, 41);
            // 
            // panel8
            // 
            this.panel8.Size = new System.Drawing.Size(746, 168);
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
            this.dgvOrigen.Size = new System.Drawing.Size(746, 168);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(565, 14);
            this.toolTip1.SetToolTip(this.btnFiltrar, "Recuperar Datos del Cierre");
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click_1);
            // 
            // grpFiltro
            // 
            this.grpFiltro.Controls.Add(this.cbMes);
            this.grpFiltro.Controls.Add(this.label2);
            this.grpFiltro.Controls.Add(this.label6);
            this.grpFiltro.Controls.Add(this.cbAnho);
            this.grpFiltro.Size = new System.Drawing.Size(746, 62);
            this.grpFiltro.Controls.SetChildIndex(this.btnFiltrar, 0);
            this.grpFiltro.Controls.SetChildIndex(this.cbAnho, 0);
            this.grpFiltro.Controls.SetChildIndex(this.label6, 0);
            this.grpFiltro.Controls.SetChildIndex(this.label2, 0);
            this.grpFiltro.Controls.SetChildIndex(this.cbMes, 0);
            // 
            // panel7
            // 
            this.panel7.Size = new System.Drawing.Size(746, 20);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(415, 5);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(259, 5);
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnEliminarTodo
            // 
            this.toolTip1.SetToolTip(this.btnEliminarTodo, "Eliminar Todas las Filas de Grilla Inferior");
            // 
            // btnAgregarSeleccion
            // 
            this.toolTip1.SetToolTip(this.btnAgregarSeleccion, "Agregar Filas Seleccionadas");
            // 
            // btnEliminarSeleccion
            // 
            this.btnEliminarSeleccion.Location = new System.Drawing.Point(647, 1);
            this.toolTip1.SetToolTip(this.btnEliminarSeleccion, "Eliminar cuenta no cerrada");
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.lblEtiquetaCicloNoCerrado);
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
            this.dgvDestino.Size = new System.Drawing.Size(746, 180);
            // 
            // cbAnho
            // 
            this.cbAnho.AllowDrag = false;
            this.cbAnho.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cbAnho.FormattingEnabled = true;
            this.cbAnho.Location = new System.Drawing.Point(206, 24);
            this.cbAnho.Name = "cbAnho";
            this.cbAnho.Size = new System.Drawing.Size(136, 21);
            this.cbAnho.TabIndex = 1;
            // 
            // textBox5
            // 
            this.textBox5.AllowDrag = false;
            this.textBox5.Location = new System.Drawing.Point(-184, -4);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Controls.Add(this.textBox5);
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label6.Location = new System.Drawing.Point(155, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Año";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.Location = new System.Drawing.Point(358, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mes";
            // 
            // cbMes
            // 
            this.cbMes.AllowDrag = false;
            this.cbMes.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cbMes.FormattingEnabled = true;
            this.cbMes.Location = new System.Drawing.Point(409, 24);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(136, 21);
            this.cbMes.TabIndex = 1;
            // 
            // lblEtiquetaCicloNoCerrado
            // 
            this.lblEtiquetaCicloNoCerrado.AutoSize = true;
            this.lblEtiquetaCicloNoCerrado.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.lblEtiquetaCicloNoCerrado.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblEtiquetaCicloNoCerrado.ForeColor = System.Drawing.Color.Red;
            this.lblEtiquetaCicloNoCerrado.Location = new System.Drawing.Point(493, 0);
            this.lblEtiquetaCicloNoCerrado.Name = "lblEtiquetaCicloNoCerrado";
            this.lblEtiquetaCicloNoCerrado.Size = new System.Drawing.Size(251, 16);
            this.lblEtiquetaCicloNoCerrado.TabIndex = 2;
            this.lblEtiquetaCicloNoCerrado.Text = "No hay cierre definido para el periodo";
            this.lblEtiquetaCicloNoCerrado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FCierreMensual
            // 
            this.Size = new System.Drawing.Size(746, 517);
            this.Text = "FCierreMensual";
            this.Load += new System.EventHandler(this.FCierreMensual_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrigen)).EndInit();
            this.grpFiltro.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDestino)).EndInit();
            this.panel10.ResumeLayout(false);
            this.label6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label label6;
        private TextBox textBox5;
        private ComboBox cbAnho;
        private ComboBox cbMes;
        private Label label2;
        private Label lblEtiquetaCicloNoCerrado;


    }
}