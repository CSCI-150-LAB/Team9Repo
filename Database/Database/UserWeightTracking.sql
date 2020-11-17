CREATE TABLE [dbo].[UserWeightTracking]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [username] VARCHAR(50) NOT NULL, 
    [weight] DECIMAL(9, 3) NOT NULL, 
    [date] DATETIME NOT NULL
)
GO CREATE INDEX ix_weight_tracking ON [dbo].[UserWeightTracking] ([username]);