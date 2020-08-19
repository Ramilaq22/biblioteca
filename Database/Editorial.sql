CREATE TABLE [dbo].[Editorial]
(
	[EditorialID] INT NOT NULL IDENTITY(1,1),
	[Name] VARCHAR(255) NOT NULL,
    CONSTRAINT PK_Editorial PRIMARY KEY (EditorialID)
)
