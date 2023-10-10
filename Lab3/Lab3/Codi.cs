using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Codi
    {
        public static List<string> Codificacion(string entrada)
        {
            Dictionary<string, int> dictionari = new Dictionary<string, int>();
            List<string> compresion = new List<string>();
            int IndiDicc = 0;
            string Similar = " ";
            if (Similar == " ")
            {
                // Verificar si la clave existe antes de agregarla
                if (dictionari.ContainsKey(Similar))
                {
                    compresion.Add(dictionari[Similar].ToString());
                }
                else
                {
                    compresion.Add(Similar[Similar.Length - 1].ToString());
                }
            }
            foreach (char c in entrada)
            {
                Similar += c;

                if (!dictionari.ContainsKey(Similar))
                {
                    dictionari.Add(Similar, IndiDicc++);
                    if (Similar == Similar)
                    {
                        IndiDicc = IndiDicc++;
                        Console.WriteLine("< " + Similar + " " + IndiDicc + " >");
                    }
                    else
                    {
                        IndiDicc = IndiDicc;
                        Console.WriteLine("< " + Similar + " " + IndiDicc + " >");
                    }
                    //compresion.Add(dictionari[Similar.Substring(0, Similar.Length - 1)].ToString() + c);
                    Similar = " ";
                }
            }
            return compresion;
        }

    }
}
