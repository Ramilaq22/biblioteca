CREATE PROCEDURE [dbo].[Partners_Check]
	@DNIParam int
AS
	SELECT PartnerID, LastName, FirstName, DNI, [Address], Phone FROM Partner
	WHERE DNI = @DNIParam
RETURN 0
