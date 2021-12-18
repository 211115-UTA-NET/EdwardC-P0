SELECT * FROM Customers;

SELECT * FROM "Login";

SELECT * FROM StoreLocations;

SELECT * FROM StoreItems;

SELECT * FROM ItemDetails;

-- Display StoreHistoryList
SELECT InvoiceHistory.InvoiceId, InvoiceDate, InvoiceList.ItemName, InvoiceList.ItemQuanity, InvoiceList.TotalPrice
FROM InvoiceHistory
FULL OUTER JOIN InvoiceList ON InvoiceList.InvoiceId = InvoiceHistory.InvoiceId;
