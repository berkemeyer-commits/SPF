#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace SPF.Forms.UI
{
    public partial class FSelColExportExcel : Form
    {
        #region Eventos personalizados
        public event EventHandler<AceptarClickEventArgs> AceptarClick;
        #endregion Eventos personalizados

        public FSelColExportExcel()
        {
            InitializeComponent();
        }

        public FSelColExportExcel(List<string> columnasDisponibles)
        {
            InitializeComponent();

            this.listBox1.Enabled = false;
            this.listBox2.Enabled = false;
            this.btnAgregarTodos.Enabled = false;
            this.btnAgregar.Enabled = false;
            this.btnQuitarTodos.Enabled = false;
            this.btnQuitar.Enabled = false;

            this.listBox1.Items.Clear();
            this.listBox2.Items.Clear();
            foreach(string col in columnasDisponibles)
            {
                this.listBox1.Items.Add(col);
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.AceptarClick != null)
            {
                this.AceptarClick(this, new AceptarClickEventArgs(this.EvaluarRadios(), this.GetSelectedColumnsList()));
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string EvaluarRadios()
        {
            string Result = "";
            if (this.rbSoloVisibles.Checked)
                Result = AceptarClickEventArgs.VISIBLES;
            else if (this.rbTodas.Checked)
                Result = AceptarClickEventArgs.TODAS;
            else
                Result = AceptarClickEventArgs.SELECCIONADAS;
            return Result;
        }


        private void rbSeleccionarColumnas_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbSeleccionarColumnas.Checked)
            {
                this.listBox1.Enabled = true;
                this.listBox2.Enabled = true;
                this.btnAgregarTodos.Enabled = true;
                this.btnAgregar.Enabled = true;
                this.btnQuitarTodos.Enabled = true;
                this.btnQuitar.Enabled = true;
            }
            else
            {
                this.listBox1.Enabled = false;
                this.listBox2.Enabled = false;
                this.btnAgregarTodos.Enabled = false;
                this.btnAgregar.Enabled = false;
                this.btnQuitarTodos.Enabled = false;
                this.btnQuitar.Enabled = false;
            }
        }

        private void btnAgregarTodos_Click(object sender, EventArgs e)
        {
            if (this.listBox1.Items.Count > 0)
            {
                foreach (object item in this.listBox1.Items)
                {
                    this.listBox2.Items.Add((string)item);
                }
                this.listBox1.Items.Clear();
            }
        }

        private void btnQuitarTodos_Click(object sender, EventArgs e)
        {
            if (this.listBox2.Items.Count > 0)
            {
                foreach (object item in this.listBox2.Items)
                {
                    this.listBox1.Items.Add((string)item);
                }
                this.listBox2.Items.Clear();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex > -1)
            {
                this.listBox2.Items.Add(this.listBox1.Items[this.listBox1.SelectedIndex]);
                this.listBox1.Items.Remove(this.listBox1.Items[this.listBox1.SelectedIndex]);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (this.listBox2.SelectedIndex > -1)
            {
                this.listBox1.Items.Add(this.listBox2.Items[this.listBox2.SelectedIndex]);
                this.listBox2.Items.Remove(this.listBox2.Items[this.listBox2.SelectedIndex]);
            }
        }

        public List<string> GetSelectedColumnsList()
        {
            List<string> Result = new List<string>();
            foreach (object item in this.listBox2.Items)
            {
                Result.Add((string)item);
            }
            return Result;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            this.btnAgregar.PerformClick();
        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            this.btnQuitar.PerformClick();
        }
        
    }

    public class AceptarClickEventArgs : EventArgs
    {
        public const string VISIBLES = "V";
        public const string TODAS = "T";
        public const string SELECCIONADAS = "S";

        private string todas = VISIBLES;
        private List<string> listaColumnasSeleccionadas = null;

        public AceptarClickEventArgs(string valor, List<string> colNameList)
        {
            this.todas = valor;
            this.listaColumnasSeleccionadas = colNameList;
        }

        public string TipoSeleccion
        {
            get { return this.todas; }
        }

        public List<string> ListaColumnasSeleccionadas
        {
            get { return this.listaColumnasSeleccionadas; }
        }
    }
}