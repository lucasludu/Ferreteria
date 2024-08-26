IF NOT EXISTS (SELECT 1 FROM SYS.TABLES WHERE NAME LIKE '[dbo].[Local_Historico]')
BEGIN
	CREATE TABLE [dbo].[Local_Historico] (
		Id INT IDENTITY(1,1),
		IdLocal INT,
		Nombre VARCHAR(50) NOT NULL,
		Direccion VARCHAR(50) NOT NULL,
		Telefono VARCHAR(50) NOT NULL,
		FechaModif DATETIME,
		CONSTRAINT pk_LocalHistorico PRIMARY KEY (Id)
	);
END

