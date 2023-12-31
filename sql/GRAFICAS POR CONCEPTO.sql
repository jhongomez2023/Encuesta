--SELECT * FROM AFI WHERE DOCIDAFILIADO 

DECLARE @FECHA1 DATETIME ='01/07/2022', @FECHA2 DATETIME='31/07/2022' 

SELECT TIPO, EAPB, COUNT(EAPB) CANT FROM (
SELECT DISTINCT DOCUMENTO,CASE WHEN PPT.IDPLAN='ASE' THEN 'SOAT' ELSE TER.RAZONSOCIAL END EAPB, 'EAPB' TIPO 
FROM RESULTADOENCUESTA INNER JOIN AFI ON AFI.DOCIDAFILIADO=RESULTADOENCUESTA.DOCUMENTO
					   INNER JOIN TER ON TER.IDTERCERO=AFI.IDADMINISTRADORA
					   INNER JOIN PPT ON PPT.IDTERCERO=TER.IDTERCERO
					  
WHERE CAST(FECHA AS DATE) BETWEEN @FECHA1 AND @FECHA2 ) Z
GROUP BY TIPO, EAPB

UNION ALL
SELECT TIPO,GRUPOPOB, COUNT(GRUPOPOB) CANT  FROM (
SELECT DISTINCT DOCUMENTO,GRUPOPOB, 'GRUPOPOB' TIPO FROM RESULTADOENCUESTA
WHERE CAST(FECHA AS DATE) BETWEEN @FECHA1 AND @FECHA2 ) Z
GROUP BY TIPO , GRUPOPOB
UNION ALL

SELECT TIPO,PREGUNTA, COUNT(PREGUNTA) CANT  FROM (
SELECT DISTINCT DOCUMENTO,PREGUNTA, 'Otros' TIPO FROM RESULTADOENCUESTA
WHERE CAST(FECHA AS DATE) BETWEEN @FECHA1 AND @FECHA2 AND EVALUADO='' AND SERVICIO='') Z
GROUP BY TIPO , PREGUNTA

SELECT * FROM RESULTADOENCUESTA 
