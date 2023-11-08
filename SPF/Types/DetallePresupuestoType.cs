using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPF.Types
{
    public class DetallePresupuestoType
    {
        public Nullable<int> OrdenTrabajoID { get; set; }
        public Nullable<int> ExpedienteID { get; set; }
        public string Acta { get; set; }
        public string DenominacionMarca { get; set; }
        public Nullable<DateTime> PresentacionFecha { get; set; }
        public string HI { get; set; }
        public int ClienteID { get; set; }
        public string ClienteNombre { get; set; }
        public Nullable<int> TramiteID { get; set; }
        public string TramiteDescrip { get; set; }
        public string SerieAux { get; set; }
        public Nullable<int> NroPresupuestoAux { get; set; }
        public string NroPresupuesto { get; set; }
        public Nullable<bool> Generado { get; set; }
        public Nullable<bool> Terminado { get; set; }
        public Nullable<bool> Anulado { get; set; }
        public Nullable<int> ExpedienteIDPadre { get; set; }
        public Nullable<int> ExpedientePadreID_pr { get; set; }
        public Nullable<int> HINro { get; set; }
        public Nullable<int> HIAnho { get; set; }
        public Nullable<int> CotizacionCabID { get; set; }
        public Nullable<int> MeID { get; set; }
        public Nullable<int> MergeDocID { get; set; }
        public string Idioma { get; set; }
    }
}