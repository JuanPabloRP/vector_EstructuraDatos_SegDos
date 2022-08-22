using System;
using static System.Net.Mime.MediaTypeNames;

namespace vectorSegDos
{
    class vector_EstructuraDatos_SegDos
    {
        static void Main(string[] args)
        {
            creacionVector();
        }

        //llenar vector y verificar que sean numeros
        static void creacionVector()
        {
            double[] vector = new double[20];
            double n = 0;
            string dato = "";
            bool ok = false;
            int contador = 0;

            Console.WriteLine("Creando vector...");

            do
            {
                Console.WriteLine("Ingrese n: ");
                dato = Console.ReadLine();

                if (double.TryParse(dato, out n)) {
                    ok = true;
                }
                else
                {
                    ok = false;
                    Console.WriteLine("Error, ingrese un numero");
                }


                if (ok)
                {
                    vector[contador] = Convert.ToDouble(dato); 
                    contador += 1;
                }

            } while (contador < 20);

            Console.WriteLine("\nVector creado con exito :3\n");

            /*
            for (int i = 0; i < vector.Length; i++) {
                Console.WriteLine("i " + i + " a " + vector[i]);
            }
            */

            menu(vector);
        }

        static void menu(double[] vector)
        {
            int op = 0;
            string dato = "";



            Console.WriteLine("\nMenu de opciones: \n1-Ver promedio\n2-Ver pares\n3-Ver impares\n4-Ver num mayor\n5-Ver num menor\n6-Eliminar un elemento del vector\n7-Buscar un elemento del vector");
            do
            {
                Console.WriteLine("-----------------");
                Console.WriteLine("Ingrese op (1 al 7): ");

                Console.WriteLine("-----------------");
                dato = Console.ReadLine();

                if (int.TryParse(dato, out op))
                {
                    switch (op)
                    {
                        case 1:
                            promedio(vector);
                            break;
                        case 2:
                            pares(vector);
                            break;
                        case 3:
                            impares(vector);
                            break;
                        case 4:
                            mayor(vector);
                            break;
                        case 5:
                            menor(vector);
                            break;
                        case 6:
                            eliminarElem(vector);
                            break;
                        case 7:
                            buscarElem(vector);
                            break;

                        default:
                            Console.WriteLine("Error, valor fuera de rango");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Error, valor invalido");
                }




            } while ((!(int.TryParse(dato, out op))) || (op < 1 || op > 7));
        }


        static void promedio(double[] vector)
        {
            double prom = 0;
            for (int i = 0; i < vector.Length; i++)
            {
                prom += vector[i];
            }
            prom /= vector.Length;
            Console.WriteLine("Promedio: " + prom);
            continuar();
        }


        static void pares(double[] vector) {
            sbyte cantidad = 0;
            for (int i = 0; i < vector.Length; i++)
            {
                if (vector[i] % 2 == 0) {
                    cantidad += 1;
                }
            }
            Console.WriteLine("Cantidad pares: " + cantidad);

            continuar();
        }


        static void impares(double[] vector)
        {
            sbyte cantidad = 0;
            for (int i = 0; i < vector.Length; i++)
            {
                if (vector[i] % 2 == 1 || vector[i] % 2 == -1)
                {
                    cantidad += 1;
                }
            }

            Console.WriteLine("Cantidad impares: " + cantidad);
            
            continuar();
            
        }


        static void mayor(double[] vector)
        {
            double mayor = -99999999;
            
            
            for(int i = 0; i < vector.Length; i++){
                if (vector[i] > mayor)
                {
                    mayor = vector[i];
                }   
            }

            Console.WriteLine("Mayor: " + mayor);

            continuar();
        }


        static void menor(double[] vector)
        {
            double menor = 9999999999;

            for (int i = 0; i < vector.Length; i++) {
                if (vector[i] < menor)
                {
                    menor = vector[i];

                }
            }

            Console.WriteLine("Menor: " + menor);

            continuar();
        }
          

        static void eliminarElem(double[] vector)
        {
            int j = 0,k = 0;
            double nD = 0;
            
            Random n = new Random();
            k = n.Next(0, (vector.Length - 1));
            j = k;



            for (int i = 0; i < vector.Length; i++)
            {
                if (i == k && (k <= vector.Length - 2))
                {
                    if (k == j)
                    {
                        nD = vector[j];
                    }
                    
                    vector[k] = vector[k + 1];
                    k++;
                }
            }

            vector[vector.Length - 1] = 0;

            Console.WriteLine("\nLa posicion a eliminar ha sido de manera aleatoria, la pos eliminada fue: " + j);
            Console.WriteLine("\nNumero eliminado: " + nD + "\tEn posicion: " + j + "\n");

            //comentar xd
            for (int i = 0; i < vector.Length; i++)
            {
                Console.Write(vector[i] + "  ");
            }
            

            continuar();
        }


        static void buscarElem(double[] vector)
        {
            string dato = "";
            double datoABuscar = 0;
            bool encontrado = false;

            do
            {
                Console.WriteLine("Ingrese el dato a buscar: ");
                dato = Console.ReadLine();

                if (double.TryParse(dato, out datoABuscar))
                {
                    for (int i = 0; i < vector.Length; i++)
                    {
                        if (datoABuscar == vector[i])
                        {
                            encontrado = true;
                        }
                        
                    }
                }
                else
                {
                    Console.WriteLine("Error, dato no valido");
                }



                if (encontrado)
                {
                    Console.WriteLine("Número encontrado :D " + datoABuscar);
                    break;
                }
                else
                {
                    Console.WriteLine("Dato no encontrado D:");
                }

            } while ((!(double.TryParse(dato, out datoABuscar))) || (encontrado == false));

            continuar();
        }


        static void continuar()
        {
            string op = "";
            
            do
            {
                Console.WriteLine("\n\nIngrese S para crear otro vector u otra tecla para salir (seguido presione la tecla enter)");
                op = Console.ReadLine();

                if (op.ToUpper() == "S")
                {
                    creacionVector();
                }
                break;
                
            } while (!(op.ToUpper() == "S"));

            Console.WriteLine("Fin programa");
        }

    }
}



/*
 Promedio: Halle el valor promedio de ellos.
Pares: Halle la cantidad de números pares.
Impares: Halle la cantidad de números impares.
Mayor: Halle el número mayor.
Menor: Halle el número menor.
Eliminar: Elimine un elemento del vector (en cualquier posición).
Buscar: busque un elemento dentro del vector con el método de búsqueda binaria.
 
//hacer: continuar ? menu : salir
 */