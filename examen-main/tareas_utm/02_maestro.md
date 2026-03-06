# TAREA: EJERCICIO 3 - SISTEMA DE ALERTAS Y EXTENSIONES (REVISADO)

## REQUERIMIENTOS TÉCNICOS:
    * **Capa:** Application (Lógica de Negocio).
    * **Objetivo:** Implementar métodos de extensión estáticos de C# 14 para la entidad `Restaurante` que permitan cálculos inmediatos sin contaminar la entidad pura.
    * **Clase/Interfaz:** Interfaz `ILowStockAlertUseCase` e implementación `LowStockAlertUseCaseImpl`.
    * **Detalle Clave:** 
        * El método de extensión `IsOpen()` debe usar `TimeOnly` y `DateTime.Now`.
        * El caso de uso debe devolver un `IAsyncEnumerable<Product>` para optimización de memoria (Native AOT).
    * **Registro:** Inyección de Dependencias manual en `Program.cs` usando `AddScoped`.
