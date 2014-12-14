
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 09/10/2012 17:26:21
-- Generated from EDMX file: G:\Documentos\Visual Studio 2010\Projects\TC_Mantelli_Sole\Modelo_Entidades\Modelo_Auditoria.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Modelo_Auditoria];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CatOperaciones_Auditoria]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatOperaciones_Auditoria];
GO
IF OBJECT_ID(N'[dbo].[Log_Historia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Log_Historia];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CatOperaciones_Auditoria'
CREATE TABLE [dbo].[CatOperaciones_Auditoria] (
    [nro_operacion] bigint IDENTITY(1,1) NOT NULL,
    [estado] int NOT NULL,
    [fecha_y_hora_inicio] datetime  NULL,
    [fecha_y_hora_fin] datetime  NULL,
    [notas] nvarchar(320)  NULL,
    [nro_documento] bigint  NULL,
    [peso_inicial] float  NULL,
    [peso_final] float  NULL,
    [tipo_documento] nvarchar(30)  NULL,
    [tipo_operacion] int NOT NULL,
    [USU_CODIGO] nvarchar(15)  NOT NULL,
    [fecha_y_hora_accion] datetime  NOT NULL,
    [accion] nvarchar(50)  NOT NULL,
    [nro_alquiler] int  NULL,
    [nro_chofer] int  NOT NULL,
    [nro_transporte] int  NOT NULL,
    [nro_cliente] int  NOT NULL
);
GO

-- Creating table 'Log_Historia'
CREATE TABLE [dbo].[Log_Historia] (
    [nro_log] bigint IDENTITY(1,1) NOT NULL,
    [USU_CODIGO] varchar(15)  NOT NULL,
    [fecha_y_hora] datetime2  NOT NULL,
    [accion] varchar(10)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [nro_operacion], [USU_CODIGO], [fecha_y_hora_accion] in table 'CatOperaciones_Auditoria'
ALTER TABLE [dbo].[CatOperaciones_Auditoria]
ADD CONSTRAINT [PK_CatOperaciones_Auditoria]
    PRIMARY KEY CLUSTERED ([nro_operacion], [USU_CODIGO], [fecha_y_hora_accion] ASC);
GO

-- Creating primary key on [nro_log], [USU_CODIGO], [fecha_y_hora] in table 'Log_Historia'
ALTER TABLE [dbo].[Log_Historia]
ADD CONSTRAINT [PK_Log_Historia]
    PRIMARY KEY CLUSTERED ([nro_log], [USU_CODIGO], [fecha_y_hora] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------