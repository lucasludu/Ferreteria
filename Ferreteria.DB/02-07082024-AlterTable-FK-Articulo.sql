IF EXISTS (SELECT 1 FROM sys.tables WHERE name LIKE 'Articulo')
BEGIN
	IF EXISTS (SELECT 1 FROM sys.tables WHERE name LIKE 'Categoria')
	BEGIN
		ALTER TABLE [dbo].[Articulo] 
		ADD CONSTRAINT fk_articulo_Categoria
		FOREIGN KEY (CategoriaId)
		REFERENCES [dbo].[Categoria] (Id)
	END 
END

