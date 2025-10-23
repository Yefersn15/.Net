using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escoge una de las siguientes opciones: ");
            Console.WriteLine("1. Array");
            Console.WriteLine("2. Listas");
            Console.WriteLine("");
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Ejercicio de arrays");
                    int[] numeros = new int[5];
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine("Ingrese un número: ");
                        numeros[i] = int.Parse(Console.ReadLine());
                    }
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine("Número en la posición {0}: {1}", i, numeros[i]);
                    }
                    break;

                case 2:
                    List<int> numero = new List<int>();
                    numero.Add(10);
                    numero.Add(20);
                    numero.Add(30);

                    Console.WriteLine("Los numeros de la lista son: ");
                    foreach (int i in numero)
                    {
                        Console.WriteLine(i);
                    }
                    int PrimerNUmero = numero[1];
                    Console.WriteLine("El segundo Numero de la lista es: "+PrimerNUmero);

                    numero[1] = 25;
                    Console.WriteLine("la lista despues de modificar el segundo numero: ");
                    foreach (int i in numero)
                    {
                        Console.WriteLine(i);
                    }
                    numero.Insert(1, 15);
                    Console.WriteLine("la lista despues de insertar 15 en la posicion 1 : ");
                    foreach (int i in numero)
                    {
                        Console.WriteLine(i);
                    }
                    numero.Sort();
                    Console.WriteLine("la lista despues de ordenar los numeros: ");
                    foreach (int i in numero)
                    {
                        Console.WriteLine(i);
                    }
                    break;

                    case 3:
                    // Desarrolar un programa en C# que administre una lista de productos deante listas.
                    // El programam permitira:
                    // Agregar nuevos productos con su nombre y precio colicitado al usuario.
                    // Mostrar la lista de productos.
                    // Actualizar un producto existente.
                    // Eliminar un producto de la lista.
                    // Salir del programa.
                    List<string> productos = new List<string>();
                    while (true)
                    {
                        Console.WriteLine("Seleccione una opción:");
                        Console.WriteLine("1. Agregar producto");
                        Console.WriteLine("2. Mostrar productos");
                        Console.WriteLine("3. Actualizar producto");
                        Console.WriteLine("4. Eliminar producto");
                        Console.WriteLine("5. Salir");
                        int opcionProducto = int.Parse(Console.ReadLine());
                        switch (opcionProducto)
                        {
                            case 1:
                                Console.WriteLine("Ingrese el nombre del producto:");
                                string nuevoProducto = Console.ReadLine();

                                Console.WriteLine("Ingrese el precio del producto:");
                                string precioProducto = Console.ReadLine();

                                productos.Add(nuevoProducto + precioProducto);
                                Console.WriteLine("Producto agregado.");
                                break;
                            case 2:
                                Console.WriteLine("Lista de productos:");
                                foreach (string producto in productos)
                                {
                                    Console.WriteLine(producto);
                                }
                                break;
                            case 3:
                                Console.WriteLine("Ingrese el nombre del producto a actualizar:");
                                string productoActualizar = Console.ReadLine();
                                if (productos.Contains(productoActualizar))
                                {
                                    Console.WriteLine("Ingrese el nuevo nombre del producto:");
                                    string nuevoNombre = Console.ReadLine();
                                    int index = productos.IndexOf(productoActualizar);
                                    productos[index] = nuevoNombre;
                                    Console.WriteLine("Producto actualizado.");
                                }
                                else
                                {
                                    Console.WriteLine("Producto no encontrado.");
                                }
                                break;
                            case 4:
                                Console.WriteLine("Ingrese el nombre del producto a eliminar:");
                                string productoEliminar = Console.ReadLine();
                                if (productos.Remove(productoEliminar))
                                {
                                    Console.WriteLine("Producto eliminado.");
                                }
                                else
                                {
                                    Console.WriteLine("Producto no encontrado.");
                                }
                                break;
                            case 5:
                                Console.WriteLine("Saliendo del programa.");
                                return;
                            default:
                                Console.WriteLine("Opción no válida.");
                                break;
                        }
                    }
            }
        }
    }
};
