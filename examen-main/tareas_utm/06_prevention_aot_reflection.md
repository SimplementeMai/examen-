# 🛡️ blindaje 06: COMPATIBILIDAD NATIVE AOT (REFLEXIÓN)

## 🎯 PROPÓSITO ARQUITECTÓNICO
Permitir que la aplicación se compile a código máquina nativo (AOT) para un arranque instantáneo y consumo de RAM mínimo (ideal para contenedores y microservicios).

## 🔍 EL ENEMIGO: REFLEXIÓN DINÁMICA
Native AOT elimina el código que no se usa. La reflexión (ej: `typeof(T).GetProperties()`) intenta usar código que el compilador no puede predecir, causando fallos en tiempo de ejecución.

## 🛠️ ESTRATEGIA DE SUPERVIVENCIA
1.  **Mapeo Manual:** Asignar columnas de `SqlDataReader` a propiedades manualmente. Es más código, pero es 100% seguro para AOT.
2.  **No Dynamic:** El uso de `dynamic` está terminantemente prohibido.
3.  **Source Generators:** Preferir generadores de código que trabajen en tiempo de compilación.

✅ **EJEMPLO AOT-READY:**
```csharp
// Mapeo estático sin reflexión
var p = new Product {
    Id = reader.GetInt32(0),
    Nombre = reader.GetString(1)
};
```
