using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.UI
{
    partial class FCargarDepositoRecaudacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCargarDepositoRecaudacion));
            this.btnAceptar = new Gizmox.WebGUI.Forms.Button();
            this.btnCancelar = new Gizmox.WebGUI.Forms.Button();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.btnCargarDatosDepositos = new Gizmox.WebGUI.Forms.Button();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.chkFiltroFecha = new Gizmox.WebGUI.Forms.CheckBox();
            this.pnlFiltroFecha = new Gizmox.WebGUI.Forms.Panel();
            this.label18 = new Gizmox.WebGUI.Forms.Label();
            this.dtpFechaHasta = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpFechaDesde = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label21 = new Gizmox.WebGUI.Forms.Label();
            this.btnFiltrar = new Gizmox.WebGUI.Forms.Button();
            this.tSBCliente = new SPF.UserControls.Base.ucTextSearchBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.dgvRecaudaciones = new Gizmox.WebGUI.Forms.DataGridView();
            this.toolTip1 = new Gizmox.WebGUI.Forms.ToolTip();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlFiltroFecha.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecaudaciones)).BeginInit();
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
            this.panel3.Controls.Add(this.btnCargarDatosDepositos);
            this.panel3.Controls.Add(this.btnAceptar);
            this.panel3.Controls.Add(this.btnCancelar);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 473);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1057, 49);
            this.panel3.TabIndex = 1;
            // 
            // btnCargarDatosDepositos
            // 
            this.btnCargarDatosDepositos.CustomStyle = "F";
            this.btnCargarDatosDepositos.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnCargarDatosDepositos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCargarDatosDepositos.ForeColor = System.Drawing.Color.White;
            this.btnCargarDatosDepositos.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnCargarDatosDepositos.Image"));
            this.btnCargarDatosDepositos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCargarDatosDepositos.ImageSize = new System.Drawing.Size(32, 32);
            this.btnCargarDatosDepositos.Location = new System.Drawing.Point(598, 5);
            this.btnCargarDatosDepositos.Name = "btnCargarDatosDepositos";
            this.btnCargarDatosDepositos.Size = new System.Drawing.Size(126, 36);
            this.btnCargarDatosDepositos.TabIndex = 5;
            this.btnCargarDatosDepositos.Text = "&Cargar Datos";
            this.btnCargarDatosDepositos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnCargarDatosDepositos, "Cargar información de Fecha y N° de Retención");
            this.btnCargarDatosDepositos.Visible = false;
            this.btnCargarDatosDepositos.Click += new System.EventHandler(this.btnCargarDatosRetencion_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.chkFiltroFecha);
            this.panel2.Controls.Add(this.pnlFiltroFecha);
            this.panel2.Controls.Add(this.btnFiltrar);
            this.panel2.Controls.Add(this.tSBCliente);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1057, 73);
            this.panel2.TabIndex = 0;
            // 
            // chkFiltroFecha
            // 
            this.chkFiltroFecha.AutoSize = true;
            this.chkFiltroFecha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkFiltroFecha.Location = new System.Drawing.Point(42, 51);
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
            this.pnlFiltroFecha.Location = new System.Drawing.Point(423, 5);
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
            this.btnFiltrar.Location = new System.Drawing.Point(660, 13);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(85, 36);
            this.btnFiltrar.TabIndex = 5;
            this.btnFiltrar.Text = "&Filtrar";
            this.btnFiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // tSBCliente
            // 
            this.tSBCliente.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBCliente.BackColor = System.Drawing.SystemColors.Control;
            this.tSBCliente.DBContext = null;
            this.tSBCliente.DisplayMember = "";
            this.tSBCliente.KeyMember = "";
            this.tSBCliente.LabelCampoBusqueda = "";
            this.tSBCliente.Location = new System.Drawing.Point(42, 23);
            this.tSBCliente.Name = "tSBCliente";
            this.tSBCliente.NombreCampoDescrip = "";
            this.tSBCliente.NombreCampoID = "";
            this.tSBCliente.Size = new System.Drawing.Size(375, 20);
            this.tSBCliente.SoloLectura = false;
            this.tSBCliente.TabIndex = 0;
            this.tSBCliente.Text = "ucTextSearchBox";
            this.tSBCliente.TituloBuscador = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(42, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(59, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Filtrar por fechas";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvRecaudaciones);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1057, 400);
            this.panel1.TabIndex = 2;
            // 
            // dgvRecaudaciones
            // 
            this.dgvRecaudaciones.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvRecaudaciones.Location = new System.Drawing.Point(0, 0);
            this.dgvRecaudaciones.Name = "dgvRecaudaciones";
            this.dgvRecaudaciones.Size = new System.Drawing.Size(1057, 400);
            this.dgvRecaudaciones.TabIndex = 0;
            this.dgvRecaudaciones.CellContentClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgvRetenciones_CellContentClick);
            this.dgvRecaudaciones.CellFormatting += new Gizmox.WebGUI.Forms.DataGridViewCellFormattingEventHandler(this.dgvRecaudaciones_CellFormatting);
            this.dgvRecaudaciones.DataBindingComplete += new Gizmox.WebGUI.Forms.DataGridViewBindingCompleteEventHandler(this.dgvRecaudaciones_DataBindingComplete);
            this.dgvRecaudaciones.KeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.dgvRecaudaciones_KeyDown);
            // 
            // FCargarDepositoRecaudacion
            // 
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Size = new System.Drawing.Size(1057, 522);
            this.Text = "FReservarNroPresup";
            this.Load += new System.EventHandler(this.FCargarDepositoRecaudacion_Load);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnlFiltroFecha.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecaudaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnAceptar;
        private Button btnCancelar;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private DataGridView dgvRecaudaciones;
        private ToolTip toolTip1;
        private Button btnCargarDatosDepositos;
        private UserControls.Base.ucTextSearchBox tSBCliente;
        private Label label1;
        private Label label2;
        private Button btnFiltrar;
        private Panel pnlFiltroFecha;
        private Label label18;
        private DateTimePicker dtpFechaHasta;
        private DateTimePicker dtpFechaDesde;
        private Label label21;
        private CheckBox chkFiltroFecha;


    }
}