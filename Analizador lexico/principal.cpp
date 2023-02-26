#include <cstdlib>
#include <iostream>
#include <string>

#include "lexico.h"
#include "lexico.cpp"

using namespace std;

int main(int argc, char *argv[]){
    
    Lexico lexico;
    //generamos la entrada
    lexico.entrada("-254 + 55.23  ! &&  != >= return ; , \"hola\" ( ) if else while adios char  { } = ");
    
    cout << "Resultado del Analisis Lexico" << endl << endl;
    cout << "Simbolo\t\tTipo" << endl;
    
    while (lexico.simbolo.compare("$") != 0 ){
        //llamamos a la funcion sigSimbolo
        lexico.sigSimbolo();
        cout <<  lexico.simbolo << "\t\t" << lexico.tipoAcad(lexico.tipo) << endl;          
    }
        
    cin.get();
    return 0;
}
