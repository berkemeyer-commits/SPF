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
using SPF.Forms;
using SPF.Types;
using System.Data.Entity;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Dynamic;

using System.Data.SqlClient;
using System.Collections;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text.RegularExpressions;

using SPF.Forms.Base;
using SPF.Base;
using Microsoft.Reporting.WebForms;

#endregion

namespace SPF.Forms.UI
{
    public partial class FSolicitudesPendientes : Form
    {
        #region Constantes
        private const string CAMPO_SOLICITUDPAGOCABID = "SolicitudPagoCabID";
        private const string CAMPO_FECHASOLICITUD = "FechaSolicitud";
        private const string CAMPO_EXPEDIENTEID = "ExpedienteID";
        private const string CAMPO_ACTA = "Acta";
        private const string CAMPO_ORDENTRABAJOID = "OrdenTrabajoID";
        private const string CAMPO_HI = "HI";
        private const string CAMPO_TRAMITEID = "TramiteID";
        private const string CAMPO_TRAMITEDESCRIP = "TramiteDescrip";
        private const string CAMPO_TARIFAID = "TarifaID";
        private const string CAMPO_TARIFADESCRIP = "TarifaDescrip";
        private const string CAMPO_CANTIDAD = "Cantidad";
        private const string CAMPO_REFCLIENTE = "RefCliente";
        private const string CAMPO_OBSERVACION = "Observacion";
        private const string CAMPO_TIPOASOCIACION = "TipoAsociacion";
        private const string INFO = "Las siguientes solicitudes de servicios se encuentran registradas en el sistema.{0}" +
                                    "Están asignadas al cliente {1} ({2}), pero no han sido asociadas a ningún presupuesto.{3}" +
                                    "Favor verifíquelas.";
        #endregion Constantes

        #region Métodos de Inicio
        public FSolicitudesPendientes()
        {
            InitializeComponent();
        }

        public FSolicitudesPendientes(int clienteID, string clienteNombre, List<GetSolicitudesXCliente_Result> listaSolicitudes)
        {
            InitializeComponent();

            this.Text = String.Format("Solicitudes Pendientes de Facturación - {0} ({1})", clienteNombre, clienteID.ToString());
            this.txtInfo.Text = String.Format(INFO, Environment.NewLine, clienteNombre, clienteID.ToString(), Environment.NewLine);

            this.dgvSolicitudes.DataSource = listaSolicitudes.OrderBy( a => a.FechaSolicitud).ToList();
            this.FormatearGrilla();
        }

        private void FSolicitudesPendientes_Load(object sender, EventArgs e)
        {
            if (this.dgvSolicitudes.Rows.Count > 0)
            {
                this.FormatearGrilla();
                this.dgvSolicitudes.CurrentCell = this.dgvSolicitudes.Rows[0].Cells[CAMPO_SOLICITUDPAGOCABID];
                this.dgvSolicitudes.Focus();
            }
        }
        #endregion Métodos de Inicio

        #region Métodos de Apoyo
        private void FormatearGrilla()
        {
            this.dgvSolicitudes.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvSolicitudes.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dgvSolicitudes.DefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvSolicitudes.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvSolicitudes.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            this.dgvSolicitudes.ItemsPerPage = 10;
            this.dgvSolicitudes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvSolicitudes.MultiSelect = false;

            foreach (DataGridViewColumn col in this.dgvSolicitudes.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            int displayIndex = 0;

            this.dgvSolicitudes.Columns[CAMPO_SOLICITUDPAGOCABID].Visible = true;
            this.dgvSolicitudes.Columns[CAMPO_SOLICITUDPAGOCABID].DisplayIndex = displayIndex;
            this.dgvSolicitudes.Columns[CAMPO_SOLICITUDPAGOCABID].HeaderText = "Solic. ID";
            this.dgvSolicitudes.Columns[CAMPO_SOLICITUDPAGOCABID].Width = 70;
            this.dgvSolicitudes.Columns[CAMPO_SOLICITUDPAGOCABID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            displayIndex++;

            this.dgvSolicitudes.Columns[CAMPO_FECHASOLICITUD].Visible = true;
            this.dgvSolicitudes.Columns[CAMPO_FECHASOLICITUD].DisplayIndex = displayIndex;
            this.dgvSolicitudes.Columns[CAMPO_FECHASOLICITUD].HeaderText = "Fec. Solic.";
            this.dgvSolicitudes.Columns[CAMPO_FECHASOLICITUD].Width = 70;
            displayIndex++;

            this.dgvSolicitudes.Columns[CAMPO_TRAMITEDESCRIP].Visible = true;
            this.dgvSolicitudes.Columns[CAMPO_TRAMITEDESCRIP].DisplayIndex = displayIndex;
            this.dgvSolicitudes.Columns[CAMPO_TRAMITEDESCRIP].HeaderText = "Trámite";
            this.dgvSolicitudes.Columns[CAMPO_TRAMITEDESCRIP].Width = 120;
            displayIndex++;

            this.dgvSolicitudes.Columns[CAMPO_TARIFADESCRIP].Visible = true;
            this.dgvSolicitudes.Columns[CAMPO_TARIFADESCRIP].DisplayIndex = displayIndex;
            this.dgvSolicitudes.Columns[CAMPO_TARIFADESCRIP].HeaderText = "Tarifa";
            this.dgvSolicitudes.Columns[CAMPO_TARIFADESCRIP].Width = 120;
            displayIndex++;

            this.dgvSolicitudes.Columns[CAMPO_CANTIDAD].Visible = true;
            this.dgvSolicitudes.Columns[CAMPO_CANTIDAD].DisplayIndex = displayIndex;
            this.dgvSolicitudes.Columns[CAMPO_CANTIDAD].HeaderText = "Cantidad";
            this.dgvSolicitudes.Columns[CAMPO_CANTIDAD].Width = 70;
            this.dgvSolicitudes.Columns[CAMPO_CANTIDAD].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvSolicitudes.Columns[CAMPO_CANTIDAD].DefaultCellStyle.Format = "N2";
            displayIndex++;

            this.dgvSolicitudes.Columns[CAMPO_ACTA].Visible = true;
            this.dgvSolicitudes.Columns[CAMPO_ACTA].DisplayIndex = displayIndex;
            this.dgvSolicitudes.Columns[CAMPO_ACTA].HeaderText = "Acta";
            this.dgvSolicitudes.Columns[CAMPO_ACTA].Width = 70;
            displayIndex++;

            this.dgvSolicitudes.Columns[CAMPO_REFCLIENTE].Visible = true;
            this.dgvSolicitudes.Columns[CAMPO_REFCLIENTE].DisplayIndex = displayIndex;
            this.dgvSolicitudes.Columns[CAMPO_REFCLIENTE].HeaderText = "Ref. Cliente";
            this.dgvSolicitudes.Columns[CAMPO_REFCLIENTE].Width = 120;
            displayIndex++;

            this.dgvSolicitudes.Columns[CAMPO_OBSERVACION].Visible = true;
            this.dgvSolicitudes.Columns[CAMPO_OBSERVACION].DisplayIndex = displayIndex;
            this.dgvSolicitudes.Columns[CAMPO_OBSERVACION].HeaderText = "Observacion";
            this.dgvSolicitudes.Columns[CAMPO_OBSERVACION].Width = 120;
            displayIndex++;

            this.dgvSolicitudes.Columns[CAMPO_EXPEDIENTEID].Visible = true;
            this.dgvSolicitudes.Columns[CAMPO_EXPEDIENTEID].DisplayIndex = displayIndex;
            this.dgvSolicitudes.Columns[CAMPO_EXPEDIENTEID].HeaderText = "Exp. ID";
            this.dgvSolicitudes.Columns[CAMPO_EXPEDIENTEID].Width = 70;
            this.dgvSolicitudes.Columns[CAMPO_EXPEDIENTEID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            displayIndex++;

            this.dgvSolicitudes.Columns[CAMPO_ORDENTRABAJOID].Visible = true;
            this.dgvSolicitudes.Columns[CAMPO_ORDENTRABAJOID].DisplayIndex = displayIndex;
            this.dgvSolicitudes.Columns[CAMPO_ORDENTRABAJOID].HeaderText = "O.T. ID";
            this.dgvSolicitudes.Columns[CAMPO_ORDENTRABAJOID].Width = 70;
            this.dgvSolicitudes.Columns[CAMPO_ORDENTRABAJOID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            displayIndex++;
        }


        #endregion Métodos de Apoyo

        #region Métodos sobre Controles Locales
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion Métodos sobre Controles Locales

        

    }
}