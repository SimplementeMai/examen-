# TAREA: EJERCICIO 4 - ORQUESTACIÓN Y MENÚ CLI (REVISADO)

## REQUERIMIENTOS TÉCNICOS:
    * **Capa:** API / Consola.
    * **Objetivo:** Crea un menú interactivo en el proyecto unificado 'food'. Configura la Inyección de Dependencias para conectar interfaces con implementaciones de Infraestructura dentro del mismo ensamblado para máximo rendimiento Native AOT.

    * **Captura de Datos:** Solicitar 'Fecha de Inicio' y 'Fecha de Fin' validando con 'DateTime.TryParse'.
    * **Orquestación:** Consumir el caso de uso 'IFetchSalesByFilterUseCase' enviando un objeto 'SaleFilter'.
    * **Restricción de Arquitectura:** Crear un 'IServiceScope' manual dentro del bucle del menú para cada ciclo de ejecución.
