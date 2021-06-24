use TesteSqlServer

go

create procedure select_usuario
(
	@Id int
)
as
begin
	select Id, Nome, CPF, Email, Telefone, Sexo, DataNascimento from Usuario where Id = @Id;
end
