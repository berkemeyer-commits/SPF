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
    public partial class FReservarNroPresup : Form
    {
        #region Variables
        BerkeDBEntities DBContext;
        private int gNropresupuesto;
        private int gCantidad;
        private string gSerie;
        #endregion Variables

        #region Propiedades
        public int NroPresupuesto
        {
            get { return this.gNropresupuesto; }
            set { this.gNropresupuesto = value; }
        }

        public int Cantidad
        {
            get { return this.gCantidad; }
            set { this.gCantidad = value; }
        }

        public string Serie
        {
            get { return this.gSerie; }
            set { this.gSerie = value; }
        }
        #endregion Propiedades

        public FReservarNroPresup()
        {
            InitializeComponent();
        }

        public FReservarNroPresup(string titulo, BerkeDBEntities context)
        {
            InitializeComponent();
            this.Text = titulo;
            this.DBContext = context;

            List<ConfigPresup> lista = this.DBContext.ConfigPresup.Where(a => a.Vigente == true).ToList();

            if (lista.Count > 1)
            {
                throw new Exception("No se encuentra configuración para obtener el número de presupuesto o existe más de uno vigente");
            }
            this.NroPresupuesto = lista.First().Numero.Value;
            this.Serie = lista.First().Serie;
            this.Cantidad = 1;
            this.txtCantidad.Text = this.Cantidad.ToString();
            this.txtNros.Text = this.GetNros();
            this.txtUltNroUtilizado.Text = lista.First().Serie + (this.NroPresupuesto - 1).ToString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.txtCantidad.Text == string.Empty)
            {
                MessageBox.Show("Debe indicar un valor númerico para Cantidad.",
                                "Atención Requerida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }

            int cantidad;
            if ((!int.TryParse(this.txtCantidad.Text, out cantidad)) || (cantidad == 0))
            {
                MessageBox.Show("El valor de cantidad debe ser numérico y mayor a 0 (cero).",
                                "Atención Requerida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }
            this.Cantidad = cantidad;
            this.txtNros.Text = this.GetNros();
                    
            string caption = "Reserva de Números de Presupuesto";
            string message = string.Format("Se reservarán {0} números de presupuestos ¿Está seguro?", this.Cantidad.ToString());

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(DialogHandler));
        }

        private void DialogHandler(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    this.ReservarNros();
                }
            }
        }

        private void ReservarNros()
        {
            bool success = false;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        List<ConfigPresup> lista = context.ConfigPresup.Where(a => a.Vigente == true).ToList();

                        if (lista.Count > 1)
                        {
                            throw new Exception("No se encuentra configuración para obtener el número de presupuesto o existe más de uno vigente");
                        }

                        this.NroPresupuesto = lista.First().Numero.Value;
                        
                        lista.First().Numero = this.NroPresupuesto + this.Cantidad;
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        MessageBox.Show("Ocurrió un error al procesar la reserva de números de presupuestos. "
                                        + ex.Message + Environment.NewLine
                                        + ex.InnerException,
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Stop);
                    }
                }
            }
            if (success)
            {
                MessageBox.Show("Operación completada con éxito." + Environment.NewLine + 
                                "N° de Presupuesto reservados: " + Environment.NewLine + this.GetNros(), 
                                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information,
                                new EventHandler(DialogHandler1));                
            }
        }

        private void DialogHandler1(object sender, EventArgs e)
        {
            this.Close();
        }

        private string GetNros()
        {
            string lista = string.Empty;

            for (int i = this.NroPresupuesto; i < this.NroPresupuesto + this.Cantidad; i++)
            {
                if (lista != string.Empty)
                    lista += ", ";

                lista += this.Serie + i.ToString();
            }

            return lista;
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            this.txtNros.Text = string.Empty;
            int cantidad;
            if ((!int.TryParse(this.txtCantidad.Text, out cantidad)) || (cantidad == 0))
            {
                MessageBox.Show("El valor de cantidad debe ser numérico y mayor a 0 (cero).",
                                "Atención Requerida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }
            this.Cantidad = cantidad;
            this.txtNros.Text = this.GetNros();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}