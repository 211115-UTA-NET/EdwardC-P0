-- Create database
CREATE DATABASE BikeShop;

-- Create tables
-- TABLE 1
CREATE TABLE "Login"
(
	CustomerId INT,
	Username VARCHAR(100) PRIMARY KEY,
	"Password" VARCHAR(100) NOT NULL,
	IsManager BIT NOT NULL
);

-- TABLE 2
CREATE TABLE Customer
(
	CustomerId INT PRIMARY KEY,
	FirstName VARCHAR(100) NOT NULL,
	LastName VARCHAR(100) NOT NULL,
	PhoneNumber VARCHAR(10) NOT NULL,
	"Address" VARCHAR(100) NOT NULL
);

-- TABLE 3
CREATE TABLE Store
(
	StoreId INT PRIMARY KEY,
	StoreLocation VARCHAR(100) NOT NULL
);

-- TABLE 4
CREATE TABLE StoreItems
(
	ItemId INT PRIMARY KEY,
	ItemName VARCHAR(100) NOT NULL,
	StoreId INT NOT NULL,
	ItemQuantity INT NOT NULL
);

-- TABLE 5
CREATE TABLE ItemDetail
(
	ItemName VARCHAR(100) PRIMARY KEY,
	ItemDetail VARCHAR(250) NOT NULL,
	Price INT NOT NULL
);

-- TABLE 6
CREATE TABLE Invoices
(
	InvocieId INT PRIMARY KEY,
	CustomerId INT NOT NULL,
	StoreId INT NOT NULL
);

-- TABLE 7
CREATE TABLE InvoiceHistory
(
	InvoiceId INT NOT NULL,
	InvoiceDate DATE NOT NULL
);

-- TABLE 8
CREATE TABLE InvoiceList
(
	InvoiceId INT NOT NULL,
	ItemName VARCHAR(100) NOT NULL,
	ItemQuanity INT NOT NULL,
	TotalPrice INT NOT NULL
);