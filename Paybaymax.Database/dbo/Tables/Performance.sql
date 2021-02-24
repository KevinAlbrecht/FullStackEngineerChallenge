CREATE TABLE [dbo].[Performance] (
    [Id]          UNIQUEIDENTIFIER CONSTRAINT [DF_Performance_Id] DEFAULT (newid()) NOT NULL,
    [Title]       NVARCHAR (50)    NOT NULL,
    [Description] NVARCHAR (MAX)   NOT NULL,
    [Date]        DATE             NOT NULL,
    [EmployeeId]  UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Performance] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Performance_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee] ([Id])
);





