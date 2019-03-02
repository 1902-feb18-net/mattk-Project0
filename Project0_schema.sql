--CREATE DATABASE Project0;

--GO
--CREATE SCHEMA Project0;
--GO

CREATE TABLE Project0.Cupcake (
	CupcakeId INT NOT NULL PRIMARY KEY IDENTITY,
	Type NVARCHAR(100) NOT NULL,
	Cost DECIMAL(8,2) NOT NULL DEFAULT(6.00)
);

CREATE TABLE Project0.Ingredient (
	IngredientId INT NOT NULL PRIMARY KEY IDENTITY,
	Type NVARCHAR(100) NOT NULL
);

CREATE TABLE Project0.RecipeItem (
	RecipeItemId INT NOT NULL PRIMARY KEY IDENTITY,
	CupcakeID INT NOT NULL,
	IngredientID INT NOT NULL,
	Amount DECIMAL(10,6) NOT NULL,
	Units NVARCHAR(50) NOT NULL,
	CONSTRAINT CupcakeIngredient UNIQUE (CupcakeID, IngredientID),
	CONSTRAINT FK_Recipe_Cupcake FOREIGN KEY (CupcakeID) REFERENCES Project0.Cupcake (CupcakeId),
	CONSTRAINT FK_Recipe_Ingredient FOREIGN KEY (IngredientID) REFERENCES Project0.Ingredient (IngredientId)
);

INSERT INTO Project0.Cupcake (Type, Cost) VALUES
	('Vanilla', 3.5),
	('Chocolate', 5.25),
	('ChocPeanutButter', 6.25),
	('RaspAmaretto', 6),
	('ChocPeppermint', 6.5),
	('MintOreo', 6),
	('Coconut', 4),
	('Lemon', 4.7);
	
INSERT INTO Project0.Ingredient (Type) VALUES
	('Flour'),
	('BakingPowder'),
	('Salt'),
	('UnsaltedButter'),
	('GranulatedSugar'),
	('LargeEgg'),
	('VanillaExtract'),
	('SourCream'),
	('ConfectionerSugar'),
	('HeavyCream'),
	('CocoaPowder'),
	('Raspberry'),
	('PeanutButter'),
	('Peppermint'),
	('Oreo'),
	('CoconutMilk'),
	('Lemon'),
	('Amaretto');
	
SELECT *
FROM Project0.Cupcake;

SELECT *
FROM Project0.Ingredient;

INSERT INTO Project0.RecipeItem 
(CupcakeID, IngredientID, Amount, Units) VALUES
	(1, 1, 0.028, 'lbs'),
	(1, 2, 0.00094, 'lbs'),
	(1, 3, 0.00045, 'lbs'),
	(1, 4, 0.054, 'lbs'),
	(1, 5, 0.031, 'lbs'),

	(1, 6, 0.14, 'each'),
	(1, 7, 0.0004, 'gallons'),
	(1, 8, 0.019, 'lbs'),
	(1, 9, 0.057, 'lbs'),
	(1, 10, 0.0045, 'gallons'),

	(1, 11, 0, 'lbs'),
	(1, 12, 0, 'each'),
	(1, 13, 0, 'lbs'),
	(1, 14, 0, 'each'),
	(1, 15, 0, 'lbs'),

	(1, 16, 0, 'gallons'),
	(1, 17, 0, 'each'),
	(1, 18, 0, 'lbs'),
	
	
	(2, 1, 0.028, 'lbs'),
	(2, 2, 0.00094, 'lbs'),
	(2, 3, 0.00045, 'lbs'),
	(2, 4, 0.054, 'lbs'),
	(2, 5, 0.031, 'lbs'),

	(2, 6, 0.14, 'each'),
	(2, 7, 0.0004, 'gallons'),
	(2, 8, 0.019, 'lbs'),
	(2, 9, 0.057, 'lbs'),
	(2, 10, 0.0045, 'gallons'),

	(2, 11, 0.024, 'lbs'),
	(2, 12, 0, 'each'),
	(2, 13, 0, 'lbs'),
	(2, 14, 0, 'each'),
	(2, 15, 0, 'lbs'),

	(2, 16, 0, 'gallons'),
	(2, 17, 0, 'each'),
	(2, 18, 0, 'lbs'),
	

	(3, 1, 0.028, 'lbs'),
	(3, 2, 0.00094, 'lbs'),
	(3, 3, 0.00045, 'lbs'),
	(3, 4, 0.054, 'lbs'),
	(3, 5, 0.031, 'lbs'),

	(3, 6, 0.14, 'each'),
	(3, 7, 0.0004, 'gallons'),
	(3, 8, 0.019, 'lbs'),
	(3, 9, 0.057, 'lbs'),
	(3, 10, 0.0045, 'gallons'),

	(3, 11, 0.024, 'lbs'),
	(3, 12, 0, 'each'),
	(3, 13, 0.011, 'lbs'),
	(3, 14, 0, 'each'),
	(3, 15, 0, 'lbs'),

	(3, 16, 0, 'gallons'),
	(3, 17, 0, 'each'),
	(3, 18, 0, 'lbs'),


	(4, 1, 0.028, 'lbs'),
	(4, 2, 0.00094, 'lbs'),
	(4, 3, 0.00045, 'lbs'),
	(4, 4, 0.054, 'lbs'),
	(4, 5, 0.031, 'lbs'),

	(4, 6, 0.14, 'each'),
	(4, 7, 0.0004, 'gallons'),
	(4, 8, 0.019, 'lbs'),
	(4, 9, 0.057, 'lbs'),
	(4, 10, 0.0045, 'gallons'),

	(4, 11, 0, 'lbs'),
	(4, 12, 7, 'each'),
	(4, 13, 0, 'lbs'),
	(4, 14, 0, 'each'),
	(4, 15, 0, 'lbs'),

	(4, 16, 0, 'gallons'),
	(4, 17, 0, 'each'),
	(4, 18, 0.014, 'lbs'),


	(5, 1, 0.028, 'lbs'),
	(5, 2, 0.00094, 'lbs'),
	(5, 3, 0.00045, 'lbs'),
	(5, 4, 0.054, 'lbs'),
	(5, 5, 0.031, 'lbs'),

	(5, 6, 0.14, 'each'),
	(5, 7, 0.0004, 'gallons'),
	(5, 8, 0.019, 'lbs'),
	(5, 9, 0.057, 'lbs'),
	(5, 10, 0.0045, 'gallons'),

	(5, 11, 0.024, 'lbs'),
	(5, 12, 0, 'each'),
	(5, 13, 0, 'lbs'),
	(5, 14, 1, 'each'),
	(5, 15, 0, 'lbs'),

	(5, 16, 0, 'gallons'),
	(5, 17, 0, 'each'),
	(5, 18, 0, 'lbs'),


	(6, 1, 0.028, 'lbs'),
	(6, 2, 0.00094, 'lbs'),
	(6, 3, 0.00045, 'lbs'),
	(6, 4, 0.054, 'lbs'),
	(6, 5, 0.031, 'lbs'),

	(6, 6, 0.14, 'each'),
	(6, 7, 0.0004, 'gallons'),
	(6, 8, 0.019, 'lbs'),
	(6, 9, 0.057, 'lbs'),
	(6, 10, 0.0045, 'gallons'),

	(6, 11, 0, 'lbs'),
	(6, 12, 0, 'each'),
	(6, 13, 0, 'lbs'),
	(6, 14, 0.5, 'each'),
	(6, 15, 0.02, 'lbs'),

	(6, 16, 0, 'gallons'),
	(6, 17, 0, 'each'),
	(6, 18, 0, 'lbs'),


	(7, 1, 0.028, 'lbs'),
	(7, 2, 0.00094, 'lbs'),
	(7, 3, 0.00045, 'lbs'),
	(7, 4, 0.054, 'lbs'),
	(7, 5, 0.031, 'lbs'),

	(7, 6, 0.14, 'each'),
	(7, 7, 0.0004, 'gallons'),
	(7, 8, 0.019, 'lbs'),
	(7, 9, 0.057, 'lbs'),
	(7, 10, 0.0045, 'gallons'),

	(7, 11, 0, 'lbs'),
	(7, 12, 0, 'each'),
	(7, 13, 0, 'lbs'),
	(7, 14, 0, 'each'),
	(7, 15, 0, 'lbs'),

	(7, 16, 0.0025, 'gallons'),
	(7, 17, 0, 'each'),
	(7, 18, 0, 'lbs'),


	(8, 1, 0.028, 'lbs'),
	(8, 2, 0.00094, 'lbs'),
	(8, 3, 0.00045, 'lbs'),
	(8, 4, 0.054, 'lbs'),
	(8, 5, 0.031, 'lbs'),

	(8, 6, 0.14, 'each'),
	(8, 7, 0.0004, 'gallons'),
	(8, 8, 0.019, 'lbs'),
	(8, 9, 0.057, 'lbs'),
	(8, 10, 0.0045, 'gallons'),

	(8, 11, 0, 'lbs'),
	(8, 12, 0, 'each'),
	(8, 13, 0, 'lbs'),
	(8, 14, 0, 'each'),
	(8, 15, 0, 'lbs'),

	(8, 16, 0, 'gallons'),
	(8, 17, 0.15, 'each'),
	(8, 18, 0, 'lbs');
	
SELECT *
FROM Project0.RecipeItem;

CREATE TABLE Project0.Location (
	LocationId INT NOT NULL PRIMARY KEY IDENTITY
);

CREATE TABLE Project0.LocationInventory (
	LocationInventoryId INT NOT NULL PRIMARY KEY IDENTITY,
	LocationID INT NOT NULL,
	IngredientID INT NOT NULL,
	Amount DECIMAL(10,6) NOT NULL,
	Units NVARCHAR(50) NOT NULL,
	CONSTRAINT InventoryIngredient UNIQUE (LocationID, IngredientID),
	CONSTRAINT FK_Location FOREIGN KEY (LocationID) REFERENCES Project0.Location (LocationId),
	CONSTRAINT FK_Ingredient FOREIGN KEY (IngredientID) REFERENCES Project0.Ingredient (IngredientId)
);

CREATE TABLE Project0.Customer (
	CustomerId INT NOT NULL PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	DefaultStore INT NOT NULL,
	CONSTRAINT FK_Default_Location FOREIGN KEY (DefaultStore) REFERENCES Project0.Location (LocationId)
);

CREATE TABLE Project0.CupcakeOrder (
	OrderId INT NOT NULL PRIMARY KEY IDENTITY,
	LocationID INT NOT NULL,
	CustomerID INT NOT NULL,
	CupcakeID INT NOT NULL,
	Quantity INT NOT NULL,
	OrderTime DATETIME2 NOT NULL,
	CONSTRAINT FK_Order_Location FOREIGN KEY (LocationID) REFERENCES Project0.Location (LocationId),
	CONSTRAINT FK_Order_Customer FOREIGN KEY (CustomerID) REFERENCES Project0.Customer (CustomerId),
	CONSTRAINT FK_Order_Cupcake FOREIGN KEY (CupcakeID) REFERENCES Project0.Cupcake (CupcakeId)
);

