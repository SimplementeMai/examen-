# TAREA: EJERCICIO 2 - CATALOGO UNIFICADO (C# 14 / .NET 10)

Contexto de actividad.

    "Actúa como un arquitecto experto en .NET. Crea una solución llamada 'food' siguiendo los principios de 'Unified Resilient Architecture'. Debido a requerimientos de alto rendimiento y carga instantánea, la solución se consolida en un único proyecto ejecutable en la carpeta /food que contiene:
        * Domain: Entidades puras en el mismo namespace (Restaurante, Pedido, Product, Customer).
        * Application: Casos de uso e interfaces definidos internamente.
        * Infrastructure: EF Core 10 In-Memory para persistencia rápida y cumplimiento de límites de 30MB.
        * API (Console): Menú interactivo con Inyección de Dependencias manual y manejo de excepciones robusto.
            Restricción crítica: Todo el código debe estar optimizado para Native AOT y evitar la reflexión lenta."