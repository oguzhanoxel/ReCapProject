CREATE DATABASE ReCapProjectDB;

CREATE TABLE Colors (
    ID int IDENTITY (1, 1) NOT NULL,
    Name varchar(255),
    PRIMARY KEY (ID),
);

CREATE TABLE Brands (
    ID int IDENTITY (1, 1) NOT NULL,
    Name varchar(255),
    PRIMARY KEY (ID),
);

CREATE TABLE Cars (
    ID int IDENTITY (1, 1) NOT NULL,
    BrandID int,
    ColorID int,
	Name nvarchar(255),
    ModelYear smallint,
    DailyPrice DECIMAL(10,2),
    Description nvarchar(max),
    PRIMARY KEY (ID),
    FOREIGN KEY (BrandID) REFERENCES Brands(ID),
    FOREIGN KEY (ColorID) REFERENCES Colors(ID),
);

CREATE TABLE Users (
    ID int IDENTITY (1, 1) NOT NULL,
    FirstName varchar(255),
    LastName varchar(255),
    Email  varchar(255) NOT NULL UNIQUE,
    Password varchar(255) NOT NULL,
    PRIMARY KEY (ID),
);

CREATE TABLE Customers (
    ID int IDENTITY (1, 1) NOT NULL,
    UserID int,
    CompanyName varchar(255),
    PRIMARY KEY (ID),
    FOREIGN KEY (UserID) REFERENCES Users(ID),
);

CREATE TABLE Rentals (
    ID int IDENTITY (1, 1) NOT NULL,
    CarID int,
    CustomerID int,
    RentDate DateTime,
    ReturnDate DateTime,
    PRIMARY KEY (ID),
    FOREIGN KEY (CarID) REFERENCES Cars(ID),
    FOREIGN KEY (CustomerID) REFERENCES Customers(ID),
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
