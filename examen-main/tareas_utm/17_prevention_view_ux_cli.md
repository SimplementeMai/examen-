# 🛡️ blindaje 17: ESTÁNDAR VISUAL PREMIUM (UX CLI)

## 🎯 PROPÓSITO ARQUITECTÓNICO
Transformar una aplicación de consola rudimentaria en una herramienta de grado profesional. La legibilidad de los datos reduce el error humano y aumenta la confianza del usuario final.

## 📐 REGLAS DE DISEÑO UI/UX
1.  **Box Drawing (Unicode):** Uso de caracteres `╔ ═ ╗ ║ ╚` para crear una jerarquía visual clara.
2.  **Alineación de Tablas:** Uso de interpolación con formato de ancho fijo (`{valor,-20}`) para asegurar que las columnas no bailen al cambiar los datos.
3.  **Feedback Semántico de Colores:**
    - **Cyan:** Navegación y Títulos.
    - **Verde:** Estados activos o éxito.
    - **Rojo:** Errores críticos.
    - **Gris Oscuro:** Estados inactivos o información secundaria.

## 📑 COMPONENTE DE TICKET (MAESTRO-DETALLE)
Para reportes de ventas, se debe usar el formato de "Factura Visual" que agrupe los detalles bajo un encabezado único, mejorando la comprensión de la transacción.

✅ **EJEMPLO DE SALIDA ESPERADA:**
```text
╔══════════════════════════════════════╗
║ ID | PRODUCTO             | PRECIO   ║
╟──────────────────────────────────────╢
║ 1  | Tacos al Pastor      | $45.00   ║
╚══════════════════════════════════════╝
```
