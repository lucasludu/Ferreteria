IF EXISTS (SELECT 1 FROM SYS.TABLES WHERE NAME LIKE 'Articulo')
BEGIN
	ALTER TABLE Articulo ADD 
	ProveedorId INT, 
	Activo BIT, 
	CONSTRAINT fk_articulo_proveedor FOREIGN KEY (ProveedorId) REFERENCES Proveedor (Id);
END