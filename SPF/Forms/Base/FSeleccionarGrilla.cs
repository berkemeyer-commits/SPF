#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace SPF.Forms.Base
{
    public partial class FSeleccionarGrilla : Form
    {
        #region Variables
        private BindingSource bS_Origen;
        private BindingSource bS_Destino;
        private string tituloOrigenString = String.Empty;
        private string tituloDestinoString = String.Empty;
        private int firstVisibleColOrigen = -1;
        private int firstVisibleColDestino = -1;
        #endregion Variables

        #region Constantes
        private const string TITULO_GRILLA_ORIGEN = "{0}";
        private const string TITULO_GRILLA_DESTINO = "{0}";
        #endregion Constantes

        #region Propiedades
        public string SetGroupTitle
        {
            set { this.grpFiltro.Text = value; }
        }

        public string SetTituloGrillaOrigen
        {
            set { this.lblGrillaOrigen.Text = value; }
        }

        public string TituloGrillaDestino
        {
            set { this.lblGrillaDestino.Text = value; }
            get { return this.lblGrillaDestino.Text; }
        }

        public Color SetColorTituloGrillaDestino
        {
            set { this.lblGrillaDestino.ForeColor = value; }
        }

        public Color SetColorTituloGrillaOrigen
        {
            set { this.lblGrillaOrigen.ForeColor = value; }
        }

        public string TituloOrigenString
        {
            set { this.tituloOrigenString = value; }
            get { return this.tituloOrigenString; }
        }

        public string TituloDestinoString
        {
            set { this.tituloDestinoString = value; }
            get { return this.tituloDestinoString; }
        }

        public int FirstVisibleColumnOrigen
        {
            set { this.firstVisibleColOrigen = value; }
            get { return this.firstVisibleColOrigen; }
        }

        public int FirstVisibleColumnDestino
        {
            set { this.firstVisibleColDestino = value; }
            get { return this.firstVisibleColDestino; }
        }

        public BindingSource GetDataSourceOrigen
        {
            get { return this.bS_Origen;}
        }

        public BindingSource GetDataSourceDestino
        {
            get { return this.bS_Destino; }
        }
        #endregion Propiedades

        #region Métodos de Inicio
        public FSeleccionarGrilla()
        {
            InitializeComponent();
        }

        public void Inicializar()
        {
            
        }
        #endregion Métodos de Inicio

        #region Métodos Locales sobre controles
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbMarcarTodo_CheckedChanged(object sender, EventArgs e)
        {
            this.MarcarTodo(this.cbMarcarTodo.Checked);
        }
        #endregion Métodos Locales sobre controles

        #region Métodos Públicos
        protected virtual void btnFiltrar_Click(object sender, EventArgs e)
        {
            //
        }

        public void SetDataSourceOrigen<T>(List<T> lista) where T : class
        {
            this.bS_Origen = new BindingSource();
            this.bS_Origen.DataSource = lista;
            this.dgvOrigen.DataSource = this.bS_Origen;
            
            if (this.TituloOrigenString != String.Empty)
                this.SetTituloGrillaOrigen = String.Format(this.TituloOrigenString, this.dgvOrigen.Rows.Count.ToString());


            if (this.dgvOrigen.Rows.Count > 0)
            {
                //this.FormatearGrillas();
                this.FormatearGrillaOrigen();
                this.SetFirstVisibleColumnOrigen();
                this.dgvOrigen.CurrentCell = this.dgvOrigen.Rows[0].Cells[this.FirstVisibleColumnOrigen];
                this.dgvOrigen.CurrentCell.Selected = true;
                this.dgvOrigen.Focus();
            }
            else
            {
                this.dgvOrigen.DataSource = null;

                if (this.dgvOrigen.Columns.Count > 0)
                    this.dgvOrigen.Columns.Remove(this.dgvOrigen.Columns[0]);
            }

            
        }

        public void SetDataSourceDestino<T>(List<T> lista) where T : class
        {
            this.bS_Destino = new BindingSource();
            this.bS_Destino.DataSource = lista;
            this.dgvDestino.DataSource = this.bS_Destino;

            if (this.TituloDestinoString != String.Empty)
                this.TituloGrillaDestino = String.Format(this.TituloDestinoString, this.dgvDestino.Rows.Count.ToString());


            if (this.dgvDestino.Rows.Count > 0)
            {
                //this.FormatearGrillas();
                this.FormatearGrillaDestino();
                this.SetFirstVisibleColumnDestino();
                this.dgvDestino.CurrentCell = this.dgvDestino.Rows[0].Cells[this.FirstVisibleColumnDestino];
                this.dgvDestino.CurrentCell.Selected = true;
                this.dgvDestino.Focus();
            }
            else
            {
                this.dgvDestino.DataSource = null;

                if (this.dgvDestino.Columns.Count > 0)
                    this.dgvDestino.Columns.Remove(this.dgvDestino.Columns[0]);
            }
        }

        public void PrepararDatos<TEntity>(string PKName) where TEntity : class
        {
            if (this.dgvOrigen.Rows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar alguna fila en la grilla superior.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            int cntFilasAgregadas = 0;
            List<TEntity> listaOrigen = new List<TEntity>();

            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[this.dgvOrigen.DataSource];
            currencyManager1.SuspendBinding();

            foreach (DataGridViewRow row in this.dgvOrigen.Rows)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)row.Cells[0];
                if ((checkCell.Value != null) && ((bool)checkCell.Value) && (row.Visible))
                {
                    listaOrigen.Add((TEntity)row.DataBoundItem);
                    row.Visible = false;
                    cntFilasAgregadas++;
                }
            }
            currencyManager1.ResumeBinding();

            this.MarcarTodo(false);
            this.cbMarcarTodo.Checked = false;

            if (listaOrigen.Count > 0)
            {
                int cantidadFilas = this.dgvDestino.RowCount;
                var listaDestino = cantidadFilas > 0 ?
                                                      (List<TEntity>)this.bS_Destino.DataSource :
                                                      new List<TEntity>();
                listaDestino.AddRange(listaOrigen);

                if (this.bS_Destino == null)
                    this.bS_Destino = new BindingSource();

                this.bS_Destino.DataSource = listaDestino.GroupBy(x => GetPropertyValue(x, PKName)).Select(y => y.First()).ToList();
                this.dgvDestino.DataSource = this.bS_Destino;
                
                if (this.dgvDestino.Rows.Count > 0)
                {
                    if (this.TituloOrigenString != String.Empty)
                    {
                        this.SetTituloGrillaOrigen = String.Format(this.TituloOrigenString, (this.dgvOrigen.Rows.OfType<DataGridViewRow>().Where(a => a.Visible == true).ToList().Count).ToString());
                    }

                    if (this.TituloDestinoString != String.Empty)
                        this.TituloGrillaDestino = String.Format(this.TituloDestinoString, this.dgvDestino.Rows.Count.ToString());

                    //this.FormatearGrillas();
                    this.FormatearGrillaDestino();
                    this.SetFirstVisibleColumnDestino();
                    this.dgvDestino.CurrentCell = this.dgvDestino.Rows[0].Cells[this.FirstVisibleColumnDestino];
                    this.dgvDestino.CurrentCell.Selected = true;
                    this.dgvDestino.Focus();
                }

                
            }
        }

        private static object GetPropertyValue(object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName).GetValue(obj, null);
        }

        protected void SetFirstVisibleColumnOrigen()
        {
            foreach (DataGridViewColumn col in this.dgvOrigen.Columns)
            {
                if (col.Visible)
                {
                    this.FirstVisibleColumnOrigen = col.Index;
                    break;
                }
            }
        }

        protected void SetFirstVisibleColumnDestino()
        {
            foreach (DataGridViewColumn col in this.dgvDestino.Columns)
            {
                if (col.Visible)
                {
                    this.FirstVisibleColumnDestino = col.Index;
                    break;
                }
            }
        }

        protected virtual void FormatearGrillaOrigen()
        {
            //
        }

        protected virtual void FormatearGrillaDestino()
        {
            //
        }
        #endregion Métodos Públicos

        #region Métodos Privados
        protected virtual void FormatearGrillas()
        {
            this.dgvOrigen.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvOrigen.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dgvOrigen.DefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvOrigen.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvOrigen.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            this.dgvOrigen.ItemsPerPage = 4;
            this.dgvOrigen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrigen.MultiSelect = false;
            this.dgvOrigen.AllowUserToAddRows = false;
            this.dgvOrigen.AllowUserToDeleteRows = false;

            this.dgvDestino.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvDestino.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dgvDestino.DefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvDestino.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvDestino.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            this.dgvDestino.ItemsPerPage = 5;
            this.dgvDestino.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDestino.MultiSelect = false;
            this.dgvDestino.AllowUserToAddRows = false;
            this.dgvDestino.AllowUserToDeleteRows = true;

            //if (this.dgvOrigen.Rows.Count > 0)
            //{
            //    this.FormatearGrillaOrigen();
            //    this.SetFirstVisibleColumnOrigen();
            //}

            //if (this.dgvDestino.Rows.Count > 0)
            //{
            //    this.FormatearGrillaDestino();
            //    this.SetFirstVisibleColumnDestino();
            //}
        }

        private void MarcarTodo(bool marcar)
        {
            foreach (DataGridViewRow row in this.dgvOrigen.Rows)
            {
                if (row.Visible)
                    row.Cells[0].Value = marcar;
            }
        }


        #endregion Métodos Privados

        private void FSeleccionarGrilla_VisibleChanged(object sender, EventArgs e)
        {
            this.FormatearGrillas();

            if (this.dgvOrigen.Rows.Count > 0)
                this.FormatearGrillaOrigen();
            if (this.dgvDestino.Rows.Count > 0)
                this.FormatearGrillaDestino();
        }

        public virtual void btnAgregarSeleccion_Click(object sender, EventArgs e)
        {
            //Se debe implementar en el formulario heredado
        }

        private void tSMIBorrar_Click(object sender, EventArgs e)
        {
            this.btnEliminarTodo.PerformClick();
        }

        private void dgvDestino_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (this.TituloDestinoString != String.Empty)
                this.TituloGrillaDestino = String.Format(this.TituloDestinoString, this.dgvDestino.Rows.Count.ToString());
        }

        private void btnEliminarTodo_Click(object sender, EventArgs e)
        {
            this.dgvDestino.DataSource = null;
        }

        protected virtual void btnEliminarSeleccion_Click(object sender, EventArgs e)
        {
            if (this.dgvDestino.CurrentRow != null)
            {
                this.dgvDestino.Rows.RemoveAt(this.dgvDestino.CurrentRow.Index);
            }
        }

        private void FSeleccionarGrilla_Load(object sender, EventArgs e)
        {
            this.FormatearGrillas();
        }

        private void btnFiltrar_Click_1(object sender, EventArgs e)
        {

        }

        

        
    }
}