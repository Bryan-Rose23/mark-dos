/*
	ARCHIVO DE EJECUCION DE PROCEDIMIENTOS CON DATOS
	1.- 21/01/2025	BROSALES	-CREACION DEL ARCHIVO
	2.- 21/01/2025	BROSALES	-EXEC PCDINSERTAR_CARGO
								-EXEC PCDINSERTAR_DEPARTAMENTO
								-EXEC PCDINSERTAR_EMPLEADO
								-EXEC PCDINSERTAR_GRUPO
								-EXEC PCDINSERTAR_USUARIO
								-EXEC PCDINSERTAR_MENU
								-EXEC PCDLISTARMENUS

*/
USE ECOVISA;

EXEC PCDINSERTAR_CARGO 'Gerente';
EXEC PCDINSERTAR_CARGO 'Coordinador de Logística y Mercadeo';
SELECT * FROM TBLCARGO;

EXEC PCDINSERTAR_DEPARTAMENTO 'Gerencia';
EXEC PCDINSERTAR_DEPARTAMENTO 'Logistica y Mercadeo';
SELECT * FROM TBLDEPARTAMENTO;

EXEC PCDINSERTAR_EMPLEADO 'William', 'Jefferson', 'Gaitan', 'Rostran', '0010708000020K', 'Bo. Rene Polanco, de donde fue la casa de la mujer 1/2 C al Norte', 77748181, 'wgaitan00@gmail.com', 1, 1;
SELECT * FROM TBLEMPLEADO;

EXEC PCDINSERTAR_GRUPO 'Administrador';
EXEC PCDINSERTAR_GRUPO 'Gerencia';
EXEC PCDINSERTAR_GRUPO 'Logística y Mercadeo';
SELECT * FROM TBLGRUPO;	

EXECUTE [dbo].[PCDINSERTAR_USUARIO] 'William Gaitan Rostran', 'WGaitan','c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f', 1 ,1, 2
SELECT * FROM TBLUSUARIO;
	
EXEC PCDINSERTAR_MENU 'Inicio', 'Home/Index', 0;
EXEC PCDINSERTAR_MENU 'Administración', null, 0;
EXEC PCDINSERTAR_MENU 'Personal', 'Administracion/Trabajador', 2;
EXEC PCDINSERTAR_MENU 'Departamentos', 'Administracion/Departamentos', 2;
EXEC PCDINSERTAR_MENU 'Ventas', null, 0;
EXEC PCDINSERTAR_MENU 'Inventario', null, 0;
EXEC PCDINSERTAR_MENU 'Catálogos', null, 0;
EXEC PCDINSERTAR_MENU 'Configuración', null, 0;


EXEC PCDINSERTAR_SUCURSAL 'ECOVISA CENTRAL', 'Bo. René Polanco del Centro de Salud Carlos Rugama 30vrs al Oeste.'

EXEC PCDLISTARMENUS;
