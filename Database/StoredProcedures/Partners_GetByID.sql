CREATE PROCEDURE [dbo].[Partners_GetByID]
	@IDParam int
AS
	SELECT PartnerID, LastName, FirstName, DNI, [Address], Phone FROM Partner
	WHERE PartnerID = @IDParam
RETURN 0
