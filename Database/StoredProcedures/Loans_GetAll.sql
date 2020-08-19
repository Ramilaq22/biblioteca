CREATE PROCEDURE [dbo].[Loans_GetAll] AS
	SELECT LoanID, BookID, PartnerID, LoanDate, EstimatedDate, DevolutionDate FROM Loan
RETURN 0