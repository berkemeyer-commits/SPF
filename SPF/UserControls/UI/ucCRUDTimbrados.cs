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
    public partial class ucCRUDTimbrados : ucBaseForm2015
    {
        #region Constantes
        private const string CAMPO_TIMBRADOID = "TimbradoID";
        private const string CAMPO_TIMBRADONRO = "TimbradoNro";
        private const string CAMPO_TIMBRADOFECVIGDESDE = "TimbradoFecVigDesde";
        private const string CAMPO_TIMBRADOFECVIGHASTA = "TimbradoFecVigHasta";
        private const string CAMPO_TIMBRADONRODESDE = "TimbradoNroDesde";
        private const string CAMPO_TIMBRADONROHASTA = "TimbradoNroHasta";
        private const string CAMPO_TIMBRADOVIGENTE = "TimbradoVigente";
        private const string CAMPO_TIMBRADOSERIE = "TimbradoSerie";
        private const string CAMPO_TIMBRADOSUCURSAL = "TimbradoSucursal";
        private const string CAMPO_TIMBRADODESCRIPCION = "TimbradoDescripcion";
        private const string CAMPO_TIMBRADOHOJASUELTA = "TimbradoHojaSuelta";
        private const string CAMPO_TIMBRADOTIPODOCUMENTOID = "TimbradoTipoDocumentoID";
        private const string CAMPO_TIMBRADOTIPODOCUMENTODESCRIPCION = "TimbradoTipoDocumentoDescripcion";
        private const string CAMPO_TIMBRADOUSUARIOEXCLUSIVOID = "TimbradoUsuarioExclusivoId";
        private const string CAMPO_TIMBRADOUSUARIOEXCLUSIVONOMBRE = "TimbradoUsuarioExclusivoNombre";
        
        private const string CAMPO_USUARIOID = "UsuarioID";
        private const string CAMPO_USUARIONOMBRE = "UsuarioNombre";
        private const int SISTEMA_ID = 1;
        private const int RECIBO_ID = 14;
        #endregion Constantes

        #region Variables
        private BindingSource bS;
        frmPickBase fPickUsuario, fPickDocumento, fPickUsuarioExclusivo;
        #endregion Variables

        #region Métodos de Inicio
        public ucCRUDTimbrados()
        {
            InitializeComponent();
        }

        public ucCRUDTimbrados(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();
            this.DBContext = dbContext;
            this.Titulo = Titulo;

            var timbrado = (from ti in this.DBContext.ti_timbrado
                            join td in this.DBContext.td_tipodocumento
                                on ti.ti_tipodocumentoid equals td.td_tipodocumentoid
                            join us in this.DBContext.Usuario
                                on ti.ti_usuarioid equals us.ID into us_ti
                            from us in us_ti.DefaultIfEmpty()
                             select new
                             {
                                 TimbradoID = ti.ti_timbradoid,
                                 TimbradoNro = ti.ti_nrotimbrado,
                                 TimbradoFecVigDesde = ti.ti_vigenciadesde,
                                 TimbradoFecVigHasta = ti.ti_vigenciahasta,
                                 TimbradoNroDesde = ti.ti_numerodesde,
                                 TimbradoNroHasta = ti.ti_numerohasta,
                                 TimbradoVigente = ti.ti_vigente,
                                 TimbradoSerie = ti.ti_serie,
                                 TimbradoSucursal = ti.ti_sucursal,
                                 TimbradoDescripcion = ti.ti_descripcion,
                                 TimbradoHojaSuelta = ti.ti_facthojasuelta,
                                 TimbradoTipoDocumentoID = ti.ti_tipodocumentoid,
                                 TimbradoTipoDocumentoDescripcion = td.td_descripcion,
                                 TimbradoUsuarioExclusivoId = ti.ti_usuarioid,
                                 TimbradoUsuarioExclusivoNombre = us.NombrePila
                             })
                              .OrderByDescending(a => a.TimbradoID)
                              .Take(50);

            this.BindingSourceBase = timbrado.ToList();

            #region Especificar campos para filtro
            this.SetFilter(CAMPO_TIMBRADOID, "Timbrado ID", false);
            this.SetFilter(CAMPO_TIMBRADONRO, "N° Timbrado");
            this.SetFilter(CAMPO_TIMBRADOTIPODOCUMENTOID, "Tipo Doc. ID", false);
            this.SetFilter(CAMPO_TIMBRADOTIPODOCUMENTODESCRIPCION, "Tipo Doc. Desc.");
            this.SetFilter(CAMPO_TIMBRADOFECVIGDESDE, "Fec. Vig. Desde");
            this.SetFilter(CAMPO_TIMBRADOFECVIGHASTA, "Fec. Vig. Hasta");
            this.SetFilter(CAMPO_TIMBRADONRODESDE, "N° Desde", false);
            this.SetFilter(CAMPO_TIMBRADONROHASTA, "N° Hasta", false);
            this.SetFilter(CAMPO_TIMBRADOVIGENTE, "Vigente (S/N)", false);
            this.SetFilter(CAMPO_TIMBRADOSERIE, "Serie");
            this.SetFilter(CAMPO_TIMBRADOSUCURSAL, "Sucursal");
            this.SetFilter(CAMPO_TIMBRADODESCRIPCION, "Descripción");
            this.SetFilter(CAMPO_TIMBRADOHOJASUELTA, "Imp. Hoja suelta (S/N)", false);
            this.SetFilter(CAMPO_TIMBRADOUSUARIOEXCLUSIVOID, "Usu. Exc. Id", false);
            this.SetFilter(CAMPO_TIMBRADOUSUARIOEXCLUSIVONOMBRE, "Usu. Exclusivo");
            this.TituloBuscador = "Buscar Timbrados";
            #endregion Especificar campos para filtro

            this.tSBDocumento.KeyMemberWidth = 30;
            this.tSBDocumento.ToolTip = "Elegir Tipo Documento";
            this.tSBDocumento.AceptarClick += tSBDocumento_AceptarClick;
            this.tSBDocumento.KeyMemberTextChanged += tSBDocumento_KeyMemberTextChanged;

            this.tSBUsuario.KeyMemberWidth = 30;
            this.tSBUsuario.ToolTip = "Elegir Usuario Exclusivo";
            this.tSBUsuario.AceptarClick += tsBUsuario_AceptarClick;
            
            this.bS = new BindingSource();

            #region Asignación Eventos Deletados
            //Asignar Evento de Validación de carga de campos
            this.ValidarCamposEvent += ucCRUDTimbrados_ValidarCamposEvent;
            //Asignar Evento para Guardar Registro
            this.CRUDEvent += ucCRUDTimbrados_CRUDEvent;
            #endregion Asignación Eventos Deletados

            this.lblUsuario.Text = "Usuario" + Environment.NewLine + "Exclusivo";
        }

        private void tSBDocumento_KeyMemberTextChanged(object sender, EventArgs e)
        {
            int documentoId = -1;
            if (int.TryParse(this.tSBDocumento.KeyMember, out documentoId))
            {
                bool mostrarUsuExc = documentoId == RECIBO_ID;
                this.lblUsuario.Visible = mostrarUsuExc;
                this.tSBUsuario.Visible = mostrarUsuExc;
            }
        }
        #endregion Métodos de Inicio


        #region Picks
        #region Tipo Documento
        private void tSBDocumento_AceptarClick(object sender, EventArgs e)
        {
            if (fPickDocumento == null)
            {
                fPickDocumento = new frmPickBase();
                fPickDocumento.AceptarFiltrarClick += fPickDocumento_AceptarFiltrarClick;
                fPickDocumento.FiltrarClick += fPickDocumento_FiltrarClick;
                fPickDocumento.Titulo = "Elegir Documento a Autorizar";
                fPickDocumento.CampoIDNombre = "td_tipodocumentoid";
                fPickDocumento.CampoDescripNombre = "td_descripcion";
                fPickDocumento.LabelCampoID = "ID";
                fPickDocumento.LabelCampoDescrip = "Documento";
                fPickDocumento.NombreCampo = "Documento";
                fPickDocumento.PermitirFiltroNulo = true;
            }
            fPickDocumento.MostrarFiltro();
            this.fPickDocumento_FiltrarClick(sender, e);
        }

        private void fPickDocumento_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickDocumento != null)
            {
                fPickDocumento.LoadData<td_tipodocumento>(this.DBContext.td_tipodocumento.Where(a => a.td_mostrar == true && a.td_sistemaid == SISTEMA_ID),
                                                          fPickDocumento.GetWhereString());
            }
        }

        private void fPickDocumento_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBDocumento.DisplayMember = fPickDocumento.ValorDescrip;
            this.tSBDocumento.KeyMember = fPickDocumento.ValorID;

            fPickDocumento.Close();
            fPickDocumento.Dispose();
        }
        #endregion Tipo Documento

        #region Usuario Exclusivo
        private void tsBUsuario_AceptarClick(object sender, EventArgs e)
        {
            if (fPickUsuarioExclusivo == null)
            {
                fPickUsuarioExclusivo = new frmPickBase();
                fPickUsuarioExclusivo.AceptarFiltrarClick += fPickUsuarioExclusivo_AceptarFiltrarClick;
                fPickUsuarioExclusivo.FiltrarClick += fPickUsuarioExclusivo_FiltrarClick;
                fPickUsuarioExclusivo.Titulo = "Elegir Usuario Exclusivo";
                fPickUsuarioExclusivo.CampoIDNombre = "ID";
                fPickUsuarioExclusivo.CampoDescripNombre = "Nombre";
                fPickUsuarioExclusivo.LabelCampoID = "ID";
                fPickUsuarioExclusivo.LabelCampoDescrip = "Nombre";
                fPickUsuarioExclusivo.NombreCampo = "Usuario Exc.";
                fPickUsuarioExclusivo.PermitirFiltroNulo = true;
            }
            fPickUsuarioExclusivo.MostrarFiltro();
            this.fPickUsuarioExclusivo_FiltrarClick(sender, e);
        }

        private void fPickUsuarioExclusivo_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickUsuarioExclusivo != null)
            {
                fPickUsuarioExclusivo.LoadData<Usuario>(this.DBContext.Usuario, fPickUsuarioExclusivo.GetWhereString());
            }
        }

        private void fPickUsuarioExclusivo_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBUsuario.DisplayMember = fPickUsuarioExclusivo.ValorDescrip;
            this.tSBUsuario.KeyMember = fPickUsuarioExclusivo.ValorID;

            fPickUsuarioExclusivo.Close();
            fPickUsuarioExclusivo.Dispose();
        }
        #endregion Usuario Exclusivo

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
            int timbradoID = Convert.ToInt32(this.txtTimbradoID.Text);

            su_serieusuario su = new su_serieusuario();
            su.su_timbradoid = timbradoID;
            su.su_usuarioid = Convert.ToInt32(fPickUsuario.ValorID);
            this.DBContext.su_serieusuario.Add(su);
            this.DBContext.SaveChanges();
            this.CargarPermisos(timbradoID);
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

                var query = (from ti in this.DBContext.ti_timbrado
                             join td in this.DBContext.td_tipodocumento
                                 on ti.ti_tipodocumentoid equals td.td_tipodocumentoid
                             join us in this.DBContext.Usuario
                                on ti.ti_usuarioid equals us.ID into us_ti
                             from us in us_ti.DefaultIfEmpty()
                             select new
                             {
                                 TimbradoID = ti.ti_timbradoid,
                                 TimbradoNro = ti.ti_nrotimbrado,
                                 TimbradoFecVigDesde = ti.ti_vigenciadesde,
                                 TimbradoFecVigHasta = ti.ti_vigenciahasta,
                                 TimbradoNroDesde = ti.ti_numerodesde,
                                 TimbradoNroHasta = ti.ti_numerohasta,
                                 TimbradoVigente = ti.ti_vigente,
                                 TimbradoSerie = ti.ti_serie,
                                 TimbradoSucursal = ti.ti_sucursal,
                                 TimbradoDescripcion = ti.ti_descripcion,
                                 TimbradoHojaSuelta = ti.ti_facthojasuelta,
                                 TimbradoTipoDocumentoID = ti.ti_tipodocumentoid,
                                 TimbradoTipoDocumentoDescripcion = td.td_descripcion,
                                 TimbradoUsuarioExclusivoId = ti.ti_usuarioid,
                                 TimbradoUsuarioExclusivoNombre = us.NombrePila
                             });

                if (where != "")
                {
                    this.BindingSourceBase = query.Where(where, filterParams).OrderByDescending(a => a.TimbradoID).ToList();
                }
                else
                {
                    this.BindingSourceBase = query.OrderByDescending(a => a.TimbradoID).Take(50).ToList();
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

            this.dgvListadoABM.Columns[CAMPO_TIMBRADOID].HeaderText = "ID";
            this.dgvListadoABM.Columns[CAMPO_TIMBRADOID].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvListadoABM.Columns[CAMPO_TIMBRADOID].Width = 70;
            this.dgvListadoABM.Columns[CAMPO_TIMBRADOID].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_TIMBRADOID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_TIMBRADOID].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_TIMBRADODESCRIPCION].HeaderText = "Descripción";
            this.dgvListadoABM.Columns[CAMPO_TIMBRADODESCRIPCION].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvListadoABM.Columns[CAMPO_TIMBRADODESCRIPCION].Width = 150;
            this.dgvListadoABM.Columns[CAMPO_TIMBRADODESCRIPCION].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_TIMBRADODESCRIPCION].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_TIMBRADONRO].HeaderText = "N° Timbrado";
            this.dgvListadoABM.Columns[CAMPO_TIMBRADONRO].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvListadoABM.Columns[CAMPO_TIMBRADONRO].Width = 90;
            this.dgvListadoABM.Columns[CAMPO_TIMBRADONRO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_TIMBRADONRO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_TIMBRADONRO].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_TIMBRADOTIPODOCUMENTODESCRIPCION].HeaderText = "Tipo Documento";
            this.dgvListadoABM.Columns[CAMPO_TIMBRADOTIPODOCUMENTODESCRIPCION].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvListadoABM.Columns[CAMPO_TIMBRADOTIPODOCUMENTODESCRIPCION].Width = 150;
            this.dgvListadoABM.Columns[CAMPO_TIMBRADOTIPODOCUMENTODESCRIPCION].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_TIMBRADOTIPODOCUMENTODESCRIPCION].Visible = true;
            displayIndex++;

            DataGridViewCheckBoxColumn colVigente = new DataGridViewCheckBoxColumn();
            colVigente.DataPropertyName = CAMPO_TIMBRADOVIGENTE;
            colVigente.Name = CAMPO_TIMBRADOVIGENTE;
            colVigente.HeaderText = "Vigente";
            colVigente.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colVigente.FalseValue = false;
            colVigente.TrueValue = true;
            colVigente.ReadOnly = true;
            this.dgvListadoABM.Columns.Insert(displayIndex, colVigente);
            displayIndex++;

            //DataGridViewCheckBoxColumn colHojaSuelta = new DataGridViewCheckBoxColumn();
            //colHojaSuelta.DataPropertyName = CAMPO_TIMBRADOHOJASUELTA;
            //colHojaSuelta.Name = CAMPO_TIMBRADOHOJASUELTA;
            //colHojaSuelta.HeaderText = "Imp. Hoja Suelta";
            //colHojaSuelta.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //colHojaSuelta.FalseValue = false;
            //colHojaSuelta.TrueValue = true;
            //colHojaSuelta.ReadOnly = true;
            //this.dgvListadoABM.Columns.Insert(displayIndex, colHojaSuelta);
            //displayIndex++;
        }

        protected override void tbbNuevo_Click(object sender, EventArgs e)
        {
            base.tbbNuevo_Click(sender, e);
            this.limpiarDatos();
            this.txtFechaDesde.Text = System.DateTime.Now.ToShortDateString();
            this.dtpFechaDesde.Value = System.DateTime.Now;
            this.txtFechaHasta.Text = System.DateTime.Now.ToShortDateString();
            this.dtpFechaHasta.Value = System.DateTime.Now;
            this.chkVigente.Checked = true;
            this.tSBDocumento.SetFocus();
            this.lblUsuario.Visible = false;
            this.tSBUsuario.Visible = false;
        }

        protected override void tbbEditar_Click(object sender, EventArgs e)
        {
            //base.tbbEditar_Click(sender, e);
            this.FormEditStatus = EDIT;

            if (this.tabListaABM.SelectedIndex != 2)
            {
                this.tabListaABM.SelectedIndex = 1;
                this.tSBDocumento.SetFocus();
            }   
                
        }

        protected override void tbbCancelar_Click(object sender, EventArgs e)
        {
            base.tbbCancelar_Click(sender, e);

            if (this.LastDGVIndex > -1)
            {
                this.CargarTimbrados(this.dgvListadoABM.Rows[this.LastDGVIndex]);
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
            this.txtTimbradoID.Text = String.Empty;
            this.chkVigente.Checked = false;
            this.txtNroTimbrado.Text = String.Empty;
            this.txtDescripcion.Text = String.Empty;
            this.txtFechaDesde.Text = String.Empty;
            this.txtFechaHasta.Text = String.Empty;
            this.txtNroDesde.Text = String.Empty;
            this.txtNroHasta.Text = String.Empty;
            this.txtSerie.Text = String.Empty;
            this.txtSucursal.Text = String.Empty;
            this.chkFactHojaSuelta.Checked = false;
            this.tSBDocumento.Clear();
            this.tSBUsuario.Clear();
        }
        #endregion Limpiar Datos

        #region ReadOnly condicional
        protected override void Editable(bool editar)
        {
            this.chkVigente.Enabled = !editar;
            this.txtNroTimbrado.ReadOnly = editar;
            this.txtDescripcion.ReadOnly = editar;
            this.txtFechaDesde.ReadOnly = editar;
            this.dtpFechaDesde.Enabled = !editar;
            this.txtFechaHasta.ReadOnly = editar;
            this.dtpFechaHasta.Enabled = !editar;
            this.txtNroDesde.ReadOnly = editar;
            this.txtNroHasta.ReadOnly = editar;
            this.txtSerie.ReadOnly = editar;
            this.txtSucursal.ReadOnly = editar;
            this.btnAgregarPermiso.Enabled = !editar;
            this.btnEliminarPermiso.Enabled = !editar;
            this.chkFactHojaSuelta.Enabled = !editar;
            this.tSBDocumento.Editable = !editar;
            this.tSBUsuario.Editable = !editar;
        }
        #endregion ReadOnly condicional

        #region Métodos de Apoyo
        private void CargarTimbrados(DataGridViewRow row)
        {
            this.limpiarDatos();

            this.txtTimbradoID.Text = row.Cells[CAMPO_TIMBRADOID].Value.ToString();
            this.chkVigente.Checked = (bool)row.Cells[CAMPO_TIMBRADOVIGENTE].Value;
            this.txtNroTimbrado.Text = row.Cells[CAMPO_TIMBRADONRO].Value.ToString();
            this.txtDescripcion.Text = row.Cells[CAMPO_TIMBRADODESCRIPCION].Value.ToString();
            this.txtFechaDesde.Text = Convert.ToDateTime(row.Cells[CAMPO_TIMBRADOFECVIGDESDE].Value.ToString()).ToShortDateString();
            this.txtFechaHasta.Text = Convert.ToDateTime(row.Cells[CAMPO_TIMBRADOFECVIGHASTA].Value.ToString()).ToShortDateString();
            this.txtNroDesde.Text = row.Cells[CAMPO_TIMBRADONRODESDE].Value.ToString();
            this.txtNroHasta.Text = row.Cells[CAMPO_TIMBRADONROHASTA].Value.ToString();
            this.txtSerie.Text = row.Cells[CAMPO_TIMBRADOSERIE].Value.ToString();
            this.txtSucursal.Text = row.Cells[CAMPO_TIMBRADOSUCURSAL].Value.ToString();
            this.chkFactHojaSuelta.Checked = (bool)row.Cells[CAMPO_TIMBRADOHOJASUELTA].Value;
            this.tSBDocumento.KeyMember = row.Cells[CAMPO_TIMBRADOTIPODOCUMENTOID].Value.ToString();
            this.tSBDocumento.DisplayMember = row.Cells[CAMPO_TIMBRADOTIPODOCUMENTODESCRIPCION].Value.ToString();
            this.tSBUsuario.KeyMember = row.Cells[CAMPO_TIMBRADOUSUARIOEXCLUSIVOID].Value != null
                                        ? row.Cells[CAMPO_TIMBRADOUSUARIOEXCLUSIVOID].Value.ToString()
                                        : string.Empty;
            this.tSBUsuario.DisplayMember = row.Cells[CAMPO_TIMBRADOUSUARIOEXCLUSIVONOMBRE].Value != null
                                            ? row.Cells[CAMPO_TIMBRADOUSUARIOEXCLUSIVONOMBRE].Value.ToString()
                                            : string.Empty;

            bool mostrarUsuExc = Convert.ToInt32(this.tSBDocumento.KeyMember) == RECIBO_ID;

            this.lblUsuario.Visible = mostrarUsuExc;
            this.tSBUsuario.Visible = mostrarUsuExc;

            //Cargar permisos
            this.CargarPermisos(Convert.ToInt32(this.txtTimbradoID.Text));
        }

        private void CargarPermisos(int TimbradoID)
        {
            var query = (from su in this.DBContext.su_serieusuario
                         join usu in this.DBContext.Usuario
                            on su.su_usuarioid equals usu.ID
                         select new PermisoTimbrado
                         {
                             PermisoTimbradoID = su.su_serieusuarioid,
                             TimbradoID = su.su_timbradoid,
                             UsuarioID = su.su_usuarioid,
                             UsuarioNombre = usu.NombrePila
                         })
                        .Where(a => a.TimbradoID == TimbradoID).ToList();

            if (query.Count > 0)
            {
                this.bS.DataSource = query;
                this.dgvDetPermisos.DataSource = this.bS;
                this.FormatearGrillaPermisos();
            }
            else
                this.dgvDetPermisos.DataSource = null;
        }
        #endregion Métodos de Apoyo

        #region Métodos locales sobre controles
        
        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaDesde.Text = this.dtpFechaDesde.Value.ToShortDateString();
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaHasta.Text = this.dtpFechaHasta.Value.ToShortDateString();
        }

        private void ucCRUDMovimientoCuenta_VisibleChanged(object sender, EventArgs e)
        {
            if (this.tabListaABM.SelectedIndex == 0)
                this.FormatearGrilla();
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

        protected override void dgvListadoABM_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            base.dgvListadoABM_RowEnter(sender, e);

            if ((this.LastDGVIndex > -1) && (!this.IsClosing))
                this.CargarTimbrados(this.dgvListadoABM.Rows[this.LastDGVIndex]);
        }

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
                            new EventHandler(DialogHandler));

            //if (this.dgvDetCobranzas.RowCount > 0)
            //{
            //    this.dgvDetCobranzas.CurrentCell = this.dgvDetCobranzas.Rows[0].Cells[0];
            //    this.dgvDetCobranzas.CurrentCell.Selected = true;
            //    this.dgvDetCobranzas.Focus();
            //}
            //else
            //{
            //    this.btnEliminarCobro.Enabled = false;
            //    this.btnAgregarCobro.Focus();
            //}
        }

        private void DialogHandler(object sender, EventArgs e)
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

            su_serieusuario su = this.DBContext.su_serieusuario.First(a => a.su_serieusuarioid == permisoID);
            this.DBContext.su_serieusuario.Remove(su);
            this.DBContext.SaveChanges();
            this.CargarPermisos(Convert.ToInt32(this.txtTimbradoID.Text));

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

        }

        private void dgvDetPermisos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.btnEliminarPermiso.Enabled = this.dgvDetPermisos.CurrentRow != null && this.FormEditStatus != BROWSE;
        }

        private void tabListaABM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabListaABM.SelectedIndex == 2)
            {
                this.ManejarBotones();
            }
        }

        private void ManejarBotones()
        {
            if (this.dgvDetPermisos.RowCount > 0)
            {
                this.dgvDetPermisos.CurrentCell = this.dgvDetPermisos.Rows[0].Cells[2];
                this.dgvDetPermisos.CurrentCell.Selected = true;
                this.dgvDetPermisos.Focus();

                if (this.FormEditStatus != BROWSE)
                {
                    this.btnEliminarPermiso.Enabled = true;
                    this.btnAgregarPermiso.Enabled = true;
                }
                else
                {
                    this.btnEliminarPermiso.Enabled = false;
                    this.btnAgregarPermiso.Enabled = false;
                }
            }
            else
            {
                if (this.FormEditStatus != BROWSE)
                {
                    this.btnEliminarPermiso.Enabled = false;
                    this.btnAgregarPermiso.Enabled = true;
                    this.btnAgregarPermiso.Focus();
                }
                else
                {
                    this.btnAgregarPermiso.Enabled = false;
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
        private void ucCRUDTimbrados_CRUDEvent(object sender, EventArgs e)
        {
            ti_timbrado ti = new ti_timbrado();

            ti.ti_timbradoid = this.FormEditStatus != INSERT ? Convert.ToInt32(this.txtTimbradoID.Text) : 0;
            ti.ti_vigente = this.chkVigente.Checked;
            ti.ti_nrotimbrado = Convert.ToInt32(this.txtNroTimbrado.Text);
            ti.ti_descripcion = this.txtDescripcion.Text != String.Empty ? this.txtDescripcion.Text : null;
            ti.ti_vigenciadesde = Convert.ToDateTime(this.txtFechaDesde.Text);
            ti.ti_vigenciahasta = Convert.ToDateTime(this.txtFechaHasta.Text);
            ti.ti_numerodesde = Convert.ToInt32(this.txtNroDesde.Text);
            ti.ti_numerohasta = Convert.ToInt32(this.txtNroHasta.Text);
            ti.ti_serie = this.txtSerie.Text;
            ti.ti_sucursal = this.txtSucursal.Text;
            ti.ti_facthojasuelta = this.chkFactHojaSuelta.Checked;
            ti.ti_tipodocumentoid = Convert.ToInt32(this.tSBDocumento.KeyMember);
            ti.ti_usuarioid = Convert.ToInt32(this.tSBUsuario.KeyMember);

            bool exito = false;

            if (this.FormEditStatus != BROWSE)
            {
                ti = this.GuardarRegistro<ti_timbrado>(ti);
            }
            else
            {
                exito = this.EliminarRegistro<ti_timbrado>(ti);
                ti = exito ? ti : null;
            }

            if ((ti != null) || (exito))
            {
                int index = 0;
                if (this.FormEditStatus == INSERT)
                {
                    this.FilterEntity("", null);
                    this.CargarTimbrados(this.dgvListadoABM.Rows[0]);
                }
                else if ((this.FormEditStatus == EDIT) || (this.FormEditStatus == BROWSE))
                {
                    this.FilterEntity(this.WhereString, this.FilterParam);
                    this.CargarTimbrados(this.dgvListadoABM.Rows[this.LastDGVIndex]);
                    index = this.LastDGVIndex;
                }

                this.FormEditStatus = BROWSE;
                this.dgvListadoABM.CurrentCell = this.dgvListadoABM.Rows[index].Cells[0];
                this.dgvListadoABM.CurrentCell.Selected = true;


                MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void ucCRUDTimbrados_ValidarCamposEvent(object sender, EventArgs e)
        {
            if (this.tSBDocumento.KeyMember == "")
            {
                MessageBox.Show("Debe ingresar el tipo de documento.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (Convert.ToInt32(this.tSBDocumento.KeyMember) == RECIBO_ID)
            {
                if (this.tSBUsuario.KeyMember.Trim() == string.Empty)
                {
                    MessageBox.Show("Para el tipo de documento Recibo es obligatorio ingresar el usuario exclusivo del timbrado.",
                                    "Información",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    return;
                }
            }

            if (this.txtFechaDesde.Text == "")
            {
                MessageBox.Show("Debe ingresar la fecha del límite inferior del rango de vigencia.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (this.txtFechaHasta.Text == "")
            {
                MessageBox.Show("Debe ingresar la fecha del límite superior del rango de vigencia.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            DateTime FechaDesde, FechaHasta;
            if (DateTime.TryParse(this.txtFechaDesde.Text, out FechaDesde) && DateTime.TryParse(this.txtFechaHasta.Text, out FechaHasta))
            {
                if (FechaDesde >= FechaHasta)
                {
                    MessageBox.Show("La Fecha Desde no puede ser igual o superior a la Fecha Hasta.",
                                "Atención Requerida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if (this.txtNroDesde.Text == "")
            {
                MessageBox.Show("Debe ingresar el número del límite inferior del rango de facturas en vigencia.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (this.txtNroHasta.Text == "")
            {
                MessageBox.Show("Debe ingresar el número del límite superior del rango de facturas en vigencia.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }
            
            Int32 NroDesde, NroHasta;
            if (Int32.TryParse(this.txtNroDesde.Text, out NroDesde) && Int32.TryParse(this.txtNroHasta.Text, out NroHasta))
            {
                if (NroDesde >= NroHasta)
                {
                    MessageBox.Show("El Número Desde no puede ser igual superior al Número Hasta.",
                                "Atención Requerida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if (this.txtNroTimbrado.Text == "")
            {
                MessageBox.Show("Debe ingresar el número de timbrado.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (this.txtDescripcion.Text == "")
            {
                MessageBox.Show("Debe ingresar la descripción del timbrado.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (this.txtSerie.Text == "")
            {
                MessageBox.Show("Debe ingresar la serie del timbrado.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (this.txtSucursal.Text == "")
            {
                MessageBox.Show("Debe ingresar la sucursal de timbrado.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            this.ValidOK = true;
        }

        #region Métodos de Edición de Datos
        #endregion Métodos de Edición de Datos

        private void cbAsociarCobranzas_CheckedChanged(object sender, EventArgs e)
        {
            //if (!this.cbAsociarCobranzas.Checked)
            //{
            //    this.tpCobAsoc.Hide();

            //    if ((this.FormEditStatus != BROWSE) 
            //        && (this.dgvListadoABM.CurrentRow != null) 
            //        && (this.dgvListadoABM.CurrentRow.Cells[CAMPO_ASOCIADOACOBRANZA].Value != null)
            //        && ((bool)this.dgvListadoABM.CurrentRow.Cells[CAMPO_ASOCIADOACOBRANZA].Value))
            //    {
            //        foreach (DataGridViewRow row in this.dgvDetCobranzas.Rows)
            //        {
            //            if (row.Cells[CAMPO_COBROXMOVID].Value != null)
            //                this.cobrosElim.Add((SeleccionarCobrosType)row.DataBoundItem);
            //        }
            //        this.dgvDetCobranzas.DataSource = null;
            //    }
            //}
            //else
            //    this.tpCobAsoc.Show();
        }
        #endregion CRUD

        

    }
}