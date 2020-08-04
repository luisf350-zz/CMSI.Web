CREATE TABLE [dbo].[PorcentajeProfesional]
(
	Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	ProfesionalId UNIQUEIDENTIFIER NOT NULL,
	ProcedimientoId UNIQUEIDENTIFIER NOT NULL,
	Porcentaje FLOAT NOT NULL,
	FechaCreacion DATETIME NOT NULL,
	FechaModificacion DATETIME NOT NULL
)
GO

ALTER TABLE [dbo].[PorcentajeProfesional]  ADD  CONSTRAINT [FK_PorcentajeProfesional_Profesional] FOREIGN KEY([ProfesionalId])
REFERENCES [dbo].[Profesionales] ([Id])
GO

ALTER TABLE [dbo].[PorcentajeProfesional]  ADD  CONSTRAINT [FK_PorcentajeProfesional_Procedimientos] FOREIGN KEY([ProcedimientoId])
REFERENCES [dbo].[Procedimientos] ([Id])
GO