# 🛡️ blindaje 15: LÍMITES DE CAPA (LAYER LEAKS)

## 🎯 PROPÓSITO ARQUITECTÓNICO
Mantener la "Pureza de Capas" de la Arquitectura Limpia. Si la UI sabe cómo funciona la base de datos, el sistema se vuelve rígido y difícil de cambiar.

## 🔍 EL CONCEPTO DE DESACOPLAMIENTO
La capa de **API (Consola)** no debe tener ni un solo `using Microsoft.EntityFrameworkCore;`. Si lo tiene, significa que la infraestructura se está "filtrando" a la presentación.

## 🛠️ REGLAS DE AISLAMIENTO
1.  **Interfaces como Puentes:** La UI solo interactúa con Interfaces (ej: `IUseCase`).
2.  **No SQL en el Menú:** Está terminantemente prohibido escribir lógica de base de datos dentro del `switch` principal. Todo debe estar encapsulado en un Caso de Uso.
3.  **DTOs vs Entities:** Para reportes complejos, usa objetos de transferencia de datos (DTOs) en lugar de enviar la entidad de base de datos directamente a la consola.

✅ **FLUJO CORRECTO:**
`Menú CLI` -> `Interfaz de Caso de Uso` -> `Implementación de Infraestructura`.
