#include <iostream>
#include <fstream>
#include <string>
#include <sstream>
#include <bits/stdc++.h>

#include "lexico.h"
#include "pila.h"
#include "lexico.cpp"
#include "pila.cpp"

using namespace std;
string reglas[53];
int cont = 0, fil = 0, col = 0;
int tablaLR[95][46];
string rreglaactual[3];

//Funcion para separar los elementos de la tabla LR
void arrange2(string str){
    int posicion = 0;
    string w = "";
    for (auto x : str) 
    {
        if (x == ' ')
        {
            rreglaactual[posicion] = w;
            posicion ++;
            w = "";
        }
        else {
            w = w + x;
        }
    }
    rreglaactual[posicion] = w;
    posicion ++;
}

void arrange(string str){ //Funcion para separar los elementos de la tabla LR
    int num;
    string w = "";
    col = 0;
    for (auto x : str) {
        if (x == ' '){
            stringstream ss;
            ss << w;  
            ss >> num;
            tablaLR[fil][col] = num;
            col ++;
            w = "";
        }
        else{
            w = w + x;
        }
    }
    stringstream ss;
    ss << w;  
    ss >> num;
    tablaLR[fil][col] = num;
    col ++;
    fil ++;
}

int main(){//Funcion principal
    int estadoact;
    fstream newfile;
    newfile.open("compilador.lr",ios::in); //open a file to perform read operation using file object
    if (newfile.is_open()){   //checking whether the file is open
        string tp;
        while(getline(newfile, tp)){ //read data from file object and put it into string.
            if (cont <= 52){
                reglas[cont] = tp;
            }if(cont >= 54){
                arrange(tp);
            }
            cont ++;
        }
        newfile.close(); //close the file object.
    }

    int contador = 0;
    int idReglas[2] = {3,2}; 
    int IonReglas[2] = {3,0};
    int idE = 3; 
    int E;
    Pila pila;
    ElementoPila *elemento;
    int fila, columna, accion;
    bool aceptacion= false;
    Lexico lexico("float palabara ; ");//cadena a analizar

    elemento = new Terminal(2,"$");
    pila.push( elemento); //Entra signo de pesos que inicializa la cadena
    elemento = new Estado(0);
    pila.push( elemento );                 
    lexico.sigSimbolo();    //obtenemos el primer simbolo de la cadena

    fila= pila.top();   //para la fila tomamos el ultimo elemento de la pila
    columna= lexico.tipo;//para la columna tomamos en cuenta el tipo de simbolo que estamos analizando
    cout << "Fila: " << fila << endl;
    cout << "Columna: " << columna << endl;
    accion= tablaLR[fila][columna];//obtenemos la accion a realizar

    pila.muestra();//mostramos la pila
    cout << "entrada: " << lexico.simbolo << endl;
    cout << "accion: " << accion << endl;

    while(accion != -1){//mientras la accion sea diferente de -1 seguimos analizando

        if(accion > 0){//si la accion es mayor a 0 hacemos un desplazamiento
            cout << endl;
            cout << "Desplazamiento" << endl;
            elemento = new Terminal(lexico.tipo,lexico.c);
            pila.push( elemento );
            elemento = new Estado(accion);
            pila.push( elemento );
            lexico.sigSimbolo();

            fila= pila.top();
            columna= lexico.tipo;
            cout << "Fila: " << fila << endl;
            cout << "Columna: " << columna << endl;
            accion= tablaLR[fila][columna];

            pila.muestra();
            cout << "entrada: " << lexico.simbolo << endl;
            cout << "accion: " << accion << endl;
        }
        if(accion < 0){//si la accion es menor a 0 hacemos una reduccion
            cout << endl;
            cout << "REDUCCION" << endl;
            int reglaapp = abs(accion) - 1;
            cout << "REGLA: " << reglaapp<< endl;
            int numborrados;
            stringstream ss;
            char reglastr = reglas[reglaapp][3];
            ss << reglastr;  
            ss >> numborrados;
            numborrados = numborrados * 2;
            if (accion == -1)break;//si la accion es -1 es aceptacion

            for(int i=0; i<numborrados; i++){//borramos los elementos de la pila
                pila.pop();
            }

            pila.muestra();
            arrange2(reglas[reglaapp]);
            string prueba= rreglaactual[2];
            prueba = prueba+ " ";
            Lexico lexico2(prueba);
            lexico2.sigSimbolo();
            elemento = new NoTerminal(lexico2.tipo,lexico2.c);
            estadoact = tablaLR[pila.top()][lexico2.tipo];
            pila.push( elemento ); //Entra signo de pesos que inicializa la cadena
            elemento = new Estado(estadoact);
            pila.push( elemento );

            fila= pila.top();
            columna= lexico.tipo;
            cout << "Fila: " << fila << endl;
            cout << "Columna: " << columna << endl;
            accion= tablaLR[fila][columna];
            pila.muestra();
            cout << "entrada: " << lexico.simbolo << endl;
            cout << "accion: " << accion << endl << endl;
            
        }
        if(accion == 0)break;
    }
    cout << "Automata terminado" << endl;
    aceptacion= accion == -1;
    if (aceptacion) cout << "aceptacion" << endl;
    else cout << "No aceptacion" << endl;
}
