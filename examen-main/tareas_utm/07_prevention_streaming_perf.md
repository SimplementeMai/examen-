# 🛡️ blindaje 07: RENDIMIENTO Y STREAMING (IASYNCENUMERABLE)

## 🎯 PROPÓSITO ARQUITECTÓNICO
Optimizar el consumo de memoria en aplicaciones que manejan catálogos extensos (como los 250 productos de UTM Market), permitiendo el procesamiento de datos mientras se descargan de la base de datos.

## 🔍 FLUJO DE DATOS (STREAMING)
A diferencia de `Task<List<T>>`, que bloquea el hilo hasta tener TODA la lista en memoria, `IAsyncEnumerable<T>` entrega los objetos uno por uno.
- **Beneficio AOT:** Menor presión sobre el Garbage Collector.
- **Beneficio UX:** El usuario ve los primeros resultados instantáneamente.

## 🛠️ PROTOCOLO DE USO
1.  **EnumeratorCancellation:** Obligatorio para permitir que el sistema detenga la descarga si el usuario cierra la pantalla.
2.  **Yield Return:** Técnica para "pausar" el método y entregar un valor sin cerrar la conexión.

✅ **PATRÓN DE ALTO RENDIMIENTO:**
```csharp
public async IAsyncEnumerable<Product> Get([EnumeratorCancellation] CancellationToken ct) {
    await foreach(var p in db.Products.AsAsyncEnumerable()) yield return p;
}
```
