using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPF.Types
{
    public class Sifen
    {
    }

    public class SifenAsyncResponse
    {
        public string cdc { get; set; }
        public string codError { get; set; }
        public string estado { get; set; }
        public DateTime fecha { get; set; }
        public string lote { get; set; }
        public string protAut { get; set; }
        public string ruc { get; set; }
        public string tipoDe { get; set; }
        public string tipoWS { get; set; }
    }

    public class SifenQueryResponse
    {
        public string cdc { get; set; }
        public string codigoRespuesta { get; set; }
        public string estado { get; set; }
        public DateTime fechaproceso { get; set; }
        public string lote { get; set; }
        public string msgRespuesta { get; set; }
        public string numini { get; set; }
        public string ruc { get; set; }
    }

    public class SifenQueryResponse2
    {
        public string cdc { get; set; }
        public string codigoRespuesta { get; set; }
        public string estado { get; set; }
        public DateTime fechaproceso { get; set; }
        public string lote { get; set; }
        public string msgRespuesta { get; set; }
        public string numdoc { get; set; }
    }

    public class SifenCancelResponse
    {
        public string cdc { get; set; }
        public string codigoRespuesta { get; set; }
        public string error { get; set; }
        public string estado { get; set; }
        public DateTime fechaproceso { get; set; }
        public string msgRespuesta { get; set; }
        public string proAut { get; set; }
    }
}