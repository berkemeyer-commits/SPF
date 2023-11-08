using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPF.Types
{
    public class CopiarCotizacionHIType
    {
        public int ExpedienteID { get; set; }
        public int OrdenTrabajoID { get; set; }
        public string Denominacion { get; set; }
        public Nullable<int> ActaNro { get; set; }
        public Nullable<int> ActaAnio { get; set; }
        public string Acta 
        {
            get { return ActaNro.ToString() + "/" + ActaAnio.ToString(); }
        }
        public int HINro { get; set; }
        public int HIAnio { get; set; }
        public string DisplayText
        {
            get { return this.Acta + " - " + this.Denominacion; }
        }

        public string HI
        {
            get { return this.HINro.ToString() + "/" + this.HIAnio.ToString(); }
        }
    }
}