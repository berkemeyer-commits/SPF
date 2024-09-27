using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.UI
{
    partial class FCargarRetencionesRecibo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCargarRetencionesRecibo));
            this.btnAceptar = new Gizmox.WebGUI.Forms.Button();
            this.btnCancelar = new Gizmox.WebGUI.Forms.Button();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.btnCargarDatosRetencion = new Gizmox.WebGUI.Forms.Button();
            this.btnParaImgNCE = new Gizmox.WebGUI.Forms.Button();
            this.btnParaImgFE = new Gizmox.WebGUI.Forms.Button();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.btnActualizarDatosRetTimb = new Gizmox.WebGUI.Forms.Button();
            this.txtNroTimbrado = new Gizmox.WebGUI.Forms.TextBox();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.txtPorcRetRenta = new Gizmox.WebGUI.Forms.TextBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.txtPorcRetIVA10 = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.txtCliente = new Gizmox.WebGUI.Forms.TextBox();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.dgvRetenciones = new Gizmox.WebGUI.Forms.DataGridView();
            this.toolTip1 = new Gizmox.WebGUI.Forms.ToolTip();
            this.lblTotalImpCob = new Gizmox.WebGUI.Forms.Label();
            this.txtTotalRetIVA10 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTotalRetRenta = new Gizmox.WebGUI.Forms.TextBox();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.txtTotalRetenciones = new Gizmox.WebGUI.Forms.TextBox();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRetenciones)).BeginInit();
            this.SuspendLayout();
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
            this.btnAceptar.Location = new System.Drawing.Point(728, 5);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(94, 36);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
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
            this.btnCancelar.Location = new System.Drawing.Point(826, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(94, 36);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtTotalRetenciones);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtTotalRetRenta);
            this.panel3.Controls.Add(this.txtTotalRetIVA10);
            this.panel3.Controls.Add(this.lblTotalImpCob);
            this.panel3.Controls.Add(this.btnCargarDatosRetencion);
            this.panel3.Controls.Add(this.btnParaImgNCE);
            this.panel3.Controls.Add(this.btnParaImgFE);
            this.panel3.Controls.Add(this.btnAceptar);
            this.panel3.Controls.Add(this.btnCancelar);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 455);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(931, 47);
            this.panel3.TabIndex = 1;
            // 
            // btnCargarDatosRetencion
            // 
            this.btnCargarDatosRetencion.CustomStyle = "F";
            this.btnCargarDatosRetencion.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnCargarDatosRetencion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCargarDatosRetencion.ForeColor = System.Drawing.Color.White;
            this.btnCargarDatosRetencion.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnCargarDatosRetencion.Image"));
            this.btnCargarDatosRetencion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCargarDatosRetencion.ImageSize = new System.Drawing.Size(32, 32);
            this.btnCargarDatosRetencion.Location = new System.Drawing.Point(598, 5);
            this.btnCargarDatosRetencion.Name = "btnCargarDatosRetencion";
            this.btnCargarDatosRetencion.Size = new System.Drawing.Size(126, 36);
            this.btnCargarDatosRetencion.TabIndex = 5;
            this.btnCargarDatosRetencion.Text = "&Cargar Datos";
            this.btnCargarDatosRetencion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnCargarDatosRetencion, "Cargar información de Fecha y N° de Retención");
            this.btnCargarDatosRetencion.Click += new System.EventHandler(this.btnCargarDatosRetencion_Click);
            // 
            // btnParaImgNCE
            // 
            this.btnParaImgNCE.CustomStyle = "F";
            this.btnParaImgNCE.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnParaImgNCE.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnParaImgNCE.ForeColor = System.Drawing.Color.White;
            this.btnParaImgNCE.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnParaImgNCE.Image"));
            this.btnParaImgNCE.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnParaImgNCE.ImageSize = new System.Drawing.Size(32, 32);
            this.btnParaImgNCE.Location = new System.Drawing.Point(488, 5);
            this.btnParaImgNCE.Name = "btnParaImgNCE";
            this.btnParaImgNCE.Size = new System.Drawing.Size(26, 36);
            this.btnParaImgNCE.TabIndex = 5;
            this.btnParaImgNCE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnParaImgNCE.Visible = false;
            // 
            // btnParaImgFE
            // 
            this.btnParaImgFE.CustomStyle = "F";
            this.btnParaImgFE.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnParaImgFE.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnParaImgFE.ForeColor = System.Drawing.Color.White;
            this.btnParaImgFE.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnParaImgFE.Image"));
            this.btnParaImgFE.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnParaImgFE.ImageSize = new System.Drawing.Size(32, 32);
            this.btnParaImgFE.Location = new System.Drawing.Point(514, 5);
            this.btnParaImgFE.Name = "btnParaImgFE";
            this.btnParaImgFE.Size = new System.Drawing.Size(24, 36);
            this.btnParaImgFE.TabIndex = 5;
            this.btnParaImgFE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnParaImgFE.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.btnActualizarDatosRetTimb);
            this.panel2.Controls.Add(this.txtNroTimbrado);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtPorcRetRenta);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtPorcRetIVA10);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtCliente);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(931, 98);
            this.panel2.TabIndex = 0;
            // 
            // btnActualizarDatosRetTimb
            // 
            this.btnActualizarDatosRetTimb.CustomStyle = "F";
            this.btnActualizarDatosRetTimb.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnActualizarDatosRetTimb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnActualizarDatosRetTimb.ForeColor = System.Drawing.Color.White;
            this.btnActualizarDatosRetTimb.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnActualizarDatosRetTimb.Image"));
            this.btnActualizarDatosRetTimb.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizarDatosRetTimb.ImageSize = new System.Drawing.Size(32, 32);
            this.btnActualizarDatosRetTimb.Location = new System.Drawing.Point(654, 34);
            this.btnActualizarDatosRetTimb.Name = "btnActualizarDatosRetTimb";
            this.btnActualizarDatosRetTimb.Size = new System.Drawing.Size(94, 36);
            this.btnActualizarDatosRetTimb.TabIndex = 4;
            this.btnActualizarDatosRetTimb.Text = "&Actualizar";
            this.btnActualizarDatosRetTimb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnActualizarDatosRetTimb, "Actualizar información de porcentaje de retenciones y timbrado");
            this.btnActualizarDatosRetTimb.Click += new System.EventHandler(this.btnActualizarDatosRetTimb_Click);
            // 
            // txtNroTimbrado
            // 
            this.txtNroTimbrado.Location = new System.Drawing.Point(520, 61);
            this.txtNroTimbrado.Name = "txtNroTimbrado";
            this.txtNroTimbrado.Size = new System.Drawing.Size(118, 20);
            this.txtNroTimbrado.TabIndex = 3;
            this.txtNroTimbrado.Text = "--";
            this.txtNroTimbrado.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.txtNroTimbrado.Enter += new System.EventHandler(this.txtNroTimbrado_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(429, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Nº Timbrado";
            // 
            // txtPorcRetRenta
            // 
            this.txtPorcRetRenta.Location = new System.Drawing.Point(375, 61);
            this.txtPorcRetRenta.Name = "txtPorcRetRenta";
            this.txtPorcRetRenta.Size = new System.Drawing.Size(40, 20);
            this.txtPorcRetRenta.TabIndex = 2;
            this.txtPorcRetRenta.Text = "0";
            this.txtPorcRetRenta.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.txtPorcRetRenta.Enter += new System.EventHandler(this.txtPorcRetRenta_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(297, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "% Ret. Renta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "% Ret. IVA 10%";
            // 
            // txtPorcRetIVA10
            // 
            this.txtPorcRetIVA10.Location = new System.Drawing.Point(245, 61);
            this.txtPorcRetIVA10.Name = "txtPorcRetIVA10";
            this.txtPorcRetIVA10.Size = new System.Drawing.Size(40, 20);
            this.txtPorcRetIVA10.TabIndex = 1;
            this.txtPorcRetIVA10.Text = "0";
            this.txtPorcRetIVA10.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.txtPorcRetIVA10.Enter += new System.EventHandler(this.txtPorcRetIVA10_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cliente";
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.SystemColors.Control;
            this.txtCliente.Location = new System.Drawing.Point(245, 22);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(393, 20);
            this.txtCliente.TabIndex = 0;
            this.txtCliente.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvRetenciones);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 98);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(931, 357);
            this.panel1.TabIndex = 2;
            // 
            // dgvRetenciones
            // 
            this.dgvRetenciones.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvRetenciones.Location = new System.Drawing.Point(0, 0);
            this.dgvRetenciones.Name = "dgvRetenciones";
            this.dgvRetenciones.Size = new System.Drawing.Size(931, 357);
            this.dgvRetenciones.TabIndex = 0;
            this.dgvRetenciones.CellContentClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgvRetenciones_CellContentClick);
            // 
            // lblTotalImpCob
            // 
            this.lblTotalImpCob.AutoSize = true;
            this.lblTotalImpCob.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalImpCob.Location = new System.Drawing.Point(9, 5);
            this.lblTotalImpCob.Name = "lblTotalImpCob";
            this.lblTotalImpCob.Size = new System.Drawing.Size(54, 13);
            this.lblTotalImpCob.TabIndex = 0;
            this.lblTotalImpCob.Text = "Total Ret. IVA 10%";
            this.lblTotalImpCob.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTotalRetIVA10
            // 
            this.txtTotalRetIVA10.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotalRetIVA10.Location = new System.Drawing.Point(12, 21);
            this.txtTotalRetIVA10.Name = "txtTotalRetIVA10";
            this.txtTotalRetIVA10.ReadOnly = true;
            this.txtTotalRetIVA10.Size = new System.Drawing.Size(145, 20);
            this.txtTotalRetIVA10.TabIndex = 2;
            this.txtTotalRetIVA10.TabStop = false;
            this.txtTotalRetIVA10.Text = "0,00";
            this.txtTotalRetIVA10.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalRetRenta
            // 
            this.txtTotalRetRenta.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotalRetRenta.Location = new System.Drawing.Point(163, 21);
            this.txtTotalRetRenta.Name = "txtTotalRetRenta";
            this.txtTotalRetRenta.ReadOnly = true;
            this.txtTotalRetRenta.Size = new System.Drawing.Size(145, 20);
            this.txtTotalRetRenta.TabIndex = 2;
            this.txtTotalRetRenta.TabStop = false;
            this.txtTotalRetRenta.Text = "0,00";
            this.txtTotalRetRenta.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(160, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Total Ret. Renta";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTotalRetenciones
            // 
            this.txtTotalRetenciones.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotalRetenciones.Location = new System.Drawing.Point(314, 21);
            this.txtTotalRetenciones.Name = "txtTotalRetenciones";
            this.txtTotalRetenciones.ReadOnly = true;
            this.txtTotalRetenciones.Size = new System.Drawing.Size(145, 20);
            this.txtTotalRetenciones.TabIndex = 2;
            this.txtTotalRetenciones.TabStop = false;
            this.txtTotalRetenciones.Text = "0,00";
            this.txtTotalRetenciones.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(311, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Total Retenciones";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FCargarRetencionesRecibo
            // 
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Size = new System.Drawing.Size(931, 502);
            this.Text = "FReservarNroPresup";
            this.Load += new System.EventHandler(this.FCargarRetencionesRecibo_Load);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRetenciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnAceptar;
        private Button btnCancelar;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private DataGridView dgvRetenciones;
        private Button btnParaImgNCE;
        private Button btnParaImgFE;
        private ToolTip toolTip1;
        private Button btnCargarDatosRetencion;
        private Button btnActualizarDatosRetTimb;
        private TextBox txtNroTimbrado;
        private Label label4;
        private TextBox txtPorcRetRenta;
        private Label label3;
        private Label label2;
        private TextBox txtPorcRetIVA10;
        private Label label1;
        private TextBox txtCliente;
        private Label label6;
        private TextBox txtTotalRetenciones;
        private Label label5;
        private TextBox txtTotalRetRenta;
        private TextBox txtTotalRetIVA10;
        private Label lblTotalImpCob;


    }
}