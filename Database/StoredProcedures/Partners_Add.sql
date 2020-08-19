CREATE PROCEDURE [dbo].[Partners_Add]
	@LastName varchar(255),
	@FirstName varchar(255),
	@DNI varchar(8),
	@Address varchar(255),
	@Phone varchar(255)

AS
	INSERT INTO Partner (LastName, FirstName, DNI, [Address], Phone) VALUES
	(@Lastname, @FirstName, @DNI, @Address, @Phone)
RETURN 0
