#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Security.Principal;
using System.Collections;
using System.Reflection;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using ModelEF6;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.Reporting.WebForms;
using SPF.Classes;

using Berke.Libs.Boletin.Libs;

#endregion

namespace SPF.UserControls
{
    public partial class ucReport : UserControl
    {
        #region Propiedades
        public string ReportFileSource
        {
            set { this.mstrReportPath = value; }
            get { return this.mstrReportPath; }
        }

        public string ReportDisplayName
        {
            set { this.mstrReportDisplayName = value; }
            get { return this.mstrReportDisplayName; }
        }

        public ReportDataSource ReportDataSource
        {
            set { this.datasource = value; }
            get { return this.datasource; }
        }

        public List<ReportDataSource> ListReportDataSource
        {
            set { this.listDatasource = value; }
            get { return this.listDatasource; }
        }

        public Gizmox.WebGUI.Reporting.ReportViewer Report
        {
            get { return this.RV; }
        }

        public string RVClientID
        {
            get { return this.RV.ClientId; }
        }

        public bool SoloImpresion
        {
            set { this.soloImpresion = value; }
            get { return this.soloImpresion; } 
        }

        public bool SoloPDF
        {
            set { this.soloPDF = value; }
            get { return this.soloPDF; }
        }

        public bool SoloExportarExcel
        {
            set { this.soloExportarExcel = value; }
            get { return this.soloExportarExcel; }
        }

        public List<ReportParameter> ReportParameters
        {
            set { this.listParameters = value; }
            get { return this.listParameters; }
        }
        #endregion Propiedades

        #region Constantes
        private const string LOCALHOST = "localhost";
        #endregion Constantes

        private string mstrReportPath = "";
        private string mstrReportDisplayName = "";
        private Boolean mblnReset = false;
        private bool soloImpresion = false;
        private bool soloPDF = false;
        private bool soloExportarExcel = false;
        private ReportDataSource datasource = null;
        private List<ReportDataSource> listDatasource = null;
        private List<ReportParameter> listParameters = null;

        public ucReport()
        {
            InitializeComponent();
        }

        public ucReport(string Titulo = "", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();
        }

        private void ucReportTest_Load(object sender, EventArgs e)
        {
            //mstrReportPath = @"Reportes\TestReport.rdlc";
            mblnReset = true;
            //this.RV.AutoScroll = true;
        }

        private void RV_HostedPageLoad(object sender, Gizmox.WebGUI.Forms.Hosts.AspPageEventArgs e)
        {
            if (mblnReset)
            {
                this.mblnReset = false;
                this.RV.Reset();

                if (this.SoloPDF)
                {
                    this.DisableRenderExtension("WORDOPENXML");
                    this.DisableRenderExtension("EXCELOPENXML");
                }

                if (this.SoloImpresion)
                {
                    this.DisableRenderExtension("WORDOPENXML");
                    this.DisableRenderExtension("PDF");
                    this.DisableRenderExtension("EXCELOPENXML");
                }

                if (this.SoloExportarExcel)
                {
                    this.DisableRenderExtension("WORDOPENXML");
                    this.DisableRenderExtension("PDF");
                    this.DisableRenderExtension("EXCELOPENXML");
                    this.EnableRenderExtension("Excel");
                }

                this.RV.LocalReport.DataSources.Clear();
                //ReportDataSource datasource;
                //using (var db = new BerkeDBEntities())
                //{
                //    var query = db.mn_menu.Where(b => b.mn_activo == true).OrderBy(b => b.mn_nivel).ThenBy(b => b.mn_orden);
                //    datasource = new ReportDataSource("DataSet1", query.ToList());
                //}

                //this.RV.LocalReport.DataSources.Add(datasource);
                if ((this.ListReportDataSource != null) && (this.ListReportDataSource.Count > 0))
                {
                    foreach (ReportDataSource rpt in this.ListReportDataSource)
                    {
                        this.RV.LocalReport.DataSources.Add(rpt);
                    }
                }
                else
                    this.RV.LocalReport.DataSources.Add(this.ReportDataSource);

                this.RV.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                this.RV.LocalReport.ReportPath = this.ReportFileSource;
                this.RV.LocalReport.DisplayName = this.ReportDisplayName;

                if (this.ReportParameters != null)
                    this.RV.LocalReport.SetParameters(this.ReportParameters);
            }

            //this.RV.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            //this.RV.LocalReport.ReportPath = this.ReportFileSource;
            //this.RV.LocalReport.DisplayName = this.ReportDisplayName;
        }

        public void SendAsMail(string from, string to, string cc, string bcc, string smtpServer,
                               string format = "PDF,pdf", string fileName = "Reporte", string asuntoMail = "Reporte del SPF",
                               string cuerpoMail = "Por favor revise el archivo adjunto.", string smtp_port = "587")
        {
            string[] frmext = format.Split(',');

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            if (frmext[0] == "HTML")
            {
                EnableRenderExtension("HTML4.0");
                frmext[0] = "Word";
            }
            
            byte[] bytes = this.RV.LocalReport.Render(frmext[0], null, out mimeType, out encoding, out extension, out 
                                                      streamids, out warnings);

            MemoryStream memoryStream = null;
            MailMessage message = new MailMessage();

            if (frmext[1] != "html")
            {
                memoryStream = new MemoryStream(bytes);
                memoryStream.Seek(0, SeekOrigin.Begin);
                Attachment attachment = new Attachment(memoryStream, fileName + "." + frmext[1]);
                message.Attachments.Add(attachment);
            }

            #region Manejo de Destinatarios
            if (from != "")
            {
                //from = "Notificaciones@berke.com.py";
                message.From = new MailAddress(from);
                message.ReplyToList.Add(new MailAddress(from));
            }

            if (to != "")
            {
                string[] tos = (to.Replace(';', ',')).Split(','); ;
                foreach (string subTo in tos)
                {
                    message.To.Add(new MailAddress(subTo));
                }
            }

            if (cc != "")
            {
                string[] ccs = (cc.Replace(';', ',')).Split(','); ;
                foreach (string subCC in ccs)
                {
                    message.CC.Add(new MailAddress(subCC));
                }
            }

            if (bcc != "")
            {
                string[] bccs = (bcc.Replace(';', ',')).Split(','); ;
                foreach (string subBCC in bccs)
                {
                    message.Bcc.Add(new MailAddress(subBCC));
                }
            }
            #endregion Manejo de Destinatarios
            //message.From = new MailAddress("Gustavo.Galeano@berke.com.py");
            //message.To.Add("ggaleano.py@gmail.com");         
           
            //message.CC.Add("ggaleano.py@gmail.com");

            message.Subject = asuntoMail;
            message.IsBodyHtml = true;

            if (frmext[1] != "html")
                message.Body = cuerpoMail.Replace(Environment.NewLine, "<br>");
            else
                message.Body = this.getHTML(bytes);


            //SmtpClient smtp = new SmtpClient(smtpServer);
            //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtp.UseDefaultCredentials = false;
            //smtp.Credentials = CredentialCache.DefaultNetworkCredentials;
            //smtp.Send(message);

            //Para SMTP de Office365
            SmtpClient smtpClient = new SmtpClient(smtpServer, Convert.ToInt32(smtp_port));
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;

            smtpClient.UseDefaultCredentials = false;

            string username = VWGContext.Current.Session["EmailUsuario"].ToString();
            string password = this.decryptPasswd();
            smtpClient.Credentials = new NetworkCredential(username, password);

            try
            {
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error [SendMailThrowSMTP] " + ex.ToString());
            }
        }

        private string decryptPasswd()
        {
            string Result = string.Empty;
            int usuarioID = Convert.ToInt32(VWGContext.Current.Session["UsuarioID"].ToString());

            SPF.Classes.Encrypt_Decrypt decrypt = new SPF.Classes.Encrypt_Decrypt();

            using (BerkeDBEntities context = new BerkeDBEntities())
            {
                Result = decrypt.DecryptString(context.Usuario.FirstOrDefault(a => a.ID == usuarioID).PasswordEmail);
            }

            return Result;
        }

        private string getHTML(byte [] wordFile)
        {
            
            string fileName = WindowsIdentity.GetCurrent().User + System.DateTime.Now.Ticks.ToString();
            string fileNameWord = Context.Server.MapPath("~/Temp/") + fileName + ".doc";
            string fileNameHTML = Context.Server.MapPath("~/Temp/") + fileName + ".html";

            File.WriteAllBytes(fileNameWord, wordFile);

            WordLibs w = new WordLibs();
            w.agregarDocumento(fileNameWord);
            w.guardarComoHTML();
            w.cerrarDocumento();
            w.cerrarWord();
            
            string htmlFileContent = File.ReadAllText(fileNameHTML);

            File.Delete(fileNameWord);
            File.Delete(fileNameHTML);
            
            return htmlFileContent;
        }

        private void convertDoc2HTML(string fileNameWord, string fileNameHTML, byte [] wordFile)
        {
            
        }

        protected virtual bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        private IList RenderingExtensions
        {
            get
            {
                var service = this.RV.LocalReport
                    .GetType()
                    .GetField("m_previewService",
                BindingFlags.NonPublic | BindingFlags.Instance)
                    .GetValue(this.RV.LocalReport);

                var extensions = service
                    .GetType()
                    .GetMethod("ListRenderingExtensions")
                    .Invoke(service, null);

                return (IList)extensions;
            }
        }

        private void EnableRenderExtension(string extensionName)
        {
            //RenderingExtension[] renderingExtList = this.RV.LocalReport.ListRenderingExtensions();
            

            foreach (var extension in this.RV.LocalReport.ListRenderingExtensions())
            {
                // name = extension.Name;
                var name = extension
                    .GetType()
                    .GetProperty("Name")
                    .GetValue(extension, null)
                    .ToString();

                if (name == extensionName)
                {
                    // extension.m_isVisible = true;
                    extension
                        .GetType()
                        .GetField("m_isVisible",
                    BindingFlags.NonPublic | BindingFlags.Instance)
                        .SetValue(extension, true);

                    // extension.m_isExposedExternally = true;
                    /*
                     * 03/10/2023 Exportacion a Starsoft
                    extension
                        .GetType()
                        .GetField("m_isExposedExternally",
                    BindingFlags.NonPublic | BindingFlags.Instance)
                        .SetValue(extension, true);*/

                    // extension.m_localizedName = localizedExtensionName;
                    //extension
                    //    .GetType()
                    //    .GetField("m_localizedName",
                    //BindingFlags.NonPublic | BindingFlags.Instance)
                    //    .SetValue(extension, localizedExtensionName);
                }
            }
        }

        public void DisableRenderExtension(string extensionName)
        {
            //RenderingExtension[] renderingExtList = this.RV.LocalReport.ListRenderingExtensions();


            foreach (var extension in this.RV.LocalReport.ListRenderingExtensions())
            {
                // name = extension.Name;
                var name = extension
                    .GetType()
                    .GetProperty("Name")
                    .GetValue(extension, null)
                    .ToString();

                if (name == extensionName)
                {
                    // extension.m_isVisible = true;
                    extension
                        .GetType()
                        .GetField("m_isVisible",
                    BindingFlags.NonPublic | BindingFlags.Instance)
                        .SetValue(extension, false);

                    // extension.m_isExposedExternally = true;
                    //extension
                    //    .GetType()
                    //    .GetField("m_isExposedExternally",
                    //BindingFlags.NonPublic | BindingFlags.Instance)
                    //    .SetValue(extension, false);

                    // extension.m_localizedName = localizedExtensionName;
                    //extension
                    //    .GetType()
                    //    .GetField("m_localizedName",
                    //BindingFlags.NonPublic | BindingFlags.Instance)
                    //    .SetValue(extension, localizedExtensionName);
                }
            }
        }

        public string PrintReport()
        {
            const string PDF = "pdf";
            //const string HTML = "html";
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            byte[] bytes = this.RV.LocalReport.Render(PDF, null, out mimeType, out encoding, out extension, out 
                                                      streamids, out warnings);
            string specialpath = Context.HttpContext.Request.Url.Authority.IndexOf(LOCALHOST) > -1 ? String.Empty : @"\" + Context.HttpContext.Request.ApplicationPath;
            string path = VWGContext.Current.Server.MapPath(specialpath +
                                                            @"\Resources\UserData\" + VWGContext.Current.Session["WindowsUser"].ToString() + @"\");
            Berke.Libs.Base.Helpers.Files.CreateDirectory(@path);
            string fileName = "Reportes-" + DateTime.Now.Ticks.ToString() + ".pdf";
            string saveFileName = @path + @fileName;
            Berke.Libs.Base.Helpers.Files.SaveBytesToFile(bytes, @saveFileName);
            
            return @fileName;
            
        }
    }
}