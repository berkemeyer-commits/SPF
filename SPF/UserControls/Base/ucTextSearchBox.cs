#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using SPF.Forms.Base;

using ModelEF6;
using SPF.Forms;
using SPF.Types;
using System.Data.Entity;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.EntityClient;

#endregion

namespace SPF.UserControls.Base
{
    public partial class ucTextSearchBox : UserControl
    {
        #region Propiedades
        public string KeyMember
        {
            set { this.txtID.Text = value; }
            get { return this.txtID.Text; }
        }

        public string DisplayMember
        {
            set { this.txtDescripcion.Text = value; }
            get { return this.txtDescripcion.Text; }
        }

        public int KeyMemberWidth
        {
            set
            {
                this.txtID.Width = value;
                Size nSize = new Size(value, this.pnlTextBox1.Size.Height);
                this.pnlTextBox1.Size = nSize;
            }
        }

        public bool SoloLectura
        {
            set { this.soloLectura = value; }
            get { return this.soloLectura; }
        }


        public bool Editable
        {
            set 
            {
                if (!this.SoloLectura)
                {
                    this.txtID.ReadOnly = !value;
                    this.txtID.BackColor = value ? Color.White : SystemColors.Control;
                    
                    if ((this.descripcionEditable.HasValue) && (this.descripcionEditable.Value))
                    {
                        this.txtID.ReadOnly = true;
                        this.txtID.BackColor = SystemColors.Control;

                        this.txtDescripcion.ReadOnly = !value;
                        this.txtDescripcion.BackColor = Color.White;
                    }
                    ////
                }
                else
                {
                    this.txtID.ReadOnly = true;
                    this.txtID.BackColor = SystemColors.Control;
                    //this.btnBuscar.Enabled = !value;
                    ////
                    if ((this.descripcionEditable.HasValue) && (this.descripcionEditable.Value))
                    {
                        this.txtDescripcion.ReadOnly = true;
                        this.txtDescripcion.BackColor = SystemColors.Control;
                    }
                    ////
                }
                //this.txtID.ReadOnly = !value;
                this.btnBuscar.Enabled = value;
            }
        }

        public string ToolTip
        {
            set { this.toolTip1.SetToolTip(this.btnBuscar, value); }
        }

        public string NombreCampoID
        {
            set { this.stringID = value; }
            get { return this.stringID; }
        }

        public string NombreCampoDescrip
        {
            set { this.stringDescrip = value; }
            get { return this.stringDescrip; }
        }

        public string TituloBuscador
        {
            set { this.tituloBuscador = value; }
            get { return this.tituloBuscador; }
        }

        public string LabelCampoBusqueda
        {
            set { this.campoBuscador = value; }
            get { return this.campoBuscador; }
        }

        public BerkeDBEntities DBContext
        {
            set { this.dbContext = value; }
            get { return this.dbContext; }
        }

        public string ToolTipTSB
        {
            set
            {
                this.toolTip1.SetToolTip(this.txtID, value);
                this.toolTip1.SetToolTip(this.txtDescripcion, value);
                this.toolTip1.SetToolTip(this.pnlBack, value);
            }
        }

        public bool ReadOnly
        {
            set
            {
                this.txtID.ReadOnly = value;
                this.txtID.BackColor = !value ? Color.White : SystemColors.Control;
            }
        }

        //public T SetClass
        //{
        //    set { this.claseEntidad = value; }
        //    get { return this.claseEntidad; }
        //}

        #endregion Propiedades

        #region Variables
        private string stringID = "";
        private string stringDescrip = "";
        private string tituloBuscador = "";
        private string campoBuscador = "";
        private bool soloLectura = false;
        private BerkeDBEntities dbContext;
        private Nullable<bool> descripcionEditable = null;
        #endregion Variables

        #region Eventos personalizados
        public event EventHandler AceptarClick;
        public event EventHandler KeyMemberTextChanged;
        public event EventHandler DisplayMemberLeave;
        #endregion Eventos personalizados
        public ucTextSearchBox()
        {
            InitializeComponent();
            
        }

        protected virtual void btnBuscar_Click(object sender, EventArgs e)
        {
            if (this.AceptarClick != null)
            {
                this.AceptarClick(sender, e);
            }

            //frmPickBase f = new frmPickBase();
            //f.Titulo = this.TituloBuscador;
            //f.NombreCampo = this.LabelCampoBusqueda;
            ////f.LoadData<CPais>(this.DBContext.CPais);
            //f.ShowDialog();
        }

        public void Clear()
        {
            this.txtID.Text = "";
            this.txtDescripcion.Text = "";
        }

        public void MakeDescriptionEditable(bool valor = true)
        {
            this.descripcionEditable = valor;// true;
            
            this.txtDescripcion.ReadOnly = !valor;// false;
            this.txtDescripcion.TabStop = valor;// true;
            this.txtDescripcion.BackColor = valor ? Color.White : SystemColors.Control;

            this.txtID.ReadOnly = valor;
            this.txtID.TabStop = !valor;// true;
            this.txtID.BackColor = !valor ? Color.White : SystemColors.Control;
        }

        

        //public void MakeDescriptionEditable(bool valor = true)
        //{
        //    this.descripcionEditable = valor;// true;
        //    this.txtDescripcion.ReadOnly = !valor;// false;
        //    this.txtID.TabStop = valor;// true;
        //    //this.txtID.TabIndex = 0;
        //    this.txtDescripcion.ReadOnly = !valor;// false;
        //    this.txtDescripcion.TabStop = valor;// true;
        //    //this.txtDescripcion.TabIndex = 1;
        //    //this.btnBuscar.TabIndex = 2;
        //    this.txtDescripcion.BackColor = valor ? Color.White : SystemColors.Control;
        //}

        public void SetFocus()
        {
            if (this.txtID.TabStop)
                this.txtID.Focus();
            else this.txtDescripcion.Focus();
        }

        private void ucTextSearchBox_Load(object sender, EventArgs e)
        {
            //
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            if ((this.txtID.Text == "") && (this.descripcionEditable.HasValue) && (!this.descripcionEditable.Value))
                this.txtDescripcion.Text = "";
        }

        private void txtDescripcion_Leave(object sender, EventArgs e)
        {
            if (this.txtDescripcion.Text.Trim() == String.Empty)
                this.txtID.Text = String.Empty;

            if (/*(this.txtID.Text.Trim() == String.Empty) && (this.txtDescripcion.Text.Trim() != String.Empty) && */(this.DisplayMemberLeave != null))
            {
                this.DisplayMemberLeave(sender, e);
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            this.toolTip1.SetToolTip(this.txtID, this.txtID.Text);

            if ((this.txtID.Text.Trim() == String.Empty) && (this.descripcionEditable.HasValue) && (!this.descripcionEditable.Value)) this.txtDescripcion.Text = String.Empty;

            if (this.KeyMemberTextChanged != null)
            {
                this.KeyMemberTextChanged(sender, e);
            }
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            this.toolTip1.SetToolTip(this.txtDescripcion, this.txtDescripcion.Text);            
        }

        
    }
}