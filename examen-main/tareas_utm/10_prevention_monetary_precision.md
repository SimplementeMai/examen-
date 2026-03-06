# 🛡️ blindaje 10: PRECISIÓN MONETARIA TOTAL

## 🎯 PROPÓSITO ARQUITECTÓNICO
Eliminar errores de redondeo en cálculos financieros (impuestos, envíos, totales) que pueden causar pérdidas de dinero o inconsistencias legales.

## 🔍 POR QUÉ DECIMAL(19,4)
- **Precisión:** A diferencia de `double` (que es aproximado), `decimal` es exacto.
- **Escala SQL:** Usar 4 decimales en SQL permite cálculos intermedios precisos antes del redondeo final a 2 decimales para el usuario.

## 🛠️ CONFIGURACIÓN DE MAPEO
EF Core necesita saber la precisión exacta para generar la columna correcta en la base de datos o validar el envío de datos.

✅ **CONFIGURACIÓN FLUID API:**
```csharp
modelBuilder.Entity<Pedido>()
    .Property(p => p.CostoEnvio)
    .HasPrecision(19, 4);
```
