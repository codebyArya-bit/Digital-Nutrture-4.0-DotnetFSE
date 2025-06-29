-- CREATE DATABASE OnlineRetailStore;
-- GO

USE OnlineRetailStore;
GO

-- (optional) clean out old tables
DROP TABLE IF EXISTS OrderDetails;
DROP TABLE IF EXISTS Orders;
DROP TABLE IF EXISTS Products;
DROP TABLE IF EXISTS Customers;
GO

-- now your DDL + DML
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    Name VARCHAR(100),
    Region VARCHAR(50)
);
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10,2)
);
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT        REFERENCES Customers(CustomerID),
    OrderDate DATE
);
CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY,
    OrderID INT           REFERENCES Orders(OrderID),
    ProductID INT         REFERENCES Products(ProductID),
    Quantity INT
);
GO

INSERT INTO Customers (CustomerID, Name, Region) VALUES
 (1,'Alice','North'),(2,'Bob','South'),
 (3,'Charlie','East'),(4,'David','West');
INSERT INTO Products (ProductID, ProductName, Category, Price) VALUES
 (1,'Laptop','Electronics',1200.00),
 (2,'Smartphone','Electronics', 800.00),
 (3,'Tablet','Electronics', 600.00),
 (4,'Headphones','Accessories', 150.00),
 (5,'Charger','Accessories', 150.00),
 (6,'Smartwatch','Electronics', 800.00);
INSERT INTO Orders (OrderID, CustomerID, OrderDate) VALUES
 (1,1,'2023-01-15'),(2,2,'2023-02-20'),
 (3,3,'2023-03-25'),(4,4,'2023-04-30');
INSERT INTO OrderDetails (OrderDetailID, OrderID, ProductID, Quantity) VALUES
 (1,1,1,1),(2,2,2,2),(3,3,3,1),(4,4,4,3);
GO

-- Exercise 1A: ROW_NUMBER
SELECT *
FROM (
  SELECT 
    ProductID,ProductName,Category,Price,
    ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum
  FROM Products
) AS x
WHERE RowNum<=3
ORDER BY Category,RowNum;
GO

-- Exercise 1B: RANK
SELECT *
FROM (
  SELECT 
    ProductID,ProductName,Category,Price,
    RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS RankNum
  FROM Products
) AS x
WHERE RankNum<=3
ORDER BY Category,RankNum;
GO

-- Exercise 1C: DENSE_RANK
SELECT *
FROM (
  SELECT 
    ProductID,ProductName,Category,Price,
    DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRankNum
  FROM Products
) AS x
WHERE DenseRankNum<=3
ORDER BY Category,DenseRankNum;
GO
