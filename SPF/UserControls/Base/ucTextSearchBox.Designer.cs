using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.UserControls.Base
{
    partial class ucTextSearchBox
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
            this.pnlBack = new Gizmox.WebGUI.Forms.Panel();
            this.pnlTextBox = new Gizmox.WebGUI.Forms.Panel();
            this.pnlTextBox2 = new Gizmox.WebGUI.Forms.Panel();
            this.txtDescripcion = new Gizmox.WebGUI.Forms.TextBox();
            this.pnlTextBox1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel4 = new Gizmox.WebGUI.Forms.Panel();
            this.txtID = new Gizmox.WebGUI.Forms.TextBox();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.pnlBoton = new Gizmox.WebGUI.Forms.Panel();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.btnBuscar = new Gizmox.WebGUI.Forms.Button();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.toolTip1 = new Gizmox.WebGUI.Forms.ToolTip();
            this.pnlBack.SuspendLayout();
            this.pnlTextBox.SuspendLayout();
            this.pnlTextBox2.SuspendLayout();
            this.pnlTextBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlBoton.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBack
            // 
            this.pnlBack.Controls.Add(this.pnlTextBox);
            this.pnlBack.Controls.Add(this.pnlBoton);
            this.pnlBack.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlBack.Location = new System.Drawing.Point(0, 0);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Size = new System.Drawing.Size(435, 20);
            this.pnlBack.TabIndex = 0;
            // 
            // pnlTextBox
            // 
            this.pnlTextBox.Controls.Add(this.pnlTextBox2);
            this.pnlTextBox.Controls.Add(this.pnlTextBox1);
            this.pnlTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlTextBox.Location = new System.Drawing.Point(0, 0);
            this.pnlTextBox.Name = "pnlTextBox";
            this.pnlTextBox.Resizable = new Gizmox.WebGUI.Forms.ResizableOptions(true);
            this.pnlTextBox.Size = new System.Drawing.Size(398, 20);
            this.pnlTextBox.TabIndex = 2;
            // 
            // pnlTextBox2
            // 
            this.pnlTextBox2.BackColor = System.Drawing.Color.Transparent;
            this.pnlTextBox2.Controls.Add(this.txtDescripcion);
            this.pnlTextBox2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlTextBox2.Location = new System.Drawing.Point(98, 0);
            this.pnlTextBox2.Name = "pnlTextBox2";
            this.pnlTextBox2.Resizable = new Gizmox.WebGUI.Forms.ResizableOptions(true);
            this.pnlTextBox2.Size = new System.Drawing.Size(300, 20);
            this.pnlTextBox2.TabIndex = 1;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.AllowDrag = false;
            this.txtDescripcion.BackColor = System.Drawing.SystemColors.Control;
            this.txtDescripcion.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.txtDescripcion.Location = new System.Drawing.Point(0, 0);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(300, 20);
            this.txtDescripcion.TabIndex = 1;
            this.txtDescripcion.TabStop = false;
            this.txtDescripcion.Leave += new System.EventHandler(this.txtDescripcion_Leave);
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            // 
            // pnlTextBox1
            // 
            this.pnlTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.pnlTextBox1.Controls.Add(this.panel4);
            this.pnlTextBox1.Controls.Add(this.panel3);
            this.pnlTextBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.pnlTextBox1.Location = new System.Drawing.Point(0, 0);
            this.pnlTextBox1.Name = "pnlTextBox1";
            this.pnlTextBox1.Size = new System.Drawing.Size(98, 31);
            this.pnlTextBox1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtID);
            this.panel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Resizable = new Gizmox.WebGUI.Forms.ResizableOptions(true);
            this.panel4.Size = new System.Drawing.Size(96, 20);
            this.panel4.TabIndex = 1;
            // 
            // txtID
            // 
            this.txtID.AllowDrag = false;
            this.txtID.BackColor = System.Drawing.SystemColors.Control;
            this.txtID.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.txtID.Location = new System.Drawing.Point(0, 0);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(96, 20);
            this.txtID.TabIndex = 0;
            this.txtID.Leave += new System.EventHandler(this.txtID_Leave);
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // panel3
            // 
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(96, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2, 20);
            this.panel3.TabIndex = 0;
            // 
            // pnlBoton
            // 
            this.pnlBoton.BackColor = System.Drawing.Color.Transparent;
            this.pnlBoton.Controls.Add(this.panel2);
            this.pnlBoton.Controls.Add(this.panel1);
            this.pnlBoton.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.pnlBoton.Location = new System.Drawing.Point(398, 0);
            this.pnlBoton.Name = "pnlBoton";
            this.pnlBoton.Size = new System.Drawing.Size(37, 20);
            this.pnlBoton.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnBuscar);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Resizable = new Gizmox.WebGUI.Forms.ResizableOptions(true);
            this.panel2.Size = new System.Drawing.Size(34, 20);
            this.panel2.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.btnBuscar.Location = new System.Drawing.Point(0, 0);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(34, 20);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "...";
            this.toolTip1.SetToolTip(this.btnBuscar, "Seleccionar valor");
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(3, 20);
            this.panel1.TabIndex = 0;
            // 
            // ucTextSearchBox
            // 
            this.Controls.Add(this.pnlBack);
            this.Size = new System.Drawing.Size(435, 20);
            this.Text = "ucTextSearchBox";
            this.Load += new System.EventHandler(this.ucTextSearchBox_Load);
            this.pnlBack.ResumeLayout(false);
            this.pnlTextBox.ResumeLayout(false);
            this.pnlTextBox2.ResumeLayout(false);
            this.pnlTextBox1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.pnlBoton.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlBack;
        public Panel pnlBoton;
        protected Panel pnlTextBox;
        private Panel pnlTextBox2;
        private TextBox txtDescripcion;
        private Panel pnlTextBox1;
        private Panel panel2;
        private Button btnBuscar;
        private Panel panel1;
        private Panel panel4;
        private TextBox txtID;
        private Panel panel3;
        private ToolTip toolTip1;
        

    }
}