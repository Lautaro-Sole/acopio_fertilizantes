use SEGURIDAD
go

insert into SEGURIDAD.dbo.USUARIOS values
('admin','21232f297a57a5a743894a0e4a801fc3','apellido','nombre','mail@gmail.com', 1),
('usuario', 'f8032d5cae3de20fcec887f395ec9a6a', 'apellidousuario', 'nombreusuario', 'mail@gmail.com', 1),
('juan', 'a94652aa97c7211ba8954dd15a3cf838',	'Mantel',	'Jean',	'juan.mantelli@gmail.com',	1),
('lucas','dc53fc4f621c80bdc2fa0329a6123708','Vignals','Lucas','lucas_santiagoo@hotmail.com', 1),
('aye','15be96c681f86d5e22721a05dda30a5f','Casamassa','Aye','ayelen.casamassa@hotmail.com', 1),
('debug','ad42f6697b035b7580e4fef93be20b4d','apellido','nombre','lautaro.solemayorga@gmail.com', 1),
('debug2','96fefd1156ed5ff1ec677b321be42a86','apellido','nombre','belengarro31@gmail.com', 1)

insert into SEGURIDAD.dbo.GRUPOS values
('seg','Empleados de Seguridad Patrimonial', 1),
('entrada','Empleados de Control de Entrada', 1),
('carga','Empleados de Carga y Descarga', 1),
('admins','Administradores', 1),
('debug','Debug', 1)

--codigo de grupo, codigo de usuario
insert into SEGURIDAD.dbo.USUARIOS_GRUPOS values
('admins', 'lucas'),
('admins', 'admin'),
('seg', 'aye'),
('carga', 'juan'),
('entrada', 'usuario'),
('debug', 'debug'),
('debug', 'debug2')

insert into SEGURIDAD.dbo.PERMISOS values
('A','ALTA'),
('B','BAJA'),
('C','CONSULTA'),
('E','EXPORTAR'),
('I','IMPRIMIR'),
('M','MODIFICAR'),
('R','RESETEAR'),
('Z','AUTORIZAR'),
('G','REGISTRAR CARGA/DESCARGA')
insert into SEGURIDAD.dbo.MODULOS values
('gestiones','Gestiones'),
('opera','Operaciones'),
('seguridad','Seguridad'),
('informes', 'Informes')
insert into SEGURIDAD.dbo.FORMULARIOS values
('grupos', 'Grupos', 'seguridad', 'frmGrupos'),
('perfiles', 'Perfiles', 'seguridad', 'frmPerfiles'),
('usuarios', 'Usuarios', 'seguridad', 'frmUsuarios'),
('almacenes', 'Almacenes', 'gestiones', 'frmAlmacenes'),
('alquileres', 'Alquileres', 'gestiones', 'frmAlquileres'),
('choferes', 'Choferes', 'gestiones', 'frmChoferes'),
('clientes', 'Clientes', 'gestiones', 'frmClientes'),
('transp', 'Transportes', 'gestiones', 'frmTransportes'),
('regingreso', 'Registro de Ingreso', 'opera', 'frmRegistroIngreso'),
('opera', 'Operaciones', 'opera', 'frmOperaciones') ,
('autorizar', 'Autorizar Operacion', 'opera', 'frmAutorizarOperacion'),
('pesado', 'Pesado', 'opera', 'frmPesado'),
('infvip','Mejores Clientes', 'informes', 'frmInformeVIP'),
('infestalq', 'Estado de alquileres', 'informes', 'frmInformeEstadoAlquileres'),
('inffertmov','Clientes que movieron más fertilizante', 'informes', 'frmInformeFertMovido')

insert into SEGURIDAD.dbo.FORMULARIOS_PERMISOS values
('grupos','A'),
('grupos','B'),
('grupos','C'),
('grupos','M'),
('perfiles','A'),
('perfiles','B'),
('perfiles','C'),
('perfiles','M'),
('usuarios','A'),
('usuarios','B'),
('usuarios','C'),
('usuarios','M'),
('usuarios','R'),
('almacenes','A'),
('almacenes','B'),
('almacenes','C'),
('almacenes','M'),
('alquileres','A'),
('alquileres','B'),
('alquileres','C'),
('alquileres','M'),
('autorizar', 'Z'),
('choferes','A'),
('choferes','B'),
('choferes','C'),
('choferes','M'),
('clientes','A'),
('clientes','B'),
('clientes','C'),
('clientes','M'),
('transp','A'),
('transp','B'),
('transp','C'),
('transp','M'),
('regingreso','A'),
('pesado', 'A'),
('opera','Z'),
('opera','G'),
('opera','C'),
('infvip', 'C'),
('inffertmov', 'C'),
('infestalq', 'C')

insert into SEGURIDAD.dbo.PERFILES values
('grupos','admins','A', 'admin', '06-07-2012','A'),
('grupos','admins','B', 'admin', '06-07-2012','A'),
('grupos','admins','M', 'admin', '06-07-2012','A'),
('grupos','admins','C', 'admin', '06-07-2012','A'),
('perfiles','admins','A', 'admin', '06-07-2012','A'),
('perfiles','admins','B', 'admin', '06-07-2012','A'),
('perfiles','admins','M', 'admin', '06-07-2012','A'),
('perfiles','admins','C', 'admin', '06-07-2012','A'),
('usuarios','admins','A', 'admin', '06-07-2012','A'),
('usuarios','admins','B', 'admin', '06-07-2012','A'),
('usuarios','admins','M', 'admin', '06-07-2012','A'),
('usuarios','admins','R', 'admin', '06-07-2012','A'),
('usuarios','admins','C', 'admin', '06-07-2012','A')

--darle todos los perfiles de gestiones y autorizaciones a seguridad patrimonial
insert into SEGURIDAD.dbo.PERFILES values 
('almacenes','seg','A', 'admin', '06-07-2012','A'),
('almacenes','seg','B', 'admin', '06-07-2012','A'),
('almacenes','seg','M', 'admin', '06-07-2012','A'),
('almacenes','seg','C', 'admin', '06-07-2012','A'),
('alquileres','seg','A', 'admin', '06-07-2012','A'),
('alquileres','seg','B', 'admin', '06-07-2012','A'),
('alquileres','seg','M', 'admin', '06-07-2012','A'),
('alquileres','seg','C', 'admin', '06-07-2012','A'),
('choferes','seg','A', 'admin', '06-07-2012','A'),
('choferes','seg','B', 'admin', '06-07-2012','A'),
('choferes','seg','M', 'admin', '06-07-2012','A'),
('choferes','seg','C', 'admin', '06-07-2012','A'),
('clientes','seg','A', 'admin', '06-07-2012','A'),
('clientes','seg','B', 'admin', '06-07-2012','A'),
('clientes','seg','M', 'admin', '06-07-2012','A'),
('clientes','seg','C', 'admin', '06-07-2012','A'),
('transp','seg','A', 'admin', '06-07-2012','A'),
('transp','seg','B', 'admin', '06-07-2012','A'),
('transp','seg','M', 'admin', '06-07-2012','A'),
('transp','seg','C', 'admin', '06-07-2012','A'),
('opera','seg','Z', 'admin', '06-07-2012','A'),
('opera','seg','C', 'admin', '06-07-2012','A'),
('autorizar', 'seg', 'Z', 'admin', '2012-07-06 00:00:00.000', 'A'),
('infvip','seg','C', 'admin', '06-07-2012','A'),
('inffertmov','seg','C', 'admin', '06-07-2012','A'),
('infestalq','seg','C', 'admin', '06-07-2012','A')

--darle todos los perfiles de registro de ingreso a empleados de ingreso
insert into SEGURIDAD.dbo.PERFILES values
('regingreso','entrada','A', 'admin', '06-07-2012','A')

--darle todos los perfiles de carga y descarga a empleados de carga y descarga
insert into SEGURIDAD.dbo.PERFILES values 
('opera','carga','C', 'admin', '06-07-2012','A'),
('pesado','carga','A', 'admin', '06-07-2012','A')

--darle todos los perfiles a usuario para pruebas
insert into SEGURIDAD.dbo.PERFILES values   
('almacenes','debug','A', 'admin', '06-07-2012','A'),
('almacenes','debug','B', 'admin', '06-07-2012','A'),
('almacenes','debug','M', 'admin', '06-07-2012','A'),
('almacenes','debug','C', 'admin', '06-07-2012','A'),
('alquileres','debug','A', 'admin', '06-07-2012','A'),
('alquileres','debug','B', 'admin', '06-07-2012','A'),
('alquileres','debug','M', 'admin', '06-07-2012','A'),
('alquileres','debug','C', 'admin', '06-07-2012','A'),
('choferes','debug','A', 'admin', '06-07-2012','A'),
('choferes','debug','B', 'admin', '06-07-2012','A'),
('choferes','debug','M', 'admin', '06-07-2012','A'),
('choferes','debug','C', 'admin', '06-07-2012','A'),
('clientes','debug','A', 'admin', '06-07-2012','A'),
('clientes','debug','B', 'admin', '06-07-2012','A'),
('clientes','debug','M', 'admin', '06-07-2012','A'),
('clientes','debug','C', 'admin', '06-07-2012','A'),
('transp','debug','A', 'admin', '06-07-2012','A'),
('transp','debug','B', 'admin', '06-07-2012','A'),
('transp','debug','M', 'admin', '06-07-2012','A'),
('transp','debug','C', 'admin', '06-07-2012','A'),
('regingreso','debug','A', 'admin', '06-07-2012','A'),
('opera','debug','Z', 'admin', '06-07-2012','A'),
('opera','debug','G', 'admin', '06-07-2012','A'),
('opera','debug','C', 'admin', '06-07-2012','A'),
('autorizar', 'debug', 'Z', 'admin', '2012-07-06', 'A'),
('pesado','debug','A', 'admin', '06-07-2012','A'),
('infvip','debug','C', 'admin', '06-07-2012','A'),
('inffertmov','debug','C', 'admin', '06-07-2012','A'),
('infestalq','debug','C', 'admin', '06-07-2012','A'),
('grupos','debug','A', 'admin', '06-07-2012','A'),
('grupos','debug','B', 'admin', '06-07-2012','A'),
('grupos','debug','M', 'admin', '06-07-2012','A'),
('grupos','debug','C', 'admin', '06-07-2012','A'),
('perfiles','debug','A', 'admin', '06-07-2012','A'),
('perfiles','debug','B', 'admin', '06-07-2012','A'),
('perfiles','debug','M', 'admin', '06-07-2012','A'),
('perfiles','debug','C', 'admin', '06-07-2012','A'),
('usuarios','debug','A', 'admin', '06-07-2012','A'),
('usuarios','debug','B', 'admin', '06-07-2012','A'),
('usuarios','debug','M', 'admin', '06-07-2012','A'),
('usuarios','debug','R', 'admin', '06-07-2012','A'),
('usuarios','debug','C', 'admin', '06-07-2012','A')