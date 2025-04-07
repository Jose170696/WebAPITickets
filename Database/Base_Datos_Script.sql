CREATE TABLE Roles (
ro_identificador int primary key identity,
ro_descripcion nvarchar(125) not null,
ro_fecha_adicion datetime default getdate() not null,
ro_adicionado_por nvarchar(10) not null,
ro_fecha_modificacion datetime,
ro_modificado_por nvarchar (10)
);


CREATE TABLE Usuarios (
us_identificador int primary key identity,
us_nombre_completo nvarchar(150) not null,
us_correo nvarchar(150) not null,
us_clave nvarchar(255) not null,
us_ro_identificador int foreign key (us_ro_identificador) references Roles(ro_identificador),
us_estado nvarchar(1) not null,
us_fecha_adicion datetime default getdate() not null,
us_adicionado_por nvarchar(10) not null,
us_fecha_modificacion datetime,
us_modificado_por nvarchar (10)
);


create table Categorias (
ca_identificador int primary key identity,
ca_nombre nvarchar(100) not null
);


create table Importancias (
im_identificador int primary key identity,
im_nivel nvarchar(50) not null
);


create table Urgencias (
ur_identificador int primary key identity,
ur_nivel nvarchar(50) not null
);


create table Tiquetes (
ti_identificador int primary key identity (1,1),
ti_asunto nvarchar(150) not null,
ti_ca_id int foreign key references Categorias(ca_identificador),
ti_us_id_asigna int foreign key references Usuarios(us_identificador),
ti_ur_id int foreign key references Urgencias(ur_identificador),
ti_im_id int foreign key references Importancias(im_identificador),
ti_estado nvarchar(150) not null,
ti_solucion nvarchar(255),
ti_fecha_adicion datetime default getdate() not null,
ti_adicionado_por nvarchar(10) not null,
ti_fecha_modificacion datetime,
ti_modificado_por nvarchar(10)
);


