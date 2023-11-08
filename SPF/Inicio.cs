#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Net;
using System.Web;
using System.IO;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using ModelEF6;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Security.Principal;
using System.Threading;
using System.Globalization;
using System.Configuration;

using SPF.UserControls;
using SPF.Classes;
using VWGCometCSharp;
using HtmlAgilityPack;

#endregion

namespace SPF
{
    public partial class Inicio : Form
    {
        #region Constantes
        private const string PRESUP_FOLDER = "PRESUP_FOLDER";
        private const string WEATHER_HTML = "<html>" +
                                    "<body>" +
                                    "<a href=\"http://www.accuweather.com/es/py/asuncion/257012/weather-forecast/257012\" class=\"aw-widget-legal\"></a>" +
                                    "<div id=\"awcc1419892156508\" class=\"aw-widget-current\" data-locationkey=\"257012\" data-unit=\"c\" data-language=\"es\" data-useip=\"false\" data-uid=\"awcc1419892156508\"></div>" +
                                    "</div>" +
                                    "<script type=\"text/javascript\" src=\"http://oap.accuweather.com/launch.js\">" +
                                    "</script>" +
                                    "</body>" +
                                    "</html>";
        private const string DIV_CONTENT_REPLACE = "#replacecontent#";
        private const string TITULO_REPLACE = "<h2>Cotizaciones principales</h2>";
        private const string TITULO_NEW = "<h3 style=\"text-decoration: underline;\">Cotizaciones Principales del día - {0}</h3></br>";
        private const string REMOVE_DIV_MIDDLE = "<div id=\"leftboxmiddle\"></div>";
        private const string ICONO_REPLACE = "#icono#";
        private const string PATH_ICONO = "Icons.maxicambios_48x48.png.wgx";
        private const string COIN_REPLACE = "gfx/backgrounds/coin.gif";
        private const string PATH_COIN = "Images.coin.gif.wgx";
        private const string ES_ADMINISTRADOR = "EsAdministrador";
        private const string PUEDE_VER_TODO = "PuedeVerTodo";
        private const string IMPRESION_DOCUMENTOS = "impredoc";
        private const string IMPRESION_DOCUMENTOS_TRUE = "1";
        private const string FECHA_ASSEMBLY = "Última Actualización: {0} {1}";
        private const int SISTEMA_ID = 1;
        private const string IE_BROWSER = "InternetExplorer";
        private const string TESTMODE = "TestMode";
        private const string TESTMODE_USERNAME = "TestModeUserName";
        private const string TESTMODE_PASSWORD = "TestModePassword";
        private const string TESTMODE_DOMAIN = "TestModeDomain";
        #endregion Constantes

        #region Variables Globales
        private WindowsIdentity currentWindowsUser;
        private Hashtable userControlsHT;
        private BerkeDBEntities db;
        private bool impreDoc = false;
        #endregion Variables Globales
        
        #region Manejo de eventos
        
        #endregion Manejo de eventos

        #region Propiedades
        public bool EsImpreDoc
        {
            get { return this.impreDoc; }
            set { this.impreDoc = value; }
        }
        public TreeNode NodoSeleccionado
        {
            get { return this.tvMenu.SelectedNode; }
        }

        public string Estado
        {
            get { return this.lblStatus.Text; }
            set { this.lblStatus.Text = value; }
        }
        #endregion Propiedades

        public Inicio()
        {
            InitializeComponent();
            userControlsHT = new Hashtable();
            CultureInfo ci = new CultureInfo("es-ES");
            VWGContext.Current.CurrentUICulture = ci;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //using (Impersonator Context = new Impersonator("gagaleanod", "berke.com.py", "C0r0navirus"))
            //{
            //    this.DoWork();
            //}
            bool isTestMode = false;
            
            if (ConfigurationManager.AppSettings[TESTMODE] != null)
            {
                isTestMode = Convert.ToBoolean(ConfigurationManager.AppSettings[TESTMODE]);
            }

            VWGContext.Current.Session["TestMode"] = isTestMode;

            if (isTestMode)
            {
                string userName = ConfigurationManager.AppSettings[TESTMODE_USERNAME].ToString();
                string password = ConfigurationManager.AppSettings[TESTMODE_PASSWORD].ToString();
                string domain = ConfigurationManager.AppSettings[TESTMODE_DOMAIN].ToString();

                VWGContext.Current.Session["WindowsUser"] = userName;

                using (Impersonation.LogonUser(domain, userName, password, LogonType.NewCredentials))
                {
                    // Code to execute as the impersonated user
                    this.DoWork(userName);
                }
            }
            else
            {
                currentWindowsUser = WindowsIdentity.GetCurrent();
                VWGContext.Current.Session["WindowsUser"] = currentWindowsUser.Name;
                string userName = VWGContext.Current.Session["WindowsUser"].ToString();

                if (userName != "")
                {
                    userName = userName.Replace(@"BERKE\", "");
                }

                this.DoWork(userName);
            }
        }

        private void DoWork(string username = "")
        {
            for (int i = 0; i < Context.Arguments.Count; i++)
            {
                this.EsImpreDoc = Context.Arguments.Keys[i] == IMPRESION_DOCUMENTOS && Context.Arguments[i] == IMPRESION_DOCUMENTOS_TRUE;
            }

            //this.CometFrequency = 0;

            this.lblFecha.Text = "Asunción, " + DateTime.Now.ToLongDateString();
            DateTime assemblyDate = File.GetLastWriteTime(Assembly.GetExecutingAssembly().Location);
            //this.lblFechaAssembly.Text = String.Format(FECHA_ASSEMBLY, "20/04/2022", "09:48 pm"); //String.Format(FECHA_ASSEMBLY, assemblyDate.ToShortDateString(), assemblyDate.ToShortTimeString());
            this.lblFechaAssembly.Text = String.Format(FECHA_ASSEMBLY, assemblyDate.ToShortDateString(), assemblyDate.ToShortTimeString());

            this.lblBD.Text = "Base de Datos: Sin conexión";
            this.lblServidor.Text = "Servidor: Sin conexión";

            //currentWindowsUser = WindowsIdentity.GetCurrent();
            //VWGContext.Current.Session["WindowsUser"] = currentWindowsUser.Name;

            //db = new BerkeDBEntities();

            //string username = VWGContext.Current.Session["WindowsUser"].ToString();
            //if (username != "")
            //{
            //    username = username.Replace(@"BERKE\", "");
            //}

            try
            {
                db = new BerkeDBEntities();
                Usuario usuario = this.db.Usuario.First(a => a.Usuario1 == username);
                VWGContext.Current.Session["UsuarioID"] = usuario.ID;
                VWGContext.Current.Session["NombreUsuario"] = usuario.NombrePila;
                VWGContext.Current.Session["EmailUsuario"] = usuario.Email;
                pa_parametros param = this.db.pa_parametros.First(a => a.clave == PRESUP_FOLDER);
                VWGContext.Current.Session["PresupFolderURL"] = String.Format(param.valor, username);
                VWGContext.Current.Session["SistemaID"] = SISTEMA_ID.ToString();
                VWGContext.Current.Session["UserName"] = username;

                Environment.SetEnvironmentVariable("TMP", @"C:\\Windows\Temp\");
            }
            catch (InvalidOperationException)
            {
                throw new Exception("No existe el usuario: " + username);
            }
            catch (Exception ex)
            {
                this.lblNoRole.Text = string.Format("Ocurrió un error en el inicio de sesión del usuario: {0}" + Environment.NewLine +
                                                    "Detalles del error:" + Environment.NewLine + "{1}" + Environment.NewLine + "{2}", username, ex.Message, 
                                                    ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                this.pnlMenu.Visible = false;
                this.lblNoRole.Visible = true;
                
                this.ManageWeatherWidget();
                this.tvMenu.Focus();

                this.htmlBoxDummyImg.Html = "<img style=\"visibility:hidden;height:0;width:0\" " +
                                            "src=\"Icons.usuario64x64.png.wgx\" " +
                                            "onload=\"window.status = 'Bienvenido al Sistema de Presupuestos y Facturación - Berkemeyer Attorneys and Counselors';\" >" +
                                            "</img>";
                this.htmlBoxDummyImg.Update();

                this.Estado = "Bienvenido al Sistema de Presupuestos y Facturación - Berkemeyer Attorneys and Counselors";
                this.pnlStatus.Visible = Context.HttpContext.Request.Browser.Browser != IE_BROWSER;
                this.htmlBox2.Visible = false;
                this.pnlContenidoPrincipal.Controls.Add(this.lblNoRole);
                return;
            }

            this.lblUsuario.Text = "Usuario: " + VWGContext.Current.Session["NombreUsuario"];

            //using (var db = new testMenuDBEntities())
            //{
            this.lblBD.Text = "Base de Datos: " + db.Database.Connection.Database;
            this.lblServidor.Text = "Servidor: " + db.Database.Connection.DataSource;

            //Armamos dinámicamente el contenido del menú principal
            this.tvMenu.Nodes.Clear();


            //Recuperamos los ítems del menú desde la base de datos
            //y las ordenamos por nivel y orden para asegurarnos de que
            //los menúes "padres" estén primeros en la lista y no generen errores
            //al ser referenciados por los menúes hijos

            //var query = db.mn_menu.Where(b => b.mn_activo == true).OrderBy(b => b.mn_nivel).ThenBy(b => b.mn_orden);

            //Se llama a un procedimiento que realiza las verificaciones de roles y devuelve el listado de menúes a los que el usuario
            //tiene acceso
            #region Inicio Normal
            this.btnImprimirDocumentos.Visible = false;
            //username = "kamoyanoa";
            List<GetMenuPorUsuarioSIGO2_Result> query = db.GetMenuPorUsuarioSIGO2(username, SISTEMA_ID).ToList();
            //List<GetMenuPorUsuarioSIGO2_Result> mostrarImpresion = query.Where(a => a.mn_clave == IMPRESION_DOCUMENTOS).ToList();

            //---------------
            List<GetMenuPorUsuarioSIGO2_Result> mostrarImpresion = new List<GetMenuPorUsuarioSIGO2_Result>();
            //---------------

            int menuIDImpresion = -1;
            if (mostrarImpresion.Count == 1)
            {
                this.btnImprimirDocumentos.Visible = !this.EsImpreDoc;
                menuIDImpresion = mostrarImpresion.First().mn_idmenu;
            }
            else if (mostrarImpresion.Count > 0)
                throw new Exception("Hay más de un menú de impresión de documentos definido. Referencia: (impredoc).");

            if (this.EsImpreDoc)
            {
                this.pnlContenidoPrincipal.Controls.Clear();
                query = query.Where(a => a.mn_idmenupadre == menuIDImpresion).ToList();
                mostrarImpresion.AddRange(query);
                query = mostrarImpresion;
                if (mostrarImpresion.Count == 0)
                {
                    //this.lblNoRole.Visible = true;
                    this.pnlContenidoPrincipal.Controls.Add(this.lblNoRole);
                }


            }
            else
            {
                query = query.Where(a => a.mn_idmenu != menuIDImpresion).ToList().Where(b => b.mn_idmenupadre != menuIDImpresion).ToList();
            }

            Hashtable hashMenu = new Hashtable();
            VWGContext.Current.Session[PUEDE_VER_TODO] = null;

            if (query.Count > 0)
            {
                bool firstIt = true;
                foreach (var item in query)
                {
                    if (firstIt)
                    {
                        //Creamos variables de sesión sobr níveles de acceso del Usuario logueado
                        VWGContext.Current.Session[ES_ADMINISTRADOR] = item.EsAdministrador.Value;
                        //VWGContext.Current.Session[PUEDE_VER_TODO] = item.PuedeVerTodo.Value;
                        firstIt = false;
                    }

                    if ((item.PuedeVerTodo.HasValue) && (item.PuedeVerTodo.Value) && (item.mn_idmenupadre.HasValue))
                    {
                        VWGContext.Current.Session[PUEDE_VER_TODO] += (VWGContext.Current.Session[PUEDE_VER_TODO] != null ? ";" : String.Empty)
                                                                        + item.mn_titulo;
                    }

                    //Guardamos el conjunto idmenu => clave para luego referenciar al menú padre por la clave
                    //al armar el árbol del menú
                    hashMenu[item.mn_idmenu] = item.mn_clave;
                    string title = this.MakeShortTitle(item.mn_titulo);
                    if (!item.mn_idmenupadre.HasValue)
                    {
                        //this.tvMenu.Nodes.Add(item.mn_clave, item.mn_titulo);
                        this.tvMenu.Nodes.Add(new TreeNode() { Name = item.mn_clave, Text = title, ToolTipText = item.mn_titulo });
                    }
                    else
                    {
                        //this.tvMenu.Nodes[(string)hashMenu[item.mn_idmenupadre]].Nodes.Add(item.mn_clave
                        //                 + "$" + item.mn_rutarelativa + "$" + item.mn_tipo, item.mn_titulo);
                        this.tvMenu.Nodes[(string)hashMenu[item.mn_idmenupadre]].Nodes.Add(new TreeNode()
                        {
                            Name = item.mn_clave + "$" + item.mn_rutarelativa + "$" + item.mn_tipo,
                            Text = title,
                            ToolTipText = item.mn_titulo
                        });
                    }
                }
                this.lblNoRole.Text = "";
                this.lblNoRole.Visible = false;
                this.pnlMenu.Visible = true;
            }
            else if (query.Count == 0)
            {
                if (!this.EsImpreDoc)
                {
                    this.lblNoRole.Text = String.Format("El usuario \"{0}\" no pertenece a ningún rol con acceso al sistema.",
                                                        VWGContext.Current.Session["WindowsUser"].ToString());
                }
                else
                {
                    this.lblNoRole.Text = String.Format("No tiene acceso a este módulo. Usuario: \"{0}\".",
                                                        VWGContext.Current.Session["WindowsUser"].ToString());
                }
                this.pnlMenu.Visible = false;
                this.lblNoRole.Visible = true;
            }

            this.ManageWeatherWidget();
            this.tvMenu.Focus();
            //this.IsPageFullyLoaded();

            this.htmlBoxDummyImg.Html = "<img style=\"visibility:hidden;height:0;width:0\" " +
                                        "src=\"Icons.usuario64x64.png.wgx\" " +
                                        "onload=\"window.status = 'Bienvenido al Sistema de Presupuestos y Facturación - Berkemeyer Attorneys and Counselors';\" >" +
                                        "</img>";
            this.htmlBoxDummyImg.Update();

            this.Estado = "Bienvenido al Sistema de Presupuestos y Facturación - Berkemeyer Attorneys and Counselors";
            this.pnlStatus.Visible = Context.HttpContext.Request.Browser.Browser != IE_BROWSER;

            //this.htmlBox1.Visible = false;
            this.htmlBox2.Visible = false;
            //this.htmlBox3.Visible = false;

            #endregion Inicio Normal
        }

        private string MakeShortTitle(string title)
        {
            string Result = title;

            if (title.Length > 30)
                Result = title.Substring(0, 22).TrimEnd() + "...";

            return Result;
        }

        private void ManageWeatherWidget()
        {
            try
            {
                this.pnlContenidoPrincipal.Controls.Clear();
                this.CloseAllUserControls();

                this.htmlBox1.Visible = !this.lblNoRole.Visible;
                this.htmlBox1.Html = WEATHER_HTML;
                this.htmlBox1.Update();
                this.pnlContenidoPrincipal.Controls.Add(this.htmlBox1);

                string path3 = VWGContext.Current.Server.MapPath(@"\Resources\UserData\xe-currency-converter.htm");
                string html3 = System.IO.File.ReadAllText(@path3);
                this.htmlBox3.Visible = !this.lblNoRole.Visible;
                this.htmlBox3.Html = html3;
                this.htmlBox3.Update();
                this.pnlContenidoPrincipal.Controls.Add(this.htmlBox3);

                //string path2 = VWGContext.Current.Server.MapPath(@"\Resources\UserData\cotizaciones.html");
                //string html2 = System.IO.File.ReadAllText(@path2);
                //string divHTML = this.GetHTMLDivData();
                //this.htmlBox2.Visible = !this.lblNoRole.Visible;
                //html2 = html2.Replace(DIV_CONTENT_REPLACE, divHTML);
                //html2 = html2.Replace(COIN_REPLACE, PATH_COIN);
                //this.htmlBox2.Html = html2;
                //this.htmlBox2.Update();
                //this.pnlContenidoPrincipal.Controls.Add(this.htmlBox2);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al manejar los Widgets: " + Environment.NewLine + ex.Message, "Información de Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private string GetHTMLDivData()
        {
            string result = String.Empty;

            //HtmlAgilityPack.HtmlNode.ElementsFlags.Remove("form");
            HtmlDocument doc = new HtmlDocument();
            doc.OptionAutoCloseOnEnd = true;
            doc.LoadHtml(this.GetHTMLData());
            //doc.LoadHtml(this.GetHTMLDataTroughWebClient());

            //
            //var web = new HtmlWeb();
            //web.PreRequest = delegate(HttpWebRequest webRequest)
            //{
            //    webRequest.Timeout = 10000;
            //    return true;
            //};
            //web.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.2.4) Gecko/20100611 Firefox/3.6.4";
            //var doc = web.Load("http://www.maxicambios.com.py", "proxy.berke.com.py", 8080, @"BERKE\gagaleanod", "berkemeyer");

            /*Ahora
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://www.maxicambios.com.py");
            request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.2.4) Gecko/20100611 Firefox/3.6.4";
            request.Timeout = 20000; Ahora*/
            /*
            WebProxy myProxy = new WebProxy();
            Uri newUri = new Uri("http://proxy.berke.com.py:8080");
            // Associate the newUri object to 'myProxy' object so that new myProxy settings can be set.
            myProxy.Address = newUri;
            // Create a NetworkCredential object and associate it with the 
            // Proxy property of request object.
            myProxy.Credentials = new NetworkCredential("gagaleanod", "berkemeyer", "BERKE");
            request.Proxy = myProxy;*/

            /*Aora WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

            doc.LoadHtml( reader.ReadToEnd()); Ahora */


            //HtmlNode rightcontentNode = doc.DocumentNode.SelectSingleNode("//div[@id='rightcontentfirst']");
            
            //if (rightcontentNode != null)
            //{
            //    HtmlNode despliega = rightcontentNode.SelectSingleNode("//div[@class='despliega']");
            //    result = rightcontentNode.InnerHtml.Replace(despliega.InnerHtml, String.Empty);
            //}
            //else
            //{
            //    result = rightcontentNode.InnerHtml;
            //}

            HtmlNode tablaCoti = doc.DocumentNode.SelectSingleNode("//div[@class='table-responsive ranks closed']");
            result = tablaCoti.InnerHtml;
            
            return result;
        }

        private string GetHTMLData()
        {
            string data = String.Empty;
            string urlAddress = "http://www.maxicambios.com.py";

            //var proxy = WebRequest.GetSystemWebProxy();
            //proxy.Credentials = CredentialCache.DefaultNetworkCredentials;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            //request.Proxy = proxy;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                data = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }
            return data;
        }

        private string GetHTMLDataTroughWebClient()
        {
            string urlAddress = "http://www.maxicambios.com.py";
            string html = String.Empty;
            using (var client = new WebClient())
            {
                WebProxy wp = new WebProxy("proxy.berke.com.py:8080");
                //wp.UseDefaultCredentials = true;
                wp.Credentials = CredentialCache.DefaultNetworkCredentials;
                client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.2.4) Gecko/20100611 Firefox/3.6.4";
                client.Proxy = wp;
                html = client.DownloadString(urlAddress);
            }
            return html;
        }

        private void SetDynamicHandler(Object obj, Type type, string CustomEventHandlerName)
        {
            foreach (EventInfo info in type.GetEvents())
            {
                if (info.Name == CustomEventHandlerName)
                {
                    Type tDelegate = info.EventHandlerType;

                    MethodInfo miHandler = typeof(Inicio).GetMethod("UserControlCloseHandler",
                                                  BindingFlags.NonPublic | BindingFlags.Instance);

                    Delegate d = Delegate.CreateDelegate(tDelegate, this, miHandler);

                    MethodInfo addHandler = info.GetAddMethod();
                    Object[] addHandlerArgs = { d };
                    addHandler.Invoke(obj, addHandlerArgs);
                }
            }
         }

        private void UserControlCloseHandler(Object sender, EventArgs e)
        {
            this.userControlsHT[sender.GetType().ToString()] = null;
            ((Control)sender).Dispose();

            if (this.pnlContenidoPrincipal.Controls.Count > 0)
            {
                //if (this.pnlContenidoPrincipal.Controls.Count > 3)
                if (this.pnlContenidoPrincipal.Controls.Count > 2)
                {
                    this.pnlContenidoPrincipal.Controls[this.pnlContenidoPrincipal.Controls.Count - 1].Visible = true;
                    this.pnlContenidoPrincipal.Controls[this.pnlContenidoPrincipal.Controls.Count - 1].Focus();
                }
                else
                {
                    for (int i = 0; i <= this.pnlContenidoPrincipal.Controls.Count - 1; i++)
                    {
                        this.pnlContenidoPrincipal.Controls[i].Visible = true;
                    }
                }
            }
            else
            {
                this.tvMenu.SelectedNode = this.tvMenu.SelectedNode.Parent;
                this.tvMenu.Focus();
            }
            if (this.tvMenu.SelectedNode != null)
            {
                this.Estado = this.tvMenu.SelectedNode.Parent.Text + " - " + this.tvMenu.SelectedNode.ToolTipText;
                this.SetStatusBarText(this.tvMenu.SelectedNode.Parent.Text + " - " + this.tvMenu.SelectedNode.ToolTipText);
            }
        }

        private void CloseAllUserControls()
        {
            ArrayList arrayList = new ArrayList(this.userControlsHT.Keys);
            foreach (var key in arrayList)
            {
                this.userControlsHT[key] = null;
            }
        }

        private void btnOcultarMenu_Click(object sender, EventArgs e)
        {
            this.pnlMenu.Visible = false;
            this.btnMostrarMenu.Visible = true;
            this.pnlContenidoPrincipal.Focus();
        }

        private void btnMostrarMenu_Click(object sender, EventArgs e)
        {
            this.pnlMenu.Visible = true;
            ((Button)sender).Visible = false;
            this.tvMenu.Focus();
        }

        private void tvMenu_Click(object sender, EventArgs e)
        {
            TreeNode node = null;
            string[] className = null;
            
            if (e.GetType() == typeof(TreeNodeMouseClickEventArgs))
            {
                node = ((TreeNodeMouseClickEventArgs)e).Node;
                className = node.Name.Split('$');
            }
            else
                return;

            //if (className[0] == "crudimpfacturas")
            //{
            //    MessageBox.Show("Funcionalidad en Desarrollo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            //string[] className = ((TreeNode)e).Name.Split('$');//((TreeView)sender).SelectedNode.Name.Split('$');
            
            Object myObj = null;

            try
            {
                if (className.Count() > 1)
                {
                    ////this.Estado = node.Parent.Text + " - " + node.ToolTipText;
                    //this.SetStatusBarText(node.Parent.Text + " - " + node.ToolTipText);

                    if (Context.HttpContext.Request.Browser.Browser != IE_BROWSER)
                    {
                        this.Estado = node.Parent.Text + " - " + node.ToolTipText;
                    }
                    else
                    {
                        //this.Estado = node.Parent.Text + " - " + node.ToolTipText;
                        this.SetStatusBarText(node.Parent.Text + " - " + node.ToolTipText);
                    }


                    

                    if (userControlsHT[className[1]] != null)
                    {
                        myObj = userControlsHT[className[1]];

                        if (className[2] == "UC")
                        {
                            foreach (Control ctrl in this.pnlContenidoPrincipal.Controls)
                            {
                                if (ctrl.Name != className[1])
                                    ctrl.Visible = false;
                            }
                            this.pnlContenidoPrincipal.Controls[className[1]].Visible = true;
                            this.pnlContenidoPrincipal.Controls[className[1]].Focus();
                        }
                        else if (className[2] == "FR")
                        {
                            ((Gizmox.WebGUI.Forms.Form)myObj).MinimizeBox = false;
                            ((Gizmox.WebGUI.Forms.Form)myObj).ShowDialog();
                            ((Gizmox.WebGUI.Forms.Form)myObj).FormClosed += delegate { myObj = null; };
                        }
                        else if (className[2] == "FC")
                        {
                            if (((Gizmox.WebGUI.Forms.Form)myObj).WindowState != FormWindowState.Normal)
                            {
                                ((Gizmox.WebGUI.Forms.Form)myObj).WindowState = FormWindowState.Normal;
                                ((Gizmox.WebGUI.Forms.Form)myObj).Focus();
                            }

                        }
                    }
                    else if (className[1] != "")
                    {
                        //Obtenemos el Type de la clase a instanciar a partir de los datos del menú referenciado en 
                        //la base de datos, tabla Mn_Menu
                        Type uControl = Type.GetType(className[1]);

                        //Instanciamos el UserControl a mostrar utilizando Reflection, de tal manera a hacerlo de manera
                        //dinámica y no por cada UserControl invididual
                        myObj = Activator.CreateInstance(uControl,
                                                         new object[] { (node.Parent).Text + " - " + node.ToolTipText, db });

                        if (className[2] == "UC")
                        {
                            //Enlazamos dinámicamente el evento "OnUserControlButtonClicked" del UserControl dinámicamente instanciado
                            //al handler local UserControlCloseHandler
                            this.SetDynamicHandler(myObj, uControl, "OnUserControlButtonClicked");
                            userControlsHT[uControl.FullName] = myObj;

                            foreach (Control ctrl in this.pnlContenidoPrincipal.Controls)
                            {
                                ctrl.Visible = false;
                            }
                            Control ucCtrl = (Control)myObj;
                            ucCtrl.Name = className[1];
                            this.pnlContenidoPrincipal.Controls.Add(ucCtrl);
                            this.pnlContenidoPrincipal.Controls[className[1]].Dock = DockStyle.Fill;
                            this.pnlContenidoPrincipal.Controls[className[1]].Focus();

                        }
                        else if (className[2] == "FR")
                        {
                            ((Gizmox.WebGUI.Forms.Form)myObj).MinimizeBox = false;
                            ((Gizmox.WebGUI.Forms.Form)myObj).FormClosed += delegate { myObj = null; };
                            ((Gizmox.WebGUI.Forms.Form)myObj).ShowDialog();
                        }
                        else if (className[2] == "FC")
                        {
                            userControlsHT[uControl.FullName] = myObj;
                            ((Gizmox.WebGUI.Forms.Form)myObj).Show();
                            ((Gizmox.WebGUI.Forms.Form)myObj).FormClosed += delegate
                            {
                                this.userControlsHT[myObj.GetType().ToString()] = null;
                                ((Control)myObj).Dispose();
                                myObj = null;
                            };
                        }
                    }
                }
                else
                {
                    this.Estado = node.ToolTipText;
                    this.SetStatusBarText(node.ToolTipText);
                }
                
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("No se encontró el elemento.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al abrir el componente: " + Environment.NewLine + ex.Message, "Información de Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                MessageBox.Show(ex.InnerException.Message);
            }
        }

        private void Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Cerramos la conexión a la base de datos global
            //Si se crearon conexiones además de ésta se deben cerrar independientemente por cada instancia creada
            ((IObjectContextAdapter)db).ObjectContext.Connection.Close();
        }

        private void pictHome_Click(object sender, EventArgs e)
        {
            //this.pnlContenidoPrincipal.Controls.Clear();
            //this.pnlContenidoPrincipal.Controls.Add(this.htmlBox1);
            //this.pnlContenidoPrincipal.Controls.Add(this.htmlBox2);
            this.ManageWeatherWidget();
        }

        private void btnImprimirDocumentos_Click(object sender, EventArgs e)
        {
            VWGClientContext.Current.Invoke("NewMaximizeWindowTab", "post.Inicio.wgx?impredoc=1");
            //MessageBox.Show("Función en desarrollo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    object [] jsParams = new object[2];
        //    jsParams[0] = this.htmlBox3.ID.ToString();
        //    jsParams[1] = this.ID.ToString();
        //    VWGClientContext.Current.Invoke("printHTMLBox", jsParams);
        //}

        public void SetStatusBarText(string message)
        {
            const string JS_SET_STATUSBAR_TEST = "window.status = '{0}'";

            VWGClientContext.Current.Invoke(this, "eval", String.Format(JS_SET_STATUSBAR_TEST, message));
        }

       
    }
}