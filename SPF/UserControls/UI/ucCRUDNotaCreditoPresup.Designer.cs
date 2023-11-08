using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.UserControls.UI
{
    partial class ucCRUDNotaCreditoPresup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCRUDNotaCreditoPresup));
            this.tbbAnular = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.Sep6 = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.tbPagosAsoc = new Gizmox.WebGUI.Forms.TabPage();
            this.pnlDetNC = new Gizmox.WebGUI.Forms.Panel();
            this.pnlPagosAsocFill = new Gizmox.WebGUI.Forms.Panel();
            this.panel4 = new Gizmox.WebGUI.Forms.Panel();
            this.dgvPagosAsoc = new Gizmox.WebGUI.Forms.DataGridView();
            this.panel5 = new Gizmox.WebGUI.Forms.Panel();
            this.pnlPagosAsocTop = new Gizmox.WebGUI.Forms.Panel();
            this.pnlPagosAsocBottom = new Gizmox.WebGUI.Forms.Panel();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.txtFechaNC = new Gizmox.WebGUI.Forms.TextBox();
            this.dtpFechaNC = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblAutorizacionVigente = new Gizmox.WebGUI.Forms.Label();
            this.textBox4 = new Gizmox.WebGUI.Forms.TextBox();
            this.label18 = new Gizmox.WebGUI.Forms.Label();
            this.textBox5 = new Gizmox.WebGUI.Forms.TextBox();
            this.label19 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.txtNCID = new Gizmox.WebGUI.Forms.TextBox();
            this.txtNCNro = new Gizmox.WebGUI.Forms.TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.txtSaldo = new Gizmox.WebGUI.Forms.TextBox();
            this.label9 = new Gizmox.WebGUI.Forms.Label();
            this.label10 = new Gizmox.WebGUI.Forms.Label();
            this.txtMonto = new Gizmox.WebGUI.Forms.TextBox();
            this.label11 = new Gizmox.WebGUI.Forms.Label();
            this.label12 = new Gizmox.WebGUI.Forms.Label();
            this.label13 = new Gizmox.WebGUI.Forms.Label();
            this.txtPresupAsoc = new Gizmox.WebGUI.Forms.TextBox();
            this.tSBCliente = new SPF.UserControls.Base.ucTextSearchBox();
            this.tSBMoneda = new SPF.UserControls.Base.ucTextSearchBox();
            this.btnBuscar = new Gizmox.WebGUI.Forms.Button();
            this.txtNCReferencia = new Gizmox.WebGUI.Forms.TextBox();
            this.textBox1 = new Gizmox.WebGUI.Forms.TextBox();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.textBox2 = new Gizmox.WebGUI.Forms.TextBox();
            this.label14 = new Gizmox.WebGUI.Forms.Label();
            this.textBox3 = new Gizmox.WebGUI.Forms.TextBox();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.textBox6 = new Gizmox.WebGUI.Forms.TextBox();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.txtNCCuerpo = new Gizmox.WebGUI.Forms.TextBox();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.dgvDetPresup = new Gizmox.WebGUI.Forms.DataGridView();
            this.dataGridView1 = new Gizmox.WebGUI.Forms.DataGridView();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.chkAnulado = new Gizmox.WebGUI.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).BeginInit();
            this.tabListaABM.SuspendLayout();
            this.tbPagosAsoc.SuspendLayout();
            this.pnlDetNC.SuspendLayout();
            this.pnlPagosAsocFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagosAsoc)).BeginInit();
            this.label19.SuspendLayout();
            this.label14.SuspendLayout();
            this.label7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetPresup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListadoABM
            // 
            this.dgvListadoABM.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dgvListadoABM.Size = new System.Drawing.Size(1053, 400);
            this.dgvListadoABM.CellFormatting += new Gizmox.WebGUI.Forms.DataGridViewCellFormattingEventHandler(this.dgvListadoABM_CellFormatting);
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
            // tbbImprimir
            // 
            this.tbbImprimir.Click += new System.EventHandler(this.tbbImprimir_Click_1);
            // 
            // tbbGuardar
            // 
            this.tbbGuardar.Click += new System.EventHandler(this.tbbGuardar_Click);
            // 
            // tbbCancelar
            // 
            this.tbbCancelar.Click += new System.EventHandler(this.tbbCancelar_Click_1);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.chkAnulado);
            this.pnlDetalle.Controls.Add(this.txtNCCuerpo);
            this.pnlDetalle.Controls.Add(this.label7);
            this.pnlDetalle.Controls.Add(this.label14);
            this.pnlDetalle.Controls.Add(this.txtNCReferencia);
            this.pnlDetalle.Controls.Add(this.btnBuscar);
            this.pnlDetalle.Controls.Add(this.tSBMoneda);
            this.pnlDetalle.Controls.Add(this.tSBCliente);
            this.pnlDetalle.Controls.Add(this.txtFechaNC);
            this.pnlDetalle.Controls.Add(this.txtPresupAsoc);
            this.pnlDetalle.Controls.Add(this.label13);
            this.pnlDetalle.Controls.Add(this.label12);
            this.pnlDetalle.Controls.Add(this.label11);
            this.pnlDetalle.Controls.Add(this.txtMonto);
            this.pnlDetalle.Controls.Add(this.label10);
            this.pnlDetalle.Controls.Add(this.label9);
            this.pnlDetalle.Controls.Add(this.txtSaldo);
            this.pnlDetalle.Controls.Add(this.label4);
            this.pnlDetalle.Controls.Add(this.label2);
            this.pnlDetalle.Controls.Add(this.txtNCNro);
            this.pnlDetalle.Controls.Add(this.txtNCID);
            this.pnlDetalle.Controls.Add(this.label1);
            this.pnlDetalle.Controls.Add(this.label19);
            this.pnlDetalle.Controls.Add(this.lblAutorizacionVigente);
            this.pnlDetalle.Controls.Add(this.dtpFechaNC);
            this.pnlDetalle.Controls.Add(this.label3);
            this.pnlDetalle.Controls.Add(this.panel3);
            this.pnlDetalle.Size = new System.Drawing.Size(1110, 430);
            // 
            // tBBaseForm
            // 
            this.tBBaseForm.Buttons.AddRange(new Gizmox.WebGUI.Forms.ToolBarButton[] {
            this.tbbAnular,
            this.Sep6});
            // 
            // tbbNuevo
            // 
            this.tbbNuevo.Click += new System.EventHandler(this.tbbNuevo_Click);
            // 
            // tabListaABM
            // 
            this.tabListaABM.Alignment = Gizmox.WebGUI.Forms.TabAlignment.Top;
            this.tabListaABM.Controls.Add(this.tbPagosAsoc);
            this.tabListaABM.Size = new System.Drawing.Size(1081, 449);
            // 
            // tbbAnular
            // 
            this.tbbAnular.CustomStyle = "";
            this.tbbAnular.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbbAnular.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tbbAnular.Image"));
            this.tbbAnular.Name = "tbbAnular";
            this.tbbAnular.Size = 24;
            this.tbbAnular.Text = "A";
            this.tbbAnular.ToolTipText = "Permite Anular ésta Nota de Crédito";
            this.tbbAnular.Click += new System.EventHandler(this.tbbAnular_Click);
            // 
            // Sep6
            // 
            this.Sep6.CustomStyle = "";
            this.Sep6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Sep6.Name = "Sep6";
            this.Sep6.Size = 24;
            this.Sep6.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.Separator;
            this.Sep6.ToolTipText = "";
            // 
            // panel3
            // 
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 414);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1110, 16);
            this.panel3.TabIndex = 2;
            // 
            // tbPagosAsoc
            // 
            this.tbPagosAsoc.Controls.Add(this.pnlDetNC);
            this.tbPagosAsoc.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tbPagosAsoc.Location = new System.Drawing.Point(0, 0);
            this.tbPagosAsoc.Name = "tbPagosAsoc";
            this.tbPagosAsoc.Size = new System.Drawing.Size(1073, 420);
            this.tbPagosAsoc.TabIndex = 2;
            this.tbPagosAsoc.Text = "Pagos Asociados";
            // 
            // pnlDetNC
            // 
            this.pnlDetNC.Controls.Add(this.pnlPagosAsocFill);
            this.pnlDetNC.Controls.Add(this.pnlPagosAsocTop);
            this.pnlDetNC.Controls.Add(this.pnlPagosAsocBottom);
            this.pnlDetNC.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlDetNC.Location = new System.Drawing.Point(0, 0);
            this.pnlDetNC.Name = "pnlDetNC";
            this.pnlDetNC.Size = new System.Drawing.Size(1110, 430);
            this.pnlDetNC.TabIndex = 3;
            // 
            // pnlPagosAsocFill
            // 
            this.pnlPagosAsocFill.Controls.Add(this.panel4);
            this.pnlPagosAsocFill.Controls.Add(this.dgvPagosAsoc);
            this.pnlPagosAsocFill.Controls.Add(this.panel5);
            this.pnlPagosAsocFill.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlPagosAsocFill.Location = new System.Drawing.Point(0, 24);
            this.pnlPagosAsocFill.Name = "pnlPagosAsocFill";
            this.pnlPagosAsocFill.Size = new System.Drawing.Size(1110, 280);
            this.pnlPagosAsocFill.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(979, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(131, 280);
            this.panel4.TabIndex = 1;
            // 
            // dgvPagosAsoc
            // 
            this.dgvPagosAsoc.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvPagosAsoc.Location = new System.Drawing.Point(35, 0);
            this.dgvPagosAsoc.Name = "dgvPagosAsoc";
            this.dgvPagosAsoc.Size = new System.Drawing.Size(1075, 280);
            this.dgvPagosAsoc.TabIndex = 3;
            this.dgvPagosAsoc.Text = "hola mundo";
            // 
            // panel5
            // 
            this.panel5.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(35, 280);
            this.panel5.TabIndex = 0;
            // 
            // pnlPagosAsocTop
            // 
            this.pnlPagosAsocTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.pnlPagosAsocTop.Location = new System.Drawing.Point(0, 0);
            this.pnlPagosAsocTop.Name = "pnlPagosAsocTop";
            this.pnlPagosAsocTop.Size = new System.Drawing.Size(1110, 24);
            this.pnlPagosAsocTop.TabIndex = 1;
            // 
            // pnlPagosAsocBottom
            // 
            this.pnlPagosAsocBottom.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.pnlPagosAsocBottom.Location = new System.Drawing.Point(0, 304);
            this.pnlPagosAsocBottom.Name = "pnlPagosAsocBottom";
            this.pnlPagosAsocBottom.Size = new System.Drawing.Size(1110, 126);
            this.pnlPagosAsocBottom.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Asociados";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtFechaNC
            // 
            this.txtFechaNC.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaNC.Location = new System.Drawing.Point(174, 59);
            this.txtFechaNC.Name = "txtFechaNC";
            this.txtFechaNC.Size = new System.Drawing.Size(81, 18);
            this.txtFechaNC.TabIndex = 0;
            // 
            // dtpFechaNC
            // 
            this.dtpFechaNC.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaNC.Location = new System.Drawing.Point(173, 58);
            this.dtpFechaNC.Name = "dtpFechaNC";
            this.dtpFechaNC.Size = new System.Drawing.Size(100, 21);
            this.dtpFechaNC.TabIndex = 3;
            this.dtpFechaNC.TabStop = false;
            // 
            // lblAutorizacionVigente
            // 
            this.lblAutorizacionVigente.AutoSize = true;
            this.lblAutorizacionVigente.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblAutorizacionVigente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblAutorizacionVigente.Location = new System.Drawing.Point(604, 26);
            this.lblAutorizacionVigente.Name = "lblAutorizacionVigente";
            this.lblAutorizacionVigente.Size = new System.Drawing.Size(41, 13);
            this.lblAutorizacionVigente.TabIndex = 15;
            this.lblAutorizacionVigente.Text = "Autorización para modificación vigente";
            this.lblAutorizacionVigente.Visible = false;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.Location = new System.Drawing.Point(154, 56);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(279, 20);
            this.textBox4.TabIndex = 1;
            this.textBox4.TabStop = false;
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
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Control;
            this.textBox5.Location = new System.Drawing.Point(-129, -4);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(50, 20);
            this.textBox5.TabIndex = 1;
            this.textBox5.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Controls.Add(this.textBox4);
            this.label19.Controls.Add(this.label18);
            this.label19.Controls.Add(this.textBox5);
            this.label19.Location = new System.Drawing.Point(84, 136);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "Moneda";
            this.label19.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "NC ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtNCID
            // 
            this.txtNCID.BackColor = System.Drawing.SystemColors.Control;
            this.txtNCID.Location = new System.Drawing.Point(173, 23);
            this.txtNCID.Name = "txtNCID";
            this.txtNCID.ReadOnly = true;
            this.txtNCID.Size = new System.Drawing.Size(100, 20);
            this.txtNCID.TabIndex = 1;
            this.txtNCID.TabStop = false;
            this.txtNCID.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // txtNCNro
            // 
            this.txtNCNro.BackColor = System.Drawing.SystemColors.Control;
            this.txtNCNro.Location = new System.Drawing.Point(330, 23);
            this.txtNCNro.Name = "txtNCNro";
            this.txtNCNro.ReadOnly = true;
            this.txtNCNro.Size = new System.Drawing.Size(100, 20);
            this.txtNCNro.TabIndex = 1;
            this.txtNCNro.TabStop = false;
            this.txtNCNro.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "NC N°";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Cliente";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtSaldo
            // 
            this.txtSaldo.BackColor = System.Drawing.SystemColors.Control;
            this.txtSaldo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtSaldo.ForeColor = System.Drawing.Color.Red;
            this.txtSaldo.Location = new System.Drawing.Point(488, 59);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(100, 20);
            this.txtSaldo.TabIndex = 1;
            this.txtSaldo.TabStop = false;
            this.txtSaldo.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.txtSaldo.TextChanged += new System.EventHandler(this.txtSaldo_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(443, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Saldo";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(290, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Total";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtMonto
            // 
            this.txtMonto.BackColor = System.Drawing.SystemColors.Window;
            this.txtMonto.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtMonto.ForeColor = System.Drawing.Color.Black;
            this.txtMonto.Location = new System.Drawing.Point(330, 59);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(100, 20);
            this.txtMonto.TabIndex = 1;
            this.txtMonto.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.txtMonto.Leave += new System.EventHandler(this.txtMonto_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(83, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Fecha";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(83, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Generación";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(84, 166);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Presupuestos";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtPresupAsoc
            // 
            this.txtPresupAsoc.BackColor = System.Drawing.SystemColors.Control;
            this.txtPresupAsoc.Location = new System.Drawing.Point(174, 166);
            this.txtPresupAsoc.Name = "txtPresupAsoc";
            this.txtPresupAsoc.ReadOnly = true;
            this.txtPresupAsoc.Size = new System.Drawing.Size(533, 20);
            this.txtPresupAsoc.TabIndex = 1;
            this.txtPresupAsoc.TabStop = false;
            // 
            // tSBCliente
            // 
            this.tSBCliente.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBCliente.BackColor = System.Drawing.SystemColors.Control;
            this.tSBCliente.DBContext = null;
            this.tSBCliente.DisplayMember = "";
            this.tSBCliente.KeyMember = "";
            this.tSBCliente.LabelCampoBusqueda = "";
            this.tSBCliente.Location = new System.Drawing.Point(174, 96);
            this.tSBCliente.Name = "tSBCliente";
            this.tSBCliente.NombreCampoDescrip = "";
            this.tSBCliente.NombreCampoID = "";
            this.tSBCliente.Size = new System.Drawing.Size(570, 20);
            this.tSBCliente.TabIndex = 2;
            this.tSBCliente.Text = "ucTextSearchBox";
            this.tSBCliente.TituloBuscador = "";
            this.tSBCliente.Leave += new System.EventHandler(this.tSBCliente_Leave);
            // 
            // tSBMoneda
            // 
            this.tSBMoneda.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBMoneda.BackColor = System.Drawing.SystemColors.Control;
            this.tSBMoneda.DBContext = null;
            this.tSBMoneda.DisplayMember = "";
            this.tSBMoneda.KeyMember = "";
            this.tSBMoneda.LabelCampoBusqueda = "";
            this.tSBMoneda.Location = new System.Drawing.Point(174, 132);
            this.tSBMoneda.Name = "tSBMoneda";
            this.tSBMoneda.NombreCampoDescrip = "";
            this.tSBMoneda.NombreCampoID = "";
            this.tSBMoneda.Size = new System.Drawing.Size(570, 20);
            this.tSBMoneda.TabIndex = 3;
            this.tSBMoneda.Text = "ucTextSearchBox";
            this.tSBMoneda.TituloBuscador = "";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(710, 166);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(34, 20);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "...";
            this.tTBaseForm.SetToolTip(this.btnBuscar, "Seleccionar Presupuestos");
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtNCReferencia
            // 
            this.txtNCReferencia.BackColor = System.Drawing.SystemColors.Window;
            this.txtNCReferencia.Location = new System.Drawing.Point(174, 205);
            this.txtNCReferencia.Multiline = true;
            this.txtNCReferencia.Name = "txtNCReferencia";
            this.txtNCReferencia.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.txtNCReferencia.Size = new System.Drawing.Size(570, 53);
            this.txtNCReferencia.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Location = new System.Drawing.Point(154, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(279, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-170, -1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Area";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.Location = new System.Drawing.Point(-129, -4);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(50, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Controls.Add(this.textBox1);
            this.label14.Controls.Add(this.label5);
            this.label14.Controls.Add(this.textBox2);
            this.label14.Location = new System.Drawing.Point(84, 208);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Referencia";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.Location = new System.Drawing.Point(154, 56);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(279, 20);
            this.textBox3.TabIndex = 1;
            this.textBox3.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-170, -1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Area";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.Control;
            this.textBox6.Location = new System.Drawing.Point(-129, -4);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(50, 20);
            this.textBox6.TabIndex = 1;
            this.textBox6.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Controls.Add(this.textBox3);
            this.label7.Controls.Add(this.label6);
            this.label7.Controls.Add(this.textBox6);
            this.label7.Location = new System.Drawing.Point(84, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Cuerpo";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtNCCuerpo
            // 
            this.txtNCCuerpo.BackColor = System.Drawing.SystemColors.Window;
            this.txtNCCuerpo.Location = new System.Drawing.Point(174, 275);
            this.txtNCCuerpo.Multiline = true;
            this.txtNCCuerpo.Name = "txtNCCuerpo";
            this.txtNCCuerpo.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.txtNCCuerpo.Size = new System.Drawing.Size(570, 79);
            this.txtNCCuerpo.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(35, 430);
            this.panel2.TabIndex = 0;
            // 
            // dgvDetPresup
            // 
            this.dgvDetPresup.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvDetPresup.Location = new System.Drawing.Point(35, 0);
            this.dgvDetPresup.Name = "dgvDetPresup";
            this.dgvDetPresup.Size = new System.Drawing.Size(838, 430);
            this.dgvDetPresup.TabIndex = 3;
            this.dgvDetPresup.Text = "hola mundo";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(158, 14);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(838, 430);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.Text = "hola mundo";
            // 
            // panel1
            // 
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(35, 430);
            this.panel1.TabIndex = 0;
            // 
            // chkAnulado
            // 
            this.chkAnulado.AutoSize = true;
            this.chkAnulado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAnulado.Enabled = false;
            this.chkAnulado.Location = new System.Drawing.Point(437, 25);
            this.chkAnulado.Name = "chkAnulado";
            this.chkAnulado.Size = new System.Drawing.Size(65, 17);
            this.chkAnulado.TabIndex = 16;
            this.chkAnulado.TabStop = false;
            this.chkAnulado.Text = "Anulado";
            // 
            // ucCRUDNotaCreditoPresup
            // 
            this.Text = "ucCRUDNotaCreditoPresup";
            this.VisibleChanged += new System.EventHandler(this.ucCRUDNotaCreditoPresup_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).EndInit();
            this.tabListaABM.ResumeLayout(false);
            this.tbPagosAsoc.ResumeLayout(false);
            this.pnlDetNC.ResumeLayout(false);
            this.pnlPagosAsocFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagosAsoc)).EndInit();
            this.label19.ResumeLayout(false);
            this.label14.ResumeLayout(false);
            this.label7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetPresup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ToolBarButton tbbAnular;
        private ToolBarButton Sep6;
        private Panel panel3;
        private TabPage tbPagosAsoc;
        private Panel pnlDetNC;
        private TextBox txtPresupAsoc;
        private Label label13;
        private Label label12;
        private Label label11;
        private TextBox txtMonto;
        private Label label10;
        private Label label9;
        private TextBox txtSaldo;
        private Label label4;
        private Label label2;
        private TextBox txtNCNro;
        private TextBox txtNCID;
        private Label label1;
        private Label label19;
        private TextBox textBox4;
        private Label label18;
        private TextBox textBox5;
        private Label lblAutorizacionVigente;
        private DateTimePicker dtpFechaNC;
        private TextBox txtFechaNC;
        private Label label3;
        private Base.ucTextSearchBox tSBMoneda;
        private Base.ucTextSearchBox tSBCliente;
        private Button btnBuscar;
        private Label label14;
        private TextBox textBox1;
        private Label label5;
        private TextBox textBox2;
        private TextBox txtNCReferencia;
        private TextBox txtNCCuerpo;
        private Label label7;
        private TextBox textBox3;
        private Label label6;
        private TextBox textBox6;
        private Panel pnlPagosAsocFill;
        private Panel panel4;
        private DataGridView dgvPagosAsoc;
        private Panel panel5;
        private Panel pnlPagosAsocTop;
        private Panel pnlPagosAsocBottom;
        private Panel panel2;
        private DataGridView dgvDetPresup;
        private DataGridView dataGridView1;
        private Panel panel1;
        private CheckBox chkAnulado;


    }
}