# 🛡️ blindaje 13: SEGURIDAD Y PREVENCIÓN DE INYECCIÓN SQL

## 🎯 PROPÓSITO ARQUITECTÓNICO
Blindar la base de datos contra ataques de manipulación de comandos (SQL Injection) que podrían filtrar datos de clientes o destruir el catálogo de productos.

## 🔍 EL RIESGO DE LA CONCATENACIÓN
Nunca debes construir un comando SQL pegando strings directamente (ej: `"WHERE Id = " + userInput`). Un atacante podría escribir `' OR 1=1 --'` y acceder a toda la información.

## 🛠️ DEFENSA MEDIANTE PARÁMETROS
EF Core ya maneja esto automáticamente, pero en el mapeo manual para Native AOT (ADO.NET), **ES OBLIGATORIO** usar la colección `Parameters`.
1.  **Define placeholders:** Usa `@nombre` en tu Query.
2.  **Mapea valores:** Usa `cmd.Parameters.AddWithValue()`. El motor de SQL tratará el valor como un dato simple, no como código ejecutable.

✅ **CÓDIGO SEGURO:**
```csharp
var cmd = new SqlCommand("SELECT * FROM Customers WHERE Email = @email", conn);
cmd.Parameters.AddWithValue("@email", userInput);
```
