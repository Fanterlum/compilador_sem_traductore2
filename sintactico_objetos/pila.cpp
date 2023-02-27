#include "pila.h"

#include <sstream>

//Constructor
void Pila::push(ElementoPila *x){
   lista.push_front(x);
}

//Elimina el ultimo elemento de la pila
ElementoPila* Pila::pop(){
   ElementoPila* x = *lista.begin();
   lista.erase(lista.begin());
   return x;
};

//Retorna el ultimo elemento de la pila
int Pila::top(){
   ElementoPila *x = *lista.begin();
   int y = x->numero();
   return y;     
};

//Muestra la pila
void Pila::muestra(){
   list <ElementoPila*>::reverse_iterator it;
   ElementoPila *x;
   cout << "Pila: ";
   //Recorre la lista de forma inversa
   for (it= lista.rbegin(); it != lista.rend(); it++){
      x= *it;
      x->muestra2();   
   }
   cout << endl;
};
