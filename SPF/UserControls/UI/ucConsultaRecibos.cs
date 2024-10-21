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
    public partial class ucConsultaRecibos : ucBaseForm
    {
        #region Constantes
        private const string LOCALHOST = "localhost";

        private const string CAMPO_RECIBOID = "ReciboId";
        private const string CAMPO_FECHARECIBO = "FechaRecibo";
        private const string CAMPO_NRORECIBO = "NroRecibo";
        private const string CAMPO_CLIENTEID = "ClienteId";
        private const string CAMPO_CLIENTENOMBRE = "ClienteNombre";
        private const string CAMPO_MONEDAID = "MonedaId";
        private const string CAMPO_MONEDADESCRIP = "MonedaDescrip";
        private const string CAMPO_MONEDAABREV = "MonedaAbrev";
        private const string CAMPO_TOTALRECIBO = "TotalRecibo";
        private const string CAMPO_TOTALNC = "TotalNC";
        private const string CAMPO_TOTALRETIVA10 = "TotalRetIVA10";
        private const string CAMPO_TOTALRETRENTA = "TotalRetRenta";
        private const string CAMPO_TOTALTRANSF = "TotalTransf";
        private const string CAMPO_TOTALGASTOS = "TotalGastos";
        private const string CAMPO_TOTALCHEQUES = "TotalCheques";
        private const string CAMPO_TOTALEFECTIVO = "TotalEfectivo";
        private const string CAMPO_CONCEPTORECIBO = "ConceptoRecibo";
        private const string CAMPO_USUARIOCARGAID = "UsuarioCargaId";
        private const string CAMPO_USUARIOCARGANOMBRE = "UsuarioCargaNombre";
        private const string CAMPO_ANULADO = "Anulado";
        private const string CAMPO_AUTORIZACIONVIG = "TieneAutorizacionVigente";

        private const string CAMPO_FECHA_TRANSFERENCIA = "FechaTransferencia";
        private const string CAMPO_CUENTA_TRANSFERENCIA_ID = "BancoTransferenciaId";
        private const string CAMPO_CUENTA_TRANSFERENCIA_DESCRIP = "BancoTransferenciaDescrip";
        private const string CAMPO_NUMERO_TRANSFERENCIA = "NumeroTransferencia";
        private const string CAMPO_MONTO_GASTO_BANCARIO = "MontoGastoBancario";
        private const string CAMPO_MONTO_TRANSFERENCIA = "MontoTransferencia";
        private const string CAMPO_MONEDA_TRANSFERENCIA_ID = "MonedaTransferenciaId";
        private const string CAMPO_MONEDA_TRANSFERENCIA_ABREV = "MonedaTransferenciaAbrev";
        private const string CAMPO_CUENTA_TRANSFERENCIA_PAIS_ID = "PaisId";

        private const string CAMPO_FECHA_CHEQUE = "FechaCheque";
        private const string CAMPO_BANCO_CHEQUE_ID = "BancoChequeId";
        private const string CAMPO_BANCO_CHEQUE_DESCRIP = "BancoChequeDescrip";
        private const string CAMPO_NUMERO_CHEQUE = "NumeroCheque";
        private const string CAMPO_MONTO_CHEQUE = "MontoCheque";
        private const string CAMPO_MONEDA_CHEQUE_ID = "MonedaChequeId";
        private const string CAMPO_MONEDA_CHEQUE_ABREV = "MonedaChequeAbrev";

        private string CAMPO_NROFACTURA = "NroFactura";
        private string CAMPO_FECHAFACTURA = "FechaFactura";
        private string CAMPO_TOTALFACTURA = "TotalFactura";
        private string CAMPO_MONTOPAGADOFACTURA = "MontoPagadoFactura";
        private string CAMPO_NUMERORETENCION = "NumeroRetencion";
        private string CAMPO_FECHARETENCION = "FechaRetencion";
        private string CAMPO_RETENCIONIVA10 = "MontoRetencionIVA10";
        private string CAMPO_RETENCIONRENTA = "MontoRetencionRenta";
        private string CAMPO_RUC = "RUC";

        private string CAMPO_NRODOCUMENTO = "NroDocumento";
        private string CAMPO_FECHADOCUMENTO = "FechaDocumento";
        private string CAMPO_SERVICIOS = "Servicios";
        private string CAMPO_TOTALDOCUMENTO = "TotalDocumento";
        private string CAMPO_SALDODOCUMENTO = "SaldoDocumento";
        private string CAMPO_TRAMITEDESCRIP = "TramiteDescrip";
        private string CAMPO_AREADESCRIP = "AreaDescrip";

        private int DOCUMENTO_RECIBO_CLIENTE_ID = 14;

        private const int GUARANIES_MONEDA_ID = 3;
        private const string GUARANIES_TEXTO = "guaraníes";
        private const int DOLARES_MONEDA_ID = 2;
        private const string DOLARES_TEXTO = "dólares americanos";
        private const string FORMATO_MONEDA_GUARANIES_GRILLA = "N0";
        private const string FORMATO_MONEDA_OTROS_GRILLA = "N2";
        private const string FORMATO_MONEDA_GUARANIES = "{0:N0}";
        private const string FORMATO_MONEDA_OTROS = "{0:N2}";

        private const string ESTADO_PENDIENTE = "A";
        private const int PAIS_PARAGUAY_ID = 91;
        private const int IDIOMA_ESPANOL = 2;

        private const int LIMITE_FACTURAS_POR_RECIBO = 14;
        private const int LIMITE_TRANSF_CHEQUES_POR_RECIBO = 4;
        private const bool IMPRIMIR_RECIBO_SIMPLE = true;

        private const string FACTURAS_CANCELADAS = "FACTURAS CANCELADAS S/ DETALLE. ";
        private const string FACTURAS_PAGOS_PARCIALES = "PAGO PARCIAL FACT: {0}. ";
        #endregion Constantes

        #region Variables
        private FormatoNumeroReciboType formatoNumeroRecibo;
        private List<int> timbrados = new List<int>();
        private int UsuarioId;
        #endregion Variables

        #region Propiedades
        private FormatoNumeroReciboType FormatoNumeroRecibo
        {
            get { return this.formatoNumeroRecibo; }
            set { this.formatoNumeroRecibo = value; }
        }
        #endregion Propiedades

        #region Métodos de Inicio
        public ucConsultaRecibos()
        {
            InitializeComponent();
        }

        public ucConsultaRecibos(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();
            this.DBContext = dbContext;
            this.Titulo = Titulo;
            this.UsuarioId = Convert.ToInt32(VWGContext.Current.Session["UsuarioID"].ToString());

            timbrados = (from t in
                             ((from su in this.DBContext.su_serieusuario
                               join usu in this.DBContext.Usuario
                                  on su.su_usuarioid equals usu.ID
                               join ti in this.DBContext.ti_timbrado
                                on su.su_timbradoid equals ti.ti_timbradoid
                               select new PermisoTimbrado
                               {
                                   PermisoTimbradoID = su.su_serieusuarioid,
                                   TimbradoID = su.su_timbradoid,
                                   UsuarioID = su.su_usuarioid,
                                   UsuarioNombre = usu.NombrePila,
                                   TipoDocumentoID = ti.ti_tipodocumentoid
                               })
                                 .Where(a => a.UsuarioID == this.UsuarioId && a.TipoDocumentoID == DOCUMENTO_RECIBO_CLIENTE_ID).ToList())
                         select t.TimbradoID).ToList();

            var recibos = (from re in this.DBContext.re_recibo
                           join cl in this.DBContext.Cliente
                               on re.re_clienteid equals cl.ID
                           join mo in this.DBContext.Moneda
                               on re.re_monedaid equals mo.ID
                           join us in this.DBContext.Usuario
                               on re.re_usuarioid equals us.ID
                           select new
                           {
                               NroRecibo = re.re_numero,
                               FechaRecibo = re.re_fecha,
                               ClienteId = re.re_clienteid,
                               ClienteNombre = cl.Nombre,
                               MonedaId = re.re_monedaid,
                               MonedaDescrip = mo.Descripcion,
                               MonedaAbrev = mo.AbrevMoneda,
                               TotalRecibo = re.re_totalrecibo,
                               TotalNC = re.re_totalnc,
                               TotalRetIVA10 = re.re_montoret10,
                               TotalRetRenta = re.re_montoretrenta,
                               TotalTransf = re.re_totaltransf,
                               TotalGastos = re.re_totalgastos,
                               TotalCheques = re.re_totalcheques,
                               TotalEfectivo = re.re_totalefectivo,
                               ConceptoRecibo = re.re_concepto,
                               UsuarioCargaId = re.re_usuarioid,
                               UsuarioCargaNombre = us.NombrePila,
                               Anulado = re.re_anulado,
                               ReciboId = re.re_reciboid,
                               TimbradoId = re.re_timbradoid,
                               TieneAutorizacionVigente = this.DBContext.GetAutorizacionPorDocumentoID(DOCUMENTO_RECIBO_CLIENTE_ID,
                                                                                                       re.re_reciboid,
                                                                                                       this.UsuarioId)
                                                                                                      .FirstOrDefault().Value
                           })
                           .Where(a => timbrados.Contains(a.TimbradoId))
                           .OrderByDescending(a => a.ReciboId)
                           .Take(50);

            this.BindingSourceBase = recibos.ToList();

            #region Especificar campos para filtro
            this.SetFilter(CAMPO_RECIBOID, "Recibo Id", false);
            this.SetFilter(CAMPO_FECHARECIBO, "Fecha Recibo", false);
            this.SetFilter(CAMPO_NRORECIBO, "N° Recibo", false);
            this.SetFilter(CAMPO_TOTALRECIBO, "Total Recibo", false);
            this.SetFilter(CAMPO_CLIENTENOMBRE, "Nombre Cliente");
            this.SetFilter(CAMPO_MONEDADESCRIP, "Moneda Desc.");
            this.SetFilter(CAMPO_CONCEPTORECIBO, "Concepto");
            this.SetFilter(CAMPO_USUARIOCARGANOMBRE, "Usuario carga");
            this.TituloBuscador = "Buscar Recibos";
            #endregion Especificar campos para filtro

            #region Ocultar botones
            this.tbbBorrar.Visible = false;
            this.tbbGuardar.Visible = false;
            this.tbbNuevo.Visible = false;
            this.tbbCancelar.Visible = false;
            this.tbbEditar.Visible = false;
            this.tbbExportarExcel.Visible = false;
            #endregion Ocultar botones

            this.tbbImprimir.Visible = true;

            this.lblRetIVA10.Text = "Total Ret." + Environment.NewLine + "IVA 10%";
            this.lblRetRenta.Text = "Total Ret." + Environment.NewLine + "Renta";
            this.lblTotalGastosBancarios.Text = "Total Gastos" + Environment.NewLine + "Bancarios";
            this.lblTotalRecibo.Text = "Tot. Recibo";
            this.lblUsuarioCarga.Text = "Usuario" + Environment.NewLine + "Carga";
            this.lblEfectivo.Text = "Total" + Environment.NewLine + "Efectivo";
        }

        private void SetFormatoNumero(int monedaId)
        {
            this.formatoNumeroRecibo = new FormatoNumeroReciboType();

            if (monedaId == GUARANIES_MONEDA_ID)
            {
                this.FormatoNumeroRecibo.General = FORMATO_MONEDA_GUARANIES;
                this.FormatoNumeroRecibo.Grilla = FORMATO_MONEDA_GUARANIES_GRILLA;
            }
            else
            {
                this.FormatoNumeroRecibo.General = FORMATO_MONEDA_OTROS;
                this.FormatoNumeroRecibo.Grilla = FORMATO_MONEDA_OTROS_GRILLA;
            }
        }

        private void FormatearGrillaTransferencias()
        {
            this.dgvTransferencias.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Pixel);
            this.dgvTransferencias.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dgvTransferencias.DefaultCellStyle.Font = new Font("Arial", 10F, GraphicsUnit.Pixel);
            this.dgvTransferencias.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvTransferencias.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            this.dgvTransferencias.ItemsPerPage = 4;
            this.dgvTransferencias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransferencias.MultiSelect = false;
            //this.dgvTransferencias.AllowUserToAddRows = false;
            //this.dgvTransferencias.AllowUserToDeleteRows = true;
            //this.dgvTransferencias.AllowUserToResizeRows = true;
            //this.dgvTransferencias.AllowUserToOrderColumns = false;
            this.dgvTransferencias.RowHeadersWidth = 20;
            this.dgvTransferencias.ScrollBars = ScrollBars.None;
            this.dgvTransferencias.ReadOnly = true;

            foreach (DataGridViewColumn col in this.dgvTransferencias.Columns)
            {
                col.Visible = false;
                //col.ReadOnly = true;
            }

            int displayIndex = 0;
            
            DataGridViewTextBoxColumn fechaTransferencia = new DataGridViewTextBoxColumn();
            fechaTransferencia.Name = CAMPO_FECHA_TRANSFERENCIA;
            fechaTransferencia.DataPropertyName = CAMPO_FECHA_TRANSFERENCIA;
            fechaTransferencia.Visible = true;
            fechaTransferencia.DisplayIndex = displayIndex;
            fechaTransferencia.HeaderText = "Fecha";
            fechaTransferencia.DefaultCellStyle.Format = "dd/MM/yyyy";
            fechaTransferencia.Width = 70;
            this.dgvTransferencias.Columns.Add(fechaTransferencia);
            displayIndex++;

            DataGridViewTextBoxColumn cuentaTransferenciaId = new DataGridViewTextBoxColumn();
            cuentaTransferenciaId.Name = CAMPO_CUENTA_TRANSFERENCIA_ID;
            cuentaTransferenciaId.DataPropertyName = CAMPO_CUENTA_TRANSFERENCIA_ID;
            cuentaTransferenciaId.Visible = false;
            cuentaTransferenciaId.DisplayIndex = displayIndex;
            this.dgvTransferencias.Columns.Add(cuentaTransferenciaId);
            displayIndex++;

            DataGridViewTextBoxColumn bancoTransferencia = new DataGridViewTextBoxColumn();
            bancoTransferencia.Name = CAMPO_CUENTA_TRANSFERENCIA_DESCRIP;
            bancoTransferencia.DataPropertyName = CAMPO_CUENTA_TRANSFERENCIA_DESCRIP;
            bancoTransferencia.Visible = true;
            bancoTransferencia.DisplayIndex = displayIndex;
            bancoTransferencia.HeaderText = "Cuenta";
            bancoTransferencia.Width = 140;
            this.dgvTransferencias.Columns.Add(bancoTransferencia);
            displayIndex++;

            DataGridViewTextBoxColumn numeroTransferencia = new DataGridViewTextBoxColumn();
            numeroTransferencia.Name = CAMPO_NUMERO_TRANSFERENCIA;
            numeroTransferencia.DataPropertyName = CAMPO_NUMERO_TRANSFERENCIA;
            numeroTransferencia.Visible = true;
            numeroTransferencia.DisplayIndex = displayIndex;
            numeroTransferencia.HeaderText = "Número";
            numeroTransferencia.Width = 70;
            this.dgvTransferencias.Columns.Add(numeroTransferencia);
            displayIndex++;

            DataGridViewTextBoxColumn gastoBancario = new DataGridViewTextBoxColumn();
            gastoBancario.Name = CAMPO_MONTO_GASTO_BANCARIO;
            gastoBancario.DataPropertyName = CAMPO_MONTO_GASTO_BANCARIO;
            gastoBancario.Visible = true;
            gastoBancario.DisplayIndex = displayIndex;
            gastoBancario.HeaderText = "Gasto";
            gastoBancario.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gastoBancario.DefaultCellStyle.Format = this.FormatoNumeroRecibo.Grilla;
            gastoBancario.Width = 65;
            this.dgvTransferencias.Columns.Add(gastoBancario);
            displayIndex++;

            DataGridViewTextBoxColumn importeTransferencia = new DataGridViewTextBoxColumn();
            importeTransferencia.Name = CAMPO_MONTO_TRANSFERENCIA;
            importeTransferencia.DataPropertyName = CAMPO_MONTO_TRANSFERENCIA;
            importeTransferencia.Visible = true;
            importeTransferencia.DisplayIndex = displayIndex;
            importeTransferencia.HeaderText = "Monto";
            importeTransferencia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            importeTransferencia.DefaultCellStyle.Format = this.FormatoNumeroRecibo.Grilla;
            importeTransferencia.Width = 65;
            this.dgvTransferencias.Columns.Add(importeTransferencia);
            displayIndex++;
        }

        private void FormatearGrillaCheques()
        {
            this.dgvCheques.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Pixel);
            this.dgvCheques.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dgvCheques.DefaultCellStyle.Font = new Font("Arial", 10F, GraphicsUnit.Pixel);
            this.dgvCheques.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvCheques.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            this.dgvCheques.ItemsPerPage = 4;
            this.dgvCheques.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvCheques.MultiSelect = false;
            this.dgvCheques.AllowUserToAddRows = false;
            this.dgvCheques.AllowUserToDeleteRows = true;
            this.dgvCheques.AllowUserToResizeRows = true;
            this.dgvCheques.AllowUserToOrderColumns = false;
            this.dgvCheques.RowHeadersWidth = 20;
            this.dgvCheques.ScrollBars = ScrollBars.None;
            
            foreach (DataGridViewColumn col in this.dgvCheques.Columns)
            {
                col.Visible = false;
                //col.ReadOnly = true;
            }

            int displayIndex = 0;

            DataGridViewTextBoxColumn fechaCheque = new DataGridViewTextBoxColumn();
            fechaCheque.Name = CAMPO_FECHA_CHEQUE;
            fechaCheque.DataPropertyName = CAMPO_FECHA_CHEQUE;
            fechaCheque.Visible = true;
            fechaCheque.DisplayIndex = displayIndex;
            fechaCheque.HeaderText = "Fecha";
            fechaCheque.DefaultCellStyle.Format = "dd/MM/yyyy";
            fechaCheque.Width = 70;
            this.dgvCheques.Columns.Add(fechaCheque);
            displayIndex++;

            DataGridViewTextBoxColumn bancoCheque = new DataGridViewTextBoxColumn();
            bancoCheque.Name = CAMPO_BANCO_CHEQUE_DESCRIP;
            bancoCheque.DataPropertyName = CAMPO_BANCO_CHEQUE_DESCRIP;
            bancoCheque.Visible = true;
            bancoCheque.DisplayIndex = displayIndex;
            bancoCheque.HeaderText = "Banco";
            bancoCheque.Width = 160;
            this.dgvCheques.Columns.Add(bancoCheque);
            displayIndex++;

            DataGridViewTextBoxColumn numeroCheque = new DataGridViewTextBoxColumn();
            numeroCheque.Name = CAMPO_NUMERO_CHEQUE;
            numeroCheque.DataPropertyName = CAMPO_NUMERO_CHEQUE;
            numeroCheque.Visible = true;
            numeroCheque.DisplayIndex = displayIndex;
            numeroCheque.HeaderText = "Número";
            numeroCheque.Width = 70;
            this.dgvCheques.Columns.Add(numeroCheque);
            displayIndex++;

            DataGridViewTextBoxColumn importeCheque = new DataGridViewTextBoxColumn();
            importeCheque.Name = CAMPO_MONTO_CHEQUE;
            importeCheque.DataPropertyName = CAMPO_MONTO_CHEQUE;
            importeCheque.Visible = true;
            importeCheque.DisplayIndex = displayIndex;
            importeCheque.HeaderText = "Monto";
            importeCheque.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            importeCheque.DefaultCellStyle.Format = this.FormatoNumeroRecibo.Grilla;
            importeCheque.Width = 65;
            this.dgvCheques.Columns.Add(importeCheque);
            displayIndex++;
        }

        private void FormatearGrillaFacturas()
        {
            this.dgvFacturas.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Pixel);
            this.dgvFacturas.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dgvFacturas.DefaultCellStyle.Font = new Font("Arial", 10F, GraphicsUnit.Pixel);
            this.dgvFacturas.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvFacturas.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            this.dgvFacturas.ItemsPerPage = 15;
            this.dgvFacturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvFacturas.MultiSelect = false;
            this.dgvFacturas.AllowUserToAddRows = false;
            this.dgvFacturas.AllowUserToDeleteRows = true;
            this.dgvFacturas.AllowUserToResizeRows = true;
            this.dgvFacturas.AllowUserToOrderColumns = false;
            this.dgvFacturas.RowHeadersWidth = 20;
            this.dgvFacturas.ScrollBars = ScrollBars.None;
            this.dgvFacturas.ReadOnly = true;

            foreach (DataGridViewColumn col in this.dgvFacturas.Columns)
            {
                col.Visible = false;
            }

            int displayIndex = 0;

            DataGridViewTextBoxColumn ruc = new DataGridViewTextBoxColumn();
            ruc.Name = CAMPO_RUC;
            ruc.DataPropertyName = CAMPO_RUC;
            ruc.Visible = false;
            ruc.DisplayIndex = displayIndex;
            ruc.HeaderText = "RUC";
            ruc.Width = 120;
            this.dgvFacturas.Columns.Add(ruc);
            displayIndex++;

            DataGridViewTextBoxColumn numeroFactura = new DataGridViewTextBoxColumn();
            numeroFactura.Name = CAMPO_NROFACTURA;
            numeroFactura.DataPropertyName = CAMPO_NROFACTURA;
            numeroFactura.Visible = true;
            numeroFactura.DisplayIndex = displayIndex;
            numeroFactura.HeaderText = "Número Factura";
            numeroFactura.Width = 120;
            this.dgvFacturas.Columns.Add(numeroFactura);
            displayIndex++;

            DataGridViewTextBoxColumn fechaFactura = new DataGridViewTextBoxColumn();
            fechaFactura.Name = CAMPO_FECHAFACTURA;
            fechaFactura.DataPropertyName = CAMPO_FECHAFACTURA;
            fechaFactura.Visible = true;
            fechaFactura.DisplayIndex = displayIndex;
            fechaFactura.HeaderText = "Fecha Factura";
            fechaFactura.DefaultCellStyle.Format = "dd/MM/yyyy";
            fechaFactura.Width = 70;
            this.dgvFacturas.Columns.Add(fechaFactura);
            displayIndex++;

            DataGridViewTextBoxColumn totalFactura = new DataGridViewTextBoxColumn();
            totalFactura.Name = CAMPO_TOTALFACTURA;
            totalFactura.DataPropertyName = CAMPO_TOTALFACTURA;
            totalFactura.Visible = true;
            totalFactura.DisplayIndex = displayIndex;
            totalFactura.HeaderText = "Total Factura";
            totalFactura.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            totalFactura.DefaultCellStyle.Format = this.FormatoNumeroRecibo.Grilla;
            totalFactura.Width = 65;
            this.dgvFacturas.Columns.Add(totalFactura);
            displayIndex++;

            DataGridViewTextBoxColumn importeCobrado = new DataGridViewTextBoxColumn();
            importeCobrado.Name = CAMPO_MONTOPAGADOFACTURA;
            importeCobrado.DataPropertyName = CAMPO_MONTOPAGADOFACTURA;
            importeCobrado.Visible = true;
            importeCobrado.DisplayIndex = displayIndex;
            importeCobrado.HeaderText = "Importe Cobrado";
            importeCobrado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            importeCobrado.DefaultCellStyle.Format = this.FormatoNumeroRecibo.Grilla;
            importeCobrado.Width = 65;
            this.dgvFacturas.Columns.Add(importeCobrado);
            displayIndex++;

            DataGridViewTextBoxColumn numeroRetencion = new DataGridViewTextBoxColumn();
            numeroRetencion.Name = CAMPO_NUMERORETENCION;
            numeroRetencion.DataPropertyName = CAMPO_NUMERORETENCION;
            numeroRetencion.Visible = true;
            numeroRetencion.DisplayIndex = displayIndex;
            numeroRetencion.HeaderText = "Número Retención";
            numeroRetencion.Width = 90;
            this.dgvFacturas.Columns.Add(numeroRetencion);
            displayIndex++;

            DataGridViewTextBoxColumn fechaRetencion = new DataGridViewTextBoxColumn();
            fechaRetencion.Name = CAMPO_FECHARETENCION;
            fechaRetencion.DataPropertyName = CAMPO_FECHARETENCION;
            fechaRetencion.Visible = true;
            fechaRetencion.DisplayIndex = displayIndex;
            fechaRetencion.HeaderText = "Fecha Retención";
            fechaRetencion.DefaultCellStyle.Format = "dd/MM/yyyy";
            fechaRetencion.Width = 70;
            this.dgvFacturas.Columns.Add(fechaRetencion);
            displayIndex++;

            DataGridViewTextBoxColumn retencionIVA10 = new DataGridViewTextBoxColumn();
            retencionIVA10.Name = CAMPO_RETENCIONIVA10;
            retencionIVA10.DataPropertyName = CAMPO_RETENCIONIVA10;
            retencionIVA10.Visible = true;
            retencionIVA10.DisplayIndex = displayIndex;
            retencionIVA10.HeaderText = "Ret. IVA 10%";
            retencionIVA10.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            retencionIVA10.DefaultCellStyle.Format = this.FormatoNumeroRecibo.Grilla;
            retencionIVA10.Width = 65;
            this.dgvFacturas.Columns.Add(retencionIVA10);
            displayIndex++;

            DataGridViewTextBoxColumn retencionRenta = new DataGridViewTextBoxColumn();
            retencionRenta.Name = CAMPO_RETENCIONRENTA;
            retencionRenta.DataPropertyName = CAMPO_RETENCIONRENTA;
            retencionRenta.Visible = true;
            retencionRenta.DisplayIndex = displayIndex;
            retencionRenta.HeaderText = "Ret. Renta";
            retencionRenta.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            retencionRenta.DefaultCellStyle.Format = this.FormatoNumeroRecibo.Grilla;
            retencionRenta.Width = 65;
            this.dgvFacturas.Columns.Add(retencionRenta);
            displayIndex++;
        }

        private void FormatearGrillaDocAsoc()
        {
            this.dgvDocAsoc.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Pixel);
            this.dgvDocAsoc.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dgvDocAsoc.DefaultCellStyle.Font = new Font("Arial", 10F, GraphicsUnit.Pixel);
            this.dgvDocAsoc.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvDocAsoc.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            this.dgvDocAsoc.ItemsPerPage = 17;
            this.dgvDocAsoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocAsoc.MultiSelect = false;
            this.dgvDocAsoc.AllowUserToAddRows = false;
            this.dgvDocAsoc.AllowUserToDeleteRows = true;
            this.dgvDocAsoc.AllowUserToResizeRows = true;
            this.dgvDocAsoc.AllowUserToOrderColumns = false;
            this.dgvDocAsoc.RowHeadersWidth = 20;
            this.dgvDocAsoc.ScrollBars = ScrollBars.None;
            this.dgvDocAsoc.ReadOnly = true;

            foreach (DataGridViewColumn col in this.dgvDocAsoc.Columns)
            {
                col.Visible = false;
                //col.ReadOnly = true;
            }

            int displayIndex = 0;

            DataGridViewTextBoxColumn numeroDoc = new DataGridViewTextBoxColumn();
            numeroDoc.Name = CAMPO_NRODOCUMENTO;
            numeroDoc.DataPropertyName = CAMPO_NRODOCUMENTO;
            numeroDoc.Visible = true;
            numeroDoc.DisplayIndex = displayIndex;
            numeroDoc.HeaderText = "Documento N°";
            numeroDoc.Width = 120;
            this.dgvDocAsoc.Columns.Add(numeroDoc);
            displayIndex++;

            DataGridViewTextBoxColumn fechaDoc = new DataGridViewTextBoxColumn();
            fechaDoc.Name = CAMPO_FECHADOCUMENTO;
            fechaDoc.DataPropertyName = CAMPO_FECHADOCUMENTO;
            fechaDoc.Visible = true;
            fechaDoc.DisplayIndex = displayIndex;
            fechaDoc.HeaderText = "Fecha Doc.";
            fechaDoc.DefaultCellStyle.Format = "dd/MM/yyyy";
            fechaDoc.Width = 70;
            this.dgvDocAsoc.Columns.Add(fechaDoc);
            displayIndex++;

            DataGridViewTextBoxColumn serviciosDoc = new DataGridViewTextBoxColumn();
            serviciosDoc.Name = CAMPO_SERVICIOS;
            serviciosDoc.DataPropertyName = CAMPO_SERVICIOS;
            serviciosDoc.Visible = true;
            serviciosDoc.DisplayIndex = displayIndex;
            serviciosDoc.HeaderText = "Servicios";
            serviciosDoc.Width = 250;
            serviciosDoc.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvDocAsoc.Columns.Add(serviciosDoc);
            displayIndex++;

            DataGridViewTextBoxColumn totalDoc = new DataGridViewTextBoxColumn();
            totalDoc.Name = CAMPO_TOTALDOCUMENTO;
            totalDoc.DataPropertyName = CAMPO_TOTALDOCUMENTO;
            totalDoc.Visible = true;
            totalDoc.DisplayIndex = displayIndex;
            totalDoc.HeaderText = "Total Doc.";
            totalDoc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            totalDoc.DefaultCellStyle.Format = this.FormatoNumeroRecibo.Grilla;
            totalDoc.Width = 65;
            this.dgvDocAsoc.Columns.Add(totalDoc);
            displayIndex++;

            DataGridViewTextBoxColumn saldoDoc = new DataGridViewTextBoxColumn();
            saldoDoc.Name = CAMPO_SALDODOCUMENTO;
            saldoDoc.DataPropertyName = CAMPO_SALDODOCUMENTO;
            saldoDoc.Visible = true;
            saldoDoc.DisplayIndex = displayIndex;
            saldoDoc.HeaderText = "Saldo Doc.";
            saldoDoc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            saldoDoc.DefaultCellStyle.Format = this.FormatoNumeroRecibo.Grilla;
            saldoDoc.Width = 65;
            this.dgvDocAsoc.Columns.Add(saldoDoc);
            displayIndex++;

            DataGridViewTextBoxColumn tramiteDescrip = new DataGridViewTextBoxColumn();
            tramiteDescrip.Name = CAMPO_TRAMITEDESCRIP;
            tramiteDescrip.DataPropertyName = CAMPO_TRAMITEDESCRIP;
            tramiteDescrip.Visible = true;
            tramiteDescrip.DisplayIndex = displayIndex;
            tramiteDescrip.HeaderText = "Trámite";
            tramiteDescrip.Width = 120;
            this.dgvDocAsoc.Columns.Add(tramiteDescrip);
            displayIndex++;

            DataGridViewTextBoxColumn areaDescrip = new DataGridViewTextBoxColumn();
            areaDescrip.Name = CAMPO_AREADESCRIP;
            areaDescrip.DataPropertyName = CAMPO_AREADESCRIP;
            areaDescrip.Visible = true;
            areaDescrip.DisplayIndex = displayIndex;
            areaDescrip.HeaderText = "Área";
            areaDescrip.Width = 120;
            this.dgvDocAsoc.Columns.Add(areaDescrip);
            displayIndex++;
        }
        #endregion Métodos de Inicio

        #region Método Extendidos del ParentControl
        protected override void FilterEntity(string where = "", object[] filterParams = null)
        {
            try
            {
                this.limpiarDatos();

                var query = (from re in this.DBContext.re_recibo
                             join cl in this.DBContext.Cliente
                                 on re.re_clienteid equals cl.ID
                             join mo in this.DBContext.Moneda
                                 on re.re_monedaid equals mo.ID
                             join us in this.DBContext.Usuario
                                 on re.re_usuarioid equals us.ID
                             select new
                             {
                                 NroRecibo = re.re_numero,
                                 FechaRecibo = re.re_fecha,
                                 ClienteId = re.re_clienteid,
                                 ClienteNombre = cl.Nombre,
                                 MonedaId = re.re_monedaid,
                                 MonedaDescrip = mo.Descripcion,
                                 MonedaAbrev = mo.AbrevMoneda,
                                 TotalRecibo = re.re_totalrecibo,
                                 TotalNC = re.re_totalnc,
                                 TotalRetIVA10 = re.re_montoret10,
                                 TotalRetRenta = re.re_montoretrenta,
                                 TotalTransf = re.re_totaltransf,
                                 TotalGastos = re.re_totalgastos,
                                 TotalCheques = re.re_totalcheques,
                                 TotalEfectivo = re.re_totalefectivo,
                                 ConceptoRecibo = re.re_concepto,
                                 UsuarioCargaId = re.re_usuarioid,
                                 UsuarioCargaNombre = us.NombrePila,
                                 Anulado = re.re_anulado,
                                 ReciboId = re.re_reciboid,
                                 TimbradoId = re.re_timbradoid,
                                 TieneAutorizacionVigente = this.DBContext.GetAutorizacionPorDocumentoID(DOCUMENTO_RECIBO_CLIENTE_ID,
                                                                                                         re.re_reciboid,
                                                                                                         this.UsuarioId)
                                                                                                        .FirstOrDefault().Value
                             })
                             .Where(a => timbrados.Contains(a.TimbradoId));

                if (where != "")
                {
                    this.BindingSourceBase = query.Where(where, filterParams).OrderByDescending(a => a.ReciboId).ToList();
                }
                else
                {
                    this.BindingSourceBase = query.OrderByDescending(a => a.ReciboId).Take(50).ToList();
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

            this.dgvListadoABM.Columns[CAMPO_NRORECIBO].HeaderText = "Número";
            this.dgvListadoABM.Columns[CAMPO_NRORECIBO].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_NRORECIBO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_NRORECIBO].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_FECHARECIBO].HeaderText = "Fecha";
            this.dgvListadoABM.Columns[CAMPO_FECHARECIBO].Width = 100;
            this.dgvListadoABM.Columns[CAMPO_FECHARECIBO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_FECHARECIBO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_FECHARECIBO].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_CLIENTENOMBRE].HeaderText = "Cliente";
            this.dgvListadoABM.Columns[CAMPO_CLIENTENOMBRE].Width = 200;
            this.dgvListadoABM.Columns[CAMPO_CLIENTENOMBRE].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_CLIENTENOMBRE].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_MONEDAABREV].HeaderText = "Moneda";
            this.dgvListadoABM.Columns[CAMPO_MONEDAABREV].Width = 80;
            this.dgvListadoABM.Columns[CAMPO_MONEDAABREV].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_MONEDAABREV].Visible = true;
            displayIndex++;

            this.dgvListadoABM.Columns[CAMPO_TOTALRECIBO].HeaderText = "Total";
            this.dgvListadoABM.Columns[CAMPO_TOTALRECIBO].Width = 100;
            this.dgvListadoABM.Columns[CAMPO_TOTALRECIBO].DisplayIndex = displayIndex;
            this.dgvListadoABM.Columns[CAMPO_TOTALRECIBO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvListadoABM.Columns[CAMPO_TOTALRECIBO].Visible = true;
            displayIndex++;

            DataGridViewCheckBoxColumn colAnulado = new DataGridViewCheckBoxColumn();
            colAnulado.DataPropertyName = CAMPO_ANULADO;
            colAnulado.Name = CAMPO_ANULADO;
            colAnulado.HeaderText = "Anulado";
            colAnulado.FalseValue = false;
            colAnulado.TrueValue = true;
            colAnulado.ReadOnly = true;
            this.dgvListadoABM.Columns.Insert(displayIndex, colAnulado);
            displayIndex++;
        }

        protected override void tbbNuevo_Click(object sender, EventArgs e)
        {
            base.tbbNuevo_Click(sender, e);
            this.limpiarDatos();
        }

        protected override void tbbCancelar_Click(object sender, EventArgs e)
        {
            base.tbbCancelar_Click(sender, e);

            if (this.LastDGVIndex > -1)
            {
                this.CargarRecibo(this.dgvListadoABM.Rows[this.LastDGVIndex]);
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
            this.lblAutorizacionVigente.Visible = false;
        }
        #endregion Limpiar Datos

        #region ReadOnly condicional
        protected override void Editable(bool editar)
        {
        }
        #endregion ReadOnly condicional

        #region Métodos de Apoyo
        private void CargarRecibo(DataGridViewRow row)
        {
            this.limpiarDatos();
            int reciboid = Convert.ToInt32(row.Cells[CAMPO_RECIBOID].Value);
            int monedaid = Convert.ToInt32(row.Cells[CAMPO_MONEDAID].Value);
            string monedaabrev = row.Cells[CAMPO_MONEDAABREV].Value.ToString();

            //string formatoNumero = Convert.ToInt32(row.Cells[CAMPO_MONEDAID].Value) == GUARANIES_MONEDA_ID
            //                        ? FORMATO_MONEDA_GUARANIES
            //                        : FORMATO_MONEDA_OTROS;
            this.SetFormatoNumero(monedaid);

            this.txtReciboId.Text = row.Cells[CAMPO_RECIBOID].Value.ToString();
            this.txtNroRecibo.Text = row.Cells[CAMPO_NRORECIBO].Value.ToString();
            this.txtFechaRecibo.Text = Convert.ToDateTime(row.Cells[CAMPO_FECHARECIBO].Value).ToShortDateString();
            this.txtMoneda.Text = row.Cells[CAMPO_MONEDAABREV].Value.ToString();
            this.txtCliente.Text = row.Cells[CAMPO_CLIENTENOMBRE].Value.ToString() + 
                                    "(" +
                                    row.Cells[CAMPO_CLIENTEID].Value.ToString() +
                                    ")";
            this.txtTotalRecibo.Text = string.Format(this.FormatoNumeroRecibo.General, (decimal)row.Cells[CAMPO_TOTALRECIBO].Value);
            this.txtTotalNC.Text = string.Format(this.FormatoNumeroRecibo.General, (decimal)row.Cells[CAMPO_TOTALNC].Value);
            //this.txtTotalRetIVA10.Text = string.Format(this.FormatoNumeroRecibo.General, (decimal)row.Cells[CAMPO_TOTALRETIVA10].Value);
            //this.txtTotalRetRenta.Text = string.Format(this.FormatoNumeroRecibo.General, (decimal)row.Cells[CAMPO_TOTALRETRENTA].Value);
            this.txtConcepto.Text = row.Cells[CAMPO_CONCEPTORECIBO].Value.ToString();
            this.txtEstado.Text = !(bool)row.Cells[CAMPO_ANULADO].Value ? "Activo" : "Anulado";
            this.txtUsuarioCarga.Text = row.Cells[CAMPO_USUARIOCARGANOMBRE].Value.ToString();
            this.txtTotalTransferencias.Text = string.Format(this.FormatoNumeroRecibo.General, (decimal)row.Cells[CAMPO_TOTALTRANSF].Value);
            this.txtTotalGastosBancarios.Text = string.Format(this.FormatoNumeroRecibo.General, (decimal)row.Cells[CAMPO_TOTALGASTOS].Value);
            this.txtTotalCheques.Text = string.Format(this.FormatoNumeroRecibo.General, (decimal)row.Cells[CAMPO_TOTALCHEQUES].Value);
            this.txtTotalEfectivo.Text = string.Format(this.FormatoNumeroRecibo.General, (decimal)row.Cells[CAMPO_TOTALEFECTIVO].Value);
            this.txtTotalRetIVA10.Text = string.Format(this.FormatoNumeroRecibo.General, (decimal)row.Cells[CAMPO_TOTALRETIVA10].Value);
            this.txtTotalRetRenta.Text = string.Format(this.FormatoNumeroRecibo.General, (decimal)row.Cells[CAMPO_TOTALRETRENTA].Value);
            this.lblAutorizacionVigente.Visible = (bool)row.Cells[CAMPO_AUTORIZACIONVIG].Value;

            #region Datos Transferencias
            this.dgvTransferencias.DataSource = this.GetTransferencias(reciboid, monedaid, monedaabrev);
            this.dgvTransferencias.AutoGenerateColumns = false;
            this.FormatearGrillaTransferencias();
            #endregion Datos Transferencias

            #region Datos Cheques
            this.dgvCheques.AutoGenerateColumns = false;
            this.dgvCheques.DataSource = this.GetCheques(reciboid, monedaid, monedaabrev);
            this.FormatearGrillaCheques();
            #endregion Datos Cheques

            #region Datos Facturas
            this.dgvFacturas.AutoGenerateColumns = true;
            this.dgvFacturas.DataSource = this.GetFacturas(reciboid);
            this.FormatearGrillaFacturas();
            #endregion Datos Facturas

            #region Datos Documentos Asociados
            this.dgvDocAsoc.AutoGenerateColumns = false;
            this.dgvDocAsoc.DataSource = this.GetDocumentosAsoc(reciboid);
            this.FormatearGrillaDocAsoc();
            #endregion Datos Documentos Asociados

            //this.tbbImprimir.Visible = this.txtEstado.Text != CAMPO_ANULADO;
        }

        private List<DocumentosAsociadosType> GetDocumentosAsoc(int reciboid)
        {
            List<DocumentosAsociadosType> lista = (from pp in this.DBContext.pp_pagopresupuesto
                                                   join pc in this.DBContext.pc_presupuestocab
                                                    on pp.pp_presupuestocabid equals pc.pc_presupuestocabid
                                                   join tr in this.DBContext.Tramite
                                                    on pc.pc_tramiteid equals tr.ID
                                                   join ac in this.DBContext.ac_areacontabilidad
                                                    on pc.pc_areaid equals ac.ac_areacontabilidadid
                                                   select new DocumentosAsociadosType
                                                   {
                                                       NroDocumento = this.DBContext.GetDocumentoNro(pc.pc_presupuestocabid).FirstOrDefault(),
                                                       FechaDocumento = this.DBContext.GetFechaDocumento(pc.pc_presupuestocabid).FirstOrDefault(),
                                                       Servicios = pc.pc_descripcion,
                                                       TotalDocumento = pc.pc_total,
                                                       SaldoDocumento = pc.pc_saldo,
                                                       TramiteDescrip = tr.Descrip,
                                                       AreaDescrip = ac.ac_descripcionarea,
                                                       ReciboId = pp.pp_reciboid
                                                   })
                                                   .Where(a => a.ReciboId == reciboid)
                                                   .ToList();

            return lista;
        }

        private List<FacturaRetencionConsultaType> GetFacturas(int reciboid)
        {
            List<FacturaRetencionConsultaType> listaFE = (from rf in this.DBContext.rf_recibofactura
                                                          join fc in this.DBContext.fc_facturacabecera
                                                              on rf.rf_facturacabid equals fc.fc_facturacabeceraid
                                                          join rr in this.DBContext.rr_reciboretencion
                                                              on rf.rf_facturacabid equals rr.rr_facturaid into rrGroup
                                                          from rr in rrGroup.DefaultIfEmpty()
                                                          select new FacturaRetencionConsultaType
                                                          {
                                                              NroFactura = fc.fc_nrofactura,
                                                              FechaFactura = fc.fc_fechafactura,
                                                              TotalFactura = fc.fc_total,
                                                              MontoPagadoFactura = rf.rf_montopagado,
                                                              NumeroRetencion = rr.rr_numero,
                                                              FechaRetencion = rr.rr_fecharetencion,
                                                              MontoRetencionIVA10 = rr.rr_montoretencioniva10,
                                                              MontoRetencionRenta = rr.rr_montoretencionrenta,
                                                              ReciboId = rf.rf_reciboid,
                                                              RUC = fc.fc_ruc
                                                          })
              .Where(a => a.ReciboId == reciboid && a.MontoPagadoFactura > 0)
              .Distinct()
              .ToList();

            List<FacturaRetencionConsultaType> listaNCE = (from re in this.DBContext.re_recibo
                                                          join rf in this.DBContext.rf_recibofactura
                                                              on re.re_reciboid equals rf.rf_reciboid
                                                          join nc in this.DBContext.nc_notacreditocabecera
                                                              on rf.rf_facturacabid equals nc.nc_notacreditocabeceraid
                                                          select new FacturaRetencionConsultaType
                                                          {
                                                              NroFactura = nc.nc_nronotacredito,
                                                              FechaFactura = nc.nc_fechanotacredito,
                                                              TotalFactura = nc.nc_total,
                                                              MontoPagadoFactura = 0,
                                                              ReciboId = re.re_reciboid,
                                                              RUC = nc.nc_ruc
                                                          })
              .Where(a => a.ReciboId == reciboid && a.MontoPagadoFactura > 0)
              .Distinct()
              .ToList();
            return listaFE.Union(listaNCE).Distinct().ToList();
        }

        private List<DatosTransferenciaReciboType> GetTransferencias(int reciboid, int monedaid, string monedaabrev)
        {
            List<DatosTransferenciaReciboType> lista = (from rt in this.DBContext.rt_recibotransf
                                                        join cb in this.DBContext.cb_cuentabanco
                                                            on rt.rt_cuentabancoid equals cb.cb_cuentabancoid
                                                        join ba in this.DBContext.ba_banco
                                                            on cb.cb_bancoid equals ba.ba_bancoid
                                                        where rt.rt_reciboid == reciboid
                                                        select new
                                                        {
                                                            FechaTransferencia = rt.rt_fechatransf,
                                                            BancoTransferenciaId = rt.rt_cuentabancoid,
                                                            BancoTransferenciaDescrip = cb.cb_descripcion,
                                                            NumeroTransferencia = rt.rt_numero,
                                                            MontoGastoBancario = rt.rt_montogasto,
                                                            MontoTransferencia = rt.rt_montotransf,
                                                            MonedaTransferenciaId = monedaid,
                                                            MonedaTransferenciaAbrev = monedaabrev,
                                                            PaisId = ba.ba_paisid,
                                                            ReciboId = rt.rt_reciboid
                                                        })
                                             .ToList()
                                             .Select(a => new DatosTransferenciaReciboType
                                             {
                                                 FechaTransferencia = a.FechaTransferencia.ToString("d"),
                                                 BancoTransferenciaId = a.BancoTransferenciaId,
                                                 BancoTransferenciaDescrip = a.BancoTransferenciaDescrip,
                                                 NumeroTransferencia = a.NumeroTransferencia,
                                                 MontoGastoBancario = a.MontoGastoBancario,
                                                 MontoTransferencia = a.MontoTransferencia,
                                                 MonedaTransferenciaId = a.MonedaTransferenciaId,
                                                 MonedaTransferenciaAbrev = a.MonedaTransferenciaAbrev,
                                                 PaisId = a.PaisId,
                                                 ReciboId = a.ReciboId
                                             }).ToList();

            return lista;
        }

        private List<DatosChequeReciboType> GetCheques(int reciboid, int monedaid, string monedaabrev)
        {
            List<DatosChequeReciboType> lista = (from rch in this.DBContext.rch_recibocheque
                                                 join ba in this.DBContext.ba_banco
                                                     on rch.rch_bancoid equals ba.ba_bancoid
                                                 where rch.rch_reciboid == reciboid
                                                 select new
                                                 {
                                                     FechaCheque = rch.rch_fechacheque,
                                                     BancoChequeId = rch.rch_bancoid,
                                                     BancoChequeDescrip = ba.ba_descripcion,
                                                     NumeroCheque = rch.rch_numero,
                                                     MontoCheque = rch.rch_monto,
                                                     MonedaChequeId = monedaid,
                                                     MonedaChequeAbrev = monedaabrev,
                                                     ReciboId = rch.rch_reciboid
                                                 })
                                      .ToList()
                                      .Select(a => new DatosChequeReciboType
                                      {
                                          FechaCheque = a.FechaCheque.ToString("d"),
                                          BancoChequeId = a.BancoChequeId,
                                          BancoChequeDescrip = a.BancoChequeDescrip,
                                          NumeroCheque = a.NumeroCheque,
                                          MontoCheque = a.MontoCheque,
                                          MonedaChequeId = a.MonedaChequeId,
                                          MonedaChequeAbrev = a.MonedaChequeAbrev,
                                          ReciboId = a.ReciboId
                                      }).ToList();


            return lista;
        }

        private string GetRucFromFacturas()
        {
            string ruc = string.Empty;

            if (this.dgvFacturas.Rows[0].Cells[CAMPO_RUC].Value != null)
            {
                ruc = this.dgvFacturas.Rows[0].Cells[CAMPO_RUC].Value.ToString();
            }
            else
            {
                for (int i = 1; i < this.dgvFacturas.RowCount; i++)
                {
                    if (this.dgvFacturas.Rows[i].Cells[CAMPO_RUC].Value != null)
                    {
                        ruc = this.dgvFacturas.Rows[i].Cells[CAMPO_RUC].Value.ToString();
                        break;
                    }
                }
            }

            return ruc;
        }
        #endregion Métodos de Apoyo

        #region Métodos locales sobre controles
        private void ucCRUDBancos_VisibleChanged(object sender, EventArgs e)
        {
            if (this.tabListaABM.SelectedIndex == 0)
                this.FormatearGrilla();
        }

        private void dgvListadoABM_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (this.LastDGVIndex > -1)
            //    this.CargarRecibo(this.dgvListadoABM.Rows[this.LastDGVIndex]);
            if (e.RowIndex > -1)
                this.CargarRecibo(this.dgvListadoABM.Rows[e.RowIndex]);
        }

        private void dgvListadoABM_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.RowIndex > -1) && (e.ColumnIndex > -1))
            {
                //if (this.dgvListadoABM.Columns[e.ColumnIndex].Name == CAMPO_TOTALRECIBO)
                //{
                //    if ((int)this.dgvListadoABM.Rows[e.RowIndex].Cells[CAMPO_MONEDAID].Value == GUARANIES_MONEDA_ID)
                //        this.dgvListadoABM.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Format = FORMATO_MONEDA_GUARANIES_GRILLA;
                //    else this.dgvListadoABM.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Format = FORMATO_MONEDA_OTROS_GRILLA;
                //}

                if (this.dgvListadoABM.Columns[e.ColumnIndex].Name == CAMPO_TOTALRECIBO)
                {
                    int monedaId = (int)this.dgvListadoABM.Rows[e.RowIndex].Cells[CAMPO_MONEDAID].Value;

                    switch (monedaId)
                    {
                        case GUARANIES_MONEDA_ID:
                            e.Value = string.Format(FORMATO_MONEDA_GUARANIES, e.Value);
                            e.FormattingApplied = true;
                            break;
                        default:
                            e.Value = string.Format(FORMATO_MONEDA_OTROS, e.Value);
                            e.FormattingApplied = true;
                            break;
                    }
                }
            }
        }
        #endregion Métodos locales sobre controles

        private void tbbAnular_Click(object sender, EventArgs e)
        {
            if (!this.lblAutorizacionVigente.Visible)
            {
                MessageBox.Show("No se puede anular el recibo debido a que no posee autorización vigente.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;

            }

            if (this.txtEstado.Text == CAMPO_ANULADO)
            {
                MessageBox.Show("No se puede anular el recibo debido a que ya se encuentra en ese estado.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            string message = "";
            string caption = "";
            caption = "Anulación de Recibo";
            message = "Se anulará el recibo actual ¿Desea continuar?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(AnularDialogHandler));
        }

        private void AnularDialogHandler(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    this.AnularPago(Convert.ToInt32(this.txtReciboId.Text));
                }
            }
        }

        private void AnularPago(int reciboId)
        {
            bool success = false;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        List<pp_pagopresupuesto> listPP = context.pp_pagopresupuesto.Where(a => a.pp_reciboid == reciboId).ToList();

                        foreach (pp_pagopresupuesto pp in listPP)
                        {
                            pp_pagopresupuesto pPag = context.pp_pagopresupuesto.First(a => a.pp_pagopresupuestoid == pp.pp_pagopresupuestoid);
                            pPag.pp_anulado = true;

                            pc_presupuestocab pCab = context.pc_presupuestocab.First(a => a.pc_presupuestocabid == pp.pp_presupuestocabid);
                            pCab.pc_saldo += pPag.pp_montopago;
                            pCab.pc_estado = ESTADO_PENDIENTE;
                        }

                        re_recibo re = context.re_recibo.First(a => a.re_reciboid == reciboId);
                        re.re_anulado = true;
                        re.re_fechaanulacion = DateTime.Now;
                        re.re_usuarioanulacion = VWGContext.Current.Session["WindowsUser"].ToString();

                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        MessageBox.Show("Ocurrió un error al anular el recibo. "
                                        + ex.Message + Environment.NewLine
                                        + ex.InnerException,
                                        "Error al anular",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Stop);
                    }
                }
            }
            if (success)
            {
                //this.txtEstado.Text = "Anulado";
                this.FilterEntity(this.WhereString, this.FilterParam);
                this.CargarRecibo(this.dgvListadoABM.Rows[this.LastDGVIndex]);
                MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvDocAsoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                if ((this.dgvDocAsoc.Columns[e.ColumnIndex].Name == CAMPO_SERVICIOS))
                {
                    this.dgvDocAsoc.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = this.dgvDocAsoc.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
            }
        }

        #region Imprimir recibo
        private void GenerarReporte(bool imprimirReciboSimple = false)
        {
            string numeroRecibo = this.txtNroRecibo.Text;
            string pdfName = numeroRecibo + ".pdf";
            this.OpenPdfInBrowser(this.GenerarPDF(imprimirReciboSimple), pdfName);
        }

        private byte[] GenerarPDF(bool imprimirReciboSimple)
        {
            string reportPath = @"Reportes\Recibo de Dinero.rdlc";

            LocalReport report = new LocalReport();
            report.ReportPath = reportPath;

            report.DataSources.Add(new ReportDataSource("DataSet1", this.GetFacturasParaRecibo()));
            report.DataSources.Add(new ReportDataSource("DataSet2", this.GetRetencionesParaRecibo()));
            report.DataSources.Add(new ReportDataSource("DataSet3", this.GetDatosRecibo(imprimirReciboSimple)));
            report.DataSources.Add(new ReportDataSource("DataSet4", this.GetDatosTransferenciaReciboReporte()));
            report.DataSources.Add(new ReportDataSource("DataSet5", this.GetDatosChequeReciboReporte()));

            byte[] bytes;
            string mimeType, encoding, fileNameExtension;
            string[] streamIds;
            Warning[] warnings;

            // Renderizar el reporte
            bytes = report.Render(
                "PDF", null, out mimeType, out encoding, out fileNameExtension,
                out streamIds, out warnings);

            return bytes;
        }

        public void OpenPdfInBrowser(byte[] pdfBytes, string fileName)
        {
            string path = VWGContext.Current.Server.MapPath(@"\" +
                                                            Context.HttpContext.Request.ApplicationPath +
                                                            @"\Resources\UserData\" +
                                                            VWGContext.Current.Session["WindowsUser"].ToString() +
                                                            @"\Recibos\");
            Directory.CreateDirectory(path);
            string tempFilePath = path + fileName;

            File.WriteAllBytes(tempFilePath, pdfBytes);

            string pdfUrl = @"http://" +
                            Context.HttpContext.Request.Url.Authority +
                            @"/sistema/Resources/UserData/" +
                            VWGContext.Current.Session["WindowsUser"].ToString().Replace('\\', '/') +
                            @"/Recibos/" + fileName;

            bool isTestMode = (bool)VWGContext.Current.Session["TestMode"];
            if (isTestMode)
            {
                pdfUrl = @"http://" +
                         Context.HttpContext.Request.Url.Authority +
                         @"/Resources/UserData/" +
                         VWGContext.Current.Session["WindowsUser"].ToString().Replace('\\', '/') +
                         @"/Recibos/" + fileName;
            }

            LinkParameters linkParameters = new LinkParameters();
            linkParameters.Target = "_blank";

            Link.Open(pdfUrl, linkParameters);
        }

        public void _OpenPdfInBrowser(byte[] pdfBytes, string fileName)
        {
            string specialpath = Context.HttpContext.Request.Url.Authority.IndexOf(LOCALHOST) > -1 ? String.Empty : @"\" + Context.HttpContext.Request.ApplicationPath;
            string directoryPath = VWGContext.Current.Server.MapPath(specialpath +
                                                            @"\Resources\UserData\" + VWGContext.Current.Session["WindowsUser"].ToString() + @"\");
            Directory.CreateDirectory(directoryPath);
            string tempFilePath = directoryPath + fileName;

            File.WriteAllBytes(tempFilePath, pdfBytes);
            string pdfUrl = @"http://" + Context.HttpContext.Request.Url.Authority + @"/sistema/Resources/UserData/" + VWGContext.Current.Session["WindowsUser"].ToString() + @"/" + fileName;

            bool isTestMode = (bool)VWGContext.Current.Session["TestMode"];

            if (isTestMode)
            {
                pdfUrl = @"http://" + Context.HttpContext.Request.Url.Authority + @"/Resources/UserData/" + VWGContext.Current.Session["WindowsUser"].ToString() + @"/" + fileName;
            }

            LinkParameters linkParameters = new LinkParameters();
            linkParameters.Target = "_blank";

            Link.Open(pdfUrl, linkParameters);
        }

        private List<ReciboFacturasType> GetFacturasParaRecibo()
        {
            List<ReciboFacturasType> reciboFacturas = new List<ReciboFacturasType>();

            
            for(int i = 0; i < LIMITE_FACTURAS_POR_RECIBO; i++)
            {
                if (i < this.dgvFacturas.RowCount)
                {
                    reciboFacturas.Add(new ReciboFacturasType()
                    {
                        ID = i + 1,
                        NroFactura = this.dgvFacturas.Rows[i].Cells[CAMPO_NROFACTURA].Value.ToString(),
                        Importe = string.Format(this.FormatoNumeroRecibo.General, (decimal)this.dgvFacturas.Rows[i].Cells[CAMPO_MONTOPAGADOFACTURA].Value)
                    });
                }
                else
                {
                    reciboFacturas.Add(new ReciboFacturasType()
                    {
                        ID = i + 1,
                        NroFactura = "--",
                        Importe = "--"
                    });
                }
            }
            return reciboFacturas;
        }

        private List<ReciboRetencionesType> GetRetencionesParaRecibo()
        {
            List<ReciboRetencionesType> reciboRetenciones = new List<ReciboRetencionesType>();

            decimal totalRetenciones = Convert.ToDecimal(this.txtTotalRetIVA10.Text) + Convert.ToDecimal(this.txtTotalRetRenta.Text);

            reciboRetenciones.Add(new ReciboRetencionesType()
            {
                ImporteRetencion = totalRetenciones > 0
                                    ? string.Format(this.FormatoNumeroRecibo.General, totalRetenciones)
                                    : "--"
            });

            return reciboRetenciones;
        }

        private List<DatosTransfenciaReciboReporte> GetDatosTransferenciaReciboReporte()
        {
            List<DatosTransfenciaReciboReporte> data = new List<DatosTransfenciaReciboReporte>();

            int c = 1;
            foreach (DataGridViewRow row in this.dgvTransferencias.Rows)
            {
                if ((int)row.Cells[CAMPO_CUENTA_TRANSFERENCIA_PAIS_ID].Value == PAIS_PARAGUAY_ID)
                {
                    DatosTransfenciaReciboReporte transf = new DatosTransfenciaReciboReporte();
                    transf.ID = c;
                    transf.FechaTransferencia = row.Cells[CAMPO_FECHA_TRANSFERENCIA].Value.ToString();
                    transf.BancoTransferencia = row.Cells[CAMPO_CUENTA_TRANSFERENCIA_DESCRIP].Value.ToString();
                    transf.NroTransferencia = row.Cells[CAMPO_NUMERO_TRANSFERENCIA].Value.ToString();
                    transf.MontoTransferencia = string.Format(this.FormatoNumeroRecibo.General, (decimal)row.Cells[CAMPO_MONTO_TRANSFERENCIA].Value); //string.Format(this.FormatoNumeroRecibo.General, totalTransferencia);
                    data.Add(transf);
                    c++;
                }
            }
            return data;
        }

        private List<DatosChequeReciboReporte> GetDatosChequeReciboReporte()
        {
            List<DatosChequeReciboReporte> data = new List<DatosChequeReciboReporte>();

            int c = 1;
            foreach (DataGridViewRow row in this.dgvCheques.Rows)
            {
                DatosChequeReciboReporte cheq = new DatosChequeReciboReporte();
                cheq.ID = c;
                cheq.FechaCheque = row.Cells[CAMPO_FECHA_CHEQUE].Value.ToString();
                cheq.CargoBancoCheque = row.Cells[CAMPO_BANCO_CHEQUE_DESCRIP].Value.ToString();
                cheq.NroCheque = row.Cells[CAMPO_NUMERO_CHEQUE].Value.ToString();
                cheq.MontoCheque = string.Format(this.FormatoNumeroRecibo.General, (decimal)row.Cells[CAMPO_MONTO_CHEQUE].Value);
                data.Add(cheq);
                c++;
            }
            return data;
        }

        private List<DatosReciboType> GetDatosRecibo(bool imprimirReciboSimple)
        {
            DatosReciboType datosRecibo = new DatosReciboType();
            datosRecibo.AbrevMoneda = this.dgvListadoABM.CurrentRow.Cells[CAMPO_MONEDAABREV].Value.ToString();
            datosRecibo.TotalRecibo = this.txtTotalRecibo.Text;
            datosRecibo.ClienteNombre = this.dgvListadoABM.CurrentRow.Cells[CAMPO_CLIENTENOMBRE].Value.ToString();
            datosRecibo.RUC = this.GetRucFromFacturas();
            datosRecibo.NroRecibo = this.txtNroRecibo.Text;

            string descripMoneda = string.Empty;

            int monedaId = Convert.ToInt32(this.dgvListadoABM.CurrentRow.Cells[CAMPO_MONEDAID].Value.ToString());
            switch (monedaId)
            {
                case DOLARES_MONEDA_ID:
                    descripMoneda = DOLARES_TEXTO;
                    break;
                case GUARANIES_MONEDA_ID:
                    descripMoneda = GUARANIES_TEXTO;
                    break;
                default:
                    descripMoneda = this.dgvListadoABM.CurrentRow.Cells[CAMPO_MONEDADESCRIP].Value.ToString();
                    break;
            }

            datosRecibo.DescripMoneda = descripMoneda;
            datosRecibo.TotalLetras = Utils.TruncarTexto(descripMoneda + " " + Utils.ObtenerTotalEnLetras(IDIOMA_ESPANOL,
                                                                                                        monedaId,
                                                                                                        this.txtTotalRecibo.Text,
                                                                                                        descripMoneda,
                                                                                                        false), 47)
                                                                                                        .Replace(descripMoneda, string.Empty)
                                                                                                        .TrimStart()
                                                                                                        .TrimEnd();

            datosRecibo.Concepto = Utils.TruncarTexto(this.txtConcepto.Text.ToUpper(), 45).TrimStart().TrimEnd();
            datosRecibo.Efectivo = Convert.ToDecimal(this.txtTotalEfectivo.Text) > 0 ? this.txtTotalEfectivo.Text : string.Empty;
            datosRecibo.Cheque = Convert.ToDecimal(this.txtTotalCheques.Text) > 0;
            datosRecibo.FechaRecibo = this.txtFechaRecibo.Text;
            datosRecibo.ElaboradoPor = this.txtUsuarioCarga.Text;
            datosRecibo.ImprimirReciboSimple = imprimirReciboSimple;
            datosRecibo.Anulado = this.txtEstado.Text == CAMPO_ANULADO;
            List<DatosReciboType> result = new List<DatosReciboType>();
            result.Add(datosRecibo);

            return result;
        }
        #endregion Imprimir recibo

        private void tbbImprimir_Click_1(object sender, EventArgs e)
        {
            string message = "";
            string caption = "";
            caption = "Impresión de Recibo";
            message = "¿Desea imprimir el recibo en el formato de dos copias por página?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(ImprimirDialogHandler));
            //this.GenerarReporte();
        }

        private void ImprimirDialogHandler(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                this.GenerarReporte(!(msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes));
                //if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                //{
                //    this.GenerarReporte(false);
                //}
            }
        }
    }
}