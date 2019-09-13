CREATE DATABASE EstudiantesDb
GO
USE EstudiantesDb
GO
CREATE TABLE Estudiantes 
(
	ID int primary key identity,
    matricula varchar(9),
    nombre varchar(30),
    apellido varchar(30),
    nacimiento varchar(30),
    cedula varchar(13),
    telefono varchar(11),
    celular varchar(11),
    email varchar(30),
    sexo varchar(10),
    balance decimal,
)

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