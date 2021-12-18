-- Create database
-- CREATE DATABASE BikeShop;
-- DROP DATABASE BikeShop;

-- Create tables
-- TABLE 1
-- DROP TABLE StoreLocations;
CREATE TABLE StoreLocations
(
	StoreId INT IDENTITY(1,1) PRIMARY KEY,
	StoreLocation VARCHAR(100) NOT NULL
);

-- TABLE 2
-- DROP TABLE ItemDetails
CREATE TABLE ItemDetails
(
	ItemName VARCHAR(100) PRIMARY KEY,
	ItemDetail VARCHAR(500) NOT NULL,
	Price MONEY NOT NULL
);

-- TABLE 3
-- DROP TABLE Customers;
CREATE TABLE Customers
(
	CustomerId INT IDENTITY(1,1) PRIMARY KEY,
	FirstName VARCHAR(100) NOT NULL,
	LastName VARCHAR(100) NOT NULL,
	PhoneNumber VARCHAR(10) NOT NULL,
	"Address" VARCHAR(100) NOT NULL
);

-- TABLE 4
-- Drop TABLE StoreItems;
CREATE TABLE StoreItems
(
	ItemId INT IDENTITY(1,1) PRIMARY KEY,
	ItemName VARCHAR(100) NOT NULL,
	StoreId INT NOT NULL,
	ItemQuantity INT NOT NULL,
	CONSTRAINT FK_StoreItems_ItemName_ItemDetails FOREIGN KEY (ItemName) 
	REFERENCES ItemDetails(ItemName),
	CONSTRAINT FK_StoreItems_StoreId_StoreLocations FOREIGN KEY (StoreId)
	REFERENCES StoreLocations(StoreId)
);

-- TABLE 5
-- DROP TABLE "Login";
CREATE TABLE "Login"
(
	CustomerId INT IDENTITY(1,1) NOT NULL,
	Username VARCHAR(100) PRIMARY KEY,
	"Password" VARCHAR(100) NOT NULL,
	IsManager BIT NOT NULL,
	CONSTRAINT "FK_Login_CustomerId_Customers" FOREIGN KEY (CustomerId)
	REFERENCES Customers(CustomerId)
);

-- TABLE 6
--DROP TABLE Invoices;
CREATE TABLE Invoices
(
	InvoiceId INT IDENTITY(1,1) PRIMARY KEY,
	CustomerId INT NOT NULL,
	StoreId INT NOT NULL,
	CONSTRAINT FK_Invoices_CustomerId_Customers FOREIGN KEY (CustomerId)
	REFERENCES Customers(CustomerId),
	CONSTRAINT FK_Invoices_StoreId_StoreLocations FOREIGN KEY (StoreId)
	REFERENCES StoreLocations(StoreId)
);

-- TABLE 7
-- DROP TABLE InvoiceHistory;
CREATE TABLE InvoiceHistory
(
	InvoiceId INT NOT NULL,
	InvoiceDate DATE NOT NULL,
	CONSTRAINT FK_InvoiceHistory_InvoiceId_Invoices FOREIGN KEY (InvoiceId) 
	REFERENCES Invoices(InvoiceId)
);

-- TABLE 8
-- DROP TABLE InvoiceList;
CREATE TABLE InvoiceList
(
	InvoiceId INT NOT NULL,
	ItemName VARCHAR(100) NOT NULL,
	ItemQuanity INT NOT NULL,
	TotalPrice INT NOT NULL,
	CONSTRAINT FK_InvoiceList_ItemName_ItemDetails FOREIGN KEY (ItemName) 
	REFERENCES ItemDetails(ItemName),
	CONSTRAINT FK_InvoiceList_InvoiceId_Invoices FOREIGN KEY (InvoiceId) 
	REFERENCES Invoices(InvoiceId)
);