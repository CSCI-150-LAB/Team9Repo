CREATE TABLE [dbo].[RecipeData]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY,
    [recipeid] VARCHAR(12) NOT NULL, 
    [item_name] VARCHAR(50) NOT NULL, 
    [quantity] INT NULL
)
GO CREATE INDEX ix_recipe_data ON [dbo].[RecipeData] ([recipeid], [item_name]);
