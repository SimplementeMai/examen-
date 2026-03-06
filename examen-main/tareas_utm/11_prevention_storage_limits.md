# 🛡️ blindaje 11: LÍMITES DE ALMACENAMIENTO (SPACE QUOTA)

## 🎯 PROPÓSITO ARQUITECTÓNICO
Garantizar que la aplicación funcione dentro de restricciones físicas estrictas (como los 30MB de Somee.com o bases de datos embebidas).

## 🔍 TÉCNICAS DE AHORRO DE ESPACIO
1.  **AsNoTracking:** Para consultas de "solo lectura" (menús, reportes), le dice a EF Core: "no guardes una copia de este objeto en RAM". Ahorra CPU y memoria.
2.  **Varchar vs Nvarchar:**
    - `VARCHAR`: 1 byte por carácter. Ideal para Folios, SKUs y códigos ASCII.
    - `NVARCHAR`: 2 bytes por carácter. Solo para nombres que requieran acentos o emojis.
3.  **Seeding Inteligente:** No llenar la base de datos con basura. Insertar solo lo necesario para validar la funcionalidad.

✅ **CONSULTA OPTIMIZADA:**
```csharp
var list = await db.Products.AsNoTracking().ToListAsync();
```
