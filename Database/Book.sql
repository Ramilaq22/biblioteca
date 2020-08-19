﻿CREATE TABLE [dbo].[Book]
(
	[BookID] INT NOT NULL IDENTITY(1,1),
	[ISBN] INT NOT NULL,
	[EditorialID] INT NOT NULL,
	[AuthorID] INT NOT NULL,
	[Title] VARCHAR(255) NOT NULL,
	[Edition] INT NOT NULL,
	[Year] INT NOT NULL,
	[EditionYear] INT NOT NULL,
	[Deterioration] VARCHAR(255) NOT NULL,
    CONSTRAINT PK_Book PRIMARY KEY (BookID),
	CONSTRAINT FK_BookAuthor FOREIGN KEY (AuthorID) REFERENCES Author(AuthorID),
	CONSTRAINT FK_BookEditorial FOREIGN KEY (EditorialID) REFERENCES Editorial(EditorialID)
)
