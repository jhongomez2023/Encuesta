using System.Data;
using System.Data.SqlClient;
using Encuesta.TipoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Encuesta.Datos
{
    public class DPLANTILLAENCUESTAD
    {
        public static void Insertar(PLANTILLAENCUESTAD plantillaencuestad)
        {
            DConexion cnn = new DConexion();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand(@"INSERT INTO PLANTILLAENCUESTAD(CODPLANTILLAENCUESTA,ORDEN,SERVICIO,PREGUNTA,EVALUADO,TIPO)
                                            VALUES(@CODPLANTILLAENCUESTA,@ORDEN,@SERVICIO,@PREGUNTA,@EVALUADO,@TIPO)", cnn.cn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@CODPLANTILLAENCUESTA", plantillaencuestad.CODPLANTILLAENCUESTA); 
            cmd.Parameters.AddWithValue("@ORDEN", plantillaencuestad.ORDEN);
            cmd.Parameters.AddWithValue("@SERVICIO", plantillaencuestad.SERVICIO);
            cmd.Parameters.AddWithValue("@PREGUNTA", plantillaencuestad.PREGUNTA);
            cmd.Parameters.AddWithValue("@EVALUADO", plantillaencuestad.EVALUADO);
            cmd.Parameters.AddWithValue("@TIPO", plantillaencuestad.TIPO);
            try
            {
                cnn.cn.Open();
                dr = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                throw new Exception(@"INSERT INTO PLANTILLAENCUESTAD(CODPLANTILLAENCUESTA,ORDEN,SERVICIO,PREGUNTA,EVALUADO,TIPO)
                                            VALUES(@CODPLANTILLAENCUESTA,@ORDEN,@SERVICIO,@PREGUNTA,@EVALUADO,@TIPO)", e);
            }
            finally
            {
                cnn.cn.Close();
                cmd.Dispose();
            }

        }

        public static void Actualizar(PLANTILLAENCUESTAD plantillaencuestad)
        {
            DConexion cnn = new DConexion();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand(@"UPDATE PLANTILLAENCUESTAD  SET  ORDEN=@ORDEN,SERVICIO=@SERVICIO,PREGUNTA=@PREGUNTA,EVALUADO=@EVALUADO,TIPO=@TIPO
                                              WHERE CODPLANTILLAENCUESTA=@CODPLANTILLAENCUESTA AND CAMPO=@CAMPO", cnn.cn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@CODPLANTILLAENCUESTA", plantillaencuestad.CODPLANTILLAENCUESTA);
            cmd.Parameters.AddWithValue("@CAMPO", plantillaencuestad.CAMPO);
            cmd.Parameters.AddWithValue("@ORDEN", plantillaencuestad.ORDEN);
            cmd.Parameters.AddWithValue("@SERVICIO", plantillaencuestad.SERVICIO);
            cmd.Parameters.AddWithValue("@PREGUNTA", plantillaencuestad.PREGUNTA);
            cmd.Parameters.AddWithValue("@EVALUADO", plantillaencuestad.EVALUADO);
            cmd.Parameters.AddWithValue("@TIPO", plantillaencuestad.TIPO);

            try
            {
                cnn.cn.Open();
                dr = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                throw new Exception(@"UPDATE PLANTILLAENCUESTAD  SET  ORDEN=@ORDEN,SERVICIO=@SERVICIO,PREGUNTA=@PREGUNTA,EVALUADO=@EVALUADO,TIPO=@TIPO
                                      WHERE CODPLANTILLAENCUESTA=@CODPLANTILLAENCUESTA AND CAMPO=@CAMPO", e);
            }
            finally
            {
                cnn.cn.Close();
                cmd.Dispose();
            }

        }

        public static DataTable GetAll(int codplantilla)
        {
            DConexion conn = new DConexion();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(@"SELECT CODPLANTILLAENCUESTA,CAMPO,ORDEN,SERVICIO,PREGUNTA,EVALUADO,TIPO FROM PLANTILLAENCUESTAD
                                              WHERE CODPLANTILLAENCUESTA=@CODPLANTILLAENCUESTA", conn.cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@CODPLANTILLAENCUESTA", codplantilla);

            try
            {
                conn.cn.Open();
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception e)
            {
                throw new Exception(@"SELECT CODPLANTILLAENCUESTA,CAMPO,ORDEN,SERVICIO,PREGUNTA,EVALUADO,TIPO FROM PLANTILLAENCUESTAD
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