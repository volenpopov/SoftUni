
CREATE DATABASE TripService;

USE TripService;
GO

---1

CREATE TABLE Cities (
	Id INT IDENTITY
	,[Name] NVARCHAR(20) NOT NULL
	,CountryCode NVARCHAR(2) NOT NULL

	CONSTRAINT PK_CityId PRIMARY KEY (Id)
)


CREATE TABLE Hotels (
	Id INT IDENTITY
	,[Name] NVARCHAR(30) NOT NULL
	,CityId INT NOT NULL
	,EmployeeCount INT NOT NULL
	,BaseRate DECIMAL(15,2)

	CONSTRAINT PK_HotelId PRIMARY KEY (Id)
	,CONSTRAINT FK_HotelsCityToCities FOREIGN KEY (CityId) REFERENCES Cities(Id)
)

CREATE TABLE Rooms (
	Id INT IDENTITY
	,Price DECIMAL(15,2) NOT NULL
	,[Type] NVARCHAR(20) NOT NULL
	,Beds INT NOT NULL
	,HotelId INT NOT NULL

	CONSTRAINT PK_RoomId PRIMARY KEY (Id)
	,CONSTRAINT FK_RoomHotelToHotels FOREIGN KEY (HotelId) REFERENCES Hotels(Id)
)

CREATE TABLE Trips (
	Id INT IDENTITY
	,RoomId INT NOT NULL
	,BookDate DATE NOT NULL
	,ArrivalDate DATE NOT NULL
	,ReturnDate DATE NOT NULL
	,CancelDate DATE

	CONSTRAINT PK_TripId PRIMARY KEY (Id)
	,CONSTRAINT FK_TripRoomToRooms FOREIGN KEY (RoomId) REFERENCES Rooms(Id)
	,CONSTRAINT CHK_BookBeforeArrival CHECK(BookDate < ArrivalDate)
	,CONSTRAINT CHK_ArrivalBeforeReturn CHECK(ArrivalDate < ReturnDate)
)

CREATE TABLE Accounts (
	Id INT IDENTITY
	,FirstName NVARCHAR(50) NOT NULL
	,MiddleName NVARCHAR(20)
	,LastName NVARCHAR(50) NOT NULL
	,CityId INT NOT NULL
	,BirthDate DATE NOT NULL
	,Email NVARCHAR(100) NOT NULL UNIQUE

	,CONSTRAINT PK_AccountId PRIMARY KEY (Id)
	, CONSTRAINT FK_AccountCityToCities FOREIGN KEY (CityId) REFERENCES Cities(Id)
)

CREATE TABLE AccountsTrips (
	AccountId INT NOT NULL
	,TripId INT NOT NULL
	,Luggage INT NOT NULL

	CONSTRAINT FK_AccountsTripsAccountToAccounts FOREIGN KEY (AccountId) REFERENCES Accounts(Id)
	,CONSTRAINT FK_AccountsTripsTripToTrips FOREIGN KEY (TripId) REFERENCES Trips(Id)
	,CONSTRAINT PK_AccountTrip PRIMARY KEY (AccountId, TripId)
	,CONSTRAINT CHK_Luggage CHECK(Luggage >= 0)
)



---2

INSERT INTO Accounts(FirstName, MiddleName, LastName, CityId, BirthDate, Email)
VALUES ('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com'),
('Gosho', NULL, 'Petrov', 11, '1978-05-16', 'g_petrov@gmail.com'),
('Ivan', 'Petrovich', 'Pavlov', 59, '1849-09-26', 'i_pavlov@softuni.bg'),
('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')
 
INSERT INTO Trips(RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate)
VALUES (101, '2015-04-12','2015-04-14', '2015-04-20',   '2015-02-02'),
(102, '2015-07-07','2015-07-15',    '2015-07-22',   '2015-04-29'),
(103, '2013-07-17','2013-07-23',    '2013-07-24',   NULL),
(104, '2012-03-17','2012-03-31',    '2012-04-01',   '2012-01-10'),
(109, '2017-08-07','2017-08-28',    '2017-08-29',   NULL)



---3

UPDATE Rooms
SET Price *= 1.14
WHERE HotelId IN (5, 7, 9)


----4

DELETE FROM AccountsTrips
WHERE AccountId = 47;


---5

SELECT 
	Id
	,[Name]
FROM Cities
WHERE CountryCode = 'BG'
ORDER BY [Name]


---6

SELECT 
	CONCAT(FirstName, ' ', ISNULL(MiddleName + ' ', ''), LastName) AS Fullname
	,YEAR(BirthDate) AS [BirthYear]
FROM Accounts
WHERE YEAR(BirthDate) > 1991
ORDER BY BirthYear DESC, Fullname

---7

SELECT
	a.FirstName
	,a.LastName
	,FORMAT(a.BirthDate, 'MM-dd-yyyy') AS [BirthDate]
	,c.[Name] AS [Hometown]
	,a.Email
FROM Accounts AS a
JOIN Cities AS c ON c.Id = a.CityId
WHERE LEFT(a.Email, 1) = 'e'
ORDER BY Hometown DESC

---8

SELECT
	c.[Name]
	, COUNT(h.Id) AS [Hotels]
FROM Cities AS c
LEFT JOIN Hotels AS h ON h.CityId = c.Id
GROUP BY c.[Name]
ORDER BY Hotels DESC, c.[Name]


---9

SELECT 
	r.Id
	,r.Price
	,h.[Name] AS [Hotel]
	,c.[Name] AS [City]
FROM Rooms AS r
JOIN Hotels AS h ON h.Id = r.HotelId
JOIN Cities AS c ON c.Id = h.CityId
WHERE Type = 'First Class'
ORDER BY r.Price DESC, Id

---10

SELECT
	a.Id AS [AccountId]
	,a.FirstName + ' ' + a.LastName AS [FullName]
	,MAX(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS [LongestTrip]
	,MIN(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS [ShortestTrip]
FROM Accounts AS a
JOIN AccountsTrips AS [at] ON [at].AccountId = a.Id
JOIN Trips AS t ON t.Id = [at].TripId
WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL
GROUP BY a.Id, a.FirstName, a.LastName
ORDER BY LongestTrip DESC, a.Id


---11

SELECT TOP (5)
	c.Id
	,c.[Name] AS City
	,c.CountryCode AS Country
	,COUNT(a.Id) AS [NumOfAccounts]
FROM Cities AS c 
JOIN Accounts AS a ON a.CityId = c.Id 
GROUP BY c.Id, c.[Name], c.CountryCode
ORDER BY [NumOfAccounts] DESC


---12

SELECT 
	a.Id
	,a.Email
	,c.[Name] AS [City]
	,COUNT(t.Id) AS [NumOfTrips]
FROM Accounts AS a
JOIN Cities AS c ON c.Id = a.CityId
JOIN AccountsTrips AS [at] ON [at].AccountId = a.Id
JOIN Trips AS t ON t.Id = [at].TripId
JOIN Rooms AS r ON r.Id = t.RoomId
JOIN Hotels AS h ON h.Id = r.HotelId
WHERE c.Id = h.CityId
GROUP BY a.Id, a.Email, c.[Name]
HAVING COUNT(t.Id) >= 1
ORDER BY NumOfTrips DESC, a.Id


---13

SELECT TOP 10
	c.Id
	,c.[Name]
	,SUM(h.BaseRate + r.Price) AS [TotalRevenue]
	,COUNT(t.Id) AS [NumOfTrips]
FROM Cities AS c
JOIN Hotels AS h ON h.CityId = c.Id
JOIN Rooms AS r ON r.HotelId = h.Id
JOIN Trips AS t ON t.RoomId = r.Id
WHERE YEAR(BookDate) = 2016
GROUP BY c.Id, c.[Name]
ORDER BY TotalRevenue DESC, NumOfTrips DESC


---14

SELECT
	t.Id
	,h.[Name] AS [HotelName]
	,r.[Type] AS [RoomType]
	,CASE
		WHEN t.CancelDate IS NOT NULL THEN 0
		ELSE SUM(h.BaseRate + r.Price)
	 END AS [Revenue]
FROM Trips AS t
JOIN Rooms AS r ON r.Id = t.RoomId
JOIN Hotels AS h ON h.Id = r.HotelId
JOIN AccountsTrips AS [at] ON [at].TripId = t.Id
GROUP BY t.Id, h.Name, r.Type, t.CancelDate
ORDER BY r.[Type], t.Id


---15

SELECT 
	r.Id
	,r.Email
	,r.CountryCode
	,r.TripCount
FROM (	
	SELECT
		a.Id
		,a.Email
		,c.CountryCode
		,COUNT(t.Id) AS [TripCount]
		,ROW_NUMBER() OVER(PARTITION BY c.Countrycode ORDER BY COUNT(t.Id) DESC) AS [Ranking]
	FROM Accounts AS a
	JOIN AccountsTrips AS at ON at.AccountId = a.Id
	JOIN Trips AS t ON t.Id = at.TripId
	JOIN Rooms AS r ON r.Id = t.RoomId
	JOIN Hotels AS h ON h.Id = r.HotelId
	JOIN Cities AS c ON c.Id = h.CityId
	GROUP BY a.Id, a.Email, c.CountryCode
) AS r
WHERE r.Ranking = 1
ORDER BY r.TripCount DESC


---16

SELECT 
	TripId
	,SUM(Luggage) AS [LuggageCount]
	,CASE
		WHEN SUM(Luggage) > 5 THEN CONCAT('$', SUM(Luggage) * 5)
		ELSE '$0'
	END AS [Fee]
FROM AccountsTrips
GROUP BY TripId
HAVING SUM(Luggage) > 0
ORDER BY LuggageCount DESC


---17

SELECT 
	t.Id
	,CONCAT(a.FirstName, ' ', ISNULL(a.MiddleName + ' ', ''), a.LastName) AS [Fullname]
	,c.[Name] AS [From]
	,ci.[Name] AS [To]
	,CASE
		WHEN t.CancelDate IS NULL THEN CONCAT(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate), ' days')
		ELSE 'Canceled'
	END AS [Duration]
FROM Trips AS t
JOIN AccountsTrips AS at ON at.TripId = t.Id
JOIN Accounts AS a ON a.Id = at.AccountId
JOIN Cities AS c ON c.Id = a.CityId
JOIN Rooms AS r ON r.Id = t.RoomId
JOIN Hotels AS h ON h.Id = r.HotelId
JOIN Cities AS ci ON ci.Id = h.CityId
ORDER BY Fullname, t.Id


---18
GO;

CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR(MAX)
AS
	BEGIN

		DECLARE @resultTable TABLE (
			RoomId INT NOT NULL
			,RoomType NVARCHAR(30) NOT NULL
			,Beds INT NOT NULL
			,TotalPrice DECIMAL(15,2) NOT NULL
		);

		INSERT INTO @resultTable
		SELECT TOP 1
			tbl.Id
			,tbl.Type
			,tbl.Beds
			,tbl.TotalPrice
		FROM (
			SELECT
				r.Id
				,r.Type
				,r.Beds
				,r.Price
				,(h.BaseRate + r.Price) * @People AS [TotalPrice]
			FROM Rooms as r 
			JOIN Hotels as h ON h.Id = r.HotelId
			JOIN Trips AS t ON t.RoomId = r.Id
			WHERE h.Id = @HotelId 
				AND r.Beds > @People
				AND @Date NOT BETWEEN t.ArrivalDate AND t.ReturnDate
				AND t.CancelDate IS NULL
		) AS tbl
		ORDER BY TotalPrice DESC
		
		DECLARE @message NVARCHAR(MAX) = (SELECT CONCAT('Room ', r.RoomId, ': ', r.RoomType, ' (', r.Beds, ' beds) - $', r.TotalPrice)
										 FROM @resultTable AS r)

		IF (@message IS NULL)
			RETURN 'No rooms available';
			
		RETURN @message;
	END


SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)


---19
GO;

CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
	BEGIN

		DECLARE @targetHotelId INT = (SELECT TOP 1 r.HotelId
								FROM Rooms AS r
								JOIN Trips AS t ON t.RoomId = r.Id
								WHERE r.Id = @TargetRoomId);

		DECLARE @currentTripHotel INT = (SELECT TOP 1 r.HotelId
										 FROM Rooms AS r 
										 JOIN Trips AS t ON t.RoomId = r.Id
										 WHERE t.Id = @TripId);
	
		DECLARE @targetRoomBeds INT = (SELECT TOP 1 r.Beds
										FROM Rooms AS r
										WHERE r.Id = @TargetRoomId);

		DECLARE @numberOfPeople INT = (SELECT COUNT(*)
										FROM AccountsTrips AS at
										WHERE at.TripId = @TripId);

		IF (@targetHotelId != @currentTripHotel)
			BEGIN
			RAISERROR('Target room is in another hotel!', 16, 1);
			RETURN
			END

		IF (@targetRoomBeds < @numberOfPeople)
			BEGIN
			RAISERROR('Not enough beds in target room!', 16, 1);
			RETURN
			END

		UPDATE Trips
		SET RoomId = @TargetRoomId
		WHERE Id = @TripId;
	
	END;

---20
GO;

CREATE TRIGGER tr_DeletingTrip ON Trips
INSTEAD OF DELETE
AS
	BEGIN

		UPDATE Trips SET CancelDate = CAST(GETDATE() AS DATE)
		FROM Trips AS t
		JOIN DELETED AS d ON d.Id = t.Id
		WHERE t.Id = d.Id AND t.CancelDate IS NULL
		
	END;