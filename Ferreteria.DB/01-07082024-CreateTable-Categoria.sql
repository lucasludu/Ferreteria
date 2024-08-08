IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name LIKE 'Categoria')
BEGIN
	CREATE TABLE Categoria (
		Id INT IDENTITY(1,1),
		Nombre VARCHAR(50) NOT NULL,
		CONSTRAINT pk_Categoria PRIMARY KEY (Id)
	);
END