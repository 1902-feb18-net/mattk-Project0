CREATE DATABASE Project0;

GO
CREATE SCHEMA Project0;
GO

DROP TABLE IF EXISTS Project0.Cupcake
DROP TABLE IF EXISTS Project0.CupcakeOrder
DROP TABLE IF EXISTS Project0.Customer
DROP TABLE IF EXISTS Project0.Ingredient
DROP TABLE IF EXISTS Project0.Location
DROP TABLE IF EXISTS Project0.LocationInventory
DROP TABLE IF EXISTS Project0.RecipeItem



CREATE TABLE Project0.Location (
	LocationId INT NOT NULL PRIMARY KEY IDENTITY
);

SELECT *
FROM Project0.Location;

SELECT *
FROM Project0.Customer;
