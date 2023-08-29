using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Encuesta.TipoDatos;

namespace Encuesta.Datos
{
    public class DPLANTILLAENCUESTA
    {

        public static void Insertar(PLANTILLAENCUESTA plantillaencuesta)
        {
            DConexion cnn = new DConexion();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand(@"INSERT INTO PLANTILLAENCUESTA(DESCRIPCION)
VALUES(@DESCRIPCION)", cnn.cn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@DESCRIPCION", plantillaencuesta.DESCRIPCION);
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

        public static void Actualizar(PLANTILLAENCUESTA plantillaencuesta)
        {
            DConexion cnn = new DConexion();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand(@"UPDATE PLANTILLAENCUESTA  SET  DESCRIPCION=@DESCRIPCION WHERE CODPLANTILLAENCUESTA=@CODPLANTILLAENCUESTA", cnn.cn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@DESCRIPCION", plantillaencuesta.DESCRIPCION);
            cmd.Parameters.AddWithValue("@CODPLANTILLAENCUESTA", plantillaencuesta.CODPLANTILLAENCUESTA);

            try
            {
                cnn.cn.Open();
                dr = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                throw new Exception(@"UPDATE PLANTILLAENCUESTA  SET  DESCRIPCION=@DESCRIPCION WHERE CODPLANTILLAENCUESTA=@CODPLANTILLAENCUESTA", e);
            }
            finally
            {
                cnn.cn.Close();
                cmd.Dispose();
            }

        }
        public static  DataTable GetAll()
        {
            DConexion conn = new DConexion();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT CODPLANTILLAENCUESTA,DESCRIPCION FROM PLANTILLAENCUESTA ", conn.cn);
            cmd.CommandType = CommandType.Text;

            try
            {
                conn.cn.Open();
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception e)
            {
                throw new Exception(@"SELECT CODPLANTILLAENCUESTA,DESCRIPCION FROM PLANTILLAENCUESTA ", e);
            }
            finally
            {
                conn.cn.Close();
                cmd.Dispose();
            }
            return dt;
        }
        public static DataTable GetAllResultado( DateTime fechainicial , DateTime fechafinal)
        {
            DConexion conn = new DConexion();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(@"SELECT FECHA , DOCUMENTO, NOMBREAFI, EDAD, DIRECCION, TELEFONO, EAPB, GRUPOPOB, SERVICIO, PREGUNTA, EVALUADO, VALOR
FROM RESULTADOENCUESTA WHERE CAST(FECHA AS DATE) BETWEEN @FECHA1 AND @FECHA2 
ORDER BY ID", conn.cn);
            cmd.CommandType = CommandType.Text;


            cmd.Parameters.AddWithValue("@FECHA1", fechainicial);
            cmd.Parameters.AddWithValue("@FECHA2", fechafinal);

            try
            {
                conn.cn.Open();
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception e)
            {
                throw new Exception(@"SELECT FECHA , DOCUMENTO, NOMBREAFI, EDAD, DIRECCION, TELEFONO, EAPB, GRUPOPOB, SERVICIO, PREGUNTA, EVALUADO, VALOR
FROM RESULTADOENCUESTA WHERE CAST(FECHA AS DATE) BETWEEN @FECHA1 AND @FECHA2", e);
            }
            finally
            {
                conn.cn.Close();
                cmd.Dispose();
            }
            return dt;
        }
        public static DataTable GetAllResultadoResumido(DateTime fechainicial, DateTime fechafinal)
        {
            DConexion conn = new DConexion();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(@"SELECT SERVICIO ,PREGUNTA,EVALUADO, VALOR  RESPUESTA , COUNT(VALOR) CANT
FROM RESULTADOENCUESTA
 WHERE CAST(FECHA AS DATE) BETWEEN @FECHA1 AND @FECHA2
GROUP BY SERVICIO ,PREGUNTA,EVALUADO, VALOR    
", conn.cn);
            cmd.CommandType = CommandType.Text;


            cmd.Parameters.AddWithValue("@FECHA1", fechainicial);
            cmd.Parameters.AddWithValue("@FECHA2", fechafinal);

            try
            {
                conn.cn.Open();
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception e)
            {
                throw new Exception(@"SELECT SERVICIO ,PREGUNTA,EVALUADO, VALOR  RESPUESTA , COUNT(VALOR) CANT
FROM RESULTADOENCUESTA
 WHERE CAST(FECHA AS DATE) BETWEEN @FECHA1 AND @FECHA2
GROUP BY SERVICIO ,PREGUNTA,EVALUADO, VALOR    ", e);
            }
            finally
            {
                conn.cn.Close();
                cmd.Dispose();
            }
            return dt;
        }
        public static DataTable traerPlantillaEncuesta(int codplantilla,   string servicio)
        {
            DConexion conn = new DConexion();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(@"SELECT ROW_NUMBER()OVER(ORDER BY ORDEN, CAMPO)CNS, Z. *,  
CASE WHEN TIPO  IN ('RadioButton','Lista','Alfanumerico') then REPLACE(REPLACE(REPLACE('rbt'+ 'JAGR' +CASE WHEN COALESCE(SERVICIO,'')='' THEN 'Blanco' ELSE COALESCE(SERVICIO,'') END + 'JAGR' + PREGUNTA  + 'JAGR' + VALOR +'JAGR' +CONVERT(VARCHAR(MAX), CAMPO) + CONVERT(VARCHAR(MAX), ROW_NUMBER()OVER(ORDER BY ORDEN, CAMPO))
,' ','1sp4c10'),',','C0m4'),'?','Pr3gunt4')
ELSE '' END IDCAMPO

 FROM(
SELECT  MIN(ORDEN) ORDEN,SERVICIO,PREGUNTA, PREGUNTA  VALOR, 'Pregunta' TIPOREGISTRO,'Titulo' TIPO, 0 CAMPO
FROM PLANTILLAENCUESTAD 
WHERE SERVICIO=COALESCE(@SERVICIO,'')   and CODPLANTILLAENCUESTA=@CODPLANTILLAENCUESTA
AND COALESCE(PREGUNTA,'')<>''
GROUP BY PREGUNTA,SERVICIO
UNION ALL
SELECT  MIN(ORDEN) ORDEN,SERVICIO,PREGUNTA, PREGUNTA  VALOR, 'Pregunta' TIPOREGISTRO,'Titulo' TIPO, 0 CAMPO
FROM PLANTILLAENCUESTAD 
WHERE SERVICIO='' AND EVALUADO<>''   and CODPLANTILLAENCUESTA=@CODPLANTILLAENCUESTA 
AND COALESCE(PREGUNTA,'')<>''
GROUP BY PREGUNTA,SERVICIO
UNION ALL
SELECT  ORDEN,SERVICIO,PREGUNTA, EVALUADO , 'Evaluado', TIPO, CAMPO
FROM PLANTILLAENCUESTAD WHERE SERVICIO=@SERVICIO and CODPLANTILLAENCUESTA=@CODPLANTILLAENCUESTA
--GROUP BY EVALUADO,PREGUNTA, SERVICIO
UNION ALL 

SELECT ORDEN,SERVICIO,PREGUNTA,'' , 'EvaluadoSerBlanco', TIPO, CAMPO
FROM PLANTILLAENCUESTAD 

WHERE coalesce(SERVICIO,'')='' AND COALESCE(EVALUADO,'')='' and CODPLANTILLAENCUESTA=@CODPLANTILLAENCUESTA
UNION ALL
SELECT ORDEN,SERVICIO,PREGUNTA, EVALUADO, 'EvaluadoNoBlanco', TIPO, CAMPO
FROM PLANTILLAENCUESTAD 

WHERE SERVICIO='' AND COALESCE(EVALUADO,'')<>'' and CODPLANTILLAENCUESTA=@CODPLANTILLAENCUESTA
) Z

ORDER BY ORDEN, CAMPO", conn.cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@CODPLANTILLAENCUESTA", codplantilla);
            cmd.Parameters.AddWithValue("@SERVICIO", servicio);


            try
            {
                conn.cn.Open();
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception e)
            {
                throw new Exception(@"SELECT ROW_NUMBER()OVER(ORDER BY ORDEN, CAMPO)CNS, Z. *,  
CASE WHEN TIPO  IN ('RadioButton','Lista','Alfanumerico') then REPLACE(REPLACE(REPLACE('rbt'+ 'JAGR' +CASE WHEN COALESCE(SERVICIO,'')='' THEN 'Blanco' ELSE COALESCE(SERVICIO,'') END + 'JAGR' + PREGUNTA  + 'JAGR' + VALOR +'JAGR' +CONVERT(VARCHAR(MAX), CAMPO) + CONVERT(VARCHAR(MAX), ROW_NUMBER()OVER(ORDER BY ORDEN, CAMPO))
,' ','1sp4c10'),',','C0m4'),'?','Pr3gunt4')
ELSE '' END IDCAMPO

 FROM(
SELECT  MIN(ORDEN) ORDEN,SERVICIO,PREGUNTA, PREGUNTA  VALOR, 'Pregunta' TIPOREGISTRO,'Titulo' TIPO, 0 CAMPO
FROM PLANTILLAENCUESTAD 
WHERE SERVICIO=COALESCE(@SERVICIO,'')   and CODPLANTILLAENCUESTA=@CODPLANTILLAENCUESTA
AND COALESCE(PREGUNTA,'')<>''
GROUP BY PREGUNTA,SERVICIO
UNION ALL
SELECT  MIN(ORDEN) ORDEN,SERVICIO,PREGUNTA, PREGUNTA  VALOR, 'Pregunta' TIPOREGISTRO,'Titulo' TIPO, 0 CAMPO
FROM PLANTILLAENCUESTAD 
WHERE SERVICIO='' AND EVALUADO<>''   and CODPLANTILLAENCUESTA=@CODPLANTILLAENCUESTA 
AND COALESCE(PREGUNTA,'')<>''
GROUP BY PREGUNTA,SERVICIO
UNION ALL
SELECT  ORDEN,SERVICIO,PREGUNTA, EVALUADO , 'Evaluado', TIPO, CAMPO
FROM PLANTILLAENCUESTAD WHERE SERVICIO=@SERVICIO and CODPLANTILLAENCUESTA=@CODPLANTILLAENCUESTA
--GROUP BY EVALUADO,PREGUNTA, SERVICIO
UNION ALL 

SELECT ORDEN,SERVICIO,PREGUNTA,'' , 'EvaluadoSerBlanco', TIPO, CAMPO
FROM PLANTILLAENCUESTAD 

WHERE coalesce(SERVICIO,'')='' AND COALESCE(EVALUADO,'')='' and CODPLANTILLAENCUESTA=@CODPLANTILLAENCUESTA
UNION ALL
SELECT ORDEN,SERVICIO,PREGUNTA, EVALUADO, 'EvaluadoNoBlanco', TIPO, CAMPO
FROM PLANTILLAENCUESTAD 

WHERE SERVICIO='' AND COALESCE(EVALUADO,'')<>'' and CODPLANTILLAENCUESTA=@CODPLANTILLAENCUESTA
) Z

ORDER BY ORDEN, CAMPO", e);
            }
            finally
            {
                conn.cn.Close();
                cmd.Dispose();
            }
            return dt;
        }
        public static DataTable graficaAfiEncuestadosEmpresa(DateTime fechainicial, DateTime fechafinal)
        {
            DConexion conn = new DConexion();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(@"SELECT TIPO,LEFT( EAPB,50)EAPB, COUNT(EAPB) Total FROM (
SELECT DISTINCT DOCUMENTO, CASE WHEN PPT.IDPLAN = 'ASE' THEN 'SOAT' ELSE TER.RAZONSOCIAL END EAPB, 'EAPB' TIPO
FROM RESULTADOENCUESTA INNER JOIN AFI ON AFI.DOCIDAFILIADO = RESULTADOENCUESTA.DOCUMENTO

                       INNER JOIN TER ON TER.IDTERCERO = AFI.IDADMINISTRADORA

                       INNER JOIN PPT ON PPT.IDTERCERO = TER.IDTERCERO


WHERE CAST(FECHA AS DATE) BETWEEN @FECHA1 AND @FECHA2) Z
GROUP BY TIPO, EAPB ", conn.cn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@FECHA1", fechainicial);
            cmd.Parameters.AddWithValue("@FECHA2", fechafinal);

            try
            {
                conn.cn.Open();
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception e)
            {
                throw new Exception(@"SELECT CODPLANTILLAENCUESTA,DESCRIPCION FROM PLANTILLAENCUESTA ", e);
            }
            finally
            {
                conn.cn.Close();
                cmd.Dispose();
            }
            return dt;
        }
        public static DataTable graficaAfiEncuestadosGrupoPob(DateTime fechainicial, DateTime fechafinal)
        {
            DConexion conn = new DConexion();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(@"SELECT TIPO,GRUPOPOB, COUNT(GRUPOPOB) Total  FROM (
SELECT DISTINCT DOCUMENTO,GRUPOPOB, 'GRUPOPOB' TIPO FROM RESULTADOENCUESTA
WHERE CAST(FECHA AS DATE) BETWEEN @FECHA1 AND @FECHA2 ) Z
GROUP BY TIPO , GRUPOPOB", conn.cn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@FECHA1", fechainicial);
            cmd.Parameters.AddWithValue("@FECHA2", fechafinal);

            try
            {
                conn.cn.Open();
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception e)
            {
                throw new Exception(@"SELECT TIPO,GRUPOPOB, COUNT(GRUPOPOB) CANT  FROM (
SELECT DISTINCT DOCUMENTO,GRUPOPOB, 'GRUPOPOB' TIPO FROM RESULTADOENCUESTA
WHERE CAST(FECHA AS DATE) BETWEEN @FECHA1 AND @FECHA2 ) Z
GROUP BY TIPO , GRUPOPOB", e);
            }
            finally
            {
                conn.cn.Close();
                cmd.Dispose();
            }
            return dt;
        }
        public static DataTable graficaAfiEncuestadosPregunta(DateTime fechainicial, DateTime fechafinal)
        {
            DConexion conn = new DConexion();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM(
SELECT TIPO,PREGUNTA,   [SI] , [NO], [Definitivo SI], [Definitivo NO], [Probablemente SI], [Probablemente NO]
FROM  
(
SELECT TIPO,PREGUNTA, VALOR  FROM (
SELECT  PREGUNTA,VALOR, 'Preguntas Varias' TIPO FROM RESULTADOENCUESTA
WHERE CAST(FECHA AS DATE) BETWEEN @FECHA1 AND @FECHA2 
AND SERVICIO='' AND EVALUADO='') Z
) AS SourceTable  
PIVOT  
(  
  COUNT(VALOR)
 
  FOR VALOR IN ([SI], [NO], [Definitivo SI], [Definitivo NO], [Probablemente SI], [Probablemente NO])  
) AS PivotTable ) Z", conn.cn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@FECHA1", fechainicial);
            cmd.Parameters.AddWithValue("@FECHA2", fechafinal);

            try
            {
                conn.cn.Open();
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception e)
            {
                throw new Exception(@"SELECT TIPO,GRUPOPOB, COUNT(GRUPOPOB) CANT  FROM (
SELECT DISTINCT DOCUMENTO,GRUPOPOB, 'GRUPOPOB' TIPO FROM RESULTADOENCUESTA
WHERE CAST(FECHA AS DATE) BETWEEN @FECHA1 AND @FECHA2 ) Z
GROUP BY TIPO , GRUPOPOB", e);
            }
            finally
            {
                conn.cn.Close();
                cmd.Dispose();
            }
            return dt;
        }
        public static DataTable graficaAfiEncuestadosServicioUrgencia(DateTime fechainicial, DateTime fechafinal)
        {
            DConexion conn = new DConexion();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(@"SELECT TIPO,EVALUADO,   
  [Muy Buena], [Buena], [Regular], [Malo], [Muy Malo]
FROM  
(
SELECT TIPO,EVALUADO, VALOR  FROM (
SELECT  EVALUADO,VALOR, 'Servicio Urgencia' TIPO FROM RESULTADOENCUESTA
WHERE CAST(FECHA AS DATE) BETWEEN @FECHA1 AND @FECHA2 
AND SERVICIO='Urgencia') Z
) AS SourceTable  
PIVOT  
(  
  COUNT(VALOR)

  FOR VALOR IN ([Muy Buena], [Buena], [Regular], [Malo], [Muy Malo])  
) AS PivotTable ", conn.cn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@FECHA1", fechainicial);
            cmd.Parameters.AddWithValue("@FECHA2", fechafinal);

            try
            {
                conn.cn.Open();
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception e)
            {
                throw new Exception(@"SELECT TIPO,GRUPOPOB, COUNT(GRUPOPOB) CANT  FROM (
SELECT DISTINCT DOCUMENTO,GRUPOPOB, 'GRUPOPOB' TIPO FROM RESULTADOENCUESTA
WHERE CAST(FECHA AS DATE) BETWEEN @FECHA1 AND @FECHA2 ) Z
GROUP BY TIPO , GRUPOPOB", e);
            }
            finally
            {
                conn.cn.Close();
                cmd.Dispose();
            }
            return dt;
        }
        public static DataTable graficaAfiEncuestadosServicioUci(DateTime fechainicial, DateTime fechafinal)
        {
            DConexion conn = new DConexion();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(@"SELECT TIPO,EVALUADO,   
  [Muy Buena], [Buena], [Regular], [Malo], [Muy Malo]
FROM  
(
SELECT TIPO,EVALUADO, VALOR  FROM (
SELECT  EVALUADO,VALOR, 'Servicio Urgencia' TIPO FROM RESULTADOENCUESTA
WHERE CAST(FECHA AS DATE) BETWEEN @FECHA1 AND @FECHA2 
AND SERVICIO='Uci') Z
) AS SourceTable  
PIVOT  
(  
  COUNT(VALOR)

  FOR VALOR IN ([Muy Buena], [Buena], [Regular], [Malo], [Muy Malo])  
) AS PivotTable ", conn.cn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@FECHA1", fechainicial);
            cmd.Parameters.AddWithValue("@FECHA2", fechafinal);

            try
            {
                conn.cn.Open();
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception e)
            {
                throw new Exception(@"SELECT TIPO,GRUPOPOB, COUNT(GRUPOPOB) CANT  FROM (
SELECT DISTINCT DOCUMENTO,GRUPOPOB, 'GRUPOPOB' TIPO FROM RESULTADOENCUESTA
WHERE CAST(FECHA AS DATE) BETWEEN @FECHA1 AND @FECHA2 ) Z
GROUP BY TIPO , GRUPOPOB", e);
            }
            finally
            {
                conn.cn.Close();
                cmd.Dispose();
            }
            return dt;
        }
        public static DataTable graficaAfiEncuestadosServicioConsultaExterna(DateTime fechainicial, DateTime fechafinal)
        {
            DConexion conn = new DConexion();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(@"SELECT TIPO,EVALUADO,   
  [Muy Buena], [Buena], [Regular], [Malo], [Muy Malo]
FROM  
(
SELECT TIPO,EVALUADO, VALOR  FROM (
SELECT  EVALUADO,VALOR, 'Servicio Urgencia' TIPO FROM RESULTADOENCUESTA
WHERE CAST(FECHA AS DATE) BETWEEN @FECHA1 AND @FECHA2 
AND SERVICIO='Consulta Externa') Z
) AS SourceTable  
PIVOT  
(  
  COUNT(VALOR)

  FOR VALOR IN ([Muy Buena], [Buena], [Regular], [Malo], [Muy Malo])  
) AS PivotTable ", conn.cn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@FECHA1", fechainicial);
            cmd.Parameters.AddWithValue("@FECHA2", fechafinal);

            try
            {
                conn.cn.Open();
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception e)
            {
                throw new Exception(@"SELECT TIPO,GRUPOPOB, COUNT(GRUPOPOB) CANT  FROM (
SELECT DISTINCT DOCUMENTO,GRUPOPOB, 'GRUPOPOB' TIPO FROM RESULTADOENCUESTA
WHERE CAST(FECHA AS DATE) BETWEEN @FECHA1 AND @FECHA2 ) Z
GROUP BY TIPO , GRUPOPOB", e);
            }
            finally
            {
                conn.cn.Close();
                cmd.Dispose();
            }
            return dt;
        }
        public static DataTable graficaAfiEncuestadosServicioCirugia(DateTime fechainicial, DateTime fechafinal)
        {
            DConexion conn = new DConexion();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(@"SELECT TIPO,EVALUADO,   
  [Muy Buena], [Buena], [Regular], [Malo], [Muy Malo]
FROM  
(
SELECT TIPO,EVALUADO, VALOR  FROM (
SELECT  EVALUADO,VALOR, 'Servicio Urgencia' TIPO FROM RESULTADOENCUESTA
WHERE CAST(FECHA AS DATE) BETWEEN @FECHA1 AND @FECHA2 
AND SERVICIO='Cirugia') Z
) AS SourceTable  
PIVOT  
(  
  COUNT(VALOR)

  FOR VALOR IN ([Muy Buena], [Buena], [Regular], [Malo], [Muy Malo])  
) AS PivotTable ", conn.cn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@FECHA1", fechainicial);
            cmd.Parameters.AddWithValue("@FECHA2", fechafinal);

            try
            {
                conn.cn.Open();
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception e)
            {
                throw new Exception(@"SELECT TIPO,GRUPOPOB, COUNT(GRUPOPOB) CANT  FROM (
SELECT DISTINCT DOCUMENTO,GRUPOPOB, 'GRUPOPOB' TIPO FROM RESULTADOENCUESTA
WHERE CAST(FECHA AS DATE) BETWEEN @FECHA1 AND @FECHA2 ) Z
GROUP BY TIPO , GRUPOPOB", e);
            }
            finally
            {
                conn.cn.Close();
                cmd.Dispose();
            }
            return dt;
        }
        public static DataTable graficaAfiEncuestadosServicioHospitalizacion(DateTime fechainicial, DateTime fechafinal)
        {
            DConexion conn = new DConexion();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(@"SELECT TIPO,EVALUADO,   
  [Muy Buena], [Buena], [Regular], [Malo], [Muy Malo]
FROM  
(
SELECT TIPO,EVALUADO, VALOR  FROM (
SELECT  EVALUADO,VALOR, 'Servicio Urgencia' TIPO FROM RESULTADOENCUESTA
WHERE CAST(FECHA AS DATE) BETWEEN @FECHA1 AND @FECHA2 
AND SERVICIO='Hospitalizacion') Z
) AS SourceTable  
PIVOT  
(  
  COUNT(VALOR)

  FOR VALOR IN ([Muy Buena], [Buena], [Regular], [Malo], [Muy Malo])  
) AS PivotTable ", conn.cn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@FECHA1", fechainicial);
            cmd.Parameters.AddWithValue("@FECHA2", fechafinal);

            try
            {
                conn.cn.Open();
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception e)
            {
                throw new Exception(@"SELECT TIPO,GRUPOPOB, COUNT(GRUPOPOB) CANT  FROM (
SELECT DISTINCT DOCUMENTO,GRUPOPOB, 'GRUPOPOB' TIPO FROM RESULTADOENCUESTA
WHERE CAST(FECHA AS DATE) BETWEEN @FECHA1 AND @FECHA2 ) Z
GROUP BY TIPO , GRUPOPOB", e);
            }
            finally
            {
                conn.cn.Close();
                cmd.Dispose();
            }
            return dt;
        }
        public static DataTable graficaAfiEncuestadosOtrosEvaluados(DateTime fechainicial, DateTime fechafinal)
        {
            DConexion conn = new DConexion();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(@"SELECT TIPO,EVALUADO,   
  [Muy Buena], [Buena], [Regular], [Malo], [Muy Malo]
FROM  
(
SELECT TIPO,EVALUADO, VALOR  FROM (
SELECT  EVALUADO,VALOR, 'Servicio Urgencia' TIPO FROM RESULTADOENCUESTA
WHERE CAST(FECHA AS DATE) BETWEEN @FECHA1 AND @FECHA2 
AND SERVICIO='' AND EVALUADO<>'') Z
) AS SourceTable  
PIVOT  
(  
  COUNT(VALOR)

  FOR VALOR IN ([Muy Buena], [Buena], [Regular], [Malo], [Muy Malo])  
) AS PivotTable ", conn.cn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@FECHA1", fechainicial);
            cmd.Parameters.AddWithValue("@FECHA2", fechafinal);

            try
            {
                conn.cn.Open();
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception e)
            {
                throw new Exception(@"SELECT TIPO,GRUPOPOB, COUNT(GRUPOPOB) CANT  FROM (
SELECT DISTINCT DOCUMENTO,GRUPOPOB, 'GRUPOPOB' TIPO FROM RESULTADOENCUESTA
WHERE CAST(FECHA AS DATE) BETWEEN @FECHA1 AND @FECHA2 ) Z
GROUP BY TIPO , GRUPOPOB", e);
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