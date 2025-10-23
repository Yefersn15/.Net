using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static taller_3.ProgramaAcademico;

namespace taller_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SISTEMA INTEGRAL - TALLER 3 ===");
            Console.WriteLine("Seleccione una de las siguientes opciones:");
            Console.WriteLine("1. Sistema de Préstamos Estudiantiles (Intereses y amortización)");
            Console.WriteLine("2. Generador de Colillas de Pago (Nómina empleados)");
            Console.WriteLine("3. Agenda Personal (Gestión de contactos)");
            Console.WriteLine("4. Sistema Bibliotecario (Catálogo de libros)");
            Console.WriteLine("5. Matrícula Universitaria (Proceso de inscripción 2020)");
            Console.WriteLine("6. COMPUTRONIC (Control de ventas y bonificaciones)");
            Console.WriteLine("7. Estadísticas de Seguros (Accidentes de tránsito)");
            Console.WriteLine("8. Tik Tok (Bonificaciones por cumpleaños)");
            Console.WriteLine("9. Distribución de Alcohol (Control de carga camiones)");
            Console.Write("\nIngrese su opción: ");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Un estudiante realiza un préstamo a un plazo de 5 años, donde la tasa fija de interés es del 5% anual, se debe solicitar el monto del préstamo y se desea calcular la siguiente información.");
                    Console.WriteLine("Ingrese el monto del préstamo:");
                    float montoPrestamo = float.Parse(Console.ReadLine());
                    float InteresesAnuales = montoPrestamo * 0.05f;
                    Console.WriteLine("Intereses Anuales: " + InteresesAnuales);
                    float InteresesMensuales = InteresesAnuales / 12;
                    Console.WriteLine("Intereses Mensuales: " + InteresesMensuales);
                    float interesestrimestrales = InteresesAnuales / 4;
                    Console.WriteLine("Intereses Trimestrales: " + interesestrimestrales);
                    float totalPagar = montoPrestamo + (InteresesAnuales * 5);
                    Console.WriteLine("Total a Pagar: " + totalPagar);
                    break;

                case 2:
                    Console.WriteLine("Desarrollar un algoritmo que permita generar la colilla de pago de los empleados de una empresa.");
                    Console.WriteLine("Ingrese el nombre del empleado:");
                    string nombreEmpleado = Console.ReadLine();
                    Console.WriteLine("Ingrese el salario del empleado:");
                    float salarioEmpleado = float.Parse(Console.ReadLine());
                    float ahorro = salarioEmpleado * 0.05f;
                    Console.WriteLine("Ahorro: " + ahorro);
                    float salud = salarioEmpleado * 0.125f;
                    Console.WriteLine("Salud: " + salud);
                    float pension = salarioEmpleado * 0.16f;
                    Console.WriteLine("Pension: " + pension);
                    float totalDeducciones = ahorro + salud + pension;
                    Console.WriteLine("Deducciones: " + totalDeducciones);
                    float salarioNeto = salarioEmpleado - totalDeducciones;
                    Console.WriteLine("Salario Neto: " + salarioNeto);
                    break;

                case 3:
                    GestionPersonas gestionPersonas = new GestionPersonas();
                    gestionPersonas.MenuGestion();
                    break;
                case 4:
                    Biblioteca biblioteca = new Biblioteca();
                    biblioteca.MenuBiblioteca();
                    break;
                case 5:
                    MatriculaUniversidad matricula = new MatriculaUniversidad();
                    matricula.MenuMatricula();
                    break;

                case 6:
                    // COMPUTRONIC
                    Computronic computronic = new Computronic();
                    computronic.MenuComputronic();
                    break;

                case 7:
                    // Seguros
                    Seguros seguros = new Seguros();
                    seguros.MenuSeguros();
                    break;

                case 8:
                    // Tik Tok
                    TikTok tikTok = new TikTok();
                    tikTok.MenuTikTok();
                    break;

                case 9:
                    // Alcohol
                    Alcohol alcohol = new Alcohol();
                    alcohol.MenuAlcohol();
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}