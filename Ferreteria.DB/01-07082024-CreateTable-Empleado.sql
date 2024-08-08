IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name LIKE 'Empleado')
BEGIN
	CREATE TABLE [dbo].[Empleado] (
		Id INT IDENTITY(1,1),
		Nombre VARCHAR(50) NOT NULL,
		Correo VARCHAR(50) NOT NULL,
		Password VARCHAR(50) NOT NULL,
		PuestoId INT,
		LocalId INT,
		CONSTRAINT pk_Empleado PRIMARY KEY (Id),
		CONSTRAINT fk_Empleado_Local FOREIGN KEY (LocalId) REFERENCES [dbo].[Local] (Id)
	);
END