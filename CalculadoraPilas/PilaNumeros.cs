using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraPilaInterfaz
{
    class PilaNumeros
    {
        private int max;
        private int c;
        private NodoNumeros cima;

        public PilaNumeros(int max)
        {
            this.max = max;
            this.c = 0;
            this.cima = null;
        }

        public int Max { get => max; }
        public int C { get => c; }
        public NodoNumeros Cima { get => cima; set => cima = value; }

        public void push(int valor)
        {
            NodoNumeros n = new NodoNumeros(valor);
            if (isEmpty())
            {
                cima = n;
                c++;
                return;
            }
            if (!isFull())
            {
                n.Siguiente = cima;
                cima = n;
                c++;
                return;
            }
            else { Console.WriteLine("Pila llena"); return; }
        }

        public NodoNumeros pop()
        {
            if (isEmpty()) { Console.WriteLine("Pila vacia"); return null; }
            else
            {
                NodoNumeros temp = cima;
                cima = cima.Siguiente;
                c--;
                return temp;
            }
        }
        public Boolean isEmpty()
        {
            if (c == 0) { return true; }
            else { return false; }
        }
        public Boolean isFull()
        {
            if (c >= max) { return true; }
            else { return false; }
        }

        public NodoNumeros getCima()
        {
            if (isEmpty()) { Console.WriteLine("Pila vacia"); return null; }
            else
            {
                return cima;
            }
        }
        public void Mostrar()
        {
            if (isEmpty()) { Console.WriteLine("Pila vacia"); }
            else
            {
                NodoNumeros temp = cima;
                while (temp != null)
                {
                    Console.WriteLine($"{temp.Value}");
                    temp = temp.Siguiente;
                }

            }
        }

    }
}
