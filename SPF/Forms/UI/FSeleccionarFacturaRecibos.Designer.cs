using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.UI
{
    partial class FSeleccionarFacturaRecibos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FSeleccionarFacturaRecibos));
            this.panel5 = new Gizmox.WebGUI.Forms.Panel();
            this.lblTotalRecibo = new Gizmox.WebGUI.Forms.Label();
            this.txtTotalRecibo = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTotalNCred = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTotalImpNotaCred = new Gizmox.WebGUI.Forms.Label();
            this.lblTotalImpCob = new Gizmox.WebGUI.Forms.Label();
            this.txtTotalImpCob = new Gizmox.WebGUI.Forms.TextBox();
            this.btnParaImgFE = new Gizmox.WebGUI.Forms.Button();
            this.btnParaImgNCE = new Gizmox.WebGUI.Forms.Button();
            this.lblFilasRecuperadas = new Gizmox.WebGUI.Forms.Label();
            this.btnCancelar = new Gizmox.WebGUI.Forms.Button();
            this.btnCobrar = new Gizmox.WebGUI.Forms.Button();
            this.panel6 = new Gizmox.WebGUI.Forms.Panel();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.chkFiltroFecha = new Gizmox.WebGUI.Forms.CheckBox();
            this.pnlFiltroFecha = new Gizmox.WebGUI.Forms.Panel();
            this.label18 = new Gizmox.WebGUI.Forms.Label();
            this.dtpFechaHasta = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpFechaDesde = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label21 = new Gizmox.WebGUI.Forms.Label();
            this.btnFiltrar = new Gizmox.WebGUI.Forms.Button();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.textBox5 = new Gizmox.WebGUI.Forms.TextBox();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.cbMoneda = new Gizmox.WebGUI.Forms.ComboBox();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.tSBCliente = new SPF.UserControls.Base.ucTextSearchBox();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.dgvFacturasRecibos = new Gizmox.WebGUI.Forms.DataGridView();
            this.toolTip1 = new Gizmox.WebGUI.Forms.ToolTip();
            this.lblSeleccionadas = new Gizmox.WebGUI.Forms.Label();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.pnlFiltroFecha.SuspendLayout();
            this.label1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasRecibos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel5.Controls.Add(this.lblSeleccionadas);
            this.panel5.Controls.Add(this.lblTotalRecibo);
            this.panel5.Controls.Add(this.txtTotalRecibo);
            this.panel5.Controls.Add(this.txtTotalNCred);
            this.panel5.Controls.Add(this.lblTotalImpNotaCred);
            this.panel5.Controls.Add(this.lblTotalImpCob);
            this.panel5.Controls.Add(this.txtTotalImpCob);
            this.panel5.Controls.Add(this.btnParaImgFE);
            this.panel5.Controls.Add(this.btnParaImgNCE);
            this.panel5.Controls.Add(this.lblFilasRecuperadas);
            this.panel5.Controls.Add(this.btnCancelar);
            this.panel5.Controls.Add(this.btnCobrar);
            this.panel5.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 464);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1057, 64);
            this.panel5.TabIndex = 0;
            // 
            // lblTotalRecibo
            // 
            this.lblTotalRecibo.AutoSize = true;
            this.lblTotalRecibo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalRecibo.Location = new System.Drawing.Point(570, 13);
            this.lblTotalRecibo.Name = "lblTotalRecibo";
            this.lblTotalRecibo.Size = new System.Drawing.Size(54, 13);
            this.lblTotalRecibo.TabIndex = 0;
            this.lblTotalRecibo.Text = "Total Recibo";
            this.lblTotalRecibo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTotalRecibo
            // 
            this.txtTotalRecibo.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotalRecibo.Location = new System.Drawing.Point(570, 29);
            this.txtTotalRecibo.Name = "txtTotalRecibo";
            this.txtTotalRecibo.ReadOnly = true;
            this.txtTotalRecibo.Size = new System.Drawing.Size(145, 20);
            this.txtTotalRecibo.TabIndex = 2;
            this.txtTotalRecibo.TabStop = false;
            this.txtTotalRecibo.Text = "0,00";
            this.txtTotalRecibo.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalNCred
            // 
            this.txtTotalNCred.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotalNCred.Location = new System.Drawing.Point(410, 29);
            this.txtTotalNCred.Name = "txtTotalNCred";
            this.txtTotalNCred.ReadOnly = true;
            this.txtTotalNCred.Size = new System.Drawing.Size(145, 20);
            this.txtTotalNCred.TabIndex = 2;
            this.txtTotalNCred.TabStop = false;
            this.txtTotalNCred.Text = "0,00";
            this.txtTotalNCred.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalImpNotaCred
            // 
            this.lblTotalImpNotaCred.AutoSize = true;
            this.lblTotalImpNotaCred.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalImpNotaCred.Location = new System.Drawing.Point(410, 13);
            this.lblTotalImpNotaCred.Name = "lblTotalImpNotaCred";
            this.lblTotalImpNotaCred.Size = new System.Drawing.Size(54, 13);
            this.lblTotalImpNotaCred.TabIndex = 0;
            this.lblTotalImpNotaCred.Text = "Total Notas Crédito";
            this.lblTotalImpNotaCred.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalImpCob
            // 
            this.lblTotalImpCob.AutoSize = true;
            this.lblTotalImpCob.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalImpCob.Location = new System.Drawing.Point(246, 13);
            this.lblTotalImpCob.Name = "lblTotalImpCob";
            this.lblTotalImpCob.Size = new System.Drawing.Size(54, 13);
            this.lblTotalImpCob.TabIndex = 0;
            this.lblTotalImpCob.Text = "Total Importe Cobrado";
            this.lblTotalImpCob.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTotalImpCob
            // 
            this.txtTotalImpCob.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotalImpCob.Location = new System.Drawing.Point(249, 29);
            this.txtTotalImpCob.Name = "txtTotalImpCob";
            this.txtTotalImpCob.ReadOnly = true;
            this.txtTotalImpCob.Size = new System.Drawing.Size(145, 20);
            this.txtTotalImpCob.TabIndex = 2;
            this.txtTotalImpCob.TabStop = false;
            this.txtTotalImpCob.Text = "0,00";
            this.txtTotalImpCob.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
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
            this.btnParaImgFE.Location = new System.Drawing.Point(752, 13);
            this.btnParaImgFE.Name = "btnParaImgFE";
            this.btnParaImgFE.Size = new System.Drawing.Size(24, 36);
            this.btnParaImgFE.TabIndex = 5;
            this.btnParaImgFE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnParaImgFE.Visible = false;
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
            this.btnParaImgNCE.Location = new System.Drawing.Point(726, 13);
            this.btnParaImgNCE.Name = "btnParaImgNCE";
            this.btnParaImgNCE.Size = new System.Drawing.Size(26, 36);
            this.btnParaImgNCE.TabIndex = 5;
            this.btnParaImgNCE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnParaImgNCE.Visible = false;
            // 
            // lblFilasRecuperadas
            // 
            this.lblFilasRecuperadas.AutoSize = true;
            this.lblFilasRecuperadas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFilasRecuperadas.Location = new System.Drawing.Point(21, 4);
            this.lblFilasRecuperadas.Name = "lblFilasRecuperadas";
            this.lblFilasRecuperadas.Size = new System.Drawing.Size(46, 13);
            this.lblFilasRecuperadas.TabIndex = 0;
            this.lblFilasRecuperadas.Text = "lblFilasRecuperadas";
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
            this.btnCancelar.Location = new System.Drawing.Point(897, 13);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(103, 36);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnCobrar
            // 
            this.btnCobrar.CustomStyle = "F";
            this.btnCobrar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnCobrar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCobrar.ForeColor = System.Drawing.Color.White;
            this.btnCobrar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnCobrar.Image"));
            this.btnCobrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCobrar.ImageSize = new System.Drawing.Size(32, 32);
            this.btnCobrar.Location = new System.Drawing.Point(792, 13);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(103, 36);
            this.btnCobrar.TabIndex = 4;
            this.btnCobrar.Text = "&Relizar Cobro";
            this.btnCobrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.chkFiltroFecha);
            this.panel6.Controls.Add(this.pnlFiltroFecha);
            this.panel6.Controls.Add(this.btnFiltrar);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.cbMoneda);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.tSBCliente);
            this.panel6.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1057, 74);
            this.panel6.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(37, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Filtrar por fechas";
            // 
            // chkFiltroFecha
            // 
            this.chkFiltroFecha.AutoSize = true;
            this.chkFiltroFecha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkFiltroFecha.Location = new System.Drawing.Point(21, 49);
            this.chkFiltroFecha.Name = "chkFiltroFecha";
            this.chkFiltroFecha.Size = new System.Drawing.Size(15, 14);
            this.chkFiltroFecha.TabIndex = 7;
            this.chkFiltroFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltroFecha.CheckedChanged += new System.EventHandler(this.chkFiltroFecha_CheckedChanged);
            // 
            // pnlFiltroFecha
            // 
            this.pnlFiltroFecha.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pnlFiltroFecha.Controls.Add(this.label18);
            this.pnlFiltroFecha.Controls.Add(this.dtpFechaHasta);
            this.pnlFiltroFecha.Controls.Add(this.dtpFechaDesde);
            this.pnlFiltroFecha.Controls.Add(this.label21);
            this.pnlFiltroFecha.Location = new System.Drawing.Point(669, 6);
            this.pnlFiltroFecha.Name = "pnlFiltroFecha";
            this.pnlFiltroFecha.Size = new System.Drawing.Size(226, 43);
            this.pnlFiltroFecha.TabIndex = 6;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label18.Location = new System.Drawing.Point(119, 3);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Fecha Hasta";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.BackColor = System.Drawing.Color.White;
            this.dtpFechaHasta.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaHasta.Location = new System.Drawing.Point(121, 18);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(100, 21);
            this.dtpFechaHasta.TabIndex = 3;
            this.dtpFechaHasta.TabStop = false;
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.BackColor = System.Drawing.Color.White;
            this.dtpFechaDesde.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaDesde.Location = new System.Drawing.Point(7, 18);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(100, 21);
            this.dtpFechaDesde.TabIndex = 3;
            this.dtpFechaDesde.TabStop = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label21.Location = new System.Drawing.Point(5, 3);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(78, 13);
            this.label21.TabIndex = 0;
            this.label21.Text = "Fecha Desde";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.CustomStyle = "F";
            this.btnFiltrar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnFiltrar.Image"));
            this.btnFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFiltrar.ImageSize = new System.Drawing.Size(32, 32);
            this.btnFiltrar.Location = new System.Drawing.Point(915, 16);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(85, 36);
            this.btnFiltrar.TabIndex = 5;
            this.btnFiltrar.Text = "&Filtrar";
            this.btnFiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Controls.Add(this.textBox5);
            this.label1.Controls.Add(this.label5);
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(411, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Moneda";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(-279, -1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Cliente";
            // 
            // cbMoneda
            // 
            this.cbMoneda.AllowDrag = false;
            this.cbMoneda.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cbMoneda.FormattingEnabled = true;
            this.cbMoneda.Location = new System.Drawing.Point(411, 24);
            this.cbMoneda.Name = "cbMoneda";
            this.cbMoneda.Size = new System.Drawing.Size(251, 21);
            this.cbMoneda.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(22, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Cliente";
            // 
            // tSBCliente
            // 
            this.tSBCliente.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBCliente.BackColor = System.Drawing.SystemColors.Control;
            this.tSBCliente.DBContext = null;
            this.tSBCliente.DisplayMember = "";
            this.tSBCliente.KeyMember = "";
            this.tSBCliente.LabelCampoBusqueda = "";
            this.tSBCliente.Location = new System.Drawing.Point(21, 24);
            this.tSBCliente.Name = "tSBCliente";
            this.tSBCliente.NombreCampoDescrip = "";
            this.tSBCliente.NombreCampoID = "";
            this.tSBCliente.Size = new System.Drawing.Size(375, 20);
            this.tSBCliente.SoloLectura = false;
            this.tSBCliente.TabIndex = 0;
            this.tSBCliente.Text = "ucTextSearchBox";
            this.tSBCliente.TituloBuscador = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvFacturasRecibos);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1057, 390);
            this.panel1.TabIndex = 1;
            // 
            // dgvFacturasRecibos
            // 
            this.dgvFacturasRecibos.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvFacturasRecibos.Location = new System.Drawing.Point(0, 0);
            this.dgvFacturasRecibos.Name = "dgvFacturasRecibos";
            this.dgvFacturasRecibos.Size = new System.Drawing.Size(1057, 390);
            this.dgvFacturasRecibos.TabIndex = 0;
            this.dgvFacturasRecibos.CellContentClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgvFacturasRecibos_CellContentClick);
            this.dgvFacturasRecibos.CellFormatting += new Gizmox.WebGUI.Forms.DataGridViewCellFormattingEventHandler(this.dgvFacturasRecibos_CellFormatting);
            this.dgvFacturasRecibos.CellValidating += new Gizmox.WebGUI.Forms.DataGridViewCellValidatingEventHandler(this.dgvFacturasRecibos_CellValidating);
            this.dgvFacturasRecibos.CellValueChanged += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgvFacturasRecibos_CellValueChanged);
            this.dgvFacturasRecibos.DataError += new Gizmox.WebGUI.Forms.DataGridViewDataErrorEventHandler(this.dgvFacturasRecibos_DataError);
            // 
            // lblSeleccionadas
            // 
            this.lblSeleccionadas.AutoSize = true;
            this.lblSeleccionadas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblSeleccionadas.Location = new System.Drawing.Point(21, 25);
            this.lblSeleccionadas.Name = "lblSeleccionadas";
            this.lblSeleccionadas.Size = new System.Drawing.Size(46, 13);
            this.lblSeleccionadas.TabIndex = 0;
            this.lblSeleccionadas.Text = "lblSeleccionadas";
            // 
            // FSeleccionarFacturaRecibos
            // 
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel6);
            this.Size = new System.Drawing.Size(1057, 525);
            this.Text = "FSeleccionarProveedor";
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.pnlFiltroFecha.ResumeLayout(false);
            this.label1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasRecibos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel5;
        private Panel panel6;
        private Panel panel1;
        private Button btnCancelar;
        private Button btnCobrar;
        private Label label6;
        private UserControls.Base.ucTextSearchBox tSBCliente;
        private Label label1;
        private TextBox textBox5;
        private Label label5;
        private ComboBox cbMoneda;
        private Button btnFiltrar;
        private CheckBox chkFiltroFecha;
        private Panel pnlFiltroFecha;
        private Label label18;
        private DateTimePicker dtpFechaHasta;
        private DateTimePicker dtpFechaDesde;
        private Label label21;
        private Label label2;
        private Label lblFilasRecuperadas;
        private Button btnParaImgNCE;
        private Button btnParaImgFE;
        private DataGridView dgvFacturasRecibos;
        private DataGridView dgvFR;
        private ToolTip toolTip1;
        private Label lblTotalRecibo;
        private TextBox txtTotalRecibo;
        private TextBox txtTotalNCred;
        private Label lblTotalImpNotaCred;
        private Label lblTotalImpCob;
        private TextBox txtTotalImpCob;
        private Label lblSeleccionadas;


    }
}