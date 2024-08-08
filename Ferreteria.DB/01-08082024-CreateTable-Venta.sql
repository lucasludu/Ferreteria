IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name LIKE 'Venta')
BEGIN
	CREATE TABLE [dbo].[Venta] (
		Id INT IDENTITY(1,1),
		LocalId INT,
		ArticuloId INT,
		Importe DECIMAL(18,2) NOT NULL,
		Unidad INT NOT NULL,
		FechaVta DATETIME,
		CONSTRAINT pk_Venta PRIMARY KEY (Id),
		CONSTRAINT fk_Venta_Local FOREIGN KEY (LocalId) REFERENCES [dbo].[Local] (Id),
		CONSTRAINT fk_Venta_Articulo FOREIGN KEY (ArticuloId) REFERENCES [dbo].[Articulo] (Id)
	);
END