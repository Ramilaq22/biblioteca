CREATE PROCEDURE [dbo].[Loans_Edit]
	@LoanID int,
	@DevolutionDate datetime
AS
	UPDATE Loan
	SET DevolutionDate = @DevolutionDate
	WHERE LoanID = @LoanID;
RETURN 0
