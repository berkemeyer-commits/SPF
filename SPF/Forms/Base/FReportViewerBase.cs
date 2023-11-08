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

using Microsoft.Reporting.WebForms;
using SPF.Forms.UI;
using ModelEF6;

#endregion

namespace SPF.Forms.Base
{
    public partial class FReportViewerBase : Form
    {

        #region Propiedades
        public string Titulo
        {
            get { return this.Text; }
            set { this.Text = value; }
        }

        public string NombreArchivoAdjunto
        {
            set { this.fileName = value; }
            get { return this.fileName; }
        }

        public string AsuntoMail
        {
            set { this.asuntoMail = value; }
            get { return this.asuntoMail != "" ? this.asuntoMail : "Enviando Reporte del SPF"; }
        }

        public string CuerpoMail
        {
            set { this.cuerpoMail = value; }
            get { return this.cuerpoMail != "" ? this.cuerpoMail : "Por favor revise el documento adjunto."; }
        }

        public int Idioma
        {
            set { this.idioma = value; }
            get { return this.idioma; }
        }

        public string CantidadRegistros
        {
            set { this.lblRegistros.Text = value; }
            get { return this.lblRegistros.Text; }
        }

        #endregion Propiedades

        #region Variables
        private string asuntoMail = "";
        private string cuerpoMail = "";
        private string fileName = "";
        private int idioma = -1;
        BerkeDBEntities DBContext;
        FDatosMailing fDatosMailing;
        private string fileNamePDF = String.Empty;
        #endregion Variables

        #region Constantes
        private const string SMTP = "SMTP";
        private const string SMTP_PORT = "SMTP_PORT";
        private const string IDIOMA_ESPANOL = "2";
        private const string PDF_IMPRESION_URL = "file://{0}";
        private const string PDF_IMPRESION_TITULO = "Imprimir - {0}";
        private const string IE_BROWSER = "InternetExplorer";
        private const string LOCALHOST = "localhost";
        #endregion Constantes
        
        public FReportViewerBase()
        {
            InitializeComponent();
        }

        public FReportViewerBase(string rptPath, ReportDataSource rptDS, BerkeDBEntities context, List<ReportParameter> rptParams)
        {
            InitializeComponent();
            this.ucReport1.ReportFileSource = rptPath;
            this.ucReport1.ReportDataSource = rptDS;

            this.ucReport1.ReportParameters = rptParams;

            this.DBContext = context;
            this.lblRegistros.Text = "";

            this.btnImprimir.Visible = Context.HttpContext.Request.Browser.Browser != IE_BROWSER;
        }

        public FReportViewerBase(string rptPath, ReportDataSource rptDS, BerkeDBEntities context = null)
        {
            InitializeComponent();
            this.ucReport1.ReportFileSource = rptPath;
            this.ucReport1.ReportDataSource = rptDS;

            this.DBContext = context;
            this.lblRegistros.Text = "";

            this.btnImprimir.Visible = Context.HttpContext.Request.Browser.Browser != IE_BROWSER;
        }

        public FReportViewerBase(string rptPath, List<ReportDataSource> rptDS, BerkeDBEntities context = null)
        {
            InitializeComponent();
            this.ucReport1.ReportFileSource = rptPath;
            this.ucReport1.ListReportDataSource = rptDS;
            this.DBContext = context;
            this.lblRegistros.Text = "";

            this.btnImprimir.Visible = Context.HttpContext.Request.Browser.Browser != IE_BROWSER;
        }

        public FReportViewerBase(string rptPath, ReportDataSource rptDS, BerkeDBEntities context = null, string reportDisplayName = "", bool soloImpresion = false, bool soloPDF = false)
        {
            InitializeComponent();
            this.ucReport1.SoloImpresion = soloImpresion;
            this.ucReport1.SoloPDF = soloPDF;
            this.ucReport1.ReportFileSource = rptPath;
            this.ucReport1.ReportDataSource = rptDS;
            this.DBContext = context;
            this.lblRegistros.Text = "";
            this.ucReport1.ReportDisplayName = reportDisplayName;

            this.btnImprimir.Visible = Context.HttpContext.Request.Browser.Browser != IE_BROWSER;
        }

        public FReportViewerBase(string rptPath, List<ReportDataSource> rptDS, BerkeDBEntities context = null, string reportDisplayName = "", bool soloImpresion = false, bool soloPDF = false)
        {
            InitializeComponent();
            this.ucReport1.SoloImpresion = soloImpresion;
            this.ucReport1.SoloPDF = soloPDF;
            this.ucReport1.ReportFileSource = rptPath;
            this.ucReport1.ListReportDataSource = rptDS;
            this.DBContext = context;
            this.lblRegistros.Text = "";
            this.ucReport1.ReportDisplayName = reportDisplayName;

            this.btnImprimir.Visible = Context.HttpContext.Request.Browser.Browser != IE_BROWSER;
        }

        public void SoloImpresion(bool soloImpresion = true)
        {
            this.grpEnviar.Visible = !soloImpresion;
            this.btnEnviar.Visible = !soloImpresion;
        }

        public void SoloPDF(bool soloPDF = true)
        {
            this.rbPDF.Checked = soloPDF;
            this.grpEnviar.Enabled = !soloPDF;
        }

        public void SoloExportarExcel(bool soloExportarExcel = false)
        {
            this.ucReport1.SoloExportarExcel = soloExportarExcel;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {

        }

        private void f_AceptarFiltrarClick(object sender, EventArgs e)
        {
            string subject = fDatosMailing.Subject;
            string body = fDatosMailing.Body;
            string from = fDatosMailing.From;
            string to = fDatosMailing.To;
            string cc = fDatosMailing.CC;
            string bcc = fDatosMailing.BCC;

            //pa_parametros param = this.DBContext.pa_parametros.First(a => a.clave == SMTP);
            string smtp = this.DBContext.pa_parametros.First(a => a.clave == SMTP).valor;
            string smtp_port = this.DBContext.pa_parametros.First(a => a.clave == SMTP_PORT).valor;

            if ((from == "") || (to == ""))
            {
                MessageBox.Show("Debe indicar el remitente y al menos un destinatario.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            string format = "";
            if (rbPDF.Checked)
                format = "PDF,pdf";
            else if (rbWord.Checked)
                format = "Word,doc";
            else if (rbExcel.Checked)
                format = "Excel,xls";
            else if (rbEmbebido.Checked)
                format = "HTML,html";
            try
            {
                this.ucReport1.SendAsMail(from, to, cc, bcc, smtp,
                                          format, this.NombreArchivoAdjunto, subject, body, smtp_port);
                fDatosMailing.Close();
                MessageBox.Show("E-mail enviado éxitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       private void btnEnviar_ClientClick(object objSender, Gizmox.WebGUI.Forms.Client.ClientEventArgs objArgs)
        {
            objArgs.Context.Invoke("getReportHTML");
        }


       private void enviarMail(string htmlbody = "")
       {
           if (fDatosMailing == null)
           {
               fDatosMailing = new FDatosMailing(this.DBContext);
               fDatosMailing.Subject = this.AsuntoMail;
               fDatosMailing.Body = this.CuerpoMail;
               fDatosMailing.AceptarFiltrarClick += f_AceptarFiltrarClick;
           }
           fDatosMailing.ShowDialog();

       }

       public void MostrarEnviar(bool mostrar = true)
       {
           this.grpEnviar.Visible = mostrar;
           this.btnEnviar.Visible = mostrar;
       }
       
        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(Gizmox.WebGUI.Common.Interfaces.IEvent objEvent)
        {
          //Condition, which catch our client custom event
          if(objEvent.Type == "exportReport")
          {
              //Getting parameters from client side
              string strHTMLREportBody = objEvent["htmlreportbody"];

              //if (strHTMLREportBody != "")

              this.enviarMail();
              
          }
          else { base.FireEvent(objEvent); }
        }

        private void btnImprimir_ClientClick(object objSender, Gizmox.WebGUI.Forms.Client.ClientEventArgs objArgs)
        {
            //objArgs.Context.Invoke("adentro");
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            this.fileNamePDF = this.ucReport1.PrintReport();
            string url = Context.HttpContext.Request.Url.Scheme + "://"
                         + Context.HttpContext.Request.Url.Authority
                         + Context.HttpContext.Request.ApplicationPath
                         + @"\Resources\UserData\" + VWGContext.Current.Session["WindowsUser"].ToString() + @"\"
                         + this.fileNamePDF;

            object[] jsParams = new object[4];
            jsParams[0] = url;
            jsParams[1] = String.Format(PDF_IMPRESION_TITULO, this.Titulo);
            jsParams[2] = 750;
            jsParams[3] = 600;

            VWGClientContext.Current.Invoke("PopupCenter", jsParams);
            return;
            //VWGClientContext.Current.Invoke("verDatos");            
        }

        private void FReportViewerBase_Load(object sender, EventArgs e)
        {
            this.fileNamePDF = String.Empty;
            if (this.btnImprimir.Visible)
                this.btnImprimir.Focus();
            else this.btnEnviar.Focus();
        }

        private void FReportViewerBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.fileNamePDF != String.Empty)
            {
                //System.IO.File.Delete(VWGContext.Current.Server.MapPath(@"\Resources\UserData\" + VWGContext.Current.Session["WindowsUser"].ToString() + @"\") + this.fileNamePDF);
                string specialpath = Context.HttpContext.Request.Url.Authority.IndexOf(LOCALHOST) > -1 ? String.Empty : @"\" + Context.HttpContext.Request.ApplicationPath;
                string path = VWGContext.Current.Server.MapPath(specialpath +
                                                                @"\Resources\UserData\" + VWGContext.Current.Session["WindowsUser"].ToString() + @"\");
                System.IO.File.Delete(path + this.fileNamePDF);
            }
        }       
               
    }
}