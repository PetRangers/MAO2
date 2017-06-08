
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/08/2017 09:33:20
-- Generated from EDMX file: C:\Users\III\Desktop\0607MAO2-CRUD\CaptainMao\CaptainMao\Areas\Hospital\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Mao];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Adoption_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Adoption] DROP CONSTRAINT [FK_Adoption_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_Adoption_Categories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Adoption] DROP CONSTRAINT [FK_Adoption_Categories];
GO
IF OBJECT_ID(N'[dbo].[FK_Adoption_Citys]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Adoption] DROP CONSTRAINT [FK_Adoption_Citys];
GO
IF OBJECT_ID(N'[dbo].[FK_AdpWish_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdpWish] DROP CONSTRAINT [FK_AdpWish_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_AdpWish_Categories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdpWish] DROP CONSTRAINT [FK_AdpWish_Categories];
GO
IF OBJECT_ID(N'[dbo].[FK_AdpWish_Citys]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdpWish] DROP CONSTRAINT [FK_AdpWish_Citys];
GO
IF OBJECT_ID(N'[dbo].[FK_Article_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Article] DROP CONSTRAINT [FK_Article_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_Article_Board]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Article] DROP CONSTRAINT [FK_Article_Board];
GO
IF OBJECT_ID(N'[dbo].[FK_Article_TitleCategories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Article] DROP CONSTRAINT [FK_Article_TitleCategories];
GO
IF OBJECT_ID(N'[dbo].[FK_Board_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Board] DROP CONSTRAINT [FK_Board_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_Comment_Article]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comment] DROP CONSTRAINT [FK_Comment_Article];
GO
IF OBJECT_ID(N'[dbo].[FK_Comment_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comment] DROP CONSTRAINT [FK_Comment_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_Hospital_Citys]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Hospital] DROP CONSTRAINT [FK_Hospital_Citys];
GO
IF OBJECT_ID(N'[dbo].[FK_HospitalCategoryDetails_Categories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HospitalCategoryDetails] DROP CONSTRAINT [FK_HospitalCategoryDetails_Categories];
GO
IF OBJECT_ID(N'[dbo].[FK_HospitalCategoryDetails_Hospital]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HospitalCategoryDetails] DROP CONSTRAINT [FK_HospitalCategoryDetails_Hospital];
GO
IF OBJECT_ID(N'[MaoModel1StoreContainer].[FK_Scorce_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [MaoModel1StoreContainer].[Scorce] DROP CONSTRAINT [FK_Scorce_AspNetUsers];
GO
IF OBJECT_ID(N'[MaoModel1StoreContainer].[FK_Scorce_Hospital]', 'F') IS NOT NULL
    ALTER TABLE [MaoModel1StoreContainer].[Scorce] DROP CONSTRAINT [FK_Scorce_Hospital];
GO
IF OBJECT_ID(N'[dbo].[FK_UserPet_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserPet] DROP CONSTRAINT [FK_UserPet_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_UserPet_Categories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserPet] DROP CONSTRAINT [FK_UserPet_Categories];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[Adoption]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Adoption];
GO
IF OBJECT_ID(N'[dbo].[AdpWish]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdpWish];
GO
IF OBJECT_ID(N'[dbo].[Article]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Article];
GO
IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[Board]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Board];
GO
IF OBJECT_ID(N'[dbo].[Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categories];
GO
IF OBJECT_ID(N'[dbo].[Citys]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Citys];
GO
IF OBJECT_ID(N'[dbo].[Comment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comment];
GO
IF OBJECT_ID(N'[dbo].[Hospital]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Hospital];
GO
IF OBJECT_ID(N'[dbo].[HospitalCategoryDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HospitalCategoryDetails];
GO
IF OBJECT_ID(N'[dbo].[TitleCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TitleCategories];
GO
IF OBJECT_ID(N'[dbo].[UserPet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserPet];
GO
IF OBJECT_ID(N'[MaoModel1StoreContainer].[Scorce]', 'U') IS NOT NULL
    DROP TABLE [MaoModel1StoreContainer].[Scorce];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'Adoption'
CREATE TABLE [dbo].[Adoption] (
    [AdoptionID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Sex] nchar(10)  NOT NULL,
    [CategoryID] int  NOT NULL,
    [Build] nchar(10)  NOT NULL,
    [Age] nchar(10)  NULL,
    [CityID] int  NOT NULL,
    [Hair] nchar(10)  NULL,
    [Description] nvarchar(50)  NULL,
    [PostDate] datetime  NOT NULL,
    [BytesImage] varbinary(max)  NULL,
    [PetImage] nvarchar(50)  NULL,
    [DelCheck] bit  NOT NULL,
    [RegistrationUserID] nvarchar(128)  NULL
);
GO

-- Creating table 'AdpWish'
CREATE TABLE [dbo].[AdpWish] (
    [WishID] int IDENTITY(1,1) NOT NULL,
    [UserID] nvarchar(128)  NOT NULL,
    [Sex] nchar(10)  NULL,
    [CategoryID] int  NOT NULL,
    [Build] nchar(10)  NULL,
    [Age] nchar(10)  NULL,
    [CityID] int  NOT NULL,
    [Hair] nchar(10)  NULL,
    [PostDate] datetime  NOT NULL
);
GO

-- Creating table 'Article'
CREATE TABLE [dbo].[Article] (
    [ArticleID] int IDENTITY(1,1) NOT NULL,
    [BoardID] int  NOT NULL,
    [PosterID] nvarchar(128)  NOT NULL,
    [Title] nvarchar(200)  NULL,
    [TitleCategoryID] int  NOT NULL,
    [ContentText] nvarchar(max)  NULL,
    [CreateDateTime] datetime  NULL,
    [LastChDateTime] datetime  NULL,
    [Number] int  NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL,
    [NickName] nvarchar(max)  NULL,
    [LastName] nvarchar(max)  NULL,
    [FirstName] nvarchar(max)  NULL,
    [LoginCount] int  NOT NULL,
    [Experience] int  NOT NULL,
    [DateRegistered] datetime  NOT NULL,
    [Photo] varbinary(max)  NULL
);
GO

-- Creating table 'Board'
CREATE TABLE [dbo].[Board] (
    [BoardID] int  NOT NULL,
    [BoardName] nvarchar(20)  NOT NULL,
    [MasterUserID] nvarchar(128)  NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [CategoryID] int IDENTITY(1,1) NOT NULL,
    [CategoryName] nvarchar(10)  NOT NULL
);
GO

-- Creating table 'Citys'
CREATE TABLE [dbo].[Citys] (
    [CityID] int IDENTITY(1,1) NOT NULL,
    [CityName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Comment'
CREATE TABLE [dbo].[Comment] (
    [ArticleID] int  NOT NULL,
    [CommentID] int IDENTITY(1,1) NOT NULL,
    [PosterID] nvarchar(128)  NOT NULL,
    [ContentText] nvarchar(max)  NULL,
    [NewDateTime] datetime  NULL
);
GO

-- Creating table 'Hospital'
CREATE TABLE [dbo].[Hospital] (
    [HospitalID] int IDENTITY(1,1) NOT NULL,
    [HospitalName] nvarchar(50)  NOT NULL,
    [HospitalAddress] nvarchar(50)  NOT NULL,
    [AddressArea] int  NOT NULL,
    [HospitalPhone] nvarchar(50)  NOT NULL,
    [CategoryID] int  NULL,
    [BusinessHours] nvarchar(50)  NULL,
    [Emergency] nvarchar(50)  NULL,
    [OutpatientProject] nvarchar(50)  NULL,
    [Equipment] nvarchar(50)  NULL,
    [WebAddress] nvarchar(50)  NULL,
    [OnlineConsultation] nvarchar(50)  NULL,
    [OnView] nvarchar(50)  NOT NULL,
    [Map] nvarchar(50)  NULL
);
GO

-- Creating table 'HospitalCategoryDetails'
CREATE TABLE [dbo].[HospitalCategoryDetails] (
    [CountID] int IDENTITY(1,1) NOT NULL,
    [HospitalID] int  NOT NULL,
    [CategoryID] int  NOT NULL
);
GO

-- Creating table 'TitleCategories'
CREATE TABLE [dbo].[TitleCategories] (
    [TitleCategoryID] int  NOT NULL,
    [TitleCategoryName] nvarchar(30)  NOT NULL
);
GO

-- Creating table 'UserPet'
CREATE TABLE [dbo].[UserPet] (
    [PetID] int IDENTITY(1,1) NOT NULL,
    [PetName] nvarchar(20)  NOT NULL,
    [UserID] nvarchar(128)  NOT NULL,
    [CategoryID] int  NOT NULL,
    [PetSex] bit  NULL,
    [PetPhoto] varbinary(max)  NULL,
    [PetBirthday] datetime  NULL
);
GO

-- Creating table 'Scorce'
CREATE TABLE [dbo].[Scorce] (
    [UserID] nvarchar(128)  NOT NULL,
    [HospitalID] int  NOT NULL,
    [Scorce1] int  NULL,
    [Date] nvarchar(50)  NULL,
    [NoteValue] nvarchar(50)  NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [AspNetRoles_Id] nvarchar(128)  NOT NULL,
    [AspNetUsers_Id] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [AdoptionID] in table 'Adoption'
ALTER TABLE [dbo].[Adoption]
ADD CONSTRAINT [PK_Adoption]
    PRIMARY KEY CLUSTERED ([AdoptionID] ASC);
GO

-- Creating primary key on [WishID] in table 'AdpWish'
ALTER TABLE [dbo].[AdpWish]
ADD CONSTRAINT [PK_AdpWish]
    PRIMARY KEY CLUSTERED ([WishID] ASC);
GO

-- Creating primary key on [ArticleID] in table 'Article'
ALTER TABLE [dbo].[Article]
ADD CONSTRAINT [PK_Article]
    PRIMARY KEY CLUSTERED ([ArticleID] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey], [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey], [UserId] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [BoardID] in table 'Board'
ALTER TABLE [dbo].[Board]
ADD CONSTRAINT [PK_Board]
    PRIMARY KEY CLUSTERED ([BoardID] ASC);
GO

-- Creating primary key on [CategoryID] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([CategoryID] ASC);
GO

-- Creating primary key on [CityID] in table 'Citys'
ALTER TABLE [dbo].[Citys]
ADD CONSTRAINT [PK_Citys]
    PRIMARY KEY CLUSTERED ([CityID] ASC);
GO

-- Creating primary key on [CommentID] in table 'Comment'
ALTER TABLE [dbo].[Comment]
ADD CONSTRAINT [PK_Comment]
    PRIMARY KEY CLUSTERED ([CommentID] ASC);
GO

-- Creating primary key on [HospitalID] in table 'Hospital'
ALTER TABLE [dbo].[Hospital]
ADD CONSTRAINT [PK_Hospital]
    PRIMARY KEY CLUSTERED ([HospitalID] ASC);
GO

-- Creating primary key on [CountID] in table 'HospitalCategoryDetails'
ALTER TABLE [dbo].[HospitalCategoryDetails]
ADD CONSTRAINT [PK_HospitalCategoryDetails]
    PRIMARY KEY CLUSTERED ([CountID] ASC);
GO

-- Creating primary key on [TitleCategoryID] in table 'TitleCategories'
ALTER TABLE [dbo].[TitleCategories]
ADD CONSTRAINT [PK_TitleCategories]
    PRIMARY KEY CLUSTERED ([TitleCategoryID] ASC);
GO

-- Creating primary key on [PetID] in table 'UserPet'
ALTER TABLE [dbo].[UserPet]
ADD CONSTRAINT [PK_UserPet]
    PRIMARY KEY CLUSTERED ([PetID] ASC);
GO

-- Creating primary key on [UserID], [HospitalID] in table 'Scorce'
ALTER TABLE [dbo].[Scorce]
ADD CONSTRAINT [PK_Scorce]
    PRIMARY KEY CLUSTERED ([UserID], [HospitalID] ASC);
GO

-- Creating primary key on [AspNetRoles_Id], [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([AspNetRoles_Id], [AspNetUsers_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RegistrationUserID] in table 'Adoption'
ALTER TABLE [dbo].[Adoption]
ADD CONSTRAINT [FK_Adoption_AspNetUsers]
    FOREIGN KEY ([RegistrationUserID])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Adoption_AspNetUsers'
CREATE INDEX [IX_FK_Adoption_AspNetUsers]
ON [dbo].[Adoption]
    ([RegistrationUserID]);
GO

-- Creating foreign key on [CategoryID] in table 'Adoption'
ALTER TABLE [dbo].[Adoption]
ADD CONSTRAINT [FK_Adoption_Categories]
    FOREIGN KEY ([CategoryID])
    REFERENCES [dbo].[Categories]
        ([CategoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Adoption_Categories'
CREATE INDEX [IX_FK_Adoption_Categories]
ON [dbo].[Adoption]
    ([CategoryID]);
GO

-- Creating foreign key on [CityID] in table 'Adoption'
ALTER TABLE [dbo].[Adoption]
ADD CONSTRAINT [FK_Adoption_Citys]
    FOREIGN KEY ([CityID])
    REFERENCES [dbo].[Citys]
        ([CityID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Adoption_Citys'
CREATE INDEX [IX_FK_Adoption_Citys]
ON [dbo].[Adoption]
    ([CityID]);
GO

-- Creating foreign key on [UserID] in table 'AdpWish'
ALTER TABLE [dbo].[AdpWish]
ADD CONSTRAINT [FK_AdpWish_AspNetUsers]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdpWish_AspNetUsers'
CREATE INDEX [IX_FK_AdpWish_AspNetUsers]
ON [dbo].[AdpWish]
    ([UserID]);
GO

-- Creating foreign key on [CategoryID] in table 'AdpWish'
ALTER TABLE [dbo].[AdpWish]
ADD CONSTRAINT [FK_AdpWish_Categories]
    FOREIGN KEY ([CategoryID])
    REFERENCES [dbo].[Categories]
        ([CategoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdpWish_Categories'
CREATE INDEX [IX_FK_AdpWish_Categories]
ON [dbo].[AdpWish]
    ([CategoryID]);
GO

-- Creating foreign key on [CityID] in table 'AdpWish'
ALTER TABLE [dbo].[AdpWish]
ADD CONSTRAINT [FK_AdpWish_Citys]
    FOREIGN KEY ([CityID])
    REFERENCES [dbo].[Citys]
        ([CityID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdpWish_Citys'
CREATE INDEX [IX_FK_AdpWish_Citys]
ON [dbo].[AdpWish]
    ([CityID]);
GO

-- Creating foreign key on [PosterID] in table 'Article'
ALTER TABLE [dbo].[Article]
ADD CONSTRAINT [FK_Article_AspNetUsers]
    FOREIGN KEY ([PosterID])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Article_AspNetUsers'
CREATE INDEX [IX_FK_Article_AspNetUsers]
ON [dbo].[Article]
    ([PosterID]);
GO

-- Creating foreign key on [BoardID] in table 'Article'
ALTER TABLE [dbo].[Article]
ADD CONSTRAINT [FK_Article_Board]
    FOREIGN KEY ([BoardID])
    REFERENCES [dbo].[Board]
        ([BoardID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Article_Board'
CREATE INDEX [IX_FK_Article_Board]
ON [dbo].[Article]
    ([BoardID]);
GO

-- Creating foreign key on [TitleCategoryID] in table 'Article'
ALTER TABLE [dbo].[Article]
ADD CONSTRAINT [FK_Article_TitleCategories]
    FOREIGN KEY ([TitleCategoryID])
    REFERENCES [dbo].[TitleCategories]
        ([TitleCategoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Article_TitleCategories'
CREATE INDEX [IX_FK_Article_TitleCategories]
ON [dbo].[Article]
    ([TitleCategoryID]);
GO

-- Creating foreign key on [ArticleID] in table 'Comment'
ALTER TABLE [dbo].[Comment]
ADD CONSTRAINT [FK_Comment_Article]
    FOREIGN KEY ([ArticleID])
    REFERENCES [dbo].[Article]
        ([ArticleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Comment_Article'
CREATE INDEX [IX_FK_Comment_Article]
ON [dbo].[Comment]
    ([ArticleID]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserClaims]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserLogins]
    ([UserId]);
GO

-- Creating foreign key on [MasterUserID] in table 'Board'
ALTER TABLE [dbo].[Board]
ADD CONSTRAINT [FK_Board_AspNetUsers]
    FOREIGN KEY ([MasterUserID])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Board_AspNetUsers'
CREATE INDEX [IX_FK_Board_AspNetUsers]
ON [dbo].[Board]
    ([MasterUserID]);
GO

-- Creating foreign key on [PosterID] in table 'Comment'
ALTER TABLE [dbo].[Comment]
ADD CONSTRAINT [FK_Comment_AspNetUsers]
    FOREIGN KEY ([PosterID])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Comment_AspNetUsers'
CREATE INDEX [IX_FK_Comment_AspNetUsers]
ON [dbo].[Comment]
    ([PosterID]);
GO

-- Creating foreign key on [UserID] in table 'Scorce'
ALTER TABLE [dbo].[Scorce]
ADD CONSTRAINT [FK_Scorce_AspNetUsers]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserID] in table 'UserPet'
ALTER TABLE [dbo].[UserPet]
ADD CONSTRAINT [FK_UserPet_AspNetUsers]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserPet_AspNetUsers'
CREATE INDEX [IX_FK_UserPet_AspNetUsers]
ON [dbo].[UserPet]
    ([UserID]);
GO

-- Creating foreign key on [CategoryID] in table 'HospitalCategoryDetails'
ALTER TABLE [dbo].[HospitalCategoryDetails]
ADD CONSTRAINT [FK_HospitalCategoryDetails_Categories]
    FOREIGN KEY ([CategoryID])
    REFERENCES [dbo].[Categories]
        ([CategoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HospitalCategoryDetails_Categories'
CREATE INDEX [IX_FK_HospitalCategoryDetails_Categories]
ON [dbo].[HospitalCategoryDetails]
    ([CategoryID]);
GO

-- Creating foreign key on [CategoryID] in table 'UserPet'
ALTER TABLE [dbo].[UserPet]
ADD CONSTRAINT [FK_UserPet_Categories]
    FOREIGN KEY ([CategoryID])
    REFERENCES [dbo].[Categories]
        ([CategoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserPet_Categories'
CREATE INDEX [IX_FK_UserPet_Categories]
ON [dbo].[UserPet]
    ([CategoryID]);
GO

-- Creating foreign key on [AddressArea] in table 'Hospital'
ALTER TABLE [dbo].[Hospital]
ADD CONSTRAINT [FK_Hospital_Citys]
    FOREIGN KEY ([AddressArea])
    REFERENCES [dbo].[Citys]
        ([CityID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Hospital_Citys'
CREATE INDEX [IX_FK_Hospital_Citys]
ON [dbo].[Hospital]
    ([AddressArea]);
GO

-- Creating foreign key on [HospitalID] in table 'HospitalCategoryDetails'
ALTER TABLE [dbo].[HospitalCategoryDetails]
ADD CONSTRAINT [FK_HospitalCategoryDetails_Hospital]
    FOREIGN KEY ([HospitalID])
    REFERENCES [dbo].[Hospital]
        ([HospitalID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HospitalCategoryDetails_Hospital'
CREATE INDEX [IX_FK_HospitalCategoryDetails_Hospital]
ON [dbo].[HospitalCategoryDetails]
    ([HospitalID]);
GO

-- Creating foreign key on [HospitalID] in table 'Scorce'
ALTER TABLE [dbo].[Scorce]
ADD CONSTRAINT [FK_Scorce_Hospital]
    FOREIGN KEY ([HospitalID])
    REFERENCES [dbo].[Hospital]
        ([HospitalID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Scorce_Hospital'
CREATE INDEX [IX_FK_Scorce_Hospital]
ON [dbo].[Scorce]
    ([HospitalID]);
GO

-- Creating foreign key on [AspNetRoles_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles]
    FOREIGN KEY ([AspNetRoles_Id])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUsers'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUsers]
ON [dbo].[AspNetUserRoles]
    ([AspNetUsers_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------