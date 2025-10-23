using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Producto
    {
        public string nombre { get; set; }
        public double precio { get; set; }
        public int cantidad { get; set; }
        public string categoria { get; set; }
        public int id { get; set; }

        // Propiedad calculada para el precio total
        public double PrecioTotal
        {
            get { return cantidad * precio; }
        }

        public Producto(string nombre, double precio, int cantidad, string categoria, int id)
        {
            this.nombre = nombre;
            this.precio = precio;
            this.cantidad = cantidad;
            this.categoria = categoria;
            this.id = id;
        }

        // Método para mostrar información del producto incluyendo el precio total
        public void MostrarInformacion()
        {
            Console.WriteLine($"ID: {id}, Nombre: {nombre}, Precio: {precio:C}, Cantidad: {cantidad}, Categoría: {categoria}, Precio Total: {PrecioTotal:C}");
        }

        public class ProductosCrud
        {
            public List<Producto> productos { get; set; } = new List<Producto>();
            public int siguienteId { get; set; } = 1;

            // CREATE - Crear producto
            public void CrearProducto()
            {
                Console.WriteLine("Ingrese el nombre del producto:");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el precio del producto:");
                double precio = double.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese la cantidad del producto:");
                int cantidad = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese la categoría del producto:");
                string categoria = Console.ReadLine();

                // Auto incremento del ID
                Producto nuevoProducto = new Producto(nombre, precio, cantidad, categoria, siguienteId);
                productos.Add(nuevoProducto);
                siguienteId++; // Incrementar el ID para el próximo producto

                Console.WriteLine($"Producto creado exitosamente con ID: {nuevoProducto.id}");
            }

            // READ - Listar todos los productos
            public void ListarProductos()
            {
                if (productos.Count == 0)
                {
                    Console.WriteLine("No hay productos registrados.");
                    return;
                }

                Console.WriteLine("\n=== LISTA DE PRODUCTOS ===");
                foreach (var producto in productos)
                {
                    producto.MostrarInformacion();
                }

                // Mostrar el total general de todos los productos
                double totalGeneral = productos.Sum(p => p.PrecioTotal);
                Console.WriteLine($"\nTOTAL GENERAL DE INVENTARIO: {totalGeneral:C}");
            }

            // READ - Buscar producto por ID
            public void BuscarProductoPorId()
            {
                Console.WriteLine("Ingrese el ID del producto a buscar:");
                int id = int.Parse(Console.ReadLine());
                var producto = ObtenerProductoPorId(id);

                if (producto != null)
                {
                    Console.WriteLine("\n=== PRODUCTO ENCONTRADO ===");
                    producto.MostrarInformacion();
                }
                else
                {
                    Console.WriteLine($"No se encontró ningún producto con ID: {id}");
                }
            }

            // UPDATE - Actualizar producto
            public void ActualizarProducto()
            {
                Console.WriteLine("=== ACTUALIZAR PRODUCTO ===");
                Console.WriteLine("Ingrese el ID del producto a actualizar:");
                int id = int.Parse(Console.ReadLine());
                var producto = ObtenerProductoPorId(id);

                if (producto != null)
                {
                    Console.WriteLine("Producto actual:");
                    producto.MostrarInformacion();
                    Console.WriteLine("\nIngrese los nuevos datos:");

                    Console.WriteLine("Ingrese el nuevo nombre del producto:");
                    producto.nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese el nuevo precio del producto:");
                    producto.precio = double.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese la nueva cantidad del producto:");
                    producto.cantidad = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese la nueva categoría del producto:");
                    producto.categoria = Console.ReadLine();

                    Console.WriteLine($"Producto con ID: {id} actualizado exitosamente.");
                    Console.WriteLine("Producto actualizado:");
                    producto.MostrarInformacion();
                }
                else
                {
                    Console.WriteLine($"No se encontró ningún producto con ID: {id}");
                }
            }

            // DELETE - Eliminar producto
            public void EliminarProducto()
            {
                Console.WriteLine("=== ELIMINAR PRODUCTO ===");
                Console.WriteLine("Ingrese el ID del producto a eliminar:");
                int id = int.Parse(Console.ReadLine());
                var producto = ObtenerProductoPorId(id);

                if (producto != null)
                {
                    Console.WriteLine("Producto a eliminar:");
                    producto.MostrarInformacion();

                    Console.WriteLine("¿Está seguro de eliminar este producto? (s/n)");
                    string confirmacion = Console.ReadLine();

                    if (confirmacion.ToLower() == "s")
                    {
                        productos.Remove(producto);
                        Console.WriteLine($"Producto con ID: {id} eliminado exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("Eliminación cancelada.");
                    }
                }
                else
                {
                    Console.WriteLine($"No se encontró ningún producto con ID: {id}");
                }
            }

            // Método auxiliar para obtener producto por ID
            private Producto ObtenerProductoPorId(int id)
            {
                return productos.FirstOrDefault(p => p.id == id);
            }

            // Método para mostrar el precio total de un producto específico
            public void MostrarPrecioTotalProducto()
            {
                Console.WriteLine("Ingrese el ID del producto para ver el precio total:");
                int id = int.Parse(Console.ReadLine());
                var producto = ObtenerProductoPorId(id);

                if (producto != null)
                {
                    Console.WriteLine($"\n=== PRECIO TOTAL DEL PRODUCTO ===");
                    Console.WriteLine($"Producto: {producto.nombre}");
                    Console.WriteLine($"Precio unitario: {producto.precio:C}");
                    Console.WriteLine($"Cantidad: {producto.cantidad}");
                    Console.WriteLine($"Precio total: {producto.PrecioTotal:C}");
                }
                else
                {
                    Console.WriteLine($"No se encontró ningún producto con ID: {id}");
                }
            }

            // Método para mostrar menú principal
            public void MostrarMenu()
            {
                while (true)
                {
                    Console.WriteLine("\n=== SISTEMA DE GESTIÓN DE PRODUCTOS ===");
                    Console.WriteLine("1. Crear producto");
                    Console.WriteLine("2. Listar productos");
                    Console.WriteLine("3. Buscar producto por ID");
                    Console.WriteLine("4. Actualizar producto");
                    Console.WriteLine("5. Eliminar producto");
                    Console.WriteLine("6. Mostrar precio total de producto");
                    Console.WriteLine("7. Salir");
                    Console.WriteLine("Seleccione una opción:");

                    string opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            CrearProducto();
                            break;
                        case "2":
                            ListarProductos();
                            break;
                        case "3":
                            BuscarProductoPorId();
                            break;
                        case "4":
                            ActualizarProducto();
                            break;
                        case "5":
                            EliminarProducto();
                            break;
                        case "6":
                            MostrarPrecioTotalProducto();
                            break;
                        case "7":
                            Console.WriteLine("¡Hasta luego!");
                            return;
                        default:
                            Console.WriteLine("Opción no válida. Intente nuevamente.");
                            break;
                    }
                }
            }
        }
    }
}