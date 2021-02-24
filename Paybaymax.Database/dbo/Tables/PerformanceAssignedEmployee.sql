CREATE TABLE [dbo].[PerformanceAssignedEmployee] (
    [Id]            INT              IDENTITY (1, 1) NOT NULL,
    [EmployeeId]    UNIQUEIDENTIFIER NOT NULL,
    [PerformanceId] UNIQUEIDENTIFIER NOT NULL,
    [Done]          BIT              CONSTRAINT [DF_PerformanceAssignedEmployee_Done] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_PerformanceAssignedEmployee] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PerformanceAssignedEmployee_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee] ([Id]),
    CONSTRAINT [FK_PerformanceAssignedEmployee_Performance] FOREIGN KEY ([PerformanceId]) REFERENCES [dbo].[Performance] ([Id])
);

