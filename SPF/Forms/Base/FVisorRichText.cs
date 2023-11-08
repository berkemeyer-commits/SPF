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
    public partial class FVisorRichText : Form
    {
        public FVisorRichText()
        {
            InitializeComponent();
        }

        public FVisorRichText(string rtf)
        {
            InitializeComponent();
            this.richTextBox1.Text = rtf;
            this.richTextBox1.Update();
        }
    }
}