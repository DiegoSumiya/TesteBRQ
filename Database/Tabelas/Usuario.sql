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
