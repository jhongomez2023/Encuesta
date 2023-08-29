using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Encuesta.TipoDatos;

namespace Encuesta.Datos
{
    public class DRESULTADOENCUESTA
    {

        public static void Insertar(string datos, string documento, string encuesta) 
        {
            DConexion cnn = new DConexion();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand(@"SP_GUARDAR_RESULTADOENCUESTA", cnn.cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@DATOS", datos);
            cmd.Parameters.AddWithValue("@DOCUMENTO", documento);
            cmd.Parameters.AddWithValue("@ENCUESTA", encuesta);

            try
            {
                cnn.cn.Open();
                dr = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                throw new Exception(@"INSERT INTO PLANTILLAENCUESTA(DESCRIPCION)
VALUES(DESCRIPCION)", e);
            }
            finally
            {
                cnn.cn.Close();
                cmd.Dispose();
            }

        }

    }
}