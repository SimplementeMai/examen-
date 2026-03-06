# 📔 Registro de Cambios - Arquitectura UTM Market

## [FASE 1] SQL/SERVER-ARCHITECT - 2026-03-05
... (contenido previo)

## [FASE 2] SQL/MIX PRODUCTS - 2026-03-05
### Cambios Realizados:
- Actualización de `db-scripts/01_create_foodcampus.sql` para incluir 15 restaurantes base (cumpliendo Ejercicio 2).
- Creación de `db-scripts/02_seed_data_utm_market.sql` con 250 productos simulados para el marketplace.

### Detalles Técnicos:
- **Transaccionalidad:** Uso de `BEGIN TRANSACTION` y `TRY...CATCH` para asegurar integridad.
- **Limpieza:** Implementación de `TRUNCATE` y `DBCC CHECKIDENT` para reinicio de catálogos.
- **Categorización:** Mix de Abarrotes, Bebidas y Limpieza con SKUs EAN-13.

### Razón:
Cumplir con los requerimientos de datos semilla para pruebas de carga y visualización en el menú CLI.

