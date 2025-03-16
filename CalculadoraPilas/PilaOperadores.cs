using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraPilaInterfaz
{
    class PilaOperadores
    {
        private int max;
        private int c;
        private NodoOperador cima;

        public PilaOperadores(int max)
        {
            this.max = max;
            this.c = 0;
            this.cima = null;
        }

        public int Max { get => max; }
        public int C { get => c; }
        public NodoOperador Cima { get => cima; set => cima = value; }

        public void push(String valor)
        {
            NodoOperador n = new NodoOperador(valor);
            if (isEmpty())
            {
                cima = n;
                c++;
                return;
            }
            if (isFull()) { Console.WriteLine("Pila llena"); return; }
            else
            {
                if (n.Value.Equals("-") || n.Value.Equals("+"))
                {
                    NodoOperador temp = cima;
                    while (temp.Siguiente != null)
                    {
                        temp = temp.Siguiente;
                    }
                    temp.Siguiente = n;
                    c++;
                    return;
                }
                else if (n.Value.Equals("*") || n.Value.Equals("/"))
                {
                    n.Siguiente = cima;
                    cima = n;
                    c++;
                }



            }
        }

        public NodoOperador pop()
        {
            if (isEmpty()) { Console.WriteLine("Pila vacia"); return null; }
            else
            {
                NodoOperador temp = cima;
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

        public NodoOperador getCima()
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
                NodoOperador temp = cima;
                while (temp != null)
                {
                    Console.WriteLine($"{temp.Value}");
                    temp = temp.Siguiente;
                }

            }
        }

    }
}
