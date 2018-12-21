
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/21/2018 15:55:31
-- Generated from EDMX file: C:\Users\JZimmerman\source\repos\DevBuild.Assessment6-WebForm\DevBuild.Assessment6-WebForm\Models\PartyDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PartyDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Guest_GameOfThronesCharacters]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Guest] DROP CONSTRAINT [FK_Guest_GameOfThronesCharacters];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Dish]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dish];
GO
IF OBJECT_ID(N'[dbo].[GameOfThronesCharacters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GameOfThronesCharacters];
GO
IF OBJECT_ID(N'[dbo].[Guest]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Guest];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Dishes'
CREATE TABLE [dbo].[Dishes] (
    [DishID] int IDENTITY(1,1) NOT NULL,
    [PersonName] nvarchar(50)  NULL,
    [PhoneNumber] nvarchar(24)  NULL,
    [DishName] nvarchar(50)  NULL,
    [DishDescription] nvarchar(100)  NULL,
    [Option] nchar(20)  NULL,
    [GuestID] int  NULL
);
GO

-- Creating table 'GameOfThronesCharacters'
CREATE TABLE [dbo].[GameOfThronesCharacters] (
    [CharacterID] int  NOT NULL,
    [Name] nvarchar(128)  NULL,
    [Aliases] nvarchar(max)  NULL,
    [Titles] nvarchar(max)  NULL,
    [Mother] nvarchar(50)  NULL,
    [Father] nvarchar(50)  NULL,
    [Gender] nvarchar(50)  NULL,
    [Culture] nvarchar(50)  NULL,
    [House] nvarchar(50)  NULL,
    [Allegiance] nvarchar(50)  NULL,
    [Book] nvarchar(50)  NULL,
    [Url] nvarchar(max)  NULL
);
GO

-- Creating table 'Guests'
CREATE TABLE [dbo].[Guests] (
    [GuestID] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(50)  NULL,
    [LastName] nvarchar(50)  NULL,
    [AttendanceDate] datetime  NULL,
    [EmailAddress] nvarchar(50)  NULL,
    [IsAttending] bit  NULL,
    [HasAPlusOne] bit  NULL,
    [Guest1] nvarchar(50)  NULL,
    [BringingADish] bit  NULL,
    [DishID] int  NULL,
    [CharacterID] int  NULL
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

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [DishID] in table 'Dishes'
ALTER TABLE [dbo].[Dishes]
ADD CONSTRAINT [PK_Dishes]
    PRIMARY KEY CLUSTERED ([DishID] ASC);
GO

-- Creating primary key on [CharacterID] in table 'GameOfThronesCharacters'
ALTER TABLE [dbo].[GameOfThronesCharacters]
ADD CONSTRAINT [PK_GameOfThronesCharacters]
    PRIMARY KEY CLUSTERED ([CharacterID] ASC);
GO

-- Creating primary key on [GuestID] in table 'Guests'
ALTER TABLE [dbo].[Guests]
ADD CONSTRAINT [PK_Guests]
    PRIMARY KEY CLUSTERED ([GuestID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CharacterID] in table 'Guests'
ALTER TABLE [dbo].[Guests]
ADD CONSTRAINT [FK_Guest_GameOfThronesCharacters]
    FOREIGN KEY ([CharacterID])
    REFERENCES [dbo].[GameOfThronesCharacters]
        ([CharacterID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Guest_GameOfThronesCharacters'
CREATE INDEX [IX_FK_Guest_GameOfThronesCharacters]
ON [dbo].[Guests]
    ([CharacterID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------