CREATE DATABASE JGonzalezPruebaMVC
GO

CREATE TABLE Autor(
	IdAutor INT PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(50)
)

CREATE TABLE Editorial(
	IdEditorial INT PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(50)
)

CREATE TABLE Genero(
	IdGenero INT PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(50)
)

CREATE TABLE Libro(
	IdLibro INT PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(50),
	IdAutor INT REFERENCES Autor(IdAutor),
	NumeroPaginas INT,
	FechaPublicacion DATE,
	IdEditorial INT REFERENCES Editorial(IdEditorial),
	Edicion VARCHAR(50),
	IdGenero INT REFERENCES Genero(IdGenero),
)


CREATE PROCEDURE LibroAdd
@Nombre VARCHAR(50),
@IdAutor INT,
@NumeroPaginas INT,
@FechaPublicacion VARCHAR(15),
@IdEditorial INT,
@Edicion VARCHAR(50),
@IdGenero INT
AS

INSERT INTO Libro (Nombre,
	IdAutor,
	NumeroPaginas,
	FechaPublicacion,
	IdEditorial,
	Edicion,
	IdGenero)

	VALUES (@Nombre,
			@IdAutor,
			@NumeroPaginas,
			CONVERT(DATE,@FechaPublicacion,105),
			@IdEditorial,
			@Edicion,
			@IdGenero)
GO

LibroAdd 'Don Quijote de la Mancha', 1, 256, '02-05-1605', 2, '13ra. Edicion', 5

SELECT * FROM Libro

CREATE PROCEDURE LibroUpdate
@IdLibro INT,
@Nombre VARCHAR(50),
@IdAutor INT,
@NumeroPaginas INT,
@FechaPublicacion VARCHAR(15),
@IdEditorial INT,
@Edicion VARCHAR(50),
@IdGenero INT
AS
UPDATE Libro SET Nombre = @Nombre,
				IdAutor = @IdAutor,
				NumeroPaginas = @NumeroPaginas,
				FechaPublicacion = CONVERT(DATE, @FechaPublicacion, 105),
				IdEditorial = @IdEditorial,
				Edicion = @Edicion,
				IdGenero = @IdGenero
WHERE IdLibro = @IdLibro
GO

LibroUpdate 3, 'El señor de los anillos', 2, 300, '29-07-1954', 3, '13ra. Edicion', 5

CREATE PROCEDURE LibroDelete
@IdLibro INT
AS
DELETE FROM Libro WHERE IdLibro = @IdLibro
GO

LibroDelete 4

CREATE PROCEDURE LibroGetAll
AS
SELECT Libro.IdLibro,
	Libro.Nombre,
	Libro.IdAutor,
	Autor.Nombre AS AutorNombre,
	Libro.NumeroPaginas,
	Libro.FechaPublicacion,
	Libro.IdEditorial,
	Editorial.Nombre AS EditorialNombre,
	Libro.Edicion,
	Libro.IdGenero,
	Genero.Nombre AS GeneroNombre
FROM Libro
INNER JOIN Autor ON Autor.IdAutor = Libro.IdAutor
INNER JOIN Editorial ON Editorial.IdEditorial = Libro.IdEditorial
INNER JOIN Genero ON Genero.IdGenero = Libro.IdGenero
GO

CREATE PROCEDURE LibroGetById
@IdLibro INT
AS
SELECT Libro.IdLibro,
	Libro.Nombre,
	Libro.IdAutor,
	Autor.Nombre AS AutorNombre,
	Libro.NumeroPaginas,
	Libro.FechaPublicacion,
	Libro.IdEditorial,
	Editorial.Nombre AS EditorialNombre,
	Libro.Edicion,
	Libro.IdGenero,
	Genero.Nombre AS GeneroNombre
FROM Libro
INNER JOIN Autor ON Autor.IdAutor = Libro.IdAutor
INNER JOIN Editorial ON Editorial.IdEditorial = Libro.IdEditorial
INNER JOIN Genero ON Genero.IdGenero = Libro.IdGenero
WHERE IdLibro = @IdLibro
GO

LibroGetById 2

CREATE PROCEDURE AutorGetAll
AS
SELECT IdAutor, Nombre
FROM Autor

CREATE PROCEDURE EditorialGetAll
AS
SELECT IdEditorial, Nombre
FROM Editorial

CREATE PROCEDURE GeneroGetAll
AS
SELECT IdGenero, Nombre
FROM Genero