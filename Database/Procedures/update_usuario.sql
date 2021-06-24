use TesteSqlServer
go

create procedure update_usuario
(
	@Id int
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