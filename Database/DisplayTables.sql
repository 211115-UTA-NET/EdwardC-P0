SELECT * FROM Customers;

SELECT * FROM "Login";

SELECT * FROM StoreLocations;

SELECT * FROM StoreItems;

SELECT * FROM ItemDetails;

-- Display StoreHistoryList
SELECT InvoiceHistory.InvoiceId, InvoiceDate, InvoiceList.ItemName, InvoiceList.ItemQuanity, InvoiceList.TotalPrice
FROM InvoiceHistory
FULL OUTER JOIN InvoiceList ON InvoiceList.InvoiceId = InvoiceHistory.InvoiceId;


-- Display Customer Order History
SELECT InvoiceHistory.InvoiceId, InvoiceDate, InvoiceList.ItemName, InvoiceList.ItemQuanity, InvoiceList.TotalPrice, StoreLocations.StoreLocation
FROM InvoiceHistory
INNER JOIN InvoiceList On InvoiceList.InvoiceId = InvoiceHistory.InvoiceId
INNER JOIN Invoices ON Invoices.InvoiceId = InvoiceList.InvoiceId
INNER JOIN StoreLocations On StoreLocations.StoreId = Invoices.StoreId
INNER JOIN Customers ON Customers.CustomerId = Invoices.CustomerId;

-- Display details of an Order
SELECT * FROM ItemDetails;

-- Display StoreItems 
SELECT StoreItems.ItemName, StoreItems.ItemQuantity, StoreLocations.StoreLocation
FROM StoreItems
INNER JOIN StoreLocations ON StoreLocations.StoreId = StoreItems.StoreId
WHERE StoreLocations.StoreId = 2;

-- Display Process Order
SELECT ItemName, Price 
FROM ItemDetails

-- CheckQuantityItem
SELECT ItemName, ItemQuantity
FROM StoreItems
WHERE StoreId = 1 AND ItemName = 'Shimano Altus FC-M311 Crankset'

--Display ItemName
SELECT ItemName
FROM ItemDetails

-- Display Invoice for Customer and store History
SELECT Invoices.InvoiceId, InvoiceHistory.InvoiceDate, 
	InvoiceList.ItemName, InvoiceList.ItemQuanity, 
	InvoiceList.TotalPrice, StoreLocations.StoreLocation
FROM Invoices
INNER JOIN InvoiceHistory ON InvoiceHistory.InvoiceId = Invoices.InvoiceId
INNER JOIN InvoiceList ON InvoiceList.InvoiceId = Invoices.InvoiceId
INNER JOIN StoreLocations On StoreLocations.StoreId = Invoices.StoreId
WHERE Invoices.CustomerId = 1;

-- Display Store Items for Manager to check Inventory
SELECT ItemId, ItemName, ItemQuantity, StoreLocation
FROM StoreItems
INNER JOIN StoreLocations ON StoreLocations.StoreId = StoreItems.StoreId;

-- Test for add Invoices, InvoiceHistory, and InvoicesList
SELECT * FROM Invoices;
SELECT * FROM InvoiceHistory;
SELECT * FROM InvoiceList;

SELECT TOP 1 InvoiceId
FROM Invoices
ORDER BY InvoiceId DESC;
