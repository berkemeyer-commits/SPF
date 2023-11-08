using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPF.Types
{
    public class OpoExpeType
    {
        public int ExpeOpoID { get; set; }
        public Nullable<int> ExpeID { get; set; }
        public Nullable<int> ActaNro { get; set; }
        public Nullable<int> ActaAnio { get; set; }
        public int IDCliente { get; set; }
        public string ClienteNombre { get; set; }
        public Nullable<int> AtencionID { get; set; }
        public string AtencionNombre { get; set; }
        public string DenominacionMarca { get; set; }
        public Nullable<int> RegistroNro { get; set; }
        public string TramiteDescrip { get; set; }
        public int TramiteID { get; set; }
        public string TramiteDescripDestino { get; set; }
        public Nullable<int> UsuarioID { get; set; }
        public Nullable<DateTime> FechaEnvio { get; set; }
        public string NombreUsuario { get; set; }
        public Nullable<int> HINro { get; set; }
        public Nullable<int> HiAnio { get; set; }
        public Nullable<int> OrdenTrabajoID { get; set; }
        public Nullable<DateTime> FechaPresentacion { get; set; }
        public string ParteNombre { get; set; }
        public string ContraparteNombre { get; set; }
        public Nullable<DateTime> FechaSalida { get; set; }
        public string HITexto
        {
            get 
            {
                if ((this.HINro.ToString() != "") && (this.HiAnio.ToString() != ""))
                    return this.HINro.ToString() + "/" + this.HiAnio.ToString();
                else
                    return "";
            }
        }
        public string Acta
        {
            get
            {
                if ((this.ActaNro.HasValue && this.ActaAnio.HasValue) && (acta == ""))
                    acta = this.ActaNro.ToString() + "/" + this.ActaAnio.ToString();

                return acta;
            }
            set
            {
                acta = value;
            }
        }
        private string acta = "";

        public int UsuarioAuditID { get; set; }
        public string UsuarioAuditNombre { get; set; }
        public string AuditOperacion { get; set; }
    }
}