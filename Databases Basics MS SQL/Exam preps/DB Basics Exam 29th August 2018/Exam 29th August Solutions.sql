USE master
GO

CREATE DATABASE Supermarket
GO

USE Supermarket
GO

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Items
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	Price DECIMAL(15,2) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Phone CHAR(12) NOT NULL,
	Salary DECIMAL(15,2) NOT NULL
)

CREATE TABLE Orders
(
	Id INT PRIMARY KEY IDENTITY,
	[DateTime] DATETIME NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL
)

CREATE TABLE OrderItems
(
	OrderId INT FOREIGN KEY REFERENCES Orders(Id),
	ItemId INT FOREIGN KEY REFERENCES Items(Id),
	Quantity INT NOT NULL CHECK(Quantity >= 1)

	CONSTRAINT PK_OrderItems PRIMARY KEY (OrderId, ItemId)
)

CREATE TABLE Shifts
(
	Id INT IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	CheckIn DATETIME NOT NULL,
	CheckOut DATETIME NOT NULL

	
	CONSTRAINT PK_Shifts PRIMARY KEY (Id, EmployeeId)
)

ALTER TABLE Shifts 
ADD CONSTRAINT CHK_CheckDates CHECK(CheckIn < CheckOut)


---2
INSERT INTO Employees (FirstName, LastName, Phone, Salary) VALUES
  ('Stoyan',	'Petrov',	'888-785-8573',	500.25),
  ('Stamat',	'Nikolov',	'789-613-1122',	999995.25),
  ('Evgeni',	'Petkov',	'645-369-9517',	1234.51),
  ('Krasimir',	'Vidolov',	'321-471-9982',	50.25)

INSERT INTO Items (Name, Price, CategoryId) VALUES
  ('Tesla battery',154.25	,8),
  ('Chess',	30.25,	8),
  ('Juice',	5.32,1),
  ('Glasses',10,	8),
  ('Bottle of water',	1,	1)


 ---3

 UPDATE Items
 SET Price *= 1.27
 WHERE CategoryId IN (1, 2, 3)

 ---4

 DELETE FROM OrderItems
 WHERE OrderId = 48

 DELETE FROM Orders
 WHERE Id = 48

 ---5

 SELECT Id, FirstName
 FROM Employees
 WHERE Salary > 6500
 ORDER BY FirstName, Id

 ---6

 SELECT CONCAT(FirstName, ' ', LastName), Phone
 FROM Employees
 WHERE LEFT(Phone, 1) = '3'
 ORDER BY FirstName, Phone

 ---7

 SELECT FirstName, LastName, COUNT(o.Id) AS [OrdersCount]
 FROM Employees AS e
 JOIN Orders AS o ON o.EmployeeId = e.Id
 GROUP BY FirstName, LastName
 ORDER BY OrdersCount DESC, FirstName

 ---8

 SELECT FirstName, LastName, AVG(DATEDIFF(HOUR,s.CheckIn, s.CheckOut)) AS [Diff]
 FROM Employees AS e
 JOIN Shifts AS s ON s.EmployeeId = e.Id
 GROUP BY e.Id, FirstName, LastName, e.Id
 HAVING AVG(DATEDIFF(HOUR,s.CheckIn, s.CheckOut)) > 7
 ORDER BY Diff DESC, e.Id

 ---9

 SELECT TOP 1 r.OrderId, SUM(r.Price * r.Quantity) AS [TotalPrice]
 FROM (
	 SELECT	oi.OrderId, i.Price, oi.Quantity
	 FROM OrderItems AS oi
	 JOIN Items AS i ON i.Id = oi.ItemId
	 GROUP BY oi.OrderId, i.Price, oi.Quantity
 ) AS r
 GROUP BY r.OrderId
 ORDER BY TotalPrice DESC

 ---10

 SELECT TOP 10 oi.OrderId, MAX(i.Price) AS [Exp], MIN(i.Price) AS [Cheap]
 FROM OrderItems AS oi
 JOIN Items AS i ON i.Id = oi.ItemId
 GROUP BY oi.OrderId
 ORDER BY [Exp] DESC, oi.OrderId

 
---11

SELECT DISTINCT e.Id, FirstName, LastName
FROM Employees AS e
JOIN Orders AS o ON o.EmployeeId = e.Id
JOIN OrderItems AS oi ON oi.OrderId = o.Id
ORDER BY e.Id

---12

SELECT DISTINCT r.Id, r.Fullname
FROM (
	SELECT e.Id, e.FirstName + ' ' + e.LastName AS [Fullname]
		,CASE
			WHEN (DATEDIFF(HOUR, s.CheckIn, s.CheckOut)) < 4  THEN 1
			ELSE 0
		END AS [check]
	FROM Employees AS e
	JOIN Shifts AS s ON s.EmployeeId = e.Id
) AS r
WHERE r.[check] = 1
ORDER BY r.Id

---13

SELECT
	e.FirstName + ' ' + e.LastName
	,SUM(i.Price * oi.Quantity) AS [Total Price]
	,SUM(oi.Quantity) AS [ItemsCount]
FROM Employees AS e
JOIN Orders AS o ON o.EmployeeId = e.Id
JOIN OrderItems AS oi ON oi.OrderId = o.Id
JOIN Items AS i ON i. Id = oi.ItemId
WHERE o.[DateTime] < '2018-06-15' 
GROUP BY e.FirstName, e.LastName
ORDER BY [Total Price] DESC, ItemsCount DESC

---14

SELECT
	CONCAT(FirstName, ' ', LastName) AS [Fullname]
	,CASE
		WHEN DATEPART(WEEKDAY, s.CheckIn) = 1 THEN 'Sunday'
		WHEN DATEPART(WEEKDAY, s.CheckIn) = 2 THEN 'Monday'
		WHEN DATEPART(WEEKDAY, s.CheckIn) = 3 THEN 'Tuesday'
		WHEN DATEPART(WEEKDAY, s.CheckIn) = 4 THEN 'Wednesday'
		WHEN DATEPART(WEEKDAY, s.CheckIn) = 5 THEN 'Thursday'
		WHEN DATEPART(WEEKDAY, s.CheckIn) = 6 THEN 'Friday'
		WHEN DATEPART(WEEKDAY, s.CheckIn) = 7 THEN 'Saturday'
	END AS [ce]
FROM Employees AS e
LEFT JOIN Orders AS o ON o.EmployeeId = e.Id
JOIN Shifts AS s ON s.EmployeeId = e.Id
WHERE o.Id IS NULL AND DATEDIFF(HOUR, s.CheckIn, s.CheckOut) > 12
ORDER BY e.Id


---15

SELECT 
	CONCAT(e.FirstName, ' ', e.LastName) AS [fullname]
	,DATEDIFF(HOUR, s.CheckIn, s.CheckOut) AS [Workhours]
	,t.price
FROM (
	SELECT o.EmployeeId
		,o.Id
		,SUM(i.Price * oi.Quantity) AS [price]
		,ROW_NUMBER() OVER(PARTITION BY o.EmployeeId ORDER BY SUM(i.Price * oi.Quantity) DESC) as [rankigng]
		,o.[DateTime] as [dsad]
	FROM Orders AS o
	JOIN OrderItems AS oi ON oi.OrderId = o.Id
	JOIN Items AS i ON i.Id = oi.ItemId
	GROUP BY o.EmployeeId, o.Id, o.DateTime
) AS t
JOIN Employees AS e ON e.Id = t.EmployeeId
JOIN Shifts AS s ON s.EmployeeId = e.Id
WHERE t.rankigng = 1 AND t.dsad BETWEEN s.CheckIn AND s.CheckOut
ORDER BY fullname, Workhours DESC


---16

SELECT DATEPART(DAY, o.DateTime) AS dayy, FORMAT(AVG(i.Price * oi.Quantity), 'N2')
FROM Orders AS o
JOIN OrderItems AS oi ON oi.OrderId = o.Id
JOIN Items AS i ON i.Id = oi.ItemId
GROUP BY DATEPART(DAY, o.DateTime)
ORDER BY dayy


---17

SELECT i.Name, c.Name, SUM(oi.Quantity) AS [count], SUM(i.Price * oi.Quantity) AS profit
FROM Items AS i
JOIN Categories AS c ON c.Id = i.CategoryId
LEFT JOIN OrderItems AS oi ON oi.ItemId = i.Id
GROUP BY i.Name, c.Name
ORDER BY profit DESC, count DESC


---18
GO;

CREATE FUNCTION dbo.udf_GetPromotedProducts(@CurrentDate DATE, @StartDate DATE, @EndDate DATE, @Discount DECIMAL(15,2), @FirstItemId INT, @SecondItemId INT, @ThirdItemId INT)
RETURNS NVARCHAR(MAX)
AS 

BEGIN
	
	DECLARE @itemErrorMsg NVARCHAR(100) = 'One of the items does not exists!';
	DECLARE @dateErrorMsg NVARCHAR(100) = 'The current date is not within the promotion dates!';


	IF (NOT EXISTS(SELECT Id FROM Items WHERE Id = @FirstItemId))
		RETURN @itemErrorMsg;

	IF (NOT EXISTS(SELECT Id FROM Items WHERE Id = @SecondItemId))
		RETURN @itemErrorMsg;

	IF (NOT EXISTS(SELECT Id FROM Items WHERE Id = @ThirdItemId))
		RETURN @itemErrorMsg;

	IF (NOT @CurrentDate BETWEEN @StartDate AND @EndDate)
		RETURN @dateErrorMsg;

	DECLARE @firstItemName NVARCHAR(50) = (SELECT Name FROM Items WHERE Id = @FirstItemId);
	DECLARE @secondItemName NVARCHAR(50) = (SELECT Name FROM Items WHERE Id = @SecondItemId);
	DECLARE @thirdItemName NVARCHAR(50) = (SELECT Name FROM Items WHERE Id = @ThirdItemId);

	DECLARE @firstItemDiscountedPrice DECIMAL(15,2) = (SELECT Price FROM Items WHERE Id = @FirstItemId) * ((100 - @Discount)/100);
	DECLARE @secondItemDiscountedPrice DECIMAL(15,2) = (SELECT Price FROM Items WHERE Id = @SecondItemId) * ((100 - @Discount)/100);
	DECLARE @thirdItemDiscountedPrice DECIMAL(15,2) = (SELECT Price FROM Items WHERE Id = @ThirdItemId) * ((100 - @Discount)/100);

	DECLARE @message NVARCHAR(MAX) = CONCAT(@firstItemName, ' price: ', @firstItemDiscountedPrice, ' <-> ', @secondItemName, ' price: ', @secondItemDiscountedPrice, ' <-> ', @thirdItemName, ' price: ', @thirdItemDiscountedPrice);

	RETURN @message;

END

---19

GO;

CREATE PROC dbo.usp_CancelOrder(@OrderId INT, @CancelDate DATE)
AS

BEGIN 

	IF (NOT EXISTS(SELECT Id FROM Orders WHERE Id = @OrderId))
		BEGIN
		RAISERROR('The order does not exist!', 16, 1)
		RETURN
		END
		

	DECLARE @issueDate DATETIME = (SELECT DateTime FROM Orders WHERE Id = @OrderId);

	IF (DATEDIFF(DAY, @issueDate, @CancelDate) >= 3)
		BEGIN
		RAISERROR('You cannot cancel the order!', 16, 1)
		RETURN
		END

	DELETE FROM OrderItems
	WHERE OrderId = @OrderId

	DELETE FROM Orders
	WHERE Id = @OrderId

END

---20

CREATE TABLE DeletedOrders (
	OrderId INT NOT NULL
	,ItemId INT NOT NULL
	,ItemQuantity INT NOT NULL
	
	CONSTRAINT PK_OrderItem PRIMARY KEY (OrderId, ItemId) 
)

GO;
CREATE TRIGGER tr_OnOrderDelete ON OrderItems FOR DELETE
AS

INSERT INTO DeletedOrders (OrderId, ItemId, ItemQuantity)
SELECT d.OrderId, d.ItemId, d.Quantity
FROM deleted AS d
