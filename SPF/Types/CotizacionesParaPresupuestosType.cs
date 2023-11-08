using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPF.Types
{
    public class CotizacionesParaPresupuestosType
    {
        public Nullable<int> ExpedienteID { get; set; }
        public Nullable<int> OrdenTrabajoID { get; set; }
        public string HI { get; set; }
        public int ClienteID { get; set; }
        public string ClienteNombre { get; set; }
        public Nullable<int> TramiteID { get; set; }
        public string TramiteDescrip { get; set; }
        public string SerieAux { get; set; }
        public Nullable<int> NroPresupuestoAux { get; set; }
        public string ClienteCorreo { get; set; }
        public bool ClienteMultiple { get; set; }
        public Nullable<bool> Generado { get; set; }
        public string NroPresupuesto { get; set; }
        public string ReferenciaCliente { get; set; }
        public string ErrMsg { get; set; }
        public Nullable<int> HechoPor { get; set; }
        public string InicialesHecho { get; set; }
        public Nullable<int> AprobadoPor { get; set; }
        public string InicialesAprob { get; set; }
        public Nullable<int> AreaContabID { get; set; }
        public string AbrevPresupDoc { get; set; }
        public string AreaDescrip { get; set; }
        public Nullable<bool> Anulado { get; set; }
        public Nullable<DateTime> FechaGeneracionAux { get; set; }
        public string Idioma { get; set; }
    }

    public class CotizacionesPorPresupuestosType
    {
        public int CotizacionCabID { get; set; }
        public Nullable<DateTime> FechaConfirmacion { get; set; }
        public string DocumentoNro { get; set; }
        public Nullable<DateTime> FechaDocumento { get; set; }
        public string Estado { get; set; }
        public string ConfeccionadoPor { get; set; }
        public string Responsable { get; set; }
        public string Observacion
        {
            get { return observacion; }
            set { this.observacion = value != String.Empty ? value : "--"; }
        }
        public string observacion = String.Empty;
    }
}