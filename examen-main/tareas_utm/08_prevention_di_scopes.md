# 🛡️ blindaje 08: CICLO DE VIDA DE SERVICIOS (DI SCOPES)

## 🎯 PROPÓSITO ARQUITECTÓNICO
Gestionar correctamente la memoria y las conexiones a base de datos en aplicaciones de larga duración (como un menú CLI infinito).

## 🔍 EL RIESGO DEL "DbContext Cansado"
Si usas un solo `DbContext` para toda la vida del programa:
1. La caché interna crece hasta agotar la RAM.
2. La conexión puede cerrarse por timeout.
3. Errores en una venta pueden contaminar la siguiente.

## 🛠️ PATRÓN DE SCOPE MANUAL
En aplicaciones CLI, el contenedor de dependencias no sabe cuándo termina una "petición web". Debemos simularlo:
1.  Crear un `IServiceScope` al inicio de cada opción del menú.
2.  Extraer los servicios necesarios.
3.  Cerrar el scope (usando `using`) para liberar la base de datos inmediatamente.

✅ **IMPLEMENTACIÓN PROFESIONAL:**
```csharp
while(running) {
    using var scope = host.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<FoodDbContext>();
    // ... realizar operación y liberar al salir del bloque
}
```
