USE EmployeeDB;
GO

-- Exercise 5: Create a Stored Procedure to return the total number of employees in a department.
-- Name: sp_GetTotalEmployeesInDepartment
CREATE PROCEDURE sp_GetTotalEmployeesInDepartment
    @DepartmentID INT,
    @TotalEmployees INT OUTPUT -- Output parameter to return the count
AS
BEGIN
    SELECT @TotalEmployees = COUNT(EmployeeID)
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;
GO

-- Testing Stored Procedures

-- Test sp_GetTotalEmployeesInDepartment for DepartmentID 3 (IT)
PRINT '--- Testing sp_GetTotalEmployeesInDepartment for DepartmentID 3 (IT) ---';
DECLARE @EmployeeCountIT INT;
EXEC sp_GetTotalEmployeesInDepartment
    @DepartmentID = 3,
    @TotalEmployees = @EmployeeCountIT OUTPUT;
SELECT @EmployeeCountIT AS TotalEmployeesInITDepartment;
GO

-- Test sp_GetTotalEmployeesInDepartment for DepartmentID 1 (HR)
PRINT '--- Testing sp_GetTotalEmployeesInDepartment for DepartmentID 1 (HR) ---';
DECLARE @EmployeeCountHR INT;
EXEC sp_GetTotalEmployeesInDepartment
    @DepartmentID = 1,
    @TotalEmployees = @EmployeeCountHR OUTPUT;
SELECT @EmployeeCountHR AS TotalEmployeesInHRDepartment;
GO
