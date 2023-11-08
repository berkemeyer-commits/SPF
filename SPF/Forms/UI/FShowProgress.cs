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
    public partial class FShowProgress : Form
    {
        int pValue = 0;
        public FShowProgress()
        {
            InitializeComponent();

            //this.timer1.Tick += timer1_Tick;
            //this.timer1.Interval = 1000;

            //progressBar1.Maximum = 100;
            //progressBar1.Step = 1;
            //progressBar1.Value = 0;

            //for (int i = 0; i < 100; i++)
            //{
            //    progressBar1.Value = i;
            //    System.Threading.Thread.Sleep(1000);
            //}
        }

        //private void FShowProgress_Load(object sender, EventArgs e)
        //{
        //    this.timer1.Start();
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (pValue == 100)
            //    pValue = 0;
            //else pValue = pValue + 10;

            //progressBar1.Value = pValue;
        }

        //private void FShowProgress_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    this.timer1.Stop();
        //}
    }
}