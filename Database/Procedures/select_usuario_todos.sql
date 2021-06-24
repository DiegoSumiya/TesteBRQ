use TesteSqlServer

go

create procedure select_usuario_todos

as
begin
	select Id, Nome, CPF, Email, Telefone, Sexo, DataNascimento from Usuario;
end
