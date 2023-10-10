using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Vista
{
    class ArbolB<T> where T : IComparable<Persona>
    {
        private Nodo raiz;
        // private Nodo trabajo;
        private Nodo izq;
        private Nodo der;
        public int i;

        public Nodo raiz2;
        public ArbolB(int I)
        {
            i = I;
            raiz2 = new Nodo();
            raiz2.Claves = 0;
            raiz2.EsHoja = true;

        }
        internal Nodo Raiz { get => raiz; set => raiz = value; }
        //Insertar 
        public void Insertar(Persona persona)//Dato que se incerta, nodo en el que se inserta (aqui le digo en cual quiero que se inserte )
        {
            Nodo R = raiz2;

            if (R.Claves == (2 * i - 1)) //Cambiar el tipo a int 
            {
                Nodo s = new Nodo();
                raiz2 = s;
                s.EsHoja = false;
                s.Claves = 0;
                s.hijos[0] = R;
                Dividir(s, 0, R);
                InsertarEnNodo(s, persona);
            }
            else
            {
                InsertarEnNodo(R, persona);
            }

        }
        //Insertar en Nodo
        public void InsertarEnNodo(Nodo nodo, Persona persona)
        {
            if (nodo.EsHoja)
            {
                int i;
                i = nodo.Claves;

                while (i >= 1 && persona.CompareTo(nodo.clave[i - 1]) < 0)
                {
                    nodo.clave[i] = nodo.clave[i - 1];
                    i--;
                }
                nodo.clave[i] = persona;
                nodo.Claves++;
            }
            else
            {
                int j = 0;
                while (j < nodo.Claves && persona.CompareTo(nodo.clave[j]) > 0)
                {
                    j++;
                }
                if (nodo.hijos[j].Claves == (2 * i - 1))
                {
                    Dividir(nodo, j, nodo.hijos[j]);
                    if (persona.CompareTo(nodo.clave[j]) > 0)
                    {
                        j++;
                    }
                }
                InsertarEnNodo(nodo.hijos[j], persona);
            }
        }

        //Eliminar 
        public Nodo Eliminar(Nodo nodo)
        {

            return null;
        }
        //Actualizar
        public Nodo Actualizar(Nodo nodo, Persona persona)
        {


            return null;
        }
        //Buscar
        public Persona Buscar(Nodo nodo, Persona persona)
        {
            Persona obj9 = new Persona();
            Nodo newNodo3 = new Nodo();
            int i;
            if (nodo == null)
            {
                return persona;
            }
            for (i = 0; i < nodo.Claves; i++)
            {
                if (persona.CompareTo(nodo.clave[i]) < 0)
                {
                    break;
                }
                if (persona.CompareTo(nodo.clave[i]) == 0)
                {
                    return nodo.clave[i];
                }
            }
            if (nodo.EsHoja)
            {
                return (null);
            }
            else
            {
                return Buscar(nodo.hijos[i], persona);
            }
        }
        // Dividir Nodos 
        public void Dividir(Nodo npadre, int posicion, Nodo nhijos)
        {
            Nodo newNodo = new Nodo();
            newNodo.EsHoja = nhijos.EsHoja;
            newNodo.NumClaves = (i - 1);
            for (int j = 0; j < (i - 1); j++)
            {
                newNodo.clave[j] = nhijos.clave[(j + i)];
            }
            if (nhijos.EsHoja == false)
            {
                for (int k = 0; k < i; k++)
                {
                    newNodo.hijos[k] = nhijos.hijos[(k + i)];
                }
            }
            nhijos.ClavesUsadas = i - 1;
            for (int j = npadre.ClavesUsadas; j < posicion; j++)
            {
                npadre.hijos[(j + 1)] = npadre.hijos[(j)];
            }
            npadre.hijos[(posicion + 1)] = newNodo;
            for (int j = npadre.ClavesUsadas; j < posicion; j--)
            {
                npadre.clave[(j + 1)] = npadre.clave[j];
            }
            npadre.clave[posicion] = nhijos.clave[(i - 1)];
            npadre.ClavesUsadas++;
        }
    }
}
