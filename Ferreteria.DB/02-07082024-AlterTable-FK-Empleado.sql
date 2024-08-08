IF EXISTS (SELECT 1 FROM sys.tables WHERE name IN ('Empleado', 'Puesto'))
BEGIN
	ALTER TABLE [dbo].[Empleado]
	ADD CONSTRAINT fk_Empleado_Puesto
	FOREIGN KEY (PuestoId)
	REFERENCES [dbo].[Puesto] (Id)
END