use TesteSqlServer

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