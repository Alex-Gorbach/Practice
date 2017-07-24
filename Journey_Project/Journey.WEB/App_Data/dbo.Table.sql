CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [StartPoint] NCHAR(128) NOT NULL, 
    [EndPoint] NCHAR(128) NOT NULL, 
    [Waypoints] NCHAR(128) NOT NULL, 
    [Date] DATETIME NOT NULL, 
    [UserID] NCHAR(128) NOT NULL

)
