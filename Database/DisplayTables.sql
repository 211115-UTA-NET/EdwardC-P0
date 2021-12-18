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