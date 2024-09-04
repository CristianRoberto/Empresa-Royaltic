-- Creacion de  la base de datos para almacenar informacion del sistemas web
CREATE DATABASE TechStoreDB;
-- Seleccionar la base de datos para su uso
USE TechStoreDB;

-------Creacion de tablas para el sistema web
-- Crear la tabla de Categorias
CREATE TABLE Categorias (
    CategoriasID INT PRIMARY KEY IDENTITY(1,1),  -- Identificador único para la catería
    Nombre NVARCHAR(100) NOT NULL,              -- Nombre de la catería
    Descripcion NVARCHAR(255),                  -- Descripción de la catería
    Estado BIT NOT NULL DEFAULT 1,              -- Estado activo/inactivo de la catería
    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(), -- Fecha de creación de la catería
    FechaActualizacion DATETIME NULL            -- Fecha de última actualización de la catería
);
-- Crear la tabla de Productos
CREATE TABLE Productos (
    ProductoID INT PRIMARY KEY IDENTITY(1,1),   -- Identificador único para el producto
    Nombre NVARCHAR(100) NOT NULL,              -- Nombre del producto
    Descripcion NVARCHAR(255),                  -- Descripción del producto
    Precio DECIMAL(10, 2) NOT NULL,             -- Precio del producto
    Stock INT NOT NULL,                         -- Cantidad en inventario
    SKU NVARCHAR(50) UNIQUE NOT NULL,           -- Códi único de identificación del producto (Stock Keeping Unit)
    Proveedor NVARCHAR(100),                    -- Proveedor del producto
    FechaIngreso DATETIME NOT NULL DEFAULT GETDATE(), -- Fecha de ingreso del producto
    Estado BIT NOT NULL DEFAULT 1,              -- Estado activo/inactivo del producto
    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(), -- Fecha de creación del producto
    FechaActualizacion DATETIME NULL            -- Fecha de última actualización del producto
);
-- Crear la tabla de ProductosXCaterias para la relación muchos a muchos
CREATE TABLE ProductosXcateria (
    ProductoID INT NOT NULL,                    -- Clave foránea a la tabla Productos
    CategoriasID INT NOT NULL,                   -- Clave foránea a la tabla Caterias
    PRIMARY KEY (ProductoID, CategoriasID),      -- Clave primaria compuesta por ProductoID y CateriaID
    FechaAsignacion DATETIME NOT NULL DEFAULT GETDATE(), -- Fecha de asignación del producto a la catería
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID) ON DELETE CASCADE,
    FOREIGN KEY (CategoriasID) REFERENCES Categorias(CategoriasID) ON DELETE CASCADE
);
---------------------
--Inserciones a las  tablas para tener datos almacenados---
-- Insertar dos registros en la tabla Caterias
INSERT INTO Categorias (Nombre, Descripcion, Estado, FechaActualizacion)
VALUES 
('Electrónica', 'Dispositivos electrónicos y gadgets', 1, GETDATE()),
('Computadoras', 'PCs, laptops, y accesorios de computación', 1, GETDATE());
-- Insertar dos registros en la tabla Productos
INSERT INTO Productos (Nombre, Descripcion, Precio, Stock, SKU, Proveedor, Estado, FechaActualizacion)
VALUES 
('Smartphone XYZ', 'Smartphone de última generación con pantalla AMOLED', 599.99, 50, 'SM-XYZ-002', 'ProveedorTech', 1, GETDATE()),
('Laptop ABC', 'Laptop ligera con procesador de alta velocidad', 999.99, 30, 'LT-ABC-003', 'CompuWorld', 1, GETDATE());
-- Insertar registros en la tabla ProductosXCaterias
-- Asociar el 'Smartphone XYZ' con la catería 'Electrónica'
INSERT INTO ProductosXcateria (ProductoID, CategoriasID, FechaAsignacion)
VALUES (1, 1, GETDATE());
-- Asociar la 'Laptop ABC' con la catería 'Computadoras'
INSERT INTO ProductosXcateria (ProductoID, CategoriasID, FechaAsignacion)
VALUES (2, 2, GETDATE());
-- Asociar el 'Smartphone XYZ' con la catería 'Computadoras' (ejemplo de producto en múltiples Categorias)
INSERT INTO ProductosXcateria (ProductoID, CategoriasID, FechaAsignacion)
VALUES (1, 2, GETDATE());


---------Selecion y muestra de tablas
select * from Categorias
select * from Productos
select * from ProductosXcateria






