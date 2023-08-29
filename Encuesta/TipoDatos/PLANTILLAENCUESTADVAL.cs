using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Encuesta.TipoDatos
{
    public class PLANTILLAENCUESTADVAL
    {
        public int IDPLANTILLALISTA { get; set; }
        public int CODPLANTILLAENCUESTA { get; set; }
        public int CAMPO { get; set; }
        public string DESCRIPCION { get; set; }
    }
}