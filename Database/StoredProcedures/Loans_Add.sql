CREATE PROCEDURE [dbo].[Loans_Add]
	@BookID int,
	@PartnerID int,
	@LoanDate datetime,
	@EstimatedDate datetime,
	@DevolutionDate datetime
AS
	INSERT INTO Loan (BookID, PartnerID, LoanDate, EstimatedDate, DevolutionDate) VALUES
	(@BookID, @PartnerID, @LoanDate, @EstimatedDate, @DevolutionDate)
RETURN 0