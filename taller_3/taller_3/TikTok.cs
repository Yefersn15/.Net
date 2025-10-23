using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taller_3
{
    internal class TikTok
    {
        public List<EmpleadoTikTok> empleados { get; set; } = new List<EmpleadoTikTok>();
        public const double VALOR_BONO = 150000;

        public class EmpleadoTikTok
        {
            public string nombre { get; set; }
            public DateTime fechaNacimiento { get; set; }
            public int edad { get; set; }
            public bool recibeBono { get; set; }
            public double bonoAsignado { get; set; }

            public void CalcularEdad()
            {
                DateTime fechaActual = DateTime.Now;
                edad = fechaActual.Year - fechaNacimiento.Year;

                if (fechaActual.Month < fechaNacimiento.Month ||
                    (fechaActual.Month == fechaNacimiento.Month && fechaActual.Day < fechaNacimiento.Day))
                {
                    edad--;
                }
            }

            public void VerificarBono()
            {
                CalcularEdad();
                if (edad > 18 && edad < 50)
                {
                    recibeBono = true;
                    bonoAsignado = VALOR_BONO;
                }
                else
                {
                    recibeBono = false;
                    bonoAsignado = 0;
                }
            }

            public string ObtenerMesCumpleaños()
            {
                return fechaNacimiento.ToString("MMMM");
            }
        }

        public void MenuTikTok()
        {
            int opcion;
            do
            {
                Console.WriteLine("\n=== SISTEMA TIK TOK - BONIFICACIONES ===");
                Console.WriteLine("1. Registrar empleado");
                Console.WriteLine("2. Mostrar reporte de bonificaciones");
                Console.WriteLine("3. Listar todos los empleados");
                Console.WriteLine("0. Salir");
                Console.WriteLine("Seleccione una opción:");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        RegistrarEmpleado();
                        break;
                    case 2:
                        MostrarReporteBonificaciones();
                        break;
                    case 3:
                        ListarEmpleados();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del sistema Tik Tok...");
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

        public void RegistrarEmpleado()
        {
            Console.WriteLine("\n=== REGISTRAR EMPLEADO TIK TOK ===");

            EmpleadoTikTok nuevoEmpleado = new EmpleadoTikTok();

            Console.WriteLine("Ingrese el nombre del empleado:");
            nuevoEmpleado.nombre = Console.ReadLine();

            Console.WriteLine("=== FECHA DE NACIMIENTO ===");
            Console.WriteLine("Ingrese el año de nacimiento:");
            int año = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el mes de nacimiento (1-12):");
            int mes = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el día de nacimiento:");
            int dia = int.Parse(Console.ReadLine());

            nuevoEmpleado.fechaNacimiento = new DateTime(año, mes, dia);
            nuevoEmpleado.VerificarBono();

            empleados.Add(nuevoEmpleado);

            Console.WriteLine($"\nEmpleado {nuevoEmpleado.nombre} registrado exitosamente.");
            Console.WriteLine($"Edad: {nuevoEmpleado.edad} años");
            Console.WriteLine($"Mes de cumpleaños: {nuevoEmpleado.ObtenerMesCumpleaños()}");

            if (nuevoEmpleado.recibeBono)
            {
                Console.WriteLine($"✅ CALIFICA PARA BONO: ${VALOR_BONO:###,###}");
            }
            else
            {
                Console.WriteLine($"❌ NO CALIFICA PARA BONO (edad: {nuevoEmpleado.edad} años)");
            }
        }

        public void MostrarReporteBonificaciones()
        {
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
                return;
            }

            Console.WriteLine("\n=== REPORTE DE BONIFICACIONES TIK TOK ===");

            // Calcular promedio de edades
            double promedioEdades = empleados.Average(e => e.edad);
            Console.WriteLine($"\nPROMEDIO DE EDADES: {promedioEdades:F1} años");

            // Lista desglosada por meses
            Console.WriteLine("\nLISTA DESGLOSADA POR MESES:");
            Console.WriteLine("============================");
            Console.WriteLine("| {0,-12} | {1,-15} | {2,-20} |", "Mes", "Empleados TikTok", "Dinero en Bonos");
            Console.WriteLine("|{0}|{1}|{2}|", new string('-', 14), new string('-', 17), new string('-', 22));

            var empleadosPorMes = empleados
                .Where(e => e.recibeBono)
                .GroupBy(e => e.ObtenerMesCumpleaños())
                .OrderBy(g => DateTime.ParseExact(g.Key, "MMMM", System.Globalization.CultureInfo.CurrentCulture).Month);

            double totalDineroBonos = 0;

            foreach (var grupo in empleadosPorMes)
            {
                int cantidadEmpleados = grupo.Count();
                double dineroBono = cantidadEmpleados * VALOR_BONO;
                totalDineroBonos += dineroBono;

                Console.WriteLine("| {0,-12} | {1,-15} | {2,-20} |",
                    grupo.Key,
                    $"{cantidadEmpleados} empleados",
                    $"${dineroBono:###,###}");
            }

            // Mostrar meses sin empleados que reciben bono
            string[] todosLosMeses = {
                "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
            };

            var mesesConBono = empleadosPorMes.Select(g => g.Key).ToList();
            var mesesSinBono = todosLosMeses.Except(mesesConBono);

            foreach (var mes in mesesSinBono)
            {
                Console.WriteLine("| {0,-12} | {1,-15} | {2,-20} |",
                    mes,
                    "0 empleados",
                    "$0");
            }

            Console.WriteLine("|{0}|{1}|{2}|", new string('-', 14), new string('-', 17), new string('-', 22));

            // Estadísticas generales
            int totalEmpleados = empleados.Count;
            int empleadosConBono = empleados.Count(e => e.recibeBono);
            int empleadosSinBono = totalEmpleados - empleadosConBono;

            Console.WriteLine($"\nESTADÍSTICAS GENERALES:");
            Console.WriteLine($"Total empleados registrados: {totalEmpleados}");
            Console.WriteLine($"Empleados que reciben bono: {empleadosConBono}");
            Console.WriteLine($"Empleados que NO reciben bono: {empleadosSinBono}");
            Console.WriteLine($"TOTAL DINERO EN BONOS: ${totalDineroBonos:###,###}");

            // Distribución por edades
            Console.WriteLine($"\nDISTRIBUCIÓN POR EDADES:");
            var menores18 = empleados.Count(e => e.edad <= 18);
            var entre18y50 = empleados.Count(e => e.edad > 18 && e.edad < 50);
            var mayores50 = empleados.Count(e => e.edad >= 50);

            Console.WriteLine($"Menores o igual a 18 años: {menores18} empleados");
            Console.WriteLine($"Entre 19 y 49 años: {entre18y50} empleados");
            Console.WriteLine($"Mayores o igual a 50 años: {mayores50} empleados");
        }

        public void ListarEmpleados()
        {
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
                return;
            }

            Console.WriteLine("\n=== LISTA DE EMPLEADOS TIK TOK ===");
            foreach (var empleado in empleados)
            {
                Console.WriteLine($"\nEMPLEADO: {empleado.nombre}");
                Console.WriteLine($"Fecha nacimiento: {empleado.fechaNacimiento:dd/MM/yyyy}");
                Console.WriteLine($"Edad: {empleado.edad} años");
                Console.WriteLine($"Mes cumpleaños: {empleado.ObtenerMesCumpleaños()}");

                if (empleado.recibeBono)
                {
                    Console.WriteLine($"✅ CALIFICA PARA BONO: ${empleado.bonoAsignado:###,###}");
                }
                else
                {
                    Console.WriteLine($"❌ NO CALIFICA PARA BONO");
                }
                Console.WriteLine("---------------------------");
            }
        }
    }
}