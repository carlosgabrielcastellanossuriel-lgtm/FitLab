Sistema de Gestión Gimnasio FITLAB

Cómo correr la aplicación:
1. Extraer la carpeta comprimida.
2. Abrir la solución en Visual Studio.
3. Presionar 'F5' o ejecutar el comando 'dotnet run' en la terminal.
4. Utilizar el teclado para navegar por el menú de la consola.

====================================================================================================================================================

							Mapa de Clases Principales:
Program: Acá es donde está mi menú de consola.
Gestor: Aquí está casi toda la lógica del sistema de gestión, tenemos las listas y métodos que almacenan la información.
Clientes, Estudiantes, Premium: Las clases que definen el comportamiento de cada cliente(con descuentos diferentes).
Membresias, Membresia_mensual, Membresia_trimestral, Membresia_anual: Clases que almacenan todos los datos y comportamiento de nuestras membresías.
Pagos: Esta clase gestiona los pagos, los registra y modifica directamente el comportamiento de las membresías.
Excepciones: Actualmente, en esta clase solo hay una excepción, la cual se utiliza para manejar errores de buscado de IDs.
Interfaces: Acá tenemos dos contratos(interfaces), los cuales mis clases principales tienen que seguir.

====================================================================================================================================================

							Evidencia de Principios SOLID aplicados

1. SRP (Principio de Responsabilidad Única): Donde más claro queda la aplicación de este principio, es en mi clase principal (Program.cs). Aquí vemos que esta se encarga solamente de gestionar la consola.

2. OCP (Principio de Abierto/Cerrado): Este principio queda aplicado sobre todo en la clase Membresías, la cual es una clase abstracta. Si en un futuro se quisiera agregar otro tipo de membresía, solo habría que crear otra clase que herede de la clase Membresia, sin afectar el código.

3. LSP (Principio de Sustitución de Liskov): Este principio queda evidenciado en todas las jerarquías del sistema. Un ejemplo claro es el constructor de la clase Pagos, donde hay polimorfismo al pedir Membresia(padre) y poder recibir Membresia_mensual(hija). 

4. ISP (Principio de Segregación de Interfaces): Esto se evidencia en nuestra clase interfaces, donde vemos que tenemos interfaces superdirectas.

5. DIP (Principio de Inversión de Dependencias): Se podría evidenciar este principio en mi clase Gestor(una clase de alto nivel) tenemos una lista la cual usa polimorfismo List<Membresias> esto hace que la clase de alto nivel no depende de si la lista es List<Membresia_mensual> o List<Membresia_anual>.

====================================================================================================================================================

FITLAB - Asignación 2: Refactorización con Patrones de Diseño

Patrones Aplicados:

1. Singleton: Implementado en la clase Logger (ubicada en la carpeta Patterns). Resuelve el problema de tener una instancia única y global para registrar los eventos del sistema, evitando instanciar múltiples escritores que puedan chocar al intentar escribir en el mismo archivo físico de logs. No se aplicó a entidades de negocio para respetar los principios de la arquitectura limpia.

2. Factory Simple: Implementado en ClientesFactory. Centraliza la lógica de creación de los clientes (Regular, Estudiante, Premium). Resuelve la dispersión de instanciación, permitiendo que el sistema solicite un cliente pasando solo el tipo y los datos, ocultando la complejidad de las clases concretas.

3. Factory Method: Implementado a través de la interfaz IMembresiaFactory y sus creadores concretos (MembresiaAnualFactory, MembresiaMensualFactory, MembresiaTrimestralFactory). Permite delegar la instanciación de las membresías a subclases específicas, haciendo que el sistema sea abierto a la extensión.

Funcionalidad Nueva:

Se agregó un Sistema de Logger Global que intercepta las acciones críticas del programa (registro de nuevos clientes, membresías, sesiones y pagos). Cada vez que el gestor ejecuta una de estas acciones, el Logger registra el evento con un sello de tiempo (fecha y hora exacta) en un archivo de texto externo (Eventos_FITLAB.txt).

Pregunta Reflexiva
¿Cuáles de estas carpetas crees que deberían convertirse en proyectos independientes en una arquitectura por capas real, y por qué?

En una arquitectura por capas real, las carpetas Models y Services deberían ser proyectos independientes (Class Libraries). 
- Models representaría la capa de Dominio (Domain Layer), conteniendo únicamente las entidades puras del negocio sin dependencias externas. 
- Services representaría la capa de Aplicación o Casos de Uso (Application Layer), la cual orquesta la lógica del negocio referenciando al proyecto del Dominio. 
Separarlos físicamente en diferentes proyectos garantiza que la interfaz de usuario (Program.cs) o los repositorios de datos no puedan contaminar las reglas centrales del negocio, respetando la Regla de Dependencia y el principio de Inversión de Dependencias (DIP).