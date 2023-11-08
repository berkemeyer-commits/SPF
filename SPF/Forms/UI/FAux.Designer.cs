using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.UI
{
    partial class FAux
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FAux));
            this.cbTipoFactura = new Gizmox.WebGUI.Forms.ComboBox();
            this.label27 = new Gizmox.WebGUI.Forms.Label();
            this.label28 = new Gizmox.WebGUI.Forms.Label();
            this.tSBProveedor = new SPF.UserControls.Base.ucTextSearchBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.btnLeer = new Gizmox.WebGUI.Forms.Button();
            this.textBox17 = new Gizmox.WebGUI.Forms.TextBox();
            this.label30 = new Gizmox.WebGUI.Forms.Label();
            this.textBox18 = new Gizmox.WebGUI.Forms.TextBox();
            this.label31 = new Gizmox.WebGUI.Forms.Label();
            this.txtDocPath = new Gizmox.WebGUI.Forms.TextBox();
            this.button1 = new Gizmox.WebGUI.Forms.Button();
            this.groupBox2 = new Gizmox.WebGUI.Forms.GroupBox();
            this.panel5 = new Gizmox.WebGUI.Forms.Panel();
            this.panel8 = new Gizmox.WebGUI.Forms.Panel();
            this.textBox14 = new Gizmox.WebGUI.Forms.TextBox();
            this.label10 = new Gizmox.WebGUI.Forms.Label();
            this.textBox15 = new Gizmox.WebGUI.Forms.TextBox();
            this.label11 = new Gizmox.WebGUI.Forms.Label();
            this.txtFacturaTotal = new Gizmox.WebGUI.Forms.TextBox();
            this.textBox11 = new Gizmox.WebGUI.Forms.TextBox();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.textBox12 = new Gizmox.WebGUI.Forms.TextBox();
            this.label9 = new Gizmox.WebGUI.Forms.Label();
            this.txtFacturaTipo = new Gizmox.WebGUI.Forms.TextBox();
            this.textBox8 = new Gizmox.WebGUI.Forms.TextBox();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.textBox9 = new Gizmox.WebGUI.Forms.TextBox();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.txtFacturaFecha = new Gizmox.WebGUI.Forms.TextBox();
            this.textBox5 = new Gizmox.WebGUI.Forms.TextBox();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.textBox6 = new Gizmox.WebGUI.Forms.TextBox();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.txtFacturaProveedor = new Gizmox.WebGUI.Forms.TextBox();
            this.txtFacturaNro = new Gizmox.WebGUI.Forms.TextBox();
            this.textBox1 = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.textBox2 = new Gizmox.WebGUI.Forms.TextBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.btnAceptar = new Gizmox.WebGUI.Forms.Button();
            this.btnCerrar = new Gizmox.WebGUI.Forms.Button();
            this.panel7 = new Gizmox.WebGUI.Forms.Panel();
            this.label31.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.label11.SuspendLayout();
            this.label9.SuspendLayout();
            this.label7.SuspendLayout();
            this.label5.SuspendLayout();
            this.label3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbTipoFactura
            // 
            this.cbTipoFactura.AllowDrag = false;
            this.cbTipoFactura.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoFactura.FormattingEnabled = true;
            this.cbTipoFactura.Location = new System.Drawing.Point(76, 44);
            this.cbTipoFactura.Name = "cbTipoFactura";
            this.cbTipoFactura.Size = new System.Drawing.Size(180, 21);
            this.cbTipoFactura.TabIndex = 1;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(13, 41);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(35, 13);
            this.label27.TabIndex = 0;
            this.label27.Text = "Tipo";
            this.label27.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(13, 54);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(35, 13);
            this.label28.TabIndex = 0;
            this.label28.Text = "Factura";
            this.label28.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tSBProveedor
            // 
            this.tSBProveedor.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBProveedor.BackColor = System.Drawing.Color.Transparent;
            this.tSBProveedor.DBContext = null;
            this.tSBProveedor.DisplayMember = "";
            this.tSBProveedor.KeyMember = "";
            this.tSBProveedor.LabelCampoBusqueda = "";
            this.tSBProveedor.Location = new System.Drawing.Point(76, 17);
            this.tSBProveedor.Name = "tSBProveedor";
            this.tSBProveedor.NombreCampoDescrip = "";
            this.tSBProveedor.NombreCampoID = "";
            this.tSBProveedor.Size = new System.Drawing.Size(410, 20);
            this.tSBProveedor.SoloLectura = false;
            this.tSBProveedor.TabIndex = 0;
            this.tSBProveedor.Text = "ucTextSearchBox";
            this.tSBProveedor.TituloBuscador = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Proveedor";
            // 
            // btnLeer
            // 
            this.btnLeer.AutoSize = true;
            this.btnLeer.Location = new System.Drawing.Point(728, 40);
            this.btnLeer.Name = "btnLeer";
            this.btnLeer.Size = new System.Drawing.Size(80, 25);
            this.btnLeer.TabIndex = 0;
            this.btnLeer.Text = "Leer Archivo";
            this.btnLeer.Click += new System.EventHandler(this.btnLeer_Click);
            // 
            // textBox17
            // 
            this.textBox17.BackColor = System.Drawing.SystemColors.Control;
            this.textBox17.Location = new System.Drawing.Point(154, 56);
            this.textBox17.Name = "textBox17";
            this.textBox17.ReadOnly = true;
            this.textBox17.Size = new System.Drawing.Size(279, 20);
            this.textBox17.TabIndex = 1;
            this.textBox17.TabStop = false;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(-170, -1);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(35, 13);
            this.label30.TabIndex = 0;
            this.label30.Text = "Area";
            this.label30.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox18
            // 
            this.textBox18.BackColor = System.Drawing.SystemColors.Control;
            this.textBox18.Location = new System.Drawing.Point(-129, -4);
            this.textBox18.Name = "textBox18";
            this.textBox18.ReadOnly = true;
            this.textBox18.Size = new System.Drawing.Size(50, 20);
            this.textBox18.TabIndex = 1;
            this.textBox18.TabStop = false;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Controls.Add(this.textBox17);
            this.label31.Controls.Add(this.label30);
            this.label31.Controls.Add(this.textBox18);
            this.label31.Location = new System.Drawing.Point(508, 21);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(35, 13);
            this.label31.TabIndex = 0;
            this.label31.Text = "Documento";
            this.label31.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtDocPath
            // 
            this.txtDocPath.BackColor = System.Drawing.SystemColors.Control;
            this.txtDocPath.ClientId = "txtDocPathClientID";
            this.txtDocPath.Location = new System.Drawing.Point(577, 17);
            this.txtDocPath.Name = "txtDocPath";
            this.txtDocPath.ReadOnly = true;
            this.txtDocPath.Size = new System.Drawing.Size(231, 20);
            this.txtDocPath.TabIndex = 1;
            this.txtDocPath.TabStop = false;
            this.txtDocPath.TextChanged += new System.EventHandler(this.txtDocPath_TextChanged);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(642, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "Subir Archivo";
            this.button1.Click += new System.EventHandler(this.btnSubir_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbTipoFactura);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.tSBProveedor);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnLeer);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.txtDocPath);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(55, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(829, 73);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Subir Documento";
            // 
            // panel5
            // 
            this.panel5.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.CornflowerBlue);
            this.panel5.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.panel5.Controls.Add(this.groupBox2);
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Location = new System.Drawing.Point(100, 290);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(932, 147);
            this.panel5.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel8.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(932, 54);
            this.panel8.TabIndex = 0;
            // 
            // textBox14
            // 
            this.textBox14.BackColor = System.Drawing.SystemColors.Control;
            this.textBox14.Location = new System.Drawing.Point(154, 56);
            this.textBox14.Name = "textBox14";
            this.textBox14.ReadOnly = true;
            this.textBox14.Size = new System.Drawing.Size(279, 20);
            this.textBox14.TabIndex = 1;
            this.textBox14.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(-170, -1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Area";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox15
            // 
            this.textBox15.BackColor = System.Drawing.SystemColors.Control;
            this.textBox15.Location = new System.Drawing.Point(-129, -4);
            this.textBox15.Name = "textBox15";
            this.textBox15.ReadOnly = true;
            this.textBox15.Size = new System.Drawing.Size(50, 20);
            this.textBox15.TabIndex = 1;
            this.textBox15.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Controls.Add(this.textBox14);
            this.label11.Controls.Add(this.label10);
            this.label11.Controls.Add(this.textBox15);
            this.label11.Location = new System.Drawing.Point(366, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Total";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtFacturaTotal
            // 
            this.txtFacturaTotal.BackColor = System.Drawing.SystemColors.Control;
            this.txtFacturaTotal.ClientId = "txtDocPathClientID";
            this.txtFacturaTotal.Location = new System.Drawing.Point(415, 68);
            this.txtFacturaTotal.Name = "txtFacturaTotal";
            this.txtFacturaTotal.ReadOnly = true;
            this.txtFacturaTotal.Size = new System.Drawing.Size(231, 20);
            this.txtFacturaTotal.TabIndex = 1;
            this.txtFacturaTotal.TabStop = false;
            // 
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.SystemColors.Control;
            this.textBox11.Location = new System.Drawing.Point(154, 56);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(279, 20);
            this.textBox11.TabIndex = 1;
            this.textBox11.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(-170, -1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Area";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox12
            // 
            this.textBox12.BackColor = System.Drawing.SystemColors.Control;
            this.textBox12.Location = new System.Drawing.Point(-129, -4);
            this.textBox12.Name = "textBox12";
            this.textBox12.ReadOnly = true;
            this.textBox12.Size = new System.Drawing.Size(50, 20);
            this.textBox12.TabIndex = 1;
            this.textBox12.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Controls.Add(this.textBox11);
            this.label9.Controls.Add(this.label8);
            this.label9.Controls.Add(this.textBox12);
            this.label9.Location = new System.Drawing.Point(40, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Tipo";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtFacturaTipo
            // 
            this.txtFacturaTipo.BackColor = System.Drawing.SystemColors.Control;
            this.txtFacturaTipo.ClientId = "txtDocPathClientID";
            this.txtFacturaTipo.Location = new System.Drawing.Point(109, 72);
            this.txtFacturaTipo.Name = "txtFacturaTipo";
            this.txtFacturaTipo.ReadOnly = true;
            this.txtFacturaTipo.Size = new System.Drawing.Size(231, 20);
            this.txtFacturaTipo.TabIndex = 1;
            this.txtFacturaTipo.TabStop = false;
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.SystemColors.Control;
            this.textBox8.Location = new System.Drawing.Point(154, 56);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(279, 20);
            this.textBox8.TabIndex = 1;
            this.textBox8.TabStop = false;
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
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.SystemColors.Control;
            this.textBox9.Location = new System.Drawing.Point(-129, -4);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(50, 20);
            this.textBox9.TabIndex = 1;
            this.textBox9.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Controls.Add(this.textBox8);
            this.label7.Controls.Add(this.label6);
            this.label7.Controls.Add(this.textBox9);
            this.label7.Location = new System.Drawing.Point(366, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Fecha";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtFacturaFecha
            // 
            this.txtFacturaFecha.BackColor = System.Drawing.SystemColors.Control;
            this.txtFacturaFecha.ClientId = "txtDocPathClientID";
            this.txtFacturaFecha.Location = new System.Drawing.Point(415, 42);
            this.txtFacturaFecha.Name = "txtFacturaFecha";
            this.txtFacturaFecha.ReadOnly = true;
            this.txtFacturaFecha.Size = new System.Drawing.Size(231, 20);
            this.txtFacturaFecha.TabIndex = 1;
            this.txtFacturaFecha.TabStop = false;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Control;
            this.textBox5.Location = new System.Drawing.Point(154, 56);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(279, 20);
            this.textBox5.TabIndex = 1;
            this.textBox5.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-170, -1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Area";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Controls.Add(this.textBox5);
            this.label5.Controls.Add(this.label4);
            this.label5.Controls.Add(this.textBox6);
            this.label5.Location = new System.Drawing.Point(40, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Proveedor";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtFacturaProveedor
            // 
            this.txtFacturaProveedor.BackColor = System.Drawing.SystemColors.Control;
            this.txtFacturaProveedor.ClientId = "txtDocPathClientID";
            this.txtFacturaProveedor.Location = new System.Drawing.Point(109, 16);
            this.txtFacturaProveedor.Name = "txtFacturaProveedor";
            this.txtFacturaProveedor.ReadOnly = true;
            this.txtFacturaProveedor.Size = new System.Drawing.Size(537, 20);
            this.txtFacturaProveedor.TabIndex = 1;
            this.txtFacturaProveedor.TabStop = false;
            // 
            // txtFacturaNro
            // 
            this.txtFacturaNro.BackColor = System.Drawing.SystemColors.Control;
            this.txtFacturaNro.ClientId = "txtDocPathClientID";
            this.txtFacturaNro.Location = new System.Drawing.Point(109, 42);
            this.txtFacturaNro.Name = "txtFacturaNro";
            this.txtFacturaNro.ReadOnly = true;
            this.txtFacturaNro.Size = new System.Drawing.Size(231, 20);
            this.txtFacturaNro.TabIndex = 1;
            this.txtFacturaNro.TabStop = false;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-170, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Area";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Controls.Add(this.textBox1);
            this.label3.Controls.Add(this.label1);
            this.label3.Controls.Add(this.textBox2);
            this.label3.Location = new System.Drawing.Point(40, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Número";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtFacturaTotal);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtFacturaTipo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtFacturaFecha);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtFacturaProveedor);
            this.groupBox1.Controls.Add(this.txtFacturaNro);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(55, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(680, 98);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Factura";
            // 
            // btnAceptar
            // 
            this.btnAceptar.CustomStyle = "F";
            this.btnAceptar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnAceptar.Image"));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnAceptar.ImageSize = new System.Drawing.Size(32, 32);
            this.btnAceptar.Location = new System.Drawing.Point(786, 17);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(98, 36);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "&Procesar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
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
            this.btnCerrar.Location = new System.Drawing.Point(786, 62);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(98, 36);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "&Cerrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel7.Controls.Add(this.groupBox1);
            this.panel7.Controls.Add(this.btnAceptar);
            this.panel7.Controls.Add(this.btnCerrar);
            this.panel7.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 596);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1132, 117);
            this.panel7.TabIndex = 0;
            // 
            // FAux
            // 
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel5);
            this.Size = new System.Drawing.Size(1132, 713);
            this.Text = "FAux";
            this.label31.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.label11.ResumeLayout(false);
            this.label9.ResumeLayout(false);
            this.label7.ResumeLayout(false);
            this.label5.ResumeLayout(false);
            this.label3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox cbTipoFactura;
        private Label label27;
        private Label label28;
        private UserControls.Base.ucTextSearchBox tSBProveedor;
        private Label label2;
        private Button btnLeer;
        private TextBox textBox17;
        private Label label30;
        private TextBox textBox18;
        private Label label31;
        private TextBox txtDocPath;
        private Button button1;
        private GroupBox groupBox2;
        private Panel panel5;
        private Panel panel8;
        private TextBox textBox14;
        private Label label10;
        private TextBox textBox15;
        private Label label11;
        private TextBox txtFacturaTotal;
        private TextBox textBox11;
        private Label label8;
        private TextBox textBox12;
        private Label label9;
        private TextBox txtFacturaTipo;
        private TextBox textBox8;
        private Label label6;
        private TextBox textBox9;
        private Label label7;
        private TextBox txtFacturaFecha;
        private TextBox textBox5;
        private Label label4;
        private TextBox textBox6;
        private Label label5;
        private TextBox txtFacturaProveedor;
        private TextBox txtFacturaNro;
        private TextBox textBox1;
        private Label label1;
        private TextBox textBox2;
        private Label label3;
        private GroupBox groupBox1;
        private Button btnAceptar;
        private Button btnCerrar;
        private Panel panel7;


    }
}