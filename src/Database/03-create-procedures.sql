PRINT N'Creating [dbo].[FilmStartsWith]...';


GO
create procedure FilmStartsWith

	@name varchar(255)

as 
begin

	set @name = @name + '%';
	
	select * from Film
	where Title like @name
	order by Title
end
GO
PRINT N'Creating [dbo].[FindActor]...';


GO
create procedure FindActor 

	@name varchar(255)

as 
begin

	set @name = '%' + @name + '%';
	
	select * from Actor
	where FirstName like @name or LastName like @name
	order by LastName, FirstName
end
GO
PRINT N'Creating [dbo].[PagedActors]...';


GO
create procedure PagedActors

	@pageSize int,
	@pageNumber int

as
begin

	declare @skip int
	set @skip = @pageSize * (@pageNumber - 1)

	select *
	from actor 
	order by LastName, FirstName
	offset @skip rows fetch next @pageSize rows only

end
GO
PRINT N'Update complete.';


GO