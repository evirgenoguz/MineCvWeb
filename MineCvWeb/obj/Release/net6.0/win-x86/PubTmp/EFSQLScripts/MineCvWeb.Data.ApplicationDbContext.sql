IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220612231231_AddTableToDatabase')
BEGIN
    CREATE TABLE [Eduations] (
        [Id] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [University] nvarchar(max) NOT NULL,
        [Department] nvarchar(max) NOT NULL,
        [EntranceYear] int NOT NULL,
        [GraduationYear] int NOT NULL,
        [GPA] real NOT NULL,
        CONSTRAINT [PK_Eduations] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220612231231_AddTableToDatabase')
BEGIN
    CREATE TABLE [Experiences] (
        [Id] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [JobTitle] nvarchar(max) NOT NULL,
        [Company] nvarchar(max) NOT NULL,
        [HowManyYear] int NOT NULL,
        CONSTRAINT [PK_Experiences] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220612231231_AddTableToDatabase')
BEGIN
    CREATE TABLE [Languages] (
        [Id] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [LanguageName] nvarchar(max) NOT NULL,
        [LanguageLevel] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Languages] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220612231231_AddTableToDatabase')
BEGIN
    CREATE TABLE [Resumes] (
        [Id] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Surname] nvarchar(max) NOT NULL,
        [Adress] nvarchar(max) NOT NULL,
        [PhoneNumber] nvarchar(max) NOT NULL,
        [Age] int NOT NULL,
        [JobTitle] nvarchar(max) NOT NULL,
        [MyDescription] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Resumes] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220612231231_AddTableToDatabase')
BEGIN
    CREATE TABLE [Skills] (
        [Id] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [SkillName] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Skills] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220612231231_AddTableToDatabase')
BEGIN
    CREATE TABLE [Users] (
        [Id] int NOT NULL IDENTITY,
        [Email] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Surname] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220612231231_AddTableToDatabase')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220612231231_AddTableToDatabase', N'6.0.5');
END;
GO

COMMIT;
GO

