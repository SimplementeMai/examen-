# 🛡️ blindaje 16: RESOLUCIÓN DE DEPENDENCIAS EN DBCONTEXT

## 🎯 PROPÓSITO ARQUITECTÓNICO
Asegurar que el ciclo de vida del `DbContext` sea compatible con el contenedor de Inyección de Dependencias (DI) de Microsoft, evitando bloqueos en el hilo principal durante la inicialización.

## 🔍 DETALLE TÉCNICO DEL CONFLICTO
EF Core 10 requiere que las colecciones `DbSet` estén disponibles inmediatamente tras la construcción del objeto. El uso de expresiones lambda (`=> Set<T>()`) causa que:
1. El compilador intente resolver el set en cada acceso.
2. Si el proveedor de servicios está ocupado, se genera un interbloqueo (Deadlock) en `get_DbContextDependencies()`.

## 🛠️ ESTÁNDAR DE IMPLEMENTACIÓN
- **Propiedades Automáticas:** Usa `{ get; set; } = null!;`. El valor `null!` (null-forgiving operator) le dice al compilador que EF Core se encargará de inicializar la propiedad vía reflexión al arrancar.
- **Dependency Scoping:** El `DbContext` debe ser siempre `Scoped`. Nunca lo resuelvas como `Singleton`.

✅ **ESTRUCTURA CORRECTA:**
```csharp
public class FoodDbContext(DbContextOptions<FoodDbContext> options) : DbContext(options) {
    public DbSet<Restaurante> Restaurantes { get; set; } = null!;
}
```
