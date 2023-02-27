#include <cstdlib>
#include <iostream>
#include <string>

#include "lexico.h"
#include "pila.h"
#include "lexico.cpp"
#include "pila.cpp"

using namespace std;

int main(int argc, char *argv[]){ 
    int contador = 0;
    int idReglas[2] = {3,2}; 
    int IonReglas[2] = {3,0};
    int idE = 3; 
    int E;
    int tablaLR[5][4]={//matriz de la tabla LR(1)
        2, 0, 0, 1,
        0, 0, -1, 0,
        0, 3, -2, 0,
        2, 0, 0, 4,
        0, 0, -3, 0
    };
    Pila pila;
    ElementoPila *elemento;
    int fila, columna, accion;
    bool aceptacion= false;
    
    Lexico lexico("a + b + c + d + e + f ");

    elemento = new Terminal(2,"$");
    pila.push( elemento); //introducimos el simbolo de fin de cadena
    elemento = new Estado(0);
    pila.push( elemento );                 
    lexico.sigSimbolo();//leemos el primer simbolo de la cadena

    fila= pila.top();//para la fila tomamos en cuenta en top de la pila
    columna= lexico.tipo;//para la columna tomamos en cuenta el tipo de simbolo que se leyo
    cout << "fila: " << fila << endl;
    cout << "Columna" << columna << endl;
    accion= tablaLR[fila][columna];//obtenemos la accion a realizar

    pila.muestra();//mostramos la pila
    cout << "entrada: " << lexico.simbolo << endl;
    cout << "accion: " << accion << endl;

    while(accion != -1){//mientras la accion sea diferente de aceptacion repetimos el proceso
        if(accion > 0){//si la accion es mayor a 0 hacemos un desplazo
            if(accion != 4){
                elemento = new Terminal(lexico.tipo,lexico.c);
                pila.push( elemento );
                elemento = new Estado(accion);
                pila.push( elemento );
            }
            lexico.sigSimbolo();

            fila= pila.top();
            columna= lexico.tipo;
            cout << "fila: " << fila << endl;
            cout << "Columna" << columna << endl;
            accion= tablaLR[fila][columna];

            pila.muestra();
            cout << "entrada: " << lexico.simbolo << endl;
            cout << "accion: " << accion << endl;
        }
        if(accion < 0){//Si la accion es menor a 0 hacemos una reduccion
            if (accion == -1)break;//si es -1 aceptamos la cadena
            if (accion == -3){ //si es -3 aplicamos la regla 1(E = <id> + E)
                contador = 0;
                E = idReglas[contador]  + IonReglas[contador];//(3,3)
            }
            if (accion == -2){//si es -2 aplicamos la regla 2(E = <id>)
                contador = 1;
                E = idReglas[contador];//(3)
            }

            for(int i=0; i<E; i++){//eliminamos los elementos de la pila
                pila.pop();
            }

            pila.muestra();
            fila= pila.top();
            columna= 3;//el no terminal E
            cout << "fila: " << fila << endl;
            cout << "Columna" << columna << endl;
            accion= tablaLR[fila][columna];

            elemento = new NoTerminal(3,"E");
            pila.push( elemento ); //introducimos el no terminal E
            cout << "entro " <<endl;
            elemento = new Estado(accion);
            pila.push( elemento );
            pila.muestra();
            cout << "entrada: " << lexico.simbolo << endl;
            cout << "accion: " << accion << endl << endl;
        }
        if(accion == 0)break;
    }
    cout << "Automata terminado" << endl;
    
    aceptacion= accion == -1;
    //si la accion es -1 es aceptacion
    if (aceptacion) cout << "aceptacion" << endl;
    else cout << "no aceptacion" << endl;
}
