using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.UI
{
    partial class FSelColExportExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FSelColExportExcel));
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.panel4 = new Gizmox.WebGUI.Forms.Panel();
            this.panel5 = new Gizmox.WebGUI.Forms.Panel();
            this.grpSeleccionarColumnas = new Gizmox.WebGUI.Forms.GroupBox();
            this.btnQuitarTodos = new Gizmox.WebGUI.Forms.Button();
            this.btnAgregarTodos = new Gizmox.WebGUI.Forms.Button();
            this.btnQuitar = new Gizmox.WebGUI.Forms.Button();
            this.btnAgregar = new Gizmox.WebGUI.Forms.Button();
            this.listBox2 = new Gizmox.WebGUI.Forms.ListBox();
            this.listBox1 = new Gizmox.WebGUI.Forms.ListBox();
            this.rbSeleccionarColumnas = new Gizmox.WebGUI.Forms.RadioButton();
            this.btnCancelar = new Gizmox.WebGUI.Forms.Button();
            this.btnAceptar = new Gizmox.WebGUI.Forms.Button();
            this.rbTodas = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbSoloVisibles = new Gizmox.WebGUI.Forms.RadioButton();
            this.toolTip1 = new Gizmox.WebGUI.Forms.ToolTip();
            this.panel5.SuspendLayout();
            this.grpSeleccionarColumnas.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(409, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 412);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 412);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(10, 402);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(399, 10);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(10, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(399, 10);
            this.panel4.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.grpSeleccionarColumnas);
            this.panel5.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(10, 10);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(399, 392);
            this.panel5.TabIndex = 3;
            // 
            // grpSeleccionarColumnas
            // 
            this.grpSeleccionarColumnas.Controls.Add(this.btnQuitarTodos);
            this.grpSeleccionarColumnas.Controls.Add(this.btnAgregarTodos);
            this.grpSeleccionarColumnas.Controls.Add(this.btnQuitar);
            this.grpSeleccionarColumnas.Controls.Add(this.btnAgregar);
            this.grpSeleccionarColumnas.Controls.Add(this.listBox2);
            this.grpSeleccionarColumnas.Controls.Add(this.listBox1);
            this.grpSeleccionarColumnas.Controls.Add(this.rbSeleccionarColumnas);
            this.grpSeleccionarColumnas.Controls.Add(this.btnCancelar);
            this.grpSeleccionarColumnas.Controls.Add(this.btnAceptar);
            this.grpSeleccionarColumnas.Controls.Add(this.rbTodas);
            this.grpSeleccionarColumnas.Controls.Add(this.rbSoloVisibles);
            this.grpSeleccionarColumnas.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.grpSeleccionarColumnas.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpSeleccionarColumnas.Location = new System.Drawing.Point(0, 0);
            this.grpSeleccionarColumnas.Name = "grpSeleccionarColumnas";
            this.grpSeleccionarColumnas.Size = new System.Drawing.Size(399, 392);
            this.grpSeleccionarColumnas.TabIndex = 0;
            this.grpSeleccionarColumnas.TabStop = false;
            // 
            // btnQuitarTodos
            // 
            this.btnQuitarTodos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnQuitarTodos.Location = new System.Drawing.Point(180, 285);
            this.btnQuitarTodos.Name = "btnQuitarTodos";
            this.btnQuitarTodos.Size = new System.Drawing.Size(40, 35);
            this.btnQuitarTodos.TabIndex = 2;
            this.btnQuitarTodos.Text = "<<";
            this.toolTip1.SetToolTip(this.btnQuitarTodos, "Quitar Todos");
            this.btnQuitarTodos.Click += new System.EventHandler(this.btnQuitarTodos_Click);
            // 
            // btnAgregarTodos
            // 
            this.btnAgregarTodos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAgregarTodos.Location = new System.Drawing.Point(180, 137);
            this.btnAgregarTodos.Name = "btnAgregarTodos";
            this.btnAgregarTodos.Size = new System.Drawing.Size(40, 36);
            this.btnAgregarTodos.TabIndex = 2;
            this.btnAgregarTodos.Text = ">>";
            this.toolTip1.SetToolTip(this.btnAgregarTodos, "Agregar Todos");
            this.btnAgregarTodos.Click += new System.EventHandler(this.btnAgregarTodos_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnQuitar.Location = new System.Drawing.Point(180, 236);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(40, 35);
            this.btnQuitar.TabIndex = 2;
            this.btnQuitar.Text = "<";
            this.toolTip1.SetToolTip(this.btnQuitar, "Quitar Seleccionado");
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAgregar.Location = new System.Drawing.Point(180, 187);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(40, 36);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = ">";
            this.toolTip1.SetToolTip(this.btnAgregar, "Agregar Seleccionado");
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // listBox2
            // 
            this.listBox2.Location = new System.Drawing.Point(225, 116);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(158, 225);
            this.listBox2.TabIndex = 5;
            this.listBox2.DoubleClick += new System.EventHandler(this.listBox2_DoubleClick);
            // 
            // listBox1
            // 
            this.listBox1.Location = new System.Drawing.Point(17, 116);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(158, 225);
            this.listBox1.TabIndex = 5;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // rbSeleccionarColumnas
            // 
            this.rbSeleccionarColumnas.AutoSize = true;
            this.rbSeleccionarColumnas.Location = new System.Drawing.Point(96, 77);
            this.rbSeleccionarColumnas.Name = "rbSeleccionarColumnas";
            this.rbSeleccionarColumnas.Size = new System.Drawing.Size(121, 17);
            this.rbSeleccionarColumnas.TabIndex = 0;
            this.rbSeleccionarColumnas.Text = "Selecionar columnas";
            this.rbSeleccionarColumnas.CheckedChanged += new System.EventHandler(this.rbSeleccionarColumnas_CheckedChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.CustomStyle = "F";
            this.btnCancelar.DialogResult = Gizmox.WebGUI.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnCancelar.Image"));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.ImageSize = new System.Drawing.Size(32, 32);
            this.btnCancelar.Location = new System.Drawing.Point(345, 351);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(38, 38);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnCancelar, "Cancelar");
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AutoSize = true;
            this.btnAceptar.CustomStyle = "F";
            this.btnAceptar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnAceptar.Image"));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.ImageSize = new System.Drawing.Size(32, 32);
            this.btnAceptar.Location = new System.Drawing.Point(307, 351);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(38, 38);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnAceptar, "Aceptar");
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // rbTodas
            // 
            this.rbTodas.AutoSize = true;
            this.rbTodas.Location = new System.Drawing.Point(96, 51);
            this.rbTodas.Name = "rbTodas";
            this.rbTodas.Size = new System.Drawing.Size(172, 17);
            this.rbTodas.TabIndex = 0;
            this.rbTodas.Text = "Todas las columnas disponibles";
            // 
            // rbSoloVisibles
            // 
            this.rbSoloVisibles.AutoSize = true;
            this.rbSoloVisibles.Checked = true;
            this.rbSoloVisibles.Location = new System.Drawing.Point(96, 25);
            this.rbSoloVisibles.Name = "rbSoloVisibles";
            this.rbSoloVisibles.Size = new System.Drawing.Size(143, 17);
            this.rbSoloVisibles.TabIndex = 0;
            this.rbSoloVisibles.Text = "Sólo columnas de la grilla";
            // 
            // FSelColExportExcel
            // 
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Size = new System.Drawing.Size(419, 412);
            this.Text = "Seleccionar Columnas";
            this.panel5.ResumeLayout(false);
            this.grpSeleccionarColumnas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private GroupBox grpSeleccionarColumnas;
        private RadioButton rbTodas;
        private RadioButton rbSoloVisibles;
        private Button btnCancelar;
        private ToolTip toolTip1;
        private Button btnAceptar;
        private ListBox listBox2;
        private ListBox listBox1;
        private RadioButton rbSeleccionarColumnas;
        private Button btnQuitarTodos;
        private Button btnAgregarTodos;
        private Button btnQuitar;
        private Button btnAgregar;


    }
}