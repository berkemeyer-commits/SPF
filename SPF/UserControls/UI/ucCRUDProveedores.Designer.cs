using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.UserControls.UI
{
    partial class ucCRUDProveedores
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
            this.txtProveedorID = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.txtNombre = new Gizmox.WebGUI.Forms.TextBox();
            this.txtRUC = new Gizmox.WebGUI.Forms.TextBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.tSBCiudad = new SPF.UserControls.Base.ucTextSearchBox();
            this.tSBPais = new SPF.UserControls.Base.ucTextSearchBox();
            this.cbIdioma = new Gizmox.WebGUI.Forms.ComboBox();
            this.textBox3 = new Gizmox.WebGUI.Forms.TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.textBox4 = new Gizmox.WebGUI.Forms.TextBox();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.textBox5 = new Gizmox.WebGUI.Forms.TextBox();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.txtObservaciones = new Gizmox.WebGUI.Forms.TextBox();
            this.rbJuridica = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbFisica = new Gizmox.WebGUI.Forms.RadioButton();
            this.grpPersoneria = new Gizmox.WebGUI.Forms.GroupBox();
            this.txtDireccion = new Gizmox.WebGUI.Forms.TextBox();
            this.textBox6 = new Gizmox.WebGUI.Forms.TextBox();
            this.label9 = new Gizmox.WebGUI.Forms.Label();
            this.label10 = new Gizmox.WebGUI.Forms.Label();
            this.chkActivo = new Gizmox.WebGUI.Forms.CheckBox();
            this.textBox7 = new Gizmox.WebGUI.Forms.TextBox();
            this.label11 = new Gizmox.WebGUI.Forms.Label();
            this.label12 = new Gizmox.WebGUI.Forms.Label();
            this.label13 = new Gizmox.WebGUI.Forms.Label();
            this.txtTelefono = new Gizmox.WebGUI.Forms.TextBox();
            this.chkPublico = new Gizmox.WebGUI.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).BeginInit();
            this.label4.SuspendLayout();
            this.label8.SuspendLayout();
            this.label6.SuspendLayout();
            this.grpPersoneria.SuspendLayout();
            this.label10.SuspendLayout();
            this.label12.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListadoABM
            // 
            this.dgvListadoABM.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dgvListadoABM.Size = new System.Drawing.Size(1110, 339);
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
            // tbbGuardar
            // 
            this.tbbGuardar.Click += new System.EventHandler(this.tbbGuardar_Click_1);
            // 
            // tbbCancelar
            // 
            this.tbbCancelar.Click += new System.EventHandler(this.tbbCancelar_Click);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.chkPublico);
            this.pnlDetalle.Controls.Add(this.txtTelefono);
            this.pnlDetalle.Controls.Add(this.label13);
            this.pnlDetalle.Controls.Add(this.label12);
            this.pnlDetalle.Controls.Add(this.chkActivo);
            this.pnlDetalle.Controls.Add(this.label10);
            this.pnlDetalle.Controls.Add(this.txtDireccion);
            this.pnlDetalle.Controls.Add(this.grpPersoneria);
            this.pnlDetalle.Controls.Add(this.txtObservaciones);
            this.pnlDetalle.Controls.Add(this.label6);
            this.pnlDetalle.Controls.Add(this.label8);
            this.pnlDetalle.Controls.Add(this.label4);
            this.pnlDetalle.Controls.Add(this.cbIdioma);
            this.pnlDetalle.Controls.Add(this.tSBPais);
            this.pnlDetalle.Controls.Add(this.tSBCiudad);
            this.pnlDetalle.Controls.Add(this.label3);
            this.pnlDetalle.Controls.Add(this.txtRUC);
            this.pnlDetalle.Controls.Add(this.txtNombre);
            this.pnlDetalle.Controls.Add(this.label1);
            this.pnlDetalle.Controls.Add(this.txtProveedorID);
            // 
            // tBBaseForm
            // 
            this.tBBaseForm.Size = new System.Drawing.Size(1138, 42);
            // 
            // tabListaABM
            // 
            this.tabListaABM.Alignment = Gizmox.WebGUI.Forms.TabAlignment.Top;
            this.tabListaABM.Size = new System.Drawing.Size(1138, 388);
            // 
            // txtProveedorID
            // 
            this.txtProveedorID.BackColor = System.Drawing.SystemColors.Control;
            this.txtProveedorID.Location = new System.Drawing.Point(135, 43);
            this.txtProveedorID.Name = "txtProveedorID";
            this.txtProveedorID.ReadOnly = true;
            this.txtProveedorID.Size = new System.Drawing.Size(100, 20);
            this.txtProveedorID.TabIndex = 1;
            this.txtProveedorID.TabStop = false;
            this.txtProveedorID.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Proveedor";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(237, 43);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(367, 20);
            this.txtNombre.TabIndex = 0;
            // 
            // txtRUC
            // 
            this.txtRUC.Location = new System.Drawing.Point(689, 43);
            this.txtRUC.Name = "txtRUC";
            this.txtRUC.Size = new System.Drawing.Size(189, 20);
            this.txtRUC.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(626, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "RUC";
            // 
            // tSBCiudad
            // 
            this.tSBCiudad.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBCiudad.DBContext = null;
            this.tSBCiudad.DisplayMember = "";
            this.tSBCiudad.KeyMember = "";
            this.tSBCiudad.LabelCampoBusqueda = "";
            this.tSBCiudad.Location = new System.Drawing.Point(493, 82);
            this.tSBCiudad.Name = "tSBCiudad";
            this.tSBCiudad.NombreCampoDescrip = "";
            this.tSBCiudad.NombreCampoID = "";
            this.tSBCiudad.Size = new System.Drawing.Size(185, 20);
            this.tSBCiudad.SoloLectura = false;
            this.tSBCiudad.TabIndex = 3;
            this.tSBCiudad.Text = "ucTextSearchBox";
            this.tSBCiudad.TituloBuscador = "";
            // 
            // tSBPais
            // 
            this.tSBPais.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBPais.DBContext = null;
            this.tSBPais.DisplayMember = "";
            this.tSBPais.KeyMember = "";
            this.tSBPais.LabelCampoBusqueda = "";
            this.tSBPais.Location = new System.Drawing.Point(135, 82);
            this.tSBPais.Name = "tSBPais";
            this.tSBPais.NombreCampoDescrip = "";
            this.tSBPais.NombreCampoID = "";
            this.tSBPais.Size = new System.Drawing.Size(293, 20);
            this.tSBPais.SoloLectura = false;
            this.tSBPais.TabIndex = 2;
            this.tSBPais.Text = "ucTextSearchBox";
            this.tSBPais.TituloBuscador = "";
            // 
            // cbIdioma
            // 
            this.cbIdioma.AllowDrag = false;
            this.cbIdioma.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cbIdioma.FormattingEnabled = true;
            this.cbIdioma.Location = new System.Drawing.Point(742, 82);
            this.cbIdioma.Name = "cbIdioma";
            this.cbIdioma.Size = new System.Drawing.Size(136, 21);
            this.cbIdioma.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.AllowDrag = false;
            this.textBox3.Location = new System.Drawing.Point(-184, -4);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(-279, -1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cliente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Controls.Add(this.textBox3);
            this.label4.Controls.Add(this.label2);
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.Location = new System.Drawing.Point(61, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "País";
            // 
            // textBox4
            // 
            this.textBox4.AllowDrag = false;
            this.textBox4.Location = new System.Drawing.Point(-184, -4);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(-279, -1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Cliente";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Controls.Add(this.textBox4);
            this.label8.Controls.Add(this.label7);
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label8.Location = new System.Drawing.Point(440, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Ciudad";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Controls.Add(this.textBox5);
            this.label6.Controls.Add(this.label5);
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label6.Location = new System.Drawing.Point(689, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Idioma";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.AllowDrag = false;
            this.txtObservaciones.Location = new System.Drawing.Point(135, 192);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ReadOnly = true;
            this.txtObservaciones.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(479, 78);
            this.txtObservaciones.TabIndex = 8;
            // 
            // rbJuridica
            // 
            this.rbJuridica.AutoSize = true;
            this.rbJuridica.Location = new System.Drawing.Point(132, 17);
            this.rbJuridica.Name = "rbJuridica";
            this.rbJuridica.Size = new System.Drawing.Size(61, 17);
            this.rbJuridica.TabIndex = 1;
            this.rbJuridica.Text = "Jurídica";
            // 
            // rbFisica
            // 
            this.rbFisica.AutoSize = true;
            this.rbFisica.Location = new System.Drawing.Point(23, 17);
            this.rbFisica.Name = "rbFisica";
            this.rbFisica.Size = new System.Drawing.Size(51, 17);
            this.rbFisica.TabIndex = 0;
            this.rbFisica.Text = "Física";
            this.rbFisica.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageAboveText;
            // 
            // grpPersoneria
            // 
            this.grpPersoneria.Controls.Add(this.rbJuridica);
            this.grpPersoneria.Controls.Add(this.rbFisica);
            this.grpPersoneria.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpPersoneria.Location = new System.Drawing.Point(626, 192);
            this.grpPersoneria.Name = "grpPersoneria";
            this.grpPersoneria.Size = new System.Drawing.Size(230, 46);
            this.grpPersoneria.TabIndex = 9;
            this.grpPersoneria.TabStop = false;
            this.grpPersoneria.Text = "Personería";
            // 
            // txtDireccion
            // 
            this.txtDireccion.AllowDrag = false;
            this.txtDireccion.Location = new System.Drawing.Point(135, 119);
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.txtDireccion.Size = new System.Drawing.Size(479, 55);
            this.txtDireccion.TabIndex = 5;
            // 
            // textBox6
            // 
            this.textBox6.AllowDrag = false;
            this.textBox6.Location = new System.Drawing.Point(-184, -4);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(-279, -1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Cliente";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Controls.Add(this.textBox6);
            this.label10.Controls.Add(this.label9);
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label10.Location = new System.Drawing.Point(61, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Dirección";
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkActivo.Location = new System.Drawing.Point(626, 157);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(56, 17);
            this.chkActivo.TabIndex = 7;
            this.chkActivo.Text = "Activo";
            // 
            // textBox7
            // 
            this.textBox7.AllowDrag = false;
            this.textBox7.Location = new System.Drawing.Point(-184, -4);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(100, 20);
            this.textBox7.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(-279, -1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Cliente";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Controls.Add(this.textBox7);
            this.label12.Controls.Add(this.label11);
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label12.Location = new System.Drawing.Point(61, 197);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Observación";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(626, 122);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "Teléfono";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(689, 119);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(189, 20);
            this.txtTelefono.TabIndex = 6;
            // 
            // chkPublico
            // 
            this.chkPublico.AutoSize = true;
            this.chkPublico.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPublico.Location = new System.Drawing.Point(742, 157);
            this.chkPublico.Name = "chkPublico";
            this.chkPublico.Size = new System.Drawing.Size(59, 17);
            this.chkPublico.TabIndex = 7;
            this.chkPublico.Text = "Público";
            // 
            // ucCRUDProveedores
            // 
            this.Size = new System.Drawing.Size(1140, 466);
            this.Text = "ucCRUDProveedores";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).EndInit();
            this.label4.ResumeLayout(false);
            this.label8.ResumeLayout(false);
            this.label6.ResumeLayout(false);
            this.grpPersoneria.ResumeLayout(false);
            this.label10.ResumeLayout(false);
            this.label12.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label label3;
        private TextBox txtRUC;
        private TextBox txtNombre;
        private Label label1;
        private TextBox txtProveedorID;
        private Label label6;
        private TextBox textBox5;
        private Label label5;
        private Label label8;
        private TextBox textBox4;
        private Label label7;
        private Label label4;
        private TextBox textBox3;
        private Label label2;
        private ComboBox cbIdioma;
        private Base.ucTextSearchBox tSBPais;
        private Base.ucTextSearchBox tSBCiudad;
        private Label label10;
        private TextBox textBox6;
        private Label label9;
        private TextBox txtDireccion;
        private GroupBox grpPersoneria;
        private RadioButton rbJuridica;
        private RadioButton rbFisica;
        private TextBox txtObservaciones;
        private TextBox txtTelefono;
        private Label label13;
        private Label label12;
        private TextBox textBox7;
        private Label label11;
        private CheckBox chkActivo;
        private CheckBox chkPublico;


    }
}