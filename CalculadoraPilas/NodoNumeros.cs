using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraPilaInterfaz
{
    class NodoNumeros
    {
        private NodoNumeros siguiente;
        private int value;

        public NodoNumeros(int value)
        {
            this.siguiente = null;
            this.value = value;
        }

        public NodoNumeros Siguiente { get => siguiente; set => siguiente = value; }
        public int Value { get => value; set => this.value = value; }
    }
}
