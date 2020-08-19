CREATE PROCEDURE [dbo].[Authors_GetAll] AS
	SELECT AuthorID, [Name] FROM Author
RETURN 0
