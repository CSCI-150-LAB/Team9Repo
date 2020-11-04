CREATE TABLE [dbo].[UserTracking]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [username] VARCHAR(50) NOT NULL, 
    [item_name] VARCHAR(50) NOT NULL, 
    [weight] INT NULL, 
    [calories] INT NOT NULL, 
    [fat] DECIMAL(9, 2) NOT NULL,
    [carbohydrate] DECIMAL(9, 2) NOT NULL,
    [protein] DECIMAL(9, 2) NOT NULL,
    [meal_type] INT NOT NULL, --1 breakfast, 2 lunch, 3 dinner
    [date_logged] DATETIME NOT NULL
)-- Index usernames and item names, indexing is important when you try to search by table names such as searching by username or item_name. Indexing makes searching faster.
GO CREATE INDEX ix_tracking ON [dbo].[UserTracking] ([username],[item_name], [meal_type], [date_logged]);