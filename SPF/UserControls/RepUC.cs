#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace SCCFCC
{
    public partial class RepUC : UserControl
    {
        private string mstrPath = "";
        private Boolean mblnReset = false;

        public RepUC()
        {
            InitializeComponent();
        }

        public void ShowReport(string strReport)
        {
            mstrPath = strReport;
            mblnReset = true;
            RV.Update();
        }

        private void RV_HostedPageLoad(object sender, Gizmox.WebGUI.Forms.Hosts.AspPageEventArgs e)
        {
            if (mblnReset)
            {
                mblnReset = false;
                RV.Reset();
            }
            RV.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            RV.LocalReport.ReportPath = mstrPath;
        }
    }
}