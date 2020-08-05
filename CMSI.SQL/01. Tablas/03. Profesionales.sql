CREATE TABLE [dbo].[Profesionales]
(
	Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	TipoDocumentoId UNIQUEIDENTIFIER NOT NULL,
	NroIdentificacion BIGINT NOT NULL,
	Nombres VARCHAR(150) NOT NULL,
	Apellidos VARCHAR(150) NOT NULL,
	Registro VARCHAR(50) NOT NULL,
	Especialidad VARCHAR(150) NOT NULL,
	Observaciones VARCHAR(500) NULL,
	FechaCreacion DATETIME NOT NULL,
	FechaModificacion DATETIME NOT NULL
)
GO

ALTER TABLE [dbo].[Profesionales]  ADD  CONSTRAINT [FK_Profesionales_TipoDocumento] FOREIGN KEY([TipoDocumentoId])
REFERENCES [dbo].[TipoDocumentos] ([Id])
GO