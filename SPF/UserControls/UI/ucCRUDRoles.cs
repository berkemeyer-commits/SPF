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
using SPF.Forms.UI;
using SPF.UserControls.Base;
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
    public partial class ucCRUDRoles : ucBaseForm2015
    {
        #region Constantes
        private const string CAMPO_ROLID = "RolID";
        private const string CAMPO_ROLDESCRIPCION = "RolDescripcion";
        private const string CAMPO_ROLESADMINISTRADOR = "RolEsAdministrador";
        private const string CAMPO_ROLSISTEMAID = "RolSistemaID";
        private const string CAMPO_ROLREQUIEREPERMISOSESPECIALES = "RolRequierePermisosEspeciales";

        private const string CAMPO_USUARIOID = "UsuarioID";
        private const string CAMPO_USUARIONOMBRE = "UsuarioNombre";
        private const string CAMPO_PUEDE_VER_TODO = "PuedeVerTodo";

        private const string BTN_EXPANDIR_LBL = "Expandir Todo";
        private const string BTN_COLAPSAR_LBL = "Colapsar Todo";

        private const string BTN_ASIGNAR_PERMISOS_ESPECIALES_LBL = "Asignar Permisos Especiales";
        private const string BTN_ELIMINAR_PERMISOS_ESPECIALES_LBL = "Eliminar Permisos Especiales";
        #endregion Constantes

        #region Variables
        private BindingSource bSMenues;
        private BindingSource bSPermisos;        
        private int SistemaID;
        private List<AccesosType> lAccesos;
        frmPickBase fPickUsuario;
        #endregion Variables

        #region Métodos de Inicio
        public ucCRUDRoles()
        {
            InitializeComponent();
        }

        public ucCRUDRoles(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();
            this.DBContext = dbContext;
            this.Titulo = Titulo;
            this.SistemaID = Convert.ToInt32(VWGContext.Current.Session["SistemaID"].ToString());

            lAccesos = new List<AccesosType>();

            var rol = (from ro in this.DBContext.ro_rol
                       select new
                       {
                           RolID = ro.ro_rolid,
                           RolDescripcion = ro.ro_descripcion,
                           RolEsAdministrador = ro.ro_administrador,
                           RolSistemaID = ro.ro_sistemaid,
                           RolRequierePermisosEspeciales = this.DBContext.GetRolRequierePermisosEspeciales(ro.ro_rolid).FirstOrDefault().RequierePermisosEspeciales
                       })
                       .Where(a => a.RolSistemaID.Value == this.SistemaID)
                       .OrderBy(a => a.RolID)
                       .Take(50);

            this.BindingSourceBase = rol.ToList();

            #region Especificar campos para filtro
            this.SetFilter(CAMPO_ROLID, "Rol ID", false);
            this.SetFilter(CAMPO_ROLDESCRIPCION, "Descripción Rol");
            this.SetFilter(CAMPO_ROLESADMINISTRADOR, "Es Admin (S/N)", false);
            this.TituloBuscador = "Buscar Roles";
            #endregion Especificar campos para filtro

            this.bSMenues = new BindingSource();
            this.bSPermisos = new BindingSource();

            this.btnExpandirColapsar.Text = BTN_COLAPSAR_LBL;
            this.chkRequierePermisosEspeciales.Enabled = false;

            this.btnAgregarMenu.Visible = false;
            this.btnEliminarMenu.Visible = false;

            #region Asignación Eventos Deletados
            //Asignar Evento de Validación de carga de campos
            this.ValidarCamposEvent += ucCRUDRoles_ValidarCamposEvent;
            //Asignar Evento para Guardar Registro
            this.CRUDEvent += ucCRUDRoles_CRUDEvent;
            #endregion Asignación Eventos Deletados
        }
        #endregion Métodos de Inicio
        
        #region Picks
        #region Usuario
        private void fPickUsuario_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickUsuario != null)
            {
                fPickUsuario.LoadData<Usuario>(this.DBContext.Usuario, fPickUsuario.GetWhereString());
            }
        }

        private void fPickUsuario_AceptarFiltrarClick(object sender, EventArgs e)
        {
            int rolID = Convert.ToInt32(this.txtRolID.Text);

            ru_rolusuario ru = new ru_rolusuario();
            ru.ru_rolid = rolID;
            ru.ru_usuarioid = Convert.ToInt32(fPickUsuario.ValorID);
            ru.ru_puedevertodo = false;
            this.DBContext.ru_rolusuario.Add(ru);
            this.DBContext.SaveChanges();
            this.CargarPermisos(rolID);
            this.ManejarBotones();

            fPickUsuario.Close();
            fPickUsuario.Dispose();
        }        
        #endregion Usuario
        #endregion Picks

        #region Método Extendidos del ParentControl
        protected override void FilterEntity(string where = "", object[] filterParams = null)
        {
            try
            {
                this.limpiarDatos();

                var query = (from ro in this.DBContext.ro_rol
                             select new
                             {
                                 RolID = ro.ro_rolid,
                                 RolDescripcion = ro.ro_descripcion,
                                 RolEsAdministrador = ro.ro_administrador,
                                 RolSistemaID = ro.ro_sistemaid,
                                 RolRequierePermisosEspeciales = this.DBContext.GetRolRequierePermisosEspeciales(ro.ro_rolid).FirstOrDefault().RequierePermisosEspeciales
                             })
                             .Where(a => a.RolSistemaID.Value == this.SistemaID);

                if (where != "")
                {
                    this.BindingSourceBase = query.Where(where, filterParams).OrderBy(a => a.RolID).ToList();
                }
                else
                {
                    this.BindingSourceBase = query.OrderBy(a => a.RolID).Take(50).ToList();
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

            this.dgvListadoABM.Columns[CAMPO_ROLID].HeaderText = "ID";
            this.dgvListadoABM.Columns[CAMPO_ROLID].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvListadoABM.Columns[CAMPO_ROLID].Width = 70;
            this.dgvListadoABM.Columns[CAMPO_ROLID].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_ROLID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_ROLID].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_ROLDESCRIPCION].HeaderText = "Descripción";
            this.dgvListadoABM.Columns[CAMPO_ROLDESCRIPCION].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvListadoABM.Columns[CAMPO_ROLDESCRIPCION].Width = 150;
            this.dgvListadoABM.Columns[CAMPO_ROLDESCRIPCION].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_ROLDESCRIPCION].Visible = true;
            displayIndex++;

            DataGridViewCheckBoxColumn colEsAdministrador = new DataGridViewCheckBoxColumn();
            colEsAdministrador.DataPropertyName = CAMPO_ROLESADMINISTRADOR;
            colEsAdministrador.Name = CAMPO_ROLESADMINISTRADOR;
            colEsAdministrador.Width = 120;
            colEsAdministrador.HeaderText = "Es Administrador";
            colEsAdministrador.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colEsAdministrador.FalseValue = false;
            colEsAdministrador.TrueValue = true;
            colEsAdministrador.ReadOnly = true;
            this.dgvListadoABM.Columns.Insert(displayIndex, colEsAdministrador);
            displayIndex++;
        }

        protected override void tbbNuevo_Click(object sender, EventArgs e)
        {
            base.tbbNuevo_Click(sender, e);
            this.limpiarDatos();
        }

        protected override void tbbEditar_Click(object sender, EventArgs e)
        {
            //base.tbbEditar_Click(sender, e);
            this.FormEditStatus = EDIT;

            if (this.tabListaABM.SelectedIndex != 3)
            {
                this.tabListaABM.SelectedIndex = 1;
                this.txtDescripcion.Focus();
            }
            else
            {
                if (this.dgvDetPermisos.Rows.Count > 0)
                {
                    this.ManejarBotones();
                }
                else
                    this.btnAgregarPermiso.Focus();
            }
        }

        protected override void tbbCancelar_Click(object sender, EventArgs e)
        {
            base.tbbCancelar_Click(sender, e);

            if (this.LastDGVIndex > -1)
            {
                this.CargarRoles(this.dgvListadoABM.Rows[this.LastDGVIndex]);
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
            this.txtRolID.Text = String.Empty;
            this.chkEsAdministrador.Checked = false;
            this.txtDescripcion.Text = String.Empty;            
        }
        #endregion Limpiar Datos

        #region ReadOnly condicional
        protected override void Editable(bool editar)
        {
            this.chkEsAdministrador.Enabled = !editar;
            this.txtDescripcion.ReadOnly = editar;
            this.txtDescripcion.ReadOnly = editar;
            this.btnAgregarPermiso.Enabled = !editar;
            this.btnEliminarPermiso.Enabled = !editar;
            this.btnAsignarPermisosEspeciales.Enabled = !editar;
        }
        #endregion ReadOnly condicional

        #region Métodos de Apoyo
        private void CargarRoles(DataGridViewRow row)
        {
            this.limpiarDatos();

            this.txtRolID.Text = row.Cells[CAMPO_ROLID].Value.ToString();
            this.txtDescripcion.Text = row.Cells[CAMPO_ROLDESCRIPCION].Value.ToString();
            this.chkEsAdministrador.Checked = row.Cells[CAMPO_ROLESADMINISTRADOR].Value != null ? (bool)row.Cells[CAMPO_ROLESADMINISTRADOR].Value : false;

            this.chkRequierePermisosEspeciales.Visible = (bool)row.Cells[CAMPO_ROLREQUIEREPERMISOSESPECIALES].Value;
            this.chkRequierePermisosEspeciales.Checked = this.chkRequierePermisosEspeciales.Visible;
            this.btnAsignarPermisosEspeciales.Visible = this.chkRequierePermisosEspeciales.Visible;
                      
            //Cargar Menúes
            this.CargarMenues(Convert.ToInt32(this.txtRolID.Text), Convert.ToBoolean(this.chkEsAdministrador.Checked));
            //Cargar Permisos
            this.CargarPermisos(Convert.ToInt32(this.txtRolID.Text));
        }

        private void CargarMenues(int RolID, bool EsAdministrador)
        {
            lAccesos.Clear();

            var query = (from mn in this.DBContext.mn_menu
                         join rm in this.DBContext.rm_rolmenu
                            on mn.mn_idmenu equals rm.rm_menuid into mn_rm
                            from rm in mn_rm.DefaultIfEmpty()
                         join mnp in this.DBContext.mn_menu
                            on mn.mn_idmenupadre equals mnp.mn_idmenu into mn_mnp
                            from mnp in mn_mnp.DefaultIfEmpty()
                         select new AccesosType
                         {
                             MenuID = mn.mn_idmenu,
                             MenuClave = mn.mn_clave,
                             MenuPadreID = mn.mn_idmenupadre,
                             MenuPadreTitulo = mnp.mn_titulo,
                             MenuTitulo = mn.mn_titulo,
                             RolID = rm.rm_rolid,
                             MenuNivel = mn.mn_nivel,
                             MenuOrden = mn.mn_orden,
                             MenuActivo = mn.mn_activo,
                             SistemaID = mn.mn_sistemaid
                         });

            if (!EsAdministrador)
            {
                lAccesos = query.Where(a => a.SistemaID == this.SistemaID && a.RolID == RolID && a.MenuActivo.Value == true).OrderBy(b => b.MenuNivel).ThenBy(c => c.MenuOrden).ToList();
            }
            else
            {
                lAccesos = query.Where(a => a.SistemaID == this.SistemaID && a.MenuActivo.Value == true).OrderBy(b => b.MenuNivel).ThenBy(c => c.MenuOrden).ToList();
            }

            this.tvAccesos.Nodes.Clear();
            if (lAccesos.Count > 0)
            {
                Hashtable hashMenu = new Hashtable();
                
                foreach (AccesosType item in lAccesos)
                {
                    hashMenu[item.MenuID] = item.MenuClave;
                    string title = item.MenuTitulo;
                    if (!item.MenuPadreID.HasValue)
                    {
                        if (this.tvAccesos.Nodes.Find(item.MenuClave, false).Count() == 0)
                            this.tvAccesos.Nodes.Add(new TreeNode() { Name = item.MenuClave, Text = title, ToolTipText = item.MenuTitulo });
                    }
                    else
                    {
                        if (this.tvAccesos.Nodes.Find(item.MenuClave + item.MenuID.ToString(), true).Count() == 0)
                        {
                            this.tvAccesos.Nodes[(string)hashMenu[item.MenuPadreID]].Nodes.Add(new TreeNode()
                            {
                                Name = item.MenuClave + item.MenuID.ToString(),
                                Text = title,
                                ToolTipText = item.MenuTitulo
                            });
                        }
                    }
                }

                this.tvAccesos.ExpandAll();
                this.btnExpandirColapsar.Text = BTN_COLAPSAR_LBL;
            }
        }

        private void CargarPermisos(int RolID)
        {
            var query = (from ru in this.DBContext.ru_rolusuario
                         join usu in this.DBContext.Usuario
                            on ru.ru_usuarioid equals usu.ID
                         select new PermisoRol
                         {
                             PermisoRolID = ru.ru_rolusuarioid,
                             RolID = ru.ru_rolid,
                             UsuarioID = ru.ru_usuarioid,
                             UsuarioNombre = usu.NombrePila,
                             PuedeVerTodo = ru.ru_puedevertodo
                         })
                        .Where(a => a.RolID == RolID).ToList();

            if (query.Count > 0)
            {
                this.bSPermisos.DataSource = query;
                this.dgvDetPermisos.DataSource = this.bSPermisos;
                this.FormatearGrillaPermisos();
            }
            else
                this.dgvDetPermisos.DataSource = null;


        }
        #endregion Métodos de Apoyo

        #region Métodos locales sobre controles

        private void btnExpandirColapsar_Click(object sender, EventArgs e)
        {
            if (this.btnExpandirColapsar.Text == BTN_COLAPSAR_LBL)
            {
                this.tvAccesos.CollapseAll();
                this.btnExpandirColapsar.Text = BTN_EXPANDIR_LBL;
            }
            else
            {
                this.tvAccesos.ExpandAll();
                this.btnExpandirColapsar.Text = BTN_COLAPSAR_LBL;
            }
        }

        private void ucCRUDMovimientoCuenta_VisibleChanged(object sender, EventArgs e)
        {
            if (this.tabListaABM.SelectedIndex == 0)
                this.FormatearGrilla();
        }

        protected override void tabListaABM_SelectedIndexChanging(object sender, TabControlCancelEventArgs e)
        {
            //if (this.FormEditStatus != BROWSE)
            //{
            //    if ((!((this.cbAsociarCobranzas.Visible) && (this.cbAsociarCobranzas.Checked) && ((e.TabPage != tabListaABM.TabPages[0])))))
            //        e.Cancel = true;
            //}
        }

        protected override void dgvListadoABM_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            base.dgvListadoABM_RowEnter(sender, e);

            if ((this.LastDGVIndex > -1) && (!this.IsClosing))
                this.CargarRoles(this.dgvListadoABM.Rows[this.LastDGVIndex]);
        }        

        private void FormatearGrillaPermisos()
        {
            foreach (DataGridViewColumn col in this.dgvDetPermisos.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            this.dgvDetPermisos.ReadOnly = true;
            this.dgvDetPermisos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetPermisos.ItemsPerPage = 10;
            this.dgvDetPermisos.ShowCellToolTips = true;
            this.dgvDetPermisos.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvDetPermisos.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvDetPermisos.DefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvDetPermisos.DefaultCellStyle.BackColor = Color.Transparent;
            this.dgvDetPermisos.MultiSelect = false;

            this.dgvDetPermisos.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;

            int displayIndex = 0;

            this.dgvDetPermisos.Columns[CAMPO_USUARIOID].HeaderText = "Usuario ID";
            this.dgvDetPermisos.Columns[CAMPO_USUARIOID].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDetPermisos.Columns[CAMPO_USUARIOID].Width = 80;
            this.dgvDetPermisos.Columns[CAMPO_USUARIOID].DisplayIndex = displayIndex;
            this.dgvDetPermisos.Columns[CAMPO_USUARIOID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvDetPermisos.Columns[CAMPO_USUARIOID].Visible = true;
            displayIndex++;

            this.dgvDetPermisos.Columns[CAMPO_USUARIONOMBRE].HeaderText = "Nombre Usuario";
            this.dgvDetPermisos.Columns[CAMPO_USUARIONOMBRE].Width = 200;
            this.dgvDetPermisos.Columns[CAMPO_USUARIONOMBRE].DisplayIndex = displayIndex;
            this.dgvDetPermisos.Columns[CAMPO_USUARIONOMBRE].Visible = true;
            displayIndex++;

            if (this.chkRequierePermisosEspeciales.Visible)
            {
                DataGridViewCheckBoxColumn colPuedeVerTodo = new DataGridViewCheckBoxColumn();
                colPuedeVerTodo.DataPropertyName = CAMPO_PUEDE_VER_TODO;
                colPuedeVerTodo.Name = CAMPO_PUEDE_VER_TODO;
                colPuedeVerTodo.Width = 150;
                colPuedeVerTodo.HeaderText = "Permisos Especiales";
                colPuedeVerTodo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colPuedeVerTodo.FalseValue = false;
                colPuedeVerTodo.TrueValue = true;
                colPuedeVerTodo.ReadOnly = true;
                this.dgvDetPermisos.Columns.Insert(displayIndex, colPuedeVerTodo);
                displayIndex++;
            }

        }

        private void dgvDetPermisos_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.FormEditStatus != BROWSE)
            {
                this.btnEliminarPermiso.Enabled = this.dgvDetPermisos.CurrentRow != null;
                this.btnAsignarPermisosEspeciales.Enabled = this.dgvDetPermisos.CurrentRow != null;

                if (this.btnAsignarPermisosEspeciales.Enabled)
                {
                    if ((bool)this.dgvDetPermisos.CurrentRow.Cells[CAMPO_PUEDE_VER_TODO].Value)
                        this.btnAsignarPermisosEspeciales.Text = BTN_ELIMINAR_PERMISOS_ESPECIALES_LBL;
                    else
                        this.btnAsignarPermisosEspeciales.Text = BTN_ASIGNAR_PERMISOS_ESPECIALES_LBL;
                }
            }
        }

        private void dgvDetPermisos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.btnEliminarPermiso.Enabled = this.dgvDetPermisos.CurrentRow != null;
            this.btnAsignarPermisosEspeciales.Enabled = this.dgvDetPermisos.CurrentRow != null;

            if (this.btnAsignarPermisosEspeciales.Enabled)
            {
                if ((bool)this.dgvDetPermisos.CurrentRow.Cells[CAMPO_PUEDE_VER_TODO].Value)
                    this.btnAsignarPermisosEspeciales.Text = BTN_ELIMINAR_PERMISOS_ESPECIALES_LBL;
                else
                    this.btnAsignarPermisosEspeciales.Text = BTN_ASIGNAR_PERMISOS_ESPECIALES_LBL;
            }
        }

        private void tabListaABM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabListaABM.SelectedIndex == 3)
            {
                this.ManejarBotones();
            }
        }

        private void ManejarBotones()
        {
            if (this.dgvDetPermisos.RowCount > 0)
            {
                if (this.FormEditStatus != BROWSE)
                {
                    this.btnEliminarPermiso.Enabled = true;
                    this.btnAsignarPermisosEspeciales.Enabled = true;
                    this.btnAgregarPermiso.Enabled = true;
                }
                else
                {
                    this.btnEliminarPermiso.Enabled = false;
                    this.btnAsignarPermisosEspeciales.Enabled = false;
                    this.btnAgregarPermiso.Enabled = false;
                }
                this.dgvDetPermisos.CurrentCell = this.dgvDetPermisos.Rows[0].Cells[2];
                this.dgvDetPermisos.CurrentCell.Selected = true;
                this.dgvDetPermisos.Focus();
            }
            else
            {
                if (this.FormEditStatus != BROWSE)
                {
                    this.btnEliminarPermiso.Enabled = false;
                    this.btnAsignarPermisosEspeciales.Enabled = false;
                    this.btnAgregarPermiso.Enabled = true;
                    this.btnAgregarPermiso.Focus();
                }
                else
                {
                    this.btnAgregarPermiso.Enabled = false;
                    this.btnAsignarPermisosEspeciales.Enabled = false;
                    this.btnEliminarPermiso.Enabled = false;
                }
            }
        }

        //private void tbbBorrar_Click_1(object sender, EventArgs e)
        //{
        //    string caption = "Eliminación de registro";
        //    string message = "Se eliminará el presente registro ¿Desea continuar?";

        //    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
        //    MessageBox.Show(message, caption, buttons,
        //                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
        //                    new EventHandler(DialogHandler));
        //}

        #endregion Métodos locales sobre controles

        #region CRUD
        private void ucCRUDRoles_CRUDEvent(object sender, EventArgs e)
        {
            ro_rol ro = new ro_rol();

            ro.ro_rolid = this.FormEditStatus != INSERT ? Convert.ToInt32(this.txtRolID.Text) : 0;
            ro.ro_administrador = this.chkEsAdministrador.Checked;
            ro.ro_descripcion = this.txtDescripcion.Text != String.Empty ? this.txtDescripcion.Text : null;
            ro.ro_sistemaid = this.SistemaID;
            
            bool exito = false;

            if (this.FormEditStatus != BROWSE)
            {
                ro = this.GuardarRegistro<ro_rol>(ro);
            }
            else
            {
                exito = this.EliminarRegistro<ro_rol>(ro);
                ro = exito ? ro : null;
            }

            if ((ro != null) || (exito))
            {
                int index = 0;
                if (this.FormEditStatus == INSERT)
                {
                    this.FilterEntity("", null);
                    this.CargarRoles(this.dgvListadoABM.Rows[0]);
                    index = this.dgvListadoABM.Rows.Count - 1;
                }
                else if ((this.FormEditStatus == EDIT) || (this.FormEditStatus == BROWSE))
                {
                    this.FilterEntity(this.WhereString, this.FilterParam);
                    this.CargarRoles(this.dgvListadoABM.Rows[this.LastDGVIndex]);
                    index = this.LastDGVIndex;// > this.dgvListadoABM.Rows.Count - 1 ? this.LastDGVIndex - 1 : this.LastDGVIndex;
                }

                this.FormEditStatus = BROWSE;
                
                if (this.dgvListadoABM.Rows.Count > 0)
                {
                    this.dgvListadoABM.CurrentCell = this.dgvListadoABM.Rows[index].Cells[0];
                    this.dgvListadoABM.CurrentCell.Selected = true;
                }
                
                MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void ucCRUDRoles_ValidarCamposEvent(object sender, EventArgs e)
        {
            if (this.txtDescripcion.Text == "")
            {
                MessageBox.Show("Debe ingresar la descripción del Rol.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            this.ValidOK = true;
        }

        #region Permisos
        private void btnEliminarDetalle_Click(object sender, EventArgs e)
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
                            new EventHandler(DialogHandlerPermiso));
        }

        private void DialogHandlerPermiso(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    if (this.FormEditStatus != BROWSE)
                        this.EliminarPermiso();
                }
            }
        }

        private void EliminarPermiso()
        {
            int permisoID = Convert.ToInt32(this.dgvDetPermisos.CurrentRow.Cells[0].Value);

            ru_rolusuario ru = this.DBContext.ru_rolusuario.First(a => a.ru_rolusuarioid == permisoID);
            this.DBContext.ru_rolusuario.Remove(ru);
            this.DBContext.SaveChanges();
            this.CargarPermisos(Convert.ToInt32(this.txtRolID.Text));

            if (this.dgvDetPermisos.RowCount > 0)
            {
                this.dgvDetPermisos.CurrentCell = this.dgvDetPermisos.Rows[0].Cells[2];
                this.dgvDetPermisos.CurrentCell.Selected = true;
                this.dgvDetPermisos.Focus();
            }
            else
            {
                this.btnEliminarPermiso.Enabled = false;
                this.btnAgregarPermiso.Focus();
            }
        }


        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
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
            fPickUsuario.MostrarFiltro();
        }
        #endregion Permisos        

        private void btnAsignarPermisosEspeciales_Click(object sender, EventArgs e)
        {
            string message = String.Empty;
            string caption = String.Empty;

            if (this.btnAsignarPermisosEspeciales.Text == BTN_ASIGNAR_PERMISOS_ESPECIALES_LBL)
            {
                message = "Se agregarán permisos especiales al usuario seleccionado." + Environment.NewLine +
                          "El usuario podrá ver contenido restringido a perfiles de Administrador." + Environment.NewLine +
                          "¿Desea continuar?";
                caption = "Confirmación de Asignación de Permisos Especiales";
            }
            else
            {
                message = "Se eliminarán los permisos especiales del usuario seleccionado." + Environment.NewLine +
                          "El usuario ya no podrá ver contenido restringido a perfiles de Administrador." + Environment.NewLine +
                          "¿Desea continuar?";
                caption = "Confirmación de Eliminación de Permisos Especiales";
            }
            
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(DialogHandlerPermisoEspeciales));
        }

        private void DialogHandlerPermisoEspeciales(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    if (this.FormEditStatus != BROWSE)
                    {
                        this.ActualizarPermisosEspeciales(this.btnAsignarPermisosEspeciales.Text == BTN_ASIGNAR_PERMISOS_ESPECIALES_LBL);
                    }
                }
            }
        }

        private void ActualizarPermisosEspeciales(bool actualizar)
        {
            int permisoID = Convert.ToInt32(this.dgvDetPermisos.CurrentRow.Cells[0].Value);

            ru_rolusuario ru = this.DBContext.ru_rolusuario.First(a => a.ru_rolusuarioid == permisoID);
            ru.ru_puedevertodo = actualizar;
            this.DBContext.SaveChanges();
            this.CargarPermisos(Convert.ToInt32(this.txtRolID.Text));

            if (this.dgvDetPermisos.RowCount > 0)
            {
                this.dgvDetPermisos.CurrentCell = this.dgvDetPermisos.Rows[0].Cells[2];
                this.dgvDetPermisos.CurrentCell.Selected = true;
                this.dgvDetPermisos.Focus();
            }
            else
            {
                this.btnEliminarPermiso.Enabled = false;
                this.btnAgregarPermiso.Focus();
            }
        }

        #endregion CRUD       

    }
}