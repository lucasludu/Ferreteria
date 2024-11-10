IF EXISTS (SELECT 1 FROM SYS.TABLES WHERE NAME LIKE 'Articulo')
BEGIN
	EXEC sp_rename 'Articulo.Descripcion', 'Marca', 'COLUMN';
END