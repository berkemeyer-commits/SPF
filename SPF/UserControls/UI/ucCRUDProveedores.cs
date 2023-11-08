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
using SPF.Forms.Base;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.ObjectModel;
using System.Data.Objects.SqlClient;

using SPF.Classes;
using Microsoft.Reporting.WebForms;

#endregion

namespace SPF.UserControls.UI
{
    public partial class ucCRUDProveedores : ucBaseForm
    {
        #region Constantes
        private const string CAMPO_PROVEEDORID = "ProveedorID";
        private const string CAMPO_PROVEEDORNOMBRE = "ProveedorNombre";
        private const string CAMPO_PROVEEDORDIRECCION = "ProveedorDireccion";
        private const string CAMPO_PROVEEDORRUC = "ProveedorRUC";
        private const string CAMPO_PROVEEDORPERSONERIA = "ProveedorPersoneria";
        private const string CAMPO_PROVEEDOROBSERVACION = "ProveedorObservacion";
        private const string CAMPO_PROVEEDORIDIOMAID = "ProveedorIdiomaID";
        private const string CAMPO_PROVEEDORIDIOMA = "ProveedorIdioma";
        private const string CAMPO_PROVEEDORPAISID = "ProveedorPaisID";
        private const string CAMPO_PROVEEDORPAIS = "ProveedorPais";
        private const string CAMPO_PROVEEDORACTIVO = "ProveedorActivo";
        private const string CAMPO_PROVEEDORPUBLICO = "ProveedorPublico";
        private const string CAMPO_PROVEEDORCIUDADID = "ProveedorCiudadID";
        private const string CAMPO_PROVEEDORCIUDAD = "ProveedorCiudad";
        private const string CAMPO_PROVEEDORTELEFONO = "ProveedorTelefono";
        private const string CAMPO_PROVEEDORDDI = "ProveedorDDI";

        private const string ES_ADMINISTRADOR = "EsAdministrador";
        private const string PUEDE_VER_TODO = "PuedeVerTodo";
        #endregion Constantes

        #region Variables
        frmPickBase fPickPais;
        frmPickBase fPickCiudad;
        private bool PuedeVerTodo = false;
        #endregion Variables

        #region Métodos de Inicio
        public ucCRUDProveedores()
        {
            InitializeComponent();
        }

        public ucCRUDProveedores(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();
            this.DBContext = dbContext;
            this.Titulo = Titulo;
            //this.UsuarioID = Convert.ToInt32(VWGContext.Current.Session["UsuarioID"].ToString());
            //Verificamos que el usuario pueda ver todas las solicitudes
            //this.PuedeVerTodo = (((bool)VWGContext.Current.Session[ES_ADMINISTRADOR]) || ((bool)VWGContext.Current.Session[PUEDE_VER_TODO]));
            this.PuedeVerTodo = (((bool)VWGContext.Current.Session[ES_ADMINISTRADOR])
                                || (VWGContext.Current.Session[PUEDE_VER_TODO] != null) && (VWGContext.Current.Session[PUEDE_VER_TODO].ToString().IndexOf(Titulo.Split(new string[] { " - " }, StringSplitOptions.None)[1]) > -1));

            this.chkPublico.Visible = this.PuedeVerTodo;

            var proveedor = (from prov in this.DBContext.pr_proveedor
                             join idio in this.DBContext.CIdioma
                                on prov.pr_idiomaid equals idio.ididioma into idio_prov
                             from idio in idio_prov.DefaultIfEmpty()
                             join pais in this.DBContext.CPais
                                on prov.pr_paisid equals pais.idpais into pais_prov
                             from pais in pais_prov.DefaultIfEmpty()
                             join ciud in this.DBContext.CCiudad
                                on prov.pr_ciudadid equals ciud.idciudad into ciud_prov
                             from ciud in ciud_prov.DefaultIfEmpty()
                             select new
                             {
                                 ProveedorID = prov.pr_proveedorid,
                                 ProveedorNombre = prov.pr_nombre,
                                 ProveedorDireccion = prov.pr_direccion,
                                 ProveedorRUC = prov.pr_ruc,
                                 ProveedorPersoneria = prov.pr_personeria,
                                 ProveedorObservacion = prov.pr_obs,
                                 ProveedorIdiomaID = prov.pr_idiomaid,
                                 ProveedorIdioma = idio.descrip,
                                 ProveedorPaisID = prov.pr_paisid,
                                 ProveedorPais = pais.descrip,
                                 ProveedorActivo = prov.pr_activo,
                                 ProveedorPublico = prov.pr_publico,
                                 ProveedorCiudadID = prov.pr_ciudadid,
                                 ProveedorCiudad = ciud.nomciudad,
                                 ProveedorTelefono = prov.pr_telefono,
                                 ProveedorDDI = prov.pr_ddi
                             })
                             .OrderByDescending(a => a.ProveedorID)
                             .Take(50);

            this.BindingSourceBase = proveedor.ToList();

            #region Especificar campos para filtro
            this.SetFilter(CAMPO_PROVEEDORID, "ID Proveedor", false);
            this.SetFilter(CAMPO_PROVEEDORNOMBRE, "Nombre Prov.");
            this.SetFilter(CAMPO_PROVEEDORDIRECCION, "Dir. Proveedor", false);
            this.SetFilter(CAMPO_PROVEEDORRUC, "RUC Proveedor");
            this.SetFilter(CAMPO_PROVEEDORPERSONERIA, "Pers. Proveedor");
            this.SetFilter(CAMPO_PROVEEDORIDIOMAID, "Idioma ID", false);
            this.SetFilter(CAMPO_PROVEEDORIDIOMA, "Idioma Prov.");
            this.SetFilter(CAMPO_PROVEEDORPAISID, "País ID", false);
            this.SetFilter(CAMPO_PROVEEDORPAIS, "País Proveedor");
            this.SetFilter(CAMPO_PROVEEDORACTIVO, "Prov. Activo (S/N)", false);
            this.SetFilter(CAMPO_PROVEEDORCIUDADID, "Ciudad ID", false);
            this.SetFilter(CAMPO_PROVEEDORCIUDAD, "Ciudad Prov.");
            this.SetFilter(CAMPO_PROVEEDORTELEFONO, "Teléfono Prov.");
            this.SetFilter(CAMPO_PROVEEDORDDI, "DDI Proveedor");

            if (this.PuedeVerTodo)
                this.SetFilter(CAMPO_PROVEEDORPUBLICO, "Público (S/N)", false);

            this.TituloBuscador = "Buscar Proveedores";
            #endregion Especificar campos para filtro

            #region Inicializar TextSearchBoxes
            this.tSBPais.KeyMemberWidth = 36;
            this.tSBPais.ToolTip = "Elegir País";
            this.tSBPais.AceptarClick += tSBPais_AceptarClick;

            this.tSBCiudad.KeyMemberWidth = 36;
            this.tSBCiudad.ToolTip = "Elegir País";
            this.tSBCiudad.AceptarClick += tSBCiudad_AceptarClick;
            #endregion Inicializar TextSearchBoxes

            this.cargarCBIdioma();
        }
        #endregion Métodos de Inicio

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
        #endregion Combo Idioma

        #region Método Extendidos del ParentControl
        protected override void FilterEntity(string where = "", object[] filterParams = null)
        {
            try
            {
                this.limpiarDatos();

                var query = (from prov in this.DBContext.pr_proveedor
                             join idio in this.DBContext.CIdioma
                                on prov.pr_idiomaid equals idio.ididioma into idio_prov
                             from idio in idio_prov.DefaultIfEmpty()
                             join pais in this.DBContext.CPais
                                on prov.pr_paisid equals pais.idpais into pais_prov
                             from pais in pais_prov.DefaultIfEmpty()
                             join ciud in this.DBContext.CCiudad
                                on prov.pr_ciudadid equals ciud.idciudad into ciud_prov
                             from ciud in ciud_prov.DefaultIfEmpty()
                             select new
                             {
                                 ProveedorID = prov.pr_proveedorid,
                                 ProveedorNombre = prov.pr_nombre,
                                 ProveedorDireccion = prov.pr_direccion,
                                 ProveedorRUC = prov.pr_ruc,
                                 ProveedorPersoneria = prov.pr_personeria,
                                 ProveedorObservacion = prov.pr_obs,
                                 ProveedorIdiomaID = prov.pr_idiomaid,
                                 ProveedorIdioma = idio.descrip,
                                 ProveedorPaisID = prov.pr_paisid,
                                 ProveedorPais = pais.descrip,
                                 ProveedorActivo = prov.pr_activo,
                                 ProveedorPublico = prov.pr_publico,
                                 ProveedorCiudadID = prov.pr_ciudadid,
                                 ProveedorCiudad = ciud.nomciudad,
                                 ProveedorTelefono = prov.pr_telefono,
                                 ProveedorDDI = prov.pr_ddi
                             });

                if (where != "")
                {
                    this.BindingSourceBase = query.Where(where, filterParams).OrderByDescending(a => a.ProveedorID).ToList();
                }
                else
                {
                    this.BindingSourceBase = query.OrderByDescending(a => a.ProveedorID).Take(50).ToList();
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
                col.ReadOnly = true;
            }

            int displayIndex = 0;

            this.dgvListadoABM.Columns[CAMPO_PROVEEDORID].HeaderText = "Proveedor ID";
            this.dgvListadoABM.Columns[CAMPO_PROVEEDORID].Width = 100;
            this.dgvListadoABM.Columns[CAMPO_PROVEEDORID].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_PROVEEDORID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_PROVEEDORID].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_PROVEEDORNOMBRE].HeaderText = "Razón Social";
            this.dgvListadoABM.Columns[CAMPO_PROVEEDORNOMBRE].Width = 250;
            this.dgvListadoABM.Columns[CAMPO_PROVEEDORNOMBRE].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_PROVEEDORNOMBRE].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_PROVEEDORRUC].HeaderText = "RUC";
            this.dgvListadoABM.Columns[CAMPO_PROVEEDORRUC].Width = 100;
            this.dgvListadoABM.Columns[CAMPO_PROVEEDORRUC].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_PROVEEDORRUC].Visible = true;
            displayIndex++;

            DataGridViewCheckBoxColumn colActivo = new DataGridViewCheckBoxColumn();
            colActivo.DataPropertyName = CAMPO_PROVEEDORACTIVO;
            colActivo.Name = CAMPO_PROVEEDORACTIVO;
            colActivo.HeaderText = "Activo";
            colActivo.FalseValue = false;
            colActivo.TrueValue = true;
            colActivo.ReadOnly = true;
            this.dgvListadoABM.Columns.Insert(displayIndex, colActivo);
        }

        protected override void tbbNuevo_Click(object sender, EventArgs e)
        {
            base.tbbNuevo_Click(sender, e);
            this.limpiarDatos();
            this.chkActivo.Checked = true;
            this.txtNombre.Focus();
        }

        protected override void tbbEditar_Click(object sender, EventArgs e)
        {
            base.tbbEditar_Click(sender, e);
            this.txtNombre.Focus();
        }

        protected override void tbbCancelar_Click(object sender, EventArgs e)
        {
            base.tbbCancelar_Click(sender, e);

            if (this.LastDGVIndex > -1)
            {
                this.CargarProveedor(this.dgvListadoABM.Rows[this.LastDGVIndex]);
            }
            else
            {
                this.limpiarDatos();
            }
        }

        #endregion Método Extendidos del ParentControl

        #region Limpiar Datos
        private void limpiarDatos()
        {
            this.txtProveedorID.Text = "";
            this.txtNombre.Text = "";
            this.txtDireccion.Text = "";
            this.txtRUC.Text = "";
            this.txtObservaciones.Text = "";
            this.txtTelefono.Text = "";
            this.rbJuridica.Checked = false;
            this.rbFisica.Checked = false;
            //this.txtDDIPais.Text = "";
            //this.txtDDICiudad.Text = "";
            this.cbIdioma.SelectedValue = -1;
            this.tSBPais.Clear();
            this.tSBCiudad.Clear();
            this.chkActivo.Checked = false;
            this.chkPublico.Checked = false;
        }
        #endregion Limpiar Datos

        #region ReadOnly condicional
        protected override void Editable(bool editar)
        {
            this.txtProveedorID.ReadOnly = editar;
            this.txtNombre.ReadOnly = editar;
            this.txtDireccion.ReadOnly = editar;
            this.txtRUC.ReadOnly = editar;
            this.txtObservaciones.ReadOnly = editar;
            this.txtTelefono.ReadOnly = editar;
            this.cbIdioma.Enabled = !editar;
            this.rbJuridica.Enabled = !editar;
            this.rbFisica.Enabled = !editar;
            //this.txtDDIPais.ReadOnly = editar;
            //this.txtDDICiudad.ReadOnly = editar;
            this.tSBPais.Editable = !editar;
            this.tSBCiudad.Editable = !editar;
            this.chkActivo.Enabled = !editar;
            this.chkPublico.Enabled = !editar;
        }
        #endregion ReadOnly condicional

        #region Métodos locales sobre controles
        private void dgvListadoABM_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this.LastDGVIndex > -1)
                this.CargarProveedor(this.dgvListadoABM.Rows[this.LastDGVIndex]);
        }

        private void tbbGuardar_Click_1(object sender, EventArgs e)
        {
            if (this.txtNombre.Text == "")
            {
                MessageBox.Show("Debe ingresar la Razón Social del proveedor.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (this.txtRUC.Text == "")
            {
                MessageBox.Show("Debe ingresar el RUC del proveedor.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

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

        #region Métodos de Apoyo
        private void CargarProveedor(DataGridViewRow row)
        {
            this.limpiarDatos();

            this.txtProveedorID.Text = row.Cells[CAMPO_PROVEEDORID].Value.ToString();
            this.txtNombre.Text = row.Cells[CAMPO_PROVEEDORNOMBRE].Value.ToString();
            this.txtRUC.Text = row.Cells[CAMPO_PROVEEDORRUC].Value != null ?
                row.Cells[CAMPO_PROVEEDORRUC].Value.ToString() :
                "";

            this.txtTelefono.Text = row.Cells[CAMPO_PROVEEDORTELEFONO].Value != null ?
                row.Cells[CAMPO_PROVEEDORTELEFONO].Value.ToString() :
                "";

            if (row.Cells[CAMPO_PROVEEDORPAISID].Value != null)
            {
                this.tSBPais.KeyMember = row.Cells[CAMPO_PROVEEDORPAISID].Value.ToString();
                this.tSBPais.DisplayMember = row.Cells[CAMPO_PROVEEDORPAIS].Value.ToString();
            }

            if (row.Cells[CAMPO_PROVEEDORCIUDADID].Value != null)
            {
                this.tSBCiudad.KeyMember = row.Cells[CAMPO_PROVEEDORCIUDADID].Value.ToString();
                this.tSBCiudad.DisplayMember = row.Cells[CAMPO_PROVEEDORCIUDAD].Value.ToString();
            }

            this.txtDireccion.Text = row.Cells[CAMPO_PROVEEDORDIRECCION].Value != null ?
                row.Cells[CAMPO_PROVEEDORDIRECCION].Value.ToString() :
                "";

            if (row.Cells[CAMPO_PROVEEDORACTIVO].Value != null)
                this.chkActivo.Checked = (bool)row.Cells[CAMPO_PROVEEDORACTIVO].Value;

            if (row.Cells[CAMPO_PROVEEDORPUBLICO].Value != null)
                this.chkPublico.Checked = (bool)row.Cells[CAMPO_PROVEEDORPUBLICO].Value;

            this.txtObservaciones.Text = row.Cells[CAMPO_PROVEEDOROBSERVACION].Value != null ?
                row.Cells[CAMPO_PROVEEDOROBSERVACION].Value.ToString() :
                "";

            #region Datos Idioma
            if (row.Cells[CAMPO_PROVEEDORIDIOMAID].Value != null)
            {
                this.cbIdioma.SelectedValue = (int)row.Cells[CAMPO_PROVEEDORIDIOMAID].Value;
            }
            #endregion Datos Pais

            #region Personeria
            string personeria = row.Cells[CAMPO_PROVEEDORPERSONERIA].Value != null ?
                row.Cells[CAMPO_PROVEEDORPERSONERIA].Value.ToString() :
                "";

            switch (personeria)
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

        }
        #endregion Métodos de Apoyo

        #region CRUD
        private void GuardarRegistro()
        {
            bool success = false;
            
            pr_proveedor prov = null;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        prov = this.guardarProveedor(context);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
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
                if (this.FormEditStatus == INSERT)
                    this.FilterEntity(CAMPO_PROVEEDORID + " = " + prov.pr_proveedorid.ToString(), null);
                else if (this.FormEditStatus == EDIT)
                    this.FilterEntity(this.WhereString, this.FilterParam);
                                
                this.FormEditStatus = BROWSE;
                this.CargarProveedor(this.dgvListadoABM.Rows[this.LastDGVIndex]);

                MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EliminarRegistro()
        {
            bool success = false;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        this.eliminarProveedor(context);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
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

        #region Métodos de Edición de Datos
        private pr_proveedor guardarProveedor(BerkeDBEntities context = null)
        {
            pr_proveedor prov = new pr_proveedor();
            if (this.FormEditStatus == EDIT)
            {
                int proveedorID = Convert.ToInt32(this.txtProveedorID.Text);

                prov = context.pr_proveedor.First(a => a.pr_proveedorid == proveedorID);

                prov.pr_nombre = this.txtNombre.Text != "" ? this.txtNombre.Text : "";
                prov.pr_direccion = this.txtDireccion.Text != "" ? this.txtDireccion.Text : "";
                prov.pr_ruc = this.txtRUC.Text;
                prov.pr_obs = this.txtObservaciones.Text != "" ? this.txtObservaciones.Text : null;
                prov.pr_activo = this.chkActivo.Checked;
                prov.pr_publico = this.chkPublico.Checked;
                prov.pr_telefono = this.txtTelefono.Text != "" ? this.txtTelefono.Text : null;

                #region Personeria
                prov.pr_personeria = null;
                if (this.rbJuridica.Checked)
                    prov.pr_personeria = "J";
                else if (this.rbFisica.Checked)
                    prov.pr_personeria = "F";
                #endregion Personeria

                #region Datos Pais
                int paisID;
                if (int.TryParse(this.tSBPais.KeyMember, out paisID))
                {
                    prov.pr_paisid = paisID;
                }
                else
                    prov.pr_paisid = null;
                #endregion Datos Pais

                #region Datos Idioma
                int idiomaID = Convert.ToInt32(this.cbIdioma.SelectedValue.ToString());
                if (idiomaID > 0)
                {
                    prov.pr_idiomaid = idiomaID;
                }
                else prov.pr_idiomaid = null;
                #endregion Datos Pais

                #region Datos Ciudad
                int ciudadID;
                if (int.TryParse(this.tSBCiudad.KeyMember, out ciudadID))
                {
                    prov.pr_ciudadid = ciudadID;
                }
                else prov.pr_ciudadid = null;
                #endregion Datos Ciudad
            }
            else if (this.FormEditStatus == INSERT)
            {
                prov.pr_nombre = this.txtNombre.Text != "" ? this.txtNombre.Text : "";
                prov.pr_direccion = this.txtDireccion.Text != "" ? this.txtDireccion.Text : "";
                prov.pr_ruc = this.txtRUC.Text;
                prov.pr_obs = this.txtObservaciones.Text != "" ? this.txtObservaciones.Text : null;
                prov.pr_activo = this.chkActivo.Checked;
                prov.pr_publico = this.chkPublico.Checked;
                prov.pr_telefono = this.txtTelefono.Text != "" ? this.txtTelefono.Text : null;

                #region Personeria
                prov.pr_personeria = null;
                if (this.rbJuridica.Checked)
                    prov.pr_personeria = "J";
                else if (this.rbFisica.Checked)
                    prov.pr_personeria = "F";
                #endregion Personeria

                #region Datos Pais
                int paisID;
                if (int.TryParse(this.tSBPais.KeyMember, out paisID))
                {
                    prov.pr_paisid = paisID;
                }
                else
                    prov.pr_paisid = null;
                #endregion Datos Pais

                #region Datos Idioma
                int idiomaID = Convert.ToInt32(this.cbIdioma.SelectedValue.ToString());
                if (idiomaID > 0)
                {
                    prov.pr_idiomaid = idiomaID;
                }
                else prov.pr_idiomaid = null;
                #endregion Datos Pais

                #region Datos Ciudad
                int ciudadID;
                if (int.TryParse(this.tSBCiudad.KeyMember, out ciudadID))
                {
                    prov.pr_ciudadid = ciudadID;
                }
                else prov.pr_ciudadid = null;
                #endregion Datos Ciudad   
                context.pr_proveedor.Add(prov);
            }

            return prov;
        }

        private void eliminarProveedor(BerkeDBEntities context = null)
        {
            int proveedorID = Convert.ToInt32(this.txtProveedorID.Text);
            pr_proveedor prov = context.pr_proveedor.First(a => a.pr_proveedorid == proveedorID);

            context.pr_proveedor.Remove(prov);
            
        }
        #endregion Métodos de Edición de Datos

        #endregion CRUD
    }
}