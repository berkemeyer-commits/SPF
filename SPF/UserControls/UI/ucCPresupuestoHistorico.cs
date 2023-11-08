#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Gateways;

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
using System.Data.Objects.SqlClient;

#endregion

namespace SPF.UserControls.UI
{
    public partial class ucCPresupuestoHistorico : ucBaseForm
    {
        #region Constantes
        private const string CAMPO_PRESUPUESTOHISTID = "PresupuestoHistID";
        private const string CAMPO_FECHADOCUMENTO = "FechaDocumento";
        private const string CAMPO_NROAGENTE = "NroAgente";
        private const string CAMPO_CLIENTEID = "ClienteID";
        private const string CAMPO_ANOMBREDE = "ANombreDe";
        private const string CAMPO_NOMBREAGENTE = "NombreAgente";
        private const string CAMPO_OBJETO = "Objeto";
        private const string CAMPO_MONEDA = "Moneda";
        private const string CAMPO_MONTO = "Monto";
        private const string CAMPO_NRODOCUMENTO = "NroDocumento";
        private const string CAMPO_TRAMITE = "Tramite";
        private const string CAMPO_RESPONSABLE = "Responsable";
        private const string CAMPO_FECHAPAGO = "FechaPago";
        private const string CAMPO_DIFBANCARIA = "DifBancaria";
        private const string CAMPO_RUC = "RUC";
        private const string CAMPO_FORMAPAGO = "FormaPago";
        private const string CAMPO_MONTOPAGO = "MontoPago";
        private const string CAMPO_BANCOABREV = "BancoAbrev";
        private const string CAMPO_NOMBREBANCO= "NombreBanco";
        private const string CAMPO_FECHABOLETA = "FechaBoleta";
        #endregion Constantes

        #region Variables
        #endregion Variables

        #region Métodos de Inicio
        public ucCPresupuestoHistorico()
        {
            InitializeComponent();
        }

        public ucCPresupuestoHistorico(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();
            this.DBContext = dbContext;
            this.Titulo = Titulo;
            //this.TituloDetalle = "Presupuesto";
            //this.UsuarioID = Convert.ToInt32(VWGContext.Current.Session["UsuarioID"].ToString());

            #region Ocultar botones que no se usan
            this.tbbNuevo.Visible = false;
            this.tbbEditar.Visible = false;
            this.tbbGuardar.Visible = false;
            this.tbbImprimir.Visible = false;
            this.tbbCancelar.Visible = false;
            this.tbbBorrar.Visible = false;
            //this.tbbUpdDocs.Visible = false;
            #endregion Ocultar botones que no se usan

            var presup =  (from ph in this.DBContext.ph_presupuestohistorico
                          select new
                          {
                            PresupuestoHistID = ph.ph_presupuestohistoricoid,
                            FechaDocumento = ph.ph_fechadocumento,
                            NroAgente = ph.ph_nroagente,
                            ClienteID = ph.ph_clienteid,
                            ANombreDe = ph.ph_anombrede,
                            NombreAgente = ph.ph_agente,
                            Objeto = ph.ph_objeto,
                            Moneda = ph.ph_moneda,
                            Monto = ph.ph_monto,
                            NroDocumento = ph.ph_nrodocumento,
                            Tramite = ph.ph_tramite,
                            Responsable = ph.ph_responsable,
                            FechaPago = ph.ph_fechapago,
                            DifBancaria = ph.ph_difbancaria,
                            RUC = ph.ph_ruc,
                            FormaPago = ph.ph_formapago,
                            MontoPago = ph.ph_montopago,
                            BancoAbrev = ph.ph_bancoabrev,
                            NombreBanco = ph.ph_nombrebanco,
                            FechaBoleta = ph.ph_fechaboleta
                          })
                          .OrderByDescending(a => a.FechaDocumento)
                          .Take(50);

            this.BindingSourceBase = presup.ToList();

            #region Especificar campos para filtro
            this.SetFilter(CAMPO_PRESUPUESTOHISTID, "ID Presupuesto Hist.", false);
            this.SetFilter(CAMPO_FECHADOCUMENTO, "Fec. Documento");
            this.SetFilter(CAMPO_NROAGENTE, "N° Agente (DF)", false);
            this.SetFilter(CAMPO_CLIENTEID, "ID Cliente", false);
            this.SetFilter(CAMPO_ANOMBREDE, "A Nombre De");
            this.SetFilter(CAMPO_NOMBREAGENTE, "Nomb. Agente");
            this.SetFilter(CAMPO_OBJETO, "Objeto");
            this.SetFilter(CAMPO_MONEDA, "Moneda");
            this.SetFilter(CAMPO_MONTO, "Cliente Nombre");
            this.SetFilter(CAMPO_NRODOCUMENTO, "N° Documento");
            this.SetFilter(CAMPO_TRAMITE, "Trámite");
            this.SetFilter(CAMPO_RESPONSABLE, "Responsable");
            this.SetFilter(CAMPO_FECHAPAGO, "Fec. Pago");
            this.SetFilter(CAMPO_DIFBANCARIA, "Dif. Bancaria", false);
            this.SetFilter(CAMPO_RUC, "RUC");
            this.SetFilter(CAMPO_FORMAPAGO, "Forma Pago");
            this.SetFilter(CAMPO_MONTOPAGO, "Monto Pago");
            this.SetFilter(CAMPO_BANCOABREV, "Banco Abrev.");
            this.SetFilter(CAMPO_NOMBREBANCO, "Nombre Banco");
            this.SetFilter(CAMPO_FECHABOLETA, "Fec. Boleta");
            this.TituloBuscador = "Buscar Prespuestos Históricos";
            #endregion Especificar campos para filtro

        }

        #endregion Métodos de Inicio

        #region Método Extendidos del ParentControl
        protected override void FilterEntity(string where = "", object[] filterParams = null)
        {
            try
            {
                this.limpiarDatos();

                var query = (from ph in this.DBContext.ph_presupuestohistorico
                             select new
                             {
                                 PresupuestoHistID = ph.ph_presupuestohistoricoid,
                                 FechaDocumento = ph.ph_fechadocumento,
                                 NroAgente = ph.ph_nroagente,
                                 ClienteID = ph.ph_clienteid,
                                 ANombreDe = ph.ph_anombrede,
                                 NombreAgente = ph.ph_agente,
                                 Objeto = ph.ph_objeto,
                                 Moneda = ph.ph_moneda,
                                 Monto = ph.ph_monto,
                                 NroDocumento = ph.ph_nrodocumento,
                                 Tramite = ph.ph_tramite,
                                 Responsable = ph.ph_responsable,
                                 FechaPago = ph.ph_fechapago,
                                 DifBancaria = ph.ph_difbancaria,
                                 RUC = ph.ph_ruc,
                                 FormaPago = ph.ph_formapago,
                                 MontoPago = ph.ph_montopago,
                                 BancoAbrev = ph.ph_bancoabrev,
                                 NombreBanco = ph.ph_nombrebanco,
                                 FechaBoleta = ph.ph_fechaboleta
                             });


                if (where != "")
                {
                    this.BindingSourceBase = query.Where(where, filterParams).OrderByDescending(a => a.FechaDocumento).ToList();
                }
                else
                {
                    this.BindingSourceBase = query.OrderByDescending(a => a.FechaDocumento).Take(50).ToList();
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

            this.dgvListadoABM.Columns[CAMPO_PRESUPUESTOHISTID].HeaderText = "Presup. Hist. ID";
            this.dgvListadoABM.Columns[CAMPO_PRESUPUESTOHISTID].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_PRESUPUESTOHISTID].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_PRESUPUESTOHISTID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_PRESUPUESTOHISTID].Visible = true;
            displayIndex++;
            
            this.dgvListadoABM.Columns[CAMPO_FECHADOCUMENTO].HeaderText = "Fec. Documento";
            this.dgvListadoABM.Columns[CAMPO_FECHADOCUMENTO].Width = 120;
            this.dgvListadoABM.Columns[CAMPO_FECHADOCUMENTO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_FECHADOCUMENTO].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_NROAGENTE].HeaderText = "N° Agente";
            this.dgvListadoABM.Columns[CAMPO_NROAGENTE].Width = 120;
            this.dgvListadoABM.Columns[CAMPO_NROAGENTE].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_NROAGENTE].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_NROAGENTE].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_CLIENTEID].HeaderText = "ID Cliente";
            this.dgvListadoABM.Columns[CAMPO_CLIENTEID].Width = 120;
            this.dgvListadoABM.Columns[CAMPO_CLIENTEID].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_CLIENTEID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_CLIENTEID].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_ANOMBREDE].HeaderText = "A Nombre De";
            this.dgvListadoABM.Columns[CAMPO_ANOMBREDE].Width = 250;
            this.dgvListadoABM.Columns[CAMPO_ANOMBREDE].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_ANOMBREDE].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_NOMBREAGENTE].HeaderText = "Nombre Agente";
            this.dgvListadoABM.Columns[CAMPO_NOMBREAGENTE].Width = 250;
            this.dgvListadoABM.Columns[CAMPO_NOMBREAGENTE].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_NOMBREAGENTE].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_OBJETO].HeaderText = "Objeto";
            this.dgvListadoABM.Columns[CAMPO_OBJETO].Width = 250;
            this.dgvListadoABM.Columns[CAMPO_OBJETO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_OBJETO].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_MONEDA].HeaderText = "Moneda";
            this.dgvListadoABM.Columns[CAMPO_MONEDA].Width = 60;
            this.dgvListadoABM.Columns[CAMPO_MONEDA].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_MONEDA].Visible = true;
            displayIndex++;
            
            this.dgvListadoABM.Columns[CAMPO_MONTO].HeaderText = "Monto";
            this.dgvListadoABM.Columns[CAMPO_MONTO].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_MONTO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_MONTO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_MONTO].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_NRODOCUMENTO].HeaderText = "N° Documento";
            this.dgvListadoABM.Columns[CAMPO_NRODOCUMENTO].Width = 120;
            this.dgvListadoABM.Columns[CAMPO_NRODOCUMENTO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_NRODOCUMENTO].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_TRAMITE].HeaderText = "Trámite";
            this.dgvListadoABM.Columns[CAMPO_TRAMITE].Width = 250;
            this.dgvListadoABM.Columns[CAMPO_TRAMITE].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_TRAMITE].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_RESPONSABLE].HeaderText = "Responsable";
            this.dgvListadoABM.Columns[CAMPO_RESPONSABLE].Width = 120;
            this.dgvListadoABM.Columns[CAMPO_RESPONSABLE].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_RESPONSABLE].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_FECHAPAGO].HeaderText = "Fecha Pago";
            this.dgvListadoABM.Columns[CAMPO_FECHAPAGO].Width = 120;
            this.dgvListadoABM.Columns[CAMPO_FECHAPAGO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_FECHAPAGO].Visible = true;
            displayIndex++;


            this.dgvListadoABM.Columns[CAMPO_DIFBANCARIA].HeaderText = "Dif. Bancaria";
            this.dgvListadoABM.Columns[CAMPO_DIFBANCARIA].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_DIFBANCARIA].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_DIFBANCARIA].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_DIFBANCARIA].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_RUC].HeaderText = "RUC";
            this.dgvListadoABM.Columns[CAMPO_RUC].Width = 100;
            this.dgvListadoABM.Columns[CAMPO_RUC].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_RUC].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_FORMAPAGO].HeaderText = "Forma Pago";
            this.dgvListadoABM.Columns[CAMPO_FORMAPAGO].Width = 120;
            this.dgvListadoABM.Columns[CAMPO_FORMAPAGO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_FORMAPAGO].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_MONTOPAGO].HeaderText = "Monto Pago";
            this.dgvListadoABM.Columns[CAMPO_MONTOPAGO].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_MONTOPAGO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_MONTOPAGO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_MONTOPAGO].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_BANCOABREV].HeaderText = "Banco Abrev.";
            this.dgvListadoABM.Columns[CAMPO_BANCOABREV].Width = 120;
            this.dgvListadoABM.Columns[CAMPO_BANCOABREV].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_BANCOABREV].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_NOMBREBANCO].HeaderText = "Nombre Banco";
            this.dgvListadoABM.Columns[CAMPO_NOMBREBANCO].Width = 250;
            this.dgvListadoABM.Columns[CAMPO_NOMBREBANCO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_NOMBREBANCO].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_FECHABOLETA].HeaderText = "Fecha Boleta";
            this.dgvListadoABM.Columns[CAMPO_FECHABOLETA].Width = 120;
            this.dgvListadoABM.Columns[CAMPO_FECHABOLETA].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_FECHABOLETA].Visible = true;
            displayIndex++;
        }
        #endregion Método Extendidos del ParentControl

        #region Limpiar Datos
        private void limpiarDatos()
        {
            this.txtPresupHistID.Text = "";
            this.txtFecDoc.Text = "";
            this.txtNroDocumento.Text = "";
            this.txtRUC.Text = "";
            this.txtNroAgente.Text = "";
            this.txtNombreAgente.Text = "";
            this.txtClienteID.Text = "";
            this.txtANombreDe.Text = "";
            this.txtObjeto.Text = "";
            this.txtMonto.Text = "";
            this.txtMoneda.Text = "";
            this.txtTramite.Text = "";
            this.txtResponsable.Text = "";
            this.txtFechaPago.Text = "";
            this.txtMontoPago.Text = "";
            this.txtFormaPago.Text = "";
            this.txtDifBancaria.Text = "";
            this.txtBancoAbrev.Text = "";
            this.txtNombreBanco.Text = "";
            this.txtFechaBoleta.Text = "";
        }
        #endregion Limpiar Datos

        #region CargarDatos
        private void CargarDatos(DataGridViewRow row)
        {
            this.limpiarDatos();
            this.txtPresupHistID.Text = row.Cells[CAMPO_PRESUPUESTOHISTID].Value.ToString();
            this.txtFecDoc.Text = row.Cells[CAMPO_FECHADOCUMENTO].Value != null ?
                                    Convert.ToDateTime(row.Cells[CAMPO_FECHADOCUMENTO].Value.ToString()).ToShortDateString() :
                                    "";
            this.txtNroDocumento.Text = row.Cells[CAMPO_NRODOCUMENTO].Value != null ?
                                        row.Cells[CAMPO_NRODOCUMENTO].Value.ToString() :
                                        "";

            this.txtRUC.Text = row.Cells[CAMPO_RUC].Value != null ?
                                        row.Cells[CAMPO_RUC].Value.ToString() :
                                        ""; ;
            this.txtNroAgente.Text = row.Cells[CAMPO_NROAGENTE].Value != null ?
                                        row.Cells[CAMPO_NROAGENTE].Value.ToString() :
                                        ""; 
            this.txtNombreAgente.Text = row.Cells[CAMPO_NOMBREAGENTE].Value != null ?
                                        row.Cells[CAMPO_NOMBREAGENTE].Value.ToString() :
                                        ""; 
            this.txtClienteID.Text = row.Cells[CAMPO_CLIENTEID].Value != null ?
                                        row.Cells[CAMPO_CLIENTEID].Value.ToString() :
                                        ""; 
            this.txtANombreDe.Text = row.Cells[CAMPO_ANOMBREDE].Value != null ?
                                        row.Cells[CAMPO_ANOMBREDE].Value.ToString() :
                                        ""; 
            this.txtObjeto.Text = row.Cells[CAMPO_OBJETO].Value != null ?
                                        row.Cells[CAMPO_OBJETO].Value.ToString() :
                                        ""; 
            this.txtMonto.Text = row.Cells[CAMPO_MONTO].Value != null ?
                                        String.Format("{0:0.00}", (decimal)row.Cells[CAMPO_MONTO].Value) :
                                        ""; ;
            this.txtMoneda.Text = row.Cells[CAMPO_MONEDA].Value != null ?
                                        row.Cells[CAMPO_MONEDA].Value.ToString() :
                                        ""; 
            this.txtTramite.Text = row.Cells[CAMPO_TRAMITE].Value != null ?
                                        row.Cells[CAMPO_TRAMITE].Value.ToString() :
                                        ""; 
            this.txtResponsable.Text = row.Cells[CAMPO_RESPONSABLE].Value != null ?
                                        row.Cells[CAMPO_RESPONSABLE].Value.ToString() :
                                        ""; 
            this.txtFechaPago.Text = this.txtFecDoc.Text = row.Cells[CAMPO_FECHAPAGO].Value != null ?
                                    Convert.ToDateTime(row.Cells[CAMPO_FECHAPAGO].Value.ToString()).ToShortDateString() :
                                    "";
            this.txtMontoPago.Text = row.Cells[CAMPO_MONTOPAGO].Value != null ?
                                        String.Format("{0:0.00}", (decimal)row.Cells[CAMPO_MONTOPAGO].Value) :
                                        ""; 
            this.txtFormaPago.Text = row.Cells[CAMPO_FORMAPAGO].Value != null ?
                                        row.Cells[CAMPO_FORMAPAGO].Value.ToString() :
                                        ""; 
            this.txtDifBancaria.Text = row.Cells[CAMPO_DIFBANCARIA].Value != null ?
                                        row.Cells[CAMPO_DIFBANCARIA].Value.ToString() :
                                        ""; 
            this.txtBancoAbrev.Text = row.Cells[CAMPO_BANCOABREV].Value != null ?
                                        row.Cells[CAMPO_BANCOABREV].Value.ToString() :
                                        ""; 
            this.txtNombreBanco.Text = row.Cells[CAMPO_NOMBREBANCO].Value != null ?
                                        row.Cells[CAMPO_NOMBREBANCO].Value.ToString() :
                                        ""; 
            this.txtFechaBoleta.Text = this.txtFecDoc.Text = row.Cells[CAMPO_FECHABOLETA].Value != null ?
                                    Convert.ToDateTime(row.Cells[CAMPO_FECHABOLETA].Value.ToString()).ToShortDateString() :
                                    "";

        }
        #endregion CargarDatos

        #region Controles Locales
        private void dgvListadoABM_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this.LastDGVIndex > -1)
                this.CargarDatos(this.dgvListadoABM.Rows[this.LastDGVIndex]);

        }
        #endregion Controles Locales
    }
}