CREATE TABLE [dbo].[Users] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [FirstName]    VARCHAR (50)    NOT NULL,
    [LastName]     VARCHAR (50)    NOT NULL,
    [Email]        VARCHAR (50)    NOT NULL,
    [PasswordHash] VARBINARY (500) NOT NULL,
    [PasswordSalt] VARBINARY (500) NOT NULL,
    [Status]       BIT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[UserOperationClaims] (
    [Id]               INT IDENTITY (1, 1) NOT NULL,
    [UserId]           INT NOT NULL,
    [OperationClaimId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[OperationClaims] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (250) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Rentals] (
    [ID]         INT      IDENTITY (1, 1) NOT NULL,
    [CarID]      INT      NOT NULL,
    [UserID]     INT      NOT NULL,
    [RentDate]   DATETIME NOT NULL,
    [ReturnDate] DATETIME NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([CarID]) REFERENCES [dbo].[Cars] ([ID]),
    FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([Id])
);

CREATE TABLE [dbo].[Customers] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [UserID]      INT           NOT NULL,
    [CompanyName] VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Colors] (
    [ID]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (255) NOT NULL
);

CREATE TABLE [dbo].[Cars] (
    [ID]          INT             IDENTITY (1, 1) NOT NULL,
    [BrandID]     INT             NOT NULL,
    [ColorID]     INT             NOT NULL,
    [Name]        NVARCHAR (255)  NOT NULL,
    [ModelYear]   SMALLINT        NOT NULL,
    [DailyPrice]  DECIMAL (10, 2) NOT NULL,
    [Description] NVARCHAR (MAX)  NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([BrandID]) REFERENCES [dbo].[Brands] ([ID])
);

CREATE TABLE [dbo].[CarImages] (
    [ID]        INT            IDENTITY (1, 1) NOT NULL,
    [CarID]     INT            NOT NULL,
    [ImagePath] NVARCHAR (MAX) NOT NULL,
    [Date]      DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([CarID]) REFERENCES [dbo].[Cars] ([ID])
);

CREATE TABLE [dbo].[Brands] (
    [ID]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);
