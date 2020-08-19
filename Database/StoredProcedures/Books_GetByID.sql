CREATE PROCEDURE [dbo].[Books_GetByID]
	@IDParam int
AS
	SELECT BookID, ISBN, Title, EditorialID, Edition, [Year], EditionYear, AuthorID, Deterioration FROM Book
	WHERE BookID = @IDParam
RETURN 0
