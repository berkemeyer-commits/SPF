using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.UI.Reportes
{
    partial class FRepFacturasRegExtGanancia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRepFacturasRegExtGanancia));
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel4 = new Gizmox.WebGUI.Forms.Panel();
            this.txtObservacion = new Gizmox.WebGUI.Forms.TextBox();
            this.grpTipoReporte = new Gizmox.WebGUI.Forms.GroupBox();
            this.rbConPago = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbSinPago = new Gizmox.WebGUI.Forms.RadioButton();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.tSBCorresponsal = new SPF.UserControls.Base.ucTextSearchBox();
            this.txtFechaHasta = new Gizmox.WebGUI.Forms.TextBox();
            this.txtFechaDesde = new Gizmox.WebGUI.Forms.TextBox();
            this.dtpFechaDesde = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label21 = new Gizmox.WebGUI.Forms.Label();
            this.label18 = new Gizmox.WebGUI.Forms.Label();
            this.dtpFechaHasta = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.btnAceptar = new Gizmox.WebGUI.Forms.Button();
            this.btnCancelar = new Gizmox.WebGUI.Forms.Button();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.tSBMoneda = new SPF.UserControls.Base.ucTextSearchBox();
            this.lblObservacion = new Gizmox.WebGUI.Forms.Label();
            this.rbSinPagosObligados = new Gizmox.WebGUI.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.grpTipoReporte.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(525, 283);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtObservacion);
            this.panel4.Controls.Add(this.grpTipoReporte);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.tSBCorresponsal);
            this.panel4.Controls.Add(this.txtFechaHasta);
            this.panel4.Controls.Add(this.txtFechaDesde);
            this.panel4.Controls.Add(this.dtpFechaDesde);
            this.panel4.Controls.Add(this.label21);
            this.panel4.Controls.Add(this.label18);
            this.panel4.Controls.Add(this.dtpFechaHasta);
            this.panel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 46);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(525, 191);
            this.panel4.TabIndex = 2;
            // 
            // txtObservacion
            // 
            this.txtObservacion.BackColor = System.Drawing.SystemColors.Control;
            this.txtObservacion.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.txtObservacion.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtObservacion.Font = new System.Drawing.Font("Tahoma", 7.25F, System.Drawing.FontStyle.Bold);
            this.txtObservacion.ForeColor = System.Drawing.Color.Red;
            this.txtObservacion.Location = new System.Drawing.Point(34, 154);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(458, 34);
            this.txtObservacion.TabIndex = 3;
            this.txtObservacion.Visible = false;
            // 
            // grpTipoReporte
            // 
            this.grpTipoReporte.Controls.Add(this.rbSinPagosObligados);
            this.grpTipoReporte.Controls.Add(this.rbConPago);
            this.grpTipoReporte.Controls.Add(this.rbSinPago);
            this.grpTipoReporte.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpTipoReporte.ForeColor = System.Drawing.Color.Black;
            this.grpTipoReporte.Location = new System.Drawing.Point(38, 87);
            this.grpTipoReporte.Name = "grpTipoReporte";
            this.grpTipoReporte.Size = new System.Drawing.Size(458, 64);
            this.grpTipoReporte.TabIndex = 4;
            this.grpTipoReporte.TabStop = false;
            this.grpTipoReporte.Text = "Formato Reporte";
            // 
            // rbConPago
            // 
            this.rbConPago.AutoSize = true;
            this.rbConPago.Location = new System.Drawing.Point(363, 27);
            this.rbConPago.Name = "rbConPago";
            this.rbConPago.Size = new System.Drawing.Size(76, 17);
            this.rbConPago.TabIndex = 2;
            this.rbConPago.Text = "Con Pagos";
            this.rbConPago.CheckedChanged += new System.EventHandler(this.rbConPago_CheckedChanged);
            // 
            // rbSinPago
            // 
            this.rbSinPago.AutoSize = true;
            this.rbSinPago.Checked = true;
            this.rbSinPago.Location = new System.Drawing.Point(20, 27);
            this.rbSinPago.Name = "rbSinPago";
            this.rbSinPago.Size = new System.Drawing.Size(71, 17);
            this.rbSinPago.TabIndex = 0;
            this.rbSinPago.Text = "Sin Pagos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(323, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Hasta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Corresponsal";
            // 
            // tSBCorresponsal
            // 
            this.tSBCorresponsal.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBCorresponsal.BackColor = System.Drawing.Color.Transparent;
            this.tSBCorresponsal.DBContext = null;
            this.tSBCorresponsal.DisplayMember = "";
            this.tSBCorresponsal.KeyMember = "";
            this.tSBCorresponsal.LabelCampoBusqueda = "";
            this.tSBCorresponsal.Location = new System.Drawing.Point(113, 22);
            this.tSBCorresponsal.Name = "tSBCorresponsal";
            this.tSBCorresponsal.NombreCampoDescrip = "";
            this.tSBCorresponsal.NombreCampoID = "";
            this.tSBCorresponsal.Size = new System.Drawing.Size(387, 20);
            this.tSBCorresponsal.SoloLectura = false;
            this.tSBCorresponsal.TabIndex = 0;
            this.tSBCorresponsal.Text = "ucTextSearchBox";
            this.tSBCorresponsal.TituloBuscador = "";
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaHasta.Location = new System.Drawing.Point(401, 55);
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.Size = new System.Drawing.Size(81, 18);
            this.txtFechaHasta.TabIndex = 3;
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaDesde.Location = new System.Drawing.Point(114, 55);
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.Size = new System.Drawing.Size(81, 18);
            this.txtFechaDesde.TabIndex = 2;
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaDesde.Location = new System.Drawing.Point(113, 54);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaDesde.TabIndex = 3;
            this.dtpFechaDesde.TabStop = false;
            this.dtpFechaDesde.ValueChanged += new System.EventHandler(this.dtpFechaDesde_ValueChanged);
            this.dtpFechaDesde.Enter += new System.EventHandler(this.dtpFechaDesde_Enter);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(31, 53);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(43, 13);
            this.label21.TabIndex = 0;
            this.label21.Text = "Fecha Pago";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(323, 53);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(43, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Fecha Pago";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaHasta.Location = new System.Drawing.Point(399, 54);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaHasta.TabIndex = 3;
            this.dtpFechaHasta.TabStop = false;
            this.dtpFechaHasta.ValueChanged += new System.EventHandler(this.dtpFechaHasta_ValueChanged);
            this.dtpFechaHasta.Enter += new System.EventHandler(this.dtpFechaHasta_Enter);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Controls.Add(this.btnAceptar);
            this.panel3.Controls.Add(this.btnCancelar);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 237);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(525, 46);
            this.panel3.TabIndex = 1;
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
            this.btnAceptar.Location = new System.Drawing.Point(142, 5);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(85, 36);
            this.btnAceptar.TabIndex = 4;
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
            this.btnCancelar.Location = new System.Drawing.Point(298, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 36);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.tSBMoneda);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(525, 46);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Moneda";
            this.label1.Visible = false;
            // 
            // tSBMoneda
            // 
            this.tSBMoneda.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBMoneda.BackColor = System.Drawing.Color.Transparent;
            this.tSBMoneda.DBContext = null;
            this.tSBMoneda.DisplayMember = "";
            this.tSBMoneda.KeyMember = "";
            this.tSBMoneda.LabelCampoBusqueda = "";
            this.tSBMoneda.Location = new System.Drawing.Point(129, 21);
            this.tSBMoneda.Name = "tSBMoneda";
            this.tSBMoneda.NombreCampoDescrip = "";
            this.tSBMoneda.NombreCampoID = "";
            this.tSBMoneda.Size = new System.Drawing.Size(387, 20);
            this.tSBMoneda.SoloLectura = false;
            this.tSBMoneda.TabIndex = 1;
            this.tSBMoneda.Text = "ucTextSearchBox";
            this.tSBMoneda.TituloBuscador = "";
            this.tSBMoneda.Visible = false;
            // 
            // lblObservacion
            // 
            this.lblObservacion.AutoSize = true;
            this.lblObservacion.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.lblObservacion.ForeColor = System.Drawing.Color.Red;
            this.lblObservacion.Location = new System.Drawing.Point(32, 154);
            this.lblObservacion.Name = "lblObservacion";
            this.lblObservacion.Size = new System.Drawing.Size(43, 26);
            this.lblObservacion.TabIndex = 0;
            this.lblObservacion.Text = "lblObservacion";
            // 
            // rbSinPagosObligados
            // 
            this.rbSinPagosObligados.AutoSize = true;
            this.rbSinPagosObligados.Location = new System.Drawing.Point(148, 27);
            this.rbSinPagosObligados.Name = "rbSinPagosObligados";
            this.rbSinPagosObligados.Size = new System.Drawing.Size(172, 17);
            this.rbSinPagosObligados.TabIndex = 1;
            this.rbSinPagosObligados.Text = "Sin Pagos (Con oblig. de Pago)";
            this.rbSinPagosObligados.CheckedChanged += new System.EventHandler(this.rbSinPagosObligados_CheckedChanged);
            // 
            // FRepFacturasRegExtGanancia
            // 
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Size = new System.Drawing.Size(525, 283);
            this.Text = "Reporte de Estado de Cuenta";
            this.Load += new System.EventHandler(this.FRepPagosPendientes_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.grpTipoReporte.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private TextBox txtFechaHasta;
        private TextBox txtFechaDesde;
        private DateTimePicker dtpFechaDesde;
        private Label label21;
        private Label label18;
        private DateTimePicker dtpFechaHasta;
        private Button btnAceptar;
        private Button btnCancelar;
        private UserControls.Base.ucTextSearchBox tSBMoneda;
        private UserControls.Base.ucTextSearchBox tSBCorresponsal;
        private Label label2;
        private Label label1;
        private GroupBox grpTipoReporte;
        private RadioButton rbSinPago;
        private RadioButton rbConPago;
        private Label label4;
        private Label label3;
        private Label lblObservacion;
        private TextBox txtObservacion;
        private RadioButton rbSinPagosObligados;


    }
}