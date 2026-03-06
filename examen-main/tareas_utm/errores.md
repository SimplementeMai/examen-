# 📔 BITÁCORA DE ERRORES Y POST-MORTEM (RESUELTO)

## HISTORIAL DE FALLOS DETECTADOS

### 1. Error de Llaves Primarias (InvalidOperationException)
- **Causa:** EF Core no reconoció `IdPedido` como PK por convención.
- **Solución:** Aplicación del atributo `[Key]` y actualización del manual `00_prevention_ef_keys.md`.

### 2. Error de Resolución de Dependencias (get_DbContextDependencies)
- **Causa:** Uso de propiedades calculadas (`=> Set<T>()`) en el DbContext.
- **Solución:** Conversión a propiedades auto-implementadas `{ get; set; }` y actualización del manual `16_prevention_dbcontext_dependencies.md`.

### 3. Advertencia de Nulidad (CS9264)
- **Causa:** Propiedades `string` no inicializadas en el constructor.
- **Solución:** Uso del modificador `required` de C# 14.

### 4. Advertencia de Asincronía (CS8425)
- **Causa:** `CancellationToken` sin decorar en `IAsyncEnumerable`.
- **Solución:** Aplicación del atributo `[EnumeratorCancellation]`.

## ESTADO FINAL: 0 ERRORES / 0 ADVERTENCIAS.
