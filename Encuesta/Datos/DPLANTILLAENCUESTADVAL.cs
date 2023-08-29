using System.Data;
using System.Data.SqlClient;
using Encuesta.TipoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Encuesta.Datos
{
    public class DPLANTILLAENCUESTADVAL
    {
        public static void Insertar(PLANTILLAENCUESTADVAL plantillaencuestadval)
        {
            DConexion cnn = new DConexion();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand(@"INSERT INTO PLANTILLAENCUESTADVAL(CODPLANTILLAENCUESTA,CAMPO,DESCRIPCION)
                                            VALUES(@CODPLANTILLAENCUESTA,@CAMPO,@DESCRIPCION)", cnn.cn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@CODPLANTILLAENCUESTA", plantillaencuestadval.CODPLANTILLAENCUESTA);
            cmd.Parameters.AddWithValue("@CAMPO", plantillaencuestadval.CAMPO);
            cmd.Parameters.AddWithValue("@DESCRIPCION", plantillaencuestadval.DESCRIPCION);
            try
            {
                cnn.cn.Open();
                dr = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                throw new Exception(@"INSERT INTO PLANTILLAENCUESTADVAL(CODPLANTILLAENCUESTA,CAMPO,DESCRIPCION)
                                            VALUES(@CODPLANTILLAENCUESTA,@CAMPO,@DESCRIPCION)", e);
            }
            finally
            {
                cnn.cn.Close();
                cmd.Dispose();
            }

        }

        public static void Actualizar(PLANTILLAENCUESTADVAL plantillaencuestadval)
        {
            DConexion cnn = new DConexion();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand(@"UPDATE PLANTILLAENCUESTADVAL  SET  DESCRIPCION=@DESCRIPCION
                                              WHERE CODPLANTILLAENCUESTA=@CODPLANTILLAENCUESTA AND CAMPO=@CAMPO AND IDPLANTILLALISTA=@IDPLANTILLALISTA ", cnn.cn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@IDPLANTILLALISTA", plantillaencuestadval.IDPLANTILLALISTA);
            cmd.Parameters.AddWithValue("@CODPLANTILLAENCUESTA", plantillaencuestadval.CODPLANTILLAENCUESTA);
            cmd.Parameters.AddWithValue("@CAMPO", plantillaencuestadval.CAMPO);
            cmd.Parameters.AddWithValue("@DESCRIPCION", plantillaencuestadval.DESCRIPCION);

            try
            {
                cnn.cn.Open();
                dr = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                throw new Exception(@"UPDATE PLANTILLAENCUESTADVAL  SET  DESCRIPCION=@DESCRIPCION
                                              WHERE CODPLANTILLAENCUESTA=@CODPLANTILLAENCUESTA AND CAMPO=@CAMPO AND IDPLANTILLALISTA=@IDPLANTILLALISTA ", e);
            }
            finally
            {
                cnn.cn.Close();
                cmd.Dispose();
            }

        }

        public static DataTable GetAll(int codplantilla, int idCampo)
        {
            DConexion conn = new DConexion();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(@"SELECT IDPLANTILLALISTA,CODPLANTILLAENCUESTA,CAMPO,DESCRIPCION  FROM PLANTILLAENCUESTADVAL
                                              WHERE CODPLANTILLAENCUESTA=@CODPLANTILLAENCUESTA AND CAMPO=@CAMPO", conn.cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@CODPLANTILLAENCUESTA", codplantilla);
            cmd.Parameters.AddWithValue("@CAMPO", idCampo);


            try
            {
                conn.cn.Open();
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception e)
            {
                throw new Exception(@"SELECT IDPLANTILLALISTA,CODPLANTILLAENCUESTA,CAMPO,DESCRIPCION FROM PLANTILLAENCUESTADVAL
                                    WHERE CODPLANTILLAENCUESTA=@CODPLANTILLAENCUESTA", e);
            }
            finally
            {
                conn.cn.Close();
                cmd.Dispose();
            }
            return dt;
        }
    }
}