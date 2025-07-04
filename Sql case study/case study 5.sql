CREATE DATABASE RetailStoreDB;
GO

USE RetailStoreDB;
GO


CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName VARCHAR(100),
    OrderDate DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE OrderItems (
    OrderItemID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
    ProductName VARCHAR(100),
    Quantity INT,
    UnitPrice DECIMAL(10,2)
);
GO

-- Step 2: Use Transaction to Insert Data into Both Tables
BEGIN TRY
    BEGIN TRANSACTION;

    -- Insert into Orders table
    INSERT INTO Orders (CustomerName)
    VALUES ('John Doe');

    -- Get the generated OrderID
    DECLARE @OrderID INT = SCOPE_IDENTITY();

    -- Insert multiple items into OrderItems
    INSERT INTO OrderItems (OrderID, ProductName, Quantity, UnitPrice)
    VALUES 
        (@OrderID, 'Keyboard', 2, 1500.00),
        (@OrderID, 'Mouse', 1, 500.00),
        (@OrderID, 'Monitor', 1, 7000.00);

    -- Commit if all successful
    COMMIT TRANSACTION;
    PRINT 'Order and items inserted successfully.';
END TRY
BEGIN CATCH
    -- Rollback if any error occurs
    ROLLBACK TRANSACTION;
    PRINT 'Transaction failed. Rolled back.';
    PRINT ERROR_MESSAGE();
END CATCH;
GO

-- Step 4: Check the inserted data
-- View Orders
SELECT * FROM Orders;

-- View OrderItems
SELECT * FROM OrderItems;


drop database eventdb;