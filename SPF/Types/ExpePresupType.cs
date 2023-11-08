using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPF.Types
{
    public class ExpePresupType
    {
        public int PresupuestoCabID { get; set; }
        public Nullable<int> ExpedienteID { get; set; }
        public string DenominacionMarca { get; set; }
        public string PropietarioMarca { get; set; }
        public Nullable<int> ActaNro { get; set; }
        public Nullable<int> ActaAnio { get; set; }
        public string RegistroNro { get; set; }
        public string DescripTramite { get; set; }
        public Nullable<int> HINro { get; set; }
        public Nullable<int> HiAnio { get; set; }
        public int CotizacionCabID { get; set; }
        public int TramiteID { get; set; }
        public string Serie { get; set; }
        public Nullable<int> NroPresupuesto { get; set; }
        public string NroPresupuestoCompuesto
        {
            get
            {
                if ((this.Serie != "") && (this.NroPresupuesto.HasValue))
                    return this.Serie + this.NroPresupuesto.Value.ToString();
                else
                    return "";
            }

        }
        public string HI
        {
            get
            {
                if ((this.HINro.HasValue) && (this.HiAnio.HasValue))
                    return this.HINro.ToString() + "/" + this.HiAnio.ToString();
                else
                    return "";
            }
        }
        public string Acta
        {
            get
            {
                if ((this.ActaNro.HasValue) && (this.ActaNro.HasValue))
                    return this.ActaNro.ToString() + "/" + this.ActaAnio.ToString();
                else
                    return "";
            }
            
        }
        public Nullable<int> OrdenTrabajoID { get; set; }
        public Nullable<DateTime> FechaCorresp { get; set; }
        public Nullable<bool> EnTramite { get; set; }
        public string ReferenciaCliente { get; set; }
        public string ReferenciaCorresp { get; set; }
        public Nullable<int> NroCorresp { get; set; }
        public Nullable<int> AnioCorresp { get; set; }
        public Nullable<int> AreaContabID { get; set; }
        public Nullable<int> AprobadoPor { get; set; }
        public Nullable<int> HechoPor { get; set; }
        public string Origen { get; set; }
        public string MarcaTipo { get; set; }
        public int ClaseNro { get; set; }
        public Nullable<int> NroRegistro { get; set; }
        public Nullable<int> AnoRegistro { get; set; }
        public Nullable<DateTime> FechaConcesion { get; set; }
        public Nullable<int> AtencionID { get; set; }
        public string AtencionNombre { get; set; }
    }
}