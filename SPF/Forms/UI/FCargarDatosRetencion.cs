#region Using

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.IO;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms;

using ModelEF6;
using SPF.Forms.Base;
using SPF.Types;
using SPF.Forms;
using SPF.Base;

#endregion

namespace SPF.Forms.UI
{
    public partial class FCargarDatosRetencion : Form
    {
        #region Variables
        private DateTime fechaRetencion;
        private string numeroRetencion;
        private List<int> listaFacturaIx;
        #endregion Variables

        #region Constantes
        #endregion Constantes

        #region Eventos Personalizados
        public event EventHandler AceptarClick;
        #endregion Eventos Personalizados

        #region Propiedades
        public DateTime FechaRetencion
        {
            set { this.fechaRetencion = value; }
            get { return this.fechaRetencion; }
        }

        public string NumeroRetencion
        {
            set { this.numeroRetencion = value; }
            get { return this.numeroRetencion; }
        }

        public List<int> ListaFacturaIx
        {
            set { this.listaFacturaIx = value; }
            get { return this.listaFacturaIx; }
        }
        #endregion Propiedades

        public FCargarDatosRetencion()
        {
            InitializeComponent();
        }

        public FCargarDatosRetencion(string titulo, List<int> listaIndex)
        {
            InitializeComponent();
            this.Text = titulo;
            this.ListaFacturaIx = listaIndex;
            this.LimpiarTextBoxes();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.ValidarDatos())
            {
                this.FechaRetencion = this.dtpFechaRetencion.Value;
                this.NumeroRetencion = this.txtNumeroRetencion.Text;

                if (this.AceptarClick != null)
                {
                    this.AceptarClick(this, null);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidarDatos()
        {
            if (this.txtNumeroRetencion.Text == String.Empty)
            {
                this.txtNumeroRetencion.Focus();
                MessageBox.Show("Debe ingresar el número de retención.",
                               "Atención Requerida",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void FCargarTransferenciaRecibo_Load(object sender, EventArgs e)
        {
            this.LimpiarTextBoxes();
            this.dtpFechaRetencion.Focus();
        }

        private void LimpiarTextBoxes()
        {
            this.dtpFechaRetencion.Value = DateTime.Now;
            this.txtNumeroRetencion.Text = String.Empty;
        }
    }
}