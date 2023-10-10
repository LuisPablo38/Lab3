using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Nodo
    {

        public static int i = 2;

        public int Claves = 3;
        public bool EsHoja;

        public Persona[] clave = new Persona[2 * i - 1];
        public Nodo[] hijos = new Nodo[2 * i];
        public int ClavesUsadas = 0;


        public Nodo()//string INFORMACION)
        {


            izq = null;
            der = null;
            EsHoja = true;
        }

        public Nodo izq;
        public Nodo der;
        public int NumClaves;


        internal Nodo Izq { get => izq; set => izq = value; }
        internal Nodo Der { get => der; set => der = value; }
    }
}
