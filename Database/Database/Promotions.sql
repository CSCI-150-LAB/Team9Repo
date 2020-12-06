CREATE TABLE [dbo].[Promotions]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [recipeid] VARCHAR(12) NULL
)
GO CREATE INDEX ix_promotions ON [dbo].[Promotions] ([recipeid]);