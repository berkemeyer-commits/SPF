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
    
    public partial class RepEstadoDeCuentaTramitesDesagrupados1_Result
    {
        public int ClienteID { get; set; }
        public string ClienteNombre { get; set; }
        public Nullable<int> ClienteIdiomaID { get; set; }
        public string Tramite { get; set; }
        public string CodigoRESI { get; set; }
        public string FechaDoc { get; set; }
        public Nullable<System.DateTime> FechaDocAsDate { get; set; }
        public string NroDoc { get; set; }
        public Nullable<decimal> Saldo { get; set; }
        public string Moneda { get; set; }
        public System.DateTime FechaGeneracion { get; set; }
        public int PresupuestoID { get; set; }
        public int TramiteID { get; set; }
        public string Origen { get; set; }
    }
}