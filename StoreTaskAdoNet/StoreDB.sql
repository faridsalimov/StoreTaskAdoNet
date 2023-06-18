CREATE DATABASE StoreDB
GO
USE StoreDB
GO

CREATE TABLE Products(
[ID] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(30) NOT NULL,
[Description] NVARCHAR(30),
[Price] MONEY NOT NULL DEFAULT(0),
[Discount] FLOAT NOT NULL DEFAULT(0),
[Quantity] INT NOT NULL DEFAULT(10)
)

GO

CREATE TABLE Customers(
[ID] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Username] NVARCHAR(30) NOT NULL
)

GO

CREATE TABLE Orders(
[ID] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Date] datetime2 NOT NULL DEFAULT(GETDATE()),
[Amount] INT NOT NULL DEFAULT(1),
[ProductID] INT FOREIGN KEY REFERENCES Products([ID]) NOT NULL,
[CustomerID] INT FOREIGN KEY REFERENCES Customers([ID]) NOT NULL,
)

GO

CREATE TABLE Admins(
[ID] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Username] NVARCHAR(30) NOT NULL,
[Password] NVARCHAR(30) NOT NULL
)

GO

INSERT INTO Products([Name],[Description],[Price],[Discount],[Quantity])
VALUES('IPhone 11 Pro', 'a phone.', 2129, 15, 250),('Geforce Rtx 4070 Ti', 'a video card.', 1999, 10, 100)

GO

INSERT INTO Customers([Username])
VALUES('faridsalimov'),('emirhan')

GO

INSERT INTO Orders([Date],[Amount],[CustomerID],[ProductID])
VALUES(GETDATE(), 1, 1, 1), (GETDATE(), 2, 2, 2)

GO

INSERT INTO Admins([Username],[Password])
VALUES('admin', 'admin')