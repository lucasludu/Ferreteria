IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name LIKE 'Puesto')
BEGIN
	CREATE TABLE [dbo].[Puesto] (
		Id INT IDENTITY(1,1),
		Nombre VARCHAR(50) NOT NULL,
		CONSTRAINT pk_Puesto PRIMARY KEY (Id),
	);
END