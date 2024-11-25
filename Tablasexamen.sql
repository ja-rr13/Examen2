create database Tablasexamen
go
use Tablasexamen
go
create table Usuarios(
	UsuarioID int primary key,
	Nombre varchar(100),
	CorreoElectronico varchar(100),
	Telefono varchar(100)
)
insert into Usuarios(UsuarioID,Nombre,CorreoElectronico,Telefono) VALUES('7','Jahir','jra@gmail.com','34072345')
select * from Usuarios
--borrar
create procedure IngresarUsuario
@UsuarioID int,
@nombre varchar(100),
@CorreoElectronico varchar(100),
@telefono varchar(100)
as
begin
insert into Usuarios values (@UsuarioID,@nombre,@CorreoElectronico,@telefono)

end


create procedure borarUsuario
@UsuarioID int
as
begin
delete Usuarios where UsuarioID=@UsuarioID

end


create procedure ModificarUsuario
@UsuarioID int,
@nombre varchar(100),
@CorreoElectronico varchar(100),
@telefono varchar(100)

as
begin
update Usuarios set nombre=@nombre, Correoelectronico=@CorreoElectronico, telefono=@telefono where UsuarioID=@UsuarioID

end

create procedure consultarUsuarios
@UsuarioID int
as
begin
select * from Usuarios where UsuarioID=@UsuarioID

end
create table Tecnicos(
	TecnicoID int primary key,
	Nombre varchar(100),
	Especialidad varchar(100)
	
)
--insertar
insert into Tecnicos(TecnicoID,Nombre,Especialidad) VALUES('2','Jahir','Informatica')
--borrar
select * from Tecnicos
create procedure IngresarTecnicos
@TecnicoID int,
@nombre varchar(100),
@Especialidad varchar(100)
as
begin
insert into Tecnicos values (@TecnicoID,@nombre,@Especialidad)

end

create procedure borarTecnico
@TecnicoID varchar(100)
as
begin
delete Tecnicos where TecnicoID=@TecnicoID

end
create procedure ModificarTecnicos
@TecnicoID int,
@nombre varchar(100),
@Especialidad varchar(100)

as
begin
update Tecnicos set nombre=@nombre,  Especialidad=@Especialidad where TecnicoID=@TecnicoID

end

create procedure consultarTecnicos
@TecnicoID Varchar(100)
as
begin
select * from Tecnicos where TecnicoID=@TecnicoID

end
create table Equipos(
	EquipoID int primary key,
	TipoEquipo varchar(100),
	Modelo varchar(100),
	UsuarioID int foreign key references Usuarios(UsuarioID)
)
insert into Equipos(EquipoID,TipoEquipo,Modelo,UsuarioID) VALUES(2,'j','b',7)
select * from Equipos
--borrar
create procedure IngresarEquipos
@EquipoID int,
@Tipoequipo varchar(100),
@modelo varchar(100),
@UsuarioID int
as
begin
insert into Equipos values (@EquipoID,@Tipoequipo,@modelo,@UsuarioID)

end
create procedure borarEquipo
@EquipoID varchar(100)
as
begin
delete Equipos where EquipoID=@EquipoID

end
create procedure ModificarEquipos
@EquipoID int,
@Tipoequipo varchar(100),
@modelo varchar(100),
@UsuarioID int

as
begin
update Equipos set TipoEquipo=@Tipoequipo,  Modelo=@modelo, UsuarioID=@UsuarioID where @EquipoID=EquipoID

end
create procedure consultarEquipo
@EquipoID int
as
begin
select * from Equipos where EquipoID=@EquipoID

end
create table Reparaciones(
	ReparacionID int primary key,
	FechaSolicitud varchar(50),
	Estado varchar(50),
	EquipoID int foreign key references Equipos(EquipoID)
)
create table DetallesReparacion(
	DetalleID int primary key,
	Descripcion varchar(50),
	FechaInicio varchar(50),
	FechaFin varchar(50),
	ReparacionID int foreign key references Reparaciones(ReparacionID)
)
create table Asignaciones(
	AsignacionID int primary key,
	FechaAsignacion varchar(50),
	TecnicoID int foreign key references Tecnicos(TecnicoID),
	ReparacionID int foreign key references Reparaciones(ReparacionID)
)