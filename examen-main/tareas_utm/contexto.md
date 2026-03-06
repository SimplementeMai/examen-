# 📄 CONTEXTO ESTRATÉGICO: PROYECTO FOODCAMPUS (MASTER)

## 🏢 VISIÓN EMPRESARIAL
Este sistema es el núcleo de operaciones para la red de alimentos de la UTM. Su diseño prioriza la **Escalabilidad** y el **Rendimiento Extremo**, asegurando que la gestión de miles de transacciones diarias no sature los recursos del campus.

## 🏗️ PILARES DE LA ARQUITECTURA
1.  **Unified Resilient Architecture:** Consolidación del núcleo lógico en un ensamblado único para maximizar la velocidad de carga Native AOT.
2.  **Domain-Driven Design (Lite):** Entidades ricas con validaciones integradas (`field`, `required`).
3.  **Zero-Latency Persistence:** Uso de EF Core 10 con estrategias de caché y `AsNoTracking` para respuesta instantánea.

## 🎯 OBJETIVOS TÉCNICOS ALCANZADOS
- **Arranque:** < 500ms mediante optimización de ensamblados.
- **Seguridad:** Protección nativa contra inyecciones y fugas de datos.
- **Portabilidad:** Sistema auto-contenido capaz de ejecutarse en entornos con memoria limitada (30MB).
