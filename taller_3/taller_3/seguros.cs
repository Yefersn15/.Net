using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taller_3
{
    internal class Seguros
    {
        public List<Conductor> conductores { get; set; } = new List<Conductor>();

        public class Conductor
        {
            public int añoNacimiento { get; set; }
            public int sexo { get; set; } // 1: Femenino, 2: Masculino
            public int registroCarro { get; set; } // 1: Bogotá, 2: Otras ciudades
            public int edad { get; set; }

            public void CalcularEdad()
            {
                int añoActual = DateTime.Now.Year;
                edad = añoActual - añoNacimiento;
            }
        }

        public void MenuSeguros()
        {
            int opcion;
            do
            {
                Console.WriteLine("\n=== SISTEMA DE SEGUROS - ACCIDENTES DE TRÁNSITO ===");
                Console.WriteLine("1. Registrar conductor involucrado en accidente");
                Console.WriteLine("2. Mostrar estadísticas");
                Console.WriteLine("3. Listar todos los conductores");
                Console.WriteLine("0. Salir");
                Console.WriteLine("Seleccione una opción:");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        RegistrarConductor();
                        break;
                    case 2:
                        MostrarEstadisticas();
                        break;
                    case 3:
                        ListarConductores();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del sistema de seguros...");
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

        public void RegistrarConductor()
        {
            Console.WriteLine("\n=== REGISTRAR CONDUCTOR EN ACCIDENTE ===");

            Conductor nuevoConductor = new Conductor();

            Console.WriteLine("Ingrese el año de nacimiento del conductor:");
            nuevoConductor.añoNacimiento = int.Parse(Console.ReadLine());
            nuevoConductor.CalcularEdad();

            Console.WriteLine("Ingrese el sexo del conductor:");
            Console.WriteLine("1. Femenino");
            Console.WriteLine("2. Masculino");
            nuevoConductor.sexo = int.Parse(Console.ReadLine());

            while (nuevoConductor.sexo != 1 && nuevoConductor.sexo != 2)
            {
                Console.WriteLine("Opción no válida. Ingrese 1 para Femenino o 2 para Masculino:");
                nuevoConductor.sexo = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Ingrese el registro del carro:");
            Console.WriteLine("1. Bogotá");
            Console.WriteLine("2. Otras ciudades");
            nuevoConductor.registroCarro = int.Parse(Console.ReadLine());

            while (nuevoConductor.registroCarro != 1 && nuevoConductor.registroCarro != 2)
            {
                Console.WriteLine("Opción no válida. Ingrese 1 para Bogotá o 2 para Otras ciudades:");
                nuevoConductor.registroCarro = int.Parse(Console.ReadLine());
            }

            conductores.Add(nuevoConductor);

            string sexoTexto = nuevoConductor.sexo == 1 ? "Femenino" : "Masculino";
            string registroTexto = nuevoConductor.registroCarro == 1 ? "Bogotá" : "Otras ciudades";

            Console.WriteLine($"\nConductor registrado exitosamente:");
            Console.WriteLine($"Edad: {nuevoConductor.edad} años");
            Console.WriteLine($"Sexo: {sexoTexto}");
            Console.WriteLine($"Registro: {registroTexto}");
        }

        public void MostrarEstadisticas()
        {
            if (conductores.Count == 0)
            {
                Console.WriteLine("No hay conductores registrados.");
                return;
            }

            Console.WriteLine("\n=== ESTADÍSTICAS DE ACCIDENTES DE TRÁNSITO ===");
            Console.WriteLine($"Total conductores involucrados: {conductores.Count}");

            // 1. Porcentaje de conductores menores de 30 años
            int conductoresMenores30 = conductores.Count(c => c.edad < 30);
            double porcentajeMenores30 = (double)conductoresMenores30 / conductores.Count * 100;
            Console.WriteLine($"\n1. PORCENTAJE DE CONDUCTORES MENORES DE 30 AÑOS:");
            Console.WriteLine($"   {conductoresMenores30} de {conductores.Count} conductores");
            Console.WriteLine($"   {porcentajeMenores30:F2}%");

            // 2. Porcentaje de conductores por sexo
            int conductoresFemeninos = conductores.Count(c => c.sexo == 1);
            int conductoresMasculinos = conductores.Count(c => c.sexo == 2);
            double porcentajeFemenino = (double)conductoresFemeninos / conductores.Count * 100;
            double porcentajeMasculino = (double)conductoresMasculinos / conductores.Count * 100;

            Console.WriteLine($"\n2. PORCENTAJE DE CONDUCTORES POR SEXO:");
            Console.WriteLine($"   Femenino: {conductoresFemeninos} conductores ({porcentajeFemenino:F2}%)");
            Console.WriteLine($"   Masculino: {conductoresMasculinos} conductores ({porcentajeMasculino:F2}%)");

            // 3. Porcentaje de conductores masculinos con edades entre 12 y 30 años
            int masculinos12a30 = conductores.Count(c => c.sexo == 2 && c.edad >= 12 && c.edad <= 30);
            double porcentajeMasculinos12a30 = (double)masculinos12a30 / conductores.Count * 100;
            double porcentajeMasculinos12a30DelTotalMasculino = conductoresMasculinos > 0 ?
            (double)masculinos12a30 / conductoresMasculinos * 100 : 0;

            Console.WriteLine($"\n3. PORCENTAJE DE CONDUCTORES MASCULINOS (12-30 AÑOS):");
            Console.WriteLine($"   {masculinos12a30} de {conductores.Count} conductores totales");
            Console.WriteLine($"   {porcentajeMasculinos12a30:F2}% del total de conductores");
            Console.WriteLine($"   {masculinos12a30} de {conductoresMasculinos} conductores masculinos");
            Console.WriteLine($"   {porcentajeMasculinos12a30DelTotalMasculino:F2}% del total de conductores masculinos");

            // 4. Porcentaje de conductores con carros registrados fuera de Bogotá
            int conductoresFueraBogota = conductores.Count(c => c.registroCarro == 2);
            double porcentajeFueraBogota = (double)conductoresFueraBogota / conductores.Count * 100;

            Console.WriteLine($"\n4. PORCENTAJE DE CONDUCTORES CON CARROS FUERA DE BOGOTÁ:");
            Console.WriteLine($"   {conductoresFueraBogota} de {conductores.Count} conductores");
            Console.WriteLine($"   {porcentajeFueraBogota:F2}%");

            // Estadísticas adicionales
            Console.WriteLine($"\nESTADÍSTICAS ADICIONALES:");
            Console.WriteLine($"Edad promedio: {conductores.Average(c => c.edad):F1} años");
            Console.WriteLine($"Conductor más joven: {conductores.Min(c => c.edad)} años");
            Console.WriteLine($"Conductor mayor: {conductores.Max(c => c.edad)} años");

            int conductoresBogota = conductores.Count(c => c.registroCarro == 1);
            Console.WriteLine($"Conductores de Bogotá: {conductoresBogota} ({((double)conductoresBogota / conductores.Count * 100):F2}%)");
        }

        public void ListarConductores()
        {
            if (conductores.Count == 0)
            {
                Console.WriteLine("No hay conductores registrados.");
                return;
            }

            Console.WriteLine("\n=== LISTA DE CONDUCTORES INVOLUCRADOS EN ACCIDENTES ===");
            foreach (var conductor in conductores)
            {
                string sexoTexto = conductor.sexo == 1 ? "Femenino" : "Masculino";
                string registroTexto = conductor.registroCarro == 1 ? "Bogotá" : "Otras ciudades";

                Console.WriteLine($"Año nacimiento: {conductor.añoNacimiento}");
                Console.WriteLine($"Edad: {conductor.edad} años");
                Console.WriteLine($"Sexo: {sexoTexto}");
                Console.WriteLine($"Registro carro: {registroTexto}");
                Console.WriteLine("---------------------------");
            }
        }
    }
}