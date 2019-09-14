CREATE DATABASE RegistroDb
GO
USE RegistroDb
GO
CREATE TABLE Registro
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

