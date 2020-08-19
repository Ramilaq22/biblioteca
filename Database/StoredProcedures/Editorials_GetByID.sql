CREATE PROCEDURE [dbo].[Editorials_GetByID]
	@EditorialIDParam int
AS
	SELECT EditorialID, [Name] FROM Editorial
	WHERE EditorialID = @EditorialIDParam
RETURN 0