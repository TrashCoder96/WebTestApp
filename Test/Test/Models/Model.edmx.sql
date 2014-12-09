
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/13/2014 00:28:46
-- Generated from EDMX file: C:\Users\asus-pc\Documents\GitHub\WebTestApp\Test\Test\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [student22];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__aspnet_Me__Appli__6319B466]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[aspnet_Membership] DROP CONSTRAINT [FK__aspnet_Me__Appli__6319B466];
GO
IF OBJECT_ID(N'[dbo].[FK__aspnet_Me__UserI__640DD89F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[aspnet_Membership] DROP CONSTRAINT [FK__aspnet_Me__UserI__640DD89F];
GO
IF OBJECT_ID(N'[dbo].[FK__aspnet_Pa__Appli__10E07F16]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[aspnet_Paths] DROP CONSTRAINT [FK__aspnet_Pa__Appli__10E07F16];
GO
IF OBJECT_ID(N'[dbo].[FK__aspnet_Pe__PathI__1699586C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[aspnet_PersonalizationAllUsers] DROP CONSTRAINT [FK__aspnet_Pe__PathI__1699586C];
GO
IF OBJECT_ID(N'[dbo].[FK__aspnet_Pe__PathI__1A69E950]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[aspnet_PersonalizationPerUser] DROP CONSTRAINT [FK__aspnet_Pe__PathI__1A69E950];
GO
IF OBJECT_ID(N'[dbo].[FK__aspnet_Pe__UserI__1B5E0D89]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[aspnet_PersonalizationPerUser] DROP CONSTRAINT [FK__aspnet_Pe__UserI__1B5E0D89];
GO
IF OBJECT_ID(N'[dbo].[FK__aspnet_Pr__UserI__7720AD13]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[aspnet_Profile] DROP CONSTRAINT [FK__aspnet_Pr__UserI__7720AD13];
GO
IF OBJECT_ID(N'[dbo].[FK__aspnet_Ro__Appli__7FB5F314]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[aspnet_Roles] DROP CONSTRAINT [FK__aspnet_Ro__Appli__7FB5F314];
GO
IF OBJECT_ID(N'[dbo].[FK__aspnet_Us__Appli__54CB950F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[aspnet_Users] DROP CONSTRAINT [FK__aspnet_Us__Appli__54CB950F];
GO
IF OBJECT_ID(N'[dbo].[FK__aspnet_Us__RoleI__047AA831]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[aspnet_UsersInRoles] DROP CONSTRAINT [FK__aspnet_Us__RoleI__047AA831];
GO
IF OBJECT_ID(N'[dbo].[FK__aspnet_Us__UserI__038683F8]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[aspnet_UsersInRoles] DROP CONSTRAINT [FK__aspnet_Us__UserI__038683F8];
GO
IF OBJECT_ID(N'[dbo].[FK_DisciplineSet_aspnet_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Discipline] DROP CONSTRAINT [FK_DisciplineSet_aspnet_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_DisciplineTest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Test] DROP CONSTRAINT [FK_DisciplineTest];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupStudentRequest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentRequest] DROP CONSTRAINT [FK_GroupStudentRequest];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupTest_Group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupTest] DROP CONSTRAINT [FK_GroupTest_Group];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupTest_Test]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupTest] DROP CONSTRAINT [FK_GroupTest_Test];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupUser_aspnet_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupUser] DROP CONSTRAINT [FK_GroupUser_aspnet_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupUser_Group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupUser] DROP CONSTRAINT [FK_GroupUser_Group];
GO
IF OBJECT_ID(N'[dbo].[FK_QuastionVariant]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Variant] DROP CONSTRAINT [FK_QuastionVariant];
GO
IF OBJECT_ID(N'[dbo].[FK_RequestSet_aspnet_Roles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Request] DROP CONSTRAINT [FK_RequestSet_aspnet_Roles];
GO
IF OBJECT_ID(N'[dbo].[FK_RequestSet_aspnet_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Request] DROP CONSTRAINT [FK_RequestSet_aspnet_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentRequestSet_aspnet_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentRequest] DROP CONSTRAINT [FK_StudentRequestSet_aspnet_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_TestQuastion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Quastion] DROP CONSTRAINT [FK_TestQuastion];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[aspnet_Applications]', 'U') IS NOT NULL
    DROP TABLE [dbo].[aspnet_Applications];
GO
IF OBJECT_ID(N'[dbo].[aspnet_Membership]', 'U') IS NOT NULL
    DROP TABLE [dbo].[aspnet_Membership];
GO
IF OBJECT_ID(N'[dbo].[aspnet_Paths]', 'U') IS NOT NULL
    DROP TABLE [dbo].[aspnet_Paths];
GO
IF OBJECT_ID(N'[dbo].[aspnet_PersonalizationAllUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[aspnet_PersonalizationAllUsers];
GO
IF OBJECT_ID(N'[dbo].[aspnet_PersonalizationPerUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[aspnet_PersonalizationPerUser];
GO
IF OBJECT_ID(N'[dbo].[aspnet_Profile]', 'U') IS NOT NULL
    DROP TABLE [dbo].[aspnet_Profile];
GO
IF OBJECT_ID(N'[dbo].[aspnet_Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[aspnet_Roles];
GO
IF OBJECT_ID(N'[dbo].[aspnet_SchemaVersions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[aspnet_SchemaVersions];
GO
IF OBJECT_ID(N'[dbo].[aspnet_Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[aspnet_Users];
GO
IF OBJECT_ID(N'[dbo].[aspnet_UsersInRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[aspnet_UsersInRoles];
GO
IF OBJECT_ID(N'[dbo].[aspnet_WebEvent_Events]', 'U') IS NOT NULL
    DROP TABLE [dbo].[aspnet_WebEvent_Events];
GO
IF OBJECT_ID(N'[dbo].[Discipline]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Discipline];
GO
IF OBJECT_ID(N'[dbo].[Group]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Group];
GO
IF OBJECT_ID(N'[dbo].[GroupTest]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupTest];
GO
IF OBJECT_ID(N'[dbo].[GroupUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupUser];
GO
IF OBJECT_ID(N'[dbo].[Quastion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Quastion];
GO
IF OBJECT_ID(N'[dbo].[Request]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Request];
GO
IF OBJECT_ID(N'[dbo].[StudentRequest]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentRequest];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Test]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Test];
GO
IF OBJECT_ID(N'[dbo].[Variant]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Variant];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'aspnet_Applications'
CREATE TABLE [dbo].[aspnet_Applications] (
    [ApplicationName] nvarchar(256)  NOT NULL,
    [LoweredApplicationName] nvarchar(256)  NOT NULL,
    [ApplicationId] uniqueidentifier  NOT NULL,
    [Description] nvarchar(256)  NULL
);
GO

-- Creating table 'aspnet_Membership'
CREATE TABLE [dbo].[aspnet_Membership] (
    [ApplicationId] uniqueidentifier  NOT NULL,
    [UserId] uniqueidentifier  NOT NULL,
    [Password] nvarchar(128)  NOT NULL,
    [PasswordFormat] int  NOT NULL,
    [PasswordSalt] nvarchar(128)  NOT NULL,
    [MobilePIN] nvarchar(16)  NULL,
    [Email] nvarchar(256)  NULL,
    [LoweredEmail] nvarchar(256)  NULL,
    [PasswordQuestion] nvarchar(256)  NULL,
    [PasswordAnswer] nvarchar(128)  NULL,
    [IsApproved] bit  NOT NULL,
    [IsLockedOut] bit  NOT NULL,
    [CreateDate] datetime  NOT NULL,
    [LastLoginDate] datetime  NOT NULL,
    [LastPasswordChangedDate] datetime  NOT NULL,
    [LastLockoutDate] datetime  NOT NULL,
    [FailedPasswordAttemptCount] int  NOT NULL,
    [FailedPasswordAttemptWindowStart] datetime  NOT NULL,
    [FailedPasswordAnswerAttemptCount] int  NOT NULL,
    [FailedPasswordAnswerAttemptWindowStart] datetime  NOT NULL,
    [Comment] nvarchar(max)  NULL
);
GO

-- Creating table 'aspnet_Paths'
CREATE TABLE [dbo].[aspnet_Paths] (
    [ApplicationId] uniqueidentifier  NOT NULL,
    [PathId] uniqueidentifier  NOT NULL,
    [Path] nvarchar(256)  NOT NULL,
    [LoweredPath] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'aspnet_PersonalizationAllUsers'
CREATE TABLE [dbo].[aspnet_PersonalizationAllUsers] (
    [PathId] uniqueidentifier  NOT NULL,
    [PageSettings] varbinary(max)  NOT NULL,
    [LastUpdatedDate] datetime  NOT NULL
);
GO

-- Creating table 'aspnet_PersonalizationPerUser'
CREATE TABLE [dbo].[aspnet_PersonalizationPerUser] (
    [Id] uniqueidentifier  NOT NULL,
    [PathId] uniqueidentifier  NULL,
    [UserId] uniqueidentifier  NULL,
    [PageSettings] varbinary(max)  NOT NULL,
    [LastUpdatedDate] datetime  NOT NULL
);
GO

-- Creating table 'aspnet_Profile'
CREATE TABLE [dbo].[aspnet_Profile] (
    [UserId] uniqueidentifier  NOT NULL,
    [PropertyNames] nvarchar(max)  NOT NULL,
    [PropertyValuesString] nvarchar(max)  NOT NULL,
    [PropertyValuesBinary] varbinary(max)  NOT NULL,
    [LastUpdatedDate] datetime  NOT NULL
);
GO

-- Creating table 'aspnet_Roles'
CREATE TABLE [dbo].[aspnet_Roles] (
    [ApplicationId] uniqueidentifier  NOT NULL,
    [RoleId] uniqueidentifier  NOT NULL,
    [RoleName] nvarchar(256)  NOT NULL,
    [LoweredRoleName] nvarchar(256)  NOT NULL,
    [Description] nvarchar(256)  NULL
);
GO

-- Creating table 'aspnet_SchemaVersions'
CREATE TABLE [dbo].[aspnet_SchemaVersions] (
    [Feature] nvarchar(128)  NOT NULL,
    [CompatibleSchemaVersion] nvarchar(128)  NOT NULL,
    [IsCurrentVersion] bit  NOT NULL
);
GO

-- Creating table 'aspnet_Users'
CREATE TABLE [dbo].[aspnet_Users] (
    [ApplicationId] uniqueidentifier  NOT NULL,
    [UserId] uniqueidentifier  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL,
    [LoweredUserName] nvarchar(256)  NOT NULL,
    [MobileAlias] nvarchar(16)  NULL,
    [IsAnonymous] bit  NOT NULL,
    [LastActivityDate] datetime  NOT NULL
);
GO

-- Creating table 'aspnet_WebEvent_Events'
CREATE TABLE [dbo].[aspnet_WebEvent_Events] (
    [EventId] char(32)  NOT NULL,
    [EventTimeUtc] datetime  NOT NULL,
    [EventTime] datetime  NOT NULL,
    [EventType] nvarchar(256)  NOT NULL,
    [EventSequence] decimal(19,0)  NOT NULL,
    [EventOccurrence] decimal(19,0)  NOT NULL,
    [EventCode] int  NOT NULL,
    [EventDetailCode] int  NOT NULL,
    [Message] nvarchar(1024)  NULL,
    [ApplicationPath] nvarchar(256)  NULL,
    [ApplicationVirtualPath] nvarchar(256)  NULL,
    [MachineName] nvarchar(256)  NOT NULL,
    [RequestUrl] nvarchar(1024)  NULL,
    [ExceptionType] nvarchar(256)  NULL,
    [Details] nvarchar(max)  NULL
);
GO

-- Creating table 'Disciplines'
CREATE TABLE [dbo].[Disciplines] (
    [DisciplineId] uniqueidentifier  NOT NULL,
    [DisciplineName] nvarchar(max)  NOT NULL,
    [aspnet_Users_UserId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Groups'
CREATE TABLE [dbo].[Groups] (
    [GroupId] uniqueidentifier  NOT NULL,
    [GroupName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Quastions'
CREATE TABLE [dbo].[Quastions] (
    [QuastionId] uniqueidentifier  NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [Test_TestId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Requests'
CREATE TABLE [dbo].[Requests] (
    [RequestId] uniqueidentifier  NOT NULL,
    [Message] nvarchar(max)  NOT NULL,
    [aspnet_Roles_RoleId] uniqueidentifier  NOT NULL,
    [aspnet_Users_UserId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'StudentRequests'
CREATE TABLE [dbo].[StudentRequests] (
    [StudentRequestId] uniqueidentifier  NOT NULL,
    [Message] nvarchar(max)  NOT NULL,
    [Group_GroupId] uniqueidentifier  NOT NULL,
    [aspnet_Users_UserId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Tests'
CREATE TABLE [dbo].[Tests] (
    [TestId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Discipline_DisciplineId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Variants'
CREATE TABLE [dbo].[Variants] (
    [VariantId] uniqueidentifier  NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [IsValid] bit  NOT NULL,
    [Quastion_QuastionId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'aspnet_UsersInRoles'
CREATE TABLE [dbo].[aspnet_UsersInRoles] (
    [aspnet_Roles_RoleId] uniqueidentifier  NOT NULL,
    [aspnet_Users_UserId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'GroupTest'
CREATE TABLE [dbo].[GroupTest] (
    [Groups_GroupId] uniqueidentifier  NOT NULL,
    [Tests_TestId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'GroupUser'
CREATE TABLE [dbo].[GroupUser] (
    [aspnet_Users_UserId] uniqueidentifier  NOT NULL,
    [Groups_GroupId] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ApplicationId] in table 'aspnet_Applications'
ALTER TABLE [dbo].[aspnet_Applications]
ADD CONSTRAINT [PK_aspnet_Applications]
    PRIMARY KEY CLUSTERED ([ApplicationId] ASC);
GO

-- Creating primary key on [UserId] in table 'aspnet_Membership'
ALTER TABLE [dbo].[aspnet_Membership]
ADD CONSTRAINT [PK_aspnet_Membership]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [PathId] in table 'aspnet_Paths'
ALTER TABLE [dbo].[aspnet_Paths]
ADD CONSTRAINT [PK_aspnet_Paths]
    PRIMARY KEY CLUSTERED ([PathId] ASC);
GO

-- Creating primary key on [PathId] in table 'aspnet_PersonalizationAllUsers'
ALTER TABLE [dbo].[aspnet_PersonalizationAllUsers]
ADD CONSTRAINT [PK_aspnet_PersonalizationAllUsers]
    PRIMARY KEY CLUSTERED ([PathId] ASC);
GO

-- Creating primary key on [Id] in table 'aspnet_PersonalizationPerUser'
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser]
ADD CONSTRAINT [PK_aspnet_PersonalizationPerUser]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserId] in table 'aspnet_Profile'
ALTER TABLE [dbo].[aspnet_Profile]
ADD CONSTRAINT [PK_aspnet_Profile]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [RoleId] in table 'aspnet_Roles'
ALTER TABLE [dbo].[aspnet_Roles]
ADD CONSTRAINT [PK_aspnet_Roles]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [Feature], [CompatibleSchemaVersion] in table 'aspnet_SchemaVersions'
ALTER TABLE [dbo].[aspnet_SchemaVersions]
ADD CONSTRAINT [PK_aspnet_SchemaVersions]
    PRIMARY KEY CLUSTERED ([Feature], [CompatibleSchemaVersion] ASC);
GO

-- Creating primary key on [UserId] in table 'aspnet_Users'
ALTER TABLE [dbo].[aspnet_Users]
ADD CONSTRAINT [PK_aspnet_Users]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [EventId] in table 'aspnet_WebEvent_Events'
ALTER TABLE [dbo].[aspnet_WebEvent_Events]
ADD CONSTRAINT [PK_aspnet_WebEvent_Events]
    PRIMARY KEY CLUSTERED ([EventId] ASC);
GO

-- Creating primary key on [DisciplineId] in table 'Disciplines'
ALTER TABLE [dbo].[Disciplines]
ADD CONSTRAINT [PK_Disciplines]
    PRIMARY KEY CLUSTERED ([DisciplineId] ASC);
GO

-- Creating primary key on [GroupId] in table 'Groups'
ALTER TABLE [dbo].[Groups]
ADD CONSTRAINT [PK_Groups]
    PRIMARY KEY CLUSTERED ([GroupId] ASC);
GO

-- Creating primary key on [QuastionId] in table 'Quastions'
ALTER TABLE [dbo].[Quastions]
ADD CONSTRAINT [PK_Quastions]
    PRIMARY KEY CLUSTERED ([QuastionId] ASC);
GO

-- Creating primary key on [RequestId] in table 'Requests'
ALTER TABLE [dbo].[Requests]
ADD CONSTRAINT [PK_Requests]
    PRIMARY KEY CLUSTERED ([RequestId] ASC);
GO

-- Creating primary key on [StudentRequestId] in table 'StudentRequests'
ALTER TABLE [dbo].[StudentRequests]
ADD CONSTRAINT [PK_StudentRequests]
    PRIMARY KEY CLUSTERED ([StudentRequestId] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [TestId] in table 'Tests'
ALTER TABLE [dbo].[Tests]
ADD CONSTRAINT [PK_Tests]
    PRIMARY KEY CLUSTERED ([TestId] ASC);
GO

-- Creating primary key on [VariantId] in table 'Variants'
ALTER TABLE [dbo].[Variants]
ADD CONSTRAINT [PK_Variants]
    PRIMARY KEY CLUSTERED ([VariantId] ASC);
GO

-- Creating primary key on [aspnet_Roles_RoleId], [aspnet_Users_UserId] in table 'aspnet_UsersInRoles'
ALTER TABLE [dbo].[aspnet_UsersInRoles]
ADD CONSTRAINT [PK_aspnet_UsersInRoles]
    PRIMARY KEY CLUSTERED ([aspnet_Roles_RoleId], [aspnet_Users_UserId] ASC);
GO

-- Creating primary key on [Groups_GroupId], [Tests_TestId] in table 'GroupTest'
ALTER TABLE [dbo].[GroupTest]
ADD CONSTRAINT [PK_GroupTest]
    PRIMARY KEY CLUSTERED ([Groups_GroupId], [Tests_TestId] ASC);
GO

-- Creating primary key on [aspnet_Users_UserId], [Groups_GroupId] in table 'GroupUser'
ALTER TABLE [dbo].[GroupUser]
ADD CONSTRAINT [PK_GroupUser]
    PRIMARY KEY CLUSTERED ([aspnet_Users_UserId], [Groups_GroupId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ApplicationId] in table 'aspnet_Membership'
ALTER TABLE [dbo].[aspnet_Membership]
ADD CONSTRAINT [FK__aspnet_Me__Appli__6319B466]
    FOREIGN KEY ([ApplicationId])
    REFERENCES [dbo].[aspnet_Applications]
        ([ApplicationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__aspnet_Me__Appli__6319B466'
CREATE INDEX [IX_FK__aspnet_Me__Appli__6319B466]
ON [dbo].[aspnet_Membership]
    ([ApplicationId]);
GO

-- Creating foreign key on [ApplicationId] in table 'aspnet_Paths'
ALTER TABLE [dbo].[aspnet_Paths]
ADD CONSTRAINT [FK__aspnet_Pa__Appli__10E07F16]
    FOREIGN KEY ([ApplicationId])
    REFERENCES [dbo].[aspnet_Applications]
        ([ApplicationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__aspnet_Pa__Appli__10E07F16'
CREATE INDEX [IX_FK__aspnet_Pa__Appli__10E07F16]
ON [dbo].[aspnet_Paths]
    ([ApplicationId]);
GO

-- Creating foreign key on [ApplicationId] in table 'aspnet_Roles'
ALTER TABLE [dbo].[aspnet_Roles]
ADD CONSTRAINT [FK__aspnet_Ro__Appli__7FB5F314]
    FOREIGN KEY ([ApplicationId])
    REFERENCES [dbo].[aspnet_Applications]
        ([ApplicationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__aspnet_Ro__Appli__7FB5F314'
CREATE INDEX [IX_FK__aspnet_Ro__Appli__7FB5F314]
ON [dbo].[aspnet_Roles]
    ([ApplicationId]);
GO

-- Creating foreign key on [ApplicationId] in table 'aspnet_Users'
ALTER TABLE [dbo].[aspnet_Users]
ADD CONSTRAINT [FK__aspnet_Us__Appli__54CB950F]
    FOREIGN KEY ([ApplicationId])
    REFERENCES [dbo].[aspnet_Applications]
        ([ApplicationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__aspnet_Us__Appli__54CB950F'
CREATE INDEX [IX_FK__aspnet_Us__Appli__54CB950F]
ON [dbo].[aspnet_Users]
    ([ApplicationId]);
GO

-- Creating foreign key on [UserId] in table 'aspnet_Membership'
ALTER TABLE [dbo].[aspnet_Membership]
ADD CONSTRAINT [FK__aspnet_Me__UserI__640DD89F]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[aspnet_Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PathId] in table 'aspnet_PersonalizationAllUsers'
ALTER TABLE [dbo].[aspnet_PersonalizationAllUsers]
ADD CONSTRAINT [FK__aspnet_Pe__PathI__1699586C]
    FOREIGN KEY ([PathId])
    REFERENCES [dbo].[aspnet_Paths]
        ([PathId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PathId] in table 'aspnet_PersonalizationPerUser'
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser]
ADD CONSTRAINT [FK__aspnet_Pe__PathI__1A69E950]
    FOREIGN KEY ([PathId])
    REFERENCES [dbo].[aspnet_Paths]
        ([PathId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__aspnet_Pe__PathI__1A69E950'
CREATE INDEX [IX_FK__aspnet_Pe__PathI__1A69E950]
ON [dbo].[aspnet_PersonalizationPerUser]
    ([PathId]);
GO

-- Creating foreign key on [UserId] in table 'aspnet_PersonalizationPerUser'
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser]
ADD CONSTRAINT [FK__aspnet_Pe__UserI__1B5E0D89]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[aspnet_Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__aspnet_Pe__UserI__1B5E0D89'
CREATE INDEX [IX_FK__aspnet_Pe__UserI__1B5E0D89]
ON [dbo].[aspnet_PersonalizationPerUser]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'aspnet_Profile'
ALTER TABLE [dbo].[aspnet_Profile]
ADD CONSTRAINT [FK__aspnet_Pr__UserI__7720AD13]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[aspnet_Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [aspnet_Roles_RoleId] in table 'Requests'
ALTER TABLE [dbo].[Requests]
ADD CONSTRAINT [FK_RequestSet_aspnet_Roles]
    FOREIGN KEY ([aspnet_Roles_RoleId])
    REFERENCES [dbo].[aspnet_Roles]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RequestSet_aspnet_Roles'
CREATE INDEX [IX_FK_RequestSet_aspnet_Roles]
ON [dbo].[Requests]
    ([aspnet_Roles_RoleId]);
GO

-- Creating foreign key on [aspnet_Users_UserId] in table 'Disciplines'
ALTER TABLE [dbo].[Disciplines]
ADD CONSTRAINT [FK_DisciplineSet_aspnet_Users]
    FOREIGN KEY ([aspnet_Users_UserId])
    REFERENCES [dbo].[aspnet_Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DisciplineSet_aspnet_Users'
CREATE INDEX [IX_FK_DisciplineSet_aspnet_Users]
ON [dbo].[Disciplines]
    ([aspnet_Users_UserId]);
GO

-- Creating foreign key on [aspnet_Users_UserId] in table 'Requests'
ALTER TABLE [dbo].[Requests]
ADD CONSTRAINT [FK_RequestSet_aspnet_Users]
    FOREIGN KEY ([aspnet_Users_UserId])
    REFERENCES [dbo].[aspnet_Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RequestSet_aspnet_Users'
CREATE INDEX [IX_FK_RequestSet_aspnet_Users]
ON [dbo].[Requests]
    ([aspnet_Users_UserId]);
GO

-- Creating foreign key on [aspnet_Users_UserId] in table 'StudentRequests'
ALTER TABLE [dbo].[StudentRequests]
ADD CONSTRAINT [FK_StudentRequestSet_aspnet_Users]
    FOREIGN KEY ([aspnet_Users_UserId])
    REFERENCES [dbo].[aspnet_Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentRequestSet_aspnet_Users'
CREATE INDEX [IX_FK_StudentRequestSet_aspnet_Users]
ON [dbo].[StudentRequests]
    ([aspnet_Users_UserId]);
GO

-- Creating foreign key on [Discipline_DisciplineId] in table 'Tests'
ALTER TABLE [dbo].[Tests]
ADD CONSTRAINT [FK_DisciplineTest]
    FOREIGN KEY ([Discipline_DisciplineId])
    REFERENCES [dbo].[Disciplines]
        ([DisciplineId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DisciplineTest'
CREATE INDEX [IX_FK_DisciplineTest]
ON [dbo].[Tests]
    ([Discipline_DisciplineId]);
GO

-- Creating foreign key on [Group_GroupId] in table 'StudentRequests'
ALTER TABLE [dbo].[StudentRequests]
ADD CONSTRAINT [FK_GroupStudentRequest]
    FOREIGN KEY ([Group_GroupId])
    REFERENCES [dbo].[Groups]
        ([GroupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupStudentRequest'
CREATE INDEX [IX_FK_GroupStudentRequest]
ON [dbo].[StudentRequests]
    ([Group_GroupId]);
GO

-- Creating foreign key on [Quastion_QuastionId] in table 'Variants'
ALTER TABLE [dbo].[Variants]
ADD CONSTRAINT [FK_QuastionVariant]
    FOREIGN KEY ([Quastion_QuastionId])
    REFERENCES [dbo].[Quastions]
        ([QuastionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_QuastionVariant'
CREATE INDEX [IX_FK_QuastionVariant]
ON [dbo].[Variants]
    ([Quastion_QuastionId]);
GO

-- Creating foreign key on [Test_TestId] in table 'Quastions'
ALTER TABLE [dbo].[Quastions]
ADD CONSTRAINT [FK_TestQuastion]
    FOREIGN KEY ([Test_TestId])
    REFERENCES [dbo].[Tests]
        ([TestId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestQuastion'
CREATE INDEX [IX_FK_TestQuastion]
ON [dbo].[Quastions]
    ([Test_TestId]);
GO

-- Creating foreign key on [aspnet_Roles_RoleId] in table 'aspnet_UsersInRoles'
ALTER TABLE [dbo].[aspnet_UsersInRoles]
ADD CONSTRAINT [FK_aspnet_UsersInRoles_aspnet_Roles]
    FOREIGN KEY ([aspnet_Roles_RoleId])
    REFERENCES [dbo].[aspnet_Roles]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [aspnet_Users_UserId] in table 'aspnet_UsersInRoles'
ALTER TABLE [dbo].[aspnet_UsersInRoles]
ADD CONSTRAINT [FK_aspnet_UsersInRoles_aspnet_Users]
    FOREIGN KEY ([aspnet_Users_UserId])
    REFERENCES [dbo].[aspnet_Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_aspnet_UsersInRoles_aspnet_Users'
CREATE INDEX [IX_FK_aspnet_UsersInRoles_aspnet_Users]
ON [dbo].[aspnet_UsersInRoles]
    ([aspnet_Users_UserId]);
GO

-- Creating foreign key on [Groups_GroupId] in table 'GroupTest'
ALTER TABLE [dbo].[GroupTest]
ADD CONSTRAINT [FK_GroupTest_Group]
    FOREIGN KEY ([Groups_GroupId])
    REFERENCES [dbo].[Groups]
        ([GroupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Tests_TestId] in table 'GroupTest'
ALTER TABLE [dbo].[GroupTest]
ADD CONSTRAINT [FK_GroupTest_Test]
    FOREIGN KEY ([Tests_TestId])
    REFERENCES [dbo].[Tests]
        ([TestId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupTest_Test'
CREATE INDEX [IX_FK_GroupTest_Test]
ON [dbo].[GroupTest]
    ([Tests_TestId]);
GO

-- Creating foreign key on [aspnet_Users_UserId] in table 'GroupUser'
ALTER TABLE [dbo].[GroupUser]
ADD CONSTRAINT [FK_GroupUser_aspnet_Users]
    FOREIGN KEY ([aspnet_Users_UserId])
    REFERENCES [dbo].[aspnet_Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Groups_GroupId] in table 'GroupUser'
ALTER TABLE [dbo].[GroupUser]
ADD CONSTRAINT [FK_GroupUser_Group]
    FOREIGN KEY ([Groups_GroupId])
    REFERENCES [dbo].[Groups]
        ([GroupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupUser_Group'
CREATE INDEX [IX_FK_GroupUser_Group]
ON [dbo].[GroupUser]
    ([Groups_GroupId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------