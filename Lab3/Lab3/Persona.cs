using Lab3.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Persona : IComparable<Persona> 
    {
        public string Nombre { get; set; }
        public long Identificador { get; set; }

        public string Direccion { get; set; }

        public string Cumpleaños { get; set; }

        public string Empresa { get; set; }

        public int CompareTo(Persona other)
        {
            if (this.Identificador > other.Identificador)
            {
                return 1;
            }
            else if (this.Identificador < other.Identificador)
            {
                return -1;
            }
            return Identificador.CompareTo(other.Identificador);
        }

    }
}
