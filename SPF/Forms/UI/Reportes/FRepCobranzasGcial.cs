#region Using

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.IO;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms;

using ModelEF6;
using SPF.Forms.Base;
using SPF.Types;
using SPF.Forms;
using SPF.Base;
using SPF.Classes;
using Microsoft.Reporting.WebForms;

#endregion

namespace SPF.Forms.UI.Reportes
{
    public partial class FRepCobranzasGcial : FSeleccionarGrilla
    {
        #region Variables
        private BerkeDBEntities DBContext;
        private frmPickBase fPickBanco;
        private frmPickBase fPickFormaPago;
        private frmPickBase fPickMoneda;
        private frmPickBase fPickUnidadNegocio;
        #endregion Variables

        #region Constantes
        private const string CAMPO_SELECCIONAR = "Seleccionar";
        private const string CAMPO_COBROID = "CobroID";
        private const string CAMPO_FECHACOBRO= "FechaCobro";
        private const string CAMPO_CLIENTEID = "ClienteID";
        private const string CAMPO_CLIENTENOMBRE = "ClienteNombre";
        private const string CAMPO_FORMAPAGOID = "FormaPagoID";
        private const string CAMPO_FORMAPAGODESCRIP = "FormaPagoDescrip";
        private const string CAMPO_BANCOCHEQUEID = "BancoChequeID";
        private const string CAMPO_BANCOCHEQUEDESCRIP = "BancoChequeDescrip";
        private const string CAMPO_CHEQUENRO = "ChequeNro";
        private const string CAMPO_MONTOCOBRO = "MontoCobro";
        private const string CAMPO_MONEDAID = "MonedaID";
        private const string CAMPO_MONEDAABREV = "MonedaAbrev";
        private const string CAMPO_UNIDADNEGOCIOID = "UnidadNegocioID";
        private const string CAMPO_UNIDADNEGOCIODESCRIP = "UnidadNegocioDescrip";
        private const string AND = " AND ";
        private const string TITULO_GRILLA_ORIGEN = "Cobros - {0} filas";
        private const string TITULO_GRILLA_DESTINO = "Datos para el Listado - {0} cobros serán incluidos en el Listado";
        private const string DS1 = "DS1";
        private const string DS2 = "DS2";
        private const string DS3 = "DS3";
        private const string DATASET1 = "DataSet1";
        private const string DATASET2 = "DataSet2";
        private const string DATASET3 = "DataSet3";
        private const int REPORTE_COBROS_GERENCIAL = 1;
        private const string ETIQUETA_CHECKBOX_INCLUIR_SOLO_COBORS_NUEVOS = "Incluir sólo cobros posteriores al {0}";
        private const string TOOLTIP_CHECKBOX_INCLUIR_SOLO_COBORS_NUEVOS = "Se incluirán sólo cobros nuevos, posteriores a la última fecha de generación de este reporte.";
        #endregion Constantes

        #region Métodos de Inicio
        public FRepCobranzasGcial()
        {
            InitializeComponent();
        }

        public FRepCobranzasGcial(string titulo, BerkeDBEntities context)
        {
            InitializeComponent();
            this.Text = titulo;
            this.DBContext = context;
            //this.ConfigurarGrillas();
            //this.FormatearGrillas();
            this.SetGroupTitle = "Filtrar Cobranzas";
            this.SetTituloGrillaOrigen = "Cobros";
            this.TituloGrillaDestino = "Datos para el Listado";
            this.chkIncluirSoloCobrosNuevos.Text = String.Format(ETIQUETA_CHECKBOX_INCLUIR_SOLO_COBORS_NUEVOS, this.GetFechaUltimaGeneracion());
            this.toolTip1.SetToolTip(this.chkIncluirSoloCobrosNuevos, TOOLTIP_CHECKBOX_INCLUIR_SOLO_COBORS_NUEVOS);

            #region TextSearchBoxes
            this.tSBBanco.KeyMemberWidth = 100;
            this.tSBBanco.Editable = true;
            this.tSBBanco.ToolTip = "Elegir Banco de Depósito";
            this.tSBBanco.AceptarClick += tSBBanco_AceptarClick;

            this.tSBFormaPago.KeyMemberWidth = 100;
            this.tSBFormaPago.Editable = true;
            this.tSBFormaPago.ToolTip = "Elegir Forma de Pago";
            this.tSBFormaPago.AceptarClick += tSBFormaPago_AceptarClick;

            this.tSBMoneda.KeyMemberWidth = 100;
            this.tSBMoneda.ToolTip = "Elegir Moneda";
            this.tSBMoneda.Editable = true;
            this.tSBMoneda.AceptarClick += tSBMoneda_AceptarClick;

            this.tSBUnidadNegocio.KeyMemberWidth = 100;
            this.tSBUnidadNegocio.ToolTip = "Elegir Unidad de Negocio";
            this.tSBUnidadNegocio.Editable = true;
            this.tSBUnidadNegocio.AceptarClick += tSBUnidadNegocio_AceptarClick;
            #endregion TextSearchBoxes
        }

        private void FRepCobranzasGcial_Load(object sender, EventArgs e)
        {
            DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            this.dtpFechaDesde.Value = firstDayOfMonth;
            this.txtFechaDesde.Text = firstDayOfMonth.ToShortDateString();
            this.dtpFechaHasta.Value = DateTime.Now;
            this.txtFechaHasta.Text = DateTime.Now.ToShortDateString();

            this.TituloOrigenString = TITULO_GRILLA_ORIGEN;
            this.TituloDestinoString = TITULO_GRILLA_DESTINO;
            this.txtFechaDesde.Focus();
        }
                
        #endregion Métodos de Inicio

        #region Métodos de Apoyo
        private void GetDatosCobros(string where = "", object[] filterParams = null)
        {
            //var query = (from cob in this.DBContext.pp_pagopresupuesto
            //             join pCab in this.DBContext.pc_presupuestocab
            //                on cob.pp_presupuestocabid equals pCab.pc_presupuestocabid
            //             join cli in this.DBContext.Cliente
            //                on pCab.pc_clienteid equals cli.ID
            //             join bCheq in this.DBContext.ba_banco
            //                on cob.pp_bancochequeid equals bCheq.ba_bancoid into bCheq_cob
            //             from bCheq in bCheq_cob.DefaultIfEmpty()
            //             join fp in this.DBContext.fp_formadepago
            //                on cob.pp_formapagoid equals fp.fp_formadepagoid
            //             join mon in this.DBContext.Moneda
            //                on cob.pp_monedaid equals mon.ID
            //             select new CobrosType
            //             {
            //                 CobroID = cob.pp_pagopresupuestoid,
            //                 FechaCobro = cob.pp_fechapago,
            //                 ClienteID = pCab.pc_clienteid,
            //                 ClienteNombre = cli.Nombre,
            //                 FormaPagoID = cob.pp_formapagoid,
            //                 FormaPagoDescrip = fp.fp_descripcion,
            //                 BancoChequeID = cob.pp_bancochequeid,
            //                 BancoChequeDescrip = bCheq.ba_descripcion,
            //                 ChequeNro = cob.pp_nrocheque,
            //                 MontoCobro = cob.pp_montopago,
            //                 MonedaAbrev = mon.AbrevMoneda
            //             })
            //             .Where(where, filterParams)
            //             .OrderBy(a => a.CobroID)
            //             .ToList();

            var query = this.DBContext.GetListaParaRepCobrosGcial(where, this.chkIncluirSoloCobrosNuevos.Checked).ToList();

            this.SetDataSourceOrigen<GetListaParaRepCobrosGcial_Result>(query);
            
        }

        private void GenerarFiltro()
        {
            string rango = String.Empty;
            string cobroID = String.Empty;
            string bancoID = String.Empty;
            string nroCheque = String.Empty;
            string formapagoID = String.Empty;
            string unidadNegocioID = String.Empty;
            string predicate = String.Empty;


            if ((this.txtFechaDesde.Text.Trim() == String.Empty) &&
                (this.txtFechaHasta.Text.Trim() == String.Empty) &&
                (this.txtCobroID.Text.Trim() == String.Empty) &&
                (this.tSBBanco.KeyMember.Trim() == String.Empty) &&
                (this.txtNroCheque.Text.Trim() == String.Empty) &&
                (this.tSBFormaPago.KeyMember.Trim() == String.Empty))
            {
                MessageBox.Show("Debe indicar algún filtro.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            if (((this.txtFechaDesde.Text.Trim() != String.Empty) &&
                (this.txtFechaHasta.Text.Trim() == String.Empty)) ||
                ((this.txtFechaDesde.Text.Trim() == String.Empty) &&
                (this.txtFechaHasta.Text.Trim() != String.Empty)))
            {
                MessageBox.Show("Debe indicar la Fecha Desde y la Fecha Hasta del rango.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            GenerarCadenasFiltro genFiltro = new GenerarCadenasFiltro();

            if ((this.txtFechaDesde.Text.Trim() != "") && (this.txtFechaHasta.Text.Trim() != String.Empty))
            {
                rango = this.txtFechaDesde.Text + "-" + this.txtFechaHasta.Text;
            }

            if (rango != String.Empty)
            {
                predicate += predicate != String.Empty ? AND : String.Empty;
                predicate += genFiltro.GetFilterString(rango, CAMPO_FECHACOBRO, true).Replace('\"', '\'');
            }

            if (this.txtCobroID.Text != String.Empty)
            {
                predicate += predicate != String.Empty ? AND : String.Empty;
                predicate += genFiltro.GetFilterString(this.txtCobroID.Text, CAMPO_COBROID);
            }

            if (this.tSBBanco.KeyMember != String.Empty)
            {
                predicate += predicate != String.Empty ? AND : String.Empty;
                predicate += genFiltro.GetFilterString(this.tSBBanco.KeyMember, CAMPO_BANCOCHEQUEID);
            }

            if (this.txtNroCheque.Text != String.Empty)
            {
                predicate += predicate != String.Empty ? AND : String.Empty;
                predicate += genFiltro.GetFilterString(this.txtNroCheque.Text, CAMPO_CHEQUENRO, true, true);
            }

            if (this.tSBFormaPago.KeyMember != String.Empty)
            {
                predicate += predicate != String.Empty ? AND : String.Empty;
                predicate += genFiltro.GetFilterString(this.tSBFormaPago.KeyMember, CAMPO_FORMAPAGOID);
            }

            if (this.tSBMoneda.KeyMember != String.Empty)
            {
                predicate += predicate != String.Empty ? AND : String.Empty;
                predicate += genFiltro.GetFilterString(this.tSBMoneda.KeyMember, CAMPO_MONEDAID);
            }

            if (this.tSBUnidadNegocio.KeyMember != String.Empty)
            {
                predicate += predicate != String.Empty ? AND : String.Empty;
                predicate += genFiltro.GetFilterString(this.tSBUnidadNegocio.KeyMember, CAMPO_UNIDADNEGOCIOID);
            }

            //predicate = genFiltro.GetParseString(predicate);
            //List<object> filterParam = genFiltro.FilterParam;
            this.GetDatosCobros(predicate);
        }

        private void GenerarReporte()
        {
            if (this.dgvDestino.RowCount == 0)
            {
                MessageBox.Show("No se seleccionaron datos para la generación del reporte.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            List<GetRepCobranzasPorUnidNegocioV2_Result> reportDS = new List<GetRepCobranzasPorUnidNegocioV2_Result>();

            try
            {
                reportDS = this.DBContext.GetRepCobranzasPorUnidNegocioV2(this.GetListaCobros(), this.chkIncluirSoloCobrosNuevos.Checked).ToList();

                if (reportDS.Count == 0)
                {
                    throw new Exception("No existen datos para el reporte con los criterios ingresados.");
                }

                //ReportDataSource datasource = null;
                //datasource = new ReportDataSource("DataSet1", reportDS);

                string path = @"Reportes\RepListadoCobrosGcialV2.rdlc";
                string asuntoMail = "Reporte de Cobros por Unidad de Negocio - Gerencial";
                string cuerpoMail = "Por favor revise el documento adjunto.";
                string nombreArchivo = "RepListadoCobrosGcial";
                string rango = this.GetRangoString();

                FReportViewerBase f = new FReportViewerBase(path, this.GetListReportDatSource(reportDS, rango), this.DBContext);
                f.FormClosed += delegate { f = null; };
                f.Titulo = String.Format("Reporte de Cobros por Unidad de Negocio - Gerencial - {0}", rango);
                f.NombreArchivoAdjunto = nombreArchivo;
                f.AsuntoMail = asuntoMail + " - " + String.Format("Reporte de Cobros por Unidad de Negocio - Gerencial - {0}", rango);
                f.CuerpoMail = cuerpoMail;
                f.ShowDialog();

                this.chkIncluirSoloCobrosNuevos.Text = String.Format(ETIQUETA_CHECKBOX_INCLUIR_SOLO_COBORS_NUEVOS, this.GetFechaUltimaGeneracion());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al generar el reporte: " + Environment.NewLine + ex.Message, "Información de Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private string GetListaCobros()
        {
            string Result = String.Empty;
            foreach (DataGridViewRow row in this.dgvDestino.Rows)
            {
                Result += Result != String.Empty ? "," : String.Empty;
                Result += row.Cells[CAMPO_COBROID].Value.ToString();
            }
            return Result;
        }

        private string GetRangoString()
        {
            const string RANGO = "Del {0} al {1}";
            const string TODOS = "Todos";
            string Result = String.Empty;

            Result = TODOS;

            if ((this.txtFechaDesde.Text != String.Empty) && (this.txtFechaHasta.Text != String.Empty))
            {
                Result = String.Format(RANGO, this.txtFechaDesde.Text, this.txtFechaHasta.Text);
            }

            return Result;
        }

        private string GetFechaUltimaGeneracion()
        {
            const string FECHAHORA = "{0} {1}";
            sr_seguimientoreporte sr = this.DBContext.sr_seguimientoreporte.First(a => a.sr_reporteid == REPORTE_COBROS_GERENCIAL);
            ((IObjectContextAdapter)this.DBContext).ObjectContext.Refresh(System.Data.Entity.Core.Objects.RefreshMode.ClientWins, sr);

            return String.Format(FECHAHORA, sr.sr_fechaultgen.ToShortDateString(), sr.sr_fechaultgen.ToShortTimeString());
        }

        private List<ReportDataSource> GetListReportDatSource(List<GetRepCobranzasPorUnidNegocioV2_Result> dsAll, string rango)
        {
            List<ReportDataSource> Result = new List<ReportDataSource>();

            List<Dataset1RepCobranzasGcial> listaDS1 = (from ds1 in dsAll
                                                        select new Dataset1RepCobranzasGcial
                                                        {
                                                            Dataset = ds1.Dataset,
                                                            //CobroID = ds1.CobroID,
                                                            CobroIDStr = ds1.CobroIDStr,
                                                            FechaCobro = ds1.FechaCobro,
                                                            ClienteID = ds1.ClienteID,
                                                            //ClienteNombre = ds1.ClienteNombre,
                                                            Documentos = ds1.Documentos,
                                                            MonedaID = ds1.MonedaID,
                                                            MonedaAbrev = ds1.MonedaAbrev,
                                                            MonedaDescrip = ds1.MonedaDescrip,
                                                            FormaPagoID = ds1.FormaPagoID,
                                                            FormaPagoDescrip = ds1.FormaPagoDescrip,
                                                            BancoChequeID = ds1.BancoChequeID,
                                                            BancoChequeDescrip = ds1.BancoChequeDescrip,
                                                            ChequeNro = ds1.ChequeNro,
                                                            MontoCobro = ds1.MontoCobro,
                                                            //TramiteID = ds1.TramiteID,
                                                            //TramiteDescrip = ds1.TramiteDescrip,
                                                            //AreaID = ds1.AreaID,
                                                            //AreaDescrip = ds1.AreaDescrip,
                                                            UnidadNegocioID = ds1.UnidadNegocioID,
                                                            UnidadNegocioDescrip = ds1.UnidadNegocioDescrip,
                                                            Rango = ds1.Rango
                                                        })
                                                       .Where(a => a.Dataset == DS1)
                                                       .ToList();
            listaDS1.First().Rango = rango;
            Result.Add(new ReportDataSource(DATASET1, listaDS1));

            List<Dataset2RepCobranzasGcial> listaDS2 = (from ds2 in dsAll
                                                        select new Dataset2RepCobranzasGcial
                                                        {
                                                            Dataset = ds2.Dataset,
                                                            DS2_MonedaDescrip = ds2.DS2_MonedaDescrip,
                                                            DS2_TotalPI = ds2.DS2_PI_TOTAL,
                                                            DS2_TotalPG = ds2.DS2_PG_TOTAL,
                                                            DS2_GranTotal = ds2.DS2_GRAN_TOTAL
                                                        })
                                                       .Where(a => a.Dataset == DS2)
                                                       .ToList();
            Result.Add(new ReportDataSource(DATASET2, listaDS2));

            List<Dataset3RepCobranzasGcial> listaDS3 = (from ds3 in dsAll
                                                        select new Dataset3RepCobranzasGcial
                                                        {
                                                            Dataset = ds3.Dataset,
                                                            DS3_MonedaDescrip = ds3.DS3_MonedaDescrip,
                                                            DS3_TotalPI = ds3.DS3_PI_TOTAL,
                                                            DS3_TotalPG = ds3.DS3_PG_TOTAL,
                                                            DS3_GranTotal = ds3.DS3_GRAN_TOTAL
                                                        })
                                                       .Where(a => a.Dataset == DS3)
                                                       .ToList();
            Result.Add(new ReportDataSource(DATASET3, listaDS3));

            return Result;
        }
        
        #endregion Métodos de Apoyo

        #region Métodos Sobreescritos heredados del Parent Control
        protected override void FormatearGrillaOrigen()
        {
            foreach (DataGridViewColumn col in this.dgvOrigen.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            int displayIndex = 0;

            this.dgvOrigen.Columns[CAMPO_COBROID].Visible = true;
            this.dgvOrigen.Columns[CAMPO_COBROID].DisplayIndex = displayIndex;
            this.dgvOrigen.Columns[CAMPO_COBROID].HeaderText = "Cobro ID";
            this.dgvOrigen.Columns[CAMPO_COBROID].Width = 70;
            this.dgvOrigen.Columns[CAMPO_COBROID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            displayIndex++;

            this.dgvOrigen.Columns[CAMPO_FECHACOBRO].Visible = true;
            this.dgvOrigen.Columns[CAMPO_FECHACOBRO].DisplayIndex = displayIndex;
            this.dgvOrigen.Columns[CAMPO_FECHACOBRO].HeaderText = "Fecha";
            this.dgvOrigen.Columns[CAMPO_FECHACOBRO].Width = 65;
            //this.dgvOrigen.Columns[CAMPO_FECHACOBRO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            displayIndex++;

            this.dgvOrigen.Columns[CAMPO_CLIENTENOMBRE].Visible = true;
            this.dgvOrigen.Columns[CAMPO_CLIENTENOMBRE].DisplayIndex = displayIndex;
            this.dgvOrigen.Columns[CAMPO_CLIENTENOMBRE].HeaderText = "Cliente";
            this.dgvOrigen.Columns[CAMPO_CLIENTENOMBRE].Width = 200;
            displayIndex++;

            this.dgvOrigen.Columns[CAMPO_FORMAPAGODESCRIP].Visible = true;
            this.dgvOrigen.Columns[CAMPO_FORMAPAGODESCRIP].DisplayIndex = displayIndex;
            this.dgvOrigen.Columns[CAMPO_FORMAPAGODESCRIP].HeaderText = "Forma de Pago";
            this.dgvOrigen.Columns[CAMPO_FORMAPAGODESCRIP].Width = 120;
            displayIndex++;

            this.dgvOrigen.Columns[CAMPO_BANCOCHEQUEDESCRIP].Visible = true;
            this.dgvOrigen.Columns[CAMPO_BANCOCHEQUEDESCRIP].DisplayIndex = displayIndex;
            this.dgvOrigen.Columns[CAMPO_BANCOCHEQUEDESCRIP].HeaderText = "Banco";
            this.dgvOrigen.Columns[CAMPO_BANCOCHEQUEDESCRIP].Width = 90;
            displayIndex++;

            this.dgvOrigen.Columns[CAMPO_CHEQUENRO].Visible = true;
            this.dgvOrigen.Columns[CAMPO_CHEQUENRO].DisplayIndex = displayIndex;
            this.dgvOrigen.Columns[CAMPO_CHEQUENRO].HeaderText = "N° Cheque";
            this.dgvOrigen.Columns[CAMPO_CHEQUENRO].Width = 95;
            displayIndex++;

            this.dgvOrigen.Columns[CAMPO_MONTOCOBRO].Visible = true;
            this.dgvOrigen.Columns[CAMPO_MONTOCOBRO].DisplayIndex = displayIndex;
            this.dgvOrigen.Columns[CAMPO_MONTOCOBRO].HeaderText = "Monto";
            this.dgvOrigen.Columns[CAMPO_MONTOCOBRO].Width = 70;
            this.dgvOrigen.Columns[CAMPO_MONTOCOBRO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvOrigen.Columns[CAMPO_MONTOCOBRO].DefaultCellStyle.Format = "N2";
            displayIndex++;

            this.dgvOrigen.Columns[CAMPO_MONEDAABREV].Visible = true;
            this.dgvOrigen.Columns[CAMPO_MONEDAABREV].DisplayIndex = displayIndex;
            this.dgvOrigen.Columns[CAMPO_MONEDAABREV].HeaderText = "Moneda";
            this.dgvOrigen.Columns[CAMPO_MONEDAABREV].Width = 60;
            displayIndex++;

            this.dgvOrigen.Columns[CAMPO_UNIDADNEGOCIODESCRIP].Visible = true;
            this.dgvOrigen.Columns[CAMPO_UNIDADNEGOCIODESCRIP].DisplayIndex = displayIndex;
            this.dgvOrigen.Columns[CAMPO_UNIDADNEGOCIODESCRIP].HeaderText = "Unid. Negocio";
            this.dgvOrigen.Columns[CAMPO_UNIDADNEGOCIODESCRIP].Width = 95;
            displayIndex++;

            DataGridViewCheckBoxColumn doWork = new DataGridViewCheckBoxColumn();
            doWork.Name = CAMPO_SELECCIONAR;
            doWork.HeaderText = CAMPO_SELECCIONAR;
            doWork.ValueType = typeof(Boolean);
            doWork.FalseValue = false;
            doWork.TrueValue = true;
            doWork.ReadOnly = false;
            doWork.Width = 80;
            this.dgvOrigen.Columns.Insert(0, doWork);
        }

        protected override void FormatearGrillaDestino()
        {
            foreach (DataGridViewColumn col in this.dgvDestino.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            int displayIndex = 0;

            this.dgvDestino.Columns[CAMPO_COBROID].Visible = true;
            this.dgvDestino.Columns[CAMPO_COBROID].DisplayIndex = displayIndex;
            this.dgvDestino.Columns[CAMPO_COBROID].HeaderText = "Cobro ID";
            this.dgvDestino.Columns[CAMPO_COBROID].Width = 70;
            this.dgvDestino.Columns[CAMPO_COBROID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            displayIndex++;

            this.dgvDestino.Columns[CAMPO_FECHACOBRO].Visible = true;
            this.dgvDestino.Columns[CAMPO_FECHACOBRO].DisplayIndex = displayIndex;
            this.dgvDestino.Columns[CAMPO_FECHACOBRO].HeaderText = "Fecha";
            this.dgvDestino.Columns[CAMPO_FECHACOBRO].Width = 70;
            //this.dgvDestino.Columns[CAMPO_FECHACOBRO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            displayIndex++;

            this.dgvDestino.Columns[CAMPO_CLIENTENOMBRE].Visible = true;
            this.dgvDestino.Columns[CAMPO_CLIENTENOMBRE].DisplayIndex = displayIndex;
            this.dgvDestino.Columns[CAMPO_CLIENTENOMBRE].HeaderText = "Cliente";
            this.dgvDestino.Columns[CAMPO_CLIENTENOMBRE].Width = 240;
            displayIndex++;

            this.dgvDestino.Columns[CAMPO_FORMAPAGODESCRIP].Visible = true;
            this.dgvDestino.Columns[CAMPO_FORMAPAGODESCRIP].DisplayIndex = displayIndex;
            this.dgvDestino.Columns[CAMPO_FORMAPAGODESCRIP].HeaderText = "Forma de Pago";
            this.dgvDestino.Columns[CAMPO_FORMAPAGODESCRIP].Width = 120;
            displayIndex++;

            this.dgvDestino.Columns[CAMPO_BANCOCHEQUEDESCRIP].Visible = true;
            this.dgvDestino.Columns[CAMPO_BANCOCHEQUEDESCRIP].DisplayIndex = displayIndex;
            this.dgvDestino.Columns[CAMPO_BANCOCHEQUEDESCRIP].HeaderText = "Banco";
            this.dgvDestino.Columns[CAMPO_BANCOCHEQUEDESCRIP].Width = 90;
            displayIndex++;

            this.dgvDestino.Columns[CAMPO_CHEQUENRO].Visible = true;
            this.dgvDestino.Columns[CAMPO_CHEQUENRO].DisplayIndex = displayIndex;
            this.dgvDestino.Columns[CAMPO_CHEQUENRO].HeaderText = "N° Cheque";
            this.dgvDestino.Columns[CAMPO_CHEQUENRO].Width = 95;
            displayIndex++;

            this.dgvDestino.Columns[CAMPO_MONTOCOBRO].Visible = true;
            this.dgvDestino.Columns[CAMPO_MONTOCOBRO].DisplayIndex = displayIndex;
            this.dgvDestino.Columns[CAMPO_MONTOCOBRO].HeaderText = "Monto";
            this.dgvDestino.Columns[CAMPO_MONTOCOBRO].Width = 80;
            this.dgvDestino.Columns[CAMPO_MONTOCOBRO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvDestino.Columns[CAMPO_MONTOCOBRO].DefaultCellStyle.Format = "N2";
            displayIndex++;

            this.dgvDestino.Columns[CAMPO_MONEDAABREV].Visible = true;
            this.dgvDestino.Columns[CAMPO_MONEDAABREV].DisplayIndex = displayIndex;
            this.dgvDestino.Columns[CAMPO_MONEDAABREV].HeaderText = "Moneda";
            this.dgvDestino.Columns[CAMPO_MONEDAABREV].Width = 60;
            displayIndex++;

            this.dgvDestino.Columns[CAMPO_UNIDADNEGOCIODESCRIP].Visible = true;
            this.dgvDestino.Columns[CAMPO_UNIDADNEGOCIODESCRIP].DisplayIndex = displayIndex;
            this.dgvDestino.Columns[CAMPO_UNIDADNEGOCIODESCRIP].HeaderText = "Unid. Negocio";
            this.dgvDestino.Columns[CAMPO_UNIDADNEGOCIODESCRIP].Width = 95;
            displayIndex++;
        }

        public override void btnAgregarSeleccion_Click(object sender, EventArgs e)
        {
            this.PrepararDatos<GetListaParaRepCobrosGcial_Result>(CAMPO_COBROID);
        }
        #endregion Métodos Sobreescritos heredados del Parent Control

        #region Métodos Locales Sobre Controles
        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaDesde.Text = this.dtpFechaDesde.Value.ToShortDateString();
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            this.txtFechaHasta.Text = this.dtpFechaHasta.Value.ToShortDateString();
        }

        private void btnFiltrar_Click_1(object sender, EventArgs e)
        {
            this.GenerarFiltro();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.GenerarReporte();
        }
        
        #endregion Métodos Locales Sobre Controles

        #region Picks
        #region Banco
        private void tSBBanco_AceptarClick(object sender, EventArgs e)
        {
            if (fPickBanco == null)
            {
                fPickBanco = new frmPickBase();
                fPickBanco.AceptarFiltrarClick += fPickBanco_AceptarFiltrarClick;
                fPickBanco.FiltrarClick += fPickBanco_FiltrarClick;
                fPickBanco.Titulo = "Elegir Banco";
                fPickBanco.CampoIDNombre = "ba_bancoid";
                fPickBanco.CampoDescripNombre = "ba_descripcion";
                fPickBanco.LabelCampoID = "ID";
                fPickBanco.LabelCampoDescrip = "Nombre";
                fPickBanco.NombreCampo = "Banco";
                fPickBanco.PermitirFiltroNulo = true;
            }
            fPickBanco.MostrarFiltro();
            this.fPickBanco_FiltrarClick(sender, e);
        }

        private void fPickBanco_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickBanco != null)
            {
                fPickBanco.LoadData<ba_banco>(this.DBContext.ba_banco, fPickBanco.GetWhereString());
            }
        }

        private void fPickBanco_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBBanco.DisplayMember = fPickBanco.ValorDescrip;
            this.tSBBanco.KeyMember = fPickBanco.ValorID;

            fPickBanco.Close();
            fPickBanco.Dispose();
        }
        #endregion Banco Depósito

        #region Forma de Pago
        private void tSBFormaPago_AceptarClick(object sender, EventArgs e)
        {
            if (fPickFormaPago == null)
            {
                fPickFormaPago = new frmPickBase();
                fPickFormaPago.AceptarFiltrarClick += fPickFormaPago_AceptarFiltrarClick;
                fPickFormaPago.FiltrarClick += fPickFormaPago_FiltrarClick;
                fPickFormaPago.Titulo = "Elegir Forma de Pago";
                fPickFormaPago.CampoIDNombre = "fp_formadepagoid";
                fPickFormaPago.CampoDescripNombre = "fp_descripcion";
                fPickFormaPago.LabelCampoID = "ID";
                fPickFormaPago.LabelCampoDescrip = "Nombre";
                fPickFormaPago.NombreCampo = "Forma Pago";
                fPickFormaPago.PermitirFiltroNulo = true;
            }
            fPickFormaPago.MostrarFiltro();
            this.fPickFormaPago_FiltrarClick(sender, e);
        }

        private void fPickFormaPago_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickFormaPago != null)
            {
                fPickFormaPago.LoadData<fp_formadepago>(this.DBContext.fp_formadepago, fPickFormaPago.GetWhereString());
            }
        }

        private void fPickFormaPago_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBFormaPago.DisplayMember = fPickFormaPago.ValorDescrip;
            this.tSBFormaPago.KeyMember = fPickFormaPago.ValorID;

            fPickFormaPago.Close();
            fPickFormaPago.Dispose();

        }
        #endregion Forma de Pago

        #region Moneda
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
                fPickMoneda.NombreCampo = "Moneda";
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
        #endregion Moneda

        #region Unidad Negocio
        private void tSBUnidadNegocio_AceptarClick(object sender, EventArgs e)
        {
            if (fPickUnidadNegocio == null)
            {
                fPickUnidadNegocio = new frmPickBase();
                fPickUnidadNegocio.AceptarFiltrarClick += fPickUnidadNegocio_AceptarFiltrarClick;
                fPickUnidadNegocio.FiltrarClick += fPickUnidadNegocio_FiltrarClick;
                fPickUnidadNegocio.Titulo = "Elegir Unidad de Negocio";
                fPickUnidadNegocio.CampoIDNombre = "UnidadNegocioID";
                fPickUnidadNegocio.CampoDescripNombre = "UnidadNegocioDescrip";
                fPickUnidadNegocio.LabelCampoID = "ID";
                fPickUnidadNegocio.LabelCampoDescrip = "Descripción";
                fPickUnidadNegocio.NombreCampo = "Un. Negocio";
                fPickUnidadNegocio.PermitirFiltroNulo = true;
            }
            fPickUnidadNegocio.MostrarFiltro();
            this.fPickUnidadNegocio_FiltrarClick(sender, e);
        }

        private void fPickUnidadNegocio_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickUnidadNegocio != null)
            {
                var query = (from un in this.DBContext.un_unidadnegocio
                             select new UnidadNegocioType
                             {
                                 UnidadNegocioID = un.un_unidadnegocioid,
                                 UnidadNegocioDescrip = un.un_descripcion
                             })
                            .Where(a => a.UnidadNegocioID == 1 || a.UnidadNegocioID == 2).ToList();

                fPickUnidadNegocio.LoadData<UnidadNegocioType>(query.AsQueryable(), fPickUnidadNegocio.GetWhereString());
                //fPickUnidadNegocio.LoadData<un_unidadnegocio>(this.DBContext.un_unidadnegocio, fPickUnidadNegocio.GetWhereString());
            }
        }

        private void fPickUnidadNegocio_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBUnidadNegocio.DisplayMember = fPickUnidadNegocio.ValorDescrip;
            this.tSBUnidadNegocio.KeyMember = fPickUnidadNegocio.ValorID;

            fPickUnidadNegocio.Close();
            fPickUnidadNegocio.Dispose();
        }
        #endregion Unidad Negocio

        private void btnAgregarSeleccion_Click_1(object sender, EventArgs e)
        {

        }

        #endregion Picks
    }
}