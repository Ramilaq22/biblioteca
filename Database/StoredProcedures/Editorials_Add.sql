CREATE PROCEDURE [dbo].[Editorials_Add]
	@Name varchar(255)
AS
	INSERT INTO Editorial ([Name]) VALUES
	(@Name)
RETURN 0