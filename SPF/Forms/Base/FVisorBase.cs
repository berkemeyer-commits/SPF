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

namespace SPF.Forms.Base
{
    public partial class FVisorBase : Form
    {
        #region Propiedades
        public string Info
        {
            set { this.rtxtData.Text = value; }
            get { return this.rtxtData.Text; }
        }

        public bool Editable
        {
            set { this.rtxtData.ReadOnly = value; }
        }

        public string Titulo
        {
            set { this.Text = value; }
            get { return this.Text; }
        }
        #endregion Propiedades

        public FVisorBase()
        {
            InitializeComponent();
            this.rtxtData.ReadOnly = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //if (this.txtSearhbox.Text != "")
            //{
            //    int index = 0;
            //    string temp = this.rtxtData.Text;
            //    this.rtxtData.Text = "";
            //    this.rtxtData.Text = temp;

            //    while (index < this.rtxtData.Text.LastIndexOf(this.txtSearhbox.Text))
            //    {
            //        this.rtxtData.
            //        // Searches the text in a RichTextBox control for a string within a range of text withing the control and with specific options applied to the search.
            //        this.rtxtData.Find(this.txtSearhbox.Text, index, this.rtxtData.TextLength, RichTextBoxFinds.None);
            //        // Selection Color. This is added automatically when a match is found.
            //        
            //        // After a match is found the index is increased so the search won't stop at the same match again. This makes possible to highlight same words at the same time.
            //        index = this.rtxtData.Text.IndexOf(this.txtSearhbox.Text, index) + 1;
            //    }
            //}
            this.rtxtData.SelectedIndicator = true;
            //this.rtxtDat
            this.rtxtData.SelectionStart = Convert.ToInt32(this.txtSearhbox.Text.Split('-')[0]);
            this.rtxtData.SelectionLength = Convert.ToInt32(this.txtSearhbox.Text.Split('-')[1]);

  
        }


    }
}