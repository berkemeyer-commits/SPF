using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPF.Types
{
    public class ExpeOpoType
    {
        public int ExpedienteID { get; set; }
        public string DenominacionMarca { get; set; }
        public int MarcaID { get; set; }
        public Nullable<int> ActaNro { get; set; }
        public Nullable<int> ActaAnio { get; set; }
        public Nullable<int> RegistroNro { get; set; }
        public Nullable<int> ClienteID { get; set; }
        public string ClienteNombre { get; set; }
        public int TramiteID { get; set; }
        public string DescripTramite { get; set; }
        public Nullable<int> HINro { get; set; }
        public Nullable<int> HiAnio { get; set; }
        public Nullable<int> OrdenTrabajoID { get; set; }
        public string ParteNombre { get; set; }
        public string ContraparteNombre { get; set; }
        public string HITexto
        {
            get { return this.HINro.ToString() + "/" + this.HiAnio.ToString(); }
        }
        public Nullable<DateTime> FechaPresentacion { get; set; }
    }
}