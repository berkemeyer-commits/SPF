using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.IO;

namespace UploadFile
{
    public partial class UploadFile : System.Web.UI.Page
    {
        #region Constantes
        private const String ACTION_UPLOAD = "U";
        private const String ACTION_UPLOAD_SAVE = "US";
        #endregion Constantes
        #region Variables
        private String folderParam = String.Empty;
        private String filenameParam = String.Empty;
        private String parentElementIdVal = String.Empty;
        private String actionParam = String.Empty;
        private String extensionParam = String.Empty;
        #endregion Variables

        #region Propiedades
        protected String FolderParam
        {
            set { this.folderParam = value; }
            get { return this.folderParam; }
        }
        protected String FilenameParam
        {
            set { this.filenameParam = value; }
            get { return this.filenameParam; }
        }
        protected String ParentElementParam
        {
            set { this.parentElementIdVal = value; }
            get { return this.parentElementIdVal; }
        }
        protected String ActionParam
        {
            set { this.actionParam = value != null ? value.ToUpper() : null; }
            get { return this.actionParam; }
        }
        protected String ExtensionParam
        {
            set { this.extensionParam = value != null ? value.ToUpper() : null; }
            get { return this.extensionParam; }
        }
        #endregion Propiedades

        protected void Page_Load(object sender, EventArgs e)
        {
            this.FolderParam = Request.QueryString["folder"];
            this.FilenameParam = Request.QueryString["filename"];
            this.ParentElementParam = Request.QueryString["parentElementId"];
            this.ActionParam = Request.QueryString["action"];
            this.ExtensionParam = Request.QueryString["extension"];

            this.parentElementId.Value = this.ParentElementParam;
            this.action.Value = this.ActionParam;

            this.File1.Accept = this.ExtensionParam;
        }

        protected void Submit1_ServerClick(object sender, EventArgs e)
        {
            if ((File1.PostedFile != null) && (File1.PostedFile.ContentLength > 0))
            {
                //string fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
                //string SaveLocation = Server.MapPath("Data") + "\\" + fn;
                string SaveLocation = WebConfigurationManager.AppSettings["dataFolderPath"] + this.FolderParam;
                try
                {
                    if (!Directory.Exists(SaveLocation))
                    {
                        Directory.CreateDirectory(SaveLocation);
                    }

                    SaveLocation += "\\" + this.FilenameParam + "-" + Path.GetExtension(File1.PostedFile.FileName).Replace(".", "") + ".upload";
                    File1.PostedFile.SaveAs(SaveLocation);
                    //Response.Write("The file has been uploaded.");

                    this.uploadedFilePath.Value = SaveLocation + "_#_" + File1.PostedFile.FileName;

                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Click", "processFile()", true);

                    //if (this.ActionParam == ACTION_UPLOAD_SAVE)
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Click", "btnCloseClick()", true);
                    //}

                    this.HandleParagraph(false);
                    
                }
                catch (Exception ex)
                {
                    //Response.Write("Error: " + ex.Message);
                    this.HandleParagraph(true, "Error: " + ex.Message);
                    //Note: Exception.Message returns a detailed message that describes the current exception. 
                    //For security reasons, we do not recommend that you return Exception.Message to end users in 
                    //production environments. It would be better to put a generic error message. 
                }
            }
            else
            {
                //Response.Write("Please select a file to upload.");
                this.HandleParagraph(true);
            }
        }

        private void HandleParagraph(Boolean hasError, String errMsg = "Debe seleccionar un archivo para procesar.")
        {
            this.okParagraph.Visible = !hasError;
            this.errorParagraph.Visible = hasError;

            if (hasError)
            {
                this.errorParagraph.InnerText = errMsg;
            }
        }
    }
}