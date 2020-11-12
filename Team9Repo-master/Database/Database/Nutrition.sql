CREATE TABLE [dbo].[Nutrition]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [item_name] VARCHAR(50) NOT NULL, 
    [calories] INT NOT NULL, 
    [fat] DECIMAL(9, 2) NOT NULL,
    [carbohydrate] DECIMAL(9, 2) NOT NULL,
    [protein] DECIMAL(9, 2) NOT NULL,
    [contains_gluten] INT NOT NULL, 
    [contains_nuts] INT NOT NULL, 
    [contains_fish] INT NOT NULL, 
    [contains_dairy] INT NOT NULL, 
    [contains_soy] INT NOT NULL
)--If you want the database to be optimized for searching/selecting you need to add an index on that table. Read about indexes here:
-- https://www.sqlservertutorial.net/sql-server-indexes/sql-server-create-index/
GO CREATE INDEX ix_full_nutrition ON [dbo].[Nutrition] ([item_name],[calories],[fat],[carbohydrate],[protein],[contains_gluten],[contains_nuts],[contains_fish],[contains_dairy],[contains_soy]);