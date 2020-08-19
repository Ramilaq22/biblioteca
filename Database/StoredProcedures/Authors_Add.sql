CREATE PROCEDURE [dbo].[Authors_Add]
	@Name varchar(255)
AS
	INSERT INTO Author ([Name]) VALUES
	(@Name)
RETURN 0
