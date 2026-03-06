# ⚖️ REGLAS MAESTRAS DEL PROYECTO (CONSOLIDADO)

## 🏗️ SECCIÓN 1: PROTOCOLO DE OPERACIÓN (ORIGINAL)
1. LAS MODIFICACIONES PUEDEN ALTERAR EL ALTORNO CONOCIDO TOTAL, SIN EMBARGO EL EFECTO DEL CODIGO DEBERA SER EL DESEADO TRAS FINALIZAR, POR ESTO MISMO, TODO CAMBIO REALIZADO DEBE SER PRIMERO ESCRITO EN LA TERMINAL PARA SER ANALIZADO TANTO POR EL USUARIO COMO POR VOS, ADICIONALMENTE SE ANALIZARAN ASPECTOS CLAVE EN RELACION CON PREGUNTAS (
    - ¿Es grande y requiere de un apartado individual? 
    - ¿El lógico? 
    - ¿Tiene el efecto esperado ó será complementado con alguna otra implementación inmediata? 
    - ¿AFECTA A OTRA ÁREA? 
    - ¿Existe alguna alternativa no considerada para su elaboración y que pueda permitir la existencia del área planteada pero en una escala mejorada u optimizada?
    Todas estas deben ser las preguntas realizadas en la terminal QUE YO TAMBIÉN JUNTO CONTIGO DEBO RESPONDER) REALIZADAS EN LA TERMINAL; UNA VEZ QUE LA PRUEBA DE POR RESULTADO UN EVENTO SEGURO PODRA SER IMPLEMENTADO ASEGURANDO UNA CONEXIÓN LOGICA Y PROFESIONAL EN CADA MINIMA MODICIFACIÓN. EL CAMBIO DEBERA SER REGISTRADO EN EN ARCHIVO DE TIPO MD QUE INFORME DE FORMA BREVE Y CLARA QUE SE HIZO, COMO SE HIZO Y LA RAZÓN POR LA QUE SE EJECUTO EL CAMBIO.

2. TODA SECCIÓN DEL CODIGO QUE REQUIERA DE MODIFICACIONES QUE AFECTEN AL ENTORNO EN SU TOTALIDAD DEBE Y SERÁ COLOCADO EN UN APARTADO EXCLUSIVO QUE AYUDARÁ EN SU POSTERIOR TRATO SIN AFECTAR AL RESTO DEL ENTORNO DE OCURRIR ALGUN FALLO. ESTO PERMITIRÁ UN TRATO AISLADO Y POR CONSIGUIENTE SIN RIESGOS; POR CONSIGUIENTE DEBERÁS ASEGURARTE DE REALIZAR LAS RESPECTIVAS CONEXIONES.

3. CADA MODICICACIÓN REALIZADA EN CONJUNTO DEBE Y AFECTARÁ UNICAMENTE LAS ÁREAS SEÑALADAS POR LO QUE DEBES SER SUMAMENTE CLARO AL MOMENTO DE EXPLICAR PROPUESTAS Y MEJORAS, DEBIDO A QUE SI AQUELLA MEJORA- MODIFICA ASPECTOS DE OTRA Ó NO ERA LO PLANEADO, SERÁ CONSIDERADO UN ERROR QUE PODRIA VER UNA REPERCUCIÓN EN NUESTRO RENDIMIENTO COLABORATIVO.

4. CADA CAMBIO ENORME CON EL QUE SEA EVIDENTE EL SURGIMIENTO DE UN ERROR FATAL DEBERÁ DE SER INFORMADO PARA QUE YO, NO TÚ, YO PUEDA REALIZAR MANUALMENTE UNA COPIA DE SEGURIDAD DEL ARCHIVO. DEBERÁS ESPERAR MI CONFIRMACIÓN ANTES DE PROCEDER, NO AVANZARÁS A MENOS QUE YO PERSONALMENTE TE INDIQUE QUE REALICE LA COPIA DE SEGURIDAD Y QUE PUEDES CONTINUAR.

5. SIEMPRE SE PROCURA EL ENLACE LÓGICO DE LOS DATOS AUN A INTERIOR DE CADA CARPETA Y SUBCARPETA.

6. ANALIZA UNA POSIBLE SOLUCIÓN/RESPUESTA EN INGLES Y RESPONDE EN ESPAÑOL.

7. SI ES LA PRIMERA VEZ QUE LEES EL CONTEXTO DEL PROYECTO JAMAS DEBES ASUMIR QUE LAS COSAS YA ESTAN, VERIFICA LO QUE ESTA Y NO, ANALIZA EL CONTEXTO Y DETERMINA EN BASE AL CODIGO CONJUNTO DEL CONTEXTO DE ELEMENTOS DE CADA FASE, LA FASE ACTUAL EN EL QUE SE ENCUENTRA EL PROYECTO EN DESARROLLO. JAMÁS OLVIDES UN DETALLE TAN ESENCIAL.

8. EL DESARROLLO EN RELACIÓN CON EL LENGUAJE DE C# DEBERA DE SER IMPLEMENTADO EN EL ARCHIVO DE TIPO C# QUE YO TE MENCIONE- SI ES QUE NO EXISTE ALGUNO INFORMAME Y YO LO CREARÉ.

---

## 🏛️ SECCIÓN 2: CONDICIONES DE ESTRUCTURA
La raiz del repositorio debe contener exactamente estas 3 carpetas:
- **/db-scripts:** Archivos .sql para creación (DDL) e inserción (DML).
- **/prompts:** Archivos de texto con los prompts exactos utilizados.
- **/src:** Contiene los proyectos de la solución .NET (Domain, Application, Infrastructure, API).
*Nota: Para optimización de rendimiento, se permite la consolidación en /food manteniendo el aislamiento lógico.*

---

## ⚖️ SECCIÓN 3: REGLAS DE ORO DEL ARQUITECTO (COMPLEMENTO SENIOR)
Para mantener la excelencia, se añaden estos blindajes técnicos:
1. **Invarianza de Datos:** Nunca permitas que un objeto nazca incompleto. Uso obligatorio de `required` y `[Key]` para identidades.
2. **Validación Atómica:** Las reglas de negocio (ej: no stocks negativos) viven en los setters de la entidad vía `field`, no en la UI.
3. **Asincronía Total:** Prohibido el uso de métodos síncronos. Usa `IAsyncEnumerable` con `[EnumeratorCancellation]`.
4. **Eficiencia de Recursos:** Siempre limpia la memoria matando procesos colgados (`taskkill`) antes de compilar.
5. **Principio de Menor Privilegio:** Consultas de lectura siempre con `.AsNoTracking()`.
6. **Zero Secrets:** Ni una sola contraseña debe tocar el código fuente.

---

## 💻 SECCIÓN 4: REQUISITOS TÉCNICOS C# 14
- **Palabra clave field:** Utilizada en setters para validar reglas de negocio de manera limpia sin campos de respaldo privados explícitos.
- **Miembros de extensión:** Implementar propiedades/métodos de extensión para cálculos derivados (ej: `IsOpen` en Restaurante).

---

## 🎨 SECCIÓN 5: UI Y RESILIENCIA
- **Robustez:** La aplicación no debe cerrarse por excepciones de formato o fallas de conexión.
- **Flujos seguros:** Implementar `TryParse` y capturar excepciones con mensajes amigables en color rojo.
- **Diseño Premium:** Uso de tablas formateadas y tickets detallados para toda visualización de datos.

---

## 📜 SECCIÓN 6: INGENIERÍA DE PROMPTS
Cada elemento del sistema debe tener un prompt estructurado (con contexto y restricciones) en la carpeta `/prompts`:
- Scripts SQL (Creación y Dummy).
- Objetos de Dominio (uso de field).
- Mappers y Transformadores.
- Interfaces de Repositorios y Casos de Uso.
- Menú de capa de presentación (DI y captura defensiva).
