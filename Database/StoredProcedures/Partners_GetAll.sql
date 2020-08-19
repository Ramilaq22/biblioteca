CREATE PROCEDURE [dbo].[Partners_GetAll] AS
	SELECT PartnerID, LastName, FirstName, DNI, [Address], Phone FROM Partner
RETURN 0
