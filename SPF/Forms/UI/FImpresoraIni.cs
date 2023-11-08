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
    public partial class FImpresoraIni : Form
    {
        public FImpresoraIni()
        {
            InitializeComponent();
            this.CloseBox = false;
            this.MinimizeBox = false;
        }

        public void SetMessage(int status = 0)
        {
            if (status == 0)
                this.lblMensaje.Text = "Aguarde, iniciando servicio de impresora...";
            else
                this.lblMensaje.Text = "Servicio de Impresora... Listo.";
        }
    }
}