using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPF.Types
{
    public class PartePresupuestoType
    {
        public int PartePresupuestoID { get; set; }
        public int TramiteID { get; set; }
        public string TramiteDescrip { get; set; }
        public string DescripServEsp { get; set; }
        public string DescripGastIng { get; set; }
        public string DescripServIng { get; set; }
        public string DescripGastEsp { get; set; }

    }
}