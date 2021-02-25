CREATE DATABASE ReCapProjectDB;

CREATE TABLE [dbo].[Brands] (
    [ID]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Colors] (
    [ID]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
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
    FOREIGN KEY ([BrandID]) REFERENCES [dbo].[Brands] ([ID]),
    FOREIGN KEY ([ColorID]) REFERENCES [dbo].[Colors] ([ID])
);

CREATE TABLE [dbo].[Users] (
    [ID]        INT           IDENTITY (1, 1) NOT NULL,
    [FirstName] VARCHAR (255) NULL,
    [LastName]  VARCHAR (255) NULL,
    [Email]     VARCHAR (255) NOT NULL,
    [Password]  VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    UNIQUE NONCLUSTERED ([Email] ASC)
);

CREATE TABLE [dbo].[Customers] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [UserID]      INT           NOT NULL,
    [CompanyName] VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([ID])
);

CREATE TABLE [dbo].[Rentals] (
    [ID]         INT      IDENTITY (1, 1) NOT NULL,
    [CarID]      INT      NOT NULL,
    [CustomerID] INT      NOT NULL,
    [RentDate]   DATETIME NOT NULL,
    [ReturnDate] DATETIME NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([CarID]) REFERENCES [dbo].[Cars] ([ID]),
    FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customers] ([ID])
);

CREATE TABLE [dbo].[CarImages] (
    [ID]        INT            IDENTITY (1, 1) NOT NULL,
    [CarID]     INT            NOT NULL,
    [ImagePath] NVARCHAR (MAX) NOT NULL,
    [Date]      DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([CarID]) REFERENCES [dbo].[Cars] ([ID])
);



INSERT INTO Colors(Name)VALUES ('Black');
INSERT INTO Colors(Name)VALUES ('White');
INSERT INTO Colors(Name)VALUES ('Red');

INSERT INTO Brands(Name)VALUES ('A brand');
INSERT INTO Brands(Name)VALUES ('B brand');

INSERT INTO Cars(BrandID, ColorID, Name, ModelYear, DailyPrice, Description)VALUES (1, 1, 'Tristique', 2011, 799.99, 'Description');
INSERT INTO Cars(BrandID, ColorID, Name, ModelYear, DailyPrice, Description)VALUES (1, 2, 'Tellus', 2012, 679.99, 'Description2');
INSERT INTO Cars(BrandID, ColorID, Name, ModelYear, DailyPrice, Description)VALUES (2, 2, 'Libero', 2016, 569.99, 'Description3');
INSERT INTO Cars(BrandID, ColorID, Name, ModelYear, DailyPrice, Description)VALUES (2, 3, 'Quisque', 2013, 399.99, 'Description4');
INSERT INTO Cars(BrandID, ColorID, Name, ModelYear, DailyPrice, Description)VALUES (2, 1, 'Mauris', 2014, 999.99, 'Description5');

INSERT INTO Users(FirstName, LastName, Email, Password)VALUES ('', '', 'oguzhan@example.com', '123456789Qq');
INSERT INTO Users(FirstName, LastName, Email, Password)VALUES ('Ahmet', 'A.', 'ahmet@example.com', '123456789Qq');
INSERT INTO Users(FirstName, LastName, Email, Password)VALUES ('', 'T.', 'mehmet@example.com', '123456789Qq');
INSERT INTO Users(FirstName, LastName, Email, Password)VALUES ('Ayşe', 'A.', 'ayşe@example.com', '123456789Qq');
INSERT INTO Users(FirstName, LastName, Email, Password)VALUES ('Aylin', 'L.', 'aylin@example.com', '123456789Qq');

INSERT INTO Customers (UserID, CompanyName)VALUES (2, 'A company');
INSERT INTO Customers (UserID, CompanyName)VALUES (2, 'A company');
INSERT INTO Customers (UserID, CompanyName)VALUES (5, 'C company');
INSERT INTO Customers (UserID, CompanyName)VALUES (4, 'B company');
INSERT INTO Customers (UserID, CompanyName)VALUES (4, 'B company');

INSERT INTO Rentals(CarID, CustomerID, RentDate, ReturnDate)VALUES (3, 2, '20200922 10:00:09 PM', '20200928 12:30:09 AM');
INSERT INTO Rentals(CarID, CustomerID, RentDate, ReturnDate)VALUES (3, 3, '20210612 10:00:09 PM', '20210620 12:30:09 AM');
INSERT INTO Rentals(CarID, CustomerID, RentDate, ReturnDate)VALUES (1, 1, '20210313 12:00:09 PM', '20210321 10:30:09 PM');
INSERT INTO Rentals(CarID, CustomerID, RentDate)VALUES (5, 4, '20200223 06:00:09 PM');
INSERT INTO Rentals(CarID, CustomerID, RentDate, ReturnDate)VALUES (3, 2, '20200122 07:00:09 PM', '20200125 06:30:09 AM');
INSERT INTO Rentals(CarID, CustomerID, RentDate)VALUES (4, 4, '20210624 03:00:09 PM');
INSERT INTO Rentals(CarID, CustomerID, RentDate, ReturnDate)VALUES (4, 1, '20210707 06:00:09 PM', '20210716 01:30:09 AM');
INSERT INTO Rentals(CarID, CustomerID, RentDate, ReturnDate)VALUES (2, 3, '20201103 10:00:09 PM', '20201110 06:30:09 AM');
