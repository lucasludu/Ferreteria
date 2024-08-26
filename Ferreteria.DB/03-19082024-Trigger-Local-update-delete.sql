IF EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'Local_Trigger_Insert_Update_Delete') AND type IN (N'TR'))
BEGIN
	DROP TRIGGER [dbo].[Local_Trigger_Insert_Update_Delete]
END

GO

CREATE TRIGGER [dbo].[Local_Trigger_Insert_Update_Delete] ON [dbo].[Local] AFTER UPDATE, DELETE
AS 
BEGIN
	DECLARE @IsUpdate BIT

	IF EXISTS (SELECT 1 FROM deleted)
		SET @IsUpdate = 1;
	ELSE
		SET @IsUpdate = 0;

	IF (@IsUpdate = 1)
	BEGIN 

		INSERT INTO [dbo].[Local_Historico] (IdLocal, Nombre, Direccion, Telefono, FechaModif)
		SELECT d.Id, d.Nombre, d.Direccion, d.Telefono, GETDATE()
		FROM deleted d;

	END

END