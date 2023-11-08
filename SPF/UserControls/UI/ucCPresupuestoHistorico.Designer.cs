using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.UserControls.UI
{
    partial class ucCPresupuestoHistorico
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
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.txtPresupHistID = new Gizmox.WebGUI.Forms.TextBox();
            this.txtFecDoc = new Gizmox.WebGUI.Forms.TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.txtNroAgente = new Gizmox.WebGUI.Forms.TextBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.txtClienteID = new Gizmox.WebGUI.Forms.TextBox();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.txtNombreAgente = new Gizmox.WebGUI.Forms.TextBox();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.txtANombreDe = new Gizmox.WebGUI.Forms.TextBox();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.txtObjeto = new Gizmox.WebGUI.Forms.TextBox();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.label9 = new Gizmox.WebGUI.Forms.Label();
            this.txtMoneda = new Gizmox.WebGUI.Forms.TextBox();
            this.txtMonto = new Gizmox.WebGUI.Forms.TextBox();
            this.label10 = new Gizmox.WebGUI.Forms.Label();
            this.label11 = new Gizmox.WebGUI.Forms.Label();
            this.txtNroDocumento = new Gizmox.WebGUI.Forms.TextBox();
            this.label12 = new Gizmox.WebGUI.Forms.Label();
            this.txtTramite = new Gizmox.WebGUI.Forms.TextBox();
            this.txtResponsable = new Gizmox.WebGUI.Forms.TextBox();
            this.label13 = new Gizmox.WebGUI.Forms.Label();
            this.txtFormaPago = new Gizmox.WebGUI.Forms.TextBox();
            this.label14 = new Gizmox.WebGUI.Forms.Label();
            this.label15 = new Gizmox.WebGUI.Forms.Label();
            this.txtMontoPago = new Gizmox.WebGUI.Forms.TextBox();
            this.txtFechaPago = new Gizmox.WebGUI.Forms.TextBox();
            this.label16 = new Gizmox.WebGUI.Forms.Label();
            this.label17 = new Gizmox.WebGUI.Forms.Label();
            this.txtDifBancaria = new Gizmox.WebGUI.Forms.TextBox();
            this.txtFechaBoleta = new Gizmox.WebGUI.Forms.TextBox();
            this.label18 = new Gizmox.WebGUI.Forms.Label();
            this.label19 = new Gizmox.WebGUI.Forms.Label();
            this.txtNombreBanco = new Gizmox.WebGUI.Forms.TextBox();
            this.txtBancoAbrev = new Gizmox.WebGUI.Forms.TextBox();
            this.label20 = new Gizmox.WebGUI.Forms.Label();
            this.label21 = new Gizmox.WebGUI.Forms.Label();
            this.txtRUC = new Gizmox.WebGUI.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListadoABM
            // 
            this.dgvListadoABM.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dgvListadoABM.Size = new System.Drawing.Size(1278, 430);
            this.dgvListadoABM.RowEnter += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgvListadoABM_RowEnter);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.txtRUC);
            this.pnlDetalle.Controls.Add(this.label21);
            this.pnlDetalle.Controls.Add(this.label20);
            this.pnlDetalle.Controls.Add(this.txtBancoAbrev);
            this.pnlDetalle.Controls.Add(this.txtNombreBanco);
            this.pnlDetalle.Controls.Add(this.label19);
            this.pnlDetalle.Controls.Add(this.label18);
            this.pnlDetalle.Controls.Add(this.txtFechaBoleta);
            this.pnlDetalle.Controls.Add(this.txtDifBancaria);
            this.pnlDetalle.Controls.Add(this.label17);
            this.pnlDetalle.Controls.Add(this.label16);
            this.pnlDetalle.Controls.Add(this.txtFechaPago);
            this.pnlDetalle.Controls.Add(this.txtMontoPago);
            this.pnlDetalle.Controls.Add(this.label15);
            this.pnlDetalle.Controls.Add(this.label14);
            this.pnlDetalle.Controls.Add(this.txtFormaPago);
            this.pnlDetalle.Controls.Add(this.label13);
            this.pnlDetalle.Controls.Add(this.txtResponsable);
            this.pnlDetalle.Controls.Add(this.txtTramite);
            this.pnlDetalle.Controls.Add(this.label12);
            this.pnlDetalle.Controls.Add(this.txtNroDocumento);
            this.pnlDetalle.Controls.Add(this.label11);
            this.pnlDetalle.Controls.Add(this.label10);
            this.pnlDetalle.Controls.Add(this.txtMonto);
            this.pnlDetalle.Controls.Add(this.txtMoneda);
            this.pnlDetalle.Controls.Add(this.label9);
            this.pnlDetalle.Controls.Add(this.label8);
            this.pnlDetalle.Controls.Add(this.txtObjeto);
            this.pnlDetalle.Controls.Add(this.label7);
            this.pnlDetalle.Controls.Add(this.txtANombreDe);
            this.pnlDetalle.Controls.Add(this.label6);
            this.pnlDetalle.Controls.Add(this.txtNombreAgente);
            this.pnlDetalle.Controls.Add(this.label5);
            this.pnlDetalle.Controls.Add(this.txtClienteID);
            this.pnlDetalle.Controls.Add(this.label4);
            this.pnlDetalle.Controls.Add(this.label3);
            this.pnlDetalle.Controls.Add(this.txtNroAgente);
            this.pnlDetalle.Controls.Add(this.label2);
            this.pnlDetalle.Controls.Add(this.txtFecDoc);
            this.pnlDetalle.Controls.Add(this.txtPresupHistID);
            this.pnlDetalle.Controls.Add(this.label1);
            this.pnlDetalle.Size = new System.Drawing.Size(1298, 450);
            // 
            // tBBaseForm
            // 
            this.tBBaseForm.Size = new System.Drawing.Size(1306, 42);
            // 
            // tabListaABM
            // 
            this.tabListaABM.Alignment = Gizmox.WebGUI.Forms.TabAlignment.Top;
            this.tabListaABM.Size = new System.Drawing.Size(1306, 479);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pr. Hist. ID";
            // 
            // txtPresupHistID
            // 
            this.txtPresupHistID.BackColor = System.Drawing.SystemColors.Control;
            this.txtPresupHistID.Location = new System.Drawing.Point(125, 36);
            this.txtPresupHistID.Name = "txtPresupHistID";
            this.txtPresupHistID.ReadOnly = true;
            this.txtPresupHistID.Size = new System.Drawing.Size(100, 20);
            this.txtPresupHistID.TabIndex = 1;
            this.txtPresupHistID.TabStop = false;
            this.txtPresupHistID.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // txtFecDoc
            // 
            this.txtFecDoc.BackColor = System.Drawing.SystemColors.Control;
            this.txtFecDoc.Location = new System.Drawing.Point(317, 36);
            this.txtFecDoc.Name = "txtFecDoc";
            this.txtFecDoc.ReadOnly = true;
            this.txtFecDoc.Size = new System.Drawing.Size(100, 20);
            this.txtFecDoc.TabIndex = 1;
            this.txtFecDoc.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fec. Doc.";
            // 
            // txtNroAgente
            // 
            this.txtNroAgente.BackColor = System.Drawing.SystemColors.Control;
            this.txtNroAgente.Location = new System.Drawing.Point(125, 73);
            this.txtNroAgente.Name = "txtNroAgente";
            this.txtNroAgente.ReadOnly = true;
            this.txtNroAgente.Size = new System.Drawing.Size(100, 20);
            this.txtNroAgente.TabIndex = 1;
            this.txtNroAgente.TabStop = false;
            this.txtNroAgente.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "N° Agente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "ID Cliente";
            // 
            // txtClienteID
            // 
            this.txtClienteID.BackColor = System.Drawing.SystemColors.Control;
            this.txtClienteID.Location = new System.Drawing.Point(125, 113);
            this.txtClienteID.Name = "txtClienteID";
            this.txtClienteID.ReadOnly = true;
            this.txtClienteID.Size = new System.Drawing.Size(100, 20);
            this.txtClienteID.TabIndex = 1;
            this.txtClienteID.TabStop = false;
            this.txtClienteID.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Agente";
            // 
            // txtNombreAgente
            // 
            this.txtNombreAgente.BackColor = System.Drawing.SystemColors.Control;
            this.txtNombreAgente.Location = new System.Drawing.Point(317, 76);
            this.txtNombreAgente.Name = "txtNombreAgente";
            this.txtNombreAgente.ReadOnly = true;
            this.txtNombreAgente.Size = new System.Drawing.Size(477, 20);
            this.txtNombreAgente.TabIndex = 1;
            this.txtNombreAgente.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(240, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "A Nombre de";
            // 
            // txtANombreDe
            // 
            this.txtANombreDe.BackColor = System.Drawing.SystemColors.Control;
            this.txtANombreDe.Location = new System.Drawing.Point(317, 113);
            this.txtANombreDe.Name = "txtANombreDe";
            this.txtANombreDe.ReadOnly = true;
            this.txtANombreDe.Size = new System.Drawing.Size(415, 20);
            this.txtANombreDe.TabIndex = 1;
            this.txtANombreDe.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(240, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Nombre";
            // 
            // txtObjeto
            // 
            this.txtObjeto.BackColor = System.Drawing.SystemColors.Control;
            this.txtObjeto.Location = new System.Drawing.Point(125, 153);
            this.txtObjeto.Name = "txtObjeto";
            this.txtObjeto.ReadOnly = true;
            this.txtObjeto.Size = new System.Drawing.Size(482, 20);
            this.txtObjeto.TabIndex = 1;
            this.txtObjeto.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Objeto";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(240, 192);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Moneda";
            // 
            // txtMoneda
            // 
            this.txtMoneda.BackColor = System.Drawing.SystemColors.Control;
            this.txtMoneda.Location = new System.Drawing.Point(317, 189);
            this.txtMoneda.Name = "txtMoneda";
            this.txtMoneda.ReadOnly = true;
            this.txtMoneda.Size = new System.Drawing.Size(100, 20);
            this.txtMoneda.TabIndex = 1;
            this.txtMoneda.TabStop = false;
            // 
            // txtMonto
            // 
            this.txtMonto.BackColor = System.Drawing.SystemColors.Control;
            this.txtMonto.Location = new System.Drawing.Point(125, 189);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.ReadOnly = true;
            this.txtMonto.Size = new System.Drawing.Size(100, 20);
            this.txtMonto.TabIndex = 1;
            this.txtMonto.TabStop = false;
            this.txtMonto.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(52, 192);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Monto";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(433, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "N° Doc.";
            // 
            // txtNroDocumento
            // 
            this.txtNroDocumento.BackColor = System.Drawing.SystemColors.Control;
            this.txtNroDocumento.Location = new System.Drawing.Point(507, 36);
            this.txtNroDocumento.Name = "txtNroDocumento";
            this.txtNroDocumento.ReadOnly = true;
            this.txtNroDocumento.Size = new System.Drawing.Size(100, 20);
            this.txtNroDocumento.TabIndex = 1;
            this.txtNroDocumento.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(52, 229);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Trámite";
            // 
            // txtTramite
            // 
            this.txtTramite.BackColor = System.Drawing.SystemColors.Control;
            this.txtTramite.Location = new System.Drawing.Point(125, 226);
            this.txtTramite.Name = "txtTramite";
            this.txtTramite.ReadOnly = true;
            this.txtTramite.Size = new System.Drawing.Size(482, 20);
            this.txtTramite.TabIndex = 1;
            this.txtTramite.TabStop = false;
            // 
            // txtResponsable
            // 
            this.txtResponsable.BackColor = System.Drawing.SystemColors.Control;
            this.txtResponsable.Location = new System.Drawing.Point(694, 226);
            this.txtResponsable.Name = "txtResponsable";
            this.txtResponsable.ReadOnly = true;
            this.txtResponsable.Size = new System.Drawing.Size(100, 20);
            this.txtResponsable.TabIndex = 1;
            this.txtResponsable.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(617, 229);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Responsable";
            // 
            // txtFormaPago
            // 
            this.txtFormaPago.BackColor = System.Drawing.SystemColors.Control;
            this.txtFormaPago.Location = new System.Drawing.Point(507, 264);
            this.txtFormaPago.Name = "txtFormaPago";
            this.txtFormaPago.ReadOnly = true;
            this.txtFormaPago.Size = new System.Drawing.Size(100, 20);
            this.txtFormaPago.TabIndex = 1;
            this.txtFormaPago.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(433, 267);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Forma Pago";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(240, 267);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Monto Pago";
            // 
            // txtMontoPago
            // 
            this.txtMontoPago.BackColor = System.Drawing.SystemColors.Control;
            this.txtMontoPago.Location = new System.Drawing.Point(317, 264);
            this.txtMontoPago.Name = "txtMontoPago";
            this.txtMontoPago.ReadOnly = true;
            this.txtMontoPago.Size = new System.Drawing.Size(100, 20);
            this.txtMontoPago.TabIndex = 1;
            this.txtMontoPago.TabStop = false;
            this.txtMontoPago.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // txtFechaPago
            // 
            this.txtFechaPago.BackColor = System.Drawing.SystemColors.Control;
            this.txtFechaPago.Location = new System.Drawing.Point(125, 264);
            this.txtFechaPago.Name = "txtFechaPago";
            this.txtFechaPago.ReadOnly = true;
            this.txtFechaPago.Size = new System.Drawing.Size(100, 20);
            this.txtFechaPago.TabIndex = 1;
            this.txtFechaPago.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(52, 267);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Fec. Pago";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(617, 267);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Dif. Bancaria";
            // 
            // txtDifBancaria
            // 
            this.txtDifBancaria.BackColor = System.Drawing.SystemColors.Control;
            this.txtDifBancaria.Location = new System.Drawing.Point(694, 264);
            this.txtDifBancaria.Name = "txtDifBancaria";
            this.txtDifBancaria.ReadOnly = true;
            this.txtDifBancaria.Size = new System.Drawing.Size(100, 20);
            this.txtDifBancaria.TabIndex = 1;
            this.txtDifBancaria.TabStop = false;
            this.txtDifBancaria.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // txtFechaBoleta
            // 
            this.txtFechaBoleta.BackColor = System.Drawing.SystemColors.Control;
            this.txtFechaBoleta.Location = new System.Drawing.Point(694, 302);
            this.txtFechaBoleta.Name = "txtFechaBoleta";
            this.txtFechaBoleta.ReadOnly = true;
            this.txtFechaBoleta.Size = new System.Drawing.Size(100, 20);
            this.txtFechaBoleta.TabIndex = 1;
            this.txtFechaBoleta.TabStop = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(617, 309);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Fec. Boleta";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(240, 305);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "Nom. Banco";
            // 
            // txtNombreBanco
            // 
            this.txtNombreBanco.BackColor = System.Drawing.SystemColors.Control;
            this.txtNombreBanco.Location = new System.Drawing.Point(317, 302);
            this.txtNombreBanco.Name = "txtNombreBanco";
            this.txtNombreBanco.ReadOnly = true;
            this.txtNombreBanco.Size = new System.Drawing.Size(290, 20);
            this.txtNombreBanco.TabIndex = 1;
            this.txtNombreBanco.TabStop = false;
            // 
            // txtBancoAbrev
            // 
            this.txtBancoAbrev.BackColor = System.Drawing.SystemColors.Control;
            this.txtBancoAbrev.Location = new System.Drawing.Point(125, 302);
            this.txtBancoAbrev.Name = "txtBancoAbrev";
            this.txtBancoAbrev.ReadOnly = true;
            this.txtBancoAbrev.Size = new System.Drawing.Size(100, 20);
            this.txtBancoAbrev.TabIndex = 1;
            this.txtBancoAbrev.TabStop = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(52, 305);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(35, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = "Banc. Abrev.";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(617, 39);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(35, 13);
            this.label21.TabIndex = 0;
            this.label21.Text = "RUC";
            // 
            // txtRUC
            // 
            this.txtRUC.BackColor = System.Drawing.SystemColors.Control;
            this.txtRUC.Location = new System.Drawing.Point(694, 36);
            this.txtRUC.Name = "txtRUC";
            this.txtRUC.ReadOnly = true;
            this.txtRUC.Size = new System.Drawing.Size(100, 20);
            this.txtRUC.TabIndex = 1;
            this.txtRUC.TabStop = false;
            // 
            // ucCPresupuestoHistorico
            // 
            this.Size = new System.Drawing.Size(1308, 557);
            this.Text = "ucCPresupuestoHistorico";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox txtPresupHistID;
        private Label label1;
        private Label label2;
        private TextBox txtFecDoc;
        private Label label3;
        private TextBox txtNroAgente;
        private TextBox txtClienteID;
        private Label label4;
        private Label label7;
        private TextBox txtANombreDe;
        private Label label6;
        private TextBox txtNombreAgente;
        private Label label5;
        private Label label10;
        private TextBox txtMonto;
        private TextBox txtMoneda;
        private Label label9;
        private Label label8;
        private TextBox txtObjeto;
        private TextBox txtNroDocumento;
        private Label label11;
        private Label label13;
        private TextBox txtResponsable;
        private TextBox txtTramite;
        private Label label12;
        private Label label16;
        private TextBox txtFechaPago;
        private TextBox txtMontoPago;
        private Label label15;
        private Label label14;
        private TextBox txtFormaPago;
        private TextBox txtDifBancaria;
        private Label label17;
        private Label label20;
        private TextBox txtBancoAbrev;
        private TextBox txtNombreBanco;
        private Label label19;
        private Label label18;
        private TextBox txtFechaBoleta;
        private TextBox txtRUC;
        private Label label21;


    }
}