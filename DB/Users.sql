CREATE TABLE [dbo].[Users]
(
	[id] INT NOT NULL IDENTITY, 
    [username] VARCHAR(50) NOT NULL, 
    [password] VARCHAR(MAX) NOT NULL, 
    [admin_powers] INT NOT NULL DEFAULT 0, 
    [age] INT NULL, 
    [gender] VARCHAR(6) NULL, 
    [height_feet] INT NULL, 
    [height_inches] INT NULL, 
    [weight] INT NULL, 
    [bmr] INT NULL, 
    [activity_level] VARCHAR(50) NULL, 
    [gluten_allergy] INT NOT NULL, 
    [peanut_allergy] INT NOT NULL, 
    [fish_allergy] INT NOT NULL, 
    [soy_allergy] INT NOT NULL, 
    [dairy_allergy] INT NOT NULL, 
    [join_date] DATETIME NOT NULL, 
    [last_login] DATETIME NOT NULL, 
    CONSTRAINT [PK_Table1] PRIMARY KEY ([id]) 
)
GO CREATE INDEX ix_user_login ON [dbo].[Users] ([username]);
