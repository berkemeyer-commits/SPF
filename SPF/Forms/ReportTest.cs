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

using ModelEF6;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Reporting.WebForms;

#endregion

namespace SPF.Forms
{
    public partial class ReportTest : Form
    {
        private string mstrReportPath = "";
        private Boolean mblnReset = false;

        public ReportTest()
        {
            InitializeComponent();
        }

        private void ReportTest_Load(object sender, EventArgs e)
        {
            mstrReportPath = @"C:\Apps\SCCFCC\SCCFCC\SCCFCC\Reportes\TestReport.rdlc";
            mblnReset = true;
        }

        private void RV_HostedPageLoad(object sender, Gizmox.WebGUI.Forms.Hosts.AspPageEventArgs e)
        {
            if (mblnReset)
            {
                this.mblnReset = false;
                this.RV.Reset();

                this.RV.LocalReport.DataSources.Clear();
                ReportDataSource datasource;
                using (var db = new BerkeDBEntities())
                {
                    var query = db.mn_menu.Where(b => b.mn_activo == true).OrderBy(b => b.mn_nivel).ThenBy(b => b.mn_orden);
                    datasource = new ReportDataSource("DataSet1", query.ToList());
                }

                this.RV.LocalReport.DataSources.Add(datasource);
            }

            this.RV.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            this.RV.LocalReport.ReportPath = mstrReportPath;
        }
    }
}