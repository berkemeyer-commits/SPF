#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Transactions;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI;

using ModelEF6;
using SPF.Types;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.ObjectModel;

using SPF.Forms.Base;
using SPF.Forms.UI;
using Microsoft.Reporting.WebForms;
#endregion

namespace SPF.UserControls.UI
{
    public partial class ucCtaCteCliente : ucBaseForm
    {
        #region Constantes
        //Combo Tipo Sistema Electrónico
        private const string TIPOSISTEMAELECTRONICOID = "TipoSistemaElectronicoID";
        private const string TIPOSISTEMAELECTRONICODESCRIP = "TipoSistemaElectronicoDescrip";
        private const string VALOR_NINGUNO = "Ninguno";
        //Combo Idioma
        private const string IDIOMAID = "ID";
        private const string IDIOMADESCRIP = "Descripcion";

        //private const string IDCLIENTE = "ID";
        //private const string CLIENTENOMBRE = "Nombre";
        //private const string CLIENTECIUDAD = "ClienteCiudad";
        //private const string CLIENTEPAIS = "ClientePais";
        //private const string CLIENTEOBS = "Obs";
        private const string CAMPO_IDCLIENTE = "ID";
        private const string CAMPO_CLIENTENOMBRE = "Nombre";
        private const string CAMPO_CLIENTEOBS = "Obs";
        private const string CAMPO_DIRECCION = "Direccion";
        private const string CAMPO_CORREO = "Correo";
        private const string CAMPO_DOCUMENTO = "Documento";
        private const string CAMPO_RUC = "RUC";
        private const string CAMPO_PERSONERIA = "Personeria";
        private const string CAMPO_FECHAALTA = "FechaAlta";
        private const string CAMPO_FECHAMODIFICACION = "FechaModificacion";
        private const string CAMPO_IDIOMAID = "IdiomaID";
        private const string CAMPO_PAISID = "PaisID";
        private const string CAMPO_CLIENTEPAIS = "ClientePais";
        private const string CAMPO_MULTIPLE = "Multiple";
        private const string CAMPO_GRUPOEMPRESARIALID = "GrupoEmpresarialID";
        private const string CAMPO_ACTIVO = "Activo";
        private const string CAMPO_TRADUCCIONAUTO = "TraduccionAuto";
        private const string CAMPO_CIUDADID = "CiudadID";
        private const string CAMPO_CLIENTECIUDAD = "ClienteCiudad";
        private const string CAMPO_INUBICABLE = "Inubicable";
        private const string CAMPO_DDI = "Ddi";
        private const string CAMPO_PGENERAL = "PGeneral";
        private const string CAMPO_PINTELECTUAL = "PIntelectual";
        private const string CAMPO_DISTRIBUIDOR = "Distribuidor";
        private const string CAMPO_FACTURALOCAL = "FacturaLocal";
        private const string CAMPO_OBSANTE = "ObsAnte";
        private const string CAMPO_TIPOSISTEMAELECTRONICOID = "TipoSistElectronicoID";
        private const string CAMPO_TIPOSISTEMAELECTRONICODESCRIP = "TipoSistElectronicoDescrip";
        private const string CAMPO_BANCOID = "BancoID";
        private const string CAMPO_BANCONOMBRE = "BancoNombre";

        private const string TIPORELACIONCLIENTE = "C";
        private const string CLIENTE = "Cliente";

        private const string CAMPO_CUENTADESCRIPCION = "CuentaDescripcion";
        private const string CAMPO_CUENTANUMERO = "CuentaNumero";
        private const string CAMPO_MONEDAABREV = "MonedaAbrev";
        private const string CAMPO_CCCMID = "CCCMID";
        #endregion Constantes

        #region Variables
        frmPickBase fPickPais;
        frmPickBase fPickCiudad;
        SPF.Forms.UI.FCotizar f;
        private BindingSource bS;
        #endregion Variables

        #region Métodos de inicialización
        public ucCtaCteCliente(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();
            this.Titulo = Titulo;
            this.DBContext = dbContext;
            this.UseSQLSyntax = true;
            
            //var cli =   (from clientes in this.DBContext.Cliente
            //            join cpais in this.DBContext.CPais
            //              on clientes.PaisID equals cpais.idpais into cli_pais
            //            from cpais in cli_pais.DefaultIfEmpty()
            //            join ciudad in this.DBContext.CCiudad
            //              on clientes.CiudadID equals ciudad.idciudad into cli_ciudad
            //            from ciudad in cli_ciudad.DefaultIfEmpty()
            //             join ca in this.DBContext.ca_clienteantecedente
            //                     on clientes.ID equals ca.ca_clienteid into cli_ca
            //             from ca in cli_ca.DefaultIfEmpty()
            //            select new
            //            {
            //                IDCliente = clientes.ID,
            //                ClienteNombre = clientes.Nombre,
            //                ClienteCiudad = ciudad.nomciudad,
            //                ClientePais = cpais.descrip,
            //                Obs = clientes.Obs,
            //                ObsAnte = ca.ca_observacion
            //            })
            //          .GroupBy(a => a.IDCliente).Select(grp => grp.First())
            //          .Take(50)
            //          .OrderByDescending(b => b.IDCliente);

            List<GetListaClientes_Result> cli = new List<GetListaClientes_Result>();
            cli = (from lista in this.DBContext.GetListaClientes(String.Empty, String.Empty)
                   select new GetListaClientes_Result
                        {
                            ID = lista.ID,
                            Nombre = lista.Nombre,
                            Obs = lista.Obs,
                            Direccion = lista.Direccion,
                            Correo = lista.Correo,
                            Documento = lista.Documento,
                            RUC = lista.RUC,
                            Personeria = lista.Personeria,
                            FechaAlta = lista.FechaAlta,
                            FechaModificacion = lista.FechaModificacion,
                            IdiomaID = lista.IdiomaID,
                            PaisID = lista.PaisID,
                            Multiple = lista.Multiple,
                            GrupoEmpresarialID = lista.GrupoEmpresarialID,
                            Activo = lista.Activo,
                            TraduccionAuto = lista.TraduccionAuto,
                            CiudadID = lista.CiudadID,
                            Inubicable = lista.Inubicable,
                            Ddi = lista.Ddi,
                            PGeneral = lista.PGeneral,
                            PIntelectual = lista.PIntelectual,
                            Distribuidor = lista.Distribuidor,
                            FacturaLocal = lista.FacturaLocal,
                            ClienteCiudad = lista.ClienteCiudad,
                            ClientePais = lista.ClientePais,
                            TipoSistElectronicoID = lista.TipoSistElectronicoID,
                            TipoSistElectronicoDescrip = lista.TipoSistElectronicoDescrip,
                            BancoID = lista.BancoID,
                            BancoNombre = lista.BancoNombre
                        })
                        .ToList();
            this.BindingSourceBase = cli;

            #region Especificar campos para filtro
            this.SetFilter(CAMPO_IDCLIENTE, "ID Cliente", false);
            this.SetFilter(CAMPO_CLIENTENOMBRE, "Nombre Cliente");
            this.SetFilter(CAMPO_CLIENTECIUDAD, "Ciudad");
            this.SetFilter(CAMPO_CLIENTEPAIS, "Pais");
            this.SetFilter(CAMPO_CLIENTEOBS, "Obs. Cliente");
            this.SetFilter(CAMPO_OBSANTE, "Obs. Antec.");
            this.SetFilter(CAMPO_TIPOSISTEMAELECTRONICOID, "ID Tipo Sist. Elec.", false);
            this.SetFilter(CAMPO_TIPOSISTEMAELECTRONICODESCRIP, "Tipo Sist. Elec.");
            this.SetFilter(CAMPO_BANCOID, "Banco ID", false);
            this.SetFilter(CAMPO_BANCONOMBRE, "Banco Nombre");            
            this.TituloBuscador = "Buscar Clientes";
            #endregion Especificar campos para filtro

            this.bS = new BindingSource();

            //this.cargarCBIdioma();
            this.CargarCombos();

            #region Inicializar TextSearchBoxes
            this.tSBPais.KeyMemberWidth = 36;
            this.tSBPais.ToolTip = "Elegir País";
            this.tSBPais.AceptarClick += tSBPais_AceptarClick;

            this.tSBCiudad.KeyMemberWidth = 36;
            this.tSBCiudad.ToolTip = "Elegir País";
            this.tSBCiudad.AceptarClick += tSBCiudad_AceptarClick;
            #endregion Inicializar TextSearchBoxes
        }
        #endregion Métodos de inicialización

        #region Picks
        #region PickCiudad
        private void tSBCiudad_AceptarClick(object sender, EventArgs e)
        {
            if (fPickCiudad == null)
            {
                fPickCiudad = new frmPickBase();
                fPickCiudad.AceptarFiltrarClick += fPickCiudad_AceptarFiltrarClick;
                fPickCiudad.FiltrarClick += fPickCiudad_FiltrarClick;
                fPickCiudad.Titulo = "Elegir Ciudad";
                fPickCiudad.CampoIDNombre = "idciudad";
                fPickCiudad.CampoDescripNombre = "nomciudad";
                fPickCiudad.LabelCampoID = "ID";
                fPickCiudad.LabelCampoDescrip = "Descripción";
                fPickCiudad.NombreCampo = "Ciudad";
                //fPickCiudad.ShowDialog();
                
            }
            fPickCiudad.MostrarFiltro();
        }

        private void fPickCiudad_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickCiudad != null)
            {
                fPickCiudad.LoadData<CCiudad>(this.DBContext.CCiudad, fPickCiudad.GetWhereString());
            }
        }

        private void fPickCiudad_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBCiudad.DisplayMember = fPickCiudad.ValorDescrip;
            this.tSBCiudad.KeyMember = fPickCiudad.ValorID;

            fPickCiudad.Close();
            fPickCiudad.Dispose();
            //fPickCiudad = null;
        }
        #endregion PickCiudad
        
        #region PickPais
        private void tSBPais_AceptarClick(object sender, EventArgs e)
        {
            if (fPickPais == null)
            {
                fPickPais = new frmPickBase();
                //fPickPais.init("idpais", "descrip");
                fPickPais.AceptarFiltrarClick += f_AceptarFiltrarClickPais;
                fPickPais.FiltrarClick += fPickPais_FiltrarClick;
                fPickPais.Titulo = "Elegir País";
                fPickPais.CampoIDNombre = "idpais";
                fPickPais.CampoDescripNombre = "descrip";
                fPickPais.LabelCampoID = "ID";
                fPickPais.LabelCampoDescrip = "Descripción";
                fPickPais.NombreCampo = "País";
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

        private void f_AceptarFiltrarClickPais(object sender, EventArgs e)
        {
            this.tSBPais.DisplayMember = fPickPais.ValorDescrip;
            this.tSBPais.KeyMember = fPickPais.ValorID;

            fPickPais.Close();
            fPickPais.Dispose();
        }
        #endregion PickPais        
        #endregion Picks

        #region Combo Idioma
        private void cargarCBIdioma()
        {
            bool existeVacio = true;
            this.DBContext.CIdioma.Where(b => b.descrip != String.Empty).Load();

            try
            {
                CIdioma idio = this.DBContext.CIdioma.Local.First(b => b.ididioma == -1);
            }
            catch (InvalidOperationException)
            {
                existeVacio = false;
            }

            if (!existeVacio)
                this.DBContext.CIdioma.Local.Add(new CIdioma { ididioma = -1, descrip = "" });

            this.cbIdioma.DataSource = this.DBContext.CIdioma.Local.ToList();
            this.cbIdioma.DisplayMember = "descrip";
            this.cbIdioma.ValueMember = "ididioma";
        }

        private void CargarCombos()
        {
            List<TipoSistemaElectronico> listTSE = (from tse in this.DBContext.tse_tiposistelectronico
                                                    select new TipoSistemaElectronico
                                                    {
                                                        TipoSistemaElectronicoID = tse.tse_tiposistelectronicoid,
                                                        TipoSistemaElectronicoDescrip = tse.tse_descripcion
                                                    })
                                                    .ToList();
            listTSE.Add(new TipoSistemaElectronico { TipoSistemaElectronicoID = -1, TipoSistemaElectronicoDescrip = VALOR_NINGUNO });
            listTSE = listTSE.OrderBy(a => a.TipoSistemaElectronicoID).ToList();
            this.cbSistemaElectronico.DataSource = listTSE;
            this.cbSistemaElectronico.ValueMember = TIPOSISTEMAELECTRONICOID;
            this.cbSistemaElectronico.DisplayMember = TIPOSISTEMAELECTRONICODESCRIP;
            this.cbSistemaElectronico.SelectedValue = -1;

            List<CBIdioma> listIdio = (from idio in this.DBContext.CIdioma
                                       select new CBIdioma
                                       {
                                           ID = idio.ididioma,
                                           Descripcion = idio.descrip
                                       })
                                       .Where( a => a.Descripcion != String.Empty)
                                       .ToList();
            listIdio.Add(new CBIdioma { ID = -1, Descripcion = String.Empty });
            listIdio = listIdio.OrderBy(a => a.ID).ToList();
            this.cbIdioma.DataSource = listIdio;
            this.cbIdioma.ValueMember = IDIOMAID;
            this.cbIdioma.DisplayMember = IDIOMADESCRIP;
            this.cbIdioma.SelectedValue = -1;

        }


        #endregion Combo Idioma

        #region Cargar Cliente
        private void cargarCliente(int clienteID)
        {
            Cliente cliente = this.DBContext.Cliente.First(a => a.ID == clienteID);
            ((IObjectContextAdapter)this.DBContext).ObjectContext.Refresh(System.Data.Entity.Core.Objects.RefreshMode.ClientWins, cliente);
            
            this.txtIDCliente.Text = cliente.ID.ToString();
            this.txtNombreCliente.Text = cliente.Nombre;
            this.txtCorreo.Text = cliente.Correo;
            this.txtRUC.Text = cliente.RUC;
            this.txtDocumento.Text = cliente.Documento;
            this.txtObservaciones.Text = cliente.Obs;

            if (cliente.PGeneral.HasValue)
                this.chkPG.Checked = cliente.PGeneral.Value;

            if (cliente.PIntelectual.HasValue)
                this.chkPI.Checked = cliente.PIntelectual.Value;

            if (cliente.TraduccionAuto.HasValue)
                this.chkTradAuto.Checked = cliente.TraduccionAuto.Value;

            if (cliente.Inubicable.HasValue)
                this.chkNoUbicable.Checked = cliente.Inubicable.Value;

            if (cliente.Activo.HasValue)
                this.chkActivo.Checked = cliente.Activo.Value;

            if (cliente.FacturaLocal.HasValue)
                this.chkFacturaLocal.Checked = cliente.FacturaLocal.Value;

            this.chkClienteMultiple.Checked = cliente.Multiple;

            #region Personeria
            switch (cliente.Personeria)
            {
                case "J":
                    rbJuridica.Checked = true;
                    break;
                case "F":
                    rbFisica.Checked = true;
                    break;
                default:
                    rbJuridica.Checked = false;
                    rbFisica.Checked = false;
                    break;
            }
            #endregion Personeria

            #region Datos Pais
            if (cliente.PaisID != null)
            {
                CPais pais = this.DBContext.CPais.First(a => a.idpais == cliente.PaisID);
                this.txtDDIPais.Text = pais.paistel;
                this.tSBPais.DisplayMember = pais.descrip + "(" + pais.paisalfa + ")";
                this.tSBPais.KeyMember = pais.idpais.ToString();//pais.paisalfa;
            }
            #endregion Datos Pais

            #region Datos Idioma
            if (cliente.IdiomaID != null)
            {
                this.cbIdioma.SelectedValue = cliente.IdiomaID;
            }
            #endregion Datos Pais

            this.cbSistemaElectronico.SelectedValue = cliente.TipoSistElectronicoID.HasValue ? cliente.TipoSistElectronicoID.Value : -1;

            #region Datos Ciudad
            if (cliente.CiudadID != null)
            {
                CCiudad ciudad = this.DBContext.CCiudad.First(a => a.idciudad == cliente.CiudadID);
                this.txtDDICiudad.Text = ciudad.codciudad.ToString();
                this.tSBCiudad.DisplayMember = ciudad.nomciudad;
                this.tSBCiudad.KeyMember = ciudad.idciudad.ToString();
            }
            #endregion Datos Ciudad       
            //Cargar Cuentas
            this.CargarCuentas(Convert.ToInt32(this.txtIDCliente.Text));
        }
        #endregion Cargar Cliente

        #region Limpiar Datos
        private void limpiarDatos()
        {
            this.txtIDCliente.Text = String.Empty;
            this.txtNombreCliente.Text = String.Empty;
            this.txtCorreo.Text = String.Empty;
            this.txtRUC.Text = String.Empty;
            this.txtDocumento.Text = String.Empty;
            this.txtObservaciones.Text = String.Empty;
            this.rbJuridica.Checked = false;
            this.rbFisica.Checked = false;
            this.txtDDIPais.Text = String.Empty;
            this.txtDDICiudad.Text = String.Empty;
            this.cbIdioma.SelectedValue = -1;
            this.tSBPais.Clear();
            this.tSBCiudad.Clear();
            this.chkPG.Checked = false;
            this.chkPI.Checked = false;
            this.chkTradAuto.Checked = false;
            this.chkNoUbicable.Checked = false;
            this.chkActivo.Checked = false;
            this.chkClienteMultiple.Checked = false;
            this.chkFacturaLocal.Checked = false;
            this.cbSistemaElectronico.SelectedValue = -1;
        }
        #endregion Limpiar Datos

        #region ReadOnly condicional
        protected override void Editable(bool editar)
        {
            this.txtNombreCliente.ReadOnly = editar;
            this.txtCorreo.ReadOnly = editar;
            this.txtRUC.ReadOnly = editar;
            this.txtDocumento.ReadOnly = editar;
            this.txtObservaciones.ReadOnly = editar;
            this.cbIdioma.Enabled = !editar;
            this.rbJuridica.Enabled = !editar;
            this.rbFisica.Enabled = !editar;
            //this.txtDDIPais.ReadOnly = editar;
            //this.txtDDICiudad.ReadOnly = editar;
            this.tSBPais.Editable = !editar;
            this.tSBCiudad.Editable = !editar;
            this.chkPG.Enabled = !editar;
            this.chkPI.Enabled = !editar;
            this.chkTradAuto.Enabled = !editar;
            this.chkNoUbicable.Enabled = !editar;
            this.chkActivo.Enabled = !editar;
            this.chkClienteMultiple.Enabled = !editar;
            this.chkFacturaLocal.Enabled = !editar;
            this.tbbCotizar.Enabled = editar;
            this.cbSistemaElectronico.Enabled = !editar;
            this.btnAgregarCuenta.Enabled = !editar;
            this.btnEliminarCuenta.Enabled = !editar;
        }
        #endregion ReadOnly condicional

        #region Métodos locales sobre controles
        private void dgvListadoABM_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int clienteID = (int)((DataGridView)sender).Rows[e.RowIndex].Cells[0].Value;

                if (clienteID.ToString() == this.txtIDCliente.Text) return;

                this.limpiarDatos();
                this.cargarCliente(clienteID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al recuperar los datos: " + Environment.NewLine + ex.Message, "Información de Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void tbbGuardar_Click_1(object sender, EventArgs e)
        {
            //MessageBox.Show("Do you want to continue?", "Confirmation", MessageBoxButtons.YesNo, msgBoxHandler);
            string message = "";
            string caption = "";
            if (this.FormEditStatus == EDIT)
            {
                caption = "Actualización de registro";
                message = "Se modificará el presente registro ¿Desea continuar?";
            }
            else if (this.FormEditStatus == INSERT)
            {
                caption = "Inserción de nuevo de registro";
                message = "Se insertará un nuevo registro ¿Desea continuar?";
            }

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
                    if (this.FormEditStatus != BROWSE)
                        this.GuardarRegistro();
                    else
                        this.EliminarRegistro();
                }
            }
        }

        private void DialogHandlerEliminarCuenta(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    if (this.FormEditStatus != BROWSE)
                        this.EliminarCuenta();

                }
            }
        }

        private void EliminarCuenta()
        {
            int cccmID = Convert.ToInt32(this.dgvDetCuentas.CurrentRow.Cells[0].Value);

            ccm_conclictamoneda ccm = this.DBContext.ccm_conclictamoneda.First(a => a.ccm_conclictamonedaid == cccmID);
            this.DBContext.ccm_conclictamoneda.Remove(ccm);
            this.DBContext.SaveChanges();
            this.CargarCuentas(Convert.ToInt32(this.txtIDCliente.Text));

            if (this.dgvDetCuentas.RowCount > 0)
            {
                this.dgvDetCuentas.CurrentCell = this.dgvDetCuentas.Rows[0].Cells[5];
                this.dgvDetCuentas.CurrentCell.Selected = true;
                this.dgvDetCuentas.Focus();
            }
            else
            {
                this.btnEliminarCuenta.Enabled = false;
                this.btnAgregarCuenta.Focus();
            }
        }

        private void tbbBorrar_Click_1(object sender, EventArgs e)
        {
            string caption = "Eliminación de registro";
            string message = "Se eliminará el presente registro ¿Desea continuar?";
            
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(DialogHandler));
        }

        #endregion Métodos locales sobre controles

        #region Métodos Extendidos del ParentControl
        protected override void FilterEntity(string where = "", object[] filterParams = null)
        {
            try
            {
                this.limpiarDatos();
                string pattern1 = String.Empty;

                if (where.IndexOf(" AND ") > -1)
                    pattern1 = @"\(ObsAnte\sLIKE\s.*?\)\s\s\sAND";
                else
                    pattern1 = @"\(ObsAnte\sLIKE\s.*?\)";

                string pattern2 = @"\%.*?\%";
                string val = Regex.Match(where, pattern1).Value;
                string obsAnte = Regex.Match(val, pattern2).Value.Replace("%", String.Empty);
                string filtro = where;

                if (val != String.Empty)
                    filtro = where.Replace(val, String.Empty);

                List<GetListaClientes_Result> cli = new List<GetListaClientes_Result>();
                cli = (from lista in this.DBContext.GetListaClientes(filtro.TrimStart().TrimEnd(), obsAnte) 
                       select new GetListaClientes_Result
                       {
                           ID = lista.ID,
                           Nombre = lista.Nombre,
                           Obs = lista.Obs,
                           Direccion = lista.Direccion,
                           Correo = lista.Correo,
                           Documento = lista.Documento,
                           RUC = lista.RUC,
                           Personeria = lista.Personeria,
                           FechaAlta = lista.FechaAlta,
                           FechaModificacion = lista.FechaModificacion,
                           IdiomaID = lista.IdiomaID,
                           PaisID = lista.PaisID,
                           Multiple = lista.Multiple,
                           GrupoEmpresarialID = lista.GrupoEmpresarialID,
                           Activo = lista.Activo,
                           TraduccionAuto = lista.TraduccionAuto,
                           CiudadID = lista.CiudadID,
                           Inubicable = lista.Inubicable,
                           Ddi = lista.Ddi,
                           PGeneral = lista.PGeneral,
                           PIntelectual = lista.PIntelectual,
                           Distribuidor = lista.Distribuidor,
                           FacturaLocal = lista.FacturaLocal,
                           ClienteCiudad = lista.ClienteCiudad,
                           ClientePais = lista.ClientePais,
                           TipoSistElectronicoID = lista.TipoSistElectronicoID,
                           TipoSistElectronicoDescrip = lista.TipoSistElectronicoDescrip,
                           BancoID = lista.BancoID,
                           BancoNombre = lista.BancoNombre
                       }).ToList();

                this.BindingSourceBase = cli;

                //var query = (from clientes in this.DBContext.Cliente
                //             join cpais in this.DBContext.CPais
                //               on clientes.PaisID equals cpais.idpais into cli_pais
                //             from cpais in cli_pais.DefaultIfEmpty()
                //             join ciudad in this.DBContext.CCiudad
                //               on clientes.CiudadID equals ciudad.idciudad into cli_ciudad
                //             from ciudad in cli_ciudad.DefaultIfEmpty()
                //             join ca in this.DBContext.ca_clienteantecedente
                //                on clientes.ID equals ca.ca_clienteid into cli_ca
                //                from ca in cli_ca.DefaultIfEmpty()
                //             select new
                //             {
                //                 IDCliente = clientes.ID,
                //                 ClienteNombre = clientes.Nombre,
                //                 ClienteCiudad = ciudad.nomciudad,
                //                 ClientePais = cpais.descrip,
                //                 Obs = clientes.Obs,
                //                 ObsCliAnte = ca.ca_observacion
                //             });

                //if (where != "")
                //{
                //    this.BindingSourceBase = query.Where(where, filterParams)
                //                                .GroupBy(a => a.IDCliente).Select(grp => grp.First())
                //                                .OrderByDescending(b => b.IDCliente).ToList();
                //}
                //else
                //{
                //    this.BindingSourceBase = query.Take(50)
                //                                .GroupBy(a => a.IDCliente).Select(grp => grp.First())
                //                                .OrderByDescending(b => b.IDCliente).ToList();
                //}
                
                this.FormatearGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al filtrar los datos: " + Environment.NewLine + ex.Message, "Información de Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        protected override void tbbNuevo_Click(object sender, EventArgs e)
        {
            base.tbbNuevo_Click(sender, e);
            this.limpiarDatos();
            this.tSBPais.SetFocus();
        }

        protected override void tbbEditar_Click(object sender, EventArgs e)
        {
            base.tbbEditar_Click(sender, e);
            this.txtNombreCliente.Focus();
        }

        private void tbbCotizar_Click(object sender, EventArgs e)
        {
            /*
             private void tsFilterForm_Click(object sender, EventArgs e) {
        if (filterForm == null) {
            filterForm = new FilterForm();
            filterForm.FormClosed += delegate { filterForm = null; };
            filterForm.Show();
        }
        else {
            filterForm.WindowState = FormWindowState.Normal;
            filterForm.Focus();
        }
    }
             */
            //SPF.Forms.UI.FCotizar f = new Forms.UI.FCotizar(Convert.ToInt32(this.txtIDCliente.Text), this.txtNombreCliente.Text, this.DBContext);
            if (f == null)
            {
                int clienteID = Convert.ToInt32(this.txtIDCliente.Text);
                List<GetSolicitudesXCliente_Result> listaSolicitudes = this.DBContext.GetSolicitudesXCliente(clienteID.ToString()).ToList();

                f = new FCotizar(clienteID, this.txtNombreCliente.Text, this.DBContext);
                f.FormClosed += delegate { f = null; };
                f.Show();

                if (listaSolicitudes.Count > 0)
                {
                    FSolicitudesPendientes fSP = new FSolicitudesPendientes(clienteID, this.txtNombreCliente.Text, listaSolicitudes);
                    fSP.FormClosed += delegate { fSP = null; };
                    fSP.Show();
                }

            }
            else
            {
                f.WindowState = FormWindowState.Normal;
                f.Focus();
            }
            
            
        }

        protected override void tbbCancelar_Click(object sender, EventArgs e)
        {
            base.tbbCancelar_Click(sender, e);

            if (this.LastDGVIndex > -1)
            {
                int clienteID = Convert.ToInt32(this.dgvListadoABM.Rows[this.LastDGVIndex].Cells[CAMPO_IDCLIENTE].Value.ToString());
                this.cargarCliente(clienteID);
            }
            //int i;
            //if (int.TryParse(this.txtIDCliente.Text, out i))
            //{
            //    this.cargarCliente(i);
            //}
        }

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
                        this.eliminarCliente(context);
                        //transaction.Complete();
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        success = true;

                        //this.eliminarCliente();
                        ////transaction.Complete();
                        //success = true;
                    }
                    catch (Exception ex)
                    {
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
                    this.limpiarDatos();
                    this.FilterEntity(this.WhereString, this.FilterParam);
                    this.FormEditStatus = BROWSE;
                    MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void GuardarRegistro()
        {
            bool success = false;
            //int clienteID = -9999;

            Cliente cliente = null;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                //using (TransactionScope transaction = new TransactionScope())
                {
                    try
                    {
                        cliente = this.guardarCliente(context);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        success = true;

                        //clienteID = this.guardarCliente();
                        ////transaction.Complete();
                        //success = true;
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
                //this.cargarCliente(clienteID);
                this.cargarCliente(cliente.ID);
                if (this.FormEditStatus != BROWSE)
                    this.FilterEntity(this.WhereString, this.FilterParam);

                this.FormEditStatus = BROWSE;
                MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        protected override void FormatearGrilla()
        {
            base.FormatearGrilla();

            foreach (DataGridViewColumn col in this.dgvListadoABM.Columns)
            {
                col.Visible = false;
            }

            this.dgvListadoABM.Columns[CAMPO_IDCLIENTE].HeaderText = "ID";
            this.dgvListadoABM.Columns[CAMPO_IDCLIENTE].Width = 60;
            this.dgvListadoABM.Columns[CAMPO_IDCLIENTE].Visible = true;
            this.dgvListadoABM.Columns[CAMPO_IDCLIENTE].DisplayIndex = 0;
            this.dgvListadoABM.Columns[CAMPO_CLIENTENOMBRE].HeaderText = "Nombre o Razón Social";
            this.dgvListadoABM.Columns[CAMPO_CLIENTENOMBRE].Width = 300;
            this.dgvListadoABM.Columns[CAMPO_CLIENTENOMBRE].Visible = true;
            this.dgvListadoABM.Columns[CAMPO_CLIENTENOMBRE].DisplayIndex = 1;
            this.dgvListadoABM.Columns[CAMPO_CLIENTECIUDAD].HeaderText = "Ciudad";
            this.dgvListadoABM.Columns[CAMPO_CLIENTECIUDAD].Width = 120;
            this.dgvListadoABM.Columns[CAMPO_CLIENTECIUDAD].Visible = true;
            this.dgvListadoABM.Columns[CAMPO_CLIENTECIUDAD].DisplayIndex = 3;
            this.dgvListadoABM.Columns[CAMPO_CLIENTEPAIS].HeaderText = "País";
            this.dgvListadoABM.Columns[CAMPO_CLIENTEPAIS].Width = 120;
            this.dgvListadoABM.Columns[CAMPO_CLIENTEPAIS].Visible = true;
            this.dgvListadoABM.Columns[CAMPO_CLIENTEPAIS].DisplayIndex = 2;

        }
        #endregion Métodos Extendidos del ParentControl

        #region Métodos de Edición de Datos
        private Cliente guardarCliente(BerkeDBEntities context = null)
        {
            //int clienteID = -9999;
            Cliente cliente = new Cliente();
            if (this.FormEditStatus == EDIT)
            {
                int clienteID = Convert.ToInt32(this.txtIDCliente.Text);

                cliente = context.Cliente.First(a => a.ID == clienteID);

                //this.txtIDCliente.Text = cliente.ID.ToString();
                cliente.Nombre = this.txtNombreCliente.Text;
                cliente.Correo = this.txtCorreo.Text;
                cliente.RUC = this.txtRUC.Text;
                cliente.Documento = this.txtDocumento.Text;
                cliente.Obs = this.txtObservaciones.Text;
                cliente.PGeneral = this.chkPG.Checked;
                cliente.PIntelectual = this.chkPI.Checked;
                cliente.TraduccionAuto = this.chkTradAuto.Checked;
                cliente.Inubicable = this.chkNoUbicable.Checked;
                cliente.Activo = this.chkActivo.Checked;
                cliente.Multiple = this.chkClienteMultiple.Checked;
                cliente.FacturaLocal = this.chkFacturaLocal.Checked;

                #region Personeria
                if (this.rbJuridica.Checked)
                    cliente.Personeria = "J";
                else if (this.rbFisica.Checked) 
                    cliente.Personeria = "F";
                #endregion Personeria

                #region Datos Pais
                int paisID;
                if (int.TryParse(this.tSBPais.KeyMember, out paisID))
                {
                    cliente.PaisID = paisID;
                }
                #endregion Datos Pais

                #region Datos Idioma
                int idiomaID = Convert.ToInt32(this.cbIdioma.SelectedValue.ToString());
                if (idiomaID > 0)
                {
                    cliente.IdiomaID = idiomaID;
                }
                else cliente.IdiomaID = null;
                #endregion Datos Pais

                if ((int)this.cbSistemaElectronico.SelectedValue > 0)
                    cliente.TipoSistElectronicoID = (int)this.cbSistemaElectronico.SelectedValue;
                else cliente.TipoSistElectronicoID = null;

                #region Datos Ciudad
                int ciudadID;
                if (int.TryParse(this.tSBCiudad.KeyMember, out ciudadID))
                {
                    cliente.CiudadID = ciudadID;
                }
                #endregion Datos Ciudad

                //this.DBContext.SaveChanges();
            }
            else if (this.FormEditStatus == INSERT)
            {
                //Cliente cliente = new Cliente();

                cliente.Nombre = this.txtNombreCliente.Text;
                cliente.Correo = this.txtCorreo.Text;
                cliente.RUC = this.txtRUC.Text;
                cliente.Documento = this.txtDocumento.Text;
                cliente.Obs = this.txtObservaciones.Text;
                cliente.PGeneral = this.chkPG.Checked;
                cliente.PIntelectual = this.chkPI.Checked;
                cliente.TraduccionAuto = this.chkTradAuto.Checked;
                cliente.Inubicable = this.chkNoUbicable.Checked;
                cliente.Activo = this.chkActivo.Checked;
                cliente.Multiple = this.chkClienteMultiple.Checked;
                cliente.FacturaLocal = this.chkFacturaLocal.Checked;

                #region Personeria
                if (this.rbJuridica.Checked)
                    cliente.Personeria = "J";
                else if (this.rbFisica.Checked)
                    cliente.Personeria = "F";
                #endregion Personeria

                #region Datos Pais
                int paisID;
                if (int.TryParse(this.tSBPais.KeyMember, out paisID))
                {
                    cliente.PaisID = paisID;
                }
                #endregion Datos Pais

                #region Datos Idioma
                int idiomaID = Convert.ToInt32(this.cbIdioma.SelectedValue.ToString());
                if (idiomaID > 0)
                {
                    cliente.IdiomaID = idiomaID;
                }
                else cliente.IdiomaID = null;
                #endregion Datos Pais

                if ((int)this.cbSistemaElectronico.SelectedValue > 0)
                    cliente.TipoSistElectronicoID = (int)this.cbSistemaElectronico.SelectedValue;
                else cliente.TipoSistElectronicoID = null;

                #region Datos Ciudad
                int ciudadID;
                if (int.TryParse(this.tSBCiudad.KeyMember, out ciudadID))
                {
                    cliente.CiudadID = ciudadID;
                }
                #endregion Datos Ciudad

                context.Cliente.Add(cliente);
                //this.DBContext.SaveChanges();
                //clienteID = cliente.ID;
            }

            return cliente;
        }

        private void eliminarCliente(BerkeDBEntities context = null)
        {
            int clienteID = Convert.ToInt32(this.txtIDCliente.Text);
            Cliente cliente = context.Cliente.First(a => a.ID == clienteID);

            context.Cliente.Remove(cliente);
            //this.DBContext.SaveChanges();
        }
        #endregion Métodos de Edición de Datos

        private void tbbAntecedentes_Click(object sender, EventArgs e)
        {
            Gizmox.WebGUI.Forms.Form f = new Form();
            f.Controls.Add(new UserControls.UI.ucAntecedentesCliente(this.txtIDCliente.Text, this.txtNombreCliente.Text, "Antecedente del Cliente", this.DBContext));
            f.Controls[0].Dock = DockStyle.Fill;
            f.Size = new Size(850, 520);
            f.StartPosition = FormStartPosition.CenterScreen;
            f.BackColor = Color.CornflowerBlue;
            f.FormClosed += delegate { f = null; };
            f.ShowDialog();
        }

        private void tbbHistorico_Click(object sender, EventArgs e)
        {
            bool existe = true;
            //ch_clientehistorico ch = new ch_clientehistorico();

            ReportDataSource datasource = new ReportDataSource();

            try
            {
                int clienteid = -1;

                if (this.txtIDCliente.Text != "")
                    clienteid = Convert.ToInt32(this.txtIDCliente.Text);

                var query = (from h in this.DBContext.ch_clientehistorico
                            select new
                            {
                                TarifaHistorico = h.ch_tarifashistoricas,
                                ClienteID = h.ch_clientenuevoid
                            })
                            .Where(a => a.ClienteID == clienteid).ToList();

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
                f.Titulo = "Antecedentes Históricos - " + this.txtNombreCliente.Text + "(" + this.txtIDCliente.Text + ")";
                f.MostrarEnviar(false);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen antecedentes históricos para este cliente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvDetCuenta_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.btnEliminarCuenta.Enabled = this.dgvDetCuentas.CurrentRow != null && this.FormEditStatus != BROWSE;
        }

        private void dgvDetCuentas_DoubleClick(object sender, EventArgs e)
        {
            if (this.dgvDetCuentas.RowCount > 0)
            {
                int ix = this.dgvDetCuentas.CurrentRow != null ? this.dgvDetCuentas.CurrentRow.Index : 0;
                FCuentaPorClienteContinente f = new Forms.UI.FCuentaPorClienteContinente(this.DBContext,
                                                                                         CLIENTE,
                                                                                         this.txtIDCliente.Text,
                                                                                         this.txtNombreCliente.Text,
                                                                                         this.FormEditStatus,
                                                                                         (ClienteContinenteCuentaMoneda)this.dgvDetCuentas.Rows[ix].DataBoundItem);
                f.FormClosed += delegate
                {
                    f = null;
                    if (this.FormEditStatus != BROWSE)
                        this.CargarCuentas(Convert.ToInt32(this.txtIDCliente.Text));

                    if (this.dgvDetCuentas.RowCount > 0)
                    {
                        this.dgvDetCuentas.CurrentCell = this.dgvDetCuentas.Rows[0].Cells[5];
                        this.dgvDetCuentas.CurrentCell.Selected = true;
                        this.dgvDetCuentas.Focus();
                    }
                };
                f.ShowDialog();
            }
        }

        private void btnAgregarCuenta_Click(object sender, EventArgs e)
        {
            FCuentaPorClienteContinente f = new Forms.UI.FCuentaPorClienteContinente(this.DBContext,
                                                                                     CLIENTE,
                                                                                     this.txtIDCliente.Text,
                                                                                     this.txtNombreCliente.Text,
                                                                                     this.FormEditStatus);
            f.FormClosed += delegate
            {
                f = null;
                this.CargarCuentas(Convert.ToInt32(this.txtIDCliente.Text));

                if (this.dgvDetCuentas.RowCount > 0)
                {
                    this.dgvDetCuentas.CurrentCell = this.dgvDetCuentas.Rows[0].Cells[5];
                    this.dgvDetCuentas.CurrentCell.Selected = true;
                    this.dgvDetCuentas.Focus();
                }
            };
            f.ShowDialog();
        }

        private void btnEliminarCuenta_Click(object sender, EventArgs e)
        {
            string message = "";
            string caption = "";
            if (this.FormEditStatus == EDIT)
            {
                caption = "Eliminación de registro";
                message = "Se eliminará el presente registro ¿Desea continuar?";
            }
            else if (this.FormEditStatus == INSERT)
            {
                caption = "Eliminación de registro";
                message = "Se eliminará el registro seleccionado ¿Desea continuar?";
            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(DialogHandlerEliminarCuenta));
        }

        private void CargarCuentas(int clienteID)
        {
            var query = (from ccm in this.DBContext.ccm_conclictamoneda
                         join mon in this.DBContext.Moneda
                            on ccm.ccm_monedaid equals mon.ID
                         join cb in this.DBContext.cb_cuentabanco
                            on ccm.ccm_cuentabancoid equals cb.cb_cuentabancoid
                         join ba in this.DBContext.ba_banco
                            on cb.cb_bancoid equals ba.ba_bancoid
                         join cl in this.DBContext.Cliente
                            on ccm.ccm_concliid equals cl.ID
                         select new ClienteContinenteCuentaMoneda
                         {
                             CCCMID = ccm.ccm_conclictamonedaid,
                             ConCliID = ccm.ccm_concliid,
                             ConCliDescripcion = cl.Nombre,
                             TipoRelacion = ccm.ccm_tiporelacion,
                             CuentaID = ccm.ccm_cuentabancoid,
                             CuentaDescripcion = cb.cb_descripcion,
                             CuentaNumero = cb.cb_nrocuenta,
                             BancoID = cb.cb_bancoid,
                             BancoDescripcion = ba.ba_descripcion,
                             MonedaID = mon.ID,
                             MonedaDescripcion = mon.Descripcion,
                             MonedaAbrev = mon.AbrevMoneda
                         })
                        .Where(a => a.ConCliID == clienteID && a.TipoRelacion == TIPORELACIONCLIENTE)
                        .ToList();

            if (query.Count > 0)
            {
                this.bS.DataSource = query;
                this.dgvDetCuentas.DataSource = this.bS;
                this.FormatearGrillaCuentas();
            }
            else
                this.dgvDetCuentas.DataSource = null;
        }

        private void FormatearGrillaCuentas()
        {
            foreach (DataGridViewColumn col in this.dgvDetCuentas.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            this.dgvDetCuentas.ReadOnly = true;
            this.dgvDetCuentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetCuentas.ItemsPerPage = 10;
            this.dgvDetCuentas.ShowCellToolTips = true;
            this.dgvDetCuentas.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvDetCuentas.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvDetCuentas.DefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvDetCuentas.DefaultCellStyle.BackColor = Color.Transparent;
            this.dgvDetCuentas.MultiSelect = false;

            this.dgvDetCuentas.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;

            int displayIndex = 0;

            //this.dgvDetCuentas.Columns[CAMPO_CCCMID].HeaderText = "ID";
            //this.dgvDetCuentas.Columns[CAMPO_CCCMID].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.dgvDetCuentas.Columns[CAMPO_CCCMID].Width = 80;
            //this.dgvDetCuentas.Columns[CAMPO_CCCMID].DisplayIndex = displayIndex;
            //this.dgvDetCuentas.Columns[CAMPO_CCCMID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //this.dgvDetCuentas.Columns[CAMPO_CCCMID].Visible = true;
            //displayIndex++;

            this.dgvDetCuentas.Columns[CAMPO_MONEDAABREV].HeaderText = "Moneda";
            this.dgvDetCuentas.Columns[CAMPO_MONEDAABREV].Width = 80;
            this.dgvDetCuentas.Columns[CAMPO_MONEDAABREV].DisplayIndex = displayIndex;
            this.dgvDetCuentas.Columns[CAMPO_MONEDAABREV].Visible = true;
            displayIndex++;

            this.dgvDetCuentas.Columns[CAMPO_CUENTADESCRIPCION].HeaderText = "Descripción Cuenta";
            this.dgvDetCuentas.Columns[CAMPO_CUENTADESCRIPCION].Width = 200;
            this.dgvDetCuentas.Columns[CAMPO_CUENTADESCRIPCION].DisplayIndex = displayIndex;
            this.dgvDetCuentas.Columns[CAMPO_CUENTADESCRIPCION].Visible = true;
            displayIndex++;

            this.dgvDetCuentas.Columns[CAMPO_CUENTANUMERO].HeaderText = "N° Cuenta";
            this.dgvDetCuentas.Columns[CAMPO_CUENTANUMERO].Width = 200;
            this.dgvDetCuentas.Columns[CAMPO_CUENTANUMERO].DisplayIndex = displayIndex;
            this.dgvDetCuentas.Columns[CAMPO_CUENTANUMERO].Visible = true;
            displayIndex++;
        }

        private void ManejarBotones()
        {
            if (this.dgvDetCuentas.RowCount > 0)
            {
                this.dgvDetCuentas.CurrentCell = this.dgvDetCuentas.Rows[0].Cells[5];
                this.dgvDetCuentas.CurrentCell.Selected = true;
                this.dgvDetCuentas.Focus();

                if (this.FormEditStatus != BROWSE)
                {
                    this.btnEliminarCuenta.Enabled = true;
                    this.btnAgregarCuenta.Enabled = true;
                }
                else
                {
                    this.btnEliminarCuenta.Enabled = false;
                    this.btnAgregarCuenta.Enabled = false;
                }
            }
            else
            {
                if (this.FormEditStatus != BROWSE)
                {
                    this.btnEliminarCuenta.Enabled = false;
                    this.btnAgregarCuenta.Enabled = true;
                    this.btnAgregarCuenta.Focus();
                }
                else
                {
                    this.btnAgregarCuenta.Enabled = false;
                    this.btnEliminarCuenta.Enabled = false;
                }
            }
        }

        private void tabListaABM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabListaABM.SelectedIndex == 2)
            {
                this.ManejarBotones();
            }
        }

        protected override void tabListaABM_SelectedIndexChanging(object sender, TabControlCancelEventArgs e)
        {
            if (this.FormEditStatus == EDIT)
            {
                e.Cancel = e.TabPage.TabIndex == 0;
            }
            else if (this.FormEditStatus == INSERT)
            {
                e.Cancel = e.TabPage.TabIndex != 1;
            }
            else e.Cancel = false;
        }
    }
}