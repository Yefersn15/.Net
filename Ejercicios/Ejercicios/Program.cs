using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ejercicios.Vehiculo;

namespace Ejercicios
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Ejecutar sistema de mantenimiento de vehículos");
            Console.WriteLine("2. Ejecutar sistema de gestión de empleados");
            Console.WriteLine("3. Ejecutar sistema de biblioteca digital");
            int Opcion = int.Parse(Console.ReadLine());
            switch (Opcion)
            {
                case 1:
                    Console.WriteLine("=== SISTEMA DE MANTENIMIENTO TRANSMOVIL S.A. ===\n");

                    // Crear objetos de diferentes tipos de vehículos
                    Vehiculo automovil = new Vehiculo("Toyota", "Hilux", 45000);
                    Camion camionVolquete = new Camion("Volvo", "FH16", 120000, 15.5);
                    Camion camionReparto = new Camion("Mercedes-Benz", "Actros", 75000, 8.0);

                    // Mostrar información del automóvil
                    Console.WriteLine("=== AUTOMÓVIL ===");
                    automovil.MostrarInformacion();
                    Console.WriteLine($"Costo de mantenimiento: ${automovil.ObtenerCostoMantenimiento():F2}");
                    Console.WriteLine();

                    // Mostrar información del camión volquete
                    Console.WriteLine("=== CAMIÓN VOLQUETE ===");
                    camionVolquete.MostrarInformacion();
                    Console.WriteLine($"Costo de mantenimiento: ${camionVolquete.ObtenerCostoMantenimiento():F2}");
                    Console.WriteLine();

                    // Mostrar información del camión de reparto
                    Console.WriteLine("=== CAMIÓN DE REPARTO ===");
                    camionReparto.MostrarInformacion();
                    Console.WriteLine($"Costo de mantenimiento: ${camionReparto.ObtenerCostoMantenimiento():F2}");
                    Console.WriteLine();

                    // Demostrar actualización de kilometraje
                    Console.WriteLine("=== ACTUALIZACIÓN DE KILOMETRAJE ===");
                    automovil.ActualizarKilometraje(48000);
                    automovil.MostrarInformacion();
                    Console.WriteLine($"Nuevo costo de mantenimiento: ${automovil.ObtenerCostoMantenimiento():F2}");
                    Console.WriteLine();

                    // Intentar actualizar con kilometraje menor (debe fallar)
                    Console.WriteLine("=== INTENTO DE ACTUALIZACIÓN INVÁLIDA ===");
                    automovil.ActualizarKilometraje(47000);

                    Console.WriteLine("\n=== FIN DEL REPORTE ===");

                    break;
                case 2:
                    Console.WriteLine("=== SISTEMA DE GESTIÓN DE EMPLEADOS - TECHGLOBAL ===\n");

                    // Crear empleados regulares
                    Empleado empleado1 = new Empleado("María González", "Desarrollador Senior", 50000);
                    Empleado empleado2 = new Empleado("Carlos Rodríguez", "Analista de Sistemas", 45000);
                    Empleado empleado3 = new Empleado("Ana López", "Diseñadora UX", 42000);

                    // Crear gerentes
                    Gerente gerente1 = new Gerente("Roberto Silva", "Gerente de TI", 80000, "Tecnología", 10000);
                    Gerente gerente2 = new Gerente("Laura Mendoza", "Gerente de Operaciones", 75000, "Operaciones", 8500);

                    // Mostrar información de empleados regulares
                    Console.WriteLine("\n--- EMPLEADOS REGULARES ---");
                    empleado1.MostrarInformacion();
                    empleado2.MostrarInformacion();
                    empleado3.MostrarInformacion();

                    // Mostrar información de gerentes
                    Console.WriteLine("\n--- GERENTES ---");
                    gerente1.MostrarInformacion();
                    gerente2.MostrarInformacion();

                    // Mostrar resúmenes ejecutivos de gerentes
                    Console.WriteLine("\n--- RESUMENES EJECUTIVOS ---");
                    gerente1.MostrarResumenEjecutivo();
                    gerente2.MostrarResumenEjecutivo();

                    // Demostrar modificación de salario (área administrativa)
                    Console.WriteLine("\n--- ACTUALIZACIÓN DE SALARIOS (ÁREA ADMINISTRATIVA) ---");

                    // Intento sin permisos
                    Console.WriteLine("Intento sin permisos:");
                    empleado1.ActualizarSalario(55000, "CLAVE_INCORRECTA");

                    // Intento con permisos administrativos
                    Console.WriteLine("\nIntento con permisos administrativos:");
                    empleado1.ActualizarSalario(55000, "ADMIN123");

                    // Mostrar información actualizada
                    Console.WriteLine("\nInformación actualizada:");
                    empleado1.MostrarInformacion();

                    // Demostrar cálculos de bonos específicos
                    Console.WriteLine("\n--- CÁLCULOS DE BONOS ---");
                    Console.WriteLine($"Bono total gerente TI: ${gerente1.CalcularBonoTotal():F2}");
                    Console.WriteLine($"Bono total gerente Operaciones: ${gerente2.CalcularBonoTotal():F2}");

                    Console.WriteLine("\n=== FIN DEL REPORTE ===");
                    break;
                case 3:
                    Console.WriteLine("=== SISTEMA DE BIBLIOTECA DIGITAL LECTURA VIVA ===\n");

                    // Crear libros físicos
                    Libro libro1 = new Libro("Cien años de soledad", "Gabriel García Márquez", 471);
                    Libro libro2 = new Libro("1984", "George Orwell", 328);
                    Libro libro3 = new Libro("El Quijote", "Miguel de Cervantes", 863);

                    // Crear libros digitales
                    LibroDigital libroDigital1 = new LibroDigital("Dune", "Frank Herbert", 412, 5.2);
                    LibroDigital libroDigital2 = new LibroDigital("Fundación", "Isaac Asimov", 255, 3.8);
                    LibroDigital libroDigital3 = new LibroDigital("Neuromante", "William Gibson", 271, 4.1);

                    // Mostrar información de libros físicos
                    Console.WriteLine("\n--- LIBROS FÍSICOS ---");
                    libro1.MostrarInformacion();
                    libro2.MostrarInformacion();
                    libro3.MostrarInformacion();

                    // Mostrar información de libros digitales
                    Console.WriteLine("\n--- LIBROS DIGITALES ---");
                    libroDigital1.MostrarInformacion();
                    libroDigital2.MostrarInformacion();
                    libroDigital3.MostrarInformacion();

                    // Mostrar resúmenes usando el método protegido
                    Console.WriteLine("\n--- RESUMENES DE LIBROS ---");
                    libro1.MostrarResumen();
                    libro2.MostrarResumen();
                    libro3.MostrarResumen();
                    libroDigital1.MostrarResumen();
                    libroDigital2.MostrarResumen();
                    libroDigital3.MostrarResumen();

                    // Mostrar información específica de libros digitales
                    Console.WriteLine("\n--- INFORMACIÓN DE DESCARGA ---");
                    libroDigital1.MostrarInformacionDescarga();
                    libroDigital2.MostrarInformacionDescarga();
                    libroDigital3.MostrarInformacionDescarga();

                    // Demostrar modificación de páginas (solo personal biblioteca)
                    Console.WriteLine("\n--- ACTUALIZACIÓN DE PÁGINAS (PERSONAL BIBLIOTECA) ---");

                    // Intento sin permisos
                    Console.WriteLine("Intento sin permisos:");
                    libro1.ActualizarNumeroPaginas(480, "CLAVE_INCORRECTA");

                    // Intento con permisos de biblioteca
                    Console.WriteLine("\nIntento con permisos de biblioteca:");
                    libro1.ActualizarNumeroPaginas(480, "BIBLIO123");

                    // Mostrar información actualizada
                    Console.WriteLine("\nInformación actualizada:");
                    libro1.MostrarInformacion();

                    Console.WriteLine("\n=== FIN DEL CATÁLOGO ===");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}