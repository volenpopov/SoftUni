CREATE DATABASE School

USE School
GO;

CREATE TABLE Subjects (
	Id INT IDENTITY PRIMARY KEY
	,Name NVARCHAR(20) NOT NULL
	,Lessons INT NOT NULL

	,CONSTRAINT CHK_LessonMoreThanZero CHECK(Lessons > 0)
)

CREATE TABLE Teachers (
	Id INT IDENTITY PRIMARY KEY
	,FirstName NVARCHAR(20) NOT NULL
	,LastName NVARCHAR(20) NOT NULL
	,Address NVARCHAR(20) NOT NULL
	,Phone VARCHAR(10)
	,SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE Exams (
	Id INT IDENTITY PRIMARY KEY
	,Date DATETIME
	,SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE Students (
	Id INT IDENTITY PRIMARY KEY
	,FirstName NVARCHAR(30) NOT NULL
	,MiddleName NVARCHAR(25)
	,LastName NVARCHAR(30) NOT NULL
	,Age INT
	,Address NVARCHAR(50) 
	,Phone NVARCHAR(10)

	,CONSTRAINT CHK_Age CHECK(Age >= 5 AND Age <= 100)
)

CREATE TABLE StudentsTeachers (
	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL
	,TeacherId INT FOREIGN KEY REFERENCES Teachers(Id) NOT NULL

	,CONSTRAINT PK_StudentTeacher PRIMARY KEY(StudentId, TeacherId)
)

CREATE TABLE StudentsExams (
	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL
	,ExamId INT FOREIGN KEY REFERENCES Exams(Id) NOT NULL
	,Grade DECIMAL(3,2) NOT NULL
	
    ,CONSTRAINT PK_StudentExam PRIMARY KEY(StudentId, ExamId)
	,CONSTRAINT CHK_ExamGrade CHECK(Grade >= 2.00 AND Grade <= 6.00)
)

CREATE TABLE StudentsSubjects (
	Id INT IDENTITY PRIMARY KEY
	,StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL
	,SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
	,Grade DECIMAL(3,2)  NOT NULL

	,CONSTRAINT CHK_SubjectGrade CHECK(Grade >= 2.00 AND Grade <= 6.00)
)

---2

INSERT INTO Subjects (Name, Lessons) VALUES
('Geometry', 12),
('Health', 10),
('Drama', 7),
('Sports', 9)

INSERT INTO Teachers (FirstName, LastName, Address, Phone, SubjectId) VALUES
('Ruthanne', 'Bamb', '84948 Mesta Junction', '3105500146', 6),
('Gerrard', 'Lowin', '370 Talisman Plaza', '3324874824', 2),
('Merrile', 'Lambdin', '81 Dahle Plaza', '4373065154', 5),
('Bert', 'Ivie', '2 Gateway Circle', '4409584510', 4)


---3

UPDATE StudentsSubjects
SET Grade =
	CASE 
		WHEN Grade >= 5.50 THEN 6.00
		ELSE Grade
	END
WHERE SubjectId IN (1,2)

---4

DELETE FROM StudentsTeachers
WHERE TeacherId IN (
	SELECT Id
	FROM Teachers
	WHERE Phone LIKE '%72%'
)

DELETE FROM Teachers
WHERE Id IN (
	SELECT Id
	FROM Teachers
	WHERE Phone LIKE '%72%'
)

---5
SELECT FirstName, LastName, Age
FROM Students
WHERE Age >= 12
ORDER BY FirstName, LastName


---6
SELECT 
	CONCAT(FirstName, ' ', MiddleName, ' ', LastName) as [Full Name]
	,Address
FROM Students
WHERE Address LIKE '%road%'
ORDER BY FirstName, LastName, [Address]

---7
SELECT FirstName, [Address], Phone
FROM Students
WHERE MiddleName IS NOT NULL AND LEFT(Phone, 2) = '42'
ORDER BY FirstName

---8
SELECT FirstName, LastName, COUNT(TeacherId) AS [TeachersCount]
FROM StudentsTeachers AS st
JOIN Students AS s ON s.Id = st.StudentId
GROUP BY FirstName, LastName


---9
SELECT 
	CONCAT(FirstName, ' ', LastName) as [FullName]
	,(s.Name + '-' + CAST(s.Lessons AS VARCHAR(5)))
	,COUNT(st.StudentId) AS [StudentsCount]
FROM Teachers AS t
JOIN  Subjects AS s ON s.Id = t.SubjectId
JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
GROUP BY FirstName, LastName, s.Name, s.Lessons
ORDER BY StudentsCount DESC


---10
SELECT CONCAT(FirstName, ' ', LastName) as [Full Name]
FROM Students AS s
LEFT JOIN StudentsExams AS se ON se.StudentId = s.Id
WHERE se.ExamId IS NULL
ORDER BY [Full Name]

---11
SELECT TOP 10  t.FirstName, t.LastName, COUNT(st.StudentId) AS [studentCount]
FROM Teachers AS t
JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
GROUP BY FirstName, LastName
ORDER BY studentCount DESC, FirstName, LastName

---12
SELECT TOP 10 s.FirstName, s.LastName, CONVERT(DECIMAL(3,2),AVG(se.Grade)) AS [SuccessRate]
FROM Students AS s
JOIN StudentsExams AS se ON se.StudentId = s.Id
GROUP BY s.FirstName, s.LastName
ORDER BY SuccessRate DESC, FirstName, LastName


---13
SELECT r.FirstName, r.LastName, r.Grade
FROM (
	SELECT s.FirstName, s.LastName, ss.Grade, DENSE_RANK() OVER(PARTITION BY FirstName ORDER BY ss.Grade DESC) AS [Rankoing]
	FROM Students AS s
	JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id
	GROUP BY FirstName, LastName, ss.Grade
) AS r
WHERE r.Rankoing = 2
ORDER BY FirstName, LastName

---14
SELECT CONCAT(FirstName, ' ', ISNULL(MiddleName + ' ', ''), LastName) AS [Fullname]
FROM Students AS s
LEFT JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id
WHERE ss.SubjectId IS NULL
ORDER BY Fullname


---15
SELECT
	[data].TeacherName
	,[data].[Subject]
	,[data].StudentName
	,CONVERT(DECIMAL(3,2), [data].avgGrade) AS [Grade]
FROM (
	SELECT
		t.FirstName + ' ' + t.LastName AS [TeacherName]
		,sub.[Name] AS [Subject]
		,s.FirstName + ' ' + s.LastName AS [StudentName]
		,DENSE_RANK() OVER(PARTITION BY t.FirstName + ' ' + t.LastName ORDER BY AVG(ss.Grade) DESC) AS [GradeRank]
		,AVG(ss.Grade) AS [avgGrade]
	FROM Teachers AS t
	JOIN Subjects AS sub ON sub.Id = t.SubjectId
	JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
	JOIN Students AS s ON s.Id = st.StudentId
	JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id AND ss.SubjectId = sub.Id
	GROUP BY t.FirstName, t.LastName, sub.Name, s.FirstName, s.LastName
) AS [data]
WHERE data.GradeRank = 1
ORDER BY [data].[Subject], [data].TeacherName, Grade DESC

---16
SELECT su.Name AS [subjname], AVG(ss.Grade)
FROM Subjects AS su
JOIN StudentsSubjects AS ss ON ss.SubjectId = su.Id
GROUP BY su.Name, su.Id
ORDER BY su.Id

---17

SELECT t.quarter, t.subjName, COUNT(t.stud)
FROM (
	SELECT
		CASE
			WHEN MONTH(e.Date) IN (1,2,3) THEN 'Q1'
			WHEN MONTH(e.Date) IN (4,5,6) THEN 'Q2'
			WHEN MONTH(e.Date) IN (7,8,9) THEN 'Q3'
			WHEN MONTH(e.Date) IN (10,11,12) THEN 'Q4'
			ELSE 'TBA'
		END AS [quarter]
		,su.Name AS [subjName]
		,se.StudentId AS [stud]
		,Grade
	FROM Exams AS e
	JOIN Subjects AS su ON su.Id = e.SubjectId
	JOIN StudentsExams AS se ON se.ExamId = e.Id
	WHERE Grade >= 4.00
) AS t
GROUP BY t.quarter, t.subjName
ORDER BY t.quarter

---18

CREATE FUNCTION dbo.udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(3,2))
RETURNS	NVARCHAR(MAX)
AS
BEGIN

	IF (NOT EXISTS(SELECT Id FROM Students WHERE Id = @studentId))
		RETURN 'The student with provided id does not exist in the school!';

	IF (@grade > 6.00)
		RETURN 'Grade cannot be above 6.00!';

	DECLARE @studentName NVARCHAR(MAX) = (SELECT FirstName FROM Students WHERE Id = @studentId);

	DECLARE @endGrade DECIMAL(3,2) = @grade + 0.50;

	DECLARE @result INT = (SELECT COUNT(*) 
							FROM StudentsExams 
							WHERE StudentId = @studentId
							AND Grade BETWEEN @grade AND @endGrade);
	RETURN 'You have to update ' + CONVERT(NVARCHAR(3), @result)+ ' grades for the student ' + @studentName;

END


---19
CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS

BEGIN

		IF (NOT EXISTS(SELECT Id FROM Students WHERE Id = @StudentId))
		BEGIN
		RAISERROR('This school has no student with the provided id!', 16, 1);
		RETURN
		END

		DELETE FROM StudentsTeachers
		WHERE StudentId = @StudentId

		DELETE FROM StudentsExams
		WHERE StudentId = @StudentId

		DELETE FROM StudentsSubjects
		WHERE StudentId = @StudentId

		DELETE FROM Students
		WHERE Id = @StudentId

END 


---20
CREATE TABLE ExcludedStudents (
	StudentId INT NOT NULL
	,StudentName NVARCHAR(MAX) NOT NULL
)

CREATE TRIGGER tr_ExcludeStudent ON Students FOR DELETE
AS

INSERT INTO ExcludedStudents (StudentId, StudentName)
SELECT d.Id, d.FirstName + ' ' + d.LastName
FROM deleted AS d
