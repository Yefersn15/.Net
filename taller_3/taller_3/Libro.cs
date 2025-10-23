using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taller_3
{
    internal class Libro
    {
        public string titulo { get; set; }
        public string autor { get; set; }
        public string editorial { get; set; }
        public DateTime anioPublicacion { get; set; }

        public Libro(string titulo, string autor, string editorial, DateTime anioPublicacion)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.editorial = editorial;
            this.anioPublicacion = anioPublicacion;
        }

        // Método para mostrar información del libro
        public void MostrarInformacion()
        {
            Console.WriteLine($"Título: {titulo}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Editorial: {editorial}");
            Console.WriteLine($"Año de Publicación: {anioPublicacion:yyyy}");
            Console.WriteLine("---------------------------");
        }
    }

    internal class Biblioteca
    {
        public List<Libro> libros { get; set; } = new List<Libro>();

        // Método para agregar libro
        public void AgregarLibro()
        {
            Console.WriteLine("\n=== AGREGAR NUEVO LIBRO ===");

            Console.WriteLine("Ingrese el título del libro:");
            string titulo = Console.ReadLine();

            Console.WriteLine("Ingrese el autor del libro:");
            string autor = Console.ReadLine();

            Console.WriteLine("Ingrese la editorial del libro:");
            string editorial = Console.ReadLine();

            Console.WriteLine("Ingrese el año de publicación:");
            int anio = int.Parse(Console.ReadLine());
            DateTime anioPublicacion = new DateTime(anio, 1, 1);

            Libro nuevoLibro = new Libro(titulo, autor, editorial, anioPublicacion);
            libros.Add(nuevoLibro);

            Console.WriteLine($"Libro '{titulo}' agregado exitosamente.");
        }

        // Método para listar todos los libros
        public void ListarLibros()
        {
            if (libros.Count == 0)
            {
                Console.WriteLine("No hay libros en la biblioteca.");
                return;
            }

            Console.WriteLine("\n=== LISTA DE LIBROS ===");
            foreach (var libro in libros)
            {
                libro.MostrarInformacion();
            }
        }

        // Método para buscar libro por nombre
        public void BuscarLibroPorNombre()
        {
            Console.WriteLine("\n=== BUSCAR LIBRO ===");
            Console.WriteLine("Ingrese el título del libro a buscar:");
            string tituloBuscado = Console.ReadLine();

            // Buscar libros que contengan el texto (case insensitive)
            var librosEncontrados = libros.Where(l =>
                l.titulo.ToLower().Contains(tituloBuscado.ToLower())).ToList();

            if (librosEncontrados.Count > 0)
            {
                Console.WriteLine($"\nSe encontraron {librosEncontrados.Count} libro(s):");
                foreach (var libro in librosEncontrados)
                {
                    libro.MostrarInformacion();
                }
            }
            else
            {
                Console.WriteLine($"No se encontraron libros con el título: '{tituloBuscado}'");
            }
        }

        // Método para mostrar el menú y gestionar opciones
        public void MenuBiblioteca()
        {
            int opcion;
            do
            {
                Console.WriteLine("\n=== BIBLIOTECA ===");
                Console.WriteLine("1. Agregar libro");
                Console.WriteLine("2. Listar libros");
                Console.WriteLine("3. Buscar libro por nombre");
                Console.WriteLine("0. Salir");
                Console.WriteLine("Seleccione una opción:");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AgregarLibro();
                        break;
                    case 2:
                        ListarLibros();
                        break;
                    case 3:
                        BuscarLibroPorNombre();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo de la biblioteca...");
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