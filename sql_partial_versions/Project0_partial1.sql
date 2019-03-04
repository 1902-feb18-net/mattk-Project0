DROP TABLE IF EXISTS Project0.CupcakeOrder
DROP TABLE IF EXISTS Project0.Customer
DROP TABLE IF EXISTS Project0.LocationInventory
DROP TABLE IF EXISTS Project0.RecipeItem
DROP TABLE IF EXISTS Project0.Cupcake
DROP TABLE IF EXISTS Project0.Ingredient
DROP TABLE IF EXISTS Project0.Location

SELECT *
FROM Project0.Location;

SELECT *
FROM Project0.Customer;

SELECT *
FROM Project0.LocationInventory
WHERE LocationId = 2;

SELECT *
FROM Project0.CupcakeOrder;

UPDATE Project0.LocationInventory
SET Amount = 120.00
WHERE 1 = 1;

SELECT *
FROM Project0.Ingredient;

DELETE FROM Project0.CupcakeOrder
WHERE 1 = 1;

SELECT *
FROM Project0.CupcakeOrder;