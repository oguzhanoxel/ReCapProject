CREATE DATABASE ReCapProjectDB;

CREATE TABLE Colors (
    ColorID int NOT NULL,
    ColorName varchar(255),
    PRIMARY KEY (ColorID),
);

CREATE TABLE Brands (
    BrandID int NOT NULL,
    BrandName varchar(255),
    PRIMARY KEY (BrandID),
);

CREATE TABLE Cars (
    ID int NOT NULL,
    BrandID int,
    ColorID int,
	Name nvarchar(255),
    ModelYear smallint,
    DailyPrice DECIMAL(10,2),
    Description nvarchar(max),
    PRIMARY KEY (ID),
    FOREIGN KEY (BrandID) REFERENCES Brands(BrandID),
    FOREIGN KEY (ColorID) REFERENCES Colors(ColorID),
);

INSERT INTO Colors(ColorID, ColorName)
VALUES (1, 'Black');
INSERT INTO Colors(ColorID, ColorName)
VALUES (2, 'White');
INSERT INTO Colors(ColorID, ColorName)
VALUES (3, 'Red');

INSERT INTO Brands(BrandID, BrandName)
VALUES (1, 'A brand');
INSERT INTO Brands(BrandID, BrandName)
VALUES (2, 'B brand');

INSERT INTO Cars(ID, BrandID, ColorID, ModelYear, DailyPrice, Description)
VALUES (1, 1, 1, 2011, 799.99, 'Description');
INSERT INTO Cars(ID, BrandID, ColorID, ModelYear, DailyPrice, Description)
VALUES (2, 1, 2, 2012, 679.99, 'Description2');
INSERT INTO Cars(ID, BrandID, ColorID, ModelYear, DailyPrice, Description)
VALUES (3, 2, 2, 2016, 569.99, 'Description3');
INSERT INTO Cars(ID, BrandID, ColorID, ModelYear, DailyPrice, Description)
VALUES (4, 2, 3, 2013, 399.99, 'Description4');
INSERT INTO Cars(ID, BrandID, ColorID, ModelYear, DailyPrice, Description)
VALUES (5, 2, 1, 2014, 999.99, 'Description5');