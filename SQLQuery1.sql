 
 /* PRIMERO EJECUTAR SOLO EL CREATE DATABASE */
  CREATE DATABASE CARWASH

USE CARWASH;

 /* TABLA CLIENTE */
CREATE TABLE CLIENTE(
DNI int  not null PRIMARY KEY ,
NOMBRE VARCHAR(20),
APELLIDO VARCHAR(50) not null,
CORREO VARCHAR(50) not null,
TELEFONO NUMERIC(20)
)

 /* TABLA TIPO_SERVICIO */
CREATE TABLE TIPO_SERVICIO(
COD_TIPO_SERV VARCHAR(50)  not null PRIMARY KEY ,
NOMBRE VARCHAR(20) not null,
DESCRIPCION VARCHAR(50)not null
)

 /* TABLA SERVICIO */
CREATE TABLE SERVICIO(
COD_SERVICIO VARCHAR(50)  not null PRIMARY KEY ,
COD_TIPO_SERV VARCHAR(50) not null,
NOMBRE VARCHAR(20) not null,
PRECIO FLOAT,
DURACION smalldatetime not null,
DESCRIPCION VARCHAR(50) not null,
CONSTRAINT FK_SERVICIO_TIPO_SERVICIO FOREIGN  KEY(COD_TIPO_SERV) REFERENCES TIPO_SERVICIO(COD_TIPO_SERV)	
)

 /* TABLA _AUTO */
CREATE TABLE _AUTO(
PLACA VARCHAR(50) not null PRIMARY KEY,
DNI int not null ,
MARCA VARCHAR(30) not null,
MODELO VARCHAR(30) ,
CLASE VARCHAR(20)  ,
NUM_ASI int ,
CONSTRAINT FK_SERVICIO_TIPO_AUTO FOREIGN  KEY(DNI) REFERENCES CLIENTE(DNI)
)


 /* TABLA ORDEN_ATENCION */ 
CREATE TABLE ORDEN_ATENCION(
COD_ORDEN_ATENCION VARCHAR(50)  not null PRIMARY KEY ,
PLACA VARCHAR (50) not null,
DNI int not null,
CONSTRAINT FK_ORDEN_ATENCION_AUTO FOREIGN KEY(PLACA) REFERENCES _AUTO(PLACA),
CONSTRAINT FK_ORDEN_ATENCION_CLIENTE FOREIGN KEY(DNI) REFERENCES CLIENTE(DNI), 
 )


  /* TABLA MARCA_MATERIAL */
CREATE TABLE MARCA_MATERIAL(
COD_MARCA VARCHAR(20)  not null PRIMARY KEY ,
DESCRIPCION VARCHAR(50) not null,
)


 /* TABLA MATERIALES */
CREATE TABLE MATERIALES(
COD_MATE VARCHAR(50)  not null PRIMARY KEY ,
COD_MARCA VARCHAR(20),
DESCRIPCION VARCHAR(50) not null,
PRECI_UNI FLOAT,
FECHA_INGRESO DATE ,
CONSTRAINT FK_MATERIALES_MARCA FOREIGN KEY(COD_MARCA) REFERENCES MARCA_MATERIAL(COD_MARCA), 
)


 /* TABLA REGISTRAR_SERVICIO */
CREATE TABLE REGISTRAR_SERVICIO(
COD_MATE VARCHAR(50)  not null ,
COD_SERVICIO VARCHAR(50)not null,
CANTIDAD INT not null,
 CONSTRAINT FK_REGISTRAR_SERVICIO_MATERIALES FOREIGN KEY(COD_MATE) REFERENCES MATERIALES(COD_MATE), 
 CONSTRAINT FK_REGISTRAR_SERVICIO_SERVICIO FOREIGN KEY(COD_SERVICIO) REFERENCES SERVICIO(COD_SERVICIO), 
)


 /* TABLA DETALLE_ORDEN_ATENCION */
CREATE TABLE DETALLE_ORDEN_ATENCION(
COD_MATE VARCHAR(50)  not null ,
 PLACA VARCHAR(50) not null,
 COD_ORDEN_ATENCION VARCHAR(50)  not null ,
 DNI int  not null,

 CONSTRAINT FK_DETALLE_ORDEN_ATENCION_MATERIALES FOREIGN KEY(COD_MATE) REFERENCES MATERIALES(COD_MATE), 
 CONSTRAINT FK_DETALLE_ORDEN_ATENCION_AUTO FOREIGN KEY(PLACA) REFERENCES _AUTO(PLACA), 
 CONSTRAINT FK_DETALLE_ORDEN_ATENCION_ORDEN_ATENCION FOREIGN KEY(COD_ORDEN_ATENCION) REFERENCES ORDEN_ATENCION(COD_ORDEN_ATENCION), 
 CONSTRAINT FK_DETALLE_ORDEN_ATENCION_CLIENTE FOREIGN KEY(DNI) REFERENCES CLIENTE(DNI), 

)

 /* TABLA TIPO_COMPROBANTE */
CREATE TABLE TIPO_COMPROBANTE(
COD_TIPO_COMPRO VARCHAR(20)  not null PRIMARY KEY ,
DESCRIPCION VARCHAR(50) not null,
)
	


 /* TABLA COMPROBANTE_PAGO */	
CREATE TABLE COMPROBANTE_PAGO(
COD_COMPROBANTE VARCHAR(50) not null PRIMARY KEY ,
COD_ORDEN_ATENCION VARCHAR(50)  not null ,
PLACA VARCHAR(50) not null,
COD_TIPO_COMPRO VARCHAR(20)  not null,
DNI int  not null,

NOMBRE VARCHAR(50) ,
TELEFONO int  ,	
OBSERVACIONES VARCHAR(50),	
IMPORTE_TOT VARCHAR(50) not null,
SUBTOTAL FLOAT,
IGV FLOAT,

 CONSTRAINT FK_COMPROBANTE_PAGO_TIPO_COMPROBANTE FOREIGN KEY(COD_TIPO_COMPRO) REFERENCES TIPO_COMPROBANTE(COD_TIPO_COMPRO), 
 CONSTRAINT FK_COMPROBANTE_PAGO_AUTO FOREIGN KEY(PLACA) REFERENCES _AUTO(PLACA), 
 CONSTRAINT FK_COMPROBANTE_PAGO_ORDEN_ATENCION FOREIGN KEY(COD_ORDEN_ATENCION) REFERENCES ORDEN_ATENCION(COD_ORDEN_ATENCION), 
 CONSTRAINT FK_COMPROBANTE_PAGO_CLIENTE FOREIGN KEY(DNI) REFERENCES CLIENTE(DNI), 
)



 /* TABLA VENTAS_DIARIAS */
CREATE TABLE VENTAS_DIARIAS(
NUM_VENTAS int not null PRIMARY KEY ,
COD_MATE VARCHAR(50)  not null ,
COD_SERVICIO VARCHAR(50)not null,
PLACA VARCHAR(50) not null,
COD_ORDEN_ATENCION VARCHAR(50)  not null ,
DNI int  not null, 
 
FECHA_EMISION DATE ,
OBSERVACIONES VARCHAR(50),	
IMPORTE_TOT VARCHAR(50) not null,
SUBTOTAL FLOAT,
IGV FLOAT,

 
 CONSTRAINT FK_VENTAS_DIARIAS_AUTO FOREIGN KEY(PLACA) REFERENCES _AUTO(PLACA), 
 CONSTRAINT FK_VENTAS_DIARIAS_ORDEN_ATENCION FOREIGN KEY(COD_ORDEN_ATENCION) REFERENCES ORDEN_ATENCION(COD_ORDEN_ATENCION), 
 CONSTRAINT FK_VENTAS_DIARIAS_CLIENTE FOREIGN KEY(DNI) REFERENCES CLIENTE(DNI), 
)

 /* TABLA PROVEEDOR */
CREATE TABLE PROVEEDOR(
RUC int not null PRIMARY KEY ,
RAZON_SOCIAL VARCHAR(50),
TELEFONO int ,
DIRECCION VARCHAR(50),
 
)

  /* TABLA ORDEN_COMPRA */
CREATE TABLE ORDEN_COMPRA(
COD_MATE VARCHAR(50)  not null ,
RUC int not null,

CANTIDAD int,
SUBTOTAL float,
 CONSTRAINT FK_ORDEN_ATENCION_MATERIALES FOREIGN KEY(COD_MATE) REFERENCES MATERIALES(COD_MATE), 
 CONSTRAINT FK_ORDEN_COMPRA_PROVEEDOR FOREIGN KEY(RUC) REFERENCES PROVEEDOR(RUC),
)

 /* TABLA TIPO_LOGIN */
CREATE TABLE TIPO_LOGIN(
COD_TIPO_LOG VARCHAR(20) not null PRIMARY KEY ,
DESCRIPCION VARCHAR(50),
 
)

 /* TABLA _LOGIN */
CREATE TABLE _LOGIN(
COD_LOGIN VARCHAR(20) not null PRIMARY KEY ,
COD_TIPO_LOG VARCHAR(20) not null,
_USER VARCHAR(20),
_PASSWORD VARCHAR(20),
 CONSTRAINT FK_LOGIN_COD_TIPO_LOG FOREIGN KEY(COD_TIPO_LOG) REFERENCES TIPO_LOGIN(COD_TIPO_LOG),
)

 /* TABLA TIPO_EMPLEADO */
CREATE TABLE TIPO_EMPLEADO(
COD_TIPO_EMP VARCHAR(20)  not null PRIMARY KEY ,
NOMBRE VARCHAR(20),
 
)

  /* TABLA EMPLEADO */
CREATE TABLE EMPLEADO(
COD_EMP int  not null PRIMARY KEY ,
COD_TIPO_EMP VARCHAR(20)  not null,
NOMBRE VARCHAR(20),
APELLIDO VARCHAR(50) not null,
DIRECCION VARCHAR(50) not null,
CORREO VARCHAR(50) not null,
TELEFONO NUMERIC(20),
CUMPLEAŅOS DATE

 CONSTRAINT FK_EMPLEADO_TIPO_EMPLEADO FOREIGN KEY(COD_TIPO_EMP) REFERENCES TIPO_EMPLEADO(COD_TIPO_EMP),
)










  