using System;

using System.Web;
using System.IO;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Common.Gateways
{
    [MetadataTag("DLGW")]
    public class DownloadGateway : Gizmox.WebGUI.Forms.Control, IGatewayComponent
    {

        private string myContentType;
        private ContainerControl myContainer;
        private Stream myStream;
        private string myFilePath;
        private string myTargetFilename;
        private LinkParameters myLinkParameters = new LinkParameters();
        private bool myDownloadAsAttachment = true;

        #region C'tor
        private DownloadGateway()
        {
            // parameterless constructor not allowed
            throw new Exception("DownloadGateway does not support parameterless constructor");
        }

        /// <summary>
        /// Constructor when downloading a physical file.
        /// File must be accessible from the worker process, but does not need to be on any particular folder
        /// Full physical path to the filename must be in the parameter.
        /// Content type for the data will be based on the extension of the filename and is retrieved from
        /// the server's registry, defaulting to "application/octetstream"
        /// </summary>
        /// <param name="strFullPhycialFilePath"></param>
        /// <remarks>Full physical path and filename of the file to download. Does support UNC paths</remarks>
        public DownloadGateway(string strFullPhycialFilePath)
        {
            //Default Link Parameters
            myLinkParameters.Target = "_self";

            myStream = null;
            myFilePath = strFullPhycialFilePath;
            myTargetFilename = System.IO.Path.GetFileName(strFullPhycialFilePath);
            this.DetectContentType(strFullPhycialFilePath);
        }

        /// <summary>
        /// Constructor when downloading from an already open stream.
        /// Stream must be already opened and it is read from start to finish.
        /// TargetFilename parameter is used as a 'friendly' filename if downloading as attachment, as well as
        /// seeking 
        /// Content type for the data will be based on the extension of the filename and is retrieved from
        /// the server's registry, defaulting to "application/octetstream"
        /// </summary>
        /// <param name="objStream"></param>
        /// <param name="strTargetFilename"></param>
        /// <remarks></remarks>
        public DownloadGateway(Stream objStream, string strTargetFilename)
        {
            //Default Link Parameters
            myLinkParameters.Target = "_self";

            myStream = objStream;
            myFilePath = null;
            myTargetFilename = strTargetFilename;
            this.DetectContentType(strTargetFilename);
        }
        #endregion

        #region Properties

        /// <summary>
        /// Only relevant when downloading as attachment (which is the default).
        /// Will default to the filename without path parameter in the constructor when downloading a file, 
        /// and to the friendly filename in the constructor when downloading from a stream.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string TargetFileName
        {
            get { return myTargetFilename; }
            set { myTargetFilename = value; }
        }

        /// <summary>
        /// Content type is automatically set based on the filename/friendlyfilename of the constructor and
        /// is based on the server's registry for mime content types, defaulting to "application/octetstream".
        /// Can be overwritten before StartDownload is called.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string ContentType
        {
            get { return myContentType; }
            set { myContentType = value; }
        }

        /// <summary>
        /// Downloading as attachment (default) or inline
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool DownloadAsAttachment
        {
            get { return myDownloadAsAttachment; }
            set { myDownloadAsAttachment = value; }
        }

        /// <summary>
        /// LinkParameters used when invoking the download request via Link.Open.
        /// Can be adjusted at will before StartDownload is called.
        /// Default LinkParameters only have Target set to "_self", which initiates the download within the 
        /// current window and you get just one single download window, instead of a new window and then the
        /// download window.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public LinkParameters LinkParameters
        {
            get { return myLinkParameters; }
            set { myLinkParameters = value; }
        }

        #endregion

        #region The download operation

        /// <summary>
        /// Starts the download
        /// </summary>
        /// <param name="objContainerControl"></param>
        /// <remarks></remarks>
        public void StartDownload(ContainerControl objContainerControl)
        {
            //Set Parent Container
            myContainer = objContainerControl;

            //Add Myself to Container (to get current HTTP Context)
            myContainer.Controls.Add(this);

            //Open Link to ourself as a Gateway (using empty Action string) -> Calls Me.GetGatewayHandler()

            Link.Open(new GatewayReference(this, "VWGDownload"), myLinkParameters);
        }

        #endregion

        #region Internals

        /// <summary>
        /// This is the core Function that writes to the HTTP Response Stream when Gateway contents are requested.
        /// No need to check strAction here as we will only get one type of request, "VWGDownload"
        /// </summary>
        /// <param name="objHttpContext"></param>
        /// <param name="strAction"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected override Gizmox.WebGUI.Common.Interfaces.IGatewayHandler ProcessGatewayRequest(System.Web.HttpContext objHttpContext, string strAction)
        {
            //Get HTTP Response Object
            HttpResponse objResponse = objHttpContext.Response;

            //Set the Content-Type
            if (this.myContentType != null)
            {
                objResponse.ContentType = myContentType;
            }

            //Set Filename Header
            if (this.myDownloadAsAttachment == true & this.myTargetFilename != null)
            {
                //add the response headers
                objResponse.AddHeader("content-disposition", "attachment; filename=\"" + this.myTargetFilename + "\"");
            }

            //Send File out to HTTP Stream
            if (myStream == null)
            {
                //Write to Stream using using FileStream
                objResponse.WriteFile(myFilePath);
            }
            else
            {
                //Write to Stream using Byte Array
                byte[] myByteArray = GetStreamAsByteArray(myStream);
                objResponse.BinaryWrite(myByteArray);
            }

            //Remove Myself from Container
            myContainer.Controls.Remove(this);

            return null;
        }

        /// <summary>
        /// Helper function when downloading from a stream.
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        private byte[] GetStreamAsByteArray(System.IO.Stream stream)
        {
            stream.Seek(0, 0);
            int streamLength = Convert.ToInt32(stream.Length);
            byte[] fileData = new byte[streamLength + 1];
            // Read the file into a byte array
            stream.Read(fileData, 0, streamLength);
            stream.Close();
            return fileData;
        }

        /// <summary>
        /// Searches the registry of the server for a contenttype matching the extension of the filename
        /// If none is found, defaults to "application/octetstream"
        /// Sets the content type to be used by the component and is called as a part of the Constructor.
        /// If you need to override the default, check the content type after creating your instance of
        /// the DownloadGateway and set according to your needs if required.
        /// </summary>
        /// <param name="strFilename"></param>
        /// <remarks></remarks>
        private void DetectContentType(string strFilename)
        {
            string mime = "application/octetstream";
            string ext = System.IO.Path.GetExtension(strFilename).ToLower();
            if (ext != null && ext.Length > 0)
            {
                Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
                if (rk != null && rk.GetValue("Content Type") != null)
                {
                    mime = rk.GetValue("Content Type").ToString();
                }
            }
            this.myContentType = mime;
        }

        #region Usercontrol
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
        }

        #endregion
        #endregion
    }
}