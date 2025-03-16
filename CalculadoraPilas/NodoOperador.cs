using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraPilaInterfaz
{
    public class NodoOperador
    {
        private NodoOperador siguiente;
        private String value;

        public NodoOperador(String valor)
        {
            this.siguiente = null;
            this.value = valor;
        }

        public NodoOperador Siguiente { get => siguiente; set => siguiente = value; }
        public string Value { get => value; set => this.value = value; }
    }
}
