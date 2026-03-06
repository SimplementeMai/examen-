# 🤖 DIRECTIVA TÉCNICA DE RECONSTRUCCIÓN: FOODCAMPUS (MASTER GUIDE)

Para formar la aplicación desde cero con éxito total y cero errores, Gemini CLI **DEBE** procesar estos 23 archivos en el orden estricto indicado. **NO IGNORES NINGUNO.**

## 📁 BLOQUE 1: REGLAS Y CONTEXTO (VISIÓN OPERATIVA)
Antes de generar código, asimila las leyes del proyecto:
1.  **Reglas.md**: Normas de comportamiento, estructura y estándares C# 14.
2.  **contexto.md**: Visión estratégica y stack tecnológico definitivo.
3.  **resolución.md**: Historial de decisiones y migración a arquitectura unificada.
4.  **errores.md**: Bitácora de fallos resueltos (Lectura crítica para no repetirlos).

## 🛡️ BLOQUE 2: ENCICLOPEDIA DE PREVENCIÓN (BLINDAJE TÉCNICO)
Lectura obligatoria para asegurar la calidad del código generado:
- **00_prevention_ef_keys.md**: Prevención de fallos en llaves primarias.
- **16_prevention_dbcontext_dependencies.md**: Prevención de fallos de DI en DbContext.
- **17_prevention_view_ux_cli.md**: Estándar de diseño visual Premium.
- **06_prevention_aot_reflection.md**: Compatibilidad con Native AOT.
- **07_prevention_streaming_perf.md**: Uso de IAsyncEnumerable para rendimiento.
- **08_prevention_di_scopes.md**: Manejo del ciclo de vida de servicios (Scopes).
- **09_prevention_cli_resilience.md**: Validación de input con Try-Pattern.
- **10_prevention_monetary_precision.md**: Manejo de Decimal(19,4) para finanzas.
- **11_prevention_storage_limits.md**: Optimización para el límite de 30MB.
- **12_prevention_csharp14_field.md**: Uso correcto de la palabra clave 'field'.
- **13_prevention_sql_injection.md**: Seguridad en comandos SQL manuales.
- **14_prevention_secrets_leaks.md**: Gestión segura de secretos y Zero Trust.
- **15_prevention_layer_leaks.md**: Aislamiento de capas en arquitectura limpia.

## 💾 BLOQUE 3: PERSISTENCIA Y PROMPTS (DEFINICIÓN DE DATOS)
Configuración de la base de datos y mapeo:
1.  **db-scripts/01_create_foodcampus.sql**: Estructura DDL de tablas.
2.  **db-scripts/02_seed_data_utm_market.sql**: Carga de 250 productos.
3.  **prompts/03_aot_repository_prompt.md**: Lógica de mapeo manual Native AOT.

## 📋 BLOQUE 4: IMPLEMENTACIÓN (ORDEN DE TAREAS)
Secuencia de reconstrucción del archivo `/food/Program.cs`:
1.  **04_restaurantes.md**: Creación del proyecto y arquitectura unificada.
2.  **01_va.md**: Implementación de entidades de dominio.
3.  **03_ejercicio1.md**: Implementación de persistencia y clientes.
4.  **02_maestro.md**: Lógica de negocio avanzada y alertas.
5.  **05_ejercicio3.md**: Orquestación del Menú CLI final y reportes.

**EL CUMPLIMIENTO DE ESTA GUÍA ES EL ÚNICO CAMINO AL ÉXITO.**
`cd food` -> `dotnet run`
