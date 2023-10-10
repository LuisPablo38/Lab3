using Lab3.Vista; 
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            string carpet = @"D:\Users\luisp\Downloads\inputs";
            bool opcion = true;
            ArbolB<Persona> obj = new ArbolB<Persona>(2);
            Persona obj2 = new Persona();
            string empresa;
            string union;

            while (opcion)
            {
                Console.Clear();
                Console.WriteLine("         Prueba de eficiencia Talent Hub");
                Console.WriteLine("Seleccione una de las siguientes opciones para realizar ");
                Console.WriteLine(" 1. Insertar registro de persona");
                Console.WriteLine(" 2. Mostrar datos codigicados");
                Console.WriteLine(" 3. Buscar cartas asociados a un PDI");
 
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Console.Clear();
                        string nombreIngreso;
                        string Cumpleaños;
                        string Direccio;
                        Console.WriteLine("Personas info ingrese los datos o escriba Salir para terminar");
                        Console.WriteLine("Ingrese el nombre");
                        nombreIngreso = Console.ReadLine();
                        Console.WriteLine("Ingrese el DPI");
                        long DPI = long.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese fecha de cumpleaños mm/dd/yyy");
                        Cumpleaños = Console.ReadLine();
                        Console.WriteLine("Ingrese la direccion");
                        Direccio = Console.ReadLine();
                        Console.WriteLine("Ingrese la empresa");
                        empresa = Console.ReadLine();
                        obj2.Nombre = nombreIngreso;
                        obj2.Identificador = DPI;
                        obj2.Cumpleaños = Cumpleaños;
                        obj2.Direccion = Direccio;
                        obj2.Empresa = empresa;
                        union = empresa + nombreIngreso;
                        Console.WriteLine("Se guardo el nombre " + obj2.Nombre + " Identificado con el DPI: " + obj2.Identificador + " Con fecha de cumpleaños " + obj2.Cumpleaños + " Y direccion: " + obj2.Direccion);
                        //string PersonasJson = JsonSerializer.Serialize(obj2); //Serealizar a formato JSON 
                        obj.Insertar(obj2);
                        System.Threading.Thread.Sleep(2000);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Compreso");
                        List<string> compresion = Codi.Codificacion(union = obj2.Empresa + obj2.Identificador);
                        Console.WriteLine("Mensaje sin comprimir");
                        Console.WriteLine("Empresa:  " + obj2.Empresa + " " + " Identificador " + obj2.Identificador);
                        //"compadre_no_compro_coco"
                        System.Threading.Thread.Sleep(10000);
                        break;
                    case 3:
                        Console.Clear();

                        Console.WriteLine("Ingrese el identificador a buscar");

                        string primeros17Caracteres = Console.ReadLine();

                        Dictionary<string, List<string>> archivosAgrupados = BuscarArchivosPorIdentificadorSimilar(carpet, primeros17Caracteres);

                        if (archivosAgrupados.Count > 0)
                        {
                            Console.WriteLine("Archivos encontrados con identificadores similares:");

                            foreach (var kvp in archivosAgrupados)
                            {
                                Console.WriteLine($"Identificador: {kvp.Key}");

                                foreach (string archivo in kvp.Value)
                                {
                                    Console.WriteLine(archivo);

                                    string nombreArch = "Cifrado" + $"{kvp.Key}_{Path.GetFileName(archivo)}";
                                    string rutaArchivoCifr = Path.Combine(@"C:\Users\luisp\Desktop\Landivar\Cuarto año\Octavo Ciclo\Estructuras 2\Lab\", nombreArch);

                                    EscribiRArchi(archivo, rutaArchivoCifr);

                                    string nomArchCDesi = "Descifrado" + $"{kvp.Key}_{Path.GetFileName(archivo)}";
                                    string rutaArchivoDesi = Path.Combine(@"C:\Users\luisp\Desktop\Landivar\Cuarto año\Octavo Ciclo\Estructuras 2\Lab\", nomArchCDesi);

                                    EscribiRArchiDes(archivo, rutaArchivoDesi);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se encontraron archivos con identificadores similares.");
                        }


                        System.Threading.Thread.Sleep(9000);
                        break;
                    default:
                        Console.WriteLine("Ingrese una opcion valida");
                        System.Threading.Thread.Sleep(3000);
                        break;
                }
            }
        }

        static Dictionary<string, List<string>> BuscarArchivosPorIdentificadorSimilar(string carpeta, string primeros17Caracteres)
        {
            Dictionary<string, List<string>> archivosAgrupados = new Dictionary<string, List<string>>();
            try
            {
                string[] archivos = Directory.GetFiles(carpeta, $"{primeros17Caracteres}*.txt");

                foreach (string archivo in archivos)
                {
                    string nombreArchivo = Path.GetFileNameWithoutExtension(archivo);
                    string identificadorBase = nombreArchivo.Substring(0, 17);

                    if (!archivosAgrupados.ContainsKey(identificadorBase))
                    {
                        archivosAgrupados[identificadorBase] = new List<string>();
                    }
                    archivosAgrupados[identificadorBase].Add(archivo);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ocurrió un error");
            }
            return archivosAgrupados;
        }

        static void EscribiRArchi(string rutaOrigen, string rutaDestino)
        {
            try
            {
                string contenido = File.ReadAllText(rutaOrigen);
                string mensaje = Cifrado.Encriptado(contenido, 7);
                File.WriteAllText(rutaDestino, mensaje);
            }
            catch (Exception)
            {
                Console.WriteLine("Error al escribir en el archivo");
            }
        }

        static void EscribiRArchiDes(string rutaOrigen, string rutaDestino)
        {
            try
            {
                string contenido = File.ReadAllText(rutaOrigen);
                File.WriteAllText(rutaDestino, contenido);
            }
            catch (Exception)
            {
                Console.WriteLine("Error al escribir en el archivo");
            }
        }

    }
}
