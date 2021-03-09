# State Machine

Para crear una máquina de estados en C#, se inicia con un diagrama de estados.

![](https://github.com/areyesram/StateMachine/blob/master/images/State%20machine.png?raw=true)

* Cada estado tiene un número definido de acciones válidas.
* Una acción en un determinado estado, puede llevar a la máquina a un estado diferente, o al mismo estado.
* La tupla de (estado actual, acción, nuevo estado) se conoce como una transición.
* Es necesario:
    * Identificar los estados
    * Identificar las acciones o entradas.
    * Crear la matriz de transiciones.
* A partir de todo esto, la única lógica que hay que implementar es:
    * nuevo estado = transición[estado actual, acción]
