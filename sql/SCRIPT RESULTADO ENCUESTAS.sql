CREATE TABLE RESULTADOENCUESTA(

ID  INT IDENTITY (1,1),
FECHA DATETIME  NOT NULL,
DOCUMENTO VARCHAR(20) NOT NULL,
NOMBREAFI VARCHAR(MAX),
EDAD VARCHAR(20),
DIRECCION VARCHAR(MAX),
TELEFONO VARCHAR(MAX),
EAPB VARCHAR(MAX),
GRUPOPOB VARCHAR(MAX), 
ENCUESTA VARCHAR(MAX),
SERVICIO VARCHAR(100),
PREGUNTA VARCHAR(MAX), 
EVALUADO VARCHAR(MAX),
VALOR VARCHAR(MAX))