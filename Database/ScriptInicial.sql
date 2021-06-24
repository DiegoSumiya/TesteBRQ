CREATE DATABASE TesteSqlServer
go
use TesteSqlServer
go

create table Usuario
(
	Id int not null primary key identity(1,1),
	Nome varchar(100) not null,
	CPF varchar(15) not null,
	Email varchar(50) not null,
	Telefone varchar(15) not null,
	Sexo char(1) not null,
	DataNascimento datetime not null
)
go

create procedure insert_usuario
(
	
	@Nome varchar(100),
	@CPF varchar(15),
	@Email varchar(50),
	@Telefone varchar(15),
	@Sexo char(1),
	@DataNascimento datetime
)
as
begin
	insert into Usuario (Nome, CPF, Email, Telefone, Sexo, DataNascimento)
	values (@Nome, @CPF, @Email, @Telefone, @Sexo, @DataNascimento)
end

go

create procedure select_usuario
(
	@Id int
)
as
begin
	select Id, Nome, CPF, Email, Telefone, Sexo, DataNascimento from Usuario where Id = @Id;
end

go

create procedure delete_usuario
(
	@Id int
)
as
begin
	delete from Usuario where Id = @Id;
end

go

create procedure update_usuario
(
	@Id int,
	@Nome varchar(100),
	@CPF varchar(15),
	@Email varchar(50),
	@Telefone varchar(15),
	@Sexo char(1),
	@DataNascimento datetime
)
as 
begin
	update Usuario set Nome = @Nome, CPF = @CPF, Email = @Email, Telefone = @Telefone, Sexo = @Sexo, DataNascimento = @DataNascimento where Id = @Id;
end

go
create procedure select_usuario_todos

as
begin
	select Id, Nome, CPF, Email, Telefone, Sexo, DataNascimento from Usuario;
end

