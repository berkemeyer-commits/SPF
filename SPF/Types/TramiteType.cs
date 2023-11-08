using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPF.Types
{
    public class TramiteType
    {
        public int TramiteID { get; set; }
        public string DescripcionTramite { get; set; }
        public Nullable<int> TarifaID { get; set; }
        public Nullable<int> TrrID { get; set; }
    }
}