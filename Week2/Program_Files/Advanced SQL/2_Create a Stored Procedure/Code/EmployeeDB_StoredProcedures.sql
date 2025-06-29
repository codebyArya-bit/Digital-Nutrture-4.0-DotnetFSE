-- EmployeeDB Stored Procedures Script

CREATE DATABASE EmployeeDB;
GO

USE EmployeeDB;
GO

CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);
GO

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1), -- Using IDENTITY for auto-incrementing EmployeeID
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
    Salary DECIMAL(10,2),
    JoinDate DATE
);
GO

INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'HR'),
(2, 'Finance'),
(3, 'IT'),
(4, 'Marketing');
GO

INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
('John', 'Doe', 1, 5000.00, '2020-01-15'),
('Jane', 'Smith', 2, 6000.00, '2019-03-22'),
('Michael', 'Johnson', 3, 7000.00, '2018-07-30'),
('Emily', 'Davis', 4, 5500.00, '2021-11-05');
GO

-- Stored Procedures
-- Exercise 1, Steps 1 & 2: Create a Stored Procedure to retrieve employee details by department.
-- Name: sp_GetEmployeesByDepartment
CREATE PROCEDURE sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT
        E.EmployeeID,
        E.FirstName,
        E.LastName,
        D.DepartmentName,
        E.Salary,
        E.JoinDate
    FROM
        Employees AS E
    INNER JOIN
        Departments AS D ON E.DepartmentID = D.DepartmentID
    WHERE
        E.DepartmentID = @DepartmentID;
END;
GO 

-- Exercise 1, Step 3: Create a stored procedure named sp_InsertEmployee
CREATE PROCEDURE sp_InsertEmployee
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @Salary DECIMAL(10,2),
    @JoinDate DATE
AS
BEGIN
    INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate)
    VALUES (@FirstName, @LastName, @DepartmentID, @Salary, @JoinDate);
END;
GO

-- Test sp_GetEmployeesByDepartment
PRINT '--- Testing sp_GetEmployeesByDepartment for DepartmentID 1 (HR) ---';
EXEC sp_GetEmployeesByDepartment @DepartmentID = 1;
GO

-- Test sp_InsertEmployee
PRINT '--- Testing sp_InsertEmployee ---';
EXEC sp_InsertEmployee
    @FirstName = 'Nirupam',
    @LastName = 'Das',
    @DepartmentID = 3,
    @Salary = 6200.00,
    @JoinDate = '2023-05-10';
GO

-- Verify the new employee has been inserted
PRINT '--- Verifying newly inserted employee ---';
SELECT * FROM Employees WHERE FirstName = 'Nirupam' AND LastName = 'Das';
GO

-- Re-test sp_GetEmployeesByDepartment for DepartmentID 3
PRINT '--- Re-testing sp_GetEmployeesByDepartment for DepartmentID 3 (IT) to see Nirupam ---';
EXEC sp_GetEmployeesByDepartment @DepartmentID = 3;
GO
