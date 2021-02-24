CREATE TABLE [dbo].[UserType] (
    [Id]    TINYINT       IDENTITY (1, 1) NOT NULL,
    [Title] NVARCHAR (20) NOT NULL,
    CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED ([Id] ASC)
);



