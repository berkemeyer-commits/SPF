using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.UI
{
    partial class FCopiarCotizaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCopiarCotizaciones));
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel4 = new Gizmox.WebGUI.Forms.Panel();
            this.btnQuitar = new Gizmox.WebGUI.Forms.Button();
            this.btnAgregar = new Gizmox.WebGUI.Forms.Button();
            this.lblExpedientesHI = new Gizmox.WebGUI.Forms.Label();
            this.lblExpedientesACopiar = new Gizmox.WebGUI.Forms.Label();
            this.listBox2 = new Gizmox.WebGUI.Forms.ListBox();
            this.listBox1 = new Gizmox.WebGUI.Forms.ListBox();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.btnCerrar = new Gizmox.WebGUI.Forms.Button();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.btnCopiarHI = new Gizmox.WebGUI.Forms.Button();
            this.btnAgregarTodos = new Gizmox.WebGUI.Forms.Button();
            this.toolTip1 = new Gizmox.WebGUI.Forms.ToolTip();
            this.btnQuitarTodos = new Gizmox.WebGUI.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(1062, 454);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnQuitarTodos);
            this.panel4.Controls.Add(this.btnAgregarTodos);
            this.panel4.Controls.Add(this.btnQuitar);
            this.panel4.Controls.Add(this.btnAgregar);
            this.panel4.Controls.Add(this.lblExpedientesHI);
            this.panel4.Controls.Add(this.lblExpedientesACopiar);
            this.panel4.Controls.Add(this.listBox2);
            this.panel4.Controls.Add(this.listBox1);
            this.panel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 44);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1062, 370);
            this.panel4.TabIndex = 2;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnQuitar.Location = new System.Drawing.Point(509, 198);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(45, 35);
            this.btnQuitar.TabIndex = 2;
            this.btnQuitar.Text = "<";
            this.toolTip1.SetToolTip(this.btnQuitar, "Quitar Seleccionado");
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAgregar.Location = new System.Drawing.Point(509, 149);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(45, 36);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = ">";
            this.toolTip1.SetToolTip(this.btnAgregar, "Agregar Seleccionado");
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblExpedientesHI
            // 
            this.lblExpedientesHI.AutoSize = true;
            this.lblExpedientesHI.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblExpedientesHI.Location = new System.Drawing.Point(16, 14);
            this.lblExpedientesHI.Name = "lblExpedientesHI";
            this.lblExpedientesHI.Size = new System.Drawing.Size(35, 13);
            this.lblExpedientesHI.TabIndex = 1;
            this.lblExpedientesHI.Text = "Expedientes de la HI";
            // 
            // lblExpedientesACopiar
            // 
            this.lblExpedientesACopiar.AutoSize = true;
            this.lblExpedientesACopiar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblExpedientesACopiar.Location = new System.Drawing.Point(564, 14);
            this.lblExpedientesACopiar.Name = "lblExpedientesACopiar";
            this.lblExpedientesACopiar.Size = new System.Drawing.Size(35, 13);
            this.lblExpedientesACopiar.TabIndex = 1;
            this.lblExpedientesACopiar.Text = "Expedientes donde se copiarán cotizaciones";
            // 
            // listBox2
            // 
            this.listBox2.Location = new System.Drawing.Point(564, 40);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(480, 316);
            this.listBox2.TabIndex = 0;
            this.listBox2.DoubleClick += new System.EventHandler(this.listBox2_DoubleClick);
            // 
            // listBox1
            // 
            this.listBox1.Location = new System.Drawing.Point(19, 40);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(480, 316);
            this.listBox1.TabIndex = 0;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Controls.Add(this.btnCopiarHI);
            this.panel3.Controls.Add(this.btnCerrar);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 414);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1062, 40);
            this.panel3.TabIndex = 1;
            // 
            // btnCerrar
            // 
            this.btnCerrar.CustomStyle = "F";
            this.btnCerrar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnCerrar.Image"));
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.ImageSize = new System.Drawing.Size(32, 32);
            this.btnCerrar.Location = new System.Drawing.Point(968, 2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(85, 36);
            this.btnCerrar.TabIndex = 20;
            this.btnCerrar.Text = "&Cerrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1062, 44);
            this.panel2.TabIndex = 0;
            // 
            // btnCopiarHI
            // 
            this.btnCopiarHI.CustomStyle = "F";
            this.btnCopiarHI.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnCopiarHI.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCopiarHI.ForeColor = System.Drawing.Color.White;
            this.btnCopiarHI.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnCopiarHI.Image"));
            this.btnCopiarHI.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCopiarHI.ImageSize = new System.Drawing.Size(32, 32);
            this.btnCopiarHI.Location = new System.Drawing.Point(878, 2);
            this.btnCopiarHI.Name = "btnCopiarHI";
            this.btnCopiarHI.Size = new System.Drawing.Size(90, 36);
            this.btnCopiarHI.TabIndex = 21;
            this.btnCopiarHI.Text = "&Copiar";
            this.btnCopiarHI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopiarHI.Click += new System.EventHandler(this.btnCopiarHI_Click);
            // 
            // btnAgregarTodos
            // 
            this.btnAgregarTodos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAgregarTodos.Location = new System.Drawing.Point(509, 99);
            this.btnAgregarTodos.Name = "btnAgregarTodos";
            this.btnAgregarTodos.Size = new System.Drawing.Size(45, 36);
            this.btnAgregarTodos.TabIndex = 2;
            this.btnAgregarTodos.Text = ">>";
            this.toolTip1.SetToolTip(this.btnAgregarTodos, "Agregar Todos");
            this.btnAgregarTodos.Click += new System.EventHandler(this.btnAgregarTodos_Click);
            // 
            // btnQuitarTodos
            // 
            this.btnQuitarTodos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnQuitarTodos.Location = new System.Drawing.Point(509, 247);
            this.btnQuitarTodos.Name = "btnQuitarTodos";
            this.btnQuitarTodos.Size = new System.Drawing.Size(45, 35);
            this.btnQuitarTodos.TabIndex = 2;
            this.btnQuitarTodos.Text = "<<";
            this.toolTip1.SetToolTip(this.btnQuitarTodos, "Quitar Todos");
            this.btnQuitarTodos.Click += new System.EventHandler(this.btnQuitarTodos_Click);
            // 
            // FCopiarCotizaciones
            // 
            this.Controls.Add(this.panel1);
            this.Size = new System.Drawing.Size(1062, 454);
            this.Text = "FTramiteAsociados";
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel4;
        private Button btnQuitar;
        private Button btnAgregar;
        private Label lblExpedientesHI;
        private Label lblExpedientesACopiar;
        private ListBox listBox2;
        private ListBox listBox1;
        private Panel panel3;
        private Panel panel2;
        private Button btnCerrar;
        private Button btnCopiarHI;
        private Button btnQuitarTodos;
        private ToolTip toolTip1;
        private Button btnAgregarTodos;


    }
}