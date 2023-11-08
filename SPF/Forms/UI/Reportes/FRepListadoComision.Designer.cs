using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.UI.Reportes
{
    partial class FRepListadoComision
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRepListadoComision));
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel4 = new Gizmox.WebGUI.Forms.Panel();
            this.lblAdvertencia = new Gizmox.WebGUI.Forms.Label();
            this.grpFiltroFecha = new Gizmox.WebGUI.Forms.GroupBox();
            this.rbTodo = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbRango = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbAl = new Gizmox.WebGUI.Forms.RadioButton();
            this.txtFechaAl = new Gizmox.WebGUI.Forms.TextBox();
            this.dtpFechaAl = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.txtFechaHasta = new Gizmox.WebGUI.Forms.TextBox();
            this.txtFechaDesde = new Gizmox.WebGUI.Forms.TextBox();
            this.dtpFechaHasta = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label18 = new Gizmox.WebGUI.Forms.Label();
            this.dtpFechaDesde = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.tSBCliente = new SPF.UserControls.Base.ucTextSearchBox();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.btnAceptar = new Gizmox.WebGUI.Forms.Button();
            this.btnCancelar = new Gizmox.WebGUI.Forms.Button();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.tSBAbogado = new SPF.UserControls.Base.ucTextSearchBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.grpFiltroFecha.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(525, 354);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.tSBAbogado);
            this.panel4.Controls.Add(this.lblAdvertencia);
            this.panel4.Controls.Add(this.grpFiltroFecha);
            this.panel4.Controls.Add(this.tSBCliente);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 46);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(525, 261);
            this.panel4.TabIndex = 2;
            // 
            // lblAdvertencia
            // 
            this.lblAdvertencia.AutoSize = true;
            this.lblAdvertencia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblAdvertencia.ForeColor = System.Drawing.Color.Red;
            this.lblAdvertencia.Location = new System.Drawing.Point(34, 226);
            this.lblAdvertencia.Name = "lblAdvertencia";
            this.lblAdvertencia.Size = new System.Drawing.Size(35, 13);
            this.lblAdvertencia.TabIndex = 9;
            // 
            // grpFiltroFecha
            // 
            this.grpFiltroFecha.Controls.Add(this.rbTodo);
            this.grpFiltroFecha.Controls.Add(this.rbRango);
            this.grpFiltroFecha.Controls.Add(this.rbAl);
            this.grpFiltroFecha.Controls.Add(this.txtFechaAl);
            this.grpFiltroFecha.Controls.Add(this.dtpFechaAl);
            this.grpFiltroFecha.Controls.Add(this.txtFechaHasta);
            this.grpFiltroFecha.Controls.Add(this.txtFechaDesde);
            this.grpFiltroFecha.Controls.Add(this.dtpFechaHasta);
            this.grpFiltroFecha.Controls.Add(this.label18);
            this.grpFiltroFecha.Controls.Add(this.dtpFechaDesde);
            this.grpFiltroFecha.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpFiltroFecha.ForeColor = System.Drawing.Color.Black;
            this.grpFiltroFecha.Location = new System.Drawing.Point(34, 88);
            this.grpFiltroFecha.Name = "grpFiltroFecha";
            this.grpFiltroFecha.Size = new System.Drawing.Size(458, 131);
            this.grpFiltroFecha.TabIndex = 2;
            this.grpFiltroFecha.TabStop = false;
            this.grpFiltroFecha.Text = "Filtro por Fechas";
            // 
            // rbTodo
            // 
            this.rbTodo.AutoSize = true;
            this.rbTodo.Location = new System.Drawing.Point(18, 102);
            this.rbTodo.Name = "rbTodo";
            this.rbTodo.Size = new System.Drawing.Size(81, 17);
            this.rbTodo.TabIndex = 5;
            this.rbTodo.Text = "Incluir Todo";
            this.rbTodo.CheckedChanged += new System.EventHandler(this.rbTodo_CheckedChanged);
            // 
            // rbRango
            // 
            this.rbRango.AutoSize = true;
            this.rbRango.Location = new System.Drawing.Point(18, 66);
            this.rbRango.Name = "rbRango";
            this.rbRango.Size = new System.Drawing.Size(55, 17);
            this.rbRango.TabIndex = 5;
            this.rbRango.Text = "Desde";
            this.rbRango.CheckedChanged += new System.EventHandler(this.rbRango_CheckedChanged);
            // 
            // rbAl
            // 
            this.rbAl.AutoSize = true;
            this.rbAl.Location = new System.Drawing.Point(18, 28);
            this.rbAl.Name = "rbAl";
            this.rbAl.Size = new System.Drawing.Size(34, 17);
            this.rbAl.TabIndex = 4;
            this.rbAl.Text = "Al";
            this.rbAl.CheckedChanged += new System.EventHandler(this.rbAl_CheckedChanged);
            // 
            // txtFechaAl
            // 
            this.txtFechaAl.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaAl.Location = new System.Drawing.Point(113, 25);
            this.txtFechaAl.Name = "txtFechaAl";
            this.txtFechaAl.Size = new System.Drawing.Size(81, 18);
            this.txtFechaAl.TabIndex = 3;
            // 
            // dtpFechaAl
            // 
            this.dtpFechaAl.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaAl.Location = new System.Drawing.Point(112, 24);
            this.dtpFechaAl.Name = "dtpFechaAl";
            this.dtpFechaAl.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaAl.TabIndex = 3;
            this.dtpFechaAl.TabStop = false;
            this.dtpFechaAl.ValueChanged += new System.EventHandler(this.dtpFechaAl_ValueChanged);
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaHasta.Location = new System.Drawing.Point(294, 65);
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.Size = new System.Drawing.Size(81, 18);
            this.txtFechaHasta.TabIndex = 3;
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaDesde.Location = new System.Drawing.Point(113, 65);
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.Size = new System.Drawing.Size(81, 18);
            this.txtFechaDesde.TabIndex = 3;
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaHasta.Location = new System.Drawing.Point(293, 64);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaHasta.TabIndex = 3;
            this.dtpFechaHasta.TabStop = false;
            this.dtpFechaHasta.ValueChanged += new System.EventHandler(this.dtpFechaHasta_ValueChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(224, 68);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(43, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Hasta";
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaDesde.Location = new System.Drawing.Point(112, 64);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaDesde.TabIndex = 3;
            this.dtpFechaDesde.TabStop = false;
            this.dtpFechaDesde.ValueChanged += new System.EventHandler(this.dtpFechaDesde_ValueChanged);
            // 
            // tSBCliente
            // 
            this.tSBCliente.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBCliente.BackColor = System.Drawing.SystemColors.Control;
            this.tSBCliente.DBContext = null;
            this.tSBCliente.DisplayMember = "";
            this.tSBCliente.KeyMember = "";
            this.tSBCliente.LabelCampoBusqueda = "";
            this.tSBCliente.Location = new System.Drawing.Point(117, 24);
            this.tSBCliente.Name = "tSBCliente";
            this.tSBCliente.NombreCampoDescrip = "";
            this.tSBCliente.NombreCampoID = "";
            this.tSBCliente.Size = new System.Drawing.Size(375, 20);
            this.tSBCliente.TabIndex = 0;
            this.tSBCliente.Text = "ucTextSearchBox";
            this.tSBCliente.TituloBuscador = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Cliente";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Controls.Add(this.btnAceptar);
            this.panel3.Controls.Add(this.btnCancelar);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 307);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(525, 47);
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
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(525, 46);
            this.panel2.TabIndex = 0;
            // 
            // tSBAbogado
            // 
            this.tSBAbogado.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBAbogado.BackColor = System.Drawing.SystemColors.Control;
            this.tSBAbogado.DBContext = null;
            this.tSBAbogado.DisplayMember = "";
            this.tSBAbogado.KeyMember = "";
            this.tSBAbogado.LabelCampoBusqueda = "";
            this.tSBAbogado.Location = new System.Drawing.Point(117, 52);
            this.tSBAbogado.Name = "tSBAbogado";
            this.tSBAbogado.NombreCampoDescrip = "";
            this.tSBAbogado.NombreCampoID = "";
            this.tSBAbogado.Size = new System.Drawing.Size(375, 20);
            this.tSBAbogado.TabIndex = 1;
            this.tSBAbogado.Text = "ucTextSearchBox";
            this.tSBAbogado.TituloBuscador = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Abogado";
            // 
            // FRepListadoComision
            // 
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(525, 354);
            this.Text = "Reporte de Estado de Cuenta";
            this.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(this.FRepListadoGeneralDeudas_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.grpFiltroFecha.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Label label6;
        private UserControls.Base.ucTextSearchBox tSBCliente;
        private Button btnAceptar;
        private Button btnCancelar;
        private GroupBox grpFiltroFecha;
        private RadioButton rbRango;
        private RadioButton rbAl;
        private TextBox txtFechaAl;
        private DateTimePicker dtpFechaAl;
        private TextBox txtFechaHasta;
        private TextBox txtFechaDesde;
        private DateTimePicker dtpFechaHasta;
        private Label label18;
        private DateTimePicker dtpFechaDesde;
        private RadioButton rbTodo;
        private Label lblAdvertencia;
        private Label label1;
        private UserControls.Base.ucTextSearchBox tSBAbogado;


    }
}