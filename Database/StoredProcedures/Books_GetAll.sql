CREATE PROCEDURE [dbo].[Books_GetAll]
AS
	SELECT BookID, ISBN, Title, EditorialID, Edition, [Year], EditionYear, AuthorID, Deterioration FROM Book
RETURN 0
