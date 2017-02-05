CREATE TABLE BANCO  
   (BancoID int NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    Direccion varchar(300) NULL,
    Nombre varchar(200) NULL,  
    FechaRegistro date NULL)  
GO  

CREATE TABLE SUCURSAL  
   (SucursalID int NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    Direccion varchar(300) NULL,
    Nombre varchar(200) NULL,  
    FechaRegistro date NULL,
	BancoID int NOT NULL,
	FOREIGN KEY (BancoID) REFERENCES BANCO(BancoID))  
GO  

CREATE TABLE MONEDA  
   (MonedaID int NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    Descripcion varchar(50) NULL)  
GO

CREATE TABLE ESTADO  
   (EstadoID int NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    Descripcion varchar(50) NULL)  
GO  

CREATE TABLE ORDENPAGO
   (OrdenPagoID int NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    Monto decimal(5,2) NULL,
	MonedaID int NULL,
	EstadoID int NULL,
	FechaPago date NULL,
	SucursalID int NOT NULL,
	FOREIGN KEY (SucursalID) REFERENCES SUCURSAL(SucursalID),
	FOREIGN KEY (MonedaID) REFERENCES MONEDA(MonedaID),
	FOREIGN KEY (EstadoID) REFERENCES ESTADO(EstadoID))  
GO  


INSERT INTO BANCO(Direccion, Nombre,FechaRegistro) VALUES('Av. Mariano Arnejo 234', 'BCP',GETDATE());

INSERT INTO MONEDA(Descripcion) VALUES('Soles');
INSERT INTO MONEDA(Descripcion) VALUES('Dolares');

INSERT INTO ESTADO(Descripcion) VALUES('Pagada');
INSERT INTO ESTADO(Descripcion) VALUES('Declinada');
INSERT INTO ESTADO(Descripcion) VALUES('Fallida');
INSERT INTO ESTADO(Descripcion) VALUES('Anulada');

select * from banco;
select * from sucursal;
