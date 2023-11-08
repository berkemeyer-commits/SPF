using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPF.Types
{
    public class AntecedentesClienteType
    {
        public Nullable<DateTime> FechaAntecedente { get; set; }
        public int AntecedenteID { get; set; }
        public int ClienteID { get; set; }
        public string ClienteNombre { get; set; }
        public int TipoAntecedenteID { get; set; }
        public string TipoAntecedenteNombre { get; set; }
        public Nullable<int> TarifarioID { get; set; }
        public string Observacion { get; set; }
        public string TipoAntecedenteLocal { get; set; }
        public Nullable<int> UsuarioEnviaID { get; set; }
        public string UsuarioEnviaNombre { get; set; }
        public Nullable<int> UsuarioAutorizaID { get; set; }
        public string UsuarioAutorizaNombre { get; set; }
        public Nullable<int> TramiteID { get; set; }
        public string TramiteDescrip { get; set; }
        public Nullable<int> RegistroNro { get; set; }
        public Nullable<int> ActaNro { get; set; }
        public Nullable<int> ActaAnio { get; set; }
        public bool TieneAutorizacionVigente { get; set; }
        
        public string TipoAntecedenteLocalNombre
        {
            get
            {
                if (this.TipoAntecedenteLocal == "M")
                    return "Manual";
                else if (this.TipoAntecedenteLocal == "A")
                    return "Automático";
                return "";
            }
        }


    }
}