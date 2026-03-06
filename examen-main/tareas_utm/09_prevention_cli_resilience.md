# 🛡️ blindaje 09: RESILIENCIA DE INTERFAZ (UI CRASH)

## 🎯 PROPÓSITO ARQUITECTÓNICO
Asegurar que la aplicación sea robusta y no se cierre por errores accidentales del usuario (Input Validation). Una aplicación que "explota" por una letra mal puesta es inaceptable.

## 🔍 TRY-PATTERN VS EXCEPTIONS
Lanzar y capturar excepciones es lento y ensucia el flujo. El "Try-Pattern" (`TryParse`) es la forma más eficiente de validar datos.

## 🛠️ REGLAS DE ORO DE INPUT
1.  **Validación Silenciosa:** Intentar convertir el dato. Si falla, mostrar un aviso y volver al menú.
2.  **Null-Coalescing:** Usar `??` para proveer valores por defecto en strings vacíos.
3.  **Visual Feedback:** Notificar al usuario exactamente qué tipo de dato se esperaba.

✅ **CÓDIGO INDESTRUCTIBLE:**
```csharp
if (!int.TryParse(Console.ReadLine(), out int id)) {
    Console.WriteLine("(!) Error: Se esperaba un número.");
    continue;
}
```
