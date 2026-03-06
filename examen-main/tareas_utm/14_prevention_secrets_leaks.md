# 🛡️ blindaje 14: GESTIÓN DE SECRETOS Y ZERO TRUST

## 🎯 PROPÓSITO ARQUITECTÓNICO
Implementar una cultura de "Confianza Cero" (Zero Trust) donde las credenciales de base de datos nunca viajan en el código fuente, evitando filtraciones masivas si el repositorio cae en manos equivocadas.

## 🔍 EL PELIGRO DE Git
Subir un archivo `appsettings.json` con una contraseña real a un repositorio es un error fatal. Los bots de escaneo detectan estas cadenas en segundos.

## 🛠️ ESTRATEGIA DE PROTECCIÓN
1.  **User Secrets:** En desarrollo, usa el comando `dotnet user-secrets`. Esto guarda la contraseña en una carpeta local de tu usuario, fuera del proyecto.
2.  **Environment Variables:** En producción, usa variables de entorno configuradas en el servidor.
3.  **Placeholders:** Los archivos de configuración en Git solo deben tener ejemplos vacíos (ej: `Server=...;Database=...;`).

✅ **COMANDO DE PROTECCIÓN:**
`dotnet user-secrets set "ConnectionStrings:Default" "MiContraseñaReal"`
