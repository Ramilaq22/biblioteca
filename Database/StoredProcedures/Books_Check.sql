CREATE PROCEDURE [dbo].[Books_Check]
	@ISBNParam int
AS
	SELECT BookID, ISBN, Title, EditorialID, Edition, [Year], EditionYear, AuthorID, Deterioration FROM Book
	WHERE ISBN = @ISBNParam
RETURN 0
