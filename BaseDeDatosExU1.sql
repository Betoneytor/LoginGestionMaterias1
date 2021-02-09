drop database exu1;
create database exu1;
use exu1;
drop table usuarios;
-- ____________________________________________________
create table usuarios
(
idUsuario 		int(10) 		primary key auto_increment,
email 			varchar(30) 	not null,
contrasena 		int(5) 			not null
);
-- ______________________________________________________-
select u.idUsuario
from usuarios u where u.email= "betoneitor333@gmail.com" and u.contrasena = "81132";
select*from usuarios;
select u.email,u.contrasena from usuarios u where u.idUsuario =5;
insert into usuarios(email,contrasena) values("betoneitor333@gmail.com","81132");
delete from usuarios where idUsuario=1;
-- ___________________________________________________________________________________________________
select * from materias;
create table materias
(
idMateria 		int(10) 		primary key auto_increment,
idUsuario 		int(10)		    not null,
nombre			varchar(30) 	not null,

constraint idUsuario foreign key (idUsuario)
references usuarios(idUsuario)
);
-- ______________________________________________________-

insert into materias(idUsuario,nombre) 
			  values(1,"Prog.WEB II");
SELECT m.idMateria, m.IdUsuario, m.nombre
FROM materias m
WHERE m.IdMateria=2;
-- ______________________________________________________-
create table Unidades
(
idUnidad 			int(10) primary key auto_increment,
idMateria 			int(10) not null,
numeroUnidad    	int(10) not null,
calificacionUnidad 	int(10) not null,

constraint idMateria foreign key (idMateria)
references materias(idMateria)
);
-- ______________________________________________________-