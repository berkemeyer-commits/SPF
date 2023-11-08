#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using ModelEF6;
using SPF.Types;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.ObjectModel;

using SPF.Forms.Base;

#endregion

namespace SPF.Forms.UI
{
    public partial class FCopiarCotizaciones : Form
    {
        #region Variables
        BerkeDBEntities DBContext;
        //IBindingList bindingList;
        BindingList<CopiarCotizacionHIType> bList1;
        BindingList<CopiarCotizacionHIType> bList2;
        int OrdenTrabajoID = -1;
        int TramiteID = -1;
        int ExpedienteID = -1;
        int CotizacionCabID = -1;
        #endregion Variables

        #region Constantes
        public const string BROWSE = "BROWSE";
        public const string INSERT = "INSERT";
        public const string EDIT = "EDIT";
        private const string OTROS_TRAMITES = "OTROS_TRAMITES";
        #endregion Constantes

        public FCopiarCotizaciones()
        {
            InitializeComponent();
        }

        public FCopiarCotizaciones(BerkeDBEntities context, string estadoEdicion, int OrdenTrabajoID, int tramiteID, int expedienteID, int cotizacioncabID)
        {
            InitializeComponent();
            this.DBContext = context;
            this.OrdenTrabajoID = OrdenTrabajoID;
            this.TramiteID = tramiteID;
            this.ExpedienteID = expedienteID;
            this.CotizacionCabID = cotizacioncabID;
            this.Text = "Expedientes de la HI";

            this.cargarListBoxes();

        }

        private void cargarListBoxes()
        {
            #region Listbox1
            pa_parametros param = this.DBContext.pa_parametros.First(a => a.clave == OTROS_TRAMITES);

            List<string> listaOtrosTramites = new List<string>(param.valor.Split(','));

            if ((listaOtrosTramites.Contains(this.TramiteID.ToString())))
            {
                var qry = (from opo in this.DBContext.op_oposicion
                           join ot in this.DBContext.OrdenTrabajo
                             on opo.OrdenTrabajoID equals ot.ID into ot_opo
                             from ot in ot_opo.DefaultIfEmpty()
                           select new CopiarCotizacionHIType
                           {
                               ExpedienteID = opo.ID,
                               OrdenTrabajoID = ot.ID,
                               Denominacion = opo.Denominacion,
                               ActaNro = opo.ActaNro,
                               ActaAnio = opo.ActaAnio,
                               HINro = ot.Nro,
                               HIAnio = ot.Anio
                           }).Where(a => a.OrdenTrabajoID == this.OrdenTrabajoID && a.ExpedienteID != this.ExpedienteID);


                bList1 = new BindingList<CopiarCotizacionHIType>(qry.ToList());
            }
            else
            {
            
                var qry = (from expe in this.DBContext.Expediente
                           join ot in this.DBContext.OrdenTrabajo
                             on expe.OrdenTrabajoID equals ot.ID
                           join mar in this.DBContext.Marca
                             on expe.MarcaID equals mar.ID
                           select new CopiarCotizacionHIType
                           {
                               ExpedienteID = expe.ID,
                               OrdenTrabajoID = ot.ID,
                               Denominacion = mar.Denominacion,
                               ActaNro = expe.ActaNro,
                               ActaAnio = expe.ActaAnio,
                               HINro = ot.Nro,
                               HIAnio = ot.Anio
                           }).Where(a => a.OrdenTrabajoID == this.OrdenTrabajoID && a.ExpedienteID != this.ExpedienteID);


                bList1 = new BindingList<CopiarCotizacionHIType>(qry.ToList());
            }
            this.listBox1.DataSource = bList1;
            this.listBox1.DisplayMember = "DisplayText";
            this.listBox1.ValueMember = "ExpedienteID";

            this.Text = "Expedientes de la HI " + bList1.First().HI;

            #endregion Listbox1

            if (bList2 == null)
            {
                bList2 = new BindingList<CopiarCotizacionHIType>();
                this.listBox2.DataSource = bList2;
                this.listBox2.DisplayMember = "DisplayText";
                this.listBox2.ValueMember = "ExpedienteID";
            }

            this.ActualizarLabels();
        }

        private void ActualizarLabels()
        {
            this.lblExpedientesHI.Text = "Expedientes de la HI (" + bList1.Count.ToString() + " expedientes)";
            this.lblExpedientesACopiar.Text = "Expedientes donde se copiarán cotizaciones (" + bList2.Count.ToString() + " expedientes)";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (bList1.Count > 0)
            {
                bList2.Add((CopiarCotizacionHIType)this.listBox1.SelectedItem);
                bList1.Remove((CopiarCotizacionHIType)this.listBox1.SelectedItem);

                this.ActualizarLabels();
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (bList2.Count > 0)
            {
                bList1.Add((CopiarCotizacionHIType)this.listBox2.SelectedItem);
                bList2.Remove((CopiarCotizacionHIType)this.listBox2.SelectedItem);

                this.ActualizarLabels();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            this.btnAgregar.PerformClick();
        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            this.btnQuitar.PerformClick();
        }

        private void btnCopiarHI_Click(object sender, EventArgs e)
        {
            string caption = "Copiar Cotizaciones a Expedientes de la HI";

            string message = "Se copiarán las cotizaciones a los expedientes de la HI seleccionados ¿Desea continuar?";


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
                    this.Guardar();
                }
            }
        }

        private void btnAgregarTodos_Click(object sender, EventArgs e)
        {
            bList2.Clear();

            foreach (var item in this.listBox1.Items)
            {
                bList2.Add((CopiarCotizacionHIType)item);
            }

            bList1.Clear();
            this.ActualizarLabels();
        }

        private void btnQuitarTodos_Click(object sender, EventArgs e)
        {
            bList2.Clear();
            this.cargarListBoxes();
            this.ActualizarLabels();
        }


        private bool existeCotizacion(int expedienteid, int tarifaid, BerkeDBEntities context)
        {
            bool Result = false;

            var query = (from tc in context.tc_tarifascliente
                         select new
                         {
                             ExpedienteID = tc.tc_expedienteid,
                             TarifaID = tc.tc_tarifaid
                         })
                        .Where(a => a.ExpedienteID == expedienteid && a.TarifaID == tarifaid).ToList();

            if (query.Count > 0)
                Result = true;

            return Result;
        }

        private void Guardar()
        {
            bool success = false;
            string message = "";
            using (BerkeDBEntities context = new BerkeDBEntities())
            {
            //Crear transacción
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        //Obtiene las cotizaciones a copiar
                        var queryCotizaciones = context.tc_tarifascliente
                                                .Where(a => a.tc_cotizacioncabid == this.CotizacionCabID)
                                                .ToList();

                        cc_cotizacioncab ccFrom = context.cc_cotizacioncab
                                                         .First(a => a.cc_cotizacioncabid == this.CotizacionCabID);

                        //Itera sobre la lista de expedientes destinos de la copia
                        int gExpedienteID = -1;
                        int gCotizacionCabID = -1;
                        int creados = 0;
                        foreach (var item in this.listBox2.Items)
                        {
                            CopiarCotizacionHIType copy = (CopiarCotizacionHIType)item;
                            
                            foreach(var cotizacion in queryCotizaciones)
                            {
                                if (!this.existeCotizacion(copy.ExpedienteID, cotizacion.tc_tarifaid, context))
                                {
                                    //Cargar Cabecera
                                    cc_cotizacioncab cc = new cc_cotizacioncab();
                                    if (gExpedienteID != copy.ExpedienteID)
                                    {
                                        cc.cc_expedienteid = copy.ExpedienteID;
                                        cc.cc_fecha = ccFrom.cc_fecha;
                                        cc.cc_solicitadopor = ccFrom.cc_solicitadopor;
                                        cc.cc_aprobadopor = ccFrom.cc_aprobadopor;
                                        cc.cc_confirmado = ccFrom.cc_confirmado;
                                        context.cc_cotizacioncab.Add(cc);
                                        context.SaveChanges();
                                        gExpedienteID = copy.ExpedienteID;
                                        gCotizacionCabID = cc.cc_cotizacioncabid;
                                    }
                                    //Iterar y guardar cotizaciones (si aún no existen cotizaciones para ese expediente/tarifa)
                                    tc_tarifascliente tc = new tc_tarifascliente();
                                    tc.tc_clienteid = cotizacion.tc_clienteid;
                                    tc.tc_fecha = System.DateTime.Now;
                                    tc.tc_tarifaid = cotizacion.tc_tarifaid;
                                    tc.tc_monto = cotizacion.tc_monto;
                                    tc.tc_observacion = cotizacion.tc_observacion;
                                    tc.tc_tipounidaddesc = cotizacion.tc_tipounidaddesc;
                                    tc.tc_descuentomonto = cotizacion.tc_descuentomonto;
                                    tc.tc_descuentoporcentaje = cotizacion.tc_descuentoporcentaje;
                                    tc.tc_tipounidadimp = cotizacion.tc_tipounidadimp;
                                    tc.tc_impuestomonto = cotizacion.tc_impuestomonto;
                                    tc.tc_impuestoporcentaje = cotizacion.tc_impuestoporcentaje;
                                    tc.tc_expedienteid = copy.ExpedienteID;
                                    tc.tc_tramiteid = cotizacion.tc_tramiteid;
                                    tc.tc_precioventa = cotizacion.tc_precioventa;
                                    tc.tc_cantidad = cotizacion.tc_cantidad;
                                    tc.tc_total = cotizacion.tc_total;
                                    tc.tc_especial = cotizacion.tc_especial;
                                    tc.tc_monedaid = cotizacion.tc_monedaid;
                                    tc.tc_totalconrecargo = cotizacion.tc_totalconrecargo;
                                    tc.tc_cotizacioncabid = gCotizacionCabID;
                                    context.tc_tarifascliente.Add(tc);
                                    context.SaveChanges();
                                    creados++;
                                    
                                }
                                else
                                {
                                    message += String.Format("No puede ser copiar la cotización al acta {0} ({1}) porque ya existen cotizaciones para el Expediente/Tarifa." + Environment.NewLine,
                                                             copy.Acta, copy.Denominacion);
                                    break;
                                }
                        
                            }
                                                
                        }

                        if (creados > 0)
                        {
                            //context.SaveChanges();
                            dbContextTransaction.Commit();
                            success = true;
                        }
                        else
                            dbContextTransaction.Dispose();
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

                if (success)
                {
                    MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (message != "")
                {
                    MessageBox.Show("Operación completada con excepciones: " + Environment.NewLine + message,
                                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}