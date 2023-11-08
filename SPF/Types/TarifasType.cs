using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPF.Types
{
    public class TarifasType
    {
        public int TarifaID {get;set;}
        public string DescripcionTarifa {get; set;}
        public int TramiteID { get; set; }
        public int MonedaID {get;set;}
        public Nullable<int> TipoTarifaID { get;set; }
    }

    public class TarifasTypeSinTramite
    {
        public int TarifaID { get; set; }
        public string DescripcionTarifa { get; set; }
        public int MonedaID { get; set; }
        public int TipoTarifaID { get; set; }
    }

    public class DetalleTarifasPresupuestoType
    {
        public string DetalleDescripcion { get; set; }
        public decimal DetalleMonto { get; set; }
    }

    public class MonedaInfo
    {
        public int MonedadID { get; set; }
        public string MonedaDescrip { get; set; }
    }
}