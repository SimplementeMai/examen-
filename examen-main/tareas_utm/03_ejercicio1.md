# TAREA: EJERCICIO 2 - RESTAURANTES Y PERSISTENCIA

## REQUERIMIENTOS TÉCNICOS:
    * **Capa:** Core (Dominio) e Infrastructure (Persistencia)
    * **Objetivo:** Genera el DbContext en la capa de Infrastructure usando EF Core 10. Para este proyecto unificado, se utiliza el proveedor In-Memory para garantizar la carga instantánea (< 3s) y el cumplimiento estricto del límite de 30MB.

    Restricción de infraestructura: El sistema debe permitir la siembra de datos iniciales automática y el registro manual de clientes.

    * **Clase/Interfaz:** Customer.cs, ICustomerRepository (impl. en Program.cs)
    * **Detalle Clave:** Validar Email con 'field' de C# 14, usar Primary Constructors y asegurar compatibilidad con Native AOT mediante mapeo estático.
