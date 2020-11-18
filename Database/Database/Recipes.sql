CREATE TABLE [dbo].[Recipes]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY,
    [name] VARCHAR(80) NOT NULL, 
    [description] VARCHAR(200) NOT NULL, 
    [instructions] VARCHAR(MAX) NOT NULL, 
    [createdBy] VARCHAR(50) NOT NULL, 
    [recipeid] VARCHAR(12) NOT NULL, 
    [date] DATETIME NOT NULL
)
GO CREATE INDEX ix_recipes ON [dbo].[Recipes] ([name],[recipeid], [date], [createdBy]);