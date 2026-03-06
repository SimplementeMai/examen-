# 🛡️ blindaje 00: ESTÁNDAR DE LLAVES EN EF CORE 10

## 🎯 PROPÓSITO ARQUITECTÓNICO
Garantizar la integridad referencial y el mapeo correcto entre el modelo de objetos (C#) y el modelo relacional (SQL). Sin una llave definida, EF Core no puede rastrear cambios ni realizar operaciones de actualización/borrado.

## 🔍 ANÁLISIS DEL FALLO (POST-MORTEM)
El error `InvalidOperationException` surge porque el motor de EF Core utiliza **Convenciones de Naming**. 
- Busca: `Id` o `ClassNameId`.
- Encontró: `IdPedido`.
Al no coincidir, el motor asume que la entidad es "Keyless" (sin llave), lo cual prohíbe la persistencia.

## 🛠️ SOLUCIÓN DE INGENIERÍA
1.  **Decoración Explícita:** Se utiliza el atributo `[Key]` para anular la convención y forzar la identidad.
2.  **Namespace Requerido:** `using System.ComponentModel.DataAnnotations;`
3.  **Impacto en Rendimiento:** Al definir la llave, se habilita el Identity Tracking de EF Core, permitiendo transacciones atómicas.

✅ **CÓDIGO DE GRADO INDUSTRIAL:**
```csharp
public class Pedido {
    [Key] // Obligatorio para nombres personalizados
    public int IdPedido { get; set; }
}
```
