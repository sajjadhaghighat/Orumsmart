
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/30/2021 16:56:13
-- Generated from EDMX file: C:\Users\sajjad\source\repos\Ourmsmart\Ourmsmart\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [VIRADB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__OrderAddres__OID__1ED998B2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderAddress] DROP CONSTRAINT [FK__OrderAddres__OID__1ED998B2];
GO
IF OBJECT_ID(N'[dbo].[FK__Orders__PID__1BFD2C07]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK__Orders__PID__1BFD2C07];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Contact]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contact];
GO
IF OBJECT_ID(N'[dbo].[ENContents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ENContents];
GO
IF OBJECT_ID(N'[dbo].[ENProducts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ENProducts];
GO
IF OBJECT_ID(N'[dbo].[ENUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ENUsers];
GO
IF OBJECT_ID(N'[dbo].[FAContents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FAContents];
GO
IF OBJECT_ID(N'[dbo].[FAProducts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FAProducts];
GO
IF OBJECT_ID(N'[dbo].[FAUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FAUsers];
GO
IF OBJECT_ID(N'[dbo].[OrderAddress]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderAddress];
GO
IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Contacts'
CREATE TABLE [dbo].[Contacts] (
    [CoID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(255)  NOT NULL,
    [Email] nvarchar(255)  NOT NULL,
    [Subject] nvarchar(255)  NOT NULL,
    [Message] nvarchar(max)  NOT NULL,
    [Timestamp] nvarchar(255)  NOT NULL
);
GO

-- Creating table 'ENContents'
CREATE TABLE [dbo].[ENContents] (
    [CID] int IDENTITY(1,1) NOT NULL,
    [title] nvarchar(255)  NOT NULL,
    [content] nvarchar(max)  NULL
);
GO

-- Creating table 'ENProducts'
CREATE TABLE [dbo].[ENProducts] (
    [PID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(255)  NOT NULL,
    [Summary] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Price] nvarchar(255)  NOT NULL,
    [Status] nvarchar(255)  NOT NULL,
    [Qty] int  NOT NULL,
    [Imagepath] nvarchar(max)  NULL,
    [Ptype] nvarchar(255)  NOT NULL,
    [Pmodel] nvarchar(255)  NOT NULL
);
GO

-- Creating table 'ENUsers'
CREATE TABLE [dbo].[ENUsers] (
    [UID] int IDENTITY(1,1) NOT NULL,
    [Fullname] nvarchar(255)  NOT NULL,
    [Username] nvarchar(255)  NOT NULL,
    [Password] nvarchar(255)  NOT NULL,
    [Email] nvarchar(255)  NOT NULL,
    [Bio] nvarchar(max)  NULL,
    [Team] nvarchar(255)  NULL,
    [Type] nvarchar(255)  NOT NULL,
    [Imagepath] nvarchar(max)  NULL
);
GO

-- Creating table 'FAContents'
CREATE TABLE [dbo].[FAContents] (
    [CID] int IDENTITY(1,1) NOT NULL,
    [title] nvarchar(255)  NOT NULL,
    [content] nvarchar(max)  NULL
);
GO

-- Creating table 'FAProducts'
CREATE TABLE [dbo].[FAProducts] (
    [PID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(255)  NOT NULL,
    [Summary] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Price] nvarchar(255)  NOT NULL,
    [Status] nvarchar(255)  NOT NULL,
    [Qty] int  NOT NULL,
    [Imagepath] nvarchar(max)  NULL,
    [Ptype] nvarchar(255)  NOT NULL,
    [Pmodel] nvarchar(255)  NOT NULL
);
GO

-- Creating table 'FAUsers'
CREATE TABLE [dbo].[FAUsers] (
    [UID] int IDENTITY(1,1) NOT NULL,
    [Fullname] nvarchar(255)  NOT NULL,
    [Username] nvarchar(255)  NOT NULL,
    [Password] nvarchar(255)  NOT NULL,
    [Email] nvarchar(255)  NOT NULL,
    [Bio] nvarchar(max)  NULL,
    [Team] nvarchar(255)  NULL,
    [Type] nvarchar(255)  NOT NULL,
    [Imagepath] nvarchar(max)  NULL
);
GO

-- Creating table 'OrderAddresses'
CREATE TABLE [dbo].[OrderAddresses] (
    [AID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(255)  NOT NULL,
    [Ostan] nvarchar(255)  NOT NULL,
    [City] nvarchar(255)  NOT NULL,
    [Address] nvarchar(255)  NOT NULL,
    [Phone] nvarchar(255)  NOT NULL,
    [Email] nvarchar(255)  NOT NULL,
    [Codeposti] nvarchar(255)  NOT NULL,
    [Cartid] int  NULL,
    [OID] int  NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [OID] int IDENTITY(1,1) NOT NULL,
    [Cartid] int  NOT NULL,
    [Oqty] int  NOT NULL,
    [Timestamp] nvarchar(255)  NOT NULL,
    [Price] nvarchar(255)  NOT NULL,
    [Status] nvarchar(255)  NOT NULL,
    [Paycode] nvarchar(255)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Tracingcode] nvarchar(max)  NULL,
    [PID] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CoID] in table 'Contacts'
ALTER TABLE [dbo].[Contacts]
ADD CONSTRAINT [PK_Contacts]
    PRIMARY KEY CLUSTERED ([CoID] ASC);
GO

-- Creating primary key on [CID] in table 'ENContents'
ALTER TABLE [dbo].[ENContents]
ADD CONSTRAINT [PK_ENContents]
    PRIMARY KEY CLUSTERED ([CID] ASC);
GO

-- Creating primary key on [PID] in table 'ENProducts'
ALTER TABLE [dbo].[ENProducts]
ADD CONSTRAINT [PK_ENProducts]
    PRIMARY KEY CLUSTERED ([PID] ASC);
GO

-- Creating primary key on [UID] in table 'ENUsers'
ALTER TABLE [dbo].[ENUsers]
ADD CONSTRAINT [PK_ENUsers]
    PRIMARY KEY CLUSTERED ([UID] ASC);
GO

-- Creating primary key on [CID] in table 'FAContents'
ALTER TABLE [dbo].[FAContents]
ADD CONSTRAINT [PK_FAContents]
    PRIMARY KEY CLUSTERED ([CID] ASC);
GO

-- Creating primary key on [PID] in table 'FAProducts'
ALTER TABLE [dbo].[FAProducts]
ADD CONSTRAINT [PK_FAProducts]
    PRIMARY KEY CLUSTERED ([PID] ASC);
GO

-- Creating primary key on [UID] in table 'FAUsers'
ALTER TABLE [dbo].[FAUsers]
ADD CONSTRAINT [PK_FAUsers]
    PRIMARY KEY CLUSTERED ([UID] ASC);
GO

-- Creating primary key on [AID] in table 'OrderAddresses'
ALTER TABLE [dbo].[OrderAddresses]
ADD CONSTRAINT [PK_OrderAddresses]
    PRIMARY KEY CLUSTERED ([AID] ASC);
GO

-- Creating primary key on [OID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([OID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK__Orders__PID__1BFD2C07]
    FOREIGN KEY ([PID])
    REFERENCES [dbo].[FAProducts]
        ([PID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Orders__PID__1BFD2C07'
CREATE INDEX [IX_FK__Orders__PID__1BFD2C07]
ON [dbo].[Orders]
    ([PID]);
GO

-- Creating foreign key on [OID] in table 'OrderAddresses'
ALTER TABLE [dbo].[OrderAddresses]
ADD CONSTRAINT [FK__OrderAddres__OID__1ED998B2]
    FOREIGN KEY ([OID])
    REFERENCES [dbo].[Orders]
        ([OID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__OrderAddres__OID__1ED998B2'
CREATE INDEX [IX_FK__OrderAddres__OID__1ED998B2]
ON [dbo].[OrderAddresses]
    ([OID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------