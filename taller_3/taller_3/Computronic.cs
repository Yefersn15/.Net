using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taller_3
{
    internal class Computronic
    {
        public List<Empleado> empleados { get; set; } = new List<Empleado>();
        public const double PAGO_BASICO = 500000;

        public class Empleado
        {
            public string nombre { get; set; }
            public List<double> ventas { get; set; } = new List<double>();
            public int ventasMenores300 { get; set; }
            public int ventasEntre300800 { get; set; }
            public int ventasMayores800 { get; set; }
            public double totalVentas { get; set; }
            public double bonificacion { get; set; }
            public double totalPagar { get; set; }

            public void CalcularEstadisticas()
            {
                ventasMenores300 = 0;
                ventasEntre300800 = 0;
                ventasMayores800 = 0;
                totalVentas = 0;
                bonificacion = 0;

                foreach (var venta in ventas)
                {
                    totalVentas += venta;

                    if (venta <= 300000)
                    {
                        ventasMenores300++;
                    }
                    else if (venta > 300000 && venta < 800000)
                    {
                        ventasEntre300800++;
                    }
                    else if (venta >= 800000)
                    {
                        ventasMayores800++;
                    }

                    // Calcular bonificación por venta
                    if (venta >= 400000 && venta <= 800000)
                    {
                        bonificacion += venta * 0.03;
                    }
                    else if (venta > 400000 && venta < 800000)
                    {
                        bonificacion += venta * 0.05;
                    }
                    else if (venta > 800000)
                    {
                        bonificacion += venta * 0.10;
                    }
                }

                totalPagar = PAGO_BASICO + bonificacion;
            }
        }

        public void MenuComputronic()
        {
            int opcion;
            do
            {
                Console.WriteLine("\n=== SISTEMA COMPUTRONIC ===");
                Console.WriteLine("1. Registrar empleado y ventas");
                Console.WriteLine("2. Mostrar reporte del día");
                Console.WriteLine("3. Listar todos los empleados");
                Console.WriteLine("0. Salir");
                Console.WriteLine("Seleccione una opción:");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        RegistrarEmpleadoVentas();
                        break;
                    case 2:
                        MostrarReporteDia();
                        break;
                    case 3:
                        ListarEmpleados();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del sistema COMPUTRONIC...");
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

        public void RegistrarEmpleadoVentas()
        {
            Console.WriteLine("\n=== REGISTRAR EMPLEADO Y VENTAS ===");

            Console.WriteLine("Ingrese el nombre del empleado:");
            string nombre = Console.ReadLine();

            Empleado nuevoEmpleado = new Empleado();
            nuevoEmpleado.nombre = nombre;

            Console.WriteLine($"¿Cuántas ventas realizó {nombre} hoy?");
            int cantidadVentas = int.Parse(Console.ReadLine());

            for (int i = 0; i < cantidadVentas; i++)
            {
                Console.WriteLine($"Ingrese el valor de la venta #{i + 1}:");
                double venta = double.Parse(Console.ReadLine());

                if (venta < 0)
                {
                    Console.WriteLine("Error: El valor debe ser positivo. Intente nuevamente.");
                    i--;
                    continue;
                }

                nuevoEmpleado.ventas.Add(venta);
            }

            nuevoEmpleado.CalcularEstadisticas();
            empleados.Add(nuevoEmpleado);

            Console.WriteLine($"\nEmpleado {nombre} registrado exitosamente.");
            Console.WriteLine($"Total ventas: ${nuevoEmpleado.totalVentas:###,###}");
            Console.WriteLine($"Bonificación: ${nuevoEmpleado.bonificacion:###,###}");
            Console.WriteLine($"Total a pagar: ${nuevoEmpleado.totalPagar:###,###}");
        }

        public void MostrarReporteDia()
        {
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
                return;
            }

            Console.WriteLine("\n=== REPORTE DEL DÍA - COMPUTRONIC ===");

            // Totales generales
            int totalVentasMenores300 = 0;
            int totalVentasEntre300800 = 0;
            int totalVentasMayores800 = 0;
            double totalVentasEmpresa = 0;
            double totalBonificaciones = 0;
            double totalPagos = 0;

            foreach (var empleado in empleados)
            {
                totalVentasMenores300 += empleado.ventasMenores300;
                totalVentasEntre300800 += empleado.ventasEntre300800;
                totalVentasMayores800 += empleado.ventasMayores800;
                totalVentasEmpresa += empleado.totalVentas;
                totalBonificaciones += empleado.bonificacion;
                totalPagos += empleado.totalPagar;
            }

            Console.WriteLine($"\nTOTALES GENERALES:");
            Console.WriteLine($"Total empleados: {empleados.Count}");
            Console.WriteLine($"Total ventas registradas: {empleados.Sum(e => e.ventas.Count)}");
            Console.WriteLine($"Total ventas empresa: ${totalVentasEmpresa:###,###}");

            Console.WriteLine($"\nDISTRIBUCIÓN DE VENTAS:");
            Console.WriteLine($"Ventas <= $300,000: {totalVentasMenores300}");
            Console.WriteLine($"Ventas entre $300,001 y $799,999: {totalVentasEntre300800}");
            Console.WriteLine($"Ventas >= $800,000: {totalVentasMayores800}");

            Console.WriteLine($"\nTOTALES DE PAGOS:");
            Console.WriteLine($"Total pagos básicos: ${empleados.Count * PAGO_BASICO:###,###}");
            Console.WriteLine($"Total bonificaciones: ${totalBonificaciones:###,###}");
            Console.WriteLine($"Total a pagar a empleados: ${totalPagos:###,###}");

            // Empleado con mejor desempeño
            var mejorEmpleado = empleados.OrderByDescending(e => e.totalVentas).First();
            Console.WriteLine($"\nEMPLEADO CON MEJOR DESEMPEÑO:");
            Console.WriteLine($"Nombre: {mejorEmpleado.nombre}");
            Console.WriteLine($"Total ventas: ${mejorEmpleado.totalVentas:###,###}");
            Console.WriteLine($"Bonificación: ${mejorEmpleado.bonificacion:###,###}");
        }

        public void ListarEmpleados()
        {
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
                return;
            }

            Console.WriteLine("\n=== LISTA DE EMPLEADOS ===");
            foreach (var empleado in empleados)
            {
                Console.WriteLine($"\nEMPLEADO: {empleado.nombre}");
                Console.WriteLine($"Total ventas: {empleado.ventas.Count}");
                Console.WriteLine($"Ventas <= $300,000: {empleado.ventasMenores300}");
                Console.WriteLine($"Ventas $300,001-$799,999: {empleado.ventasEntre300800}");
                Console.WriteLine($"Ventas >= $800,000: {empleado.ventasMayores800}");
                Console.WriteLine($"Total ventas: ${empleado.totalVentas:###,###}");
                Console.WriteLine($"Pago básico: ${PAGO_BASICO:###,###}");
                Console.WriteLine($"Bonificación: ${empleado.bonificacion:###,###}");
                Console.WriteLine($"TOTAL A PAGAR: ${empleado.totalPagar:###,###}");
                Console.WriteLine("---------------------------");
            }
        }
    }
}