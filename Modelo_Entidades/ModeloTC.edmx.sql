
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 11/05/2012 15:05:29
-- Generated from EDMX file: G:\Documentos\Visual Studio 2010\Projects\TC_Mantelli_Sole Con Strategy\Modelo_Entidades\ModeloTC.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Acopio_Fertilizantes];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Alquiler_Alquiler_Producto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Alquileres_Productos] DROP CONSTRAINT [FK_Alquiler_Alquiler_Producto];
GO
IF OBJECT_ID(N'[dbo].[FK_Producto_Alquiler_Producto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Alquileres_Productos] DROP CONSTRAINT [FK_Producto_Alquiler_Producto];
GO
IF OBJECT_ID(N'[dbo].[FK_Almacen_Alquiler]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CatAlquileres] DROP CONSTRAINT [FK_Almacen_Alquiler];
GO
IF OBJECT_ID(N'[dbo].[FK_Alquiler_Cliente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CatAlquileres] DROP CONSTRAINT [FK_Alquiler_Cliente];
GO
IF OBJECT_ID(N'[dbo].[FK_Operacion_Alquiler]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CatOperaciones] DROP CONSTRAINT [FK_Operacion_Alquiler];
GO
IF OBJECT_ID(N'[dbo].[FK_Operacion_Chofer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CatOperaciones] DROP CONSTRAINT [FK_Operacion_Chofer];
GO
IF OBJECT_ID(N'[dbo].[FK_Documento_Operacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CatOperaciones] DROP CONSTRAINT [FK_Documento_Operacion];
GO
IF OBJECT_ID(N'[dbo].[FK_Documento_Producto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CatDocumentos] DROP CONSTRAINT [FK_Documento_Producto];
GO
IF OBJECT_ID(N'[dbo].[FK_Operacion_Transporte]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CatOperaciones] DROP CONSTRAINT [FK_Operacion_Transporte];
GO
IF OBJECT_ID(N'[dbo].[FK_Choferes_Transportes_CatChoferes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Choferes_Transportes] DROP CONSTRAINT [FK_Choferes_Transportes_CatChoferes];
GO
IF OBJECT_ID(N'[dbo].[FK_Choferes_Transportes_CatTransportes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Choferes_Transportes] DROP CONSTRAINT [FK_Choferes_Transportes_CatTransportes];
GO
IF OBJECT_ID(N'[dbo].[FK_Clientes_Choferes_CatChoferes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Clientes_Choferes] DROP CONSTRAINT [FK_Clientes_Choferes_CatChoferes];
GO
IF OBJECT_ID(N'[dbo].[FK_Clientes_Choferes_CatClientes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Clientes_Choferes] DROP CONSTRAINT [FK_Clientes_Choferes_CatClientes];
GO
IF OBJECT_ID(N'[dbo].[FK_Cliente_Operacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CatOperaciones] DROP CONSTRAINT [FK_Cliente_Operacion];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Alquileres_Productos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Alquileres_Productos];
GO
IF OBJECT_ID(N'[dbo].[CatAlmacenes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatAlmacenes];
GO
IF OBJECT_ID(N'[dbo].[CatAlquileres]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatAlquileres];
GO
IF OBJECT_ID(N'[dbo].[CatChoferes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatChoferes];
GO
IF OBJECT_ID(N'[dbo].[CatClientes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatClientes];
GO
IF OBJECT_ID(N'[dbo].[CatDocumentos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatDocumentos];
GO
IF OBJECT_ID(N'[dbo].[CatOperaciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatOperaciones];
GO
IF OBJECT_ID(N'[dbo].[CatProductos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatProductos];
GO
IF OBJECT_ID(N'[dbo].[CatTransportes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatTransportes];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Choferes_Transportes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Choferes_Transportes];
GO
IF OBJECT_ID(N'[dbo].[Clientes_Choferes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clientes_Choferes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Alquileres_Productos'
CREATE TABLE [dbo].[Alquileres_Productos] (
    [nro_alquiler] int  NOT NULL,
    [codigo_producto] int  NOT NULL,
    [cantidad_kg] float  NULL
);
GO

-- Creating table 'CatAlmacenes'
CREATE TABLE [dbo].[CatAlmacenes] (
    [nro_almacen] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(60)  NULL,
    [direccion] nvarchar(60)  NULL,
    [distancia_a_empresa] int  NULL,
    [capacidad] float  NULL
);
GO

-- Creating table 'CatAlquileres'
CREATE TABLE [dbo].[CatAlquileres] (
    [nro_alquiler] int IDENTITY(1,1) NOT NULL,
    [estado] bit  NULL,
    [fecha_inicio_alquiler] datetime  NULL,
    [fecha_fin_alquiler] datetime  NULL,
    [capacidad] float  NULL,
    [nro_almacen] int  NOT NULL,
    [nro_cliente] int  NOT NULL
);
GO

-- Creating table 'CatChoferes'
CREATE TABLE [dbo].[CatChoferes] (
    [nro_chofer] int IDENTITY(1,1) NOT NULL,
    [apellido] nvarchar(60)  NULL,
    [nombre] nvarchar(60)  NULL,
    [num_documento] int  NULL,
    [tipo_documento] nvarchar(20)  NULL
);
GO

-- Creating table 'CatClientes'
CREATE TABLE [dbo].[CatClientes] (
    [nro_cliente] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(60)  NULL,
    [telefono] nvarchar(60)  NULL,
    [email] nvarchar(60)  NULL
);
GO

-- Creating table 'CatDocumentos'
CREATE TABLE [dbo].[CatDocumentos] (
    [nro_documento] bigint  NOT NULL,
    [fecha_hora] datetime  NULL,
    [tipo_documento] nvarchar(30)  NOT NULL,
    [peso] float  NULL,
    [codigo_producto] int  NOT NULL
);
GO

-- Creating table 'CatTipos_Operacion'
CREATE TABLE [dbo].[CatTipos_Operacion] (
	[id_tipo_operacion] int IDENTITY(1,1) NOT NULL,
	[descripcion] nvarchar(120) NOT NULL
);
GO

-- Creating table 'CatEstados_Operacion'
CREATE TABLE [dbo].[CatEstados_Operacion] (
	[id_estado_operacion] int IDENTITY(1,1) NOT NULL,
	[descripcion] nvarchar(120) NOT NULL
);
GO

-- Creating table 'CatOperaciones'
CREATE TABLE [dbo].[CatOperaciones] (
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

-- Creating table 'CatProductos'
CREATE TABLE [dbo].[CatProductos] (
    [codigo_producto] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(60)  NOT NULL
);
GO

-- Creating table 'CatTipos_Matricula'
CREATE TABLE [dbo].[CatTipos_Matricula] (
	[id_tipo_matricula] int IDENTITY(1,1) NOT NULL,
	[descripcion] nvarchar(120) NOT NULL
);
GO

-- Creating table 'CatTransportes'
CREATE TABLE [dbo].[CatTransportes] (
    [nro_transporte] int IDENTITY(1,1) NOT NULL,
    [nro_matricula] nvarchar(60) NOT NULL,
    [carga_maxima] float  NULL,
    [tara] float  NULL,
    [tipo_matricula] int NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Choferes_Transportes'
CREATE TABLE [dbo].[Choferes_Transportes] (
    [Choferes_nro_chofer] int  NOT NULL,
    [Transportes_nro_transporte] int  NOT NULL
);
GO

-- Creating table 'Clientes_Choferes'
CREATE TABLE [dbo].[Clientes_Choferes] (
    [Choferes_nro_chofer] int  NOT NULL,
    [Clientes_nro_cliente] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [nro_alquiler], [codigo_producto] in table 'Alquileres_Productos'
ALTER TABLE [dbo].[Alquileres_Productos]
ADD CONSTRAINT [PK_Alquileres_Productos]
    PRIMARY KEY CLUSTERED ([nro_alquiler], [codigo_producto] ASC);
GO

-- Creating primary key on [nro_almacen] in table 'CatAlmacenes'
ALTER TABLE [dbo].[CatAlmacenes]
ADD CONSTRAINT [PK_CatAlmacenes]
    PRIMARY KEY CLUSTERED ([nro_almacen] ASC);
GO

-- Creating primary key on [nro_alquiler] in table 'CatAlquileres'
ALTER TABLE [dbo].[CatAlquileres]
ADD CONSTRAINT [PK_CatAlquileres]
    PRIMARY KEY CLUSTERED ([nro_alquiler] ASC);
GO

-- Creating primary key on [nro_chofer] in table 'CatChoferes'
ALTER TABLE [dbo].[CatChoferes]
ADD CONSTRAINT [PK_CatChoferes]
    PRIMARY KEY CLUSTERED ([nro_chofer] ASC);
GO

-- Creating primary key on [nro_cliente] in table 'CatClientes'
ALTER TABLE [dbo].[CatClientes]
ADD CONSTRAINT [PK_CatClientes]
    PRIMARY KEY CLUSTERED ([nro_cliente] ASC);
GO

-- Creating primary key on [nro_documento], [tipo_documento] in table 'CatDocumentos'
ALTER TABLE [dbo].[CatDocumentos]
ADD CONSTRAINT [PK_CatDocumentos]
    PRIMARY KEY CLUSTERED ([nro_documento], [tipo_documento] ASC);
GO

-- Creating primary key on [id_tipo_operacion] in table 'CatTipos_Operacion'
ALTER TABLE [dbo].CatTipos_Operacion
ADD CONSTRAINT [PK_CatTipos_Operacion]
    PRIMARY KEY CLUSTERED ([id_tipo_operacion] ASC);
GO

-- Creating primary key on [id_estado_operacion] in table 'CatEstados_Operacion'
ALTER TABLE [dbo].CatEstados_Operacion
ADD CONSTRAINT [PK_CatEstados_Operacion]
    PRIMARY KEY CLUSTERED (id_estado_operacion ASC);
GO

-- Creating primary key on [id_tipo_matricula] in table 'CatTipos_Matricula'
ALTER TABLE [dbo].CatTipos_Matricula
ADD CONSTRAINT [PK_CatTipos_Matricula]
    PRIMARY KEY CLUSTERED (id_tipo_matricula ASC);
GO

-- Creating primary key on [nro_operacion] in table 'CatOperaciones'
ALTER TABLE [dbo].[CatOperaciones]
ADD CONSTRAINT [PK_CatOperaciones]
    PRIMARY KEY CLUSTERED ([nro_operacion] ASC);
GO

-- Creating primary key on [codigo_producto] in table 'CatProductos'
ALTER TABLE [dbo].[CatProductos]
ADD CONSTRAINT [PK_CatProductos]
    PRIMARY KEY CLUSTERED ([codigo_producto] ASC);
GO

-- Creating primary key on [nro_transporte] in table 'CatTransportes'
ALTER TABLE [dbo].[CatTransportes]
ADD CONSTRAINT [PK_CatTransportes]
    PRIMARY KEY CLUSTERED ([nro_transporte] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Choferes_nro_chofer], [Transportes_nro_transporte] in table 'Choferes_Transportes'
ALTER TABLE [dbo].[Choferes_Transportes]
ADD CONSTRAINT [PK_Choferes_Transportes]
    PRIMARY KEY NONCLUSTERED ([Choferes_nro_chofer], [Transportes_nro_transporte] ASC);
GO

-- Creating primary key on [Choferes_nro_chofer], [Clientes_nro_cliente] in table 'Clientes_Choferes'
ALTER TABLE [dbo].[Clientes_Choferes]
ADD CONSTRAINT [PK_Clientes_Choferes]
    PRIMARY KEY NONCLUSTERED ([Choferes_nro_chofer], [Clientes_nro_cliente] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [nro_alquiler] in table 'Alquileres_Productos'
ALTER TABLE [dbo].[Alquileres_Productos]
ADD CONSTRAINT [FK_Alquiler_Alquiler_Producto]
    FOREIGN KEY ([nro_alquiler])
    REFERENCES [dbo].[CatAlquileres]
        ([nro_alquiler])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [codigo_producto] in table 'Alquileres_Productos'
ALTER TABLE [dbo].[Alquileres_Productos]
ADD CONSTRAINT [FK_Producto_Alquiler_Producto]
    FOREIGN KEY ([codigo_producto])
    REFERENCES [dbo].[CatProductos]
        ([codigo_producto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Producto_Alquiler_Producto'
CREATE INDEX [IX_FK_Producto_Alquiler_Producto]
ON [dbo].[Alquileres_Productos]
    ([codigo_producto]);
GO

-- Creating foreign key on [nro_almacen] in table 'CatAlquileres'
ALTER TABLE [dbo].[CatAlquileres]
ADD CONSTRAINT [FK_Almacen_Alquiler]
    FOREIGN KEY ([nro_almacen])
    REFERENCES [dbo].[CatAlmacenes]
        ([nro_almacen])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Almacen_Alquiler'
CREATE INDEX [IX_FK_Almacen_Alquiler]
ON [dbo].[CatAlquileres]
    ([nro_almacen]);
GO

-- Creating foreign key on [nro_cliente] in table 'CatAlquileres'
ALTER TABLE [dbo].[CatAlquileres]
ADD CONSTRAINT [FK_Alquiler_Cliente]
    FOREIGN KEY ([nro_cliente])
    REFERENCES [dbo].[CatClientes]
        ([nro_cliente])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Alquiler_Cliente'
CREATE INDEX [IX_FK_Alquiler_Cliente]
ON [dbo].[CatAlquileres]
    ([nro_cliente]);
GO

-- Creating foreign key on [nro_alquiler] in table 'CatOperaciones'
ALTER TABLE [dbo].[CatOperaciones]
ADD CONSTRAINT [FK_Operacion_Alquiler]
    FOREIGN KEY ([nro_alquiler])
    REFERENCES [dbo].[CatAlquileres]
        ([nro_alquiler])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Operacion_Alquiler'
CREATE INDEX [IX_FK_Operacion_Alquiler]
ON [dbo].[CatOperaciones]
    ([nro_alquiler]);
GO

-- Creating foreign key on [nro_chofer] in table 'CatOperaciones'
ALTER TABLE [dbo].[CatOperaciones]
ADD CONSTRAINT [FK_Operacion_Chofer]
    FOREIGN KEY ([nro_chofer])
    REFERENCES [dbo].[CatChoferes]
        ([nro_chofer])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Operacion_Chofer'
CREATE INDEX [IX_FK_Operacion_Chofer]
ON [dbo].[CatOperaciones]
    ([nro_chofer]);
GO

-- Creating foreign key on [nro_documento], [tipo_documento] in table 'CatOperaciones'
ALTER TABLE [dbo].[CatOperaciones]
ADD CONSTRAINT [FK_Documento_Operacion]
    FOREIGN KEY ([nro_documento], [tipo_documento])
    REFERENCES [dbo].[CatDocumentos]
        ([nro_documento], [tipo_documento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Documento_Operacion'
CREATE INDEX [IX_FK_Documento_Operacion]
ON [dbo].[CatOperaciones]
    ([nro_documento], [tipo_documento]);
GO

-- Creating foreign key on [codigo_producto] in table 'CatDocumentos'
ALTER TABLE [dbo].[CatDocumentos]
ADD CONSTRAINT [FK_Documento_Producto]
    FOREIGN KEY ([codigo_producto])
    REFERENCES [dbo].[CatProductos]
        ([codigo_producto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Documento_Producto'
CREATE INDEX [IX_FK_Documento_Producto]
ON [dbo].[CatDocumentos]
    ([codigo_producto]);
GO

-- Creating foreign key on [nro_transporte] in table 'CatOperaciones'
ALTER TABLE [dbo].[CatOperaciones]
ADD CONSTRAINT [FK_Operacion_Transporte]
    FOREIGN KEY ([nro_transporte])
    REFERENCES [dbo].[CatTransportes]
        ([nro_transporte])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Operacion_Transporte'
CREATE INDEX [IX_FK_Operacion_Transporte]
ON [dbo].[CatOperaciones]
    ([nro_transporte]);
GO

-- Creating foreign key on [Choferes_nro_chofer] in table 'Choferes_Transportes'
ALTER TABLE [dbo].[Choferes_Transportes]
ADD CONSTRAINT [FK_Choferes_Transportes_CatChoferes]
    FOREIGN KEY ([Choferes_nro_chofer])
    REFERENCES [dbo].[CatChoferes]
        ([nro_chofer])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Transportes_nro_transporte] in table 'Choferes_Transportes'
ALTER TABLE [dbo].[Choferes_Transportes]
ADD CONSTRAINT [FK_Choferes_Transportes_CatTransportes]
    FOREIGN KEY ([Transportes_nro_transporte])
    REFERENCES [dbo].[CatTransportes]
        ([nro_transporte])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Choferes_Transportes_CatTransportes'
CREATE INDEX [IX_FK_Choferes_Transportes_CatTransportes]
ON [dbo].[Choferes_Transportes]
    ([Transportes_nro_transporte]);
GO

-- Creating foreign key on [Choferes_nro_chofer] in table 'Clientes_Choferes'
ALTER TABLE [dbo].[Clientes_Choferes]
ADD CONSTRAINT [FK_Clientes_Choferes_CatChoferes]
    FOREIGN KEY ([Choferes_nro_chofer])
    REFERENCES [dbo].[CatChoferes]
        ([nro_chofer])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Clientes_nro_cliente] in table 'Clientes_Choferes'
ALTER TABLE [dbo].[Clientes_Choferes]
ADD CONSTRAINT [FK_Clientes_Choferes_CatClientes]
    FOREIGN KEY ([Clientes_nro_cliente])
    REFERENCES [dbo].[CatClientes]
        ([nro_cliente])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Clientes_Choferes_CatClientes'
CREATE INDEX [IX_FK_Clientes_Choferes_CatClientes]
ON [dbo].[Clientes_Choferes]
    ([Clientes_nro_cliente]);
GO

-- Creating foreign key on [nro_cliente] in table 'CatOperaciones'
ALTER TABLE [dbo].[CatOperaciones]
ADD CONSTRAINT [FK_Cliente_Operacion]
    FOREIGN KEY ([nro_cliente])
    REFERENCES [dbo].[CatClientes]
        ([nro_cliente])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Cliente_Operacion'
CREATE INDEX [IX_FK_Cliente_Operacion]
ON [dbo].[CatOperaciones]
    ([nro_cliente]);
GO

-- Creating foreign key on [id_tipo_operacion] in table 'CatOperaciones'
ALTER TABLE [dbo].[CatOperaciones]
ADD CONSTRAINT [FK_Tipo_Operacion_Operacion]
    FOREIGN KEY ([tipo_operacion])
    REFERENCES [dbo].[CatTipos_Operacion]
        ([id_tipo_operacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Cliente_Operacion'
CREATE INDEX [IX_Tipo_Operacion_Operacion]
ON [dbo].[CatOperaciones]
    ([tipo_operacion]);
GO

-- Creating foreign key on [id_estado_operacion] in table 'CatOperaciones'
ALTER TABLE [dbo].[CatOperaciones]
ADD CONSTRAINT [FK_Estado_Operacion_Operacion]
    FOREIGN KEY ([estado])
    REFERENCES [dbo].[CatEstados_Operacion]
        ([id_estado_operacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Cliente_Operacion'
CREATE INDEX [IX_FK_Estado_Operacion_Operacion]
ON [dbo].[CatOperaciones]
    ([estado]);
GO

-- Creating foreign key on [id_estado_operacion] in table 'CatOperaciones'
ALTER TABLE [dbo].[CatTransportes]
ADD CONSTRAINT [FK_Tipo_Matricula_Transporte]
    FOREIGN KEY ([tipo_matricula])
    REFERENCES [dbo].[CatTipos_Matricula]
        ([id_tipo_matricula])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Cliente_Operacion'
CREATE INDEX [IX_FK_Tipo_Matricula_Transporte]
ON [dbo].[CatTransportes]
    ([tipo_matricula]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------