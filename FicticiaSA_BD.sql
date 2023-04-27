create database FicticiaSA 
use FicticiaSA 

create table Usuarios(
IdUsuario int not null identity(1,1),
NombreUsuario nvarchar(50) not null,
Password varbinary(max) not null,
Salt varbinary(max) not null,
PRIMARY KEY (IdUsuario)
);

create table Personas(
IdPersona int not null identity(1,1),
NombreCompleto nvarchar(100) not null,
Identificacion nvarchar(100) not null,
Edad int not null,
Genero nvarchar(50) not null,
EsActivo bit not null,
Maneja bit null,
UsaLentes bit null,
Diabetico bit null,
OtraEnfermedad bit null,
OtrasEnfermedades nvarchar(100) null,
FechaAlta datetime not null,
FechaBaja datetime null
PRIMARY KEY (IdPersona)
);