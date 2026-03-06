# 🛡️ blindaje 12: LÓGICA EN SETTERS (C# 14 FIELD)

## 🎯 PROPÓSITO ARQUITECTÓNICO
Encapsular las reglas de negocio directamente en las entidades de dominio, evitando que el sistema entre en un estado inválido (ej: costos negativos).

## 🔍 INNOVACIÓN DE C# 14: KEYWORD FIELD
Anteriormente, para validar un setter necesitábamos un campo privado manual (backing field). C# 14 introduce `field`, que permite:
1.  **Código Limpio:** Reduce el ruido visual al eliminar variables privadas extras.
2.  **Seguridad:** Previene el error común de llamar a la propiedad dentro de su propio setter, lo cual causaba un `StackOverflowException`.

## 🛠️ REGLA DE IMPLEMENTACIÓN
Toda validación debe ser atómica y lanzar excepciones claras si no se cumple la regla de negocio.

✅ **IMPLEMENTACIÓN SENIOR:**
```csharp
public decimal Costo { 
    get; 
    set => field = value >= 0 ? value : throw new Exception("No negativo"); 
}
```
