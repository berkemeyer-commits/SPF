//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelEF6
{
    using System;
    using System.Collections.Generic;
    
    public partial class pmu_pagomultiple
    {
        public pmu_pagomultiple()
        {
            this.pp_pagopresupuesto = new ObservableListSource<pp_pagopresupuesto>();
        }
    
        public int pmu_pagomultipleid { get; set; }
        public int pmu_clienteid { get; set; }
        public int pmu_monedaid { get; set; }
        public int pmu_formapagoid { get; set; }
        public System.DateTime pmu_fechapago { get; set; }
        public decimal pmu_montopago { get; set; }
        public string pmu_referencia { get; set; }
    
        public virtual fp_formadepago fp_formadepago { get; set; }
        public virtual ObservableListSource<pp_pagopresupuesto> pp_pagopresupuesto { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Moneda Moneda { get; set; }
    }
}
