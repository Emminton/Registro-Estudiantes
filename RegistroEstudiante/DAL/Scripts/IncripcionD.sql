CREATE DATABASE InscripcionDb
GO
USE InscripcionDb
GO

CREATE TABLE Inscripcion
(
	IDinscripcion int primary key identity,
    fecha DateTime,
    IDestudiante int primary key identity,
    comentario varchar(50),
    monto decimal,
	deposito decimal,
    balance decimal,
)