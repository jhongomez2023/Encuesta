using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Encuesta.Datos
{
    public class DConexion
    {
        public SqlConnection cn = new SqlConnection("Data Source=JAGR;Initial Catalog=KCLINIVIDA;Integrated Security = false;User ID=SA;Password=DFB698a7b");
    }
}