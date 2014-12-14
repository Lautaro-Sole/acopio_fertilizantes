use Acopio_Fertilizantes
go

-- Insertar datos en las tablas


insert into dbo.CatClientes values
('YPF', '0054-011-55433465', 'contacto@ypf.com.ar'),
('Petrobras', '0054-011-44934212', 'contacto@petrobras.com.ar')
	
insert into dbo.CatChoferes values 
('Rua', 'Miguel', 25452125, 'DNI'),
('Wëber', 'Alan', 30254584, 'DNI'),
('Cortez', 'Guillermo', 28770884, 'DNI'),
('Benitez', 'Carlos', 320145123, 'DNI')

insert into CatTipos_Matricula values
('Patente')

insert into CatTransportes values
('AHM512', 15000, 9725, 1),
('JKL256', 15000, 12125,1),
('ZXC128', 13000, 13000,1),
('YUP064', 15000, 8000, 1)

insert into CatAlmacenes values
('Centro','Junín 1203', 12000, 50000),
('Este','Santa Fe 201', 800, 75000),
('Norte','Entre Ríos 3902', 24000, 60000)

insert into CatProductos values
('Fertilizante en bolsa (de 50 kg)'),
('Fertilizante a granel')

--select * from Clientes_Choferes
-- chofer, cliente
insert into Clientes_Choferes values
(1, 1),
(2, 1),
(2, 2),
(3, 2)

insert into Choferes_Transportes values
(1, 1),
(1, 2),
(2, 2),
(2, 3),
(3, 1),
(3, 3),
(4, 4) 

insert into CatAlquileres values
(0, '08-08-2011', '08-08-2013', 50000, 1, 1),
(1, '08-08-2013', '08-08-2015', 50000, 1, 1),
(1, '09-09-2013', '09-09-2015', 60000, 3, 2),
(1, '08-08-2013', '08-08-2015', 50000, 2, 1),
(1, '09-09-2013', '09-09-2015', 25000, 2, 2)

insert into CatDocumentos values
(1, '10-10-2011 8:27:33', 'Remito', 12000, 1), 
(2, '10-10-2011 8:35:47', 'Remito', 9000, 1),
(3, '08-10-2013 10:12:47', 'Remito', 8000, 2),
(4, '10-11-2013 11:23:47', 'Remito', 10000, 2),
(5, '27-07-2014 15:23:47', 'Remito', 5000, 1),
(6, '31-07-2014 08:12:47', 'Orden de Carga', 3000, 2),
(7, '01-08-2014 09:23:47', 'Orden de Carga', 5000, 2)

insert into dbo.CatEstados_Operacion values
('Ingresa'),
('Rechazado'),
('Autorizado'),
('Finalizado'),
('Cerrado')

insert into dbo.CatTipos_Operacion values
('Carga'),
('Descarga')

--operaciones completas
insert into CatOperaciones(estado, fecha_y_hora_inicio, fecha_y_hora_fin, notas, nro_documento, peso_inicial, peso_final, tipo_documento, tipo_operacion, USU_CODIGO, fecha_y_hora_accion, accion, nro_alquiler, nro_chofer, nro_transporte, nro_cliente) values
(5, '12-10-2011 12:23:14', '12-10-2011 14:33:33', 'Retrasado por piquete.', 1, 25028, 13028, 'Remito', 2, 'debug', '12-10-2011 14:33:33', 'modificacion', 1, 2, 3, 1),
(5, '12-10-2011 14:33:33', '12-10-2011 16:53:43', 'Retrasado por piquete.', 2, 18752, 9752, 'Remito', 2, 'debug', '12-10-2011 16:53:43', 'modificacion', 1, 1, 1, 1),
(5, '10-10-2013 09:27:42', '10-10-2013 20:53:43', 'Nada que destacar.', 3, 20133, 12133, 'Remito', 2, 'debug', '10-10-2013 20:53:43', 'modificacion', 4, 2, 2, 1),
(5, '12-12-2013 12:33:33', '12-12-2013 15:22:53', 'Nada que destacar.', 4, 19735, 9735, 'Remito', 2, 'debug', '12-12-2013 15:22:53', 'modificacion', 5, 3, 1, 2),
(5, '29-07-2014 09:07:05', '29-07-2014 11:28:17', 'Nada que destacar.', 5, 17138, 12138, 'Remito', 2, 'debug', '29-07-2014 11:28:17', 'modificacion', 3, 2, 2, 2),
(5, '31-07-2014 08:03:12', '31-07-2014 11:13:12', 'Nada que destacar.', 6, 12130, 15130, 'Orden de Carga', 1, 'debug', '31-07-2014 11:13:12', 'modificacion', 4, 1, 2, 1)
-- operaciones iniciadas
-- chofer 2, transporte 2, cliente 2
insert into CatOperaciones(estado, fecha_y_hora_inicio, notas, nro_chofer, nro_transporte, nro_cliente, tipo_documento, tipo_operacion, USU_CODIGO, fecha_y_hora_accion, accion) values
(1, '01-08-2014 08:05:03', 'Nada que destacar.', 2, 2, 2,'Orden de Carga', 1, 'debug', '01-08-2014 08:23:03', 'alta') 

--operaciones autorizadas
insert into CatOperaciones(estado, fecha_y_hora_inicio, notas, nro_documento , nro_alquiler, nro_chofer, nro_transporte, nro_cliente, tipo_documento, tipo_operacion, USU_CODIGO, fecha_y_hora_accion, accion) values
(3, '01-08-2014 08:03:03', 'Nada que destacar.', 7, 5, 3, 3, 2,'Orden de Carga', 1, 'debug', '01-08-2014 08:23:03', 'modificacion') 


-- select * from Alquileres_Productos
insert into Alquileres_Productos values
(1, 1, 21000),
(2, 1, 21000),
(4, 2, 8000),
(5, 2, 10000),
(3, 2, 5000)

