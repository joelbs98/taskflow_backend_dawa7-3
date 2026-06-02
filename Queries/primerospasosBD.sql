USE CursoDB;

SELECT * FROM Cursos;


-- REPASO DE BASE DE DATOS
/*
CREATE DATABASE CursoDB; -> CREAR UNA BASE DE DATOS

CREATE TABLE Cursos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Docente NVARCHAR(100) NOT NULL,
    Activo BIT NOT NULL
); -> CREAR UNA TABLA


INSERT INTO Cursos (Nombre, Docente, Activo)
VALUES 
('Desarrollo Web', 'Ing. Joel Barba', 1),
('Bases de Datos', 'Ing. Karla Abad', 1),
('Programación Avanzada', 'Ing. Leili López', 0); -> INSERTAR UNO O VARIOS REGISTROS

SELECT * FROM Cursos; -> CONSULTAR O LEER

UPDATE Cursos
SET Activo = 1
WHERE Id = 3; -> ACTUALIZAR UN O VARIOS REGISTROS

DELETE FROM Cursos WHERE Id=2; -> ELIMINAR UN O VARIOS REGISTROS
*/

