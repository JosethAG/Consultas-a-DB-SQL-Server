-- Crear la base de datos
CREATE DATABASE UsersDB;
GO

-- Usar la base de datos
USE UsersDB;
GO

-- Crear la tabla Users
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Email NVARCHAR(100),
    BirthDate DATE,
    City NVARCHAR(50),
    Country NVARCHAR(50)
);
GO

-- Insertar registros de ejemplo
INSERT INTO Users (FirstName, LastName, Email, BirthDate, City, Country) VALUES
('Juan', 'Pérez', 'juan.perez@example.com', '1985-04-23', 'Ciudad de México', 'México'),
('Ana', 'García', 'ana.garcia@example.com', '1990-11-15', 'Madrid', 'España'),
('Luis', 'Martínez', 'luis.martinez@example.com', '1982-08-30', 'Buenos Aires', 'Argentina'),
('María', 'López', 'maria.lopez@example.com', '1978-03-12', 'Lima', 'Perú'),
('Carlos', 'González', 'carlos.gonzalez@example.com', '1995-06-07', 'Bogotá', 'Colombia'),
('Sofía', 'Rodríguez', 'sofia.rodriguez@example.com', '2000-12-01', 'Santiago', 'Chile'),
('David', 'Fernández', 'david.fernandez@example.com', '1992-07-21', 'Caracas', 'Venezuela'),
('Laura', 'Martín', 'laura.martin@example.com', '1988-10-05', 'Quito', 'Ecuador'),
('Miguel', 'Hernández', 'miguel.hernandez@example.com', '1975-09-14', 'La Paz', 'Bolivia'),
('Elena', 'Díaz', 'elena.diaz@example.com', '1983-01-22', 'Asunción', 'Paraguay');
GO

-- Crear el procedimiento almacenado para listar users
CREATE PROCEDURE ListUsers
AS
BEGIN
    -- Seleccionar todos los registros de la tabla Users
    SELECT UserID, FirstName, LastName, Email, BirthDate, City, Country
    FROM Users
END;
GO
