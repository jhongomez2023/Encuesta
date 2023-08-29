DECLARE @FECHA1 DATETIME ='01/07/2022', @FECHA2 DATETIME='31/07/2022' 
,@SERVICIO VARCHAR(MAX)=''
--URGENCIA
SELECT * FROM(
SELECT TIPO,EVALUADO,   
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
) AS PivotTable 

--UCI
 UNION ALL

 SELECT TIPO,EVALUADO,   
  [Muy Buena], [Buena], [Regular], [Malo], [Muy Malo]
FROM  
(
SELECT TIPO,EVALUADO, VALOR  FROM (
SELECT  EVALUADO,VALOR, 'Servicio Uci' TIPO FROM RESULTADOENCUESTA
WHERE CAST(FECHA AS DATE) BETWEEN @FECHA1 AND @FECHA2 
AND SERVICIO='Uci') Z
) AS SourceTable  
PIVOT  
(  
  COUNT(VALOR)

  FOR VALOR IN ([Muy Buena], [Buena], [Regular], [Malo], [Muy Malo])  
) AS PivotTable
--CIRUGIA
UNION ALL
SELECT TIPO,EVALUADO,   
  [Muy Buena], [Buena], [Regular], [Malo], [Muy Malo]
FROM  
(
SELECT TIPO,EVALUADO, VALOR  FROM (
SELECT  EVALUADO,VALOR, 'Servicio Cirugia' TIPO FROM RESULTADOENCUESTA
WHERE CAST(FECHA AS DATE) BETWEEN @FECHA1 AND @FECHA2 
AND SERVICIO='Cirugia') Z
) AS SourceTable  
PIVOT  
(  
  COUNT(VALOR)

  FOR VALOR IN ([Muy Buena], [Buena], [Regular], [Malo], [Muy Malo])  
) AS PivotTable
--Hospitalizacion
UNION ALL
SELECT TIPO, EVALUADO,   
  [Muy Buena], [Buena], [Regular], [Malo], [Muy Malo]
FROM  
(
SELECT TIPO,EVALUADO, VALOR  FROM (
SELECT  EVALUADO,VALOR, 'Servicio Hospitalizacion' TIPO FROM RESULTADOENCUESTA
WHERE CAST(FECHA AS DATE) BETWEEN @FECHA1 AND @FECHA2 
AND SERVICIO='Hospitalizacion') Z
) AS SourceTable  
PIVOT  
(  
  COUNT(VALOR)

  FOR VALOR IN ([Muy Buena], [Buena], [Regular], [Malo], [Muy Malo])  
) AS PivotTable
--Consulta Externa
UNION ALL
SELECT TIPO, EVALUADO,   
  [Muy Buena], [Buena], [Regular], [Malo], [Muy Malo]
FROM  
(
SELECT TIPO,EVALUADO, VALOR  FROM (
SELECT  EVALUADO,VALOR, 'Servicio Consulta Externa' TIPO FROM RESULTADOENCUESTA
WHERE CAST(FECHA AS DATE) BETWEEN @FECHA1 AND @FECHA2 
AND SERVICIO='Consulta Externa') Z
) AS SourceTable  
PIVOT  
(  
  COUNT(VALOR)

  FOR VALOR IN ([Muy Buena], [Buena], [Regular], [Malo], [Muy Malo])  
) AS PivotTable) SERVICIOS 

WHERE TIPO=CASE WHEN  COALESCE(@SERVICIO,'')='' THEN TIPO ELSE  COALESCE(@SERVICIO,'') END 