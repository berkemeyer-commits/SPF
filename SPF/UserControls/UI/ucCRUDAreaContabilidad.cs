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
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.ObjectModel;

#endregion

namespace SPF.UserControls.UI
{
    public partial class ucCRUDAreaContabilidad : ucBaseForm
    {
        #region Variables
        frmPickBase fPickCArea;
        frmPickBase fPickUnidadNegocio;
        #endregion Variables

        #region Constantes
        private const string CAMPO_AREACONTABILIDADID = "AreaContabilidadID";
        private const string CAMPO_DESCRIPCIONAREA    = "DescripcionArea";
        private const string CAMPO_AREAMARCASID       = "AreaMarcasID";
        private const string CAMPO_AREAMARCASDESCRIP  = "AreaMarcasDescrip";
        private const string CAMPO_UNIDADNEGOCIOID    = "UnidadNegocioID";
        private const string CAMPO_UNIDADNEGOCIODESCRIP = "UnidadNegocioDescrip";
        #endregion Constantes

        #region Métodos de Inicio
        public ucCRUDAreaContabilidad()
        {
            InitializeComponent();
        }

        public ucCRUDAreaContabilidad(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();
            this.DBContext = dbContext;
            this.Titulo = Titulo;

            var areas = (from areaContab in this.DBContext.ac_areacontabilidad
                         join carea in this.DBContext.CArea
                            on areaContab.ac_areamarcasid equals carea.idarea into ac_ca
                         from carea in ac_ca.DefaultIfEmpty()
                         join uNeg in this.DBContext.un_unidadnegocio
                            on areaContab.ac_unidadnegocioid equals uNeg.un_unidadnegocioid into ac_un
                         from uNeg in ac_un.DefaultIfEmpty()
                         select new
                         {
                             AreaContabilidadID = areaContab.ac_areacontabilidadid,
                             DescripcionArea = areaContab.ac_descripcionarea,
                             AreaMarcasID = areaContab.ac_areamarcasid,
                             AreaMarcasDescrip = carea.descrip,
                             UnidadNegocioID = areaContab.ac_unidadnegocioid,
                             UnidadNegocioDescrip = uNeg.un_descripcion
                         })
                         .OrderBy(a => a.AreaContabilidadID)
                         .Take(50);

            this.BindingSourceBase = areas.ToList();

            #region Especificar campos para filtro
            this.SetFilter("AreaContabilidadID", "ID Area Contabilidad", false);
            this.SetFilter("DescripcionArea", "Descripción Area");
            this.SetFilter("AreaMarcasID", "ID Area Marcas", false);
            this.SetFilter("AreaMarcasDescrip", "Descrip. Area Marcas");
            this.SetFilter(CAMPO_UNIDADNEGOCIOID, "ID Unid. Negocio", false);
            this.SetFilter(CAMPO_UNIDADNEGOCIODESCRIP, "Descrip. Unid. Negocio");
            this.TituloBuscador = "Buscar Areas de Contabilidad";
            #endregion Especificar campos para filtro

            #region Inicializar TextSearchBoxes
            this.tSBCArea.KeyMemberWidth = 70;
            this.tSBCArea.ToolTip = "Elegir Trámite";
            this.tSBCArea.AceptarClick += tSBCArea_AceptarClick;

            this.tSBUnidadNegocio.KeyMemberWidth = 70;
            this.tSBUnidadNegocio.ToolTip = "Elegir Trámite";
            this.tSBUnidadNegocio.AceptarClick += tSBUnidadNegocio_AceptarClick;
            #endregion Inicializar TextSearchBoxes
        }
        #endregion Métodos de Inicio

        #region Picks
        private void tSBCArea_AceptarClick(object sender, EventArgs e)
        {
            if (fPickCArea == null)
            {
                fPickCArea = new frmPickBase();
                fPickCArea.AceptarFiltrarClick += fPickCArea_AceptarFiltrarClick;
                fPickCArea.FiltrarClick += fPickCArea_FiltrarClick;
                fPickCArea.Titulo = "Elegir Area de Marcas";
                fPickCArea.CampoIDNombre = "idarea";
                fPickCArea.CampoDescripNombre = "descrip";
                fPickCArea.LabelCampoID = "ID";
                fPickCArea.LabelCampoDescrip = "Descripción";
                fPickCArea.NombreCampo = "Area";
                fPickCArea.PermitirFiltroNulo = true;
            }
            fPickCArea.MostrarFiltro();
            fPickCArea_FiltrarClick(sender, e);
        }

        private void fPickCArea_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickCArea != null)
            {
                fPickCArea.LoadData<CArea>(this.DBContext.CArea, fPickCArea.GetWhereString());
            }
        }

        private void fPickCArea_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBCArea.DisplayMember = fPickCArea.ValorDescrip;
            this.tSBCArea.KeyMember = fPickCArea.ValorID;

            fPickCArea.Close();
            fPickCArea.Dispose();
        }

        private void tSBUnidadNegocio_AceptarClick(object sender, EventArgs e)
        {
            if (fPickUnidadNegocio == null)
            {
                fPickUnidadNegocio = new frmPickBase();
                fPickUnidadNegocio.AceptarFiltrarClick += fPickUnidadNegocio_AceptarFiltrarClick;
                fPickUnidadNegocio.FiltrarClick += fPickUnidadNegocio_FiltrarClick;
                fPickUnidadNegocio.Titulo = "Elegir Unidad de Negocio";
                fPickUnidadNegocio.CampoIDNombre = "un_unidadnegocioid";
                fPickUnidadNegocio.CampoDescripNombre = "un_descripcion";
                fPickUnidadNegocio.LabelCampoID = "ID";
                fPickUnidadNegocio.LabelCampoDescrip = "Descripción";
                fPickUnidadNegocio.NombreCampo = "Unid. Negocio";
                fPickUnidadNegocio.PermitirFiltroNulo = true;
            }
            fPickUnidadNegocio.MostrarFiltro();
            fPickUnidadNegocio_FiltrarClick(sender, e);
        }

        private void fPickUnidadNegocio_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickUnidadNegocio != null)
            {
                fPickUnidadNegocio.LoadData<un_unidadnegocio>(this.DBContext.un_unidadnegocio, fPickUnidadNegocio.GetWhereString());
            }
        }

        private void fPickUnidadNegocio_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBUnidadNegocio.DisplayMember = fPickUnidadNegocio.ValorDescrip;
            this.tSBUnidadNegocio.KeyMember = fPickUnidadNegocio.ValorID;

            fPickUnidadNegocio.Close();
            fPickUnidadNegocio.Dispose();
        }
        #endregion Picks

        #region Método Extendidos del ParentControl
        protected override void FilterEntity(string where = "", object[] filterParams = null)
        {
            try
            {
                this.limpiarDatos();

                var query = (from areaContab in this.DBContext.ac_areacontabilidad
                             join carea in this.DBContext.CArea
                                on areaContab.ac_areamarcasid equals carea.idarea into ac_ca
                                from carea in ac_ca.DefaultIfEmpty()
                             join uNeg in this.DBContext.un_unidadnegocio
                                on areaContab.ac_unidadnegocioid equals uNeg.un_unidadnegocioid into ac_un
                                from uNeg in ac_un.DefaultIfEmpty()
                             select new
                             {
                                 AreaContabilidadID = areaContab.ac_areacontabilidadid,
                                 DescripcionArea = areaContab.ac_descripcionarea,
                                 AreaMarcasID = areaContab.ac_areamarcasid,
                                 AreaMarcasDescrip = carea.descrip,
                                 UnidadNegocioID = areaContab.ac_unidadnegocioid,
                                 UnidadNegocioDescrip = uNeg.un_descripcion
                             });

                if (where != "")
                {
                    this.BindingSourceBase = query.Where(where, filterParams).OrderBy(a => a.AreaContabilidadID).ToList();
                }
                else
                {
                    this.BindingSourceBase = query.OrderBy(a => a.AreaContabilidadID).Take(50).ToList();
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
            this.dgvListadoABM.Columns[CAMPO_AREACONTABILIDADID].HeaderText = "Area ID";
            this.dgvListadoABM.Columns[CAMPO_AREACONTABILIDADID].Width = 60;
            this.dgvListadoABM.Columns[CAMPO_AREACONTABILIDADID].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_AREACONTABILIDADID].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_DESCRIPCIONAREA].HeaderText = "Descripción Area";
            this.dgvListadoABM.Columns[CAMPO_DESCRIPCIONAREA].Width = 150;
            this.dgvListadoABM.Columns[CAMPO_DESCRIPCIONAREA].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_DESCRIPCIONAREA].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_AREAMARCASDESCRIP].HeaderText = "Area Equivalente";
            this.dgvListadoABM.Columns[CAMPO_AREAMARCASDESCRIP].Width = 150;
            this.dgvListadoABM.Columns[CAMPO_AREAMARCASDESCRIP].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_AREAMARCASDESCRIP].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_UNIDADNEGOCIODESCRIP].HeaderText = "Unidad de Negocio";
            this.dgvListadoABM.Columns[CAMPO_UNIDADNEGOCIODESCRIP].Width = 150;
            this.dgvListadoABM.Columns[CAMPO_UNIDADNEGOCIODESCRIP].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_UNIDADNEGOCIODESCRIP].Visible = true;
            displayIndex++;
        }

        protected override void tbbNuevo_Click(object sender, EventArgs e)
        {
            base.tbbNuevo_Click(sender, e);
            this.limpiarDatos();
            this.txtDescripcionArea.Focus();
        }

        protected override void tbbEditar_Click(object sender, EventArgs e)
        {
            base.tbbEditar_Click(sender, e);
            this.txtDescripcionArea.Focus();
        }
        #endregion Método Extendidos del ParentControl

        #region Controles Locales
        private void dgvListadoABM_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.limpiarDatos();
            this.txtAreaID.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_AREACONTABILIDADID].Value.ToString();

            if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_DESCRIPCIONAREA].Value != null)
            {
                this.txtDescripcionArea.Text = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_DESCRIPCIONAREA].Value.ToString();
            }

            if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_AREAMARCASID].Value != null)
            {
                this.tSBCArea.KeyMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_AREAMARCASID].Value.ToString();
                this.tSBCArea.DisplayMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_AREAMARCASDESCRIP].Value.ToString();
            }

            if (((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_UNIDADNEGOCIOID].Value != null)
            {
                this.tSBUnidadNegocio.KeyMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_UNIDADNEGOCIOID].Value.ToString();
                this.tSBUnidadNegocio.DisplayMember = ((DataGridView)sender).Rows[e.RowIndex].Cells[CAMPO_UNIDADNEGOCIODESCRIP].Value.ToString();
            }
        }

        private void tbbGuardar_Click(object sender, EventArgs e)
        {
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
        #endregion Controles Locales

        #region ReadOnly condicional
        protected override void Editable(bool editar)
        {
            this.txtDescripcionArea.ReadOnly = editar;
            this.tSBCArea.Editable = !editar;
            this.tSBUnidadNegocio.Editable = !editar;
        }
        #endregion ReadOnly condicional

        #region Limpiar Datos
        private void limpiarDatos()
        {
            this.txtAreaID.Text = "";
            this.txtDescripcionArea.Text = "";
            this.tSBCArea.Clear();
            this.tSBUnidadNegocio.Clear();
        }
        #endregion Limpiar Datos

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
                        this.eliminaArea(context);
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

            ac_areacontabilidad ac = null;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        ac = this.guardarArea(context);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
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
                if (this.FormEditStatus != BROWSE)
                    this.FilterEntity(this.WhereString, this.FilterParam);

                this.FormEditStatus = BROWSE;
                MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region Métodos de Edición de Datos
        private ac_areacontabilidad guardarArea(BerkeDBEntities context = null)
        {
            ac_areacontabilidad ac = new ac_areacontabilidad();
            if (this.FormEditStatus == EDIT)
            {
                int areaID = Convert.ToInt32(this.txtAreaID.Text);

                ac = context.ac_areacontabilidad.First(a => a.ac_areacontabilidadid == areaID);

                ac.ac_descripcionarea = this.txtDescripcionArea.Text;

                if (this.tSBCArea.KeyMember != "")
                {
                    ac.ac_areamarcasid = Convert.ToInt32(this.tSBCArea.KeyMember);
                }
                else
                {
                    ac.ac_areamarcasid = null;
                }

                if (this.tSBUnidadNegocio.KeyMember != "")
                {
                    ac.ac_unidadnegocioid = Convert.ToInt32(this.tSBUnidadNegocio.KeyMember);
                }
                else
                {
                    ac.ac_unidadnegocioid = null;
                }
                
            }
            else if (this.FormEditStatus == INSERT)
            {
                ac.ac_descripcionarea = this.txtDescripcionArea.Text;

                if (this.tSBCArea.KeyMember != "")
                {
                    ac.ac_areamarcasid = Convert.ToInt32(this.tSBCArea.KeyMember);
                }
                else
                {
                    ac.ac_areamarcasid = null;
                }

                if (this.tSBUnidadNegocio.KeyMember != "")
                {
                    ac.ac_unidadnegocioid = Convert.ToInt32(this.tSBUnidadNegocio.KeyMember);
                }
                else
                {
                    ac.ac_unidadnegocioid = null;
                }

                context.ac_areacontabilidad.Add(ac);
            }

            return ac;
        }

        private void eliminaArea(BerkeDBEntities context = null)
        {
            int areaID = Convert.ToInt32(this.txtAreaID.Text);
            ac_areacontabilidad ac = context.ac_areacontabilidad.First(a => a.ac_areacontabilidadid == areaID);

            context.ac_areacontabilidad.Remove(ac);
        }
        #endregion Métodos de Edición de Datos

       
        #endregion CRUD
    }
}