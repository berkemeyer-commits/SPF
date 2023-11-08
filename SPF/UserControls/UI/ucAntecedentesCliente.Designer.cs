using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.UserControls.UI
{
    partial class ucAntecedentesCliente
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
            this.txtIDAntecedente = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.txtClienteID = new Gizmox.WebGUI.Forms.TextBox();
            this.txtClienteNombre = new Gizmox.WebGUI.Forms.TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.cbTipoAntecedente = new Gizmox.WebGUI.Forms.ComboBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.tSBAutorizadoPor = new SPF.UserControls.Base.ucTextSearchBox();
            this.label35 = new Gizmox.WebGUI.Forms.Label();
            this.tSBEnviadoPor = new SPF.UserControls.Base.ucTextSearchBox();
            this.label34 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.dtpFecha = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.txtObservaciones = new Gizmox.WebGUI.Forms.TextBox();
            this.label29 = new Gizmox.WebGUI.Forms.Label();
            this.txtTipoAntecedenteLocal = new Gizmox.WebGUI.Forms.TextBox();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.txtEdActaNro = new Gizmox.WebGUI.Forms.TextBox();
            this.txtEdActaAnio = new Gizmox.WebGUI.Forms.TextBox();
            this.txtEdRegistroNro = new Gizmox.WebGUI.Forms.TextBox();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.tSBTramite = new SPF.UserControls.Base.ucTextSearchBox();
            this.label10 = new Gizmox.WebGUI.Forms.Label();
            this.lblAutorizacionVigente = new Gizmox.WebGUI.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListadoABM
            // 
            this.dgvListadoABM.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dgvListadoABM.Size = new System.Drawing.Size(807, 394);
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
            this.tbbGuardar.Click += new System.EventHandler(this.tbbGuardar_Click);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.lblAutorizacionVigente);
            this.pnlDetalle.Controls.Add(this.label10);
            this.pnlDetalle.Controls.Add(this.tSBTramite);
            this.pnlDetalle.Controls.Add(this.label7);
            this.pnlDetalle.Controls.Add(this.txtEdRegistroNro);
            this.pnlDetalle.Controls.Add(this.txtEdActaAnio);
            this.pnlDetalle.Controls.Add(this.txtEdActaNro);
            this.pnlDetalle.Controls.Add(this.label6);
            this.pnlDetalle.Controls.Add(this.label5);
            this.pnlDetalle.Controls.Add(this.txtTipoAntecedenteLocal);
            this.pnlDetalle.Controls.Add(this.label29);
            this.pnlDetalle.Controls.Add(this.txtObservaciones);
            this.pnlDetalle.Controls.Add(this.dtpFecha);
            this.pnlDetalle.Controls.Add(this.label4);
            this.pnlDetalle.Controls.Add(this.label34);
            this.pnlDetalle.Controls.Add(this.tSBEnviadoPor);
            this.pnlDetalle.Controls.Add(this.label35);
            this.pnlDetalle.Controls.Add(this.tSBAutorizadoPor);
            this.pnlDetalle.Controls.Add(this.label3);
            this.pnlDetalle.Controls.Add(this.cbTipoAntecedente);
            this.pnlDetalle.Controls.Add(this.label2);
            this.pnlDetalle.Controls.Add(this.txtClienteNombre);
            this.pnlDetalle.Controls.Add(this.txtClienteID);
            this.pnlDetalle.Controls.Add(this.label1);
            this.pnlDetalle.Controls.Add(this.txtIDAntecedente);
            this.pnlDetalle.Size = new System.Drawing.Size(957, 414);
            // 
            // tBBaseForm
            // 
            this.tBBaseForm.Size = new System.Drawing.Size(965, 42);
            // 
            // txtIDAntecedente
            // 
            this.txtIDAntecedente.BackColor = System.Drawing.SystemColors.Control;
            this.txtIDAntecedente.Location = new System.Drawing.Point(212, 21);
            this.txtIDAntecedente.Name = "txtIDAntecedente";
            this.txtIDAntecedente.ReadOnly = true;
            this.txtIDAntecedente.Size = new System.Drawing.Size(100, 20);
            this.txtIDAntecedente.TabIndex = 0;
            this.txtIDAntecedente.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            // 
            // txtClienteID
            // 
            this.txtClienteID.BackColor = System.Drawing.SystemColors.Control;
            this.txtClienteID.Location = new System.Drawing.Point(212, 53);
            this.txtClienteID.Name = "txtClienteID";
            this.txtClienteID.ReadOnly = true;
            this.txtClienteID.Size = new System.Drawing.Size(100, 20);
            this.txtClienteID.TabIndex = 0;
            this.txtClienteID.TabStop = false;
            // 
            // txtClienteNombre
            // 
            this.txtClienteNombre.BackColor = System.Drawing.SystemColors.Control;
            this.txtClienteNombre.Location = new System.Drawing.Point(313, 53);
            this.txtClienteNombre.Name = "txtClienteNombre";
            this.txtClienteNombre.ReadOnly = true;
            this.txtClienteNombre.Size = new System.Drawing.Size(334, 20);
            this.txtClienteNombre.TabIndex = 0;
            this.txtClienteNombre.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cliente";
            // 
            // cbTipoAntecedente
            // 
            this.cbTipoAntecedente.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoAntecedente.FormattingEnabled = true;
            this.cbTipoAntecedente.Location = new System.Drawing.Point(445, 89);
            this.cbTipoAntecedente.Name = "cbTipoAntecedente";
            this.cbTipoAntecedente.Size = new System.Drawing.Size(202, 21);
            this.cbTipoAntecedente.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(344, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tipo Antecedente";
            // 
            // tSBAutorizadoPor
            // 
            this.tSBAutorizadoPor.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBAutorizadoPor.DBContext = null;
            this.tSBAutorizadoPor.DisplayMember = "";
            this.tSBAutorizadoPor.KeyMember = "";
            this.tSBAutorizadoPor.LabelCampoBusqueda = "";
            this.tSBAutorizadoPor.Location = new System.Drawing.Point(212, 183);
            this.tSBAutorizadoPor.Name = "tSBAutorizadoPor";
            this.tSBAutorizadoPor.NombreCampoDescrip = "";
            this.tSBAutorizadoPor.NombreCampoID = "";
            this.tSBAutorizadoPor.Size = new System.Drawing.Size(435, 20);
            this.tSBAutorizadoPor.TabIndex = 7;
            this.tSBAutorizadoPor.Text = "ucTextSearchBox";
            this.tSBAutorizadoPor.TituloBuscador = "";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(130, 190);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(35, 13);
            this.label35.TabIndex = 0;
            this.label35.Text = "Autorizado por";
            // 
            // tSBEnviadoPor
            // 
            this.tSBEnviadoPor.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBEnviadoPor.DBContext = null;
            this.tSBEnviadoPor.DisplayMember = "";
            this.tSBEnviadoPor.KeyMember = "";
            this.tSBEnviadoPor.LabelCampoBusqueda = "";
            this.tSBEnviadoPor.Location = new System.Drawing.Point(212, 218);
            this.tSBEnviadoPor.Name = "tSBEnviadoPor";
            this.tSBEnviadoPor.NombreCampoDescrip = "";
            this.tSBEnviadoPor.NombreCampoID = "";
            this.tSBEnviadoPor.Size = new System.Drawing.Size(435, 20);
            this.tSBEnviadoPor.TabIndex = 8;
            this.tSBEnviadoPor.Text = "ucTextSearchBox";
            this.tSBEnviadoPor.TituloBuscador = "";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(144, 218);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(35, 13);
            this.label34.TabIndex = 0;
            this.label34.Text = "Enviado por";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Fecha";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/mm/yyyy";
            this.dtpFecha.Location = new System.Drawing.Point(212, 89);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(100, 21);
            this.dtpFecha.TabIndex = 1;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(212, 266);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(435, 125);
            this.txtObservaciones.TabIndex = 9;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(130, 269);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(35, 13);
            this.label29.TabIndex = 0;
            this.label29.Text = "Observaciones";
            // 
            // txtTipoAntecedenteLocal
            // 
            this.txtTipoAntecedenteLocal.BackColor = System.Drawing.SystemColors.Control;
            this.txtTipoAntecedenteLocal.Location = new System.Drawing.Point(403, 21);
            this.txtTipoAntecedenteLocal.Name = "txtTipoAntecedenteLocal";
            this.txtTipoAntecedenteLocal.ReadOnly = true;
            this.txtTipoAntecedenteLocal.Size = new System.Drawing.Size(100, 20);
            this.txtTipoAntecedenteLocal.TabIndex = 0;
            this.txtTipoAntecedenteLocal.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(324, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Tipo Registro";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(175, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Acta";
            // 
            // txtEdActaNro
            // 
            this.txtEdActaNro.AllowDrag = false;
            this.txtEdActaNro.BackColor = System.Drawing.SystemColors.Window;
            this.txtEdActaNro.Location = new System.Drawing.Point(212, 125);
            this.txtEdActaNro.Name = "txtEdActaNro";
            this.txtEdActaNro.ReadOnly = true;
            this.txtEdActaNro.Size = new System.Drawing.Size(100, 20);
            this.txtEdActaNro.TabIndex = 3;
            // 
            // txtEdActaAnio
            // 
            this.txtEdActaAnio.AllowDrag = false;
            this.txtEdActaAnio.BackColor = System.Drawing.SystemColors.Window;
            this.txtEdActaAnio.Location = new System.Drawing.Point(314, 125);
            this.txtEdActaAnio.Name = "txtEdActaAnio";
            this.txtEdActaAnio.ReadOnly = true;
            this.txtEdActaAnio.Size = new System.Drawing.Size(100, 20);
            this.txtEdActaAnio.TabIndex = 4;
            // 
            // txtEdRegistroNro
            // 
            this.txtEdRegistroNro.AllowDrag = false;
            this.txtEdRegistroNro.BackColor = System.Drawing.SystemColors.Window;
            this.txtEdRegistroNro.Location = new System.Drawing.Point(547, 125);
            this.txtEdRegistroNro.Name = "txtEdRegistroNro";
            this.txtEdRegistroNro.Size = new System.Drawing.Size(100, 20);
            this.txtEdRegistroNro.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(497, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Registro";
            // 
            // tSBTramite
            // 
            this.tSBTramite.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBTramite.DBContext = null;
            this.tSBTramite.DisplayMember = "";
            this.tSBTramite.KeyMember = "";
            this.tSBTramite.LabelCampoBusqueda = "";
            this.tSBTramite.Location = new System.Drawing.Point(212, 154);
            this.tSBTramite.Name = "tSBTramite";
            this.tSBTramite.NombreCampoDescrip = "";
            this.tSBTramite.NombreCampoID = "";
            this.tSBTramite.Size = new System.Drawing.Size(435, 20);
            this.tSBTramite.TabIndex = 6;
            this.tSBTramite.Text = "ucTextSearchBox";
            this.tSBTramite.TituloBuscador = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(161, 161);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Trámite";
            // 
            // lblAutorizacionVigente
            // 
            this.lblAutorizacionVigente.AutoSize = true;
            this.lblAutorizacionVigente.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblAutorizacionVigente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblAutorizacionVigente.Location = new System.Drawing.Point(517, 24);
            this.lblAutorizacionVigente.Name = "lblAutorizacionVigente";
            this.lblAutorizacionVigente.Size = new System.Drawing.Size(41, 13);
            this.lblAutorizacionVigente.TabIndex = 15;
            this.lblAutorizacionVigente.Text = "Autorización para modificación vigente";
            this.lblAutorizacionVigente.Visible = false;
            // 
            // ucAntecedentesCliente
            // 
            this.Size = new System.Drawing.Size(967, 521);
            this.Text = "ucAntecedentesCliente";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label label3;
        private ComboBox cbTipoAntecedente;
        private Label label2;
        private TextBox txtClienteNombre;
        private TextBox txtClienteID;
        private Label label1;
        private TextBox txtIDAntecedente;
        private Label label4;
        private Label label34;
        private Base.ucTextSearchBox tSBEnviadoPor;
        private Label label35;
        private Base.ucTextSearchBox tSBAutorizadoPor;
        private DateTimePicker dtpFecha;
        private Label label29;
        private TextBox txtObservaciones;
        private Label label5;
        private TextBox txtTipoAntecedenteLocal;
        private Label label7;
        private TextBox txtEdRegistroNro;
        private TextBox txtEdActaAnio;
        private TextBox txtEdActaNro;
        private Label label6;
        private Label label10;
        private Base.ucTextSearchBox tSBTramite;
        private Label lblAutorizacionVigente;


    }
}