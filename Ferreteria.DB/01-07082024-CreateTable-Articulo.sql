IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name LIKE 'Articulo')
BEGIN
	CREATE TABLE Articulo (
		Id INT IDENTITY(1,1),
		Nombre VARCHAR(50) NOT NULL,
		Descripcion VARCHAR(50) NOT NULL,
		Precio DECIMAL(18,2) NOT NULL,
		Stock INT NOT NULL,
		CategoriaId INT
		CONSTRAINT pk_Articulo PRIMARY KEY (Id)
	);
END