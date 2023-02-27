#ifndef _PILA
#define _PILA
#include <list>
#include <iostream>
#include <string>
using namespace std;
//Clase que contiene los elementos que se pueden almacenar en la pila
class ElementoPila{
   protected:
      int valor;
   public:
      virtual void muestra(){}
      virtual void muestra2(){}
      virtual int numero(){}
};
//Clase que contiene los terminales que se pueden almacenar en la pila
class Terminal: public ElementoPila{
   protected:
      string literal;
   public:
      Terminal(int valor, string literal){
         this->valor = valor;
         this->literal= literal;
      }
      //Muestra el terminal
      void muestra(){
         cout << "Terminal" << endl;
         cout << "valor: " << valor << endl;
         cout << "Literal: " << literal << endl << endl;
      }
      //Muestra si es terminal
      void muestra2(){
         cout << "Ter-";
      }
      //Retorna el valor del terminal
      int numero(){
         return valor;
      }
};
//Clase que contiene los no terminales que se pueden almacenar en la pila
class NoTerminal: public ElementoPila{
   protected:
      string literal;
   public:
      NoTerminal(int valor, string literal){
         this->valor = valor;
         this->literal= literal;
      }
      void muestra(){
         cout << "NoTerminal" << endl;
         cout << "valor: " << valor << endl;
         cout << "Literal: " << literal << endl << endl;
      }
      void muestra2(){
         cout << "NoTer-";
      }
      int numero(){
         return valor;
      }
};
//Clase que contiene los estados que se pueden almacenar en la pila
class Estado: public ElementoPila{
   public:
      Estado(int valor){
         this->valor = valor;
      }
      void muestra(){
         cout << "Estado" << endl;
         cout << "valor: " << valor << endl;
      }
      void muestra2(){
         cout << "Est-";
      }
      int numero(){
         return valor;
      }
};
//Clase que contiene la pila
class Pila{
   private:      
      list<ElementoPila*> lista;      
      
   public:  
      void push(ElementoPila* x);
      int top();
      ElementoPila* pop();
      void muestra();
};


#endif
