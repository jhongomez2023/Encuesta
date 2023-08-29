using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Encuesta.TipoDatos
{
    public class PLANTILLAENCUESTAD
    {

        public int CODPLANTILLAENCUESTA { get; set; }
        public int CAMPO { get; set; }
        public int ORDEN { get; set; }
        public string SERVICIO { get; set; }
        public string PREGUNTA { get; set; }
        public string EVALUADO { get; set; }
        public string TIPO { get; set; }
    }
}