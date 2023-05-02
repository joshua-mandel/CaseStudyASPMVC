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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181729_Initial')
BEGIN
    CREATE TABLE [Countries] (
        [CountryId] nvarchar(450) NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Countries] PRIMARY KEY ([CountryId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181729_Initial')
BEGIN
    CREATE TABLE [Products] (
        [ProductId] int NOT NULL IDENTITY,
        [ProductCode] nvarchar(max) NOT NULL,
        [ProductName] nvarchar(max) NOT NULL,
        [YearlyPrice] float NOT NULL,
        [ReleaseDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([ProductId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181729_Initial')
BEGIN
    CREATE TABLE [Technicians] (
        [TechnicianId] int NOT NULL IDENTITY,
        [TechnicianName] nvarchar(max) NOT NULL,
        [TechnicianEmail] nvarchar(max) NOT NULL,
        [TechnicianPhone] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Technicians] PRIMARY KEY ([TechnicianId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181729_Initial')
BEGIN
    CREATE TABLE [Customers] (
        [CustomerId] int NOT NULL IDENTITY,
        [FirstName] nvarchar(51) NOT NULL,
        [LastName] nvarchar(51) NOT NULL,
        [Address] nvarchar(51) NOT NULL,
        [City] nvarchar(51) NOT NULL,
        [State] nvarchar(51) NOT NULL,
        [PostalCode] nvarchar(21) NOT NULL,
        [CountryId] nvarchar(450) NOT NULL,
        [EmailAddress] nvarchar(51) NULL,
        [Phone] nvarchar(max) NULL,
        CONSTRAINT [PK_Customers] PRIMARY KEY ([CustomerId]),
        CONSTRAINT [FK_Customers_Countries_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [Countries] ([CountryId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181729_Initial')
BEGIN
    CREATE TABLE [CustomerProduct] (
        [CustomersCustomerId] int NOT NULL,
        [ProductsProductId] int NOT NULL,
        CONSTRAINT [PK_CustomerProduct] PRIMARY KEY ([CustomersCustomerId], [ProductsProductId]),
        CONSTRAINT [FK_CustomerProduct_Customers_CustomersCustomerId] FOREIGN KEY ([CustomersCustomerId]) REFERENCES [Customers] ([CustomerId]) ON DELETE CASCADE,
        CONSTRAINT [FK_CustomerProduct_Products_ProductsProductId] FOREIGN KEY ([ProductsProductId]) REFERENCES [Products] ([ProductId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181729_Initial')
BEGIN
    CREATE TABLE [Incidents] (
        [IncidentId] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [ProductId] int NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [CustomerId] int NOT NULL,
        [TechnicianId] int NOT NULL,
        [DateOpened] datetime2 NOT NULL,
        [DateClosed] datetime2 NULL,
        CONSTRAINT [PK_Incidents] PRIMARY KEY ([IncidentId]),
        CONSTRAINT [FK_Incidents_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([CustomerId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Incidents_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([ProductId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Incidents_Technicians_TechnicianId] FOREIGN KEY ([TechnicianId]) REFERENCES [Technicians] ([TechnicianId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181729_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CountryId', N'Name') AND [object_id] = OBJECT_ID(N'[Countries]'))
        SET IDENTITY_INSERT [Countries] ON;
    EXEC(N'INSERT INTO [Countries] ([CountryId], [Name])
    VALUES (N''A'', N''United States''),
    (N''B'', N''Mexico''),
    (N''C'', N''Canada''),
    (N''D'', N''United Kingdom''),
    (N''E'', N''Australia'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CountryId', N'Name') AND [object_id] = OBJECT_ID(N'[Countries]'))
        SET IDENTITY_INSERT [Countries] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181729_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProductId', N'ProductCode', N'ProductName', N'ReleaseDate', N'YearlyPrice') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] ON;
    EXEC(N'INSERT INTO [Products] ([ProductId], [ProductCode], [ProductName], [ReleaseDate], [YearlyPrice])
    VALUES (1, N''TRNY10'', N''Tournament Master 1.0'', ''2023-04-21T00:00:00.0000000-05:00'', 4.9900000000000002E0),
    (2, N''LEAG10'', N''League Scheduler 1.0'', ''2023-04-21T00:00:00.0000000-05:00'', 4.9900000000000002E0),
    (3, N''LEAGD10'', N''League Scheduler Deluxe 1.0'', ''2023-04-21T00:00:00.0000000-05:00'', 7.9900000000000002E0),
    (4, N''DRAFT10'', N''Draft Manager 1.0'', ''2023-04-21T00:00:00.0000000-05:00'', 4.9900000000000002E0),
    (5, N''TEAM10'', N''Team Manager 1.0'', ''2023-04-21T00:00:00.0000000-05:00'', 4.9900000000000002E0),
    (6, N''TRNY20'', N''Tournament Master 2.0'', ''2023-04-21T00:00:00.0000000-05:00'', 5.9900000000000002E0),
    (7, N''DRAFT20'', N''Draft Manager 2.0'', ''2023-04-21T00:00:00.0000000-05:00'', 5.9900000000000002E0)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProductId', N'ProductCode', N'ProductName', N'ReleaseDate', N'YearlyPrice') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181729_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'TechnicianId', N'TechnicianEmail', N'TechnicianName', N'TechnicianPhone') AND [object_id] = OBJECT_ID(N'[Technicians]'))
        SET IDENTITY_INSERT [Technicians] ON;
    EXEC(N'INSERT INTO [Technicians] ([TechnicianId], [TechnicianEmail], [TechnicianName], [TechnicianPhone])
    VALUES (-1, N'''', N'''', N''''),
    (1, N''alison@sportsprosoftware.com'', N''Alison Diaz'', N''800-555-0443''),
    (2, N''awilson@sportsprosoftware.com'', N''Andrew Wilson'', N''800-555-0449''),
    (3, N''gfiori@sportsprosoftware.com'', N''Gina Fiori'', N''800-555-0459''),
    (4, N''gunter@sportsprosoftware.com'', N''Gunter Wendt'', N''800-555-0400''),
    (5, N''jason@sportsprosoftware.com'', N''Jason Lee'', N''800-555-0444'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'TechnicianId', N'TechnicianEmail', N'TechnicianName', N'TechnicianPhone') AND [object_id] = OBJECT_ID(N'[Technicians]'))
        SET IDENTITY_INSERT [Technicians] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181729_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CustomerId', N'Address', N'City', N'CountryId', N'EmailAddress', N'FirstName', N'LastName', N'Phone', N'PostalCode', N'State') AND [object_id] = OBJECT_ID(N'[Customers]'))
        SET IDENTITY_INSERT [Customers] ON;
    EXEC(N'INSERT INTO [Customers] ([CustomerId], [Address], [City], [CountryId], [EmailAddress], [FirstName], [LastName], [Phone], [PostalCode], [State])
    VALUES (1, N''123 Spooner Street'', N''San Francisco'', N''A'', N''kanthoni@pge.com'', N''Kaitlyn'', N''Anthoni'', N''970-331-1691'', N''63141'', N''California''),
    (2, N''123 Spooner Street'', N''Washington'', N''A'', N''ania@mma.nidc.com'', N''Ania'', N''Irvin'', N''970-331-1691'', N''63141'', N''California''),
    (3, N''123 Spooner Street'', N''Mission Viejo'', N''B'', NULL, N''Gonzalo'', N''Keeton'', N''970-331-1691'', N''63141'', N''California''),
    (4, N''123 Spooner Street'', N''Sacramento'', N''A'', N''amauro@yahoo.org'', N''Anton'', N''Mauro'', N''970-331-1691'', N''63141'', N''California''),
    (5, N''123 Spooner Street'', N''Fresno'', N''A'', N''kmayte@fresno.ca.gov'', N''Kendall'', N''Mayte'', N''970-331-1691'', N''63141'', N''California''),
    (6, N''123 Spooner Street'', N''Los Angeles'', N''A'', N''kenzie@mma.jobtrak.com'', N''Kenzie'', N''Quinn'', N''970-331-1691'', N''63141'', N''California''),
    (7, N''123 Spooner Street'', N''Fresno'', N''A'', N''marvin@expedata.com'', N''Marvin'', N''Quintin'', NULL, N''63141'', N''California'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CustomerId', N'Address', N'City', N'CountryId', N'EmailAddress', N'FirstName', N'LastName', N'Phone', N'PostalCode', N'State') AND [object_id] = OBJECT_ID(N'[Customers]'))
        SET IDENTITY_INSERT [Customers] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181729_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IncidentId', N'CustomerId', N'DateClosed', N'DateOpened', N'Description', N'ProductId', N'TechnicianId', N'Title') AND [object_id] = OBJECT_ID(N'[Incidents]'))
        SET IDENTITY_INSERT [Incidents] ON;
    EXEC(N'INSERT INTO [Incidents] ([IncidentId], [CustomerId], [DateClosed], [DateOpened], [Description], [ProductId], [TechnicianId], [Title])
    VALUES (1, 5, NULL, ''2023-04-21T13:17:29.3081281-05:00'', N''Program fails with error code 510, unable to open database.'', 2, 4, N''Error launching program''),
    (2, 2, NULL, ''2023-04-21T13:17:29.3081284-05:00'', N''Program fails with error code 510, unable to open database.'', 7, 1, N''Could not install''),
    (3, 3, NULL, ''2023-04-21T13:17:29.3081288-05:00'', N''Program fails with error code 510, unable to open database.'', 1, 3, N''Error launching program''),
    (4, 5, NULL, ''2023-04-21T13:17:29.3081291-05:00'', N''Program fails with error code 510, unable to open database.'', 4, 2, N''Program keeps crashing'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IncidentId', N'CustomerId', N'DateClosed', N'DateOpened', N'Description', N'ProductId', N'TechnicianId', N'Title') AND [object_id] = OBJECT_ID(N'[Incidents]'))
        SET IDENTITY_INSERT [Incidents] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181729_Initial')
BEGIN
    CREATE INDEX [IX_CustomerProduct_ProductsProductId] ON [CustomerProduct] ([ProductsProductId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181729_Initial')
BEGIN
    CREATE INDEX [IX_Customers_CountryId] ON [Customers] ([CountryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181729_Initial')
BEGIN
    CREATE INDEX [IX_Incidents_CustomerId] ON [Incidents] ([CustomerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181729_Initial')
BEGIN
    CREATE INDEX [IX_Incidents_ProductId] ON [Incidents] ([ProductId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181729_Initial')
BEGIN
    CREATE INDEX [IX_Incidents_TechnicianId] ON [Incidents] ([TechnicianId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181729_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230421181729_Initial', N'7.0.2');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181935_Initial2')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181935_Initial2')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181935_Initial2')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181935_Initial2')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181935_Initial2')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181935_Initial2')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181935_Initial2')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181935_Initial2')
BEGIN
    EXEC(N'UPDATE [Incidents] SET [DateOpened] = ''2023-04-21T13:19:35.1107835-05:00''
    WHERE [IncidentId] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181935_Initial2')
BEGIN
    EXEC(N'UPDATE [Incidents] SET [DateOpened] = ''2023-04-21T13:19:35.1107839-05:00''
    WHERE [IncidentId] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181935_Initial2')
BEGIN
    EXEC(N'UPDATE [Incidents] SET [DateOpened] = ''2023-04-21T13:19:35.1107842-05:00''
    WHERE [IncidentId] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181935_Initial2')
BEGIN
    EXEC(N'UPDATE [Incidents] SET [DateOpened] = ''2023-04-21T13:19:35.1107845-05:00''
    WHERE [IncidentId] = 4;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181935_Initial2')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181935_Initial2')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181935_Initial2')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181935_Initial2')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181935_Initial2')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181935_Initial2')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181935_Initial2')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421181935_Initial2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230421181935_Initial2', N'7.0.2');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421200058_Updatesss')
BEGIN
    ALTER TABLE [Incidents] DROP CONSTRAINT [FK_Incidents_Technicians_TechnicianId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421200058_Updatesss')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Incidents]') AND [c].[name] = N'TechnicianId');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Incidents] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Incidents] ALTER COLUMN [TechnicianId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421200058_Updatesss')
BEGIN
    EXEC(N'UPDATE [Incidents] SET [DateOpened] = ''2023-04-21T15:00:58.5897716-05:00''
    WHERE [IncidentId] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421200058_Updatesss')
BEGIN
    EXEC(N'UPDATE [Incidents] SET [DateOpened] = ''2023-04-21T15:00:58.5897719-05:00''
    WHERE [IncidentId] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421200058_Updatesss')
BEGIN
    EXEC(N'UPDATE [Incidents] SET [DateOpened] = ''2023-04-21T15:00:58.5897723-05:00''
    WHERE [IncidentId] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421200058_Updatesss')
BEGIN
    EXEC(N'UPDATE [Incidents] SET [DateOpened] = ''2023-04-21T15:00:58.5897726-05:00''
    WHERE [IncidentId] = 4;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421200058_Updatesss')
BEGIN
    ALTER TABLE [Incidents] ADD CONSTRAINT [FK_Incidents_Technicians_TechnicianId] FOREIGN KEY ([TechnicianId]) REFERENCES [Technicians] ([TechnicianId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421200058_Updatesss')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230421200058_Updatesss', N'7.0.2');
END;
GO

COMMIT;
GO

