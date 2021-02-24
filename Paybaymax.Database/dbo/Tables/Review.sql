CREATE TABLE [dbo].[Review] (
    [Id]                UNIQUEIDENTIFIER CONSTRAINT [DF_Review_Id] DEFAULT (newid()) NOT NULL,
    [GlobalRating]      TINYINT          NOT NULL,
    [QualityRating]     TINYINT          NOT NULL,
    [InitiativeRating]  TINYINT          NOT NULL,
    [CooperationRating] TINYINT          NOT NULL,
    [Comment]           NVARCHAR (MAX)   NOT NULL,
    [CreatedDate]       DATE             CONSTRAINT [DF_Review_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [UpdatedDate]       DATE             NULL,
    [PerformanceId]     UNIQUEIDENTIFIER NOT NULL,
    [CreatorEmployeeId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Review_Employee] FOREIGN KEY ([CreatorEmployeeId]) REFERENCES [dbo].[Employee] ([Id]),
    CONSTRAINT [FK_Review_Performance] FOREIGN KEY ([PerformanceId]) REFERENCES [dbo].[Performance] ([Id])
);







