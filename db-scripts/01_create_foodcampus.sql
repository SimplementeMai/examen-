/* 
 * SQL SCRIPT: FOODCAMPUS - DDL & DML (REVISADO)
 * DATABASE: FoodCampus_nwn
 * RESTRICTION: Max 15 Restaurants (Somee compatibility)
 */

SET NOCOUNT ON;
SET XACT_ABORT ON;

USE [Mai_nwn];
GO

-- 1. DDL: Tablas Base
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Restaurantes]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Restaurantes](
        [Id] INT IDENTITY(1,1) PRIMARY KEY,
        [Nombre] NVARCHAR(100) NOT NULL,
        [Especialidad] NVARCHAR(50),
        [HorarioApertura] TIME NOT NULL,
        [HorarioCierre] TIME NOT NULL
    );
END

-- 2. DML: Datos Semilla (Exactamente 15 Restaurantes)
IF (SELECT COUNT(*) FROM [dbo].[Restaurantes]) = 0
BEGIN
    INSERT INTO [dbo].[Restaurantes] (Nombre, Especialidad, HorarioApertura, HorarioCierre)
    VALUES 
    ('Tacos La UTM', 'Tacos', '08:00', '16:00'),
    ('Burger Campus', 'Hamburguesas', '10:00', '20:00'),
    ('Pizza Universitaria', 'Pizza', '11:00', '21:00'),
    ('Comedor Central', 'Comida Corrida', '12:00', '16:00'),
    ('Sub UTM', 'Subway', '09:00', '18:00'),
    ('Sushi Dragon', 'Sushi', '12:00', '22:00'),
    ('Lonches El Inge', 'Lonches', '07:00', '14:00'),
    ('Cafe Búho', 'Cafetería', '07:00', '21:00'),
    ('Ensaladas Fresh', 'Ensaladas', '10:00', '18:00'),
    ('Pollo Express', 'Pollo Asado', '11:00', '17:00'),
    ('Tortas El Paso', 'Tortas', '08:00', '20:00'),
    ('Bowl UTM', 'Comida Asiática', '12:00', '19:00'),
    ('Donas & Coffee', 'Repostería', '08:00', '20:00'),
    ('Chilaquiles Master', 'Desayunos', '07:30', '13:00'),
    ('Jugos Naturales', 'Bebidas', '07:00', '15:00');
    PRINT '15 Restaurantes insertados correctamente.';
END
GO
