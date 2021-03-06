
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/30/2012 21:40:40
-- Generated from EDMX file: G:\Documentos\Visual Studio 2010\Projects\TC_Mantelli_Sole\Modelo_Entidades\ModeloSeguridad.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SEGURIDAD];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_FORMULARIOS_MODULOS]', 'F') IS NOT NULL
	ALTER TABLE [dbo].[FORMULARIOS] DROP CONSTRAINT [FK_FORMULARIOS_MODULOS];
GO
IF OBJECT_ID(N'[dbo].[FK_FORMULARIOS_PERMISOS_FORMULARIOS]', 'F') IS NOT NULL
	ALTER TABLE [dbo].[FORMULARIOS_PERMISOS] DROP CONSTRAINT [FK_FORMULARIOS_PERMISOS_FORMULARIOS];
GO
IF OBJECT_ID(N'[dbo].[FK_FORMULARIOS_PERMISOS_PERMISOS]', 'F') IS NOT NULL
	ALTER TABLE [dbo].[FORMULARIOS_PERMISOS] DROP CONSTRAINT [FK_FORMULARIOS_PERMISOS_PERMISOS];
GO
IF OBJECT_ID(N'[dbo].[FK_PERFILES_FORMULARIOS]', 'F') IS NOT NULL
	ALTER TABLE [dbo].[PERFILES] DROP CONSTRAINT [FK_PERFILES_FORMULARIOS];
GO
IF OBJECT_ID(N'[dbo].[FK_PERFILES_GRUPOS]', 'F') IS NOT NULL
	ALTER TABLE [dbo].[PERFILES] DROP CONSTRAINT [FK_PERFILES_GRUPOS];
GO
IF OBJECT_ID(N'[dbo].[FK_PERFILES_PERMISOS]', 'F') IS NOT NULL
	ALTER TABLE [dbo].[PERFILES] DROP CONSTRAINT [FK_PERFILES_PERMISOS];
GO
IF OBJECT_ID(N'[dbo].[FK_USUARIOS_GRUPOS_GRUPOS]', 'F') IS NOT NULL
	ALTER TABLE [dbo].[USUARIOS_GRUPOS] DROP CONSTRAINT [FK_USUARIOS_GRUPOS_GRUPOS];
GO
IF OBJECT_ID(N'[dbo].[FK_USUARIOS_GRUPOS_USUARIOS]', 'F') IS NOT NULL
	ALTER TABLE [dbo].[USUARIOS_GRUPOS] DROP CONSTRAINT [FK_USUARIOS_GRUPOS_USUARIOS];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FORMULARIOS]', 'U') IS NOT NULL
	DROP TABLE [dbo].[FORMULARIOS];
GO
IF OBJECT_ID(N'[dbo].[FORMULARIOS_PERMISOS]', 'U') IS NOT NULL
	DROP TABLE [dbo].[FORMULARIOS_PERMISOS];
GO
IF OBJECT_ID(N'[dbo].[GRUPOS]', 'U') IS NOT NULL
	DROP TABLE [dbo].[GRUPOS];
GO
IF OBJECT_ID(N'[dbo].[MODULOS]', 'U') IS NOT NULL
	DROP TABLE [dbo].[MODULOS];
GO
IF OBJECT_ID(N'[dbo].[PERFILES]', 'U') IS NOT NULL
	DROP TABLE [dbo].[PERFILES];
GO
IF OBJECT_ID(N'[dbo].[PERMISOS]', 'U') IS NOT NULL
	DROP TABLE [dbo].[PERMISOS];
GO
IF OBJECT_ID(N'[dbo].[USUARIOS]', 'U') IS NOT NULL
	DROP TABLE [dbo].[USUARIOS];
GO
IF OBJECT_ID(N'[dbo].[USUARIOS_GRUPOS]', 'U') IS NOT NULL
	DROP TABLE [dbo].[USUARIOS_GRUPOS];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'FORMULARIOS'
CREATE TABLE [dbo].[FORMULARIOS] (
	[FRM_CODIGO] nvarchar(10)  NOT NULL,
	[FRM_DESCRIPCION] nvarchar(50)  NULL,
	[FRM_MODULO] nvarchar(10)  NULL,
	[FRM_FORMULARIO] nvarchar(50)  NULL
);
GO

-- Creating table 'GRUPOS'
CREATE TABLE [dbo].[GRUPOS] (
	[GRU_CODIGO] nvarchar(10)  NOT NULL,
	[GRU_DESCRIPCION] nvarchar(50)  NULL,
	[GRU_ESTADO] bit  NULL
);
GO

-- Creating table 'MODULOS'
CREATE TABLE [dbo].[MODULOS] (
	[MOD_CODIGO] nvarchar(10)  NOT NULL,
	[MOD_DESCRIPCION] nvarchar(50)  NULL
);
GO

-- Creating table 'PERFILES'
CREATE TABLE [dbo].[PERFILES] (
	[PRF_CODIGO] int IDENTITY(1,1) NOT NULL,
	[FRM_CODIGO] nvarchar(10)  NULL,
	[GRU_CODIGO] nvarchar(10)  NULL,
	[PER_CODIGO] nvarchar(5)  NULL,
	[AU_USUARIO] nvarchar(15)  NULL,
	[AU_FECHA] datetime  NULL,
	[AU_MOVIMIENTO] nvarchar(10)  NULL
);
GO

-- Creating table 'PERMISOS'
CREATE TABLE [dbo].[PERMISOS] (
	[PER_CODIGO] nvarchar(5)  NOT NULL,
	[PER_DESCRIPCION] nvarchar(30)  NULL
);
GO

-- Creating table 'USUARIOS'
CREATE TABLE [dbo].[USUARIOS] (
	[USU_CODIGO] nvarchar(15)  NOT NULL,
	[USU_CLAVE] nvarchar(32)  NULL,
	[USU_APELLIDO] nvarchar(30)  NOT NULL,
	[USU_NOMBRE] nvarchar(30)  NULL,
	[USU_EMAIL] nvarchar(60)  NOT NULL,
	[USU_ESTADO] bit  NULL
);
GO

-- Creating table 'FORMULARIOS_PERMISOS'
CREATE TABLE [dbo].[FORMULARIOS_PERMISOS] (
	[FORMULARIOS_FRM_CODIGO] nvarchar(10)  NOT NULL,
	[PERMISOS_PER_CODIGO] nvarchar(5)  NOT NULL
);
GO

-- Creating table 'USUARIOS_GRUPOS'
CREATE TABLE [dbo].[USUARIOS_GRUPOS] (
	[GRUPOS_GRU_CODIGO] nvarchar(10)  NOT NULL,
	[USUARIOS_USU_CODIGO] nvarchar(15)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [FRM_CODIGO] in table 'FORMULARIOS'
ALTER TABLE [dbo].[FORMULARIOS]
ADD CONSTRAINT [PK_FORMULARIOS]
	PRIMARY KEY CLUSTERED ([FRM_CODIGO] ASC);
GO

-- Creating primary key on [GRU_CODIGO] in table 'GRUPOS'
ALTER TABLE [dbo].[GRUPOS]
ADD CONSTRAINT [PK_GRUPOS]
	PRIMARY KEY CLUSTERED ([GRU_CODIGO] ASC);
GO

-- Creating primary key on [MOD_CODIGO] in table 'MODULOS'
ALTER TABLE [dbo].[MODULOS]
ADD CONSTRAINT [PK_MODULOS]
	PRIMARY KEY CLUSTERED ([MOD_CODIGO] ASC);
GO

-- Creating primary key on [PRF_CODIGO] in table 'PERFILES'
ALTER TABLE [dbo].[PERFILES]
ADD CONSTRAINT [PK_PERFILES]
	PRIMARY KEY CLUSTERED ([PRF_CODIGO] ASC);
GO

-- Creating primary key on [PER_CODIGO] in table 'PERMISOS'
ALTER TABLE [dbo].[PERMISOS]
ADD CONSTRAINT [PK_PERMISOS]
	PRIMARY KEY CLUSTERED ([PER_CODIGO] ASC);
GO

-- Creating primary key on [USU_CODIGO] in table 'USUARIOS'
ALTER TABLE [dbo].[USUARIOS]
ADD CONSTRAINT [PK_USUARIOS]
	PRIMARY KEY CLUSTERED ([USU_CODIGO] ASC);
GO

-- Creating primary key on [FORMULARIOS_FRM_CODIGO], [PERMISOS_PER_CODIGO] in table 'FORMULARIOS_PERMISOS'
ALTER TABLE [dbo].[FORMULARIOS_PERMISOS]
ADD CONSTRAINT [PK_FORMULARIOS_PERMISOS]
	PRIMARY KEY NONCLUSTERED ([FORMULARIOS_FRM_CODIGO], [PERMISOS_PER_CODIGO] ASC);
GO

-- Creating primary key on [GRUPOS_GRU_CODIGO], [USUARIOS_USU_CODIGO] in table 'USUARIOS_GRUPOS'
ALTER TABLE [dbo].[USUARIOS_GRUPOS]
ADD CONSTRAINT [PK_USUARIOS_GRUPOS]
	PRIMARY KEY NONCLUSTERED ([GRUPOS_GRU_CODIGO], [USUARIOS_USU_CODIGO] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [FRM_MODULO] in table 'FORMULARIOS'
ALTER TABLE [dbo].[FORMULARIOS]
ADD CONSTRAINT [FK_FORMULARIOS_MODULOS]
	FOREIGN KEY ([FRM_MODULO])
	REFERENCES [dbo].[MODULOS]
		([MOD_CODIGO])
	ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FORMULARIOS_MODULOS'
CREATE INDEX [IX_FK_FORMULARIOS_MODULOS]
ON [dbo].[FORMULARIOS]
	([FRM_MODULO]);
GO

-- Creating foreign key on [FRM_CODIGO] in table 'PERFILES'
ALTER TABLE [dbo].[PERFILES]
ADD CONSTRAINT [FK_PERFILES_FORMULARIOS]
	FOREIGN KEY ([FRM_CODIGO])
	REFERENCES [dbo].[FORMULARIOS]
		([FRM_CODIGO])
	ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PERFILES_FORMULARIOS'
CREATE INDEX [IX_FK_PERFILES_FORMULARIOS]
ON [dbo].[PERFILES]
	([FRM_CODIGO]);
GO

-- Creating foreign key on [GRU_CODIGO] in table 'PERFILES'
ALTER TABLE [dbo].[PERFILES]
ADD CONSTRAINT [FK_PERFILES_GRUPOS]
	FOREIGN KEY ([GRU_CODIGO])
	REFERENCES [dbo].[GRUPOS]
		([GRU_CODIGO])
	ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PERFILES_GRUPOS'
CREATE INDEX [IX_FK_PERFILES_GRUPOS]
ON [dbo].[PERFILES]
	([GRU_CODIGO]);
GO

-- Creating foreign key on [PER_CODIGO] in table 'PERFILES'
ALTER TABLE [dbo].[PERFILES]
ADD CONSTRAINT [FK_PERFILES_PERMISOS]
	FOREIGN KEY ([PER_CODIGO])
	REFERENCES [dbo].[PERMISOS]
		([PER_CODIGO])
	ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PERFILES_PERMISOS'
CREATE INDEX [IX_FK_PERFILES_PERMISOS]
ON [dbo].[PERFILES]
	([PER_CODIGO]);
GO

-- Creating foreign key on [FORMULARIOS_FRM_CODIGO] in table 'FORMULARIOS_PERMISOS'
ALTER TABLE [dbo].[FORMULARIOS_PERMISOS]
ADD CONSTRAINT [FK_FORMULARIOS_PERMISOS_FORMULARIOS]
	FOREIGN KEY ([FORMULARIOS_FRM_CODIGO])
	REFERENCES [dbo].[FORMULARIOS]
		([FRM_CODIGO])
	ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PERMISOS_PER_CODIGO] in table 'FORMULARIOS_PERMISOS'
ALTER TABLE [dbo].[FORMULARIOS_PERMISOS]
ADD CONSTRAINT [FK_FORMULARIOS_PERMISOS_PERMISOS]
	FOREIGN KEY ([PERMISOS_PER_CODIGO])
	REFERENCES [dbo].[PERMISOS]
		([PER_CODIGO])
	ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FORMULARIOS_PERMISOS_PERMISOS'
CREATE INDEX [IX_FK_FORMULARIOS_PERMISOS_PERMISOS]
ON [dbo].[FORMULARIOS_PERMISOS]
	([PERMISOS_PER_CODIGO]);
GO

-- Creating foreign key on [GRUPOS_GRU_CODIGO] in table 'USUARIOS_GRUPOS'
ALTER TABLE [dbo].[USUARIOS_GRUPOS]
ADD CONSTRAINT [FK_USUARIOS_GRUPOS_GRUPOS]
	FOREIGN KEY ([GRUPOS_GRU_CODIGO])
	REFERENCES [dbo].[GRUPOS]
		([GRU_CODIGO])
	ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [USUARIOS_USU_CODIGO] in table 'USUARIOS_GRUPOS'
ALTER TABLE [dbo].[USUARIOS_GRUPOS]
ADD CONSTRAINT [FK_USUARIOS_GRUPOS_USUARIOS]
	FOREIGN KEY ([USUARIOS_USU_CODIGO])
	REFERENCES [dbo].[USUARIOS]
		([USU_CODIGO])
	ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_USUARIOS_GRUPOS_USUARIOS'
CREATE INDEX [IX_FK_USUARIOS_GRUPOS_USUARIOS]
ON [dbo].[USUARIOS_GRUPOS]
	([USUARIOS_USU_CODIGO]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------