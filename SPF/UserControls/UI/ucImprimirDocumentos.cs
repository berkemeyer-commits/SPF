#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Gateways;

using ModelEF6;
using SPF.Types;
using SPF.Forms.Base;
using SPF.Forms.UI;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.ObjectModel;

#endregion

namespace SPF.UserControls.UI
{
    public partial class ucImprimirDocumentos : ucBaseForm
    {
        #region Variables Globales
        private FImpresoraIni fImpresoraIni;
        private string listaImpresoras = String.Empty;
        private string defaultPrinter = String.Empty;
        #endregion Variables Globales

        #region Propiedades
        public string ListaImpresoras
        {
            get { return this.listaImpresoras; }
            set { this.listaImpresoras = value; }
        }

        public string DefaultPrinter
        {
            get { return this.defaultPrinter; }
            set { this.defaultPrinter = value; }
        }
        #endregion Propiedades

        #region Métodos de Inicio
        public ucImprimirDocumentos()
        {
            InitializeComponent();
        }

        public ucImprimirDocumentos(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();
            this.DBContext = dbContext;
            this.Titulo = Titulo;
        }

        private void ucImprimirDocumentos_Load(object sender, EventArgs e)
        {
            //this.tabListaABM.SelectedIndex = 1;
            
            this.tbbImpresoraSelec.Visible = false;

            this.label1.Text = "0";
            //string path = VWGContext.Current.Server.MapPath(@"\Scripts\Printing\dist\printing_page.html");
            ////string path = VWGContext.Current.Server.MapPath(@"\Scripts\Printing\dist\sample-copia.html");
            //string html = System.IO.File.ReadAllText(@path);
            string jsPathDeployJava = Context.HttpContext.Request.Url.Scheme + "://" + Context.HttpContext.Request.Url.Authority
                                                                   + Context.HttpContext.Request.ApplicationPath
                                                                   + @"/Scripts/Printing/dist";

            VWGClientContext.Current.Invoke("deployQZ", jsPathDeployJava);

            //html = html.Replace("#deployJava#", jsPathDeployJava);

            //string jsPathIncludeJS = Context.HttpContext.Request.Url.Scheme + "://" + Context.HttpContext.Request.Url.Authority
            //                                                       + Context.HttpContext.Request.ApplicationPath
            //                                                       + @"/Scripts";
            //html = html.Replace("#includeJS#", jsPathIncludeJS);

            //htmbApplet.Html = html;
            //htmbApplet.Update();

            ////this.label1.Text = this.htmbApplet.ID.ToString();
            //this.CheckPrinterStatus();
        }
        #endregion Métodos de Inicio

        private void CheckPrinterStatus()
        {
            fImpresoraIni = new FImpresoraIni();
            fImpresoraIni.FormClosed += delegate { fImpresoraIni = null;
                                                   string strScript = "document.getElementById(\"TRG_"
                                                                        + this.htmbApplet.ID.ToString()
                                                                        + "\").contentWindow.useDefaultPrinter1();";
                                                   VWGClientContext.Current.Invoke(this, "eval", strScript); };
            fImpresoraIni.SetMessage();
            fImpresoraIni.ShowDialog();

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string strScript = "document.getElementById(\"TRG_"
                                + this.htmbApplet.ID.ToString()
                                + "\").contentWindow.useDefaultPrinter1();";
            VWGClientContext.Current.Invoke(this, "eval", strScript);
            MessageBox.Show(this.DefaultPrinter);
        }

        protected override void FireEvent(Gizmox.WebGUI.Common.Interfaces.IEvent objEvent)
        {
            //Condition, which catch our client custom event
            if (objEvent.Type == "printerStatus")
            {
                //Getting parameters from client side
                string statusValue = objEvent["statusValue"];

                if ((Convert.ToInt32(statusValue) == 1) && (fImpresoraIni != null))
                {
                    //Cerrar Ventana de Estado
                    //fImpresoraIni.SetMessage(1);
                    //Thread.Sleep(1500);
                    fImpresoraIni.Close();
                    //string strScript = "document.getElementById(\"TRG_"
                    //            + this.htmbApplet.ID.ToString()
                    //            + "\").contentWindow.useDefaultPrinter1();";
                    //VWGClientContext.Current.Invoke(this, "eval", strScript);
                }
            }
            else if (objEvent.Type == "printersList")
            {
                //Getting parameters from client side
                string printers = objEvent["printers"];
                this.ListaImpresoras = printers;
                this.FillDropDownList();
            }
            else if (objEvent.Type == "defaultPrinter")
            {
                //Getting parameters from client side
                string printer = objEvent["printer"];
                this.DefaultPrinter = printer;
                //this.tbbImpresoraSelec.Text = this.DefaultPrinter;
                this.tbbDDPrinters.Text = this.DefaultPrinter;
            }
            else
            {
                base.FireEvent(objEvent);
            }
        }

        private void FillDropDownList()
        {
            if (this.ListaImpresoras != String.Empty)
            {
                ContextMenu ctxMenu = new ContextMenu();
                
                foreach (string printer in this.ListaImpresoras.Split(','))
                {
                    ctxMenu.MenuItems.Add(new MenuItem(printer, this.menuItem_Click));
                }
                
                this.tbbDDPrinters.DropDownMenu = ctxMenu;
                //string strScript = "document.getElementById(\"TRG_"
                //                + this.htmbApplet.ID.ToString()
                //                + "\").contentWindow.useDefaultPrinter1();";
                //VWGClientContext.Current.Invoke(this, "eval", strScript);
            }
        }

        private void menuItem_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            this.tbbImpresoraSelec.Text = menuItem.Text;
        }

        private void tbbDDPrinters_Click(object sender, EventArgs e)
        {
            string strScript = "document.getElementById(\"TRG_"
                            + this.htmbApplet.ID.ToString()
                            + "\").contentWindow.findPrinters1();";
            VWGClientContext.Current.Invoke(this, "eval", strScript);
        }

    }


}
