### TITULO DEL TRABAJO
Analizador Sintactico objetos

### NOMBRE DE LA MATERIA
TRADUCTORES DE LENGUAJE 2

### NOMBRE ESTUDIANTE
González García Vicente

### NOMBRE DEL PROFESOR
MTRO. López Franco Michel Emanuel

# Analizador Sintáctico
El analizador sintáctico es una parte fundamental de los compiladores y se encarga de verificar que la sintaxis de un programa esté correctamente escrita de acuerdo a las reglas de una gramática. En otras palabras, su objetivo es comprobar que la estructura de un programa sea válida y cumpla con las especificaciones del lenguaje.
En el código del main que se proporciona, se puede observar la implementación de un analizador sintáctico descendente utilizando la técnica de Análisis Sintáctico LR(1). Este tipo de análisis utiliza una pila y una tabla de análisis para realizar una lectura anticipada de la entrada y decidir qué acción tomar en cada momento.

# Funcionamiento
En primer lugar, se crea una instancia de la clase Lexico con la cadena a analizar como argumento. Luego, se inicializa la pila con un elemento de estado inicial y el símbolo $, que indica el final de la cadena.

El analizador empieza a leer la cadena de entrada utilizando el método sigSimbolo() de la clase Lexico, que devuelve el siguiente símbolo en la entrada y actualiza los valores de tipo y c con su información.

A continuación, se obtiene el estado actual de la pila con top() y se utiliza como fila en la tabla de análisis tablaLR. El valor de tipo se utiliza como columna en la tabla. La intersección de la fila y la columna en la tabla nos da la acción a tomar.

Si la acción es un número positivo, se realiza un desplazamiento y se añade el símbolo a la pila. Si la acción es negativa, se realiza una reducción aplicando una de las reglas de la gramática. Para ello, se sacan de la pila los elementos necesarios y se añade a la pila el no terminal resultante de la reducción.

El proceso se repite hasta que se alcanza el estado de aceptación (-1) o se detecta un error en la entrada (0). Si el análisis finaliza en estado de aceptación, significa que la entrada es sintácticamente correcta.

# Conclusiones
El código proporcionado es un ejemplo sencillo de cómo se puede implementar un analizador sintáctico LR(1). Sin embargo, en un compilador real, esta tarea suele ser mucho más compleja debido a la cantidad de reglas y símbolos que deben ser considerados. Además, es necesario tener en cuenta otros factores como la semántica del lenguaje y la generación de código intermedio.

![2023-02-26-19-34-44](https://user-images.githubusercontent.com/73490758/221453392-cbc63d8d-dffb-46fa-af34-7b19cfadb30c.gif)
