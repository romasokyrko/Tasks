CREATE DATABASE MyShop

CREATE TABLE Products (
 ProductID INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
 ProductName VARCHAR (50) NOT NULL,
 SupplierID INT NOT NULL,
 CategoryID INT NOT NULL,
 Price DECIMAL NOT NULL,
);

SET IDENTITY_INSERT Products ON
INSERT INTO Products
	(ProductID, ProductName, SupplierID, CategoryID, Price)
VALUES
	(1, 'Chais',1,1,18.00),
	(2, 'Chang',1,1,19.00),
	(3, 'Aniseed Syrup',1,2,10.00),
	(4, 'Chef Anton’s Cajun Seasoning',2,2,22.00),
	(5, 'Chef Anton’s Gumbo Mix',2,2,21.35);
SET IDENTITY_INSERT Products OFF

CREATE TABLE Suppliers (
 SupplierID INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
 SupplierName VARCHAR (50) NOT NULL,
 City VARCHAR (50) NOT NULL,
 Country VARCHAR (50) NOT NULL
);

SET IDENTITY_INSERT Suppliers ON
INSERT INTO Suppliers
	(SupplierID, SupplierName, City, Country)
VALUES
	(1,'Exotic Liquid','London','UK'),
	(2,'New Orleans Cajun Delights','New Orleans','USA'),
	(3,'Grandma Kelly’s Homestead','Ann Arbor','USA'),
	(4,'Tokyo Traders','Tokyo','Japan'),
	(5,'Cooperativa de Quesos ‘Las Cabras’','Oviedo','Spain');
SET IDENTITY_INSERT Suppliers OFF

CREATE TABLE Categories (
 CategoryID INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
 CategoryName VARCHAR (50) NOT NULL, 
 Description NVARCHAR (70) NOT NULL
);

SET IDENTITY_INSERT Categories ON
INSERT INTO Categories
	(CategoryID, CategoryName, Description)
VALUES
	(1,'Beverages','Soft drinks, coffees, teas, beers, and ales'),
	(2,'Condiments','Sweet and savory sauces, relishes, spreads, and seasonings'),
	(3,'Confections','Desserts, candies, and sweet breads'),
	(4,'Dairy Products','Cheeses'),
	(5,'Grains/Cereals','Breads, crackers, pasta, and cereal');
SET IDENTITY_INSERT Categories OFF;



SELECT ProductName 
FROM Products
WHERE ProductName  LIKE 'C%'
ORDER BY ProductName


SELECT TOP (1) ProductName, MIN (Price) AS 'Min Price'
FROM Products
Group By ProductName;

SELECT ProductName, Price, Country
FROM Products INNER JOIN Suppliers
ON Products.ProductID = Suppliers.SupplierID
AND Suppliers.Country = N'USA'
GROUP BY ProductName, Price, Country

SELECT c.CategoryName, s.SupplierName
FROM Products AS p
       JOIN 
	Categories AS c
	ON p.CategoryID = c.CategoryID
	
	JOIN
	Suppliers AS s
	ON s.SupplierID = p.SupplierID
WHERE c.CategoryName = 'Condiments'; 

SET IDENTITY_INSERT Suppliers ON

INSERT INTO Suppliers
	(SupplierID, SupplierName, City, Country)
VALUES	
	(6,'Norske Meierier','Lviv','Ukraine');

SET IDENTITY_INSERT Suppliers OFF

SET IDENTITY_INSERT Products ON

INSERT INTO Products
	(ProductID, ProductName, SupplierID, CategoryID, Price)
VALUES	
	(6, 'Green tea',1,1,10)

SET IDENTITY_INSERT Products OFF;






