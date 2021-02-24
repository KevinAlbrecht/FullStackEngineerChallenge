CREATE TABLE [dbo].[Employee] (
    [Id]        UNIQUEIDENTIFIER CONSTRAINT [DF_Employee_Id] DEFAULT (newid()) NOT NULL,
    [FirstName] NVARCHAR (50)    NOT NULL,
    [LastName]  NVARCHAR (50)    NOT NULL,
    [Job]       NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([Id] ASC)
);





