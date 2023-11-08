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

using SPF.Forms.Base;
using SPF.Classes;
using ModelEF6;

#endregion

namespace SPF.Forms.UI
{
    public partial class FDatosMailingHTML : Form
    {
        #region Variables
        frmPickBase fPickUsuario;
        BerkeDBEntities DBContext;
        string whoCalled = "";
        string referenceNumber = "";
        #endregion Variables

        #region Eventos Personalizados
        public event EventHandler AceptarFiltrarClick;
        #endregion Eventos Personalizados

        #region Propiedades
        public string From
        {
            get { return this.txtDe.Text; }
        }

        public string To
        {
            set { this.txtPara.Text = value; }
            get { return this.txtPara.Text; }
        }
        
        public string CC
        {
            set { this.txtCC.Text = value; }
            get { return this.txtCC.Text; }
        }

        public string BCC
        {
            set { this.txtBCC.Text = value; }
            get { return this.txtBCC.Text; }
        }

        public string Subject
        {
            set { this.txtAsunto.Text = value; }
            get { return this.txtAsunto.Text; }
        }

        public string Body
        {
            set { this.htmlText.Html = value; }
            get { return this.htmlText.Html; }
        }

        public string ReferenceNumber
        {
            set { this.referenceNumber = value; }
            get { return this.referenceNumber; }
        }
        
        #endregion Propiedades

        public FDatosMailingHTML()
        {
            InitializeComponent();
        }

        public FDatosMailingHTML(BerkeDBEntities context)
        {
            InitializeComponent();
            this.DBContext = context;
            whoCalled = "";
        }

        private void FDatosMailing_Load(object sender, EventArgs e)
        {
            this.txtDe.Text = VWGContext.Current.Session["EmailUsuario"].ToString();
            this.txtUsuario.Text = VWGContext.Current.Session["EmailUsuario"].ToString();

            int usuarioID = Convert.ToInt32(VWGContext.Current.Session["UsuarioID"].ToString());
            this.txtPassword.Text = this.DBContext.Usuario.FirstOrDefault(a => a.ID == usuarioID).PasswordEmail;

            if (fPickUsuario == null)
            {
                fPickUsuario = new frmPickBase();
                fPickUsuario.AceptarFiltrarClick += fPickUsuario_AceptarFiltrarClick;
                fPickUsuario.FiltrarClick += fPickUsuario_FiltrarClick;
                fPickUsuario.Titulo = "Elegir Usuario";
                fPickUsuario.CampoIDNombre = "ID";
                fPickUsuario.CampoDescripNombre = "NombrePila";
                fPickUsuario.LabelCampoID = "ID";
                fPickUsuario.LabelCampoDescrip = "Nombre";
                fPickUsuario.NombreCampo = "Usuario";
                fPickUsuario.PermitirFiltroNulo = true;
            }
            //fPickUsuario.MostrarFiltro();
        }

        #region Pick Usuario
        private void fPickUsuario_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickUsuario != null)
            {
                fPickUsuario.LoadData<Usuario>(this.DBContext.Usuario, fPickUsuario.GetWhereString());
            }
        }

        private void fPickUsuario_AceptarFiltrarClick(object sender, EventArgs e)
        {
            switch (whoCalled)
            {
                case "Para":
                    {
                        if (this.txtPara.Text != "")
                            this.txtPara.Text += "; ";
                        
                        this.txtPara.Text += fPickUsuario.GetValor("Email").ToString();

                        break;
                    }

                case "CC":
                    {
                        if (this.txtCC.Text != "")
                            this.txtCC.Text += "; ";

                        this.txtCC.Text += fPickUsuario.GetValor("Email").ToString();

                        break;
                    }

                case "BCC":
                    {
                        if (this.txtBCC.Text != "")
                            this.txtBCC.Text += "; ";

                        this.txtBCC.Text += fPickUsuario.GetValor("Email");

                        break;
                    }
            }
                        
            fPickUsuario.Close();
            fPickUsuario.Dispose();
        }
        #endregion Pick Usuario

        private void btnPara_Click(object sender, EventArgs e)
        {
            whoCalled = "Para";
            fPickUsuario.MostrarFiltro();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if ((this.txtUsuario.Text.Trim() == string.Empty) || (this.txtPassword.Text.Trim() == string.Empty))
            {
                MessageBox.Show("Debe ingresar E-mail y Contraseña para la autenticación en la pestaña \"Configurar\".",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            if (this.AceptarFiltrarClick != null)
            {
                this.AceptarFiltrarClick(sender, e);
                //this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCC_Click(object sender, EventArgs e)
        {
            whoCalled = "CC";
            fPickUsuario.MostrarFiltro();
        }

        private void btnBCC_Click(object sender, EventArgs e)
        {
            whoCalled = "BCC";
            fPickUsuario.MostrarFiltro();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.txtPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("La contraseña debe contener algún tipo de caracter.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }


            string message = "Se modificarán los datos de autentiación para el envío de e-mail" + Environment.NewLine +
                             "¿Desea continuar?";
            string caption = "Confirmación";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(DialogHandler));
        }

        private void DialogHandler(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    this.GuardarCredenciales();
                }
            }
        }

        private void GuardarCredenciales()
        {
            bool success = false;
            
            Usuario usu = new Usuario();
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Encrypt_Decrypt encrypt = new Encrypt_Decrypt();
                        int usuarioID = Convert.ToInt32(VWGContext.Current.Session["UsuarioID"].ToString());
                        string encrypt_pwd = encrypt.EncryptString(this.txtPassword.Text);
                        context.Usuario.FirstOrDefault(a => a.ID == usuarioID).PasswordEmail = encrypt_pwd;
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        this.txtPassword.Text = encrypt_pwd;
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();

                        string innerException = String.Empty;

                        if (ex.InnerException != null)
                        {
                            innerException += "Detalle: ";
                            innerException += ex.InnerException.InnerException != null
                                              ? ex.InnerException.InnerException.Message
                                              : ex.InnerException.Message;
                        }

                        MessageBox.Show("Ocurrió un error al procesar el guardado: "
                                        + ex.Message + Environment.NewLine
                                        + innerException,
                                        "Error al guardar los datos",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Stop);
                    }
                }
            }

            if (success)
            {
                MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FDatosMailingHTML_GotFocus(object sender, EventArgs e)
        {
            this.txtPara.Focus();
        }
    }
}