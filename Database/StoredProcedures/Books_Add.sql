CREATE PROCEDURE [dbo].[Books_Add]
	@ISBN int,
	@EditorialID int,	
	@AuthorID int,	
	@Title varchar(255),
	@Edition int,	
	@Year int,
	@EditionYear int,
	@Deterioration varchar(255)
AS
	INSERT INTO Book (ISBN, EditorialID, AuthorID, Title, Edition, [Year], EditionYear, Deterioration) VALUES
	(@ISBN, @EditorialID, @AuthorID, @Title, @Edition, @Year, @EditionYear, @Deterioration)
RETURN 0