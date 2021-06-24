use TesteSqlServer

go

create procedure delete_usuario
(
	@Id int
)
as
begin
	delete from Usuario where Id = @Id;
end