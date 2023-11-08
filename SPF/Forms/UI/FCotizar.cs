#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;

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
    public partial class FCotizar : Form
    {

        #region Variables Globales
        int ClienteID;
        int ClienteMultipleID;
        bool esMultiple = false;
        BerkeDBEntities DBContext;
        frmPickBase fPickTramite;
        frmPickBase fPickCliente;
        frmPickBase fPickPais;
        frmPickBase fPickTarifa;
        frmPickBase fPickMoneda;
        frmPickBase fPickEnviadoPor;
        frmPickBase fPickAutorizadoPor;
        private bool TramiteInterno = false;
        string ListaCotizacionesID = "";
        private bool EsForm = false;
        private List<string> ColumnsToExclude = null;
        private List<OpoListTypeAll> listaExpe;
        private bool EditarSoloRecargoAT = false;
        #endregion Variables Globales
        
        #region Constantes
        public const string BROWSE = "BROWSE";
        public const string INSERT = "INSERT";
        public const string EDIT = "EDIT";
        private const string CAMPO_EXPEDIENTEID   = "ExpedienteID";
        private const string CAMPO_REGISTRONRO    = "RegistroNro";
        private const string CAMPO_ACTAANIO       = "ActaAnio";
        private const string CAMPO_ACTANRO        = "ActaNro";
        private const string CAMPO_ACTA           = "Acta";
        private const string CAMPO_TRAMITEID      = "TramiteID";
        private const string CAMPO_TRAMITEDESCRIP = "TramiteDescrip";
        private const string CAMPO_DENOMINACION   = "DenominacionMarca";
        private const string CAMPO_CLIENTEID      = "ClienteID";
        private const string CAMPO_CLIENTENOMBRE  = "ClienteNombre";
        private const string CAMPO_HINRO = "HINro";
        private const string CAMPO_HIANIO = "HIAnio";
        private const string CAMPO_HI = "HI";
        private const int DOLARES_AMERICANOS = 2;
        private const string OTROS_TRAMITES = "OTROS_TRAMITES";
        private const string CAMPO_TARIFAID             = "TarifaID";
        private const string CAMPO_TARIFADESCRIPCION    = "TarifaDescripcion";
        private const string CAMPO_TARIFAFECHA = "TarifaFecha";
        private const string CAMPO_TARIFACLIENTEID = "Tarifa_ClienteID";
        private const string CAMPO_TARIFACLIENTENOMBRE = "TarifaClienteNombre";
        private const string CAMPO_TARIFATIPOUNIDDESC = "TarifaTipoUnidadDescuento";
        private const string CAMPO_TARIFAMONTODESCUENTO = "TarifaMontoDescuento";
        private const string CAMPO_TARIFAPORCDESC       = "TarifaPorcentajeDescuento";
        private const string CAMPO_TARIFATIPOUNIDIMP    = "TarifaTipoUnidadImpuesto";
        private const string CAMPO_TARIFAMONTOIMPUESTO  = "TarifaMontoImpuesto";
        private const string CAMPO_TARIFAPORCIMP        = "TarifaPorcentajeImpuesto";
        private const string CAMPO_TARIFAEXPEDIENTE     = "TarifaExpedienteID";
        private const string CAMPO_TARIFACANTIDAD       = "TarifaCantidad";
        private const string CAMPO_TARIFATOTAL          = "TarifaTotal";
        private const string CAMPO_TARIFAMONEDADID      = "TarifaMonedaID";
        private const string CAMPO_TARIFAMONEDADDESCRIP = "TarifaMonedaDescrip";
        private const string CAMPO_TARIFAPRECIOUNITARIO = "TarifaPrecioUnitario";
        private const string CAMPO_TARIFAPRECIOVENTA    = "TarifaPrecioVenta";
        private const string CAMPO_TARIFAXCLIENTEID     = "Tarifa_TarifaClienteID";
        private const string CAMPO_TARIFAESPECIAL       = "TarifaEsEspecial";
        private const string CAMPO_COTIZACIONCABID      = "CotizacionCabID";
        private const string CAMPO_FECHACOTIZACION      = "FechaCotiCab";
        private const string CAMPO_AUTORIZADOPOR        = "AutorizadoPor";
        private const string CAMPO_AUTORIZADOPORNOMBRE  = "AutorizadoPorNombre";
        private const string CAMPO_ENVIADOPOR           = "EnviadoPor";
        private const string CAMPO_ENVIADOPORNOMBRE     = "EnviadoPorNombre";
        private const string CAMPO_CONFIRMADO           = "Confirmado";
        private const string CAMPO_ESDUPLICADO          = "EsDuplicado";
        private const string CAMPO_SELECCIONAR          = "Seleccionar";
        private const string CAMPO_ORDENTRABAJOID       = "OrdenTrabajoID";
        private const string CAMPO_TIENEAUTORIZACIONVIG = "TieneAutorizacionVigente";
        private const string CAMPO_TARIFATOTALCONRECARGO= "TarifaTotalConRecargo";
        private const string CAMPO_TARIFARECARGONETO    = "TarifaRecargoNeto";
        private const string CAMPO_CLIENTEPAISID        = "ClientePaisID";
        private const string CAMPO_CLIENTEPAISDESCRIP   = "ClientePaisDescrip";
        private const string CAMPO_FECHADOCUMENTO       = "FechaDocumento";
        private const string CAMPO_NRODOCUMENTO         = "NroDocumento";
        private const string CAMPO_ESTADODOCUMENTO      = "EstadoDocumento";
        private const string CAMPO_ESTADODOCUMENTOTEXTO = "EstadoDocumentoTexto";
        private const string CAMPO_OBSERVACION          = "Observacion";
        private const string CAMPO_MONTORECARGOAT       = "MontoRecargoAT";
        private const string CAMPO_FECHAENTRADA         = "FechaEntrada";
        private const string CAMPO_FECHASALIDA          = "FechaSalida";
        private const string CAMPO_ESSUSTINTERV         = "EsSustInterv";
        private const int TIPO_DOCUMENTO = 1;
        private const string USUARIOS_BERKE = "USUARIOS_BERKE";
        #endregion Constantes

        #region Propiedades
        public string FormEditStatus
        {
            set { this.txtEditStatus.Text = value; }
            get { return this.txtEditStatus.Text; }
        }
        #endregion Propiedades

        public FCotizar()
        {
            InitializeComponent();
        }

        public FCotizar(string titulo, BerkeDBEntities context)
        {
            InitializeComponent();
            this.DBContext = context;
            this.ClienteID = -1;

            this.tSBTramite.KeyMemberWidth = 70;
            this.tSBTramite.ToolTip = "Elegir Trámite";
            this.tSBTramite.Editable = true;
            this.tSBTramite.AceptarClick += tSBTramite_AceptarClick;

            this.tSBCliente.KeyMemberWidth = 70;
            this.tSBCliente.ToolTip = "Elegir Cliente";
            this.tSBCliente.Editable = true;
            this.tSBCliente.AceptarClick += tSBCliente_AceptarClick;

            this.tSBPais.KeyMemberWidth = 70;
            this.tSBPais.ToolTip = "Elegir País";
            this.tSBPais.Editable = true;
            this.tSBPais.AceptarClick += tSBPais_AceptarClick;

            this.tSBMoneda.KeyMemberWidth = 50;
            this.tSBMoneda.ToolTip = "Elegir Moneda";
            this.tSBMoneda.AceptarClick += tSBMoneda_AceptarClick;

            this.tSBTarifa.KeyMemberWidth = 50;
            this.tSBTarifa.ToolTip = "Elegir Tarifa";
            this.tSBTarifa.AceptarClick += tSBTarifa_AceptarClick;

            this.tSBEnviadoPor.KeyMemberWidth = 35;
            this.tSBEnviadoPor.ToolTip = "Elegir Persona que Envía";
            this.tSBEnviadoPor.AceptarClick += tSBEnviadoPor_AceptarClick;

            this.tSBAutorizadoPor.KeyMemberWidth = 35;
            this.tSBAutorizadoPor.ToolTip = "Elegir Persona que Autoriza";
            this.tSBAutorizadoPor.AceptarClick += tSBAutorizadoPor_AceptarClick;

            this.tSBClienteEdit.KeyMemberWidth = 70;
            this.tSBClienteEdit.ToolTip = "Elegir Cliente";
            this.tSBClienteEdit.AceptarClick += tSBClienteEdit_AceptarClick;

            this.Text = titulo;
            this.EsForm = true;
            this.tSBCliente.Clear();
            this.FormEditStatus = BROWSE;
            this.tSBCliente.Focus();

            ColumnsToExclude = new List<string>();
            
        }

        public FCotizar(int clienteid, string clientenombre, BerkeDBEntities context)
        {
            InitializeComponent();
            this.ClienteID = clienteid;
            this.DBContext = context;
            this.EsClienteMultiple();

            this.tSBTramite.KeyMemberWidth = 70;
            this.tSBTramite.ToolTip = "Elegir Trámite";
            this.tSBTramite.Editable = true;
            this.tSBTramite.AceptarClick += tSBTramite_AceptarClick;

            this.tSBCliente.KeyMemberWidth = 70;
            this.tSBCliente.ToolTip = "Elegir Cliente";
            //this.tSBCliente.Editable = true;
            this.tSBCliente.AceptarClick += tSBCliente_AceptarClick;

            this.tSBPais.KeyMemberWidth = 70;
            this.tSBPais.ToolTip = "Elegir País";
            this.tSBPais.Editable = true;
            this.tSBPais.AceptarClick += tSBPais_AceptarClick;

            this.tSBMoneda.KeyMemberWidth = 50;
            this.tSBMoneda.ToolTip = "Elegir Moneda";
            this.tSBMoneda.AceptarClick += tSBMoneda_AceptarClick;

            this.tSBTarifa.KeyMemberWidth = 50;
            this.tSBTarifa.ToolTip = "Elegir Tarifa";
            this.tSBTarifa.AceptarClick += tSBTarifa_AceptarClick;

            this.tSBEnviadoPor.KeyMemberWidth = 35;
            this.tSBEnviadoPor.ToolTip = "Elegir Persona que Envía";
            this.tSBEnviadoPor.AceptarClick += tSBEnviadoPor_AceptarClick;

            this.tSBAutorizadoPor.KeyMemberWidth = 35;
            this.tSBAutorizadoPor.ToolTip = "Elegir Persona que Autoriza";
            this.tSBAutorizadoPor.AceptarClick += tSBAutorizadoPor_AceptarClick;

            this.tSBClienteEdit.KeyMemberWidth = 35;
            this.tSBClienteEdit.ToolTip = "Elegir Cliente";
            this.tSBClienteEdit.AceptarClick += tSBClienteEdit_AceptarClick;

            this.Text = "Cotizaciones";
            this.EsForm = false;
            this.tSBCliente.KeyMember = clienteid.ToString();
            this.tSBCliente.DisplayMember = clientenombre;
            this.FormEditStatus = BROWSE;
            this.tSBTramite.Focus();

            ColumnsToExclude = new List<string>();
        }

        private void EsClienteMultiple()
        {
            //Cliente cli =  this.DBContext.Cliente.First(a => a.ID == this.ClienteID);
            this.esMultiple = this.DBContext.Cliente.First(a => a.ID == this.ClienteID).Multiple;

            if (this.esMultiple)
            {
                if (!this.EsForm)
                {
                    this.lblCliente.Text = "C.Múltiple" + Environment.NewLine + "(" + this.ClienteID.ToString() + ")";
                    this.lblCliente.ForeColor = Color.Red;
                }
                this.ClienteMultipleID = this.ClienteID;
            }
            else
            {
                this.lblCliente.Text = "Cliente";
                this.lblCliente.ForeColor = Color.Black;
                this.ClienteMultipleID = -1;
            }
        }

        private void tSBTarifa_AceptarClick(object sender, EventArgs e)
        {
            if ((this.tSBMoneda.KeyMember == "") || (this.txtTramiteID.Text == ""))
            {
                MessageBox.Show("Debe indicar el trámite y la moneda antes de seleccionar una tarifa.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            if (fPickTarifa == null)
            {
                fPickTarifa = new frmPickBase();
                fPickTarifa.AceptarFiltrarClick += fPickTarifa_AceptarFiltrarClick;
                fPickTarifa.FiltrarClick += fPickTarifa_FiltrarClick;
                fPickTarifa.Titulo = "Elegir Tarifa";
                fPickTarifa.CampoIDNombre = "TarifaID";
                fPickTarifa.CampoDescripNombre = "DescripcionTarifa";
                fPickTarifa.LabelCampoID = "ID";
                fPickTarifa.LabelCampoDescrip = "Descripción";
                fPickTarifa.NombreCampo = "Tarifa";
                fPickTarifa.PermitirFiltroNulo = true;
            }
            fPickTarifa.MostrarFiltro();
            this.fPickTarifa_FiltrarClick(sender, e);
        }

        private void fPickTarifa_FiltrarClick(object sender, EventArgs e)
        {
            int tramiteid = Convert.ToInt32(this.txtTramiteID.Text);
            int monedaid = Convert.ToInt32(this.tSBMoneda.KeyMember);

            var query = (from tarifas in this.DBContext.Tarifas
                         join trr_tarifatramite in this.DBContext.trr_tramitetarifa
                           on tarifas.ID equals trr_tarifatramite.ttr_tarifaid
                         select new TarifasType
                         {
                             TarifaID = tarifas.ID,
                             DescripcionTarifa = tarifas.Descripcion,
                             TramiteID = trr_tarifatramite.ttr_tramiteid,
                             MonedaID = tarifas.MonedaID
                         })
                        .Where(a => a.TramiteID == tramiteid && a.MonedaID == DOLARES_AMERICANOS);//monedaid);
            

            if (fPickTarifa != null)
            {
                fPickTarifa.LoadData<TarifasType>(query.AsQueryable(), fPickTarifa.GetWhereString());
                //fPickTarifa.LoadData<TarifasType>(query, fPickTarifa.GetWhereString());
            }
        }

        private void fPickTarifa_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBTarifa.DisplayMember = fPickTarifa.ValorDescrip;
            this.tSBTarifa.KeyMember = fPickTarifa.ValorID;

            fPickTarifa.Close();
            fPickTarifa.Dispose();

            if (this.tSBTarifa.KeyMember != "")
                this.getTarifaFromHistorico();
                
        }

        private void tSBMoneda_AceptarClick(object sender, EventArgs e)
        {
            if (fPickMoneda == null)
            {
                fPickMoneda = new frmPickBase();
                fPickMoneda.AceptarFiltrarClick += fPickMoneda_AceptarFiltrarClick;
                fPickMoneda.FiltrarClick += fPickMoneda_FiltrarClick;
                fPickMoneda.Titulo = "Elegir Moneda";
                fPickMoneda.CampoIDNombre = "ID";
                fPickMoneda.CampoDescripNombre = "Descripcion";
                fPickMoneda.LabelCampoID = "ID";
                fPickMoneda.LabelCampoDescrip = "Descripción";
                fPickMoneda.NombreCampo = "Tarifa";
                fPickMoneda.PermitirFiltroNulo = true;
            }
            fPickMoneda.MostrarFiltro();
            this.fPickMoneda_FiltrarClick(sender, e);
        }

        private void fPickMoneda_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickMoneda != null)
            {
                fPickMoneda.LoadData<Moneda>(this.DBContext.Moneda, fPickMoneda.GetWhereString());
            }
        }

        private void fPickMoneda_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBMoneda.DisplayMember = fPickMoneda.ValorDescrip;
            this.tSBMoneda.KeyMember = fPickMoneda.ValorID;

            fPickMoneda.Close();
            fPickMoneda.Dispose();
        }

        private void tSBCliente_AceptarClick(object sender, EventArgs e)
        {
            if (fPickCliente == null)
            {
                fPickCliente = new frmPickBase();
                fPickCliente.AceptarFiltrarClick += fPickCliente_AceptarFiltrarClick;
                fPickCliente.FiltrarClick += fPickCliente_FiltrarClick;
                fPickCliente.Titulo = "Elegir Cliente";
                fPickCliente.CampoIDNombre = "ID";
                fPickCliente.CampoDescripNombre = "Nombre";
                fPickCliente.LabelCampoID = "ID";
                fPickCliente.LabelCampoDescrip = "Nombre";
                fPickCliente.NombreCampo = "Cliente";
                fPickCliente.PermitirFiltroNulo = false;
            }
            fPickCliente.MostrarFiltro();
        }

        private void fPickCliente_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickCliente != null)
            {
                fPickCliente.LoadData<Cliente>(this.DBContext.Cliente, fPickCliente.GetWhereString());
            }
        }

        private void fPickCliente_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBCliente.DisplayMember = fPickCliente.ValorDescrip;
            this.tSBCliente.KeyMember = fPickCliente.ValorID;
            this.ClienteID = Convert.ToInt32(this.tSBCliente.KeyMember);
            this.EsClienteMultiple();

            if ((this.tSBCliente.KeyMember != "") && (this.tSBTramite.KeyMember != ""))
            {
                //this.obtenerExpedientes(Convert.ToInt32(this.tSBTramite.KeyMember));
                //this.tabControl1.SelectedTab = tpListado;
            }

            

            fPickCliente.Close();
            fPickCliente.Dispose();
        }

        private void tSBClienteEdit_AceptarClick(object sender, EventArgs e)
        {
            if (fPickCliente == null)
            {
                fPickCliente = new frmPickBase();
                fPickCliente.AceptarFiltrarClick += fPickClientEdit_AceptarFiltrarClick;
                fPickCliente.FiltrarClick += fPickClienteEdit_FiltrarClick;
                fPickCliente.Titulo = "Elegir Cliente";
                fPickCliente.CampoIDNombre = "ID";
                fPickCliente.CampoDescripNombre = "Nombre";
                fPickCliente.LabelCampoID = "ID";
                fPickCliente.LabelCampoDescrip = "Nombre";
                fPickCliente.NombreCampo = "Cliente";
                fPickCliente.PermitirFiltroNulo = false;
            }
            fPickCliente.MostrarFiltro();
        }

        private void fPickClienteEdit_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickCliente != null)
            {
                fPickCliente.LoadData<Cliente>(this.DBContext.Cliente, fPickCliente.GetWhereString());
            }
        }

        private void fPickClientEdit_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBClienteEdit.DisplayMember = fPickCliente.ValorDescrip;
            this.tSBClienteEdit.KeyMember = fPickCliente.ValorID;
            this.ClienteID = Convert.ToInt32(this.tSBClienteEdit.KeyMember);

            fPickCliente.Close();
            fPickCliente.Dispose();
        }

        #region País
        private void tSBPais_AceptarClick(object sender, EventArgs e)
        {
            if (fPickPais == null)
            {
                fPickPais = new frmPickBase();
                fPickPais.AceptarFiltrarClick += fPickPais_AceptarFiltrarClick;
                fPickPais.FiltrarClick += fPickPais_FiltrarClick;
                fPickPais.Titulo = "Elegir País";
                fPickPais.CampoIDNombre = "idpais";
                fPickPais.CampoDescripNombre = "descrip";
                fPickPais.LabelCampoID = "ID";
                fPickPais.LabelCampoDescrip = "Descripción";
                fPickPais.NombreCampo = "País";
                fPickPais.PermitirFiltroNulo = false;
            }
            fPickPais.MostrarFiltro();
        }

        private void fPickPais_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickPais != null)
            {
                fPickPais.LoadData<CPais>(this.DBContext.CPais, fPickPais.GetWhereString());
            }
        }

        private void fPickPais_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBPais.DisplayMember = fPickPais.ValorDescrip;
            this.tSBPais.KeyMember = fPickPais.ValorID;
            fPickPais.Close();
            fPickPais.Dispose();
        }
        #endregion País

        private void tSBTramite_AceptarClick(object sender, EventArgs e)
        {
            if (fPickTramite == null)
            {
                fPickTramite = new frmPickBase();
                fPickTramite.AceptarFiltrarClick += fPickTramite_AceptarFiltrarClick;
                fPickTramite.FiltrarClick += fPickTramite_FiltrarClick;
                fPickTramite.Titulo = "Elegir Trámite";
                fPickTramite.CampoIDNombre = "ID";
                fPickTramite.CampoDescripNombre = "Descrip";
                fPickTramite.LabelCampoID = "ID";
                fPickTramite.LabelCampoDescrip = "Descripción";
                fPickTramite.NombreCampo = "Trámite";
                fPickTramite.PermitirFiltroNulo = true;
            }
            fPickTramite.MostrarFiltro();
            this.fPickTramite_FiltrarClick(sender, e);
        }
        
        private void fPickTramite_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickTramite != null)
            {
                fPickTramite.LoadData<Tramite>(this.DBContext.Tramite, fPickTramite.GetWhereString());
            }
        }

        private void fPickTramite_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBTramite.DisplayMember = fPickTramite.ValorDescrip;
            this.tSBTramite.KeyMember = fPickTramite.ValorID;

            int result = 0;

            if (this.esMultiple)
                result = this.getClientexTramite(Convert.ToInt32(this.tSBTramite.KeyMember));

            if (result == 0)
            {
                fPickTramite.Close();
                fPickTramite.Dispose();
            }
        }

        private void tSBEnviadoPor_AceptarClick(object sender, EventArgs e)
        {
            if (fPickEnviadoPor == null)
            {
                fPickEnviadoPor = new frmPickBase();
                fPickEnviadoPor.AceptarFiltrarClick += fPickEnviadoPor_AceptarFiltrarClick;
                fPickEnviadoPor.FiltrarClick += fPickEnviadoPor_FiltrarClick;
                fPickEnviadoPor.Titulo = "Elegir Persona que Envía";
                fPickEnviadoPor.CampoIDNombre = "ID";
                fPickEnviadoPor.CampoDescripNombre = "NombrePila";
                fPickEnviadoPor.LabelCampoID = "ID";
                fPickEnviadoPor.LabelCampoDescrip = "Nombre";
                fPickEnviadoPor.NombreCampo = "Usuario";
                fPickEnviadoPor.PermitirFiltroNulo = true;
            }
            fPickEnviadoPor.MostrarFiltro();
        }

        private void fPickEnviadoPor_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickEnviadoPor != null)
            {
                fPickEnviadoPor.LoadData<Usuario>(this.DBContext.Usuario, fPickEnviadoPor.GetWhereString());
            }
        }

        private void fPickEnviadoPor_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBEnviadoPor.DisplayMember = fPickEnviadoPor.ValorDescrip;
            this.tSBEnviadoPor.KeyMember = fPickEnviadoPor.ValorID;

            fPickEnviadoPor.Close();
            fPickEnviadoPor.Dispose();
        }

        private void tSBAutorizadoPor_AceptarClick(object sender, EventArgs e)
        {
            if (fPickAutorizadoPor == null)
            {
                fPickAutorizadoPor = new frmPickBase();
                fPickAutorizadoPor.AceptarFiltrarClick += fPickAutorizadoPor_AceptarFiltrarClick;
                fPickAutorizadoPor.FiltrarClick += fPickAutorizadoPor_FiltrarClick;
                fPickAutorizadoPor.Titulo = "Elegir Persona que Autoriza";
                fPickAutorizadoPor.CampoIDNombre = "ID";
                fPickAutorizadoPor.CampoDescripNombre = "NombrePila";
                fPickAutorizadoPor.LabelCampoID = "ID";
                fPickAutorizadoPor.LabelCampoDescrip = "Nombre";
                fPickAutorizadoPor.NombreCampo = "Usuario";
                fPickAutorizadoPor.PermitirFiltroNulo = true;
            }
            fPickAutorizadoPor.MostrarFiltro();
        }

        private void fPickAutorizadoPor_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickAutorizadoPor != null)
            {
                fPickAutorizadoPor.LoadData<Usuario>(this.DBContext.Usuario, fPickAutorizadoPor.GetWhereString());
            }
        }

        private void fPickAutorizadoPor_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBAutorizadoPor.DisplayMember = fPickAutorizadoPor.ValorDescrip;
            this.tSBAutorizadoPor.KeyMember = fPickAutorizadoPor.ValorID;

            fPickAutorizadoPor.Close();
            fPickAutorizadoPor.Dispose();
        }
        
        private int getClientexTramite(int tramiteID)
        {
            ClienteXTramite cxt = new ClienteXTramite();
            try
            {
                cxt = this.DBContext.ClienteXTramite.First(a => a.ClienteMultipleID == this.ClienteMultipleID && a.TramiteID == tramiteID);
            }
            catch (InvalidOperationException)
            {
                if (tramiteID == 1)
                {
                    MessageBox.Show("No se encuentran clientes asociados para el trámite seleccionado.",
                                    "Advertencia",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return -1;
                }

                this.getClientexTramite(1);//Si no hay cliente definido para el trámite en cuestión se utiliza el de Registro por defecto
                return 1;
            }
            
            this.ClienteID = cxt.ClienteID;
            Cliente cli = this.DBContext.Cliente.First(a => a.ID == this.ClienteID);

            //this.tSBCliente.KeyMember = cli.ID.ToString();
            //this.tSBCliente.DisplayMember = cli.Nombre;
            this.txtClienteFacturacionID.Text = cli.ID.ToString();
            this.txtClienteFacturacionNombre.Text = cli.Nombre;

            this.tSBClienteEdit.KeyMember = cli.ID.ToString();
            this.tSBClienteEdit.DisplayMember = cli.Nombre;

            return 0;
            //this.EsClienteMultiple();
        }

        #region Combo Tarifas
        //private void cargarCBTarifas(int tramiteid, int monedaid)
        //{
            

        //    bool existeVacio = true;
        //    this.DBContext.Tarifas.Load();

        //    try
        //    {
        //        Tarifas tarif = this.DBContext.Tarifas.Local.First(b => b.ID == -1);
        //    }
        //    catch (InvalidOperationException)
        //    {
        //        existeVacio = false;
        //    }

            
        //    var query = (from tarifas in this.DBContext.Tarifas.Local
        //                 join trr_tarifatramite in this.DBContext.trr_tramitetarifa
        //                   on tarifas.ID equals trr_tarifatramite.ttr_tarifaid
        //                 select new TarifasType
        //                 {
        //                     TarifaID = tarifas.ID,
        //                     DescripcionTarifa = tarifas.Descripcion,
        //                     TramiteID = trr_tarifatramite.ttr_tramiteid,
        //                     MonedaID = tarifas.MonedaID
        //                 })
        //                .Where(a => a.TramiteID == tramiteid && a.MonedaID == monedaid)
        //                .ToList();

        //    if (!existeVacio)
        //        query.Add(new TarifasType {TarifaID = -1, DescripcionTarifa = "Seleccione una tarifa...", TramiteID = -1, MonedaID = -1 });

        //    this.cbTarifas.DataSource = query;
        //    this.cbTarifas.DisplayMember = "DescripcionTarifa";
        //    this.cbTarifas.ValueMember = "TarifaID";
        //    this.cbTarifas.SelectedValue = -1;

        //    this.cbTarifas.SelectedValueChanged += cbTarifas_SelectedValueChanged;
        //}


        private void getTarifaFromHistorico()
        {
            if (this.FormEditStatus != BROWSE)
            {
                int tarifaID = -1;
                int monedaID = -1;

                tarifaID = Convert.ToInt32(this.tSBTarifa.KeyMember);
                monedaID = Convert.ToInt32(this.tSBMoneda.KeyMember);

                if ((tarifaID != -1) && (monedaID != -1))
                {
                    int tramiteID = Convert.ToInt32(this.txtTramiteID.Text);
                    int clienteID = this.esMultiple ? this.ClienteMultipleID : this.ClienteID;
                    //int clienteID = Convert.ToInt32(this.tSBCliente.KeyMember);

                    try
                    {
                        
                            tc_tarifascliente tc = this.DBContext.tc_tarifascliente
                                                .OrderByDescending(b => b.tc_fecha)
                                                .ThenByDescending(b => b.tc_id)
                                                .First(b => b.tc_clienteid == clienteID 
                                                            && b.tc_tarifaid == tarifaID 
                                                            && b.tc_tramiteid == tramiteID 
                                                            && b.tc_monedaid == monedaID
                                                            && !b.tc_especial);
                        
                        ((IObjectContextAdapter)this.DBContext).ObjectContext.Refresh(System.Data.Entity.Core.Objects.RefreshMode.ClientWins, tc);


                        //rcm_relacotizamone rcm = this.DBContext.rcm_relacotizamone.First(a => a.MonedaID == monedaID);

                        this.txtMonto.Text = tc.tc_monto.ToString();
                        //this.txtMonto.Text = String.Format("{0:0.00}", decimal.Round((tc.tc_monto / rcm.Factor), MidpointRounding.AwayFromZero));
                        this.txtPrecioVenta.Text = tc.tc_precioventa.ToString();
                        //this.txtPrecioVenta.Text = String.Format("{0:0.00}", decimal.Round((tc.tc_precioventa / rcm.Factor), MidpointRounding.AwayFromZero));
                        this.txtCantidad.Text = "1,00";
                        this.cbTipoUnidadDescuento.SelectedIndex = tc.tc_tipounidaddesc ? 1 : 0;
                        this.txtMontoDescuento.Text = tc.tc_descuentomonto.ToString();
                        //this.txtMontoDescuento.Text = String.Format("{0:0.00}", decimal.Round((tc.tc_descuentomonto / rcm.Factor), MidpointRounding.AwayFromZero));
                        this.txtPorcDescuento.Text = tc.tc_descuentoporcentaje.ToString();
                        this.cbTipoUnidadImpuesto.SelectedIndex = tc.tc_tipounidadimp ? 1 : 0;
                        this.txtMontoImp.Text = tc.tc_impuestomonto.ToString();
                        //this.txtMontoImp.Text = String.Format("{0:0.00}", decimal.Round((tc.tc_impuestomonto / rcm.Factor), MidpointRounding.AwayFromZero));
                        this.txtPorcImp.Text = tc.tc_impuestoporcentaje.ToString();

                        this.txtTotalConRecargo.Text = "0,00";
                        this.txtRecargoAT.Text = "0,00";

                        decimal total = 0;
                        if (this.chkRedondear.Checked)
                            total = decimal.Round(tc.tc_precioventa * (Convert.ToDecimal(this.txtCantidad.Text)) + tc.tc_impuestomonto - tc.tc_descuentomonto, MidpointRounding.AwayFromZero); 
                        else
                            total = tc.tc_precioventa * (Convert.ToDecimal(this.txtCantidad.Text)) + tc.tc_impuestomonto - tc.tc_descuentomonto;

                        this.txtTotal.Text = String.Format("{0:0.00}", total);
                        //this.txtTotal.Text = String.Format("{0:0.00}", (tc.tc_precioventa * (Convert.ToDecimal(this.txtCantidad.Text)) + tc.tc_impuestomonto - tc.tc_descuentomonto));

                        if (this.FormEditStatus == INSERT)
                        {
                            this.lblTarifaUtilizada.Visible = true;
                            this.lblTarifaUtilizada.Text = "Tarifa Utilizada: Última - " + tc.tc_fecha.ToShortDateString();
                        }

                    }
                    catch (InvalidOperationException)
                    {
                        Tarifas tarifa = this.DBContext.Tarifas.First(b => b.ID == tarifaID);

                        ((IObjectContextAdapter)this.DBContext).ObjectContext.Refresh(System.Data.Entity.Core.Objects.RefreshMode.ClientWins, tarifa);

                        
                        rcm_relacotizamone rcm = this.DBContext.rcm_relacotizamone.First(a => a.MonedaID == monedaID);

                        if (tarifa != null)
                        {
                            //this.txtMonto.Text = tarifa.Monto.ToString();
                            this.txtMonto.Text = String.Format("{0:0.00}", decimal.Round((tarifa.Monto * rcm.Factor), MidpointRounding.AwayFromZero));
                            //this.txtPrecioVenta.Text = tarifa.PrecioVenta.ToString();
                            this.txtPrecioVenta.Text = String.Format("{0:0.00}", decimal.Round((tarifa.PrecioVenta * rcm.Factor), MidpointRounding.AwayFromZero));
                            this.txtCantidad.Text = "1,00";
                            this.cbTipoUnidadDescuento.SelectedIndex = tarifa.TipoUnidadDesc ? 1 : 0;
                            //this.txtMontoDescuento.Text = tarifa.DescuentoMonto.ToString();
                            this.txtMontoDescuento.Text = String.Format("{0:0.00}", decimal.Round((tarifa.DescuentoMonto * rcm.Factor), MidpointRounding.AwayFromZero));
                            this.txtPorcDescuento.Text = tarifa.DescuentoPorcentaje.ToString();
                            this.cbTipoUnidadImpuesto.SelectedIndex = tarifa.TipoUnidadImp ? 1 : 0;
                            //this.txtMontoImp.Text = tarifa.ImpuestoMonto.ToString();
                            this.txtMontoImp.Text = String.Format("{0:0.00}", decimal.Round((tarifa.ImpuestoMonto * rcm.Factor), MidpointRounding.AwayFromZero));
                            this.txtPorcImp.Text = tarifa.ImpuestoPorcentaje.ToString();
                            //this.txtTotal.Text = String.Format("{0:0.00}",(tarifa.PrecioVenta * (Convert.ToDecimal(this.txtCantidad.Text)) + tarifa.ImpuestoMonto - tarifa.DescuentoMonto));
                            this.txtTotalConRecargo.Text = "0,00";
                            
                            this.calcularTotal();

                            if (this.FormEditStatus == INSERT)
                            {
                                this.lblTarifaUtilizada.Visible = true;
                                this.lblTarifaUtilizada.Text = "Tarifa Utilizada: Base";
                            }
                        }
                    }

                    this.calcularGrandTotal();
                    this.txtCantidad.Focus();
                }
            }
        }
        private void cbTarifas_SelectedValueChanged(object sender, EventArgs e)
        {
            

        }

        //private void cargarCBMoneda()
        //{
        //    //this.DBContext.Moneda.Load();
        //    //this.cbMoneda.DataSource = this.DBContext.Moneda.ToList();
        //    //this.cbMoneda.DisplayMember = "Descripcion";
        //    //this.cbMoneda.ValueMember = "ID";

        //    bool existeVacio = true;
        //    //((IObjectContextAdapter)this.DBContext).ObjectContext.Refresh(System.Data.Entity.Core.Objects.RefreshMode.ClientWins, this.DBContext.Moneda.Local);
        //    this.DBContext.Moneda.Load();
            
            
        //    try
        //    {
        //        Moneda mone = this.DBContext.Moneda.Local.First(b => b.ID == -1);
        //    }
        //    catch (InvalidOperationException)
        //    {
        //        existeVacio = false;
        //        //this.DBContext.Moneda.Local.Add(new Moneda { ID = -1, Descripcion = "Seleccione una moneda..." });
        //    }

        //    if (!existeVacio)
        //        this.DBContext.Moneda.Local.Add(new Moneda { ID = -1, Descripcion = "Seleccione una moneda..." });

        //    this.cbMoneda.DataSource = this.DBContext.Moneda.Local.OrderBy(b => b.ID).ToList();
        //    this.cbMoneda.DisplayMember = "Descripcion";
        //    this.cbMoneda.ValueMember = "ID";

        //    this.cbMoneda.SelectedValue = -1;

        //    this.cbMoneda.SelectedValueChanged += cbMoneda_SelectedValueChanged;
        //}

        private void cbMoneda_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (this.cbMoneda.SelectedValue != null)
                //this.cargarCBTarifas(Convert.ToInt32(this.tSBTramite.KeyMember), (int)this.cbMoneda.SelectedValue);
        }

        #endregion Combo Idioma

        private void btnVerHistorico_Click(object sender, EventArgs e)
        {
            bool existe = true;
            //ch_clientehistorico ch = new ch_clientehistorico();

            ReportDataSource datasource = new ReportDataSource();

            try
            {
                //int clienteid = -1;

                //if (this.txtIDCliente.Text != "")
                //    clienteid = Convert.ToInt32(this.txtIDCliente.Text);

                var query = (from h in this.DBContext.ch_clientehistorico
                             select new
                             {
                                 TarifaHistorico = h.ch_tarifashistoricas,
                                 ClienteID = h.ch_clientenuevoid
                             })
                            .Where(a => a.ClienteID == this.ClienteID).ToList();

                datasource.Name = "DataSet1";
                datasource.Value = query;

            }
            catch (InvalidOperationException)
            {
                existe = false;
            }

            if (existe)
            {
                //FVisorBase f = new FVisorBase();
                //f.Titulo = "Antecedentes Históricos de Cotizaciones";
                //f.Info = ch.ch_tarifashistoricas;
                //f.ShowDialog();

                string path = @"Reportes\HistoricoAntecedentes.rdlc";

                FReportViewerBase f = new FReportViewerBase(path, datasource, this.DBContext);
                f.FormClosed += delegate { f = null; };
                f.Titulo = "Antecedentes Históricos - " + this.tSBCliente.DisplayMember + "(" + this.tSBCliente.KeyMember + ")";
                f.MostrarEnviar(false);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen antecedentes históricos para este cliente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //bool existe = true;
            //TarifasxCliente tarifasxcliente = new TarifasxCliente();
            //try
            //{
            //    tarifasxcliente = this.DBContext.TarifasxCliente.First(a => a.ID == ClienteID);
            //}
            //catch (InvalidOperationException)
            //{
            //    existe = false;
            //}

            //if (existe)
            //{
            //    FVisorBase f = new FVisorBase();
            //    f.Titulo = "Antecedentes Históricos de Cotizaciones";
            //    f.Info = tarifasxcliente.Observacion;
            //    f.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("No existen antecedentes históricos para este cliente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        //private void obtenerExpedientes(int tramiteid, int actanro = -1, int actaanio = -1,
        //                                int hinro = -1, int hianio = -1, int expedienteID = -1)
        #region Deprecated
        //private void obtenerExpedientes(int tramiteid, string actanro = "", string actaanio = "",
        //                                string hinro = "", string hianio = "", string expedienteID = "",
        //                                string cotizacionID = "")
        //{
        //    int usuarioID = Convert.ToInt32(VWGContext.Current.Session["UsuarioID"].ToString());

        //    pa_parametros param = this.DBContext.pa_parametros.First(a => a.clave == OTROS_TRAMITES);

        //    List<string> listaOtrosTramites = new List<string>(param.valor.Split(','));

        //    if ((listaOtrosTramites.Contains(tramiteid.ToString())) || (this.chkAntecedentes.Checked))
        //    {
        //        this.TramiteInterno = true;

        //        int clienteid;

        //        if (this.esMultiple)
        //            clienteid = this.ClienteMultipleID;
        //        else
        //            clienteid = this.ClienteID;

        //        //string predicate = "ClienteID = " + clienteid.ToString();
        //        string predicate = String.Empty;

        //        if (clienteid != -1)
        //        {
        //            predicate += predicate != String.Empty ? " AND " : String.Empty;
        //            predicate += " ClienteID = " + clienteid.ToString();
        //        }

        //        if (tramiteid != -1)
        //        {
        //            predicate += predicate != String.Empty ? " AND " : String.Empty;
        //            predicate += " TramiteID = " + tramiteid.ToString();
        //        }

        //        if (actanro != "")
        //        {
        //            predicate += predicate != String.Empty ? " AND " : String.Empty;
        //            predicate += this.GetFilterString(actanro.ToString(), "ActaNro", false);
        //        }

        //        if (actaanio != "")
        //        {
        //            predicate += predicate != String.Empty ? " AND " : String.Empty;
        //            predicate += this.GetFilterString(actaanio.ToString(), "ActaAnio", false);
        //        }

        //        if (hinro != "")
        //        {
        //            predicate += predicate != String.Empty ? " AND " : String.Empty;
        //            predicate += this.GetFilterString(hinro.ToString(), "HINro", false);
        //        }

        //        if (hianio != "")
        //        {
        //            predicate += predicate != String.Empty ? " AND " : String.Empty;
        //            predicate += this.GetFilterString(hianio.ToString(), "HIAnio", false);
        //        }

        //        if (expedienteID != "")
        //        {
        //            predicate += predicate != String.Empty ? " AND " : String.Empty;
        //            predicate += this.GetFilterString(expedienteID.ToString(), "ExpedienteID", false);
        //        }

        //        if (cotizacionID != "")
        //        {
        //            predicate += predicate != String.Empty ? " AND " : String.Empty;
        //            predicate += this.GetFilterString(cotizacionID.ToString(), "CotizacionCabID", false);
        //        }

        //        if (predicate == String.Empty)
        //        {
        //            MessageBox.Show("Debe indicar un filtro.",
        //                        "Información",
        //                        MessageBoxButtons.OK,
        //                        MessageBoxIcon.Information);
        //            return;
        //        }
 
        //        var expes = (from opo in this.DBContext.op_oposicion
        //                     join expedientes in this.DBContext.Expediente
        //                       on opo.ExpedienteID equals expedientes.ID into opo_expe
        //                       from expedientes in opo_expe.DefaultIfEmpty()
        //                     join marca in this.DBContext.Marca
        //                       on expedientes.MarcaID equals marca.ID into expe_mar
        //                       from marca in expe_mar.DefaultIfEmpty()
        //                     join marcaregren in this.DBContext.MarcaRegRen
        //                       on marca.MarcaRegRenID equals marcaregren.ID into mar_mrr
        //                       from marcaregren in mar_mrr.DefaultIfEmpty()
        //                     join tramite in this.DBContext.Tramite
        //                       on opo.TramiteID equals tramite.ID
        //                     //
        //                     join cotizacioncab in this.DBContext.cc_cotizacioncab
        //                       on opo.ID equals cotizacioncab.cc_expedienteid into opo_cc
        //                     from cotizacioncab in opo_cc.DefaultIfEmpty()
        //                     //Autorizado Por
        //                     join usuarioAutorizador in this.DBContext.Usuario
        //                       on cotizacioncab.cc_aprobadopor equals usuarioAutorizador.ID into coticab_usuAuto
        //                     from usuarioAutorizador in coticab_usuAuto.DefaultIfEmpty()
        //                     //Enviado Por
        //                     join usuarioEnviador in this.DBContext.Usuario
        //                       on cotizacioncab.cc_solicitadopor equals usuarioEnviador.ID into coticab_usuEnvi
        //                     from usuarioEnviador in coticab_usuEnvi.DefaultIfEmpty()
        //                     //OrdenTrabajo
        //                     join ot in this.DBContext.OrdenTrabajo
        //                       on opo.OrdenTrabajoID equals ot.ID into opo_ot
        //                       from ot in opo_ot.DefaultIfEmpty()
        //                     join cli in this.DBContext.Cliente
        //                        on opo.ClienteID equals cli.ID
        //                     select new OpoListType
        //                     {
        //                         ExpedienteID = opo.ID,
        //                         RegistroNro = marcaregren.RegistroNro,
        //                         ActaAnio = opo.ActaAnio,
        //                         ActaNro = opo.ActaNro,
        //                         //Acta = "", //opo.ActaNro + "/" + opo.ActaAnio,
        //                         TramiteID = opo.TramiteID,
        //                         TramiteDescrip = tramite.Descrip,
        //                         DenominacionMarca = opo.Denominacion,
        //                         ClienteID = opo.ClienteID,
        //                         ClienteNombre = cli.Nombre,
        //                         HINro = ot.Nro,
        //                         HIAnio = ot.Anio,
        //                         CotizacionCabID = cotizacioncab.cc_cotizacioncabid,
        //                         FechaCotiCab = cotizacioncab.cc_fecha,
        //                         AutorizadoPor = cotizacioncab.cc_aprobadopor,
        //                         AutorizadoPorNombre = usuarioAutorizador.NombrePila,
        //                         EnviadoPor = cotizacioncab.cc_solicitadopor,
        //                         EnviadoPorNombre = usuarioEnviador.NombrePila,
        //                         Confirmado = cotizacioncab.cc_confirmado,
        //                         OrdenTrabajoID = opo.OrdenTrabajoID,
        //                         TieneAutorizacionVigente = this.DBContext.GetAutorizacionPorDocumentoID(TIPO_DOCUMENTO,
        //                                                                                                 cotizacioncab.cc_cotizacioncabid,
        //                                                                                                 usuarioID)
        //                                                                                                 .FirstOrDefault().Value
                                 
        //                     }).Where(predicate)//.Where(a => a.ClienteID == this.ClienteID && a.TramiteID == tramiteid)
        //                .OrderByDescending(a => a.ExpedienteID)
        //                .ToList();
        //        this.dgvExpedientes.DataSource = expes.ToList();//this.DBContext.Expediente.Where(a => a.TramiteID == tramiteid && a.ClienteID == this.ClienteID).ToList();
        //    }
        //    else
        //    {
        //        this.TramiteInterno = false;

        //        int clienteid;

        //        if (this.esMultiple)
        //            clienteid = this.ClienteMultipleID;
        //        else
        //            clienteid = this.ClienteID;

        //        //string predicate = "ClienteID = " + clienteid.ToString(); 

        //        //if (tramiteid != -1)
        //        //    predicate += " AND TramiteID = " + tramiteid.ToString();
        //        //if (actanro != "")
        //        //    predicate += " AND " + this.GetFilterString(actanro.ToString(), "ActaNro", false);
        //        //if (actaanio != "")
        //        //    predicate += " AND " + this.GetFilterString(actaanio.ToString(), "ActaAnio", false);
        //        //if (hinro != "")
        //        //    predicate += " AND " + this.GetFilterString(hinro.ToString(), "HINro", false);
        //        //if (hianio != "")
        //        //    predicate += " AND " + this.GetFilterString(hianio.ToString(), "HIAnio", false);
        //        //if (expedienteID != "")
        //        //    predicate += " AND " + this.GetFilterString(expedienteID.ToString(), "ExpedienteID", false);
        //        //if (cotizacionID != "")
        //        //    predicate += " AND " + this.GetFilterString(cotizacionID.ToString(), "CotizacionCabID", false);

        //        string predicate = String.Empty;

        //        if (clienteid != -1)
        //        {
        //            predicate += predicate != String.Empty ? " AND " : String.Empty;
        //            predicate += " ClienteID = " + clienteid.ToString();
        //        }

        //        if (tramiteid != -1)
        //        {
        //            predicate += predicate != String.Empty ? " AND " : String.Empty;
        //            predicate += " TramiteID = " + tramiteid.ToString();
        //        }

        //        if (actanro != "")
        //        {
        //            predicate += predicate != String.Empty ? " AND " : String.Empty;
        //            predicate += this.GetFilterString(actanro.ToString(), "ActaNro", false);
        //        }

        //        if (actaanio != "")
        //        {
        //            predicate += predicate != String.Empty ? " AND " : String.Empty;
        //            predicate += this.GetFilterString(actaanio.ToString(), "ActaAnio", false);
        //        }

        //        if (hinro != "")
        //        {
        //            predicate += predicate != String.Empty ? " AND " : String.Empty;
        //            predicate += this.GetFilterString(hinro.ToString(), "HINro", false);
        //        }

        //        if (hianio != "")
        //        {
        //            predicate += predicate != String.Empty ? " AND " : String.Empty;
        //            predicate += this.GetFilterString(hianio.ToString(), "HIAnio", false);
        //        }

        //        if (expedienteID != "")
        //        {
        //            predicate += predicate != String.Empty ? " AND " : String.Empty;
        //            predicate += this.GetFilterString(expedienteID.ToString(), "ExpedienteID", false);
        //        }

        //        if (cotizacionID != "")
        //        {
        //            predicate += predicate != String.Empty ? " AND " : String.Empty;
        //            predicate += this.GetFilterString(cotizacionID.ToString(), "CotizacionCabID", false);
        //        }

        //        if (predicate == String.Empty)
        //        {
        //            MessageBox.Show("Debe indicar un filtro.",
        //                        "Información",
        //                        MessageBoxButtons.OK,
        //                        MessageBoxIcon.Information);
        //            return;
        //        }

        //        var expes = (from expedientes in this.DBContext.Expediente
        //                     join marca in this.DBContext.Marca
        //                       on expedientes.MarcaID equals marca.ID
        //                     join marcaregren in this.DBContext.MarcaRegRen
        //                       on marca.MarcaRegRenID equals marcaregren.ID
        //                     join tramite in this.DBContext.Tramite
        //                       on expedientes.TramiteID equals tramite.ID
        //                     join ot in this.DBContext.OrdenTrabajo
        //                       on expedientes.OrdenTrabajoID equals ot.ID
        //                     //
        //                     join cotizacioncab in this.DBContext.cc_cotizacioncab
        //                       on expedientes.ID equals cotizacioncab.cc_expedienteid into expe_cc
        //                     from cotizacioncab in expe_cc.DefaultIfEmpty()
        //                     //Autorizado Por
        //                     join usuarioAutorizador in this.DBContext.Usuario
        //                       on cotizacioncab.cc_aprobadopor equals usuarioAutorizador.ID into coticab_usuAuto
        //                     from usuarioAutorizador in coticab_usuAuto.DefaultIfEmpty()
        //                     //Enviado Por
        //                     join usuarioEnviador in this.DBContext.Usuario
        //                       on cotizacioncab.cc_solicitadopor equals usuarioEnviador.ID into coticab_usuEnvi
        //                     from usuarioEnviador in coticab_usuEnvi.DefaultIfEmpty()
        //                     //Cliente
        //                     join cli in this.DBContext.Cliente
        //                        on expedientes.ClienteID equals cli.ID

        //                     select new OpoListType
        //                     {
        //                         ExpedienteID = expedientes.ID,
        //                         RegistroNro = marcaregren.RegistroNro,
        //                         ActaAnio = expedientes.ActaAnio,
        //                         ActaNro = expedientes.ActaNro,
        //                         Acta = expedientes.Acta,
        //                         TramiteID = expedientes.TramiteID,
        //                         TramiteDescrip = tramite.Descrip,
        //                         DenominacionMarca = marca.Denominacion,
        //                         ClienteID = expedientes.ClienteID,
        //                         ClienteNombre = cli.Nombre,
        //                         HINro = ot.Nro,
        //                         HIAnio = ot.Anio,
        //                         CotizacionCabID = cotizacioncab.cc_cotizacioncabid,
        //                         FechaCotiCab = cotizacioncab.cc_fecha,
        //                         AutorizadoPor = cotizacioncab.cc_aprobadopor,
        //                         AutorizadoPorNombre = usuarioAutorizador.NombrePila,
        //                         EnviadoPor = cotizacioncab.cc_solicitadopor,
        //                         EnviadoPorNombre = usuarioEnviador.NombrePila,
        //                         Confirmado = cotizacioncab.cc_confirmado,
        //                         OrdenTrabajoID = ot.ID,
        //                         TieneAutorizacionVigente = this.DBContext.GetAutorizacionPorDocumentoID(TIPO_DOCUMENTO,
        //                                                                                                 cotizacioncab.cc_cotizacioncabid,
        //                                                                                                 usuarioID)
        //                                                                                                 .FirstOrDefault().Value
                                 
        //                     }).Where(predicate)//.Where(a => a.TramiteID == tramiteid && a.ClienteID == this.ClienteID)
        //                    .OrderByDescending(a => a.ExpedienteID);
        //                    //.ToList();
        //        //string sql = ((System.Data.Objects.ObjectQuery)expes).ToTraceString();
        //        this.dgvExpedientes.DataSource = expes.ToList();
                
                
                
        //    }
        //    this.FormatearGrilla();

        //    //this.cargarCBTarifas(tramiteid, (int)this.cbMoneda.SelectedValue);
        //}
        #endregion Deprecated

        private void obtenerExpedientes(int tramiteid, string paisid = "", string actanro = "", string actaanio = "",
                                        string hinro = "", string hianio = "", string expedienteID = "",
                                        string cotizacionID = "", string fechaEntrada = "", string fechaSalida = "")
        {
            int usuarioID = Convert.ToInt32(VWGContext.Current.Session["UsuarioID"].ToString());

            int clienteid;

            if (this.esMultiple)
                clienteid = this.ClienteMultipleID;
            else
                clienteid = this.ClienteID;

            string predicate = String.Empty;

            if (clienteid != -1)
            {
                predicate += predicate != String.Empty ? " AND " : String.Empty;
                predicate += " ClienteID = " + clienteid.ToString();
            }

            if (tramiteid != -1)
            {
                predicate += predicate != String.Empty ? " AND " : String.Empty;
                predicate += " TramiteID = " + tramiteid.ToString();
            }

            if (paisid != String.Empty)
            {
                predicate += predicate != String.Empty ? " AND " : String.Empty;
                predicate += this.GetFilterString(paisid, "ClientePaisID", false);
            }

            if (actanro != "")
            {
                predicate += predicate != String.Empty ? " AND " : String.Empty;
                predicate += this.GetFilterString(actanro.ToString(), "ActaNro", false);
            }

            if (actaanio != "")
            {
                predicate += predicate != String.Empty ? " AND " : String.Empty;
                predicate += this.GetFilterString(actaanio.ToString(), "ActaAnio", false);
            }

            if (hinro != "")
            {
                predicate += predicate != String.Empty ? " AND " : String.Empty;
                predicate += this.GetFilterString(hinro.ToString(), "HINro", false);
            }

            if (hianio != "")
            {
                predicate += predicate != String.Empty ? " AND " : String.Empty;
                predicate += this.GetFilterString(hianio.ToString(), "HIAnio", false);
            }

            if (expedienteID != "")
            {
                predicate += predicate != String.Empty ? " AND " : String.Empty;
                predicate += this.GetFilterString(expedienteID.ToString(), "ExpedienteID", false);
            }

            if (cotizacionID != "")
            {
                predicate += predicate != String.Empty ? " AND " : String.Empty;
                predicate += this.GetFilterString(cotizacionID.ToString(), "CotizacionCabID", false);
            }

            if (fechaEntrada != "")
            {
                predicate += predicate != String.Empty ? " AND " : String.Empty;
                //predicate += this.GetFilterString(fechaEntrada, "FechaEntrada", true);
                //GetFilterString(string valor, string clave, bool escadena = false, bool useSQLSyntax = false)
                SPF.Classes.GenerarCadenasFiltro f = new Classes.GenerarCadenasFiltro();
                predicate += f.GetFilterString(fechaEntrada, "FechaEntrada", true, true).Replace('\"', '\'');
            }

            if (fechaSalida != "")
            {
                predicate += predicate != String.Empty ? " AND " : String.Empty;
                SPF.Classes.GenerarCadenasFiltro f = new Classes.GenerarCadenasFiltro();
                predicate += f.GetFilterString(fechaSalida, "FechaSalida", true, true).Replace('\"', '\'');
            }

            if (predicate == String.Empty)
            {
                MessageBox.Show("Debe indicar un filtro.",
                            "Información",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                return;
            }

            listaExpe = new List<OpoListTypeAll>();
            listaExpe = (from lista in this.DBContext.GetTramitesParaCotizaciones(usuarioID, predicate)
                         select new OpoListTypeAll
                           {
                               ExpedienteID = lista.ExpedienteID,
                               RegistroNro = lista.RegistroNro,
                               ActaAnio = lista.ActaAnio,
                               ActaNro = lista.ActaNro,
                               //Acta = "", //opo.ActaNro + "/" + opo.ActaAnio,
                               TramiteID = lista.TramiteID,
                               TramiteDescrip = lista.TramiteDescrip,
                               DenominacionMarca = lista.DenominacionMarca,
                               ClienteID = lista.ClienteID,
                               ClienteNombre = lista.ClienteNombre,
                               ClientePaisID = lista.ClientePaisID,
                               ClientePaisDescrip = lista.ClientePaisDescrip,
                               HINro = lista.HiNro,
                               HIAnio = lista.HiAnio,
                               CotizacionCabID = lista.CotizacionCabID,
                               FechaCotiCab = lista.FechaCotiCab,
                               AutorizadoPor = lista.AutorizadoPor,
                               AutorizadoPorNombre = lista.AutorizadoPorNombre,
                               EnviadoPor = lista.EnviadoPor,
                               EnviadoPorNombre = lista.EnviadoPorNombre,
                               Confirmado = lista.Confirmado,
                               EsDuplicado = lista.EsDuplicado,
                               OrdenTrabajoID = lista.OrdenTrabajoID,
                               TieneAutorizacionVigente = lista.TienAutorizacionVigente,
                               NroDocumento = lista.DocumentoNro,
                               FechaDocumento = lista.FechaGeneracionPresup,
                               EstadoDocumento = lista.EstadoDocumento,
                               Observacion = lista.Observacion,
                               MontoRecargoAT = lista.MontoRecargoAT,
                               TarifaID = lista.TarifaID,
                               TarifaDescripcion = lista.TarifaDescripcion,
                               TarifaFecha = lista.TarifaFecha,
                               Tarifa_ClienteID = lista.Tarifa_ClienteID,
                               TarifaClienteNombre = lista.TarifaClienteNombre,
                               TarifaPrecioUnitario = lista.TarifaPrecioUnitario,
                               TarifaTipoUnidadDescuento = lista.TarifaTipoUnidadDescuento,
                               TarifaMontoDescuento = lista.TarifaMontoDescuento,
                               TarifaPorcentajeDescuento = lista.TarifaPorcentajeDescuento,
                               TarifaTipoUnidadImpuesto = lista.TarifaTipoUnidadImpuesto,
                               TarifaMontoImpuesto = lista.TarifaMontoImpuesto,
                               TarifaPorcentajeImpuesto = lista.TarifaPorcentajeImpuesto,
                               TarifaExpedienteID = lista.TarifaExpedienteID,
                               TarifaCantidad = lista.TarifaCantidad,
                               TarifaTotal = lista.TarifaTotal,
                               TarifaMonedaID = lista.TarifaMonedaID,
                               TarifaMonedaDescrip = lista.TarifaMonedaDescrip,
                               TarifaPrecioVenta = lista.TarifaPrecioVenta,
                               Tarifa_TarifaClienteID = lista.Tarifa_TarifaClienteID,
                               TarifaEsEspecial = lista.TarifaEsEspecial,
                               TarifaTotalConRecargo = lista.TarifaTotalConRecargo,
                               TarifaRecargoNeto = lista.TarifaRecargoNeto,
                               FechaEntrada = lista.FechaEntrada,
                               FechaSalida = lista.FechaSalida,
                               EsSustInterv = lista.EsSustInterv
                           }).ToList();

            this.dgvExportarExcel.DataSource = listaExpe;

            var query = (from item in listaExpe
                         select new OpoListTypeCab
                         {
                             //Cabecera
                             ExpedienteID = item.ExpedienteID,
                             RegistroNro = item.RegistroNro,
                             ActaAnio = item.ActaAnio,
                             ActaNro = item.ActaNro,
                             TramiteID = item.TramiteID,
                             TramiteDescrip = item.TramiteDescrip,
                             DenominacionMarca = item.DenominacionMarca,
                             ClienteID = item.ClienteID,
                             ClienteNombre = item.ClienteNombre,
                             ClientePaisID = item.ClientePaisID,
                             ClientePaisDescrip = item.ClientePaisDescrip,
                             HINro = item.HINro,
                             HIAnio = item.HIAnio,
                             CotizacionCabID = item.CotizacionCabID,
                             FechaCotiCab = item.FechaCotiCab,
                             EsDuplicado = item.EsDuplicado,
                             AutorizadoPor = item.AutorizadoPor,
                             AutorizadoPorNombre = item.AutorizadoPorNombre,
                             EnviadoPor = item.EnviadoPor,
                             EnviadoPorNombre = item.EnviadoPorNombre,
                             Confirmado = item.Confirmado,
                             OrdenTrabajoID = item.OrdenTrabajoID,
                             TieneAutorizacionVigente = item.TieneAutorizacionVigente,
                             NroDocumento = item.NroDocumento,
                             FechaDocumento = item.FechaDocumento,
                             EstadoDocumento = item.EstadoDocumento,
                             Observacion = item.Observacion,
                             MontoRecargoAT = item.MontoRecargoAT,
                             FechaEntrada = item.FechaEntrada,
                             FechaSalida = item.FechaSalida,
                             EsSustInterv = item.EsSustInterv
                         })
                         .GroupBy(x => new { x.CotizacionCabID, x.ExpedienteID, x.TramiteID, x.NroDocumento, x.EstadoDocumento }).Select(g => g.First()).ToList();

            //this.dgvExpedientes.DataSource = listaExpe;
            this.dgvExpedientes.DataSource = query;
            
            this.FormatearGrilla();

            //this.cargarCBTarifas(tramiteid, (int)this.cbMoneda.SelectedValue);
        }

        private void dgvExpedientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.cambiarTab();
        }

        private void FormatearGrilla()
        {
            foreach (DataGridViewColumn col in dgvExpedientes.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            int displayIndex = 0;

            DataGridViewCheckBoxColumn colConfirmado = new DataGridViewCheckBoxColumn();
            colConfirmado.DataPropertyName = CAMPO_CONFIRMADO;
            colConfirmado.Name = CAMPO_CONFIRMADO;
            colConfirmado.ValueType = typeof(Boolean);
            colConfirmado.HeaderText = "Confirmado";
            colConfirmado.FalseValue = false;
            colConfirmado.TrueValue = true;
            colConfirmado.ReadOnly = true;
            colConfirmado.Width = 80;
            dgvExpedientes.Columns.Insert(displayIndex, colConfirmado);
            displayIndex++;

            DataGridViewCheckBoxColumn colEsSustInterv = new DataGridViewCheckBoxColumn();
            colEsSustInterv.DataPropertyName = CAMPO_ESSUSTINTERV;
            colEsSustInterv.Name = CAMPO_ESSUSTINTERV;
            colEsSustInterv.ValueType = typeof(Boolean);
            colEsSustInterv.HeaderText = "Sust./Interv.";
            colEsSustInterv.FalseValue = false;
            colEsSustInterv.TrueValue = true;
            colEsSustInterv.ReadOnly = true;
            colEsSustInterv.Width = 100;
            dgvExpedientes.Columns.Insert(displayIndex, colEsSustInterv);
            displayIndex++;

            dgvExpedientes.Columns[CAMPO_COTIZACIONCABID].Visible = true;
            dgvExpedientes.Columns[CAMPO_COTIZACIONCABID].DisplayIndex = displayIndex;
            dgvExpedientes.Columns[CAMPO_COTIZACIONCABID].HeaderText = "Cotización ID";
            dgvExpedientes.Columns[CAMPO_COTIZACIONCABID].Width = 95;
            dgvExpedientes.Columns[CAMPO_COTIZACIONCABID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            displayIndex++;

            if (this.EsForm)
            {
                dgvExpedientes.Columns[CAMPO_CLIENTENOMBRE].Visible = true;
                dgvExpedientes.Columns[CAMPO_CLIENTENOMBRE].DisplayIndex = displayIndex;
                dgvExpedientes.Columns[CAMPO_CLIENTENOMBRE].HeaderText = "Cliente Expediente";
                dgvExpedientes.Columns[CAMPO_CLIENTENOMBRE].Width = 200;
                displayIndex++;
            }



            dgvExpedientes.Columns[CAMPO_TRAMITEDESCRIP].Visible = true;
            dgvExpedientes.Columns[CAMPO_TRAMITEDESCRIP].DisplayIndex = displayIndex;
            dgvExpedientes.Columns[CAMPO_TRAMITEDESCRIP].HeaderText = "Trámite";
            dgvExpedientes.Columns[CAMPO_TRAMITEDESCRIP].Width = 160;
            displayIndex++;

            dgvExpedientes.Columns[CAMPO_DENOMINACION].Visible = true;
            dgvExpedientes.Columns[CAMPO_DENOMINACION].DisplayIndex = displayIndex;
            dgvExpedientes.Columns[CAMPO_DENOMINACION].HeaderText = "Denominación";
            dgvExpedientes.Columns[CAMPO_DENOMINACION].Width = 200;
            displayIndex++;

            dgvExpedientes.Columns[CAMPO_REGISTRONRO].Visible = true;
            dgvExpedientes.Columns[CAMPO_REGISTRONRO].DisplayIndex = displayIndex;
            dgvExpedientes.Columns[CAMPO_REGISTRONRO].HeaderText = "Registro N°";
            dgvExpedientes.Columns[CAMPO_REGISTRONRO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            displayIndex++;
            
            dgvExpedientes.Columns[CAMPO_ACTA].Visible = true;
            dgvExpedientes.Columns[CAMPO_ACTA].DisplayIndex = displayIndex;
            dgvExpedientes.Columns[CAMPO_ACTA].HeaderText = "Acta";
            displayIndex++;
            
            dgvExpedientes.Columns[CAMPO_HI].Visible = true;
            dgvExpedientes.Columns[CAMPO_HI].DisplayIndex = displayIndex;
            dgvExpedientes.Columns[CAMPO_HI].HeaderText = "HI";
            displayIndex++;

            dgvExpedientes.Columns[CAMPO_FECHAENTRADA].Visible = true;
            dgvExpedientes.Columns[CAMPO_FECHAENTRADA].DisplayIndex = displayIndex;
            dgvExpedientes.Columns[CAMPO_FECHAENTRADA].HeaderText = "Fec. Entrada";
            dgvExpedientes.Columns[CAMPO_FECHAENTRADA].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvExpedientes.Columns[CAMPO_FECHAENTRADA].DefaultCellStyle.Format = "dd/MM/yyyy";
            displayIndex++;

            dgvExpedientes.Columns[CAMPO_FECHASALIDA].Visible = true;
            dgvExpedientes.Columns[CAMPO_FECHASALIDA].DisplayIndex = displayIndex;
            dgvExpedientes.Columns[CAMPO_FECHASALIDA].HeaderText = "Fec. Salida";
            dgvExpedientes.Columns[CAMPO_FECHASALIDA].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvExpedientes.Columns[CAMPO_FECHASALIDA].DefaultCellStyle.Format = "dd/MM/yyyy";
            displayIndex++;

            dgvExpedientes.Columns[CAMPO_NRODOCUMENTO].Visible = true;
            dgvExpedientes.Columns[CAMPO_NRODOCUMENTO].DisplayIndex = displayIndex;
            dgvExpedientes.Columns[CAMPO_NRODOCUMENTO].HeaderText = "N° Documento";
            displayIndex++;

            dgvExpedientes.Columns[CAMPO_FECHADOCUMENTO].Visible = true;
            dgvExpedientes.Columns[CAMPO_FECHADOCUMENTO].DisplayIndex = displayIndex;
            dgvExpedientes.Columns[CAMPO_FECHADOCUMENTO].HeaderText = "Fecha Doc.";
            displayIndex++;

            dgvExpedientes.Columns[CAMPO_ESTADODOCUMENTOTEXTO].Visible = true;
            dgvExpedientes.Columns[CAMPO_ESTADODOCUMENTOTEXTO].DisplayIndex = displayIndex;
            dgvExpedientes.Columns[CAMPO_ESTADODOCUMENTOTEXTO].HeaderText = "Estado Doc.";
            displayIndex++;
            
            dgvExpedientes.Columns[CAMPO_EXPEDIENTEID].Visible = true;
            dgvExpedientes.Columns[CAMPO_EXPEDIENTEID].DisplayIndex = displayIndex;
            dgvExpedientes.Columns[CAMPO_EXPEDIENTEID].HeaderText = "Expediente";
            dgvExpedientes.Columns[CAMPO_EXPEDIENTEID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            displayIndex++;

            dgvExpedientes.Columns[CAMPO_FECHACOTIZACION].Visible = true;
            dgvExpedientes.Columns[CAMPO_FECHACOTIZACION].DisplayIndex = displayIndex;
            dgvExpedientes.Columns[CAMPO_FECHACOTIZACION].HeaderText = "Fecha Conf.";
            displayIndex++;

            dgvExpedientes.Columns[CAMPO_AUTORIZADOPORNOMBRE].Visible = true;
            dgvExpedientes.Columns[CAMPO_AUTORIZADOPORNOMBRE].DisplayIndex = displayIndex;
            dgvExpedientes.Columns[CAMPO_AUTORIZADOPORNOMBRE].HeaderText = "Autorizado Por";
            dgvExpedientes.Columns[CAMPO_AUTORIZADOPORNOMBRE].Width = 120;
            displayIndex++;

            dgvExpedientes.Columns[CAMPO_ENVIADOPORNOMBRE].Visible = true;
            dgvExpedientes.Columns[CAMPO_ENVIADOPORNOMBRE].DisplayIndex = displayIndex;
            dgvExpedientes.Columns[CAMPO_ENVIADOPORNOMBRE].HeaderText = "Enviado Por";
            dgvExpedientes.Columns[CAMPO_ENVIADOPORNOMBRE].Width = 120;
            displayIndex++;

            if (this.EsForm)
            {
                dgvExpedientes.Columns[CAMPO_CLIENTEID].Visible = true;
                dgvExpedientes.Columns[CAMPO_CLIENTEID].DisplayIndex = displayIndex;
                dgvExpedientes.Columns[CAMPO_CLIENTEID].HeaderText = "ID Cliente Expediente";
                dgvExpedientes.Columns[CAMPO_CLIENTEID].Width = 80;
                dgvExpedientes.Columns[CAMPO_CLIENTEID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                displayIndex++;

                dgvExpedientes.Columns[CAMPO_CLIENTEPAISID].Visible = true;
                dgvExpedientes.Columns[CAMPO_CLIENTEPAISID].DisplayIndex = displayIndex;
                dgvExpedientes.Columns[CAMPO_CLIENTEPAISID].HeaderText = "ID Pais Cliente";
                dgvExpedientes.Columns[CAMPO_CLIENTEPAISID].Width = 80;
                dgvExpedientes.Columns[CAMPO_CLIENTEPAISID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                displayIndex++;

                dgvExpedientes.Columns[CAMPO_CLIENTEPAISDESCRIP].Visible = true;
                dgvExpedientes.Columns[CAMPO_CLIENTEPAISDESCRIP].DisplayIndex = displayIndex;
                dgvExpedientes.Columns[CAMPO_CLIENTEPAISDESCRIP].HeaderText = "Pais Cliente";
                dgvExpedientes.Columns[CAMPO_CLIENTEPAISDESCRIP].Width = 120;
                displayIndex++;
            }

            dgvExpedientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExpedientes.ItemsPerPage = 10;
            dgvExpedientes.ShowCellToolTips = true;
            
            //dgvExpedientes.ShowFilterRow = true;

            lblRegistrosInfo.Visible = true;
            lblRegistrosInfo.Text = dgvExpedientes.RowCount.ToString() + " filas recuperadas";


            DataGridViewCheckBoxColumn doWork = new DataGridViewCheckBoxColumn();
            doWork.Name = CAMPO_SELECCIONAR;
            doWork.HeaderText = CAMPO_SELECCIONAR;
            doWork.ValueType = typeof(Boolean);
            doWork.FalseValue = false;
            doWork.TrueValue = true;
            doWork.ReadOnly = false;
            doWork.Width = 80;
            dgvExpedientes.Columns.Insert(0, doWork);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if ((this.chkConfirmado.Checked) && (!this.lblAutorizacionVigente.Visible))
            {
                MessageBox.Show("No se pueden agregar tarifas a la cotización debido a que ya fue confirmada.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;

            }

            this.cambiarTab();
            this.limpiarValores();
            this.txtFecha.Text = System.DateTime.Now.ToShortDateString();

            string usuarios = this.DBContext.pa_parametros.FirstOrDefault(a => a.clave == USUARIOS_BERKE).valor;
            List<int> UsuariosIds = usuarios.Split(',').Select(int.Parse).ToList();
            int usuarioID = Convert.ToInt32(VWGContext.Current.Session["UsuarioID"].ToString());
            var match = UsuariosIds.FirstOrDefault(a => a == usuarioID);

            if (match > 0)
            {
                this.tSBAutorizadoPor.KeyMember = usuarioID.ToString();
                this.tSBAutorizadoPor.DisplayMember = VWGContext.Current.Session["NombreUsuario"].ToString();
            }

            //this.txtCantidad.Focus();
            this.FormEditStatus = INSERT;



        }

        private void cambiarTab()
        {
            this.tabControl1.SelectedTab = tbDetalle;

            if (this.dgvTarifas.RowCount > 0)
                this.dgvTarifas.CurrentCell = this.dgvTarifas.Rows[0].Cells[CAMPO_TARIFAFECHA];
            else
                this.limpiarValores();

            this.dgvTarifas.Focus();
        }

        private void cargarExpedientes(DataGridViewRow row)
        {
            if (row.Cells[CAMPO_ACTA].Value != null)
                this.txtActa.Text = row.Cells[CAMPO_ACTA].Value.ToString();

            if (row.Cells[CAMPO_REGISTRONRO].Value != null)
                this.txtRegistro.Text = row.Cells[CAMPO_REGISTRONRO].Value.ToString();
            else
                this.txtRegistro.Text = "";

            if (row.Cells[CAMPO_DENOMINACION].Value != null)
                this.txtDenominacion.Text = row.Cells[CAMPO_DENOMINACION].Value.ToString();

            if (row.Cells[CAMPO_COTIZACIONCABID].Value != null)
                this.txtCotiID.Text = row.Cells[CAMPO_COTIZACIONCABID].Value.ToString();
            else
                this.txtCotiID.Text = "";

            if (row.Cells[CAMPO_AUTORIZADOPORNOMBRE].Value != null)
            {
                this.tSBAutorizadoPor.KeyMember = row.Cells[CAMPO_AUTORIZADOPOR].Value.ToString();
                this.tSBAutorizadoPor.DisplayMember = row.Cells[CAMPO_AUTORIZADOPORNOMBRE].Value.ToString();
            }
            else
            {
                this.tSBAutorizadoPor.KeyMember = "";
                this.tSBAutorizadoPor.DisplayMember = "";
            }

            if (row.Cells[CAMPO_ENVIADOPORNOMBRE].Value != null)
            {
                this.tSBEnviadoPor.KeyMember = row.Cells[CAMPO_ENVIADOPOR].Value.ToString();
                this.tSBEnviadoPor.DisplayMember = row.Cells[CAMPO_ENVIADOPORNOMBRE].Value.ToString();
            }
            else
            {
                this.tSBEnviadoPor.KeyMember = "";
                this.tSBEnviadoPor.DisplayMember = "";
            }

            if (row.Cells[CAMPO_FECHACOTIZACION].Value != null)
                this.txtFechaCotiCab.Text = Convert.ToDateTime(row.Cells[CAMPO_FECHACOTIZACION].Value).ToShortDateString();
            else
                this.txtFechaCotiCab.Text = "";

            if (row.Cells[CAMPO_CONFIRMADO].Value != null)
                this.chkConfirmado.Checked = (bool)row.Cells[CAMPO_CONFIRMADO].Value;
            else
                this.chkConfirmado.Checked = false;


            this.txtExpedienteID.Text = row.Cells[CAMPO_EXPEDIENTEID].Value.ToString();
            this.txtTramiteID.Text = row.Cells[CAMPO_TRAMITEID].Value.ToString();
            this.txtTramiteDescrip.Text = row.Cells[CAMPO_TRAMITEDESCRIP].Value.ToString();

            if (row.Cells[CAMPO_NRODOCUMENTO].Value != null)
                this.txtNroPresupuesto.Text = row.Cells[CAMPO_NRODOCUMENTO].Value.ToString();
            else
                this.txtNroPresupuesto.Text = "";

            if (row.Cells[CAMPO_ESTADODOCUMENTOTEXTO].Value != null)
                this.txtEstado.Text = row.Cells[CAMPO_ESTADODOCUMENTOTEXTO].Value.ToString();
            else
                this.txtEstado.Text = string.Empty;

            if (row.Cells[CAMPO_FECHADOCUMENTO].Value != null)
                this.txtFechaDocumento.Text = ((DateTime)row.Cells[CAMPO_FECHADOCUMENTO].Value).ToShortDateString();
            else
                this.txtFechaDocumento.Text = "";

            if (row.Cells[CAMPO_OBSERVACION].Value != null)
                this.txtObservacion.Text = row.Cells[CAMPO_OBSERVACION].Value.ToString();
            else
                this.txtObservacion.Text = "";

            this.txtRecargoAT.Text = String.Format("{0:0.00}", row.Cells[CAMPO_MONTORECARGOAT].Value.ToString());

            string estado = row.Cells[CAMPO_ESTADODOCUMENTO].Value != null ?
                                            row.Cells[CAMPO_ESTADODOCUMENTO].Value.ToString()
                                            : null;
            Nullable<int> cotizacionCabID = null;

            if (this.txtCotiID.Text != String.Empty)
                cotizacionCabID = Convert.ToInt32(this.txtCotiID.Text);

            this.obtenerTarifasxExpediente(Convert.ToInt32(this.txtExpedienteID.Text), this.txtNroPresupuesto.Text, estado, cotizacionCabID);

            if (this.EsForm)
            {
                this.ClienteID = (int)row.Cells[CAMPO_CLIENTEID].Value;
                this.EsClienteMultiple();
            }

            if (this.esMultiple)
            {
                this.getClientexTramite(Convert.ToInt32(this.txtTramiteID.Text));
            }
            else
            {
                //if (this.EsForm)
                //{
                //    this.txtClienteFacturacionID.Text = row.Cells[CAMPO_CLIENTEID].Value.ToString();
                //    this.txtClienteFacturacionNombre.Text = row.Cells[CAMPO_CLIENTENOMBRE].Value.ToString();
                //    this.tSBClienteEdit.KeyMember = row.Cells[CAMPO_CLIENTEID].Value.ToString();
                //    this.tSBClienteEdit.DisplayMember = row.Cells[CAMPO_CLIENTENOMBRE].Value.ToString();
                //}
                //else
                //{
                //    this.txtClienteFacturacionID.Text = this.tSBCliente.KeyMember;
                //    this.txtClienteFacturacionNombre.Text = this.tSBCliente.DisplayMember;
                //    this.tSBClienteEdit.KeyMember = this.tSBCliente.KeyMember;
                //    this.tSBClienteEdit.DisplayMember = this.tSBCliente.DisplayMember;
                //}
            }

            if (row.Cells[CAMPO_ORDENTRABAJOID].Value != null)
                this.txtOTID.Text = row.Cells[CAMPO_ORDENTRABAJOID].Value.ToString();
            else
                this.txtOTID.Text = "";

            this.lblAutorizacionVigente.Visible = (bool)row.Cells[CAMPO_TIENEAUTORIZACIONVIG].Value;
                       

            //MessageBox.Show("ClienteID: " + this.ClienteID.ToString() + Environment.NewLine +
            //                "ClienteMultipleID:" + this.ClienteMultipleID.ToString());
        }

        private void dgvExpedientes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.cargarExpedientes(((DataGridView)sender).Rows[e.RowIndex]);
            this.txtEditStatus_TextChanged(sender, e);

            //if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_ACTA].Value != null)
            //    this.txtActa.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_ACTA].Value.ToString();
            
            //if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_REGISTRONRO].Value != null)
            //    this.txtRegistro.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_REGISTRONRO].Value.ToString();
            //else
            //    this.txtRegistro.Text = "";
            
            //if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_DENOMINACION].Value != null)
            //    this.txtDenominacion.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_DENOMINACION].Value.ToString();

            //if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_COTIZACIONCABID].Value != null)
            //    this.txtCotiID.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_COTIZACIONCABID].Value.ToString();
            //else
            //    this.txtCotiID.Text = "";

            //if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_AUTORIZADOPORNOMBRE].Value != null)
            //{
            //    this.tSBAutorizadoPor.KeyMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_AUTORIZADOPOR].Value.ToString();
            //    this.tSBAutorizadoPor.DisplayMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_AUTORIZADOPORNOMBRE].Value.ToString();
            //}
            //else
            //{
            //    this.tSBAutorizadoPor.KeyMember = "";
            //    this.tSBAutorizadoPor.DisplayMember = "";
            //}

            //if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_ENVIADOPORNOMBRE].Value != null)
            //{
            //    this.tSBEnviadoPor.KeyMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_ENVIADOPOR].Value.ToString();
            //    this.tSBEnviadoPor.DisplayMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_ENVIADOPORNOMBRE].Value.ToString();
            //}
            //else
            //{
            //    this.tSBEnviadoPor.KeyMember = "";
            //    this.tSBEnviadoPor.DisplayMember = "";
            //}

            //if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_FECHACOTIZACION].Value != null)
            //    this.txtFechaCotiCab.Text = Convert.ToDateTime(((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_FECHACOTIZACION].Value).ToShortDateString();
            //else
            //    this.txtFechaCotiCab.Text = "";

            //if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_CONFIRMADO].Value != null)
            //    this.chkConfirmado.Checked = (bool)((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_CONFIRMADO].Value;
            //else
            //    this.chkConfirmado.Checked = false;


            //this.txtExpedienteID.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_EXPEDIENTEID].Value.ToString();
            //this.txtTramiteID.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TRAMITEID].Value.ToString();
            //this.txtTramiteDescrip.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TRAMITEDESCRIP].Value.ToString();

            //if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_NRODOCUMENTO].Value != null)
            //    this.txtNroPresupuesto.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_NRODOCUMENTO].Value.ToString();
            //else
            //    this.txtNroPresupuesto.Text = "";

            //if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_ESTADODOCUMENTOTEXTO].Value != null)
            //    this.txtEstado.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_ESTADODOCUMENTOTEXTO].Value.ToString();
            //else
            //    this.txtEstado.Text = string.Empty;

            //if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_FECHADOCUMENTO].Value != null)
            //    this.txtFechaDocumento.Text = ((DateTime)((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_FECHADOCUMENTO].Value).ToShortDateString();
            //else
            //    this.txtFechaDocumento.Text = "";

            //if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_OBSERVACION].Value != null)
            //    this.txtObservacion.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_OBSERVACION].Value.ToString();
            //else
            //    this.txtObservacion.Text = "";

            //this.txtRecargoAT.Text = String.Format("{0:0.00}", ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_MONTORECARGOAT].Value.ToString());

            //string estado = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_ESTADODOCUMENTO].Value != null ?
            //                                ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_ESTADODOCUMENTO].Value.ToString()
            //                                : null;
            //Nullable<int> cotizacionCabID = null;

            //if (this.txtCotiID.Text != String.Empty )
            //    cotizacionCabID = Convert.ToInt32(this.txtCotiID.Text);

            //this.obtenerTarifasxExpediente(Convert.ToInt32(this.txtExpedienteID.Text), this.txtNroPresupuesto.Text, estado, cotizacionCabID);

            //if (this.EsForm)
            //{
            //    this.ClienteID = (int)((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_CLIENTEID].Value;
            //    this.EsClienteMultiple();
            //}

            //if (this.esMultiple)
            //{
            //    this.getClientexTramite(Convert.ToInt32(this.txtTramiteID.Text));
            //}
            //else
            //{
            //    //if (this.EsForm)
            //    //{
            //    //    this.txtClienteFacturacionID.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_CLIENTEID].Value.ToString();
            //    //    this.txtClienteFacturacionNombre.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_CLIENTENOMBRE].Value.ToString();
            //    //    this.tSBClienteEdit.KeyMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_CLIENTEID].Value.ToString();
            //    //    this.tSBClienteEdit.DisplayMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_CLIENTENOMBRE].Value.ToString();
            //    //}
            //    //else
            //    //{
            //    //    this.txtClienteFacturacionID.Text = this.tSBCliente.KeyMember;
            //    //    this.txtClienteFacturacionNombre.Text = this.tSBCliente.DisplayMember;
            //    //    this.tSBClienteEdit.KeyMember = this.tSBCliente.KeyMember;
            //    //    this.tSBClienteEdit.DisplayMember = this.tSBCliente.DisplayMember;
            //    //}
            //}

            //if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_ORDENTRABAJOID].Value != null)
            //    this.txtOTID.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_ORDENTRABAJOID].Value.ToString();
            //else
            //    this.txtOTID.Text = "";

            //this.lblAutorizacionVigente.Visible = (bool)((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_TIENEAUTORIZACIONVIG].Value;

            //this.txtEditStatus_TextChanged(sender, e);

            ////MessageBox.Show("ClienteID: " + this.ClienteID.ToString() + Environment.NewLine +
            ////                "ClienteMultipleID:" + this.ClienteMultipleID.ToString());

        }

        private void obtenerTarifasxExpediente(int expedienteid, string nrodocumento, string estado, Nullable<int> cotizacionCabID)
        {
            
            //((IObjectContextAdapter)this.DBContext).ObjectContext.Refresh(System.Data.Entity.Core.Objects.RefreshMode.ClientWins, this.DBContext.tc_tarifascliente);


            //var query = (from tc_tarifasCliente in this.DBContext.tc_tarifascliente
            //             join tarifas in this.DBContext.Tarifas
            //               on tc_tarifasCliente.tc_tarifaid equals tarifas.ID
            //             join monedas in this.DBContext.Moneda
            //               on tc_tarifasCliente.tc_monedaid equals monedas.ID
            //             select new
            //             {
            //                 TarifaID = tarifas.ID,
            //                 TarifaDescripcion = tarifas.Descripcion,
            //                 Fecha = tc_tarifasCliente.tc_fecha,
            //                 ClienteID = tc_tarifasCliente.tc_clienteid,
            //                 PrecioUnitario = tarifas.Monto,
            //                 TipoUnidadDescuento = tc_tarifasCliente.tc_tipounidaddesc,
            //                 MontoDescuento = tc_tarifasCliente.tc_descuentomonto,
            //                 PorcentajeDescuento = tc_tarifasCliente.tc_descuentoporcentaje,
            //                 TipoUnidadImpuesto = tc_tarifasCliente.tc_tipounidadimp,
            //                 MontoImpuesto = tc_tarifasCliente.tc_impuestomonto,
            //                 PorcentajeImpuesto = tc_tarifasCliente.tc_impuestoporcentaje,
            //                 ExpedienteID = tc_tarifasCliente.tc_expedienteid,
            //                 Cantidad = tc_tarifasCliente.tc_cantidad,
            //                 Total = tc_tarifasCliente.tc_total,
            //                 MonedaID = tc_tarifasCliente.tc_monedaid,
            //                 MonedaDescrip = monedas.Descripcion,
            //                 PrecioVenta = tc_tarifasCliente.tc_precioventa,
            //                 TarifaClienteID = tc_tarifasCliente.tc_id,
            //                 EsEspecial = tc_tarifasCliente.tc_especial,
            //                 TotalConRecargo = tc_tarifasCliente.tc_totalconrecargo,
            //                 RecargoNeto = tc_tarifasCliente.tc_recargoneto
            //             })
            //            .Where(a => a.ExpedienteID == expedienteid)
            //            .OrderByDescending(a => a.Fecha)
            //            .ToList();

            var query = nrodocumento != String.Empty ? this.listaExpe.Where(a => a.ExpedienteID == expedienteid && a.NroDocumento == nrodocumento && a.EstadoDocumento == estado && a.CotizacionCabID == cotizacionCabID).OrderByDescending(a => a.TarifaFecha).ToList()
                                                     : this.listaExpe.Where(a => a.ExpedienteID == expedienteid && a.CotizacionCabID == cotizacionCabID).OrderByDescending(a => a.TarifaFecha).ToList();
                        
            this.dgvTarifas.DataSource = query;
            this.FormatearGrillaTarifas();
            this.calcularGrandTotal();            
                        
        }

        private void cargarTarifasxCliente(DataGridViewRow row)
        {
            this.limpiarValores();

            row = row == null ? this.dgvTarifas.Rows[0] : row;

            if (row.Cells[CAMPO_TARIFAID].Value != null)
            {
                //this.cbMoneda.SelectedValue = (int)row.Cells[CAMPO_TARIFAMONEDADID].Value;
                this.tSBMoneda.KeyMember = row.Cells[CAMPO_TARIFAMONEDADID].Value.ToString();
                this.tSBMoneda.DisplayMember = row.Cells[CAMPO_TARIFAMONEDADDESCRIP].Value.ToString();
                //this.cbTarifas.SelectedValue = (int)row.Cells[CAMPO_TARIFAID].Value;
                this.tSBTarifa.KeyMember = row.Cells[CAMPO_TARIFAID].Value.ToString();
                this.tSBTarifa.DisplayMember = row.Cells[CAMPO_TARIFADESCRIPCION].Value.ToString();
                this.txtFecha.Text = Convert.ToDateTime(row.Cells[CAMPO_TARIFAFECHA].Value.ToString()).ToShortDateString();
                this.txtMonto.Text = String.Format("{0:0.00}", row.Cells[CAMPO_TARIFAPRECIOUNITARIO].Value.ToString());
                this.txtCantidad.Text = String.Format("{0:0.00}", row.Cells[CAMPO_TARIFACANTIDAD].Value.ToString());
                this.txtPrecioVenta.Text = String.Format("{0:0.00}", row.Cells[CAMPO_TARIFAPRECIOVENTA].Value.ToString());
                this.cbTipoUnidadDescuento.SelectedIndex = (Convert.ToBoolean(row.Cells[CAMPO_TARIFATIPOUNIDDESC].Value)) ? 1 : 0;
                this.txtMontoDescuento.Text = String.Format("{0:0.00}", row.Cells[CAMPO_TARIFAMONTODESCUENTO].Value.ToString());
                this.txtPorcDescuento.Text = String.Format("{0:0.00}", row.Cells[CAMPO_TARIFAPORCDESC].Value.ToString());
                this.cbTipoUnidadImpuesto.SelectedIndex = (Convert.ToBoolean(row.Cells[CAMPO_TARIFATIPOUNIDIMP].Value)) ? 1 : 0;
                this.txtMontoImp.Text = String.Format("{0:0.00}", row.Cells[CAMPO_TARIFAMONTOIMPUESTO].Value.ToString());
                this.txtPorcImp.Text = String.Format("{0:0.00}", row.Cells[CAMPO_TARIFAPORCIMP].Value.ToString());
                this.txtTotal.Text = String.Format("{0:0.00}", row.Cells[CAMPO_TARIFATOTAL].Value.ToString());
                this.chEspecial.Checked = (bool)row.Cells[CAMPO_TARIFAESPECIAL].Value;
                this.txtTotalConRecargo.Text = String.Format("{0:0.00}", row.Cells[CAMPO_TARIFATOTALCONRECARGO].Value.ToString());

                this.tSBClienteEdit.KeyMember = row.Cells[CAMPO_TARIFACLIENTEID].Value.ToString();
                this.tSBClienteEdit.DisplayMember = row.Cells[CAMPO_TARIFACLIENTENOMBRE].Value.ToString();
            }
        }

        private void limpiarValores()
        {
            //this.cbMoneda.SelectedValue = -1;
            //this.cbTarifas.SelectedValue = -1;
            this.tSBMoneda.Clear();
            this.tSBTarifa.Clear();
            this.txtFecha.Text = "";
            this.txtMonto.Text = "";
            this.txtCantidad.Text = "";
            this.cbTipoUnidadDescuento.SelectedIndex = 0;
            this.txtMontoDescuento.Text = "";
            this.txtPorcDescuento.Text = "";
            this.cbTipoUnidadImpuesto.SelectedIndex = 0;
            this.txtMontoImp.Text = "";
            this.txtPorcImp.Text = "";
            this.txtTotal.Text = "";
            this.txtPrecioVenta.Text = "";
            this.chEspecial.Checked = false;
            this.txtTotalConRecargo.Text = "";            
        }

        private void FormatearGrillaTarifas()
        {
            this.dgvTarifas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvTarifas.ReadOnly = true;

            foreach (DataGridViewColumn col in this.dgvTarifas.Columns)
            {
                col.Visible = false;
            }

            dgvTarifas.Columns[CAMPO_TARIFAFECHA].Visible = true;
            dgvTarifas.Columns[CAMPO_TARIFAFECHA].DisplayIndex = 0;
            dgvTarifas.Columns[CAMPO_TARIFAFECHA].HeaderText = "Fecha";
            dgvTarifas.Columns[CAMPO_TARIFAFECHA].Width = 100;
            dgvTarifas.Columns[CAMPO_TARIFAFECHA].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTarifas.Columns[CAMPO_TARIFAFECHA].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvTarifas.Columns[CAMPO_TARIFADESCRIPCION].Visible = true;
            dgvTarifas.Columns[CAMPO_TARIFADESCRIPCION].DisplayIndex = 1;
            dgvTarifas.Columns[CAMPO_TARIFADESCRIPCION].HeaderText = "Descripción";
            dgvTarifas.Columns[CAMPO_TARIFADESCRIPCION].Width = 250;

            dgvTarifas.Columns[CAMPO_TARIFAPRECIOUNITARIO].Visible = true;
            dgvTarifas.Columns[CAMPO_TARIFAPRECIOUNITARIO].DisplayIndex = 2;
            dgvTarifas.Columns[CAMPO_TARIFAPRECIOUNITARIO].HeaderText = "Prec. Unit.";
            dgvTarifas.Columns[CAMPO_TARIFAPRECIOUNITARIO].Width = 90;
            dgvTarifas.Columns[CAMPO_TARIFAPRECIOUNITARIO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvTarifas.Columns[CAMPO_TARIFACANTIDAD].Visible = true;
            dgvTarifas.Columns[CAMPO_TARIFACANTIDAD].DisplayIndex = 3;
            dgvTarifas.Columns[CAMPO_TARIFACANTIDAD].HeaderText = "Cantidad";
            dgvTarifas.Columns[CAMPO_TARIFACANTIDAD].Width = 90;
            dgvTarifas.Columns[CAMPO_TARIFACANTIDAD].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvTarifas.Columns[CAMPO_TARIFAPRECIOVENTA].Visible = true;
            dgvTarifas.Columns[CAMPO_TARIFAPRECIOVENTA].DisplayIndex = 4;
            dgvTarifas.Columns[CAMPO_TARIFAPRECIOVENTA].HeaderText = "Prec. Venta";
            dgvTarifas.Columns[CAMPO_TARIFAPRECIOVENTA].Width = 90;
            dgvTarifas.Columns[CAMPO_TARIFAPRECIOVENTA].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvTarifas.Columns[CAMPO_TARIFAMONTODESCUENTO].Visible = true;
            dgvTarifas.Columns[CAMPO_TARIFAMONTODESCUENTO].DisplayIndex = 5;
            dgvTarifas.Columns[CAMPO_TARIFAMONTODESCUENTO].HeaderText = "Monto Desc.";
            dgvTarifas.Columns[CAMPO_TARIFAMONTODESCUENTO].Width = 90;
            dgvTarifas.Columns[CAMPO_TARIFAMONTODESCUENTO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvTarifas.Columns[CAMPO_TARIFAPORCDESC].Visible = true;
            dgvTarifas.Columns[CAMPO_TARIFAPORCDESC].DisplayIndex = 6;
            dgvTarifas.Columns[CAMPO_TARIFAPORCDESC].HeaderText = "Porc. Desc.";
            dgvTarifas.Columns[CAMPO_TARIFAPORCDESC].Width = 90;
            dgvTarifas.Columns[CAMPO_TARIFAPORCDESC].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvTarifas.Columns[CAMPO_TARIFAMONTOIMPUESTO].Visible = true;
            dgvTarifas.Columns[CAMPO_TARIFAMONTOIMPUESTO].DisplayIndex = 7;
            dgvTarifas.Columns[CAMPO_TARIFAMONTOIMPUESTO].HeaderText = "Monto Imp.";
            dgvTarifas.Columns[CAMPO_TARIFAMONTOIMPUESTO].Width = 90;
            dgvTarifas.Columns[CAMPO_TARIFAMONTOIMPUESTO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvTarifas.Columns[CAMPO_TARIFAPORCIMP].Visible = true;
            dgvTarifas.Columns[CAMPO_TARIFAPORCIMP].DisplayIndex = 8;
            dgvTarifas.Columns[CAMPO_TARIFAPORCIMP].HeaderText = "Porc. Imp.";
            dgvTarifas.Columns[CAMPO_TARIFAPORCIMP].Width = 90;
            dgvTarifas.Columns[CAMPO_TARIFAPORCIMP].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvTarifas.Columns[CAMPO_TARIFATOTAL].Visible = true;
            dgvTarifas.Columns[CAMPO_TARIFATOTAL].DisplayIndex = 9;
            dgvTarifas.Columns[CAMPO_TARIFATOTAL].HeaderText = "Total";
            dgvTarifas.Columns[CAMPO_TARIFATOTAL].Width = 90;
            dgvTarifas.Columns[CAMPO_TARIFATOTAL].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvTarifas.Columns[CAMPO_TARIFARECARGONETO].Visible = true;
            dgvTarifas.Columns[CAMPO_TARIFARECARGONETO].DisplayIndex = 10;
            dgvTarifas.Columns[CAMPO_TARIFARECARGONETO].HeaderText = "Rec. Neto";
            dgvTarifas.Columns[CAMPO_TARIFARECARGONETO].Width = 95;
            dgvTarifas.Columns[CAMPO_TARIFARECARGONETO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvTarifas.Columns[CAMPO_TARIFATOTALCONRECARGO].Visible = true;
            dgvTarifas.Columns[CAMPO_TARIFATOTALCONRECARGO].DisplayIndex = 11;
            dgvTarifas.Columns[CAMPO_TARIFATOTALCONRECARGO].HeaderText = @"Tot. c/ Rec.";
            dgvTarifas.Columns[CAMPO_TARIFATOTALCONRECARGO].Width = 95;
            dgvTarifas.Columns[CAMPO_TARIFATOTALCONRECARGO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void permitirEdicion(bool editar)
        {
            if (!this.EditarSoloRecargoAT)
            {
                //this.cbTarifas.Enabled = editar;
                //this.cbMoneda.Enabled = editar;
                this.tSBMoneda.Editable = editar;
                this.tSBTarifa.Editable = editar;
                this.cbTipoUnidadDescuento.Enabled = editar;
                this.cbTipoUnidadImpuesto.Enabled = editar;

                if (this.FormEditStatus == INSERT)
                {
                    this.cbTipoUnidadDescuento.SelectedIndex = 0;
                    this.cbTipoUnidadImpuesto.SelectedIndex = 0;
                }

                this.txtCantidad.ReadOnly = !editar;
                this.txtPrecioVenta.ReadOnly = !editar;
                this.txtMontoDescuento.ReadOnly = !editar;
                this.txtPorcDescuento.ReadOnly = !editar;
                this.txtMontoImp.ReadOnly = !editar;
                this.txtPorcImp.ReadOnly = !editar;
                this.chEspecial.Enabled = editar;
                this.chkRedondear.Enabled = editar;

                this.txtFechaCotiCab.ReadOnly = !editar;
                this.txtObservacion.ReadOnly = !editar;
                this.tSBAutorizadoPor.Editable = editar;
                this.tSBEnviadoPor.Editable = editar;
                //this.tSBClienteEdit.Editable = editar;

                this.txtTotalConRecargo.ReadOnly = !editar;

                this.txtRecargoAT.ReadOnly = !editar;
            }
            else
            {
                //this.cbTarifas.Enabled = editar;
                //this.cbMoneda.Enabled = editar;
                this.txtRecargoAT.ReadOnly = false;
            }
        }

        private void cbTipoUnidadImpuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.FormEditStatus != BROWSE)
            {
                if (this.cbTipoUnidadImpuesto.SelectedIndex == 0)
                {
                    this.txtMontoImp.ReadOnly = false;
                    this.txtMontoImp.BackColor = SystemColors.Window;
                    this.txtPorcImp.ReadOnly = true;
                    this.txtPorcImp.BackColor = SystemColors.Control;
                    this.txtMontoImp.Focus();
                }
                else if (this.cbTipoUnidadImpuesto.SelectedIndex == 1)
                {
                    this.txtMontoImp.ReadOnly = true;
                    this.txtMontoImp.BackColor = SystemColors.Control;
                    this.txtPorcImp.ReadOnly = false;
                    this.txtPorcImp.BackColor = SystemColors.Window;
                    this.txtPorcImp.Focus();
                }
                else
                {
                    this.txtMontoImp.ReadOnly = true;
                    this.txtMontoImp.BackColor = SystemColors.Control;
                    this.txtPorcImp.ReadOnly = true;
                    this.txtPorcImp.BackColor = SystemColors.Control;
                }
            }
        }

        private void cbTipoUnidadDescuento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.FormEditStatus != BROWSE)
            {
                if (this.cbTipoUnidadDescuento.SelectedIndex == 0)
                {
                    this.txtMontoDescuento.ReadOnly = false;
                    this.txtMontoDescuento.BackColor = SystemColors.Window;
                    this.txtPorcDescuento.ReadOnly = true;
                    this.txtPorcDescuento.BackColor = SystemColors.Control;
                    this.txtMontoDescuento.Focus();
                }
                else if (this.cbTipoUnidadDescuento.SelectedIndex == 1)
                {
                    this.txtMontoDescuento.ReadOnly = true;
                    this.txtMontoDescuento.BackColor = SystemColors.Control;
                    this.txtPorcDescuento.ReadOnly = false;
                    this.txtPorcDescuento.BackColor = SystemColors.Window;
                    this.txtPorcDescuento.Focus();
                }
                else
                {
                    this.txtMontoDescuento.ReadOnly = true;
                    this.txtMontoDescuento.BackColor = SystemColors.Control;
                    this.txtPorcDescuento.ReadOnly = true;
                    this.txtPorcDescuento.BackColor = SystemColors.Control;
                }
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //Validar moneda, no se pueden ingresar monedas diversas en la misma cotización
            string valMsg = String.Empty;
            if (this.ExistenMonedasDiversas(Convert.ToInt32(this.tSBMoneda.KeyMember)))
            {
                valMsg = "- Existen tarifas con monedas distintas." + Environment.NewLine;
                //MessageBox.Show("Existen tarifas con monedas distintas.",
                //                "Información",
                //                MessageBoxButtons.OK,
                //                MessageBoxIcon.Information);
                //return;
            }

            string caption = String.Empty;
            string message = String.Empty;

            if (this.FormEditStatus == INSERT)
            {
                caption = "Inserción de nuevo de registro";
                message = "Se insertará un nuevo registro ¿Desea continuar?";
            }
            else if (this.FormEditStatus == EDIT)
            {
                caption = "Modificación de registro";
                message = "Se modificará el registro actual ¿Desea continuar?";
            }

            if (valMsg != String.Empty)
            {
                message = "Advertencias a tener en cuenta:" + Environment.NewLine +
                          valMsg +
                          "¿Desea continuar de todas formas?";
            }
            
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(DialogHandler));
        }

        private bool ExistenMonedasDiversas(int monedaID)
        {
            bool Result = false;

            if (this.dgvTarifas.Rows.Count > 0)
            {
                List<int> listaMonedaID = new List<int>();
                listaMonedaID.Add(monedaID);
                foreach (DataGridViewRow row in this.dgvTarifas.Rows)
                {
                    if ((row.Cells[CAMPO_TARIFAMONEDADID].Value != null) && (!listaMonedaID.Contains((int)row.Cells[CAMPO_TARIFAMONEDADID].Value)))
                        listaMonedaID.Add((int)row.Cells[CAMPO_TARIFAMONEDADID].Value);
                }

                if (listaMonedaID.Count > 1)
                    Result = true;

            }

            return Result;
        }

        private void DialogHandler(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    if (this.FormEditStatus != BROWSE)
                        this.GuardarRegistro();
                    else
                        this.EliminarRegistro();
                }
            }
        }


        #region Eliminar Registro
        private void EliminarRegistro()
        {
            bool success = false;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                //using (TransactionScope transaction = new TransactionScope())
                {
                    try
                    {
                        this.eliminarTarifa(context);
                        //transaction.Complete();
                        context.SaveChanges();

                        int cotiCab;
                        if (Int32.TryParse(this.txtCotiID.Text, out cotiCab))
                        {
                            if (context.tc_tarifascliente.Where(a => a.tc_cotizacioncabid == cotiCab).Count() == 0)
                            {
                                context.cc_cotizacioncab.First(a => a.cc_cotizacioncabid == cotiCab).cc_expedienteid = null;
                                context.SaveChanges();
                            }
                        }

                        if (this.lblAutorizacionVigente.Visible)
                        {
                            //int cotiCab = Convert.ToInt32(this.txtCotiID.Text);
                            List<ca_clienteantecedente> chList = context.ca_clienteantecedente
                                                                .Where(a => a.ca_cotizacioncabid == cotiCab
                                                                        && a.ca_tipoantecedente == "A").ToList();

                            foreach (var item in chList)
                            {
                                item.ca_observacion = context.getDescripTarifaTable(item.ca_cotizacioncabid).FirstOrDefault().ToString();
                            }
                            context.SaveChanges();
                        }

                        

                        dbContextTransaction.Commit();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        //transaction.Dispose();
                        dbContextTransaction.Rollback();
                        MessageBox.Show("Ocurrió un error al eliminar el registro: "
                                        + ex.Message + Environment.NewLine
                                        + ex.InnerException,
                                        "Error al eliminar los datos",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Stop);
                    }
                }
                if (success)
                {
                    //this.limpiarValores();
                    //this.obtenerTarifasxExpediente(Convert.ToInt32(this.txtExpedienteID.Text), this.txtNroPresupuesto.Text);
                    this.btnFiltrar.PerformClick();
                    if (this.dgvTarifas.RowCount > 0)
                    {
                        this.dgvTarifas.CurrentCell = this.dgvTarifas.Rows[0].Cells[CAMPO_TARIFAFECHA];
                    }
                    else
                    {
                        this.limpiarValores();
                    }

                    this.FormEditStatus = BROWSE;
                    this.manejarBotonesTab(true);
                    MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.calcularGrandTotal();
                    this.dgvTarifas.Focus();

                }
            }
        }

        private void eliminarTarifa(BerkeDBEntities context = null)
        {
            int tcID = Convert.ToInt32(this.dgvTarifas.CurrentRow.Cells[CAMPO_TARIFAXCLIENTEID].Value.ToString());
            tc_tarifascliente tarifa = context.tc_tarifascliente.First(a => a.tc_id == tcID);
            context.tc_tarifascliente.Remove(tarifa);
        }
        #endregion Eliminar Registro
        
        #region Guardar Registro
        private void GuardarRegistro()
        {
            bool success = false;
            
            tc_tarifascliente tc = null;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (!this.EditarSoloRecargoAT)
                        {
                            tc = this.guardarTarifa(context);
                            //context.SaveChanges();
                            //Abierto con autorización
                            if (this.lblAutorizacionVigente.Visible)
                            {
                                int cotiCabID = Convert.ToInt32(this.txtCotiID.Text);

                                List<ca_clienteantecedente> chList = context.ca_clienteantecedente
                                                                    .Where(a => a.ca_cotizacioncabid == cotiCabID //tc.tc_cotizacioncabid.Value
                                                                            && a.ca_tipoantecedente == "A").ToList();

                                foreach (var item in chList)
                                {
                                    item.ca_observacion = context.getDescripTarifaTable(item.ca_cotizacioncabid).FirstOrDefault().ToString();
                                }
                                //context.SaveChanges();
                                //context.cc_cotizacioncab.First(a => a.cc_cotizacioncabid == cotiCabID).cc_recargoatmonto = Convert.ToDecimal(this.txtRecargoAT.Text);                            
                            }
                        }
                        else
                        {
                            int cotiCabID = Convert.ToInt32(this.txtCotiID.Text);
                            context.cc_cotizacioncab.First(a => a.cc_cotizacioncabid == cotiCabID).cc_recargoatmonto = Convert.ToDecimal(this.txtRecargoAT.Text);
                        }

                        context.SaveChanges();
                        dbContextTransaction.Commit();

                        if (!this.EditarSoloRecargoAT)
                            this.txtCotiID.Text = tc.tc_cotizacioncabid.HasValue ? tc.tc_cotizacioncabid.Value.ToString() : "";

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
                    if (success)
                    {
                        try
                        {
                            int rowIX = -1;
                            if (this.dgvTarifas.RowCount > 0)
                                rowIX = this.dgvTarifas.CurrentRow.Index;

                            //this.obtenerTarifasxExpediente(Convert.ToInt32(this.txtExpedienteID.Text), this.txtNroPresupuesto.Text);

                            int ix = this.dgvExpedientes.CurrentRow.Index;
                            this.btnFiltrar.PerformClick();
                            this.cargarExpedientes(this.dgvExpedientes.Rows[ix]);
                            
                            if (this.dgvTarifas.RowCount > 0)
                            {
                                this.dgvExpedientes.CurrentCell = this.dgvExpedientes.Rows[ix].Cells[CAMPO_CLIENTEID];
                                this.dgvExpedientes.Rows[ix].Selected = true;
                                if (this.FormEditStatus == INSERT)
                                {
                                    //this.cargarTarifasxCliente(this.dgvTarifas.Rows[this.dgvTarifas.RowCount - 1]);
                                    this.dgvTarifas.CurrentCell = this.dgvTarifas.Rows[this.dgvTarifas.RowCount - 1].Cells[CAMPO_TARIFAFECHA];
                                    this.dgvTarifas.Focus();
                                }
                                else if (this.FormEditStatus == EDIT)
                                {
                                    //this.cargarTarifasxCliente(this.dgvTarifas.Rows[rowIX]);
                                    this.dgvTarifas.CurrentCell = this.dgvTarifas.Rows[rowIX].Cells[CAMPO_TARIFAFECHA];
                                    this.dgvTarifas.Focus();
                                }
                            }
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                                                
                        this.FormEditStatus = BROWSE;
                        MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.calcularGrandTotal();
                        //this.dgvTarifas.Focus();
                        
                    }
                }
                
            }
            
        }

        private tc_tarifascliente guardarTarifa(BerkeDBEntities context = null)
        {
            tc_tarifascliente tarifaxcliente = new tc_tarifascliente();
            if (this.FormEditStatus == EDIT)
            {
                int tcID = Convert.ToInt32(this.dgvTarifas.CurrentRow.Cells[CAMPO_TARIFAXCLIENTEID].Value.ToString());
                tarifaxcliente = context.tc_tarifascliente.First(b => b.tc_id == tcID);
                tarifaxcliente.tc_tarifaid = Convert.ToInt32(this.tSBTarifa.KeyMember);
                tarifaxcliente.tc_clienteid = this.ClienteID; // Convert.ToInt32(this.tSBClienteEdit.KeyMember);
                tarifaxcliente.tc_expedienteid = Convert.ToInt32(this.txtExpedienteID.Text);
                tarifaxcliente.tc_fecha = Convert.ToDateTime(this.txtFecha.Text);
                tarifaxcliente.tc_monto = Convert.ToDecimal(this.txtMonto.Text);
                tarifaxcliente.tc_tipounidaddesc = this.cbTipoUnidadDescuento.SelectedIndex == 0 ? false : true;
                tarifaxcliente.tc_descuentomonto = Convert.ToDecimal(this.txtMontoDescuento.Text);
                tarifaxcliente.tc_descuentoporcentaje = Convert.ToDecimal(this.txtPorcDescuento.Text);
                tarifaxcliente.tc_tipounidadimp = this.cbTipoUnidadImpuesto.SelectedIndex == 0 ? false : true;
                tarifaxcliente.tc_impuestomonto = Convert.ToDecimal(this.txtMontoImp.Text);
                tarifaxcliente.tc_impuestoporcentaje = Convert.ToDecimal(this.txtPorcImp.Text);
                tarifaxcliente.tc_cantidad = Convert.ToDecimal(this.txtCantidad.Text);
                tarifaxcliente.tc_precioventa = Convert.ToDecimal(this.txtPrecioVenta.Text);
                tarifaxcliente.tc_total = Convert.ToDecimal(this.txtTotal.Text);
                tarifaxcliente.tc_tramiteid = Convert.ToInt32(this.txtTramiteID.Text);
                tarifaxcliente.tc_especial = this.chEspecial.Checked;
                tarifaxcliente.tc_monedaid = Convert.ToInt32(this.tSBMoneda.KeyMember);
                tarifaxcliente.tc_totalconrecargo = Convert.ToDecimal(this.txtTotalConRecargo.Text);
                
                if (tarifaxcliente.tc_cotizacioncabid.HasValue)
                {
                    this.guardarCotiCab(context, tarifaxcliente.tc_cotizacioncabid.Value, tarifaxcliente.tc_monedaid.Value);

                    foreach(tc_tarifascliente tc in context.tc_tarifascliente.Where( a => a.tc_cotizacioncabid == tarifaxcliente.tc_cotizacioncabid.Value).ToList())
                    {
                        tc.tc_clienteid = tarifaxcliente.tc_clienteid;
                    }
                    
                }

                

            }
            else if (this.FormEditStatus == INSERT)
            {
                tarifaxcliente.tc_tarifaid = Convert.ToInt32(this.tSBTarifa.KeyMember);//this.cbTarifas.SelectedValue);
                tarifaxcliente.tc_clienteid = this.ClienteID; //Convert.ToInt32(this.tSBClienteEdit.KeyMember);
                tarifaxcliente.tc_expedienteid = Convert.ToInt32(this.txtExpedienteID.Text);
                tarifaxcliente.tc_fecha = Convert.ToDateTime(this.txtFecha.Text);
                tarifaxcliente.tc_monto = Convert.ToDecimal(this.txtMonto.Text);
                tarifaxcliente.tc_tipounidaddesc = this.cbTipoUnidadDescuento.SelectedIndex == 0 ? false : true;
                tarifaxcliente.tc_descuentomonto = Convert.ToDecimal(this.txtMontoDescuento.Text);
                tarifaxcliente.tc_descuentoporcentaje = Convert.ToDecimal(this.txtPorcDescuento.Text);
                tarifaxcliente.tc_tipounidadimp = this.cbTipoUnidadImpuesto.SelectedIndex == 0 ? false : true;
                tarifaxcliente.tc_impuestomonto = Convert.ToDecimal(this.txtMontoImp.Text);
                tarifaxcliente.tc_impuestoporcentaje = Convert.ToDecimal(this.txtPorcImp.Text);
                tarifaxcliente.tc_cantidad = Convert.ToDecimal(this.txtCantidad.Text);
                tarifaxcliente.tc_precioventa = Convert.ToDecimal(this.txtPrecioVenta.Text);
                tarifaxcliente.tc_total = Convert.ToDecimal(this.txtTotal.Text);
                tarifaxcliente.tc_tramiteid = Convert.ToInt32(this.txtTramiteID.Text);
                tarifaxcliente.tc_especial = this.chEspecial.Checked;
                tarifaxcliente.tc_monedaid = Convert.ToInt32(this.tSBMoneda.KeyMember);
                tarifaxcliente.tc_totalconrecargo = Convert.ToDecimal(this.txtTotalConRecargo.Text);

                if (this.txtCotiID.Text != "")
                {
                    tarifaxcliente.tc_cotizacioncabid = Convert.ToInt32(this.txtCotiID.Text);
                }
                else
                {
                    int ccID = this.guardarCotiCab(context, -1, tarifaxcliente.tc_monedaid.Value);

                    if (ccID != -1)
                    {
                        tarifaxcliente.tc_cotizacioncabid = ccID;
                        
                    }
                    else
                        tarifaxcliente.tc_cotizacioncabid = null;
                }
                context.tc_tarifascliente.Add(tarifaxcliente);
                
            }

            return tarifaxcliente;
            
        }

        private int guardarCotiCab(BerkeDBEntities context, int ccID = -1, Nullable<int> monedaID = null)
        {
            int Result = -1;

            if (ccID == -1)
            {
                cc_cotizacioncab cc = new cc_cotizacioncab();

                if (this.tSBAutorizadoPor.KeyMember != "")
                {
                    cc.cc_aprobadopor = Convert.ToInt32(this.tSBAutorizadoPor.KeyMember);
                    //cc.cc_confirmado = true;
                    //this.chkConfirmado.Checked = true;
                }

                
                if (this.tSBEnviadoPor.KeyMember != "")
                    cc.cc_solicitadopor = Convert.ToInt32(this.tSBEnviadoPor.KeyMember);

                if (this.txtFechaCotiCab.Text != "")
                    cc.cc_fecha = Convert.ToDateTime(this.txtFechaCotiCab.Text);

                if (this.txtExpedienteID.Text != "")
                    cc.cc_expedienteid = Convert.ToInt32(this.txtExpedienteID.Text);

                if (this.txtObservacion.Text != "")
                    cc.cc_observacion = this.txtObservacion.Text;
                else cc.cc_observacion = null;

                if (this.txtRecargoAT.Text != String.Empty)
                {
                    if ((monedaID.HasValue) && (this.txtRecargoAT.Text != "0,00"))
                        cc.cc_recargoatmonedaid = monedaID.Value;
                    else
                        cc.cc_recargoatmonedaid = null;

                    cc.cc_recargoatmonto = Convert.ToDecimal(this.txtRecargoAT.Text);
                }
                else
                {
                    cc.cc_recargoatmonto = null;
                    cc.cc_recargoatmonedaid = null;
                }

                context.cc_cotizacioncab.Add(cc);
                //context.SaveChanges();
                Result = cc.cc_cotizacioncabid;
            }
            else
            {
                cc_cotizacioncab cc = context.cc_cotizacioncab.First(a => a.cc_cotizacioncabid == ccID);
                
                string autorizadopor = cc.cc_aprobadopor.HasValue ? cc.cc_aprobadopor.Value.ToString() : "";
                if (this.tSBAutorizadoPor.KeyMember != autorizadopor)
                {
                    cc.cc_aprobadopor = Convert.ToInt32(this.tSBAutorizadoPor.KeyMember);
                    if (cc.cc_aprobadopor.HasValue)
                    {
                        //cc.cc_confirmado = true;
                        //this.chkConfirmado.Checked = true;
                    }
                    
                }

                string enviadopor = cc.cc_solicitadopor.HasValue ? cc.cc_solicitadopor.Value.ToString() : "";
                if (this.tSBEnviadoPor.KeyMember != enviadopor)
                {
                    cc.cc_solicitadopor = Convert.ToInt32(this.tSBEnviadoPor.KeyMember);
                }

                string fechaCotiz = cc.cc_fecha.HasValue ? cc.cc_fecha.Value.ToShortDateString() : "";
                if (this.txtFechaCotiCab.Text != fechaCotiz)
                {
                    cc.cc_fecha = Convert.ToDateTime(this.txtFechaCotiCab.Text);
                }

                if (this.txtObservacion.Text != "")
                    cc.cc_observacion = this.txtObservacion.Text;
                else cc.cc_observacion = null;

                if (this.txtRecargoAT.Text != String.Empty)
                {
                    if ((monedaID.HasValue) && (this.txtRecargoAT.Text != "0,00"))
                        cc.cc_recargoatmonedaid = monedaID.Value;
                    else
                        cc.cc_recargoatmonedaid = null;

                    cc.cc_recargoatmonto = Convert.ToDecimal(this.txtRecargoAT.Text);
                }
                else
                {
                    cc.cc_recargoatmonto = null;
                    cc.cc_recargoatmonedaid = null;
                }

            }

            return Result;
        }

        #endregion Guardar Registro


        private void calcularTotal()
        {
            if ((this.txtCantidad.Text != "") &&
                 (this.txtPrecioVenta.Text != "") &&
                 (this.txtMontoDescuento.Text != "") &&
                 (this.txtPorcDescuento.Text != "") &&
                 (this.txtMontoImp.Text != "") &&
                 (this.txtPorcImp.Text != "")
                )
            {
                decimal total = Convert.ToDecimal(this.txtCantidad.Text) * Convert.ToDecimal(this.txtPrecioVenta.Text);

                if ((this.cbTipoUnidadDescuento.SelectedIndex == 0) && (this.txtMontoDescuento.Text != ""))
                {
                    total = (Convert.ToDecimal(this.txtPrecioVenta.Text) - Convert.ToDecimal(this.txtMontoDescuento.Text)) * Convert.ToDecimal(this.txtCantidad.Text);
                    //total = total - Convert.ToDecimal(this.txtMontoDescuento.Text);
                }
                else if ((this.cbTipoUnidadDescuento.SelectedIndex == 1) && (this.txtPorcDescuento.Text != ""))
                {
                    total = (Convert.ToDecimal(this.txtPrecioVenta.Text) - decimal.Round((Convert.ToDecimal(this.txtPrecioVenta.Text) * Convert.ToDecimal(this.txtPorcDescuento.Text) / 100), MidpointRounding.AwayFromZero)) * Convert.ToDecimal(this.txtCantidad.Text);
                    //total = decimal.Round((total - total * Convert.ToDecimal(this.txtPorcDescuento.Text) / 100), MidpointRounding.AwayFromZero);
                }

                if ((this.cbTipoUnidadImpuesto.SelectedIndex == 0) && (this.txtMontoImp.Text != ""))
                {
                    total = total + Convert.ToDecimal(this.txtMontoImp.Text);
                    //total = total + Convert.ToDecimal(this.txtMontoImp.Text);
                }
                else if ((this.cbTipoUnidadImpuesto.SelectedIndex == 1) && (this.txtPorcImp.Text != ""))
                {
                    total = total + decimal.Round(total * Convert.ToDecimal(this.txtPorcImp.Text) / 100, MidpointRounding.AwayFromZero);
                }

                if (this.chkRedondear.Checked)
                    total = decimal.Round(total, MidpointRounding.AwayFromZero);

                this.txtTotal.Text = String.Format("{0:0.00}", total);
            }
        }

        private void txtPorcDescuento_Leave(object sender, EventArgs e)
        {
            if (this.FormEditStatus != BROWSE)
            {
                decimal valor;
                if (!decimal.TryParse(this.txtPorcDescuento.Text, out valor)) this.txtPorcDescuento.Text = "0,00";
                if ((this.cbTipoUnidadDescuento.SelectedIndex == 1) && (this.txtPorcDescuento.Text != ""))
                {
                    //decimal monto = Convert.ToDecimal(Convert.ToDecimal(this.txtPrecioVenta.Text) * Convert.ToDecimal(this.txtPorcDescuento.Text) / 100);
                    //this.txtMontoDescuento.Text = String.Format("{0:0.00}", monto);
                    this.txtMontoDescuento.Text = "0,00";
                    this.txtPorcDescuento.Text = String.Format("{0:0.00}", Convert.ToDecimal(this.txtPorcDescuento.Text));
                    this.calcularTotal();

                }
            }
        }

        private void txtPorcImp_Leave(object sender, EventArgs e)
        {
            if (this.FormEditStatus != BROWSE)
            {
                decimal valor;
                if (!decimal.TryParse(this.txtPorcImp.Text, out valor)) this.txtPorcImp.Text = "0,00";
                if ((this.cbTipoUnidadImpuesto.SelectedIndex == 1) && (this.txtPorcImp.Text != ""))
                {
                    //decimal monto = Convert.ToDecimal(Convert.ToDecimal(this.txtPrecioVenta.Text) * Convert.ToDecimal(this.txtPorcImp.Text) / 100);
                    //this.txtMontoImp.Text = String.Format("{0:0.00}", monto);
                    this.txtMontoImp.Text = "0,00";
                    this.txtPorcImp.Text = String.Format("{0:0.00}", Convert.ToDecimal(this.txtPorcImp.Text));
                    this.calcularTotal();
                }
            }
        }

        private void txtMontoDescuento_Leave(object sender, EventArgs e)
        {
            if (this.FormEditStatus != BROWSE)
            {
                decimal valor;
                if (!decimal.TryParse(this.txtMontoDescuento.Text, out valor)) this.txtMontoDescuento.Text = "0,00";
                if ((this.cbTipoUnidadDescuento.SelectedIndex == 0) && (this.txtMontoDescuento.Text != ""))
                {

                    //decimal porc = Convert.ToDecimal(this.txtMontoDescuento.Text) / Convert.ToDecimal(this.txtPrecioVenta.Text) * 100;
                    //this.txtPorcDescuento.Text = String.Format("{0:0.00}", porc);
                    this.txtPorcDescuento.Text = "0,00";
                    this.txtMontoDescuento.Text = String.Format("{0:0.00}", Convert.ToDecimal(this.txtMontoDescuento.Text));
                    //this.txtTotal.Text = String.Format("{0:0.00}", (Convert.ToDecimal(this.txtPrecioVenta.Text) * (Convert.ToDecimal(this.txtCantidad.Text)) + Convert.ToDecimal(this.txtMontoImp.Text) - Convert.ToDecimal(this.txtPorcDescuento.Text)));
                    this.calcularTotal();
                }
            }
        }

        private void txtMontoImp_Leave(object sender, EventArgs e)
        {
            if (this.FormEditStatus != BROWSE)
            {
                decimal valor;
                if (!decimal.TryParse(this.txtMontoImp.Text, out valor)) this.txtMontoImp.Text = "0,00";
                if ((this.cbTipoUnidadImpuesto.SelectedIndex == 0) && (this.txtMontoImp.Text != ""))
                {
                    //decimal porc = Convert.ToDecimal(this.txtMontoImp.Text) / Convert.ToDecimal(this.txtPrecioVenta.Text) * 100;
                    //this.txtPorcImp.Text = String.Format("{0:0.00}", porc);
                    this.txtPorcImp.Text = "0,00";
                    this.txtMontoImp.Text = String.Format("{0:0.00}", this.txtMontoImp.Text);
                    //this.txtTotal.Text = String.Format("{0:0.00}", (Convert.ToDecimal(this.txtPrecioVenta.Text) * (Convert.ToDecimal(this.txtCantidad.Text)) + Convert.ToDecimal(this.txtMontoImp.Text) - Convert.ToDecimal(this.txtPorcDescuento.Text)));
                    this.calcularTotal();
                }
            }
        }

        //private void txtMontoDescuento_Leave(object sender, EventArgs e)
        //{
        //    if (this.FormEditStatus != BROWSE)
        //    {
        //        if ((this.cbTipoUnidadDescuento.SelectedIndex == 0) && (this.txtMontoDescuento.Text != ""))
        //        {
        //            decimal porc = Convert.ToDecimal(this.txtMontoDescuento.Text) / Convert.ToDecimal(this.txtMonto.Text) * 100;
        //            this.txtPorcDescuento.Text = String.Format("{0:0.##}", porc);
        //        }
        //    }
        //}

        //private void txtMontoImp_Leave(object sender, EventArgs e)
        //{
        //    if ((this.cbTipoUnidadImpuesto.SelectedIndex == 0) && (this.txtMontoImp.Text != ""))
        //    {
        //        decimal porc = Convert.ToDecimal(this.txtMontoImp.Text) / Convert.ToDecimal(this.txtMonto.Text) * 100;
        //        this.txtPorcImp.Text = String.Format("{0:0.##}", porc);
        //    }
        //}

        private void dgvTarifas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (this.dgvTarifas.CurrentRow != null)
            //    this.cargarTarifasxCliente(this.dgvTarifas.CurrentRow);

           // MessageBox.Show("cambio");
        }

        private void dgvExpedientes_SelectionChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("SelectionChanged");
        }

        private void dgvTarifas_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvTarifas.CurrentRow != null)
                this.cargarTarifasxCliente(this.dgvTarifas.CurrentRow);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.FormEditStatus = BROWSE;

            if (this.dgvTarifas.RowCount > 0)
            {
                this.cargarExpedientes(this.dgvExpedientes.CurrentRow);
                //this.cargarTarifasxCliente(this.dgvTarifas.CurrentRow);
            }
            else
                this.limpiarValores();


            this.dgvTarifas.Focus();
        }

        private void txtEditStatus_TextChanged(object sender, EventArgs e)
        {
            if (this.FormEditStatus == BROWSE)
            {
                this.btnNuevo.Visible = false;
                this.btnEliminar.Visible = false;
                this.btnEditar.Visible = false;

                this.btnGrabar.Visible = false;
                this.btnCancelar.Visible = false;

                this.EditarSoloRecargoAT = false;

                this.permitirEdicion(false);
                this.lblTarifaUtilizada.Visible = false;
                this.tSBClienteEdit.Editable = false;                
            }
            else if (this.FormEditStatus == INSERT)
            {
                this.btnNuevo.Visible = false;
                this.btnEliminar.Visible = false;
                this.btnEditar.Visible = false;
                this.btnGrabar.Visible = true;
                this.btnCancelar.Visible = true;

                this.permitirEdicion(true);

                this.tSBClienteEdit.Editable = false;
            }
            else if (this.FormEditStatus == EDIT)
            {
                this.btnNuevo.Visible = false;
                this.btnEliminar.Visible = false;
                this.btnEditar.Visible = false;
                this.btnGrabar.Visible = true;
                this.btnCancelar.Visible = true;

                this.permitirEdicion(true);                

                if ((this.dgvExpedientes.CurrentRow != null) &&
                    (this.dgvExpedientes.CurrentRow.Cells[CAMPO_ESDUPLICADO].Value != null) &&
                    (Convert.ToBoolean(this.dgvExpedientes.CurrentRow.Cells[CAMPO_ESDUPLICADO].Value)))
                {
                    this.tSBClienteEdit.Editable = true;
                }
            }
            this.manejarBotonesTab();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if ((this.chkConfirmado.Checked) && (!this.lblAutorizacionVigente.Visible))
            {

                MessageBox.Show("La cotización está confirmada, sólo puede modificar el campo \"Recargo A/T\"." + Environment.NewLine +
                                "Para modificar los demás atributos debe generar una autorización.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                this.EditarSoloRecargoAT = true;
                this.FormEditStatus = EDIT;
                this.txtRecargoAT.Focus();

                //return;

            }
            else
            {
                this.FormEditStatus = EDIT;
                this.txtMonto.Focus();
            }            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //if (this.chkConfirmado.Checked)
            if ((this.chkConfirmado.Checked) && (!this.lblAutorizacionVigente.Visible))
            {
                MessageBox.Show("No se puede eliminar la cotización debido a que ya fue confirmada.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }


            string caption = "Eliminación de registro";
            string message = "Se eliminará el presente registro ¿Desea continuar?";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(DialogHandler));
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            if (this.FormEditStatus != BROWSE)
            {
                //if ((int)this.cbTarifas.SelectedValue != -1)
                if (this.tSBTarifa.KeyMember != "")
                {
                    decimal valor;
                    if (!decimal.TryParse(this.txtCantidad.Text, out valor))
                        this.txtCantidad.Text = "1,00";
                    else
                        this.txtCantidad.Text = String.Format("{0:0.00}", valor);

                    this.calcularTotal();
                    //this.txtTotal.Text = String.Format("{0:0.00}", (Convert.ToDecimal(this.txtPrecioVenta.Text) * (Convert.ToDecimal(this.txtCantidad.Text)) + Convert.ToDecimal(this.txtMontoImp.Text) - Convert.ToDecimal(this.txtPorcDescuento.Text)));
                }
            }
        }

        private void txtPrecioVenta_Leave(object sender, EventArgs e)
        {
            if (this.FormEditStatus != BROWSE)
            {
                //if ((int)this.cbTarifas.SelectedValue != -1)
                if (this.tSBTarifa.KeyMember != "")
                {
                    decimal valor;
                    if (!decimal.TryParse(this.txtPrecioVenta.Text, out valor)) 
                        this.txtPrecioVenta.Text = "0,00";
                    else
                        this.txtPrecioVenta.Text = String.Format("{0:0.00}", valor);

                    //this.txtTotal.Text = String.Format("{0:0.00}", (Convert.ToDecimal(this.txtPrecioVenta.Text) * (Convert.ToDecimal(this.txtCantidad.Text)) + Convert.ToDecimal(this.txtMontoImp.Text) - Convert.ToDecimal(this.txtPorcDescuento.Text)));
                    this.calcularTotal();
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.manejarBotonesTab();
        }

        private void tabControl1_SelectedIndexChanging(object sender, TabControlCancelEventArgs e)
        {
            if (this.FormEditStatus != BROWSE)
                e.Cancel = true;
        }

        private void manejarBotonesTab(bool vienedeEliminar = false)
        {
            if (this.tabControl1.SelectedTab == tbDetalle)
            {
                this.btnMarcarTodo.Visible = false;
                this.btnDuplicar.Visible = false;
                this.btnImprimir.Visible = false;
                this.btnExportarAExcel.Visible = false;
                this.grpTipoReporte.Visible = false;
                if (this.FormEditStatus == BROWSE)
                {
                    this.btnNuevo.Visible = true;
                    this.btnConfirmar.Visible = false;
                    
                    if ((this.txtCotiID.Text != "") && (!this.chkConfirmado.Checked))
                    {
                        this.btnConfirmar.Visible = true;
                    }

                    if ((this.txtOTID.Text != "") && (this.dgvTarifas.RowCount > 0))
                        this.btnCopiarHI.Visible = true;

                }
                else
                {
                    this.btnNuevo.Visible = false;
                    this.btnConfirmar.Visible = false;
                    this.btnCopiarHI.Visible = false;
                }

                if ((this.FormEditStatus == BROWSE) && (this.dgvTarifas.RowCount > 0))
                {
                    this.btnEditar.Visible = true;
                    this.btnEliminar.Visible = true;
                    this.dgvTarifas.CurrentCell = this.dgvTarifas.Rows[0].Cells[CAMPO_TARIFAFECHA];
                }
                else if (vienedeEliminar)
                {
                    this.btnEditar.Visible = false;
                    this.btnEliminar.Visible = false;
                }
            }
            else
            {
                this.btnNuevo.Visible = false;
                this.btnEditar.Visible = false;
                this.btnEliminar.Visible = false;
                this.btnMarcarTodo.Visible = true;
                this.btnDuplicar.Visible = true;
                this.btnImprimir.Visible = true;
                this.grpTipoReporte.Visible = true;
                if (this.dgvExpedientes.RowCount > 0)
                    this.btnConfirmar.Visible = true;
                else
                    this.btnConfirmar.Visible = false;
                this.btnCopiarHI.Visible = false;
                this.btnExportarAExcel.Visible = this.dgvExpedientes.Rows.Count > 0;
            }
            this.dgvTarifas.Focus();
        }

        private Tuple<bool,string> ValidateDate(string dateStr)
        {
            //dateStr = dateStr.Replace("-", "/").Replace(".", "/");
            bool ok = true;
            string errMsg = "";
            CultureInfo esPY = new CultureInfo("es-PY");
            if (dateStr != string.Empty)
            {
                string[] dateList = dateStr.Split(',');

                if (dateList.Length > 1)
                {
                    foreach (string date in dateList)
                    {
                        DateTime temp;
                        if (!DateTime.TryParseExact(date, "dd/MM/yyyy", esPY, DateTimeStyles.None, out temp))
                        {
                            ok = false;
                        }
                    }
                }
                else
                {
                    dateList = dateStr.Split('-');
                    if (dateList.Length > 2)
                    {
                        ok = false;
                    }
                    else if (dateList.Length == 2)
                    {
                        bool infOk = true;
                        bool supOk = true;
                        bool chkOk = true;

                        DateTime tempInf;
                        if (!DateTime.TryParseExact(dateList[0], "dd/MM/yyyy", esPY, DateTimeStyles.None, out tempInf))
                        {
                            infOk = false;
                        }

                        DateTime tempSup;
                        if (!DateTime.TryParseExact(dateList[1], "dd/MM/yyyy", esPY, DateTimeStyles.None, out tempSup))
                        {
                            supOk = false;
                        }

                        if (tempInf > tempSup)
                        {
                            chkOk = false;
                            errMsg = "El límite inferior del rango no puede ser mayor al límite superior.";
                        }

                        ok = infOk && supOk && chkOk;
                    }
                    else
                    {
                        DateTime temp;
                        if (!DateTime.TryParseExact(dateStr, "dd/MM/yyyy", esPY, DateTimeStyles.None, out temp))
                        {
                            ok = false;
                        }
                    }
                }
            }
            return new Tuple<bool, string>(ok, errMsg);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            Tuple<bool, string> chkFecEntrada = this.ValidateDate(this.txtFechaEntrada.Text.Trim());
            if (!chkFecEntrada.Item1)
            {
                MessageBox.Show(chkFecEntrada.Item2 != string.Empty ? "Fecha Entrada: " + chkFecEntrada.Item2 : "El formato de la fecha de entrada ingresada es inválido.", 
                                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Tuple<bool, string> chkFecSalida = this.ValidateDate(this.txtFechaSalida.Text.Trim());
            if (!chkFecSalida.Item1)
            {
                MessageBox.Show(chkFecEntrada.Item2 != string.Empty ? "Fecha Salida: " + chkFecEntrada.Item2 : "El formato de la fecha de salida ingresada es inválido.", 
                                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.ClienteID.ToString() == "")// || (this.tSBTramite.KeyMember == ""))
            {
                MessageBox.Show("Debe especificar un cliente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int tramiteid = -1;
            
            if (this.tSBTramite.KeyMember != "")
                tramiteid = Convert.ToInt32(this.tSBTramite.KeyMember);

            string paisid = String.Empty;

            if (this.tSBPais.KeyMember != String.Empty)
                paisid = this.tSBPais.KeyMember;

            if (this.EsForm)
            {
                if (this.tSBCliente.KeyMember != String.Empty)
                {
                    this.ClienteID = Convert.ToInt32(this.tSBCliente.KeyMember);
                    this.EsClienteMultiple();
                }
                else
                {
                    this.ClienteID = -1;
                    this.esMultiple = false;
                }
            }

            try
            {
                this.obtenerExpedientes(tramiteid,
                                        paisid,
                                        this.txtActaNro.Text,
                                        this.txtActaAnho.Text,
                                        this.txtHINro.Text,
                                        this.txtHIAnio.Text,
                                        this.txtExpedienteIDFil.Text,
                                        this.txtCotizacionIDFil.Text,
                                        this.txtFechaEntrada.Text,
                                        this.txtFechaSalida.Text);

                if ((this.dgvExpedientes.Rows.Count > 0) && (this.FormEditStatus == BROWSE))
                {
                    this.dgvExpedientes.CurrentCell = this.dgvExpedientes.Rows[0].Cells[CAMPO_DENOMINACION];
                }
                this.btnMarcarTodo.Text = "Marcar Todo";
                this.dgvExpedientes.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al recuperar los datos: "
                                 + ex.Message + Environment.NewLine
                                 + ex.InnerException,
                                 "Error al recuperar datos",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Stop);
            }

        }

        private void calcularGrandTotal()
        {
            decimal grandTotal = 0;
            //string stringTotal = String.Empty;
            foreach (DataGridViewRow row in this.dgvTarifas.Rows)
            {
                if (Convert.ToDecimal(row.Cells[CAMPO_TARIFATOTALCONRECARGO].Value) > 0)
                {
                    grandTotal += Convert.ToDecimal(row.Cells[CAMPO_TARIFATOTALCONRECARGO].Value);
                }
                else
                {
                    grandTotal += Convert.ToDecimal(row.Cells[CAMPO_TARIFATOTAL].Value);
                    //stringTotal += (stringTotal != String.Empty ? "," : String.Empty) + String.Format("{0:0.00}", Convert.ToDecimal(row.Cells[CAMPO_TARIFATOTAL].Value));
                }
            }
            if (this.chkRedondear.Checked)
                grandTotal = decimal.Round(grandTotal, MidpointRounding.AwayFromZero);

            this.txtGrandTotal.Text = String.Format("{0:0.00}", grandTotal);
            //MessageBox.Show(stringTotal);
        }


        private void ucTextSearchBox2_Load(object sender, EventArgs e)
        {

        }

        private void chkRedondear_CheckedChanged(object sender, EventArgs e)
        {
            this.calcularTotal();
            this.calcularGrandTotal();
        }

        private void btnMarcarTodo_Click(object sender, EventArgs e)
        {
            const string DESMARCAR = "Desmarcar Todo";
            const string MARCAR = "Marcar Todo";
            bool marcar = true;

            if (this.btnMarcarTodo.Text == DESMARCAR)
                marcar = false;

            foreach (DataGridViewRow row in this.dgvExpedientes.Rows)
            {
                row.Cells[0].Value = marcar;
            }

            this.btnMarcarTodo.Text = marcar ? DESMARCAR : MARCAR;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!hayMarcados())
            {
                MessageBox.Show("Debe marcar las filas que desea incluir en la Cotización.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            /*var query = this.DBContext.mn_menu.Where(b => b.mn_activo == true).OrderBy(b => b.mn_nivel).ThenBy(b => b.mn_orden);
            ReportDataSource datasource = new ReportDataSource("DataSet1", query.ToList());*/

            //string path = "";
            //if (this.chkAntecedentes.Checked)
            //    path = @"Reportes\HojaCotizacion1-1.z";
            //else
            //string path = this.rbActa.Checked ? @"Reportes\HojaCotizacionPorActa-SP.rdlc" : @"Reportes\HojaCotizacionPorHI-SP.rdlc";
            string path = this.rbActa.Checked ? @"Reportes\HojaCotizacionPorActa-SP-Obs.rdlc" : @"Reportes\HojaCotizacionPorHI-SP-Obs.rdlc";

            //Nombre del archivo generado desde la ventana del visor de reportes
            string fileName = (this.rbActa.Checked ? @"HojaCotizacionPorActa-SP-Obs" : @"HojaCotizacionPorHI-SP-Obs")
                                + DateTime.Now.ToString("_ddMMyyyy_Hmmss");

            FReportViewerBase f = new FReportViewerBase(path, this.makeReportDataSource(), this.DBContext, fileName);
            f.FormClosed += delegate { f = null; };
            f.Titulo = "Imprimir Cotización";
            f.NombreArchivoAdjunto = "HojaCotizacion";
            f.AsuntoMail = "Hoja de Cotización - " + this.tSBCliente.DisplayMember + " (" + this.tSBCliente.KeyMember + ")";
            f.ShowDialog();
        }

        private bool hayMarcados()
        {
            if (this.dgvExpedientes.RowCount > 0)
            {
                foreach (DataGridViewRow row in this.dgvExpedientes.Rows)
                {
                    if ((row.Cells[0].Value != null) && ((bool)row.Cells[0].Value))
                        return true;
                }
            }
            return false;
        }

        private List<ReportDataSource> makeReportDataSource()
        {
            string lista = "";
            foreach (DataGridViewRow row in this.dgvExpedientes.Rows)
            {
                //if ((row.Cells[CAMPO_EXPEDIENTEID].Value != null) && (row.Cells[0].Value != null) && ((bool)row.Cells[0].Value))
                //{
                //    if (lista != "")
                //        lista += ",";

                //    lista += row.Cells[CAMPO_EXPEDIENTEID].Value.ToString();
                //}

                if ((row.Cells[CAMPO_COTIZACIONCABID].Value != null) && (row.Cells[0].Value != null) && ((bool)row.Cells[0].Value))
                {
                    if (lista != "")
                        lista += ",";

                    lista += row.Cells[CAMPO_COTIZACIONCABID].Value.ToString();
                }
            }

            this.ListaCotizacionesID = lista;
            List<RepHojaCotizacion_Result> reportDS = new List<RepHojaCotizacion_Result>();

            reportDS = this.DBContext.RepHojaCotizacion(lista, 
                                                        this.rbActa.Checked ? "A" : "H",
                                                        Convert.ToInt32(this.txtTramiteID.Text)).ToList();

            //string filterString = this.GetFilterString(lista, "ExpedienteID", false);

            //foreach (RepHojaCotizacion_Result row in reportDS)
            //{
                
            //}

            List<ReportDataSource> datasource = new List<ReportDataSource>();
            datasource.Add(new ReportDataSource("DataSet1", reportDS));
            datasource.Add(this.GetListaCotizacionesPorPresupuestos(reportDS.First().Cotizaciones, this.DBContext));

            //if (!this.TramiteInterno)
            //{
            //    var query = (from tc in this.DBContext.tc_tarifascliente
            //                 join exp in this.DBContext.Expediente
            //                     on tc.tc_expedienteid equals exp.ID
            //                 join cli in this.DBContext.Cliente
            //                     on tc.tc_clienteid equals cli.ID
            //                 join tr in this.DBContext.Tramite
            //                     on tc.tc_tramiteid equals tr.ID
            //                 join tar in this.DBContext.Tarifas
            //                     on tc.tc_tarifaid equals tar.ID
            //                 join mo in this.DBContext.Moneda
            //                     on tc.tc_monedaid equals mo.ID
            //                 join ot in this.DBContext.OrdenTrabajo
            //                     on exp.OrdenTrabajoID equals ot.ID
            //                 select new CotizacionReportType
            //                 {
            //                     ExpedienteID = tc.tc_expedienteid,
            //                     TramiteID = tc.tc_tramiteid,
            //                     Cantidad = tc.tc_cantidad,
            //                     ClienteID = tc.tc_clienteid,
            //                     PrecioVenta = tc.tc_precioventa,
            //                     FechaTarifa = tc.tc_fecha,
            //                     TarifaID = tc.tc_tarifaid,
            //                     MonedaID = tc.tc_monedaid,
            //                     ClienteNombre = cli.Nombre,
            //                     TramiteDescripcion = tr.Descrip,
            //                     TarifaDescripcion = tar.Descripcion,
            //                     MonedaDescrip = mo.Descripcion,
            //                     ExpedienteActa = exp.Acta,
            //                     HINro = ot.Nro,
            //                     HIAnio = ot.Anio,
            //                     ActaNro = exp.ActaNro,
            //                     ActaAnio = exp.ActaAnio,
            //                     ImpuestoMonto = tc.tc_impuestomonto,
            //                     ImpuestoPorcentaje = tc.tc_impuestoporcentaje,
            //                     DescuentoMonto = tc.tc_descuentomonto,
            //                     DescuentoPorcentaje = tc.tc_descuentoporcentaje,
            //                     Total = tc.tc_total
            //                 }).Where(filterString).OrderBy(a => a.TarifaID)
            //                 .ThenBy(a => a.HINro).ThenBy(a => a.HIAnio)
            //                 .ThenBy(a => a.ActaNro).ThenBy(a => a.ActaAnio);
            //    datasource = new ReportDataSource("DataSet1", query.ToList());
            //}
            //else
            //{
            //    var query = (from tc in this.DBContext.tc_tarifascliente
            //                 join opo in this.DBContext.op_oposicion
            //                     on tc.tc_expedienteid equals opo.ID
            //                 join cli in this.DBContext.Cliente
            //                     on tc.tc_clienteid equals cli.ID
            //                 join tr in this.DBContext.Tramite
            //                     on tc.tc_tramiteid equals tr.ID
            //                 join tar in this.DBContext.Tarifas
            //                     on tc.tc_tarifaid equals tar.ID
            //                 join mo in this.DBContext.Moneda
            //                     on tc.tc_monedaid equals mo.ID
            //                 select new CotizacionReportType
            //                 {
            //                     ExpedienteID = tc.tc_expedienteid,
            //                     TramiteID = tc.tc_tramiteid,
            //                     Cantidad = tc.tc_cantidad,
            //                     ClienteID = tc.tc_clienteid,
            //                     PrecioVenta = tc.tc_precioventa,
            //                     FechaTarifa = tc.tc_fecha,
            //                     TarifaID = tc.tc_tarifaid,
            //                     MonedaID = tc.tc_monedaid,
            //                     ClienteNombre = cli.Nombre,
            //                     TramiteDescripcion = tr.Descrip,
            //                     TarifaDescripcion = tar.Descripcion,
            //                     MonedaDescrip = mo.Descripcion,
            //                     ActaNro = opo.ActaNro,
            //                     ActaAnio = opo.ActaAnio,
            //                     ImpuestoMonto = tc.tc_impuestomonto,
            //                     ImpuestoPorcentaje = tc.tc_impuestoporcentaje,
            //                     DescuentoMonto = tc.tc_descuentomonto,
            //                     DescuentoPorcentaje = tc.tc_descuentoporcentaje,
            //                     Total = tc.tc_total
            //                 }).Where(filterString).OrderBy(a => a.TarifaID)
            //                 //.ThenBy(a => a.HINro).ThenBy(a => a.HIAnio)
            //                 .ThenBy(a => a.ActaNro).ThenBy(a => a.ActaAnio);
            //    datasource = new ReportDataSource("DataSet1", query.ToList());
            //}

            

            return datasource;
        }

        private string getWhereString(string lista, string clave)
        {
            const string DEFAULT_STRING_PATTERN = "( {0} = {1} )";

            string filterString = "";
            #region ValueList
            string[] listaValores = lista.Split(',');

            //if (listaValores.Length > 1)
            //{
                string gFiltro = "";
                foreach (string e in listaValores)
                {
                    if (gFiltro != "")
                        gFiltro += " OR ";

                    //if (esFecha)
                    //    gFiltro += String.Format(DEFAULT_STRING_PATTERN, this.Clave, this.addComillas(e));
                    //else
                    gFiltro += String.Format(DEFAULT_STRING_PATTERN, clave, this.addComillas(e));
                }
                filterString = " (" + gFiltro + ") ";

            //}
            #endregion ValueList
            return filterString;
        }

        private string addComillas(string valor, bool esCadena = false)
        {
            if (esCadena)
                return "\"" + valor + "\"";
            else
                return valor;
        }

        public string GetFilterString(string valor, string clave, bool escadena)
        {
            const string DEFAULT_STRING_PATTERN = "( {0} = {1} )";
            const string WILDCARD_STRING_PATTERN = " {0}.Contains(\"{1}\") ";
            const string RANGE_STRING_PATTERN = "( {0} >= {1} AND {0} <= {2} )";

            string filterString = "";

            //dtList = new List<DateTime>();

            if (valor != "")
            {
                //Verificamos si es una lista y el primero de los valores es tipo fecha
                //bool esFecha = this.IsDate(this.Valor.Split(',')[0]);
                //Verificamos si es un rango y el primero de los valores es tipo fecha
                //if (!esFecha) esFecha = this.IsDate(this.Valor.Split('-')[0]);

                #region WildCard
                if (escadena)
                {
                    filterString = String.Format(WILDCARD_STRING_PATTERN, clave, valor.ToUpper());
                }
                #endregion WildCard
                else
                {
                    #region Default
                    filterString = String.Format(DEFAULT_STRING_PATTERN, clave, this.addComillas(valor, escadena));
                    #endregion Default

                    #region ValueList
                    string[] listaValores = valor.Split(',');

                    if (listaValores.Length > 1)
                    {
                        string gFiltro = "";
                        foreach (string e in listaValores)
                        {
                            if (gFiltro != "")
                                gFiltro += " OR ";

                            //if (esFecha)
                              //  gFiltro += String.Format(DEFAULT_STRING_PATTERN, this.Clave, this.addComillas(e));
                            //else
                                gFiltro += String.Format(DEFAULT_STRING_PATTERN, clave, this.addComillas(e, escadena));
                        }
                        filterString = " (" + gFiltro + ") ";

                    }
                    #endregion ValueList

                    #region Range
                    string[] rangoValores = valor.Split('-');

                    if ((rangoValores[0] != "") && (rangoValores.Length == 2))
                    {
                        filterString = String.Format(RANGE_STRING_PATTERN, clave, this.addComillas(rangoValores[0], escadena), this.addComillas(rangoValores[1]), escadena);
                    }
                    #endregion Range

                }
            }

            return filterString;
        }

        private void CambiarEstado()
        {
            foreach (DataGridViewRow row in this.dgvExpedientes.Rows)
            {
                if ((row.Cells[CAMPO_EXPEDIENTEID].Value != null) && (row.Cells[0].Value != null) && ((bool)row.Cells[0].Value))
                {
                }
            }
        }

        private ReportDataSource GetListaCotizacionesPorPresupuestos(string lista, BerkeDBEntities context)
        {
            const string VALOR_ANULADO = "N";
            ReportDataSource result = null;

            string where = this.getWhereString(lista, CAMPO_COTIZACIONCABID);

            List<CotizacionesPorPresupuestosType> qry = (from cc in context.cc_cotizacioncab
                                                         join cp in context.cp_cotizacionesxpresup
                                                           on cc.cc_cotizacioncabid equals cp.cp_cotizacionid into cc_cp
                                                         from cp in cc_cp.DefaultIfEmpty()
                                                         join pc in context.pc_presupuestocab
                                                           on cp.cp_presupuestocabid equals pc.pc_presupuestocabid into cc_pc
                                                         from pc in cc_pc.DefaultIfEmpty()
                                                         select new CotizacionesPorPresupuestosType
                                                         {
                                                             CotizacionCabID = cc.cc_cotizacioncabid,
                                                             FechaConfirmacion = cc.cc_fecha,
                                                             DocumentoNro = context.GetDocumentoNro(pc.pc_presupuestocabid).FirstOrDefault(),
                                                             FechaDocumento = context.GetFechaDocumento(pc.pc_presupuestocabid).FirstOrDefault(),
                                                             Estado = pc.pc_estado,
                                                             ConfeccionadoPor = context.GetCotizacionConfeccionadoPorTable(cc.cc_cotizacioncabid).FirstOrDefault().ConfeccionadoPor,
                                                             Responsable = context.GetCotizacionResponsableTable(cc.cc_cotizacioncabid).FirstOrDefault().Responsable,
                                                             Observacion = cc.cc_observacion
                                                         })
                                                         .Where(where)
                                                         .Where(a => a.Estado != VALOR_ANULADO)
                                                         .OrderBy(a => a.CotizacionCabID)
                                                         .ToList();

            //if (qry.Count > 0)
                result = new ReportDataSource("DataSet2", qry);

            return result;
        }

        private void dgvExpedientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.RowIndex > -1) && 
                (this.dgvExpedientes.Rows[e.RowIndex].Cells[CAMPO_CONFIRMADO].Value != null) && 
                ((bool)(this.dgvExpedientes.Rows[e.RowIndex].Cells[CAMPO_CONFIRMADO].Value)))
                {
                    if ((bool)(this.dgvExpedientes.Rows[e.RowIndex].Cells[CAMPO_TIENEAUTORIZACIONVIG].Value))
                        ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                    else
                        ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightPink;
                }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

            if ((this.tSBEnviadoPor.KeyMember == "") || (this.tSBAutorizadoPor.KeyMember == ""))// || (this.txtFechaCotiCab.Text == ""))
            {
                MessageBox.Show("Debe ingresar obligatoriamente:" + Environment.NewLine +
                                "- Responsable" + Environment.NewLine +
                                "- Autorizado por" + Environment.NewLine,
                                //"- Fecha de confirmación",
                                        "Atención Requerida",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                return;
            }

            string caption = "Confirmación de Cotización";

            string message = "Se confirmarán las cotizaciones marcadas ¿Desea continuar?";

            if (this.tabControl1.SelectedTab == this.tbDetalle)
                message = "Se confirmará la cotización ¿Desea continuar?";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(DialogHandler1));
        }

        private bool confirmarCotizacion(int CotiCabID, BerkeDBEntities context = null)
        {
            cc_cotizacioncab cc = context.cc_cotizacioncab.First(a => a.cc_cotizacioncabid == CotiCabID);

            if (this.txtFechaCotiCab.Text != "")
                cc.cc_fecha = Convert.ToDateTime(this.txtFechaCotiCab.Text);
            else
                cc.cc_fecha = System.DateTime.Now;

            cc.cc_confirmado = true;
            context.SaveChanges();
            return true;
        }

        private void marcarConfirmadosGrilla()
        {
            //bool success = false;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (DataGridViewRow row in this.dgvExpedientes.Rows)
                        {
                            if (!(Convert.ToBoolean(row.Cells[CAMPO_CONFIRMADO].Value)) && (row.Cells[0].Value != null) && ((bool)row.Cells[0].Value))
                            {
                                int coticabid;

                                if (row.Cells[CAMPO_COTIZACIONCABID].Value != null)
                                {
                                    coticabid = Convert.ToInt32(row.Cells[CAMPO_COTIZACIONCABID].Value);
                                    row.Cells[CAMPO_CONFIRMADO].Value = this.confirmarCotizacion(coticabid, context);
                                }
                            }
                        }
                        dbContextTransaction.Commit();
                        //success = true;
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        MessageBox.Show("Ocurrió un error al confirmar la cotización: "
                                        + ex.Message + Environment.NewLine
                                        + ex.InnerException,
                                        "Error al actualizar los datos",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Stop);
                    }
                }
            }
        }

        private void DialogHandler1(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    if (this.tabControl1.SelectedTab == this.tbDetalle)
                        this.chkConfirmado.Checked = this.confirmarCotizacion(Convert.ToInt32(this.txtCotiID.Text), this.DBContext);
                    else
                        this.marcarConfirmadosGrilla();

                    this.btnFiltrar.PerformClick();
                }
            }
        }

        private void btnCopiarHI_Click(object sender, EventArgs e)
        {
            Forms.UI.FCopiarCotizaciones f = new Forms.UI.FCopiarCotizaciones(this.DBContext, this.FormEditStatus, 
                                                                              Convert.ToInt32(this.txtOTID.Text), 
                                                                              Convert.ToInt32(this.txtTramiteID.Text),
                                                                              Convert.ToInt32(this.txtExpedienteID.Text),
                                                                              Convert.ToInt32(this.txtCotiID.Text));
            f.FormClosed += delegate { f = null; this.btnFiltrar.PerformClick(); };
            f.ShowDialog();

                           
        }

        private void DialogHandler2(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    //if (this.tabControl1.SelectedTab == this.tbDetalle)
                        //this.chkConfirmado.Checked = this.confirmarCotizacion(Convert.ToInt32(this.txtCotiID.Text), this.DBContext);
                    //else
                        //this.marcarConfirmadosGrilla();

                    //
                    this.btnFiltrar.PerformClick();
                }
            }
        }

        private void txtTotalConRecargo_Leave(object sender, EventArgs e)
        {
            if (this.FormEditStatus != BROWSE)
            {
                decimal valor;
                if (!decimal.TryParse(this.txtTotalConRecargo.Text, out valor))
                    this.txtTotalConRecargo.Text = "0,00";
                else
                    this.txtTotalConRecargo.Text = String.Format("{0:0.00}", valor);
            }
        }

        private void txtRecargoAT_Leave(object sender, EventArgs e)
        {
            if (this.FormEditStatus != BROWSE)
            {
                decimal valor;
                if (!decimal.TryParse(this.txtRecargoAT.Text, out valor))
                    this.txtRecargoAT.Text = "0,00";
                else
                    this.txtRecargoAT.Text = String.Format("{0:0.00}", valor);
            }
        }

        private void btnExportarAExcel_Click(object sender, EventArgs e)
        {
            if (this.dgvExpedientes.Rows.Count > 0)
            {
                ColumnsToExclude.Add(CAMPO_SELECCIONAR);
                
                FSelColExportExcel f = new FSelColExportExcel(this.GetAllColumnsNamesList());
                f.AceptarClick += f_AceptarClick;
                f.FormClosed += delegate { f = null; };
                f.ShowDialog();

                //string fileName = SPF.Classes.ExportarGrillaAExcel.ExportarExcel(this.dgvExpedientes, columnsToExclude);
                //DownloadGateway download = new DownloadGateway(@fileName);
                //download.StartDownload(this);
            }
        }

        private void f_AceptarClick(object sender, AceptarClickEventArgs e)
        {
            List<DataGridViewColumn> colList = new List<DataGridViewColumn>();
            DataGridView grid = new DataGridView();
            grid = this.dgvExpedientes;
            if (e.TipoSeleccion == AceptarClickEventArgs.TODAS)
            {
                grid = this.dgvExportarExcel;
                colList = this.GetAllColumnsList();
            }
            else if (e.TipoSeleccion == AceptarClickEventArgs.VISIBLES)
            {
                colList = this.GetVisibleColumnsList();
            }
            else
            {
                foreach (string colName in e.ListaColumnasSeleccionadas)
                {
                    foreach (DataGridViewColumn col in this.dgvExportarExcel.Columns)
                    {
                        if (col.Name == colName)
                            colList.Add(col);
                    }
                }
                grid = this.dgvExportarExcel;
            }
            string fileName = SPF.Classes.ExportarGrillaAExcel.ExportarExcel(grid, colList.OrderBy(a => a.DisplayIndex).ToList());
            DownloadGateway download = new DownloadGateway(@fileName);
            download.StartDownload(this);
        }

        private List<string> GetAllColumnsNamesList()
        {
            List<string> Result = new List<string>();
            foreach (DataGridViewColumn col in this.dgvExportarExcel.Columns)
            {
                if (!ColumnsToExclude.Contains(col.Name))
                    Result.Add(col.Name);
            }
            return Result;
        }

        private List<DataGridViewColumn> GetAllColumnsList()
        {
            List<DataGridViewColumn> Result = new List<DataGridViewColumn>();
            foreach (DataGridViewColumn col in this.dgvExportarExcel.Columns)
            {
                if (!ColumnsToExclude.Contains(col.Name))
                    Result.Add(col);
            }
            return Result;
        }

        private List<DataGridViewColumn> GetVisibleColumnsList()
        {
            List<DataGridViewColumn> Result = new List<DataGridViewColumn>();
            foreach (DataGridViewColumn col in this.dgvExpedientes.Columns)
            {
                if ((!ColumnsToExclude.Contains(col.Name)) && (col.Visible)) 
                    Result.Add(col);
            }
            return Result;
        }

        private void btnDuplicar_Click(object sender, EventArgs e)
        {
            if (!hayMarcados())
            {
                MessageBox.Show("No existen cotizaciones seleccionadas.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            string caption = "Duplicar Cotización";
            string message = "Se duplicarán las cotizaciones seleccionadas ¿Desea continuar?";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(DialogHandlerDuplicar));
        }

        private void DialogHandlerDuplicar(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    Duplicar();
                    //foreach (DataGridViewRow row in this.dgvExpedientes.Rows)
                    //{
                    //    //int cotizacionCabID = Convert.ToInt32(row.Cells[CAMPO_COTIZACIONCABID].Value);
                    //    //int c = 0;
                    //    //if ((row.Cells[0].Value != null) && ((bool)row.Cells[0].Value) && (cotizacionCabID > 0))
                    //    //{
                    //    //    Duplicar(cotizacionCabID);
                    //    //    c++;
                    //    //}
                    //    //MessageBox.Show(c.ToString() + " Filas duplicadas existosamente.", "Resultado",
                    //    //                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                }
            }
        }

        private void Duplicar()
        {
            int c = 0;
            foreach (DataGridViewRow row in this.dgvExpedientes.Rows)
            {
                int cotizacioncabID = Convert.ToInt32(row.Cells[CAMPO_COTIZACIONCABID].Value);
                if ((row.Cells[0].Value != null) && ((bool)row.Cells[0].Value) && (cotizacioncabID > 0))
                {
                    //bool success = false;
                    using (var context = new BerkeDBEntities())
                    {
                        using (var dbContextTransaction = context.Database.BeginTransaction())
                        {
                            try
                            {
                                cc_cotizacioncab ccs = context.cc_cotizacioncab.First(a => a.cc_cotizacioncabid == cotizacioncabID);

                                cc_cotizacioncab cci = new cc_cotizacioncab();
                                cci.cc_expedienteid = ccs.cc_expedienteid.Value;
                                if (ccs.cc_fecha.HasValue)
                                    cci.cc_fecha = ccs.cc_fecha.Value;
                                if (ccs.cc_aprobadopor.HasValue)
                                    cci.cc_aprobadopor = ccs.cc_aprobadopor.Value;
                                if (ccs.cc_solicitadopor.HasValue)
                                    cci.cc_solicitadopor = ccs.cc_solicitadopor.Value;
                                cci.cc_confirmado = false;
                                cci.cc_observacion = ccs.cc_observacion;
                                cci.cc_esduplicado = true;
                                context.cc_cotizacioncab.Add(cci);
                                context.SaveChanges();

                                foreach (tc_tarifascliente tcs in context.tc_tarifascliente.Where(a => a.tc_cotizacioncabid == cotizacioncabID).ToList())
                                {
                                    tc_tarifascliente tci = new tc_tarifascliente();
                                    tci.tc_clienteid = tcs.tc_clienteid;
                                    tci.tc_fecha = tcs.tc_fecha;
                                    tci.tc_tarifaid = tcs.tc_tarifaid;
                                    tci.tc_monto = tcs.tc_monto;
                                    tci.tc_observacion = tcs.tc_observacion;
                                    if (tcs.tc_tarifadocid.HasValue)
                                        tci.tc_tarifadocid = tcs.tc_tarifadocid.Value;
                                    tci.tc_tipounidaddesc = tcs.tc_tipounidaddesc;
                                    tci.tc_descuentomonto = tcs.tc_descuentomonto;
                                    tci.tc_descuentoporcentaje = tcs.tc_descuentoporcentaje;
                                    tci.tc_tipounidadimp = tcs.tc_tipounidadimp;
                                    tci.tc_impuestomonto = tcs.tc_impuestomonto;
                                    tci.tc_impuestoporcentaje = tcs.tc_impuestoporcentaje;
                                    if (tcs.tc_expedienteid.HasValue)
                                        tci.tc_expedienteid = tcs.tc_expedienteid.Value;
                                    if (tcs.tc_tramiteid.HasValue)
                                        tci.tc_tramiteid = tcs.tc_tramiteid.Value;
                                    tci.tc_precioventa = tcs.tc_precioventa;
                                    tci.tc_cantidad = tcs.tc_cantidad;
                                    tci.tc_total = tcs.tc_total;
                                    tci.tc_especial = tcs.tc_especial;
                                    if (tcs.tc_monedaid.HasValue)
                                        tci.tc_monedaid = tcs.tc_monedaid.Value;
                                    if (tcs.tc_cotizacioncabid.HasValue)
                                        tci.tc_cotizacioncabid = tcs.tc_cotizacioncabid.Value;
                                    if (tcs.tc_totalconrecargo.HasValue)
                                        tci.tc_totalconrecargo = tcs.tc_totalconrecargo.Value;
                                    tci.tc_cotizacioncabid = cci.cc_cotizacioncabid;
                                    context.tc_tarifascliente.Add(tci);
                                    context.SaveChanges();
                                }

                                dbContextTransaction.Commit();
                                //success = true;
                                c++;
                            }
                            catch (Exception ex)
                            {
                                dbContextTransaction.Rollback();
                                MessageBox.Show("Ocurrió un error al duplicar la cotización: "
                                                + ex.Message + Environment.NewLine
                                                + ex.InnerException,
                                                "Error al duplicar los datos",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Stop);
                                return;
                            }
                        }

                    }

                }
            }

            this.btnFiltrar.PerformClick();
            MessageBox.Show(c.ToString() + " filas duplicadas existosamente.", "Resultado",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
            
        }        
    }
}