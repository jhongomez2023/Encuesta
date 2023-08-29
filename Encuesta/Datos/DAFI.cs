using System.Data;
using System.Data.SqlClient;
using Encuesta.TipoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Encuesta.Datos
{
    public class DAFI
    {


        public static DataTable GetAll(string documento)
        {
            DConexion conn = new DConexion();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(@"SELECT NOMBREAFI, DOCIDAFILIADO,EDAD , AFI.DIRECCION ,COALESCE(TELEFONORES, CELULAR) TELEFONO,TER.RAZONSOCIAL EAPB, TGEN.DESCRIPCION GRUPOPOB,
COALESCE(PRO.PROCEDENCIA,'No Aplica') PROCEDENCIA
FROM AFI LEFT JOIN TGEN ON TGEN.CODIGO=AFI.GRUPOPOB AND TGEN.CAMPO='GRUPOPOB' AND TGEN.TABLA='General'
		 LEFT JOIN TER ON AFI.IDADMINISTRADORA=TER.IDTERCERO		 
		 LEFT JOIN (SELECT ROW_NUMBER()OVER (ORDER BY FECHA DESC) ITEM, FECHA, Z.IDAFILIADO , Z.PROCEDENCIA  
					FROM (
						SELECT  FECHA, IDAFILIADO,'Consulta Externa' PROCEDENCIA FROM AUT
						WHERE ESTADO='Pendiente'
						UNION ALL
						SELECT FECHA , IDAFILIADO, 'Consulta Externa'  FROM CIT 
						WHERE COALESCE(IDAFILIADO,'')<>'' AND CUMPLIDA=1
						UNION ALL
						SELECT HADM.FECHA , HADM.IDAFILIADO,
						CASE WHEN AFU.IDAREA='01' THEN 'Urgencia'
							 WHEN AFU.IDAREA='07' THEN 'Cirugia'
							 WHEN AFU.IDAREA='10' THEN 'Hospitalizacion'
							 WHEN AFU.IDAREA='08' THEN 'Uci' END PROCEDENCIA  
						FROM HADM INNER JOIN HHAB ON HHAB.HABCAMA=HADM.HABCAMA
								  INNER JOIN AFU ON AFU.IDAREA=HHAB.IDAREA

						WHERE HHAB.CLASE='Cama'

						)Z INNER JOIN AFI ON AFI.IDAFILIADO=Z.IDAFILIADO
						WHERE AFI.DOCIDAFILIADO=@DOCUMENTO ) PRO ON PRO.IDAFILIADO=AFI.IDAFILIADO AND ITEM=1

WHERE AFI.DOCIDAFILIADO=@DOCUMENTO", conn.cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@DOCUMENTO", documento);

            try
            {
                conn.cn.Open();
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception e)
            {
                throw new Exception(@"SELECT NOMBREAFI, DOCIDAFILIADO,EDAD , AFI.DIRECCION ,COALESCE(TELEFONORES, CELULAR) TELEFONO,TER.RAZONSOCIAL EAPB, TGEN.DESCRIPCION GRUPOPOB,
COALESCE(PRO.PROCEDENCIA,'No Aplica') PROCEDENCIA
FROM AFI LEFT JOIN TGEN ON TGEN.CODIGO=AFI.GRUPOPOB AND TGEN.CAMPO='GRUPOPOB' AND TGEN.TABLA='General'
		 LEFT JOIN TER ON AFI.IDADMINISTRADORA=TER.IDTERCERO		 
		 LEFT JOIN (SELECT ROW_NUMBER()OVER (ORDER BY FECHA DESC) ITEM, FECHA, Z.IDAFILIADO , Z.PROCEDENCIA  
					FROM (
						SELECT  FECHA, IDAFILIADO,'Consulta Externa' PROCEDENCIA FROM AUT
						WHERE ESTADO='Pendiente'
						UNION ALL
						SELECT FECHA , IDAFILIADO, 'Consulta Externa'  FROM CIT 
						WHERE COALESCE(IDAFILIADO,'')<>'' AND CUMPLIDA=1
						UNION ALL
						SELECT HADM.FECHA , HADM.IDAFILIADO,
						CASE WHEN AFU.IDAREA='01' THEN 'Urgencia'
							 WHEN AFU.IDAREA='07' THEN 'Cirugia'
							 WHEN AFU.IDAREA='10' THEN 'Hospitalizacion'
							 WHEN AFU.IDAREA='08' THEN 'Uci' END PROCEDENCIA  
						FROM HADM INNER JOIN HHAB ON HHAB.HABCAMA=HADM.HABCAMA
								  INNER JOIN AFU ON AFU.IDAREA=HHAB.IDAREA

						WHERE HHAB.CLASE='Cama'

						)Z INNER JOIN AFI ON AFI.IDAFILIADO=Z.IDAFILIADO
						WHERE AFI.DOCIDAFILIADO=@DOCUMENTO ) PRO ON PRO.IDAFILIADO=AFI.IDAFILIADO AND ITEM=1

WHERE AFI.DOCIDAFILIADO=@DOCUMENTO", e);
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