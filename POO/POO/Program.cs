using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Crear una instancia del CRUD de productos
            Producto.ProductosCrud crudProductos = new Producto.ProductosCrud();

            Console.WriteLine("1. Autos");
            Console.WriteLine("2. Aprendices");
            Console.WriteLine("3. Productos");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    // Código para la opción 1
                    Auto coche1 = new Auto("Toyota", "Corolla", 2020, "Rojo");
                    Auto coche2 = new Auto("Honda", "Civic", 2019, "Azul");
                    Auto coche3 = new Auto("Ford", "Focus", 2018, "Negro");

                    coche1.color = "Blanco";
                    coche2.anio = 2021;
                    coche3.modelo = "Accord";

                    Console.WriteLine("Información de los coches:");
                    Console.WriteLine("Primer coche:");
                    coche1.MostrarInfo();
                    Console.WriteLine("Segundo coche:");
                    coche2.MostrarInfo();
                    Console.WriteLine("Tercer coche:");
                    coche3.MostrarInfo();
                    break;

                case 2:
                    // Código para la opción 2
                    Aprendiz aprendiz1 = new Aprendiz("Juan Perez", 2000, "Desarrollo de Software", 12345, "Bogotá", "Calle 123 #45-67");
                    Aprendiz aprendiz2 = new Aprendiz("Maria Gomez", 2005, "Diseño Gráfico", 67890, "Medellín", "Carrera 89 #12-34");
                    Aprendiz aprendiz3 = new Aprendiz("Carlos Ruiz", 1998, "Administración de Empresas", 11223, "Cali", "Avenida 45 #67-89");
                    Console.WriteLine("Información de los aprendices:");
                    Console.WriteLine("Primer aprendiz:");
                    aprendiz1.MostrarInfo();
                    aprendiz1.VerificarEdad();

                    Console.WriteLine("Segundo aprendiz:");
                    aprendiz2.MostrarInfo();
                    aprendiz2.VerificarEdad();

                    Console.WriteLine("Tercer aprendiz:");
                    aprendiz3.MostrarInfo();
                    aprendiz3.VerificarEdad();
                    break;

                case 3:
                    // Código para la opción 3 - Productos
                    MenuProductos(crudProductos);
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }

        static void MenuProductos(Producto.ProductosCrud crud)
        {
            int opcion;
            do
            {
                Console.WriteLine("\n=== MENÚ PRODUCTOS ===");
                Console.WriteLine("1. Crear producto");
                Console.WriteLine("2. Listar productos");
                Console.WriteLine("3. Actualizar producto");
                Console.WriteLine("4. Eliminar producto");
                Console.WriteLine("5. Ver precio total de producto");
                Console.WriteLine("0. Salir");
                Console.WriteLine("Seleccione una opción:");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        crud.CrearProducto();
                        break;
                    case 2:
                        crud.ListarProductos();
                        break;
                    case 3:
                        crud.ActualizarProducto();
                        break;
                    case 4:
                        crud.EliminarProducto();
                        break;
                    case 5:
                        crud.MostrarPrecioTotalProducto();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del menú de productos...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 0);
        }
    }
}