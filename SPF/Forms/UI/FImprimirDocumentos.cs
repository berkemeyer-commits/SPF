#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Gateways;

using ModelEF6;
using SPF.Forms.Base;
using SPF.Types;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.ObjectModel;
using System.Transactions;
using Microsoft.Reporting.WebForms;
#endregion

namespace SPF.Forms.UI
{
    public partial class FImprimirDocumentos : Form
    {
        #region Variables Globales
        BerkeDBEntities DBContext;
        FImpresoraIni fImpresoraIni;
        #endregion Variables Globales

        public FImprimirDocumentos()
        {
            InitializeComponent();
        }

        public FImprimirDocumentos(string titulo, BerkeDBEntities context)
        {
            InitializeComponent();
            this.DBContext = context;
        }

        private void FImprimirDocumentos_Load(object sender, EventArgs e)
        {
            this.label1.Text = "0";
            string path = VWGContext.Current.Server.MapPath(@"\Scripts\Printing\dist\printing_page.html");
            string html = System.IO.File.ReadAllText(@path);
            string jsPathDeployJava = Context.HttpContext.Request.Url.Scheme + "://" + Context.HttpContext.Request.Url.Authority
                                                                   + Context.HttpContext.Request.ApplicationPath
                                                                   + @"/Scripts/Printing/dist";
            html = html.Replace("#deployJava#", jsPathDeployJava);

            string jsPathIncludeJS = Context.HttpContext.Request.Url.Scheme + "://" + Context.HttpContext.Request.Url.Authority
                                                                   + Context.HttpContext.Request.ApplicationPath
                                                                   + @"/Scripts";
            html = html.Replace("#includeJS#", jsPathIncludeJS);

            htmbApplet.Html = html;
            htmbApplet.Update();

            //this.label1.Text = this.htmbApplet.ID.ToString();
            this.CheckPrinterStatus();
        }

        private void CheckPrinterStatus()
        {
            fImpresoraIni = new FImpresoraIni();
            fImpresoraIni.FormClosed += delegate { fImpresoraIni = null; };
            fImpresoraIni.SetMessage();
            fImpresoraIni.ShowDialog();
            
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string strScript = "document.getElementById(\"TRG_"
                                + this.htmbApplet.ID.ToString()
                                + "\").contentWindow.findPrinters();";
            VWGClientContext.Current.Invoke(this, "eval", strScript);
        }

        protected override void FireEvent(Gizmox.WebGUI.Common.Interfaces.IEvent objEvent)
        {
            //Condition, which catch our client custom event
            if (objEvent.Type == "printerStatus")
            {
                //Getting parameters from client side
                string statusValue = objEvent["statusValue"];

                this.label1.Text = statusValue;

                if (Convert.ToInt32(statusValue) == 1)
                {
                    fImpresoraIni.SetMessage(1);
                    Thread.Sleep(1500);
                    fImpresoraIni.Close();
                }
            }
            else
            {
                base.FireEvent(objEvent);
            }
        }

        private void htmbApplet_Click(object sender, EventArgs e)
        {

        }
    }
}