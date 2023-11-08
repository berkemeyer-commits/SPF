using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPF.Types
{
    public class CotizacionReportType
    {
        public Nullable<int> ExpedienteID { get; set; }
        public Nullable<int> TramiteID { get; set; }
        public decimal Cantidad { get; set; }
        public int ClienteID { get; set; }
        public decimal PrecioVenta { get; set; }
        public DateTime FechaTarifa { get; set; }
        public int TarifaID { get; set; }
        public Nullable<int> MonedaID { get; set; }
        public string ClienteNombre { get; set; }
        public string TramiteDescripcion { get; set; }
        public string TarifaDescripcion { get; set; }
        public string MonedaDescrip { get; set; }
        public string ExpedienteActa { get; set; }
        public Nullable<int> HINro { get; set; }
        public Nullable<int> HIAnio { get; set; }
        public Nullable<int> ActaNro { get; set; }
        public Nullable<int> ActaAnio { get; set; }
        public decimal ImpuestoMonto { get; set; }
        public decimal ImpuestoPorcentaje { get; set; }
        public decimal DescuentoMonto { get; set; }
        public decimal DescuentoPorcentaje { get; set; }
        public decimal Total { get; set; }
        /*
         ImpuestoMonto, 
ImpuestoPorcentaje,
DescuentoMonto, 
DescuentoPorcentaje,
Total
         */
    }
}