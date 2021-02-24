USE [Paybaymax]
GO

PRINT N'Inserting two basic UserTypes'
INSERT INTO [dbo].[UserType]
           ([Title])
     VALUES
           ('Regular'),
           ('Admin')
GO

PRINT N'Inserting Employees'
INSERT INTO [dbo].[Employee]
           ([FirstName]
           ,[LastName]
           ,[Job])
     VALUES
           ('Franck'
           ,'TheAdm'
           ,'Human Resources'),
           ('John'
           ,'TheRegular'
           ,'Junior Developer'),
           ('Ken'
           ,'TheThrid'
           ,'Mid Developer'),
           ('Jude'
           ,'Fourth'
           ,'Senior Developer'),
           ('Eri'
           ,'Fifth'
           ,'Techlead')
GO

declare @FranckId uniqueidentifier = (select id from [dbo].Employee WHERE Employee.FirstName = 'Franck');
declare @JohnId uniqueidentifier = (select id from [dbo].Employee WHERE Employee.FirstName = 'John');
declare @KenId uniqueidentifier = (select id from [dbo].Employee WHERE Employee.FirstName = 'Ken');
declare @JudeId uniqueidentifier = (select id from [dbo].Employee WHERE Employee.FirstName = 'Jude');
declare @EriId uniqueidentifier = (select id from [dbo].Employee WHERE Employee.FirstName = 'Eri');

PRINT N'Inserting Users'
INSERT INTO [dbo].[User]
           ([Email]
           ,[Password]
           ,[UserType]
           ,[EmployeeId])
     VALUES
           ('admin@paybay.max'
           ,'P@ssw0rd!'
           ,2
           ,@FranckId),
           ('regular@paybay.max'
           ,'P@ssw0rd!'
           ,1
           ,@JohnId),
           ('ken@paybay.max'
           ,'P@ssw0rd!'
           ,1
           ,@KenId),
           ('jude@paybay.max'
           ,'P@ssw0rd!'
           ,1
           ,@JudeId),
           ('eri@paybay.max'
           ,'P@ssw0rd!'
           ,1
           ,@EriId)

PRINT N'Inserting one basic Performance'
INSERT INTO [dbo].[Performance]
           ([Title]
           ,[Description]
           ,[Date]
           ,[EmployeeId])
     VALUES
           ('Public Big Event webpage'
           ,'This project meant to provide a public marketing webpage to promote our Big Event'
           ,CAST( GETDATE() AS Date )
           ,@JohnId),
           ('Debugging main platform webpage'
           ,''
           ,CAST( GETDATE() AS Date )
           ,@JohnId),
           ('Architecturing the Public Big Event webpage'
           ,''
           ,CAST( GETDATE() AS Date )
           ,@EriId),
           ('Integrate the Public Big Event design webpage'
           ,''
           ,CAST( GETDATE() AS Date )
           ,@JohnId)
           ,
           ('Integrate the Public Big Event design webpage'
           ,''
           ,CAST( GETDATE() AS Date )
           ,@JudeId)

DECLARE @JohnPerfId uniqueidentifier = (select top 1 id from [dbo].Performance P where P.EmployeeId = @JohnId);
DECLARE @JudePerfId uniqueidentifier = (select top 1 id from [dbo].Performance P where P.EmployeeId = @JudeId);

PRINT N'Inserting one PerformanceAssignedEmployee'
    INSERT INTO [dbo].[PerformanceAssignedEmployee]
           ([EmployeeId]
           ,[PerformanceId])
     VALUES
           (@KenId
           ,@JohnPerfId)

    INSERT INTO [dbo].[PerformanceAssignedEmployee]
           ([EmployeeId]
           ,[PerformanceId])
     VALUES
           (@KenId
           ,@JudePerfId)
GO