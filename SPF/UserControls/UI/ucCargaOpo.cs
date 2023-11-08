#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using ModelEF6;
using SPF.Types;
using System.Data.Entity;
using System.Data.Objects;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.ObjectModel;
using SPF.Forms.Base;


#endregion

namespace SPF.UserControls.UI
{
    public partial class ucCargaOpo : ucBaseForm
    {
        #region Variables
        frmPickBase fPickCliente;
        frmPickBase fPickTramite;
        frmPickBase fPickAtencion;
        #endregion Variables

        #region Constantes
        public const string CAMPO_EXPEOPOID     = "ExpeOpoID";
        public const string CAMPO_EXPEDIENTEID  = "ExpeID";
        public const string CAMPO_ACTA          = "Acta";
        public const string CAMPO_ACTANRO       = "ActaNro";
        public const string CAMPO_ACTAANIO      = "ActaAnio";
        public const string CAMPO_IDCLIENTE     = "IDCliente";
        public const string CAMPO_CLIENTENOMBRE = "ClienteNombre";
        public const string CAMPO_DENOMINACION  = "DenominacionMarca";
        public const string CAMPO_REGISTRONRO   = "RegistroNro";
        public const string CAMPO_TRAMITEDESCRIP = "TramiteDescrip";
        public const string CAMPO_TRAMITEID     = "TramiteID";
        public const string CAMPO_TRAMITEDESCRIPDESTINO = "TramiteDescripDestino";
        public const string CAMPO_USUARIOID = "UsuarioID";
        public const string CAMPO_FECHAENTRADA  = "FechaEnvio";
        public const string CAMPO_FECHASALIDA = "FechaSalida";
        public const string CAMPO_USUARIONOMBREPILA = "NombreUsuario";
        public const string CAMPO_HINRO = "HINro";
        public const string CAMPO_HIANIO = "HIAnio";
        public const string CAMPO_HITEXTO = "HITexto";
        public const string CAMPO_ORDENTRABAJOID = "OrdenTrabajoID";
        private const string CAMPO_FECHAPRESENTACION = "FechaPresentacion";
        private const string CAMPO_PARTENOMBRE = "ParteNombre";
        private const string CAMPO_CONTRAPARTENOMBRE = "ContraparteNombre";
        private const string CAMPO_ATENCIONID = "AtencionID";
        private const string CAMPO_ATENCIONNOMBRE = "AtencionNombre";
        private const string CAMPO_USUARIOCARGAID = "UsuarioAuditID";
        private const string CAMPO_USUARIOCARGANOMBRE = "UsuarioAuditNombre";
        private const string TRAMITES_MULTIPLES = "TRAMITES_MULTIPLES";
        private const string AUDIT_OPERACION_INSERT = "INSERT";
        #endregion Constantes

        #region Métodos de Inicio
        public ucCargaOpo()
        {
            InitializeComponent();
        }

        public ucCargaOpo(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();
            this.Titulo = Titulo;
            this.DBContext = dbContext;

            this.tSBCliente.KeyMemberWidth = 70;
            this.tSBCliente.ToolTip = "Elegir Cliente";
            this.tSBCliente.AceptarClick += tSBCliente_AceptarClick;

            this.tSBTramite.KeyMemberWidth = 70;
            this.tSBTramite.ToolTip = "Elegir Trámite";
            this.tSBTramite.AceptarClick += tSBTramite_AceptarClick;

            this.tSBAtencion.KeyMemberWidth = 70;
            this.tSBAtencion.ToolTip = "Elegir Atención";
            this.tSBAtencion.AceptarClick += tSBAtencion_AceptarClick;

            this.txtOTID.Text = "-1";

            #region DateTime Pickers
            this.dtpFechaPresentacion.Format = DateTimePickerFormat.Short;
            this.dtpFechaEntrada.Format = DateTimePickerFormat.Short;
            this.dtpFechaSalida.Format = DateTimePickerFormat.Short;
            #endregion DateTime Pickers

            var opo = (from expeopo in this.DBContext.op_oposicion
                      join expedientes in this.DBContext.Expediente
                        on expeopo.ExpedienteID equals expedientes.ID into expeopo_expe
                        from expedientes in expeopo_expe.DefaultIfEmpty()
                      join cliente in this.DBContext.Cliente
                        on expeopo.ClienteID equals cliente.ID
                      join marca in this.DBContext.Marca
                        on expedientes.MarcaID equals marca.ID into expe_marca
                        from marca in expe_marca.DefaultIfEmpty()
                      join marcaregren in this.DBContext.MarcaRegRen
                        on marca.MarcaRegRenID equals marcaregren.ID into mar_mrr
                        from marcaregren in mar_mrr.DefaultIfEmpty()
                      join tramite in this.DBContext.Tramite
                        on expedientes.TramiteID equals tramite.ID into expe_tra
                        from tramite in expe_tra.DefaultIfEmpty()
                      join tramite1 in this.DBContext.Tramite
                        on expeopo.TramiteID equals tramite1.ID
                      join usuario in this.DBContext.Usuario
                        on expeopo.UsuarioID equals usuario.ID into usu_expeopo
                        from usuario in usu_expeopo.DefaultIfEmpty()
                       join ot in this.DBContext.OrdenTrabajo
                         on expedientes.OrdenTrabajoID equals ot.ID into ot_expe
                         from ot in ot_expe.DefaultIfEmpty()
                       join at in this.DBContext.Atencion
                         on expeopo.AtencionID equals at.ID into at_expeopo
                       from at in at_expeopo.DefaultIfEmpty()
                       join AudExpeOpo in this.DBContext.Audit_op_oposicion
                         on expeopo.ID equals AudExpeOpo.ID
                       join uAud in this.DBContext.Usuario
                          on AudExpeOpo.Audit_User.Substring(6, AudExpeOpo.Audit_User.Length) equals uAud.Usuario1
                       select new OpoExpeType
                       {
                           ExpeOpoID = expeopo.ID,
                           ExpeID = expeopo.ExpedienteID,
                           ActaNro = expeopo.ActaNro,
                           ActaAnio = expeopo.ActaAnio,
                           IDCliente = expeopo.ClienteID,
                           ClienteNombre = cliente.Nombre,
                           DenominacionMarca = expeopo.Denominacion,
                           RegistroNro = marcaregren.RegistroNro,
                           TramiteDescrip = tramite.Descrip,
                           TramiteID = expeopo.TramiteID,
                           TramiteDescripDestino = tramite1.Descrip,
                           UsuarioID = expeopo.UsuarioID,
                           FechaEnvio = expeopo.FechaEnvio,
                           NombreUsuario = usuario.NombrePila,
                           HINro = ot.Nro,
                           HiAnio = ot.Anio,
                           OrdenTrabajoID = expedientes.OrdenTrabajoID,
                           FechaPresentacion = expeopo.PresentacionFecha,
                           ParteNombre = expeopo.ParteNombre,
                           ContraparteNombre = expeopo.ContraparteNombre,
                           AtencionID = expeopo.AtencionID,
                           AtencionNombre = at.Nombre,
                           FechaSalida = expeopo.FechaSalida,
                           UsuarioAuditID = uAud.ID,
                           UsuarioAuditNombre = uAud.NombrePila,
                           AuditOperacion = AudExpeOpo.Audit_Operacion
                       })
                      .Where(a => a.AuditOperacion == AUDIT_OPERACION_INSERT)
                      .Take(50).OrderByDescending(b => b.ExpeOpoID);
            this.BindingSourceBase = opo.ToList();
            
            #region Especificar campos para filtro
            this.SetFilter("ExpeOpoID", "ID", false);
            this.SetFilter(CAMPO_DENOMINACION, "Denominación");
            this.SetFilter("ActaNro", "Acta Nro.", false);
            this.SetFilter("ActaAnio", "Acta Año", false);
            this.SetFilter("HINro", "HI Nro.", false);
            this.SetFilter("HIAnio", "HI Año", false);
            this.SetFilter(CAMPO_REGISTRONRO, "N° Registro", false);
            this.SetFilter("ClienteNombre", "Nombre Cliente");
            this.SetFilter("IDCliente", "ID Cliente", false);
            this.SetFilter(CAMPO_ATENCIONNOMBRE, "Nombre Atención");
            this.SetFilter(CAMPO_ATENCIONID, "ID Atención", false);
            this.SetFilter("TramiteDescrip", "Tramite Padre");
            this.SetFilter("TramiteDescripDestino", "Tramite Destino");
            this.SetFilter(CAMPO_USUARIONOMBREPILA, "Usuario");
            this.SetFilter(CAMPO_FECHAPRESENTACION, "Fec. Pres.");
            this.SetFilter(CAMPO_FECHAENTRADA, "Fec. Entrada");
            this.SetFilter(CAMPO_FECHASALIDA, "Fec. Entrada");
            this.SetFilter(CAMPO_PARTENOMBRE, "Parte Nombre");
            this.SetFilter(CAMPO_CONTRAPARTENOMBRE, "Contraparte Nombre");
            this.SetFilter(CAMPO_USUARIOCARGAID, "Usu. Carga ID", false);
            this.SetFilter(CAMPO_USUARIOCARGANOMBRE, "Usu. Carga Nombre");
            this.TituloBuscador = "Buscar Expedientes";
            #endregion Especificar campos para filtro

        }

        #endregion Métodos de Inicio

        #region Método Extendidos del ParentControl
        protected override void FilterEntity(string where = "", object[] filterParams = null)
        {
            try
            {
                this.limpiarValores();

                var query = (from expeopo in this.DBContext.op_oposicion
                             join expedientes in this.DBContext.Expediente
                               on expeopo.ExpedienteID equals expedientes.ID into expeopo_expe
                             from expedientes in expeopo_expe.DefaultIfEmpty()
                             join cliente in this.DBContext.Cliente
                               on expeopo.ClienteID equals cliente.ID
                             join marca in this.DBContext.Marca
                               on expedientes.MarcaID equals marca.ID into expe_marca
                             from marca in expe_marca.DefaultIfEmpty()
                             join marcaregren in this.DBContext.MarcaRegRen
                               on marca.MarcaRegRenID equals marcaregren.ID into mar_mrr
                             from marcaregren in mar_mrr.DefaultIfEmpty()
                             join tramite in this.DBContext.Tramite
                               on expedientes.TramiteID equals tramite.ID into expe_tra
                             from tramite in expe_tra.DefaultIfEmpty()
                             join tramite1 in this.DBContext.Tramite
                               on expeopo.TramiteID equals tramite1.ID
                             join usuario in this.DBContext.Usuario
                               on expeopo.UsuarioID equals usuario.ID into usu_expeopo
                             from usuario in usu_expeopo.DefaultIfEmpty()
                             join ot in this.DBContext.OrdenTrabajo
                               on expedientes.OrdenTrabajoID equals ot.ID into ot_expe
                             from ot in ot_expe.DefaultIfEmpty()
                             join at in this.DBContext.Atencion
                               on expeopo.AtencionID equals at.ID into at_expeopo
                             from at in at_expeopo.DefaultIfEmpty()
                             join AudExpeOpo in this.DBContext.Audit_op_oposicion
                                on expeopo.ID equals AudExpeOpo.ID
                             join uAud in this.DBContext.Usuario
                                on AudExpeOpo.Audit_User.Substring(6, AudExpeOpo.Audit_User.Length) equals uAud.Usuario1
                             select new OpoExpeType
                             {
                                 ExpeOpoID = expeopo.ID,
                                 ExpeID = expeopo.ExpedienteID,
                                 ActaNro = expeopo.ActaNro,
                                 ActaAnio = expeopo.ActaAnio,
                                 IDCliente = expeopo.ClienteID,
                                 ClienteNombre = cliente.Nombre,
                                 DenominacionMarca = expeopo.Denominacion,
                                 RegistroNro = marcaregren.RegistroNro,
                                 TramiteDescrip = tramite.Descrip,
                                 TramiteID = expeopo.TramiteID,
                                 TramiteDescripDestino = tramite1.Descrip,
                                 UsuarioID = expeopo.UsuarioID,
                                 FechaEnvio = expeopo.FechaEnvio,
                                 NombreUsuario = usuario.NombrePila,
                                 HINro = ot.Nro,
                                 HiAnio = ot.Anio,
                                 OrdenTrabajoID = expedientes.OrdenTrabajoID,
                                 FechaPresentacion = expeopo.PresentacionFecha,
                                 ParteNombre = expeopo.ParteNombre,
                                 ContraparteNombre = expeopo.ContraparteNombre,
                                 AtencionID = expeopo.AtencionID,
                                 AtencionNombre = at.Nombre,
                                 FechaSalida = expeopo.FechaSalida,
                                 UsuarioAuditID = uAud.ID,
                                 UsuarioAuditNombre = uAud.NombrePila,
                                 AuditOperacion = AudExpeOpo.Audit_Operacion
                             })
                             .Where(a => a.AuditOperacion == AUDIT_OPERACION_INSERT);

                if (where != "")
                {
                    this.BindingSourceBase = query.Where(where, filterParams).OrderByDescending(b => b.ExpeOpoID).ToList();
                }
                else
                {
                    this.BindingSourceBase = query.Take(50).OrderByDescending(b => b.ExpeOpoID).ToList();
                }

                this.FormatearGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al filtrar los datos: " + Environment.NewLine + ex.Message, "Información de Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        protected override void FormatearGrilla()
        {
            base.FormatearGrilla();

            foreach (DataGridViewColumn col in this.dgvListadoABM.Columns)
            {
                col.Visible = false;
            }

            this.dgvListadoABM.Columns[CAMPO_EXPEOPOID].HeaderText = "ID";
            this.dgvListadoABM.Columns[CAMPO_EXPEOPOID].Width = 50;
            this.dgvListadoABM.Columns[CAMPO_EXPEOPOID].DisplayIndex = 0;
            this.dgvListadoABM.Columns[CAMPO_EXPEOPOID].Visible = true;

            this.dgvListadoABM.Columns[CAMPO_TRAMITEDESCRIPDESTINO].HeaderText = "Trámite";
            this.dgvListadoABM.Columns[CAMPO_TRAMITEDESCRIPDESTINO].Width = 200;
            this.dgvListadoABM.Columns[CAMPO_TRAMITEDESCRIPDESTINO].DisplayIndex = 1;
            this.dgvListadoABM.Columns[CAMPO_TRAMITEDESCRIPDESTINO].Visible = true;

            this.dgvListadoABM.Columns[CAMPO_DENOMINACION].HeaderText = "Marca";
            this.dgvListadoABM.Columns[CAMPO_DENOMINACION].Width = 300;
            this.dgvListadoABM.Columns[CAMPO_DENOMINACION].DisplayIndex = 2;
            this.dgvListadoABM.Columns[CAMPO_DENOMINACION].Visible = true;

            this.dgvListadoABM.Columns[CAMPO_REGISTRONRO].HeaderText = "Registro N°";
            this.dgvListadoABM.Columns[CAMPO_REGISTRONRO].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_REGISTRONRO].DisplayIndex = 3;
            this.dgvListadoABM.Columns[CAMPO_REGISTRONRO].Visible = true;

            this.dgvListadoABM.Columns[CAMPO_ACTA].HeaderText = "Acta";
            this.dgvListadoABM.Columns[CAMPO_ACTA].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_ACTA].DisplayIndex = 4;
            this.dgvListadoABM.Columns[CAMPO_ACTA].Visible = true;

            this.dgvListadoABM.Columns[CAMPO_CLIENTENOMBRE].HeaderText = "Cliente";
            this.dgvListadoABM.Columns[CAMPO_CLIENTENOMBRE].Width = 300;
            this.dgvListadoABM.Columns[CAMPO_CLIENTENOMBRE].DisplayIndex = 5;
            this.dgvListadoABM.Columns[CAMPO_CLIENTENOMBRE].Visible = true;

            this.dgvListadoABM.Columns[CAMPO_TRAMITEDESCRIP].HeaderText = "Trámite Padre";
            this.dgvListadoABM.Columns[CAMPO_TRAMITEDESCRIP].Width = 200;
            this.dgvListadoABM.Columns[CAMPO_TRAMITEDESCRIP].DisplayIndex = 6;
            this.dgvListadoABM.Columns[CAMPO_TRAMITEDESCRIP].Visible = true;


        }

        #endregion Método Extendidos del ParentControl

        #region Picks

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
            fPickTramite_FiltrarClick(sender, e);
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

            fPickTramite.Close();
            fPickTramite.Dispose();
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

            if (this.txtParteNombre.Text == "")
                this.txtParteNombre.Text = this.tSBCliente.DisplayMember;


            fPickCliente.Close();
            fPickCliente.Dispose();
        }

        private void tSBAtencion_AceptarClick(object sender, EventArgs e)
        {
            if (this.tSBCliente.KeyMember == "")
            {
                MessageBox.Show("Debe ingresar un cliente válido.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (fPickAtencion == null)
            {
                fPickAtencion = new frmPickBase();
                fPickAtencion.AceptarFiltrarClick += fPickAtencion_AceptarFiltrarClick;
                fPickAtencion.FiltrarClick += fPickAtencion_FiltrarClick;
                fPickAtencion.Titulo = "Elegir Atención";
                fPickAtencion.CampoIDNombre = "AtencionID";
                fPickAtencion.CampoDescripNombre = "AtencionNombre";
                fPickAtencion.LabelCampoID = "ID";
                fPickAtencion.LabelCampoDescrip = "Nombre";
                fPickAtencion.NombreCampo = "Atención";
                fPickAtencion.PermitirFiltroNulo = true;
            }
            fPickAtencion.MostrarFiltro();
            fPickAtencion_FiltrarClick(sender, e);
        }

        private void fPickAtencion_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickAtencion != null)
            {
                int clienteID = Convert.ToInt32(this.tSBCliente.KeyMember);

                var query = (from at in this.DBContext.Atencion
                             select new AtencionType
                             {
                                 AtencionID = at.ID,
                                 AtencionNombre = at.Nombre,
                                 ClienteID = at.ClienteID
                             }).Where(a => a.ClienteID == clienteID);

                fPickAtencion.LoadData<AtencionType>(query.AsQueryable(), fPickAtencion.GetWhereString());
            }
        }

        private void fPickAtencion_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBAtencion.DisplayMember = fPickAtencion.ValorDescrip;
            this.tSBAtencion.KeyMember = fPickAtencion.ValorID;

            fPickAtencion.Close();
            fPickAtencion.Dispose();
        }


        
        #endregion Picks

        #region Controles Locales
        private void tbbBorrar_Click_1(object sender, EventArgs e)
        {
            string caption = "Eliminación de registro";
            string message = "Se eliminará el presente registro ¿Desea continuar?";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(DialogHandler));
        }

        protected override void txtFormEditStatus_TextChanged(object sender, EventArgs e)
        {
            base.txtFormEditStatus_TextChanged(sender, e);

            if (this.FormEditStatus != BROWSE)
            {
                this.grpBoxBuscarExpediente.Enabled = true;
                this.grpBoxBuscarExpediente.TabStop = true;
                if (this.txtOTID.Text != "")
                {
                    this.chkCopiarHI.Enabled = true;
                    this.chkCopiarHI.Visible = true;
                    this.chkCopiarHI.Checked = false;
                }
            }
            else
            {
                this.grpBoxBuscarExpediente.Enabled = false;
                this.grpBoxBuscarExpediente.TabStop = false;
                this.chkCopiarHI.Enabled = false;
                this.chkCopiarHI.Visible = false;
                this.chkCopiarHI.Checked = false;
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string msg = "";

            if ((this.txtActaNro.Text == "") && (this.txtActaAnio.Text == "") && (this.txtRegistroNro.Text == ""))
                msg = "Debe especificar número y año de acta o sólo número de registro";

            if (((this.txtActaNro.Text != "") && (this.txtActaAnio.Text == "")) ||
                ((this.txtActaNro.Text == "") && (this.txtActaAnio.Text != "")))
                msg = "Debe especificar número y año de acta ó sólo número de registro";

            if (msg != "")
            {
                MessageBox.Show(msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                this.getExpediente();
        }

        private void tbbGuardar_Click_1(object sender, EventArgs e)
        {
            #region Validaciones
            if (this.tSBTramite.KeyMember == "")
            {
                MessageBox.Show("Debe ingresar un trámite válido.",
                               "Información",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return;
            }
            
            if (this.tSBCliente.KeyMember == "")
            {
                MessageBox.Show("Debe ingresar un cliente válido.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                
                return;
            }

            if (this.tSBAtencion.KeyMember == "")
            {
                MessageBox.Show("Debe ingresar una atención válida.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            if (Convert.ToInt32(this.tSBTramite.KeyMember) <= 10)
            {
                MessageBox.Show("Trámite no admitido." + Environment.NewLine +
                                "Este tipo de trámite es generado en el Sistema de Marcas.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }
            #endregion Validaciones


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

        private void dgvListadoABM_SelectionChanged(object sender, EventArgs e)
        {
            //if (this.dgvListadoABM.CurrentRow != null)
            //  this.cargarTarifasxCliente(this.dgvListadoABM.CurrentRow);
        }

        private void dgvListadoABM_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (this.dgvListadoABM.CurrentRow != null)
            //this.cargarExpeOpo(this.dgvListadoABM.CurrentRow);
            if (this.LastDGVIndex > -1)
                this.cargarExpeOpo(this.dgvListadoABM.Rows[this.LastDGVIndex]);
        }

        private void ucCargaOpo_VisibleChanged(object sender, EventArgs e)
        {
            this.FormatearGrilla();
        }

        private void dtpFechaPresentacion_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaPresentacion.Text = this.dtpFechaPresentacion.Value.ToShortDateString();
        }
        #endregion Controles Locales

        #region Controles Extendidos

        protected override void tbbCancelar_Click(object sender, EventArgs e)
        {
            base.tbbCancelar_Click(sender, e);

            //if ((this.dgvListadoABM.RowCount > 0) && (this.dgvListadoABM.CurrentRow != null))
            //{
            //    //this.dgvListadoABM.CurrentCell = this.dgvListadoABM.Rows[0].Cells[CAMPO_EXPEOPOID];
            //    this.cargarExpeOpo(this.dgvListadoABM.CurrentRow);
            //}
            if (this.LastDGVIndex > -1)
            {
                this.cargarExpeOpo(this.dgvListadoABM.Rows[this.LastDGVIndex]);
            }
            else
                this.limpiarValores();
        }

        protected override void tbbNuevo_Click(object sender, EventArgs e)
        {
            base.tbbNuevo_Click(sender, e);
            this.limpiarValores();
            this.txtFechaEntrada.Text = System.DateTime.Now.Date.ToShortDateString();
            this.txtActaNro.Focus();
        }

        #endregion Controles Extendidos

        #region Métodos Locales

        private void getExpediente()
        {
            if (this.txtActaNro.Text != "")
            {
                int actanro = Convert.ToInt32(this.txtActaNro.Text);
                int actaanio = Convert.ToInt32(this.txtActaAnio.Text);

                try
                {
                    ExpeOpoType expeopo = (from expediente in this.DBContext.Expediente
                                          join marca in this.DBContext.Marca
                                            on expediente.MarcaID equals marca.ID
                                          join cliente in this.DBContext.Cliente
                                            on marca.ClienteID equals cliente.ID into cli_mar
                                            from cliente in cli_mar.DefaultIfEmpty()
                                          join marcaregren in this.DBContext.MarcaRegRen
                                            on marca.MarcaRegRenID equals marcaregren.ID
                                          join tramite in this.DBContext.Tramite
                                            on expediente.TramiteID equals tramite.ID
                                          join ot in this.DBContext.OrdenTrabajo
                                            on expediente.OrdenTrabajoID equals ot.ID into ot_expe
                                            from ot in ot_expe.DefaultIfEmpty()
                                          select new ExpeOpoType
                                          {
                                              ExpedienteID = expediente.ID,
                                              MarcaID = marca.ID,
                                              DenominacionMarca = marca.Denominacion,
                                              ActaNro = expediente.ActaNro,
                                              ActaAnio = expediente.ActaAnio,
                                              RegistroNro = marcaregren.RegistroNro,
                                              ClienteID = cliente.ID,
                                              ClienteNombre = cliente.Nombre,
                                              TramiteID = expediente.TramiteID,
                                              DescripTramite = tramite.Descrip,
                                              HINro = ot.Nro,
                                              HiAnio = ot.Anio,
                                              OrdenTrabajoID = expediente.OrdenTrabajoID,
                                              FechaPresentacion = expediente.PresentacionFecha
                                          }
                                          ).First(b => b.ActaNro == actanro && b.ActaAnio == actaanio
                                                        /*&& (b.TramiteID == 1 || b.TramiteID == 2)*/);

                    if (expeopo.ActaNro.HasValue)
                        this.txtEdActaNro.Text = expeopo.ActaNro.Value.ToString();
                    if (expeopo.ActaAnio.HasValue)
                        this.txtEdActaAnio.Text = expeopo.ActaAnio.Value.ToString();
                    if (expeopo.RegistroNro.HasValue)
                        this.txtEdRegistroNro.Text = expeopo.RegistroNro.Value.ToString();
                    this.txtDenominacion.Text = expeopo.DenominacionMarca;
                    //this.txtCliente.Text = expeopo.ClienteID.ToString() + " - " + expeopo.ClienteNombre;
                    this.txtTramite.Text = expeopo.DescripTramite;
                    this.txtExpeID.Text = expeopo.ExpedienteID.ToString();

                    if (expeopo.OrdenTrabajoID.HasValue)
                    {
                        this.txtHITexto.Text = expeopo.HITexto;
                        this.txtOTID.Text = expeopo.OrdenTrabajoID.ToString();
                    }

                    this.txtFechaPresentacion.Text = expeopo.FechaPresentacion.HasValue ? expeopo.FechaPresentacion.Value.ToShortDateString() : "";

                    this.tSBTramite.SetFocus();
                }
                catch (InvalidOperationException)
                //catch(Exception ex)
                {
                    MessageBox.Show("No se encontraron expedientes para los filtros especificados." + Environment.NewLine +
                                    "Verifique que el expediente tenga un cliente asociado.", 
                                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (this.txtRegistroNro.Text != "")
            {
                int registronro = Convert.ToInt32(this.txtRegistroNro.Text);

                try
                {
                    var expeopo = (from expediente in this.DBContext.Expediente
                                           join marca in this.DBContext.Marca
                                             on expediente.MarcaID equals marca.ID
                                           join cliente in this.DBContext.Cliente
                                             on marca.ClienteID equals cliente.ID into cli_mar
                                             from cliente in cli_mar.DefaultIfEmpty()
                                           join marcaregren in this.DBContext.MarcaRegRen
                                             on marca.MarcaRegRenID equals marcaregren.ID
                                           join tramite in this.DBContext.Tramite
                                             on expediente.TramiteID equals tramite.ID
                                           join ot in this.DBContext.OrdenTrabajo
                                             on expediente.OrdenTrabajoID equals ot.ID into ot_expe
                                             from ot in ot_expe.DefaultIfEmpty()
                                           select new ExpeOpoType
                                           {
                                               ExpedienteID = expediente.ID,
                                               MarcaID = marca.ID,
                                               DenominacionMarca = marca.Denominacion,
                                               ActaNro = expediente.ActaNro,
                                               ActaAnio = expediente.ActaAnio,
                                               RegistroNro = marcaregren.RegistroNro,
                                               ClienteID = cliente.ID,
                                               ClienteNombre = cliente.Nombre,
                                               TramiteID = expediente.TramiteID,
                                               DescripTramite = tramite.Descrip,
                                               HINro = ot.Nro,
                                               HiAnio = ot.Anio,
                                               OrdenTrabajoID = expediente.OrdenTrabajoID,
                                               FechaPresentacion = expediente.PresentacionFecha
                                           }
                                          ).First(b => b.RegistroNro == registronro
                                                        /*&& (b.TramiteID == 1 || b.TramiteID == 2)*/);

                    if (expeopo.ActaNro.HasValue)
                        this.txtEdActaNro.Text = expeopo.ActaNro.Value.ToString();
                    if (expeopo.ActaAnio.HasValue)
                        this.txtEdActaAnio.Text = expeopo.ActaAnio.Value.ToString();
                    if (expeopo.RegistroNro.HasValue)
                        this.txtEdRegistroNro.Text = expeopo.RegistroNro.Value.ToString();
                    this.txtDenominacion.Text = expeopo.DenominacionMarca;
                    this.txtTramite.Text = expeopo.DescripTramite;
                    this.txtExpeID.Text = expeopo.ExpedienteID.ToString();
                    this.txtFechaPresentacion.Text = expeopo.FechaPresentacion.HasValue ? expeopo.FechaPresentacion.Value.ToShortDateString() : "";

                    if (expeopo.OrdenTrabajoID.HasValue)
                    {
                        this.txtHITexto.Text = expeopo.HITexto;
                        this.txtOTID.Text = expeopo.OrdenTrabajoID.ToString();
                    }

                    this.txtEdActaNro.Focus();
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("No se encontraron expedientes para los filtros especificados." + Environment.NewLine +
                                    "Verifique que el expediente tenga un cliente asociado.",
                                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
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

        private bool existeExpedienteTramite(int expedienteID, int tramiteID, BerkeDBEntities context)
        {
            bool Result = false;

            if ((expedienteID != -1) && (this.FormEditStatus == INSERT))
            {
                var qryExpeTram = (from opo in context.op_oposicion
                                   select new
                                   {
                                       ExpedienteID = opo.ExpedienteID,
                                       TramiteID = opo.TramiteID
                                   })
                                   .Where(a => a.ExpedienteID == expedienteID && a.TramiteID == tramiteID)
                                   .ToList();

                if (qryExpeTram.Count > 0)
                    Result = true;
            }

            return Result;
        }
        #endregion Métodos Locales
        
        #region Limpiar Valores
        private void limpiarValores()
        {
            this.txtActaNro.Text = "";
            this.txtActaAnio.Text = "";
            this.txtRegistroNro.Text = "";
            this.txtEdActaNro.Text = "";
            this.txtEdActaAnio.Text = "";
            this.txtEdRegistroNro.Text = "";
            this.txtTramite.Text = "";
            this.txtDenominacion.Text = "";
            //this.txtCliente.Text = "";
            this.tSBCliente.Clear();
            this.txtExpeOpoID.Text = "";
            this.txtExpeID.Text = "";
            this.tSBTramite.Clear();
            this.txtFechaPresentacion.Text = "";
            this.txtFechaEntrada.Text = "";
            this.txtFechaSalida.Text = "";
            this.txtHITexto.Text = "";
            this.txtOTID.Text = "";
            this.txtParteNombre.Text = "";
            this.txtContraparteNombre.Text = "";
            this.tSBAtencion.Clear();
            this.txtUsuarioCargaID.Text = string.Empty;
            this.txtUsuarioCargaNombre.Text = string.Empty;
        }
        #endregion Limpiar Valores

        #region ReadOnly condicional
        protected override void Editable(bool editar)
        {
            this.tSBCliente.Editable = !editar;
            this.tSBTramite.Editable = !editar;
            this.txtEdActaNro.ReadOnly = editar;
            this.txtEdActaAnio.ReadOnly = editar;
            this.txtDenominacion.ReadOnly = editar;
            this.txtFechaPresentacion.ReadOnly = editar;
            this.txtFechaEntrada.ReadOnly = editar;
            this.txtFechaSalida.ReadOnly = editar;
            this.txtParteNombre.ReadOnly = editar;
            this.txtContraparteNombre.ReadOnly = editar;
            this.tSBAtencion.Editable = !editar;
            this.dtpFechaEntrada.Enabled = !editar;
            this.dtpFechaSalida.Enabled = !editar;
            this.dtpFechaPresentacion.Enabled = !editar;
            
        }
        #endregion ReadOnly condicional

        #region CRUD
        private void EliminarRegistro()
        {
            bool success = false;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        this.eliminarCliente(context);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        success = true;
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
                    this.limpiarValores();
                    this.FilterEntity(this.WhereString, this.FilterParam);
                    this.FormEditStatus = BROWSE;
                    MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void eliminarCliente(BerkeDBEntities context = null)
        {
            int opoID = Convert.ToInt32(this.txtExpeOpoID.Text);
            op_oposicion oposicio = context.op_oposicion.First(a => a.ID == opoID);

            context.op_oposicion.Remove(oposicio);
            
        }

        private void GuardarRegistro()
        {
            bool success = false;
            int cantidadExpedientes = 0;
            string errmsg = "";
            
            op_oposicion opo = null;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        pa_parametros param = this.DBContext.pa_parametros.First(a => a.clave == TRAMITES_MULTIPLES);

                        List<string> listaTramitesMultiples = new List<string>(param.valor.Split(','));
                        int tramiteID = Convert.ToInt32(this.tSBTramite.KeyMember);

                        if (this.chkCopiarHI.Checked)
                        {
                            int otID = Convert.ToInt32(this.txtOTID.Text);
                            string where = "";
                            if (this.FormEditStatus == INSERT)
                            {
                                where = " OrdenTrabajoID = " + otID.ToString();
                            }
                            else if (this.FormEditStatus == EDIT)
                            {
                                where = " OrdenTrabajoID = " + otID.ToString() +
                                        " AND ExpedienteID <> " + this.txtExpeID.Text; ;
                            }

                            var qryExpes = (from expe in context.Expediente
                                            join mrr in context.MarcaRegRen
                                                on expe.MarcaRegRenID equals mrr.ID into mrr_expe
                                            from mrr in mrr_expe.DefaultIfEmpty()
                                            join marca in context.Marca
                                                on expe.MarcaID equals marca.ID
                                            select new
                                            {
                                                ActaNro = expe.ActaNro,
                                                ActaAnio = expe.ActaAnio,
                                                RegistroNro = mrr.RegistroNro,
                                                Denominacion = marca.Denominacion,
                                                ExpedienteID = expe.ID,
                                                OrdenTrabajoID = expe.OrdenTrabajoID,
                                                FechaPresentacion = expe.PresentacionFecha
                                            }
                                            ).Where(where).ToList();

                            

                            foreach (var item in qryExpes)
                            {
                                if ((!this.existeExpedienteTramite(item.ExpedienteID, Convert.ToInt32(this.tSBTramite.KeyMember), context)) ||
                                    (listaTramitesMultiples.Contains(tramiteID.ToString())))
                                {
                                    op_oposicion op = new op_oposicion();
                                    op.ActaNro = item.ActaNro;
                                    op.ActaAnio = item.ActaAnio;
                                    op.RegistroNro = item.RegistroNro;
                                    op.Denominacion = item.Denominacion;
                                    op.ExpedienteID = item.ExpedienteID;
                                    op.ClienteID = Convert.ToInt32(this.tSBCliente.KeyMember);
                                    op.TramiteID = tramiteID; //Convert.ToInt32(this.tSBTramite.KeyMember);
                                    op.OrdenTrabajoID = item.OrdenTrabajoID;
                                    op.PresentacionFecha = item.FechaPresentacion;
                                    op.ParteNombre = this.txtParteNombre.Text != "" ? this.txtParteNombre.Text : null;
                                    op.ContraparteNombre = this.txtContraparteNombre.Text != "" ? this.txtContraparteNombre.Text : null;
                                    op.AtencionID = Convert.ToInt32(this.tSBAtencion.KeyMember);

                                    if (this.txtFechaEntrada.Text != "")
                                        op.FechaEnvio = Convert.ToDateTime(this.txtFechaEntrada.Text);
                                    else
                                        op.FechaEnvio = null;

                                    if (this.txtFechaSalida.Text != "")
                                        op.FechaSalida = Convert.ToDateTime(this.txtFechaSalida.Text);
                                    else
                                        op.FechaSalida = null;
                                    
                                    context.op_oposicion.Add(op);
                                    cantidadExpedientes++;
                                }
                                else
                                {
                                    errmsg += String.Format("No puede ser crear el expediente de {0} para el acta {1} ({2}) porque ya existe un expediente" + Environment.NewLine +
                                                            "de {0} para dicha acta.",
                                                             this.tSBTramite.DisplayMember, item.ActaNro + "/" + item.ActaAnio, item.Denominacion);
                                }
                            }

                        }
                        else
                        {
                            int expeID = -1;
                            if (this.txtExpeID.Text != "")
                                expeID = Convert.ToInt32(this.txtExpeID.Text);

                            if ((!this.existeExpedienteTramite(expeID,
                                                              Convert.ToInt32(this.tSBTramite.KeyMember), 
                                                              context)) ||
                                (listaTramitesMultiples.Contains(tramiteID.ToString())))
                            {
                                opo = this.guardarExpeOpo(context);
                                cantidadExpedientes++;
                            }
                            else
                            {
                                errmsg += String.Format("No puede ser crear el expediente de {0} para el acta {1} ({2}) porque ya existe un expediente" + Environment.NewLine +
                                                        "de {0} para dicha acta.",
                                                         this.tSBTramite.DisplayMember, 
                                                         this.txtEdActaNro.Text + "/" + this.txtEdActaAnio.Text, 
                                                         this.txtDenominacion.Text);
                            }
                        }

                        if (cantidadExpedientes > 0)
                        {
                            context.SaveChanges();
                            dbContextTransaction.Commit();
                            
                        }
                        success = true;
                    }
                    catch (DbEntityValidationException e)
                    {
                        string error = "";
                        string sError = "";
                        foreach (var eve in e.EntityValidationErrors)
                        {
                            error = String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                eve.Entry.Entity.GetType().Name, eve.Entry.State);

                            foreach (var ve in eve.ValidationErrors)
                            {
                                sError = String.Format("Property: \"{0}\", Error: \"{1}\"",
                                    ve.PropertyName, ve.ErrorMessage);
                            }
                        }
                        dbContextTransaction.Rollback();
                        MessageBox.Show("Ocurrió un error al procesar el guardado: " + Environment.NewLine
                                        + error + Environment.NewLine
                                        + sError,
                                        "Error al guardar los datos",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Stop);
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
                string message = "Operación completada con éxito.";

                if (cantidadExpedientes > 1)
                {
                    message += Environment.NewLine + cantidadExpedientes.ToString() + " expedientes creados.";

                }

                if (errmsg == "")
                {
                    MessageBox.Show(message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.FilterEntity(this.WhereString, this.FilterParam);
                    //this.txtExpeOpoID.Text = opo.ID.ToString();
                    this.FormEditStatus = BROWSE;
                }
                else
                {
                    MessageBox.Show("Operación completada con excepciones: " + Environment.NewLine + errmsg,
                                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private op_oposicion guardarExpeOpo(BerkeDBEntities context = null)
        {
            op_oposicion opo = new op_oposicion();
            if (this.FormEditStatus == EDIT)
            {
                int expeopoID = Convert.ToInt32(this.txtExpeOpoID.Text);
                opo = context.op_oposicion.First(a => a.ID == expeopoID);

                if (this.txtEdActaNro.Text != "")
                    opo.ActaNro = Convert.ToInt32(this.txtEdActaNro.Text);

                if (this.txtEdActaAnio.Text != "")
                    opo.ActaAnio = Convert.ToInt32(this.txtEdActaAnio.Text);

                if (this.txtRegistroNro.Text != "")
                    opo.RegistroNro = Convert.ToInt32(this.txtRegistroNro.Text);

                if (this.txtDenominacion.Text != "")
                    opo.Denominacion = this.txtDenominacion.Text;

                if (this.txtExpeID.Text != "")
                    opo.ExpedienteID = Convert.ToInt32(this.txtExpeID.Text);

                if (this.txtFechaEntrada.Text != "")
                    opo.FechaEnvio = Convert.ToDateTime(this.txtFechaEntrada.Text);
                else
                    opo.FechaEnvio = null;

                if (this.txtFechaSalida.Text != "")
                    opo.FechaSalida = Convert.ToDateTime(this.txtFechaSalida.Text);
                else
                    opo.FechaSalida = null;

                opo.ClienteID = Convert.ToInt32(this.tSBCliente.KeyMember);
                opo.TramiteID = Convert.ToInt32(this.tSBTramite.KeyMember);
                opo.AtencionID = Convert.ToInt32(this.tSBAtencion.KeyMember);

                if (this.txtFechaPresentacion.Text != "")
                    opo.PresentacionFecha = Convert.ToDateTime(this.txtFechaPresentacion.Text);

                if (this.txtOTID.Text != "")
                    opo.OrdenTrabajoID = Convert.ToInt32(this.txtOTID.Text);

                opo.ParteNombre = this.txtParteNombre.Text != "" ? this.txtParteNombre.Text : null;
                opo.ContraparteNombre = this.txtContraparteNombre.Text != "" ? this.txtContraparteNombre.Text : null;

            }
            else if (this.FormEditStatus == INSERT)
            {
                if (this.txtEdActaNro.Text != "")
                    opo.ActaNro = Convert.ToInt32(this.txtEdActaNro.Text);

                if (this.txtEdActaAnio.Text != "")
                    opo.ActaAnio = Convert.ToInt32(this.txtEdActaAnio.Text);

                if (this.txtRegistroNro.Text != "")
                    opo.RegistroNro = Convert.ToInt32(this.txtRegistroNro.Text);

                if (this.txtDenominacion.Text != "")
                    opo.Denominacion = this.txtDenominacion.Text;

                if (this.txtExpeID.Text != "")
                    opo.ExpedienteID = Convert.ToInt32(this.txtExpeID.Text);

                if (this.txtFechaEntrada.Text != "")
                    opo.FechaEnvio = Convert.ToDateTime(this.txtFechaEntrada.Text);
                else
                    opo.FechaEnvio = null;

                if (this.txtFechaSalida.Text != "")
                    opo.FechaSalida = Convert.ToDateTime(this.txtFechaSalida.Text);
                else
                    opo.FechaSalida = null;

                opo.ClienteID = Convert.ToInt32(this.tSBCliente.KeyMember);
                opo.TramiteID = Convert.ToInt32(this.tSBTramite.KeyMember);
                opo.AtencionID = Convert.ToInt32(this.tSBAtencion.KeyMember);

                if (this.txtFechaPresentacion.Text != "")
                    opo.PresentacionFecha = Convert.ToDateTime(this.txtFechaPresentacion.Text);

                if (this.txtOTID.Text != "")
                    opo.OrdenTrabajoID = Convert.ToInt32(this.txtOTID.Text);

                opo.ParteNombre = this.txtParteNombre.Text != "" ? this.txtParteNombre.Text : null;
                opo.ContraparteNombre = this.txtContraparteNombre.Text != "" ? this.txtContraparteNombre.Text : null;

                context.op_oposicion.Add(opo);

            }
            return opo;
        }

        private void cargarExpeOpo(DataGridViewRow row)
        {
            this.limpiarValores();
            
            this.txtExpeOpoID.Text = row.Cells[CAMPO_EXPEOPOID].Value.ToString();

            if (row.Cells[CAMPO_EXPEDIENTEID].Value != null)
                this.txtExpeID.Text = row.Cells[CAMPO_EXPEDIENTEID].Value.ToString();
            
            if (row.Cells[CAMPO_ACTANRO].Value != null)
                this.txtEdActaNro.Text = row.Cells[CAMPO_ACTANRO].Value.ToString();

            if (row.Cells[CAMPO_ACTAANIO].Value != null)
            this.txtEdActaAnio.Text = row.Cells[CAMPO_ACTAANIO].Value.ToString();

            if (row.Cells[CAMPO_REGISTRONRO].Value != null)
                this.txtEdRegistroNro.Text = row.Cells[CAMPO_REGISTRONRO].Value.ToString();

            if (row.Cells[CAMPO_TRAMITEDESCRIP].Value != null)
                this.txtTramite.Text = row.Cells[CAMPO_TRAMITEDESCRIP].Value.ToString();

            if (row.Cells[CAMPO_DENOMINACION].Value != null)
                this.txtDenominacion.Text = row.Cells[CAMPO_DENOMINACION].Value.ToString();

            if (row.Cells[CAMPO_FECHAENTRADA].Value != null)
                this.txtFechaEntrada.Text = Convert.ToDateTime(row.Cells[CAMPO_FECHAENTRADA].Value.ToString()).ToShortDateString();
            else
                this.txtFechaEntrada.Text = "";

            if (row.Cells[CAMPO_FECHASALIDA].Value != null)
                this.txtFechaSalida.Text = Convert.ToDateTime(row.Cells[CAMPO_FECHASALIDA].Value.ToString()).ToShortDateString();
            else
                this.txtFechaSalida.Text = "";

            this.tSBCliente.KeyMember = row.Cells[CAMPO_IDCLIENTE].Value.ToString();
            this.tSBCliente.DisplayMember = row.Cells[CAMPO_CLIENTENOMBRE].Value.ToString();
            this.tSBTramite.KeyMember = row.Cells[CAMPO_TRAMITEID].Value.ToString();
            this.tSBTramite.DisplayMember = row.Cells[CAMPO_TRAMITEDESCRIPDESTINO].Value.ToString();

            if (row.Cells[CAMPO_ATENCIONID].Value != null)
            {
                this.tSBAtencion.KeyMember = row.Cells[CAMPO_ATENCIONID].Value.ToString();
                this.tSBAtencion.DisplayMember = row.Cells[CAMPO_ATENCIONNOMBRE].Value.ToString();
            }

            if (row.Cells[CAMPO_FECHAPRESENTACION].Value != null)
                this.txtFechaPresentacion.Text = Convert.ToDateTime(row.Cells[CAMPO_FECHAPRESENTACION].Value.ToString()).ToShortDateString();

            if (row.Cells[CAMPO_ORDENTRABAJOID].Value != null)
            {
                this.txtOTID.Text = row.Cells[CAMPO_ORDENTRABAJOID].Value.ToString();
                this.txtHITexto.Text = row.Cells[CAMPO_HITEXTO].Value.ToString();
            }
            else
            {
                this.txtOTID.Text = "";
                this.txtHITexto.Text = "";
            }

            if (row.Cells[CAMPO_PARTENOMBRE].Value != null)
            {
                this.txtParteNombre.Text = row.Cells[CAMPO_PARTENOMBRE].Value.ToString();
            }

            if (row.Cells[CAMPO_CONTRAPARTENOMBRE].Value != null)
            {
                this.txtContraparteNombre.Text = row.Cells[CAMPO_CONTRAPARTENOMBRE].Value.ToString();
            }

            this.txtUsuarioCargaID.Text = row.Cells[CAMPO_USUARIOCARGAID].Value.ToString();
            this.txtUsuarioCargaNombre.Text = row.Cells[CAMPO_USUARIOCARGANOMBRE].Value.ToString();
        }

        #endregion CRUD

        private void dtpFechaEntrada_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaEntrada.Text = this.dtpFechaEntrada.Value.ToShortDateString();
        }

        private void dtpFechaSalida_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaSalida.Text = this.dtpFechaSalida.Value.ToShortDateString();
        }

        private void tbbEditar_Click_1(object sender, EventArgs e)
        {
            base.tbbEditar_Click(sender, e);
            this.tSBTramite.SetFocus();
        }
    }
}