CREATE TABLE [dbo].[User] (
    [Id]         UNIQUEIDENTIFIER CONSTRAINT [DF_User_Id] DEFAULT (newid()) NOT NULL,
    [Email]      NVARCHAR (100)   NOT NULL,
    [Password]   NVARCHAR (MAX)   NOT NULL,
    [UserType]   TINYINT          NOT NULL,
    [EmployeeId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_User_UserType] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee] ([Id])
);





