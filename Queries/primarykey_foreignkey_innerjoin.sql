-- CREATE DATABASE AcademiaDB;
USE AcademiaDB;
/*
CREATE TABLE Docentes(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR(100) NOT NULL
);

CREATE TABLE Cursos (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR(100) NOT NULL,
	Activo BIT NOT NULL,
	DocenteId INT NOT NULL,
	FOREIGN KEY (DocenteId) REFERENCES Docentes(Id)
);

INSERT INTO Docentes (Nombre) VALUES
('Ing. Joel Barba'),
('Ing. Alejandro Salazar'),
('Ing. Angie Guale');

INSERT INTO Cursos (Nombre, Activo, DocenteId)
VALUES
('Desarrollo Web avanzado',1,2),
('Base de datos II', 1, 1),
('Arquitectura de software', 0,3);

SELECT * FROM Docentes;
*/
USE AcademiaDB;

SELECT * FROM Cursos;
SELECT * FROM Docentes;

USE AcademiaDB;
-- JOIN permite combinar información de dos o mas tablas relacionadas
SELECT Cursos.Nombre AS Curso, Docentes.Nombre AS Docente
FROM Cursos
INNER JOIN Docentes ON Cursos.DocenteId = Docentes.Id;

USE AcademiaDB;
SELECT
	Cursos.Id,
	Cursos.Nombre AS Curso,
	Cursos.Activo,
	Docentes.Nombre AS Docente
FROM Cursos
INNER JOIN Docentes ON Cursos.DocenteId = Docentes.Id
WHERE Cursos.Activo = 0;

USE AcademiaDB;
SELECT
	Cursos.Id,
	Cursos.Nombre AS Curso,
	Cursos.Activo,
	Docentes.Nombre AS Docente
FROM Cursos
INNER JOIN Docentes ON Cursos.DocenteId = Docentes.Id
ORDER BY Cursos.Nombre ASC;



