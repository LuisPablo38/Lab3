using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Cifrado
    {
        public static string Encriptado(string plaintext, int key)
        {
            char[,] matr = new char[key, (int)Math.Ceiling((double)plaintext.Length / key)];
            int indice = 0;
            // Llenar la cuadrícula con el mensaje original
            for (int col = 0; col < matr.GetLength(1); col++)
            {
                for (int fila = 0; fila < matr.GetLength(0); fila++)
                {
                    if (indice < plaintext.Length)
                    {
                        matr[fila, col] = plaintext[indice];
                        indice++;
                    }
                    else
                    {
                        matr[fila, col] = ' '; // Rellenar con espacios en blanco si es necesario
                    }
                }
            }
            // Leer la cuadrícula en orden de columna
            string ciphertext = "";
            for (int row = 0; row < matr.GetLength(0); row++)
            {
                for (int col = 0; col < matr.GetLength(1); col++)
                {
                    ciphertext += matr[row, col];
                }
            }
            return ciphertext;
        }
    }
}

