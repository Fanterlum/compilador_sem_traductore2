### TITULO DEL TRABAJO
Gramatica de un compilador

### NOMBRE DE LA MATERIA
TRADUCTORES DE LENGUAJE 2

### NOMBRE ESTUDIANTE
González García Vicente

### NOMBRE DEL PROFESOR
MTRO. López Franco Michel Emanuel


# Archivos
lexico.cpp: Archivo que contiene la implementación de la clase Lexico.

lexico.h: Archivo que contiene la declaración de la clase Lexico.

pila.cpp: Archivo que contiene la implementación de la clase Pila.

pila.h: Archivo que contiene la declaración de la clase Pila.

compilador.cpp: Archivo que contiene la función main del compilador.
# Funcionamiento
El archivo compilador.cpp contiene la función main que analizara la gramatica, en la cual se lleva a cabo el análisis sintáctico de la cadena de entrada.

En primer lugar, se lee el archivo compilador.lr para obtener la tabla de análisis LR y las reglas de reducción que se utilizarán durante el análisis.

A continuación, se inicializa la pila con el estado inicial y el símbolo $, que indica el fin de la cadena de entrada.

Se procede a leer el primer símbolo de la cadena de entrada, y se determina la acción a realizar en base al estado actual y al símbolo leído. Si la acción es una reducción, se borran los elementos de la pila correspondientes a la regla de reducción, y se realiza una nueva acción en base al nuevo estado actual y al símbolo que está en el tope de la pila. Si la acción es un desplazamiento, se inserta el símbolo leído en la pila y se realiza una nueva acción en base al nuevo estado actual y al siguiente símbolo de la cadena de entrada.

El proceso continúa hasta que se llega a un estado de aceptación, en cuyo caso se indica que la cadena de entrada es sintácticamente correcta, o hasta que se detecta un error, en cuyo caso se indica que la cadena de entrada es incorrecta.




https://user-images.githubusercontent.com/73490758/221710397-384b217b-9ead-4f8e-9edb-9890f1af25c4.mp4

