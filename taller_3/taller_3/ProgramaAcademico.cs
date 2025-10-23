using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taller_3
{
    internal class ProgramaAcademico
    {
        public string Nombre { get; set; }
        public int Creditos { get; set; }
        public double Descuento { get; set; }

        public ProgramaAcademico(string nombre, int creditos, double descuento)
        {
            Nombre = nombre;
            Creditos = creditos;
            Descuento = descuento;
        }

        internal class Estudiante
        {
            public string Nombre { get; set; }
            public ProgramaAcademico Programa { get; set; }
            public string FormaPago { get; set; }
            public double ValorSinDescuento { get; set; }
            public double DescuentoAplicado { get; set; }
            public double ValorNeto { get; set; }

            public Estudiante(string nombre, ProgramaAcademico programa, string formaPago, double valorCredito)
            {
                Nombre = nombre;
                Programa = programa;
                FormaPago = formaPago;

                // Calcular valores
                ValorSinDescuento = programa.Creditos * valorCredito;

                if (formaPago.ToUpper() == "EFECTIVO")
                {
                    DescuentoAplicado = ValorSinDescuento * (programa.Descuento / 100);
                }
                else
                {
                    DescuentoAplicado = 0;
                }

                ValorNeto = ValorSinDescuento - DescuentoAplicado;
            }
        }

        internal class MatriculaUniversidad
        {
            private List<ProgramaAcademico> programas;
            private List<Estudiante> estudiantes;
            private const double VALOR_CREDITO = 200000;

            public MatriculaUniversidad()
            {
                programas = new List<ProgramaAcademico>
            {
                new ProgramaAcademico("Ingeniería de sistemas", 20, 18),
                new ProgramaAcademico("Psicología", 16, 12),
                new ProgramaAcademico("Economía", 18, 10),
                new ProgramaAcademico("Comunicación Social", 18, 5),
                new ProgramaAcademico("Administración de Empresas", 20, 15)
            };

                estudiantes = new List<Estudiante>();
            }

            public void MenuMatricula()
            {
                int opcion;
                do
                {
                    Console.WriteLine("\n=== SISTEMA DE MATRÍCULA UNIVERSITARIA ===");
                    Console.WriteLine("1. Matricular estudiante");
                    Console.WriteLine("2. Mostrar reportes");
                    Console.WriteLine("3. Listar estudiantes matriculados");
                    Console.WriteLine("0. Salir");
                    Console.WriteLine("Seleccione una opción:");

                    opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            MatricularEstudiante();
                            break;
                        case 2:
                            MostrarReportes();
                            break;
                        case 3:
                            ListarEstudiantes();
                            break;
                        case 0:
                            Console.WriteLine("Saliendo del sistema de matrícula...");
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

            private void MatricularEstudiante()
            {
                Console.WriteLine("\n=== MATRICULAR NUEVO ESTUDIANTE ===");

                Console.WriteLine("Ingrese el nombre del estudiante:");
                string nombre = Console.ReadLine();

                Console.WriteLine("\nSeleccione el programa académico:");
                for (int i = 0; i < programas.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {programas[i].Nombre} - {programas[i].Creditos} créditos - {programas[i].Descuento}% descuento");
                }

                int opcionPrograma = int.Parse(Console.ReadLine()) - 1;
                if (opcionPrograma < 0 || opcionPrograma >= programas.Count)
                {
                    Console.WriteLine("Opción de programa no válida.");
                    return;
                }

                Console.WriteLine("\nSeleccione la forma de pago:");
                Console.WriteLine("1. Efectivo (aplica descuento)");
                Console.WriteLine("2. Pago en línea (no aplica descuento)");
                int opcionPago = int.Parse(Console.ReadLine());

                string formaPago = opcionPago == 1 ? "EFECTIVO" : "LINEA";

                ProgramaAcademico programaSeleccionado = programas[opcionPrograma];
                Estudiante nuevoEstudiante = new Estudiante(nombre, programaSeleccionado, formaPago, VALOR_CREDITO);
                estudiantes.Add(nuevoEstudiante);

                Console.WriteLine($"\nEstudiante {nombre} matriculado exitosamente en {programaSeleccionado.Nombre}");
                Console.WriteLine($"Valor sin descuento: ${nuevoEstudiante.ValorSinDescuento:###,###}");
                if (formaPago == "EFECTIVO")
                {
                    Console.WriteLine($"Descuento aplicado: ${nuevoEstudiante.DescuentoAplicado:###,###}");
                }
                Console.WriteLine($"Valor neto a pagar: ${nuevoEstudiante.ValorNeto:###,###}");
            }

            private void MostrarReportes()
            {
                if (estudiantes.Count == 0)
                {
                    Console.WriteLine("No hay estudiantes matriculados.");
                    return;
                }

                Console.WriteLine("\n=== REPORTES DEL TERCER PERIODO ACADÉMICO 2020 ===");

                // a. Cantidad de estudiantes inscritos por programa académico
                Console.WriteLine("\na. CANTIDAD DE ESTUDIANTES INSCRITOS POR PROGRAMA:");
                foreach (var programa in programas)
                {
                    int cantidad = estudiantes.Count(e => e.Programa.Nombre == programa.Nombre);
                    Console.WriteLine($"   {programa.Nombre}: {cantidad} estudiantes");
                }

                // b. Total de créditos inscritos
                int totalCreditos = estudiantes.Sum(e => e.Programa.Creditos);
                Console.WriteLine($"\nb. TOTAL DE CRÉDITOS INSCRITOS: {totalCreditos} créditos");

                // c. Valor total pagado sin descuento
                double totalSinDescuento = estudiantes.Sum(e => e.ValorSinDescuento);
                Console.WriteLine($"\nc. VALOR TOTAL SIN DESCUENTO: ${totalSinDescuento:###,###}");

                // d. Valor total de descuentos aplicados
                double totalDescuentos = estudiantes.Sum(e => e.DescuentoAplicado);
                Console.WriteLine($"\nd. VALOR TOTAL DE DESCUENTOS: ${totalDescuentos:###,###}");

                // e. Valor neto de las inscripciones
                double valorNetoTotal = estudiantes.Sum(e => e.ValorNeto);
                Console.WriteLine($"\ne. VALOR NETO TOTAL: ${valorNetoTotal:###,###}");

                // Estadísticas adicionales
                Console.WriteLine($"\nESTADÍSTICAS ADICIONALES:");
                Console.WriteLine($"Total estudiantes matriculados: {estudiantes.Count}");

                int estudiantesEfectivo = estudiantes.Count(e => e.FormaPago == "EFECTIVO");
                int estudiantesLinea = estudiantes.Count(e => e.FormaPago == "LINEA");
                Console.WriteLine($"Estudiantes que pagaron en efectivo: {estudiantesEfectivo}");
                Console.WriteLine($"Estudiantes que pagaron en línea: {estudiantesLinea}");

                double ahorroPromedio = estudiantesEfectivo > 0 ? estudiantes.Where(e => e.FormaPago == "EFECTIVO").Average(e => e.DescuentoAplicado) : 0;
                Console.WriteLine($"Ahorro promedio por estudiante (efectivo): ${ahorroPromedio:###,###}");
            }

            private void ListarEstudiantes()
            {
                if (estudiantes.Count == 0)
                {
                    Console.WriteLine("No hay estudiantes matriculados.");
                    return;
                }

                Console.WriteLine("\n=== LISTA DE ESTUDIANTES MATRICULADOS ===");
                foreach (var estudiante in estudiantes)
                {
                    Console.WriteLine($"Nombre: {estudiante.Nombre}");
                    Console.WriteLine($"Programa: {estudiante.Programa.Nombre}");
                    Console.WriteLine($"Forma de pago: {estudiante.FormaPago}");
                    Console.WriteLine($"Valor sin descuento: ${estudiante.ValorSinDescuento:###,###}");
                    Console.WriteLine($"Descuento: ${estudiante.DescuentoAplicado:###,###}");
                    Console.WriteLine($"Valor neto: ${estudiante.ValorNeto:###,###}");
                    Console.WriteLine("---------------------------");
                }
            }
        }
    }

}