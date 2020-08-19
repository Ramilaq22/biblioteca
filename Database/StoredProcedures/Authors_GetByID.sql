CREATE PROCEDURE [dbo].[Authors_GetByID]
	@AuthorIDParam int
AS
	SELECT AuthorID, [Name] FROM Author
	WHERE AuthorID = @AuthorIDParam
RETURN 0