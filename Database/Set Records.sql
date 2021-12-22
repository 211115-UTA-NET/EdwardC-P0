-- Rename TABLE: StoreLocation to StoreLocations
--EXEC sp_rename StoreLocation, StoreLocations;

-- Noted: double quote uses for Table/column<Name> while
-- Single quote uses for string
INSERT INTO StoreLocations 
    (StoreLocation)
VALUES
    ('340 Hilltop Street Ashburn, VA 20147'),
    ('913 Birchpond Street Billerica, MA 01821'),
    ('753 Acacia St.Glen Ellyn, IL 60137')

--SELECT * FROM StoreLocations;
-- EXEC sp_rename ItemDetail, ItemDetails;
-- ALTER TABLE ItemDetails
-- ALTER COLUMN Price MONEY;

INSERT ItemDetails 
    (ItemName, ItemDetail, Price)
VALUES
    ('Shimano Altus FC-M311 Crankset',
     '170mm, 7/8-Speed, 42/32/22t, Riveted, Square Taper JIS Spindle Interface, Black, with Chainguard',
     54.99),
     ('Lizard Skins DSP Bar Tape V2 4.6mm',
     'A new pattern, an upgraded polymer and a screw-in bar plug. The new pattern is more technical with a new design and multiple layers of depth. The Polymer has new formula enchanced for more durability and comfort. The new plug provides a clean, tight finish',
     51.99),
     ('Odyssey Bluebird Single Speed',
     'The proven and reliable KMC 510-HX chain with an added a permantly attached, factory installed half-link to one end the chain is trimmed to size you can easily decide whether or not to use the half-link. Original factory assembled pin joints are radically stronger than workshop assembled ones, so this is a huge benegit.',
     15.99)

INSERT StoreItems
    (ItemName, StoreId, ItemQuantity)
VALUES
    ('Shimano Altus FC-M311 Crankset', 1, 17),
    ('Shimano Altus FC-M311 Crankset', 2, 9),
    ('Shimano Altus FC-M311 Crankset', 3, 5),
	('Odyssey Bluebird Single Speed', 1, 10),
	('Odyssey Bluebird Single Speed', 2, 11),
	('Lizard Skins DSP Bar Tape V2 4.6mm', 1, 15),
	('Lizard Skins DSP Bar Tape V2 4.6mm', 3, 8)

-- UPDATE StoreItems
-- SET ItemId = 1
-- WHERE ItemId = 4;

INSERT Customers
    (FirstName, LastName, PhoneNumber, "Address")
VALUES
    ('Eddie', 'Cicio', 1113335555, '5 Jones Dr. Miami, FL 33125 '),
    ('Jackie', 'Chan', 2224446666, '26 Pennington Ave. Hickory, VA 20148')

INSERT "Login"
    (Username, "Password", IsManager)
VALUES
    ('Eddie', 'test', 0),
    ('Jackie', 'test2', 1)

-- Delete Record Test

-- DELETE FROM "Login"
-- WHERE CustomerId = 9;
-- DELETE FROM Customers
-- WHERE FirstName = 'Mich';


--Add Invoices, InvoiceHistory, InvoiceList

INSERT Invoices 
	(CustomerId, StoreId)
VALUES 
	(1, 2),
	(1, 1),
	(1, 3),
	(1, 2),
	(1, 2);

INSERT InvoiceHistory 
	(InvoiceId, InvoiceDate)
VALUES 
	(1, '2000-04-25'),
	(2, '1994-09-01'),
	(3, '2003-08-17'),
	(4, '2004-01-20'),
	(5, '2017-03-14')

INSERT InvoiceList 
	(InvoiceId, ItemName, ItemQuantity, TotalPrice)
VALUES 
	(1, 'Shimano Altus FC-M311 Crankset', 3, 164.97),
	(2, 'Odyssey Bluebird Single Speed', 2, 31.98),
	(3, 'Lizard Skins DSP Bar Tape V2 4.6mm', 4, 207.96),
	(4, 'Odyssey Bluebird Single Speed', 4, 63.96),
	(5, 'Lizard Skins DSP Bar Tape V2 4.6mm', 2, 103.98);

-- Modify the store's inventory decrease
UPDATE StoreItems
SET ItemQuantity = (ItemQuantity + 1)
WHERE ItemName = 'Shimano Altus FC-M311 Crankset' AND StoreId = 2;