using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPF.Base
{
    public class ReportWrapper : Gizmox.WebGUI.Reporting.ReportViewer
    {
        /// 
        /// Set OverFlow = auto on the html representation of the wrapped control
        /// 
        /// "sender">
        /// "e">
        protected override void OnHostedControlPreRender(object sender, EventArgs e)
        {
            ((Microsoft.Reporting.WebForms.ReportViewer)this.HostedControl).Style.Add("overflow", "auto");

            base.OnHostedControlPreRender(sender, e);

        }

        /// 
        /// AutoScroll set to false, we are controlling the autoscroll
        /// 
        //public override bool AutoScroll
        //{
        //    get
        //    {
        //        return false;
        //    }
        //}
    }
}